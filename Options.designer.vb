<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Options
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.LMsg = New System.Windows.Forms.Label
        Me.BrwLog = New System.Windows.Forms.Button
        Me.DsnLog = New System.Windows.Forms.TextBox
        Me.WrLog = New System.Windows.Forms.CheckBox
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.OnlyOnce = New System.Windows.Forms.CheckBox
        Me.ShutDown = New System.Windows.Forms.CheckBox
        Me.VerCopy = New System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CheckProgr = New System.Windows.Forms.CheckBox
        Me.CheckWinDir = New System.Windows.Forms.CheckBox
        Me.ProgrSize = New System.Windows.Forms.Label
        Me.ProgSizeN = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LMsg
        '
        Me.LMsg.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LMsg.AutoSize = True
        Me.LMsg.BackColor = System.Drawing.SystemColors.Control
        Me.LMsg.ForeColor = System.Drawing.Color.Red
        Me.LMsg.Location = New System.Drawing.Point(12, 353)
        Me.LMsg.Name = "LMsg"
        Me.LMsg.Size = New System.Drawing.Size(39, 13)
        Me.LMsg.TabIndex = 11
        Me.LMsg.Text = "Label2"
        '
        'BrwLog
        '
        Me.BrwLog.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BrwLog.Location = New System.Drawing.Point(599, 31)
        Me.BrwLog.Name = "BrwLog"
        Me.BrwLog.Size = New System.Drawing.Size(101, 24)
        Me.BrwLog.TabIndex = 10
        Me.BrwLog.Text = "Browse"
        Me.BrwLog.UseVisualStyleBackColor = True
        '
        'DsnLog
        '
        Me.DsnLog.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DsnLog.Location = New System.Drawing.Point(1, 35)
        Me.DsnLog.Name = "DsnLog"
        Me.DsnLog.Size = New System.Drawing.Size(592, 20)
        Me.DsnLog.TabIndex = 9
        '
        'WrLog
        '
        Me.WrLog.AutoSize = True
        Me.WrLog.Location = New System.Drawing.Point(1, 12)
        Me.WrLog.Name = "WrLog"
        Me.WrLog.Size = New System.Drawing.Size(81, 17)
        Me.WrLog.TabIndex = 8
        Me.WrLog.Text = "CheckBox1"
        Me.WrLog.UseVisualStyleBackColor = True
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.OK_Button.Location = New System.Drawing.Point(455, 326)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(111, 40)
        Me.OK_Button.TabIndex = 12
        Me.OK_Button.Text = "O"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(581, 326)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(111, 40)
        Me.Cancel_Button.TabIndex = 13
        Me.Cancel_Button.Text = "C"
        '
        'OnlyOnce
        '
        Me.OnlyOnce.AutoSize = True
        Me.OnlyOnce.Location = New System.Drawing.Point(26, 120)
        Me.OnlyOnce.Name = "OnlyOnce"
        Me.OnlyOnce.Size = New System.Drawing.Size(50, 17)
        Me.OnlyOnce.TabIndex = 16
        Me.OnlyOnce.Text = "once"
        Me.OnlyOnce.UseVisualStyleBackColor = True
        Me.OnlyOnce.Visible = False
        '
        'ShutDown
        '
        Me.ShutDown.AutoSize = True
        Me.ShutDown.Location = New System.Drawing.Point(1, 106)
        Me.ShutDown.Name = "ShutDown"
        Me.ShutDown.Size = New System.Drawing.Size(218, 17)
        Me.ShutDown.TabIndex = 15
        Me.ShutDown.Text = "Shut down the pc, when backup is done"
        Me.ShutDown.UseVisualStyleBackColor = True
        '
        'VerCopy
        '
        Me.VerCopy.AutoSize = True
        Me.VerCopy.Location = New System.Drawing.Point(1, 73)
        Me.VerCopy.Name = "VerCopy"
        Me.VerCopy.Size = New System.Drawing.Size(121, 17)
        Me.VerCopy.TabIndex = 14
        Me.VerCopy.Text = "Verify the copied file"
        Me.VerCopy.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CheckProgr)
        Me.GroupBox1.Controls.Add(Me.CheckWinDir)
        Me.GroupBox1.Location = New System.Drawing.Point(1, 203)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(551, 63)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'CheckProgr
        '
        Me.CheckProgr.AutoSize = True
        Me.CheckProgr.Location = New System.Drawing.Point(37, 40)
        Me.CheckProgr.Name = "CheckProgr"
        Me.CheckProgr.Size = New System.Drawing.Size(81, 17)
        Me.CheckProgr.TabIndex = 1
        Me.CheckProgr.Text = "CheckBox2"
        Me.CheckProgr.UseVisualStyleBackColor = True
        '
        'CheckWinDir
        '
        Me.CheckWinDir.AutoSize = True
        Me.CheckWinDir.Location = New System.Drawing.Point(37, 18)
        Me.CheckWinDir.Name = "CheckWinDir"
        Me.CheckWinDir.Size = New System.Drawing.Size(81, 17)
        Me.CheckWinDir.TabIndex = 0
        Me.CheckWinDir.Text = "CheckBox1"
        Me.CheckWinDir.UseVisualStyleBackColor = True
        '
        'ProgrSize
        '
        Me.ProgrSize.AutoSize = True
        Me.ProgrSize.Location = New System.Drawing.Point(-2, 152)
        Me.ProgrSize.Name = "ProgrSize"
        Me.ProgrSize.Size = New System.Drawing.Size(39, 13)
        Me.ProgrSize.TabIndex = 18
        Me.ProgrSize.Text = "Label1"
        '
        'ProgSizeN
        '
        Me.ProgSizeN.Location = New System.Drawing.Point(-2, 168)
        Me.ProgSizeN.Name = "ProgSizeN"
        Me.ProgSizeN.Size = New System.Drawing.Size(19, 20)
        Me.ProgSizeN.TabIndex = 17
        Me.ProgSizeN.Text = "50"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 171)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(22, 13)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Mb"
        '
        'Options
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(704, 375)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ProgrSize)
        Me.Controls.Add(Me.ProgSizeN)
        Me.Controls.Add(Me.OnlyOnce)
        Me.Controls.Add(Me.ShutDown)
        Me.Controls.Add(Me.VerCopy)
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.LMsg)
        Me.Controls.Add(Me.BrwLog)
        Me.Controls.Add(Me.DsnLog)
        Me.Controls.Add(Me.WrLog)
        Me.Name = "Options"
        Me.Text = "Options"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LMsg As System.Windows.Forms.Label
    Friend WithEvents BrwLog As System.Windows.Forms.Button
    Friend WithEvents DsnLog As System.Windows.Forms.TextBox
    Friend WithEvents WrLog As System.Windows.Forms.CheckBox
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents OnlyOnce As System.Windows.Forms.CheckBox
    Friend WithEvents ShutDown As System.Windows.Forms.CheckBox
    Friend WithEvents VerCopy As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckProgr As System.Windows.Forms.CheckBox
    Friend WithEvents CheckWinDir As System.Windows.Forms.CheckBox
    Friend WithEvents ProgrSize As System.Windows.Forms.Label
    Friend WithEvents ProgSizeN As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
