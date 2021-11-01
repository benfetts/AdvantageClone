Imports System.Data.SqlClient
Imports System.Text
Imports Webvantage.wvTimeSheet
Imports Webvantage.MiscFN
Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms
Imports Ionic.Zip
Imports Telerik.Web.UI

Partial Public Class Alert_New
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Dim _pers As PageStatePersister

    Private ConnectionString As String = ""
    Private EmployeeCode As String = ""

    Public App As MiscFN.Source_App
    Public AlertLevel As String = ""
    Public IsPopUp As Boolean = False

    Public ClCode As String = ""
    Public DivCode As String = ""
    Public ProdCode As String = ""
    Public JobNumber As Integer = 0
    Public JobComponentNbr As Integer = 0
    Public JobVerHdrID As Integer = 0

    Private IsCopy As Boolean = False
    Private EmpCode As String = ""
    Private ManagerCode As String = ""
    Private TaskCode As String = ""
    Private AccountExecCode As String = ""
    Private RoleCode As String = ""
    Private CutOffDate As String = ""
    Private IncludeCompletedTasks As Boolean = True
    Private IncludeOnlyPendingTasks As Boolean = False
    Private ExcludeProjectedTasks As Boolean = False
    Private IncludeCompletedSchedules As Boolean = True
    Private MilestonesOnly As Boolean = False
    Private TrafficStatusCode As String = ""
    Private ExcludeTaskComment As Boolean = False

    Private UsingATaskLevelFilter As Boolean = False
    Private TaskPhaseFilter As String = ""

    Public TaskSeqNbr As Integer = -1

    Public CampaignCode As String = ""
    Public CmpIdentifier As Integer = 0

    Public EstimateNumber As Integer = 0
    Public EstimateComponentNbr As Integer = 0

    Public ATBNumber As Integer = 0
    Public ATBRevisionNumber As Short = 0

    Public currentWindowsIdentity As System.Security.Principal.WindowsIdentity

    Public FromProjectScheduleAlertInbox As Boolean = False
    Private HasNotifyAssignment As Boolean = False

    'This variable will be used to replace pages using "Pop/Send" (popsend.aspx)
    Public SendOnly As Boolean = False
    'variables from the popsend.aspx page
    Private AlertFunction As String = ""

    Private PO_RefId As Integer = 0
    Private PO_AlertFunction As String = ""

    Private PrintJS As Boolean = False
    Private PrintJV As Boolean = False
    Private PrintCB As Boolean = False

    Private VendorQuoteNbr As Integer = 0
    Private VendorCode As String = ""

    Private AutoSetToAssignment As Boolean = False
    Private AutoSetToEmail As Boolean = False

    Private _CopyFromAlertID As Integer = 0

    Private _MultipleJob As Boolean = False
    Private _MultipleJobList As String = ""

    Private UcRadScriptManager As Telerik.Web.UI.RadScriptManager = Nothing

    Private FileType As Integer = 1 'PDF

    Private Property _DraftAlertID As Integer
        Get
            If ViewState("_DraftAlertID") Is Nothing Then
                ViewState("_DraftAlertID") = 0
            End If
            Return ViewState("_DraftAlertID")
        End Get
        Set(value As Integer)
            ViewState("_DraftAlertID") = value
        End Set
    End Property
    Private _SavingDraft As Boolean = False

#End Region

#Region " Properties "

    'Store viewstate in session instead of on the page...
    'This doesn't work on the base page
    Protected Overrides ReadOnly Property PageStatePersister() As PageStatePersister
        Get
            If _pers Is Nothing Then
                _pers = New SessionPageStatePersister(Me)
            End If
            Return _pers
        End Get
    End Property
    Public Property FormIsAlertAssignment() As Boolean
        Get
            Return Me.ChkIsAlertAssignment.Checked
        End Get
        Set(ByVal value As Boolean)
            Me.ChkIsAlertAssignment.Checked = value
            Me.SetAlertOrAssignment()
        End Set
    End Property
    Public Property CheckboxIsAssignment() As CheckBox
        Get
            Return Me.ChkIsAlertAssignment
        End Get
        Set(ByVal value As CheckBox)
            Me.ChkIsAlertAssignment = value
        End Set
    End Property


#End Region

#Region " Methods "

#Region " Controls "

    Private Sub RadComboBoxVersion_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxVersion.SelectedIndexChanged

        Me.LoadBuild(CType(Me.RadComboBoxVersion.SelectedValue, Integer))

    End Sub
    Protected Sub AlertLevelDropDownList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadComboBoxAlertLevel.SelectedIndexChanged

        Me.ChangeAlertLevel(RadComboBoxAlertLevel.SelectedValue)

    End Sub
    Private Sub RadComboBoxAlertAssignmentTemplate_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadComboBoxAlertAssignmentTemplate.SelectedIndexChanged

        If IsNumeric(Me.RadComboBoxAlertAssignmentTemplate.SelectedValue) = True Then

            Me.SetStatesAndEmployees(Me.RadComboBoxAlertAssignmentTemplate.SelectedValue)
            Me.SetDefaultSubject()

        Else

            Me.RadTreeViewStates.Nodes.Clear()
            Me.RadComboBoxAssignTo.Items.Clear()
            Me.RadComboBoxAssignTo.Enabled = False

        End If

    End Sub
    Private Sub RadTreeViewStates_NodeClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadTreeNodeEventArgs) Handles RadTreeViewStates.NodeClick
        'TEST: Me.FsAlertRecipients.Visible = False
        If Me.RadComboBoxAlertAssignmentTemplate.SelectedIndex > 0 And Me.RadTreeViewStates.SelectedNode.Index > -1 Then
            Dim a As New cAlerts()
            With Me.RadComboBoxAssignTo
                .Items.Clear()
                .Text = ""
                .DataTextField = "EMP_FML"
                .DataValueField = "EMP_CODE"
                .DataSource = a.GetNotificationRecipients(Me.RadTreeViewStates.SelectedValue, 0, 0, Me.RadComboBoxAlertAssignmentTemplate.SelectedValue)
                .DataBind()
            End With
            With Me.RadComboBoxAssignTo
                .Visible = True
                .Enabled = True
                .Focus()
            End With
            Try
                For Each item As Telerik.Web.UI.RadComboBoxItem In Me.RadComboBoxAssignTo.Items

                    If item.Text.Contains("*") = True Then

                        item.Selected = True
                        Me.RadComboBoxAssignTo.Text = item.Text
                        Me.RadComboBoxAssignTo.SelectedValue = item.Value
                        Me.RadComboBoxAssignTo.Items.FindItemByValue(item.Value).Selected = True
                        Exit For

                    End If

                Next
            Catch ex As Exception
            End Try
            Try
                Me.RadComboBoxCategory.FindItemByValue(a.GetDefaultCategory(Me.RadTreeViewStates.SelectedValue).ToString()).Selected = True
            Catch ex As Exception
            End Try
            Me.SetDefaultSubject()
        Else
            Try
                With Me.RadComboBoxAssignTo
                    If .Items.Count > 0 Then
                        .SelectedIndex = 0
                    End If
                    .Visible = True
                    .Enabled = False
                End With
            Catch ex As Exception
            End Try
        End If
        Me.RadComboBoxAssignTo.Visible = True
    End Sub
    Private Sub RadComboBoxAssignTo_ItemsRequested(sender As Object, e As Telerik.Web.UI.RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxAssignTo.ItemsRequested

        Dim AlertStateId As Integer = 0
        Dim AlertNotifyHdrId As Integer = 0

        If Me.RadComboBoxAlertAssignmentTemplate.SelectedIndex > -1 AndAlso IsNumeric(Me.RadComboBoxAlertAssignmentTemplate.SelectedValue) Then
            AlertNotifyHdrId = CType(Me.RadComboBoxAlertAssignmentTemplate.SelectedValue, Integer)
        End If
        If Me.RadTreeViewStates.SelectedNode IsNot Nothing AndAlso IsNumeric(Me.RadTreeViewStates.SelectedNode.Value) Then
            AlertStateId = CType(Me.RadTreeViewStates.SelectedNode.Value, Integer)
        End If
        Dim a As New cAlerts()
        Dim data As DataTable = a.GetNotificationRecipients(AlertStateId, 0, 0, AlertNotifyHdrId, e.Text, Me.CheckBoxShowAllAssignmentEmployees.Checked) 'GetData(e.Text)

        Dim itemOffset As Integer = e.NumberOfItems
        Dim endOffset As Integer = Math.Min(itemOffset + Me.RadComboBoxAssignTo.ItemsPerRequest, data.Rows.Count)
        e.EndOfItems = endOffset = data.Rows.Count

        RadComboBoxAssignTo.Items.Clear()

        For i As Integer = itemOffset To endOffset - 1

            RadComboBoxAssignTo.Items.Add(New RadComboBoxItem(data.Rows(i)("EMP_FML").ToString(),
                                                              data.Rows(i)("EMP_CODE").ToString()))

        Next

        e.Message = AdvantageFramework.Web.Presentation.Controls.RadComboBoxAutoFillGetStatusMessage(endOffset, data.Rows.Count)

    End Sub
    Private Sub CheckBoxShowAllAssignmentEmployees_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxShowAllAssignmentEmployees.CheckedChanged

        Me.BindRadComboBoxAssignTo()

    End Sub
    Private Sub BindRadComboBoxAssignTo()

        Dim AlertStateId As Integer = 0
        Dim AlertNotifyHdrId As Integer = 0

        If Me.RadComboBoxAlertAssignmentTemplate.SelectedIndex > -1 AndAlso IsNumeric(Me.RadComboBoxAlertAssignmentTemplate.SelectedValue) Then
            AlertNotifyHdrId = CType(Me.RadComboBoxAlertAssignmentTemplate.SelectedValue, Integer)
        End If
        If Me.RadTreeViewStates.SelectedNode IsNot Nothing AndAlso IsNumeric(Me.RadTreeViewStates.SelectedNode.Value) Then
            AlertStateId = CType(Me.RadTreeViewStates.SelectedNode.Value, Integer)
        End If
        If AlertNotifyHdrId > 0 And AlertStateId > 0 Then

            Dim a As New cAlerts()

            With Me.RadComboBoxAssignTo

                .DataTextField = "EMP_FML"
                .DataValueField = "EMP_CODE"
                .DataSource = a.GetNotificationRecipients(AlertStateId, 0, 0, AlertNotifyHdrId, "", Me.CheckBoxShowAllAssignmentEmployees.Checked)
                .DataBind()
                '.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Unassigned]", "unassigned"))

            End With

            If Not Me.Page.IsPostBack And Not Me.Page.IsCallback Then


            Else

                For Each item As Telerik.Web.UI.RadComboBoxItem In Me.RadComboBoxAssignTo.Items

                    If item.Text.Contains("*") = True Then

                        item.Selected = True

                    End If

                Next

            End If

            Me.RadComboBoxAssignTo.Focus()

        End If

    End Sub

    Protected Sub BtnClearSelectionsSelections_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClearSelections.Click
        'If Me.RadComboBoxAlertLevel.SelectedValue = "JC" Then
        '    Me.RadTreeViewStates.Nodes.Clear()
        '    Me.RadComboBoxAssignTo.SelectedIndex = 0
        '    Me.RadComboBoxAssignTo.Enabled = False
        'End If
        'If Me.RadComboBoxAlertLevel.SelectedValue = "PST" Or Me.AlertLevel = "PST" Then
        '    Try
        '        Me.RadioNotifyAlertGroup.Checked = False
        '        Me.RadioNotifyEmployeesTask.Checked = False
        '        Me.RadioNotifyEmployeesAssigned.Checked = False
        '        Me.RadioNotifyNext.Checked = False
        '    Catch ex As Exception
        '    End Try
        'End If

        ''Me.RadTreeViewStates.Nodes.Clear()
        ''If Me.RadComboBoxAssignTo.Items.Count > 0 Then
        ''    Me.RadComboBoxAssignTo.SelectedIndex = 0
        ''End If
        ''Me.RadComboBoxAssignTo.Enabled = False
        Me.RadioNotifyAlertGroup.Checked = False
        Me.RadioNotifyEmployeesTask.Checked = False
        Me.RadioNotifyEmployeesAssigned.Checked = False
        Me.RadioNotifyNext.Checked = False

        Me.AutoCompleteRecipients.Clear() 'Me.TxtRecipients.Value = ""

    End Sub
    Private Sub BtnSelectRecipients_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSelectRecipients.Click
        If Me.RadComboBoxAlertLevel.SelectedIndex = 0 Then

            Me.ShowMessage("Please select an Alert Level")
            Exit Sub

        End If

        Dim str As String = ""
        str = QuickValidateLookups(Me.RadComboBoxAlertLevel.SelectedValue)

        If str = "" Then

            Dim ThisEmailGroup As String = ""
            Dim ThisJobNumber As Integer = 0
            Dim ThisJobComponentNumber As Integer = 0
            Dim IsAG As Integer = 0
            Dim ThisClCode As String = ""
            Dim ThisDivCode As String = ""
            Dim ThisPrdCode As String = ""

            Dim agency As New AdvantageFramework.Web.AgencySettings.Methods(Session("ConnString"), Session("UserCode"), HttpContext.Current)
            Dim AssignmentState As Integer = If(agency.GetValue(AdvantageFramework.Agency.Settings.JR_ASSIGN_STATE, 0) = "", 0, agency.GetValue(AdvantageFramework.Agency.Settings.JR_ASSIGN_STATE, 0))
            Dim JobRequestEmployee As String = agency.GetValue(AdvantageFramework.Agency.Settings.JR_DFLT_CONTACT, "")
            Dim JobRequestAlertGroup As String = agency.GetValue(AdvantageFramework.Agency.Settings.JR_DFLT_ALERT_GROUP, "")

            Try
                If Me.IsClientPortal = True Then

                    If AutoSetToAssignment = True Then
                        If AssignmentState > 0 Then
                            ThisEmailGroup = JobRequestAlertGroup
                            Me.ChkIsAlertAssignment.Visible = False
                        Else
                            ThisEmailGroup = _Session.ClientPortalUser.AlertGroupCode
                            Me.ChkIsAlertAssignment.Visible = False
                        End If
                    Else
                        If JobRequestAlertGroup <> "" And Request.QueryString("pagetype") = "jr" Then
                            ThisEmailGroup = JobRequestAlertGroup
                            Me.ChkIsAlertAssignment.Visible = False
                        Else
                            ThisEmailGroup = _Session.ClientPortalUser.AlertGroupCode
                            If ThisEmailGroup Is Nothing Then
                                ThisEmailGroup = ""
                            End If
                            Me.ChkIsAlertAssignment.Visible = False
                        End If
                    End If

                Else

                    If AutoSetToAssignment = True Then
                        If AssignmentState > 0 Then
                            ThisEmailGroup = JobRequestAlertGroup
                        Else
                            ThisEmailGroup = getDefaultEmailGroup()
                        End If
                    Else
                        If JobRequestAlertGroup <> "" And Request.QueryString("pagetype") = "jr" Then
                            ThisEmailGroup = JobRequestAlertGroup
                        Else
                            ThisEmailGroup = getDefaultEmailGroup()
                        End If
                    End If

                End If
            Catch ex As Exception

                ThisEmailGroup = ""

            End Try
            If Me.RadComboBoxAlertLevel.SelectedValue = "JC" And Request.QueryString("fromapp") <> "jobsearchmul" Then

                If Me.txtClient.Text = "" And Me.txtDivision.Text = "" And Me.txtProduct.Text = "" Then

                    Dim job As New cJobFunctions(Session("ConnString"))
                    job.GetCliDivProdFromJob(CInt(Me.txtJob.Text), CInt(Me.txtComponent.Text), ThisClCode, ThisDivCode, ThisPrdCode)

                Else

                    ThisClCode = Me.txtClient.Text
                    ThisDivCode = Me.txtDivision.Text
                    ThisPrdCode = Me.txtProduct.Text

                End If

            Else

                ThisClCode = Me.txtClient.Text
                ThisDivCode = Me.txtDivision.Text
                ThisPrdCode = Me.txtProduct.Text

            End If

            ThisEmailGroup = ThisEmailGroup.Replace("/", "-").Replace("&", "and").Replace(",", "_").Replace("'", "__")


            ThisJobNumber = Me.JobNumber
            ThisJobComponentNumber = Me.JobComponentNbr

            Try
                If ThisJobNumber = 0 Or ThisJobComponentNumber = 0 Then

                    ThisJobNumber = CType(Me.txtJob.Text, Integer)
                    ThisJobComponentNumber = CType(Me.txtComponent.Text, Integer)

                End If
            Catch ex As Exception

                ThisJobNumber = 0
                ThisJobComponentNumber = 0

            End Try

            If ThisJobNumber > 0 And ThisJobComponentNumber > 0 Then

                IsAG = 1

            End If

            Dim qs As New AdvantageFramework.Web.QueryString()

            qs.Page = "LookUp_Recipients.aspx"
            qs.JobNumber = ThisJobNumber
            qs.JobComponentNumber = ThisJobComponentNumber
            qs.EmailGroup = ThisEmailGroup
            qs.Add("ag", IsAG)
            qs.Add("NewAlertLevel", Me.RadComboBoxAlertLevel.SelectedValue)
            qs.ClientCode = ThisClCode
            qs.DivisionCode = ThisDivCode
            qs.ProductCode = ThisPrdCode
            qs.Add("uac", "1") 'UseAutoComplete
            qs.Add("seldrcpt", Me.AutoCompleteRecipients.GetCommaDelimitedStringOfEmployeeCodes())

            Me.OpenLookUpRecipients(qs.ToString(True))

        Else

            Me.ShowMessage(str)
            Exit Sub

        End If

    End Sub
    Private Sub RadToolbarAlertNew_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarAlertNew.ButtonClick

        Dim ErrorMessage As String = ""

        Select Case e.Item.Value
            Case "SaveDraft"

                If Me.CheckStartDueDate() = False Then Exit Sub

                Me._SavingDraft = True

                Me._DraftAlertID = Me.SaveAlert(False, True)

                If Me._DraftAlertID > 0 Then Me.RadGridDraftAttachemnts.Rebind()

            Case "DeleteDraft"

                If Me._DraftAlertID > 0 Then

                    Dim a As New cAlerts()
                    Dim s As String = ""

                    If a.DeleteAlert(Me._DraftAlertID, s) = True Then

                        Me.CloseThisWindowAndRefreshCaller("Alert_Inbox.aspx")

                    Else

                        If s <> "" Then Me.ShowMessage(s)

                    End If

                End If

                Exit Sub

            Case "Send"

                If Me.CheckStartDueDate() = False Then Exit Sub

                Dim Valid As Boolean = True
                Dim AlertSavedAndSent As Boolean = False
                Dim SendError As String = ""

                If Me._DraftAlertID > 0 Then

                    SqlHelper.ExecuteNonQuery(Session("ConnString"), CommandType.Text, String.Format("UPDATE ALERT SET IS_DRAFT = 0 WHERE ALERT_ID = {0};", Me._DraftAlertID))

                End If
                If Me.RadComboBoxAlertLevel.SelectedIndex = 0 Then

                    Me.ShowMessage("Please select an alert level")
                    Valid = False

                End If
                If Me.HasRecipient() = False Then

                    Valid = False

                End If

                Dim str As String = String.Empty

                str = QuickValidateLookups(Me.RadComboBoxAlertLevel.SelectedValue)

                If String.IsNullOrWhiteSpace(str) = False Then

                    Me.ShowMessage(str)
                    Valid = False

                End If

                If Valid = True Then

                    Page.Validate()

                    If Page.IsValid = False Then

                        Valid = False

                    End If

                End If

                If Valid = True Then

                    If (Me.App = Source_App.ProjectSchedule Or Me.App = Source_App.ProjectSchedule_Alerts) And Me.CheckboxIsAssignment.Checked = False Then

                        If RadioEmail.Checked = False Then

                            Me.SendProjectScheduleAlert()
                            AlertSavedAndSent = True

                        End If

                    End If

                    If AlertSavedAndSent = False Then

                        If Me.SendOnly = False Or Me.CheckboxIsAssignment.Checked = True Then

                            Me.SendAlertOrAlertAssignment() 'The default path that handles normal alerts and assignments

                        Else

                            If Me.SendEmailAlert(SendError) = False Then 'The path that replaces "popsend.aspx" for apps except PS. includes email option on print/send pages

                                If SendError <> "" Then

                                    Me.ShowMessage(SendError)
                                    Exit Sub

                                Else

                                    Me.CloseThisWindow()

                                End If

                            Else

                                If SendError.Contains(Alert.BaseMessageIsOverSizedMessage) = True Then

                                    Me.ShowMessage(SendError)
                                    Me.CloseThisWindow()

                                End If

                            End If

                        End If

                    End If

                    Me.GoBack()

                Else

                    'Me.UpdatePanel.ResponseScripts.Add("enableSend();")
                    Me.RadToolbarAlertNew.FindItemByValue("Send").Enabled = True

                End If

            Case "Clear"

                Me.ResetForm()

            Case "Cancel"

                If Request.QueryString("content") = "1" Then

                    Me.CloseThisWindowNew()

                Else

                    Me.CloseThisWindow()

                End If

        End Select
    End Sub
    Private Sub ChkIsAlertAssignment_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkIsAlertAssignment.CheckedChanged

        Me.SetAlertOrAssignment()
        Me.SetDefaultSubject()

    End Sub
    Private Sub RadioNotifyEmployeesTask_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioNotifyEmployeesTask.CheckedChanged

        Me.SetAlertRecipientsForNotifyEmployeeTask()

    End Sub
    Private Sub RadioNotifyEmployeesAssigned_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioNotifyEmployeesAssigned.CheckedChanged
        Try
            If Me.JobNumber = 0 Or Me.JobComponentNbr = 0 Then
                Me.JobNumber = CType(Me.txtJob.Text, Integer)
                Me.JobComponentNbr = CType(Me.txtComponent.Text, Integer)
            End If
        Catch ex As Exception
            Me.JobNumber = 0
            Me.JobComponentNbr = 0
        End Try
        If Me.RadioNotifyEmployeesAssigned.Checked = True And Me.JobNumber > 0 And Me.JobComponentNbr > 0 Then
            Dim str As String = ""
            Me.AutoCompleteRecipients.Clear()      'Me.TxtRecipients.Value = ""
            Dim s As New cSchedule(Session("ConnString"), Session("UserCode"))
            Dim dt As New DataTable
            dt = s.NotifyGetEmailGroup(Me.JobNumber, Me.JobComponentNbr, "", True)
            Try

                For i As Integer = 0 To dt.Rows.Count - 1
                    str &= dt.Rows(i)("EMP_CODE") & ","
                Next

            Catch ex As Exception
                Me.ShowMessage(AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString))
            End Try

            'check assignments...
            Dim dt2 As DataTable = s.GetScheduleHeader(Me.JobNumber, Me.JobComponentNbr, Session("UserCode").ToString(), False).Tables(0)
            If dt2.Rows.Count > 0 Then
                If Not dt2.Rows(0)("ASSIGN_1").ToString.Trim = "" Then
                    str &= dt2.Rows(0)("ASSIGN_1") & ","
                End If
                If Not dt2.Rows(0)("ASSIGN_2").ToString.Trim = "" Then
                    str &= dt2.Rows(0)("ASSIGN_2") & ","
                End If
                If Not dt2.Rows(0)("ASSIGN_3").ToString.Trim = "" Then
                    str &= dt2.Rows(0)("ASSIGN_3") & ","
                End If
                If Not dt2.Rows(0)("ASSIGN_4").ToString.Trim = "" Then
                    str &= dt2.Rows(0)("ASSIGN_4") & ","
                End If
                If Not dt2.Rows(0)("ASSIGN_5").ToString.Trim = "" Then
                    str &= dt2.Rows(0)("ASSIGN_5") & ","
                End If
                If IsDBNull(dt2.Rows(0)("EMP_CODE_AE")) = False Then
                    str &= dt2.Rows(0)("EMP_CODE_AE") & ","
                End If
            End If

            str = MiscFN.CleanStringForSplit(str, ",")

            'Me.TxtRecipients.Value = str
            Me.AutoCompleteRecipients.AddEntries(str)

        End If
    End Sub
    Private Sub RadioNotifyNext_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioNotifyNext.CheckedChanged
        Try
            If Me.JobNumber = 0 Or Me.JobComponentNbr = 0 Then
                Me.JobNumber = CType(Me.txtJob.Text, Integer)
                Me.JobComponentNbr = CType(Me.txtComponent.Text, Integer)
            End If
        Catch ex As Exception
            Me.JobNumber = 0
            Me.JobComponentNbr = 0
        End Try
        If Me.RadioNotifyNext.Checked = True And Me.JobNumber > 0 And Me.JobComponentNbr > 0 Then
            'Me.TxtRecipients.Value = ""
            Dim s As New cSchedule(Session("ConnString"), Session("UserCode"))
            'TxtRecipients.Value = s.NotifyGetNextEmployeesList(Me.JobNumber, Me.JobComponentNbr)
            Me.AutoCompleteRecipients.AddEntries(s.NotifyGetNextEmployeesList(Me.JobNumber, Me.JobComponentNbr))
        End If
    End Sub
    Private Sub RadioNotifyAlertGroup_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioNotifyAlertGroup.CheckedChanged
        'if it is the only one visible, then run it with out the "checked" check
        If Me.RadioNotifyAlertGroup.Visible = True And
            Me.RadioNotifyEmployeesAssigned.Visible = False And
            Me.RadioNotifyEmployeesTask.Visible = False And
            Me.RadioNotifyNext.Visible = False Then

            Me.RadioNotifyAlertGroup.Checked = True

        End If
        If Me.RadioNotifyAlertGroup.Checked = True Then
            Dim str As String = ""
            Me.AutoCompleteRecipients.Clear() 'Me.TxtRecipients.Value = ""
            Select Case Me.RadComboBoxAlertLevel.SelectedValue
                'Case "JO", "JC", "ES", "EST", "PS", "PST"
                '    Dim s As New cSchedule(Session("ConnString"), Session("UserCode"))
                '    Dim DtDefaultGroup As New DataTable
                '    DtDefaultGroup = s.NotifyGetEmailGroup(Me.JobNumber, Me.JobComponentNbr, "", False)
                '    Try
                '        For i As Integer = 0 To DtDefaultGroup.Rows.Count - 1
                '            str &= DtDefaultGroup.Rows(i)("EMP_CODE") & ","
                '        Next
                '        str = MiscFN.RemoveDuplicatesFromString(str, ",")
                '        str = MiscFN.RemoveTrailingDelimiter(str, ",")
                '    Catch ex As Exception
                '        Me.TxtRecipients.Value = "Error getting default recipients!"
                '    End Try
                Case "CM"
                    If Me.CmpIdentifier = 0 Then
                        Dim j As New cJobs(Session("ConnString"))
                        Me.CmpIdentifier = j.GetCampaignIdentifier(Me.txtCampaign.Text.Trim(), Me.txtClient.Text, Me.txtDivision.Text, Me.txtProduct.Text)
                    End If
                    If Me.CmpIdentifier > 0 Then
                        Dim cmp As New cCampaign(Session("ConnString"), Me.CmpIdentifier)
                        str = cmp.GetDfltAlertGroupMembers(Me.CmpIdentifier)
                    End If
                Case Else
                    Try
                        If Me.JobNumber = 0 Or Me.JobComponentNbr = 0 Then
                            Me.JobNumber = CType(Me.txtJob.Text, Integer)
                            Me.JobComponentNbr = CType(Me.txtComponent.Text, Integer)
                        End If
                    Catch ex As Exception
                        Me.JobNumber = 0
                        Me.JobComponentNbr = 0
                    End Try
                    If Me.JobNumber > 0 And Me.JobComponentNbr > 0 Then
                        Dim s As New cSchedule(Session("ConnString"), Session("UserCode"))
                        Dim DtDefaultGroup As New DataTable
                        DtDefaultGroup = s.NotifyGetEmailGroup(Me.JobNumber, Me.JobComponentNbr, "", False)
                        Try
                            For i As Integer = 0 To DtDefaultGroup.Rows.Count - 1
                                str &= DtDefaultGroup.Rows(i)("EMP_CODE") & ","
                            Next
                            str = MiscFN.RemoveDuplicatesFromString(str, ",")
                            str = MiscFN.RemoveTrailingDelimiter(str, ",")
                        Catch ex As Exception
                            Me.ShowMessage("Error getting default alert group!")
                        End Try
                    End If
            End Select
            'Me.TxtRecipients.Value = str
            Me.AutoCompleteRecipients.AddEntries(str)
        End If
        Me.SetEmailOrAlert()
    End Sub
    Private Sub RadioAlert_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioAlert.CheckedChanged

        Me.SetEmailOrAlert()

    End Sub
    Private Sub RadioEmail_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioEmail.CheckedChanged

        Me.SetEmailOrAlert()

    End Sub
    Private Sub RadComboBoxAssignTo_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxAssignTo.SelectedIndexChanged

    End Sub
    Private Sub ImageButtonRefreshDetails_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonRefreshDetails.Click

        Me.CheckForBoard()
        Me.LoadVersionAndBuild()
        Me.LoadLinkableDocuments()

    End Sub
    Private Sub ImageButtonContacts_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonContacts.Click
        Try
            If Me.TrJob.Visible = True And Me.TrComponent.Visible = True And Me.TrClient.Visible = True And Me.TrDivision.Visible = True And Me.TrProduct.Visible = True Then
                Me.OpenWindow("Contacts", "popContacts.aspx?from=newalert&client=" & Me.txtClient.Text & "&division=" & Me.txtDivision.Text & "&product=" & Me.txtProduct.Text & "&j=" & Me.txtJob.Text & "&jc=" & Me.txtComponent.Text, 1200, 400)
                'Me.ImageButtonContacts.Attributes.Add("onclick", "window.open('popContacts.aspx?from=newalert&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&j=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jc=' + document.forms[0]." & Me.txtComponent.ClientID & ".value, 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=700,height=200,scrollbars=1,resizable=no,menubar=no,maximazable=no');return false;")
            ElseIf Me.TrJob.Visible = True And Me.TrComponent.Visible = True Then
                Me.OpenWindow("Contacts", "popContacts.aspx?from=newalert&client=&division=&product=&j=" & Me.txtJob.Text & "&jc=" & Me.txtComponent.Text, 1200, 400)
                'Me.ImageButtonContacts.Attributes.Add("onclick", "window.open('popContacts.aspx?from=newalert&client=&division=&product=&j=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jc=' + document.forms[0]." & Me.txtComponent.ClientID & ".value, 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=700,height=200,scrollbars=1,resizable=no,menubar=no,maximazable=no');return false;")
            End If

        Catch ex As Exception
        End Try
    End Sub
    Private Sub ImageButtonRefreshLinkDocumentsListBox_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonRefreshLinkDocumentsListBox.Click

        Me.LoadLinkableDocuments()

    End Sub
    Private Sub LinkButtonEmailRecipientsTO_Click(sender As Object, e As EventArgs) Handles LinkButtonEmailRecipientsTO.Click

        Me.OpenEmailRecipientsWindow(Me.PO_RefId)

    End Sub
    Private Sub LinkButtonEmailRecipientsCC_Click(sender As Object, e As EventArgs) Handles LinkButtonEmailRecipientsCC.Click

        Me.OpenEmailRecipientsWindow(0)

    End Sub
    Private Sub LinkButtonEmailRecipientsBCC_Click(sender As Object, e As EventArgs) Handles LinkButtonEmailRecipientsBCC.Click

        Me.OpenEmailRecipientsWindow(0)

    End Sub
    Private Sub ChkUploadToRepository_CheckedChanged(sender As Object, e As EventArgs) Handles ChkUploadToRepository.CheckedChanged

        If CheckBoxUploadToProofHQ.Visible Then

            CheckBoxUploadToProofHQ.Enabled = ChkUploadToRepository.Checked

            If CheckBoxUploadToProofHQ.Enabled = False Then

                CheckBoxUploadToProofHQ.Checked = False

            End If

        End If

    End Sub

#End Region
#Region " Page "

    Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        Me.AllowFloat = False
        Me.ConnectionString = Session("ConnString")
        Me.EmployeeCode = Session("EmpCode")
        Me.SetQSVars()

        If Not Me.Page.IsPostBack And Not Me.Page.IsCallback Then

            Dim m As New DocumentRepository("", True)
            If m.SetRadAsyncUpload(Me.RadUploadAlertDocuments, True, Me.LabelFileSizeLimitMessage.Text) = False Then

                'Me.ShowMessage(Me.LabelFileSizeLimitMessage.Text)
                Me.LabelFileSizeLimitMessage.CssClass = "warning"

            End If

        End If

    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        If Not Me.Page.IsPostBack And Not Me.Page.IsCallback Then

            Me.SetRadDatePicker(Me.RadDatePickerStartDate)
            Me.SetRadDatePicker(Me.RadDatePickerDueDate)

            Me.RadToolbarAlertNew.FindItemByValue("Send").ToolTip = "Send email and alert recipients"
            Me.RadToolbarAlertNew.FindItemByValue("SaveDraft").ToolTip = "Save as draft to send later"

            Me.ResetForm()

            If Me.SendOnly = True Then

                'Me.FsAllowEmail.Visible = True
                Me.RadioAlert.Checked = True
                Me.RadioEmail.Checked = False
                Me.SetEmailOrAlert()

            Else 'default to alert

                Me.FsAllowEmail.Visible = False
                Me.RadioAlert.Checked = True
                Me.RadioEmail.Checked = False

            End If
            If Me.AutoSetToAssignment = True Then

                Me.ChkIsAlertAssignment.Checked = True
                Me.SetAlertOrAssignment()
                'TEST: Me.FsAlertRecipients.Visible = False

            End If

        End If

        Select Case Me.App
            Case Source_App.Alert
                Me.AlertLevel = ""
            Case Source_App.Campaign
                Me.AlertLevel = "CM"
            Case Source_App.Desktop
                Me.AlertLevel = "DT"
            Case Source_App.Estimate
                Me.AlertLevel = "ES"
            Case Source_App.EstimateComponent
                Me.AlertLevel = "EST"
            Case Source_App.JobJacket, Source_App.JobJacketAlerts
                Me.AlertLevel = "JJ" '"JO" 'JJ ???????????????????????????????????????????????????????????????
                Me.DivRepositoryAndProofHQCheckBoxes.Visible = True
                'Case Source_App.JobJacketAlerts
            Case Source_App.ProjectSchedule, Source_App.ProjectSchedule_Alerts
                Me.AlertLevel = "PS"
                Me.DivRepositoryAndProofHQCheckBoxes.Visible = True
            Case Source_App.PurchaseOrder
                Me.AlertLevel = "PO"
            Case Source_App.MediaATB
                Me.AlertLevel = "AB"
            Case Source_App.JobVersion
                Me.AlertLevel = "JR"
            Case Else
                Me.AlertLevel = ""
        End Select

        If Not Me.Page.IsPostBack And Not Me.Page.IsCallback Then

            'Page.ClientTarget = "Uplevel" ' Enables client side validation
            Me.hlOffice.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=newalert&control=" & Me.txtOffice.ClientID & "&type=office&ddtype=client');return false;")
            Me.hlClient.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=newalert&control=" & Me.txtClient.ClientID & "&type=client&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value);return false;")
            Me.hlDivision.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=newalert&control=" & Me.txtDivision.ClientID & "&type=divisionjj&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value);return false;")
            Me.hlProduct.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=newalert&control=" & Me.txtProduct.ClientID & "&type=product&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value);return false;")
            Me.hlCampaign.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?calledfrom=custom&form=newalert&type=campaign&control=" & Me.txtCampaign.ClientID & "&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value);return false;")
            Me.hlJob.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=newalert&type=job&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&office=' + document.forms[0]." & Me.txtOffice.ClientID & ".value);return false;")
            Me.hlComponent.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=newalert&type=jobcompnewalert&control=" & txtComponent.ClientID & "&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtComponent.ClientID & ".value);return false;")
            Me.hlMediaATB.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=newalert&control=" & Me.txtMediaATB.ClientID & "&type=atbmedia&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&atbmedia=' + document.forms[0]." & Me.txtMediaATB.ClientID & ".value);return false;")

            Me.LoadListCategories()
            Dim a As New cAlerts()
            a.LoadPrioritiesComboBox(Me.RadComboBoxPriority, True)
            Me.BindRadComboBoxAlertLevel()

            Me.LoadAlertAssignmentTemplates()

            Select Case Me.App

                Case Source_App.JobJacket, Source_App.JobJacketAlerts

                    Me.RadComboBoxAlertLevel.Items.FindItemByValue("JC").Selected = True
                    Me.txtJob.Text = Me.JobNumber.ToString()
                    Me.txtComponent.Text = Me.JobComponentNbr.ToString()
                    Me.RadComboBoxAlertLevel.Enabled = False

                Case Source_App.JobJacketMultiPrint

                    Me.RadComboBoxAlertLevel.Items.FindItemByValue("JC").Selected = True
                    Me.txtJob.Text = Me.JobNumber.ToString()
                    Me.txtComponent.Text = Me.JobComponentNbr.ToString()
                    Me.ChangeAlertLevel("JC")

                Case Source_App.ProjectSchedule, Source_App.ProjectSchedule_Alerts

                    Me.RadComboBoxAlertLevel.Items.FindItemByValue("PS").Selected = True
                    Me.RadComboBoxAlertLevel.Enabled = False
                    Me.txtJob.Text = Me.JobNumber.ToString()
                    Me.txtComponent.Text = Me.JobComponentNbr.ToString()
                    Me.SetProjectScheduleDefault(False)

                Case Source_App.Campaign

                    Me.RadComboBoxAlertLevel.Items.FindItemByValue("CM").Selected = True
                    Me.RadComboBoxAlertLevel.Enabled = False
                    Me.SetCampaignDefault(False)

                Case Source_App.Estimate

                    Me.RadComboBoxAlertLevel.Items.FindItemByValue("ES").Selected = True
                    Me.RadComboBoxAlertLevel.Enabled = False
                    Me.SetEstimateDefault(False)

                Case Source_App.EstimateComponent

                    Me.RadComboBoxAlertLevel.Items.FindItemByValue("EST").Selected = True
                    Me.RadComboBoxAlertLevel.Enabled = False
                    Me.SetEstimateComponentDefault(False)

                Case Source_App.PurchaseOrder

                    Me.RadComboBoxAlertLevel.Items.FindItemByValue("PO").Selected = True
                    Me.RadComboBoxAlertLevel.Enabled = False
                    Me.SetPurchaseOrderDefault()

                Case Source_App.Alert

                    Me.ChangeAlertLevel("")

                Case Source_App.MediaATB

                    Me.txtMediaATB.Text = Me.ATBNumber.ToString
                    Me.txtMediaATBRev.Text = Me.ATBRevisionNumber.ToString
                    Me.RadComboBoxAlertLevel.Items.FindItemByValue("AB").Selected = True
                    Me.RadComboBoxAlertLevel.Enabled = False
                    Me.SetMediaATBDefault()

                Case Source_App.JobVersion

                    If IsClientPortal = True Then

                        Me.RadComboBoxAlertLevel.Items.FindItemByValue("CL").Selected = True

                    Else

                        Me.RadComboBoxAlertLevel.Items.FindItemByValue("PR").Selected = True

                    End If

                    Me.RadioEmail.Enabled = False

                Case Else

                    Me.ChangeAlertLevel("")

            End Select

            If Me.JobNumber > 0 And Me.JobComponentNbr > 0 Then

                Me.LoadLinkableDocuments()

            End If

            Me.SetRadioNotify()

            'SET the pdf checkbox
            If Me.App <> Source_App.ProjectSchedule Then

                Try

                    Dim dt As New DataTable
                    dt = a.GetAgencyPDFSettings()

                    If Not dt Is Nothing Then

                        If dt.Rows.Count > 0 Then

                            Dim PDF_Alert_Only As Integer = dt.Rows(0)("PDF_ALERT_ONLY")
                            Dim Email_Attach_Def As Integer = dt.Rows(0)("EMAIL_ATTACH_DEF")

                            If PDF_Alert_Only = 0 And Email_Attach_Def = 0 Then

                                With Me.ChkExcludeAttachmentFromEmail
                                    .Checked = False
                                    .Enabled = True
                                End With

                            ElseIf PDF_Alert_Only = 0 And Email_Attach_Def = 1 Then

                                With Me.ChkExcludeAttachmentFromEmail
                                    .Checked = True
                                    .Enabled = True
                                End With

                            ElseIf PDF_Alert_Only = 1 Then

                                With Me.ChkExcludeAttachmentFromEmail
                                    .Checked = True
                                    .Enabled = False
                                End With

                            End If

                        End If

                    End If

                Catch ex As Exception

                End Try

            End If

            Me.CheckBoxUploadDocumentsToJob.Enabled = Me.ChkExcludeAttachmentFromEmail.Checked

        Else 'It is a postback

            If IsNumeric(Me.txtJob.Text) = True Then Me.JobNumber = CType(Me.txtJob.Text, Integer)
            If IsNumeric(Me.txtComponent.Text) = True Then Me.JobComponentNbr = CType(Me.txtComponent.Text, Integer)

            Select Case Me.EventArgument

                Case "RefreshState"

                    If Me.IsAlertAssignment = True AndAlso Me.JobNumber > 0 And Me.JobComponentNbr > 0 Then

                        Me.LoadAlertStates(Me.JobNumber, Me.JobComponentNbr)

                    End If

                Case "GetDefaultAssignment"

                    If Me.IsAlertAssignment = True Then

                        Dim HasPreset As Boolean = Me.PreSetAlertAssignment(True)
                        Me.ReloadAutoRecipientControl()

                        If HasPreset = False Then

                            Me.AutoCompleteRecipients.FocusTextBox()

                        End If

                    End If

                Case "ReloadAutoRecipientControl"

                    Me.ReloadAutoRecipientControl()
                    Me.FocusControl(Me.txtDivision)

            End Select

        End If

        'allow RadComboBoxAlertLevel to override QS
        'RadComboBoxAlertLevel is set automatically above when creating "pre-set" new alerts
        If Not Me.Page.IsPostBack And Not Me.Page.IsCallback Then

            If Me.RadComboBoxAlertLevel.Items.Count > 0 Then

                If Me.RadComboBoxAlertLevel.SelectedIndex > -1 Then

                    Me.AlertLevel = Me.RadComboBoxAlertLevel.SelectedValue
                    Me.ChangeAlertLevel(Me.AlertLevel)

                End If

            End If

        End If

        'allow defaults to override the override
        If Not Me.Page.IsPostBack And Not Me.Page.IsCallback Then
            Select Case Me.App
                Case Source_App.JobJacket, Source_App.JobJacketAlerts
                Case Source_App.ProjectSchedule, Source_App.ProjectSchedule_Alerts
                    Me.SetProjectScheduleDefault(False)
                Case Source_App.Campaign
                    Me.SetCampaignDefault(False)
                Case Source_App.Estimate
                    Me.SetEstimateDefault(False)
                Case Source_App.EstimateComponent
                    Me.SetEstimateComponentDefault(False)
                Case Source_App.Alert
                Case Source_App.PurchaseOrder
                    Me.SetPurchaseOrderDefault()
                Case Source_App.VendorQuote
                    Me.SetVendorQuoteDefault()
                Case Source_App.MediaATB
                    Me.SetMediaATBDefault()
                Case Source_App.JobVersion
                    SetJobRequestCDP()
                Case Else
            End Select

        End If

        Me.SetAlertLevelPanels()

        If Not Me.Page.IsPostBack And Not Me.Page.IsCallback Then
            If Me.SendOnly = True Then

                Me.PopulateEmailSubject()

            Else

                If Me.App = Source_App.JobJacket Then

                    Me.PopulateEmailSubject()

                End If

            End If
            If Me.App = Source_App.Estimate Or Me.App = Source_App.EstimateComponent Then
                With Me.CheckBoxIncludeEstimateHtml
                    .Checked = False
                    .Visible = True
                End With
            End If
        End If

        If Me.App = Source_App.ProjectSchedule Then
            With Me.ChkExcludeAttachmentFromEmail
                .Checked = False
                .Visible = False
            End With
            If Me.IsAlertAssignment = False Then
                With Me.ChkIncludeProjectScheduleReport
                    .Visible = True
                End With
                With Me.CheckBoxIncludeProjectScheduleInHTML
                    .Visible = True
                End With
            End If
        End If

        If Not Me.Page.IsPostBack And Not Me.Page.IsCallback Then

            If Me.AutoSetToAssignment = True Then

                Me.ChkIsAlertAssignment.Checked = True
                Me.SetAlertOrAssignment()
                'TEST: Me.FsAlertRecipients.Visible = False

            End If
            If _CopyFromAlertID > 0 Then

                FieldsetCopyOptions.Visible = True
                LoadAlertForCopy(_CopyFromAlertID)

            End If
            If Me._DraftAlertID > 0 Then

                Me.LoadAlertDraft()

            Else

                Me.LoadVersionAndBuild()

            End If

        Else

            Select Case Me.EventTarget
                Case "SetAutoCompleteEntries"
                    If Me.EventArgument <> "" Then
                        Me.AutoCompleteRecipients.AddEntries(Me.EventArgument)
                    End If
            End Select

        End If

        Me.AutoCompleteRecipients.UseWebservice = False

        Me.AutoCompleteRecipients.IsAssignment = Me.CheckboxIsAssignment.Checked

        If Me.txtClient.Text.Trim() <> "" Then Me.AutoCompleteRecipients.ClientCode = Me.txtClient.Text.Trim()
        If Me.txtDivision.Text.Trim() <> "" Then Me.AutoCompleteRecipients.DivisionCode = Me.txtDivision.Text.Trim()
        If Me.txtProduct.Text.Trim() <> "" Then Me.AutoCompleteRecipients.ProductCode = Me.txtProduct.Text.Trim()
        If IsNumeric(Me.txtJob.Text) = True Then Me.AutoCompleteRecipients.JobNumber = CType(Me.txtJob.Text, Integer)
        If IsNumeric(Me.txtComponent.Text) = True Then Me.AutoCompleteRecipients.JobComponentNumber = CType(Me.txtComponent.Text, Integer)

        If Me.AutoCompleteRecipients.JobNumber = 0 Then Me.AutoCompleteRecipients.JobNumber = Me.CurrentQuerystring.JobNumber
        If Me.AutoCompleteRecipients.JobComponentNumber = 0 Then Me.AutoCompleteRecipients.JobComponentNumber = Me.CurrentQuerystring.JobComponentNumber

    End Sub
    Private Sub Page_LoadComplete(sender As Object, e As System.EventArgs) Handles Me.LoadComplete

        'objects
        Dim IsProofHQEnabled As Boolean = False

        If Not Me.IsPostBack And Not Me.IsCallback Then

            'Me.SetAlertLevelPanels()

            Select Case Me.App
                Case Source_App.JobJacket, Source_App.JobJacketAlerts
                    If Me.IsClientPortal = True Or Request.QueryString("fromapp") = "jobsearchmul" Then
                        Me.ChkIsAlertAssignment.Visible = False
                    End If
                Case Source_App.ProjectSchedule, Source_App.ProjectSchedule_Alerts
                    Me.SetProjectScheduleDefault(False)
                    With Me.ChkExcludeAttachmentFromEmail
                        .Checked = False
                        .Visible = False
                    End With
                    Me.ChkIncludeProjectScheduleReport.Visible = True ' Not Me.IsAlertAssignment
                    Me.CheckBoxIncludeProjectScheduleInHTML.Visible = Not Me.IsAlertAssignment
                Case Source_App.Campaign
                    Me.SetCampaignDefault(False)
                Case Source_App.Estimate
                    Me.SetEstimateDefault(False)
                Case Source_App.EstimateComponent
                    Me.SetEstimateComponentDefault(False)
                Case Source_App.Alert
                Case Source_App.PurchaseOrder
                    Me.SetPurchaseOrderDefault()
                Case Source_App.VendorQuote
                    Me.SetVendorQuoteDefault()
                Case Source_App.MediaATB
                    Me.SetMediaATBDefault()
                Case Else
            End Select

        End If

        If Me.IsClientPortal = True Then

            Me.ChkIsAlertAssignment.Visible = False
            Me.TrLinkDocuments.Visible = False
            Me.hlClient.Attributes.Remove("href")
            Me.LabelAttachment.Text = "Add Attachments"

        End If

        Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

            IsProofHQEnabled = AdvantageFramework.ProofHQ.IsProofHQEnabled(DataContext)

        End Using

        ChkUploadToRepository.AutoPostBack = CheckBoxUploadToProofHQ.Visible

        If Not Me.IsPostBack And Not Me.IsCallback Then

            If IsNumeric(Me.txtJob.Text) = True Then Me.JobNumber = CType(Me.txtJob.Text, Integer)
            If IsNumeric(Me.txtComponent.Text) = True Then Me.JobComponentNbr = CType(Me.txtComponent.Text, Integer)

            If ((Me.AlertLevel = "JO" Or Me.AlertLevel = "JC" Or Me.AlertLevel = "JJ") And
                (Me.JobNumber = 0 Or Me.JobComponentNbr = 0)) Or Me.App = Source_App.AlertInbox Then

                Me.RadComboBoxAlertLevel.Enabled = True

                Me.AlertLevel = "JC"
                Me.SetAlertLevel(AlertLevel)
                Me.hlComponent.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=newalert&type=jobcompnewalert&control=" & txtComponent.ClientID & "&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.txtComponent.ClientID & ".value);return false;")

                If Me.JobNumber = 0 Then

                    Me.txtJob.Text = ""
                    Me.txtComponent.Text = ""

                End If
                If Me.JobComponentNbr = 0 Then

                    Me.txtComponent.Text = ""

                End If

            End If

        End If

        If Me.IsAlertAssignment = True Then

            Me.LabelRecipients.Text = "CC Recipients:"

        Else

            Me.LabelRecipients.Text = "Alert Recipients:"

        End If

        If Not Me.IsPostBack And Not Me.IsCallback Then

            If Me.AutoSetToEmail = True Then

                Me.RadioAlert.Checked = False
                Me.RadioEmail.Checked = True
                Me._SetEmailOrAlert()

            End If

            If Me.txtClient.ReadOnly = False Then Me.txtClient.Attributes.Add("onblur", "ReloadAutoRecipientControl();")

        End If

        Me.FsAllowEmail.Visible = False
        Me.ChkIsAlertAssignment.Visible = False

        Me.Title = "New Alert"
        If Me.RadioEmail.Checked = True Then Me.Title = "New Email"
        If Me.ChkIsAlertAssignment.Checked = True Then Me.Title = "New Assignment"
        loadDescriptions()

    End Sub

#End Region
#Region " Email "

    'normal alert/assignment uses this one
    Private Function SendEmailAlert(ByVal AlertID As Integer, ByVal ExcludeAttachments As Boolean, ByVal IncludeProjectSchedule As Boolean) As Boolean
        Dim impersonationContext As System.Security.Principal.WindowsImpersonationContext
        If IsNTAuth = True Then
            Me.currentWindowsIdentity = CType(HttpContext.Current.User.Identity, System.Security.Principal.WindowsIdentity)
            impersonationContext = Me.currentWindowsIdentity.Impersonate()
        End If

        Dim alert As New Alert(Session("ConnString"))
        alert.LoadByPrimaryKey(AlertID)
        Dim bool As Boolean
        Try
            Dim IsPST As Boolean = False
            If alert.ALERT_LEVEL = "PST" Then

                IsPST = True

            End If

            Dim EmailEmpCodes As String = Me.AutoCompleteRecipients.GetCommaDelimitedStringOfEmployeeCodes() 'Me.TxtRecipients.Value

            If Me.ChkIsAlertAssignment.Checked = True AndAlso Me.RadComboBoxAssignTo.SelectedIndex > 1 Then

                EmailEmpCodes &= ", " & Me.RadComboBoxAssignTo.SelectedValue

            End If
            If Me.ChkIsAlertAssignment.Checked = False Then

                EmailEmpCodes &= ", " & Session("EmpCode")

            End If

            'bool = alert.SendEmail("[New Alert]", EmailEmpCodes, "", "", "", ExcludeAttachments, IsPST, Me.IsClientPortal, True)

            'If bool = False Then

            '    Me.ShowMessage(alert.getErrMsg)
            '    SendEmailAlert = False
            '    Return False

            'Else

            '    If alert.getErrMsg.ToString().Contains("Message exceeds maximum email size") Then

            '        Me.ShowMessage(alert.getErrMsg)

            '    End If

            '    SendEmailAlert = True

            'End If
            Dim ClientContactIdList As String = Me.AutoCompleteRecipients.GetCommaDelimitedStringOfClientContacts()
            Dim RecipientArrayCC() As String
            Dim ClientContactEmailAddresses As String = ""

            RecipientArrayCC = ClientContactIdList.Split(",")

            If Not RecipientArrayCC Is Nothing Then

                Dim oAlerts As New cAlerts(Session("ConnString"))

                For i = 0 To RecipientArrayCC.Length - 1

                    If IsNumeric(RecipientArrayCC(i)) = True Then

                        Dim codeID As Integer = RecipientArrayCC(i)

                        If oAlerts.GetCPAlertEmailFlag(codeID) = 1 Then

                            ClientContactEmailAddresses &= oAlerts.GetEmail(codeID) & ","

                        End If

                    End If
                Next

            End If

            Dim eso As New EmailSessionObject(HttpContext.Current.Session("ConnString"),
                                              HttpContext.Current.Session("UserCode"),
                                              Me._Session,
                                              HttpContext.Current.Session("WebvantageURL"),
                                              HttpContext.Current.Session("ClientPortalURL"))

            With eso

                .AlertId = AlertID
                .Subject = "[New Alert]"
                .EmployeeCodesToSendEmailTo = EmailEmpCodes
                .ClientPortalEmailAddressessToSendTo = MiscFN.CleanStringForSplit(ClientContactEmailAddresses, ",")
                .ExcludeAttachments = ExcludeAttachments
                .InsertEmailBodyAsAlertDescription = IsPST
                .IsClientPortal = Me.IsClientPortal
                .IncludeOriginator = True
                .SessionID = HttpContext.Current.Session.SessionID.ToString()
                .PhysicalApplicationPath = HttpContext.Current.Request.PhysicalApplicationPath
                .Send()

            End With

            Me.CheckForAsyncMessage()

        Catch ex As Exception

            Me.ShowMessage("Error: Alert Email not Sent.")
            SendEmailAlert = False

        End Try

        If IsNTAuth = True Then

            impersonationContext.Undo()

        End If

        Return True

    End Function
    'This is the path for a normal alert or assignment
    Private Sub SendAlertOrAlertAssignment()

        If Me.txtSubject.Text.Trim() = "" Then

            Me.ShowMessage("Please enter a Subject")
            Exit Sub

        End If

        Dim intAlertID As Integer = 0
        Dim blnReturn As Boolean = False
        Dim SendError As String = ""

        Me.Page.Validate()

        If Me.Page.IsValid Then

            Dim dueDate As String = ""
            Try

                If Me.RadDatePickerDueDate.SelectedDate.HasValue = True Then

                    dueDate = CType(Me.RadDatePickerDueDate.SelectedDate, Date).ToShortDateString()

                End If
            Catch ex As Exception
                dueDate = ""
            End Try

            If Me.CheckStartDueDate() = False Then Exit Sub

            intAlertID = SaveAlert()

            If intAlertID > 0 Then

                Dim generate As Boolean = Me.GenerateDocForAssignment(intAlertID, SendError)

                Dim impersonationContext As System.Security.Principal.WindowsImpersonationContext
                If IsNTAuth = True Then

                    Me.currentWindowsIdentity = CType(HttpContext.Current.User.Identity, System.Security.Principal.WindowsIdentity)
                    impersonationContext = Me.currentWindowsIdentity.Impersonate()

                End If

                CheckToCopyAlertCommentsAndAttachments(intAlertID)

                blnReturn = SendEmailAlert(intAlertID, Me.ChkExcludeAttachmentFromEmail.Checked, Me.ChkIncludeProjectScheduleReport.Checked)

                'If blnReturn = False Then

                '    Exit Sub

                'Else

                '    Exit Sub

                'End If

                Try

                    SqlHelper.ExecuteNonQuery(Session("ConnString"), CommandType.Text, String.Format("UPDATE ALERT SET IS_DRAFT = 0 WHERE ALERT_ID = {0};", intAlertID))

                Catch ex As Exception

                End Try

                If IsNTAuth = True Then

                    impersonationContext.Undo()

                End If

            End If

        End If

    End Sub
    'This is the path for sending an email alert (replacing popsend.aspx)
    '1. First generate docs, save the email/assignment, then send using next step
    Private Function SendEmailAlert(ByRef ErrorMessage As String) As Boolean

        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

        Try
            If PageType() <> "" Then

                Dim intAlertID As Integer = 0
                Dim sbBody As New System.Text.StringBuilder

                Dim sFileName As String = ""
                Dim sFileNameJS As String = ""
                Dim sFileNameJV As String = ""
                Dim sFileNameCB As String = ""
                Dim sFileNameEst As String = ""
                Dim sFileNameRFQ As String = ""
                Dim sFileNamePS As String = ""
                Dim a As New cAlerts()
                Dim PDF_Alert_Only As Integer = 0
                Try
                    Dim dt As New DataTable
                    dt = a.GetAgencyPDFSettings()
                    If Not dt Is Nothing Then
                        If dt.Rows.Count > 0 Then
                            PDF_Alert_Only = dt.Rows(0)("PDF_ALERT_ONLY")
                        End If
                    End If
                Catch ex As Exception
                End Try


                Select Case PageType()
                    Case "jt"
                        If Request.QueryString("fromapp") = "jobsearchmul" Then
                            Session("printjs") = CInt(Request.QueryString("printjs"))
                            Session("printjv") = CInt(Request.QueryString("printjv"))
                            Session("printcb") = CInt(Request.QueryString("printcb"))
                            Session("printjof") = CInt(Request.QueryString("printjof"))
                            If Me._MultipleJob = True Then
                                Dim filename As String
                                Dim filenameJS As String
                                Dim filenameJV As String
                                Dim filenameCB As String
                                Dim count As Integer = Session("ProjectScheduleJobCompCount")
                                Dim StrFilePrefix As String = Request.PhysicalApplicationPath & "TEMP\"
                                Select Case count
                                    Case 0
                                        Me.ShowMessage("No file(s) selected.")
                                    Case 1
                                        Dim jc() As String = Me._MultipleJobList.Split("/")
                                        Dim j As String = jc(0)
                                        Dim c As String = MiscFN.RemoveTrailingDelimiter(jc(1), ",")
                                        Dim strURL As String = "popReportViewer.aspx?job=" & j & "&jobcomp=" & c & "&ms=False&Type=1&Report=TrafficDetailByJob"
                                        Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
                                        strBuilder.Append("<script language='javascript'>")
                                        strBuilder.Append("window.open('" & strURL & "', '', 'screenX=150,left=150,screenY=150,top=150,width=1,height=1,scrollbars=yes,resizable=no,menubar=no,maximazable=no')")
                                        strBuilder.Append("</")
                                        strBuilder.Append("script>")
                                        Page.RegisterStartupScript("newpage", strBuilder.ToString())
                                    Case Is > 1
                                        Try
                                            Dim outputStream As New System.IO.MemoryStream
                                            Dim strfiles As String

                                            Dim RepositorySecuritySettings As New vDocumentRepositorySettings(Session("ConnString"))
                                            RepositorySecuritySettings.LoadAll()
                                            Dim ThisUserDomain As String = RepositorySecuritySettings.DOC_REPOSITORY_USER_DOMAIN
                                            Dim ThisUserName As String = RepositorySecuritySettings.DOC_REPOSITORY_USER_NAME

                                            Dim ThisUserPassword As String = AdvantageFramework.Security.Encryption.Decrypt(RepositorySecuritySettings.DOC_REPOSITORY_USER_PASSWORD)
                                            Dim ThisPath = RepositorySecuritySettings.DOC_REPOSITORY_PATH

                                            Dim impersonateUser As Boolean = False
                                            Dim AliasAccount As AliasAccount
                                            impersonateUser = ThisUserName <> ""

                                            If impersonateUser = True Then
                                                AliasAccount.BeginImpersonation(ThisUserName, ThisUserDomain, ThisUserPassword)
                                            End If

                                            Dim zip As New ZipFile

                                            Dim jc() As String = Me._MultipleJobList.Split(",")
                                            For i As Integer = 0 To jc.Length - 1
                                                Dim jobc As String
                                                jobc = jc(i)
                                                If jobc <> "" Then
                                                    Dim jobcomp() As String = jobc.Split("/")
                                                    Session("JobOrderFormJobNum") = jobcomp(0)
                                                    Session("JobOrderFormJobCompNum") = jobcomp(1)
                                                    If Session("printjof") IsNot Nothing AndAlso Session("printjof") = 1 AndAlso Me.ChkExcludeAttachmentFromEmail.Checked = False Then
                                                        sFileName = Me.OutputReportFileJT()
                                                    End If
                                                    If Session("printjs") IsNot Nothing AndAlso Session("printjs") = 1 AndAlso Me.ChkExcludeAttachmentFromEmail.Checked = False Then
                                                        filenameJS = Me.OutputReportFileJSAllVers()
                                                    End If
                                                    If Session("printjv") IsNot Nothing AndAlso Session("printjv") = 1 AndAlso Me.ChkExcludeAttachmentFromEmail.Checked = False Then
                                                        filenameJV = Me.OutputReportFileJVAllVers()
                                                    End If
                                                    If Session("printcb") IsNot Nothing AndAlso Session("printcb") = 1 AndAlso Me.ChkExcludeAttachmentFromEmail.Checked = False Then
                                                        filenameCB = Me.OutputReportFileCB()
                                                    End If
                                                    Dim f As IO.FileInfo
                                                    If sFileName <> "" Then
                                                        f = New IO.FileInfo(sFileName)
                                                        If f.Exists Then
                                                            zip.AddFile(sFileName, "")
                                                            strfiles &= sFileName & "|"
                                                        End If
                                                    End If
                                                    If filenameJS <> "" Then
                                                        f = New IO.FileInfo(filenameJS)
                                                        If f.Exists Then
                                                            zip.AddFile(filenameJS, "")
                                                            strfiles &= filenameJS & "|"
                                                        End If
                                                    End If
                                                    If filenameJV <> "" Then
                                                        f = New IO.FileInfo(filenameJV)
                                                        If f.Exists Then
                                                            zip.AddFile(filenameJV, "")
                                                            strfiles &= filenameJV & "|"
                                                        End If
                                                    End If
                                                    If filenameCB <> "" Then
                                                        f = New IO.FileInfo(filenameCB)
                                                        If f.Exists Then
                                                            zip.AddFile(filenameCB, "")
                                                            strfiles &= filenameCB & "|"
                                                        End If
                                                    End If
                                                End If
                                            Next

                                            zip.Save(Request.PhysicalApplicationPath.Trim() & "TEMP\Webvantage_Job_Templates__" & Today.Year.ToString() & Today.Month.ToString() & Today.Day.ToString() & ".zip")
                                            sFileName = Request.PhysicalApplicationPath.Trim() & "TEMP\Webvantage_Job_Templates__" & Today.Year.ToString() & Today.Month.ToString() & Today.Day.ToString() & ".zip"
                                            'zip.Save(Response.OutputStream)

                                            Dim str() As String = strfiles.Split("|")
                                            For x As Integer = 0 To str.Length - 1
                                                If str(x) <> "" Then
                                                    Try
                                                        My.Computer.FileSystem.DeleteFile(str(x).Trim)
                                                    Catch ex As Exception
                                                        'lbl_msg.Text = ex.Message.ToString
                                                    End Try
                                                    Try
                                                        Kill(str(x).Trim)
                                                    Catch ex As Exception
                                                        'lbl_msg.Text = ex.Message.ToString
                                                    End Try
                                                End If
                                            Next

                                            If impersonateUser = True Then
                                                AliasAccount.EndImpersonation()
                                            End If

                                            'Response.AddHeader("Content-Disposition", "inline;filename=Webvantage_Job_Templates__" & Today.Year.ToString() & Today.Month.ToString() & Today.Day.ToString() & ".zip")
                                            'Response.ContentType = "application/zip"
                                            'Response.Flush()
                                            'Response.End()
                                        Catch ex As Exception

                                        End Try
                                End Select
                            End If
                        Else
                            Session("printjs") = CInt(Request.QueryString("printjs"))
                            Session("printjv") = CInt(Request.QueryString("printjv"))
                            Session("printcb") = CInt(Request.QueryString("printcb"))
                            Session("printjof") = CInt(Request.QueryString("printjof"))
                            If Session("printjof") IsNot Nothing AndAlso Session("printjof") = 1 AndAlso Me.ChkExcludeAttachmentFromEmail.Checked = False Then
                                sFileName = Me.OutputReportFileJT()
                            End If
                            If Session("printjs") IsNot Nothing AndAlso Session("printjs") = 1 AndAlso Me.ChkExcludeAttachmentFromEmail.Checked = False Then
                                sFileNameJS = Me.OutputReportFileJSAllVers()
                            End If
                            If Session("printjv") IsNot Nothing AndAlso Session("printjv") = 1 AndAlso Me.ChkExcludeAttachmentFromEmail.Checked = False Then
                                sFileNameJV = Me.OutputReportFileJVAllVers()
                            End If
                            If Session("printcb") IsNot Nothing AndAlso Session("printcb") = 1 AndAlso Me.ChkExcludeAttachmentFromEmail.Checked = False Then
                                sFileNameCB = Me.OutputReportFileCB()
                            End If
                        End If
                    Case "po"
                        sFileName = Me.OutputReportFilePO()
                    Case "js"
                        sFileName = Me.OutputReportFileJS()
                    Case "jv", "jr"
                        sFileName = Me.OutputReportFileJV()
                    Case "cb"
                        sFileName = Me.OutputReportFileCB()
                    Case "est"
                        If Request.QueryString("combine") = 1 Then
                            sFileName = Me.OutputReportFileEST()
                        Else
                            Dim comp As Integer = 0
                            Dim qte As Integer = 0
                            Dim qtes As String
                            Dim qtedesc As String
                            Dim comps() As String = Request.QueryString("comps").Split(",")
                            Dim quotesEst() As String = Request.QueryString("quotes").Split(",")
                            Dim quotesDesc() As String = Session("EstimatingQteDescs").ToString.Split(",")
                            For i As Integer = 0 To comps.Length - 1
                                If comps(i) <> "" Then
                                    If comp > 0 And comp <> comps(i) Then
                                        Session("EstimatingQteDescs" & comp) = qtedesc
                                        sFileNameEst &= Me.OutputReportFileEST(comp, qtes) & ","
                                        qtes = ""
                                    End If
                                    comp = comps(i)
                                    qte = quotesEst(i)
                                    qtes &= qte & ","
                                    qtedesc &= quotesDesc(i) & ","
                                End If
                            Next
                            Session("EstimatingQteDescs" & comp) = qtedesc
                            sFileNameEst &= Me.OutputReportFileEST(comp, qtes) & ","
                            sFileNameEst = MiscFN.RemoveTrailingDelimiter(sFileNameEst, ",")
                        End If
                    Case "rfq"
                        sFileName = Me.OutputReportFileRFQ()
                    Case "cmp"
                        'sFileName = Me.OutputReportFileCMP()
                    Case "ps"
                        sFileName = Me.OutputReportFilePS()
                    Case "psg"
                        sFileName = Me.OutputReportFilePSExcel()
                    Case "psf", "psgf"
                        Dim StrFilePrefix As String = Request.PhysicalApplicationPath & "TEMP\"
                        Dim StrFilePrefixPS As String = Request.PhysicalApplicationPath & "TEMP\"

                        If Me.RadioEmail.Checked = True Then
                            If Me.ChkIncludeProjectScheduleReport.Checked = True Then
                                Dim r As cReports = New cReports(Session("ConnString"))
                                Dim StrFileDate As String = "__" & Now.Year.ToString() & Now.Month.ToString() & Now.Day.ToString() & Now.Hour.ToString() & Now.Minute.ToString
                                Dim StrFileType As String = ".pdf"
                                sFileName = "Project_Schedule_" & Me.JobNumber.ToString() & "_" & JobComponentNbr.ToString() & AdvantageFramework.StringUtilities.GUID_Date(True, True, True) & StrFileType
                                sFileNamePS = "Project_Schedule_2_" & Me.JobNumber.ToString() & "_" & JobComponentNbr.ToString() & AdvantageFramework.StringUtilities.GUID_Date(True, True, True) & StrFileType
                                Dim rpt As New popReportViewer
                                Try
                                    Dim ThisOptions As String = ""
                                    If Request.QueryString("from") = "sfuc" Then
                                        ThisOptions = Me.JobNumber.ToString() & "|" & Me.JobComponentNbr.ToString() & "|" & Request.QueryString("hours") & "|" & Request.QueryString("ms") & "|" & Request.QueryString("due") & "|" & Request.QueryString("excludeTC") & "|" & Request.QueryString("sort") & "|" & Request.QueryString("phase") & "|" & Request.QueryString("reso") & "|" & Request.QueryString("completed")
                                        If Request.QueryString("rpt") = "duedate" Then
                                            If rpt.renderDoc(StrFilePrefix & sFileNamePS, "TrafficDetailByJobDueDate", "", "", "", "", "", 1, "", ThisOptions, , ErrorMessage) = False Then
                                                Return False
                                            End If
                                            sFileNamePS = StrFilePrefixPS & sFileNamePS
                                        ElseIf Request.QueryString("rpt") = "dateres" Then
                                            If rpt.renderDoc(StrFilePrefix & sFileNamePS, "TrafficDetailByJob2", "", "", "", "", "", 1, "", ThisOptions, , ErrorMessage) = False Then
                                                Return False
                                            End If
                                            sFileNamePS = StrFilePrefixPS & sFileNamePS
                                        ElseIf Request.QueryString("rpt") = "job" Then
                                            If Request.QueryString("hours") = 1 Then
                                                If rpt.renderDoc(StrFilePrefix & sFileNamePS, "TrafficDetailByJob", "", "", "", "", "", 1, "", ThisOptions, , ErrorMessage) = False Then
                                                    Return False
                                                End If
                                                sFileNamePS = StrFilePrefixPS & sFileNamePS
                                            End If
                                        ElseIf Request.QueryString("rpt") = "calgantt" Then
                                            StrFilePrefixPS = ""
                                            StrFileType = ".xls"
                                            sFileNamePS = Me.OutputReportFilePSExcel()
                                        End If
                                        ThisOptions = Me.JobNumber.ToString() & "|" & Me.JobComponentNbr.ToString() & "||0"
                                        If rpt.renderDoc(StrFilePrefix & sFileName, "TrafficDetailByJob", "", "", "", "", "", 1, "", ThisOptions, , ErrorMessage) = False Then
                                            Return False
                                        End If
                                    Else
                                        ThisOptions = Me.JobNumber.ToString() & "|" & Me.JobComponentNbr.ToString() & "||0"
                                        If rpt.renderDoc(StrFilePrefix & sFileName, "TrafficDetailByJob", "", "", "", "", "", 1, "", ThisOptions, , ErrorMessage) = False Then
                                            Return False
                                        End If
                                    End If
                                    sFileName = StrFilePrefix & sFileName
                                Catch ex As Exception
                                    sFileName = ""
                                    sFileNamePS = ""
                                    ErrorMessage = MiscFN.JavascriptSafe(ex.Message.ToString())
                                    Return False
                                End Try
                            Else
                                Dim r As cReports = New cReports(Session("ConnString"))
                                Dim StrFileDate As String = "__" & Now.Year.ToString() & Now.Month.ToString() & Now.Day.ToString() & Now.Hour.ToString() & Now.Minute.ToString
                                Dim StrFileType As String = ".pdf"
                                sFileNamePS = "Project_Schedule_2_" & Me.JobNumber.ToString() & "_" & JobComponentNbr.ToString() & AdvantageFramework.StringUtilities.GUID_Date(True, True, True) & StrFileType
                                Dim rpt As New popReportViewer
                                Try
                                    Dim ThisOptions As String
                                    If Request.QueryString("from") = "sfuc" Then
                                        ThisOptions = Me.JobNumber.ToString() & "|" & Me.JobComponentNbr.ToString() & "|" & Request.QueryString("hours") & "|" & Request.QueryString("ms") & "|" & Request.QueryString("due") & "|" & Request.QueryString("excludeTC") & "|" & Request.QueryString("sort") & "|" & Request.QueryString("phase") & "|" & Request.QueryString("reso") & "|" & Request.QueryString("completed")
                                        If Request.QueryString("rpt") = "duedate" Then
                                            If rpt.renderDoc(StrFilePrefix & sFileNamePS, "TrafficDetailByJobDueDate", "", "", "", "", "", 1, "", ThisOptions, , ErrorMessage) = False Then
                                                Return False
                                            End If
                                            sFileNamePS = StrFilePrefixPS & sFileNamePS
                                        ElseIf Request.QueryString("rpt") = "dateres" Then
                                            If rpt.renderDoc(StrFilePrefix & sFileNamePS, "TrafficDetailByJob2", "", "", "", "", "", 1, "", ThisOptions, , ErrorMessage) = False Then
                                                Return False
                                            End If
                                            sFileNamePS = StrFilePrefixPS & sFileNamePS
                                        ElseIf Request.QueryString("rpt") = "job" Then
                                            If rpt.renderDoc(StrFilePrefix & sFileNamePS, "TrafficDetailByJob", "", "", "", "", "", 1, "", ThisOptions, , ErrorMessage) = False Then
                                                Return False
                                            End If
                                            sFileNamePS = StrFilePrefixPS & sFileNamePS
                                        ElseIf Request.QueryString("rpt") = "calgantt" Then
                                            StrFilePrefixPS = ""
                                            StrFileType = ".xls"
                                            sFileNamePS = Me.OutputReportFilePSExcel()
                                        End If
                                    Else
                                        sFileNamePS = ""
                                    End If
                                Catch ex As Exception
                                    sFileNamePS = ""
                                    ErrorMessage = MiscFN.JavascriptSafe(ex.Message.ToString())
                                    Return False
                                End Try
                            End If
                        End If
                    Case "atb"
                        sFileName = Me.OutputReportFileATB()
                End Select

                If Me.ValidateSave(ErrorMessage) = False Then
                    Return False
                End If

                If Me.RadioAlert.Checked = True Then

                    Dim strDocIdList As String = ""

                    intAlertID = SaveEmailAlert(sFileName, sFileNameJS, sFileNameJV, sFileNameEst, sFileNameCB, , strDocIdList, ErrorMessage)

                    If ErrorMessage <> "" Then
                        If intAlertID > 0 Then
                            ErrorMessage = "The Alert was saved, but there were errors. " & ErrorMessage
                        Else
                            ErrorMessage = "The Alert was not saved.  " & ErrorMessage
                        End If
                        Return False
                    End If

                    If intAlertID > 0 Then

                        CheckToCopyAlertCommentsAndAttachments(intAlertID)

                        Try

                            Dim currentWindowsIdentity1 As System.Security.Principal.WindowsIdentity
                            Dim impersonationContext1 As System.Security.Principal.WindowsImpersonationContext

                            If IsNTAuth = True Then

                                Me.currentWindowsIdentity = CType(HttpContext.Current.User.Identity, System.Security.Principal.WindowsIdentity)
                                impersonationContext1 = Me.currentWindowsIdentity.Impersonate()

                            End If

                            SqlHelper.ExecuteNonQuery(Session("ConnString"), CommandType.Text, String.Format("UPDATE ALERT SET IS_DRAFT = 0 WHERE ALERT_ID = {0};", intAlertID))

                            If IsNTAuth = True Then

                                impersonationContext1.Undo()

                            End If

                        Catch ex As Exception
                        End Try


                        If Me.ProcessEmails(sFileName.Trim(), intAlertID, sFileNameJS.Trim(), sFileNameJV.Trim(), sFileNameEst, sFileNameCB.Trim(), strDocIdList, , , ErrorMessage) = False Then

                            Return False

                        End If

                    End If

                ElseIf Me.RadioEmail.Checked = True Then

                    Dim Document As New Document(Session("ConnString"))
                    Dim Repository As New DocumentRepository(Session("ConnString"))
                    Dim StrDocIds As String = ""
                    Dim HasMultipleUploads As Boolean = False
                    If sFileName.Trim() <> "" And (sFileNameJS.Trim() <> "" Or sFileNameJV.Trim() <> "" Or sFileNameEst.Trim() <> "" Or sFileNameCB.Trim() <> "") Then
                        HasMultipleUploads = True
                    End If
                    Dim currentWindowsIdentity1 As System.Security.Principal.WindowsIdentity
                    Dim impersonationContext1 As System.Security.Principal.WindowsImpersonationContext
                    If Me.RadUploadAlertDocuments.UploadedFiles.Count > 0 Then 'And IsNTAUTH = False Then

                        If IsNTAuth = True Then

                            Me.currentWindowsIdentity = CType(HttpContext.Current.User.Identity, System.Security.Principal.WindowsIdentity)
                            impersonationContext1 = Me.currentWindowsIdentity.Impersonate()

                        End If

                        Dim doc As New DocumentRepository("", True)

                        If IsNTAuth = True Then

                            impersonationContext1.Undo()

                        End If

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                                For i = 0 To Me.RadUploadAlertDocuments.UploadedFiles.Count - 1

                                    Dim realFilename As String = Me.RadUploadAlertDocuments.UploadedFiles(i).GetName
                                    Dim MIMEType As String = ""

                                    If Not Me.RadUploadAlertDocuments.UploadedFiles(i).ContentType Is Nothing Then

                                        MIMEType = Me.RadUploadAlertDocuments.UploadedFiles(i).ContentType

                                    Else

                                        MIMEType = ""

                                    End If

                                    Dim FileLength As Integer = Me.RadUploadAlertDocuments.UploadedFiles(i).InputStream.Length
                                    Dim ThisFC As New DocumentRepository.FileCompare

                                    ThisFC.FileByteLength = CType(FileLength, Long)

                                    If DocumentRepository.RadAsyncUploadFileTypeIsValid(Me.RadUploadAlertDocuments.UploadedFiles(i)) = True AndAlso
                                        doc.IsOverFileSizeLimit(ThisFC) = False Then

                                        If FileLength > 0 Then

                                            Dim FileBytes(FileLength - 1) As Byte
                                            Me.RadUploadAlertDocuments.UploadedFiles(i).InputStream.Read(FileBytes, 0, FileLength)

                                            Dim UsePrefix As String = "a_"
                                            If Me.ChkUploadToRepository.Checked = True Then

                                                UsePrefix = "d_"

                                            Else

                                                UsePrefix = "a_"

                                            End If

                                            Dim RepositoryFilename As String = Repository.AddDocument(realFilename, FileBytes, "", "", Session("userCode"), "New Alert", "Attached Doc", UsePrefix)

                                            If IsNTAuth = True And HasMultipleUploads = True Then

                                                Me.currentWindowsIdentity = CType(HttpContext.Current.User.Identity, System.Security.Principal.WindowsIdentity)
                                                impersonationContext1 = Me.currentWindowsIdentity.Impersonate()

                                            End If
                                            Dim DocumentId As Integer = Document.Add(realFilename, MIMEType, RepositoryFilename, FileLength, Session("UserCode"), "", "")
                                            StrDocIds = StrDocIds & DocumentId.ToString() & ","

                                            If IsNumeric(Me.txtJob.Text) = True Then

                                                Me.JobNumber = CType(Me.txtJob.Text, Integer)

                                            End If
                                            If IsNumeric(Me.txtComponent.Text) = True Then

                                                Me.JobComponentNbr = CType(Me.txtComponent.Text, Integer)

                                            End If

                                            If Me.ChkUploadToRepository.Checked = True Then 'adds additional record to job doc table/job comp doc table so that doc shows up in the alert as well as the repository

                                                Try
                                                    Select Case Me.RadComboBoxAlertLevel.SelectedValue
                                                        Case "OF"

                                                            AdvantageFramework.DocumentManager.AddOfficeDocument(DbContext, Me.txtOffice.Text, DocumentId)

                                                        Case "CL"

                                                            AdvantageFramework.DocumentManager.AddClientDocument(DataContext, Me.txtClient.Text, DocumentId)

                                                        Case "DI"

                                                            AdvantageFramework.DocumentManager.AddDivisionDocument(DataContext, Me.txtClient.Text, Me.txtDivision.Text, DocumentId)

                                                        Case "PR"

                                                            AdvantageFramework.DocumentManager.AddProductDocument(DataContext, Me.txtClient.Text, Me.txtDivision.Text, Me.txtProduct.Text, DocumentId)

                                                        Case "CM"

                                                            If _CampaignID > 0 Then

                                                                AdvantageFramework.DocumentManager.AddCampaignDocument(DataContext, _CampaignID, DocumentId)

                                                            End If

                                                        Case "JO"

                                                            If Me.JobNumber > 0 Then

                                                                Dim DocumentJ As New JobDocument(Me.ConnectionString)
                                                                DocumentId = DocumentJ.Add(Me.JobNumber, realFilename, MIMEType, RepositoryFilename, FileLength, Session("UserCode"), "", "", 0, 2, DocumentId)

                                                            End If

                                                        Case "JC", "ES", "EST"

                                                            If Me.JobNumber > 0 And Me.JobComponentNbr > 0 Then

                                                                Dim DocumentJC As New JobComponentDocuments(Me.ConnectionString)
                                                                DocumentId = DocumentJC.Add(Me.JobNumber, Me.JobComponentNbr, realFilename, MIMEType, RepositoryFilename, FileLength, Session("UserCode"), "", "", 0, 2, DocumentId)

                                                            End If

                                                        Case "PST", "BRD"

                                                            AdvantageFramework.DocumentManager.AddTaskDocument(DataContext, Me.JobNumber, Me.JobComponentNbr, Me.TaskSeqNbr, DocumentId)

                                                    End Select
                                                Catch ex As Exception
                                                    ErrorMessage = ex.Message.ToString()
                                                End Try

                                                If DocumentId > 0 AndAlso CheckBoxUploadToProofHQ.Checked Then

                                                    UploadDocumentToProofHQ(DbContext, DataContext, DocumentId, Agency)

                                                End If

                                            End If

                                            If IsNTAuth = True And HasMultipleUploads = True Then
                                                impersonationContext1.Undo()
                                            End If

                                        End If

                                    End If

                                Next

                            End Using

                        End Using

                    End If

                    StrDocIds = MiscFN.RemoveTrailingDelimiter(StrDocIds, ",")

                    If PageType() = "jt" AndAlso CInt(Request.QueryString("printjof")) = 0 Then

                        If Me.ProcessEmails("", intAlertID, sFileNameJS.Trim(), sFileNameJV.Trim(), sFileNameEst, sFileNameCB.Trim(), sFileNameRFQ, StrDocIds, sFileNamePS, ErrorMessage) = False Then

                            Return False

                        End If

                    Else

                        If Me.ProcessEmails(sFileName.Trim(), intAlertID, sFileNameJS.Trim(), sFileNameJV.Trim(), sFileNameEst, sFileNameCB.Trim(), sFileNameRFQ, StrDocIds, sFileNamePS, ErrorMessage) = False Then

                            Return False

                        End If

                    End If

                End If

                Return True

            Else

                ErrorMessage = ""
                Return True

            End If
        Catch ex As Exception

            ErrorMessage = MiscFN.JavascriptSafe(ex.Message.ToString())
            Return False

        End Try
    End Function
    Private Function GenerateDocForAssignment(ByVal AlertID As Integer, ByRef ErrorMessage As String) As Boolean
        Try
            If PageType() <> "" Then

                Dim sFileName As String = ""
                Dim sFileNameJS As String = ""
                Dim sFileNameJV As String = ""
                Dim sFileNameCB As String = ""
                Dim sFileNameEst As String = ""
                Dim sFileNameRFQ As String = ""
                Dim sFileNamePS As String = ""

                If Me.ChkExcludeAttachmentFromEmail.Checked = True Then

                Else
                    Select Case PageType()
                        Case "jt"
                            Session("printjs") = CInt(Request.QueryString("printjs"))
                            Session("printjv") = CInt(Request.QueryString("printjv"))
                            Session("printcb") = CInt(Request.QueryString("printcb"))
                            Session("printjof") = CInt(Request.QueryString("printjof"))
                            If Session("printjof") IsNot Nothing AndAlso Session("printjof") = 1 AndAlso Me.ChkExcludeAttachmentFromEmail.Checked = False Then
                                sFileName = Me.OutputReportFileJT()
                            End If
                            If Session("printjs") IsNot Nothing AndAlso Session("printjs") = 1 AndAlso Me.ChkExcludeAttachmentFromEmail.Checked = False Then
                                sFileNameJS = Me.OutputReportFileJSAllVers()
                            End If
                            If Session("printjv") IsNot Nothing AndAlso Session("printjv") = 1 AndAlso Me.ChkExcludeAttachmentFromEmail.Checked = False Then
                                sFileNameJV = Me.OutputReportFileJVAllVers()
                            End If
                            If Session("printcb") IsNot Nothing AndAlso Session("printcb") = 1 AndAlso Me.ChkExcludeAttachmentFromEmail.Checked = False Then
                                sFileNameCB = Me.OutputReportFileCB()
                            End If
                        Case "po"
                            sFileName = Me.OutputReportFilePO()
                        Case "js"
                            sFileName = Me.OutputReportFileJS()
                        Case "jv", "jr"
                            sFileName = Me.OutputReportFileJV()
                        Case "cb"
                            sFileName = Me.OutputReportFileCB()
                        Case "est"
                            If Request.QueryString("combine") = 1 Then
                                sFileName = Me.OutputReportFileEST()
                            Else
                                Dim comp As Integer = 0
                                Dim qte As Integer = 0
                                Dim qtes As String
                                Dim qtedesc As String
                                Dim comps() As String = Request.QueryString("comps").Split(",")
                                Dim quotesEst() As String = Request.QueryString("quotes").Split(",")
                                Dim quotesDesc() As String = Session("EstimatingQteDescs").ToString.Split(",")
                                For i As Integer = 0 To comps.Length - 1
                                    If comps(i) <> "" Then
                                        If comp > 0 And comp <> comps(i) Then
                                            Session("EstimatingQteDescs" & comp) = qtedesc
                                            sFileNameEst &= Me.OutputReportFileEST(comp, qtes) & ","
                                            qtes = ""
                                        End If
                                        comp = comps(i)
                                        qte = quotesEst(i)
                                        qtes &= qte & ","
                                        qtedesc &= quotesDesc(i) & ","
                                    End If
                                Next
                                Session("EstimatingQteDescs" & comp) = qtedesc
                                sFileNameEst &= Me.OutputReportFileEST(comp, qtes) & ","
                                sFileNameEst = MiscFN.RemoveTrailingDelimiter(sFileNameEst, ",")
                            End If
                        Case "rfq"
                            sFileName = Me.OutputReportFileRFQ()
                        Case "cmp"
                            'sFileName = Me.OutputReportFileCMP()
                        Case "ps"
                            sFileName = Me.OutputReportFilePS()
                        Case "psg"
                            sFileName = Me.OutputReportFilePSExcel()
                        Case "psf", "psgf"
                            Dim StrFilePrefix As String = Request.PhysicalApplicationPath & "TEMP\"
                            Dim StrFilePrefixPS As String = Request.PhysicalApplicationPath & "TEMP\"

                            'If Me.RadioEmail.Checked = True Then
                            If Me.ChkIncludeProjectScheduleReport.Checked = True Then
                                Dim r As cReports = New cReports(Session("ConnString"))
                                Dim StrFileDate As String = "__" & Now.Year.ToString() & Now.Month.ToString() & Now.Day.ToString() & Now.Hour.ToString() & Now.Minute.ToString
                                Dim StrFileType As String = ".pdf"
                                sFileName = "Project_Schedule_" & Me.JobNumber.ToString() & "_" & JobComponentNbr.ToString() & AdvantageFramework.StringUtilities.GUID_Date(True, True, True) & StrFileType
                                sFileNamePS = "Project_Schedule_2_" & Me.JobNumber.ToString() & "_" & JobComponentNbr.ToString() & AdvantageFramework.StringUtilities.GUID_Date(True, True, True) & StrFileType
                                Dim rpt As New popReportViewer
                                Try
                                    Dim ThisOptions As String = ""
                                    If Request.QueryString("from") = "sfuc" Then
                                        ThisOptions = Me.JobNumber.ToString() & "|" & Me.JobComponentNbr.ToString() & "|" & Request.QueryString("hours") & "|" & Request.QueryString("ms") & "|" & Request.QueryString("due") & "|" & Request.QueryString("excludeTC") & "|" & Request.QueryString("sort")
                                        If Request.QueryString("rpt") = "duedate" Then
                                            If rpt.renderDoc(StrFilePrefix & sFileNamePS, "TrafficDetailByJobDueDate", "", "", "", "", "", 1, "", ThisOptions, , ErrorMessage) = False Then
                                                Return False
                                            End If
                                            sFileNamePS = StrFilePrefixPS & sFileNamePS
                                        ElseIf Request.QueryString("rpt") = "dateres" Then
                                            If rpt.renderDoc(StrFilePrefix & sFileNamePS, "TrafficDetailByJob2", "", "", "", "", "", 1, "", ThisOptions, , ErrorMessage) = False Then
                                                Return False
                                            End If
                                            sFileNamePS = StrFilePrefixPS & sFileNamePS
                                        ElseIf Request.QueryString("rpt") = "job" Then
                                            If Request.QueryString("hours") = 1 Then
                                                If rpt.renderDoc(StrFilePrefix & sFileNamePS, "TrafficDetailByJob", "", "", "", "", "", 1, "", ThisOptions, , ErrorMessage) = False Then
                                                    Return False
                                                End If
                                                sFileNamePS = StrFilePrefixPS & sFileNamePS
                                            End If
                                        ElseIf Request.QueryString("rpt") = "calgantt" Then
                                            StrFilePrefixPS = ""
                                            StrFileType = ".xls"
                                            sFileNamePS = Me.OutputReportFilePSExcel()
                                        End If
                                        ThisOptions = Me.JobNumber.ToString() & "|" & Me.JobComponentNbr.ToString() & "||0"
                                        If rpt.renderDoc(StrFilePrefix & sFileName, "TrafficDetailByJob", "", "", "", "", "", 1, "", ThisOptions, , ErrorMessage) = False Then
                                            Return False
                                        End If
                                    Else
                                        ThisOptions = Me.JobNumber.ToString() & "|" & Me.JobComponentNbr.ToString() & "||0"
                                        If rpt.renderDoc(StrFilePrefix & sFileName, "TrafficDetailByJob", "", "", "", "", "", 1, "", ThisOptions, , ErrorMessage) = False Then
                                            Return False
                                        End If
                                    End If
                                    sFileName = StrFilePrefix & sFileName
                                Catch ex As Exception
                                    sFileName = ""
                                    sFileNamePS = ""
                                    ErrorMessage = MiscFN.JavascriptSafe(ex.Message.ToString())
                                    Return False
                                End Try
                            Else
                                Dim r As cReports = New cReports(Session("ConnString"))
                                Dim StrFileDate As String = "__" & Now.Year.ToString() & Now.Month.ToString() & Now.Day.ToString() & Now.Hour.ToString() & Now.Minute.ToString
                                Dim StrFileType As String = ".pdf"
                                sFileNamePS = "Project_Schedule_2_" & Me.JobNumber.ToString() & "_" & JobComponentNbr.ToString() & AdvantageFramework.StringUtilities.GUID_Date(True, True, True) & StrFileType
                                Dim rpt As New popReportViewer
                                Try
                                    Dim ThisOptions As String
                                    If Request.QueryString("from") = "sfuc" Then
                                        ThisOptions = Me.JobNumber.ToString() & "|" & Me.JobComponentNbr.ToString() & "|" & Request.QueryString("hours") & "|" & Request.QueryString("ms") & "|" & Request.QueryString("due") & "|" & Request.QueryString("excludeTC") & "|" & Request.QueryString("sort")
                                        If Request.QueryString("rpt") = "duedate" Then
                                            If rpt.renderDoc(StrFilePrefix & sFileNamePS, "TrafficDetailByJobDueDate", "", "", "", "", "", 1, "", ThisOptions, , ErrorMessage) = False Then
                                                Return False
                                            End If
                                            sFileNamePS = StrFilePrefixPS & sFileNamePS
                                        ElseIf Request.QueryString("rpt") = "dateres" Then
                                            If rpt.renderDoc(StrFilePrefix & sFileNamePS, "TrafficDetailByJob2", "", "", "", "", "", 1, "", ThisOptions, , ErrorMessage) = False Then
                                                Return False
                                            End If
                                            sFileNamePS = StrFilePrefixPS & sFileNamePS
                                        ElseIf Request.QueryString("rpt") = "job" Then
                                            If rpt.renderDoc(StrFilePrefix & sFileNamePS, "TrafficDetailByJob", "", "", "", "", "", 1, "", ThisOptions, , ErrorMessage) = False Then
                                                Return False
                                            End If
                                            sFileNamePS = StrFilePrefixPS & sFileNamePS
                                        ElseIf Request.QueryString("rpt") = "calgantt" Then
                                            StrFilePrefixPS = ""
                                            StrFileType = ".xls"
                                            sFileNamePS = Me.OutputReportFilePSExcel()
                                        End If
                                    Else
                                        sFileNamePS = ""
                                    End If
                                Catch ex As Exception
                                    sFileNamePS = ""
                                    ErrorMessage = MiscFN.JavascriptSafe(ex.Message.ToString())
                                    Return False
                                End Try
                            End If
                            'End If
                        Case "atb"
                            sFileName = Me.OutputReportFileATB()

                    End Select

                End If

                If Me.ValidateSave(ErrorMessage) = False Then
                    Return False
                End If

                Dim Document As New Document(Session("ConnString"))
                Dim Repository As New DocumentRepository(Session("ConnString"))
                Dim Alert As New Alert(Session("ConnString"))
                Alert.LoadByPrimaryKey(AlertID)

                Dim HasUpload As Boolean = False
                If sFileName.Trim() <> "" Or sFileNameJS.Trim() <> "" Or sFileNameJV.Trim() <> "" Or sFileNameEst.Trim() <> "" Or sFileNameCB.Trim() <> "" Then
                    HasUpload = True
                End If

                Dim HasMultipleUploads As Boolean = False
                If sFileName.Trim() <> "" And (sFileNameJS.Trim() <> "" Or sFileNameJV.Trim() <> "" Or sFileNameEst.Trim() <> "" Or sFileNameCB.Trim() <> "") Then
                    HasMultipleUploads = True
                End If
                If HasUpload = True Then
                    HasMultipleUploads = True
                End If

                Dim f As IO.FileInfo
                Dim fjs As IO.FileInfo
                If sFileName <> "" Then
                    f = New IO.FileInfo(sFileName)
                    If f.Exists Then
                        Dim realFilename As String = f.Name
                        Dim MIMEType As String
                        Select Case f.Extension.ToLower()
                            Case ".pdf"
                                MIMEType = "application/pdf"
                            Case ".xls"
                                MIMEType = "application/msexcel"
                            Case ".txt"
                                MIMEType = "text/plain"
                            Case ".tiff"
                                MIMEType = "image/tiff"
                            Case ".rtf"
                                MIMEType = "application/rtf"
                            Case Else
                                MIMEType = "application/pdf"
                        End Select
                        Dim FileLength As Integer = f.Length
                        Dim FileBytes(FileLength) As Byte
                        Dim ff As IO.FileStream = f.OpenRead
                        ff.Read(FileBytes, 0, FileLength)

                        Dim RepositoryFilename As String = "" 'Repository.AddDocument(realFilename, FileBytes, "", "", Session("userCode"), "New Alert", "Attached Doc", "a_")

                        RepositoryFilename = "a_" & Guid.NewGuid.ToString()
                        Dim DocumentId As Integer = 0
                        Try
                            Dim impersonationContext As System.Security.Principal.WindowsImpersonationContext
                            If IsNTAuth = True Then ' And HasMultipleUploads = True Then
                                Me.currentWindowsIdentity = CType(HttpContext.Current.User.Identity, System.Security.Principal.WindowsIdentity)
                                impersonationContext = Me.currentWindowsIdentity.Impersonate()
                            End If
                            'db stuff here
                            Try
                                DocumentId = Document.Add(realFilename, MIMEType, RepositoryFilename, FileLength, Session("UserCode"), "", "")
                                If IsClientPortal = True Then
                                    Alert.AddAttachment(DocumentId, "", Session("UserID"))
                                Else
                                    Alert.AddAttachment(DocumentId, Session("UserCode"), 0)
                                End If
                            Catch ex As Exception
                                ErrorMessage = ex.Message.ToString()
                                Return Alert.ALERT_ID
                            End Try
                            If IsNTAuth = True Then ' And HasMultipleUploads = True Then
                                impersonationContext.Undo()
                            End If
                        Catch ex As Exception
                        End Try
                        Dim RepositoryFilenameTemp = Repository.AddDocument(realFilename, FileBytes, "", "", Session("userCode"), "New Alert", "Attached Doc", "", RepositoryFilename)
                        ff.Close()
                    End If
                End If

                If sFileNameJS <> "" Then
                    fjs = New IO.FileInfo(sFileNameJS)
                    If fjs.Exists Then
                        Dim realFilename As String = fjs.Name
                        Dim MIMEType As String
                        If fjs.Extension = ".PDF" Then
                            MIMEType = "application/pdf"
                        ElseIf fjs.Extension = ".XLS" Then
                            MIMEType = "application/msexcel"
                        ElseIf fjs.Extension = ".TXT" Then
                            MIMEType = "text/plain"
                        ElseIf fjs.Extension = ".TIFF" Then
                            MIMEType = "image/tiff"
                        ElseIf fjs.Extension = ".RTF" Then
                            MIMEType = "application/rtf"
                        Else
                            MIMEType = "application/pdf"
                        End If
                        Dim FileLength As Integer = fjs.Length
                        Dim FileBytes(FileLength) As Byte
                        Dim ff As IO.FileStream = fjs.OpenRead
                        ff.Read(FileBytes, 0, FileLength)
                        Dim RepositoryFilenameJS As String = "" 'Repository.AddDocument(realFilename, FileBytes, "", "", Session("userCode"), "New Alert", "Attached Doc", "a_")
                        RepositoryFilenameJS = "a_" & Guid.NewGuid.ToString()
                        Dim DocumentId As Integer = 0
                        Try
                            Dim impersonationContext As System.Security.Principal.WindowsImpersonationContext
                            If IsNTAuth = True Then 'And HasMultipleUploads = True Then
                                Me.currentWindowsIdentity = CType(HttpContext.Current.User.Identity, System.Security.Principal.WindowsIdentity)
                                impersonationContext = Me.currentWindowsIdentity.Impersonate()
                            End If
                            'db stuff here
                            Try
                                DocumentId = Document.Add(realFilename, MIMEType, RepositoryFilenameJS, FileLength, Session("UserCode"), "", "")
                                If IsClientPortal = True Then
                                    Alert.AddAttachment(DocumentId, "", Session("UserID"))
                                Else
                                    Alert.AddAttachment(DocumentId, Session("UserCode"), 0)
                                End If
                            Catch ex As Exception
                                ErrorMessage = ex.Message.ToString()
                                Return Alert.ALERT_ID
                            End Try
                            If IsNTAuth = True Then 'And HasMultipleUploads = True Then
                                impersonationContext.Undo()
                            End If
                        Catch ex As Exception
                        End Try

                        Dim RepositoryFilenameTemp = Repository.AddDocument(realFilename, FileBytes, "", "", Session("userCode"), "New Alert", "Attached Doc", "", RepositoryFilenameJS)
                        ff.Close()
                    End If
                End If

                If sFileNameJV <> "" Then
                    fjs = New IO.FileInfo(sFileNameJV)
                    If fjs.Exists Then
                        Dim realFilename As String = fjs.Name
                        Dim MIMEType As String
                        If fjs.Extension = ".PDF" Then
                            MIMEType = "application/pdf"
                        ElseIf fjs.Extension = ".XLS" Then
                            MIMEType = "application/msexcel"
                        ElseIf fjs.Extension = ".TXT" Then
                            MIMEType = "text/plain"
                        ElseIf fjs.Extension = ".TIFF" Then
                            MIMEType = "image/tiff"
                        ElseIf fjs.Extension = ".RTF" Then
                            MIMEType = "application/rtf"
                        Else
                            MIMEType = "application/pdf"
                        End If
                        Dim FileLength As Integer = fjs.Length
                        Dim FileBytes(FileLength) As Byte
                        Dim ff As IO.FileStream = fjs.OpenRead
                        ff.Read(FileBytes, 0, FileLength)
                        Dim RepositoryFilenameJV As String = "" 'Repository.AddDocument(realFilename, FileBytes, "", "", Session("userCode"), "New Alert", "Attached Doc", "a_")
                        RepositoryFilenameJV = "a_" & Guid.NewGuid.ToString()
                        Dim DocumentId As Integer = 0
                        Try
                            Dim impersonationContext As System.Security.Principal.WindowsImpersonationContext
                            If IsNTAuth = True And HasMultipleUploads = True Then
                                Me.currentWindowsIdentity = CType(HttpContext.Current.User.Identity, System.Security.Principal.WindowsIdentity)
                                impersonationContext = Me.currentWindowsIdentity.Impersonate()
                            End If
                            'db stuff here
                            Try
                                DocumentId = Document.Add(realFilename, MIMEType, RepositoryFilenameJV, FileLength, Session("UserCode"), "", "")
                                If IsClientPortal = True Then
                                    Alert.AddAttachment(DocumentId, "", Session("UserID"))
                                Else
                                    Alert.AddAttachment(DocumentId, Session("UserCode"), 0)
                                End If
                            Catch ex As Exception
                                ErrorMessage = ex.Message.ToString()
                                Return Alert.ALERT_ID
                            End Try
                            If IsNTAuth = True And HasMultipleUploads = True Then
                                impersonationContext.Undo()
                            End If
                        Catch ex As Exception
                        End Try
                        Dim RepositoryFilenameTemp = Repository.AddDocument(realFilename, FileBytes, "", "", Session("userCode"), "New Alert", "Attached Doc", "", RepositoryFilenameJV)
                        ff.Close()
                    End If
                End If

                If sFileNameCB <> "" Then
                    fjs = New IO.FileInfo(sFileNameCB)
                    If fjs.Exists Then
                        Dim realFilename As String = fjs.Name
                        Dim MIMEType As String
                        If fjs.Extension = ".PDF" Then
                            MIMEType = "application/pdf"
                        ElseIf fjs.Extension = ".XLS" Then
                            MIMEType = "application/msexcel"
                        ElseIf fjs.Extension = ".TXT" Then
                            MIMEType = "text/plain"
                        ElseIf fjs.Extension = ".TIFF" Then
                            MIMEType = "image/tiff"
                        ElseIf fjs.Extension = ".RTF" Then
                            MIMEType = "application/rtf"
                        Else
                            MIMEType = "application/pdf"
                        End If
                        Dim FileLength As Integer = fjs.Length
                        Dim FileBytes(FileLength) As Byte
                        Dim ff As IO.FileStream = fjs.OpenRead
                        ff.Read(FileBytes, 0, FileLength)

                        Dim RepositoryFilenameCB As String = "" 'Repository.AddDocument(realFilename, FileBytes, "", "", Session("userCode"), "New Alert", "Attached Doc", "a_")
                        RepositoryFilenameCB = "a_" & Guid.NewGuid.ToString()
                        Dim DocumentId As Integer = 0 '
                        Try
                            Dim impersonationContext As System.Security.Principal.WindowsImpersonationContext
                            If IsNTAuth = True And HasMultipleUploads = True Then
                                Me.currentWindowsIdentity = CType(HttpContext.Current.User.Identity, System.Security.Principal.WindowsIdentity)
                                impersonationContext = Me.currentWindowsIdentity.Impersonate()
                            End If
                            'db stuff here
                            Try
                                DocumentId = Document.Add(realFilename, MIMEType, RepositoryFilenameCB, FileLength, Session("UserCode"), "", "")
                                If IsClientPortal = True Then
                                    Alert.AddAttachment(DocumentId, "", Session("UserID"))
                                Else
                                    Alert.AddAttachment(DocumentId, Session("UserCode"), 0)
                                End If
                            Catch ex As Exception
                                ErrorMessage = ex.Message.ToString()
                                Return Alert.ALERT_ID
                            End Try
                            If IsNTAuth = True And HasMultipleUploads = True Then
                                impersonationContext.Undo()
                            End If
                        Catch ex As Exception
                        End Try
                        Dim RepositoryFilenameTemp = Repository.AddDocument(realFilename, FileBytes, "", "", Session("userCode"), "New Alert", "Attached Doc", "", RepositoryFilenameCB)
                        ff.Close()
                    End If
                End If

                If sFileNameEst <> "" Then
                    Dim fns() As String = sFileNameEst.Split(",")
                    For w As Integer = 0 To fns.Length - 1
                        fjs = New IO.FileInfo(fns(w))
                        If fjs.Exists Then
                            Dim realFilename As String = fjs.Name
                            Dim MIMEType As String
                            If fjs.Extension = ".PDF" Then
                                MIMEType = "application/pdf"
                            ElseIf fjs.Extension = ".XLS" Then
                                MIMEType = "application/msexcel"
                            ElseIf fjs.Extension = ".TXT" Then
                                MIMEType = "text/plain"
                            ElseIf fjs.Extension = ".TIFF" Then
                                MIMEType = "image/tiff"
                            ElseIf fjs.Extension = ".RTF" Then
                                MIMEType = "application/rtf"
                            Else
                                MIMEType = "application/pdf"
                            End If
                            Dim FileLength As Integer = fjs.Length
                            Dim FileBytes(FileLength) As Byte
                            Dim ff As IO.FileStream = fjs.OpenRead
                            ff.Read(FileBytes, 0, FileLength)
                            Dim RepositoryFilenameEst As String = "" 'Repository.AddDocument(realFilename, FileBytes, "", "", Session("userCode"), "New Alert", "Attached Doc", "a_")
                            RepositoryFilenameEst = "a_" & Guid.NewGuid.ToString()
                            Dim DocumentId As Integer = 0
                            Try
                                Dim impersonationContext As System.Security.Principal.WindowsImpersonationContext
                                If IsNTAuth = True And HasMultipleUploads = True Then
                                    Me.currentWindowsIdentity = CType(HttpContext.Current.User.Identity, System.Security.Principal.WindowsIdentity)
                                    impersonationContext = Me.currentWindowsIdentity.Impersonate()
                                End If
                                'db stuff here
                                Try
                                    DocumentId = Document.Add(realFilename, MIMEType, RepositoryFilenameEst, FileLength, Session("UserCode"), "", "")
                                    If IsClientPortal = True Then
                                        Alert.AddAttachment(DocumentId, "", Session("UserID"))
                                    Else
                                        Alert.AddAttachment(DocumentId, Session("UserCode"), 0)
                                    End If
                                Catch ex As Exception
                                    ErrorMessage = ex.Message.ToString()
                                    Return Alert.ALERT_ID
                                End Try
                                If IsNTAuth = True And HasMultipleUploads = True Then
                                    impersonationContext.Undo()
                                End If
                            Catch ex As Exception
                            End Try
                            Dim RepositoryFilenameTemp = Repository.AddDocument(realFilename, FileBytes, "", "", Session("userCode"), "New Alert", "Attached Doc", "", RepositoryFilenameEst)
                            ff.Close()
                        End If
                    Next
                End If


                Try 'delete generated docs
                    If Me.ChkExcludeAttachmentFromEmail.Checked = False Then
                        Try
                            If sFileName <> "" Then
                                My.Computer.FileSystem.DeleteFile(sFileName)
                            End If
                        Catch ex As Exception
                        End Try
                        Try
                            If sFileNameJS <> "" Then
                                My.Computer.FileSystem.DeleteFile(sFileNameJS)
                            End If
                        Catch ex As Exception
                        End Try
                        Try
                            If sFileNameCB <> "" Then
                                My.Computer.FileSystem.DeleteFile(sFileNameCB)
                            End If
                        Catch ex As Exception
                        End Try
                        Try
                            If sFileNameEst <> "" Then
                                If sFileNameEst.IndexOf(",") > -1 Then
                                    Dim files() As String = sFileNameEst.Split(",")
                                    For j As Integer = 0 To files.Length - 1
                                        Try
                                            My.Computer.FileSystem.DeleteFile(files(j).Trim())
                                        Catch ex As Exception
                                        End Try
                                    Next
                                Else
                                    My.Computer.FileSystem.DeleteFile(sFileNameEst)
                                End If
                            End If
                        Catch ex As Exception
                        End Try
                        Try
                            If sFileNameRFQ <> "" Then
                                My.Computer.FileSystem.DeleteFile(sFileNameRFQ)
                            End If
                        Catch ex As Exception
                        End Try
                        Try
                            If sFileNamePS <> "" Then
                                My.Computer.FileSystem.DeleteFile(sFileNamePS)
                            End If
                        Catch ex As Exception
                        End Try
                        Try
                            If sFileName <> "" Then
                                My.Computer.FileSystem.DeleteFile(sFileName)
                            End If
                        Catch ex As Exception
                        End Try
                    End If
                Catch ex As Exception
                End Try

                'End If

                'If Me.EmailSent = True Or intAlertID > 0 Then
                '    Me.CloseThisWindow()
                'End If

                ErrorMessage = ""
                Return True

            Else
                'ErrorMessage = "Could not get page type"
                'Return False

                ErrorMessage = ""
                Return True
            End If
        Catch ex As Exception
            ErrorMessage = MiscFN.JavascriptSafe(ex.Message.ToString())
            Return False
        End Try
    End Function
    '2. Send the emails
    Private Function ProcessEmails(ByVal sFileName As String, ByVal AlertID As Integer, Optional ByVal sFileNameJS As String = "", Optional ByVal sFileNameJV As String = "",
                                   Optional ByVal sFileNameEST As String = "", Optional ByVal sFileNameCB As String = "", Optional ByVal sFileNameRFQ As String = "",
                                   Optional ByVal DocIdList As String = "", Optional ByVal sFileNamePS As String = "", Optional ByRef ErrorMessage As String = "") As Boolean
        Try

            Dim oEstimating As cEstimating = New cEstimating(Session("ConnString"), CStr(Session("UserCode")))
            Dim impersonationContext As System.Security.Principal.WindowsImpersonationContext
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim IsAssignment As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)

            End Using

            If Alert IsNot Nothing Then

                IsAssignment = AdvantageFramework.AlertSystem.IsAlertAnAlertAssignment(Alert)

            End If

            If IsNTAuth = True Then
                Me.currentWindowsIdentity = CType(HttpContext.Current.User.Identity, System.Security.Principal.WindowsIdentity)
                impersonationContext = Me.currentWindowsIdentity.Impersonate()
            End If

            Dim WebvantageURL As String = ""
            Dim ClientPortalURL As String = ""
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))
                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)
            End Using

            If Agency IsNot Nothing Then
                WebvantageURL = Agency.WebvantageURL
                ClientPortalURL = Agency.ClientPortalURL
            End If

            Dim ws As New cWebServices(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"), HttpContext.Current.Session("EmpCode"))
            If ws.GetSMPTSettingsByUser(IsClientPortal) = False Then
                ErrorMessage = "Could not get user SMTP settings"
                Return False
            End If

            Dim emp As New cEmployee(Session("ConnString"))
            Dim ClientContact As AdvantageFramework.Security.Database.Entities.ClientContact
            Dim FromEmailAddress As String
            If IsClientPortal = True Then
                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))
                    ClientContact = AdvantageFramework.Security.Database.Procedures.ClientContact.LoadByClientContactID(SecurityDbContext, HttpContext.Current.Session("UserID"))
                    If ClientContact.EmailAddress <> "" Then
                        FromEmailAddress = ClientContact.EmailAddress
                    End If
                End Using
            Else
                FromEmailAddress = emp.GetEmail(Session("EmpCode")) ' ws.oSMTPSettings.SMTP_SENDER
            End If


            Dim NowDate As Date = Now

            Dim i As Integer
            If FromEmailAddress = "" Then
                ErrorMessage = "You do not have an email address in the database"
                Exit Function
            End If

            Dim Sent_Count As Integer = 0
            Dim node As Telerik.Web.UI.RadTreeNode
            Dim MyJV As JobVersion = New JobVersion(Session("ConnString"))
            Dim desc As String
            Dim jc As New Job(Session("ConnString"))
            Dim CurrentAlert As New Alert(Session("ConnString"))

            CurrentAlert.LoadByPrimaryKey(AlertID)

            desc = MyJV.GetAgencyDesc()
            jc.GetJob(Me.JobNumber, Me.JobComponentNbr)

            Dim EstimateBody As New AdvantageFramework.Email.Classes.HtmlEmail(True)
            Dim ProjectScheduleBody As String = ""
            Dim FinalEmailBody As String = ""

            Dim EmailHtmlBody As New AdvantageFramework.Email.Classes.HtmlEmail(True)

            If Me.PageType() <> "" Then

                EmailHtmlBody.AddCustomRow(Me.BodyRadEditor.Html.ToString())

                Dim PdfAttachedText As String = "{0} - {1}_{2} - attached in PDF format."
                Select Case Me.PageType()
                    Case "jt"
                        If Request.QueryString("fromapp") = "jobsearchmul" Then
                            Dim jbcp() As String = Me._MultipleJobList.Split(",")
                            For w As Integer = 0 To jbcp.Length - 1
                                Dim jobc As String
                                jobc = jbcp(w)
                                If jobc <> "" Then
                                    Dim jobcomp() As String = jobc.Split("/")
                                    If Session("printjof") IsNot Nothing AndAlso Session("printjof") = 1 AndAlso Me.ChkExcludeAttachmentFromEmail.Checked = False Then
                                        EmailHtmlBody.AddCustomRow(String.Format(PdfAttachedText, "Job Order", jobcomp(0), jobcomp(1)))
                                    End If
                                    If Session("printjs") IsNot Nothing AndAlso Session("printjs") = 1 AndAlso Me.ChkExcludeAttachmentFromEmail.Checked = False Then
                                        EmailHtmlBody.AddCustomRow(String.Format(PdfAttachedText, "Specification", jobcomp(0), jobcomp(1)))
                                    End If
                                    If Session("printjv") IsNot Nothing AndAlso Session("printjv") = 1 AndAlso Me.ChkExcludeAttachmentFromEmail.Checked = False Then
                                        EmailHtmlBody.AddCustomRow(String.Format(PdfAttachedText, desc, jobcomp(0), jobcomp(1)))
                                    End If
                                    If Session("printcb") IsNot Nothing AndAlso Session("printcb") = 1 AndAlso Me.ChkExcludeAttachmentFromEmail.Checked = False Then
                                        EmailHtmlBody.AddCustomRow(String.Format(PdfAttachedText, "Creative Brief", jobcomp(0), jobcomp(1)))
                                    End If
                                End If
                            Next
                        Else
                            If Me.JobNumber > 0 AndAlso Me.JobComponentNbr > 0 Then
                                If Session("printjof") IsNot Nothing AndAlso Session("printjof") = 1 AndAlso Me.ChkExcludeAttachmentFromEmail.Checked = False Then
                                    EmailHtmlBody.AddCustomRow(String.Format(PdfAttachedText, "Job Order", Me.JobNumber, Me.JobComponentNbr))
                                End If
                                If Session("printjs") IsNot Nothing AndAlso Session("printjs") = 1 AndAlso Me.ChkExcludeAttachmentFromEmail.Checked = False Then
                                    EmailHtmlBody.AddCustomRow(String.Format(PdfAttachedText, "Specification", Me.JobNumber, Me.JobComponentNbr))
                                End If
                                If Session("printjv") IsNot Nothing AndAlso Session("printjv") = 1 AndAlso Me.ChkExcludeAttachmentFromEmail.Checked = False Then
                                    EmailHtmlBody.AddCustomRow(String.Format(PdfAttachedText, desc, Me.JobNumber, Me.JobComponentNbr))
                                End If
                                If Session("printcb") IsNot Nothing AndAlso Session("printcb") = 1 AndAlso Me.ChkExcludeAttachmentFromEmail.Checked = False Then
                                    EmailHtmlBody.AddCustomRow(String.Format(PdfAttachedText, "Creative Brief", Me.JobNumber, Me.JobComponentNbr))
                                End If

                            End If
                        End If
                    Case "po"
                        EmailHtmlBody.AddCustomRow("Purchase Order - " & Me.PO_RefId.ToString() & " - attached in PDF format.")
                    Case "js"
                        EmailHtmlBody.AddCustomRow("Specification - " & Session("JSReportJobNum") & "_" & Session("JSReportJobCompNum") & " - attached in PDF format.")
                    Case "jv"
                        EmailHtmlBody.AddCustomRow(Session("JVTemplateName") & " - " &
                                                Session("JVReportVersion") &
                                                " for Job/Comp " &
                                                Session("JVReportJobNum").ToString.PadLeft(6, "0") & "_" & Session("JVReportJobCompNum").ToString.PadLeft(3, "0") & " - " & jc.JOB_DESC &
                                                " - attached in PDF format.")
                    Case "cb"
                        EmailHtmlBody.AddCustomRow("Creative Brief - " & Session("CBReportJobNum") & "_" & Session("CBReportJobCompNum") & " - attached in PDF format.")
                    Case "rfq"
                        EmailHtmlBody.AddCustomRow("RFQ - " &
                                                    Request.QueryString("EstNum").PadLeft(6, "0") &
                                                    "-" &
                                                    Request.QueryString("EstCompNum").PadLeft(2, "0") &
                                                    "-" &
                                                    Request.QueryString("VendorQteNbr").PadLeft(2, "0") &
                                                    " - attached in PDF format.")

                        EmailHtmlBody.AddCustomRow("<a href='" & WebvantageURL & "/VendorQuote.aspx?PageMode=edit&EstNum=" & Request.QueryString("EstNum") & "&EstComp=" & Request.QueryString("EstCompNum") & "&vendorreq=" & CInt(Request.QueryString("VendorQteNbr")) & "'>*Click here to view this vendor request.</a>")
                        EmailHtmlBody.AddCustomRow("*Link for Webvantage users only.")

                    Case "cmp"
                        Dim cCMP As New cCampaign(Session("ConnString"), CType(Request.QueryString("cmp"), Integer))
                        'EmailHtmlBody.AddCustomRow("Campaign - " & cCMP.CMP_CODE & " - attached in PDF format.")
                    Case "est"
                        Dim dt As New DataTable
                        Dim str_cli_code As String = ""
                        Dim str_div_code As String = ""
                        Dim str_prd_code As String = ""
                        Dim str_cli As String = ""
                        Dim str_div As String = ""
                        Dim str_prod As String = ""
                        Dim str_job As String = ""
                        Dim str_comp As String = ""
                        Dim str_est As String = ""
                        Dim str_estcomp As String = ""
                        Dim str_est_num As String = ""
                        Dim str_estcomp_num As String = ""
                        Dim str_sc As String = ""
                        Dim str_cliref As String = ""
                        Dim str_mu As String = ""
                        Dim str_cam As String = ""
                        Dim str_cc As String = ""
                        Dim str_ae As String = ""
                        Dim comp As Integer = 0
                        Dim qte As Integer = 0
                        Dim qtes As String = ""
                        Dim qtedesc As String = ""

                        Dim cps As String = Request.QueryString("comps")
                        Dim comps() As String = MiscFN.RemoveTrailingDelimiter(cps, ",").Split(",")
                        Dim quotesEst() As String = Request.QueryString("quotes").Split(",")
                        Dim quotesDesc() As String = Session("EstimatingQteDescs").ToString.Split(",")

                        For w As Integer = 0 To comps.Length - 1
                            If comp > 0 And comp <> comps(w) Then
                                dt = oEstimating.GetEstimateData(Me.EstimateNumber, comp, 0, 0, Session("UserCode"))
                                If dt.Rows.Count > 0 Then
                                    If IsDBNull(dt.Rows(0)("CL_CODE")) = False Then
                                        str_cli_code = dt.Rows(0)("CL_CODE")
                                        str_cli = dt.Rows(0)("CL_CODE")
                                    End If
                                    If IsDBNull(dt.Rows(0)("CL_NAME")) = False Then
                                        str_cli = dt.Rows(0)("CL_NAME")
                                    End If
                                    If IsDBNull(dt.Rows(0)("DIV_CODE")) = False Then
                                        str_div_code = dt.Rows(0)("DIV_CODE")
                                        str_div = dt.Rows(0)("DIV_CODE")
                                    End If
                                    If IsDBNull(dt.Rows(0)("DIV_NAME")) = False Then
                                        str_div = dt.Rows(0)("DIV_NAME")
                                    End If
                                    If IsDBNull(dt.Rows(0)("PRD_CODE")) = False Then
                                        str_prd_code = dt.Rows(0)("PRD_CODE")
                                        str_prod = dt.Rows(0)("PRD_CODE")
                                    End If
                                    If IsDBNull(dt.Rows(0)("PRD_DESCRIPTION")) = False Then
                                        str_prod = dt.Rows(0)("PRD_DESCRIPTION")
                                    End If
                                    If IsDBNull(dt.Rows(0)("JOB_NUMBER")) = False Then
                                        str_job = dt.Rows(0)("JOB_NUMBER").ToString.PadLeft(6, "0")
                                    Else
                                        str_job = ""
                                    End If
                                    If IsDBNull(dt.Rows(0)("JOB_DESC")) = False Then
                                        str_job &= " - " & dt.Rows(0)("JOB_DESC")
                                    End If
                                    If IsDBNull(dt.Rows(0)("JOB_COMPONENT_NBR")) = False Then
                                        str_comp = dt.Rows(0)("JOB_COMPONENT_NBR").ToString.PadLeft(3, "0")
                                    Else
                                        str_comp = ""
                                    End If
                                    If IsDBNull(dt.Rows(0)("JOB_COMP_DESC")) = False Then
                                        str_comp &= " - " & dt.Rows(0)("JOB_COMP_DESC")
                                    End If
                                    If IsDBNull(dt.Rows(0)("ESTIMATE_NUMBER")) = False Then
                                        str_est = dt.Rows(0)("ESTIMATE_NUMBER").ToString.PadLeft(6, "0")
                                        str_est_num = dt.Rows(0)("ESTIMATE_NUMBER")
                                    End If
                                    If IsDBNull(dt.Rows(0)("EST_LOG_DESC")) = False Then
                                        str_est &= " - " & dt.Rows(0)("EST_LOG_DESC")
                                    End If
                                    If IsDBNull(dt.Rows(0)("EST_COMPONENT_NBR")) = False Then
                                        str_estcomp = dt.Rows(0)("EST_COMPONENT_NBR").ToString.PadLeft(2, "0")
                                        str_estcomp_num = dt.Rows(0)("EST_COMPONENT_NBR")
                                    End If
                                    If IsDBNull(dt.Rows(0)("EST_COMP_DESC")) = False Then
                                        str_estcomp &= " - " & dt.Rows(0)("EST_COMP_DESC")
                                    End If
                                    If IsDBNull(dt.Rows(0)("SC_CODE")) = False Then
                                        str_sc = dt.Rows(0)("SC_CODE")
                                    End If
                                    If IsDBNull(dt.Rows(0)("SC_DESCRIPTION")) = False Then
                                        str_sc &= " - " & dt.Rows(0)("SC_DESCRIPTION")
                                    End If
                                    If IsDBNull(dt.Rows(0)("CMP_CODE")) = False Then
                                        str_cam = dt.Rows(0)("CMP_CODE")
                                    End If
                                    If IsDBNull(dt.Rows(0)("CMP_NAME")) = False Then
                                        str_cam &= " - " & dt.Rows(0)("CMP_NAME")
                                    End If
                                    If IsDBNull(dt.Rows(0)("EST_PRD_CONT_CODE")) = False Then
                                        str_cc = dt.Rows(0)("EST_PRD_CONT_CODE")
                                    End If
                                    If IsDBNull(dt.Rows(0)("CONT_FML")) = False Then
                                        str_cc &= " - " & dt.Rows(0)("CONT_FML")
                                    End If
                                    If IsDBNull(dt.Rows(0)("EST_MARKUP_PCT")) = False Then
                                        str_mu = dt.Rows(0)("EST_MARKUP_PCT")
                                    End If
                                    If IsDBNull(dt.Rows(0)("JOB_CLI_REF")) = False Then
                                        str_cliref = dt.Rows(0)("JOB_CLI_REF")
                                    End If
                                    If IsDBNull(dt.Rows(0)("AE")) = False Then
                                        str_ae = dt.Rows(0)("AE")
                                    End If
                                End If

                                EstimateHeader(EmailHtmlBody, str_cli, str_div, str_prod, str_job, str_comp, str_est, str_estcomp, str_ae, str_cliref, str_mu)

                                If AlertID > 0 Then
                                    EmailHtmlBody.AddCustomRow(CurrentAlert.GeneralInfo(AlertID))
                                Else
                                    EmailHtmlBody.AddCustomRow(CurrentAlert.GeneralInfoNoAlert(Session("UserCode"), Me.RadComboBoxPriority.SelectedValue))
                                End If

                                'Individual quotes
                                qtes = MiscFN.RemoveTrailingDelimiter(qtes, ",")
                                Dim qutes() As String = qtes.Split(",") 'list of quotes 
                                If qutes.Length > 0 Then
                                    EmailHtmlBody.AddHeaderRow("Quotes")
                                    For j As Integer = 0 To qutes.Length - 1
                                        EmailHtmlBody.AddCustomRow(EstimateQuotes(str_est_num, str_estcomp_num, qutes(j)))
                                    Next
                                End If
                                qtes = ""

                            End If
                            comp = comps(w)
                            qte = quotesEst(w)
                            qtes &= qte & ","
                            qtedesc &= quotesDesc(w) & ","
                        Next

                        Try
                            If Me.EstimateNumber <> 0 Then
                                dt = oEstimating.GetEstimateData(CType(Me.EstimateNumber, Integer), comp, 0, 0, Session("UserCode"))
                                If dt.Rows.Count > 0 Then
                                    If IsDBNull(dt.Rows(0)("CL_CODE")) = False Then
                                        str_cli_code = dt.Rows(0)("CL_CODE")
                                        str_cli = dt.Rows(0)("CL_CODE")
                                    End If
                                    If IsDBNull(dt.Rows(0)("CL_NAME")) = False Then
                                        str_cli = dt.Rows(0)("CL_NAME")
                                    End If
                                    If IsDBNull(dt.Rows(0)("DIV_CODE")) = False Then
                                        str_div_code = dt.Rows(0)("DIV_CODE")
                                        str_div = dt.Rows(0)("DIV_CODE")
                                    End If
                                    If IsDBNull(dt.Rows(0)("DIV_NAME")) = False Then
                                        str_div = dt.Rows(0)("DIV_NAME")
                                    End If
                                    If IsDBNull(dt.Rows(0)("PRD_CODE")) = False Then
                                        str_prd_code = dt.Rows(0)("PRD_CODE")
                                        str_prod = dt.Rows(0)("PRD_CODE")
                                    End If
                                    If IsDBNull(dt.Rows(0)("PRD_DESCRIPTION")) = False Then
                                        str_prod = dt.Rows(0)("PRD_DESCRIPTION")
                                    End If
                                    If IsDBNull(dt.Rows(0)("JOB_NUMBER")) = False Then
                                        str_job = dt.Rows(0)("JOB_NUMBER").ToString.PadLeft(6, "0")
                                    Else
                                        str_job = ""
                                    End If
                                    If IsDBNull(dt.Rows(0)("JOB_DESC")) = False Then
                                        str_job &= " - " & dt.Rows(0)("JOB_DESC")
                                    End If
                                    If IsDBNull(dt.Rows(0)("JOB_COMPONENT_NBR")) = False Then
                                        str_comp = dt.Rows(0)("JOB_COMPONENT_NBR").ToString.PadLeft(3, "0")
                                    Else
                                        str_comp = ""
                                    End If
                                    If IsDBNull(dt.Rows(0)("JOB_COMP_DESC")) = False Then
                                        str_comp &= " - " & dt.Rows(0)("JOB_COMP_DESC")
                                    End If
                                    If IsDBNull(dt.Rows(0)("ESTIMATE_NUMBER")) = False Then
                                        str_est = dt.Rows(0)("ESTIMATE_NUMBER").ToString.PadLeft(6, "0")
                                        str_est_num = dt.Rows(0)("ESTIMATE_NUMBER")
                                    End If
                                    If IsDBNull(dt.Rows(0)("EST_LOG_DESC")) = False Then
                                        str_est &= " - " & dt.Rows(0)("EST_LOG_DESC")
                                    End If
                                    If IsDBNull(dt.Rows(0)("EST_COMPONENT_NBR")) = False Then
                                        str_estcomp = dt.Rows(0)("EST_COMPONENT_NBR").ToString.PadLeft(2, "0")
                                        str_estcomp_num = dt.Rows(0)("EST_COMPONENT_NBR")
                                    End If
                                    If IsDBNull(dt.Rows(0)("EST_COMP_DESC")) = False Then
                                        str_estcomp &= " - " & dt.Rows(0)("EST_COMP_DESC")
                                    End If
                                    If IsDBNull(dt.Rows(0)("SC_CODE")) = False Then
                                        str_sc = dt.Rows(0)("SC_CODE")
                                    End If
                                    If IsDBNull(dt.Rows(0)("SC_DESCRIPTION")) = False Then
                                        str_sc &= " - " & dt.Rows(0)("SC_DESCRIPTION")
                                    End If
                                    If IsDBNull(dt.Rows(0)("CMP_CODE")) = False Then
                                        str_cam = dt.Rows(0)("CMP_CODE")
                                    End If
                                    If IsDBNull(dt.Rows(0)("CMP_NAME")) = False Then
                                        str_cam &= " - " & dt.Rows(0)("CMP_NAME")
                                    End If
                                    If IsDBNull(dt.Rows(0)("EST_PRD_CONT_CODE")) = False Then
                                        str_cc = dt.Rows(0)("EST_PRD_CONT_CODE")
                                    End If
                                    If IsDBNull(dt.Rows(0)("CONT_FML")) = False Then
                                        str_cc &= " - " & dt.Rows(0)("CONT_FML")
                                    End If
                                    If IsDBNull(dt.Rows(0)("EST_MARKUP_PCT")) = False Then
                                        str_mu = dt.Rows(0)("EST_MARKUP_PCT")
                                    End If
                                    If IsDBNull(dt.Rows(0)("JOB_CLI_REF")) = False Then
                                        str_cliref = dt.Rows(0)("JOB_CLI_REF")
                                    End If
                                    If IsDBNull(dt.Rows(0)("AE")) = False Then
                                        str_ae = dt.Rows(0)("AE")
                                    End If
                                End If
                                Me.EstimateHeader(EmailHtmlBody, str_cli, str_div, str_prod, str_job, str_comp, str_est, str_estcomp, str_ae, str_cliref, str_mu)
                            End If
                        Catch ex As Exception
                            ErrorMessage = MiscFN.JavascriptSafe(ex.Message.ToString())
                            Return False
                        End Try


                        If AlertID > 0 Then
                            EmailHtmlBody.AddCustomRow(CurrentAlert.GeneralInfo(AlertID))
                        Else
                            EmailHtmlBody.AddCustomRow(CurrentAlert.GeneralInfoNoAlert(Session("UserCode"), Me.RadComboBoxPriority.SelectedValue))
                        End If

                        qtes = MiscFN.RemoveTrailingDelimiter(qtes, ",")
                        Dim qutes2() As String = qtes.Split(",")
                        If qutes2.Length > 0 Then
                            EmailHtmlBody.AddHeaderRow("Quotes")
                            For j As Integer = 0 To qutes2.Length - 1
                                EmailHtmlBody.AddCustomRow(EstimateQuotes(str_est_num, str_estcomp_num, qutes2(j)))
                            Next
                        End If
                        EstimateBody = EmailHtmlBody
                        EstimateBody.Finish()
                        'Update the alert with the new text
                        Try
                            Dim arP(1) As SqlParameter
                            Dim pBody As New SqlParameter("@BODY", SqlDbType.Text)
                            If Me.CheckBoxIncludeEstimateHtml.Checked = True Then
                                pBody.Value = EstimateBody.ToString(AlertID)
                            Else
                                EmailHtmlBody = New AdvantageFramework.Email.Classes.HtmlEmail(True)
                                If Me.BodyRadEditor.Text.Trim() <> "" Then
                                    pBody.Value = Me.BodyRadEditor.Html
                                    EmailHtmlBody.AddCustomRow(Me.BodyRadEditor.Html)
                                Else
                                    pBody.Value = System.DBNull.Value
                                End If
                            End If
                            arP(0) = pBody
                            SqlHelper.ExecuteNonQuery(Session("ConnString"), CommandType.Text, "UPDATE ALERT WITH(ROWLOCK) SET BODY = @BODY, BODY_HTML = @BODY WHERE ALERT_ID = " & AlertID & ";", arP)
                        Catch ex As Exception
                        End Try

                        Try
                            If Not dt Is Nothing Then
                                dt.Dispose()
                                dt = Nothing
                            End If
                        Catch ex As Exception
                        End Try
                    Case "psf", "psgf"
                        Dim str_cli_code As String = ""
                        Dim str_div_code As String = ""
                        Dim str_prd_code As String = ""
                        Dim str_cli As String = ""
                        Dim str_div As String = ""
                        Dim str_prod As String = ""
                        Dim str_job As String = ""
                        Dim str_comp As String = ""
                        Dim str_start As String = ""
                        Dim str_due As String = ""
                        Dim str_stat As String = ""
                        Dim oTrafficSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))

                        Try
                            Dim dtPS As DataTable = oTrafficSchedule.GetScheduleHeader(Me.JobNumber, Me.JobComponentNbr, Session("UserCode").ToString(), False).Tables(0)
                            If dtPS.Rows.Count > 0 Then
                                If IsDBNull(dtPS.Rows(0)("CL_CODE")) = False Then
                                    str_cli_code = dtPS.Rows(0)("CL_CODE")
                                    str_cli = dtPS.Rows(0)("CL_CODE")
                                End If
                                If IsDBNull(dtPS.Rows(0)("CL_NAME")) = False Then
                                    str_cli &= " - " & dtPS.Rows(0)("CL_NAME")
                                End If
                                If IsDBNull(dtPS.Rows(0)("DIV_CODE")) = False Then
                                    str_div_code = dtPS.Rows(0)("DIV_CODE")
                                    str_div = dtPS.Rows(0)("DIV_CODE")
                                End If
                                If IsDBNull(dtPS.Rows(0)("DIV_NAME")) = False Then
                                    str_div &= " - " & dtPS.Rows(0)("DIV_NAME")
                                End If
                                If IsDBNull(dtPS.Rows(0)("PRD_CODE")) = False Then
                                    str_prd_code = dtPS.Rows(0)("PRD_CODE")
                                    str_prod = dtPS.Rows(0)("PRD_CODE")
                                End If
                                If IsDBNull(dtPS.Rows(0)("PRD_DESCRIPTION")) = False Then
                                    str_prod &= " - " & dtPS.Rows(0)("PRD_DESCRIPTION")
                                End If
                                If IsDBNull(dtPS.Rows(0)("JOB_NUMBER")) = False Then
                                    str_job = dtPS.Rows(0)("JOB_NUMBER")
                                End If
                                If IsDBNull(dtPS.Rows(0)("JOB_DESC")) = False Then
                                    str_job &= " - " & dtPS.Rows(0)("JOB_DESC")
                                End If
                                If IsDBNull(dtPS.Rows(0)("JOB_COMPONENT_NBR")) = False Then
                                    str_comp = dtPS.Rows(0)("JOB_COMPONENT_NBR")
                                End If
                                If IsDBNull(dtPS.Rows(0)("JOB_COMP_DESC")) = False Then
                                    str_comp &= " - " & dtPS.Rows(0)("JOB_COMP_DESC")
                                End If
                                If IsDBNull(dtPS.Rows(0)("TRF_CODE")) = False Then
                                    str_stat = dtPS.Rows(0)("TRF_CODE")
                                End If
                                If IsDBNull(dtPS.Rows(0)("TRF_DESC")) = False Then
                                    str_stat &= " - " & dtPS.Rows(0)("TRF_DESC")
                                End If
                                If IsDBNull(dtPS.Rows(0)("START_DATE")) = False Then
                                    str_start = dtPS.Rows(0)("START_DATE")
                                End If
                                If IsDBNull(dtPS.Rows(0)("JOB_FIRST_USE_DATE")) = False Then
                                    str_due = dtPS.Rows(0)("JOB_FIRST_USE_DATE")
                                End If
                            End If
                            Try
                                If Not dtPS Is Nothing Then
                                    dtPS.Dispose()
                                    dtPS = Nothing
                                End If
                            Catch ex As Exception
                            End Try
                        Catch ex As Exception
                            ErrorMessage = MiscFN.JavascriptSafe(ex.Message.ToString())
                            Return False
                        End Try

                        EmailHtmlBody.AddBlankRow()
                        Me.ProjectScheduleHeader(EmailHtmlBody, str_cli, str_div, str_prod, str_job, str_comp, str_start, str_due, str_stat)
                        EmailHtmlBody.AddCustomRow(Me.ProjectScheduleTasksTable(Me.JobNumber, Me.JobComponentNbr))

                End Select

            End If

            Dim EmailToList As String = ""
            Dim EmailCCList As String = ""
            Dim EmailBCCList As String = ""
            Dim HasClientPortalRecipients As Boolean = False

            If Me.RadioAlert.Checked = True Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Dim BaseAlertRecipients As Generic.List(Of AdvantageFramework.Database.Classes.AlertEmailRecipient) = Nothing

                    BaseAlertRecipients = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.AlertEmailRecipient)(String.Format("EXEC [dbo].[usp_Get_Alert_EmailRecipients] {0};", AlertID)).ToList

                    If BaseAlertRecipients IsNot Nothing Then

                        For Each Recipient As AdvantageFramework.Database.Classes.AlertEmailRecipient In BaseAlertRecipients

                            If Recipient.IsClientPortal = True Then

                                HasClientPortalRecipients = True

                            End If

                            If Recipient.SendEmail = True AndAlso String.IsNullOrWhiteSpace(Recipient.RecipientEmailAddress) = False Then

                                If IsAssignment = True Then

                                    If Recipient.IsCC = False Then

                                        EmailToList &= Recipient.RecipientEmailAddress & ","

                                    Else

                                        EmailCCList &= Recipient.RecipientEmailAddress & ","

                                    End If

                                Else

                                    EmailToList &= Recipient.RecipientEmailAddress & ","

                                End If

                            End If

                        Next

                    End If

                End Using

                EmailBCCList = ""

            Else 'SENDING AN EMAIL WITHOUT SENDING AN ALERT

                EmailToList = Me.TxtEmailTo.Text.Trim()
                EmailCCList = Me.TxtEmailCC.Text.Trim()
                EmailBCCList = Me.TxtEmailBCC.Text.Trim()

            End If

            If AlertID > 0 Then

                If HasClientPortalRecipients = False Then

                    EmailHtmlBody.AddHyperlinkRow(WebvantageURL & "/Desktop_AlertView?SprintID=0&AlertID=" & AlertID.ToString(), AdvantageFramework.AlertSystem.WebvantageAlertLinkVerbiage)

                Else

                    EmailHtmlBody.AddHyperlinkRow(WebvantageURL & "/Desktop_AlertView?SprintID=0&AlertID=" & AlertID.ToString(), AdvantageFramework.AlertSystem.WebvantageWithClientPortalAlertLinkVerbiage)
                    If ClientPortalURL IsNot Nothing AndAlso ClientPortalURL <> "" Then
                        EmailHtmlBody.AddHyperlinkRow(ClientPortalURL & "/Desktop_AlertView?SprintID=0&AlertID=" & AlertID.ToString(), AdvantageFramework.AlertSystem.ClientPortalAlertLinkVerbiage)
                    End If

                End If

            End If

            'don't change the body once it is finished
            EmailHtmlBody.Finish()
            FinalEmailBody = EmailHtmlBody.ToString(AlertID)

            EmailToList = MiscFN.CleanStringForSplit(EmailToList, ",")
            EmailCCList = MiscFN.CleanStringForSplit(EmailCCList, ",")
            EmailBCCList = MiscFN.CleanStringForSplit(EmailBCCList, ",")

            Dim oApp As cApplication = New cApplication(CStr(Session("ConnString")))
            Dim Repository As New DocumentRepository(Session("ConnString"))
            Dim Document As New Document(Session("ConnString"))

            If IsNTAuth = True Then
                impersonationContext.Undo()
            End If

            Dim DocumentIDList As New Generic.List(Of Integer)
            If DocIdList.Trim() <> "" Then

                Dim ar() As String
                ar = DocIdList.Split(",")

                For g As Integer = 0 To ar.Length - 1

                    DocumentIDList.Add(ar(g))

                Next

            End If

            If IsNTAuth = True Then

                Me.currentWindowsIdentity = CType(HttpContext.Current.User.Identity, System.Security.Principal.WindowsIdentity)
                impersonationContext = Me.currentWindowsIdentity.Impersonate()

            End If

            Dim LinkedDocIds As New System.Collections.Generic.List(Of Integer)

            Dim HasLinkedDocuments As Boolean = False
            For Each item As Telerik.Web.UI.RadListBoxItem In Me.RadListBoxLinkableDocuments.Items

                If item.Selected = True Then

                    LinkedDocIds.Add(item.Value)
                    HasLinkedDocuments = True

                End If

            Next

            Try

                Dim edso As New EmailWithDocumentsSessionObject()
                edso.ConnectionString = Session("ConnString")
                edso.UserCode = Session("UserCode")
                edso.EmployeeCode = Session("EmpCode")
                edso.SessionID = HttpContext.Current.Session.SessionID.ToString()
                edso.PhysicalApplicationPath = HttpContext.Current.Request.PhysicalApplicationPath
                edso.strTo = EmailToList
                edso.strCCList = EmailCCList
                edso.strBCCList = EmailBCCList
                edso.strSubject = Me.txtSubject.Text.Trim()
                edso.strBody = FinalEmailBody.ToString().Trim()
                edso.Priority = CType(Me.RadComboBoxPriority.SelectedValue, Integer)
                edso.DocLinkList = LinkedDocIds
                edso.DocumentIdList = DocumentIDList
                If MiscFN.IsClientPortal = True Then
                    edso.ClientPortalUserID = Session("UserID")
                End If

                edso.combine = Session("EstimatingCombine")

                If Me.ChkExcludeAttachmentFromEmail.Checked = False Then

                    edso.strFileName = sFileName.Trim()
                    edso.strFileNameJS = sFileNameJS.Trim()
                    edso.strFileNameJV = sFileNameJV.Trim()
                    edso.strFileNameEST = sFileNameEST.Trim()
                    edso.strFileNameCB = sFileNameCB.Trim()
                    edso.strFileNamePS = sFileNamePS.Trim()

                    edso.AlertId = AlertID

                End If

                edso.Send()

            Catch ex As Exception

            End Try

            If IsNTAuth = True Then

                impersonationContext.Undo()

            End If

            Me.CheckForAsyncMessage()

            Return True

        Catch ex As Exception

            ErrorMessage = MiscFN.JavascriptSafe(ex.Message.ToString())
            Return False

        End Try

    End Function
    'This is just for PS regular alert...?
    Private Function SendProjectScheduleAlert()

        If Me.CheckStartDueDate() = False Then Exit Function

        If Me.JobNumber > 0 And Me.JobComponentNbr > 0 Then

            Dim thisAlertID As Integer = 0
            Dim ErrorMessage As String = ""
            thisAlertID = Me.SaveAlert(True)

            Dim str_uname As String = ""
            Dim str_msg As String = ""
            Dim str_cli_code As String = ""
            Dim str_div_code As String = ""
            Dim str_prd_code As String = ""
            Dim str_cli As String = ""
            Dim str_div As String = ""
            Dim str_prod As String = ""
            Dim str_job As String = ""
            Dim str_comp As String = ""
            Dim str_start As String = ""
            Dim str_due As String = ""
            Dim str_stat As String = ""

            Dim bool As Boolean = True

            Dim oTrafficSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
            Try
                Dim dt As DataTable = oTrafficSchedule.GetScheduleHeader(Me.JobNumber, Me.JobComponentNbr, Session("UserCode").ToString(), False).Tables(0)
                If dt.Rows.Count > 0 Then
                    If IsDBNull(dt.Rows(0)("CL_CODE")) = False Then
                        str_cli_code = dt.Rows(0)("CL_CODE")
                        str_cli = dt.Rows(0)("CL_CODE")
                    End If
                    If IsDBNull(dt.Rows(0)("CL_NAME")) = False Then
                        str_cli &= " - " & dt.Rows(0)("CL_NAME")
                    End If
                    If IsDBNull(dt.Rows(0)("DIV_CODE")) = False Then
                        str_div_code = dt.Rows(0)("DIV_CODE")
                        str_div = dt.Rows(0)("DIV_CODE")
                    End If
                    If IsDBNull(dt.Rows(0)("DIV_NAME")) = False Then
                        str_div &= " - " & dt.Rows(0)("DIV_NAME")
                    End If
                    If IsDBNull(dt.Rows(0)("PRD_CODE")) = False Then
                        str_prd_code = dt.Rows(0)("PRD_CODE")
                        str_prod = dt.Rows(0)("PRD_CODE")
                    End If
                    If IsDBNull(dt.Rows(0)("PRD_DESCRIPTION")) = False Then
                        str_prod &= " - " & dt.Rows(0)("PRD_DESCRIPTION")
                    End If
                    If IsDBNull(dt.Rows(0)("JOB_NUMBER")) = False Then
                        str_job = dt.Rows(0)("JOB_NUMBER")
                    End If
                    If IsDBNull(dt.Rows(0)("JOB_DESC")) = False Then
                        str_job &= " - " & dt.Rows(0)("JOB_DESC")
                    End If
                    If IsDBNull(dt.Rows(0)("JOB_COMPONENT_NBR")) = False Then
                        str_comp = dt.Rows(0)("JOB_COMPONENT_NBR")
                    End If
                    If IsDBNull(dt.Rows(0)("JOB_COMP_DESC")) = False Then
                        str_comp &= " - " & dt.Rows(0)("JOB_COMP_DESC")
                    End If
                    If IsDBNull(dt.Rows(0)("TRF_CODE")) = False Then
                        str_stat = dt.Rows(0)("TRF_CODE")
                    End If
                    If IsDBNull(dt.Rows(0)("TRF_DESC")) = False Then
                        str_stat &= " - " & dt.Rows(0)("TRF_DESC")
                    End If
                    If IsDBNull(dt.Rows(0)("START_DATE")) = False Then
                        str_start = dt.Rows(0)("START_DATE")
                    End If
                    If IsDBNull(dt.Rows(0)("JOB_FIRST_USE_DATE")) = False Then
                        str_due = dt.Rows(0)("JOB_FIRST_USE_DATE")
                    End If
                End If
            Catch ex As Exception
            End Try

            'Reports:
            Dim StrFilePrefix As String = Request.PhysicalApplicationPath & "TEMP\"
            Dim StrFilePrefixPS As String = Request.PhysicalApplicationPath & "TEMP\"
            Dim StrFileName As String = ""
            Dim StrFileNamePS As String = ""

            Dim oAppVars As New cAppVars(cAppVars.Application.SCHEDULE_PRINT, Session("UserCode"))
            oAppVars.getAllAppVars()
            Dim s As String = ""
            Dim ar() As String
            s = oAppVars.getAppVar("Location")
            If s = "[None]" Or s = "" Then
                Session("PSLogoLocation") = ""
                Session("PSLogoLocationID") = "None"
            Else
                ar = s.Split("|")
                Session("PSLogoLocation") = ar(1)
                Session("PSLogoLocationID") = ar(0)
            End If

            If Me.ChkIncludeProjectScheduleReport.Checked = True Then
                Dim r As cReports = New cReports(Session("ConnString"))
                Dim StrFileDate As String = "__" & Now.Year.ToString() & Now.Month.ToString() & Now.Day.ToString() & Now.Hour.ToString() & Now.Minute.ToString
                Dim StrFileType As String = ".pdf"
                StrFileName = "Project_Schedule_" & Me.JobNumber.ToString() & "_" & JobComponentNbr.ToString() & AdvantageFramework.StringUtilities.GUID_Date(True, True, True) & StrFileType
                StrFileNamePS = "Project_Schedule_2_" & Me.JobNumber.ToString() & "_" & JobComponentNbr.ToString() & AdvantageFramework.StringUtilities.GUID_Date(True, True, True) & StrFileType
                Dim rpt As New popReportViewer
                Try
                    Dim ThisOptions As String
                    If Request.QueryString("from") = "sfuc" Then
                        ThisOptions = Me.JobNumber.ToString() & "|" & Me.JobComponentNbr.ToString() & "|" & Request.QueryString("hours") & "|" & BoolToInt(Request.QueryString("ms")) & "|" & Request.QueryString("due") & "|" & Request.QueryString("excludeTC") & "|" & Request.QueryString("sort") & "|" & Request.QueryString("phase") & "|" & Request.QueryString("reso") & "|" & Request.QueryString("completed")
                        If Request.QueryString("rpt") = "duedate" Then
                            rpt.renderDoc(StrFilePrefix & StrFileNamePS, "TrafficDetailByJobDueDate", "", "", "", "", "", 1, "", ThisOptions)
                        ElseIf Request.QueryString("rpt") = "dateres" Then
                            rpt.renderDoc(StrFilePrefix & StrFileNamePS, "TrafficDetailByJob2", "", "", "", "", "", 1, "", ThisOptions)
                        ElseIf Request.QueryString("rpt") = "job" Then
                            If Request.QueryString("hours") = 1 Then
                                rpt.renderDoc(StrFilePrefix & StrFileNamePS, "TrafficDetailByJob", "", "", "", "", "", 1, "", ThisOptions)
                            End If
                        ElseIf Request.QueryString("rpt") = "job3" Then
                            rpt.renderDoc(StrFilePrefix & StrFileNamePS, "TrafficDetailByJob3", "", "", "", "", "", 1, "", ThisOptions)
                        ElseIf Request.QueryString("rpt") = "jobDays" Then
                            rpt.renderDoc(StrFilePrefix & StrFileNamePS, "TrafficDetailByJobDays", "", "", "", "", "", 1, "", ThisOptions)
                        ElseIf Request.QueryString("rpt") = "calgantt" Then
                            StrFilePrefixPS = ""
                            StrFileType = ".xls"
                            StrFileNamePS = Me.OutputReportFilePSExcel
                        End If
                        rpt.renderDoc(StrFilePrefix & StrFileName, "TrafficDetailByJob", "", "", "", "", "", 1, "", ThisOptions)
                    Else
                        ThisOptions = Me.JobNumber.ToString() & "|" & Me.JobComponentNbr.ToString() & "||0"
                        rpt.renderDoc(StrFilePrefix & StrFileName, "TrafficDetailByJob", "", "", "", "", "", 1, "", ThisOptions)
                    End If

                Catch ex As Exception
                    StrFileName = ""
                    StrFileNamePS = ""
                End Try
            Else
                Dim r As cReports = New cReports(Session("ConnString"))
                Dim StrFileDate As String = "__" & Now.Year.ToString() & Now.Month.ToString() & Now.Day.ToString() & Now.Hour.ToString() & Now.Minute.ToString
                Dim StrFileType As String = ".pdf"
                StrFileNamePS = "Project_Schedule_2_" & Me.JobNumber.ToString() & "_" & JobComponentNbr.ToString() & AdvantageFramework.StringUtilities.GUID_Date(True, True, True) & StrFileType
                Dim rpt As New popReportViewer
                Try
                    Dim ThisOptions As String
                    If Request.QueryString("from") = "sfuc" Then
                        ThisOptions = Me.JobNumber.ToString() & "|" & Me.JobComponentNbr.ToString() & "|" & Request.QueryString("hours") & "|" & Request.QueryString("ms") & "|" & Request.QueryString("due") & "|" & Request.QueryString("excludeTC") & "|" & Request.QueryString("sort") & "|" & Request.QueryString("phase") & "|" & Request.QueryString("reso") & "|" & Request.QueryString("completed")
                        If Request.QueryString("rpt") = "duedate" Then
                            rpt.renderDoc(StrFilePrefix & StrFileNamePS, "TrafficDetailByJobDueDate", "", "", "", "", "", 1, "", ThisOptions)
                        ElseIf Request.QueryString("rpt") = "dateres" Then
                            rpt.renderDoc(StrFilePrefix & StrFileNamePS, "TrafficDetailByJob2", "", "", "", "", "", 1, "", ThisOptions)
                        ElseIf Request.QueryString("rpt") = "job" Then
                            'If Request.QueryString("hours") = 1 Then
                            rpt.renderDoc(StrFilePrefix & StrFileNamePS, "TrafficDetailByJob", "", "", "", "", "", 1, "", ThisOptions)
                            'If
                        ElseIf Request.QueryString("rpt") = "job3" Then
                            rpt.renderDoc(StrFilePrefix & StrFileNamePS, "TrafficDetailByJob3", "", "", "", "", "", 1, "", ThisOptions)
                        ElseIf Request.QueryString("rpt") = "jobDays" Then
                            rpt.renderDoc(StrFilePrefix & StrFileNamePS, "TrafficDetailByJobDays", "", "", "", "", "", 1, "", ThisOptions)
                        ElseIf Request.QueryString("rpt") = "calgantt" Then
                            StrFilePrefixPS = ""
                            StrFileType = ".xls"
                            StrFileNamePS = Me.OutputReportFilePSExcel
                        End If
                    Else
                        StrFileNamePS = ""
                    End If

                Catch ex As Exception
                    StrFileNamePS = ""
                End Try
            End If

            Try
                Dim ThisAlert As New Alert(Session("ConnString"))
                If ThisAlert.LoadByPrimaryKey(thisAlertID) = True Then
                    Try
                        If StrFileName <> "" Then
                            Dim Document As New Document(Session("ConnString"))
                            Dim Repository As New DocumentRepository(Session("ConnString"))

                            Dim DocumentId As Integer = 0
                            Dim FInfo As FileInfo
                            FInfo = New FileInfo(StrFilePrefix & StrFileName)
                            Dim FileLength As Long = 0
                            FileLength = FInfo.Length
                            Dim FileBytes(FileLength - 1) As Byte

                            Dim FileStream As System.IO.FileStream = FInfo.OpenRead()
                            FileStream.Read(FileBytes, 0, FileLength)
                            Dim realFilename As String = ""
                            realFilename = MiscFN.ParseLast(StrFileName, "\")

                            Dim RepositoryFilenamePS As String = ""
                            RepositoryFilenamePS = "a_" & Guid.NewGuid.ToString()
                            DocumentId = 0
                            Try
                                Dim impersonationContext As System.Security.Principal.WindowsImpersonationContext
                                If IsNTAuth = True Then
                                    Me.currentWindowsIdentity = CType(HttpContext.Current.User.Identity, System.Security.Principal.WindowsIdentity)
                                    impersonationContext = Me.currentWindowsIdentity.Impersonate()
                                End If
                                'db stuff here
                                DocumentId = Document.Add(realFilename, "application/pdf", RepositoryFilenamePS, FileLength, Session("UserCode"), "", "")
                                If IsClientPortal = True Then
                                    ThisAlert.AddAttachment(DocumentId, "", Session("UserID"))
                                Else
                                    ThisAlert.AddAttachment(DocumentId, Session("UserCode"), 0)
                                End If
                                If IsNTAuth = True Then
                                    impersonationContext.Undo()
                                End If
                            Catch ex As Exception
                            End Try
                            Dim RepFNameTemp As String = Repository.AddDocument(realFilename, FileBytes, "", "", Session("userCode"), "Alert View", "Attached Doc", "a_", RepositoryFilenamePS)
                            FileStream.Close()
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If StrFileNamePS <> "" Then
                            Dim Document As New Document(Session("ConnString"))
                            Dim Repository As New DocumentRepository(Session("ConnString"))

                            Dim DocumentId As Integer = 0
                            Dim FInfo As FileInfo
                            FInfo = New FileInfo(StrFilePrefixPS & StrFileNamePS)
                            Dim FileLength As Long = 0
                            FileLength = FInfo.Length
                            Dim FileBytes(FileLength - 1) As Byte

                            Dim FileStream As System.IO.FileStream = FInfo.OpenRead()
                            FileStream.Read(FileBytes, 0, FileLength)
                            Dim realFilename As String = ""
                            realFilename = MiscFN.ParseLast(StrFileNamePS, "\")

                            Dim RepositoryFilenamePS As String = ""
                            RepositoryFilenamePS = "a_" & Guid.NewGuid.ToString()
                            DocumentId = 0
                            Try
                                Dim impersonationContext As System.Security.Principal.WindowsImpersonationContext
                                If IsNTAuth = True Then
                                    Me.currentWindowsIdentity = CType(HttpContext.Current.User.Identity, System.Security.Principal.WindowsIdentity)
                                    impersonationContext = Me.currentWindowsIdentity.Impersonate()
                                End If
                                'db stuff here
                                Dim ThisMimeType As String = "application/pdf"
                                If StrFileNamePS.IndexOf(".xls") > -1 Then
                                    ThisMimeType = "application/msexcel"
                                End If
                                DocumentId = Document.Add(realFilename, ThisMimeType, RepositoryFilenamePS, FileLength, Session("UserCode"), "", "")
                                If IsClientPortal = True Then
                                    ThisAlert.AddAttachment(DocumentId, "", Session("UserID"))
                                Else
                                    ThisAlert.AddAttachment(DocumentId, Session("UserCode"), 0)
                                End If
                                If IsNTAuth = True Then
                                    impersonationContext.Undo()
                                End If
                            Catch ex As Exception
                            End Try
                            Dim RepFNameTemp As String = Repository.AddDocument(realFilename, FileBytes, "", "", Session("userCode"), "Alert View", "Attached Doc", "a_", RepositoryFilenamePS)
                            FileStream.Close()
                        End If
                    Catch ex As Exception
                    End Try
                End If
            Catch ex As Exception
            End Try

            Dim StrEmps As String = Me.AutoCompleteRecipients.GetCommaDelimitedStringOfEmployeeCodes() 'Me.TxtRecipients.Value
            StrEmps &= "," & Session("EmpCode").ToString()

            Dim dtEmailList As New DataTable

            Try
                Dim impersonationContext As System.Security.Principal.WindowsImpersonationContext
                If IsNTAuth = True Then
                    Me.currentWindowsIdentity = CType(HttpContext.Current.User.Identity, System.Security.Principal.WindowsIdentity)
                    impersonationContext = Me.currentWindowsIdentity.Impersonate()
                End If

                'db stuff here
                dtEmailList = oTrafficSchedule.NotifyGetEmailEmployees(StrEmps, thisAlertID)

                If IsNTAuth = True Then
                    impersonationContext.Undo()
                End If
            Catch ex As Exception
            End Try

            Dim ws As New cWebServices(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"), HttpContext.Current.Session("EmpCode"))
            Dim CurrEmpName As String = ""
            Dim CurrEmpEmail As String = ""

            'Dim strTasksTable As String = BodyTasks(Me.JobNumber, Me.JobComponentNbr)

            Dim strAddress As String = ""

            '''Dim sbEmailBody As New System.Text.StringBuilder

            If dtEmailList.Rows.Count > 0 Then

                Dim StrAlertBodyString As String = ""
                Dim StrAlertBodyHTML As String = ""
                Dim StrAlertBodyLink As String = "Please see schedule application for details."

                'Gather General Information section of email
                'By this time, impersonation should be off:
                Dim impersonationContext As System.Security.Principal.WindowsImpersonationContext
                If IsNTAuth = True Then
                    Me.currentWindowsIdentity = CType(HttpContext.Current.User.Identity, System.Security.Principal.WindowsIdentity)
                    impersonationContext = Me.currentWindowsIdentity.Impersonate()
                End If

                Dim alert As New Alert(Session("ConnString"))
                'Dim strGeneralInfo As String = alert.GeneralInfo(thisAlertID)

                Dim sb As New System.Text.StringBuilder
                For i As Integer = 0 To dtEmailList.Rows.Count - 1
                    With sb
                        If Not IsDBNull(dtEmailList.Rows(i)("EMP_EMAIL")) = True Then
                            If AdvantageFramework.Email.IsValidEmailAddress(dtEmailList.Rows(i)("EMP_EMAIL")) = True Then
                                'If i = 0 Then
                                '    CurrEmpEmail = dtEmailList.Rows(i)("MAILBEE_TITLE")
                                'Else
                                .Append(dtEmailList.Rows(i)("MAILBEE_TITLE"))
                                .Append(",")
                                'End If
                            End If
                        End If
                    End With
                Next

                Dim url As String
                Dim csec As New cSecurity(Session("ConnString"))
                Dim dr As SqlClient.SqlDataReader
                dr = csec.getSettingsCP()
                If dr.HasRows = True Then
                    Do While dr.Read
                        url = Request.Url.Scheme & "://" & dr.GetString(0)
                    Loop
                    dr.Close()
                Else
                    url = Request.Url.Scheme & "://" & Request.Url.Host & "/" & Request.ApplicationPath
                End If

                Dim MyEmailBody As New AdvantageFramework.Email.Classes.HtmlEmail(True)
                If Me.BodyRadEditor.Text.Trim() <> "" Then
                    MyEmailBody.AddCustomRow(Me.BodyRadEditor.Html.ToString())
                    MyEmailBody.AddBlankRow()
                End If

                If Me.CheckboxIsAssignment.Checked = False Then

                    MyEmailBody.AddHyperlinkRow(url & "/Desktop_AlertView?SprintID=0&AlertID=" & thisAlertID, AdvantageFramework.AlertSystem.WebvantageAlertLinkVerbiage)

                    If Me.CheckBoxIncludeProjectScheduleInHTML.Checked = True Then

                        Me.ProjectScheduleHeader(MyEmailBody, str_cli, str_div, str_prod, str_job, str_comp, str_start, str_due, str_stat)
                        MyEmailBody.AddCustomRow(Me.ProjectScheduleTasksTable(Me.JobNumber, Me.JobComponentNbr))
                        MyEmailBody.AddBlankRow()

                        MyEmailBody.AddHyperlinkRow(url & "/Desktop_AlertView?SprintID=0&AlertID=" & thisAlertID, AdvantageFramework.AlertSystem.WebvantageAlertLinkVerbiage)

                    End If

                End If

                MyEmailBody.Finish()

                Dim FinalEmailBody As String = ""
                FinalEmailBody = MyEmailBody.ToString(thisAlertID)

                Try
                    Dim arP(1) As SqlParameter

                    Dim pBody As New SqlParameter("@BODY", SqlDbType.Text)
                    pBody.Value = FinalEmailBody
                    arP(0) = pBody

                    SqlHelper.ExecuteNonQuery(Session("ConnString"), CommandType.Text, "UPDATE ALERT WITH(ROWLOCK) SET IS_DRAFT = 0, BODY = @BODY, BODY_HTML = @BODY WHERE ALERT_ID = " & thisAlertID & ";", arP)
                Catch ex As Exception
                End Try

                CheckToCopyAlertCommentsAndAttachments(thisAlertID)

                Dim StrEmails As String = sb.ToString()
                StrEmails = MiscFN.CleanStringForSplit(StrEmails, ",", False, True, True, True)
                Try

                    Dim edso As New EmailWithDocumentsSessionObject()
                    edso.ConnectionString = Session("ConnString")
                    edso.UserCode = Session("UserCode")
                    edso.EmployeeCode = Session("EmpCode")
                    edso.SessionID = HttpContext.Current.Session.SessionID.ToString()
                    edso.PhysicalApplicationPath = HttpContext.Current.Request.PhysicalApplicationPath
                    edso.strTo = StrEmails
                    edso.strSubject = Me.txtSubject.Text.Trim()
                    edso.strBody = FinalEmailBody.ToString().Trim()
                    edso.Priority = CType(Me.RadComboBoxPriority.SelectedValue, Integer)

                    If MiscFN.IsClientPortal = True Then
                        edso.ClientPortalUserID = Session("UserID")
                    End If

                    edso.combine = Session("EstimatingCombine")
                    edso.AlertId = thisAlertID
                    edso.Send()

                Catch ex As Exception

                End Try
                'bool = ws.SendEmailWAttachments(thisAlertID, CurrEmpEmail, Me.txtSubject.Text, FinalEmailBody.ToString(), StrEmails, ",", True, CType(Me.RadComboBoxPriority.SelectedValue, Integer), IsNTAuth)

                'If StrFileName <> "" Then
                '    Try
                '        File.Delete(StrFilePrefix & StrFileName)
                '    Catch ex As Exception
                '    End Try
                'End If
                If IsNTAuth = True Then
                    impersonationContext.Undo()
                End If
            End If
            If bool = False Then

                Me.ShowMessage(ws.getErrMsg)

            Else

                If ws.err_msg.Contains(Alert.BaseMessageIsOverSizedMessage) Then

                    Me.ShowMessage(ws.getErrMsg)

                End If

                Me.GoBack()

            End If
        End If
    End Function

#End Region
#Region " Custom Email body "

    Private Sub ProjectScheduleHeader(ByRef EmailBody As AdvantageFramework.Email.Classes.HtmlEmail, ByVal TheClient As String, ByVal TheDivision As String, ByVal TheProduct As String, ByVal TheJob As String, ByVal TheComponent As String,
                                ByVal TheStartDate As String, ByVal TheDueDate As String, ByVal TheStatus As String)
        If cGlobals.wvIsDate(TheStartDate) = True Then
            TheStartDate = cGlobals.wvCDate(TheStartDate).ToShortDateString
        End If
        If cGlobals.wvIsDate(TheDueDate) = True Then
            TheDueDate = cGlobals.wvCDate(TheDueDate).ToShortDateString
        End If
        With EmailBody
            'Project schedule info:
            .AddHeaderRow("Project Schedule Details")
            .AddKeyValueRow("Client", TheClient)
            .AddKeyValueRow("Division", TheDivision)
            .AddKeyValueRow("Product", TheProduct)
            .AddKeyValueRow("Job", TheJob)
            .AddKeyValueRow("Component", TheComponent)
            .AddKeyValueRow("Status", TheStatus)
            .AddKeyValueRow("Start", TheStartDate)
            .AddKeyValueRow("Due", TheDueDate)
            .AddBlankRow()
        End With
    End Sub
    Private Function ProjectScheduleTasksTable(ByVal JNum As Integer, ByVal JCNum As Integer) As String
        Dim BoolNextDueMarked As Boolean = False
        Dim NextDueFontStyle As String = ""  ' = " color=""#FF0000"""
        Dim BoolAlternate As Boolean = False
        Dim AltColor As String = ""

        Dim sb As New System.Text.StringBuilder
        With sb
            .Append("<table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""2"" bgcolor=""" & AdvantageFramework.Email.BodyBackgroundColor & """>")
            .Append("  <tr>")
            .Append("    <td align=""left"" valign=""middle"" width=""50%"" bgcolor=""" & AdvantageFramework.Email.RowBackgroundColor & """><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.RowFontColor & """>Task</font></td>")
            .Append("    <td align=""left"" valign=""middle"" width=""20%"" bgcolor=""" & AdvantageFramework.Email.RowBackgroundColor & """><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.RowFontColor & """>Employees</font></td>")
            .Append("    <td align=""right"" valign=""middle"" width=""10%"" bgcolor=""" & AdvantageFramework.Email.RowBackgroundColor & """><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.RowFontColor & """>Start</font></td>")
            .Append("    <td align=""right"" valign=""middle"" width=""10%"" bgcolor=""" & AdvantageFramework.Email.RowBackgroundColor & """><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.RowFontColor & """>Due</font></td>")
            .Append("    <td align=""right"" valign=""middle"" width=""10%"" bgcolor=""" & AdvantageFramework.Email.RowBackgroundColor & """><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.RowFontColor & """>Completed</font></td>")
            .Append("  </tr>")
            Dim oTrafficSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
            Dim dt As New DataTable
            dt = oTrafficSchedule.GetScheduleTasks(JNum, JCNum, "", CStr(Session("UserCode")), "", "", "", True, False, False)
            Dim ThisSEQ As Integer = 0
            Dim ThisTask As String = ""
            Dim ThisEmpListString As String = ""
            Dim ThisStartDate As String = ""
            Dim ThisDueDate As String = ""
            Dim ThisCompletedDate As String = ""
            Dim ThisTaskComment As String = ""
            For i As Integer = 0 To dt.Rows.Count - 1
                If IsDBNull(dt.Rows(i)("TASK_CODE")) = False Then
                    ThisTask = dt.Rows(i)("TASK_CODE")
                Else
                    ThisTask = "&nbsp;"
                End If
                If IsDBNull(dt.Rows(i)("TASK_DESCRIPTION")) = False Then
                    ThisTask &= " - " & dt.Rows(i)("TASK_DESCRIPTION")
                    'Else
                    '    ThisTask = "&nbsp;"
                End If
                'emps!
                If IsDBNull(dt.Rows(i)("TASK_START_DATE")) = False Then
                    ThisStartDate = dt.Rows(i)("TASK_START_DATE")
                Else
                    ThisStartDate = "&nbsp;"
                End If
                If IsDBNull(dt.Rows(i)("JOB_REVISED_DATE")) = False Then
                    ThisDueDate = dt.Rows(i)("JOB_REVISED_DATE")
                Else
                    ThisDueDate = "&nbsp;"
                End If
                If IsDBNull(dt.Rows(i)("JOB_COMPLETED_DATE")) = False Then
                    ThisCompletedDate = dt.Rows(i)("JOB_COMPLETED_DATE")
                Else
                    ThisCompletedDate = "&nbsp;"
                End If
                If IsDBNull(dt.Rows(i)("FNC_COMMENTS")) = False Then
                    ThisTaskComment = dt.Rows(i)("FNC_COMMENTS")
                Else
                    ThisTaskComment = ""
                End If

                If cGlobals.wvIsDate(ThisStartDate) = True Then
                    ThisStartDate = cGlobals.wvCDate(ThisStartDate).ToShortDateString
                Else
                    ThisStartDate = "&nbsp;"
                End If
                If cGlobals.wvIsDate(ThisDueDate) = True Then
                    ThisDueDate = cGlobals.wvCDate(ThisDueDate).ToShortDateString
                Else
                    ThisDueDate = "&nbsp;"
                End If
                If cGlobals.wvIsDate(ThisCompletedDate) = True Then
                    ThisCompletedDate = cGlobals.wvCDate(ThisCompletedDate).ToShortDateString
                Else
                    ThisCompletedDate = "&nbsp;"
                    If BoolNextDueMarked = False Then
                        NextDueFontStyle = " color=""#FF0000"""
                        BoolNextDueMarked = True
                    Else
                        NextDueFontStyle = ""
                    End If
                End If

                If IsDBNull(dt.Rows(i)("SEQ_NBR")) = False Then
                    ThisSEQ = CType(dt.Rows(i)("SEQ_NBR"), Integer)
                Else
                    ThisSEQ = -1
                End If

                If BoolAlternate = True Then
                    AltColor = " bgcolor=""#FFFFFF"""
                Else
                    AltColor = " bgcolor=""#DADADA"""
                End If

                .Append("  <tr>")
                .Append("    <td align=""left"" valign=""top""" & AltColor & "><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """" & NextDueFontStyle & ">" & ThisTask & "</font></td>") 'task
                If ThisSEQ >= 0 Then
                    Dim strEmps As String = oTrafficSchedule.GetTaskEmpListString(JNum, JCNum, ThisSEQ)
                    .Append("    <td align=""left"" valign=""top""" & AltColor & "><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """" & NextDueFontStyle & ">" & strEmps & "</font></td>") 'emps
                Else
                    .Append("    <td align=""left"" valign=""top""" & AltColor & "><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """" & NextDueFontStyle & ">&nbsp;</font></td>") 'emps
                End If
                .Append("    <td align=""right"" valign=""top""" & AltColor & "><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """" & NextDueFontStyle & ">" & ThisStartDate & "</font></td>") 'start
                .Append("    <td align=""right"" valign=""top""" & AltColor & "><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """" & NextDueFontStyle & ">" & ThisDueDate & "</font></td>") 'due
                .Append("    <td align=""right"" valign=""top""" & AltColor & "><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """" & NextDueFontStyle & ">" & ThisCompletedDate & "</font></td>") 'completed
                .Append("  </tr>")
                If ThisTaskComment.Length > 0 Then
                    .Append("  <tr>")
                    .Append("    <td colspan=""5"" align=""left"" valign=""top""" & AltColor & "><font size=""1"" face=""" & AdvantageFramework.Email.Font & """>Task Comments:&nbsp;&nbsp;" & ThisTaskComment & "</font></td>")
                    .Append("  </tr>")
                End If

                BoolAlternate = Not BoolAlternate
            Next
            .Append("</table>")
        End With
        Return sb.ToString()
    End Function

    Private Sub EstimateHeader(ByRef EmailBody As AdvantageFramework.Email.Classes.HtmlEmail, ByVal TheClient As String, ByVal TheDivision As String, ByVal TheProduct As String, ByVal TheJob As String, ByVal TheComponent As String,
                                ByVal TheEst As String, ByVal TheEstComp As String, ByVal TheAccountExec As String, ByVal TheClientRef As String, ByVal TheMarkup As String)
        With EmailBody
            'Project schedule info:
            .AddHeaderRow("Estimate")
            .AddKeyValueRow("Client", TheClient)
            .AddKeyValueRow("Division", TheDivision)
            .AddKeyValueRow("Product", TheProduct)
            .AddKeyValueRow("Job", TheJob)
            .AddKeyValueRow("Component", TheComponent)
            .AddKeyValueRow("Estimate", TheEst)
            .AddKeyValueRow("Component", TheEstComp)
            .AddKeyValueRow("Account Executive", TheAccountExec)
            .AddKeyValueRow("Client Ref", TheClientRef)
            .AddBlankRow()
        End With
    End Sub
    Private Function EstimateQuotes(ByVal EstNum As Integer, ByVal ECNum As Integer, ByVal QNum As Integer) As String
        Dim oEstimating As cEstimating = New cEstimating(Session("ConnString"), CStr(Session("UserCode")))
        Dim BoolNextDueMarked As Boolean = False
        Dim NextDueFontStyle As String = ""  ' = " color=""#FF0000"""
        Dim BoolAlternate As Boolean = False
        Dim AltColor As String = ""
        Dim dr As SqlDataReader
        Dim max As Integer
        max = oEstimating.GetEstimateQuoteMaxRevision(EstNum, ECNum, QNum)
        dr = oEstimating.GetEstimateQuoteInfo(EstNum, ECNum, QNum, max)
        dr.Read()
        Dim sb As New System.Text.StringBuilder
        With sb
            'quote header
            .Append("<table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""2"" bgcolor=""" & AdvantageFramework.Email.BodyBackgroundColor & """>")
            .Append("  <tr>")
            .Append("    <td align=""left"" valign=""middle""><font size=""" & AdvantageFramework.Email.HeaderFontSize & """ face=""" & AdvantageFramework.Email.Font & """><li>Quote:&nbsp;&nbsp;" & dr("EST_QUOTE_NBR").ToString.PadLeft(3, "0") & " - " & dr("EST_QUOTE_DESC") & " - Revision " & dr("EST_REV_NBR").ToString.PadLeft(3, "0") & "</li></font></td>")
            .Append("  </tr>")
            .Append("</table>")

            'items
            .Append("<table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""2"" bgcolor=""" & AdvantageFramework.Email.BodyBackgroundColor & """>")
            .Append("  <tr>")
            .Append("    <td align=""left"" valign=""middle"" width=""50%"" bgcolor=""" & AdvantageFramework.Email.RowBackgroundColor & """><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.RowFontColor & """>Function</font></td>")
            .Append("    <td align=""right"" valign=""middle"" width=""50%"" bgcolor=""" & AdvantageFramework.Email.RowBackgroundColor & """><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.RowFontColor & """>Total</font></td>")
            .Append("  </tr>")

            Dim ds As New DataSet

            ds = oEstimating.GetEstimateQuoteDetailsAlert(EstNum, ECNum, QNum, max)
            Dim ThisSEQ As Integer = 0
            Dim ThisFunction As String = ""
            Dim ThisSuppliedBy As String = ""
            Dim ThisStartDate As String = ""
            Dim ThisTotal As Decimal
            Dim ThisCompletedDate As String = ""
            Dim ThisTaskComment As String = ""
            Dim ThisFncType As String = ""
            Dim ThisFncTypeDesc As String = ""
            Dim fnctype As String = ""
            Dim totalEst As Decimal = 0.0
            Dim totalEstType As Decimal = 0.0
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                If IsDBNull(ds.Tables(0).Rows(i)("FNC_TYPE")) = False Then
                    ThisFncType = ds.Tables(0).Rows(i)("FNC_TYPE")
                    If fnctype <> ThisFncType Then
                        If fnctype <> "" Then
                            .Append("  <tr>")
                            .Append("    <td align=""left"" valign=""top""" & AltColor & "><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """" & NextDueFontStyle & "></font></td>")
                            .Append("    <td align=""right"" valign=""top""" & AltColor & "><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """" & NextDueFontStyle & ">Total for " & ThisFncTypeDesc & ":&nbsp;&nbsp;&nbsp;&nbsp;" & totalEstType.ToString("#,##0.00") & "</font></td>")
                            .Append("  </tr>")
                            totalEstType = 0.0
                        End If
                        If IsDBNull(ds.Tables(0).Rows(i)("FNC_TYPE_DESC")) = False Then
                            ThisFncTypeDesc = ds.Tables(0).Rows(i)("FNC_TYPE_DESC")
                        End If
                        .Append("  <tr>")
                        .Append("    <td align=""left"" valign=""top""" & AltColor & "><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """" & NextDueFontStyle & ">&nbsp;Type:" & ThisFncTypeDesc & "</font></td>")
                        .Append("    <td align=""right"" valign=""top""" & AltColor & "><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """" & NextDueFontStyle & "></font></td>") 'due
                        .Append("  </tr>")
                    End If
                    fnctype = ThisFncType
                End If
                If IsDBNull(ds.Tables(0).Rows(i)("FNC_DESCRIPTION")) = False Then
                    ThisFunction = ds.Tables(0).Rows(i)("FNC_DESCRIPTION")
                End If
                'emps!
                If IsDBNull(ds.Tables(0).Rows(i)("EST_REV_SUP_BY_CDE")) = False Then
                    ThisSuppliedBy = ds.Tables(0).Rows(i)("EST_REV_SUP_BY_CDE")
                Else
                    ThisSuppliedBy = "&nbsp;"
                End If
                If IsDBNull(ds.Tables(0).Rows(i)("LINE_TOTAL")) = False Then
                    ThisTotal = ds.Tables(0).Rows(i)("LINE_TOTAL")
                    totalEst += ds.Tables(0).Rows(i)("LINE_TOTAL")
                    totalEstType += ds.Tables(0).Rows(i)("LINE_TOTAL")
                Else
                    ThisTotal = 0.0
                End If
                If BoolAlternate = True Then
                    AltColor = " bgcolor=""#FFFFFF"""
                Else
                    AltColor = " bgcolor=""#DADADA"""
                End If

                .Append("  <tr>")
                .Append("    <td align=""left"" valign=""top""" & AltColor & "><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """" & NextDueFontStyle & ">&nbsp;&nbsp;&nbsp;&nbsp;" & ThisFunction & "</font></td>") 'task
                .Append("    <td align=""right"" valign=""top""" & AltColor & "><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """" & NextDueFontStyle & ">" & ThisTotal.ToString("#,##0.00") & "</font></td>") 'due
                .Append("  </tr>")

                BoolAlternate = Not BoolAlternate
            Next
            .Append("  <tr>")
            .Append("    <td align=""left"" valign=""top""" & AltColor & "><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """" & NextDueFontStyle & ">&nbsp;</font></td>")
            .Append("    <td align=""right"" valign=""top""" & AltColor & "><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """" & NextDueFontStyle & ">Total for " & ThisFncTypeDesc & ":&nbsp;&nbsp;&nbsp;&nbsp;" & totalEstType.ToString("#,##0.00") & "</font></td>")
            .Append("  </tr>")
            .Append("  <tr>")
            .Append("    <td align=""left"" valign=""top""" & AltColor & "><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """" & NextDueFontStyle & ">&nbsp;</font></td>")
            .Append("    <td align=""right"" valign=""top""" & AltColor & "><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """" & NextDueFontStyle & ">Total:&nbsp;&nbsp;&nbsp;&nbsp;" & totalEst.ToString("#,##0.00") & "</font></td>")
            .Append("  </tr>")
            .Append("  <tr><td colspan=""2"">&nbsp;</td></tr>")
            .Append("  <tr><td colspan=""2"">&nbsp;</td></tr>")
            .Append("</table>")
            dr.Close()
        End With
        Return sb.ToString()
    End Function

    Private Function EmailBodyTask(ByVal JNum As Integer, ByVal JCNum As Integer, ByVal SNum As Integer) As String
        Dim BoolNextDueMarked As Boolean = False
        Dim NextDueFontStyle As String = ""  ' = " color=""#FF0000"""
        Dim BoolAlternate As Boolean = False
        Dim AltColor As String = ""

        Dim oTrafficSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
        Dim dt As New DataTable
        dt = oTrafficSchedule.GetScheduleTask(JNum, JCNum, SNum)
        Dim ThisPhase As String = ""
        Dim ThisTask As String = ""
        Dim ThisTaskStatus As String = ""
        Dim ThisEmpListString As String = ""
        Dim ThisStartDate As String = ""
        Dim ThisDueDate As String = ""
        Dim ThisCompletedDate As String = ""
        Dim ThisTimeDue As String = ""
        Dim ThisTaskComment As String = ""
        Dim ThisDueDateComment As String = ""
        Dim ThisRevisedDateComment As String = ""
        For i As Integer = 0 To dt.Rows.Count - 1
            If IsDBNull(dt.Rows(i)("PHASE_DESC")) = False Then
                ThisPhase = dt.Rows(i)("PHASE_DESC")
            Else
                ThisPhase = "&nbsp;"
            End If
            If IsDBNull(dt.Rows(i)("TASK_CODE")) = False Then
                ThisTask = dt.Rows(i)("TASK_CODE")
            Else
                ThisTask = "&nbsp;"
            End If
            If IsDBNull(dt.Rows(i)("TASK_DESCRIPTION")) = False Then
                ThisTask &= " - " & dt.Rows(i)("TASK_DESCRIPTION")
                'Else
                '    ThisTask = "&nbsp;"
            End If
            If IsDBNull(dt.Rows(i)("TASK_STATUS")) = False Then
                If dt.Rows(i)("TASK_STATUS") = "P" Then
                    ThisTaskStatus = "Projected"
                ElseIf dt.Rows(i)("TASK_STATUS") = "A" Then
                    ThisTaskStatus = "Active"
                ElseIf dt.Rows(i)("TASK_STATUS") = "H" Then
                    ThisTaskStatus = "High Priority"
                ElseIf dt.Rows(i)("TASK_STATUS") = "L" Then
                    ThisTaskStatus = "Low Priority"
                End If
            Else
                ThisTaskStatus = "&nbsp;"
            End If
            'emps!
            If IsDBNull(dt.Rows(i)("TASK_START_DATE")) = False Then
                ThisStartDate = dt.Rows(i)("TASK_START_DATE")
            Else
                ThisStartDate = "&nbsp;"
            End If
            If IsDBNull(dt.Rows(i)("JOB_REVISED_DATE")) = False Then
                ThisDueDate = dt.Rows(i)("JOB_REVISED_DATE")
            Else
                ThisDueDate = "&nbsp;"
            End If
            If IsDBNull(dt.Rows(i)("REVISED_DUE_TIME")) = False Then
                ThisTimeDue = dt.Rows(i)("REVISED_DUE_TIME")
            Else
                ThisTimeDue = "&nbsp;"
            End If
            If IsDBNull(dt.Rows(i)("JOB_COMPLETED_DATE")) = False Then
                ThisCompletedDate = dt.Rows(i)("JOB_COMPLETED_DATE")
            Else
                ThisCompletedDate = "&nbsp;"
            End If
            If IsDBNull(dt.Rows(i)("FNC_COMMENTS")) = False Then
                ThisTaskComment = dt.Rows(i)("FNC_COMMENTS")
            Else
                ThisTaskComment = ""
            End If
            If IsDBNull(dt.Rows(i)("DUE_DATE_COMMENTS")) = False Then
                ThisDueDateComment = dt.Rows(i)("DUE_DATE_COMMENTS")
            Else
                ThisDueDateComment = ""
            End If
            If IsDBNull(dt.Rows(i)("REV_DATE_COMMENTS")) = False Then
                ThisRevisedDateComment = dt.Rows(i)("REV_DATE_COMMENTS")
            Else
                ThisRevisedDateComment = ""
            End If
        Next
        Dim header As String = Me.EmailBodyTaskHeader(ThisPhase, ThisTask, ThisTaskStatus, ThisStartDate, ThisDueDate, ThisTimeDue, ThisCompletedDate, ThisTaskComment, ThisDueDateComment, ThisRevisedDateComment)

        Dim sb As New System.Text.StringBuilder
        With sb
            .Append(header)
            .Append("<table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""2"" bgcolor=""#FFFFFF"">")
            .Append("  <tr>")
            .Append("    <td align=""left"" valign=""middle"" width=""25%"" bgcolor=""#92B4E0""><font size=""2"" face=""" & AdvantageFramework.Email.Font & """ color=""#FFFFFF""><strong>Employee</strong></font></td>")
            .Append("    <td align=""right"" valign=""middle"" width=""25%"" bgcolor=""#92B4E0""><font size=""2"" face=""" & AdvantageFramework.Email.Font & """ color=""#FFFFFF""><strong>Hours Allowed</strong></font></td>")
            .Append("    <td align=""right"" valign=""middle"" width=""25%"" bgcolor=""#92B4E0""><font size=""2"" face=""" & AdvantageFramework.Email.Font & """ color=""#FFFFFF""><strong>Percent Complete</strong></font></td>")
            .Append("    <td align=""right"" valign=""middle"" width=""25%"" bgcolor=""#92B4E0""><font size=""2"" face=""" & AdvantageFramework.Email.Font & """ color=""#FFFFFF""><strong>Completed Date</strong></font></td>")
            .Append("  </tr>")
            Dim dtEmp As New DataTable
            dt = oTrafficSchedule.GetTaskEmpList(JNum, JCNum, SNum)
            Dim ThisEmployee As String = ""
            Dim ThisHours As String = ""
            Dim ThisPercent As String = ""
            Dim ThisCompDate As String = ""
            For i As Integer = 0 To dt.Rows.Count - 1
                If IsDBNull(dt.Rows(i)("EMP_CODE")) = False Then
                    ThisEmployee = dt.Rows(i)("EMP_CODE")
                Else
                    ThisEmployee = "&nbsp;"
                End If
                If IsDBNull(dt.Rows(i)("HOURS_ALLOWED")) = False Then
                    ThisHours = dt.Rows(i)("HOURS_ALLOWED")
                Else
                    ThisHours = "&nbsp;"
                End If
                If IsDBNull(dt.Rows(i)("PERCENT_COMPLETE")) = False Then
                    ThisPercent = CInt(dt.Rows(i)("PERCENT_COMPLETE")).ToString() & " %"
                Else
                    ThisPercent = "&nbsp;"
                End If
                'emps!
                If IsDBNull(dt.Rows(i)("TEMP_COMP_DATE")) = False Then
                    ThisCompDate = dt.Rows(i)("TEMP_COMP_DATE")
                Else
                    ThisCompDate = "&nbsp;"
                End If

                If cGlobals.wvIsDate(ThisCompDate) = True Then
                    ThisCompDate = cGlobals.wvCDate(ThisCompDate).ToShortDateString
                Else
                    ThisCompDate = "&nbsp;"
                End If

                If BoolAlternate = True Then
                    AltColor = " bgcolor=""#FFFFFF"""
                Else
                    AltColor = " bgcolor=""#E8EEF9"""
                End If

                .Append("  <tr>")
                .Append("    <td align=""left"" valign=""top""" & AltColor & "><font size=""2"" face=""" & AdvantageFramework.Email.Font & """" & NextDueFontStyle & ">" & ThisEmployee & "</font></td>") 'Emp
                .Append("    <td align=""right"" valign=""top""" & AltColor & "><font size=""2"" face=""" & AdvantageFramework.Email.Font & """" & NextDueFontStyle & ">" & ThisHours & "</font></td>") 'hours
                .Append("    <td align=""right"" valign=""top""" & AltColor & "><font size=""2"" face=""" & AdvantageFramework.Email.Font & """" & NextDueFontStyle & ">" & ThisPercent & "</font></td>") 'percent
                .Append("    <td align=""right"" valign=""top""" & AltColor & "><font size=""2"" face=""" & AdvantageFramework.Email.Font & """" & NextDueFontStyle & ">" & ThisCompDate & "</font></td>") 'completed
                .Append("  </tr>")

                BoolAlternate = Not BoolAlternate
            Next
            .Append("</table>")
            .Append("<table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""2"" bgcolor=""#FFFFFF"">")
            .Append("  <tr><td colspan""4"">&nbsp;<td><tr>")
            .Append("  <tr>")
            .Append("    <td align=""left"" valign=""middle"" width=""20%"" bgcolor=""#92B4E0""><font size=""2"" face=""" & AdvantageFramework.Email.Font & """ color=""#FFFFFF""><strong>Employee</strong></font></td>")
            .Append("    <td align=""left"" valign=""middle"" width=""20%"" bgcolor=""#92B4E0""><font size=""2"" face=""" & AdvantageFramework.Email.Font & """ color=""#FFFFFF""><strong>Date</strong></font></td>")
            .Append("    <td align=""left"" valign=""middle"" width=""20%"" bgcolor=""#92B4E0""><font size=""2"" face=""" & AdvantageFramework.Email.Font & """ color=""#FFFFFF""><strong>Time</strong></font></td>")
            .Append("    <td align=""left"" valign=""middle"" width=""20%"" bgcolor=""#92B4E0""><font size=""2"" face=""" & AdvantageFramework.Email.Font & """ color=""#FFFFFF""><strong>Comment</strong></font></td>")
            .Append("  </tr>")
            Dim dtComment As New DataTable
            dt = oTrafficSchedule.GetTrafficDetComments(JNum, JCNum, SNum)
            Dim ThisCommentLog As String = ""
            Dim ThisEmp As String = ""
            Dim ThisDate As String = ""
            Dim ThisTime As String = ""
            Dim ThisComment As String = ""
            For i As Integer = 0 To dt.Rows.Count - 1
                If IsDBNull(dt.Rows(i)("CREATE_USER")) = False Then
                    ThisEmp = dt.Rows(i)("CREATE_USER")
                Else
                    ThisEmp = "&nbsp;"
                End If
                If IsDBNull(dt.Rows(i)("CREATE_DATE")) = False Then
                    ThisDate = CDate(dt.Rows(i)("CREATE_DATE")).ToShortDateString
                Else
                    ThisDate = "&nbsp;"
                End If
                'emps!
                If IsDBNull(dt.Rows(i)("CREATE_TIME")) = False Then
                    ThisTime = CDate(dt.Rows(i)("CREATE_TIME")).ToShortTimeString
                Else
                    ThisTime = "&nbsp;"
                End If
                If IsDBNull(dt.Rows(i)("COMMENT")) = False Then
                    ThisComment = dt.Rows(i)("COMMENT")
                Else
                    ThisComment = "&nbsp;"
                End If

                If cGlobals.wvIsDate(ThisCompDate) = True Then
                    ThisCompDate = cGlobals.wvCDate(ThisCompDate).ToShortDateString
                Else
                    ThisCompDate = "&nbsp;"
                End If
                If BoolAlternate = True Then
                    AltColor = " bgcolor=""#FFFFFF"""
                Else
                    AltColor = " bgcolor=""#E8EEF9"""
                End If

                .Append("  <tr>")
                .Append("    <td align=""left"" valign=""top""" & AltColor & "><font size=""2"" face=""" & AdvantageFramework.Email.Font & """" & NextDueFontStyle & ">" & ThisEmp & "</font></td>") 'hours
                .Append("    <td align=""left"" valign=""top""" & AltColor & "><font size=""2"" face=""" & AdvantageFramework.Email.Font & """" & NextDueFontStyle & ">" & ThisDate & "</font></td>") 'percent
                .Append("    <td align=""left"" valign=""top""" & AltColor & "><font size=""2"" face=""" & AdvantageFramework.Email.Font & """" & NextDueFontStyle & ">" & ThisTime & "</font></td>") 'completed
                .Append("    <td align=""left"" valign=""top""" & AltColor & "><font size=""2"" face=""" & AdvantageFramework.Email.Font & """" & NextDueFontStyle & ">" & ThisComment & "</font></td>") 'hours
                .Append("  </tr>")

                BoolAlternate = Not BoolAlternate
            Next
            .Append("</table>")
        End With
        Return sb.ToString()
    End Function
    Private Function EmailBodyTaskHeader(ByVal ThePhase As String, ByVal TheTask As String, ByVal TheStatus As String, ByVal TheStartDate As String,
                                 ByVal TheDueDate As String, ByVal TheTimeDue As String, ByVal TheCompletedDate As String,
                                 ByVal TheTaskComments As String, ByVal TheDueDateComments As String, ByVal TheRevisedDateComments As String) As String
        If cGlobals.wvIsDate(TheStartDate) = True Then
            TheStartDate = cGlobals.wvCDate(TheStartDate).ToShortDateString
        End If
        If cGlobals.wvIsDate(TheDueDate) = True Then
            TheDueDate = cGlobals.wvCDate(TheDueDate).ToShortDateString
        End If
        Dim sb As New System.Text.StringBuilder
        With sb
            .Append("<table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""2"" bgcolor=""#FFFFFF"">")
            .Append("  <tr>")
            .Append("    <td height=""23"" colspan=""4"" align=""left"" valign=""middle"" bgcolor=""#92B4E0""><font size=""2"" face=""" & AdvantageFramework.Email.Font & """ color=""#FFFFFF""><strong>&nbsp;&nbsp;Project Schedule Task Update</strong></font></td>")
            .Append("  </tr>")
            .Append("  <tr>")
            .Append("    <td width=""20%"" align=""right"" valign=""middle""><font size=""2"" face=""" & AdvantageFramework.Email.Font & """><strong>Phase:</strong></font></td>")
            .Append("    <td width=""30%"" align=""left"" valign=""middle""><font size=""2"" face=""" & AdvantageFramework.Email.Font & """>" & ThePhase & "</font></td>")
            .Append("  </tr>")
            .Append("  <tr>")
            .Append("    <td align=""right"" valign=""middle""><font size=""2"" face=""" & AdvantageFramework.Email.Font & """><strong>Task:</strong></font></td>")
            .Append("    <td align=""left"" valign=""middle""><font size=""2"" face=""" & AdvantageFramework.Email.Font & """>" & TheTask & "</font></td>")
            .Append("  </tr>")
            .Append("  <tr>")
            .Append("    <td align=""right"" valign=""middle""><font size=""2"" face=""" & AdvantageFramework.Email.Font & """><strong>Task Status:</strong></font></td>")
            .Append("    <td align=""left"" valign=""middle""><font size=""2"" face=""" & AdvantageFramework.Email.Font & """>" & TheStatus & "</font></td>")
            .Append("  </tr>")
            .Append("  <tr>")
            .Append("    <td align=""right"" valign=""middle""><font size=""2"" face=""" & AdvantageFramework.Email.Font & """><strong>Task Start Date:</strong></font></td>")
            .Append("    <td align=""left"" valign=""middle""><font size=""2"" face=""" & AdvantageFramework.Email.Font & """>" & TheStartDate & "</font></td>")
            .Append("  </tr>")
            .Append("  <tr>")
            .Append("    <td align=""right"" valign=""middle""><font size=""2"" face=""" & AdvantageFramework.Email.Font & """><strong>Task Due Date:</strong></font></td>")
            .Append("    <td align=""left"" valign=""middle""><font size=""2"" face=""" & AdvantageFramework.Email.Font & """>" & TheDueDate & "</font></td>")
            .Append("  </tr>")
            .Append("  <tr>")
            .Append("    <td align=""right"" valign=""middle""><font size=""2"" face=""" & AdvantageFramework.Email.Font & """><strong>Time Due:</strong></font></td>")
            .Append("    <td align=""left"" valign=""middle""><font size=""2"" face=""" & AdvantageFramework.Email.Font & """>" & TheTimeDue & "</font></td>")
            .Append("  </tr>")
            .Append("  <tr>")
            .Append("    <td align=""right"" valign=""middle""><font size=""2"" face=""" & AdvantageFramework.Email.Font & """><strong>Completed Date:</strong></font></td>")
            .Append("    <td align=""left"" valign=""middle""><font size=""2"" face=""" & AdvantageFramework.Email.Font & """>" & TheCompletedDate & "</font></td>")
            .Append("  </tr>")
            .Append("  <tr>")
            .Append("    <td align=""right"" valign=""top""><font size=""2"" face=""" & AdvantageFramework.Email.Font & """><strong>Task Comments:</strong></font></td>")
            .Append("    <td align=""left"" valign=""middle""><font size=""2"" face=""" & AdvantageFramework.Email.Font & """>" & TheTaskComments & "</font></td>")
            .Append("  </tr>")
            .Append("  <tr>")
            .Append("    <td align=""right"" valign=""top""><font size=""2"" face=""" & AdvantageFramework.Email.Font & """><strong>Due Date Comments:</strong></font></td>")
            .Append("    <td align=""left"" valign=""middle""><font size=""2"" face=""" & AdvantageFramework.Email.Font & """>" & TheDueDateComments & "</font></td>")
            .Append("  </tr>")
            .Append("  <tr>")
            .Append("    <td align=""right"" valign=""top""><font size=""2"" face=""" & AdvantageFramework.Email.Font & """><strong>Revised Date Comments:</strong></font></td>")
            .Append("    <td align=""left"" valign=""middle""><font size=""2"" face=""" & AdvantageFramework.Email.Font & """>" & TheRevisedDateComments & "</font></td>")
            .Append("  </tr>")
            .Append("  <tr>")
            .Append("    <td align=""right"" valign=""middle"">&nbsp;</td>")
            .Append("    <td align=""left"" valign=""middle"">&nbsp;</td>")
            .Append("    <td align=""right"" valign=""middle"">&nbsp;</td>")
            .Append("    <td align=""left"" valign=""middle"">&nbsp;</td>")
            .Append("  </tr>")
            .Append("</table>")
        End With
        Return sb.ToString
    End Function

#End Region
#Region " Data "

    Private Function SaveEmailAlert(ByVal filename As String, Optional ByVal filenameJS As String = "",
                                    Optional ByVal filenameJV As String = "", Optional ByVal filenameEST As String = "",
                                    Optional ByVal filenameCB As String = "", Optional ByVal sendEmail As Boolean = False,
                                    Optional ByRef UploadedDocIds As String = "",
                                    Optional ByRef ErrorMessage As String = "") As Integer

        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                Dim HasUpload As Boolean = False
                If filename.Trim() <> "" Or filenameJS.Trim() <> "" Or filenameJV.Trim() <> "" Or filenameEST.Trim() <> "" Or filenameCB.Trim() <> "" Then
                    HasUpload = True
                End If

                Dim HasMultipleUploads As Boolean = False
                If filename.Trim() <> "" And (filenameJS.Trim() <> "" Or filenameJV.Trim() <> "" Or filenameEST.Trim() <> "" Or filenameCB.Trim() <> "") Then
                    HasMultipleUploads = True
                End If
                If HasUpload = True Then
                    HasMultipleUploads = True
                End If

                Dim NowDate As Date = Now

                Dim i As Integer = 0

                Dim EmployeeCodeList As String = Me.AutoCompleteRecipients.GetCommaDelimitedStringOfEmployeeCodes()
                Dim ClientContactIdList As String = Me.AutoCompleteRecipients.GetCommaDelimitedStringOfClientContacts()

                '''''Make sure the logged user is in the list always
                ''If Me.ChkIncludeMe.Checked = True Then
                If Me.FsAlertAssignments.Visible = False Then
                    If EmployeeCodeList <> "" Then
                        If Not EmployeeCodeList.Contains(Session("EmpCode")) Then
                            EmployeeCodeList = EmployeeCodeList & "," & Session("EmpCode") ' Add the current user to the recipient's list.
                        End If
                    Else
                        EmployeeCodeList = Session("EmpCode") ' Add the current user to the recipent's list.
                    End If
                End If
                ''End If

                If Me.IsClientPortal = True Then

                    If ClientContactIdList <> "" Then

                        If Not ClientContactIdList.Contains(Session("UserID")) Then

                            ClientContactIdList = ClientContactIdList & "," & Session("UserID") ' Add the current user to the recipent's list.

                        End If
                    Else

                        ClientContactIdList = Session("UserID") ' Add the current user to the recipent's list.

                    End If

                End If

                Dim RecipientArray() As String
                Dim RecipientArrayCC() As String

                RecipientArray = EmployeeCodeList.Split(",")
                RecipientArrayCC = ClientContactIdList.Split(",")

                Dim dr As SqlClient.SqlDataReader
                'Dim Alert As New Alert(Session("ConnString"))
                Dim FxAlert As New AdvantageFramework.Database.Entities.Alert
                Try

                    With FxAlert

                        If Me.IsClientPortal = True Then
                            .AlertTypeID = 7 'CP Alert
                        Else
                            .AlertTypeID = 6 'WV Alert
                        End If
                        .AlertCategoryID = Me.RadComboBoxCategory.SelectedValue

                        .Subject = Me.txtSubject.Text
                        .Body = Me.BodyRadEditor.Text

                        .EmailBody = Me.BodyRadEditor.Html
                        .GeneratedDate = NowDate
                        .LastUpdated = NowDate
                        .PriorityLevel = Me.RadComboBoxPriority.SelectedValue

                        Try
                            If Me.RadDatePickerStartDate.SelectedDate.HasValue = True Then
                                .StartDate = CType(Me.RadDatePickerStartDate.SelectedDate, Date).ToShortDateString()
                            End If
                        Catch ex As Exception
                        End Try
                        Try
                            If Me.RadDatePickerDueDate.SelectedDate.HasValue = True Then
                                .DueDate = CType(Me.RadDatePickerDueDate.SelectedDate, Date).ToShortDateString()
                            End If
                        Catch ex As Exception
                        End Try
                        If Me.TxtTimeDue.Text.Trim() <> "" Then
                            .TimeDue = Me.TxtTimeDue.Text.Trim()
                        End If

                        Dim ThisJob As Integer = 0
                        Dim ThisComp As Integer = 0
                        Dim ThisCl As String = ""
                        Dim ThisDiv As String = ""
                        Dim ThisPrd As String = ""

                        Select Case Me.PageType()
                            Case "jt"
                                If Me.JobNumber > 0 AndAlso Me.JobComponentNbr > 0 Then
                                    ThisJob = Me.JobNumber
                                    ThisComp = Me.JobComponentNbr
                                    If ThisJob > 0 And ThisComp > 0 Then
                                        Dim c As New cTimeSheet(Session("ConnString"))
                                        c.GetJobInfo(ThisJob, , , ThisCl, ThisDiv, ThisPrd)
                                        .ClientCode = ThisCl
                                        .DivisionCode = ThisDiv
                                        .ProductCode = ThisPrd
                                        .JobNumber = ThisJob
                                        .JobComponentNumber = ThisComp
                                    End If
                                End If
                            Case "po"
                                Dim POHeader As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
                                POHeader.Select_POHeader(Int32.Parse(Me.PO_RefId), "")
                                .VendorCode = POHeader.Vendor_Code.Trim
                                .PONumber = Me.PO_RefId
                                .PORevisionNumber = POHeader.PO_Revision
                            Case "js"
                                If IsNumeric(Session("JSReportJobNum")) = True And IsNumeric(Session("JSReportJobCompNum")) = True Then
                                    ThisJob = CType(Session("JSReportJobNum"), Integer)
                                    ThisComp = CType(Session("JSReportJobCompNum"), Integer)
                                    If ThisJob > 0 And ThisComp > 0 Then
                                        Dim c As New cTimeSheet(Session("ConnString"))
                                        c.GetJobInfo(ThisJob, , , ThisCl, ThisDiv, ThisPrd)
                                        .ClientCode = ThisCl
                                        .DivisionCode = ThisDiv
                                        .ProductCode = ThisPrd
                                        .JobNumber = ThisJob
                                        .JobComponentNumber = ThisComp
                                    End If
                                End If
                            Case "jv"
                                If IsNumeric(Session("JVReportJobNum")) = True And IsNumeric(Session("JVReportJobCompNum")) = True Then
                                    ThisJob = CType(Session("JVReportJobNum"), Integer)
                                    ThisComp = CType(Session("JVReportJobCompNum"), Integer)
                                    If ThisJob > 0 And ThisComp > 0 Then
                                        Dim c As New cTimeSheet(Session("ConnString"))
                                        c.GetJobInfo(ThisJob, , , ThisCl, ThisDiv, ThisPrd)
                                        .ClientCode = ThisCl
                                        .DivisionCode = ThisDiv
                                        .ProductCode = ThisPrd
                                        .JobNumber = ThisJob
                                        .JobComponentNumber = ThisComp
                                    End If
                                End If
                            Case "cb"
                                If IsNumeric(Session("CBReportJobNum")) = True And IsNumeric(Session("CBReportJobCompNum")) = True Then
                                    ThisJob = CType(Session("CBReportJobNum"), Integer)
                                    ThisComp = CType(Session("CBReportJobCompNum"), Integer)
                                    If ThisJob > 0 And ThisComp > 0 Then
                                        Dim c As New cTimeSheet(Session("ConnString"))
                                        c.GetJobInfo(ThisJob, , , ThisCl, ThisDiv, ThisPrd)
                                        .ClientCode = ThisCl
                                        .DivisionCode = ThisDiv
                                        .ProductCode = ThisPrd
                                        .JobNumber = ThisJob
                                        .JobComponentNumber = ThisComp
                                    End If
                                End If
                            Case "cmp"
                                Dim cCMP As New cCampaign(Session("ConnString"), Me.CmpIdentifier)
                                Session("CMPSendClient") = cCMP.CL_CODE
                                Session("CMPSendDivision") = cCMP.DIV_CODE
                                Session("CMPSendProduct") = cCMP.PRD_CODE
                                .ClientCode = ThisCl
                                .DivisionCode = ThisDiv
                                .ProductCode = ThisPrd
                                .CampaignCode = cCMP.CMP_CODE
                                .CampaignID = cCMP.CMP_IDENTIFIER
                                .OfficeCode = cCMP.OFFICE_CODE
                            Case "est"
                                Dim oEstimating As New cEstimating(Session("ConnString"), Session("UserCode"))
                                Dim dt As DataTable
                                dt = oEstimating.GetEstimateData(Me.EstimateNumber, Me.EstimateComponentNbr, 0, 0, Session("UserCode"))
                                If dt.Rows.Count > 0 Then
                                    .ClientCode = dt.Rows(0)("CL_CODE")
                                    .DivisionCode = dt.Rows(0)("DIV_CODE")
                                    .ProductCode = dt.Rows(0)("PRD_CODE")
                                    If IsDBNull(dt.Rows(0)("JOB_NUMBER")) = False Then
                                        .JobNumber = dt.Rows(0)("JOB_NUMBER")
                                    End If
                                    If IsDBNull(dt.Rows(0)("JOB_COMPONENT_NBR")) = False Then
                                        .JobComponentNumber = dt.Rows(0)("JOB_COMPONENT_NBR")
                                    End If
                                    .EstimateNumber = Me.EstimateNumber
                                    If Me.EstimateComponentNbr > 0 And Me.AlertLevel = "EST" Then
                                        .EstimateComponentNumber = Me.EstimateComponentNbr
                                    End If
                                End If
                            Case "ps", "psg"
                                If Me.JobNumber > 0 And Me.JobComponentNbr > 0 Then
                                    Dim c As New cTimeSheet(Session("ConnString"))
                                    c.GetJobInfo(ThisJob, , , ThisCl, ThisDiv, ThisPrd)
                                    .ClientCode = ThisCl
                                    .DivisionCode = ThisDiv
                                    .ProductCode = ThisPrd
                                    .JobNumber = Me.JobNumber
                                    .JobComponentNumber = Me.JobComponentNbr
                                End If
                            Case "atb"

                                If Me.ATBNumber > 0 AndAlso Me.ATBRevisionNumber > -1 Then

                                    Dim MediaATBRevision As AdvantageFramework.Database.Entities.MediaATBRevision = Nothing

                                    MediaATBRevision = AdvantageFramework.Database.Procedures.MediaATBRevision.LoadByATBNumberAndRevisionNumber(DbContext, Me.ATBNumber, Me.ATBRevisionNumber)

                                    .ClientCode = MediaATBRevision.MediaATB.ClientCode
                                    .DivisionCode = MediaATBRevision.MediaATB.DivisionCode
                                    .ProductCode = MediaATBRevision.MediaATB.ProductCode
                                    .MediaATBRevisionID = MediaATBRevision.RevisionID

                                End If
                            Case "jr"
                                .ClientCode = Session("JobVerSendClient")
                                .DivisionCode = Session("JobVerSendDivision")
                                .ProductCode = Session("JobVerSendProduct")
                                .JobVersionID = Session("JobVerHdrID")
                        End Select

                        If Me.IsClientPortal = True Then
                            .AlertLevel = Me.RadComboBoxAlertLevel.SelectedValue
                            .UserCode = Session("UserID")
                            .IsCPAlert = 1
                            .ClientContactID = Session("UserID")
                        Else
                            .EmployeeCode = Session("EmpCode")
                            .AlertLevel = Me.RadComboBoxAlertLevel.SelectedValue
                            .UserCode = Session("UserCode")
                        End If

                    End With

                    If AdvantageFramework.Database.Procedures.Alert.Insert(DbContext, FxAlert) = True Then

                        Dim Alert As New Alert(Session("ConnString"))
                        Alert.LoadByPrimaryKey(FxAlert.ID)

                        Dim Employee As New cEmployee(Session("ConnString"))
                        Dim EmailFlag As Integer
                        If Not RecipientArray Is Nothing Then
                            For i = 0 To RecipientArray.Length - 1
                                If RecipientArray(i) <> "" Then
                                    EmailFlag = Employee.GetAlertEmailFlag(RecipientArray(i))
                                    If EmailFlag = 2 Or EmailFlag = 3 Then ' Email Only or Both 
                                        Alert.AddAlertRecipient(RecipientArray(i))
                                    End If
                                End If
                            Next
                        End If

                        Dim code As Integer = 0
                        Dim ThisClientCode As String = ""
                        If Me.txtClient.Visible = True Then
                            If Me.txtClient.Text.Trim() <> "" Then
                                ThisClientCode = Me.txtClient.Text.Trim()
                            End If
                        End If
                        If ThisClientCode = "" Then
                            If Me.JobNumber > 0 Then
                                Dim c As New cTimeSheet(Session("ConnString"))
                                c.GetJobInfo(Me.JobNumber, , , ThisClientCode)
                            End If
                        End If

                        If Not RecipientArrayCC Is Nothing Then

                            For i = 0 To RecipientArrayCC.Length - 1

                                If IsNumeric(RecipientArrayCC(i)) = True Then

                                    Alert.AddAlertRecipientCC(RecipientArrayCC(i))

                                End If

                            Next

                        End If

                        If Me.FsAlertAssignments.Visible = True Then

                            If Me.SaveAssignment(FxAlert.ID, ErrorMessage) = False Then

                                If ErrorMessage.Trim() <> "" Then Me.ShowMessage(ErrorMessage)

                            End If

                        End If

                        Dim Document As New Document(Session("ConnString"))
                        Dim Repository As New DocumentRepository(Session("ConnString"))

                        Dim f As IO.FileInfo
                        Dim fjs As IO.FileInfo
                        If filename <> "" Then
                            f = New IO.FileInfo(filename)
                            If f.Exists Then
                                Dim realFilename As String = f.Name
                                Dim MIMEType As String
                                Select Case f.Extension.ToLower()
                                    Case ".pdf"
                                        MIMEType = "application/pdf"
                                    Case ".xls"
                                        MIMEType = "application/msexcel"
                                    Case ".txt"
                                        MIMEType = "text/plain"
                                    Case ".tiff"
                                        MIMEType = "image/tiff"
                                    Case ".rtf"
                                        MIMEType = "application/rtf"
                                    Case ".zip"
                                        MIMEType = "application/zip"
                                    Case Else
                                        MIMEType = "application/pdf"
                                End Select
                                Dim FileLength As Integer = f.Length
                                Dim FileBytes(FileLength) As Byte
                                Dim ff As IO.FileStream = f.OpenRead
                                ff.Read(FileBytes, 0, FileLength)

                                Dim RepositoryFilename As String = "" 'Repository.AddDocument(realFilename, FileBytes, "", "", Session("userCode"), "New Alert", "Attached Doc", "a_")

                                RepositoryFilename = "a_" & Guid.NewGuid.ToString()
                                Dim DocumentId As Integer = 0
                                Try
                                    Dim impersonationContext As System.Security.Principal.WindowsImpersonationContext
                                    If IsNTAuth = True Then ' And HasMultipleUploads = True Then
                                        Me.currentWindowsIdentity = CType(HttpContext.Current.User.Identity, System.Security.Principal.WindowsIdentity)
                                        impersonationContext = Me.currentWindowsIdentity.Impersonate()
                                    End If
                                    'db stuff here
                                    Try
                                        DocumentId = Document.Add(realFilename, MIMEType, RepositoryFilename, FileLength, Session("UserCode"), "", "")
                                        If IsClientPortal = True Then
                                            Alert.AddAttachment(DocumentId, "", Session("UserID"))
                                        Else
                                            Alert.AddAttachment(DocumentId, Session("UserCode"), 0)
                                        End If
                                    Catch ex As Exception
                                        ErrorMessage = ex.Message.ToString()
                                        Return Alert.ALERT_ID
                                    End Try
                                    If IsNTAuth = True Then ' And HasMultipleUploads = True Then
                                        impersonationContext.Undo()
                                    End If
                                Catch ex As Exception
                                End Try
                                Dim RepositoryFilenameTemp = Repository.AddDocument(realFilename, FileBytes, "", "", Session("userCode"), "New Alert", "Attached Doc", "", RepositoryFilename)
                                ff.Close()
                            End If
                        End If

                        If filenameJS <> "" Then
                            fjs = New IO.FileInfo(filenameJS)
                            If fjs.Exists Then
                                Dim realFilename As String = fjs.Name
                                Dim MIMEType As String
                                Select Case fjs.Extension.ToLower()
                                    Case ".pdf"
                                        MIMEType = "application/pdf"
                                    Case ".xls"
                                        MIMEType = "application/msexcel"
                                    Case ".txt"
                                        MIMEType = "text/plain"
                                    Case ".tiff"
                                        MIMEType = "image/tiff"
                                    Case ".rtf"
                                        MIMEType = "application/rtf"
                                    Case ".zip"
                                        MIMEType = "application/zip"
                                    Case Else
                                        MIMEType = "application/pdf"
                                End Select
                                Dim FileLength As Integer = fjs.Length
                                Dim FileBytes(FileLength) As Byte
                                Dim ff As IO.FileStream = fjs.OpenRead
                                ff.Read(FileBytes, 0, FileLength)
                                Dim RepositoryFilenameJS As String = "" 'Repository.AddDocument(realFilename, FileBytes, "", "", Session("userCode"), "New Alert", "Attached Doc", "a_")
                                RepositoryFilenameJS = "a_" & Guid.NewGuid.ToString()
                                Dim DocumentId As Integer = 0
                                Try
                                    Dim impersonationContext As System.Security.Principal.WindowsImpersonationContext
                                    If IsNTAuth = True Then 'And HasMultipleUploads = True Then
                                        Me.currentWindowsIdentity = CType(HttpContext.Current.User.Identity, System.Security.Principal.WindowsIdentity)
                                        impersonationContext = Me.currentWindowsIdentity.Impersonate()
                                    End If
                                    'db stuff here
                                    Try
                                        DocumentId = Document.Add(realFilename, MIMEType, RepositoryFilenameJS, FileLength, Session("UserCode"), "", "")
                                        If IsClientPortal = True Then
                                            Alert.AddAttachment(DocumentId, "", Session("UserID"))
                                        Else
                                            Alert.AddAttachment(DocumentId, Session("UserCode"), 0)
                                        End If
                                    Catch ex As Exception
                                        ErrorMessage = ex.Message.ToString()
                                        Return Alert.ALERT_ID
                                    End Try
                                    If IsNTAuth = True Then 'And HasMultipleUploads = True Then
                                        impersonationContext.Undo()
                                    End If
                                Catch ex As Exception
                                End Try

                                Dim RepositoryFilenameTemp = Repository.AddDocument(realFilename, FileBytes, "", "", Session("userCode"), "New Alert", "Attached Doc", "", RepositoryFilenameJS)
                                ff.Close()
                            End If
                        End If

                        If filenameJV <> "" Then
                            fjs = New IO.FileInfo(filenameJV)
                            If fjs.Exists Then
                                Dim realFilename As String = fjs.Name
                                Dim MIMEType As String
                                Select Case fjs.Extension.ToLower()
                                    Case ".pdf"
                                        MIMEType = "application/pdf"
                                    Case ".xls"
                                        MIMEType = "application/msexcel"
                                    Case ".txt"
                                        MIMEType = "text/plain"
                                    Case ".tiff"
                                        MIMEType = "image/tiff"
                                    Case ".rtf"
                                        MIMEType = "application/rtf"
                                    Case ".zip"
                                        MIMEType = "application/zip"
                                    Case Else
                                        MIMEType = "application/pdf"
                                End Select
                                Dim FileLength As Integer = fjs.Length
                                Dim FileBytes(FileLength) As Byte
                                Dim ff As IO.FileStream = fjs.OpenRead
                                ff.Read(FileBytes, 0, FileLength)
                                Dim RepositoryFilenameJV As String = "" 'Repository.AddDocument(realFilename, FileBytes, "", "", Session("userCode"), "New Alert", "Attached Doc", "a_")
                                RepositoryFilenameJV = "a_" & Guid.NewGuid.ToString()
                                Dim DocumentId As Integer = 0
                                Try
                                    Dim impersonationContext As System.Security.Principal.WindowsImpersonationContext
                                    If IsNTAuth = True And HasMultipleUploads = True Then
                                        Me.currentWindowsIdentity = CType(HttpContext.Current.User.Identity, System.Security.Principal.WindowsIdentity)
                                        impersonationContext = Me.currentWindowsIdentity.Impersonate()
                                    End If
                                    'db stuff here
                                    Try
                                        DocumentId = Document.Add(realFilename, MIMEType, RepositoryFilenameJV, FileLength, Session("UserCode"), "", "")
                                        If IsClientPortal = True Then
                                            Alert.AddAttachment(DocumentId, "", Session("UserID"))
                                        Else
                                            Alert.AddAttachment(DocumentId, Session("UserCode"), 0)
                                        End If
                                    Catch ex As Exception
                                        ErrorMessage = ex.Message.ToString()
                                        Return Alert.ALERT_ID
                                    End Try
                                    If IsNTAuth = True And HasMultipleUploads = True Then
                                        impersonationContext.Undo()
                                    End If
                                Catch ex As Exception
                                End Try
                                Dim RepositoryFilenameTemp = Repository.AddDocument(realFilename, FileBytes, "", "", Session("userCode"), "New Alert", "Attached Doc", "", RepositoryFilenameJV)
                                ff.Close()
                            End If
                        End If

                        If filenameCB <> "" Then
                            fjs = New IO.FileInfo(filenameCB)
                            If fjs.Exists Then
                                Dim realFilename As String = fjs.Name
                                Dim MIMEType As String
                                Select Case fjs.Extension.ToLower()
                                    Case ".pdf"
                                        MIMEType = "application/pdf"
                                    Case ".xls"
                                        MIMEType = "application/msexcel"
                                    Case ".txt"
                                        MIMEType = "text/plain"
                                    Case ".tiff"
                                        MIMEType = "image/tiff"
                                    Case ".rtf"
                                        MIMEType = "application/rtf"
                                    Case ".zip"
                                        MIMEType = "application/zip"
                                    Case Else
                                        MIMEType = "application/pdf"
                                End Select
                                Dim FileLength As Integer = fjs.Length
                                Dim FileBytes(FileLength) As Byte
                                Dim ff As IO.FileStream = fjs.OpenRead
                                ff.Read(FileBytes, 0, FileLength)

                                Dim RepositoryFilenameCB As String = "" 'Repository.AddDocument(realFilename, FileBytes, "", "", Session("userCode"), "New Alert", "Attached Doc", "a_")
                                RepositoryFilenameCB = "a_" & Guid.NewGuid.ToString()
                                Dim DocumentId As Integer = 0 '
                                Try
                                    Dim impersonationContext As System.Security.Principal.WindowsImpersonationContext
                                    If IsNTAuth = True And HasMultipleUploads = True Then
                                        Me.currentWindowsIdentity = CType(HttpContext.Current.User.Identity, System.Security.Principal.WindowsIdentity)
                                        impersonationContext = Me.currentWindowsIdentity.Impersonate()
                                    End If
                                    'db stuff here
                                    Try
                                        DocumentId = Document.Add(realFilename, MIMEType, RepositoryFilenameCB, FileLength, Session("UserCode"), "", "")
                                        If IsClientPortal = True Then
                                            Alert.AddAttachment(DocumentId, "", Session("UserID"))
                                        Else
                                            Alert.AddAttachment(DocumentId, Session("UserCode"), 0)
                                        End If
                                    Catch ex As Exception
                                        ErrorMessage = ex.Message.ToString()
                                        Return Alert.ALERT_ID
                                    End Try
                                    If IsNTAuth = True And HasMultipleUploads = True Then
                                        impersonationContext.Undo()
                                    End If
                                Catch ex As Exception
                                End Try
                                Dim RepositoryFilenameTemp = Repository.AddDocument(realFilename, FileBytes, "", "", Session("userCode"), "New Alert", "Attached Doc", "", RepositoryFilenameCB)
                                ff.Close()
                            End If
                        End If

                        If filenameEST <> "" Then
                            Dim fns() As String = filenameEST.Split(",")
                            For w As Integer = 0 To fns.Length - 1
                                fjs = New IO.FileInfo(fns(w))
                                If fjs.Exists Then
                                    Dim realFilename As String = fjs.Name
                                    Dim MIMEType As String
                                    Select Case fjs.Extension.ToLower()
                                        Case ".pdf"
                                            MIMEType = "application/pdf"
                                        Case ".xls"
                                            MIMEType = "application/msexcel"
                                        Case ".txt"
                                            MIMEType = "text/plain"
                                        Case ".tiff"
                                            MIMEType = "image/tiff"
                                        Case ".rtf"
                                            MIMEType = "application/rtf"
                                        Case ".zip"
                                            MIMEType = "application/zip"
                                        Case Else
                                            MIMEType = "application/pdf"
                                    End Select
                                    Dim FileLength As Integer = fjs.Length
                                    Dim FileBytes(FileLength) As Byte
                                    Dim ff As IO.FileStream = fjs.OpenRead
                                    ff.Read(FileBytes, 0, FileLength)
                                    Dim RepositoryFilenameEst As String = "" 'Repository.AddDocument(realFilename, FileBytes, "", "", Session("userCode"), "New Alert", "Attached Doc", "a_")
                                    RepositoryFilenameEst = "a_" & Guid.NewGuid.ToString()
                                    Dim DocumentId As Integer = 0
                                    Try
                                        Dim impersonationContext As System.Security.Principal.WindowsImpersonationContext
                                        If IsNTAuth = True And HasMultipleUploads = True Then
                                            Me.currentWindowsIdentity = CType(HttpContext.Current.User.Identity, System.Security.Principal.WindowsIdentity)
                                            impersonationContext = Me.currentWindowsIdentity.Impersonate()
                                        End If
                                        'db stuff here
                                        Try
                                            DocumentId = Document.Add(realFilename, MIMEType, RepositoryFilenameEst, FileLength, Session("UserCode"), "", "")
                                            If IsClientPortal = True Then
                                                Alert.AddAttachment(DocumentId, "", Session("UserID"))
                                            Else
                                                Alert.AddAttachment(DocumentId, Session("UserCode"), 0)
                                            End If
                                        Catch ex As Exception
                                            ErrorMessage = ex.Message.ToString()
                                            Return Alert.ALERT_ID
                                        End Try
                                        If IsNTAuth = True And HasMultipleUploads = True Then
                                            impersonationContext.Undo()
                                        End If
                                    Catch ex As Exception
                                    End Try
                                    Dim RepositoryFilenameTemp = Repository.AddDocument(realFilename, FileBytes, "", "", Session("userCode"), "New Alert", "Attached Doc", "", RepositoryFilenameEst)
                                    ff.Close()
                                End If
                            Next
                        End If

                        Dim StrDocIds As String = ""

                        Dim HasOverSizedFile As Boolean = False

                        Dim currentWindowsIdentity1 As System.Security.Principal.WindowsIdentity
                        Dim impersonationContext1 As System.Security.Principal.WindowsImpersonationContext
                        If Me.RadUploadAlertDocuments.UploadedFiles.Count > 0 Then 'And IsNTAUTH = False Then
                            If IsNTAuth = True Then
                                Me.currentWindowsIdentity = CType(HttpContext.Current.User.Identity, System.Security.Principal.WindowsIdentity)
                                impersonationContext1 = Me.currentWindowsIdentity.Impersonate()
                            End If
                            Dim doc As New DocumentRepository("", True)
                            If IsNTAuth = True Then
                                impersonationContext1.Undo()
                            End If
                            For i = 0 To Me.RadUploadAlertDocuments.UploadedFiles.Count - 1
                                Dim realFilename As String = Me.RadUploadAlertDocuments.UploadedFiles(i).GetName
                                Dim MIMEType As String = "" 'Me.RadUploadAlertDocuments.UploadedFiles(i).ContentType
                                If Not Me.RadUploadAlertDocuments.UploadedFiles(i).ContentType Is Nothing Then
                                    MIMEType = Me.RadUploadAlertDocuments.UploadedFiles(i).ContentType
                                Else
                                    MIMEType = ""
                                End If
                                Dim FileLength As Integer = Me.RadUploadAlertDocuments.UploadedFiles(i).InputStream.Length
                                Dim ThisFC As New DocumentRepository.FileCompare
                                ThisFC.FileByteLength = CType(FileLength, Long)

                                If DocumentRepository.RadAsyncUploadFileTypeIsValid(Me.RadUploadAlertDocuments.UploadedFiles(i)) = True AndAlso
                                    doc.IsOverFileSizeLimit(ThisFC) = False Then

                                    If FileLength > 0 Then

                                        Dim FileBytes(FileLength - 1) As Byte
                                        Me.RadUploadAlertDocuments.UploadedFiles(i).InputStream.Read(FileBytes, 0, FileLength)

                                        Dim UsePrefix As String = "a_"
                                        If Me.ChkUploadToRepository.Checked = True Then
                                            UsePrefix = "d_"
                                        Else
                                            UsePrefix = "a_"
                                        End If

                                        Dim RepositoryFilename As String = Repository.AddDocument(realFilename, FileBytes, "", "", Session("userCode"), "New Alert", "Attached Doc", UsePrefix)
                                        If IsNTAuth = True And HasMultipleUploads = True Then
                                            Me.currentWindowsIdentity = CType(HttpContext.Current.User.Identity, System.Security.Principal.WindowsIdentity)
                                            impersonationContext1 = Me.currentWindowsIdentity.Impersonate()
                                        End If
                                        Dim DocumentId As Integer = Document.Add(realFilename, MIMEType, RepositoryFilename, FileLength, Session("UserCode"), "", "")
                                        StrDocIds = StrDocIds & DocumentId.ToString() & ","

                                        If IsNumeric(Me.txtJob.Text) = True Then
                                            Me.JobNumber = CType(Me.txtJob.Text, Integer)
                                        End If
                                        If IsNumeric(Me.txtComponent.Text) = True Then
                                            Me.JobComponentNbr = CType(Me.txtComponent.Text, Integer)
                                        End If

                                        If Me.ChkUploadToRepository.Checked = True Then 'adds additional record to job doc table/job comp doc table so that doc shows up in the alert as well as the repository
                                            Try
                                                Select Case Me.RadComboBoxAlertLevel.SelectedValue
                                                    Case "OF"

                                                        AdvantageFramework.DocumentManager.AddOfficeDocument(DbContext, Me.txtOffice.Text, DocumentId)

                                                    Case "CL"

                                                        AdvantageFramework.DocumentManager.AddClientDocument(DataContext, Me.txtClient.Text, DocumentId)

                                                    Case "DI"

                                                        AdvantageFramework.DocumentManager.AddDivisionDocument(DataContext, Me.txtClient.Text, Me.txtDivision.Text, DocumentId)

                                                    Case "PR"

                                                        AdvantageFramework.DocumentManager.AddProductDocument(DataContext, Me.txtClient.Text, Me.txtDivision.Text, Me.txtProduct.Text, DocumentId)

                                                    Case "CM"

                                                        If _CampaignID > 0 Then

                                                            AdvantageFramework.DocumentManager.AddCampaignDocument(DataContext, _CampaignID, DocumentId)

                                                        End If

                                                    Case "JO"

                                                        If Me.JobNumber > 0 Then

                                                            Dim DocumentJ As New JobDocument(Me.ConnectionString)
                                                            DocumentId = DocumentJ.Add(Me.JobNumber, realFilename, MIMEType, RepositoryFilename, FileLength, Session("UserCode"), "", "", 0, 2, DocumentId)

                                                        End If

                                                    Case "JC", "ES", "EST"

                                                        If Me.JobNumber > 0 And Me.JobComponentNbr > 0 Then

                                                            Dim DocumentJC As New JobComponentDocuments(Me.ConnectionString)
                                                            DocumentId = DocumentJC.Add(Me.JobNumber, Me.JobComponentNbr, realFilename, MIMEType, RepositoryFilename, FileLength, Session("UserCode"), "", "", 0, 2, DocumentId)

                                                        End If

                                                    Case "PST", "BRD"

                                                        AdvantageFramework.DocumentManager.AddTaskDocument(DataContext, Me.JobNumber, Me.JobComponentNbr, Me.TaskSeqNbr, DocumentId)

                                                End Select
                                            Catch ex As Exception
                                                ErrorMessage = ex.Message.ToString()
                                                Return Alert.ALERT_ID
                                            End Try

                                            If DocumentId > 0 AndAlso CheckBoxUploadToProofHQ.Checked Then

                                                UploadDocumentToProofHQ(DbContext, DataContext, DocumentId, Agency)

                                            End If

                                        End If


                                        If IsClientPortal = True Then
                                            Alert.AddAttachment(DocumentId, "", Session("UserID"))
                                        Else
                                            Alert.AddAttachment(DocumentId, Session("UserCode"), 0)
                                        End If
                                        If IsNTAuth = True And HasMultipleUploads = True Then
                                            impersonationContext1.Undo()
                                        End If

                                    End If
                                Else
                                    HasOverSizedFile = True
                                End If
                            Next
                            If HasOverSizedFile = True Then
                                '''Me.ShowMessage("Files that exceeded the file size limit were excluded")
                            End If
                        End If

                        UploadedDocIds = MiscFN.RemoveTrailingDelimiter(StrDocIds, ",")

                        Try
                            If IsNTAuth = True Then
                                currentWindowsIdentity1 = CType(HttpContext.Current.User.Identity, System.Security.Principal.WindowsIdentity)
                                impersonationContext1 = Me.currentWindowsIdentity.Impersonate()
                            End If
                        Catch ex As Exception
                        End Try
                        Try
                            For Each item As Telerik.Web.UI.RadListBoxItem In Me.RadListBoxLinkableDocuments.Items
                                If item.Selected = True Then
                                    If IsClientPortal = True Then
                                        Alert.AddAttachment(item.Value, "", Session("UserID"))
                                    Else
                                        Alert.AddAttachment(item.Value, Session("UserCode"), 0)
                                    End If
                                End If
                            Next
                        Catch ex As Exception
                        End Try
                        Try
                            If IsNTAuth = True Then
                                impersonationContext1.Undo()
                            End If
                        Catch ex As Exception
                        End Try

                        ErrorMessage = ""
                        Return Alert.ALERT_ID

                    Else

                        Me.ShowMessage("Alert failed to save")

                    End If

                Catch ex As Exception
                    If IsNTAuth = True And ex.Message.ToString().IndexOf("Safe handle has been closed") > -1 Then
                        ErrorMessage = ""
                        Return FxAlert.ID
                    Else
                        ErrorMessage = MiscFN.JavascriptSafe(ex.Message.ToString())
                        Return -1
                    End If
                End Try

            End Using

        End Using

    End Function
    Private Function LoadAlertForCopy(ByVal AlertID As Integer)

        'objects
        Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)

            If Alert IsNot Nothing Then

                RadComboBoxCategory.SelectedValue = Alert.AlertCategoryID
                RadComboBoxPriority.SelectedValue = Alert.PriorityLevel.GetValueOrDefault(3)

                If Alert.DueDate IsNot Nothing Then
                    Me.RadDatePickerDueDate.SelectedDate = Alert.DueDate.Value
                End If

                TxtTimeDue.Text = Alert.TimeDue
                txtSubject.Text = Alert.Subject '"[New Alert] " & Alert.Subject

                If Alert.EmailBody = "" Then
                    If Alert.Body <> "" Then
                        BodyRadEditor.Html = Alert.Body.Replace(vbCrLf, "<br />")
                    End If
                Else
                    BodyRadEditor.Html = Alert.EmailBody
                End If

                'If AdvantageFramework.AlertSystem.IsAlertAnAlertAssignment(Alert) Then

                '    Me.ChkIsAlertAssignment.Checked = True
                '    Me.SetAlertOrAssignment()
                '    'TEST: Me.FsAlertRecipients.Visible = False

                'End If

            End If

        End Using

    End Function
    Private Function LoadAlertDraft() As AdvantageFramework.Database.Entities.Alert

        Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, _DraftAlertID)

            If Alert IsNot Nothing Then

                Me.RadToolbarAlertNew.FindItemByValue("DeleteDraft").Visible = True

                RadComboBoxCategory.SelectedValue = Alert.AlertCategoryID
                RadComboBoxPriority.SelectedValue = Alert.PriorityLevel.GetValueOrDefault(3)

                If Alert.DueDate IsNot Nothing Then

                    Me.RadDatePickerDueDate.SelectedDate = Alert.DueDate.Value

                End If

                TxtTimeDue.Text = Alert.TimeDue
                txtSubject.Text = Alert.Subject

                If Alert.EmailBody = "" Then

                    If Alert.Body <> "" Then

                        BodyRadEditor.Html = Alert.Body.Replace(vbCrLf, "<br />")

                    End If

                Else

                    BodyRadEditor.Html = Alert.EmailBody

                End If

                If Alert.AlertLevel IsNot Nothing Then Me.AlertLevel = Alert.AlertLevel

                Select Case Me.AlertLevel
                    Case "CM"
                        Me.App = Source_App.Campaign
                    Case "DT"
                        Me.App = Source_App.Desktop
                    Case "ES"
                        Me.App = Source_App.Estimate
                    Case "EST"
                        Me.App = Source_App.EstimateComponent
                    Case "JJ", "JC"
                        Me.App = Source_App.JobJacket
                    Case "PS"
                        Me.App = Source_App.ProjectSchedule
                    Case "PO"
                        Me.App = Source_App.PurchaseOrder
                    Case "AB"
                        Me.App = Source_App.MediaATB
                    Case "JR"
                        Me.App = Source_App.JobVersion
                    Case Else
                        Me.App = Source_App.Alert
                End Select

                MiscFN.RadComboBoxSetIndex(Me.RadComboBoxPriority, If(Alert.PriorityLevel Is Nothing, 3, Alert.PriorityLevel), False, False)

                SetAlertLevel(Me.AlertLevel)

                If Alert.OfficeCode IsNot Nothing Then Me.txtOffice.Text = Alert.OfficeCode
                If Alert.ClientCode IsNot Nothing Then Me.txtClient.Text = Alert.ClientCode
                If Alert.DivisionCode IsNot Nothing Then Me.txtDivision.Text = Alert.DivisionCode
                If Alert.ProductCode IsNot Nothing Then Me.txtProduct.Text = Alert.ProductCode
                If Alert.CampaignCode IsNot Nothing Then Me.txtCampaign.Text = Alert.CampaignCode

                If Alert.JobNumber IsNot Nothing Then

                    Me.JobNumber = Alert.JobNumber
                    Me.txtJob.Text = Me.JobNumber.ToString()

                End If
                If Alert.JobComponentNumber IsNot Nothing Then

                    Me.JobComponentNbr = Alert.JobComponentNumber
                    Me.txtComponent.Text = Me.JobComponentNbr.ToString()

                End If

                If Alert.EstimateNumber IsNot Nothing Then Me.TxtEstimateNumber.Text = Alert.EstimateNumber.ToString()
                If Alert.EstimateComponentNumber IsNot Nothing Then Me.TxtEstimateComponentNbr.Text = Alert.EstimateComponentNumber.ToString()

                If Me.LoadVersionAndBuild() = True Then

                    If Alert.Version IsNot Nothing AndAlso IsNumeric(Alert.Version) Then

                        MiscFN.RadComboBoxSetIndex(Me.RadComboBoxVersion, Alert.Version, False, True)

                        If Alert.Build IsNot Nothing Then

                            Me.LoadBuild(CType(Me.RadComboBoxVersion.SelectedValue, Integer))

                        End If

                    End If

                End If
                If Alert.PONumber IsNot Nothing Then

                    Me.LblPoNumber.Text = ""
                    Me.LblPoDescription.Text = ""

                End If
                If Alert.MediaATBRevisionID IsNot Nothing Then

                    Me.txtMediaATB.Text = ""
                    Me.txtMediaATBRev.Text = Alert.MediaATBRevisionID.ToString()

                End If

                If AdvantageFramework.AlertSystem.IsAlertAnAlertAssignment(Alert) = True Then

                    Me.ChkIsAlertAssignment.Checked = True
                    Me.SetAlertOrAssignment()

                    Me.LoadAlertAssignmentTemplates()
                    If Alert.AlertAssignmentTemplateID IsNot Nothing Then

                        MiscFN.RadComboBoxSetIndex(Me.RadComboBoxAlertAssignmentTemplate, Alert.AlertAssignmentTemplateID, False, False)

                        If IsNumeric(Me.RadComboBoxAlertAssignmentTemplate.SelectedValue) = True Then

                            Me.BindRadTreeViewStates(Alert.AlertAssignmentTemplateID)

                            If Alert.AlertStateID IsNot Nothing Then

                                Dim SelectedNode As RadTreeNode = Me.RadTreeViewStates.FindNodeByValue(Alert.AlertStateID)

                                If SelectedNode IsNot Nothing Then

                                    SelectedNode.Selected = True

                                    Dim c As New cAlerts()
                                    With Me.RadComboBoxAssignTo

                                        .Visible = True
                                        .Enabled = True

                                    End With
                                    With Me.RadComboBoxAssignTo

                                        .Items.Clear()
                                        .Text = ""
                                        .DataTextField = "EMP_FML"
                                        .DataValueField = "EMP_CODE"
                                        .DataSource = c.GetNotificationRecipients(Alert.AlertStateID, 0, 0, Alert.AlertAssignmentTemplateID)
                                        .DataBind()

                                    End With

                                    Dim Assignee As AdvantageFramework.Database.Entities.AlertRecipient

                                    Assignee = (From Entity In DbContext.AlertRecipients
                                                Where Entity.AlertID = Alert.ID AndAlso
                                                (Entity.IsCurrentNotify IsNot Nothing AndAlso Entity.IsCurrentNotify = 1)
                                                Select Entity).SingleOrDefault()

                                    If Assignee IsNot Nothing AndAlso Me.RadComboBoxAssignTo.Items.Count > 0 Then

                                        Dim SelectedItem As RadComboBoxItem = Me.RadComboBoxAssignTo.Items.FindItemByValue(Assignee.EmployeeCode)

                                        If SelectedItem IsNot Nothing Then

                                            SelectedItem.Selected = True

                                        End If

                                    End If

                                End If


                            End If

                        Else

                            Me.RadTreeViewStates.Nodes.Clear()
                            Me.RadComboBoxAssignTo.Items.Clear()
                            Me.RadComboBoxAssignTo.Enabled = False

                        End If

                    End If

                End If

                If Alert.BoardStateID IsNot Nothing Then

                    Dim SprintHeaderID As Integer = 0
                    Dim BoardID As Integer = 0

                    Try

                        SprintHeaderID = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT TOP 1 SD.SPRINT_HDR_ID FROM SPRINT_DTL SD WHERE SD.ALERT_ID = {0}", Alert.ID)).SingleOrDefault

                    Catch ex As Exception
                        SprintHeaderID = 0
                    End Try
                    If SprintHeaderID > 0 Then
                        Try

                            BoardID = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT TOP 1 BOARD_ID FROM SPRINT_HDR SH WHERE SH.ID = {0} ORDER BY SH.IS_ACTIVE DESC, SH.START_DATE DESC", SprintHeaderID)).SingleOrDefault

                        Catch ex As Exception
                            BoardID = 0
                        End Try
                    End If

                    If BoardID > 0 Then

                        Me.CheckForBoard()

                        MiscFN.RadComboBoxSetIndex(Me.RadComboBoxBoard, BoardID, False)
                        Me.BoardIDChanged()

                        If Alert.BoardStateID IsNot Nothing Then

                            MiscFN.RadComboBoxSetIndex(Me.RadComboBoxBoardState, Alert.BoardStateID, False)

                        End If

                    End If

                End If

                Dim Recipients As String()
                Recipients = (From AlertRecipient In DbContext.AlertRecipients
                              Join Employee In DbContext.Employees On AlertRecipient.EmployeeCode Equals Employee.Code
                              Where AlertRecipient.AlertID = Me._DraftAlertID AndAlso
                                  (Employee.TerminationDate Is Nothing OrElse Employee.TerminationDate > Today) AndAlso
                                  (AlertRecipient.IsCurrentNotify Is Nothing OrElse AlertRecipient.IsCurrentNotify = 0)
                              Select AlertRecipient.EmployeeCode).ToArray()

                If Recipients IsNot Nothing Then

                    Me.AutoCompleteRecipients.AddEntries(Recipients)

                End If

                Me.AutoCompleteRecipients.AddExistingClientRecipients(DbContext, Me._DraftAlertID)

                Me.LoadLinkableDocuments()

            End If

        End Using

        Return Alert

    End Function

    Dim _CampaignID As Integer = 0
    Private Function SaveAlert(Optional ByVal SendEmail As Boolean = False, Optional IsDraft As Boolean = False) As Integer

        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

            Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                Dim oAlerts As New cAlerts(Session("ConnString"))
                Dim str As String = ""

                str = QuickValidateLookups(Me.RadComboBoxAlertLevel.SelectedValue)

                If str <> "" Then

                    Me.ShowMessage(str)
                    Exit Function

                End If

                Dim NowDate As Date = Now

                Dim i As Integer

                Dim EmployeeCodeList As String = Me.AutoCompleteRecipients.GetCommaDelimitedStringOfEmployeeCodes()
                Dim ClientContactIdList As String = Me.AutoCompleteRecipients.GetCommaDelimitedStringOfClientContacts()

                Try

                    If IsDraft = True Then

                        Dim SelectedRecipients As Generic.List(Of String)
                        Dim CurrentRecipients As Generic.List(Of AdvantageFramework.Database.Entities.AlertRecipient)

                        CurrentRecipients = Nothing
                        CurrentRecipients = AdvantageFramework.Database.Procedures.AlertRecipient.LoadByAlertID(DbContext, _DraftAlertID).ToList

                        SelectedRecipients = Me.AutoCompleteRecipients.GetListOfEmployeeCodes

                        If CurrentRecipients IsNot Nothing Then

                            If SelectedRecipients Is Nothing Then SelectedRecipients = New Generic.List(Of String)

                            For Each Recipient As AdvantageFramework.Database.Entities.AlertRecipient In CurrentRecipients

                                If SelectedRecipients.Contains(Recipient.EmployeeCode) = False AndAlso (Recipient.IsCurrentNotify Is Nothing OrElse Recipient.IsCurrentNotify = 0) Then

                                    AdvantageFramework.Database.Procedures.AlertRecipient.Delete(DbContext, Recipient)

                                End If

                            Next

                        End If

                        Dim SelectedClientPortalRecipients As Generic.List(Of Integer)
                        Dim CurrentClientPortalRecipients As Generic.List(Of AdvantageFramework.Database.Entities.ClientPortalAlertRecipient)

                        CurrentClientPortalRecipients = Nothing
                        CurrentClientPortalRecipients = AdvantageFramework.Database.Procedures.ClientPortalAlertRecipient.LoadByAlertID(DbContext, _DraftAlertID).ToList

                        SelectedClientPortalRecipients = Me.AutoCompleteRecipients.GetListOfClientContactIDs

                        If CurrentClientPortalRecipients IsNot Nothing Then

                            If SelectedClientPortalRecipients Is Nothing Then SelectedClientPortalRecipients = New Generic.List(Of Integer)

                            For Each ClientRecipient As AdvantageFramework.Database.Entities.ClientPortalAlertRecipient In CurrentClientPortalRecipients

                                If SelectedClientPortalRecipients.Contains(ClientRecipient.ClientContactID) = False Then

                                    AdvantageFramework.Database.Procedures.ClientPortalAlertRecipient.Delete(DbContext, ClientRecipient)

                                End If

                            Next

                        End If

                    End If

                Catch ex As Exception
                End Try

                Dim RecipientArray() As String
                Dim RecipientArrayCC() As String

                If Me.FsAlertAssignments.Visible = False Then

                    If EmployeeCodeList <> "" Then

                        If Not EmployeeCodeList.Contains(Session("EmpCode")) Then

                            EmployeeCodeList = EmployeeCodeList & "," & Session("EmpCode") ' Add the current user to the recipient's list.

                        End If

                    ElseIf Me.IsClientPortal = False Then

                        EmployeeCodeList = Session("EmpCode") ' Add the current user to the recipent's list.

                    End If

                End If

                If Me.IsClientPortal = True Then

                    If ClientContactIdList <> "" Then

                        If Not ClientContactIdList.Contains(Session("UserID")) Then

                            ClientContactIdList = ClientContactIdList & "," & Session("UserID") ' Add the current user to the recipent's list.

                        End If
                    Else

                        ClientContactIdList = Session("UserID") ' Add the current user to the recipent's list.

                    End If

                End If

                RecipientArray = EmployeeCodeList.Split(",")
                RecipientArrayCC = ClientContactIdList.Split(",")

                Dim dr As SqlClient.SqlDataReader
                Dim FxAlert As AdvantageFramework.Database.Entities.Alert

                If Me._DraftAlertID > 0 Then

                    FxAlert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, Me._DraftAlertID)

                Else

                    FxAlert = New AdvantageFramework.Database.Entities.Alert

                End If

                If FxAlert Is Nothing Then FxAlert = New AdvantageFramework.Database.Entities.Alert

                Try

                    If IsNumeric(Me.txtJob.Text.Trim()) Then

                        Me.JobNumber = CType(Me.txtJob.Text.Trim(), Integer)

                    End If
                    If IsNumeric(Me.txtComponent.Text.Trim()) Then

                        Me.JobComponentNbr = CType(Me.txtComponent.Text.Trim(), Integer)

                    End If

                    With FxAlert

                        If Me.IsClientPortal = True Then

                            .AlertTypeID = 7 'CP Alert

                        Else

                            .AlertTypeID = 6 'WV Alert

                        End If

                        .AlertCategoryID = Me.RadComboBoxCategory.SelectedValue

                        .Subject = Me.txtSubject.Text

                        If Me.AlertLevel = "PST" Then

                            .Body = Me.BodyRadEditor.Html

                        Else

                            .Body = Me.Sanitize(Me.BodyRadEditor.Text)

                        End If

                        .EmailBody = Me.BodyRadEditor.Html
                        .GeneratedDate = NowDate
                        .LastUpdated = NowDate
                        .PriorityLevel = Me.RadComboBoxPriority.SelectedValue

                        Try

                            If Me.RadDatePickerDueDate.SelectedDate.HasValue = True Then

                                .DueDate = CType(CType(Me.RadDatePickerDueDate.SelectedDate, Date).ToShortDateString, Date)

                            End If

                        Catch ex As Exception
                        End Try
                        Try

                            If Me.RadDatePickerStartDate.SelectedDate.HasValue = True Then

                                .StartDate = CType(CType(Me.RadDatePickerStartDate.SelectedDate, Date).ToShortDateString, Date)

                            End If

                        Catch ex As Exception
                        End Try
                        Try

                            If Me.TxtTimeDue.Text.Trim() <> "" Then

                                .TimeDue = Me.Sanitize(Me.TxtTimeDue.Text.Trim())

                            End If

                        Catch ex As Exception
                        End Try

                        If Me.JobNumber > 0 Then

                            Dim oTS As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))
                            oTS.GetJobInfo(Me.JobNumber, "", "", Me.txtClient.Text, Me.txtDivision.Text, Me.txtProduct.Text)
                            .ClientCode = Me.txtClient.Text
                            .DivisionCode = Me.txtDivision.Text
                            .ProductCode = Me.txtProduct.Text

                        End If

                        Select Case Me.RadComboBoxAlertLevel.SelectedValue
                            Case "OF"

                                .OfficeCode = Me.txtOffice.Text

                            Case "CL"

                                .ClientCode = Me.txtClient.Text

                            Case "DI"

                                .ClientCode = Me.txtClient.Text
                                .DivisionCode = Me.txtDivision.Text

                            Case "PR"

                                .ClientCode = Me.txtClient.Text
                                .DivisionCode = Me.txtDivision.Text
                                .ProductCode = Me.txtProduct.Text

                            Case "CM"

                                .ClientCode = Me.txtClient.Text
                                .DivisionCode = Me.txtDivision.Text
                                .ProductCode = Me.txtProduct.Text
                                .CampaignCode = Me.txtCampaign.Text

                                If Me.CmpIdentifier = 0 Then

                                    Dim j As New cJobs(Session("ConnString"))
                                    .CampaignID = j.GetCampaignIdentifier(Me.txtCampaign.Text.Trim(), Me.txtClient.Text, Me.txtDivision.Text, Me.txtProduct.Text)

                                    Me.CmpIdentifier = .CampaignID

                                Else

                                    .CampaignID = Me.CmpIdentifier

                                End If

                                _CampaignID = .CampaignID

                                If Me.CmpIdentifier = 0 Then 'Can't possibly still step into here...right?

                                    Exit Function

                                End If

                            Case "ES"

                                Try

                                    Dim e As New cEstimating(Session("ConnString"), Session("UserCode"))
                                    Dim dt As New DataTable

                                    dt = e.GetInfoForEstimate(Me.EstimateNumber)
                                    .ClientCode = dt.Rows(0)("CL_CODE")
                                    .DivisionCode = dt.Rows(0)("DIV_CODE")
                                    .ProductCode = dt.Rows(0)("PRD_CODE")
                                    dt.Dispose()
                                    dt = Nothing

                                Catch ex As Exception
                                End Try

                                If Me.JobNumber > 0 Then

                                    .JobNumber = Me.JobNumber

                                End If
                                If Me.JobComponentNbr > 0 Then

                                    .JobComponentNumber = Me.JobComponentNbr

                                End If

                                .EstimateNumber = Me.EstimateNumber

                            Case "EST"
                                Try

                                    Dim e As New cEstimating(Session("ConnString"), Session("UserCode"))
                                    Dim dt As New DataTable

                                    dt = e.GetInfoForEstimate(Me.EstimateNumber)

                                    .ClientCode = dt.Rows(0)("CL_CODE")
                                    .DivisionCode = dt.Rows(0)("DIV_CODE")
                                    .ProductCode = dt.Rows(0)("PRD_CODE")

                                    dt.Dispose()
                                    dt = Nothing

                                Catch ex As Exception
                                End Try
                                If Me.JobNumber > 0 Then

                                    .JobNumber = Me.JobNumber

                                End If
                                If Me.JobComponentNbr > 0 Then

                                    .JobComponentNumber = Me.JobComponentNbr

                                End If

                                .EstimateNumber = Me.EstimateNumber
                                .EstimateComponentNumber = Me.EstimateComponentNbr

                            Case "JO"

                                .JobNumber = Me.JobNumber

                            Case "JC"

                                .JobNumber = Me.JobNumber
                                .JobComponentNumber = Me.JobComponentNbr

                            Case "PS"

                                If Me.JobNumber > 0 And Me.JobComponentNbr > 0 Then

                                    .JobNumber = Me.JobNumber
                                    .JobComponentNumber = Me.JobComponentNbr

                                End If

                            Case "PST"

                                If Me.JobNumber > 0 And Me.JobComponentNbr > 0 And Me.TaskSeqNbr > -1 Then

                                    .JobNumber = Me.JobNumber
                                    .JobComponentNumber = Me.JobComponentNbr
                                    .TaskSequenceNumber = Me.TaskSeqNbr

                                End If

                            Case "AB"

                                Dim MediaATBRevision As AdvantageFramework.Database.Entities.MediaATBRevision = Nothing

                                MediaATBRevision = AdvantageFramework.Database.Procedures.MediaATBRevision.LoadByATBNumberAndRevisionNumber(DbContext, Me.ATBNumber, Me.ATBRevisionNumber)

                                If MediaATBRevision IsNot Nothing Then

                                    .ClientCode = MediaATBRevision.MediaATB.ClientCode
                                    .DivisionCode = MediaATBRevision.MediaATB.DivisionCode
                                    .ProductCode = MediaATBRevision.MediaATB.ProductCode
                                    .MediaATBRevisionID = MediaATBRevision.RevisionID

                                End If

                            Case "PO"

                                .PONumber = Me.PO_RefId

                        End Select

                        If Me.TrVersionAndBuild.Visible = True Then

                            If Me.RadComboBoxBuild.SelectedIndex > 0 And Me.RadComboBoxVersion.SelectedIndex = 0 Or Me.RadComboBoxVersion.SelectedIndex = -1 Then

                                Me.ShowMessage("Cannot use Build without using Version")
                                Exit Function

                            End If
                            If Me.RadComboBoxVersion.SelectedIndex > 0 Then

                                .Version = Me.RadComboBoxVersion.SelectedValue.ToString()

                            End If
                            If Me.RadComboBoxBuild.SelectedIndex > 0 Then

                                .Build = Me.RadComboBoxBuild.SelectedValue.ToString()

                            End If
                        End If

                        If Me.IsClientPortal = True Then

                            .EmployeeCode = Nothing
                            .AlertLevel = Me.RadComboBoxAlertLevel.SelectedValue
                            .UserCode = Session("UserID")
                            .IsCPAlert = 1
                            .ClientContactID = Session("UserID")

                        Else

                            .EmployeeCode = Session("EmpCode")
                            .AlertLevel = Me.RadComboBoxAlertLevel.SelectedValue
                            .UserCode = Session("UserCode")

                        End If

                        If Me.FieldsetBoardSprint.Visible = True Then

                            If Me.RadComboBoxBoard.SelectedItem IsNot Nothing AndAlso CType(Me.RadComboBoxBoard.SelectedItem.Value, Integer) > 0 Then

                                If Me.RadComboBoxSprint.SelectedItem IsNot Nothing AndAlso CType(Me.RadComboBoxSprint.SelectedItem.Value, Integer) > 0 Then

                                    If Me.RadComboBoxBoardState.SelectedItem IsNot Nothing AndAlso CType(Me.RadComboBoxBoardState.SelectedItem.Value, Integer) <> 0 Then

                                        .BoardStateID = Me.RadComboBoxBoardState.SelectedItem.Value

                                    Else

                                        Me.ShowMessage("No board state selected")

                                    End If

                                Else

                                    Me.ShowMessage("No sprint selected")

                                End If

                            End If

                        End If

                    End With

                    Dim Success As Boolean = False
                    Dim SprintDetail As AdvantageFramework.Database.Entities.SprintDetail = Nothing

                    If FxAlert.BoardStateID IsNot Nothing Then
                        If FxAlert.BoardStateID = -1 OrElse FxAlert.BoardStateID = 0 Then FxAlert.BoardStateID = Nothing
                    End If

                    If Me._DraftAlertID > 0 Then
                        'when opeing existing draft
                        Success = AdvantageFramework.Database.Procedures.Alert.Update(DbContext, FxAlert)

                        If FxAlert.BoardStateID IsNot Nothing Then

                        End If

                    Else

                        Success = AdvantageFramework.Database.Procedures.Alert.Insert(DbContext, FxAlert)

                        If FxAlert.BoardStateID IsNot Nothing AndAlso FxAlert.BoardStateID > 0 Then

                            SprintDetail = New AdvantageFramework.Database.Entities.SprintDetail

                            SprintDetail.SprintHeaderID = CType(Me.RadComboBoxSprint.SelectedItem.Value, Integer)
                            SprintDetail.AlertID = FxAlert.ID

                            'Try

                            '    SprintDetail.SequenceNumber = (From Item In AdvantageFramework.Database.Procedures.SprintDetail.LoadBySprintID(DbContext, SprintDetail.SprintHeaderID)
                            '                                   Where Item.SequenceNumber IsNot Nothing
                            '                                   Select Item.SequenceNumber).Max + 1

                            'Catch ex As Exception
                            '    SprintDetail.SequenceNumber = Nothing
                            'End Try

                            If AdvantageFramework.Database.Procedures.SprintDetail.Insert(DbContext, SprintDetail) Then

                                AdvantageFramework.ProjectManagement.Agile.MoveBoardItem(Me._Session, FxAlert.BoardStateID, SprintDetail, -1)

                            End If

                        End If

                    End If

                    If Success = True Then

                        Dim HasAttachments As Boolean = False

                        If Me._SavingDraft = True Then

                            Me._DraftAlertID = FxAlert.ID

                        End If

                        Dim ErrorMessage As String = ""

                        If AdvantageFramework.AlertSystem.IsAlertAnAlertAssignment(FxAlert) = True OrElse Me.FsAlertAssignments.Visible = True Then

                            Me.HasAlertAssignment(Not Me._SavingDraft)

                            If Me.SaveAssignment(FxAlert.ID, ErrorMessage) = False Then

                                If ErrorMessage.Trim() <> "" Then Me.ShowMessage(ErrorMessage)

                            End If

                        End If

                        Try

                            If IsDraft = True Then DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE ALERT SET IS_DRAFT = 1 WHERE ALERT_ID = {0};", FxAlert.ID))

                        Catch ex As Exception
                        End Try

                        Dim Alert As New Alert(Session("ConnString"))
                        Alert.LoadByPrimaryKey(FxAlert.ID)

                        If Not RecipientArray Is Nothing Then

                            For i = 0 To RecipientArray.Length - 1

                                If String.IsNullOrWhiteSpace(RecipientArray(i)) = False Then

                                    Try
                                        Alert.AddAlertRecipient(RecipientArray(i))
                                    Catch ex As Exception
                                    End Try

                                End If

                            Next


                        End If

                        Dim ThisClientCode As String = ""

                        If Me.txtClient.Visible = True Then

                            If String.IsNullOrWhiteSpace(Me.txtClient.Text) = False Then

                                ThisClientCode = Me.txtClient.Text.Trim()

                            End If

                        End If
                        If String.IsNullOrWhiteSpace(ThisClientCode) = False Then

                            If Me.JobNumber > 0 Then

                                Dim t As New cSchedule(Session("ConnString"), Session("UserCode"))
                                Dim dt As New DataTable

                                dt = t.GetBaseJobAndCompInfoDT(Me.JobNumber, Me.JobComponentNbr)

                                If Not dt Is Nothing Then

                                    If dt.Rows.Count > 0 Then

                                        If IsDBNull(dt.Rows(0)("CL_CODE")) = False Then

                                            ThisClientCode = dt.Rows(0)("CL_CODE")

                                        End If

                                    End If

                                End If

                            End If

                        End If

                        If Not RecipientArrayCC Is Nothing Then

                            For i = 0 To RecipientArrayCC.Length - 1

                                If IsNumeric(RecipientArrayCC(i)) = True Then

                                    Dim code As Integer = RecipientArrayCC(i)

                                    Try
                                        Alert.AddAlertRecipientCC(code)
                                    Catch ex As Exception
                                    End Try

                                End If

                            Next

                        End If

                        Dim oApp As cApplication = New cApplication(CStr(Session("ConnString")))
                        Dim HasOverSizedFile As Boolean = False
                        Dim Repository As New DocumentRepository(Me.ConnectionString)
                        Dim Document As New Document(Me.ConnectionString)
                        Dim HasMultipleUploads As Boolean = False

                        HasMultipleUploads = Me.RadUploadAlertDocuments.UploadedFiles.Count > 1

                        Dim currentWindowsIdentity1 As System.Security.Principal.WindowsIdentity
                        Dim impersonationContext1 As System.Security.Principal.WindowsImpersonationContext

                        If Me.RadUploadAlertDocuments.UploadedFiles.Count > 0 Then 'And IsNTAUTH = False Then

                            Dim doc As New DocumentRepository("", True)

                            For i = 0 To Me.RadUploadAlertDocuments.UploadedFiles.Count - 1

                                Dim realFilename As String = Me.RadUploadAlertDocuments.UploadedFiles(i).GetName
                                Dim MIMEType As String = ""

                                If Not Me.RadUploadAlertDocuments.UploadedFiles(i).ContentType Is Nothing Then

                                    MIMEType = Me.RadUploadAlertDocuments.UploadedFiles(i).ContentType

                                Else

                                    MIMEType = ""

                                End If

                                Dim FileLength As Integer = Me.RadUploadAlertDocuments.UploadedFiles(i).InputStream.Length
                                Dim ThisFC As New DocumentRepository.FileCompare

                                ThisFC.FileByteLength = CType(FileLength, Long)

                                If DocumentRepository.RadAsyncUploadFileTypeIsValid(Me.RadUploadAlertDocuments.UploadedFiles(i)) = True AndAlso
                                    doc.IsOverFileSizeLimit(ThisFC) = False Then

                                    If HasAttachments = False Then HasAttachments = True

                                    If FileLength > 0 Then
                                        Dim FileBytes(FileLength - 1) As Byte
                                        Me.RadUploadAlertDocuments.UploadedFiles(i).InputStream.Read(FileBytes, 0, FileLength)

                                        Dim UsePrefix As String = "a_"

                                        If Me.ChkUploadToRepository.Checked = True Then
                                            UsePrefix = "d_"
                                        Else
                                            UsePrefix = "a_"
                                        End If

                                        Dim RepositoryFilename As String = Repository.AddDocument(realFilename, FileBytes, "", "", Session("userCode"), "New Alert", "Attached Doc", UsePrefix)

                                        If IsNTAuth = True Then

                                            Me.currentWindowsIdentity = CType(HttpContext.Current.User.Identity, System.Security.Principal.WindowsIdentity)
                                            impersonationContext1 = Me.currentWindowsIdentity.Impersonate()

                                        End If

                                        Dim DocumentId As Integer = Document.Add(realFilename, MIMEType, RepositoryFilename, FileLength, Session("UserCode"), "", "")

                                        If IsNumeric(Me.txtJob.Text) = True Then

                                            Me.JobNumber = CType(Me.txtJob.Text, Integer)

                                        End If

                                        If IsNumeric(Me.txtComponent.Text) = True Then

                                            Me.JobComponentNbr = CType(Me.txtComponent.Text, Integer)

                                        End If

                                        If Me.ChkUploadToRepository.Checked = True Then 'adds additional record to job doc table/job comp doc table so that doc shows up in the alert as well as the repository

                                            Try

                                                Select Case Me.RadComboBoxAlertLevel.SelectedValue
                                                    Case "OF"

                                                        AdvantageFramework.DocumentManager.AddOfficeDocument(DbContext, Me.txtOffice.Text, DocumentId)

                                                    Case "CL"

                                                        AdvantageFramework.DocumentManager.AddClientDocument(DataContext, Me.txtClient.Text, DocumentId)

                                                    Case "DI"

                                                        AdvantageFramework.DocumentManager.AddDivisionDocument(DataContext, Me.txtClient.Text, Me.txtDivision.Text, DocumentId)

                                                    Case "PR"

                                                        AdvantageFramework.DocumentManager.AddProductDocument(DataContext, Me.txtClient.Text, Me.txtDivision.Text, Me.txtProduct.Text, DocumentId)

                                                    Case "CM"

                                                        If _CampaignID > 0 Then

                                                            AdvantageFramework.DocumentManager.AddCampaignDocument(DataContext, _CampaignID, DocumentId)

                                                        End If

                                                    Case "JO"

                                                        If Me.JobNumber > 0 Then

                                                            Dim DocumentJ As New JobDocument(Me.ConnectionString)
                                                            DocumentId = DocumentJ.Add(Me.JobNumber, realFilename, MIMEType, RepositoryFilename, FileLength, Session("UserCode"), "", "", 0, 2, DocumentId)

                                                        End If

                                                    Case "JC", "ES", "EST"

                                                        If Me.JobNumber > 0 And Me.JobComponentNbr > 0 Then

                                                            Dim DocumentJC As New JobComponentDocuments(Me.ConnectionString)
                                                            DocumentId = DocumentJC.Add(Me.JobNumber, Me.JobComponentNbr, realFilename, MIMEType, RepositoryFilename, FileLength, Session("UserCode"), "", "", 0, 2, DocumentId)

                                                        End If

                                                    Case "PST", "BRD"

                                                        AdvantageFramework.DocumentManager.AddTaskDocument(DataContext, Me.JobNumber, Me.JobComponentNbr, Me.TaskSeqNbr, DocumentId)

                                                End Select

                                            Catch ex As Exception
                                                Return Alert.ALERT_ID
                                            End Try

                                            If DocumentId > 0 AndAlso CheckBoxUploadToProofHQ.Checked Then

                                                UploadDocumentToProofHQ(DbContext, DataContext, DocumentId, Agency)

                                            End If

                                        End If

                                        If IsClientPortal = True Then

                                            Alert.AddAttachment(DocumentId, "", Session("UserID"))

                                        Else

                                            Alert.AddAttachment(DocumentId, Session("UserCode"), 0)

                                        End If

                                        If IsNTAuth = True Then 'And HasMultipleUploads = True Then

                                            impersonationContext1.Undo()

                                        End If

                                    End If
                                Else

                                    HasOverSizedFile = True

                                End If
                            Next


                        End If

                        If Me.RadListBoxLinkableDocuments.SelectedItems IsNot Nothing AndAlso Me.RadListBoxLinkableDocuments.SelectedItems.Count > 0 Then

                            If IsNTAuth = True Then

                                Me.currentWindowsIdentity = CType(HttpContext.Current.User.Identity, System.Security.Principal.WindowsIdentity)
                                impersonationContext1 = Me.currentWindowsIdentity.Impersonate()

                            End If
                            For Each item As Telerik.Web.UI.RadListBoxItem In Me.RadListBoxLinkableDocuments.SelectedItems

                                If item.Selected = True Then

                                    If HasAttachments = False Then HasAttachments = True

                                    If IsClientPortal = True Then

                                        Alert.AddAttachment(item.Value, "", Session("UserID"))

                                    Else

                                        Alert.AddAttachment(item.Value, Session("UserCode"), 0)

                                    End If

                                End If

                            Next
                            If IsNTAuth = True Then

                                impersonationContext1.Undo()

                            End If

                        End If

                    End If

                    Return FxAlert.ID

                Catch ex As Exception

                    Me.ShowMessage("Error saving alert.\n" & MiscFN.JavascriptSafe(ex.Message.ToString()))
                    Return False

                End Try

            End Using

        End Using

    End Function
    Private Function getDefaultEmailGroup() As String
        Try
            'get email groups
            Dim oAlerts As cAlerts = New cAlerts(CStr(Session("ConnString")))
            Dim JobNumber As Integer
            Dim JobComponentNumber As Integer


            Dim DefaultGroupName As String = ""
            Select Case Me.RadComboBoxAlertLevel.SelectedValue
                Case "OF"
                    DefaultGroupName = ""
                Case "CL"
                    DefaultGroupName = "" 'oAlerts.GetDefaultGroup(Me.txtClient.Text.Trim(), Me.txtDivision.Text.Trim(), Me.txtProduct.Text.Trim(), 0, 0)
                Case "DI"
                    DefaultGroupName = "" 'oAlerts.GetDefaultGroup(Me.txtClient.Text.Trim(), Me.txtDivision.Text.Trim(), Me.txtProduct.Text.Trim(), 0, 0)
                Case "PR"
                    DefaultGroupName = oAlerts.GetDefaultGroup(Me.txtClient.Text.Trim(), Me.txtDivision.Text.Trim(), Me.txtProduct.Text.Trim(), 0, 0)
                Case "CM"
                    If Me.CmpIdentifier = 0 Then
                        Dim j As New cJobs(Session("ConnString"))
                        Me.CmpIdentifier = j.GetCampaignIdentifier(Me.txtCampaign.Text.Trim(), Me.txtClient.Text, Me.txtDivision.Text, Me.txtProduct.Text)
                        _CampaignID = Me.CmpIdentifier
                    End If

                    DefaultGroupName = oAlerts.GetCampaignAlertGroup(Me.CmpIdentifier)
                Case "JC"
                    Dim ThisJobNum As Integer = 0
                    Dim ThisCompNum As Integer = 0
                    If IsNumeric(Me.txtJob.Text.Trim()) Then ThisJobNum = CType(Me.txtJob.Text.Trim(), Integer)
                    If IsNumeric(Me.txtComponent.Text.Trim()) Then ThisCompNum = CType(Me.txtComponent.Text.Trim(), Integer)
                    If ThisJobNum <> 0 And ThisCompNum <> 0 Then
                        'DefaultGroupName = oAlerts.GetDefaultGroup("", "", "", ThisJobNum, ThisCompNum)
                        DefaultGroupName = oAlerts.GetDefaultGroup(Me.txtClient.Text.Trim(), Me.txtDivision.Text.Trim(), Me.txtProduct.Text.Trim(), ThisJobNum, ThisCompNum)

                    End If
            End Select
            If DefaultGroupName Is Nothing Then DefaultGroupName = ""
            Return DefaultGroupName
        Catch
            Return ""
        End Try
    End Function
    Private Function LoadVersionAndBuild() As Boolean
        Try
            Me.TrVersionAndBuild.Visible = False
            If Me.JobNumber = 0 Then
                If IsNumeric(Me.txtJob.Text) = True Then
                    Me.JobNumber = CType(Me.txtJob.Text, Integer)
                End If
            End If
            If Me.JobComponentNbr = 0 Then
                If IsNumeric(Me.txtComponent.Text) = True Then
                    Me.JobComponentNbr = CType(Me.txtComponent.Text, Integer)
                End If
            End If

            If Me.JobNumber = 0 Then Return False

            Dim a As New cAlerts()
            Dim DtVersions As New DataTable

            DtVersions = a.GetSoftwareVersions(Me.JobNumber, Me.JobComponentNbr)

            If DtVersions Is Nothing OrElse (DtVersions IsNot Nothing AndAlso DtVersions.Rows.Count = 0) Then

                Return False

            Else
                Me.TrVersionAndBuild.Visible = True
                With Me.RadComboBoxVersion
                    .Items.Clear()
                    .DataSource = DtVersions
                    .DataTextField = "VERSION"
                    .DataValueField = "VERSION_ID"
                    .DataBind()
                    .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", "0"))
                End With
                With Me.RadComboBoxBuild
                    '.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", "0"))
                    .Enabled = False
                End With
                Return True
            End If
        Catch ex As Exception
            Me.TrVersionAndBuild.Visible = False
            Return False
        End Try
    End Function
    Private Sub LoadBuild(ByVal VersionId As Integer)
        Dim a As New cAlerts()
        If VersionId = 0 Then
            With Me.RadComboBoxBuild
                .Items.Clear()
                .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", "0"))
                .Enabled = False
            End With
        Else
            With Me.RadComboBoxBuild
                .Items.Clear()
                .DataSource = a.GetSoftwareBuilds(VersionId)
                .DataTextField = "BUILD"
                .DataValueField = "BUILD_ID"
                .DataBind()
                .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", "0"))
                .Enabled = True
            End With
        End If
    End Sub
    Private Sub LoadListCategories()
        Try

            Dim a As New cAlerts()
            Dim AllowTaskCategory As Boolean = False
            Dim AllowStoryCategory As Boolean = False

            With Me.RadComboBoxCategory

                .DataSource = a.GetManualAlertCategories(AllowTaskCategory, Me.AutoSetToAssignment)
                .DataTextField = "ALERT_DESC"
                .DataValueField = "ALERT_CAT_ID"
                .DataBind()

            End With

        Catch ex As Exception
        End Try
    End Sub
    Private Function LoadAlertAssignmentTemplates() As Boolean

        Dim a As New cAlerts()
        With Me.RadComboBoxAlertAssignmentTemplate

            .Items.Clear()
            .DataSource = a.GetAlertNotifyTemplates(False)
            .DataValueField = "ALRT_NOTIFY_HDR_ID"
            .DataTextField = "ALERT_NOTIFY_NAME"
            .DataBind()
            .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

        End With

        Me.RadComboBoxAssignTo.Enabled = False


    End Function
    Private Function LoadAlertStates(ByVal JobNumber As String, ByVal JobComponentNbr As String) As Boolean

        Dim a As New cAlerts()

        Me.RadTreeViewStates.Nodes.Clear()
        Me.RadTreeViewStates.DataTextField = "ALERT_STATE_NAME"
        Me.RadTreeViewStates.DataValueField = "ALERT_STATE_ID"
        Me.RadTreeViewStates.DataSource = a.GetAlertStates(JobNumber, JobComponentNbr)
        Me.RadTreeViewStates.DataBind()

    End Function
    Private Sub LoadLinkableDocuments()

        Me.RadListBoxLinkableDocuments.Items.Clear()

        Try
            Select Case Me.RadComboBoxAlertLevel.SelectedValue
                Case "OF"
                    Dim OfficeDocs As New vCurrentOfficeDocuments(Me.ConnectionString)
                    OfficeDocs.Where.OFFICE_CODE.Value = Me.txtOffice.Text 'Me.OfficeAutoSuggestBox.SelectedValue
                    OfficeDocs.Query.Load()
                    Do Until OfficeDocs.EOF
                        Me.RadListBoxLinkableDocuments.Items.Add(New Telerik.Web.UI.RadListBoxItem(OfficeDocs.FILENAME & " " & OfficeDocs.USER_NAME & " " & OfficeDocs.UPLOADED_DATE, OfficeDocs.DOCUMENT_ID))

                        OfficeDocs.MoveNext()
                    Loop
                Case "CL"
                    Dim ClientDocs As New vCurrentClientDocuments(Me.ConnectionString)
                    ClientDocs.Where.CL_CODE.Value = Me.txtClient.Text 'Me.ClientAutoSuggestBox.SelectedValue
                    ClientDocs.Query.Load()
                    Do Until ClientDocs.EOF
                        Me.RadListBoxLinkableDocuments.Items.Add(New Telerik.Web.UI.RadListBoxItem(ClientDocs.FILENAME & " " & ClientDocs.USER_NAME & " " & ClientDocs.UPLOADED_DATE, ClientDocs.DOCUMENT_ID))
                        ClientDocs.MoveNext()
                    Loop
                Case "DI"
                    Dim DivisionDocs As New vCurrentDivisionDocuments(Me.ConnectionString)
                    DivisionDocs.Where.DIV_CODE.Value = Me.txtDivision.Text 'Me.DivisionAutoSuggestBox.SelectedValue
                    DivisionDocs.Query.Load()
                    Do Until DivisionDocs.EOF
                        Me.RadListBoxLinkableDocuments.Items.Add(New Telerik.Web.UI.RadListBoxItem(DivisionDocs.FILENAME & " " & DivisionDocs.USER_NAME & " " & DivisionDocs.UPLOADED_DATE, DivisionDocs.DOCUMENT_ID))
                        DivisionDocs.MoveNext()
                    Loop
                Case "PR"
                    Dim ProductDocs As New vCurrentProductDocuments(Me.ConnectionString)
                    ProductDocs.Where.PRD_CODE.Value = Me.txtProduct.Text 'Me.ProductAutoSuggestBox.SelectedValue
                    ProductDocs.Query.Load()
                    Do Until ProductDocs.EOF
                        Me.RadListBoxLinkableDocuments.Items.Add(New Telerik.Web.UI.RadListBoxItem(ProductDocs.FILENAME & " " & ProductDocs.USER_NAME & " " & ProductDocs.UPLOADED_DATE, ProductDocs.DOCUMENT_ID))
                        ProductDocs.MoveNext()
                    Loop
                Case "CM"
                    Dim CampaignDocs As New vCurrentCampaignDocuments(Me.ConnectionString)
                    Dim j As New cJobs(Session("ConnString"))
                    CampaignDocs.Where.CMP_IDENTIFIER.Value = j.GetCampaignIdentifier(Me.txtCampaign.Text.Trim(), Me.txtClient.Text, Me.txtDivision.Text, Me.txtProduct.Text) 'Me.txtCampaign.TextMe.CampaignAutoSuggestBox.SelectedValue
                    CampaignDocs.Query.Load()
                    Do Until CampaignDocs.EOF
                        Me.RadListBoxLinkableDocuments.Items.Add(New Telerik.Web.UI.RadListBoxItem(CampaignDocs.FILENAME & " " & CampaignDocs.USER_NAME & " " & CampaignDocs.UPLOADED_DATE, CampaignDocs.DOCUMENT_ID))
                        CampaignDocs.MoveNext()
                    Loop
                Case "JO"
                    Dim JobDox As New vCurrentJobDocuments(Me.ConnectionString)
                    JobDox.Where.JOB_NUMBER.Value = Me.txtJob.Text
                    JobDox.Query.Load()
                    Do Until JobDox.EOF
                        Me.RadListBoxLinkableDocuments.Items.Add(New Telerik.Web.UI.RadListBoxItem(JobDox.FILENAME & ", added by " & JobDox.USER_NAME & " @ " & JobDox.UPLOADED_DATE, JobDox.DOCUMENT_ID))
                        JobDox.MoveNext()
                    Loop
                Case "JC"
                    Dim JobComponentDocs As New vCurrentJobComponentDocuments(Me.ConnectionString)
                    JobComponentDocs.Where.JOB_NUMBER.Value = Me.txtJob.Text ' Me.JobAutoSuggestBox.SelectedValue
                    JobComponentDocs.Where.JOB_COMPONENT_NUMBER.Value = Me.txtComponent.Text 'Me.ComponentAutoSuggestBox.SelectedValue
                    JobComponentDocs.Query.Load()
                    Do Until JobComponentDocs.EOF
                        Me.RadListBoxLinkableDocuments.Items.Add(New Telerik.Web.UI.RadListBoxItem(JobComponentDocs.FILENAME & ", added by " & JobComponentDocs.USER_NAME & " @ " & JobComponentDocs.UPLOADED_DATE, JobComponentDocs.DOCUMENT_ID))
                        JobComponentDocs.MoveNext()
                    Loop
                Case "PS", "PST"
                    Dim JobComponentDocs As New vCurrentJobComponentDocuments(Me.ConnectionString)
                    JobComponentDocs.Where.JOB_NUMBER.Value = Me.txtJob.Text ' Me.JobAutoSuggestBox.SelectedValue
                    JobComponentDocs.Where.JOB_COMPONENT_NUMBER.Value = Me.txtComponent.Text 'Me.ComponentAutoSuggestBox.SelectedValue
                    JobComponentDocs.Query.Load()
                    Do Until JobComponentDocs.EOF
                        Me.RadListBoxLinkableDocuments.Items.Add(New Telerik.Web.UI.RadListBoxItem(JobComponentDocs.FILENAME & ", added by " & JobComponentDocs.USER_NAME & " @ " & JobComponentDocs.UPLOADED_DATE, JobComponentDocs.DOCUMENT_ID))
                        JobComponentDocs.MoveNext()
                    Loop
                Case "EST"
                    If Me.JobNumber <> 0 And Me.JobComponentNbr <> 0 Then
                        Dim JobComponentDocs As New vCurrentJobComponentDocuments(Me.ConnectionString)
                        JobComponentDocs.Where.JOB_NUMBER.Value = Me.JobNumber ' Me.JobAutoSuggestBox.SelectedValue
                        JobComponentDocs.Where.JOB_COMPONENT_NUMBER.Value = Me.JobComponentNbr 'Me.ComponentAutoSuggestBox.SelectedValue
                        JobComponentDocs.Query.Load()
                        Do Until JobComponentDocs.EOF
                            Me.RadListBoxLinkableDocuments.Items.Add(New Telerik.Web.UI.RadListBoxItem(JobComponentDocs.FILENAME & ", added by " & JobComponentDocs.USER_NAME & " @ " & JobComponentDocs.UPLOADED_DATE, JobComponentDocs.DOCUMENT_ID))
                            JobComponentDocs.MoveNext()
                        Loop
                    End If
            End Select

        Catch ex As Exception

        End Try

    End Sub
    Private Sub BindRadTreeViewStates(ByVal AlrtNotifyHdrId As Integer)
        Me.RadTreeViewStates.Nodes.Clear()
        If AlrtNotifyHdrId > 0 Then
            'bind treeview
            Dim d As New DataTable
            Dim a As New cAlerts()
            d = a.GetAlertStates("", "", AlrtNotifyHdrId)
            Me.RadTreeViewStates.Nodes.Clear()

            'Dim n As New Telerik.Web.UI.RadTreeNode
            'With n
            '    .Text = "None"
            '    .Value = "0"
            'End With
            'Me.RadTreeViewStates.Nodes.Add(n)
            Try
                If d.Rows.Count > 0 Then
                    For i As Integer = 0 To d.Rows.Count - 1
                        Dim nn As New Telerik.Web.UI.RadTreeNode
                        With nn
                            .Text = d.Rows(i)("ALERT_STATE_NAME")
                            .Value = d.Rows(i)("ALERT_STATE_ID")
                        End With
                        Me.RadTreeViewStates.Nodes.Add(nn)
                    Next
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub loadDescriptions()
        Try
            Dim client As AdvantageFramework.Database.Entities.Client = Nothing
            Dim division As AdvantageFramework.Database.Entities.Division = Nothing
            Dim product As AdvantageFramework.Database.Entities.Product = Nothing
            Dim job As AdvantageFramework.Database.Entities.Job = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If Me.txtClient.Text <> "" Then
                    Me.TextBoxClientDescription.Text = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, Me.txtClient.Text).Name
                End If
                If Me.txtClient.Text <> "" And Me.txtDivision.Text <> "" Then
                    Me.TextBoxDivisionDescription.Text = AdvantageFramework.Database.Procedures.Division.LoadByClientAndDivisionCode(DbContext, Me.txtClient.Text, Me.txtDivision.Text).Name
                End If
                If Me.txtClient.Text <> "" And Me.txtDivision.Text <> "" And Me.txtProduct.Text <> "" Then
                    Me.TextBoxProductDescription.Text = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, Me.txtClient.Text, Me.txtDivision.Text, Me.txtProduct.Text).Name
                End If
                If Me.txtJob.Text <> "" And Me.txtComponent.Text = "" Then
                    Me.TextBoxJobDescription.Text = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, Me.txtJob.Text).Description
                End If
                If Me.txtJob.Text <> "" And Me.txtComponent.Text <> "" Then
                    Me.TextBoxJobDescription.Text = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, Me.txtJob.Text, Me.txtComponent.Text).Job.Description
                    Me.TextBoxComponentDescription.Text = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, Me.txtJob.Text, Me.txtComponent.Text).Description
                End If
            End Using
        Catch ex As Exception

        End Try
    End Sub

#End Region
#Region " Defaults "

    Private Sub SetDefaultSubject()
        Dim AlertAssignmentDefaultSubjectSetting As String = ""

        Try
            Dim m As New cMaintenanceApps()
            AlertAssignmentDefaultSubjectSetting = m.AgencySettingGet("ALRT_ASSGN_DFLT_SUB").ToString().ToLower()
        Catch ex As Exception
            AlertAssignmentDefaultSubjectSetting = ""
        End Try


        If Me.ChkIsAlertAssignment.Checked = True Then
            Dim SelectedState As String = ""
            Dim SelectedTemplate As String = ""
            Try
                If Me.RadTreeViewStates.Nodes.Count > 0 Then
                    SelectedState = Me.RadTreeViewStates.SelectedNode.Text
                End If
            Catch ex As Exception
                SelectedState = ""
            End Try
            Try
                If SelectedState.LastIndexOf("*") = SelectedState.Length - 1 Then
                    SelectedState = SelectedState.Substring(0, SelectedState.Length - 1)
                End If
            Catch ex As Exception

            End Try
            Try
                If Me.RadComboBoxAlertAssignmentTemplate.Items.Count > 0 Then
                    SelectedTemplate = Me.RadComboBoxAlertAssignmentTemplate.SelectedItem.Text
                End If
            Catch ex As Exception
                SelectedTemplate = ""
            End Try

            If SelectedState = "" Or SelectedState = "[Please select]" Then SelectedState = "N/A"
            If SelectedTemplate = "" Or SelectedTemplate = "[Please select]" Then SelectedTemplate = "N/A"

            Try
                Select Case AlertAssignmentDefaultSubjectSetting
                    Case "state"
                        Me.txtSubject.Text = "[" & SelectedState & "] "
                    Case "template"
                        Me.txtSubject.Text = "[" & SelectedTemplate & "] "
                    Case "templateandstate"
                        Me.txtSubject.Text = "[" & SelectedTemplate & " | " & SelectedState & "] "
                    Case "jjcts"
                        Dim s As String = ""
                        If IsNumeric(Me.txtJob.Text) = True Then
                            Me.JobNumber = CType(Me.txtJob.Text, Integer)
                        End If
                        If IsNumeric(Me.txtComponent.Text) = True Then
                            Me.JobComponentNbr = CType(Me.txtComponent.Text, Integer)
                        End If
                        Dim oTS As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))
                        If Me.JobNumber > 0 And Me.JobComponentNbr = 0 Then
                            Dim JobDesc As String = ""
                            oTS.GetJobInfo(Me.JobNumber, JobDesc)
                            s = Me.JobNumber.ToString().PadLeft(6, "0") & " - " & JobDesc
                        End If
                        If Me.JobNumber > 0 And Me.JobComponentNbr > 0 Then
                            Dim CompDesc As String = ""
                            oTS.GetJobComponentInfo(Me.JobNumber, Me.JobComponentNbr, "", CompDesc)
                            s = Me.JobNumber.ToString().PadLeft(6, "0") & "/" & Me.JobComponentNbr.ToString().PadLeft(3, "0") & " - " & CompDesc
                        End If
                        If s.Trim() <> "" Then
                            s = s & " | "
                        End If
                        Me.txtSubject.Text = "[" & s & SelectedTemplate & " | " & SelectedState & "] "
                End Select
            Catch ex As Exception
            End Try

        End If
    End Sub
    Private Sub SetVendorQuoteDefault()
        'Me.FsAllowEmail.Visible = True
        Me.RadioAlert.Visible = False
        Me.RadioEmail.Visible = True
        Me.RadioEmail.Checked = True
        Me.RadioEmail.Enabled = False
        Me.FsAlertRecipients.Visible = False
        Me.FsAlertAssignments.Visible = False
        Me.FsEmailRecipients.Visible = True
        Session("printrfq") = 1
        Try
            Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
            Dim ds As DataSet = est.GetRequestVendors(Me.EstimateNumber, Me.EstimateComponentNbr, Me.VendorQuoteNbr, Session("UserCode"))
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    If ds.Tables(0).Rows(i)("VN_CODE") = Request.QueryString("VendorCode") Then
                        If ds.Tables(0).Rows(i)("EMAIL_ADDRESS").ToString() <> "" Then
                            Me.TxtEmailTo.Text &= ds.Tables(0).Rows(i)("EMAIL_ADDRESS").ToString() & ", "
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
        End Try
        Try
            If Me.PO_AlertFunction = "email_po" Then
                Me.RetrieveVendorContactEmailList()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub SetPurchaseOrderDefault()
        Try
            Dim ds As DataSet
            If Me.PO_RefId > 0 Then
                Dim p As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
                With p
                    .Select_POHeader(Me.PO_RefId, "")
                    Me.LblPoNumber.Text = Me.PO_RefId.ToString().PadLeft(6, "0")
                    Me.LblPoDescription.Text = p.PO_Description
                    'Me.TrPurchaseOrder.Visible = True
                    Me.ShowRow(Me.TrPurchaseOrder, True)
                    If p.Vendor_Contact_Email <> "" Then
                        Me.TxtEmailTo.Text = p.Vendor_Contact_Email & ", "
                    End If
                End With
                'Me.TxtEmailTo.Text = ""
                'ds = p.Get_PO_Vendor_EmailDS(1, Int32.Parse(Me.PO_RefId), "")
                'If ds.Tables(0).Rows.Count > 0 Then
                '    For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                '        If IsDBNull(ds.Tables(0).Rows(i)("EMAIL_ADDRESS")) = False Then
                '            Me.TxtEmailTo.Text &= ds.Tables(0).Rows(i)("EMAIL_ADDRESS") & ", "
                '        End If
                '    Next
                'End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub SetMediaATBDefault()

        'objects
        Dim MediaATBRevision As AdvantageFramework.Database.Entities.MediaATBRevision = Nothing

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                MediaATBRevision = AdvantageFramework.Database.Procedures.MediaATBRevision.LoadByATBNumberAndRevisionNumber(DbContext, Me.ATBNumber, Me.ATBRevisionNumber)

                If MediaATBRevision IsNot Nothing Then

                    TextBoxATBDescription.Text = MediaATBRevision.Description
                    TextBoxATBRevDescription.Text = MediaATBRevision.Description

                    txtClient.Text = MediaATBRevision.MediaATB.ClientCode
                    txtDivision.Text = MediaATBRevision.MediaATB.DivisionCode
                    txtProduct.Text = MediaATBRevision.MediaATB.ProductCode

                    TextBoxClientDescription.Text = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, txtClient.Text).Name
                    TextBoxDivisionDescription.Text = AdvantageFramework.Database.Procedures.Division.LoadByClientAndDivisionCode(DbContext, txtClient.Text, txtDivision.Text).Name
                    TextBoxProductDescription.Text = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, txtClient.Text, txtDivision.Text, txtProduct.Text).Name

                    Me.hlClient.Attributes.Remove("onclick")
                    Me.hlDivision.Attributes.Remove("onclick")
                    Me.hlProduct.Attributes.Remove("onclick")
                    Me.hlMediaATB.Attributes.Remove("onclick")

                    Me.txtClient.ReadOnly = True
                    Me.txtDivision.ReadOnly = True
                    Me.txtProduct.ReadOnly = True

                End If

            End Using

            Try

                If Me.AutoSetToAssignment = False Then

                    Me.txtSubject.Text = "[New Alert] for ATB " & Me.ATBNumber.ToString().PadLeft(6, "0") & "-" & Me.ATBRevisionNumber.ToString.PadLeft(3, "0")

                End If

            Catch ex As Exception
            End Try

        Catch ex As Exception

        End Try

    End Sub
    Private Sub SetEstimateDefault(ByVal SetSubjectOnly As Boolean)
        Try
            If SetSubjectOnly = False Then
                Me.TxtEstimateNumber.Text = Me.EstimateNumber.ToString()
                Try

                Catch ex As Exception

                End Try
            End If

        Catch ex As Exception
        End Try
        Try
            If Me.AutoSetToAssignment = False Then
                Me.txtSubject.Text = "[Estimate " & Me.EstimateNumber.ToString().PadLeft(6, "0") & " Updated] By " & Session("EmployeeName")
            End If
        Catch ex As Exception
        End Try

    End Sub
    Private Sub SetEstimateComponentDefault(ByVal SetSubjectOnly As Boolean)
        Try
            'If Me.AutoSetToAssignment = True Then Exit Sub
            Dim oEstimating As cEstimating = New cEstimating(Session("ConnString"), CStr(Session("UserCode")))
            Dim dt As New DataTable
            Dim ThisJobNumber As Integer = 0
            Dim ThisJobComponentNbr As Integer = 0

            dt = oEstimating.GetEstimateData(Me.EstimateNumber, Me.EstimateComponentNbr, Me.JobNumber, Me.JobComponentNbr, Session("UserCode"))
            If Not dt Is Nothing Then
                If dt.Rows.Count > 0 Then
                    If SetSubjectOnly = False Then
                        If IsDBNull(dt.Rows(0)("ESTIMATE_NUMBER")) = False Then
                            Me.TxtEstimateNumber.Text = dt.Rows(0)("ESTIMATE_NUMBER")
                        End If
                        If IsDBNull(dt.Rows(0)("EST_LOG_DESC")) = False Then
                            Me.TextBoxEstimateDescription.Text = dt.Rows(0)("EST_LOG_DESC")
                        End If
                        If IsDBNull(dt.Rows(0)("EST_COMPONENT_NBR")) = False Then
                            Me.TxtEstimateComponentNbr.Text = dt.Rows(0)("EST_COMPONENT_NBR")
                        End If
                        If IsDBNull(dt.Rows(0)("EST_COMP_DESC")) = False Then
                            Me.TextBoxEstimateComponentDescription.Text = dt.Rows(0)("EST_COMP_DESC")
                        End If
                        If IsDBNull(dt.Rows(0)("JOB_NUMBER")) = False Then
                            ThisJobNumber = dt.Rows(0)("JOB_NUMBER")
                        End If
                        If IsDBNull(dt.Rows(0)("JOB_COMPONENT_NBR")) = False Then
                            ThisJobComponentNbr = dt.Rows(0)("JOB_COMPONENT_NBR")
                        End If
                        If IsDBNull(dt.Rows(0)("CL_CODE")) = False Then
                            Me.ClCode = dt.Rows(0)("CL_CODE")
                        End If
                    End If
                    If Me.AutoSetToAssignment = False Then
                        Me.txtSubject.Text = "[Estimate/Comp " & Me.EstimateNumber.ToString().PadLeft(6, "0") & " - " & Me.EstimateComponentNbr.ToString().PadLeft(2, "0") & "]"
                        If ThisJobNumber > 0 And ThisJobComponentNbr > 0 Then
                            Me.txtSubject.Text &= " for Job " & ThisJobNumber.ToString().PadLeft(6, "0") & "-" & ThisJobComponentNbr.ToString().PadLeft(3, "0")
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub SetCampaignDefault(ByVal SetSubjectOnly As Boolean)
        Try
            Dim cmp As cCampaign = New cCampaign(Session("ConnString"), Me.CmpIdentifier)
            cmp.LoadCampaignbyCode(Me.CmpIdentifier)
            With cmp
                If SetSubjectOnly = False Then
                    Me.txtClient.Text = .CL_CODE
                    Me.txtDivision.Text = .DIV_CODE
                    Me.txtProduct.Text = .PRD_CODE
                    Me.txtCampaign.Text = .CMP_CODE

                    Me.txtClient.ReadOnly = True
                    Me.txtDivision.ReadOnly = True
                    Me.txtProduct.ReadOnly = True
                    Me.txtCampaign.ReadOnly = True

                    Me.hlClient.Attributes.Remove("onclick")
                    Me.hlDivision.Attributes.Remove("onclick")
                    Me.hlProduct.Attributes.Remove("onclick")
                    Me.hlCampaign.Attributes.Remove("onclick")
                End If
                If Me.AutoSetToAssignment = False Then
                    If Me.SendOnly = False Then
                        Me.txtSubject.Text = "[Campaign Updated] Campaign " & cmp.CMP_CODE & " - " & cmp.CMP_NAME & " for client " & cmp.CL_CODE & " by " & cmp.getUserFullEmpName(Session("UserCode"))
                    Else
                        Me.txtSubject.Text = "[Campaign " & cmp.CMP_CODE & " - " & cmp.CMP_NAME & " ] for Client " & cmp.CL_CODE & " - " & cmp.CL_NAME
                    End If
                End If

            End With
        Catch ex As Exception
        End Try
    End Sub
    Private Sub SetProjectScheduleDefault(ByVal SetSubjectOnly As Boolean)
        Try
            Dim oTrafficSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
            Dim dt As New DataTable
            dt = oTrafficSchedule.GetScheduleHeader(Me.JobNumber, Me.JobComponentNbr, Session("UserCode").ToString(), False).Tables(0)
            If Not dt Is Nothing Then
                If dt.Rows.Count > 0 Then
                    If SetSubjectOnly = False Then
                        If IsDBNull(dt.Rows(0)("JOB_FIRST_USE_DATE")) = False Then
                            If cGlobals.wvIsDate(dt.Rows(0)("JOB_FIRST_USE_DATE")) = True Then
                                Me.RadDatePickerDueDate.SelectedDate = cGlobals.wvCDate(dt.Rows(0)("JOB_FIRST_USE_DATE"))
                            End If
                        End If
                    End If
                    Dim JobCompDescript As String = ""
                    Dim clcode As String = ""
                    If IsDBNull(dt.Rows(0)("JOB_COMP_DESC")) = False Then
                        JobCompDescript = dt.Rows(0)("JOB_COMP_DESC")
                    End If
                    If IsDBNull(dt.Rows(0)("CL_CODE")) = False Then
                        clcode = dt.Rows(0)("CL_CODE")
                    End If

                    If Me.AutoSetToAssignment = False Then
                        Me.txtSubject.Text = "[Project Schedule Updated] Job/Comp " & Me.JobNumber.ToString().PadLeft(6, "0") & "-" & Me.JobComponentNbr.ToString.PadLeft(3, "0") & " - " & JobCompDescript & " for client " & clcode & " by " & Session("EmployeeName")
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub SetTaskDefault(ByVal SetSubjectOnly As Boolean)
        Try

            Using oc = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Dim Task As AdvantageFramework.Database.Entities.JobComponentTask
                Task = Nothing

                Task = AdvantageFramework.Database.Procedures.JobComponentTask.LoadByJobNumberAndJobComponentNumberAndSequenceNumber(oc, Me.JobNumber, Me.JobComponentNbr, Me.TaskSeqNbr)

                If Task IsNot Nothing Then

                    Dim DescriptionStringBuilder As New System.Text.StringBuilder
                    Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent

                    With DescriptionStringBuilder

                        If Task.Description IsNot Nothing AndAlso String.IsNullOrEmpty(Task.Description) = False Then

                            .Append(Task.Description)
                            .Append("<br />")

                        End If

                        .Append("Default hours:  ")
                        If Task.Hours IsNot Nothing Then

                            .Append(LoGlo.FormatNumber(Task.Hours))

                        Else

                            .Append("N/A")

                        End If
                        .Append("<br />")

                        Dim TotalDisbursedHours As Decimal = 0.0
                        Try

                            TotalDisbursedHours = AdvantageFramework.Database.Procedures.JobComponentTaskEmployee.GetTotalDisbursedHours(oc, Me.JobNumber, Me.JobComponentNbr, Me.TaskSeqNbr)

                        Catch ex As Exception
                            TotalDisbursedHours = 0.0
                        End Try
                        If TotalDisbursedHours > 0.0 Then

                            .Append("Disbursed hours:  ")
                            If Task.Hours IsNot Nothing Then

                                .Append(LoGlo.FormatNumber(TotalDisbursedHours))

                            End If
                            .Append("<br />")

                        End If

                        .Append("Task comments:  ")
                        If Task.Comment IsNot Nothing AndAlso String.IsNullOrEmpty(Task.Comment) = False Then

                            .Append(Task.Comment)

                        Else

                            .Append("N/A")

                        End If
                        .Append("<br />")


                    End With

                    Me.BodyRadEditor.Html = DescriptionStringBuilder.ToString()

                    If SetSubjectOnly = False Then

                        If Task.DueDate IsNot Nothing AndAlso cGlobals.wvIsDate(Task.DueDate) = True Then

                            Me.RadDatePickerDueDate.SelectedDate = cGlobals.wvCDate(Task.DueDate)

                        End If
                        If Task.DueTime IsNot Nothing Then

                            Me.TxtTimeDue.Text = Task.DueTime

                        Else

                            Me.TxtTimeDue.Text = ""

                        End If

                    End If

                    JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(oc, Me.JobNumber, Me.JobComponentNbr)

                    If JobComponent IsNot Nothing AndAlso JobComponent.Description IsNot Nothing Then

                        Me.txtSubject.Text = "[Task Updated] for Job:  " & Me.JobNumber.ToString().PadLeft(6, "0") & "/" & Me.JobComponentNbr.ToString().PadLeft(3, "0") & " - " & JobComponent.Description

                    Else

                        Me.txtSubject.Text = "[Task Updated] for Job:  " & Me.JobNumber.ToString().PadLeft(6, "0") & "/" & Me.JobComponentNbr.ToString().PadLeft(3, "0")

                    End If

                    If Task.Description IsNot Nothing AndAlso String.IsNullOrEmpty(Task.Description) = False Then

                        Me.txtSubject.Text &= ", Task:  " & Task.Description

                    End If

                End If

            End Using

            Me.RadioAlert.Checked = False
            Me.RadioNotifyAlertGroup.Checked = False
            Me.RadioNotifyEmployeesAssigned.Checked = False
            Me.RadioNotifyNext.Checked = False
            Me.RadioNotifyEmployeesTask.Checked = True
            Me.SetAlertRecipientsForNotifyEmployeeTask()

        Catch ex As Exception
        End Try

    End Sub
    Private Sub PopulateEmailSubject()
        If Me.AutoSetToAssignment = True Then Exit Sub
        Dim HasData As Boolean = False
        Dim sb1 As New System.Text.StringBuilder
        Dim jc As New Job(Session("ConnString"))
        'sb1.Append("[")
        If Session("pagetype") = "po" Or Me.PageType() = "po" Then
            HasData = True
            Dim POHeader As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
            POHeader.Select_POHeader(Int32.Parse(Me.PO_RefId), "")
            sb1.Append("[Purchase Order] ")
            sb1.Append(Me.PO_RefId)
            sb1.Append(" for ")
            sb1.Append(POHeader.Vendor_Name.Trim())
        End If
        If Session("pagetype") = "jt" Or Me.PageType() = "jt" Then
            HasData = True
            sb1.Append("[Job Order]")
            If Request.QueryString("fromapp") IsNot Nothing AndAlso Request.QueryString("fromapp") = "jobsearchmul" Then
                sb1.Append(" for multiple Job/Components")
            Else
                sb1.Append(" for Job/Comp ")
                jc.GetJob(Me.JobNumber, Me.JobComponentNbr)
                If jc.JobComponent.JOB_COMP_DESC.Length > 254 Then
                    sb1.Append(Me.JobNumber.ToString.PadLeft(6, "0") & "-" & Me.JobComponentNbr.ToString.PadLeft(3, "0") & " - " & jc.JobComponent.JOB_COMP_DESC.Substring(0, 254) & "...")
                Else
                    sb1.Append(Me.JobNumber.ToString.PadLeft(6, "0") & "-" & Me.JobComponentNbr.ToString.PadLeft(3, "0") & " - " & jc.JobComponent.JOB_COMP_DESC)
                End If
            End If
        End If
        If Session("pagetype") = "js" Or Me.PageType() = "js" Then
            HasData = True
            jc.GetJob(Me.JobNumber, Me.JobComponentNbr)
            sb1.Append("[Job Specs]")
            sb1.Append(" for Job/Comp ")
            If jc.JobComponent.JOB_COMP_DESC.Length > 254 Then
                sb1.Append(Session("JSReportJobNum").ToString.PadLeft(6, "0") & "-" & Session("JSReportJobCompNum").ToString.PadLeft(3, "0") & " - " & jc.JobComponent.JOB_COMP_DESC.Substring(0, 254) & "...")
            Else
                sb1.Append(Session("JSReportJobNum").ToString.PadLeft(6, "0") & "-" & Session("JSReportJobCompNum").ToString.PadLeft(3, "0") & " - " & jc.JobComponent.JOB_COMP_DESC)
            End If

        End If
        If Session("pagetype") = "jv" Or Me.PageType() = "jv" Then
            HasData = True
            jc.GetJob(Me.JobNumber, Me.JobComponentNbr)
            sb1.Append("[")
            sb1.Append(Session("JVTemplateName").ToString.Replace("\", "").Replace("/", ""))
            sb1.Append(" - " & Session("JVReportVersion"))
            sb1.Append("] ")
            sb1.Append(jc.ClientDesc & " -")
            sb1.Append(" Job/Comp ")
            If jc.JobComponent.JOB_COMP_DESC.Length > 254 Then
                sb1.Append(Session("JVReportJobNum").ToString.PadLeft(6, "0") & "-" & Session("JVReportJobCompNum").ToString.PadLeft(3, "0") & " - " & jc.JobComponent.JOB_COMP_DESC.Substring(0, 254) & "...")
            Else
                sb1.Append(Session("JVReportJobNum").ToString.PadLeft(6, "0") & "-" & Session("JVReportJobCompNum").ToString.PadLeft(3, "0") & " - " & jc.JobComponent.JOB_COMP_DESC)
            End If

        End If
        If Session("pagetype") = "cb" Or Me.PageType() = "cb" Then
            HasData = True
            jc.GetJob(Me.JobNumber, Me.JobComponentNbr)
            sb1.Append("[Creative Brief]")
            sb1.Append(" for Job/Comp ")
            If jc.JobComponent.JOB_COMP_DESC.Length > 254 Then
                sb1.Append(Session("CBReportJobNum").ToString.PadLeft(6, "0") & "-" & Session("CBReportJobCompNum").ToString.PadLeft(3, "0") & " - " & jc.JobComponent.JOB_COMP_DESC.Substring(0, 254) & "...")
            Else
                sb1.Append(Session("CBReportJobNum").ToString.PadLeft(6, "0") & "-" & Session("CBReportJobCompNum").ToString.PadLeft(3, "0") & " - " & jc.JobComponent.JOB_COMP_DESC)
            End If
        End If
        If Session("pagetype") = "rfq" Or Me.PageType() = "rfq" Then
            HasData = True
            Dim oEstimating As New cEstimating(Session("ConnString"), Session("UserCode"))
            Dim dt As DataTable
            sb1.Append("[Request For Quote]")
        End If

        'sb1.Append("] ")

        If (Session("pagetype") = "po" Or Me.PageType() = "po") Then
            sb1.Append(" Please see attachment.")
        End If

        Dim str As String = sb1.ToString()

        If str.Trim() <> "" And HasData = True Then
            Me.txtSubject.Text = sb1.ToString()
        End If

        sb1 = Nothing
    End Sub
    Private Sub SetJobRequestCDP()
        Try
            Dim dr As SqlDataReader
            Dim jv As New JobVersion(Session("ConnString"))
            Dim agency As New AdvantageFramework.Web.AgencySettings.Methods(Session("ConnString"), Session("UserCode"), HttpContext.Current)
            Dim str As String = ""
            Dim drCP As SqlDataReader
            Dim osec As New cSecurity(HttpContext.Current.Session("ConnString"))
            Dim cmp As New cCampaign(Session("ConnString"))

            Me.txtClient.Text = Session("JobVerSendClient")
            Me.txtDivision.Text = Session("JobVerSendDivision")
            Me.txtProduct.Text = Session("JobVerSendProduct")

            Dim JobRequestEmployee As String = agency.GetValue(AdvantageFramework.Agency.Settings.JR_DFLT_CONTACT, "")
            Dim JobRequestAlertGroup As String = agency.GetValue(AdvantageFramework.Agency.Settings.JR_DFLT_ALERT_GROUP, "")
            If JobRequestAlertGroup <> "" Then
                str = cmp.GetAlertGroupDefaultEmployeesJR(JobRequestAlertGroup)
                Me.AutoCompleteRecipients.AddEntries(str)
            ElseIf JobRequestEmployee <> "" Then
                Me.AutoCompleteRecipients.AddEntries(JobRequestEmployee)
            Else
                If IsClientPortal = True Then
                    If _Session.ClientPortalUser.AlertGroupCode IsNot Nothing Then
                        str = cmp.GetAlertGroupDefaultEmployeesJR(_Session.ClientPortalUser.AlertGroupCode)
                        Me.AutoCompleteRecipients.AddEntries(str)
                    Else
                        drCP = osec.getUsersCPData(HttpContext.Current.Session("UserID"))
                        If drCP.HasRows Then
                            drCP.Read()
                            If drCP("AGENCY_CONTACT_CODE").ToString <> "" Then
                                Me.AutoCompleteRecipients.AddEntries(drCP("AGENCY_CONTACT_CODE").ToString)
                            End If
                            drCP.Close()
                        End If
                    End If
                End If
            End If

            dr = jv.GetJVRequestDescriptions(JobVerHdrID)
            If dr.HasRows Then
                dr.Read()
                Try
                    If Me.AutoSetToAssignment = False Then
                        If Request.QueryString("update") = "jrupdate" Then
                            If Me.IsClientPortal = True Then
                                Me.txtSubject.Text = "UPDATED - Job Request by " & Session("ContactName") & " for " & dr.GetString(1)
                            Else
                                Me.txtSubject.Text = "UPDATED - Job Request by " & Session("EmployeeName") & " for " & dr.GetString(1)
                            End If
                        Else
                            If Me.IsClientPortal = True Then
                                Me.txtSubject.Text = "Job Request by " & Session("ContactName") & " for " & dr.GetString(1)
                            Else
                                Me.txtSubject.Text = "Job Request by " & Session("EmployeeName") & " for " & dr.GetString(1)
                            End If
                        End If
                    End If
                Catch ex As Exception
                End Try
                dr.Close()
            End If

            Me.hlClient.Attributes.Remove("onclick")
            Me.hlClient.Attributes.Remove("href")
            Me.hlClient.NavigateUrl = Nothing
            Me.hlDivision.Attributes.Remove("onclick")
            Me.hlDivision.Attributes.Remove("href")
            Me.hlDivision.NavigateUrl = Nothing
            Me.hlProduct.Attributes.Remove("onclick")
            Me.hlProduct.Attributes.Remove("href")
            Me.hlProduct.NavigateUrl = Nothing

            Me.txtClient.ReadOnly = True
            Me.txtDivision.ReadOnly = True
            Me.txtProduct.ReadOnly = True

            ClientRequiredFieldValidator.Enabled = False
            DivisionRequiredFieldValidator.Enabled = False
            ProductRequiredFieldValidator.Enabled = False

        Catch ex As Exception

        End Try
    End Sub

#End Region
#Region " Control Page "

    Private Sub SetEmailOrAlert()

        If Not Me.Page.IsPostBack And Not Me.Page.IsCallback Then

            Me.RadioEmail.Checked = False
            Me.RadioAlert.Checked = True
            Me.FsAlertRecipients.Visible = True
            Me.FsEmailRecipients.Visible = False
            Me.ChkIsAlertAssignment.Visible = False

            If (Me.RadioAlert.Checked = True) Or
                (Me.RadComboBoxAlertLevel.Enabled = False And Me.FsAlertRecipients.Visible = True) Then

                Me.ChkIsAlertAssignment.Visible = True
                'TEST: Me.FsAlertRecipients.Visible = Not Me.ChkIsAlertAssignment.Checked

            End If

        Else

            Me._SetEmailOrAlert()

        End If

    End Sub
    Private Sub _SetEmailOrAlert()

        If Me.SendOnly = True Then

            If Me.RadioEmail.Checked = True Then

                Me.FsAlertRecipients.Visible = False
                Me.FsEmailRecipients.Visible = True

                With Me.ChkIsAlertAssignment

                    .Visible = False
                    .Checked = False

                End With

                Me.HideAlertFields(True)

                Try

                    Me.FsAlertAssignments.Visible = False

                Catch ex As Exception

                End Try
                Try

                    If Me.RadComboBoxAlertAssignmentTemplate.Items.Count > 0 Then

                        Me.RadComboBoxAlertAssignmentTemplate.SelectedIndex = 0

                    End If
                Catch ex As Exception

                End Try
                Try

                    If Me.RadComboBoxAssignTo.Items.Count = 0 Then

                        Me.RadComboBoxAssignTo.SelectedIndex = 0

                    End If
                Catch ex As Exception

                End Try

                Me.RadToolbarAlertNew.FindItemByValue("SaveDraft").Visible = False

            Else 'an alert, not email

                Me.FsEmailRecipients.Visible = False
                Me.ChkIsAlertAssignment.Visible = True

                If Me.ChkIsAlertAssignment.Checked = True Then

                    'Me.FsAlertRecipients.Visible = False
                    Me.FsAlertAssignments.Visible = True

                Else

                    'Me.FsAlertRecipients.Visible = True
                    Me.FsAlertAssignments.Visible = False

                End If

                Me.HideAlertFields(False)

            End If

            If Me.SendOnly = True Then

                If Me.App <> Source_App.Estimate And Me.App <> Source_App.EstimateComponent And Me.App <> Source_App.JobJacket Then

                    Me.ChkExcludeAttachmentFromEmail.Checked = False
                    Me.ChkExcludeAttachmentFromEmail.Enabled = False

                    If Me.App = Source_App.Campaign Then

                        Me.ChkExcludeAttachmentFromEmail.Visible = False

                    End If
                End If
            Else

                Me.ChkExcludeAttachmentFromEmail.Checked = True
                Me.ChkExcludeAttachmentFromEmail.Enabled = True

            End If

        Else 'normal alert

            Me.FsEmailRecipients.Visible = False
            Me.FsAlertRecipients.Visible = True 'TEST: 
            Me.ChkIsAlertAssignment.Visible = True

            If Me.ChkIsAlertAssignment.Checked = True Then

                'TEST: Me.FsAlertRecipients.Visible = False
                Me.FsAlertAssignments.Visible = True

            Else

                Me.FsAlertRecipients.Visible = True
                Me.FsAlertAssignments.Visible = False

            End If

        End If

    End Sub
    Private Sub ResetForm()

        If Me.AutoSetToAssignment = False Then

            Try

                If Me.RadComboBoxPriority.Items.Count > 0 Then

                    Me.RadComboBoxPriority.FindItemByValue("3").Selected = True

                End If

            Catch ex As Exception
            End Try

            Select Case Me.App
                Case Source_App.Alert
                    Me.txtOffice.Text = ""
                    Me.txtClient.Text = ""
                    Me.txtDivision.Text = ""
                    Me.txtProduct.Text = ""
                    Me.txtCampaign.Text = ""
                    Me.txtJob.Text = ""
                    Me.txtComponent.Text = ""
                    Me.TextBoxClientDescription.Text = ""
                    Me.TextBoxDivisionDescription.Text = ""
                    Me.TextBoxProductDescription.Text = ""
                    Me.TextBoxJobDescription.Text = ""
                    Me.TextBoxComponentDescription.Text = ""
                    Me.TextBoxCampaignDescription.Text = ""
                    Me.TxtOfficeDescription.Text = ""
                    Try
                        Me.RadDatePickerDueDate.DateInput.Text = ""
                        Me.RadDatePickerDueDate.SelectedDate = Nothing
                    Catch ex As Exception
                    End Try

                    Me.TxtTimeDue.Text = ""

                    Try
                        Me.RadComboBoxAlertLevel.SelectedIndex = -1
                        'Me.RadComboBoxAlertLevel.Focus()
                    Catch ex As Exception
                    End Try

                    'TEST: Me.FsAlertRecipients.Visible = False

                    Me.ShowRow(Me.TrOffice, False)
                    Me.ShowRow(Me.TrClient, False)
                    Me.ShowRow(Me.TrDivision, False)
                    Me.ShowRow(Me.TrProduct, False)
                    Me.ShowRow(Me.TrCampaign, False)
                    Me.ShowRow(Me.TrJob, False)
                    Me.ShowRow(Me.TrComponent, False)

                    Me.ShowRow(Me.TrEstimateNumber, False)
                    Me.ShowRow(Me.TrEstimateComponentNbr, False)
                    Me.ShowRow(Me.TrPurchaseOrder, False)
                    Me.ShowRow(Me.TrMediaATB, False)
                    Me.ShowRow(Me.TrMediaATBRev, False)

            End Select

            Me.txtOffice.Text = ""
            Me.txtClient.Text = ""
            Me.txtDivision.Text = ""
            Me.txtProduct.Text = ""
            Me.txtCampaign.Text = ""
            Me.txtJob.Text = ""
            Me.txtComponent.Text = ""
            Me.TextBoxClientDescription.Text = ""
            Me.TextBoxDivisionDescription.Text = ""
            Me.TextBoxProductDescription.Text = ""
            Me.TextBoxJobDescription.Text = ""
            Me.TextBoxComponentDescription.Text = ""
            Me.TextBoxCampaignDescription.Text = ""
            Me.TxtOfficeDescription.Text = ""

            Me.TxtEstimateNumber.Text = ""
            Me.TxtEstimateComponentNbr.Text = ""
            Me.LblPoNumber.Text = ""
            Me.LblPoDescription.Text = ""
            Me.txtMediaATB.Text = ""
            Me.txtMediaATBRev.Text = ""

            Try

                Me.RadDatePickerDueDate.DateInput.Text = ""
                Me.RadDatePickerDueDate.SelectedDate = Nothing

            Catch ex As Exception
            End Try

            Me.TxtTimeDue.Text = ""

            Me.txtSubject.Text = ""
            Me.BodyRadEditor.Html = ""

            Me.AutoCompleteRecipients.Clear()

            Me.RadioAlert.Checked = False
            Me.RadioNotifyAlertGroup.Checked = False
            Me.RadioNotifyEmployeesAssigned.Checked = False
            Me.RadioNotifyEmployeesTask.Checked = False
            Me.RadioNotifyNext.Checked = False

            Me.RadUploadAlertDocuments.Visible = True

            If Me.RadComboBoxAlertAssignmentTemplate.Items.Count > 0 Then

                Me.RadComboBoxAlertAssignmentTemplate.SelectedIndex = 0

            End If

            Me.RadTreeViewStates.Nodes.Clear()

            If Me.RadComboBoxAssignTo.Items.Count > 0 Then

                Me.RadComboBoxAssignTo.SelectedIndex = 0

            End If

            Me.RadComboBoxAssignTo.Enabled = False

            Me.ChkIsAlertAssignment.Checked = False
            Me.FsAlertAssignments.Visible = False

            If Me.SendOnly = True Then

                'Me.FsAllowEmail.Visible = True
                Me.RadioEmail.Checked = False
                Me.RadioAlert.Checked = True
                Me.FsAlertRecipients.Visible = True
                Me.FsEmailRecipients.Visible = False
                Me.ChkExcludeAttachmentFromEmail.Enabled = False

            End If

            Me.ChkExcludeAttachmentFromEmail.Checked = False

            If Me.RadComboBoxAlertLevel.SelectedIndex = 0 Then 'or Me.FsAlertRecipients.Visible = True Then

                Me.ChkIsAlertAssignment.Visible = False

            End If

            Try
                If Me.RadComboBoxCategory.Items.Count > 0 Then
                    Me.RadComboBoxCategory.SelectedIndex = 0
                End If
            Catch ex As Exception
            End Try


        Else  'reset, but leave the assignment stuff alone

            Me.RadioAlert.Checked = False
            Me.RadioNotifyAlertGroup.Checked = False
            Me.RadioNotifyEmployeesAssigned.Checked = False
            Me.RadioNotifyEmployeesTask.Checked = False
            Me.RadioNotifyNext.Checked = False

            If Me.RadComboBoxAlertAssignmentTemplate.Items.Count > 0 Then

                Me.RadComboBoxAlertAssignmentTemplate.SelectedIndex = 0

            End If

            Me.RadTreeViewStates.Nodes.Clear()

            If Me.RadComboBoxAssignTo.Items.Count > 0 Then

                Me.RadComboBoxAssignTo.SelectedIndex = 0

            End If

            Me.RadComboBoxAssignTo.Enabled = False

            Try
                If Me.RadComboBoxPriority.Items.Count > 0 Then

                    Me.RadComboBoxPriority.FindItemByValue("3").Selected = True

                End If
            Catch ex As Exception
            End Try
            Try
                If Me.RadComboBoxCategory.Items.Count > 0 Then
                    Me.RadComboBoxCategory.SelectedIndex = 0
                End If
            Catch ex As Exception
            End Try
            Try
                Me.RadDatePickerDueDate.SelectedDate = Nothing
                Me.RadDatePickerDueDate.DateInput.Text = ""
            Catch ex As Exception
            End Try

            Me.TxtTimeDue.Text = ""

            Me.txtSubject.Text = ""
            Me.BodyRadEditor.Html = ""

            Me.RadUploadAlertDocuments.Visible = True

            'TEST: Me.FsAlertRecipients.Visible = False
            Me.FsAlertAssignments.Visible = True

            Me.PreSetAlertAssignment()

            Me.FieldsetCopyOptions.Visible = False

            Me.AutoCompleteRecipients.Clear()
            Me.ChkExcludeAttachmentFromEmail.Checked = False

        End If

        If Me.RadComboBoxAlertLevel.Enabled = True Then

            If Me.txtOffice.Enabled = True Then
                Me.txtOffice.Text = ""
                Me.TxtOfficeDescription.Text = ""
            End If
            If Me.txtClient.Enabled = True Then
                Me.txtClient.Text = ""
                Me.TextBoxClientDescription.Text = ""
            End If
            If Me.txtDivision.Enabled = True Then
                Me.txtDivision.Text = ""
                Me.TextBoxDivisionDescription.Text = ""
            End If
            If Me.txtProduct.Enabled = True Then
                Me.txtProduct.Text = ""
                Me.TextBoxProductDescription.Text = ""
            End If
            If Me.txtCampaign.Enabled = True Then
                Me.txtCampaign.Text = ""
                Me.TextBoxCampaignDescription.Text = ""
            End If
            If Me.txtJob.Enabled = True Then
                Me.txtJob.Text = ""
                Me.TextBoxJobDescription.Text = ""
            End If
            If Me.txtComponent.Enabled = True Then
                Me.txtComponent.Text = ""
                Me.TextBoxComponentDescription.Text = ""
            End If

        End If

        Me.FieldsetBoardSprint.Visible = False

        Me.RadComboBoxBoard.Items.Clear()
        Me.RadComboBoxBoardState.Items.Clear()
        Me.RadComboBoxSprint.Items.Clear()

    End Sub
    Private Sub ChangeAlertLevel(ByVal AlertLevelCode As String)


        Me.SetAlertLevel(AlertLevelCode)
        Me.SetRadioNotify()
        'Me.SetEmailOrAlert()
        Me.FsAlertRecipients.Visible = True
        If Me.ChkIsAlertAssignment.Visible = True Then
            If Me.ChkIsAlertAssignment.Checked = True Then
                '''Me.TxtRecipients.Value = ""
                Me.RadioNotifyAlertGroup.Checked = False
                Me.RadioNotifyEmployeesAssigned.Checked = False
                Me.RadioNotifyEmployeesTask.Checked = False
                Me.RadioNotifyNext.Checked = False
                'TEST: Me.FsAlertRecipients.Visible = False
                Me.FsAlertAssignments.Visible = True
            Else
                Try
                    Me.RadComboBoxAlertAssignmentTemplate.SelectedIndex = 0
                    Me.RadTreeViewStates.Nodes.Clear()
                    Me.RadComboBoxAssignTo.Items.Clear()
                    Me.RadComboBoxAssignTo.Enabled = False
                Catch ex As Exception
                End Try
                'TEST: Me.FsAlertRecipients.Visible = True
                Me.FsAlertAssignments.Visible = False
            End If
        End If
    End Sub
    Private Sub SetAlertLevel(ByVal AlertLevelCode As String)

        'objects
        Dim IsProofHQEnabled As Boolean = False

        Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

            IsProofHQEnabled = AdvantageFramework.ProofHQ.IsProofHQEnabled(DataContext)

        End Using

        Me.hlJob.Attributes.Remove("onclick")
        If AlertLevelCode = "JO" Then

            Me.hlJob.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?o=1&form=newalert&type=job&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value + '&office=' + document.forms[0]." & Me.txtOffice.ClientID & ".value);return false;")

        Else

            Me.hlJob.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?o=0&form=newalert&type=job&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&job=' + document.forms[0]." & Me.txtJob.ClientID & ".value);return false;")

        End If

        OfficeRequiredFieldValidator.Enabled = False
        ClientRequiredFieldValidator.Enabled = False
        DivisionRequiredFieldValidator.Enabled = False
        ProductRequiredFieldValidator.Enabled = False
        CampaignRequiredFieldValidator.Enabled = False
        JobRequiredFieldValidator.Enabled = False
        ComponentRequiredFieldValidator.Enabled = False
        MediaATBRequiredFieldValidator.Enabled = False
        MediaATBRevRequiredFieldValidator.Enabled = False

        Me.txtOffice.CssClass = Nothing
        Me.txtClient.CssClass = Nothing
        Me.txtDivision.CssClass = Nothing
        Me.txtProduct.CssClass = Nothing
        Me.txtCampaign.CssClass = Nothing
        Me.txtJob.CssClass = Nothing
        Me.txtComponent.CssClass = Nothing

        Me.txtOffice.ReadOnly = False
        Me.txtClient.ReadOnly = False
        Me.txtDivision.ReadOnly = False
        Me.txtProduct.ReadOnly = False
        Me.txtCampaign.ReadOnly = False
        Me.txtJob.ReadOnly = False
        Me.txtComponent.ReadOnly = False

        MiscFN.RadComboBoxSetIndex(Me.RadComboBoxAlertLevel, AlertLevelCode, False, False)

        Me.ShowRow(Me.TrOffice, False)
        Me.ShowRow(Me.TrClient, False)
        Me.ShowRow(Me.TrDivision, False)
        Me.ShowRow(Me.TrProduct, False)
        Me.ShowRow(Me.TrCampaign, False)
        Me.ShowRow(Me.TrJob, False)
        Me.ShowRow(Me.TrComponent, False)
        Me.ShowRow(Me.TrEstimateNumber, False)
        Me.ShowRow(Me.TrEstimateComponentNbr, False)
        Me.ShowRow(Me.TrPurchaseOrder, False)
        Me.ShowRow(Me.TrMediaATB, False)
        Me.ShowRow(Me.TrMediaATBRev, False)

        Select Case AlertLevelCode
            Case "OF"

                OfficeRequiredFieldValidator.Enabled = True

                Me.txtOffice.CssClass = "RequiredInput"
                Me.FocusControl(Me.txtOffice)

                Me.txtClient.Text = ""
                Me.txtDivision.Text = ""
                Me.txtProduct.Text = ""
                Me.txtCampaign.Text = ""
                Me.txtJob.Text = ""
                Me.txtComponent.Text = ""

                Me.txtClient.ReadOnly = True
                Me.txtDivision.ReadOnly = True
                Me.txtProduct.ReadOnly = True
                Me.txtCampaign.ReadOnly = True
                Me.txtJob.ReadOnly = True
                Me.txtComponent.ReadOnly = True

                Me.ShowRow(Me.TrOffice, True)

            Case "CL"

                ClientRequiredFieldValidator.Enabled = True

                Me.txtClient.CssClass = "RequiredInput"
                Me.FocusControl(Me.txtClient)

                Me.txtOffice.Text = ""
                Me.txtDivision.Text = ""
                Me.txtProduct.Text = ""
                Me.txtCampaign.Text = ""
                Me.txtJob.Text = ""
                Me.txtComponent.Text = ""

                Me.txtOffice.ReadOnly = True
                Me.txtDivision.ReadOnly = True
                Me.txtProduct.ReadOnly = True
                Me.txtCampaign.ReadOnly = True
                Me.txtJob.ReadOnly = True
                Me.txtComponent.ReadOnly = True

                Me.ShowRow(Me.TrClient, True)

                If Me.IsClientPortal = True Then

                    Me.txtClient.Text = Session("CL_CODE")
                    Me.txtClient.ReadOnly = True
                    Me.ChkIsAlertAssignment.Visible = False
                    Me.hlClient.Attributes.Remove("onClick")
                    Me.hlClient.Attributes.Remove("href")
                    Me.hlClient.NavigateUrl = Nothing
                    Me.hlClient.Enabled = False

                    If Me.AlertLevel = "JR" Then

                        SetJobRequestCDP()

                    End If

                End If

            Case "DI"

                ClientRequiredFieldValidator.Enabled = True
                DivisionRequiredFieldValidator.Enabled = True

                Me.txtClient.CssClass = "RequiredInput"
                Me.FocusControl(Me.txtClient)
                Me.txtDivision.CssClass = "RequiredInput"

                Me.txtOffice.Text = ""
                Me.txtProduct.Text = ""
                Me.txtCampaign.Text = ""
                Me.txtJob.Text = ""
                Me.txtComponent.Text = ""

                Me.txtOffice.ReadOnly = True
                Me.txtProduct.ReadOnly = True
                Me.txtCampaign.ReadOnly = True
                Me.txtJob.ReadOnly = True
                Me.txtComponent.ReadOnly = True

                Me.ShowRow(Me.TrClient, True)
                Me.ShowRow(Me.TrDivision, True)

                If Me.AlertLevel = "JR" Then

                    SetJobRequestCDP()

                End If

                AdvantageFramework.Web.Presentation.Controls.ClearTextBoxesCascadeDown({Me.txtDivision, Me.txtClient})

            Case "PR"

                ClientRequiredFieldValidator.Enabled = True
                DivisionRequiredFieldValidator.Enabled = True
                ProductRequiredFieldValidator.Enabled = True

                Me.txtClient.CssClass = "RequiredInput"
                Me.FocusControl(Me.txtClient)
                Me.txtDivision.CssClass = "RequiredInput"
                Me.txtProduct.CssClass = "RequiredInput"

                Me.txtOffice.Text = ""
                Me.txtCampaign.Text = ""
                Me.txtJob.Text = ""
                Me.txtComponent.Text = ""

                Me.txtOffice.ReadOnly = True
                Me.txtCampaign.ReadOnly = True
                Me.txtJob.ReadOnly = True
                Me.txtComponent.ReadOnly = True

                Me.ShowRow(Me.TrClient, True)
                Me.ShowRow(Me.TrDivision, True)
                Me.ShowRow(Me.TrProduct, True)

                If Me.AlertLevel = "JR" Then

                    SetJobRequestCDP()

                End If

                AdvantageFramework.Web.Presentation.Controls.ClearTextBoxesCascadeDown({Me.txtProduct, Me.txtDivision, Me.txtClient})

            Case "CM"

                CampaignRequiredFieldValidator.Enabled = True

                Me.txtClient.CssClass = "RequiredInput"
                Me.FocusControl(Me.txtClient)
                Me.txtCampaign.CssClass = "RequiredInput"

                Me.txtOffice.Text = ""
                Me.txtJob.Text = ""
                Me.txtComponent.Text = ""

                Me.txtOffice.ReadOnly = True
                Me.txtJob.ReadOnly = True
                Me.txtComponent.ReadOnly = True

                Me.ShowRow(Me.TrClient, True)
                Me.ShowRow(Me.TrDivision, True)
                Me.ShowRow(Me.TrProduct, True)
                Me.ShowRow(Me.TrCampaign, True)

                With Me.RadioNotifyAlertGroup

                    .Visible = True
                    .Checked = False

                End With

                Me.RadioNotifyEmployeesTask.Visible = False
                Me.RadioNotifyEmployeesAssigned.Visible = False
                Me.RadioNotifyNext.Visible = False

            Case "JO"

                JobRequiredFieldValidator.Enabled = True

                Me.txtJob.CssClass = "RequiredInput"
                Me.FocusControl(Me.txtJob)

                Me.txtCampaign.Text = ""
                Me.txtComponent.Text = ""

                Me.ShowRow(Me.TrOffice, True)
                Me.ShowRow(Me.TrClient, True)
                Me.ShowRow(Me.TrDivision, True)
                Me.ShowRow(Me.TrProduct, True)
                Me.ShowRow(Me.TrJob, True)

                Me.DivRepositoryAndProofHQCheckBoxes.Visible = True
                CheckBoxUploadToProofHQ.Visible = (IsProofHQEnabled AndAlso Me.IsClientPortal = False)

                Me.AlertLevel = "JO"

                AdvantageFramework.Web.Presentation.Controls.ClearTextBoxesCascadeDown({Me.txtJob, Me.txtProduct, Me.txtDivision, Me.txtClient})

            Case "JC", "JJ"

                ComponentRequiredFieldValidator.Enabled = True

                Me.txtJob.CssClass = "RequiredInput"
                Me.FocusControl(Me.txtJob)
                Me.txtComponent.CssClass = "RequiredInput"

                Me.txtCampaign.Text = ""

                If Me.App = Source_App.JobJacket Or Me.App = Source_App.JobJacketAlerts And Me.RadComboBoxAlertLevel.Enabled = False Then

                    Me.hlJob.Attributes.Remove("onclick")
                    Me.hlComponent.Attributes.Remove("onclick")
                    Me.txtJob.ReadOnly = True
                    Me.txtComponent.ReadOnly = True

                Else

                    Me.ShowRow(Me.TrClient, True)
                    Me.ShowRow(Me.TrDivision, True)
                    Me.ShowRow(Me.TrProduct, True)

                End If

                Me.ShowRow(Me.TrJob, True)
                Me.ShowRow(Me.TrComponent, True)
                Me.ShowRow(Me.TrEstimateNumber, False)
                Me.ShowRow(Me.TrEstimateComponentNbr, False)

                If Me.IsClientPortal = True Then

                    Me.txtClient.Text = Session("CL_CODE")
                    Me.ImageButtonContacts.Visible = False
                    Me.ChkIsAlertAssignment.Visible = False
                    Me.txtClient.ReadOnly = True
                    Me.hlClient.Attributes.Remove("onClick")
                    Me.hlClient.Attributes.Remove("href")
                    Me.hlClient.NavigateUrl = Nothing
                    Me.hlClient.Enabled = False

                Else

                    AdvantageFramework.Web.Presentation.Controls.ClearTextBoxesCascadeDown({Me.txtComponent, Me.txtJob, Me.txtProduct, Me.txtDivision, Me.txtClient})

                End If

                Me.AlertLevel = "JC"

            Case "PST", "PS"

                Me.txtOffice.Text = ""
                Me.txtClient.Text = ""
                Me.txtDivision.Text = ""
                Me.txtProduct.Text = ""
                Me.txtCampaign.Text = ""

                Me.txtOffice.ReadOnly = True
                Me.txtClient.ReadOnly = True
                Me.txtDivision.ReadOnly = True
                Me.txtProduct.ReadOnly = True
                Me.txtCampaign.ReadOnly = True
                Me.txtJob.ReadOnly = True
                Me.txtComponent.ReadOnly = True

                Me.ShowRow(Me.TrJob, True)
                Me.ShowRow(Me.TrComponent, True)

            Case "ES"

                Me.TxtEstimateNumber.CssClass = "RequiredInput"
                Me.FocusControl(Me.TxtEstimateNumber)

                Me.txtOffice.Text = ""
                Me.txtClient.Text = ""
                Me.txtDivision.Text = ""
                Me.txtProduct.Text = ""
                Me.txtCampaign.Text = ""
                Me.txtJob.Text = ""
                Me.txtComponent.Text = ""

                Me.DivRepositoryAndProofHQCheckBoxes.Visible = True

                Me.ShowRow(Me.TrEstimateNumber, True)

            Case "EST"

                Me.TxtEstimateNumber.CssClass = "RequiredInput"
                Me.FocusControl(Me.TxtEstimateNumber)
                Me.TxtEstimateComponentNbr.CssClass = "RequiredInput"

                Me.txtOffice.Text = ""
                Me.txtClient.Text = ""
                Me.txtDivision.Text = ""
                Me.txtProduct.Text = ""
                Me.txtCampaign.Text = ""
                Me.txtJob.Text = ""
                Me.txtComponent.Text = ""

                Me.DivRepositoryAndProofHQCheckBoxes.Visible = True

                Me.ShowRow(Me.TrEstimateNumber, True)
                Me.ShowRow(Me.TrEstimateComponentNbr, True)

            Case "PO"

                Me.txtOffice.Text = ""
                Me.txtClient.Text = ""
                Me.txtDivision.Text = ""
                Me.txtProduct.Text = ""
                Me.txtCampaign.Text = ""
                Me.txtJob.Text = ""
                Me.txtComponent.Text = ""

                Me.ShowRow(Me.TrPurchaseOrder, True)

            Case "AB"

                MediaATBRequiredFieldValidator.Enabled = True
                MediaATBRevRequiredFieldValidator.Enabled = True

                Me.txtClient.Text = ""
                Me.txtDivision.Text = ""
                Me.txtProduct.Text = ""

                Me.ShowRow(Me.TrClient, True)
                Me.ShowRow(Me.TrDivision, True)
                Me.ShowRow(Me.TrProduct, True)
                Me.ShowRow(Me.TrMediaATB, True)
                Me.ShowRow(Me.TrMediaATBRev, True)

        End Select

        If Me.CheckUserGroupSetting(AdvantageFramework.Security.GroupSettings.DocumentManager_CanUpload) = 0 Then

            Me.DivRepositoryAndProofHQCheckBoxes.Visible = False
            Me.ChkUploadToRepository.Checked = False

        Else

            'If Me.AlertLevel = "JO" OrElse Me.AlertLevel = "JC" OrElse Me.AlertLevel = "JJ" OrElse
            '     Me.AlertLevel = "PS" OrElse Me.AlertLevel = "PST" OrElse
            '     Me.AlertLevel = "ES" OrElse Me.AlertLevel = "EST" Then

            Me.DivRepositoryAndProofHQCheckBoxes.Visible = True
            Me.CheckBoxUploadToProofHQ.Visible = (IsProofHQEnabled AndAlso Me.IsClientPortal = False)

            'Else

            '    Me.DivRepositoryAndProofHQCheckBoxes.Visible = False

            'End If

        End If

    End Sub
    Private Sub HideAlertFields(ByVal HideIt As Boolean)
        Me.LblCategory.Visible = Not HideIt
        Me.RadComboBoxCategory.Visible = Not HideIt
        Me.LblDueDate.Visible = Not HideIt
        Me.RadDatePickerDueDate.Visible = Not HideIt
        Me.LblTimeDue.Visible = Not HideIt
        Me.TxtTimeDue.Visible = Not HideIt
        Me.FsAlertLevel.Visible = Not HideIt
    End Sub
    Private Sub SetAlertLevelPanels()

        If Me.RadComboBoxAlertLevel.SelectedIndex = 0 Then

            Me.FsAllowEmail.Visible = False
            Me.FsEmailRecipients.Visible = False
            'Me.FsAlertRecipients.Visible = False
            'Me.FsAlertAssignments.Visible = False
            Me.ChkIsAlertAssignment.Visible = False

        Else

            Me.SetEmailOrAlert()

        End If

    End Sub
    Private Function HasAlertAssignment(Optional ValidateEmployee As Boolean = True) As Boolean

        If Me.RadComboBoxAlertAssignmentTemplate.SelectedIndex = 0 Then
            'did not select a template
            Me.HasNotifyAssignment = False
            Me.ShowMessage("Please select a Workflow Template")
            Return False

        End If
        Try

            If Me.RadTreeViewStates.Nodes.Count > 0 Then

                Try

                    If Me.RadTreeViewStates.SelectedNode Is Nothing Then

                        'did not select a state
                        Me.HasNotifyAssignment = False
                        Me.ShowMessage("Please select a State")
                        Return False

                    End If
                    If Me.RadTreeViewStates.SelectedNode.Index = Nothing Then

                        If Me.RadTreeViewStates.SelectedNode.Index < 0 Then
                            'did not select a state
                            Me.HasNotifyAssignment = False
                            Me.ShowMessage("Please select a State")
                            Return False

                        End If

                    End If
                Catch ex As Exception

                    'did not select a state
                    Me.HasNotifyAssignment = False
                    Me.ShowMessage("Please select a State")
                    Return False

                End Try
            Else

                'no states
                Me.HasNotifyAssignment = False
                Me.ShowMessage("This Workflow Template does not have any States")
                Return False

            End If
        Catch ex As Exception
            Return False
        End Try

        If ValidateEmployee = True Then

            If Me.RadComboBoxAssignTo.Enabled = False Then

                Me.HasNotifyAssignment = False
                Me.ShowMessage("Assign To selection is disabled")
                Return False

            End If
            If Me.RadComboBoxAssignTo.Items.Count > 0 Then

                If Me.RadComboBoxAssignTo.SelectedIndex = 0 Then

                    'did not select emp
                    Me.HasNotifyAssignment = False
                    Me.ShowMessage("Please select an Assign To employee")
                    Return False

                End If

            Else

                'no employee
                Me.HasNotifyAssignment = False
                Me.ShowMessage("This State does not have any employees")
                Return False
            End If

        End If

        Me.HasNotifyAssignment = True
        Return True

    End Function
    Private Function IsAlertAssignment() As Boolean
        Try
            'Dim ReturnValue As Boolean = False
            'If Me.ChkIsAlertAssignment.Checked Then
            '    If Me.RadTreeViewStates.SelectedNode.Index > 0 Then
            '        If Me.RadComboBoxAssignTo.SelectedIndex > 0 Then
            '            ReturnValue = True
            '        End If
            '    End If
            'End If
            'Return ReturnValue
            Return Me.ChkIsAlertAssignment.Checked
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Sub ShowRow(ByRef TableRow As System.Web.UI.HtmlControls.HtmlTableRow, ByVal ShowIt As Boolean)
        With TableRow
            .Attributes.Remove("style")
            If ShowIt = False Then
                .Attributes.Add("style", "display:none;")
            End If
        End With
    End Sub
    Private Sub SetRadioNotify()
        Me.RadioNotifyAlertGroup.Checked = False
        Me.RadioNotifyEmployeesTask.Checked = False
        Me.RadioNotifyEmployeesAssigned.Checked = False
        Me.RadioNotifyNext.Checked = False

        Select Case Me.AlertLevel
            Case "JJ", "CM", "JC"
                Me.TrRadioNotify.Visible = True
                Me.RadioNotifyAlertGroup.Visible = True
                Me.RadioNotifyEmployeesTask.Visible = False
                Me.RadioNotifyEmployeesAssigned.Visible = False
                Me.RadioNotifyNext.Visible = False
                'Case "PS"
                '    Me.TrRadioNotify.Visible = True
                '    Me.RadioNotifyAlertGroup.Visible = True
                '    Me.RadioNotifyEmployeesTask.Visible = False
                '    Me.RadioNotifyEmployeesAssigned.Visible = True
                '    Me.RadioNotifyNext.Visible = True
            Case "PST", "PS"
                Me.TrRadioNotify.Visible = True
                Me.RadioNotifyAlertGroup.Visible = True
                Me.RadioNotifyEmployeesTask.Visible = True
                Me.RadioNotifyEmployeesAssigned.Visible = True
                Me.RadioNotifyNext.Visible = True
            Case "EST", "ES"
                If Me.JobNumber > 0 And Me.JobComponentNbr > 0 Then
                    Me.TrRadioNotify.Visible = True
                    Me.RadioNotifyAlertGroup.Visible = True
                    Me.RadioNotifyEmployeesTask.Visible = False
                    Me.RadioNotifyEmployeesAssigned.Visible = False
                    Me.RadioNotifyNext.Visible = False
                Else
                    Me.TrRadioNotify.Visible = False
                End If
            Case Else
                Me.TrRadioNotify.Visible = False
        End Select

    End Sub
    Private Function PageType() As String
        Try
            If Not Request.QueryString("pagetype") Is Nothing Then
                Return Request.QueryString("pagetype").ToString().Trim()
            End If
            If Not Session("pagetype") Is Nothing Then
                Return Session("pagetype").ToString().Trim()
            End If
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Private Sub SetAlertOrAssignment()

        Me.FsAlertAssignments.Visible = Me.ChkIsAlertAssignment.Checked
        'TEST: Me.FsAlertRecipients.Visible = Not Me.ChkIsAlertAssignment.Checked

        If Me.ChkIsAlertAssignment.Checked = True Then
            Try
                If Me.RadComboBoxPriority.Items.Count > 0 Then
                    Me.RadComboBoxPriority.FindItemByValue("3").Selected = True
                End If
            Catch ex As Exception
            End Try
            '''Me.TxtRecipients.Value = ""
            Me.RadioNotifyAlertGroup.Checked = False
            Me.RadioNotifyEmployeesAssigned.Checked = False
            Me.RadioNotifyEmployeesTask.Checked = False
            Me.RadioNotifyNext.Checked = False
            '''Me.TxtRecipients.Value = ""
            Try
                If Me.RadComboBoxAlertAssignmentTemplate.Items.Count > 0 Then
                    Me.RadComboBoxAlertAssignmentTemplate.SelectedIndex = 0
                End If
            Catch ex As Exception
            End Try
            Try
                Me.RadTreeViewStates.Nodes.Clear()
            Catch ex As Exception
            End Try
            Try
                If Me.RadComboBoxAssignTo.Items.Count = 0 Then
                    Me.RadComboBoxAssignTo.SelectedIndex = 0
                End If
                Me.RadComboBoxAssignTo.Enabled = False
            Catch ex As Exception
            End Try

            Me.PreSetAlertAssignment()

        Else
            If Me.RadComboBoxAlertAssignmentTemplate.Items.Count > 0 Then
                Me.RadComboBoxAlertAssignmentTemplate.SelectedIndex = 0
            End If
            Me.RadTreeViewStates.Nodes.Clear()
            If Me.RadComboBoxAssignTo.Items.Count > 0 Then
                Me.RadComboBoxAssignTo.SelectedIndex = 0
            End If
            Select Case Me.App
                Case Source_App.ProjectSchedule, Source_App.ProjectSchedule_Alerts
                    Me.SetProjectScheduleDefault(True)
                Case Source_App.Campaign
                    Me.SetCampaignDefault(True)
                Case Source_App.Estimate
                    Me.SetEstimateDefault(True)
                Case Source_App.EstimateComponent
                    Me.SetEstimateComponentDefault(True)
            End Select

        End If

    End Sub
    Private Sub OpenEmailRecipientsWindow(ByVal RefId As Integer)

        Dim qs As New AdvantageFramework.Web.QueryString()
        With qs

            .Page = "LookUp_EmailRecipients.aspx"
            .Add("to", Me.TxtEmailTo.Text)
            .Add("cc", Me.TxtEmailCC.Text)
            .Add("bcc", Me.TxtEmailBCC.Text)
            .Add("fna", "1")
            .Add("ref_id", RefId)
            .Add("opener", Me.PageFilename())
            .JobNumber = Me.JobNumber
            .JobComponentNumber = Me.JobComponentNbr

        End With

        Me.OpenLookUp(qs.ToString(True))

    End Sub
    Private Sub GoBack()

        If Request.QueryString("content") IsNot Nothing AndAlso Request.QueryString("content") = "1" Then

            Me.RefreshAlertWindows(True, True, False, True, True, True)

        Else

            Me.RefreshAlertWindows()

        End If

    End Sub

#End Region
#Region " Brought over from popsend "

#Region "Output Report Functions"

    Private Function OutputReportFilePS() As String
        Try
            Dim StrFilePrefix As String = Request.PhysicalApplicationPath & "TEMP\"
            Dim StrFileName As String = ""
            Dim r As cReports = New cReports(Session("ConnString"))
            Dim StrFileType As String = ".pdf"
            StrFileName = "Project_Schedule_" & Me.JobNumber.ToString() & "_" & Me.JobComponentNbr.ToString() & AdvantageFramework.StringUtilities.GUID_Date(True, True, True) & StrFileType

            Dim rpt As New popReportViewer
            Try
                Dim ThisOptions As String = Me.JobNumber.ToString() & "|" & Me.JobComponentNbr.ToString() & "|" & Request.QueryString("hours") & "|" & Request.QueryString("ms") & "|" & Request.QueryString("due") & "|" & Request.QueryString("sort") & "|" & Request.QueryString("completed")
                If Request.QueryString("rpt") = "duedate" Then
                    rpt.renderDoc(StrFilePrefix & StrFileName, "TrafficDetailByJobDueDate", "", "", "", "", "", 1, "", ThisOptions)
                Else
                    rpt.renderDoc(StrFilePrefix & StrFileName, "TrafficDetailByJob", "", "", "", "", "", 1, "", ThisOptions)
                End If
            Catch ex As Exception
                Return ""
            End Try

            Return StrFilePrefix & StrFileName
        Catch ex As Exception
            Me.ShowMessage(MiscFN.JavascriptSafe(ex.Message.ToString()))
            Return ""
        End Try
    End Function
    Private Function OutputReportFileJT() As String
        Try
            Dim sb1 As New System.Text.StringBuilder 'build filename
            Dim sbReportName As New System.Text.StringBuilder

            sb1.Append(Request.PhysicalApplicationPath.Trim())
            sb1.Append("TEMP\")

            sb1.Append("JobOrder_")
            If Me.JobNumber > 0 Then sb1.Append(Me.JobNumber)
            If Me.JobComponentNbr > 0 Then

                sb1.Append("_")
                sb1.Append(Me.JobComponentNbr)

            End If
            sb1.Append(AdvantageFramework.StringUtilities.GUID_Date(True, True, True))

            sbReportName.Append(Request.QueryString("Report"))

            Dim rpt As New popReportViewer

            Dim imgPath As String = Request.PhysicalApplicationPath & "Images\logo_print.gif"
            rpt.renderDoc(sb1.ToString(), sbReportName.ToString(), "", "", "", "", "", Me.FileType, imgPath)
            Dim str As String = sb1.ToString()
            If str.IndexOf(".pdf") = -1 Then
                str &= ".pdf"
            End If
            Return str
        Catch ex As Exception
            Me.ShowMessage(MiscFN.JavascriptSafe(ex.Message.ToString()))
            Return ""
        End Try
    End Function
    Private Function OutputReportFileJS() As String
        Try
            Dim sb1 As New System.Text.StringBuilder 'build filename
            Dim sbTime As New System.Text.StringBuilder 'unique timestamp for filename..
            Dim sbReportName As New System.Text.StringBuilder

            sbTime.Append(Now.Year.ToString)
            sbTime.Append(Now.Month.ToString)
            sbTime.Append(Now.Day.ToString)

            sb1.Append(Request.PhysicalApplicationPath.Trim())
            sb1.Append("TEMP\")


            sb1.Append("Specification_")
            sb1.Append(Session("JSReportJobNum"))
            sb1.Append("_")
            sb1.Append(Session("JSReportJobCompNum"))
            sb1.Append(AdvantageFramework.StringUtilities.GUID_Date(True, True, True))

            sbReportName.Append("jobspec")

            Dim rpt As New popReportViewer

            Dim imgPath As String = Request.PhysicalApplicationPath & "Images\logo_print.gif"
            rpt.renderDoc(sb1.ToString(), sbReportName.ToString(), "", "", "", "", "", Me.FileType, imgPath)
            Dim str As String = sb1.ToString()
            If str.IndexOf(".pdf") = -1 Then
                str &= ".pdf"
            End If
            Return str
        Catch ex As Exception
            Me.ShowMessage(MiscFN.JavascriptSafe(ex.Message.ToString()))
            Return ""
        End Try
    End Function
    Private Function OutputReportFileJSAllVers() As String
        Try
            Dim sb1 As New System.Text.StringBuilder 'build filename
            Dim sbReportName As New System.Text.StringBuilder

            sb1.Append(Request.PhysicalApplicationPath.Trim())
            sb1.Append("TEMP\")

            sb1.Append("Specification_")
            sb1.Append(Session("JobOrderFormJobNum"))
            sb1.Append("_")
            sb1.Append(Session("JobOrderFormJobCompNum"))
            sb1.Append(AdvantageFramework.StringUtilities.GUID_Date(True, True, True))


            sbReportName.Append("jobspecs")

            Dim rpt As New popReportViewer
            Dim imgPath As String = Request.PhysicalApplicationPath & "Images\logo_print.gif"
            rpt.renderDoc(sb1.ToString(), sbReportName.ToString(), "", "", "", "", "", Me.FileType, imgPath)
            Dim str As String = sb1.ToString()
            If str.IndexOf(".pdf") = -1 Then
                str &= ".pdf"
            End If
            Return str
        Catch ex As Exception
            Me.ShowMessage(MiscFN.JavascriptSafe(ex.Message.ToString()))
            Return ""
        End Try
    End Function
    Private Function OutputReportFileJV() As String
        Try
            Dim sb1 As New System.Text.StringBuilder 'build filename
            Dim sbTime As New System.Text.StringBuilder 'unique timestamp for filename..
            Dim sbReportName As New System.Text.StringBuilder
            Dim MyJV As JobVersion = New JobVersion(Session("ConnString"))
            Dim desc As String

            desc = MyJV.GetAgencyDesc()

            sbTime.Append(Now.Year.ToString)
            sbTime.Append(Now.Month.ToString)
            sbTime.Append(Now.Day.ToString)

            sb1.Append(Request.PhysicalApplicationPath.Trim())
            sb1.Append("TEMP\")

            sb1.Append(Session("JVTemplateName").ToString.Replace("\", "").Replace("/", "") & "_")
            sb1.Append(Session("JVReportVersion"))
            sb1.Append("_")
            sb1.Append(Session("JVReportJobNum"))
            sb1.Append("_")
            sb1.Append(Session("JVReportJobCompNum"))
            sb1.Append(AdvantageFramework.StringUtilities.GUID_Date(True, True, True))

            sbReportName.Append("jobver")

            Dim rpt As New popReportViewer

            If Session("JVOutputFormat") Is Nothing Then
                Me.FileType = 1
            Else
                Me.FileType = CInt(Session("JVOutputFormat"))
            End If

            Dim imgPath As String = Request.PhysicalApplicationPath & "Images\logo_print.gif"
            rpt.renderDoc(sb1.ToString(), sbReportName.ToString(), "", "", "", "", "", Me.FileType, imgPath)
            Dim str As String = sb1.ToString()
            If str.IndexOf(".pdf") = -1 And Me.FileType = 1 Then
                str &= ".pdf"
            ElseIf str.IndexOf(".xls") = -1 And Me.FileType = 2 Then
                str &= ".xls"
            ElseIf str.IndexOf(".txt") = -1 And Me.FileType = 4 Then
                str &= ".txt"
            ElseIf str.IndexOf(".rtf") = -1 And Me.FileType = 5 Then
                str &= ".rtf"
            End If
            Return str
        Catch ex As Exception
            Me.ShowMessage(MiscFN.JavascriptSafe(ex.Message.ToString()))
            Return ""
        End Try
    End Function
    Private Function OutputReportFileJVAllVers() As String
        Try
            Dim sb1 As New System.Text.StringBuilder 'build filename
            Dim sbReportName As New System.Text.StringBuilder

            sb1.Append(Request.PhysicalApplicationPath.Trim())
            sb1.Append("TEMP\")

            sb1.Append(Session("JVReportTitle").ToString.Replace("\", "").Replace("/", "") & "_")
            sb1.Append(Session("JobOrderFormJobNum"))
            sb1.Append("_")
            sb1.Append(Session("JobOrderFormJobCompNum"))
            sb1.Append(AdvantageFramework.StringUtilities.GUID_Date(True, True, True))

            sbReportName.Append("jobversions")

            Dim rpt As New popReportViewer

            Dim imgPath As String = Request.PhysicalApplicationPath & "Images\logo_print.gif"
            rpt.renderDoc(sb1.ToString(), sbReportName.ToString(), "", "", "", "", "", Me.FileType, imgPath)
            Dim str As String = sb1.ToString()
            If str.IndexOf(".pdf") = -1 Then
                str &= ".pdf"
            End If
            Return str
        Catch ex As Exception
            Me.ShowMessage(MiscFN.JavascriptSafe(ex.Message.ToString()))
            Return ""
        End Try

    End Function
    Private Function OutputReportFileCB() As String
        Try
            Dim sb1 As New System.Text.StringBuilder 'build filename
            Dim sbReportName As New System.Text.StringBuilder

            If Me.JobNumber > 0 Then
                Session("CBReportJobNum") = Me.JobNumber.ToString.PadLeft(6, "0")
                Session("JobOrderFormJobNum") = Me.JobNumber.ToString.PadLeft(6, "0")
            End If
            If Me.JobComponentNbr > 0 Then
                Session("CBReportJobCompNum") = Me.JobComponentNbr.ToString.PadLeft(3, "0")
                Session("JobOrderFormJobCompNum") = Me.JobComponentNbr.ToString.PadLeft(3, "0")
            End If
            sb1.Append(Request.PhysicalApplicationPath.Trim())
            sb1.Append("TEMP\")

            sb1.Append("CreativeBrief_")
            If Session("pagetype") = "cb" Then
                sb1.Append(Session("CBReportJobNum"))
                sb1.Append("_")
                sb1.Append(Session("CBReportJobCompNum"))
            Else
                sb1.Append(Session("JobOrderFormJobNum"))
                sb1.Append("_")
                sb1.Append(Session("JobOrderFormJobCompNum"))
            End If

            sb1.Append(AdvantageFramework.StringUtilities.GUID_Date(True, True, True))

            sbReportName.Append("CreativeBrief")

            Dim rpt As New popReportViewer

            Dim imgPath As String = Request.PhysicalApplicationPath & "Images\logo_print.gif"
            rpt.renderDoc(sb1.ToString(), sbReportName.ToString(), "", "", "", "", "", Me.FileType, imgPath)
            Dim str As String = sb1.ToString()
            If str.IndexOf(".pdf") = -1 Then
                str &= ".pdf"
            End If
            Return str
        Catch ex As Exception
            Me.ShowMessage(MiscFN.JavascriptSafe(ex.Message.ToString()))
            Return ""
        End Try
    End Function
    Private Function OutputReportFileATB() As String

        Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
        Dim DataSource As Generic.List(Of AdvantageFramework.Database.Entities.MediaATBRevision) = Nothing
        Dim MediaATBRevision As AdvantageFramework.Database.Entities.MediaATBRevision = Nothing
        Dim FileName As String = Nothing
        Dim XtraReport As DevExpress.XtraReports.UI.XtraReport = Nothing
        Dim FilePrefix As String = ""
        Dim ReportType As AdvantageFramework.Reporting.ReportTypes = Nothing
        Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing
        Dim MemoryStream As System.IO.MemoryStream = Nothing

        Try

            FilePrefix = Request.PhysicalApplicationPath.Trim() & "TEMP\"

            If Me.ATBNumber > 0 AndAlso Me.ATBRevisionNumber > -1 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    MediaATBRevision = AdvantageFramework.Database.Procedures.MediaATBRevision.LoadByATBNumberAndRevisionNumber(DbContext, Me.ATBNumber, Me.ATBRevisionNumber)

                    If MediaATBRevision IsNot Nothing Then

                        ParameterDictionary = New Generic.Dictionary(Of String, Object)

                        DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.MediaATBRevision)

                        DataSource.Add(MediaATBRevision)

                        ParameterDictionary("DataSource") = DataSource

                        Try

                            AppVar = (From Entity In AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationName(DbContext, _Session.UserCode, "ATBPrint")
                                      Where Entity.Name = "DefaultReportType"
                                      Select Entity).SingleOrDefault

                        Catch ex As Exception
                            AppVar = Nothing
                        End Try

                        ReportType = AdvantageFramework.Reporting.ReportTypes.AuthorizationToBuyDigitalMedia

                        If AppVar IsNot Nothing Then

                            If AppVar.Value = "Report" Then

                                ReportType = AdvantageFramework.Reporting.ReportTypes.AuthorizationToBuyDigitalMedia

                            ElseIf AppVar.Value = "Form" Then

                                ReportType = AdvantageFramework.Reporting.ReportTypes.AuthorizationToBuyDigitalMediaForm

                            End If

                        End If

                        XtraReport = AdvantageFramework.Reporting.Reports.CreateReport(_Session, ReportType, ParameterDictionary, Nothing, Nothing, Nothing, Nothing)

                        If XtraReport IsNot Nothing Then

                            MemoryStream = New System.IO.MemoryStream

                            FileName = FilePrefix

                            FileName &= "ATB_" & AdvantageFramework.StringUtilities.PadWithCharacter(MediaATBRevision.ATBNumber.ToString, 6, "0", True) & "_" &
                                AdvantageFramework.StringUtilities.PadWithCharacter(MediaATBRevision.RevisionNumber.ToString, 3, "0", True) & "_" & cEmployee.TimeZoneToday.ToString("yyyyMd") & ".PDF"

                            XtraReport.CreateDocument()

                            XtraReport.ExportToPdf(MemoryStream)

                            Using FileStream = New System.IO.FileStream(FileName, FileMode.Create, FileAccess.ReadWrite)

                                MemoryStream.WriteTo(FileStream)

                            End Using

                        End If

                    End If

                End Using

            End If

        Catch ex As Exception
            Me.ShowMessage(MiscFN.JavascriptSafe(ex.Message.ToString()))
            FileName = ""
        End Try

        OutputReportFileATB = FileName

    End Function
    Private Function OutputReportFileCMP() As String
        Try
            Dim ThisCmpIdentifier As Integer = 0
            Try
                If Not Request.QueryString("CmpCode") Is Nothing Then
                    ThisCmpIdentifier = CType(Request.QueryString("CmpCode"), Integer)
                End If
            Catch ex As Exception
                ThisCmpIdentifier = 0
            End Try
            If ThisCmpIdentifier = 0 Then
                Try
                    If Not Request.QueryString("cmp") Is Nothing Then
                        ThisCmpIdentifier = CType(Request.QueryString("cmp"), Integer)
                    End If
                Catch ex As Exception
                    ThisCmpIdentifier = 0
                End Try
            End If
            If ThisCmpIdentifier > 0 Then
                Dim sb1 As New System.Text.StringBuilder 'build filename
                Dim sbReportName As New System.Text.StringBuilder
                Dim cCMP As New cCampaign(Session("ConnString"), ThisCmpIdentifier)

                sb1.Append(Request.PhysicalApplicationPath.Trim())
                sb1.Append("TEMP\")

                sb1.Append("Campaign_")
                sb1.Append(cCMP.CMP_CODE)
                sb1.Append(AdvantageFramework.StringUtilities.GUID_Date(True, True, True))

                sbReportName.Append("Campaign")

                Dim rpt As New popReportViewer

                Try
                    Dim imgPath As String = Request.PhysicalApplicationPath & "Images\logo_print.gif"
                    rpt.renderDoc(sb1.ToString(), sbReportName.ToString(), ThisCmpIdentifier, "", "", "", "", Me.FileType, imgPath)
                    Dim str As String = sb1.ToString()
                    If str.IndexOf(".pdf") = -1 Then
                        str &= ".pdf"
                    End If
                    Return str
                Catch ex As Exception
                    Return ""
                End Try
            End If
        Catch ex As Exception
            Me.ShowMessage(MiscFN.JavascriptSafe(ex.Message.ToString()))
            Return ""
        End Try
    End Function
    Private Function OutputReportFileEST(Optional ByVal comp As Integer = 0, Optional ByVal quotes As String = "") As String
        Try
            Dim sb1 As New System.Text.StringBuilder 'build filename
            Dim sbReportName As New System.Text.StringBuilder
            Dim EstimateQuote As AdvantageFramework.Estimate.Printing.Classes.EstimateQuote = Nothing
            Dim EstimateQuotes As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote) = Nothing
            Dim EstimateFormat As AdvantageFramework.Estimate.Printing.ReportFormats = AdvantageFramework.Estimate.Printing.ReportFormats.OneQuotePerPage
            Dim EstimatePrintingSettings As AdvantageFramework.Database.Entities.EstimatePrintingSetting = Nothing
            Dim EstimatePrintingSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting = Nothing
            Dim EstimatePrintSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintSetting = Nothing
            Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim DefaultFileName As String
            Dim Files As Generic.List(Of String) = Nothing
            Dim CurrentCultureCode As String = LoGlo.UserCultureGet()

            Dim estType As String = ""

            If Request.QueryString("settingType") <> "" Then
                'For Each EstimateQuote In EstimateQuotes

                estType = Request.QueryString("settingType")
                Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserID"))
                    Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                        EstimateQuotes = DbContext.Database.SqlQuery(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote)(String.Format("EXEC [dbo].[advsp_estimate_printing_quotes] {0}, {1}", Request.QueryString("e"), Request.QueryString("ec"))).ToList
                        EstimateQuote = EstimateQuotes(0)
                        EstimatePrintingSetting = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettingsWebvantage(DbContext, DataContext, estType, EstimateQuote.ClientCode, EstimateQuote.CDP, _Session.UserCode).FirstOrDefault()

                        'EstimatePrintingSetting = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettings(DbContext, False, AdvantageFramework.Estimate.Printing.EstimateFormatTypes.ClientDefault).FirstOrDefault
                        'EstimatePrintSetting = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettingsWV(DbContext, False, Session("UserCode")).FirstOrDefault
                    End Using
                End Using



                If Request.QueryString("combine") = "1" Then
                    'Report = AdvantageFramework.Reporting.Reports.CreateEstimateWV(Me._Session, EstimateQuote, Nothing, Request.QueryString("e"), Request.QueryString("ec"), Request.QueryString("comps"), Request.QueryString("quotes"), EstimatePrintSetting, Session("EstimatingPrintedDate"), CurrentCultureCode, Request.QueryString("Report"), Session("EstimatingQteDescs"), 1)
                    Report = AdvantageFramework.Reporting.Reports.CreateEstimate(Me._Session, EstimateQuote, EstimatePrintingSetting, Nothing, Request.QueryString("comps"), Request.QueryString("quotes"), Session("EstimatingQteDescs"), 2, Nothing, CurrentCultureCode)
                Else
                    'Report = AdvantageFramework.Reporting.Reports.CreateEstimateWV(Me._Session, EstimateQuote, Nothing, Request.QueryString("e"), Request.QueryString("ec"), Request.QueryString("comps"), quotes, EstimatePrintSetting, Session("EstimatingPrintedDate"), CurrentCultureCode, Request.QueryString("Report"), Session("EstimatingQteDescs" & Request.QueryString("ec")), 0)
                    Report = AdvantageFramework.Reporting.Reports.CreateEstimate(Me._Session, EstimateQuote, EstimatePrintingSetting, Nothing, Request.QueryString("comps"), Request.QueryString("quotes"), Session("EstimatingQteDescs" & Request.QueryString("ec")), 0, Nothing, CurrentCultureCode)
                End If

                If Report IsNot Nothing Then

                    DefaultFileName = "Estimate_" & Format(EstimateQuote.EstimateNumber, "000000#") & "_" & AdvantageFramework.StringUtilities.GUID_Date(True, True, True) ' & "_" & Format(EstimateQuote.QuoteNumber, "00#")

                    Report.PrintingSystem.ExportOptions.PrintPreview.DefaultFileName = DefaultFileName
                    Report.PrintingSystem.ExportOptions.PrintPreview.DefaultDirectory = Request.PhysicalApplicationPath.Trim() & "TEMP\"
                    Report.PrintingSystem.ExportOptions.PrintPreview.SaveMode = DevExpress.XtraPrinting.SaveMode.UsingDefaultPath
                    Report.PrintingSystem.ExportOptions.PrintPreview.ActionAfterExport = DevExpress.XtraPrinting.ActionAfterExport.None

                    If Request.QueryString("Type") = "1" Then
                        Report.ExportToPdf(Request.PhysicalApplicationPath.Trim() & "TEMP\" & DefaultFileName & ".pdf")
                    ElseIf Request.QueryString("Type") = "5" Then
                        Report.ExportToRtf(Request.PhysicalApplicationPath.Trim() & "TEMP\" & DefaultFileName & ".rtf")
                    Else
                        Report.ExportToPdf(Request.PhysicalApplicationPath.Trim() & "TEMP\" & DefaultFileName & ".pdf")
                    End If
                    'Files.Add(Request.PhysicalApplicationPath.Trim() & "TEMP\" & DefaultFileName & ".pdf")

                End If
                'Next
                If Request.QueryString("Type") = "1" Then
                    Return Request.PhysicalApplicationPath.Trim() & "TEMP\" & DefaultFileName & ".pdf"
                ElseIf Request.QueryString("Type") = "5" Then
                    Return Request.PhysicalApplicationPath.Trim() & "TEMP\" & DefaultFileName & ".rtf"
                Else
                    Return Request.PhysicalApplicationPath.Trim() & "TEMP\" & DefaultFileName & ".pdf"
                End If

            Else
                sb1.Append(Request.PhysicalApplicationPath.Trim())
                sb1.Append("TEMP\")

                sb1.Append("Estimate_")
                sb1.Append(Request.QueryString("EstNum"))
                If comp <> 0 Then
                    sb1.Append("_")
                    sb1.Append(comp)
                End If
                sb1.Append(AdvantageFramework.StringUtilities.GUID_Date(True, True, True))

                sbReportName.Append(Request.QueryString("Report"))

                Session("EstimatingAddressOption") = Request.QueryString("option")
                If Request.QueryString("Report").Contains("SS1") = True Or Request.QueryString("Report").Contains("008") = True Or Request.QueryString("Report").Contains("009") = True Or Request.QueryString("Report").Contains("QUR") = True Or Request.QueryString("Report").Contains("Mars") = True Then
                    Session("EstimatingCombine") = "0"
                Else
                    Session("EstimatingCombine") = Request.QueryString("combine")
                End If
                Session("EstimatingEstNum") = Me.EstimateNumber
                If comp = 0 Then
                    Session("EstimatingEstComp") = Me.EstimateComponentNbr
                Else
                    Session("EstimatingEstComp") = comp
                End If
                If quotes = "" Then
                    Session("EstimatingQuotes") = Request.QueryString("quotes")
                Else
                    Session("EstimatingQuotes") = quotes
                End If
                Session("EstimatingComps") = Request.QueryString("comps")
                Session("EstimatingUseEmpSig") = Request.QueryString("UseEmpSig")
                Dim rpt As New popReportViewer

                Dim imgPath As String = Request.PhysicalApplicationPath & "Images\logo_print.gif"
                rpt.renderDoc(sb1.ToString(), sbReportName.ToString(), "", "", "", "", "", Me.FileType, imgPath)
                Dim str As String = sb1.ToString()
                If str.IndexOf(".pdf") = -1 Then
                    str &= ".pdf"
                End If
                Return str
            End If





        Catch ex As Exception
            Me.ShowMessage(MiscFN.JavascriptSafe(ex.Message.ToString()))
            Return ""
        End Try
    End Function
    Private Function OutputReportFileRFQ(Optional ByVal comp As Integer = 0, Optional ByVal quotes As String = "") As String
        Try
            Dim sb1 As New System.Text.StringBuilder 'build filename
            Dim sbReportName As New System.Text.StringBuilder

            sb1.Append(Request.PhysicalApplicationPath.Trim())
            sb1.Append("TEMP\")

            sb1.Append("RFQ_")
            sb1.Append(Request.QueryString("EstNum"))
            If comp <> 0 Then
                sb1.Append("_")
                sb1.Append(comp)
            End If
            sb1.Append(AdvantageFramework.StringUtilities.GUID_Date(True, True, True))

            sbReportName.Append(Request.QueryString("Report"))

            Session("VendorReqEstNum") = Request.QueryString("EstNum")
            Session("VendorReqEstComp") = Request.QueryString("EstCompNum")
            Session("VendorReqVenQte") = Request.QueryString("VendorQteNbr")
            Session("VendorReqVenCode") = Request.QueryString("VendorCode")

            Dim rpt As New popReportViewer

            Dim imgPath As String = Request.PhysicalApplicationPath & "Images\logo_print.gif"
            rpt.renderDoc(sb1.ToString(), sbReportName.ToString(), "", "", "", "", "", Me.FileType, imgPath)
            Dim str As String = sb1.ToString()
            If str.IndexOf(".pdf") = -1 Then
                str &= ".pdf"
            End If
            Return str
        Catch ex As Exception
            Me.ShowMessage(MiscFN.JavascriptSafe(ex.Message.ToString()))
            Return ""
        End Try

    End Function
    Private Function OutputReportFilePO() As String

        Dim XtraReport As DevExpress.XtraReports.UI.XtraReport = Nothing
        Dim FileName As String = "PURCHASE_ORDER_" & AdvantageFramework.StringUtilities.PadWithCharacter(Int32.Parse(Me.PO_RefId).ToString, 8, "0", True, False) & ".pdf"
        Dim Path As String = Request.PhysicalApplicationPath.Trim() & "TEMP\" & FileName
        Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
        Dim PurchaseOrderPrintDefault As AdvantageFramework.Database.Entities.PurchaseOrderPrintDefault = Nothing
        Dim Location As AdvantageFramework.Database.Entities.Location = Nothing
        Dim FooterAboveSignature As Boolean = True
        Dim UsePrintedDate As Date? = Nothing
        Dim IsActiveReport As Boolean = False
        Dim ReportFormat As String = Nothing
        Dim PrintOptionsForActiveReports As String = Nothing
        Dim DataSource As Generic.List(Of AdvantageFramework.Database.Entities.PurchaseOrder) = Nothing
        Dim popReportViewer As Webvantage.popReportViewer = Nothing
        Dim Saved As Boolean = False

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                PurchaseOrderPrintDefault = AdvantageFramework.Database.Procedures.PurchaseOrderPrintDefault.LoadByUserCode(DbContext, _Session.UserCode)

                If PurchaseOrderPrintDefault IsNot Nothing Then

                    ReportFormat = PurchaseOrderPrintDefault.ReportFormat

                    If Not String.IsNullOrWhiteSpace(PurchaseOrderPrintDefault.LocationID) Then

                        Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                            Location = AdvantageFramework.Database.Procedures.Location.LoadByLocationID(DataContext, PurchaseOrderPrintDefault.LocationID)

                        End Using

                    End If

                End If

                If Not [String].IsNullOrWhiteSpace(Request("Report")) Then

                    ReportFormat = Request("Report")

                End If

                If String.IsNullOrWhiteSpace(ReportFormat) Then

                    ReportFormat = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Reporting.PurchaseOrderReports.StandardFormat).Code

                End If

                If Not AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Reporting.PurchaseOrderReports)).Select(Function(EnumObject) EnumObject.Code).ToArray.Contains(ReportFormat) Then

                    IsActiveReport = True

                End If

                If IsActiveReport Then

                    If PurchaseOrderPrintDefault IsNot Nothing Then

                        PrintOptionsForActiveReports = String.Join(";", {PurchaseOrderPrintDefault.ShippingInstructions.GetValueOrDefault(0),
                                                                         PurchaseOrderPrintDefault.PurchaseOrderInstructions.GetValueOrDefault(0),
                                                                         PurchaseOrderPrintDefault.FooterComment.GetValueOrDefault(0),
                                                                         PurchaseOrderPrintDefault.DetailDescription.GetValueOrDefault(0),
                                                                         PurchaseOrderPrintDefault.DetailInstruction.GetValueOrDefault(0),
                                                                         PurchaseOrderPrintDefault.VendorContact.GetValueOrDefault(0),
                                                                         PurchaseOrderPrintDefault.ClientName.GetValueOrDefault(0),
                                                                         PurchaseOrderPrintDefault.ProductName.GetValueOrDefault(0),
                                                                         PurchaseOrderPrintDefault.JobComponentNumber.GetValueOrDefault(0),
                                                                         PurchaseOrderPrintDefault.FunctionDescription.GetValueOrDefault(0),
                                                                         PurchaseOrderPrintDefault.JobDescription.GetValueOrDefault(0),
                                                                         PurchaseOrderPrintDefault.UseEmployeeSignature.GetValueOrDefault(0),
                                                                         PurchaseOrderPrintDefault.VendorCode.GetValueOrDefault(0),
                                                                         PurchaseOrderPrintDefault.UseUserSignature.GetValueOrDefault(0)}.ToArray)

                    End If

                    If Location IsNot Nothing Then

                        Session("LocationOverride") = Location
                        Session("POPrintLocationID") = Location.ID
                        Session("POPrintLocationPath") = Location.LogoPath
                        Session("POPrintLocationName") = Location.Name

                    Else

                        Session("LocationOverride") = Nothing
                        Session("POPrintLocationID") = "None"
                        Session("POPrintLocationPath") = ""
                        Session("POPrintLocationName") = ""

                    End If

                    popReportViewer = New popReportViewer

                    Saved = popReportViewer.renderDoc(Path, ReportFormat, Me.PO_RefId, "", "", "", "", 1, Request.PhysicalApplicationPath & "Images\logo_print.gif", PrintOptionsForActiveReports)

                Else

                    ParameterDictionary = New Generic.Dictionary(Of String, Object)
                    DataSource = (From Item In AdvantageFramework.Database.Procedures.PurchaseOrder.Load(DbContext)
                                  Where Item.Number = Me.PO_RefId
                                  Select Item).ToList

                    ParameterDictionary("DataSource") = DataSource

                    If PurchaseOrderPrintDefault IsNot Nothing Then

                        ParameterDictionary("PrintDefaults") = PurchaseOrderPrintDefault

                    End If

                    ParameterDictionary("DefaultLocation") = Location

                    If ReportFormat = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Reporting.PurchaseOrderReports.FooterAboveSignature).Code Then

                        ParameterDictionary("FooterAboveSignature") = True

                    End If

                    If CBool(PurchaseOrderPrintDefault.DateToPrint.GetValueOrDefault(0)) Then

                        ParameterDictionary("UsePrintedDate") = System.DateTime.Now

                    End If

                    XtraReport = AdvantageFramework.Reporting.Reports.CreateReport(_Session, AdvantageFramework.Reporting.ReportTypes.PurchaseOrderReport, ParameterDictionary, Nothing, Nothing, Nothing, Nothing)

                    If XtraReport IsNot Nothing Then

                        Try

                            XtraReport.ExportToPdf(Path)

                            Saved = True

                        Catch ex As Exception

                        End Try

                    End If

                End If

            End Using

            If Saved Then

                Dim PO As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
                PO.UpdatePOPrint(1, Me.PO_RefId, 1)

            End If

            Return Path
        Catch ex As Exception
            Me.ShowMessage(MiscFN.JavascriptSafe(ex.Message.ToString()))
            Return ""
        End Try

    End Function
    Private Function OutputReportFilePSExcel() As String
        Try
            Dim StrFilePrefix As String = Request.PhysicalApplicationPath & "TEMP\"
            Dim StrFileName As String = ""
            Dim r As cReports = New cReports(Session("ConnString"))
            Dim StrFileType As String = ".xls"
            StrFileName = "Project_Schedule_" & Me.JobNumber.ToString() & "_" & Me.JobComponentNbr.ToString() & AdvantageFramework.StringUtilities.GUID_Date(True, True, True) & StrFileType

            Dim fs As FileStream = File.OpenWrite(StrFilePrefix & StrFileName)
            Dim ms As MemoryStream
            Dim gl As New Ganttline()
            Dim tsCal As New TrafficSchedule_Calendar_Render()
            Dim ppe As New PertPageExcel()
            Dim enc As New UTF8Encoding
            Dim arrBytData() As Byte
            Dim Workbook As Aspose.Cells.Workbook = Nothing

            If Request.QueryString("form") = "calx" Then
                Workbook = tsCal.RenderProjectCalendarReportWorkbook(Me.JobNumber, Me.JobComponentNbr, Request.QueryString("ms"), Request.QueryString("completed"))
                'arrBytData = System.Text.Encoding.ASCII.GetBytes(tsCal.RenderProjectCalendarReport2Excel(Me.JobNumber, Me.JobComponentNbr, Request.QueryString("ms")))
                'ms = New MemoryStream(arrBytData)
            ElseIf Request.QueryString("form") = "mulx" Then
                arrBytData = System.Text.Encoding.ASCII.GetBytes(ppe.RendorMultiJobPSExcel(Me.ClCode, Me.DivCode, Me.ProdCode, Me.JobNumber, Me.JobComponentNbr, Me.EmpCode, Me.ManagerCode, Me.TaskCode, Me.AccountExecCode, Me.RoleCode, Me.CutOffDate,
                                                                    Me.IncludeCompletedTasks, Me.IncludeOnlyPendingTasks, Me.ExcludeProjectedTasks, Me.IncludeCompletedSchedules, Me.CampaignCode, Me.TaskPhaseFilter, Me.MilestonesOnly, Me.TrafficStatusCode))
                ms = New MemoryStream(arrBytData)
            ElseIf Request.QueryString("form") = "day" Then
                Workbook = gl.RenderProjectTimelineReportWorkbook(Session("ConnString"), Me.JobNumber, Me.JobComponentNbr, Me.MilestonesOnly, Me.ExcludeTaskComment, True, Request.QueryString("completed"))
                'arrBytData = System.Text.Encoding.ASCII.GetBytes(gl.RenderProjectTimelineReportExcelByDay(Me.JobNumber, Me.JobComponentNbr, Request.QueryString("ms"), Session("ConnString"), Me.ExcludeTaskComment))
                'ms = New MemoryStream(arrBytData)
            Else
                Workbook = gl.RenderProjectTimelineReportWorkbook(Session("ConnString"), Me.JobNumber, Me.JobComponentNbr, Me.MilestonesOnly, Me.ExcludeTaskComment, False, Request.QueryString("completed"))
                'arrBytData = System.Text.Encoding.ASCII.GetBytes(gl.RenderProjectTimelineReportExcel(Me.JobNumber, Me.JobComponentNbr, Request.QueryString("ms"), Session("ConnString"), Me.ExcludeTaskComment))
                'ms = New MemoryStream(arrBytData)
            End If

            If Workbook IsNot Nothing Then

                ms = New MemoryStream()
                Workbook.FileName = StrFileName
                Workbook.Save(ms, (New Aspose.Cells.XlsSaveOptions(Aspose.Cells.SaveFormat.Excel97To2003)))

            End If

            ms.WriteTo(fs)
            ms.Flush()
            ms.Close()
            fs.Close()
            Return StrFilePrefix & StrFileName
        Catch ex As Exception
            Me.ShowMessage(MiscFN.JavascriptSafe(ex.Message.ToString()))
            Return ""
        End Try
    End Function

#End Region
#Region " popsend Procedures "

    Private Function ValidateSave(ByRef ErrorMessage As String) As Boolean
        If Me.PageType() = "jt" AndAlso Me.JobNumber > 0 AndAlso Me.JobComponentNbr > 0 Then
            ErrorMessage = QuickValidateJob(Me.JobNumber, Me.JobComponentNbr)
            If ErrorMessage <> "" Then
                Return False
            End If
        End If
        If Me.PageType() = "js" Then
            ErrorMessage = QuickValidateJob(Session("JSReportJobNum"), Session("JSReportJobCompNum"))
            If ErrorMessage <> "" Then
                Return False
            End If
        End If

        If Me.PageType() = "jv" Then
            ErrorMessage = QuickValidateJob(Session("JVReportJobNum"), Session("JVReportJobCompNum"))
            If ErrorMessage <> "" Then
                Return False
            End If
        End If

        If Me.PageType() = "cb" Then
            ErrorMessage = QuickValidateJob(Session("CBReportJobNum"), Session("CBReportJobCompNum"))
            If ErrorMessage <> "" Then
                Return False
            End If
        End If

        ErrorMessage = ""
        Return True

    End Function
    Private Function QuickValidateJob(ByVal Job As Integer, ByVal jobcomp As Integer) As String
        Dim ErrMessage As String = ""
        Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
        If IsNumeric(Job.ToString) = False Then
            ErrMessage = "Job number is not valid"
        ElseIf IsNumeric(jobcomp.ToString) = False Then
            ErrMessage = "Component number is not valid"
        End If
        If myVal.ValidateJobNumber(Job.ToString) = False Then
            ErrMessage = "This job does not exist"
        ElseIf myVal.ValidateJobCompNumber(Job.ToString(), jobcomp.ToString) = False Then
            ErrMessage = "This is not a valid job/component"
        End If
        If myVal.ValidateJobCompIsViewable(Session("UserCode"), Job.ToString(), jobcomp.ToString) = False Then
            ErrMessage = "Access to this job/component is denied"
        End If
        Return ErrMessage
    End Function
    Private Sub RetrieveVendorContactEmailList()
        If Me.PO_RefId > 0 Then
            Dim ds As DataSet
            Dim POHeader As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))

            ds = POHeader.Get_PO_Vendor_EmailDS(1, Me.PO_RefId, "")

            Dim gRow As DataRow

            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                Try
                    If IsDBNull(ds.Tables(0).Rows(i)("EMAIL_ADDRESS")) = False Then
                        If AdvantageFramework.Email.IsValidEmailAddress(ds.Tables(0).Rows(i)("EMAIL_ADDRESS").ToString()) = True Then
                            Me.TxtEmailTo.Text &= ds.Tables(0).Rows(i)("EMAIL_ADDRESS") & ","
                        End If
                    End If
                Catch ex As Exception
                End Try
            Next
        End If
    End Sub

#End Region

#End Region

#Region " Board stuff "

    Private Function CheckForBoard() As Boolean

        Dim HasActiveBoard As Boolean = False
        Dim HasSprint As Boolean = False

        Dim JobSpecificBoards As Generic.List(Of AdvantageFramework.Database.Entities.Board) = Nothing
        Dim AllJobsBoards As Generic.List(Of AdvantageFramework.Database.Entities.Board) = Nothing

        Dim AvailableBoards As New Generic.List(Of AdvantageFramework.Database.Entities.Board)
        Dim DisplayBoards As New Generic.List(Of AdvantageFramework.Database.Entities.Board)

        Me.RadComboBoxBoard.Enabled = True
        Me.RadComboBoxSprint.Enabled = True
        Me.RadComboBoxBoardState.Enabled = True

        Me.RadComboBoxBoard.Items.Clear()
        Me.RadComboBoxSprint.Items.Clear()
        Me.RadComboBoxBoardState.Items.Clear()

        If Me.JobNumber > 0 AndAlso Me.JobComponentNbr > 0 Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                JobSpecificBoards = (From Entity In AdvantageFramework.Database.Procedures.Board.LoadByJobAndComponent(DbContext, JobNumber, JobComponentNbr)
                                     Where Entity.IsActive Is Nothing OrElse Entity.IsActive = True
                                     Select Entity).ToList

                If JobSpecificBoards IsNot Nothing AndAlso JobSpecificBoards.Count > 0 Then

                    For Each Board In JobSpecificBoards

                        AvailableBoards.Add(Board)

                    Next

                End If

                AllJobsBoards = (From Entity In AdvantageFramework.Database.Procedures.Board.LoadAllJobsBoards(DbContext)
                                 Where Entity.IsActive Is Nothing OrElse Entity.IsActive = True
                                 Select Entity).ToList

                If AllJobsBoards IsNot Nothing AndAlso AllJobsBoards.Count > 0 Then

                    For Each Board In AllJobsBoards

                        AvailableBoards.Add(Board)

                    Next

                End If
                If AvailableBoards IsNot Nothing AndAlso AvailableBoards.Count > 0 Then

                    HasActiveBoard = True

                    Dim Sprints As Generic.List(Of AdvantageFramework.Database.Entities.SprintHeader) = Nothing

                    For Each Board As AdvantageFramework.Database.Entities.Board In AvailableBoards

                        Sprints = AdvantageFramework.Database.Procedures.SprintHeader.LoadByBoardID(DbContext, Board.ID).ToList

                        If Sprints IsNot Nothing AndAlso Sprints.Count > 0 Then

                            For Each Sprint As AdvantageFramework.Database.Entities.SprintHeader In Sprints

                                If (Sprint.IsComplete Is Nothing OrElse Sprint.IsComplete = False) Then

                                    If HasSprint = False Then HasSprint = True
                                    DisplayBoards.Add(Board)
                                    Exit For

                                End If

                            Next

                        End If

                        Sprints = Nothing

                    Next

                End If

            End Using

        Else

            HasActiveBoard = False
            HasSprint = False

        End If

        If DisplayBoards Is Nothing OrElse DisplayBoards.Count = 0 Then

            HasActiveBoard = False
            HasSprint = False

        End If

        If HasActiveBoard = True AndAlso HasSprint = True Then

            Me.RadComboBoxBoard.DataSource = DisplayBoards
            Me.RadComboBoxBoard.DataTextField = "Name"
            Me.RadComboBoxBoard.DataValueField = "ID"
            Me.RadComboBoxBoard.DataBind()

            If DisplayBoards.Count = 1 Then

                BoardIDChanged()

            Else

                Me.RadComboBoxBoard.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", "0"))

            End If

            Me.FieldsetBoardSprint.Visible = True

        Else

            Me.FieldsetBoardSprint.Visible = False

        End If

    End Function
    Private Sub RadComboBoxBoard_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxBoard.SelectedIndexChanged

        BoardIDChanged()

    End Sub
    Private Sub BoardIDChanged()

        Me.RadComboBoxSprint.Enabled = True
        Me.RadComboBoxBoardState.Enabled = True

        Me.RadComboBoxSprint.Items.Clear()
        Me.RadComboBoxBoardState.Items.Clear()

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Dim Board As AdvantageFramework.Database.Entities.Board = Nothing
            Dim Sprints As Generic.List(Of AdvantageFramework.Database.Entities.SprintHeader) = Nothing
            Dim States As Generic.List(Of AdvantageFramework.Database.Entities.AlertState) = Nothing
            Dim ActiveSprintID As Integer = 0

            If Me.RadComboBoxBoard.SelectedItem IsNot Nothing Then

                Board = AdvantageFramework.Database.Procedures.Board.LoadByBoardID(DbContext, Me.RadComboBoxBoard.SelectedItem.Value)

            End If

            If Board IsNot Nothing Then

                Sprints = AdvantageFramework.Database.Procedures.SprintHeader.LoadByBoardID(DbContext, Me.RadComboBoxBoard.SelectedItem.Value).ToList

                If Sprints IsNot Nothing AndAlso Sprints.Count > 0 Then

                    For Each Sprint As AdvantageFramework.Database.Entities.SprintHeader In Sprints

                        If (Sprint.IsComplete Is Nothing OrElse Sprint.IsComplete = False) Then

                            If Sprint.IsActive IsNot Nothing AndAlso Sprint.IsActive = True Then

                                ActiveSprintID = Sprint.ID

                                Dim ActiveItem As New RadComboBoxItem
                                ActiveItem.Text = Sprint.Description
                                ActiveItem.Value = Sprint.ID
                                ActiveItem.CssClass = "active-item"

                                Me.RadComboBoxSprint.Items.Add(ActiveItem)

                            Else

                                Me.RadComboBoxSprint.Items.Add(New RadComboBoxItem(Sprint.Description, Sprint.ID))

                            End If

                        End If

                    Next

                    MiscFN.RadComboBoxSetIndex(Me.RadComboBoxSprint, ActiveSprintID, False)

                    Me.RadComboBoxSprint.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", "0"))

                End If

                States = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.AlertState)
                          Join BD In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.BoardDetail) On Entity.ID Equals BD.AlertStateID
                          Where BD.BoardHeaderID = Board.BoardHeaderID And (Entity.IsActive Is Nothing Or Entity.IsActive = True)
                          Order By BD.SequenceNumber
                          Select Entity).ToList

                If States IsNot Nothing Then

                    RadComboBoxBoardState.DataSource = States
                    RadComboBoxBoardState.DataTextField = "Name"
                    RadComboBoxBoardState.DataValueField = "ID"
                    RadComboBoxBoardState.DataBind()

                End If

                Me.RadComboBoxBoardState.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Backlog]", "-1"))

            End If

            If Me.RadComboBoxBoard.Items.Count = 1 Then

                Me.RadComboBoxBoard.SelectedIndex = 0
                Me.RadComboBoxBoard.Enabled = False

            End If

            Me.RadComboBoxBoardState.SelectedIndex = 0
            Me.RadComboBoxBoardState.Enabled = Me.RadComboBoxSprint.SelectedIndex > 0

        End Using

    End Sub
    Private Sub RadComboBoxSprint_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxSprint.SelectedIndexChanged

        Me.RadComboBoxBoardState.SelectedIndex = 0
        Me.RadComboBoxBoardState.Enabled = Me.RadComboBoxSprint.SelectedIndex > 0

    End Sub

#End Region

    Private Function CheckStartDueDate() As Boolean
        Dim Valid As Boolean = True
        Try

            If Me.RadDatePickerDueDate.SelectedDate.HasValue = True AndAlso Me.RadDatePickerStartDate.SelectedDate.HasValue = True Then


                If CType(Me.RadDatePickerStartDate.SelectedDate, Date) > CType(Me.RadDatePickerDueDate.SelectedDate, Date) Then

                    Me.ShowMessage("Due date is before start date")
                    Valid = False

                End If

            End If

        Catch ex As Exception
        End Try
        Return Valid
    End Function

    Private Sub ReloadAutoRecipientControl()

        If Me.txtClient.Text.Trim() <> "" Then Me.AutoCompleteRecipients.ClientCode = Me.txtClient.Text.Trim()
        If Me.txtDivision.Text.Trim() <> "" Then Me.AutoCompleteRecipients.DivisionCode = Me.txtDivision.Text.Trim()
        If Me.txtProduct.Text.Trim() <> "" Then Me.AutoCompleteRecipients.ProductCode = Me.txtProduct.Text.Trim()
        If IsNumeric(Me.txtJob.Text) = True Then Me.AutoCompleteRecipients.JobNumber = CType(Me.txtJob.Text, Integer)
        If IsNumeric(Me.txtComponent.Text) = True Then Me.AutoCompleteRecipients.JobComponentNumber = CType(Me.txtComponent.Text, Integer)

        Me.AutoCompleteRecipients.LoadData()

    End Sub
    Private Sub SetQSVars()
        Try
            If Not Request.QueryString("send") Is Nothing Then
                If Request.QueryString("send") = 1 Then
                    Me.SendOnly = True
                Else
                    Me.SendOnly = False
                End If
            End If
        Catch ex As Exception
            Me.App = MiscFN.Source_App.Alert
        End Try
        Try
            If Not Request.QueryString("f") Is Nothing Then
                Me.App = CType(Request.QueryString("f"), MiscFN.Source_App)
            End If
        Catch ex As Exception
            Me.App = MiscFN.Source_App.Alert
        End Try
        Try
            If Not Request.QueryString("pop") Is Nothing Then
                Dim i As Integer = CType(Request.QueryString("pop"), Integer)
                If i = 1 Then
                    Me.IsPopUp = True
                End If
            End If
        Catch ex As Exception
            Me.IsPopUp = False
        End Try
        Try
            If Not Request.QueryString("cli") Is Nothing Then
                Me.ClCode = Request.QueryString("cli")
            End If
        Catch ex As Exception
            Me.ClCode = ""
        End Try
        Try
            If Not Request.QueryString("div") Is Nothing Then
                Me.DivCode = Request.QueryString("div")
            End If
        Catch ex As Exception
            Me.DivCode = ""
        End Try
        Try
            If Not Request.QueryString("prd") Is Nothing Then
                Me.ProdCode = Request.QueryString("prd")
            End If
        Catch ex As Exception
            Me.ProdCode = ""
        End Try
        Try
            If Not Request.QueryString("j") Is Nothing Then
                Me.JobNumber = CType(Request.QueryString("j"), Integer)
            End If
        Catch ex As Exception
            Me.JobNumber = 0
        End Try
        Try
            If Not Request.QueryString("jc") Is Nothing Then
                Me.JobComponentNbr = CType(Request.QueryString("jc"), Integer)
            End If
        Catch ex As Exception
            Me.JobComponentNbr = 0
        End Try
        Try
            If Not Request.QueryString("e") Is Nothing Then
                Me.EstimateNumber = CType(Request.QueryString("e"), Integer)
            End If
        Catch ex As Exception
            Me.EstimateNumber = 0
        End Try
        Try
            If Not Request.QueryString("ec") Is Nothing Then
                Me.EstimateComponentNbr = CType(Request.QueryString("ec"), Integer)
            End If
        Catch ex As Exception
            Me.EstimateComponentNbr = 0
        End Try
        Try
            If Not Request.QueryString("cmp") Is Nothing Then
                Dim i As Integer = CType(Request.QueryString("cmp"), Integer)
                If i > 0 Then
                    Me.CmpIdentifier = i
                End If
            End If
        Catch ex As Exception
            Me.CmpIdentifier = 0
        End Try
        Try
            If Not Request.QueryString("seq") Is Nothing Then
                Dim i As Integer = CType(Request.QueryString("seq"), Integer)
                If i > -1 Then
                    Me.TaskSeqNbr = i
                End If
            End If
        Catch ex As Exception
            Me.TaskSeqNbr = 0
        End Try
        Try
            If Not Request.QueryString("ps") Is Nothing Then
                Dim i As Integer = CType(Request.QueryString("ps"), Integer)
                If i = 1 Then
                    Me.FromProjectScheduleAlertInbox = True
                End If
            End If
        Catch ex As Exception
            Me.FromProjectScheduleAlertInbox = False
        End Try
        Try
            If Not Request.QueryString("ref_id") Is Nothing Then
                Dim i As Integer = CType(Request.QueryString("ref_id"), Integer)
                If i > 0 Then
                    Me.PO_RefId = i
                End If
            End If
        Catch ex As Exception
            Me.PO_RefId = 0
        End Try
        Try
            If Not Request.QueryString("email_po") Is Nothing Then
                Me.PO_AlertFunction = Request.QueryString("email_po")
            End If
        Catch ex As Exception
            Me.PO_AlertFunction = ""
        End Try
        Try
            If Not Request.QueryString("vqn") Is Nothing Then
                Dim i As Integer = CType(Request.QueryString("vqn"), Integer)
                If i > -1 Then
                    Me.VendorQuoteNbr = i
                End If
            End If
        Catch ex As Exception
            Me.VendorQuoteNbr = 0
        End Try
        Try
            If Not Request.QueryString("vc") Is Nothing Then
                Me.VendorCode = Request.QueryString("vc")
            End If
        Catch ex As Exception
            Me.VendorCode = ""
        End Try
        Try
            If Not Request.QueryString("mgr") = Nothing Then
                Me.ManagerCode = Request.QueryString("mgr").ToString()
            End If
            If Not Request.QueryString("ae") = Nothing Then
                Me.AccountExecCode = Request.QueryString("ae").ToString()
            End If
            If Not Request.QueryString("ics") = Nothing Then
                Me.IncludeCompletedSchedules = CType(Request.QueryString("ics").ToString(), Boolean)
            End If
            If Not Request.QueryString("emp") = Nothing Then
                Me.EmpCode = Request.QueryString("emp").ToString()
                If Me.EmpCode.Trim <> "" Then
                    Me.UsingATaskLevelFilter = True
                End If
            End If
            If Not Request.QueryString("tsk") = Nothing Then
                Me.TaskCode = Request.QueryString("tsk").ToString()
                If Me.TaskCode.Trim <> "" Then
                    Me.UsingATaskLevelFilter = True
                End If
            End If
            If Not Request.QueryString("rl") = Nothing Then
                Me.RoleCode = Request.QueryString("rl").ToString()
                If Me.RoleCode.Trim <> "" Then
                    Me.UsingATaskLevelFilter = True
                End If
            End If
            If Not Request.QueryString("cod") = Nothing Then
                Me.CutOffDate = Request.QueryString("cod").ToString()
                If Me.CutOffDate.Trim <> "" Then
                    Me.UsingATaskLevelFilter = True
                End If
            End If
            If Not Request.QueryString("ict") = Nothing Then
                Me.IncludeCompletedTasks = CType(Request.QueryString("ict").ToString(), Boolean)
                If Me.IncludeCompletedTasks = True Then
                    Me.UsingATaskLevelFilter = True
                End If
            End If
            If Not Request.QueryString("pnd") = Nothing Then
                Me.IncludeOnlyPendingTasks = CType(Request.QueryString("pnd").ToString(), Boolean)
                If Me.IncludeOnlyPendingTasks = True Then
                    Me.UsingATaskLevelFilter = True
                End If
            End If
            If Not Request.QueryString("prj") = Nothing Then
                Me.ExcludeProjectedTasks = CType(Request.QueryString("prj").ToString(), Boolean)
                If Me.ExcludeProjectedTasks = True Then
                    Me.UsingATaskLevelFilter = True
                End If
            End If
            If Not Request.QueryString("ci") = Nothing Then
                Me.CampaignCode = Request.QueryString("ci").ToString()
            End If
            If Not Request.QueryString("pf") = Nothing Then
                Me.TaskPhaseFilter = Request.QueryString("pf").ToString()
            End If
            If Not Request.QueryString("mso") = Nothing Then
                Me.MilestonesOnly = CType(Request.QueryString("mso").ToString(), Boolean)
            End If
            If Not Request.QueryString("ts") = Nothing Then
                Me.TrafficStatusCode = Request.QueryString("ts").ToString()
            End If
            If Not Request.QueryString("excludeTC") = Nothing Then
                Me.ExcludeTaskComment = CType(Request.QueryString("excludeTC").ToString(), Boolean)
            End If
        Catch ex As Exception

        End Try
        Try
            If Not Request.QueryString("assn") = Nothing Then
                Me.AutoSetToAssignment = MiscFN.IntToBool(CType(Request.QueryString("assn"), Integer))
            End If
        Catch ex As Exception
            Me.AutoSetToAssignment = False
        End Try

        Try
            If Not Request.QueryString("jverid") = Nothing Then
                Me.JobVerHdrID = CType(Request.QueryString("jverid"), Integer)
            End If
        Catch ex As Exception
            Me.AutoSetToAssignment = False
        End Try

        Try

            If Request.QueryString("AID") <> Nothing Then

                _CopyFromAlertID = CType(Request.QueryString("AID"), Integer)
                Me.IsCopy = True

            End If

        Catch ex As Exception
            _CopyFromAlertID = 0
        End Try

        Try

            If Not Request.QueryString("eml") Is Nothing Then

                Me.AutoSetToEmail = Request.QueryString("eml") = "1"

            End If

        Catch ex As Exception

            Me.AutoSetToEmail = False

        End Try
        Try

            If Not Request.QueryString("mjobs") Is Nothing Then

                Me._MultipleJobList = Request.QueryString("mjobs").ToString().Trim()
                If Me._MultipleJobList <> "" Then

                    Me._MultipleJob = True

                End If

            End If

        Catch ex As Exception

            Me._MultipleJob = False

        End Try

        Try

            If Request.QueryString("ATBNum") IsNot Nothing Then

                Me.ATBNumber = CInt(Request.QueryString("ATBNum"))

            End If

        Catch ex As Exception
            Me.ATBNumber = 0
        End Try

        Try

            If Request.QueryString("ATBRev") IsNot Nothing Then

                Me.ATBRevisionNumber = CInt(Request.QueryString("ATBRev"))

            End If

        Catch ex As Exception
            Me.ATBRevisionNumber = 0
        End Try
        Try

            If Request.QueryString("draft_id") IsNot Nothing Then

                Me._DraftAlertID = CInt(Request.QueryString("draft_id"))

            End If

        Catch ex As Exception

            Me._DraftAlertID = 0

        End Try

    End Sub
    Private Function HasRecipient() As Boolean

        'Dim test As String
        'test = Me.AutoCompleteRecipients.GetEmployeeCodes()

        If Me.SendOnly = False Then
            If Me.AutoCompleteRecipients.HasEntries = False And Me.ChkIsAlertAssignment.Checked = False Then
                Me.ShowMessage("Please select Alert Recipient(s)")
                Return False
            ElseIf Me.ChkIsAlertAssignment.Checked = True Then ' And (Me.RadComboBoxAlertAssignmentTemplate.SelectedIndex = 0 Or Me.RadComboBoxAssignTo.SelectedIndex = 0) Then
                If Me.HasAlertAssignment() = False Then
                    Return False
                End If
                Return True
            Else
                Return True
            End If
        Else
            If Me.RadioEmail.Checked = False And Me.RadioAlert.Checked = False Then
                Me.ShowMessage("Please select a Send option")
                Return False
            End If
            If Me.RadioEmail.Checked = True Then
                If Me.TxtEmailTo.Text.Trim() = "" And Me.TxtEmailCC.Text.Trim() = "" And Me.TxtEmailBCC.Text.Trim() = "" Then
                    Me.ShowMessage("Please select Email Recipient(s)")
                    Return False
                End If
            End If
            If Me.RadioAlert.Checked = True And Me.ChkIsAlertAssignment.Checked = False Then
                If Me.AutoCompleteRecipients.HasEntries = False Then
                    Me.ShowMessage("Please select Alert Recipient(s)")
                    Return False
                End If
            End If
            If Me.RadioAlert.Checked = True And Me.ChkIsAlertAssignment.Checked = True Then
                If Me.HasAlertAssignment() = False Then
                    Return False
                End If
            End If

            Return True
        End If
    End Function
    Private Sub SetStatesAndEmployees(ByVal AlertNotifyHdrTemplateId As Integer)

        If AlertNotifyHdrTemplateId = 0 Then

        Else

            If Me.RadComboBoxAlertAssignmentTemplate.SelectedIndex > 0 Then

                Me.BindRadTreeViewStates(AlertNotifyHdrTemplateId)

            Else

                Me.RadTreeViewStates.Nodes.Clear()

            End If

            If Request.QueryString("pagetype") = "jr" Then
                Dim agency As New AdvantageFramework.Web.AgencySettings.Methods(Session("ConnString"), Session("UserCode"), HttpContext.Current)
                Dim State As New AdvantageFramework.Database.Entities.AlertAssignmentTemplateState
                Dim AssignmentState As Integer = If(agency.GetValue(AdvantageFramework.Agency.Settings.JR_ASSIGN_STATE, 0) = "", 0, agency.GetValue(AdvantageFramework.Agency.Settings.JR_ASSIGN_STATE, 0))
                Dim AssignmentStateEmployee As String = agency.GetValue(AdvantageFramework.Agency.Settings.JR_DFLT_CONTACT, "")
                Dim AssignmentStateAlertGroup As String = agency.GetValue(AdvantageFramework.Agency.Settings.JR_DFLT_ALERT_GROUP, "")
                If AssignmentState > 0 Then
                    For j As Integer = 0 To Me.RadTreeViewStates.Nodes.Count - 1
                        If AssignmentState = Me.RadTreeViewStates.Nodes(j).Value Then
                            Me.RadTreeViewStates.Nodes(j).Selected = True
                        End If
                    Next
                    Dim c As New cAlerts()
                    With Me.RadComboBoxAssignTo
                        .Visible = True
                        .Enabled = True
                        .Focus()
                    End With
                    With Me.RadComboBoxAssignTo
                        .Items.Clear()
                        .Text = ""
                        .DataTextField = "EMP_FML"
                        .DataValueField = "EMP_CODE"
                        .DataSource = c.GetNotificationRecipients(Me.RadTreeViewStates.SelectedValue, 0, 0, Me.RadComboBoxAlertAssignmentTemplate.SelectedValue)
                        .DataBind()
                    End With
                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                        State = AdvantageFramework.Database.Procedures.AlertAssignmentTemplateState.LoadByAlertAssignmentTemplateIDAndAlertStateID(DbContext, AlertNotifyHdrTemplateId, AssignmentState)
                    End Using

                    If State.DefaultEmployeeCode <> "" Then
                        Me.RadComboBoxAssignTo.SelectedValue = State.DefaultEmployeeCode
                    ElseIf AssignmentStateEmployee <> "" Then
                        Me.RadComboBoxAssignTo.SelectedValue = AssignmentStateEmployee
                    End If

                    If State.DefaultAlertGroupCode <> "" Then

                    ElseIf AssignmentStateAlertGroup <> "" Then

                    End If

                End If

            Else

                Try
                    If Me.RadComboBoxAssignTo.Items.Count > 0 Then

                        Me.RadComboBoxAssignTo.SelectedIndex = 0
                        Me.RadComboBoxAssignTo.Text = "[Please select]"

                    End If
                Catch ex As Exception
                End Try

                Me.RadComboBoxAssignTo.Enabled = False
            End If
        End If

    End Sub
    Private Function ValidateCampaignInput() As String
        Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
        Return ""
    End Function
    Private Function QuickValidateLookups(ByVal TheLevel As String) As String
        Dim ErrMessage As String = ""
        Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))

        Select Case TheLevel
            Case "OF"
                If Me.txtOffice.Text = "" Then
                    Return "Please enter an office code when filtering at the office level"
                End If
                If myVal.ValidateOffice(Me.txtOffice.Text.Trim()) = False Then
                    Return "Invalid Office"
                End If
            Case "CL"
                If Me.txtClient.Text = "" Then
                    Return "Please enter a client code when filtering at the client level"
                End If
                If myVal.ValidateCDP(Me.txtClient.Text.Trim(), "", "") = False Then
                    Return "Invalid Client"
                End If
                If myVal.ValidateCDPIsViewable("CL", Session("UserCode"), Me.txtClient.Text.Trim(), "", "") = False Then
                    Return "Access to this client is denied"
                End If
            Case "DI"
                If Me.txtClient.Text = "" Or Me.txtDivision.Text = "" Then
                    Return "Please enter a client and division code when filtering at the division level"
                End If
                If myVal.ValidateCDP(Me.txtClient.Text.Trim(), Me.txtDivision.Text.Trim(), "") = False Then
                    Return "Invalid Client, Division"
                End If
                If myVal.ValidateCDPIsViewable("DI", Session("UserCode"), Me.txtClient.Text.Trim(), Me.txtDivision.Text.Trim(), "") = False Then
                    Return "Access to this division is denied"
                End If
            Case "PR"
                If Me.txtClient.Text = "" Or Me.txtDivision.Text = "" Or Me.txtProduct.Text = "" Then
                    Return "Please enter a client, division, and product code when filtering at the product level"
                End If
                If myVal.ValidateCDP(Me.txtClient.Text.Trim(), Me.txtDivision.Text.Trim(), Me.txtProduct.Text.Trim()) = False Then
                    Return "Invalid Client, Division, Product"
                End If
                If myVal.ValidateCDPIsViewable("PR", Session("UserCode"), Me.txtClient.Text.Trim(), Me.txtDivision.Text.Trim(), Me.txtProduct.Text.Trim()) = False Then
                    Return "Access to this product is denied"
                End If
            Case "CM"
                Dim cmp As cCampaign = New cCampaign(Session("ConnString"))
                If txtClient.Text <> "" Then
                    If cmp.ValidateClient(txtClient.Text) = False Then
                        Return "Invalid Client."
                        Me.FocusControl(Me.txtClient)
                    End If
                    If myVal.ValidateCDPIsViewable("CL", Session("UserCode"), txtClient.Text, "", "") = False Then
                        Return "Access to this client is denied"
                    End If
                End If
                If txtDivision.Text <> "" Then
                    If cmp.ValidateDivision(txtClient.Text, txtDivision.Text) = False Then
                        Return "Invalid Division"
                        Me.FocusControl(Me.txtDivision)
                    End If
                    If myVal.ValidateCDPIsViewable("DI", Session("UserCode"), txtClient.Text, txtDivision.Text, "") = False Then
                        Return "Access to this division is denied"
                    End If
                End If
                If txtProduct.Text <> "" Then
                    If cmp.ValidateProduct(txtClient.Text, txtDivision.Text, txtProduct.Text) = False Then
                        Return "Invalid Product"
                        Me.FocusControl(Me.txtProduct)
                    End If
                    If myVal.ValidateCDPIsViewable("PR", Session("UserCode"), txtClient.Text, txtDivision.Text, txtProduct.Text) = False Then
                        Return "Access to this product is denied"
                    End If
                End If
                If txtCampaign.Text <> "" Then
                    If cmp.CampaignExists(txtCampaign.Text) = False Then
                        Return "Invalid Campaign"
                        Me.FocusControl(Me.txtCampaign)
                    End If
                    If myVal.ValidateCampaignIsViewable(Session("UserCode"), txtClient.Text, txtDivision.Text, txtProduct.Text, txtCampaign.Text) = False Then
                        Return "Access to this campaign is denied"
                        Me.FocusControl(Me.txtCampaign)
                    End If
                End If
                Dim ds As New DataSet
                ds = cmp.GetCampaignSearch(Session("UserCode"), "", Me.txtClient.Text, Me.txtDivision.Text, Me.txtProduct.Text, Me.txtCampaign.Text, False)
                Dim ct As Integer = 0
                Try
                    ct = ds.Tables(0).Rows.Count
                Catch ex As Exception
                    ct = 0
                End Try
                Select Case ct
                    Case 0
                        Return "Your Alert Level filter selections have returned no matching campaigns.\nPlease change your filter selections"
                    Case 1
                        Me.txtClient.Text = ds.Tables(0).Rows(0)("CL_CODE").ToString()
                        Me.txtDivision.Text = ds.Tables(0).Rows(0)("DIV_CODE").ToString()
                        Me.txtProduct.Text = ds.Tables(0).Rows(0)("PRD_CODE").ToString()
                        Me.txtCampaign.Text = ds.Tables(0).Rows(0)("CMP_CODE").ToString()
                        Me.CmpIdentifier = CType(ds.Tables(0).Rows(0)("CMP_IDENTIFIER"), Integer)
                    Case Is > 1
                        Return "Your Alert Level filter selections have returned more than one matching campaign.\nPlease narrow your filter selections"
                End Select

            Case "JC", "JJ"
                If Request.QueryString("fromapp") <> "jobsearchmul" Then
                    If Me.txtJob.Text = "" Then
                        Return "Please enter a job number when filtering at the Job/Component level"
                    End If
                    If Me.txtComponent.Text = "" Then
                        Return "Please enter a component number when filtering at the Job/Component level"
                    End If
                    If IsNumeric(Me.txtJob.Text.Trim()) = False Then
                        Return "Job number is not valid"
                    ElseIf IsNumeric(Me.txtComponent.Text.Trim()) = False Then
                        Return "Component number is not valid"
                    End If
                    If myVal.ValidateJobNumber(Me.txtJob.Text) = False Then
                        Return "This job does not exist"
                    ElseIf myVal.ValidateJobCompNumber(Me.txtJob.Text, Me.txtComponent.Text) = False Then
                        Return "This is not a valid job/component"
                    End If
                    If myVal.ValidateJobCompIsViewable(Session("UserCode"), Me.txtJob.Text.Trim(), Me.txtComponent.Text.Trim()) = False Then
                        Return "Access to this job/component is denied"
                    End If
                End If
        End Select
    End Function
    Private Function PreSetAlertAssignment(Optional ByVal ResetIfNotFound As Boolean = False) As Boolean

        Dim a As New AdvantageFramework.Web.AgencySettings.Methods(Session("ConnString"), Session("UserCode"), HttpContext.Current)
        Dim Preset As Boolean = False

        Try
            If Me.JobNumber = 0 Then

                If IsNumeric(Me.txtJob.Text) = True Then

                    Me.JobNumber = CType(Me.txtJob.Text, Integer)

                Else

                    Me.JobNumber = 0

                End If

            End If
            If Me.JobComponentNbr = 0 Then

                If IsNumeric(Me.txtComponent.Text) = True Then

                    Me.JobComponentNbr = CType(Me.txtComponent.Text, Integer)

                Else

                    Me.JobComponentNbr = 0

                End If

            End If
            If Me.JobNumber > 0 And Me.JobComponentNbr > 0 Then 'And Me.RadComboBoxAlertLevel.SelectedValue = "JC" Then

                Dim JobAlertNotifyHdrTemplateId As Integer = SqlHelper.ExecuteScalar(Session("ConnString"), CommandType.Text, "SELECT ISNULL(ALRT_NOTIFY_HDR_ID,0) FROM JOB_COMPONENT WITH(NOLOCK) WHERE JOB_NUMBER = " & Me.JobNumber & " AND JOB_COMPONENT_NBR = " & Me.JobComponentNbr & ";")

                If JobAlertNotifyHdrTemplateId > 0 And Me.RadComboBoxAlertAssignmentTemplate.Items.Count > 0 Then

                    Me.RadComboBoxAlertAssignmentTemplate.FindItemByValue(JobAlertNotifyHdrTemplateId).Selected = True
                    Me.FocusControl(Me.RadComboBoxAlertAssignmentTemplate)
                    Me.SetStatesAndEmployees(JobAlertNotifyHdrTemplateId)
                    Me.SetDefaultSubject()

                    Preset = True

                End If



            End If
            If JobVerHdrID > 0 Then

                Dim JobAlertNotifyHdrTemplateId As Integer = a.GetValue(AdvantageFramework.Agency.Settings.JR_ASSIGN_TMPLT, "")

                If JobAlertNotifyHdrTemplateId > 0 And Me.RadComboBoxAlertAssignmentTemplate.Items.Count > 0 Then

                    Me.RadComboBoxAlertAssignmentTemplate.FindItemByValue(JobAlertNotifyHdrTemplateId).Selected = True
                    Me.FocusControl(Me.RadComboBoxAlertAssignmentTemplate)
                    Me.SetStatesAndEmployees(JobAlertNotifyHdrTemplateId)
                    Me.SetDefaultSubject()

                    Preset = True

                End If

            End If

            Me.CheckForBoard()

            Return Preset

        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Sub CheckToCopyAlertCommentsAndAttachments(ByVal AlertID As Integer)

        'objects
        Dim DocumentRepository As DocumentRepository = Nothing
        Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
        Dim DocumentPrefix As String = ""
        Dim NewDocument As AdvantageFramework.Database.Entities.Document = Nothing
        Dim CopyFromAlert As AdvantageFramework.Database.Entities.Alert = Nothing
        Dim AlertCommentGeneratedDate As Date = Nothing

        If _CopyFromAlertID <> 0 AndAlso AlertID <> 0 Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                CopyFromAlert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, _CopyFromAlertID)

                If CopyFromAlert IsNot Nothing Then

                    If CheckBoxCopyComments.Checked Then

                        For Each AlertComment In CopyFromAlert.AlertComments

                            AlertCommentGeneratedDate = AlertComment.GeneratedDate.GetValueOrDefault(Now)

                            AdvantageFramework.Database.Procedures.AlertComment.Insert(DbContext, AlertID, AlertComment.UserCode, AlertCommentGeneratedDate, AlertComment.Comment, False, Nothing)

                        Next

                    End If

                    If CheckBoxCopyAttachments.Checked Then

                        DocumentRepository = New DocumentRepository(Me.ConnectionString)

                        For Each AlertAttachment In CopyFromAlert.AlertAttachments

                            DocumentPrefix = ""
                            Document = Nothing

                            Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, AlertAttachment.DocumentID)

                            If Document IsNot Nothing Then

                                If Document.FileSystemFileName.StartsWith("d_") Then

                                    DocumentPrefix = "d_"

                                Else

                                    DocumentPrefix = "a_"

                                End If

                                NewDocument = New AdvantageFramework.Database.Entities.Document

                                NewDocument.DbContext = DbContext
                                NewDocument.FileName = Document.FileName
                                NewDocument.FileSystemFileName = DocumentRepository.AddDocument(Document.FileName, DocumentRepository.GetDocument(Document.FileSystemFileName), "", "", Session("UserCode").ToString, "New Alert", "Attached Doc", DocumentPrefix)
                                NewDocument.MIMEType = Document.MIMEType
                                NewDocument.Description = Document.Description
                                NewDocument.Keywords = Document.Keywords
                                NewDocument.UploadedDate = Now
                                NewDocument.UserCode = Session("UserCode").ToString
                                NewDocument.FileSize = Document.FileSize
                                NewDocument.IsPrivate = Document.IsPrivate.GetValueOrDefault(Nothing)
                                NewDocument.DocumentTypeID = Document.DocumentTypeID.GetValueOrDefault(Nothing)

                                If AdvantageFramework.Database.Procedures.Document.Insert(DbContext, NewDocument) Then

                                    AdvantageFramework.Database.Procedures.AlertAttachment.Insert(DbContext, AlertID, AlertAttachment.UserCode, AlertAttachment.GeneratedDate, AlertAttachment.HasEmailBeenSent, NewDocument.ID, Nothing)

                                End If

                            End If

                        Next

                    End If

                End If

            End Using

        End If

    End Sub
    Private Function SaveAssignment(ByVal AlertId As Integer, ByRef ErrorMessage As String) As Boolean

        Dim SavedCorrectly As Boolean = False
        ErrorMessage = ""

        If Me.HasNotifyAssignment = True Then

            Dim ThisAlrtNotifyHdrId As Integer = 0
            Dim ThisAlertState As Integer = 0
            Dim ThisCurrentEmp As String = ""

            Try
                If Me.RadComboBoxAlertAssignmentTemplate.SelectedIndex > 0 Then
                    ThisAlrtNotifyHdrId = CType(Me.RadComboBoxAlertAssignmentTemplate.SelectedValue, Integer)
                End If
            Catch ex As Exception

                ThisAlrtNotifyHdrId = 0

            End Try

            If ThisAlrtNotifyHdrId > 0 Then

                Try

                    If Me.RadTreeViewStates.Nodes.Count > 0 Then

                        ThisAlertState = CType(Me.RadTreeViewStates.SelectedNode.Value, Integer)

                    End If

                Catch ex As Exception

                    ThisAlertState = 0

                End Try

                If ThisAlertState > 0 Then

                    Try
                        If Me.RadComboBoxAssignTo.Items.Count > 0 Then
                            If Me.RadComboBoxAssignTo.SelectedIndex > 0 Then
                                ThisCurrentEmp = Me.RadComboBoxAssignTo.SelectedValue
                            End If
                        End If
                    Catch ex As Exception

                        ThisCurrentEmp = ""

                    End Try

                    Dim a As New cAlerts()
                    SavedCorrectly = a.SaveNotifyAssignmentAlertRecipient(AlertId, ThisCurrentEmp, 0, ThisAlertState, ThisAlrtNotifyHdrId, "", True, Me.ChkIsAlertAssignment.Checked, ErrorMessage)

                End If

            End If

        End If

        Return SavedCorrectly

    End Function

    Private Sub BindRadComboBoxAlertLevel()
        With Me.RadComboBoxAlertLevel.Items
            .Clear()
            If Me.IsClientPortal = True Then
                .Add(New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))
                .Add(New Telerik.Web.UI.RadComboBoxItem("Client", "CL"))
                If Request.QueryString("pagetype") <> "jr" Then
                    .Add(New Telerik.Web.UI.RadComboBoxItem("Job/Component", "JC"))
                End If
                Select Case Me.App
                    Case Source_App.ProjectSchedule, Source_App.ProjectSchedule_Alerts
                        .Add(New Telerik.Web.UI.RadComboBoxItem("Project Schedule", "PS"))
                End Select
            ElseIf Request.QueryString("pagetype") = "jr" Then
                .Add(New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))
                .Add(New Telerik.Web.UI.RadComboBoxItem("Client", "CL"))
                .Add(New Telerik.Web.UI.RadComboBoxItem("Division", "DI"))
                .Add(New Telerik.Web.UI.RadComboBoxItem("Product", "PR"))
            Else
                .Add(New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))
                .Add(New Telerik.Web.UI.RadComboBoxItem("Office", "OF"))
                .Add(New Telerik.Web.UI.RadComboBoxItem("Client", "CL"))
                .Add(New Telerik.Web.UI.RadComboBoxItem("Division", "DI"))
                .Add(New Telerik.Web.UI.RadComboBoxItem("Product", "PR"))
                .Add(New Telerik.Web.UI.RadComboBoxItem("Campaign", "CM"))
                .Add(New Telerik.Web.UI.RadComboBoxItem("Job", "JO"))
                .Add(New Telerik.Web.UI.RadComboBoxItem("Job/Component", "JC"))
                Select Case Me.App
                    Case Source_App.Estimate
                        .Add(New Telerik.Web.UI.RadComboBoxItem("Estimate", "ES"))
                    Case Source_App.EstimateComponent
                        .Add(New Telerik.Web.UI.RadComboBoxItem("Estimate Component", "EST"))
                    Case Source_App.ProjectSchedule, Source_App.ProjectSchedule_Alerts
                        .Add(New Telerik.Web.UI.RadComboBoxItem("Project Schedule", "PS"))
                    Case Source_App.PurchaseOrder
                        .Add(New Telerik.Web.UI.RadComboBoxItem("Purchase Order", "PO"))
                    Case Source_App.MediaATB
                        .Add(New Telerik.Web.UI.RadComboBoxItem("Authorization to Buy", "AB"))
                End Select
            End If

        End With
    End Sub
    Private Sub SetAlertRecipientsForNotifyEmployeeTask()

        Try

            If Me.JobNumber = 0 Or Me.JobComponentNbr = 0 Then

                Me.JobNumber = CType(Me.txtJob.Text, Integer)
                Me.JobComponentNbr = CType(Me.txtComponent.Text, Integer)

            End If

        Catch ex As Exception

            Me.JobNumber = 0
            Me.JobComponentNbr = 0

        End Try
        If Me.RadioNotifyEmployeesTask.Checked = True And Me.JobNumber > 0 And Me.JobComponentNbr > 0 Then

            Me.AutoCompleteRecipients.Clear() 'Me.TxtRecipients.Value = ""

            Dim s As New cSchedule(Session("ConnString"), Session("UserCode"))
            Dim dt As New DataTable

            Select Case Me.App
                Case Source_App.ProjectSchedule, Source_App.ProjectSchedule_Alerts

                    dt = s.NotifyGetTasksEmployees(Me.JobNumber, Me.JobComponentNbr)

            End Select

            Try
                If Not dt Is Nothing Then

                    If dt.Rows.Count > 0 Then

                        Dim str As String = ""

                        For i As Integer = 0 To dt.Rows.Count - 1

                            str &= dt.Rows(i)("EMP_CODE") & ","

                        Next

                        str = MiscFN.RemoveDuplicatesFromString(str, ",")
                        str = MiscFN.RemoveTrailingDelimiter(str, ",")
                        Me.AutoCompleteRecipients.AddEntries(str)

                    End If

                End If
            Catch ex As Exception

                Me.ShowMessage(AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString()))

            End Try

        End If

    End Sub
    Private Sub UploadDocumentToProofHQ(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentID As Long, ByVal Agency As AdvantageFramework.Database.Entities.Agency)

        'objects
        Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
        Dim ProofHQUrl As String = ""
        Dim ByteFile() As Byte = Nothing
        Dim ProofHQFileID As Integer = 0

        Try

            If Agency IsNot Nothing Then

                Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, DocumentID)

                If Document IsNot Nothing Then

                    If AdvantageFramework.FileSystem.Download(Agency, Document, ByteFile) Then

                        If AdvantageFramework.ProofHQ.UploadFile(DbContext, DataContext, _Session.User.EmployeeCode, ByteFile, Document.FileName, Document.FileName, "", "", 0, ProofHQUrl, ProofHQFileID) Then

                            Document.ProofHQUrl = ProofHQUrl

                            AdvantageFramework.Database.Procedures.Document.Update(DbContext, Document)

                        End If

                    End If

                End If

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub RadGridDraftAttachemnts_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridDraftAttachemnts.NeedDataSource

        If Me._DraftAlertID > 0 Then

            Dim oAlerts As cAlerts = New cAlerts(_Session.ConnectionString)
            Me.RadGridDraftAttachemnts.DataSource = oAlerts.GetAlertAttachments(Me._DraftAlertID)

        Else

            Me.RadGridDraftAttachemnts.DataSource = Nothing

        End If

        Me.DivDraftAttachments.Visible = Me._DraftAlertID > 0

    End Sub
    Private Sub RadGridDraftAttachemnts_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGridDraftAttachemnts.ItemCommand
        If e.Item Is Nothing Then Exit Sub

        'objects
        Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim AlertAttachment As AdvantageFramework.Database.Entities.AlertAttachment = Nothing
        Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
        Dim URL As String = ""

        If e.Item IsNot Nothing AndAlso e.Item.ItemIndex > -1 Then

            CurrentGridDataItem = RadGridDraftAttachemnts.Items(e.Item.ItemIndex)

        End If
        If CurrentGridDataItem IsNot Nothing Then

            Select Case e.CommandName
                Case "DeleteRow"

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString.ToString(), Me._Session.UserCode.ToString())

                        AlertAttachment = AdvantageFramework.Database.Procedures.AlertAttachment.LoadByAlertAttachmentID(DbContext, CurrentGridDataItem.GetDataKeyValue("ATTACHMENT_ID"))

                        If AlertAttachment IsNot Nothing Then

                            Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, AlertAttachment.DocumentID)

                            If Document IsNot Nothing Then

                                Dim DeleteFromRepository As Boolean = False
                                Dim DocumentRepository As DocumentRepository = Nothing
                                Dim DeletedFromAlert As Boolean = False

                                DocumentRepository = New DocumentRepository(Me._Session.ConnectionString)

                                If Document.FileSystemFileName.StartsWith("a_") Then

                                    DeleteFromRepository = True

                                End If

                                If DeleteFromRepository = True Then

                                    If DocumentRepository.DeleteDocument(Document.ID, Document.FileSystemFileName) Then

                                        If AdvantageFramework.Database.Procedures.AlertAttachment.Delete(DbContext, AlertAttachment) Then

                                            For Each DocumentAlertAttachment In AdvantageFramework.Database.Procedures.AlertAttachment.LoadByDocumentID(DbContext, AlertAttachment.DocumentID)

                                                AdvantageFramework.Database.Procedures.AlertAttachment.Delete(DbContext, DocumentAlertAttachment)

                                            Next

                                            AdvantageFramework.Database.Procedures.Document.Delete(DbContext, Document)

                                        End If

                                    End If

                                Else

                                    If AdvantageFramework.Database.Procedures.AlertAttachment.Delete(DbContext, AlertAttachment) Then

                                        For Each DocumentAlertAttachment In AdvantageFramework.Database.Procedures.AlertAttachment.LoadByDocumentID(DbContext, AlertAttachment.DocumentID)

                                            AdvantageFramework.Database.Procedures.AlertAttachment.Delete(DbContext, DocumentAlertAttachment)

                                        Next

                                    End If

                                End If

                            End If

                        End If

                    End Using
            End Select

        End If

    End Sub
    Private Sub RadGridDraftAttachemnts_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGridDraftAttachemnts.ItemDataBound
        Dim Filename As String = Nothing
        Dim Description As String = Nothing

        If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then

            Dim SizeCell As Integer = 4
            Dim ProofHQURL As String = ""
            Try

                If IsDBNull(e.Item.DataItem("PROOFHQ_URL")) = False AndAlso String.IsNullOrWhiteSpace(e.Item.DataItem("PROOFHQ_URL")) = False Then

                    ProofHQURL = e.Item.DataItem("PROOFHQ_URL")

                End If

            Catch ex As Exception

                ProofHQURL = ""

            End Try

            'Filename & Description could be DbNull
            If Not IsDBNull(e.Item.DataItem("FILENAME")) Then

                Filename = e.Item.DataItem("FILENAME")

            End If

            If Not IsDBNull(e.Item.DataItem("DESCRIPTION")) Then

                Description = e.Item.DataItem("DESCRIPTION")

            End If

            AdvantageFramework.Web.Presentation.Controls.SetRadgridDocumentColumns(DirectCast(e.Item.FindControl("ImageButtonDelete"), ImageButton),
                                                                                   DirectCast(e.Item.FindControl("LinkButtonDownload"), LinkButton),
                                                                                   DirectCast(e.Item.FindControl("DivAddComments"), HtmlControls.HtmlControl), DirectCast(e.Item.FindControl("ImageButtonAddComments"), ImageButton),
                                                                                   DirectCast(e.Item.FindControl("DivDigitallySign"), HtmlControls.HtmlControl), DirectCast(e.Item.FindControl("LinkButtonDigitallySign"), LinkButton),
                                                                                   DirectCast(e.Item.FindControl("DivDocumentHistory"), HtmlControls.HtmlControl), DirectCast(e.Item.FindControl("LinkButtonDocumentHistory"), LinkButton),
                                                                                   DirectCast(e.Item.FindControl("DivDocumentType"), HtmlControls.HtmlControl), DirectCast(e.Item.FindControl("LinkButtonDocumentType"), LinkButton),
                                                                                   DirectCast(e.Item.FindControl("DivProofHQ"), HtmlControls.HtmlControl), DirectCast(e.Item.FindControl("LinkButtonProofHQ"), LinkButton), ProofHQURL,
                                                                                   e.Item.Cells(SizeCell).Text,
                                                                                   e.Item.DataItem("DOCUMENT_ID"), e.Item.DataItem("MIME_TYPE"), Filename, e.Item.DataItem("REPOSITORY_FILENAME"), Description, e.Item.DataItem("FILE_SIZE"),
                                                                                   "", "", Me._DraftAlertID)

            e.Item.Attributes.Add("DocumentId", e.Item.DataItem("DOCUMENT_ID"))

            Dim Alert As New Alert(Me._Session.ConnectionString)
            Alert.LoadByPrimaryKey(Me._DraftAlertID)
            Dim by As String = e.Item.Cells(5).Text.Trim

            Try

                If by = "&nbsp;" Then

                    Dim oAlerts As New cAlerts(Me._Session.ConnectionString)
                    Dim str As String = oAlerts.GetAlertClientContact(CInt(e.Item.Cells(7).Text))
                    e.Item.Cells(5).Text = str

                End If

            Catch ex As Exception

            End Try

        End If

    End Sub


#End Region

End Class
