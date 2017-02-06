Imports System.IO

''' <summary>
''' Kitserver 6 Help File Class
''' </summary>
Public NotInheritable Class KitserverHelp

    ''' <summary>Message content</summary>
    Private _message As String
    ''' <summary>Name the file series</summary>
    Private _fileName(47) As String
    ''' <summary>Hash value of the file form a series</summary>
    Private _fileHash(47) As String

    ''' <summary>The directory path for help files</summary>
    Private Const _dirName As String = "docs"

#Region "Properties"
    ''' <summary>
    ''' The directory path of Kitserver help file
    ''' </summary>
    ''' <value>String</value>
    ''' <returns>docs</returns>
    Public ReadOnly Property DirName As String
        Get
            Return _dirName
        End Get
    End Property

    ''' <summary>
    ''' The file name of a series
    ''' </summary>
    ''' <param name="index"></param>
    ''' <value>String</value>
    ''' <returns>_fileName(index)</returns>
    ''' <remarks>The domain is 0 to 47th</remarks>
    Public ReadOnly Property FileName(ByVal index As Integer) As String
        Get
            If index < 0 Then
                index = 0
            ElseIf index > 47 Then
                index = 47
            End If

            Return _fileName(index)
        End Get
    End Property

    ''' <summary>
    ''' The text of error message
    ''' </summary>
    ''' <value>String</value>
    ''' <returns>_message</returns>
    Public ReadOnly Property Message As String
        Get
            Return _message
        End Get
    End Property
#End Region

