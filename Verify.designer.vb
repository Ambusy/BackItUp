<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Verifi
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
        Me.Mst = New System.Windows.Forms.TreeView()
        Me.LMsg = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Mst
        '
        Me.Mst.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Mst.Location = New System.Drawing.Point(0, 20)
        Me.Mst.Name = "Mst"
        Me.Mst.Size = New System.Drawing.Size(723, 372)
        Me.Mst.TabIndex = 0
        '
        'LMsg
        '
        Me.LMsg.AutoSize = True
        Me.LMsg.Location = New System.Drawing.Point(0, 0)
        Me.LMsg.Name = "LMsg"
        Me.LMsg.Size = New System.Drawing.Size(39, 13)
        Me.LMsg.TabIndex = 5
        Me.LMsg.Text = "Label1"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DelToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(92, 26)
        '
        'DelToolStripMenuItem
        '
        Me.DelToolStripMenuItem.Name = "DelToolStripMenuItem"
        Me.DelToolStripMenuItem.Size = New System.Drawing.Size(91, 22)
        Me.DelToolStripMenuItem.Text = "Del"
        '
        'Timer1
        '
        Me.Timer1.Interval = 333
        '
        'Verifi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(723, 392)
        Me.Controls.Add(Me.LMsg)
        Me.Controls.Add(Me.Mst)
        Me.Name = "Verifi"
        Me.Text = "verif"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Mst As System.Windows.Forms.TreeView
    Friend WithEvents LMsg As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
