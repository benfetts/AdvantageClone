Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports System.Drawing

Public Class arptJobVersion
    Public dtData As DataTable
    Public description As String
    Public version As String
    Public client As String
    Public division As String
    Public product As String
    Public job As String
    Public jobcomp As String
    Public imgPath As String
    Public ReportTitle As String
    Public Reporter As String
    Public LogoPath As String
    Public LogoPlacement As Integer
    Public LogoID As String
    Public dtAgency As DataTable
    Public omitEmptyFields As Boolean
    Public CultureCode As String = "en-US"
    Public exportformat As Integer = 1
    Public _LocationLogo As AdvantageFramework.Database.Entities.LocationLogo = Nothing

    Private Sub arptJobVersion_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart

        ReportFunctions.SetCulture(Me, CultureCode)

        If Me.omitEmptyFields = True Then

            Dim j As Integer
            Dim count As Integer

            For j = 0 To Me.dtData.Rows.Count - 1

                If j <= Me.dtData.Rows.Count - 1 Then

                    If (Me.dtData.Rows(j).Item(1).ToString = "" Or IsDBNull(Me.dtData.Rows(j).Item(1))) AndAlso Me.dtData.Rows(j).Item(3).ToString <> "True" Then

                        Me.dtData.Rows.Remove(Me.dtData.Rows(j))
                        j -= 1

                    End If

                End If

            Next

        End If

        Me.DataSource = dtData

    End Sub

    Private Sub PageHeader1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageHeader1.Format
        Me.txtDesc.Text = description
        Me.txtVersion.Text = version
        Me.txtClient.Text = client
        Me.txtDivision.Text = division
        Me.txtProduct.Text = product
        Me.txtJob.Text = job
        Me.txtComponent.Text = jobcomp

        If job = "" And jobcomp = "" Then
            Me.txtJobLabel.Text = ""
            Me.txtCompLabel.Text = ""
        End If

        Me.lblTemp.Text = "Template: " & Me.lblJvTmpltDesc.Text

        If Me.LogoID = "None" Then
            'Me.Picture1.Visible = False
            'Me.txtAgencyName.Visible = False
            'Me.txtAgencyInfo.Visible = False
            PageHeader1.Visible = False
        Else

            If _LocationLogo IsNot Nothing AndAlso _LocationLogo.Image IsNot Nothing Then

                Using MemoryStream = New System.IO.MemoryStream(_LocationLogo.Image)

                    Using img As Image = System.Drawing.Image.FromStream(MemoryStream)

                        Dim bm As Bitmap

                        bm = New Bitmap(img)

                        Me.Picture1.Image = bm

                    End Using

                End Using

            Else

                If Me.LogoPath <> "" Then
                    Dim f As New IO.FileInfo(Me.LogoPath)
                    If f.Exists Then
                        Me.Picture1.Image = Drawing.Image.FromFile(Me.LogoPath)
                    Else
                        Me.Picture1.Image = Drawing.Image.FromFile(imgPath)
                    End If
                Else
                    Me.Picture1.Image = Drawing.Image.FromFile(imgPath)
                End If

            End If

            Dim str As String
            Dim str3 As String
            If Me.dtAgency.Rows.Count > 0 And Me.LogoID <> "None" Then
                If Me.dtAgency.Rows(0)("PRT_HEADER").ToString = "1" Then
                    str3 = ""

                    If Me.dtAgency.Rows(0)("PRT_NAME").ToString = "1" Then
                        If Me.dtAgency.Rows(0)("NAME").ToString <> "" Then
                            Me.txtAgencyName.Text = Me.dtAgency.Rows(0)("NAME")
                        Else
                            Me.txtAgencyName.Text = ""
                        End If
                    Else
                        Me.txtAgencyName.Text = ""
                    End If

                    If Me.dtAgency.Rows(0)("PRT_ADDR1").ToString = "1" And Me.dtAgency.Rows(0)("ADDRESS1").ToString <> "" Then
                        str3 = Me.dtAgency.Rows(0)("ADDRESS1").ToString
                    End If
                    If str3 > "" Then
                        str3 = str3 & " • "
                    End If
                    If Me.dtAgency.Rows(0)("PRT_ADDR2").ToString = "1" And Me.dtAgency.Rows(0)("ADDRESS2").ToString <> "" Then
                        str3 = str3 & Me.dtAgency.Rows(0)("ADDRESS2").ToString
                    End If
                    If Me.dtAgency.Rows(0)("PRT_CITY").ToString = "1" And Me.dtAgency.Rows(0)("CITY").ToString <> "" Then
                        If str3 > "" Then
                            str3 = str3 & " • "
                        End If
                        str3 = str3 & Me.dtAgency.Rows(0)("CITY").ToString & ", "
                    End If
                    If Me.dtAgency.Rows(0)("PRT_STATE").ToString = "1" And Me.dtAgency.Rows(0)("STATE").ToString <> "" Then
                        str3 = str3 & Me.dtAgency.Rows(0)("STATE").ToString & "  "
                    End If
                    If Me.dtAgency.Rows(0)("PRT_ZIP").ToString = "1" And Me.dtAgency.Rows(0)("ZIP").ToString <> "" Then
                        str3 = str3 & Me.dtAgency.Rows(0)("ZIP").ToString
                    End If
                    If Me.dtAgency.Rows(0)("PRT_PHONE").ToString = "1" And Me.dtAgency.Rows(0)("PHONE").ToString <> "" Then
                        If str3 > "" Then
                            str3 = str3 & " • "
                        End If
                        str3 = str3 & Me.dtAgency.Rows(0)("PHONE").ToString
                    End If
                    If Me.dtAgency.Rows(0)("PRT_FAX").ToString = "1" And Me.dtAgency.Rows(0)("FAX").ToString <> "" Then
                        If str3 > "" Then
                            str3 = str3 & " • "
                        End If
                        str3 = str3 & Me.dtAgency.Rows(0)("FAX").ToString & " Fax "
                    End If
                    If Me.dtAgency.Rows(0)("PRT_EMAIL").ToString = "1" And Me.dtAgency.Rows(0)("EMAIL").ToString <> "" Then
                        If str3 > "" Then
                            str3 = str3 & " • "
                        End If
                        str3 = str3 & Me.dtAgency.Rows(0)("EMAIL").ToString
                    End If
                    Me.txtAgencyInfo.Text = str3
                End If
            Else
                Me.txtAgencyName.Text = ""
                Me.txtAgencyInfo.Text = ""
            End If
        End If
    End Sub

    Private Sub PageFooter1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageFooter1.Format
        Me.lblBy.Text = "by " & Reporter
    End Sub

    Private Sub GroupHeader1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader1.Format
        Try
            If ReportTitle <> "" Then
                Me.lblReportTitle.Text = ReportTitle
            Else
                Me.lblReportTitle.Text = "Job Version Report"
            End If

            Select Case LogoPlacement
                Case 1
                    Me.lblReportTitle.Alignment = TextAlignment.Left
                Case 2
                    Me.lblReportTitle.Alignment = TextAlignment.Center
                Case 3
                    Me.lblReportTitle.Alignment = TextAlignment.Right
                Case Else
                    Me.lblReportTitle.Alignment = TextAlignment.Left
            End Select
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Detail1_Format(sender As Object, e As EventArgs) Handles Detail1.Format

        Me.RichTextBoxValue.Html = ReportFunctions.WrapRtfInFontTag(TextBoxValue.Text)

        If LabelIsSection.Text = "True" Then

            LineSection.Visible = True
            LabelSemiColon.Visible = False

        Else

            LineSection.Visible = False
            LabelSemiColon.Visible = True

        End If

    End Sub

End Class
