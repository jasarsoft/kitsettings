''' <summary>
''' Kitserver 6 Settings Main Form Class
''' </summary>
Public Class SettingsForm
#Region "Fields"
    ''' <summary>Instance Afs2fs class</summary>
    Private _afs2fs As Afs2fs
    ''' <summary>Instance Ball Server class</summary>
    Private _ballServer As BallServer
    ''' <summary>Instance Boot Server class</summary>
    Private _bootServer As BootServer
    ''' <summary>Instance Camera Zoomer class</summary>
    Private _cameraZoomer As CameraZoomer
    ''' <summary>Instance Kit Server class</summary>
    Private _kitServer As KitServer
    ''' <summary>Instance Kit Loader class</summary>
    Private _kitLoader As KitLoader
    ''' <summary>Instance Speeder Module class</summary>
    Private _speeder As Speeder
    ''' <summary>Instance Custom Display class</summary>
    Private _display As Display

    ''' <summary>
    ''' The delegate functions to save settings
    ''' </summary>
    ''' <returns>Boolean</returns>
    Private Delegate Function Save() As Boolean
#End Region

#Region "Constructor"
    ''' <summary>
    ''' Default initialization constructor
    ''' </summary>
    Public Sub New()
        ' Initialization designer components
        Me.InitializeComponent()

        ' Initialization class
        _afs2fs = New Afs2fs()
        _ballServer = New BallServer()
        _bootServer = New BootServer()
        _cameraZoomer = New CameraZoomer()
        _kitServer = New KitServer()
        _kitLoader = New KitLoader()
        _speeder = New Speeder()
        _display = New Display()
    End Sub
#End Region

