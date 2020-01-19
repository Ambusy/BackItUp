<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container
        Me.OpenSt = New System.Windows.Forms.Button
        Me.NewSt = New System.Windows.Forms.Button
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'OpenSt
        '
        Me.OpenSt.Location = New System.Drawing.Point(12, 12)
        Me.OpenSt.Name = "OpenSt"
        Me.OpenSt.Size = New System.Drawing.Size(146, 49)
        Me.OpenSt.TabIndex = 0
        Me.OpenSt.Text = "Button1"
        Me.OpenSt.UseVisualStyleBackColor = True
        '
        'NewSt
        '
        Me.NewSt.Location = New System.Drawing.Point(186, 12)
        Me.NewSt.Name = "NewSt"
        Me.NewSt.Size = New System.Drawing.Size(146, 49)
        Me.NewSt.TabIndex = 1
        Me.NewSt.Text = "Button2"
        Me.NewSt.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Timer1
        '
        Me.Timer1.Interval = 250
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(344, 79)
        Me.Controls.Add(Me.NewSt)
        Me.Controls.Add(Me.OpenSt)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OpenSt As System.Windows.Forms.Button
    Friend WithEvents NewSt As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class
