Imports System.Windows.Forms
Public Class StdSelDir
    Private Sub OkBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKBut.Click
        If GeenFouten() Then
            SelectedNames = NmT.Text.Split("|")
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub
    Private Function GeenFouten() As Boolean
        LMsg.Text = ""
        If NmT.Text.Length = 0 Then
            LMsg.Text = SysMsg(365)
        ElseIf NmT.Text.Length > 4 AndAlso NmT.Text.Substring(0.4) = "*** " Then
            LMsg.Text = SysMsg(365)
        End If
        Return LMsg.Text.Length() = 0
    End Function
    Private Sub CancBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancBut.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub StdSelDir_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim t As New UitEen
        HdTxt.Text = StdClickedNode.Text
        If StdHdrNode Is Nothing Then
            DPanelNm.Enabled = False
        Else
            DPanelNm.Enabled = True
        End If
        ParseNodeText(StdClickedNode.Text, t)
        hDir.Checked = t.tHidDir
        hFil.Checked = t.tHidFil
        IncrFil.Checked = t.tIncr
        Me.Text = SysMsg(150)
        OKBut.Text = SysMsg(1)
        CancBut.Text = SysMsg(2)
        BrwseBut.Text = SysMsg(4)
        hDir.Text = SysMsg(158)
        hFil.Text = SysMsg(159)
        IncrFil.Text = SysMsg(160)
        OnlyHere.Text = SysMsg(356)
        EnterNm.Text = SysMsg(157)
        LMsg.Text = ""
    End Sub
    Private Sub Brwse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BrwseBut.Click
        LMsg.Text = ""
        If BrwseBut.Text = SysMsg(156) Then
            BrwseBut.Text = SysMsg(4)
            Dim s As String = ""
            For Each sl As String In Selname.SelectedItems
                s = s + sl + "|"
            Next
            If s.Length() = 0 Then
                NmT.Text = "*** " & SysMsg(155) + " ***"
            Else
                NmT.Text = s.Substring(0, s.Length() - 1)
            End If
            Selname.Visible = False
        Else
            If Not StdHdrNode Is Nothing Then
                ShowDirName()
            End If
        End If
    End Sub
    Private Sub ShowDirName()
        Dim d As String, nd As TreeNode, BrwseDirs As New Collection
        Dim t As New UitEen
        ParseNodeText(StdHdrNode.Text, t)
        d = t.tName
        nd = StdHdrNode.Parent
        If nd Is Nothing AndAlso d.Length() = 2 AndAlso d(1) = ":"c Then
            d = d + "\" ' root must have \ at the end
        End If
        While Not (nd Is Nothing)
            ParseNodeText(nd.Text, t)
            d = t.tName + "\" + d
            nd = nd.Parent
        End While
        Selname.Items.Clear()
        If d.IndexOf("*") >= 0 OrElse d.IndexOf("?") >= 0 Then
            FindAllDir(d, BrwseDirs, False)
        Else
            If d.Length() > 0 Then BrwseDirs.Add(d)
        End If
        ParseNodeText(StdHdrNode.Text, t)
        For Each d In BrwseDirs
            Try
                Dim s() As String = Directory.GetDirectories(d)
                For i As Integer = s.GetLowerBound(0) To s.GetUpperBound(0)
                    Dim f As New DirectoryInfo(s(i))
                    If Not t.tHidDir AndAlso (f.Attributes And FileAttributes.Hidden) <> 0 Then
                    Else
                        Dim fnd As Boolean = False
                        For j As Integer = 0 To Selname.Items.Count - 1
                            If CStr(Selname.Items(j)).ToUpper = f.Name.ToUpper Then
                                fnd = True
                                Exit For
                            End If
                        Next
                        If Not fnd Then
                            Try ' only accessible directories
                                Dim dn() As String = Directory.GetFiles(d & "\" & f.Name & "\", "x.x")
                                Dim nm As String = f.Name.ToUpper()
                                If nm <> "SYSTEM VOLUME INFORMATION" AndAlso nm <> "$RECYCLE.BIN" AndAlso nm <> "RECYCLER" AndAlso nm <> "RECYCLED" Then
                                    Selname.Items.Add(f.Name)
                                End If
                            Catch ex As UnauthorizedAccessException
                            Catch ex As Exception
                                Throw ex
                            End Try
                        End If
                    End If
                Next
            Catch ex As Exception

            End Try
        Next
        Selname.Visible = True
        BrwseBut.Text = SysMsg(156)
    End Sub
    Private Sub Selname_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Selname.DoubleClick
        LMsg.Text = ""
        Brwse_Click(sender, e)
    End Sub

    Private Sub NmT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NmT.TextChanged
        LMsg.Text = ""
        BrwseBut.Text = SysMsg(4)
        Selname.Visible = False
    End Sub
End Class
