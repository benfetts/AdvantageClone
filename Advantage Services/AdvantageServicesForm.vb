Public Class AdvantageServicesForm

    Private Shared Event RefreshSettingsEvent()

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _DatabaseProfiles As Generic.List(Of AdvantageFramework.Database.DatabaseProfile) = Nothing
    Private _RefreshingDatabaseProfiles As Boolean = False
    Private _HasBeenShown As Boolean = False
    Private WithEvents _Timer As System.Windows.Forms.Timer = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Private Sub LoadDatabaseProfiles()

        _DatabaseProfiles = AdvantageFramework.Services.LoadDatabaseProfiles

        ComboBoxCurrentDatabaseProfile_CurrentDatabaseProfile.DataSource = _DatabaseProfiles.Select(Function(DB) New With {.Name1 = DB.DatabaseName, .Name = DB.DatabaseName}).ToList

    End Sub
    Private Sub SelectDatabaseProfile()

        'objects
        Dim DatabaseProfile As AdvantageFramework.Database.DatabaseProfile = Nothing

        If _RefreshingDatabaseProfiles = False Then

            If ComboBoxCurrentDatabaseProfile_CurrentDatabaseProfile.HasASelectedValue Then

                DatabaseProfile = AdvantageFramework.Database.LoadDatabaseProfile(ComboBoxCurrentDatabaseProfile_CurrentDatabaseProfile.SelectedValue)

            Else

                DatabaseProfile = Nothing

            End If

            AdvantageServicesSettingsForm_Settings.SelectDatabaseProfile(DatabaseProfile)

        End If

    End Sub
    Private Sub RefreshSettings()

        SelectDatabaseProfile()

    End Sub
    Private Sub CheckServiceStatus(ByVal ButtonItemAutoStart As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem, _
                                   ByVal ButtonItemStart As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem, _
                                   ByVal ButtonItemStop As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem)

        'objects
        Dim ServiceController As System.ServiceProcess.ServiceController = Nothing
        Dim ServiceStartupType As AdvantageFramework.Services.ServiceStartupType = Nothing

        ServiceController = AdvantageFramework.Services.Load()

        If ServiceController IsNot Nothing Then

            ServiceStartupType = AdvantageFramework.Services.GetStartupType()

            If ServiceStartupType = AdvantageFramework.Services.ServiceStartupType.Automatic Then

                ButtonItemAutoStart.Checked = True

            Else

                ButtonItemAutoStart.Checked = False

            End If

            If ServiceController.Status = ServiceProcess.ServiceControllerStatus.Paused OrElse _
                    ServiceController.Status = ServiceProcess.ServiceControllerStatus.PausePending OrElse _
                    ServiceController.Status = ServiceProcess.ServiceControllerStatus.Stopped OrElse _
                    ServiceController.Status = ServiceProcess.ServiceControllerStatus.StopPending Then

                ButtonItemStart.Visible = True
                ButtonItemStop.Visible = False
                ButtonItemAutoStart.Enabled = True

            Else

                ButtonItemStart.Visible = False
                ButtonItemStop.Visible = True
                ButtonItemAutoStart.Enabled = False

            End If

        Else

            AdvantageFramework.Services.Stop()

            ButtonItemStart.Visible = True
            ButtonItemStop.Visible = False
            ButtonItemAutoStart.Enabled = True

        End If

    End Sub
    Private Sub RefreshServiceRibbon()

        RibbonBarFilePanel_Service.ResetCachedContentSize()

        RibbonBarFilePanel_Service.Refresh()

        RibbonBarFilePanel_Service.Width = RibbonBarFilePanel_Service.GetAutoSizeWidth

        RibbonBarFilePanel_Service.Refresh()

    End Sub
    Private Sub EnableOrDisableServiceActions()

        If AdvantageServicesSettingsForm_Settings.SelectedAdvantageService IsNot Nothing Then

            ButtonItemService_Enabled.Enabled = True

            If AdvantageServicesSettingsForm_Settings.SelectedAdvantageService.Enabled Then

                ButtonItemService_Enabled.Image = AdvantageFramework.My.Resources.PowerCancelImage
                ButtonItemService_Enabled.Text = "Disable"

            Else

                ButtonItemService_Enabled.Image = AdvantageFramework.My.Resources.PowerOnImage
                ButtonItemService_Enabled.Text = "Enable"

            End If

            RibbonBarFilePanel_Service.ResetCachedContentSize()

            RibbonBarFilePanel_Service.Refresh()

            RibbonBarFilePanel_Service.Width = RibbonBarFilePanel_Service.GetAutoSizeWidth

            RibbonBarFilePanel_Service.Refresh()

            If AdvantageServicesSettingsForm_Settings.SelectedAdvantageService.Code = AdvantageFramework.Services.Service.AdvantageWindowsService.ToString OrElse
                    AdvantageServicesSettingsForm_Settings.SelectedAdvantageService.Code = AdvantageFramework.Services.Service.AdvantageCalendarWindowsService.ToString OrElse
                    AdvantageServicesSettingsForm_Settings.SelectedAdvantageService.Code = AdvantageFramework.Services.Service.AdvantageAutomatedAssignmentsService.ToString Then

                If Debugger.IsAttached Then

                    ButtonItemService_ProcessNow.Enabled = True

                Else

                    ButtonItemService_ProcessNow.Enabled = False

                End If

            ElseIf AdvantageServicesSettingsForm_Settings.SelectedAdvantageService.Code = AdvantageFramework.Services.Service.AdvantageNielsenWindowsService.ToString Then

                ButtonItemService_ProcessNow.Enabled = False

            Else

                ButtonItemService_ProcessNow.Enabled = True

            End If

        Else

            ButtonItemService_Enabled.Enabled = False
            ButtonItemService_ProcessNow.Enabled = False

        End If

    End Sub

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

    Private Sub AdvantageServicesForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If e.CloseReason <> CloseReason.ApplicationExitCall Then

            e.Cancel = True

            Me.Hide()

        End If

    End Sub
    Private Sub AdvantageServicesForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        NotifyIconForm_NotifyIcon.Icon = My.Resources.AdvantageServicesIcon

        AddHandler AdvantageFramework.Navigation.ShowMessageBoxEvent, AddressOf AdvantageFramework.WinForm.MessageBox.Show
        AddHandler RefreshSettingsEvent, AddressOf RefreshSettings

        ToolStripMenuItemMenu_ShutDown.Image = AdvantageFramework.My.Resources.ExitImage
        ToolStripMenuItemMenu_ShowLogAndSettings.Image = AdvantageFramework.My.Resources.LogAndSettingsImage
        ButtonItemDatabaseProfiles_Manage.Image = AdvantageFramework.My.Resources.DatabaseProfileImage

        ButtonItemService_AutoStart.Image = AdvantageFramework.My.Resources.AutoStartImage
        ButtonItemService_Start.Image = AdvantageFramework.My.Resources.StartImage
        ButtonItemService_Stop.Image = AdvantageFramework.My.Resources.StopImage
        ButtonItemService_Enabled.Image = AdvantageFramework.My.Resources.PowerOnImage
        ButtonItemService_ProcessNow.Image = AdvantageFramework.My.Resources.ProcessImage
        ButtonItemService_QuickManage.Image = AdvantageFramework.My.Resources.QuickManageImage
        ButtonItemSettings_Save.Image = AdvantageFramework.My.Resources.SaveImage
        ButtonItemSystem_Hide.Image = AdvantageFramework.My.Resources.HideImage
        ButtonItemMainRibbon_Help.Image = AdvantageFramework.My.Resources.HelpImage
        ButtonItemMainRibbon_ShowAndHide.Image = AdvantageFramework.My.Resources.UpImage
        ButtonItemLog_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage

        ButtonItemSystem_Exit.Visible = False

        LoadDatabaseProfiles()

        AdvantageServicesSettingsForm_Settings.LoadDefaults(True, False)

        CheckServiceStatus(ButtonItemService_AutoStart, ButtonItemService_Start, ButtonItemService_Stop)

    End Sub
    Private Sub AdvantageServicesForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        AdvantageServicesSettingsForm_Settings.SetDefaults()

        Me.Hide()

        _HasBeenShown = True

        _Timer = New System.Windows.Forms.Timer
        _Timer.Interval = 43200000
        _Timer.Start()

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub _Timer_Tick(sender As Object, e As EventArgs) Handles _Timer.Tick

        'objects
        Dim DatabaseProfile As AdvantageFramework.Database.DatabaseProfile = Nothing
        Dim RefreshSettings As Boolean = False
        Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing

        DatabaseProfile = AdvantageServicesSettingsForm_Settings.SelectedDatabaseProfile

        If DatabaseProfile IsNot Nothing Then

            Try

                Using DataContext = New AdvantageFramework.Database.DataContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                    Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.ADV_SERV_USER_CHANGE.ToString)

                    If Setting IsNot Nothing Then

                        RefreshSettings = Setting.Value

                        If RefreshSettings Then

                            Setting.Value = False

                            AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

                        End If

                    End If
                    
                End Using

            Catch ex As Exception
                RefreshSettings = False
            End Try

            If RefreshSettings Then

                RaiseEvent RefreshSettingsEvent()

            End If

        End If

    End Sub
    Private Sub ButtonItemService_Start_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemService_Start.Click

        AdvantageFramework.WinForm.Presentation.ShowWaitForm("Starting...")

        If AdvantageFramework.Services.Start() Then

            ButtonItemService_Start.Visible = False
            ButtonItemService_Stop.Visible = True
            ButtonItemService_AutoStart.Enabled = False

        Else

            AdvantageFramework.WinForm.Presentation.CloseWaitForm()

            AdvantageFramework.Navigation.ShowMessageBox(AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.Services.Service.AdvantageWindowsService.ToString()) & " cannot be started.")

        End If

        RefreshServiceRibbon()

        AdvantageFramework.WinForm.Presentation.CloseWaitForm()

    End Sub
    Private Sub ButtonItemService_Stop_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemService_Stop.Click

        AdvantageFramework.WinForm.Presentation.ShowWaitForm("Stopping...")

        AdvantageFramework.Services.Stop()

        ButtonItemService_Start.Visible = True
        ButtonItemService_Stop.Visible = False
        ButtonItemService_AutoStart.Enabled = True

        RefreshServiceRibbon()

        AdvantageFramework.WinForm.Presentation.CloseWaitForm()

    End Sub
    Private Sub ButtonItemService_AutoStart_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemService_AutoStart.CheckedChanged

        AdvantageFramework.WinForm.Presentation.ShowWaitForm("Changing...")

        If ButtonItemService_AutoStart.Checked Then

            AdvantageFramework.Services.SetStartupType(AdvantageFramework.Services.ServiceStartupType.Automatic)

        Else

            AdvantageFramework.Services.SetStartupType(AdvantageFramework.Services.ServiceStartupType.Manual)

        End If

        AdvantageFramework.WinForm.Presentation.CloseWaitForm()

    End Sub
    Private Sub AdvantageServicesSettingsForm_Settings_EnableOrDisableSaveEvent(ByVal Enabled As Boolean) Handles AdvantageServicesSettingsForm_Settings.EnableOrDisableSaveEvent

        ButtonItemSettings_Save.Enabled = Enabled

    End Sub
    Private Sub AdvantageServicesSettingsForm_Settings_EnableOrDisableActionsEvent() Handles AdvantageServicesSettingsForm_Settings.EnableOrDisableActionsEvent

        If AdvantageServicesSettingsForm_Settings.SelectedDatabaseProfile IsNot Nothing Then

            EnableOrDisableServiceActions()
            ButtonItemService_QuickManage.Enabled = True

            RibbonBarFilePanel_Settings.Enabled = True

        Else

            ButtonItemService_Enabled.Enabled = False
            ButtonItemService_ProcessNow.Enabled = False
            ButtonItemService_QuickManage.Enabled = False

            RibbonBarFilePanel_Settings.Enabled = False

        End If

    End Sub
    Private Sub AdvantageServicesSettingsForm_Settings_EnableOrDisableServiceActionsEvent() Handles AdvantageServicesSettingsForm_Settings.EnableOrDisableServiceActionsEvent

        EnableOrDisableServiceActions()

    End Sub
    Private Sub AdvantageServicesSettingsForm_Settings_NielsenTabSelectedEvent() Handles AdvantageServicesSettingsForm_Settings.NielsenTabSelectedEvent

        'If Debugger.IsAttached Then

        '    ButtonItemService_ProcessNow.Enabled = True

        'Else

        ButtonItemService_ProcessNow.Enabled = False

        'End If

    End Sub
    Private Sub ButtonItemService_Enabled_Click(sender As Object, e As EventArgs) Handles ButtonItemService_Enabled.Click

        AdvantageServicesSettingsForm_Settings.EnableOrDisableService()

    End Sub
    Private Sub ButtonItemService_ProcessNow_Click(sender As Object, e As EventArgs) Handles ButtonItemService_ProcessNow.Click

        AdvantageServicesSettingsForm_Settings.ProcessNow()

    End Sub
    Private Sub ButtonItemService_QuickManage_Click(sender As Object, e As EventArgs) Handles ButtonItemService_QuickManage.Click

        If AdvantageFramework.Maintenance.General.Presentation.AdvantageServicesQuickManageDialog.ShowFormDialog(AdvantageServicesSettingsForm_Settings.SelectedDatabaseProfile) = Windows.Forms.DialogResult.OK Then

            RefreshSettings()

        End If

    End Sub
    Private Sub ButtonItemSettings_Save_EnabledChanged(sender As Object, e As EventArgs) Handles ButtonItemSettings_Save.EnabledChanged

        AdvantageServicesSettingsForm_Settings.SaveButtonEnabledChanged(ButtonItemSettings_Save.Enabled)

    End Sub
    Private Sub ButtonItemSettings_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemSettings_Save.Click

        AdvantageServicesSettingsForm_Settings.SaveSettings()

    End Sub
    Private Sub ButtonItemLog_Refresh_Click(sender As Object, e As EventArgs) Handles ButtonItemLog_Refresh.Click

        AdvantageServicesSettingsForm_Settings.RefreshLog()

    End Sub
    Private Sub ComboBoxCurrentDatabaseProfile_CurrentDatabaseProfile_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxCurrentDatabaseProfile_CurrentDatabaseProfile.SelectedValueChanged

        If _HasBeenShown Then

            SelectDatabaseProfile()

        End If

        If AdvantageServicesSettingsForm_Settings.IsNielsenServiceTabSelected Then

            ButtonItemService_ProcessNow.Enabled = False

        End If

    End Sub
    Private Sub ButtonItemMainRibbon_ShowAndHide_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemMainRibbon_ShowAndHide.Click

        If RibbonControlForm_MainRibbon.Expanded Then

            RibbonControlForm_MainRibbon.Expanded = False
            ButtonItemMainRibbon_ShowAndHide.Image = AdvantageFramework.My.Resources.DownImage

        Else

            RibbonControlForm_MainRibbon.Expanded = True
            ButtonItemMainRibbon_ShowAndHide.Image = AdvantageFramework.My.Resources.UpImage

        End If

    End Sub
    Private Sub ButtonItemMainRibbon_Help_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemMainRibbon_Help.Click

        AdvantageFramework.WinForm.Presentation.AboutDialog.ShowFormDialog()

    End Sub
    Private Sub ToolStripMenuItemMenu_ShowLogAndSettings_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemMenu_ShowLogAndSettings.Click

        Me.Show()
        Me.BringToFront()
        Me.ShowInTaskbar = True

    End Sub
    Private Sub ButtonItemDatabaseProfiles_Manage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDatabaseProfiles_Manage.Click

        AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(AdvantageFramework.WinForm.Presentation.CRUDDialog.Type.DatabaseProfile, False, False)

        _RefreshingDatabaseProfiles = True

        Try

            LoadDatabaseProfiles()

            If AdvantageServicesSettingsForm_Settings.SelectedDatabaseProfile IsNot Nothing Then

                ComboBoxCurrentDatabaseProfile_CurrentDatabaseProfile.SelectedValue = AdvantageServicesSettingsForm_Settings.SelectedDatabaseProfile.DatabaseName

            End If

        Catch ex As Exception

        End Try

        _RefreshingDatabaseProfiles = False

        If AdvantageServicesSettingsForm_Settings.SelectedDatabaseProfile IsNot Nothing AndAlso ComboBoxCurrentDatabaseProfile_CurrentDatabaseProfile.SelectedIndex = 0 Then

            SelectDatabaseProfile()

        End If

    End Sub
    Private Sub ToolStripMenuItemMenu_ShutDown_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemMenu_ShutDown.Click

        System.Windows.Forms.Application.Exit()

    End Sub
    Private Sub ButtonItemSystem_Hide_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemSystem_Hide.Click

        Me.Hide()

    End Sub

#End Region

#End Region

End Class