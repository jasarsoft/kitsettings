Imports Microsoft.Win32

''' <summary>
''' Pro Evolution Soccer 6 parameters registry
''' </summary>
Public NotInheritable Class PesRegistry

#Region "Fields/Variables"
    ''' <summary>Registry values</summary>
    Private _regValue As RegValue
#End Region

#Region "Constants"
    ''' <summary>
    ''' Constants registry key
    ''' </summary>
    Private Structure RegName
        Public Const code As String = "code"
        Public Const installDir As String = "installdir"
        Public Const installFrom As String = "installfrom"
        Public Const langEnglish As String = "lang_e"
        Public Const langFrench As String = "lang_f"
        Public Const langGerman As String = "lang_g"
        Public Const langItalian As String = "lang_i"
        Public Const langPolish As String = "lang_p"
        Public Const langSpanish As String = "lang_s"
    End Structure

    ''' <summary>
    ''' Registry values
    ''' </summary>
    Private Structure RegValue
        Public code As String
        Public installDir As String
        Public installFrom As String
        Public langEnglish As Boolean
        Public langFrench As Boolean
        Public langGerman As Boolean
        Public langItalian As Boolean
        Public langPolish As Boolean
        Public langSpanish As Boolean
    End Structure
#End Region

#Region "Properties"
    ''' <summary>
    ''' Unique code of the game
    ''' </summary>
    ''' <value>String</value>
    ''' <returns>_regValue.code</returns>
    Public Property Code As String
        Get
            Return _regValue.code
        End Get
        Set(value As String)
            _regValue.code = value
        End Set
    End Property

    ''' <summary>
    ''' Location of installed game
    ''' </summary>
    ''' <value>String</value>
    ''' <returns>_regValue.installDir</returns>
    Public Property InstallDir As String
        Get
            Return _regValue.installDir
        End Get
        Set(value As String)
            _regValue.installDir = value
        End Set
    End Property

    ''' <summary>
    ''' The location form which a game is installed
    ''' </summary>
    ''' <value>String</value>
    ''' <returns>_regValue.installFrom</returns>
    Public Property InstallFrom As String
        Get
            Return _regValue.installFrom
        End Get
        Set(value As String)
            _regValue.installFrom = value
        End Set
    End Property

    ''' <summary>
    ''' The game installed with English language
    ''' </summary>
    ''' <value>Boolean</value>
    ''' <returns>_regValue.langEnglish</returns>
    Public Property LangEnglish As Boolean
        Get
            Return _regValue.langEnglish
        End Get
        Set(value As Boolean)
            _regValue.langEnglish = value
        End Set
    End Property

    ''' <summary>
    ''' The game installed with French language
    ''' </summary>
    ''' <value>Boolean</value>
    ''' <returns>_regValue.langFrench</returns>
    Public Property LangFrench As Boolean
        Get
            Return _regValue.langFrench
        End Get
        Set(value As Boolean)
            _regValue.langFrench = value
        End Set
    End Property

    ''' <summary>
    ''' The game installed with German language
    ''' </summary>
    ''' <value>Boolean</value>
    ''' <returns>_regValue.langGerman</returns>
    Public Property LangGerman As Boolean
        Get
            Return _regValue.langGerman
        End Get
        Set(value As Boolean)
            _regValue.langGerman = value
        End Set
    End Property

    ''' <summary>
    ''' The game installed with Italian language
    ''' </summary>
    ''' <value>Boolean</value>
    ''' <returns>_regValue.langItalian</returns>
    Public Property LangItalian As Boolean
        Get
            Return _regValue.langItalian
        End Get
        Set(value As Boolean)
            _regValue.langItalian = value
        End Set
    End Property

    ''' <summary>
    ''' The game installed with Polish language
    ''' </summary>
    ''' <value>Boolean</value>
    ''' <returns>_regValue.langPolish</returns>
    Public Property LangPolish As Boolean
        Get
            Return _regValue.langPolish
        End Get
        Set(value As Boolean)
            _regValue.langPolish = value
        End Set
    End Property

    ''' <summary>
    ''' The game installed with Spanish language
    ''' </summary>
    ''' <value>Boolean</value>
    ''' <returns>_regValue.langSpanish</returns>
    Public Property LangSpanish As Boolean
        Get
            Return _regValue.langSpanish
        End Get
        Set(value As Boolean)
            _regValue.langSpanish = value
        End Set
    End Property
#End Region

#Region "Constructor"
    ''' <summary>
    ''' Default initializazion constructor
    ''' </summary>
    Public Sub New()
        _regValue.code = ""
        _regValue.installDir = ""
        _regValue.installFrom = ""
        _regValue.langEnglish = False
        _regValue.langFrench = False
        _regValue.langGerman = False
        _regValue.langItalian = False
        _regValue.langPolish = False
        _regValue.langSpanish = False
    End Sub
