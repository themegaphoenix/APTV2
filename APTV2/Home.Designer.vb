<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Home
    Inherits Syncfusion.Windows.Forms.MetroForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Home))
        Me.CalculatorControl1 = New Syncfusion.Windows.Forms.Tools.CalculatorControl()
        Me.tabControlPanel = New Syncfusion.Windows.Forms.Tools.TabControlAdv()
        Me.pnlPhone = New Syncfusion.Windows.Forms.Tools.TabPageAdv()
        Me.cmbModel = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblVariant = New System.Windows.Forms.Label()
        Me.lblModel = New System.Windows.Forms.Label()
        Me.lblManufacturer = New System.Windows.Forms.Label()
        Me.picPhone = New System.Windows.Forms.PictureBox()
        Me.pnlBootloader = New Syncfusion.Windows.Forms.Tools.TabPageAdv()
        Me.TabControlAdv1 = New Syncfusion.Windows.Forms.Tools.TabControlAdv()
        Me.TabPageAdv1 = New Syncfusion.Windows.Forms.Tools.TabPageAdv()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtBoxUnlockKey = New System.Windows.Forms.TextBox()
        Me.btnLockBootloader = New System.Windows.Forms.Button()
        Me.btnUnlockBootloader = New System.Windows.Forms.Button()
        Me.TabPageAdv2 = New Syncfusion.Windows.Forms.Tools.TabPageAdv()
        Me.TabPageAdv3 = New Syncfusion.Windows.Forms.Tools.TabPageAdv()
        Me.txtBoxBootloader = New System.Windows.Forms.TextBox()
        Me.pnlRecovery = New Syncfusion.Windows.Forms.Tools.TabPageAdv()
        Me.progressBarRecovery = New System.Windows.Forms.ProgressBar()
        Me.txtBoxRecovery = New System.Windows.Forms.TextBox()
        Me.cmbRecovery = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.btnFlashRecovery = New System.Windows.Forms.Button()
        Me.pnlRoot = New Syncfusion.Windows.Forms.Tools.TabPageAdv()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.progressBarRoot = New System.Windows.Forms.ProgressBar()
        Me.cmbRoot = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.btnFlashMagisk = New System.Windows.Forms.Button()
        Me.txtBoxRoot = New System.Windows.Forms.TextBox()
        Me.pnlXposed = New Syncfusion.Windows.Forms.Tools.TabPageAdv()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.pnlGapps = New Syncfusion.Windows.Forms.Tools.TabPageAdv()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.progressBarGApps = New System.Windows.Forms.ProgressBar()
        Me.cmbGApps = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.btnGappsInstall = New System.Windows.Forms.Button()
        Me.txtBoxGApps = New System.Windows.Forms.TextBox()
        Me.pnlUnbrick = New Syncfusion.Windows.Forms.Tools.TabPageAdv()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TabControlUnbrick = New Syncfusion.Windows.Forms.Tools.TabControlAdv()
        Me.tabUnb1 = New Syncfusion.Windows.Forms.Tools.TabPageAdv()
        Me.ComboBoxAdv1 = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.btnFlashUnbr = New System.Windows.Forms.Button()
        Me.tabUnb2 = New Syncfusion.Windows.Forms.Tools.TabPageAdv()
        Me.tabUnb3 = New Syncfusion.Windows.Forms.Tools.TabPageAdv()
        Me.pnlAbout = New Syncfusion.Windows.Forms.Tools.TabPageAdv()
        Me.pnlBackup = New Syncfusion.Windows.Forms.Tools.TabPageAdv()
        Me.pnlSettings = New Syncfusion.Windows.Forms.Tools.TabPageAdv()
        CType(Me.tabControlPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabControlPanel.SuspendLayout()
        Me.pnlPhone.SuspendLayout()
        CType(Me.cmbModel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPhone, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBootloader.SuspendLayout()
        CType(Me.TabControlAdv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControlAdv1.SuspendLayout()
        Me.TabPageAdv1.SuspendLayout()
        Me.pnlRecovery.SuspendLayout()
        CType(Me.cmbRecovery, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlRoot.SuspendLayout()
        CType(Me.cmbRoot, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlXposed.SuspendLayout()
        Me.pnlGapps.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbGApps, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlUnbrick.SuspendLayout()
        CType(Me.TabControlUnbrick, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControlUnbrick.SuspendLayout()
        Me.tabUnb1.SuspendLayout()
        CType(Me.ComboBoxAdv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CalculatorControl1
        '
        resources.ApplyResources(Me.CalculatorControl1, "CalculatorControl1")
        Me.CalculatorControl1.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.CalculatorControl1.DoubleValue = 0R
        Me.CalculatorControl1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CalculatorControl1.MetroColor = System.Drawing.SystemColors.Control
        Me.CalculatorControl1.Name = "CalculatorControl1"
        '
        'tabControlPanel
        '
        resources.ApplyResources(Me.tabControlPanel, "tabControlPanel")
        Me.tabControlPanel.ActiveTabForeColor = System.Drawing.Color.Empty
        Me.tabControlPanel.BackColor = System.Drawing.Color.White
        Me.tabControlPanel.BeforeTouchSize = New System.Drawing.Size(740, 433)
        Me.tabControlPanel.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tabControlPanel.CloseButtonForeColor = System.Drawing.Color.Empty
        Me.tabControlPanel.CloseButtonHoverForeColor = System.Drawing.Color.Empty
        Me.tabControlPanel.CloseButtonPressedForeColor = System.Drawing.Color.Empty
        Me.tabControlPanel.Controls.Add(Me.pnlPhone)
        Me.tabControlPanel.Controls.Add(Me.pnlBootloader)
        Me.tabControlPanel.Controls.Add(Me.pnlRecovery)
        Me.tabControlPanel.Controls.Add(Me.pnlRoot)
        Me.tabControlPanel.Controls.Add(Me.pnlXposed)
        Me.tabControlPanel.Controls.Add(Me.pnlGapps)
        Me.tabControlPanel.Controls.Add(Me.pnlUnbrick)
        Me.tabControlPanel.Controls.Add(Me.pnlAbout)
        Me.tabControlPanel.Controls.Add(Me.pnlBackup)
        Me.tabControlPanel.Controls.Add(Me.pnlSettings)
        Me.tabControlPanel.FocusOnTabClick = False
        Me.tabControlPanel.InactiveTabColor = System.Drawing.Color.White
        Me.tabControlPanel.InActiveTabForeColor = System.Drawing.Color.Empty
        Me.tabControlPanel.Name = "tabControlPanel"
        Me.tabControlPanel.SeparatorColor = System.Drawing.SystemColors.ControlDark
        Me.tabControlPanel.ShowSeparator = False
        Me.tabControlPanel.TabPanelBackColor = System.Drawing.Color.White
        Me.tabControlPanel.TabStyle = GetType(Syncfusion.Windows.Forms.Tools.TabRendererMetro)
        '
        'pnlPhone
        '
        Me.pnlPhone.Controls.Add(Me.cmbModel)
        Me.pnlPhone.Controls.Add(Me.Label1)
        Me.pnlPhone.Controls.Add(Me.Label2)
        Me.pnlPhone.Controls.Add(Me.Label3)
        Me.pnlPhone.Controls.Add(Me.lblVariant)
        Me.pnlPhone.Controls.Add(Me.lblModel)
        Me.pnlPhone.Controls.Add(Me.lblManufacturer)
        Me.pnlPhone.Controls.Add(Me.picPhone)
        Me.pnlPhone.Image = Nothing
        Me.pnlPhone.ImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.pnlPhone, "pnlPhone")
        Me.pnlPhone.Name = "pnlPhone"
        Me.pnlPhone.ShowCloseButton = True
        Me.pnlPhone.ThemesEnabled = False
        '
        'cmbModel
        '
        Me.cmbModel.BeforeTouchSize = New System.Drawing.Size(282, 26)
        resources.ApplyResources(Me.cmbModel, "cmbModel")
        Me.cmbModel.Name = "cmbModel"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'lblVariant
        '
        resources.ApplyResources(Me.lblVariant, "lblVariant")
        Me.lblVariant.Name = "lblVariant"
        '
        'lblModel
        '
        resources.ApplyResources(Me.lblModel, "lblModel")
        Me.lblModel.Name = "lblModel"
        '
        'lblManufacturer
        '
        resources.ApplyResources(Me.lblManufacturer, "lblManufacturer")
        Me.lblManufacturer.Name = "lblManufacturer"
        '
        'picPhone
        '
        resources.ApplyResources(Me.picPhone, "picPhone")
        Me.picPhone.Name = "picPhone"
        Me.picPhone.TabStop = False
        '
        'pnlBootloader
        '
        Me.pnlBootloader.Controls.Add(Me.TabControlAdv1)
        Me.pnlBootloader.Controls.Add(Me.txtBoxBootloader)
        Me.pnlBootloader.Image = Nothing
        Me.pnlBootloader.ImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.pnlBootloader, "pnlBootloader")
        Me.pnlBootloader.Name = "pnlBootloader"
        Me.pnlBootloader.ShowCloseButton = True
        Me.pnlBootloader.ThemesEnabled = False
        '
        'TabControlAdv1
        '
        Me.TabControlAdv1.ActiveTabForeColor = System.Drawing.Color.Empty
        Me.TabControlAdv1.BeforeTouchSize = New System.Drawing.Size(364, 352)
        Me.TabControlAdv1.CloseButtonForeColor = System.Drawing.Color.Empty
        Me.TabControlAdv1.CloseButtonHoverForeColor = System.Drawing.Color.Empty
        Me.TabControlAdv1.CloseButtonPressedForeColor = System.Drawing.Color.Empty
        Me.TabControlAdv1.Controls.Add(Me.TabPageAdv1)
        Me.TabControlAdv1.Controls.Add(Me.TabPageAdv2)
        Me.TabControlAdv1.Controls.Add(Me.TabPageAdv3)
        Me.TabControlAdv1.InActiveTabForeColor = System.Drawing.Color.Empty
        resources.ApplyResources(Me.TabControlAdv1, "TabControlAdv1")
        Me.TabControlAdv1.Name = "TabControlAdv1"
        Me.TabControlAdv1.SeparatorColor = System.Drawing.SystemColors.ControlDark
        Me.TabControlAdv1.ShowSeparator = False
        '
        'TabPageAdv1
        '
        Me.TabPageAdv1.Controls.Add(Me.Label4)
        Me.TabPageAdv1.Controls.Add(Me.txtBoxUnlockKey)
        Me.TabPageAdv1.Controls.Add(Me.btnLockBootloader)
        Me.TabPageAdv1.Controls.Add(Me.btnUnlockBootloader)
        Me.TabPageAdv1.Image = Nothing
        Me.TabPageAdv1.ImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.TabPageAdv1, "TabPageAdv1")
        Me.TabPageAdv1.Name = "TabPageAdv1"
        Me.TabPageAdv1.ShowCloseButton = True
        Me.TabPageAdv1.ThemesEnabled = False
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'txtBoxUnlockKey
        '
        resources.ApplyResources(Me.txtBoxUnlockKey, "txtBoxUnlockKey")
        Me.txtBoxUnlockKey.Name = "txtBoxUnlockKey"
        '
        'btnLockBootloader
        '
        resources.ApplyResources(Me.btnLockBootloader, "btnLockBootloader")
        Me.btnLockBootloader.Name = "btnLockBootloader"
        Me.btnLockBootloader.UseVisualStyleBackColor = True
        '
        'btnUnlockBootloader
        '
        resources.ApplyResources(Me.btnUnlockBootloader, "btnUnlockBootloader")
        Me.btnUnlockBootloader.Name = "btnUnlockBootloader"
        Me.btnUnlockBootloader.UseVisualStyleBackColor = True
        '
        'TabPageAdv2
        '
        Me.TabPageAdv2.Image = Nothing
        Me.TabPageAdv2.ImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.TabPageAdv2, "TabPageAdv2")
        Me.TabPageAdv2.Name = "TabPageAdv2"
        Me.TabPageAdv2.ShowCloseButton = True
        Me.TabPageAdv2.ThemesEnabled = False
        '
        'TabPageAdv3
        '
        Me.TabPageAdv3.Image = Nothing
        Me.TabPageAdv3.ImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.TabPageAdv3, "TabPageAdv3")
        Me.TabPageAdv3.Name = "TabPageAdv3"
        Me.TabPageAdv3.ShowCloseButton = True
        Me.TabPageAdv3.ThemesEnabled = False
        '
        'txtBoxBootloader
        '
        Me.txtBoxBootloader.BackColor = System.Drawing.SystemColors.HotTrack
        resources.ApplyResources(Me.txtBoxBootloader, "txtBoxBootloader")
        Me.txtBoxBootloader.Name = "txtBoxBootloader"
        '
        'pnlRecovery
        '
        Me.pnlRecovery.Controls.Add(Me.progressBarRecovery)
        Me.pnlRecovery.Controls.Add(Me.txtBoxRecovery)
        Me.pnlRecovery.Controls.Add(Me.cmbRecovery)
        Me.pnlRecovery.Controls.Add(Me.btnFlashRecovery)
        Me.pnlRecovery.Image = Nothing
        Me.pnlRecovery.ImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.pnlRecovery, "pnlRecovery")
        Me.pnlRecovery.Name = "pnlRecovery"
        Me.pnlRecovery.ShowCloseButton = True
        Me.pnlRecovery.ThemesEnabled = False
        '
        'progressBarRecovery
        '
        resources.ApplyResources(Me.progressBarRecovery, "progressBarRecovery")
        Me.progressBarRecovery.Name = "progressBarRecovery"
        Me.progressBarRecovery.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        '
        'txtBoxRecovery
        '
        Me.txtBoxRecovery.BackColor = System.Drawing.SystemColors.HotTrack
        resources.ApplyResources(Me.txtBoxRecovery, "txtBoxRecovery")
        Me.txtBoxRecovery.Name = "txtBoxRecovery"
        '
        'cmbRecovery
        '
        Me.cmbRecovery.BeforeTouchSize = New System.Drawing.Size(172, 26)
        resources.ApplyResources(Me.cmbRecovery, "cmbRecovery")
        Me.cmbRecovery.Name = "cmbRecovery"
        '
        'btnFlashRecovery
        '
        resources.ApplyResources(Me.btnFlashRecovery, "btnFlashRecovery")
        Me.btnFlashRecovery.Name = "btnFlashRecovery"
        Me.btnFlashRecovery.UseVisualStyleBackColor = True
        '
        'pnlRoot
        '
        Me.pnlRoot.Controls.Add(Me.Label5)
        Me.pnlRoot.Controls.Add(Me.progressBarRoot)
        Me.pnlRoot.Controls.Add(Me.cmbRoot)
        Me.pnlRoot.Controls.Add(Me.btnFlashMagisk)
        Me.pnlRoot.Controls.Add(Me.txtBoxRoot)
        Me.pnlRoot.Image = Nothing
        Me.pnlRoot.ImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.pnlRoot, "pnlRoot")
        Me.pnlRoot.Name = "pnlRoot"
        Me.pnlRoot.ShowCloseButton = True
        Me.pnlRoot.ThemesEnabled = False
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'progressBarRoot
        '
        resources.ApplyResources(Me.progressBarRoot, "progressBarRoot")
        Me.progressBarRoot.Name = "progressBarRoot"
        Me.progressBarRoot.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        '
        'cmbRoot
        '
        Me.cmbRoot.BeforeTouchSize = New System.Drawing.Size(172, 26)
        resources.ApplyResources(Me.cmbRoot, "cmbRoot")
        Me.cmbRoot.Name = "cmbRoot"
        '
        'btnFlashMagisk
        '
        resources.ApplyResources(Me.btnFlashMagisk, "btnFlashMagisk")
        Me.btnFlashMagisk.Name = "btnFlashMagisk"
        Me.btnFlashMagisk.UseVisualStyleBackColor = True
        '
        'txtBoxRoot
        '
        Me.txtBoxRoot.BackColor = System.Drawing.SystemColors.HotTrack
        resources.ApplyResources(Me.txtBoxRoot, "txtBoxRoot")
        Me.txtBoxRoot.Name = "txtBoxRoot"
        '
        'pnlXposed
        '
        Me.pnlXposed.Controls.Add(Me.Label6)
        Me.pnlXposed.Image = Nothing
        Me.pnlXposed.ImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.pnlXposed, "pnlXposed")
        Me.pnlXposed.Name = "pnlXposed"
        Me.pnlXposed.ShowCloseButton = True
        Me.pnlXposed.ThemesEnabled = False
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'pnlGapps
        '
        Me.pnlGapps.Controls.Add(Me.PictureBox1)
        Me.pnlGapps.Controls.Add(Me.progressBarGApps)
        Me.pnlGapps.Controls.Add(Me.cmbGApps)
        Me.pnlGapps.Controls.Add(Me.btnGappsInstall)
        Me.pnlGapps.Controls.Add(Me.txtBoxGApps)
        Me.pnlGapps.Image = Nothing
        Me.pnlGapps.ImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.pnlGapps, "pnlGapps")
        Me.pnlGapps.Name = "pnlGapps"
        Me.pnlGapps.ShowCloseButton = True
        Me.pnlGapps.ThemesEnabled = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.APTV2.My.Resources.Resources.opengapps
        resources.ApplyResources(Me.PictureBox1, "PictureBox1")
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.TabStop = False
        '
        'progressBarGApps
        '
        resources.ApplyResources(Me.progressBarGApps, "progressBarGApps")
        Me.progressBarGApps.Name = "progressBarGApps"
        Me.progressBarGApps.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        '
        'cmbGApps
        '
        Me.cmbGApps.BeforeTouchSize = New System.Drawing.Size(208, 26)
        resources.ApplyResources(Me.cmbGApps, "cmbGApps")
        Me.cmbGApps.Name = "cmbGApps"
        '
        'btnGappsInstall
        '
        resources.ApplyResources(Me.btnGappsInstall, "btnGappsInstall")
        Me.btnGappsInstall.Name = "btnGappsInstall"
        Me.btnGappsInstall.UseVisualStyleBackColor = True
        '
        'txtBoxGApps
        '
        Me.txtBoxGApps.BackColor = System.Drawing.SystemColors.HotTrack
        resources.ApplyResources(Me.txtBoxGApps, "txtBoxGApps")
        Me.txtBoxGApps.Name = "txtBoxGApps"
        '
        'pnlUnbrick
        '
        Me.pnlUnbrick.Controls.Add(Me.TextBox1)
        Me.pnlUnbrick.Controls.Add(Me.TabControlUnbrick)
        Me.pnlUnbrick.Image = Nothing
        Me.pnlUnbrick.ImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.pnlUnbrick, "pnlUnbrick")
        Me.pnlUnbrick.Name = "pnlUnbrick"
        Me.pnlUnbrick.ShowCloseButton = True
        Me.pnlUnbrick.ThemesEnabled = False
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.HotTrack
        resources.ApplyResources(Me.TextBox1, "TextBox1")
        Me.TextBox1.Name = "TextBox1"
        '
        'TabControlUnbrick
        '
        Me.TabControlUnbrick.ActiveTabForeColor = System.Drawing.Color.Empty
        Me.TabControlUnbrick.BeforeTouchSize = New System.Drawing.Size(364, 352)
        Me.TabControlUnbrick.CloseButtonForeColor = System.Drawing.Color.Empty
        Me.TabControlUnbrick.CloseButtonHoverForeColor = System.Drawing.Color.Empty
        Me.TabControlUnbrick.CloseButtonPressedForeColor = System.Drawing.Color.Empty
        Me.TabControlUnbrick.Controls.Add(Me.tabUnb1)
        Me.TabControlUnbrick.Controls.Add(Me.tabUnb2)
        Me.TabControlUnbrick.Controls.Add(Me.tabUnb3)
        Me.TabControlUnbrick.InActiveTabForeColor = System.Drawing.Color.Empty
        resources.ApplyResources(Me.TabControlUnbrick, "TabControlUnbrick")
        Me.TabControlUnbrick.Name = "TabControlUnbrick"
        Me.TabControlUnbrick.SeparatorColor = System.Drawing.SystemColors.ControlDark
        Me.TabControlUnbrick.ShowSeparator = False
        '
        'tabUnb1
        '
        Me.tabUnb1.Controls.Add(Me.ComboBoxAdv1)
        Me.tabUnb1.Controls.Add(Me.btnFlashUnbr)
        Me.tabUnb1.Image = Nothing
        Me.tabUnb1.ImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.tabUnb1, "tabUnb1")
        Me.tabUnb1.Name = "tabUnb1"
        Me.tabUnb1.ShowCloseButton = True
        Me.tabUnb1.ThemesEnabled = False
        '
        'ComboBoxAdv1
        '
        Me.ComboBoxAdv1.BeforeTouchSize = New System.Drawing.Size(208, 26)
        resources.ApplyResources(Me.ComboBoxAdv1, "ComboBoxAdv1")
        Me.ComboBoxAdv1.Name = "ComboBoxAdv1"
        '
        'btnFlashUnbr
        '
        resources.ApplyResources(Me.btnFlashUnbr, "btnFlashUnbr")
        Me.btnFlashUnbr.Name = "btnFlashUnbr"
        Me.btnFlashUnbr.UseVisualStyleBackColor = True
        '
        'tabUnb2
        '
        Me.tabUnb2.Image = Nothing
        Me.tabUnb2.ImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.tabUnb2, "tabUnb2")
        Me.tabUnb2.Name = "tabUnb2"
        Me.tabUnb2.ShowCloseButton = True
        Me.tabUnb2.ThemesEnabled = False
        '
        'tabUnb3
        '
        Me.tabUnb3.Image = Nothing
        Me.tabUnb3.ImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.tabUnb3, "tabUnb3")
        Me.tabUnb3.Name = "tabUnb3"
        Me.tabUnb3.ShowCloseButton = True
        Me.tabUnb3.ThemesEnabled = False
        '
        'pnlAbout
        '
        Me.pnlAbout.Image = Nothing
        Me.pnlAbout.ImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.pnlAbout, "pnlAbout")
        Me.pnlAbout.Name = "pnlAbout"
        Me.pnlAbout.ShowCloseButton = True
        Me.pnlAbout.ThemesEnabled = False
        '
        'pnlBackup
        '
        Me.pnlBackup.Image = Nothing
        Me.pnlBackup.ImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.pnlBackup, "pnlBackup")
        Me.pnlBackup.Name = "pnlBackup"
        Me.pnlBackup.ShowCloseButton = True
        Me.pnlBackup.ThemesEnabled = False
        '
        'pnlSettings
        '
        Me.pnlSettings.Image = Nothing
        Me.pnlSettings.ImageSize = New System.Drawing.Size(16, 16)
        resources.ApplyResources(Me.pnlSettings, "pnlSettings")
        Me.pnlSettings.Name = "pnlSettings"
        Me.pnlSettings.ShowCloseButton = True
        Me.pnlSettings.ThemesEnabled = False
        '
        'Home
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tabControlPanel)
        Me.Controls.Add(Me.CalculatorControl1)
        Me.Name = "Home"
        CType(Me.tabControlPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabControlPanel.ResumeLayout(False)
        Me.pnlPhone.ResumeLayout(False)
        Me.pnlPhone.PerformLayout()
        CType(Me.cmbModel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPhone, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBootloader.ResumeLayout(False)
        Me.pnlBootloader.PerformLayout()
        CType(Me.TabControlAdv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControlAdv1.ResumeLayout(False)
        Me.TabPageAdv1.ResumeLayout(False)
        Me.TabPageAdv1.PerformLayout()
        Me.pnlRecovery.ResumeLayout(False)
        Me.pnlRecovery.PerformLayout()
        CType(Me.cmbRecovery, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlRoot.ResumeLayout(False)
        Me.pnlRoot.PerformLayout()
        CType(Me.cmbRoot, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlXposed.ResumeLayout(False)
        Me.pnlXposed.PerformLayout()
        Me.pnlGapps.ResumeLayout(False)
        Me.pnlGapps.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbGApps, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlUnbrick.ResumeLayout(False)
        Me.pnlUnbrick.PerformLayout()
        CType(Me.TabControlUnbrick, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControlUnbrick.ResumeLayout(False)
        Me.tabUnb1.ResumeLayout(False)
        CType(Me.ComboBoxAdv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CalculatorControl1 As Syncfusion.Windows.Forms.Tools.CalculatorControl
    Friend WithEvents tabControlPanel As Syncfusion.Windows.Forms.Tools.TabControlAdv
    Friend WithEvents pnlPhone As Syncfusion.Windows.Forms.Tools.TabPageAdv
    Friend WithEvents pnlBootloader As Syncfusion.Windows.Forms.Tools.TabPageAdv
    Friend WithEvents pnlRecovery As Syncfusion.Windows.Forms.Tools.TabPageAdv
    Friend WithEvents pnlRoot As Syncfusion.Windows.Forms.Tools.TabPageAdv
    Friend WithEvents pnlXposed As Syncfusion.Windows.Forms.Tools.TabPageAdv
    Friend WithEvents pnlGapps As Syncfusion.Windows.Forms.Tools.TabPageAdv
    Friend WithEvents pnlUnbrick As Syncfusion.Windows.Forms.Tools.TabPageAdv
    Friend WithEvents pnlAbout As Syncfusion.Windows.Forms.Tools.TabPageAdv
    Friend WithEvents pnlBackup As Syncfusion.Windows.Forms.Tools.TabPageAdv
    Friend WithEvents picPhone As PictureBox
    Friend WithEvents lblManufacturer As Label
    Friend WithEvents lblModel As Label
    Friend WithEvents lblVariant As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbModel As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents pnlSettings As Syncfusion.Windows.Forms.Tools.TabPageAdv
    Friend WithEvents txtBoxBootloader As TextBox
    Friend WithEvents cmbRecovery As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents btnFlashRecovery As Button
    Friend WithEvents txtBoxRecovery As TextBox
    Friend WithEvents progressBarRecovery As ProgressBar
    Friend WithEvents Label5 As Label
    Friend WithEvents progressBarRoot As ProgressBar
    Friend WithEvents cmbRoot As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents btnFlashMagisk As Button
    Friend WithEvents txtBoxRoot As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents progressBarGApps As ProgressBar
    Friend WithEvents cmbGApps As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents btnGappsInstall As Button
    Friend WithEvents txtBoxGApps As TextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TabControlUnbrick As Syncfusion.Windows.Forms.Tools.TabControlAdv
    Friend WithEvents tabUnb1 As Syncfusion.Windows.Forms.Tools.TabPageAdv
    Friend WithEvents ComboBoxAdv1 As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents btnFlashUnbr As Button
    Friend WithEvents tabUnb2 As Syncfusion.Windows.Forms.Tools.TabPageAdv
    Friend WithEvents tabUnb3 As Syncfusion.Windows.Forms.Tools.TabPageAdv
    Friend WithEvents TabControlAdv1 As Syncfusion.Windows.Forms.Tools.TabControlAdv
    Friend WithEvents TabPageAdv1 As Syncfusion.Windows.Forms.Tools.TabPageAdv
    Friend WithEvents Label4 As Label
    Friend WithEvents txtBoxUnlockKey As TextBox
    Friend WithEvents btnLockBootloader As Button
    Friend WithEvents btnUnlockBootloader As Button
    Friend WithEvents TabPageAdv2 As Syncfusion.Windows.Forms.Tools.TabPageAdv
    Friend WithEvents TabPageAdv3 As Syncfusion.Windows.Forms.Tools.TabPageAdv
End Class
