Public Module Server
    Private _edit As Boolean
    Private _formServer As FormServer

    'Sub New()
    '    _formServer = New FormServer()
    'End Sub


    Public Property Edit As Boolean
        Get
            Return _edit
        End Get
        Set(value As Boolean)
            _edit = value
        End Set
    End Property

    Public Property Form As FormServer
        Get
            Return _formServer
        End Get
        Set(value As FormServer)
            _formServer = value
        End Set
    End Property

End Module
