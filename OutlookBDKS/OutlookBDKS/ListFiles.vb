Imports System.Xml
Imports System.ServiceModel
Imports System.Security.Principal
Imports System.Net

Public Class ListFiles

    Private ArrayFiles() As ThisAddIn.FileInfo

    Public OutlookItem
    Public IDProcess
    Private WebRequest As ThisAddIn.WebRequest = New ThisAddIn.WebRequest


    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Dim Service = WebRequest.GetServiceALP()

        Dim ArrayAttachments(0) As ServiceReferenceALP.BinaryFile
        Dim TempArray(0) As ThisAddIn.FileInfo


        Dim i = 0
        For Each Row In DataGrid.Rows
            If DataGrid.Item("CheckBox", Row.Index).Value And DataGrid.Item("LockForEdition", Row.Index).Value Then

                For Each File In ArrayFiles
                    If File.ID = DataGrid.Item("FileID", Row.index).Value Then

                        Dim Bytes = File.GetBytes()

                        If i > 0 Then ReDim Preserve ArrayAttachments(i)
                        If i > 0 Then ReDim Preserve TempArray(i)

                        Dim Arr = New ServiceReferenceALP.BinaryFile
                        Arr.FileName = File.Name
                        Arr.FileExtension = File.Extension
                        Arr.FileDataSize = File.Size.ToString
                        Arr.FileDateModified = File.DateChangeLocal.ToString()
                        Arr.FileData = Bytes

                        ArrayAttachments(i) = Arr
                        TempArray(i) = File

                        i = i + 1

                    End If
                Next
            ElseIf DataGrid.Item("CheckBox", Row.Index).Value Then
                MsgBox("Документ " + DataGrid.Item("FileName", Row.Index).Value + " не захвачен для редактирования, поэтому не может быть помещен в Документооборот!")
            End If
        Next

        If i > 0 Then
            Dim Messange = Service.ReturnAttachmentToBisnessProcess(IDProcess, ArrayAttachments)

            If Messange = "" Then
                MsgBox("Сервер вернул ответ в неправильном формате.")
            Else
                If Messange = "OK" Then
                    MsgBox("Данные успешно помещены в Документооборот!")
                    For Each f In TempArray
                        f.LockForEditing = False
                    Next
                    SaveListFilesToOutlookItem()
                    RefreshDataGrid()
                Else
                    MsgBox("При помещении данных произошла ошибка: " + Messange)
                End If
            End If
        Else
            MsgBox("Нет документов для отправки!")
        End If


    End Sub

    Sub DownloadDocFromServer()
        ReDim ArrayFiles(0)

        Dim Service = WebRequest.GetServiceALP()

        Dim Messange As ServiceReferenceALP.ResponceAttachments = Service.GetAttachmentFromBisnessProcess(IDProcess)

        If Messange.Text = "OK" And Not Messange.Data Is Nothing Then

            Dim i = 0

            For Each File In Messange.Data

                Dim f = New ThisAddIn.FileInfo
                f.ID = i
                f.Name = File.FileName
                f.Data = File.FileData
                f.DateChange = File.FileDateModified
                f.Extension = File.FileExtension
                'Почему-то булевое значение не хочет передавать...
                f.LockForEditing = IIf(File.FileLockedCurrentUser.ToString = "1", True, False)
                f.SaveFileLocal()

                'MsgBox(File.FileName + " '" + File.FileLockedCurrentUser.ToString + "'" + f.LockForEditing.ToString + "'")

                If i > 0 Then ReDim Preserve ArrayFiles(i)

                ArrayFiles(i) = f

                i = i + 1

            Next

            SaveListFilesToOutlookItem()

            RefreshDataGrid()

        Else
            MsgBox("При выполнении запроса произошла ошибка: " + Messange.Text)
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        DownloadDocFromServer()

    End Sub

    Sub SaveListFilesToOutlookItem()

        'For Each Prop In Me.OutlookItem.UserProperties
        '    Dim a = Prop.Name.ToString
        '    If a.StartsWith("File") Then
        '        Me.OutlookItem.UserProperties.Remove(Prop.Index)
        '    End If
        'Next

        For Each File In ArrayFiles
            Dim Prop1 = Me.OutlookItem.UserProperties.Add("File" + File.ID.ToString, 1) ' 1 - data type 
            Prop1.Value = File.AllToString()
        Next
        Me.OutlookItem.Save()

    End Sub

    Sub RefreshDataGrid()

        DataGrid.Rows.Clear()

        For Each f In ArrayFiles
            Dim Row = DataGrid.Rows.Add()
            DataGrid.Item("FileID", Row).Value = f.ID
            DataGrid.Item("Path", Row).Value = f.Path
            DataGrid.Item("FileName", Row).Value = f.Name
            DataGrid.Item("DateChange", Row).Value = f.DateChange
            DataGrid.Item("Extension", Row).Value = f.Extension
            DataGrid.Item("LockForEdition", Row).Value = f.LockForEditing
        Next

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        For Each Row In DataGrid.Rows
            DataGrid.Item("CheckBox", Row.Index).Value = True
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        For Each Row In DataGrid.Rows
            DataGrid.Item("CheckBox", Row.Index).Value = False
        Next
    End Sub

    Private Sub ButtonOpen_Click(sender As Object, e As EventArgs) Handles ButtonOpen.Click

        Dim ArrRows(0)
        Dim i = 0

        For Each Cell In DataGrid.SelectedCells

            If Not ArrRows.Contains(Cell.RowIndex) Then
                If i > 0 Then ReDim Preserve ArrRows(i)
                ArrRows(i) = Cell.RowIndex
                i = i + 1
            End If

        Next

        For Each Row In ArrRows
            If Not Row Is Nothing Then
                Dim Path = DataGrid.Item("Path", Row).Value

                If Not Path = "" Then
                    System.Diagnostics.Process.Start(Path)
                End If
            End If
        Next

    End Sub

    Private Sub DataGrid_RowPrePaint(sender As Object, e As Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles DataGrid.RowPrePaint

        If (e.RowIndex > -1 And e.RowIndex <= DataGrid.RowCount - 1) Then
            If DataGrid.Rows(e.RowIndex).Cells("LockForEdition").Value Then
                DataGrid.Rows(e.RowIndex).DefaultCellStyle.BackColor = Drawing.Color.LightBlue
            End If
        End If

    End Sub

    Private Sub ListFiles_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

        Dim i = 0

        ReDim ArrayFiles(i)

        For Each Prop In Me.OutlookItem.UserProperties
            Dim a = Prop.Name.ToString
            If a.StartsWith("File") Then
                Dim f = New ThisAddIn.FileInfo
                f.AllFromString(Prop.Value)
                ReDim Preserve ArrayFiles(i)
                ArrayFiles(i) = f
                i = i + 1
            End If
        Next

        If i = 0 Then
            DownloadDocFromServer()
        Else
            RefreshDataGrid()
        End If



    End Sub

    Private Sub ButtonLockDocuments_Click(sender As Object, e As EventArgs) Handles ButtonLockDocuments.Click

        Dim Service = WebRequest.GetServiceALP()

        Dim ArrayAttachments(0) As ServiceReferenceALP.BinaryFile

        Dim i = 0

        For Each Row In DataGrid.Rows
            If DataGrid.Item("CheckBox", Row.Index).Value Then

                For Each File In ArrayFiles
                    If File.ID = DataGrid.Item("FileID", Row.index).Value Then

                        If i > 0 Then ReDim Preserve ArrayAttachments(i)

                        Dim Arr = New ServiceReferenceALP.BinaryFile
                        Arr.FileName = File.Name
                        Arr.FileExtension = File.Extension

                        ArrayAttachments(i) = Arr

                        i = i + 1

                    End If
                Next

            End If
        Next

        If i > 0 Then
            Dim Messange = Service.LockDocumentsInBisnessProcess(IDProcess, ArrayAttachments)
            Dim UserMsg = ""
            For Each File In Messange.Data
                If File.FileCustomText = "OK" Then
                    For Each f In ArrayFiles
                        If f.Name = File.FileName And f.Extension = File.FileExtension Then
                            f.LockForEditing = IIf(File.FileLockedCurrentUser.ToString = "1", True, False)
                            f.DateChange = File.FileDateModified
                            f.Data = File.FileData
                            f.SaveFileLocal()
                        End If
                    Next
                Else
                    UserMsg = UserMsg + vbNewLine + "Произошла ошибка при попытке захвата документа " + File.FileName + "'" + _
                        vbNewLine + File.FileCustomText
                End If
            Next
            If UserMsg = "" Then
                MsgBox("Захват документов на редактирование выполнен успешно!")
            Else
                MsgBox(UserMsg)
            End If

            SaveListFilesToOutlookItem()
        Else
            MsgBox("Необходимо отметить документы, которые требуется захватить на редактирование!")
        End If

        RefreshDataGrid()

    End Sub


End Class