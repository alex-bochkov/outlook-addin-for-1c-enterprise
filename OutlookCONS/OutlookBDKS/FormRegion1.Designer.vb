<System.ComponentModel.ToolboxItemAttribute(False)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRegion1
    Inherits Microsoft.Office.Tools.Outlook.FormRegionBase

    Public Sub New(ByVal formRegion As Microsoft.Office.Interop.Outlook.FormRegion)
        MyBase.New(Globals.Factory, formRegion)
        Me.InitializeComponent()
    End Sub

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ButtonAgree = New System.Windows.Forms.Button()
        Me.ButtonCancelAgree = New System.Windows.Forms.Button()
        Me.LabelInformer = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ButtonAgree
        '
        Me.ButtonAgree.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ButtonAgree.ForeColor = System.Drawing.Color.Blue
        Me.ButtonAgree.Location = New System.Drawing.Point(3, 3)
        Me.ButtonAgree.Name = "ButtonAgree"
        Me.ButtonAgree.Size = New System.Drawing.Size(199, 39)
        Me.ButtonAgree.TabIndex = 0
        Me.ButtonAgree.Text = "СОГЛАСОВАНО"
        Me.ButtonAgree.UseVisualStyleBackColor = True
        '
        'ButtonCancelAgree
        '
        Me.ButtonCancelAgree.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ButtonCancelAgree.ForeColor = System.Drawing.Color.Red
        Me.ButtonCancelAgree.Location = New System.Drawing.Point(208, 3)
        Me.ButtonCancelAgree.Name = "ButtonCancelAgree"
        Me.ButtonCancelAgree.Size = New System.Drawing.Size(184, 39)
        Me.ButtonCancelAgree.TabIndex = 0
        Me.ButtonCancelAgree.Text = "ОТКЛОНЕНО"
        Me.ButtonCancelAgree.UseVisualStyleBackColor = True
        '
        'LabelInformer
        '
        Me.LabelInformer.AutoSize = True
        Me.LabelInformer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.LabelInformer.ForeColor = System.Drawing.Color.Blue
        Me.LabelInformer.Location = New System.Drawing.Point(7, 46)
        Me.LabelInformer.Name = "LabelInformer"
        Me.LabelInformer.Size = New System.Drawing.Size(15, 13)
        Me.LabelInformer.TabIndex = 5
        Me.LabelInformer.Text = "  "
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.ForestGreen
        Me.Button1.Location = New System.Drawing.Point(398, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(145, 39)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Информация по документу"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FormRegion1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelInformer)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ButtonCancelAgree)
        Me.Controls.Add(Me.ButtonAgree)
        Me.Name = "FormRegion1"
        Me.Size = New System.Drawing.Size(548, 66)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    'NOTE: The following procedure is required by the Form Regions Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Shared Sub InitializeManifest(ByVal manifest As Microsoft.Office.Tools.Outlook.FormRegionManifest, ByVal factory As Microsoft.Office.Tools.Outlook.Factory)
        manifest.FormRegionName = "Интеграция с 1С:Консолидация"
        manifest.FormRegionType = Microsoft.Office.Tools.Outlook.FormRegionType.Adjoining

    End Sub
    Friend WithEvents ButtonAgree As System.Windows.Forms.Button
    Friend WithEvents ButtonCancelAgree As System.Windows.Forms.Button
    Friend WithEvents LabelInformer As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button

    Partial Public Class FormRegion1Factory
        Implements Microsoft.Office.Tools.Outlook.IFormRegionFactory

        Public Event FormRegionInitializing As Microsoft.Office.Tools.Outlook.FormRegionInitializingEventHandler

        Private _Manifest As Microsoft.Office.Tools.Outlook.FormRegionManifest


        <System.Diagnostics.DebuggerNonUserCodeAttribute()> _
        Public Sub New()
            Me._Manifest = Globals.Factory.CreateFormRegionManifest()            
            FormRegion1.InitializeManifest(Me._Manifest, Globals.Factory)
        End Sub

        <System.Diagnostics.DebuggerNonUserCodeAttribute()> _
        ReadOnly Property Manifest() As Microsoft.Office.Tools.Outlook.FormRegionManifest Implements Microsoft.Office.Tools.Outlook.IFormRegionFactory.Manifest
            Get
                Return Me._Manifest
            End Get
        End Property

        <System.Diagnostics.DebuggerNonUserCodeAttribute()> _
        Function CreateFormRegion(ByVal formRegion As Microsoft.Office.Interop.Outlook.FormRegion) As Microsoft.Office.Tools.Outlook.IFormRegion Implements Microsoft.Office.Tools.Outlook.IFormRegionFactory.CreateFormRegion
            Dim form as FormRegion1 = New FormRegion1(formRegion)
            form.Factory = Me
            Return form
        End Function

        <System.Diagnostics.DebuggerNonUserCodeAttribute()> _
        Function GetFormRegionStorage(ByVal outlookItem As Object, ByVal formRegionMode As Microsoft.Office.Interop.Outlook.OlFormRegionMode, ByVal formRegionSize As Microsoft.Office.Interop.Outlook.OlFormRegionSize) As Byte() Implements Microsoft.Office.Tools.Outlook.IFormRegionFactory.GetFormRegionStorage
            Throw New System.NotSupportedException()
        End Function

        <System.Diagnostics.DebuggerNonUserCodeAttribute()> _
        Function IsDisplayedForItem(ByVal outlookItem As Object, ByVal formRegionMode As Microsoft.Office.Interop.Outlook.OlFormRegionMode, ByVal formRegionSize As Microsoft.Office.Interop.Outlook.OlFormRegionSize) As Boolean Implements Microsoft.Office.Tools.Outlook.IFormRegionFactory.IsDisplayedForItem
            Dim cancelArgs As Microsoft.Office.Tools.Outlook.FormRegionInitializingEventArgs = Globals.Factory.CreateFormRegionInitializingEventArgs(outlookItem, formRegionMode, formRegionSize, False)
            cancelArgs.Cancel = False
            RaiseEvent FormRegionInitializing(Me, cancelArgs)
            Return Not cancelArgs.Cancel
        End Function

        <System.Diagnostics.DebuggerNonUserCodeAttribute()> _
       ReadOnly Property Kind() As Microsoft.Office.Tools.Outlook.FormRegionKindConstants Implements Microsoft.Office.Tools.Outlook.IFormRegionFactory.Kind
            Get
                Return Microsoft.Office.Tools.Outlook.FormRegionKindConstants.WindowsForms
            End Get
        End Property
    End Class
End Class

Partial Class WindowFormRegionCollection

    Friend ReadOnly Property FormRegion1() As FormRegion1
        Get
            For Each Item As Object In Me
                If (TypeOf (Item) Is FormRegion1) Then
                    Return Item
                End If
            Next
            Return Nothing
        End Get
    End Property
End Class