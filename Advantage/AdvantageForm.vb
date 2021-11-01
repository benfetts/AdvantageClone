Imports DevComponents.DotNetBar

Public Class AdvantageForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _LoadingSubItems As Boolean = False
    Private _LoadingNavigationMenus As Boolean = False
    Private _UserSettingsList As Generic.List(Of AdvantageFramework.Security.Database.Entities.UserSetting) = Nothing
    Private _UserMenusList As Generic.List(Of AdvantageFramework.Security.Database.Entities.UserMenu) = Nothing
    Private _UserMenuTabsList As Generic.List(Of AdvantageFramework.Security.Database.Entities.UserMenuTab) = Nothing
    Private Shared _SplashScreenFormClosed As Boolean = False
    Private WithEvents _DatabaseScriptCheckBackgroundWorker As System.ComponentModel.BackgroundWorker = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        If My.Application.CommandLineArgs.Count = 0 Then

            _UseSecurityLogin = True

        Else

            _UseSecurityLogin = False

        End If

    End Sub
    Private Sub LoadApplicationMenu()

        'objects
        Dim SuperTabItem As DevComponents.DotNetBar.SuperTabItem = Nothing
        Dim AdvTree As DevComponents.AdvTree.AdvTree = Nothing
        Dim [Module] As AdvantageFramework.Security.Database.Views.ModuleView = Nothing
        Dim ModulesList As Generic.List(Of AdvantageFramework.Security.Database.Views.ModuleView) = Nothing
        Dim UserPermissionList As Generic.List(Of AdvantageFramework.Security.Database.Views.UserPermission) = Nothing

        If _Session IsNot Nothing Then

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                ModulesList = AdvantageFramework.Security.Database.Procedures.ModuleView.LoadActiveModulesByApplicationID(SecurityDbContext, _Session.Application).ToList
                UserPermissionList = AdvantageFramework.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndUser(SecurityDbContext, _Session.Application, Session.User.ID).ToList

                For Each [Module] In ModulesList.Where(Function(ModView) ModView.ApplicationID = _Session.Application AndAlso ModView.ParentModuleID Is Nothing AndAlso
                                                                         ModView.IsInactive = False AndAlso ModView.IsMenuItem = True).OrderBy(Function(ModView) ModView.SortOrder)

                    Try

                        SuperTabItem = SuperTabControlHome_Menu.Tabs("SuperTabItemMenu_" & [Module].ModuleDescription.Replace(" and ", " And ").Replace(" ", "").Replace("/", "") & "Tab")

                        AdvTree = SuperTabItem.AttachedControl.Controls.OfType(Of DevComponents.AdvTree.AdvTree).FirstOrDefault()

                    Catch ex As Exception

                    End Try

                    If SuperTabItem IsNot Nothing AndAlso AdvTree IsNot Nothing Then

                        LoadApplicationSubMenu(SecurityDbContext, _Session.Application, [Module], Nothing, AdvTree, ModulesList, UserPermissionList)

                    End If

                Next

            End Using

        End If

    End Sub
    Private Sub LoadApplicationSubMenu(ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, ByVal ApplicationID As Integer,
                                       ByVal ModuleView As AdvantageFramework.Security.Database.Views.ModuleView, ByRef ParentNode As DevComponents.AdvTree.Node,
                                       ByVal AdvTree As DevComponents.AdvTree.AdvTree,
                                       ByVal ModulesList As Generic.List(Of AdvantageFramework.Security.Database.Views.ModuleView),
                                       ByVal UserPermissionList As Generic.List(Of AdvantageFramework.Security.Database.Views.UserPermission))

        'objects
        Dim Node As DevComponents.AdvTree.Node = Nothing
        Dim SubModule As AdvantageFramework.Security.Database.Views.ModuleView = Nothing
        Dim GroupStyle As DevComponents.DotNetBar.ElementStyle = Nothing
        Dim JobCustomDescription As String = ""
        Dim UserPermission As AdvantageFramework.Security.Database.Views.UserPermission = Nothing

        Try

            For Each SubModule In ModulesList.Where(Function(ModView) ModView.ApplicationID = ApplicationID AndAlso ModView.ParentModuleID.GetValueOrDefault(0) = ModuleView.ModuleID AndAlso
                                                                      ModView.IsInactive = False AndAlso ModView.IsMenuItem = True AndAlso ModView.IsDesktopObject = False).OrderBy(Function(ModView) ModView.SortOrder)

                If SubModule.IsCategory Then

                    If ModulesList.Any(Function(ModView) ModView.ApplicationID = ApplicationID AndAlso ModView.ParentModuleID.GetValueOrDefault(0) = SubModule.ModuleID AndAlso ModView.IsMenuItem AndAlso ModView.IsDesktopObject = False) Then

                        GroupStyle = New DevComponents.DotNetBar.ElementStyle

                        GroupStyle.TextColor = Color.Navy
                        GroupStyle.Font = New Font(AdvTree.Font.FontFamily, 10.0F)
                        GroupStyle.Name = "GroupStyle"
                        GroupStyle.Padding = 6

                        AdvTree.Styles.Add(GroupStyle)

                        Node = New DevComponents.AdvTree.Node(SubModule.ModuleDescription, GroupStyle)

                        Node.Name = "Node" & SubModule.ModuleID
                        Node.Image = AdvantageFramework.Security.LoadImageForModule(SubModule)
                        Node.Expanded = True

                        AddHandler Node.NodeClick, AddressOf ModuleNode_NodeClick

                        If ParentNode Is Nothing Then

                            AdvTree.Nodes.Add(Node)

                        Else

                            ParentNode.Nodes.Add(Node)

                        End If

                        LoadApplicationSubMenu(SecurityDbContext, ApplicationID, SubModule, Node, AdvTree, ModulesList, UserPermissionList)

                    End If

                Else

                    Try

                        UserPermission = (From Entity In UserPermissionList
                                          Where Entity.ApplicationID = ApplicationID AndAlso
                                                             Entity.ModuleID = SubModule.ModuleID AndAlso
                                                             Entity.UserID = _Session.User.ID
                                          Select Entity).SingleOrDefault

                    Catch ex As Exception
                        UserPermission = Nothing
                    End Try

                    If AdvantageFramework.Security.DoesUserHaveAccessToModule(UserPermission) Then

                        JobCustomDescription = ""

                        Node = New DevComponents.AdvTree.Node

                        Node.Text = AdvantageFramework.Security.LoadDescriptionForModule(SecurityDbContext, SubModule)

                        Node.Name = "Node" & SubModule.ModuleID
                        Node.Image = AdvantageFramework.Security.LoadImageForModule(SubModule)
                        Node.Tag = SubModule.ModuleID

                        AddHandler Node.NodeMouseDown, AddressOf ModuleNode_NodeMouseDown
                        AddHandler Node.NodeClick, AddressOf ModuleNode_NodeClick

                        If ParentNode Is Nothing Then

                            AdvTree.Nodes.Add(Node)

                        Else

                            ParentNode.Nodes.Add(Node)

                        End If

                    End If

                End If

            Next

        Catch ex As Exception
            Node = Nothing
        End Try

    End Sub
    Private Sub LoadCustomNavigationMenus()

        _LoadingNavigationMenus = True

        LoadNavigationWindow()

        LoadBubbleBar()

        LoadQuickAccessToolbar()

        _LoadingNavigationMenus = False

    End Sub
    Private Sub LoadBubbleBar()

        'objects
        Dim BubbleButton As DevComponents.DotNetBar.BubbleButton = Nothing
        Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing

        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Try

                UserSetting = _UserSettingsList.SingleOrDefault(Function(Entity) Entity.SettingCode = AdvantageFramework.Security.UserSettings.BubbleBarVisible.ToString)

            Catch ex As Exception
                UserSetting = Nothing
            End Try

            If UserSetting IsNot Nothing Then

                ButtonItemMenus_BubbleBar.Checked = CBool(IIf(UserSetting.NumericValue.GetValueOrDefault(1) = 1, True, False))

            End If

            For Each UserMenu In _UserMenusList.Where(Function(Entity) Entity.MenuType = AdvantageFramework.Navigation.Menus.BubbleBar).OrderBy(Function(Entity) Entity.Order).ToList

                If UserMenu.Module IsNot Nothing Then

                    If UserMenu.Module.IsInactive = False Then

                        If AdvantageFramework.Security.DoesUserHaveAccessToModule(SecurityDbContext, _Session.Application, UserMenu.ModuleID, _Session.User.ID) Then

                            BubbleButton = New DevComponents.DotNetBar.BubbleButton

                            BubbleButton.Name = "BubbleButton" & UserMenu.ModuleID
                            BubbleButton.Image = AdvantageFramework.Security.LoadImageForModule(UserMenu.Module)
                            BubbleButton.TooltipText = AdvantageFramework.Security.LoadDescriptionForModule(SecurityDbContext, UserMenu.Module)
                            BubbleButton.Tag = UserMenu.ID

                            AddHandler BubbleButton.Click, AddressOf BubbleButton_Click

                            BubbleBarTabBubbleBarMenu_Tab.Buttons.Add(BubbleButton)

                        Else

                            AdvantageFramework.Security.Database.Procedures.UserMenu.Delete(SecurityDbContext, UserMenu)

                        End If

                    Else

                        AdvantageFramework.Security.Database.Procedures.UserMenu.Delete(SecurityDbContext, UserMenu)

                    End If

                Else

                    AdvantageFramework.Security.Database.Procedures.UserMenu.Delete(SecurityDbContext, UserMenu)

                End If

            Next

        End Using

    End Sub
    Private Sub LoadNavigationWindow()

        'objects
        Dim SideBarPanelItem As DevComponents.DotNetBar.SideBarPanelItem = Nothing
        Dim ButtonItem As DevComponents.DotNetBar.ButtonItem = Nothing
        Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing
        Dim UserMenuTab As AdvantageFramework.Security.Database.Entities.UserMenuTab = Nothing

        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Try

                UserSetting = _UserSettingsList.SingleOrDefault(Function(Entity) Entity.SettingCode = AdvantageFramework.Security.UserSettings.NavigationWindowVisible.ToString)

            Catch ex As Exception
                UserSetting = Nothing
            End Try

            If UserSetting IsNot Nothing Then

                AdvantageFramework.WinForm.Presentation.Controls.SetCheckedOnButtonItem(ButtonItemMenus_Navigation, CBool(IIf(UserSetting.NumericValue.GetValueOrDefault(1) = 1, True, False)))

            End If

            Try

                UserSetting = _UserSettingsList.SingleOrDefault(Function(Entity) Entity.SettingCode = AdvantageFramework.Security.UserSettings.MyMenuDefaultTabName.ToString)

            Catch ex As Exception
                UserSetting = Nothing
            End Try

            If UserSetting IsNot Nothing Then

                AdvantageFramework.WinForm.Presentation.Controls.SetTextOnSideBarPanelItem(SideBarPanelItemNavigation_DefaultPanel, UserSetting.StringValue)
                AdvantageFramework.WinForm.Presentation.Controls.SetTextOnButtonItem(ButtonItemAddToNavigationWindow_MyMenu, UserSetting.StringValue)

            End If

            For Each UserMenuTab In _UserMenuTabsList.OrderBy(Function(MenuTab) MenuTab.Order).ToList

                SideBarPanelItem = New DevComponents.DotNetBar.SideBarPanelItem

                SideBarPanelItem.FontBold = True
                SideBarPanelItem.Name = "SideBarPanelItem" & SideBarNavigation_Navigation.Panels.Count
                SideBarPanelItem.Text = UserMenuTab.Name
                SideBarPanelItem.Tag = UserMenuTab.ID

                If UserMenuTab.HasSmallIcons Then

                    SideBarPanelItem.ItemImageSize = DevComponents.DotNetBar.eBarImageSize.Default

                Else

                    SideBarPanelItem.ItemImageSize = DevComponents.DotNetBar.eBarImageSize.Medium

                End If

                AddHandler SideBarPanelItem.MouseDown, AddressOf SideBarPanel_MouseDown
                AddHandler SideBarPanelItem.SubItemsChanged, AddressOf SideBarPanelItem_SubItemsChanged

                SideBarNavigation_Navigation.Panels.Add(SideBarPanelItem)

                For Each UserMenu In _UserMenusList.Where(Function(Entity) Entity.UserMenuTabID IsNot Nothing AndAlso Entity.UserMenuTabID = UserMenuTab.ID).OrderBy(Function(Entity) Entity.Order).ToList()

                    If UserMenu.Module IsNot Nothing Then

                        If UserMenu.Module.IsInactive = False Then

                            If AdvantageFramework.Security.DoesUserHaveAccessToModule(SecurityDbContext, _Session.Application, UserMenu.ModuleID, _Session.User.ID) Then

                                ButtonItem = New DevComponents.DotNetBar.ButtonItem

                                ButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
                                ButtonItem.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
                                ButtonItem.Text = AdvantageFramework.Security.LoadDescriptionForModule(SecurityDbContext, UserMenu.Module)
                                ButtonItem.Name = "NWButtonItem" & UserMenuTab.Name & UserMenu.ModuleID
                                ButtonItem.Image = AdvantageFramework.Security.LoadImageForModule(UserMenu.Module)
                                ButtonItem.Tag = UserMenu.ID

                                AddHandler ButtonItem.MouseDown, AddressOf NWButtonItem_MouseDown
                                AddHandler ButtonItem.Click, AddressOf NWButtonItem_Click

                                SideBarPanelItem.SubItems.Add(ButtonItem)

                            Else

                                AdvantageFramework.Security.Database.Procedures.UserMenu.Delete(SecurityDbContext, UserMenu)

                            End If

                        Else

                            AdvantageFramework.Security.Database.Procedures.UserMenu.Delete(SecurityDbContext, UserMenu)

                        End If

                    Else

                        AdvantageFramework.Security.Database.Procedures.UserMenu.Delete(SecurityDbContext, UserMenu)

                    End If

                Next

            Next

            For Each UserMenu In _UserMenusList.Where(Function(Entity) Entity.UserMenuTabID IsNot Nothing AndAlso Entity.UserMenuTabID = 0).OrderBy(Function(Entity) Entity.Order).ToList()

                If UserMenu.Module IsNot Nothing Then

                    If UserMenu.Module.IsInactive = False Then

                        If AdvantageFramework.Security.DoesUserHaveAccessToModule(SecurityDbContext, _Session.Application, UserMenu.ModuleID, _Session.User.ID) Then

                            ButtonItem = New DevComponents.DotNetBar.ButtonItem

                            ButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
                            ButtonItem.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
                            ButtonItem.Text = AdvantageFramework.Security.LoadDescriptionForModule(SecurityDbContext, UserMenu.Module)
                            ButtonItem.Name = "NWButtonItemMyMenu" & UserMenu.ModuleID
                            ButtonItem.Image = AdvantageFramework.Security.LoadImageForModule(UserMenu.Module)
                            ButtonItem.Tag = UserMenu.ID

                            AddHandler ButtonItem.MouseDown, AddressOf NWButtonItem_MouseDown
                            AddHandler ButtonItem.Click, AddressOf NWButtonItem_Click

                            SideBarPanelItemNavigation_DefaultPanel.SubItems.Add(ButtonItem)

                        Else

                            AdvantageFramework.Security.Database.Procedures.UserMenu.Delete(SecurityDbContext, UserMenu)

                        End If

                    Else

                        AdvantageFramework.Security.Database.Procedures.UserMenu.Delete(SecurityDbContext, UserMenu)

                    End If

                Else

                    AdvantageFramework.Security.Database.Procedures.UserMenu.Delete(SecurityDbContext, UserMenu)

                End If

            Next

        End Using

    End Sub
    Private Sub LoadQuickAccessToolbar()

        'objects
        Dim ButtonItem As DevComponents.DotNetBar.ButtonItem = Nothing
        Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing

        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Try

                UserSetting = _UserSettingsList.SingleOrDefault(Function(Entity) Entity.SettingCode = AdvantageFramework.Security.UserSettings.QuickAccessToolbarVisible.ToString)

            Catch ex As Exception
                UserSetting = Nothing
            End Try

            If UserSetting IsNot Nothing Then

                ButtonItemMenus_QuickAccess.Checked = CBool(IIf(UserSetting.NumericValue.GetValueOrDefault(1) = 1, True, False))

            End If

            For Each UserMenu In _UserMenusList.Where(Function(Entity) Entity.MenuType = AdvantageFramework.Navigation.Menus.QuickAccessToolbar).OrderBy(Function(Entity) Entity.Order).ToList

                If UserMenu.Module IsNot Nothing Then

                    If UserMenu.Module.IsInactive = False Then

                        If UserMenu.Module.ApplicationModules.Any(Function(AppMod) AppMod.ApplicationID = _Session.Application) Then

                            If AdvantageFramework.Security.DoesUserHaveAccessToModule(SecurityDbContext, _Session.Application, UserMenu.ModuleID, _Session.User.ID) Then

                                ButtonItem = New DevComponents.DotNetBar.ButtonItem

                                ButtonItem.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.Default
                                ButtonItem.Name = "QATButtonItem" & UserMenu.ModuleID
                                ButtonItem.Image = AdvantageFramework.Security.LoadImageForModule(UserMenu.Module)
                                ButtonItem.ImageFixedSize = New System.Drawing.Size(16, 16)
                                ButtonItem.FixedSize = New System.Drawing.Size(20, 20)
                                ButtonItem.Tag = UserMenu.ID
                                ButtonItem.Tooltip = AdvantageFramework.Security.LoadDescriptionForModule(SecurityDbContext, UserMenu.Module)
                                ButtonItem.Visible = ButtonItemMenus_QuickAccess.Checked

                                AddHandler ButtonItem.MouseDown, AddressOf QATButtonItem_MouseDown
                                AddHandler ButtonItem.Click, AddressOf QATButtonItem_Click

                                RibbonControlForm_MainRibbon.QuickToolbarItems.Add(ButtonItem)

                            Else

                                AdvantageFramework.Security.Database.Procedures.UserMenu.Delete(SecurityDbContext, UserMenu)

                            End If

                        End If

                    Else

                        AdvantageFramework.Security.Database.Procedures.UserMenu.Delete(SecurityDbContext, UserMenu)

                    End If

                Else

                    AdvantageFramework.Security.Database.Procedures.UserMenu.Delete(SecurityDbContext, UserMenu)

                End If

            Next

        End Using

    End Sub
    Private Sub LoadNavigationMenuState()

        'objects
        Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing
        Dim MenuStateDetails() As String = Nothing
        Dim Location As System.Drawing.Point = Nothing
        Dim Size As System.Drawing.Size = Nothing
        Dim DockSide As DevComponents.DotNetBar.eDockSide = Nothing
        Dim AutoHide As Boolean = False

        Try

            UserSetting = _UserSettingsList.SingleOrDefault(Function(Entity) Entity.SettingCode = AdvantageFramework.Security.UserSettings.MyMenuState.ToString)

        Catch ex As Exception
            UserSetting = Nothing
        End Try

        If UserSetting IsNot Nothing AndAlso String.IsNullOrWhiteSpace(UserSetting.StringValue) = False Then

            MenuStateDetails = UserSetting.StringValue.Split(";")

            If MenuStateDetails IsNot Nothing AndAlso MenuStateDetails.Count > 0 Then

                Location = New System.Drawing.Point
                Size = New System.Drawing.Size

                For Each MenuStateDetail In MenuStateDetails

                    Try

                        If MenuStateDetail.StartsWith("Dock=") Then

                            DockSide = MenuStateDetail.Replace("Dock=", "")

                        ElseIf MenuStateDetail.StartsWith("AutoHide=") Then

                            AutoHide = MenuStateDetail.Replace("AutoHide=", "")

                        ElseIf MenuStateDetail.StartsWith("X=") Then

                            Location.X = CInt(MenuStateDetail.Replace("X=", ""))

                        ElseIf MenuStateDetail.StartsWith("Y=") Then

                            Location.Y = CInt(MenuStateDetail.Replace("Y=", ""))

                        ElseIf MenuStateDetail.StartsWith("Width=") Then

                            Size.Width = MenuStateDetail.Replace("Width=", "")

                        ElseIf MenuStateDetail.StartsWith("Height=") Then

                            Size.Height = MenuStateDetail.Replace("Height=", "")

                        End If

                    Catch ex As Exception

                    End Try

                Next

                If DockSide = DevComponents.DotNetBar.eDockSide.None AndAlso AutoHide = False Then

                    BarForm_Navigation.DockSide = DevComponents.DotNetBar.eDockSide.None

                    BarForm_Navigation.DockedSite.Location = Location

                    If Size.Width <> 0 AndAlso Size.Height <> 0 Then

                        BarForm_Navigation.Size = Size
                        BarForm_Navigation.DockedSite.Size = Size
                        DockContainerItemNavigation_Navigation.Size = New System.Drawing.Size(Size.Width - 6, Size.Height - 27)
                        PanelDockContainerNavigation_Navigation.Size = New System.Drawing.Size(Size.Width - 10, Size.Height - 31)

                    End If

                Else

                    BarForm_Navigation.DockSide = DockSide
                    BarForm_Navigation.AutoHide = AutoHide

                    If AutoHide Then

                        BarForm_Navigation.Hide()

                    End If

                    If Size.Width <> 0 Then

                        DockContainerItemNavigation_Navigation.Width = Size.Width

                    End If

                End If

                BarForm_Navigation.Visible = ButtonItemMenus_Navigation.Checked
                DockContainerItemNavigation_Navigation.Visible = ButtonItemMenus_Navigation.Checked
                PanelDockContainerNavigation_Navigation.Visible = ButtonItemMenus_Navigation.Checked
                SideBarNavigation_Navigation.Visible = ButtonItemMenus_Navigation.Checked

                BarForm_Navigation.DockedSite.Update()
                PanelDockContainerNavigation_Navigation.Update()
                BarForm_Navigation.Update()

                BarForm_Navigation.DockedSite.Refresh()
                PanelDockContainerNavigation_Navigation.Refresh()
                DockContainerItemNavigation_Navigation.Refresh()
                BarForm_Navigation.Refresh()

                Me.Update()
                Me.Refresh()

            End If

        End If

    End Sub
    Private Sub SaveNavigationMenuState()

        'objects
        Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing

        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Try

                UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, _Session.User.ID, AdvantageFramework.Security.UserSettings.MyMenuState.ToString)

            Catch ex As Exception
                UserSetting = Nothing
            End Try

            If UserSetting IsNot Nothing Then

                UserSetting.StringValue = String.Format(AdvantageFramework.Security._MyMenuStateDetails,
                                                        IIf(BarForm_Navigation.AutoHide, CInt(BarForm_Navigation.AutoHideSide), CInt(BarForm_Navigation.DockSide)),
                                                        BarForm_Navigation.AutoHide,
                                                        BarForm_Navigation.DockedSite.Location.X,
                                                        BarForm_Navigation.DockedSite.Location.Y,
                                                        DockContainerItemNavigation_Navigation.Size.Width,
                                                        DockContainerItemNavigation_Navigation.Size.Height)

                AdvantageFramework.Security.Database.Procedures.UserSetting.Update(SecurityDbContext, UserSetting)

            Else

                UserSetting = New AdvantageFramework.Security.Database.Entities.UserSetting

                UserSetting.DbContext = SecurityDbContext
                UserSetting.UserID = _Session.User.ID
                UserSetting.SettingCode = AdvantageFramework.Security.UserSettings.MyMenuState.ToString

                UserSetting.StringValue = String.Format(AdvantageFramework.Security._MyMenuStateDetails, CInt(BarForm_Navigation.DockSide), BarForm_Navigation.AutoHide,
                                                        IIf(BarForm_Navigation.DockSide = DevComponents.DotNetBar.eDockSide.None, "0", PanelDockContainerNavigation_Navigation.Location.X),
                                                        IIf(BarForm_Navigation.DockSide = DevComponents.DotNetBar.eDockSide.None, "0", PanelDockContainerNavigation_Navigation.Location.Y),
                                                        IIf(BarForm_Navigation.DockSide = DevComponents.DotNetBar.eDockSide.None, "0", PanelDockContainerNavigation_Navigation.Size.Width),
                                                        IIf(BarForm_Navigation.DockSide = DevComponents.DotNetBar.eDockSide.None, "0", PanelDockContainerNavigation_Navigation.Size.Height))

                AdvantageFramework.Security.Database.Procedures.UserSetting.Insert(SecurityDbContext, UserSetting)

            End If

        End Using

    End Sub
    Private Sub LoadLegacyAdvantage()

        'objects
        Dim FilePathWithCommandLine As String = ""
        Dim Loaded As Boolean = False
        Dim ReadyToCheckMenuHWND As Boolean = False
        Dim MenuHWND As Integer = 0
        Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
        Dim SqlConntection As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing

        Try

            If Debugger.IsAttached Then

                Loaded = True

                'FilePathWithCommandLine = "I:\versions\v6.5x\exes"

                'FilePathWithCommandLine &= "\advantage.exe -x -s" & _Session.ServerName

                'My.Computer.FileSystem.CurrentDirectory = "I:\versions\v6.5x\exes"

            Else

                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                    Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.NEW_LICENSE_KEY.ToString)

                End Using

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Try

                        MenuHWND = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT CAST(SESSION_ID AS int) " &
                                                                                             "FROM dbo.LAME_SESSION " &
                                                                                             "WHERE SEC_USER_ID = {0} AND " &
                                                                                                   "SEC_APPLICATION_ID = {1} AND " &
                                                                                                   "CLIENT_NAME = '{2}'", _Session.User.ID, CInt(_Session.Application), My.Computer.Name)).FirstOrDefault

                    Catch ex As Exception
                        MenuHWND = 0
                    End Try

                    If MenuHWND <> 0 Then

                        Try

                            DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.LAME_SESSION " &
                                                                            "WHERE SEC_USER_ID = {0} AND " &
                                                                                  "SEC_APPLICATION_ID = {1} AND " &
                                                                                  "CLIENT_NAME = '{2}'", _Session.User.ID, CInt(_Session.Application), My.Computer.Name))

                        Catch ex As Exception

                        End Try

                    End If

                End Using

                FilePathWithCommandLine = My.Computer.FileSystem.GetDirectoryInfo(My.Application.Info.DirectoryPath).Parent.FullName

                My.Computer.FileSystem.CurrentDirectory = My.Computer.FileSystem.GetDirectoryInfo(My.Application.Info.DirectoryPath).Parent.FullName

                'If _Session.UseWindowsAuthentication Then

                '    FilePathWithCommandLine &= "\advantage.exe -x -s" & _Session.ServerName

                '    FilePathWithCommandLine &= " -d" & _Session.DatabaseName

                '    FilePathWithCommandLine &= " -n"

                'Else

                SqlConntection = New System.Data.SqlClient.SqlConnectionStringBuilder(_Session.ConnectionString)

                FilePathWithCommandLine &= "\advantage.exe -x -s" & _Session.ServerName

                FilePathWithCommandLine &= " -d" & _Session.DatabaseName
                'This is the username for the connection
                FilePathWithCommandLine &= " -u" & SqlConntection.UserID
                'This is the password for the connection
                FilePathWithCommandLine &= " -p" & SqlConntection.Password
                'User id from SEC_USER table
                FilePathWithCommandLine &= " -i" & _Session.User.ID

                'End If

                _LegacyAdvantageProcessID = Shell(FilePathWithCommandLine, AppWinStyle.NormalNoFocus, False)

                If _LegacyAdvantageProcessID <> 0 Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        DbContext.Database.Connection.Open()

                        Do While Loaded = False

                            'If _LegacyLoadTimeExpired Then

                            '    _Session.SetRegisterSecuritySessionMessage("Failed to load advantage properly!")
                            '    Exit Do

                            'Else

                            System.Threading.Thread.Sleep(10)

                            Try

                                If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) " &
                                                                                         "FROM dbo.LAME_SESSION " &
                                                                                         "WHERE SEC_USER_ID = {0} AND " &
                                                                                               "SEC_APPLICATION_ID = {1}", _Session.User.ID, CInt(_Session.Application))).FirstOrDefault > 0 Then

                                    ReadyToCheckMenuHWND = True

                                End If

                            Catch ex As Exception
                                ReadyToCheckMenuHWND = False
                            End Try

                            If ReadyToCheckMenuHWND Then

                                Try

                                    _Session.MenuHWND = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT CAST(SESSION_ID AS int) " &
                                                                                                              "FROM dbo.LAME_SESSION " &
                                                                                                              "WHERE SEC_USER_ID = {0} AND " &
                                                                                                                    "SEC_APPLICATION_ID = {1} AND " &
                                                                                                                    "CLIENT_NAME = '{2}'", _Session.User.ID, CInt(_Session.Application), My.Computer.Name)).FirstOrDefault

                                Catch ex As Exception
                                    _Session.MenuHWND = 0
                                End Try

                            End If

                            'End If

                            If ReadyToCheckMenuHWND Then

                                If _Session.MenuHWND <> 0 Then

                                    If Setting Is Nothing OrElse Setting.Value = 0 Then

                                        Loaded = _Session.RegisterSecuritySession()

                                    Else

                                        Loaded = True

                                    End If

                                Else

                                    _Session.SetRegisterSecuritySessionMessage("Session not found for this user\application\computer.")
                                    Loaded = False

                                End If

                                Exit Do

                            End If

                        Loop

                    End Using

                Else

                    Loaded = True

                End If

            End If

        Catch ex As Exception
            Loaded = False
        End Try

    End Sub
    Private Sub SaveNavigationMenuSetting()

        'objects
        Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing

        If _Session IsNot Nothing Then

            If _LoadingNavigationMenus = False Then

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Try

                        UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, _Session.User.ID, AdvantageFramework.Security.UserSettings.NavigationWindowVisible.ToString)

                    Catch ex As Exception
                        UserSetting = Nothing
                    End Try

                    If UserSetting IsNot Nothing Then

                        UserSetting.NumericValue = CDec(IIf(ButtonItemMenus_Navigation.Checked, 1, 0))

                        AdvantageFramework.Security.Database.Procedures.UserSetting.Update(SecurityDbContext, UserSetting)

                    Else

                        UserSetting = New AdvantageFramework.Security.Database.Entities.UserSetting

                        UserSetting.DbContext = SecurityDbContext
                        UserSetting.UserID = _Session.User.ID
                        UserSetting.SettingCode = AdvantageFramework.Security.UserSettings.NavigationWindowVisible.ToString

                        UserSetting.NumericValue = CDec(IIf(ButtonItemMenus_Navigation.Checked, 1, 0))

                        AdvantageFramework.Security.Database.Procedures.UserSetting.Insert(SecurityDbContext, UserSetting)

                    End If

                End Using

            End If

            BarForm_Navigation.Visible = ButtonItemMenus_Navigation.Checked
            DockContainerItemNavigation_Navigation.Visible = ButtonItemMenus_Navigation.Checked

            If ButtonItemMenus_Navigation.Checked = False Then

                BarForm_Navigation.CloseDockTab(DockContainerItemNavigation_Navigation)

            End If

            DockContainerItemNavigation_Navigation.Selected = ButtonItemMenus_Navigation.Checked

            PanelDockContainerNavigation_Navigation.Visible = ButtonItemMenus_Navigation.Checked
            SideBarNavigation_Navigation.Visible = ButtonItemMenus_Navigation.Checked

            BarForm_Navigation.DockedSite.Update()
            PanelDockContainerNavigation_Navigation.Update()
            BarForm_Navigation.Update()

            BarForm_Navigation.DockedSite.Refresh()
            PanelDockContainerNavigation_Navigation.Refresh()
            DockContainerItemNavigation_Navigation.Refresh()
            BarForm_Navigation.Refresh()

            Me.Update()
            Me.Refresh()

            System.Windows.Forms.Application.DoEvents()

        End If

    End Sub
    Private Sub ClearNotificationAlert()

        LabelItemStatusBar_Notification.Visible = False

    End Sub
    Private Sub LoadUserLoadingInformation()

        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Try

                _UserSettingsList = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserID(SecurityDbContext, _Session.User.ID).ToList

            Catch ex As Exception
                _UserSettingsList = Nothing
            End Try

            Try

                _UserMenuTabsList = AdvantageFramework.Security.Database.Procedures.UserMenuTab.LoadByUserID(SecurityDbContext, _Session.User.ID).OrderBy(Function(MenuTab) MenuTab.Order).ToList

            Catch ex As Exception
                _UserMenuTabsList = Nothing
            End Try

            Try

                _UserMenusList = AdvantageFramework.Security.Database.Procedures.UserMenu.LoadByUserID(SecurityDbContext, _Session.User.ID).Include("Module").Include("Module.ModuleInformation").Include("Module.ApplicationModules").OrderBy(Function(Menu) Menu.Order).ToList

            Catch ex As Exception
                _UserMenusList = Nothing
            End Try

        End Using

    End Sub
    Private Sub ClearUserLoadingInformation()

        Try

            _UserSettingsList = Nothing

        Catch ex As Exception
            _UserSettingsList = Nothing
        End Try

        Try

            _UserMenuTabsList = Nothing

        Catch ex As Exception
            _UserMenuTabsList = Nothing
        End Try

        Try

            _UserMenusList = Nothing

        Catch ex As Exception
            _UserMenusList = Nothing
        End Try

    End Sub

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

    Private Sub AdvantageForm_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

        'If Me.MdiChildren.Count = 0 Then

        '    System.Windows.Forms.Application.DoEvents()

        'End If

    End Sub
    Private Sub AdvantageForm_ClearMessageEvent() Handles Me.ClearMessageEvent

        LabelItemStatusBar_Message.Text = ""

        Me.Refresh()

    End Sub
    Private Sub AdvantageForm_CloseProgressBarEvent() Handles Me.CloseProgressBarEvent

        ProgressBarItemStatusBar_ProgressBar.ProgressType = DevComponents.DotNetBar.eProgressItemType.Standard

        ProgressBarItemStatusBar_ProgressBar.TextVisible = False
        ProgressBarItemStatusBar_ProgressBar.Text = ""

        ProgressBarItemStatusBar_ProgressBar.Visible = False

        Me.Refresh()

    End Sub
    Private Sub AdvantageForm_CloseSplashScreenForm() Handles Me.CloseSplashScreenForm

        Try

            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm()

        Catch ex As Exception

        End Try

        _SplashScreenFormClosed = True

    End Sub
    Private Sub AdvantageForm_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        RemoveHandler AdvantageFramework.Navigation.ClearNotificationAlertEvent, AddressOf ClearNotificationAlert
        RemoveHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle

    End Sub
    Private Sub AdvantageForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing
        Dim SplashScreenManager As DevExpress.XtraSplashScreen.SplashScreenManager = Nothing

        AddHandler AdvantageFramework.Navigation.ClearNotificationAlertEvent, AddressOf ClearNotificationAlert
        AddHandler System.Windows.Forms.Application.Idle, AddressOf Application_Idle

        LabelItemStatusBar_Time.Icon = AdvantageFramework.My.Resources.TimeEntryIcon

        DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(GetType(SplashScreen))

        System.Windows.Forms.Application.DoEvents()

        System.Threading.Thread.Sleep(500)

        If _UseSecurityLogin = False Then

            LoadStartUpInformation(My.Application.CommandLineArgs)

        End If

        If Me.IsDisposed = False AndAlso _IsFormClosing = False Then

            If _SplashScreenFormClosed Then

                DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(GetType(SplashScreen))

            End If

            LoadLegacyAdvantage()

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                LabelItemStatusBar_UserName.Text = AdvantageFramework.Security.Database.Procedures.EmployeeView.LoadByEmployeeCode(SecurityDbContext, _Session.User.EmployeeCode).ToString

            End Using

            LabelItemStatusBar_Database.Text = "Database: " & _Session.DatabaseName

            Office2007StartButtonMainRibbon_Home.Enabled = False

            SuperTabControlPanelBillingTab_Billing.PanelColor.Default.Background.Colors = New System.Drawing.Color() {System.Drawing.Color.White}
            SuperTabControlPanelDesktopTab_Desktop.PanelColor.Default.Background.Colors = New System.Drawing.Color() {System.Drawing.Color.White}
            SuperTabControlPanelEmployeeTab_Employee.PanelColor.Default.Background.Colors = New System.Drawing.Color() {System.Drawing.Color.White}
            SuperTabControlPanelFinanceAndAccountingTab_FinanceAndAccounting.PanelColor.Default.Background.Colors = New System.Drawing.Color() {System.Drawing.Color.White}
            SuperTabControlPanelGeneralLedgerTab_GeneralLedger.PanelColor.Default.Background.Colors = New System.Drawing.Color() {System.Drawing.Color.White}
            SuperTabControlPanelHelpCustomerServiceTab_HelpCustomerService.PanelColor.Default.Background.Colors = New System.Drawing.Color() {System.Drawing.Color.White}
            SuperTabControlPanelMaintenanceTab_Maintenance.PanelColor.Default.Background.Colors = New System.Drawing.Color() {System.Drawing.Color.White}
            SuperTabControlPanelMediaTab_Media.PanelColor.Default.Background.Colors = New System.Drawing.Color() {System.Drawing.Color.White}
            SuperTabControlPanelProjectManagementTab_ProjectManagement.PanelColor.Default.Background.Colors = New System.Drawing.Color() {System.Drawing.Color.White}
            SuperTabControlPanelSecurityTab_Security.PanelColor.Default.Background.Colors = New System.Drawing.Color() {System.Drawing.Color.White}

            LoadApplicationMenu()

            LoadUserLoadingInformation()

            Try

                UserSetting = _UserSettingsList.SingleOrDefault(Function(Entity) Entity.SettingCode = AdvantageFramework.Security.UserSettings.NewAdvantageApplicationsAlert.ToString)

            Catch ex As Exception
                UserSetting = Nothing
            End Try

            If UserSetting IsNot Nothing Then

                If UserSetting.NumericValue.GetValueOrDefault(0) = 1 Then

                    LabelItemStatusBar_Notification.Visible = True

                Else

                    LabelItemStatusBar_Notification.Visible = False

                End If

            Else

                LabelItemStatusBar_Notification.Visible = False

            End If

            System.Windows.Forms.Application.DoEvents()

        End If

    End Sub
    Private Sub AdvantageForm_RunDatabaseScriptCheckEvent() Handles Me.RunDatabaseScriptCheckEvent

        _DatabaseScriptCheckBackgroundWorker = New System.ComponentModel.BackgroundWorker

        _DatabaseScriptCheckBackgroundWorker.RunWorkerAsync()

    End Sub
    Private Sub AdvantageForm_SetMessageEvent(ByVal Message As String) Handles Me.SetMessageEvent

        LabelItemStatusBar_Message.Text = Message

        Me.Refresh()

    End Sub
    Private Sub AdvantageForm_SetProgressBarValueEvent(ByVal CurrentValue As Integer) Handles Me.SetProgressBarValueEvent

        ProgressBarItemStatusBar_ProgressBar.Value = CurrentValue

        Me.Refresh()

    End Sub
    Private Sub AdvantageForm_SetupProgressBarEvent(ByVal MinimumValue As Integer, ByVal MaximumValue As Integer, ByVal StartValue As Integer) Handles Me.SetupProgressBarEvent

        ProgressBarItemStatusBar_ProgressBar.ProgressType = DevComponents.DotNetBar.eProgressItemType.Standard

        ProgressBarItemStatusBar_ProgressBar.Minimum = MinimumValue
        ProgressBarItemStatusBar_ProgressBar.Maximum = MaximumValue
        ProgressBarItemStatusBar_ProgressBar.Value = StartValue

        ProgressBarItemStatusBar_ProgressBar.Visible = True

        Me.Refresh()

    End Sub
    Private Sub AdvantageForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        'objects
        Dim AdvTree As DevComponents.AdvTree.AdvTree = Nothing
        Dim SideBarPanelItem As DevComponents.DotNetBar.SideBarPanelItem = Nothing
        Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing

        If Me.IsDisposed = False AndAlso _IsFormClosing = False Then

            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm()

            System.Windows.Forms.Application.DoEvents()

            If _Session.RegisterSecuritySessionMessage = "" Then

                LoadCustomNavigationMenus()

                Office2007StartButtonMainRibbon_Home.Enabled = True

                For Each SuperTabItem In SuperTabControlHome_Menu.Tabs.OfType(Of DevComponents.DotNetBar.SuperTabItem)().ToList

                    Try

                        SuperTabItem.AttachedControl.Hide()

                    Catch ex As Exception

                    End Try

                    Try

                        AdvTree = SuperTabItem.AttachedControl.Controls.OfType(Of DevComponents.AdvTree.AdvTree).FirstOrDefault()

                    Catch ex As Exception
                        AdvTree = Nothing
                    End Try

                    If AdvTree IsNot Nothing Then

                        For Each Node In AdvTree.Nodes.OfType(Of DevComponents.AdvTree.Node)().ToList

                            If Node.Tag Is Nothing Then

                                Node.Expanded = False

                                If Node.Nodes.Count = 0 Then

                                    AdvTree.Nodes.Remove(Node)

                                End If

                            End If

                        Next

                        If AdvTree.Nodes.Count = 0 Then

                            SuperTabControlHome_Menu.Tabs.Remove(SuperTabItem)

                        End If

                    End If

                Next

                SuperTabControlHome_Menu.SelectedTab = Nothing

                If SideBarPanelItemNavigation_DefaultPanel.SubItems.Count = 0 AndAlso SideBarNavigation_Navigation.Panels.Count = 1 Then

                    Office2007StartButtonMainRibbon_Home.Expanded = True

                End If

                LoadNavigationMenuState()

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    For Each UserMenuTab In AdvantageFramework.Security.Database.Procedures.UserMenuTab.LoadByUserID(SecurityDbContext, _Session.User.ID).OrderBy(Function(MenuTab) MenuTab.Order).ToList

                        If UserMenuTab.HasSmallIcons Then

                            For Each SideBarPanelItem In SideBarNavigation_Navigation.Panels.OfType(Of DevComponents.DotNetBar.SideBarPanelItem)()

                                If SideBarPanelItem.Text = UserMenuTab.Name Then

                                    SideBarPanelItem.ItemImageSize = DevComponents.DotNetBar.eBarImageSize.Default
                                    SideBarPanelItem.Refresh()

                                End If

                            Next

                        End If

                    Next

                    Try

                        UserSetting = _UserSettingsList.SingleOrDefault(Function(Entity) Entity.SettingCode = AdvantageFramework.Security.UserSettings.MyMenuDefaultTabSmallIcons.ToString)

                    Catch ex As Exception
                        UserSetting = Nothing
                    End Try

                    If UserSetting IsNot Nothing Then

                        If UserSetting.StringValue = "Y" Then

                            SideBarPanelItemNavigation_DefaultPanel.ItemImageSize = DevComponents.DotNetBar.eBarImageSize.Default
                            SideBarPanelItemNavigation_DefaultPanel.Refresh()

                        End If

                    End If

                End Using

                WarningBoxForm_LicenseKeyNotification.Visible = AdvantageFramework.Security.LicenseKey.CheckToNotifyUserOfLicenseKey(Me.Session, WarningBoxForm_LicenseKeyNotification.Text)

                ClearUserLoadingInformation()

            Else

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Try

                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.LAME_SESSION " &
                                                                        "WHERE SEC_USER_ID = {0}", _Session.User.ID))

                    Catch ex As Exception

                    End Try

                End Using

                AdvantageFramework.WinForm.MessageBox.Show(_Session.RegisterSecuritySessionMessage)

                System.Windows.Forms.Application.Exit()

            End If

        End If

    End Sub
    Private Sub AdvantageForm_MdiChildActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MdiChildActivate

        If Me.MdiChildren.Count = 1 AndAlso TypeOf Me.MdiChildren(0) Is AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm AndAlso
                DirectCast(Me.MdiChildren(0), AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm).IsFormClosing Then

            System.Windows.Forms.Application.DoEvents()

        End If

    End Sub
    Private Sub AdvantageForm_SaveSettingsEvent() Handles Me.SaveSettingsEvent

        If _Session IsNot Nothing Then

            SaveNavigationMenuState()

        End If

    End Sub
    Private Sub AdvantageForm_StartProgressBarMarqueeEvent(ByVal Message As String) Handles Me.StartProgressBarMarqueeEvent

        ProgressBarItemStatusBar_ProgressBar.ProgressType = DevComponents.DotNetBar.eProgressItemType.Marquee

        ProgressBarItemStatusBar_ProgressBar.TextVisible = True
        ProgressBarItemStatusBar_ProgressBar.Text = Message

        ProgressBarItemStatusBar_ProgressBar.Visible = True

        Me.Refresh()

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub Application_Idle(ByVal sender As Object, ByVal e As System.EventArgs)



    End Sub
    Private Sub NWButtonItem_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        'objects
        Dim ModuleID As Integer = 0
        Dim DialogResult As System.Windows.Forms.DialogResult = System.Windows.Forms.DialogResult.None

        Try

            ModuleID = CInt(AdvantageFramework.StringUtilities.RemoveAllNonNumeric(DirectCast(sender, DevComponents.DotNetBar.ButtonItem).Name))

        Catch ex As Exception
            ModuleID = 0
        End Try

        If ModuleID <> 0 Then

            'System.Windows.Forms.Application.DoEvents()

            DialogResult = OpenModule(ModuleID)

            'System.Windows.Forms.Application.DoEvents()

        End If

    End Sub
    Private Sub QATButtonItem_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        'objects
        Dim ModuleID As Integer = 0
        Dim DialogResult As System.Windows.Forms.DialogResult = System.Windows.Forms.DialogResult.None

        Try

            ModuleID = CInt(AdvantageFramework.StringUtilities.RemoveAllNonNumeric(DirectCast(sender, DevComponents.DotNetBar.ButtonItem).Name))

        Catch ex As Exception
            ModuleID = 0
        End Try

        If ModuleID <> 0 Then

            'System.Windows.Forms.Application.DoEvents()

            DialogResult = OpenModule(ModuleID)

            'System.Windows.Forms.Application.DoEvents()

        End If

    End Sub
    Private Sub BubbleButton_Click(ByVal sender As Object, ByVal e As DevComponents.DotNetBar.ClickEventArgs)

        'objects
        Dim ModuleID As Integer = 0
        Dim DialogResult As System.Windows.Forms.DialogResult = System.Windows.Forms.DialogResult.None

        If e.Button = Windows.Forms.MouseButtons.Right Then

            ButtonItemMenus_BB.Tag = sender

            ButtonItemMenus_BB.Popup(System.Windows.Forms.Form.MousePosition)

        Else

            Try

                ModuleID = CInt(AdvantageFramework.StringUtilities.RemoveAllNonNumeric(DirectCast(sender, DevComponents.DotNetBar.BubbleButton).Name))

            Catch ex As Exception
                ModuleID = 0
            End Try

            If ModuleID <> 0 Then

                'System.Windows.Forms.Application.DoEvents()

                DialogResult = OpenModule(ModuleID)

                'System.Windows.Forms.Application.DoEvents()

            End If

        End If

    End Sub
    Private Sub ModuleNode_NodeClick(ByVal sender As Object, ByVal e As DevComponents.AdvTree.TreeNodeMouseEventArgs)

        If e.Button = Windows.Forms.MouseButtons.Left Then

            If sender IsNot Nothing AndAlso
                TypeOf sender Is DevComponents.AdvTree.Node Then

                If IsNumeric(DirectCast(sender, DevComponents.AdvTree.Node).Tag) Then

                    Office2007StartButtonMainRibbon_Home.Expanded = False

                    'System.Windows.Forms.Application.DoEvents()

                    OpenModule(CInt(DirectCast(sender, DevComponents.AdvTree.Node).Tag))

                    'System.Windows.Forms.Application.DoEvents()

                Else

                    If DirectCast(sender, DevComponents.AdvTree.Node).Nodes.Count > 0 Then

                        DirectCast(sender, DevComponents.AdvTree.Node).Expanded = Not DirectCast(sender, DevComponents.AdvTree.Node).Expanded

                    End If

                End If

            End If

        End If

    End Sub
    Private Sub ModuleNode_NodeMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        If e.Button = Windows.Forms.MouseButtons.Right Then

            ButtonItemMenus_MenuOptions.Tag = sender

            ButtonItemMenus_MenuOptions.Popup(System.Windows.Forms.Form.MousePosition)

        End If

    End Sub
    Private Sub QATButtonItem_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        If e.Button = Windows.Forms.MouseButtons.Right Then

            ButtonItemMenus_QAT.Tag = sender

            ButtonItemMenus_QAT.Popup(System.Windows.Forms.Form.MousePosition)

        End If

    End Sub
    Private Sub NWButtonItem_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        If e.Button = Windows.Forms.MouseButtons.Right Then

            ButtonItemMenus_NW.Tag = sender

            ButtonItemMenus_NW.Popup(System.Windows.Forms.Form.MousePosition)

        End If

    End Sub
    Private Sub SuperTabItems_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SuperTabItemMenu_BillingTab.Click, SuperTabItemMenu_DesktopTab.Click, SuperTabItemMenu_EmployeeTab.Click,
                                                                                                 SuperTabItemMenu_FinanceAndAccountingTab.Click, SuperTabItemMenu_GeneralLedgerTab.Click,
                                                                                                 SuperTabItemMenu_HelpCustomerServiceTab.Click, SuperTabItemMenu_MaintenanceTab.Click, SuperTabItemMenu_MediaTab.Click,
                                                                                                 SuperTabItemMenu_ProjectManagementTab.Click, SuperTabItemMenu_SecurityTab.Click

        'objects
        Dim AdvTree As DevComponents.AdvTree.AdvTree = Nothing

        If sender IsNot Nothing AndAlso TypeOf sender Is DevComponents.DotNetBar.SuperTabItem Then

            If DirectCast(sender, DevComponents.DotNetBar.SuperTabItem).IsSelected = False Then

                SuperTabControlHome_Menu.SelectedTab = sender

            End If

            If SuperTabControlHome_Menu.SelectedTab IsNot Nothing AndAlso SuperTabControlHome_Menu.SelectedTab.AttachedControl IsNot Nothing Then

                SuperTabControlHome_Menu.SelectedTab.AttachedControl.Focus()

            End If

            Try

                AdvTree = SuperTabControlHome_Menu.SelectedTab.AttachedControl.Controls.OfType(Of DevComponents.AdvTree.AdvTree).FirstOrDefault()

            Catch ex As Exception
                AdvTree = Nothing
            End Try

            If AdvTree IsNot Nothing Then

                AdvTree.Focus()

            End If

        End If

    End Sub
    Private Sub ButtonItemMenuOptions_AddToBubbleBar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemMenuOptions_AddToBubbleBar.Click

        'objects
        Dim BubbleButton As DevComponents.DotNetBar.BubbleButton = Nothing
        Dim Node As DevComponents.AdvTree.Node = Nothing
        Dim Index As Integer = 0
        Dim UserMenu As AdvantageFramework.Security.Database.Entities.UserMenu = Nothing

        If ButtonItemMenus_MenuOptions.Tag IsNot Nothing AndAlso TypeOf ButtonItemMenus_MenuOptions.Tag Is DevComponents.AdvTree.Node Then

            Node = ButtonItemMenus_MenuOptions.Tag

            If BubbleBarTabBubbleBarMenu_Tab.Buttons.OfType(Of DevComponents.DotNetBar.BubbleButton).Any(Function(ButtonItem) ButtonItem.Name = "BubbleButton" & Node.Tag) = False Then

                BubbleButton = New DevComponents.DotNetBar.BubbleButton

                BubbleButton.Name = "BubbleButton" & Node.Tag
                BubbleButton.Image = Node.Image
                BubbleButton.TooltipText = Node.Text

                AddHandler BubbleButton.Click, AddressOf BubbleButton_Click

                Index = BubbleBarTabBubbleBarMenu_Tab.Buttons.Add(BubbleButton)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If AdvantageFramework.Security.Database.Procedures.UserMenu.Insert(SecurityDbContext, _Session.User.ID, Node.Tag,
                                                                                   AdvantageFramework.Navigation.Menus.BubbleBar, Index, Nothing, UserMenu) Then

                        BubbleButton.Tag = UserMenu.ID

                    End If

                End Using

                Me.Refresh()

            End If

        End If

    End Sub
    Private Sub ButtonItemMenuOptions_AddToQuickAccessToolbar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemMenuOptions_AddToQuickAccessToolbar.Click

        'objects
        Dim NewButtonItem As DevComponents.DotNetBar.ButtonItem = Nothing
        Dim Node As DevComponents.AdvTree.Node = Nothing
        Dim Index As Integer = 0
        Dim UserMenu As AdvantageFramework.Security.Database.Entities.UserMenu = Nothing

        If ButtonItemMenus_MenuOptions.Tag IsNot Nothing AndAlso TypeOf ButtonItemMenus_MenuOptions.Tag Is DevComponents.AdvTree.Node Then

            Node = ButtonItemMenus_MenuOptions.Tag

            If RibbonControlForm_MainRibbon.QuickToolbarItems.OfType(Of DevComponents.DotNetBar.ButtonItem).Any(Function(ButtonItem) ButtonItem.Name = "QATButtonItem" & Node.Tag) = False Then

                NewButtonItem = New DevComponents.DotNetBar.ButtonItem

                NewButtonItem.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.Default
                NewButtonItem.Name = "QATButtonItem" & Node.Tag
                NewButtonItem.Image = Node.Image
                NewButtonItem.ImageFixedSize = New System.Drawing.Size(16, 16)
                NewButtonItem.FixedSize = New System.Drawing.Size(20, 20)
                NewButtonItem.Tooltip = Node.Text

                AddHandler NewButtonItem.MouseDown, AddressOf QATButtonItem_MouseDown
                AddHandler NewButtonItem.Click, AddressOf QATButtonItem_Click

                Index = RibbonControlForm_MainRibbon.QuickToolbarItems.Add(NewButtonItem)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If AdvantageFramework.Security.Database.Procedures.UserMenu.Insert(SecurityDbContext, _Session.User.ID, Node.Tag,
                                                                                   AdvantageFramework.Navigation.Menus.QuickAccessToolbar, Index, Nothing, UserMenu) Then

                        NewButtonItem.Tag = UserMenu.ID

                    End If

                End Using

                Me.Refresh()

            End If

        End If

    End Sub
    Private Sub ButtonItemAddToNavigationWindow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemAddToNavigationWindow_MyMenu.Click

        'objects
        Dim NewButtonItem As DevComponents.DotNetBar.ButtonItem = Nothing
        Dim Node As DevComponents.AdvTree.Node = Nothing
        Dim Index As Integer = 0
        Dim SideBarPanelItem As DevComponents.DotNetBar.SideBarPanelItem = Nothing
        Dim UserMenu As AdvantageFramework.Security.Database.Entities.UserMenu = Nothing

        If ButtonItemMenus_MenuOptions.Tag IsNot Nothing AndAlso TypeOf ButtonItemMenus_MenuOptions.Tag Is DevComponents.AdvTree.Node Then

            Try

                SideBarPanelItem = SideBarNavigation_Navigation.Panels(CInt(sender.tag))

            Catch ex As Exception
                SideBarPanelItem = Nothing
            End Try

            If SideBarPanelItem IsNot Nothing Then

                Node = ButtonItemMenus_MenuOptions.Tag

                If SideBarPanelItem.SubItems.OfType(Of DevComponents.DotNetBar.ButtonItem).Any(Function(ButtonItem) ButtonItem.Name = "NWButtonItem" & Node.Tag) = False Then

                    NewButtonItem = New DevComponents.DotNetBar.ButtonItem

                    NewButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
                    NewButtonItem.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
                    NewButtonItem.Text = Node.Text
                    NewButtonItem.Name = "NWButtonItem" & Node.Tag
                    NewButtonItem.Image = Node.Image
                    NewButtonItem.Tag = Node.Tag

                    AddHandler NewButtonItem.MouseDown, AddressOf NWButtonItem_MouseDown
                    AddHandler NewButtonItem.Click, AddressOf NWButtonItem_Click

                    _LoadingSubItems = True

                    Index = SideBarPanelItem.SubItems.Add(NewButtonItem)

                    _LoadingSubItems = False

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        If AdvantageFramework.Security.Database.Procedures.UserMenu.Insert(SecurityDbContext, _Session.User.ID, Node.Tag,
                                                                                       AdvantageFramework.Navigation.Menus.NavigationWindow, Index, SideBarPanelItem.Tag, UserMenu) Then

                            NewButtonItem.Tag = UserMenu.ID

                        End If

                    End Using

                    Me.Refresh()

                End If

            End If

        End If

    End Sub
    Private Sub ButtonItemBB_Remove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemBB_Remove.Click

        'objects
        Dim UserMenu As AdvantageFramework.Security.Database.Entities.UserMenu = Nothing

        If ButtonItemMenus_BB.Tag IsNot Nothing AndAlso TypeOf ButtonItemMenus_BB.Tag Is DevComponents.DotNetBar.BubbleButton Then

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Try

                    UserMenu = AdvantageFramework.Security.Database.Procedures.UserMenu.LoadByUserMenuID(SecurityDbContext,
                                                                                                         DirectCast(ButtonItemMenus_BB.Tag, DevComponents.DotNetBar.BubbleButton).Tag)

                Catch ex As Exception
                    UserMenu = Nothing
                End Try

                BubbleBarTabBubbleBarMenu_Tab.Buttons.Remove(ButtonItemMenus_BB.Tag)

                If UserMenu IsNot Nothing Then

                    AdvantageFramework.Security.Database.Procedures.UserMenu.Delete(SecurityDbContext, UserMenu)

                End If

            End Using

            Me.Refresh()

        End If

    End Sub
    Private Sub ButtonItemQAT_Remove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemQAT_Remove.Click

        'objects
        Dim UserMenu As AdvantageFramework.Security.Database.Entities.UserMenu = Nothing

        If ButtonItemMenus_QAT.Tag IsNot Nothing AndAlso TypeOf ButtonItemMenus_QAT.Tag Is DevComponents.DotNetBar.ButtonItem Then

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Try

                    UserMenu = AdvantageFramework.Security.Database.Procedures.UserMenu.LoadByUserMenuID(SecurityDbContext,
                                                                                                         DirectCast(ButtonItemMenus_QAT.Tag, DevComponents.DotNetBar.ButtonItem).Tag)

                Catch ex As Exception
                    UserMenu = Nothing
                End Try

                RibbonControlForm_MainRibbon.QuickToolbarItems.Remove(ButtonItemMenus_QAT.Tag)

                If UserMenu IsNot Nothing Then

                    AdvantageFramework.Security.Database.Procedures.UserMenu.Delete(SecurityDbContext, UserMenu)

                End If

            End Using

            Me.Refresh()

        End If

    End Sub
    Private Sub ButtonItemNW_Remove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemNW_Remove.Click

        'objects
        Dim UserMenu As AdvantageFramework.Security.Database.Entities.UserMenu = Nothing

        If ButtonItemMenus_NW IsNot Nothing AndAlso TypeOf ButtonItemMenus_NW.Tag Is DevComponents.DotNetBar.ButtonItem Then

            If SideBarNavigation_Navigation.ExpandedPanel IsNot Nothing Then

                If SideBarNavigation_Navigation.ExpandedPanel.SubItems.Contains(ButtonItemMenus_NW.Tag) Then

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Try

                            UserMenu = AdvantageFramework.Security.Database.Procedures.UserMenu.LoadByUserMenuID(SecurityDbContext,
                                                                                                                 DirectCast(ButtonItemMenus_NW.Tag, DevComponents.DotNetBar.ButtonItem).Tag)

                        Catch ex As Exception
                            UserMenu = Nothing
                        End Try

                        SideBarNavigation_Navigation.ExpandedPanel.SubItems.Remove(ButtonItemMenus_NW.Tag)

                        If UserMenu IsNot Nothing Then

                            AdvantageFramework.Security.Database.Procedures.UserMenu.Delete(SecurityDbContext, UserMenu)

                        End If

                    End Using

                    Me.Refresh()

                End If

            End If

        End If

    End Sub
    Private Sub ButtonItemNWTab_MoveDown_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemNWTab_MoveDown.Click

        'objects
        Dim UserMenuTab As AdvantageFramework.Security.Database.Entities.UserMenuTab = Nothing
        Dim SideBarPanelItem As DevComponents.DotNetBar.SideBarPanelItem = Nothing
        Dim PanelIndex As Integer = 0

        If SideBarNavigation_Navigation.ExpandedPanel IsNot Nothing Then

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                SideBarPanelItem = SideBarNavigation_Navigation.ExpandedPanel
                PanelIndex = SideBarNavigation_Navigation.Panels.IndexOf(SideBarPanelItem)

                SideBarNavigation_Navigation.Panels.RemoveAt(PanelIndex)

                If PanelIndex = SideBarNavigation_Navigation.Panels.Count Then

                    SideBarNavigation_Navigation.Panels.Insert(PanelIndex, SideBarPanelItem)

                Else

                    SideBarNavigation_Navigation.Panels.Insert(PanelIndex + 1, SideBarPanelItem)

                End If

                SideBarNavigation_Navigation.ExpandedPanel = SideBarPanelItem

                For Each SideBarPanelItem In SideBarNavigation_Navigation.Panels

                    Try

                        UserMenuTab = AdvantageFramework.Security.Database.Procedures.UserMenuTab.LoadByUserMenuTabID(SecurityDbContext, SideBarPanelItem.Tag)

                    Catch ex As Exception
                        UserMenuTab = Nothing
                    End Try

                    If UserMenuTab IsNot Nothing Then

                        UserMenuTab.Order = SideBarNavigation_Navigation.Panels.IndexOf(SideBarPanelItem)

                        AdvantageFramework.Security.Database.Procedures.UserMenuTab.Update(SecurityDbContext, UserMenuTab)

                    End If

                Next

            End Using

            Me.Refresh()

        End If

    End Sub
    Private Sub ButtonItemNWTab_MoveUp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemNWTab_MoveUp.Click

        'objects
        Dim UserMenuTab As AdvantageFramework.Security.Database.Entities.UserMenuTab = Nothing
        Dim SideBarPanelItem As DevComponents.DotNetBar.SideBarPanelItem = Nothing
        Dim PanelIndex As Integer = 0

        If SideBarNavigation_Navigation.ExpandedPanel IsNot Nothing Then

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                SideBarPanelItem = SideBarNavigation_Navigation.ExpandedPanel
                PanelIndex = SideBarNavigation_Navigation.Panels.IndexOf(SideBarPanelItem)

                SideBarNavigation_Navigation.Panels.RemoveAt(PanelIndex)

                SideBarNavigation_Navigation.Panels.Insert(PanelIndex - 1, SideBarPanelItem)

                SideBarNavigation_Navigation.ExpandedPanel = SideBarPanelItem

                For Each SideBarPanelItem In SideBarNavigation_Navigation.Panels

                    Try

                        UserMenuTab = AdvantageFramework.Security.Database.Procedures.UserMenuTab.LoadByUserMenuTabID(SecurityDbContext, SideBarPanelItem.Tag)

                    Catch ex As Exception
                        UserMenuTab = Nothing
                    End Try

                    If UserMenuTab IsNot Nothing Then

                        UserMenuTab.Order = SideBarNavigation_Navigation.Panels.IndexOf(SideBarPanelItem)

                        AdvantageFramework.Security.Database.Procedures.UserMenuTab.Update(SecurityDbContext, UserMenuTab)

                    End If

                Next

            End Using

            Me.Refresh()

        End If

    End Sub
    Private Sub ButtonItemNWTab_LargeIcons_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemNWTab_LargeIcons.Click

        'objects
        Dim UserMenuTab As AdvantageFramework.Security.Database.Entities.UserMenuTab = Nothing
        Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing

        If SideBarNavigation_Navigation.ExpandedPanel IsNot Nothing Then

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                SideBarNavigation_Navigation.ExpandedPanel.ItemImageSize = DevComponents.DotNetBar.eBarImageSize.Medium

                If SideBarNavigation_Navigation.ExpandedPanel Is SideBarPanelItemNavigation_DefaultPanel Then

                    Try

                        UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, _Session.User.ID, AdvantageFramework.Security.UserSettings.MyMenuDefaultTabSmallIcons.ToString)

                    Catch ex As Exception
                        UserSetting = Nothing
                    End Try

                    If UserSetting IsNot Nothing Then

                        UserSetting.StringValue = "N"

                        AdvantageFramework.Security.Database.Procedures.UserSetting.Update(SecurityDbContext, UserSetting)

                    Else

                        UserSetting = New AdvantageFramework.Security.Database.Entities.UserSetting

                        UserSetting.DbContext = SecurityDbContext
                        UserSetting.UserID = _Session.User.ID
                        UserSetting.SettingCode = AdvantageFramework.Security.UserSettings.MyMenuDefaultTabSmallIcons.ToString

                        UserSetting.StringValue = "N"

                        AdvantageFramework.Security.Database.Procedures.UserSetting.Insert(SecurityDbContext, UserSetting)

                    End If

                Else

                    Try

                        UserMenuTab = AdvantageFramework.Security.Database.Procedures.UserMenuTab.LoadByUserMenuTabID(SecurityDbContext, SideBarNavigation_Navigation.ExpandedPanel.Tag)

                    Catch ex As Exception
                        UserMenuTab = Nothing
                    End Try

                    If UserMenuTab IsNot Nothing Then

                        UserMenuTab.HasSmallIcons = False

                        AdvantageFramework.Security.Database.Procedures.UserMenuTab.Update(SecurityDbContext, UserMenuTab)

                    End If

                End If

            End Using

            Me.Refresh()

        End If

    End Sub
    Private Sub ButtonItemNWTab_SmallIcons_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemNWTab_SmallIcons.Click

        'objects
        Dim UserMenuTab As AdvantageFramework.Security.Database.Entities.UserMenuTab = Nothing
        Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing

        If SideBarNavigation_Navigation.ExpandedPanel IsNot Nothing Then

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                SideBarNavigation_Navigation.ExpandedPanel.ItemImageSize = DevComponents.DotNetBar.eBarImageSize.Default

                If SideBarNavigation_Navigation.ExpandedPanel Is SideBarPanelItemNavigation_DefaultPanel Then

                    Try

                        UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, _Session.User.ID, AdvantageFramework.Security.UserSettings.MyMenuDefaultTabSmallIcons.ToString)

                    Catch ex As Exception
                        UserSetting = Nothing
                    End Try

                    If UserSetting IsNot Nothing Then

                        UserSetting.StringValue = "Y"

                        AdvantageFramework.Security.Database.Procedures.UserSetting.Update(SecurityDbContext, UserSetting)

                    Else

                        UserSetting = New AdvantageFramework.Security.Database.Entities.UserSetting

                        UserSetting.DbContext = SecurityDbContext
                        UserSetting.UserID = _Session.User.ID
                        UserSetting.SettingCode = AdvantageFramework.Security.UserSettings.MyMenuDefaultTabSmallIcons.ToString

                        UserSetting.StringValue = "Y"

                        AdvantageFramework.Security.Database.Procedures.UserSetting.Insert(SecurityDbContext, UserSetting)

                    End If

                Else

                    Try

                        UserMenuTab = AdvantageFramework.Security.Database.Procedures.UserMenuTab.LoadByUserMenuTabID(SecurityDbContext, SideBarNavigation_Navigation.ExpandedPanel.Tag)

                    Catch ex As Exception
                        UserMenuTab = Nothing
                    End Try

                    If UserMenuTab IsNot Nothing Then

                        UserMenuTab.HasSmallIcons = True

                        AdvantageFramework.Security.Database.Procedures.UserMenuTab.Update(SecurityDbContext, UserMenuTab)

                    End If

                End If

            End Using

            Me.Refresh()

        End If

    End Sub
    Private Sub BarForm_Navigation_DockTabClosed(ByVal sender As Object, ByVal e As DevComponents.DotNetBar.DockTabClosingEventArgs) Handles BarForm_Navigation.DockTabClosed

        ButtonItemMenus_Navigation.Checked = False

    End Sub
    Private Sub BarForm_Navigation_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles BarForm_Navigation.MouseDown

        If e.Button = Windows.Forms.MouseButtons.Right Then

            ButtonItemMenus_NWPanel.Popup(System.Windows.Forms.Form.MousePosition)

        End If

    End Sub
    Private Sub SideBarPanelItem_SubItemsChanged(ByVal sender As Object, ByVal e As System.ComponentModel.CollectionChangeEventArgs) Handles SideBarPanelItemNavigation_DefaultPanel.SubItemsChanged

        'objects
        Dim SideBarPanelItem As DevComponents.DotNetBar.SideBarPanelItem = Nothing
        Dim UserMenu As AdvantageFramework.Security.Database.Entities.UserMenu = Nothing

        If _LoadingNavigationMenus = False Then

            If _LoadingSubItems = False AndAlso e.Action = System.ComponentModel.CollectionChangeAction.Add AndAlso
                    TypeOf sender Is DevComponents.DotNetBar.SideBarPanelItem Then

                SideBarPanelItem = sender

                For Each ButtonItem In SideBarPanelItem.SubItems.OfType(Of DevComponents.DotNetBar.ButtonItem)()

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Try

                            UserMenu = AdvantageFramework.Security.Database.Procedures.UserMenu.LoadByUserMenuID(SecurityDbContext, ButtonItem.Tag)

                        Catch ex As Exception
                            UserMenu = Nothing
                        End Try

                        If UserMenu IsNot Nothing Then

                            UserMenu.Order = SideBarPanelItem.SubItems.IndexOf(ButtonItem)

                            If UserMenu.UserMenuTabID <> CInt(SideBarPanelItem.Tag) Then

                                UserMenu.UserMenuTab = Nothing

                            End If

                            UserMenu.UserMenuTabID = SideBarPanelItem.Tag

                            AdvantageFramework.Security.Database.Procedures.UserMenu.Update(SecurityDbContext, UserMenu)

                        End If

                    End Using

                Next

            End If

        End If

    End Sub
    Private Sub SideBarPanel_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles SideBarPanelItemNavigation_DefaultPanel.MouseDown

        If e.Button = Windows.Forms.MouseButtons.Right Then

            If SideBarNavigation_Navigation.ExpandedPanel Is sender Then

                If SideBarNavigation_Navigation.ExpandedPanel Is SideBarPanelItemNavigation_DefaultPanel Then

                    ButtonItemNWTab_Remove.Visible = False
                    ButtonItemNWTab_MoveUp.Visible = False
                    ButtonItemNWTab_MoveDown.Visible = False

                Else

                    ButtonItemNWTab_MoveUp.Visible = True
                    ButtonItemNWTab_MoveDown.Visible = True

                    If SideBarNavigation_Navigation.Panels.IndexOf(SideBarNavigation_Navigation.ExpandedPanel) = 1 AndAlso
                            SideBarNavigation_Navigation.Panels.Count > 2 Then

                        ButtonItemNWTab_MoveUp.Enabled = False
                        ButtonItemNWTab_MoveDown.Enabled = True

                    ElseIf SideBarNavigation_Navigation.Panels.IndexOf(SideBarNavigation_Navigation.ExpandedPanel) = SideBarNavigation_Navigation.Panels.Count - 1 AndAlso
                            SideBarNavigation_Navigation.Panels.Count > 2 Then

                        ButtonItemNWTab_MoveUp.Enabled = True
                        ButtonItemNWTab_MoveDown.Enabled = False

                    ElseIf SideBarNavigation_Navigation.Panels.IndexOf(SideBarNavigation_Navigation.ExpandedPanel) = 1 AndAlso
                            SideBarNavigation_Navigation.Panels.Count = 2 Then

                        ButtonItemNWTab_MoveUp.Enabled = False
                        ButtonItemNWTab_MoveDown.Enabled = False

                    Else

                        ButtonItemNWTab_MoveUp.Enabled = True
                        ButtonItemNWTab_MoveDown.Enabled = True

                    End If

                    ButtonItemNWTab_Remove.Visible = True

                End If

                ButtonItemMenus_NWTab.Popup(System.Windows.Forms.Form.MousePosition)

            End If

        End If

    End Sub
    Private Sub ButtonItemNWPanel_AddTab_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemNWPanel_AddTab.Click

        'objects
        Dim TabName As String = ""
        Dim SideBarPanelItem As DevComponents.DotNetBar.SideBarPanelItem = Nothing
        Dim UserMenuTab As AdvantageFramework.Security.Database.Entities.UserMenuTab = Nothing
        Dim Index As Integer = 0

        If AdvantageFramework.WinForm.Presentation.InputDialog.ShowFormDialog("New Tab", "Enter Tab Name", "", TabName, AdvantageFramework.Security.Database.Entities.UserMenuTab.Properties.Name) = System.Windows.Forms.DialogResult.OK Then

            If TabName <> "" Then

                SideBarPanelItem = New DevComponents.DotNetBar.SideBarPanelItem

                SideBarPanelItem.FontBold = True
                SideBarPanelItem.Name = "SideBarPanelItem" & SideBarNavigation_Navigation.Panels.Count
                SideBarPanelItem.Text = TabName

                AddHandler SideBarPanelItem.MouseDown, AddressOf SideBarPanel_MouseDown
                AddHandler SideBarPanelItem.SubItemsChanged, AddressOf SideBarPanelItem_SubItemsChanged

                Index = SideBarNavigation_Navigation.Panels.Add(SideBarPanelItem)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If AdvantageFramework.Security.Database.Procedures.UserMenuTab.Insert(SecurityDbContext, _Session.User.ID, TabName, Index, True, UserMenuTab) Then

                        SideBarPanelItem.Tag = UserMenuTab.ID

                    End If

                End Using

                Me.Refresh()

            End If

        End If

    End Sub
    Private Sub SideBarNavigation_Navigation_ItemRemoved(ByVal sender As Object, ByVal e As DevComponents.DotNetBar.ItemRemovedEventArgs) Handles SideBarNavigation_Navigation.ItemRemoved

        If _LoadingNavigationMenus = False AndAlso sender IsNot Nothing AndAlso TypeOf sender Is DevComponents.DotNetBar.SideBarPanelItem Then

            If sender IsNot SideBarPanelItemNavigation_DefaultPanel Then

                If ButtonItemMenuOptions_AddToNavigationWindow.SubItems.Contains(DirectCast(sender, DevComponents.DotNetBar.SideBarPanelItem).Name.Replace("SideBarPanelItem", "ButtonItem")) Then

                    Try

                        ButtonItemMenuOptions_AddToNavigationWindow.SubItems.Remove(DirectCast(sender, DevComponents.DotNetBar.SideBarPanelItem).Name.Replace("SideBarPanelItem", "ButtonItem"))

                    Catch ex As Exception

                    End Try

                End If

                For Each ButtonItem In ButtonItemMenuOptions_AddToNavigationWindow.SubItems.OfType(Of DevComponents.DotNetBar.ButtonItem).ToList

                    ButtonItem.Tag = ButtonItemMenuOptions_AddToNavigationWindow.SubItems.IndexOf(ButtonItem)

                Next

            End If

        End If

    End Sub
    Private Sub SideBarNavigation_Navigation_ItemAdded(ByVal sender As Object, ByVal e As System.EventArgs) Handles SideBarNavigation_Navigation.ItemAdded

        'objects
        Dim ButtonItem As DevComponents.DotNetBar.ButtonItem = Nothing

        If sender IsNot Nothing AndAlso TypeOf sender Is DevComponents.DotNetBar.SideBarPanelItem Then

            If sender IsNot SideBarPanelItemNavigation_DefaultPanel Then

                If ButtonItemMenuOptions_AddToNavigationWindow.SubItems.Contains(DirectCast(sender, DevComponents.DotNetBar.SideBarPanelItem).Name.Replace("SideBarPanelItem", "ButtonItem")) = False Then

                    ButtonItem = New DevComponents.DotNetBar.ButtonItem

                    ButtonItem.Text = sender.Text
                    ButtonItem.Name = DirectCast(sender, DevComponents.DotNetBar.SideBarPanelItem).Name.Replace("SideBarPanelItem", "ButtonItem")
                    ButtonItem.Tag = SideBarNavigation_Navigation.Panels.IndexOf(sender)

                    AddHandler ButtonItem.Click, AddressOf ButtonItemAddToNavigationWindow_Click

                    ButtonItemMenuOptions_AddToNavigationWindow.SubItems.Insert(SideBarNavigation_Navigation.Panels.IndexOf(sender), ButtonItem)

                End If

            End If

        End If

    End Sub
    Private Sub ButtonItemNWTab_Remove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemNWTab_Remove.Click

        'objects
        Dim Index As Integer = -1
        Dim UserMenuTab As AdvantageFramework.Security.Database.Entities.UserMenuTab = Nothing

        If SideBarNavigation_Navigation.ExpandedPanel IsNot Nothing Then

            If SideBarNavigation_Navigation.ExpandedPanel IsNot SideBarPanelItemNavigation_DefaultPanel Then

                Index = SideBarNavigation_Navigation.Panels.IndexOf(SideBarNavigation_Navigation.ExpandedPanel)

                For Each ButtonItem In ButtonItemMenuOptions_AddToNavigationWindow.SubItems.OfType(Of DevComponents.DotNetBar.ButtonItem)().ToList

                    If ButtonItem.Text = SideBarNavigation_Navigation.ExpandedPanel.Text Then

                        ButtonItemMenuOptions_AddToNavigationWindow.SubItems.Remove(ButtonItem)
                        Exit For

                    End If

                Next

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Try

                        UserMenuTab = AdvantageFramework.Security.Database.Procedures.UserMenuTab.LoadByUserMenuTabID(SecurityDbContext, SideBarNavigation_Navigation.ExpandedPanel.Tag)

                    Catch ex As Exception
                        UserMenuTab = Nothing
                    End Try

                    If UserMenuTab IsNot Nothing Then

                        If AdvantageFramework.Security.Database.Procedures.UserMenuTab.Delete(SecurityDbContext, UserMenuTab) Then

                            SideBarNavigation_Navigation.Panels.Remove(SideBarNavigation_Navigation.ExpandedPanel)

                        End If

                    End If

                    If Index = SideBarNavigation_Navigation.Panels.Count Then

                        SideBarNavigation_Navigation.ExpandedPanel = SideBarPanelItemNavigation_DefaultPanel

                    Else

                        SideBarNavigation_Navigation.ExpandedPanel = SideBarNavigation_Navigation.Panels(Index)

                    End If

                End Using

                Me.Refresh()

            End If

        End If

    End Sub
    Private Sub ButtonItemNWTab_Rename_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemNWTab_Rename.Click

        'objects
        Dim UserMenuTab As AdvantageFramework.Security.Database.Entities.UserMenuTab = Nothing
        Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing
        Dim TabName As String = ""
        Dim Renamed As Boolean = False
        Dim Index As Integer = -1

        If SideBarNavigation_Navigation.ExpandedPanel IsNot Nothing Then

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If SideBarNavigation_Navigation.ExpandedPanel IsNot SideBarPanelItemNavigation_DefaultPanel Then


                    Try

                        UserMenuTab = AdvantageFramework.Security.Database.Procedures.UserMenuTab.LoadByUserMenuTabID(SecurityDbContext, SideBarNavigation_Navigation.ExpandedPanel.Tag)

                    Catch ex As Exception
                        UserMenuTab = Nothing
                    End Try

                    If UserMenuTab IsNot Nothing Then

                        If AdvantageFramework.WinForm.Presentation.InputDialog.ShowFormDialog("Rename Tab", "Enter Tab Name", "", TabName, AdvantageFramework.Security.Database.Entities.UserMenuTab.Properties.Name) = System.Windows.Forms.DialogResult.OK Then

                            UserMenuTab.Name = TabName

                            If AdvantageFramework.Security.Database.Procedures.UserMenuTab.Update(SecurityDbContext, UserMenuTab) Then

                                Renamed = True

                            End If

                        End If

                    End If

                Else

                    If AdvantageFramework.WinForm.Presentation.InputDialog.ShowFormDialog("Rename Tab", "Enter Tab Name", "", TabName, AdvantageFramework.Security.Database.Entities.UserMenuTab.Properties.Name) = System.Windows.Forms.DialogResult.OK Then

                        Try

                            UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, _Session.User.ID, AdvantageFramework.Security.UserSettings.MyMenuDefaultTabName.ToString)

                        Catch ex As Exception
                            UserSetting = Nothing
                        End Try

                        If UserSetting IsNot Nothing Then

                            UserSetting.StringValue = TabName

                            If AdvantageFramework.Security.Database.Procedures.UserSetting.Update(SecurityDbContext, UserSetting) Then

                                Renamed = True

                            End If

                        Else

                            UserSetting = New AdvantageFramework.Security.Database.Entities.UserSetting

                            UserSetting.DbContext = SecurityDbContext
                            UserSetting.UserID = _Session.User.ID
                            UserSetting.SettingCode = AdvantageFramework.Security.UserSettings.MyMenuDefaultTabName.ToString

                            UserSetting.StringValue = TabName

                            If AdvantageFramework.Security.Database.Procedures.UserSetting.Insert(SecurityDbContext, UserSetting) Then

                                Renamed = True

                            End If

                        End If

                    End If

                End If

                If Renamed Then

                    Index = SideBarNavigation_Navigation.Panels.IndexOf(SideBarNavigation_Navigation.ExpandedPanel)

                    For Each ButtonItem In ButtonItemMenuOptions_AddToNavigationWindow.SubItems.OfType(Of DevComponents.DotNetBar.ButtonItem)().ToList

                        If ButtonItem.Text = SideBarNavigation_Navigation.ExpandedPanel.Text Then

                            SideBarNavigation_Navigation.ExpandedPanel.Text = TabName
                            ButtonItem.Text = TabName

                            Exit For

                        End If

                    Next

                End If

            End Using

            Me.Refresh()

        End If

    End Sub
    Private Sub ButtonItemMenus_Navigation_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemMenus_Navigation.CheckedChanged

        SaveNavigationMenuSetting()

    End Sub
    Private Sub ButtonItemMenus_BubbleBar_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemMenus_BubbleBar.CheckedChanged

        'objects
        Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing

        If _Session IsNot Nothing Then

            If _LoadingNavigationMenus = False Then

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Try

                        UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, _Session.User.ID, AdvantageFramework.Security.UserSettings.BubbleBarVisible.ToString)

                    Catch ex As Exception
                        UserSetting = Nothing
                    End Try

                    If UserSetting IsNot Nothing Then

                        UserSetting.NumericValue = CDec(IIf(ButtonItemMenus_BubbleBar.Checked, 1, 0))

                        AdvantageFramework.Security.Database.Procedures.UserSetting.Update(SecurityDbContext, UserSetting)

                    Else

                        UserSetting = New AdvantageFramework.Security.Database.Entities.UserSetting

                        UserSetting.DbContext = SecurityDbContext
                        UserSetting.UserID = _Session.User.ID
                        UserSetting.SettingCode = AdvantageFramework.Security.UserSettings.BubbleBarVisible.ToString

                        UserSetting.NumericValue = CDec(IIf(ButtonItemMenus_BubbleBar.Checked, 1, 0))

                        AdvantageFramework.Security.Database.Procedures.UserSetting.Insert(SecurityDbContext, UserSetting)

                    End If

                End Using

            End If

            AdvantageFramework.WinForm.Presentation.Controls.SetVisibleOnBubbleBar(BubbleBarForm_BubbleBarMenu, ButtonItemMenus_BubbleBar.Checked)

        End If

    End Sub
    Private Sub ButtonItemMenus_QuickAccess_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemMenus_QuickAccess.CheckedChanged

        'objects
        Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing

        If _Session IsNot Nothing Then

            If _LoadingNavigationMenus = False Then

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Try

                        UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, _Session.User.ID, AdvantageFramework.Security.UserSettings.QuickAccessToolbarVisible.ToString)

                    Catch ex As Exception
                        UserSetting = Nothing
                    End Try

                    If UserSetting IsNot Nothing Then

                        UserSetting.NumericValue = CDec(IIf(ButtonItemMenus_QuickAccess.Checked, 1, 0))

                        AdvantageFramework.Security.Database.Procedures.UserSetting.Update(SecurityDbContext, UserSetting)

                    Else

                        UserSetting = New AdvantageFramework.Security.Database.Entities.UserSetting

                        UserSetting.DbContext = SecurityDbContext
                        UserSetting.UserID = _Session.User.ID
                        UserSetting.SettingCode = AdvantageFramework.Security.UserSettings.QuickAccessToolbarVisible.ToString

                        UserSetting.NumericValue = CDec(IIf(ButtonItemMenus_QuickAccess.Checked, 1, 0))

                        AdvantageFramework.Security.Database.Procedures.UserSetting.Insert(SecurityDbContext, UserSetting)

                    End If

                End Using

            End If

            For Each QuickToolbarItem In RibbonControlForm_MainRibbon.QuickToolbarItems.OfType(Of DevComponents.DotNetBar.BaseItem)().ToList

                If QuickToolbarItem.Name.StartsWith("QAT") Then

                    QuickToolbarItem.Visible = ButtonItemMenus_QuickAccess.Checked

                End If

            Next

            RibbonControlForm_MainRibbon.Refresh()

        End If

    End Sub
    Private Sub LabelItemStatusBar_Notification_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LabelItemStatusBar_Notification.Click

        'objects
        Dim AlertMessage As String = ""

        If AdvantageFramework.Security.LoadNewAdvantageApplicationsAlertSetting(_Session, AlertMessage) Then

            AdvantageFramework.WinForm.Presentation.AlertNotifcationDialog.ShowForm(_Session, System.Windows.Forms.Form.MousePosition, AlertMessage)

        End If

    End Sub
    Private Sub ButtonItemLicenseKeyNotification_DontRemindMeAgain_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemLicenseKeyNotification_DontRemindMeAgain.Click

        'objects
        Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing

        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Try

                UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, _Session.User.ID, AdvantageFramework.Security.UserSettings.RemindUserOfLicenseKeyRenewal.ToString)

            Catch ex As Exception
                UserSetting = Nothing
            End Try

            If UserSetting IsNot Nothing Then

                UserSetting.StringValue = "N"
                UserSetting.DateValue = Nothing

                AdvantageFramework.Security.Database.Procedures.UserSetting.Update(SecurityDbContext, UserSetting)

            Else

                AdvantageFramework.Security.Database.Procedures.UserSetting.Insert(SecurityDbContext, _Session.User.ID, AdvantageFramework.Security.UserSettings.RemindUserOfLicenseKeyRenewal.ToString, "N", Nothing, Nothing, UserSetting)

            End If

        End Using

        WarningBoxForm_LicenseKeyNotification.Visible = False

    End Sub
    Private Sub ButtonItemLicenseKeyNotification_RemindMeAgainTomorrow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemLicenseKeyNotification_RemindMeAgainTomorrow.Click

        'objects
        Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing

        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Try

                UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, _Session.User.ID, AdvantageFramework.Security.UserSettings.RemindUserOfLicenseKeyRenewal.ToString)

            Catch ex As Exception
                UserSetting = Nothing
            End Try

            If UserSetting IsNot Nothing Then

                UserSetting.StringValue = "Y"
                UserSetting.DateValue = Now.AddDays(1)

                AdvantageFramework.Security.Database.Procedures.UserSetting.Update(SecurityDbContext, UserSetting)

            Else

                AdvantageFramework.Security.Database.Procedures.UserSetting.Insert(SecurityDbContext, _Session.User.ID, AdvantageFramework.Security.UserSettings.RemindUserOfLicenseKeyRenewal.ToString, "Y", Nothing, Now.AddDays(1), UserSetting)

            End If

        End Using

        WarningBoxForm_LicenseKeyNotification.Visible = False

    End Sub
    Private Sub WarningBoxForm_LicenseKeyNotification_OptionsClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles WarningBoxForm_LicenseKeyNotification.OptionsClick

        ButtonItemMenus_LicenseKeyNotification.Popup(System.Windows.Forms.Form.MousePosition)

    End Sub
    Private Sub LabelItemStatusBar_Time_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LabelItemStatusBar_Time.Click

        AdvantageFramework.WinForm.Presentation.ClockDialog.ShowForm(System.Windows.Forms.Form.MousePosition)

    End Sub
    Private Sub _DatabaseScriptCheckBackgroundWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles _DatabaseScriptCheckBackgroundWorker.DoWork

        'objects
        Dim ReleaseVersion As String = ""
        Dim ErrorMessage As String = ""
        Dim UnappliedDatabaseChangesList As Generic.List(Of System.IO.FileInfo) = Nothing

        If My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\Scripts") Then

            ReleaseVersion = "v" & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & Format(My.Application.Info.Version.Build, "00")

            UnappliedDatabaseChangesList = New Generic.List(Of System.IO.FileInfo)

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                DbContext.Database.Connection.Open()

                For Each DirectoryInfo In My.Computer.FileSystem.GetDirectoryInfo(My.Application.Info.DirectoryPath & "\Scripts").GetDirectories.ToList

                    If AdvantageFramework.StringUtilities.RemoveAllNonNumeric(DirectoryInfo.Name) >= AdvantageFramework.StringUtilities.RemoveAllNonNumeric(ReleaseVersion) Then

                        AdvantageFramework.Security.LoadDirectoryScripts(_Session, UnappliedDatabaseChangesList, DirectoryInfo, DbContext, DirectoryInfo.Name)

                    End If

                Next

                DbContext.Database.Connection.Close()

            End Using

            If UnappliedDatabaseChangesList.Count > 0 Then

                ErrorMessage = "There are updates missing from your database.  " & vbCrLf &
                               "This may cause errors when using certain features of the system before rectifying the situation.  " & vbCrLf &
                               "Please notify your system adminstrator that the following items are missing and need to be applied: " & vbCrLf & vbCrLf &
                               Join(UnappliedDatabaseChangesList.Select(Function(FileInfo) FileInfo.Name.Replace(".advenc", "").Replace(".sql", "") & "_" & FileInfo.LastWriteTime.ToString("yyyyMMddHHmmss")).ToArray, vbCrLf)

            End If

        End If

        If _Session.IsNielsenSetup AndAlso My.Computer.FileSystem.DirectoryExists(My.Application.Info.DirectoryPath & "\Nielsen Scripts") Then

            ReleaseVersion = "v" & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & Format(My.Application.Info.Version.Build, "00")

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.NielsenConnectionString, _Session.UserCode)

                DbContext.Database.Connection.Open()

                If DbContext.Database.SqlQuery(Of Integer)("SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'DB_UPDATE' ").FirstOrDefault = 1 Then

                    UnappliedDatabaseChangesList = New Generic.List(Of System.IO.FileInfo)

                    For Each DirectoryInfo In My.Computer.FileSystem.GetDirectoryInfo(My.Application.Info.DirectoryPath & "\Nielsen Scripts").GetDirectories.ToList

                        If AdvantageFramework.StringUtilities.RemoveAllNonNumeric(DirectoryInfo.Name) >= AdvantageFramework.StringUtilities.RemoveAllNonNumeric(ReleaseVersion) Then

                            AdvantageFramework.Security.LoadDirectoryScripts(_Session, UnappliedDatabaseChangesList, DirectoryInfo, DbContext, DirectoryInfo.Name)

                        End If

                    Next

                    If UnappliedDatabaseChangesList.Count > 0 Then

                        If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                            ErrorMessage &= vbCrLf & vbCrLf & "Nielsen Updates: " & vbCrLf & vbCrLf &
                                            Join(UnappliedDatabaseChangesList.Select(Function(FileInfo) FileInfo.Name.Replace(".advenc", "").Replace(".sql", "") & "_" & FileInfo.LastWriteTime.ToString("yyyyMMddHHmmss")).ToArray, vbCrLf)

                        Else

                            ErrorMessage = "There are updates missing from your database.  " & vbCrLf &
                                           "This may cause errors when using certain features of the system before rectifying the situation.  " & vbCrLf &
                                           "Please notify your system adminstrator that the following items are missing and need to be applied: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf &
                                           "Nielsen Updates: " & vbCrLf & vbCrLf &
                                           Join(UnappliedDatabaseChangesList.Select(Function(FileInfo) FileInfo.Name.Replace(".advenc", "").Replace(".sql", "") & "_" & FileInfo.LastWriteTime.ToString("yyyyMMddHHmmss")).ToArray, vbCrLf)

                        End If

                    End If

                Else

                    If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                        ErrorMessage &= vbCrLf & vbCrLf & "Nielsen Updates: " & vbCrLf & vbCrLf & "Major Updates needed!"

                    Else

                        ErrorMessage = "There are updates missing from your database.  " & vbCrLf &
                                           "This may cause errors when using certain features of the system before rectifying the situation.  " & vbCrLf &
                                           "Please notify your system adminstrator that the following items are missing and need to be applied: " & vbCrLf & vbCrLf & vbCrLf & vbCrLf &
                                           "Nielsen Updates: " & vbCrLf & vbCrLf & "Major Updates needed!"

                    End If

                End If

                DbContext.Database.Connection.Close()

            End Using

        End If

        e.Result = ErrorMessage

    End Sub
    Private Sub _DatabaseScriptCheckBackgroundWorker_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles _DatabaseScriptCheckBackgroundWorker.RunWorkerCompleted

        If String.IsNullOrEmpty(e.Result) = False Then

            WarningBoxForm_DatabaseWarning.Tag = e.Result
            WarningBoxForm_DatabaseWarning.Visible = True

            LabelItemStatusBar_DatabaseWarning.Tag = e.Result
            LabelItemStatusBar_DatabaseWarning.Visible = True

            BarForm_StatusBar.Refresh()

        End If

    End Sub
    Private Sub LabelItemStatusBar_DatabaseWarning_Click(sender As Object, e As EventArgs) Handles LabelItemStatusBar_DatabaseWarning.Click

        AdvantageFramework.Navigation.ShowMessageBox(LabelItemStatusBar_DatabaseWarning.Tag, AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.OK, "Warning")

    End Sub
    Private Sub WarningBoxForm_DatabaseWarning_OptionsClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles WarningBoxForm_DatabaseWarning.OptionsClick

        ButtonItemMenus_DatabaseWarning.Popup(System.Windows.Forms.Form.MousePosition)

    End Sub
    Private Sub ButtonItemDatabaseWarning_Minimize_Click(sender As Object, e As EventArgs) Handles ButtonItemDatabaseWarning_Minimize.Click

        WarningBoxForm_DatabaseWarning.Visible = False

    End Sub
    Private Sub ButtonItemDatabaseWarning_ViewDetails_Click(sender As Object, e As EventArgs) Handles ButtonItemDatabaseWarning_ViewDetails.Click

        AdvantageFramework.Navigation.ShowMessageBox(LabelItemStatusBar_DatabaseWarning.Tag, AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.OK, "Warning")

    End Sub
    Private Sub Office2007StartButtonMainRibbon_Home_ExpandChange(sender As Object, e As EventArgs) Handles Office2007StartButtonMainRibbon_Home.ExpandChange

        CType(SuperTabControlHome_Menu.Tabs.Item(0), DevComponents.DotNetBar.ButtonItem).Symbol = "58135"
        CType(SuperTabControlHome_Menu.Tabs.Item(0), DevComponents.DotNetBar.ButtonItem).SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material

    End Sub

