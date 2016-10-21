
''' <summary>
''' Kitserver 6 Settings Speeder Module Configuration File
''' </summary>
Public NotInheritable Class Speeder
    Inherits ConfigurationFile

    ''' <summary>
    ''' Speeder Module Main Information
    ''' </summary>
    Private Structure Info
        ''' <summary>Speeder Module Configuration File Name</summary>
        Public Const fileName As String = "speeder"
        ''' <summary>Speeder Module Configuration Title Name</summary>
        Public Const titleName As String = "Speeder Module"
    End Structure

    ''' <summary>
    ''' Speeder Module Configuration Parameter
    ''' </summary>
    Private Structure Parameter
        ''' <summary>Configuration Parameter Count Factor Speed Value</summary>
        Public Const countFactor As String = "count.factor"
    End Structure

#Region "Variables"
    ''' <summary>Count Factor Speed Value</summary>
    Private _countFactor As Double
#End Region

#Region "Properties"
    ''' <summary>
    ''' Speeder Module Configuration File Name
    ''' </summary>
    ''' <value>String</value>
    ''' <returns>speeder.cfg</returns>
    Public Overloads ReadOnly Property Name As String
        Get
            Return Info.fileName & MyBase.Name
        End Get
    End Property
    ''' <summary>
    ''' Speeder Module Configuration Title Name
    ''' </summary>
    ''' <value>String</value>
    ''' <returns>Speeder Module configuration file</returns>
    Public Overloads ReadOnly Property TitleName As String
        Get
            Return Info.titleName & MyBase.Title
        End Get
    End Property

    ''' <summary>
    ''' Speeder Module Configuration Count Factor Speed Value
    ''' </summary>
    ''' <value>Double</value>
    ''' <returns>_countFactor</returns>
    Public Property CountFactor As Double
        Get
            Return _countFactor
        End Get
        Set(value As Double)
            _countFactor = value
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
        _countFactor = 0.94
    End Sub

    ''' <summary>
    ''' Generated content with the current configuration parameter values
    ''' </summary>
    ''' <returns>String</returns>
    Private Function GenerateData() As String
        Dim dataText As String
        Dim equally As String = " = "
        Dim speedValue As String = _countFactor.ToString().Replace(",", ".")

        dataText = Parameter.countFactor & equally & speedValue

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
    Public Overloads Function Check() As Boolean

        If MyBase.Check(Name, TitleName, GenerateData()) Then
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

        If MyBase.DeleteFile(Name, TitleName) Then
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

        If MyBase.CreateFile(Name, TitleName, GenerateData()) Then
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

        If MyBase.WriteFile(Name, TitleName, GenerateData()) Then
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

        readValue = MyBase.ReadFile(Name, Parameter.countFactor)

        If IsNumeric(readValue) And readValue.Contains(".") Then
            _countFactor = CType(readValue.Replace(".", ","), Double)
        Else
            Return ReadError()
        End If

        Return True
    End Function

#End Region

End Class
