Namespace WinForm.Presentation.BaseForms

    Public Class MDIApplicationForm

        Public Event SaveSettingsEvent()
        Private Declare Function SendMessage Lib "user32.dll" Alias "SendMessageA" (ByVal hWnd As IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As IntPtr) As IntPtr
        Private Declare Function SetForegroundWindow Lib "user32.dll" (ByVal hwnd As Long) As Long
        Public Event SetupProgressBarEvent(ByVal MinimumValue As Integer, ByVal MaximumValue As Integer, ByVal StartValue As Integer)
        Public Event SetProgressBarValueEvent(ByVal CurrentValue As Integer)
        Public Event CloseProgressBarEvent()
        Public Event SetMessageEvent(ByVal Message As String)
        Public Event ClearMessageEvent()
        Public Event StartProgressBarMarqueeEvent(ByVal Message As String)
        Public Event CloseSplashScreenForm()
        Public Event RunDatabaseScriptCheckEvent()

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected Shared _Session As AdvantageFramework.Security.Session = Nothing
        Protected _HasToLogIn As Boolean = True
        Protected _UseSecurityLogin As Boolean = True
        Protected _Application As AdvantageFramework.Security.Application = Security.Application.Advantage
        Protected _IsFromPowerBuilderMenu As Boolean = False
        Protected _IsFormClosing As Boolean = False
        Protected _LegacyAdvantageProcessID As Integer = 0
        Private Const WM_USER As Integer = &H400
        Private Shared WM_QUERYENDSESSION As Integer = &H11
        Protected _IsOpeningModule As Boolean = False
        Protected _ProgressThread As System.Threading.Thread = Nothing
        Protected _InternalOnlyMode As Boolean = False
        Protected _BatchMode As Boolean = False

#End Region

