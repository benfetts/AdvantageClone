Public Class AdvantageTestForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.AdvTreeEmployee_MenuItems.NodeStyle = Me.ElementStyle1
        Me.AdvTreeProjectManagement_MenuItems.NodeStyle = Me.ElementStyle1
        Me.AdvTreeMedia_MenuItems.NodeStyle = Me.ElementStyle1
        Me.AdvTreeBilling_MenuItems.NodeStyle = Me.ElementStyle1
        Me.AdvTreeFinanceAndAccounting_MenuItems.NodeStyle = Me.ElementStyle1
        Me.AdvTreeGeneralLedger_MenuItems.NodeStyle = Me.ElementStyle1
        Me.AdvTreeMaintenance_MenuItems.NodeStyle = Me.ElementStyle1
        Me.AdvTreeSecurity_MenuItems.NodeStyle = Me.ElementStyle1
        Me.AdvTreeHelpCustomerService_MenuItems.NodeStyle = Me.ElementStyle1

        If My.Application.CommandLineArgs.Count = 0 Then

            _UseSecurityLogin = True

        Else

            _UseSecurityLogin = False

        End If

        _Application = AdvantageFramework.Security.Application.Advantage

    End Sub
    Private Sub LoadApplicationMenu()

        'objects
        Dim SuperTabItem As DevComponents.DotNetBar.SuperTabItem = Nothing
        Dim AdvTree As DevComponents.AdvTree.AdvTree = Nothing
        Dim [Module] As AdvantageFramework.Security.Database.Views.ModuleView = Nothing
        Dim ModulesList As Generic.List(Of AdvantageFramework.Security.Database.Views.ModuleView) = Nothing

        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            ModulesList = AdvantageFramework.Security.Database.Procedures.ModuleView.Load(SecurityDbContext).ToList

            For Each [Module] In ModulesList.Where(Function(ModView) ModView.ApplicationID = _Session.Application AndAlso ModView.ParentModuleID Is Nothing AndAlso
                                                                     ModView.IsInactive = False AndAlso ModView.IsMenuItem = True).OrderBy(Function(ModView) ModView.SortOrder)

                Try

                    SuperTabItem = SuperTabControlHome_Menu.Tabs("SuperTabItemMenu_" & [Module].ModuleDescription.Replace(" and ", " And ").Replace(" ", "").Replace("/", "") & "Tab")

                    AdvTree = SuperTabItem.AttachedControl.Controls.OfType(Of DevComponents.AdvTree.AdvTree).First()

                Catch ex As Exception

                End Try

                If SuperTabItem IsNot Nothing AndAlso AdvTree IsNot Nothing Then

                    LoadApplicationSubMenu(_Session.Application, [Module], Nothing, AdvTree, ModulesList)

                End If

            Next

        End Using

    End Sub
    Private Sub LoadApplicationSubMenu(ByVal ApplicationID As Integer, ByVal ModuleView As AdvantageFramework.Security.Database.Views.ModuleView, ByRef ParentNode As DevComponents.AdvTree.Node, ByVal AdvTree As DevComponents.AdvTree.AdvTree, ByVal ModulesList As Generic.List(Of AdvantageFramework.Security.Database.Views.ModuleView))

        'objects
        Dim Node As DevComponents.AdvTree.Node = Nothing
        Dim SubModule As AdvantageFramework.Security.Database.Views.ModuleView = Nothing
        Dim GroupStyle As DevComponents.DotNetBar.ElementStyle = Nothing
        Dim JobCustomDescription As String = ""

        Try

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

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

                            LoadApplicationSubMenu(ApplicationID, SubModule, Node, AdvTree, ModulesList)

                        End If

                    Else

                        JobCustomDescription = ""

                        If SubModule.ModuleCode = AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobCustom1.ToString OrElse
                                SubModule.ModuleCode = AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobCustom2.ToString OrElse
                                SubModule.ModuleCode = AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobCustom3.ToString OrElse
                                SubModule.ModuleCode = AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobCustom4.ToString OrElse
                                SubModule.ModuleCode = AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobCustom5.ToString Then

                            Try

                                JobCustomDescription = SecurityDbContext.Database.SqlQuery(Of String)(String.Format("SELECT ISNULL(USER_LABEL, '') FROM dbo.UDV_LABEL WHERE UDV_TABLE_NAME = 'JOB_LOG_UDV{0}'", SubModule.ModuleCode.Substring(SubModule.ModuleCode.Length - 1))).First

                            Catch ex As Exception
                                JobCustomDescription = ""
                            End Try

                        ElseIf SubModule.ModuleCode = AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobComponentCustom1.ToString OrElse
                                SubModule.ModuleCode = AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobComponentCustom2.ToString OrElse
                                SubModule.ModuleCode = AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobComponentCustom3.ToString OrElse
                                SubModule.ModuleCode = AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobComponentCustom4.ToString OrElse
                                SubModule.ModuleCode = AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_JobComponentCustom5.ToString Then

                            Try

                                JobCustomDescription = SecurityDbContext.Database.SqlQuery(Of String)(String.Format("SELECT ISNULL(USER_LABEL, '') FROM dbo.UDV_LABEL WHERE UDV_TABLE_NAME = 'JOB_CMP_UDV{0}'", SubModule.ModuleCode.Substring(SubModule.ModuleCode.Length - 1))).First

                            Catch ex As Exception
                                JobCustomDescription = ""
                            End Try

                        End If

                        If JobCustomDescription Is Nothing OrElse JobCustomDescription = "" Then

                            Node = New DevComponents.AdvTree.Node(SubModule.ModuleDescription)

                        Else

                            Node = New DevComponents.AdvTree.Node(JobCustomDescription)

                        End If

                        Node.Name = "Node" & SubModule.ModuleID
                        Node.Image = AdvantageFramework.Security.LoadImageForModule(SubModule)
                        Node.Tag = SubModule.ModuleID

                        AddHandler Node.NodeClick, AddressOf ModuleNode_NodeClick

                        If ParentNode Is Nothing Then

                            AdvTree.Nodes.Add(Node)

                        Else

                            ParentNode.Nodes.Add(Node)

                        End If

                    End If

                Next

            End Using

        Catch ex As Exception
            Node = Nothing
        End Try

    End Sub
    Private Sub ModuleNode_NodeClick(ByVal sender As Object, ByVal e As DevComponents.AdvTree.TreeNodeMouseEventArgs)

        If e.Button = Windows.Forms.MouseButtons.Left Then

            If sender IsNot Nothing AndAlso
                TypeOf sender Is DevComponents.AdvTree.Node Then

                If IsNumeric(DirectCast(sender, DevComponents.AdvTree.Node).Tag) Then

                    Office2007StartButtonMainRibbon_Home.Expanded = False

                    System.Windows.Forms.Application.DoEvents()

                    OpenModule(CInt(DirectCast(sender, DevComponents.AdvTree.Node).Tag))

                    System.Windows.Forms.Application.DoEvents()

                Else

                    If DirectCast(sender, DevComponents.AdvTree.Node).Nodes.Count > 0 Then

                        DirectCast(sender, DevComponents.AdvTree.Node).Expanded = Not DirectCast(sender, DevComponents.AdvTree.Node).Expanded

                    End If

                End If

            End If

        End If

    End Sub

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

    Private Sub AdvantageSecurityForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Dim CSCORE_CLIENT_ID As String = AdvantageFramework.Security.Encryption.RijndaelSimpleDecrypt("3n/Pmp5puwSkEsukNmantJbpU5ckXXFE5ZPRf0tJaIhqFJzZeKtk87+qeuD5/n5L")
        'CSCORE_CLIENT_ID = AdvantageFramework.Security.Encryption.Encrypt(CSCORE_CLIENT_ID)
        'Dim CSCORE_CLIENT_SECRET As String = AdvantageFramework.Security.Encryption.RijndaelSimpleDecrypt("wlFV4bXqHb+szD/iVlgccLaQQ0FWweFMhrzz6tBf3ygjDh3V3iTs7YVguZu/j+Is")
        'CSCORE_CLIENT_SECRET = AdvantageFramework.Security.Encryption.Encrypt(CSCORE_CLIENT_SECRET)

        'Dim PW1 As String = AdvantageFramework.Security.Encryption.Encrypt("sysadm")
        'PW1 = AdvantageFramework.Security.Encryption.Decrypt(PW1)
        'Dim PW2 As String = AdvantageFramework.Security.Encryption.Encrypt("ok")
        'PW2 = AdvantageFramework.Security.Encryption.Decrypt(PW2)

        If _UseSecurityLogin = False Then

            LoadStartUpInformation(My.Application.CommandLineArgs)

        End If

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

    End Sub
    Private Sub AdvantageSecurityForm_MdiChildActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MdiChildActivate

        'If Me.MdiChildren.Count = 1 AndAlso TypeOf Me.MdiChildren(0) Is AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm AndAlso _
        '        DirectCast(Me.MdiChildren(0), AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm).IsFormClosing Then

        '    DockSite9.Visible = True

        'End If

    End Sub
    Private Sub AdvantageSecurityForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        DockSite9.Visible = False

        AdvTreeBilling_MenuItems.Refresh()
        AdvTreeDesktop_MenuItems.Refresh()
        AdvTreeEmployee_MenuItems.Refresh()
        AdvTreeFinanceAndAccounting_MenuItems.Refresh()
        AdvTreeGeneralLedger_MenuItems.Refresh()
        AdvTreeHelpCustomerService_MenuItems.Refresh()
        AdvTreeMaintenance_MenuItems.Refresh()
        AdvTreeMedia_MenuItems.Refresh()
        AdvTreeProjectManagement_MenuItems.Refresh()
        AdvTreeSecurity_MenuItems.Refresh()

        Me.Refresh()

        'Dim Delimiters As Integer = 0
        'Dim FileText As String = ""
        'Dim Message As String = ""

        'For Each FileInfo In My.Computer.FileSystem.GetDirectoryInfo("C:\LMO - (01_04_2012 12_39_49)").GetFiles

        '    FileText = FileInfo.OpenText.ReadToEnd()
        '    Delimiters = 0

        '    For Each Line In Split(FileText, vbCrLf)

        '        If Delimiters = 0 Then

        '            Delimiters = Split(Line, "|").Length

        '        Else

        '            If Delimiters <> Split(Line, "|").Length AndAlso Line <> "" Then

        '                Message &= vbCrLf & FileInfo.Name
        '                Exit For

        '            End If

        '        End If

        '    Next

        'Next

        'Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing

        'Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

        '    For Each Alert In AdvantageFramework.Database.Procedures.Alert.Load(DbContext)

        '        MsgBox(Alert.AlertAssignmentID)

        '    Next

        'End Using

        'AdvantageFramework.WinForm.MessageBox.Show(Message)

        'AdvantageFramework.GeneralLedger.ReportWriter.Presentation.ReportWriterForm.ShowForm()

        'AdvantageFramework.Maintenance.ProjectManagement.Presentation.UserDefinedValueSetupForm.ShowForm(AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_CMP_UDV1)
        'AdvantageFramework.Maintenance.ProjectManagement.Presentation.UserDefinedValueSetupForm.ShowForm(AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_CMP_UDV2)
        'AdvantageFramework.Maintenance.ProjectManagement.Presentation.UserDefinedValueSetupForm.ShowForm(AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_CMP_UDV3)
        'AdvantageFramework.Maintenance.ProjectManagement.Presentation.UserDefinedValueSetupForm.ShowForm(AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_CMP_UDV4)
        'AdvantageFramework.Maintenance.ProjectManagement.Presentation.UserDefinedValueSetupForm.ShowForm(AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_CMP_UDV5)

        'AdvantageFramework.Maintenance.ProjectManagement.Presentation.UserDefinedValueSetupForm.ShowForm(AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_LOG_UDV1)
        'AdvantageFramework.Maintenance.ProjectManagement.Presentation.UserDefinedValueSetupForm.ShowForm(AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_LOG_UDV2)
        'AdvantageFramework.Maintenance.ProjectManagement.Presentation.UserDefinedValueSetupForm.ShowForm(AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_LOG_UDV3)
        'AdvantageFramework.Maintenance.ProjectManagement.Presentation.UserDefinedValueSetupForm.ShowForm(AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_LOG_UDV4)
        'AdvantageFramework.Maintenance.ProjectManagement.Presentation.UserDefinedValueSetupForm.ShowForm(AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_LOG_UDV5)

        'AdvantageFramework.Maintenance.ProjectManagement.Presentation.EstimateTemplatesSetupForm.ShowForm()

        'AdvantageFramework.Reporting.Presentation.DynamicReportForm.ShowForm()

        'AdvantageFramework.Maintenance.ProjectManagement.Presentation.AlertGroupSetupForm.ShowForm()

        'AdvantageFramework.Maintenance.Media.Presentation.OutOfHomeTypeSetupForm.ShowForm()

        'AdvantageFramework.FinanceAndAccounting.Presentation.ServiceFeeReconciliationForm.ShowForm()

        'AdvantageFramework.FinanceAndAccounting.Presentation.AccountsPayableForm.ShowForm()

        'AdvantageFramework.Maintenance.Media.Presentation.MediaSpecificationsSetupForm.ShowForm()

        'AdvantageFramework.Maintenance.Media.Presentation.AdSizeSetupForm.ShowForm()

        'AdvantageFramework.Maintenance.Presentation.FiscalPeriodSetupForm.ShowForm()

        'AdvantageFramework.Maintenance.Presentation.FunctionHeadingSetupForm.ShowForm()

        'AdvantageFramework.Maintenance.Presentation.GeneralDescriptionSetupForm.ShowForm()

        'AdvantageFramework.Maintenance.Accounting.Presentation.EmployeeUpdateSetupForm.ShowForm()

        'AdvantageFramework.Maintenance.Accounting.Presentation.CurrencyCodeSetupForm.ShowForm()

        'AdvantageFramework.Maintenance.Accounting.Presentation.EmployeeTitleSetupForm.ShowForm()

        'AdvantageFramework.Maintenance.Accounting.Presentation.EmployeeCategorySetupForm.ShowForm()

        'AdvantageFramework.Maintenance.Accounting.Presentation.DepartmentTeamSetupForm.ShowForm()

        'AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(_Session, AdvantageFramework.Reporting.ReportTypes.SecurityPermission, Nothing)

        'AdvantageFramework.Maintenance.Presentation.PhaseSetupForm.ShowForm()

        'AdvantageFramework.Maintenance.Presentation.RoleSetupForm.ShowForm()

        'AdvantageFramework.Maintenance.Presentation.ServiceFeeTypeSetupForm.ShowForm()

        'AdvantageFramework.Maintenance.Client.Presentation.ClientSetupForm.ShowForm()

        'AdvantageFramework.Maintenance.Client.Presentation.DivisionSetupForm.ShowForm()

        'AdvantageFramework.Maintenance.Client.Presentation.ProductSetupForm.ShowForm()

        'AdvantageFramework.Maintenance.Client.Presentation.ProductCategorySetupForm.ShowForm()

        'AdvantageFramework.Maintenance.Presentation.StatusSetupForm.ShowForm()

        'AdvantageFramework.Maintenance.Presentation.ProjectScheduleSettingsSetupForm.ShowForm()

        'AdvantageFramework.Maintenance.Presentation.ProductionSettingsSetupForm.ShowForm()

        'AdvantageFramework.Maintenance.Presentation.BillingSettingsSetupForm.ShowForm()

        'AdvantageFramework.Maintenance.Management.Presentation.AgencyBuilderSettingsSetupForm.ShowForm()

        'AdvantageFramework.Security.Setup.Presentation.UserSetupForm.ShowForm()

        'AdvantageFramework.Security.Setup.Presentation.GroupSetupForm.ShowForm()

        'AdvantageFramework.Security.Setup.Presentation.ClientPortalUserSetupForm.ShowForm()

        'AdvantageFramework.Maintenance.Presentation.VendorImportWizardDialog.ShowWizardDialog()

        'AdvantageFramework.Maintenance.Client.Presentation.AccountExecutiveSetupForm.ShowForm()

        'AdvantageFramework.Maintenance.Presentation.AgencyClientSetupForm.ShowForm()

        'AdvantageFramework.Maintenance.Presentation.InvoiceCategorySetupForm.ShowForm()

        'AdvantageFramework.Maintenance.Presentation.IndirectCategorySetupForm.ShowForm()

        'AdvantageFramework.Maintenance.Accounting.Presentation.AccountSetupForm.ShowForm()

        'AdvantageFramework.Maintenance.Presentation.SalesTaxSetupForm.ShowForm()

        'AdvantageFramework.Maintenance.Presentation.StandardCommentSetupForm.ShowForm()

        'AdvantageFramework.Maintenance.Presentation.LocationSetupForm.ShowForm()

        'AdvantageFramework.Maintenance.Presentation.VendorImportStagingForm.ShowForm()

        'AdvantageFramework.Campaign.Presentation.CampaignSetupForm.ShowForm()

        'AdvantageFramework.Maintenance.Presentation.AgencySetupForm.ShowForm()

        'AdvantageFramework.Maintenance.Client.Presentation.AccountExecutiveSetupForm.ShowForm()

        'AdvantageFramework.Maintenance.Presentation.BillingCoopSetupForm.ShowForm()

        'AdvantageFramework.Reporting.Presentation.AdvancedReportWriterForm.ShowFormDialog(_Session)

        'AdvantageFramework.Reporting.Presentation.UserDefinedReportsForm.ShowForm()

        'AdvantageFramework.Maintenance.Presentation.ClientContactSetupForm.ShowForm()

        'AdvantageFramework.Maintenance.Presentation.EmployeeImportWizardDialog.ShowWizardDialog()

        'AdvantageFramework.Maintenance.Presentation.VendorContactSetupForm.ShowForm()

    End Sub

