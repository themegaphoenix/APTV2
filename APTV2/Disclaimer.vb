Imports Syncfusion.Windows.Forms

Public Class Disclaimer
    Inherits MetroForm

    Private Sub checkBoxShowDisclaimer_CheckedChanged(sender As Object, e As EventArgs) Handles checkBoxShowDisclaimer.CheckedChanged
        If checkBoxShowDisclaimer.Checked = True Then
            'it will enable the button
            My.Forms.Home.checkBoxShowDisclaimer.Checked = False
        Else
            My.Forms.Home.checkBoxShowDisclaimer.Checked = True
        End If

        My.Settings.Save()
    End Sub

    Private Sub btnContinue_Click(sender As Object, e As EventArgs) Handles btnContinue.Click
        Me.Close()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        My.Forms.Home.Close()
    End Sub
End Class
