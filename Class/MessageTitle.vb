
''' <summary>
''' Class title for message
''' </summary>
Public NotInheritable Class MessageTitle

#Region "Filed"
    ''' <summary>
    ''' Constants title
    ''' </summary>
    Private Structure Title
        Private Const appTitle As String = "Kitserver 6 Settings"
        Public Const titleInfo As String = appTitle & " | Information"
        Public Const titleError As String = appTitle & " | Error"
        Public Const titleWarning As String = appTitle & " | Warning"
    End Structure
#End Region

#Region "Properties"
    ''' <summary>
    ''' Get title for information message
    ''' </summary>
    ''' <value>String</value>
    ''' <returns>Kitserver 6 Settings | Information</returns>
    Public ReadOnly Property TitleInfo As String
        Get
            Return Title.titleInfo
        End Get
    End Property

    ''' <summary>
    ''' Get title for error message
    ''' </summary>
    ''' <value>String</value>
    ''' <returns>Kitserver 6 Settings | Error</returns>
    Public ReadOnly Property TitleError As String
        Get
            Return Title.titleError
        End Get
    End Property

    ''' <summary>
    ''' Get title for warning message
    ''' </summary>
    ''' <value>String</value>
    ''' <returns>Kitserver 6 Settings | Warning</returns>
    Public ReadOnly Property TitleWarning As String
        Get
            Return Title.titleWarning
        End Get
    End Property
#End Region

End Class
