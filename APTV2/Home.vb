Imports System.ComponentModel
Imports System.IO
Imports System.IO.Compression
Imports System.Net
Imports System.Xml
Imports APTV2.My.Resources
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Tools
Imports System.Threading.Thread
Imports System.Globalization
Imports System.Threading

Public Class Home
    Inherits MetroForm

    'todo add xposed

#Region "Variables"

    'Public variables
    Dim LabelToOutput As TextBox

    Dim progressBar As ProgressBar

    'document needs to be open during the whole program, otherwise it would be opening and closing
    ReadOnly xmlDoc As New XmlDocument()

#End Region

    Private Sub Home_Load(sender As Object, e As EventArgs) Handles MyBase.Load




        'read xml file and load in to the dropbox
        FindTheFiles()
        If My.Settings.checkForUpdates Then
            CheckXMLUpdates()
        End If
        If My.Settings.showDisclaimer = True Then
            My.Forms.Disclaimer.Show()
        End If

    End Sub

#Region "Options"

#Region "Bootloader"

    Private Async Sub btnUnlockBootloader_Click(sender As Object, e As EventArgs) Handles btnUnlockBootloader.Click
        Dim unlockKey As String = txtBoxUnlockKey.Text
        Dim proceed As Boolean = True
        If unlockKey = "" Then
            Dim result As DialogResult = MessageBox.Show(Strings.Home_btnUnlockBootloader_Click_,
                                                         Strings.Home_btnUnlockBootloader_Click_Proceed,
                                                         MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Question)
            If result = DialogResult.No Then
                proceed = False
            End If
        End If
        If proceed Then
            Dim commands(3, 3) As String
            commands = {{"adb", "reboot bootloader", Strings.Rebooting_to_bootloader},
                        {"fastboot", "oem unlock" + unlockKey,
                         Strings.Home_btnUnlockBootloader_Click_Unlocking_bootloader},
                        {"fastboot", "reboot", Strings.Home_btnUnlockBootloader_Click_Rebooting_device}
                       }
            LabelToOutput = txtBoxBootloader
            Await Task.Run(Sub() RunComands(commands))

            Dim result2 As DialogResult = MessageBox.Show(Strings.Home_btnUnlockBootloader_Click_Would_you_like_to_flash_a_custom_recovery_like_TWRP_,
                                                          Strings.Home_btnUnlockBootloader_Click_Root_the_device_,
                                                          MessageBoxButtons.YesNo,
                                                          MessageBoxIcon.Question)
            If result2 = DialogResult.Yes Then
                tabControlPanel.SelectedTab = pnlRecovery
            End If
        End If
    End Sub

    Private Async Sub btnLockBootloader_Click(sender As Object, e As EventArgs) Handles btnLockBootloader.Click
        Dim unlockKey As String = txtBoxUnlockKey.Text
        Dim proceed As Boolean = True

        If unlockKey = "" Then
            Dim result As DialogResult = MessageBox.Show(Strings.Home_btnLockBootloader_Click_,
                                                         Strings.Home_btnUnlockBootloader_Click_Proceed,
                                                         MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Question)
            If result = DialogResult.No Then
                proceed = False
            End If
        End If

        If proceed Then
            Dim commands(3, 3) As String
            commands = {{"adb", "reboot bootloader", Strings.Rebooting_to_bootloader},
                        {"fastboot", "oem relock" + unlockKey,
                         Strings.
                             Home_btnLockBootloader_Click_Relocking_bootloader___make_sure_device_is_plugged__otherwise_it_will_not_output_anything_},
                        {"fastboot", "reboot", "Rebooting device"}
                       }
            LabelToOutput = txtBoxBootloader
            Await Task.Run(Sub() RunComands(commands))
        End If
    End Sub

#End Region

