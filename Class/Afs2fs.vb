Public NotInheritable Class Afs2fs
    Inherits ConfigurationFile

#Region "Constants"
    ''' <summary>
    ''' Main constant information
    ''' </summary>
    Private Structure Info
        Public Const fileName As String = "afs2fs"
        Public Const titleName As String = "Afs2fs"
    End Structure

    ''' <summary>
    ''' Parameter constant information
    ''' </summary>
    Private Structure Parameter
        Public Const debugLog As String = "debug"
        Public Const rootFolder As String = "afs.root"
        Public Const lenghtName As String = "filename.length"
    End Structure
#End Region

#Region "Variables"
    ''' <summary>
    ''' Write Debug Log Variable
    ''' </summary>
    Private _debugLog As Boolean

    ''' <summary>
    ''' AFS Root Folder Variable
    ''' </summary>
    Private _rootFolder As String

    ''' <summary>
    ''' File Name Lenght Variable
    ''' </summary>
    Private _lenghtName As UInteger
#End Region

#Region "Properties"
#Region "Afs2fs configuration property info"
    ''' <summary>
    ''' Name of configuration file
    ''' </summary>
    ''' <value>afs2fs.cfg</value>
    ''' <returns>Info.fileName</returns>
    ''' <remarks>Property for only read</remarks>
    Public Overloads ReadOnly Property FileName As String
        Get
            Return Info.fileName & MyBase.FileName
        End Get
    End Property

    ''' <summary>
    ''' Title of configuration file
    ''' </summary>
    ''' <value>Afs2fs configuration file</value>
    ''' <returns>Info.titleName</returns>
    ''' <remarks>Property for only read</remarks>
    Public Overloads ReadOnly Property TitleName As String
        Get
            Return Info.titleName & MyBase.TitleName
        End Get
    End Property
#End Region

#Region "Afs2fs configuration property parameters"
    ''' <summary>
    ''' Property Write Debug Log
    ''' </summary>
    ''' <value>False</value>
    ''' <returns>_debugLog value</returns>
    ''' <remarks>Boolena Property</remarks>
    Public Property DebugLog As Boolean
        Get
            Return _debugLog
        End Get
        Set(value As Boolean)
            _debugLog = value
        End Set
    End Property

    ''' <summary>
    ''' Property AFS Root Folder
    ''' </summary>
    ''' <value>'dat'</value>
    ''' <returns>_rootFolder value</returns>
    ''' <remarks>String Property</remarks>
    Public Property RootFolder As String
        Get
            Return _rootFolder
        End Get
        Set(value As String)
            _rootFolder = value
        End Set
    End Property

    ''' <summary>
    ''' Property File Name Lenght
    ''' </summary>
    ''' <value>64</value>
    ''' <returns>_lenghtName value</returns>
    ''' <remarks>Unsigned Integer Property</remarks>
    Public Property LenghtName As UInteger
        Get
            Return _lenghtName
        End Get
        Set(value As UInteger)
            _lenghtName = value
        End Set
    End Property
#End Region
#End Region

#Region "Constructors"
    ''' <summary>
    ''' Default constructor
    ''' </summary>
    ''' <remarks>Setting parameters of the initial value</remarks>
    Public Sub New()
        DefaultValue()
    End Sub
#End Region

#Region "Methods"
#Region "Private Methods"
    ''' <summary>
    ''' The initial value of the parameter
    ''' </summary>
    Private Sub DefaultValue()
        _debugLog = False
        _rootFolder = "dat"
        _lenghtName = 64
    End Sub

    ''' <summary>
    ''' Generated content with the current configuration parameter values
    ''' </summary>
    ''' <returns>String content</returns>
    ''' <remarks>Always returns content</remarks>
    Private Function GenerateData() As String
        Dim dataText As String

        dataText = Parameter.debugLog & " = " & MyBase.ConvertEnable(_debugLog) & Environment.NewLine
        dataText += Parameter.rootFolder & " = " & _rootFolder & Environment.NewLine
        dataText += Parameter.lenghtName & " = " & _lenghtName.ToString()

        Return dataText
    End Function

    ''' <summary>
    ''' Error message while reading
    ''' </summary>
    ''' <returns>True if the file is correct</returns>
    ''' <remarks>It uses the function to create a new file.</remarks>
    Private Function ReadError() As Boolean
        Dim tmpText As String
        Dim msgResult As DialogResult
        Dim msgText As MessageText = New MessageText()
        Dim msgTitle As MessageTitle = New MessageTitle()

        tmpText = TitleName & msgText.ID10 & Environment.NewLine & msgText.ID01

        msgResult = MessageBox.Show(tmpText, msgTitle.TitleWarning, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If msgResult = DialogResult.Yes Then
            If CreateFile() Then
                Return True
            End If
        End If

        Return False
    End Function
#End Region

#Region "Public Methods"
    ''' <summary>
    ''' Exist Afs2fs configuratoin file
    ''' </summary>
    ''' <returns>True if file exists.</returns>
    ''' <remarks>Sends a message on error</remarks>
    Public Overloads Function ExistFile() As Boolean

        If MyBase.ExistFile(FileName, TitleName, GenerateData()) Then
            Return True
        Else
            Return False
        End If

    End Function

    ''' <summary>
    ''' Delete Afs2fs configuration file
    ''' </summary>
    ''' <returns>True if the file is deleted</returns>
    ''' <remarks>Sends a message on error</remarks>
    Public Overloads Function DeleteFile() As Boolean

        If MyBase.DeleteFile(FileName, TitleName) Then
            Return True
        Else
            Return False
        End If

    End Function

    ''' <summary>
    ''' Create Afs2fs configuration file
    ''' </summary>
    ''' <returns>True if successfully created</returns>
    ''' <remarks>Sends a message on error</remarks>
    Public Overloads Function CreateFile() As Boolean

        If MyBase.CreateFile(FileName, TitleName, GenerateData()) Then
            Return True
        Else
            Return False
        End If

    End Function

    ''' <summary>
    ''' Write Afs2fs configuration file
    ''' </summary>
    ''' <returns>True if successfully completed writing</returns>
    ''' <remarks>Sends a message on error</remarks>
    Public Overloads Function WriteFile() As Boolean

        If MyBase.WriteFile(FileName, TitleName, GenerateData()) Then
            Return True
        Else
            Dim tmpText As String
            Dim msgText As MessageText = New MessageText()
            Dim msgTitle As MessageTitle = New MessageTitle()

            tmpText = TitleName & msgText.ID11 & Environment.NewLine & msgText.ID00
            MessageBox.Show(tmpText, msgTitle.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        Return False
    End Function

    ''' <summary>
    ''' Read Afs2fs configuration file
    ''' </summary>
    ''' <returns>True if successfully read.</returns>
    ''' <remarks>Sends a message on error</remarks>
    Public Overloads Function ReadFile() As Boolean
        Dim readValue As String

        readValue = ReadFile(FileName, Parameter.debugLog)
        If IsNumeric(readValue) Then
            _debugLog = ConvertValue(readValue)
        Else
            Return ReadError()
        End If

        readValue = ReadFile(FileName, Parameter.rootFolder)
        If readValue = Nothing Then
            Return ReadError()
        End If

        readValue = ReadFile(FileName, Parameter.lenghtName)
        If IsNumeric(readValue) Then
            _lenghtName = readValue
        Else
            Return ReadError()
        End If

        Return False
    End Function
#End Region
#End Region
End Class
