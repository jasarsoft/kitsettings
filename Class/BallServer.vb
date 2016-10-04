Public NotInheritable Class BallServer
    Inherits ConfigurationFile

    Private _ballPreview As Boolean

    Private Structure Info
        Public Const fileName As String = "bserv"
        Public Const titleName As String = "Ball Server"
    End Structure

    Private Structure Parameter
        Public Const ballPreview As String = "preview"
    End Structure

    Public Sub New()
        DefaultValue()
    End Sub

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

    Public Property BallPreview As Boolean
        Get
            Return _ballPreview
        End Get
        Set(value As Boolean)
            _ballPreview = value
        End Set
    End Property

    Private Sub DefaultValue()
        _ballPreview = True
    End Sub

    Private Function GenerateData() As String
        Dim dataText As String

        dataText = Parameter.ballPreview & " = " & MyBase.ConvertEnable(_ballPreview).ToString

        Return dataText
    End Function

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
            Dim tmpText As String
            Dim msgText As MessageText = New MessageText()
            Dim msgTitle As MessageTitle = New MessageTitle()

            tmpText = TitleName & msgText.ID11 & Environment.NewLine & msgText.ID00
            MessageBox.Show(tmpText, msgTitle.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

    End Function

    Public Overloads Function ReadFile() As Boolean
        Dim readValue As String

        readValue = ReadFile(FileName, Parameter.ballPreview)

        If IsNumeric(readValue) Then
            _ballPreview = ConvertValue(readValue)
            Return True
        Else
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
        End If

    End Function

End Class
