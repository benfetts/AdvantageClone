Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document
Imports System.Data.SqlClient

Public Class arptPurchaseOrder2
    Public StrUserID As String
    Public ponumber As String
    Public logopath As String
    Public imgPath As String 'global default image.
    Public LogoID As String
    Public PODate As String
    Public Void As Boolean
    Public ds1 As DataSet
    Public header As String
    Public UseEmpSig As Boolean
    Public SigImage As System.Drawing.Image
    Public FooterComment As String
    Public DefaultFooterFontSize As Double = 0

    Private Sub arptPurchaseOrder2_PageEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PageEnd
        If Me.PageNumber <> 1 Then
            lbl_main_instruct.Visible = False
            Me.txt_maininstruct.Visible = False
        End If
    End Sub

    Private Sub arptPurchaseOrder2_PageStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PageStart
        If Me.PageNumber <> 1 Then
            lbl_main_instruct.Visible = False
            Me.txt_maininstruct.Visible = False
        End If
    End Sub

    Private Sub arptPurchaseOrder2_ReportEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportEnd

    End Sub

    Public CultureCode As String = "en-US"
    Private Sub arptPurchaseOrder2_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        ReportFunctions.SetCulture(Me, CultureCode)
        Me.DataSource = ds1.Tables(0)
    End Sub

    Private Sub group_detail_line2_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles group_detail_line2.Format
        Try
            If txt_det_desc.Text.Trim = "" Then
                Me.group_detail_line2.Visible = False
            End If
        Catch ex As Exception
            'Me.txt_hdr_agency_name.Text = ex.Message.ToString
        End Try
    End Sub
    Private Sub group_detail_line3_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles group_detail_line3.Format
        Try
            If txt_instructions.Text.Trim = "" Then
                Me.group_detail_line3.Visible = False
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
        Try
            If Me.PODate <> "" Then
                Me.txt_Issue_Date.Text = PODate
            Else
                If Me.txt_Issue_Date.Text <> "" Then
                    Me.txt_Issue_Date.Text = CDate(Me.txt_Issue_Date.Text).ToShortDateString
                End If
            End If
            If Me.txt_due_date.Text <> "" Then
                Me.txt_due_date.Text = CDate(Me.txt_due_date.Text).ToShortDateString
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PageHeader1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageHeader1.Format
        Try
            Try
                If Me.logopath <> "" Then
                    Dim f As New IO.FileInfo(Me.logopath)
                    If f.Exists Then
                        Me.Picture1.Image = Drawing.Image.FromFile(Me.logopath.Trim)
                    Else
                        Me.Picture1.Image = Drawing.Image.FromFile(imgPath)
                    End If
                    If Me.LogoID = "None" Then
                        Me.Picture1.Visible = False
                        Me.txt_agency_full_header.Visible = False
                        Me.txt_hdr_agency_name.Visible = False
                    End If
                Else
                    Me.Picture1.Visible = False
                    'Me.txt_agency_full_header.Visible = False
                    'Me.txt_hdr_agency_name.Visible = False
                    'Me.Picture1.Image = Drawing.Image.FromFile(imgPath)
                End If
            Catch ex As Exception
                'Me.txt_hdr_agency_name.Text = ex.Message.ToString
            End Try

            If Me.txt_Vendor_Attn.Text.Trim = "" Then
                Me.Label17.Visible = False
            End If
            'If Me.logopath <> "" Then
            '    FixAddress()
            'End If

            If Me.PODate <> "" Then
                Me.txt_Issue_Date.Text = PODate
            Else
                If Me.txt_Issue_Date.Text.Trim <> "" Then
                    Me.txt_Issue_Date.Text = CDate(Me.txt_Issue_Date.Text).ToShortDateString
                End If
            End If
            If Me.txt_due_date.Text.Trim <> "" Then
                Me.txt_due_date.Text = CDate(Me.txt_due_date.Text).ToShortDateString
            End If
            If Me.txt_Vendor_Attn.Text = "" Then
                Me.Label17.Visible = False
            End If

            'If Me.lblRevised.Text = "1" Then
            '    Me.lblRevised.Text = "***Revised***"
            'Else
            '    Me.lblRevised.Text = ""
            'End If
            Try
                If IsNumeric(Me.lblRevised.Text) = True Then
                    Dim r As Integer = CType(Me.lblRevised.Text, Integer)
                    If r > 0 Then
                        Me.lblRevised.Text = "***Revised***"
                    Else
                        Me.lblRevised.Text = ""
                    End If
                Else
                    Me.lblRevised.Text = ""
                End If
            Catch ex As Exception
                Me.lblRevised.Text = ""
            End Try
            If Me.Void = True Then
                Me.txtVoid.Visible = True
            Else
                Me.txtVoid.Visible = False
            End If

            Me.txt_agency_full_header.Text = header 'LTrim(Me.txt_agency_full_header.Text.Replace("|", "•"))

        Catch ex As Exception
            'Me.txt_hdr_agency_name.Text = ex.Message.ToString
        End Try

    End Sub

    Private Sub grp_detail_line_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles grp_detail_line.Format
        Try
            If Me.txtProduct.Text <> "" And Me.txt_client.Text <> "" Then
                Me.txt_client.Text = Me.txt_client.Text & vbCrLf & Me.txtProduct.Text
            ElseIf Me.txtProduct.Text <> "" And Me.txt_client.Text = "" Then
                Me.txt_client.Text = Me.txtProduct.Text
            End If
            If Me.txtJobDesc.Text <> "" And Me.txt_client.Text <> "" Then
                Me.txt_client.Text = Me.txt_client.Text & vbCrLf & Me.txtJobDesc.Text
            ElseIf Me.txtJobDesc.Text <> "" And Me.txt_client.Text = "" Then
                Me.txt_client.Text = Me.txtJobDesc.Text
            End If
            If Me.txtFncDesc.Text <> "" And Me.txt_client.Text <> "" Then
                Me.txt_client.Text = Me.txt_client.Text & vbCrLf & Me.txtFncDesc.Text
            ElseIf Me.txtFncDesc.Text <> "" And Me.txt_client.Text = "" Then
                Me.txt_client.Text = Me.txtFncDesc.Text
            End If
        Catch ex As Exception
            'Me.txt_hdr_agency_name.Text = ex.Message.ToString
        End Try

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

    Private Sub GroupFooter4_BeforePrint(sender As Object, e As System.EventArgs) Handles GroupFooter4.BeforePrint
        Try
            ReportFunctions.SetCulture(Me, CultureCode)
            Me.txt_PO_total.Text = String.Format("{0:c}", CDec(Me.txt_PO_total.Text))
        Catch ex As Exception

        End Try
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

                'lbl_footer.Visible = False

            Else

                If DefaultFooterFontSize <> 0 Then

                    txt_footer.Font = New System.Drawing.Font(txt_footer.Font.FontFamily.Name, DefaultFooterFontSize)

                End If

            End If

        Catch ex As Exception
            'Me.txt_hdr_agency_name.Text = ex.Message.ToString
        End Try
    End Sub

    Private Sub grp_po_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles grp_po.Format
        If txt_maininstruct.Text.Trim = "-" Then
            lbl_main_instruct.Visible = False
            Me.txt_maininstruct.Visible = False
        End If

        If Me.txtProduct.Text <> "" And Me.txt_client.Text <> "" Then
            Me.Label4.Text = "Client/Product"
        ElseIf Me.txtProduct.Text <> "" And Me.txt_client.Text = "" Then
            Me.Label4.Text = "Product"
        End If

        If Me.txt_client.Text = "" And Me.txtProduct.Text = "" Then
            Me.Label4.Visible = False
        End If

        If Me.TextBox1.Text = "" Then
            Me.Label5.Visible = False
        End If
    End Sub
End Class
