Public Module Combo

    Public Sub SetBoolValue(ByRef comboBox As ComboBox, ByVal inputValue As Boolean)

        If inputValue Then
            comboBox.SelectedIndex = 1
        Else
            comboBox.SelectedIndex = 0
        End If

    End Sub

    Public Function GetBoolValue(ByRef comboBox As ComboBox) As Boolean

        If comboBox.SelectedIndex = 0 Then
            Return False
        ElseIf comboBox.SelectedIndex = 1 Then
            Return True
        Else
            Return Nothing
        End If

    End Function

End Module
