Public Class Verifi
    Dim NdAll As TreeNode = Nothing
    Dim StdClickedNode As TreeNode = Nothing
    Dim MouseClickedNode As TreeNode = Nothing
    Dim LastStdClickedNode As TreeNode = Nothing
    Dim InErr As Boolean
    Private Sub Verifi_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Me.Cursor = Cursors.WaitCursor AndAlso Not UserCancelled Then
            If MessageBox.Show(SysMsg(2) & "?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                UserCancelled = True
            Else
            End If
        End If
        Me.Hide()
        e.Cancel = True
    End Sub
    Private Sub Verifi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = SysMsg(381)
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        VerifiProc()
    End Sub
    Private Sub VerifiProc()
        Dim t As New UitEen
        Me.Cursor = Cursors.WaitCursor
        Mst.Nodes.Clear()
        UserCancelled = False
        LMsg.Text = ""
        NdAll = Nothing
        For Each rn As TreeNode In myExpMode.Std.Nodes ' alle roots
            ParseNodeText(rn.Text, t)
            If t.tName = "*" Then
                NdAll = rn
            Else
                IncludeFiles(rn, t.tName)
                BckDirs(rn, t.tName, IncD, True)
                If UserCancelled Then
                    Exit Sub
                End If
            End If
        Next
        LMsg.Text = SysMsg(383)
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub IncludeFiles(ByVal nd As TreeNode, ByVal path As String)
        Dim td, tf As New UitEen
        Dim fnd As Boolean
        Dim ft As String
        fnd = False
        IncF.Clear()
        For Each fe As TreeNode In nd.Nodes
            ParseNodeText(fe.Text, tf)
            If tf.tInExcl = cIncl AndAlso tf.tEntry = cFil Then
                Dim sn As String = AddRootIfAbsent(path)
                InclFiles(tf, sn)
                fnd = True
            End If
        Next
        If Not (NdAll Is Nothing) Then
            For Each fe As TreeNode In NdAll.Nodes
                ParseNodeText(fe.Text, tf)
                If tf.tInExcl = cIncl AndAlso tf.tEntry = cFil Then
                    Dim sn As String = AddRootIfAbsent(path)
                    InclFiles(tf, sn)
                    fnd = True
                End If
            Next
        End If
        If Not fnd Then
            ParseNodeText(nd.Text, td)
            tf.tEntry = cFil
            tf.tInExcl = cIncl
            tf.tHidDir = False
            tf.tHidFil = td.tHidFil
            tf.tIncr = td.tIncr
            tf.tName = "*.*"
            Dim sn As String = AddRootIfAbsent(path) ' F:
            InclFiles(tf, sn)
        End If
        For Each fe As TreeNode In nd.Nodes
            ParseNodeText(fe.Text, tf)
            If tf.tInExcl = cExcl AndAlso tf.tEntry = cFil Then
                Dim sn As String = AddRootIfAbsent(path)
                ExclFiles(tf, sn)
            End If
        Next
        If Not (NdAll Is Nothing) Then
            For Each fe As TreeNode In NdAll.Nodes
                ParseNodeText(fe.Text, tf)
                If tf.tInExcl = cExcl AndAlso tf.tEntry = cFil Then
                    Dim sn As String = AddRootIfAbsent(path)
                    ExclFiles(tf, sn)
                End If
            Next
        End If
        Dim vp As String = "."
        If AnalAutoMode AndAlso IncF.Count = 0 Then
            AddEntryToMst(path, nd, New UitEen)
            vp = path
        End If
        For Each s As IncFni In IncF
            Dim f As New FileInfo(s.IncFNm)
            Dim copy As Boolean = True
            If s.IncFInc Then
                ft = SelRootDirsDirDest & "\" & s.IncFNm(0) & s.IncFNm.Substring(2)
                If Directory.Exists(ft) Then
                    Dim d() As String = Directory.GetFiles(ft & "\", "*.*")
                    For jd As Integer = 0 To d.Length() - 1
                        Dim fo As New FileInfo(d(jd))
                        If fo.LastWriteTime >= f.LastWriteTime Then copy = False
                    Next
                End If
            Else
                ft = SelRootDirsDirDest & "\" & s.IncFNm(0) & s.IncFNm.Substring(2)
                If File.Exists(ft) Then
                    Dim fo As New FileInfo(ft)
                    If f.LastWriteTime <= fo.LastWriteTime Then copy = False
                End If
            End If
            If copy Then
                Dim p As String = path
                If vp <> p Then
                    AddEntryToMst(p, nd, New UitEen)
                    vp = p
                End If
                AddEntryToMst(path & "\" & FilesListText & "\" + f.Name, nd, tf)
                nFcopy += 1
                nFcopyCha = True
            End If
        Next
    End Sub
    Private Sub InclFiles(ByVal t As UitEen, ByVal path As String)
        Application.DoEvents()
        If UserCancelled Then
            Exit Sub
        End If
        Dim s() As String
        Try
            Dim sn As String = AddRootIfAbsent(path)
            s = Directory.GetFiles(sn & "\", t.tName)
            For i As Integer = s.GetLowerBound(0) To s.GetUpperBound(0)
                Dim f As New FileInfo(s(i))
                Dim pn As String
                Try
                    pn = path.Substring(SelRootDirsDirDest.Length()) ' or +1, some times
                    If pn(0) = "\" Then
                        pn = pn.Substring(1)
                    End If
                    pn = pn(0) & ":" & pn.Substring(1) & "\" & f.Name
                    If Not My.Computer.FileSystem.FileExists(pn) Then
                        AddEntryToMstV(pn, t)
                    End If
                Catch ex As Exception
                    Dim ii As Integer = 5
                End Try
            Next
        Catch ex As DirectoryNotFoundException
            Dim ii As Integer = 5
        Catch ex As Exception
            Dim st As String = ex.Message + " for: " + path + "\" + t.tName
            MsgBox(st)
        End Try
    End Sub
    Private Sub ExclFiles(ByVal t As UitEen, ByVal path As String)
        Application.DoEvents()
        If UserCancelled Then
            Exit Sub
        End If
        Dim s() As String, ok As Boolean
        Try
            ok = True
            s = Directory.GetFiles(path & "\", t.tName)
        Catch ex As Exception
            ok = False
        End Try
        If ok Then
            For i As Integer = s.GetLowerBound(0) To s.GetUpperBound(0)
                Dim f As New FileInfo(s(i))
                For j As Integer = 1 To IncF.Count
                    Dim fn As IncFni = DirectCast(IncF(j), IncFni)
                    If fn.IncFNm.ToUpper = (path + "\" + f.Name).ToUpper Then
                        IncF.Remove(j)
                        Exit For
                    End If
                Next
            Next
        End If
    End Sub
    Private Sub BckDirs(ByVal nd As TreeNode, ByVal path As String, ByVal IncDp As Collection, ByVal Level0 As Boolean)
        Dim t As New UitEen
        Dim IncAll, fnd As Boolean, IncD As New Collection
        LMsg.Text = path
        LMsg.Update()
        Application.DoEvents()
        If UserCancelled Then
            Exit Sub
        End If
        IncAll = False
        fnd = False
        IncDp.Clear()
        For Each SNode As TreeNode In nd.Nodes
            ParseNodeText(SNode.Text, t)
            If t.tInExcl = cIncl AndAlso t.tEntry = cDir Then
                fnd = True
                Dim sn As String = AddRootIfAbsent(path)
                InclDirs(SNode, sn, IncDp, Level0)
            End If
            If t.tInExcl = cSelct AndAlso t.tEntry = cDir Then
                Dim sn As String = AddRootIfAbsent(path)
                InclDirs(SNode, sn, IncDp, Level0)
            End If
        Next
        If Not fnd Then
            ParseNodeText(nd.Text, t)
            t.tName = "*.*"
            Dim sn As String = AddRootIfAbsent(path)
            InclDirs(New TreeNode(ComposeNodeText(t)), sn, IncDp, Level0)
        End If
        For Each SNode As TreeNode In nd.Nodes ' excl alle dirs onder drive of dir
            ParseNodeText(SNode.Text, t)
            If t.tInExcl = cExcl AndAlso t.tEntry = cDir Then
                ExclDirs(SNode, path, IncDp)
            End If
        Next
        For Each ip As IncDPathc In IncDp
            IncludeFiles(ip.IncDNd, ip.IncDPath)
            BckDirs(ip.IncDNd, ip.IncDPath, IncD, Level0)
            If UserCancelled Then
                Exit Sub
            End If
        Next
    End Sub
    Private Function AddRootIfAbsent(ByVal path As String) As String
        Dim sn As String = path
        If sn.Length() = 2 Then
            sn = SelRootDirsDirDest
            If SelRootDirsDirDest.Substring(SelRootDirsDirDest.Length() - 1, 1) <> "\" Then
                sn &= "\"
            End If
            sn &= path(0)
        End If
        Return sn
    End Function
    Private Sub InclDirs(ByVal nd As TreeNode, ByVal path As String, ByVal IncD As Collection, ByVal Level0 As Boolean)
        Application.DoEvents()
        If UserCancelled Then
            Exit Sub
        End If
        Dim t As New UitEen, fnd As Boolean
        ParseNodeText(nd.Text, t)
        Dim s As New Collection
        Dim sn As String = AddRootIfAbsent(path)
        If t.tName.IndexOf("*") >= 0 OrElse t.tName.IndexOf("?") >= 0 Then
            FindAllDir(sn + "\" + t.tName, s, Level0)
        Else
            s.Add(sn + "\" + t.tName)
        End If
        For Each fn As String In s
            Dim f As New DirectoryInfo(fn)
            fnd = False
            For Each p As IncDPathc In IncD
                If p.IncDPath = f.FullName Then
                    fnd = True
                    Exit For
                End If
            Next
            If Not fnd Then
                If Not t.tHidDir AndAlso (f.Attributes And FileAttributes.Hidden) <> 0 Then
                Else
                    Dim ip As New IncDPathc
                    ip.IncDNd = nd
                    ip.IncDPath = f.FullName
                    IncD.Add(ip)
                End If
            End If
        Next
    End Sub
    Private Sub ExclDirs(ByVal nd As TreeNode, ByVal path As String, ByVal IncD As Collection)
        Application.DoEvents()
        If UserCancelled Then
            Exit Sub
        End If
        Dim t As New UitEen
        ParseNodeText(nd.Text, t)
        Dim s As New Collection
        Dim sn As String = AddRootIfAbsent(path)
        If t.tName.IndexOf("*") >= 0 OrElse t.tName.IndexOf("?") >= 0 Then
            FindAllDir(sn + t.tName, s, False)
        Else
            s.Add(sn + "\" + t.tName)
        End If
        For Each fn As String In s
            Dim f As New DirectoryInfo(fn)
            For j As Integer = 1 To IncD.Count
                Dim ip As IncDPathc = DirectCast(IncD.Item(j), IncDPathc)
                If ip.IncDPath.ToUpper = f.FullName.ToUpper Then
                    IncD.Remove(j)
                    Exit For
                End If
            Next
        Next
    End Sub

    Private Sub Mst_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Mst.KeyPress
        If e.KeyChar = "D" Or e.KeyChar = "d" Then
            Try
                Dim s As String
                s = SelRootDirsDirDest & "\" & MouseClickedNode.FullPath(0) + MouseClickedNode.FullPath.Substring(2)
                If MouseClickedNode.Tag = "F" Then
                    My.Computer.FileSystem.DeleteFile(s, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin)
                Else
                    My.Computer.FileSystem.DeleteDirectory(s, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin)
                End If
                MouseClickedNode.Text += " (Deleted)"
                Mst.SelectedNode = MouseClickedNode.NextVisibleNode
                MouseClickedNode = Mst.SelectedNode
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Private Sub Mst_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Mst.MouseDown
        Dim Button As Integer = e.Button \ &H100000
        MouseClickedNode = Mst.GetNodeAt(e.X, e.Y)
        If Button = 2 Then
            DelToolStripMenuItem.Text = SysMsg(382)
            StdClickedNode = Mst.GetNodeAt(e.X, e.Y)
            LastStdClickedNode = StdClickedNode
            If Not StdClickedNode Is Nothing AndAlso StdClickedNode.Text <> FilesListText Then
                StdClickedNode.TreeView.SelectedNode = StdClickedNode
                DelToolStripMenuItem.Text = DelToolStripMenuItem.Text & " " & StdClickedNode.Text
                DelToolStripMenuItem.Enabled = True
            Else
                DelToolStripMenuItem.Enabled = False
            End If
            Me.ContextMenuStrip = ContextMenuStrip1
        Else
            If Not IsNothing(LastStdClickedNode) Then
                StdClickedNode = Mst.GetNodeAt(e.X, e.Y)
                If LastStdClickedNode.Equals(StdClickedNode) Then
                    Dim fn As String = SelRootDirsDirDest & "\" & StdClickedNode.FullPath(0) & StdClickedNode.FullPath.Substring(2)
                    If StdClickedNode.Tag = "D" Then
                        My.Computer.FileSystem.DeleteDirectory(fn, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin)
                        If Not Directory.Exists(fn) Then
                            StdClickedNode.Parent.Nodes.Remove(StdClickedNode)
                        End If
                    Else
                        My.Computer.FileSystem.DeleteFile(fn, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin)
                        If Not File.Exists(fn) Then
                            StdClickedNode.Parent.Nodes.Remove(StdClickedNode)
                        End If
                    End If
                End If
            End If
            Me.ContextMenuStrip = Nothing
            LastStdClickedNode = Nothing
        End If
    End Sub
    Private Sub DElToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelToolStripMenuItem.Click
        Dim fn As String = SelRootDirsDirDest & "\" & StdClickedNode.FullPath(0) & StdClickedNode.FullPath.Substring(2)
        If StdClickedNode.Tag = "D" Then
            My.Computer.FileSystem.DeleteDirectory(fn, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin)
            If Not Directory.Exists(fn) Then
                StdClickedNode.Parent.Nodes.Remove(StdClickedNode)
            End If
        Else
            My.Computer.FileSystem.DeleteFile(fn, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin)
            If Not File.Exists(fn) Then
                StdClickedNode.Parent.Nodes.Remove(StdClickedNode)
            End If
        End If
    End Sub

End Class
