Imports System.Xml
Imports System.ServiceModel
Imports System.Security.Principal
Imports System.Net
Imports Microsoft.Win32

Public Class ThisAddIn

    Public Const RegistryPath = "Software\ALP Group\OutlookAddinCons"

    Private WithEvents TimerCheckConnection As New System.Windows.Forms.Timer

    Public Class FileInfo
        Public ID As Integer
        Public Name
        Public Data
        Public Path = ""
        Public DateChange
        Public Extension
        Public LockForEditing As Boolean

        Public Size
        Public DateChangeLocal

        Function GetBytes()


            If My.Computer.FileSystem.FileExists(Path) Then
                Dim FileInfo = My.Computer.FileSystem.GetFileInfo(Path)
                Size = FileInfo.Length
                DateChangeLocal = FileInfo.LastWriteTime
            Else
                DateChangeLocal = DateChange
            End If

            GetBytes = My.Computer.FileSystem.ReadAllBytes(Path)

        End Function
        Public Sub SaveFileLocal()

            Dim PathToFile = My.Computer.FileSystem.SpecialDirectories.MyDocuments

            Dim CatalogPath = PathToFile + IIf(PathToFile.EndsWith("\"), "", "\") + "BDKS\" + Now.ToString("yyyy-MM-dd") + "\"

            If Not My.Computer.FileSystem.DirectoryExists(CatalogPath) Then
                My.Computer.FileSystem.CreateDirectory(CatalogPath)
            End If
            PathToFile = CatalogPath + Name + "." + Extension
            My.Computer.FileSystem.WriteAllBytes(PathToFile, Data, False)
            Path = PathToFile



        End Sub

        Public Function AllToString()

            AllToString = "{" + Name + "}{" + ID.ToString + "}{" + Path + "}{" + Extension + "}{" + IIf(LockForEditing, "1", "0") + "}{" + DateChange.ToString() + "}"

        End Function

        Public Sub AllFromString(InStr As String)

            Try
                Dim Str = InStr
                Dim Pos = Str.IndexOf("}")
                Name = Str.Substring(1, Pos - 1)
                Str = Str.Substring(Pos + 1)

                Pos = Str.IndexOf("}")
                ID = Convert.ToInt32(Str.Substring(1, Pos - 1))
                Str = Str.Substring(Pos + 1)

                Pos = Str.IndexOf("}")
                Path = Str.Substring(1, Pos - 1)
                Str = Str.Substring(Pos + 1)

                Pos = Str.IndexOf("}")
                Extension = Str.Substring(1, Pos - 1)
                Str = Str.Substring(Pos + 1)

                Pos = Str.IndexOf("}")
                LockForEditing = IIf(Str.Substring(1, Pos - 1) = "0", False, True)
                Str = Str.Substring(Pos + 1)

                Pos = Str.IndexOf("}")
                DateChange = Convert.ToDateTime(Str.Substring(1, Pos - 1))

            Catch ex As Exception

            End Try

            If My.Computer.FileSystem.FileExists(Path) Then
                Dim FileInfo = My.Computer.FileSystem.GetFileInfo(Path)
                Size = FileInfo.Length
                DateChangeLocal = FileInfo.LastWriteTime
            Else
                DateChangeLocal = DateChange
            End If

        End Sub

    End Class

    Public Class WebRequest

        Function ValidateCertificate()
            ValidateCertificate = True
        End Function

        Public Function GetServiceALP() As ServiceReferenceALP.ALP_OutlookServicesPortTypeClient

            Dim regKey As RegistryKey = My.Computer.Registry.CurrentUser.CreateSubKey(RegistryPath)

            Dim RefWS As String = regKey.GetValue("WS Address")
            Dim AuthWindows As Boolean = regKey.GetValue("Auth type") = "Windows"
            Dim Login As String = regKey.GetValue("WS user")
            Dim Password As String = regKey.GetValue("WS password")

            regKey.Close()

            Dim https = RefWS.ToLower.StartsWith("https:")

            Dim basicHttpBinding As BasicHttpBinding

            If https Then
                Net.ServicePointManager.ServerCertificateValidationCallback =
                    New Net.Security.RemoteCertificateValidationCallback(AddressOf ValidateCertificate)
                basicHttpBinding = New BasicHttpBinding(BasicHttpSecurityMode.Transport)
            Else
                basicHttpBinding = New BasicHttpBinding(BasicHttpSecurityMode.TransportCredentialOnly)
            End If

            basicHttpBinding.MaxReceivedMessageSize = 20 * 1024 * 1024 ' 20 Mb

            If AuthWindows Then
                basicHttpBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Windows
            Else
                basicHttpBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic
            End If

            Dim reportService = New ServiceReferenceALP.ALP_OutlookServicesPortTypeClient(basicHttpBinding, New EndpointAddress(RefWS))

            If AuthWindows Then
                reportService.ClientCredentials.Windows.AllowedImpersonationLevel = TokenImpersonationLevel.Impersonation
                reportService.ChannelFactory.Credentials.Windows.ClientCredential = CredentialCache.DefaultNetworkCredentials
            Else
                reportService.ClientCredentials.UserName.UserName = Login
                reportService.ClientCredentials.UserName.Password = Password
            End If

            Return (reportService)

        End Function

    End Class

    Public Sub OpenConfig()

        Dim Form = New ConfigForm
        Form.ShowDialog()

    End Sub

    Private Sub TestConnection(myObject As Object, ByVal myEventArgs As EventArgs) Handles TimerCheckConnection.Tick

        Try
            Dim WS = (New WebRequest).GetServiceALP()
            WS.TestConnection()
        Catch ex As Exception

        End Try


    End Sub


    Private Sub ThisAddIn_Startup() Handles Me.Startup

        'Периодически будем опрашивать центральную базу, чтобы подключение всегда происходило быстро
        Try
            TimerCheckConnection.Interval = 1000 * 60 * 10 'every 10 min
            TimerCheckConnection.Start()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ThisAddIn_Shutdown() Handles Me.Shutdown

    End Sub

    Private Sub Application_NewMail() Handles Application.NewMail

    End Sub

    Private Sub Application_NewMailEx(EntryIDCollection As String) Handles Application.NewMailEx

        Try

            Dim varEntryIDs
            Dim objItem
            Dim i As Integer

            varEntryIDs = Split(EntryIDCollection, ",")

            For i = 0 To UBound(varEntryIDs)

                objItem = Application.Session.GetItemFromID(varEntryIDs(i))

                'MsgBox(objItem.Subject)

                Dim propAccessor As Outlook.PropertyAccessor = objItem.PropertyAccessor
                Dim internetHeaders As String = propAccessor.GetProperty("http://schemas.microsoft.com/mapi/proptag/0x007D001E")

                Dim Pos As Integer = internetHeaders.IndexOf("X-ALP-GUID: ")
                If Pos > 0 Then
                    Pos = internetHeaders.IndexOf("X-ALP-DEADLINE: ")
                    If Pos > 0 Then
                        Dim DeadLineStr = internetHeaders.Substring(Pos + 16, 19)
                        Dim DeadLineDate = Convert.ToDateTime(DeadLineStr)

                        objItem.FlagDueBy = DeadLineDate
                        objItem.FlagIcon = 6
                        objItem.FlagRequest = "Согласовать"
                        objItem.FlagStatus = 2

                        objItem.ReminderSet = True
                        objItem.ReminderTime = DeadLineDate.AddMinutes(-15)
                        objItem.ToDoTaskOrdinal = Now
                        objItem.TaskStartDate = Now
                        objItem.TaskDueDate = DeadLineDate
                        objItem.Save()
                    End If
                End If
            Next

        Catch ex As Exception

        End Try

    End Sub


End Class
