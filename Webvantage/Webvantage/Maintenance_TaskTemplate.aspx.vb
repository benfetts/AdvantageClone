Imports Telerik.Web.UI

Public Class Maintenance_TaskTemplate
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _FunctionsList As Generic.List(Of AdvantageFramework.Database.Entities.Function) = Nothing
    Private _StatusesList As Generic.List(Of AdvantageFramework.Database.Entities.Status) = Nothing
    Private _EmployeesList As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
    Private _PhasesList As Generic.List(Of AdvantageFramework.Database.Entities.Phase) = Nothing
    Private _TasksList As Generic.List(Of AdvantageFramework.Database.Entities.Task) = Nothing

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
    Private Property CurrentGridPageIndex As Integer = 0
    Private Property CurrentPageNumber As Integer = 0

#End Region

#Region " Methods "

    Private Sub ChangeTabs(ByVal TaskTemplateCode As String)

        Select Case RadTabStripTaskMaintenance.SelectedIndex

            Case 0

                LoadTaskTemplatesTab()

            Case 1

                LoadTaskTemplatesDetailTab(TaskTemplateCode)
                RadGridTaskTemplateDetails.Rebind()

        End Select

    End Sub
    Private Sub LoadTaskTemplatesTab()

        RadGridTaskTemplates.Rebind()

    End Sub
    Private Sub LoadTaskTemplatesDetail()

        'objects
        Dim TaskTemplate As AdvantageFramework.Database.Entities.TaskTemplate = Nothing

        If DropDownListTaskTemplate.SelectedValue IsNot Nothing AndAlso DropDownListTaskTemplate.SelectedValue.ToString() <> "" Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(Session("ConnString").ToString(), Session("UserCode").ToString())

                    TaskTemplate = AdvantageFramework.Database.Procedures.TaskTemplate.LoadByTaskTemplateCode(DbContext, DropDownListTaskTemplate.SelectedValue)

                    If TaskTemplate IsNot Nothing Then

                        TextBoxTaskTemplateDescription.Text = TaskTemplate.Description

                        TextBoxRushScheduleCompletionDays.Text = Format(AdvantageFramework.Database.Procedures.TaskTemplate.LoadTotalRushDaysByTaskTemplateCode(DbContext, DataContext, TaskTemplate.Code), "d")
                        TextBoxStandardScheduleCompletionDays.Text = Format(AdvantageFramework.Database.Procedures.TaskTemplate.LoadTotalStandardDaysByTaskTemplateCode(DbContext, DataContext, TaskTemplate.Code), "d")

                    End If

                End Using

            End Using

        End If

        RadGridTaskTemplateDetails.Rebind()

    End Sub
    Private Sub LoadTaskTemplatesDetailTab(ByVal TaskTemplateCode As String)

        'objects
        Dim TaskTemplates As Generic.IEnumerable(Of Object) = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            TaskTemplates = (From TaskTemplate In AdvantageFramework.Database.Procedures.TaskTemplate.Load(DbContext)
                             Select TaskTemplate.Code,
                                    TaskTemplate.Description).ToList

            DropDownListTaskTemplate.DataSource = TaskTemplates

            DropDownListTaskTemplate.DataBind()

            DropDownListTaskTemplate.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

            DropDownListCopyTaskTemplateDetails.DataSource = TaskTemplates

            DropDownListCopyTaskTemplateDetails.DataBind()

            DropDownListCopyTaskTemplateDetails.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

        End Using

        Try

            If TaskTemplateCode <> "" Then

                DropDownListTaskTemplate.SelectedValue = TaskTemplateCode

            End If

        Catch ex As Exception

            If DropDownListTaskTemplate.Items.Count > 0 Then

                DropDownListTaskTemplate.SelectedIndex = 0

            End If

        End Try

        If DropDownListTaskTemplate.SelectedValue IsNot Nothing AndAlso DropDownListTaskTemplate.SelectedValue.ToString() <> "" Then

            LoadTaskTemplatesDetail()

        Else

            TextBoxTaskTemplateDescription.Text = ""

            TextBoxStandardScheduleCompletionDays.Text = ""
            TextBoxRushScheduleCompletionDays.Text = ""

            'Using DataContext = New AdvantageFramework.Database.DataContext(Session("ConnString").ToString(), Session("UserCode").ToString())

            '    RadGridTaskTemplateDetails.DataSource = (From TaskTemplateDetail In AdvantageFramework.Database.Procedures.TaskTemplateDetailView.LoadByTaskTemplateCode(DataContext, "")
            '                                             Select TaskTemplateDetail.TaskTemplateDetailID,
            '                                                    TaskTemplateDetail.PhaseID,
            '                                                    TaskTemplateDetail.PhaseDescription,
            '                                                    TaskTemplateDetail.TaskCode,
            '                                                    TaskTemplateDetail.TaskDescription,
            '                                                    TaskTemplateDetail.ProcessOrderNumber,
            '                                                    TaskTemplateDetail.DaysToComplete,
            '                                                    TaskTemplateDetail.HoursAllowed,
            '                                                    TaskTemplateDetail.RushDaysToComplete,
            '                                                    TaskTemplateDetail.RushHoursToComplete,
            '                                                    TaskTemplateDetail.IsMilestone,
            '                                                    TaskTemplateDetail.DefaultEmployeeCode,
            '                                                    TaskTemplateDetail.DefaultEmployeeName,
            '                                                    TaskTemplateDetail.DefaultFunctionCode,
            '                                                    TaskTemplateDetail.DefaultFunctionDescription
            '                                             Order By ProcessOrderNumber).ToList

            'End Using

            'RadGridTaskTemplateDetails.DataBind()

        End If

    End Sub
    Private Sub UpdateTaskTemplate(ByRef GridDataItem As Telerik.Web.UI.GridDataItem)

        'objects
        Dim TaskTemplate As AdvantageFramework.Database.Entities.TaskTemplate = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Using DataContext = New AdvantageFramework.Database.DataContext(Session("ConnString").ToString(), Session("UserCode").ToString())

                TaskTemplate = AdvantageFramework.Database.Procedures.TaskTemplate.LoadByTaskTemplateCode(DbContext, GridDataItem.GetDataKeyValue("Code"))

                If TaskTemplate IsNot Nothing Then

                    TaskTemplate.Description = CType(GridDataItem.FindControl("TextBoxTaskTemplateDescription"), TextBox).Text.Trim

                    TaskTemplate.TotalRushDays = AdvantageFramework.Database.Procedures.TaskTemplate.LoadTotalRushDaysByTaskTemplateCode(DbContext, DataContext, TaskTemplate.Code)
                    TaskTemplate.TotalStandardDays = AdvantageFramework.Database.Procedures.TaskTemplate.LoadTotalStandardDaysByTaskTemplateCode(DbContext, DataContext, TaskTemplate.Code)

                    AdvantageFramework.Database.Procedures.TaskTemplate.Update(DbContext, TaskTemplate)

                End If

            End Using

        End Using

    End Sub
    Private Sub UpdateTaskTemplateDetail(ByRef GridDataItem As Telerik.Web.UI.GridDataItem)

        'objects
        Dim TaskTemplateDetail As AdvantageFramework.Database.Entities.TaskTemplateDetail = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Using DataContext = New AdvantageFramework.Database.DataContext(Session("ConnString").ToString(), Session("UserCode").ToString())

                TaskTemplateDetail = AdvantageFramework.Database.Procedures.TaskTemplateDetail.LoadByTaskTemplateDetailID(DataContext, GridDataItem.GetDataKeyValue("TaskTemplateDetailID"))

                If TaskTemplateDetail IsNot Nothing Then

                    If CType(GridDataItem.FindControl("DropDownListTemplateDetailPhase"), Telerik.Web.UI.RadComboBox).SelectedValue <> "" Then

                        TaskTemplateDetail.PhaseID = CType(GridDataItem.FindControl("DropDownListTemplateDetailPhase"), Telerik.Web.UI.RadComboBox).SelectedValue

                    Else

                        TaskTemplateDetail.PhaseID = Nothing

                    End If

                    TaskTemplateDetail.TaskCode = CType(GridDataItem.FindControl("DropDownListTemplateDetailTaskCode"), Telerik.Web.UI.RadComboBox).SelectedValue

                    TaskTemplateDetail.ProcessOrderNumber = CType(GridDataItem.FindControl("TextBoxTemplateDetailProcessOrderNumber"), Telerik.Web.UI.RadNumericTextBox).Value
                    TaskTemplateDetail.DaysToComplete = CType(GridDataItem.FindControl("TextBoxTemplateDetailDaysToComplete"), Telerik.Web.UI.RadNumericTextBox).Value
                    TaskTemplateDetail.HoursAllowed = CType(GridDataItem.FindControl("TextBoxTemplateDetailHoursAllowed"), Telerik.Web.UI.RadNumericTextBox).Value
                    TaskTemplateDetail.RushDaysToComplete = CType(GridDataItem.FindControl("TextBoxTemplateDetailRushDaysToComplete"), Telerik.Web.UI.RadNumericTextBox).Value
                    TaskTemplateDetail.RushHoursToComplete = CType(GridDataItem.FindControl("TextBoxTemplateDetailRushHoursToComplete"), Telerik.Web.UI.RadNumericTextBox).Value

                    If CType(GridDataItem.FindControl("CheckBoxTemplateDetailIsMilestone"), CheckBox).Checked Then

                        TaskTemplateDetail.IsMilestone = 1

                    Else

                        TaskTemplateDetail.IsMilestone = 0

                    End If

                    If CType(GridDataItem.FindControl("DropDownListTemplateDetailDefaultEmployee"), Telerik.Web.UI.RadComboBox).SelectedValue <> "" Then

                        TaskTemplateDetail.EmployeeCode = CType(GridDataItem.FindControl("DropDownListTemplateDetailDefaultEmployee"), Telerik.Web.UI.RadComboBox).SelectedValue

                    Else

                        TaskTemplateDetail.EmployeeCode = Nothing

                    End If

                    If CType(GridDataItem.FindControl("DropDownListTemplateDetailDefaultFunction"), Telerik.Web.UI.RadComboBox).SelectedValue <> "" Then

                        TaskTemplateDetail.FunctionCode = CType(GridDataItem.FindControl("DropDownListTemplateDetailDefaultFunction"), Telerik.Web.UI.RadComboBox).SelectedValue

                    Else

                        TaskTemplateDetail.FunctionCode = Nothing

                    End If

                    AdvantageFramework.Database.Procedures.TaskTemplateDetail.Update(DbContext, DataContext, TaskTemplateDetail)

                End If

            End Using

        End Using

    End Sub

