Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports System.Drawing

Public Class arptJobSpecAllVersions
    Public dtData As DataTable
    Public dtDataApproved As DataTable
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


    Private Sub arptJobSpecAllVersions_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        ReportFunctions.SetCulture(Me, CultureCode)

        If Me.omitEmptyFields = True Then
            Dim j As Integer
            Dim count As Integer
            For j = 0 To Me.dtData.Rows.Count - 1
                If j <= Me.dtData.Rows.Count - 1 Then
                    If Me.dtData.Rows(j).Item(6).ToString = "" Or IsDBNull(Me.dtData.Rows(j).Item(6)) Then
                        Me.dtData.Rows.Remove(Me.dtData.Rows(j))
                        j -= 1
                    End If
                End If
            Next
        End If

        If Approved = True Then
            Dim dv As DataView = New DataView(dtData)

            dv.RowFilter = "APPROVED = 'Approved'"
            dtDataApproved = dv.ToTable()
            Me.DataSource = dtDataApproved
        Else
            Me.DataSource = dtData
        End If
        
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

        If vendorTab = 1 Then
            Me.GroupFooter4.Visible = True
            Me.GroupFooter3.Visible = False
        End If
        If vendorTab = 2 Then
            Me.GroupFooter4.Visible = False
            Me.GroupFooter3.Visible = True
        End If
        If page = "jobjacket" Then
            If includeVS = False Then
                Me.GroupFooter4.Visible = False
                Me.GroupFooter3.Visible = False
            End If
            If includeMS = False Then
                Me.GroupFooter2.Visible = False
            End If
        End If
    End Sub

    Private Sub PageHeader1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageHeader1.Format
        Me.txtClient.Text = client
        Me.txtDivision.Text = division
        Me.txtProduct.Text = product
        Me.txtJob.Text = job
        Me.txtComponent.Text = jobcomp


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

            Dim str3 As String
            If Me.dtAgency.Rows.Count > 0 And Me.LogoID <> "None" And Me.dtAgency.Rows(0)("PRT_HEADER").ToString = "1" Then

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
                    str3 = Me.dtAgency.Rows(0)("ADDRESS1").ToString & " • "
                End If
                If Me.dtAgency.Rows(0)("PRT_ADDR2").ToString = "1" And Me.dtAgency.Rows(0)("ADDRESS2").ToString <> "" Then
                    str3 = str3 & Me.dtAgency.Rows(0)("ADDRESS2").ToString & " • "
                End If
                If Me.dtAgency.Rows(0)("PRT_CITY").ToString = "1" And Me.dtAgency.Rows(0)("CITY").ToString <> "" Then
                    str3 = str3 & Me.dtAgency.Rows(0)("CITY").ToString & ","
                End If
                If Me.dtAgency.Rows(0)("PRT_STATE").ToString = "1" And Me.dtAgency.Rows(0)("STATE").ToString <> "" Then
                    str3 = str3 & Me.dtAgency.Rows(0)("STATE").ToString & "  "
                End If
                If Me.dtAgency.Rows(0)("PRT_ZIP").ToString = "1" And Me.dtAgency.Rows(0)("ZIP").ToString <> "" Then
                    str3 = str3 & Me.dtAgency.Rows(0)("ZIP").ToString & " • "
                End If
                If Me.dtAgency.Rows(0)("PRT_PHONE").ToString = "1" And Me.dtAgency.Rows(0)("PHONE").ToString <> "" Then
                    str3 = str3 & Me.dtAgency.Rows(0)("PHONE").ToString & " • "
                End If
                If Me.dtAgency.Rows(0)("PRT_FAX").ToString = "1" And Me.dtAgency.Rows(0)("FAX").ToString <> "" Then
                    str3 = str3 & Me.dtAgency.Rows(0)("FAX").ToString & " Fax • "
                End If
                If Me.dtAgency.Rows(0)("PRT_EMAIL").ToString = "1" And Me.dtAgency.Rows(0)("EMAIL").ToString <> "" Then
                    str3 = str3 & Me.dtAgency.Rows(0)("EMAIL").ToString
                End If
                Me.txtAgencyInfo.Text = str3

            Else
                Me.txtAgencyName.Text = ""
                Me.txtAgencyInfo.Text = ""
            End If
        End If
    End Sub

    Private Sub GroupHeader2_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader2.Format
        Dim qty As String

        qty = Me.lblCatQty.Text

        If Not qty Is Nothing Then
            If Me.lblCatQty.Text.Length > 0 Then
                Me.GroupHeader2.Visible = True
                'Me.txtQuantity.Text = Me.lblCatDesc.Text & ": " & qty
                Me.txtQuantity.Text = qty
            Else
                Me.GroupHeader2.Visible = False
            End If
        Else
            Me.GroupHeader2.Visible = False
        End If
        
    End Sub

    Private Sub GroupHeader3_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader3.Format
        'Dim cat As DataView
        'cat = New DataView(Me.dtCategory)
        'cat.RowFilter = "(CATEGORY_ID = " & Me.txtCatID.Text & ")"
        'Me.txtCategory.Text = cat.Item(0)(0).ToString
    End Sub

    Private Sub Detail1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail1.Format

        Try
            Dim sep As String
            sep = Me.txtSeparator.Text
            If Me.txtSeparator.Text = "1" Then
                Me.LineSep.Visible = True
            Else
                Me.LineSep.Visible = False
            End If
        Catch ex As Exception
            Me.LineSep.Visible = False
        End Try
        
    End Sub

    Private Sub PageFooter1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageFooter1.Format
        Me.lblBy.Text = "by " & Reporter
    End Sub

    Private Sub GroupFooter3_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter3.Format
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

    Private Sub GroupFooter2_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter2.Format
        Try
            If Me.jobSpecsSubReportMS Is Nothing Then
                Me.jobSpecsSubReportMS = New arptMediaSpecs
                Me.jobSpecsSubReportMS.dtMediaSpecs = Me.dtMediaSpecs
                Me.srMediaSpecs.Report = Me.jobSpecsSubReportMS
                Me.srMediaSpecs.Report.DataSource = Me.dtMediaSpecs
            End If
        Catch ex As Exception
            Dim str As String = ""
        End Try
    End Sub

    Private Sub GroupFooter4_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter4.Format
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
            Me.Sections("GroupFooter2").Controls.Add(subreport)
        Catch ex As Exception
            Dim str As String = ""
        End Try

    End Sub

    Private Sub GroupHeader1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader1.Format
        Me.txtDesc.Text = Me.lblSpecVerDesc.Text
        Me.txtVersion.Text = Me.lblSpecVer.Text
        Me.txtRevision.Text = Me.lblSpecRev.Text
        Me.lblApproved.Text = Me.lblApprovedDtl.Text
        Me.txtReason.Text = Me.lblSpecReason.Text

    End Sub
End Class
