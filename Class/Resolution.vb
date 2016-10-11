Imports System.Runtime.InteropServices
Public NotInheritable Class Resolution

    'Detect Display 
    Private Declare Function EnumDisplaySettings _
        Lib "user32" Alias "EnumDisplaySettingsA" _
            (ByVal lpszDeviceName As Integer, _
             ByVal iModeNum As Integer, _
             ByRef lpdmode As DEVMODE) As Boolean

    Private Declare Function ChangeDisplaySettings _
        Lib "user32" Alias "ChangeDisplaySettingsA" _
            (ByRef DEVMODE As DEVMODE, _
             ByVal flags As Integer) As Integer


    Private Const ENUM_CURRENT_SETTINGS As Integer = -1
    Private Const CDS_UPDATEREGISTRY As Integer = &H1
    Private Const CDS_TEST As Long = &H2

    Private Const CCDEVICENAME As Integer = 32
    Private Const CCFORMNAME As Integer = 32

    Private Const DISP_CHANGE_SUCCESSFUL As Integer = 0
    Private Const DISP_CHANGE_RESTART As Integer = 1
    Private Const DISP_CHANGE_FAILED As Integer = -1

    'Public Const dm_BITSPERPEL As Integer = &H40000
    'Public Const dm_PELSWIDTH As Integer = &H80000
    'Public Const dm_PELSHEIGHT As Integer = &H100000
    'Public Const dm_DISPLAYFLAGS As Integer = &H200000

    <StructLayout(LayoutKind.Sequential)>
    Private Structure DEVMODE
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
        Public dmUnusedPadding As Short
        Public dmBitsPerPel As Short
        Public dmPelsWidth As Integer
        Public dmPelsHeight As Integer

        Public dmDisplayFlags As Integer
        Public dmDisplayFrequency As Integer
    End Structure

    Private _resolutionWidth As List(Of Integer)
    Private _resolutionHeight As List(Of Integer)

    Public Sub New()
        Dim dMode = -1
        Dim DevM As DEVMODE
        _resolutionWidth = New List(Of Integer)
        _resolutionHeight = New List(Of Integer)

        DevM.dmDeviceName = New [String](New Char(32) {})
        DevM.dmFormName = New [String](New Char(32) {})
        DevM.dmSize = CShort(Marshal.SizeOf(GetType(DEVMODE)))

        Do While EnumDisplaySettings(Nothing, dMode, DevM) = True
            If DevM.dmPelsWidth >= 640 And DevM.dmPelsHeight >= 480 Then
                If CInt(DevM.dmFields) = 8126592 And CInt(DevM.dmDefaultSource) = 0 Then
                    If CInt(DevM.dmBitsPerPel) = 16 And CInt(DevM.dmDisplayFrequency) = 60 Then
                        _resolutionWidth.Add(CInt(DevM.dmPelsWidth))
                        _resolutionHeight.Add(CInt(DevM.dmPelsHeight))
                    End If
                End If
            End If

            dMode += 1
        Loop
    End Sub

    Public ReadOnly Property Width As List(Of Integer)
        Get
            Return _resolutionWidth
        End Get
    End Property

    Public ReadOnly Property Height As List(Of Integer)
        Get
            Return _resolutionHeight
        End Get
    End Property

    Private Function LVAdd(DevM) As String
        If CStr(DevM.dmFields) = "8126592" And CStr(DevM.dmDefaultSource) = "0" And CStr(DevM.dmBitsPerPel) = 16 And CStr(DevM.dmDisplayFrequency) = 60 Then
            Return (CStr(DevM.dmPelsWidth) & "x" & CStr(DevM.dmPelsHeight)).ToString
        Else
            Return Nothing
        End If
    End Function

End Class
