Imports Telerik.Web.UI
Imports System.Data.SqlClient
'Template types:  0 or NULL, regular assignment, 1 
Public Class Maintenance_AlertAssignments
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
    Private tab As Integer = 0
    Private DefaultEmpLabelMSG As String = "Drag employee name over icon to set"
    Private DefaultCompletedStateLabelMSG As String = "Drag State name over icon to set"
    Private DefaultWorkflowLabelMSG As String = "Select a Template State to enable Automated Assignment"
    Private CurrentVersionId As Integer = 0
    Private CurrentSoftwareProductId As Integer = 0

    Public Enum EmployeesListType

        ManualEmployees = 0
        Role = 1
        DepartmentTeam = 2
        AlertGroup = 3
        AllEmployees = 4

    End Enum

#Region " Page and Shared "

    Private Sub Maintenance_AlertAssignments_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.PageTitle = "Workflow Maintenance"
        Dim AlertTemplateID As String = ""

        If Not Me.IsPostBack And Not Me.IsCallback Then
            Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_AlertAssignments)
            Me.BindDropTemplates(True, True)
            Me.LoadTimeZones()
            Try
                If Not Request.QueryString("t") Is Nothing Then
                    tab = CType(Request.QueryString("t"), Integer)
                End If
            Catch ex As Exception
                Me.tab = 0
            End Try

            Try
                If Request.QueryString("AlertTemplateID") IsNot Nothing Then
                    AlertTemplateID = Request.QueryString("AlertTemplateID")
                End If
            Catch ex As Exception
                AlertTemplateID = ""
            End Try
            Try
                If Request.QueryString("sftwv") IsNot Nothing Then
                    CurrentVersionId = Request.QueryString("sftwv")
                End If
            Catch ex As Exception
                CurrentVersionId = 0
            End Try

            Me.RadTabStrip1.SelectedIndex = tab
            Me.RadMultiPage1.SelectedIndex = tab

            Select Case Me.tab
                Case 0 'States Maintenance
                    Me.CheckBoxShowInactive.Visible = True
                    Me.ImageButtonExport.Visible = True
                    Me.RadGridAlertStates.Rebind()
                Case 1 'Templates Maintenance
                    Me.CheckBoxShowInactive.Visible = True
                    Me.ImageButtonExport.Visible = True
                    Me.RadGridTemplates.Rebind()
                Case 2 'Template Detail
                    Me.CheckBoxShowInactive.Visible = False
                    Me.ImageButtonExport.Visible = True
                    LoadTemplateDetailTab(AlertTemplateID)
                Case 3 'Other settings
                    Me.GetSettings()
            End Select

        End If
    End Sub
    Private Sub Maintenance_AlertAssignments_LoadComplete(sender As Object, e As System.EventArgs) Handles Me.LoadComplete
        Me.RadComboBoxTemplateStateWorkflow.Enabled = Me.TemplateAndStateSelected(False)
    End Sub

    Protected Overrides Sub RaisePostBackEvent(ByVal sourceControl As System.Web.UI.IPostBackEventHandler, ByVal eventArgument As String)
        Dim GridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        MyBase.RaisePostBackEvent(sourceControl, eventArgument)

        If sourceControl Is RadGridTemplates AndAlso (eventArgument.IndexOf("IndexOfRowDoubleClicked") <> -1) Then
            GridDataItem = RadGridTemplates.Items(Integer.Parse(eventArgument.Split(":"c)(1)))
            If GridDataItem IsNot Nothing Then
                Response.Redirect([String].Format("Maintenance_AlertAssignments.aspx?t={0}&AlertTemplateID={1}", 2, GridDataItem.GetDataKeyValue("ALRT_NOTIFY_HDR_ID")))
            End If
        End If

    End Sub
    Private Sub LoadTemplateDetailTab(ByVal AlertTemplateID As String)

        Me.BindDropTemplates(True, False)
        Me.BindRadLB_AvailableStates()
        Me.BindRadLB_StatesInTemplate()
        Me.LblEmpDefaultEmp.Text = Me.DefaultEmpLabelMSG
        Dim v As New cAppVars(cAppVars.Application.ALERT_ASSIGNMENT_MAINT)
        v.getAllAppVars()
        Dim s As String = ""
        Try
            s = v.getAppVar("EMP_FILTER")
            If s <> "" Then
                Me.RblAvailableEmployeesFilter.Items.FindByValue(s).Selected = True
            End If
        Catch ex As Exception
            s = ""
        End Try
        s = ""
        Try
            If Me.RblAvailableEmployeesFilter.SelectedIndex > -1 Then
                Me.BindDropAvailableEmployeesFilter()
                Select Case Me.RblAvailableEmployeesFilter.SelectedValue
                    Case "role"
                        s = v.getAppVar("EMP_FILTER_ROLE_CODE")
                    Case "alert_group"
                        s = v.getAppVar("EMP_FILTER_EML_GRP_CODE")
                End Select
                If s <> "" And Me.DropAvailableEmployeesFilter.Items.Count > 0 Then
                    MiscFN.RadComboBoxSetIndex(Me.DropAvailableEmployeesFilter, s, False)
                End If
            End If
        Catch ex As Exception
        End Try

        Me.DivCopyTeam.Visible = False
        Me.SetAvailableSelectionType()

        If AlertTemplateID <> "" Then

            RadComboBoxAlertTemplate.SelectedValue = AlertTemplateID

            If Me.RadComboBoxAlertTemplate.SelectedIndex = 0 Then

                Me.RadListBoxAvailableStates.Items.Clear()
                Me.RadListBoxStatesInTemplate.Items.Clear()
                Me.RadListBoxEmps_AvailableEmps.Items.Clear()
                Me.RadListBoxEmps_EmpsInTemplateState.Items.Clear()

                Me.RadListBoxStatesInTemplateToCopyTo.Items.Clear()
                Me.DivCopyTeam.Visible = False
                Me.ImageButtonCopyTemplate.Visible = False
                Me.DivSelectedTemplateOptions.Visible = False

            Else

                Me.BindRadLB_AvailableStates()
                Me.BindRadLB_StatesInTemplate()
                Me.RadListBoxEmps_AvailableEmps.Items.Clear()
                Me.RadListBoxEmps_EmpsInTemplateState.Items.Clear()

                Me.ImageButtonCopyTemplate.Visible = True
                Me.DivSelectedTemplateOptions.Visible = True

            End If

        End If

        Me.ClearAndDisableRadComboBoxTemplateStateWorkflow()

    End Sub
    Private Sub ClearAndDisableRadComboBoxTemplateStateWorkflow()
        With Me.RadComboBoxTemplateStateWorkflow
            .Items.Clear()
            .Enabled = False
        End With
    End Sub
    Private Sub BindDropTemplates(ByVal BindRadComboBoxAlertTemplate As Boolean, ByVal BindDropEmpTemplate As Boolean)
        Dim a As New cAlerts()
        Dim d As New DataTable
        d = a.GetAlertNotifyTemplates(CheckBoxShowInactive.Checked)

        If Not d Is Nothing Then
            If d.Rows.Count > 0 Then
                With Me.RadComboBoxAlertTemplate
                    .Items.Clear()
                    .DataSource = d
                    .DataTextField = "ALERT_NOTIFY_NAME"
                    .DataValueField = "ALRT_NOTIFY_HDR_ID"
                    .DataBind()
                    .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))
                End With
            End If
        End If
    End Sub

    Private Sub CheckBoxShowInactive_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxShowInactive.CheckedChanged
        Select Case Me.RadTabStrip1.SelectedIndex
            Case 0
                Me.RadGridAlertStates.Rebind()
            Case 1
                Me.RadGridTemplates.Rebind()
        End Select
    End Sub
    Private Sub ImageButtonExport_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonExport.Click

        'objects
        Dim GridView As GridView = Nothing
        Dim DataView As DataView = Nothing
        Dim DataTable As DataTable = Nothing
        Dim Alerts As cAlerts = Nothing
        Dim NewDataRow As DataRow = Nothing
        Dim AlertCategoriesDataTable As DataTable = Nothing

        Select Case Me.RadTabStrip1.SelectedIndex

            Case 0
                Alerts = New cAlerts
                DataTable = New DataTable
                DataTable.Columns.Add("State Name")
                DataTable.Columns.Add("Default Category")
                DataTable.Columns.Add("Active")

                AlertCategoriesDataTable = Alerts.GetManualAlertCategories(True, True)

                For Each DataRow In Alerts.GetAlertStates().Rows.OfType(Of DataRow)()

                    NewDataRow = DataTable.Rows.Add()

                    NewDataRow(0) = DataRow("ALERT_STATE_NAME")

                    For Each oDefaultCategoryRow In AlertCategoriesDataTable.Rows.OfType(Of DataRow)()

                        If oDefaultCategoryRow("ALERT_CAT_ID").ToString() = DataRow("DFLT_ALERT_CAT_ID").ToString() Then

                            NewDataRow(1) = oDefaultCategoryRow("ALERT_DESC")
                            Exit For

                        End If

                    Next

                    If DataRow("ACTIVE_FLAG").ToString.ToUpper = Boolean.TrueString.ToUpper Then

                        NewDataRow(2) = "YES"

                    Else

                        NewDataRow(2) = "NO"

                    End If

                Next

                DataView = New DataView(DataTable)

                If CheckBoxShowInactive.Checked = False Then

                    DataView.RowFilter = "Active = 'YES'"

                End If

                'GridView = New GridView

                'GridView.DataSource = DataView
                'GridView.DataBind()

                'AdvantageFramework.Web.Exporting.ToExcel("Assignment State.xls", GridView) <--- This doesn' work
                Me.DeliverGrid(DataView.ToTable(), "Assignment States") '<--- This does, please don't change unless you test!!!!

            Case 1

                Alerts = New cAlerts

                DataTable = New DataTable

                DataTable.Columns.Add("Template Name")
                DataTable.Columns.Add("Auto Route")
                DataTable.Columns.Add("Active")

                For Each DataRow In Alerts.GetAlertNotifyTemplates(CheckBoxShowInactive.Checked).Rows.OfType(Of DataRow)()

                    NewDataRow = DataTable.Rows.Add()

                    NewDataRow(0) = DataRow("ALERT_NOTIFY_NAME")

                    If DataRow("AUTO_NXT_STATE").ToString.ToUpper = Boolean.TrueString.ToUpper Then

                        NewDataRow(1) = "YES"

                    Else

                        NewDataRow(1) = "NO"

                    End If


                    If DataRow("ACTIVE_FLAG").ToString.ToUpper = Boolean.TrueString.ToUpper Then

                        NewDataRow(2) = "YES"

                    Else

                        NewDataRow(2) = "NO"

                    End If

                Next

                'DataView = New DataView(DataTable)

                'GridView = New GridView

                'GridView.DataSource = DataView
                'GridView.DataBind()

                'AdvantageFramework.Web.Exporting.ToExcel("Assignment Templates.xls", GridView)
                Me.DeliverGrid(DataTable, "Assignment Templates") '<--- This does, please don't change unless you test!!!!

            Case 2

                If Me.RadComboBoxAlertTemplate.SelectedIndex > 0 Then

                    Dim AlertNotificationRecipients As DataTable = Nothing

                    Alerts = New cAlerts

                    DataTable = New DataTable

                    DataTable.Columns.Add("State Name")
                    DataTable.Columns.Add("Employee Code")
                    DataTable.Columns.Add("Employee Name")

                    NewDataRow = DataTable.Rows.Add()

                    NewDataRow(1) = Me.RadComboBoxAlertTemplate.Text

                    For Each oAlertStateDataRow In Alerts.GetAlertStates(0, 0, Me.RadComboBoxAlertTemplate.SelectedValue).Rows.OfType(Of DataRow)()

                        NewDataRow = DataTable.Rows.Add()

                        NewDataRow(0) = oAlertStateDataRow("ALERT_STATE_NAME")
                        NewDataRow(1) = ""
                        NewDataRow(2) = ""

                        AlertNotificationRecipients = Alerts.GetNotificationRecipients(oAlertStateDataRow("ALERT_STATE_ID"), 0, 0, Me.RadComboBoxAlertTemplate.SelectedValue, IncludePleaseSelect:=False, IncludeUnassigned:=False)

                        If AlertNotificationRecipients.Rows.Count() > 0 Then

                            For Each oEmployeeDataRow In AlertNotificationRecipients.Rows.OfType(Of DataRow)()

                                NewDataRow = DataTable.Rows.Add()

                                NewDataRow(0) = ""
                                NewDataRow(1) = oEmployeeDataRow("EMP_CODE")
                                NewDataRow(2) = oEmployeeDataRow("EMP_FML")

                            Next

                        Else

                            NewDataRow = DataTable.Rows.Add()

                            NewDataRow(0) = ""
                            NewDataRow(1) = "unassigned"
                            NewDataRow(2) = "[Unassigned]"

                        End If

                        NewDataRow = DataTable.Rows.Add()

                    Next

                    'DataView = New DataView(DataTable)

                    'GridView = New GridView

                    'GridView.DataSource = DataView
                    'GridView.DataBind()

                    'AdvantageFramework.Web.Exporting.ToExcel("Assignment Template Details.xls", GridView) <--- This doesn' work
                    Me.DeliverGrid(DataTable, "Assignment Template Details") '<--- This does, please don't change unless you test!!!!

                Else

                    Me.ShowMessage("You must select a template first.")

                End If

        End Select

    End Sub
    Private Sub RadTabStrip1_TabClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadTabStripEventArgs) Handles RadTabStrip1.TabClick
        Select Case Me.RadTabStrip1.SelectedIndex
            Case 0 'States Maintenance
                Me.CheckBoxShowInactive.Visible = True
                Me.ImageButtonExport.Visible = True
                Me.RadGridAlertStates.Rebind()
            Case 1 'Templates Maintenance
                Me.CheckBoxShowInactive.Visible = True
                Me.ImageButtonExport.Visible = True
                Me.RadGridTemplates.Rebind()
            Case 2 'Template Detail
                Me.CheckBoxShowInactive.Visible = False
                Me.ImageButtonExport.Visible = True
                LoadTemplateDetailTab("")
            Case 3 'Other settings
                Me.CheckBoxShowInactive.Visible = False
                Me.ImageButtonExport.Visible = False
                Me.GetSettings()
        End Select
    End Sub

#End Region

#Region " States Tab "

    Private TabIndex As Integer = 0
    Private tb As System.Web.UI.WebControls.TextBox
    Private chk As CheckBox
    Private ddl As Telerik.Web.UI.RadComboBox
    Private ImgBtnAdd As System.Web.UI.WebControls.ImageButton
    Private ImgBtnDelete As System.Web.UI.WebControls.ImageButton
    Dim dt As New DataTable

    Private Sub RadGridAlertStates_CancelCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridAlertStates.CancelCommand
        Dim EditItem As GridEditableItem = CType(e.Item, GridEditableItem)
        If Not EditItem Is Nothing Then
            CType(EditItem.FindControl("TxtALERT_STATE_NAME"), TextBox).Text = ""
            CType(EditItem.FindControl("ChkACTIVE_FLAG"), CheckBox).Checked = True
            CType(EditItem.FindControl("DropDFLT_ALERT_CAT_ID"), Telerik.Web.UI.RadComboBox).SelectedIndex = 0
        End If
    End Sub

    Protected Sub RadGridAlertStates_ToggleInActive(ByVal sender As Object, ByVal e As EventArgs)
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim item As GridDataItem = CType(chk.NamingContainer, GridDataItem)

        Me.UpdateStateRow(item)
    End Sub

    Private Sub RadGridAlertStates_InsertCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridAlertStates.InsertCommand

        Dim InsertAlertState As Boolean = True

        Dim EditItem As GridEditableItem = CType(e.Item, GridEditableItem)
        If Not EditItem Is Nothing Then
            Dim StateName As String = ""
            Dim IsInactive As Boolean = True
            Dim DefaultAlertCategory As Integer = 0
            Dim ddl As Telerik.Web.UI.RadComboBox

            StateName = DirectCast(EditItem.FindControl("TxtALERT_STATE_NAME"), TextBox).Text.Trim()
            IsInactive = DirectCast(EditItem.FindControl("ChkACTIVE_FLAG"), CheckBox).Checked
            ddl = DirectCast(EditItem.FindControl("DropDFLT_ALERT_CAT_ID"), Telerik.Web.UI.RadComboBox)
            If ddl.SelectedIndex > 0 Then
                DefaultAlertCategory = ddl.SelectedValue
            End If
            If StateName = "" Then
                Me.ShowMessage("Please enter a state name")
                Exit Sub
            End If

            Dim a As New cAlerts()
            For Each DataRow In a.GetAlertStates().Rows.OfType(Of System.Data.DataRow)()
                If DataRow("ALERT_STATE_NAME").ToString.ToUpper = StateName.ToUpper Then
                    Me.ShowMessage("Please enter a unique state name")
                    InsertAlertState = False
                    Exit For
                End If
            Next

            If InsertAlertState Then
                If DefaultAlertCategory = 0 Then DefaultAlertCategory = 25
                Dim s As String = a.AlertStatesInsert(StateName, Not IsInactive, DefaultAlertCategory)
                If IsNumeric(s) = False Then
                    'error
                Else
                    'Me.RadGridAlertStates.Rebind()
                    MiscFN.ResponseRedirect("Maintenance_AlertAssignments.aspx?t=0")
                End If
            End If

        End If
    End Sub
    Private Sub RadGridAlertStates_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridAlertStates.ItemCommand

        If e.Item Is Nothing Then Exit Sub

        Dim index As Integer = e.Item.ItemIndex
        Dim CurrentGridRow As Telerik.Web.UI.GridDataItem
        If index > -1 Then
            CurrentGridRow = DirectCast(RadGridAlertStates.Items(index), Telerik.Web.UI.GridDataItem)
        End If
        Select Case e.CommandName
            Case "SaveAll"
                For Each gdi As GridDataItem In Me.RadGridAlertStates.MasterTableView.Items
                    Me.UpdateStateRow(gdi)
                Next
                Me.RadGridAlertStates.Rebind()
            Case "SaveNewRow"
                e.Item.FireCommandEvent("PerformInsert", e)
            Case "SaveRow"
                If Not CurrentGridRow Is Nothing Then
                    Me.UpdateStateRow(CurrentGridRow)
                    Me.RadGridAlertStates.Rebind()
                End If
            Case "DeleteRow"
                If Not CurrentGridRow Is Nothing Then
                    Dim ThisAlertStateId As Integer = 0
                    Try
                        ThisAlertStateId = CType(CurrentGridRow.GetDataKeyValue("ALERT_STATE_ID"), Integer)
                    Catch ex As Exception
                        ThisAlertStateId = 0
                    End Try
                    If ThisAlertStateId > 0 Then
                        Dim a As New cAlerts()
                        Dim s As String = ""
                        s = a.DeleteAlertState(ThisAlertStateId, False)
                        If s = "" Then
                            Me.RadGridAlertStates.Rebind()
                        Else
                            'error
                            Me.ShowMessage(s)
                        End If
                    End If
                End If
            Case "CancelNewRow"
                e.Item.FireCommandEvent("Cancel", e)
        End Select
    End Sub
    Private Sub RadGridAlertStates_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridAlertStates.ItemDataBound
        If TypeOf e.Item Is Telerik.Web.UI.GridEditableItem Then
            Try
                ddl = DirectCast(e.Item.FindControl("DropDFLT_ALERT_CAT_ID"), Telerik.Web.UI.RadComboBox)
            Catch ex As Exception
            End Try
            Try
                With ddl
                    If Not dt Is Nothing Then
                        .DataSource = dt
                        .DataTextField = "ALERT_DESC"
                        .DataValueField = "ALERT_CAT_ID"
                        .DataBind()
                        .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[None]", ""))
                        MiscFN.RadComboBoxSetIndex(ddl, "Action", True)
                        If CType(e.Item, GridEditableItem).IsInEditMode = False Then
                            If Not IsDBNull(e.Item.DataItem("DFLT_ALERT_CAT_ID")) Then
                                MiscFN.RadComboBoxSetIndex(ddl, e.Item.DataItem("DFLT_ALERT_CAT_ID"), False)
                            End If
                        End If
                    Else
                        ddl.Enabled = False
                    End If
                End With
            Catch ex As Exception
            End Try
            Try
                tb = DirectCast(e.Item.FindControl("TxtALERT_STATE_NAME"), TextBox)
                tb.Focus()
            Catch ex As Exception
            End Try
        End If
        If TypeOf e.Item Is Telerik.Web.UI.GridDataItem Then
            Try
                tb = DirectCast(e.Item.FindControl("TxtALERT_STATE_NAME"), TextBox)
            Catch ex As Exception
            End Try
            Try
                chk = DirectCast(e.Item.FindControl("ChkACTIVE_FLAG"), CheckBox)
            Catch ex As Exception
            End Try
            Try
                ddl = DirectCast(e.Item.FindControl("DropDFLT_ALERT_CAT_ID"), Telerik.Web.UI.RadComboBox)
            Catch ex As Exception
            End Try
            Try
                ImgBtnAdd = DirectCast(e.Item.FindControl("ImgBtnSave"), ImageButton)
            Catch ex As Exception
            End Try
            Try
                ImgBtnDelete = DirectCast(e.Item.FindControl("ImgBtnDelete"), ImageButton)
            Catch ex As Exception
            End Try

            Try
                If CType(e.Item.DataItem("ACTIVE_FLAG"), Boolean) = False Then
                    chk.Checked = True
                End If
            Catch ex As Exception
            End Try

            Dim a As New cAlerts()
            Try
                If dt.Rows.Count = 0 Then
                    dt = a.GetManualAlertCategories(True, True)
                End If
            Catch ex As Exception
            End Try
            Try
                With ddl
                    If Not dt Is Nothing Then
                        .DataSource = dt
                        .DataTextField = "ALERT_DESC"
                        .DataValueField = "ALERT_CAT_ID"
                        .DataBind()
                        .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[None]", ""))
                        If CType(e.Item, GridEditableItem).IsInEditMode = False Then
                            If Not IsDBNull(e.Item.DataItem("DFLT_ALERT_CAT_ID")) Then
                                MiscFN.RadComboBoxSetIndex(ddl, e.Item.DataItem("DFLT_ALERT_CAT_ID"), False)
                            End If
                        End If
                    Else
                        ddl.Enabled = False
                    End If
                End With
            Catch ex As Exception
            End Try
            Try
                'If CType(e.Item.DataItem("CAN_DELETE"), Integer) = 0 Then
                '    With ImgBtnDelete
                '        '.ImageUrl = "~/Images/delete_disabled.png"
                '        .ImageUrl = "~/Images/delete.png"
                '        .Enabled = True
                '        .ToolTip = "This state has related records" ' and cannot be deleted"
                '        '.Attributes.Add("onclick", "return false;")
                '        .Attributes.Add("onclick", "return confirm('This state has related records.\nDeleting this state will also remove all related records!\n\nAre you sure you want to delete?');")
                '    End With
                'Else
                With ImgBtnDelete
                    '.ImageUrl = "~/Images/delete.png"
                    .Enabled = True
                    .ToolTip = "Click to delete this row"
                    .Attributes.Add("onclick", "return confirm('Are you sure you want to delete?');")
                End With
                'End If
            Catch ex As Exception
            End Try
        End If
    End Sub
    Private Sub RadGridAlertStates_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridAlertStates.NeedDataSource

        'objects
        Dim Alerts As cAlerts = Nothing
        Dim DataRows() As DataRow = Nothing
        Dim DataView As DataView = Nothing

        Alerts = New cAlerts

        DataView = New DataView(Alerts.GetAlertStates())

        If CheckBoxShowInactive.Checked = False Then

            DataView.RowFilter = "ACTIVE_FLAG = 'TRUE'"

        End If

        Me.RadGridAlertStates.DataSource = DataView.ToTable()

        Me.RadGridAlertStates.MasterTableView.IsItemInserted = True
        Me.RadGridAlertStates.PageSize = MiscFN.LoadPageSize(Me.RadGridAlertStates.ID)
    End Sub

    Private Function UpdateStateRow(ByVal TheGridRow As Telerik.Web.UI.GridDataItem) As String
        Try
            Dim i As Integer
            i = TheGridRow.RowIndex
        Catch ex As Exception
        End Try
        Dim AlertStateId As Integer = 0
        Dim StrSQL As String = ""
        Try
            AlertStateId = CType(TheGridRow.GetDataKeyValue("ALERT_STATE_ID"), Integer)
        Catch ex As Exception
            AlertStateId = 0
        End Try

        If AlertStateId > 0 Then 'we are updating a rec
            Dim StateName As String = ""
            Dim IsInactive As Boolean = True
            Dim DefaultAlertCategory As Integer = 0
            Dim ddl As Telerik.Web.UI.RadComboBox

            StateName = DirectCast(TheGridRow.FindControl("TxtALERT_STATE_NAME"), TextBox).Text.Trim()
            IsInactive = DirectCast(TheGridRow.FindControl("ChkACTIVE_FLAG"), CheckBox).Checked
            ddl = DirectCast(TheGridRow.FindControl("DropDFLT_ALERT_CAT_ID"), Telerik.Web.UI.RadComboBox)
            If ddl.SelectedIndex > 0 Then
                DefaultAlertCategory = ddl.SelectedValue
            Else
                DefaultAlertCategory = 0
            End If
            If DefaultAlertCategory = 0 Then DefaultAlertCategory = 25
            Dim a As New cAlerts()
            Dim s As String = a.AlertStatesUpdate(AlertStateId, StateName, Not IsInactive, DefaultAlertCategory)
            If s <> "" Then
                'error
            End If
        End If
    End Function

#End Region

#Region " Templates Tab "

    Private Sub RadGridTemplates_CancelCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridTemplates.CancelCommand
        Dim EditItem As GridEditableItem = CType(e.Item, GridEditableItem)
        If Not EditItem Is Nothing Then
            CType(EditItem.FindControl("TxtALERT_NOTIFY_NAME"), TextBox).Text = ""
            CType(EditItem.FindControl("ChkACTIVE_FLAG"), CheckBox).Checked = True
        End If
    End Sub
    Private Sub RadGridTemplates_GroupsChanging(sender As Object, e As Telerik.Web.UI.GridGroupsChangingEventArgs) Handles RadGridTemplates.GroupsChanging

    End Sub

    Protected Sub RadGridTemplates_ToggleInActive(ByVal sender As Object, ByVal e As EventArgs)
        Dim chk As CheckBox = CType(sender, CheckBox)
        Dim item As GridDataItem = CType(chk.NamingContainer, GridDataItem)

        Me.UpdateTemplateRow(item)
    End Sub

    Private Sub RadGridTemplates_InsertCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridTemplates.InsertCommand
        'objects
        Dim InsertAlertTemplate As Boolean = True

        Dim EditItem As GridEditableItem = CType(e.Item, GridEditableItem)
        If Not EditItem Is Nothing Then

            Dim TemplateName As String = ""
            Dim IsInactive As Boolean = True
            Dim TemplateType As Short = 0
            Dim AutoNextState As Boolean = False

            TemplateName = DirectCast(EditItem.FindControl("TxtALERT_NOTIFY_NAME"), TextBox).Text.Trim()
            IsInactive = DirectCast(EditItem.FindControl("ChkACTIVE_FLAG"), CheckBox).Checked

            If DirectCast(EditItem.FindControl("CheckBoxReviewProofing"), CheckBox).Checked = True Then

                TemplateType = 2

            Else

                TemplateType = 0

            End If

            AutoNextState = DirectCast(EditItem.FindControl("CheckBoxAutoRoute"), CheckBox).Checked

            If TemplateName = "" Then

                Me.ShowMessage("Please enter a Template Name")
                Exit Sub

            End If

            Dim a As New cAlerts()

            For Each DataRow In a.GetAlertNotifyTemplates(True).Rows.OfType(Of System.Data.DataRow)()

                If DataRow("ALERT_NOTIFY_NAME").ToString.ToUpper = TemplateName.ToUpper Then

                    Me.ShowMessage("Please enter a unique template name")
                    InsertAlertTemplate = False
                    Exit For

                End If

            Next

            If InsertAlertTemplate Then

                Dim s As String = a.AlertTemplateInsert(TemplateName, Not IsInactive, TemplateType, AutoNextState)

                If IsNumeric(s) = False Then
                    'error
                Else
                    'Me.RadGridTemplates.Rebind()
                    If IsInactive = False Then
                        Dim SettingValue As AdvantageFramework.Database.Entities.SettingValue = Nothing
                        Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)
                            SettingValue = New AdvantageFramework.Database.Entities.SettingValue

                            SettingValue.DataContext = DataContext

                            SettingValue.SettingCode = AdvantageFramework.Agency.Settings.JR_ASSIGN_TMPLT.ToString
                            SettingValue.DisplayText = TemplateName
                            SettingValue.Value = s

                            AdvantageFramework.Database.Procedures.SettingValue.Insert(DataContext, SettingValue)
                        End Using
                    End If
                    MiscFN.ResponseRedirect("Maintenance_AlertAssignments.aspx?t=1")
                End If
            End If

        End If

    End Sub
    Private Sub RadGridTemplates_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridTemplates.ItemCommand

        If e.Item Is Nothing Then Exit Sub

        Dim index As Integer = e.Item.ItemIndex
        Dim CurrentGridRow As Telerik.Web.UI.GridDataItem
        If index > -1 Then
            CurrentGridRow = DirectCast(RadGridTemplates.Items(index), Telerik.Web.UI.GridDataItem)
        End If
        Select Case e.CommandName
            Case "SaveAll"
                For Each gdi As GridDataItem In Me.RadGridTemplates.MasterTableView.Items
                    Me.UpdateTemplateRow(gdi)
                Next
                Me.RadGridTemplates.Rebind()
            Case "SaveNewRow"
                e.Item.FireCommandEvent("PerformInsert", e)
            Case "SaveRow"
                If Not CurrentGridRow Is Nothing Then
                    Me.UpdateTemplateRow(CurrentGridRow)
                    Me.RadGridTemplates.Rebind()
                End If
            Case "DeleteRow"
                If Not CurrentGridRow Is Nothing Then
                    Dim ThisAlrtNotifyHdrId As Integer = 0
                    Try
                        ThisAlrtNotifyHdrId = CType(CurrentGridRow.GetDataKeyValue("ALRT_NOTIFY_HDR_ID"), Integer)
                    Catch ex As Exception
                        ThisAlrtNotifyHdrId = 0
                    End Try
                    If ThisAlrtNotifyHdrId > 0 Then
                        Dim a As New cAlerts()
                        Dim s As String = ""
                        s = a.DeleteAlertTemplate(ThisAlrtNotifyHdrId)
                        If s = "" Then
                            Me.RadGridTemplates.Rebind()
                            Try
                                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)
                                    AdvantageFramework.Database.Procedures.SettingValue.DeleteBySettingCodeAndLookupValue(DataContext, AdvantageFramework.Agency.Settings.JR_ASSIGN_TMPLT.ToString, ThisAlrtNotifyHdrId.ToString)
                                End Using
                            Catch ex As Exception

                            End Try
                        Else
                            'error
                            Me.ShowMessage(s)
                        End If
                    End If
                End If
            Case "CancelNewRow"
                e.Item.FireCommandEvent("Cancel", e)
        End Select
    End Sub
    Private Sub RadGridTemplates_ItemCreated(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridTemplates.ItemCreated

    End Sub
    Private Sub RadGridTemplates_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridTemplates.ItemDataBound
        Dim AlertTemplateName As System.Web.UI.WebControls.TextBox = Nothing

        If TypeOf e.Item Is Telerik.Web.UI.GridEditableItem Then
            Try
                DirectCast(e.Item.FindControl("TxtALERT_NOTIFY_NAME"), TextBox).Focus()
            Catch ex As Exception
            End Try

        End If
        If TypeOf e.Item Is Telerik.Web.UI.GridDataItem Then

            If e.Item.IsInEditMode = False Then

                Try
                    AlertTemplateName = DirectCast(e.Item.FindControl("TxtALERT_NOTIFY_NAME"), TextBox)
                    If AlertTemplateName IsNot Nothing Then
                        AlertTemplateName.Attributes.Add("OnDblClick", "RadGridTemplates_RowDoubleClick(" & e.Item.ItemIndexHierarchical & ");")
                    End If
                Catch ex As Exception
                End Try

            End If

            Try
                If CType(e.Item.DataItem("ACTIVE_FLAG"), Boolean) = False Then
                    Dim chk As CheckBox = DirectCast(e.Item.FindControl("ChkACTIVE_FLAG"), CheckBox)
                    chk.Checked = True
                End If
            Catch ex As Exception
            End Try
            Try
                Dim ib As System.Web.UI.WebControls.ImageButton = DirectCast(e.Item.FindControl("ImgBtnDelete"), ImageButton)
                With ib
                    '.ImageUrl = "~/Images/delete.png"
                    .Enabled = True
                    .ToolTip = "Click to delete this row"
                    .Attributes.Add("onclick", "return confirm('Are you sure you want to delete?');")
                End With
            Catch ex As Exception
            End Try

            Dim ReviewProofingCheckBox As System.Web.UI.WebControls.CheckBox = DirectCast(e.Item.FindControl("CheckBoxReviewProofing"), CheckBox)
            Dim AutoRouteCheckBox As System.Web.UI.WebControls.CheckBox = DirectCast(e.Item.FindControl("CheckBoxAutoRoute"), CheckBox)
            Dim IsReviewProofing As Boolean = False
            Try


                If ReviewProofingCheckBox IsNot Nothing Then

                    ReviewProofingCheckBox.ToolTip = "Check to use workflow on reviews/proofs"
                    ReviewProofingCheckBox.Checked = e.Item.DataItem("TYPE") = 2

                    IsReviewProofing = ReviewProofingCheckBox.Checked

                End If

            Catch ex As Exception
            End Try
            Try

                If AutoRouteCheckBox IsNot Nothing Then

                    AutoRouteCheckBox.ToolTip = "Automatically move to next state on assignees complete."

                    If IsReviewProofing = True Then

                        AutoRouteCheckBox.Checked = True
                        AutoRouteCheckBox.Enabled = False

                    Else

                        AutoRouteCheckBox.Checked = e.Item.DataItem("AUTO_NXT_STATE")

                    End If

                End If

            Catch ex As Exception
            End Try

        End If

    End Sub
    Private Sub RadGridTemplates_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridTemplates.NeedDataSource
        Dim a As New cAlerts()
        Dim dt As New DataTable
        dt = a.GetAlertNotifyTemplates(CheckBoxShowInactive.Checked)

        ''bug with having only one template fix
        ''===================================================================
        'If dt.Rows.Count = 1 And Session("ReloadAlertMaint") Is Nothing Then
        '    Session("ReloadAlertMaint") = 1
        '    MiscFN.ResponseRedirect("Maintenance_AlertAssignments.aspx?t=1")
        'End If
        ''===================================================================

        Me.RadGridTemplates.DataSource = dt
        Me.RadGridTemplates.MasterTableView.IsItemInserted = True
        Me.RadGridTemplates.PageSize = MiscFN.LoadPageSize(Me.RadGridTemplates.ID)
    End Sub

    Private Function UpdateTemplateRow(ByVal TheGridRow As Telerik.Web.UI.GridDataItem) As String
        Try
            Dim i As Integer
            i = TheGridRow.RowIndex
        Catch ex As Exception
        End Try
        Dim AlrtNotifyHdrId As Integer = 0
        Dim StrSQL As String = ""
        Try
            AlrtNotifyHdrId = TheGridRow.GetDataKeyValue("ALRT_NOTIFY_HDR_ID")
        Catch ex As Exception
            AlrtNotifyHdrId = 0
        End Try

        If AlrtNotifyHdrId > 0 Then 'we are updating a rec

            Dim TemplateName As String = ""
            Dim IsInactive As Boolean = True
            Dim TemplateType As Short = 0
            Dim AutoNextState As Boolean = False

            TemplateName = DirectCast(TheGridRow.FindControl("TxtALERT_NOTIFY_NAME"), TextBox).Text.Trim()
            IsInactive = DirectCast(TheGridRow.FindControl("ChkACTIVE_FLAG"), CheckBox).Checked

            If DirectCast(TheGridRow.FindControl("CheckBoxReviewProofing"), CheckBox).Checked = True Then

                TemplateType = 2

            Else

                TemplateType = 0

            End If

            AutoNextState = DirectCast(TheGridRow.FindControl("CheckBoxAutoRoute"), CheckBox).Checked

            Dim a As New cAlerts()
            Dim s As String = a.AlertTemplateUpdate(AlrtNotifyHdrId, TemplateName, Not IsInactive, TemplateType, AutoNextState)

            If s <> "" Then
                'error
            End If

            Dim SettingValue As AdvantageFramework.Database.Entities.SettingValue = Nothing
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                    Try
                        If IsInactive = True Then
                            Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.JR_ASSIGN_TMPLT.ToString)
                            If Setting IsNot Nothing Then
                                If Setting.Value <> AlrtNotifyHdrId Then
                                    AdvantageFramework.Database.Procedures.SettingValue.DeleteBySettingCodeAndLookupValue(DataContext, AdvantageFramework.Agency.Settings.JR_ASSIGN_TMPLT.ToString, AlrtNotifyHdrId)
                                End If
                            End If
                        Else
                            If AdvantageFramework.Database.Procedures.SettingValue.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.JR_ASSIGN_TMPLT.ToString).Any(Function(Entity) Entity.Value.ToString = AlrtNotifyHdrId.ToString) = False Then
                                SettingValue = New AdvantageFramework.Database.Entities.SettingValue
                                SettingValue.DataContext = DataContext
                                SettingValue.SettingCode = AdvantageFramework.Agency.Settings.JR_ASSIGN_TMPLT.ToString
                                SettingValue.DisplayText = TemplateName
                                SettingValue.Value = AlrtNotifyHdrId
                                AdvantageFramework.Database.Procedures.SettingValue.Insert(DataContext, SettingValue)
                            Else
                                SettingValue = AdvantageFramework.Database.Procedures.SettingValue.LoadBySettingCodeAndValue(DataContext, AdvantageFramework.Agency.Settings.JR_ASSIGN_TMPLT.ToString, AlrtNotifyHdrId.ToString)
                                SettingValue.DisplayText = TemplateName
                                AdvantageFramework.Database.Procedures.SettingValue.Update(DataContext, SettingValue)
                            End If

                        End If

                    Catch ex As Exception

                    End Try
                End Using
            End Using

        End If
    End Function

