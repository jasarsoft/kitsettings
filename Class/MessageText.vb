Public NotInheritable Class MessageText

    Private _id00 As String
    Private _id01 As String
    Private _id02 As String

    Private _id10 As String
    Private _id11 As String
    Private _id12 As String
    Private _id13 As String
    Private _id14 As String
    Private _id15 As String
    Private _id16 As String

    Public Sub New()
        _id00 = "Check administrative privileges to application" & Environment.NewLine
        _id00 += "or use the file from third-party software."

        _id01 = "Do you want to correct the configuration file on" & Environment.NewLine
        _id01 += "the current or recommeded settings?"

        _id02 = "Do you want to create a new configuration file" & Environment.NewLine
        _id02 += "with a recommended default settings?"

        _id10 = " contained an invalid parameter."
        _id11 = " configuration file can not be written."
        _id12 = " does not exist."
        _id13 = " can not be deleted."
        _id14 = " can not be modified."
        _id15 = " can not be created."
        _id16 = " was successfully created" & Environment.NewLine & "with an inital recommended settings."
    End Sub

    Public ReadOnly Property ID00 As String
        Get
            Return _id00
        End Get
    End Property

    Public ReadOnly Property ID01 As String
        Get
            Return _id01
        End Get
    End Property

    Public ReadOnly Property ID02 As String
        Get
            Return _id02
        End Get
    End Property


    Public ReadOnly Property ID10 As String
        Get
            Return _id10
        End Get
    End Property

    Public ReadOnly Property ID11 As String
        Get
            Return _id11
        End Get
    End Property

    Public ReadOnly Property ID12 As String
        Get
            Return _id12
        End Get
    End Property

    Public ReadOnly Property ID13 As String
        Get
            Return _id13
        End Get
    End Property

    Public ReadOnly Property ID14 As String
        Get
            Return _id14
        End Get
    End Property

    Public ReadOnly Property ID15 As String
        Get
            Return _id15
        End Get
    End Property

    Public ReadOnly Property ID16 As String
        Get
            Return _id16
        End Get
    End Property
    
End Class
