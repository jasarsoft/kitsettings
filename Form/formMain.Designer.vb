<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMain))
        Me.MenuMain = New System.Windows.Forms.MenuStrip()
        Me.menuItemFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuFileItemPlay = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuFileItemFolder = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuFileItemSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.menuFileItemSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuFileItemDefault = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuFileItemSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.menuFileItemExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuItemEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuEditItemAfs2fs = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuEditItemBootServ = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuEditItemBserv = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuEditItemCameraZoomer = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuEditItemKload = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuEditItemKserv = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuEditItemSpeeder = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuItemKitserver = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuKitserverItemKeyBind = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuKitserverItemLodCfg = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuKitserverItemSetup = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuItemSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuSettingsItemPES6 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuItemHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuHelpItemKitserver = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuHelpItemPES6Readme = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuHelpSpearator = New System.Windows.Forms.ToolStripSeparator()
        Me.menuHelpItemAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.labelHDKits = New System.Windows.Forms.Label()
        Me.comboHDKits = New System.Windows.Forms.ComboBox()
        Me.numericCameraZoom = New System.Windows.Forms.NumericUpDown()
        Me.labelBallPreview = New System.Windows.Forms.Label()
        Me.comboBallPreview = New System.Windows.Forms.ComboBox()
        Me.comboLowBoots = New System.Windows.Forms.ComboBox()
        Me.comboRandomBoots = New System.Windows.Forms.ComboBox()
        Me.comboStadiumRoof = New System.Windows.Forms.ComboBox()
        Me.comboStadiumClipping = New System.Windows.Forms.ComboBox()
        Me.labelLowBoots = New System.Windows.Forms.Label()
        Me.labelRandomBoots = New System.Windows.Forms.Label()
        Me.labelStadiumRoof = New System.Windows.Forms.Label()
        Me.labelStadiumClipping = New System.Windows.Forms.Label()
        Me.lineVertical = New System.Windows.Forms.Label()
        Me.labelCameraZoom = New System.Windows.Forms.Label()
        Me.numericSpeedModule = New System.Windows.Forms.NumericUpDown()
        Me.numericReservedMemory = New System.Windows.Forms.NumericUpDown()
        Me.combo3DAnalyzer = New System.Windows.Forms.ComboBox()
        Me.comboRenderDirectX = New System.Windows.Forms.ComboBox()
        Me.comboFullscreenResolution = New System.Windows.Forms.ComboBox()
        Me.labelSpeedModule = New System.Windows.Forms.Label()
        Me.labelReservedMemory = New System.Windows.Forms.Label()
        Me.label3DAnalyzer = New System.Windows.Forms.Label()
        Me.labelRenderDirectX = New System.Windows.Forms.Label()
        Me.labelFullscreenResolution = New System.Windows.Forms.Label()
        Me.lineHorizontal = New System.Windows.Forms.Label()
        Me.buttonPlay = New System.Windows.Forms.Button()
        Me.buttonSave = New System.Windows.Forms.Button()
        Me.buttonDefault = New System.Windows.Forms.Button()
        Me.toolTipMain = New System.Windows.Forms.ToolTip(Me.components)
        Me.MenuMain.SuspendLayout()
        CType(Me.numericCameraZoom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numericSpeedModule, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numericReservedMemory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuMain
        '
        Me.MenuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuItemFile, Me.menuItemEdit, Me.menuItemKitserver, Me.menuItemSettings, Me.menuItemHelp})
        Me.MenuMain.Location = New System.Drawing.Point(0, 0)
        Me.MenuMain.Name = "MenuMain"
        Me.MenuMain.Size = New System.Drawing.Size(500, 24)
        Me.MenuMain.TabIndex = 0
        Me.MenuMain.Text = "MenuStrip1"
        '
        'menuItemFile
        '
        Me.menuItemFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuFileItemPlay, Me.menuFileItemFolder, Me.menuFileItemSeparator1, Me.menuFileItemSave, Me.menuFileItemDefault, Me.menuFileItemSeparator2, Me.menuFileItemExit})
        Me.menuItemFile.Name = "menuItemFile"
        Me.menuItemFile.Size = New System.Drawing.Size(37, 20)
        Me.menuItemFile.Text = "&File"
        '
        'menuFileItemPlay
        '
        Me.menuFileItemPlay.Name = "menuFileItemPlay"
        Me.menuFileItemPlay.ShortcutKeyDisplayString = "Ctrl+P"
        Me.menuFileItemPlay.Size = New System.Drawing.Size(154, 22)
        Me.menuFileItemPlay.Text = "&Play"
        '
        'menuFileItemFolder
        '
        Me.menuFileItemFolder.Name = "menuFileItemFolder"
        Me.menuFileItemFolder.ShortcutKeyDisplayString = "Ctrl+F"
        Me.menuFileItemFolder.Size = New System.Drawing.Size(154, 22)
        Me.menuFileItemFolder.Text = "&Folder"
        '
        'menuFileItemSeparator1
        '
        Me.menuFileItemSeparator1.Name = "menuFileItemSeparator1"
        Me.menuFileItemSeparator1.Size = New System.Drawing.Size(151, 6)
        '
        'menuFileItemSave
        '
        Me.menuFileItemSave.Name = "menuFileItemSave"
        Me.menuFileItemSave.ShortcutKeyDisplayString = "Ctrl+S"
        Me.menuFileItemSave.Size = New System.Drawing.Size(154, 22)
        Me.menuFileItemSave.Text = "&Save"
        '
        'menuFileItemDefault
        '
        Me.menuFileItemDefault.Name = "menuFileItemDefault"
        Me.menuFileItemDefault.ShortcutKeyDisplayString = "Ctrl+D"
        Me.menuFileItemDefault.Size = New System.Drawing.Size(154, 22)
        Me.menuFileItemDefault.Text = "&Default"
        '
        'menuFileItemSeparator2
        '
        Me.menuFileItemSeparator2.Name = "menuFileItemSeparator2"
        Me.menuFileItemSeparator2.Size = New System.Drawing.Size(151, 6)
        '
        'menuFileItemExit
        '
        Me.menuFileItemExit.Name = "menuFileItemExit"
        Me.menuFileItemExit.ShortcutKeyDisplayString = "Ctrl+X"
        Me.menuFileItemExit.Size = New System.Drawing.Size(154, 22)
        Me.menuFileItemExit.Text = "E&xit"
        '
        'menuItemEdit
        '
        Me.menuItemEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuEditItemAfs2fs, Me.menuEditItemBootServ, Me.menuEditItemBserv, Me.menuEditItemCameraZoomer, Me.menuEditItemKload, Me.menuEditItemKserv, Me.menuEditItemSpeeder})
        Me.menuItemEdit.Name = "menuItemEdit"
        Me.menuItemEdit.Size = New System.Drawing.Size(39, 20)
        Me.menuItemEdit.Text = "&Edit"
        '
        'menuEditItemAfs2fs
        '
        Me.menuEditItemAfs2fs.Name = "menuEditItemAfs2fs"
        Me.menuEditItemAfs2fs.Size = New System.Drawing.Size(160, 22)
        Me.menuEditItemAfs2fs.Text = "Afs2fs"
        '
        'menuEditItemBootServ
        '
        Me.menuEditItemBootServ.Name = "menuEditItemBootServ"
        Me.menuEditItemBootServ.Size = New System.Drawing.Size(160, 22)
        Me.menuEditItemBootServ.Text = "Boot Server"
        '
        'menuEditItemBserv
        '
        Me.menuEditItemBserv.Name = "menuEditItemBserv"
        Me.menuEditItemBserv.Size = New System.Drawing.Size(160, 22)
        Me.menuEditItemBserv.Text = "Ball Server"
        '
        'menuEditItemCameraZoomer
        '
        Me.menuEditItemCameraZoomer.Name = "menuEditItemCameraZoomer"
        Me.menuEditItemCameraZoomer.Size = New System.Drawing.Size(160, 22)
        Me.menuEditItemCameraZoomer.Text = "Camera Zoomer"
        '
        'menuEditItemKload
        '
        Me.menuEditItemKload.Name = "menuEditItemKload"
        Me.menuEditItemKload.Size = New System.Drawing.Size(160, 22)
        Me.menuEditItemKload.Text = "Kitserver Load"
        '
        'menuEditItemKserv
        '
        Me.menuEditItemKserv.Name = "menuEditItemKserv"
        Me.menuEditItemKserv.Size = New System.Drawing.Size(160, 22)
        Me.menuEditItemKserv.Text = "Kit Server"
        '
        'menuEditItemSpeeder
        '
        Me.menuEditItemSpeeder.Name = "menuEditItemSpeeder"
        Me.menuEditItemSpeeder.Size = New System.Drawing.Size(160, 22)
        Me.menuEditItemSpeeder.Text = "Speeder"
        '
        'menuItemKitserver
        '
        Me.menuItemKitserver.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuKitserverItemKeyBind, Me.menuKitserverItemLodCfg, Me.menuKitserverItemSetup})
        Me.menuItemKitserver.Name = "menuItemKitserver"
        Me.menuItemKitserver.Size = New System.Drawing.Size(64, 20)
        Me.menuItemKitserver.Text = "&Kitserver"
        '
        'menuKitserverItemKeyBind
        '
        Me.menuKitserverItemKeyBind.Name = "menuKitserverItemKeyBind"
        Me.menuKitserverItemKeyBind.Size = New System.Drawing.Size(129, 22)
        Me.menuKitserverItemKeyBind.Text = "Key Bind"
        '
        'menuKitserverItemLodCfg
        '
        Me.menuKitserverItemLodCfg.Name = "menuKitserverItemLodCfg"
        Me.menuKitserverItemLodCfg.Size = New System.Drawing.Size(129, 22)
        Me.menuKitserverItemLodCfg.Text = "LOD Mixer"
        '
        'menuKitserverItemSetup
        '
        Me.menuKitserverItemSetup.Name = "menuKitserverItemSetup"
        Me.menuKitserverItemSetup.Size = New System.Drawing.Size(129, 22)
        Me.menuKitserverItemSetup.Text = "(Un)Install"
        '
        'menuItemSettings
        '
        Me.menuItemSettings.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuSettingsItemPES6})
        Me.menuItemSettings.Name = "menuItemSettings"
        Me.menuItemSettings.Size = New System.Drawing.Size(61, 20)
        Me.menuItemSettings.Text = "&Settings"
        '
        'menuSettingsItemPES6
        '
        Me.menuSettingsItemPES6.Name = "menuSettingsItemPES6"
        Me.menuSettingsItemPES6.Size = New System.Drawing.Size(102, 22)
        Me.menuSettingsItemPES6.Text = "PES 6"
        '
        'menuItemHelp
        '
        Me.menuItemHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuHelpItemKitserver, Me.menuHelpItemPES6Readme, Me.menuHelpSpearator, Me.menuHelpItemAbout})
        Me.menuItemHelp.Name = "menuItemHelp"
        Me.menuItemHelp.Size = New System.Drawing.Size(44, 20)
        Me.menuItemHelp.Text = "&Help"
        '
        'menuHelpItemKitserver
        '
        Me.menuHelpItemKitserver.Name = "menuHelpItemKitserver"
        Me.menuHelpItemKitserver.Size = New System.Drawing.Size(145, 22)
        Me.menuHelpItemKitserver.Text = "Kitserver"
        '
        'menuHelpItemPES6Readme
        '
        Me.menuHelpItemPES6Readme.Name = "menuHelpItemPES6Readme"
        Me.menuHelpItemPES6Readme.Size = New System.Drawing.Size(145, 22)
        Me.menuHelpItemPES6Readme.Text = "PES6 Readme"
        '
        'menuHelpSpearator
        '
        Me.menuHelpSpearator.Name = "menuHelpSpearator"
        Me.menuHelpSpearator.Size = New System.Drawing.Size(142, 6)
        '
        'menuHelpItemAbout
        '
        Me.menuHelpItemAbout.Name = "menuHelpItemAbout"
        Me.menuHelpItemAbout.Size = New System.Drawing.Size(145, 22)
        Me.menuHelpItemAbout.Text = "About"
        '
        'labelHDKits
        '
        Me.labelHDKits.Location = New System.Drawing.Point(12, 36)
        Me.labelHDKits.Name = "labelHDKits"
        Me.labelHDKits.Size = New System.Drawing.Size(140, 20)
        Me.labelHDKits.TabIndex = 1
        Me.labelHDKits.Text = "HD Kits Enable:"
        Me.labelHDKits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'comboHDKits
        '
        Me.comboHDKits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboHDKits.FormattingEnabled = True
        Me.comboHDKits.Items.AddRange(New Object() {"False", "True"})
        Me.comboHDKits.Location = New System.Drawing.Point(158, 36)
        Me.comboHDKits.Name = "comboHDKits"
        Me.comboHDKits.Size = New System.Drawing.Size(80, 21)
        Me.comboHDKits.TabIndex = 15
        Me.toolTipMain.SetToolTip(Me.comboHDKits, "Enable/Disable the display equipment of " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "players in high resolution (recomended)" & _
        ".")
        '
        'numericCameraZoom
        '
        Me.numericCameraZoom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.numericCameraZoom.Increment = New Decimal(New Integer() {10, 0, 0, 0})
        Me.numericCameraZoom.Location = New System.Drawing.Point(408, 36)
        Me.numericCameraZoom.Maximum = New Decimal(New Integer() {1420, 0, 0, 0})
        Me.numericCameraZoom.Minimum = New Decimal(New Integer() {800, 0, 0, 0})
        Me.numericCameraZoom.Name = "numericCameraZoom"
        Me.numericCameraZoom.Size = New System.Drawing.Size(80, 20)
        Me.numericCameraZoom.TabIndex = 21
        Me.toolTipMain.SetToolTip(Me.numericCameraZoom, "The value of the distance of the camera." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "The smaller value represents a larger d" & _
        "istance view.")
        Me.numericCameraZoom.Value = New Decimal(New Integer() {800, 0, 0, 0})
        '
        'labelBallPreview
        '
        Me.labelBallPreview.Location = New System.Drawing.Point(12, 63)
        Me.labelBallPreview.Name = "labelBallPreview"
        Me.labelBallPreview.Size = New System.Drawing.Size(140, 20)
        Me.labelBallPreview.TabIndex = 2
        Me.labelBallPreview.Text = "Ball Preview Enable:"
        Me.labelBallPreview.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'comboBallPreview
        '
        Me.comboBallPreview.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboBallPreview.FormattingEnabled = True
        Me.comboBallPreview.Items.AddRange(New Object() {"False", "True"})
        Me.comboBallPreview.Location = New System.Drawing.Point(158, 62)
        Me.comboBallPreview.Name = "comboBallPreview"
        Me.comboBallPreview.Size = New System.Drawing.Size(80, 21)
        Me.comboBallPreview.TabIndex = 16
        Me.toolTipMain.SetToolTip(Me.comboBallPreview, "Enable/Disable displaying the ball before" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "the game, when selecting (recomended)." & _
        "")
        '
        'comboLowBoots
        '
        Me.comboLowBoots.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboLowBoots.FormattingEnabled = True
        Me.comboLowBoots.Items.AddRange(New Object() {"False", "True"})
        Me.comboLowBoots.Location = New System.Drawing.Point(158, 90)
        Me.comboLowBoots.Name = "comboLowBoots"
        Me.comboLowBoots.Size = New System.Drawing.Size(80, 21)
        Me.comboLowBoots.TabIndex = 17
        Me.toolTipMain.SetToolTip(Me.comboLowBoots, "Turn on if you computer configuration is low." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Used simpler algorithm for display" & _
        "ing the boot.")
        '
        'comboRandomBoots
        '
        Me.comboRandomBoots.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboRandomBoots.FormattingEnabled = True
        Me.comboRandomBoots.Items.AddRange(New Object() {"False", "True"})
        Me.comboRandomBoots.Location = New System.Drawing.Point(158, 117)
        Me.comboRandomBoots.Name = "comboRandomBoots"
        Me.comboRandomBoots.Size = New System.Drawing.Size(80, 21)
        Me.comboRandomBoots.TabIndex = 18
        Me.toolTipMain.SetToolTip(Me.comboRandomBoots, "Allow random choice boots " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "players which are not defined.")
        '
        'comboStadiumRoof
        '
        Me.comboStadiumRoof.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboStadiumRoof.FormattingEnabled = True
        Me.comboStadiumRoof.Items.AddRange(New Object() {"False", "True"})
        Me.comboStadiumRoof.Location = New System.Drawing.Point(158, 144)
        Me.comboStadiumRoof.Name = "comboStadiumRoof"
        Me.comboStadiumRoof.Size = New System.Drawing.Size(80, 21)
        Me.comboStadiumRoof.TabIndex = 19
        Me.toolTipMain.SetToolTip(Me.comboStadiumRoof, "Enable/Disable display of the roof of the stadium." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Not recommended at low values" & _
        " for the camera zoom.")
        '
        'comboStadiumClipping
        '
        Me.comboStadiumClipping.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboStadiumClipping.FormattingEnabled = True
        Me.comboStadiumClipping.Items.AddRange(New Object() {"False", "True"})
        Me.comboStadiumClipping.Location = New System.Drawing.Point(158, 171)
        Me.comboStadiumClipping.Name = "comboStadiumClipping"
        Me.comboStadiumClipping.Size = New System.Drawing.Size(80, 21)
        Me.comboStadiumClipping.TabIndex = 20
        Me.toolTipMain.SetToolTip(Me.comboStadiumClipping, "Include/Exclude cutting of the stadium for the camera." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "This option is recommende" & _
        "d for any value of the camera.")
        '
        'labelLowBoots
        '
        Me.labelLowBoots.Location = New System.Drawing.Point(12, 90)
        Me.labelLowBoots.Name = "labelLowBoots"
        Me.labelLowBoots.Size = New System.Drawing.Size(140, 20)
        Me.labelLowBoots.TabIndex = 3
        Me.labelLowBoots.Text = "Low Boots Enable:"
        Me.labelLowBoots.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'labelRandomBoots
        '
        Me.labelRandomBoots.Location = New System.Drawing.Point(12, 117)
        Me.labelRandomBoots.Name = "labelRandomBoots"
        Me.labelRandomBoots.Size = New System.Drawing.Size(140, 20)
        Me.labelRandomBoots.TabIndex = 4
        Me.labelRandomBoots.Text = "Random Boots Enable:"
        Me.labelRandomBoots.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'labelStadiumRoof
        '
        Me.labelStadiumRoof.Location = New System.Drawing.Point(12, 144)
        Me.labelStadiumRoof.Name = "labelStadiumRoof"
        Me.labelStadiumRoof.Size = New System.Drawing.Size(140, 20)
        Me.labelStadiumRoof.TabIndex = 5
        Me.labelStadiumRoof.Text = "Stadium Roof Enable:"
        Me.labelStadiumRoof.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'labelStadiumClipping
        '
        Me.labelStadiumClipping.Location = New System.Drawing.Point(12, 171)
        Me.labelStadiumClipping.Name = "labelStadiumClipping"
        Me.labelStadiumClipping.Size = New System.Drawing.Size(140, 20)
        Me.labelStadiumClipping.TabIndex = 6
        Me.labelStadiumClipping.Text = "Stadium Clipping Enable:"
        Me.labelStadiumClipping.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lineVertical
        '
        Me.lineVertical.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lineVertical.Location = New System.Drawing.Point(244, 36)
        Me.lineVertical.Name = "lineVertical"
        Me.lineVertical.Size = New System.Drawing.Size(2, 156)
        Me.lineVertical.TabIndex = 13
        '
        'labelCameraZoom
        '
        Me.labelCameraZoom.Location = New System.Drawing.Point(262, 36)
        Me.labelCameraZoom.Name = "labelCameraZoom"
        Me.labelCameraZoom.Size = New System.Drawing.Size(140, 20)
        Me.labelCameraZoom.TabIndex = 7
        Me.labelCameraZoom.Text = "Camera Zoom Value:"
        Me.labelCameraZoom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'numericSpeedModule
        '
        Me.numericSpeedModule.DecimalPlaces = 2
        Me.numericSpeedModule.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.numericSpeedModule.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.numericSpeedModule.Location = New System.Drawing.Point(408, 63)
        Me.numericSpeedModule.Maximum = New Decimal(New Integer() {13, 0, 0, 65536})
        Me.numericSpeedModule.Minimum = New Decimal(New Integer() {7, 0, 0, 65536})
        Me.numericSpeedModule.Name = "numericSpeedModule"
        Me.numericSpeedModule.Size = New System.Drawing.Size(80, 20)
        Me.numericSpeedModule.TabIndex = 22
        Me.toolTipMain.SetToolTip(Me.numericSpeedModule, "The value of speed movement of players." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "The higher value is the faster movement " & _
        "of players.")
        Me.numericSpeedModule.Value = New Decimal(New Integer() {7, 0, 0, 65536})
        '
        'numericReservedMemory
        '
        Me.numericReservedMemory.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.numericReservedMemory.Increment = New Decimal(New Integer() {8, 0, 0, 0})
        Me.numericReservedMemory.Location = New System.Drawing.Point(408, 90)
        Me.numericReservedMemory.Maximum = New Decimal(New Integer() {512, 0, 0, 0})
        Me.numericReservedMemory.Minimum = New Decimal(New Integer() {40, 0, 0, 0})
        Me.numericReservedMemory.Name = "numericReservedMemory"
        Me.numericReservedMemory.Size = New System.Drawing.Size(80, 20)
        Me.numericReservedMemory.TabIndex = 23
        Me.toolTipMain.SetToolTip(Me.numericReservedMemory, "The value of RAM memory reserved for kitserver (MB).")
        Me.numericReservedMemory.Value = New Decimal(New Integer() {40, 0, 0, 0})
        '
        'combo3DAnalyzer
        '
        Me.combo3DAnalyzer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combo3DAnalyzer.FormattingEnabled = True
        Me.combo3DAnalyzer.Items.AddRange(New Object() {"False", "True"})
        Me.combo3DAnalyzer.Location = New System.Drawing.Point(408, 117)
        Me.combo3DAnalyzer.Name = "combo3DAnalyzer"
        Me.combo3DAnalyzer.Size = New System.Drawing.Size(80, 21)
        Me.combo3DAnalyzer.TabIndex = 24
        Me.toolTipMain.SetToolTip(Me.combo3DAnalyzer, "If you have a problem with crash games turn on." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Recommended for older and incomp" & _
        "atible graphics.")
        '
        'comboRenderDirectX
        '
        Me.comboRenderDirectX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboRenderDirectX.FormattingEnabled = True
        Me.comboRenderDirectX.Items.AddRange(New Object() {"False", "True"})
        Me.comboRenderDirectX.Location = New System.Drawing.Point(408, 144)
        Me.comboRenderDirectX.Name = "comboRenderDirectX"
        Me.comboRenderDirectX.Size = New System.Drawing.Size(80, 21)
        Me.comboRenderDirectX.TabIndex = 25
        Me.toolTipMain.SetToolTip(Me.comboRenderDirectX, "Turn on using a resolution that is not supported " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "PES 6 Settings and then set yo" & _
        "ur resolution for full screen.")
        '
        'comboFullscreenResolution
        '
        Me.comboFullscreenResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboFullscreenResolution.FormattingEnabled = True
        Me.comboFullscreenResolution.Location = New System.Drawing.Point(408, 171)
        Me.comboFullscreenResolution.Name = "comboFullscreenResolution"
        Me.comboFullscreenResolution.Size = New System.Drawing.Size(80, 21)
        Me.comboFullscreenResolution.TabIndex = 26
        Me.toolTipMain.SetToolTip(Me.comboFullscreenResolution, "Select the appropriate resolution for the display game.")
        '
        'labelSpeedModule
        '
        Me.labelSpeedModule.Location = New System.Drawing.Point(262, 63)
        Me.labelSpeedModule.Name = "labelSpeedModule"
        Me.labelSpeedModule.Size = New System.Drawing.Size(140, 20)
        Me.labelSpeedModule.TabIndex = 8
        Me.labelSpeedModule.Text = "Speed Module Value:"
        Me.labelSpeedModule.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'labelReservedMemory
        '
        Me.labelReservedMemory.Location = New System.Drawing.Point(262, 90)
        Me.labelReservedMemory.Name = "labelReservedMemory"
        Me.labelReservedMemory.Size = New System.Drawing.Size(140, 20)
        Me.labelReservedMemory.TabIndex = 9
        Me.labelReservedMemory.Text = "Reaserved Memory Value:"
        Me.labelReservedMemory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'label3DAnalyzer
        '
        Me.label3DAnalyzer.Location = New System.Drawing.Point(262, 117)
        Me.label3DAnalyzer.Name = "label3DAnalyzer"
        Me.label3DAnalyzer.Size = New System.Drawing.Size(140, 20)
        Me.label3DAnalyzer.TabIndex = 10
        Me.label3DAnalyzer.Text = "3D Analyzer Enable:"
        Me.label3DAnalyzer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'labelRenderDirectX
        '
        Me.labelRenderDirectX.Location = New System.Drawing.Point(262, 144)
        Me.labelRenderDirectX.Name = "labelRenderDirectX"
        Me.labelRenderDirectX.Size = New System.Drawing.Size(140, 20)
        Me.labelRenderDirectX.TabIndex = 11
        Me.labelRenderDirectX.Text = "Render DirectX Enable:"
        Me.labelRenderDirectX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'labelFullscreenResolution
        '
        Me.labelFullscreenResolution.Location = New System.Drawing.Point(262, 171)
        Me.labelFullscreenResolution.Name = "labelFullscreenResolution"
        Me.labelFullscreenResolution.Size = New System.Drawing.Size(140, 20)
        Me.labelFullscreenResolution.TabIndex = 12
        Me.labelFullscreenResolution.Text = "Fullscreen Resolution:"
        Me.labelFullscreenResolution.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lineHorizontal
        '
        Me.lineHorizontal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lineHorizontal.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.lineHorizontal.Location = New System.Drawing.Point(12, 204)
        Me.lineHorizontal.Name = "lineHorizontal"
        Me.lineHorizontal.Size = New System.Drawing.Size(476, 2)
        Me.lineHorizontal.TabIndex = 14
        Me.lineHorizontal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'buttonPlay
        '
        Me.buttonPlay.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.buttonPlay.Location = New System.Drawing.Point(244, 209)
        Me.buttonPlay.Name = "buttonPlay"
        Me.buttonPlay.Size = New System.Drawing.Size(244, 40)
        Me.buttonPlay.TabIndex = 29
        Me.buttonPlay.Text = "PLAY  PATCH"
        Me.toolTipMain.SetToolTip(Me.buttonPlay, "Start your game PES 6")
        Me.buttonPlay.UseVisualStyleBackColor = True
        '
        'buttonSave
        '
        Me.buttonSave.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.buttonSave.Location = New System.Drawing.Point(12, 209)
        Me.buttonSave.Name = "buttonSave"
        Me.buttonSave.Size = New System.Drawing.Size(140, 40)
        Me.buttonSave.TabIndex = 27
        Me.buttonSave.Text = "SAVE SETTINGS"
        Me.toolTipMain.SetToolTip(Me.buttonSave, "Save the current setting" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "for the configuration files")
        Me.buttonSave.UseVisualStyleBackColor = True
        '
        'buttonDefault
        '
        Me.buttonDefault.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.buttonDefault.Location = New System.Drawing.Point(158, 209)
        Me.buttonDefault.Name = "buttonDefault"
        Me.buttonDefault.Size = New System.Drawing.Size(80, 40)
        Me.buttonDefault.TabIndex = 28
        Me.buttonDefault.Text = "DEFAULT"
        Me.toolTipMain.SetToolTip(Me.buttonDefault, "Set the recommended settings" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "for kitserver configuration files")
        Me.buttonDefault.UseVisualStyleBackColor = True
        '
        'toolTipMain
        '
        Me.toolTipMain.AutoPopDelay = 5000
        Me.toolTipMain.InitialDelay = 1000
        Me.toolTipMain.ReshowDelay = 100
        Me.toolTipMain.ShowAlways = True
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(500, 261)
        Me.Controls.Add(Me.buttonDefault)
        Me.Controls.Add(Me.buttonSave)
        Me.Controls.Add(Me.buttonPlay)
        Me.Controls.Add(Me.lineHorizontal)
        Me.Controls.Add(Me.labelFullscreenResolution)
        Me.Controls.Add(Me.labelRenderDirectX)
        Me.Controls.Add(Me.label3DAnalyzer)
        Me.Controls.Add(Me.labelReservedMemory)
        Me.Controls.Add(Me.labelSpeedModule)
        Me.Controls.Add(Me.comboFullscreenResolution)
        Me.Controls.Add(Me.comboRenderDirectX)
        Me.Controls.Add(Me.combo3DAnalyzer)
        Me.Controls.Add(Me.numericReservedMemory)
        Me.Controls.Add(Me.numericSpeedModule)
        Me.Controls.Add(Me.labelCameraZoom)
        Me.Controls.Add(Me.lineVertical)
        Me.Controls.Add(Me.labelStadiumClipping)
        Me.Controls.Add(Me.labelStadiumRoof)
        Me.Controls.Add(Me.labelRandomBoots)
        Me.Controls.Add(Me.labelLowBoots)
        Me.Controls.Add(Me.comboStadiumClipping)
        Me.Controls.Add(Me.comboStadiumRoof)
        Me.Controls.Add(Me.comboRandomBoots)
        Me.Controls.Add(Me.comboLowBoots)
        Me.Controls.Add(Me.comboBallPreview)
        Me.Controls.Add(Me.labelBallPreview)
        Me.Controls.Add(Me.numericCameraZoom)
        Me.Controls.Add(Me.comboHDKits)
        Me.Controls.Add(Me.labelHDKits)
        Me.Controls.Add(Me.MenuMain)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(256, 128)
        Me.MainMenuStrip = Me.MenuMain
        Me.MaximizeBox = False
        Me.Name = "FormMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Kitserver 6 Settings"
        Me.MenuMain.ResumeLayout(False)
        Me.MenuMain.PerformLayout()
        CType(Me.numericCameraZoom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numericSpeedModule, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numericReservedMemory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuMain As System.Windows.Forms.MenuStrip
    Friend WithEvents menuItemFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuItemEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuItemKitserver As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuItemSettings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuItemHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents labelHDKits As System.Windows.Forms.Label
    Friend WithEvents comboHDKits As System.Windows.Forms.ComboBox
    Friend WithEvents numericCameraZoom As System.Windows.Forms.NumericUpDown
    Friend WithEvents labelBallPreview As System.Windows.Forms.Label
    Friend WithEvents comboBallPreview As System.Windows.Forms.ComboBox
    Friend WithEvents comboLowBoots As System.Windows.Forms.ComboBox
    Friend WithEvents comboRandomBoots As System.Windows.Forms.ComboBox
    Friend WithEvents comboStadiumRoof As System.Windows.Forms.ComboBox
    Friend WithEvents comboStadiumClipping As System.Windows.Forms.ComboBox
    Friend WithEvents labelLowBoots As System.Windows.Forms.Label
    Friend WithEvents labelRandomBoots As System.Windows.Forms.Label
    Friend WithEvents labelStadiumRoof As System.Windows.Forms.Label
    Friend WithEvents labelStadiumClipping As System.Windows.Forms.Label
    Friend WithEvents lineVertical As System.Windows.Forms.Label
    Friend WithEvents labelCameraZoom As System.Windows.Forms.Label
    Friend WithEvents numericSpeedModule As System.Windows.Forms.NumericUpDown
    Friend WithEvents numericReservedMemory As System.Windows.Forms.NumericUpDown
    Friend WithEvents combo3DAnalyzer As System.Windows.Forms.ComboBox
    Friend WithEvents comboRenderDirectX As System.Windows.Forms.ComboBox
    Friend WithEvents comboFullscreenResolution As System.Windows.Forms.ComboBox
    Friend WithEvents labelSpeedModule As System.Windows.Forms.Label
    Friend WithEvents labelReservedMemory As System.Windows.Forms.Label
    Friend WithEvents label3DAnalyzer As System.Windows.Forms.Label
    Friend WithEvents labelRenderDirectX As System.Windows.Forms.Label
    Friend WithEvents labelFullscreenResolution As System.Windows.Forms.Label
    Private WithEvents lineHorizontal As System.Windows.Forms.Label
    Friend WithEvents buttonPlay As System.Windows.Forms.Button
    Friend WithEvents buttonSave As System.Windows.Forms.Button
    Friend WithEvents buttonDefault As System.Windows.Forms.Button
    Friend WithEvents menuFileItemPlay As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuFileItemSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menuFileItemSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuFileItemDefault As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuFileItemSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menuFileItemExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolTipMain As System.Windows.Forms.ToolTip
    Friend WithEvents menuHelpItemKitserver As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuHelpItemPES6Readme As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuHelpSpearator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menuHelpItemAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuFileItemFolder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuSettingsItemPES6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuEditItemAfs2fs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuEditItemBootServ As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuEditItemBserv As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuEditItemCameraZoomer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuEditItemKload As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuEditItemKserv As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuEditItemSpeeder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuKitserverItemKeyBind As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuKitserverItemLodCfg As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuKitserverItemSetup As System.Windows.Forms.ToolStripMenuItem

End Class
