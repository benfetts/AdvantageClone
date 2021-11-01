Public Class Maintenance_Task
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



#End Region

#Region " Methods "

    Private Sub UpdateTask(ByRef GridDataItem As Telerik.Web.UI.GridDataItem)

        'objects
        Dim Task As AdvantageFramework.Database.Entities.Task = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Task = AdvantageFramework.Database.Procedures.Task.LoadByTaskCode(DbContext, GridDataItem.GetDataKeyValue("Code"))

            If Task IsNot Nothing Then

                Task.Description = CType(GridDataItem.FindControl("TextBoxTaskDescription"), TextBox).Text.Trim

                Task.ProcessOrderNumber = CType(GridDataItem.FindControl("TextBoxTaskProcessOrderNumber"), Telerik.Web.UI.RadNumericTextBox).Value
                Task.DaysToComplete = CType(GridDataItem.FindControl("TextBoxTaskDaysToComplete"), Telerik.Web.UI.RadNumericTextBox).Value
                Task.HoursAllowed = CType(GridDataItem.FindControl("TextBoxTaskHoursAllowed"), Telerik.Web.UI.RadNumericTextBox).Value

                If DirectCast(GridDataItem.FindControl("CheckBoxTaskIsMilestone"), CheckBox).Checked Then

                    Task.IsMilestone = 1

                Else

                    Task.IsMilestone = 0

                End If

                If CType(GridDataItem.FindControl("DropDownListTaskDefaultFunction"), Telerik.Web.UI.RadComboBox).SelectedItem.ToString() <> "" Then

                    Task.FunctionCode = CType(GridDataItem.FindControl("DropDownListTaskDefaultFunction"), Telerik.Web.UI.RadComboBox).SelectedValue

                Else

                    Task.FunctionCode = Nothing

                End If

                If CType(GridDataItem.FindControl("DropDownListTaskDefaultStatus"), Telerik.Web.UI.RadComboBox).SelectedItem.ToString() <> "" Then

                    Task.StatusCode = CType(GridDataItem.FindControl("DropDownListTaskDefaultStatus"), Telerik.Web.UI.RadComboBox).SelectedValue

                Else

                    Task.StatusCode = Nothing

                End If

                If DirectCast(GridDataItem.FindControl("CheckBoxTaskIsInactive"), CheckBox).Checked Then

                    Task.IsInactive = 1

                Else

                    Task.IsInactive = 0

                End If

                AdvantageFramework.Database.Procedures.Task.Update(DbContext, Task)

            End If

        End Using

    End Sub

