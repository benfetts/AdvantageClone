Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports Telerik.Web.UI

Partial Public Class BillingApproval_Approval
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private BatchID As Integer = 0
    Private CanEdit As Boolean = False
    Private Property IsApproved As Boolean
        Get
            If ViewState("IsApproved") Is Nothing Then
                Return False
            Else
                Return CType(ViewState("IsApproved"), Boolean)
            End If
        End Get
        Set(value As Boolean)
            ViewState("IsApproved") = value
        End Set
    End Property
    Private Property IsFinished As Boolean
        Get
            If ViewState("IsFinished") Is Nothing Then
                Return False
            Else
                Return CType(ViewState("IsFinished"), Boolean)
            End If
        End Get
        Set(value As Boolean)
            ViewState("IsFinished") = value
        End Set
    End Property

    Protected WithEvents LblCurrentStatus As System.Web.UI.WebControls.Label
    Protected WithEvents LblAlertStatus As System.Web.UI.WebControls.Label

#End Region

#Region " Properties "

    'Store viewstate in session instead of on the page...
    'This doesn't work on the base page
    Dim _pers As PageStatePersister
    Protected Overrides ReadOnly Property PageStatePersister() As PageStatePersister
        Get
            If _pers Is Nothing Then
                _pers = New SessionPageStatePersister(Me)
            End If
            Return _pers
        End Get
    End Property
    Private ApprovedRadToolBarButton As RadToolBarButton

#End Region

#Region " Methods "