#Region "Methods"
    ''' <summary>
    ''' Settings default or recommended values of paramter
    ''' </summary>
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
        For Each value As Integer In _display.Width
            Me.comboFullscreenResolution.Items.Add(_display.Width.Item(i).ToString() & "x" & _display.Height.Item(i).ToString())
            i += 1 'i = i + 1
        Next
    End Sub

    ''' <summary>
    ''' Read the current paramter settings with form
    ''' </summary>
    Private Sub ReadSettings()
        'Disable controls
        Call DisableSettings()
        'Read constrols paramter
        _kitServer.HdKitsEnable = Modules.Combo.GetBoolValue(Me.comboHDKits)
        _ballServer.BallPreview = Modules.Combo.GetBoolValue(Me.comboBallPreview)
        _bootServer.VersionBoots = Modules.Combo.GetBoolValue(Me.comboLowBoots)
        _bootServer.RandomBoots = Modules.Combo.GetBoolValue(Me.comboRandomBoots)
        _cameraZoomer.StadiumRoof = Modules.Combo.GetBoolValue(Me.comboStadiumRoof)
        _cameraZoomer.StadiumClipping = Modules.Combo.GetBoolValue(Me.comboStadiumClipping)
        _cameraZoomer.CameraZoom = CType(Me.numericCameraZoom.Value, Integer)
        _speeder.CountFactor = CType(Me.numericSpeedModule.Value, Double)
        _kitLoader.ReservedMemory = CType(Me.numericReservedMemory.Value * 1024 * 1024, UInteger)
        _kitLoader.Analyzer3D = Modules.Combo.GetBoolValue(Me.combo3DAnalyzer)
        _kitLoader.RenderDirectX = Modules.Combo.GetBoolValue(Me.comboRenderDirectX)

        'Resolution
        If _kitLoader.RenderDirectX Then
            _kitLoader.FullscreenWidth = _display.Width.Item(Me.comboFullscreenResolution.SelectedIndex)
            _kitLoader.FullscreenHeight = _display.Height.Item(Me.comboFullscreenResolution.SelectedIndex)
        End If

    End Sub

    ''' <summary>
    ''' Save the current setting for the configuration file
    ''' </summary>
    Private Sub SaveSettings()
        Dim settings As Save
        Dim msgText As String
        Dim msgTitle As Title = New Title()

        settings = New Save(AddressOf _kitServer.WriteFile)
        settings = [Delegate].Combine(settings, New Save(AddressOf _ballServer.WriteFile))
        settings = [Delegate].Combine(settings, New Save(AddressOf _bootServer.WriteFile))
        settings = [Delegate].Combine(settings, New Save(AddressOf _cameraZoomer.WriteFile))
        settings = [Delegate].Combine(settings, New Save(AddressOf _speeder.WriteFile))
        settings = [Delegate].Combine(settings, New Save(AddressOf _kitLoader.WriteFile))

        If settings.Invoke() Then
            msgText = "The settings have been successfully saved."
            MessageBox.Show(msgText, msgTitle.TitleInfo, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            msgText = "The settings are not successfully saved."
            MessageBox.Show(msgText, msgTitle.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        Call EnableSettings()
    End Sub

    ''' <summary>
    ''' Disable all constrols to modify parameters
    ''' </summary>
    Private Sub DisableSettings()
        Me.comboHDKits.Enabled = False
        Me.comboBallPreview.Enabled = False
        Me.comboLowBoots.Enabled = False
        Me.comboRandomBoots.Enabled = False
        Me.comboStadiumRoof.Enabled = False
        Me.comboStadiumClipping.Enabled = False
        Me.numericCameraZoom.Enabled = False
        Me.numericSpeedModule.Enabled = False
        Me.numericReservedMemory.Enabled = False
        Me.combo3DAnalyzer.Enabled = False
        Me.comboRenderDirectX.Enabled = False
        Me.comboFullscreenResolution.Enabled = False
    End Sub

    ''' <summary>
    ''' Enable all constrols to modify parameters
    ''' </summary>
    Private Sub EnableSettings()
        Me.comboHDKits.Enabled = True
        Me.comboBallPreview.Enabled = True
        Me.comboLowBoots.Enabled = True
        Me.comboRandomBoots.Enabled = True
        Me.comboStadiumRoof.Enabled = True
        Me.comboStadiumClipping.Enabled = True
        Me.numericCameraZoom.Enabled = True
        Me.numericSpeedModule.Enabled = True
        Me.numericReservedMemory.Enabled = True
        Me.combo3DAnalyzer.Enabled = True
        Me.comboRenderDirectX.Enabled = True

        If _kitLoader.RenderDirectX Then
            Me.comboFullscreenResolution.Enabled = True
        End If
    End Sub

    ''' <summary>
    ''' Start PES application
    ''' </summary>
    Private Sub RunPES()
        Dim pesFile As New PesFile()

        If pesFile.Check(pesFile.AppPES6) Then
            Process.Start(pesFile.AppPES6)
        End If
    End Sub

    ''' <summary>
    ''' Open the file in Notepad
    ''' </summary>
    ''' <param name="fileName">String</param>
    Private Sub RunCfgFile(ByVal fileName As String)
        'Open notepad with argument
        Process.Start("notepad.exe", fileName)
    End Sub

#End Region

