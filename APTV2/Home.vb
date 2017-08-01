Imports Syncfusion.Windows.Forms
Imports System.Xml
Imports System.IO
Imports System.Net
Imports System.Threading

Imports System.Diagnostics
Imports System.ComponentModel

Public Class Home
    Inherits MetroForm

    'better interface
    'add all features
    'add more recoveries

#Region "Variables"

    'Public variables
    Dim strManufacturer As String = ""

    Dim strModel As String = ""
    Dim strVariant As String = ""
    Dim LabelToOutput As TextBox
    Dim progressBar As ProgressBar

    'document needs to be open during the whole program, otherwise it would be opening and closing
    Dim xmlDoc As New XmlDocument()

#End Region

    ' The stopwatch which we will be using to calculate the download speed

    Private Sub Home_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'read xml file and load in to the dropbox
        readXML()

    End Sub

#Region "Reloading data"

    Sub readXML()
        Try
            xmlDoc.Load(My.Settings.xmlDocumentName)
            Dim nodes As XmlNodeList = xmlDoc.DocumentElement.SelectNodes("/root/phone")
            Dim manufacturer As String = "", model As String = "", variantXml As String = ""

            For Each node As XmlNode In nodes
                manufacturer = node.SelectSingleNode("manufacturer").InnerText
                model = node.SelectSingleNode("model").InnerText
                variantXml = node.SelectSingleNode("variant").InnerText
                cmbModel.Items.Add(manufacturer & " " & model & " " & variantXml)
            Next
        Catch ex As Exception
            MessageBox.Show("File not found or file corrupt")
        End Try

        Try

            'chosen model will Not break the program
            'Console.WriteLine(My.Settings.LastChosenModel)
            cmbModel.SelectedItem = My.Settings.LastChosenModel
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        reloadInfo()

    End Sub

    Private Sub cmbModel_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbModel.SelectedValueChanged
        'save the changes so the next time is open, it loads the last selected model
        My.Settings.LastChosenModel = cmbModel.SelectedItem.ToString()
        'Console.WriteLine(My.Settings.LastChosenModel)
        My.Settings.Save()
        'reload the correct information
        reloadInfo()

    End Sub

    Private Sub reloadInfo()
        'get the selection information
        Dim strPhone As String = cmbModel.SelectedItem
        Dim strPhoneSplit As String() = strPhone.Split(New Char() {" "c})
        'Console.WriteLine(strPhoneSplit(1))

        'change the variables
        strManufacturer = strPhoneSplit(0)
        strModel = strPhoneSplit(1)
        strVariant = strPhoneSplit(2)

        'load the correct information into the labels
        xmlDoc.Load(My.Settings.xmlDocumentName)
        Dim nodes As XmlNodeList = xmlDoc.DocumentElement.SelectNodes("/root/phone")
        For Each node As XmlNode In nodes
            If strVariant = node.SelectSingleNode("variant").InnerText Then

                'update Labels in the homepage
                lblManufacturer.Text = node.SelectSingleNode("manufacturer").InnerText
                lblModel.Text = node.SelectSingleNode("model").InnerText
                lblVariant.Text = node.SelectSingleNode("variant").InnerText

                'update Picture
                Try
                    Dim strPicture As String = "phones/pictures/" & node.SelectSingleNode("picture").InnerText
                    picPhone.BackgroundImage = Image.FromFile(strPicture)
                Catch ex As Exception
                    MessageBox.Show(ex.ToString)
                End Try

                'get recovery info
                For Each nod As XmlNode In node.SelectNodes("twrp/version")
                    Dim recoveryTWRP As String = nod.Attributes("id").Value
                    Console.WriteLine(recoveryTWRP)
                    If cmbRecovery.Items.Contains("TWRP " & recoveryTWRP) Then
                    Else
                        cmbRecovery.Items.Add("TWRP " & recoveryTWRP)
                    End If
                Next

            End If
        Next

    End Sub

#End Region