#Region "  Form Event Handlers "

    Private Sub Maintenance_Task_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.PageTitle = "Task Maintenance"

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            CheckBoxShowInactive.Visible = True

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub CheckBoxShowInactive_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxShowInactive.CheckedChanged

        RadGridTasks.DataSource = Nothing
        RadGridTasks.Rebind()

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

        DataTable = New DataTable

        DataTable.Columns.Add("Code")
        DataTable.Columns.Add("Description")
        DataTable.Columns.Add("Process Order Number")
        DataTable.Columns.Add("Days To Complete")
        DataTable.Columns.Add("Hours Allowed")
        DataTable.Columns.Add("Milestone")
        DataTable.Columns.Add("Default Function")
        DataTable.Columns.Add("Default Status")
        DataTable.Columns.Add("Inactive")

        RadGridTasks.AllowPaging = False

        RadGridTasks.DataSource = Nothing
        RadGridTasks.Rebind()

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            For Each GridDataItem In RadGridTasks.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

                NewDataRow = DataTable.Rows.Add()

                NewDataRow(0) = GridDataItem.DataItem.Code
                NewDataRow(1) = GridDataItem.DataItem.Description
                NewDataRow(2) = GridDataItem.DataItem.ProcessOrderNumber
                NewDataRow(3) = GridDataItem.DataItem.DaysToComplete
                NewDataRow(4) = GridDataItem.DataItem.HoursAllowed

                If GridDataItem.DataItem.IsMilestone Then

                    NewDataRow(5) = "YES"

                Else

                    NewDataRow(5) = "NO"

                End If

                [Function] = AdvantageFramework.Database.Procedures.Function.LoadByFunctionCode(DbContext, GridDataItem.DataItem.FunctionCode)

                If [Function] IsNot Nothing Then

                    NewDataRow(6) = [Function].Description

                End If

                Status = AdvantageFramework.Database.Procedures.Status.LoadByStatusCode(DbContext, GridDataItem.DataItem.StatusCode)

                If Status IsNot Nothing Then

                    NewDataRow(7) = Status.Description

                End If

                If GridDataItem.DataItem.IsInactive Then

                    NewDataRow(8) = "YES"

                Else

                    NewDataRow(8) = "NO"

                End If

            Next

        End Using

        'DataView = New DataView(DataTable)

        'GridView = New GridView

        'GridView.DataSource = DataView
        'GridView.DataBind()

        'AdvantageFramework.Web.Exporting.ToExcel("Tasks.xls", GridView)    <--- This doesn' work
        Me.DeliverGrid(DataTable, "Tasks") '<--- This does, please don't change unless you test!!!!

        RadGridTasks.AllowPaging = True

        RadGridTasks.DataSource = Nothing
        RadGridTasks.Rebind()

    End Sub
    Private Sub RadGridTasks_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridTasks.ItemDataBound

        'objects
        Dim DropDownListFunctions As Telerik.Web.UI.RadComboBox = Nothing
        Dim DropDownListStatuses As Telerik.Web.UI.RadComboBox = Nothing
        Dim ImageButtonDelete As System.Web.UI.WebControls.ImageButton = Nothing
        Dim InactiveFunction As AdvantageFramework.Database.Entities.Function = Nothing
        Dim InactiveStatus As AdvantageFramework.Database.Entities.Status = Nothing

        If _FunctionsList Is Nothing Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                _FunctionsList = AdvantageFramework.Database.Procedures.Function.LoadAllEmployeeFunctions(DbContext).ToList

            End Using

        End If

        If _StatusesList Is Nothing Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                _StatusesList = AdvantageFramework.Database.Procedures.Status.LoadAllActive(DbContext).ToList

            End Using

        End If

        Try

            DropDownListFunctions = DirectCast(e.Item.FindControl("DropDownListTaskDefaultFunction"), Telerik.Web.UI.RadComboBox)

            If DropDownListFunctions Is Nothing Then

                DropDownListFunctions = DirectCast(e.Item.FindControl("DropDownListTaskDefaultFunctionEditDropDownList"), Telerik.Web.UI.RadComboBox)

            End If

            If DropDownListFunctions IsNot Nothing Then

                DropDownListFunctions.DataSource = (From [Function] In _FunctionsList
                                                    Where [Function].IsInactive Is Nothing OrElse
                                                          [Function].IsInactive = 0
                                                    Select [Function].Code,
                                                           [Description] = If([Function].IsInactive Is Nothing OrElse [Function].IsInactive = 0, CStr([Function].Description & " ").Trim, [Function].Description & "*")
                                                    Order By
                                                        [Description]).ToList

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

                        DropDownListFunctions.SelectedValue = e.Item.DataItem.FunctionCode

                    End If

                End If

            End If

        Catch ex As Exception
            DropDownListFunctions = Nothing
        End Try

        Try

            DropDownListStatuses = DirectCast(e.Item.FindControl("DropDownListTaskDefaultStatus"), Telerik.Web.UI.RadComboBox)

            If DropDownListStatuses Is Nothing Then

                DropDownListStatuses = DirectCast(e.Item.FindControl("DropDownListTaskDefaultStatusEditDropDownList"), Telerik.Web.UI.RadComboBox)

            End If

            If DropDownListStatuses IsNot Nothing Then

                DropDownListStatuses.DataSource = (From Status In _StatusesList
                                                   Where Status.IsInactive Is Nothing OrElse
                                                         Status.IsInactive = 0
                                                   Select Status.Code,
                                                          [Description] = If(Status.IsInactive Is Nothing OrElse Status.IsInactive = 0, CStr(Status.Description & " ").Trim, Status.Description & "*")).ToList

                DropDownListStatuses.DataBind()

                DropDownListStatuses.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("", ""))

                If CType(e.Item, Telerik.Web.UI.GridEditableItem).IsInEditMode = False Then

                    Try

                        InactiveStatus = (From Status In _StatusesList
                                          Where Status.Code = e.Item.DataItem.StatusCode AndAlso
                                                Status.IsInactive = 1
                                          Select Status).Single

                    Catch ex As Exception
                        InactiveStatus = Nothing
                    End Try

                    If InactiveStatus IsNot Nothing Then

                        DropDownListStatuses.Items.Insert(1, New Telerik.Web.UI.RadComboBoxItem(InactiveStatus.Description & "*", InactiveStatus.Code))

                        DropDownListStatuses.SelectedValue = InactiveStatus.Code

                    Else

                        DropDownListStatuses.SelectedValue = e.Item.DataItem.StatusCode

                    End If

                End If

            End If

        Catch ex As Exception
            DropDownListStatuses = Nothing
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
    Private Sub RadGridTasks_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridTasks.ItemCommand

        'objects
        Dim GridEditableItem As Telerik.Web.UI.GridEditableItem = Nothing
        Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim Task As AdvantageFramework.Database.Entities.Task = Nothing
        Dim Reload As Boolean = True

        If e.Item IsNot Nothing AndAlso e.Item.ItemIndex > -1 Then

            CurrentGridDataItem = RadGridTasks.Items(e.Item.ItemIndex)

        End If

        Select Case e.CommandName

            Case "SaveAll"

                For Each GridDataItem In RadGridTasks.MasterTableView.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

                    UpdateTask(GridDataItem)

                Next

            Case "SaveNewRow"

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Task = New AdvantageFramework.Database.Entities.Task

                    Task.DbContext = DbContext

                    Task.Code = CType(e.Item.FindControl("TextBoxTaskCodeEditTextBox"), TextBox).Text.Trim
                    Task.Description = CType(e.Item.FindControl("TextBoxTaskDescriptionEditTextBox"), TextBox).Text.Trim

                    Task.ProcessOrderNumber = CType(e.Item.FindControl("TextBoxTaskProcessOrderNumberEditTextBox"), Telerik.Web.UI.RadNumericTextBox).Value
                    Task.DaysToComplete = CType(e.Item.FindControl("TextBoxTaskDaysToCompleteEditTextBox"), Telerik.Web.UI.RadNumericTextBox).Value
                    Task.HoursAllowed = CType(e.Item.FindControl("TextBoxTaskHoursAllowedEditTextBox"), Telerik.Web.UI.RadNumericTextBox).Value

                    If DirectCast(e.Item.FindControl("CheckBoxTaskIsMilestoneEditCheckBox"), CheckBox).Checked Then

                        Task.IsMilestone = 1

                    Else

                        Task.IsMilestone = 0

                    End If

                    Task.FunctionCode = CType(e.Item.FindControl("DropDownListTaskDefaultFunctionEditDropDownList"), Telerik.Web.UI.RadComboBox).SelectedValue
                    Task.StatusCode = CType(e.Item.FindControl("DropDownListTaskDefaultStatusEditDropDownList"), Telerik.Web.UI.RadComboBox).SelectedValue

                    If DirectCast(e.Item.FindControl("CheckBoxTaskIsInactiveEditCheckBox"), CheckBox).Checked Then

                        Task.IsInactive = 1

                    Else

                        Task.IsInactive = 0

                    End If

                    Reload = AdvantageFramework.Database.Procedures.Task.Insert(DbContext, Task)

                End Using

            Case "SaveRow"

                If CurrentGridDataItem IsNot Nothing Then

                    UpdateTask(CurrentGridDataItem)

                End If

            Case "CancelNewRow"

                If e.Item IsNot Nothing Then

                    CType(e.Item.FindControl("TextBoxTaskCodeEditTextBox"), TextBox).Text = ""
                    CType(e.Item.FindControl("TextBoxTaskDescriptionEditTextBox"), TextBox).Text = ""

                    CType(e.Item.FindControl("TextBoxTaskProcessOrderNumberEditTextBox"), Telerik.Web.UI.RadNumericTextBox).Value = 0
                    CType(e.Item.FindControl("TextBoxTaskDaysToCompleteEditTextBox"), Telerik.Web.UI.RadNumericTextBox).Value = 0
                    CType(e.Item.FindControl("TextBoxTaskHoursAllowedEditTextBox"), Telerik.Web.UI.RadNumericTextBox).Value = 0

                    CType(e.Item.FindControl("CheckBoxTaskIsMilestoneEditCheckBox"), CheckBox).Checked = False

                    CType(e.Item.FindControl("DropDownListTaskDefaultFunctionEditDropDownList"), Telerik.Web.UI.RadComboBox).SelectedValue = Nothing
                    CType(e.Item.FindControl("DropDownListTaskDefaultStatusEditDropDownList"), Telerik.Web.UI.RadComboBox).SelectedValue = Nothing

                    CType(e.Item.FindControl("CheckBoxTaskIsInactiveEditCheckBox"), CheckBox).Checked = False

                End If

            Case "DeleteRow"

                If CurrentGridDataItem IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Using DataContext = New AdvantageFramework.Database.DataContext(Session("ConnString").ToString(), Session("UserCode").ToString())

                            Task = AdvantageFramework.Database.Procedures.Task.LoadByTaskCode(DbContext, CurrentGridDataItem.GetDataKeyValue("Code"))

                            If Task IsNot Nothing Then

                                AdvantageFramework.Database.Procedures.Task.Delete(DbContext, DataContext, Task)

                            End If

                        End Using

                    End Using

                End If

        End Select

        If Reload Then

            If e.CommandName = "SaveNewRow" Then

                MiscFN.ResponseRedirect("Maintenance_Task.aspx")

            Else

                RadGridTasks.DataSource = Nothing
                RadGridTasks.Rebind()

            End If

        Else

            If e.Item IsNot Nothing AndAlso e.Item.IsInEditMode Then

                CType(e.Item.FindControl("TextBoxTaskCodeEditTextBox"), TextBox).Focus()

            End If

        End If

    End Sub
    Private Sub RadGridTasks_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridTasks.NeedDataSource

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            If CheckBoxShowInactive.Checked Then

                RadGridTasks.DataSource = (From Task In AdvantageFramework.Database.Procedures.Task.Load(DbContext).ToList
                                           Select Task.Code,
                                                  Task.Description,
                                                  Task.ProcessOrderNumber,
                                                  Task.DaysToComplete,
                                                  Task.HoursAllowed,
                                                  [IsMilestone] = CBool(Task.IsMilestone),
                                                  Task.FunctionCode,
                                                  Task.StatusCode,
                                                  [IsInactive] = CBool(Task.IsInactive.GetValueOrDefault(0))
                                           Order By Description).ToList

            Else

                RadGridTasks.DataSource = (From Task In AdvantageFramework.Database.Procedures.Task.LoadAllActive(DbContext).ToList
                                           Select Task.Code,
                                                  Task.Description,
                                                  Task.ProcessOrderNumber,
                                                  Task.DaysToComplete,
                                                  Task.HoursAllowed,
                                                  [IsMilestone] = CBool(Task.IsMilestone),
                                                  Task.FunctionCode,
                                                  Task.StatusCode,
                                                  [IsInactive] = CBool(Task.IsInactive.GetValueOrDefault(0))
                                           Order By Description).ToList

            End If

            RadGridTasks.MasterTableView.IsItemInserted = True

        End Using

    End Sub

#End Region

#End Region

End Class