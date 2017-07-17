Imports Syncfusion.Windows.Forms
Imports System.Xml


Public Class Home
    Inherits MetroForm

    Private Sub Home_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'read xml file and load in to the dropbox
        readXML()

    End Sub

    Sub readXML()

        Using reader As XmlReader = XmlReader.Create("HuaweiHonor.xml")
            Dim stringToAdd As String = ""
            While reader.Read()
                If reader.Name = "phone" Then
                    If stringToAdd <> "" Then
                        Me.cmbModel.Items.AddRange(New Object() {stringToAdd})
                    End If
                    stringToAdd = ""

                Else
                    If reader.Name <> "Huawei" Then
                        stringToAdd += reader.Value.Trim()
                        Console.WriteLine(reader.Value.Trim)

                    End If
                End If
            End While

        End Using

    End Sub

    Private Sub TabControlAdv1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabControlPanel.SelectedIndexChanged

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles picPhone.Click

    End Sub

    Private Sub pnlPhone_Click(sender As Object, e As EventArgs) Handles pnlPhone.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles lblModel.Click

    End Sub

    Private Sub lblManufacturer_Click(sender As Object, e As EventArgs) Handles lblManufacturer.Click

    End Sub

    Private Sub lblVariant_Click(sender As Object, e As EventArgs) Handles lblVariant.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label1_Click_1(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub ComboDropDown1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub ComboBoxAdv2_Click(sender As Object, e As EventArgs) Handles cmbModel.Click

    End Sub
End Class
