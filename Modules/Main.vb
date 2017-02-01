Public Module Main
    'Private _host As HostForm
    'Private _server As ServerForm
    Private _settings As SettingsForm


    Sub New()
        _settings = New SettingsForm()
    End Sub

    'Public Property Settings As SettingsForm
    '    Get
    '        Return _settings
    '    End Get
    '    Set(value As SettingsForm)
    '        _settings = value
    '    End Set
    'End Property

    'Public Property Host As HostForm
    '    Get
    '        Return _host
    '    End Get
    '    Set(value As HostForm)
    '        _host = value
    '    End Set
    'End Property

    'Public Property Server As ServerForm
    '    Get
    '        Return _server
    '    End Get
    '    Set(value As ServerForm)
    '        _server = value
    '    End Set
    'End Property


    <STAThread> _
    Public Sub Main()
        Application.EnableVisualStyles()
        Application.Run(_settings)
    End Sub

End Module