#Region "Recovery"

    Private Async Sub btnFlashRecovery_ClickAsync(sender As Object, e As EventArgs) Handles btnFlashRecovery.Click
        'gets the chosenRecovery Value
        Dim chosenRecovery As String = GetInfoCombox(cmbRecovery, 1)

        'loads the document and gets the current variant,
        'which searches for the right version of the recovery and downloads it

        Dim fileName As String = "downloads/twrp-" & chosenRecovery & ".img"
        Dim url As String = GetInfoXmlInner("/root/phone", chosenRecovery, True, "recovery/twrp/version", "")

        'change the progress bar
        progressBar = progressBarRecovery
        'run the right adb commands
        LabelToOutput = txtBoxRecovery

        'downloads the file
        'the file is checked it it exists first in the function
        Await DownloadFileAsync(url, fileName)

        Dim commands(3, 3) As String
        commands = {{"adb", "reboot bootloader", Strings.Rebooting_to_bootloader},
                    {"fastboot", "flash recovery" & "downloads/twrp-3.1.1-0.img",
                     "Flashing recovery: (make sure device is plugged, otherwise it will not output anything)"},
                    {"fastboot", "reboot", "Rebooting device"}
                   }
        Await Task.Run(Sub() RunComands(commands))
    End Sub

#End Region

#Region "Root"

    Private Async Sub btnFlashMagisk_Click(sender As Object, e As EventArgs) Handles btnFlashMagisk.Click
        Try

            'gets the chosenRecovery Value
            Dim chosenRoot As String = GetInfoCombox(cmbRoot, 1)

            Dim url As String = GetInfoXmlInner("/root/magisk/magiskInstaller/version", chosenRoot, False, "", "")

            If url <> "0" Then
                Dim fileName As String = "downloads/magisk-" & chosenRoot & ".zip"
                'change the progress bar and right label
                progressBar = progressBarRoot
                LabelToOutput = txtBoxRoot

                'downloads the file
                'the file is checked it it exists first in the function
                Await DownloadFileAsync(url, fileName)

                'run the right adb commands
                Dim commands(3, 3) As String
                commands = {{"adb", "devices", "Showing all devices"},
                            {"adb", "push " + fileName + " /sdcard/magisk.zip", "Copying " + fileName + " to the sd card"},
                            {"adb", "reboot recovery", "Rebooting device to recovery"}}

                Await Task.Run(Sub() RunComands(commands))
                tabControlPanelMagisk.SelectedIndex = 1
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub checkBoxRoot_CheckedChanged(sender As Object, e As EventArgs) Handles checkBoxRoot.CheckedChanged
        If checkBoxRoot.Checked = True Then
            'it will enable the button
            btnRootContinue.Enabled = True
        Else
            btnRootContinue.Enabled = False
        End If
    End Sub

    Private Sub btnRootContinue_Click(sender As Object, e As EventArgs) Handles btnRootContinue.Click
        tabControlPanelMagisk.SelectedIndex = 2
    End Sub

    Private Async Sub btnFlashMagiskManager_Click(sender As Object, e As EventArgs) Handles btnFlashMagiskManager.Click
        Try
            'gets the chosenRootManager Value
            Dim chosenRootManager As String = GetInfoCombox(cmbRootManager, 2)

            Dim url As String = GetInfoXmlInner("/root/magisk/magiskManager/version", chosenRootManager, False, "", "")
            'Console.WriteLine(url)
            If url <> "0" Then
                Dim fileName As String = "downloads/magiskManager-" & chosenRootManager & ".apk"
                'change the progress bar
                progressBar = progressBarRootManager
                LabelToOutput = txtBoxRoot

                'downloads the file
                'the file is checked it it exists first in the function
                Await DownloadFileAsync(url, fileName)
                'run the right adb commands

                Dim commands(2, 2) As String
                commands = {{"adb", "devices", "Showing all devices"},
                            {"adb", "install " & fileName, Strings.Home_btnFlashMagiskManager_Click_Installing_app_on_the_device_make_sure_device_is_plugged_in__otherwise_it_will_not_output_anything_}
                           }
                Await Task.Run(Sub() RunComands(commands))
                MessageBox.Show(Strings.Home_btnFlashMagiskManager_Click_Open_the_Magisk_Manager_Application)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

#End Region

