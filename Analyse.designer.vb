<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Analyse
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
        Me.UndoLastToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExclNameHereToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExclNameInAllMapsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExclTypeHereToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExclTypeInAllMapsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.FinishedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExpertModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Ms = New System.Windows.Forms.ListBox()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ExToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ContextMenuStrip2.SuspendLayout()
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
        Me.LMsg.Size = New System.Drawing.Size(33, 13)
        Me.LMsg.TabIndex = 5
        Me.LMsg.Text = "LMsg"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UndoLastToolStripMenuItem, Me.ToolStripMenuItem3, Me.ExclNameHereToolStripMenuItem, Me.ExclNameInAllMapsToolStripMenuItem, Me.ExclTypeHereToolStripMenuItem, Me.ExclTypeInAllMapsToolStripMenuItem, Me.ToolStripMenuItem2, Me.FinishedToolStripMenuItem, Me.ExpertModeToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(210, 202)
        '
        'UndoLastToolStripMenuItem
        '
        Me.UndoLastToolStripMenuItem.Name = "UndoLastToolStripMenuItem"
        Me.UndoLastToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.UndoLastToolStripMenuItem.Text = "Undo last"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(209, 22)
        Me.ToolStripMenuItem3.Text = "---------------------------"
        '
        'ExclNameHereToolStripMenuItem
        '
        Me.ExclNameHereToolStripMenuItem.Name = "ExclNameHereToolStripMenuItem"
        Me.ExclNameHereToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.ExclNameHereToolStripMenuItem.Text = "excl name here"
        '
        'ExclNameInAllMapsToolStripMenuItem
        '
        Me.ExclNameInAllMapsToolStripMenuItem.Name = "ExclNameInAllMapsToolStripMenuItem"
        Me.ExclNameInAllMapsToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.ExclNameInAllMapsToolStripMenuItem.Text = "excl name in all maps"
        '
        'ExclTypeHereToolStripMenuItem
        '
        Me.ExclTypeHereToolStripMenuItem.Name = "ExclTypeHereToolStripMenuItem"
        Me.ExclTypeHereToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.ExclTypeHereToolStripMenuItem.Text = "excl type here"
        '
        'ExclTypeInAllMapsToolStripMenuItem
        '
        Me.ExclTypeInAllMapsToolStripMenuItem.Name = "ExclTypeInAllMapsToolStripMenuItem"
        Me.ExclTypeInAllMapsToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.ExclTypeInAllMapsToolStripMenuItem.Text = "excl type in all maps"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(209, 22)
        Me.ToolStripMenuItem2.Text = "---------------------------"
        '
        'FinishedToolStripMenuItem
        '
        Me.FinishedToolStripMenuItem.Name = "FinishedToolStripMenuItem"
        Me.FinishedToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.FinishedToolStripMenuItem.Text = "Bckuop"
        '
        'ExpertModeToolStripMenuItem
        '
        Me.ExpertModeToolStripMenuItem.Name = "ExpertModeToolStripMenuItem"
        Me.ExpertModeToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.ExpertModeToolStripMenuItem.Text = "ExpertMode"
        '
        'Ms
        '
        Me.Ms.FormattingEnabled = True
        Me.Ms.Location = New System.Drawing.Point(290, 2)
        Me.Ms.Name = "Ms"
        Me.Ms.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.Ms.Size = New System.Drawing.Size(199, 17)
        Me.Ms.TabIndex = 6
        Me.Ms.Visible = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 333
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExToolStripMenuItem})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(86, 26)
        '
        'ExToolStripMenuItem
        '
        Me.ExToolStripMenuItem.Name = "ExToolStripMenuItem"
        Me.ExToolStripMenuItem.Size = New System.Drawing.Size(85, 22)
        Me.ExToolStripMenuItem.Text = "ex"
        '
        'Analyse
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(723, 392)
        Me.Controls.Add(Me.Ms)
        Me.Controls.Add(Me.LMsg)
        Me.Controls.Add(Me.Mst)
        Me.Name = "Analyse"
        Me.Text = "Analyse"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Mst As System.Windows.Forms.TreeView
    Friend WithEvents LMsg As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ExclNameHereToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExclNameInAllMapsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExclTypeHereToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExclTypeInAllMapsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FinishedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UndoLastToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExpertModeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Ms As System.Windows.Forms.ListBox
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ContextMenuStrip2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ExToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
