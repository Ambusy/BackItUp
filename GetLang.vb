Imports System.Globalization
Public Class GetLang
    Private Sub GetLang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ListBox1.Items.Clear()
        Dim s As String = CultureInfo.CurrentCulture.Name.Substring(0, 2).ToUpper
        Dim fnd As Boolean = False
        For Each foundFile As String In My.Computer.FileSystem.GetFiles(My.Application.Info.DirectoryPath, FileIO.SearchOption.SearchAllSubDirectories, "system messages *.txt")
            foundFile = Path.GetFileNameWithoutExtension(foundFile)
            foundFile = foundFile.Substring(foundFile.Length() - 2)
            For Each CultInf As CultureInfo In CultureInfo.GetCultures(CultureTypes.NeutralCultures)
                If CultInf.IetfLanguageTag.Length() > 1 AndAlso CultInf.IetfLanguageTag.Substring(0, 2).ToUpper = foundFile Then
                    ListBox1.Items.Add(foundFile & " " & CultInf.NativeName)
                    If foundFile = s Then
                        Dim fnn, fno As String
                        fnd = True
                        fnn = My.Application.Info.DirectoryPath & "\system messages " & foundFile & ".txt"
                        fno = My.Application.Info.DirectoryPath & "\system messages.txt"
                        My.Computer.FileSystem.CopyFile(fnn, fno)
                    End If
                End If
            Next
        Next
        If fnd Then Me.Close()
    End Sub
    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        Dim fnn, fno As String
        fnn = My.Application.Info.DirectoryPath & "\system messages " & CStr(ListBox1.SelectedItem).Substring(0, 2) & ".txt"
        fno = My.Application.Info.DirectoryPath & "\system messages.txt"
        My.Computer.FileSystem.CopyFile(fnn, fno)
        Me.Close()
    End Sub
End Class