#Region "Gapps"

    Private Async Sub btnGappsInstall_Click(sender As Object, e As EventArgs) Handles btnGappsInstall.Click
        Try
            'gets the chosenRecovery Value
            Dim chosenGapps As String = GetInfoCombox(cmbGApps, 2)

            Dim url As String = GetInfoXmlInner("/root/Gapps/version", chosenGapps, False, "", "")
            'Console.WriteLine(url)
            If url <> "0" Then
                Dim fileName As String = "downloads/gapps-" & chosenGapps & ".apk"
                'change the progress bar
                progressBar = progressBarGApps
                LabelToOutput = txtBoxGApps

                'downloads the file
                'the file is checked it it exists first in the function
                Await DownloadFileAsync(url, fileName)
                'run the right adb commands

                Dim commands(2, 2) As String
                commands = {{"adb", "devices", "Showing all devices"},
                            {"adb", "install " & fileName,
                             Strings.Home_btnGappsInstall_Click_Installing_app_on_the_device_make_sure_device_is_plugged_in__otherwise_it_will_not_output_anything_}
                           }
                Await Task.Run(Sub() RunComands(commands))

                tabControlPanelGAPPS.SelectedIndex = 1
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

#End Region

#Region "Unbrick"

    Private Sub btnUnbrickGoto_Click(sender As Object, e As EventArgs) Handles btnUnbrickGoto.Click
        If rdBtnUnbFastboot.Checked Then
            TabControlUnbrick.SelectedIndex = 1
        Else
            TabControlUnbrick.SelectedIndex = 2
        End If
    End Sub

    Private Async Sub btnFlashUnbr_Click(sender As Object, e As EventArgs) Handles btnFlashUnbrFastboot.Click

        Try
            'gets the chosenRecovery Value
            Dim chosenFlash As String = GetInfoCombox(cmbBoxUnbrickStock, 1)
            Dim info(4, 2) As String
            info = {{GetInfoXmlInner("/root/phone", chosenFlash, True, "unbrickFastboot/version", "boot"), "downloads/Unbrick/" + My.Settings.phoneVariant + "/boot-" + chosenFlash + ".img"},
                    {GetInfoXmlInner("/root/phone", chosenFlash, True, "unbrickFastboot/version", "cust"), "downloads/Unbrick/" + My.Settings.phoneVariant + "/cust-" + chosenFlash + ".img"},
                    {GetInfoXmlInner("/root/phone", chosenFlash, True, "unbrickFastboot/version", "system"), "downloads/Unbrick/" + My.Settings.phoneVariant + "/system-" + chosenFlash + ".img"},
                    {GetInfoXmlInner("/root/phone", chosenFlash, True, "unbrickFastboot/version", "recovery"), "downloads/Unbrick/" + My.Settings.phoneVariant + "/recovery-" + chosenFlash + ".img"}
                   }

            progressBar = progressBarUnbrickFastboot
            LabelToOutput = txtBoxUnbrick

            For i = 0 To (info.Length / 2 - 1)
                Await DownloadFileAsync(info(i, 0), info(i, 1))
            Next
            Dim result As DialogResult = MessageBox.Show(Strings.Home_btnFlashUnbr_Click_Please_boot_the_phone_into_fastboot_mode,
                                                         Strings.Home_btnFlashUnbr_Click_Reboot_into_fastboot_mode,
                                                         MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                Dim commands(5, 3) As String
                commands = {{"fastboot", "flash boot" & info(0, 1), "Flashing boot"},
                            {"fastboot", "flash cust " & info(1, 1), "Flashing cust"},
                            {"fastboot", "flash system " & info(2, 1), "Flashing system"},
                            {"fastboot", "flash recovery " & info(3, 1), "Flashing recovery"},
                            {"fastboot", "reboot", "Rebooting"}
                           }
                Await Task.Run(Sub() RunComands(commands))
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Async Sub btnFlashUnbrRecovery_Click(sender As Object, e As EventArgs) Handles btnFlashUnbrRecovery.Click
        Try
            'gets the chosenRecovery Value
            Dim chosenFlash As String = GetInfoCombox(cmbBoxUnbrickStock, 1)
            Dim url As String = GetInfoXmlInner("/root/phone", chosenFlash, True, "unbrickStock/version", "")
            Dim filename As String = "downloads/Unbrick/" + My.Settings.phoneVariant + "/" + chosenFlash + ".zip"
            progressBar = progressBarUnbrickStock
            LabelToOutput = txtBoxUnbrick

            Dim directory As String = "downloads/Unbrick/" + My.Settings.phoneVariant + "/" + chosenFlash

            Await DownloadFileAsync(url, filename)
            UpdateTextBox("Extracting the file")
            ZipFile.ExtractToDirectory(filename, directory)
            UpdateTextBox("Extraction complete")

            Dim file As String = directory + "/UPDATE.APP"
            Dim commands(1, 3) As String
            commands = {{"adb", "push " + file + " /sdcard/dload/UPDATE.APP", "Copying the file. The program will output when it is done, and no progress will be shown! Might take a while."},
                {"adb", "shell reboot -p", "Turning phone off"}
                       }
            Await Task.Run(Sub() RunComands(commands))

            MessageBox.Show(Strings.Home_btnFlashUnbrRecovery_Click_Power_on_your_Honor_7_Holding_all_three_buttons__VOL___VOL__and_Power__and_it_will_begin_flashing)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

#End Region

#End Region

#Region "Data Handling and operations"

#Region "Download File"

    Private Async Function DownloadFileAsync(urlAddress As String, filename As String) As Task(Of Integer)
        Using webClient = New WebClient()
            'updates the information
            AddHandler webClient.DownloadFileCompleted, AddressOf Completed
            AddHandler webClient.DownloadProgressChanged, AddressOf ProgressChanged

            Try
                'gets the directory
                Dim stringSelectedSplit As String() = filename.Split(New Char() {"/"c})
                Dim chosenString As String = stringSelectedSplit(stringSelectedSplit.Length - 1)
                Console.WriteLine(chosenString)
                Array.Resize(stringSelectedSplit, stringSelectedSplit.Length - 1)
                Dim directory As String = String.Join("/", stringSelectedSplit)
                'Console.WriteLine(directory)

                ' Start downloading the file if the file does not exist
                If File.Exists(filename) = False Then
                    If (Not System.IO.Directory.Exists(directory)) Then
                        System.IO.Directory.CreateDirectory(directory)
                    End If
                    UpdateTextBox(chosenString + Strings.Home_DownloadFileAsync_File_does_not_exist__Starting_Download_)
                    progressBar.Visible = True
                    Await webClient.DownloadFileTaskAsync(New Uri(urlAddress), filename)
                    progressBar.Visible = False
                Else
                    UpdateTextBox(chosenString + Strings.Home_DownloadFileAsync_File_already_exists)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End Using
        Return 3
    End Function

    Private Sub UpdateProgressBar(a As Integer)
        If Me.InvokeRequired Then
            Dim args() As String = {a}
            Me.Invoke(New Action(Of String)(AddressOf UpdateProgressBar), args)
            Return
        End If
        progressBar.Value = CInt(a)
    End Sub

    ' The event that will fire whenever the progress of the WebClient is changed
    Private Sub ProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs)
        ' Update the progressbar percentage
        UpdateProgressBar(e.ProgressPercentage)
    End Sub

    ' The event that will trigger when the WebClient is completed
    Private Sub Completed(sender As Object, e As AsyncCompletedEventArgs)

        If e.Cancelled = True Then
            'MessageBox.Show(Strings.Home_Completed_Download_has_been_canceled_)
            UpdateTextBox(Strings.Home_Completed_Download_has_been_canceled_)
        Else
            'MessageBox.Show(Strings.Home_Completed_Download_completed_)
            UpdateTextBox(Strings.Home_Completed_Download_completed_)
        End If
    End Sub

