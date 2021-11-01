Namespace Security.Setup.Presentation

    Public Class ModuleAccessForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _GroupModuleAccessList As Generic.List(Of AdvantageFramework.Security.Database.Classes.GroupModuleAccess) = Nothing
        Private _UserModuleAccessList As Generic.List(Of AdvantageFramework.Security.Database.Classes.UserModuleAccess) = Nothing
        Private WithEvents _ToolTipController As DevExpress.Utils.ToolTipController = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadModules(ByVal ApplicationID As Integer)

            'objects
            Dim Node As DevComponents.AdvTree.Node = Nothing
            Dim Modules As Generic.List(Of AdvantageFramework.Security.Database.Views.ModuleView) = Nothing
            Dim [Module] As AdvantageFramework.Security.Database.Views.ModuleView = Nothing
            Dim GroupModuleAccessList As Generic.List(Of AdvantageFramework.Security.Database.Entities.GroupModuleAccess) = Nothing
            Dim UserModuleAccessList As Generic.List(Of AdvantageFramework.Security.Database.Entities.UserModuleAccess) = Nothing

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Modules = SecurityDbContext.GetQuery(Of AdvantageFramework.Security.Database.Views.ModuleView).Where(Function(ModView) ModView.ApplicationID = ApplicationID AndAlso ModView.IsInactive = False).ToList
                GroupModuleAccessList = SecurityDbContext.GetQuery(Of AdvantageFramework.Security.Database.Entities.GroupModuleAccess).ToList
                UserModuleAccessList = SecurityDbContext.GetQuery(Of AdvantageFramework.Security.Database.Entities.UserModuleAccess).ToList

                For Each ModuleView In Modules.Where(Function(ModView) ModView.ParentModuleID Is Nothing).OrderBy(Function(ModView) ModView.SortOrder).ToList

                    Node = New DevComponents.AdvTree.Node

                    Node.Text = ModuleView.ModuleDescription
                    Node.Tag = ModuleView.ModuleCode

                    AdvTreeForm_Modules.Nodes.Add(Node)

                    LoadSubModule(SecurityDbContext, Modules, GroupModuleAccessList, UserModuleAccessList, ModuleView, Node, ApplicationID)

                    For Each TreeNode In Node.Nodes.OfType(Of DevComponents.AdvTree.Node).ToList

                        Try

                            [Module] = Modules.SingleOrDefault(Function(ModView) ModView.ModuleCode = TreeNode.TagString)

                        Catch ex As Exception
                            [Module] = Nothing
                        End Try

                        If [Module] IsNot Nothing Then

                            If [Module].IsCategory = True AndAlso TreeNode.Nodes.Count = 0 Then

                                Node.Nodes.Remove(TreeNode)

                            End If

                        End If

                    Next

                    If Node.Nodes.Count = 0 Then

                        AdvTreeForm_Modules.Nodes.Remove(Node)

                    End If

                Next

            End Using

        End Sub
        Private Sub LoadSubModule(ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, ByVal Modules As Generic.List(Of AdvantageFramework.Security.Database.Views.ModuleView),
                                  ByVal GroupModuleAccessList As Generic.List(Of AdvantageFramework.Security.Database.Entities.GroupModuleAccess),
                                  ByVal UserModuleAccessList As Generic.List(Of AdvantageFramework.Security.Database.Entities.UserModuleAccess),
                                  ByVal ModuleView As AdvantageFramework.Security.Database.Views.ModuleView, ByRef ParentNode As DevComponents.AdvTree.Node,
                                  ByVal ApplicationID As Integer)

            'objects
            Dim Node As DevComponents.AdvTree.Node = Nothing
            Dim AddModule As Boolean = False
            Dim [SubModule] As AdvantageFramework.Security.Database.Views.ModuleView = Nothing

            For Each [SubModule] In Modules.Where(Function(ModView) ModView.ParentModuleID.GetValueOrDefault(0) = ModuleView.ModuleID AndAlso ModView.IsInactive = False).OrderBy(Function(ModView) ModView.SortOrder).ToList

                AddModule = False

                If SubModule.IsCategory = False Then

                    If SubModule.IsApplication AndAlso ButtonItemShow_Modules.Checked Then

                        AddModule = True

                    End If

                    If SubModule.IsReport AndAlso ButtonItemShow_Reports.Checked Then

                        AddModule = True

                    End If

                    If SubModule.IsDesktopObject AndAlso ButtonItemShow_DesktopObjects.Checked Then

                        AddModule = True

                    End If

                    If SubModule.IsDashQuery AndAlso ButtonItemShow_DashboardAndQueries.Checked Then

                        AddModule = True

                    End If

                Else

                    AddModule = True

                End If

                If AddModule AndAlso ButtonItemShowBy_All.Checked = False Then

                    If SubModule.IsCategory = False Then

                        If ButtonItemShowBy_AllBlocked.Checked Then

                            AddModule = Not UserModuleAccessList.Where(Function(UserModuleAccess) UserModuleAccess.ModuleID = SubModule.ModuleID).Any(Function(UserModuleAccess) UserModuleAccess.IsBlocked = False)

                        Else

                            AddModule = Not UserModuleAccessList.Where(Function(UserModuleAccess) UserModuleAccess.ModuleID = SubModule.ModuleID).Any(Function(UserModuleAccess) UserModuleAccess.IsBlocked = True)

                        End If

                        If AddModule Then

                            If ButtonItemShowBy_AllBlocked.Checked Then

                                AddModule = Not GroupModuleAccessList.Where(Function(GroupModuleAccess) GroupModuleAccess.ModuleID = SubModule.ModuleID).Any(Function(GroupModuleAccess) GroupModuleAccess.IsBlocked = False)

                            Else

                                AddModule = Not GroupModuleAccessList.Where(Function(GroupModuleAccess) GroupModuleAccess.ModuleID = SubModule.ModuleID).Any(Function(GroupModuleAccess) GroupModuleAccess.IsBlocked = True)

                            End If

                        End If

                    End If

                End If

                If AddModule Then

                    Node = New DevComponents.AdvTree.Node

                    Node.Text = AdvantageFramework.Security.LoadDescriptionForModule(SecurityDbContext, SubModule)
                    If Node.Text = "Dashboards/Queries" AndAlso ApplicationID = 2 Then
                        Node.Text = "Dashboards"
                    End If

                    Node.Tag = SubModule.ModuleCode

                    ParentNode.Nodes.Add(Node)

                    If SubModule.IsCategory Then

                        LoadSubModule(SecurityDbContext, Modules, GroupModuleAccessList, UserModuleAccessList, SubModule, Node, ApplicationID)

                    End If

                End If

            Next

        End Sub
        Private Sub SetupUserAndGroupAccessGrids(ByVal HasCustomPermission As Boolean, ByVal AllSelectedModulesHaveSameOptions As Boolean)

            If HasCustomPermission = False OrElse AllSelectedModulesHaveSameOptions = False Then

                ButtonItemUserPrinting_AllCanPrint.Enabled = False
                ButtonItemUserPrinting_AllCantPrint.Enabled = False
                ButtonItemUserUpdating_AllCanUpdate.Enabled = False
                ButtonItemUserUpdating_AllCantUpdate.Enabled = False
                ButtonItemUserAdding_AllCanAdd.Enabled = False
                ButtonItemUserAdding_AllCantAdd.Enabled = False
                ButtonItemUserCustom1_AllRightsCustom1.Enabled = False
                ButtonItemUserCustom1_AllNoRightsCustom1.Enabled = False
                ButtonItemUserCustom2_AllRightsCustom2.Enabled = False
                ButtonItemUserCustom2_AllNoRightsCustom2.Enabled = False

                ButtonItemGroupPrinting_AllCanPrint.Enabled = False
                ButtonItemGroupPrinting_AllCantPrint.Enabled = False
                ButtonItemGroupUpdating_AllCanUpdate.Enabled = False
                ButtonItemGroupUpdating_AllCantUpdate.Enabled = False
                ButtonItemGroupAdding_AllCanAdd.Enabled = False
                ButtonItemGroupAdding_AllCantAdd.Enabled = False
                ButtonItemGroupCustom1_AllRightsCustom1.Enabled = False
                ButtonItemGroupCustom1_AllNoRightsCustom1.Enabled = False
                ButtonItemGroupCustom2_AllRightsCustom2.Enabled = False
                ButtonItemGroupCustom2_AllNoRightsCustom2.Enabled = False

            Else

                ButtonItemUserPrinting_AllCanPrint.Enabled = True
                ButtonItemUserPrinting_AllCantPrint.Enabled = True
                ButtonItemUserUpdating_AllCanUpdate.Enabled = True
                ButtonItemUserUpdating_AllCantUpdate.Enabled = True
                ButtonItemUserAdding_AllCanAdd.Enabled = True
                ButtonItemUserAdding_AllCantAdd.Enabled = True
                ButtonItemUserCustom1_AllRightsCustom1.Enabled = True
                ButtonItemUserCustom1_AllNoRightsCustom1.Enabled = True
                ButtonItemUserCustom2_AllRightsCustom2.Enabled = True
                ButtonItemUserCustom2_AllNoRightsCustom2.Enabled = True

                ButtonItemGroupPrinting_AllCanPrint.Enabled = True
                ButtonItemGroupPrinting_AllCantPrint.Enabled = True
                ButtonItemGroupUpdating_AllCanUpdate.Enabled = True
                ButtonItemGroupUpdating_AllCantUpdate.Enabled = True
                ButtonItemGroupAdding_AllCanAdd.Enabled = True
                ButtonItemGroupAdding_AllCantAdd.Enabled = True
                ButtonItemGroupCustom1_AllRightsCustom1.Enabled = True
                ButtonItemGroupCustom1_AllNoRightsCustom1.Enabled = True
                ButtonItemGroupCustom2_AllRightsCustom2.Enabled = True
                ButtonItemGroupCustom2_AllNoRightsCustom2.Enabled = True

                DataGridViewForm_GroupAccess.MakeColumnVisible(AdvantageFramework.Security.Database.Classes.GroupModuleAccess.Properties.CanPrint.ToString)
                DataGridViewForm_GroupAccess.MakeColumnVisible(AdvantageFramework.Security.Database.Classes.GroupModuleAccess.Properties.CanUpdate.ToString)
                DataGridViewForm_GroupAccess.MakeColumnVisible(AdvantageFramework.Security.Database.Classes.GroupModuleAccess.Properties.CanAdd.ToString)
                DataGridViewForm_GroupAccess.MakeColumnVisible(AdvantageFramework.Security.Database.Classes.GroupModuleAccess.Properties.Custom1.ToString)
                DataGridViewForm_GroupAccess.MakeColumnVisible(AdvantageFramework.Security.Database.Classes.GroupModuleAccess.Properties.Custom2.ToString)

                DataGridViewForm_UserAccess.MakeColumnVisible(AdvantageFramework.Security.Database.Classes.UserModuleAccess.Properties.CanPrint.ToString)
                DataGridViewForm_UserAccess.MakeColumnVisible(AdvantageFramework.Security.Database.Classes.UserModuleAccess.Properties.CanUpdate.ToString)
                DataGridViewForm_UserAccess.MakeColumnVisible(AdvantageFramework.Security.Database.Classes.UserModuleAccess.Properties.CanAdd.ToString)
                DataGridViewForm_UserAccess.MakeColumnVisible(AdvantageFramework.Security.Database.Classes.UserModuleAccess.Properties.Custom1.ToString)
                DataGridViewForm_UserAccess.MakeColumnVisible(AdvantageFramework.Security.Database.Classes.UserModuleAccess.Properties.Custom2.ToString)

            End If

        End Sub
        Private Sub SetAllUserModuleAccess(ByVal ModuleList As Generic.List(Of AdvantageFramework.Security.Database.Views.ModuleView), ByVal UserModuleAccessProperty As AdvantageFramework.Security.Database.Entities.UserModuleAccess.Properties, ByVal NewValue As Boolean)

            'objects
            Dim [Module] As AdvantageFramework.Security.Database.Views.ModuleView = Nothing
            Dim UserModuleAccess As AdvantageFramework.Security.Database.Entities.UserModuleAccess = Nothing
            Dim UserModAccess As AdvantageFramework.Security.Database.Classes.UserModuleAccess = Nothing
            Dim PropertyDescriptorEntity As System.ComponentModel.PropertyDescriptor = Nothing
            Dim PropertyDescriptorClass As System.ComponentModel.PropertyDescriptor = Nothing

            If _UserModuleAccessList IsNot Nothing Then

                Try

                    PropertyDescriptorEntity = (From [Property] In System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.Security.Database.Entities.UserModuleAccess)).OfType(Of System.ComponentModel.PropertyDescriptor)()
                                                Where [Property].Name = UserModuleAccessProperty.ToString
                                                Select [Property]).SingleOrDefault

                Catch ex As Exception
                    PropertyDescriptorEntity = Nothing
                End Try

                Try

                    PropertyDescriptorClass = (From [Property] In System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.Security.Database.Classes.UserModuleAccess)).OfType(Of System.ComponentModel.PropertyDescriptor)()
                                               Where [Property].Name = UserModuleAccessProperty.ToString
                                               Select [Property]).SingleOrDefault

                Catch ex As Exception
                    PropertyDescriptorClass = Nothing
                End Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    For Each [Module] In ModuleList

                        For Each UserModAccess In _UserModuleAccessList

                            Try

                                UserModuleAccess = SecurityDbContext.GetQuery(Of AdvantageFramework.Security.Database.Entities.UserModuleAccess).SingleOrDefault(Function(UsrModAccess) UsrModAccess.ModuleID = [Module].ModuleID AndAlso UsrModAccess.UserID = UserModAccess.UserID)

                            Catch ex As Exception
                                UserModuleAccess = Nothing
                            End Try

                            If UserModuleAccess IsNot Nothing Then

                                If PropertyDescriptorEntity IsNot Nothing Then

                                    PropertyDescriptorEntity.SetValue(UserModuleAccess, NewValue)

                                End If

                                If PropertyDescriptorClass IsNot Nothing Then

                                    PropertyDescriptorClass.SetValue(UserModAccess, NewValue)

                                End If

                                SecurityDbContext.UpdateObject(UserModuleAccess)

                            End If

                        Next

                    Next

                    SecurityDbContext.SaveChanges()

                End Using

            End If

        End Sub
        Private Sub SetAllGroupModuleAccess(ByVal ModuleList As Generic.List(Of AdvantageFramework.Security.Database.Views.ModuleView), ByVal GroupModuleAccessProperty As AdvantageFramework.Security.Database.Entities.GroupModuleAccess.Properties, ByVal NewValue As Boolean)

            'objects
            Dim [Module] As AdvantageFramework.Security.Database.Views.ModuleView = Nothing
            Dim GroupModuleAccess As AdvantageFramework.Security.Database.Entities.GroupModuleAccess = Nothing
            Dim GroupModAccess As AdvantageFramework.Security.Database.Classes.GroupModuleAccess = Nothing
            Dim PropertyDescriptorEntity As System.ComponentModel.PropertyDescriptor = Nothing
            Dim PropertyDescriptorClass As System.ComponentModel.PropertyDescriptor = Nothing

            If _GroupModuleAccessList IsNot Nothing Then

                Try

                    PropertyDescriptorEntity = (From [Property] In System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.Security.Database.Entities.GroupModuleAccess)).OfType(Of System.ComponentModel.PropertyDescriptor)()
                                                Where [Property].Name = GroupModuleAccessProperty.ToString
                                                Select [Property]).SingleOrDefault

                Catch ex As Exception
                    PropertyDescriptorEntity = Nothing
                End Try

                Try

                    PropertyDescriptorClass = (From [Property] In System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.Security.Database.Classes.GroupModuleAccess)).OfType(Of System.ComponentModel.PropertyDescriptor)()
                                               Where [Property].Name = GroupModuleAccessProperty.ToString
                                               Select [Property]).SingleOrDefault

                Catch ex As Exception
                    PropertyDescriptorClass = Nothing
                End Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    For Each [Module] In ModuleList

                        For Each GroupModAccess In _GroupModuleAccessList

                            Try

                                GroupModuleAccess = SecurityDbContext.GetQuery(Of AdvantageFramework.Security.Database.Entities.GroupModuleAccess).SingleOrDefault(Function(GrpModAccess) GrpModAccess.ModuleID = [Module].ModuleID AndAlso GrpModAccess.GroupID = GroupModAccess.GroupID)

                            Catch ex As Exception
                                GroupModuleAccess = Nothing
                            End Try

                            If GroupModuleAccess IsNot Nothing Then

                                If PropertyDescriptorEntity IsNot Nothing Then

                                    PropertyDescriptorEntity.SetValue(GroupModuleAccess, NewValue)

                                End If

                                If PropertyDescriptorClass IsNot Nothing Then

                                    PropertyDescriptorClass.SetValue(GroupModAccess, NewValue)

                                End If

                                SecurityDbContext.UpdateObject(GroupModuleAccess)

                            End If

                        Next

                    Next

                    SecurityDbContext.SaveChanges()

                End Using

            End If

        End Sub
        Private Function LoadSelectedNodes() As Generic.List(Of AdvantageFramework.Security.Database.Views.ModuleView)

            'objects
            Dim ApplicationID As Integer = 0
            Dim ModuleCode As String = ""
            Dim ModuleCodes As Generic.List(Of String) = Nothing
            Dim [Module] As AdvantageFramework.Security.Database.Views.ModuleView = Nothing
            Dim ModuleList As Generic.List(Of AdvantageFramework.Security.Database.Views.ModuleView) = Nothing

            ModuleCodes = New Generic.List(Of String)

            For Each SelectedNode In AdvTreeForm_Modules.SelectedNodes.OfType(Of DevComponents.AdvTree.Node).ToList

                Try

                    ModuleCode = SelectedNode.TagString

                Catch ex As Exception
                    ModuleCode = Nothing
                End Try

                If String.IsNullOrWhiteSpace(ModuleCode) = False Then

                    ModuleCodes.Add(ModuleCode)

                End If

            Next

            If ModuleCodes.Count > 0 AndAlso ComboBoxForm_Application.HasASelectedValue Then

                ApplicationID = ComboBoxForm_Application.GetSelectedValue

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ModuleList = AdvantageFramework.Security.Database.Procedures.ModuleView.Load(SecurityDbContext).Where(Function(ModView) ModView.ApplicationID = ApplicationID AndAlso ModView.IsCategory = False AndAlso ModuleCodes.Contains(ModView.ModuleCode) = True).ToList

                End Using

            End If

            If ModuleList Is Nothing Then

                ModuleList = New Generic.List(Of AdvantageFramework.Security.Database.Views.ModuleView)

            End If

            LoadSelectedNodes = ModuleList

        End Function
        Private Sub LoadGroupModuleAccessGrid()

            'objects
            Dim AllSelectedModulesHaveSameOptions As Boolean = True
            Dim FirstSelectedModule As AdvantageFramework.Security.Database.Views.ModuleView = Nothing

            LoadSelectedModuleInformation(FirstSelectedModule, Nothing, AllSelectedModulesHaveSameOptions)

            DataGridViewForm_GroupAccess.DataSource = _GroupModuleAccessList

            ButtonItemGroupBlocking_BlockAll.Enabled = True
            ButtonItemGroupBlocking_UnblockAll.Enabled = True

            DataGridViewForm_GroupAccess.CurrentView.BeginUpdate()

            For Each GridColumn In DataGridViewForm_GroupAccess.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                GridColumn.Visible = False

            Next

            DataGridViewForm_GroupAccess.MakeColumnVisible(AdvantageFramework.Security.Database.Classes.GroupModuleAccess.Properties.Group.ToString)
            DataGridViewForm_GroupAccess.MakeColumnVisible(AdvantageFramework.Security.Database.Classes.GroupModuleAccess.Properties.IsBlocked.ToString)

            If FirstSelectedModule.HasCustomPermission AndAlso AllSelectedModulesHaveSameOptions Then

                DataGridViewForm_GroupAccess.MakeColumnVisible(AdvantageFramework.Security.Database.Classes.UserModuleAccess.Properties.CanPrint.ToString)
                DataGridViewForm_GroupAccess.MakeColumnVisible(AdvantageFramework.Security.Database.Classes.UserModuleAccess.Properties.CanUpdate.ToString)
                DataGridViewForm_GroupAccess.MakeColumnVisible(AdvantageFramework.Security.Database.Classes.UserModuleAccess.Properties.CanAdd.ToString)
                DataGridViewForm_GroupAccess.MakeColumnVisible(AdvantageFramework.Security.Database.Classes.UserModuleAccess.Properties.Custom1.ToString)
                DataGridViewForm_GroupAccess.MakeColumnVisible(AdvantageFramework.Security.Database.Classes.UserModuleAccess.Properties.Custom2.ToString)

            End If

            DataGridViewForm_GroupAccess.CurrentView.BestFitColumns()

            DataGridViewForm_GroupAccess.CurrentView.EndUpdate()

        End Sub
        Private Sub LoadUserModuleAccessGrid()

            'objects
            Dim AllSelectedModulesHaveSameOptions As Boolean = True
            Dim FirstSelectedModule As AdvantageFramework.Security.Database.Views.ModuleView = Nothing

            LoadSelectedModuleInformation(FirstSelectedModule, Nothing, AllSelectedModulesHaveSameOptions)

            If ButtonItemEmployees_Terminated.Checked Then

                DataGridViewForm_UserAccess.DataSource = _UserModuleAccessList

            Else

                DataGridViewForm_UserAccess.DataSource = _UserModuleAccessList.Where(Function(UserModuleAccess) UserModuleAccess.EmployeeTerminationDate Is Nothing).ToList

            End If

            ButtonItemUserBlocking_BlockAll.Enabled = True
            ButtonItemUserBlocking_UnblockAll.Enabled = True

            DataGridViewForm_UserAccess.CurrentView.BeginUpdate()

            For Each GridColumn In DataGridViewForm_UserAccess.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                GridColumn.Visible = False

            Next

            DataGridViewForm_UserAccess.MakeColumnVisible(AdvantageFramework.Security.Database.Classes.UserModuleAccess.Properties.UserCode.ToString)
            DataGridViewForm_UserAccess.MakeColumnVisible(AdvantageFramework.Security.Database.Classes.UserModuleAccess.Properties.EmployeeCode.ToString)
            DataGridViewForm_UserAccess.MakeColumnVisible(AdvantageFramework.Security.Database.Classes.UserModuleAccess.Properties.EmployeeName.ToString)
            DataGridViewForm_UserAccess.MakeColumnVisible(AdvantageFramework.Security.Database.Classes.UserModuleAccess.Properties.OfficeCode.ToString)
            DataGridViewForm_UserAccess.MakeColumnVisible(AdvantageFramework.Security.Database.Classes.UserModuleAccess.Properties.OfficeName.ToString)
            DataGridViewForm_UserAccess.MakeColumnVisible(AdvantageFramework.Security.Database.Classes.UserModuleAccess.Properties.DepartmentCode.ToString)
            DataGridViewForm_UserAccess.MakeColumnVisible(AdvantageFramework.Security.Database.Classes.UserModuleAccess.Properties.DepartmentName.ToString)

            If FirstSelectedModule IsNot Nothing Then

                DataGridViewForm_UserAccess.MakeColumnVisible(AdvantageFramework.Security.Database.Classes.UserModuleAccess.Properties.IsBlocked.ToString)

            End If

            If FirstSelectedModule IsNot Nothing AndAlso FirstSelectedModule.HasCustomPermission AndAlso AllSelectedModulesHaveSameOptions Then

                DataGridViewForm_UserAccess.MakeColumnVisible(AdvantageFramework.Security.Database.Classes.UserModuleAccess.Properties.CanPrint.ToString)
                DataGridViewForm_UserAccess.MakeColumnVisible(AdvantageFramework.Security.Database.Classes.UserModuleAccess.Properties.CanUpdate.ToString)
                DataGridViewForm_UserAccess.MakeColumnVisible(AdvantageFramework.Security.Database.Classes.UserModuleAccess.Properties.CanAdd.ToString)
                DataGridViewForm_UserAccess.MakeColumnVisible(AdvantageFramework.Security.Database.Classes.UserModuleAccess.Properties.Custom1.ToString)
                DataGridViewForm_UserAccess.MakeColumnVisible(AdvantageFramework.Security.Database.Classes.UserModuleAccess.Properties.Custom2.ToString)

            End If

            DataGridViewForm_UserAccess.CurrentView.BestFitColumns()

            DataGridViewForm_UserAccess.CurrentView.EndUpdate()

        End Sub
        Private Sub LoadSelectedModuleInformation(ByRef FirstSelectedModule As AdvantageFramework.Security.Database.Views.ModuleView,
                                                  ByRef SelectedModuleList As Generic.List(Of AdvantageFramework.Security.Database.Views.ModuleView),
                                                  ByRef AllSelectedModulesHaveSameOptions As Boolean)

            'objects
            Dim [Module] As AdvantageFramework.Security.Database.Views.ModuleView = Nothing

            If SelectedModuleList Is Nothing Then

                SelectedModuleList = New Generic.List(Of AdvantageFramework.Security.Database.Views.ModuleView)

            End If

            For Each [Module] In LoadSelectedNodes()

                If [Module].IsCategory = False Then

                    SelectedModuleList.Add([Module])

                    If FirstSelectedModule Is Nothing Then

                        FirstSelectedModule = [Module]

                    Else

                        If FirstSelectedModule.HasCustomPermission <> [Module].HasCustomPermission Then

                            AllSelectedModulesHaveSameOptions = False

                        End If

                    End If

                End If

                If AllSelectedModulesHaveSameOptions = False Then

                    Exit For

                End If

            Next

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim ModuleAccessForm As AdvantageFramework.Security.Setup.Presentation.ModuleAccessForm = Nothing

            ModuleAccessForm = New AdvantageFramework.Security.Setup.Presentation.ModuleAccessForm()

            ModuleAccessForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub ModuleAccessForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            DataGridViewForm_GroupAccess.MultiSelect = False
            DataGridViewForm_UserAccess.MultiSelect = False
            DataGridViewForm_GroupAccess.OptionsView.ShowFooter = False
            DataGridViewForm_UserAccess.OptionsView.ShowFooter = False

            ButtonItemShow_Modules.Image = AdvantageFramework.My.Resources.ModuleImage
            ButtonItemShow_Reports.Image = AdvantageFramework.My.Resources.ReportImage
            ButtonItemShow_DashboardAndQueries.Image = AdvantageFramework.My.Resources.DashboardAndQueryImage
            ButtonItemShow_DesktopObjects.Image = AdvantageFramework.My.Resources.DesktopObjectImage

            ButtonItemEmployees_Terminated.Image = AdvantageFramework.My.Resources.ShowInactiveImage

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ComboBoxForm_Application.DataSource = AdvantageFramework.Security.Database.Procedures.Application.Load(SecurityDbContext).Where(Function(Application) Application.ID = AdvantageFramework.Security.Application.Advantage OrElse Application.ID = AdvantageFramework.Security.Application.Webvantage)

                _GroupModuleAccessList = (From Group In AdvantageFramework.Security.Database.Procedures.Group.Load(SecurityDbContext).Include("GroupModuleAccesses").ToList
                                          Select New AdvantageFramework.Security.Database.Classes.GroupModuleAccess(Group)).ToList

                _UserModuleAccessList = (From User In AdvantageFramework.Security.Database.Procedures.User.Load(SecurityDbContext).Include("Employee").Include("UserModuleAccesses").Include("Employee.Department").Include("Employee.Office").ToList
                                         Select New AdvantageFramework.Security.Database.Classes.UserModuleAccess(User)).ToList

                DataGridViewForm_GroupAccess.DataSource = _GroupModuleAccessList
                DataGridViewForm_UserAccess.DataSource = _UserModuleAccessList.Where(Function(UserModuleAccess) UserModuleAccess.EmployeeTerminationDate Is Nothing).ToList

                For Each GridColumn In DataGridViewForm_GroupAccess.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                    GridColumn.Visible = False

                Next

                For Each GridColumn In DataGridViewForm_UserAccess.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                    GridColumn.Visible = False

                Next

                DataGridViewForm_GroupAccess.MakeColumnVisible(AdvantageFramework.Security.Database.Classes.GroupModuleAccess.Properties.Group.ToString)

                DataGridViewForm_UserAccess.MakeColumnVisible(AdvantageFramework.Security.Database.Classes.UserModuleAccess.Properties.UserCode.ToString)
                DataGridViewForm_UserAccess.MakeColumnVisible(AdvantageFramework.Security.Database.Classes.UserModuleAccess.Properties.EmployeeCode.ToString)
                DataGridViewForm_UserAccess.MakeColumnVisible(AdvantageFramework.Security.Database.Classes.UserModuleAccess.Properties.EmployeeName.ToString)
                DataGridViewForm_UserAccess.MakeColumnVisible(AdvantageFramework.Security.Database.Classes.UserModuleAccess.Properties.OfficeCode.ToString)
                DataGridViewForm_UserAccess.MakeColumnVisible(AdvantageFramework.Security.Database.Classes.UserModuleAccess.Properties.OfficeName.ToString)
                DataGridViewForm_UserAccess.MakeColumnVisible(AdvantageFramework.Security.Database.Classes.UserModuleAccess.Properties.DepartmentCode.ToString)
                DataGridViewForm_UserAccess.MakeColumnVisible(AdvantageFramework.Security.Database.Classes.UserModuleAccess.Properties.DepartmentName.ToString)

                SetupUserAndGroupAccessGrids(False, False)

                DataGridViewForm_GroupAccess.CurrentView.BestFitColumns()
                DataGridViewForm_UserAccess.CurrentView.BestFitColumns()

            End Using

            ButtonItemUserBlocking_BlockAll.Enabled = False
            ButtonItemUserBlocking_UnblockAll.Enabled = False
            ButtonItemUserPrinting_AllCanPrint.Enabled = False
            ButtonItemUserPrinting_AllCantPrint.Enabled = False
            ButtonItemUserUpdating_AllCanUpdate.Enabled = False
            ButtonItemUserUpdating_AllCantUpdate.Enabled = False
            ButtonItemUserAdding_AllCanAdd.Enabled = False
            ButtonItemUserAdding_AllCantAdd.Enabled = False
            ButtonItemUserCustom1_AllRightsCustom1.Enabled = False
            ButtonItemUserCustom1_AllNoRightsCustom1.Enabled = False
            ButtonItemUserCustom2_AllRightsCustom2.Enabled = False
            ButtonItemUserCustom2_AllNoRightsCustom2.Enabled = False

            ButtonItemGroupBlocking_BlockAll.Enabled = False
            ButtonItemGroupBlocking_UnblockAll.Enabled = False
            ButtonItemGroupPrinting_AllCanPrint.Enabled = False
            ButtonItemGroupPrinting_AllCantPrint.Enabled = False
            ButtonItemGroupUpdating_AllCanUpdate.Enabled = False
            ButtonItemGroupUpdating_AllCantUpdate.Enabled = False
            ButtonItemGroupAdding_AllCanAdd.Enabled = False
            ButtonItemGroupAdding_AllCantAdd.Enabled = False
            ButtonItemGroupCustom1_AllRightsCustom1.Enabled = False
            ButtonItemGroupCustom1_AllNoRightsCustom1.Enabled = False
            ButtonItemGroupCustom2_AllRightsCustom2.Enabled = False
            ButtonItemGroupCustom2_AllNoRightsCustom2.Enabled = False

            _ToolTipController = New DevExpress.Utils.ToolTipController()

            DataGridViewForm_GroupAccess.GridControl.ToolTipController = _ToolTipController
            DataGridViewForm_UserAccess.GridControl.ToolTipController = _ToolTipController

        End Sub
        Private Sub ModuleAccessForm_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown

            'objects
            Dim RibbonControl As DevComponents.DotNetBar.RibbonControl = Nothing

            If RibbonBarMergeContainerForm_Options.RibbonTabItem IsNot Nothing Then

                Try

                    RibbonControl = Me.MdiParent.Controls("RibbonControlForm_MainRibbon")

                Catch ex As Exception
                    RibbonControl = Nothing
                End Try

                If RibbonControl IsNot Nothing Then

                    RibbonControl.SelectedRibbonTabItem = RibbonBarMergeContainerForm_Options.RibbonTabItem

                End If

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub _ToolTipController_GetActiveObjectInfo(ByVal sender As Object, ByVal e As DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs) Handles _ToolTipController.GetActiveObjectInfo

            'objects
            Dim ToolTipControlInfo As DevExpress.Utils.ToolTipControlInfo = Nothing
            Dim GridView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
            Dim GridHitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = Nothing
            Dim RowID As Integer = 0
            Dim ToolTipText As String = Nothing
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

            If AdvTreeForm_Modules.SelectedNode IsNot Nothing AndAlso (AdvTreeForm_Modules.SelectedNode.Tag = AdvantageFramework.Security.Modules.Employee_ExpenseReports.ToString OrElse
                                                                       AdvTreeForm_Modules.SelectedNode.Tag = AdvantageFramework.Security.Modules.Maintenance_Accounting_Vendor.ToString OrElse
                                                                       AdvTreeForm_Modules.SelectedNode.Tag = AdvantageFramework.Security.Modules.Maintenance_Accounting_Employee.ToString OrElse
                                                                       AdvTreeForm_Modules.SelectedNode.Tag = AdvantageFramework.Security.Modules.Media_MediaManager.ToString OrElse
                                                                       AdvTreeForm_Modules.SelectedNode.Tag = AdvantageFramework.Security.Modules.ProjectManagement_ProjectSchedule.ToString OrElse
                                                                       AdvTreeForm_Modules.SelectedNode.Tag = AdvantageFramework.Security.Modules.ProjectManagement_Boards.ToString) Then

                If e.SelectedControl Is DataGridViewForm_GroupAccess.GridControl Then

                    GridView = CType(DataGridViewForm_GroupAccess.GridControl.GetViewAt(e.ControlMousePosition), DevExpress.XtraGrid.Views.Grid.GridView)

                ElseIf e.SelectedControl Is DataGridViewForm_UserAccess.GridControl Then

                    GridView = CType(DataGridViewForm_UserAccess.GridControl.GetViewAt(e.ControlMousePosition), DevExpress.XtraGrid.Views.Grid.GridView)

                End If

                Try

                    If GridView IsNot Nothing Then

                        GridHitInfo = GridView.CalcHitInfo(e.ControlMousePosition)

                        If GridHitInfo.InRowCell AndAlso GridHitInfo.Column.FieldName = AdvantageFramework.Security.Database.Classes.UserModuleAccess.Properties.Custom1.ToString Then

                            ToolTipText = AdvantageFramework.Security.GetToolTip(AdvTreeForm_Modules.SelectedNode.Tag, GridHitInfo.Column.FieldName)

                        ElseIf GridHitInfo.InRowCell AndAlso GridHitInfo.Column.FieldName = AdvantageFramework.Security.Database.Classes.UserModuleAccess.Properties.Custom2.ToString Then

                            ToolTipText = AdvantageFramework.Security.GetToolTip(AdvTreeForm_Modules.SelectedNode.Tag, GridHitInfo.Column.FieldName)

                        End If

                        If String.IsNullOrEmpty(ToolTipText) = False Then

                            ToolTipControlInfo = New DevExpress.Utils.ToolTipControlInfo(RowID, ToolTipText)

                        End If

                    End If

                Catch ex As Exception

                Finally
                    e.Info = ToolTipControlInfo
                End Try

            End If

        End Sub
        Private Sub ComboBoxForm_Application_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxForm_Application.SelectedValueChanged

            If Me.HasLoaded AndAlso ComboBoxForm_Application.HasASelectedValue Then

                AdvTreeForm_Modules.Nodes.Clear()

                LoadModules(ComboBoxForm_Application.GetSelectedValue)

            End If

        End Sub
        Private Sub ButtonItemShow_DashboardAndQueries_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemShow_DashboardAndQueries.CheckedChanged

            If Me.HasLoaded AndAlso ComboBoxForm_Application.HasASelectedValue Then

                AdvTreeForm_Modules.Nodes.Clear()

                LoadModules(ComboBoxForm_Application.GetSelectedValue)

            End If

        End Sub
        Private Sub ButtonItemShow_DesktopObjects_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemShow_DesktopObjects.CheckedChanged

            If Me.HasLoaded AndAlso ComboBoxForm_Application.HasASelectedValue Then

                AdvTreeForm_Modules.Nodes.Clear()

                LoadModules(ComboBoxForm_Application.GetSelectedValue)

            End If

        End Sub
        Private Sub ButtonItemShow_Modules_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemShow_Modules.CheckedChanged

            If Me.HasLoaded AndAlso ComboBoxForm_Application.HasASelectedValue Then

                AdvTreeForm_Modules.Nodes.Clear()

                LoadModules(ComboBoxForm_Application.GetSelectedValue)

            End If

        End Sub
        Private Sub ButtonItemShow_Reports_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemShow_Reports.CheckedChanged

            If Me.HasLoaded AndAlso ComboBoxForm_Application.HasASelectedValue Then

                AdvTreeForm_Modules.Nodes.Clear()

                LoadModules(ComboBoxForm_Application.GetSelectedValue)

            End If

        End Sub
        Private Sub AdvTreeForm_Modules_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles AdvTreeForm_Modules.SelectionChanged

            'objects
            Dim [Module] As AdvantageFramework.Security.Database.Views.ModuleView = Nothing
            Dim AllSelectedModulesHaveSameOptions As Boolean = True
            Dim FirstSelectedModule As AdvantageFramework.Security.Database.Views.ModuleView = Nothing
            Dim SelectedModuleList As Generic.List(Of AdvantageFramework.Security.Database.Views.ModuleView) = Nothing
            Dim GroupModuleAccessList As Generic.List(Of AdvantageFramework.Security.Database.Classes.GroupModuleAccess) = Nothing
            Dim UserModuleAccessList As Generic.List(Of AdvantageFramework.Security.Database.Classes.UserModuleAccess) = Nothing

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                LoadSelectedModuleInformation(FirstSelectedModule, SelectedModuleList, AllSelectedModulesHaveSameOptions)

                If FirstSelectedModule IsNot Nothing Then

                    Me.ShowWaitForm()
                    Me.ShowWaitForm("Processing...")

                    Try

                        _GroupModuleAccessList = (From Group In AdvantageFramework.Security.Database.Procedures.Group.Load(SecurityDbContext).Include("GroupModuleAccesses").ToList
                                                  Select New AdvantageFramework.Security.Database.Classes.GroupModuleAccess(Group, SelectedModuleList)).ToList

                        _UserModuleAccessList = (From User In AdvantageFramework.Security.Database.Procedures.User.Load(SecurityDbContext).Include("Employee").Include("UserModuleAccesses").ToList
                                                 Select New AdvantageFramework.Security.Database.Classes.UserModuleAccess(User, SelectedModuleList)).ToList

                    Catch ex As Exception

                    End Try

                    Me.CloseWaitForm()

                    DataGridViewForm_GroupAccess.DataSource = _GroupModuleAccessList
                    DataGridViewForm_UserAccess.DataSource = _UserModuleAccessList

                    ButtonItemUserBlocking_BlockAll.Enabled = True
                    ButtonItemUserBlocking_UnblockAll.Enabled = True

                    ButtonItemGroupBlocking_BlockAll.Enabled = True
                    ButtonItemGroupBlocking_UnblockAll.Enabled = True

                    DataGridViewForm_GroupAccess.CurrentView.BeginUpdate()
                    DataGridViewForm_UserAccess.CurrentView.BeginUpdate()

                    For Each GridColumn In DataGridViewForm_GroupAccess.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                        GridColumn.Visible = False

                    Next

                    For Each GridColumn In DataGridViewForm_UserAccess.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                        GridColumn.Visible = False

                    Next

                    DataGridViewForm_GroupAccess.MakeColumnVisible(AdvantageFramework.Security.Database.Classes.GroupModuleAccess.Properties.Group.ToString)
                    DataGridViewForm_GroupAccess.MakeColumnVisible(AdvantageFramework.Security.Database.Classes.GroupModuleAccess.Properties.IsBlocked.ToString)

                    DataGridViewForm_UserAccess.MakeColumnVisible(AdvantageFramework.Security.Database.Classes.UserModuleAccess.Properties.UserCode.ToString)
                    DataGridViewForm_UserAccess.MakeColumnVisible(AdvantageFramework.Security.Database.Classes.UserModuleAccess.Properties.EmployeeCode.ToString)
                    DataGridViewForm_UserAccess.MakeColumnVisible(AdvantageFramework.Security.Database.Classes.UserModuleAccess.Properties.EmployeeName.ToString)
                    DataGridViewForm_UserAccess.MakeColumnVisible(AdvantageFramework.Security.Database.Classes.UserModuleAccess.Properties.OfficeCode.ToString)
                    DataGridViewForm_UserAccess.MakeColumnVisible(AdvantageFramework.Security.Database.Classes.UserModuleAccess.Properties.OfficeName.ToString)
                    DataGridViewForm_UserAccess.MakeColumnVisible(AdvantageFramework.Security.Database.Classes.UserModuleAccess.Properties.DepartmentCode.ToString)
                    DataGridViewForm_UserAccess.MakeColumnVisible(AdvantageFramework.Security.Database.Classes.UserModuleAccess.Properties.DepartmentName.ToString)
                    DataGridViewForm_UserAccess.MakeColumnVisible(AdvantageFramework.Security.Database.Classes.UserModuleAccess.Properties.IsBlocked.ToString)

                    SetupUserAndGroupAccessGrids(FirstSelectedModule.HasCustomPermission, AllSelectedModulesHaveSameOptions)

                    DataGridViewForm_GroupAccess.CurrentView.EndUpdate()
                    DataGridViewForm_UserAccess.CurrentView.EndUpdate()

                    DataGridViewForm_GroupAccess.CurrentView.BestFitColumns()
                    DataGridViewForm_UserAccess.CurrentView.BestFitColumns()

                Else

                    DataGridViewForm_GroupAccess.CurrentView.BeginUpdate()
                    DataGridViewForm_UserAccess.CurrentView.BeginUpdate()

                    For Each GridColumn In DataGridViewForm_GroupAccess.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                        GridColumn.Visible = False

                    Next

                    For Each GridColumn In DataGridViewForm_UserAccess.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                        GridColumn.Visible = False

                    Next

                    DataGridViewForm_GroupAccess.MakeColumnVisible(AdvantageFramework.Security.Database.Classes.GroupModuleAccess.Properties.Group.ToString)

                    DataGridViewForm_UserAccess.MakeColumnVisible(AdvantageFramework.Security.Database.Classes.UserModuleAccess.Properties.UserCode.ToString)
                    DataGridViewForm_UserAccess.MakeColumnVisible(AdvantageFramework.Security.Database.Classes.UserModuleAccess.Properties.EmployeeCode.ToString)
                    DataGridViewForm_UserAccess.MakeColumnVisible(AdvantageFramework.Security.Database.Classes.UserModuleAccess.Properties.EmployeeName.ToString)
                    DataGridViewForm_UserAccess.MakeColumnVisible(AdvantageFramework.Security.Database.Classes.UserModuleAccess.Properties.OfficeCode.ToString)
                    DataGridViewForm_UserAccess.MakeColumnVisible(AdvantageFramework.Security.Database.Classes.UserModuleAccess.Properties.OfficeName.ToString)
                    DataGridViewForm_UserAccess.MakeColumnVisible(AdvantageFramework.Security.Database.Classes.UserModuleAccess.Properties.DepartmentCode.ToString)
                    DataGridViewForm_UserAccess.MakeColumnVisible(AdvantageFramework.Security.Database.Classes.UserModuleAccess.Properties.DepartmentName.ToString)

                    SetupUserAndGroupAccessGrids(False, False)

                    DataGridViewForm_GroupAccess.CurrentView.EndUpdate()
                    DataGridViewForm_UserAccess.CurrentView.EndUpdate()

                    DataGridViewForm_GroupAccess.CurrentView.BestFitColumns()
                    DataGridViewForm_UserAccess.CurrentView.BestFitColumns()

                    ButtonItemUserBlocking_BlockAll.Enabled = False
                    ButtonItemUserBlocking_UnblockAll.Enabled = False
                    ButtonItemUserPrinting_AllCanPrint.Enabled = False
                    ButtonItemUserPrinting_AllCantPrint.Enabled = False
                    ButtonItemUserUpdating_AllCanUpdate.Enabled = False
                    ButtonItemUserUpdating_AllCantUpdate.Enabled = False
                    ButtonItemUserAdding_AllCanAdd.Enabled = False
                    ButtonItemUserAdding_AllCantAdd.Enabled = False
                    ButtonItemUserCustom1_AllRightsCustom1.Enabled = False
                    ButtonItemUserCustom1_AllNoRightsCustom1.Enabled = False
                    ButtonItemUserCustom2_AllRightsCustom2.Enabled = False
                    ButtonItemUserCustom2_AllNoRightsCustom2.Enabled = False

                    ButtonItemGroupBlocking_BlockAll.Enabled = False
                    ButtonItemGroupBlocking_UnblockAll.Enabled = False
                    ButtonItemGroupPrinting_AllCanPrint.Enabled = False
                    ButtonItemGroupPrinting_AllCantPrint.Enabled = False
                    ButtonItemGroupUpdating_AllCanUpdate.Enabled = False
                    ButtonItemGroupUpdating_AllCantUpdate.Enabled = False
                    ButtonItemGroupAdding_AllCanAdd.Enabled = False
                    ButtonItemGroupAdding_AllCantAdd.Enabled = False
                    ButtonItemGroupCustom1_AllRightsCustom1.Enabled = False
                    ButtonItemGroupCustom1_AllNoRightsCustom1.Enabled = False
                    ButtonItemGroupCustom2_AllRightsCustom2.Enabled = False
                    ButtonItemGroupCustom2_AllNoRightsCustom2.Enabled = False

                End If

            End Using

            Me.ClearChanged()

        End Sub
        Private Sub DataGridViewForm_GroupAccess_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_GroupAccess.CellValueChangingEvent

            'objects
            Dim [Module] As AdvantageFramework.Security.Database.Views.ModuleView = Nothing
            Dim GroupModuleAccess As AdvantageFramework.Security.Database.Entities.GroupModuleAccess = Nothing
            Dim GroupModAccess As AdvantageFramework.Security.Database.Classes.GroupModuleAccess = Nothing
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim ModuleList As Generic.List(Of AdvantageFramework.Security.Database.Views.ModuleView) = Nothing

            GroupModAccess = DataGridViewForm_GroupAccess.CurrentView.GetRow(e.RowHandle)

            If GroupModAccess IsNot Nothing Then

                ModuleList = LoadSelectedNodes()

                Me.ShowWaitForm()
                Me.ShowWaitForm("Processing...")

                Try

                    Try

                        PropertyDescriptor = System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.Security.Database.Entities.GroupModuleAccess)).OfType(Of System.ComponentModel.PropertyDescriptor).Where(Function(PropDesc) PropDesc.Name = e.Column.FieldName).SingleOrDefault

                    Catch ex As Exception
                        PropertyDescriptor = Nothing
                    End Try

                    If PropertyDescriptor IsNot Nothing Then

                        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each [Module] In ModuleList

                                Try

                                    GroupModuleAccess = SecurityDbContext.GetQuery(Of AdvantageFramework.Security.Database.Entities.GroupModuleAccess).SingleOrDefault(Function(GrpModAccess) GrpModAccess.ModuleID = [Module].ModuleID AndAlso GrpModAccess.GroupID = GroupModAccess.GroupID)

                                Catch ex As Exception
                                    GroupModuleAccess = Nothing
                                End Try

                                If GroupModuleAccess IsNot Nothing Then

                                    PropertyDescriptor.SetValue(GroupModuleAccess, e.Value)

                                    SecurityDbContext.UpdateObject(GroupModuleAccess)

                                End If

                            Next

                            SecurityDbContext.SaveChanges()

                        End Using

                    End If

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewForm_UserAccess_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_UserAccess.CellValueChangingEvent

            'objects
            Dim [Module] As AdvantageFramework.Security.Database.Views.ModuleView = Nothing
            Dim UserModuleAccess As AdvantageFramework.Security.Database.Entities.UserModuleAccess = Nothing
            Dim UserModAccess As AdvantageFramework.Security.Database.Classes.UserModuleAccess = Nothing
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim ModuleList As Generic.List(Of AdvantageFramework.Security.Database.Views.ModuleView) = Nothing

            UserModAccess = DataGridViewForm_UserAccess.CurrentView.GetRow(e.RowHandle)

            If UserModAccess IsNot Nothing Then

                ModuleList = LoadSelectedNodes()

                Me.ShowWaitForm()
                Me.ShowWaitForm("Processing...")

                Try

                    Try

                        PropertyDescriptor = System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.Security.Database.Entities.UserModuleAccess)).OfType(Of System.ComponentModel.PropertyDescriptor).Where(Function(PropDesc) PropDesc.Name = e.Column.FieldName).SingleOrDefault

                    Catch ex As Exception
                        PropertyDescriptor = Nothing
                    End Try

                    If PropertyDescriptor IsNot Nothing Then

                        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            SecurityDbContext.Database.Connection.Open()
                            SecurityDbContext.Configuration.AutoDetectChangesEnabled = False

                            For Each [Module] In ModuleList

                                Try

                                    UserModuleAccess = SecurityDbContext.GetQuery(Of AdvantageFramework.Security.Database.Entities.UserModuleAccess).SingleOrDefault(Function(UsrModAccess) UsrModAccess.ModuleID = [Module].ModuleID AndAlso UsrModAccess.UserID = UserModAccess.UserID)

                                Catch ex As Exception
                                    UserModuleAccess = Nothing
                                End Try

                                If UserModuleAccess IsNot Nothing Then

                                    PropertyDescriptor.SetValue(UserModuleAccess, e.Value)

                                    SecurityDbContext.UpdateObject(UserModuleAccess)

                                Else

                                    UserModuleAccess = New AdvantageFramework.Security.Database.Entities.UserModuleAccess

                                    UserModuleAccess.UserID = UserModAccess.UserID
                                    UserModuleAccess.ModuleID = [Module].ModuleID
                                    UserModuleAccess.IsBlocked = UserModAccess.IsBlocked
                                    UserModuleAccess.CanPrint = UserModAccess.CanPrint
                                    UserModuleAccess.CanUpdate = UserModAccess.CanUpdate
                                    UserModuleAccess.CanAdd = UserModAccess.CanAdd
                                    UserModuleAccess.Custom1 = UserModAccess.Custom1
                                    UserModuleAccess.Custom2 = UserModAccess.Custom2

                                    SecurityDbContext.UserModuleAccesses.Add(UserModuleAccess)

                                    PropertyDescriptor.SetValue(UserModuleAccess, e.Value)

                                End If

                            Next

                            SecurityDbContext.Configuration.AutoDetectChangesEnabled = True

                            SecurityDbContext.SaveChanges()

                        End Using

                    End If


                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemView_ExpandAll_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemView_ExpandAll.Click

            AdvTreeForm_Modules.ExpandAll()

        End Sub
        Private Sub ButtonItemView_CollapseAll_Click(sender As Object, e As System.EventArgs) Handles ButtonItemView_CollapseAll.Click

            AdvTreeForm_Modules.CollapseAll()

        End Sub
        Private Sub ButtonItemUserBlocking_BlockAll_Click(sender As Object, e As System.EventArgs) Handles ButtonItemUserBlocking_BlockAll.Click

            'DataGridViewForm_UserAccess.DataSource = Nothing

            Me.ShowWaitForm()
            Me.ShowWaitForm("Processing...")

            Try

                SetAllUserModuleAccess(LoadSelectedNodes, Database.Entities.UserModuleAccess.Properties.IsBlocked, True)

            Catch ex As Exception

            End Try

            Me.CloseWaitForm()

            LoadUserModuleAccessGrid()

        End Sub
        Private Sub ButtonItemUserBlocking_UnblockAll_Click(sender As Object, e As System.EventArgs) Handles ButtonItemUserBlocking_UnblockAll.Click

            'DataGridViewForm_UserAccess.DataSource = Nothing

            Me.ShowWaitForm()
            Me.ShowWaitForm("Processing...")

            Try

                SetAllUserModuleAccess(LoadSelectedNodes, Database.Entities.UserModuleAccess.Properties.IsBlocked, False)

            Catch ex As Exception

            End Try

            Me.CloseWaitForm()

            LoadUserModuleAccessGrid()

        End Sub
        Private Sub ButtonItemUserPrinting_AllCanPrint_Click(sender As Object, e As System.EventArgs) Handles ButtonItemUserPrinting_AllCanPrint.Click

            'DataGridViewForm_UserAccess.DataSource = Nothing

            Me.ShowWaitForm()
            Me.ShowWaitForm("Processing...")

            Try

                SetAllUserModuleAccess(LoadSelectedNodes, Database.Entities.UserModuleAccess.Properties.CanPrint, True)

            Catch ex As Exception

            End Try

            Me.CloseWaitForm()

            LoadUserModuleAccessGrid()

        End Sub
        Private Sub ButtonItemUserPrinting_AllCantPrint_Click(sender As Object, e As System.EventArgs) Handles ButtonItemUserPrinting_AllCantPrint.Click

            'DataGridViewForm_UserAccess.DataSource = Nothing

            Me.ShowWaitForm()
            Me.ShowWaitForm("Processing...")

            Try

                SetAllUserModuleAccess(LoadSelectedNodes, Database.Entities.UserModuleAccess.Properties.CanPrint, False)

            Catch ex As Exception

            End Try

            Me.CloseWaitForm()

            LoadUserModuleAccessGrid()

        End Sub
        Private Sub ButtonItemUserUpdating_AllCanUpdate_Click(sender As Object, e As System.EventArgs) Handles ButtonItemUserUpdating_AllCanUpdate.Click

            'DataGridViewForm_UserAccess.DataSource = Nothing

            Me.ShowWaitForm()
            Me.ShowWaitForm("Processing...")

            Try

                SetAllUserModuleAccess(LoadSelectedNodes, Database.Entities.UserModuleAccess.Properties.CanUpdate, True)

            Catch ex As Exception

            End Try

            Me.CloseWaitForm()

            LoadUserModuleAccessGrid()

        End Sub
        Private Sub ButtonItemUserUpdating_AllCantUpdate_Click(sender As Object, e As System.EventArgs) Handles ButtonItemUserUpdating_AllCantUpdate.Click

            'DataGridViewForm_UserAccess.DataSource = Nothing

            Me.ShowWaitForm()
            Me.ShowWaitForm("Processing...")

            Try

                SetAllUserModuleAccess(LoadSelectedNodes, Database.Entities.UserModuleAccess.Properties.CanUpdate, False)

            Catch ex As Exception

            End Try

            Me.CloseWaitForm()

            LoadUserModuleAccessGrid()

        End Sub
        Private Sub ButtonItemUserAdding_AllCanAdd_Click(sender As Object, e As System.EventArgs) Handles ButtonItemUserAdding_AllCanAdd.Click

            'DataGridViewForm_UserAccess.DataSource = Nothing

            Me.ShowWaitForm()
            Me.ShowWaitForm("Processing...")

            Try

                SetAllUserModuleAccess(LoadSelectedNodes, Database.Entities.UserModuleAccess.Properties.CanAdd, True)

            Catch ex As Exception

            End Try

            Me.CloseWaitForm()

            LoadUserModuleAccessGrid()

        End Sub
        Private Sub ButtonItemUserAdding_AllCantAdd_Click(sender As Object, e As System.EventArgs) Handles ButtonItemUserAdding_AllCantAdd.Click

            'DataGridViewForm_UserAccess.DataSource = Nothing

            Me.ShowWaitForm()
            Me.ShowWaitForm("Processing...")

            Try

                SetAllUserModuleAccess(LoadSelectedNodes, Database.Entities.UserModuleAccess.Properties.CanAdd, False)

            Catch ex As Exception

            End Try

            Me.CloseWaitForm()

            LoadUserModuleAccessGrid()

        End Sub
        Private Sub ButtonItemUserCustom1_AllRightsCustom1_Click(sender As Object, e As System.EventArgs) Handles ButtonItemUserCustom1_AllRightsCustom1.Click

            'DataGridViewForm_UserAccess.DataSource = Nothing

            Me.ShowWaitForm()
            Me.ShowWaitForm("Processing...")

            Try

                SetAllUserModuleAccess(LoadSelectedNodes, Database.Entities.UserModuleAccess.Properties.Custom1, True)

            Catch ex As Exception

            End Try

            Me.CloseWaitForm()

            LoadUserModuleAccessGrid()

        End Sub
        Private Sub ButtonItemUserCustom1_AllNoRightsCustom1_Click(sender As Object, e As System.EventArgs) Handles ButtonItemUserCustom1_AllNoRightsCustom1.Click

            'DataGridViewForm_UserAccess.DataSource = Nothing

            Me.ShowWaitForm()
            Me.ShowWaitForm("Processing...")

            Try

                SetAllUserModuleAccess(LoadSelectedNodes, Database.Entities.UserModuleAccess.Properties.Custom1, False)

            Catch ex As Exception

            End Try

            Me.CloseWaitForm()

            LoadUserModuleAccessGrid()

        End Sub
        Private Sub ButtonItemUserCustom2_AllRightsCustom2_Click(sender As Object, e As System.EventArgs) Handles ButtonItemUserCustom2_AllRightsCustom2.Click

            'DataGridViewForm_UserAccess.DataSource = Nothing

            Me.ShowWaitForm()
            Me.ShowWaitForm("Processing...")

            Try

                SetAllUserModuleAccess(LoadSelectedNodes, Database.Entities.UserModuleAccess.Properties.Custom2, True)

            Catch ex As Exception

            End Try

            Me.CloseWaitForm()

            LoadUserModuleAccessGrid()

        End Sub
        Private Sub ButtonItemUserCustom2_AllNoRightsCustom2_Click(sender As Object, e As System.EventArgs) Handles ButtonItemUserCustom2_AllNoRightsCustom2.Click

            'DataGridViewForm_UserAccess.DataSource = Nothing

            Me.ShowWaitForm()
            Me.ShowWaitForm("Processing...")

            Try

                SetAllUserModuleAccess(LoadSelectedNodes, Database.Entities.UserModuleAccess.Properties.Custom2, False)

            Catch ex As Exception

            End Try

            Me.CloseWaitForm()

            LoadUserModuleAccessGrid()

        End Sub
        Private Sub ButtonItemGroupBlocking_BlockAll_Click(sender As Object, e As System.EventArgs) Handles ButtonItemGroupBlocking_BlockAll.Click

            'DataGridViewForm_GroupAccess.DataSource = Nothing

            Me.ShowWaitForm()
            Me.ShowWaitForm("Processing...")

            Try

                SetAllGroupModuleAccess(LoadSelectedNodes, Database.Entities.GroupModuleAccess.Properties.IsBlocked, True)

            Catch ex As Exception

            End Try

            Me.CloseWaitForm()

            LoadGroupModuleAccessGrid()

        End Sub
        Private Sub ButtonItemGroupBlocking_UnblockAll_Click(sender As Object, e As System.EventArgs) Handles ButtonItemGroupBlocking_UnblockAll.Click

            'DataGridViewForm_GroupAccess.DataSource = Nothing

            Me.ShowWaitForm()
            Me.ShowWaitForm("Processing...")

            Try

                SetAllGroupModuleAccess(LoadSelectedNodes, Database.Entities.GroupModuleAccess.Properties.IsBlocked, False)

            Catch ex As Exception

            End Try

            Me.CloseWaitForm()

            LoadGroupModuleAccessGrid()

        End Sub
        Private Sub ButtonItemGroupPrinting_AllCanPrint_Click(sender As Object, e As System.EventArgs) Handles ButtonItemGroupPrinting_AllCanPrint.Click

            'DataGridViewForm_GroupAccess.DataSource = Nothing

            Me.ShowWaitForm()
            Me.ShowWaitForm("Processing...")

            Try

                SetAllGroupModuleAccess(LoadSelectedNodes, Database.Entities.GroupModuleAccess.Properties.CanPrint, True)

            Catch ex As Exception

            End Try

            Me.CloseWaitForm()

            LoadGroupModuleAccessGrid()

        End Sub
        Private Sub ButtonItemGroupPrinting_AllCantPrint_Click(sender As Object, e As System.EventArgs) Handles ButtonItemGroupPrinting_AllCantPrint.Click

            'DataGridViewForm_GroupAccess.DataSource = Nothing

            Me.ShowWaitForm()
            Me.ShowWaitForm("Processing...")

            Try

                SetAllGroupModuleAccess(LoadSelectedNodes, Database.Entities.GroupModuleAccess.Properties.CanPrint, False)

            Catch ex As Exception

            End Try

            Me.CloseWaitForm()

            LoadGroupModuleAccessGrid()

        End Sub
        Private Sub ButtonItemGroupUpdating_AllCanUpdate_Click(sender As Object, e As System.EventArgs) Handles ButtonItemGroupUpdating_AllCanUpdate.Click

            'DataGridViewForm_GroupAccess.DataSource = Nothing

            Me.ShowWaitForm()
            Me.ShowWaitForm("Processing...")

            Try

                SetAllGroupModuleAccess(LoadSelectedNodes, Database.Entities.GroupModuleAccess.Properties.CanUpdate, True)

            Catch ex As Exception

            End Try

            Me.CloseWaitForm()

            LoadGroupModuleAccessGrid()

        End Sub
        Private Sub ButtonItemGroupUpdating_AllCantUpdate_Click(sender As Object, e As System.EventArgs) Handles ButtonItemGroupUpdating_AllCantUpdate.Click

            'DataGridViewForm_GroupAccess.DataSource = Nothing

            Me.ShowWaitForm()
            Me.ShowWaitForm("Processing...")

            Try

                SetAllGroupModuleAccess(LoadSelectedNodes, Database.Entities.GroupModuleAccess.Properties.CanUpdate, False)

            Catch ex As Exception

            End Try

            Me.CloseWaitForm()

            LoadGroupModuleAccessGrid()

        End Sub
        Private Sub ButtonItemGroupAdding_AllCanAdd_Click(sender As Object, e As System.EventArgs) Handles ButtonItemGroupAdding_AllCanAdd.Click

            'DataGridViewForm_GroupAccess.DataSource = Nothing

            Me.ShowWaitForm()
            Me.ShowWaitForm("Processing...")

            Try

                SetAllGroupModuleAccess(LoadSelectedNodes, Database.Entities.GroupModuleAccess.Properties.CanAdd, True)

            Catch ex As Exception

            End Try

            Me.CloseWaitForm()

            LoadGroupModuleAccessGrid()

        End Sub
        Private Sub ButtonItemGroupAdding_AllCantAdd_Click(sender As Object, e As System.EventArgs) Handles ButtonItemGroupAdding_AllCantAdd.Click

            'DataGridViewForm_GroupAccess.DataSource = Nothing

            Me.ShowWaitForm()
            Me.ShowWaitForm("Processing...")

            Try

                SetAllGroupModuleAccess(LoadSelectedNodes, Database.Entities.GroupModuleAccess.Properties.CanAdd, False)

            Catch ex As Exception

            End Try

            Me.CloseWaitForm()

            LoadGroupModuleAccessGrid()

        End Sub
        Private Sub ButtonItemGroupCustom1_AllRightsCustom1_Click(sender As Object, e As System.EventArgs) Handles ButtonItemGroupCustom1_AllRightsCustom1.Click

            'DataGridViewForm_GroupAccess.DataSource = Nothing

            Me.ShowWaitForm()
            Me.ShowWaitForm("Processing...")

            Try

                SetAllGroupModuleAccess(LoadSelectedNodes, Database.Entities.GroupModuleAccess.Properties.Custom1, True)

            Catch ex As Exception

            End Try

            Me.CloseWaitForm()

            LoadGroupModuleAccessGrid()

        End Sub
        Private Sub ButtonItemGroupCustom1_AllNoRightsCustom1_Click(sender As Object, e As System.EventArgs) Handles ButtonItemGroupCustom1_AllNoRightsCustom1.Click

            'DataGridViewForm_GroupAccess.DataSource = Nothing

            Me.ShowWaitForm()
            Me.ShowWaitForm("Processing...")

            Try

                SetAllGroupModuleAccess(LoadSelectedNodes, Database.Entities.GroupModuleAccess.Properties.Custom1, False)

            Catch ex As Exception

            End Try

            Me.CloseWaitForm()

            LoadGroupModuleAccessGrid()

        End Sub
        Private Sub ButtonItemGroupCustom2_AllRightsCustom2_Click(sender As Object, e As System.EventArgs) Handles ButtonItemGroupCustom2_AllRightsCustom2.Click

            'DataGridViewForm_GroupAccess.DataSource = Nothing

            Me.ShowWaitForm()
            Me.ShowWaitForm("Processing...")

            Try

                SetAllGroupModuleAccess(LoadSelectedNodes, Database.Entities.GroupModuleAccess.Properties.Custom2, True)

            Catch ex As Exception

            End Try

            Me.CloseWaitForm()

            LoadGroupModuleAccessGrid()

        End Sub
        Private Sub ButtonItemGroupCustom2_AllNoRightsCustom2_Click(sender As Object, e As System.EventArgs) Handles ButtonItemGroupCustom2_AllNoRightsCustom2.Click

            'DataGridViewForm_GroupAccess.DataSource = Nothing

            Me.ShowWaitForm()
            Me.ShowWaitForm("Processing...")

            Try

                SetAllGroupModuleAccess(LoadSelectedNodes, Database.Entities.GroupModuleAccess.Properties.Custom2, False)

            Catch ex As Exception

            End Try

            Me.CloseWaitForm()

            LoadGroupModuleAccessGrid()

        End Sub
        Private Sub ButtonItemShowBy_All_CheckedChanged(sender As Object, e As System.EventArgs) Handles ButtonItemShowBy_All.CheckedChanged

            'objects
            Dim ApplicationID As Integer = 0

            If ButtonItemShowBy_All.Checked Then

                If Me.HasLoaded AndAlso ComboBoxForm_Application.HasASelectedValue Then

                    AdvTreeForm_Modules.Nodes.Clear()

                    ApplicationID = ComboBoxForm_Application.GetSelectedValue

                    Me.ShowWaitForm()
                    Me.ShowWaitForm("Processing...")

                    Try

                        LoadModules(ApplicationID)

                    Catch ex As Exception

                    End Try

                    Me.CloseWaitForm()

                End If

            End If

        End Sub
        Private Sub ButtonItemShowBy_AllBlocked_CheckedChanged(sender As Object, e As System.EventArgs) Handles ButtonItemShowBy_AllBlocked.CheckedChanged

            'objects
            Dim ApplicationID As Integer = 0

            If ButtonItemShowBy_AllBlocked.Checked Then

                If Me.HasLoaded AndAlso ComboBoxForm_Application.HasASelectedValue Then

                    AdvTreeForm_Modules.Nodes.Clear()

                    ApplicationID = ComboBoxForm_Application.GetSelectedValue

                    Me.ShowWaitForm()
                    Me.ShowWaitForm("Processing...")

                    Try

                        LoadModules(ApplicationID)

                    Catch ex As Exception

                    End Try

                    Me.CloseWaitForm()

                End If

            End If

        End Sub
        Private Sub ButtonItemShowBy_AllUnblocked_CheckedChanged(sender As Object, e As System.EventArgs) Handles ButtonItemShowBy_AllUnblocked.CheckedChanged

            'objects
            Dim ApplicationID As Integer = 0

            If ButtonItemShowBy_AllUnblocked.Checked Then

                If Me.HasLoaded AndAlso ComboBoxForm_Application.HasASelectedValue Then

                    AdvTreeForm_Modules.Nodes.Clear()

                    ApplicationID = ComboBoxForm_Application.GetSelectedValue

                    Me.ShowWaitForm()
                    Me.ShowWaitForm("Processing...")

                    Try

                        LoadModules(ApplicationID)

                    Catch ex As Exception

                    End Try

                    Me.CloseWaitForm()

                End If

            End If

        End Sub
        Private Sub ButtonItemEmployees_Terminated_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemEmployees_Terminated.CheckedChanged

            If Me.FormShown Then

                LoadUserModuleAccessGrid()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace