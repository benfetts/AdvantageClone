Public Class Maintenance_Role
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
    Private Property CurrentGridPageIndex As Integer = 0
    Private Property CurrentPageNumber As Integer = 0

#End Region

#Region " Methods "

    Private Function LoadRoles(ByRef DbContext As AdvantageFramework.Database.DbContext, ByVal OrderByDescription As Boolean) As Generic.IEnumerable(Of Object)

        'objects
        Dim Roles As Generic.IEnumerable(Of Object) = Nothing

        If CheckBoxShowInactive.Checked Then

            Roles = From Role In AdvantageFramework.Database.Procedures.Role.Load(DbContext)
                    Select Role.Code,
                        Role.Description,
                        [IsInactive] = CBool(Role.IsInactive)
                    Distinct

        Else

            Roles = From Role In AdvantageFramework.Database.Procedures.Role.LoadAllActive(DbContext)
                    Select Role.Code,
                        Role.Description,
                        [IsInactive] = CBool(Role.IsInactive)
                    Distinct

        End If

        If OrderByDescription Then

            Roles = Roles.OrderBy(Function(Role) Role.Description)

        End If

        LoadRoles = Roles

    End Function
    Private Sub LoadRolesTab()

        Me.RadGridRoles.Rebind()

    End Sub
    Private Sub LoadRoleDetailTab(ByVal RoleCode As String)

        'objects
        Dim Role As AdvantageFramework.Database.Entities.Role = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            DropDownListRoles.DataSource = LoadRoles(DbContext, True)

            DropDownListRoles.DataBind()

            DropDownListRoles.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

        End Using

        Try

            If RoleCode <> "" Then

                DropDownListRoles.SelectedValue = RoleCode

            End If

        Catch ex As Exception

            If DropDownListRoles.Items.Count > 0 Then

                DropDownListRoles.SelectedIndex = 0

            End If

        End Try

        If DropDownListRoles.SelectedValue IsNot Nothing AndAlso DropDownListRoles.SelectedValue.ToString() <> "" Then

            LoadRoleDetails()

        Else

            CheckBoxIsInactive.Checked = False

            RadListBoxAvailableEmployees.DataSource = Nothing
            RadListBoxAvailableEmployees.DataBind()

            RadListBoxCurrentEmployees.DataSource = Nothing
            RadListBoxCurrentEmployees.DataBind()

            RadListBoxAvailableTasks.DataSource = Nothing
            RadListBoxAvailableTasks.DataBind()

            RadListBoxCurrentTasks.DataSource = Nothing
            RadListBoxCurrentTasks.DataBind()

        End If

    End Sub
    Private Sub UpdateRoleOnRolesTab(ByRef GridDataItem As Telerik.Web.UI.GridDataItem)

        'objects
        Dim Role As AdvantageFramework.Database.Entities.Role = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Role = AdvantageFramework.Database.Procedures.Role.LoadByRoleCode(DbContext, GridDataItem.GetDataKeyValue("Code").ToString())

            If Role IsNot Nothing Then

                Role.Description = CType(GridDataItem.FindControl("TextBoxRoleDescription"), TextBox).Text.Trim

                If DirectCast(GridDataItem.FindControl("CheckBoxIsInactive"), CheckBox).Checked Then

                    Role.IsInactive = 1

                Else

                    Role.IsInactive = 0

                End If

                AdvantageFramework.Database.Procedures.Role.Update(DbContext, Role)

            End If

        End Using

    End Sub
    Private Sub LoadRoleDetails()

        'objects
        Dim RoleCode As String = ""
        Dim CurrentEmployeesList As Generic.List(Of Object) = Nothing
        Dim AvailableEmployeesList As Generic.List(Of Object) = Nothing
        Dim EmployeeRolesList As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeRole) = Nothing
        Dim CurrentTasksList As Generic.List(Of Object) = Nothing
        Dim AvailableTasksList As Generic.List(Of Object) = Nothing
        Dim TaskRolesList As Generic.List(Of AdvantageFramework.Database.Entities.TaskRole) = Nothing
        Dim Role As AdvantageFramework.Database.Entities.Role = Nothing
        Dim UserEmployeeOfficeList As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeOffice) = Nothing
        Dim Employees As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.Employee) = Nothing
        Dim EmployeeName As String = ""

        If DropDownListRoles.SelectedValue IsNot Nothing AndAlso DropDownListRoles.SelectedValue.ToString() <> "" Then

            RoleCode = DropDownListRoles.SelectedValue

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                UserEmployeeOfficeList = AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode).ToList

                Using DataContext = New AdvantageFramework.Database.DataContext(Session("ConnString").ToString(), Session("UserCode").ToString())

                    Role = AdvantageFramework.Database.Procedures.Role.LoadByRoleCode(DbContext, RoleCode)

                    CurrentEmployeesList = New Generic.List(Of Object)
                    AvailableEmployeesList = New Generic.List(Of Object)

                    CurrentTasksList = New Generic.List(Of Object)
                    AvailableTasksList = New Generic.List(Of Object)

                    If Role IsNot Nothing Then

                        If Role.IsInactive = 1 Then

                            CheckBoxIsInactive.Checked = True

                        Else

                            CheckBoxIsInactive.Checked = False

                        End If

                        EmployeeRolesList = AdvantageFramework.Database.Procedures.EmployeeRole.LoadByRoleCode(DbContext, RoleCode).ToList

                        If UserEmployeeOfficeList IsNot Nothing AndAlso UserEmployeeOfficeList.Count > 0 Then

                            For Each Employee In (From Entity In AdvantageFramework.Database.Procedures.EmployeeView.Load(DbContext)
                                                  Join EmpOffice In AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode) On Entity.OfficeCode Equals EmpOffice.OfficeCode
                                                  Select Entity
                                                  Order By Entity.FirstName,
                                                       Entity.MiddleInitial,
                                                       Entity.LastName)

                                If Employee.MiddleInitial Is Nothing OrElse Employee.MiddleInitial.Trim = "" Then

                                    EmployeeName = Employee.FirstName & " " & Employee.LastName

                                Else

                                    EmployeeName = Employee.FirstName & " " & Employee.MiddleInitial & ". " & Employee.LastName

                                End If

                                If (From EmployeeRole In EmployeeRolesList.AsQueryable
                                    Where EmployeeRole.EmployeeCode = Employee.Code
                                    Select EmployeeRole).Any Then

                                    If Employee.TerminationDate Is Nothing Then

                                        CurrentEmployeesList.Add(New With {.EmployeeCode = Employee.Code, .EmployeeName = EmployeeName})

                                    Else

                                        CurrentEmployeesList.Add(New With {.EmployeeCode = Employee.Code, .EmployeeName = EmployeeName & "*"})

                                    End If

                                Else

                                    If Employee.TerminationDate Is Nothing Then

                                        AvailableEmployeesList.Add(New With {.EmployeeCode = Employee.Code, .EmployeeName = EmployeeName})

                                    End If

                                End If

                            Next

                        Else

                            For Each Employee In (From Entity In AdvantageFramework.Database.Procedures.EmployeeView.Load(DbContext)
                                                  Select Entity
                                                  Order By Entity.FirstName,
                                                       Entity.MiddleInitial,
                                                       Entity.LastName)

                                If Employee.MiddleInitial Is Nothing OrElse Employee.MiddleInitial.Trim = "" Then

                                    EmployeeName = Employee.FirstName & " " & Employee.LastName

                                Else

                                    EmployeeName = Employee.FirstName & " " & Employee.MiddleInitial & ". " & Employee.LastName

                                End If

                                If (From EmployeeRole In EmployeeRolesList.AsQueryable
                                    Where EmployeeRole.EmployeeCode = Employee.Code
                                    Select EmployeeRole).Any Then

                                    If Employee.TerminationDate Is Nothing Then

                                        CurrentEmployeesList.Add(New With {.EmployeeCode = Employee.Code, .EmployeeName = EmployeeName})

                                    Else

                                        CurrentEmployeesList.Add(New With {.EmployeeCode = Employee.Code, .EmployeeName = EmployeeName & "*"})

                                    End If

                                Else

                                    If Employee.TerminationDate Is Nothing Then

                                        AvailableEmployeesList.Add(New With {.EmployeeCode = Employee.Code, .EmployeeName = EmployeeName})

                                    End If

                                End If

                            Next

                        End If

                        TaskRolesList = AdvantageFramework.Database.Procedures.TaskRole.LoadByRoleCode(DataContext, RoleCode).ToList

                        For Each Task In (From Entity In AdvantageFramework.Database.Procedures.Task.Load(DbContext)
                                          Select Entity
                                          Order By Entity.Description)

                            If (From TaskRole In TaskRolesList.AsQueryable
                                Where TaskRole.TaskCode = Task.Code
                                Select TaskRole).Any Then

                                If Task.IsInactive.GetValueOrDefault(0) = 0 Then

                                    CurrentTasksList.Add(New With {.TaskCode = Task.Code, .TaskDescription = Task.Description})

                                Else

                                    CurrentTasksList.Add(New With {.TaskCode = Task.Code, .TaskDescription = Task.Description & "*"})

                                End If

                            Else

                                If Task.IsInactive.GetValueOrDefault(0) = 0 Then

                                    AvailableTasksList.Add(New With {.TaskCode = Task.Code, .TaskDescription = Task.Description})

                                End If

                            End If

                        Next

                    End If

                    RadListBoxAvailableEmployees.DataSource = AvailableEmployeesList.AsQueryable
                    RadListBoxAvailableEmployees.DataBind()

                    RadListBoxCurrentEmployees.DataSource = CurrentEmployeesList.AsQueryable
                    RadListBoxCurrentEmployees.DataBind()

                    RadListBoxAvailableTasks.DataSource = AvailableTasksList.AsQueryable
                    RadListBoxAvailableTasks.DataBind()

                    RadListBoxCurrentTasks.DataSource = CurrentTasksList.AsQueryable
                    RadListBoxCurrentTasks.DataBind()

                End Using

            End Using

        End If

    End Sub
    Private Sub ChangeTabs(ByVal RoleCode As String)

        Select Case RadTabStripRoles.SelectedIndex

            Case 0

                LoadRolesTab()

            Case 1

                LoadRoleDetailTab(RoleCode)

        End Select

    End Sub