#End Region

#Region " Template Detail Tab "

    Private Sub CheckBoxIsDigitalAsset_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxIsDigitalAsset.CheckedChanged

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Dim SQL As String = "UPDATE ALERT_NOTIFY_HDR WITH(ROWLOCK) SET IS_DIGITAL_ASSET = @IS_DIGITAL_ASSET WHERE ALRT_NOTIFY_HDR_ID = @ALRT_NOTIFY_HDR_ID;"
            Dim SqlParameterAlertTemplateID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterIsDigitalAsset As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterAlertTemplateID = New System.Data.SqlClient.SqlParameter("@ALRT_NOTIFY_HDR_ID", SqlDbType.Int)
            SqlParameterIsDigitalAsset = New System.Data.SqlClient.SqlParameter("@IS_DIGITAL_ASSET", SqlDbType.Bit)

            SqlParameterAlertTemplateID.Value = Me.RadComboBoxAlertTemplate.SelectedItem.Value
            SqlParameterIsDigitalAsset.Value = Me.CheckBoxIsDigitalAsset.Checked

            DbContext.Database.ExecuteSqlCommand(SQL, SqlParameterAlertTemplateID, SqlParameterIsDigitalAsset)

        End Using

    End Sub
    Private Sub RadComboBoxAlertTemplate_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadComboBoxAlertTemplate.SelectedIndexChanged

        If Me.RadComboBoxAlertTemplate.SelectedIndex = 0 Then

            Me.RadListBoxAvailableStates.Items.Clear()
            Me.RadListBoxStatesInTemplate.Items.Clear()
            Me.RadListBoxEmps_AvailableEmps.Items.Clear()
            Me.RadListBoxEmps_EmpsInTemplateState.Items.Clear()
            Me.RadListBoxStatesInTemplateToCopyTo.Items.Clear()

            Me.DivCopyTeam.Visible = False

        Else

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Dim SQL As String = "SELECT ISNULL(IS_DIGITAL_ASSET, 0) FROM ALERT_NOTIFY_HDR WITH(NOLOCK) WHERE ALRT_NOTIFY_HDR_ID = @ALRT_NOTIFY_HDR_ID;"
                    Dim SqlParameterAlertTemplateID As System.Data.SqlClient.SqlParameter = Nothing

                    SqlParameterAlertTemplateID = New System.Data.SqlClient.SqlParameter("@ALRT_NOTIFY_HDR_ID", SqlDbType.Int)

                    SqlParameterAlertTemplateID.Value = Me.RadComboBoxAlertTemplate.SelectedItem.Value

                    Me.CheckBoxIsDigitalAsset.Checked = CType(DbContext.Database.SqlQuery(Of Boolean)(SQL, SqlParameterAlertTemplateID).FirstOrDefault, Boolean)

                End Using

            Catch ex As Exception
            End Try

            Me.BindRadLB_AvailableStates()
            Me.BindRadLB_StatesInTemplate()
            Me.RadListBoxEmps_AvailableEmps.Items.Clear()
            Me.RadListBoxEmps_EmpsInTemplateState.Items.Clear()

        End If

        Me.ClearAndDisableRadComboBoxTemplateStateWorkflow()
        Me.SetAvailableSelectionType()

    End Sub
    Private Sub RadioButtonListEmployeeListType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioButtonListEmployeeListType.SelectedIndexChanged

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Dim ans As AdvantageFramework.Database.Entities.AlertAssignmentTemplateState = Nothing

            ans = AdvantageFramework.Database.Procedures.AlertAssignmentTemplateState.LoadByAlertAssignmentTemplateIDAndAlertStateID(DbContext,
                                                                                                                                     Me.RadComboBoxAlertTemplate.SelectedValue,
                                                                                                                                     Me.RadListBoxStatesInTemplate.SelectedValue)

            If Not ans Is Nothing Then

                ans.EmployeeLookupType = Me.RadioButtonListEmployeeListType.SelectedIndex


                AdvantageFramework.Database.Procedures.AlertAssignmentTemplateState.Update(DbContext, ans)

            End If

        End Using

        Me.SetAvailableSelectionType()

        Me.SetExistingEmployeeListType()

    End Sub
    Private Sub LbtnTemplateCopy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LbtnTemplateCopy.Click
        If Me.RadComboBoxAlertTemplate.SelectedIndex > 0 Then
            Dim q As New AdvantageFramework.Web.QueryString()
            q = q.FromCurrent()
            q.AlertTemplateID = Me.RadComboBoxAlertTemplate.SelectedValue
            q.Page = "Maintenance_AlertAssignments_TemplateCopy.aspx"

            Me.OpenWindow("Copy Assignment Template", q.ToString(True), 175, 675, , True)

        Else
            Me.ShowMessage("Please select a Template")
        End If
    End Sub
    Private Sub ImageButtonWorkflowState_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonWorkflowState.Click

        If Me.RadComboBoxAlertTemplate.SelectedIndex <= 0 Then

            Me.ShowMessage("Please select a Template and a State in Template")
            Exit Sub

        End If
        If Me.RadListBoxStatesInTemplate.SelectedIndex < 0 Then

            Me.ShowMessage("Please select a State in Template")
            Exit Sub

        End If

        Dim qs As New AdvantageFramework.Web.QueryString()

        With qs

            .Page = "Maintenance_AlertAssignments_StateWorkflow.aspx"
            .AlertTemplateID = Me.RadComboBoxAlertTemplate.SelectedValue
            .AlertStateID = Me.RadListBoxStatesInTemplate.SelectedItem.Value
            .Add("pm", CType(Webvantage.Maintenance_AlertAssignments_StateWorkflow.PageMode.PresetTemplateState, Integer))

        End With

        Me.OpenWindow(qs, "Automated Assignments")

    End Sub

#Region " Available States listbox "

    Private Sub RadListBoxAvailableStates_Dropped(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadListBoxDroppedEventArgs) Handles RadListBoxAvailableStates.Dropped
        If Me.ImgBtnCompletedState.ClientID = e.HtmlElementID Then
            Me.LblCompletedState.Text = ""
            Dim ThisStateId As String = ""
            For Each item As RadListBoxItem In e.SourceDragItems
                Me.LblCompletedState.Text &= item.Text & vbLf
                ThisStateId = item.Value
            Next
            If IsNumeric(ThisStateId) = True And Me.RadComboBoxAlertTemplate.SelectedIndex > 0 Then
                Dim sb As New System.Text.StringBuilder
                With sb
                    .Append("UPDATE ALERT_NOTIFY_STATES WITH(ROWLOCK) SET IS_COMPLETED = NULL WHERE ALRT_NOTIFY_HDR_ID = ")
                    .Append(Me.RadComboBoxAlertTemplate.SelectedValue)
                    .Append(";")
                    .Append("INSERT INTO ALERT_NOTIFY_STATES WITH(ROWLOCK) (ALRT_NOTIFY_HDR_ID, ALERT_STATE_ID, SORT_ORDER, DFLT_EMP_CODE, IS_DFLT, IS_COMPLETED) VALUES (")
                    .Append(Me.RadComboBoxAlertTemplate.SelectedValue)
                    .Append(", ")
                    .Append(ThisStateId)
                    .Append(", NULL,NULL,NULL, 1);")
                End With
                Dim s As String = ""
                s = sb.ToString()
                If s.Trim() <> "" Then
                    Try
                        SqlHelper.ExecuteNonQuery(Session("ConnString"), CommandType.Text, s)
                    Catch ex As Exception
                    End Try
                End If
                Me.LblCompletedState.Text &= "<br />Click icon to remove"
                Me.BindRadLB_AvailableStates()
                Me.BindRadLB_StatesInTemplate()
            End If
        Else
            Me.ShowMessage("Not allowed")
        End If

    End Sub
    Private Sub RadListBoxAvailableStates_Inserted(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadListBoxEventArgs) Handles RadListBoxAvailableStates.Inserted
        If Me.RadComboBoxAlertTemplate.SelectedIndex > 0 Then
            'remove the item from the template
            Dim sb As New System.Text.StringBuilder
            For Each item As RadListBoxItem In e.Items
                With sb
                    .Append(item.Value)
                    .Append(",")
                End With
            Next
            Dim s As String = ""
            s = sb.ToString()
            s = MiscFN.RemoveTrailingDelimiter(s, ",")
            If s.Trim() <> "" Then
                Dim StrSQL As String = "DELETE FROM ALERT_NOTIFY_STATES WITH(ROWLOCK) WHERE ALRT_NOTIFY_HDR_ID = " & Me.RadComboBoxAlertTemplate.SelectedValue & " AND ALERT_STATE_ID IN (" & s & ") AND ALERT_STATE_ID NOT IN (SELECT DISTINCT ALERT_STATE_ID FROM ALERT WITH(NOLOCK) WHERE (NOT (ALERT.ALERT_STATE_ID IS NULL)) AND ALERT.ALRT_NOTIFY_HDR_ID = " & Me.RadComboBoxAlertTemplate.SelectedValue & ");" &
                                       "DELETE FROM ALERT_NOTIFY_EMPS WITH(ROWLOCK) WHERE ALRT_NOTIFY_HDR_ID = " & Me.RadComboBoxAlertTemplate.SelectedValue & " AND ALERT_STATE_ID IN (" & s & ") AND ALERT_STATE_ID NOT IN (SELECT DISTINCT ALERT_STATE_ID FROM ALERT WITH(NOLOCK) WHERE (NOT (ALERT.ALERT_STATE_ID IS NULL)) AND ALERT.ALRT_NOTIFY_HDR_ID = " & Me.RadComboBoxAlertTemplate.SelectedValue & ");"

                Try
                    SqlHelper.ExecuteNonQuery(Session("ConnString"), CommandType.Text, StrSQL)
                    Me.BindRadLB_AvailableStates()
                    Me.BindRadLB_StatesInTemplate()
                    Me.BindRadListBox_Available()
                    Me.BindRadListBoxEmps_EmpsInTemplateState()
                    Me.LblEmpDefaultEmp.Text = Me.DefaultEmpLabelMSG
                Catch ex As Exception
                    Me.ShowMessage("Error removing State(s) from Template")
                End Try
            End If
        End If
    End Sub

    Private Sub BindRadLB_AvailableStates()
        Me.RadListBoxAvailableStates.Items.Clear()
        If Me.RadComboBoxAlertTemplate.Items.Count > 0 Then
            If Me.RadComboBoxAlertTemplate.SelectedIndex > 0 Then
                Dim a As New cAlerts()
                Dim dt As New DataTable
                dt = a.GetTemplateAvailableAlertStates(Me.RadComboBoxAlertTemplate.SelectedValue)
                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        For i As Integer = 0 To dt.Rows.Count - 1
                            Dim item As New RadListBoxItem
                            With item
                                .Text = dt.Rows(i)("ALERT_STATE_NAME")
                                .Value = dt.Rows(i)("ALERT_STATE_ID")
                            End With
                            Me.RadListBoxAvailableStates.Items.Add(item)
                        Next
                    End If
                End If
            End If
        End If
    End Sub

