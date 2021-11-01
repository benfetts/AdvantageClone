
Imports System.Web

Namespace Controller
    Public Class ApplicationController
        Inherits AdvantageFramework.Controller.BaseController

#Region " Constants "

#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _IsASPActive As Boolean? = Nothing

#End Region

#Region " Properties "

        Public Property _IsClientPortal As Boolean
        Public Property ApplicationPath As String
        Public Property _IsProofingActive As Boolean
        Public Property _DatabaseName As String

#End Region

#Region " Methods "

        Public Sub New(ByVal Session As AdvantageFramework.Security.Session, ByVal IsClientPortal As Boolean, ByVal IsProofingActive As Boolean)

            MyBase.New(Session)

            Me._IsClientPortal = IsClientPortal
            Me._IsProofingActive = IsProofingActive

            If Session IsNot Nothing Then

                If String.IsNullOrEmpty(Session.DatabaseName) = False Then

                    Me._DatabaseName = Session.DatabaseName

                End If

            End If

        End Sub
        Public Function Load() As AdvantageFramework.DTO.Application

            'objects
            Dim Application As AdvantageFramework.DTO.Application = Nothing
            Dim ModulesList As Generic.List(Of AdvantageFramework.Security.Database.Views.ModuleView) = Nothing
            Dim UserPermissionList As Generic.List(Of AdvantageFramework.Security.Database.Views.UserPermission) = Nothing

            Application = New DTO.Application

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ModulesList = AdvantageFramework.Security.Database.Procedures.ModuleView.Load(SecurityDbContext).ToList

                    If Me.Session.Application <> AdvantageFramework.Security.Application.Client_Portal Then

                        UserPermissionList = AdvantageFramework.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndUser(SecurityDbContext, Me.Session.Application, Me.Session.User.ID).ToList

                    End If

                    LoadApplicationEmployeeInfo(DbContext, SecurityDbContext, Application)
                    LoadApplicationMenus(SecurityDbContext, DbContext, Application, ModulesList, UserPermissionList)

                    Application.IsProofingActive = _IsProofingActive
                    Application.DatabaseName = _DatabaseName

                End Using

            End Using

            Try

            Catch ex As Exception

            End Try

            Return Application

        End Function
        Private Sub LoadApplicationEmployeeInfo(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, ByVal Application As AdvantageFramework.DTO.Application)

            'objects
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim ClientPortalUser As AdvantageFramework.Security.Database.Entities.ClientPortalUser = Nothing
            Dim EmployeePicture As AdvantageFramework.Database.Entities.EmployeePicture = Nothing
            Dim Picture As String = Nothing
            Dim Title As String = Nothing
            Dim Signature As String = Nothing

            If _IsClientPortal = True Then

                ClientPortalUser = AdvantageFramework.Security.Database.Procedures.ClientPortalUser.LoadByClientContactID(SecurityDbContext, Me.Session.ClientPortalUser.ClientContactID)
                If ClientPortalUser IsNot Nothing Then

                    Application.Employee = New With {
                        .Code = ClientPortalUser.ClientContactID,
                        .Name = ClientPortalUser.FullName,
                        .Picture = Picture,
                        .Title = Title,
                        .FirstName = ClientPortalUser.ClientContact.FirstName,
                        .MiddleInitial = ClientPortalUser.ClientContact.MiddleInitial,
                        .LastName = ClientPortalUser.ClientContact.LastName,
                        .Nickname = ""
                    }

                End If

                Application.IsClientPortal = True

            Else

                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Me.Session.User.EmployeeCode)

                If Employee IsNot Nothing Then

                    Title = Employee.Title

                    EmployeePicture = AdvantageFramework.Database.Procedures.EmployeePicture.LoadByEmployeeCode(DbContext, Employee.Code)

                    If EmployeePicture IsNot Nothing AndAlso EmployeePicture.Image IsNot Nothing Then

                        Try

                            Picture = Convert.ToBase64String(EmployeePicture.Image, 0, EmployeePicture.Image.Length)

                        Catch ex As Exception

                        End Try

                    End If

                    If Employee.SignatureImage IsNot Nothing Then

                        Try

                            Signature = Convert.ToBase64String(Employee.SignatureImage, 0, Employee.SignatureImage.Length)

                        Catch ex As Exception

                        End Try

                    End If

                    Application.Employee = New With {
                        .Code = Employee.Code,
                        .Name = Employee.ToString,
                        .Picture = Picture,
                        .Title = Title,
                        .FirstName = Employee.FirstName,
                        .MiddleInitial = Employee.MiddleInitial,
                        .LastName = Employee.LastName,
                        .Nickname = If(EmployeePicture Is Nothing, "", EmployeePicture.Nickname),
                        .Signature = Signature
                    }

                End If
            End If



        End Sub
        Private Sub LoadApplicationMenus(ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                         ByVal DbContext As AdvantageFramework.Database.DbContext,
                                         ByVal Application As AdvantageFramework.DTO.Application,
                                         ByVal ModulesList As Generic.List(Of AdvantageFramework.Security.Database.Views.ModuleView),
                                         UserPermissionList As Generic.List(Of AdvantageFramework.Security.Database.Views.UserPermission))

            Application.MainMenuItems.AddRange(GetApplicationMenuItems(SecurityDbContext, ModulesList, UserPermissionList))
            Application.MainMenuItems.Add(GetSettingsCategoryMenuItem(SecurityDbContext))
            Application.QuickAccessMenuItems.AddRange(GetQuickAccessMenuItems(SecurityDbContext, UserPermissionList))
            Application.ProductivityMenuItems.AddRange(GetProductivityMenuItems(SecurityDbContext, DbContext, ModulesList, UserPermissionList))
            Application.SearchMenuItems.AddRange(GetSearchMenuItems(SecurityDbContext, UserPermissionList))

        End Sub
        Private Function GetApplicationMenuItems(ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                 ByVal ModulesList As Generic.List(Of AdvantageFramework.Security.Database.Views.ModuleView),
                                                 UserPermissionList As Generic.List(Of AdvantageFramework.Security.Database.Views.UserPermission)) As Generic.List(Of AdvantageFramework.DTO.Application.CategoryMenuItem)

            'objects
            Dim CategoryMenuItem As AdvantageFramework.DTO.Application.CategoryMenuItem = Nothing
            Dim CategoryMenuItems As Generic.List(Of AdvantageFramework.DTO.Application.CategoryMenuItem) = Nothing

            CategoryMenuItems = New Generic.List(Of AdvantageFramework.DTO.Application.CategoryMenuItem)

            If ModulesList IsNot Nothing AndAlso ModulesList.Count > 0 Then

                For Each ModuleView In ModulesList.Where(Function(ModView) ModView.ApplicationID = Me.Session.Application AndAlso ModView.ParentModuleID Is Nothing AndAlso
                                                                           ModView.IsInactive = False AndAlso ModView.IsMenuItem = True).OrderBy(Function(ModView) ModView.SortOrder)

                    CategoryMenuItem = New DTO.Application.CategoryMenuItem

                    CategoryMenuItem.Text = ModuleView.ModuleDescription

                    Try

                        If Me.Session.Application = AdvantageFramework.Security.Application.Client_Portal Then

                            LoadApplicationSubMenu(Me.Session.Application, Me.Session.ClientPortalUser, ModuleView, CategoryMenuItem, ModulesList)

                        Else

                            LoadApplicationSubMenu(SecurityDbContext, Me.Session.Application, ModuleView, CategoryMenuItem, ModulesList, UserPermissionList)

                        End If

                    Catch ex As Exception

                    End Try

                    If CategoryMenuItem.MenuItems IsNot Nothing AndAlso CategoryMenuItem.MenuItems.Count > 0 Then

                        CategoryMenuItems.Add(CategoryMenuItem)

                    End If

                Next

            End If

            Return CategoryMenuItems

        End Function
        Private Function GetQuickAccessMenuItems(ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                 UserPermissionList As Generic.List(Of AdvantageFramework.Security.Database.Views.UserPermission)) As Generic.List(Of AdvantageFramework.DTO.Application.MenuItem)

            'objects
            Dim MenuItems As Generic.List(Of AdvantageFramework.DTO.Application.MenuItem) = Nothing
            Dim NewCategoryMenuItem As AdvantageFramework.DTO.Application.CategoryMenuItem = Nothing
            Dim FindCategoryMenuItem As AdvantageFramework.DTO.Application.CategoryMenuItem = Nothing
            Dim SettingsCategoryMenuItem As AdvantageFramework.DTO.Application.CategoryMenuItem = Nothing
            Dim IsClientPortal As Boolean = False 'future

            MenuItems = New List(Of DTO.Application.MenuItem)

            If _IsClientPortal = False Then

                'NewCategoryMenuItem = GetNewCategoryMenuItem(SecurityDbContext)
                'FindCategoryMenuItem = GetFindCategoryMenuItem(SecurityDbContext)
                'SettingsCategoryMenuItem = GetSettingsCategoryMenuItem(SecurityDbContext)

                If CanUserAddInModule(SecurityDbContext, AdvantageFramework.Security.Modules.Desktop_Alerts, UserPermissionList) Then

                    MenuItems.Add(New DTO.Application.ApplicationMenuItem With {.Text = "Alert", .Url = "Alert_New.aspx?f=0"})
                    MenuItems.Add(New DTO.Application.ApplicationMenuItem With {.Text = "Assignment", .Url = "Alert_New.aspx?ps=0&assn=1&f=2"})

                    If _IsProofingActive = True Then

                        MenuItems.Add(New DTO.Application.ApplicationMenuItem With {.Text = "Proof", .Url = "Desktop_NewAssignment?caller=review&f=1&jt=1&assn=1"})

                    End If

                End If

                If CheckModuleAccess(SecurityDbContext, AdvantageFramework.Security.Modules.Desktop_Calendar, UserPermissionList) Then

                    MenuItems.Add(New DTO.Application.ApplicationMenuItem With {.Text = "Calendar Activity", .Url = "Calendar_NewActivity.aspx?f=0"})

                End If

                If CanUserAddInModule(SecurityDbContext, AdvantageFramework.Security.Modules.Employee_ExpenseReports, UserPermissionList) Then

                    MenuItems.Add(New DTO.Application.ApplicationMenuItem With {.Text = "Expense Report", .Url = "Employee/ExpenseReports/NewExpenseReport?invoice=new&empcode=" & Session.User.EmployeeCode})

                End If

                If CanUserAddInModule(SecurityDbContext, AdvantageFramework.Security.Modules.Employee_Timesheet, UserPermissionList) Then

                    MenuItems.Add(New DTO.Application.ApplicationMenuItem With {.Text = "Timesheet Entry", .Url = "Timesheet_CommentsView.aspx"})

                End If

                If CheckModuleAccess(SecurityDbContext, AdvantageFramework.Security.Modules.ProjectManagement_Campaigns, UserPermissionList) And
                    CanUserAddInModule(SecurityDbContext, AdvantageFramework.Security.Modules.ProjectManagement_Campaigns, UserPermissionList) Then

                    MenuItems.Add(New DTO.Application.ApplicationMenuItem With {.Text = "Campaign", .Url = "Campaign_New.aspx?FromWindow=campaignSearch"})

                End If

                If CanUserAddInModule(SecurityDbContext, AdvantageFramework.Security.Modules.ProjectManagement_Estimating, UserPermissionList) Then
                    MenuItems.Add(New DTO.Application.ApplicationMenuItem With {.Text = "Estimate", .Url = "Estimating_AddNew.aspx"})
                End If

                If CheckModuleAccess(SecurityDbContext, AdvantageFramework.Security.Modules.ProjectManagement_JobJacket, UserPermissionList) And
                   CanUserAddInModule(SecurityDbContext, AdvantageFramework.Security.Modules.ProjectManagement_JobJacket, UserPermissionList) Then

                    MenuItems.Add(New DTO.Application.ApplicationMenuItem With {.Text = "Job Jacket", .Url = "JobTemplate_New.aspx"})

                End If

                If CanUserAddInModule(SecurityDbContext, AdvantageFramework.Security.Modules.ProjectManagement_ProjectSchedule, UserPermissionList) Then

                    MenuItems.Add(New DTO.Application.ApplicationMenuItem With {.Text = "Project Schedule", .Url = "ProjectManagement/ProjectSchedule/Create?ClientCode=&DivisionCode=&ProductCode="})

                End If

                If CanUserAddInModule(SecurityDbContext, AdvantageFramework.Security.Modules.ProjectManagement_PurchaseOrders, UserPermissionList) Then

                    MenuItems.Add(New DTO.Application.ApplicationMenuItem With {.Text = "Purchase Order", .Url = "purchaseorder.aspx?pagemode=new"})

                End If

                If CanUserAddInModule(SecurityDbContext, AdvantageFramework.Security.Modules.Billing_BillingApprovalBatch, UserPermissionList) Then

                    MenuItems.Add(New DTO.Application.ApplicationMenuItem With {.Text = "Billing Approval Batch", .Url = "BillingApproval_Batch.aspx"})

                End If

                If CheckModuleAccess(SecurityDbContext, AdvantageFramework.Security.Modules.Media_AuthorizationToBuy, UserPermissionList) Then

                    MenuItems.Add(New DTO.Application.ApplicationMenuItem With {.Text = "Authorization to Buy", .Url = "Media_ATB_Add.aspx"})

                End If

                If CheckModuleAccess(SecurityDbContext, AdvantageFramework.Security.Modules.ProjectManagement_JobVersions, UserPermissionList) Then

                    MenuItems.Add(New DTO.Application.ApplicationMenuItem With {.Text = "Job Request", .Url = "jobVerNew.aspx?mode=request"})

                End If

            Else

                If CheckModuleAccess(SecurityDbContext, AdvantageFramework.Security.Modules.ProjectManagement_JobVersions, UserPermissionList) Then

                    MenuItems.Add(New DTO.Application.ApplicationMenuItem With {.Text = "Job Request", .Url = "jobVerNew.aspx?mode=request"})

                End If

            End If

            'If NewCategoryMenuItem IsNot Nothing Then

            '    MenuItems.Add(NewCategoryMenuItem)

            'End If

            'If FindCategoryMenuItem IsNot Nothing Then

            '    MenuItems.Add(FindCategoryMenuItem)

            'End If

            'If SettingsCategoryMenuItem IsNot Nothing Then

            '    MenuItems.Add(SettingsCategoryMenuItem)

            'End If

            Return MenuItems

        End Function
        Private Function GetProductivityMenuItems(ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                  ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                  ByVal ModulesList As Generic.List(Of AdvantageFramework.Security.Database.Views.ModuleView),
                                                  UserPermissionList As Generic.List(Of AdvantageFramework.Security.Database.Views.UserPermission)) As Generic.List(Of AdvantageFramework.DTO.Application.MenuItem)

            'objects
            Dim MenuItems As Generic.List(Of AdvantageFramework.DTO.Application.MenuItem) = Nothing
            Dim WorkspacesCategoryMenuItem As AdvantageFramework.DTO.Application.CategoryMenuItem = Nothing
            Dim FavoritesCategoryMenuItem As AdvantageFramework.DTO.Application.CategoryMenuItem = Nothing
            Dim IsClientPortal As Boolean = False 'future

            MenuItems = New List(Of DTO.Application.MenuItem)

            If _IsClientPortal = False Then

                WorkspacesCategoryMenuItem = GetWorkspacesCategoryMenuItem(SecurityDbContext)
                FavoritesCategoryMenuItem = GetFavoritesCategoryMenuItem(SecurityDbContext, DbContext, ModulesList, UserPermissionList)

            End If

            If WorkspacesCategoryMenuItem IsNot Nothing Then

                MenuItems.Add(WorkspacesCategoryMenuItem)

            End If

            If FavoritesCategoryMenuItem IsNot Nothing Then

                MenuItems.Add(FavoritesCategoryMenuItem)

            End If

            Return MenuItems

        End Function
        Private Function GetSearchMenuItems(ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                            UserPermissionList As Generic.List(Of AdvantageFramework.Security.Database.Views.UserPermission)) As Generic.List(Of AdvantageFramework.DTO.Application.MenuItem)

            'objects
            Dim MenuItems As Generic.List(Of AdvantageFramework.DTO.Application.MenuItem) = Nothing
            ' Dim NewCategoryMenuItem As AdvantageFramework.DTO.Application.CategoryMenuItem = Nothing
            Dim FindCategoryMenuItem As AdvantageFramework.DTO.Application.CategoryMenuItem = Nothing
            '  Dim SettingsCategoryMenuItem As AdvantageFramework.DTO.Application.CategoryMenuItem = Nothing
            Dim IsClientPortal As Boolean = False 'future

            MenuItems = New List(Of DTO.Application.MenuItem)

            'If _IsClientPortal = False Then

            'NewCategoryMenuItem = GetNewCategoryMenuItem(SecurityDbContext)
            FindCategoryMenuItem = GetFindCategoryMenuItem(SecurityDbContext, UserPermissionList)
            'SettingsCategoryMenuItem = GetSettingsCategoryMenuItem(SecurityDbContext)

            'End If

            'If NewCategoryMenuItem IsNot Nothing Then

            '    MenuItems.Add(NewCategoryMenuItem)

            'End If

            If FindCategoryMenuItem IsNot Nothing Then

                MenuItems.Add(FindCategoryMenuItem)

            End If

            'If SettingsCategoryMenuItem IsNot Nothing Then

            '    MenuItems.Add(SettingsCategoryMenuItem)

            'End If

            Return MenuItems

        End Function
        Private Function GetWorkspacesCategoryMenuItem(SecurityDbContext As AdvantageFramework.Security.Database.DbContext) As AdvantageFramework.DTO.Application.CategoryMenuItem

            'objects
            Dim Workspaces As String() = Nothing
            Dim CategoryMenuItem As AdvantageFramework.DTO.Application.CategoryMenuItem = Nothing

            CategoryMenuItem = New DTO.Application.CategoryMenuItem With {.Text = "Workspaces"}

            For Each Workspace In AdvantageFramework.Security.Database.Procedures.UserWorkspace.LoadByUserCode(SecurityDbContext, Me.Session.UserCode).OrderBy(Function(uws) uws.SortOrder).ToList

                CategoryMenuItem.MenuItems.Add(New DTO.Application.ApplicationMenuItem With {.Text = Workspace.Name, .Url = "SelectWorkspace=" & Workspace.ID})

            Next

            Return CategoryMenuItem

        End Function
        Private Function GetFavoritesCategoryMenuItem(ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                      ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                      ByVal ModulesList As Generic.List(Of AdvantageFramework.Security.Database.Views.ModuleView),
                                                      UserPermissionList As Generic.List(Of AdvantageFramework.Security.Database.Views.UserPermission)) As AdvantageFramework.DTO.Application.CategoryMenuItem

            'objects
            Dim CategoryMenuItem As AdvantageFramework.DTO.Application.CategoryMenuItem = Nothing
            Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing
            Dim UserWorkspace As AdvantageFramework.Security.Database.Entities.UserWorkspace = Nothing
            Dim ModuleView As AdvantageFramework.Security.Database.Views.ModuleView = Nothing
            Dim AddObject As Boolean = False
            Dim WorkspaceHasProjectViewpointObject As Boolean = False
            Dim DesktopObjectTitle As String = Nothing
            Dim DesktopObjectName As String = Nothing

            CategoryMenuItem = New DTO.Application.CategoryMenuItem With {.Text = "Favorites"}

            AppVar = (From Item In AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationName(DbContext, Me.Session.UserCode, "MY_SETTINGS")
                      Where Item.Name = "CURRENT_WORKSPACE"
                      Select Item).SingleOrDefault

            If AppVar IsNot Nothing Then

                If IsNumeric(AppVar.Value) Then

                    UserWorkspace = AdvantageFramework.Security.Database.Procedures.UserWorkspace.LoadByUserWorkspaceID(SecurityDbContext, CInt(AppVar.Value))

                    If UserWorkspace IsNot Nothing Then

                        For Each UserFavoriteModule In AdvantageFramework.Security.Database.Procedures.UserFavoriteModule.LoadByUserCodeAndWorkspaceID(SecurityDbContext, Me.Session.UserCode, UserWorkspace.ID)

                            ModuleView = AdvantageFramework.Security.Database.Procedures.ModuleView.LoadByModuleID(SecurityDbContext, UserFavoriteModule.ModuleID)

                            If ModuleView IsNot Nothing Then

                                If Me.CheckModuleAccess(SecurityDbContext, ModuleView.ModuleCode, UserPermissionList) Then

                                    If ModuleView.IsApplication Then

                                        CategoryMenuItem.MenuItems.Add(New AdvantageFramework.DTO.Application.ApplicationMenuItem With {.Text = ModuleView.ModuleDescription, .Url = "APP|" & ModuleView.ModuleID & "|" & ModuleView.WebvantageURL & "|0|0"})

                                    ElseIf ModuleView.IsReport Then

                                        CategoryMenuItem.MenuItems.Add(New AdvantageFramework.DTO.Application.ApplicationMenuItem With {.Text = ModuleView.ModuleDescription, .Url = "RPT|" & ModuleView.ModuleID & "|" & ModuleView.ReportURL & "|0|0"})

                                    Else

                                        CategoryMenuItem.MenuItems.Add(New AdvantageFramework.DTO.Application.ApplicationMenuItem With {.Text = ModuleView.ModuleDescription, .Url = "APP|" & ModuleView.ModuleID & "|" & ModuleView.WebvantageURL & "|0|0"})

                                    End If

                                End If

                            End If

                        Next

                        For Each WorkspaceObject In UserWorkspace.WorkspaceObjects.OrderBy(Function(WorkObject) WorkObject.SortOrder)

                            Try

                                ModuleView = ModulesList.First(Function(ModView) ModView.ModuleID = WorkspaceObject.DesktopObjectID)

                            Catch ex As Exception

                                ModuleView = Nothing

                            End Try

                            If ModuleView IsNot Nothing AndAlso Me.CheckModuleAccess(SecurityDbContext, ModuleView.ModuleCode, UserPermissionList) Then

                                AddObject = True

                                If ModuleView.DesktopObjectName.Contains("DesktopCards") Then

                                    AddObject = False

                                End If

                                If AddObject = True Then

                                    If ModuleView.DesktopObjectName.Contains("DesktopProjectViewpoint.ascx") Then

                                        DesktopObjectTitle = "Project Viewpoint"
                                        DesktopObjectName = "DesktopProjectViewpoint.ascx"

                                        If ModuleView.DesktopObjectName.Contains("?View=0") Then

                                            'ProjectViewpointAccess.Add(0)

                                        ElseIf ModuleView.DesktopObjectName.Contains("?View=2") Then

                                            'ProjectViewpointAccess.Add(1)

                                        ElseIf ModuleView.DesktopObjectName.Contains("?View=3") Then

                                            'ProjectViewpointAccess.Add(2)

                                        End If

                                        If WorkspaceHasProjectViewpointObject = False Then

                                            WorkspaceHasProjectViewpointObject = True
                                            AddObject = True

                                        Else

                                            AddObject = False

                                        End If
                                    Else

                                        DesktopObjectTitle = ModuleView.ModuleDescription
                                        DesktopObjectName = ModuleView.DesktopObjectName.Replace("dos\", "")
                                        AddObject = True

                                    End If

                                End If

                                If AddObject = True Then

                                    'Add to js array to auto open
                                    'Dim DesktopObjectLeft As Integer = -1
                                    'Dim DesktopObjectTop As Integer = -1
                                    'Dim DesktopObjectHeight As Integer = 0
                                    'Dim DesktopObjectWidth As Integer = 0
                                    'Try
                                    '    If Not WorkspaceObject.LeftCoordinate Is Nothing Then
                                    '        DesktopObjectLeft = WorkspaceObject.LeftCoordinate
                                    '    End If
                                    'Catch ex As Exception
                                    '    DesktopObjectLeft = -1
                                    'End Try
                                    'Try
                                    '    If Not WorkspaceObject.TopCoordinate Is Nothing Then
                                    '        DesktopObjectTop = WorkspaceObject.TopCoordinate
                                    '    End If
                                    'Catch ex As Exception
                                    '    DesktopObjectTop = -1
                                    'End Try
                                    'Try
                                    '    If Not WorkspaceObject.Height Is Nothing Then
                                    '        DesktopObjectHeight = WorkspaceObject.Height
                                    '    End If
                                    'Catch ex As Exception
                                    '    DesktopObjectHeight = 0
                                    'End Try
                                    'Try
                                    '    If Not WorkspaceObject.Width Is Nothing Then
                                    '        DesktopObjectWidth = WorkspaceObject.Width
                                    '    End If
                                    'Catch ex As Exception
                                    '    DesktopObjectWidth = 0
                                    'End Try

                                    'If DesktopObjectLeft = 0 Then DesktopObjectLeft = 1
                                    'If DesktopObjectTop = 0 Then DesktopObjectTop = 1

                                    DesktopObjectTitle = DesktopObjectTitle.Replace("(Cards)", "")

                                    'Me.AddToAutoOpenArray(True, ItemCount, DesktopObjectName, DesktopObjectTitle, WorkspaceObject.ID, DesktopObjectLeft, DesktopObjectTop,
                                    '                      DesktopObjectHeight, DesktopObjectWidth)

                                    CategoryMenuItem.MenuItems.Add(New AdvantageFramework.DTO.Application.ApplicationMenuItem With {.Text = DesktopObjectTitle, .Url = "DesktopObjectWindow.aspx?dtoname=" & DesktopObjectName & "&title=" & DesktopObjectTitle})

                                    If DesktopObjectName.Contains("DesktopBookmarks.ascx") = True Then

                                        'Me._HasUserAddedBookmarkDO = True

                                    End If

                                End If

                            End If

                        Next

                    End If

                End If

            End If

            Return CategoryMenuItem

        End Function
        Private Function GetNewCategoryMenuItem(ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                UserPermissionList As Generic.List(Of AdvantageFramework.Security.Database.Views.UserPermission)) As AdvantageFramework.DTO.Application.CategoryMenuItem

            'objects
            Dim CategoryMenuItem As AdvantageFramework.DTO.Application.CategoryMenuItem = Nothing

            CategoryMenuItem = New DTO.Application.CategoryMenuItem With {.Text = "New"}

            If CanUserAddInModule(SecurityDbContext, AdvantageFramework.Security.Modules.Desktop_Alerts, UserPermissionList) Then

                CategoryMenuItem.MenuItems.Add(New DTO.Application.ApplicationMenuItem With {.Text = "Alert", .Url = "Alert_New.aspx?f=0"})
                CategoryMenuItem.MenuItems.Add(New DTO.Application.ApplicationMenuItem With {.Text = "Assignment", .Url = "Alert_New.aspx?ps=0&assn=1&f=2"})

            End If

            If CanUserAddInModule(SecurityDbContext, AdvantageFramework.Security.Modules.Desktop_Calendar, UserPermissionList) Then

                CategoryMenuItem.MenuItems.Add(New DTO.Application.ApplicationMenuItem With {.Text = "Calendar Activity", .Url = "Calendar_NewActivity.aspx?f=0"})

            End If

            If CanUserAddInModule(SecurityDbContext, AdvantageFramework.Security.Modules.Employee_ExpenseReports, UserPermissionList) Then

                CategoryMenuItem.MenuItems.Add(New DTO.Application.ApplicationMenuItem With {.Text = "Expense Report", .Url = "Expense_Edit.aspx?invoice=new&empcode=" & Session.User.EmployeeCode})

            End If

            If CanUserAddInModule(SecurityDbContext, AdvantageFramework.Security.Modules.Employee_Timesheet, UserPermissionList) Then

                CategoryMenuItem.MenuItems.Add(New DTO.Application.ApplicationMenuItem With {.Text = "Timesheet Entry", .Url = "Timesheet_CommentsView.aspx"})

            End If

            If CanUserAddInModule(SecurityDbContext, AdvantageFramework.Security.Modules.ProjectManagement_Campaigns, UserPermissionList) Then

                CategoryMenuItem.MenuItems.Add(New DTO.Application.ApplicationMenuItem With {.Text = "Campaign", .Url = "Campaign_New.aspx?FromWindow=campaignSearch"})

            End If

            If CanUserAddInModule(SecurityDbContext, AdvantageFramework.Security.Modules.ProjectManagement_JobJacket, UserPermissionList) Then

                CategoryMenuItem.MenuItems.Add(New DTO.Application.ApplicationMenuItem With {.Text = "Job Jacket", .Url = "JobTemplate_New.aspx"})

            End If

            If CanUserAddInModule(SecurityDbContext, AdvantageFramework.Security.Modules.ProjectManagement_ProjectSchedule, UserPermissionList) Then

                CategoryMenuItem.MenuItems.Add(New DTO.Application.ApplicationMenuItem With {.Text = "Project Schedule", .Url = "ProjectManagement/ProjectSchedule/Create?ClientCode=&DivisionCode=&ProductCode="})

            End If

            If CanUserAddInModule(SecurityDbContext, AdvantageFramework.Security.Modules.ProjectManagement_PurchaseOrders, UserPermissionList) Then

                CategoryMenuItem.MenuItems.Add(New DTO.Application.ApplicationMenuItem With {.Text = "Purchase Order", .Url = "purchaseorder.aspx?pagemode=new"})

            End If

            If CanUserAddInModule(SecurityDbContext, AdvantageFramework.Security.Modules.Billing_BillingApprovalBatch, UserPermissionList) Then

                CategoryMenuItem.MenuItems.Add(New DTO.Application.ApplicationMenuItem With {.Text = "Billing Approval Batch", .Url = "BillingApproval_Batch.aspx"})

            End If

            If CheckModuleAccess(SecurityDbContext, AdvantageFramework.Security.Modules.Media_AuthorizationToBuy, UserPermissionList) Then

                CategoryMenuItem.MenuItems.Add(New DTO.Application.ApplicationMenuItem With {.Text = "Authorization to Buy", .Url = "Media_ATB_Add.aspx"})

            End If

            If CheckModuleAccess(SecurityDbContext, AdvantageFramework.Security.Modules.ProjectManagement_JobVersions, UserPermissionList) Then

                CategoryMenuItem.MenuItems.Add(New DTO.Application.ApplicationMenuItem With {.Text = "Job Request", .Url = "jobVerNew.aspx?mode=request"})

            End If

            Return CategoryMenuItem

        End Function
        Private Function GetFindCategoryMenuItem(ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                 UserPermissionList As Generic.List(Of AdvantageFramework.Security.Database.Views.UserPermission)) As AdvantageFramework.DTO.Application.CategoryMenuItem

            'objects
            Dim CategoryMenuItem As AdvantageFramework.DTO.Application.CategoryMenuItem = Nothing

            CategoryMenuItem = New DTO.Application.CategoryMenuItem With {.Text = "Find"}

            If _IsClientPortal = False Then

                If CheckModuleAccess(SecurityDbContext, AdvantageFramework.Security.Modules.Media_AuthorizationToBuy, UserPermissionList) Then

                    CategoryMenuItem.MenuItems.Add(New DTO.Application.ApplicationMenuItem With {.Text = "Authorization to Buy", .Url = "Media_ATB_Search.aspx"})

                End If

                If CheckModuleAccess(SecurityDbContext, AdvantageFramework.Security.Modules.ProjectManagement_Campaigns, UserPermissionList) Then

                    CategoryMenuItem.MenuItems.Add(New DTO.Application.ApplicationMenuItem With {.Text = "Campaign", .Url = "Campaign_Search.aspx"})

                End If

                If CheckModuleAccess(SecurityDbContext, AdvantageFramework.Security.Modules.Desktop_DocumentManager, UserPermissionList) Then

                    CategoryMenuItem.MenuItems.Add(New DTO.Application.ApplicationMenuItem With {.Text = "Document", .Url = "Documents_AdvancedSearch.aspx"})

                End If

                If CheckModuleAccess(SecurityDbContext, AdvantageFramework.Security.Modules.ProjectManagement_Estimating, UserPermissionList) Then

                    CategoryMenuItem.MenuItems.Add(New DTO.Application.ApplicationMenuItem With {.Text = "Estimate", .Url = "Estimating_Search.aspx"})

                End If

                If CheckModuleAccess(SecurityDbContext, AdvantageFramework.Security.Modules.ProjectManagement_JobJacket, UserPermissionList) Then

                    CategoryMenuItem.MenuItems.Add(New DTO.Application.ApplicationMenuItem With {.Text = "Job Jacket", .Url = "JobTemplate_Search.aspx"})

                End If

                'If CheckModuleAccess(SecurityDbContext, AdvantageFramework.Security.Modules.ProjectManagement_JobJacket) Then

                CategoryMenuItem.MenuItems.Add(New DTO.Application.ApplicationMenuItem With {.Text = "Job Request", .Url = "JobRequest_Search.aspx"})

                'End If

                If CheckModuleAccess(SecurityDbContext, AdvantageFramework.Security.Modules.ProjectManagement_ProjectSchedule, UserPermissionList) Then

                    CategoryMenuItem.MenuItems.Add(New DTO.Application.ApplicationMenuItem With {.Text = "Project Schedule", .Url = "TrafficSchedule_Search.aspx"})

                End If

                If CheckModuleAccess(SecurityDbContext, AdvantageFramework.Security.Modules.ProjectManagement_PurchaseOrders, UserPermissionList) Then

                    CategoryMenuItem.MenuItems.Add(New DTO.Application.ApplicationMenuItem With {.Text = "Purchase Order", .Url = "purchaseorderlist.aspx"})

                End If

                If CheckModuleAccess(SecurityDbContext, AdvantageFramework.Security.Modules.Employee_Timesheet, UserPermissionList) Then

                    CategoryMenuItem.MenuItems.Add(New DTO.Application.ApplicationMenuItem With {.Text = "Time", .Url = "Timesheet_Search.aspx"})

                End If

            End If

            CategoryMenuItem.MenuItems.Add(New DTO.Application.ApplicationMenuItem With {.Text = "Find across modules", .Url = "Search.aspx"})

            Return CategoryMenuItem

        End Function
        Private Function GetSettingsCategoryMenuItem(ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext) As AdvantageFramework.DTO.Application.CategoryMenuItem

            'objects
            Dim CategoryMenuItem As AdvantageFramework.DTO.Application.CategoryMenuItem = Nothing

            CategoryMenuItem = New DTO.Application.CategoryMenuItem With {.Text = "Support"}

            'CategoryMenuItem.MenuItems.Add(New DTO.Application.ApplicationMenuItem With {.Text = "Settings", .Url = "modules/misc/settings/settings"})

            'If CheckModuleAccess(SecurityDbContext, AdvantageFramework.Security.Modules.Maintenance_General_AgencySettings) Then

            '    CategoryMenuItem.MenuItems.Add(New DTO.Application.ApplicationMenuItem With {.Text = "Agency Settings", .Url = "AgencySettings.aspx"})

            'End If

            'CategoryMenuItem.MenuItems.Add(New DTO.Application.ApplicationMenuItem With {.Text = "Sign Out", .Url = "SIGNOUT"})
            'CategoryMenuItem.MenuItems.Add(New DTO.Application.ApplicationMenuItem With {.Text = "Help", .Url = "Help"})
            CategoryMenuItem.MenuItems.Add(New DTO.Application.ApplicationMenuItem With {.Text = "Contact Customer Service", .Url = "Help_ContactCustomerSupport.aspx"})
            CategoryMenuItem.MenuItems.Add(New DTO.Application.ApplicationMenuItem With {.Text = "About Webvantage", .Url = "About.aspx"})

            Return CategoryMenuItem

        End Function
        Private Function CanUserAddInModule(ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, SecurityModule As AdvantageFramework.Security.Modules,
                                            UserPermissionList As Generic.List(Of AdvantageFramework.Security.Database.Views.UserPermission)) As Boolean

            Return AdvantageFramework.Security.CanUserAddInModule(SecurityDbContext, Session.Application, SecurityModule.ToString, Me.Session.User.ID, UserPermissionList)

        End Function
        Private Function CheckModuleAccess(ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, SecurityModule As AdvantageFramework.Security.Modules,
                                           UserPermissionList As Generic.List(Of AdvantageFramework.Security.Database.Views.UserPermission)) As Boolean

            Return CheckModuleAccess(SecurityDbContext, SecurityModule.ToString, UserPermissionList)

        End Function
        Private Function CheckModuleAccess(ByVal ClientPortalUser As AdvantageFramework.Security.Classes.ClientPortalUser, ByVal ModuleCode As String, ByVal SaveValueToSession As Boolean) As Integer

            Dim ModuleAccess As Integer = 0

            Try

                ModuleAccess = AdvantageFramework.Security.DoesClientPortalUserHaveAccessToModule(Session, ModuleCode)

            Catch ex As Exception
                ModuleAccess = 0
            End Try

            If ModuleAccess = -1 Then

                ModuleAccess = 1

            End If

            Return ModuleAccess

        End Function
        Private Function CheckModuleAccess(ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, ModuleCode As String,
                                           UserPermissionList As Generic.List(Of AdvantageFramework.Security.Database.Views.UserPermission)) As Boolean

            If _IsClientPortal = False Then
                Return AdvantageFramework.Security.DoesUserHaveAccessToModule(SecurityDbContext, Session.Application, ModuleCode, Me.Session.User.ID, UserPermissionList)
            Else
                Return AdvantageFramework.Security.DoesClientPortalUserHaveAccessToModule(Session, ModuleCode)
            End If

        End Function
        Private Function IsAspActive(ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext) As Boolean

            If _IsASPActive.HasValue = False Then

                If SecurityDbContext.Database.SqlQuery(Of Integer)("SELECT COUNT(*) FROM dbo.AGENCY WHERE ASP_ACTIVE = 1").First >= 1 Then

                    _IsASPActive = False

                Else

                    _IsASPActive = True

                End If

            End If

            Return _IsASPActive

        End Function
        Private Sub LoadApplicationSubMenu(ByVal ApplicationID As Integer, ByVal ClientPortalUser As AdvantageFramework.Security.Classes.ClientPortalUser,
                                           ByVal ModuleView As AdvantageFramework.Security.Database.Views.ModuleView, ByVal ParentCategoryMenuItem As AdvantageFramework.DTO.Application.CategoryMenuItem,
                                           ByRef ModulesList As Generic.List(Of AdvantageFramework.Security.Database.Views.ModuleView))

            'objects
            Dim CategoryMenuItem As AdvantageFramework.DTO.Application.CategoryMenuItem = Nothing
            Dim ApplicationMenuItem As AdvantageFramework.DTO.Application.ApplicationMenuItem = Nothing
            Dim SubModule As AdvantageFramework.Security.Database.Views.ModuleView = Nothing
            Dim HasURL As Boolean = False
            Dim JobVersionDescription As String = ""

            Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    For Each SubModule In ModulesList.Where(Function(ModView) ModView.ApplicationID = ApplicationID AndAlso ModView.ParentModuleID.GetValueOrDefault(0) = ModuleView.ModuleID AndAlso
                                                                              ModView.IsInactive = False AndAlso ModView.IsMenuItem = True AndAlso ModView.IsDesktopObject = False).OrderBy(Function(ModView) ModView.SortOrder)

                        If SubModule.IsCategory Then

                            If ModulesList.Any(Function(ModView) ModView.ApplicationID = ApplicationID AndAlso ModView.ParentModuleID.GetValueOrDefault(0) = SubModule.ModuleID AndAlso
                                                                 ModView.IsMenuItem AndAlso ModView.IsDesktopObject = False AndAlso ModView.IsInactive = False) Then

                                CategoryMenuItem = New AdvantageFramework.DTO.Application.CategoryMenuItem

                                CategoryMenuItem.Text = SubModule.ModuleDescription

                                LoadApplicationSubMenu(ApplicationID, ClientPortalUser, SubModule, CategoryMenuItem, ModulesList)

                                If CategoryMenuItem.MenuItems IsNot Nothing AndAlso CategoryMenuItem.MenuItems.Count > 0 Then

                                    ParentCategoryMenuItem.MenuItems.Add(CategoryMenuItem)

                                End If

                            End If

                        Else

                            If Me.CheckModuleAccess(ClientPortalUser, SubModule.ModuleCode, False) = 1 Or Me.CheckModuleAccess(ClientPortalUser, SubModule.ModuleCode, False) = -1 Then

                                ApplicationMenuItem = New AdvantageFramework.DTO.Application.ApplicationMenuItem

                                If SubModule.ModuleDescription = "Job Version" Then

                                    Try

                                        JobVersionDescription = SecurityDbContext.Database.SqlQuery(Of String)("SELECT AGY_SETTINGS_VALUE FROM AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS_CODE = 'JOB_VERSION_DESC';").SingleOrDefault

                                    Catch ex As Exception

                                    End Try

                                    If String.IsNullOrWhiteSpace(JobVersionDescription) Then

                                        ApplicationMenuItem.Text = SubModule.ModuleDescription

                                    Else

                                        ApplicationMenuItem.Text = JobVersionDescription

                                    End If

                                Else

                                    ApplicationMenuItem.Text = SubModule.ModuleDescription

                                End If

                                If SubModule.IsApplication Then

                                    If String.IsNullOrWhiteSpace(SubModule.WebvantageURL) = False Then

                                        HasURL = True

                                        If SubModule.WebvantageURL.ToLower.Contains(".aspx") = False Then 'assume MVC VIEW

                                            SubModule.WebvantageURL = String.Format("{0}/{1}", Me.ApplicationPath, SubModule.WebvantageURL)

                                        End If

                                    End If

                                    If SubModule.ModuleCode = AdvantageFramework.Security.Modules.HelpCustomerService_Help.ToString Then

                                        ApplicationMenuItem.Value = "HELP|"

                                    Else

                                        ApplicationMenuItem.Value = "APP|" & SubModule.ModuleID & "|" & SubModule.WebvantageURL & "|0|0"

                                        If SubModule.WebvantageURL.ToLower.Contains(".aspx") = False Then 'assume MVC VIEW

                                            SubModule.WebvantageURL = String.Format("{0}/{1}", "", SubModule.WebvantageURL)

                                        End If

                                    End If

                                    If SubModule.WebvantageURL <> "" Then

                                        ApplicationMenuItem.Url = SubModule.WebvantageURL

                                    End If

                                ElseIf SubModule.IsReport Then

                                    If String.IsNullOrWhiteSpace(SubModule.ReportURL) = False Then

                                        HasURL = True

                                        If SubModule.ReportURL.ToLower.Contains(".aspx") = False Then 'assume MVC VIEW

                                            SubModule.ReportURL = String.Format("{0}/{1}", "", SubModule.ReportURL)

                                        End If

                                    End If

                                    ApplicationMenuItem.Value = "RPT|" & SubModule.ModuleID & "|" & SubModule.ReportURL & "|0|0"
                                    ApplicationMenuItem.Url = SubModule.ReportURL

                                ElseIf SubModule.IsDashQuery AndAlso String.IsNullOrWhiteSpace(SubModule.DesktopObjectName) = False Then

                                    If String.IsNullOrWhiteSpace(SubModule.DesktopObjectName) = False Then

                                        HasURL = True

                                        ApplicationMenuItem.Value = "DO|" & SubModule.ModuleID & "|" & SubModule.DesktopObjectName & "|0|0"
                                        ApplicationMenuItem.Url = "DesktopObjectLoadWindow.aspx?dtoname=" & SubModule.DesktopObjectName

                                    End If

                                Else

                                    If String.IsNullOrWhiteSpace(SubModule.WebvantageURL) = False Then

                                        HasURL = True

                                        If SubModule.WebvantageURL.ToLower.Contains(".aspx") = False Then 'assume MVC VIEW

                                            SubModule.WebvantageURL = String.Format("{0}/{1}", "", SubModule.WebvantageURL)

                                        End If

                                    End If

                                    ApplicationMenuItem.Value = "APP|" & SubModule.ModuleID & "|" & SubModule.WebvantageURL & "|0|0"
                                    ApplicationMenuItem.Url = SubModule.WebvantageURL

                                End If

                                If HasURL = True Then

                                    If Me._IsClientPortal = True And SubModule.ModuleDescription = "Project Schedule" Then

                                    Else

                                        ParentCategoryMenuItem.MenuItems.Add(ApplicationMenuItem)

                                    End If

                                End If

                            End If

                        End If

                    Next

                End Using

            Catch ex As Exception

            End Try

        End Sub
        Private Sub LoadApplicationSubMenu(ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, ByVal ApplicationID As Integer,
                                           ByVal ModuleView As AdvantageFramework.Security.Database.Views.ModuleView, ByVal ParentCategoryMenuItem As AdvantageFramework.DTO.Application.CategoryMenuItem,
                                           ByVal ModulesList As Generic.List(Of AdvantageFramework.Security.Database.Views.ModuleView),
                                           ByVal UserPermissionList As Generic.List(Of AdvantageFramework.Security.Database.Views.UserPermission))

            'objects
            Dim CategoryMenuItem As AdvantageFramework.DTO.Application.CategoryMenuItem = Nothing
            Dim ApplicationMenuItem As AdvantageFramework.DTO.Application.ApplicationMenuItem = Nothing
            Dim SubModule As AdvantageFramework.Security.Database.Views.ModuleView = Nothing
            Dim HasURL As Boolean = False
            Dim UserPermission As AdvantageFramework.Security.Database.Views.UserPermission = Nothing
            Dim JobVersionDescription As String = ""

            Try

                For Each SubModule In ModulesList.Where(Function(ModView) ModView.ApplicationID = ApplicationID AndAlso ModView.ParentModuleID.GetValueOrDefault(0) = ModuleView.ModuleID AndAlso
                                                                      ModView.IsInactive = False AndAlso ModView.IsMenuItem = True).OrderBy(Function(ModView) ModView.SortOrder)

                    If SubModule.IsCategory Then

                        If ModulesList.Any(Function(ModView) ModView.ApplicationID = ApplicationID AndAlso ModView.ParentModuleID.GetValueOrDefault(0) = SubModule.ModuleID AndAlso ModView.IsMenuItem AndAlso ModView.IsDesktopObject = False) Then

                            CategoryMenuItem = New AdvantageFramework.DTO.Application.CategoryMenuItem
                            If SubModule.ModuleDescription = "Dashboards/Queries" Then
                                CategoryMenuItem.Text = "Dashboards"
                            Else
                                CategoryMenuItem.Text = SubModule.ModuleDescription
                            End If

                            LoadApplicationSubMenu(SecurityDbContext, Me.Session.Application, SubModule, CategoryMenuItem, ModulesList, UserPermissionList)

                            If CategoryMenuItem.MenuItems IsNot Nothing AndAlso CategoryMenuItem.MenuItems.Count > 0 Then

                                ParentCategoryMenuItem.MenuItems.Add(CategoryMenuItem)

                            End If

                        End If

                    Else

                        Try

                            UserPermission = (From Entity In UserPermissionList
                                              Where Entity.ApplicationID = ApplicationID AndAlso
                                                Entity.ModuleID = SubModule.ModuleID AndAlso
                                                Entity.UserID = Me.Session.User.ID
                                              Select Entity).SingleOrDefault

                        Catch ex As Exception
                            UserPermission = Nothing
                        End Try

                        If AdvantageFramework.Security.DoesUserHaveAccessToModule(UserPermission) Then

                            ApplicationMenuItem = New AdvantageFramework.DTO.Application.ApplicationMenuItem

                            If SubModule.ModuleDescription = "Job Version" Then

                                Try

                                    JobVersionDescription = SecurityDbContext.Database.SqlQuery(Of String)("SELECT AGY_SETTINGS_VALUE FROM AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS_CODE = 'JOB_VERSION_DESC';").SingleOrDefault

                                Catch ex As Exception

                                End Try

                                If String.IsNullOrWhiteSpace(JobVersionDescription) Then

                                    ApplicationMenuItem.Text = SubModule.ModuleDescription

                                Else

                                    ApplicationMenuItem.Text = JobVersionDescription

                                End If

                            Else

                                ApplicationMenuItem.Text = SubModule.ModuleDescription

                            End If

                            If SubModule.IsApplication Then

                                If String.IsNullOrWhiteSpace(SubModule.WebvantageURL) = False Then

                                    HasURL = True

                                    If SubModule.WebvantageURL.ToLower.Contains(".aspx") = False Then 'assume MVC VIEW

                                        SubModule.WebvantageURL = String.Format("{0}/{1}", Me.ApplicationPath, SubModule.WebvantageURL)

                                    End If

                                End If

                                If SubModule.ModuleCode = AdvantageFramework.Security.Modules.HelpCustomerService_Help.ToString Then

                                    ApplicationMenuItem.Value = "HELP|"

                                Else

                                    ApplicationMenuItem.Value = "APP|" & SubModule.ModuleID & "|" & SubModule.WebvantageURL & "|0|0"

                                    If SubModule.WebvantageURL.ToLower.Contains(".aspx") = False Then 'assume MVC VIEW

                                        SubModule.WebvantageURL = String.Format("{0}/{1}", "", SubModule.WebvantageURL)

                                    End If

                                End If

                                If SubModule.WebvantageURL <> "" Then

                                    ApplicationMenuItem.Url = SubModule.WebvantageURL

                                End If

                            ElseIf SubModule.IsReport Then

                                If String.IsNullOrWhiteSpace(SubModule.ReportURL) = False Then

                                    HasURL = True

                                    If SubModule.ReportURL.ToLower.Contains(".aspx") = False Then 'assume MVC VIEW

                                        SubModule.ReportURL = String.Format("{0}/{1}", "", SubModule.ReportURL)

                                    End If

                                End If

                                ApplicationMenuItem.Value = "RPT|" & SubModule.ModuleID & "|" & SubModule.ReportURL & "|0|0"
                                ApplicationMenuItem.Url = SubModule.ReportURL

                            ElseIf SubModule.IsDashQuery AndAlso String.IsNullOrWhiteSpace(SubModule.DesktopObjectName) = False Then

                                If String.IsNullOrWhiteSpace(SubModule.DesktopObjectName) = False Then

                                    HasURL = True

                                    ApplicationMenuItem.Value = "DO|" & SubModule.ModuleID & "|" & SubModule.DesktopObjectName & "|0|0"
                                    ApplicationMenuItem.Url = "DesktopObjectLoadWindow.aspx?dtoname=" & SubModule.DesktopObjectName

                                End If

                            Else

                                If String.IsNullOrWhiteSpace(SubModule.WebvantageURL) = False Then

                                    HasURL = True

                                    If SubModule.WebvantageURL.ToLower.Contains(".aspx") = False Then 'assume MVC VIEW

                                        SubModule.WebvantageURL = String.Format("{0}/{1}", "", SubModule.WebvantageURL)

                                    End If

                                End If

                                ApplicationMenuItem.Value = "APP|" & SubModule.ModuleID & "|" & SubModule.WebvantageURL & "|0|0"
                                ApplicationMenuItem.Url = SubModule.WebvantageURL

                            End If

                            'hide items if ASP
                            If SubModule.ModuleCode = AdvantageFramework.Security.Modules.Security_Setup_ClientPortalUser.ToString OrElse
                               SubModule.ModuleCode = AdvantageFramework.Security.Modules.Security_RepositorySettings.ToString Then

                                HasURL = Me.IsAspActive(SecurityDbContext)

                            End If

                            If HasURL = True Then

                                If Me._IsClientPortal = True AndAlso SubModule.ModuleDescription = "Project Schedule" Then



                                Else

                                    ParentCategoryMenuItem.MenuItems.Add(ApplicationMenuItem)

                                End If

                            End If

                        End If

                    End If

                Next

            Catch ex As Exception

            End Try

        End Sub

#End Region

    End Class

End Namespace
