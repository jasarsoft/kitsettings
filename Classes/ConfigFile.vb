Imports System.IO

Public MustInherit Class ConfigFile

    ''' <summary>
    ''' Basic information about the file
    ''' </summary>
    Private Structure Info
        ''' <summary>Name the configuration file, ie. extension because of inheritance</summary>
        Public Const name As String = ".cfg"
        ''' <summary>Title the configuration file, ie. group title because of inheritance</summary>
        Public Const title As String = " configuration file"
        Public Const modul As String = ".dll"
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

    Protected Overridable ReadOnly Property Modul As String
        Get
            Return Info.modul
        End Get
    End Property




    ''' <summary>
    ''' Check for existance of the configuration file
    ''' </summary>
    ''' <param name="name">Name the file to be checked</param>
    ''' <param name="title">Title configuration file for an error message</param>
    ''' <param name="data">Content that will be written if the file does not exist</param>
    ''' <returns>Returns True if the exists or has successfully created new</returns>
    ''' <remarks>Function uses the process of creating a new file</remarks>
    Protected Overridable Function Check(ByVal name As String, ByVal title As String, ByVal data As String) As Boolean

        If File.Exists(name) Then
            Return True
        Else
            Dim temp As String
            Dim result As DialogResult
            Dim text As MessageText = New MessageText()
            Dim caption As Title = New Title()
            'Message: [Title File] configuration file does not exist.
            '         Do you want to create a new configuration file with a recommended default settings?
            temp = title & text.ID12 & Environment.NewLine & text.ID02

            result = MessageBox.Show(temp, caption.TitleWarning, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If result = DialogResult.Yes Then
                If Create(name, title, data) Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        End If

    End Function


    Protected Overridable Function Valid(ByVal name As String, ByVal title As String) As Boolean

        If File.Exists(name + Info.modul) Then
            Return True
        Else
            Return False
        End If

    End Function


    ''' <summary>
    ''' Delete the configuration file
    ''' </summary>
    ''' <param name="name">Name the file to be deleted</param>
    ''' <param name="title">Title configuration file used for the error message</param>
    ''' <returns>Returns True if the file is deleted successfully</returns>
    ''' <remarks>The function contains a warning about not making the surgery</remarks>
    Protected Overridable Function Delete(ByVal name As String, ByVal title As String) As Boolean
        'checking parameter tite
        If title Is Nothing Then
            Throw New ArgumentNullException("title")
        ElseIf title = "" Then
            Throw New ArgumentException("title")
        Else
            Dim temp As String = ""
            For i As Integer = 1 To title.Length
                temp += " "
                If title.StartsWith(temp) Then
                    If i = title.Length Then
                        Throw New ArgumentException("title")
                    Else
                        Continue For
                    End If
                Else
                    Exit For
                End If
            Next
        End If

        If File.Exists(name) Then
            'Try deleting the file
            Try
                File.Delete(name)
            Catch ex As ArgumentException
                Dim msgTitle = New Title()
                MessageBox.Show(ex.Message, msgTitle.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            Catch ex As Exception
                'Deletion failed
                Dim tmpText As String
                Dim msgText As MessageText = New MessageText()
                Dim msgTitle As Title = New Title()
                'Message: [Title File] configuration file can not be deleted. 
                '         Check administrative privileges to application or use the file from third-party software.
                tmpText = title & msgText.ID13 & Environment.NewLine & msgText.ID00
                MessageBox.Show(tmpText, msgTitle.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End Try
        End If

        Return True
    End Function


    ''' <summary>
    ''' Creates a new configuration file
    ''' </summary>
    ''' <param name="name">Name of the file that will be created</param>
    ''' <param name="title">Title the file that be in the header as a comment</param>
    ''' <param name="data">Content will be written</param>
    ''' <returns>Returns True if the file was created successfully</returns>
    ''' <remarks>The function uses methods of writing and erasing</remarks>
    Protected Overridable Function Create(ByVal name As String, ByVal title As String, ByVal data As String) As Boolean
        Dim tmpText As String
        Dim msgText As MessageText = New MessageText()
        Dim msgTitle As Title = New Title()

        If File.Exists(name) Then
            'Try deleting the file
            Try
                File.Delete(name)
            Catch ex As Exception
                'Deletion failed
                tmpText = title & msgText.ID14 & Environment.NewLine & msgText.ID00
                'Message: [Title File] configuration file can not be modified. 
                '         Check administrative privileges to application or use the file from third-party software.
                MessageBox.Show(tmpText, msgTitle.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End Try
        End If

        If Write(name, title, data) Then
            'Writing successfully completed
            'Message: [Title File] was successfully created with an inital recommended settings.
            tmpText = title & msgText.ID16
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
    ''' <param name="name">Name the file to be used to write</param>
    ''' <param name="title">Title to be in the header content as a comment</param>
    ''' <param name="data">The full text of which will be written</param>
    ''' <returns>Return true if successfully completed write</returns>
    ''' <remarks>The function automatically generates the header file</remarks>
    Protected Overridable Function Write(ByVal name As String, ByVal title As String, ByVal data As String) As Boolean
        'Configuration File Header
        Dim comment As String = "# Generated by Kitserver 6 Settings"
        'Try writing to a file
        Try
            Using sw As StreamWriter = File.CreateText(name)
                sw.WriteLine("# " & title)
                sw.WriteLine(comment)
                For i As Integer = 1 To comment.Length
                    sw.Write("#")
                Next
                sw.WriteLine("")
                sw.WriteLine("")
                sw.WriteLine(data)
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
    ''' <param name="name">The name of a configuration file from which to read</param>
    ''' <param name="key">The key name from which to read</param>
    ''' <returns>Returns the string value of the key</returns>
    ''' <remarks>The function reads the value of a clean key.</remarks>
    Protected Overridable Function Read(ByVal name As String, ByVal key As String, Optional ByVal replace As Boolean = True) As String
        Dim line As String
        'Try reading to a file
        Try
            Using sr As StreamReader = New StreamReader(name)
                Do
                    line = sr.ReadLine
                    If line.Contains(key) Then
                        If line.StartsWith(key) Then
                            'The key was found.
                            If replace Then
                                line = line.Replace(key, "").Replace("=", "").Replace(" ", "")
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