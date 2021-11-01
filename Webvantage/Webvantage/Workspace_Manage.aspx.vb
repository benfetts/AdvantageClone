Imports System.Data.Common
Imports System.Data.Objects
Imports System.Data.SqlClient
Imports Telerik.Web.UI
Imports System.Windows.Forms

Public Class Workspace_Manage
    Inherits Webvantage.BaseChildPage

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
    Private Property CurrentWorkspaceId() As Integer
        Get

            If IsNumeric(Me.HiddenFieldCurrentWorkspaceId.Value) = True Then

                CurrentWorkspaceId = CType(Me.HiddenFieldCurrentWorkspaceId.Value, Integer)

            Else

                CurrentWorkspaceId = 0

            End If

        End Get
        Set(ByVal value As Integer)
            Me.HiddenFieldCurrentWorkspaceId.Value = value
        End Set
    End Property

#End Region

#Region "  Page Event Handlers "

    Private Sub Workspace_Manage_Init(sender As Object, e As System.EventArgs) Handles Me.Init
        Me.AllowFloat = True
        Me.BodyTag.Attributes.Add("onload", "window.focus;")
    End Sub

    Private UserCanCreateWorkspaceTemplates As Boolean = False

    Protected Sub Workspace_Manage_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack And Not Me.IsCallback Then

            Me.SetInitialWorkspaceId()
            Me.SetPage()
            Me.RadTabStripWorkspaceManager.SelectedIndex = 0

            If Me.CurrentTheme = TkTheme.Small Then

            End If

            Me.TrExistingTemplate.Visible = False

            If Me.IsClientPortal = False Then
                Me.UserCanCreateWorkspaceTemplates = Me.LoadUserGroupSettingAccess(AdvantageFramework.Security.GroupSettings.Workspace_Template_Create) = 1
                If Request.QueryString("cp") = "1" Then
                    Me.FieldsetQuickLaunch.Visible = False
                End If
                Me.CollapsablePanelClientPortalWorkspaceOptions.Visible = False
            Else
                Me.UserCanCreateWorkspaceTemplates = False
                'Me.FieldsetQuickLaunch.Visible = False
                LoadWorkspaceOptions()
                Me.RadTabStripWorkspaceManager.Tabs(1).Visible = False
            End If
            'Me.UserCanCreateWorkspaceTemplates = AdvantageFramework.Security.LoadUserGroupSetting(_Session, AdvantageFramework.Security.GroupSettings.Workspace_Template_Create).Any(Function(SettingValue) SettingValue = True)
            Me.RadToolBarWorkspaces.FindItemByValue("SaveAsTemplate").Enabled = Me.UserCanCreateWorkspaceTemplates
            If Me.IsClientPortal = False Then
                Me.RadTabStripWorkspaceManager.FindTabByValue("Templates").Visible = Me.UserCanCreateWorkspaceTemplates
            End If
            If Request.QueryString("cp") = 1 Then
                'Me.CollapsablePanelWorkspaces.Visible = False
                ' Me.TextBoxWorkspaceName.ReadOnly = True
                'Me.RadToolBarCPTemplate.Items(2).Enabled = False
                'Me.FieldsetPanels.Visible = False
            End If
            If Me.IsClientPortal = False Then
                Dim Employee As AdvantageFramework.Security.Database.Views.Employee
                Dim WorkspaceTemplate As AdvantageFramework.Security.Database.Entities.WorkspaceTemplate
                Using DbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                    Employee = AdvantageFramework.Security.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Session("EmpCode"))
                    If Not Employee.WorkspaceTemplateID Is Nothing Then
                        WorkspaceTemplate = AdvantageFramework.Security.Database.Procedures.WorkspaceTemplate.LoadByWorkspaceTemplateID(DbContext, Employee.WorkspaceTemplateID)
                        If Not Employee.WorkspaceTemplateID Is Nothing And Request.QueryString("cp") <> 1 Then
                            If Not WorkspaceTemplate Is Nothing Then
                                Me.LabelTemplate.Text = "Last Template Applied '" & WorkspaceTemplate.Name & "'"
                            End If
                        End If
                    End If
                End Using
            End If

        End If

    End Sub

#End Region

#Region "  Workspace Details "

    Private Sub RadListBoxWorkspaces_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles RadListBoxWorkspaces.SelectedIndexChanged
        'If IsNumeric(Me.RadListBoxWorkspaces.SelectedValue) = True Then
        '    Me.CurrentWorkspaceId = CType(Me.RadListBoxWorkspaces.SelectedValue, Integer)
        '    Me.SetPage()

        '    'Me.LoadWorkspaceObjects()
        '    'Me.LoadApplicationMenu()
        '    Me.RefreshMainApplicationWindow()
        'Else
        '    Me.ShowMessage("Cannot change workspace")
        '    Exit Sub
        'End If
        If IsNumeric(Me.RadListBoxWorkspaces.SelectedValue) = False Then
            Exit Sub
        Else
            Me.CurrentWorkspaceId = CType(Me.RadListBoxWorkspaces.SelectedValue, Integer)
        End If
        Me.SetPage()
        Me.RefreshMainApplicationWindow()
    End Sub

    Private Sub CheckBoxAddToLeft_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxAddToLeft.CheckedChanged

        If Me.CheckBoxAddToCenter.Checked = True Then

            Me.CheckBoxAddToCenter.Checked = False

        End If

        Me.SetupAddItems()

    End Sub

    Private Sub CheckBoxAddToCenter_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxAddToCenter.CheckedChanged

        If Me.CheckBoxAddToLeft.Checked = True Then

            Me.CheckBoxAddToLeft.Checked = False

        End If

        Me.SetupAddItems()

    End Sub

    Private Sub RadListBoxAvailableObjects_Transferred(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadListBoxTransferredEventArgs) Handles RadListBoxAvailableObjects.Transferred

        Me.InsertObjects(e.DestinationListBox)
        Me.LoadWorkspaceObjects()
        Me.ReOrderObjects(e.DestinationListBox)
        Me.SetupAddItems()

    End Sub

    Private Sub ImageButtonDeleteFromCenter_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonDeleteFromCenter.Click

        Me.DeleteObjectsFromPanel(Me.RadListBoxCenterPanel)

    End Sub

    Private Sub LinkButtonDeleteFromCenter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButtonDeleteFromCenter.Click

        Me.DeleteObjectsFromPanel(Me.RadListBoxCenterPanel)

    End Sub

    Private Sub ImageButtonDeleteFromLeft_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonDeleteFromLeft.Click

        Me.DeleteObjectsFromPanel(Me.RadListBoxLeftPanel)

    End Sub

    Private Sub LinkButtonDeleteFromLeft_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButtonDeleteFromLeft.Click

        Me.DeleteObjectsFromPanel(Me.RadListBoxLeftPanel)

    End Sub

    Private Sub RadToolBarWorkspaces_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarWorkspaces.ButtonClick
        If IsNumeric(Me.RadListBoxWorkspaces.SelectedValue) = False Then
            'Exit Sub
        Else
            Me.CurrentWorkspaceId = CType(Me.RadListBoxWorkspaces.SelectedValue, Integer)
        End If
        Me.TrExistingTemplate.Visible = False
        Select Case e.Item.Value
            Case "Save"
                Try
                    If Me.TableWorkspaces.Visible = True Then
                        'Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                        '    Dim i As Integer = 0
                        '    For Each item As RadListBoxItem In Me.RadListBoxWorkspaces.Items
                        '        i += 1
                        '        If IsNumeric(item.Value) = True Then
                        '            Dim UserWorkspace As AdvantageFramework.Security.Database.Entities.UserWorkspace = Nothing
                        '            UserWorkspace = AdvantageFramework.Security.Database.Procedures.UserWorkspace.LoadByUserWorkspaceID(SecurityDbContext, item.Value)
                        '            If UserWorkspace IsNot Nothing Then
                        '                UserWorkspace.SortOrder = i
                        '                AdvantageFramework.Security.Database.Procedures.UserWorkspace.Update(SecurityDbContext, UserWorkspace)
                        '            End If
                        '        End If
                        '    Next
                        'End Using
                        Dim SQL As New System.Text.StringBuilder
                        Dim ctr As Integer = 0
                        For i As Integer = 0 To Me.RadListBoxWorkspaces.Items.Count - 1
                            ctr += 1
                            If IsNumeric(Me.RadListBoxWorkspaces.Items(i).Value) = True Then
                                With SQL
                                    .Append("UPDATE WV_USER_WORKSPACE WITH(ROWLOCK) SET SORT_ORDER = ")
                                    .Append(ctr.ToString())
                                    .Append(" WHERE WORKSPACE_ID = ")
                                    .Append(Me.RadListBoxWorkspaces.Items(i).Value)
                                    .Append(" AND USER_CODE = '")
                                    .Append(Session("UserCode"))
                                    .Append("';")
                                End With
                            End If
                        Next

                        SqlHelper.ExecuteNonQuery(Session("ConnString"), CommandType.Text, SQL.ToString())

                        Me.SetPage()
                        Me.RefreshMainApplicationWindow()

                    End If
                Catch ex As Exception
                End Try
            Case "Add"
                Me.TextBoxNewWorkspaceName.Text = ""
                Me.DivNewWorkspace.Visible = Not Me.DivNewWorkspace.Visible
                If Me.DivNewWorkspace.Visible = True Then
                    Me.TableWorkspaces.Visible = False
                    Me.DivNewTemplate.Visible = False
                Else
                    Me.TableWorkspaces.Visible = True
                    Me.DivNewTemplate.Visible = False
                End If
            Case "SaveAsTemplate"
                Me.TextBoxNewTemplateName.Text = ""
                Me.DivNewTemplate.Visible = Not Me.DivNewTemplate.Visible
                If Me.DivNewTemplate.Visible = True Then
                    Me.TableWorkspaces.Visible = False
                    Me.DivNewWorkspace.Visible = False
                Else
                    Me.TableWorkspaces.Visible = True
                    Me.DivNewTemplate.Visible = False
                End If
            Case "Refresh"
                Me.SetPage()
                Me.RefreshMainApplicationWindow()

        End Select
    End Sub

    Private Sub RadToolBarCurrentWorkspace_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarCurrentWorkspace.ButtonClick
        Try
            If Me.RadListBoxWorkspaces.SelectedIndex = -1 Then
                Me.ShowMessage("Please select a Workspace")
                Exit Sub
            End If
        Catch ex As Exception
        End Try

        If IsNumeric(Me.RadListBoxWorkspaces.SelectedValue) = False Then
            Exit Sub
        Else
            Me.CurrentWorkspaceId = CType(Me.RadListBoxWorkspaces.SelectedValue, Integer)
        End If
        Select Case e.Item.Value
            Case "Save"
                SaveQuickLaunch()
                Dim UserWorkspace As AdvantageFramework.Security.Database.Entities.UserWorkspace = Nothing
                Dim UserWorkspaceCP As AdvantageFramework.Security.Database.Entities.ClientPortalUserWorkspace = Nothing
                If Me.IsClientPortal = True Then
                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                        UserWorkspaceCP = AdvantageFramework.Security.Database.Procedures.ClientPortalUserWorkspace.LoadByUserWorkspaceID(SecurityDbContext, Me.CurrentWorkspaceId)
                        If UserWorkspaceCP IsNot Nothing Then
                            UserWorkspaceCP.Name = Me.TextBoxWorkspaceName.Text
                            If AdvantageFramework.Security.Database.Procedures.ClientPortalUserWorkspace.Update(SecurityDbContext, UserWorkspaceCP) = True Then
                            End If
                        End If
                    End Using
                    SaveWorkspaceOptions()
                Else
                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                        UserWorkspace = AdvantageFramework.Security.Database.Procedures.UserWorkspace.LoadByUserWorkspaceID(SecurityDbContext, Me.CurrentWorkspaceId)
                        If UserWorkspace IsNot Nothing Then
                            UserWorkspace.Name = Me.TextBoxWorkspaceName.Text
                            If AdvantageFramework.Security.Database.Procedures.UserWorkspace.Update(SecurityDbContext, UserWorkspace) = True Then
                            End If
                        End If
                    End Using
                End If
                Me.SetPage()
                Me.RefreshMainApplicationWindow()
            Case "Delete"
                Me.DeleteWorkspace(Me.CurrentWorkspaceId)
        End Select
    End Sub