#Region " Controls "

    Private Sub RadToolbarBillingApproval_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarBillingApproval.ButtonClick

        Dim ThisBatchID As Integer = 0

        If IsNumeric(Me.LblBatchID.Text) = True Then

            ThisBatchID = CType(Me.LblBatchID.Text, Integer)

        End If
        Select Case e.Item.Value
            Case "HidePopups"

                Me.LoadForm()

            Case "New"

                'pass no approval id (BA_ID)
                Session("BillinbApproval_Approval_Detail_New_Approval_Id") = Nothing
                Me.OpenWindow("Billing Approval", "BillingApproval_Approval_Detail.aspx?BAID=" & ThisBatchID.ToString() & "&AID=-1")

            Case "Finish"

                If IsNumeric(Me.LblBatchID.Text) = True Then

                    If Me.HasApprovedJobs(Me.BatchID) = False Then

                        Me.ShowMessage("There is nothing to approve")
                        Exit Sub

                    Else

                        Dim b As New cBillingApproval(Session("ConnString"), Session("UserCode"))
                        Dim str As String = ""

                        If IsApproved = False Then 'Approve

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                Dim AllowWithUnapprovedJobs As Boolean = False
                                Dim Approve As Boolean = False

                                Try

                                    AllowWithUnapprovedJobs = DbContext.Database.SqlQuery(Of Boolean)("SELECT CAST(COALESCE(AGY_SETTINGS_VALUE, AGY_SETTINGS_DEF, 0) AS BIT) FROM AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS_CODE = 'BA_APPR_W_UNAPPR';").FirstOrDefault

                                Catch ex As Exception
                                    AllowWithUnapprovedJobs = False
                                End Try

                                If AllowWithUnapprovedJobs = False Then

                                    Dim AreAllJobsApproved As Boolean = False
                                    Try

                                        AreAllJobsApproved = DbContext.Database.SqlQuery(Of Boolean)(String.Format("EXEC [dbo].[advsp_billing_approval_are_all_jobs_approved_for_batch] {0};", Me.BatchID)).FirstOrDefault

                                    Catch ex As Exception
                                        AreAllJobsApproved = False
                                    End Try

                                    If AreAllJobsApproved = False Then

                                        Me.ShowMessage("Please approve all jobs first")
                                        Exit Sub

                                    Else

                                        Approve = True

                                    End If

                                Else

                                    Approve = True

                                End If
                                If Approve = True Then

                                    str = b.BatchApprove(Me.BatchID)

                                    If str <> "" Then

                                        Me.LblMSG.Text = str

                                    End If

                                    Me.LoadForm()

                                End If

                            End Using

                        Else 'Unapprove

                            str = b.BatchApprove(Me.BatchID)

                            If str <> "" Then

                                Me.LblMSG.Text = str

                            End If

                            Me.LoadForm()

                        End If

                    End If

                End If
            Case "Alert"

                If IsNumeric(Me.LblBatchID.Text) = True Then

                    Dim strURL As String = "BillingApproval_Alert.aspx?P=2&BAID=" & ThisBatchID.ToString()
                    Me.OpenWindow("Alert", strURL)

                End If

            Case "CreateApprovals"

                If IsNumeric(Me.LblBatchID.Text) = True Then

                    Me.CreateApprovals(CType(Me.LblBatchID.Text, Integer))
                    Me.LoadForm()

                End If

            Case "Refresh"

                Me.LoadForm()

        End Select

    End Sub
    Private Sub RadGridApprovalsList_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridApprovalsList.ItemCommand

        If e.Item Is Nothing Then Exit Sub

        Select Case e.CommandName
            Case "ViewApproval"

                'pass the approval id (BA_ID)
                Dim ThisBatchID As Integer = 0
                If IsNumeric(Me.LblBatchID.Text) = True Then
                    ThisBatchID = CType(Me.LblBatchID.Text, Integer)
                End If
                Session("BillinbApproval_Approval_Detail_New_Approval_Id") = Nothing
                Me.OpenWindow("Billing Approval", "BillingApproval_Approval_Detail.aspx?BAID=" & ThisBatchID.ToString() & "&AID=" & e.CommandArgument.ToString())

            Case "Delete"

                Dim ThisBatchID As Integer = 0
                Dim ThisApprovalId As Integer = 0
                Dim ApprovalsThatCouldNotBeDeletedCount As Integer = 0
                Dim ba As New cBillingApproval()

                If IsNumeric(Me.LblBatchID.Text) = True Then

                    ThisBatchID = CType(Me.LblBatchID.Text, Integer)

                    If ThisBatchID > 0 Then

                        For i As Integer = 0 To Me.RadGridApprovalsList.MasterTableView.Items.Count - 1

                            Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridApprovalsList.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem)
                            Dim chk As CheckBox

                            chk = CType(CurrentGridRow.FindControl("CheckBoxDeleteRow"), CheckBox)

                            If Not chk Is Nothing AndAlso chk.Checked = True Then

                                If IsNumeric(CurrentGridRow.GetDataKeyValue("BA_ID")) = True Then

                                    ThisApprovalId = CurrentGridRow.GetDataKeyValue("BA_ID")

                                    If ba.CanDeleteApproval(ThisApprovalId) = False Then

                                        'Me.ShowMessage("Cannot delete approval")
                                        'Exit Sub
                                        ApprovalsThatCouldNotBeDeletedCount += 1

                                    Else

                                        Dim s As String = ba.ApprovalDelete(ThisBatchID, ThisApprovalId)
                                        If s <> "" Then

                                            'Me.ShowMessage(s)
                                            ApprovalsThatCouldNotBeDeletedCount += 1

                                        End If


                                    End If

                                End If

                            End If

                        Next

                    End If

                End If

                Select Case ApprovalsThatCouldNotBeDeletedCount
                    Case 1

                        Me.ShowMessage("One approval could not be deleted.")

                    Case Is > 1

                        Me.ShowMessage(ApprovalsThatCouldNotBeDeletedCount.ToString() & " approvals could not be deleted.")

                End Select

        End Select
    End Sub
    Private Sub RadGridApprovalsList_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridApprovalsList.ItemDataBound
        If TypeOf e.Item Is Telerik.Web.UI.GridHeaderItem Then

            Dim dataItem As Telerik.Web.UI.GridHeaderItem = e.Item
            Dim DeleteImageButton As System.Web.UI.WebControls.ImageButton = CType(dataItem.FindControl("ImageButtonDelete"), ImageButton)
            DeleteImageButton.Attributes("onclick") = "return confirm('Are you sure you want to delete the selected approvals?')"

        End If
    End Sub
    Private Sub RadGridApprovalsList_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridApprovalsList.NeedDataSource
        'Me.LoadForm()
        Dim dsBatchDetails As New DataSet
        Dim b As New cBillingApproval()
        dsBatchDetails = b.GetBatchApprovalsList(BatchID)
        Me.RadGridApprovalsList.DataSource = dsBatchDetails.Tables(1)
    End Sub

