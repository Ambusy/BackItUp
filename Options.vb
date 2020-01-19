Public Class Options
    Dim initted As Boolean = False
    Private Sub Options_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not initted Then
            initted = True
            Me.Text = SysMsg(261)
            OK_Button.Text = SysMsg(1)
            Cancel_Button.Text = SysMsg(2)
            VerCopy.Text = SysMsg(262)
            ShutDown.Text = SysMsg(263)
            OnlyOnce.Text = SysMsg(264)
            WrLog.Text = SysMsg(265)
            WrLog.Checked = False
            DsnLog.Visible = False
            BrwLog.Visible = False
            ProgrSize.Text = SysMsg(267)
            GroupBox1.Text = SysMsg(268)
            CheckWinDir.Text = My.Application.GetEnvironmentVariable("WinDir")
            CheckWinDir.Checked = True
            CheckProgr.Text = My.Application.GetEnvironmentVariable("ProgramFiles")
            CheckProgr.Checked = True
        End If
        LMsg.Text = ""
    End Sub
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If GeenFouten() Then
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            ScriptChanged = True
            Me.Close()
        End If
    End Sub
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub SelTextBox(ByVal yt As TextBox)
        yt.SelectionStart = 0
        yt.SelectionLength = 99
        yt.Select()
    End Sub
    Private Function GeenFouten() As Boolean
        LMsg.Text = ""
        If WrLog.Checked Then
            If DsnLog.Text.Trim().Length() = 0 Then
                LMsg.Text = SysMsg(266)
                SelTextBox(DsnLog)
                Return False
            ElseIf Not WritableFile(DsnLog.Text.Trim()) Then
                LMsg.Text = SysMsg(266)
                SelTextBox(DsnLog)
                Return False
            End If
        End If
        ProgSizeN.Text = ProgSizeN.Text.Trim
        For i As Integer = 0 To ProgSizeN.Text.Length() - 1
            If ProgSizeN.Text(i) < "0"c OrElse ProgSizeN.Text(i) > "9"c Then
                LMsg.Text = SysMsg(269)
                SelTextBox(ProgSizeN)
                Return False
            End If
        Next
        Return True
    End Function
    Private Sub WrLog_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WrLog.CheckedChanged
        If WrLog.Checked Then
            DsnLog.Visible = True
            BrwLog.Visible = True
        Else
            DsnLog.Visible = False
            BrwLog.Visible = False
        End If
    End Sub

    Private Sub BrwLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BrwLog.Click
        SaveFileDialog1.FileName = ""
        SaveFileDialog1.CheckFileExists = False
        SaveFileDialog1.Title = "Logfile"
        SaveFileDialog1.Filter = "Log files (*.log)|*.log|All files (*.*)|*.*"
        SaveFileDialog1.ShowDialog()
        Dim Filename As String = SaveFileDialog1.FileName
        If Filename = "" Then
            Exit Sub
        End If
        If Not WritableFile(Filename) Then
            Exit Sub
        End If
        DsnLog.Text = Filename
    End Sub
    Private Sub ShutDown_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShutDown.CheckedChanged
        OnlyOnce.Checked = False
        OnlyOnce.Visible = ShutDown.Checked
    End Sub
End Class