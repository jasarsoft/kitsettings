
''' <summary>
''' Kitserver 6 Settings Kitserver Loader Configuration File
''' </summary>
Public NotInheritable Class KitLoader
    Inherits ConfigurationFile

#Region "Constants"
    ''' <summary>
    ''' Kitserver Loader Main Information
    ''' </summary>
    Private Structure Info
        ''' <summary>Kitserver Loader Configuration File Name</summary>
        Public Const fileName As String = "kload"
        ''' <summary>Kitserver Loader Configuration Title Name</summary>
        Public Const titleName As String = "Kitserver Loader"
    End Structure

    ''' <summary>
    ''' Kitserver Loader Configuration Paramter
    ''' </summary>
    Private Structure Parameter
        ''' <summary>Configuration Parameter Write Debug Log</summary>
        Public Const debugMode As String = "debug"
        ''' <summary>Configuration Parameter GDB Directory Name</summary>
        Public Const gdbDir As String = "gdb.dir"
        ''' <summary>Configuration Parameter Reserved RAM Memory</summary>
        Public Const reservedMemory As String = "ReservedMemory"

        ''' <summary>Configuration Parameter DirectX Force SW TnL</summary>
        Public Const forceSW As String = "dx.force-SW-TnL"
        ''' <summary>Configuration Parameter DirectX Force HW TnL </summary>
        Public Const emulateHW As String = "dx.emulate-HW-TnL"
        ''' <summary>Configuration Parameter DirectX Fullscreen Width </summary>
        Public Const fullscreenWidth As String = "dx.fullscreen.width"
        ''' <summary>Configuration Parameter DirectX Fullscreen Height </summary>
        Public Const fullscreenHeight As String = "dx.fullscreen.height"

        ''' <summary>Configuration Parameter Number Module Library</summary>
        Public Const dllNum As String = "DLL.num"
        ''' <summary>Configuration Parameter Path Module Library </summary>
        Public Const dllPath As String = "DLL."
    End Structure
#End Region