#End Region

#Region "ADB Commands"

    'runs the adb commands
    Private Sub RunComands(commands(,) As String)
        For i = 0 To (commands.Length / 3 - 1)
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
                                                           'Console.WriteLine(b)
                                                           UpdateTextBox(b)

                                                       End If
                                                   End Sub
            ' catch errors
            AddHandler process.ErrorDataReceived, Sub(senderc As Object, ec As DataReceivedEventArgs)
                                                      Dim a As String = String.Format("! {0}", ec.Data)
                                                      'Console.WriteLine(a)
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

#Region "Get Info"

    Private Function GetInfoXmlInner(grandParentNodes As String, valueToFind As String, phoneVariantNeeded As Boolean, parentNodes As String, childNodes As String) As String
        'load the document
        xmlDoc.Load(My.Settings.xmlDocumentName)
        'select the right nodes
        Dim nodes As XmlNodeList = xmlDoc.DocumentElement.SelectNodes(grandParentNodes)
        'if the info need is not dependent on the variant (outside the <phone> tags)
        If phoneVariantNeeded = False Then
            For Each node As XmlNode In nodes
                'if it find the right value it returns the link
                Dim id As String = node.Attributes("id").Value
                If valueToFind = id Then
                    Return node.InnerText
                    Exit Function
                End If
            Next
        Else
            'it will find the right variant
            Dim phoneVariant As String = My.Settings.phoneVariant
            For Each node As XmlNode In nodes

                If node.SelectSingleNode("variant").InnerText = phoneVariant Then
                    'select the right node
                    For Each nod As XmlNode In node.SelectNodes(parentNodes)
                        Dim id As String = nod.Attributes("id").Value
                        If valueToFind = id Then
                            'if it needs to have more select multiple links
                            If childNodes = "" Then
                                Return nod.InnerText
                                Exit Function
                            Else
                                Return nod.SelectSingleNode(childNodes).InnerText
                            End If
                        End If
                    Next
                End If
            Next
        End If

        'it will only get here if it hasn't found the link
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

    Private Function GetInfoCombox(comboBox As ComboBoxAdv, spaces As Integer) As String
        Dim stringSelected As String = comboBox.SelectedItem
        Dim stringSelectedSplit As String() = stringSelected.Split(New Char() {" "c})
        Dim chosenString As String = stringSelectedSplit(spaces)
        Return chosenString
    End Function

    Private Sub FindTheFiles()
        Dim fi As String() = Directory.GetFiles("phones/", "*.xml")
        cmbBoxXMLFile.Items.Clear()
        For Each a In fi
            cmbBoxXMLFile.Items.Add(a)
        Next
        If cmbBoxXMLFile.Items.Contains(My.Settings.xmlDocumentName) Then
            cmbBoxXMLFile.SelectedItem = My.Settings.xmlDocumentName
        Else
            cmbBoxXMLFile.SelectedIndex = 0
        End If

    End Sub

    Private Sub cmbBoxXMLFile_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbBoxXMLFile.SelectedValueChanged
        If (Not cmbBoxXMLFile.Items.Count = 0) Then
            My.Settings.xmlDocumentName = cmbBoxXMLFile.SelectedItem.ToString()
            My.Settings.Save()
            ReadXml()
        End If

    End Sub

