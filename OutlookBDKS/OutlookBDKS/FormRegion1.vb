Imports System.Xml
Imports System.ServiceModel
Imports System.Security.Principal
Imports System.Net

Public Class FormRegion1
    Public IDProcess As String
    Private WebRequest As ThisAddIn.WebRequest = New ThisAddIn.WebRequest

#Region "Form Region Factory"

    <Microsoft.Office.Tools.Outlook.FormRegionMessageClass(Microsoft.Office.Tools.Outlook.FormRegionMessageClassAttribute.Note)> _
    <Microsoft.Office.Tools.Outlook.FormRegionName("OutlookBDKS.FormRegion1")> _
    Partial Public Class FormRegion1Factory

        ' Occurs before the form region is initialized.
        ' To prevent the form region from appearing, set e.Cancel to true.
        ' Use e.OutlookItem to get a reference to the current Outlook item.
        Private Sub FormRegion1Factory_FormRegionInitializing(ByVal sender As Object, ByVal e As Microsoft.Office.Tools.Outlook.FormRegionInitializingEventArgs) Handles Me.FormRegionInitializing

            Dim propAccessor As Outlook.PropertyAccessor = e.OutlookItem.PropertyAccessor
            Dim internetHeaders As String = propAccessor.GetProperty("http://schemas.microsoft.com/mapi/proptag/0x007D001E")

            If internetHeaders.Contains("X-ALP-BDKS: Yes") Then

            Else
                e.Cancel = True
            End If

        End Sub

    End Class

#End Region

    'Occurs before the form region is displayed. 
    'Use Me.OutlookItem to get a reference to the current Outlook item.
    'Use Me.OutlookFormRegion to get a reference to the form region.
    Private Sub FormRegion1_FormRegionShowing(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.FormRegionShowing

        Dim propAccessor As Outlook.PropertyAccessor = Me.OutlookItem.PropertyAccessor
        Dim internetHeaders As String = propAccessor.GetProperty("http://schemas.microsoft.com/mapi/proptag/0x007D001E")

        Dim Pos As Integer = internetHeaders.IndexOf("X-ALP-GUID: ")
        If Pos > 0 Then
            IDProcess = internetHeaders.Substring(Pos + 12, 36)
        End If

        AfterAgreement()


    End Sub

    Sub AfterAgreement()
        For Each Prop In Me.OutlookItem.UserProperties
            Dim a = Prop.Name.ToString
            If a = "AgreementConfirm" Then
                ButtonAgree.Enabled = False
                ButtonCancelAgree.Enabled = False
                LabelInformer.Text = "Документ был СОГЛАСОВАН " + Prop.Value.ToString
            ElseIf a = "AgreementCancel" Then
                ButtonAgree.Enabled = False
                ButtonCancelAgree.Enabled = False
                LabelInformer.Text = "Документ был ОТКЛОНЕН " + Prop.Value.ToString
            End If
        Next
    End Sub

    'Occurs when the form region is closed.   
    'Use Me.OutlookItem to get a reference to the current Outlook item.
    'Use Me.OutlookFormRegion to get a reference to the form region.
    Private Sub FormRegion1_FormRegionClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.FormRegionClosed

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles ButtonAgree.Click

        If CheckEditingFiles() Then
            Exit Sub
        End If

        Dim Form = New UserConfirm
        Form.Text = "СОГЛАСОВАНИЕ документа"
        Form.ShowDialog()

        If Form.Result Then
            DoSomePutAgreement("PutAgreement", Form.RichTextBox1.Text)
        End If

    End Sub

    Function CheckEditingFiles()

        CheckEditingFiles = False

        'Проверим наличие захваченных файлов
        Dim UserMess = ""

        For Each Prop In Me.OutlookItem.UserProperties
            Dim a = Prop.Name.ToString
            If a.StartsWith("File") Then
                Dim f = New ThisAddIn.FileInfo
                f.AllFromString(Prop.Value)
                If f.LockForEditing Then
                    UserMess = UserMess + IIf(UserMess = "", "", vbNewLine) + f.Name
                End If
            End If
        Next
        If Not UserMess = "" Then
            Dim Resp = MsgBox("Некоторые файлы приложенного документа заняты Вами для редактирования:" + vbNewLine + _
                                UserMess + vbNewLine + vbNewLine + _
                              "Выполнить задачу все равно?", MsgBoxStyle.YesNo, "Предупреждение перед выполнением задачи")
            If Resp = MsgBoxResult.No Then
                CheckEditingFiles = True
            End If
        End If

    End Function



    Sub DoSomePutAgreement(Process As String, Mess As String)

        Dim Service = WebRequest.GetServiceALP()

        Dim Messange = ""

        If Process = "PutAgreement" Then
            Messange = Service.PutAgreement(IDProcess, Mess)
        ElseIf Process = "PutCancel" Then
            Messange = Service.PutCancel(IDProcess, Mess)
        End If

        If Messange = "" Then
            MsgBox("Сервер вернул ответ в неправильном формате." + vbNewLine + " Обратитесь к администратору")
        Else
            If Process = "PutAgreement" Then
                If Messange = "OK" Then

                    Dim Prop1 = Me.OutlookItem.UserProperties.Add("AgreementConfirm", 1) ' 1 - data type 
                    Prop1.Value = Now.ToString()

                    Me.OutlookItem.FlagStatus = 1
                    Me.OutlookItem.Save()

                    MsgBox("Документ успешно согласован!")
                Else
                    MsgBox("При согласовании документа произошла ошибка: " + Messange)
                End If
            Else
                If Messange = "OK" Then

                    Dim Prop1 = Me.OutlookItem.UserProperties.Add("AgreementCancel", 1) ' 1 - data type 
                    Prop1.Value = Now.ToString()

                    Me.OutlookItem.FlagStatus = 1
                    Me.OutlookItem.Save()

                    MsgBox("Документ успешно отклонен!")

                Else
                    MsgBox("При отклонении документа произошла ошибка: " + Messange)
                End If
            End If

            AfterAgreement()

        End If

    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles ButtonCancelAgree.Click

        If CheckEditingFiles() Then
            Exit Sub
        End If

        Dim Form = New UserConfirm
        Form.Text = "ОТКЛОНЕНИЕ документа"
        Form.ShowDialog()

        If Form.Result Then
            DoSomePutAgreement("PutCancel", Form.RichTextBox1.Text)
        End If

    End Sub

    Private Sub ButtonHistory_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim Service = WebRequest.GetServiceALP()

        Dim Messange = Service.GetProcessHistory(IDProcess)

        If Messange.Text = "OK" And Not Messange.Data Is Nothing Then

            Dim FilePath As String = My.Computer.FileSystem.GetTempFileName() + ".html"
            My.Computer.FileSystem.WriteAllBytes(FilePath, Messange.Data, False)

            Dim Form = New HistoryProcess
            Form.TempFile = FilePath
            Form.ShowDialog()

        Else
            MsgBox("При выполнении запроса произошла ошибка: " + Messange.Text)
        End If

    End Sub



    Private Sub ButtonListFiles_Click(sender As Object, e As EventArgs) Handles ButtonListFiles.Click

        Dim Form = New ListFiles
        Form.OutlookItem = Me.OutlookItem
        Form.IDProcess = IDProcess
        Form.ShowDialog()

    End Sub
End Class