#Region "Constructor"
    ''' <summary>
    ''' Default initialization constructor
    ''' </summary>
    Public Sub New()
        Call FileGenerate()
        Call HashGenerate()
    End Sub
#End Region

#Region "Methods"
    ''' <summary>
    ''' Populating a series of help files
    ''' </summary>
    Private Sub FileGenerate()
        _fileName(0) = "adbtex.gif"             'adbtex.gif
        _fileName(1) = "ball_autorandom.gif"    'ball_autorandom.gif
        _fileName(2) = "ball_gamechoice.gif"    'ball_gamechoice.gif
        _fileName(3) = "ball_home.gif"          'ball_home.gif
        _fileName(4) = "ball_home1.gif"         'ball_home1.gif
        _fileName(5) = "ball_selected.gif"      'ball_selected.gif
        _fileName(6) = "ballsel.jpg"            'ballsel.jpg
        _fileName(7) = "ballsel2.jpg"           'ballsel2.jpg
        _fileName(8) = "circle.gif"             'circle.gif
        _fileName(9) = "cross.gif"              'cross.gif
        _fileName(10) = "dayfine.gif"           'dayfine.gif
        _fileName(11) = "editboot.jpg"          'editboot.jpg
        _fileName(12) = "faceseditmode.jpg"     'faceseditmode.jpg
        _fileName(13) = "france.jpg"            'france.jpg
        _fileName(14) = "gdb.gif"               'gdb.gif
        _fileName(15) = "history.txt"           'history.txt
        _fileName(16) = "hometeam.jpg"          'hometeam.jpg
        _fileName(17) = "install.jpg"           'install.jpg
        _fileName(18) = "keybind.gif"           'keybind.gif
        _fileName(19) = "kit_badge.jpg"         'kit_badge.jpg
        _fileName(20) = "kit_nobadge.jpg"       'kit_nobadge.jpg
        _fileName(21) = "kit_normal_wb.jpg"     'kit_normal_wb.jpg
        _fileName(22) = "l1.gif"                'l1.gif
        _fileName(23) = "l2.gif"                'l2.gif
        _fileName(24) = "lodingame.jpg"         'lodingame.jpg
        _fileName(25) = "lodmixer.gif"          'lodmixer.gif
        _fileName(26) = "lodmixer.txt"          'lodmixer.txt
        _fileName(27) = "manual.html"           'manual.html
        _fileName(28) = "manual-chs.html"       'manual-chs.html
        _fileName(29) = "mask.png"              'mask.png
        _fileName(30) = "overlay.gif"           'overlay.gif
        _fileName(31) = "pa.jpg"                'pa.jpg
        _fileName(32) = "pes6_badge.png"        'pes6_badge.png
        _fileName(33) = "pes6_nobadge.png"      'pes6_nobadge.png
        _fileName(34) = "r1.gif"                'r1.gif
        _fileName(35) = "r2.gif"                'r2.gif
        _fileName(36) = "ramenskoye.gif"        'ramenskoye.gif
        _fileName(37) = "selected.jpg"          'selected.jpg
        _fileName(38) = "setup.gif"             'setup.gif
        _fileName(39) = "setup2.gif"            'setup2.gif
        _fileName(40) = "square.gif"            'square.gif
        _fileName(41) = "stadiums.gif"          'stadiums.gif
        _fileName(42) = "stripsel-gk.jpg"       'stripsel-gk.jpg
        _fileName(43) = "stripsel-pl.jpg"       'stripsel-pl.jpg
        _fileName(44) = "templates.txt"         'templates.txt
        _fileName(45) = "triangle.gif"          'triangle.gif
        _fileName(46) = "uni.txt"               'uni.txt
        _fileName(47) = "viewstadiums.gif"      'viewstadiums.gif
    End Sub

    ''' <summary>
    ''' Populating a series of hash values
    ''' </summary>
    Private Sub HashGenerate()
        _fileHash(0) = "CF7081370B546221B70AABF0CF823DFE"   'adbtex.gif
        _fileHash(1) = "34A10A96D196049F4A38BAA754AEA80F"   'ball_autorandom.gif
        _fileHash(2) = "CC7A4C9BE9EAEC78E12E0EF9DB683E44"   'ball_gamechoice.gif
        _fileHash(3) = "0B4A3A3EA6CD095A37E2C604EE837DF1"   'ball_home.gif
        _fileHash(4) = "F4CE41DA919454EFF0A440D2C8AD506D"   'ball_home1.gif
        _fileHash(5) = "4196E4380F09B68252A664EA13FAAF16"   'ball_selected.gif
        _fileHash(6) = "64AEC6E3573D008F9E34C22304153EB7"   'ballsel.jpg
        _fileHash(7) = "BCFD8013530578E8C38690E8CDA20795"   'ballsel2.jpg
        _fileHash(8) = "757950D45027F7A60323A8FB9354B050"   'circle.gif
        _fileHash(9) = "C4E27252A19CC366BD8C5664FFA45C6F"   'cross.gif
        _fileHash(10) = "7AF5F1688434A4BDEB93BD848F2A1C8E"  'dayfine.gif
        _fileHash(11) = "65AF3D5DE8C952453D84A16C3F2CA277"  'editboot.jpg
        _fileHash(12) = "5153CA825A997351306FDBE51FB0553B"  'faceseditmode.jpg
        _fileHash(13) = "4B41ED27A220EC7B138043A0FB028456"  'france.jpg
        _fileHash(14) = "FAC499993FBFE40ADD30B709BCBEB388"  'gdb.gif
        _fileHash(15) = "1090667124137EB556961DF31AFD60E7"  'history.txt
        _fileHash(16) = "8C88A7D84EB959046074D74F6E0DA1D9"  'hometeam.jpg
        _fileHash(17) = "D6CB7C9D19821CF499DB39156632EA1A"  'install.jpg
        _fileHash(18) = "A46DE70B8ED7B8DB07514955D17EBBC6"  'keybind.gif
        _fileHash(19) = "0659920FBEF6D1F092066F21C0DCB99C"  'kit_badge.jpg
        _fileHash(20) = "95D9A49BF639782FD959D39366BA8553"  'kit_nobadge.jpg
        _fileHash(21) = "21BC162ECBFE6CA4D6E4F997ADF88AE0"  'kit_normal_wb.jpg
        _fileHash(22) = "1ACB45C99B7CCADADCD1CE1F9803AA14"  'l1.gif
        _fileHash(23) = "91C45B9BAC19ED1843E7522F5D628EB1"  'l2.gif
        _fileHash(24) = "74519EABE643C68897F6859C3CBDD881"  'lodingame.jpg
        _fileHash(25) = "7C3857C42CF1981B84382B03C1D0E3DE"  'lodmixer.gif
        _fileHash(26) = "DB4669838DC5035E6DF363DCD386C2A7"  'lodmixer.txt
        _fileHash(27) = "4689C60AA7D146771E123300E74C3249"  'manual.html
        _fileHash(28) = "E5415FDD818A88C9010383EF2AF0730B"  'manual-chs.html
        _fileHash(29) = "3A5D7AB307AA03A85AC67CAAAB74A61F"  'mask.png
        _fileHash(30) = "CD282C9461A8BA96E3E334F892379B1F"  'overlay.gif
        _fileHash(31) = "3A500E71FC82C5456F97FCE41E099059"  'pa.jpg
        _fileHash(32) = "C579663975C4FC3BB8729B0141731488"  'pes6_badge.png
        _fileHash(33) = "63BBD9F9B19097E0E80F140D15640738"  'pes6_nobadge.png
        _fileHash(34) = "5E0CE2BF5F6B538779E70E1BA74E3543"  'r1.gif
        _fileHash(35) = "16162CC36A93BC92DA2A52F3AF31A963"  'r2.gif
        _fileHash(36) = "DABD608839AF741416590B1062B00DBB"  'ramenskoye.gif
        _fileHash(37) = "741B1D27E7AF04BE87BD7AFC8C8AE69B"  'selected.jpg
        _fileHash(38) = "5C5ABEF04EE779B3DCA0FAD64449075A"  'setup.gif
        _fileHash(39) = "8C16EA2B3ED2A69F2530D6FA03B45453"  'setup2.gif
        _fileHash(40) = "C92077413A7DE0AE6B90C5DBABBF2333"  'square.gif
        _fileHash(41) = "6711D0BC85AF321428C996D1E824DF30"  'stadiums.gif
        _fileHash(42) = "B3E10DC5AB71953E55B6210DC8BBA104"  'stripsel-gk.jpg
        _fileHash(43) = "09D48E1E979EB13F62D981B241CCF8B8"  'stripsel-pl.jpg
        _fileHash(44) = "9CDAB3BE039994E4AACEE53F4844D62B"  'templates.txt
        _fileHash(45) = "EDE97EAA54C5662AEDA47C45BC4106B0"  'triangle.gif
        _fileHash(46) = "60D69F259857B59BFC07B3485E6D00A2"  'uni.txt
        _fileHash(47) = "FF4DC38C85735686B060641C3AA0BEC3"  'viewstadiums.gif
    End Sub


    ''' <summary>
    ''' Run Kitserver 6 help
    ''' </summary>
    ''' <returns>Boolean</returns>
    Public Function Run() As Boolean

        If File.Exists(_dirName & "\" & _fileName(27)) Then
            Process.Start(_dirName & "\" & _fileName(27))
            _message = Nothing
            Return True
        Else
            Dim msgText As MessageText

            msgText = New MessageText(_fileName(27))
            _message = msgText.ErrorRun
        End If

        Return False
    End Function

    ''' <summary>
    ''' Checking for all Help files
    ''' </summary>
    ''' <returns>Boolean</returns>
    Public Function Check() As Boolean

        For i As Integer = 0 To _fileName.Length - 1
            If Not File.Exists(_dirName & "\" & _fileName(i)) Then
                Dim msgText As MessageText

                msgText = New MessageText(_fileName(i))
                _message = msgText.ErrorCheck
                Return False
            End If
        Next

        _message = Nothing
        Return True
    End Function

    ''' <summary>
    ''' Validation Help files
    ''' </summary>
    ''' <returns>Boolean</returns>
    Public Function Valid() As Boolean

        Dim hash As Hash = New Hash()

        If Check() Then
            For i As Integer = 0 To _fileName.Length - 1
                If Not hash.HashFileMD5(_dirName & "\" & _fileName(i)) = _fileHash(i) Then
                    Dim msgText As MessageText

                    msgText = New MessageText(_fileName(i))
                    _message = msgText.ErrorValid
                    Return False
                End If
            Next
        Else
            Return False
        End If

        _message = Nothing
        Return True
    End Function
#End Region

#Region "Class"
    ''' <summary>
    ''' Class error message
    ''' </summary>
    Private Class MessageText