#Region "Events"
#Region "Form Event"
    ''' <summary>
    ''' Parameter settings in the form of a read form configuration file
    ''' </summary>
    ''' <param name="sender">Name of the object that calls event</param>
    ''' <param name="e">Arguments event on the called object</param>
    ''' <remarks>Form Main Load Event</remarks>
    Private Sub FormMain_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        DefaultValue()

        'If _kitLoader.Valid() Then
        '    Me.numericReservedMemory.Enabled = True
        '    Me.combo3DAnalyzer.Enabled = True
        '    Me.comboRenderDirectX.Enabled = True
        'Else
        '    Dim text As String
        '    Dim caption As New Title()

        '    Me.combo3DAnalyzer.Enabled = False
        '    Me.comboRenderDirectX.Enabled = False
        '    Me.numericReservedMemory.Enabled = False

        '    text = "Kitserver 6 Settings is not propertly installed." & Environment.NewLine
        '    text &= "Missing main module of kitserver, Kit Loader (kload.dll)."
        '    MessageBox.Show(text, caption.TitleError, MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Application.Exit()
        'End If

        If _kitServer.Check() And _kitServer.ReadFile() Then
            Modules.Combo.SetBoolValue(Me.comboHDKits, _kitServer.HdKitsEnable)
        End If

        If _ballServer.Check() And _ballServer.ReadFile() Then
            Modules.Combo.SetBoolValue(Me.comboBallPreview, _ballServer.BallPreview)
        End If

        If _bootServer.Check() And _bootServer.ReadFile() Then
            Modules.Combo.SetBoolValue(Me.comboLowBoots, _bootServer.VersionBoots)
            Modules.Combo.SetBoolValue(Me.comboRandomBoots, _bootServer.RandomBoots)
        End If

        If _cameraZoomer.Check() And _cameraZoomer.ReadFile() Then
            'Adjusting the loaded value
            Modules.Combo.SetBoolValue(Me.comboStadiumRoof, _cameraZoomer.StadiumRoof)
            Modules.Combo.SetBoolValue(Me.comboStadiumClipping, _cameraZoomer.StadiumClipping)
            If _cameraZoomer.CameraZoom > Me.numericCameraZoom.Maximum Then
                Me.numericCameraZoom.Value = Me.numericCameraZoom.Maximum
            ElseIf _cameraZoomer.CameraZoom < Me.numericCameraZoom.Minimum Then
                Me.numericCameraZoom.Value = Me.numericCameraZoom.Minimum
            Else
                Me.numericCameraZoom.Value = _cameraZoomer.CameraZoom
            End If
        End If

        If _speeder.Check() And _speeder.ReadFile() Then
            'Adjusting the loaded value
            If _speeder.CountFactor > Me.numericSpeedModule.Maximum Then
                Me.numericSpeedModule.Value = Me.numericSpeedModule.Maximum
            ElseIf _speeder.CountFactor < Me.numericSpeedModule.Minimum Then
                Me.numericSpeedModule.Value = Me.numericSpeedModule.Minimum
            Else
                Me.numericSpeedModule.Value = CType(_speeder.CountFactor, Decimal)
            End If
        End If

        If _kitLoader.Check() And _kitLoader.ReadFile() Then
            'Adjusting the loaded value
            If _kitLoader.ReservedMemory > (CType(Me.numericReservedMemory.Value, UInteger) * 1024 * 1024) Then
                Me.numericReservedMemory.Value = Me.numericReservedMemory.Maximum
            ElseIf _kitLoader.ReservedMemory < (CType(Me.numericReservedMemory.Value, UInteger) * 1024 * 1024) Then
                Me.numericReservedMemory.Value = Me.numericReservedMemory.Minimum
            Else
                Me.numericReservedMemory.Value = CType(_kitLoader.ReservedMemory / (1024 * 1024), Decimal)
            End If

            Modules.Combo.SetBoolValue(Me.combo3DAnalyzer, _kitLoader.Analyzer3D)
            Modules.Combo.SetBoolValue(Me.comboRenderDirectX, _kitLoader.RenderDirectX)
        End If
    End Sub

    ''' <summary>
    ''' Keyboard shortcuts for calling the most important functionality
    ''' </summary>
    ''' <param name="sender">Name of the object that calls event</param>
    ''' <param name="e">Arguments keyboard event on the called object</param>
    ''' <remarks>Form Main Key Down Event</remarks>
    Private Sub FormMain_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown

        If (e.KeyCode And Not Keys.Modifiers) = Keys.P AndAlso e.Modifiers = Keys.Control Then
            Call RunPES()
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
#End Region

#Region "Button Event"
    ''' <summary>
    ''' Launch the application of PES6 game
    ''' </summary>
    ''' <param name="sender">Name of the object that calls event</param>
    ''' <param name="e">Arguments event on the called object</param>
    ''' <remarks>Button Play Click Event</remarks>
    Private Sub ButtonPlay_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonPlay.Click
        Call RunPES()
    End Sub
    ''' <summary>
    ''' Read and save the settings
    ''' </summary>
    ''' <param name="sender">Name of the object that calls event</param>
    ''' <param name="e">Arguments event on the called object</param>
    ''' <remarks>Button Save Click Event</remarks>
    Private Sub ButtonSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonSave.Click
        Call ReadSettings()
        Call SaveSettings()
    End Sub
    ''' <summary>
    ''' Settings the preferred parameter values
    ''' </summary>
    ''' <param name="sender">Name of the object that calls event</param>
    ''' <param name="e">Arguments event on the called object</param>
    ''' <remarks>Button Default Click Event</remarks>
    Private Sub ButtonDefault_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonDefault.Click
        Call DefaultValue()
    End Sub
