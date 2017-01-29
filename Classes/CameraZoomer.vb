Namespace Classes
    ''' <summary>
    ''' Kitserver 6 Settings Camera Zoomer Configuration File
    ''' </summary>
    Public NotInheritable Class CameraZoomer
        Inherits ConfigurationFile

#Region "Constants"
        ''' <summary>
        ''' Camera Zoomer Main Information
        ''' </summary>
        Private Structure Info
            ''' <summary>Camera Zoomer Configuration File Name</summary>
            Public Const fileName As String = "camerazoomer"
            ''' <summary>Camera Zoomer Configuration Title Name</summary>
            Public Const titleName As String = "Camera Zoomer"
        End Structure

        ''' <summary>
        ''' Camera Zoom Min/Max Values
        ''' </summary>
        Private Structure Values
            ''' <summary>Minimal Zoom Value</summary>
            Public Const min As Integer = 800
            ''' <summary>Maximal Zoom Value</summary>
            Public Const max As Integer = 1420
        End Structure

        ''' <summary>
        ''' Camera Zoomer Configuration Parameter
        ''' </summary>
        Private Structure Parameter
            ''' <summary>Configuration Parameter Main Section</summary>
            Public Const mainSection As String = "[camera]"
            ''' <summary>Configuration Parameter Camera Zoom</summary>
            Public Const cameraZoom As String = "zoom"
            ''' <summary>Configuration Parameter Add Stadium Roof</summary>
            Public Const stadiumRoof As String = "add_stadium_roof"
            ''' <summary>Configuration Parameter Fix Stadium Clipping</summary>
            Public Const stadiumClipping As String = "fix_stadium_clipping"
        End Structure
#End Region

#Region "Variables"
        ''' <summary>Camera Zoom Value</summary>
        Private _cameraZoom As Integer
        ''' <summary>Add Stadium Roof (Enable)</summary>
        Private _stadiumRoof As Boolean
        ''' <summary>Fix Stadium Clipping (Enable)</summary>
        Private _stadiumClipping As Boolean
#End Region

#Region "Properties"
        ''' <summary>
        ''' Camera Zoomer Configuration File Name
        ''' </summary>
        ''' <value>String</value>
        ''' <returns>camerazoomer.cfg</returns>
        Public Overloads ReadOnly Property Name As String
            Get
                Return Info.fileName & MyBase.Name
            End Get
        End Property
        ''' <summary>
        ''' Camera Zoomer Configuration Title Name
        ''' </summary>
        ''' <value>String</value>
        ''' <returns>Camera Zoomer configuration file</returns>
        Public Overloads ReadOnly Property Title As String
            Get
                Return Info.titleName & MyBase.Title
            End Get
        End Property

        ''' <summary>
        ''' Camera Zoomer Configuration Zoom Value
        ''' </summary>
        ''' <value>Integer</value>
        ''' <returns>_cameraZoom</returns>
        Public Property CameraZoom As Integer
            Get
                Return _cameraZoom
            End Get
            Set(value As Integer)
                If value > Values.max Then
                    _cameraZoom = Values.max
                ElseIf value < Values.min Then
                    _cameraZoom = Values.min
                Else
                    _cameraZoom = value
                End If
            End Set
        End Property
        ''' <summary>
        ''' Camera Zoomer Configuration Add Stadium Roof (Enable)
        ''' </summary>
        ''' <value>Boolean</value>
        ''' <returns>_stadiumRoof</returns>
        Public Property StadiumRoof As Boolean
            Get
                Return _stadiumRoof
            End Get
            Set(value As Boolean)
                _stadiumRoof = value
            End Set
        End Property
        ''' <summary>
        ''' Camera Zoomer Configuration Fix Stadium Clipping (Enable)
        ''' </summary>
        ''' <value>Boolean</value>
        ''' <returns>_stadiumClipping</returns>
        Public Property StadiumClipping As Boolean
            Get
                Return _stadiumClipping
            End Get
            Set(value As Boolean)
                _stadiumClipping = value
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
            _cameraZoom = 1200
            _stadiumRoof = False
            _stadiumClipping = True
        End Sub

        ''' <summary>
        ''' Generated content with the current configuration parameter values
        ''' </summary>
        ''' <returns>String</returns>
        Private Function GenerateData() As String
            Dim dataText As String
            Dim equally As String = " = "

            dataText = Parameter.mainSection & Environment.NewLine
            dataText += Parameter.cameraZoom & equally & _cameraZoom.ToString() & Environment.NewLine
            dataText += Parameter.stadiumRoof & equally & ConvertEnable(_stadiumRoof) & Environment.NewLine
            dataText += Parameter.stadiumClipping & equally & ConvertEnable(_stadiumClipping)

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

            readValue = MyBase.ReadFile(Name, Parameter.cameraZoom)

            If IsNumeric(readValue) Then
                CameraZoom = CType(readValue, Integer)
            Else
                Return ReadError()
            End If

            readValue = MyBase.ReadFile(Name, Parameter.stadiumRoof)

            If IsNumeric(readValue) Then
                StadiumRoof = MyBase.ConvertValue(readValue)
            Else
                Return ReadError()
            End If

            readValue = MyBase.ReadFile(Name, Parameter.stadiumClipping)

            If IsNumeric(readValue) Then
                StadiumClipping = MyBase.ConvertValue(readValue)
            Else
                Return ReadError()
            End If

            Return True
        End Function
#End Region

    End Class
End Namespace