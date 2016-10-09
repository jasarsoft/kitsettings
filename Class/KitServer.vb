
''' <summary>
''' Kitserver 6 Settings Kit Setver Configuration File
''' </summary>
Public NotInheritable Class KitServer
    Inherits ConfigurationFile

#Region "Constants"
    ''' <summary>
    ''' Kit Server Main Information
    ''' </summary>
    Private Structure Info
        ''' <summary>Kit Server Configuration File Name</summary>
        Public Const fileName As String = "kserv"
        ''' <summary>Kit Server Configuration Title Name</summary>
        Public Const titleName As String = "Kit Server"
    End Structure

    ''' <summary>
    ''' Kit Server Configuration Parameter
    ''' </summary>
    Private Structure Parameter
        ''' <summary>Configuration Parameter HD Kits Enable</summary>
        Public Const hdKits As String = "HD-kits.enabled"
        ''' <summary>Configuration Parameter Debug Enable</summary>
        Public Const debugMode As String = "debug"
        ''' <summary>Configuration Parameter Show Kit Info</summary>
        Public Const showKitInfo As String = "ShowKitInfo"
        ''' <summary>Configuration Parameter Mini Kits Wide Backs Values</summary>
        Public Const miniKitsWide As String = "mini-kits.wide-backs"
        ''' <summary>Configuration Parameter Mini Kits Narrow Backs Values</summary>
        Public Const miniKitsNarrow As String = "mini-kits.narrow-backs"
        ''' <summary>Configuration Parameter Mini Kits Squashed With Logo Values</summary>
        Public Const miniKitsSquashed As String = "mini-kits.squashed-with-logo"
        ''' <summary>Configuration Parameter Key Home Kit</summary>
        Public Const keyHomeKit As String = "vKey.homeKit"
        ''' <summary>Configuration Parameter Key Away Kit</summary>
        Public Const keyAwayKit As String = "vKey.awayKit"
        ''' <summary>Configuration Parameter Kit GK Home Kit</summary>
        Public Const keyGkHomeKit As String = "vKey.gkHomeKit"
        ''' <summary>Configuration Parameter Kit GK Away Kit</summary>
        Public Const keyGkAwayKit As String = "vKey.gkAwayKit"
    End Structure
#End Region

#Region "Variables"
    ''' <summary>Show Kit Info Enable</summary>
    Private _showKitInfo As Boolean
    ''' <summary>Debug Mode Enable</summary>
    Private _debugEnable As Boolean
    ''' <summary>HD Kits Enable</summary>
    Private _hdKitsEnable As Boolean
#End Region

#Region "Properties"
    ''' <summary>
    ''' Kit Server Configuration File Name
    ''' </summary>
    ''' <value>String</value>
    ''' <returns>bootserv.cfg</returns>
    Public Overloads ReadOnly Property FileName As String
        Get
            Return Info.fileName & MyBase.FileName
        End Get
    End Property
    ''' <summary>
    ''' Kit Server Configuration Title Name
    ''' </summary>
    ''' <value>String</value>
    ''' <returns>Kit Server configuration file</returns>
    Public Overloads ReadOnly Property TitleName As String
        Get
            Return Info.titleName & MyBase.TitleName
        End Get
    End Property

    ''' <summary>
    ''' Kit Server Configuration Show Kit Info
    ''' </summary>
    ''' <value>Boolean</value>
    ''' <returns>_showKitInfo</returns>
    Public Property ShowKitInfo As Boolean
        Get
            Return _showKitInfo
        End Get
        Set(value As Boolean)
            _showKitInfo = value
        End Set
    End Property

    ''' <summary>
    ''' Kit Server Configuration Debug Enable
    ''' </summary>
    ''' <value>Boolean</value>
    ''' <returns>_debugEnable</returns>
    Public Property DebugEnable As Boolean
        Get
            Return _debugEnable
        End Get
        Set(value As Boolean)
            _debugEnable = value
        End Set
    End Property

    ''' <summary>
    ''' Kit Server Configuration HD Kits Enable
    ''' </summary>
    ''' <value>Boolean</value>
    ''' <returns>_hdKitsEnable</returns>
    Public Property HdKitsEnable As Boolean
        Get
            Return _hdKitsEnable
        End Get
        Set(value As Boolean)
            _hdKitsEnable = value
        End Set
    End Property
#End Region

#Region "Constructors"
    ''' <summary>
    ''' Default Main Constructor
    ''' </summary>
    ''' <remarks>Setting initial values for private variables</remarks>
    Public Sub New()
        DefaultValue()
    End Sub
#End Region

#Region "Methods"
    ''' <summary>
    ''' Setting the initial configuration values
    ''' </summary>
    Private Sub DefaultValue()
        _showKitInfo = True
        _debugEnable = False
        _hdKitsEnable = True
    End Sub

    ''' <summary>
    ''' Generated content with the current configuration parameter values
    ''' </summary>
    ''' <returns>String</returns>
    Private Function GenerateData() As String
        Dim dataText As String
        Dim equally As String = " = "

        dataText = Parameter.debugMode & equally & MyBase.ConvertEnable(_debugEnable) & Environment.NewLine
        dataText += Parameter.showKitInfo & equally & MyBase.ConvertEnable(_showKitInfo) & Environment.NewLine
        dataText += Parameter.hdKits & equally & MyBase.ConvertEnable(_hdKitsEnable) & Environment.NewLine & Environment.NewLine
        dataText += "# mini-kits model map." & Environment.NewLine
        dataText += "# Needed only for correct display of mini-kits, but doesn't affect the in-game kits." & Environment.NewLine
        dataText += "# Note: the map might be incomplete, so feel free to add the model numbers to correct groups, if you notice that a mini-kit for certain model is rendered incorrectly." & Environment.NewLine & Environment.NewLine
        dataText += "mini-kits.narrow-backs = [8]" & Environment.NewLine
        dataText += "mini-kits.wide-backs = [0,1,2,3,4,9,10,11,12,13,14,15,17,24,26,34,36,37,38,39,44,51,55,57,59,60,62,64,77,78,80,86,87,88,93,94,100,101,102,103,104,105,106,107,114]" & Environment.NewLine
        dataText += "mini-kits.squashed-with-logo = [18,19,20,21,49,54,61,68,69,70,74,91,115,116,117,118,124,125,126,127,128,129,132,134,137,138,139,140,146,147,148]" & Environment.NewLine & Environment.NewLine
        dataText += "# Any other other model is assumed to be 'squashed-without-logo' (meaning the new PES6 model with squashed shirt, but no logo in the bottom-right area of the texture.)" & Environment.NewLine
        dataText += "# Some examples: 31,71,84,etc."

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

        readValue = MyBase.ReadFile(FileName, Parameter.hdKits)
        If IsNumeric(readValue) Then
            _hdKitsEnable = MyBase.ConvertValue(readValue)
        Else
            Return ReadError()
        End If

        readValue = MyBase.ReadFile(FileName, Parameter.debug)
        If IsNumeric(readValue) Then
            _debugEnable = MyBase.ConvertValue(readValue)
        Else
            Return ReadError()
        End If

        readValue = MyBase.ReadFile(FileName, Parameter.showKitInfo)
        If IsNumeric(readValue) Then
            _showKitInfo = MyBase.ConvertValue(readValue)
        Else
            Return ReadError()
        End If

        Return True
    End Function
#End Region

End Class