#Region " Left Panel Listbox "

    Private Sub RadListBoxLeftPanel_Deleted(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadListBoxEventArgs) Handles RadListBoxLeftPanel.Deleted

        Me.DeleteObjectsFromPanel(Me.RadListBoxLeftPanel)

    End Sub

    Private Sub RadListBoxLeftPanel_Reordered(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadListBoxEventArgs) Handles RadListBoxLeftPanel.Reordered

        Me.ReOrderObjects(Me.RadListBoxLeftPanel)

    End Sub

    Private Sub RadListBoxLeftPanel_Transferred(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadListBoxTransferredEventArgs) Handles RadListBoxLeftPanel.Transferred

        Me.TransferObjects(e.DestinationListBox)
        Me.ReOrderObjects(e.DestinationListBox)

    End Sub

#End Region

#Region " Center Panel Listbox "

    Private Sub RadListBoxCenterPanel_Deleted(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadListBoxEventArgs) Handles RadListBoxCenterPanel.Deleted

        Me.DeleteObjectsFromPanel(Me.RadListBoxLeftPanel)

    End Sub

    Private Sub RadListBoxCenterPanel_Reordered(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadListBoxEventArgs) Handles RadListBoxCenterPanel.Reordered

        Me.ReOrderObjects(Me.RadListBoxCenterPanel)

    End Sub

    Private Sub RadListBoxCenterPanel_Transferred(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadListBoxTransferredEventArgs) Handles RadListBoxCenterPanel.Transferred

        Me.TransferObjects(e.DestinationListBox)
        Me.ReOrderObjects(e.DestinationListBox)

    End Sub

#End Region

#End Region

