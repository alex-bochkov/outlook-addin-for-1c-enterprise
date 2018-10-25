<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfigForm
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
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

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.RefWS = New System.Windows.Forms.TextBox()
        Me.AuthWindows = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Password = New System.Windows.Forms.TextBox()
        Me.Login = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Auth1C = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(6, 140)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(187, 45)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "ОК"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Адрес web-сервиса"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(196, 140)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(177, 45)
        Me.Button2.TabIndex = 0
        Me.Button2.Text = "Отмена"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'RefWS
        '
        Me.RefWS.Location = New System.Drawing.Point(124, 9)
        Me.RefWS.Name = "RefWS"
        Me.RefWS.Size = New System.Drawing.Size(244, 20)
        Me.RefWS.TabIndex = 2
        '
        'AuthWindows
        '
        Me.AuthWindows.AutoSize = True
        Me.AuthWindows.Location = New System.Drawing.Point(13, 19)
        Me.AuthWindows.Name = "AuthWindows"
        Me.AuthWindows.Size = New System.Drawing.Size(206, 17)
        Me.AuthWindows.TabIndex = 3
        Me.AuthWindows.Text = "сквозная Windows-аутентификация"
        Me.AuthWindows.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Password)
        Me.GroupBox1.Controls.Add(Me.Login)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Auth1C)
        Me.GroupBox1.Controls.Add(Me.AuthWindows)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 35)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(353, 100)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Способ аутентификации"
        '
        'Password
        '
        Me.Password.Location = New System.Drawing.Point(213, 60)
        Me.Password.Name = "Password"
        Me.Password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.Password.Size = New System.Drawing.Size(100, 20)
        Me.Password.TabIndex = 5
        Me.Password.UseSystemPasswordChar = True
        '
        'Login
        '
        Me.Login.Location = New System.Drawing.Point(51, 60)
        Me.Login.Name = "Login"
        Me.Login.Size = New System.Drawing.Size(100, 20)
        Me.Login.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(162, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Пароль"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Логин"
        '
        'Auth1C
        '
        Me.Auth1C.AutoSize = True
        Me.Auth1C.Location = New System.Drawing.Point(13, 39)
        Me.Auth1C.Name = "Auth1C"
        Me.Auth1C.Size = New System.Drawing.Size(194, 17)
        Me.Auth1C.TabIndex = 3
        Me.Auth1C.Text = "аутентификация 1С:Предприятия"
        Me.Auth1C.UseVisualStyleBackColor = True
        '
        'ConfigForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(375, 188)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.RefWS)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ConfigForm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Настройка параметров интеграции с 1С:Консолидация"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents RefWS As System.Windows.Forms.TextBox
    Friend WithEvents AuthWindows As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Password As System.Windows.Forms.TextBox
    Friend WithEvents Login As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Auth1C As System.Windows.Forms.RadioButton
End Class
