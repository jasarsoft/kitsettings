Public NotInheritable Class MessageTitle

    Private appTitle As String
    Private _titleInfo As String
    Private _titleError As String
    Private _titleWarning As String

    Public Sub New()

        Dim app As Application = New Application()
        appTitle = app.Title

        _titleInfo = appTitle & " | Info"
        _titleError = appTitle & " | Error"
        _titleWarning = appTitle & " | Warning"
    End Sub

    Public ReadOnly Property TitleInfo
        Get
            Return _titleInfo
        End Get
    End Property

    Public ReadOnly Property TitleError
        Get
            Return _titleError
        End Get
    End Property

    Public ReadOnly Property TitleWarning
        Get
            Return _titleWarning
        End Get
    End Property

End Class
