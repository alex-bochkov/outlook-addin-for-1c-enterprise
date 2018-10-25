Public Class HistoryProcess

    Public TempFile As String

    Function ValidateCertificate()
        ValidateCertificate = True
    End Function


    Private Sub HistoryProcess_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        WebBrowser1.Navigate(TempFile)

    End Sub

    Private Sub HistoryProcess_FormClosed(sender As Object, e As Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        'WebBrowser1.
        My.Computer.FileSystem.DeleteFile(TempFile)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub
End Class