#Region "  Form Event Handlers "

    Private Sub Maintenance_TaskTemplate_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim TabIndex As Integer = 0
        Dim TaskTemplateCode As String = ""

        Me.PageTitle = "Task Template Maintenance"

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            If Request.Cookies("RadGridTaskTemplateDetails_PageSize") IsNot Nothing AndAlso
                    Request.Cookies("RadGridTaskTemplateDetails_PageSize").Value IsNot Nothing Then

                RadGridTaskTemplateDetails.PageSize = Request.Cookies("RadGridTaskTemplateDetails_PageSize").Value

            End If

            Try

                If Not Request.QueryString("TabIndex") Is Nothing Then

                    TabIndex = CType(Request.QueryString("TabIndex"), Integer)

                End If

                If Not Request.QueryString("TaskTemplateCode") Is Nothing Then

                    TaskTemplateCode = CType(Request.QueryString("TaskTemplateCode"), String)

                End If

            Catch ex As Exception
                TabIndex = 0
                TaskTemplateCode = ""
            End Try

            Try

                RadTabStripTaskMaintenance.SelectedIndex = TabIndex
                RadMultiPageTaskMaintenance.SelectedIndex = TabIndex

                ChangeTabs(TaskTemplateCode)

            Catch ex As Exception

            End Try

        End If

    End Sub
    Protected Overrides Sub RaisePostBackEvent(ByVal sourceControl As System.Web.UI.IPostBackEventHandler, ByVal eventArgument As String)

        'objects
        Dim GridDataItem As Telerik.Web.UI.GridDataItem = Nothing

        MyBase.RaisePostBackEvent(sourceControl, eventArgument)

        If sourceControl Is RadGridTaskTemplates AndAlso (eventArgument.IndexOf("IndexOfRowDoubleClicked") <> -1) Then

            GridDataItem = RadGridTaskTemplates.Items(Integer.Parse(eventArgument.Split(":"c)(1)))

            If GridDataItem IsNot Nothing Then

                Response.Redirect([String].Format("Maintenance_TaskTemplate.aspx?TabIndex={0}&TaskTemplateCode={1}", 1, GridDataItem.GetDataKeyValue("Code")))

            End If

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Protected Sub TaskTemplateDetailTaskSelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        'objects
        Dim GridItem As Telerik.Web.UI.GridItem = Nothing
        Dim TaskCode As String = ""
        Dim Task As AdvantageFramework.Database.Entities.Task = Nothing

        Try

            GridItem = CType(CType(sender, Telerik.Web.UI.RadComboBox).Parent.Parent, Telerik.Web.UI.GridItem)

            TaskCode = CType(GridItem.FindControl("DropDownListTemplateDetailTaskCodeEditDropDownList"), Telerik.Web.UI.RadComboBox).SelectedValue

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Task = AdvantageFramework.Database.Procedures.Task.LoadByTaskCode(DbContext, TaskCode)

                If Task IsNot Nothing Then

                    CType(GridItem.FindControl("TextBoxTemplateDetailProcessOrderNumberEditTextBox"), Telerik.Web.UI.RadNumericTextBox).Value = Task.ProcessOrderNumber
                    CType(GridItem.FindControl("TextBoxTemplateDetailDaysToCompleteEditTextBox"), Telerik.Web.UI.RadNumericTextBox).Value = Task.DaysToComplete
                    CType(GridItem.FindControl("TextBoxTemplateDetailHoursAllowedEditTextBox"), Telerik.Web.UI.RadNumericTextBox).Value = Task.HoursAllowed

                    If Task.IsMilestone = 1 Then

                        CType(GridItem.FindControl("CheckBoxTemplateDetailIsMilestoneEditCheckBox"), CheckBox).Checked = True

                    Else

                        CType(GridItem.FindControl("CheckBoxTemplateDetailIsMilestoneEditCheckBox"), CheckBox).Checked = False

                    End If

                    CType(GridItem.FindControl("DropDownListTemplateDetailDefaultFunctionEditDropDownList"), Telerik.Web.UI.RadComboBox).SelectedValue = Task.FunctionCode

                End If

            End Using

        Catch ex As Exception

        End Try

    End Sub
    Private Sub ImageButtonExport_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonExport.Click

        'objects
        Dim GridView As GridView = Nothing
        Dim DataView As DataView = Nothing
        Dim DataTable As DataTable = Nothing
        Dim NewDataRow As DataRow = Nothing
        Dim Tasks As IQueryable(Of AdvantageFramework.Database.Entities.Task) = Nothing
        Dim [Function] As AdvantageFramework.Database.Entities.Function = Nothing
        Dim Status As AdvantageFramework.Database.Entities.Status = Nothing

        Select Case RadTabStripTaskMaintenance.SelectedIndex

            Case 0

                DataTable = New DataTable

                DataTable.Columns.Add("Code")
                DataTable.Columns.Add("Description")
                DataTable.Columns.Add("Total Standard Days To Completion")
                DataTable.Columns.Add("Total Rush Days To Completion")

                RadGridTaskTemplates.AllowPaging = False

                LoadTaskTemplatesTab()

                For Each GridDataItem In RadGridTaskTemplates.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

                    NewDataRow = DataTable.Rows.Add()

                    NewDataRow(0) = GridDataItem.GetDataKeyValue("Code")
                    NewDataRow(1) = GridDataItem.GetDataKeyValue("Description")
                    NewDataRow(2) = Format(GridDataItem.GetDataKeyValue("TotalStandardDays"), "d")
                    NewDataRow(3) = Format(GridDataItem.GetDataKeyValue("TotalRushDays"), "d")

                Next

                'DataView = New DataView(DataTable)

                'GridView = New GridView

                'GridView.DataSource = DataView
                'GridView.DataBind()

                'AdvantageFramework.Web.Exporting.ToExcel("Task Templates.xls", GridView)  <--- This doesn' work
                Me.DeliverGrid(DataTable, "Task Templates") '<--- This does, please don't change unless you test!!!!

                RadGridTaskTemplates.AllowPaging = True

                LoadTaskTemplatesTab()

            Case 1

                If DropDownListTaskTemplate.SelectedValue IsNot Nothing AndAlso DropDownListTaskTemplate.SelectedValue.ToString() <> "" Then

                    DataTable = New DataTable

                    DataTable.Columns.Add("Phase")
                    DataTable.Columns.Add("Task")
                    DataTable.Columns.Add("Process Order Number")
                    DataTable.Columns.Add("Days To Complete")
                    DataTable.Columns.Add("Hours Allowed")
                    DataTable.Columns.Add("Rush Days To Complete")
                    DataTable.Columns.Add("Rush Hours To Complete")
                    DataTable.Columns.Add("Milestone")
                    DataTable.Columns.Add("Default Employee")
                    DataTable.Columns.Add("Default Function")

                    RadGridTaskTemplateDetails.AllowPaging = False

                    LoadTaskTemplatesDetail()

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        For Each GridDataItem In RadGridTaskTemplateDetails.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

                            NewDataRow = DataTable.Rows.Add()

                            NewDataRow(0) = GridDataItem.DataItem.PhaseDescription
                            NewDataRow(1) = GridDataItem.DataItem.TaskDescription

                            NewDataRow(2) = Format(GridDataItem.DataItem.ProcessOrderNumber, "d")
                            NewDataRow(3) = Format(GridDataItem.DataItem.DaysToComplete, "d")
                            NewDataRow(4) = Format(GridDataItem.DataItem.HoursAllowed, "f")
                            NewDataRow(5) = Format(GridDataItem.DataItem.RushDaysToComplete, "d")
                            NewDataRow(6) = Format(GridDataItem.DataItem.RushHoursToComplete, "f")

                            If GridDataItem.DataItem.IsMilestone Then

                                NewDataRow(7) = "YES"

                            Else

                                NewDataRow(7) = "NO"

                            End If

                            NewDataRow(8) = GridDataItem.DataItem.DefaultEmployeeName
                            NewDataRow(9) = GridDataItem.DataItem.DefaultFunctionDescription

                        Next

                    End Using

                    'DataView = New DataView(DataTable)

                    'GridView = New GridView

                    'GridView.DataSource = DataView
                    'GridView.DataBind()

                    'AdvantageFramework.Web.Exporting.ToExcel("Task Template Details.xls", GridView) <--- This doesn' work
                    Me.DeliverGrid(DataTable, "Task Template Details") '<--- This does, please don't change unless you test!!!!

                    RadGridTaskTemplateDetails.AllowPaging = True

                    LoadTaskTemplatesDetail()

                End If

        End Select

    End Sub
    Private Sub RadTabStripTaskMaintenance_TabClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadTabStripEventArgs) Handles RadTabStripTaskMaintenance.TabClick

        ChangeTabs("")

    End Sub
    Private Sub RadGridTaskTemplates_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridTaskTemplates.ItemCommand

        'objects
        Dim GridEditableItem As Telerik.Web.UI.GridEditableItem = Nothing
        Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim TaskTemplate As AdvantageFramework.Database.Entities.TaskTemplate = Nothing
        Dim Reload As Boolean = True

        If e.Item IsNot Nothing Then

            If e.Item IsNot Nothing AndAlso e.Item.ItemIndex > -1 Then

                CurrentGridDataItem = RadGridTaskTemplates.Items(e.Item.ItemIndex)

            End If

        End If

        Select Case e.CommandName

            Case "SaveAll"

                For Each GridDataItem In RadGridTaskTemplates.MasterTableView.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

                    UpdateTaskTemplate(GridDataItem)

                Next

            Case "SaveNewRow"

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    TaskTemplate = New AdvantageFramework.Database.Entities.TaskTemplate

                    TaskTemplate.DbContext = DbContext

                    TaskTemplate.Code = CType(e.Item.FindControl("TextBoxTaskTemplateCodeEditTextBox"), TextBox).Text.Trim
                    TaskTemplate.Description = CType(e.Item.FindControl("TextBoxTaskTemplateDescriptionEditTextBox"), TextBox).Text.Trim

                    Reload = AdvantageFramework.Database.Procedures.TaskTemplate.Insert(DbContext, TaskTemplate)

                End Using

            Case "SaveRow"

                If CurrentGridDataItem IsNot Nothing Then

                    UpdateTaskTemplate(CurrentGridDataItem)

                End If

            Case "CancelNewRow"

                If e.Item IsNot Nothing Then

                    CType(e.Item.FindControl("TextBoxTaskTemplateCodeEditTextBox"), TextBox).Text = ""
                    CType(e.Item.FindControl("TextBoxTaskTemplateDescriptionEditTextBox"), TextBox).Text = ""

                End If

            Case "DeleteRow"

                If CurrentGridDataItem IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Using DataContext = New AdvantageFramework.Database.DataContext(Session("ConnString").ToString(), Session("UserCode").ToString())

                            TaskTemplate = AdvantageFramework.Database.Procedures.TaskTemplate.LoadByTaskTemplateCode(DbContext, CurrentGridDataItem.GetDataKeyValue("Code"))

                            If TaskTemplate IsNot Nothing Then

                                AdvantageFramework.Database.Procedures.TaskTemplate.Delete(DbContext, DataContext, TaskTemplate)

                            End If

                        End Using

                    End Using

                End If

        End Select

        If Reload Then

            If e.CommandName = "SaveNewRow" Then

                MiscFN.ResponseRedirect(String.Format("Maintenance_TaskTemplate.aspx?TabIndex={0}", RadTabStripTaskMaintenance.SelectedIndex))

            Else

                LoadTaskTemplatesTab()

            End If

        Else

            If e.Item IsNot Nothing Then

                If e.Item.IsInEditMode Then

                    CType(e.Item.FindControl("TextBoxTaskTemplateCodeEditTextBox"), TextBox).Focus()

                End If

            End If

        End If

    End Sub
    Private Sub RadGridTaskTemplates_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridTaskTemplates.ItemDataBound

        'objects
        Dim ImageButtonDelete As System.Web.UI.WebControls.ImageButton = Nothing

        Try

            ImageButtonDelete = DirectCast(e.Item.FindControl("ImageButtonDelete"), ImageButton)

            If ImageButtonDelete IsNot Nothing Then

                ImageButtonDelete.Attributes.Add("onclick", "return confirm('Are you sure you want to delete?');")

            End If

        Catch ex As Exception
            ImageButtonDelete = Nothing
        End Try

    End Sub
    Private Sub RadGridTaskTemplates_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridTaskTemplates.NeedDataSource

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Using DataContext = New AdvantageFramework.Database.DataContext(Session("ConnString").ToString(), Session("UserCode").ToString())

                RadGridTaskTemplates.DataSource = (From TaskTemplate In AdvantageFramework.Database.Procedures.TaskTemplate.Load(DbContext).ToList
                                                   Select TaskTemplate.Code,
                                                          TaskTemplate.Description,
                                                          [TotalStandardDays] = AdvantageFramework.Database.Procedures.TaskTemplate.LoadTotalStandardDaysByTaskTemplateCode(DbContext, DataContext, TaskTemplate.Code),
                                                          [TotalRushDays] = AdvantageFramework.Database.Procedures.TaskTemplate.LoadTotalRushDaysByTaskTemplateCode(DbContext, DataContext, TaskTemplate.Code)).ToList

                RadGridTaskTemplates.MasterTableView.IsItemInserted = True

            End Using

        End Using

        Me.RadGridTaskTemplates.PageSize = MiscFN.LoadPageSize(Me.RadGridTaskTemplates.ID)

    End Sub
    Private Sub RadGridTaskTemplateDetails_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridTaskTemplateDetails.ItemCommand

        'objects
        Dim GridEditableItem As Telerik.Web.UI.GridEditableItem = Nothing
        Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim TaskTemplateDetail As AdvantageFramework.Database.Entities.TaskTemplateDetail = Nothing
        Dim Reload As Boolean = True

        If e.Item IsNot Nothing AndAlso e.Item.ItemIndex > -1 Then

            CurrentGridDataItem = RadGridTaskTemplateDetails.Items(e.Item.ItemIndex)

        End If

        Select Case e.CommandName

            Case "SaveAll"

                For Each GridDataItem In RadGridTaskTemplateDetails.MasterTableView.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

                    UpdateTaskTemplateDetail(GridDataItem)

                Next

            Case "SaveNewRow"

                If DropDownListTaskTemplate.SelectedValue IsNot Nothing AndAlso DropDownListTaskTemplate.SelectedValue.ToString() <> "" Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Using DataContext = New AdvantageFramework.Database.DataContext(Session("ConnString").ToString(), Session("UserCode").ToString())

                            TaskTemplateDetail = New AdvantageFramework.Database.Entities.TaskTemplateDetail

                            TaskTemplateDetail.TaskTemplateCode = DropDownListTaskTemplate.SelectedValue

                            If IsNumeric(CType(e.Item.FindControl("DropDownListTemplateDetailPhaseEditDropDownList"), Telerik.Web.UI.RadComboBox).SelectedValue) Then

                                TaskTemplateDetail.PhaseID = CType(e.Item.FindControl("DropDownListTemplateDetailPhaseEditDropDownList"), Telerik.Web.UI.RadComboBox).SelectedValue

                            Else

                                TaskTemplateDetail.PhaseID = Nothing

                            End If

                            TaskTemplateDetail.TaskCode = CType(e.Item.FindControl("DropDownListTemplateDetailTaskCodeEditDropDownList"), Telerik.Web.UI.RadComboBox).SelectedValue

                            TaskTemplateDetail.ProcessOrderNumber = CType(e.Item.FindControl("TextBoxTemplateDetailProcessOrderNumberEditTextBox"), Telerik.Web.UI.RadNumericTextBox).Value
                            TaskTemplateDetail.DaysToComplete = CType(e.Item.FindControl("TextBoxTemplateDetailDaysToCompleteEditTextBox"), Telerik.Web.UI.RadNumericTextBox).Value
                            TaskTemplateDetail.HoursAllowed = CType(e.Item.FindControl("TextBoxTemplateDetailHoursAllowedEditTextBox"), Telerik.Web.UI.RadNumericTextBox).Value
                            TaskTemplateDetail.RushDaysToComplete = CType(e.Item.FindControl("TextBoxTemplateDetailRushDaysToCompleteEditTextBox"), Telerik.Web.UI.RadNumericTextBox).Value
                            TaskTemplateDetail.RushHoursToComplete = CType(e.Item.FindControl("TextBoxTemplateDetailRushHoursToCompleteEditTextBox"), Telerik.Web.UI.RadNumericTextBox).Value

                            If CType(e.Item.FindControl("CheckBoxTemplateDetailIsMilestoneEditCheckBox"), CheckBox).Checked Then

                                TaskTemplateDetail.IsMilestone = 1

                            Else

                                TaskTemplateDetail.IsMilestone = 0

                            End If

                            TaskTemplateDetail.EmployeeCode = CType(e.Item.FindControl("DropDownListTemplateDetailDefaultEmployeeEditDropDownList"), Telerik.Web.UI.RadComboBox).SelectedValue
                            TaskTemplateDetail.FunctionCode = CType(e.Item.FindControl("DropDownListTemplateDetailDefaultFunctionEditDropDownList"), Telerik.Web.UI.RadComboBox).SelectedValue

                            Reload = AdvantageFramework.Database.Procedures.TaskTemplateDetail.Insert(DbContext, DataContext, TaskTemplateDetail)

                        End Using

                    End Using

                End If

            Case "SaveRow"

                If CurrentGridDataItem IsNot Nothing Then

                    UpdateTaskTemplateDetail(CurrentGridDataItem)

                End If

            Case "CancelNewRow"

                If e.Item IsNot Nothing Then

                    CType(e.Item.FindControl("DropDownListTemplateDetailPhaseEditDropDownList"), Telerik.Web.UI.RadComboBox).SelectedValue = Nothing
                    CType(e.Item.FindControl("DropDownListTemplateDetailTaskCodeEditDropDownList"), Telerik.Web.UI.RadComboBox).SelectedValue = Nothing

                    CType(e.Item.FindControl("TextBoxTemplateDetailProcessOrderNumberEditTextBox"), Telerik.Web.UI.RadNumericTextBox).Value = 0
                    CType(e.Item.FindControl("TextBoxTemplateDetailDaysToCompleteEditTextBox"), Telerik.Web.UI.RadNumericTextBox).Value = 0
                    CType(e.Item.FindControl("TextBoxTemplateDetailHoursAllowedEditTextBox"), Telerik.Web.UI.RadNumericTextBox).Value = 0
                    CType(e.Item.FindControl("TextBoxTemplateDetailRushDaysToCompleteEditTextBox"), Telerik.Web.UI.RadNumericTextBox).Value = 0
                    CType(e.Item.FindControl("TextBoxTemplateDetailRushHoursToCompleteEditTextBox"), Telerik.Web.UI.RadNumericTextBox).Value = 0

                    CType(e.Item.FindControl("CheckBoxTemplateDetailIsMilestoneEditCheckBox"), CheckBox).Checked = False

                    CType(e.Item.FindControl("DropDownListTemplateDetailDefaultEmployeeEditDropDownList"), Telerik.Web.UI.RadComboBox).SelectedValue = Nothing
                    CType(e.Item.FindControl("DropDownListTemplateDetailDefaultFunctionEditDropDownList"), Telerik.Web.UI.RadComboBox).SelectedValue = Nothing

                End If

            Case "DeleteRow"

                If CurrentGridDataItem IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Using DataContext = New AdvantageFramework.Database.DataContext(Session("ConnString").ToString(), Session("UserCode").ToString())

                            TaskTemplateDetail = AdvantageFramework.Database.Procedures.TaskTemplateDetail.LoadByTaskTemplateDetailID(DataContext, CurrentGridDataItem.GetDataKeyValue("TaskTemplateDetailID"))

                            If TaskTemplateDetail IsNot Nothing Then

                                AdvantageFramework.Database.Procedures.TaskTemplateDetail.Delete(DbContext, DataContext, TaskTemplateDetail)

                            End If

                        End Using

                    End Using

                End If

        End Select

        If Reload Then

            LoadTaskTemplatesDetailTab(DropDownListTaskTemplate.SelectedValue)

        Else

            CType(e.Item.FindControl("DropDownListTemplateDetailPhaseEditDropDownList"), Telerik.Web.UI.RadComboBox).Focus()

        End If

    End Sub
    Private Sub RadGridTaskTemplateDetails_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridTaskTemplateDetails.ItemDataBound

        'objects
        Dim DropDownListPhases As Telerik.Web.UI.RadComboBox = Nothing
        Dim DropDownListTasks As Telerik.Web.UI.RadComboBox = Nothing
        Dim DropDownListEmployees As Telerik.Web.UI.RadComboBox = Nothing
        Dim DropDownListFunctions As Telerik.Web.UI.RadComboBox = Nothing
        Dim ImageButtonDelete As System.Web.UI.WebControls.ImageButton = Nothing
        Dim InactiveFunction As AdvantageFramework.Database.Entities.Function = Nothing
        Dim InactivePhase As AdvantageFramework.Database.Entities.Phase = Nothing
        Dim InactiveTask As AdvantageFramework.Database.Entities.Task = Nothing
        Dim InactiveEmployee As AdvantageFramework.Database.Views.Employee = Nothing
        Dim UserEmployeeOfficeList As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeOffice) = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            UserEmployeeOfficeList = AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode).ToList

        End Using

        If _PhasesList Is Nothing Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                _PhasesList = AdvantageFramework.Database.Procedures.Phase.Load(DbContext).ToList

            End Using

        End If

        If _TasksList Is Nothing Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                _TasksList = AdvantageFramework.Database.Procedures.Task.Load(DbContext).ToList

            End Using

        End If

        If _EmployeesList Is Nothing Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                _EmployeesList = AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(DbContext).ToList

            End Using

        End If

        If _FunctionsList Is Nothing Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                _FunctionsList = AdvantageFramework.Database.Procedures.Function.LoadAllEmployeeFunctions(DbContext).ToList

            End Using

        End If

        Try

            DropDownListPhases = DirectCast(e.Item.FindControl("DropDownListTemplateDetailPhase"), Telerik.Web.UI.RadComboBox)

            If DropDownListPhases Is Nothing Then

                DropDownListPhases = DirectCast(e.Item.FindControl("DropDownListTemplateDetailPhaseEditDropDownList"), Telerik.Web.UI.RadComboBox)

            End If

            If DropDownListPhases IsNot Nothing Then

                DropDownListPhases.DataSource = (From Phase In _PhasesList
                                                 Where Phase.IsInactive = 0
                                                 Select Phase.ID,
                                                        Phase.Description).ToList

                DropDownListPhases.DataBind()

                DropDownListPhases.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("", ""))

                If CType(e.Item, Telerik.Web.UI.GridEditableItem).IsInEditMode = False Then

                    Try

                        InactivePhase = (From Phase In _PhasesList
                                         Where Phase.ID = e.Item.DataItem.PhaseID AndAlso
                                               Phase.IsInactive = 1
                                         Select Phase).Single

                    Catch ex As Exception
                        InactivePhase = Nothing
                    End Try

                    If InactivePhase IsNot Nothing Then

                        DropDownListPhases.Items.Insert(1, New Telerik.Web.UI.RadComboBoxItem(InactivePhase.Description & "*", InactivePhase.ID))

                        DropDownListPhases.SelectedValue = InactivePhase.ID

                    Else

                        DropDownListPhases.SelectedValue = e.Item.DataItem.PhaseID

                    End If

                End If

            End If

        Catch ex As Exception
            DropDownListPhases = Nothing
        End Try

        Try

            DropDownListTasks = DirectCast(e.Item.FindControl("DropDownListTemplateDetailTaskCode"), Telerik.Web.UI.RadComboBox)

            If DropDownListTasks Is Nothing Then

                DropDownListTasks = DirectCast(e.Item.FindControl("DropDownListTemplateDetailTaskCodeEditDropDownList"), Telerik.Web.UI.RadComboBox)

                If DropDownListTasks IsNot Nothing Then

                    AddHandler DropDownListTasks.SelectedIndexChanged, AddressOf TaskTemplateDetailTaskSelectionChanged

                End If

            End If

            If DropDownListTasks IsNot Nothing Then

                DropDownListTasks.DataSource = (From Task In _TasksList
                                                Where Task.IsInactive Is Nothing OrElse
                                                      Task.IsInactive = 0
                                                Select Task.Code,
                                                       Task.Description
                                                Order By Description).ToList

                DropDownListTasks.DataBind()

                DropDownListTasks.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("", ""))

                If CType(e.Item, Telerik.Web.UI.GridEditableItem).IsInEditMode = False Then

                    Try

                        InactiveTask = (From Task In _TasksList
                                        Where Task.Code = e.Item.DataItem.TaskCode AndAlso
                                              Task.IsInactive = 1
                                        Select Task).Single

                    Catch ex As Exception
                        InactiveTask = Nothing
                    End Try

                    If InactiveTask IsNot Nothing Then

                        DropDownListTasks.Items.Insert(1, New Telerik.Web.UI.RadComboBoxItem(InactiveTask.Description & "*", InactiveTask.Code))

                        DropDownListTasks.SelectedValue = InactiveTask.Code

                    Else

                        DropDownListTasks.SelectedValue = e.Item.DataItem.TaskCode

                    End If

                End If

            End If

        Catch ex As Exception
            DropDownListTasks = Nothing
        End Try

        Try

            DropDownListEmployees = DirectCast(e.Item.FindControl("DropDownListTemplateDetailDefaultEmployee"), Telerik.Web.UI.RadComboBox)

            If DropDownListEmployees Is Nothing Then

                DropDownListEmployees = DirectCast(e.Item.FindControl("DropDownListTemplateDetailDefaultEmployeeEditDropDownList"), Telerik.Web.UI.RadComboBox)

            End If

            If DropDownListEmployees IsNot Nothing Then

                If UserEmployeeOfficeList IsNot Nothing AndAlso UserEmployeeOfficeList.Count > 0 Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                        DropDownListEmployees.DataSource = (From Employee In _EmployeesList
                                                            Join EmpOffice In AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode) On Employee.OfficeCode Equals EmpOffice.OfficeCode
                                                            Where Employee.TerminationDate Is Nothing
                                                            Select Employee.Code,
                                                                   [FullName] = Employee.FirstName & " " & Employee.LastName).ToList
                    End Using

                Else

                    DropDownListEmployees.DataSource = (From Employee In _EmployeesList
                                                        Where Employee.TerminationDate Is Nothing
                                                        Select Employee.Code,
                                                               [FullName] = Employee.FirstName & " " & Employee.LastName).ToList

                End If



                DropDownListEmployees.DataBind()

                DropDownListEmployees.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("", ""))

                If CType(e.Item, Telerik.Web.UI.GridEditableItem).IsInEditMode = False Then

                    Try

                        InactiveEmployee = (From Employee In _EmployeesList
                                            Where Employee.Code = e.Item.DataItem.DefaultEmployeeCode AndAlso
                                                  Employee.TerminationDate IsNot Nothing
                                            Select Employee).Single

                    Catch ex As Exception
                        InactiveEmployee = Nothing
                    End Try

                    If InactiveEmployee IsNot Nothing Then

                        DropDownListEmployees.Items.Insert(1, New Telerik.Web.UI.RadComboBoxItem(InactiveEmployee.FirstName & " " & InactiveEmployee.LastName & "*", InactiveEmployee.Code))

                        DropDownListEmployees.SelectedValue = InactiveEmployee.Code

                    Else

                        DropDownListEmployees.SelectedValue = e.Item.DataItem.DefaultEmployeeCode

                    End If

                End If

            End If

        Catch ex As Exception
            DropDownListEmployees = Nothing
        End Try

        Try

            DropDownListFunctions = DirectCast(e.Item.FindControl("DropDownListTemplateDetailDefaultFunction"), Telerik.Web.UI.RadComboBox)

            If DropDownListFunctions Is Nothing Then

                DropDownListFunctions = DirectCast(e.Item.FindControl("DropDownListTemplateDetailDefaultFunctionEditDropDownList"), Telerik.Web.UI.RadComboBox)

            End If

            If DropDownListFunctions IsNot Nothing Then

                DropDownListFunctions.DataSource = (From [Function] In _FunctionsList
                                                    Where [Function].IsInactive Is Nothing OrElse
                                                          [Function].IsInactive = 0
                                                    Select [Function].Code,
                                                            [Function].Description).ToList

                DropDownListFunctions.DataBind()

                DropDownListFunctions.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("", ""))

                If CType(e.Item, Telerik.Web.UI.GridEditableItem).IsInEditMode = False Then

                    Try

                        InactiveFunction = (From [Function] In _FunctionsList
                                            Where [Function].Code = e.Item.DataItem.DefaultFunctionCode AndAlso
                                                  [Function].IsInactive = 1
                                            Select [Function]).Single

                    Catch ex As Exception
                        InactiveFunction = Nothing
                    End Try

                    If InactiveFunction IsNot Nothing Then

                        DropDownListFunctions.Items.Insert(1, New Telerik.Web.UI.RadComboBoxItem(InactiveFunction.Description & "*", InactiveFunction.Code))

                        DropDownListFunctions.SelectedValue = InactiveFunction.Code

                    Else

                        DropDownListFunctions.SelectedValue = e.Item.DataItem.DefaultFunctionCode

                    End If

                End If

            End If

        Catch ex As Exception
            DropDownListFunctions = Nothing
        End Try

        Try

            ImageButtonDelete = DirectCast(e.Item.FindControl("ImageButtonDelete"), ImageButton)

            If ImageButtonDelete IsNot Nothing Then

                ImageButtonDelete.Attributes.Add("onclick", "return confirm('Are you sure you want to delete?');")

            End If

        Catch ex As Exception
            ImageButtonDelete = Nothing
        End Try

    End Sub
    Private Sub DropDownListTaskTemplate_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListTaskTemplate.SelectedIndexChanged

        If DropDownListTaskTemplate.SelectedValue IsNot Nothing AndAlso DropDownListTaskTemplate.SelectedValue <> "" Then

            LoadTaskTemplatesDetail()

        Else

            TextBoxTaskTemplateDescription.Text = ""

            TextBoxStandardScheduleCompletionDays.Text = ""
            TextBoxRushScheduleCompletionDays.Text = ""

            RadGridTaskTemplateDetails.DataSource = ""

        End If

    End Sub
    Private Sub TextBoxTaskTemplateDescription_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxTaskTemplateDescription.TextChanged

        'objects
        Dim TaskTemplate As AdvantageFramework.Database.Entities.TaskTemplate = Nothing

        If DropDownListTaskTemplate.SelectedValue IsNot Nothing AndAlso DropDownListTaskTemplate.SelectedValue.ToString() <> "" Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                TaskTemplate = AdvantageFramework.Database.Procedures.TaskTemplate.LoadByTaskTemplateCode(DbContext, DropDownListTaskTemplate.SelectedValue)

                If TaskTemplate IsNot Nothing Then

                    TaskTemplate.Description = TextBoxTaskTemplateDescription.Text

                    AdvantageFramework.Database.Procedures.TaskTemplate.Update(DbContext, TaskTemplate)

                End If

            End Using

        End If

    End Sub
    Private Sub RadGridTaskTemplateDetails_PageSizeChanged(sender As Object, e As Telerik.Web.UI.GridPageSizeChangedEventArgs) Handles RadGridTaskTemplateDetails.PageSizeChanged

        Response.Cookies("RadGridTaskTemplateDetails_PageSize").Value = e.NewPageSize
        Response.Cookies("RadGridTaskTemplateDetails_PageSize").Expires = Now.AddDays(365)

    End Sub
    Private Sub ImageButtonCopyTaskTemplateDetails_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonCopyTaskTemplateDetails.Click

        'objects
        Dim NewTaskTemplateDetail As AdvantageFramework.Database.Entities.TaskTemplateDetail = Nothing

        If DropDownListTaskTemplate.SelectedValue IsNot Nothing AndAlso DropDownListTaskTemplate.SelectedValue.ToString() <> "" AndAlso
                DropDownListCopyTaskTemplateDetails.SelectedValue IsNot Nothing AndAlso DropDownListCopyTaskTemplateDetails.SelectedValue.ToString() <> "" Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(Session("ConnString").ToString(), Session("UserCode").ToString())

                    For Each TaskTemplateDetail In AdvantageFramework.Database.Procedures.TaskTemplateDetail.LoadByTaskTemplateCode(DataContext, DropDownListCopyTaskTemplateDetails.SelectedValue)

                        NewTaskTemplateDetail = New AdvantageFramework.Database.Entities.TaskTemplateDetail

                        NewTaskTemplateDetail.TaskTemplateCode = DropDownListTaskTemplate.SelectedValue
                        NewTaskTemplateDetail.TaskCode = TaskTemplateDetail.TaskCode
                        NewTaskTemplateDetail.PhaseID = TaskTemplateDetail.PhaseID
                        NewTaskTemplateDetail.ProcessOrderNumber = TaskTemplateDetail.ProcessOrderNumber
                        NewTaskTemplateDetail.DaysToComplete = TaskTemplateDetail.DaysToComplete
                        NewTaskTemplateDetail.HoursAllowed = TaskTemplateDetail.HoursAllowed
                        NewTaskTemplateDetail.RushDaysToComplete = TaskTemplateDetail.RushDaysToComplete
                        NewTaskTemplateDetail.RushHoursToComplete = TaskTemplateDetail.RushHoursToComplete
                        NewTaskTemplateDetail.IsMilestone = TaskTemplateDetail.IsMilestone
                        NewTaskTemplateDetail.EmployeeCode = TaskTemplateDetail.EmployeeCode
                        NewTaskTemplateDetail.FunctionCode = TaskTemplateDetail.FunctionCode
                        NewTaskTemplateDetail.RoleCode = TaskTemplateDetail.RoleCode

                        AdvantageFramework.Database.Procedures.TaskTemplateDetail.Insert(DbContext, DataContext, NewTaskTemplateDetail)

                    Next

                End Using

            End Using

            LoadTaskTemplatesDetailTab(DropDownListTaskTemplate.SelectedValue)

        End If

    End Sub