#Region "Bootloader"

    Private Sub btnUnlockBootloader_Click(sender As Object, e As EventArgs) Handles btnUnlockBootloader.Click
        Dim unlockKey As String = txtBoxUnlockKey.Text
        Dim proceed As Boolean

        If unlockKey = "" Then
            Dim result As DialogResult = MessageBox.Show("You have not entered a unlock key." + vbLf +
                                                          "Some devices might not require it." + vbLf +
                                                          "Continue?",
                                                          "Proceed",
                                                          MessageBoxButtons.YesNo,
                                                          MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                proceed = True
            Else
                proceed = False
            End If
        End If

        If proceed Then
            Dim commands(3, 3) As String
            commands = {{"adb", "reboot bootloader", "Rebooting to bootloader"},
                {"fastboot", "oem unlock" + unlockKey, "Unlocking bootloader: (make sure device is plugged, otherwise it will not output anything)"},
                {"fastboot", "reboot", "Rebooting device"}
            }
            LabelToOutput = txtBoxBootloader
            Task.Run(Sub() runComands(commands))
        End If

    End Sub

    Private Sub btnLockBootloader_Click(sender As Object, e As EventArgs) Handles btnLockBootloader.Click
        Dim unlockKey As String = txtBoxUnlockKey.Text
        Dim proceed As Boolean

        If unlockKey = "" Then
            Dim result As DialogResult = MessageBox.Show("You have not entered a unlock key." + vbLf +
                                                              "Some devices might not require it." + vbLf +
                                                              "Continue?",
                                                              "Proceed",
                                                              MessageBoxButtons.YesNo,
                                                              MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                proceed = True
            Else
                proceed = False
            End If
        End If

        If proceed Then
            Dim commands(3, 3) As String
            commands = {{"adb", "reboot bootloader", "Rebooting to bootloader"},
                {"fastboot", "oem relock" + unlockKey, "RElocking bootloader: (make sure device is plugged, otherwise it will not output anything)"},
                {"fastboot", "reboot", "Rebooting device"}
            }
            'Dim executable As String() = {"fastboot"}
            'Dim arguments As String() = {"oem relock " + unlockKey}
            'Dim description As String() = {"Unlocking bootloader: (make sure device is plugged, otherwise it will not output anything)"}
            ''Dim executable As String() = {"adb"}
            ''Dim arguments As String() = {"help"}
            ''Console.WriteLine(arguments(0))
            LabelToOutput = txtBoxBootloader
            Task.Run(Sub() runComands(commands))
        End If

    End Sub

#End Region
    Private Async Sub btnFlashRecovery_ClickAsync(sender As Object, e As EventArgs) Handles btnFlashRecovery.Click
        'gets the chosenRecovery Value
        Dim strRecovery As String = cmbRecovery.SelectedItem
        Dim strRecoverySplit As String() = strRecovery.Split(New Char() {" "c})
        Console.WriteLine(strRecoverySplit(1))
        Dim chosenRecovery As String = strRecoverySplit(1)


        'loads the document and gets the current variant,
        'which searches for the right version of the recovery and downloads it
        xmlDoc.Load(My.Settings.xmlDocumentName)
        Dim nodes As XmlNodeList = xmlDoc.DocumentElement.SelectNodes("/root/phone")
        For Each node As XmlNode In nodes
            If strVariant = node.SelectSingleNode("variant").InnerText Then
                For Each nod As XmlNode In node.SelectNodes("twrp/version")
                    Dim id As String = nod.Attributes("id").Value
                    If chosenRecovery = id Then

                        Dim fileName As String = "downloads/twrp-" & id & ".img"
                        'change the progress bar
                        progressBar = progressBarRecovery

                        'downloads the file
                        'the file is checked it it exists first in the function
                        Await DownloadFileAsync(nod.InnerText, fileName)

                        'run the right adb commands
                        LabelToOutput = txtBoxRecovery
                        Dim commands(3, 3) As String
                        commands = {{"adb", "reboot bootloader", "Rebooting to bootloader"},
                                                {"fastboot", "flash recovery" & "downloads/twrp-3.1.1-0.img", "Flashing recovery: (make sure device is plugged, otherwise it will not output anything)"},
                                                {"fastboot", "reboot", "Rebooting device"}
                                            }
                        Await Task.Run(Sub() runComands(commands))
                    End If
                Next
            End If
        Next

    End Sub

#Region "Download File"

    Private Sub UpdateProgressBar(ByVal a As Integer)
        If Me.InvokeRequired Then
            Dim args() As String = {a}
            Me.Invoke(New Action(Of String)(AddressOf UpdateProgressBar), args)
            Return
        End If
        progressBar.Value = CInt(a)

    End Sub

    Public Async Function DownloadFileAsync(urlAddress As String, filename As String) As Task(Of Integer)
        Using webClient = New WebClient()
            'updates the information
            AddHandler webClient.DownloadFileCompleted, AddressOf Completed
            AddHandler webClient.DownloadProgressChanged, AddressOf ProgressChanged

            Try
                ' Start downloading the file if the file does not exist
                If File.Exists(filename) = False Then
                    Await webClient.DownloadFileTaskAsync(New Uri(urlAddress), filename)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End Using
        Return 3

    End Function

    ' The event that will fire whenever the progress of the WebClient is changed
    Private Sub ProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs)

        'Console.WriteLine(e.ProgressPercentage)
        ' Update the progressbar percentage
        UpdateProgressBar(e.ProgressPercentage)

    End Sub

    ' The event that will trigger when the WebClient is completed
    Private Sub Completed(sender As Object, e As AsyncCompletedEventArgs)

        If e.Cancelled = True Then
            MessageBox.Show("Download has been canceled.")
        Else
            MessageBox.Show("Download completed!")
        End If
    End Sub

#End Region

#Region "ADB Commands"

    'runs the adb commands
    Private Sub runComands(ByVal commands(,) As String)
        For i As Integer = 0 To (commands.Length - 1)
            Dim process = New Process()
            process.StartInfo = createStartInfo(commands(i, 0), commands(i, 1))
            process.EnableRaisingEvents = True
            AddHandler process.Exited, Sub(ByVal sendera As Object, ByVal ea As System.EventArgs)
                                           'Console.WriteLine(process.ExitTime)
                                           'Console.WriteLine(". Processing done.")
                                           ' output line n when output is ready (= all lines are present)
                                           'Console.WriteLine(lines(1))
                                           'UpdateTextBox(Environment.NewLine & process.ExitTime & Environment.NewLine & ".ProcessingDone")
                                       End Sub
            ' catch standard output
            AddHandler process.OutputDataReceived, Sub(ByVal senderb As Object, ByVal eb As System.Diagnostics.DataReceivedEventArgs)
                                                       If (Not String.IsNullOrEmpty(eb.Data)) Then
                                                           Dim b As String = String.Format("{0}> {1}", DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"), eb.Data)
                                                           Console.WriteLine(b)
                                                           UpdateTextBox(b)

                                                       End If
                                                   End Sub
            ' catch errors
            AddHandler process.ErrorDataReceived, Sub(ByVal senderc As Object, ByVal ec As System.Diagnostics.DataReceivedEventArgs)
                                                      Dim a As String = String.Format("! {0}", ec.Data)
                                                      Console.WriteLine(a)
                                                      UpdateTextBox(a)

                                                  End Sub
            ' start process
            UpdateTextBox(commands(i, 2))
            Dim result = process.Start()
            ' and wait for output
            process.BeginOutputReadLine()
            ' and wait for errors :-)
            process.BeginErrorReadLine()
            process.WaitForExit()
            process.Close()

        Next

    End Sub

    'the process information stuff
    Private Function createStartInfo(ByVal executable As String, ByVal arguments As String) As ProcessStartInfo
        Dim processStartInfo = New ProcessStartInfo(executable, arguments)
        processStartInfo.WorkingDirectory = Path.GetDirectoryName(executable)
        ' we want to read standard output
        processStartInfo.RedirectStandardOutput = True
        ' we want to read the standard error
        processStartInfo.RedirectStandardError = True
        processStartInfo.UseShellExecute = False
        processStartInfo.ErrorDialog = False
        processStartInfo.CreateNoWindow = True
        Return processStartInfo
    End Function

    'output the error and stuff to the chosen label
    Private Sub UpdateTextBox(ByVal a As String)
        If Me.InvokeRequired Then
            Dim args() As String = {a}
            Me.Invoke(New Action(Of String)(AddressOf UpdateTextBox), args)
            Return
        End If
        LabelToOutput.AppendText(a & Environment.NewLine)

    End Sub

#End Region

End Class