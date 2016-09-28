Imports System.IO

Public NotInheritable Class CameraZoomer
    Inherits ConfigurationFile

    Private Const maxValue As Integer = 1420
    Private Const minValue As Integer = 800

    Private Const _fileName As String = "camerazoomer"
    Private Const _titleName As String = "Camera Zoomer"

    Private Structure ParameterCFG
        Public Const mainSection As String = "[camera]"
        Public Const cameraZoom As String = "zoom"
        Public Const stadiumRoof As String = "add_stadium_roof"
        Public Const stadiumClipping As String = "fix_stadium_clipping"
    End Structure

    Private _cameraZoom As Integer
    Private _stadiumRoof As Boolean
    Private _stadiumClipping As Boolean

    Public Sub New()
        DefaultValue()
    End Sub

#Region "Info Parameter Property"
    Public ReadOnly Property FileName As String
        Get
            Return _fileName & MyBase.ExtensionCFG
        End Get
    End Property

    Public ReadOnly Property TitleName As String
        Get
            Return _titleName & MyBase.SubTitleCFG
        End Get
    End Property
#End Region

#Region "Main Parameter Property"
    Public Property CameraZoomValue As Integer
        Get
            Return _cameraZoom
        End Get
        Set(value As Integer)
            If value > maxValue Then
                _cameraZoom = maxValue
            ElseIf value < minValue Then
                _cameraZoom = minValue
            Else
                _cameraZoom = value
            End If
        End Set
    End Property

    Public Property StadiumRoofEnable As Boolean
        Get
            Return _stadiumRoof
        End Get
        Set(value As Boolean)
            _stadiumRoof = value
        End Set
    End Property

    Public Property StadiumClippingEnable As Boolean
        Get
            Return _stadiumClipping
        End Get
        Set(value As Boolean)
            _stadiumClipping = value
        End Set
    End Property
#End Region

#Region "CFG Parameter Property"
    Public ReadOnly Property CameraZoomParam As String
        Get
            Return ParameterCFG.cameraZoom
        End Get
    End Property

    Public ReadOnly Property StadiumRoofParam As String
        Get
            Return ParameterCFG.stadiumRoof
        End Get
    End Property

    Public ReadOnly Property StadiumClippingParam As String
        Get
            Return ParameterCFG.stadiumClipping
        End Get
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

        dataText = ParameterCFG.mainSection & Environment.NewLine
        dataText += CameraZoomParam & MyBase.OperatorCFG & Me.CameraZoomValue & Environment.NewLine
        dataText += StadiumRoofParam & MyBase.OperatorCFG & MyBase.ConvertEnable(StadiumRoofEnable).ToString & Environment.NewLine
        dataText += StadiumClippingParam & MyBase.OperatorCFG & MyBase.ConvertEnable(StadiumClippingEnable).ToString

        Return dataText
    End Function

    Private Function ReadError() As Boolean
        Dim msgResult As DialogResult
        Dim msgTitle As MessageTitle = New MessageTitle()
        Dim msgText As MessageText.CfgFile = New MessageText.CfgFile()

        msgResult = MessageBox.Show(Me.TitleName & msgText.ErrorRead, msgTitle.TitleWarning, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        DefaultValue()

        If msgResult = DialogResult.Yes Then
            If Me.CreateFile() Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Function ExistFile() As Boolean

        If MyBase.ExistCFG(Me.FileName) Then
            Return True
        Else
            Dim msgReasult As DialogResult
            Dim msgTitle As MessageTitle = New MessageTitle()
            Dim msgText As MessageText.CfgFile = New MessageText.CfgFile()

            msgReasult = MessageBox.Show(Me.TitleName & msgText.ErrorExist, msgTitle.TitleWarning, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If msgReasult = DialogResult.Yes Then
                If Me.CreateFile() Then
                    Return True
                Else
                    Return False
                End If
            End If
        End If

        Return False
    End Function

    Public Function DeleteFile() As Boolean

        If MyBase.ExistCFG(Me.FileName) Then
            If MyBase.DeleteCFG(Me.FileName) Then
                Return True
            Else
                Dim msgTitle As MessageTitle = New MessageTitle()
                Dim msgText As MessageText.CfgFile = New MessageText.CfgFile()

                MessageBox.Show(Me.TitleName & msgText.ErrorDelete, msgTitle.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        Else
            Return True
        End If

    End Function

    Public Function CreateFile()

        Dim msgTitle As MessageTitle = New MessageTitle()
        Dim msgText As MessageText.CfgFile = New MessageText.CfgFile()

        If WriteCFG(Me.FileName, Me.TitleName, Me.GenerateData()) Then
            MessageBox.Show(Me.TitleName & msgText.InfoCreate, msgTitle.TitleInfo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return True
        Else
            MessageBox.Show(Me.TitleName & msgText.ErrorWrite, msgTitle.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        
    End Function

    Public Function WriteFile() As Boolean

        If WriteCFG(Me.FileName, Me.TitleName, Me.GenerateData()) Then
            Return True
        Else
            Dim msgTitle As MessageTitle = New MessageTitle()
            Dim msgText As MessageText.CfgFile = New MessageText.CfgFile()

            MessageBox.Show(Me.TitleName & msgText.ErrorWrite, msgTitle.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False
        End If
    End Function

    Public Function ReadFile() As Boolean
        Dim readValue As String

        readValue = MyBase.ReadCFG(Me.FileName, Me.CameraZoomParam)

        If IsNumeric(readValue) Then
            Me._cameraZoom = Convert.ToInt32(readValue)
        Else
            Me.ReadError()
            Return False
        End If

        readValue = MyBase.ReadCFG(FileName, StadiumRoofParam)

        If IsNumeric(readValue) Then
            Me._stadiumRoof = MyBase.ConvertValue(readValue)
        Else
            Me.ReadError()
            Return False
        End If

        readValue = MyBase.ReadCFG(FileName, StadiumClippingParam)

        If IsNumeric(readValue) Then
            Me._stadiumClipping = MyBase.ConvertValue(readValue)
        Else
            Me.ReadError()
            Return False
        End If

        Return True
    End Function
#End Region

End Class