#End Region

#End Region

End Class

'Public Class ApplicationIdle
'    Implements System.Windows.Forms.IMessageFilter

'    Public Event Idle As EventHandler
'    Public Event Activity As EventHandler(Of ActivityEventArgs)

'    Public Shared ReadOnly ZeroTime As New TimeSpan(0, 0, 0)
'    Private Shared ReadOnly oneSecond As New TimeSpan(0, 0, 1)

'    Private timer As Timer

'    Private _IdleTime As TimeSpan
'    Private _TickInterval As TimeSpan
'    Private _TimeRemaining As TimeSpan
'    Private _TimeElapsed As TimeSpan

'    Public Sub New()

'        timer = New Timer

'        timer.Interval = 1000
'        AddHandler timer.Tick, New EventHandler(AddressOf timer_Tick)

'        _IdleTime = New TimeSpan(0, 0, 20)
'        _TickInterval = New TimeSpan(0, 0, 1)

'        _TimeRemaining = ZeroTime
'        _TimeElapsed = ZeroTime

'    End Sub

'    Private Sub timer_Tick(sender As Object, e As EventArgs)

'        _TimeElapsed = _TimeElapsed.Add(_TickInterval)
'        _TimeRemaining = _TimeRemaining.Subtract(_TickInterval)

'        If _TimeRemaining = ZeroTime Then