#End Region
#Region " States Currently In Template listbox "

    Private Sub RadListBoxStatesInTemplate_Dropped(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadListBoxDroppedEventArgs) Handles RadListBoxStatesInTemplate.Dropped
        If Me.ImgBtnCompletedState.ClientID = e.HtmlElementID Then
            Me.LblCompletedState.Text = ""
            Dim ThisStateId As String = ""
            For Each item As RadListBoxItem In e.SourceDragItems
                Me.LblCompletedState.Text &= item.Text & vbLf
                ThisStateId = item.Value
            Next
            If IsNumeric(ThisStateId) = True And Me.RadComboBoxAlertTemplate.SelectedIndex > 0 Then
                Dim s As String = ""
                Dim a As New cAlerts()
                a.UpdateCompletedState(CType(Me.RadComboBoxAlertTemplate.SelectedValue, Integer), CType(ThisStateId, Integer))
                If s = "" Then
                    Me.BindRadLB_StatesInTemplate()
                Else
                    LblCompletedState.Text = s & "<br />Click icon to remove"
                End If
            End If
        ElseIf Me.ImageButtonWorkflowState.ClientID = e.HtmlElementID Then
            Me.LabelWorkflowState.Text = ""
            Dim ThisStateId As String = ""
            For Each item As RadListBoxItem In e.SourceDragItems
                ThisStateId = item.Value
            Next
            If IsNumeric(ThisStateId) = True And Me.RadComboBoxAlertTemplate.SelectedIndex > 0 Then
                'Dim q As New AdvantageFramework.Web.QueryString()
                'With q
                '    .Page = "Maintenance_AlertAssignments_StateWorkflow.aspx"
                '    .AlertNotifyHdrId = CType(Me.RadComboBoxAlertTemplate.SelectedValue, Integer)
                '    .AlertStateId = CType(ThisStateId, Integer)
                'End With
                'Me.RefreshCaller(q.ToString(True), False, True, True)
            End If

        Else
            Me.ShowMessage("Not allowed")
        End If

    End Sub
    Private Sub RadListBoxStatesInTemplate_Inserted(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadListBoxEventArgs) Handles RadListBoxStatesInTemplate.Inserted
        If Me.RadComboBoxAlertTemplate.SelectedIndex > 0 Then
            'add state to template here
            Dim sb As New System.Text.StringBuilder
            For Each item As RadListBoxItem In e.Items
                With sb
                    .Append("INSERT INTO ALERT_NOTIFY_STATES WITH(ROWLOCK) (ALRT_NOTIFY_HDR_ID,	ALERT_STATE_ID,	SORT_ORDER,	DFLT_EMP_CODE) VALUES (")
                    .Append(Me.RadComboBoxAlertTemplate.SelectedValue)
                    .Append(", ")
                    .Append(item.Value)
                    .Append(", ")
                    .Append(item.Index)
                    .Append(", NULL);")
                End With
            Next
            Dim s As String = ""
            s = sb.ToString()
            If s.Trim() <> "" Then
                Try
                    SqlHelper.ExecuteNonQuery(Session("ConnString"), CommandType.Text, s)
                Catch ex As Exception
                End Try
            End If
        End If
    End Sub
    Private Sub RadListBoxStatesInTemplate_Reordered(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadListBoxEventArgs) Handles RadListBoxStatesInTemplate.Reordered
        'make sure order is correct
        Dim sb As New System.Text.StringBuilder
        If Me.RadComboBoxAlertTemplate.SelectedIndex > 0 Then
            Dim i As Integer = 0
            For Each item As RadListBoxItem In Me.RadListBoxStatesInTemplate.Items ' e.Items
                i += 1
                With sb
                    .Append("UPDATE ALERT_NOTIFY_STATES WITH(ROWLOCK) SET SORT_ORDER = ")
                    .Append(i)
                    .Append(" WHERE ALRT_NOTIFY_HDR_ID = ")
                    .Append(Me.RadComboBoxAlertTemplate.SelectedValue)
                    .Append(" AND ALERT_STATE_ID = ")
                    .Append(item.Value)
                    .Append(";")
                End With
            Next
            Dim s As String = ""
            s = sb.ToString()
            If s.Trim() <> "" Then
                Try
                    SqlHelper.ExecuteNonQuery(Session("ConnString"), CommandType.Text, s)
                Catch ex As Exception
                End Try
            End If
        End If
    End Sub
    Private Sub RadListBoxStatesInTemplate_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadListBoxStatesInTemplate.SelectedIndexChanged

        Me.LblEmpDefaultEmp.Text = Me.DefaultEmpLabelMSG

        If Me.TemplateAndStateSelected(True) = True Then

            Me.SetExistingEmployeeListType()

            If Me.DivCopyTeam.Visible = True Then

                Me.BindRadLB_StatesInTemplateToCopyTo()

            End If

        Else

            Me.RadListBoxEmps_AvailableEmps.Items.Clear()
            Me.RadListBoxEmps_EmpsInTemplateState.Items.Clear()
            Me.RadListBoxStatesInTemplateToCopyTo.Items.Clear()

            Me.ClearAndDisableRadComboBoxTemplateStateWorkflow()

        End If

        Me.SetAvailableSelectionType()

    End Sub

    Private Sub BindRadLB_StatesInTemplate()
        Me.RadListBoxStatesInTemplate.Items.Clear()
        If Me.RadComboBoxAlertTemplate.Items.Count > 0 Then
            If Me.RadComboBoxAlertTemplate.SelectedIndex > 0 Then
                Dim a As New cAlerts()
                Dim dt As New DataTable
                dt = a.GetAlertStates(0, 0, Me.RadComboBoxAlertTemplate.SelectedValue)
                Dim HasCompleted As Boolean = False
                Dim HasWorkflow As Boolean = False
                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        For i As Integer = 0 To dt.Rows.Count - 1
                            Dim item As New RadListBoxItem
                            With item
                                .Text = dt.Rows(i)("ALERT_STATE_NAME")
                                .Value = dt.Rows(i)("ALERT_STATE_ID")
                            End With
                            Me.RadListBoxStatesInTemplate.Items.Add(item)
                            If CType(dt.Rows(i)("IS_COMPLETED"), Integer) = 1 Then
                                HasCompleted = True
                                Me.LblCompletedState.Text = dt.Rows(i)("ALERT_STATE_NAME").ToString() & "<br />Click icon to remove"
                            End If
                            'If CType(dt.Rows(i)("HAS_WORKFLOW"), Integer) = 1 Then
                            '    HasWorkflow = True
                            '    Me.LabelWorkflowState.Text = dt.Rows(i)("ALERT_STATE_NAME").ToString() & "<br />Click icon to remove"
                            'End If
                        Next
                    End If
                End If
                If HasCompleted = False Then
                    Me.LblCompletedState.Text = Me.DefaultCompletedStateLabelMSG
                End If
                If HasWorkflow = False Then
                    Me.LabelWorkflowState.Text = Me.DefaultWorkflowLabelMSG
                End If
            End If
        End If
    End Sub
    Private Function TemplateAndStateSelected(ByVal ShowMessages As Boolean) As Boolean
        Try

            If Me.RadComboBoxAlertTemplate.SelectedIndex > 0 Then
            Else
                If ShowMessages = True Then Me.ShowMessage("Please select a Template")
                Return False
            End If

            Dim NumberOfSelectedRecords As Integer = 0
            For i As Integer = 0 To Me.RadListBoxStatesInTemplate.Items.Count - 1
                If Me.RadListBoxStatesInTemplate.Items(i).Selected = True Then
                    NumberOfSelectedRecords += 1
                End If
            Next

            Select Case NumberOfSelectedRecords
                Case 1
                    Return True
                Case 0
                    If ShowMessages = True Then Me.ShowMessage("Please select a State")
                    Return False
                Case Is > 1
                    If ShowMessages = True Then Me.ShowMessage("Please select only one State")
                    Return False
            End Select

        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Sub SetExistingEmployeeListType()
        Using DbContext As New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

            Dim ast As AdvantageFramework.Database.Entities.AlertAssignmentTemplateState = Nothing

            ast = AdvantageFramework.Database.Procedures.AlertAssignmentTemplateState.LoadByAlertAssignmentTemplateIDAndAlertStateID(DbContext,
                                                                                                                                    Me.RadComboBoxAlertTemplate.SelectedValue,
                                                                                                                                    Me.RadListBoxStatesInTemplate.SelectedValue)

            If Not ast Is Nothing Then

                Dim CurrentListType As EmployeesListType = EmployeesListType.ManualEmployees

                If Not ast.EmployeeLookupType Is Nothing AndAlso IsNumeric(ast.EmployeeLookupType) = True Then

                    CurrentListType = CType(CType(ast.EmployeeLookupType, Integer), EmployeesListType)

                End If

                Me.RadioButtonListEmployeeListType.SelectedIndex = CType(CurrentListType, Integer)

                Me.BindRadListBox_Available()
                Me.BindRadListBoxEmps_EmpsInTemplateState()

                If Me.RadListBoxEmps_AvailableEmps.Items.Count > 0 Then

                    Dim SelectedItem As RadListBoxItem

                    Select Case CurrentListType

                        Case EmployeesListType.AlertGroup

                            'If Not ast.DefaultAlertGroupCode = Nothing Then

                            '    MiscFN.RadListBoxSetIndex(Me.RadListBoxEmps_AvailableEmps, ast.DefaultAlertGroupCode, False, True)

                            'End If
                            Dim list As New Generic.List(Of AdvantageFramework.Database.Entities.AlertAssignmentTemplateEmailGroup)

                            list = AdvantageFramework.Database.Procedures.AlertAssignmentTemplateEmailGroup.LoadByAlertAssignmentTemplateIDAndAlertStateID(DbContext,
                                                                                                                                                           Me.RadComboBoxAlertTemplate.SelectedValue,
                                                                                                                                                           Me.RadListBoxStatesInTemplate.SelectedValue).ToList()
                            If Not list Is Nothing Then

                                For Each item As AdvantageFramework.Database.Entities.AlertAssignmentTemplateEmailGroup In list

                                    SelectedItem = Me.RadListBoxEmps_AvailableEmps.FindItemByValue(item.EmailGroupCode)

                                    If Not SelectedItem Is Nothing Then

                                        SelectedItem.Selected = True
                                        SelectedItem = Nothing

                                    Else

                                        Me.RadListBoxEmps_AvailableEmps.Items.Add(New RadListBoxItem(item.EmailGroupCode & "*", item.EmailGroupCode))

                                    End If

                                Next

                            End If

                        Case EmployeesListType.DepartmentTeam

                            'If Not ast.DefaultDepartmentTeamCode = Nothing Then

                            '    MiscFN.RadListBoxSetIndex(Me.RadListBoxEmps_AvailableEmps, ast.DefaultDepartmentTeamCode, False, True)

                            'End If
                            Dim list As New Generic.List(Of AdvantageFramework.Database.Entities.AlertAssignmentTemplateDepartmentTeam)

                            list = AdvantageFramework.Database.Procedures.AlertAssignmentTemplateDepartmentTeam.LoadByAlertAssignmentTemplateIDAndAlertStateID(DbContext,
                                                                                                                                                           Me.RadComboBoxAlertTemplate.SelectedValue,
                                                                                                                                                           Me.RadListBoxStatesInTemplate.SelectedValue).ToList()
                            If Not list Is Nothing Then

                                For Each item As AdvantageFramework.Database.Entities.AlertAssignmentTemplateDepartmentTeam In list

                                    SelectedItem = Me.RadListBoxEmps_AvailableEmps.FindItemByValue(item.DepartmentTeamCode)

                                    If Not SelectedItem Is Nothing Then

                                        SelectedItem.Selected = True
                                        SelectedItem = Nothing

                                    Else

                                        Me.RadListBoxEmps_AvailableEmps.Items.Add(New RadListBoxItem(item.DepartmentTeamCode & "*", item.DepartmentTeamCode))

                                    End If

                                Next

                            End If

                        Case EmployeesListType.Role

                            'If Not ast.DefaultRoleCode = Nothing Then

                            '    MiscFN.RadListBoxSetIndex(Me.RadListBoxEmps_AvailableEmps, ast.DefaultRoleCode, False, True)

                            'End If
                            Dim list As New Generic.List(Of AdvantageFramework.Database.Entities.AlertAssignmentTemplateRole)

                            list = AdvantageFramework.Database.Procedures.AlertAssignmentTemplateRole.LoadByAlertAssignmentTemplateIDAndAlertStateID(DbContext,
                                                                                                                                                           Me.RadComboBoxAlertTemplate.SelectedValue,
                                                                                                                                                           Me.RadListBoxStatesInTemplate.SelectedValue).ToList()
                            If Not list Is Nothing Then

                                For Each item As AdvantageFramework.Database.Entities.AlertAssignmentTemplateRole In list

                                    SelectedItem = Me.RadListBoxEmps_AvailableEmps.FindItemByValue(item.RoleCode)

                                    If Not SelectedItem Is Nothing Then

                                        SelectedItem.Selected = True
                                        SelectedItem = Nothing

                                    Else

                                        Me.RadListBoxEmps_AvailableEmps.Items.Add(New RadListBoxItem(item.RoleCode & "*", item.RoleCode))

                                    End If

                                Next

                            End If

                    End Select

                End If

            End If

        End Using

    End Sub

#End Region

