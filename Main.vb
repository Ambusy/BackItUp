Module Main
    Friend Const LmtExp As Integer = 7
    Friend Const cIncl As String = "Incl"
    Friend Const cExcl As String = "Excl"
    Friend Const cSelct As String = "Sel"
    Friend Const cIncr As String = "Incr"
    Friend Const cDir As String = "Dir"
    Friend Const cFil As String = "Fil"
    Friend Wrtr As StreamWriter, Rdr As StreamReader
    Friend myForm As New Form1()
    Friend mylForm As New GetLang()
    Friend myExpMode As New ExpertMode()
    Friend myAnal As New Analyse()
    Friend myVeri As New Verifi()
    Friend myOptions As New Options()
    Friend CommandLine As String
    Friend ScriptChanged, UserCancelled As Boolean
    Friend IncF As New Collection ' files to include
    Friend IncD As New Collection ' dirs to include
    Friend SysConst As New Collection
    Friend AnalAutoMode As Boolean
    Friend BackupDone As Boolean
    Friend BckAutoMode As Boolean
    Friend DirDestName As String
    Friend nFcopy As Integer, nFcopyCha As Boolean
    Friend FilesListText As String
    Friend RemFromMst As New Collection
    Friend pAddToStd As TreeNode, AddToStd As TreeNode, fAddToStd As Boolean
    Friend SelRootDirsDirDest As String = ""
    Friend StdClickedNode, StdHdrNode As TreeNode
    Friend SelectedNames() As String
    Friend OpenNaam As String
    Public Sub Main(ByVal cmdArgs() As String)
        If Not My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\" & "system messages.txt") Then
            Application.Run(mylForm)
        End If
        ReadSysMsg(My.Application.Info.DirectoryPath & "\system messages.txt")
        If cmdArgs.GetUpperBound(0) > -1 Then
            CommandLine = cmdArgs(0).Trim()
        Else
            CommandLine = ""
        End If
        If Left(CommandLine, 1) = """" Then ' EXPLORER puts filename between " "
            CommandLine = Mid(CommandLine, 2)
            If Right(CommandLine, 1) = """" Then CommandLine = Mid(CommandLine, 1, CommandLine.Length() - 1)
        End If
        myOptions.CheckWinDir.Text = My.Application.GetEnvironmentVariable("WinDir")
        myOptions.CheckWinDir.Checked = True
        myOptions.CheckProgr.Text = My.Application.GetEnvironmentVariable("ProgramFiles")
        myOptions.CheckProgr.Checked = True
        'myOptions.CheckSysVol.Checked = True
        'myOptions.CheckRecy.Checked = True
        Application.Run(myForm)
    End Sub
    <Global.System.Diagnostics.DebuggerStepThroughAttribute()> _
    Friend Sub ParseNodeText(ByVal s As String, ByVal t As UitEen)
        Dim w As String = NxtWordFromStr(s)
        t.tHidFil = False
        t.tHidDir = False
        t.tIncr = False
        t.tInExcl = w
        w = NxtWordFromStr(s)
        t.tEntry = w
        Dim i As Integer = s.IndexOf("<"c)
        If i > -1 Then
            Dim gt As String = s.Substring(i + 2)
            s = s.Substring(0, i - 3)
            i = gt.IndexOf(">"c)
            gt = gt.Substring(0, i - 1)
            t.tSze = CInt(gt)
        End If
        i = s.IndexOf("/"c)
        If i > -1 Then
            t.tName = s.Substring(0, i - 1).Trim()
            s = s.Substring(i)
            While s.Length() > 0 AndAlso s.Substring(0, 1) = "/"
                If s.Substring(1, 1) = "d" Then t.tHidDir = True
                If s.Substring(1, 1) = "f" Then t.tHidFil = True
                If s.Substring(1, 1) = "i" Then t.tIncr = True
                If s.Length() > 2 Then
                    s = s.Substring(3)
                Else
                    Exit While
                End If
            End While
        Else
            t.tName = s.Trim()
        End If
    End Sub
    <Global.System.Diagnostics.DebuggerStepThroughAttribute()> _
    Friend Function ComposeNodeText(ByVal t As UitEen) As String
        Dim w As String = t.tInExcl & " " & t.tEntry & " " & t.tName
        If t.tInExcl <> cExcl Then
            If t.tHidFil Then w = w & " /f"
            If t.tHidDir Then w = w & " /d"
            If t.tIncr Then w = w & " /i"
            If t.tSze <> 0 Then w = w & "   < " & CStr(t.tSze) & " >"
        End If
        Return w
    End Function
    Friend Sub Wrt(ByVal s As String)
        Debug.WriteLine(s)
        Wrtr.Write(s & vbCrLf)
    End Sub
    <Global.System.Diagnostics.DebuggerStepThroughAttribute()> _
     Friend Function WritableFile(ByVal fn As String) As Boolean
        Dim f As String
        WritableFile = False
        f = Path.GetFullPath(fn)
        Dim dr As New DirectoryInfo(f.Substring(0, 2))
        If dr.Attributes = -1 Then
            MsgBox(SysMsg(6))
            Exit Function
        End If
        If CBool(dr.Attributes And FileAttributes.ReadOnly) Then ' R/O drive
            MsgBox(SysMsg(7))
            Exit Function
        End If
        If File.Exists(f) Then
            Dim fi As New FileInfo(f)
            If CBool(fi.IsReadOnly) Then
                MsgBox(SysMsg(8))
                Exit Function
            End If
        End If
        WritableFile = True
    End Function
    <Global.System.Diagnostics.DebuggerStepThroughAttribute()> _
     Friend Function NxtWordFromStr(ByRef s As String, Optional ByVal Def As String = "", Optional ByVal sep As String = " ") As String ' modifies s .............
        ' get next word from string, and strip from string s
        Dim i As Integer
        s = s.TrimStart()
        i = InStr(1, s, sep)
        If i = 0 Then
            NxtWordFromStr = s
            s = ""
        Else
            NxtWordFromStr = s.Substring(0, i - 1)
            s = s.Substring(i)
        End If
        If NxtWordFromStr = "" Then If Not IsNothing(Def) Then NxtWordFromStr = Def
        NxtWordFromStr = NxtWordFromStr
    End Function
    <Global.System.Diagnostics.DebuggerStepThroughAttribute()> _
    Friend Sub SelTextBox(ByVal yt As TextBox)
        yt.SelectionStart = 0
        yt.SelectionLength = 99
        yt.Select()
    End Sub
    <Global.System.Diagnostics.DebuggerStepThroughAttribute()> _
      Friend Function SysMsg(ByVal i As Integer) As String
        Dim s As String = "SFL" & CStr(i)
        If SysConst.Contains(s) Then
            SysMsg = CStr(SysConst.Item(s))
        Else
            SysMsg = s & " not defined in 'system messages.txt'"
        End If
    End Function
    Friend Sub ReadSysMsg(ByVal Filename As String)
        Dim line As String
        Dim w As String
        Try
            Using sr As StreamReader = New StreamReader(Filename)
                ' Read and display the lines from the file until the end 
                ' of the file is reached.
                line = sr.ReadLine()
                While Not (line Is Nothing)
                    w = NxtWordFromStr(line)
                    If w.Length() > 3 AndAlso w.Substring(0, 3) = "SFL" Then
                        SysConst.Add(line, w)
                    End If
                    line = sr.ReadLine()
                End While
                sr.Close()
            End Using
        Catch E As Exception
            MsgBox("File: " & Filename & " not found or corrupted, cancelling program. Reinstall systemfiles", MsgBoxStyle.Exclamation)
            myForm.Close()
        End Try
    End Sub
    Friend Sub FindAllDir(ByVal dirn As String, ByVal BrwseDirs As Collection, ByVal level0 As Boolean)
        ' take all dirs, if name contains ? or *
        Dim dp() As String = dirn.Split("\"c)
        For i As Integer = 0 To dp.Length() - 1
            Dim ne As Integer = BrwseDirs.Count
            If (dp(i).IndexOf("*") >= 0 OrElse dp(i).IndexOf("?") >= 0) Then
                For id As Integer = 1 To BrwseDirs.Count
                    Dim dnn As String = CStr(BrwseDirs.Item(id))
                    Try
                        Dim s() As String = Directory.GetDirectories(dnn & "\", dp(i))
                        For jf As Integer = 0 To s.Length() - 1
                            If Not level0 Then
                                BrwseDirsAdd(BrwseDirs, s(jf))
                            Else
                                Dim nm As String = s(jf)
                                Dim od() As String = nm.Split("\"c)
                                nm = od(1).ToUpper()
                                If nm <> "SYSTEM VOLUME INFORMATION" AndAlso nm <> "$RECYCLE.BIN" AndAlso nm <> "RECYCLER" AndAlso nm <> "RECYCLED" Then
                                    BrwseDirsAdd(BrwseDirs, s(jf))
                                End If
                            End If
                        Next
                    Catch ex As Exception
                    End Try
                Next
            Else
                If i = 0 Then
                    BrwseDirs.Add(dp(0))
                Else
                    For id As Integer = 1 To BrwseDirs.Count
                        BrwseDirs.Add(CStr(BrwseDirs.Item(id)) + "\" + dp(i))
                    Next
                End If
            End If
            For j As Integer = 1 To ne ' remove old entries, are all renewed
                BrwseDirs.Remove(1)
            Next
        Next
    End Sub
    Private Sub BrwseDirsAdd(ByVal BrwseDirs As Collection, ByVal nm As String)
        Try ' only accessible directories
            Dim d() As String = Directory.GetFiles(nm & "\", "x.x")
            BrwseDirs.Add(nm)
        Catch ex As UnauthorizedAccessException
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Friend Sub AddEntryInStd(ByVal f As String, ByVal flag As String, ByVal Flgs As UitEen)
        If flag = "F" Then
            Dim j As Integer = f.LastIndexOf("<"c)
            If j > -1 Then
                f = f.Substring(0, j - 3)
            End If
            Dim p() As String = Split(f, "\")
            f = p(0)
            For i As Integer = 1 To p.Length() - 2
                If p(i) <> FilesListText Then
                    f = f & "\" & p(i)
                End If
            Next
            Flgs.tName = f
            Flgs.tEntry = cDir
            If Flgs.tInExcl = cExcl Then
                Flgs.tInExcl = cSelct
            End If
            AddDirToStd(Flgs, flag)
            Flgs.tName = f & "\" & p(p.Length() - 1)
            Flgs.tEntry = cFil
            If Flgs.tInExcl = cSelct Then
                Flgs.tInExcl = cExcl
            End If
            AddFilToStd(Flgs)
        Else
            Flgs.tName = f
            Flgs.tEntry = cDir
            AddDirToStd(Flgs, flag)
        End If
    End Sub
    Friend Function FindInMst(ByVal f As String) As TreeNode
        Dim p() As String, t As New UitEen, i As Integer
        p = Split(f, "\")
        i = 0
        For Each tr As TreeNode In myExpMode.Std.Nodes ' find root dir
            ParseNodeText(tr.Text, t)
            If t.tName.ToUpper = p(i).ToUpper Then
                If i < (p.Length() - 1) Then
                    Return FindInMstL(tr, p, i + 1, t) ' descend
                End If
            End If
        Next
        Return Nothing
    End Function
    Friend Function FindInMstL(ByVal trp As TreeNode, ByVal p() As String, ByVal i As Integer, ByVal t As UitEen) As TreeNode
        For Each tr As TreeNode In trp.Nodes ' find sub dir
            ParseNodeText(tr.Text, t)
            If t.tName.ToUpper = p(i).ToUpper Then
                If i < (p.Length() - 1) Then
                    Return FindInMstL(tr, p, i + 1, t) ' descend
                Else
                    Return tr
                End If
            End If
        Next
        Return trp
    End Function
    Friend Sub AddEntryInStd(ByVal f As String, ByVal flag As String)
        Dim flgs As New UitEen, pa As TreeNode
        pa = FindInMst(f)
        If Not pa Is Nothing Then
            ParseNodeText(pa.Text, flgs)
        Else
            flgs.tHidDir = False
            flgs.tHidFil = False
            flgs.tIncr = False
        End If
        flgs.tInExcl = cExcl
        AddEntryInStd(f, flag, flgs)
    End Sub
    Friend Sub AddDirToStd(ByVal Flgs As UitEen, ByVal FlagDF As String)
        Dim t As New UitEen, fnd As Boolean
        Dim nam As String = Flgs.tName
        Dim p() As String = Split(nam, "\")
        Dim i As Integer = 0
        fnd = False
        For Each tr As TreeNode In myExpMode.Std.Nodes ' find root dir
            ParseNodeText(tr.Text, t)
            If t.tName.ToUpper = p(i).ToUpper Then
                If i < (p.Length() - 1) Then
                    AddDirToStdL(tr, p, i + 1, Flgs, FlagDF) ' descend
                End If
                fnd = True
                Exit For
            End If
        Next
        If Not fnd Then ' name not found yet: insert root
            t.tEntry = Flgs.tEntry
            t.tHidDir = Flgs.tHidDir
            t.tHidFil = Flgs.tHidFil
            t.tIncr = Flgs.tIncr
            t.tInExcl = Flgs.tInExcl
            t.tName = p(i)
            Dim nn As TreeNode = New TreeNode(ComposeNodeText(t))
            If t.tName = "*" Then
                myExpMode.Std.Nodes.Insert(0, nn)
            Else
                myExpMode.Std.Nodes.Add(nn)
            End If
            If i < (p.Length() - 1) Then
                AddDirToStdL(nn, p, i + 1, Flgs, FlagDF) ' descend
            End If
        End If
    End Sub
    Private Sub AddDirToStdL(ByVal tr As TreeNode, ByVal p() As String, ByVal i As Integer, ByVal Flgs As UitEen, ByVal FlagDF As String)
        Dim t As New UitEen
        Dim fnd As Boolean = False
        For Each ntr As TreeNode In tr.Nodes ' descend sub dirs
            ParseNodeText(ntr.Text, t)
            If t.tName.ToUpper = p(i).ToUpper Then ' found  entry: do not add to excluded
                If t.tInExcl <> cExcl Then ' found incl/part 
                    If i < (p.Length() - 1) Then ' searching for a deeper one
                        AddDirToStdL(ntr, p, i + 1, Flgs, FlagDF)
                    ElseIf Flgs.tInExcl = cExcl Then ' found the deepest dir: change to exclude and remove subnodes if we are excluding it
                        t.tInExcl = cExcl
                        ntr.Text = ComposeNodeText(t)
                        For Each nxtr As TreeNode In ntr.Nodes
                            ntr.Nodes.Remove(nxtr)
                        Next
                    End If
                End If
                fnd = True
                Exit For
            End If
        Next
        If Not fnd Then ' name not specified: insert and descend if not last one
            t.tEntry = Flgs.tEntry
            If FlagDF = "F" Then
                Dim tol As New UitEen
                ParseNodeText(tr.Text, tol)
                t.tHidDir = tol.tHidDir
                t.tHidFil = tol.tHidFil
                t.tIncr = tol.tIncr
            Else
                t.tHidDir = Flgs.tHidDir
                t.tHidFil = Flgs.tHidFil
                t.tIncr = Flgs.tIncr
            End If
            t.tInExcl = Flgs.tInExcl
            If t.tInExcl = cExcl Then
                If i < (p.Length - 1) Then
                    t.tInExcl = cSelct
                End If
            End If
            t.tName = p(i)
            Dim nn As TreeNode = New TreeNode(ComposeNodeText(t))
            tr.Nodes.Add(nn)
            If i < LmtExp Then tr.Expand()
            If i < p.Length() - 1 Then
                AddDirToStdL(nn, p, i + 1, Flgs, FlagDF)
            End If
        End If
    End Sub
    Friend Sub AddFilToStd(ByVal Flgs As UitEen)
        Dim t As New UitEen, fnd As Boolean
        Dim nam As String = Flgs.tName
        Dim p() As String = Split(nam, "\")
        Dim i As Integer = 0
        For Each tr As TreeNode In myExpMode.Std.Nodes ' find root dir
            ParseNodeText(tr.Text, t)
            If t.tName.ToUpper = p(i).ToUpper Then
                If i < (p.Length() - 1) Then
                    AddFilToStdL(tr, p, i + 1, Flgs) ' descend
                End If
                fnd = True
                Exit For
            End If
        Next
    End Sub
    Private Sub AddFilToStdL(ByVal tr As TreeNode, ByVal p() As String, ByVal i As Integer, ByVal Flgs As UitEen)
        Dim t As New UitEen
        Dim fnd As Boolean = False
        For Each ntr As TreeNode In tr.Nodes
            ParseNodeText(ntr.Text, t)
            If t.tName.ToUpper = p(i).ToUpper Then ' found  entry
                If i = (p.Length() - 2) AndAlso t.tInExcl = cExcl AndAlso Flgs.tInExcl = cExcl Then ' found the lower dir: change to exclude  
                    t.tInExcl = cSelct
                    ntr.Text = ComposeNodeText(t)
                End If
                If i < (p.Length() - 1) Then ' searching for a deeper one
                    AddFilToStdL(ntr, p, i + 1, Flgs)
                End If
                fnd = True
                Exit For
            End If
        Next
        If Not fnd Then ' name not specified: insert filename
            t.tEntry = cFil
            t.tHidDir = False
            t.tHidFil = False
            t.tIncr = Flgs.tIncr
            t.tInExcl = Flgs.tInExcl
            t.tName = p(i)
            Dim nn As TreeNode = New TreeNode(ComposeNodeText(t))
            tr.Nodes.Add(nn)
            If i < LmtExp Then tr.Expand()
        End If
    End Sub
    Friend Sub AddEntryToMst(ByVal nm As String, ByVal sn As TreeNode, ByVal tf As UitEen)
        Dim t As New UitEen, fnd As Boolean
        Dim p() As String = Split(nm, "\")
        Dim i As Integer = 0
        fnd = False
        For Each tr As TreeNode In myAnal.Mst.Nodes ' find root dir
            If tr.Text.ToUpper = p(i).ToUpper Then
                If i < (p.Length() - 1) Then
                    AddEntryToMstL(tr, p, i + 1, nm, sn) ' descend
                End If
                fnd = True
                Exit For
            End If
        Next
        If Not fnd Then ' name not found yet: insert root
            Dim nn As TreeNode = New TreeNode(p(i))
            nn.Tag = "R" ' root
            myAnal.Mst.Nodes.Add(nn)
            If i < (p.Length() - 1) Then
                AddEntryToMstL(nn, p, i + 1, nm, sn) ' descend
            End If
        End If
    End Sub
    Private Sub AddEntryToMstL(ByVal tr As TreeNode, ByVal p() As String, ByVal i As Integer, ByVal nm As String, ByVal sn As TreeNode)
        Dim fnd As Boolean = False
        For Each ntr As TreeNode In tr.Nodes
            If ntr.Text.ToUpper = p(i).ToUpper Then ' found  entry
                If i < (p.Length() - 1) Then ' not last one, descend more
                    AddEntryToMstL(ntr, p, i + 1, nm, sn)
                End If
                fnd = True
                Exit For
            End If
        Next
        If Not fnd Then ' name not specified: insert and descend if not last one
            Dim nn As TreeNode = New TreeNode(p(i))
            Dim t As New UitEen
            ParseNodeText(sn.Text, t)
            If tr.Text = FilesListText Then
                If t.tIncr Then
                    nn.Tag = "FI" ' files
                Else
                    nn.Tag = "F" ' files
                    If t.tSze > 0 Then
                        Dim kb As Double = 1024
                        Dim mb As Double = kb * 1024
                        If t.tSze < kb Then
                            nn.Text = nn.Text & "   < " & CStr(t.tSze) & " >"
                        ElseIf t.tSze < mb Then
                            nn.Text = nn.Text & "   < " & CStr(CInt(t.tSze / kb)) & " Kb >"
                        Else
                            nn.Text = nn.Text & "   < " & CStr(CInt(t.tSze / mb)) & " Mb >"
                        End If
                    End If
                End If
            Else
                If nn.Text = FilesListText Then
                    nn.Tag = "X" ' ignore
                Else
                    nn.Tag = "D" ' directory
                End If
            End If
            tr.Nodes.Add(nn)
            If i < LmtExp And tr.Text <> FilesListText Then tr.Expand()
            If i < p.Length() - 1 Then
                AddEntryToMstL(nn, p, i + 1, nm, sn)
            End If
        End If
    End Sub
    Friend Sub AddEntryToMstV(ByVal nm As String, ByVal t As UitEen)
        Dim fnd As Boolean
        Dim p() As String = Split(nm, "\")
        Dim i As Integer = 0
        fnd = False
        For Each tr As TreeNode In myVeri.Mst.Nodes ' find root dir
            If tr.Text.ToUpper = p(i).ToUpper Then
                If i < (p.Length() - 1) Then
                    AddEntryToMstVL(tr, p, i + 1, nm, t) ' descend
                End If
                fnd = True
                Exit For
            End If
        Next
        If Not fnd Then ' name not found yet: insert root
            Dim nn As TreeNode = New TreeNode(p(i))
            nn.Tag = "R" ' root
            myVeri.Mst.Nodes.Add(nn)
            If i < (p.Length() - 1) Then
                AddEntryToMstVL(nn, p, i + 1, nm, t) ' descend
            End If
        End If
    End Sub
    Private Sub AddEntryToMstVL(ByVal tr As TreeNode, ByVal p() As String, ByVal i As Integer, ByVal nm As String, ByVal t As UitEen)
        Dim fnd As Boolean = False
        For Each ntr As TreeNode In tr.Nodes
            If ntr.Text.ToUpper = p(i).ToUpper Then ' found  entry
                If i < (p.Length() - 1) Then ' not last one, descend more
                    AddEntryToMstVL(ntr, p, i + 1, nm, t)
                End If
                fnd = True
                Exit For
            End If
        Next
        If Not fnd Then ' name not specified: insert and descend if not last one
            Dim nn As TreeNode = New TreeNode(p(i))
            If i < p.Length - 1 Then
                nn.Tag = "D" ' directory
            Else
                If t.tIncr Then
                    nn.Tag = "FI" ' files
                Else
                    nn.Tag = "F" ' files
                End If
            End If
            tr.Nodes.Add(nn)
            If i < LmtExp And tr.Text <> FilesListText Then tr.Expand()
            If i < p.Length() - 1 Then
                AddEntryToMstVL(nn, p, i + 1, nm, t)
            End If
        End If
    End Sub
End Module
Friend Class UitEen
    Friend tInExcl As String
    Friend tEntry As String
    Friend tName As String
    Friend tHidDir As Boolean
    Friend tHidFil As Boolean
    Friend tIncr As Boolean
    Friend tSze As Integer
End Class
Friend Class RemMst
    Friend RemMstN As TreeNode
    Friend RemMstP As TreeNode
    Friend RemMstI As Integer
End Class