Imports System.IO

Public NotInheritable Class KitserverHelp

    Private _message As String
    Private _fileName(47) As String
    Private _fileHash(47) As String

    Private Const _dirName As String = "docs"

    Public Sub New()
        Call FileGenerate()
        Call HashGenerate()
    End Sub

    Private Sub FileGenerate()
        _fileName(0) = "adbtex.gif"
        _fileName(1) = "ball_autorandom.gif"
        _fileName(2) = "ball_gamechoice.gif"
        _fileName(3) = "ball_home.gif"
        _fileName(4) = "ball_home1.gif"
        _fileName(5) = "ball_selected.gif"
        _fileName(6) = "ballsel.jpg"
        _fileName(7) = "ballsel2.jpg"
        _fileName(8) = "circle.gif"
        _fileName(9) = "cross.gif"
        _fileName(10) = "dayfine.gif"
        _fileName(11) = "editboot.jpg"
        _fileName(12) = "faceseditmode.jpg"
        _fileName(13) = "france.jpg"
        _fileName(14) = "gdb.gif"
        _fileName(15) = "history.txt"
        _fileName(16) = "hometeam.jpg"
        _fileName(17) = "install.jpg"
        _fileName(18) = "keybind.gif"
        _fileName(19) = "kit_badge.jpg"
        _fileName(20) = "kit_nobadge.jpg"
        _fileName(21) = "kit_normal_wb.jpg"
        _fileName(22) = "l1.gif"
        _fileName(23) = "l2.gif"
        _fileName(24) = "lodingame.jpg"
        _fileName(25) = "lodmixer.gif"
        _fileName(26) = "lodmixer.txt"
        _fileName(27) = "manual.html"
        _fileName(28) = "manual-chs.html"
        _fileName(29) = "mask.png"
        _fileName(30) = "overlay.gif"
        _fileName(31) = "pa.jpg"
        _fileName(32) = "pes6_badge.png"
        _fileName(33) = "pes6_nobadge.png"
        _fileName(34) = "r1.gif"
        _fileName(35) = "r2.gif"
        _fileName(36) = "ramenskoye.gif"
        _fileName(37) = "selected.jpg"
        _fileName(38) = "setup.gif"
        _fileName(39) = "setup2.gif"
        _fileName(40) = "square.gif"
        _fileName(41) = "stadiums.gif"
        _fileName(42) = "stripsel-gk.jpg"
        _fileName(43) = "stripsel-pl.jpg"
        _fileName(44) = "templates.txt"
        _fileName(45) = "triangle.gif"
        _fileName(46) = "uni.txt"
        _fileName(47) = "viewstadiums.gif"
    End Sub

    Private Sub HashGenerate()
        _fileHash(0) = "CF7081370B546221B70AABF0CF823DFE"
        _fileHash(1) = "34A10A96D196049F4A38BAA754AEA80F"
        _fileHash(2) = "CC7A4C9BE9EAEC78E12E0EF9DB683E44"
        _fileHash(3) = "0B4A3A3EA6CD095A37E2C604EE837DF1"
        _fileHash(4) = "F4CE41DA919454EFF0A440D2C8AD506D"
        _fileHash(5) = "4196E4380F09B68252A664EA13FAAF16"
        _fileHash(6) = "64AEC6E3573D008F9E34C22304153EB7"
        _fileHash(7) = "BCFD8013530578E8C38690E8CDA20795"
        _fileHash(8) = "757950D45027F7A60323A8FB9354B050"
        _fileHash(9) = "C4E27252A19CC366BD8C5664FFA45C6F"
        _fileHash(10) = "7AF5F1688434A4BDEB93BD848F2A1C8E"
        _fileHash(11) = "65AF3D5DE8C952453D84A16C3F2CA277"
        _fileHash(12) = "5153CA825A997351306FDBE51FB0553B"
        _fileHash(13) = "4B41ED27A220EC7B138043A0FB028456"
        _fileHash(14) = "FAC499993FBFE40ADD30B709BCBEB388"
        _fileHash(15) = "1090667124137EB556961DF31AFD60E7"
        _fileHash(16) = "8C88A7D84EB959046074D74F6E0DA1D9"
        _fileHash(17) = "D6CB7C9D19821CF499DB39156632EA1A"
        _fileHash(18) = "A46DE70B8ED7B8DB07514955D17EBBC6"
        _fileHash(19) = "0659920FBEF6D1F092066F21C0DCB99C"
        _fileHash(20) = "95D9A49BF639782FD959D39366BA8553"
        _fileHash(21) = "21BC162ECBFE6CA4D6E4F997ADF88AE0"
        _fileHash(22) = "1ACB45C99B7CCADADCD1CE1F9803AA14"
        _fileHash(23) = "91C45B9BAC19ED1843E7522F5D628EB1"
        _fileHash(24) = "74519EABE643C68897F6859C3CBDD881"
        _fileHash(25) = "7C3857C42CF1981B84382B03C1D0E3DE"
        _fileHash(26) = "DB4669838DC5035E6DF363DCD386C2A7"
        _fileHash(27) = "4689C60AA7D146771E123300E74C3249"
        _fileHash(28) = "E5415FDD818A88C9010383EF2AF0730B"
        _fileHash(29) = "3A5D7AB307AA03A85AC67CAAAB74A61F"
        _fileHash(30) = "CD282C9461A8BA96E3E334F892379B1F"
        _fileHash(31) = "3A500E71FC82C5456F97FCE41E099059"
        _fileHash(32) = "C579663975C4FC3BB8729B0141731488"
        _fileHash(33) = "63BBD9F9B19097E0E80F140D15640738"
        _fileHash(34) = "5E0CE2BF5F6B538779E70E1BA74E3543"
        _fileHash(35) = "16162CC36A93BC92DA2A52F3AF31A963"
        _fileHash(36) = "DABD608839AF741416590B1062B00DBB"
        _fileHash(37) = "741B1D27E7AF04BE87BD7AFC8C8AE69B"
        _fileHash(38) = "5C5ABEF04EE779B3DCA0FAD64449075A"
        _fileHash(39) = "8C16EA2B3ED2A69F2530D6FA03B45453"
        _fileHash(40) = "C92077413A7DE0AE6B90C5DBABBF2333"
        _fileHash(41) = "6711D0BC85AF321428C996D1E824DF30"
        _fileHash(42) = "B3E10DC5AB71953E55B6210DC8BBA104"
        _fileHash(43) = "09D48E1E979EB13F62D981B241CCF8B8"
        _fileHash(44) = "9CDAB3BE039994E4AACEE53F4844D62B"
        _fileHash(45) = "EDE97EAA54C5662AEDA47C45BC4106B0"
        _fileHash(46) = "60D69F259857B59BFC07B3485E6D00A2"
        _fileHash(47) = "FF4DC38C85735686B060641C3AA0BEC3"
    End Sub

    Public ReadOnly Property DirName As String
        Get
            Return _dirName
        End Get
    End Property

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

    Public ReadOnly Property Message As String
        Get
            Return _message
        End Get
    End Property

    Public Function Run() As Boolean

        If File.Exists(_dirName & "\" & _fileName(27)) Then
            Process.Start(_dirName & "\" & _fileName(27))
            Return True
        Else
            Dim msgText As MessageText

            msgText = New MessageText(_fileName(27))
            _message = msgText.ErrorRun
        End If

        Return False
    End Function

    Public Function Check() As Boolean

        For i As Integer = 0 To _fileName.Length - 1
            If Not File.Exists(_dirName & "\" & _fileName(i)) Then
                Dim msgText As MessageText

                msgText = New MessageText(_fileName(i))
                _message = msgText.ErrorCheck
                Return False
            End If
        Next

        Return True
    End Function

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

        Return True
    End Function

    Private Class MessageText

        Private Structure MsgError
            Public Shared errorRun As String
            Public Shared errorCheck As String
            Public Shared errorValid As String
        End Structure

        Public Sub New(ByVal fileName As String)
            MsgError.errorRun = "Kitserver help can not be launched." & Environment.NewLine
            MsgError.errorRun += "Missing key file '" & fileName & "' to see the help."

            MsgError.errorCheck = "Kitserver help file '" & fileName & "' missing." & Environment.NewLine
            MsgError.errorCheck += "Do you want to be sure to run and view help?"

            MsgError.errorValid = "Kitserver help file '" & fileName & "' has changed." & Environment.NewLine
            MsgError.errorValid += "Help may not give accurate information you seek."
        End Sub

        Public ReadOnly Property ErrorRun As String
            Get
                Return MsgError.errorRun
            End Get
        End Property

        Public ReadOnly Property ErrorCheck As String
            Get
                Return MsgError.errorCheck
            End Get
        End Property

        Public ReadOnly Property ErrorValid As String
            Get
                Return MsgError.errorValid
            End Get
        End Property
    End Class

End Class