#End Region

#Region "Reloading data"

    Private Sub ReadXml()
        Try
            cmbModel.Items.Clear()
            xmlDoc.Load(My.Settings.xmlDocumentName)
            'Console.WriteLine(My.Settings.xmlDocumentName)
            Dim nodes As XmlNodeList = xmlDoc.DocumentElement.SelectNodes("/root/phone")
            Dim manufacturer = "", model = "", variantXml = ""

            For Each node As XmlNode In nodes
                manufacturer = node.SelectSingleNode("manufacturer").InnerText
                model = node.SelectSingleNode("model").InnerText
                variantXml = node.SelectSingleNode("variant").InnerText
                If (Not cmbModel.Items.Contains(manufacturer & " " & model & " " & variantXml)) Then
                    cmbModel.Items.Add(manufacturer & " " & model & " " & variantXml)
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(Strings.Home_readXML_File_not_found_or_file_corrupt)
        End Try

        Try

            'chosen model will Not break the program
            'Console.WriteLine(My.Settings.LastChosenModel)
            If cmbModel.Items.Contains(My.Settings.LastChosenModel) Then
                cmbModel.SelectedItem = My.Settings.LastChosenModel
            Else
                cmbModel.SelectedIndex = 0
            End If
            ReloadInfo()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub cmbModel_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbModel.SelectedValueChanged
        If (Not cmbModel.Items.Count = 0) Then
            'save the changes so the next time is open, it loads the last selected model
            My.Settings.LastChosenModel = cmbModel.SelectedItem.ToString()
            'Console.WriteLine(My.Settings.LastChosenModel)
            My.Settings.Save()
            'reload the correct information
            ReloadInfo()
        End If

    End Sub

    Private Sub ReloadInfo()

        'get the selection information
        My.Settings.phoneVariant = GetInfoCombox(cmbModel, 2)
        Try
            'load the correct information into the labels
            xmlDoc.Load(My.Settings.xmlDocumentName)
            'get file details

            lblCreator.Text = String.Format("{0} {1} {2}",
                                        xmlDoc.SelectSingleNode("/root/creator").InnerText,
                                        xmlDoc.SelectSingleNode("/root/date").InnerText,
                                        xmlDoc.SelectSingleNode("/root/version").InnerText)

            'loops through all the phones to find the right one and gets the information fromm them
            Dim nodes As XmlNodeList = xmlDoc.DocumentElement.SelectNodes("/root/phone")
            For Each node As XmlNode In nodes
                If My.Settings.phoneVariant = node.SelectSingleNode("variant").InnerText Then

                    'update Labels in the homepage
                    lblManufacturer.Text = cmbModel.SelectedItem.ToString
                    lblProcessor.Text = node.SelectSingleNode("processor").InnerText
                    lblRAM.Text = node.SelectSingleNode("RAM").InnerText
                    lblStorage.Text = node.SelectSingleNode("storage").InnerText

                    'update Picture
                    Dim strPicture As String = "phones/pictures/" & node.SelectSingleNode("picture").InnerText
                    picPhone.BackgroundImage = Image.FromFile(strPicture)

                    'get recovery info
                    cmbRecovery.Items.Clear()
                    For Each nod As XmlNode In node.SelectNodes("recovery/twrp/version")
                        Dim recoveryTwrp As String = nod.Attributes("id").Value
                        If cmbRecovery.Items.Contains("TWRP " & recoveryTwrp) = False Then
                            cmbRecovery.Items.Add("TWRP " & recoveryTwrp)
                        End If
                    Next
                    Try
                        cmbRecovery.SelectedIndex = 0
                    Catch ex As Exception

                    End Try

                    cmbBoxUnbrickFastboot.Items.Clear()
                    For Each noda As XmlNode In node.SelectNodes("unbrickFastboot/version")
                        'Console.WriteLine(noda.ToString)
                        Dim emuiVersion As String = noda.Attributes("id").Value
                        If cmbBoxUnbrickFastboot.Items.Contains("EMUI " & emuiVersion) = False Then
                            cmbBoxUnbrickFastboot.Items.Add("EMUI " & emuiVersion)
                        End If
                    Next
                    Try
                        cmbBoxUnbrickFastboot.SelectedIndex = 0
                    Catch ex As Exception
                    End Try

                    cmbBoxUnbrickStock.Items.Clear()
                    For Each noda As XmlNode In node.SelectNodes("unbrickStock/version")
                        'Console.WriteLine(noda.ToString)
                        Dim emuiVersion As String = noda.Attributes("id").Value
                        If cmbBoxUnbrickStock.Items.Contains("EMUI " & emuiVersion) = False Then
                            cmbBoxUnbrickStock.Items.Add("EMUI " & emuiVersion)
                        End If
                    Next
                    Try
                        cmbBoxUnbrickStock.SelectedIndex = 0
                    Catch ex As Exception
                    End Try

                End If
            Next

            'populate dropdown stuff
            AddToComboBoxesXml("/root/Gapps/version", "Gapps Application ", cmbGApps)
            AddToComboBoxesXml("/root/magisk/magiskInstaller/version", "Magisk ", cmbRoot)
            AddToComboBoxesXml("/root/magisk/magiskManager/version", "Magisk Manager ", cmbRootManager)


            checkBoxesReload()
        Catch ex As Exception
            MessageBox.Show(Strings.Home_ReloadInfo_File_does_not_contains_invalid_information)
        End Try


    End Sub

