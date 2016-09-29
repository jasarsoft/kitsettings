Public NotInheritable Class Application

    Private Structure AppInfo
        Public Const appName As String = "kitsettings.exe"
        Public Const appTitle As String = "Kitserver 6 Settings"
        Public Const appVersion As String = "1.0.0.0"
        Public Const appDeveloper As String = "Edin Jašarević"
        Public Const appWebsite As String = "www.github/jasarsoft/kitsettings"
    End Structure

    Public ReadOnly Property Name As String
        Get
            Return AppInfo.appName
        End Get
    End Property

    Public ReadOnly Property Title As String
        Get
            Return AppInfo.appTitle
        End Get
    End Property

    Public ReadOnly Property Version As String
        Get
            Return AppInfo.appVersion
        End Get
    End Property

    Public ReadOnly Property Developer As String
        Get
            Return AppInfo.appDeveloper
        End Get
    End Property

    Public ReadOnly Property Website As String
        Get
            Return AppInfo.appWebsite
        End Get
    End Property

End Class