#Region " Available selections listbox "

    Private Sub BindRadListBox_Available()

        Me.RadListBoxEmps_AvailableEmps.Items.Clear()
        Me.RadListBoxEmps_EmpsInTemplateState.Items.Clear()

        If Me.RadComboBoxAlertTemplate.Items.Count > 0 AndAlso Me.RadComboBoxAlertTemplate.SelectedIndex > 0 Then

            Select Case Me.RadioButtonListEmployeeListType.SelectedValue
                Case "manual"

                    Dim DataView As DataView = Nothing
                    If Me.RadComboBoxAlertTemplate.SelectedIndex > 0 And Me.RadListBoxStatesInTemplate.SelectedIndex > -1 Then
                        Dim a As New cAlerts()
                        Dim dt As New DataTable

                        Select Case Me.RblAvailableEmployeesFilter.SelectedValue
                            Case "role"
                                dt = a.GetAvailableEmployees(Me.RadComboBoxAlertTemplate.SelectedValue, Me.RadListBoxStatesInTemplate.SelectedValue, Me.DropAvailableEmployeesFilter.SelectedValue, "")
                            Case "alert_group"
                                dt = a.GetAvailableEmployees(Me.RadComboBoxAlertTemplate.SelectedValue, Me.RadListBoxStatesInTemplate.SelectedValue, "", Me.DropAvailableEmployeesFilter.SelectedValue)
                            Case "none"
                                If Not Me.IsPostBack And Not Me.IsCallback Then
                                    'don't load anything?
                                Else 'it is post/call back
                                    dt = a.GetAvailableEmployees(Me.RadComboBoxAlertTemplate.SelectedValue, Me.RadListBoxStatesInTemplate.SelectedValue, "", "")
                                End If
                            Case Else
                                dt = a.GetAvailableEmployees(Me.RadComboBoxAlertTemplate.SelectedValue, Me.RadListBoxStatesInTemplate.SelectedValue, "", "")
                        End Select

                        If Not dt Is Nothing Then
                            If dt.Rows.Count > 0 Then

                                DataView = New DataView(dt)

                                DataView.Sort = "EMP_FML"

                                dt = DataView.ToTable()

                                Dim DfltEmpCode As String = ""
                                Dim DfltEmpName As String = ""
                                For i As Integer = 0 To dt.Rows.Count - 1
                                    Dim item As New RadListBoxItem
                                    With item
                                        .Text = dt.Rows(i)("EMP_FML")
                                        .Value = dt.Rows(i)("EMP_CODE")
                                    End With
                                    Me.RadListBoxEmps_AvailableEmps.Items.Add(item)
                                Next
                            End If
                        End If
                    End If

                Case "role"

                    Using DbContext As New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                        Dim list As New Generic.List(Of AdvantageFramework.Database.Entities.Role)
                        list = Nothing

                        list = AdvantageFramework.Database.Procedures.Role.LoadAllActive(DbContext).ToList()

                        If Not list Is Nothing Then

                            For Each role In list

                                Dim item As New RadListBoxItem
                                With item
                                    .Text = role.Description
                                    .Value = role.Code
                                End With

                                Me.RadListBoxEmps_AvailableEmps.Items.Add(item)

                            Next

                        End If

                    End Using

                Case "department"

                    Using DbContext As New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                        Dim list As New Generic.List(Of AdvantageFramework.Database.Entities.DepartmentTeam)
                        list = Nothing

                        list = AdvantageFramework.Database.Procedures.DepartmentTeam.LoadAllActive(DbContext).ToList()

                        If Not list Is Nothing Then

                            For Each dpttm In list

                                Dim item As New RadListBoxItem
                                With item
                                    .Text = dpttm.Description
                                    .Value = dpttm.Code
                                End With

                                Me.RadListBoxEmps_AvailableEmps.Items.Add(item)

                            Next

                        End If

                    End Using

                Case "alertgroup"

                    Using DbContext As New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                        Dim list As New Generic.List(Of AdvantageFramework.Database.Entities.AlertGroup)
                        list = Nothing

                        list = AdvantageFramework.Database.Procedures.AlertGroup.LoadAllActiveDistinctAlertGroups(DbContext).ToList()

                        If Not list Is Nothing Then

                            For Each alrtgrp In list

                                Dim item As New RadListBoxItem
                                With item
                                    .Text = alrtgrp.Code
                                    .Value = alrtgrp.Code
                                End With

                                Me.RadListBoxEmps_AvailableEmps.Items.Add(item)

                            Next

                        End If

                    End Using

            End Select

        End If

    End Sub
    Private Sub SetAvailableSelectionType()

        If Me.RadComboBoxAlertTemplate.SelectedIndex = -1 OrElse Me.RadComboBoxAlertTemplate.SelectedIndex = 0 Then

            Me.ImageButtonCopyTemplate.Visible = False
            Me.DivSelectedTemplateOptions.Visible = False

        Else

            Me.ImageButtonCopyTemplate.Visible = True
            Me.DivSelectedTemplateOptions.Visible = True

        End If

        If Me.RadComboBoxAlertTemplate.SelectedIndex = -1 OrElse Me.RadComboBoxAlertTemplate.SelectedIndex = 0 OrElse Me.RadListBoxStatesInTemplate.SelectedIndex = -1 Then

            Me.RadioButtonListEmployeeListType.Enabled = False
            Me.RadListBoxEmps_AvailableEmps.Enabled = False
            Me.RadListBoxEmps_EmpsInTemplateState.Enabled = False
            Me.FieldsetFilterEmployees.Visible = False
            Me.RadListBoxEmps_AvailableEmps.Items.Clear()
            Me.RadListBoxEmps_EmpsInTemplateState.Items.Clear()

        Else

            Me.RadioButtonListEmployeeListType.Enabled = True
            Me.RadListBoxEmps_AvailableEmps.Enabled = True
            Me.RadListBoxEmps_AvailableEmps.SelectionMode = ListBoxSelectionMode.Multiple
            Me.RadListBoxEmps_AvailableEmps.AutoPostBack = True
            Me.RadListBoxEmps_EmpsInTemplateState.Enabled = True
            Me.FieldsetFilterEmployees.Visible = Me.RadioButtonListEmployeeListType.SelectedValue = "manual"
            Me.SetDragAndDropForEmployees()

            Select Case Me.RadioButtonListEmployeeListType.SelectedValue
                Case "manual"

                    Me.RadListBoxEmps_AvailableEmps.AutoPostBack = False

                    Me.LabelAvailableEmpListType.Text = "Available Employees"
                    Me.LabelCurrentEmployees.Text = "Employees Currently in State"

                Case "role"

                    Me.LabelAvailableEmpListType.Text = "Available Roles"
                    Me.LabelCurrentEmployees.Text = "Employees in this Role"

                Case "department"

                    Me.LabelAvailableEmpListType.Text = "Available Department/Team"
                    Me.LabelCurrentEmployees.Text = "Employees in this Department/Team"

                Case "alertgroup"

                    Me.LabelAvailableEmpListType.Text = "Available Alert Group"
                    Me.LabelCurrentEmployees.Text = "Employees in this Alert Group"

            End Select

        End If

    End Sub
    Private Sub SetDragAndDropForEmployees()

        If Me.RadioButtonListEmployeeListType.SelectedValue = "manual" Then

            With Me.RadListBoxEmps_AvailableEmps

                .AllowTransfer = True
                .EnableDragAndDrop = True
                .TransferToID = "RadListBoxEmps_EmpsInTemplateState"

            End With
            With Me.RadListBoxEmps_EmpsInTemplateState

                .AllowTransfer = True
                .EnableDragAndDrop = True
                .SelectionMode = ListBoxSelectionMode.Multiple

            End With

        Else

            With Me.RadListBoxEmps_AvailableEmps

                .AllowTransfer = False
                .EnableDragAndDrop = False
                .TransferToID = Nothing

            End With
            With Me.RadListBoxEmps_EmpsInTemplateState

                .AllowTransfer = False
                .EnableDragAndDrop = True
                .SelectionMode = ListBoxSelectionMode.Single

            End With

        End If

    End Sub

#Region " Manual "

    Private Sub RadListBoxEmps_AvailableEmps_Dropped(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadListBoxDroppedEventArgs) Handles RadListBoxEmps_AvailableEmps.Dropped
        If ImgBtnEmpDefaultEmp.ClientID = e.HtmlElementID Then
            Try
                LblEmpDefaultEmp.Text = ""
                Dim ThisEmpCode As String = ""
                For Each item As RadListBoxItem In e.SourceDragItems
                    LblEmpDefaultEmp.Text &= item.Value & " - " & item.Text + ", " & vbLf
                    ThisEmpCode = item.Value
                Next
                'save to current employees
                Dim sb As New System.Text.StringBuilder
                With sb
                    .Append("INSERT INTO ALERT_NOTIFY_EMPS WITH(ROWLOCK) (ALERT_STATE_ID, ALRT_NOTIFY_HDR_ID, EMP_CODE) VALUES (")
                    .Append(Me.RadListBoxStatesInTemplate.SelectedValue)
                    .Append(",")
                    .Append(Me.RadComboBoxAlertTemplate.SelectedValue)
                    .Append(", '")
                    .Append(ThisEmpCode)
                    .Append("');")
                End With
                Dim s As String = ""
                s = sb.ToString()
                If s.Trim() <> "" Then
                    Try
                        SqlHelper.ExecuteNonQuery(Session("ConnString"), CommandType.Text, s)
                    Catch ex As Exception
                    End Try
                End If
                Me.BindRadListBox_Available()
                'set as default too
                Me.SetDefaultEmployee(ThisEmpCode)
                Me.BindRadListBoxEmps_EmpsInTemplateState()
            Catch ex As Exception
                Me.ShowMessage("Error")
            End Try
        Else
            Me.ShowMessage("Not allowed")
        End If
    End Sub
    Private Sub RadListBoxEmps_AvailableEmps_Inserted(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadListBoxEventArgs) Handles RadListBoxEmps_AvailableEmps.Inserted
        If Me.RadComboBoxAlertTemplate.SelectedIndex > 0 And Me.RadListBoxStatesInTemplate.SelectedIndex > -1 Then
            'Remove the emp(s) from the Template/State
            Dim sb As New System.Text.StringBuilder
            For Each item As RadListBoxItem In e.Items
                With sb
                    .Append("'")
                    .Append(item.Value)
                    .Append("',")
                End With
            Next
            Dim s As String = ""
            s = sb.ToString()
            s = MiscFN.RemoveTrailingDelimiter(s, ",")
            If s.Trim() <> "" Then
                Dim StrSQL As String = "DELETE FROM ALERT_NOTIFY_EMPS WITH(ROWLOCK) WHERE ALRT_NOTIFY_HDR_ID = " & Me.RadComboBoxAlertTemplate.SelectedValue & " AND ALERT_STATE_ID = " &
                    Me.RadListBoxStatesInTemplate.SelectedValue & " AND EMP_CODE IN (" & s & ");"
                'Dim SbSQL As New System.Text.StringBuilder
                'With SbSQL
                '    .Append(" DELETE FROM ALERT_NOTIFY_EMPS WITH(ROWLOCK) ")
                '    .Append(" WHERE  ALRT_NOTIFY_HDR_ID = ")
                '    .Append(Me.RadComboBoxAlertTemplate.SelectedValue)
                '    .Append("       AND ALERT_STATE_ID = ")
                '    .Append(Me.RadListBoxStatesInTemplate.SelectedValue)
                '    .Append("       AND EMP_CODE IN (")
                '    .Append(s)
                '    .Append(")")
                '    '.Append("       AND EMP_CODE NOT IN (")
                '    '.Append("       						SELECT DISTINCT ALERT_RCPT.EMP_CODE")
                '    '.Append("                            FROM   ALERT WITH (NOLOCK)")
                '    '.Append("                                   INNER JOIN ALERT_RCPT WITH (NOLOCK)")
                '    '.Append("                                        ON  ALERT.ALERT_ID = ALERT_RCPT.ALERT_ID")
                '    '.Append("                            WHERE  (ALERT.ALRT_NOTIFY_HDR_ID = ")
                '    '.Append(Me.RadComboBoxAlertTemplate.SelectedValue)
                '    '.Append(") ")
                '    '.Append("                                   AND (ALERT.ALERT_STATE_ID = ")
                '    '.Append(Me.RadListBoxStatesInTemplate.SelectedValue)
                '    '.Append(") ")
                '    '.Append("                                   AND (ALERT_RCPT.CURRENT_NOTIFY = 1)")
                '    '.Append("       )")
                '    .Append(";")
                'End With
                'Dim StrSQL As String = SbSQL.ToString()
                Try
                    SqlHelper.ExecuteNonQuery(Session("ConnString"), CommandType.Text, StrSQL)
                    Me.BindRadListBox_Available()
                    Me.BindRadListBoxEmps_EmpsInTemplateState()
                Catch ex As Exception
                    Exit Sub
                End Try
            End If

        End If
    End Sub
    Private Sub RadListBoxEmps_AvailableEmps_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadListBoxEmps_AvailableEmps.SelectedIndexChanged

        Me.SaveEmployeeListType()

    End Sub

    Private Sub RblAvailableEmployeesFilter_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RblAvailableEmployeesFilter.SelectedIndexChanged
        Dim v As New cAppVars(cAppVars.Application.ALERT_ASSIGNMENT_MAINT)
        v.getAllAppVars()
        v.setAppVar("EMP_FILTER", Me.RblAvailableEmployeesFilter.SelectedValue, "String")
        v.SaveAllAppVars()

        Me.BindDropAvailableEmployeesFilter()
        Try
            Dim s As String = ""
            If Me.RblAvailableEmployeesFilter.SelectedIndex > -1 Then
                Me.BindDropAvailableEmployeesFilter()
                Select Case Me.RblAvailableEmployeesFilter.SelectedValue
                    Case "role"
                        s = v.getAppVar("EMP_FILTER_ROLE_CODE")
                    Case "alert_group"
                        s = v.getAppVar("EMP_FILTER_EML_GRP_CODE")
                End Select
                If s <> "" And Me.DropAvailableEmployeesFilter.Items.Count > 0 Then
                    MiscFN.RadComboBoxSetIndex(Me.DropAvailableEmployeesFilter, s, False)
                End If
            End If
        Catch ex As Exception
        End Try
        Me.BindRadListBox_Available()
    End Sub
    Private Sub BindDropAvailableEmployeesFilter()
        Dim d As New cDropDowns(Session("ConnString"))
        With Me.DropAvailableEmployeesFilter
            Select Case Me.RblAvailableEmployeesFilter.SelectedValue
                Case "role"
                    .DataSource = d.GetRoles()
                    .DataTextField = "Description"
                    .DataValueField = "Code"
                    .DataBind()
                    .Enabled = True
                Case "alert_group"
                    .DataSource = d.GetEmailAlertGroups()
                    .DataTextField = "Description"
                    .DataValueField = "Code"
                    .DataBind()
                    .Enabled = True
                Case "none"
                    .Items.Clear()
                    .Enabled = False
            End Select
        End With
    End Sub
    Private Sub DropAvailableEmployeesFilter_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropAvailableEmployeesFilter.SelectedIndexChanged
        Dim v As New cAppVars(cAppVars.Application.ALERT_ASSIGNMENT_MAINT)
        v.getAllAppVars()
        If Me.RblAvailableEmployeesFilter.SelectedValue = "role" Then
            v.setAppVar("EMP_FILTER_ROLE_CODE", Me.DropAvailableEmployeesFilter.SelectedValue, "String")
        ElseIf Me.RblAvailableEmployeesFilter.SelectedValue = "alert_group" Then
            v.setAppVar("EMP_FILTER_EML_GRP_CODE", Me.DropAvailableEmployeesFilter.SelectedValue, "String")
        End If
        v.SaveAllAppVars()
        Me.BindRadListBox_Available()
    End Sub