#Region "Variables"
    ''' <summary>GDB Directory Name</summary>
    Private _gdbDir As String
    ''' <summary>Write Debug Log Enable</summary>
    Private _debugMode As Boolean
    ''' <summary>Reserved RAM Memory</summary>
    Private _reservedMemory As UInteger

    ''' <summary>DirectX Force SW TnL</summary>
    Private _forceSW As Boolean
    ''' <summary>DirectX Emulate HW TnL Caps</summary>
    Private _emulateHW As Boolean

    ''' <summary>DirectX Fullscreen Resolution Width</summary>
    Private _fullscreenWidth As UInteger
    ''' <summary>DirectX Fullscreen Resolution Height</summary>
    Private _fullscreenHeight As UInteger
#End Region

#Region "Properties"
    ''' <summary>
    ''' Kitserver Loader Configuration File Name
    ''' </summary>
    ''' <value>String</value>
    ''' <returns>kload.cfg</returns>
    Public Overloads ReadOnly Property FileName As String
        Get
            Return Info.fileName & MyBase.FileName
        End Get
    End Property

    ''' <summary>
    ''' Kitserver Loader Configuration Title Name
    ''' </summary>
    ''' <value>String</value>
    ''' <returns>Kitserver Loader configuration file</returns>
    Public Overloads ReadOnly Property TitleName As String
        Get
            Return Info.titleName & MyBase.TitleName
        End Get
    End Property


    ''' <summary>
    ''' Kitserver Loader Configuration GDB Directory Name
    ''' </summary>
    ''' <value>String</value>
    ''' <returns>_</returns>
    Public Property GdbDirectory As String
        Get
            Return _gdbDir
        End Get
        Set(value As String)
            _gdbDir = value
        End Set
    End Property
    ''' <summary>
    ''' Kitserver Loader Configuration Write Debug Log (Mode Enable)
    ''' </summary>
    ''' <value>Boolean</value>
    ''' <returns>_debugMode</returns>
    Public Property DebugMode As Boolean
        Get
            Return _debugMode
        End Get
        Set(value As Boolean)
            _debugMode = value
        End Set
    End Property
    ''' <summary>
    ''' Kitserver Loader Configuration Reserved ROM Memory
    ''' </summary>
    ''' <value>Unsigned Integer</value>
    ''' <returns>_lenghtName</returns>
    Public Property ReservedMemory As UInteger
        Get
            Return _reservedMemory
        End Get
        Set(value As UInteger)
            _reservedMemory = value
        End Set
    End Property

    ''' <summary>
    ''' Kitserver Loader Configuration 3D Analyzer Enable
    ''' </summary>
    ''' <value>Unsigned Integer</value>
    ''' <returns>_lenghtName</returns>
    Public Property Analyzer3D As Boolean
        Get
            Return _forceSW
        End Get
        Set(value As Boolean)
            _forceSW = value
            _emulateHW = value
        End Set
    End Property

    ''' <summary>
    ''' Kitserver Loader Configuration Fullscreen Resolution Width
    ''' </summary>
    ''' <value>Unsigned Integer</value>
    ''' <returns>_fullscreenWidth</returns>
    Public Property FullscreenWidth As UInteger
        Get
            Return _fullscreenWidth
        End Get
        Set(value As UInteger)
            _fullscreenWidth = value
        End Set
    End Property
    ''' <summary>
    ''' Kitserver Loader Configuration Fullscreen Resolution Height
    ''' </summary>
    ''' <value>Unsigned Integer</value>
    ''' <returns>_fullscreenHeight</returns>
    Public Property FullscreenHeight As UInteger
        Get
            Return _fullscreenHeight
        End Get
        Set(value As UInteger)
            _fullscreenHeight = value
        End Set
    End Property
#End Region

#Region "Constructors"
    ''' <summary>
    ''' Default Main Constructor
    ''' </summary>
    ''' <remarks>Setting parameters of the initial value</remarks>
    Public Sub New()
        DefaultValue()
    End Sub
#End Region

#Region "Methods"
    ''' <summary>
    ''' Setting the initial configuration values
    ''' </summary>
    Private Sub DefaultValue()
        _gdbDir = ".\"
        _debugMode = False
        _reservedMemory = 268435456 '256 MB
        'Settings parameters for 3D Analyzer
        _forceSW = False
        _emulateHW = False
        'Fullscreen Resolution on Full HD (FHD) 1080p
        _fullscreenWidth = 1920
        _fullscreenHeight = 1080
    End Sub


    ''' <summary>
    ''' Generated content with the current configuration parameter values
    ''' </summary>
    ''' <returns>String</returns>
    Private Function GenerateData() As String
        Dim dataText As String
        Dim equally As String = " = "
        Dim kitserver As String = "kitserver\"

        dataText = Parameter.debugMode & equally & MyBase.ConvertEnable(_debugMode) & Environment.NewLine
        dataText += Parameter.gdbDir & equally & ControlChars.Quote & _gdbDir & ControlChars.Quote & Environment.NewLine
        dataText += Parameter.reservedMemory & equally & _reservedMemory.ToString() & Environment.NewLine & Environment.NewLine

        dataText += "# Include modules" & Environment.NewLine
        dataText += Parameter.dllNum & equally & "14" & Environment.NewLine
        dataText += Parameter.dllPath & "0" & equally & ControlChars.Quote & kitserver & "zlib1.dll" & ControlChars.Quote & Environment.NewLine
        dataText += Parameter.dllPath & "1" & equally & ControlChars.Quote & kitserver & "libpng13.dll" & ControlChars.Quote & Environment.NewLine
        dataText += Parameter.dllPath & "2" & equally & ControlChars.Quote & kitserver & "afs2fs.dll" & ControlChars.Quote & Environment.NewLine
        dataText += Parameter.dllPath & "3" & equally & ControlChars.Quote & kitserver & "kserv.dll" & ControlChars.Quote & Environment.NewLine
        dataText += Parameter.dllPath & "4" & equally & ControlChars.Quote & kitserver & "bserv.dll" & ControlChars.Quote & Environment.NewLine
        dataText += Parameter.dllPath & "5" & equally & ControlChars.Quote & kitserver & "fserv.dll" & ControlChars.Quote & Environment.NewLine
        dataText += Parameter.dllPath & "6" & equally & ControlChars.Quote & kitserver & "bootserv.dll" & ControlChars.Quote & Environment.NewLine
        dataText += Parameter.dllPath & "7" & equally & ControlChars.Quote & kitserver & "stadium.dll" & ControlChars.Quote & Environment.NewLine
        dataText += Parameter.dllPath & "8" & equally & ControlChars.Quote & kitserver & "lodmixer.dll" & ControlChars.Quote & Environment.NewLine
        dataText += Parameter.dllPath & "9" & equally & ControlChars.Quote & kitserver & "dxtools.dll" & ControlChars.Quote & Environment.NewLine
        dataText += Parameter.dllPath & "10" & equally & ControlChars.Quote & kitserver & "clock.dll" & ControlChars.Quote & Environment.NewLine
        dataText += Parameter.dllPath & "11" & equally & ControlChars.Quote & kitserver & "psc.dll" & ControlChars.Quote & Environment.NewLine
        dataText += Parameter.dllPath & "12" & equally & ControlChars.Quote & kitserver & "speeder.dll" & ControlChars.Quote & Environment.NewLine
        dataText += Parameter.dllPath & "13" & equally & ControlChars.Quote & kitserver & "camerazoomer.dll" & ControlChars.Quote & Environment.NewLine & Environment.NewLine

        dataText += "# DirectX Options" & Environment.NewLine
        dataText += Parameter.forceSW & equally & MyBase.ConvertEnable(_forceSW) & Environment.NewLine
        dataText += Parameter.emulateHW & equally & MyBase.ConvertEnable(_emulateHW) & Environment.NewLine
        dataText += "# " & Parameter.fullscreenWidth & equally & _fullscreenWidth & Environment.NewLine
        dataText += "# " & Parameter.fullscreenHeight & equally & _fullscreenHeight

        Return dataText
    End Function

    ''' <summary>
    ''' The function shows the error message to read
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks>The function returns true if the parameter is corrected</remarks>
    Private Function ReadError() As Boolean
        Dim tmpText As String
        Dim msgResult As DialogResult
        Dim msgText As MessageText = New MessageText()
        Dim msgTitle As MessageTitle = New MessageTitle()

        tmpText = TitleName & msgText.ID10 & Environment.NewLine & msgText.ID01

        msgResult = MessageBox.Show(tmpText, msgTitle.TitleWarning, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If msgResult = DialogResult.Yes Then
            If CreateFile() Then
                Return True
            End If
        End If

        Return False
    End Function

    ''' <summary>
    ''' The function checks the existence of a configuration file
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks>The function gives a message in error</remarks>
    Public Overloads Function ExistFile() As Boolean

        If MyBase.ExistFile(FileName, TitleName, GenerateData()) Then
            Return True
        Else
            Return False
        End If

    End Function

    ''' <summary>
    ''' The function deletes a configuration file
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks>The function gives a message in error</remarks>
    Public Overloads Function DeleteFile() As Boolean

        If MyBase.DeleteFile(FileName, TitleName) Then
            Return True
        Else
            Return False
        End If

    End Function

    ''' <summary>
    ''' The function creates a new configuration file
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks>The function gives a message in error</remarks>
    Public Overloads Function CreateFile() As Boolean

        If MyBase.CreateFile(FileName, TitleName, GenerateData()) Then
            Return True
        Else
            Return False
        End If

    End Function

    ''' <summary>
    ''' The function writes values in the configuration file
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks>The function gives a message in error</remarks>
    Public Overloads Function WriteFile() As Boolean

        If MyBase.WriteFile(FileName, TitleName, GenerateData()) Then
            Return True
        Else
            Dim tmpText As String
            Dim msgText As MessageText = New MessageText()
            Dim msgTitle As MessageTitle = New MessageTitle()

            tmpText = TitleName & msgText.ID11 & Environment.NewLine & msgText.ID00
            MessageBox.Show(tmpText, msgTitle.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        Return False
    End Function

    ''' <summary>
    ''' The function reads the values from the configuration file
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks>The function gives a message in error</remarks>
    Public Overloads Function ReadFile() As Boolean
        Dim readValue As String

        'readValue = MyBase.ReadFile(FileName, Parameter.gdbDir, False)
        'If Not readValue = Nothing Then
        '    Dim index As Integer

        '    index = readValue.IndexOf(ControlChars.Quote)
        '    If Not index = -1 Then
        '        _gdbDir = readValue.Substring(index).Replace(ControlChars.Quote, "")
        '    Else
        '        Return ReadError()
        '    End If
        'End If

        readValue = MyBase.ReadFile(FileName, Parameter.reservedMemory)
        If IsNumeric(readValue) Then
            _reservedMemory = CType(readValue, UInteger)
        Else
            Return ReadError()
        End If

        'Read Force and Emulate for 3D Analyzer
        readValue = MyBase.ReadFile(FileName, Parameter.forceSW)
        If IsNumeric(readValue) Then
            _forceSW = MyBase.ConvertEnable(readValue)
        Else
            Return ReadError()
        End If
        readValue = MyBase.ReadFile(FileName, Parameter.emulateHW)
        If IsNumeric(readValue) Then
            _emulateHW = MyBase.ConvertEnable(readValue)
        Else
            Return ReadError()
        End If
        'Check that you are equal to their parameters
        If Not _forceSW = _emulateHW Then
            Analyzer3D = False
            Return ReadError()
        End If

        Return True
    End Function
#End Region


End Class
