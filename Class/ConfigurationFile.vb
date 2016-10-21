Imports System.IO

Public MustInherit Class ConfigurationFile

    ''' <summary>
    ''' Basic information about the file
    ''' </summary>
    Private Structure Info
        ''' <summary>Name the configuration file, ie. extension because of inheritance</summary>
        Public Const name As String = ".cfg"
        ''' <summary>Title the configuration file, ie. group title because of inheritance</summary>
        Public Const title As String = " configuration file"
    End Structure

    ''' <summary>
    ''' Property for getting an extension of the configuration file
    ''' </summary>
    ''' <returns>Returns the extension configuration file</returns>
    ''' <remarks>The property must be inherited</remarks>
    Protected Overridable ReadOnly Property Name As String
        Get
            Return Info.name
        End Get
    End Property

    ''' <summary>
    ''' Property for getting part of the title configuration file
    ''' </summary>
    ''' <returns>Returns a part of the title for the configuration file</returns>
    ''' <remarks>The property must be inherited</remarks>
    Protected Overridable ReadOnly Property Title As String
        Get
            Return Info.title
        End Get
    End Property

    ''' <summary>
    ''' Check for existance of the configuration file
    ''' </summary>
    ''' <param name="fileName">Name the file to be checked</param>
    ''' <param name="titleName">Title configuration file for an error message</param>
    ''' <param name="fileData">Content that will be written if the file does not exist</param>
    ''' <returns>Returns True if the exists or has successfully created new</returns>
    ''' <remarks>Function uses the process of creating a new file</remarks>
    Protected Overridable Function Check(ByVal fileName As String, ByVal titleName As String, ByVal fileData As String) As Boolean

        If File.Exists(fileName) Then
            Return True
        Else
            Dim tmpText As String
            Dim msgReasult As DialogResult
            Dim msgText As MessageText = New MessageText()
            Dim msgTitle As MessageTitle = New MessageTitle()
            'Message: [Title File] configuration file does not exist.
            '         Do you want to create a new configuration file with a recommended default settings?
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
    ''' Delete the configuration file
    ''' </summary>
    ''' <param name="fileName">Name the file to be deleted</param>
    ''' <param name="titleName">Title configuration file used for the error message</param>
    ''' <returns>Returns True if the file is deleted successfully</returns>
    ''' <remarks>The function contains a warning about not making the surgery</remarks>
    Protected Overridable Function DeleteFile(ByVal fileName As String, ByVal titleName As String) As Boolean

        If File.Exists(fileName) Then
            'Try deleting the file
            Try
                File.Delete(fileName)
            Catch ex As Exception
                'Deletion failed
                Dim tmpText As String
                Dim msgText As MessageText = New MessageText()
                Dim msgTitle As MessageTitle = New MessageTitle()
                'Message: [Title File] configuration file can not be deleted. 
                '         Check administrative privileges to application or use the file from third-party software.
                tmpText = titleName & msgText.ID13 & Environment.NewLine & msgText.ID00
                MessageBox.Show(tmpText, msgTitle.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End Try
        End If

        Return True
    End Function

    ''' <summary>
    ''' Creates a new configuration file
    ''' </summary>
    ''' <param name="fileName">Name of the file that will be created</param>
    ''' <param name="titleName">Title the file that be in the header as a comment</param>
    ''' <param name="fileData">Content will be written</param>
    ''' <returns>Returns True if the file was created successfully</returns>
    ''' <remarks>The function uses methods of writing and erasing</remarks>
    Protected Overridable Function CreateFile(ByVal fileName As String, ByVal titleName As String, ByVal fileData As String) As Boolean
        Dim tmpText As String
        Dim msgText As MessageText = New MessageText()
        Dim msgTitle As MessageTitle = New MessageTitle()

        If File.Exists(fileName) Then
            'Try deleting the file
            Try
                File.Delete(fileName)
            Catch ex As Exception
                'Deletion failed
                tmpText = titleName & msgText.ID14 & Environment.NewLine & msgText.ID00
                'Message: [Title File] configuration file can not be modified. 
                '         Check administrative privileges to application or use the file from third-party software.
                MessageBox.Show(tmpText, msgTitle.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End Try
        End If

        If WriteFile(fileName, titleName, fileData) Then
            'Writing successfully completed
            'Message: [Title File] was successfully created with an inital recommended settings.
            tmpText = titleName & msgText.ID16
            MessageBox.Show(tmpText, msgTitle.TitleInfo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return True
        Else
            'Writing is not successfully completed
            'Message: [Title File] configuration file can not be created. 
            '         Check administrative privileges to application or use the file from third-party software.
            tmpText = msgText.ID15 & Environment.NewLine & msgText.ID00
            MessageBox.Show(tmpText, msgTitle.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

    End Function

    ''' <summary>
    ''' Write new content in the configuration file
    ''' </summary>
    ''' <param name="fileName">Name the file to be used to write</param>
    ''' <param name="titleName">Title to be in the header content as a comment</param>
    ''' <param name="fileData">The full text of which will be written</param>
    ''' <returns>Return true if successfully completed write</returns>
    ''' <remarks>The function automatically generates the header file</remarks>
    Protected Overridable Function WriteFile(ByVal fileName As String, ByVal titleName As String, ByVal fileData As String) As Boolean
        'Configuration File Header
        Dim comment As String = "# Generated by Kitserver 6 Settings"
        'Try writing to a file
        Try
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
    ''' Read key value from the configuration file
    ''' </summary>
    ''' <param name="fileName">The name of a configuration file from which to read</param>
    ''' <param name="keyValue">The key name from which to read</param>
    ''' <returns>Returns the string value of the key</returns>
    ''' <remarks>The function reads the value of a clean key.</remarks>
    Protected Overridable Function ReadFile(ByVal fileName As String, ByVal keyValue As String, Optional ByVal enableReplace As Boolean = True) As String
        Dim line As String
        'Try reading to a file
        Try
            Using sr As StreamReader = New StreamReader(fileName)
                Do
                    line = sr.ReadLine
                    If line.Contains(keyValue) Then
                        If line.StartsWith(keyValue) Then
                            'The key was found.
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
    ''' <param name="inputValue">A parameter is converted to a numeric string value</param>
    ''' <returns>String: '1' - True; '2' - False;</returns>
    ''' <remarks>Undefined value is converted to the same value os False</remarks>
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
    ''' <param name="inputValue">The numeric string variable that is converted to a Boolean value</param>
    ''' <returns>Return False only as an input value of zero</returns>
    ''' <remarks>Any nonzero value is converted to True</remarks>
    Protected Function ConvertValue(ByVal inputValue As String) As Boolean

        If inputValue = "0" Then
            Return False
        Else
            Return True
        End If

    End Function

End Class
