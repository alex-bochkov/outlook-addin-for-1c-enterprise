Public Class CreateTask
    Public Item As Object
    Const PR_ATTACH_DATA_BIN As String = "http://schemas.microsoft.com/mapi/proptag/0x37010102"

    Private Sub CreateTask_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Subject.Text = Item.ConversationTopic

        DetailText.Lines = {"Для: " + Item.To.ToString,
                            "От: " + Item.SenderName.ToString,
                            "Дата: " + Item.ReceivedTime.ToString,
                            "----------------------------------------------------",
                            Item.Body}

        For Each att In Item.Attachments
            FilesList.Items.Add(att.DisplayName, True)
            'Dim attachmentData = att.PropertyAccessor.GetProperty(PR_ATTACH_DATA_BIN)
        Next

        Imp.SelectedItem = Imp.Items(0)

    End Sub



    Private Sub CreateTask_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown



    End Sub

    Private Sub Cancel_Click(sender As System.Object, e As System.EventArgs) Handles Cancel.Click
        Close()
    End Sub

    Private Sub Create_Click(sender As System.Object, e As System.EventArgs) Handles Create.Click

        If UserList.Text.Length = 0 Then
            MsgBox("Не указан ответственный!")
            Exit Sub
        End If

        Dim web = New ThisAddIn.WebRequest
        Dim serv = web.GetServiceALP()

        Dim Proc = New ServiceReferenceALP.Process
        Proc.Subject = Subject.Text
        Proc.DeadLine = DateTimeDeadline.Value.ToString("yyyyMMddHHmmss")
        Proc.DetailText = DetailText.Text
        Proc.TaskFor = UserList.Text
        Proc.Importance = Imp.Text

        Dim ArrayAttachments(0) As ServiceReferenceALP.BinaryFile

        Dim a = 0
        Dim i = 0
        For Each ListItem In FilesList.Items
            If FilesList.GetItemChecked(a) Then

                For Each att In Item.Attachments
                    If ListItem = att.DisplayName Then

                        Dim attachmentData = att.PropertyAccessor.GetProperty(PR_ATTACH_DATA_BIN)

                        Dim b = New ServiceReferenceALP.BinaryFile
                        b.FileName = ListItem
                        b.FileData = attachmentData
                        b.FileDataSize = att.Size
                        b.FileDateModified = Now

                        Dim Name = ListItem.ToString
                        If Name.Substring(Name.Length - 4, 1) = "." Then
                            b.FileExtension = Name.Substring(Name.Length - 4)
                        ElseIf Name.Substring(Name.Length - 5, 1) = "." Then
                            b.FileExtension = Name.Substring(Name.Length - 5)
                        End If

                        If i > 0 Then ReDim Preserve ArrayAttachments(i)

                        ArrayAttachments(i) = b

                        i = i + 1

                    End If
                Next

            End If
            a = a + 1
        Next

        If i > 0 Then
            Proc.ArrayAttachment = ArrayAttachments
        End If

        Dim Mess = serv.CreateProcess(Proc)

        If Mess.Status = "OK" Then

            Item.HTMLBody = "<p><FONT color=#ff0000>" + Mess.Text + "</p>" + _
                "<p>Кому: " + UserList.Text + " </p>" + _
                "<p>Срок: " + DateTimeDeadline.Value.ToString + " </p>" + _
                "<p>-----------------------------------------</FONT></p>" + vbNewLine + Item.HTMLBody
            Item.Save()

            Close()
        Else
            MsgBox(Mess.Text)
        End If

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        FindUser()
    End Sub



    Sub FindUser()
        Dim web = New ThisAddIn.WebRequest
        Dim serv = web.GetServiceALP()

        Dim Resp = serv.GetUserList(UserList.Text)

        If Resp.Length > 0 Then

            UserList.Items.Clear()

            For Each user In Resp
                UserList.Items.Add(user.Name)
            Next
            If Resp.Length = 1 Then
                UserList.Text = Resp(0).Name
            End If

            UserList.Show()

        Else
            MsgBox("Не удалось найти пользователей по указанной подстроке!")
        End If

    End Sub




End Class