#End Region
#Region " Page "

    Private Sub Page_Init2(sender As Object, e As System.EventArgs) Handles Me.Init

        Session("DtApprovals") = Nothing
        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Billing_BillingApproval)

        Try
            Session("BA_APPROVAL_GO_BACK") = Nothing
        Catch ex As Exception
        End Try
        Try
            BatchID = CType(Request.QueryString("BAID"), Integer)
        Catch ex As Exception
            BatchID = 0
        End Try

        Dim qs As New AdvantageFramework.Web.QueryString
        qs = qs.FromCurrent()
        If qs.BillingApprovalBatchID > 0 Then Me.BatchID = qs.BillingApprovalBatchID

        Me.LblCurrentStatus = CType(Me.RadToolbarBillingApproval.FindItemByValue("RadToolBarButtonLblCurrentStatus").FindControl("LblCurrentStatus"), System.Web.UI.WebControls.Label)
        Me.LblAlertStatus = CType(Me.RadToolbarBillingApproval.FindItemByValue("RadToolBarButtonLblAlertStatus").FindControl("LblAlertStatus"), System.Web.UI.WebControls.Label)

        ApprovedRadToolBarButton = CType(Me.RadToolbarBillingApproval.FindItemByValue("Finish"), Telerik.Web.UI.RadToolBarButton)

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack = True And Not Me.IsCallback = True Then

            Me.LblMSG.Text = ""
            Me.LoadForm()

            If Me.ApprovedRadToolBarButton IsNot Nothing AndAlso Me.HasApprovedJobs(Me.BatchID) = False Then

                ApprovedRadToolBarButton.Enabled = False
                ApprovedRadToolBarButton.ToolTip = "There is nothing to approve"

            End If

        End If

        Me.CheckApprovalRequirement()

    End Sub