#Region " Methods "

    Private Function ReturnJavascriptText(ByVal ErrorMessage As String, Optional ByVal FriendlyMessage As String = "", Optional ByVal ScriptName As String = "JSAlert", Optional ByVal ReturnOnlyMessageString As Boolean = False) As String

        'objects
        Dim JavaScript As String = ""

        ScriptName = ScriptName & Now.Millisecond.ToString()

        If FriendlyMessage <> "" Then

            FriendlyMessage = MiscFN.JavascriptSafe(FriendlyMessage) & "\n\n"

        End If

        If ReturnOnlyMessageString = False Then

            JavaScript &= "<script type=""text/javascript"">"

        End If

        JavaScript &= "alert ('" & FriendlyMessage & MiscFN.JavascriptSafe(ErrorMessage.ToString()) & "');"

        If ReturnOnlyMessageString = False Then

            JavaScript &= "</script>"

        End If

        ReturnJavascriptText = JavaScript

    End Function

    Protected Overrides Sub ShowMessageBox(ByVal Message As String, ByVal MessageBoxButtons As AdvantageFramework.WinForm.MessageBox.MessageBoxButtons, ByVal Title As String, ByRef DialogResult As AdvantageFramework.WinForm.MessageBox.DialogResults)

        Me.AddJavascriptToPage(ReturnJavascriptText(Message, , , True))

    End Sub

    Private Sub SetPage()
        Me.DivNewWorkspace.Visible = False
        Me.DivNewTemplate.Visible = False
        Me.TableWorkspaces.Visible = True

        Me.TextBoxNewTemplateName.Text = ""
        Me.TextBoxNewWorkspaceName.Text = ""
        Me.TextBoxWorkspaceName.Text = ""

        LoadWorkspaces()
        LoadWorkspaceObjects()
        LoadApplicationMenu()
        SetupAddItems()

    End Sub

    Private Sub SetInitialWorkspaceId()

        'objects
        Dim UserWorkspace As AdvantageFramework.Security.Database.Entities.UserWorkspace = Nothing
        Dim AppVars As cAppVars = Nothing

        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            If Request.QueryString("cp") = "1" Then
                If Me.CurrentWorkspaceId = 0 Then

                    Try

                        UserWorkspace = AdvantageFramework.Security.Database.Procedures.UserWorkspace.LoadByUserCodeCP(SecurityDbContext, _Session.UserCode, 1).OrderBy(Function(Workspace) Workspace.SortOrder).First

                    Catch ex As Exception
                        UserWorkspace = Nothing
                    End Try

                    If UserWorkspace IsNot Nothing Then

                        Me.CurrentWorkspaceId = UserWorkspace.ID

                    End If

                End If
            Else
                Try

                    AppVars = New cAppVars(cAppVars.Application.MY_SETTINGS)

                    AppVars.getAllAppVars()

                    If IsNumeric(AppVars.getAppVar("CURRENT_WORKSPACE")) = True Then

                        Me.CurrentWorkspaceId = CType(AppVars.getAppVar("CURRENT_WORKSPACE"), Integer)

                    End If

                Catch ex As Exception

                End Try

                If Me.CurrentWorkspaceId = 0 Then

                    Try

                        UserWorkspace = AdvantageFramework.Security.Database.Procedures.UserWorkspace.LoadByUserCode(SecurityDbContext, _Session.UserCode).OrderBy(Function(Workspace) Workspace.SortOrder).First

                    Catch ex As Exception
                        UserWorkspace = Nothing
                    End Try

                    If UserWorkspace IsNot Nothing Then

                        Me.CurrentWorkspaceId = UserWorkspace.ID

                    End If

                End If
            End If

        End Using

    End Sub

    Private Sub LoadWorkspaces()

        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
            With Me.RadListBoxWorkspaces
                .Items.Clear()
                If Me.IsClientPortal = True Then
                    .DataSource = AdvantageFramework.Security.Database.Procedures.ClientPortalUserWorkspace.LoadByUserID(SecurityDbContext, _Session.ClientPortalUser.ClientContactID).OrderBy(Function(Workspace) Workspace.SortOrder).ToList
                Else
                    If Request.QueryString("cp") = 1 Then
                        .DataSource = AdvantageFramework.Security.Database.Procedures.UserWorkspace.LoadByUserCode(SecurityDbContext, _Session.UserCode).Where(Function(UserWorkspace) UserWorkspace.IsClientPortal = 1).OrderBy(Function(Workspace) Workspace.SortOrder).ToList
                    Else
                        .DataSource = AdvantageFramework.Security.Database.Procedures.UserWorkspace.LoadByUserCode(SecurityDbContext, _Session.UserCode).Where(Function(UserWorkspace) UserWorkspace.IsClientPortal = 0 Or UserWorkspace.IsClientPortal Is Nothing).OrderBy(Function(Workspace) Workspace.SortOrder).ToList
                    End If
                End If
                .DataTextField = "Name"
                .DataValueField = "ID"
                .DataBind()
            End With
            If Me.CurrentWorkspaceId > 0 Then
                MiscFN.RadListBoxSetIndex(Me.RadListBoxWorkspaces, Me.CurrentWorkspaceId, False)
            End If
            If Me.RadListBoxWorkspaces.SelectedIndex > -1 Then
                Me.TextBoxWorkspaceName.Text = Me.RadListBoxWorkspaces.SelectedItem.Text
            End If
        End Using

    End Sub

    Private Sub LoadListBoxAvailableObjects()

        'objects
        Dim RadListBoxItemList As Generic.List(Of Telerik.Web.UI.RadListBoxItem) = Nothing
        Dim ParentModuleDescription As String = ""
        Dim ParentModule As AdvantageFramework.Security.Database.Views.ModuleView = Nothing
        Dim ModulesList As Generic.List(Of AdvantageFramework.Security.Database.Views.ModuleView) = Nothing

        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            With Me.RadListBoxAvailableObjects
                .Items.Clear()
                .AllowReorder = False
                .AllowDelete = False
            End With

            RadListBoxItemList = New Generic.List(Of Telerik.Web.UI.RadListBoxItem)

            ModulesList = AdvantageFramework.Security.Database.Procedures.ModuleView.LoadActiveModules(SecurityDbContext).Where(Function(ModView) ModView.ApplicationID = AdvantageFramework.Security.Application.Webvantage).ToList

            For Each [Module] In ModulesList.Where(Function(ModDO) ModDO.IsDesktopObject = True AndAlso ModDO.IsMenuItem = True AndAlso ModDO.ApplicationID = AdvantageFramework.Security.Application.Webvantage).ToList

                If Me.CheckModuleAccess([Module].ModuleCode, False) = 1 Then

                    ParentModule = Nothing

                    Do While True

                        Try

                            If ParentModule Is Nothing Then

                                ParentModule = ModulesList.Single(Function(ModView) ModView.ModuleID = [Module].ParentModuleID)

                            Else

                                ParentModule = ModulesList.Single(Function(ModView) ModView.ModuleID = ParentModule.ParentModuleID)

                            End If

                        Catch ex As Exception
                            ParentModule = Nothing
                        End Try

                        If ParentModule IsNot Nothing Then

                            If ParentModule.ParentModuleID Is Nothing Then

                                ParentModuleDescription = ParentModule.ModuleDescription
                                Exit Do

                            End If

                        Else

                            ParentModuleDescription = ""
                            Exit Do

                        End If

                    Loop

                    RadListBoxItemList.Add(New Telerik.Web.UI.RadListBoxItem("(" & ParentModuleDescription & ") - " & [Module].ModuleDescription, [Module].ModuleID))

                End If

            Next

            For Each RadListBoxItem In RadListBoxItemList.OrderBy(Function(ListBoxItem) ListBoxItem.Text)

                RadListBoxAvailableObjects.Items.Add(RadListBoxItem)

            Next

        End Using

    End Sub

    Private Sub LoadListBoxAvailableObjectsCP()

        'objects
        Dim RadListBoxItemList As Generic.List(Of Telerik.Web.UI.RadListBoxItem) = Nothing
        Dim ParentModuleDescription As String = ""
        Dim ParentModule As AdvantageFramework.Security.Database.Views.ModuleView = Nothing
        Dim ModulesList As Generic.List(Of AdvantageFramework.Security.Database.Views.ModuleView) = Nothing

        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, "")

            With Me.RadListBoxAvailableObjects
                .Items.Clear()
                .AllowReorder = False
                .AllowDelete = False
            End With

            RadListBoxItemList = New Generic.List(Of Telerik.Web.UI.RadListBoxItem)

            ModulesList = AdvantageFramework.Security.Database.Procedures.ModuleView.LoadActiveModules(SecurityDbContext).Where(Function(ModView) ModView.ApplicationID = AdvantageFramework.Security.Application.Client_Portal).ToList

            For Each [Module] In ModulesList.Where(Function(ModDO) ModDO.IsDesktopObject = True AndAlso ModDO.IsMenuItem = True AndAlso ModDO.ApplicationID = AdvantageFramework.Security.Application.Client_Portal).ToList

                If Me.CheckModuleAccess([Module].ModuleCode, False) = 1 Then

                    ParentModule = Nothing

                    Do While True

                        Try

                            If ParentModule Is Nothing Then

                                ParentModule = ModulesList.Single(Function(ModView) ModView.ModuleID = [Module].ParentModuleID)

                            Else

                                ParentModule = ModulesList.Single(Function(ModView) ModView.ModuleID = ParentModule.ParentModuleID)

                            End If

                        Catch ex As Exception
                            ParentModule = Nothing
                        End Try

                        If ParentModule IsNot Nothing Then

                            If ParentModule.ParentModuleID Is Nothing Then

                                ParentModuleDescription = ParentModule.ModuleDescription
                                Exit Do

                            End If

                        Else

                            ParentModuleDescription = ""
                            Exit Do

                        End If

                    Loop

                    RadListBoxItemList.Add(New Telerik.Web.UI.RadListBoxItem("(" & ParentModuleDescription & ") - " & [Module].ModuleDescription, [Module].ModuleID))

                End If

            Next

            For Each RadListBoxItem In RadListBoxItemList.OrderBy(Function(ListBoxItem) ListBoxItem.Text)

                RadListBoxAvailableObjects.Items.Add(RadListBoxItem)

            Next

        End Using

    End Sub

    Private Sub LoadWorkspaceObjects()

        'objects
        Dim [Module] As AdvantageFramework.Security.Database.Views.ModuleView = Nothing
        Dim RadListBoxItemList As Generic.List(Of Telerik.Web.UI.RadListBoxItem) = Nothing
        Dim ModulesList As Generic.List(Of AdvantageFramework.Security.Database.Views.ModuleView) = Nothing
        Dim ParentModuleDescription As String = ""
        Dim ParentModule As AdvantageFramework.Security.Database.Views.ModuleView = Nothing

        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            RadListBoxLeftPanel.Items.Clear()
            RadListBoxCenterPanel.Items.Clear()

            RadListBoxItemList = New Generic.List(Of Telerik.Web.UI.RadListBoxItem)

            ModulesList = AdvantageFramework.Security.Database.Procedures.ModuleView.LoadActiveModules(SecurityDbContext).Where(Function(ModView) ModView.ApplicationID = AdvantageFramework.Security.Application.Webvantage).ToList

            If Me.IsClientPortal = True Then
                For Each ClientPortalWorkspaceObject In AdvantageFramework.Security.Database.Procedures.ClientPortalWorkspaceObject.LoadByWorkspaceIDAndZoneID(SecurityDbContext, Me.CurrentWorkspaceId, "RadDockZoneLeft").OrderBy(Function(WorkObject) WorkObject.SortOrder)

                    Try

                        [Module] = ModulesList.Single(Function(ModView) ModView.ModuleID = ClientPortalWorkspaceObject.DesktopObjectID)

                    Catch ex As Exception
                        [Module] = Nothing
                    End Try

                    If [Module] IsNot Nothing AndAlso Me.CheckModuleAccess([Module].ModuleCode, False) = 1 Then

                        ParentModule = Nothing

                        Do While True

                            Try

                                If ParentModule Is Nothing Then

                                    ParentModule = ModulesList.Single(Function(ModView) ModView.ModuleID = [Module].ParentModuleID)

                                Else

                                    ParentModule = ModulesList.Single(Function(ModView) ModView.ModuleID = ParentModule.ParentModuleID)

                                End If

                            Catch ex As Exception
                                ParentModule = Nothing
                            End Try

                            If ParentModule IsNot Nothing Then

                                If ParentModule.ParentModuleID Is Nothing Then

                                    ParentModuleDescription = ParentModule.ModuleDescription
                                    Exit Do

                                End If

                            Else

                                ParentModuleDescription = ""
                                Exit Do

                            End If

                        Loop

                        RadListBoxItemList.Add(New Telerik.Web.UI.RadListBoxItem("(" & ParentModuleDescription & ") - " & [Module].ModuleDescription, ClientPortalWorkspaceObject.ID))

                    End If

                Next

                For Each RadListBoxItem In RadListBoxItemList

                    RadListBoxLeftPanel.Items.Add(RadListBoxItem)

                Next

                RadListBoxItemList = Nothing

                RadListBoxItemList = New Generic.List(Of Telerik.Web.UI.RadListBoxItem)

                For Each ClientPortalWorkspaceObject In AdvantageFramework.Security.Database.Procedures.ClientPortalWorkspaceObject.LoadByWorkspaceIDAndZoneID(SecurityDbContext, Me.CurrentWorkspaceId, "RadDockZoneCenter").OrderBy(Function(WorkObject) WorkObject.SortOrder)

                    Try

                        [Module] = ModulesList.Single(Function(ModView) ModView.ModuleID = ClientPortalWorkspaceObject.DesktopObjectID)

                    Catch ex As Exception
                        [Module] = Nothing
                    End Try

                    If [Module] IsNot Nothing AndAlso Me.CheckModuleAccess([Module].ModuleCode, False) = 1 Then

                        ParentModule = Nothing

                        Do While True

                            Try

                                If ParentModule Is Nothing Then

                                    ParentModule = ModulesList.Single(Function(ModView) ModView.ModuleID = [Module].ParentModuleID)

                                Else

                                    ParentModule = ModulesList.Single(Function(ModView) ModView.ModuleID = ParentModule.ParentModuleID)

                                End If

                            Catch ex As Exception
                                ParentModule = Nothing
                            End Try

                            If ParentModule IsNot Nothing Then

                                If ParentModule.ParentModuleID Is Nothing Then

                                    ParentModuleDescription = ParentModule.ModuleDescription
                                    Exit Do

                                End If

                            Else

                                ParentModuleDescription = ""
                                Exit Do

                            End If

                        Loop

                        RadListBoxItemList.Add(New Telerik.Web.UI.RadListBoxItem("(" & ParentModuleDescription & ") - " & [Module].ModuleDescription, ClientPortalWorkspaceObject.ID))

                    End If

                Next

                For Each RadListBoxItem In RadListBoxItemList

                    RadListBoxCenterPanel.Items.Add(RadListBoxItem)

                Next
            Else
                For Each WorkspaceObject In AdvantageFramework.Security.Database.Procedures.WorkspaceObject.LoadByWorkspaceIDAndZoneID(SecurityDbContext, Me.CurrentWorkspaceId, "RadDockZoneLeft").OrderBy(Function(WorkObject) WorkObject.SortOrder)

                    Try

                        [Module] = ModulesList.Single(Function(ModView) ModView.ModuleID = WorkspaceObject.DesktopObjectID)

                    Catch ex As Exception
                        [Module] = Nothing
                    End Try

                    If [Module] IsNot Nothing AndAlso Me.CheckModuleAccess([Module].ModuleCode, False) = 1 Then

                        ParentModule = Nothing

                        Do While True

                            Try

                                If ParentModule Is Nothing Then

                                    ParentModule = ModulesList.Single(Function(ModView) ModView.ModuleID = [Module].ParentModuleID)

                                Else

                                    ParentModule = ModulesList.Single(Function(ModView) ModView.ModuleID = ParentModule.ParentModuleID)

                                End If

                            Catch ex As Exception
                                ParentModule = Nothing
                            End Try

                            If ParentModule IsNot Nothing Then

                                If ParentModule.ParentModuleID Is Nothing Then

                                    ParentModuleDescription = ParentModule.ModuleDescription
                                    Exit Do

                                End If

                            Else

                                ParentModuleDescription = ""
                                Exit Do

                            End If

                        Loop

                        RadListBoxItemList.Add(New Telerik.Web.UI.RadListBoxItem("(" & ParentModuleDescription & ") - " & [Module].ModuleDescription, WorkspaceObject.ID))

                    End If

                Next

                For Each RadListBoxItem In RadListBoxItemList

                    RadListBoxLeftPanel.Items.Add(RadListBoxItem)

                Next

                RadListBoxItemList = Nothing

                RadListBoxItemList = New Generic.List(Of Telerik.Web.UI.RadListBoxItem)

                For Each WorkspaceObject In AdvantageFramework.Security.Database.Procedures.WorkspaceObject.LoadByWorkspaceIDAndZoneID(SecurityDbContext, Me.CurrentWorkspaceId, "RadDockZoneCenter").OrderBy(Function(WorkObject) WorkObject.SortOrder)

                    Try

                        [Module] = ModulesList.Single(Function(ModView) ModView.ModuleID = WorkspaceObject.DesktopObjectID)

                    Catch ex As Exception
                        [Module] = Nothing
                    End Try

                    If [Module] IsNot Nothing AndAlso Me.CheckModuleAccess([Module].ModuleCode, False) = 1 Then

                        ParentModule = Nothing

                        Do While True

                            Try

                                If ParentModule Is Nothing Then

                                    ParentModule = ModulesList.Single(Function(ModView) ModView.ModuleID = [Module].ParentModuleID)

                                Else

                                    ParentModule = ModulesList.Single(Function(ModView) ModView.ModuleID = ParentModule.ParentModuleID)

                                End If

                            Catch ex As Exception
                                ParentModule = Nothing
                            End Try

                            If ParentModule IsNot Nothing Then

                                If ParentModule.ParentModuleID Is Nothing Then

                                    ParentModuleDescription = ParentModule.ModuleDescription
                                    Exit Do

                                End If

                            Else

                                ParentModuleDescription = ""
                                Exit Do

                            End If

                        Loop

                        RadListBoxItemList.Add(New Telerik.Web.UI.RadListBoxItem("(" & ParentModuleDescription & ") - " & [Module].ModuleDescription, WorkspaceObject.ID))

                    End If

                Next

                For Each RadListBoxItem In RadListBoxItemList

                    RadListBoxCenterPanel.Items.Add(RadListBoxItem)

                Next
            End If

        End Using

    End Sub

    Private Sub RefreshMainApplicationWindow(Optional ByVal JustGo As Boolean = False)

        'objects
        Dim AppVars As cAppVars = Nothing
        If Request.QueryString("cp") = "1" Then

        Else

            If JustGo = False Then

                AppVars = New cAppVars(cAppVars.Application.MY_SETTINGS)

                With AppVars
                    .getAllAppVars()
                    .setAppVar("CURRENT_WORKSPACE", Me.CurrentWorkspaceId, "Integer")
                    .SaveAllAppVars()
                End With

            End If

        End If

        Me.AddJavascriptToPage("window.opener.location.href = 'Default.aspx';")

    End Sub

    Private Sub ReOrderObjects(ByRef RadListBoxToReOrder As Telerik.Web.UI.RadListBox)

        'objects
        Dim RadListBoxItem As Telerik.Web.UI.RadListBoxItem = Nothing
        Dim WorkspaceObject As AdvantageFramework.Security.Database.Entities.WorkspaceObject = Nothing
        Dim WorkspaceObjectCP As AdvantageFramework.Security.Database.Entities.ClientPortalWorkspaceObject = Nothing

        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            For Each RadListBoxItem In RadListBoxToReOrder.Items

                If Me.IsClientPortal = True Then
                    WorkspaceObjectCP = AdvantageFramework.Security.Database.Procedures.ClientPortalWorkspaceObject.LoadByWorkspaceObjectID(SecurityDbContext, RadListBoxItem.Value)

                    If WorkspaceObjectCP IsNot Nothing Then

                        WorkspaceObjectCP.SortOrder = RadListBoxItem.Index

                        AdvantageFramework.Security.Database.Procedures.ClientPortalWorkspaceObject.Update(SecurityDbContext, WorkspaceObjectCP)

                    End If
                Else
                    WorkspaceObject = AdvantageFramework.Security.Database.Procedures.WorkspaceObject.LoadByWorkspaceObjectID(SecurityDbContext, RadListBoxItem.Value)

                    If WorkspaceObject IsNot Nothing Then

                        WorkspaceObject.SortOrder = RadListBoxItem.Index

                        AdvantageFramework.Security.Database.Procedures.WorkspaceObject.Update(SecurityDbContext, WorkspaceObject)

                    End If
                End If

            Next

        End Using

    End Sub

    Private Sub DeleteObjectsFromPanel(ByRef RadListBoxToDeleteFrom As Telerik.Web.UI.RadListBox)

        'objects
        Dim WorkspaceObject As AdvantageFramework.Security.Database.Entities.WorkspaceObject = Nothing
        Dim WorkspaceObjectCP As AdvantageFramework.Security.Database.Entities.ClientPortalWorkspaceObject = Nothing
        Dim RadListBoxItem As Telerik.Web.UI.RadListBoxItem = Nothing

        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            For Each RadListBoxItem In RadListBoxToDeleteFrom.SelectedItems

                If Me.IsClientPortal = True Then
                    WorkspaceObjectCP = AdvantageFramework.Security.Database.Procedures.ClientPortalWorkspaceObject.LoadByWorkspaceObjectID(SecurityDbContext, RadListBoxItem.Value)

                    If WorkspaceObjectCP IsNot Nothing Then

                        AdvantageFramework.Security.Database.Procedures.ClientPortalWorkspaceObject.Delete(SecurityDbContext, WorkspaceObjectCP)

                    End If
                Else
                    WorkspaceObject = AdvantageFramework.Security.Database.Procedures.WorkspaceObject.LoadByWorkspaceObjectID(SecurityDbContext, RadListBoxItem.Value)

                    If WorkspaceObject IsNot Nothing Then

                        AdvantageFramework.Security.Database.Procedures.WorkspaceObject.Delete(SecurityDbContext, WorkspaceObject)

                    End If
                End If



            Next

        End Using

        LoadWorkspaceObjects()

    End Sub

    Private Sub InsertObjects(ByRef RadListBoxToInsertTo As Telerik.Web.UI.RadListBox)

        'objects
        Dim RadListBoxItem As Telerik.Web.UI.RadListBoxItem = Nothing
        Dim ZoneID As String = ""

        If RadListBoxToInsertTo.ID = RadListBoxLeftPanel.ID Then

            ZoneID = "RadDockZoneLeft"

        Else

            ZoneID = "RadDockZoneCenter"

        End If

        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            For Each RadListBoxItem In Me.RadListBoxAvailableObjects.SelectedItems

                If Me.IsClientPortal = True Then
                    AdvantageFramework.Security.Database.Procedures.ClientPortalWorkspaceObject.Insert(SecurityDbContext, Me.CurrentWorkspaceId, RadListBoxItem.Value, ZoneID,
                                                                                       Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
                Else
                    AdvantageFramework.Security.Database.Procedures.WorkspaceObject.Insert(SecurityDbContext, Me.CurrentWorkspaceId, RadListBoxItem.Value, ZoneID,
                                                                                       Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
                End If


            Next

        End Using

    End Sub

    Private Sub TransferObjects(ByRef RadListBoxToTransferTo As Telerik.Web.UI.RadListBox)

        'objects
        Dim RadListBoxItem As Telerik.Web.UI.RadListBoxItem = Nothing
        Dim WorkspaceObject As AdvantageFramework.Security.Database.Entities.WorkspaceObject = Nothing
        Dim ZoneID As String = ""

        If RadListBoxToTransferTo.ID = RadListBoxLeftPanel.ID Then

            ZoneID = "RadDockZoneLeft"

        Else

            ZoneID = "RadDockZoneCenter"

        End If

        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            For Each RadListBoxItem In RadListBoxToTransferTo.Items

                WorkspaceObject = AdvantageFramework.Security.Database.Procedures.WorkspaceObject.LoadByWorkspaceObjectID(SecurityDbContext, RadListBoxItem.Value)

                If WorkspaceObject IsNot Nothing Then

                    WorkspaceObject.ZoneID = ZoneID

                    AdvantageFramework.Security.Database.Procedures.WorkspaceObject.Update(SecurityDbContext, WorkspaceObject)

                End If

            Next

        End Using

    End Sub

    Private Sub SetupAddItems()

        If Me.CheckBoxAddToLeft.Checked = False And Me.CheckBoxAddToCenter.Checked = False Then

            Me.TrAvailableObjectsHeader.Visible = False
            Me.TrRadListBoxAvailableObjects.Visible = False
            Me.RadListBoxLeftPanel.TransferToID = Me.RadListBoxCenterPanel.ID

        ElseIf Me.CheckBoxAddToLeft.Checked = True And Me.CheckBoxAddToCenter.Checked = False Then

            Me.TrAvailableObjectsHeader.Visible = True
            Me.TrRadListBoxAvailableObjects.Visible = True
            If Me.IsClientPortal Or Request.QueryString("cp") = "1" Then
                Me.LoadListBoxAvailableObjectsCP()
            Else
                Me.LoadListBoxAvailableObjects()
            End If
            Me.RadListBoxAvailableObjects.TransferToID = Me.RadListBoxLeftPanel.ID

        ElseIf Me.CheckBoxAddToLeft.Checked = False And Me.CheckBoxAddToCenter.Checked = True Then

            Me.TrAvailableObjectsHeader.Visible = True
            Me.TrRadListBoxAvailableObjects.Visible = True
            If Me.IsClientPortal Or Request.QueryString("cp") = "1" Then
                Me.LoadListBoxAvailableObjectsCP()
            Else
                Me.LoadListBoxAvailableObjects()
            End If
            Me.RadListBoxAvailableObjects.TransferToID = Me.RadListBoxCenterPanel.ID

        ElseIf Me.CheckBoxAddToLeft.Checked = True And Me.CheckBoxAddToCenter.Checked = True Then

            Me.TrAvailableObjectsHeader.Visible = False
            Me.TrRadListBoxAvailableObjects.Visible = False
            Me.CheckBoxAddToLeft.Checked = False
            Me.CheckBoxAddToCenter.Checked = False

        End If

    End Sub

    Private Sub LoadApplicationMenu()

        'objects
        Dim ModuleView As AdvantageFramework.Security.Database.Views.ModuleView = Nothing
        Dim RadTreeNode As Telerik.Web.UI.RadTreeNode = Nothing
        Dim ModulesList As Generic.List(Of AdvantageFramework.Security.Database.Views.ModuleView) = Nothing

        Me.RadTreeViewQuickLaunch.Nodes.Clear()

        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            ModulesList = AdvantageFramework.Security.Database.Procedures.ModuleView.Load(SecurityDbContext).ToList

            For Each ModuleView In ModulesList.Where(Function(ModView) ModView.ApplicationID = _Session.Application AndAlso ModView.ParentModuleID Is Nothing AndAlso
                                                                       ModView.IsInactive = False AndAlso ModView.IsMenuItem = True).OrderBy(Function(ModView) ModView.SortOrder)

                RadTreeNode = New Telerik.Web.UI.RadTreeNode

                RadTreeNode.Text = ModuleView.ModuleDescription
                RadTreeNode.Checkable = False

                RadTreeViewQuickLaunch.Nodes.Add(RadTreeNode)

                LoadApplicationSubMenu(_Session.Application, ModuleView, RadTreeNode, ModulesList)

                If RadTreeNode.Nodes.Count = 0 Then

                    RadTreeViewQuickLaunch.Nodes.Remove(RadTreeNode)

                End If

            Next

            RadTreeViewQuickLaunch.CheckBoxes = True

        End Using

    End Sub

    Private Sub LoadApplicationSubMenu(ByVal ApplicationID As Integer, ByVal ModuleView As AdvantageFramework.Security.Database.Views.ModuleView, ByRef ParentRadTreeNode As Telerik.Web.UI.RadTreeNode, ByRef ModulesList As Generic.List(Of AdvantageFramework.Security.Database.Views.ModuleView))

        'objects
        Dim RadTreeNode As Telerik.Web.UI.RadTreeNode = Nothing
        Dim SubModule As AdvantageFramework.Security.Database.Views.ModuleView = Nothing

        Try

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                For Each SubModule In ModulesList.Where(Function(ModView) ModView.ApplicationID = ApplicationID AndAlso ModView.ParentModuleID.GetValueOrDefault(0) = ModuleView.ModuleID AndAlso
                                                                          ModView.IsInactive = False AndAlso ModView.IsMenuItem = True AndAlso ModView.IsDesktopObject = False).OrderBy(Function(ModView) ModView.SortOrder)

                    If SubModule.IsCategory Then

                        If ModulesList.Any(Function(ModView) ModView.ApplicationID = ApplicationID AndAlso ModView.ParentModuleID.GetValueOrDefault(0) = SubModule.ModuleID AndAlso
                                                             ModView.IsMenuItem AndAlso ModView.IsDesktopObject = False AndAlso ModView.IsInactive = False) Then

                            RadTreeNode = New Telerik.Web.UI.RadTreeNode

                            RadTreeNode.Text = SubModule.ModuleDescription
                            RadTreeNode.Checkable = False

                            ParentRadTreeNode.Nodes.Add(RadTreeNode)

                            LoadApplicationSubMenu(ApplicationID, SubModule, RadTreeNode, ModulesList)

                            If RadTreeNode.Nodes.Count = 0 Then

                                ParentRadTreeNode.Nodes.Remove(RadTreeNode)

                            End If

                        End If

                    Else

                        If Me.CheckModuleAccess(SubModule.ModuleCode, False) = 1 Then

                            RadTreeNode = New Telerik.Web.UI.RadTreeNode

                            RadTreeNode.Text = SubModule.ModuleDescription
                            RadTreeNode.Checkable = True

                            RadTreeNode.Attributes.Add("ID", SubModule.ModuleID)

                            If AdvantageFramework.Security.Database.Procedures.UserFavoriteModule.LoadByUserCodeAndWorkspaceIDAndModuleID(SecurityDbContext, _Session.UserCode, Me.CurrentWorkspaceId, SubModule.ModuleID) IsNot Nothing Then

                                RadTreeNode.Checked = True

                            End If

                            If (Me.IsClientPortal = True Or Request.QueryString("cp") = "1") And SubModule.ModuleDescription = "Project Schedule" Then

                            Else
                                ParentRadTreeNode.Nodes.Add(RadTreeNode)
                            End If


                        End If

                    End If

                Next

            End Using

        Catch ex As Exception
            RadTreeNode = Nothing
        End Try

    End Sub

    Public Sub DeleteWorkspace(ByVal UserWorkspaceID As Integer)
        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
            If Me.IsClientPortal = True Then
                Dim ClientPortalUserWorkspace As AdvantageFramework.Security.Database.Entities.ClientPortalUserWorkspace = Nothing
                ClientPortalUserWorkspace = AdvantageFramework.Security.Database.Procedures.ClientPortalUserWorkspace.LoadByUserWorkspaceID(SecurityDbContext, UserWorkspaceID)
                If ClientPortalUserWorkspace IsNot Nothing Then
                    If AdvantageFramework.Security.Database.Procedures.ClientPortalUserWorkspace.Delete(SecurityDbContext, ClientPortalUserWorkspace) Then
                        Me.LoadWorkspaces()
                        If Me.RadListBoxWorkspaces.Items.Count > 0 Then
                            Me.CurrentWorkspaceId = Me.RadListBoxWorkspaces.Items(0).Value
                        Else
                            Me.CurrentWorkspaceId = Me.NextWorkspaceId()
                        End If
                        Me.SaveCurrentWorkspaceId(Me.CurrentWorkspaceId)
                        Me.SetPage()
                        Me.RefreshMainApplicationWindow()
                    End If
                End If
            Else
                Dim UserWorkspace As AdvantageFramework.Security.Database.Entities.UserWorkspace = Nothing
                UserWorkspace = AdvantageFramework.Security.Database.Procedures.UserWorkspace.LoadByUserWorkspaceID(SecurityDbContext, UserWorkspaceID)
                If UserWorkspace IsNot Nothing Then
                    If AdvantageFramework.Security.Database.Procedures.UserWorkspace.Delete(SecurityDbContext, UserWorkspace) Then
                        Me.LoadWorkspaces()
                        If Me.RadListBoxWorkspaces.Items.Count > 0 Then
                            Me.CurrentWorkspaceId = Me.RadListBoxWorkspaces.Items(0).Value
                        Else
                            Me.CurrentWorkspaceId = Me.NextWorkspaceId()
                        End If
                        Me.SaveCurrentWorkspaceId(Me.CurrentWorkspaceId)
                        Me.SetPage()
                        Me.RefreshMainApplicationWindow()

                    End If
                End If
            End If
        End Using
    End Sub

    Private Sub LoadWorkspace()
        Try
            If IsNumeric(Me.RadListBoxWorkspaces.SelectedValue) = True Then
                Me.CurrentWorkspaceId = CType(Me.RadListBoxWorkspaces.SelectedValue, Integer)
                Me.LoadWorkspaceObjects()
                Me.LoadApplicationMenu()
                Me.RefreshMainApplicationWindow()
            Else
                Exit Sub
            End If
        Catch ex As Exception
            Me.ShowMessage("Cannot load Workspace")
        End Try
    End Sub

    Private Function NextWorkspaceId() As Integer
        Try
            Dim arP(2) As System.Data.SqlClient.SqlParameter
            Dim pUserCode As New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
            pUserCode.Value = Session("UserCode")
            arP(0) = pUserCode
            Dim pMoveDirection As New System.Data.SqlClient.SqlParameter("@MOVE_DIRECTION", SqlDbType.VarChar, 1)
            pMoveDirection.Value = "+"
            arP(1) = pMoveDirection
            Dim i As Integer = CType(SqlHelper.ExecuteScalar(Session("ConnString"), CommandType.StoredProcedure, "usp_wv_WORKSPACE_NAVIGATE", arP), Integer)
            Me.CurrentWorkspaceId = i
            Try
                MiscFN.RadListBoxSetIndex(Me.RadListBoxWorkspaces, Me.CurrentWorkspaceId, False)
            Catch ex As Exception
            End Try
            Return i
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Private Sub SaveQuickLaunch()
        If IsClientPortal = True Then
            SqlHelper.ExecuteNonQuery(Session("ConnString"), CommandType.Text, "DELETE FROM CP_USER_QUICK_LAUNCH_APPS WITH(ROWLOCK) WHERE CDP_CONTACT_ID = '" & Session("UserID") & "' AND TAB_ID = " & Me.CurrentWorkspaceId & ";" &
                                  "DELETE FROM CP_USER_QUICK_LAUNCH_REPORTS WITH(ROWLOCK) WHERE CDP_CONTACT_ID = '" & Session("UserID") & "' AND TAB_ID = " & Me.CurrentWorkspaceId & ";")
            Dim ModuleID As Integer = 0
            For Each TreeNode As RadTreeNode In Me.RadTreeViewQuickLaunch.CheckedNodes
                If TreeNode.Attributes("ID") <> "" AndAlso IsNumeric(TreeNode.Attributes("ID")) Then
                    ModuleID = CInt(TreeNode.Attributes("ID"))
                    Using ThisSecurityObjectContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                        AdvantageFramework.Security.Database.Procedures.CPUserFavoriteModule.Insert(ThisSecurityObjectContext, Session("UserID"),
                                                                                                  Me.CurrentWorkspaceId, ModuleID, Nothing)
                    End Using
                End If
            Next
        Else
            SqlHelper.ExecuteNonQuery(Session("ConnString"), CommandType.Text, "DELETE FROM WV_USER_QUICK_LAUNCH_APPS WITH(ROWLOCK) WHERE USERID = '" & Session("UserCode") & "' AND TABNO = " & Me.CurrentWorkspaceId & ";" &
                                  "DELETE FROM WV_USER_QUICK_LAUNCH_REPORTS WITH(ROWLOCK) WHERE USERID = '" & Session("UserCode") & "' AND TABNO = " & Me.CurrentWorkspaceId & ";")
            Dim ModuleID As Integer = 0
            For Each TreeNode As RadTreeNode In Me.RadTreeViewQuickLaunch.CheckedNodes
                If TreeNode.Attributes("ID") <> "" AndAlso IsNumeric(TreeNode.Attributes("ID")) Then
                    ModuleID = CInt(TreeNode.Attributes("ID"))
                    Using ThisSecurityObjectContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                        AdvantageFramework.Security.Database.Procedures.UserFavoriteModule.Insert(ThisSecurityObjectContext, _Session.UserCode,
                                                                                                  Me.CurrentWorkspaceId, ModuleID, Nothing)
                    End Using
                End If
            Next
        End If
    End Sub

    Private Sub SaveWorkspaceOptions()
        Try
            Dim t As New UserTheme(Session("EmpCode"), Session("UserCode"), Session("ConnString"), Me.IsClientPortal)
            t.LoadFromDatabase()
            With t.Settings

                .FloatDesktopObjects = Me.CheckBoxFloatObjects.Checked
                .SingleNodeMainMenu = Me.RadioButtonMenuSingleNode.Checked

            End With

            t.Save()

        Catch ex As Exception
        End Try
    End Sub

    Private Sub LoadWorkspaceOptions()
        Try
            Dim t As New UserTheme(Session("EmpCode"), Session("UserCode"), Session("ConnString"))
            With t
                .Load()
                Try
                    Me.CheckBoxFloatObjects.Checked = .Settings.FloatDesktopObjects
                Catch ex As Exception
                End Try
                Try
                    Me.RadioButtonMenuSingleNode.Checked = .Settings.SingleNodeMainMenu
                    Me.RadioButtonMenuFull.Checked = Not .Settings.SingleNodeMainMenu
                Catch ex As Exception
                End Try
            End With
        Catch ex As Exception

        End Try
    End Sub

#End Region

    Private Sub ImageButtonCancelNewWorkspace_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonCancelNewWorkspace.Click
        Me.TextBoxNewWorkspaceName.Text = ""
        Me.DivNewWorkspace.Visible = False
        Me.DivNewTemplate.Visible = False
        Me.TableWorkspaces.Visible = True
    End Sub

    Private Sub ImageButtonSaveNewWorkspace_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonSaveNewWorkspace.Click
        Dim UserWorkspace As AdvantageFramework.Security.Database.Entities.UserWorkspace = Nothing
        Dim UserWorkspaceCP As AdvantageFramework.Security.Database.Entities.ClientPortalUserWorkspace = Nothing
        Dim UserWorkspaceCount As Integer = 0
        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
            If Me.TextBoxNewWorkspaceName.Text.Trim() = "" Then
                Me.ShowMessage("Please enter a name for your new Workspace")
                Me.SetPage()
            Else
                If Me.IsClientPortal = True Then
                    UserWorkspaceCount = AdvantageFramework.Security.Database.Procedures.ClientPortalUserWorkspace.LoadByUserID(SecurityDbContext, _Session.ClientPortalUser.ClientContactID).Max(Function(Workspace) Workspace.SortOrder).GetValueOrDefault(0) + 1
                    If AdvantageFramework.Security.Database.Procedures.ClientPortalUserWorkspace.Insert(SecurityDbContext, _Session.ClientPortalUser.ClientContactID, Me.TextBoxNewWorkspaceName.Text.Trim(), Nothing, UserWorkspaceCount, UserWorkspaceCP) Then
                        Me.CurrentWorkspaceId = UserWorkspaceCP.ID
                        Me.SetPage()
                        Me.RefreshMainApplicationWindow()
                    End If
                Else
                    If Request.QueryString("cp") = "1" Then
                        UserWorkspaceCount = AdvantageFramework.Security.Database.Procedures.UserWorkspace.LoadByUserCode(SecurityDbContext, _Session.UserCode).Max(Function(Workspace) Workspace.SortOrder).GetValueOrDefault(0) + 1
                        If AdvantageFramework.Security.Database.Procedures.UserWorkspace.Insert(SecurityDbContext, _Session.UserCode, Me.TextBoxNewWorkspaceName.Text.Trim(), Nothing, UserWorkspaceCount, 1, UserWorkspace) Then
                            Me.CurrentWorkspaceId = UserWorkspace.ID
                            Me.SetPage()
                            Me.RefreshMainApplicationWindow()
                        End If
                    Else
                        UserWorkspaceCount = AdvantageFramework.Security.Database.Procedures.UserWorkspace.LoadByUserCode(SecurityDbContext, _Session.UserCode).Max(Function(Workspace) Workspace.SortOrder).GetValueOrDefault(0) + 1
                        If AdvantageFramework.Security.Database.Procedures.UserWorkspace.Insert(SecurityDbContext, _Session.UserCode, Me.TextBoxNewWorkspaceName.Text.Trim(), Nothing, UserWorkspaceCount, 0, UserWorkspace) Then
                            Me.CurrentWorkspaceId = UserWorkspace.ID
                            Me.SetPage()
                            Me.RefreshMainApplicationWindow()
                        End If
                    End If

                End If

            End If
        End Using
    End Sub

    Private Sub ImageButtonCancelNewTemplate_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonCancelNewTemplate.Click
        Me.TextBoxNewTemplateName.Text = ""
        Me.DivNewWorkspace.Visible = False
        Me.DivNewTemplate.Visible = False
        Me.TableWorkspaces.Visible = True
    End Sub

    Private Sub ImageButtonSaveNewTemplate_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonSaveNewTemplate.Click
        Me.SaveNewTemplate(Me.TextBoxNewTemplateName.Text.Trim())
    End Sub

    Private Sub SaveNewTemplate(ByVal TemplateName As String)
        Try
            Dim i As Integer
            If Me.IsClientPortal = True Or Request.QueryString("cp") = "1" Then
                i = Me.SaveNewWorkspaceTemplateCP(TemplateName, "")
            Else
                i = Me.SaveNewWorkspaceTemplate(TemplateName, "")
            End If
            Select Case i
                Case Is > 0
                    Me.TrExistingTemplate.Visible = True
                Case -1
                Case Else
                    Me.RadGridWorkspaceTemplates.Rebind()
                    Me.TableWorkspaces.Visible = True
                    Me.DivNewTemplate.Visible = False
                    Me.DivNewWorkspace.Visible = False
            End Select
        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try
    End Sub

    Private Sub RadToolBarTemplates_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarTemplates.ButtonClick
        Select Case e.Item.Value
            'Case "ApplyToSelf"
            '    Try
            '        If Me.RadListBoxWorkspaceTemplates.SelectedIndex > -1 Then
            '            Dim arP(2) As SqlParameter
            '            If Me.IsClientPortal = True Then
            '                Dim pUserId As New SqlParameter("@CP_USER_ID", SqlDbType.Int)
            '                pUserId.Value = _Session.ClientPortalUser.ClientContactID
            '                arP(0) = pUserId
            '            Else
            '                Dim pUserId As New SqlParameter("@SEC_USER_ID", SqlDbType.Int)
            '                pUserId.Value = _Session.User.ID
            '                arP(0) = pUserId
            '            End If

            '            Dim pWorkspaceTemplateId As New SqlParameter("@WORKSPACE_TEMPLATE_ID", SqlDbType.Int)
            '            pWorkspaceTemplateId.Value = Me.RadListBoxWorkspaceTemplates.SelectedValue
            '            arP(1) = pWorkspaceTemplateId
            '            If Me.IsClientPortal = True Then
            '                SqlHelper.ExecuteNonQuery(Session("ConnString"), CommandType.StoredProcedure, "usp_CP_WORKSPACE_TMPLT_APPLY_TO_USER", arP)
            '            Else
            '                SqlHelper.ExecuteNonQuery(Session("ConnString"), CommandType.StoredProcedure, "usp_WV_WORKSPACE_TMPLT_APPLY_TO_USER", arP)
            '            End If
            '            Me.NextWorkspaceId()
            '            Me.SetInitialWorkspaceId()
            '            Me.SetPage()
            '            Me.RefreshMainApplicationWindow()
            '        Else
            '            Me.ShowMessage("Please select a Workspace Template before trying to apply it")
            '        End If
            '    Catch ex As Exception
            '        Me.ShowMessage(ex.Message.ToString())
            '    End Try
            Case "Refresh"
                Me.RadGridWorkspaceTemplates.Rebind()
        End Select
    End Sub

    Private Sub ButtonCancelOverwriteExistingTemplate_Click(sender As Object, e As System.EventArgs) Handles ButtonCancelOverwriteExistingTemplate.Click
        Me.TextBoxNewTemplateName.Focus()
        Me.TrExistingTemplate.Visible = False
    End Sub

    Private Sub ButtonOverwriteExistingTemplate_Click(sender As Object, e As System.EventArgs) Handles ButtonOverwriteExistingTemplate.Click
        Try
            Dim TemplateId As Integer
            If Request.QueryString("cp") = "1" Then
                TemplateId = Me.SaveNewWorkspaceTemplateCP(Me.TextBoxNewTemplateName.Text, "")
            Else
                TemplateId = Me.SaveNewWorkspaceTemplate(Me.TextBoxNewTemplateName.Text, "")
            End If
            If TemplateId > 0 Then
                Dim SQL As New System.Text.StringBuilder
                With SQL
                    .Append(" DELETE ")
                    .Append(" FROM   WV_WORKSPACE_TMPLT_ITEM WITH(ROWLOCK) ")
                    .Append(" WHERE  WORKSPACE_ID IN (SELECT WV_WORKSPACE_TMPLT_DTL.WORKSPACE_ID ")
                    .Append("                         FROM   WV_WORKSPACE_TMPLT_DTL ")
                    .Append("                         WHERE  TEMPLATE_ID = " & TemplateId & ");")
                    .Append(" DELETE ")
                    .Append(" FROM   WV_WORKSPACE_TMPLT_DTL WITH(ROWLOCK) ")
                    .Append(" WHERE  TEMPLATE_ID = " & TemplateId & ";")
                    .Append(" DELETE ")
                    .Append(" FROM   WV_WORKSPACE_TMPLT_HDR WITH(ROWLOCK) ")
                    .Append(" WHERE  TEMPLATE_ID = " & TemplateId & ";")
                End With
                SqlHelper.ExecuteNonQuery(Session("ConnString"), CommandType.Text, SQL.ToString())
                If Request.QueryString("cp") = "1" Then
                    If Me.SaveNewWorkspaceTemplateCP(Me.TextBoxNewTemplateName.Text, "") = 0 Then
                        Me.DivNewTemplate.Visible = False
                        Me.DivNewWorkspace.Visible = False
                        Me.TrExistingTemplate.Visible = False
                        Me.TableWorkspaces.Visible = True
                        Me.RadGridWorkspaceTemplates.Rebind()
                    End If
                Else
                    If Me.SaveNewWorkspaceTemplate(Me.TextBoxNewTemplateName.Text, "") = 0 Then
                        Me.DivNewTemplate.Visible = False
                        Me.DivNewWorkspace.Visible = False
                        Me.TrExistingTemplate.Visible = False
                        Me.TableWorkspaces.Visible = True
                        Me.RadGridWorkspaceTemplates.Rebind()
                    End If
                End If

            End If
        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try
    End Sub

    Private Function SaveNewWorkspaceTemplate(ByVal TemplateName As String, ByVal TemplateDescription As String) As Integer
        Try
            TemplateName = TemplateName.Trim()
            TemplateDescription = TemplateDescription.Trim()

            If TemplateName = "" Then
                Me.ShowMessage("Please enter a name for your new Workspace Template")
                Return -1
            End If
            Dim arP(3) As SqlParameter
            Dim pUserId As New SqlParameter("@SEC_USER_ID", SqlDbType.Int)
            pUserId.Value = _Session.User.ID
            arP(0) = pUserId
            Dim pTemplateName As New SqlParameter("@TEMPLATE_NAME", SqlDbType.VarChar, 50)
            pTemplateName.Value = TemplateName
            arP(1) = pTemplateName
            Dim pTemplateDescription As New SqlParameter("@TEMPLATE_DESC", SqlDbType.VarChar, 100)
            If TemplateDescription = "" Then
                pTemplateDescription.Value = System.DBNull.Value
            Else
                pTemplateDescription.Value = TemplateDescription
            End If
            arP(2) = pTemplateDescription
            Return CType(SqlHelper.ExecuteScalar(Session("ConnString"), CommandType.StoredProcedure, "usp_WV_WORKSPACE_TMPLT_INSERT", arP), Integer)
        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
            Return -1
        End Try
    End Function
    Private Function SaveNewWorkspaceTemplateCP(ByVal TemplateName As String, ByVal TemplateDescription As String) As Integer
        Try
            TemplateName = TemplateName.Trim()
            TemplateDescription = TemplateDescription.Trim()

            If TemplateName = "" Then
                Me.ShowMessage("Please enter a name for your new Workspace Template")
                Return -1
            End If
            Dim arP(3) As SqlParameter
            Dim pUserId As New SqlParameter("@CP_USER_ID", SqlDbType.Int)
            If Request.QueryString("cp") = "1" Then
                pUserId.Value = _Session.User.ID
            Else
                pUserId.Value = _Session.ClientPortalUser.ClientContactID
            End If
            arP(0) = pUserId
            Dim pTemplateName As New SqlParameter("@TEMPLATE_NAME", SqlDbType.VarChar, 50)
            pTemplateName.Value = TemplateName
            arP(1) = pTemplateName
            Dim pTemplateDescription As New SqlParameter("@TEMPLATE_DESC", SqlDbType.VarChar, 100)
            If TemplateDescription = "" Then
                pTemplateDescription.Value = System.DBNull.Value
            Else
                pTemplateDescription.Value = TemplateDescription
            End If
            arP(2) = pTemplateDescription
            Return CType(SqlHelper.ExecuteScalar(Session("ConnString"), CommandType.StoredProcedure, "usp_CP_WORKSPACE_TMPLT_INSERT", arP), Integer)
        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
            Return -1
        End Try
    End Function

    Private Sub SaveCurrentWorkspaceId(ByVal WorkspaceId As Integer)
        Try
            Dim a As New cAppVars(cAppVars.Application.MY_SETTINGS)
            a.setAppVarDB("CURRENT_WORKSPACE", WorkspaceId)
        Catch ex As Exception
        End Try
    End Sub

    ''Private Sub LoadWorkspaceTemplates()
    ''    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
    ''        With Me.RadListBoxWorkspaceTemplates
    ''            If Me.IsClientPortal = True Then
    ''                .DataSource = AdvantageFramework.Security.Database.Procedures.WorkspaceTemplate.Load(SecurityDbContext).Where(Function(WorkspaceTemplate) WorkspaceTemplate.IsClientPortal = 1)
    ''            Else
    ''                .DataSource = AdvantageFramework.Security.Database.Procedures.WorkspaceTemplate.LoadByUserID(SecurityDbContext, _Session.User.ID)
    ''            End If
    ''            .DataTextField = "Name"
    ''            .DataValueField = "ID"
    ''            .DataBind()
    ''        End With
    ''    End Using
    ''End Sub

    Public Sub ShowMessage(ByVal [ErrorMessage] As String)
        Me.Page.ClientScript.RegisterStartupScript(Me.Page.GetType(), "msg", "ShowMessage('" & MiscFN.JavascriptSafe(ErrorMessage) & "');", True)
    End Sub

    Private Sub Workspace_Manage_LoadComplete(sender As Object, e As System.EventArgs) Handles Me.LoadComplete
        Try
            If Me.RadListBoxWorkspaces.SelectedIndex = -1 Then
                Me.RadToolBarCurrentWorkspace.Enabled = False
            Else
                Me.RadToolBarCurrentWorkspace.Enabled = True
            End If
        Catch ex As Exception
        End Try
        If Me.DivNewTemplate.Visible = True Or Me.DivNewWorkspace.Visible = True Then
            Me.CollapsablePanelCurrentWorkspaces.Visible = False
        Else
            Me.CollapsablePanelCurrentWorkspaces.Visible = True
        End If
        If Request.QueryString("cp") = 1 Then
            'Me.RadToolBarCurrentWorkspace.Visible = False
            'Me.RadToolBarCPTemplate.Visible = True
        End If
    End Sub

    Private Sub RadGridWorkspaceTemplates_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridWorkspaceTemplates.ItemCommand
        Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        CurrentGridDataItem = RadGridWorkspaceTemplates.Items(e.Item.ItemIndex)
        Dim WorkspaceTemplateId As Integer = 0

        Try
            If Not CurrentGridDataItem Is Nothing Then
                WorkspaceTemplateId = CType(CurrentGridDataItem.GetDataKeyValue("ID"), Integer)
            End If
        Catch ex As Exception
            WorkspaceTemplateId = 0
        End Try


        If WorkspaceTemplateId > 0 Then

            Dim pWorkspaceTemplateId As New SqlParameter("@WORKSPACE_TEMPLATE_ID", SqlDbType.Int)
            pWorkspaceTemplateId.Value = WorkspaceTemplateId

            Select Case e.CommandName
                Case "SaveRow"
                    Dim TemplateName As String = ""
                    Try
                        TemplateName = CType(CurrentGridDataItem.FindControl("LabelTemplateName"), Label).Text
                    Catch ex As Exception
                        TemplateName = ""
                    End Try
                    If TemplateName <> "" Then
                        'delete existing:
                        SqlHelper.ExecuteNonQuery(Session("ConnString"), CommandType.StoredProcedure, "usp_WV_WORKSPACE_TMPLT_DELETE", pWorkspaceTemplateId)
                        'save new:
                        Me.SaveNewTemplate(TemplateName)
                    End If
                    Me.RadGridWorkspaceTemplates.Rebind()
                Case "ApplyToSelf"
                    Dim arP(2) As SqlParameter
                    If Me.IsClientPortal = True Or Request.QueryString("cp") = "1" Then
                        Dim pUserId As New SqlParameter("@CP_USER_ID", SqlDbType.Int)
                        pUserId.Value = _Session.ClientPortalUser.ClientContactID
                        arP(0) = pUserId
                    Else
                        Dim pUserId As New SqlParameter("@SEC_USER_ID", SqlDbType.Int)
                        pUserId.Value = _Session.User.ID
                        arP(0) = pUserId
                    End If

                    arP(1) = pWorkspaceTemplateId

                    If Me.IsClientPortal = True Or Request.QueryString("cp") = "1" Then
                        SqlHelper.ExecuteNonQuery(Session("ConnString"), CommandType.StoredProcedure, "usp_CP_WORKSPACE_TMPLT_APPLY_TO_USER", arP)
                    Else
                        SqlHelper.ExecuteNonQuery(Session("ConnString"), CommandType.StoredProcedure, "usp_WV_WORKSPACE_TMPLT_APPLY_TO_USER", arP)
                    End If

                    If Me.IsClientPortal = False Then
                        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session("ConnString"), Session("UserCode"))
                            SecurityDbContext.Database.ExecuteSqlCommand("UPDATE dbo.EMPLOYEE SET WV_TMPLT_HDR_ID = " & WorkspaceTemplateId & " WHERE EMP_CODE = '" & Session("EmpCode") & "'")
                        End Using
                    End If

                    If Me.IsClientPortal = False Then
                        Dim Employee As AdvantageFramework.Security.Database.Views.Employee
                        Dim WorkspaceTemplate As AdvantageFramework.Security.Database.Entities.WorkspaceTemplate
                        Using DbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                            Employee = AdvantageFramework.Security.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Session("EmpCode"))
                            If Not Employee.WorkspaceTemplateID Is Nothing Then
                                WorkspaceTemplate = AdvantageFramework.Security.Database.Procedures.WorkspaceTemplate.LoadByWorkspaceTemplateID(DbContext, Employee.WorkspaceTemplateID)
                                If Not Employee.WorkspaceTemplateID Is Nothing And Request.QueryString("cp") <> 1 Then
                                    If Not WorkspaceTemplate Is Nothing Then
                                        Me.LabelTemplate.Text = "Last Template Applied '" & WorkspaceTemplate.Name & "'"
                                    End If
                                End If
                            End If
                        End Using
                    End If

                    Me.NextWorkspaceId()
                    Me.SetInitialWorkspaceId()
                    Me.SetPage()
                    Me.RefreshMainApplicationWindow()

                    Me.RadGridWorkspaceTemplates.Rebind()
                Case "DeleteRow"
                    SqlHelper.ExecuteNonQuery(Session("ConnString"), CommandType.StoredProcedure, "usp_WV_WORKSPACE_TMPLT_DELETE", pWorkspaceTemplateId)
                    Me.RadGridWorkspaceTemplates.Rebind()
            End Select

        End If

    End Sub

    Private Sub RadGridWorkspaceTemplates_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridWorkspaceTemplates.ItemDataBound
        If TypeOf e.Item Is Telerik.Web.UI.GridDataItem Then

            Dim dataItem As Telerik.Web.UI.GridDataItem = e.Item

            Dim imgbtnApplyToSelf As System.Web.UI.WebControls.ImageButton
            Try
                imgbtnApplyToSelf = CType(dataItem.FindControl("ImageButtonApplyToSelf"), ImageButton)
                imgbtnApplyToSelf.Attributes("onclick") = "return confirm('Are you sure you want to apply this Template?')"
            Catch ex As Exception
            End Try

            Dim imgbtnReplace As System.Web.UI.WebControls.ImageButton
            Try
                imgbtnReplace = CType(dataItem.FindControl("ImageButtonSave"), ImageButton)
                imgbtnReplace.Attributes("onclick") = "return confirm('Are you sure you want to replace this Template?')"
            Catch ex As Exception
            End Try

            Dim imgbtnDelete As System.Web.UI.WebControls.ImageButton
            Try
                imgbtnDelete = CType(dataItem.FindControl("ImageButtonDelete"), ImageButton)
                imgbtnDelete.Attributes("onclick") = "return confirm('Are you sure you want to delete this Template?')"
            Catch ex As Exception
            End Try

            If Me.IsClientPortal = True Then
                imgbtnReplace.Visible = False
                imgbtnDelete.Visible = False
            End If
            If Request.QueryString("cp") = "1" Then
                imgbtnApplyToSelf.Visible = False
            End If

        End If
    End Sub

    Private Sub RadGridWorkspaceTemplates_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridWorkspaceTemplates.NeedDataSource
        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
            With Me.RadGridWorkspaceTemplates
                If Me.IsClientPortal = True Or Request.QueryString("cp") = "1" Then

                    .DataSource = AdvantageFramework.Security.Database.Procedures.WorkspaceTemplate.Load(SecurityDbContext).Where(Function(WorkspaceTemplate) WorkspaceTemplate.IsClientPortal = 1).ToList

                Else

                    .DataSource = AdvantageFramework.Security.Database.Procedures.WorkspaceTemplate.LoadNonClientPortalWorkspaceTemplates(SecurityDbContext).ToList()

                End If
            End With
        End Using
    End Sub

    'Private Sub RadToolBarCPTemplate_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarCPTemplate.ButtonClick
    '    Try
    '        Select Case e.Item.Value
    '            Case "Add"
    '                Dim UserWorkspace As AdvantageFramework.Security.Database.Entities.UserWorkspace = Nothing
    '                Dim UserWorkspaceCP As AdvantageFramework.Security.Database.Entities.ClientPortalUserWorkspace = Nothing
    '                Dim UserWorkspaceCount As Integer = 0
    '                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
    '                    If Me.TextBoxWorkspaceName.Text.Trim() = "" Then
    '                        Me.ShowMessage("Please enter a name for your new template")
    '                        Me.SetPage()
    '                    Else
    '                        UserWorkspaceCount = AdvantageFramework.Security.Database.Procedures.UserWorkspace.LoadByUserCode(SecurityDbContext, _Session.UserCode).Max(Function(Workspace) Workspace.SortOrder).GetValueOrDefault(0) + 1
    '                        If AdvantageFramework.Security.Database.Procedures.UserWorkspace.Insert(SecurityDbContext, _Session.UserCode, Me.TextBoxWorkspaceName.Text.Trim(), Nothing, UserWorkspaceCount, UserWorkspace) Then
    '                            Me.CurrentWorkspaceId = UserWorkspace.ID
    '                            'Me.TextBoxWorkspaceName.Text = Me.TextBoxWorkspaceName.Text
    '                            'Me.SetPage()
    '                            'Me.RefreshMainApplicationWindow()
    '                        End If
    '                    End If
    '                End Using
    '                Me.FieldsetPanels.Visible = True
    '                Me.RadToolBarCPTemplate.Items(0).Enabled = False
    '                Me.RadToolBarCPTemplate.Items(2).Enabled = True
    '            Case "Save"
    '                Dim UserWorkspace As AdvantageFramework.Security.Database.Entities.UserWorkspace = Nothing
    '                Dim UserWorkspaceCP As AdvantageFramework.Security.Database.Entities.ClientPortalUserWorkspace = Nothing
    '                Dim UserWorkspaceCount As Integer = 0
    '                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
    '                    SaveNewTemplate(Me.TextBoxWorkspaceName.Text.Trim())
    '                    Me.DeleteWorkspace(Me.CurrentWorkspaceId)
    '                    Me.FieldsetPanels.Visible = False
    '                    Me.RadToolBarCPTemplate.Items(0).Enabled = True
    '                    Me.RadToolBarCPTemplate.Items(2).Enabled = False
    '                End Using
    '        End Select
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub CheckBoxFloatObjects_CheckedChanged(sender As Object, e As System.EventArgs) Handles CheckBoxFloatObjects.CheckedChanged
        Try
            Me.SaveWorkspaceOptions()
            Me.RefreshMainApplicationWindow()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadioButtonMenuFull_CheckedChanged(sender As Object, e As System.EventArgs) Handles RadioButtonMenuFull.CheckedChanged
        Try
            Me.SaveWorkspaceOptions()
            Me.RefreshMainApplicationWindow()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadioButtonMenuSingleNode_CheckedChanged(sender As Object, e As System.EventArgs) Handles RadioButtonMenuSingleNode.CheckedChanged
        Try
            Me.SaveWorkspaceOptions()
            Me.RefreshMainApplicationWindow()
        Catch ex As Exception

        End Try
    End Sub
End Class
