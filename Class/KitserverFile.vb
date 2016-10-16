Imports System.IO

Public Class KitserverFile

    Private Structure AppFile
        Public Const keyBind As String = "keybind.exe"
        Public Const lodMixer As String = "lodcfg.exe"
        Public Const setup As String = "setup.exe"
    End Structure

    Public ReadOnly Property AppKeyBind As String
        Get
            Return AppFile.keyBind
        End Get
    End Property

    Public ReadOnly Property AppLodMixer As String
        Get
            Return AppFile.lodMixer
        End Get
    End Property

    Public ReadOnly Property AppSetup As String
        Get
            Return AppFile.setup
        End Get
    End Property

    Public Function Check(ByVal fileName As String) As Boolean
        If File.Exists(fileName) Then
            Return True
        Else
            Call MessageError(fileName)
        End If

        Return False
    End Function

    Private Sub MessageError(ByVal fileName As String)
        Dim msgText As String
        Dim msgTitle As New MessageTitle()

        msgText = "Warning, '" & fileName & "' file does not exist." & Environment.NewLine
        msgText += "Kitserver is not complete or is not properly installed."

        MessageBox.Show(msgText, msgTitle.TitleWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

End Class
