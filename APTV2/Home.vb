Imports System.ComponentModel
Imports System.Globalization
Imports System.IO
Imports System.Net
Imports System.Threading
Imports System.Xml
Imports APTV2.My.Resources
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Tools

Public Class Home
    Inherits MetroForm

    'todo better interface
    'todo add all features
    'todo add more recoveries

#Region "Variables"

    'Public variables
    Dim strManufacturer As String = ""

    Dim strModel As String = ""
    Dim strVariant As String = ""
    Dim LabelToOutput As TextBox
    Dim progressBar As ProgressBar

    'document needs to be open during the whole program, otherwise it would be opening and closing
    ReadOnly xmlDoc As New XmlDocument()

#End Region

    Private Sub Home_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'read xml file and load in to the dropbox
        ReadXml()
    End Sub

#Region "Reloading data"

    Sub ReadXml()
        Try
            xmlDoc.Load(My.Settings.xmlDocumentName)
            Dim nodes As XmlNodeList = xmlDoc.DocumentElement.SelectNodes("/root/phone")
            Dim manufacturer = "", model = "", variantXml = ""

            For Each node As XmlNode In nodes
                manufacturer = node.SelectSingleNode("manufacturer").InnerText
                model = node.SelectSingleNode("model").InnerText
                variantXml = node.SelectSingleNode("variant").InnerText
                cmbModel.Items.Add(manufacturer & " " & model & " " & variantXml)
            Next
        Catch ex As Exception
            MessageBox.Show(Strings.Home_readXML_File_not_found_or_file_corrupt)
        End Try

        Try

            'chosen model will Not break the program
            'Console.WriteLine(My.Settings.LastChosenModel)
            cmbModel.SelectedItem = My.Settings.LastChosenModel
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        ReloadInfo()
    End Sub

    Private Sub cmbModel_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbModel.SelectedValueChanged
        'save the changes so the next time is open, it loads the last selected model
        My.Settings.LastChosenModel = cmbModel.SelectedItem.ToString()
        'Console.WriteLine(My.Settings.LastChosenModel)
        My.Settings.Save()
        'reload the correct information
        ReloadInfo()
    End Sub

    Private Sub ReloadInfo()
        'get the selection information
        Dim strPhone As String = cmbModel.SelectedItem
        Console.WriteLine(strPhone)
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
                cmbRecovery.Items.Clear()

                For Each nod As XmlNode In node.SelectNodes("twrp/version")
                    Dim recoveryTwrp As String = nod.Attributes("id").Value
                    If cmbRecovery.Items.Contains("TWRP " & recoveryTwrp) = False Then
                        cmbRecovery.Items.Add("TWRP " & recoveryTwrp)

                    End If
                    cmbRecovery.SelectedIndex = 0
                Next

            End If
        Next

        'populate dropdown stuff
        AddToComboBoxesXml("/root/Gapps/version", "Gapps Application ", cmbGApps)
        AddToComboBoxesXml("/root/magiskInstaller/version", "Magisk ", cmbRoot)
    End Sub

#End Region

