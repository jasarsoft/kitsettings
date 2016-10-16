Imports System.IO

Public Class PesFolder

    Private _folderName As FolderName

    Private Structure FolderName
        Public dirPES As String
        Public dirDat As String
        Public dirSave As String
    End Structure

    Public ReadOnly Property DirPes As String
        Get
            Return _folderName.dirPES
        End Get
    End Property

    Public ReadOnly Property DirDat As String
        Get
            Return _folderName.dirDat
        End Get
    End Property

    Public ReadOnly Property DirSave As String
        Get
            Return _folderName.dirSave
        End Get
    End Property

    Public Sub New()
        Dim myDir = My.Computer.FileSystem.SpecialDirectories.MyDocuments

        _folderName.dirPES = "\.."
        _folderName.dirDat = _folderName.dirPES & "\dat"
        _folderName.dirSave = myDir & "\KONAMI\Pro Evolution Soccer 6\save\folder1"
    End Sub

    Public Function Check(ByVal dirName As String) As Boolean

        If Directory.Exists(dirName) Then
            Return True
        Else
            Call MessageError(dirName)
        End If

        Return False
    End Function

    Private Sub MessageError(ByVal dirName As String)
        Dim msgText As String
        Dim msgTitle As New MessageTitle()

        If dirName = _folderName.dirDat Then
            msgText = "PES Dat"
        Else
            msgText = "PES Save"
        End If

        msgText += " directory do not exist." & Environment.NewLine
        msgText += "Your game may not work properly."

        MessageBox.Show(msgText, msgTitle.TitleWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

End Class
