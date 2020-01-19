<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StdSelFil
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
        Me.HdTxt = New System.Windows.Forms.Label
        Me.CancBut = New System.Windows.Forms.Button
        Me.AddPDPanelNm = New System.Windows.Forms.Panel
        Me.EnterNm = New System.Windows.Forms.Label
        Me.BrwseBut = New System.Windows.Forms.Button
        Me.NmT = New System.Windows.Forms.TextBox
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.only = New System.Windows.Forms.CheckBox
        Me.Headr = New System.Windows.Forms.Label
        Me.LMsg = New System.Windows.Forms.Label
        Me.Selname = New System.Windows.Forms.ListBox
        Me.OkBut = New System.Windows.Forms.Button
        Me.IncrFil = New System.Windows.Forms.CheckBox
        Me.AddPDPanelNm.SuspendLayout()
        Me.SuspendLayout()
        '
        'HdTxt
        '
        Me.HdTxt.AutoSize = True
        Me.HdTxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HdTxt.Location = New System.Drawing.Point(3, 25)
        Me.HdTxt.Name = "HdTxt"
        Me.HdTxt.Size = New System.Drawing.Size(55, 16)
        Me.HdTxt.TabIndex = 47
        Me.HdTxt.Text = "Label1"
        '
        'CancBut
        '
        Me.CancBut.Location = New System.Drawing.Point(47, 184)
        Me.CancBut.Name = "CancBut"
        Me.CancBut.Size = New System.Drawing.Size(143, 35)
        Me.CancBut.TabIndex = 46
        Me.CancBut.Text = "Cancel"
        Me.CancBut.UseVisualStyleBackColor = True
        '
        'AddPDPanelNm
        '
        Me.AddPDPanelNm.Controls.Add(Me.EnterNm)
        Me.AddPDPanelNm.Controls.Add(Me.BrwseBut)
        Me.AddPDPanelNm.Controls.Add(Me.NmT)
        Me.AddPDPanelNm.Location = New System.Drawing.Point(47, 44)
        Me.AddPDPanelNm.Name = "AddPDPanelNm"
        Me.AddPDPanelNm.Size = New System.Drawing.Size(625, 47)
        Me.AddPDPanelNm.TabIndex = 44
        '
        'EnterNm
        '
        Me.EnterNm.AutoSize = True
        Me.EnterNm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.EnterNm.Location = New System.Drawing.Point(455, 15)
        Me.EnterNm.Name = "EnterNm"
        Me.EnterNm.Size = New System.Drawing.Size(156, 15)
        Me.EnterNm.TabIndex = 11
        Me.EnterNm.Text = "or enter a name with * and/or ?"
        '
        'BrwseBut
        '
        Me.BrwseBut.Location = New System.Drawing.Point(362, 11)
        Me.BrwseBut.Name = "BrwseBut"
        Me.BrwseBut.Size = New System.Drawing.Size(87, 21)
        Me.BrwseBut.TabIndex = 10
        Me.BrwseBut.Text = "Browse"
        Me.BrwseBut.UseVisualStyleBackColor = True
        '
        'NmT
        '
        Me.NmT.Location = New System.Drawing.Point(3, 13)
        Me.NmT.Name = "NmT"
        Me.NmT.Size = New System.Drawing.Size(353, 20)
        Me.NmT.TabIndex = 8
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'only
        '
        Me.only.AutoSize = True
        Me.only.Location = New System.Drawing.Point(47, 97)
        Me.only.Name = "only"
        Me.only.Size = New System.Drawing.Size(69, 17)
        Me.only.TabIndex = 48
        Me.only.Text = "only here"
        Me.only.UseVisualStyleBackColor = True
        '
        'Headr
        '
        Me.Headr.AutoSize = True
        Me.Headr.Location = New System.Drawing.Point(3, 3)
        Me.Headr.Name = "Headr"
        Me.Headr.Size = New System.Drawing.Size(39, 13)
        Me.Headr.TabIndex = 49
        Me.Headr.Text = "Label1"
        '
        'LMsg
        '
        Me.LMsg.AutoSize = True
        Me.LMsg.ForeColor = System.Drawing.Color.Red
        Me.LMsg.Location = New System.Drawing.Point(12, 394)
        Me.LMsg.Name = "LMsg"
        Me.LMsg.Size = New System.Drawing.Size(26, 13)
        Me.LMsg.TabIndex = 50
        Me.LMsg.Text = "msg"
        '
        'Selname
        '
        Me.Selname.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Selname.FormattingEnabled = True
        Me.Selname.Location = New System.Drawing.Point(409, 97)
        Me.Selname.Name = "Selname"
        Me.Selname.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.Selname.Size = New System.Drawing.Size(302, 290)
        Me.Selname.TabIndex = 51
        Me.Selname.Visible = False
        '
        'OkBut
        '
        Me.OkBut.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.OkBut.Location = New System.Drawing.Point(47, 146)
        Me.OkBut.Name = "OkBut"
        Me.OkBut.Size = New System.Drawing.Size(143, 32)
        Me.OkBut.TabIndex = 52
        Me.OkBut.Text = "OK"
        Me.OkBut.UseVisualStyleBackColor = True
        '
        'IncrFil
        '
        Me.IncrFil.AutoSize = True
        Me.IncrFil.Location = New System.Drawing.Point(47, 120)
        Me.IncrFil.Name = "IncrFil"
        Me.IncrFil.Size = New System.Drawing.Size(86, 17)
        Me.IncrFil.TabIndex = 53
        Me.IncrFil.Text = "Incr bck files"
        Me.IncrFil.UseVisualStyleBackColor = True
        '
        'StdSelFil
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(725, 416)
        Me.Controls.Add(Me.IncrFil)
        Me.Controls.Add(Me.OkBut)
        Me.Controls.Add(Me.Selname)
        Me.Controls.Add(Me.LMsg)
        Me.Controls.Add(Me.Headr)
        Me.Controls.Add(Me.only)
        Me.Controls.Add(Me.HdTxt)
        Me.Controls.Add(Me.CancBut)
        Me.Controls.Add(Me.AddPDPanelNm)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "StdSelFil"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "StdSelFil"
        Me.AddPDPanelNm.ResumeLayout(False)
        Me.AddPDPanelNm.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents HdTxt As System.Windows.Forms.Label
    Friend WithEvents CancBut As System.Windows.Forms.Button
    Friend WithEvents AddPDPanelNm As System.Windows.Forms.Panel
    Friend WithEvents EnterNm As System.Windows.Forms.Label
    Friend WithEvents BrwseBut As System.Windows.Forms.Button
    Friend WithEvents NmT As System.Windows.Forms.TextBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents only As System.Windows.Forms.CheckBox
    Friend WithEvents Headr As System.Windows.Forms.Label
    Friend WithEvents LMsg As System.Windows.Forms.Label
    Friend WithEvents Selname As System.Windows.Forms.ListBox
    Friend WithEvents OkBut As System.Windows.Forms.Button
    Friend WithEvents IncrFil As System.Windows.Forms.CheckBox

End Class
