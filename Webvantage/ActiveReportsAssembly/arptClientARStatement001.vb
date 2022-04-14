Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document
Imports Webvantage.cReports
Imports System.Web
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing

Public Class arptClientARStatement001
    Public strID As String
    Public strPostPeriod As String
    Public strLocation As String
    Public strAgedDate As String
    Public strFooter As String
    Public imgPath As String
    Public dt As DataTable
    Public PutCommentInFooter As Boolean = False
    Public strExclude As String
    Public strIncludeComments As String
    'Private ds As arptClientDS
    'Private dt As New arptClientDS.usp_wv_reports_ar_statements_client_001DataTable
    Public _LocationLogo As AdvantageFramework.Database.Entities.LocationLogo = Nothing

    Public CultureCode As String = "en-US"
    Private Sub arptClientARStatement001_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        ReportFunctions.SetCulture(Me, CultureCode)
        'ds = New arptClientDS
        'Dim t As New arptClientDSTableAdapters.usp_wv_reports_ar_statements_client_001TableAdapter
        't.FillAR(dt, strID, strPostPeriod, strLocation, strAgedDate, strFooter)
        Me.DataSource = dt
        If Me.PutCommentInFooter = True Then
            Me.GroupHeader1.Height = 1.742
            With Me.Line6
                .Y1 = 1.25
                .Y2 = 1.25
            End With
            Me.GroupFooter1.Height = 1.596
            Me.Comments.Visible = False
            Me.CommentsFooter.Visible = True
        Else
            Me.GroupHeader1.Height = 1.702
            With Me.Line6
                .Y1 = 1.5
                .Y2 = 1.5
            End With
            Me.GroupFooter1.Height = 1.367
            Me.Comments.Visible = True
            Me.CommentsFooter.Visible = False
        End If

        Me.PageSettings.Margins.Top = 0.2F

        If strExclude = "1" Then
            Me.Label15.Visible = False
            Me.Description.Visible = False
            Me.Label14.Visible = False
            Me.Reference.Visible = False
            If strIncludeComments = "1" Then
                Me.Label3.Visible = True
                Me.TextboxInvoiceComments.Visible = True
            End If
        End If


    End Sub


    Private Sub GroupHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupHeader1.Format
        'Client Name and Address
        Try
            Dim str As String = Me.ClientName.Text
            If Me.AddressUse.Text = "2" Then
                str = str & vbCrLf & Me.SAddress1.Text
                If Me.SAddress2.Text <> "@@@" Then
                    str = str & vbCrLf & Me.SAddress2.Text
                End If
                If Me.SCity.Text <> "" Then
                    str = str & vbCrLf & Me.SCity.Text & ", "
                End If
                If Me.SState.Text <> "" Then
                    If Me.SCity.Text <> "" Then
                        str = str & Me.SState.Text
                    Else
                        str = str & vbCrLf & Me.SState.Text
                    End If
                End If
                If Me.SZip.Text <> "" Then
                    If Me.SCity.Text <> "" Or Me.SState.Text <> "" Then
                        str = str & " " & Me.SZip.Text
                    Else
                        str = str & vbCrLf & Me.SZip.Text
                    End If
                End If
            Else
                If Me.CAddress1.Text <> "" Then
                    str = str & vbCrLf & Me.CAddress1.Text
                End If
                If Me.CAddress2.Text <> "@@@" Then
                    str = str & vbCrLf & Me.CAddress2.Text
                End If
                If Me.CCity.Text <> "" Then
                    str = str & vbCrLf & Me.CCity.Text & ", "
                End If
                If Me.CState.Text <> "" Then
                    If Me.CCity.Text <> "" Then
                        str = str & Me.CState.Text
                    Else
                        str = str & vbCrLf & Me.CState.Text
                    End If
                End If
                If Me.CZip.Text <> "" Then
                    If Me.CCity.Text <> "" Or Me.CState.Text <> "" Then
                        str = str & " " & Me.CZip.Text
                    Else
                        str = str & vbCrLf & Me.CZip.Text
                    End If
                End If
            End If
            Me.ClientName.Text = str

            'Contact Name
            Dim str2 As String = Me.FirstName.Text
            str2 = str2 & " " & Me.LastName.Text
            Me.FirstName.Text = str2

            'Date
            Me.DateAR.Text = Now.Date.Date
            'Catch ex As Exception
            '    Me.ShowError("GroupHeader1_Format")
            'End Try

        Catch ex As Exception
            Err.Raise(Err.Number, "Error GroupHeader1_Format <br />" & ex.Message.ToString & "<br />" & ex.InnerException.ToString)
        End Try

    End Sub
    Private Sub Detail1_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail1.BeforePrint
        Try

            If Me.InvoiceAmount.Text <> "" Then
                Me.InvoiceAmount.Text = String.Format("{0:n}", CDec(ReportFunctions.FormatDecimal(Me.InvoiceAmount.Text)))
            End If

            If Me.InvoiceAmount.Text = "0.00" Then
                Me.InvoiceAmount.Text = ""
            End If

            If Me.Fields.Item("InvoiceSeq").Value <> 0 Then
                Me.InvoiceNumber.Text &= "-" & Format(Me.Fields.Item("InvoiceSeq").Value, "0000")
            End If


        Catch ex As Exception

        End Try
    End Sub
    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        'Amount Check - OA
        Dim str As String
        Try
            If Me.OriginalAmount.Text = Me.InvoiceAmount.Text Or Me.InvoiceAmount.Text = "0.00" Then
                Me.OriginalAmount.Text = ""
            Else
                Me.OriginalAmount.Text = "*"
            End If
            'If Me.Reference.Text.Trim = "Variou" Then
            str = Me.Reference.Text
            If Not str Is Nothing Then
                If str.Trim = "Variou" Then
                    Me.Reference.Text = "Various Jobs"
                End If
            End If
            If Me.InvoiceDate.Text <> "" Then
                Me.InvoiceDate.Text = CDate(Me.InvoiceDate.Text).ToShortDateString
            End If
        Catch ex As Exception
            Err.Raise(Err.Number, "Error Detail1_Format <br />" & ex.Message.ToString & "<br />" & ex.InnerException.ToString)
        End Try
    End Sub

    Private Sub GroupFooter1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupFooter1.Format
        'Using OnAccount Field
        Try
            If Me.OnAccount.Text = 1 Then
                If ReportFunctions.FormatDecimal(OnAccountAmount.Text) <> ReportFunctions.FormatDecimal(0) Then
                    Me.LessPayments.Text = "Less On Accounts Payments:"
                Else
                    Me.LessPayments.Text = ""
                End If
            Else
                Me.LessPayments.Text = ""
            End If

            'Using OnAccountAmount Field
            If Me.OnAccount.Text = 1 Then
                If ReportFunctions.FormatDecimal(OnAccountAmount.Text) <> ReportFunctions.FormatDecimal(0) Then
                    Me.OnAcc.Text = String.Format("{0:n}", CDec(ReportFunctions.FormatDecimal(Me.OnAccountAmount.Text)))
                Else
                    Me.OnAcc.Text = ""
                End If
            Else
                Me.OnAcc.Text = ""
            End If

            'Total
            If Me.OnAccount.Text = 1 Then
                Me.Total.Text = String.Format("{0:c}", CDec(ReportFunctions.FormatDecimal(Me.TotalAR.Text)) - CDec(ReportFunctions.FormatDecimal(Me.OnAccountAmount.Text)))
            Else
                Me.Total.Text = String.Format("{0:c}", CDec(ReportFunctions.FormatDecimal(Me.TotalAR.Text)))
            End If
        Catch ex As Exception
            Err.Raise(Err.Number, "Error GroupFooter1_Format <br />" & ex.Message.ToString & "<br />" & ex.InnerException.ToString)
        End Try

    End Sub

    Private Sub PageFooter1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageFooter1.Format
        'Footer
        Try
            If strLocation <> "None" Then
                Me.Footer.Text = strFooter.Replace("?", "•")
            End If
        Catch ex As Exception
            Err.Raise(Err.Number, "Error PageFooter1_Format <br />" & ex.Message.ToString & "<br />" & ex.InnerException.ToString)
        End Try

    End Sub

    Private Sub PageHeader1_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageHeader1.BeforePrint
        Dim str As String
        Dim cityStateZip As String = ""
        Try
            Dim str3 As String

            If Me.PrtHeader.Text = "1" Then
                If strLocation <> "None" Then
                    'Agency Name
                    If Me.PrtName.Text <> "1" Then
                        Me.AgencyName.Text = ""
                    End If

                    'Agency Information
                    str = Me.AgencyAddress1.Text
                    If Not str Is Nothing Then
                        If Me.PrtAddr1.Text = "1" And str.Trim <> "" Then
                            str3 = Me.AgencyAddress1.Text
                        End If
                    End If

                    str = Me.AgencyAddress2.Text
                    If Not str Is Nothing Then
                        If Me.PrtAddr2.Text = "1" And str.Trim <> "" Then
                            If str3 > "" Then
                                str3 = str3 & " • "
                            End If
                            str3 = str3 & AgencyAddress2.Text
                        End If
                    End If

                    str = Me.AgencyCity.Text
                    If Not str Is Nothing Then
                        If Me.PrtCity.Text = "1" And str.Trim <> "" Then
                            cityStateZip = AgencyCity.Text & ","
                        End If
                    End If

                    str = Me.AgencyState.Text
                    If Not str Is Nothing Then
                        If Me.PrtState.Text = "1" And str.Trim <> "" Then
                            If cityStateZip <> "" Then
                                cityStateZip = cityStateZip & " "
                            End If
                            cityStateZip = cityStateZip & AgencyState.Text
                        End If
                    End If

                    str = Me.AgencyZip.Text
                    If Not str Is Nothing Then
                        If Me.PrtZip.Text = "1" And str.Trim <> "" Then
                            If cityStateZip <> "" Then
                                cityStateZip = cityStateZip & " "
                            End If
                            cityStateZip = cityStateZip & AgencyZip.Text
                        End If
                    End If

                    If cityStateZip <> "" Then
                        If str3 > "" Then
                            str3 = str3 & " • "
                        End If
                        str3 = str3 & cityStateZip
                    End If

                    str = Me.AgencyPhone.Text
                    If Not str Is Nothing Then
                        If Me.PrtPhone.Text = "1" And str.Trim <> "" Then
                            If str3 > "" Then
                                str3 = str3 & " • "
                            End If
                            str3 = str3 & AgencyPhone.Text
                        End If
                    End If

                    str = Me.AgencyFax.Text
                    If Not str Is Nothing Then
                        If Me.PrtFax.Text = "1" And str.Trim <> "" Then
                            If str3 > "" Then
                                str3 = str3 & " • "
                            End If
                            str3 = str3 & AgencyFax.Text & " Fax "
                        End If
                    End If

                    str = Me.AgencyEmail.Text
                    If Not str Is Nothing Then
                        If Me.PrtEmail.Text = "1" And str.Trim <> "" Then
                            If str3 > "" Then
                                str3 = str3 & " • "
                            End If
                            str3 = str3 & AgencyEmail.Text
                        End If
                    End If

                End If

                If Me.AgencyName.Text = "" Then
                    Me.AgencyInfo.Text = str3
                Else
                    If str3 Is Nothing Or str3 = "" Then
                        Me.AgencyInfo.Text = Me.AgencyName.Text
                    Else
                        Me.AgencyInfo.Text = Me.AgencyName.Text & " • " & str3
                    End If
                End If


            Else
                'Me.AgencyName.Text = ""
                Me.AgencyInfo.Text = ""
            End If

            'If strLocation <> "" Then

            '    Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())
            '        rpt._LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, Request.QueryString("Loc"), AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)
            '    End Using

            'End If


            If _LocationLogo IsNot Nothing AndAlso _LocationLogo.Image IsNot Nothing Then

                Using MemoryStream = New System.IO.MemoryStream(_LocationLogo.Image)

                    Using img As Image = System.Drawing.Image.FromStream(MemoryStream)

                        Dim bm As Bitmap

                        bm = New Bitmap(img)

                        Me.Picture1.Image = bm

                    End Using

                End Using

            Else

                If Me.LogoPath.Text <> "" Then

                    Dim f As New IO.FileInfo(Me.LogoPath.Text)
                    If f.Exists Then
                        Me.Picture1.Image = Drawing.Image.FromFile(Me.LogoPath.Text)
                    Else
                        Me.Picture1.Image = Drawing.Image.FromFile(imgPath)
                    End If
                Else
                    Me.Picture1.Image = Drawing.Image.FromFile(imgPath)
                End If

            End If

        Catch ex As Exception
            Err.Raise(Err.Number, "Error PageHeader1_BeforePrint <br />" & ex.Message.ToString & "<br />" & ex.InnerException.ToString)
        End Try
    End Sub

    'Private Sub ReportHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportHeader1.Format
    '    If strLocation <> "None" Then
    '        If Me.LogoPath.Text <> "" Then
    '            Dim f As New IO.FileInfo(Me.LogoPath.Text)
    '            If f.Exists Then
    '                Me.Picture1.Image = Drawing.Image.FromFile(Me.LogoPath.Text)
    '            Else
    '                Me.Picture1.Image = Drawing.Image.FromFile(imgPath)
    '            End If
    '        Else
    '            Me.Picture1.Image = Drawing.Image.FromFile(imgPath)
    '        End If
    '    Else
    '        Me.ReportHeader1.Visible = False
    '    End If
    'End Sub
    
    Private Sub GroupFooter2_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter2.Format
        Try
            Me.CurrentAR.Text = String.Format("{0:n}", CDec(ReportFunctions.FormatDecimal(Me.CurrentAR.Text)))
            Me.OverThirtyAR.Text = String.Format("{0:n}", CDec(ReportFunctions.FormatDecimal(Me.OverThirtyAR.Text)))
            Me.OverSixtyAR.Text = String.Format("{0:n}", CDec(ReportFunctions.FormatDecimal(Me.OverSixtyAR.Text)))
            Me.TotalAR.Text = String.Format("{0:n}", CDec(ReportFunctions.FormatDecimal(Me.TotalAR.Text)))
        Catch ex As Exception

        End Try
    End Sub
End Class
