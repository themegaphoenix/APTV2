Imports Syncfusion.Windows.Forms
Imports System.Xml
Imports System.IO

Public Class Home
    Inherits MetroForm

    'Public variables
    Dim strManufacturer As String = ""

    Dim strModel As String = ""
    Dim strVariant As String = ""
    Dim LabelToOutput As TextBox

    'document needs to be open during the whole program, otherwise it would be opening and closing
    Dim xmlDoc As New XmlDocument()

    Private Sub Home_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'read xml file and load in to the dropbox
        readXML()

    End Sub

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
            'choses the first item, and then selects the last item if there is
            cmbModel.SelectedIndex = 0
            'the exception that will throw when it does not find the last
            'chosen model will Not break the program
            cmbModel.SelectedItem = My.Settings.LastChosenModel
            reloadInfo()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmbModel_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbModel.SelectedValueChanged
        'save the changes so the next time is open, it loads the last selected model
        My.Settings.LastChosenModel = cmbModel.SelectedItem.ToString()
        'Console.WriteLine(cmbModel.SelectedItem.ToString())
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
                lblManufacturer.Text = node.SelectSingleNode("manufacturer").InnerText
                lblModel.Text = node.SelectSingleNode("model").InnerText
                lblVariant.Text = node.SelectSingleNode("variant").InnerText
                'Console.WriteLine(strPicture)
                Try
                    Dim strPicture As String = "phones/pictures/" & node.SelectSingleNode("picture").InnerText
                    picPhone.BackgroundImage = Image.FromFile(strPicture)
                Catch ex As Exception
                End Try
            End If
        Next

    End Sub

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
            Dim executable As String() = {"fastboot"}
            Dim arguments As String() = {"oem unlock " + unlockKey}
            Dim description As String() = {"Unlocking bootloader: (make sure device is plugged, otherwise it will not output anything)"}
            'Dim executable As String() = {"adb"}
            'Dim arguments As String() = {"help"}
            'Console.WriteLine(arguments(0))
            LabelToOutput = txtBoxBootloader
            Task.Run(Sub() runComands(executable, arguments, description))
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
            Dim executable As String() = {"fastboot"}
            Dim arguments As String() = {"oem relock " + unlockKey}
            Dim description As String() = {"Unlocking bootloader: (make sure device is plugged, otherwise it will not output anything)"}
            'Dim executable As String() = {"adb"}
            'Dim arguments As String() = {"help"}
            'Console.WriteLine(arguments(0))
            LabelToOutput = txtBoxBootloader
            Task.Run(Sub() runComands(executable, arguments, description))
        End If

    End Sub

    'runs the adb commands and outputs in the chosen label
    Private Sub runComands(ByVal executable As String(), ByVal arguments As String(), ByVal description As String())
        'Try
        For i As Integer = 0 To (arguments.Length - 1)
            Dim process = New Process()
            process.StartInfo = createStartInfo(executable(i), arguments(i))
            process.EnableRaisingEvents = True
            AddHandler process.Exited, Sub(ByVal sendera As Object, ByVal ea As System.EventArgs)
                                           'Console.WriteLine(process.ExitTime)
                                           'Console.WriteLine(". Processing done.")
                                           ' output line n when output is ready (= all lines are present)
                                           'Console.WriteLine(lines(1))
                                           UpdateTextBox(Environment.NewLine & process.ExitTime & Environment.NewLine & ".ProcessingDone")
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
            UpdateTextBox(description(i))
            Dim result = process.Start()
            ' and wait for output
            process.BeginOutputReadLine()
            ' and wait for errors :-)
            process.BeginErrorReadLine()
            process.WaitForExit()
            UpdateTextBox(Environment.NewLine & process.ExitTime & Environment.NewLine & ".ProcessingDone")

        Next

        'Catch ex As Exception

        'End Try
    End Sub

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

    Private Sub UpdateTextBox(ByVal a As String)
        If Me.InvokeRequired Then
            Dim args() As String = {a}
            Me.Invoke(New Action(Of String)(AddressOf UpdateTextBox), args)
            Return
        End If
        LabelToOutput.AppendText(a & Environment.NewLine)

    End Sub
End Class