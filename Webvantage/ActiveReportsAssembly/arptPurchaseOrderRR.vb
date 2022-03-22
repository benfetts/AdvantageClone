Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports System.Data.SqlClient
Imports System
Imports System.IO
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel

Public Class arptPurchaseOrderRR
    Public StrUserID As String
    Public ponumber As String
    Public logopath As String
    Public imgPath As String 'global default image.
    Public LogoID As String
    Public LogoName As String
    Public PODate As String
    Public Void As Boolean
    Public ds1 As DataSet
    Public header As String
    Public SigImage As System.Drawing.Image
    Public UseEmpSig As Boolean
    Public ds As New DataSet()
    Public FooterComment As String
    Public DefaultFooterFontSize As Double = 0
    Public AgencyName As String
    Public DefaultLocation As AdvantageFramework.Database.Entities.Location
    Private _LocationLogo As AdvantageFramework.Database.Entities.LocationLogo = Nothing
    Public _Clientname As String = ""
    Public UseLocationName As Boolean = False
    Public UseClientName As Boolean = False
    Public ConnString As String
    Public UserCode As String


    Private POHeader1 As arptPOHeader = Nothing

    Private Sub arptPurchaseOrder_PageEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PageEnd
        If Me.PageNumber <> 1 Then
            lbl_main_instruct.Visible = False
            Me.txt_maininstruct.Visible = False
        End If
    End Sub

    Private Sub arptPurchaseOrder_PageStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PageStart
        If Me.PageNumber <> 1 Then
            lbl_main_instruct.Visible = False
            Me.txt_maininstruct.Visible = False
        End If
    End Sub

    Private Sub arptPurchaseOrder_ReportEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportEnd

    End Sub

    Public CultureCode As String = "en-US"
    Private Sub arptPurchaseOrder_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        ReportFunctions.SetCulture(Me, CultureCode)
        Me.DataSource = ds1.Tables(0)

        Me.POHeader1 = New arptPOHeader
        Me.POHeader1.dtData = ds1.Tables(0)
        Me.POHeader1.PODate = PODate
        Me.POHeader1.LogoID = ""
        Me.POHeader1.CultureCode = CultureCode
        Me.SubReport1.Report = POHeader1

    End Sub

    Private Sub group_detail_line2_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles group_detail_line2.Format
        Try
            If txt_det_desc.Text.Trim = "" Then
                'Me.group_detail_line2.Visible = False
            End If
        Catch ex As Exception
            'Me.txt_hdr_agency_name.Text = ex.Message.ToString
        End Try
    End Sub
    Private Sub group_detail_line3_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles group_detail_line3.Format
        Try
            If txt_instructions.Text.Trim = "" Then
                'Me.group_detail_line3.Visible = False
            End If
        Catch ex As Exception
            'Me.txt_hdr_agency_name.Text = ex.Message.ToString
        End Try
    End Sub

    Private Sub GroupFooter6_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter6.Format
        Try
            If txtDelivery.Text.Trim = "-" Then
                lbl_deliver.Visible = False
                Me.txtDelivery.Visible = False
            End If
        Catch ex As Exception
            'Me.txt_hdr_agency_name.Text = ex.Message.ToString
        End Try
    End Sub

    Private Sub GroupFooter5_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter5.Format

    End Sub

    Private Sub ReportFooter1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportFooter1.Format

    End Sub

    Private Sub ReportHeader1_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportHeader1.BeforePrint


    End Sub

    Private Sub PageHeader1_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageHeader1.BeforePrint

        Dim LocationInfo As Generic.List(Of String) = Nothing
        Dim CityStateZipLine As String = Nothing

        Try

            If Me.DefaultLocation IsNot Nothing Then

                If Me.DefaultLocation.PrintHeader.GetValueOrDefault(0) Then

                    If Not CBool(Me.DefaultLocation.PrintNameHeader.GetValueOrDefault(0)) Then

                        Me.txt_hdr_agency_name.Visible = False

                    End If

                    LocationInfo = New Generic.List(Of String)

                    If CBool(Me.DefaultLocation.PrintCityHeader.GetValueOrDefault(0)) Then

                        CityStateZipLine = Me.DefaultLocation.City

                    End If

                    If CBool(Me.DefaultLocation.PrintStateHeader.GetValueOrDefault(0)) Then

                        CityStateZipLine = CityStateZipLine & If(String.IsNullOrEmpty(CityStateZipLine) = False, ", ", "") & Me.DefaultLocation.State

                    End If

                    If CBool(Me.DefaultLocation.PrintZipHeader.GetValueOrDefault(0)) Then

                        CityStateZipLine = CityStateZipLine & If(String.IsNullOrEmpty(CityStateZipLine) = False, " ", "") & Me.DefaultLocation.Zip

                    End If

                    'BuildLocationString(Me.DefaultLocation.Name, CBool(Me.DefaultLocation.PrintNameHeader.GetValueOrDefault(0)), LocationInfo)
                    BuildLocationString(Me.DefaultLocation.Address, CBool(Me.DefaultLocation.PrintAddressHeader.GetValueOrDefault(0)), LocationInfo)
                    BuildLocationString(Me.DefaultLocation.Address2, CBool(Me.DefaultLocation.PrintAddress2Header.GetValueOrDefault(0)), LocationInfo)
                    BuildLocationString(CityStateZipLine, Not String.IsNullOrEmpty(CityStateZipLine), LocationInfo)
                    BuildLocationString(String.Format("{0:(###) ###-####}", Me.DefaultLocation.Phone), CBool(Me.DefaultLocation.PrintPhoneHeader.GetValueOrDefault(0)), LocationInfo)
                    BuildLocationString(String.Format("{0:(###) ###-####}", Me.DefaultLocation.Fax), CBool(Me.DefaultLocation.PrintFaxHeader.GetValueOrDefault(0)), LocationInfo)
                    BuildLocationString(Me.DefaultLocation.Email, CBool(Me.DefaultLocation.PrintEmailHeader.GetValueOrDefault(0)), LocationInfo)

                    Me.txt_agency_full_header.Text = String.Join(" • ", LocationInfo)

                Else

                    Me.txt_hdr_agency_name.Visible = False
                    Me.txt_agency_full_header.Visible = False

                End If

            End If

            'If Me.PODate <> "" Then
            '    Me.txt_Issue_Date.Text = PODate
            'Else
            '    If Me.txt_Issue_Date.Text <> "" Then
            '        Me.txt_Issue_Date.Text = CDate(Me.txt_Issue_Date.Text).ToShortDateString
            '    End If
            'End If
            'If Me.txt_due_date.Text <> "" Then
            '    Me.txt_due_date.Text = CDate(Me.txt_due_date.Text).ToShortDateString
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PageHeader1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageHeader1.Format

        'objects
        Dim FileInfo As System.IO.FileInfo = Nothing
        Dim LogoVisible As Boolean = False
        Dim FilePath As String = Nothing
        Dim Image As Object = Nothing

        Try

            Try

                Using DbContext As New AdvantageFramework.Database.DbContext(ConnString, UserCode)
                    If DefaultLocation IsNot Nothing Then

                        _LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, DefaultLocation.ID, AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)

                    Else

                        _LocationLogo = Nothing

                    End If
                End Using


                If Me.DefaultLocation IsNot Nothing Then

                    If Me.DefaultLocation.LogoLocation <> "N" Then

                        If String.IsNullOrWhiteSpace(DefaultLocation.LogoPath) = False Then

                            If My.Computer.FileSystem.FileExists(DefaultLocation.LogoPath) Then

                                LogoVisible = True
                                Me.Picture1.Image = System.Drawing.Image.FromFile(DefaultLocation.LogoPath)

                            End If

                        ElseIf _LocationLogo IsNot Nothing AndAlso _LocationLogo.Image IsNot Nothing Then

                            Using MemoryStream = New System.IO.MemoryStream(_LocationLogo.Image)

                                LogoVisible = True

                                Using img As Image = System.Drawing.Image.FromStream(MemoryStream)

                                    Dim bm As Bitmap

                                    bm = New Bitmap(img)

                                    Me.Picture1.Image = bm

                                End Using

                            End Using

                        End If

                    End If

                ElseIf Me.logopath <> "" Then

                    FileInfo = New IO.FileInfo(Me.logopath)

                    If FileInfo.Exists Then

                        LogoVisible = True
                        FilePath = Me.logopath.Trim

                    Else

                        LogoVisible = True
                        FilePath = imgPath

                    End If

                    Me.Picture1.Image = System.Drawing.Image.FromFile(FilePath)

                End If

                If Me.LogoID = "None" Then

                    Me.txt_agency_full_header.Visible = False
                    Me.txt_hdr_agency_name.Visible = False

                End If

                Me.Picture1.Visible = LogoVisible

                'If Me.Picture1.Visible Then

                '    If Image IsNot Nothing Then
                '        Me.Picture1.Image = System.Drawing.Image.
                '    Else
                '        Me.Picture1.Image = System.Drawing.Image.FromFile(FilePath)
                '    End If


                'End If

            Catch ex As Exception
                'Me.txt_hdr_agency_name.Text = ex.Message.ToString
            End Try

            'If Me.txt_Vendor_Attn.Text.Trim = "" Then
            '    Me.TextBox10.Visible = False
            'End If
            'If Me.logopath <> "" Then
            '    FixAddress()
            'End If

            'If Me.PODate <> "" Then
            '    Me.txt_Issue_Date.Text = PODate
            'Else
            '    If Me.txt_Issue_Date.Text.Trim <> "" Then
            '        Me.txt_Issue_Date.Text = CDate(Me.txt_Issue_Date.Text).ToShortDateString
            '    End If
            'End If
            'If Me.txt_due_date.Text.Trim <> "" Then
            '    Me.txt_due_date.Text = CDate(Me.txt_due_date.Text).ToShortDateString
            'End If

            'If Me.txt_Vendor_Attn.Text = "" Then
            '    Me.TextBox10.Visible = False
            'End If

            'If Me.lblRevised.Text = "1" Then
            '    Me.lblRevised.Text = "***Revised***"
            'Else
            '    Me.lblRevised.Text = ""
            'End If


            Me.txt_agency_full_header.Text = header 'LTrim(Me.txt_agency_full_header.Text.Replace("|", "•"))
            'Me.txtAgent.Text = Me.AgencyName
        Catch ex As Exception
            'Me.txt_hdr_agency_name.Text = ex.Message.ToString
        End Try

    End Sub

    Private Sub BuildLocationString(ByVal FieldValue As String, ByVal PrintField As Boolean, ByVal List As Generic.List(Of String))

        Try

            If PrintField Then

                If String.IsNullOrEmpty(FieldValue) = False Then

                    List.Add(FieldValue)

                End If

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub grp_po_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles grp_po.Format
        If txt_maininstruct.Text.Trim = "-" Then
            lbl_main_instruct.Visible = False
            Me.txt_maininstruct.Visible = False
        End If

        If Me.txtProduct.Text <> "" And Me.txt_client.Text <> "" And Me.txtFncDesc.Text <> "" Then
            Me.Label4.Text = "Client/Product/Function"
        ElseIf Me.txtProduct.Text <> "" And Me.txt_client.Text <> "" And Me.txtFncDesc.Text = "" Then
            Me.Label4.Text = "Client/Product"
        ElseIf Me.txtProduct.Text = "" And Me.txt_client.Text <> "" And Me.txtFncDesc.Text <> "" Then
            Me.Label4.Text = "Client/Function"
        ElseIf Me.txtProduct.Text <> "" And Me.txt_client.Text = "" And Me.txtFncDesc.Text <> "" Then
            Me.Label4.Text = "Product/Function"
        ElseIf Me.txtProduct.Text = "" And Me.txt_client.Text <> "" And Me.txtFncDesc.Text = "" Then
            Me.Label4.Text = "Client"
        ElseIf Me.txtProduct.Text = "" And Me.txt_client.Text = "" And Me.txtFncDesc.Text <> "" Then
            Me.Label4.Text = "Function"
        ElseIf Me.txtProduct.Text <> "" And Me.txt_client.Text = "" And Me.txtFncDesc.Text = "" Then
            Me.Label4.Text = "Product"
        End If

        If Me.txt_client.Text = "" And Me.txtProduct.Text = "" And Me.txtFncDesc.Text = "" Then
            Me.Label4.Visible = False
        End If

    End Sub


    Private Sub grp_detail_line_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles grp_detail_line.Format
        Try
            If Me.txtProduct.Text <> "" And Me.txt_client.Text <> "" Then
                Me.txt_client.Text = Me.txt_client.Text & vbCrLf & Me.txtProduct.Text
            ElseIf Me.txtProduct.Text <> "" And Me.txt_client.Text = "" Then
                Me.txt_client.Text = Me.txtProduct.Text
            End If
            If Me.txtFncDesc.Text <> "" And Me.txt_client.Text <> "" Then
                Me.txt_client.Text = Me.txt_client.Text & vbCrLf & Me.txtFncDesc.Text
            ElseIf Me.txtFncDesc.Text <> "" And Me.txt_client.Text = "" Then
                Me.txt_client.Text = Me.txtFncDesc.Text
            End If

            If txtJobDesc.Text <> "" And Me.TextBox1.Text <> "" Then
                Me.TextBox1.Text = Me.TextBox1.Text & vbCrLf & Me.txtJobDesc.Text
            ElseIf Me.txtJobDesc.Text <> "" And Me.TextBox1.Text = "" Then
                Me.TextBox1.Text = Me.txtJobDesc.Text
            End If
            If txtJobCompDesc.Text <> "" And Me.TextBox1.Text <> "" Then
                Me.TextBox1.Text = Me.TextBox1.Text & vbCrLf & Me.txtJobCompDesc.Text
            ElseIf Me.txtJobCompDesc.Text <> "" And Me.TextBox1.Text = "" Then
                Me.TextBox1.Text = Me.txtJobCompDesc.Text
            End If

            If Me.TextBox1.Text = "" Then
                Me.Label5.Visible = False
            End If


        Catch ex As Exception
            'Me.txt_hdr_agency_name.Text = ex.Message.ToString
        End Try

    End Sub

    Private Sub PageFooter1_BeforePrint(sender As Object, e As EventArgs) Handles PageFooter1.BeforePrint

        'objects
        Dim LocationInfo As Generic.List(Of String) = Nothing
        Dim LocationString As String = Nothing
        Dim CityStateZipLine As String = Nothing

        If Me.DefaultLocation IsNot Nothing Then

            LocationInfo = New Generic.List(Of String)

            If CBool(Me.DefaultLocation.PrintCityFooter.GetValueOrDefault(0)) Then

                CityStateZipLine = Me.DefaultLocation.City

            End If

            If CBool(Me.DefaultLocation.PrintStateFooter.GetValueOrDefault(0)) Then

                CityStateZipLine = CityStateZipLine & If(String.IsNullOrEmpty(CityStateZipLine) = False, ", ", "") & Me.DefaultLocation.State

            End If

            If CBool(Me.DefaultLocation.PrintZipFooter.GetValueOrDefault(0)) Then

                CityStateZipLine = CityStateZipLine & If(String.IsNullOrEmpty(CityStateZipLine) = False, " ", "") & Me.DefaultLocation.Zip

            End If

            BuildLocationString(Me.DefaultLocation.Name, CBool(Me.DefaultLocation.PrintNameFooter.GetValueOrDefault(0)), LocationInfo)
            BuildLocationString(Me.DefaultLocation.Address, CBool(Me.DefaultLocation.PrintAddressFooter.GetValueOrDefault(0)), LocationInfo)
            BuildLocationString(Me.DefaultLocation.Address2, CBool(Me.DefaultLocation.PrintAddress2Footer.GetValueOrDefault(0)), LocationInfo)
            BuildLocationString(CityStateZipLine, Not String.IsNullOrEmpty(CityStateZipLine), LocationInfo)
            BuildLocationString(String.Format("{0:(###) ###-####}", Me.DefaultLocation.Phone), CBool(Me.DefaultLocation.PrintPhoneFooter.GetValueOrDefault(0)), LocationInfo)
            BuildLocationString(String.Format("{0:(###) ###-####}", Me.DefaultLocation.Fax), CBool(Me.DefaultLocation.PrintFaxFooter.GetValueOrDefault(0)), LocationInfo)
            BuildLocationString(Me.DefaultLocation.Email, CBool(Me.DefaultLocation.PrintEmailFooter.GetValueOrDefault(0)), LocationInfo)

            Me.txt_agency_full_footer.Text = String.Join(" • ", LocationInfo)

        End If

    End Sub

    Private Sub PageFooter1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageFooter1.Format
        'Check if nothing, the descriptions can be long and may not exist yet.
        If Me.txt_agency_full_footer.Text <> Nothing Then
            Me.txt_agency_full_footer.Text = RTrim(LTrim(Me.txt_agency_full_footer.Text.Replace("|", "•")))
        End If
    End Sub

    Private Sub FixAddress()
        Try
            'Dim str As String = RTrim(LTrim(Me.txt_agency_full_header.Text.Replace("|", "•")))
            ''str = Webvantage.MiscFN.RemoveTrailingDelimiter(str, "•")
            'Me.txt_agency_full_header.Text = str

            'Dim str2 As String = RTrim(LTrim(Me.txt_agency_full_footer.Text.Replace("|", "•")))
            ''str2 = Webvantage.MiscFN.RemoveTrailingDelimiter(str2, "•")
            'Me.txt_agency_full_footer.Text = str2
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Detail1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail1.Format
        Me.txt_agency_full_header.Text = header
    End Sub

    Private Sub GroupFooter4_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter4.Format
        Try
            If UseEmpSig Then
                Me.EmpSigPic.Image = SigImage
                If Me.PODate <> "" Then
                    Me.AuthDate.Text = PODate
                Else
                    If Me.AuthDate.Text <> "" Then
                        Me.AuthDate.Text = CDate(Me.AuthDate.Text).ToShortDateString
                    End If
                End If
            Else
                Me.AuthDate.Text = ""
            End If

        Catch ex As Exception
        End Try
        Try

            txt_footer.Text = FooterComment

            If txt_footer.Text.Trim = "" Then

                lbl_footer.Visible = False

            Else

                If DefaultFooterFontSize <> 0 Then

                    txt_footer.Font = New System.Drawing.Font(txt_footer.Font.FontFamily.Name, DefaultFooterFontSize)

                End If

            End If

        Catch ex As Exception
            'Me.txt_hdr_agency_name.Text = ex.Message.ToString
        End Try
    End Sub

    Private Sub GroupFooter4_BeforePrint(sender As Object, e As System.EventArgs) Handles GroupFooter4.BeforePrint
        Try
            ReportFunctions.SetCulture(Me, CultureCode)
            Me.txt_PO_total.Text = String.Format("{0:c}", CDec(Me.txt_PO_total.Text))

            If UseLocationName = True Then
                Me.Label18.Text = Me.LogoName & " Authorization:"
            End If

            If UseClientName = True Then
                Me.Label18.Text = "Agency Authorization as agent for " & _Clientname & ":"
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub GroupHeader1_Format(sender As Object, e As System.EventArgs) Handles GroupHeader1.Format
        Try
            If Me.txt_Vendor_Attn.Text.Trim = "" Then
                Me.TextBox10.Visible = False
            End If
            If Me.txt_Vendor_Attn.Text = "" Then
                Me.TextBox10.Visible = False
            End If
            Try
                If IsNumeric(Me.txtRevised.Text) = True Then
                    Dim r As Integer = CType(Me.txtRevised.Text, Integer)
                    If r > 0 Then
                        Me.txtRevised.Text = "***Revised***"
                    Else
                        Me.txtRevised.Text = ""
                    End If
                Else
                    Me.txtRevised.Text = ""
                End If
            Catch ex As Exception
                Me.txtRevised.Text = ""
            End Try
            If Me.Void = True Then
                Me.txtVoid.Visible = True
            Else
                Me.txtVoid.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub

End Class