#End Region

#Region "ComboBox Event"
    ''' <summary>
    ''' The resolution setting combobox available in relation to the choice of DirectX combobox
    ''' </summary>
    ''' <param name="sender">Name of the object that calls event</param>
    ''' <param name="e">Arguments event on the called object</param>
    ''' <remarks>Combobox Reander DirectX Selected Index Changed Event</remarks>
    Private Sub ComboRenderDirectX_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles comboRenderDirectX.SelectedIndexChanged
        If Me.comboRenderDirectX.SelectedIndex = 0 Then
            Me.comboFullscreenResolution.Enabled = False
        Else
            Me.comboFullscreenResolution.Enabled = True
            Me.comboFullscreenResolution.SelectedIndex = 0
        End If
    End Sub
#End Region

#Region "Menu File Event"
    ''' <summary>
    ''' Run PES application
    ''' </summary>
    ''' <param name="sender">Name of the object that calls event</param>
    ''' <param name="e">Arguments event on the called object</param>
    ''' <remarks>Menu File Item Play Click Event</remarks>
    Private Sub MenuFileItemPlay_Click(ByVal sender As Object, ByVal e As EventArgs) Handles menuFileItemPlay.Click
        Call RunPES()
    End Sub
    ''' <summary>
    ''' Open the application directory in explorer
    ''' </summary>
    ''' <param name="sender">Name of the object that calls event</param>
    ''' <param name="e">Arguments event on the called object</param>
    ''' <remarks>Menu File Item Folder Click Event</remarks>
    Private Sub MenuFileItemFolder_Click(ByVal sender As Object, ByVal e As EventArgs) Handles menuFileItemFolder.Click
        Process.Start(Environment.CurrentDirectory)
    End Sub
    ''' <summary>
    ''' Save settings parameter form in the configuration file
    ''' </summary>
    ''' <param name="sender">Name of the object that calls event</param>
    ''' <param name="e">Arguments event on the called object</param>
    ''' <remarks>Menu File Item Save Click Event</remarks>
    Private Sub MenuFileItemSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles menuFileItemSave.Click
        Call ReadSettings()
        Call SaveSettings()
    End Sub
    ''' <summary>
    ''' Settings paramter in form of the recommended values
    ''' </summary>
    ''' <param name="sender">Name of the object that calls event</param>
    ''' <param name="e">Arguments event on the called object</param>
    ''' <remarks>Menu File Item Default Click Event</remarks>
    Private Sub MenuFileItemDefault_Click(ByVal sender As Object, ByVal e As EventArgs) Handles menuFileItemDefault.Click
        Call DefaultValue()
    End Sub
    ''' <summary>
    ''' Close and exit the application
    ''' </summary>
    ''' <param name="sender">Name of the object that calls event</param>
    ''' <param name="e">Arguments event on the called object</param>
    ''' <remarks>Menu File Item Exit Click Event</remarks>
    Private Sub MenuFileItemExit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles menuFileItemExit.Click
        Me.Close()
    End Sub
#End Region

