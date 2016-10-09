
''' <summary>
''' Kitserver 6 Settings Boot Server Configuration File
''' </summary>
Public NotInheritable Class BootServer
    Inherits ConfigurationFile

    ''' <summary>
    ''' Boot Server Main Information
    ''' </summary>
    Private Structure Info
        ''' <summary>Boot Server Configuration File Name</summary>
        Public Const fileName As String = "bootserv"
        ''' <summary>Boot Server Configuration Title Name</summary>
        Public Const titleName As String = "Boot Server"
    End Structure

    ''' <summary>
    ''' Boot Server Configuration Parameter
    ''' </summary>
    Private Structure Parameter
        ''' <summary>Configuration Parameter Random Boots Enable</summary>
        Public Const randomBoots As String = "random-boots.enabled"
        ''' <summary>Configuration Parameter Other Version Boots Enable</summary>
        Public Const versionBoots As String = "otherVersion"
    End Structure

#Region "Variables"
    ''' <summary>Random Boots Enable</summary>
    Private _randomBoots As Boolean
    ''' <summary>Other Version Boots Enable</summary>
    Private _versionBoots As Boolean
#End Region

#Region "Properties"
    ''' <summary>
    ''' Boot Server Configuration File Name
    ''' </summary>
    ''' <value>String</value>
    ''' <returns>bootserv.cfg</returns>
    Public Overloads ReadOnly Property FileName As String
        Get
            Return Info.fileName & MyBase.FileName
        End Get
    End Property
    ''' <summary>
    ''' Boot Server Configuration Title Name
    ''' </summary>
    ''' <value>String</value>
    ''' <returns>Boot Server configuration file</returns>
    Public Overloads ReadOnly Property TitleName As String
        Get
            Return Info.titleName & MyBase.TitleName
        End Get
    End Property

    ''' <summary>
    ''' Boot Server Configuration Random Boots Enable
    ''' </summary>
    ''' <value>Boolean</value>
    ''' <returns>_randomBoots</returns>
    Public Property RandomBoots As Boolean
        Get
            Return _randomBoots
        End Get
        Set(value As Boolean)
            _randomBoots = value
        End Set
    End Property
    ''' <summary>
    ''' Boot Server Configuration Other Version Boots
    ''' </summary>
    ''' <value>Boolean</value>
    ''' <returns>_versionBoots</returns>
    Public Property VersionBoots As Boolean
        Get
            Return _versionBoots
        End Get
        Set(value As Boolean)
            _versionBoots = value
        End Set
    End Property
#End Region

#Region "Constructors"
    ''' <summary>
    ''' Default Main Constructor
    ''' </summary>
    ''' <remarks>Setting initial values for private variables</remarks>
    Public Sub New()
        DefaultValue()
    End Sub
#End Region

#Region "Methods"
    ''' <summary>
    ''' Setting the initial configuration values
    ''' </summary>
    Private Sub DefaultValue()
        _randomBoots = False
        _versionBoots = False
    End Sub

    ''' <summary>
    ''' Generated content with the current configuration parameter values
    ''' </summary>
    ''' <returns>String</returns>
    Private Function GenerateData() As String
        Dim dataText As String
        Dim equally As String = " = "

        dataText = Parameter.randomBoots & equally & MyBase.ConvertEnable(_randomBoots) & Environment.NewLine
        dataText += Parameter.versionBoots & equally & MyBase.ConvertEnable(_versionBoots)

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

        tmpText = TitleName & msgText.ID10 & Environment.NewLine & msgText.ID01

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
    Public Overloads Function ExistFile() As Boolean

        If MyBase.ExistFile(FileName, TitleName, GenerateData()) Then
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

        If MyBase.DeleteFile(FileName, TitleName) Then
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

        If MyBase.CreateFile(FileName, TitleName, GenerateData()) Then
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

        If MyBase.WriteFile(FileName, TitleName, GenerateData()) Then
            Return True
        Else
            Dim tmpText As String
            Dim msgText As MessageText = New MessageText()
            Dim msgTitle As MessageTitle = New MessageTitle()

            tmpText = TitleName & msgText.ID11 & Environment.NewLine & msgText.ID00
            MessageBox.Show(tmpText, msgTitle.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

    End Function

    ''' <summary>
    ''' The function reads the values from the configuration file
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks>The function gives a message in error</remarks>
    Public Overloads Function ReadFile() As Boolean
        Dim readValue As String

        readValue = MyBase.ReadFile(FileName, Parameter.randomBoots)

        If IsNumeric(readValue) Then
            _randomBoots = MyBase.ConvertValue(readValue)
        Else
            If ReadError() Then
                Return True
            Else
                Return False
            End If
        End If

        readValue = MyBase.ReadFile(FileName, Parameter.versionBoots)

        If IsNumeric(readValue) Then
            _versionBoots = MyBase.ConvertValue(readValue)
        Else
            Return ReadError()
        End If

        Return True
    End Function

#End Region

End Class
