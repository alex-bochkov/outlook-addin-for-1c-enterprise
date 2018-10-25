Imports Microsoft.Win32

Public Class ConfigForm



    Public Sub New()

        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        ' Добавьте все инициализирующие действия после вызова InitializeComponent().

    End Sub

    Private Sub ConfigForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Dim regKey As RegistryKey = My.Computer.Registry.CurrentUser.CreateSubKey(ThisAddIn.RegistryPath)

        RefWS.Text = regKey.GetValue("WS Address")
        AuthWindows.Checked = regKey.GetValue("Auth type") = "Windows"
        Auth1C.Checked = Not regKey.GetValue("Auth type") = "Windows"
        Login.Text = regKey.GetValue("WS user")
        Password.Text = regKey.GetValue("WS password")

        regKey.Close()

        ShowFields()

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles AuthWindows.CheckedChanged
        ShowFields()
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Auth1C.CheckedChanged
        ShowFields()
    End Sub

    Private Sub ShowFields()

        Login.Enabled = Auth1C.Checked
        Password.Enabled = Auth1C.Checked

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click


        Dim regKey As RegistryKey = My.Computer.Registry.CurrentUser.CreateSubKey(ThisAddIn.RegistryPath)
        regKey.SetValue("WS Address", RefWS.Text)
        regKey.SetValue("WS user", Login.Text)
        regKey.SetValue("WS password", Password.Text)
        regKey.SetValue("Auth type", IIf(AuthWindows.Checked, "Windows", "1C"))
        regKey.Close()

        Dim Success = False
        Dim text = ""

        Try
            Dim ws = (New ThisAddIn.WebRequest).GetServiceALP()

            Dim mess = ws.TestConnection()

            Success = (mess = True)

            If Not Success Then
                text = "Web-сервис вернул неправильный ответ " + mess.ToString
            End If

        Catch ex As Exception
            text = ex.Message
        End Try

        If Success Then
            Close()
        Else
            MsgBox("Ошибка проверки указанных параметров доступа:" + vbNewLine + text)
        End If

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click

        Close()

    End Sub
End Class