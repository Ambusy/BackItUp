<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StdSelDir
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
        Me.CancBut = New System.Windows.Forms.Button
        Me.DPanelNm = New System.Windows.Forms.Panel
        Me.EnterNm = New System.Windows.Forms.Label
        Me.BrwseBut = New System.Windows.Forms.Button
        Me.NmT = New System.Windows.Forms.TextBox
        Me.HdTxt = New System.Windows.Forms.Label
        Me.Selname = New System.Windows.Forms.ListBox
        Me.PanelChk = New System.Windows.Forms.Panel
        Me.IncrFil = New System.Windows.Forms.CheckBox
        Me.hFil = New System.Windows.Forms.CheckBox
        Me.hDir = New System.Windows.Forms.CheckBox
        Me.OnlyHere = New System.Windows.Forms.CheckBox
        Me.Headr = New System.Windows.Forms.Label
        Me.LMsg = New System.Windows.Forms.Label
        Me.OKBut = New System.Windows.Forms.Button
        Me.DPanelNm.SuspendLayout()
        Me.PanelChk.SuspendLayout()
        Me.SuspendLayout()
        '
        'CancBut
        '
        Me.CancBut.Location = New System.Drawing.Point(50, 286)
        Me.CancBut.Name = "CancBut"
        Me.CancBut.Size = New System.Drawing.Size(143, 35)
        Me.CancBut.TabIndex = 39
        Me.CancBut.Text = "Cancel"
        Me.CancBut.UseVisualStyleBackColor = True
        '
        'DPanelNm
        '
        Me.DPanelNm.Controls.Add(Me.EnterNm)
        Me.DPanelNm.Controls.Add(Me.BrwseBut)
        Me.DPanelNm.Controls.Add(Me.NmT)
        Me.DPanelNm.Location = New System.Drawing.Point(33, 37)
        Me.DPanelNm.Name = "DPanelNm"
        Me.DPanelNm.Size = New System.Drawing.Size(625, 47)
        Me.DPanelNm.TabIndex = 35
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
        'HdTxt
        '
        Me.HdTxt.AutoSize = True
        Me.HdTxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HdTxt.Location = New System.Drawing.Point(0, 18)
        Me.HdTxt.Name = "HdTxt"
        Me.HdTxt.Size = New System.Drawing.Size(55, 16)
        Me.HdTxt.TabIndex = 40
        Me.HdTxt.Text = "Label1"
        '
        'Selname
        '
        Me.Selname.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Selname.FormattingEnabled = True
        Me.Selname.Location = New System.Drawing.Point(395, 90)
        Me.Selname.Name = "Selname"
        Me.Selname.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.Selname.Size = New System.Drawing.Size(302, 290)
        Me.Selname.TabIndex = 42
        Me.Selname.Visible = False
        '
        'PanelChk
        '
        Me.PanelChk.Controls.Add(Me.IncrFil)
        Me.PanelChk.Controls.Add(Me.hFil)
        Me.PanelChk.Controls.Add(Me.hDir)
        Me.PanelChk.Location = New System.Drawing.Point(36, 90)
        Me.PanelChk.Name = "PanelChk"
        Me.PanelChk.Size = New System.Drawing.Size(222, 96)
        Me.PanelChk.TabIndex = 43
        '
        'IncrFil
        '
        Me.IncrFil.AutoSize = True
        Me.IncrFil.Location = New System.Drawing.Point(14, 63)
        Me.IncrFil.Name = "IncrFil"
        Me.IncrFil.Size = New System.Drawing.Size(86, 17)
        Me.IncrFil.TabIndex = 44
        Me.IncrFil.Text = "Incr bck files"
        Me.IncrFil.UseVisualStyleBackColor = True
        '
        'hFil
        '
        Me.hFil.AutoSize = True
        Me.hFil.Location = New System.Drawing.Point(14, 40)
        Me.hFil.Name = "hFil"
        Me.hFil.Size = New System.Drawing.Size(109, 17)
        Me.hFil.TabIndex = 43
        Me.hFil.Text = "Incl HIDDEN files"
        Me.hFil.UseVisualStyleBackColor = True
        '
        'hDir
        '
        Me.hDir.AutoSize = True
        Me.hDir.Location = New System.Drawing.Point(14, 17)
        Me.hDir.Name = "hDir"
        Me.hDir.Size = New System.Drawing.Size(131, 17)
        Me.hDir.TabIndex = 42
        Me.hDir.Text = "Incl Hidden directories"
        Me.hDir.UseVisualStyleBackColor = True
        '
        'OnlyHere
        '
        Me.OnlyHere.AutoSize = True
        Me.OnlyHere.Location = New System.Drawing.Point(50, 202)
        Me.OnlyHere.Name = "OnlyHere"
        Me.OnlyHere.Size = New System.Drawing.Size(69, 17)
        Me.OnlyHere.TabIndex = 45
        Me.OnlyHere.Text = "only here"
        Me.OnlyHere.UseVisualStyleBackColor = True
        '
        'Headr
        '
        Me.Headr.AutoSize = True
        Me.Headr.Location = New System.Drawing.Point(1, 1)
        Me.Headr.Name = "Headr"
        Me.Headr.Size = New System.Drawing.Size(39, 13)
        Me.Headr.TabIndex = 46
        Me.Headr.Text = "Label1"
        '
        'LMsg
        '
        Me.LMsg.AutoSize = True
        Me.LMsg.ForeColor = System.Drawing.Color.Red
        Me.LMsg.Location = New System.Drawing.Point(16, 379)
        Me.LMsg.Name = "LMsg"
        Me.LMsg.Size = New System.Drawing.Size(26, 13)
        Me.LMsg.TabIndex = 47
        Me.LMsg.Text = "msg"
        '
        'OKBut
        '
        Me.OKBut.Location = New System.Drawing.Point(50, 245)
        Me.OKBut.Name = "OKBut"
        Me.OKBut.Size = New System.Drawing.Size(143, 35)
        Me.OKBut.TabIndex = 48
        Me.OKBut.Text = "ok"
        Me.OKBut.UseVisualStyleBackColor = True
        '
        'StdSelDir
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(709, 402)
        Me.Controls.Add(Me.OKBut)
        Me.Controls.Add(Me.LMsg)
        Me.Controls.Add(Me.Headr)
        Me.Controls.Add(Me.OnlyHere)
        Me.Controls.Add(Me.PanelChk)
        Me.Controls.Add(Me.Selname)
        Me.Controls.Add(Me.HdTxt)
        Me.Controls.Add(Me.CancBut)
        Me.Controls.Add(Me.DPanelNm)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "StdSelDir"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "StdSelDir"
        Me.DPanelNm.ResumeLayout(False)
        Me.DPanelNm.PerformLayout()
        Me.PanelChk.ResumeLayout(False)
        Me.PanelChk.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CancBut As System.Windows.Forms.Button
    Friend WithEvents DPanelNm As System.Windows.Forms.Panel
    Friend WithEvents EnterNm As System.Windows.Forms.Label
    Friend WithEvents BrwseBut As System.Windows.Forms.Button
    Friend WithEvents NmT As System.Windows.Forms.TextBox
    Friend WithEvents HdTxt As System.Windows.Forms.Label
    Friend WithEvents Selname As System.Windows.Forms.ListBox
    Friend WithEvents PanelChk As System.Windows.Forms.Panel
    Friend WithEvents IncrFil As System.Windows.Forms.CheckBox
    Friend WithEvents hFil As System.Windows.Forms.CheckBox
    Friend WithEvents hDir As System.Windows.Forms.CheckBox
    Friend WithEvents OnlyHere As System.Windows.Forms.CheckBox
    Friend WithEvents Headr As System.Windows.Forms.Label
    Friend WithEvents LMsg As System.Windows.Forms.Label
    Friend WithEvents OKBut As System.Windows.Forms.Button

End Class
