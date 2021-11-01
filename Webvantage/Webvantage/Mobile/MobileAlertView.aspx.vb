Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Security
Imports Microsoft.Win32
Imports Webvantage.cGlobals.Globals
Imports Webvantage.MiscFN
Imports System.Web.Mobile
Imports System.Web.UI.MobileControls
Imports System.Drawing

Partial Public Class MobileAlertView
    Inherits MobileBase

    Private accessPrivate As Integer
    Public sAlertID As String
    Private CurrentAlertID As Integer
    Private CurrentAlert As Alert

    Shared ReadOnly _slashArray() As Char = {"/"}
    Public sRestrictBrowser() As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GetQueryString()
        accessPrivate = Convert.ToInt32(AdvantageFramework.Security.LoadUserGroupSetting(_Session, AdvantageFramework.Security.GroupSettings.DocumentManager_ViewPrivateDocuments).Any(Function(SettingValue) SettingValue = True))

        sRestrictBrowser = Split(System.Configuration.ConfigurationManager.AppSettings("RestrictMobile").ToString(), ",")

        If Not IsPostBack() Then
            lblFileMessage.Text = ""
            FillAlertView()
            HideColumns()
        End If




    End Sub
    'only hides columns and makes changes if web.config is changed to restrict mobile.
    Public Sub HideColumns()
        If (Not IsNothing(Request.Headers("User-Agent"))) Then
            If Not IsNothing(sRestrictBrowser) Then
                For i As Integer = 0 To sRestrictBrowser.GetUpperBound(0)
                    If Request.Headers("User-Agent").Contains(sRestrictBrowser(i).ToString()) Then
                        gvAttachments.Columns(0).Visible = False
                        gvAttachments.Columns(2).Visible = False
                        gvAttachments.Columns(3).Visible = False
                        gvAttachments.Columns(4).Visible = False

                        gvComments.Columns(1).Visible = False
                        gvComments.Columns(2).Visible = False
                        gvComments.Columns(3).Visible = False
                    End If
                Next
            End If
        End If
    End Sub


    Private Sub GetQueryString()
        If Not IsNothing(Request.QueryString("alert")) Then
            If IsNumeric(Request.QueryString("alert")) Then
                CurrentAlertID = CInt(Request.QueryString("alert"))
                CurrentAlert = New Alert(Session("ConnString"))

            End If
        End If
    End Sub

    Private Sub FillAlertView()
        If CurrentAlert.LoadByPrimaryKey(CurrentAlertID) Then

            Dim Recipient As New AlertRecipient(Session("ConnString"))
            Recipient.Where.ALERT_ID.Value = CurrentAlert.ALERT_ID
            Recipient.Where.EMP_CODE.Value = Session("EmpCode")
            Recipient.Query.Load()

            If Recipient.RowCount = 0 Then
                'Throw New Exception("Access Denied.")
                'Me.JSMessageBox("Access Denied.")
                'Exit Sub
            Else
                If Not Recipient.IsColumnNull(Recipient.ColumnNames.PROCESSED) Then
                    'Me.DismissedLabel.Text = Format(Recipient.PROCESSED, "G")
                    Me.lblStatus.Visible = True
                    Me.lblStatus.Text = Format(Recipient.PROCESSED, "G").ToString
                End If

            End If

            Dim AlertCategory As String = Request.QueryString("AlertCategory")

            LoadAlert(CurrentAlert)
            LoadRecipients(CurrentAlertID)
            LoadComments(CurrentAlertID)
            LoadAttachments(CurrentAlertID)
            LoadApproval()
            ' Defect #180

            Dim AlertRecipient As New AlertRecipient(CStr(Session("ConnString")))
            AlertRecipient.Where.ALERT_ID.Value = Me.CurrentAlertID
            AlertRecipient.Where.EMP_CODE.Value = Session("EmpCode")
            AlertRecipient.Query.Load()
            If AlertRecipient.RowCount > 0 Then
                'Set the Read_alert flag to 1
                AlertRecipient.READ_ALERT = 1
                AlertRecipient.Save()
            End If
            Response.Clear()


        End If



    End Sub


    '********************************************************************
    Private Function LoadRecipients(ByVal intAlertID As Integer)
        Try
            Dim alert As New Alert(Session("ConnString"))
            alert.LoadByPrimaryKey(Me.CurrentAlertID)
            Dim recipients As vAlertRecipientList = alert.GetRecipientList
            Dim recipientsCP As vCPAlertRecipientList = alert.GetRecipientListCP

            Me.grdRecipients.DataSource = recipients.DefaultView
            Me.grdRecipients.DataBind()
            Me.grdRecipientsCP.DataSource = recipientsCP.DefaultView
            Me.grdRecipientsCP.DataBind()

            Me.lbNEmailToRecipients.Visible = recipients.RowCount > 0

        Catch ex As Exception
            ' ShowAlert("Could not load recipients.\n" & ex.Message.ToString())
        End Try

    End Function

    Private Function LoadAlert(ByVal alert As Alert)

        Dim oAlerts As cAlerts = New cAlerts(CStr(Session("ConnString")))

        Try
            Dim DsAlert As New DataSet
            Dim DtAlertDetails As New DataTable
            DsAlert = oAlerts.GetAlert(alert.ALERT_ID)
            DtAlertDetails = DsAlert.Tables(0)
            If Not DtAlertDetails Is Nothing Then
                If DtAlertDetails.Rows.Count > 0 Then

                End If
            End If
            With alert
                'We are an Approval Alert
                If CurrentAlert.ALERT_CAT_ID = "38" Then
                    Me.lblNAlertType.Text = DtAlertDetails.Rows(0)("ALERT_TYPE_DESC")
                    If .BODY_HTML = "" Then
                        Me.lblNDetails.Text = DtAlertDetails.Rows(0)("BODY").ToString.Replace(vbCrLf, "<br />")
                    Else
                        Me.lblNDetails.Text = .BODY_HTML
                    End If

                    SwitchScreen("APPROVAL")


                    ''Add rest of code for Approval Alerts...

                Else 'Normal Alert
                    SwitchScreen("NORMAL")

                    Me.lblNAlertType.Text = DtAlertDetails.Rows(0)("ALERT_TYPE_DESC")
                    If alert.CL_CODE.Trim <> "" Then Me.lblNClientCode.Text = alert.CL_CODE & " - " & DtAlertDetails.Rows(0)("CL_NAME").ToString
                    If .BODY_HTML = "" Then
                        Me.lblNDetails.Text = DtAlertDetails.Rows(0)("BODY").ToString.Replace(vbCrLf, "<br />")
                    Else
                        Me.lblNDetails.Text = .BODY_HTML
                    End If
                    If .OFFICE_CODE.Trim <> "" Then Me.lblNOfficeCode.Text = .OFFICE_CODE & " - " & DtAlertDetails.Rows(0)("OFFICE_NAME").ToString
                    If .DIV_CODE.Trim <> "" Then Me.lblNDivisionCode.Text = .DIV_CODE & " - " & DtAlertDetails.Rows(0)("DIV_NAME").ToString

                    If .PRD_CODE.Trim <> "" Then Me.lblNProduct.Text = .PRD_CODE & " - " & DtAlertDetails.Rows(0)("PRD_DESCRIPTION").ToString
                    Me.lblNCategory.Text = DtAlertDetails.Rows(0)("CATEGORY_DISPLAY")
                    If DtAlertDetails.Rows(0)("USER_NAME").ToString() = "" And alert.s_CP_ALERT = "1" Then
                        Me.lblNGenerated.Text = Format(.GENERATED, "G") & " by " & oAlerts.GetAlertClientContact(CInt(alert.ALERT_USER))
                    Else
                        Me.lblNGenerated.Text = Format(.GENERATED, "G") & " by " & DtAlertDetails.Rows(0)("USER_NAME").ToString
                    End If
                    If .CMP_CODE.Trim <> "" Then Me.lblNCampaignCode.Text = .CMP_CODE & " - " & DtAlertDetails.Rows(0)("CMP_NAME").ToString
                    If Not .IsColumnNull(.ColumnNames.JOB_NUMBER) Then
                        If .JOB_NUMBER <> 0 Then
                            lblNJobNumber.Text = "(" & .JOB_NUMBER & ") " & DtAlertDetails.Rows(0)("JOB_DESC").ToString
                        End If
                    End If
                    If Not .IsColumnNull(.ColumnNames.JOB_COMPONENT_NBR) Then
                        If .JOB_COMPONENT_NBR <> 0 Then
                            lblNComponentNumber.Text = " (" & .JOB_COMPONENT_NBR & ") " & DtAlertDetails.Rows(0)("JOB_COMP_DESC").ToString
                        End If
                    End If
                    Select Case .PRIORITY
                        Case 1
                            Me.lblPriority.Text = "High"
                        Case 2
                            Me.lblPriority.Text = "Medium"
                        Case 3
                            Me.lblPriority.Text = "Low"
                        Case 0
                            Me.lblPriority.Text = ""
                        Case Else
                            Me.lblPriority.Text = .PRIORITY

                    End Select
                    Me.lblNSubject.Text = .SUBJECT

                End If


            End With
        Catch ex As Exception
            'Err.Raise(Err.Number, "Error: Loading Alert", Err.Description)
            ' ShowAlert("Could not load alert.\n" & ex.Message.ToString())
        End Try

    End Function
    Private Sub LoadComments(ByVal alertId As Integer)
        Try
            Dim Alert As New Alert(Session("ConnString"))
            Alert.LoadByPrimaryKey(Me.CurrentAlertID)
            Dim Comments As vAlertComments = Alert.GetCommentsView

            gvComments.DataSource = Comments.DefaultView
            gvComments.DataBind()

        Catch ex As Exception

        End Try
    End Sub
    Public Sub SwitchScreen(ByVal sType As String)

        Select Case sType.ToUpper
            Case "NORMAL"
                Me.lblNAlertType.Visible = True
                Me.lblNOfficeCode.Visible = True
                Me.lblNClientCode.Visible = True
                Me.lblNCampaignCode.Visible = True
                Me.lblNJobNumber.Visible = True
                Me.lblNDetails.Visible = True
                Me.gvComments.Visible = True
                Me.gvAttachments.Visible = True
                Me.grdRecipients.Visible = True
                Me.grdRecipientsCP.Visible = True
                Me.lbNEmailToRecipients.Visible = True
                Me.lbNDismissAlert.Visible = True
                Me.lbNAddComment.Visible = True
                Me.txtNCommentEntry.Visible = True
                Me.lblStatus.Visible = True

                Me.lbAApprove.Visible = False
                Me.lbADeny.Visible = False

            Case "APPROVAL"
                Me.lblNAlertType.Visible = True
                Me.lblNOfficeCode.Visible = False
                Me.lblNClientCode.Visible = False
                Me.lblNCampaignCode.Visible = False
                Me.lblNJobNumber.Visible = False
                Me.lblNDetails.Visible = True
                Me.gvComments.Visible = True
                Me.gvAttachments.Visible = True
                Me.grdRecipients.Visible = True
                Me.grdRecipientsCP.Visible = True
                Me.lbNEmailToRecipients.Visible = False
                Me.lbNDismissAlert.Visible = False
                Me.lbNAddComment.Visible = False
                Me.txtNCommentEntry.Visible = True

                Me.lblStatus.Visible = True
                Me.lbAApprove.Visible = False
                Me.lbADeny.Visible = False

        End Select



    End Sub

    'Private Function SendEmailAlert(ByVal intAlertID As Integer) As Boolean

    '    Dim strFrom As String
    '    Dim user As New cEmployee(CStr(Session("ConnString")))
    '    Dim UserEmail As String = user.GetEmail(CStr(Session("EmpCode")))

    '    If UserEmail = "" Then
    '        JSMessageBox("You do not have an email address in the database.  Alert was added.  No Email was sent.")
    '        Exit Function
    '    Else
    '        strFrom = UserEmail
    '    End If

    '    Dim URLwv As String
    '    Dim URLcp As String
    '    Dim csec As New cSecurity(Session("ConnString"))
    '    Dim dr As SqlClient.SqlDataReader
    '    dr = csec.getSettingsCP()
    '    If dr.HasRows = True Then
    '        Do While dr.Read
    '            URLwv = Request.Url.Scheme & "://" & dr.GetString(0)
    '            URLcp = Request.Url.Scheme & "://" & dr.GetString(1)
    '            'URLwv = Request.Url.Scheme & "://" & Request.Url.Host & "/" & dr.GetString(0)
    '            'URLcp = Request.Url.Scheme & "://" & Request.Url.Host & "/" & dr.GetString(1)
    '        Loop
    '        dr.Close()
    '    Else
    '        URLwv = Request.Url.Scheme & "://" & Request.Url.Host & "/" & Request.ApplicationPath
    '    End If

    '    Dim alert As New Alert(Session("ConnString"))

    '    Try
    '        alert.SendEmail(strFrom, URLwv, "Alert (Update) - ", True, URLcp)
    '        SendEmailAlert = True
    '    Catch ex As Exception
    '        JSMessageBox("Error: Alert Email not Sent.  Alert was added.  No Email was sent.\n " & ex.Message)
    '        'Throw New Exception("Error: Alert Email not Sent.", ex)
    '        SendEmailAlert = False
    '    End Try

    'End Function

    Private Function LoadAttachments(ByVal alertId As Integer)
        Try
            Dim alert As New Alert(Session("ConnString"))
            alert.LoadByPrimaryKey(Me.CurrentAlertID)

            Dim attachments As vAlertAttachmentList = alert.GetAttachmentList




            Dim attachmentCount As Integer = 0

            Try
                attachmentCount = alert.GetAttachmentCount

            Catch ex As Exception

            End Try

            Me.gvAttachments.DataSource = attachments.DefaultView
            gvAttachments.DataBind()
        Catch ex As Exception
            'ShowAlert("Error loading attachments.\n" & ex.Message.ToString())
            'Err.Raise(Err.Number, "Error: Loading Attachments", Err.Description)
        End Try

    End Function

    'Private Function LoadComments(ByVal intAlertID As Integer)
    '    Me.CommentsRadGrid.DataBind()
    'End Function

    'Private Function LoadRecipients(ByVal intAlertID As Integer)
    '    Try
    '        Dim alert As New Alert(Session("ConnString"))
    '        alert.LoadByPrimaryKey(Me.CurrentAlertID)
    '        Dim recipients As vAlertRecipientList = alert.GetRecipientList
    '        Dim recipientsCP As vCPAlertRecipientList = alert.GetRecipientListCP

    '        Me.grdRecipients.DataSource = recipients.DefaultView
    '        Me.grdRecipients.DataBind()
    '        Me.grdRecipientsCP.DataSource = recipientsCP.DefaultView
    '        Me.grdRecipientsCP.DataBind()

    '        Me.cmdEMail_Bottom.Enabled = recipients.RowCount > 0

    '    Catch ex As Exception
    '        ShowAlert("Could not load recipients.\n" & ex.Message.ToString())
    '    End Try

    'End Function

    Private Function LoadApproval()
        Try
            Dim PO As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
            Dim dr As SqlDataReader
            dr = PO.GetPOApprData(Session("EmpCode"), CurrentAlert.PO_NUMBER)
            If dr.HasRows = True Then
                Do While dr.Read
                    'If MiscFN.BrowserTypeIs(MiscFN.Browser_Types.Safari) = True Then
                    '    Me.TxtCommentApproval.Text = dr.GetString(5)
                    'Else
                    '    Me.ApprovalRadEditor.Html = dr.GetString(5)
                    'End If
                    Me.txtNCommentEntry.Text = dr.GetString(5)

                    If IsDBNull(dr("PO_APPROVAL_FLAG")) = False Then

                        If dr.GetBoolean(6) = True Then
                            Me.lblStatus.Text = "Approved"
                            Me.lblStatus.Visible = True
                            lbAApprove.Enabled = False
                            lbAApprove.Visible = True
                            Me.txtNCommentEntry.Visible = False
                            Me.lbNAddComment.Visible = False
                        ElseIf dr.GetBoolean(6) = False Then
                            lblStatus.Visible = False

                            lblStatus.Text = "DENIED"
                            lbADeny.Visible = True
                            lbADeny.Enabled = False
                            Me.txtNCommentEntry.Visible = False
                            Me.lbNAddComment.Visible = False
                        Else
                            lblStatus.Visible = False
                            lblStatus.Text = ""
                            Me.lbAApprove.Enabled = True
                            Me.lbADeny.Enabled = True
                            Me.lbAApprove.Visible = True
                            Me.lbADeny.Visible = True
                            Me.txtNCommentEntry.Visible = True
                            Me.lbNAddComment.Visible = True
                        End If
                    Else
                        Me.lblStatus.Visible = False
                        Me.lblStatus.Text = ""
                        Me.lbAApprove.Enabled = True
                        Me.lbADeny.Enabled = True
                        Me.lbAApprove.Visible = True
                        Me.lbADeny.Visible = True

                    End If

                    Me.lbNDismissAlert.Visible = True
                    Me.lbNEmailToRecipients.Visible = False
                Loop
            End If
        Catch ex As Exception

        End Try
    End Function

    '********************************************************************
    Private Sub lbBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        MiscFN.ResponseRedirect("~/mobile/MobileAlerts.aspx")
    End Sub

    Private Sub lbLogout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogout.Click
        Me.SignOut()
    End Sub

    Public Sub gvAttachments_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvAttachments.RowCommand
        Select Case e.CommandName
            Case "Download"
                Dim DocumentId As Integer = CInt(e.CommandArgument)
                Dim bps As Webvantage.BasePageShared
                bps.DeliverFile(DocumentId)
        End Select
    End Sub
    Private Function addComment()
        ' Just exit out if the user did not enter anything in the CommentsTextBox
        If Me.txtNCommentEntry.Text = "" Then
            Exit Function
        End If


        Try
            Dim alertComment As New AlertComment(CStr(Session("ConnString")))

            alertComment.AddNewComment(Me.CurrentAlertID, Session("UserCode"), Me.txtNCommentEntry.Text)

            LoadComments(Me.CurrentAlertID)

            ' Adding a new Comment should cause the alert to show up again on everyone's 
            ' alert pages, so it must be undismissed
            Dim AlertRecipient As New AlertRecipient(CStr(Session("ConnString")))
            AlertRecipient.Where.ALERT_ID.Value = Me.CurrentAlertID
            AlertRecipient.Query.Load()

            Do Until AlertRecipient.EOF
                AlertRecipient.SetColumnNull(AlertRecipient.ColumnNames.PROCESSED)
                AlertRecipient.SetColumnNull(AlertRecipient.ColumnNames.READ_ALERT)
                AlertRecipient.MoveNext()
            Loop

            AlertRecipient.Save()

            Dim CPAlertRecipient As New CPAlertRecipient(CStr(Session("ConnString")))
            CPAlertRecipient.Where.ALERT_ID.Value = Me.CurrentAlertID
            CPAlertRecipient.Query.Load()

            Do Until CPAlertRecipient.EOF
                CPAlertRecipient.SetColumnNull(CPAlertRecipient.ColumnNames.PROCESSED)
                CPAlertRecipient.SetColumnNull(CPAlertRecipient.ColumnNames.READ_ALERT)
                CPAlertRecipient.MoveNext()
            Loop

            CPAlertRecipient.Save()

            txtNCommentEntry.Text = ""

            LoadComments(Me.CurrentAlertID)

        Catch ex As Exception
            'Throw ex
            ' ShowAlert("Could add comment.\n" & ex.Message.ToString())
        End Try

    End Function
    Private Function UpdateRecipients()
        Try
            Dim alertList As New AlertRecipient(Session("ConnString"))
            Dim alertListCP As New CPAlertRecipient(Session("ConnString"))
            For i As Integer = 0 To Me.grdRecipients.Rows.Count - 1
                'Dim cb As CheckBox = Me.grdRecipients.Rows(i).Cells(1).Text
                alertList = New AlertRecipient(Session("ConnString"))
                alertList.Where.ALERT_ID.Value = Me.CurrentAlertID
                alertList.Where.EMP_CODE.Value = Me.grdRecipients.Rows(i).Cells(0).Text
                alertList.Query.Load()
                If alertList.RowCount > 0 Then
                    'Set the Read_alert flag to NULL
                    alertList.s_READ_ALERT = ""
                    alertList.s_PROCESSED = ""
                    alertList.s_CURRENT_RCPT = ""
                    alertList.Save()
                End If
            Next
            'For i As Integer = 0 To Me.grdRecipientsCP.Rows.Count - 1
            '    'Dim cb As CheckBox = Me.grdRecipientsCP.Rows(i).FindControl("cbSelectRecpCP")
            '    Dim hfCP As System.Web.UI.WebControls.HiddenField
            '    hfCP = Me.grdRecipientsCP.Rows(i).FindControl("hfCDPID")
            '    alertListCP = New CPAlertRecipient(Session("ConnString"))
            '    alertListCP.Where.ALERT_ID.Value = Me.CurrentAlertID
            '    alertListCP.Where.CDP_CONTACT_ID.Value = hfCP.Value
            '    alertListCP.Query.Load()
            '    If alertListCP.RowCount > 0 Then
            '        If cb.Checked = True Then
            '            'Set the Read_alert flag to NULL
            '            alertListCP.s_READ_ALERT = ""
            '            alertListCP.s_PROCESSED = ""
            '            alertListCP.s_CURRENT_RCPT = ""
            '        Else
            '            alertListCP.CURRENT_RCPT = 1
            '        End If
            '        alertListCP.Save()
            '    End If
            'Next
        Catch ex As Exception

        End Try
    End Function
    Private Function SendEmailAlert(ByVal AlertID As Integer, ByVal includeAttachments As Boolean, ByVal includeComments As Boolean) As Boolean
        Try

            Dim eso As New EmailSessionObject(HttpContext.Current.Session("ConnString"), _
                                              HttpContext.Current.Session("UserCode"), _
                                              Me._Session, _
                                              HttpContext.Current.Session("WebvantageURL"), _
                                              HttpContext.Current.Session("ClientPortalURL"))

            With eso

                .AlertId = AlertID
                .Subject = "[Alert Updated]"

            End With

            eso.SendEmailOnSeparateThread()
            Return True


        Catch ex As Exception

            SendEmailAlert = False

        End Try
    End Function

    Private Sub JSMessageBox(ByVal Message As String)
        Dim strScript As String
        strScript = "<script type=""text/javascript"">alert('" & Message & "')</script>"
        If Not Page.IsStartupScriptRegistered("Webvantage") Then
            Page.RegisterStartupScript("Webvantage", strScript)
        End If
    End Sub

    Private Sub gvAttachments_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvAttachments.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim Alert As New Alert(Session("ConnString"))
            Alert.LoadByPrimaryKey(Me.CurrentAlertID)
            Dim IconCell As Integer = 0
            Dim LinkButtonCell As Integer = 1
            Dim SizeCell As Integer = 2
            Dim DocumentIconImageButton As System.Web.UI.WebControls.ImageButton = e.Row.Cells(IconCell).FindControl("DocumentIconImageButton")
            Dim DownloadLinkButton As System.Web.UI.WebControls.LinkButton = e.Row.Cells(LinkButtonCell).FindControl("DownloadLinkButton")

            Select Case e.Row.DataItem("MimeType")
                Case "URL"
                    DownloadLinkButton.Text = e.Row.DataItem("RealFileName")
                    DocumentIconImageButton.ImageUrl = "~/images/document_url.png"
                    DownloadLinkButton.Attributes.Add("onclick", " window.open('" & e.Row.DataItem("REPOSITORY_FILENAME") & "');")
                    Dim Description As String = ""

                    Try
                        Description = e.Row.DataItem("DESCRIPTION")
                    Catch ex As Exception
                        Description = ""
                    End Try
                    If Description <> "" Then
                        DownloadLinkButton.ToolTip = e.Row.DataItem("RealFileName") & " - " & Description
                    Else
                        DownloadLinkButton.ToolTip = e.Row.DataItem("RealFileName")
                    End If
                    e.Row.Cells(SizeCell).Text = "N/A"


                Case Else
                    Dim FileSize As Double = e.Row.DataItem("FILE_SIZE") / 1000
                    Select Case FileSize
                        Case Is < 1
                            e.Row.Cells(SizeCell).Text = "< 1K"
                        Case 0 To 999
                            e.Row.Cells(SizeCell).Text = FileSize.ToString("#,###") & " KB"
                        Case Is >= 1000
                            e.Row.Cells(SizeCell).Text = (FileSize / 1000).ToString("#,###.##") & " MB"
                    End Select
                    DownloadLinkButton.Text = e.Row.DataItem("RealFileName")
                    DownloadLinkButton.CommandArgument = e.Row.DataItem("DOCUMENT_ID")
                    DownloadLinkButton.CommandName = "Download"
                    Try
                        DownloadLinkButton.ToolTip = e.Row.DataItem("DESCRIPTION")
                    Catch ex As Exception
                        DownloadLinkButton.ToolTip = "No description"
                    End Try

                    'Choose and icon to show for thisdocument 
                    Dim IconPath As String

                    Select Case e.Row.DataItem("MimeType")
                        Case "application/msword"
                            IconPath = "document_word.png"
                        Case "application/mspowerpoint", "application/vnd.ms-powerpoint"
                            IconPath = "document_powerpoint.png"
                        Case "application/msproject", "application/vnd.ms-msproject"
                            IconPath = "document_project.png"
                        Case "application/pdf"
                            IconPath = "document_pdf.png"
                        Case "application/msexcel", "application/vnd.ms-excel"
                            IconPath = "document_excel.png"
                        Case "image/bmp"
                            IconPath = "document_image.png"
                        Case "image/gif"
                            IconPath = "document_image.png"
                        Case "image/jpeg", "image/pjpeg"
                            IconPath = "document_jpg.png"
                        Case "image/x-png"
                            IconPath = "document_png.png"
                        Case "image/tiff"
                            IconPath = "document_tif.png"
                        Case "text/plain"
                            IconPath = "document_text.png"
                        Case "image/x-photoshop"
                            IconPath = "document_photoshop.png"
                        Case "application/illustrator"
                            IconPath = "document_illustrator.png"
                        Case "URL"
                            IconPath = "document_url.png"
                        Case "application/x-zip-compressed", "application/zip"
                            IconPath = "document_zip.png"
                        Case Else
                            IconPath = "document_generic.png"
                    End Select
                    DocumentIconImageButton.ImageUrl = "~/images/" & IconPath
                    DocumentIconImageButton.CommandArgument = e.Row.DataItem("DOCUMENT_ID")
                    DocumentIconImageButton.CommandName = "Download"

            End Select

            e.Row.Attributes.Add("DocumentId", e.Row.DataItem("DOCUMENT_ID"))


            Dim by As String = e.Row.Cells(5).Text.Trim
            Dim cp As String = Alert.s_CP_ALERT
            Try
                If by = "&nbsp;" Then
                    Dim oAlerts As New cAlerts(Session("ConnString"))
                    Dim str As String = oAlerts.GetAlertClientContact(CInt(e.Row.Cells(7).Text))
                    e.Row.Cells(5).Text = str
                End If
            Catch ex As Exception
                'Me.LblMSG.Text = ex.Message.Trim
            End Try

        End If
    End Sub

    Private Sub gvComments_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvComments.RowDataBound
        Dim Alert As New Alert(Session("ConnString"))
        Alert.LoadByPrimaryKey(Me.CurrentAlertID)
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim by As String = e.Row.Cells(3).Text.Trim
            Dim cp As String = Alert.s_CP_ALERT
            Try
                If by = "&nbsp;" Then
                    Dim oAlerts As New cAlerts(Session("ConnString"))
                    Dim str As String = oAlerts.GetAlertClientContact(CInt(e.Row.Cells(5).Text))
                    e.Row.Cells(3).Text = str
                End If
            Catch ex As Exception
                'Me.LblMSG.Text = ex.Message.Trim
            End Try
        End If
    End Sub

    Protected Sub lbNDismissAlert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbNDismissAlert.Click
        Try

            DismissAlert()
            ' Redirect the user back 
            MiscFN.ResponseRedirect("~/mobile/mobilealerts.aspx")
        Catch ex As Exception
            ' ShowAlert("Could not dismiss alert.\nPlease check the repository settings.\n" & ex.Message.ToString())
        End Try
    End Sub
    Private Sub DismissAlert()
        Try
            Dim AlertRecipient As New AlertRecipient(CStr(Session("ConnString")))
            ' Load the row from ALERT_RCPT
            AlertRecipient.Where.ALERT_ID.Value = Me.CurrentAlertID
            AlertRecipient.Where.EMP_CODE.Value = Session("EmpCode")
            AlertRecipient.Query.Load()

            If AlertRecipient.RowCount > 0 Then
                'Set the PROCESSED date to now
                AlertRecipient.PROCESSED = Date.Now
                AlertRecipient.Save()
            Else
                ' This seems to happen when a user created an alert (Diary) with no recipients.
                AlertRecipient.AddNew()
                AlertRecipient.PROCESSED = Date.Now
                AlertRecipient.EMP_CODE = Session("EmpCode")
                AlertRecipient.ALERT_RCPT_ID = 1
                AlertRecipient.ALERT_ID = Me.CurrentAlertID
                AlertRecipient.Save()
            End If
        Catch ex As Exception
            ' ShowAlert("Could not dismiss alert.\nPlease check the repository settings.\n" & ex.Message.ToString())
        End Try
    End Sub

    Protected Sub lbNAddComment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbNAddComment.Click
        addComment()

    End Sub

    Protected Sub lbNEmailToRecipients_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbNEmailToRecipients.Click
        Try
            UpdateRecipients()
            SendEmailAlert(Me.CurrentAlertID, True, False)
            FillAlertView()
            'Me.JSMessageBox("All of the email recipients have been alerted.")
        Catch ex As Exception
            ' Me.JSMessageBox("Error occured sending mail." & ex.Message)
        End Try

    End Sub

    Private Sub lbAApprove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbAApprove.Click
        addCommentApproval(True)
        DismissAlert()
        LoadComments(Me.CurrentAlertID)
    End Sub
    Private Sub lbADeny_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbADeny.Click
        addCommentApproval(False)
        DismissAlert()
        LoadComments(Me.CurrentAlertID)
    End Sub
    Private Function sendAlertApproval(ByVal PONum As Integer, ByVal approve As Boolean, ByVal notes As String)
        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Dim FxAlert As New AdvantageFramework.Database.Entities.Alert
            Try
                'Dim Alert As New Alert(Session("ConnString"))
                Dim alertComment As New AlertComment(Session("ConnString"))
                Dim POHeader As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
                POHeader.Select_POHeader(PONum, "")
                Dim dr As SqlDataReader
                Dim strBody As String
                Dim usercode As String
                Dim username As String

                With FxAlert

                    .AlertTypeID = 3 'Approvals
                    .AlertCategoryID = 39

                    If approve = True Then
                        .Subject = "PO Approved - " & POHeader.Vendor_Name & " - " & POHeader.PO_Description
                    Else
                        .Subject = "PO Approval Denied - " & POHeader.Vendor_Name & " - " & POHeader.PO_Description
                    End If
                    If POHeader.PO_Revision > 0 Then
                        .Subject &= " Revision: " & POHeader.PO_Revision
                    End If

                    strBody &= "--------------------------------------" & vbCrLf
                    strBody &= "Purchase Order Details:" & vbCrLf
                    strBody &= "--------------------------------------" & vbCrLf
                    'If approve = True Then

                    strBody &= "PO Number: <a href='purchaseorder.aspx?po_number=" & AdvantageFramework.StringUtilities.RijndaelSimpleEncryptPO(PONum.ToString()) & "&pagemode=edit'>Click here to view this Purchase Order.</a>" & vbCrLf
                    ' Else
                    'strBody &= "PO Number: Denied" & vbCrLf
                    'End If
                    strBody &= "PO Description: " & POHeader.PO_Description & vbCrLf
                    strBody &= "Issued By: " & POHeader.Issue_By_Emp_Name & vbCrLf
                    strBody &= "Issued To: " & POHeader.Vendor_Name & vbCrLf
                    strBody &= "Total PO Amount: " & POHeader.PO_Total & vbCrLf
                    strBody &= "Employee's Limit: " & POHeader.Get_PO_Emp_Limit(1, POHeader.Issue_By_Emp_Code, usercode, username) & vbCrLf
                    If POHeader.PO_Revision > 0 Then
                        strBody &= "PO Revision: " & POHeader.PO_Revision & vbCrLf
                    End If
                    strBody &= "Notes: " & notes & vbCrLf

                    dr = POHeader.GetPOApprDataByPO(PONum)
                    If dr.HasRows = True Then
                        strBody &= "" & vbCrLf
                        strBody &= "Approvals needed: " & vbCrLf
                        Do While dr.Read
                            strBody &= dr.GetString(6) & ": "
                            If IsDBNull(dr("PO_APPROVAL_FLAG")) = False Then
                                If dr.GetBoolean(5) = True Then
                                    strBody &= "Approved" & vbCrLf
                                ElseIf dr.GetBoolean(5) = False Then
                                    strBody &= "Denied" & vbCrLf
                                Else
                                    strBody &= "Pending" & vbCrLf
                                End If
                            Else
                                strBody &= "Pending" & vbCrLf
                            End If
                        Loop
                    End If

                    .Body = strBody

                    '.BODY_HTML = Me.BodyRadEditor.Html
                    .GeneratedDate = Now
                    .LastUpdated = .GeneratedDate
                    .PriorityLevel = 3
                    .PONumber = CInt(PONum)
                    .EmployeeCode = Session("EmpCode")
                    .AlertLevel = "NA"
                    .UserCode = Session("UserCode")

                End With
                If AdvantageFramework.Database.Procedures.Alert.Insert(DbContext, FxAlert) = True Then

                    Dim Alert As New Alert(Session("ConnString"))
                    Alert.LoadByPrimaryKey(FxAlert.ID)
                    If approve = True Then
                        alertComment.AddNewComment(Alert.ALERT_ID, Session("UserCode"), "Approved - " & Me.txtNCommentEntry.Text)
                    Else
                        alertComment.AddNewComment(Alert.ALERT_ID, Session("UserCode"), "Denied - " & Me.txtNCommentEntry.Text)
                    End If
                    Alert.AddAlertRecipient(POHeader.Issue_By_Emp_Code)
                    Return Alert.ALERT_ID

                Else

                    'Me.ShowMessage("Alert failed to save")

                End If
            Catch ex As Exception
                ' ShowAlert("Could add alert.\n" & ex.Message.ToString())
            End Try

        End Using

    End Function
    Private Function addCommentApproval(ByVal approve As Boolean)
        Try
            Dim Alert As New Alert(Session("ConnString"))
            Alert.LoadByPrimaryKey(Me.CurrentAlertID)

            Dim PO As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
            Dim alertComment As New AlertComment(Session("ConnString"))
            Dim newrev As Integer
            Dim dr As SqlDataReader
            dr = PO.GetPOApprData(Session("EmpCode"), Alert.PO_NUMBER)
            Dim alertid As Integer
            If dr.HasRows = True Then
                Do While dr.Read
                    If approve = True Then
                        alertComment.AddNewComment(Me.CurrentAlertID, Session("UserCode"), "Approved - " & Me.txtNCommentEntry.Text)
                        PO.UpdatePOApproval(dr.GetInt32(0), dr.GetString(1), dr.GetInt16(2), dr.GetInt32(3), True, Session("UserCode"), Now, Me.txtNCommentEntry.Text)
                        alertid = Me.sendAlertApproval(dr.GetInt32(0), True, Me.txtNCommentEntry.Text)
                        If alertid > 0 Then
                            Me.SendEmailAlert(alertid, True, False)
                        End If

                        Me.lblStatus.Visible = True
                        Me.lblStatus.Text = "APPROVED"
                        Me.lbAApprove.Enabled = False
                        Me.lbADeny.Enabled = True

                    Else
                        alertComment.AddNewComment(Me.CurrentAlertID, Session("UserCode"), "Denied - " & Me.txtNCommentEntry.Text)
                        PO.UpdatePOApproval(dr.GetInt32(0), dr.GetString(1), dr.GetInt16(2), dr.GetInt32(3), False, Session("UserCode"), Now, Me.txtNCommentEntry.Text)
                        alertid = Me.sendAlertApproval(dr.GetInt32(0), False, Me.txtNCommentEntry.Text)
                        If alertid > 0 Then
                            Me.SendEmailAlert(alertid, True, False)
                        End If

                        'newrev = PO.Increment_PO_Revision(1, CurrentAlert.PO_NUMBER)
                        Me.lblStatus.Visible = True
                        Me.lblStatus.Text = "DENIED"
                        Me.lbADeny.Enabled = False
                        Me.lbAApprove.Enabled = True

                    End If
                Loop
            Else
                'ShowAlert("Approval has been resubmitted or canceled!")
            End If

            txtNCommentEntry.Text = ""

        Catch ex As Exception
            'Throw ex
            'ShowAlert("Could add comment.\n" & ex.Message.ToString())
        End Try

    End Function

    Protected Sub gvAttachments_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles gvAttachments.SelectedIndexChanged

    End Sub
End Class