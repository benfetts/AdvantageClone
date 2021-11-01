Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports System.Drawing

Public Class arptJobSpecs 
    Public dtData As DataTable
    Public dtQuantity As DataTable
    Public dtCategory As DataTable
    Public dtHeaderData As DataTable
    Public dtText As DataTable
    Public dtVendor As DataTable
    Public dtMediaSpecs As DataTable
    Public description As String
    Public reason As String
    Public version As String
    Public revision As String
    Public client As String
    Public division As String
    Public product As String
    Public job As String
    Public jobcomp As String
    Public Reporter As String
    Public Approved As Boolean
    Public imgPath As String
    Public title As String
    Public vendorTab As Integer
    Private jobSpecsSubReportVendor1 As arptJobSpecsVendor = Nothing
    Private jobSpecsSubReportVendor2 As arptJobSpecsVendorOut = Nothing
    Private jobSpecsSubReportMS As arptMediaSpecs = Nothing
    Public includeVS As Boolean
    Public includeMS As Boolean
    Public page As String
    Dim i As Integer = 0
    Public LogoPath As String
    Public LogoPlacement As Integer
    Public LogoID As String
    Public dtAgency As DataTable
    Public omitEmptyFields As Boolean
    Public CultureCode As String = "en-US"
    Public _LocationLogo As AdvantageFramework.Database.Entities.LocationLogo = Nothing

    Private Sub arptJobSpecs_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        ReportFunctions.SetCulture(Me, CultureCode)
        'Dim i As Integer
        'For i = 0 To dtMediaSpecs.Tables.Count - 1
        '    If dtMediaSpecs.Tables(i).Rows.Count <> 0 Then
        '        Me.constructReport(dtMediaSpecs.Tables(0))
        '    End If
        'Next
        If Me.omitEmptyFields = True Then
            Dim j As Integer
            Dim count As Integer
            For j = 0 To Me.dtData.Rows.Count - 1
                If j <= Me.dtData.Rows.Count - 1 Then
                    If Me.dtData.Rows(j).Item(5).ToString = "" Then
                        Me.dtData.Rows.Remove(Me.dtData.Rows(j))
                        j -= 1
                    End If
                End If
            Next
        End If
        Me.DataSource = dtData

        If Me.Approved = True Then
            Me.lblApproved.Visible = True
        Else
            Me.lblApproved.Visible = False
        End If
        If vendorTab = 1 Then
            Me.GroupFooter3.Visible = True
            Me.GroupFooter2.Visible = False
        End If
        If vendorTab = 2 Then
            Me.GroupFooter3.Visible = False
            Me.GroupFooter2.Visible = True
        End If
        If page = "jobjacket" Then
            If includeVS = False Then
                Me.GroupFooter3.Visible = False
                Me.GroupFooter2.Visible = False
            End If
            If includeMS = False Then
                Me.GroupFooter1.Visible = False
            End If
        End If

    End Sub

    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format
        Me.txtDesc.Text = description
        Me.txtVersion.Text = version
        Me.txtRevision.Text = revision
        Me.txtClient.Text = client
        Me.txtDivision.Text = division
        Me.txtProduct.Text = product
        Me.txtJob.Text = job
        Me.txtComponent.Text = jobcomp
        Me.txtReason.Text = reason

        If Me.LogoID = "None" Then
            'Me.Picture1.Visible = False
            'Me.txtAgencyName.Visible = False
            'Me.txtAgencyInfo.Visible = False
            Me.PageHeader1.Visible = False
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

            Dim str3 As String = ""
            Dim strCSZ As String = ""

            If Me.dtAgency.Rows.Count > 0 And Me.LogoID <> "None" Then
                If Me.dtAgency.Rows(0)("PRT_HEADER").ToString = "1" Then
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

                    If Me.dtAgency.Rows(0)("PRT_ADDR2").ToString = "1" And Me.dtAgency.Rows(0)("ADDRESS2").ToString <> "" Then
                        If str3 > "" Then
                            str3 = str3 & " • "
                        End If
                        str3 = str3 & Me.dtAgency.Rows(0)("ADDRESS2").ToString
                    End If

                    If Me.dtAgency.Rows(0)("PRT_CITY").ToString = "1" And Me.dtAgency.Rows(0)("CITY").ToString <> "" Then
                        strCSZ = Me.dtAgency.Rows(0)("CITY").ToString & ","
                    End If
                    If Me.dtAgency.Rows(0)("PRT_STATE").ToString = "1" And Me.dtAgency.Rows(0)("STATE").ToString <> "" Then
                        If strCSZ <> "" Then
                            strCSZ = strCSZ & " "
                        End If
                        strCSZ = strCSZ & dtAgency.Rows(0)("STATE").ToString
                    End If
                    If Me.dtAgency.Rows(0)("PRT_ZIP").ToString = "1" And Me.dtAgency.Rows(0)("ZIP").ToString <> "" Then
                        If strCSZ <> "" Then
                            strCSZ = strCSZ & " "
                        End If
                        strCSZ = strCSZ & dtAgency.Rows(0)("ZIP").ToString
                    End If

                    If strCSZ <> "" Then
                        If str3 > "" Then
                            str3 = str3 & " • "
                        End If
                        str3 = str3 & strCSZ
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
                Else
                    Me.txtAgencyName.Text = ""
                    Me.txtAgencyInfo.Text = ""
                End If
            Else
                Me.txtAgencyName.Text = ""
                Me.txtAgencyInfo.Text = ""
            End If
        End If
    End Sub

    Private Sub GroupHeader5_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader5.Format
        Try
            If title <> "" Then
                Me.lblReportTitle.Text = title
            Else
                Me.lblReportTitle.Text = "Specification Sheet"
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

    Private Sub GroupHeader1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader1.Format
        Dim i As Integer
        If dtQuantity.Rows.Count > 0 Then
            For i = 0 To dtQuantity.Rows.Count - 1
                Me.txtQuantity.Text = Me.txtQuantity.Text & String.Format("{0:0,0}", CInt(dtQuantity.Rows(i)(0).ToString)) & " / "
            Next
            Me.GroupHeader1.Visible = True
            If Me.txtQuantity.Text.Trim.EndsWith("/") Then
                Me.txtQuantity.Text = Me.txtQuantity.Text.Trim.Substring(0, Me.txtQuantity.Text.Trim.Length - 1)
            End If
        Else
            Me.GroupHeader1.Visible = False
        End If
        
    End Sub

    Private Sub GroupHeader2_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader2.Format
        Try
            Dim str As String
            Dim cat As DataView

            If Me.txtCatID.Text Is Nothing Then
                str = ""
            Else
                str = Me.txtCatID.Text
            End If

            'cat = New DataView(Me.dtCategory)
            'cat.RowFilter = "(CATEGORY_ID = " & str & ")"
            'Me.txtCategory.Text = cat.Item(0)(0).ToString

        Catch ex As Exception
            'Me.lblApproved.Text = ex.Message
        End Try
    End Sub

    Private Sub Detail1_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail1.BeforePrint
        Try
            'Me.txtData.Text.Replace("#apostrophe#", "'").Replace("#semicolon#", ";")
            Me.txtData.Text = Me.txtData.Text.ToString.Replace("#apostrophe#", "'").Replace("#semicolon#", ";")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Detail1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail1.Format
        Try

            Me.txtShortDesc.Text = Me.txtShortDesc.Text & ": "
            If Me.txtFieldName.Text = "TEXT_1" Then
                Me.txtData.Text = dtText.Rows(0)("TEXT_1").ToString.Replace("#semicolon#", ";")
            End If
            If Me.txtFieldName.Text = "TEXT_2" Then
                Me.txtData.Text = dtText.Rows(0)("TEXT_2").ToString.Replace("#semicolon#", ";")
            End If
            If Me.txtFieldName.Text = "TEXT_3" Then
                Me.txtData.Text = dtText.Rows(0)("TEXT_3").ToString.Replace("#semicolon#", ";")
            End If
            If Me.txtFieldName.Text = "TEXT_4" Then
                Me.txtData.Text = dtText.Rows(0)("TEXT_4").ToString.Replace("#semicolon#", ";")
            End If
            If Me.txtFieldName.Text = "TEXT_5" Then
                Me.txtData.Text = dtText.Rows(0)("TEXT_5").ToString.Replace("#semicolon#", ";")
            End If
            If Me.txtFieldName.Text = "TEXT_6" Then
                Me.txtData.Text = dtText.Rows(0)("TEXT_6").ToString.Replace("#semicolon#", ";")
            End If
            If Me.txtFieldName.Text = "TEXT_7" Then
                Me.txtData.Text = dtText.Rows(0)("TEXT_7").ToString.Replace("#semicolon#", ";")
            End If
            If Me.txtFieldName.Text = "TEXT_8" Then
                Me.txtData.Text = dtText.Rows(0)("TEXT_8").ToString.Replace("#semicolon#", ";")
            End If
            If Me.txtFieldName.Text = "TEXT_9" Then
                Me.txtData.Text = dtText.Rows(0)("TEXT_9").ToString.Replace("#semicolon#", ";")
            End If
            If Me.txtFieldName.Text = "TEXT_10" Then
                Me.txtData.Text = dtText.Rows(0)("TEXT_10").ToString.Replace("#semicolon#", ";")
            End If
            If Me.txtFieldName.Text = "TEXT_11" Then
                Me.txtData.Text = dtText.Rows(0)("TEXT_11").ToString.Replace("#semicolon#", ";")
            End If
            If Me.txtFieldName.Text = "TEXT_12" Then
                Me.txtData.Text = dtText.Rows(0)("TEXT_12").ToString.Replace("#semicolon#", ";")
            End If
            If Me.txtFieldName.Text = "TEXT_13" Then
                Me.txtData.Text = dtText.Rows(0)("TEXT_13").ToString.Replace("#semicolon#", ";")
            End If
            If Me.txtFieldName.Text = "TEXT_14" Then
                Me.txtData.Text = dtText.Rows(0)("TEXT_14").ToString.Replace("#semicolon#", ";")
            End If
            If Me.txtFieldName.Text = "TEXT_15" Then
                Me.txtData.Text = dtText.Rows(0)("TEXT_15").ToString.Replace("#semicolon#", ";")
            End If
            If Me.txtFieldName.Text = "TEXT_16" Then
                Me.txtData.Text = dtText.Rows(0)("TEXT_16").ToString.Replace("#semicolon#", ";")
            End If
            If Me.txtFieldName.Text = "TEXT_17" Then
                Me.txtData.Text = dtText.Rows(0)("TEXT_17").ToString.Replace("#semicolon#", ";")
            End If
            If Me.txtFieldName.Text = "TEXT_18" Then
                Me.txtData.Text = dtText.Rows(0)("TEXT_18").ToString.Replace("#semicolon#", ";")
            End If
            If Me.txtFieldName.Text = "TEXT_19" Then
                Me.txtData.Text = dtText.Rows(0)("TEXT_19").ToString.Replace("#semicolon#", ";")
            End If
            If Me.txtFieldName.Text = "TEXT_20" Then
                Me.txtData.Text = dtText.Rows(0)("TEXT_20").ToString.Replace("#semicolon#", ";")
            End If

            Dim sep As String
            sep = Me.txtSeparator.Text
            If Me.txtSeparator.Text = "1" Then
                Me.LineSep.Visible = True
            Else
                Me.LineSep.Visible = False
            End If

        Catch ex As Exception
            'Me.lblApproved.Text = ex.Message
        End Try
    End Sub
    
    Private Sub PageFooter1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageFooter1.Format
        Me.lblBy.Text = "by " & Reporter
    End Sub

    Private Sub GroupFooter2_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter2.Format
        Try
            If Me.jobSpecsSubReportVendor2 Is Nothing Then
                Me.jobSpecsSubReportVendor2 = New arptJobSpecsVendorOut
                Me.jobSpecsSubReportVendor2.dtVendor = Me.dtVendor
                Me.jobSpecsSubReportVendor2.CultureCode = Me.CultureCode
                Me.srVendor2.Report = Me.jobSpecsSubReportVendor2
                Me.srVendor2.Report.DataSource = Me.dtVendor
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GroupFooter1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter1.Format
        Try
            If Me.jobSpecsSubReportMS Is Nothing Then
                If dtMediaSpecs.Rows.Count > 0 Then
                    Me.jobSpecsSubReportMS = New arptMediaSpecs
                    Me.jobSpecsSubReportMS.dtMediaSpecs = Me.dtMediaSpecs
                    Me.srMediaSpecs.Report = Me.jobSpecsSubReportMS
                    Me.srMediaSpecs.Report.DataSource = Me.dtMediaSpecs
                Else
                    Me.srMediaSpecs.Visible = False
                    Me.TextBox4.Visible = False
                End If
                
            End If
        Catch ex As Exception
            Dim str As String = ""
        End Try
    End Sub

    Private Sub GroupFooter3_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter3.Format
        Try
            If Me.jobSpecsSubReportVendor1 Is Nothing Then
                Me.jobSpecsSubReportVendor1 = New arptJobSpecsVendor
                Me.jobSpecsSubReportVendor1.dtVendor = Me.dtVendor
                Me.jobSpecsSubReportVendor1.CultureCode = Me.CultureCode
                Me.srVendor1.Report = Me.jobSpecsSubReportVendor1
                Me.srVendor1.Report.DataSource = Me.dtVendor
            End If
        Catch ex As Exception
            Dim str As String = ""
        End Try
    End Sub

    Private Sub constructReport(ByVal table As DataTable)
        Try
            Dim sr As arptMediaSpecs
            Dim subreport As New SubReport
            sr = New arptMediaSpecs
            sr.dtMediaSpecs = table
            subreport.Report = sr
            subreport.Report.DataSource = table
            subreport.Location = New System.Drawing.Point(0.06, 0.06)
            Me.Sections("GroupFooter1").Controls.Add(subreport)
        Catch ex As Exception
            Dim str As String = ""
        End Try

    End Sub

    
End Class
