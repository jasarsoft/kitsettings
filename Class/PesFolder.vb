Imports System.IO

Public Class PesFolder

    Private myDir As String
    Private folderName(4) As String

    Public ReadOnly Property DirDat As String
        Get
            Return folderName(0)
        End Get
    End Property

    Public ReadOnly Property DirKonami As String
        Get
            Return folderName(1)
        End Get
    End Property

    Public ReadOnly Property DirPes6 As String
        Get
            Return folderName(2)
        End Get
    End Property

    Public ReadOnly Property DirSave As String
        Get
            Return folderName(3)
        End Get
    End Property

    Public ReadOnly Property DirFolder1 As String
        Get
            Return folderName(4)
        End Get
    End Property


    Public Sub New()
        myDir = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\"
        Call GenerateDir()
    End Sub

    Private Sub GenerateDir()
        folderName(0) = "..\dat"
        folderName(1) = myDir & "KONAMI"
        folderName(2) = myDir & "Pro Evolution Soccer 6"
        folderName(3) = myDir & "save"
        folderName(4) = myDir & "folder1"
    End Sub


    Public Function Check() As Boolean

        For Each dirName As String In folderName
            If Not Directory.Exists(dirName) Then
                Dim msgText As String
                Dim msgTitle As New MessageTitle()

                msgText = dirName.Replace("..\", "").Replace(myDir, "")
                msgText += " directory do not exist." & Environment.NewLine
                msgText += "Your game may not work properly."

                MessageBox.Show(msgText, msgTitle.TitleWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
        Next

        Return True
    End Function

End Class
