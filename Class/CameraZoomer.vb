Imports System.IO

Public NotInheritable Class CameraZoomer
    Inherits ConfigurationFile

    Private _cameraZoom As Integer
    Private _stadiumRoof As Boolean
    Private _stadiumClipping As Boolean

    Private Structure Info
        Public Const fileName As String = "camerazoomer"
        Public Const titleName As String = "Camera Zoomer"
    End Structure

    Private Structure Values
        Public Const min As Integer = 800
        Public Const max As Integer = 1420
    End Structure

    Private Structure Parameter
        Public Const mainSection As String = "[camera]"
        Public Const cameraZoom As String = "zoom"
        Public Const stadiumRoof As String = "add_stadium_roof"
        Public Const stadiumClipping As String = "fix_stadium_clipping"
    End Structure

    
    Public Sub New()
        DefaultValue()
    End Sub

#Region "Info Parameter Property"

    Public Overloads ReadOnly Property FileName As String
        Get
            Return Info.fileName & MyBase.FileName
        End Get
    End Property

    Public Overloads ReadOnly Property TitleName As String
        Get
            Return Info.titleName & MyBase.TitleName
        End Get
    End Property

#End Region

#Region "Main Parameter Property"
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

    Public Property StadiumRoof As Boolean
        Get
            Return _stadiumRoof
        End Get
        Set(value As Boolean)
            _stadiumRoof = value
        End Set
    End Property

    Public Property StadiumClipping As Boolean
        Get
            Return _stadiumClipping
        End Get
        Set(value As Boolean)
            _stadiumClipping = value
        End Set
    End Property
#End Region


#Region "Methods"
    Private Sub DefaultValue()
        _cameraZoom = 1200
        _stadiumRoof = False
        _stadiumClipping = True
    End Sub

    Private Function GenerateData() As String
        Dim dataText As String
        Dim equally As String = " = "

        dataText = Parameter.mainSection & Environment.NewLine
        dataText += Parameter.cameraZoom & equally & _cameraZoom.ToString() & Environment.NewLine
        dataText += Parameter.stadiumRoof & equally & ConvertEnable(_stadiumRoof) & Environment.NewLine
        dataText += Parameter.stadiumClipping & equally & ConvertEnable(_stadiumClipping)

        Return dataText
    End Function

    Private Sub ReadError()
        Dim msgText As String
        Dim msgResult As DialogResult
        Dim msgTitle As MessageTitle = New MessageTitle()

        msgText = TitleName & " contained an invalid parameter." & Environment.NewLine
        msgText += "Do you want to correct the configuration file on" & Environment.NewLine
        msgText += "the current or recommeded settings?"

        msgResult = MessageBox.Show(msgText, msgTitle.TitleWarning, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If msgResult = DialogResult.Yes Then
            CreateFile()
        End If
    End Sub

    Public Overloads Function ExistFile() As Boolean

        If MyBase.ExistFile(FileName, TitleName, GenerateData()) Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Overloads Function DeleteFile() As Boolean

        If MyBase.DeleteFile(FileName, TitleName) Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Overloads Function CreateFile() As Boolean

        If MyBase.CreateFile(FileName, TitleName, GenerateData()) Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Overloads Function WriteFile() As Boolean

        If MyBase.WriteFile(FileName, TitleName, GenerateData()) Then
            Return True
        Else
            Dim msgText As String
            Dim msgTitle As MessageTitle = New MessageTitle()
            Dim msgSubText As MessageText = New MessageText()

            msgText = TitleName & " configuration file can not be written." & Environment.NewLine & msgSubText.ID00
            MessageBox.Show(msgText, msgTitle.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

    End Function

    Public Overloads Function ReadFile() As Boolean
        Dim readValue As String

        readValue = ReadFile(FileName, Parameter.cameraZoom)

        If IsNumeric(readValue) Then
            _cameraZoom = Convert.ToInt32(readValue)
        Else
            ReadError()
            Return False
        End If

        readValue = ReadFile(FileName, Parameter.stadiumRoof)

        If IsNumeric(readValue) Then
            _stadiumRoof = ConvertValue(readValue)
        Else
            ReadError()
            Return False
        End If

        readValue = ReadFile(FileName, Parameter.stadiumClipping)

        If IsNumeric(readValue) Then
            _stadiumClipping = ConvertValue(readValue)
        Else
            ReadError()
            Return False
        End If

        Return True
    End Function
#End Region

End Class
