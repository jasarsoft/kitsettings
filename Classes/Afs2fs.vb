Namespace Classes
    ''' <summary>
    ''' Kitserver 6 Settings Afs2fs Module Configuration File
    ''' </summary>
    Public NotInheritable Class Afs2fs
        Inherits ConfigurationFile

#Region "Constants"
        ''' <summary>
        ''' Afs2fs Module Main Information
        ''' </summary>
        Private Structure Info
            ''' <summary>Afs2fs Module Configuration File Name</summary>
            Public Const fileName As String = "afs2fs"
            ''' <summary>Afs2fs Module Configuration Title Name</summary>
            Public Const titleName As String = "Afs2fs Module"
        End Structure

        ''' <summary>
        ''' Afs2fs Module Configuration Paramter
        ''' </summary>
        Private Structure Parameter
            ''' <summary>Configuration Parameter Write Debug Log</summary>
            Public Const debugMode As String = "debug"
            ''' <summary>Configuration Parameter AFS Root Directory</summary>
            Public Const rootFolder As String = "afs.root"
            ''' <summary>Configuration Prameter File Name Lenght</summary>
            Public Const lenghtName As String = "filename.length"
        End Structure
#End Region

#Region "Variables"
        ''' <summary>Write Debug Log (Mode Enable)</summary>
        Private _debugMode As Boolean
        ''' <summary>AFS Root Directory Name</summary>
        Private _rootFolder As String
        ''' <summary>File Name Lenght Value</summary>
        Private _lenghtName As UInteger
#End Region

#Region "Properties"
        ''' <summary>
        ''' Afs2fs Module Configuration File Name
        ''' </summary>
        ''' <value>String</value>
        ''' <returns>afs2fs.cfg</returns>
        Public Overloads ReadOnly Property Name As String
            Get
                Return Info.fileName & MyBase.Name
            End Get
        End Property

        ''' <summary>
        ''' Afs2fs Module Configuration Title Name
        ''' </summary>
        ''' <value>String</value>
        ''' <returns>Afs2fs Module configuration file</returns>
        Public Overloads ReadOnly Property Title As String
            Get
                Return Info.titleName & MyBase.Title
            End Get
        End Property


        ''' <summary>
        ''' Afs2fs Module Configuration Write Debug Log (Mode Enable)
        ''' </summary>
        ''' <value>Boolean</value>
        ''' <returns>_debugMode</returns>
        Public Property DebugMode As Boolean
            Get
                Return _debugMode
            End Get
            Set(value As Boolean)
                _debugMode = value
            End Set
        End Property

        ''' <summary>
        ''' Afs2fs Module Configuration AFS Root Directory Name
        ''' </summary>
        ''' <value>String</value>
        ''' <returns>_rootFolder</returns>
        Public Property RootFolder As String
            Get
                Return _rootFolder
            End Get
            Set(value As String)
                _rootFolder = value
            End Set
        End Property

        ''' <summary>
        ''' Afs2fs Module Configuration File Name Lenght Value
        ''' </summary>
        ''' <value>Unsigned Integer</value>
        ''' <returns>_lenghtName</returns>
        Public Property LenghtName As UInteger
            Get
                Return _lenghtName
            End Get
            Set(value As UInteger)
                _lenghtName = value
            End Set
        End Property
#End Region

#Region "Constructors"
        ''' <summary>
        ''' Default Main Constructor
        ''' </summary>
        ''' <remarks>Setting parameters of the initial value</remarks>
        Public Sub New()
            DefaultValue()
        End Sub
#End Region

#Region "Methods"
        ''' <summary>
        ''' Setting the initial configuration values
        ''' </summary>
        Private Sub DefaultValue()
            _debugMode = False
            _rootFolder = "dat"
            _lenghtName = 64
        End Sub

        ''' <summary>
        ''' Generated content with the current configuration parameter values
        ''' </summary>
        ''' <returns>String</returns>
        Private Function GenerateData() As String
            Dim dataText As String
            Dim equally As String = " = "

            dataText = Parameter.debugMode & equally & MyBase.ConvertEnable(_debugMode) & Environment.NewLine
            dataText += Parameter.rootFolder & equally & ControlChars.Quote & _rootFolder & ControlChars.Quote & Environment.NewLine
            dataText += Parameter.lenghtName & equally & _lenghtName.ToString()

            Return dataText
        End Function

        ''' <summary>
        ''' The function shows the error message to read
        ''' </summary>
        ''' <returns>Boolean</returns>
        ''' <remarks>The function returns true if the parameter is corrected</remarks>
        Private Function ReadError() As Boolean
            Dim tmpText As String
            Dim msgResult As DialogResult
            Dim msgText As MessageText = New MessageText()
            Dim msgTitle As MessageTitle = New MessageTitle()

            tmpText = Title & msgText.ID10 & Environment.NewLine & msgText.ID01

            msgResult = MessageBox.Show(tmpText, msgTitle.TitleWarning, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If msgResult = DialogResult.Yes Then
                If CreateFile() Then
                    Return True
                End If
            End If

            Return False
        End Function

        ''' <summary>
        ''' The function checks the existence of a configuration file
        ''' </summary>
        ''' <returns>Boolean</returns>
        ''' <remarks>The function gives a message in error</remarks>
        Public Overloads Function Check() As Boolean

            If MyBase.Check(Name, Title, GenerateData()) Then
                Return True
            Else
                Return False
            End If

        End Function

        ''' <summary>
        ''' The function deletes a configuration file
        ''' </summary>
        ''' <returns>Boolean</returns>
        ''' <remarks>The function gives a message in error</remarks>
        Public Overloads Function DeleteFile() As Boolean

            If MyBase.DeleteFile(Name, Title) Then
                Return True
            Else
                Return False
            End If

        End Function

        ''' <summary>
        ''' The function creates a new configuration file
        ''' </summary>
        ''' <returns>Boolean</returns>
        ''' <remarks>The function gives a message in error</remarks>
        Public Overloads Function CreateFile() As Boolean

            If MyBase.CreateFile(Name, Title, GenerateData()) Then
                Return True
            Else
                Return False
            End If

        End Function

        ''' <summary>
        ''' The function writes values in the configuration file
        ''' </summary>
        ''' <returns>Boolean</returns>
        ''' <remarks>The function gives a message in error</remarks>
        Public Overloads Function WriteFile() As Boolean

            If MyBase.WriteFile(Name, Title, GenerateData()) Then
                Return True
            Else
                Dim tmpText As String
                Dim msgText As MessageText = New MessageText()
                Dim msgTitle As MessageTitle = New MessageTitle()

                tmpText = Title & msgText.ID11 & Environment.NewLine & msgText.ID00
                MessageBox.Show(tmpText, msgTitle.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            Return False
        End Function

        ''' <summary>
        ''' The function reads the values from the configuration file
        ''' </summary>
        ''' <returns>Boolean</returns>
        ''' <remarks>The function gives a message in error</remarks>
        Public Overloads Function ReadFile() As Boolean
            Dim readValue As String

            readValue = MyBase.ReadFile(Name, Parameter.debugMode)
            If IsNumeric(readValue) Then
                _debugMode = MyBase.ConvertValue(readValue)
            Else
                Return ReadError()
            End If

            readValue = MyBase.ReadFile(Name, Parameter.rootFolder)
            If readValue = Nothing Then
                Return ReadError()
            End If

            readValue = MyBase.ReadFile(Name, Parameter.lenghtName)
            If IsNumeric(readValue) Then
                _lenghtName = readValue
            Else
                Return ReadError()
            End If

            Return False
        End Function
#End Region

    End Class
End Namespace