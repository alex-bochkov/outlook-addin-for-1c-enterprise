<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListFiles
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListFiles))
        Me.DataGrid = New System.Windows.Forms.DataGridView()
        Me.CheckBox = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.FileID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Picture = New System.Windows.Forms.DataGridViewImageColumn()
        Me.FileName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Extension = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateChange = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Path = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LockForEdition = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ButtonOpen = New System.Windows.Forms.Button()
        Me.ButtonLockDocuments = New System.Windows.Forms.Button()
        CType(Me.DataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGrid
        '
        Me.DataGrid.AllowUserToAddRows = False
        Me.DataGrid.AllowUserToDeleteRows = False
        Me.DataGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CheckBox, Me.FileID, Me.Picture, Me.FileName, Me.Extension, Me.DateChange, Me.Path, Me.LockForEdition})
        Me.DataGrid.Location = New System.Drawing.Point(33, 3)
        Me.DataGrid.Name = "DataGrid"
        Me.DataGrid.ShowEditingIcon = False
        Me.DataGrid.Size = New System.Drawing.Size(870, 296)
        Me.DataGrid.TabIndex = 0
        '
        'CheckBox
        '
        Me.CheckBox.HeaderText = ""
        Me.CheckBox.Name = "CheckBox"
        Me.CheckBox.Width = 5
        '
        'FileID
        '
        Me.FileID.HeaderText = "FileID"
        Me.FileID.Name = "FileID"
        Me.FileID.ReadOnly = True
        Me.FileID.Visible = False
        Me.FileID.Width = 59
        '
        'Picture
        '
        Me.Picture.HeaderText = ""
        Me.Picture.Name = "Picture"
        Me.Picture.ReadOnly = True
        Me.Picture.Visible = False
        Me.Picture.Width = 5
        '
        'FileName
        '
        Me.FileName.HeaderText = "Наименование"
        Me.FileName.Name = "FileName"
        Me.FileName.ReadOnly = True
        Me.FileName.Width = 108
        '
        'Extension
        '
        Me.Extension.HeaderText = "Расш.файла"
        Me.Extension.Name = "Extension"
        Me.Extension.ReadOnly = True
        Me.Extension.Width = 94
        '
        'DateChange
        '
        Me.DateChange.HeaderText = "Дата изменения"
        Me.DateChange.Name = "DateChange"
        Me.DateChange.ReadOnly = True
        Me.DateChange.Width = 107
        '
        'Path
        '
        Me.Path.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Path.HeaderText = "Имя файла"
        Me.Path.Name = "Path"
        Me.Path.ReadOnly = True
        Me.Path.Width = 82
        '
        'LockForEdition
        '
        Me.LockForEdition.HeaderText = "LockForEdition"
        Me.LockForEdition.Name = "LockForEdition"
        Me.LockForEdition.Visible = False
        Me.LockForEdition.Width = 84
        '
        'Button5
        '
        Me.Button5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button5.Location = New System.Drawing.Point(635, 305)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(268, 41)
        Me.Button5.TabIndex = 4
        Me.Button5.Text = "Поместить захваченные документы в Документооборот"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button4.Location = New System.Drawing.Point(12, 305)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(201, 41)
        Me.Button4.TabIndex = 5
        Me.Button4.Text = "Загрузить документы из Документооборота"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(2, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(25, 25)
        Me.Button1.TabIndex = 6
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(2, 27)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(25, 25)
        Me.Button2.TabIndex = 6
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ButtonOpen
        '
        Me.ButtonOpen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonOpen.Location = New System.Drawing.Point(421, 305)
        Me.ButtonOpen.Name = "ButtonOpen"
        Me.ButtonOpen.Size = New System.Drawing.Size(208, 41)
        Me.ButtonOpen.TabIndex = 7
        Me.ButtonOpen.Text = "Открыть выделенные документы"
        Me.ButtonOpen.UseVisualStyleBackColor = True
        '
        'ButtonLockDocuments
        '
        Me.ButtonLockDocuments.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonLockDocuments.Location = New System.Drawing.Point(219, 305)
        Me.ButtonLockDocuments.Name = "ButtonLockDocuments"
        Me.ButtonLockDocuments.Size = New System.Drawing.Size(196, 41)
        Me.ButtonLockDocuments.TabIndex = 8
        Me.ButtonLockDocuments.Text = "Захватить выделенные документы на редактирование"
        Me.ButtonLockDocuments.UseVisualStyleBackColor = True
        '
        'ListFiles
        '
        Me.AccessibleRole = System.Windows.Forms.AccessibleRole.Alert
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(906, 349)
        Me.Controls.Add(Me.ButtonLockDocuments)
        Me.Controls.Add(Me.ButtonOpen)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.DataGrid)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ListFiles"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Загруженные файлы"
        CType(Me.DataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGrid As System.Windows.Forms.DataGridView
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ButtonOpen As System.Windows.Forms.Button
    Friend WithEvents ButtonLockDocuments As System.Windows.Forms.Button
    Friend WithEvents CheckBox As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents FileID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Picture As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents FileName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Extension As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateChange As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Path As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LockForEdition As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