'            OnIdle(EventArgs.Empty)
'            [Stop]()

'        End If

'    End Sub
'    Public Sub Start()

'        _TimeRemaining = _IdleTime
'        _TimeElapsed = ZeroTime
'        Application.AddMessageFilter(Me)
'        timer.Start()

'    End Sub
'    Public Sub [Stop]()

'        timer.[Stop]()
'        _TimeRemaining = ZeroTime
'        _TimeElapsed = ZeroTime

'        Application.RemoveMessageFilter(Me)

'    End Sub
'    Public Function PreFilterMessage(ByRef m As System.Windows.Forms.Message) As Boolean Implements System.Windows.Forms.IMessageFilter.PreFilterMessage

'        If [Enum].IsDefined(GetType(ActivityMessages), m.Msg) Then

'            _TimeRemaining = _IdleTime
'            _TimeElapsed = ZeroTime

'            Dim e As New ActivityEventArgs(DirectCast(m.Msg, ActivityMessages))

'            OnActivity(e)

'        End If

'        Return False

'    End Function
'    Protected Overridable Sub OnIdle(e As EventArgs)

'        RaiseEvent Idle(Me, e)

'    End Sub
'    Protected Overridable Sub OnActivity(e As ActivityEventArgs)

'        RaiseEvent Activity(Me, e)