#Region "Bootloader"

    Private Sub btnUnlockBootloader_Click(sender As Object, e As EventArgs) Handles btnUnlockBootloader.Click
        Dim unlockKey As String = txtBoxUnlockKey.Text
        Dim proceed As Boolean
        Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("fr-Fr")
        If unlockKey = "" Then
            Dim result As DialogResult = MessageBox.Show(Strings.Home_btnUnlockBootloader_Click_,
                                                         Strings.Home_btnUnlockBootloader_Click_Proceed,
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
            commands = {{"adb", "reboot bootloader", Strings.Home_btnUnlockBootloader_Click_Rebooting_to_bootloader},
                        {"fastboot", "oem unlock" + unlockKey, Strings.Home_btnUnlockBootloader_Click_Unlocking_bootloader},
                        {"fastboot", "reboot", Strings.Home_btnUnlockBootloader_Click_Rebooting_device}
                       }
            LabelToOutput = txtBoxBootloader
            Task.Run(Sub() RunComands(commands))
        End If
    End Sub

    Private Sub btnLockBootloader_Click(sender As Object, e As EventArgs) Handles btnLockBootloader.Click
        Dim unlockKey As String = txtBoxUnlockKey.Text
        Dim proceed As Boolean

        If unlockKey = "" Then
            Dim result As DialogResult = MessageBox.Show(Strings.Home_btnLockBootloader_Click_,
                                                         Strings.Home_btnUnlockBootloader_Click_Proceed,
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
            commands = {{"adb", "reboot bootloader", Strings.Home_btnLockBootloader_Click_Rebooting_to_bootloader},
                        {"fastboot", "oem relock" + unlockKey,
                         Strings.Home_btnLockBootloader_Click_Relocking_bootloader___make_sure_device_is_plugged__otherwise_it_will_not_output_anything_},
                        {"fastboot", "reboot", "Rebooting device"}
                       }
            LabelToOutput = txtBoxBootloader
            Task.Run(Sub() RunComands(commands))
        End If
    End Sub

#End Region

#Region "Recovery"

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
                        commands = {{"adb", "reboot bootloader", Strings.Home_btnLockBootloader_Click_Rebooting_to_bootloader},
                                    {"fastboot", "flash recovery" & "downloads/twrp-3.1.1-0.img",
                                     "Flashing recovery: (make sure device is plugged, otherwise it will not output anything)"},
                                    {"fastboot", "reboot", "Rebooting device"}
                                   }
                        Await Task.Run(Sub() RunComands(commands))
                    End If
                Next
            End If
        Next
    End Sub

#End Region

#Region "Root"

    Private Async Sub btnFlashMagisk_Click(sender As Object, e As EventArgs) Handles btnFlashMagisk.Click
        'gets the chosenRecovery Value
        Dim strRoot As String = cmbRoot.SelectedItem
        Dim strRootSplit As String() = strRoot.Split(New Char() {" "c})
        Console.WriteLine(strRootSplit(1))
        Dim chosenRoot As String = strRootSplit(1)

        Dim url As String = GetInfoXmlInner("/root/magiskInstaller/version", chosenRoot)
        'Console.WriteLine(url)
        If url <> "0" Then
            Dim fileName As String = "downloads/magisk-" & chosenRoot & ".zip"
            'change the progress bar
            progressBar = progressBarRoot

            'downloads the file
            'the file is checked it it exists first in the function
            Await DownloadFileAsync(url, fileName)

            'run the right adb commands
            'todo fix the commands
            LabelToOutput = txtBoxRoot
            Dim commands(3, 3) As String
            commands = {{"adb", "reboot bootloader", Strings.Home_btnLockBootloader_Click_Rebooting_to_bootloader},
                        {"fastboot", "flash recovery" & "downloads/twrp-3.1.1-0.img",
                         "Flashing recovery: (make sure device is plugged, otherwise it will not output anything)"},
                        {"fastboot", "reboot", "Rebooting device"}}

            Await Task.Run(Sub() RunComands(commands))
        End If
    End Sub

#End Region

#Region "Gapps"

    Private Async Sub btnGappsInstall_Click(sender As Object, e As EventArgs) Handles btnGappsInstall.Click
        'gets the chosenRecovery Value
        Dim strGapps As String = cmbGApps.SelectedItem
        Dim strGappsSplit As String() = strGapps.Split(New Char() {" "c})
        'Console.WriteLine(strGappsSplit(2))
        Dim chosenGapps As String = strGappsSplit(2)

        Dim url As String = GetInfoXmlInner("/root/Gapps/version", chosenGapps)
        'Console.WriteLine(url)
        If url <> "0" Then
            Dim fileName As String = "downloads/gapps-" & chosenGapps & ".apk"
            'change the progress bar
            progressBar = progressBarGApps

            'downloads the file
            'the file is checked it it exists first in the function
            Await DownloadFileAsync(url, fileName)

            'run the right adb commands

            'todo fix the commands
            LabelToOutput = txtBoxGApps
            Dim commands(3, 3) As String
            commands = {{"adb", "devices", "Showing all devices"},
                        {"adb", "install " & fileName,
                         Strings.Home_btnGappsInstall_Click_Installing_app_on_the_device_make_sure_device_is_plugged_in__otherwise_it_will_not_output_anything_}
                       }
            Await Task.Run(Sub() RunComands(commands))
        End If
    End Sub

#End Region

#Region "Unbrick"

    Private Sub btnFlashUnbr_Click(sender As Object, e As EventArgs) Handles btnFlashUnbr.Click
    End Sub

#End Region

#Region "Download File"

    Private Sub UpdateProgressBar(a As Integer)
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
            MessageBox.Show(Strings.Home_Completed_Download_has_been_canceled_)
        Else
            MessageBox.Show(Strings.Home_Completed_Download_completed_)
        End If
    End Sub

#End Region

#Region "ADB Commands"

    'runs the adb commands
    Private Sub RunComands(commands(,) As String)
        For i = 0 To (commands.Length - 1)
            Dim process = New Process()
            process.StartInfo = createStartInfo(commands(i, 0), commands(i, 1))
            process.EnableRaisingEvents = True
            AddHandler process.Exited, Sub(sendera As Object, ea As EventArgs)
                                           'Console.WriteLine(process.ExitTime)
                                           'Console.WriteLine(". Processing done.")
                                           ' output line n when output is ready (= all lines are present)
                                           'Console.WriteLine(lines(1))
                                       End Sub
            ' catch standard output
            AddHandler process.OutputDataReceived, Sub(senderb As Object, eb As DataReceivedEventArgs)
                                                       If (Not String.IsNullOrEmpty(eb.Data)) Then
                                                           Dim b As String = String.Format("{0}> {1}", DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"), eb.Data)
                                                           Console.WriteLine(b)
                                                           UpdateTextBox(b)

                                                       End If
                                                   End Sub
            ' catch errors
            AddHandler process.ErrorDataReceived, Sub(senderc As Object, ec As DataReceivedEventArgs)
                                                      Dim a As String = String.Format("! {0}", ec.Data)
                                                      Console.WriteLine(a)
                                                      UpdateTextBox(a)
                                                  End Sub
            ' start process
            UpdateTextBox(commands(i, 2))
            process.Start()
            ' and wait for output
            process.BeginOutputReadLine()
            ' and wait for errors :-)
            process.BeginErrorReadLine()
            process.WaitForExit()
            UpdateTextBox(Environment.NewLine & process.ExitTime & Environment.NewLine & ".ProcessingDone")
            process.Close()

        Next
    End Sub

    'the process information stuff
    Private Function createStartInfo(executable As String, arguments As String) As ProcessStartInfo
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
    Private Sub UpdateTextBox(a As String)
        If Me.InvokeRequired Then
            Dim args() As String = {a}
            Me.Invoke(New Action(Of String)(AddressOf UpdateTextBox), args)
            Return
        End If
        LabelToOutput.AppendText(a & Environment.NewLine)
    End Sub

#End Region

#Region "Get Info from the XML File"

    Private Function GetInfoXmlInner(parentNodes As String, valueToFind As String) As String
        xmlDoc.Load(My.Settings.xmlDocumentName)
        Dim nodes As XmlNodeList = xmlDoc.DocumentElement.SelectNodes(parentNodes)
        For Each node As XmlNode In nodes

            Dim id As String = node.Attributes("id").Value
            If valueToFind = id Then

                Return node.InnerText
                Exit Function
            End If
        Next
        MessageBox.Show(Strings.Home_getInfoXMLInner_Not_Found)
        Return 0
    End Function

    Private Sub AddToComboBoxesXml(nodes As String, prefix As String, ByRef dropdown As ComboBoxAdv)
        'clear all the items
        dropdown.Items.Clear()
        Try


            'scan through all the items and add them if they are not already present
            Dim parentNode2 As XmlNodeList = xmlDoc.DocumentElement.SelectNodes(nodes)
            For Each node As XmlNode In parentNode2
                Dim version As String = node.Attributes("id").Value
                If dropdown.Items.Contains(prefix & version) = False Then
                    dropdown.Items.Add(prefix & version)
                End If
            Next
            dropdown.SelectedIndex = 0
        Catch ex As Exception

        End Try
    End Sub

#End Region

End Class