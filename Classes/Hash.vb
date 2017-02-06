Imports System.IO
Imports System.Security.Cryptography

''' <summary>
''' Custom MD5 Hash File Class
''' </summary>
Public NotInheritable Class Hash
    ''' <summary>
    ''' Get MD5 hash value for the file
    ''' </summary>
    ''' <param name="fileName"></param>
    ''' <returns>String</returns>
    ''' <remarks>Hash value is in uppercase</remarks>
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

    ''' <summary>
    ''' MD5 hash value for the file
    ''' </summary>
    ''' <param name="fileName"></param>
    ''' <returns>String</returns>
    ''' <remarks>Hash value is in uppercase</remarks>
    Public Function HashFileMD5(ByVal fileName As String) As String

        If File.Exists(fileName) Then
            Return HashFileGenerator(fileName)
        Else
            Return Nothing
        End If

    End Function

End Class