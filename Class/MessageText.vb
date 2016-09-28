Public NotInheritable Class MessageText

    Public Class CfgFile

        Private _errorExist As String
        Private _errorDelete As String
        Private _errorWrite As String
        Private _errorRead As String

        Private _infoCreate As String

        Public Sub New()
            Dim errorIntroduction As String

            errorIntroduction = "Check administrative privileges to application" & Environment.NewLine
            errorIntroduction += "or use the file from third-party software."

            _errorWrite = " can not be written." & Environment.NewLine & errorIntroduction
            _errorDelete = " can not be deleted." & Environment.NewLine & errorIntroduction

            _errorRead = " contained an invalid parameter." & Environment.NewLine
            _errorRead += "Do you want to correct the configuration file on" & Environment.NewLine
            _errorRead += "the current or recommeded settings."

            _errorExist += " does not exist." & Environment.NewLine
            _errorExist += "Do you want to create a new configuration file" & Environment.NewLine
            _errorExist += "with a recommended default settings?"

            _infoCreate += " was successfully created" & Environment.NewLine
            _infoCreate += "with an inital recommended settings."
        End Sub

        Public ReadOnly Property ErrorWrite
            Get
                Return _errorWrite
            End Get
        End Property

        Public ReadOnly Property ErrorRead
            Get
                Return _errorRead
            End Get
        End Property

        Public ReadOnly Property ErrorDelete
            Get
                Return _errorDelete
            End Get
        End Property

        Public ReadOnly Property ErrorExist
            Get
                Return _errorExist
            End Get
        End Property

        Public ReadOnly Property InfoCreate
            Get
                Return _infoCreate
            End Get
        End Property

    End Class
End Class
