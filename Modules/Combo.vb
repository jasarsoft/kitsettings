Namespace Modules
    ''' <summary>
    ''' Module for additional methods of ComboBox
    ''' </summary>
    Public Module Combo
        ''' <summary>
        ''' Set bool value in combobox
        ''' </summary>
        ''' <param name="comboBox"></param>
        ''' <param name="inputValue"></param>
        Public Sub SetBoolValue(ByRef comboBox As ComboBox, ByVal inputValue As Boolean)

            If inputValue Then
                comboBox.SelectedIndex = 1
            Else
                comboBox.SelectedIndex = 0
            End If

        End Sub

        ''' <summary>
        ''' Get bool value in combobox
        ''' </summary>
        ''' <param name="comboBox"></param>
        ''' <returns>Boolean</returns>
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
End Namespace
