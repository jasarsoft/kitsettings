Imports System.Runtime.InteropServices

' Custom class for display detection
' Used literature with CodeGuru website.
Namespace Classes
    ''' <summary>
    ''' Display information computer
    ''' </summary>
    Public NotInheritable Class Display

        ''' <summary>
        ''' Collection of information on the computer display
        ''' </summary>
        ''' <param name="lpszDeviceName"></param>
        ''' <param name="iModeNum"></param>
        ''' <param name="lpdmode"></param>
        ''' <returns>Boolean</returns>
        ''' <remarks>Used library 'user32.dll of windows</remarks>
        Private Declare Function EnumDisplaySettings _
            Lib "user32" Alias "EnumDisplaySettingsA" _
                (ByVal lpszDeviceName As Integer, _
                 ByVal iModeNum As Integer, _
                 ByRef lpdmode As DevMode) As Boolean

        ''' <summary>
        ''' Parameter settings for the display
        ''' </summary>
        ''' <param name="DEVMODE"></param>
        ''' <param name="flags"></param>
        ''' <returns>Integer</returns>
        ''' <remarks>Used library 'user32.dll of windows</remarks>
        Private Declare Function ChangeDisplaySettings _
            Lib "user32" Alias "ChangeDisplaySettingsA" _
                (ByRef DEVMODE As DevMode, _
                 ByVal flags As Integer) As Integer


        Private Const ENUM_CURRENT_SETTINGS As Integer = -1
        Private Const CDS_UPDATEREGISTRY As Integer = &H1
        Private Const CDS_TEST As Long = &H2

        Private Const CCDEVICENAME As Integer = 32
        Private Const CCFORMNAME As Integer = 32

        Private Const DISP_CHANGE_SUCCESSFUL As Integer = 0
        Private Const DISP_CHANGE_RESTART As Integer = 1
        Private Const DISP_CHANGE_FAILED As Integer = -1

        Public Const dm_BITSPERPEL As Integer = &H40000
        Public Const dm_PELSWIDTH As Integer = &H80000
        Public Const dm_PELSHEIGHT As Integer = &H100000
        Public Const dm_DISPLAYFLAGS As Integer = &H200000

        ''' <summary>
        ''' The structure of the display information
        ''' </summary>
        <StructLayout(LayoutKind.Sequential)>
        Private Structure DevMode
            <MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst:=CCDEVICENAME)>
            Public dmDeviceName As String
            Public dmSpecVersion As Short
            Public dmDriverVersion As Short
            Public dmSize As Short
            Public dmDriverExtra As Short
            Public dmFields As Integer

            Public dmOrientation As Short
            Public dmPaperSize As Short
            Public dmPaperLength As Short
            Public dmPaperWidth As Short

            Public dmScale As Short
            Public dmCopies As Short
            Public dmDefaultSource As Short
            Public dmPrintQuality As Short
            Public dmColor As Short
            Public dmDuplex As Short
            Public dmYResolution As Short
            Public dmTTOption As Short
            Public dmCollate As Short

            <MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst:=CCFORMNAME)>
            Public dmFormName As String
            Public dmLogPixels As Short
            Public dmBitsPerPel As Short

            Public dmPelsWidth As Integer
            Public dmPelsHeight As Integer

            Public dmDisplayFlags As Integer
            Public dmDisplayFrequency As Integer

            Public dmICMMethod As Integer
            Public dmICMIntent As Integer

            Public dmMediaType As Integer
            Public dmDitherType As Integer

            Public dmReserved1 As Integer
            Public dmReserved2 As Integer

            Public dmPanningWidth As Integer
            Public dmPanningHeight As Integer
            Public dmUnusedPadding As Short
        End Structure

        Private _resolutionWidth As List(Of Integer)
        Private _resolutionHeight As List(Of Integer)

        ''' <summary>
        ''' Default Constructor
        ''' </summary>
        ''' <remarks>Generates supported resolution</remarks>
        Public Sub New()
            Dim dMode = -1
            Dim devMode As DevMode
            _resolutionWidth = New List(Of Integer)
            _resolutionHeight = New List(Of Integer)

            devMode.dmDeviceName = New [String](New Char(32) {})
            devMode.dmFormName = New [String](New Char(32) {})
            devMode.dmSize = CShort(Marshal.SizeOf(GetType(DevMode)))

            Do While EnumDisplaySettings(Nothing, dMode, devMode) = True
                If devMode.dmPelsWidth >= 640 And devMode.dmPelsHeight >= 480 Then
                    If CInt(devMode.dmFields) = 8126592 And CInt(devMode.dmDefaultSource) = 0 Then
                        If CInt(devMode.dmBitsPerPel) = 16 And CInt(devMode.dmDisplayFrequency) = 60 Then
                            _resolutionWidth.Add(CInt(devMode.dmPelsWidth))
                            _resolutionHeight.Add(CInt(devMode.dmPelsHeight))
                        End If
                    End If
                End If

                dMode += 1
            Loop
        End Sub

        ''' <summary>
        ''' A list of supported resolution Width
        ''' </summary>
        ''' <value>List(Integer)</value>
        ''' <returns>_resoutionWidth</returns>
        Public ReadOnly Property Width As List(Of Integer)
            Get
                Return _resolutionWidth
            End Get
        End Property

        ''' <summary>
        ''' A list of supported resolution Height
        ''' </summary>
        ''' <value>List(Integer)</value>
        ''' <returns>_resoutionHeight</returns>
        Public ReadOnly Property Height As List(Of Integer)
            Get
                Return _resolutionHeight
            End Get
        End Property

    End Class
End Namespace