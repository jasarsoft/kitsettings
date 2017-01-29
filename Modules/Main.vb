
Namespace Modules
    Public Module Main
        Private _formMain As Forms.Main


        Sub New()
            _formMain = New Forms.Main()
        End Sub

        Public Property Form As Forms.Main
            Get
                Return _formMain
            End Get
            Set(value As Forms.Main)
                _formMain = value
            End Set
        End Property


        <STAThread> _
        Public Sub Main()
            Application.EnableVisualStyles()
            Application.Run(_formMain)
        End Sub

    End Module
End Namespace


