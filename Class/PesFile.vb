Imports System.IO

Public Class PesFile

    Private _appFile As AppFile
    Private _helpFile As HelpFile
    Private _afsFile(14) As String

    Private pesFolder As PesFolder


    Private Structure AppFile
        Public pes6 As String
        Public settings As String
    End Structure

    Private Structure HelpFile
        Public readme As String
    End Structure

    Public ReadOnly Property AppPES6 As String
        Get
            Return _appFile.pes6
        End Get
    End Property

    Public ReadOnly Property AppSettings As String
        Get
            Return _appFile.settings
        End Get
    End Property

    Public ReadOnly Property ReadmeFile As String
        Get
            Return _helpFile.readme
        End Get
    End Property

    Public Sub New()
        pesFolder = New PesFolder()

        _appFile.pes6 = pesFolder.DirPes & "\PES6.exe"
        _appFile.settings = pesFolder.DirPes & "\settings.exe"

        _helpFile.readme = pesFolder.DirPes & "\readme.htm"

        Call GenerateAfs()
    End Sub

    Private Sub GenerateAfs()
        'PES 6 Opmov File
        _afsFile(0) = pesFolder.DirDat & "\opmov"
        'PES 6 Main AFS Files
        _afsFile(1) = pesFolder.DirDat & "\0_text.afs"
        _afsFile(2) = pesFolder.DirDat & "\0_sound.afs"
        'PES 6 English AFS Files
        _afsFile(3) = pesFolder.DirDat & "\e_text.afs"
        _afsFile(4) = pesFolder.DirDat & "\e_sound.afs"
        'PES 6 French AFS Files
        _afsFile(5) = pesFolder.DirDat & "\f_text.afs"
        _afsFile(6) = pesFolder.DirDat & "\f_sound.afs"
        'PES 6 German AFS Files
        _afsFile(7) = pesFolder.DirDat & "\g_text.afs"
        _afsFile(8) = pesFolder.DirDat & "\g_sound.afs"
        'PES 6 Italian AFS Files
        _afsFile(9) = pesFolder.DirDat & "\i_text.afs"
        _afsFile(10) = pesFolder.DirDat & "\i_sound.afs"
        'PES 6 Polish AFS Files
        _afsFile(11) = pesFolder.DirDat & "\p_text.afs"
        _afsFile(12) = pesFolder.DirDat & "\p_sound.afs"
        'PES 6 Spanish AFS Files
        _afsFile(13) = pesFolder.DirDat & "\s_text.afs"
        _afsFile(14) = pesFolder.DirDat & "\s_sound.afs"
    End Sub

    Public Function Check(ByVal fileName As String) As Boolean

        If File.Exists(fileName) Then
            Return True
        Else
            Call MessageError(fileName)
        End If

        Return False
    End Function


    Public Function CheckAfs() As Boolean
        Dim pesRegistry As New PesRegistry()

        If pesRegistry.Read() Then
            For i As Integer = 0 To 14
                If i = 3 Or i = 4 And Not pesRegistry.LangEnglish Then
                    Continue For
                ElseIf i = 5 Or i = 6 And Not pesRegistry.LangFrench Then
                    Continue For
                ElseIf i = 7 Or i = 8 And Not pesRegistry.LangGerman Then
                    Continue For
                ElseIf i = 9 Or i = 10 And Not pesRegistry.LangItalian Then
                    Continue For
                ElseIf i = 11 Or i = 12 And Not pesRegistry.LangPolish Then
                    Continue For
                ElseIf i = 13 Or i = 14 And Not pesRegistry.LangSpanish Then
                    Continue For
                End If

                If Not File.Exists(_afsFile(i)) Then
                    Call MessageError(_afsFile(i))
                    Return False
                End If
            Next
        End If

        Return True
    End Function

    Private Sub MessageError(ByVal fileName As String)
        Dim msgText As String
        Dim msgTitle As New MessageTitle()

        msgText = "Warning, '" & fileName.Replace(pesFolder.DirPes, "").Replace(pesFolder.DirDat, "").Replace("\", "")
        msgText += "' file does not exist." & Environment.NewLine
        msgText += "Your game is not complete and may not work properly."

        MessageBox.Show(msgText, msgTitle.TitleWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

End Class