#Region " Properties "

        Public ReadOnly Property Session As AdvantageFramework.Security.Session
            Get
                Session = _Session
            End Get
        End Property
        Public ReadOnly Property IsFormClosing As Boolean
            Get
                IsFormClosing = _IsFormClosing
            End Get
        End Property
        Public Property HasToLogIn As Boolean
            Get
                HasToLogIn = _HasToLogIn
            End Get
            Set(ByVal value As Boolean)
                _HasToLogIn = value
            End Set
        End Property
        Public Property UseSecurityLogin As Boolean
            Get
                UseSecurityLogin = _UseSecurityLogin
            End Get
            Set(ByVal value As Boolean)
                _UseSecurityLogin = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub ShutDown()

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing

            If Me.Session IsNot Nothing Then

                If Me.Session.MenuHWND <> 0 Then

                    SendMessage(Me.Session.MenuHWND, WM_USER + 61, 0, 0)

                End If

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.NEW_LICENSE_KEY.ToString)

                    If Setting IsNot Nothing AndAlso Setting.Value = 1 Then

                        AdvantageFramework.Security.LicenseKey.Clear(Me.Session, AdvantageFramework.Security.GetMACAddress, "", "")

                    Else

                        Me.Session.UnregisterSecuritySession()

                    End If

                End Using

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.LAME_SESSION " &
                                                                           "WHERE SESSION_ID = {0}", Me.Session.MenuHWND))

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.Security.SetUserLogoutAuditRecord(Me.Session)

            End If

        End Sub
        Protected Overrides Sub Finalize()

            MyBase.Finalize()

        End Sub
        Protected Function LoadStartUpInformation(ByRef CommandLineArgs As System.Collections.ObjectModel.ReadOnlyCollection(Of String)) As Boolean

            'objects
            Dim ServerName As String = ""
            Dim DatabaseName As String = ""
            Dim UseWindowsAuthentication As Boolean = False
            Dim UserName As String = ""
            Dim Password As String = ""
            Dim ErrorMessage As String = ""
            Dim IsLoggedIn As Boolean = False
            Dim ConnectionString As String = ""
            Dim UpperCaseDatabaseAndUserName As Boolean = False
            Dim ConnectionDatabaseProfiles As Generic.List(Of AdvantageFramework.Database.ConnectionDatabaseProfile) = Nothing
            Dim ConnectionDatabaseProfile As AdvantageFramework.Database.ConnectionDatabaseProfile = Nothing
            Dim ValidLogin As Boolean = False
            Dim TwoFactor As AdvantageFramework.Security.Password.TwoFactorAuthentication = Nothing

            For Each CommandLine In CommandLineArgs

                If CommandLine.StartsWith("-s") Then

                    ServerName = CommandLine.Replace("-s", "")

                ElseIf CommandLine.StartsWith("-d") Then

                    DatabaseName = CommandLine.Replace("-d", "")

                ElseIf CommandLine.StartsWith("-n") Then

                    UseWindowsAuthentication = True

                ElseIf CommandLine.StartsWith("-u") Then

                    UserName = CommandLine.Replace("-u", "")

                ElseIf CommandLine.StartsWith("-p") Then

                    Password = CommandLine.Replace("-p", "")

                ElseIf CommandLine.StartsWith("-r") Then

                    _IsFromPowerBuilderMenu = True

                ElseIf CommandLine.StartsWith("-x") Then

                    If CommandLine = "-xADVAN" Then

                        _InternalOnlyMode = True

                    ElseIf CommandLine = "-xBATCH" Then

                        _BatchMode = True

                    End If

                ElseIf CommandLine.StartsWith("-c") Then

                    UpperCaseDatabaseAndUserName = True

                End If

            Next

            If UseWindowsAuthentication Then

                UserName = My.User.Name

            End If

            If UpperCaseDatabaseAndUserName Then

                UserName = UserName.ToUpper
                DatabaseName = DatabaseName.ToUpper

            End If

            ConnectionDatabaseProfiles = AdvantageFramework.Database.LoadConnectionDatabaseProfileForAdvantage()

            Try

                ConnectionDatabaseProfile = ConnectionDatabaseProfiles.FirstOrDefault(Function(Entity) Entity.DatabaseName = DatabaseName)

            Catch ex As Exception
                ConnectionDatabaseProfile = Nothing
            End Try

            If (_Application = Security.Application.Advantage_Nielsen_Database_Update OrElse _Application = Security.Application.Advantage_Database_Update OrElse _Application = Security.Application.Advantage_Update) OrElse
                    ConnectionDatabaseProfile IsNot Nothing Then

                If (_Application = Security.Application.Advantage_Nielsen_Database_Update OrElse _Application = Security.Application.Advantage_Database_Update OrElse _Application = Security.Application.Advantage_Update) Then

                    ValidLogin = AdvantageFramework.Security.Login(_Application, Nothing, _Session, ServerName, DatabaseName, UseWindowsAuthentication,
                                                                   UserName, Password, AdvantageFramework.Security.GetMACAddress, AdvantageFramework.Security.GetIPAddress,
                                                                   "", "",
                                                                   ErrorMessage)

                ElseIf ConnectionDatabaseProfile IsNot Nothing Then

                    ConnectionString = AdvantageFramework.Database.CreateConnectionString(ConnectionDatabaseProfile.ServerName, ConnectionDatabaseProfile.DatabaseName, False, ConnectionDatabaseProfile.UserName, AdvantageFramework.Security.Encryption.Decrypt(ConnectionDatabaseProfile.Password))

                    TwoFactor = New AdvantageFramework.Security.Password.TwoFactorAuthentication(ConnectionString, UserName)

                    If TwoFactor.Mode = AdvantageFramework.Security.Password.TwoFactorAuthentication.Type.None Then

                        ValidLogin = AdvantageFramework.Security.Login(_Application, Nothing, _Session, ConnectionDatabaseProfile.ServerName, DatabaseName,
                                                                       UseWindowsAuthentication, UserName, Password,
                                                                       AdvantageFramework.Security.GetMACAddress,
                                                                       AdvantageFramework.Security.GetIPAddress,
                                                                       AdvantageFramework.Database.CreateConnectionString(ConnectionDatabaseProfile.ServerName,
                                                                                                                          ConnectionDatabaseProfile.DatabaseName,
                                                                                                                          False,
                                                                                                                          ConnectionDatabaseProfile.UserName,
                                                                                                                          AdvantageFramework.Security.Encryption.Decrypt(ConnectionDatabaseProfile.Password)),
                                                                       ConnectionDatabaseProfile.UserName,
                                                                       ErrorMessage)

                    Else

                        Select Case TwoFactor.Mode

                            Case AdvantageFramework.Security.Password.TwoFactorAuthentication.Type.Email

                                ValidLogin = False

                            Case AdvantageFramework.Security.Password.TwoFactorAuthentication.Type.SecurityQuestion

                                ValidLogin = False

                        End Select

                    End If

                End If

                If ValidLogin Then

                    If ErrorMessage <> "" Then

                        AdvantageFramework.Navigation.ShowMessageBox(ErrorMessage, MessageBox.MessageBoxButtons.OK, "Warning")

                    End If

                    RaiseEvent RunDatabaseScriptCheckEvent()

                    IsLoggedIn = True

                Else

                    RaiseEvent CloseSplashScreenForm()

                    If AdvantageFramework.Navigation.ShowLogin(_Application, Nothing, _Session, ServerName, DatabaseName, UseWindowsAuthentication, UserName, UpperCaseDatabaseAndUserName) = AdvantageFramework.WinForm.MessageBox.DialogResults.OK Then

                        RaiseEvent RunDatabaseScriptCheckEvent()

                        IsLoggedIn = True

                    Else

                        System.Windows.Forms.Application.Exit()

                    End If

                End If

            Else

                RaiseEvent CloseSplashScreenForm()

                If AdvantageFramework.Navigation.ShowLogin(_Application, Nothing, _Session, ServerName, DatabaseName, UseWindowsAuthentication, UserName, UpperCaseDatabaseAndUserName) = AdvantageFramework.WinForm.MessageBox.DialogResults.OK Then

                    RaiseEvent RunDatabaseScriptCheckEvent()

                    IsLoggedIn = True

                Else

                    System.Windows.Forms.Application.Exit()

                End If

            End If

            LoadStartUpInformation = IsLoggedIn

        End Function
        Protected Friend Function OpenModule(ByVal SecurityModule As AdvantageFramework.Security.Modules) As System.Windows.Forms.DialogResult

            'objects
            Dim [Module] As AdvantageFramework.Security.Database.Views.ModuleView = Nothing

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                [Module] = AdvantageFramework.Security.Database.Procedures.ModuleView.LoadByModuleCode(SecurityDbContext, SecurityModule.ToString)

                OpenModule = OpenModule([Module])

            End Using

        End Function
        Protected Friend Function OpenModule(ByVal ModuleID As Integer) As System.Windows.Forms.DialogResult

            'objects
            Dim [Module] As AdvantageFramework.Security.Database.Views.ModuleView = Nothing

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                [Module] = AdvantageFramework.Security.Database.Procedures.ModuleView.LoadByModuleID(SecurityDbContext, ModuleID)

                OpenModule = OpenModule([Module])

            End Using

        End Function
        Private Function GetModuleFormType(ByVal [Module] As AdvantageFramework.Security.Database.Views.ModuleView) As System.Type

            'objects
            Dim ModuleFormType As System.Type = Nothing

            Select Case [Module].ModuleCode

                Case AdvantageFramework.Security.Modules.FinanceAccounting_PaymentManagerEnhanced.ToString

                    ModuleFormType = GetType(AdvantageFramework.FinanceAndAccounting.Presentation.PaymentManagerDialog)

                Case AdvantageFramework.Security.Modules.GeneralLedger_Processing_UpdateToSummary.ToString

                    ModuleFormType = GetType(AdvantageFramework.GeneralLedger.Processing.Presentation.UpdateToSummaryForm)

                Case AdvantageFramework.Security.Modules.Security_Setup_CDPSecurityGroup.ToString

                    ModuleFormType = GetType(AdvantageFramework.Security.Setup.Presentation.CDPSecurityGroupSetupForm)

                Case AdvantageFramework.Security.Modules.GeneralLedger_Processing_PostRecurring.ToString

                    ModuleFormType = GetType(AdvantageFramework.GeneralLedger.JournalEntriesBudgets.Presentation.RecurringJournalEntryPostForm)

                Case AdvantageFramework.Security.Modules.Security_PasswordPolicy.ToString

                    ModuleFormType = GetType(AdvantageFramework.Security.Presentation.PasswordPolicySetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Media_CanadaUniverse.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Media.Presentation.CanadaUniverseSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Media_MarketGroups.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Media.Presentation.MarketGroupSetupForm)

                Case AdvantageFramework.Security.Modules.FinanceAccounting_RevenueResourcePlan.ToString

                    ModuleFormType = GetType(AdvantageFramework.FinanceAndAccounting.Presentation.RevenueResourcePlanSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_VendorInvoiceCategory.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Accounting.Presentation.VendorInvoiceCategorySetupForm)

                Case AdvantageFramework.Security.Modules.Media_MediaBroadcastWorksheet.ToString

                    ModuleFormType = GetType(AdvantageFramework.Media.Presentation.MediaBroadcastWorksheetSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Client_ClientContactImport.ToString

                    ModuleFormType = GetType(AdvantageFramework.Importing.Presentation.ImportForm)

                Case AdvantageFramework.Security.Modules.Maintenance_General_VCCSettings.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.General.Presentation.VCCSettingsSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_General_ContactTypes.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.General.Presentation.ContactTypeSetupForm)

                Case AdvantageFramework.Security.Modules.FinanceAccounting_Reports_ClientPLRTP.ToString

                    ModuleFormType = GetType(AdvantageFramework.Reporting.Presentation.ClientPLInitialLoadingDialog)

                Case AdvantageFramework.Security.Modules.Employee_Reports_DirectTimeActivityRTP.ToString

                    ModuleFormType = GetType(AdvantageFramework.Reporting.Presentation.DirectTimeInitialLoadingDialog)

                Case AdvantageFramework.Security.Modules.Employee_Reports_HoursWorkedRTP.ToString

                    ModuleFormType = GetType(AdvantageFramework.Reporting.Presentation.DirectIndirectTimeInitialLoadingDialog)

                Case AdvantageFramework.Security.Modules.Billing_Reports_InvoicePrintingEnhancedRTP.ToString

                    ModuleFormType = GetType(AdvantageFramework.Billing.Reports.Presentation.InvoicePrintingSetupForm)

                Case AdvantageFramework.Security.Modules.Security_Setup_Group.ToString

                    ModuleFormType = GetType(AdvantageFramework.Security.Setup.Presentation.GroupSetupForm)

                Case AdvantageFramework.Security.Modules.Security_Setup_ModuleAccess.ToString

                    ModuleFormType = GetType(AdvantageFramework.Security.Setup.Presentation.ModuleAccessForm)

                Case AdvantageFramework.Security.Modules.Security_Setup_User.ToString

                    ModuleFormType = GetType(AdvantageFramework.Security.Setup.Presentation.UserSetupForm)

                Case AdvantageFramework.Security.Modules.Desktop_ReportWriter_DynamicReports.ToString

                    ModuleFormType = GetType(AdvantageFramework.Desktop.Presentation.DynamicReportsForm)

                Case AdvantageFramework.Security.Modules.Security_ChangePassword.ToString

                    ModuleFormType = GetType(AdvantageFramework.Security.Presentation.ChangePasswordDialog)

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectSchedule_Phase.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.ProjectSchedule.Presentation.PhaseSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectSchedule_Status.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.ProjectSchedule.Presentation.StatusSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectSchedule_Role.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.ProjectSchedule.Presentation.RoleSetupForm)

                Case AdvantageFramework.Security.Modules.Desktop_ReportWriter_AdvancedReportWriter.ToString

                    ModuleFormType = GetType(AdvantageFramework.Desktop.Presentation.AdvancedReportsForm)

                Case AdvantageFramework.Security.Modules.Desktop_ReportWriter_UserDefinedReports.ToString

                    ModuleFormType = GetType(AdvantageFramework.Desktop.Presentation.UserDefinedReportsForm)

                Case AdvantageFramework.Security.Modules.Security_Setup_UserDefinedReportAccess.ToString

                    ModuleFormType = GetType(AdvantageFramework.Security.Setup.Presentation.UserDefinedReportAccessForm)

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_ProductionSettings.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.ProjectManagement.Presentation.ProductionSettingsSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectSchedule_Settings.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.ProjectSchedule.Presentation.ProjectScheduleSettingsSetupForm)

                Case AdvantageFramework.Security.Modules.HelpCustomerService_Aboutadvantage.ToString

                    ModuleFormType = GetType(AdvantageFramework.WinForm.Presentation.AboutDialog)

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_ServiceFeeType.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Accounting.Presentation.ServiceFeeTypeSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_DeptTeam.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Accounting.Presentation.DepartmentTeamSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_ClientDiscount.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Accounting.Presentation.ClientDiscountSetupForm)

                Case AdvantageFramework.Security.Modules.Security_Setup_ClientPortalUser.ToString

                    ModuleFormType = GetType(AdvantageFramework.Security.Setup.Presentation.ClientPortalUserSetupForm)

                Case AdvantageFramework.Security.Modules.FinanceAccounting_ServiceFeeReconciliation.ToString

                    ModuleFormType = GetType(AdvantageFramework.FinanceAndAccounting.Presentation.ServiceFeeReconciliationForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Management_AgencyBuilder.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Management.Presentation.AgencyBuilderSettingsSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_General_StandardComments.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.General.Presentation.StandardCommentSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_General_MyObjectDefinition.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.General.Presentation.MyObjectDefinitionSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_General_Locations.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.General.Presentation.LocationSetupForm)

                Case AdvantageFramework.Security.Modules.Media_MediaPlanning.ToString

                    ModuleFormType = GetType(AdvantageFramework.Media.Presentation.MediaPlanningForm)

                Case AdvantageFramework.Security.Modules.Maintenance_General_UserDefinedReportCategory.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.General.Presentation.UserDefinedReportCategorySetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Media_Daypart.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Media.Presentation.DaypartSetupForm)

                Case AdvantageFramework.Security.Modules.GeneralLedger_ReportWriter_GLReportWriter.ToString

                    ModuleFormType = GetType(AdvantageFramework.GeneralLedger.ReportWriter.Presentation.GeneralLedgerReportForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Client_Affiliation.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Client.Presentation.AffiliationSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Client_Industry.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Client.Presentation.IndustrySetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Client_Specialty.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Client.Presentation.SpecialtySetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Client_Competition.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Client.Presentation.CompetitionSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Client_Rating.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Client.Presentation.RatingSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Client_Source.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Client.Presentation.SourceSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_General_Region.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.General.Presentation.RegionSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_General_CycleFrequency.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.General.Presentation.CycleSetupForm)

                Case AdvantageFramework.Security.Modules.FinanceAccounting_ServiceFeeReconciliation.ToString

                    ModuleFormType = GetType(AdvantageFramework.FinanceAndAccounting.Presentation.ServiceFeeReconciliationForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Client_AccountExecutive.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Client.Presentation.AccountExecutiveSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Client_Client.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Client.Presentation.ClientSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Client_ProductCategory.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Client.Presentation.ProductCategorySetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Client_ClientContact.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Client.Presentation.ClientContactSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Client_ClientMapping.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Client.Presentation.ClientMappingSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Billing_BillingSettings.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Billing.Presentation.BillingSettingsSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Management_AgencyClients.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Management.Presentation.AgencyClientSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Billing_InvoiceCategory.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Billing.Presentation.InvoiceCategorySetupForm)

                Case AdvantageFramework.Security.Modules.ProjectManagement_Campaigns.ToString

                    ModuleFormType = GetType(AdvantageFramework.ProjectManagement.Presentation.CampaignSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_AccountNumber.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Accounting.Presentation.AccountSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_TimeCategory.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Accounting.Presentation.IndirectCategorySetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_TimeCategoryType.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Accounting.Presentation.IndirectCategoryTypeSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_SalesTax.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Accounting.Presentation.SalesTaxSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_VendorContact.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Accounting.Presentation.VendorContactSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_EmployeeCategory.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Accounting.Presentation.EmployeeCategorySetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_EmployeeTitle.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Accounting.Presentation.EmployeeTitleSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_FunctionHeading.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Accounting.Presentation.FunctionHeadingSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_FiscalPeriod.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Accounting.Presentation.FiscalPeriodSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Media_AdSize.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Media.Presentation.AdSizeSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Media_InternetType.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Media.Presentation.InternetTypeSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Media_MediaMarket.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Media.Presentation.MediaMarketSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Media_OutofHomeType.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Media.Presentation.OutOfHomeTypeSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_EstimateTemplates.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.ProjectManagement.Presentation.EstimateTemplatesSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_Destination.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.ProjectManagement.Presentation.DestinationSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_ComplexityType.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.ProjectManagement.Presentation.ComplexityTypeSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_Blackplate.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.ProjectManagement.Presentation.BlackplateSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_AlertGroups.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.ProjectManagement.Presentation.AlertGroupSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobType.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.ProjectManagement.Presentation.JobTypeSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_PrintSpecStatus.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.ProjectManagement.Presentation.PrintSpecStatusSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_PromotionType.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.ProjectManagement.Presentation.PromotionTypeSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_ResourceType.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.ProjectManagement.Presentation.ResourceTypeSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_SalesClass.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Accounting.Presentation.SalesClassSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_CurrencyCodes.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Accounting.Presentation.CurrencyCodeSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Media_MediaSpecs.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Media.Presentation.MediaSpecificationsSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectSchedule_Task.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.ProjectSchedule.Presentation.TaskSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Media_Partner.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Media.Presentation.PartnerSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_ARStatement.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Accounting.Presentation.AccountsReceivableStatementSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobCustomTabNames.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.ProjectManagement.Presentation.JobCustomTabNamesEditDialog)

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_GeneralDescriptions.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Accounting.Presentation.GeneralDescriptionSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobComponentCustom1.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.ProjectManagement.Presentation.UserDefinedValueSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobComponentCustom2.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.ProjectManagement.Presentation.UserDefinedValueSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobComponentCustom3.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.ProjectManagement.Presentation.UserDefinedValueSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobComponentCustom4.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.ProjectManagement.Presentation.UserDefinedValueSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobComponentCustom5.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.ProjectManagement.Presentation.UserDefinedValueSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobCustom1.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.ProjectManagement.Presentation.UserDefinedValueSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobCustom2.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.ProjectManagement.Presentation.UserDefinedValueSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobCustom3.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.ProjectManagement.Presentation.UserDefinedValueSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobCustom4.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.ProjectManagement.Presentation.UserDefinedValueSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobCustom5.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.ProjectManagement.Presentation.UserDefinedValueSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_EmployeeUpdate.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Accounting.Presentation.EmployeeUpdateSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_Bank.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Accounting.Presentation.BankSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_General_WebsiteTypes.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.General.Presentation.WebsiteTypeSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_Employee.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Accounting.Presentation.EmployeeSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_SalesClassFormat.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.ProjectManagement.Presentation.SalesClassFormatSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_VendorTerms.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Accounting.Presentation.VendorTermSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Billing_RateFlagStructureEntry.ToString,
                        AdvantageFramework.Security.Modules.Maintenance_Billing_RateFlagStructure.ToString,
                        AdvantageFramework.Security.Modules.Maintenance_Billing_RateFlagEntry.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Billing.Presentation.RateFlagStructureSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_BillingCoop.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Accounting.Presentation.BillingCoopSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_Function.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Accounting.Presentation.FunctionSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_PaidTimeOff.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Accounting.Presentation.PTORuleSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_VendorPricing.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.ProjectManagement.Presentation.VendorPricingSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_AdNumber.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.ProjectManagement.Presentation.AdNumberSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Media_VendorRep.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Media.Presentation.VendorRepSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Media_Associate.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Media.Presentation.AssociateSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_Resource.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.ProjectManagement.Presentation.ResourceSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Management_OHAccounts.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Management.Presentation.OverheadAccountSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_General_Agency.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.General.Presentation.AgencySetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_PurchaseOrderApproval.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.ProjectManagement.Presentation.PurchaseOrderApprovalRuleSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Media_RateCardContract.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Media.Presentation.RateCardContractSetupForm)

                Case AdvantageFramework.Security.Modules.Employee_ExpenseReports.ToString

                    ModuleFormType = GetType(AdvantageFramework.Employee.Presentation.ExpenseReportSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_Office.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Accounting.Presentation.OfficeSetupForm)

                Case AdvantageFramework.Security.Modules.Desktop_DocumentManager.ToString

                    ModuleFormType = GetType(AdvantageFramework.Desktop.Presentation.DocumentManagerSetupForm)

                Case AdvantageFramework.Security.Modules.FinanceAccounting_AccountsPayable.ToString

                    ModuleFormType = GetType(AdvantageFramework.FinanceAndAccounting.Presentation.AccountsPayableForm)

                Case AdvantageFramework.Security.Modules.FinanceAccounting_EmployeeTimeForecast.ToString

                    ModuleFormType = GetType(AdvantageFramework.FinanceAndAccounting.Presentation.EmployeeTimeForecastForm)

                Case AdvantageFramework.Security.Modules.FinanceAccounting_EmployeeTimeForecastSettings.ToString

                    ModuleFormType = GetType(AdvantageFramework.FinanceAndAccounting.Presentation.EmployeeTimeForecastSettingsSetupForm)

                Case AdvantageFramework.Security.Modules.FinanceAccounting_EmployeeTimeForecastComparisonDashboard.ToString

                    ModuleFormType = GetType(AdvantageFramework.FinanceAndAccounting.Presentation.EmployeeTimeForecastComparisonDashboardForm)

                Case AdvantageFramework.Security.Modules.ProjectManagement_Reports_JobDetailAnalysisRTP.ToString

                    ModuleFormType = GetType(AdvantageFramework.Reporting.Presentation.JobDetailAnalysisInitialLoadingDialog)

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobTemplate.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.ProjectManagement.Presentation.JobTemplateSetupForm)

                Case AdvantageFramework.Security.Modules.FinanceAccounting_Imports_ChecksClearedImport.ToString

                    ModuleFormType = GetType(AdvantageFramework.Importing.Presentation.ImportForm)

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobSpecification.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.ProjectManagement.Presentation.JobSpecificationTemplateSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_AlertEventSettings.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.ProjectManagement.Presentation.AlertEventSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_Vendor.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Accounting.Presentation.VendorSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Client_ManagementLevel.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Client.Presentation.ManagementLevelSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobVersionTemplate.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.ProjectManagement.Presentation.JobVersionTemplateSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectSchedule_TaskTemplate.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.ProjectSchedule.Presentation.TaskTemplateSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_CreativeBriefTemplate.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.ProjectManagement.Presentation.CreativeBriefTemplateSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Media_PartnerAllocation.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Media.Presentation.PartnerAllocationSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_DestinationContact.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.ProjectManagement.Presentation.DestinationContactSetupForm)

                Case AdvantageFramework.Security.Modules.ProjectManagement_Reports_JobVersionRPT.ToString

                    ModuleFormType = GetType(AdvantageFramework.Reporting.Presentation.JobVersionReportsForm)

                Case AdvantageFramework.Security.Modules.Employee_ExpenseApproval.ToString

                    ModuleFormType = GetType(AdvantageFramework.Employee.Presentation.ExpenseApprovalSetupForm)

                Case AdvantageFramework.Security.Modules.FinanceAccounting_VoidInvoicesEnhanced.ToString

                    ModuleFormType = GetType(AdvantageFramework.FinanceAndAccounting.Presentation.VoidInvoicesForm)

                Case AdvantageFramework.Security.Modules.GeneralLedger_Maintenance_CrossReference.ToString

                    ModuleFormType = GetType(AdvantageFramework.GeneralLedger.Maintenance.Presentation.CrossReferenceSetupForm)

                Case AdvantageFramework.Security.Modules.GeneralLedger_Maintenance_AccountAllocation.ToString

                    ModuleFormType = GetType(AdvantageFramework.GeneralLedger.Maintenance.Presentation.AccountAllocationSetupForm)

                Case AdvantageFramework.Security.Modules.GeneralLedger_Maintenance_GeneralLedgerMapping.ToString

                    ModuleFormType = GetType(AdvantageFramework.GeneralLedger.Maintenance.Presentation.GeneralLedgerMappingSetupForm)

                Case AdvantageFramework.Security.Modules.GeneralLedger_ReportWriter_ReportingAcctGroup.ToString

                    ModuleFormType = GetType(AdvantageFramework.GeneralLedger.ReportWriter.Presentation.GLReportAccountGroupSetupForm)

                Case AdvantageFramework.Security.Modules.ProjectManagement_PurchaseOrders.ToString

                    ModuleFormType = GetType(AdvantageFramework.ProjectManagement.Presentation.PurchaseOrderSetupForm)

                Case AdvantageFramework.Security.Modules.GeneralLedger_Maintenance_PostingPeriods.ToString

                    ModuleFormType = GetType(AdvantageFramework.GeneralLedger.Maintenance.Presentation.PostingPeriodsSetupForm)

                Case AdvantageFramework.Security.Modules.FinanceAccounting_AccountsPayable_AP_ExpenseReport_Import.ToString

                    ModuleFormType = GetType(AdvantageFramework.Importing.Presentation.ImportForm)

                Case AdvantageFramework.Security.Modules.Security_SelectReports.ToString

                    ModuleFormType = GetType(AdvantageFramework.Security.Presentation.ReportSelectionSetupForm)

                Case AdvantageFramework.Security.Modules.FinanceAccounting_1099Processing.ToString

                    ModuleFormType = GetType(AdvantageFramework.FinanceAndAccounting.Presentation.IRS1099ProcessingForm)

                Case AdvantageFramework.Security.Modules.Billing_AdjustTime.ToString

                    ModuleFormType = GetType(AdvantageFramework.Billing.Presentation.AdjustTimeSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_VendorMapping.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Accounting.Presentation.VendorMappingSetupForm)

                Case AdvantageFramework.Security.Modules.Desktop_CRMCentral.ToString

                    ModuleFormType = GetType(AdvantageFramework.Desktop.Presentation.CRMCentralSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_General_IntegrationSettings.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.General.Presentation.IntegrationSettingsSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_General_AdvantageServicesSettings.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.General.Presentation.AdvantageServicesSettingsForm)

                Case AdvantageFramework.Security.Modules.GeneralLedger_Exports_GLDetailQueryExportRTP.ToString

                    ModuleFormType = GetType(AdvantageFramework.Exporting.Presentation.ExportForm)

                Case AdvantageFramework.Security.Modules.HelpCustomerService_ContactCustomerService.ToString

                    ModuleFormType = GetType(AdvantageFramework.Help.Presentation.ContactSupportDialog)

                Case AdvantageFramework.Security.Modules.FinanceAccounting_ClientInvoicesImport.ToString

                    ModuleFormType = GetType(AdvantageFramework.Importing.Presentation.ImportForm)

                    'Case AdvantageFramework.Security.Modules.Employee_Timesheet.ToString

                    '    ModuleFormType = GetType(AdvantageFramework.Employee.Presentation.EmployeeTimesheetForm)

                Case AdvantageFramework.Security.Modules.FinanceAccounting_ClientCashReceipts.ToString

                    ModuleFormType = GetType(AdvantageFramework.FinanceAndAccounting.Presentation.ClientCashReceiptForm)

                Case AdvantageFramework.Security.Modules.FinanceAccounting_ClientInvoices.ToString

                    ModuleFormType = GetType(AdvantageFramework.FinanceAndAccounting.Presentation.ClientInvoiceForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Client_ClientImport.ToString

                    ModuleFormType = GetType(AdvantageFramework.Importing.Presentation.ImportForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Client_DivisionImport.ToString

                    ModuleFormType = GetType(AdvantageFramework.Importing.Presentation.ImportForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Client_ProductImport.ToString

                    ModuleFormType = GetType(AdvantageFramework.Importing.Presentation.ImportForm)

                Case AdvantageFramework.Security.Modules.GeneralLedger_Maintenance_ChartofAccounts.ToString

                    ModuleFormType = GetType(AdvantageFramework.GeneralLedger.Maintenance.Presentation.ChartOfAccountsSetupForm)

                Case AdvantageFramework.Security.Modules.FinanceAccounting_CreateRecurringAP.ToString

                    ModuleFormType = GetType(AdvantageFramework.FinanceAndAccounting.Presentation.AccountsPayableRecurSetupForm)

                Case AdvantageFramework.Security.Modules.FinanceAccounting_PostRecurringAP.ToString

                    ModuleFormType = GetType(AdvantageFramework.FinanceAndAccounting.Presentation.AccountsPayableRecurPostForm)

                Case AdvantageFramework.Security.Modules.Billing_BillingCommandCenter.ToString

                    ModuleFormType = GetType(AdvantageFramework.Billing.Presentation.BillingCommandCenterForm)

                Case AdvantageFramework.Security.Modules.ProjectManagement_Reports_JobStatusRPT.ToString

                    ModuleFormType = GetType(AdvantageFramework.Reporting.Presentation.JobStatusReportsForm)

                Case AdvantageFramework.Security.Modules.Media_Reports_MediaSpecificationRPT.ToString

                    ModuleFormType = GetType(AdvantageFramework.Reporting.Presentation.MediaSpecificationReportsForm)

                Case AdvantageFramework.Security.Modules.FinanceAccounting_Reports_EmployeeUtilizationRTP.ToString

                    ModuleFormType = GetType(AdvantageFramework.Reporting.Presentation.EmployeeUtilizationReportsForm)

                Case AdvantageFramework.Security.Modules.Media_DigitalResults.ToString

                    ModuleFormType = GetType(AdvantageFramework.Media.Presentation.DigitalResultsForm)

                Case AdvantageFramework.Security.Modules.ProjectManagement_Reports_EstimatePrintingRTP.ToString()

                    ModuleFormType = GetType(AdvantageFramework.ProjectManagement.Reports.Presentation.EstimatePrintingSetupForm)

                Case AdvantageFramework.Security.Modules.FinanceAccounting_IncomeOnly.ToString

                    ModuleFormType = GetType(AdvantageFramework.FinanceAndAccounting.Presentation.IncomeOnlyForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_VendorServiceTax.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Accounting.Presentation.VendorServiceTaxSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_AvalaraProductMapping.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Accounting.Presentation.AvalaraProductMappingSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_AvalaraTaxCodeMaintenance.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Accounting.Presentation.AvalaraTaxSetupForm)

                Case AdvantageFramework.Security.Modules.Billing_AvalaraRepost.ToString

                    ModuleFormType = GetType(AdvantageFramework.Billing.Presentation.AvalaraRepostForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Client_ClientPO.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Client.Presentation.ClientPOSetupForm)

                Case AdvantageFramework.Security.Modules.Media_MediaManager.ToString

                    ModuleFormType = GetType(AdvantageFramework.Media.Presentation.MediaManagerForm)

                Case AdvantageFramework.Security.Modules.Maintenance_General_Documents.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.General.Presentation.DocumentsSetupForm)

                Case AdvantageFramework.Security.Modules.Billing_Reports_BillingReportsRTP.ToString

                    ModuleFormType = GetType(AdvantageFramework.Reporting.Presentation.BillingWorksheetInitialLoadingDialog)

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_CashReceiptPaymentType.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Accounting.Presentation.CashReceiptPaymentTypeSetupForm)

                Case AdvantageFramework.Security.Modules.Media_Reports_MediaCurrentStatusRTP.ToString

                    ModuleFormType = GetType(AdvantageFramework.Reporting.Presentation.MediaCurrentStatusNewInitialLoadingDialog)

                Case AdvantageFramework.Security.Modules.FinanceAccounting_Imports_PTOImport.ToString

                    ModuleFormType = GetType(AdvantageFramework.Importing.Presentation.ImportForm)

                Case AdvantageFramework.Security.Modules.FinanceAccounting_Reports_SalesJournalRTP.ToString

                    ModuleFormType = GetType(AdvantageFramework.Reporting.Presentation.SalesJournalInitialLoadingDialog)

                Case AdvantageFramework.Security.Modules.Maintenance_Client_Media_Percentages.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Client.Presentation.ClientMediaPercentagesSetupForm)

                Case AdvantageFramework.Security.Modules.GeneralLedger_Imports_ImportJournalEntries.ToString

                    ModuleFormType = GetType(AdvantageFramework.Importing.Presentation.ImportForm)

                Case AdvantageFramework.Security.Modules.GeneralLedger_Reports_GeneralLedgerReports.ToString

                    ModuleFormType = GetType(AdvantageFramework.GeneralLedger.Reports.Presentation.GeneralLedgerReportDialog)

                Case AdvantageFramework.Security.Modules.Maintenance_Client_Types.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Client.Presentation.ClientTypesSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Media_Buyer.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Media.Presentation.MediaBuyerSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Media_Demographic.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Media.Presentation.DemographicSetupForm)

                Case AdvantageFramework.Security.Modules.GeneralLedger_JournalEntriesBudgets_JournalEntries.ToString

                    ModuleFormType = GetType(AdvantageFramework.GeneralLedger.JournalEntriesBudgets.Presentation.JournalEntrySetupForm)

                'Case AdvantageFramework.Security.Modules.Media_MediaResearchTester.ToString

                '    ModuleFormType = GetType(AdvantageFramework.Media.Presentation.MediaResearchToolForm)

                Case AdvantageFramework.Security.Modules.GeneralLedger_Maintenance_GeneralLedgerMappingExport.ToString

                    ModuleFormType = GetType(AdvantageFramework.GeneralLedger.Maintenance.Views.GeneralLedgerMappingExportSetupForm)

                Case AdvantageFramework.Security.Modules.FinanceAccounting_Reports_PurchaseOrderReportRTP.ToString

                    ModuleFormType = GetType(AdvantageFramework.Reporting.Presentation.OpenPurchaseOrderDetailLoadingDialog)

                Case AdvantageFramework.Security.Modules.ProjectManagement_Reports_PurchaseOrderReportRTP.ToString

                    ModuleFormType = GetType(AdvantageFramework.Reporting.Presentation.OpenPurchaseOrderDetailLoadingDialog)

                Case AdvantageFramework.Security.Modules.Media_BroadcastResearchTool.ToString

                    ModuleFormType = GetType(AdvantageFramework.Media.Presentation.BroadcastResearchToolForm)

                Case AdvantageFramework.Security.Modules.Employee_TimesheetEnhanced.ToString

                    ModuleFormType = GetType(AdvantageFramework.Employee.Presentation.EmployeeTimesheetForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Media_InvoiceMatchingSettings.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Media.Presentation.InvoiceMatchingSettingsSetupForm)

                Case AdvantageFramework.Security.Modules.ProjectManagement_Reports_SprintRTP.ToString

                    ModuleFormType = GetType(AdvantageFramework.Reporting.Presentation.SprintReportsForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Media_CableNetwork.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Media.Presentation.CableNetworkSetupForm)

                Case AdvantageFramework.Security.Modules.FinanceAccounting_ClientLatePaymentFees.ToString

                    ModuleFormType = GetType(AdvantageFramework.FinanceAndAccounting.Presentation.ClientLatePaymentFeeForm)

                Case AdvantageFramework.Security.Modules.FinanceAccounting_Exports_VATTaxExport.ToString

                    ModuleFormType = GetType(AdvantageFramework.FinanceAndAccounting.Exports.VATExportForm)

                Case AdvantageFramework.Security.Modules.Media_ComscoreTester.ToString

                    ModuleFormType = GetType(AdvantageFramework.Media.Presentation.ComscoreToolForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Media_Channel.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Media.Presentation.MediaChannelSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Media_Tactic.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Media.Presentation.MediaTacticSetupForm)

                Case AdvantageFramework.Security.Modules.FinanceAccounting_Reports_CashManagementProductionRTP.ToString

                    ModuleFormType = GetType(AdvantageFramework.Reporting.Presentation.CashManagementProductionReports)

                Case AdvantageFramework.Security.Modules.FinanceAccounting_Reports_MonthEndReportsEnhancedRTP.ToString

                    ModuleFormType = GetType(AdvantageFramework.Reporting.Presentation.MonthEndMediaWIPInitialLoadingDialog)

                Case AdvantageFramework.Security.Modules.Maintenance_Media_NationalUniverse.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Media.Presentation.NationalUniverseSetupForm)

                Case AdvantageFramework.Security.Modules.GeneralLedger_Maintenance_Configuration.ToString

                    ModuleFormType = GetType(AdvantageFramework.GeneralLedger.Maintenance.Presentation.ConfigurationSetupForm)

                Case AdvantageFramework.Security.Modules.Media_DigitalCampaignManager.ToString

                    ModuleFormType = GetType(AdvantageFramework.Media.Presentation.DigitalCampaignManagerForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Media_MixRateTemplate.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Media.Presentation.MediaTemplateSetupForm)

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_QuickBooksSettings.ToString

                    ModuleFormType = GetType(AdvantageFramework.Maintenance.Accounting.Presentation.QuickbooksSetupForm)

                Case AdvantageFramework.Security.Modules.Media_Exports_BroadcastBuyInvoice.ToString

                    ModuleFormType = GetType(AdvantageFramework.Media.Exports.BroadcastBuyInvoiceExportForm)

                Case AdvantageFramework.Security.Modules.Media_Reports_BroadcastInvoiceRPT.ToString

                    ModuleFormType = GetType(AdvantageFramework.Reporting.Presentation.BroadcastInvoiceReportInitialLoadingDialog)

                Case AdvantageFramework.Security.Modules.Media_ComscorePrecache.ToString

                    ModuleFormType = GetType(AdvantageFramework.Media.Presentation.ComscorePrecacheForm)

                Case Else

                    ModuleFormType = Nothing

            End Select

            GetModuleFormType = ModuleFormType

        End Function
        Private Function ShowModuleForm(ByVal [Module] As AdvantageFramework.Security.Database.Views.ModuleView, ByRef DialogResult As System.Windows.Forms.DialogResult) As Boolean

            'objects
            Dim FormShowed As Boolean = True
            Dim Report As AdvantageFramework.Reporting.ReportTypes = AdvantageFramework.Reporting.ReportTypes.JobDetailAnalysisV1Summary
            Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing

            Select Case [Module].ModuleCode

                Case AdvantageFramework.Security.Modules.FinanceAccounting_PaymentManagerEnhanced.ToString

                    AdvantageFramework.FinanceAndAccounting.Presentation.PaymentManagerDialog.ShowFormDialog()

                Case AdvantageFramework.Security.Modules.GeneralLedger_Processing_UpdateToSummary.ToString

                    AdvantageFramework.GeneralLedger.Processing.Presentation.UpdateToSummaryForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Security_Setup_CDPSecurityGroup.ToString

                    AdvantageFramework.Security.Setup.Presentation.CDPSecurityGroupSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.GeneralLedger_Processing_PostRecurring.ToString

                    AdvantageFramework.GeneralLedger.JournalEntriesBudgets.Presentation.RecurringJournalEntryPostForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Security_PasswordPolicy.ToString

                    AdvantageFramework.Security.Presentation.PasswordPolicySetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Media_CanadaUniverse.ToString

                    AdvantageFramework.Maintenance.Media.Presentation.CanadaUniverseSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Media_MarketGroups.ToString

                    AdvantageFramework.Maintenance.Media.Presentation.MarketGroupSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.FinanceAccounting_RevenueResourcePlan.ToString

                    AdvantageFramework.FinanceAndAccounting.Presentation.RevenueResourcePlanSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_VendorInvoiceCategory.ToString

                    AdvantageFramework.Maintenance.Accounting.Presentation.VendorInvoiceCategorySetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Media_MediaBroadcastWorksheet.ToString

                    AdvantageFramework.Media.Presentation.MediaBroadcastWorksheetSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Client_ClientContactImport.ToString

                    AdvantageFramework.Importing.Presentation.ImportForm.ShowForm(AdvantageFramework.Importing.ImportType.ClientContact)

                Case AdvantageFramework.Security.Modules.Maintenance_General_VCCSettings.ToString

                    AdvantageFramework.Maintenance.General.Presentation.VCCSettingsSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_General_ContactTypes.ToString

                    AdvantageFramework.Maintenance.General.Presentation.ContactTypeSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.FinanceAccounting_Reports_ClientPLRTP.ToString

                    Report = Reporting.ReportTypes.ClientPLGrossIncomeSummaryByClientDivisionProduct

                    AdvantageFramework.Reporting.Presentation.ClientPLInitialLoadingDialog.ShowFormDialog(True, Report, ParameterDictionary)

                Case AdvantageFramework.Security.Modules.Billing_Reports_InvoicePrintingEnhancedRTP.ToString

                    AdvantageFramework.Billing.Reports.Presentation.InvoicePrintingSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.FinanceAccounting_AccountsPayable_AP_ExpenseReport_Import.ToString

                    AdvantageFramework.Importing.Presentation.ImportForm.ShowForm(AdvantageFramework.Importing.ImportType.AccountsPayable)

                Case AdvantageFramework.Security.Modules.Maintenance_Client_ClientMapping.ToString

                    AdvantageFramework.Maintenance.Client.Presentation.ClientMappingSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Billing_AdjustTime.ToString

                    AdvantageFramework.Billing.Presentation.AdjustTimeSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_General_CSIPreferredPartnerSettings.ToString

                    DialogResult = AdvantageFramework.Maintenance.General.Presentation.CSIPreferredPartnerSettingsDialog.ShowFormDialog()

                Case AdvantageFramework.Security.Modules.HelpCustomerService_ContactCustomerService.ToString

                    DialogResult = AdvantageFramework.Help.Presentation.ContactSupportDialog.ShowFormDialog()

                Case AdvantageFramework.Security.Modules.Maintenance_General_AdvantageServicesSettings.ToString

                    AdvantageFramework.Maintenance.General.Presentation.AdvantageServicesSettingsForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Security_Setup_Group.ToString

                    AdvantageFramework.Security.Setup.Presentation.GroupSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Security_Setup_ModuleAccess.ToString

                    AdvantageFramework.Security.Setup.Presentation.ModuleAccessForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Security_Setup_User.ToString

                    AdvantageFramework.Security.Setup.Presentation.UserSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Desktop_ReportWriter_DynamicReports.ToString

                    AdvantageFramework.Desktop.Presentation.DynamicReportsForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Security_Reports_SecurityReportRTP.ToString

                    AdvantageFramework.Security.Reports.Presentation.ReportSelectionForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Security_ChangePassword.ToString

                    DialogResult = AdvantageFramework.Security.Presentation.ChangePasswordDialog.ShowFormDialog(Me.Session, AdvantageFramework.Security.Presentation.ChangePasswordDialog.PasswordType.All)

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectSchedule_Phase.ToString

                    AdvantageFramework.Maintenance.ProjectSchedule.Presentation.PhaseSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectSchedule_Status.ToString

                    AdvantageFramework.Maintenance.ProjectSchedule.Presentation.StatusSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectSchedule_Role.ToString

                    AdvantageFramework.Maintenance.ProjectSchedule.Presentation.RoleSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Desktop_ReportWriter_AdvancedReportWriter.ToString

                    AdvantageFramework.Desktop.Presentation.AdvancedReportsForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Desktop_ReportWriter_UserDefinedReports.ToString

                    AdvantageFramework.Desktop.Presentation.UserDefinedReportsForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Security_Setup_UserDefinedReportAccess.ToString

                    AdvantageFramework.Security.Setup.Presentation.UserDefinedReportAccessForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_ProductionSettings.ToString

                    AdvantageFramework.Maintenance.ProjectManagement.Presentation.ProductionSettingsSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectSchedule_Settings.ToString

                    AdvantageFramework.Maintenance.ProjectSchedule.Presentation.ProjectScheduleSettingsSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.HelpCustomerService_Help.ToString

                    OpenHelpFile()

                Case AdvantageFramework.Security.Modules.HelpCustomerService_Aboutadvantage.ToString

                    DialogResult = AdvantageFramework.WinForm.Presentation.AboutDialog.ShowFormDialog()

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_ServiceFeeType.ToString

                    AdvantageFramework.Maintenance.Accounting.Presentation.ServiceFeeTypeSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_DeptTeam.ToString

                    AdvantageFramework.Maintenance.Accounting.Presentation.DepartmentTeamSetupForm.ShowForm()

                    'AdvantageFramework.Maintenance.Accounting.Views.DepartmentTeamSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_ClientDiscount.ToString

                    AdvantageFramework.Maintenance.Accounting.Presentation.ClientDiscountSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Security_Setup_ClientPortalUser.ToString

                    AdvantageFramework.Security.Setup.Presentation.ClientPortalUserSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.FinanceAccounting_ServiceFeeReconciliation.ToString

                    AdvantageFramework.FinanceAndAccounting.Presentation.ServiceFeeReconciliationForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Management_AgencyBuilder.ToString

                    AdvantageFramework.Maintenance.Management.Presentation.AgencyBuilderSettingsSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_General_StandardComments.ToString

                    AdvantageFramework.Maintenance.General.Presentation.StandardCommentSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_General_MyObjectDefinition.ToString

                    AdvantageFramework.Maintenance.General.Presentation.MyObjectDefinitionSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_General_Locations.ToString

                    AdvantageFramework.Maintenance.General.Presentation.LocationSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Media_MediaPlanning.ToString

                    AdvantageFramework.Media.Presentation.MediaPlanningForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_General_UserDefinedReportCategory.ToString

                    AdvantageFramework.Maintenance.General.Presentation.UserDefinedReportCategorySetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Media_Daypart.ToString

                    AdvantageFramework.Maintenance.Media.Presentation.DaypartSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.GeneralLedger_ReportWriter_GLReportWriter.ToString

                    AdvantageFramework.GeneralLedger.ReportWriter.Presentation.GeneralLedgerReportForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Client_Affiliation.ToString

                    AdvantageFramework.Maintenance.Client.Presentation.AffiliationSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Client_Industry.ToString

                    AdvantageFramework.Maintenance.Client.Presentation.IndustrySetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Client_Specialty.ToString

                    AdvantageFramework.Maintenance.Client.Presentation.SpecialtySetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Client_Competition.ToString

                    AdvantageFramework.Maintenance.Client.Presentation.CompetitionSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Client_Rating.ToString

                    AdvantageFramework.Maintenance.Client.Presentation.RatingSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Client_Source.ToString

                    AdvantageFramework.Maintenance.Client.Presentation.SourceSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_General_Region.ToString

                    AdvantageFramework.Maintenance.General.Presentation.RegionSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_General_CycleFrequency.ToString

                    AdvantageFramework.Maintenance.General.Presentation.CycleSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.FinanceAccounting_ServiceFeeReconciliation.ToString

                    AdvantageFramework.FinanceAndAccounting.Presentation.ServiceFeeReconciliationForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Client_AccountExecutive.ToString

                    AdvantageFramework.Maintenance.Client.Presentation.AccountExecutiveSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Client_Client.ToString

                    AdvantageFramework.Maintenance.Client.Presentation.ClientSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Client_ProductCategory.ToString

                    AdvantageFramework.Maintenance.Client.Presentation.ProductCategorySetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Client_ClientContact.ToString

                    AdvantageFramework.Maintenance.Client.Presentation.ClientContactSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Client_ClientMapping.ToString

                    AdvantageFramework.Maintenance.Client.Presentation.ClientMappingSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Billing_BillingSettings.ToString

                    AdvantageFramework.Maintenance.Billing.Presentation.BillingSettingsSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Management_AgencyClients.ToString

                    AdvantageFramework.Maintenance.Management.Presentation.AgencyClientSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Billing_InvoiceCategory.ToString

                    AdvantageFramework.Maintenance.Billing.Presentation.InvoiceCategorySetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.ProjectManagement_Campaigns.ToString

                    AdvantageFramework.ProjectManagement.Presentation.CampaignSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_AccountNumber.ToString

                    AdvantageFramework.Maintenance.Accounting.Presentation.AccountSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_TimeCategory.ToString

                    AdvantageFramework.Maintenance.Accounting.Presentation.IndirectCategorySetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_TimeCategoryType.ToString

                    AdvantageFramework.Maintenance.Accounting.Presentation.IndirectCategoryTypeSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_SalesTax.ToString

                    AdvantageFramework.Maintenance.Accounting.Presentation.SalesTaxSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_VendorContact.ToString

                    AdvantageFramework.Maintenance.Accounting.Presentation.VendorContactSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_EmployeeCategory.ToString

                    AdvantageFramework.Maintenance.Accounting.Presentation.EmployeeCategorySetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_EmployeeTitle.ToString

                    AdvantageFramework.Maintenance.Accounting.Presentation.EmployeeTitleSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_FunctionHeading.ToString

                    AdvantageFramework.Maintenance.Accounting.Presentation.FunctionHeadingSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_FiscalPeriod.ToString

                    AdvantageFramework.Maintenance.Accounting.Presentation.FiscalPeriodSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Media_AdSize.ToString

                    AdvantageFramework.Maintenance.Media.Presentation.AdSizeSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Media_InternetType.ToString

                    AdvantageFramework.Maintenance.Media.Presentation.InternetTypeSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Media_MediaMarket.ToString

                    AdvantageFramework.Maintenance.Media.Presentation.MediaMarketSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Media_OutofHomeType.ToString

                    AdvantageFramework.Maintenance.Media.Presentation.OutOfHomeTypeSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_EstimateTemplates.ToString

                    AdvantageFramework.Maintenance.ProjectManagement.Presentation.EstimateTemplatesSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_Destination.ToString

                    AdvantageFramework.Maintenance.ProjectManagement.Presentation.DestinationSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_ComplexityType.ToString

                    AdvantageFramework.Maintenance.ProjectManagement.Presentation.ComplexityTypeSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_Blackplate.ToString

                    AdvantageFramework.Maintenance.ProjectManagement.Presentation.BlackplateSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_AlertGroups.ToString

                    AdvantageFramework.Maintenance.ProjectManagement.Presentation.AlertGroupSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobType.ToString

                    AdvantageFramework.Maintenance.ProjectManagement.Presentation.JobTypeSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_PrintSpecStatus.ToString

                    AdvantageFramework.Maintenance.ProjectManagement.Presentation.PrintSpecStatusSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_PromotionType.ToString

                    AdvantageFramework.Maintenance.ProjectManagement.Presentation.PromotionTypeSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_ResourceType.ToString

                    AdvantageFramework.Maintenance.ProjectManagement.Presentation.ResourceTypeSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_SalesClass.ToString

                    AdvantageFramework.Maintenance.Accounting.Presentation.SalesClassSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_CurrencyCodes.ToString

                    AdvantageFramework.Maintenance.Accounting.Presentation.CurrencyCodeSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Media_MediaSpecs.ToString

                    AdvantageFramework.Maintenance.Media.Presentation.MediaSpecificationsSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectSchedule_Task.ToString

                    AdvantageFramework.Maintenance.ProjectSchedule.Presentation.TaskSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Media_Partner.ToString

                    AdvantageFramework.Maintenance.Media.Presentation.PartnerSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_ARStatement.ToString

                    AdvantageFramework.Maintenance.Accounting.Presentation.AccountsReceivableStatementSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobCustomTabNames.ToString

                    DialogResult = AdvantageFramework.Maintenance.ProjectManagement.Presentation.JobCustomTabNamesEditDialog.ShowFormDialog()

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_GeneralDescriptions.ToString

                    AdvantageFramework.Maintenance.Accounting.Presentation.GeneralDescriptionSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobComponentCustom1.ToString

                    AdvantageFramework.Maintenance.ProjectManagement.Presentation.UserDefinedValueSetupForm.ShowForm(AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_CMP_UDV1)

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobComponentCustom2.ToString

                    AdvantageFramework.Maintenance.ProjectManagement.Presentation.UserDefinedValueSetupForm.ShowForm(AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_CMP_UDV2)

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobComponentCustom3.ToString

                    AdvantageFramework.Maintenance.ProjectManagement.Presentation.UserDefinedValueSetupForm.ShowForm(AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_CMP_UDV3)

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobComponentCustom4.ToString

                    AdvantageFramework.Maintenance.ProjectManagement.Presentation.UserDefinedValueSetupForm.ShowForm(AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_CMP_UDV4)

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobComponentCustom5.ToString

                    AdvantageFramework.Maintenance.ProjectManagement.Presentation.UserDefinedValueSetupForm.ShowForm(AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_CMP_UDV5)

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobCustom1.ToString

                    AdvantageFramework.Maintenance.ProjectManagement.Presentation.UserDefinedValueSetupForm.ShowForm(AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_LOG_UDV1)

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobCustom2.ToString

                    AdvantageFramework.Maintenance.ProjectManagement.Presentation.UserDefinedValueSetupForm.ShowForm(AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_LOG_UDV2)

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobCustom3.ToString

                    AdvantageFramework.Maintenance.ProjectManagement.Presentation.UserDefinedValueSetupForm.ShowForm(AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_LOG_UDV3)

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobCustom4.ToString

                    AdvantageFramework.Maintenance.ProjectManagement.Presentation.UserDefinedValueSetupForm.ShowForm(AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_LOG_UDV4)

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobCustom5.ToString

                    AdvantageFramework.Maintenance.ProjectManagement.Presentation.UserDefinedValueSetupForm.ShowForm(AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_LOG_UDV5)

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_EmployeeUpdate.ToString

                    AdvantageFramework.Maintenance.Accounting.Presentation.EmployeeUpdateSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_Bank.ToString

                    AdvantageFramework.Maintenance.Accounting.Presentation.BankSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_General_WebsiteTypes.ToString

                    AdvantageFramework.Maintenance.General.Presentation.WebsiteTypeSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_Employee.ToString

                    AdvantageFramework.Maintenance.Accounting.Presentation.EmployeeSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_SalesClassFormat.ToString

                    AdvantageFramework.Maintenance.ProjectManagement.Presentation.SalesClassFormatSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_VendorTerms.ToString

                    AdvantageFramework.Maintenance.Accounting.Presentation.VendorTermSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Billing_RateFlagStructureEntry.ToString,
                        AdvantageFramework.Security.Modules.Maintenance_Billing_RateFlagStructure.ToString,
                        AdvantageFramework.Security.Modules.Maintenance_Billing_RateFlagEntry.ToString

                    AdvantageFramework.Maintenance.Billing.Presentation.RateFlagStructureSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_BillingCoop.ToString

                    AdvantageFramework.Maintenance.Accounting.Presentation.BillingCoopSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_Function.ToString

                    AdvantageFramework.Maintenance.Accounting.Presentation.FunctionSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_PaidTimeOff.ToString

                    AdvantageFramework.Maintenance.Accounting.Presentation.PTORuleSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_VendorPricing.ToString

                    AdvantageFramework.Maintenance.ProjectManagement.Presentation.VendorPricingSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_AdNumber.ToString

                    AdvantageFramework.Maintenance.ProjectManagement.Presentation.AdNumberSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Media_VendorRep.ToString

                    AdvantageFramework.Maintenance.Media.Presentation.VendorRepSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Media_Associate.ToString

                    AdvantageFramework.Maintenance.Media.Presentation.AssociateSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_Resource.ToString

                    AdvantageFramework.Maintenance.ProjectManagement.Presentation.ResourceSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Management_OHAccounts.ToString

                    AdvantageFramework.Maintenance.Management.Presentation.OverheadAccountSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_General_Agency.ToString

                    AdvantageFramework.Maintenance.General.Presentation.AgencySetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_PurchaseOrderApproval.ToString

                    AdvantageFramework.Maintenance.ProjectManagement.Presentation.PurchaseOrderApprovalRuleSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Media_RateCardContract.ToString

                    AdvantageFramework.Maintenance.Media.Presentation.RateCardContractSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Employee_ExpenseReports.ToString

                    AdvantageFramework.Employee.Presentation.ExpenseReportSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_Office.ToString

                    AdvantageFramework.Maintenance.Accounting.Presentation.OfficeSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Desktop_DocumentManager.ToString

                    AdvantageFramework.Desktop.Presentation.DocumentManagerSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.FinanceAccounting_AccountsPayable.ToString

                    AdvantageFramework.FinanceAndAccounting.Presentation.AccountsPayableForm.ShowForm()

                Case AdvantageFramework.Security.Modules.FinanceAccounting_EmployeeTimeForecast.ToString

                    AdvantageFramework.FinanceAndAccounting.Presentation.EmployeeTimeForecastForm.ShowForm()

                Case AdvantageFramework.Security.Modules.FinanceAccounting_EmployeeTimeForecastSettings.ToString

                    AdvantageFramework.FinanceAndAccounting.Presentation.EmployeeTimeForecastSettingsSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.FinanceAccounting_EmployeeTimeForecastComparisonDashboard.ToString

                    AdvantageFramework.FinanceAndAccounting.Presentation.EmployeeTimeForecastComparisonDashboardForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobTemplate.ToString

                    AdvantageFramework.Maintenance.ProjectManagement.Presentation.JobTemplateSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.ProjectManagement_Reports_JobDetailAnalysisRTP.ToString

                    AdvantageFramework.Reporting.Presentation.JobDetailAnalysisInitialLoadingDialog.ShowFormDialog(Report, ParameterDictionary, False)

                    'If AdvantageFramework.Reporting.Presentation.JobDetailAnalysisInitialLoadingDialog.ShowFormDialog(Report, ParameterDictionary, False) = System.Windows.Forms.DialogResult.OK Then

                    '    AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, Report, ParameterDictionary, Nothing, Nothing, Nothing, Nothing)

                    'End If

                Case AdvantageFramework.Security.Modules.FinanceAccounting_Imports_ChecksClearedImport.ToString

                    AdvantageFramework.Importing.Presentation.ImportForm.ShowForm(Importing.ImportType.ClearedChecks)

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobSpecification.ToString

                    AdvantageFramework.Maintenance.ProjectManagement.Presentation.JobSpecificationTemplateSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_AlertEventSettings.ToString

                    AdvantageFramework.Maintenance.ProjectManagement.Presentation.AlertEventSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_Vendor.ToString

                    AdvantageFramework.Maintenance.Accounting.Presentation.VendorSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Client_ManagementLevel.ToString

                    AdvantageFramework.Maintenance.Client.Presentation.ManagementLevelSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobVersionTemplate.ToString

                    AdvantageFramework.Maintenance.ProjectManagement.Presentation.JobVersionTemplateSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectSchedule_TaskTemplate.ToString

                    AdvantageFramework.Maintenance.ProjectSchedule.Presentation.TaskTemplateSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_CreativeBriefTemplate.ToString

                    AdvantageFramework.Maintenance.ProjectManagement.Presentation.CreativeBriefTemplateSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Media_PartnerAllocation.ToString

                    AdvantageFramework.Maintenance.Media.Presentation.PartnerAllocationSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_DestinationContact.ToString

                    AdvantageFramework.Maintenance.ProjectManagement.Presentation.DestinationContactSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.ProjectManagement_Reports_JobVersionRPT.ToString

                    AdvantageFramework.Reporting.Presentation.JobVersionReportsForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Employee_ExpenseApproval.ToString

                    AdvantageFramework.Employee.Presentation.ExpenseApprovalSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.FinanceAccounting_VoidInvoicesEnhanced.ToString

                    AdvantageFramework.FinanceAndAccounting.Presentation.VoidInvoicesForm.ShowForm()

                Case AdvantageFramework.Security.Modules.GeneralLedger_Maintenance_CrossReference.ToString

                    AdvantageFramework.GeneralLedger.Maintenance.Presentation.CrossReferenceSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.GeneralLedger_Maintenance_AccountAllocation.ToString

                    AdvantageFramework.GeneralLedger.Maintenance.Presentation.AccountAllocationSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.GeneralLedger_Maintenance_GeneralLedgerMapping.ToString

                    AdvantageFramework.GeneralLedger.Maintenance.Presentation.GeneralLedgerMappingSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.GeneralLedger_ReportWriter_ReportingAcctGroup.ToString

                    AdvantageFramework.GeneralLedger.ReportWriter.Presentation.GLReportAccountGroupSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.ProjectManagement_PurchaseOrders.ToString

                    AdvantageFramework.ProjectManagement.Presentation.PurchaseOrderSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.GeneralLedger_Maintenance_PostingPeriods.ToString

                    AdvantageFramework.GeneralLedger.Maintenance.Presentation.PostingPeriodsSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.GeneralLedger_Exports_GLDetailQueryExportRTP.ToString

                    AdvantageFramework.Exporting.Presentation.ExportForm.ShowForm(Exporting.ExportTypes.GeneralLedgerDetail, False, True, Nothing)

                Case AdvantageFramework.Security.Modules.Security_SelectReports.ToString

                    AdvantageFramework.Security.Presentation.ReportSelectionSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.FinanceAccounting_1099Processing.ToString

                    AdvantageFramework.FinanceAndAccounting.Presentation.IRS1099ProcessingForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_VendorMapping.ToString

                    AdvantageFramework.Maintenance.Accounting.Presentation.VendorMappingSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Desktop_CRMCentral.ToString

                    AdvantageFramework.Desktop.Presentation.CRMCentralSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_General_IntegrationSettings.ToString

                    AdvantageFramework.Maintenance.General.Presentation.IntegrationSettingsSetupForm.ShowForm()

                    'Case AdvantageFramework.Security.Modules.Employee_Timesheet.ToString

                    '    AdvantageFramework.Employee.Presentation.EmployeeTimesheetForm.ShowForm()

                Case AdvantageFramework.Security.Modules.FinanceAccounting_ClientCashReceipts.ToString

                    AdvantageFramework.FinanceAndAccounting.Presentation.ClientCashReceiptForm.ShowForm()

                Case AdvantageFramework.Security.Modules.FinanceAccounting_ClientInvoices.ToString

                    AdvantageFramework.FinanceAndAccounting.Presentation.ClientInvoiceForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Client_ClientImport.ToString

                    AdvantageFramework.Importing.Presentation.ImportForm.ShowForm(AdvantageFramework.Importing.ImportType.Client)

                Case AdvantageFramework.Security.Modules.Maintenance_Client_DivisionImport.ToString

                    AdvantageFramework.Importing.Presentation.ImportForm.ShowForm(AdvantageFramework.Importing.ImportType.Division)

                Case AdvantageFramework.Security.Modules.Maintenance_Client_ProductImport.ToString

                    AdvantageFramework.Importing.Presentation.ImportForm.ShowForm(AdvantageFramework.Importing.ImportType.Product)

                Case AdvantageFramework.Security.Modules.GeneralLedger_Maintenance_ChartofAccounts.ToString

                    AdvantageFramework.GeneralLedger.Maintenance.Presentation.ChartOfAccountsSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.FinanceAccounting_CreateRecurringAP.ToString

                    AdvantageFramework.FinanceAndAccounting.Presentation.AccountsPayableRecurSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.FinanceAccounting_PostRecurringAP.ToString

                    AdvantageFramework.FinanceAndAccounting.Presentation.AccountsPayableRecurPostForm.ShowForm()

                Case AdvantageFramework.Security.Modules.FinanceAccounting_ClientInvoicesImport.ToString

                    AdvantageFramework.Importing.Presentation.ImportForm.ShowForm(AdvantageFramework.Importing.ImportType.AccountsReceivable)

                Case AdvantageFramework.Security.Modules.Billing_BillingCommandCenter.ToString

                    AdvantageFramework.Billing.Presentation.BillingCommandCenterForm.ShowForm()

                Case AdvantageFramework.Security.Modules.ProjectManagement_Reports_JobStatusRPT.ToString

                    AdvantageFramework.Reporting.Presentation.JobStatusReportsForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Media_Reports_MediaSpecificationRPT.ToString

                    AdvantageFramework.Reporting.Presentation.MediaSpecificationReportsForm.ShowForm()

                Case AdvantageFramework.Security.Modules.FinanceAccounting_Reports_EmployeeUtilizationRTP.ToString

                    AdvantageFramework.Reporting.Presentation.EmployeeUtilizationReportsForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Media_DigitalResults.ToString

                    AdvantageFramework.Media.Presentation.DigitalResultsForm.ShowForm()

                Case AdvantageFramework.Security.Modules.ProjectManagement_Reports_EstimatePrintingRTP.ToString

                    AdvantageFramework.ProjectManagement.Reports.Presentation.EstimatePrintingSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.FinanceAccounting_IncomeOnly.ToString

                    AdvantageFramework.FinanceAndAccounting.Presentation.IncomeOnlyForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_VendorServiceTax.ToString

                    AdvantageFramework.Maintenance.Accounting.Presentation.VendorServiceTaxSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_AvalaraProductMapping.ToString

                    AdvantageFramework.Maintenance.Accounting.Presentation.AvalaraProductMappingSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_AvalaraTaxCodeMaintenance.ToString

                    AdvantageFramework.Maintenance.Accounting.Presentation.AvalaraTaxSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Billing_AvalaraRepost.ToString

                    AdvantageFramework.Billing.Presentation.AvalaraRepostForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Client_ClientPO.ToString

                    AdvantageFramework.Maintenance.Client.Presentation.ClientPOSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Media_MediaManager.ToString

                    AdvantageFramework.Media.Presentation.MediaManagerForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_General_Documents.ToString

                    AdvantageFramework.Maintenance.General.Presentation.DocumentsSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Billing_Reports_BillingReportsRTP.ToString

                    Report = Reporting.ReportTypes.BillingWorksheetProductionSummary

                    AdvantageFramework.Reporting.Presentation.BillingWorksheetInitialLoadingDialog.ShowFormDialog(Report, ParameterDictionary)

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_CashReceiptPaymentType.ToString

                    AdvantageFramework.Maintenance.Accounting.Presentation.CashReceiptPaymentTypeSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Media_Reports_MediaCurrentStatusRTP.ToString

                    AdvantageFramework.Reporting.Presentation.MediaCurrentStatusNewInitialLoadingDialog.ShowFormDialog(True, Report, ParameterDictionary)

                Case AdvantageFramework.Security.Modules.FinanceAccounting_Imports_PTOImport.ToString

                    AdvantageFramework.Importing.Presentation.ImportForm.ShowForm(Importing.ImportType.PTO)

                Case AdvantageFramework.Security.Modules.FinanceAccounting_Reports_SalesJournalRTP.ToString

                    AdvantageFramework.Reporting.Presentation.SalesJournalInitialLoadingDialog.ShowFormDialog(Nothing, True, Report, ParameterDictionary)

                Case AdvantageFramework.Security.Modules.Maintenance_Client_Media_Percentages.ToString

                    AdvantageFramework.Maintenance.Client.Presentation.ClientMediaPercentagesSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.GeneralLedger_Imports_ImportJournalEntries.ToString

                    AdvantageFramework.Importing.Presentation.ImportForm.ShowForm(Importing.ImportType.JournalEntry)

                Case AdvantageFramework.Security.Modules.GeneralLedger_Reports_GeneralLedgerReports.ToString

                    AdvantageFramework.GeneralLedger.Reports.Presentation.GeneralLedgerReportDialog.ShowFormDialog(ParameterDictionary, False)

                Case AdvantageFramework.Security.Modules.Maintenance_Client_Types.ToString

                    AdvantageFramework.Maintenance.Client.Presentation.ClientTypesSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Media_Buyer.ToString

                    AdvantageFramework.Maintenance.Media.Presentation.MediaBuyerSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Media_Demographic.ToString

                    AdvantageFramework.Maintenance.Media.Presentation.DemographicSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.GeneralLedger_JournalEntriesBudgets_JournalEntries.ToString

                    AdvantageFramework.GeneralLedger.JournalEntriesBudgets.Presentation.JournalEntrySetupForm.ShowForm()

                'Case AdvantageFramework.Security.Modules.Media_MediaResearchTester.ToString

                '    AdvantageFramework.Media.Presentation.MediaResearchToolForm.ShowForm()

                Case AdvantageFramework.Security.Modules.GeneralLedger_Maintenance_GeneralLedgerMappingExport.ToString

                    AdvantageFramework.GeneralLedger.Maintenance.Views.GeneralLedgerMappingExportSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.FinanceAccounting_Reports_PurchaseOrderReportRTP.ToString

                    AdvantageFramework.Reporting.Presentation.OpenPurchaseOrderDetailLoadingDialog.ShowFormDialog(Nothing, True, Report, ParameterDictionary)

                Case AdvantageFramework.Security.Modules.ProjectManagement_Reports_PurchaseOrderReportRTP.ToString

                    AdvantageFramework.Reporting.Presentation.OpenPurchaseOrderDetailLoadingDialog.ShowFormDialog(Nothing, True, Report, ParameterDictionary)

                Case AdvantageFramework.Security.Modules.Media_BroadcastResearchTool.ToString

                    AdvantageFramework.Media.Presentation.BroadcastResearchToolForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Employee_TimesheetEnhanced.ToString

                    AdvantageFramework.Employee.Presentation.EmployeeTimesheetForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Media_InvoiceMatchingSettings.ToString

                    AdvantageFramework.Maintenance.Media.Presentation.InvoiceMatchingSettingsSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.ProjectManagement_Reports_SprintRTP.ToString

                    AdvantageFramework.Reporting.Presentation.SprintReportsForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Media_CableNetwork.ToString

                    AdvantageFramework.Maintenance.Media.Presentation.CableNetworkSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Employee_Reports_DirectTimeActivityRTP.ToString

                    Report = Reporting.ReportTypes.DirectTimebyClientSummary

                    AdvantageFramework.Reporting.Presentation.DirectTimeInitialLoadingDialog.ShowFormDialog(Nothing, True, Report, ParameterDictionary)

                Case AdvantageFramework.Security.Modules.Employee_Reports_HoursWorkedRTP.ToString

                    'Report = Reporting.ReportTypes.DirectTimebyClientSummary

                    AdvantageFramework.Reporting.Presentation.DirectIndirectTimeInitialLoadingDialog.ShowFormDialog(Nothing, True, Report, ParameterDictionary)

                Case AdvantageFramework.Security.Modules.FinanceAccounting_ClientLatePaymentFees.ToString

                    AdvantageFramework.FinanceAndAccounting.Presentation.ClientLatePaymentFeeForm.ShowForm()

                Case AdvantageFramework.Security.Modules.FinanceAccounting_Exports_VATTaxExport.ToString

                    AdvantageFramework.FinanceAndAccounting.Exports.VATExportForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Media_ComscoreTester.ToString

                    AdvantageFramework.Media.Presentation.ComscoreToolForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Media_Channel.ToString

                    AdvantageFramework.Maintenance.Media.Presentation.MediaChannelSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Media_Tactic.ToString

                    AdvantageFramework.Maintenance.Media.Presentation.MediaTacticSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.FinanceAccounting_Reports_CashManagementProductionRTP.ToString

                    AdvantageFramework.Reporting.Presentation.CashManagementProductionReports.ShowFormDialog(Report, ParameterDictionary, False)

                Case AdvantageFramework.Security.Modules.FinanceAccounting_Reports_MonthEndReportsEnhancedRTP.ToString

                    AdvantageFramework.Reporting.Presentation.MonthEndMediaWIPInitialLoadingDialog.ShowFormDialog(Nothing, True, Report, ParameterDictionary)

                Case AdvantageFramework.Security.Modules.Maintenance_Media_NationalUniverse.ToString

                    AdvantageFramework.Maintenance.Media.Presentation.NationalUniverseSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.GeneralLedger_Maintenance_Configuration.ToString

                    AdvantageFramework.GeneralLedger.Maintenance.Presentation.ConfigurationSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Media_DigitalCampaignManager.ToString

                    AdvantageFramework.Media.Presentation.DigitalCampaignManagerForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Media_MixRateTemplate.ToString

                    AdvantageFramework.Maintenance.Media.Presentation.MediaTemplateSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Maintenance_Accounting_QuickBooksSettings.ToString

                    AdvantageFramework.Maintenance.Accounting.Presentation.QuickbooksSetupForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Media_Exports_BroadcastBuyInvoice.ToString

                    AdvantageFramework.Media.Exports.BroadcastBuyInvoiceExportForm.ShowForm()

                Case AdvantageFramework.Security.Modules.Media_Reports_BroadcastInvoiceRPT.ToString

                    AdvantageFramework.Reporting.Presentation.BroadcastInvoiceReportInitialLoadingDialog.ShowFormDialog(ParameterDictionary)

                Case AdvantageFramework.Security.Modules.Media_ComscorePrecache.ToString

                    AdvantageFramework.Media.Presentation.ComscorePrecacheForm.ShowForm()

                Case Else

                    FormShowed = False

            End Select

            ShowModuleForm = FormShowed

        End Function
        Protected Friend Function OpenModule(ByVal [Module] As AdvantageFramework.Security.Database.Views.ModuleView) As System.Windows.Forms.DialogResult

            'objects
            Dim DialogResult As System.Windows.Forms.DialogResult = System.Windows.Forms.DialogResult.None
            Dim ModuleType As System.Type = Nothing
            Dim FoundForm As Boolean = False

            If AdvantageFramework.Security.LicenseKey.CheckForValidUserLicenseKey(Me.Session, AdvantageFramework.Security.GetMACAddress, "", "") Then

                If _IsOpeningModule = False Then

                    _IsOpeningModule = True

                    If [Module] IsNot Nothing Then

                        ModuleType = GetModuleFormType([Module])

                        If CheckFormOpenForm(ModuleType, [Module].ModuleCode) = False Then

                            FoundForm = ShowModuleForm([Module], DialogResult)

                            If Me.Session.MenuHWND <> 0 AndAlso FoundForm = False Then

                                SendMessage(Me.Session.MenuHWND, WM_USER + 60, [Module].ModuleID, 0)

                                SetForegroundWindow(Me.Session.MenuHWND)

                            End If

                        End If

                    End If

                    _IsOpeningModule = False

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("The license information for this user\application\machine is no longer valid.")

                System.Windows.Forms.Application.Exit()

            End If

            OpenModule = DialogResult

        End Function
        Public Sub SetupProgressBar(ByVal MinimumValue As Integer, ByVal MaximumValue As Integer, ByVal StartValue As Integer)

            RaiseEvent SetupProgressBarEvent(MinimumValue, MaximumValue, StartValue)

        End Sub
        Public Sub SetProgressBarValue(ByVal CurrentValue As Integer)

            RaiseEvent SetProgressBarValueEvent(CurrentValue)

        End Sub
        Public Sub CloseProgressBar()

            RaiseEvent CloseProgressBarEvent()

        End Sub
        Public Sub OpenHelpFile()

            'objects
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim WebvantageURL As String = Nothing
            Dim DirectoryInfo As System.IO.DirectoryInfo = Nothing
            Dim ParentDirectoryInfo As System.IO.DirectoryInfo = Nothing
            Dim HelpFileLoaded As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                    If Agency IsNot Nothing Then

                        If Agency.IsASP.GetValueOrDefault(0) = 1 Then

                            AdvantageFramework.WinForm.MessageBox.Show("For full access to Advantage Help, open the browser on your machine and go to https://www.advantagehosted.com/webvantage/flashhelp/advantage.htm")

                        End If

                        Try

                            WebvantageURL = AdvantageFramework.Agency.LoadMachineAccessSettings(AdvantageFramework.Agency.LocalMachineAccess.WebvantageURL)

                        Catch ex As Exception
                            WebvantageURL = Nothing
                        End Try

                        If String.IsNullOrWhiteSpace(WebvantageURL) = False Then

                            Try

                                WebvantageURL = AdvantageFramework.StringUtilities.AppendTrailingCharacter(WebvantageURL, "/") & "FlashHelp/advantage.htm"

                            Catch ex As Exception
                                WebvantageURL = Nothing
                            End Try

                        ElseIf String.IsNullOrWhiteSpace(Agency.WebvantageURL) = False Then

                            Try

                                WebvantageURL = AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.WebvantageURL, "/") & "FlashHelp/advantage.htm"

                            Catch ex As Exception
                                WebvantageURL = Nothing
                            End Try

                        End If

                        If String.IsNullOrWhiteSpace(WebvantageURL) = False Then

                            Try

                                AdvantageFramework.WinForm.Presentation.BrowserForm.ShowForm(WebvantageURL)

                                HelpFileLoaded = True

                            Catch ex As Exception
                                HelpFileLoaded = False
                            End Try

                        End If

                    End If

                    If HelpFileLoaded = False Then

                        DirectoryInfo = My.Computer.FileSystem.GetDirectoryInfo(My.Application.Info.DirectoryPath)

                        If DirectoryInfo IsNot Nothing Then

                            ParentDirectoryInfo = DirectoryInfo.Parent

                            If ParentDirectoryInfo IsNot Nothing Then

                                If ParentDirectoryInfo.GetDirectories.Any(Function(DirInfo) DirInfo.Name = "FlashHelp") Then

                                    If My.Computer.FileSystem.FileExists(AdvantageFramework.StringUtilities.AppendTrailingCharacter(ParentDirectoryInfo.FullName, "\") & "FlashHelp\advantage.htm") Then

                                        System.Diagnostics.Process.Start(AdvantageFramework.StringUtilities.AppendTrailingCharacter(ParentDirectoryInfo.FullName, "\") & "FlashHelp\advantage.htm")

                                        HelpFileLoaded = True

                                    End If

                                End If

                            End If

                        End If

                    End If

                End Using

            Catch ex As Exception
                HelpFileLoaded = False
            End Try

            If HelpFileLoaded = False Then

                AdvantageFramework.Navigation.ShowMessageBox("Trouble opening up help documentation.")

            End If

        End Sub
        Public Sub SetMessage(ByVal Message As String)

            RaiseEvent SetMessageEvent(Message)

        End Sub
        Public Sub ClearMessage()

            RaiseEvent ClearMessageEvent()

        End Sub
        Public Sub StartProgressBarMarquee(ByVal Message As String)

            RaiseEvent StartProgressBarMarqueeEvent(Message)

        End Sub
        Public Function CheckFormOpenForm(ByVal FormType As System.Type, Optional ModuleCode As String = "") As Boolean

            'objects
            Dim IsFormOpen As Boolean = False

            If FormType IsNot Nothing Then

                For Each MdiChildForm In Me.MdiChildren

                    If FormType Is MdiChildForm.GetType Then

                        If FormType Is GetType(AdvantageFramework.Exporting.Presentation.ExportForm) Then

                            Select Case ModuleCode

                                Case AdvantageFramework.Security.Modules.GeneralLedger_Exports_GLDetailQueryExportRTP.ToString

                                    If CType(MdiChildForm, AdvantageFramework.Exporting.Presentation.ExportForm).ExportType = Exporting.ExportTypes.GeneralLedgerDetail Then

                                        IsFormOpen = True
                                        MdiChildForm.Activate()
                                        Exit For

                                    End If

                            End Select

                        ElseIf FormType Is GetType(AdvantageFramework.Maintenance.ProjectManagement.Presentation.UserDefinedValueSetupForm) Then

                            Select Case ModuleCode

                                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobComponentCustom1.ToString

                                    If CType(MdiChildForm, AdvantageFramework.Maintenance.ProjectManagement.Presentation.UserDefinedValueSetupForm).UserDefinedLabelTable = Database.Entities.UserDefinedLabelTables.JOB_CMP_UDV1 Then

                                        IsFormOpen = True
                                        MdiChildForm.Activate()
                                        Exit For

                                    End If

                                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobComponentCustom2.ToString

                                    If CType(MdiChildForm, AdvantageFramework.Maintenance.ProjectManagement.Presentation.UserDefinedValueSetupForm).UserDefinedLabelTable = Database.Entities.UserDefinedLabelTables.JOB_CMP_UDV2 Then

                                        IsFormOpen = True
                                        MdiChildForm.Activate()
                                        Exit For

                                    End If

                                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobComponentCustom3.ToString

                                    If CType(MdiChildForm, AdvantageFramework.Maintenance.ProjectManagement.Presentation.UserDefinedValueSetupForm).UserDefinedLabelTable = Database.Entities.UserDefinedLabelTables.JOB_CMP_UDV3 Then

                                        IsFormOpen = True
                                        MdiChildForm.Activate()
                                        Exit For

                                    End If

                                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobComponentCustom4.ToString

                                    If CType(MdiChildForm, AdvantageFramework.Maintenance.ProjectManagement.Presentation.UserDefinedValueSetupForm).UserDefinedLabelTable = Database.Entities.UserDefinedLabelTables.JOB_CMP_UDV4 Then

                                        IsFormOpen = True
                                        MdiChildForm.Activate()
                                        Exit For

                                    End If

                                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobComponentCustom5.ToString

                                    If CType(MdiChildForm, AdvantageFramework.Maintenance.ProjectManagement.Presentation.UserDefinedValueSetupForm).UserDefinedLabelTable = Database.Entities.UserDefinedLabelTables.JOB_CMP_UDV5 Then

                                        IsFormOpen = True
                                        MdiChildForm.Activate()
                                        Exit For

                                    End If

                                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobCustom1.ToString

                                    If CType(MdiChildForm, AdvantageFramework.Maintenance.ProjectManagement.Presentation.UserDefinedValueSetupForm).UserDefinedLabelTable = Database.Entities.UserDefinedLabelTables.JOB_LOG_UDV1 Then

                                        IsFormOpen = True
                                        MdiChildForm.Activate()
                                        Exit For

                                    End If

                                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobCustom2.ToString

                                    If CType(MdiChildForm, AdvantageFramework.Maintenance.ProjectManagement.Presentation.UserDefinedValueSetupForm).UserDefinedLabelTable = Database.Entities.UserDefinedLabelTables.JOB_LOG_UDV2 Then

                                        IsFormOpen = True
                                        MdiChildForm.Activate()
                                        Exit For

                                    End If

                                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobCustom3.ToString

                                    If CType(MdiChildForm, AdvantageFramework.Maintenance.ProjectManagement.Presentation.UserDefinedValueSetupForm).UserDefinedLabelTable = Database.Entities.UserDefinedLabelTables.JOB_LOG_UDV3 Then

                                        IsFormOpen = True
                                        MdiChildForm.Activate()
                                        Exit For

                                    End If

                                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobCustom4.ToString

                                    If CType(MdiChildForm, AdvantageFramework.Maintenance.ProjectManagement.Presentation.UserDefinedValueSetupForm).UserDefinedLabelTable = Database.Entities.UserDefinedLabelTables.JOB_LOG_UDV4 Then

                                        IsFormOpen = True
                                        MdiChildForm.Activate()
                                        Exit For

                                    End If

                                Case AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobCustom5.ToString

                                    If CType(MdiChildForm, AdvantageFramework.Maintenance.ProjectManagement.Presentation.UserDefinedValueSetupForm).UserDefinedLabelTable = Database.Entities.UserDefinedLabelTables.JOB_LOG_UDV5 Then

                                        IsFormOpen = True
                                        MdiChildForm.Activate()
                                        Exit For

                                    End If

                            End Select

                        ElseIf FormType Is GetType(AdvantageFramework.Importing.Presentation.ImportForm) Then

                            Select Case ModuleCode

                                Case AdvantageFramework.Security.Modules.FinanceAccounting_Imports_ChecksClearedImport.ToString

                                    If CType(MdiChildForm, AdvantageFramework.Importing.Presentation.ImportForm).ImportType = AdvantageFramework.Importing.ImportType.ClearedChecks Then

                                        IsFormOpen = True
                                        MdiChildForm.Activate()
                                        Exit For

                                    End If

                                Case AdvantageFramework.Security.Modules.FinanceAccounting_AccountsPayable_AP_ExpenseReport_Import.ToString

                                    If CType(MdiChildForm, AdvantageFramework.Importing.Presentation.ImportForm).ImportType = AdvantageFramework.Importing.ImportType.AccountsPayable Then

                                        IsFormOpen = True
                                        MdiChildForm.Activate()
                                        Exit For

                                    End If

                                Case AdvantageFramework.Security.Modules.FinanceAccounting_ClientInvoicesImport.ToString

                                    If CType(MdiChildForm, AdvantageFramework.Importing.Presentation.ImportForm).ImportType = AdvantageFramework.Importing.ImportType.AccountsReceivable Then

                                        IsFormOpen = True
                                        MdiChildForm.Activate()
                                        Exit For

                                    End If

                                Case AdvantageFramework.Security.Modules.Maintenance_Client_ClientContactImport.ToString

                                    If CType(MdiChildForm, AdvantageFramework.Importing.Presentation.ImportForm).ImportType = AdvantageFramework.Importing.ImportType.ClientContact Then

                                        IsFormOpen = True
                                        MdiChildForm.Activate()
                                        Exit For

                                    End If

                                Case AdvantageFramework.Security.Modules.Maintenance_Client_ClientImport.ToString

                                    If CType(MdiChildForm, AdvantageFramework.Importing.Presentation.ImportForm).ImportType = AdvantageFramework.Importing.ImportType.Client Then

                                        IsFormOpen = True
                                        MdiChildForm.Activate()
                                        Exit For

                                    End If

                                Case AdvantageFramework.Security.Modules.Maintenance_Client_DivisionImport.ToString

                                    If CType(MdiChildForm, AdvantageFramework.Importing.Presentation.ImportForm).ImportType = AdvantageFramework.Importing.ImportType.Division Then

                                        IsFormOpen = True
                                        MdiChildForm.Activate()
                                        Exit For

                                    End If

                                Case AdvantageFramework.Security.Modules.Maintenance_Client_ProductImport.ToString

                                    If CType(MdiChildForm, AdvantageFramework.Importing.Presentation.ImportForm).ImportType = AdvantageFramework.Importing.ImportType.Product Then

                                        IsFormOpen = True
                                        MdiChildForm.Activate()
                                        Exit For

                                    End If

                                Case AdvantageFramework.Security.Modules.Media_DigitalResults.ToString

                                    If CType(MdiChildForm, AdvantageFramework.Importing.Presentation.ImportForm).ImportType = AdvantageFramework.Importing.ImportType.DigitalResults Then

                                        IsFormOpen = True
                                        MdiChildForm.Activate()
                                        Exit For

                                    End If

                                Case AdvantageFramework.Security.Modules.FinanceAccounting_Imports_PTOImport.ToString

                                    If CType(MdiChildForm, AdvantageFramework.Importing.Presentation.ImportForm).ImportType = AdvantageFramework.Importing.ImportType.PTO Then

                                        IsFormOpen = True
                                        MdiChildForm.Activate()
                                        Exit For

                                    End If

                                Case AdvantageFramework.Security.Modules.GeneralLedger_Imports_ImportJournalEntries.ToString

                                    If CType(MdiChildForm, AdvantageFramework.Importing.Presentation.ImportForm).ImportType = AdvantageFramework.Importing.ImportType.JournalEntry Then

                                        IsFormOpen = True
                                        MdiChildForm.Activate()
                                        Exit For

                                    End If

                            End Select

                        Else

                            IsFormOpen = True
                            MdiChildForm.Activate()
                            Exit For

                        End If

                    End If

                Next

            End If

            CheckFormOpenForm = IsFormOpen

        End Function
        Protected Overrides Sub OnSizeChanged(e As EventArgs)

            If Me.IsHandleCreated AndAlso Me.IsDisposed = False Then

                Me.BeginInvoke(Sub()

                                   MyBase.OnSizeChanged(e)

                               End Sub)

            End If

        End Sub
        Public Function IsAnyDialogFormOpen() As Boolean

            'objects
            Dim DialogFormIsOpen As Boolean = False

            If Me.OwnedForms IsNot Nothing Then

                For Each Form In Me.OwnedForms

                    If Form IsNot Nothing AndAlso Form.Modal Then

                        DialogFormIsOpen = True
                        Exit For

                    End If

                Next

            End If

            IsAnyDialogFormOpen = DialogFormIsOpen

        End Function

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

        Private Sub MDIApplicationForm_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

            RemoveHandler AdvantageFramework.Navigation.ShowMessageBoxEvent, AddressOf AdvantageFramework.WinForm.MessageBox.Show
            RemoveHandler AdvantageFramework.Navigation.ShowLoginEvent, AddressOf AdvantageFramework.Security.Presentation.LoginDialog.ShowFormDialog
            RemoveHandler AdvantageFramework.Navigation.ShowChangePasswordEvent, AddressOf AdvantageFramework.Database.Presentation.ChangePasswordDialog.ShowFormDialog
            RemoveHandler AdvantageFramework.Navigation.ShowErrorEvent, AddressOf AdvantageFramework.Error.ShowFormDialog

        End Sub
        Private Sub MDIApplicationForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

            'objects
            Dim ClosingMessage As String = ""

            If e.CloseReason = Windows.Forms.CloseReason.UserClosing Then

                ClosingMessage = "Are you sure you want to exit?"

                Try

                    For Each MDIForm In Me.MdiChildren

                        If TypeOf MDIForm Is AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm Then

                            If DirectCast(MDIForm, AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm).ShowUnsavedChangesOnFormClosing AndAlso
                                    DirectCast(MDIForm, AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm).CheckUserEntryChangedSetting Then

                                ClosingMessage = "You have unsaved changes. Do you want to exit without saving?"

                                Exit For

                            End If

                        ElseIf TypeOf MDIForm Is AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseForm Then

                            If DirectCast(MDIForm, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseForm).ShowUnsavedChangesOnFormClosing AndAlso
                                    DirectCast(MDIForm, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseForm).CheckUserEntryChangedSetting Then

                                ClosingMessage = "You have unsaved changes. Do you want to exit without saving?"

                                Exit For

                            End If

                        End If

                    Next

                    For Each MDIForm In System.Windows.Forms.Application.OpenForms.OfType(Of System.Windows.Forms.Form).ToArray

                        If TypeOf MDIForm Is AdvantageFramework.WinForm.Presentation.BaseForms.BaseRibbonForm Then

                            If DirectCast(MDIForm, AdvantageFramework.WinForm.Presentation.BaseForms.BaseRibbonForm).ShowUnsavedChangesOnFormClosing AndAlso
                                    DirectCast(MDIForm, AdvantageFramework.WinForm.Presentation.BaseForms.BaseRibbonForm).CheckUserEntryChangedSetting Then

                                ClosingMessage = "You have unsaved changes. Do you want to exit without saving?"

                                Exit For

                            End If

                        ElseIf TypeOf MDIForm Is AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseRibbonForm Then

                            If DirectCast(MDIForm, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseRibbonForm).ShowUnsavedChangesOnFormClosing AndAlso
                                    DirectCast(MDIForm, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseRibbonForm).CheckUserEntryChangedSetting Then

                                ClosingMessage = "You have unsaved changes. Do you want to exit without saving?"

                                Exit For

                            End If

                        End If

                    Next

                Catch ex As Exception

                End Try

                If AdvantageFramework.WinForm.MessageBox.Show(ClosingMessage, MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    _IsFormClosing = True

                Else

                    e.Cancel = True

                End If

            Else

                _IsFormClosing = True

            End If

            If _IsFormClosing Then

                Try

                    For Each MDIForm In System.Windows.Forms.Application.OpenForms.OfType(Of System.Windows.Forms.Form).ToArray

                        If Not MDIForm.IsDisposed AndAlso TypeOf MDIForm Is AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm Then

                            If DirectCast(MDIForm, AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm).ChildForms IsNot Nothing AndAlso
                                    DirectCast(MDIForm, AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm).ChildForms.Count > 0 Then

                                While DirectCast(MDIForm, AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm).ChildForms.Count > 0

                                    DirectCast(DirectCast(MDIForm, AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm).ChildForms(0), AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).ShowUnsavedChangesOnFormClosing = False
                                    DirectCast(MDIForm, AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm).ChildForms(0).Close()

                                End While

                                MDIForm.Close()

                            End If

                        ElseIf Not MDIForm.IsDisposed AndAlso TypeOf MDIForm Is AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseForm Then

                            If DirectCast(MDIForm, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseForm).ChildForms IsNot Nothing AndAlso
                                    DirectCast(MDIForm, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseForm).ChildForms.Count > 0 Then

                                While DirectCast(MDIForm, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseForm).ChildForms.Count > 0

                                    DirectCast(DirectCast(MDIForm, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseForm).ChildForms(0), AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).ShowUnsavedChangesOnFormClosing = False
                                    DirectCast(MDIForm, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseForm).ChildForms(0).Close()

                                End While

                                MDIForm.Close()

                            End If

                        End If

                    Next

                Catch ex As Exception

                End Try

                e.Cancel = False

                RaiseEvent SaveSettingsEvent()

                ShutDown()

            End If

        End Sub
        Private Sub MDIApplicationForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            AddHandler AdvantageFramework.Navigation.ShowMessageBoxEvent, AddressOf AdvantageFramework.WinForm.MessageBox.Show
            AddHandler AdvantageFramework.Navigation.ShowLoginEvent, AddressOf AdvantageFramework.Security.Presentation.LoginDialog.ShowFormDialog
            AddHandler AdvantageFramework.Navigation.ShowChangePasswordEvent, AddressOf AdvantageFramework.Database.Presentation.ChangePasswordDialog.ShowFormDialog
            AddHandler AdvantageFramework.Navigation.ShowErrorEvent, AddressOf AdvantageFramework.Error.ShowFormDialog

            Me.DoubleBuffered = True

            Try

                Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(System.Diagnostics.Process.GetCurrentProcess.MainModule.FileName)

            Catch ex As Exception

                Me.Icon = AdvantageFramework.My.Resources.AdvantageIcon

            End Try

            DevExpress.Utils.TouchHelpers.TouchKeyboardSupport.EnableTouchKeyboard = False
            DevExpress.XtraReports.Configuration.Settings.Default.UserDesignerOptions.DataBindingMode = DevExpress.XtraReports.UI.DataBindingMode.Bindings
            DevExpress.XtraReports.Configuration.Settings.Default.UserDesignerOptions.ConvertBindingsToExpressions = DevExpress.XtraReports.UI.PromptBoolean.False
            DevExpress.XtraEditors.WindowsFormsSettings.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False

            ButtonItemSystem_Exit.Image = AdvantageFramework.My.Resources.ExitImage
            ButtonItemMainRibbon_Help.Image = AdvantageFramework.My.Resources.HelpImage
            ButtonItemMainRibbon_ShowAndHide.Image = AdvantageFramework.My.Resources.UpImage

            RibbonControlForm_MainRibbon.SelectedRibbonTabItem = RibbonTabItemMainRibbon_File

            If _HasToLogIn AndAlso Me.DesignMode = False Then

                If _UseSecurityLogin Then

                    If AdvantageFramework.Navigation.ShowLogin(_Application, Nothing, _Session, "", "", False, "", False) = AdvantageFramework.WinForm.MessageBox.DialogResults.Cancel Then

                        System.Windows.Forms.Application.Exit()

                    Else

                        RaiseEvent RunDatabaseScriptCheckEvent()

                    End If

                End If

            End If

        End Sub
        Private Sub MDIApplicationForm_MdiChildActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MdiChildActivate

            If Me.ActiveMdiChild IsNot Nothing Then

                If Me.ActiveMdiChild.WindowState <> Windows.Forms.FormWindowState.Maximized Then

                    Me.ActiveMdiChild.WindowState = System.Windows.Forms.FormWindowState.Maximized

                End If

                For Each TabItem In TabStripForm_MDIChildren.Tabs.OfType(Of DevComponents.DotNetBar.TabItem).ToList

                    If TabItem.AttachedControl Is Me.ActiveMdiChild Then

                        TabItem.CloseButtonVisible = True
                        TabStripForm_MDIChildren.CloseButtonVisible = True

                        Exit For

                    End If

                Next

            End If

        End Sub
        Private Sub MDIApplicationForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            TabStripForm_MDIChildren.Visible = False

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemSystem_Exit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemSystem_Exit.Click

            Me.Close()

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

            OpenModule(AdvantageFramework.Security.Modules.HelpCustomerService_Aboutadvantage)

        End Sub
        Private Sub TabStripForm_MDIChildren_Click(sender As Object, e As EventArgs) Handles TabStripForm_MDIChildren.Click

            If TabStripForm_MDIChildren.SelectedTab IsNot Nothing Then

                If TabStripForm_MDIChildren.SelectedTab.AttachedControl IsNot Nothing Then

                    If TabStripForm_MDIChildren.SelectedTab.AttachedControl.GetType.BaseType = GetType(AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm) Then

                        If DirectCast(TabStripForm_MDIChildren.SelectedTab.AttachedControl, AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm).Enabled = False Then

                            DirectCast(TabStripForm_MDIChildren.SelectedTab.AttachedControl, AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm).ActivateEnabledChildForm()

                        End If

                    ElseIf TabStripForm_MDIChildren.SelectedTab.AttachedControl.GetType.BaseType = GetType(AdvantageFramework.WinForm.Presentation.BaseForms.BaseRibbonForm) Then

                        If DirectCast(TabStripForm_MDIChildren.SelectedTab.AttachedControl, AdvantageFramework.WinForm.Presentation.BaseForms.BaseRibbonForm).Enabled = False Then

                            DirectCast(TabStripForm_MDIChildren.SelectedTab.AttachedControl, AdvantageFramework.WinForm.Presentation.BaseForms.BaseRibbonForm).ActivateEnabledChildForm()

                        End If

                    ElseIf TabStripForm_MDIChildren.SelectedTab.AttachedControl.GetType.BaseType = GetType(AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseForm) Then

                        If DirectCast(TabStripForm_MDIChildren.SelectedTab.AttachedControl, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseForm).Enabled = False Then

                            DirectCast(TabStripForm_MDIChildren.SelectedTab.AttachedControl, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseForm).ActivateEnabledChildForm()

                        End If

                    ElseIf TabStripForm_MDIChildren.SelectedTab.AttachedControl.GetType.BaseType = GetType(AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseRibbonForm) Then

                        If DirectCast(TabStripForm_MDIChildren.SelectedTab.AttachedControl, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseRibbonForm).Enabled = False Then

                            DirectCast(TabStripForm_MDIChildren.SelectedTab.AttachedControl, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseRibbonForm).ActivateEnabledChildForm()

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub TabStripForm_MDIChildren_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles TabStripForm_MDIChildren.SelectedTabChanged

            If e.NewTab IsNot Nothing AndAlso e.NewTab.AttachedControl IsNot Nothing Then

                If e.NewTab.AttachedControl.GetType.BaseType = GetType(AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm) Then

                    With DirectCast(e.NewTab.AttachedControl, AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm)

                        .WindowState = Windows.Forms.FormWindowState.Maximized
                        .Enabled = .SecurityEnabled

                    End With

                ElseIf e.NewTab.AttachedControl.GetType.BaseType = GetType(AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseForm) Then

                    With DirectCast(e.NewTab.AttachedControl, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseForm)

                        .WindowState = Windows.Forms.FormWindowState.Maximized
                        .Enabled = .SecurityEnabled

                    End With

                End If

            End If

        End Sub
        Private Sub TabStripForm_MDIChildren_SelectedTabChanging(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles TabStripForm_MDIChildren.SelectedTabChanging

            'objects
            Dim IsOldTabClosing As Boolean = True

            If e.NewTab IsNot Nothing AndAlso e.NewTab.AttachedControl IsNot Nothing Then

                If e.OldTab IsNot Nothing AndAlso e.OldTab.AttachedControl IsNot Nothing Then

                    If e.OldTab.AttachedControl.GetType.BaseType = GetType(AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm) Then

                        IsOldTabClosing = DirectCast(e.OldTab.AttachedControl, AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm).IsFormClosing

                    ElseIf e.OldTab.AttachedControl.GetType.BaseType = GetType(AdvantageFramework.WinForm.Presentation.BaseForms.BaseRibbonForm) Then

                        IsOldTabClosing = DirectCast(e.OldTab.AttachedControl, AdvantageFramework.WinForm.Presentation.BaseForms.BaseRibbonForm).IsFormClosing

                    ElseIf e.OldTab.AttachedControl.GetType.BaseType = GetType(AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseForm) Then

                        IsOldTabClosing = DirectCast(e.OldTab.AttachedControl, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseForm).IsFormClosing

                    ElseIf e.OldTab.AttachedControl.GetType.BaseType = GetType(AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseRibbonForm) Then

                        IsOldTabClosing = DirectCast(e.OldTab.AttachedControl, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseRibbonForm).IsFormClosing

                    End If

                End If

                If e.NewTab.AttachedControl.GetType.BaseType = GetType(AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm) Then

                    If DirectCast(e.NewTab.AttachedControl, AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm).Enabled = False Then

                        e.Cancel = Not IsOldTabClosing

                        If e.Cancel Then

                            DirectCast(e.NewTab.AttachedControl, AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm).ActivateEnabledChildForm()

                        Else

                            DirectCast(e.NewTab.AttachedControl, AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm).SecurityEnabled = False
                            DirectCast(e.NewTab.AttachedControl, AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm).Enabled = True

                        End If

                    End If

                ElseIf e.NewTab.AttachedControl.GetType.BaseType = GetType(AdvantageFramework.WinForm.Presentation.BaseForms.BaseRibbonForm) Then

                    If DirectCast(e.NewTab.AttachedControl, AdvantageFramework.WinForm.Presentation.BaseForms.BaseRibbonForm).Enabled = False Then

                        e.Cancel = Not IsOldTabClosing

                        DirectCast(e.NewTab.AttachedControl, AdvantageFramework.WinForm.Presentation.BaseForms.BaseRibbonForm).ActivateEnabledChildForm()

                    End If

                ElseIf e.NewTab.AttachedControl.GetType.BaseType = GetType(AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseForm) Then

                    If DirectCast(e.NewTab.AttachedControl, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseForm).Enabled = False Then

                        e.Cancel = Not IsOldTabClosing

                        If e.Cancel Then

                            DirectCast(e.NewTab.AttachedControl, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseForm).ActivateEnabledChildForm()

                        Else

                            DirectCast(e.NewTab.AttachedControl, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseForm).SecurityEnabled = False
                            DirectCast(e.NewTab.AttachedControl, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseForm).Enabled = True

                        End If

                    End If

                ElseIf e.NewTab.AttachedControl.GetType.BaseType = GetType(AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseRibbonForm) Then

                    If DirectCast(e.NewTab.AttachedControl, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseRibbonForm).Enabled = False Then

                        e.Cancel = Not IsOldTabClosing

                        DirectCast(e.NewTab.AttachedControl, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseRibbonForm).ActivateEnabledChildForm()

                    End If

                End If

            End If

        End Sub
        Private Sub TabStripForm_MDIChildren_PreRenderTabItem(sender As Object, e As DevComponents.DotNetBar.RenderTabItemEventArgs) Handles TabStripForm_MDIChildren.PreRenderTabItem

            If e.TabItem.AttachedControl.GetType.Equals(GetType(AdvantageFramework.Media.Presentation.MediaPlanEditForm)) Then

                If Not String.IsNullOrWhiteSpace(DirectCast(e.TabItem.AttachedControl, AdvantageFramework.Media.Presentation.MediaPlanEditForm).TabText) Then

                    e.TabItem.Text = DirectCast(e.TabItem.AttachedControl, AdvantageFramework.Media.Presentation.MediaPlanEditForm).TabText

                End If

            ElseIf e.TabItem.AttachedControl.GetType.Equals(GetType(AdvantageFramework.Media.Presentation.MediaBroadcastWorksheetMarketDetailForm)) Then

                If Not String.IsNullOrWhiteSpace(DirectCast(e.TabItem.AttachedControl, AdvantageFramework.Media.Presentation.MediaBroadcastWorksheetMarketDetailForm).TabText) Then

                    e.TabItem.Text = DirectCast(e.TabItem.AttachedControl, AdvantageFramework.Media.Presentation.MediaBroadcastWorksheetMarketDetailForm).TabText

                End If

            End If

        End Sub
        Private Sub TabStripForm_MDIChildren_TabItemOpen(sender As Object, e As EventArgs) Handles TabStripForm_MDIChildren.TabItemOpen

            If TypeOf sender Is DevComponents.DotNetBar.TabItem Then

                CType(sender, DevComponents.DotNetBar.TabItem).CloseButtonVisible = False

            End If

            TabStripForm_MDIChildren.CloseButtonVisible = False

        End Sub

#End Region

#End Region

    End Class

End Namespace

