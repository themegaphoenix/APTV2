<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Home
    Inherits Syncfusion.Windows.Forms.MetroForm

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
        Me.CalculatorControl1 = New Syncfusion.Windows.Forms.Tools.CalculatorControl()
        Me.tabControlPanel = New Syncfusion.Windows.Forms.Tools.TabControlAdv()
        Me.pnlPhone = New Syncfusion.Windows.Forms.Tools.TabPageAdv()
        Me.lblVariant = New System.Windows.Forms.Label()
        Me.lblModel = New System.Windows.Forms.Label()
        Me.lblManufacturer = New System.Windows.Forms.Label()
        Me.picPhone = New System.Windows.Forms.PictureBox()
        Me.pnlBootloader = New Syncfusion.Windows.Forms.Tools.TabPageAdv()
        Me.pnlRecovery = New Syncfusion.Windows.Forms.Tools.TabPageAdv()
        Me.pnlRoot = New Syncfusion.Windows.Forms.Tools.TabPageAdv()
        Me.pnlXposed = New Syncfusion.Windows.Forms.Tools.TabPageAdv()
        Me.pnlGapps = New Syncfusion.Windows.Forms.Tools.TabPageAdv()
        Me.pnlUnbrick = New Syncfusion.Windows.Forms.Tools.TabPageAdv()
        Me.pnlAbout = New Syncfusion.Windows.Forms.Tools.TabPageAdv()
        Me.pnlBackup = New Syncfusion.Windows.Forms.Tools.TabPageAdv()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbModel = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        CType(Me.tabControlPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabControlPanel.SuspendLayout()
        Me.pnlPhone.SuspendLayout()
        CType(Me.picPhone, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbModel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CalculatorControl1
        '
        Me.CalculatorControl1.AccessibleDescription = "Calculator control"
        Me.CalculatorControl1.AccessibleName = "Calculator Control"
        Me.CalculatorControl1.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.CalculatorControl1.Culture = New System.Globalization.CultureInfo("en-GB")
        Me.CalculatorControl1.DoubleValue = 0R
        Me.CalculatorControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CalculatorControl1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CalculatorControl1.Location = New System.Drawing.Point(0, 0)
        Me.CalculatorControl1.MetroColor = System.Drawing.SystemColors.Control
        Me.CalculatorControl1.Name = "CalculatorControl1"
        Me.CalculatorControl1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CalculatorControl1.Size = New System.Drawing.Size(75, 23)
        Me.CalculatorControl1.TabIndex = 0
        Me.CalculatorControl1.Text = "CalculatorControl1"
        '
        'tabControlPanel
        '
        Me.tabControlPanel.ActiveTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.tabControlPanel.ActiveTabForeColor = System.Drawing.Color.Empty
        Me.tabControlPanel.BackColor = System.Drawing.Color.White
        Me.tabControlPanel.BeforeTouchSize = New System.Drawing.Size(740, 433)
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
        Me.tabControlPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabControlPanel.FocusOnTabClick = False
        Me.tabControlPanel.Font = New System.Drawing.Font("Roboto Condensed", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabControlPanel.InactiveTabColor = System.Drawing.Color.White
        Me.tabControlPanel.InActiveTabForeColor = System.Drawing.Color.Empty
        Me.tabControlPanel.ItemSize = New System.Drawing.Size(79, 22)
        Me.tabControlPanel.Location = New System.Drawing.Point(0, 0)
        Me.tabControlPanel.Multiline = True
        Me.tabControlPanel.Name = "tabControlPanel"
        Me.tabControlPanel.Padding = New System.Drawing.Point(10, 5)
        Me.tabControlPanel.SeparatorColor = System.Drawing.SystemColors.ControlDark
        Me.tabControlPanel.ShowSeparator = False
        Me.tabControlPanel.Size = New System.Drawing.Size(740, 433)
        Me.tabControlPanel.TabIndex = 1
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
        Me.pnlPhone.Location = New System.Drawing.Point(1, 31)
        Me.pnlPhone.Name = "pnlPhone"
        Me.pnlPhone.ShowCloseButton = True
        Me.pnlPhone.Size = New System.Drawing.Size(737, 400)
        Me.pnlPhone.TabIndex = 1
        Me.pnlPhone.Text = "Phone"
        Me.pnlPhone.ThemesEnabled = False
        '
        'lblVariant
        '
        Me.lblVariant.AutoSize = True
        Me.lblVariant.Location = New System.Drawing.Point(489, 225)
        Me.lblVariant.Name = "lblVariant"
        Me.lblVariant.Size = New System.Drawing.Size(41, 18)
        Me.lblVariant.TabIndex = 5
        Me.lblVariant.Text = "Label1"
        '
        'lblModel
        '
        Me.lblModel.AutoSize = True
        Me.lblModel.Location = New System.Drawing.Point(489, 186)
        Me.lblModel.Name = "lblModel"
        Me.lblModel.Size = New System.Drawing.Size(40, 18)
        Me.lblModel.TabIndex = 4
        Me.lblModel.Text = "Model"
        '
        'lblManufacturer
        '
        Me.lblManufacturer.AutoSize = True
        Me.lblManufacturer.Location = New System.Drawing.Point(489, 147)
        Me.lblManufacturer.Name = "lblManufacturer"
        Me.lblManufacturer.Size = New System.Drawing.Size(41, 18)
        Me.lblManufacturer.TabIndex = 3
        Me.lblManufacturer.Text = "Label1"
        '
        'picPhone
        '
        Me.picPhone.Location = New System.Drawing.Point(32, 33)
        Me.picPhone.Name = "picPhone"
        Me.picPhone.Size = New System.Drawing.Size(201, 330)
        Me.picPhone.TabIndex = 2
        Me.picPhone.TabStop = False
        '
        'pnlBootloader
        '
        Me.pnlBootloader.Image = Nothing
        Me.pnlBootloader.ImageSize = New System.Drawing.Size(16, 16)
        Me.pnlBootloader.Location = New System.Drawing.Point(1, 31)
        Me.pnlBootloader.Name = "pnlBootloader"
        Me.pnlBootloader.ShowCloseButton = True
        Me.pnlBootloader.Size = New System.Drawing.Size(737, 400)
        Me.pnlBootloader.TabIndex = 3
        Me.pnlBootloader.Text = "Bootloader"
        Me.pnlBootloader.ThemesEnabled = False
        '
        'pnlRecovery
        '
        Me.pnlRecovery.Image = Nothing
        Me.pnlRecovery.ImageSize = New System.Drawing.Size(16, 16)
        Me.pnlRecovery.Location = New System.Drawing.Point(1, 31)
        Me.pnlRecovery.Name = "pnlRecovery"
        Me.pnlRecovery.ShowCloseButton = True
        Me.pnlRecovery.Size = New System.Drawing.Size(737, 400)
        Me.pnlRecovery.TabIndex = 2
        Me.pnlRecovery.Text = "Recovery"
        Me.pnlRecovery.ThemesEnabled = False
        '
        'pnlRoot
        '
        Me.pnlRoot.Image = Nothing
        Me.pnlRoot.ImageSize = New System.Drawing.Size(16, 16)
        Me.pnlRoot.Location = New System.Drawing.Point(1, 31)
        Me.pnlRoot.Name = "pnlRoot"
        Me.pnlRoot.ShowCloseButton = True
        Me.pnlRoot.Size = New System.Drawing.Size(737, 400)
        Me.pnlRoot.TabIndex = 4
        Me.pnlRoot.Text = "Root"
        Me.pnlRoot.ThemesEnabled = False
        '
        'pnlXposed
        '
        Me.pnlXposed.Image = Nothing
        Me.pnlXposed.ImageSize = New System.Drawing.Size(16, 16)
        Me.pnlXposed.Location = New System.Drawing.Point(1, 31)
        Me.pnlXposed.Name = "pnlXposed"
        Me.pnlXposed.ShowCloseButton = True
        Me.pnlXposed.Size = New System.Drawing.Size(737, 400)
        Me.pnlXposed.TabIndex = 5
        Me.pnlXposed.Text = "Xposed"
        Me.pnlXposed.ThemesEnabled = False
        '
        'pnlGapps
        '
        Me.pnlGapps.Image = Nothing
        Me.pnlGapps.ImageSize = New System.Drawing.Size(16, 16)
        Me.pnlGapps.Location = New System.Drawing.Point(1, 31)
        Me.pnlGapps.Name = "pnlGapps"
        Me.pnlGapps.ShowCloseButton = True
        Me.pnlGapps.Size = New System.Drawing.Size(737, 400)
        Me.pnlGapps.TabIndex = 6
        Me.pnlGapps.Text = "Gapps"
        Me.pnlGapps.ThemesEnabled = False
        '
        'pnlUnbrick
        '
        Me.pnlUnbrick.Image = Nothing
        Me.pnlUnbrick.ImageSize = New System.Drawing.Size(16, 16)
        Me.pnlUnbrick.Location = New System.Drawing.Point(1, 31)
        Me.pnlUnbrick.Name = "pnlUnbrick"
        Me.pnlUnbrick.ShowCloseButton = True
        Me.pnlUnbrick.Size = New System.Drawing.Size(737, 400)
        Me.pnlUnbrick.TabIndex = 8
        Me.pnlUnbrick.Text = "Unbrick"
        Me.pnlUnbrick.ThemesEnabled = False
        '
        'pnlAbout
        '
        Me.pnlAbout.Image = Nothing
        Me.pnlAbout.ImageSize = New System.Drawing.Size(16, 16)
        Me.pnlAbout.Location = New System.Drawing.Point(1, 31)
        Me.pnlAbout.Name = "pnlAbout"
        Me.pnlAbout.ShowCloseButton = True
        Me.pnlAbout.Size = New System.Drawing.Size(737, 400)
        Me.pnlAbout.TabIndex = 9
        Me.pnlAbout.Text = "About"
        Me.pnlAbout.ThemesEnabled = False
        '
        'pnlBackup
        '
        Me.pnlBackup.Image = Nothing
        Me.pnlBackup.ImageSize = New System.Drawing.Size(16, 16)
        Me.pnlBackup.Location = New System.Drawing.Point(1, 31)
        Me.pnlBackup.Name = "pnlBackup"
        Me.pnlBackup.ShowCloseButton = True
        Me.pnlBackup.Size = New System.Drawing.Size(737, 400)
        Me.pnlBackup.TabIndex = 10
        Me.pnlBackup.Text = "Backup"
        Me.pnlBackup.ThemesEnabled = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(396, 225)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 18)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Variant"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(396, 186)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 18)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Model"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(396, 147)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 18)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Manufacturer"
        '
        'cmbModel
        '
        Me.cmbModel.BackColor = System.Drawing.Color.LightGray
        Me.cmbModel.BeforeTouchSize = New System.Drawing.Size(321, 26)
        Me.cmbModel.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.cmbModel.Font = New System.Drawing.Font("Roboto Condensed", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbModel.Location = New System.Drawing.Point(300, 68)
        Me.cmbModel.Name = "cmbModel"
        Me.cmbModel.ReadOnly = True
        Me.cmbModel.Size = New System.Drawing.Size(321, 26)
        Me.cmbModel.Sorted = True
        Me.cmbModel.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cmbModel.TabIndex = 10
        '
        'Home
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(740, 433)
        Me.Controls.Add(Me.tabControlPanel)
        Me.Controls.Add(Me.CalculatorControl1)
        Me.Name = "Home"
        Me.Text = "APTV2"
        CType(Me.tabControlPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabControlPanel.ResumeLayout(False)
        Me.pnlPhone.ResumeLayout(False)
        Me.pnlPhone.PerformLayout()
        CType(Me.picPhone, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbModel, System.ComponentModel.ISupportInitialize).EndInit()
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
End Class
