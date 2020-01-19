Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = SysMsg(51)
        OpenSt.Text = SysMsg(52)
        NewSt.Text = SysMsg(53)
        If CommandLine.Length() > 0 Then
            Timer1.Enabled = True
        End If
    End Sub
    Private Sub NewSt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewSt.Click
        Dim allDrives() As DriveInfo = DriveInfo.GetDrives()
        Dim d As DriveInfo
        ScriptChanged = True
        Analyse.SaveFileDialog1.FileName = ""
        SelRootDirs.ListBox1.Items.Clear()
        For Each d In allDrives
            If d.DriveType = DriveType.Fixed Then
                SelRootDirs.ListBox1.Items.Add(d.Name.Substring(0, 3))
            End If
        Next
        Dim flgs As New UitEen
        myExpMode.Std.Nodes.Clear()
        SelRootDirs.DirDest.Text = SelRootDirsDirDest
        Dim rc As Integer = SelRootDirs.ShowDialog()
        SelRootDirsDirDest = SelRootDirs.DirDest.Text.TrimEnd
        If rc = Windows.Forms.DialogResult.OK Or rc = Windows.Forms.DialogResult.Yes Then
            Dim CSelected1 As Boolean = False, CSelected2 As Boolean = False
            For Each s As String In SelRootDirs.ListBox1.SelectedItems
                flgs.tEntry = cDir
                flgs.tInExcl = cIncl
                flgs.tHidDir = True
                flgs.tHidFil = False
                If s.Substring(s.Length() - 1) = "\"c Then ' roots staan met \
                    s = s.Substring(0, s.Length() - 1)
                End If
                flgs.tName = s
                If s = myOptions.CheckWinDir.Text.Substring(0, 2) Then
                    CSelected1 = True
                End If
                If s = myOptions.CheckProgr.Text.Substring(0, 2) Then
                    CSelected2 = True
                End If
                AddDirToStd(flgs, "D")
            Next
            flgs.tEntry = cDir
            flgs.tInExcl = cExcl
            flgs.tHidDir = True
            flgs.tHidFil = False
            flgs.tIncr = False
            If rc = Windows.Forms.DialogResult.OK Then
                ' beginners mode
                AnalAutoMode = True
            Else 'expert mode
                AnalAutoMode = False
            End If
            If CSelected1 Or CSelected2 Then
                If CSelected1 AndAlso myOptions.CheckWinDir.Checked Then
                    flgs.tName = myOptions.CheckWinDir.Text
                    AddDirToStd(flgs, "D")
                End If
                If CSelected2 AndAlso myOptions.CheckProgr.Checked Then
                    flgs.tName = myOptions.CheckProgr.Text
                    AddDirToStd(flgs, "D")
                End If
            End If
            myExpMode.Show()
            Me.Hide()
        End If
    End Sub
    Private Sub OpenSt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenSt.Click
        Dim files()
        OpenFileDialog1.Title = SysMsg(59)
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = SysMsg(311)
        OpenFileDialog1.CheckFileExists = True
        OpenFileDialog1.Multiselect = False
        OpenFileDialog1.ShowHelp = False
        OpenFileDialog1.ShowDialog()
        files = OpenFileDialog1.FileNames
        If files(0) > "" Then
            OpenNaam = files(0)
            OpenAFile()
        End If
    End Sub
    Private Sub OpenAFile()
        Dim fo As New FileInfo(OpenNaam), s As String, t As New UitEen
        Dim p(99) As String
        Me.Text = SysMsg(51) + " - " + fo.Name
        myExpMode.Std.Nodes.Clear()
        OpenFileDialog1.FileName = OpenNaam
        Try
            Dim st As Stream = File.Open(OpenFileDialog1.FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
            Dim ChkDir As String = ""
            Rdr = New StreamReader(st)
            s = Rdr.ReadLine
            If s Is Nothing Then s = "     10        "
            myOptions.ShutDown.Checked = (s(0) = "Y")
            myOptions.VerCopy.Checked = (s(1) = "Y")
            myOptions.WrLog.Checked = (s(2) = "Y")
            s = s & "           "
            myOptions.ProgSizeN.Text = s.Substring(3, 10)
            If myOptions.ProgSizeN.Text.Trim.Length = 0 Then myOptions.ProgSizeN.Text = "10"
            myOptions.DsnLog.Text = s.Substring(13).Trim
            SelRootDirsDirDest = Rdr.ReadLine.TrimEnd
            Do Until Rdr.Peek = -1
                s = Rdr.ReadLine
                Dim i As Integer
                i = s.IndexOf(" "c)
                Dim n As Integer = CInt(s.Substring(0, i))
                s = s.Substring(i + 1).Trim
                ParseNodeText(s, t)
                p(n) = t.tName
                For ii As Integer = n - 1 To 0 Step -1 ' full path
                    t.tName = p(ii) & "\" & t.tName
                Next
                If t.tEntry = cFil Then
                    AddEntryInStd(t.tName, "F", t)
                    If Not File.Exists(t.tName) Then
                        MessageBox.Show(t.tName + SysMsg(54))
                    End If

                Else
                    AddEntryInStd(t.tName, "D", t)
                    If Not Directory.Exists(t.tName) Then
                        MessageBox.Show(t.tName + SysMsg(54))
                    End If
                End If
            Loop
            Rdr.Close()
            st.Close()
        Catch ex As Exception
            Dim st As String = OpenFileDialog1.FileName
            st = st.Substring(st.LastIndexOf("\"c) + 1)
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Error while processing " + st)
        End Try
        ScriptChanged = False
        AnalAutoMode = False
        Me.Hide()
        myExpMode.Show()
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        OpenNaam = CommandLine
        OpenAFile()
    End Sub
End Class