#End Region

#Region "  Control Event Handlers "



#End Region

#End Region

    Private Sub ButtonItemInvoicePrinting_Click(sender As Object, e As EventArgs) Handles ButtonItemInvoicePrinting.Click

        AdvantageFramework.Billing.Reports.Presentation.InvoicePrintingSetupForm.ShowForm()

    End Sub
    Private Sub ButtonItem1_Click(sender As Object, e As EventArgs) Handles ButtonItemVendorInvCat.Click

        AdvantageFramework.Exporting.Presentation.ExportForm.ShowForm(AdvantageFramework.Exporting.Methods.ExportTypes.YayPayInvoiceDetails, True, True, Nothing)

    End Sub
    Private Sub ButtonItem1_Click_1(sender As Object, e As EventArgs) Handles ButtonItem1.Click

        AdvantageFramework.Security.Setup.Presentation.CDPSecurityGroupSetupForm.ShowForm()

    End Sub
    Private Sub ButtonItem2_Click(sender As Object, e As EventArgs) Handles ButtonItem2.Click

        'AdvantageFramework.Maintenance.Media.Presentation.StationSetupForm.ShowForm()

        For Each ODBC In AdvantageFramework.Database.LoadODBCs()

            Console.WriteLine(ODBC.ToString)

        Next
        'Dim CSCORE_CLIENT_ID As String = AdvantageFramework.Security.Encryption.RijndaelSimpleDecrypt("3n/Pmp5puwSkEsukNmantJbpU5ckXXFE5ZPRf0tJaIhqFJzZeKtk87+qeuD5/n5L")
        'CSCORE_CLIENT_ID = AdvantageFramework.Security.Encryption.Encrypt(CSCORE_CLIENT_ID)
        'Dim CSCORE_CLIENT_SECRET As String = AdvantageFramework.Security.Encryption.RijndaelSimpleDecrypt("wlFV4bXqHb+szD/iVlgccLaQQ0FWweFMhrzz6tBf3ygjDh3V3iTs7YVguZu/j+Is")
        'CSCORE_CLIENT_SECRET = AdvantageFramework.Security.Encryption.Encrypt(CSCORE_CLIENT_SECRET)

    End Sub
    Private Sub ButtonItemRevenueResourcesPlan_Click(sender As Object, e As EventArgs) Handles ButtonItemRevenueResourcesPlan.Click

        AdvantageFramework.FinanceAndAccounting.Presentation.RevenueResourcePlanSetupForm.ShowForm()

    End Sub
    Private Sub ButtonItemJournalEntry_Click(sender As Object, e As EventArgs) Handles ButtonItemJournalEntry.Click

        AdvantageFramework.GeneralLedger.JournalEntriesBudgets.Presentation.JournalEntrySetupForm.ShowForm()

    End Sub

    Private Sub ButtonItemBroadcastWorksheet_Click(sender As Object, e As EventArgs) Handles ButtonItemBroadcastWorksheet.Click

        'Dim SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus = AdvantageFramework.Email.SendingEmailStatus.EmailSent

        'Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

        '    AdvantageFramework.Email.Send(DbContext, "steven.walden@gotoadvantage.com", String.Empty, String.Empty, "Advantage Test Email", "BODY!!!", 1, New Generic.List(Of AdvantageFramework.Email.Classes.Attachment), SendingEmailStatus)

        'End Using

        AdvantageFramework.Media.Presentation.MediaBroadcastWorksheetSetupForm.ShowForm()

        'AdvantageFramework.Services.Calendar.ProcessDatabase(New AdvantageFramework.Database.DatabaseProfile With {.DatabaseServer = "STEVEW-NB", .DatabaseName = "KW_67006_1", .DatabaseUserName = "SYSADM", .DatabasePassword = "sysadm", .EnableServices = True})

    End Sub

    Private Sub ButtonItemClearServicesLogs_Click(sender As Object, e As EventArgs) Handles ButtonItemClearServicesLogs.Click


        AdvantageFramework.Services.EmailListener.LoadLog(False)
        AdvantageFramework.Services.Calendar.LoadLog(False)
        AdvantageFramework.Services.Contract.LoadLog(False)
        AdvantageFramework.Services.CoreMediaCheckExport.LoadLog(False)
        AdvantageFramework.Services.CSIPreferredPartner.LoadLog(False)
        AdvantageFramework.Services.Exports.LoadLog(False)
        AdvantageFramework.Services.MediaOceanImport.LoadLog(False)
        AdvantageFramework.Services.MissingTime.LoadLog(False)
        AdvantageFramework.Services.PaidTimeOffAccruals.LoadLog(False)
        AdvantageFramework.Services.QvAAlert.LoadLog(False)
        AdvantageFramework.Services.Task.LoadLog(False)
        AdvantageFramework.Services.Imports.LoadLog(False)
        AdvantageFramework.Services.VCC.LoadLog(False)
        AdvantageFramework.Services.VendorContract.LoadLog(False)
        AdvantageFramework.Services.Nielsen.LoadLog(False)
        AdvantageFramework.Services.CalendarTimeSheetImport.LoadLog(False)
        AdvantageFramework.Services.ScheduledReports.LoadLog(False)
        AdvantageFramework.Services.ComScore.LoadLog(False)
        AdvantageFramework.Services.InOutBoard.LoadLog(False)
        AdvantageFramework.Services.AutomatedAssignments.LoadLog(False)

        AdvantageFramework.Services.AutomatedAssignments.ClearLog()
        AdvantageFramework.Services.Calendar.ClearLog()
        AdvantageFramework.Services.CalendarTimeSheetImport.ClearLog()
        AdvantageFramework.Services.ComScore.ClearLog()
        AdvantageFramework.Services.Contract.ClearLog()
        AdvantageFramework.Services.CoreMediaCheckExport.ClearLog()
        AdvantageFramework.Services.CSIPreferredPartner.ClearLog()
        AdvantageFramework.Services.CurrencyExchange.ClearLog()
        AdvantageFramework.Services.EmailListener.ClearLog()
        AdvantageFramework.Services.Exports.ClearLog()
        AdvantageFramework.Services.Imports.ClearLog()
        AdvantageFramework.Services.InOutBoard.ClearLog()
        AdvantageFramework.Services.JobCompUDFImport.ClearLog()
        AdvantageFramework.Services.MediaExport.ClearLog()
        AdvantageFramework.Services.MediaOceanImport.ClearLog()
        AdvantageFramework.Services.MissingTime.ClearLog()
        AdvantageFramework.Services.Nielsen.ClearLog()
        AdvantageFramework.Services.PaidTimeOffAccruals.ClearLog()
        AdvantageFramework.Services.QvAAlert.ClearLog()
        AdvantageFramework.Services.Task.ClearLog()
        AdvantageFramework.Services.VCC.ClearLog()
        AdvantageFramework.Services.VendorContract.ClearLog()

    End Sub

End Class
