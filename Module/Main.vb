Public Module Main
    Private _formMain As FormMain


    Sub New()
        _formMain = New FormMain()
    End Sub

    Public Property Form As FormMain
        Get
            Return _formMain
        End Get
        Set(value As FormMain)
            _formMain = value
        End Set
    End Property


    <STAThread> _
    Public Sub Main()
        Application.EnableVisualStyles()
        Application.Run(_formMain)
    End Sub

End Module