#End Region

#End Region

    Private Sub RadGridTaskTemplates_PageIndexChanged(sender As Object, e As Telerik.Web.UI.GridPageChangedEventArgs) Handles RadGridTaskTemplates.PageIndexChanged

        Me.CurrentPageNumber = e.NewPageIndex
        Me.RadGridTaskTemplates.Rebind()

    End Sub

    Private Sub RadGridTaskTemplates_PageSizeChanged(sender As Object, e As Telerik.Web.UI.GridPageSizeChangedEventArgs) Handles RadGridTaskTemplates.PageSizeChanged

        MiscFN.SavePageSize(Me.RadGridTaskTemplates.ID, e.NewPageSize)

    End Sub

    Private Sub RadGridTaskTemplateDetails_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridTaskTemplateDetails.NeedDataSource

        Dim TaskTemplateCode As String = ""

        If Not String.IsNullOrWhiteSpace(DropDownListTaskTemplate.SelectedValue) Then

            TaskTemplateCode = DropDownListTaskTemplate.SelectedValue

        End If

        Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

            RadGridTaskTemplateDetails.DataSource = (From TaskTemplateDetail In AdvantageFramework.Database.Procedures.TaskTemplateDetailView.LoadByTaskTemplateCode(DataContext, TaskTemplateCode)
                                                     Select TaskTemplateDetail.TaskTemplateDetailID,
                                                                        TaskTemplateDetail.PhaseID,
                                                                        TaskTemplateDetail.PhaseDescription,
                                                                        TaskTemplateDetail.TaskCode,
                                                                        TaskTemplateDetail.TaskDescription,
                                                                        TaskTemplateDetail.ProcessOrderNumber,
                                                                        TaskTemplateDetail.DaysToComplete,
                                                                        TaskTemplateDetail.HoursAllowed,
                                                                        TaskTemplateDetail.RushDaysToComplete,
                                                                        TaskTemplateDetail.RushHoursToComplete,
                                                                        TaskTemplateDetail.IsMilestone,
                                                                        TaskTemplateDetail.DefaultEmployeeCode,
                                                                        TaskTemplateDetail.DefaultEmployeeName,
                                                                        TaskTemplateDetail.DefaultFunctionCode,
                                                                        TaskTemplateDetail.DefaultFunctionDescription
                                                     Order By ProcessOrderNumber).ToList

            RadGridTaskTemplateDetails.MasterTableView.IsItemInserted = True

        End Using

    End Sub

End Class