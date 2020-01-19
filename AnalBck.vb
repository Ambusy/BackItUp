Public Class AnalBck
    Private Sub AnalBck_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        myForm.Show()
        Me.Hide()
        e.Cancel = True ' close gaat niet door
    End Sub
    Private Sub AnalBck_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = SysMsg(71)
        SvBut.Text = SysMsg(74)
        AnBut.Text = SysMsg(72)
        BckBut.Text = SysMsg(73)
        LMsg.Text = ""
        If AnalAutoMode Then
            Timer1.Enabled = True
        End If
    End Sub
    Private Sub AnBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnBut.Click
        myAnal.ShowDialog()
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        myAnal.ShowDialog()
    End Sub
End Class