#End Region

#Region " Other Employee List Types "

    Private Sub SaveEmployeeListType()
        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Dim ans As AdvantageFramework.Database.Entities.AlertAssignmentTemplateState = Nothing

            ans = AdvantageFramework.Database.Procedures.AlertAssignmentTemplateState.LoadByAlertAssignmentTemplateIDAndAlertStateID(DbContext,
                                                                                                                                     Me.RadComboBoxAlertTemplate.SelectedValue,
                                                                                                                                     Me.RadListBoxStatesInTemplate.SelectedValue)

            If Not ans Is Nothing Then

                ans.EmployeeLookupType = Me.RadioButtonListEmployeeListType.SelectedIndex

                If Me.RadListBoxEmps_AvailableEmps.SelectedIndex > -1 Then

                    Select Case Me.RadioButtonListEmployeeListType.SelectedValue
                        Case "role"

                            'ans.DefaultRoleCode = Me.RadListBoxEmps_AvailableEmps.SelectedValue
                            AdvantageFramework.Database.Procedures.AlertAssignmentTemplateRole.DeleteByAlertAssignmentTemplateIDAndAlertStateID(DbContext,
                                                                                                                                                Me.RadComboBoxAlertTemplate.SelectedValue,
                                                                                                                                                Me.RadListBoxStatesInTemplate.SelectedValue)
                            Dim list As New Generic.List(Of AdvantageFramework.Database.Entities.AlertAssignmentTemplateRole)
                            Dim AlertAssignmentEntityItem As AdvantageFramework.Database.Entities.AlertAssignmentTemplateRole
                            For Each item In Me.RadListBoxEmps_AvailableEmps.SelectedItems

                                AlertAssignmentEntityItem = New AdvantageFramework.Database.Entities.AlertAssignmentTemplateRole

                                AlertAssignmentEntityItem.AlertAssignmentTemplateID = Me.RadComboBoxAlertTemplate.SelectedValue
                                AlertAssignmentEntityItem.AlertStateID = Me.RadListBoxStatesInTemplate.SelectedValue
                                AlertAssignmentEntityItem.RoleCode = item.Value

                                list.Add(AlertAssignmentEntityItem)

                                AlertAssignmentEntityItem = Nothing

                            Next

                            If list.Count > 0 Then

                                AdvantageFramework.Database.Procedures.AlertAssignmentTemplateRole.InsertList(DbContext, list)

                            End If

                        Case "department"

                            'ans.DefaultDepartmentTeamCode = Me.RadListBoxEmps_AvailableEmps.SelectedValue
                            AdvantageFramework.Database.Procedures.AlertAssignmentTemplateDepartmentTeam.DeleteByAlertAssignmentTemplateIDAndAlertStateID(DbContext,
                                                                                                                                                Me.RadComboBoxAlertTemplate.SelectedValue,
                                                                                                                                                Me.RadListBoxStatesInTemplate.SelectedValue)
                            Dim list As New Generic.List(Of AdvantageFramework.Database.Entities.AlertAssignmentTemplateDepartmentTeam)
                            Dim AlertAssignmentEntityItem As AdvantageFramework.Database.Entities.AlertAssignmentTemplateDepartmentTeam
                            For Each item In Me.RadListBoxEmps_AvailableEmps.SelectedItems

                                AlertAssignmentEntityItem = New AdvantageFramework.Database.Entities.AlertAssignmentTemplateDepartmentTeam

                                AlertAssignmentEntityItem.AlertAssignmentTemplateID = Me.RadComboBoxAlertTemplate.SelectedValue
                                AlertAssignmentEntityItem.AlertStateID = Me.RadListBoxStatesInTemplate.SelectedValue
                                AlertAssignmentEntityItem.DepartmentTeamCode = item.Value

                                list.Add(AlertAssignmentEntityItem)

                                AlertAssignmentEntityItem = Nothing

                            Next

                            If list.Count > 0 Then

                                AdvantageFramework.Database.Procedures.AlertAssignmentTemplateDepartmentTeam.InsertList(DbContext, list)

                            End If

                        Case "alertgroup"

                            'ans.DefaultAlertGroupCode = Me.RadListBoxEmps_AvailableEmps.SelectedValue
                            'ans.DefaultDepartmentTeamCode = Me.RadListBoxEmps_AvailableEmps.SelectedValue
                            AdvantageFramework.Database.Procedures.AlertAssignmentTemplateEmailGroup.DeleteByAlertAssignmentTemplateIDAndAlertStateID(DbContext,
                                                                                                                                                Me.RadComboBoxAlertTemplate.SelectedValue,
                                                                                                                                                Me.RadListBoxStatesInTemplate.SelectedValue)
                            Dim list As New Generic.List(Of AdvantageFramework.Database.Entities.AlertAssignmentTemplateEmailGroup)
                            Dim AlertAssignmentEntityItem As AdvantageFramework.Database.Entities.AlertAssignmentTemplateEmailGroup
                            For Each item In Me.RadListBoxEmps_AvailableEmps.SelectedItems

                                AlertAssignmentEntityItem = New AdvantageFramework.Database.Entities.AlertAssignmentTemplateEmailGroup

                                AlertAssignmentEntityItem.AlertAssignmentTemplateID = Me.RadComboBoxAlertTemplate.SelectedValue
                                AlertAssignmentEntityItem.AlertStateID = Me.RadListBoxStatesInTemplate.SelectedValue
                                AlertAssignmentEntityItem.EmailGroupCode = item.Value

                                list.Add(AlertAssignmentEntityItem)

                                AlertAssignmentEntityItem = Nothing

                            Next

                            If list.Count > 0 Then

                                AdvantageFramework.Database.Procedures.AlertAssignmentTemplateEmailGroup.InsertList(DbContext, list)

                            End If

                    End Select

                End If

                AdvantageFramework.Database.Procedures.AlertAssignmentTemplateState.Update(DbContext, ans)
                Me.BindRadListBoxEmps_EmpsInTemplateState()

            End If

        End Using

    End Sub

#End Region

#End Region
#Region " Current Assignment Team listbox "


    Private Sub RadListBoxEmps_EmpsInTemplateState_Dropped(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadListBoxDroppedEventArgs) Handles RadListBoxEmps_EmpsInTemplateState.Dropped

        If ImgBtnEmpDefaultEmp.ClientID = e.HtmlElementID Then

            LblEmpDefaultEmp.Text = ""
            Dim ThisEmpCode As String = ""

            For Each item As RadListBoxItem In e.SourceDragItems

                ThisEmpCode = String.Empty
                'LblEmpDefaultEmp.Text &= item.Value & " - " & item.Text + ", " & vbLf
                ThisEmpCode = item.Value

                Me.SetDefaultEmployee(ThisEmpCode)

            Next

            Me.BindRadListBoxEmps_EmpsInTemplateState()

        Else

            Me.ShowMessage("Not allowed")

        End If

    End Sub
    Private Sub RadListBoxEmps_EmpsInTemplateState_Inserted(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadListBoxEventArgs) Handles RadListBoxEmps_EmpsInTemplateState.Inserted
        If Me.RadComboBoxAlertTemplate.SelectedIndex > 0 And Me.RadListBoxStatesInTemplate.SelectedIndex > -1 Then
            'Add emp(s) to current assignment team (ALERT_NOTIFY_EMPS)
            Dim sb As New System.Text.StringBuilder
            For Each item As RadListBoxItem In e.Items
                With sb
                    .Append("INSERT INTO ALERT_NOTIFY_EMPS WITH(ROWLOCK) (ALERT_STATE_ID, ALRT_NOTIFY_HDR_ID, EMP_CODE) VALUES (")
                    .Append(Me.RadListBoxStatesInTemplate.SelectedValue)
                    .Append(",")
                    .Append(Me.RadComboBoxAlertTemplate.SelectedValue)
                    .Append(", '")
                    .Append(item.Value)
                    .Append("');")
                End With
            Next
            Dim s As String = ""
            s = sb.ToString()
            If s.Trim() <> "" Then
                Try
                    SqlHelper.ExecuteNonQuery(Session("ConnString"), CommandType.Text, s)
                Catch ex As Exception
                End Try
            End If
        End If
    End Sub

    Private Sub BindRadListBoxEmps_EmpsInTemplateState()
        Dim DataView As DataView = Nothing
        Me.RadListBoxEmps_EmpsInTemplateState.Items.Clear()
        If Me.RadListBoxStatesInTemplate.SelectedIndex > -1 And Me.RadComboBoxAlertTemplate.SelectedIndex > 0 Then
            Dim a As New cAlerts()
            Dim dt As New DataTable
            dt = a.GetNotificationRecipients(Me.RadListBoxStatesInTemplate.SelectedValue, 0, 0, Me.RadComboBoxAlertTemplate.SelectedValue, "", False, False, False)
            If Not dt Is Nothing Then
                If dt.Rows.Count > 0 Then
                    DataView = New DataView(dt)
                    DataView.Sort = "EMP_FML"
                    dt = DataView.ToTable()
                    Dim DfltEmpCode As String = ""
                    Dim DfltEmpName As String = ""
                    For i As Integer = 0 To dt.Rows.Count - 1
                        Dim item As New RadListBoxItem
                        With item
                            .Text = dt.Rows(i)("EMP_FML")
                            .Value = dt.Rows(i)("EMP_CODE")
                        End With

                        If dt.Rows(i)("IS_DEFAULT") = True Then

                            DfltEmpCode = dt.Rows(i)("EMP_CODE")
                            DfltEmpName = dt.Rows(i)("EMP_FML")

                            'Me.LblEmpDefaultEmp.Text = DfltEmpCode & " - " & DfltEmpName & "<br />Click icon to remove"
                            'If dt.Rows(i)("EMP_FML").ToString().IndexOf("*") > -1 Then
                            '    DfltEmpCode = dt.Rows(i)("EMP_CODE")
                            '    DfltEmpName = dt.Rows(i)("EMP_FML")
                            '    Me.LblEmpDefaultEmp.Text = DfltEmpCode & " - " & DfltEmpName & "<br />Click icon to remove"
                            'Else
                            '    Me.LblEmpDefaultEmp.Text = Me.DefaultEmpLabelMSG
                            'End If

                        End If

                        Me.RadListBoxEmps_EmpsInTemplateState.Items.Add(item)

                    Next

                    'If DfltEmpCode <> "" Then

                    '    Dim item As RadListBoxItem = Me.RadListBoxEmps_EmpsInTemplateState.FindItemByValue(DfltEmpCode)
                    '    If Not item Is Nothing Then
                    '        item.Selected
                    '    End If
                    'End If

                End If
            End If
        End If
    End Sub
    Private Sub SetDefaultEmployee(ByVal EmpCode As String)

        If EmpCode <> "" And Me.RadComboBoxAlertTemplate.SelectedIndex > 0 And Me.RadListBoxStatesInTemplate.SelectedIndex > -1 Then

            Dim s As String = ""
            Dim a As New cAlerts()

            s = a.UpdateDefaultEmployee(EmpCode, Me.RadComboBoxAlertTemplate.SelectedValue, Me.RadListBoxStatesInTemplate.SelectedValue)

            If s = "" Then

                Me.BindRadListBoxEmps_EmpsInTemplateState()

            Else

                LblEmpDefaultEmp.Text = s & "<br />Click icon to remove"

            End If

        End If
    End Sub


#End Region

