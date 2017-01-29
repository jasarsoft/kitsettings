Namespace Classes
    ''' <summary>
    ''' Kitserver 6 Settings Application Data
    ''' </summary>
    Public NotInheritable Class About

        ''' <summary>
        ''' Application Main Information
        ''' </summary>
        Private Structure AppInfo
            ''' <summary>Application File Name</summary>
            Public Const appName As String = "kitsettings.exe"
            ''' <summary>Application Title Name</summary>
            Public Const appTitle As String = "Kitserver 6 Settings"
            ''' <summary>Application Version Value</summary>
            Public Const appVersion As String = "1.0.0.0 Beta"
            ''' <summary>Application Developer Name</summary>
            Public Const appDeveloper As String = "Edin Jašarević"
            ''' <summary>Application License</summary>
            Public Const appLicense As String = "Apache License, Version 2.0"
            ''' <summary>Application Website Name</summary>
            Public Const appWebsite As String = "www.github.com/jasarsoft/kitsettings"
            ''' <summary>Application Description Text</summary>
            Public Const appDescription As String = "Kitserver 6 Settings application for editing kitserver parameters in the " & _
                                                    "configuration file for Pro Evolution Soccer 6 game through a simple interface."
        End Structure

        ''' <summary>
        ''' Application File Name
        ''' </summary>
        ''' <value>String</value>
        ''' <returns>kitsettings.exe</returns>
        Public ReadOnly Property Name As String
            Get
                Return AppInfo.appName
            End Get
        End Property

        ''' <summary>
        ''' Application Title Name
        ''' </summary>
        ''' <value>String</value>
        ''' <returns>Kitserver 6 Settings</returns>
        Public ReadOnly Property Title As String
            Get
                Return AppInfo.appTitle
            End Get
        End Property

        ''' <summary>
        ''' Application Version Value
        ''' </summary>
        ''' <value>String</value>  
        ''' <returns>1.0.0.0</returns>
        Public ReadOnly Property Version As String
            Get
                Return AppInfo.appVersion
            End Get
        End Property

        ''' <summary>
        ''' Application Developer Name
        ''' </summary>
        ''' <value>String</value>
        ''' <returns>Edin Jašarević</returns>
        Public ReadOnly Property Developer As String
            Get
                Return AppInfo.appDeveloper
            End Get
        End Property

        ''' <summary>
        ''' Application License Information
        ''' </summary>
        ''' <value>String</value>
        ''' <returns>Apache License, Version 2.0</returns>
        Public ReadOnly Property License As String
            Get
                Return AppInfo.appLicense
            End Get
        End Property

        ''' <summary>
        ''' Application Website Name
        ''' </summary>
        ''' <value>String</value>
        ''' <returns>www.github/jasarsoft/kitsettings</returns>
        Public ReadOnly Property Website As String
            Get
                Return AppInfo.appWebsite
            End Get
        End Property

        ''' <summary>
        ''' Application Description Text
        ''' </summary>
        ''' <value>String</value>
        ''' <returns>Kitserver 6 Settings application for editing kitserver parameters in the configuration file for Pro Evolution Soccer 6 game through a simple interface.</returns>
        Public ReadOnly Property Description As String
            Get
                Return AppInfo.appDescription
            End Get
        End Property

    End Class
End Namespace
