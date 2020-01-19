<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelRootDirs
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SelRootDirs))
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.BR_Button = New System.Windows.Forms.Button
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.EM_button = New System.Windows.Forms.Button
        Me.LMsg = New System.Windows.Forms.Label
        Me.Opt_But = New System.Windows.Forms.Button
        Me.DirDestLab = New System.Windows.Forms.Label
        Me.DirDest = New System.Windows.Forms.TextBox
        Me.DirDestBut = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.OK_Button.Location = New System.Drawing.Point(188, 353)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(111, 40)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "O"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(314, 353)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(111, 40)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "C"
        '
        'BR_Button
        '
        Me.BR_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BR_Button.Location = New System.Drawing.Point(441, 353)
        Me.BR_Button.Name = "BR_Button"
        Me.BR_Button.Size = New System.Drawing.Size(111, 40)
        Me.BR_Button.TabIndex = 2
        Me.BR_Button.Text = "Br"
        Me.BR_Button.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(0, 19)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.ListBox1.Size = New System.Drawing.Size(692, 303)
        Me.ListBox1.TabIndex = 1
        '
        'EM_button
        '
        Me.EM_button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.EM_button.Location = New System.Drawing.Point(12, 353)
        Me.EM_button.Name = "EM_button"
        Me.EM_button.Size = New System.Drawing.Size(111, 40)
        Me.EM_button.TabIndex = 2
        Me.EM_button.Text = "em"
        Me.EM_button.UseVisualStyleBackColor = True
        '
        'LMsg
        '
        Me.LMsg.AutoSize = True
        Me.LMsg.Location = New System.Drawing.Point(1, 1)
        Me.LMsg.Name = "LMsg"
        Me.LMsg.Size = New System.Drawing.Size(39, 13)
        Me.LMsg.TabIndex = 3
        Me.LMsg.Text = "Label1"
        '
        'Opt_But
        '
        Me.Opt_But.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Opt_But.Location = New System.Drawing.Point(566, 353)
        Me.Opt_But.Name = "Opt_But"
        Me.Opt_But.Size = New System.Drawing.Size(111, 40)
        Me.Opt_But.TabIndex = 4
        Me.Opt_But.Text = "Op"
        '
        'DirDestLab
        '
        Me.DirDestLab.AutoSize = True
        Me.DirDestLab.Location = New System.Drawing.Point(431, 330)
        Me.DirDestLab.Name = "DirDestLab"
        Me.DirDestLab.Size = New System.Drawing.Size(21, 13)
        Me.DirDestLab.TabIndex = 5
        Me.DirDestLab.Text = "dst"
        '
        'DirDest
        '
        Me.DirDest.Location = New System.Drawing.Point(0, 327)
        Me.DirDest.Name = "DirDest"
        Me.DirDest.Size = New System.Drawing.Size(309, 20)
        Me.DirDest.TabIndex = 6
        '
        'DirDestBut
        '
        Me.DirDestBut.Location = New System.Drawing.Point(315, 327)
        Me.DirDestBut.Name = "DirDestBut"
        Me.DirDestBut.Size = New System.Drawing.Size(110, 24)
        Me.DirDestBut.TabIndex = 7
        Me.DirDestBut.Text = "dst"
        Me.DirDestBut.UseVisualStyleBackColor = True
        '
        'SelRootDirs
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(689, 394)
        Me.Controls.Add(Me.DirDestBut)
        Me.Controls.Add(Me.DirDest)
        Me.Controls.Add(Me.DirDestLab)
        Me.Controls.Add(Me.Opt_But)
        Me.Controls.Add(Me.LMsg)
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.BR_Button)
        Me.Controls.Add(Me.EM_button)
        Me.Controls.Add(Me.ListBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SelRootDirs"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Select the entry"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents BR_Button As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents EM_button As System.Windows.Forms.Button
    Friend WithEvents LMsg As System.Windows.Forms.Label
    Friend WithEvents Opt_But As System.Windows.Forms.Button
    Friend WithEvents DirDestLab As System.Windows.Forms.Label
    Friend WithEvents DirDest As System.Windows.Forms.TextBox
    Friend WithEvents DirDestBut As System.Windows.Forms.Button

End Class
