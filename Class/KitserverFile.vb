Imports System.IO

''' <summary>
''' Kitserver 6 File Class
''' </summary>
Public NotInheritable Class KitserverFile

#Region "Field"
    ''' <summary>
    ''' Name of the application
    ''' </summary>
    Private Structure AppFile
        Public Const keyBind As String = "keybind.exe"
        Public Const lodMixer As String = "lodcfg.exe"
        Public Const setup As String = "setup.exe"
    End Structure
#End Region

#Region "Properties"
    ''' <summary>
    ''' Name KeyBind application
    ''' </summary>
    ''' <value>String</value>
    ''' <returns>keybind.exe</returns>
    Public ReadOnly Property AppKeyBind As String
        Get
            Return AppFile.keyBind
        End Get
    End Property

    ''' <summary>
    ''' Name LodMixer application
    ''' </summary>
    ''' <value>String</value>
    ''' <returns>lodcfg.exe</returns>
    Public ReadOnly Property AppLodMixer As String
        Get
            Return AppFile.lodMixer
        End Get
    End Property

    ''' <summary>
    ''' Name Setup application
    ''' </summary>
    ''' <value>String</value>
    ''' <returns>setup.exe</returns>
    Public ReadOnly Property AppSetup As String
        Get
            Return AppFile.setup
        End Get
    End Property
#End Region

#Region "Methods"
    ''' <summary>
    ''' Checking existence of the input file
    ''' </summary>
    ''' <param name="fileName"></param>
    ''' <returns>Boolean</returns>
    ''' <remarks>Sends a message if the file does not exist</remarks>
    Public Function Check(ByVal fileName As String) As Boolean
        If File.Exists(fileName) Then
            Return True
        Else
            Call MessageError(fileName)
        End If

        Return False
    End Function

    ''' <summary>
    ''' Display error message
    ''' </summary>
    ''' <param name="fileName"></param>
    Private Sub MessageError(ByVal fileName As String)
        Dim msgText As String
        Dim msgTitle As New MessageTitle()

        msgText = "Warning, '" & fileName & "' file does not exist." & Environment.NewLine
        msgText += "Kitserver is not complete or is not properly installed."

        MessageBox.Show(msgText, msgTitle.TitleWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub
#End Region

End Class
