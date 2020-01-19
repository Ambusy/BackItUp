<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AnalBck
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
        Me.components = New System.ComponentModel.Container()
        Me.Std = New System.Windows.Forms.TreeView()
        Me.SvBut = New System.Windows.Forms.Button()
        Me.AnBut = New System.Windows.Forms.Button()
        Me.BckBut = New System.Windows.Forms.Button()
        Me.LMsg = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'Std
        '
        Me.Std.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Std.Location = New System.Drawing.Point(9, 25)
        Me.Std.Name = "Std"
        Me.Std.Size = New System.Drawing.Size(702, 287)
        Me.Std.TabIndex = 0
        '
        'SvBut
        '
        Me.SvBut.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.SvBut.Location = New System.Drawing.Point(9, 318)
        Me.SvBut.Name = "SvBut"
        Me.SvBut.Size = New System.Drawing.Size(139, 33)
        Me.SvBut.TabIndex = 1
        Me.SvBut.Text = "sv"
        Me.SvBut.UseVisualStyleBackColor = True
        '
        'AnBut
        '
        Me.AnBut.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.AnBut.Location = New System.Drawing.Point(169, 318)
        Me.AnBut.Name = "AnBut"
        Me.AnBut.Size = New System.Drawing.Size(139, 33)
        Me.AnBut.TabIndex = 2
        Me.AnBut.Text = "anal"
        Me.AnBut.UseVisualStyleBackColor = True
        '
        'BckBut
        '
        Me.BckBut.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BckBut.Location = New System.Drawing.Point(327, 318)
        Me.BckBut.Name = "BckBut"
        Me.BckBut.Size = New System.Drawing.Size(139, 33)
        Me.BckBut.TabIndex = 3
        Me.BckBut.Text = "Bck"
        Me.BckBut.UseVisualStyleBackColor = True
        '
        'LMsg
        '
        Me.LMsg.AutoSize = True
        Me.LMsg.Location = New System.Drawing.Point(10, 6)
        Me.LMsg.Name = "LMsg"
        Me.LMsg.Size = New System.Drawing.Size(39, 13)
        Me.LMsg.TabIndex = 4
        Me.LMsg.Text = "Label1"
        '
        'Timer1
        '
        Me.Timer1.Interval = 333
        '
        'AnalBck
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(722, 363)
        Me.Controls.Add(Me.LMsg)
        Me.Controls.Add(Me.BckBut)
        Me.Controls.Add(Me.AnBut)
        Me.Controls.Add(Me.SvBut)
        Me.Controls.Add(Me.Std)
        Me.Name = "AnalBck"
        Me.Text = "AnalBck"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Std As System.Windows.Forms.TreeView
    Friend WithEvents SvBut As System.Windows.Forms.Button
    Friend WithEvents AnBut As System.Windows.Forms.Button
    Friend WithEvents BckBut As System.Windows.Forms.Button
    Friend WithEvents LMsg As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
