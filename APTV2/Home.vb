Imports Syncfusion.Windows.Forms
Imports System.Xml

Public Class Home
    Inherits MetroForm

    'Public variables
    Dim strManufacturer As String = ""

    Dim strModel As String = ""
    Dim strVariant As String = ""

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

End Class