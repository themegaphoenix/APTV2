<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Disclaimer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Disclaimer))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.checkBoxShowDisclaimer = New System.Windows.Forms.CheckBox()
        Me.btnContinue = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(297, 52)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = resources.GetString("Label1.Text")
        '
        'checkBoxShowDisclaimer
        '
        Me.checkBoxShowDisclaimer.AutoSize = True
        Me.checkBoxShowDisclaimer.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.checkBoxShowDisclaimer.Location = New System.Drawing.Point(17, 101)
        Me.checkBoxShowDisclaimer.Name = "checkBoxShowDisclaimer"
        Me.checkBoxShowDisclaimer.Size = New System.Drawing.Size(179, 17)
        Me.checkBoxShowDisclaimer.TabIndex = 25
        Me.checkBoxShowDisclaimer.Text = "Do not show this message again"
        Me.checkBoxShowDisclaimer.UseVisualStyleBackColor = True
        '
        'btnContinue
        '
        Me.btnContinue.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnContinue.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnContinue.Location = New System.Drawing.Point(293, 160)
        Me.btnContinue.Name = "btnContinue"
        Me.btnContinue.Size = New System.Drawing.Size(66, 25)
        Me.btnContinue.TabIndex = 26
        Me.btnContinue.Text = "Continue"
        Me.btnContinue.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnExit.Location = New System.Drawing.Point(221, 160)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(66, 25)
        Me.btnExit.TabIndex = 27
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'Disclaimer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(364, 193)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnContinue)
        Me.Controls.Add(Me.checkBoxShowDisclaimer)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Disclaimer"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.ShowMaximizeBox = False
        Me.Text = "Disclaimer"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents checkBoxShowDisclaimer As CheckBox
    Friend WithEvents btnContinue As Button
    Friend WithEvents btnExit As Button
End Class
