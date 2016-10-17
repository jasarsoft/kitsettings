Imports System.IO

''' <summary>
''' Pro Evolution Soccer 6 Directory Class
''' </summary>
Public Class PesFolder

#Region "Fields"
    ''' <summary>Local directory filed</summary>
    Private _folderName As FolderName

    ''' <summary>
    ''' Structure fileds directory
    ''' </summary>
    Private Structure FolderName
        Public dirPES As String
        Public dirDat As String
        Public dirSave As String
    End Structure
#End Region

#Region "Properties"
    ''' <summary>
    ''' The name of the main directory with a path
    ''' </summary>
    ''' <value>String</value>
    ''' <returns>\..</returns>
    Public ReadOnly Property DirPes As String
        Get
            Return _folderName.dirPES
        End Get
    End Property

    ''' <summary>
    ''' Directory path of Dat folder
    ''' </summary>
    ''' <value>String</value>
    ''' <returns>(PES6)\dat</returns>
    Public ReadOnly Property DirDat As String
        Get
            Return _folderName.dirDat
        End Get
    End Property

    ''' <summary>
    ''' Directory path of the Option File
    ''' </summary>
    ''' <value>String</value>
    ''' <returns>(MyDocument)\KONAMI\Pro Evolution Soccer 6\save\folder1</returns>
    Public ReadOnly Property DirSave As String
        Get
            Return _folderName.dirSave
        End Get
    End Property
#End Region

#Region "Constructor"
    ''' <summary>
    ''' Default initialization constructor
    ''' </summary>
    Public Sub New()
        Dim myDir = My.Computer.FileSystem.SpecialDirectories.MyDocuments

        _folderName.dirPES = "\.."
        _folderName.dirDat = _folderName.dirPES & "\dat"
        _folderName.dirSave = myDir & "\KONAMI\Pro Evolution Soccer 6\save\folder1"
    End Sub
#End Region

#Region "Methods"
    ''' <summary>
    ''' Checking for a specified directory
    ''' </summary>
    ''' <param name="dirName"></param>
    ''' <returns>Boolean</returns>
    ''' <remarks>Sends a message if the directory does not exist</remarks>
    Public Function Check(ByVal dirName As String) As Boolean

        If Directory.Exists(dirName) Then
            Return True
        Else
            Call MessageError(dirName)
        End If

        Return False
    End Function

    ''' <summary>
    ''' Display error message
    ''' </summary>
    ''' <param name="dirName"></param>
    Private Sub MessageError(ByVal dirName As String)
        Dim msgText As String
        Dim msgTitle As New MessageTitle()

        If dirName = _folderName.dirDat Then
            msgText = "PES6 Dat"
        Else
            msgText = "PES6 Save"
        End If

        msgText += " directory do not exist." & Environment.NewLine
        msgText += "Your game may not work properly."

        MessageBox.Show(msgText, msgTitle.TitleWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub
#End Region

End Class