#End Region

    Private Sub CreateApprovals(ByVal BatchId As Integer)

        Dim b As New cBillingApproval(Session("ConnString"), Session("UserCode"))
        Dim str As String = b.AutoSaveAllClients(BatchId, True)

        If str <> "" Then

            Me.LblMSG.Text = str

        End If

    End Sub
    Private Sub AutoCreateApprovals(ByVal BatchId As Integer)

        Dim SessionKey As String = "AutoCreateApprovals" & BatchId.ToString().PadLeft(10)

        If HttpContext.Current.Session(SessionKey) Is Nothing Then

            Me.CreateApprovals(BatchId)
            HttpContext.Current.Session(SessionKey) = True.ToString()

        End If

    End Sub
    Private Sub LoadForm()

        If BatchID > 0 Then

            Me.HiddenFieldHasUnapprovedJobs.Value = "0"

            Dim b As New cBillingApproval(Session("ConnString"), Session("UserCode"))
            Dim dsBatchDetails As New DataSet
            Dim dtBatchHeader As New DataTable

            dsBatchDetails = b.GetBatchApprovalsList(BatchID)
            dtBatchHeader = dsBatchDetails.Tables(0)

            If IsDBNull(dtBatchHeader.Rows(0)("BA_BATCH_ID")) = False Then
                Me.LblBatchID.Text = dtBatchHeader.Rows(0)("BA_BATCH_ID").ToString().PadLeft(6, "0")
            Else
                Me.LblBatchID.Text = ""
            End If
            If IsDBNull(dtBatchHeader.Rows(0)("BA_BATCH_DESC")) = False Then
                Me.LblBatchDescription.Text = dtBatchHeader.Rows(0)("BA_BATCH_DESC").ToString()
            Else
                Me.LblBatchDescription.Text = ""
            End If
            If IsDBNull(dtBatchHeader.Rows(0)("BATCH_DATE")) = False Then
                Me.LblBatchDate.Text = LoGlo.FormatDate(cGlobals.wvCDate(dtBatchHeader.Rows(0)("BATCH_DATE")).ToShortDateString)
            Else
                Me.LblBatchDate.Text = ""
            End If
            If IsDBNull(dtBatchHeader.Rows(0)("STATUS")) = False Then
                LblCurrentStatus.Text = dtBatchHeader.Rows(0)("STATUS").ToString()
            Else
                LblCurrentStatus.Text = "N/A"
            End If
            If IsDBNull(dtBatchHeader.Rows(0)("ALERT_STATUS")) = False Then
                LblAlertStatus.Text = dtBatchHeader.Rows(0)("ALERT_STATUS").ToString()
            Else
                LblAlertStatus.Text = "N/A"
            End If

            If IsDBNull(dtBatchHeader.Rows(0)("JOB_BATCH_COUNT")) = False Then
                LblJobList.Text = "Job List (" & b.GetBatchJobListSimple(BatchID, True).Rows.Count.ToString() & ")"
            End If

            'set finish button
            If IsDBNull(dtBatchHeader.Rows(0)("APPROVED")) = False Then

                If dtBatchHeader.Rows(0)("APPROVED") = True Then

                    IsApproved = True

                    ApprovedRadToolBarButton.Text = "Approved"
                    ApprovedRadToolBarButton.Checked = True
                    ApprovedRadToolBarButton.ToolTip = "Batch is approved.  Click to unapprove."

                Else

                    IsApproved = False

                    ApprovedRadToolBarButton.Text = "Approve"
                    ApprovedRadToolBarButton.Checked = False
                    ApprovedRadToolBarButton.ToolTip = "Click to mark batch as approved"

                End If

            End If

            'enable finish button
            If IsDBNull(dtBatchHeader.Rows(0)("FINISHED")) = False Then

                If dtBatchHeader.Rows(0)("FINISHED") = True Then

                    IsFinished = True
                    ApprovedRadToolBarButton.Enabled = False

                Else

                    ApprovedRadToolBarButton.Enabled = True

                    If b.HasUnApprovedJobs(Me.BatchID) = True AndAlso IsApproved = False Then

                        Me.HiddenFieldHasUnapprovedJobs.Value = "1"

                    End If

                End If

            End If

            If IsApproved = False AndAlso IsFinished = True Then

                ApprovedRadToolBarButton.ToolTip = "Batch is finished"

            End If

            If IsApproved = True Or IsFinished = True Then

                CType(Me.RadToolbarBillingApproval.FindItemByValue("New"), Telerik.Web.UI.RadToolBarButton).Enabled = False

            Else

                CType(Me.RadToolbarBillingApproval.FindItemByValue("New"), Telerik.Web.UI.RadToolBarButton).Enabled = True

            End If

            'wire up tooltip
            With Me.RadToolTipManager1.TargetControls

                .Clear()
                .Add(Me.LblBatchIDTitle.ClientID, BatchID, True)

            End With

            Me.RadToolTipManager1.Enabled = True

            With Me.RadToolTipManager2

                .TargetControls.Clear()
                .TargetControls.Add(Me.LblJobList.ClientID, BatchID, True)

            End With
            Me.RadToolTipManager2.Enabled = True

            'Me.RadGridApprovalsList.DataSource = dsBatchDetails.Tables(1)

            Me.AutoCreateApprovals(BatchID)
            Me.RadGridApprovalsList.Rebind()

        Else

            Me.LblMSG.Text = "Batch ID not found."

            With Me.RadToolTipManager1

                .TargetControls.Clear()
                .Enabled = False
                .Visible = False

            End With

            With Me.RadToolTipManager2

                .TargetControls.Clear()
                .Enabled = False
                .Visible = False

            End With

        End If
    End Sub

    Private Function HasApprovedJobs(ByVal BillingApprovalBatchID As Integer) As Boolean

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            If CType(DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(1) FROM BILL_APPR BA WITH(NOLOCK) INNER JOIN BILL_APPR_HDR BAH WITH(NOLOCK) ON BA.BA_ID = BAH.BA_ID WHERE BA_BATCH_ID = {0};", BillingApprovalBatchID)).FirstOrDefault, Integer) = 0 Then

                Return False

            Else

                Return True

            End If

        End Using

    End Function
    Private Sub CheckApprovalRequirement()

        If Me.ApprovedRadToolBarButton IsNot Nothing Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Dim AllowWithUnapprovedJobs As Boolean = False
                Dim AreAllJobsApproved As Boolean = False

                Try

                    AllowWithUnapprovedJobs = DbContext.Database.SqlQuery(Of Boolean)("SELECT CAST(COALESCE(AGY_SETTINGS_VALUE, AGY_SETTINGS_DEF, 0) AS BIT) FROM AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS_CODE = 'BA_APPR_W_UNAPPR';").FirstOrDefault

                Catch ex As Exception
                    AllowWithUnapprovedJobs = False
                End Try
                Try

                    AreAllJobsApproved = DbContext.Database.SqlQuery(Of Boolean)(String.Format("EXEC [dbo].[advsp_billing_approval_are_all_jobs_approved_for_batch] {0};", Me.BatchID)).FirstOrDefault

                Catch ex As Exception
                    AreAllJobsApproved = False
                End Try

                If AllowWithUnapprovedJobs = True AndAlso AreAllJobsApproved = False Then

                    'wire up return confirm
                    Me.ApprovedRadToolBarButton.CommandName = "Approve_Warn"

                ElseIf AllowWithUnapprovedJobs = False AndAlso AreAllJobsApproved = True Then

                    'allow approval; do nothing
                    Me.ApprovedRadToolBarButton.CommandName = "Finish"

                ElseIf AllowWithUnapprovedJobs = True AndAlso AreAllJobsApproved = True Then

                    'allow approval; do nothing
                    Me.ApprovedRadToolBarButton.CommandName = "Finish"

                ElseIf AllowWithUnapprovedJobs = False AndAlso AreAllJobsApproved = False Then

                    'don't allow approval
                    Me.ApprovedRadToolBarButton.CommandName = "Approve_Disallow"

                End If

            End Using

        End If

    End Sub

    'tooltip:
    Protected Sub OnAjaxUpdate(ByVal sender As Object, ByVal args As ToolTipUpdateEventArgs)
        Me.UpdateToolTip(args.Value, args.UpdatePanel)
    End Sub
    Private Sub UpdateToolTip(ByVal ArguementValue As String, ByVal panel As UpdatePanel)
        Dim ctrl As System.Web.UI.Control = Page.LoadControl("BillingApproval_Approval_Tooltip.ascx")
        panel.ContentTemplateContainer.Controls.Add(ctrl)

        Dim t As BillingApproval_Approval_Tooltip = DirectCast(ctrl, BillingApproval_Approval_Tooltip)
        With t
            .BatchID = ArguementValue
        End With
    End Sub

    'job list tooltip:
    Protected Sub OnAjaxUpdate2(ByVal sender As Object, ByVal args As ToolTipUpdateEventArgs)
        Me.UpdateToolTip2(args.Value, args.UpdatePanel)
    End Sub
    Private Sub UpdateToolTip2(ByVal ArguementValue As String, ByVal panel As UpdatePanel)
        Dim ctrl As System.Web.UI.Control = Page.LoadControl("BillingApproval_Batch_Tooltip_JobList.ascx")
        panel.ContentTemplateContainer.Controls.Add(ctrl)

        Dim t As BillingApproval_Batch_Tooltip_JobList = DirectCast(ctrl, BillingApproval_Batch_Tooltip_JobList)
        With t

            .BatchID = ArguementValue
            .GetSimpleList = True
            .ItalicizeApproved = True

        End With
    End Sub

#End Region

End Class
