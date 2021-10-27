Public Module Parameter

    Public Sub Text(ByVal name As String)
        If name = "" Then
            Throw New ArgumentException()
        End If

    End Sub


End Module