'    End Sub

'    Protected Overridable Sub OnAsyncCompleted(asyncResult As IAsyncResult)
'        Dim subscriber As EventHandler = DirectCast(asyncResult.AsyncState, EventHandler)
'        subscriber.EndInvoke(asyncResult)
'    End Sub

'    Protected Overridable Sub OnActivityAsyncCompleted(asyncResult As IAsyncResult)
'        Dim subscriber As EventHandler(Of ActivityEventArgs) = DirectCast(asyncResult.AsyncState, EventHandler(Of ActivityEventArgs))
'        subscriber.EndInvoke(asyncResult)
'    End Sub

'End Class
'Public Enum ActivityMessages As Integer
'    ''' <summary>
'    ''' Cursor moved while within the nonclient area.
'    ''' </summary>
'    WM_NCMOUSEMOVE = &HA0
'    ''' <summary>
'    ''' Mouse left button pressed while the cursor was within the nonclient area.
'    ''' </summary>
'    WM_NCLBUTTONDOWN = &HA1
'    ''' <summary>
'    ''' Mouse left button released while the cursor was within the nonclient area.
'    ''' </summary>
'    WM_NCLBUTTONUP = &HA2
'    ''' <summary>
'    ''' Mouse left button double-clicked while the cursor was within the nonclient area.
'    ''' </summary>
'    WM_NCLBUTTONDBLCLK = &HA3
'    ''' <summary>
'    ''' Mouse right button pressed while the cursor was within the nonclient area.
'    ''' </summary>
'    WM_NCRBUTTONDOWN = &HA4
'    ''' <summary>
'    ''' Mouse right button released while the cursor was within the nonclient area.
'    ''' </summary>
'    WM_NCRBUTTONUP = &HA5
'    ''' <summary>
'    ''' Mouse right button double-clicked while the cursor was within the nonclient area.
'    ''' </summary>
'    WM_NCRBUTTONDBLCLK = &HA6
'    ''' <summary>
'    ''' Mouse middle button pressed while the cursor was within the nonclient area.
'    ''' </summary>
'    WM_NCMBUTTONDOWN = &HA7
'    ''' <summary>
'    ''' Mouse middle button released while the cursor was within the nonclient area.
'    ''' </summary>
'    WM_NCMBUTTONUP = &HA8
'    ''' <summary>
'    ''' Mouse middle button double-clicked while the cursor was within the nonclient area.
'    ''' </summary>
'    WM_NCMBUTTONDBLCLK = &HA9
'    ''' <summary>
'    ''' Key pressed.
'    ''' </summary>
'    WM_KEYDOWN = &H100
'    ''' <summary>
'    ''' Key released.
'    ''' </summary>
'    WM_KEYUP = &H101
'    ''' <summary>
'    ''' F10 key, or held down the ALT key and then another key pressed.
'    ''' </summary>
'    WM_SYSKEYDOWN = &H104
'    ''' <summary>
'    ''' Key released that was pressed while the ALT key was held down.
'    ''' </summary>
'    WM_SYSKEYUP = &H105
'    ''' <summary>
'    ''' Cursor moved.
'    ''' </summary>
'    WM_MOUSEMOVE = &H200
'    ''' <summary>
'    ''' Mouse left button pressed.
'    ''' </summary>
'    WM_LBUTTONDOWN = &H201
'    ''' <summary>
'    ''' Mouse left button released.
'    ''' </summary>
'    WM_LBUTTONUP = &H202
'    ''' <summary>
'    ''' Mouse left button double-clicked.
'    ''' </summary>
'    WM_LBUTTONDBLCLK = &H203
'    ''' <summary>
'    ''' Mouse right button pressed.
'    ''' </summary>
'    WM_RBUTTONDOWN = &H204
'    ''' <summary>
'    ''' Mouse right button released.
'    ''' </summary>
'    WM_RBUTTONUP = &H205
'    ''' <summary>
'    ''' Mouse right button double-clicked.
'    ''' </summary>
'    WM_RBUTTONDBLCLK = &H206
'    ''' <summary>
'    ''' Mouse middle button pressed.
'    ''' </summary>
'    WM_MBUTTONDOWN = &H207
'    ''' <summary>
'    ''' Mouse middle button releaseed.
'    ''' </summary>
'    WM_MBUTTONUP = &H208
'    ''' <summary>
'    ''' Mouse middle button double-clicked.
'    ''' </summary>
'    WM_MBUTTONDBLCLK = &H209
'    ''' <summary>
'    ''' Mouse wheel rotated.
'    ''' </summary>
'    WM_MOUSEWHEEL = &H20A
'End Enum
'Public Class ActivityEventArgs
'    Inherits EventArgs
'#Region "Private Members"

'    Private _Message As ActivityMessages

'#End Region

'#Region "Constructors"

'    ''' <summary>
'    ''' Initializes a new instance of the ActivityEventArgs class.
'    ''' </summary>
'    ''' <param name="message">One of the ActivityMessages.</param>
'    Public Sub New(message As ActivityMessages)
'        _Message = message
'    End Sub

'#End Region

'#Region "Properties"

'    ''' <summary>
'    ''' Gets the one of the ActivityMessages that the component used to consider the application not idle. 
'    ''' </summary>
'    Public ReadOnly Property Message() As ActivityMessages
'        Get
'            Return _Message
'        End Get
'    End Property

'#End Region
'End Class
