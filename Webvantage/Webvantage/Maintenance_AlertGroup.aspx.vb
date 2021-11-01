Public Class Maintenance_AlertGroup
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



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

#End Region

#Region " Methods "

    Private Function LoadAlertGroups(ByRef DbContext As AdvantageFramework.Database.DbContext) As Generic.IEnumerable(Of Object)

        If CheckBoxShowInactive.Checked Then

            LoadAlertGroups = (From AlertGroup In AdvantageFramework.Database.Procedures.AlertGroup.Load(DbContext).ToList
                               Select AlertGroup.Code,
                                        [IsInactive] = CBool(AlertGroup.IsInactive.GetValueOrDefault(0))
                               Distinct).ToList

        Else

            LoadAlertGroups = (From AlertGroup In AdvantageFramework.Database.Procedures.AlertGroup.LoadAllActive(DbContext).ToList
                               Select AlertGroup.Code,
                                        [IsInactive] = CBool(AlertGroup.IsInactive.GetValueOrDefault(0))
                               Distinct).ToList

        End If

    End Function
    Private Sub LoadAlertGroupsGridOnAlertGroupsTab()

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            RadGridAlertGroups.DataSource = LoadAlertGroups(DbContext)

            RadGridAlertGroups.DataBind()

        End Using

    End Sub
    Private Sub LoadAlertGroupsTab()

        LoadAlertGroupsGridOnAlertGroupsTab()

    End Sub
    Private Sub LoadAlertGroupDetailTab(ByVal AlertGroupCode As String)

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            DropDownListAlertGroups.DataSource = LoadAlertGroups(DbContext)

            DropDownListAlertGroups.DataBind()

            DropDownListAlertGroups.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

        End Using

        Try

            If AlertGroupCode <> "" Then

                DropDownListAlertGroups.SelectedValue = AlertGroupCode

            End If

        Catch ex As Exception

            If DropDownListAlertGroups.Items.Count > 0 Then

                DropDownListAlertGroups.SelectedIndex = 0

            End If

        End Try

        If DropDownListAlertGroups.SelectedValue IsNot Nothing AndAlso DropDownListAlertGroups.SelectedValue.ToString() <> "" Then

            LoadAlertGroupDetails()

        Else

            RadGridAlertGroupAvailableEmployees.DataSource = Nothing

            RadGridAlertGroupAvailableEmployees.DataBind()

            RadGridAlertGroupCurrentEmployees.DataSource = Nothing

            RadGridAlertGroupCurrentEmployees.DataBind()

        End If

    End Sub
    Private Sub UpdateAlertGroupOnAlertGroupsTab(ByRef GridDataItem As Telerik.Web.UI.GridDataItem)

        'objects
        Dim AlertGroupCode As String = ""

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            AlertGroupCode = GridDataItem.GetDataKeyValue("Code")

            For Each AlertGroup In AdvantageFramework.Database.Procedures.AlertGroup.LoadByAlertGroupCode(DbContext, AlertGroupCode).ToList

                If DirectCast(GridDataItem.FindControl("CheckBoxIsInactive"), CheckBox).Checked Then

                    AlertGroup.IsInactive = 1

                Else

                    AlertGroup.IsInactive = 0

                End If

                AdvantageFramework.Database.Procedures.AlertGroup.Update(DbContext, AlertGroup)

                Dim SettingValue As AdvantageFramework.Database.Entities.SettingValue = Nothing
                Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)
                    Try
                        If AlertGroup.IsInactive = 1 Then
                            Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.JR_DFLT_ALERT_GROUP.ToString)
                            If Setting IsNot Nothing Then
                                If Setting.Value <> AlertGroupCode Then
                                    AdvantageFramework.Database.Procedures.SettingValue.DeleteBySettingCodeAndLookupValue(DataContext, AdvantageFramework.Agency.Settings.JR_DFLT_ALERT_GROUP.ToString, AlertGroupCode)
                                End If
                            End If
                        Else
                            If AdvantageFramework.Database.Procedures.SettingValue.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.JR_DFLT_ALERT_GROUP.ToString).Any(Function(Entity) Entity.Value.ToString = AlertGroupCode.ToString) = False Then
                                SettingValue = New AdvantageFramework.Database.Entities.SettingValue
                                SettingValue.DataContext = DataContext
                                SettingValue.SettingCode = AdvantageFramework.Agency.Settings.JR_DFLT_ALERT_GROUP.ToString
                                SettingValue.DisplayText = AlertGroupCode
                                SettingValue.Value = AlertGroupCode
                                AdvantageFramework.Database.Procedures.SettingValue.Insert(DataContext, SettingValue)
                            Else
                                SettingValue = AdvantageFramework.Database.Procedures.SettingValue.LoadBySettingCodeAndValue(DataContext, AdvantageFramework.Agency.Settings.JR_DFLT_ALERT_GROUP.ToString, AlertGroupCode.ToString)
                                SettingValue.DisplayText = AlertGroupCode
                                AdvantageFramework.Database.Procedures.SettingValue.Update(DataContext, SettingValue)
                            End If

                        End If

                    Catch ex As Exception

                    End Try
                End Using

            Next

        End Using

    End Sub
    Private Sub LoadAlertGroupDetails()

        'objects
        Dim AlertGroupList As Generic.List(Of AdvantageFramework.Database.Entities.AlertGroup) = Nothing
        Dim AlertGroup As AdvantageFramework.Database.Entities.AlertGroup = Nothing
        Dim CurrentEmployeesList As Generic.List(Of Object) = Nothing
        Dim AvailableEmployeesList As Generic.List(Of Object) = Nothing
        Dim Role As AdvantageFramework.Database.Entities.Role = Nothing
        Dim [Function] As AdvantageFramework.Database.Entities.Function = Nothing
        Dim UserEmployeeOfficeList As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeOffice) = Nothing
        Dim DefaultRoleDescription As String = ""
        Dim DefaultFunctionDescription As String = ""

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            AlertGroupList = AdvantageFramework.Database.Procedures.AlertGroup.LoadByAlertGroupCode(DbContext, DropDownListAlertGroups.SelectedValue).ToList
            UserEmployeeOfficeList = AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode).ToList
            CurrentEmployeesList = New Generic.List(Of Object)
            AvailableEmployeesList = New Generic.List(Of Object)

            If AlertGroupList.Count > 0 AndAlso AlertGroupList(0).IsInactive.GetValueOrDefault(0) = 1 Then

                CheckBoxIsInactive.Checked = True

            Else

                CheckBoxIsInactive.Checked = False

            End If

            For Each Employee In AdvantageFramework.Database.Procedures.EmployeeView.Load(DbContext)

                Try

                    AlertGroup = (From Entity In AlertGroupList.AsQueryable
                                  Where Entity.EmployeeCode = Employee.Code
                                  Select Entity).Single

                Catch ex As Exception
                    AlertGroup = Nothing
                End Try

                If AlertGroup IsNot Nothing Then

                    Role = AdvantageFramework.Database.Procedures.Role.LoadByRoleCode(DbContext, Employee.RoleCode)

                    If Role IsNot Nothing Then

                        DefaultRoleDescription = Role.Description

                    Else

                        DefaultRoleDescription = ""

                    End If

                    [Function] = AdvantageFramework.Database.Procedures.Function.LoadByFunctionCode(DbContext, Employee.FunctionCode)

                    If [Function] IsNot Nothing Then

                        DefaultFunctionDescription = [Function].Description

                    Else

                        DefaultFunctionDescription = ""

                    End If

                    CurrentEmployeesList.Add(New With {.IncludeOnSchedule = AlertGroup.IncludeOnSchedule.GetValueOrDefault(0), .EmployeeCode = Employee.Code, .EmployeeName = Employee.FirstName & " " & Employee.LastName, .Email = Employee.Email, .DefaultFunction = DefaultFunctionDescription, .DefaultRole = DefaultRoleDescription})

                Else

                    If Employee.TerminationDate Is Nothing Then

                        If UserEmployeeOfficeList IsNot Nothing AndAlso UserEmployeeOfficeList.Count > 0 Then
                            For Each office In UserEmployeeOfficeList
                                If office.OfficeCode = Employee.OfficeCode Then
                                    AvailableEmployeesList.Add(New With {.EmployeeCode = Employee.Code, .EmployeeName = Employee.FirstName & " " & Employee.LastName})
                                End If
                            Next
                        Else
                            AvailableEmployeesList.Add(New With {.EmployeeCode = Employee.Code, .EmployeeName = Employee.FirstName & " " & Employee.LastName})
                        End If

                    End If

                End If

            Next

            RadGridAlertGroupAvailableEmployees.DataSource = AvailableEmployeesList.AsQueryable

            RadGridAlertGroupAvailableEmployees.DataBind()

            RadGridAlertGroupCurrentEmployees.DataSource = CurrentEmployeesList.AsQueryable

            RadGridAlertGroupCurrentEmployees.DataBind()

        End Using

    End Sub
    Private Sub ChangeTabs(ByVal AlertGroupCode As String)

        Select Case RadTabStripAlertGroups.SelectedIndex

            Case 0

                LoadAlertGroupsTab()

            Case 1

                LoadAlertGroupDetailTab(AlertGroupCode)

        End Select

    End Sub