#Region "Menu Edit Event"
    ''' <summary>
    ''' Run Afs2fs configuration file for viewing in Notepad
    ''' </summary>
    ''' <param name="sender">Name of the object that calls event</param>
    ''' <param name="e">Arguments event on the called object</param>
    ''' <remarks>Menu Edit Item Afs2fs Click Event</remarks>
    Private Sub MenuEditItemAfs2fs_Click(ByVal sender As Object, ByVal e As EventArgs) Handles menuEditItemAfs2fs.Click
        If _afs2fs.Check() Then
            Call RunCfgFile(_afs2fs.Name)
        End If
    End Sub
    ''' <summary>
    ''' Run Boot Server configuration file for viewing in Notepad
    ''' </summary>
    ''' <param name="sender">Name of the object that calls event</param>
    ''' <param name="e">Arguments event on the called object</param>
    ''' <remarks>Menu Edit Item Boot Server Click Event</remarks>
    Private Sub MenuEditItemBootServ_Click(ByVal sender As Object, ByVal e As EventArgs) Handles menuEditItemBootServ.Click
        If _bootServer.Check() Then
            Call RunCfgFile(_bootServer.Name)
        End If
    End Sub
    ''' <summary>
    ''' Run Ball Server configuration file for viewing in Notepad
    ''' </summary>
    ''' <param name="sender">Name of the object that calls event</param>
    ''' <param name="e">Arguments event on the called object</param>
    ''' <remarks>Menu Edit Item Ball Server Click Event</remarks>
    Private Sub MenuEditItemBserv_Click(ByVal sender As Object, ByVal e As EventArgs) Handles menuEditItemBserv.Click
        If _ballServer.Check() Then
            Call RunCfgFile(_ballServer.Name)
        End If
    End Sub
    ''' <summary>
    ''' Run Camera Zoomer configuration file for viewing in Notepad
    ''' </summary>
    ''' <param name="sender">Name of the object that calls event</param>
    ''' <param name="e">Arguments event on the called object</param>
    ''' <remarks>Menu Edit Item Camera Zoomer Click Event</remarks>
    Private Sub MenuEditItemCameraZoomer_Click(ByVal sender As Object, ByVal e As EventArgs) Handles menuEditItemCameraZoomer.Click
        If _cameraZoomer.Check() Then
            Call RunCfgFile(_cameraZoomer.Name)
        End If
    End Sub
    ''' <summary>
    ''' Run Kitserver Loader configuration file for viewing in Notepad
    ''' </summary>
    ''' <param name="sender">Name of the object that calls event</param>
    ''' <param name="e">Arguments event on the called object</param>
    ''' <remarks>Menu Edit Item Kitserver Loader Click Event</remarks>
    Private Sub MenuEditItemKload_Click(ByVal sender As Object, ByVal e As EventArgs) Handles menuEditItemKload.Click
        If _kitLoader.Check() Then
            Call RunCfgFile(_kitLoader.Name)
        End If
    End Sub
    ''' <summary>
    ''' Run Kit Server configuraiton file for viewing in Notepad
    ''' </summary>
    ''' <param name="sender">Name of the object that calls event</param>
    ''' <param name="e">Arguments event on the called object</param>
    ''' <remarks>Menu Edit Item Kit Server Click Event</remarks>
    Private Sub MenuEditItemKserv_Click(ByVal sender As Object, ByVal e As EventArgs) Handles menuEditItemKserv.Click
        If _kitServer.Check() Then
            Call RunCfgFile(_kitServer.Name)
        End If
    End Sub
    ''' <summary>
    ''' Menu Edit Item Speeder configuration file for viewing in Notepad
    ''' </summary>
    ''' <param name="sender">Name of the object that calls event</param>
    ''' <param name="e">Arguments event on the called object</param>
    ''' <remarks>Menu Edit Item Speeder Click Event</remarks>
    Private Sub MenuEditItemSpeeder_Click(ByVal sender As Object, ByVal e As EventArgs) Handles menuEditItemSpeeder.Click
        If _speeder.Check() Then
            Call RunCfgFile(_speeder.Name)
        End If
    End Sub
#End Region

