Imports Microsoft.Office.Tools.Ribbon

Public Class Ribbon1

    Private Sub Button4_Click(sender As System.Object, e As Microsoft.Office.Tools.Ribbon.RibbonControlEventArgs) Handles Button4.Click

        Dim Form = New AboutBox
        Form.ShowDialog()

    End Sub

    Private Sub Button5_Click(sender As System.Object, e As Microsoft.Office.Tools.Ribbon.RibbonControlEventArgs) Handles Button5.Click
        Dim Form = New ConfigForm
        Form.ShowDialog()
    End Sub

    Private Sub Button6_Click(sender As System.Object, e As Microsoft.Office.Tools.Ribbon.RibbonControlEventArgs) Handles Button6.Click

        Dim CurrentItem = e.Control.Context.CurrentItem()

        Dim Form = New CreateTask
        Form.Item = CurrentItem
        Form.ShowDialog()

    End Sub
End Class
