Imports System.Windows.Forms
Public Class SelRootDirs
    Dim cleared As Boolean
    Dim added As Boolean
    Private Sub eind()
        If added Then
            For i As Integer = 0 To ListBox1.Items.Count - 1
                ListBox1.SetSelected(i, True)
            Next
        End If
        ScriptChanged = True
        DirDestName = DirDest.Text
    End Sub
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If GeenFouten() Then
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            eind()
            Me.Close()
        End If
    End Sub
    Private Sub EM_button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EM_button.Click
        If GeenFouten() Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Yes
            eind()
            Me.Close()
        End If
    End Sub
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub ListBox1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.DoubleClick
        If ListBox1.SelectedIndex > -1 Then
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            ScriptChanged = True
            Me.Close()
        End If
    End Sub
    Private Sub SelRootDirs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = SysMsg(151)
        OK_Button.Text = SysMsg(1)
        Cancel_Button.Text = SysMsg(2)
        BR_Button.Text = SysMsg(4)
        EM_button.Text = SysMsg(61)
        LMsg.Text = SysMsg(62)
        LMsg.ForeColor = Color.Black
        DirDest.Text = ""
        DirDestBut.Text = SysMsg(64)
        DirDestLab.Text = SysMsg(65)
        Opt_But.Text = SysMsg(261)
        cleared = False
        added = False
    End Sub
    Private Sub BR_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BR_Button.Click
        If Not cleared Then
            cleared = True
            ListBox1.Items.Clear()
            LMsg.Text = SysMsg(63)
        End If
        FolderBrowserDialog1.Description = SysMsg(154)
        FolderBrowserDialog1.ShowNewFolderButton = False
        FolderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer
        Dim rc As Integer = FolderBrowserDialog1.ShowDialog()
        If rc = 1 Then
            ListBox1.Items.Add(FolderBrowserDialog1.SelectedPath)
            added = True
        End If
    End Sub
    Private Sub Opt_But_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Opt_But.Click
        myOptions.ShowDialog()
    End Sub
    Private Sub DirDestBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DirDestBut.Click
        LMsg.Text = ""
        Me.FolderBrowserDialog1.Description = SysMsg(65)
        Me.FolderBrowserDialog1.ShowNewFolderButton = True
        Me.FolderBrowserDialog1.RootFolder = Environment.SpecialFolder.Desktop
        Dim rc As Integer = FolderBrowserDialog1.ShowDialog()
        If rc = 1 Then
            DirDest.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub
    Private Function GeenFouten() As Boolean
        LMsg.Text = ""
        If Not added AndAlso ListBox1.SelectedItems.Count = 0 Then
            LMsg.Text = SysMsg(68)
        ElseIf added AndAlso ListBox1.Items.Count = 0 Then
            LMsg.Text = SysMsg(68)
        ElseIf DirDest.Text.Trim().Length() = 0 Then
            LMsg.Text = SysMsg(67)
            SelTextBox(DirDest)
        ElseIf Not WritableFile(DirDest.Text.Trim()) Then
            LMsg.Text = SysMsg(67)
            SelTextBox(DirDest)
        End If

        If LMsg.Text.Length() > 0 Then
            LMsg.ForeColor = Color.Red
            Return False
        End If
        LMsg.ForeColor = Color.Black
        Return True
    End Function
    Private Sub ListBox1_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.Click
        LMsg.Text = ""
    End Sub
End Class
