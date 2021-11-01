Public Class Alert_Html
    Inherits System.Web.UI.Page

    Private AlertId As Integer = 0
    Private AlertLevelCode As String = ""
    Private AlertTypeId As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not Request.QueryString("a") Is Nothing Then
                Me.AlertId = CType(Request.QueryString("a"), Integer)
            End If
        Catch ex As Exception
            AlertId = 0
        End Try

        If Me.AlertId > 0 Then
            Dim DsMain As New DataSet
            Dim DtAlert As New DataTable
            Dim DtAlertComments As New DataTable
            Dim DtAlertAssignment As New DataTable
            Dim DtMyAlert As New DataTable
            Dim DtRecipients As New DataTable
            Dim DtAttachments As New DataTable

            Dim a As New cAlerts()
            DsMain = a.GetAlert(Me.AlertId)

            If Not DsMain Is Nothing Then

                If DsMain.Tables.Count > 0 Then

                    DtAlert = DsMain.Tables(0)
                    DtAlertComments = DsMain.Tables(1)
                    DtAlertAssignment = DsMain.Tables(2)
                    DtMyAlert = DsMain.Tables(3)
                    DtRecipients = DsMain.Tables(4)
                    DtAttachments = DsMain.Tables(5)

                    Try 'Set main alert items

                        If Not DtAlert Is Nothing Then

                            If DtAlert.Rows.Count > 0 Then

                                Try
                                    If IsDBNull(DtAlert.Rows(0)("ALERT_LEVEL")) = False Then
                                        Me.AlertLevelCode = DtAlert.Rows(0)("ALERT_LEVEL").ToString()
                                    End If
                                Catch ex As Exception
                                End Try
                                Me.SetLevel()
                                Try
                                    If IsDBNull(DtAlert.Rows(0)("ALERT_TYPE_ID")) = False Then
                                        Me.AlertTypeId = CType(DtAlert.Rows(0)("ALERT_TYPE_ID"), Integer)
                                    End If
                                Catch ex As Exception
                                    Me.AlertTypeId = 0
                                End Try
                                Try
                                    If IsDBNull(DtAlert.Rows(0)("ALERT_LEVEL_DISPLAY")) = False Then
                                        Me.LblHeader.Text = DtAlert.Rows(0)("ALERT_LEVEL_DISPLAY").ToString()
                                    End If
                                Catch ex As Exception
                                End Try
                                Try
                                    If IsDBNull(DtAlert.Rows(0)("ALERT_TYPE_DESC")) = False Then
                                        Me.LblAlertType.Text = DtAlert.Rows(0)("ALERT_TYPE_DESC").ToString()
                                    End If
                                Catch ex As Exception
                                End Try
                                Try
                                    If IsDBNull(DtAlert.Rows(0)("GENERATED")) = False Then
                                        Me.LblGenerated.Text = LoGlo.FormatDateTime(DtAlert.Rows(0)("GENERATED")) & " by " & DtAlert.Rows(0)("USER_NAME").ToString()
                                    End If
                                Catch ex As Exception
                                End Try

                                Try
                                    If IsDBNull(DtAlert.Rows(0)("ID")) = False Then
                                        LabelAlertID.Text = DtAlert.Rows(0)("ID").ToString
                                    End If
                                Catch ex As Exception
                                End Try

                                Me.TrOffice.Visible = False
                                Me.TrClient.Visible = False
                                Me.TrDivision.Visible = False
                                Me.TrProduct.Visible = False
                                Me.TrCampaign.Visible = False
                                Me.TrEstimate.Visible = False
                                Me.TrEstimateComponent.Visible = False
                                Me.TrJob.Visible = False
                                Me.TrComponent.Visible = False
                                Me.TrTask.Visible = False
                                Me.TrCategory.Visible = False
                                Me.TrPriority.Visible = False
                                Me.TrDueDate.Visible = False
                                Me.TrTimeDue.Visible = False
                                Me.TrVersion.Visible = False
                                Me.TrBuild.Visible = False
                                Me.TrSubject.Visible = False
                                Me.TrDescription.Visible = False

                                Try
                                    If IsDBNull(DtAlert.Rows(0)("OFFICE_DISPLAY")) = False Then
                                        Me.LblOffice.Text = DtAlert.Rows(0)("OFFICE_DISPLAY").ToString()
                                        Me.TrOffice.Visible = True
                                    End If
                                Catch ex As Exception
                                End Try
                                Try
                                    If IsDBNull(DtAlert.Rows(0)("CLIENT_DISPLAY")) = False Then
                                        Me.LblClient.Text = DtAlert.Rows(0)("CLIENT_DISPLAY").ToString()
                                        Me.TrClient.Visible = True
                                    End If
                                Catch ex As Exception
                                End Try
                                Try
                                    If IsDBNull(DtAlert.Rows(0)("DIVISION_DISPLAY")) = False Then
                                        Me.LblDivision.Text = DtAlert.Rows(0)("DIVISION_DISPLAY").ToString()
                                        Me.TrDivision.Visible = True
                                    End If
                                Catch ex As Exception
                                End Try
                                Try
                                    If IsDBNull(DtAlert.Rows(0)("PRODUCT_DISPLAY")) = False Then
                                        Me.LblProduct.Text = DtAlert.Rows(0)("PRODUCT_DISPLAY").ToString()
                                        Me.TrProduct.Visible = True
                                    End If
                                Catch ex As Exception
                                End Try
                                Try
                                    If IsDBNull(DtAlert.Rows(0)("CAMPAIGN_DISPLAY")) = False Then
                                        Me.LblCampaign.Text = DtAlert.Rows(0)("CAMPAIGN_DISPLAY").ToString()
                                        Me.TrCampaign.Visible = True
                                    End If
                                Catch ex As Exception
                                End Try
                                Try
                                    If IsDBNull(DtAlert.Rows(0)("ESTIMATE_DISPLAY")) = False Then
                                        Me.LblEstimate.Text = DtAlert.Rows(0)("ESTIMATE_DISPLAY").ToString()
                                        Me.TrEstimate.Visible = True
                                    End If
                                Catch ex As Exception
                                End Try
                                Try
                                    If IsDBNull(DtAlert.Rows(0)("ESTIMATE_COMPONENT_DISPLAY")) = False Then
                                        Me.LblEstimateComponent.Text = DtAlert.Rows(0)("ESTIMATE_COMPONENT_DISPLAY").ToString()
                                        Me.TrEstimateComponent.Visible = True
                                    End If
                                Catch ex As Exception
                                End Try
                                Try
                                    If IsDBNull(DtAlert.Rows(0)("JOB_DISPLAY")) = False Then
                                        Me.LblJob.Text = DtAlert.Rows(0)("JOB_DISPLAY").ToString()
                                        Me.TrJob.Visible = True
                                    End If
                                Catch ex As Exception
                                End Try
                                Try
                                    If IsDBNull(DtAlert.Rows(0)("JOB_COMPONENT_DISPLAY")) = False Then
                                        Me.LblComponent.Text = DtAlert.Rows(0)("JOB_COMPONENT_DISPLAY").ToString()
                                        Me.TrComponent.Visible = True
                                    End If
                                Catch ex As Exception
                                End Try
                                Try
                                    If IsDBNull(DtAlert.Rows(0)("TASK_FUNCTION_DISPLAY")) = False Then
                                        Me.LblTask.Text = DtAlert.Rows(0)("TASK_FUNCTION_DISPLAY").ToString()
                                        Me.TrTask.Visible = True
                                    End If
                                Catch ex As Exception
                                End Try
                                Try
                                    If IsDBNull(DtAlert.Rows(0)("CATEGORY_DISPLAY")) = False Then
                                        Me.LblCategory.Text = DtAlert.Rows(0)("CATEGORY_DISPLAY").ToString()
                                        Me.TrCategory.Visible = True
                                    End If
                                Catch ex As Exception
                                End Try
                                Try
                                    If IsDBNull(DtAlert.Rows(0)("PRIORITY_DISPLAY")) = False Then
                                        Me.LblPriority.Text = DtAlert.Rows(0)("PRIORITY_DISPLAY").ToString()
                                        Me.TrPriority.Visible = True
                                    End If
                                Catch ex As Exception
                                End Try
                                Try
                                    If IsDBNull(DtAlert.Rows(0)("DUE_DATE")) = False Then
                                        Me.LblDueDate.Text = LoGlo.FormatDateTime(DtAlert.Rows(0)("DUE_DATE"), False)
                                        Me.TrDueDate.Visible = True
                                    End If
                                Catch ex As Exception
                                End Try
                                Try
                                    If IsDBNull(DtAlert.Rows(0)("TIME_DUE")) = False Then
                                        Me.LblTimeDue.Text = DtAlert.Rows(0)("TIME_DUE").ToString()
                                        Me.TrTimeDue.Visible = True
                                    End If
                                Catch ex As Exception
                                End Try


                                Try
                                    If IsDBNull(DtAlert.Rows(0)("VERSION_DISPLAY")) = False Then
                                        Me.LabelVersion.Text = DtAlert.Rows(0)("VERSION_DISPLAY").ToString()
                                        Me.TrVersion.Visible = True
                                    End If
                                Catch ex As Exception
                                End Try
                                Try
                                    If IsDBNull(DtAlert.Rows(0)("BUILD_DISPLAY")) = False Then
                                        Me.LabelBuild.Text = DtAlert.Rows(0)("BUILD_DISPLAY").ToString()
                                        Me.TrBuild.Visible = True
                                    End If
                                Catch ex As Exception
                                End Try



                                Try
                                    If IsDBNull(DtAlert.Rows(0)("SUBJECT")) = False Then
                                        Me.LblSubject.Text = DtAlert.Rows(0)("SUBJECT").ToString()
                                        Me.TrSubject.Visible = True
                                    End If
                                Catch ex As Exception
                                End Try
                                ' Do we have HTML to show? If so, show it, if Not, shot the plain text.
                                Dim BodyText As String = ""
                                Dim BodyHTML As String = ""
                                Try
                                    If IsDBNull(DtAlert.Rows(0)("BODY")) = False Then
                                        BodyText = DtAlert.Rows(0)("BODY").ToString()
                                    End If
                                Catch ex As Exception
                                    BodyText = ""
                                End Try
                                Try
                                    If IsDBNull(DtAlert.Rows(0)("BODY_HTML")) = False Then
                                        BodyHTML = DtAlert.Rows(0)("BODY_HTML").ToString()
                                    End If
                                Catch ex As Exception
                                    BodyHTML = ""
                                End Try

                                BodyText = BodyText.Replace(AdvantageFramework.AlertSystem.WebvantageAlertLinkVerbiage, "")
                                BodyHTML = BodyHTML.Replace(AdvantageFramework.AlertSystem.WebvantageAlertLinkVerbiage, "")

                                BodyText = BodyText.Replace(AdvantageFramework.AlertSystem.WebvantageAssignmentLinkVerbiage, "")
                                BodyHTML = BodyHTML.Replace(AdvantageFramework.AlertSystem.WebvantageAssignmentLinkVerbiage, "")

                                BodyText = BodyText.Replace(AdvantageFramework.AlertSystem.WebvantageWithClientPortalAlertLinkVerbiage, "")
                                BodyHTML = BodyHTML.Replace(AdvantageFramework.AlertSystem.WebvantageWithClientPortalAlertLinkVerbiage, "")

                                BodyText = BodyText.Replace(AdvantageFramework.AlertSystem.WebvantageWithClientPortalAssignmentLinkVerbiage, "")
                                BodyHTML = BodyHTML.Replace(AdvantageFramework.AlertSystem.WebvantageWithClientPortalAssignmentLinkVerbiage, "")

                                BodyText = BodyText.Replace(AdvantageFramework.AlertSystem.ClientPortalAlertLinkVerbiage, "")
                                BodyHTML = BodyHTML.Replace(AdvantageFramework.AlertSystem.ClientPortalAlertLinkVerbiage, "")

                                BodyText = BodyText.Replace(AdvantageFramework.AlertSystem.ClientPortalAssignmentLinkVerbiage, "")
                                BodyHTML = BodyHTML.Replace(AdvantageFramework.AlertSystem.ClientPortalAssignmentLinkVerbiage, "")

                                If BodyHTML = "" Then
                                    BodyText = BodyText.Replace(Environment.NewLine, "<br />")
                                    Me.LblDescription.Text = BodyText.Trim()
                                Else
                                    Me.LblDescription.Text = BodyHTML.Trim()
                                End If
                                If Me.LblDescription.Text <> "" Then
                                    Me.TrDescription.Visible = True
                                End If
                            End If
                        End If
                    Catch ex As Exception
                        'Cant get alert data
                    End Try
                    'get details specific to me
                    Try
                        If Not DtMyAlert Is Nothing Then
                            If DtMyAlert.Rows.Count > 0 Then
                                If IsDBNull(DtMyAlert.Rows(0)("PROCESSED")) = False Then
                                    Me.LblDismissed.Text = LoGlo.FormatDateTime(CType(DtMyAlert.Rows(0)("PROCESSED"), DateTime).ToLongDateString()) & "  (" & LoGlo.FormatDateTime(DtMyAlert.Rows(0)("PROCESSED")) & ")"
                                Else
                                    Me.TrDismissed.Visible = False
                                End If
                            End If
                        Else
                            Me.TrDismissed.Visible = False
                        End If
                    Catch ex As Exception
                        Me.TrDismissed.Visible = False
                    End Try
                    'Set comments
                    Try
                        If Not DtAlertComments Is Nothing Then
                            If DtAlertComments.Rows.Count > 0 Then
                                Me.TblComments.Visible = True
                                Me.TrComments.Visible = True
                                For i As Integer = 0 To DtAlertComments.Rows.Count - 1
                                    Dim s As String = ""
                                    Try
                                        If IsDBNull(DtAlertComments.Rows(i)("Comment")) = False Then
                                            s = DtAlertComments.Rows(i)("Comment").ToString().Replace(Environment.NewLine, "<br />").Trim()
                                        End If
                                    Catch ex As Exception
                                        s = ""
                                    End Try
                                    If s <> "" Then
                                        Try
                                            Dim sb As New System.Text.StringBuilder
                                            With sb
                                                .Append("<li>")
                                                .Append(s)
                                                If s.IndexOf("changed from:") = -1 And s.IndexOf("Description changed") = -1 Then
                                                    .Append("<br/>")
                                                End If
                                                .Append("&nbsp;&nbsp;&nbsp;&nbsp;-&nbsp;")
                                                '.Append("<strong>")
                                                .Append(DtAlertComments.Rows(i)("EmployeeFullName").ToString())
                                                '.Append("</strong>")
                                                .Append("&nbsp;")
                                                Try
                                                    If IsDBNull(DtAlertComments.Rows(i)("CustodyEndDate")) = False Then
                                                        If CDate(DtAlertComments.Rows(i)("GeneratedDate")).Date = CDate(DtAlertComments.Rows(i)("CustodyEndDate")).Date Then
                                                            .Append(LoGlo.FormatDateTime(DtAlertComments.Rows(i)("GeneratedDate")) & " - " & CDate(LoGlo.FormatDateTime(DtAlertComments.Rows(i)("CustodyEndDate"))).ToLongTimeString)
                                                        Else
                                                            .Append(LoGlo.FormatDateTime(DtAlertComments.Rows(i)("GeneratedDate")) & " - " & LoGlo.FormatDateTime(DtAlertComments.Rows(i)("CustodyEndDate")))
                                                        End If
                                                    Else
                                                        .Append(LoGlo.FormatDateTime(DtAlertComments.Rows(i)("GeneratedDate")))
                                                    End If

                                                Catch ex As Exception
                                                End Try
                                                .Append("</li>")
                                            End With
                                            Dim tr As New System.Web.UI.HtmlControls.HtmlTableRow
                                            Dim td1 As New System.Web.UI.HtmlControls.HtmlTableCell
                                            Dim td2 As New System.Web.UI.HtmlControls.HtmlTableCell
                                            With td1
                                                .Width = "4%"
                                                .InnerHtml = "&nbsp;"
                                            End With
                                            With td2
                                                .Width = "96%"
                                                .InnerHtml = sb.ToString()
                                                .Attributes.Add("align", "justify")
                                            End With
                                            With tr.Cells
                                                .Add(td1)
                                                .Add(td2)
                                            End With
                                            Me.TblComments.Rows.Add(tr)
                                        Catch ex As Exception
                                        End Try
                                    End If
                                Next
                            Else
                                Me.TblComments.Visible = False
                                Me.TrComments.Visible = False
                            End If
                        Else
                            Me.TblComments.Visible = False
                            Me.TrComments.Visible = False
                        End If
                    Catch ex As Exception
                        'Cant get comments
                    End Try

                    Dim IsAssignment As Boolean = False
                    'assignment:
                    Try
                        If Not DtAlertAssignment Is Nothing Then

                            If DtAlertAssignment.Rows.Count > 0 Then

                                IsAssignment = True

                                Me.TrAlertAssignmentHdr.Visible = True
                                Me.TrWorkflowTemplate.Visible = True
                                Me.TrState.Visible = True
                                Me.TrAssignTo.Visible = True
                                Try
                                    If IsDBNull(DtAlertAssignment.Rows(0)("ALERT_NOTIFY_NAME")) = False Then
                                        Me.LblWorkflowTemplate.Text = DtAlertAssignment.Rows(0)("ALERT_NOTIFY_NAME").ToString()
                                    End If
                                Catch ex As Exception
                                End Try
                                Try
                                    If IsDBNull(DtAlertAssignment.Rows(0)("ALERT_STATE_NAME")) = False Then
                                        Me.LblState.Text = DtAlertAssignment.Rows(0)("ALERT_STATE_NAME").ToString()
                                    End If
                                Catch ex As Exception
                                End Try
                                Try
                                    If IsDBNull(DtAlertAssignment.Rows(0)("ASSIGN_EMP_FML")) = False Then
                                        Me.LblAssignTo.Text = DtAlertAssignment.Rows(0)("ASSIGN_EMP_FML").ToString()
                                    End If
                                Catch ex As Exception
                                End Try
                            Else
                                Me.TrAlertAssignmentHdr.Visible = False
                                Me.TrWorkflowTemplate.Visible = False
                                Me.TrState.Visible = False
                                Me.TrAssignTo.Visible = False
                            End If
                        Else
                            Me.TrAlertAssignmentHdr.Visible = False
                            Me.TrWorkflowTemplate.Visible = False
                            Me.TrState.Visible = False
                            Me.TrAssignTo.Visible = False
                        End If
                    Catch ex As Exception
                        'can't get assignment
                    End Try

                    If IsAssignment = True Then

                        Me.LblHeader.Text &= " Assignment:  "

                    Else

                        Me.LblHeader.Text &= " Alert:  "

                    End If

                    Me.LblHeader.Text &= Me.LblSubject.Text

                    'recipients
                    Try
                        If Not DtRecipients Is Nothing Then
                            If DtRecipients.Rows.Count > 0 Then
                                Me.TrRecipientsHdr.Visible = True
                                Me.TrRecipients.Visible = True
                                Dim SbRecipients As New System.Text.StringBuilder
                                For j As Integer = 0 To DtRecipients.Rows.Count - 1
                                    With SbRecipients
                                        .Append(DtRecipients.Rows(j)("UserName").ToString())
                                        .Append(", ")
                                    End With
                                Next
                                Me.LblRecipients.Text = MiscFN.RemoveTrailingDelimiter(SbRecipients.ToString(), ",")
                            Else
                                Me.TrRecipientsHdr.Visible = False
                                Me.TrRecipients.Visible = False
                            End If
                        Else
                            Me.TrRecipientsHdr.Visible = False
                            Me.TrRecipients.Visible = False
                        End If
                    Catch ex As Exception
                        'can't get recipients
                    End Try

                    'attachments?
                    Try
                        If Not DtAttachments Is Nothing Then
                            If DtAttachments.Rows.Count > 0 Then
                                Me.TrAttachmentsHdr.Visible = True
                                Me.TrAttachmentsTable.Visible = True
                                Me.TblAttachments.Visible = True
                                For k As Integer = 0 To DtAttachments.Rows.Count - 1
                                    Try
                                        Dim TrAttachmentItem As New System.Web.UI.HtmlControls.HtmlTableRow
                                        Dim TdSpacer As New System.Web.UI.HtmlControls.HtmlTableCell
                                        Dim TdFilename As New System.Web.UI.HtmlControls.HtmlTableCell
                                        Dim TdSize As New System.Web.UI.HtmlControls.HtmlTableCell
                                        Dim TdAddedBy As New System.Web.UI.HtmlControls.HtmlTableCell
                                        Dim TdAdded As New System.Web.UI.HtmlControls.HtmlTableCell
                                        Dim TdPrivate As New System.Web.UI.HtmlControls.HtmlTableCell
                                        With TdSpacer
                                            .InnerHtml = "&nbsp;"
                                        End With

                                        With TdFilename
                                            Try
                                                .InnerHtml = DtAttachments.Rows(k)("FILENAME").ToString()
                                            Catch ex As Exception
                                                .InnerHtml = "&nbsp;"
                                            End Try
                                            .Attributes.Add("align", "left")
                                        End With

                                        With TdSize
                                            Try
                                                Dim size As Double = 0.0
                                                If IsNumeric(DtAttachments.Rows(k)("FILE_SIZE")) = True Then
                                                    size = CType(DtAttachments.Rows(k)("FILE_SIZE"), Double) / 1000
                                                    Select Case size
                                                        Case Is < 1
                                                            .InnerHtml = "< 1K"
                                                        Case 0 To 9999
                                                            .InnerHtml = size.ToString("#,###") & " KB"
                                                        Case Is >= 1000
                                                            .InnerHtml = (size / 1000).ToString("#,###.##") & " MB"
                                                    End Select
                                                Else
                                                    .InnerHtml = "&nbsp;"
                                                End If
                                            Catch ex As Exception
                                                .InnerHtml = "&nbsp;"
                                            End Try
                                            .Attributes.Add("align", "right")
                                        End With

                                        With TdAddedBy
                                            Try
                                                .InnerHtml = DtAttachments.Rows(k)("USER_NAME").ToString()
                                            Catch ex As Exception
                                                .InnerHtml = "&nbsp;"
                                            End Try
                                            .Attributes.Add("align", "left")
                                        End With
                                        With TdAdded
                                            Try
                                            Catch ex As Exception
                                                .InnerHtml = "&nbsp;"
                                            End Try
                                            .InnerHtml = LoGlo.FormatDateTime(DtAttachments.Rows(k)("GENERATED_DATE").ToString())
                                            .Attributes.Add("align", "right")
                                        End With
                                        With TdPrivate
                                            Try
                                                .InnerHtml = DtAttachments.Rows(k)("IS_PRIVATE").ToString()
                                            Catch ex As Exception
                                                .InnerHtml = "&nbsp;"
                                            End Try
                                            .Attributes.Add("align", "center")
                                        End With

                                        With TrAttachmentItem.Cells
                                            .Add(TdSpacer)
                                            .Add(TdFilename)
                                            .Add(TdSize)
                                            .Add(TdAddedBy)
                                            .Add(TdAdded)
                                            .Add(TdPrivate)
                                        End With
                                        Me.TblAttachments.Rows.Add(TrAttachmentItem)
                                    Catch ex As Exception
                                    End Try
                                Next
                            Else
                                Me.TrAttachmentsHdr.Visible = False
                                Me.TrAttachmentsTable.Visible = False
                                Me.TblAttachments.Visible = False
                            End If
                        Else
                            Me.TrAttachmentsHdr.Visible = False
                            Me.TrAttachmentsTable.Visible = False
                            Me.TblAttachments.Visible = False
                        End If
                    Catch ex As Exception
                        'can't get attachments
                    End Try
                End If
            End If
        End If

        Select Case Me.AlertTypeId
            Case 1, 2, 3, 4, 5, 8
                Me.TrDueDate.Visible = False
                Me.TrTimeDue.Visible = False
            Case 6, 7
                'leave it alone
            Case Else
                Me.TrDueDate.Visible = False
                Me.TrTimeDue.Visible = False
        End Select

    End Sub

    Private Sub SetLevel()

        Me.TrDismissed.Visible = False

        Me.TrOffice.Visible = False
        Me.TrClient.Visible = False
        Me.TrDivision.Visible = False
        Me.TrProduct.Visible = False
        Me.TrCampaign.Visible = False
        Me.TrJob.Visible = False
        Me.TrComponent.Visible = False
        Me.TrTask.Visible = False
        Me.TrEstimate.Visible = False
        Me.TrEstimateComponent.Visible = False

        Me.TrDueDate.Visible = False
        Me.TrTimeDue.Visible = False

        Me.TrDescription.Visible = False

        Me.TrComments.Visible = False

        Me.TrRecipientsHdr.Visible = False
        Me.TrRecipients.Visible = False

        Me.TrAlertAssignmentHdr.Visible = False
        Me.TrWorkflowTemplate.Visible = False
        Me.TrState.Visible = False
        Me.TrAssignTo.Visible = False

        If Me.AlertLevelCode.Trim() <> "" Then
            Select Case Me.AlertLevelCode.Trim()
                Case "OF"
                    Me.TrOffice.Visible = True
                Case "CL"
                    Me.TrClient.Visible = True
                Case "DI"
                    Me.TrClient.Visible = True
                    Me.TrDivision.Visible = True
                Case "PR"
                    Me.TrClient.Visible = True
                    Me.TrDivision.Visible = True
                    Me.TrProduct.Visible = True
                Case "CM"
                    Me.TrClient.Visible = True
                    Me.TrDivision.Visible = True
                    Me.TrProduct.Visible = True
                    Me.TrCampaign.Visible = True
                Case "JO"
                    Me.TrOffice.Visible = True
                    Me.TrClient.Visible = True
                    Me.TrDivision.Visible = True
                    Me.TrProduct.Visible = True
                    Me.TrJob.Visible = True
                Case "JJ", "JC"
                    Me.TrOffice.Visible = True
                    Me.TrClient.Visible = True
                    Me.TrDivision.Visible = True
                    Me.TrProduct.Visible = True
                    Me.TrJob.Visible = True
                    Me.TrComponent.Visible = True
                Case "PS"
                    Me.TrJob.Visible = True
                    Me.TrComponent.Visible = True
                Case "PST"
                    Me.TrJob.Visible = True
                    Me.TrComponent.Visible = True
                    Me.TrTask.Visible = True
                Case "ES", "EST"
                    Me.TrEstimate.Visible = True
                    Me.TrEstimateComponent.Visible = True
            End Select
        End If
    End Sub

End Class
