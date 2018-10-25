Public Class CreateTaskIn1C

#Region "Фабрика областей формы"

    <Microsoft.Office.Tools.Outlook.FormRegionMessageClass(Microsoft.Office.Tools.Outlook.FormRegionMessageClassAttribute.Note)> _
    <Microsoft.Office.Tools.Outlook.FormRegionName("Outlook + Документооборот.CreateTaskIn1C")> _
    Partial Public Class CreateTaskIn1CFactory

    ' Возникает перед инициализацией области формы.
    ' Чтобы исключить появление области формы, задайте для параметра e.Cancel значение true.
    ' Используйте e.OutlookItem для получения ссылки на текущий элемент Outlook.
        Private Sub CreateTaskIn1CFactory_FormRegionInitializing(ByVal sender As Object, ByVal e As Microsoft.Office.Tools.Outlook.FormRegionInitializingEventArgs) Handles Me.FormRegionInitializing

    End Sub

    End Class

#End Region

    'Возникает перед отображением области формы. 
    'Используйте Me.OutlookItem для получения ссылки на текущий элемент Outlook.
    'Используйте Me.OutlookFormRegion для получения ссылки на область формы.
    Private Sub CreateTaskIn1C_FormRegionShowing(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.FormRegionShowing

    End Sub

    'Возникает перед закрытием области формы.   
    'Используйте Me.OutlookItem для получения ссылки на текущий элемент Outlook.
    'Используйте Me.OutlookFormRegion для получения ссылки на область формы.
    Private Sub CreateTaskIn1C_FormRegionClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.FormRegionClosed

    End Sub

End Class