#Region " Default Employee "

    Private Sub ImgBtnEmpDefaultEmp_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgBtnEmpDefaultEmp.Click
        Me.ClearDefaultEmployee()
    End Sub

    Private Sub ClearDefaultEmployee()
        If Me.RadListBoxStatesInTemplate.SelectedIndex > -1 And Me.RadComboBoxAlertTemplate.SelectedIndex > 0 Then
            Dim a As New cAlerts()
            a.UpdateDefaultEmployee("", Me.RadComboBoxAlertTemplate.SelectedValue, Me.RadListBoxStatesInTemplate.SelectedValue)
            Me.BindRadListBoxEmps_EmpsInTemplateState()
            Me.LblEmpDefaultEmp.Text = Me.DefaultEmpLabelMSG
        Else
            Me.ShowMessage("Please select a Template and a State Currently in Template")
        End If
    End Sub

#End Region
#Region " Default Completed State "

    Private Sub ImgBtnCompletedState_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgBtnCompletedState.Click
        Try
            If Me.RadComboBoxAlertTemplate.SelectedIndex > 0 Then
                Dim a As New cAlerts()
                a.UpdateCompletedState(Me.RadComboBoxAlertTemplate.SelectedValue, 0)
                Me.BindRadLB_StatesInTemplate()
                Me.LblCompletedState.Text = Me.DefaultCompletedStateLabelMSG
            Else
                Me.ShowMessage("Please select a Template")
            End If
        Catch ex As Exception
        End Try
    End Sub

#End Region

#End Region

#Region " Copy Current Assignment Team Panel "

    Private Sub LBtnCopyCurrentAssignmentTeam_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LBtnCopyCurrentAssignmentTeam.Click
        If Me.DivCopyTeam.Visible = False Then
            If Me.RadComboBoxAlertTemplate.SelectedIndex = 0 Or Me.RadListBoxStatesInTemplate.SelectedIndex = -1 Then
                Me.ShowMessage("Please select a Template and State")
                Me.DivCopyTeam.Visible = False
                Exit Sub
            Else
                Me.DivCopyTeam.Visible = True
                'bind the new list box
                Me.BindRadLB_StatesInTemplateToCopyTo()
            End If
        ElseIf Me.DivCopyTeam.Visible = True Then
            Me.RadListBoxStatesInTemplateToCopyTo.Items.Clear()
            Me.DivCopyTeam.Visible = False
        End If
    End Sub

    Private Sub BindRadLB_StatesInTemplateToCopyTo()
        Me.RadListBoxStatesInTemplateToCopyTo.Items.Clear()
        If Me.RadComboBoxAlertTemplate.Items.Count > 0 Then
            If Me.RadComboBoxAlertTemplate.SelectedIndex > 0 Then
                Dim a As New cAlerts()
                Dim dt As New DataTable
                dt = a.GetAlertStates(0, 0, Me.RadComboBoxAlertTemplate.SelectedValue)
                If Not dt Is Nothing Then
                    If dt.Rows.Count > 0 Then
                        For i As Integer = 0 To dt.Rows.Count - 1
                            If CType(dt.Rows(i)("ALERT_STATE_ID"), Integer) <> CType(Me.RadListBoxStatesInTemplate.SelectedValue, Integer) Then
                                Dim item As New RadListBoxItem
                                With item
                                    .Text = dt.Rows(i)("ALERT_STATE_NAME")
                                    .Value = dt.Rows(i)("ALERT_STATE_ID")
                                End With
                                Me.RadListBoxStatesInTemplateToCopyTo.Items.Add(item)
                            End If
                        Next
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub BtnCopyCurrentAssignmentTeam_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCopyCurrentAssignmentTeam.Click
        Try
            If Me.RadListBoxStatesInTemplateToCopyTo.SelectedIndex = -1 Then
                Me.ShowMessage("Please select state(s) to copy to")
                Exit Sub
            End If
            If Me.RadComboBoxAlertTemplate.SelectedIndex > 0 And Me.RadListBoxStatesInTemplate.SelectedIndex > -1 Then
                Dim a As New cAlerts()
                For i As Integer = 0 To Me.RadListBoxStatesInTemplateToCopyTo.Items.Count - 1
                    If Me.RadListBoxStatesInTemplateToCopyTo.Items(i).Selected = True Then
                        a.CopyAssignmentTeam(Me.RadComboBoxAlertTemplate.SelectedValue, Me.RadListBoxStatesInTemplate.SelectedValue,
                                             Me.RadComboBoxAlertTemplate.SelectedValue, Me.RadListBoxStatesInTemplateToCopyTo.Items(i).Value)
                    End If
                Next
            End If
            Me.DivCopyTeam.Visible = False
            Me.RadListBoxStatesInTemplateToCopyTo.Items.Clear()
        Catch ex As Exception
            Me.ShowMessage("Error copying Assignment Team")
        End Try
    End Sub

#End Region

#Region " Other Settings Tab "

#Region " General Settings "

    Private Sub GetSettings()
        Dim dt As New DataTable
        dt = SqlHelper.ExecuteDataTable(Session("ConnString"), CommandType.Text, "SELECT * FROM AGY_SETTINGS WHERE AGY_SETTINGS_CODE LIKE 'ALRT_ASSGN_%';", "DtSettings")
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Select Case dt.Rows(i)("AGY_SETTINGS_CODE").ToString()
                    Case "ALRT_ASSGN_TRK_SD"
                        Me.CheckBoxTrackAlertDescriptionChanges.Checked = MiscFN.IntToBool(dt.Rows(i)("AGY_SETTINGS_VALUE"))
                    Case "ALRT_ASSGN_DFLT_SUB"
                        Me.RadComboBoxAlertAssignmentDefaultSubject.FindItemByValue(dt.Rows(i)("AGY_SETTINGS_VALUE")).Selected = True
                    Case "ALRT_ASSGN_CS_RT_DFL"
                        Me.CheckBoxRouteReviewsByDefault.Checked = MiscFN.IntToBool(dt.Rows(i)("AGY_SETTINGS_VALUE"))
                    Case "ALRT_ASSGN_CMTS_FST"
                        Me.CheckBoxCommentsFirstOnEmails.Checked = MiscFN.IntToBool(dt.Rows(i)("AGY_SETTINGS_VALUE"))
                End Select
            Next
        End If
    End Sub
    Private Sub LoadTimeZones()

        Me.RadComboBoxDatabaseServerTimeZone.Items.Clear()
        Me.RadComboBoxAgencyTimeZone.Items.Clear()

        Dim TimeZones As System.Collections.Generic.List(Of TimeZoneInfo)

        TimeZones = AdvantageFramework.Database.Procedures.TimeZone.LoadSystemTimeZones

        If TimeZones IsNot Nothing Then

            Me.RadComboBoxDatabaseServerTimeZone.DataSource = TimeZones
            Me.RadComboBoxDatabaseServerTimeZone.DataTextField = "StandardName"
            Me.RadComboBoxDatabaseServerTimeZone.DataValueField = "Id"
            Me.RadComboBoxDatabaseServerTimeZone.DataBind()
            Me.RadComboBoxDatabaseServerTimeZone.Items.Insert(0, New RadComboBoxItem("[Don't Change]", ""))

            Me.RadComboBoxAgencyTimeZone.DataSource = TimeZones
            Me.RadComboBoxAgencyTimeZone.DataTextField = "StandardName"
            Me.RadComboBoxAgencyTimeZone.DataValueField = "Id"
            Me.RadComboBoxAgencyTimeZone.DataBind()
            Me.RadComboBoxAgencyTimeZone.Items.Insert(0, New RadComboBoxItem("[Don't Change]", ""))

            Using DbContext = New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

                Dim agy As New AdvantageFramework.Database.Entities.Agency
                agy = Nothing

                agy = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                If Not agy Is Nothing Then

                    If Not agy.DatabaseServerTimeZoneID Is Nothing AndAlso String.IsNullOrWhiteSpace(agy.DatabaseServerTimeZoneID) = False Then MiscFN.RadComboBoxSetIndex(Me.RadComboBoxDatabaseServerTimeZone, agy.DatabaseServerTimeZoneID, False)
                    If Not agy.TimeZoneID Is Nothing AndAlso String.IsNullOrWhiteSpace(agy.TimeZoneID) = False Then MiscFN.RadComboBoxSetIndex(Me.RadComboBoxAgencyTimeZone, agy.TimeZoneID, False)

                End If

            End Using

        End If

    End Sub
    Private Sub SaveTimeZones()

        Using DbContext = New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

            Dim Agency As New AdvantageFramework.Database.Entities.Agency
            Agency = Nothing

            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

            If Not Agency Is Nothing Then

                If Me.RadComboBoxAgencyTimeZone.SelectedIndex > 0 Then

                    Agency.TimeZoneID = Me.RadComboBoxAgencyTimeZone.SelectedItem.Value

                Else

                    Agency.TimeZoneID = Nothing

                End If
                If Me.RadComboBoxDatabaseServerTimeZone.SelectedIndex > 0 Then

                    Agency.DatabaseServerTimeZoneID = Me.RadComboBoxDatabaseServerTimeZone.SelectedItem.Value

                Else

                    Agency.DatabaseServerTimeZoneID = Nothing

                End If
                If AdvantageFramework.Database.Procedures.Agency.Update(DbContext, Agency) = True Then

                    cEmployee.ResetTimeZoneOffsetSession()

                End If

            End If

        End Using

    End Sub

    Private Sub CheckBoxRouteReviewsByDefault_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxRouteReviewsByDefault.CheckedChanged
        Dim m As New cMaintenanceApps()
        m.AgencySettingSet("ALRT_ASSGN_CS_RT_DFL", "Use auto-routed template by default when creating reviews",
                           MiscFN.BoolToInt(Me.CheckBoxRouteReviewsByDefault.Checked), "0")
    End Sub
    Private Sub CheckBoxCommentsFirstOnEmails_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxCommentsFirstOnEmails.CheckedChanged
        Dim m As New cMaintenanceApps()
        m.AgencySettingSet("ALRT_ASSGN_CMTS_FST", "Use auto-routed template by default when creating reviews",
                           MiscFN.BoolToInt(Me.CheckBoxCommentsFirstOnEmails.Checked), "0")
    End Sub

    Private Sub CheckBoxTrackAlertDescriptionChanges_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxTrackAlertDescriptionChanges.CheckedChanged
        Dim m As New cMaintenanceApps()
        m.AgencySettingSet("ALRT_ASSGN_TRK_SD", "Track changes to subject/description when creating assignment.",
                           MiscFN.BoolToInt(Me.CheckBoxTrackAlertDescriptionChanges.Checked), "0")
    End Sub
    Private Sub RadComboBoxAlertAssignmentDefaultSubject_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxAlertAssignmentDefaultSubject.SelectedIndexChanged
        Dim m As New cMaintenanceApps()
        m.AgencySettingSet("ALRT_ASSGN_DFLT_SUB", "Set a default subject for assignment emails/alerts.",
                           Me.RadComboBoxAlertAssignmentDefaultSubject.SelectedValue, "")
    End Sub
    Private Sub RadComboBoxAgencyTimeZone_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxAgencyTimeZone.SelectedIndexChanged

        If Me.RadComboBoxAgencyTimeZone.SelectedIndex = 0 Then Me.RadComboBoxDatabaseServerTimeZone.SelectedIndex = 0
        Me.SaveTimeZones()

    End Sub
    Private Sub RadComboBoxDatabaseServerTimeZone_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxDatabaseServerTimeZone.SelectedIndexChanged

        If Me.RadComboBoxDatabaseServerTimeZone.SelectedIndex = 0 Then Me.RadComboBoxAgencyTimeZone.SelectedIndex = 0
        Me.SaveTimeZones()

    End Sub

#End Region

#End Region

    Private Sub RadGridAlertStates_PageSizeChanged(sender As Object, e As GridPageSizeChangedEventArgs) Handles RadGridAlertStates.PageSizeChanged
        MiscFN.SavePageSize(Me.RadGridAlertStates.ID, e.NewPageSize)
    End Sub

    Private Sub RadGridTemplates_PageSizeChanged(sender As Object, e As GridPageSizeChangedEventArgs) Handles RadGridTemplates.PageSizeChanged
        MiscFN.SavePageSize(Me.RadGridTemplates.ID, e.NewPageSize)
    End Sub

    Private Sub ImageButtonCopyTemplate_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonCopyTemplate.Click
        If Me.RadComboBoxAlertTemplate.SelectedIndex > 0 Then
            Dim q As New AdvantageFramework.Web.QueryString()
            q = q.FromCurrent()
            q.AlertTemplateID = Me.RadComboBoxAlertTemplate.SelectedValue
            q.Page = "Maintenance_AlertAssignments_TemplateCopy.aspx"

            Me.OpenWindow("Copy Assignment Template", q.ToString(True), 175, 675, , True)

        Else
            Me.ShowMessage("Please select a Template")
        End If

    End Sub

End Class
