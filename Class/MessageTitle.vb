Public NotInheritable Class MessageTitle

    Private Structure Title
        Private Const appTitle As String = "Kitserver 6 Settings"
        Public Const titleInfo As String = appTitle & " | Information"
        Public Const titleError As String = appTitle & " | Error"
        Public Const titleWarning As String = appTitle & " | Warning"
    End Structure

    Public ReadOnly Property TitleInfo
        Get
            Return Title.titleInfo
        End Get
    End Property

    Public ReadOnly Property TitleError
        Get
            Return Title.titleError
        End Get
    End Property

    Public ReadOnly Property TitleWarning
        Get
            Return Title.titleWarning
        End Get
    End Property

End Class
