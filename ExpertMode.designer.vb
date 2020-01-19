<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExpertMode
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
        Me.Std = New System.Windows.Forms.TreeView
        Me.SvBut = New System.Windows.Forms.Button
        Me.AnBut = New System.Windows.Forms.Button
        Me.BckBut = New System.Windows.Forms.Button
        Me.LMsg = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SelDirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExclDirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.InclDirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExclFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.InclFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OptBut = New System.Windows.Forms.Button
        Me.VerfBut = New System.Windows.Forms.Button
        Me.ScFile = New System.Windows.Forms.Label
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Std
        '
        Me.Std.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Std.Location = New System.Drawing.Point(9, 25)
        Me.Std.Name = "Std"
        Me.Std.Size = New System.Drawing.Size(702, 268)
        Me.Std.TabIndex = 0
        '
        'SvBut
        '
        Me.SvBut.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.SvBut.Location = New System.Drawing.Point(9, 318)
        Me.SvBut.Name = "SvBut"
        Me.SvBut.Size = New System.Drawing.Size(118, 33)
        Me.SvBut.TabIndex = 1
        Me.SvBut.Text = "sv"
        Me.SvBut.UseVisualStyleBackColor = True
        '
        'AnBut
        '
        Me.AnBut.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.AnBut.Location = New System.Drawing.Point(133, 318)
        Me.AnBut.Name = "AnBut"
        Me.AnBut.Size = New System.Drawing.Size(118, 33)
        Me.AnBut.TabIndex = 2
        Me.AnBut.Text = "anal"
        Me.AnBut.UseVisualStyleBackColor = True
        '
        'BckBut
        '
        Me.BckBut.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BckBut.Location = New System.Drawing.Point(257, 318)
        Me.BckBut.Name = "BckBut"
        Me.BckBut.Size = New System.Drawing.Size(118, 33)
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
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem, Me.EditToolStripMenuItem, Me.DelToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(97, 70)
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelDirToolStripMenuItem, Me.ExclDirToolStripMenuItem, Me.InclDirToolStripMenuItem, Me.ExclFileToolStripMenuItem, Me.InclFileToolStripMenuItem})
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(96, 22)
        Me.AddToolStripMenuItem.Text = "Add"
        '
        'SelDirToolStripMenuItem
        '
        Me.SelDirToolStripMenuItem.Name = "SelDirToolStripMenuItem"
        Me.SelDirToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.SelDirToolStripMenuItem.Text = "Sel dir"
        '
        'ExclDirToolStripMenuItem
        '
        Me.ExclDirToolStripMenuItem.Name = "ExclDirToolStripMenuItem"
        Me.ExclDirToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.ExclDirToolStripMenuItem.Text = "Excl dir"
        '
        'InclDirToolStripMenuItem
        '
        Me.InclDirToolStripMenuItem.Name = "InclDirToolStripMenuItem"
        Me.InclDirToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.InclDirToolStripMenuItem.Text = "Incl dir"
        '
        'ExclFileToolStripMenuItem
        '
        Me.ExclFileToolStripMenuItem.Name = "ExclFileToolStripMenuItem"
        Me.ExclFileToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.ExclFileToolStripMenuItem.Text = "Excl file"
        '
        'InclFileToolStripMenuItem
        '
        Me.InclFileToolStripMenuItem.Name = "InclFileToolStripMenuItem"
        Me.InclFileToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.InclFileToolStripMenuItem.Text = "incl file"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(96, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'DelToolStripMenuItem
        '
        Me.DelToolStripMenuItem.Name = "DelToolStripMenuItem"
        Me.DelToolStripMenuItem.Size = New System.Drawing.Size(96, 22)
        Me.DelToolStripMenuItem.Text = "del"
        '
        'OptBut
        '
        Me.OptBut.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OptBut.Location = New System.Drawing.Point(593, 318)
        Me.OptBut.Name = "OptBut"
        Me.OptBut.Size = New System.Drawing.Size(118, 33)
        Me.OptBut.TabIndex = 5
        Me.OptBut.Text = "op"
        Me.OptBut.UseVisualStyleBackColor = True
        '
        'VerfBut
        '
        Me.VerfBut.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.VerfBut.Location = New System.Drawing.Point(429, 318)
        Me.VerfBut.Name = "VerfBut"
        Me.VerfBut.Size = New System.Drawing.Size(118, 33)
        Me.VerfBut.TabIndex = 6
        Me.VerfBut.Text = "vf"
        Me.VerfBut.UseVisualStyleBackColor = True
        '
        'ScFile
        '
        Me.ScFile.AutoSize = True
        Me.ScFile.Location = New System.Drawing.Point(14, 300)
        Me.ScFile.Name = "ScFile"
        Me.ScFile.Size = New System.Drawing.Size(39, 13)
        Me.ScFile.TabIndex = 7
        Me.ScFile.Text = "Label1"
        '
        'ExpertMode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(722, 363)
        Me.Controls.Add(Me.ScFile)
        Me.Controls.Add(Me.VerfBut)
        Me.Controls.Add(Me.OptBut)
        Me.Controls.Add(Me.LMsg)
        Me.Controls.Add(Me.SvBut)
        Me.Controls.Add(Me.BckBut)
        Me.Controls.Add(Me.AnBut)
        Me.Controls.Add(Me.Std)
        Me.Name = "ExpertMode"
        Me.Text = "ExpertMode"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Std As System.Windows.Forms.TreeView
    Friend WithEvents SvBut As System.Windows.Forms.Button
    Friend WithEvents AnBut As System.Windows.Forms.Button
    Friend WithEvents BckBut As System.Windows.Forms.Button
    Friend WithEvents LMsg As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExclDirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InclDirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelDirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExclFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InclFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptBut As System.Windows.Forms.Button
    Friend WithEvents VerfBut As System.Windows.Forms.Button
    Friend WithEvents ScFile As System.Windows.Forms.Label
End Class
