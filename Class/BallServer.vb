
''' <summary>
''' Kitserver 6 Settings Ball Server Configuration File
''' </summary>
Public NotInheritable Class BallServer
    Inherits ConfigurationFile

#Region "Constatns"
    ''' <summary>
    ''' Ball Server Main Information
    ''' </summary>
    Private Structure Info
        ''' <summary>Ball Server Configuration File Name</summary>
        Public Const fileName As String = "bserv"
        ''' <summary>Ball Server Configuration Title Name</summary>
        Public Const titleName As String = "Ball Server"
    End Structure

    ''' <summary>
    ''' Ball Server Configuration Parameter
    ''' </summary>
    Private Structure Parameter
        ''' <summary>Configuration Parameter Ball Preview</summary>
        Public Const ballPreview As String = "preview"
    End Structure
#End Region

#Region "Variables"
    ''' <summary>Ball Preview Enable</summary>
    Private _ballPreview As Boolean
#End Region

#Region "Properties"
    ''' <summary>
    ''' Ball Server Configuration File Name
    ''' </summary>
    ''' <value>String</value>
    ''' <returns>bserver.cfg</returns>
    Public Overloads ReadOnly Property FileName As String
        Get
            Return Info.fileName & MyBase.FileName
        End Get
    End Property
    ''' <summary>
    ''' Ball Server Configuration Title Name
    ''' </summary>
    ''' <value>String</value>
    ''' <returns>Ball Server configuration file</returns>
    Public Overloads ReadOnly Property TitleName As String
        Get
            Return Info.titleName & MyBase.TitleName
        End Get
    End Property

    ''' <summary>
    ''' Ball Server Configuration Ball Preview Enable
    ''' </summary>
    ''' <value>Boolean</value>
    ''' <returns>_ballPreview</returns>
    Public Property BallPreview As Boolean
        Get
            Return _ballPreview
        End Get
        Set(value As Boolean)
            _ballPreview = value
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
        _ballPreview = True
    End Sub

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
    ''' Generated content with the current configuration parameter values
    ''' </summary>
    ''' <returns>String</returns>
    Private Function GenerateData() As String
        Dim dataText As String

        dataText = Parameter.ballPreview & " = " & MyBase.ConvertEnable(_ballPreview)

        Return dataText
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

        readValue = MyBase.ReadFile(FileName, Parameter.ballPreview)

        If IsNumeric(readValue) Then
            _ballPreview = MyBase.ConvertValue(readValue)
        Else
            Return ReadError()
        End If

        Return True
    End Function
#End Region

End Class