#End Region

#Region "Methods"
    ''' <summary>
    ''' Read all registry values
    ''' </summary>
    ''' <returns>Boolean</returns>
    Public Function Read() As Boolean
        Dim regKey As RegistryKey

        regKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\KONAMIPES6\PES6")
        If regKey IsNot Nothing Then
            If Not ReadRegistry(regKey, RegName.code, _regValue.code) Then
                Return False
            ElseIf Not ReadRegistry(regKey, RegName.installDir, _regValue.installDir) Then
                Return False
            ElseIf Not ReadRegistry(regKey, RegName.installFrom, _regValue.installFrom) Then
                Return False
            ElseIf Not ReadRegistry(regKey, RegName.langEnglish, _regValue.langEnglish) Then
                Return False
            ElseIf Not ReadRegistry(regKey, RegName.langFrench, _regValue.langFrench) Then
                Return False
            ElseIf Not ReadRegistry(regKey, RegName.langGerman, _regValue.langGerman) Then
                Return False
            ElseIf Not ReadRegistry(regKey, RegName.langItalian, _regValue.langItalian) Then
                Return False
            ElseIf Not ReadRegistry(regKey, RegName.langPolish, _regValue.langPolish) Then
                Return False
            ElseIf Not ReadRegistry(regKey, RegName.langSpanish, _regValue.langSpanish) Then
                Return False
            Else
                Return True
            End If
        End If

        Call MessageError()
        Return False
    End Function

    ''' <summary>
    ''' Read the text registry key
    ''' </summary>
    ''' <param name="regKey"></param>
    ''' <param name="regName"></param>
    ''' <param name="regValue"></param>
    ''' <returns>Boolean</returns>    
    Private Function ReadRegistry(ByVal regKey As RegistryKey, ByVal regName As String, ByRef regValue As String) As Boolean
        Dim tmpValue As Object

        tmpValue = regKey.GetValue(regName, Nothing)
        If tmpValue IsNot Nothing Then
            regValue = CType(tmpValue, String)
            Return True
        End If

        Call MessageError()
        Return False
    End Function

    ''' <summary>
    ''' Read bool registry key
    ''' </summary>
    ''' <param name="regKey"></param>
    ''' <param name="regName"></param>
    ''' <param name="regValue"></param>
    ''' <returns>Boolean</returns>
    Private Function ReadRegistry(ByVal regKey As RegistryKey, ByVal regName As String, ByRef regValue As Boolean) As Boolean
        Dim tmpValue As Object

        tmpValue = regKey.GetValue(regName, Nothing)
        If tmpValue IsNot Nothing Then
            regValue = CType(tmpValue, Boolean)
            Return True
        End If

        Call MessageError()
        Return False
    End Function

    ''' <summary>
    ''' Error message on irregular or non-existent registry
    ''' </summary>
    Private Sub MessageError()
        Dim msgText As String
        Dim msgTitle As New Title()

        msgText = "Your registry is the game does not exist or is not correct." & Environment.NewLine
        msgText += "The game may not work and therefore the kitserver."

        MessageBox.Show(msgText, msgTitle.TitleWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub
#End Region

End Class