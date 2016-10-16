Public Class FormMain

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

    Private Sub ButtonPlay_Click(sender As Object, e As EventArgs) Handles buttonPlay.Click
        Dim pesFile As New PesFile()

        If pesFile.Check(pesFile.AppPES6) Then
            Process.Start(pesFile.AppPES6)
        End If
    End Sub

    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
    End Sub

    Private Sub ComboRenderDirectX_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboRenderDirectX.SelectedIndexChanged
        If Me.comboRenderDirectX.SelectedIndex = 0 Then
            Me.comboFullscreenResolution.Enabled = False
        Else
            Me.comboFullscreenResolution.Enabled = True
            Me.comboFullscreenResolution.SelectedIndex = 0
        End If
    End Sub


    Private Sub ButtonSave_Click(sender As Object, e As EventArgs) Handles buttonSave.Click

        Call ReadSettings()
        Call SaveSettings()

    End Sub

    Private Sub ButtonDefault_Click(sender As Object, e As EventArgs) Handles buttonDefault.Click
        Call DefaultValue()
    End Sub

    Private Sub MenuHelpItemAbout_Click(sender As Object, e As EventArgs) Handles menuHelpItemAbout.Click
        Dim about As New FormAbout()
        about.Show()
    End Sub

    Private Sub FormMain_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        If (e.KeyCode And Not Keys.Modifiers) = Keys.P AndAlso e.Modifiers = Keys.Control Then
            Dim pesFile As New PesFile()

            If pesFile.Check(pesFile.AppPES6) Then
                Process.Start(pesFile.AppPES6)
            End If
        ElseIf (e.KeyCode And Not Keys.Modifiers) = Keys.D AndAlso e.Modifiers = Keys.Control Then
            Call DefaultValue()
        ElseIf (e.KeyCode And Not Keys.Modifiers) = Keys.S AndAlso e.Modifiers = Keys.Control Then
            Call ReadSettings()
            Call SaveSettings()
        ElseIf (e.KeyCode And Not Keys.Modifiers) = Keys.X AndAlso e.Modifiers = Keys.Control Then
            Me.Close()
        ElseIf (e.KeyCode And Not Keys.Modifiers) = Keys.F AndAlso e.Modifiers = Keys.Control Then
            Process.Start(Environment.CurrentDirectory)
        End If

    End Sub

    Private Sub MenuHelpItemKitserver_Click(sender As Object, e As EventArgs) Handles menuHelpItemKitserver.Click

        Dim msgTitle As New MessageTitle()
        Dim help As KitserverHelp = New KitserverHelp()

        If Not help.Check() Then
            Dim msgResult As DialogResult

            msgResult = MessageBox.Show(help.Message, msgTitle.TitleWarning, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If msgResult = DialogResult.No Then
                Exit Sub
            End If
        Else
            If Not help.Valid() Then
                MessageBox.Show(help.Message, msgTitle.TitleWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

            If Not help.Run() Then
                MessageBox.Show(help.Message, msgTitle.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub MenuFileItemDefault_Click(sender As Object, e As EventArgs) Handles menuFileItemDefault.Click
        Call DefaultValue()
    End Sub

    Private Sub menuFileItemFolder_Click(sender As Object, e As EventArgs) Handles menuFileItemFolder.Click
        Process.Start(Environment.CurrentDirectory)
    End Sub

    Private Sub menuHelpItemPES6Readme_Click(sender As Object, e As EventArgs) Handles menuHelpItemPES6Readme.Click
        Dim pesFile As New PesFile()

        If pesFile.Check(pesFile.ReadmeFile) Then
            Process.Start(pesFile.ReadmeFile)
        End If

    End Sub

    Private Sub menuSettingsItemPES6_Click(sender As Object, e As EventArgs) Handles menuSettingsItemPES6.Click
        Dim pesFile As New PesFile()

        If pesFile.Check(pesFile.AppSettings) Then
            Process.Start(pesFile.AppSettings)
        End If

    End Sub

    Private Sub menuKitserverItemKeyBind_Click(sender As Object, e As EventArgs) Handles menuKitserverItemKeyBind.Click
        Dim kitserverFile As New KitserverFile

        If kitserverFile.Check(kitserverFile.AppKeyBind) Then
            Process.Start(kitserverFile.AppKeyBind)
        End If

    End Sub

    Private Sub menuKitserverItemLodCfg_Click(sender As Object, e As EventArgs) Handles menuKitserverItemLodCfg.Click
        Dim kitserverFile As New KitserverFile

        If kitserverFile.Check(kitserverFile.AppLodMixer) Then
            Process.Start(kitserverFile.AppLodMixer)
        End If
    End Sub

    Private Sub menuKitserverItemSetup_Click(sender As Object, e As EventArgs) Handles menuKitserverItemSetup.Click
        Dim kitserverFile As New KitserverFile

        If kitserverFile.Check(kitserverFile.AppSetup) Then
            Process.Start(kitserverFile.AppSetup)
        End If
    End Sub

    Private Sub menuEditItemAfs2fs_Click(sender As Object, e As EventArgs) Handles menuEditItemAfs2fs.Click
        If afs2fs.ExistFile() Then
            Process.Start(afs2fs.FileName)
        End If
    End Sub

    Private Sub menuEditItemBootServ_Click(sender As Object, e As EventArgs) Handles menuEditItemBootServ.Click
        If bootServer.ExistFile() Then
            Process.Start(bootServer.FileName)
        End If
    End Sub

    Private Sub menuEditItemBserv_Click(sender As Object, e As EventArgs) Handles menuEditItemBserv.Click
        If ballServer.ExistFile() Then
            Process.Start(ballServer.FileName)
        End If
    End Sub

    Private Sub menuEditItemCameraZoomer_Click(sender As Object, e As EventArgs) Handles menuEditItemCameraZoomer.Click
        If cameraZoomer.ExistFile() Then
            Process.Start(cameraZoomer.FileName)
        End If
    End Sub

    Private Sub menuEditItemKload_Click(sender As Object, e As EventArgs) Handles menuEditItemKload.Click
        If kitLoader.ExistFile() Then
            Process.Start(kitLoader.FileName)
        End If
    End Sub

    Private Sub menuEditItemKserv_Click(sender As Object, e As EventArgs) Handles menuEditItemKserv.Click
        If kitServer.ExistFile() Then
            Process.Start(kitServer.FileName)
        End If
    End Sub

    Private Sub menuEditItemSpeeder_Click(sender As Object, e As EventArgs) Handles menuEditItemSpeeder.Click
        If speeder.ExistFile() Then
            Process.Start(speeder.FileName)
        End If
    End Sub
End Class