#Region "  Form Event Handlers "

    Private Sub Maintenance_Role_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.PageTitle = "Role Maintenance"
        'objects
        Dim TabIndex As Integer = 0
        Dim RoleCode As String = ""



        If Not Me.IsPostBack And Not Me.IsCallback Then

            Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Maintenance_ProjectSchedule_Role)

            Try

                If Not Request.QueryString("TabIndex") Is Nothing Then

                    TabIndex = CType(Request.QueryString("TabIndex"), Integer)

                End If

                If Not Request.QueryString("RoleCode") Is Nothing Then

                    RoleCode = CType(Request.QueryString("RoleCode"), String)

                End If

            Catch ex As Exception
                TabIndex = 0
                RoleCode = ""
            End Try

            Try

                RadTabStripRoles.SelectedIndex = TabIndex
                RadMultiPageRoles.SelectedIndex = TabIndex

                ChangeTabs(RoleCode)

            Catch ex As Exception

            End Try

        End If

    End Sub
    Protected Overrides Sub RaisePostBackEvent(ByVal sourceControl As System.Web.UI.IPostBackEventHandler, ByVal eventArgument As String)

        'objects
        Dim GridDataItem As Telerik.Web.UI.GridDataItem = Nothing

        MyBase.RaisePostBackEvent(sourceControl, eventArgument)

        If sourceControl Is RadGridRoles AndAlso (eventArgument.IndexOf("IndexOfRowDoubleClicked") <> -1) Then

            GridDataItem = RadGridRoles.Items(Integer.Parse(eventArgument.Split(":"c)(1)))

            If GridDataItem IsNot Nothing Then

                Response.Redirect([String].Format("Maintenance_Role.aspx?TabIndex={0}&RoleCode={1}", 1, GridDataItem.GetDataKeyValue("Code")))

            End If

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub CheckBoxShowInactive_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxShowInactive.CheckedChanged

        'objects
        Dim RoleCode As String = ""

        If RadTabStripRoles.SelectedIndex = 1 AndAlso DropDownListRoles.SelectedValue IsNot Nothing AndAlso DropDownListRoles.SelectedValue.ToString() <> "" Then

            RoleCode = DropDownListRoles.SelectedValue

        End If

        ChangeTabs(RoleCode)

    End Sub
    Private Sub ImageButtonExport_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonExport.Click

        'objects
        Dim GridView As GridView = Nothing
        Dim DataView As DataView = Nothing
        Dim DataTable As DataTable = Nothing
        Dim NewDataRow As DataRow = Nothing
        Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
        Dim Task As AdvantageFramework.Database.Entities.Task = Nothing
        Dim Role As AdvantageFramework.Database.Entities.Role = Nothing

        Select Case RadTabStripRoles.SelectedIndex

            Case 0

                DataTable = New DataTable

                DataTable.Columns.Add("Code")
                DataTable.Columns.Add("Description")
                DataTable.Columns.Add("Active")

                RadGridRoles.AllowPaging = False

                LoadRolesTab()

                For Each GridDataItem In RadGridRoles.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

                    NewDataRow = DataTable.Rows.Add()

                    NewDataRow(0) = GridDataItem.DataItem.Code

                    NewDataRow(1) = GridDataItem.DataItem.Description

                    If GridDataItem.DataItem.IsInactive = False Then

                        NewDataRow(2) = "YES"

                    Else

                        NewDataRow(2) = "NO"

                    End If

                Next

                'DataView = New DataView(DataTable)

                'GridView = New GridView

                'GridView.DataSource = DataView
                'GridView.DataBind()

                'AdvantageFramework.Web.Exporting.ToExcel("Roles.xls", GridView)  <--- This doesn' work
                Me.DeliverGrid(DataTable, "Roles") '<--- This does, please don't change unless you test!!!!

                RadGridRoles.AllowPaging = True

                LoadRolesTab()

            Case 1

                If DropDownListRoles.SelectedValue IsNot Nothing AndAlso DropDownListRoles.SelectedValue.ToString() <> "" Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                            Role = AdvantageFramework.Database.Procedures.Role.LoadByRoleCode(DbContext, DropDownListRoles.SelectedValue)

                            If Role IsNot Nothing Then

                                DataTable = New DataTable

                                DataTable.Columns.Add("Task\Employee")
                                DataTable.Columns.Add("Code")
                                DataTable.Columns.Add("Description\Name")

                                NewDataRow = DataTable.Rows.Add()

                                NewDataRow(0) = "Role: " & DropDownListRoles.SelectedItem.Text

                                If Role.IsInactive = 1 Then

                                    NewDataRow(1) = "Active:  NO"

                                Else

                                    NewDataRow(1) = "Active:  YES"

                                End If

                                NewDataRow(2) = ""

                                NewDataRow = DataTable.Rows.Add()

                                NewDataRow(0) = ""
                                NewDataRow(1) = ""
                                NewDataRow(2) = ""

                                NewDataRow = DataTable.Rows.Add()

                                NewDataRow(0) = "Tasks"
                                NewDataRow(1) = ""
                                NewDataRow(2) = ""

                                For Each TaskRole In AdvantageFramework.Database.Procedures.TaskRole.LoadByRoleCode(DataContext, DropDownListRoles.SelectedValue)

                                    Task = AdvantageFramework.Database.Procedures.Task.LoadByTaskCode(DbContext, TaskRole.TaskCode)

                                    NewDataRow = DataTable.Rows.Add()

                                    NewDataRow(0) = ""
                                    NewDataRow(1) = TaskRole.TaskCode

                                    If Task IsNot Nothing Then

                                        NewDataRow(2) = Task.Description

                                    End If

                                Next

                                NewDataRow = DataTable.Rows.Add()

                                NewDataRow(0) = "Employees"
                                NewDataRow(1) = ""
                                NewDataRow(2) = ""

                                For Each EmployeeRole In AdvantageFramework.Database.Procedures.EmployeeRole.LoadByRoleCode(DbContext, DropDownListRoles.SelectedValue)

                                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeRole.EmployeeCode)

                                    NewDataRow = DataTable.Rows.Add()

                                    NewDataRow(0) = ""
                                    NewDataRow(1) = EmployeeRole.EmployeeCode

                                    If Employee IsNot Nothing Then

                                        If Employee.MiddleInitial Is Nothing OrElse Employee.MiddleInitial.Trim = "" Then

                                            NewDataRow(2) = Employee.FirstName & " " & Employee.LastName

                                        Else

                                            NewDataRow(2) = Employee.FirstName & " " & Employee.MiddleInitial & ". " & Employee.LastName

                                        End If

                                    End If

                                Next


                                'DataView = New DataView(DataTable)

                                'GridView = New GridView

                                'GridView.DataSource = DataView
                                'GridView.DataBind()

                                'AdvantageFramework.Web.Exporting.ToExcel("Role Details.xls", GridView)  <--- This doesn' work
                                Me.DeliverGrid(DataTable, "Role Details") '<--- This does, please don't change unless you test!!!!

                            End If

                        End Using

                    End Using

                End If

        End Select

    End Sub
    Private Sub DropDownListRoles_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListRoles.SelectedIndexChanged

        If DropDownListRoles.SelectedValue IsNot Nothing AndAlso DropDownListRoles.SelectedValue.ToString() <> "" Then

            LoadRoleDetails()

        Else

            CheckBoxIsInactive.Checked = False

            RadListBoxAvailableEmployees.DataSource = Nothing
            RadListBoxAvailableEmployees.DataBind()

            RadListBoxCurrentEmployees.DataSource = Nothing
            RadListBoxCurrentEmployees.DataBind()

            RadListBoxAvailableTasks.DataSource = Nothing
            RadListBoxAvailableTasks.DataBind()

            RadListBoxCurrentTasks.DataSource = Nothing
            RadListBoxCurrentTasks.DataBind()

        End If

    End Sub
    Private Sub RadTabStripRoles_TabClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadTabStripEventArgs) Handles RadTabStripRoles.TabClick

        ChangeTabs("")

    End Sub
    Private Sub RadListBoxCurrentEmployees_Dropped(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadListBoxDroppedEventArgs) Handles RadListBoxCurrentEmployees.Dropped

        'objects
        Dim EmployeeRolesList As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeRole) = Nothing
        Dim EmployeeRole As AdvantageFramework.Database.Entities.EmployeeRole = Nothing

        If DropDownListRoles.SelectedValue IsNot Nothing AndAlso DropDownListRoles.SelectedValue.ToString() <> "" Then

            If e.HtmlElementID = RadListBoxAvailableEmployees.ClientID Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    EmployeeRolesList = AdvantageFramework.Database.Procedures.EmployeeRole.LoadByRoleCode(DbContext, DropDownListRoles.SelectedValue).ToList

                    For Each ListBoxItem In e.SourceDragItems.OfType(Of Telerik.Web.UI.RadListBoxItem)()

                        Try

                            EmployeeRole = (From Entity In EmployeeRolesList.AsQueryable
                                            Where Entity.EmployeeCode = ListBoxItem.Value
                                            Select Entity).Single

                        Catch ex As Exception
                            EmployeeRole = Nothing
                        End Try

                        If EmployeeRole IsNot Nothing Then

                            AdvantageFramework.Database.Procedures.EmployeeRole.Delete(DbContext, EmployeeRole)

                        End If

                    Next

                End Using

                LoadRoleDetails()

            End If

        End If

    End Sub
    Private Sub RadListBoxCurrentEmployees_Inserted(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadListBoxEventArgs) Handles RadListBoxCurrentEmployees.Inserted

        'objects
        Dim EmployeeRole As AdvantageFramework.Database.Entities.EmployeeRole = Nothing

        If DropDownListRoles.SelectedValue IsNot Nothing AndAlso DropDownListRoles.SelectedValue.ToString() <> "" Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                For Each ListBoxItem In e.Items.OfType(Of Telerik.Web.UI.RadListBoxItem)()

                    EmployeeRole = New AdvantageFramework.Database.Entities.EmployeeRole

                    EmployeeRole.EmployeeCode = ListBoxItem.Value
                    EmployeeRole.RoleCode = DropDownListRoles.SelectedValue

                    AdvantageFramework.Database.Procedures.EmployeeRole.Insert(DbContext, EmployeeRole)

                Next

            End Using

            LoadRoleDetails()

        End If

    End Sub
    Private Sub RadListBoxAvailableEmployees_Dropped(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadListBoxDroppedEventArgs) Handles RadListBoxAvailableEmployees.Dropped

        'objects
        Dim EmployeeRole As AdvantageFramework.Database.Entities.EmployeeRole = Nothing

        If DropDownListRoles.SelectedValue IsNot Nothing AndAlso DropDownListRoles.SelectedValue.ToString() <> "" Then

            If e.HtmlElementID = RadListBoxCurrentEmployees.ClientID Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    For Each ListBoxItem In e.SourceDragItems.OfType(Of Telerik.Web.UI.RadListBoxItem)()

                        EmployeeRole = New AdvantageFramework.Database.Entities.EmployeeRole

                        EmployeeRole.EmployeeCode = ListBoxItem.Value
                        EmployeeRole.RoleCode = DropDownListRoles.SelectedValue

                        AdvantageFramework.Database.Procedures.EmployeeRole.Insert(DbContext, EmployeeRole)

                    Next

                End Using

            End If

            LoadRoleDetails()

        End If

    End Sub
    Private Sub RadListBoxAvailableEmployees_Inserted(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadListBoxEventArgs) Handles RadListBoxAvailableEmployees.Inserted

        'objects
        Dim EmployeeRolesList As Generic.List(Of AdvantageFramework.Database.Entities.EmployeeRole) = Nothing
        Dim EmployeeRole As AdvantageFramework.Database.Entities.EmployeeRole = Nothing

        If DropDownListRoles.SelectedValue IsNot Nothing AndAlso DropDownListRoles.SelectedValue.ToString() <> "" Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                EmployeeRolesList = AdvantageFramework.Database.Procedures.EmployeeRole.LoadByRoleCode(DbContext, DropDownListRoles.SelectedValue).ToList

                For Each ListBoxItem In e.Items.OfType(Of Telerik.Web.UI.RadListBoxItem)()

                    Try

                        EmployeeRole = (From Entity In EmployeeRolesList.AsQueryable
                                        Where Entity.EmployeeCode = ListBoxItem.Value
                                        Select Entity).Single

                    Catch ex As Exception
                        EmployeeRole = Nothing
                    End Try

                    If EmployeeRole IsNot Nothing Then

                        AdvantageFramework.Database.Procedures.EmployeeRole.Delete(DbContext, EmployeeRole)

                    End If

                Next

            End Using

            LoadRoleDetails()

        End If

    End Sub
    Private Sub RadListBoxCurrentTasks_Dropped(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadListBoxDroppedEventArgs) Handles RadListBoxCurrentTasks.Dropped

        'objects
        Dim TaskRolesList As Generic.List(Of AdvantageFramework.Database.Entities.TaskRole) = Nothing
        Dim TaskRole As AdvantageFramework.Database.Entities.TaskRole = Nothing

        If DropDownListRoles.SelectedValue IsNot Nothing AndAlso DropDownListRoles.SelectedValue.ToString() <> "" Then

            If e.HtmlElementID = RadListBoxAvailableTasks.ClientID Then

                Using DataContext = New AdvantageFramework.Database.DataContext(Session("ConnString").ToString(), Session("UserCode").ToString())

                    TaskRolesList = AdvantageFramework.Database.Procedures.TaskRole.LoadByRoleCode(DataContext, DropDownListRoles.SelectedValue).ToList

                    For Each ListBoxItem In e.SourceDragItems.OfType(Of Telerik.Web.UI.RadListBoxItem)()

                        Try

                            TaskRole = (From Entity In TaskRolesList.AsQueryable
                                        Where Entity.TaskCode = ListBoxItem.Value
                                        Select Entity).Single

                        Catch ex As Exception
                            TaskRole = Nothing
                        End Try

                        If TaskRole IsNot Nothing Then

                            AdvantageFramework.Database.Procedures.TaskRole.Delete(DataContext, TaskRole)

                        End If

                    Next

                End Using

                LoadRoleDetails()

            End If

        End If

    End Sub
    Private Sub RadListBoxCurrentTasks_Inserted(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadListBoxEventArgs) Handles RadListBoxCurrentTasks.Inserted

        'objects
        Dim TaskRole As AdvantageFramework.Database.Entities.TaskRole = Nothing

        If DropDownListRoles.SelectedValue IsNot Nothing AndAlso DropDownListRoles.SelectedValue.ToString() <> "" Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(Session("ConnString").ToString(), Session("UserCode").ToString())

                    For Each ListBoxItem In e.Items.OfType(Of Telerik.Web.UI.RadListBoxItem)()

                        TaskRole = New AdvantageFramework.Database.Entities.TaskRole

                        TaskRole.TaskCode = ListBoxItem.Value
                        TaskRole.RoleCode = DropDownListRoles.SelectedValue

                        AdvantageFramework.Database.Procedures.TaskRole.Insert(DataContext, DbContext, TaskRole)

                    Next

                End Using

            End Using

            LoadRoleDetails()

        End If

    End Sub
    Private Sub RadListBoxAvailableTasks_Dropped(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadListBoxDroppedEventArgs) Handles RadListBoxAvailableTasks.Dropped

        'objects
        Dim TaskRole As AdvantageFramework.Database.Entities.TaskRole = Nothing

        If DropDownListRoles.SelectedValue IsNot Nothing AndAlso DropDownListRoles.SelectedValue.ToString() <> "" Then

            If e.HtmlElementID = RadListBoxCurrentTasks.ClientID Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(Session("ConnString").ToString(), Session("UserCode").ToString())

                        For Each ListBoxItem In e.SourceDragItems.OfType(Of Telerik.Web.UI.RadListBoxItem)()

                            TaskRole = New AdvantageFramework.Database.Entities.TaskRole

                            TaskRole.TaskCode = ListBoxItem.Value
                            TaskRole.RoleCode = DropDownListRoles.SelectedValue

                            AdvantageFramework.Database.Procedures.TaskRole.Insert(DataContext, DbContext, TaskRole)

                        Next

                    End Using

                End Using

            End If

            LoadRoleDetails()

        End If

    End Sub
    Private Sub RadListBoxAvailableTasks_Inserted(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadListBoxEventArgs) Handles RadListBoxAvailableTasks.Inserted

        'objects
        Dim TaskRolesList As Generic.List(Of AdvantageFramework.Database.Entities.TaskRole) = Nothing
        Dim TaskRole As AdvantageFramework.Database.Entities.TaskRole = Nothing

        If DropDownListRoles.SelectedValue IsNot Nothing AndAlso DropDownListRoles.SelectedValue.ToString() <> "" Then

            Using DataContext = New AdvantageFramework.Database.DataContext(Session("ConnString").ToString(), Session("UserCode").ToString())

                TaskRolesList = AdvantageFramework.Database.Procedures.TaskRole.LoadByRoleCode(DataContext, DropDownListRoles.SelectedValue).ToList

                For Each ListBoxItem In e.Items.OfType(Of Telerik.Web.UI.RadListBoxItem)()

                    Try

                        TaskRole = (From Entity In TaskRolesList.AsQueryable
                                    Where Entity.TaskCode = ListBoxItem.Value
                                    Select Entity).Single

                    Catch ex As Exception
                        TaskRole = Nothing
                    End Try

                    If TaskRole IsNot Nothing Then

                        AdvantageFramework.Database.Procedures.TaskRole.Delete(DataContext, TaskRole)

                    End If

                Next

            End Using

            LoadRoleDetails()

        End If

    End Sub
    Private Sub CheckBoxIsInactive_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxIsInactive.CheckedChanged

        'objects
        Dim Role As AdvantageFramework.Database.Entities.Role = Nothing

        If DropDownListRoles.SelectedValue IsNot Nothing AndAlso DropDownListRoles.SelectedValue.ToString() <> "" Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Role = AdvantageFramework.Database.Procedures.Role.LoadByRoleCode(DbContext, DropDownListRoles.SelectedValue)

                If Role IsNot Nothing Then

                    If CheckBoxIsInactive.Checked Then

                        Role.IsInactive = 1

                    Else

                        Role.IsInactive = 0

                    End If

                    AdvantageFramework.Database.Procedures.Role.Update(DbContext, Role)

                End If

            End Using

            LoadRoleDetailTab(DropDownListRoles.SelectedValue)

        End If

    End Sub
    Private Sub RadGridRoles_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridRoles.ItemCommand

        'objects
        Dim GridEditableItem As Telerik.Web.UI.GridEditableItem = Nothing
        Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim Role As AdvantageFramework.Database.Entities.Role = Nothing
        Dim Reload As Boolean = True

        If e.Item IsNot Nothing AndAlso e.Item.ItemIndex > -1 Then

            CurrentGridDataItem = RadGridRoles.Items(e.Item.ItemIndex)

        End If

        Select Case e.CommandName

            Case "SaveAll"

                For Each GridDataItem In RadGridRoles.MasterTableView.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

                    UpdateRoleOnRolesTab(GridDataItem)

                Next

            Case "SaveNewRow"

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Role = New AdvantageFramework.Database.Entities.Role

                    Role.DbContext = DbContext

                    Role.Code = CType(e.Item.FindControl("TextBoxRoleCodeEditTextBox"), TextBox).Text.Trim
                    Role.Description = CType(e.Item.FindControl("TextBoxRoleDescriptionEditTextBox"), TextBox).Text.Trim

                    If CType(e.Item.FindControl("CheckBoxIsInactiveEditCheckBox"), CheckBox).Checked Then

                        Role.IsInactive = 1

                    Else

                        Role.IsInactive = 0

                    End If

                    Reload = AdvantageFramework.Database.Procedures.Role.Insert(DbContext, Role)

                End Using

            Case "SaveRow"

                If CurrentGridDataItem IsNot Nothing Then

                    UpdateRoleOnRolesTab(CurrentGridDataItem)

                End If

            Case "CancelNewRow"

                If e.Item IsNot Nothing Then

                    CType(e.Item.FindControl("TextBoxRoleCodeEditTextBox"), TextBox).Text = ""
                    CType(e.Item.FindControl("TextBoxRoleDescriptionEditTextBox"), TextBox).Text = ""
                    CType(e.Item.FindControl("CheckBoxIsInactiveEditCheckBox"), CheckBox).Checked = False

                End If

            Case "DeleteRow"

                If CurrentGridDataItem IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Using DataContext = New AdvantageFramework.Database.DataContext(Session("ConnString").ToString(), Session("UserCode").ToString())

                            Role = AdvantageFramework.Database.Procedures.Role.LoadByRoleCode(DbContext, CurrentGridDataItem.GetDataKeyValue("Code"))

                            If Role IsNot Nothing Then

                                AdvantageFramework.Database.Procedures.Role.Delete(DbContext, DataContext, Role)

                            End If

                        End Using

                    End Using

                End If

        End Select

        If Reload Then

            If e.CommandName = "SaveNewRow" Then

                MiscFN.ResponseRedirect(String.Format("Maintenance_Role.aspx?TabIndex={0}", RadTabStripRoles.SelectedIndex))

            Else

                Me.RadGridRoles.Rebind()

            End If

        Else

            If e.Item.IsInEditMode Then

                CType(e.Item.FindControl("TextBoxRoleCodeEditTextBox"), TextBox).Focus()

            End If

        End If

    End Sub
    Private Sub RadGridRoles_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridRoles.ItemDataBound

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
    Private Sub RadGridRoles_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridRoles.NeedDataSource

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            RadGridRoles.DataSource = LoadRoles(DbContext, False).ToList
            RadGridRoles.MasterTableView.IsItemInserted = True

        End Using

        Me.RadGridRoles.PageSize = MiscFN.LoadPageSize(Me.RadGridRoles.ID)

    End Sub
    Private Sub RadGridRoles_PageIndexChanged(sender As Object, e As Telerik.Web.UI.GridPageChangedEventArgs) Handles RadGridRoles.PageIndexChanged

        Me.CurrentPageNumber = e.NewPageIndex
        Me.RadGridRoles.Rebind()

    End Sub
    Private Sub RadGridRoles_PageSizeChanged(sender As Object, e As Telerik.Web.UI.GridPageSizeChangedEventArgs) Handles RadGridRoles.PageSizeChanged

        MiscFN.SavePageSize(Me.RadGridRoles.ID, e.NewPageSize)

    End Sub

#End Region

#End Region

End Class