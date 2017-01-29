Imports System.IO

Namespace Classes
    Public Class Host

        Private _path As String
        Private _servers As List(Of String)



        'Constructor
        Sub New()
            _servers = New List(Of String)
            _path = Environment.GetFolderPath(Environment.SpecialFolder.System) + "\drivers\etc\hosts"
        End Sub


        Public ReadOnly Property Path As String
            Get
                Return _path
            End Get
        End Property

        Public Property Servers As List(Of String)
            Get
                Return _servers
            End Get
            Set(value As List(Of String))
                _servers = value
            End Set
        End Property



        Public Function Check() As Boolean
            If File.Exists(_path) Then
                Return True
            Else
                Return False
            End If
        End Function

        Public Function Valid() As Boolean
            Dim line As String

            If Me.Check() Then
                Using sr As StreamReader = New StreamReader(_path)
                    Do
                        line = sr.ReadLine
                        If line.StartsWith("#Kitserver 6 Settings") Then
                            Do
                                line = sr.ReadLine
                                If line.StartsWith("#####################") Then
                                    Return True
                                End If
                            Loop Until sr.EndOfStream
                        End If
                    Loop Until sr.EndOfStream
                End Using
            End If

            Return False
        End Function

        Public Function Read() As Boolean
            Dim line As String

            _servers.Clear()
            If Me.Check() Then
                Using sr As StreamReader = New StreamReader(_path)
                    Do
                        line = sr.ReadLine
                        If line.StartsWith("#Kitserver 6 Settings") Then
                            Do
                                line = sr.ReadLine
                                If line.StartsWith("#####################") Then
                                    Return True
                                Else
                                    _servers.Add(line)
                                End If
                            Loop Until sr.EndOfStream

                            'While True
                            '    line = sr.ReadLine
                            '    If line.StartsWith("#####################") Then
                            '        Return True
                            '    Else
                            '        _servers.Add(line)
                            '    End If
                            '    If sr.EndOfStream Then
                            '        Return False
                            '    End If
                            'End While
                        End If
                    Loop Until sr.EndOfStream
                End Using
            End If

            Return False
        End Function

        Public Function Write() As Boolean
            Dim line As String
            Dim done As Boolean = False
            Dim text As New List(Of String)

            If File.Exists(_path) Then
                Using sr As StreamReader = New StreamReader(_path)
                    Do
                        line = sr.ReadLine
                        text.Add(line)
                        If line.StartsWith("#Kitserver 6 Settings") Then
                            Do
                                line = sr.ReadLine
                                If line.StartsWith("#####################") Then
                                    For Each name As String In _servers
                                        text.Add(name)
                                    Next
                                    done = True
                                    Exit Do
                                End If
                            Loop Until sr.EndOfStream

                            'While True
                            '    line = sr.ReadLine
                            '    If line.StartsWith("#####################") Then
                            '        For Each name As String In _servers
                            '            text.Add(name)
                            '        Next
                            '        done = True
                            '        Exit While
                            '    End If
                            '    If sr.EndOfStream Then
                            '        done = False
                            '        Exit While
                            '    End If
                            'End While
                        End If
                    Loop Until sr.EndOfStream

                    If Not done Then
                        text.Add("")
                        text.Add("#Kitserver 6 Settings")
                        For Each name As String In _servers
                            text.Add(name)
                        Next
                        text.Add("#####################")
                    End If
                End Using

                Using sw As StreamWriter = File.CreateText(_path + "new")
                    For Each name As String In text
                        sw.WriteLine(name)
                    Next
                End Using
            End If

            Return done
        End Function


    End Class
End Namespace
