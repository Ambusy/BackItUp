Public Class ExpertMode
    Private Sub expertBck_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If ScriptChanged Then
            If MsgBox(SysMsg(312), MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                Analyse.SaveStFile(Analyse.SaveFileDialog1.FileName)
            End If
        End If
        myForm.Show()
        Me.Hide()
        e.Cancel = True ' close gaat niet door
    End Sub
    Private Sub ExpertMode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = SysMsg(71)
        SvBut.Text = SysMsg(74)
        AnBut.Text = SysMsg(72)
        BckBut.Text = SysMsg(73)
        OptBut.Text = SysMsg(77)
        VerfBut.Text = SysMsg(76)
        AddToolStripMenuItem.Text = SysMsg(351)
        EditToolStripMenuItem.Text = SysMsg(352)
        DelToolStripMenuItem.Text = SysMsg(353)
        SelDirToolStripMenuItem.Text = SysMsg(354)
        ExclDirToolStripMenuItem.Text = SysMsg(355)
        InclDirToolStripMenuItem.Text = SysMsg(358)
        ExclFileToolStripMenuItem.Text = SysMsg(359)
        InclFileToolStripMenuItem.Text = SysMsg(362)
        ScFile.Text = SysMsg(367) + " " + SelRootDirsDirDest
        LMsg.Text = ""
        BckAutoMode = False
        If AnalAutoMode Then
            Timer1.Enabled = True
        End If
    End Sub
    Private Sub AnBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnBut.Click
        BckAutoMode = False
        myAnal.ShowDialog()
    End Sub
    Private Sub BckBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BckBut.Click
        BckAutoMode = True
        myAnal.ShowDialog()
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        BackupDone = False
        myAnal.ShowDialog()
        If BackupDone Then
            Me.Hide()
            myForm.Show()
        End If
    End Sub
    Private Sub SvBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SvBut.Click
        Analyse.SaveStFile(Analyse.SaveFileDialog1.FileName)
    End Sub
    Private Sub Std_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Std.MouseDown
        Dim Button As Integer = e.Button \ &H100000
        If Button = 2 Then
            Dim t As New UitEen
            Dim tr As New UitEen
            StdClickedNode = Std.GetNodeAt(e.X, e.Y)
            StdHdrNode = StdClickedNode
            If Not StdClickedNode Is Nothing Then
                StdClickedNode.TreeView.SelectedNode = StdClickedNode
                ParseNodeText(StdClickedNode.FullPath, tr)
                ParseNodeText(StdClickedNode.Text, t)
                AddToolStripMenuItem.Enabled = (t.tInExcl <> cExcl AndAlso tr.tName(0) <> "*"c)
                ExclFileToolStripMenuItem.Enabled = (t.tInExcl <> cExcl)
                InclFileToolStripMenuItem.Enabled = (t.tInExcl <> cExcl)
                EditToolStripMenuItem.Enabled = True
                DelToolStripMenuItem.Enabled = True
            Else
                AddToolStripMenuItem.Enabled = False
                EditToolStripMenuItem.Enabled = False
                DelToolStripMenuItem.Enabled = False
            End If
            Me.ContextMenuStrip = ContextMenuStrip1
        Else
            Me.ContextMenuStrip = Nothing
        End If
    End Sub
    Private Sub SelDirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelDirToolStripMenuItem.Click
        ' select one dir
        Dim MyF As New StdSelDir
        MyF.PanelChk.Visible = True
        MyF.IncrFil.Visible = False
        MyF.Headr.Text = SysMsg(354)
        MyF.ShowDialog()
        MyF.IncrFil.Visible = True
        If MyF.DialogResult = Windows.Forms.DialogResult.OK Then
            For Each f As String In SelectedNames
                Dim t As New UitEen
                t.tEntry = cDir
                t.tHidDir = MyF.hDir.Checked
                t.tHidFil = MyF.hFil.Checked
                t.tIncr = False
                t.tInExcl = cSelct
                t.tName = f
                Dim nd As New TreeNode(ComposeNodeText(t))
                StdClickedNode.Nodes.Add(nd)
                StdClickedNode.Expand()
                ScriptChanged = True
            Next
        End If
    End Sub
    Private Sub ExclDirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExclDirToolStripMenuItem.Click
        Dim MyF As New StdSelDir
        MyF.PanelChk.Visible = False
        MyF.Headr.Text = SysMsg(355)
        MyF.ShowDialog()
        If MyF.DialogResult = Windows.Forms.DialogResult.OK Then
            Dim t As New UitEen
            If Not MyF.OnlyHere.Checked Then
                ' exclude one dir
                For Each f As String In SelectedNames
                    t.tEntry = cDir
                    t.tHidDir = MyF.hDir.Checked
                    t.tHidFil = MyF.hFil.Checked
                    t.tIncr = MyF.IncrFil.Checked
                    t.tInExcl = cExcl
                    t.tName = f
                    Dim nd As New TreeNode(ComposeNodeText(t))
                    StdClickedNode.Nodes.Add(nd)
                    StdClickedNode.Expand()
                    ScriptChanged = True
                Next
            Else
                ' exclude dir in *
                For Each f As String In SelectedNames
                    t.tEntry = cDir
                    t.tHidDir = MyF.hDir.Checked
                    t.tHidFil = MyF.hFil.Checked
                    t.tIncr = MyF.IncrFil.Checked
                    t.tInExcl = cExcl
                    t.tName = "*\" + f
                    AddEntryInStd("*\" + f, "D", t)
                    ScriptChanged = True
                Next
            End If
        End If
    End Sub
    Private Sub InclDirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InclDirToolStripMenuItem.Click
        Dim MyF As New StdSelDir
        MyF.PanelChk.Visible = True
        MyF.Headr.Text = SysMsg(358)
        MyF.ShowDialog()
        If MyF.DialogResult = Windows.Forms.DialogResult.OK Then
            Dim t As New UitEen
            If Not MyF.OnlyHere.Checked Then
                ' include one dir
                For Each f As String In SelectedNames
                    t.tEntry = cDir
                    t.tHidDir = MyF.hDir.Checked
                    t.tHidFil = MyF.hFil.Checked
                    t.tIncr = MyF.IncrFil.Checked
                    t.tInExcl = cIncl
                    t.tName = f
                    Dim nd As New TreeNode(ComposeNodeText(t))
                    StdClickedNode.Nodes.Add(nd)
                    StdClickedNode.Expand()
                    ScriptChanged = True
                Next
            Else
                'include dir in *
                For Each f As String In SelectedNames
                    t.tEntry = cDir
                    t.tHidDir = MyF.hDir.Checked
                    t.tHidFil = MyF.hFil.Checked
                    t.tIncr = MyF.IncrFil.Checked
                    t.tInExcl = cIncl
                    t.tName = "*\" + f
                    AddEntryInStd("*\" + f, "D", t)
                    ScriptChanged = True
                Next
            End If
        End If
    End Sub
    Private Sub ExclFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExclFileToolStripMenuItem.Click
        Dim MyF As New StdSelFil
        MyF.Headr.Text = SysMsg(359)
        MyF.IncrFil.Visible = False
        MyF.ShowDialog()
        MyF.IncrFil.Visible = True
        If MyF.DialogResult = Windows.Forms.DialogResult.OK Then
            Dim t As New UitEen
            If Not MyF.only.Checked Then
                ' exclude one file
                For Each f As String In SelectedNames
                    t.tEntry = cFil
                    t.tHidDir = False
                    t.tHidFil = False
                    t.tIncr = False
                    t.tInExcl = cExcl
                    t.tName = f
                    Dim nd As New TreeNode(ComposeNodeText(t))
                    StdClickedNode.Nodes.Add(nd)
                    StdClickedNode.Expand()
                    ScriptChanged = True
                Next
            Else
                ' excl one file in *
                For Each f As String In SelectedNames
                    t.tEntry = cFil
                    t.tHidDir = False
                    t.tHidFil = False
                    t.tIncr = False
                    t.tInExcl = cExcl
                    t.tName = f
                    AddEntryInStd("*\" + f, "F", t)
                    ScriptChanged = True
                Next
            End If
        End If
    End Sub
    Private Sub InclFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InclFileToolStripMenuItem.Click
        Dim MyF As New StdSelFil
        MyF.Headr.Text = SysMsg(362)
        MyF.ShowDialog()
        If MyF.DialogResult = Windows.Forms.DialogResult.OK Then
            Dim t As New UitEen
            ParseNodeText(StdClickedNode.Text, t)
            If Not MyF.only.Checked Then
                ' include one file
                For Each f As String In SelectedNames
                    t.tEntry = cFil
                    t.tHidDir = False
                    t.tHidFil = False
                    t.tIncr = MyF.IncrFil.Checked
                    t.tInExcl = cIncl
                    t.tName = f
                    Dim nd As New TreeNode(ComposeNodeText(t))
                    StdClickedNode.Nodes.Add(nd)
                    StdClickedNode.Expand()
                    ScriptChanged = True
                Next
            Else
                ' incl one file in *
                For Each f As String In SelectedNames
                    t.tEntry = cFil
                    t.tHidDir = False
                    t.tHidFil = False
                    t.tIncr = False
                    t.tInExcl = cExcl
                    t.tName = f
                    AddEntryInStd("*\" + f, "F", t)
                    ScriptChanged = True
                Next
            End If
        End If
    End Sub
    Private Sub DelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelToolStripMenuItem.Click
        StdClickedNode.Remove()
        ScriptChanged = True
    End Sub
    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        Dim t As New UitEen
        ParseNodeText(StdClickedNode.Text, t)
        If t.tEntry = cFil Then
            Dim MyF As New StdSelFil
            MyF.Headr.Text = SysMsg(366)
            MyF.NmT.Text = t.tName
            MyF.only.Visible = False
            MyF.ShowDialog()
            MyF.only.Visible = True
            If MyF.DialogResult = Windows.Forms.DialogResult.OK Then
                t.tName = MyF.NmT.Text
                StdClickedNode.Text = ComposeNodeText(t)
                ScriptChanged = True
            End If
        End If
        If t.tEntry = cDir Then
            Dim MyF As New StdSelDir
            MyF.Headr.Text = SysMsg(366)
            MyF.NmT.Text = t.tName
            MyF.hDir.Checked = t.tHidDir
            MyF.hFil.Checked = t.tHidFil
            MyF.IncrFil.Checked = t.tIncr
            StdHdrNode = StdClickedNode.Parent
            MyF.OnlyHere.Visible = False
            MyF.ShowDialog()
            MyF.OnlyHere.Visible = True
            If MyF.DialogResult = Windows.Forms.DialogResult.OK Then
                t.tHidDir = MyF.hDir.Checked
                t.tHidFil = MyF.hFil.Checked
                t.tIncr = MyF.IncrFil.Checked
                t.tName = MyF.NmT.Text
                StdClickedNode.Text = ComposeNodeText(t)
                ScriptChanged = True
            End If
        End If
    End Sub
    Private Sub OptBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptBut.Click
        myOptions.GroupBox1.Visible = False
        myOptions.ShowDialog()
        myOptions.GroupBox1.Visible = True
    End Sub

    Private Sub VerfBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerfBut.Click
        myVeri.Show()
        myVeri.Timer1.Enabled = True
    End Sub
End Class