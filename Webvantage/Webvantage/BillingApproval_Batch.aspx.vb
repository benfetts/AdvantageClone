Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports Telerik.Web.UI
Imports System.Drawing

Partial Public Class BillingApproval_Batch
    Inherits Webvantage.BaseChildPage

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

    Private Property BatchID As Integer
        Get

            If ViewState("BatchID") Is Nothing Then ViewState("BatchID") = 0
            Return CType(ViewState("BatchID"), Integer)

        End Get
        Set(value As Integer)

            ViewState("BatchID") = value

        End Set
    End Property
    Private CanEditBatch As Boolean = False
    Private BaExists As Boolean = False
    Protected WithEvents LabelCurrentStatus As System.Web.UI.WebControls.Label
    Protected WithEvents LabelAlertStatus As System.Web.UI.WebControls.Label
    Protected WithEvents ImageStatus As System.Web.UI.WebControls.Image


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Billing_BillingApprovalBatch)
        Me.LabelCurrentStatus = CType(Me.RadToolBarButtonCurrentStatus.FindControl("LabelCurrentStatus"), System.Web.UI.WebControls.Label)
        Me.LabelAlertStatus = CType(Me.RadToolBarButtonAlertStatus.FindControl("LabelAlertStatus"), System.Web.UI.WebControls.Label)
        Me.ImageStatus = CType(Me.RadToolBarButtonImageStatus.FindControl("ImageStatus"), System.Web.UI.WebControls.Image)

        Try

            BatchID = CType(Request.QueryString("BAID"), Integer)

        Catch ex As Exception
            BatchID = 0
        End Try

        Dim GoBack As Boolean = False
        Dim ReloadBatch As Boolean = False

        If Not Me.IsPostBack = True And Not Me.IsCallback = True Then

            Me.RadToolbarBillingApprovalBatch.FindItemByValue("Bookmark").Visible = Me.EnableBookmarks

            If BatchID = 0 Then 'new rec

                Me.CanEditBatch = True

                LoadPostingPeriods(True)
                SetCDPCToAll()
                LoadAEListbox()
                LoadPMListbox()

                SetManagerType()

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

                'disable finish and delete buttons
                Me.RadToolBarButtonFinished.Enabled = False
                Me.RadToolBarButtonDelete.Enabled = False
                Me.RbOpenJobsWithoutUnbilledRecords.Checked = True

                Me.RadToolbarBillingApprovalBatch.FindItemByValue("Bookmark").Visible = False

                Me.RadDatePickerBatchDate.SelectedDate = Today.Date
                'Me.RadDatePickerBatchDate.DateInput.Text = Today.Date

            Else

                LoadPostingPeriods(False)
                LoadBatch(BatchID)

            End If

            'Load Lookups:
            LoadLookups(Me.CanEditBatch)

            If Me.CanEditBatch = True Then
                'Me.TxtBatchDescription.Focus()
                Me.FocusControl(Me.TxtBatchDescription)
            End If

            Dim sched As New cSchedule()
            Me.LabelProjectManagerTitle.Text = sched.GetManagerLabel()

        End If

        Try

            If Session("BA_BATCH_GO_BACK") = "1" Then

                Dim m As String = ""
                Dim y As String = ""

                If MiscFN.ValidDate(Me.RadDatePickerBatchDate) Then

                    Dim s As Date = Me.RadDatePickerBatchDate.SelectedDate
                    m = s.Month.ToString().PadLeft(2, "0")
                    y = s.Year.ToString()

                End If

                Dim q As New AdvantageFramework.Web.QueryString()
                With q
                    .Page = "BillingApproval_View.aspx"
                    .Month = m
                    .Year = y
                    .Go()
                End With

            End If

        Catch ex As Exception
        End Try

    End Sub

    Private Sub SetFormEdit(ByVal bEdit As Boolean)
        Me.RadToolBarButtonSave.Enabled = CanEditBatch
        Me.TxtBatchDescription.Enabled = CanEditBatch
        Me.RadDatePickerBatchDate.Enabled = CanEditBatch
        Me.TxtEmployeeCode.Enabled = CanEditBatch
        Me.TxtEmployeeDescription.Enabled = CanEditBatch
        Me.RadDatePickerDateCutoff.Enabled = CanEditBatch
        Me.DropPostingPeriod.Enabled = CanEditBatch
        'ae listbox?

        Me.RblSelectionLevel.Enabled = CanEditBatch
        'selection listbox?

        Me.EnableProductionCheckboxes(CanEditBatch)

    End Sub

    Private Sub EnableProductionCheckboxes(ByVal Enabled As Boolean)
        Me.RbOpenJobsWithoutUnbilledRecords.Enabled = Enabled
        Me.ChkFeeTimeRecords.Enabled = Enabled
        Me.ChkNonBillableRecords.Enabled = Enabled
        Me.RbOpenJobsWithoutUnbilledRecords.Enabled = Enabled
        Me.RbOpenJobsWithUnbilledRecordsOnly.Enabled = Enabled
        Me.RbAllOpenJobs.Enabled = Enabled
    End Sub

    Private Sub SetListboxSelecteItems(ByVal dtSource As DataTable, ByVal lb As Telerik.Web.UI.RadListBox)
        If dtSource.Rows.Count > 0 And lb.Items.Count > 0 Then
            For i As Integer = 0 To dtSource.Rows.Count - 1
                If IsDBNull(dtSource.Rows(i)("SELECTED_VALUES")) = False Then
                    Try
                        lb.FindItemByValue(dtSource.Rows(i)("SELECTED_VALUES")).Selected = True
                    Catch ex As Exception
                    End Try
                End If
            Next
        End If
    End Sub

    Private Sub SetCDPCToAll()
        'Set default for CDPC selection:
        Me.RblSelectionLevel.SelectedIndex = 0
        With Me.LbCDPCSelections
            .Items.Clear()
            .Enabled = False
            .Items.Insert(0, New Telerik.Web.UI.RadlistBoxItem("ALL", "ALL"))
        End With
    End Sub

    Private StrAEs As String = ""
    Private Sub LoadAEListbox()
        'Load ae's
        Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))
        With Me.LbAEs
            .DataSource = oDD.GetAccountExecsBillingApprovalBatch()
            .DataTextField = "description"
            .DataValueField = "code"
            .DataBind()
            .Items.Insert(0, New Telerik.Web.UI.RadListBoxItem("ALL", "ALL"))
        End With
    End Sub

    Private StrPMs As String = ""
    Private Sub LoadPMListbox()
        'Load ae's
        Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))
        With Me.RadListBoxProjectManagers
            .DataSource = oDD.GetManagers(Session("UserCode"))
            .DataTextField = "description"
            .DataValueField = "code"
            .DataBind()
            .Items.Insert(0, New Telerik.Web.UI.RadListBoxItem("ALL", "ALL"))
        End With
    End Sub

    Private Sub LoadLookups(ByVal bEnable As Boolean)
        If bEnable = True Then
            Me.HlEmployee.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.TxtEmployeeCode.ClientID & "&type=empns');return false;")
        End If
    End Sub

    Private Sub LoadPostingPeriods(ByVal SetCurrent As Boolean)
        Dim b As New cBillingApproval(Session("ConnString"), Session("UserCode"))
        If SetCurrent = False Then 'for loading an existing batch. set default based on loadbatch value
            With Me.DropPostingPeriod
                .DataSource = b.GetPostingPeriods
                .DataTextField = "PPPERIOD"
                .DataValueField = "PPPERIOD"
                .DataBind()
                '.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[All]", "All"))
            End With
        Else 'new batch
            Me.DropPostingPeriod.Items.Clear()
            Dim sdr As SqlDataReader
            sdr = b.GetPostingPeriods
            While sdr.Read
                If Not sdr.IsDBNull(0) = True Then
                    Dim itm As New Telerik.Web.UI.RadComboBoxItem
                    With itm
                        .Text = sdr.GetValue(0).ToString()
                        .Value = sdr.GetValue(0).ToString()
                        If Not sdr.IsDBNull(1) = True Then
                            If sdr.GetValue(1).ToString() = "C" Then
                                .Selected = True
                            Else
                                .Selected = False
                            End If
                        Else
                            .Selected = False
                        End If
                    End With
                    Me.DropPostingPeriod.Items.Add(itm)
                End If
            End While
        End If

    End Sub

    Private Sub RblSelectionLevel_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RblSelectionLevel.SelectedIndexChanged
        Me.LoadCDPCListBox()
    End Sub

    Private Sub LoadCDPCListBox()
        Me.LbCDPCSelections.Items.Clear()

        Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))
        With Me.LbCDPCSelections
            Select Case Me.RblSelectionLevel.SelectedValue
                Case "CDPC"
                    .Enabled = False
                    .Items.Insert(0, New Telerik.Web.UI.RadListBoxItem("ALL", "ALL"))
                    Exit Sub
                Case "CLIENT"
                    .Enabled = True
                    .DataSource = oDD.GetClientList(Session("UserCode"))
                Case "DIVISION"
                    .Enabled = True
                    .DataSource = oDD.GetDivisionsAll(Session("UserCode"))
                Case "PRODUCT"
                    .Enabled = True
                    .DataSource = oDD.GetProductsAll(Session("UserCode"))
                Case "CAMPAIGN"
                    .Enabled = True
                    .DataSource = oDD.GetAllCampaignsWithCDP(Session("UserCode"))
            End Select
            .DataValueField = "Code"
            .DataTextField = "Description"
            .DataBind()
        End With
    End Sub

    Private Sub LoadBatch(ByVal iBatchID As Integer)
        Try
            Dim b As New cBillingApproval(Session("ConnString"), Session("UserCode"))
            Dim dsBatchDetails As New DataSet
            Dim dtBatchHeader As New DataTable
            Dim dtBatchAEs As New DataTable
            Dim dtBatchPMs As New DataTable
            Dim dtBatchCDPC As New DataTable
            Dim dtPageSettings As New DataTable

            Dim LoadLevel As String = "CDPC"

            dsBatchDetails = b.GetBatchDetails(iBatchID)
            dtBatchHeader = dsBatchDetails.Tables(0)
            dtBatchAEs = dsBatchDetails.Tables(1)
            dtBatchPMs = dsBatchDetails.Tables(2)
            dtBatchCDPC = dsBatchDetails.Tables(3)
            dtPageSettings = dsBatchDetails.Tables(4)



            If IsDBNull(dtBatchHeader.Rows(0)("LOAD_LEVEL")) = False Then
                LoadLevel = dtBatchHeader.Rows(0)("LOAD_LEVEL")
            End If

            If IsDBNull(dtBatchHeader.Rows(0)("BA_BATCH_ID")) = False Then
                Me.LblBatchID.Text = dtBatchHeader.Rows(0)("BA_BATCH_ID").ToString().PadLeft(6, "0")
            Else
                Me.LblBatchID.Text = "[New]"
            End If

            If IsDBNull(dtBatchHeader.Rows(0)("BA_BATCH_DESC")) = False Then
                Me.TxtBatchDescription.Text = dtBatchHeader.Rows(0)("BA_BATCH_DESC")
            Else
                Me.TxtBatchDescription.Text = ""
            End If
            If IsDBNull(dtBatchHeader.Rows(0)("BATCH_DATE")) = False Then
                Me.RadDatePickerBatchDate.SelectedDate = cGlobals.wvCDate(dtBatchHeader.Rows(0)("BATCH_DATE"))
            End If
            If IsDBNull(dtBatchHeader.Rows(0)("DATE_CUTOFF")) = False Then
                Me.RadDatePickerDateCutoff.SelectedDate = cGlobals.wvCDate(dtBatchHeader.Rows(0)("DATE_CUTOFF"))
            End If
            If IsDBNull(dtBatchHeader.Rows(0)("PERIOD_CUTOFF")) = False Then
                MiscFN.RadComboBoxSetIndex(Me.DropPostingPeriod, dtBatchHeader.Rows(0)("PERIOD_CUTOFF").ToString(), True)
            Else
                Me.LoadPostingPeriods(True)
            End If
            If IsDBNull(dtBatchHeader.Rows(0)("EMP_CODE")) = False Then
                Me.TxtEmployeeCode.Text = dtBatchHeader.Rows(0)("EMP_CODE")
            Else
                Me.TxtEmployeeCode.Text = ""
            End If
            If IsDBNull(dtBatchHeader.Rows(0)("EMP_FML_NAME")) = False Then
                Me.TxtEmployeeDescription.Text = dtBatchHeader.Rows(0)("EMP_FML_NAME")
            Else
                Me.TxtEmployeeDescription.Text = ""
            End If
            Try
                If IsDBNull(dtBatchHeader.Rows(0)("SEL_OPTION")) = False Then
                    Dim i As Integer = 0
                    If IsNumeric(dtBatchHeader.Rows(0)("SEL_OPTION")) = True Then
                        i = CType(dtBatchHeader.Rows(0)("SEL_OPTION"), Integer)
                    End If
                    Select Case i
                        Case 0
                            Me.RbOpenJobsWithoutUnbilledRecords.Checked = False
                            Me.RbOpenJobsWithUnbilledRecordsOnly.Checked = False
                            Me.RbAllOpenJobs.Checked = True
                        Case 1
                            Me.RbOpenJobsWithoutUnbilledRecords.Checked = True
                            Me.RbOpenJobsWithUnbilledRecordsOnly.Checked = False
                            Me.RbAllOpenJobs.Checked = False
                        Case 2
                            Me.RbOpenJobsWithoutUnbilledRecords.Checked = False
                            Me.RbOpenJobsWithUnbilledRecordsOnly.Checked = True
                            Me.RbAllOpenJobs.Checked = False
                    End Select
                    ''If Me.RbOpenJobsWithoutUnbilledRecords.Checked = True Or Me.RbOpenJobsWithUnbilledRecordsOnly.Checked = True Then
                    ''    Me.ChkFeeTimeRecords.Enabled = False
                    ''    Me.ChkNonBillableRecords.Enabled = False
                    ''ElseIf Me.RbAllOpenJobs.Checked = True Then
                    Me.ChkFeeTimeRecords.Enabled = True
                    Me.ChkNonBillableRecords.Enabled = True
                    ''End If
                End If
            Catch ex As Exception
            End Try

            If IsDBNull(dtBatchHeader.Rows(0)("MANAGER_TYPE")) = False Then
                Select Case CType(dtBatchHeader.Rows(0)("MANAGER_TYPE"), Integer)
                    Case 0
                        Me.RadioButtonManagerTypeAE.Checked = True
                        Me.RadioButtonManagerTypePM.Checked = False
                    Case 1
                        Me.RadioButtonManagerTypeAE.Checked = False
                        Me.RadioButtonManagerTypePM.Checked = True
                End Select
                Me.SetManagerType()
            End If

            'If IsDBNull(dtBatchHeader.Rows(0)("INCL_NO_DTL")) = False Then
            '    Me.ChkBxLstProductionOptions.Items(0).Selected = dtBatchHeader.Rows(0)("INCL_NO_DTL") 'MiscFN.IntToBool(dtBatchHeader.Rows(0)("INCL_NO_DTL"))
            'End If
            If IsDBNull(dtBatchHeader.Rows(0)("INCL_NB")) = False Then
                Me.ChkNonBillableRecords.Checked = dtBatchHeader.Rows(0)("INCL_NB") 'MiscFN.IntToBool(dtBatchHeader.Rows(0)("INCL_NB"))
            End If
            If IsDBNull(dtBatchHeader.Rows(0)("INCL_FEE")) = False Then
                Me.ChkFeeTimeRecords.Checked = dtBatchHeader.Rows(0)("INCL_FEE") 'MiscFN.IntToBool(dtBatchHeader.Rows(0)("INCL_FEE"))
            End If

            If IsDBNull(dtBatchHeader.Rows(0)("INCL_INT")) = False Then
                Me.ChkBxLstMediaOptions.Items(0).Selected = dtBatchHeader.Rows(0)("INCL_INT") 'MiscFN.IntToBool(dtBatchHeader.Rows(0)("INCL_INT"))
            End If
            If IsDBNull(dtBatchHeader.Rows(0)("INCL_MAG")) = False Then
                Me.ChkBxLstMediaOptions.Items(1).Selected = dtBatchHeader.Rows(0)("INCL_MAG") 'MiscFN.IntToBool(dtBatchHeader.Rows(0)("INCL_MAG"))
            End If
            If IsDBNull(dtBatchHeader.Rows(0)("INCL_NP")) = False Then
                Me.ChkBxLstMediaOptions.Items(2).Selected = dtBatchHeader.Rows(0)("INCL_NP") 'MiscFN.IntToBool(dtBatchHeader.Rows(0)("INCL_NP"))
            End If
            If IsDBNull(dtBatchHeader.Rows(0)("INCL_OD")) = False Then
                Me.ChkBxLstMediaOptions.Items(3).Selected = dtBatchHeader.Rows(0)("INCL_OD") 'MiscFN.IntToBool(dtBatchHeader.Rows(0)("INCL_OD"))
            End If
            If IsDBNull(dtBatchHeader.Rows(0)("INCL_RA")) = False Then
                Me.ChkBxLstMediaOptions.Items(4).Selected = dtBatchHeader.Rows(0)("INCL_RA") 'MiscFN.IntToBool(dtBatchHeader.Rows(0)("INCL_RA"))
            End If
            If IsDBNull(dtBatchHeader.Rows(0)("INCL_TV")) = False Then
                Me.ChkBxLstMediaOptions.Items(5).Selected = dtBatchHeader.Rows(0)("INCL_TV") 'MiscFN.IntToBool(dtBatchHeader.Rows(0)("INCL_TV"))
            End If
            ''If IsDBNull(dtBatchHeader.Rows(0)("APPR_METHOD")) = False Then
            ''    Me.RblApprovalMethod.SelectedIndex = CType(dtBatchHeader.Rows(0)("APPR_METHOD"), Integer)
            ''End If
            If IsDBNull(dtBatchHeader.Rows(0)("STATUS")) = False Then
                LabelCurrentStatus.Text = dtBatchHeader.Rows(0)("STATUS").ToString()
            End If
            If IsDBNull(dtBatchHeader.Rows(0)("ALERT_STATUS")) = False Then
                Me.LabelAlertStatus.Text = dtBatchHeader.Rows(0)("ALERT_STATUS").ToString()
            End If
            If IsDBNull(dtBatchHeader.Rows(0)("JOB_BATCH_COUNT")) = False Then
                LblJobList.Text = "Job List (" & dtBatchHeader.Rows(0)("JOB_BATCH_COUNT").ToString() & ")"
            End If

            'set edit variable:
            ''If IsDBNull(dtBatchHeader.Rows(0)("CREATE_USER")) = False Then
            ''    If dtBatchHeader.Rows(0)("CREATE_USER").ToString().Trim() = Session("UserCode").ToString().Trim() And Me.LblCurrentStatus.Text.Trim() = "Pending" Then
            ''        CanEdit = True
            ''    Else
            ''        CanEdit = False
            ''    End If
            ''End If

            If IsDBNull(dtBatchHeader.Rows(0)("BA_EXISTS")) = False Then
                Dim ceb As Integer = CType(dtBatchHeader.Rows(0)("BA_EXISTS"), Integer)
                If ceb <> 0 Then
                    Me.BaExists = True
                Else
                    Me.BaExists = False
                End If
            End If

            Me.CanEditBatch = True

            Dim CriteriaLocked As Boolean = False
            If CriteriaLocked = False Then
                If IsDBNull(dtBatchHeader.Rows(0)("APPROVED")) = False Then
                    CriteriaLocked = dtBatchHeader.Rows(0)("APPROVED")
                End If
            End If
            If CriteriaLocked = False Then
                If IsDBNull(dtBatchHeader.Rows(0)("FINISHED")) = False Then
                    CriteriaLocked = dtBatchHeader.Rows(0)("FINISHED")
                End If
            End If
            If CriteriaLocked = False Then
                If IsDBNull(dtBatchHeader.Rows(0)("BILLED_ANY")) = False Then
                    CriteriaLocked = dtBatchHeader.Rows(0)("BILLED_ANY")
                End If
            End If
            If CriteriaLocked = False Then
                If IsDBNull(dtBatchHeader.Rows(0)("BILLED_ALL")) = False Then
                    CriteriaLocked = dtBatchHeader.Rows(0)("BILLED_ALL")
                End If
            End If

            'set status image:
            If IsDBNull(dtBatchHeader.Rows(0)("BILLED_ANY")) = False Then
                If dtBatchHeader.Rows(0)("BILLED_ANY") = True Then
                    With Me.ImageStatus
                        .ImageUrl = "~/Images/square_green.png"
                        .AlternateText = "Pending/In Progress"
                        .ToolTip = "Pending/In Progress"
                    End With

                End If
            End If
            If IsDBNull(dtBatchHeader.Rows(0)("APPROVED")) = False Then
                If dtBatchHeader.Rows(0)("APPROVED") = True Then
                    With Me.ImageStatus
                        .ImageUrl = "~/Images/square_yellow.png"
                        .AlternateText = "Approved"
                        .ToolTip = "Approved"
                    End With
                End If
            End If
            If IsDBNull(dtBatchHeader.Rows(0)("FINISHED")) = False Then
                If dtBatchHeader.Rows(0)("FINISHED") = True Then
                    With Me.ImageStatus
                        .ImageUrl = "~/Images/square_red.png"
                        .AlternateText = "Finished"
                        .ToolTip = "Finished"
                    End With
                End If
            End If


            'set finished toggle
            If IsDBNull(dtBatchHeader.Rows(0)("FINISHED")) = False Then
                If dtBatchHeader.Rows(0)("FINISHED") = True Then
                    Me.RadToolBarButtonFinished.Checked = True
                Else
                    Me.RadToolBarButtonFinished.Checked = False
                End If
            End If
            'set finish button
            If IsDBNull(dtBatchHeader.Rows(0)("APPROVED")) = False Then
                If dtBatchHeader.Rows(0)("APPROVED") = True And Me.CanEditBatch = True Then
                    Me.RadToolBarButtonFinished.Enabled = True
                Else
                    Me.RadToolBarButtonFinished.Enabled = False
                End If
            End If

            If Me.CanEditBatch = True Then
                Dim iCanDelete As Integer = 1
                If IsDBNull(dtBatchHeader.Rows(0)("CAN_DELETE")) = False Then
                    iCanDelete = CType(dtBatchHeader.Rows(0)("CAN_DELETE"), Integer)
                End If
                If iCanDelete = 0 Then
                    Me.RadToolBarButtonDelete.Enabled = False
                Else
                    Me.RadToolBarButtonDelete.Enabled = True
                End If
            Else
                Me.RadToolBarButtonDelete.Enabled = False
            End If
            Me.SetFormEdit(Me.CanEditBatch)

            Me.LoadAEListbox()
            Me.SetListboxSelecteItems(dtBatchAEs, Me.LbAEs)

            Me.LoadPMListbox()
            Me.SetListboxSelecteItems(dtBatchPMs, Me.RadListBoxProjectManagers)


            Me.RblSelectionLevel.Items.FindByValue(LoadLevel).Selected = True

            Me.LoadCDPCListBox()

            Me.SetListboxSelecteItems(dtBatchCDPC, Me.LbCDPCSelections)

            If Me.CanEditBatch = False Or CriteriaLocked = True Or BaExists = True Then
                Me.LitAEs.Text = ""
                Me.LitCDPCSelections.Text = ""
                Me.LiteralProjectManagers.Text = ""
                For i As Integer = 0 To Me.LbAEs.Items.Count - 1
                    If Me.LbAEs.Items(i).Selected = True Then
                        Me.LitAEs.Text &= Me.LbAEs.Items(i).Text & "<br/>"
                    End If
                Next
                For j As Integer = 0 To Me.LbCDPCSelections.Items.Count - 1
                    If Me.LbCDPCSelections.Items(j).Selected = True Then
                        Me.LitCDPCSelections.Text &= Me.LbCDPCSelections.Items(j).Text & "<br/>"
                    End If
                Next
                For k As Integer = 0 To Me.RadListBoxProjectManagers.Items.Count - 1
                    If Me.RadListBoxProjectManagers.Items(k).Selected = True Then
                        Me.LiteralProjectManagers.Text &= Me.RadListBoxProjectManagers.Items(k).Text & "<br/>"
                    End If
                Next
                Me.LbAEs.Visible = False
                Me.LbCDPCSelections.Visible = False
                Me.RadListBoxProjectManagers.Visible = False

                Me.RadioButtonManagerTypeAE.Enabled = False
                Me.RadioButtonManagerTypePM.Enabled = False
                Me.RblSelectionLevel.Enabled = False

                Me.RadDatePickerDateCutoff.Enabled = False
                Me.DropPostingPeriod.Enabled = False
                Me.EnableProductionCheckboxes(False)
                Me.ChkBxLstMediaOptions.Enabled = False
                Me.TxtEmployeeCode.Enabled = False
                Me.TxtEmployeeDescription.Enabled = False
                Me.BtnSaveJobListTop.Visible = False
                Me.BtnSaveJobListBottom.Visible = False
                Me.ChkFeeTimeRecords.Enabled = False
                Me.ChkNonBillableRecords.Enabled = False
                Me.RadGridJobList.MasterTableView.GetColumn("ColSelect").Visible = False
            Else
                Me.LitAEs.Text = ""
                Me.LitCDPCSelections.Text = ""
                Me.LiteralProjectManagers.Text = ""
                Me.LbAEs.Visible = True
                Me.LbCDPCSelections.Visible = True
                Me.RadListBoxProjectManagers.Visible = True

                Me.RblSelectionLevel.Enabled = True
                Me.RadioButtonManagerTypeAE.Enabled = True
                Me.RadioButtonManagerTypePM.Enabled = True

                Me.RadDatePickerDateCutoff.Enabled = True
                Me.DropPostingPeriod.Enabled = True
                Me.EnableProductionCheckboxes(True)
                Me.ChkBxLstMediaOptions.Enabled = False
                Me.TxtEmployeeCode.Enabled = True
                Me.TxtEmployeeDescription.Enabled = True
                Me.BtnSaveJobListTop.Visible = True
                Me.BtnSaveJobListBottom.Visible = True
                Me.RadGridJobList.MasterTableView.GetColumn("ColSelect").Visible = True
            End If


            If iBatchID > 0 Then
                With Me.RadToolTipManager1
                    .TargetControls.Clear()
                    .TargetControls.Add(Me.LblBatchIDTitle.ClientID, iBatchID, True)
                End With
                Me.RadToolTipManager1.Enabled = True

                With Me.RadToolTipManager2
                    .TargetControls.Clear()
                    .TargetControls.Add(Me.LblJobList.ClientID, iBatchID, True)
                End With
                Me.RadToolTipManager2.Enabled = True
            Else
                Me.RadToolTipManager1.TargetControls.Clear()
                Me.RadToolTipManager1.Enabled = False

                Me.RadToolTipManager2.TargetControls.Clear()
                Me.RadToolTipManager2.Enabled = False
            End If
            If iBatchID <= 0 Then
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
            Me.RadGridJobList.Rebind()
            Try
                If dtPageSettings.Rows.Count > 0 Then
                    Me.CollapsablePanelJobSelections.Collapsed = Not dtPageSettings.Rows(0)("AGY_SETTINGS_VALUE")
                End If
            Catch ex As Exception
                Me.CollapsablePanelJobSelections.Collapsed = False
            End Try

        Catch ex As Exception

            If Not Request.QueryString("bm") Is Nothing Then
                If Request.QueryString("bm") = "1" Then

                    Me.ShowMessage("Batch is no longer available. Please delete your bookmark.")
                    Me.CloseThisWindow()

                End If
            End If

        End Try
    End Sub

    'work this into a simpler standalone function?
    Private Function CanEditCriteria(ByVal iBatchID As Integer) As Boolean
        If BatchID = 0 Then
            Return False
        End If

        Dim b As New cBillingApproval(Session("ConnString"), Session("UserCode"))
        Dim dsBatchDetails As New DataSet
        Dim dtBatchHeader As New DataTable
        dsBatchDetails = b.GetBatchDetails(iBatchID)
        dtBatchHeader = dsBatchDetails.Tables(0)

        If IsDBNull(dtBatchHeader.Rows(0)("APPROVED")) = False Then
            If dtBatchHeader.Rows(0)("APPROVED") = True Then
                Return False
            End If
        End If
        If IsDBNull(dtBatchHeader.Rows(0)("FINISHED")) = False Then
            If dtBatchHeader.Rows(0)("FINISHED") = True Then
                Return False
            End If
        End If
        If IsDBNull(dtBatchHeader.Rows(0)("BILLED_ANY")) = False Then
            If dtBatchHeader.Rows(0)("BILLED_ANY") = True Then
                Return False
            End If
        End If
        If IsDBNull(dtBatchHeader.Rows(0)("BILLED_ALL")) = False Then
            If dtBatchHeader.Rows(0)("BILLED_ALL") = True Then
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub CreateBatch()
        Try
            Dim sSelectionsBase As String = ""
            Dim sClients As String = ""
            Dim sDivisions As String = ""
            Dim sProducts As String = ""
            Dim sCampaigns As String = ""
            Dim sAEs As String = ""
            Dim sPMs As String = ""
            Dim sLoadLevel As String = Me.RblSelectionLevel.SelectedValue.ToUpper

            'Validate:
            If ValidateData() = False Then
                Exit Sub
            End If

            'Build code strings:
            Me.BuildCodeStrings(sLoadLevel, sSelectionsBase, sClients, sDivisions, sProducts, sCampaigns, sAEs, sPMs)

            'Do insert:
            Dim DateCutoff As String = ""
            Try
                DateCutoff = CType(Me.RadDatePickerDateCutoff.SelectedDate, Date).ToShortDateString()
            Catch ex As Exception
                DateCutoff = ""
            End Try
            Dim BatchDate As String = ""
            Try
                BatchDate = CType(Me.RadDatePickerBatchDate.SelectedDate, Date).ToShortDateString()
            Catch ex As Exception
                BatchDate = ""
            End Try
            Dim b As New cBillingApproval(Session("ConnString"), Session("UserCode"))
            Dim MgrType As Integer = 0
            If Me.RadioButtonManagerTypePM.Checked = True Then
                MgrType = 1
            End If
            Dim strMSG As String = b.BatchAddNew(Me.TxtBatchDescription.Text,
                                                      BatchDate,
                                                      Session("UserCode"),
                                                      Now.Date,
                                                      Session("UserCode"),
                                                      Now.Date,
                                                      DateCutoff,
                                                      Me.DropPostingPeriod.SelectedValue,
                                                      Me.TxtEmployeeCode.Text,
                                                      Me.ChkNonBillableRecords.Checked,
                                                      Me.ChkFeeTimeRecords.Checked,
                                                      Me.ChkBxLstMediaOptions.Items(0).Selected,
                                                      Me.ChkBxLstMediaOptions.Items(2).Selected,
                                                      Me.ChkBxLstMediaOptions.Items(1).Selected,
                                                      Me.ChkBxLstMediaOptions.Items(3).Selected,
                                                      Me.ChkBxLstMediaOptions.Items(4).Selected,
                                                      Me.ChkBxLstMediaOptions.Items(5).Selected,
                                                      False, False, False, False, False,
                                                      0, Me.SetSelOption(), MgrType)

            If IsNumeric(strMSG) = True Then

                BatchID = CType(strMSG, Integer)
                Me.LblBatchID.Text = BatchID.ToString().PadLeft(6, "0")

                'Insert selections:
                If BatchID > 0 Then

                    Me.BillingApprovalBatchCreated()

                    Dim sm As String = Me.SaveSelections(BatchID, sLoadLevel, sAEs, sPMs, sSelectionsBase, True)
                    If sm <> "" Then

                        Me.ShowMessage(sm)

                    Else

                        sm = b.BatchApplyCriteria(BatchID)

                        If sm <> "" Then

                            Me.ShowMessage(sm)

                        Else

                            MiscFN.ResponseRedirect("BillingApproval_Batch.aspx?BAID=" & BatchID.ToString())
                            'LoadPostingPeriods(False)
                            'LoadBatch(BatchID)

                        End If

                    End If

                End If

            Else

                Me.ShowMessage(strMSG)

            End If
        Catch ex As Exception
            Me.ShowMessage("Error creating batch: " & ex.Message.ToString())
        End Try

    End Sub

    Private Sub UpdateBatch()
        Try
            'Update the batch:
            Dim sSelectionsBase As String = ""
            Dim sClients As String = ""
            Dim sDivisions As String = ""
            Dim sProducts As String = ""
            Dim sCampaigns As String = ""
            Dim sAEs As String = ""
            Dim sPMs As String = ""
            Dim sLoadLevel As String = Me.RblSelectionLevel.SelectedValue.ToUpper

            'Validate:
            If ValidateData() = False Then
                Exit Sub
            End If

            'Build code strings:
            Me.BuildCodeStrings(sLoadLevel, sSelectionsBase, sClients, sDivisions, sProducts, sCampaigns, sAEs, sPMs)

            Dim sm As String = ""
            Dim ThisCanEditCriteria As Boolean = CanEditCriteria(CType(Me.LblBatchID.Text, Integer))
            If ThisCanEditCriteria = True Then
                sm = Me.SaveSelections(CType(Me.LblBatchID.Text, Integer), sLoadLevel, sAEs, sPMs, sSelectionsBase, False)
                If sm <> "" Then
                    Me.ShowMessage(sm)
                End If
            End If
            Dim DateCutoff As String = ""
            Try
                DateCutoff = CType(Me.RadDatePickerDateCutoff.SelectedDate, Date).ToShortDateString()
            Catch ex As Exception
                DateCutoff = ""
            End Try
            Dim BatchDate As String = ""
            Try
                BatchDate = CType(Me.RadDatePickerBatchDate.SelectedDate, Date).ToShortDateString()
            Catch ex As Exception
                BatchDate = ""
            End Try
            Dim MgrType As Integer = 0
            If Me.RadioButtonManagerTypePM.Checked = True Then
                MgrType = 1
            End If
            Dim b As New cBillingApproval(Session("ConnString"), Session("UserCode"))
            Dim strMSG As String = b.BatchUpdate(CType(Me.LblBatchID.Text, Integer), _
                                                       Me.TxtBatchDescription.Text, _
                                                       BatchDate, _
                                                       Session("UserCode"), _
                                                       Now.Date, _
                                                       DateCutoff, _
                                                       Me.DropPostingPeriod.SelectedValue, _
                                                       Me.TxtEmployeeCode.Text, _
                                                      Me.ChkNonBillableRecords.Checked, _
                                                      Me.ChkFeeTimeRecords.Checked, _
                                                       Me.ChkBxLstMediaOptions.Items(0).Selected, _
                                                       Me.ChkBxLstMediaOptions.Items(2).Selected, _
                                                       Me.ChkBxLstMediaOptions.Items(1).Selected, _
                                                       Me.ChkBxLstMediaOptions.Items(3).Selected, _
                                                       Me.ChkBxLstMediaOptions.Items(4).Selected, _
                                                       Me.ChkBxLstMediaOptions.Items(5).Selected, _
                                                       0, ThisCanEditCriteria, Me.SetSelOption(), MgrType)
            If strMSG <> "" Then
                Me.ShowMessage(sm & "<br />" & strMSG)
            End If

        Catch ex As Exception
            Me.ShowMessage("Error updating batch:  " & ex.Message.ToString())
        End Try
    End Sub

    Private Function SaveSelections(ByVal BatchID As Integer, ByVal LoadLevel As String, ByVal AESelectionString As String, _
                                    ByVal PMSelectionString As String, ByVal CDPCSelectionString As String, ByVal IsNewBatch As Boolean) As String
        Try
            Dim SbSQL As New System.Text.StringBuilder
            Dim StrSQL As String = ""
            'INSERT INTO BILL_APPR_BATCH_AE (BA_BATCH_ID,AE_EMP_CODE) VALUES (51,'ama');
            'INSERT INTO BILL_APPR_BATCH_CDP (BA_BATCH_ID,CL_CODE,DIV_CODE,PRD_CODE) VALUES (51,'abc','abc','abc');
            'INSERT INTO BILL_APPR_BATCH_CMP (BA_BATCH_ID,CMP_IDENTIFIER) VALUES (51,3);

            If IsNewBatch = False Then 'it's an update, clear out existing data first:
                With SbSQL
                    .Append("DELETE FROM BILL_APPR_BATCH_AE WITH(ROWLOCK) WHERE BA_BATCH_ID = ")
                    .Append(BatchID)
                    .Append(";")
                    .Append("DELETE FROM BILL_APPR_BATCH_PM WITH(ROWLOCK) WHERE BA_BATCH_ID = ")
                    .Append(BatchID)
                    .Append(";")
                    .Append("DELETE FROM BILL_APPR_BATCH_CDP WITH(ROWLOCK) WHERE BA_BATCH_ID = ")
                    .Append(BatchID)
                    .Append(";")
                    .Append("DELETE FROM BILL_APPR_BATCH_CMP WITH(ROWLOCK) WHERE BA_BATCH_ID = ")
                    .Append(BatchID)
                    .Append(";")
                End With
            End If

            If AESelectionString.Trim() <> "" Then
                Dim arAE() As String
                arAE = AESelectionString.Split(",")
                For i As Integer = 0 To arAE.Length - 1
                    With SbSQL
                        .Append("INSERT INTO BILL_APPR_BATCH_AE (BA_BATCH_ID,AE_EMP_CODE) VALUES (")
                        .Append(BatchID.ToString())
                        .Append(",")
                        .Append(arAE(i).ToString())
                        .Append(");")
                    End With
                Next
            End If

            If PMSelectionString.Trim() <> "" Then
                Dim arPM() As String
                arPM = PMSelectionString.Split(",")
                For i As Integer = 0 To arPM.Length - 1
                    With SbSQL
                        .Append("INSERT INTO BILL_APPR_BATCH_PM (BA_BATCH_ID, PM_EMP_CODE) VALUES (")
                        .Append(BatchID.ToString())
                        .Append(",")
                        .Append(arPM(i).ToString())
                        .Append(");")
                    End With
                Next
            End If

            If CDPCSelectionString.Trim() <> "" Then
                Dim j As Integer = 0
                Dim arCDP() As String
                arCDP = CDPCSelectionString.Split(",")
                Select Case LoadLevel
                    Case "CDPC" 'This is "all"...no criteria set
                        'no save needed to cdp and campaign table
                    Case "CLIENT"
                        For j = 0 To arCDP.Length - 1
                            If arCDP(j) <> "" Then
                                With SbSQL
                                    .Append("INSERT INTO BILL_APPR_BATCH_CDP (BA_BATCH_ID,CL_CODE,DIV_CODE,PRD_CODE) VALUES (")
                                    .Append(BatchID.ToString())
                                    .Append(",'")
                                    .Append(arCDP(j).ToString())
                                    .Append("',NULL,NULL);")
                                End With
                            End If
                        Next
                    Case "DIVISION"
                        For j = 0 To arCDP.Length - 1
                            Dim arSplit() As String
                            arSplit = arCDP(j).Split(":")
                            If arSplit(0) <> "" And arSplit(1) <> "" Then
                                With SbSQL
                                    .Append("INSERT INTO BILL_APPR_BATCH_CDP (BA_BATCH_ID,CL_CODE,DIV_CODE,PRD_CODE) VALUES (")
                                    .Append(BatchID.ToString())
                                    .Append(",'")
                                    .Append(arSplit(0).ToString()) 'client code
                                    .Append("','")
                                    .Append(arSplit(1).ToString()) 'division code
                                    .Append("',NULL);")
                                End With
                            End If
                        Next
                    Case "PRODUCT"
                        For j = 0 To arCDP.Length - 1
                            Dim arSplit() As String
                            arSplit = arCDP(j).Split(":")
                            If arSplit(0) <> "" And arSplit(1) <> "" And arSplit(2) <> "" Then
                                With SbSQL
                                    .Append("INSERT INTO BILL_APPR_BATCH_CDP (BA_BATCH_ID,CL_CODE,DIV_CODE,PRD_CODE) VALUES (")
                                    .Append(BatchID.ToString())
                                    .Append(",'")
                                    .Append(arSplit(0).ToString()) 'client code
                                    .Append("','")
                                    .Append(arSplit(1).ToString()) 'division code
                                    .Append("','")
                                    .Append(arSplit(2).ToString()) 'product code
                                    .Append("');")
                                End With
                            End If
                        Next
                    Case "CAMPAIGN"
                        'will need to build the cdp string for insert as well as the cmp identifier string! (?)
                        For j = 0 To arCDP.Length - 1
                            Dim arSplit() As String
                            arSplit = arCDP(j).Split(":")
                            With SbSQL
                                '''CDP:
                                ''.Append("INSERT INTO BILL_APPR_BATCH_CDP (BA_BATCH_ID,CL_CODE,DIV_CODE,PRD_CODE) VALUES (")
                                ''.Append(BatchID.ToString())
                                ''.Append(",'")
                                ''.Append(arSplit(0).ToString()) 'client code
                                ''.Append("','")
                                ''.Append(arSplit(1).ToString()) 'division code
                                ''.Append("','")
                                ''.Append(arSplit(2).ToString()) 'product code
                                ''.Append("');")

                                'CMP IDENTIFIER:
                                .Append("INSERT INTO BILL_APPR_BATCH_CMP (BA_BATCH_ID,CMP_IDENTIFIER) VALUES (")
                                .Append(BatchID.ToString())
                                .Append(",")
                                .Append(arSplit(4).ToString()) 'campaign identifier
                                .Append(");")
                            End With
                        Next

                End Select
            End If

            StrSQL = SbSQL.ToString()

            'Save:
            If StrSQL.Trim() <> "" Then
                Using MyConn As New SqlConnection(Session("ConnString"))
                    MyConn.Open()
                    Dim MyTrans As SqlTransaction = MyConn.BeginTransaction
                    Dim MyCmd As New SqlCommand(StrSQL, MyConn, MyTrans)
                    Try
                        MyCmd.ExecuteNonQuery()
                        MyTrans.Commit()
                    Catch ex As Exception
                        MyTrans.Rollback()
                        Return "Error running selection SQL:&nbsp;&nbsp;" & ex.Message.ToString()
                    Finally
                        If MyConn.State = ConnectionState.Open Then MyConn.Close()
                    End Try
                End Using
            End If
            Return ""
        Catch ex As Exception
            Return "Error saving batch selections:&nbsp;&nbsp;" & ex.Message.ToString()
        End Try
    End Function

    Private Function ValidateData() As Boolean
        If Me.TxtBatchDescription.Text.Trim = "" Then
            Me.ShowMessage("Please enter a batch description")
            Me.FocusControl(Me.TxtBatchDescription)
            Return False
        End If
        If MiscFN.ValidDate(Me.RadDatePickerBatchDate) = False Then
            Me.ShowMessage("Invalid Batch date")
            Return False
        End If
        ''If Me.RblApprovalMethod.SelectedIndex = -1 Then
        ''    Me.ShowMessage("Please select an approval method."
        ''    Me.RblApprovalMethod.Focus()
        ''    Return False
        ''End If
        If Me.TxtEmployeeCode.Text.Trim = "" Then
            Me.ShowMessage("Please assign an employee to this batch")
            Me.FocusControl(Me.TxtEmployeeCode)
            Return False
        End If
        Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
        If myVal.ValidateEmpCode(Me.TxtEmployeeCode.Text) = False Then
            Me.ShowMessage("Please enter a valid employee code")
            Me.FocusControl(Me.TxtEmployeeCode)
            Return False
        End If
        Dim t As cTraffic = New cTraffic(Session("ConnString"), Session("UserCode"))
        If t.IsEmpTerminated(Me.TxtEmployeeCode.Text) = True Then
            Me.ShowMessage("Please enter a valid employee code")
            Me.FocusControl(TxtEmployeeCode)
            Return False
        End If
        If MiscFN.ValidDate(Me.RadDatePickerDateCutoff) = False Then
            Me.ShowMessage("Please enter a valid date cutoff")
            Return False
        End If

        If Me.RblSelectionLevel.SelectedIndex > 0 Then
            Dim HasSelected As Boolean = False
            For j As Integer = 0 To Me.LbCDPCSelections.Items.Count - 1
                If Me.LbCDPCSelections.Items(j).Selected = True Then
                    HasSelected = True
                    Exit For
                End If
            Next
            If HasSelected = False Then
                Me.ShowMessage("Please select at least one " & Me.RblSelectionLevel.SelectedItem.Text)
                Return False
            End If
        End If

        'If Me.TxtPeriodCutoff.Text <> "" Then
        '    If cGlobals.wvIsDate(Me.TxtPeriodCutoff.Text) = False Then
        '        Me.ShowMessage("Invalid period cutoff."
        '        Me.TxtPeriodCutoff.Focus()
        '        Return False
        '    Else
        '        Me.TxtPeriodCutoff.Text = cGlobals.wvCDate(Me.TxtPeriodCutoff.Text).ToShortDateString
        '    End If
        'End If
        Return True
    End Function

    Private Sub BuildCodeStrings(ByVal LoadLevel As String, ByRef StrSelectionsBase As String, ByRef StrClients As String, ByRef StrDivisions As String, _
                                 ByRef StrProducts As String, ByRef StrCampaigns As String, ByRef StrAEs As String, ByRef StrPMs As String)
        'Build code strings:
        '===================================================================================
        'AE's
        If Me.LbAEs.Items(0).Selected = True Then
            For i As Integer = 1 To Me.LbAEs.Items.Count - 1
                StrAEs &= "'" & Me.LbAEs.Items(i).Value & "',"
            Next
        Else
            For i As Integer = 1 To Me.LbAEs.Items.Count - 1
                If Me.LbAEs.Items(i).Selected = True Then
                    StrAEs &= "'" & Me.LbAEs.Items(i).Value & "',"
                End If
            Next
        End If
        StrAEs = MiscFN.RemoveDuplicatesFromString(StrAEs, ",")
        StrAEs = MiscFN.RemoveTrailingDelimiter(StrAEs, ",")

        'PM's
        If Me.RadListBoxProjectManagers.Items(0).Selected = True Then
            For i As Integer = 1 To Me.RadListBoxProjectManagers.Items.Count - 1
                StrPMs &= "'" & Me.RadListBoxProjectManagers.Items(i).Value & "',"
            Next
        Else
            For i As Integer = 1 To Me.RadListBoxProjectManagers.Items.Count - 1
                If Me.RadListBoxProjectManagers.Items(i).Selected = True Then
                    StrPMs &= "'" & Me.RadListBoxProjectManagers.Items(i).Value & "',"
                End If
            Next
        End If
        StrPMs = MiscFN.RemoveDuplicatesFromString(StrPMs, ",")
        StrPMs = MiscFN.RemoveTrailingDelimiter(StrPMs, ",")

        'Selection Level:
        For j As Integer = 0 To Me.LbCDPCSelections.Items.Count - 1
            If Me.LbCDPCSelections.Items(j).Selected = True Then
                StrSelectionsBase &= Me.LbCDPCSelections.Items(j).Value & ","
            End If
        Next
        StrSelectionsBase = MiscFN.RemoveDuplicatesFromString(StrSelectionsBase, ",")
        StrSelectionsBase = MiscFN.RemoveTrailingDelimiter(StrSelectionsBase, ",")

        'Selection Level:
        Dim k As Integer = 0
        Dim ar() As String
        ar = StrSelectionsBase.Split(",")
        Select Case LoadLevel
            Case "CDPC" 'This is "all"...no criteria set
                'Make sure all empty:
                StrClients = ""
                StrDivisions = ""
                StrProducts = ""
                StrCampaigns = ""
            Case "CLIENT"
                'Parse:
                For k = 0 To ar.Length - 1
                    StrClients &= "'" & ar(k).ToString() & "',"
                Next
                StrClients = MiscFN.RemoveDuplicatesFromString(StrClients, ",")
                StrClients = MiscFN.RemoveTrailingDelimiter(StrClients, ",")
                'Make sure empty:
                StrDivisions = ""
                StrProducts = ""
                StrCampaigns = ""
            Case "DIVISION"
                'Parse:
                For k = 0 To ar.Length - 1

                    Dim ar2() As String
                    ar2 = ar(k).Split(":")
                    StrClients &= "'" & ar2(0).ToString() & "',"
                    StrDivisions &= "'" & ar2(1).ToString() & "',"
                Next
                StrClients = MiscFN.RemoveDuplicatesFromString(StrClients, ",")
                StrClients = MiscFN.RemoveTrailingDelimiter(StrClients, ",")
                StrDivisions = MiscFN.RemoveDuplicatesFromString(StrDivisions, ",")
                StrDivisions = MiscFN.RemoveTrailingDelimiter(StrDivisions, ",")

                'Make sure empty:
                StrProducts = ""
                StrCampaigns = ""
            Case "PRODUCT"
                'Parse:
                For k = 0 To ar.Length - 1
                    Dim ar2() As String
                    ar2 = ar(k).Split(":")
                    StrClients &= "'" & ar2(0).ToString() & "',"
                    StrDivisions &= "'" & ar2(1).ToString() & "',"
                    StrProducts &= "'" & ar2(2).ToString() & "',"
                Next
                StrClients = MiscFN.RemoveDuplicatesFromString(StrClients, ",")
                StrClients = MiscFN.RemoveTrailingDelimiter(StrClients, ",")
                StrDivisions = MiscFN.RemoveDuplicatesFromString(StrDivisions, ",")
                StrDivisions = MiscFN.RemoveTrailingDelimiter(StrDivisions, ",")
                StrProducts = MiscFN.RemoveDuplicatesFromString(StrProducts, ",")
                StrProducts = MiscFN.RemoveTrailingDelimiter(StrProducts, ",")

                'Make sure empty:
                StrCampaigns = ""
            Case "CAMPAIGN"
                'Parse all:
                For k = 0 To ar.Length - 1
                    Dim ar2() As String
                    ar2 = ar(k).Split(":")
                    StrClients &= "'" & ar2(0).ToString() & "',"
                    StrDivisions &= "'" & ar2(1).ToString() & "',"
                    StrProducts &= "'" & ar2(2).ToString() & "',"
                    StrCampaigns &= "'" & ar2(3).ToString() & "',"
                Next
                StrClients = MiscFN.RemoveDuplicatesFromString(StrClients, ",")
                StrClients = MiscFN.RemoveTrailingDelimiter(StrClients, ",")
                StrDivisions = MiscFN.RemoveDuplicatesFromString(StrDivisions, ",")
                StrDivisions = MiscFN.RemoveTrailingDelimiter(StrDivisions, ",")
                StrProducts = MiscFN.RemoveDuplicatesFromString(StrProducts, ",")
                StrProducts = MiscFN.RemoveTrailingDelimiter(StrProducts, ",")
                StrCampaigns = MiscFN.RemoveDuplicatesFromString(StrCampaigns, ",")
                StrCampaigns = MiscFN.RemoveTrailingDelimiter(StrCampaigns, ",")
        End Select
    End Sub

    'tooltip:
    Protected Sub OnAjaxUpdate(ByVal sender As Object, ByVal args As ToolTipUpdateEventArgs)
        Me.UpdateToolTip(args.Value, args.UpdatePanel)
    End Sub

    Private Sub UpdateToolTip(ByVal ArguementValue As String, ByVal panel As UpdatePanel)
        Dim ctrl As System.Web.UI.Control = Page.LoadControl("BillingApproval_Batch_Tooltip.ascx")
        panel.ContentTemplateContainer.Controls.Add(ctrl)

        Dim t As BillingApproval_Batch_Tooltip = DirectCast(ctrl, BillingApproval_Batch_Tooltip)
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
        End With
    End Sub

    'new job grid
    Private Sub RadGridJobList_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridJobList.NeedDataSource

        If Me.BatchID = 0 AndAlso IsNumeric(Me.LblBatchID.Text) = True Then Me.BatchID = CType(Me.LblBatchID.Text, Integer)

        If Me.BatchID > 0 Then

            Dim b As New cBillingApproval(Session("ConnString"), Session("UserCode"))
            Me.RadGridJobList.DataSource = b.GetBatchCriteriaJobs(Me.BatchID)

        End If

    End Sub

    Private Sub RadGridJobList_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridJobList.ItemDataBound
        Dim b As New cBillingApproval(Session("ConnString"), Session("UserCode"))
        Dim dsBatchDetails As New DataSet
        dsBatchDetails = b.GetBatchDetails(BatchID)
        If e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Or e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Then
            Try
                Dim IsOnBatch As Boolean = False

                Dim hfIsOnBatch As System.Web.UI.WebControls.HiddenField = CType(e.Item.FindControl("HfIS_ON_BATCH"), HiddenField)
                Dim lbl As System.Web.UI.WebControls.Label = CType(e.Item.FindControl("LbLSAVED_TO_BATCH"), Label)
                If hfIsOnBatch.Value = "1" Then
                    IsOnBatch = True
                    If Me.HfSavedYesColor.Value <> "" Then
                        e.Item.Cells(2).BackColor = ColorTranslator.FromHtml(Me.HfSavedYesColor.Value)
                    End If
                    lbl.Text = "Yes"
                    lbl.ToolTip = "This job/component is currently saved to this batch."
                Else
                    IsOnBatch = False
                    If Me.HfSavedNoColor.Value <> "" Then
                        e.Item.Cells(2).BackColor = ColorTranslator.FromHtml(Me.HfSavedNoColor.Value)
                    End If
                    lbl.Text = "No"
                    lbl.ToolTip = "This job/component is not currently saved to this batch."
                End If

                CType(e.Item.FindControl("ChkJob"), CheckBox).Checked = IsOnBatch

                If dsBatchDetails.Tables(0).Rows.Count > 0 Then
                    If IsDBNull(dsBatchDetails.Tables(0).Rows(0)("CAN_EDIT_CRITERIA")) = False Then
                        If dsBatchDetails.Tables(0).Rows(0)("CAN_EDIT_CRITERIA") = 0 Then
                            CType(e.Item.FindControl("ChkJob"), CheckBox).Enabled = False
                        End If
                    End If
                End If


            Catch ex As Exception
            End Try
        ElseIf e.Item.ItemType = Telerik.Web.UI.GridItemType.Header Then
            Try
                If dsBatchDetails.Tables(0).Rows.Count > 0 Then
                    If IsDBNull(dsBatchDetails.Tables(0).Rows(0)("CAN_EDIT_CRITERIA")) = False Then
                        If dsBatchDetails.Tables(0).Rows(0)("CAN_EDIT_CRITERIA") = 0 Then
                            CType(e.Item.FindControl("ChkAllJobs"), CheckBox).Enabled = False
                        End If
                    End If
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub BillingApproval_Batch_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        Try
            If Me.RadGridJobList.MasterTableView.Items.Count > 0 Then
                Dim AllRowsChecked As Boolean = True
                Try
                    For i As Integer = 0 To Me.RadGridJobList.MasterTableView.Items.Count - 1
                        Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridJobList.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem)
                        Dim Chk As CheckBox = CType(CurrentGridRow.FindControl("ChkJob"), CheckBox)
                        If Chk.Checked = False And AllRowsChecked = True Then
                            AllRowsChecked = False
                        End If
                    Next
                Catch ex As Exception
                End Try
                Try
                    Dim headeritem As Telerik.Web.UI.GridHeaderItem = CType(Me.RadGridJobList.MasterTableView.GetItems(Telerik.Web.UI.GridItemType.Header)(0), Telerik.Web.UI.GridHeaderItem)
                    CType(headeritem.FindControl("ChkAllJobs"), CheckBox).Checked = AllRowsChecked
                Catch ex As Exception
                End Try
                Me.BtnSaveJobListTop.Visible = True
                Me.BtnSaveJobListBottom.Visible = True
            Else
                'no rows in grid
                Me.BtnSaveJobListTop.Visible = False
                Me.BtnSaveJobListBottom.Visible = False
            End If
        Catch ex As Exception
        End Try
        Me.ChkFeeTimeRecords.Enabled = True
        Me.ChkNonBillableRecords.Enabled = True

        ''''CType(Me.RadToolbarBillingApprovalBatch.FindItemByValue("CreateApprovals"), RadToolBarButton).Enabled = Not IsNumeric(Me.LblBatchID.Text)

        ''If Me.BaExists = True Then
        ''    Me.TxtBatchDescription.Enabled = True
        ''    Me.TxtBatchDate.Enabled = True
        ''    Me.HlEmployee.Attributes.Remove("onclick")
        ''    Me.TxtEmployeeCode.Enabled = False
        ''    Me.TxtEmployeeDescription.Enabled = False
        ''    Me.TxtDateCutoff.Enabled = True
        ''    Me.DropPostingPeriod.Enabled = True

        ''    'DISABLE AE LB
        ''    Me.LitAEs.Text = ""
        ''    For i As Integer = 0 To Me.LbAEs.Items.Count - 1
        ''        If Me.LbAEs.Items(i).Selected = True Then
        ''            Me.LitAEs.Text &= Me.LbAEs.Items(i).Text & "<br/>"
        ''        End If
        ''    Next
        ''    Me.LbAEs.Visible = False

        ''    Me.RblSelectionLevel.Enabled = False

        ''    'DISABLE SEL LEVEL LB
        ''    Me.LitCDPCSelections.Text = ""
        ''    For j As Integer = 0 To Me.LbCDPCSelections.Items.Count - 1
        ''        If Me.LbCDPCSelections.Items(j).Selected = True Then
        ''            Me.LitCDPCSelections.Text &= Me.LbCDPCSelections.Items(j).Text & "<br/>"
        ''        End If
        ''    Next
        ''    Me.LbCDPCSelections.Visible = False

        ''    Me.BtnSaveJobListTop.Enabled = False
        ''    Me.RadGridJobList.MasterTableView.GetColumn("ColSelect").Visible = False
        ''    Me.BtnSaveJobListBottom.Enabled = False
        ''    Me.RbAllOpenJobs.Enabled = False
        ''    Me.RbOpenJobsWithoutUnbilledRecords.Enabled = False
        ''    Me.RbOpenJobsWithUnbilledRecordsOnly.Enabled = False
        ''    Me.ChkFeeTimeRecords.Enabled = True
        ''    Me.ChkNonBillableRecords.Enabled = True
        ''End If

    End Sub

    Public Sub ChkAllJobs_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim CheckAll As Boolean = CType(sender, CheckBox).Checked
        For i As Integer = 0 To Me.RadGridJobList.MasterTableView.Items.Count - 1
            Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridJobList.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem)
            CType(CurrentGridRow.FindControl("ChkJob"), CheckBox).Checked = CheckAll
        Next
    End Sub

    Private Sub SaveJobList()
        Try
            'UpdateBatch()
            Dim SbAdd As New System.Text.StringBuilder
            Dim SbRemove As New System.Text.StringBuilder
            Dim CounterAdd As Integer = 0
            Dim CounterRemove As Integer = 0

            Dim HasAdd As Boolean = False
            Dim HasRemove As Boolean = False

            With SbAdd
                .Append("UPDATE JOB_COMPONENT SET BA_BATCH_ID = ")
                .Append(Me.BatchID.ToString())
                .Append(" WHERE ")
            End With

            SbRemove.Append("UPDATE JOB_COMPONENT SET BA_BATCH_ID = NULL WHERE ")

            For i As Integer = 0 To Me.RadGridJobList.MasterTableView.Items.Count - 1
                Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridJobList.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem)
                Dim Chk As CheckBox = CType(CurrentGridRow.FindControl("ChkJob"), CheckBox)
                Dim HfIsOnBatch As System.Web.UI.WebControls.HiddenField = CType(CurrentGridRow.FindControl("HfIS_ON_BATCH"), HiddenField)
                Dim IsAlreadyOnBatch As Boolean = False
                Dim JobNumber As Integer = CType(CType(CurrentGridRow.FindControl("HfJOB_NUMBER"), HiddenField).Value, Integer)
                Dim JobComponentNbr As Integer = CType(CType(CurrentGridRow.FindControl("HfJOB_COMPONENT_NBR"), HiddenField).Value, Integer)

                If HfIsOnBatch.Value = "0" And Chk.Checked = True Then 'job/comp needs to be added to batch
                    HasAdd = True
                    With SbAdd
                        If CounterAdd > 0 Then
                            .Append(" OR ")
                        End If
                        .Append(" (JOB_NUMBER = ")
                        .Append(JobNumber.ToString())
                        .Append(" AND JOB_COMPONENT_NBR = ")
                        .Append(JobComponentNbr.ToString())
                        .Append(") ")
                    End With
                    CounterAdd += 1
                ElseIf HfIsOnBatch.Value = "1" And Chk.Checked = False Then 'job/comp needs to be removed from batch
                    HasRemove = True
                    With SbRemove
                        If CounterRemove > 0 Then
                            .Append(" OR ")
                        End If
                        .Append(" (JOB_NUMBER = ")
                        .Append(JobNumber.ToString())
                        .Append(" AND JOB_COMPONENT_NBR = ")
                        .Append(JobComponentNbr.ToString())
                        .Append(") ")
                    End With
                    CounterRemove += 1
                End If
            Next
            Dim StrSQL As String = ""
            If HasAdd = True Then
                StrSQL &= SbAdd.ToString() & ";"
            End If
            If HasRemove = True Then
                StrSQL &= SbRemove.ToString() & ";"
            End If
            If HasAdd = True Or HasRemove = True Then
                'update database
                Using MyConn As New SqlConnection(Session("ConnString"))
                    MyConn.Open()
                    Dim MyTrans As SqlTransaction = MyConn.BeginTransaction
                    Dim MyCmd As New SqlCommand(StrSQL, MyConn, MyTrans)
                    Try
                        MyCmd.ExecuteNonQuery()
                        MyTrans.Commit()
                    Catch ex As Exception
                        MyTrans.Rollback()
                    Finally
                        If MyConn.State = ConnectionState.Open Then MyConn.Close()
                    End Try
                End Using
                Me.RadGridJobList.Rebind()
                Me.LoadBatch(Me.BatchID)
                'MiscFN.ResponseRedirect("BillingApproval_Batch.aspx?BAID=" & BatchID.ToString())
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnSaveJobListTop_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSaveJobListTop.Click
        Me.SaveJobList()
    End Sub

    Private Sub BtnSaveJobListBottom_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSaveJobListBottom.Click
        Me.SaveJobList()
    End Sub

    Private Sub SetDetailSettings()
        'Me.ChkFeeTimeRecords.Checked = False
        'Me.ChkNonBillableRecords.Checked = False
        'If Me.RbOpenJobsWithoutUnbilledRecords.Checked = True Or RbOpenJobsWithUnbilledRecordsOnly.Checked = True Then
        '    Me.ChkFeeTimeRecords.Enabled = False
        '    Me.ChkNonBillableRecords.Enabled = False
        'ElseIf Me.RbAllOpenJobs.Checked = True Then
        Me.ChkFeeTimeRecords.Enabled = True
        Me.ChkNonBillableRecords.Enabled = True
        'End If

    End Sub

    Private Function SetSelOption() As Integer
        If Me.RbOpenJobsWithoutUnbilledRecords.Checked = True Then
            Return 1
        ElseIf Me.RbOpenJobsWithUnbilledRecordsOnly.Checked = True Then
            Return 2
        ElseIf Me.RbAllOpenJobs.Checked = True Then
            Return 0
        End If
    End Function

    Private Sub RbAllOpenJobs_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbAllOpenJobs.CheckedChanged
        Me.SetDetailSettings()
    End Sub

    Private Sub RbOpenJobsWithUnbilledRecordsOnly_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbOpenJobsWithUnbilledRecordsOnly.CheckedChanged
        Me.SetDetailSettings()
    End Sub

    Private Sub RbOpenJobsWithoutUnbilledRecords_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbOpenJobsWithoutUnbilledRecords.CheckedChanged
        Me.SetDetailSettings()
    End Sub

    Private Sub RadToolbarBillingApprovalBatch_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarBillingApprovalBatch.ButtonClick

        Select Case e.Item.Value

            Case "Delete"

                Dim m As String = ""
                Dim y As String = ""

                If MiscFN.ValidDate(Me.RadDatePickerBatchDate) = True Then

                    Dim s As Date = cGlobals.wvCDate(Me.RadDatePickerBatchDate.SelectedDate)
                    m = s.Month.ToString().PadLeft(2, "0")
                    y = s.Year.ToString()

                Else

                    m = Now.Month.ToString().PadLeft(2, "0")
                    y = Now.Year.ToString()

                End If
                If IsNumeric(Me.LblBatchID.Text) = True Then

                    Dim b As New cBillingApproval(Session("ConnString"), Session("UserCode"))
                    Dim str As String = b.DeleteEntireBatch(CType(Me.LblBatchID.Text, Integer))

                    If str <> "" Then

                        Session("BA_BATCH_GO_BACK") = "0"
                        Me.ShowMessage(str)

                    Else

                        Session("BA_BATCH_GO_BACK") = "1"
                        Me.CloseThisWindowAndRefreshCaller("BillingApproval_View.aspx?m=" & m & "&y=" & y)

                    End If

                End If

            Case "Save"

                Dim IsNew As Boolean = False

                If IsNumeric(Me.LblBatchID.Text) = False Then

                    IsNew = True
                    CreateBatch()

                Else

                    IsNew = False
                    UpdateBatch()

                End If
                If IsNumeric(Me.LblBatchID.Text) = True Then

                    Me.BatchID = CType(Me.LblBatchID.Text, Integer)

                    If CType(Me.RadToolbarBillingApprovalBatch.FindItemByValue("CreateApprovals"), RadToolBarButton).Checked = True Then

                        Dim b As New cBillingApproval(Session("ConnString"), Session("UserCode"))
                        Dim s As String = ""

                        s = b.AutoSaveAllClients(Me.BatchID, Not IsNew)

                        If s <> "" Then

                            Me.ShowMessage(s)

                        End If

                    End If

                    Me.LoadBatch(Me.BatchID)

                End If

            Case "Finish"

                Dim m As String = ""
                Dim y As String = ""

                If MiscFN.ValidDate(Me.RadDatePickerBatchDate) = True Then

                    Dim s As Date = cGlobals.wvCDate(Me.RadDatePickerBatchDate.SelectedDate)
                    m = s.Month.ToString().PadLeft(2, "0")
                    y = s.Year.ToString()

                Else

                    m = Now.Month.ToString().PadLeft(2, "0")
                    y = Now.Year.ToString()

                End If

                If IsNumeric(Me.LblBatchID.Text) = True Then

                    Dim b As New cBillingApproval(Session("ConnString"), Session("UserCode"))
                    Dim str As String = b.BatchFinish(CType(Me.LblBatchID.Text, Integer))

                    If str <> "" Then

                        Me.ShowMessage(str)

                    Else

                        Me.LoadBatch(CType(Me.LblBatchID.Text, Integer))
                        Me.RefreshCaller("BillingApproval_View.aspx?m=" & m & "&y=" & y)

                    End If

                End If

            Case "Alert"

                If IsNumeric(Me.LblBatchID.Text) = True Then

                    Dim strURL As String = "BillingApproval_Alert.aspx?P=1&BAID=" & CType(Me.LblBatchID.Text, Integer).ToString()
                    Me.OpenWindow("Alert", strURL)

                End If

            Case "HidePopups", "Refresh"

                Me.LoadBatch(Me.BatchID)

            Case "Bookmark"

                Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
                Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))
                Dim qs As New AdvantageFramework.Web.QueryString()

                qs = qs.FromCurrent()

                With b

                    .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Billing_BillingApprovalBatch
                    .UserCode = Session("UserCode")
                    .Name = "BA Batch: " & Me.BatchID
                    .PageURL = "BillingApproval_Batch.aspx" & qs.ToString()

                End With

                Dim s As String = ""
                If BmMethods.SaveBookmark(b, s) = False Then
                    Me.ShowMessage(s)
                Else
                    Me.RefreshBookmarksDesktopObject()
                End If

        End Select
    End Sub

    Private Sub RadioButtonManagerTypeAE_CheckedChanged(sender As Object, e As System.EventArgs) Handles RadioButtonManagerTypeAE.CheckedChanged
        Me.SetManagerType()
    End Sub

    Private Sub RadioButtonManagerTypePM_CheckedChanged(sender As Object, e As System.EventArgs) Handles RadioButtonManagerTypePM.CheckedChanged
        Me.SetManagerType()
    End Sub

    Private Sub SetManagerType()

        Me.LbAEs.Enabled = Me.RadioButtonManagerTypeAE.Checked
        Me.RadListBoxProjectManagers.Enabled = Not Me.RadioButtonManagerTypeAE.Checked

    End Sub

End Class
