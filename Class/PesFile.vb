Imports System.IO

Public Class PesFile

    Private mainDir As String
    Private pesFolder As PesFolder

    Private fileName(5) As String

    Public ReadOnly Property AppPES6 As String
        Get
            Return fileName(0)
        End Get
    End Property

    Public ReadOnly Property AppSettings As String
        Get
            Return fileName(1)
        End Get
    End Property

    Public ReadOnly Property ReadmeFile As String
        Get
            Return fileName(2)
        End Get
    End Property

    Public ReadOnly Property OpmovFile As String
        Get
            Return fileName(3)
        End Get
    End Property

    Public ReadOnly Property AfsText As String
        Get
            Return fileName(4)
        End Get
    End Property

    Public ReadOnly Property AfsSound As String
        Get
            Return fileName(5)
        End Get
    End Property

    Public Sub New()
        mainDir = "..\"
        pesFolder = New PesFolder()

        Call GenerateFile()
    End Sub

    Private Sub GenerateFile()
        'PES 6 Application Files
        fileName(0) = mainDir & "PES6.exe"
        fileName(1) = mainDir & "settings.exe"
        'PES 6 Readme file
        fileName(2) = mainDir & "readme.htm"
        'PES 6 Opmov File
        fileName(3) = pesFolder.DirDat & "\opmov"
        'PES 6 Main AFS Files
        fileName(4) = pesFolder.DirDat & "\0_text.afs"
        fileName(5) = pesFolder.DirDat & "\0_sound.afs"
    End Sub

    Public Function Check() As Boolean

        For Each name As String In fileName
            If File.Exists(name) Then
                Dim msgText As String
                Dim msgTitle As New MessageTitle()

                msgText = name.Replace(mainDir, "").Replace(pesFolder.DirDat, "").Replace("\", "")
                msgText += " file does not exist." & Environment.NewLine
                msgText += "Your game may not work properly."

                MessageBox.Show(msgText, msgTitle.TitleWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
        Next

        Return True
    End Function

End Class
