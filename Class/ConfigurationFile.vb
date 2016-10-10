Imports System.IO

Public MustInherit Class ConfigurationFile

    ''' <summary>
    ''' Basic information about the file.
    ''' </summary>
    Private Structure Info
        ''' <summary>
        ''' File Name = '.cfg'
        ''' </summary>
        Public Const fileName As String = ".cfg"
        ''' <summary>
        ''' Title Name = ' configuration file'
        ''' </summary>
        Public Const titleName As String = " configuration file"
    End Structure

    ''' <summary>
    ''' The extension configuration file name.
    ''' </summary>
    ''' <returns>String: '.cfg'</returns>
    ''' <remarks>The property must be inherited.</remarks>
    Protected Overridable ReadOnly Property FileName As String
        Get
            Return Info.fileName
        End Get
    End Property

    ''' <summary>
    ''' Property group title.
    ''' </summary>
    ''' <returns>String: ' configuration file'</returns>
    ''' <remarks>The property must be inherited.</remarks>
    Protected Overridable ReadOnly Property TitleName As String
        Get
            Return Info.titleName
        End Get
    End Property

    ''' <summary>
    ''' The function for getting information about the existance of the file
    ''' </summary>
    ''' <param name="fileName"></param>
    ''' <param name="titleName"></param>
    ''' <param name="fileData"></param>
    ''' <returns>Boolean; True - The file exists; False - The file does not exist.</returns>
    ''' <remarks>Function uses the process of creating a new file.</remarks>
    Protected Overridable Function ExistFile(ByVal fileName As String, ByVal titleName As String, ByVal fileData As String) As Boolean

        If File.Exists(fileName) Then
            Return True
        Else
            Dim tmpText As String
            Dim msgReasult As DialogResult
            Dim msgText As MessageText = New MessageText()
            Dim msgTitle As MessageTitle = New MessageTitle()

            tmpText = titleName & msgText.ID12 & Environment.NewLine & msgText.ID02

            msgReasult = MessageBox.Show(tmpText, msgTitle.TitleWarning, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If msgReasult = DialogResult.Yes Then
                If CreateFile(fileName, titleName, fileData) Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        End If

    End Function

    ''' <summary>
    ''' The function deletes the configuration file.
    ''' </summary>
    ''' <param name="fileName"></param>
    ''' <param name="titleName"></param>
    ''' <returns>Boolean; True - The file is deleted; False - The file is not deleted;</returns>
    ''' <remarks>The function contains a warning about not making the surgery.</remarks>
    Protected Overridable Function DeleteFile(ByVal fileName As String, ByVal titleName As String) As Boolean

        If File.Exists(fileName) Then
            Try
                File.Delete(fileName)
                Return True
            Catch ex As Exception
                Dim tmpText As String
                Dim msgText As MessageText = New MessageText()
                Dim msgTitle As MessageTitle = New MessageTitle()

                tmpText = titleName & msgText.ID13 & Environment.NewLine & msgText.ID00
                MessageBox.Show(tmpText, msgTitle.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End Try
        Else
            Return True
        End If

    End Function

    ''' <summary>
    ''' The function creates a new configuration file.
    ''' </summary>
    ''' <param name="fileName"></param>
    ''' <param name="titleName"></param>
    ''' <param name="fileData"></param>
    ''' <returns>Boolean; True - The file is created; False - The file is not created.</returns>
    ''' <remarks>The function uses methods of writing and erasing.</remarks>
    Protected Overridable Function CreateFile(ByVal fileName As String, ByVal titleName As String, ByVal fileData As String) As Boolean
        Dim tmpText As String
        Dim msgText As MessageText = New MessageText()
        Dim msgTitle As MessageTitle = New MessageTitle()

        If File.Exists(fileName) Then
            Try
                File.Delete(fileName)
            Catch ex As Exception
                tmpText = titleName & msgText.ID14 & Environment.NewLine & msgText.ID00
                MessageBox.Show(tmpText, msgTitle.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End Try
        End If

        If WriteFile(fileName, titleName, fileData) Then
            tmpText = titleName & msgText.ID16
            MessageBox.Show(tmpText, msgTitle.TitleInfo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return True
        Else
            tmpText = msgText.ID15 & Environment.NewLine & msgText.ID00
            MessageBox.Show(tmpText, msgTitle.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

    End Function

    ''' <summary>
    ''' Function for entry of parameter values.
    ''' </summary>
    ''' <param name="fileName"></param>
    ''' <param name="titleName"></param>
    ''' <param name="fileData"></param>
    ''' <returns>Boolean; True - Finished successfully; False - Not completed</returns>
    ''' <remarks>The function automatically generates the header file.</remarks>
    Protected Overridable Function WriteFile(ByVal fileName As String, ByVal titleName As String, ByVal fileData As String) As Boolean
        Dim app As Application = New Application()
        Dim comment As String = "# Generated by " & app.Title

        Try
            app = Nothing
            Using sw As StreamWriter = File.CreateText(fileName)
                sw.WriteLine("# " & titleName)
                sw.WriteLine(comment)
                For i As Integer = 1 To comment.Length
                    sw.Write("#")
                Next
                sw.WriteLine("")
                sw.WriteLine("")
                sw.WriteLine(fileData)
                sw.Close()
            End Using
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    ''' <summary>
    ''' The function to read values.
    ''' </summary>
    ''' <param name="fileName"></param>
    ''' <param name="keyValue"></param>
    ''' <returns>Boolean: True - Successfull read; False - Don't read;</returns>
    ''' <remarks>The function reads the value of a clean key.</remarks>
    Protected Overridable Function ReadFile(ByVal fileName As String, ByVal keyValue As String, Optional ByVal enableReplace As Boolean = True) As String
        Dim line As String

        Try
            Using sr As StreamReader = New StreamReader(fileName)
                Do
                    line = sr.ReadLine
                    If line.Contains(keyValue) Then
                        If line.StartsWith(keyValue) Then
                            If enableReplace Then
                                line = line.Replace(keyValue, "").Replace("=", "").Replace(" ", "")
                            End If

                            Return line
                        End If
                    End If
                Loop Until sr.EndOfStream
            End Using
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Function converts a Boolean value to a numerical string.
    ''' </summary>
    ''' <param name="inputValue"></param>
    ''' <returns>String: '1' - True; '2' - False;</returns>
    ''' <remarks>Nothing</remarks>
    Protected Function ConvertEnable(ByVal inputValue As Boolean) As String

        If inputValue Then
            Return "1"
        Else
            Return "0"
        End If

    End Function

    ''' <summary>
    ''' The function converts the string value to boolean.
    ''' </summary>
    ''' <param name="inputValue"></param>
    ''' <returns>Boolean: True - value > 0; False - value = 0</returns>
    ''' <remarks>Nothing</remarks>
    Protected Function ConvertValue(ByVal inputValue As String) As Boolean

        If inputValue = "0" Then
            Return False
        Else
            Return True
        End If

    End Function

End Class
