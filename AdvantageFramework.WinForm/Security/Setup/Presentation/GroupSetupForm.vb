Namespace Security.Setup.Presentation

    Public Class GroupSetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _LoadGroupModuleAccess As Boolean = False
        Private _LoadGroupGroupSettings As Boolean = False
        Private _GroupList As Generic.List(Of AdvantageFramework.Security.Database.Entities.Group) = Nothing
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
        Private Sub LoadGrid()

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewLeftSection_Groups.DataSource = AdvantageFramework.Security.Database.Procedures.Group.Load(SecurityDbContext)

            End Using

            DataGridViewLeftSection_Groups.CurrentView.BestFitColumns()

            If DataGridViewLeftSection_Groups.HasRows = False Then

                ClearGroupDetail()

            End If

        End Sub
        Private Sub LoadSelectedItemDetails(ByVal TabItem As DevComponents.DotNetBar.TabItem)

            'objects
            Dim ClearGroupDetails As Boolean = False
            Dim GroupIDArray() As Integer = Nothing

            Me.FormAction = WinForm.Presentation.FormActions.LoadingSelectedItem

            Try

                If DataGridViewLeftSection_Groups.HasASelectedRow Then

                    If TabItem Is Nothing Then

                        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            GroupIDArray = DataGridViewLeftSection_Groups.GetAllSelectedRowsBookmarkValues().OfType(Of Integer).ToArray()

                            _GroupList = AdvantageFramework.Security.Database.Procedures.Group.LoadByGroupIDs(SecurityDbContext, GroupIDArray).Include("GroupUsers").Include("GroupUsers.User").Include("GroupModuleAccesses").Include("GroupSettings").Include("GroupApplicationAccesses").ToList

                        End Using

                        For Each TabItem In TabControlRightSection_GroupDetails.Tabs.OfType(Of DevComponents.DotNetBar.TabItem)()

                            TabItem.Tag = False

                        Next

                        TabItem = TabControlRightSection_GroupDetails.SelectedTab

                    End If

                    If TabItem Is TabItemGroupDetails_UsersTab AndAlso TabItem.Tag = False Then

                        LoadGroupUser()

                    ElseIf TabItem Is TabItemGroupDetails_ModuleAccessTab AndAlso TabItem.Tag = False Then

                        LoadGroupApplicationAccess()

                        LoadGroupModuleAccess()

                    ElseIf TabItem Is TabItemGroupDetails_GroupSettingsTab AndAlso TabItem.Tag = False Then

                        LoadGroupSettings()

                    ElseIf TabItem Is TabItemGroupDetails_WorkspacesTab AndAlso TabItem.Tag = False Then

                        LoadUserAppliedWorkspaceTemplate()

                    End If

                Else

                    _GroupList = Nothing

                    ClearGroupDetails = True

                End If

                If ClearGroupDetails Then

                    ClearGroupDetail()

                End If

                LoadGroupNameAndDescription()

                Me.ClearChanged()

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonItemActions_Delete.Enabled = (DataGridViewLeftSection_Groups.HasOnlyOneSelectedRow AndAlso Me.FormShown)
            ButtonItemActions_Save.Enabled = Me.UserEntryChanged
            ButtonItemActions_Copy.Enabled = (DataGridViewLeftSection_Groups.HasOnlyOneSelectedRow AndAlso Me.FormShown)

            TextBoxRightSection_Description.Enabled = (DataGridViewLeftSection_Groups.HasOnlyOneSelectedRow AndAlso Me.FormShown)
            TextBoxRightSection_Name.Enabled = (DataGridViewLeftSection_Groups.HasOnlyOneSelectedRow AndAlso Me.FormShown)

            TabControlRightSection_GroupDetails.Enabled = (DataGridViewLeftSection_Groups.HasASelectedRow AndAlso Me.FormShown)

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            'objects
            Dim IsOkay As Boolean = True

            If Me.CheckUserEntryChangedSetting Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    IsOkay = Me.Validator

                    If IsOkay Then

                        IsOkay = False

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                        Try

                            IsOkay = Save()

                        Catch ex As Exception
                            AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                        End Try

                        If IsOkay = False Then

                            If AdvantageFramework.Navigation.ShowMessageBox("Saving failed. Do you want to continue without saving?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                                IsOkay = True

                            End If

                        End If

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.ClearValidations()

                    End If

                End If

            End If

            CheckForUnsavedChanges = IsOkay

        End Function
        Private Sub SaveGroupSettings(ByVal CheckBox As AdvantageFramework.WinForm.Presentation.Controls.CheckBox)

            'objects
            Dim GroupSetting As AdvantageFramework.Security.Database.Entities.GroupSetting = Nothing

            If _LoadGroupGroupSettings = False AndAlso _GroupList IsNot Nothing AndAlso _GroupList.Count > 0 Then

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    For Each Group In _GroupList

                        Try

                            GroupSetting = Group.GroupSettings.SingleOrDefault(Function(GrpSetting) GrpSetting.SettingCode = CheckBox.Tag)

                        Catch ex As Exception
                            GroupSetting = Nothing
                        End Try

                        Select Case CheckBox.Name

                            Case CheckBoxGroupSettings_AllowGroupToAddHolidays.Name

                                If GroupSetting Is Nothing Then

                                    If AdvantageFramework.Security.Database.Procedures.GroupSetting.Insert(SecurityDbContext, Group.ID, AdvantageFramework.Security.GroupSettings.Calendar_AllowGroupToAddHolidays.ToString, IIf(CheckBoxGroupSettings_AllowGroupToAddHolidays.Checked, "Y", "N"), Nothing, Nothing, GroupSetting) Then

                                        Group.GroupSettings.Add(GroupSetting)

                                    End If

                                Else

                                    GroupSetting.StringValue = IIf(CheckBoxGroupSettings_AllowGroupToAddHolidays.Checked, "Y", "N")

                                    AdvantageFramework.Security.Database.Procedures.GroupSetting.Update(SecurityDbContext, GroupSetting)

                                End If

                            Case CheckBoxGroupSettings_AllowGroupToViewOtherEmployees.Name

                                If GroupSetting Is Nothing Then

                                    If AdvantageFramework.Security.Database.Procedures.GroupSetting.Insert(SecurityDbContext, Group.ID, AdvantageFramework.Security.GroupSettings.Calendar_AllowGroupToAddHolidays.ToString, IIf(CheckBoxGroupSettings_AllowGroupToViewOtherEmployees.Checked, "Y", "N"), Nothing, Nothing, GroupSetting) Then

                                        Group.GroupSettings.Add(GroupSetting)

                                    End If

                                Else

                                    GroupSetting.StringValue = IIf(CheckBoxGroupSettings_AllowGroupToViewOtherEmployees.Checked, "Y", "N")

                                    AdvantageFramework.Security.Database.Procedures.GroupSetting.Update(SecurityDbContext, GroupSetting)

                                End If

                            Case CheckBoxGroupSettings_ShowAllAssignments.Name

                                If GroupSetting Is Nothing Then

                                    If AdvantageFramework.Security.Database.Procedures.GroupSetting.Insert(SecurityDbContext, Group.ID, AdvantageFramework.Security.GroupSettings.AlertInbox_ShowAllAssignments.ToString, IIf(CheckBoxGroupSettings_ShowAllAssignments.Checked, "Y", "N"), Nothing, Nothing, GroupSetting) Then

                                        Group.GroupSettings.Add(GroupSetting)

                                    End If

                                Else

                                    GroupSetting.StringValue = IIf(CheckBoxGroupSettings_ShowAllAssignments.Checked, "Y", "N")

                                    AdvantageFramework.Security.Database.Procedures.GroupSetting.Update(SecurityDbContext, GroupSetting)

                                End If

                            Case CheckBoxGroupSettings_ShowUnassignedAssignments.Name

                                If GroupSetting Is Nothing Then

                                    If AdvantageFramework.Security.Database.Procedures.GroupSetting.Insert(SecurityDbContext, Group.ID, AdvantageFramework.Security.GroupSettings.AlertInbox_ShowUnassignedAssignments.ToString, IIf(CheckBoxGroupSettings_ShowUnassignedAssignments.Checked, "Y", "N"), Nothing, Nothing, GroupSetting) Then

                                        Group.GroupSettings.Add(GroupSetting)

                                    End If

                                Else

                                    GroupSetting.StringValue = IIf(CheckBoxGroupSettings_ShowUnassignedAssignments.Checked, "Y", "N")

                                    AdvantageFramework.Security.Database.Procedures.GroupSetting.Update(SecurityDbContext, GroupSetting)

                                End If

                            Case CheckBoxGroupSettings_AllowTaskEdit.Name

                                If GroupSetting Is Nothing Then

                                    If AdvantageFramework.Security.Database.Procedures.GroupSetting.Insert(SecurityDbContext, Group.ID, AdvantageFramework.Security.GroupSettings.Schedule_AllowTaskEdit.ToString, IIf(CheckBoxGroupSettings_AllowTaskEdit.Checked, "Y", "N"), Nothing, Nothing, GroupSetting) Then

                                        Group.GroupSettings.Add(GroupSetting)

                                    End If

                                Else

                                    GroupSetting.StringValue = IIf(CheckBoxGroupSettings_AllowTaskEdit.Checked, "Y", "N")

                                    AdvantageFramework.Security.Database.Procedures.GroupSetting.Update(SecurityDbContext, GroupSetting)

                                End If

                            Case CheckBoxGroupSettings_AllowMediaPageEdit.Name

                                If GroupSetting Is Nothing Then

                                    If AdvantageFramework.Security.Database.Procedures.GroupSetting.Insert(SecurityDbContext, Group.ID, AdvantageFramework.Security.GroupSettings.Schedule_AllowMediaPageEdit.ToString, IIf(CheckBoxGroupSettings_AllowMediaPageEdit.Checked, "Y", "N"), Nothing, Nothing, GroupSetting) Then

                                        Group.GroupSettings.Add(GroupSetting)

                                    End If

                                Else

                                    GroupSetting.StringValue = IIf(CheckBoxGroupSettings_AllowMediaPageEdit.Checked, "Y", "N")

                                    AdvantageFramework.Security.Database.Procedures.GroupSetting.Update(SecurityDbContext, GroupSetting)

                                End If

                            Case CheckBoxGroupSettings_CanUpload.Name

                                If GroupSetting Is Nothing Then

                                    If AdvantageFramework.Security.Database.Procedures.GroupSetting.Insert(SecurityDbContext, Group.ID, AdvantageFramework.Security.GroupSettings.DocumentManager_CanUpload.ToString, IIf(CheckBoxGroupSettings_CanUpload.Checked, "Y", "N"), Nothing, Nothing, GroupSetting) Then

                                        Group.GroupSettings.Add(GroupSetting)

                                    End If

                                Else

                                    GroupSetting.StringValue = IIf(CheckBoxGroupSettings_CanUpload.Checked, "Y", "N")

                                    AdvantageFramework.Security.Database.Procedures.GroupSetting.Update(SecurityDbContext, GroupSetting)

                                End If

                            Case CheckBoxGroupSettings_ViewPrivateDocuments.Name

                                If GroupSetting Is Nothing Then

                                    If AdvantageFramework.Security.Database.Procedures.GroupSetting.Insert(SecurityDbContext, Group.ID, AdvantageFramework.Security.GroupSettings.DocumentManager_ViewPrivateDocuments.ToString, IIf(CheckBoxGroupSettings_ViewPrivateDocuments.Checked, "Y", "N"), Nothing, Nothing, GroupSetting) Then

                                        Group.GroupSettings.Add(GroupSetting)

                                    End If

                                Else

                                    GroupSetting.StringValue = IIf(CheckBoxGroupSettings_ViewPrivateDocuments.Checked, "Y", "N")

                                    AdvantageFramework.Security.Database.Procedures.GroupSetting.Update(SecurityDbContext, GroupSetting)

                                End If

                            Case CheckBoxGroupSettings_CreateWorkspaceTemplate.Name

                                If GroupSetting Is Nothing Then

                                    If AdvantageFramework.Security.Database.Procedures.GroupSetting.Insert(SecurityDbContext, Group.ID, AdvantageFramework.Security.GroupSettings.Workspace_Template_Create.ToString, IIf(CheckBoxGroupSettings_CreateWorkspaceTemplate.Checked, "Y", "N"), Nothing, Nothing, GroupSetting) Then

                                        Group.GroupSettings.Add(GroupSetting)

                                    End If

                                Else

                                    GroupSetting.StringValue = IIf(CheckBoxGroupSettings_CreateWorkspaceTemplate.Checked, "Y", "N")

                                    AdvantageFramework.Security.Database.Procedures.GroupSetting.Update(SecurityDbContext, GroupSetting)

                                End If

                        End Select

                    Next

                End Using

            End If

        End Sub
        Private Sub LoadGroupSettings()

            'objects
            Dim GroupSettingList As Generic.List(Of AdvantageFramework.Security.Database.Entities.GroupSetting) = Nothing
            Dim GroupSetting As AdvantageFramework.Security.Database.Entities.GroupSetting = Nothing

            _LoadGroupGroupSettings = True

            CheckBoxGroupSettings_AllowGroupToAddHolidays.Checked = True
            CheckBoxGroupSettings_AllowGroupToViewOtherEmployees.Checked = True
            CheckBoxGroupSettings_ShowAllAssignments.Checked = True
            CheckBoxGroupSettings_ShowUnassignedAssignments.Checked = True
            CheckBoxGroupSettings_AllowTaskEdit.Checked = True
            CheckBoxGroupSettings_AllowMediaPageEdit.Checked = True
            CheckBoxGroupSettings_CanUpload.Checked = True
            CheckBoxGroupSettings_ViewPrivateDocuments.Checked = True
            CheckBoxGroupSettings_CreateWorkspaceTemplate.Checked = True

            If _GroupList IsNot Nothing AndAlso _GroupList.Count > 0 Then

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)
                    '-----------------------------------------------------------------------------------------------
                    '-----------------------------------------------------------------------------------------------
                    '-----------------------------------------------------------------------------------------------
                    GroupSettingList = New Generic.List(Of AdvantageFramework.Security.Database.Entities.GroupSetting)

                    For Each GroupSetting In _GroupList.SelectMany(Function(Group) Group.GroupSettings.Where(Function(GrpSetting) GrpSetting.SettingCode = AdvantageFramework.Security.GroupSettings.Calendar_AllowGroupToAddHolidays.ToString))

                        GroupSettingList.Add(GroupSetting)

                        If GroupSetting.StringValue = "N" OrElse GroupSetting.StringValue = Nothing Then

                            CheckBoxGroupSettings_AllowGroupToAddHolidays.Checked = False

                        End If

                    Next

                    If GroupSettingList.Count = 0 Then

                        CheckBoxGroupSettings_AllowGroupToAddHolidays.Checked = False

                    End If

                    CheckBoxGroupSettings_AllowGroupToAddHolidays.Tag = AdvantageFramework.Security.GroupSettings.Calendar_AllowGroupToAddHolidays.ToString
                    '-----------------------------------------------------------------------------------------------
                    '-----------------------------------------------------------------------------------------------
                    '-----------------------------------------------------------------------------------------------
                    GroupSettingList = New Generic.List(Of AdvantageFramework.Security.Database.Entities.GroupSetting)

                    For Each GroupSetting In _GroupList.SelectMany(Function(Group) Group.GroupSettings.Where(Function(GrpSetting) GrpSetting.SettingCode = AdvantageFramework.Security.GroupSettings.Calendar_AllowGroupToViewOtherEmployees.ToString))

                        GroupSettingList.Add(GroupSetting)

                        If GroupSetting.StringValue = "N" OrElse GroupSetting.StringValue = Nothing Then

                            CheckBoxGroupSettings_AllowGroupToViewOtherEmployees.Checked = False

                        End If

                    Next

                    If GroupSettingList.Count = 0 Then

                        CheckBoxGroupSettings_AllowGroupToViewOtherEmployees.Checked = False

                    End If

                    CheckBoxGroupSettings_AllowGroupToViewOtherEmployees.Tag = AdvantageFramework.Security.GroupSettings.Calendar_AllowGroupToViewOtherEmployees.ToString
                    '-----------------------------------------------------------------------------------------------
                    '-----------------------------------------------------------------------------------------------
                    '-----------------------------------------------------------------------------------------------
                    GroupSettingList = New Generic.List(Of AdvantageFramework.Security.Database.Entities.GroupSetting)

                    For Each GroupSetting In _GroupList.SelectMany(Function(Group) Group.GroupSettings.Where(Function(GrpSetting) GrpSetting.SettingCode = AdvantageFramework.Security.GroupSettings.AlertInbox_ShowAllAssignments.ToString))

                        GroupSettingList.Add(GroupSetting)

                        If GroupSetting.StringValue = "N" OrElse GroupSetting.StringValue = Nothing Then

                            CheckBoxGroupSettings_ShowAllAssignments.Checked = False

                        End If

                    Next

                    If GroupSettingList.Count = 0 Then

                        CheckBoxGroupSettings_ShowAllAssignments.Checked = False

                    End If

                    CheckBoxGroupSettings_ShowAllAssignments.Tag = AdvantageFramework.Security.GroupSettings.AlertInbox_ShowAllAssignments.ToString
                    '-----------------------------------------------------------------------------------------------
                    '-----------------------------------------------------------------------------------------------
                    '-----------------------------------------------------------------------------------------------
                    GroupSettingList = New Generic.List(Of AdvantageFramework.Security.Database.Entities.GroupSetting)

                    For Each GroupSetting In _GroupList.SelectMany(Function(Group) Group.GroupSettings.Where(Function(GrpSetting) GrpSetting.SettingCode = AdvantageFramework.Security.GroupSettings.AlertInbox_ShowUnassignedAssignments.ToString))

                        GroupSettingList.Add(GroupSetting)

                        If GroupSetting.StringValue = "N" OrElse GroupSetting.StringValue = Nothing Then

                            CheckBoxGroupSettings_ShowUnassignedAssignments.Checked = False

                        End If

                    Next

                    If GroupSettingList.Count = 0 Then

                        CheckBoxGroupSettings_ShowUnassignedAssignments.Checked = False

                    End If

                    CheckBoxGroupSettings_ShowUnassignedAssignments.Tag = AdvantageFramework.Security.GroupSettings.AlertInbox_ShowUnassignedAssignments.ToString
                    '-----------------------------------------------------------------------------------------------
                    '-----------------------------------------------------------------------------------------------
                    '-----------------------------------------------------------------------------------------------
                    GroupSettingList = New Generic.List(Of AdvantageFramework.Security.Database.Entities.GroupSetting)

                    For Each GroupSetting In _GroupList.SelectMany(Function(Group) Group.GroupSettings.Where(Function(GrpSetting) GrpSetting.SettingCode = AdvantageFramework.Security.GroupSettings.Schedule_AllowTaskEdit.ToString))

                        GroupSettingList.Add(GroupSetting)

                        If GroupSetting.StringValue = "N" OrElse GroupSetting.StringValue = Nothing Then

                            CheckBoxGroupSettings_AllowTaskEdit.Checked = False

                        End If

                    Next

                    If GroupSettingList.Count = 0 Then

                        CheckBoxGroupSettings_AllowTaskEdit.Checked = False

                    End If

                    CheckBoxGroupSettings_AllowTaskEdit.Tag = AdvantageFramework.Security.GroupSettings.Schedule_AllowTaskEdit.ToString
                    '-----------------------------------------------------------------------------------------------
                    '-----------------------------------------------------------------------------------------------
                    '-----------------------------------------------------------------------------------------------
                    GroupSettingList = New Generic.List(Of AdvantageFramework.Security.Database.Entities.GroupSetting)

                    For Each GroupSetting In _GroupList.SelectMany(Function(Group) Group.GroupSettings.Where(Function(GrpSetting) GrpSetting.SettingCode = AdvantageFramework.Security.GroupSettings.Schedule_AllowMediaPageEdit.ToString))

                        GroupSettingList.Add(GroupSetting)

                        If GroupSetting.StringValue = "N" OrElse GroupSetting.StringValue = Nothing Then

                            CheckBoxGroupSettings_AllowMediaPageEdit.Checked = False

                        End If

                    Next

                    If GroupSettingList.Count = 0 Then

                        CheckBoxGroupSettings_AllowMediaPageEdit.Checked = False

                    End If

                    CheckBoxGroupSettings_AllowMediaPageEdit.Tag = AdvantageFramework.Security.GroupSettings.Schedule_AllowMediaPageEdit.ToString
                    '-----------------------------------------------------------------------------------------------
                    '-----------------------------------------------------------------------------------------------
                    '-----------------------------------------------------------------------------------------------
                    GroupSettingList = New Generic.List(Of AdvantageFramework.Security.Database.Entities.GroupSetting)

                    For Each GroupSetting In _GroupList.SelectMany(Function(Group) Group.GroupSettings.Where(Function(GrpSetting) GrpSetting.SettingCode = AdvantageFramework.Security.GroupSettings.DocumentManager_CanUpload.ToString))

                        GroupSettingList.Add(GroupSetting)

                        If GroupSetting.StringValue = "N" OrElse GroupSetting.StringValue = Nothing Then

                            CheckBoxGroupSettings_CanUpload.Checked = False

                        End If

                    Next

                    If GroupSettingList.Count = 0 Then

                        CheckBoxGroupSettings_CanUpload.Checked = False

                    End If

                    CheckBoxGroupSettings_CanUpload.Tag = AdvantageFramework.Security.GroupSettings.DocumentManager_CanUpload.ToString
                    '-----------------------------------------------------------------------------------------------
                    '-----------------------------------------------------------------------------------------------
                    '-----------------------------------------------------------------------------------------------
                    GroupSettingList = New Generic.List(Of AdvantageFramework.Security.Database.Entities.GroupSetting)

                    For Each GroupSetting In _GroupList.SelectMany(Function(Group) Group.GroupSettings.Where(Function(GrpSetting) GrpSetting.SettingCode = AdvantageFramework.Security.GroupSettings.DocumentManager_ViewPrivateDocuments.ToString))

                        GroupSettingList.Add(GroupSetting)

                        If GroupSetting.StringValue = "N" OrElse GroupSetting.StringValue = Nothing Then

                            CheckBoxGroupSettings_ViewPrivateDocuments.Checked = False

                        End If

                    Next

                    If GroupSettingList.Count = 0 Then

                        CheckBoxGroupSettings_ViewPrivateDocuments.Checked = False

                    End If

                    CheckBoxGroupSettings_ViewPrivateDocuments.Tag = AdvantageFramework.Security.GroupSettings.DocumentManager_ViewPrivateDocuments.ToString
                    '-----------------------------------------------------------------------------------------------
                    '-----------------------------------------------------------------------------------------------
                    '-----------------------------------------------------------------------------------------------
                    GroupSettingList = New Generic.List(Of AdvantageFramework.Security.Database.Entities.GroupSetting)

                    For Each GroupSetting In _GroupList.SelectMany(Function(Group) Group.GroupSettings.Where(Function(GrpSetting) GrpSetting.SettingCode = AdvantageFramework.Security.GroupSettings.Workspace_Template_Create.ToString))

                        GroupSettingList.Add(GroupSetting)

                        If GroupSetting.StringValue = "N" OrElse GroupSetting.StringValue = Nothing Then

                            CheckBoxGroupSettings_CreateWorkspaceTemplate.Checked = False

                        End If

                    Next

                    If GroupSettingList.Count = 0 Then

                        CheckBoxGroupSettings_CreateWorkspaceTemplate.Checked = False

                    End If

                    CheckBoxGroupSettings_CreateWorkspaceTemplate.Tag = AdvantageFramework.Security.GroupSettings.Workspace_Template_Create.ToString

                    TabItemGroupDetails_GroupSettingsTab.Tag = True

                    _LoadGroupGroupSettings = False

                End Using

            End If

        End Sub
        Private Sub SaveGroupModuleAccess(ByVal GroupModuleAccessProperty As AdvantageFramework.Security.Database.Entities.GroupModuleAccess.Properties, ByVal NewValue As Boolean)

            'objects
            Dim [Module] As AdvantageFramework.Security.Database.Views.ModuleView = Nothing
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim GroupModuleAccess As AdvantageFramework.Security.Database.Entities.GroupModuleAccess = Nothing

            If _LoadGroupModuleAccess = False AndAlso _GroupList IsNot Nothing AndAlso _GroupList.Count > 0 Then

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    For Each SelectedNode In AdvTreeModuleAccess_Modules.SelectedNodes

                        Try

                            [Module] = SelectedNode.Tag

                        Catch ex As Exception
                            [Module] = Nothing
                        End Try

                        If [Module] IsNot Nothing Then

                            If [Module].IsCategory = False Then

                                For Each Group In _GroupList

                                    Try

                                        GroupModuleAccess = Group.GroupModuleAccesses.SingleOrDefault(Function(GrpModAccess) GrpModAccess.ModuleID = [Module].ModuleID)

                                    Catch ex As Exception
                                        GroupModuleAccess = Nothing
                                    End Try

                                    If GroupModuleAccess IsNot Nothing Then

                                        Try

                                            PropertyDescriptor = (From [Property] In System.ComponentModel.TypeDescriptor.GetProperties(GroupModuleAccess).OfType(Of System.ComponentModel.PropertyDescriptor)()
                                                                  Where [Property].Name = GroupModuleAccessProperty.ToString
                                                                  Select [Property]).SingleOrDefault

                                        Catch ex As Exception
                                            PropertyDescriptor = Nothing
                                        End Try

                                        If PropertyDescriptor IsNot Nothing Then

                                            PropertyDescriptor.SetValue(GroupModuleAccess, NewValue)

                                        End If

                                        AdvantageFramework.Security.Database.Procedures.GroupModuleAccess.Update(SecurityDbContext, GroupModuleAccess)

                                    End If

                                Next

                            End If

                        End If

                    Next

                End Using

            End If

        End Sub
        Private Sub LoadGroupModuleAccess()

            'objects
            Dim [Module] As AdvantageFramework.Security.Database.Views.ModuleView = Nothing
            Dim GroupModuleAccess As AdvantageFramework.Security.Database.Entities.GroupModuleAccess = Nothing
            Dim AllSelectedModulesHaveSameOptions As Boolean = True
            Dim FirstSelectedModule As AdvantageFramework.Security.Database.Views.ModuleView = Nothing
            Dim AllGroupModuleAccess As Generic.List(Of AdvantageFramework.Security.Database.Entities.GroupModuleAccess) = Nothing

            For Each SelectedNode In AdvTreeModuleAccess_Modules.SelectedNodes

                Try

                    [Module] = SelectedNode.Tag

                Catch ex As Exception
                    [Module] = Nothing
                Finally

                    If [Module] IsNot Nothing Then

                        If [Module].IsCategory = False Then

                            If FirstSelectedModule Is Nothing Then

                                FirstSelectedModule = [Module]

                            Else

                                If FirstSelectedModule.HasCustomPermission <> [Module].HasCustomPermission Then

                                    AllSelectedModulesHaveSameOptions = False

                                End If

                            End If

                        End If

                    End If

                End Try

            Next

            _LoadGroupModuleAccess = True

            _ToolTipController.SetToolTip(CheckBoxModuleAccess_Custom1, Nothing)
            _ToolTipController.SetToolTip(CheckBoxModuleAccess_Custom2, Nothing)

            If FirstSelectedModule IsNot Nothing Then

                CheckBoxModuleAccess_IsBlocked.Visible = True

                If AllSelectedModulesHaveSameOptions Then

                    CheckBoxModuleAccess_CanPrint.Visible = FirstSelectedModule.HasCustomPermission
                    CheckBoxModuleAccess_CanUpdate.Visible = FirstSelectedModule.HasCustomPermission
                    CheckBoxModuleAccess_CanAdd.Visible = FirstSelectedModule.HasCustomPermission
                    CheckBoxModuleAccess_Custom1.Visible = FirstSelectedModule.HasCustomPermission
                    CheckBoxModuleAccess_Custom2.Visible = FirstSelectedModule.HasCustomPermission

                Else

                    CheckBoxModuleAccess_CanPrint.Visible = False
                    CheckBoxModuleAccess_CanUpdate.Visible = False
                    CheckBoxModuleAccess_CanAdd.Visible = False
                    CheckBoxModuleAccess_Custom1.Visible = False
                    CheckBoxModuleAccess_Custom2.Visible = False

                End If

                If AdvTreeModuleAccess_Modules.SelectedNodes.Count = 1 Then

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        SetToolTips()

                        If _GroupList IsNot Nothing AndAlso _GroupList.Count = 1 Then

                            Try

                                GroupModuleAccess = _GroupList(0).GroupModuleAccesses.SingleOrDefault(Function(GrpModAccess) GrpModAccess.ModuleID = FirstSelectedModule.ModuleID)

                            Catch ex As Exception
                                GroupModuleAccess = Nothing
                            End Try

                            If GroupModuleAccess IsNot Nothing Then

                                CheckBoxModuleAccess_IsBlocked.Checked = GroupModuleAccess.IsBlocked
                                CheckBoxModuleAccess_CanPrint.Checked = GroupModuleAccess.CanPrint
                                CheckBoxModuleAccess_CanUpdate.Checked = GroupModuleAccess.CanUpdate
                                CheckBoxModuleAccess_CanAdd.Checked = GroupModuleAccess.CanAdd
                                CheckBoxModuleAccess_Custom1.Checked = GroupModuleAccess.Custom1
                                CheckBoxModuleAccess_Custom2.Checked = GroupModuleAccess.Custom2

                            End If

                        ElseIf _GroupList IsNot Nothing AndAlso _GroupList.Count > 0 Then

                            CheckBoxModuleAccess_IsBlocked.Checked = True
                            CheckBoxModuleAccess_CanPrint.Checked = True
                            CheckBoxModuleAccess_CanUpdate.Checked = True
                            CheckBoxModuleAccess_CanAdd.Checked = True
                            CheckBoxModuleAccess_Custom1.Checked = True
                            CheckBoxModuleAccess_Custom2.Checked = True

                            For Each Group In _GroupList

                                Try

                                    GroupModuleAccess = Group.GroupModuleAccesses.SingleOrDefault(Function(GrpModAccess) GrpModAccess.ModuleID = FirstSelectedModule.ModuleID)

                                Catch ex As Exception
                                    GroupModuleAccess = Nothing
                                End Try

                                If GroupModuleAccess IsNot Nothing Then

                                    If GroupModuleAccess.IsBlocked = False Then

                                        CheckBoxModuleAccess_IsBlocked.Checked = False

                                    End If

                                    If GroupModuleAccess.CanPrint = False Then

                                        CheckBoxModuleAccess_CanPrint.Checked = False

                                    End If

                                    If GroupModuleAccess.CanUpdate = False Then

                                        CheckBoxModuleAccess_CanUpdate.Checked = False

                                    End If

                                    If GroupModuleAccess.CanAdd = False Then

                                        CheckBoxModuleAccess_CanAdd.Checked = False

                                    End If

                                    If GroupModuleAccess.Custom1 = False Then

                                        CheckBoxModuleAccess_Custom1.Checked = False

                                    End If

                                    If GroupModuleAccess.Custom2 = False Then

                                        CheckBoxModuleAccess_Custom2.Checked = False

                                    End If

                                End If

                            Next

                        Else

                            CheckBoxModuleAccess_IsBlocked.Visible = False
                            CheckBoxModuleAccess_CanPrint.Visible = False
                            CheckBoxModuleAccess_CanUpdate.Visible = False
                            CheckBoxModuleAccess_CanAdd.Visible = False
                            CheckBoxModuleAccess_Custom1.Visible = False
                            CheckBoxModuleAccess_Custom2.Visible = False

                        End If

                    End Using

                Else

                    CheckBoxModuleAccess_IsBlocked.Checked = False
                    CheckBoxModuleAccess_CanPrint.Checked = False
                    CheckBoxModuleAccess_CanUpdate.Checked = False
                    CheckBoxModuleAccess_CanAdd.Checked = False
                    CheckBoxModuleAccess_Custom1.Checked = False
                    CheckBoxModuleAccess_Custom2.Checked = False

                End If

            Else

                CheckBoxModuleAccess_IsBlocked.Visible = False
                CheckBoxModuleAccess_CanPrint.Visible = False
                CheckBoxModuleAccess_CanUpdate.Visible = False
                CheckBoxModuleAccess_CanAdd.Visible = False
                CheckBoxModuleAccess_Custom1.Visible = False
                CheckBoxModuleAccess_Custom2.Visible = False

            End If

            TabItemGroupDetails_ModuleAccessTab.Tag = True

            _LoadGroupModuleAccess = False

        End Sub
        Private Sub LoadGroupApplicationAccess()

            'objects
            Dim ApplicationID As Integer = 0
            Dim GroupApplicationAccess As AdvantageFramework.Security.Database.Entities.GroupApplicationAccess = Nothing

            If _GroupList IsNot Nothing AndAlso _GroupList.Count > 0 AndAlso ComboBoxModuleAccess_Application.HasASelectedValue Then

                _LoadGroupModuleAccess = True

                ApplicationID = ComboBoxModuleAccess_Application.GetSelectedValue

                If _GroupList.Count = 1 Then

                    Try

                        GroupApplicationAccess = _GroupList.FirstOrDefault.GroupApplicationAccesses.SingleOrDefault(Function(GrpAppAccess) GrpAppAccess.ApplicationID = ApplicationID)

                    Catch ex As Exception
                        GroupApplicationAccess = Nothing
                    End Try

                    If GroupApplicationAccess IsNot Nothing Then

                        CheckBoxModuleAccess_IsApplicationBlocked.Checked = GroupApplicationAccess.IsBlocked

                    Else

                        CheckBoxModuleAccess_IsApplicationBlocked.Checked = False

                    End If

                Else

                    If _GroupList.SelectMany(Function(Group) Group.GroupApplicationAccesses).Any(Function(GrpAppAccess) GrpAppAccess.ApplicationID = ApplicationID AndAlso GrpAppAccess.IsBlocked = True) Then

                        CheckBoxModuleAccess_IsApplicationBlocked.Checked = True

                    Else

                        CheckBoxModuleAccess_IsApplicationBlocked.Checked = False

                    End If

                End If

                _LoadGroupModuleAccess = False

            End If

        End Sub
        Private Sub SaveGroupApplicationAccess()

            'objects
            Dim ApplicationID As Integer = 0
            Dim GroupApplicationAccess As AdvantageFramework.Security.Database.Entities.GroupApplicationAccess = Nothing

            If _LoadGroupModuleAccess = False AndAlso _GroupList IsNot Nothing AndAlso _GroupList.Count > 0 AndAlso ComboBoxModuleAccess_Application.HasASelectedValue Then

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ApplicationID = ComboBoxModuleAccess_Application.GetSelectedValue

                    For Each Group In _GroupList

                        Try

                            GroupApplicationAccess = Group.GroupApplicationAccesses.SingleOrDefault(Function(GrpAppAccess) GrpAppAccess.ApplicationID = ApplicationID)

                        Catch ex As Exception
                            GroupApplicationAccess = Nothing
                        End Try

                        If GroupApplicationAccess IsNot Nothing Then

                            GroupApplicationAccess.IsBlocked = CheckBoxModuleAccess_IsApplicationBlocked.Checked

                            AdvantageFramework.Security.Database.Procedures.GroupApplicationAccess.Update(SecurityDbContext, GroupApplicationAccess)

                        Else

                            GroupApplicationAccess = New AdvantageFramework.Security.Database.Entities.GroupApplicationAccess

                            GroupApplicationAccess.DbContext = SecurityDbContext

                            GroupApplicationAccess.ApplicationID = ApplicationID
                            GroupApplicationAccess.GroupID = Group.ID
                            GroupApplicationAccess.IsBlocked = CheckBoxModuleAccess_IsApplicationBlocked.Checked
                            GroupApplicationAccess.CanPrint = True
                            GroupApplicationAccess.CanUpdate = True
                            GroupApplicationAccess.CanAdd = True
                            GroupApplicationAccess.Custom1 = False
                            GroupApplicationAccess.Custom2 = False

                            AdvantageFramework.Security.Database.Procedures.GroupApplicationAccess.Insert(SecurityDbContext, GroupApplicationAccess)

                        End If

                    Next

                End Using

            End If

        End Sub
        Private Sub LoadGroupNameAndDescription()

            Dim Group As AdvantageFramework.Security.Database.Entities.Group = Nothing

            If _GroupList IsNot Nothing AndAlso _GroupList.Count = 1 Then

                Group = _GroupList.FirstOrDefault

                TextBoxRightSection_Description.Text = Group.Description
                TextBoxRightSection_Name.Text = Group.Name
                TextBoxRightSection_Description.Enabled = True
                TextBoxRightSection_Name.Enabled = True

            Else

                TextBoxRightSection_Description.Text = ""
                TextBoxRightSection_Name.Text = ""
                TextBoxRightSection_Description.Enabled = False
                TextBoxRightSection_Name.Enabled = False

            End If

        End Sub
        Private Sub LoadGroupUser()

            'objects
            Dim GroupUsersList As Generic.List(Of AdvantageFramework.Security.Database.Entities.User) = Nothing
            Dim AvailableUsersList As Generic.List(Of AdvantageFramework.Security.Database.Entities.User) = Nothing
            Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing
            Dim AllGroupUsersList As Generic.List(Of Generic.List(Of AdvantageFramework.Security.Database.Entities.User)) = Nothing
            Dim AddGroupUser As Boolean = True
            Dim FinalGroupUsersList As Generic.List(Of AdvantageFramework.Security.Database.Entities.User) = Nothing
            Dim UsersList As Generic.List(Of AdvantageFramework.Security.Database.Entities.User) = Nothing

            If _GroupList IsNot Nothing AndAlso _GroupList.Count > 0 Then

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    AllGroupUsersList = New Generic.List(Of Generic.List(Of AdvantageFramework.Security.Database.Entities.User))

                    For Each Group In _GroupList

                        GroupUsersList = Group.GroupUsers.Select(Function(GroupUser) GroupUser.User).ToList

                        AllGroupUsersList.Add(GroupUsersList)

                    Next

                    FinalGroupUsersList = New Generic.List(Of AdvantageFramework.Security.Database.Entities.User)

                    UsersList = AdvantageFramework.Security.Database.Procedures.User.Load(SecurityDbContext).Include("GroupUsers").Include("Employee").Include("Employee.Department").Include("Employee.Office").ToList

                    For Each User In UsersList

                        AddGroupUser = True

                        For Each GroupUsersList In AllGroupUsersList

                            If GroupUsersList.Any(Function(GroupUser) GroupUser.ID = User.ID) = False Then

                                AddGroupUser = False
                                Exit For

                            End If

                        Next

                        If AddGroupUser Then

                            FinalGroupUsersList.Add(User)

                        End If

                    Next

                    AvailableUsersList = New Generic.List(Of AdvantageFramework.Security.Database.Entities.User)

                    For Each User In UsersList

                        If FinalGroupUsersList.Any(Function(GroupUser) GroupUser.ID = User.ID) = False Then

                            If CheckBoxLeftSection_ShowOnlyUsersWithNoGroup.Checked Then

                                If User.GroupUsers.Count = 0 Then

                                    If ButtonItemEmployees_Terminated.Checked Then

                                        AvailableUsersList.Add(User)

                                    Else

                                        If User.Employee.TerminationDate Is Nothing Then

                                            AvailableUsersList.Add(User)

                                        End If

                                    End If

                                End If

                            Else

                                If ButtonItemEmployees_Terminated.Checked Then

                                    AvailableUsersList.Add(User)

                                Else

                                    If User.Employee.TerminationDate Is Nothing Then

                                        AvailableUsersList.Add(User)

                                    End If

                                End If

                            End If

                        End If

                    Next

                    DataGridViewRightSection_GroupUsers.DataSource = FinalGroupUsersList
                    DataGridViewLeftSection_AvailableUsers.DataSource = AvailableUsersList

                    DataGridViewRightSection_GroupUsers.CurrentView.BestFitColumns()
                    DataGridViewLeftSection_AvailableUsers.CurrentView.BestFitColumns()

                    TabItemGroupDetails_UsersTab.Tag = True

                End Using

            End If

        End Sub
        Private Sub LoadUserAppliedWorkspaceTemplate()

            'objects
            Dim AppliedWorkspaceTemplate As Integer = 0
            Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing
            Dim AllGroupUsersList As Generic.List(Of AdvantageFramework.Security.Database.Entities.User) = Nothing
            Dim FinalGroupUsersList As Generic.List(Of AdvantageFramework.Security.Database.Entities.User) = Nothing

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If _GroupList IsNot Nothing AndAlso _GroupList.Count > 0 Then

                    AllGroupUsersList = New Generic.List(Of AdvantageFramework.Security.Database.Entities.User)

                    For Each Group In _GroupList

                        For Each User In Group.GroupUsers.Select(Function(GroupUser) GroupUser.User).ToList

                            AllGroupUsersList.Add(User)

                        Next

                    Next

                    FinalGroupUsersList = New Generic.List(Of AdvantageFramework.Security.Database.Entities.User)

                    For Each User In AdvantageFramework.Security.Database.Procedures.User.Load(SecurityDbContext).Include("Employee").ToList

                        If AllGroupUsersList.Any(Function(Usr) Usr.ID = User.ID) Then

                            FinalGroupUsersList.Add(User)

                        End If

                    Next

                    For Each User In FinalGroupUsersList

                        If FinalGroupUsersList.IndexOf(User) = 0 Then

                            AppliedWorkspaceTemplate = User.Employee.WorkspaceTemplateID.GetValueOrDefault(0)

                        Else

                            If AppliedWorkspaceTemplate <> User.Employee.WorkspaceTemplateID.GetValueOrDefault(0) Then

                                AppliedWorkspaceTemplate = 0
                                Exit For

                            End If

                        End If

                    Next

                End If

                ComboBoxWorkspaces_WorkspaceTemplates.SelectedValue = AppliedWorkspaceTemplate

                TabItemGroupDetails_WorkspacesTab.Tag = True

            End Using

        End Sub
        Private Sub ClearGroupDetail()

            DataGridViewRightSection_GroupUsers.DataSource = Nothing
            DataGridViewLeftSection_AvailableUsers.DataSource = Nothing

            AdvTreeModuleAccess_Modules.SelectedNode = Nothing

            CheckBoxModuleAccess_IsApplicationBlocked.Checked = False

            CheckBoxModuleAccess_IsBlocked.Checked = False
            CheckBoxModuleAccess_CanPrint.Checked = False
            CheckBoxModuleAccess_CanUpdate.Checked = False
            CheckBoxModuleAccess_CanAdd.Checked = False
            CheckBoxModuleAccess_Custom1.Checked = False
            CheckBoxModuleAccess_Custom2.Checked = False

            CheckBoxGroupSettings_AllowGroupToAddHolidays.Checked = False
            CheckBoxGroupSettings_AllowGroupToViewOtherEmployees.Checked = False
            CheckBoxGroupSettings_ShowAllAssignments.Checked = False
            CheckBoxGroupSettings_ShowUnassignedAssignments.Checked = False
            CheckBoxGroupSettings_AllowTaskEdit.Checked = False
            CheckBoxGroupSettings_AllowMediaPageEdit.Checked = False
            CheckBoxGroupSettings_CanUpload.Checked = False
            CheckBoxGroupSettings_ViewPrivateDocuments.Checked = False
            CheckBoxGroupSettings_CreateWorkspaceTemplate.Checked = False

        End Sub
        Private Sub LoadModules()

            'objects
            Dim Node As DevComponents.AdvTree.Node = Nothing
            Dim ApplicationID As Integer = 0

            If ComboBoxModuleAccess_Application.HasASelectedValue Then

                AdvTreeModuleAccess_Modules.Nodes.Clear()

                ApplicationID = ComboBoxModuleAccess_Application.GetSelectedValue

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    For Each ModuleView In SecurityDbContext.GetQuery(Of AdvantageFramework.Security.Database.Views.ModuleView).Where(Function(ModView) ModView.ApplicationID = ApplicationID AndAlso ModView.ParentModuleID Is Nothing AndAlso ModView.IsInactive = False).OrderBy(Function(ModView) ModView.SortOrder)

                        Node = New DevComponents.AdvTree.Node

                        Node.Text = ModuleView.ModuleDescription
                        Node.Tag = ModuleView

                        AdvTreeModuleAccess_Modules.Nodes.Add(Node)

                        LoadSubModule(ApplicationID, ModuleView, Node)

                    Next

                End Using

            End If

        End Sub
        Private Sub LoadSubModule(ByVal ApplicationID As Integer, ByVal ModuleView As AdvantageFramework.Security.Database.Views.ModuleView, ByRef ParentNode As DevComponents.AdvTree.Node)

            'objects
            Dim Node As DevComponents.AdvTree.Node = Nothing

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                For Each [SubModule] In SecurityDbContext.GetQuery(Of AdvantageFramework.Security.Database.Views.ModuleView).Where(Function(ModView) ModView.ApplicationID = ApplicationID AndAlso ModView.ParentModuleID = ModuleView.ModuleID AndAlso ModView.IsInactive = False).OrderBy(Function(ModView) ModView.SortOrder)

                    Node = New DevComponents.AdvTree.Node

                    Node.Text = AdvantageFramework.Security.LoadDescriptionForModule(SecurityDbContext, SubModule)
                    If Node.Text = "Dashboards/Queries" AndAlso ApplicationID = 2 Then
                        Node.Text = "Dashboards"
                    End If
                    Node.Tag = SubModule

                    ParentNode.Nodes.Add(Node)

                    If SubModule.IsCategory Then

                        LoadSubModule(ApplicationID, SubModule, Node)

                    End If

                Next

            End Using

        End Sub
        Private Function Save() As Boolean

            'objects
            Dim Saved As Boolean = False
            Dim GroupID As Integer = 0
            Dim Group As AdvantageFramework.Security.Database.Entities.Group = Nothing
            Dim ErrorMessage As String = Nothing

            If DataGridViewLeftSection_Groups.HasOnlyOneSelectedRow Then

                If Me.Validator Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                    Try

                        GroupID = DataGridViewLeftSection_Groups.CurrentView.GetRowCellValue(DataGridViewLeftSection_Groups.CurrentView.FocusedRowHandle, AdvantageFramework.Security.Database.Entities.Group.Properties.ID.ToString)

                        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Group = AdvantageFramework.Security.Database.Procedures.Group.LoadByGroupID(SecurityDbContext, GroupID)

                            If Group IsNot Nothing Then

                                Group.Name = TextBoxRightSection_Name.Text
                                Group.Description = TextBoxRightSection_Description.Text

                                If AdvantageFramework.Security.Database.Procedures.Group.Update(SecurityDbContext, Group) Then

                                    Me.ClearChanged()

                                    LoadGrid()

                                End If

                            End If

                        End Using

                    Catch ex As Exception
                        ErrorMessage = ex.Message
                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If ErrorMessage = "" Then

                        Saved = True

                        DataGridViewLeftSection_Groups.FocusToFindPanel(False)

                        DataGridViewLeftSection_Groups.CurrentView.GridViewSelectionChanged()

                    End If

                Else

                    For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    Next

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a valid group.")

            End If

            Save = Saved

        End Function
        Private Sub SetToolTips()

            'objects
            Dim ModuleView As AdvantageFramework.Security.Database.Views.ModuleView = Nothing

            If AdvTreeModuleAccess_Modules.SelectedNode IsNot Nothing Then

                ModuleView = TryCast(AdvTreeModuleAccess_Modules.SelectedNode.Tag, AdvantageFramework.Security.Database.Views.ModuleView)

                If ModuleView IsNot Nothing AndAlso (ModuleView.ModuleCode = AdvantageFramework.Security.Modules.Employee_ExpenseReports.ToString OrElse
                        ModuleView.ModuleCode = AdvantageFramework.Security.Modules.Maintenance_Accounting_Vendor.ToString OrElse
                        ModuleView.ModuleCode = AdvantageFramework.Security.Modules.Maintenance_Accounting_Employee.ToString OrElse
                        ModuleView.ModuleCode = AdvantageFramework.Security.Modules.Media_MediaManager.ToString OrElse
                        ModuleView.ModuleCode = AdvantageFramework.Security.Modules.ProjectManagement_ProjectSchedule.ToString OrElse
                        ModuleView.ModuleCode = AdvantageFramework.Security.Modules.ProjectManagement_Boards.ToString) Then

                    _ToolTipController.SetToolTip(CheckBoxModuleAccess_Custom1, AdvantageFramework.Security.GetToolTip(ModuleView.ModuleCode, AdvantageFramework.Security.Database.Classes.UserModuleAccess.Properties.Custom1.ToString))
                    _ToolTipController.SetToolTip(CheckBoxModuleAccess_Custom2, AdvantageFramework.Security.GetToolTip(ModuleView.ModuleCode, AdvantageFramework.Security.Database.Classes.UserModuleAccess.Properties.Custom2.ToString))

                End If

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim GroupSetupForm As AdvantageFramework.Security.Setup.Presentation.GroupSetupForm = Nothing

            GroupSetupForm = New AdvantageFramework.Security.Setup.Presentation.GroupSetupForm()

            GroupSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub GroupSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Copy.Image = AdvantageFramework.My.Resources.CopyImage

            ButtonItemEmployees_Terminated.Image = AdvantageFramework.My.Resources.ShowInactiveImage

            AdvantageFramework.WinForm.Presentation.Controls.SetByPassUserEntryChanged(Me, True)

            Me.ByPassUserEntryChanged = False

            TextBoxRightSection_Description.ByPassUserEntryChanged = False
            TextBoxRightSection_Name.ByPassUserEntryChanged = False

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ComboBoxModuleAccess_Application.DataSource = AdvantageFramework.Security.Database.Procedures.Application.Load(SecurityDbContext).Where(Function(Application) Application.ID = AdvantageFramework.Security.Application.Advantage OrElse Application.ID = AdvantageFramework.Security.Application.Webvantage)

                ComboBoxWorkspaces_WorkspaceTemplates.DataSource = AdvantageFramework.Security.Database.Procedures.WorkspaceTemplate.LoadNonClientPortalWorkspaceTemplates(SecurityDbContext)

                TextBoxRightSection_Description.SetPropertySettings(AdvantageFramework.Security.Database.Entities.Group.Properties.Description)
                TextBoxRightSection_Name.SetPropertySettings(AdvantageFramework.Security.Database.Entities.Group.Properties.Name)

            End Using

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            _ToolTipController = New DevExpress.Utils.ToolTipController()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub GroupSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub GroupSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub GroupSetupForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            DataGridViewLeftSection_Groups.FocusToFindPanel(True)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub DataGridViewLeftSection_Groups_LeavingRowEvent(ByVal e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewLeftSection_Groups.LeavingRowEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                e.Allow = CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_Groups_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_Groups.SelectionChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                LoadSelectedItemDetails(Nothing)
                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ComboBoxModuleAccess_Application_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxModuleAccess_Application.SelectedIndexChanged

            LoadModules()

            LoadGroupApplicationAccess()

        End Sub
        Private Sub AdvTreeModuleAccess_Modules_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles AdvTreeModuleAccess_Modules.SelectionChanged

            LoadGroupModuleAccess()

        End Sub
        Private Sub ButtonRightSection_AddToGroup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonRightSection_AddToGroup.Click

            'objects
            Dim UserID As Integer = 0
            Dim UserIDList As Generic.List(Of Integer) = Nothing

            If DataGridViewLeftSection_Groups.HasASelectedRow AndAlso DataGridViewLeftSection_AvailableUsers.HasASelectedRow Then

                UserIDList = DataGridViewLeftSection_AvailableUsers.GetAllSelectedRowsBookmarkValues.OfType(Of Integer).ToList

                Me.ShowWaitForm()
                Me.ShowWaitForm("Processing...")

                Try

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each Group In _GroupList

                            For Each UserID In UserIDList

                                If AdvantageFramework.Security.Database.Procedures.GroupUser.LoadByGroupIDAndUserID(SecurityDbContext, Group.ID, UserID) Is Nothing Then

                                    AdvantageFramework.Security.Database.Procedures.GroupUser.Insert(SecurityDbContext, Group.ID, UserID, Nothing)

                                End If

                            Next

                        Next

                    End Using

                Catch ex As Exception

                End Try

                Me.ShowWaitForm("Loading...")

                Try

                    LoadSelectedItemDetails(Nothing)

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonRightSection_RemoveFromGroup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonRightSection_RemoveFromGroup.Click

            'objects
            Dim UserID As Integer = 0
            Dim GroupUser As AdvantageFramework.Security.Database.Entities.GroupUser = Nothing
            Dim UserIDList As Generic.List(Of Integer) = Nothing

            If DataGridViewLeftSection_Groups.HasASelectedRow AndAlso DataGridViewRightSection_GroupUsers.HasASelectedRow Then

                UserIDList = DataGridViewRightSection_GroupUsers.GetAllSelectedRowsBookmarkValues.OfType(Of Integer).ToList

                Me.ShowWaitForm()
                Me.ShowWaitForm("Processing...")

                Try

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each Group In _GroupList

                            For Each UserID In UserIDList

                                GroupUser = AdvantageFramework.Security.Database.Procedures.GroupUser.LoadByGroupIDAndUserID(SecurityDbContext, Group.ID, UserID)

                                If GroupUser IsNot Nothing Then

                                    AdvantageFramework.Security.Database.Procedures.GroupUser.Delete(SecurityDbContext, GroupUser)

                                End If

                            Next

                        Next

                    End Using

                Catch ex As Exception

                End Try

                Me.ShowWaitForm("Loading...")

                Try

                    LoadSelectedItemDetails(Nothing)

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemActions_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim GroupID As Integer = 0
            Dim ContinueAdd As Boolean = True

            If DataGridViewLeftSection_Groups.HasOnlyOneSelectedRow Then

                ContinueAdd = CheckForUnsavedChanges()

            End If

            If ContinueAdd Then

                If AdvantageFramework.Security.Setup.Presentation.GroupEditDialog.ShowFormDialog(GroupID) = System.Windows.Forms.DialogResult.OK Then

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                    Try

                        LoadGrid()

                        DataGridViewLeftSection_Groups.SelectRow(GroupID)

                    Catch ex As Exception

                    End Try

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                    DataGridViewLeftSection_Groups.CurrentView.GridViewSelectionChanged()

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            Save()

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim Group As AdvantageFramework.Security.Database.Entities.Group = Nothing

            If DataGridViewLeftSection_Groups.HasOnlyOneSelectedRow Then

                If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Group = AdvantageFramework.Security.Database.Procedures.Group.LoadByGroupID(SecurityDbContext, DataGridViewLeftSection_Groups.CurrentView.GetRowCellValue(DataGridViewLeftSection_Groups.CurrentView.FocusedRowHandle, AdvantageFramework.Security.Database.Entities.Group.Properties.ID.ToString))

                            If AdvantageFramework.Security.Database.Procedures.Group.Delete(SecurityDbContext, Group) Then

                                LoadGrid()

                            End If

                        End Using

                    Catch ex As Exception
                        AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    DataGridViewLeftSection_Groups.CurrentView.GridViewSelectionChanged()

                End If

            End If

        End Sub
        Private Sub CheckBoxModuleAccess_CanAdd_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxModuleAccess_CanAdd.CheckedChanged

            SaveGroupModuleAccess(Database.Entities.GroupModuleAccess.Properties.CanAdd, CheckBoxModuleAccess_CanAdd.Checked)

        End Sub
        Private Sub CheckBoxModuleAccess_CanPrint_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxModuleAccess_CanPrint.CheckedChanged

            SaveGroupModuleAccess(Database.Entities.GroupModuleAccess.Properties.CanPrint, CheckBoxModuleAccess_CanPrint.Checked)

        End Sub
        Private Sub CheckBoxModuleAccess_CanUpdate_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxModuleAccess_CanUpdate.CheckedChanged

            SaveGroupModuleAccess(Database.Entities.GroupModuleAccess.Properties.CanUpdate, CheckBoxModuleAccess_CanUpdate.Checked)

        End Sub
        Private Sub CheckBoxModuleAccess_Custom1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxModuleAccess_Custom1.CheckedChanged

            SaveGroupModuleAccess(Database.Entities.GroupModuleAccess.Properties.Custom1, CheckBoxModuleAccess_Custom1.Checked)

        End Sub
        Private Sub CheckBoxModuleAccess_Custom2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxModuleAccess_Custom2.CheckedChanged

            SaveGroupModuleAccess(Database.Entities.GroupModuleAccess.Properties.Custom2, CheckBoxModuleAccess_Custom2.Checked)

        End Sub
        Private Sub CheckBoxModuleAccess_IsBlocked_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxModuleAccess_IsBlocked.CheckedChanged

            SaveGroupModuleAccess(Database.Entities.GroupModuleAccess.Properties.IsBlocked, CheckBoxModuleAccess_IsBlocked.Checked)

        End Sub
        Private Sub CheckBoxLeftSection_ShowOnlyUsersWithNoGroup_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBoxLeftSection_ShowOnlyUsersWithNoGroup.CheckedChanged

            LoadGroupUser()

        End Sub
        Private Sub ButtonItemView_ExpandAll_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemView_ExpandAll.Click

            AdvTreeModuleAccess_Modules.ExpandAll()

        End Sub
        Private Sub ButtonItemView_CollapseAll_Click(sender As Object, e As System.EventArgs) Handles ButtonItemView_CollapseAll.Click

            AdvTreeModuleAccess_Modules.CollapseAll()

        End Sub
        Private Sub CheckBoxGroupSettings_AllowUserToAddHolidays_CheckedChanged(sender As Object, e As System.EventArgs) Handles CheckBoxGroupSettings_AllowGroupToAddHolidays.CheckedChanged

            SaveGroupSettings(sender)

        End Sub
        Private Sub CheckBoxGroupSettings_AllowUserToViewOtherEmployees_CheckedChanged(sender As Object, e As System.EventArgs) Handles CheckBoxGroupSettings_AllowGroupToViewOtherEmployees.CheckedChanged

            SaveGroupSettings(sender)

        End Sub
        Private Sub CheckBoxGroupSettings_ShowAllAssignments_CheckedChanged(sender As Object, e As System.EventArgs) Handles CheckBoxGroupSettings_ShowAllAssignments.CheckedChanged

            SaveGroupSettings(sender)

        End Sub
        Private Sub CheckBoxGroupSettings_ShowUnassignedAssignments_CheckedChanged(sender As Object, e As System.EventArgs) Handles CheckBoxGroupSettings_ShowUnassignedAssignments.CheckedChanged

            SaveGroupSettings(sender)

        End Sub
        Private Sub CheckBoxGroupSettings_AllowTaskEdit_CheckedChanged(sender As Object, e As System.EventArgs) Handles CheckBoxGroupSettings_AllowTaskEdit.CheckedChanged

            SaveGroupSettings(sender)

        End Sub
        Private Sub CheckBoxGroupSettings_AllowMediaPageEdit_CheckedChanged(sender As Object, e As System.EventArgs) Handles CheckBoxGroupSettings_AllowMediaPageEdit.CheckedChanged

            SaveGroupSettings(sender)

        End Sub
        Private Sub CheckBoxGroupSettings_CanUpload_CheckedChanged(sender As Object, e As System.EventArgs) Handles CheckBoxGroupSettings_CanUpload.CheckedChanged

            SaveGroupSettings(sender)

        End Sub
        Private Sub CheckBoxGroupSettings_ViewPrivateDocuments_CheckedChanged(sender As Object, e As System.EventArgs) Handles CheckBoxGroupSettings_ViewPrivateDocuments.CheckedChanged

            SaveGroupSettings(sender)

        End Sub
        Private Sub CheckBoxGroupSettings_CreateWorkspaceTemplate_CheckedChanged(sender As Object, e As System.EventArgs) Handles CheckBoxGroupSettings_CreateWorkspaceTemplate.CheckedChanged

            SaveGroupSettings(sender)

        End Sub
        Private Sub ButtonWorkspaces_Apply_Click(sender As Object, e As System.EventArgs) Handles ButtonWorkspaces_Apply.Click

            'objects
            Dim WorkspaceTemplate As AdvantageFramework.Security.Database.Entities.WorkspaceTemplate = Nothing
            Dim Group As AdvantageFramework.Security.Database.Entities.Group = Nothing
            Dim UserWorkspace As AdvantageFramework.Security.Database.Entities.UserWorkspace = Nothing
            Dim AskToOverrideWorkspaces As Boolean = False
            Dim WorkspaceTemplateDetailsList As Generic.List(Of AdvantageFramework.Security.Database.Entities.WorkspaceTemplateDetail) = Nothing

            If DataGridViewLeftSection_Groups.HasASelectedRow Then

                If ComboBoxWorkspaces_WorkspaceTemplates.HasASelectedValue Then

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        WorkspaceTemplate = AdvantageFramework.Security.Database.Procedures.WorkspaceTemplate.LoadByWorkspaceTemplateID(SecurityDbContext, ComboBoxWorkspaces_WorkspaceTemplates.GetSelectedValue)

                        If WorkspaceTemplate IsNot Nothing Then

                            For Each Group In _GroupList

                                For Each GroupUser In Group.GroupUsers

                                    If AdvantageFramework.Security.Database.Procedures.UserWorkspace.LoadByUserCode(SecurityDbContext, GroupUser.User.UserCode).Any Then

                                        AskToOverrideWorkspaces = True
                                        Exit For

                                    End If

                                Next

                                If AskToOverrideWorkspaces Then

                                    Exit For

                                End If

                            Next

                            If AskToOverrideWorkspaces Then

                                If AdvantageFramework.WinForm.MessageBox.Show("Do you want to replace existing workspaces with the ones in the selected template?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                                    Me.ShowWaitForm()
                                    Me.ShowWaitForm("Processing...")
                                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                                    Try

                                        For Each Group In _GroupList

                                            For Each GroupUser In Group.GroupUsers

                                                For Each UserWorkspace In AdvantageFramework.Security.Database.Procedures.UserWorkspace.LoadByUserCode(SecurityDbContext, GroupUser.User.UserCode).ToList

                                                    AdvantageFramework.Security.Database.Procedures.UserWorkspace.Delete(SecurityDbContext, UserWorkspace)

                                                Next

                                            Next

                                        Next

                                    Catch ex As Exception

                                    End Try

                                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False
                                    Me.CloseWaitForm()

                                    AskToOverrideWorkspaces = True

                                Else

                                    AskToOverrideWorkspaces = False

                                End If

                            Else

                                AskToOverrideWorkspaces = True

                            End If

                            If AskToOverrideWorkspaces Then

                                Me.ShowWaitForm()
                                Me.ShowWaitForm("Processing...")
                                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                                Try

                                    For Each Group In _GroupList

                                        For Each GroupUser In Group.GroupUsers

                                            SecurityDbContext.Database.ExecuteSqlCommand("UPDATE dbo.EMPLOYEE SET WV_TMPLT_HDR_ID = " & WorkspaceTemplate.ID & " WHERE EMP_CODE = '" & GroupUser.User.EmployeeCode & "'")

                                            WorkspaceTemplateDetailsList = WorkspaceTemplate.WorkspaceTemplateDetails.ToList

                                            For Each WorkspaceTemplateDetail In WorkspaceTemplate.WorkspaceTemplateDetails

                                                If AdvantageFramework.Security.Database.Procedures.UserWorkspace.Insert(SecurityDbContext, GroupUser.User.UserCode, WorkspaceTemplateDetail.Name, WorkspaceTemplateDetail.Description, WorkspaceTemplateDetail.SortOrder, 0, UserWorkspace) Then

                                                    For Each WorkspaceTemplateItem In WorkspaceTemplateDetail.WorkspaceTemplateItems

                                                        If AdvantageFramework.Security.DoesUserHaveAccessToModule(SecurityDbContext, AdvantageFramework.Security.Application.Webvantage, WorkspaceTemplateItem.ModuleID, GroupUser.UserID) Then

                                                            AdvantageFramework.Security.Database.Procedures.WorkspaceObject.Insert(SecurityDbContext, UserWorkspace.ID, WorkspaceTemplateItem.ModuleID, WorkspaceTemplateItem.ZoneID, WorkspaceTemplateItem.Height, WorkspaceTemplateItem.Width, WorkspaceTemplateItem.TopCoordinate, WorkspaceTemplateItem.LeftCoordinate, WorkspaceTemplateItem.SortOrder, Nothing)

                                                        End If

                                                    Next

                                                    If WorkspaceTemplateDetailsList.IndexOf(WorkspaceTemplateDetail) = 0 Then

                                                        SecurityDbContext.Database.ExecuteSqlCommand("UPDATE dbo.APP_VARS SET VARIABLE_VALUE = '" & UserWorkspace.ID & "' WHERE USERID = '" & GroupUser.User.UserCode & "' AND [APPLICATION] = 'MY_SETTINGS' AND VARIABLE_NAME = 'CURRENT_WORKSPACE'")

                                                    End If

                                                End If

                                            Next

                                        Next

                                    Next

                                Catch ex As Exception

                                End Try

                                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False
                                Me.CloseWaitForm()

                                AdvantageFramework.WinForm.MessageBox.Show("Process Complete")

                            End If

                        Else

                            AdvantageFramework.WinForm.MessageBox.Show("Please select a valid workspace template")

                        End If

                    End Using

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Please select a workspace template")

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a group")

            End If

        End Sub
        Private Sub TabControlRightSection_GroupDetails_SelectedTabChanging(ByVal sender As Object, ByVal e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles TabControlRightSection_GroupDetails.SelectedTabChanging

            LoadSelectedItemDetails(e.NewTab)

            If e.NewTab Is TabItemGroupDetails_ModuleAccessTab Then

                RibbonBarOptions_View.Visible = True

            Else

                RibbonBarOptions_View.Visible = False

            End If

            If e.NewTab Is TabItemGroupDetails_UsersTab Then

                RibbonBarOptions_Employees.Visible = True

            Else

                RibbonBarOptions_Employees.Visible = False

            End If

        End Sub
        Private Sub ButtonItemActions_Copy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Copy.Click

            'objects
            Dim GroupID As Integer = 0
            Dim CopyFromGroupID As Integer = 0
            Dim CopyFromGroupName As String = ""
            Dim Group As AdvantageFramework.Security.Database.Entities.Group = Nothing

            If DataGridViewLeftSection_Groups.HasASelectedRow Then

                CopyFromGroupID = DataGridViewLeftSection_Groups.CurrentView.GetRowCellValue(DataGridViewLeftSection_Groups.CurrentView.FocusedRowHandle, AdvantageFramework.Security.Database.Entities.Group.Properties.ID.ToString)
                CopyFromGroupName = DataGridViewLeftSection_Groups.CurrentView.GetRowCellValue(DataGridViewLeftSection_Groups.CurrentView.FocusedRowHandle, AdvantageFramework.Security.Database.Entities.Group.Properties.Name.ToString)

                If AdvantageFramework.Security.Setup.Presentation.GroupEditDialog.ShowFormDialog(GroupID, CopyFromGroupName) = System.Windows.Forms.DialogResult.OK Then

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Group = AdvantageFramework.Security.Database.Procedures.Group.LoadByGroupID(SecurityDbContext, CopyFromGroupID)

                        If Group IsNot Nothing Then

                            If AdvantageFramework.Security.Database.Procedures.GroupModuleAccess.CopyFromGroup(SecurityDbContext, GroupID, CopyFromGroupID) Then

                                AdvantageFramework.Security.Database.Procedures.GroupSetting.CopyFromGroup(SecurityDbContext, GroupID, CopyFromGroupID)

                            End If

                        End If

                    End Using

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                    Try

                        LoadGrid()

                        DataGridViewLeftSection_Groups.SelectRow(GroupID)

                    Catch ex As Exception

                    End Try

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                    DataGridViewLeftSection_Groups.CurrentView.GridViewSelectionChanged()

                End If

            End If

        End Sub
        Private Sub ComboBoxWorkspaces_WorkspaceTemplates_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxWorkspaces_WorkspaceTemplates.SelectedValueChanged

            ButtonWorkspaces_Apply.Enabled = ComboBoxWorkspaces_WorkspaceTemplates.HasASelectedValue

        End Sub
        Private Sub CheckBoxModuleAccess_IsApplicationBlocked_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxModuleAccess_IsApplicationBlocked.CheckedChanged

            SaveGroupApplicationAccess()

        End Sub
        Private Sub ButtonItemEmployees_Terminated_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemEmployees_Terminated.CheckedChanged

            If Me.FormShown Then

                LoadGroupUser()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
