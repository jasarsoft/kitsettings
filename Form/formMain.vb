Public Class formMain

    Dim afs2fs As Afs2fs
    Dim ballServer As BallServer
    Dim bootServer As BootServer
    Dim cameraZoomer As CameraZoomer
    Dim kitServer As KitServer
    Dim kitLoader As KitLoader
    Dim speeder As Speeder
    Dim resolution As Resolution

    Private Delegate Function Save() As Boolean


    Public Sub New()
        ' Initialization designer components
        InitializeComponent()

        ' Initialization class
        afs2fs = New Afs2fs()
        ballServer = New BallServer()
        bootServer = New BootServer()
        cameraZoomer = New CameraZoomer()
        kitServer = New KitServer()
        kitLoader = New KitLoader()
        speeder = New Speeder()
        resolution = New Resolution()
    End Sub

    Private Sub DefaultValue()
        Me.comboHDKits.SelectedIndex = 1 'Set True
        Me.comboBallPreview.SelectedIndex = 1
        Me.comboLowBoots.SelectedIndex = 0 'Set False
        Me.comboRandomBoots.SelectedIndex = 0
        Me.comboStadiumRoof.SelectedIndex = 0
        Me.comboStadiumClipping.SelectedIndex = 1
        Me.numericCameraZoom.Value = 1200I
        Me.numericSpeedModule.Value = 0.94D
        Me.numericReservedMemory.Value = 256I
        Me.combo3DAnalyzer.SelectedIndex = 0
        Me.comboRenderDirectX.SelectedIndex = 0

        'Resolution
        Dim i As Integer = 0
        For Each value As Integer In resolution.Width
            Me.comboFullscreenResolution.Items.Add(resolution.Width.Item(i).ToString() & "x" & resolution.Height.Item(i).ToString())
            i += 1 'i = i + 1
        Next
    End Sub

    Private Sub ReadSettings()
        kitServer.HdKitsEnable = Combo.GetBoolValue(Me.comboHDKits)
        ballServer.BallPreview = Combo.GetBoolValue(Me.comboBallPreview)
        bootServer.VersionBoots = Combo.GetBoolValue(Me.comboLowBoots)
        bootServer.RandomBoots = Combo.GetBoolValue(Me.comboRandomBoots)
        cameraZoomer.StadiumRoof = Combo.GetBoolValue(Me.comboStadiumRoof)
        cameraZoomer.StadiumClipping = Combo.GetBoolValue(Me.comboStadiumClipping)
        cameraZoomer.CameraZoom = CType(Me.numericCameraZoom.Value, Integer)
        speeder.CountFactor = CType(Me.numericSpeedModule.Value, Double)
        kitLoader.ReservedMemory = CType(Me.numericReservedMemory.Value * 1024 * 1024, UInteger)
        kitLoader.Analyzer3D = Combo.GetBoolValue(Me.combo3DAnalyzer)
        kitLoader.RenderDirectX = Combo.GetBoolValue(Me.comboRenderDirectX)

        'Resolution
        If kitLoader.RenderDirectX Then
            kitLoader.FullscreenWidth = resolution.Width.Item(Me.comboFullscreenResolution.SelectedIndex)
            kitLoader.FullscreenHeight = resolution.Height.Item(Me.comboFullscreenResolution.SelectedIndex)
        End If

    End Sub

    Private Sub SaveSettings()
        Dim settings As Save
        Dim msgText As String
        Dim msgTitle As MessageTitle = New MessageTitle()

        settings = New Save(AddressOf kitServer.WriteFile)
        settings = [Delegate].Combine(settings, New Save(AddressOf ballServer.WriteFile))
        settings = [Delegate].Combine(settings, New Save(AddressOf bootServer.WriteFile))
        settings = [Delegate].Combine(settings, New Save(AddressOf cameraZoomer.WriteFile))
        settings = [Delegate].Combine(settings, New Save(AddressOf speeder.WriteFile))
        settings = [Delegate].Combine(settings, New Save(AddressOf kitLoader.WriteFile))

        If settings.Invoke() Then
            msgText = "The settings have been successfully saved."
            MessageBox.Show(msgText, msgTitle.TitleInfo, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            msgText = "The settings are not successfully saved."
            MessageBox.Show(msgText, msgTitle.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub buttonPlay_Click(sender As Object, e As EventArgs) Handles buttonPlay.Click

        Process.Start("..\PES6.exe")
    End Sub

    Private Sub formMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        DefaultValue()

        If kitServer.ExistFile() And kitServer.ReadFile() Then
            Combo.SetBoolValue(Me.comboHDKits, kitServer.HdKitsEnable)
        End If

        If ballServer.ExistFile() And ballServer.ReadFile() Then
            Combo.SetBoolValue(Me.comboBallPreview, ballServer.BallPreview)
        End If

        If bootServer.ExistFile() And bootServer.ReadFile() Then
            Combo.SetBoolValue(Me.comboLowBoots, bootServer.VersionBoots)
            Combo.SetBoolValue(Me.comboRandomBoots, bootServer.RandomBoots)
        End If

        If cameraZoomer.ExistFile() And cameraZoomer.ReadFile() Then
            Combo.SetBoolValue(Me.comboStadiumRoof, cameraZoomer.StadiumRoof)
            Combo.SetBoolValue(Me.comboStadiumClipping, cameraZoomer.StadiumClipping)
            Me.numericCameraZoom.Value = cameraZoomer.CameraZoom
        End If

        If speeder.ExistFile() And speeder.ReadFile() Then
            Me.numericSpeedModule.Value = CType(speeder.CountFactor, Decimal)
        End If

        If kitLoader.ExistFile() And kitLoader.ReadFile() Then
            Me.numericReservedMemory.Value = CType(kitLoader.ReservedMemory / (1024 * 1024), Decimal)
            Combo.SetBoolValue(Me.combo3DAnalyzer, kitLoader.Analyzer3D)
            Combo.SetBoolValue(Me.comboRenderDirectX, kitLoader.RenderDirectX)
        End If

        'toolTipMain.SetToolTip(Me.buttonPlay, "Start your game PES 6")
        'toolTipMain.SetToolTip(Me.buttonDefault, "Set the recommended settings" & Environment.NewLine & "for kitserver configuration files")
        'toolTipMain.SetToolTip(Me.buttonSave, "Save the current setting" & Environment.NewLine & "for the configuration files")

        'toolTipMain.SetToolTip(Me.comboHDKits, "Turn on the display equipment" & Environment.NewLine & "of players in high resolution (recomended)")
        'toolTipMain.SetToolTip(Me.comboBallPreview, "Enable/Disable displaying the ball before" & Environment.NewLine & "the game, when selecting (recomended)")

    End Sub

    Private Sub comboRenderDirectX_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboRenderDirectX.SelectedIndexChanged
        If Me.comboRenderDirectX.SelectedIndex = 0 Then
            Me.comboFullscreenResolution.Enabled = False
        Else
            Me.comboFullscreenResolution.Enabled = True
            Me.comboFullscreenResolution.SelectedIndex = 0
        End If
    End Sub


    Private Sub buttonSave_Click(sender As Object, e As EventArgs) Handles buttonSave.Click

        Call ReadSettings()
        Call SaveSettings()

    End Sub

    Private Sub buttonDefault_Click(sender As Object, e As EventArgs) Handles buttonDefault.Click
        Call DefaultValue()
    End Sub

    Private Sub menuHelpItemAbout_Click(sender As Object, e As EventArgs) Handles menuHelpItemAbout.Click
        Dim about As New formAbout()
        about.Show()
    End Sub
End Class
