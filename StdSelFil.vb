Imports System.Windows.Forms
Public Class StdSelFil
    Private Sub OkBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OkBut.Click
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
    Private Sub StdSelFil_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        HdTxt.Text = StdClickedNode.Text
        OkBut.Text = SysMsg(1)
        CancBut.Text = SysMsg(2)
        BrwseBut.Text = SysMsg(4)
        only.Text = SysMsg(356)
        IncrFil.Text = SysMsg(160)
        LMsg.Text = ""
        Dim t As New UitEen
        ParseNodeText(StdClickedNode.Text, t)
        IncrFil.Checked = t.tIncr
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
            ShowFilName()
        End If
    End Sub
    Private Sub ShowFilName()
        Dim d As String, nd As TreeNode, BrwseDirs As New Collection, ndr As TreeNode
        Dim t As New UitEen
        nd = StdClickedNode
        ParseNodeText(nd.Text, t)
        While t.tEntry = cFil
            nd = nd.Parent
            ParseNodeText(nd.Text, t)
        End While
        ndr = nd
        d = t.tName
        If nd Is Nothing AndAlso d.Length() = 2 AndAlso d(1) = ":"c Then
            d = d + "\" ' root must have \ at the end
        End If
        nd = nd.Parent
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
        ParseNodeText(ndr.Text, t)
        For Each d In BrwseDirs
            Try
                Dim s() As String = Directory.GetFiles(d)
                For i As Integer = s.GetLowerBound(0) To s.GetUpperBound(0)
                    Dim f As New FileInfo(s(i))
                    If Not t.tHidDir AndAlso (f.Attributes And FileAttributes.Hidden) <> 0 Then
                    Else
                        Dim fnd As Boolean = False
                        For j As Integer = 0 To Selname.Items.Count - 1
                            If CStr(Selname.Items(j)).ToUpper = f.Name.ToUpper Then
                                fnd = True
                                Exit For
                            End If
                        Next
                        If Not fnd Then Selname.Items.Add(f.Name)
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
