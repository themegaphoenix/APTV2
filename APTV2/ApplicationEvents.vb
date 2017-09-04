Imports System.Globalization
Imports System.Threading.Thread
Imports System.Threading

Namespace My

    ' The following events are available for MyApplication:
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active.
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication
        Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
            Dim language = My.Settings.selectedLanguage

            Thread.CurrentThread.CurrentUICulture = New CultureInfo(language)
            Thread.CurrentThread.CurrentCulture = New CultureInfo(language)
            CultureInfo.DefaultThreadCurrentCulture = New CultureInfo(language)


            'this code does not work as it just keeps restarting the application,
            'as the the selected value changes
            'Select Case language
            '    Case "en"
            '        My.Forms.Home.cmbBoxLanguage.SelectedItem = "English"
            '    Case "fr"
            '        My.Forms.Home.cmbBoxLanguage.SelectedItem = "French"
            '    Case "de"
            '        My.Forms.Home.cmbBoxLanguage.SelectedItem = "German"
            '    Case "ru"
            '        My.Forms.Home.cmbBoxLanguage.SelectedItem = "Russian"
            '    Case "pt"
            '        My.Forms.Home.cmbBoxLanguage.SelectedItem = "Portuguese"
            '    Case Else
            '        My.Forms.Home.cmbBoxLanguage.SelectedItem = "English"

            'End Select

        End Sub

    End Class

End Namespace