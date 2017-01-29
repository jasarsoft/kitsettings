Public Module Host
    Private _formHost As FormHost

    'Sub New()
    '    _formHost = New FormHost()
    'End Sub


    Public Property Form As FormHost
        Get
            Return _formHost
        End Get
        Set(value As FormHost)
            _formHost = value
        End Set
    End Property

End Module