#End Region

#Region "Update"

    Private Async Sub CheckXMLUpdates()

        'IMPORTANT
        'the download file information is not used as it needs a progress bar
        'and textbox to update the status so we are better of using it standalone
        '
        Try
            xmlDoc.Load(My.Settings.xmlDocumentName)
            'get file details
            Dim currentVersion As String = xmlDoc.SelectSingleNode("/root/version").InnerText
            Dim updateURL As String = xmlDoc.SelectSingleNode("/root/updateURL").InnerText
            Dim filename = "downloads/updateXML.txt"

            'downloads a .txt file to check if there is a new version
            Using webClient = New WebClient()
                Await webClient.DownloadFileTaskAsync(New Uri(updateURL), filename)
            End Using

            'now we try to read the file
            Using reader As StreamReader = New StreamReader(filename)
                ' Read one line from file - the first value will be the new version numbers
                Dim latestVersion As String = reader.ReadLine

                'if the new version number is bigger than the current version it will prompt the user
                If Decimal.Parse(latestVersion) > Decimal.Parse(currentVersion) Then
                    Console.WriteLine(Strings.Home_CheckXMLUpdates_Update_Found)

                    'asks the user if they want to download a new version
                    Dim result As DialogResult = MessageBox.Show(Strings.Home_CheckXMLUpdates_New_version_of_the_XML__data__file_found__Download_now_,
                                                             Strings.Home_CheckXMLUpdates_Update,
                                                             MessageBoxButtons.YesNo,
                                                             MessageBoxIcon.Question)
                    'if they say yes
                    If result = DialogResult.Yes Then
                        'it will create a new webclinet
                        Using webClient = New WebClient()
                            'gets the url from the next line
                            Dim UpdateXMLFile As String = reader.ReadLine
                            Console.WriteLine(UpdateXMLFile)
                            'the filename for the update
                            Dim xmlFileName As String = My.Settings.xmlDocumentName
                            'downloads and replaces the current file
                            Await webClient.DownloadFileTaskAsync(New Uri(UpdateXMLFile), xmlFileName)
                            'reads the new file information and reloads the data
                            ReadXml()
                            MessageBox.Show(Strings.Home_CheckXMLUpdates_Update_Complete)

                        End Using
                    End If
                ElseIf Decimal.Parse(latestVersion) = Decimal.Parse(currentVersion) Then
                    MessageBox.Show(Strings.Home_CheckXMLUpdates_You_have_the_latest_version)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub checkBoxUpdatesStart_CheckedChanged(sender As Object, e As EventArgs) Handles checkBoxUpdatesStart.CheckedChanged
        'if the box is checked for updates
        If checkBoxUpdatesStart.Checked = True Then
            'it will change the settings
            My.Settings.checkForUpdates = True
        Else
            My.Settings.checkForUpdates = False

        End If
        'save the settings
        My.Settings.Save()

    End Sub

    Private Sub btnXMLFileUpdates_Click(sender As Object, e As EventArgs) Handles btnXMLFileUpdates.Click
        'checks for updates
        CheckXMLUpdates()
    End Sub

    Private Sub checkBoxShowDisclaimer_CheckedChanged(sender As Object, e As EventArgs) Handles checkBoxShowDisclaimer.CheckedChanged
        'if the box is checked to show the disclaimer
        If checkBoxShowDisclaimer.Checked = True Then
            'it will change the settings
            My.Settings.showDisclaimer = True
        Else
            My.Settings.showDisclaimer = False

        End If
        'save the settings
        My.Settings.Save()
    End Sub

    Private Sub checkBoxesReload()
        If My.Settings.showDisclaimer Then
            checkBoxShowDisclaimer.Checked = True
        Else
            checkBoxShowDisclaimer.Checked = False
        End If
        If My.Settings.checkForUpdates Then
            checkBoxUpdatesStart.Checked = True
        Else
            checkBoxUpdatesStart.Checked = False
        End If
    End Sub

    Private Sub cmbBoxLanguage_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbBoxLanguage.SelectedValueChanged
        Dim language As String = cmbBoxLanguage.SelectedItem.ToString()
        Select Case language
            Case "English"
                My.Settings.selectedLanguage = "en"
            Case "French"
                My.Settings.selectedLanguage = "fr"
            Case "German"
                My.Settings.selectedLanguage = "de"
            Case "Russian"
                My.Settings.selectedLanguage = "ru"
            Case "Portuguese"
                My.Settings.selectedLanguage = "pt"
            Case Else
                My.Settings.selectedLanguage = "en"
        End Select

        My.Settings.Save()

        Application.Restart()

    End Sub

    Private Sub cmbBoxLanguage_Click(sender As Object, e As EventArgs) Handles cmbBoxLanguage.Click

    End Sub

#End Region

#End Region

End Class