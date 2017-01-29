Namespace Modules
    Public Module Server
        Private _edit As Boolean
        Private _formServer As Forms.Server

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

        Public Property Form As Forms.Server
            Get
                Return _formServer
            End Get
            Set(value As Forms.Server)
                _formServer = value
            End Set
        End Property

    End Module
End Namespace