#Region "Fields"
        ''' <summary>Field message error</summary>
        Private _msgError As MsgError

        ''' <summary>
        ''' The structure of field for an error message
        ''' </summary>
        Private Structure MsgError
            Public errorRun As String
            Public errorCheck As String
            Public errorValid As String
        End Structure
#End Region

#Region "Properties"
        ''' <summary>
        ''' The text of error message for the run
        ''' </summary>
        ''' <value>String</value>
        ''' <returns>Kitserver help can not be launched. Missing key file 'filename' to see the help.</returns>
        Public ReadOnly Property ErrorRun As String
            Get
                Return _msgError.errorRun
            End Get
        End Property

        ''' <summary>
        ''' The text of error message to check
        ''' </summary>
        ''' <value></value>
        ''' <returns>Kitserver help file 'filename' missing. Do you want to be sure to run and view help?</returns>
        Public ReadOnly Property ErrorCheck As String
            Get
                Return _msgError.errorCheck
            End Get
        End Property

        ''' <summary>
        ''' The text of error message for valid
        ''' </summary>
        ''' <value>String</value>
        ''' <returns>Kitserver help file 'filename' has changed. Help may not give accurative information you seek.</returns>
        Public ReadOnly Property ErrorValid As String
            Get
                Return _msgError.errorValid
            End Get
        End Property
#End Region

#Region "Constructor"
        ''' <summary>
        ''' Default initialzation constructor
        ''' </summary>
        ''' <param name="fileName"></param>
        Public Sub New(ByVal fileName As String)
            _msgError.errorRun = "Kitserver help can not be launched." & Environment.NewLine
            _msgError.errorRun += "Missing key file '" & fileName & "' to see the help."

            _msgError.errorCheck = "Kitserver help file '" & fileName & "' missing." & Environment.NewLine
            _msgError.errorCheck += "Do you want to be sure to run and view help?"

            _msgError.errorValid = "Kitserver help file '" & fileName & "' has changed." & Environment.NewLine
            _msgError.errorValid += "Help may not give accurate information you seek."
        End Sub
#End Region

    End Class
#End Region

End Class