#Region "  Form Event Handlers "

    Private Sub Maintenance_AlertGroup_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.PageTitle = "Alert Group Maintenance"
        'objects
        Dim TabIndex As Integer = 0
        Dim AlertGroupCode As String = ""
        Dim Action As Integer = 0
        Dim ShowInactive As Integer = 0
        Dim AvailableEmployeeList As Generic.List(Of Object) = Nothing
        Dim CurrentEmployeeList As Generic.List(Of Object) = Nothing
        Dim UserEmployeeOfficeList As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeOffice) = Nothing

        If Not Me.IsPostBack And Not Me.IsCallback Then

            Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_AlertGroups)

            Try

                If Not Request.QueryString("TabIndex") Is Nothing Then

                    TabIndex = CType(Request.QueryString("TabIndex"), Integer)

                End If

                If Not Request.QueryString("AlertGroupCode") Is Nothing Then

                    AlertGroupCode = CType(Request.QueryString("AlertGroupCode"), String)

                End If

                If Not Request.QueryString("Action") Is Nothing Then

                    Action = CType(Request.QueryString("Action"), Integer)

                End If

                If Not Request.QueryString("ShowInactive") Is Nothing Then

                    ShowInactive = CType(Request.QueryString("ShowInactive"), Integer)

                End If

            Catch ex As Exception
                TabIndex = 0
                AlertGroupCode = ""
                Action = 0
            End Try

            Try

                RadTabStripAlertGroups.SelectedIndex = TabIndex
                RadMultiPageAlertGroups.SelectedIndex = TabIndex

                CheckBoxShowInactive.Checked = CBool(ShowInactive)

                ChangeTabs(AlertGroupCode)

            Catch ex As Exception

            End Try

            If RadTabStripAlertGroups.SelectedIndex = 1 Then

                If Action = 1 Then

                    TextBoxAlertGroup.Text = ""

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        UserEmployeeOfficeList = AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode).ToList
                        AvailableEmployeeList = New Generic.List(Of Object)
                        CurrentEmployeeList = New Generic.List(Of Object)

                        For Each Employee In AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(DbContext)

                            If UserEmployeeOfficeList IsNot Nothing AndAlso UserEmployeeOfficeList.Count > 0 Then
                                For Each office In UserEmployeeOfficeList
                                    If office.OfficeCode = Employee.OfficeCode Then
                                        AvailableEmployeeList.Add(New With {.EmployeeCode = Employee.Code, .EmployeeName = Employee.FirstName & " " & Employee.LastName})
                                    End If
                                Next
                            Else
                                AvailableEmployeeList.Add(New With {.EmployeeCode = Employee.Code, .EmployeeName = Employee.FirstName & " " & Employee.LastName})
                            End If

                        Next

                        RadGridAlertGroupAvailableEmployees.DataSource = AvailableEmployeeList.AsQueryable

                        RadGridAlertGroupAvailableEmployees.DataBind()

                        RadGridAlertGroupCurrentEmployees.DataSource = CurrentEmployeeList.AsQueryable

                        RadGridAlertGroupCurrentEmployees.DataBind()

                    End Using

                    TextBoxAlertGroup.Focus()

                End If

            End If

        ElseIf Me.IsPostBack Then

            Try

                If Not Request.QueryString("Action") Is Nothing Then

                    Action = CType(Request.QueryString("Action"), Integer)

                End If

            Catch ex As Exception
                Action = 0
            End Try

        End If

        If RadTabStripAlertGroups.SelectedIndex = 1 Then

            If Action = 1 Then

                TableRowAlertGroupDetailDropDownHeader.Visible = False
                ImageButtonExport.Visible = False
                CheckBoxShowInactive.Visible = False
                TableRowAlertGroupDetailTextBoxHeader.Visible = True
                ImageButtonSaveAlertGroup.Visible = True
                ImageButtonCancelAlertGroup.Visible = True
                ImageButtonSaveCurrentEmployeesDetails.Visible = False

            Else

                TableRowAlertGroupDetailDropDownHeader.Visible = True
                ImageButtonExport.Visible = True
                CheckBoxShowInactive.Visible = True
                TableRowAlertGroupDetailTextBoxHeader.Visible = False
                ImageButtonSaveAlertGroup.Visible = False
                ImageButtonCancelAlertGroup.Visible = False
                ImageButtonSaveCurrentEmployeesDetails.Visible = True

            End If

        End If

    End Sub
    Protected Overrides Sub RaisePostBackEvent(ByVal sourceControl As System.Web.UI.IPostBackEventHandler, ByVal eventArgument As String)

        'objects
        Dim GridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim ShowInactive As Integer = 0

        MyBase.RaisePostBackEvent(sourceControl, eventArgument)

        If sourceControl Is RadGridAlertGroups AndAlso (eventArgument.IndexOf("IndexOfRowDoubleClicked") <> -1) Then

            GridDataItem = RadGridAlertGroups.Items(Integer.Parse(eventArgument.Split(":"c)(1)))

            If GridDataItem IsNot Nothing Then

                If CheckBoxShowInactive.Checked Then

                    ShowInactive = 1

                Else

                    ShowInactive = 0

                End If

                Response.Redirect([String].Format("Maintenance_AlertGroup.aspx?TabIndex={0}&AlertGroupCode={1}&ShowInactive={2}", 1, GridDataItem.GetDataKeyValue("Code"), ShowInactive))

            End If

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub CheckBoxShowInactive_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxShowInactive.CheckedChanged

        'objects
        Dim AlertGroupCode As String = ""

        If RadTabStripAlertGroups.SelectedIndex = 1 AndAlso DropDownListAlertGroups.SelectedValue IsNot Nothing AndAlso DropDownListAlertGroups.SelectedValue.ToString() <> "" Then

            AlertGroupCode = DropDownListAlertGroups.SelectedValue

        End If

        ChangeTabs(AlertGroupCode)

    End Sub
    Private Sub ImageButtonExport_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonExport.Click

        'objects
        Dim GridView As GridView = Nothing
        Dim DataView As DataView = Nothing
        Dim DataTable As DataTable = Nothing
        Dim NewDataRow As DataRow = Nothing
        Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
        Dim [Function] As AdvantageFramework.Database.Entities.Function = Nothing
        Dim Role As AdvantageFramework.Database.Entities.Role = Nothing

        Select Case RadTabStripAlertGroups.SelectedIndex

            Case 0

                DataTable = New DataTable

                DataTable.Columns.Add("Alert Group Code")
                DataTable.Columns.Add("Active")

                RadGridAlertGroups.AllowPaging = False

                LoadAlertGroupsTab()

                For Each GridDataItem In RadGridAlertGroups.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

                    NewDataRow = DataTable.Rows.Add()

                    NewDataRow(0) = GridDataItem.DataItem.Code

                    If GridDataItem.DataItem.IsInactive = False Then

                        NewDataRow(1) = "YES"

                    Else

                        NewDataRow(1) = "NO"

                    End If

                Next

                'DataView = New DataView(DataTable)

                'GridView = New GridView

                'GridView.DataSource = DataView
                'GridView.DataBind()

                'AdvantageFramework.Web.Exporting.ToExcel("Alert Groups.xls", GridView) <--- This doesn' work
                Me.DeliverGrid(DataTable, "Alert Groups") '<--- This does, please don't change unless you test!!!!

                RadGridAlertGroups.AllowPaging = True

                LoadAlertGroupsTab()

            Case 1

                If DropDownListAlertGroups.SelectedValue IsNot Nothing AndAlso DropDownListAlertGroups.SelectedValue.ToString() <> "" Then

                    DataTable = New DataTable

                    DataTable.Columns.Add("Employee Code")
                    DataTable.Columns.Add("Employee Name")
                    DataTable.Columns.Add("Employee Email")
                    DataTable.Columns.Add("Default Role")
                    DataTable.Columns.Add("Default Function")
                    DataTable.Columns.Add("Include On Schedule")

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        For Each AlertGroup In AdvantageFramework.Database.Procedures.AlertGroup.LoadByAlertGroupCode(DbContext, DropDownListAlertGroups.SelectedValue)

                            Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, AlertGroup.EmployeeCode)

                            If Employee IsNot Nothing Then

                                NewDataRow = DataTable.Rows.Add()

                                NewDataRow(0) = Employee.Code

                                NewDataRow(1) = Employee.FirstName & " " & Employee.LastName
                                NewDataRow(2) = Employee.Email

                                Role = AdvantageFramework.Database.Procedures.Role.LoadByRoleCode(DbContext, Employee.RoleCode)

                                If Role IsNot Nothing Then

                                    NewDataRow(3) = Role.Description

                                Else

                                    NewDataRow(3) = ""

                                End If

                                [Function] = AdvantageFramework.Database.Procedures.Function.LoadByFunctionCode(DbContext, Employee.FunctionCode)

                                If [Function] IsNot Nothing Then

                                    NewDataRow(4) = [Function].Description

                                Else

                                    NewDataRow(4) = ""

                                End If

                                If AlertGroup.IncludeOnSchedule.GetValueOrDefault(0) = 1 Then

                                    NewDataRow(5) = "YES"

                                Else

                                    NewDataRow(5) = "NO"

                                End If

                            End If

                        Next

                    End Using

                    'DataView = New DataView(DataTable)

                    'GridView = New GridView

                    'GridView.DataSource = DataView
                    'GridView.DataBind()

                    'AdvantageFramework.Web.Exporting.ToExcel("Alert Group Details.xls", GridView) <--- This doesn' work
                    Me.DeliverGrid(DataTable, "Alert Group Details") '<--- This does, please don't change unless you test!!!!

                End If

        End Select

    End Sub
    Private Sub RadGridAlertGroups_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridAlertGroups.ItemCommand

        'objects
        Dim GridEditableItem As Telerik.Web.UI.GridEditableItem = Nothing
        Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim AlertGroupCode As String = ""

        If e.Item IsNot Nothing AndAlso e.Item.ItemIndex > -1 Then

            CurrentGridDataItem = RadGridAlertGroups.Items(e.Item.ItemIndex)

        End If

        Select Case e.CommandName

            Case "SaveAll"

                For Each GridDataItem In RadGridAlertGroups.MasterTableView.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

                    UpdateAlertGroupOnAlertGroupsTab(GridDataItem)

                Next

            Case "SaveRow"

                If CurrentGridDataItem IsNot Nothing Then

                    UpdateAlertGroupOnAlertGroupsTab(CurrentGridDataItem)

                End If

            Case "DeleteRow"

                If CurrentGridDataItem IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        AlertGroupCode = CurrentGridDataItem.GetDataKeyValue("Code")

                        AdvantageFramework.Database.Procedures.AlertGroup.DeleteAll(DbContext, AlertGroupCode)

                        Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)
                            Try

                                AdvantageFramework.Database.Procedures.SettingValue.DeleteBySettingCodeAndLookupValue(DataContext, AdvantageFramework.Agency.Settings.JR_DFLT_ALERT_GROUP.ToString, AlertGroupCode)

                            Catch ex As Exception

                            End Try
                        End Using


                    End Using

                End If

        End Select

        LoadAlertGroupsGridOnAlertGroupsTab()

    End Sub
    Private Sub DropDownListAlertGroups_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListAlertGroups.SelectedIndexChanged

        If DropDownListAlertGroups.SelectedValue IsNot Nothing AndAlso DropDownListAlertGroups.SelectedValue.ToString() <> "" Then

            LoadAlertGroupDetails()

        Else

            RadGridAlertGroupAvailableEmployees.DataSource = Nothing

            RadGridAlertGroupAvailableEmployees.DataBind()

            RadGridAlertGroupCurrentEmployees.DataSource = Nothing

            RadGridAlertGroupCurrentEmployees.DataBind()

        End If

    End Sub
    Private Sub RadTabStripAlertGroups_TabClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadTabStripEventArgs) Handles RadTabStripAlertGroups.TabClick

        If RadTabStripAlertGroups.SelectedIndex = 0 Then

            If Request.QueryString("Action") IsNot Nothing Then

                MiscFN.ResponseRedirect("Maintenance_AlertGroup.aspx")

            Else

                ChangeTabs("")

            End If

        Else

            ChangeTabs("")

        End If

    End Sub
    Private Sub CheckBoxIsInactive_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxIsInactive.CheckedChanged

        If DropDownListAlertGroups.SelectedValue IsNot Nothing AndAlso DropDownListAlertGroups.SelectedValue.ToString() <> "" AndAlso TableRowAlertGroupDetailDropDownHeader.Visible Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                For Each AlertGroup In AdvantageFramework.Database.Procedures.AlertGroup.LoadByAlertGroupCode(DbContext, DropDownListAlertGroups.SelectedValue).ToList

                    If CheckBoxIsInactive.Checked Then

                        AlertGroup.IsInactive = 1

                    Else

                        AlertGroup.IsInactive = 0

                    End If

                    AdvantageFramework.Database.Procedures.AlertGroup.Update(DbContext, AlertGroup)

                Next

            End Using

            LoadAlertGroupDetailTab(DropDownListAlertGroups.SelectedValue)

        End If

    End Sub
    Private Sub ImageButtonAddNewAlertGroup_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonAddNewAlertGroup.Click

        Response.Redirect([String].Format("Maintenance_AlertGroup.aspx?TabIndex={0}&Action={1}", 1, 1))

    End Sub
    Private Sub ImageButtonCancelAlertGroup_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonCancelAlertGroup.Click

        'objects
        Dim AlertGroupCode As String = ""

        If RadTabStripAlertGroups.SelectedIndex = 1 AndAlso DropDownListAlertGroups.SelectedValue IsNot Nothing AndAlso DropDownListAlertGroups.SelectedValue.ToString() <> "" Then

            AlertGroupCode = DropDownListAlertGroups.SelectedValue

        End If

        Response.Redirect([String].Format("Maintenance_AlertGroup.aspx?TabIndex={0}&AlertGroupCode={1}", 1, AlertGroupCode))

    End Sub
    Private Sub ImageButtonSaveAlertGroup_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonSaveAlertGroup.Click

        'objects
        Dim AlertGroup As AdvantageFramework.Database.Entities.AlertGroup = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            TextBoxAlertGroup.Text = TextBoxAlertGroup.Text.Trim()

            If (From Entity In DbContext.AlertGroups
                Where Entity.Code.ToUpper = TextBoxAlertGroup.Text.ToUpper
                Select Entity).Any = False Then

                If RadGridAlertGroupCurrentEmployees.Items.Count > 0 Then

                    For Each GridDataItem In RadGridAlertGroupCurrentEmployees.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

                        AlertGroup = New AdvantageFramework.Database.Entities.AlertGroup

                        AlertGroup.Code = TextBoxAlertGroup.Text
                        AlertGroup.EmployeeCode = GridDataItem.GetDataKeyValue("EmployeeCode")

                        If CheckBoxIsInactive.Checked Then

                            AlertGroup.IsInactive = 1

                        Else

                            AlertGroup.IsInactive = 0

                        End If

                        Try

                            If GridDataItem.FindControl("CheckBoxIncludeOnSchedule") IsNot Nothing Then

                                If DirectCast(GridDataItem.FindControl("CheckBoxIncludeOnSchedule"), CheckBox).Checked Then

                                    AlertGroup.IncludeOnSchedule = 1

                                Else

                                    AlertGroup.IncludeOnSchedule = 0

                                End If

                            End If

                        Catch ex As Exception
                            AlertGroup.IncludeOnSchedule = 0
                        End Try

                        AdvantageFramework.Database.Procedures.AlertGroup.Insert(DbContext, AlertGroup)

                    Next

                    DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO dbo.ALERT_GROUP([E_GROUP], [ALERT_CAT_ID], [ACTIVE_FLAG]) " &
                                                                    "SELECT '{0}', ALERT_CAT_ID, 1 FROM dbo.ALERT_CATEGORY", AlertGroup.Code))

                    If CheckBoxIsInactive.Checked = False Then
                        Dim SettingValue As AdvantageFramework.Database.Entities.SettingValue = Nothing
                        Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)
                            SettingValue = New AdvantageFramework.Database.Entities.SettingValue

                            SettingValue.DataContext = DataContext

                            SettingValue.SettingCode = AdvantageFramework.Agency.Settings.JR_DFLT_ALERT_GROUP.ToString
                            SettingValue.DisplayText = TextBoxAlertGroup.Text
                            SettingValue.Value = TextBoxAlertGroup.Text

                            AdvantageFramework.Database.Procedures.SettingValue.Insert(DataContext, SettingValue)
                        End Using
                    End If

                    Response.Redirect([String].Format("Maintenance_AlertGroup.aspx?TabIndex={0}&AlertGroupCode={1}", 1, TextBoxAlertGroup.Text))

                Else

                    Me.ShowMessage("You must add at least one employee to the alert group before saving.")
                End If

            Else

                Me.ShowMessage("Please enter a unique alert group code.")

            End If

        End Using

    End Sub
    Private Sub RadGridAlertGroups_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridAlertGroups.ItemDataBound

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
    Private Sub ImageButtonAddEmployee_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonAddEmployee.Click

        'objects
        Dim AlertGroup As AdvantageFramework.Database.Entities.AlertGroup = Nothing
        Dim AvailableEmployeeList As Generic.List(Of Object) = Nothing
        Dim CurrentEmployeeList As Generic.List(Of Object) = Nothing
        Dim Role As AdvantageFramework.Database.Entities.Role = Nothing
        Dim [Function] As AdvantageFramework.Database.Entities.Function = Nothing
        Dim DefaultRoleDescription As String = ""
        Dim DefaultFunctionDescription As String = ""
        Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
        Dim AvailableEmployee As Object = Nothing
        Dim UserEmployeeOfficeList As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeOffice) = Nothing

        If RadGridAlertGroupAvailableEmployees.SelectedItems.Count > 0 Then

            If TableRowAlertGroupDetailDropDownHeader.Visible Then

                If DropDownListAlertGroups.SelectedValue IsNot Nothing AndAlso DropDownListAlertGroups.SelectedValue.ToString() <> "" Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        For Each GridDataItem In RadGridAlertGroupAvailableEmployees.SelectedItems.OfType(Of Telerik.Web.UI.GridDataItem)()

                            AlertGroup = New AdvantageFramework.Database.Entities.AlertGroup

                            AlertGroup.Code = DropDownListAlertGroups.SelectedValue
                            AlertGroup.EmployeeCode = GridDataItem.GetDataKeyValue("EmployeeCode")

                            If CheckBoxIsInactive.Checked Then

                                AlertGroup.IsInactive = 1

                            Else

                                AlertGroup.IsInactive = 0

                            End If

                            AlertGroup.IncludeOnSchedule = 0

                            AdvantageFramework.Database.Procedures.AlertGroup.Insert(DbContext, AlertGroup)

                        Next

                    End Using

                    LoadAlertGroupDetails()

                End If

            Else

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    AvailableEmployeeList = New Generic.List(Of Object)
                    CurrentEmployeeList = New Generic.List(Of Object)
                    UserEmployeeOfficeList = AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode).ToList

                    For Each Employee In AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(DbContext)

                        If UserEmployeeOfficeList IsNot Nothing AndAlso UserEmployeeOfficeList.Count > 0 Then
                            For Each office In UserEmployeeOfficeList
                                If office.OfficeCode = Employee.OfficeCode Then
                                    AvailableEmployeeList.Add(New With {.EmployeeCode = Employee.Code, .EmployeeName = Employee.FirstName & " " & Employee.LastName})
                                End If
                            Next
                        Else
                            AvailableEmployeeList.Add(New With {.EmployeeCode = Employee.Code, .EmployeeName = Employee.FirstName & " " & Employee.LastName})
                        End If

                    Next

                    For Each GridDataItem In RadGridAlertGroupCurrentEmployees.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, GridDataItem.GetDataKeyValue("EmployeeCode"))

                        If Employee IsNot Nothing Then

                            Role = AdvantageFramework.Database.Procedures.Role.LoadByRoleCode(DbContext, Employee.RoleCode)

                            If Role IsNot Nothing Then

                                DefaultRoleDescription = Role.Description

                            Else

                                DefaultRoleDescription = ""

                            End If

                            [Function] = AdvantageFramework.Database.Procedures.Function.LoadByFunctionCode(DbContext, Employee.FunctionCode)

                            If [Function] IsNot Nothing Then

                                DefaultFunctionDescription = [Function].Description

                            Else

                                DefaultFunctionDescription = ""

                            End If

                            CurrentEmployeeList.Add(New With {.IncludeOnSchedule = 0, .EmployeeCode = Employee.Code, .EmployeeName = Employee.FirstName & " " & Employee.LastName, .Email = Employee.Email, .DefaultFunction = DefaultFunctionDescription, .DefaultRole = DefaultRoleDescription})

                            AvailableEmployee = Nothing

                            For Each AvailableEmployee In AvailableEmployeeList

                                If AvailableEmployee.EmployeeCode = Employee.Code Then

                                    Exit For

                                End If

                            Next

                            If AvailableEmployee IsNot Nothing Then

                                AvailableEmployeeList.Remove(AvailableEmployee)

                            End If

                        End If

                    Next

                    For Each GridDataItem In RadGridAlertGroupAvailableEmployees.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

                        If GridDataItem.Selected Then

                            Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, GridDataItem.GetDataKeyValue("EmployeeCode"))

                            If Employee IsNot Nothing Then

                                Role = AdvantageFramework.Database.Procedures.Role.LoadByRoleCode(DbContext, Employee.RoleCode)

                                If Role IsNot Nothing Then

                                    DefaultRoleDescription = Role.Description

                                Else

                                    DefaultRoleDescription = ""

                                End If

                                [Function] = AdvantageFramework.Database.Procedures.Function.LoadByFunctionCode(DbContext, Employee.FunctionCode)

                                If [Function] IsNot Nothing Then

                                    DefaultFunctionDescription = [Function].Description

                                Else

                                    DefaultFunctionDescription = ""

                                End If

                                CurrentEmployeeList.Add(New With {.IncludeOnSchedule = 0, .EmployeeCode = Employee.Code, .EmployeeName = Employee.FirstName & " " & Employee.LastName, .Email = Employee.Email, .DefaultFunction = DefaultFunctionDescription, .DefaultRole = DefaultRoleDescription})

                                AvailableEmployee = Nothing

                                For Each AvailableEmployee In AvailableEmployeeList

                                    If AvailableEmployee.EmployeeCode = Employee.Code Then

                                        Exit For

                                    End If

                                Next

                                If AvailableEmployee IsNot Nothing Then

                                    AvailableEmployeeList.Remove(AvailableEmployee)

                                End If

                            End If

                        End If

                    Next

                    RadGridAlertGroupAvailableEmployees.DataSource = AvailableEmployeeList.AsQueryable

                    RadGridAlertGroupAvailableEmployees.DataBind()

                    RadGridAlertGroupCurrentEmployees.DataSource = CurrentEmployeeList.AsQueryable

                    RadGridAlertGroupCurrentEmployees.DataBind()

                End Using

            End If

        End If

    End Sub
    Private Sub ImageButtonRemoveEmployee_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonRemoveEmployee.Click

        'objects
        Dim AlertGroup As AdvantageFramework.Database.Entities.AlertGroup = Nothing
        Dim AvailableEmployeeList As Generic.List(Of Object) = Nothing
        Dim CurrentEmployeeList As Generic.List(Of Object) = Nothing
        Dim AvailableEmployee As Object = Nothing
        Dim UserEmployeeOfficeList As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeOffice) = Nothing

        If RadGridAlertGroupCurrentEmployees.SelectedItems.Count > 0 Then

            If TableRowAlertGroupDetailDropDownHeader.Visible Then

                If DropDownListAlertGroups.SelectedValue IsNot Nothing AndAlso DropDownListAlertGroups.SelectedValue.ToString() <> "" Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        For Each GridDataItem In RadGridAlertGroupCurrentEmployees.SelectedItems.OfType(Of Telerik.Web.UI.GridDataItem)()

                            AlertGroup = AdvantageFramework.Database.Procedures.AlertGroup.LoadByAlertGroupCodeAndEmployeeCode(DbContext, DropDownListAlertGroups.SelectedValue, GridDataItem.GetDataKeyValue("EmployeeCode"))

                            If AlertGroup IsNot Nothing Then

                                AdvantageFramework.Database.Procedures.AlertGroup.Delete(DbContext, AlertGroup)

                            End If

                        Next

                    End Using

                    LoadAlertGroupDetails()

                End If

            Else

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    AvailableEmployeeList = New Generic.List(Of Object)
                    CurrentEmployeeList = New Generic.List(Of Object)
                    UserEmployeeOfficeList = AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode).ToList

                    For Each Employee In AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(DbContext)

                        If UserEmployeeOfficeList IsNot Nothing AndAlso UserEmployeeOfficeList.Count > 0 Then
                            For Each office In UserEmployeeOfficeList
                                If office.OfficeCode = Employee.OfficeCode Then
                                    AvailableEmployeeList.Add(New With {.EmployeeCode = Employee.Code, .EmployeeName = Employee.FirstName & " " & Employee.LastName})
                                End If
                            Next
                        Else
                            AvailableEmployeeList.Add(New With {.EmployeeCode = Employee.Code, .EmployeeName = Employee.FirstName & " " & Employee.LastName})
                        End If

                    Next

                    For Each GridDataItem In RadGridAlertGroupCurrentEmployees.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

                        If GridDataItem.Selected = False Then

                            CurrentEmployeeList.Add(New With {.IncludeOnSchedule = GridDataItem.GetDataKeyValue("IncludeOnSchedule"), .EmployeeCode = GridDataItem.GetDataKeyValue("EmployeeCode"), .EmployeeName = GridDataItem.GetDataKeyValue("EmployeeName"), .Email = GridDataItem.GetDataKeyValue("Email"), .DefaultFunction = GridDataItem.GetDataKeyValue("DefaultFunction"), .DefaultRole = GridDataItem.GetDataKeyValue("DefaultRole")})

                            AvailableEmployee = Nothing

                            For Each AvailableEmployee In AvailableEmployeeList

                                If AvailableEmployee.EmployeeCode = GridDataItem.GetDataKeyValue("EmployeeCode") Then

                                    Exit For

                                End If

                            Next

                            If AvailableEmployee IsNot Nothing Then

                                AvailableEmployeeList.Remove(AvailableEmployee)

                            End If

                        End If

                    Next

                    RadGridAlertGroupAvailableEmployees.DataSource = AvailableEmployeeList.AsQueryable

                    RadGridAlertGroupAvailableEmployees.DataBind()

                    RadGridAlertGroupCurrentEmployees.DataSource = CurrentEmployeeList.AsQueryable

                    RadGridAlertGroupCurrentEmployees.DataBind()

                End Using

            End If

        End If

    End Sub
    Private Sub ImageButtonSaveCurrentEmployeesDetails_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonSaveCurrentEmployeesDetails.Click

        'objects
        Dim AlertGroup As AdvantageFramework.Database.Entities.AlertGroup = Nothing
        Dim GridDataItem As Telerik.Web.UI.GridDataItem = Nothing

        Try

            If DropDownListAlertGroups.SelectedValue IsNot Nothing AndAlso DropDownListAlertGroups.SelectedValue.ToString() <> "" AndAlso TableRowAlertGroupDetailDropDownHeader.Visible Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    For Each GridDataItem In RadGridAlertGroupCurrentEmployees.MasterTableView.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

                        AlertGroup = AdvantageFramework.Database.Procedures.AlertGroup.LoadByAlertGroupCodeAndEmployeeCode(DbContext, DropDownListAlertGroups.SelectedValue, GridDataItem.GetDataKeyValue("EmployeeCode"))

                        If AlertGroup IsNot Nothing Then

                            If CType(GridDataItem.FindControl("CheckBoxIncludeOnSchedule"), CheckBox).Checked Then

                                AlertGroup.IncludeOnSchedule = 1

                            Else

                                AlertGroup.IncludeOnSchedule = 0

                            End If

                            AdvantageFramework.Database.Procedures.AlertGroup.Update(DbContext, AlertGroup)

                        End If

                    Next

                End Using

                LoadAlertGroupDetails()

            End If

        Catch ex As Exception

        End Try

    End Sub

#End Region

#End Region

End Class
