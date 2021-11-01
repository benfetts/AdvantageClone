Namespace Maintenance.General.Presentation

    Public Class AdvantageServicesSettingsForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim AdvantageServicesSettingsForm As AdvantageFramework.Maintenance.General.Presentation.AdvantageServicesSettingsForm = Nothing

            AdvantageServicesSettingsForm = New AdvantageFramework.Maintenance.General.Presentation.AdvantageServicesSettingsForm()

            AdvantageServicesSettingsForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub AdvantageServicesForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim IsAgencyASP As Boolean = False

            ButtonItemService_Enabled.Image = AdvantageFramework.My.Resources.PowerOnImage
            ButtonItemService_ProcessNow.Image = AdvantageFramework.My.Resources.ProcessImage
            ButtonItemSettings_Save.Image = AdvantageFramework.My.Resources.SaveImage

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                IsAgencyASP = AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext)

            End Using

            AdvantageServicesSettingsForm_Settings.LoadDefaults(False, IsAgencyASP)

        End Sub
        Private Sub AdvantageServicesForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            'objects
            Dim DatabaseProfile As AdvantageFramework.Database.DatabaseProfile = Nothing
            Dim SqlConntection As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing

            AdvantageServicesSettingsForm_Settings.SetDefaults()

            SqlConntection = New System.Data.SqlClient.SqlConnectionStringBuilder(Me.Session.ConnectionString)

            DatabaseProfile = New AdvantageFramework.Database.DatabaseProfile

            DatabaseProfile.DatabaseServer = SqlConntection.DataSource
            DatabaseProfile.DatabaseName = SqlConntection.InitialCatalog
            DatabaseProfile.UseWindowsAuthentication = False
            DatabaseProfile.DatabaseUserName = SqlConntection.UserID
            DatabaseProfile.DatabasePassword = SqlConntection.Password

            AdvantageServicesSettingsForm_Settings.SelectDatabaseProfile(DatabaseProfile)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub AdvantageServicesSettingsForm_Settings_EnableOrDisableSaveEvent(ByVal Enabled As Boolean) Handles AdvantageServicesSettingsForm_Settings.EnableOrDisableSaveEvent

            ButtonItemSettings_Save.Enabled = Enabled

        End Sub
        Private Sub AdvantageServicesSettingsForm_Settings_EnableOrDisableActionsEvent() Handles AdvantageServicesSettingsForm_Settings.EnableOrDisableActionsEvent

            If AdvantageServicesSettingsForm_Settings.SelectedDatabaseProfile IsNot Nothing Then

                RibbonBarFilePanel_Service.Enabled = True
                RibbonBarFilePanel_Settings.Enabled = True

            Else

                RibbonBarFilePanel_Service.Enabled = False
                RibbonBarFilePanel_Settings.Enabled = False

            End If

        End Sub
        Private Sub AdvantageServicesSettingsForm_Settings_EnableOrDisableServiceActionsEvent() Handles AdvantageServicesSettingsForm_Settings.EnableOrDisableServiceActionsEvent

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

                ElseIf AdvantageServicesSettingsForm_Settings.SelectedAdvantageService.Code = AdvantageFramework.Services.Service.AdvantageExportWindowsService.ToString Then

                    ButtonItemService_ProcessNow.Enabled = AdvantageServicesSettingsForm_Settings.HasASelectedExportTemplate

                ElseIf AdvantageServicesSettingsForm_Settings.SelectedAdvantageService.Code = AdvantageFramework.Services.Service.AdvantageNielsenWindowsService.ToString Then

                    ButtonItemService_ProcessNow.Enabled = False

                ElseIf AdvantageServicesSettingsForm_Settings.SelectedAdvantageService.Code = AdvantageFramework.Services.Service.AdvantageComScoreWindowsService.ToString Then

                    If Debugger.IsAttached Then

                        ButtonItemService_ProcessNow.Enabled = True

                    Else

                        ButtonItemService_ProcessNow.Enabled = False

                    End If

                Else

                    ButtonItemService_ProcessNow.Enabled = True

                End If

            Else

                ButtonItemService_Enabled.Enabled = False
                ButtonItemService_ProcessNow.Enabled = False

            End If

        End Sub
        Private Sub ButtonItemService_Enabled_Click(sender As Object, e As EventArgs) Handles ButtonItemService_Enabled.Click

            AdvantageServicesSettingsForm_Settings.EnableOrDisableService()

        End Sub
        Private Sub ButtonItemService_ProcessNow_Click(sender As Object, e As EventArgs) Handles ButtonItemService_ProcessNow.Click

            'objects
            Dim [Continue] As Boolean = False

            If ButtonItemSettings_Save.Enabled Then

                If AdvantageFramework.WinForm.MessageBox.Show("You need to save your changes before continuing.  Do you want to save your changes now?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Save Changes?") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                    AdvantageServicesSettingsForm_Settings.SaveSettings()

                    [Continue] = True

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                End If

            Else

                [Continue] = True

            End If

            If [Continue] Then

                AdvantageServicesSettingsForm_Settings.ProcessNow()

            End If

        End Sub
        Private Sub ButtonItemSettings_Save_EnabledChanged(sender As Object, e As EventArgs) Handles ButtonItemSettings_Save.EnabledChanged

            AdvantageServicesSettingsForm_Settings.SaveButtonEnabledChanged(ButtonItemSettings_Save.Enabled)

        End Sub
        Private Sub ButtonItemSettings_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemSettings_Save.Click

            AdvantageServicesSettingsForm_Settings.SaveSettings()

        End Sub

#End Region

#End Region

    End Class

End Namespace