Imports System.IO
Imports System.Text
Imports System.Security
Imports System.Security.Cryptography
Public NotInheritable Class Hash

    Private Function HashFileGenerator(ByVal fileName As String) As String

        Dim hashValue() As Byte
        Dim hex_value As String = ""
        Dim hash As Object = MD5.Create

        Dim fileStream As FileStream = File.OpenRead(fileName)
        fileStream.Position = 0
        hashValue = hash.ComputeHash(fileStream)

        For i As Integer = 0 To hashValue.Length - 1
            hex_value += hashValue(i).ToString("X2")
        Next i

        fileStream.Close()

        Return hex_value
    End Function


    Public Function HashFileMD5(ByVal fileName As String) As String

        If File.Exists(fileName) Then
            Return HashFileGenerator(fileName)
        Else
            Return Nothing
        End If

    End Function

End Class
