Public NotInheritable Class MessageText

    Private _id00 As String

    Public Sub New()
        _id00 = "Check administrative privileges to application" & Environment.NewLine
        _id00 += "or use the file from third-party software."
    End Sub

    Public ReadOnly Property ID00 As String
        Get
            Return _id00
        End Get
    End Property
    
End Class
