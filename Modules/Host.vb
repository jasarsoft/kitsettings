Namespace Modules
    Public Module Host
        Private _formHost As Forms.Host

        'Sub New()
        '    _formHost = New FormHost()
        'End Sub


        Public Property Form As Forms.Host
            Get
                Return _formHost
            End Get
            Set(value As Forms.Host)
                _formHost = value
            End Set
        End Property

    End Module
End Namespace