#Region "Menu Kitserver Event"
    ''' <summary>
    ''' Run kitserver KeyBind application
    ''' </summary>
    ''' <param name="sender">Name of the object that calls event</param>
    ''' <param name="e">Arguments event on the called object</param>
    ''' <remarks>Menu Kitserver Item KeyBind Click Event</remarks>
    Private Sub MenuKitserverItemKeyBind_Click(ByVal sender As Object, ByVal e As EventArgs) Handles menuKitserverItemKeyBind.Click
        Dim kitserverFile As New KitserverFile

        If kitserverFile.Check(kitserverFile.AppKeyBind) Then
            Process.Start(kitserverFile.AppKeyBind)
        End If
    End Sub
    ''' <summary>
    ''' Run kitserver LodCfg application
    ''' </summary>
    ''' <param name="sender">Name of the object that calls event</param>
    ''' <param name="e">Arguments event on the called object</param>
    ''' <remarks>Menu Kitserver Item LodCfg Click Event</remarks>
    Private Sub MenuKitserverItemLodCfg_Click(ByVal sender As Object, ByVal e As EventArgs) Handles menuKitserverItemLodCfg.Click
        Dim kitserverFile As New KitserverFile

        If kitserverFile.Check(kitserverFile.AppLodMixer) Then
            Process.Start(kitserverFile.AppLodMixer)
        End If
    End Sub
    ''' <summary>
    ''' Run kitserver Setup application
    ''' </summary>
    ''' <param name="sender">Name of the object that calls event</param>
    ''' <param name="e">Arguments event on the called object</param>
    ''' <remarks>Menu Kitserver Item Setup Click Event</remarks>
    Private Sub MenuKitserverItemSetup_Click(ByVal sender As Object, ByVal e As EventArgs) Handles menuKitserverItemSetup.Click
        Dim kitserverFile As New KitserverFile

        If kitserverFile.Check(kitserverFile.AppSetup) Then
            Process.Start(kitserverFile.AppSetup)
        End If
    End Sub
#End Region

#Region "Menu Settings Event"
    ''' <summary>
    ''' Launch PES6 settings application
    ''' </summary>
    ''' <param name="sender">Name of the object that calls event</param>
    ''' <param name="e">Arguments event on the called object</param>
    ''' <remarks>Menu Settings Item PES6 Click Event</remarks>
    Private Sub MenuSettingsItemPES6_Click(ByVal sender As Object, ByVal e As EventArgs) Handles menuSettingsItemPES6.Click
        Dim pesFile As New PesFile()

        If pesFile.Check(pesFile.AppSettings) Then
            Process.Start(pesFile.AppSettings)
        End If
    End Sub
#End Region

#Region "Menu Help Event"
    ''' <summary>
    ''' Open kitserver help document
    ''' </summary>
    ''' <param name="sender">Name of the object that calls event</param>
    ''' <param name="e">Arguments event on the called object</param>
    ''' <remarks>Menu Help Item Kitserver Click Event</remarks>
    Private Sub MenuHelpItemKitserver_Click(ByVal sender As Object, ByVal e As EventArgs) Handles menuHelpItemKitserver.Click

        Dim msgTitle As New Title()
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
    ''' <summary>
    ''' Open the readme file of PES6 game
    ''' </summary>
    ''' <param name="sender">Name of the object that calls event</param>
    ''' <param name="e">Arguments event on the called object</param>
    ''' <remarks>Menu Help Item PES6 Readme Click Event</remarks>
    Private Sub MenuHelpItemPES6Readme_Click(ByVal sender As Object, ByVal e As EventArgs) Handles menuHelpItemPES6Readme.Click
        Dim pesFile As New PesFile()

        If pesFile.Check(pesFile.ReadmeFile) Then
            Process.Start(pesFile.ReadmeFile)
        End If

    End Sub
    ''' <summary>
    ''' Open the form with information about the application
    ''' </summary>
    ''' <param name="sender">Name of the object that calls event</param>
    ''' <param name="e">Arguments event on the called object</param>
    ''' <remarks>Menu Help Item About Click Event</remarks>
    Private Sub MenuHelpItemAbout_Click(ByVal sender As Object, ByVal e As EventArgs) Handles menuHelpItemAbout.Click
        Dim about As New AboutForm()
        about.Show()
    End Sub
#End Region

#End Region

    Private Sub SettingsForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub

    Private Sub HostToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HostToolStripMenuItem.Click
        Dim hostForm As HostForm

        hostForm = New HostForm()
        hostForm.ShowDialog(Me)
    End Sub
End Class
