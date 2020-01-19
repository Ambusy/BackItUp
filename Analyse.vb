Public Class Analyse
    Dim NdAll As TreeNode = Nothing
    Dim AnalyseDone As Boolean
    Dim logFile As StreamWriter = Nothing
    Dim InErr As Boolean
    Dim maxSz As Integer
    Dim errsInAna As Boolean
    Dim TotBytes As Double
    Dim CTotBytes As Double
    Private Sub Analyse_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Me.Cursor = Cursors.WaitCursor AndAlso Not UserCancelled Then
            If MessageBox.Show(SysMsg(2) & "?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                UserCancelled = True
                If myOptions.WrLog.Checked Then
                    logFile.WriteLine("ABORT: " & Format(Now, "ddd d MMM yyyy - HH mm ss"))
                    logFile.Close()
                End If
            Else
                e.Cancel = True
            End If
        Else
            If myOptions.WrLog.Checked Then
                logFile.WriteLine(Format(Now, "ddd d MMM yyyy - HH mm ss"))
                logFile.Close()
            End If
            If ScriptChanged Then
                SaveSt_Click()
            End If
        End If
    End Sub
    Private Sub Analyse_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = SysMsg(72)
        FilesListText = SysMsg(5)
        Mst.Nodes.Clear()
        RemFromMst.Clear()
        UserCancelled = False
        LMsg.Text = ""
        AnalyseDone = False
        BackupDone = False
        Timer1.Enabled = True
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        AnalyzeProc()
    End Sub
    Private Sub AnalyzeProc()
        Dim t As New UitEen
        Me.Cursor = Cursors.WaitCursor
        Me.Text = SysMsg(72)
        Ms.Visible = False
        TotBytes = 0
        errsInAna = False
        If myOptions.WrLog.Checked Then
            If Not logFile Is Nothing Then
                logFile.Close()
            End If
            logFile = File.CreateText(myOptions.DsnLog.Text)
            logFile.WriteLine(Format(Now, "ddd d MMM yyyy - HH mm ss"))
        End If
        nFcopy = 0
        nFcopyCha = False
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
        AnalyseDone = True
        Dim nb As String
        Dim kb As Double = 1024
        Dim mb As Double = kb * 1024
        Dim gb As Double = mb * 1024
        If TotBytes > gb Then
            nb = Format((TotBytes / gb), "F") & " Gb"
        ElseIf TotBytes > mb Then
            nb = Format((TotBytes / mb), "F") & " Mb"
        Else
            nb = Format((TotBytes / kb), "F") & " Kb"
        End If
        LMsg.Text = CStr(nFcopy) & " " & SysMsg(78) & " (" & nb & ")"
        If Mst.Nodes.Count > 0 Then
            Mst.SelectedNode = Mst.Nodes(0)
            Me.Cursor = Cursors.Default
            If BckAutoMode Then
                BackupProc()
            End If
        End If
        Me.Cursor = Cursors.Default
        If errsInAna Then
            MsgBox(SysMsg(80))
        End If
    End Sub
    Private Sub IncludeFiles(ByVal nd As TreeNode, ByVal path As String)
        Dim td, tf As New UitEen
        Dim fnd As Boolean
        Dim ft As String
        Dim diff1 As System.TimeSpan
        fnd = False
        IncF.Clear()
        For Each fe As TreeNode In nd.Nodes
            ParseNodeText(fe.Text, tf)
            If tf.tInExcl = cIncl AndAlso tf.tEntry = cFil Then
                InclFiles(tf, path)
                fnd = True
            End If
        Next
        If Not (NdAll Is Nothing) Then
            For Each fe As TreeNode In NdAll.Nodes
                ParseNodeText(fe.Text, tf)
                If tf.tInExcl = cIncl AndAlso tf.tEntry = cFil Then
                    InclFiles(tf, path)
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
            InclFiles(tf, path)
        End If
        For Each fe As TreeNode In nd.Nodes
            ParseNodeText(fe.Text, tf)
            If tf.tInExcl = cExcl AndAlso tf.tEntry = cFil Then
                ExclFiles(tf, path)
            End If
        Next
        If Not (NdAll Is Nothing) Then
            For Each fe As TreeNode In NdAll.Nodes
                ParseNodeText(fe.Text, tf)
                If tf.tInExcl = cExcl AndAlso tf.tEntry = cFil Then
                    ExclFiles(tf, path)
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
                    Try
                        Dim d() As String = Directory.GetFiles(ft & "\", "*.*")
                        For jd As Integer = 0 To d.Length() - 1
                            Dim fo As New FileInfo(d(jd))
                            diff1 = f.LastWriteTime.Subtract(fo.LastWriteTime)
                            If Math.Abs(diff1.Seconds) < 3 Then copy = False
                        Next
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                End If
            Else
                ft = SelRootDirsDirDest & "\" & s.IncFNm(0) & s.IncFNm.Substring(2)
                If File.Exists(ft) Then
                    Dim fo As New FileInfo(ft)
                    diff1 = f.LastWriteTime.Subtract(fo.LastWriteTime)
                    If Math.Abs(diff1.Seconds) < 3 Then copy = False
                End If
            End If
            If copy Then
                Dim p As String = path
                If vp <> p Then
                    AddEntryToMst(p, nd, New UitEen)
                    vp = p
                End If
                Dim nnd As New TreeNode
                tf.tName = f.Name
                tf.tInExcl = cIncl
                tf.tIncr = s.IncFInc
                tf.tSze = s.IncFSze
                nnd.Text = ComposeNodeText(tf)
                AddEntryToMst(path & "\" & FilesListText & "\" + f.Name, nnd, tf)
                nFcopy += 1
                TotBytes += f.Length
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
            s = Directory.GetFiles(path & "\", t.tName)
            For i As Integer = s.GetLowerBound(0) To s.GetUpperBound(0)
                Dim f As New FileInfo(s(i))
                If Not t.tHidFil AndAlso (f.Attributes And (FileAttributes.Hidden)) <> 0 Then
                Else
                    Dim fn As New IncFni
                    fn.IncFNm = path & "\" & f.Name
                    fn.IncFInc = t.tIncr
                    Try
                        fn.IncFSze = f.Length
                    Catch ex As Exception
                        fn.IncFSze = 1024 * 1024 * 1024 ' groot
                    End Try
                    IncF.Add(fn)
                End If
            Next
        Catch ex As System.UnauthorizedAccessException
            If myOptions.WrLog.Checked Then
                logFile.WriteLine(SysMsg(81) & path)
                errsInAna = True
            End If
        Catch ex As Exception
            If Not BckAutoMode Then
                Dim st As String = ex.Message + " for: " + path + "\" + t.tName
                MsgBox(st)
            End If
        End Try
    End Sub
    Private Sub ExclFiles(ByVal t As UitEen, ByVal path As String)
        Application.DoEvents()
        If UserCancelled Then
            Exit Sub
        End If
        Dim s() As String
        Try
            s = Directory.GetFiles(path & "\", t.tName)
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
        Catch ex As Exception
            If myOptions.WrLog.Checked Then
                logFile.WriteLine(ex.Message + " for: " + path + "\" + t.tName)
            Else
                If Not BckAutoMode Then
                    Dim st As String = ex.Message + " for: " + path + "\" + t.tName
                    MsgBox(st)
                End If
            End If
        End Try
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
                If t.tName <> "dummy" Then InclDirs(SNode, path, IncDp, Level0)
            End If
            If t.tInExcl = cSelct AndAlso t.tEntry = cDir Then
                InclDirs(SNode, path, IncDp, Level0)
            End If
        Next
        If Not (NdAll Is Nothing) Then
            For Each SNode As TreeNode In NdAll.Nodes
                ParseNodeText(SNode.Text, t)
                If t.tInExcl = cIncl AndAlso t.tEntry = cDir Then
                    fnd = True
                    InclDirs(SNode, path, IncDp, False)
                End If
                If t.tInExcl = cSelct AndAlso t.tEntry = cDir Then
                    InclDirs(SNode, path, IncDp, False)
                End If
            Next
        End If
        If Not fnd Then
            ParseNodeText(nd.Text, t)
            t.tName = "*.*"
            InclDirs(New TreeNode(ComposeNodeText(t)), path, IncDp, True)
        End If
        For Each SNode As TreeNode In nd.Nodes ' excl alle dirs onder drive of dir
            ParseNodeText(SNode.Text, t)
            If t.tInExcl = cExcl AndAlso t.tEntry = cDir Then
                ExclDirs(SNode, path, IncDp)
            End If
        Next
        If Not (NdAll Is Nothing) Then
            For Each SNode As TreeNode In NdAll.Nodes
                ParseNodeText(SNode.Text, t)
                If t.tInExcl = cExcl AndAlso t.tEntry = cDir Then
                    ExclDirs(SNode, path, IncDp)
                End If
            Next
        End If
        For Each ip As IncDPathc In IncDp
            ParseNodeText(ip.IncDNd.Text, t)
            'If ip.IncDPath = "C:\Users\Guest\AppData\Local\Microsoft\Windows\Temporary Internet Files" Then
            '    Dim i As Integer = 1
            'End If
            If (t.tInExcl = cIncl OrElse (Not fnd And t.tInExcl = cSelct)) AndAlso t.tEntry = cDir Then
                IncludeFiles(ip.IncDNd, ip.IncDPath)
            End If
            BckDirs(ip.IncDNd, ip.IncDPath, IncD, False)
            If UserCancelled Then
                Exit Sub
            End If
        Next
    End Sub
    Private Sub InclDirs(ByVal nd As TreeNode, ByVal path As String, ByVal IncD As Collection, ByVal level0 As Boolean)
        Application.DoEvents()
        If UserCancelled Then
            Exit Sub
        End If
        Dim t As New UitEen, fnd As Boolean
        ParseNodeText(nd.Text, t)
        Dim s As New Collection
        If t.tName.IndexOf("*") >= 0 OrElse t.tName.IndexOf("?") >= 0 Then
            FindAllDir(path + "\" + t.tName, s, nd.Parent Is Nothing)
        Else
            s.Add(path + "\" + t.tName)
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
        If t.tName.IndexOf("*") >= 0 OrElse t.tName.IndexOf("?") >= 0 Then
            FindAllDir(path + t.tName, s, nd.Parent Is Nothing)
        Else
            s.Add(path + "\" + t.tName)
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
    Private Sub BackupProc()
        If myOptions.WrLog.Checked Then
            logFile.WriteLine(SysMsg(400))
        End If
        maxSz = CInt(myOptions.ProgSizeN.Text) * 1024 * 1024
        CTotBytes = 0
        Me.Cursor = Cursors.WaitCursor
        Me.Text = SysMsg(73)
        Ms.Items.Clear()
        InErr = False
        Dim nc As Long = 0
        For Each tr As TreeNode In Mst.Nodes
            If tr.Tag(0) = "F" Then
                BackupOneFile(tr)
                If UserCancelled Then
                    Exit Sub
                End If
            Else
                tr.TreeView.SelectedNode = tr
                BackupOneDirDown(tr)
                If UserCancelled Then
                    Exit Sub
                End If
            End If
        Next
        Me.ContextMenuStrip = Nothing
        Me.Cursor = Cursors.Default
        LMsg.Text = SysMsg(75)
        If InErr = True Then
            Ms.Location = New Point(Mst.Location.X, Mst.Location.Y)
            Ms.Size = New Size(Mst.Size.Width, Mst.Size.Height)
            Ms.Visible = True
            Ms.BringToFront()
        Else
            If BckAutoMode Then
                Me.Hide()
            End If
        End If
        BackupDone = True
    End Sub
    Private Sub BackupOneDirDown(ByVal rtr As TreeNode)
        For Each tr As TreeNode In rtr.Nodes
            If tr.Tag(0) = "F" Then
                BackupOneFile(tr)
                If UserCancelled Then
                    Exit Sub
                End If
            Else
                tr.TreeView.SelectedNode = tr
                BackupOneDirDown(tr)
                If UserCancelled Then
                    Exit Sub
                End If
            End If
        Next
    End Sub
    Private Sub BackupOneFile(ByVal tr As TreeNode)
        Application.DoEvents()
        If UserCancelled Then
            Exit Sub
        End If
        Dim s As String = tr.FullPath
        Dim j As Integer = s.LastIndexOf("<"c)
        If j > -1 Then
            s = s.Substring(0, j - 3)
        End If
        Dim p() As String = s.Split("\"c)
        s = p(0)
        For i As Integer = 1 To p.Length() - 1
            If p(i) <> FilesListText Then
                s = s + "\" + p(i)
            End If
        Next
        Dim t As String = SelRootDirsDirDest + "\" + s(0) + s.Substring(2)
        Try
            If Not My.Computer.FileSystem.FileExists(s) Then
                LMsg.Text = tr.FullPath
                If myOptions.WrLog.Checked Then
                    logFile.WriteLine(SysMsg(404) & ":   " + s)
                End If
                Ms.Items.Add(SysMsg(404) & ":   " + s)
                InErr = True
            Else
                Dim fio As New FileInfo(s)
                'If nFcopyCha Then
                '    LMsg.Text = tr.FullPath
                'Else
                LMsg.Text = "(" & Format(CTotBytes * 100.0! / TotBytes, "F") & "%) " & tr.FullPath
                'End If
                LMsg.Refresh()
                CTotBytes = CTotBytes + fio.Length
                If fio.Length() > maxSz Then
                    If My.Computer.FileSystem.FileExists(t) Then
                        Try
                            My.Computer.FileSystem.DeleteFile(t)
                        Catch ex As Exception
                        End Try
                    End If
                    Try
                        If tr.Tag = "FI" Then
                            t = t + "\" + Format(Now(), "yyyy-MM-dd HH-mm-ss")
                            My.Computer.FileSystem.CopyFile(s, t, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs)
                        Else
                            My.Computer.FileSystem.CopyFile(s, t, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs)
                        End If
                    Catch ex As Exception
                        If myOptions.WrLog.Checked Then
                            logFile.WriteLine(SysMsg(401) & ":   " + s)
                            logFile.WriteLine("- - - - - - - " + ex.Message)
                        End If
                        Ms.Items.Add(SysMsg(401) & ":   " + s)
                        Ms.Items.Add("- - - - - - - - " + ex.Message)
                        InErr = True
                    End Try
                Else
                    Try
                        If tr.Tag = "FI" Then
                            t = t + "\" + Format(Now(), "yyyy-MM-dd HH-mm-ss")
                            My.Computer.FileSystem.CopyFile(s, t, True)
                        Else
                            My.Computer.FileSystem.CopyFile(s, t, True)
                        End If
                    Catch ex As Exception
                        If myOptions.WrLog.Checked Then
                            logFile.WriteLine(SysMsg(401) & ":   " + s)
                            logFile.WriteLine("- - - - - - - " + ex.Message)
                        End If
                        Ms.Items.Add(SysMsg(401) & ":   " + s)
                        Ms.Items.Add("- - - - - - - - " + ex.Message)
                        InErr = True
                    End Try
                End If
                If UserCancelled Then
                    Exit Sub
                End If
                Dim ifs As DirectoryInfo
                Dim ift As DirectoryInfo
                Try
                    ifs = New DirectoryInfo(s)
                    ift = New DirectoryInfo(t)
                    ift.Attributes = ifs.Attributes
                Catch ex As Exception
                End Try
                If myOptions.WrLog.Checked Then
                    logFile.WriteLine(s)
                End If
                If myOptions.VerCopy.Checked Then
                    Application.DoEvents()
                    If UserCancelled Then
                        Exit Sub
                    End If
                    Dim fs As FileStream = New FileStream(s, FileMode.Open, FileAccess.Read)
                    Dim r As New BinaryReader(fs)
                    Dim fsc As FileStream = New FileStream(t, FileMode.Open, FileAccess.Read)
                    Dim rc As New BinaryReader(fsc)
                    Dim eofi As Boolean = False
                    Dim dta(1024) As Byte
                    Dim vfy(1024) As Byte
                    Dim n, n2 As Integer
                    While Not eofi
                        n = r.Read(dta, 0, 1024)
                        If n <> 1024 Then
                            eofi = True
                        End If
                        n2 = rc.Read(vfy, 0, 1024)
                        If n <> n2 Then
                            If myOptions.WrLog.Checked Then
                                logFile.WriteLine(SysMsg(401) & ":   " + s)
                                logFile.WriteLine("- - - - - - - " & SysMsg(402))
                            End If
                            Ms.Items.Add(SysMsg(401) & ":   " + s)
                            Ms.Items.Add("- - - - - - - " & SysMsg(402))
                            InErr = True
                            eofi = True
                        End If
                        For i As Integer = 0 To 1024
                            If vfy(i) <> dta(i) Then
                                If myOptions.WrLog.Checked Then
                                    logFile.WriteLine(SysMsg(401) & ":   " + s)
                                    logFile.WriteLine("- - - - - - - " & SysMsg(403))
                                End If
                                Ms.Items.Add(SysMsg(401) & ":   " + s)
                                Ms.Items.Add("- - - - - - - " & SysMsg(403))
                                InErr = True
                                eofi = True
                                Exit For
                            End If
                        Next i
                    End While
                    r.Close()
                    fs.Close()
                    rc.Close()
                    fsc.Close()
                End If
            End If
        Catch ex As Exception
            If myOptions.WrLog.Checked Then
                logFile.WriteLine(SysMsg(401) & ":   " + s)
                logFile.WriteLine("- - - - - - - " + ex.Message)
            End If
            Ms.Items.Add(SysMsg(401) & ":   " + s)
            Ms.Items.Add("- - - - - - - - " + ex.Message)
            InErr = True
        End Try
    End Sub
    Private Sub Ms_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Ms.MouseDown
        Dim Button As Integer = e.Button \ &H100000
        If Button = 2 Then
            Dim ni As Integer = 0
            For Each si As String In Ms.SelectedItems
                If si.Length() > SysMsg(401).Length Then
                    If si.Substring(0, SysMsg(401).Length) = SysMsg(401) Then
                        ni += 1
                    End If
                End If
            Next
            If ni = 0 Then
                Me.ContextMenuStrip = Nothing
            Else
                Dim s As String = SysMsg(79)
                Dim i As Integer = s.IndexOf("%"c)
                If i > -1 Then
                    s = s.Substring(0, i) & CStr(ni) & s.Substring(i + 1)
                End If
                ExToolStripMenuItem.Text = s
                Me.ContextMenuStrip = ContextMenuStrip2
            End If
        End If
    End Sub
    Private Sub ExToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExToolStripMenuItem.Click
        ScriptChanged = True
        Dim t As New UitEen
        t.tEntry = cFil
        t.tInExcl = cSelct
        Dim sm As String = SysMsg(401)
        Dim sl As Integer = sm.Length()
        For Each si As String In Ms.SelectedItems
            If si.Length() > sl Then
                If si.Substring(0, sl) = sm Then
                    t.tName = si.Substring(sl + 4)
                    AddEntryInStd(t.tName, "F", t)
                End If
            End If
        Next
    End Sub
    Private Sub Mst_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Mst.MouseDown
        Dim Button As Integer = e.Button \ &H100000
        If Button = 2 Then
            ExclNameHereToolStripMenuItem.Text = SysMsg(301)
            ExclNameInAllMapsToolStripMenuItem.Text = SysMsg(302)
            ExclTypeHereToolStripMenuItem.Text = SysMsg(303)
            ExclTypeInAllMapsToolStripMenuItem.Text = SysMsg(304)
            If Not BackupDone Then
                FinishedToolStripMenuItem.Text = SysMsg(305)
            Else
                FinishedToolStripMenuItem.Text = SysMsg(308)
            End If
            UndoLastToolStripMenuItem.Text = SysMsg(306)
            ExpertModeToolStripMenuItem.Text = SysMsg(307)
            StdClickedNode = Mst.GetNodeAt(e.X, e.Y)
            If Not StdClickedNode Is Nothing AndAlso StdClickedNode.Text <> FilesListText Then
                Dim fnNme As String = StdClickedNode.Text
                Dim j As Integer = fnNme.LastIndexOf("<"c)
                If j > -1 Then
                    fnNme = fnNme.Substring(0, j - 3)
                End If
                StdClickedNode.TreeView.SelectedNode = StdClickedNode
                j = fnNme.LastIndexOf(".")
                Dim TypeF As String = ""
                If j > -1 Then
                    TypeF = fnNme.Substring(j + 1)
                End If
                ExclNameHereToolStripMenuItem.Text = ExclNameHereToolStripMenuItem.Text & " " & fnNme
                ExclNameHereToolStripMenuItem.Enabled = True
                ExclNameInAllMapsToolStripMenuItem.Text = ExclNameInAllMapsToolStripMenuItem.Text & " " & fnNme
                ExclNameInAllMapsToolStripMenuItem.Enabled = True
                If j > -1 Then
                    ExclTypeHereToolStripMenuItem.Text = ExclTypeHereToolStripMenuItem.Text & " " & TypeF
                    ExclTypeHereToolStripMenuItem.Enabled = True
                    ExclTypeInAllMapsToolStripMenuItem.Text = ExclTypeInAllMapsToolStripMenuItem.Text & " " & TypeF
                    ExclTypeInAllMapsToolStripMenuItem.Enabled = True
                Else
                    ExclTypeHereToolStripMenuItem.Enabled = False
                    ExclTypeInAllMapsToolStripMenuItem.Enabled = False
                End If
                UndoLastToolStripMenuItem.Enabled = (RemFromMst.Count > 0)
            Else
                ExclNameHereToolStripMenuItem.Enabled = False
                ExclNameInAllMapsToolStripMenuItem.Enabled = False
                ExclTypeHereToolStripMenuItem.Enabled = False
                ExclTypeInAllMapsToolStripMenuItem.Enabled = False
                UndoLastToolStripMenuItem.Enabled = False
            End If
            Me.ContextMenuStrip = ContextMenuStrip1
        Else
            Me.ContextMenuStrip = Nothing
        End If
    End Sub
    Private Sub ExclNameHereToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExclNameHereToolStripMenuItem.Click
        ScriptChanged = True
        fAddToStd = False
        RemFromMst.Clear()
        AddEntryInStd(StdClickedNode.FullPath, StdClickedNode.Tag) '  add to std
        Dim nd As New RemMst
        nd.RemMstN = StdClickedNode
        nd.RemMstP = StdClickedNode.Parent
        nd.RemMstI = StdClickedNode.Index
        RemFromMst.Add(nd)
        AdjustNCopy(StdClickedNode, -1)
        StdClickedNode.Parent.Nodes.Remove(StdClickedNode) ' delete from mst
    End Sub
    Private Sub ExclNameInAllMapsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExclNameInAllMapsToolStripMenuItem.Click
        ScriptChanged = True
        fAddToStd = False
        RemFromMst.Clear()
        AddEntryInStd("*\" & StdClickedNode.Text, StdClickedNode.Tag) ' add to std *
        Dim nd As New RemMst
        nd.RemMstN = StdClickedNode
        nd.RemMstP = StdClickedNode.Parent
        nd.RemMstI = StdClickedNode.Index
        RemFromMst.Add(nd)
        AdjustNCopy(StdClickedNode, -1)
        StdClickedNode.Parent.Nodes.Remove(StdClickedNode) ' delete from mst
    End Sub
    Private Sub ExclTypeHereToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExclTypeHereToolStripMenuItem.Click
        ScriptChanged = True
        fAddToStd = False
        RemFromMst.Clear()
        Dim f As String = StdClickedNode.FullPath
        Dim j As Integer = f.LastIndexOf("<"c)
        If j > -1 Then
            f = f.Substring(0, j - 3)
        End If
        Dim p() As String = Split(f, "\")
        Dim i As Integer = p.Length() - 1
        Dim fn As String = p(i)
        j = fn.LastIndexOf(".")
        Dim TypeF As String = fn.Substring(j + 1).ToUpper
        p(i) = "*." & TypeF
        AddEntryInStd(Join(p, "\"), "F") ' delete from mst, add to std
        Dim curTr As TreeNode = StdClickedNode.Parent
        For Each tr As TreeNode In curTr.Nodes
            remFileType(tr, TypeF)
        Next
        For Each nd As RemMst In RemFromMst
            AdjustNCopy(nd.RemMstN, -1)
            curTr.Nodes.Remove(nd.RemMstN)
        Next
    End Sub
    Private Sub remFileType(ByVal tr As TreeNode, ByVal TypeF As String)
        Dim p() As String = Split(tr.FullPath, "\")
        Dim i As Integer = p.Length() - 1
        Dim fn As String = p(i)
        Dim j As Integer = fn.LastIndexOf(".")
        If j > -1 Then
            If TypeF = fn.Substring(j + 1).ToUpper Then
                Dim nd As New RemMst
                nd.RemMstN = tr
                nd.RemMstP = tr.Parent
                nd.RemMstI = tr.Index
                RemFromMst.Add(nd)
            End If
        End If
    End Sub
    Private Sub ExclTypeInAllMapsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExclTypeInAllMapsToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        ScriptChanged = True
        fAddToStd = False
        RemFromMst.Clear()
        Dim f As String = StdClickedNode.FullPath
        Dim j As Integer = f.LastIndexOf("<"c)
        If j > -1 Then
            f = f.Substring(0, j - 3)
        End If
        Dim p() As String = Split(f, "\")
        Dim i As Integer = p.Length() - 1
        Dim fn As String = p(i)
        j = fn.LastIndexOf(".")
        Dim TypeF As String = fn.Substring(j + 1).ToUpper
        AddEntryInStd("*\*." & TypeF, "F") ' add to std
        Dim curTr As TreeNode = StdClickedNode.Parent
        For Each tr As TreeNode In Mst.Nodes ' delete from mst
            remFileType(tr, TypeF)
            ExclTypeInAllMapsDown(tr, TypeF)
        Next
        For Each nd As RemMst In RemFromMst
            AdjustNCopy(nd.RemMstN, -1)
            curTr.Nodes.Remove(nd.RemMstN)
        Next
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub ExclTypeInAllMapsDown(ByVal rtr As TreeNode, ByVal TypeF As String)
        For Each tr As TreeNode In rtr.Nodes
            remFileType(tr, TypeF)
            ExclTypeInAllMapsDown(tr, TypeF)
        Next
    End Sub
    Private Sub UndoLastToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UndoLastToolStripMenuItem.Click
        For Each nd As RemMst In RemFromMst
            AdjustNCopy(nd.RemMstN, +1)
            nd.RemMstP.Nodes.Insert(nd.RemMstI, nd.RemMstN) ' delete from std, add to mst
        Next
        RemFromMst.Clear()
    End Sub
    Private Sub FinishedToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FinishedToolStripMenuItem.Click
        If BackupDone Then
            Me.Hide()
        Else
            If ScriptChanged Then
                SaveSt_Click()
            End If
            BackupProc()
        End If
    End Sub
    Private Sub ExpertModeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpertModeToolStripMenuItem.Click
        Me.Hide()
    End Sub
    Private Sub AdjustNCopy(ByVal tr As TreeNode, ByVal delta As Integer)
        AdjustNCopyN(tr, delta)
        LMsg.Text = CStr(nFcopy) & " " & SysMsg(78)
        LMsg.Update()
    End Sub
    Private Sub AdjustNCopyN(ByVal tr As TreeNode, ByVal delta As Integer)
        For Each ntr As TreeNode In tr.Nodes
            If ntr.Tag(0) = "F" Then
                nFcopy += delta
                nFcopyCha = True
            End If
            AdjustNCopyN(ntr, delta)
        Next
    End Sub
    Friend Sub SaveSt_Click()
        SaveFileDialog1.FileName = OpenNaam
        SaveFileDialog1.CheckFileExists = False
        SaveFileDialog1.Title = SysMsg(310)
        SaveFileDialog1.Filter = SysMsg(311)
        SaveFileDialog1.ShowDialog()
        If SaveFileDialog1.FileName = "" Then
            Exit Sub
        End If
        SaveStFile(SaveFileDialog1.FileName)
    End Sub
    Friend Sub SaveStFile(ByVal Filename As String)
        Dim t As New UitEen
        If Filename = "" Then
            SaveSt_Click()
            Exit Sub
        End If
        If Not WritableFile(Filename) Then
            Exit Sub
        End If
        Dim st As Stream = File.Open(Filename, FileMode.Create, FileAccess.ReadWrite, FileShare.None)
        Wrtr = New StreamWriter(st)
        Dim s As String
        If myOptions.ShutDown.Checked And Not myOptions.OnlyOnce.Checked Then
            s = "Y"
        Else
            s = "N"
        End If
        If myOptions.VerCopy.Checked Then
            s += "Y"
        Else
            s += "N"
        End If
        If myOptions.WrLog.Checked Then
            s += "Y"
        Else
            s += "N"
        End If
        s = s + myOptions.ProgSizeN.Text.PadRight(10)
        If myOptions.WrLog.Checked Then
            s += myOptions.DsnLog.Text
        End If
        Wrt(s)
        Wrt(SelRootDirsDirDest)
        For Each SNode As TreeNode In myExpMode.Std.Nodes
            Wrt("0 " + SNode.Text)
            SaveGoDown(0, SNode, t)
        Next
        Wrtr.Close()
        st.Close()
        ScriptChanged = False
    End Sub
    Private Sub SaveGoDown(ByVal ix As Integer, ByVal nd As TreeNode, ByVal t As UitEen)
        For Each SNode As TreeNode In nd.Nodes
            Wrt(CStr(ix + 1) + " ".PadRight(ix + 2) + SNode.Text)
            SaveGoDown(ix + 1, SNode, t)
        Next
    End Sub
End Class
Friend Class IncDPathc
    Friend IncDNd As TreeNode
    Friend IncDPath As String
End Class
Friend Class IncFni
    Friend IncFNm As String
    Friend IncFInc As Boolean
    Friend IncFSze As Integer
End Class
