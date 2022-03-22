Namespace WinForm.Presentation

    Public Class CRUDDialog

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum [Type]
            DatabaseProfile
            Office
            Employee
            [Function]
            Department
            Role
            DynamicReport
            PurchaseOrderApprovalRule
            EmployeeFunction
            EmployeeTitle
            Client
            AdvancedReportWriterReport
            UserDefinedReport
            PostPeriod
            Application
            ServiceFeeType
            Division
            Product
            VendorTerm
            ImportVendorCategory
            GeneralLedgerAccount
            ExceedOption
            CampaignDetailType
            SalesClass
            EmployeeCategory
            Vendor
            EstimateTemplate
            ServiceFeeReconciliationReport
            OfficeLimitGroup
            JobType
            Blackplate
            Task
            SalesTax
            ImportCreditCardTemplate
            ImportNonCreditCardTemplate
            ImportClearedChecksTemplate
            TaskTemplate
            PostPeriodActiveAP
            GLReportTemplate
            ImportAccountsPayableGenericTemplate
            JobSpecCategory
            ExportTemplate
            EmployeeTimesheetFunctionGroup
            ImportClientTemplate
            ImportDivisionTemplate
            ImportProductTemplate
            User
            ImportAccountsPayableStrataFixedInternet
            ImportAccountsPayableStrataFixedBroadcast
            ImportAccountsPayableStrataFixedPrint
            RecordSource
            ImportAccountsReceivableTemplate
            ImportFunctionTemplate
            ImportChartOfAccountTemplate
            EmployeeHRHistory
            PostPeriodActiveAR
            InternetOrder
            MagazineOrder
            NewspaperOrder
            OutOfHomeOrder
            RadioOrder
            TVOrder
            ImportDigitalResultsTemplate
            InvoiceCategory
            IncomeOnlyHistory
            AvalaraTaxTemplate
            CashReceiptTemplate
            CashReceiptCustomTemplate
            ImportAccountsReceivableCustomTemplate
            ImportAccountsPayableCustomTemplate
            APIUsers
            MediaToolsUsers
            ImportClientContactTemplate
            ImportPTOTemplate
            ImportJournalEntryTemplate
            ImportJournalEntryMOGLIFACETemplate
            ClientPO
            ImportAccountsPayable4AsBroadcast
            EmployeeHours
            AdNumber
            AdSizeCode
            ImportMediaRFPTemplate
            GLSummaryClearAndRepost
            ComscoreMarket
        End Enum

#End Region

#Region " Variables "

        Private _FormType As AdvantageFramework.WinForm.Presentation.CRUDDialog.Type = Type.DatabaseProfile
        Private _IsSelecting As Boolean = False
        Private _ShowOnlyActiveObjects As Boolean = True
        Private _SelectedObjects As IEnumerable = Nothing
        Private _Title As String = Nothing
        Private _RequireClientDivisionToBeActive As Boolean = False
        Private _LimitToNewBusinessClients As Boolean = False
        Private _ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
        Private _IsAgencyASP As Boolean = False

#End Region

#Region " Properties "

        Private ReadOnly Property SelectedObjects() As IEnumerable
            Get
                SelectedObjects = _SelectedObjects
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal FormType As AdvantageFramework.WinForm.Presentation.CRUDDialog.Type, ByVal IsSelecting As Boolean, ByVal ShowOnlyActiveObjects As Boolean, ByVal AllowMultiSelect As Boolean, ByVal Title As String, ByVal RequireClientDivisionToBeActive As Boolean, LimitToNewBusinessClients As Boolean, ByVal ParameterDictionary As Generic.Dictionary(Of String, Object))

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _FormType = FormType
            _IsSelecting = IsSelecting
            _ShowOnlyActiveObjects = ShowOnlyActiveObjects
            DataGridViewForm_Objects.MultiSelect = AllowMultiSelect
            _Title = Title
            _RequireClientDivisionToBeActive = RequireClientDivisionToBeActive
            _LimitToNewBusinessClients = LimitToNewBusinessClients
            _ParameterDictionary = ParameterDictionary

        End Sub
        Private Sub SetupCRUD()

            ButtonForm_Copy.Visible = False

            Select Case _FormType

                Case Type.DatabaseProfile

                    DataGridViewForm_Objects.ControlType = Presentation.Controls.DataGridView.Type.DatabaseProfile

                    Me.Text = "Database Profiles"

                Case Type.Office

                    Me.Text = "Offices"

                    ButtonForm_Add.Visible = False
                    ButtonForm_Edit.Visible = False
                    ButtonForm_Delete.Visible = False

                Case Type.Employee

                    Me.Text = "Employees"

                    ButtonForm_Add.Visible = False
                    ButtonForm_Edit.Visible = False
                    ButtonForm_Delete.Visible = False

                Case Type.Function

                    Me.Text = "Functions"

                    ButtonForm_Add.Visible = False
                    ButtonForm_Edit.Visible = False
                    ButtonForm_Delete.Visible = False

                Case Type.Department

                    Me.Text = "Departments"

                    ButtonForm_Add.Visible = False
                    ButtonForm_Edit.Visible = False
                    ButtonForm_Delete.Visible = False

                Case Type.Role

                    Me.Text = "Roles"

                    ButtonForm_Add.Visible = False
                    ButtonForm_Edit.Visible = False
                    ButtonForm_Delete.Visible = False

                Case Type.DynamicReport

                    Me.Text = "Report Templates"

                    If _IsSelecting Then

                        ButtonForm_Add.Visible = False
                        ButtonForm_Edit.Visible = False
                        ButtonForm_Delete.Visible = False

                    Else

                        ButtonForm_Add.Visible = False
                        ButtonForm_Edit.Visible = True
                        ButtonForm_Delete.Visible = True

                    End If

                Case Type.PurchaseOrderApprovalRule

                    Me.Text = "Purchase Order Approval Rules"

                    ButtonForm_Add.Visible = False
                    ButtonForm_Edit.Visible = False
                    ButtonForm_Delete.Visible = False

                Case Type.EmployeeFunction

                    Me.Text = "Employee Functions"

                    ButtonForm_Add.Visible = False
                    ButtonForm_Edit.Visible = False
                    ButtonForm_Delete.Visible = False

                Case Type.EmployeeTitle

                    Me.Text = "Employee Titles"

                    ButtonForm_Add.Visible = False
                    ButtonForm_Edit.Visible = False
                    ButtonForm_Delete.Visible = False

                Case Type.Client

                    Me.Text = "Clients"

                    ButtonForm_Add.Visible = False
                    ButtonForm_Edit.Visible = False
                    ButtonForm_Delete.Visible = False

                Case Type.AdvancedReportWriterReport

                    Me.Text = "Advanced Report Writer Reports"

                    ButtonForm_Add.Visible = False
                    ButtonForm_Edit.Visible = False
                    ButtonForm_Delete.Visible = False

                Case Type.UserDefinedReport

                    Me.Text = "User Defined Reports"

                    If _IsSelecting Then

                        ButtonForm_Add.Visible = False
                        ButtonForm_Edit.Visible = False
                        ButtonForm_Delete.Visible = False

                    Else

                        ButtonForm_Add.Visible = False
                        ButtonForm_Edit.Visible = True
                        ButtonForm_Delete.Visible = True

                    End If

                Case Type.PostPeriod

                    Me.Text = "Post Periods"

                    ButtonForm_Add.Visible = False
                    ButtonForm_Edit.Visible = False
                    ButtonForm_Delete.Visible = False

                Case Type.Application

                    Me.Text = "Applications"

                    ButtonForm_Add.Visible = False
                    ButtonForm_Edit.Visible = False
                    ButtonForm_Delete.Visible = False

                Case Type.ServiceFeeType

                    Me.Text = "Service Fee Types"

                    ButtonForm_Add.Visible = False
                    ButtonForm_Edit.Visible = False
                    ButtonForm_Delete.Visible = False

                Case Type.Division

                    Me.Text = "Divisions"

                    If _IsSelecting Then

                        ButtonForm_Add.Visible = False
                        ButtonForm_Edit.Visible = False
                        ButtonForm_Delete.Visible = False

                    Else

                        ButtonForm_Add.Visible = True
                        ButtonForm_Edit.Visible = True
                        ButtonForm_Delete.Visible = False

                    End If

                Case Type.Product

                    Me.Text = "Products"

                    If _IsSelecting Then

                        ButtonForm_Add.Visible = False
                        ButtonForm_Edit.Visible = False
                        ButtonForm_Delete.Visible = False

                    Else

                        ButtonForm_Add.Visible = True
                        ButtonForm_Edit.Visible = True
                        ButtonForm_Delete.Visible = False

                    End If

                Case Type.VendorTerm

                    Me.Text = "Vendor Terms"

                    ButtonForm_Add.Visible = False
                    ButtonForm_Edit.Visible = False
                    ButtonForm_Delete.Visible = False

                Case Type.ImportVendorCategory

                    Me.Text = "Vendor Categories"

                    ButtonForm_Add.Visible = False
                    ButtonForm_Edit.Visible = False
                    ButtonForm_Delete.Visible = False

                Case Type.GeneralLedgerAccount

                    Me.Text = "General Ledger Accounts"

                    ButtonForm_Add.Visible = False
                    ButtonForm_Edit.Visible = False
                    ButtonForm_Delete.Visible = False

                Case Type.ExceedOption

                    Me.Text = "Exceed Estimate Options"

                    ButtonForm_Add.Visible = False
                    ButtonForm_Edit.Visible = False
                    ButtonForm_Delete.Visible = False

                Case Type.CampaignDetailType

                    Me.Text = "Campaign Detail Types"

                    ButtonForm_Add.Visible = False
                    ButtonForm_Edit.Visible = False
                    ButtonForm_Delete.Visible = False

                Case Type.SalesClass

                    Me.Text = "Sales Classes"

                    ButtonForm_Add.Visible = False
                    ButtonForm_Edit.Visible = False
                    ButtonForm_Delete.Visible = False

                Case Type.EmployeeCategory

                    Me.Text = "Employee Categories"

                    ButtonForm_Add.Visible = False
                    ButtonForm_Edit.Visible = False
                    ButtonForm_Delete.Visible = False

                Case Type.Vendor

                    Me.Text = "Vendors"

                    ButtonForm_Add.Visible = False
                    ButtonForm_Edit.Visible = False
                    ButtonForm_Delete.Visible = False

                Case Type.EstimateTemplate

                    Me.Text = "Estimate Templates"

                    ButtonForm_Add.Visible = False
                    ButtonForm_Edit.Visible = False
                    ButtonForm_Delete.Visible = False

                Case Type.ServiceFeeReconciliationReport

                    Me.Text = "Report Templates"

                    If _IsSelecting Then

                        ButtonForm_Add.Visible = False
                        ButtonForm_Edit.Visible = False
                        ButtonForm_Delete.Visible = False

                    Else

                        ButtonForm_Add.Visible = False
                        ButtonForm_Edit.Visible = True
                        ButtonForm_Delete.Visible = True

                    End If

                Case Type.OfficeLimitGroup

                    Me.Text = "Office Limit Group Templates"

                    ButtonForm_Add.Visible = False
                    ButtonForm_Edit.Visible = False
                    ButtonForm_Delete.Visible = False

                Case Type.JobType

                    Me.Text = "Job Types"

                    ButtonForm_Add.Visible = False
                    ButtonForm_Edit.Visible = False
                    ButtonForm_Delete.Visible = False

                Case Type.Blackplate

                    Me.Text = "Blackplates"

                    ButtonForm_Add.Visible = False
                    ButtonForm_Edit.Visible = False
                    ButtonForm_Delete.Visible = False

                Case Type.Task

                    Me.Text = "Tasks"

                    ButtonForm_Add.Visible = False
                    ButtonForm_Edit.Visible = False
                    ButtonForm_Delete.Visible = False

                Case Type.SalesTax

                    Me.Text = "Sales Tax"

                    ButtonForm_Add.Visible = False
                    ButtonForm_Edit.Visible = False
                    ButtonForm_Delete.Visible = False

                Case Type.ImportCreditCardTemplate

                    Me.Text = "Import Credit Card Template"

                    ButtonForm_Add.Visible = True
                    ButtonForm_Edit.Visible = True
                    ButtonForm_Delete.Visible = True
                    ButtonForm_Copy.Visible = True

                Case Type.ImportNonCreditCardTemplate

                    Me.Text = "Import Non Credit Card Template"

                    ButtonForm_Add.Visible = True
                    ButtonForm_Edit.Visible = True
                    ButtonForm_Delete.Visible = True
                    ButtonForm_Copy.Visible = True

                Case Type.ImportClearedChecksTemplate

                    Me.Text = "Import Cleared Checks Template"

                    ButtonForm_Add.Visible = True
                    ButtonForm_Edit.Visible = True
                    ButtonForm_Delete.Visible = True
                    ButtonForm_Copy.Visible = True

                Case Type.TaskTemplate

                    Me.Text = "Task Templates"

                    ButtonForm_Add.Visible = False
                    ButtonForm_Edit.Visible = False
                    ButtonForm_Delete.Visible = False

                Case Type.PostPeriodActiveAP

                    Me.Text = "Active AP Post Periods"

                    ButtonForm_Add.Visible = False
                    ButtonForm_Edit.Visible = False
                    ButtonForm_Delete.Visible = False

                Case Type.GLReportTemplate

                    Me.Text = "GL Report Templates"

                    ButtonForm_Add.Visible = False
                    ButtonForm_Edit.Visible = False
                    ButtonForm_Delete.Visible = False

                Case Type.ImportAccountsPayableGenericTemplate

                    Me.Text = "Import Accounts Payable Template"

                    ButtonForm_Add.Visible = True
                    ButtonForm_Edit.Visible = True
                    ButtonForm_Delete.Visible = True
                    ButtonForm_Copy.Visible = True

                Case Type.ExportTemplate

                    Me.Text = "Export Template"

                    ButtonForm_Add.Visible = True
                    ButtonForm_Edit.Visible = True
                    ButtonForm_Delete.Visible = True
                    ButtonForm_Copy.Visible = True

                Case Type.JobSpecCategory

                    Me.Text = "Select Job Spec Category"

                    ButtonForm_Add.Visible = False
                    ButtonForm_Edit.Visible = False
                    ButtonForm_Delete.Visible = False

                Case Type.EmployeeTimesheetFunctionGroup

                    Me.Text = "Employee Timesheet Function Group Templates"

                    ButtonForm_Add.Visible = False
                    ButtonForm_Edit.Visible = False
                    ButtonForm_Delete.Visible = False

                Case Type.ImportClientContactTemplate

                    Me.Text = "Import Client Contact Template"

                    ButtonForm_Add.Visible = True
                    ButtonForm_Edit.Visible = True
                    ButtonForm_Delete.Visible = True
                    ButtonForm_Copy.Visible = True

                Case Type.ImportClientTemplate

                    Me.Text = "Import Client Template"

                    ButtonForm_Add.Visible = True
                    ButtonForm_Edit.Visible = True
                    ButtonForm_Delete.Visible = True
                    ButtonForm_Copy.Visible = True

                Case Type.ImportDivisionTemplate

                    Me.Text = "Import Division Template"

                    ButtonForm_Add.Visible = True
                    ButtonForm_Edit.Visible = True
                    ButtonForm_Delete.Visible = True
                    ButtonForm_Copy.Visible = True

                Case Type.ImportProductTemplate

                    Me.Text = "Import Product Template"

                    ButtonForm_Add.Visible = True
                    ButtonForm_Edit.Visible = True
                    ButtonForm_Delete.Visible = True
                    ButtonForm_Copy.Visible = True

                Case Type.User

                    Me.Text = "User"

                    ButtonForm_Add.Visible = False
                    ButtonForm_Edit.Visible = False
                    ButtonForm_Delete.Visible = False
                    ButtonForm_Copy.Visible = False

                Case Type.ImportAccountsPayableStrataFixedInternet

                    Me.Text = "Strata Fixed Internet Template"

                    ButtonForm_Add.Visible = True
                    ButtonForm_Edit.Visible = True
                    ButtonForm_Delete.Visible = True
                    ButtonForm_Copy.Visible = True

                Case Type.ImportAccountsPayableStrataFixedBroadcast

                    Me.Text = "Strata Fixed Broadcast Template"

                    ButtonForm_Add.Visible = True
                    ButtonForm_Edit.Visible = True
                    ButtonForm_Delete.Visible = True
                    ButtonForm_Copy.Visible = True

                Case Type.ImportAccountsPayableStrataFixedPrint

                    Me.Text = "Strata Fixed Print Template"

                    ButtonForm_Add.Visible = True
                    ButtonForm_Edit.Visible = True
                    ButtonForm_Delete.Visible = True
                    ButtonForm_Copy.Visible = True

                Case Type.RecordSource

                    Me.Text = "Record Source"

                    ButtonForm_Add.Visible = True
                    ButtonForm_Edit.Visible = True
                    ButtonForm_Delete.Visible = False
                    ButtonForm_Copy.Visible = False

                Case Type.ImportAccountsReceivableTemplate

                    Me.Text = "Import Accounts Receivable Template"

                    ButtonForm_Add.Visible = True
                    ButtonForm_Edit.Visible = True
                    ButtonForm_Delete.Visible = True
                    ButtonForm_Copy.Visible = True

                Case Type.ImportFunctionTemplate

                    Me.Text = "Import Function Template"

                    ButtonForm_Add.Visible = True
                    ButtonForm_Edit.Visible = True
                    ButtonForm_Delete.Visible = True
                    ButtonForm_Copy.Visible = True

                Case Type.ImportChartOfAccountTemplate

                    Me.Text = "Import Chart of Account Template"

                    ButtonForm_Add.Visible = True
                    ButtonForm_Edit.Visible = True
                    ButtonForm_Delete.Visible = True
                    ButtonForm_Copy.Visible = True

                Case Type.EmployeeHRHistory

                    Me.Text = "Employee H/R History"

                    ButtonForm_Add.Visible = True
                    ButtonForm_Edit.Visible = True
                    ButtonForm_Delete.Visible = True
                    ButtonForm_Copy.Visible = False

                Case Type.PostPeriodActiveAR

                    Me.Text = "Active AR Post Periods"

                    ButtonForm_Add.Visible = False
                    ButtonForm_Edit.Visible = False
                    ButtonForm_Delete.Visible = False

                Case Type.InternetOrder

                    Me.Text = "Internet Orders"

                    ButtonForm_Add.Visible = False
                    ButtonForm_Edit.Visible = False
                    ButtonForm_Delete.Visible = False
                    ButtonForm_Copy.Visible = False

                Case Type.MagazineOrder

                    Me.Text = "Magazine Orders"

                    ButtonForm_Add.Visible = False
                    ButtonForm_Edit.Visible = False
                    ButtonForm_Delete.Visible = False
                    ButtonForm_Copy.Visible = False

                Case Type.NewspaperOrder

                    Me.Text = "Newspaper Orders"

                    ButtonForm_Add.Visible = False
                    ButtonForm_Edit.Visible = False
                    ButtonForm_Delete.Visible = False
                    ButtonForm_Copy.Visible = False

                Case Type.OutOfHomeOrder

                    Me.Text = "Out Of Home Orders"

                    ButtonForm_Add.Visible = False
                    ButtonForm_Edit.Visible = False
                    ButtonForm_Delete.Visible = False
                    ButtonForm_Copy.Visible = False

                Case Type.RadioOrder

                    Me.Text = "Radio Orders"

                    ButtonForm_Add.Visible = False
                    ButtonForm_Edit.Visible = False
                    ButtonForm_Delete.Visible = False
                    ButtonForm_Copy.Visible = False

                Case Type.TVOrder

                    Me.Text = "TV Orders"

                    ButtonForm_Add.Visible = False
                    ButtonForm_Edit.Visible = False
                    ButtonForm_Delete.Visible = False
                    ButtonForm_Copy.Visible = False

                Case Type.ImportDigitalResultsTemplate

                    Me.Text = "Import Media Results Template"

                    ButtonForm_Add.Visible = True
                    ButtonForm_Edit.Visible = True
                    ButtonForm_Delete.Visible = True
                    ButtonForm_Copy.Visible = True

                Case Type.InvoiceCategory

                    Me.Text = "Invoice Categories"

                    ButtonForm_Add.Visible = False
                    ButtonForm_Edit.Visible = False
                    ButtonForm_Delete.Visible = False

                Case Type.IncomeOnlyHistory

                    Me.Text = "Income Only History"

                    ButtonForm_Add.Visible = False
                    ButtonForm_Edit.Visible = False
                    ButtonForm_Delete.Visible = False
                    ButtonForm_Copy.Visible = False

                Case Type.AvalaraTaxTemplate

                    Me.Text = "Import Avalara Tax Template"

                    ButtonForm_Add.Visible = True
                    ButtonForm_Edit.Visible = True
                    ButtonForm_Delete.Visible = True
                    ButtonForm_Copy.Visible = True

                Case Type.CashReceiptTemplate

                    Me.Text = "Import Cash Receipt Template"

                    ButtonForm_Add.Visible = True
                    ButtonForm_Edit.Visible = True
                    ButtonForm_Delete.Visible = True
                    ButtonForm_Copy.Visible = True

                Case Type.CashReceiptCustomTemplate

                    Me.Text = "Import Cash Receipt Template"

                    ButtonForm_Add.Visible = False
                    ButtonForm_Edit.Visible = True
                    ButtonForm_Delete.Visible = False
                    ButtonForm_Copy.Visible = False

                Case Type.ImportAccountsReceivableCustomTemplate

                    Me.Text = "Import Accounts Receivable Custom Template"

                    ButtonForm_Add.Visible = False
                    ButtonForm_Edit.Visible = True
                    ButtonForm_Delete.Visible = False
                    ButtonForm_Copy.Visible = False

                Case Type.ImportAccountsPayableCustomTemplate

                    Me.Text = "Import Accounts Payable Custom Template"

                    ButtonForm_Add.Visible = False
                    ButtonForm_Edit.Visible = True
                    ButtonForm_Delete.Visible = False
                    ButtonForm_Copy.Visible = False

                Case Type.APIUsers

                    Me.Text = "API Users"

                    ButtonForm_Add.Visible = False
                    ButtonForm_Edit.Visible = False
                    ButtonForm_Delete.Visible = False
                    ButtonForm_Copy.Visible = False

                Case Type.MediaToolsUsers

                    Me.Text = "Media Tools Users"

                    ButtonForm_Add.Visible = False
                    ButtonForm_Edit.Visible = False
                    ButtonForm_Delete.Visible = False
                    ButtonForm_Copy.Visible = False

                Case Type.ImportPTOTemplate

                    Me.Text = "Import PTO Template"

                    ButtonForm_Add.Visible = True
                    ButtonForm_Edit.Visible = True
                    ButtonForm_Delete.Visible = True
                    ButtonForm_Copy.Visible = True
                    ButtonForm_Exclude.Visible = True

                Case Type.ImportJournalEntryTemplate

                    Me.Text = "Import Journal Entry Template"

                    ButtonForm_Add.Visible = True
                    ButtonForm_Edit.Visible = True
                    ButtonForm_Delete.Visible = True
                    ButtonForm_Copy.Visible = True

                Case Type.ImportJournalEntryMOGLIFACETemplate

                    Me.Text = "Import Journal Entry MO GLIFACE Template"

                    ButtonForm_Add.Visible = False
                    ButtonForm_Edit.Visible = True
                    ButtonForm_Delete.Visible = False
                    ButtonForm_Copy.Visible = False

                Case Type.ClientPO

                    Me.Text = "Client POs"

                    ButtonForm_Add.Visible = False
                    ButtonForm_Edit.Visible = False
                    ButtonForm_Delete.Visible = False

                Case Type.ImportAccountsPayable4AsBroadcast

                    Me.Text = "4A's Broadcast Template"

                    ButtonForm_Add.Visible = True
                    ButtonForm_Edit.Visible = True
                    ButtonForm_Delete.Visible = True
                    ButtonForm_Copy.Visible = True

                Case Type.EmployeeHours

                    Me.Text = "Employee Hours Template"

                    ButtonForm_Add.Visible = True
                    ButtonForm_Edit.Visible = True
                    ButtonForm_Delete.Visible = True
                    ButtonForm_Copy.Visible = True

                Case Type.AdNumber

                    Me.Text = "Ad Number"

                    ButtonForm_Add.Visible = AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.Session, AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_AdNumber)
                    ButtonForm_Edit.Visible = False
                    ButtonForm_Delete.Visible = False

                Case Type.AdSizeCode

                    Me.Text = "Ad Size"

                    ButtonForm_Add.Visible = AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.Session, AdvantageFramework.Security.Modules.Maintenance_Media_AdSize)
                    ButtonForm_Edit.Visible = False
                    ButtonForm_Delete.Visible = False

                Case Type.ImportMediaRFPTemplate

                    Me.Text = "Media RFP Template"

                    ButtonForm_Add.Visible = False
                    ButtonForm_Edit.Visible = True
                    ButtonForm_Delete.Visible = False
                    ButtonForm_Copy.Visible = False

                Case Type.GLSummaryClearAndRepost

                    Me.Text = "GL Summary Clear and Repost"

                    ButtonForm_Add.Visible = False
                    ButtonForm_Edit.Visible = False
                    ButtonForm_Delete.Visible = False

                Case Type.ComscoreMarket

                    Me.Text = "Markets"

                    ButtonForm_Add.Visible = False
                    ButtonForm_Edit.Visible = False
                    ButtonForm_Delete.Visible = False

            End Select

            If _Title IsNot Nothing AndAlso _Title <> "" Then

                Me.Text = _Title

            End If

        End Sub
        Private Sub RefreshCRUD()

            Dim EmployeeGroupCodes As String() = Nothing
            Dim CurrentAPPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Dim AgencyImportPath As String = Nothing
            Dim CurrentARPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Dim Employee As AdvantageFramework.Database.Core.Employee = Nothing
            Dim CurrentGLPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Dim ExcludeClientCodes As IEnumerable(Of String) = Nothing
            Dim PostPeriodCodes As IEnumerable(Of String) = Nothing

            If _FormType = Type.DatabaseProfile Then

                DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.LoadDatabaseProfiles

            Else

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            _IsAgencyASP = AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext)

                            If _IsAgencyASP Then

                                AgencyImportPath = AdvantageFramework.StringUtilities.AppendTrailingCharacter(AdvantageFramework.Database.Procedures.Agency.LoadImportPath(DbContext), "\")

                            End If

                            Select Case _FormType

                                Case Type.Office

                                    If _ShowOnlyActiveObjects Then

                                        DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.Office.LoadAllActive(DbContext).ToList

                                    Else

                                        DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.Office.Load(DbContext).ToList

                                    End If

                                Case Type.Employee

                                    If _ShowOnlyActiveObjects Then

                                        DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(DbContext).ToList

                                    Else

                                        DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.EmployeeView.Load(DbContext).ToList

                                    End If

                                Case Type.Function

                                    If _ShowOnlyActiveObjects Then

                                        DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.Function.LoadAllActive(DbContext).ToList

                                    Else

                                        DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.Function.Load(DbContext).ToList

                                    End If

                                Case Type.Department

                                    If _ShowOnlyActiveObjects Then

                                        DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.DepartmentTeam.LoadAllActive(DbContext).ToList

                                    Else

                                        DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.DepartmentTeam.Load(DbContext).ToList

                                    End If

                                Case Type.Role

                                    If _ShowOnlyActiveObjects Then

                                        DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.Role.LoadAllActive(DbContext).ToList

                                    Else

                                        DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.Role.Load(DbContext).ToList

                                    End If

                                Case Type.DynamicReport

                                    DataGridViewForm_Objects.DataSource = AdvantageFramework.Reporting.LoadAvailableDynamicReports(Me.Session, AdvantageFramework.Reporting.Database.Procedures.DynamicReport.Load(ReportingDbContext).Include("UserDefinedReportCategory").ToList)

                                Case Type.PurchaseOrderApprovalRule

                                    If _ShowOnlyActiveObjects Then

                                        DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRule.LoadAllActive(DbContext).ToList

                                    Else

                                        DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRule.Load(DbContext).ToList

                                    End If

                                Case Type.EmployeeFunction

                                    If _ShowOnlyActiveObjects Then

                                        DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.Function.LoadAllActiveEmployeeFunctions(DbContext).ToList

                                    Else

                                        DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.Function.LoadAllEmployeeFunctions(DbContext).ToList

                                    End If

                                Case Type.EmployeeTitle

                                    If _ShowOnlyActiveObjects Then

                                        DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.EmployeeTitle.LoadAllActive(DbContext).ToList

                                    Else

                                        DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.EmployeeTitle.Load(DbContext).ToList

                                    End If

                                Case Type.Client

                                    If _ShowOnlyActiveObjects Then

                                        If _LimitToNewBusinessClients Then

                                            DataGridViewForm_Objects.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Client.LoadAllActiveByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext).ToList
                                                                                   Where Entity.IsNewBusiness = 1
                                                                                   Select Entity).ToList

                                        Else

                                            If _ParameterDictionary IsNot Nothing AndAlso _ParameterDictionary.ContainsKey("ExcludeClientCodes") Then

                                                ExcludeClientCodes = _ParameterDictionary.Item("ExcludeClientCodes")

                                                DataGridViewForm_Objects.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Client.LoadAllActive(DbContext)
                                                                                       Where ExcludeClientCodes.Contains(Entity.Code) = False
                                                                                       Select Entity).ToList

                                            Else

                                                DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.Client.LoadAllActiveByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext).ToList

                                            End If

                                        End If

                                    Else

                                        DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.Client.LoadAllActiveByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext).ToList

                                    End If

                                Case Type.AdvancedReportWriterReport

                                    DataGridViewForm_Objects.ItemDescription = "Advanced Report Writer Report(s)"

                                    DataGridViewForm_Objects.DataSource = (From AdvancedReportWriterReport In AdvantageFramework.Reporting.LoadAvailableAdvancedReportWriterDataSets(Me.Session)
                                                                           Select [ID] = AdvancedReportWriterReport.Key,
                                                                                  [AdvancedReportWriterReport] = AdvancedReportWriterReport.Value
                                                                           Order By [AdvancedReportWriterReport]).ToList

                                    If DataGridViewForm_Objects.Columns("ID") IsNot Nothing Then

                                        If DataGridViewForm_Objects.Columns("ID").Visible Then

                                            DataGridViewForm_Objects.Columns("ID").Visible = False

                                        End If

                                    End If

                                Case Type.UserDefinedReport

                                    DataGridViewForm_Objects.DataSource = AdvantageFramework.Reporting.LoadAvailableUserDefinedReports(Me.Session)

                                Case Type.PostPeriod

                                    If _ShowOnlyActiveObjects Then

                                        DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllActiveNonYearEndPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList

                                    Else

                                        DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList

                                    End If

                                Case Type.Application

                                    DataGridViewForm_Objects.DataSource = AdvantageFramework.Security.Database.Procedures.Application.Load(SecurityDbContext).ToList

                                Case Type.ServiceFeeType

                                    If _ShowOnlyActiveObjects Then

                                        DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.ServiceFeeType.LoadAllActive(DbContext).ToList

                                    Else

                                        DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.ServiceFeeType.Load(DbContext).ToList

                                    End If

                                Case Type.Division

                                    If _ShowOnlyActiveObjects Then

                                        If _RequireClientDivisionToBeActive Then

                                            DataGridViewForm_Objects.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Division.LoadAllActiveByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext).Include("Client")
                                                                                   Where Entity.Client.IsActive = 1
                                                                                   Select Entity).ToList

                                        ElseIf _LimitToNewBusinessClients Then

                                            DataGridViewForm_Objects.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Division.LoadAllActiveByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext).Include("Client")
                                                                                   Where Entity.Client.IsNewBusiness = 1
                                                                                   Select Entity).ToList

                                        Else

                                            DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.Division.LoadAllActiveByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext).Include("Client").ToList

                                        End If

                                    Else

                                        DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.Division.LoadByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext).Include("Client").ToList

                                    End If

                                Case Type.Product

                                    If _ShowOnlyActiveObjects Then

                                        If _RequireClientDivisionToBeActive Then

                                            DataGridViewForm_Objects.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Product.LoadAllActiveByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext).Include("Office").Include("Client").Include("Division")
                                                                                   Where Entity.Client.IsActive = 1 AndAlso
                                                                                         Entity.Division.IsActive = 1
                                                                                   Select Entity).ToList

                                        Else

                                            DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.Product.LoadAllActiveByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext).Include("Office").Include("Client").Include("Division").ToList

                                        End If

                                    Else

                                        DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.Product.LoadByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext, True).ToList

                                    End If

                                Case Type.VendorTerm

                                    DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.VendorTerm.Load(DbContext).ToList

                                Case Type.ImportVendorCategory

                                    DataGridViewForm_Objects.ItemDescription = "Vendor Category(ies)"

                                    DataGridViewForm_Objects.DataSource = (From EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.ImportVendorCategories))
                                                                           Select [Description] = EnumObject.Description,
                                                                                  [Code] = EnumObject.Code).ToList

                                    If DataGridViewForm_Objects.Columns("Code") IsNot Nothing Then

                                        If DataGridViewForm_Objects.Columns("Code").Visible Then

                                            DataGridViewForm_Objects.Columns("Code").Visible = False

                                        End If

                                    End If

                                Case Type.GeneralLedgerAccount

                                    DataGridViewForm_Objects.DataSourceViewOption = Presentation.Controls.DataGridView.DataSourceViewOptions.GeneralLedgerAccount_CodeAndDescriptionSeparated

                                    If _ParameterDictionary IsNot Nothing AndAlso _ParameterDictionary.ContainsKey("AccountPayableOfficeCode") AndAlso _ParameterDictionary.ContainsKey("NonClientOfficeCode") Then

                                        DataGridViewForm_Objects.DataSource = (From GL In AdvantageFramework.AccountPayable.GetNonClientGLAccountList(DbContext, Session, _ParameterDictionary("AccountPayableOfficeCode"), _ParameterDictionary("NonClientOfficeCode"))
                                                                               Select GL).ToList

                                    ElseIf _ParameterDictionary IsNot Nothing AndAlso _ParameterDictionary.ContainsKey("OfficeCode") Then

                                        DataGridViewForm_Objects.DataSource = AdvantageFramework.AccountPayable.GetProductionGLAccountList(DbContext, _ParameterDictionary("OfficeCode"), Session)

                                    Else

                                        If _ShowOnlyActiveObjects Then

                                            DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActiveWithOfficeLimits(DbContext, Me.Session).ToList

                                        Else

                                            DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadWithOfficeLimits(DbContext, Me.Session).ToList

                                        End If

                                    End If

                                    DataGridViewForm_Objects.FocusToFindPanel(True)

                                Case Type.ExceedOption

                                    DataGridViewForm_Objects.ItemDescription = "Exceed Option(s)"

                                    DataGridViewForm_Objects.DataSource = (From KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Database.Entities.ExceedEstimateOptions))
                                                                           Select [Name] = KeyValuePair.Value,
                                                                                  [ID] = CShort(KeyValuePair.Key)).ToList

                                    If DataGridViewForm_Objects.Columns("ID") IsNot Nothing Then

                                        If DataGridViewForm_Objects.Columns("ID").Visible Then

                                            DataGridViewForm_Objects.Columns("ID").Visible = False

                                        End If

                                    End If

                                Case Type.CampaignDetailType

                                    DataGridViewForm_Objects.ItemDescription = "Campaign Detail Type(s)"

                                    DataGridViewForm_Objects.DataSource = (From EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.CampaignDetailTypes))
                                                                           Select [Description] = EnumObject.Description,
                                                                                  [Code] = EnumObject.Code).ToList

                                    If DataGridViewForm_Objects.Columns("Code") IsNot Nothing Then

                                        If DataGridViewForm_Objects.Columns("Code").Visible Then

                                            DataGridViewForm_Objects.Columns("Code").Visible = False

                                        End If

                                    End If

                                Case Type.SalesClass

                                    If _ShowOnlyActiveObjects Then

                                        DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.SalesClass.LoadAllActive(DbContext).ToList

                                    Else

                                        DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.SalesClass.Load(DbContext).ToList

                                    End If

                                Case Type.EmployeeCategory

                                    If _ShowOnlyActiveObjects Then

                                        DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.EmployeeCategory.LoadAllActive(DbContext).ToList

                                    Else

                                        DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.EmployeeCategory.Load(DbContext).ToList

                                    End If

                                Case Type.Vendor

                                    If _ShowOnlyActiveObjects Then

                                        DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.Vendor.LoadAllActive(DbContext).ToList

                                    Else

                                        DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.Vendor.Load(DbContext).ToList

                                    End If

                                Case Type.EstimateTemplate

                                    If _ShowOnlyActiveObjects Then

                                        DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.EstimateTemplate.LoadAllActive(DbContext).ToList

                                    Else

                                        DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.EstimateTemplate.Load(DbContext).ToList

                                    End If

                                Case Type.ServiceFeeReconciliationReport

                                    DataGridViewForm_Objects.DataSource = AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationReport.Load(SecurityDbContext).ToList

                                Case Type.OfficeLimitGroup

                                    EmployeeGroupCodes = (From Entity In AdvantageFramework.Database.Procedures.EmployeeOffice.Load(DbContext).ToList
                                                          Select Entity.UserGroupCode).Distinct.ToArray

                                    DataGridViewForm_Objects.DataSource = (From Entity In AdvantageFramework.Database.Procedures.EmployeeView.Load(DbContext)
                                                                           Where EmployeeGroupCodes.Where(Function(GroupCode) GroupCode = Entity.Code).Any = True
                                                                           Select Entity).ToList

                                Case Type.JobType

                                    If _ShowOnlyActiveObjects Then

                                        DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.JobType.LoadAllActive(DbContext).ToList

                                    Else

                                        DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.JobType.Load(DbContext).ToList

                                    End If

                                Case Type.Blackplate

                                    If _ShowOnlyActiveObjects Then

                                        DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.Blackplate.LoadAllActive(DbContext).ToList

                                    Else

                                        DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.Blackplate.Load(DbContext).ToList

                                    End If

                                Case Type.Task

                                    If _ShowOnlyActiveObjects Then

                                        DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.Task.LoadAllActive(DbContext).ToList

                                    Else

                                        DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.Task.Load(DbContext).ToList

                                    End If

                                Case Type.SalesTax

                                    If _ShowOnlyActiveObjects Then

                                        DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.SalesTax.LoadAllActive(DbContext).ToList

                                    Else

                                        DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.SalesTax.Load(DbContext).ToList

                                    End If

                                Case Type.ImportCreditCardTemplate

                                    DataGridViewForm_Objects.DataSource = LoadImportTemplateDetails(DbContext, Importing.ImportTemplateTypes.ExpenseReport_CreditCard, AgencyImportPath)

                                Case Type.ImportNonCreditCardTemplate

                                    DataGridViewForm_Objects.DataSource = LoadImportTemplateDetails(DbContext, Importing.ImportTemplateTypes.ExpenseReport_NonCreditCard, AgencyImportPath)

                                Case Type.ImportClearedChecksTemplate

                                    DataGridViewForm_Objects.DataSource = LoadImportTemplateDetails(DbContext, Importing.ImportTemplateTypes.ClearedChecks_Default, AgencyImportPath)

                                Case Type.TaskTemplate

                                    DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.TaskTemplate.Load(DbContext)

                                Case Type.PostPeriodActiveAP

                                    DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllActiveAPPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList

                                    CurrentAPPostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentAPPostPeriod(DbContext)

                                    If CurrentAPPostPeriod IsNot Nothing Then

                                        DataGridViewForm_Objects.SelectRow(CurrentAPPostPeriod.Code)

                                    End If

                                Case Type.GLReportTemplate

                                    DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.GLReportTemplate.Load(DbContext)

                                Case Type.ImportAccountsPayableGenericTemplate

                                    DataGridViewForm_Objects.DataSource = LoadImportTemplateDetails(DbContext, Importing.ImportTemplateTypes.AccountsPayable_Generic, AgencyImportPath)

                                Case Type.ExportTemplate

                                    DataGridViewForm_Objects.DataSource = LoadExportTemplateDetails(DbContext, _ParameterDictionary("ExportType"), AgencyImportPath)

                                Case Type.JobSpecCategory

                                    If _ParameterDictionary IsNot Nothing Then

                                        If _ShowOnlyActiveObjects Then

                                            DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.JobSpecificationCategory.LoadByJobSpecificationTypeCode(DbContext, _ParameterDictionary("JobSpecificationTypeCode").ToString).Where(Function(Entity) Entity.IsInactive = 0).ToList

                                        Else

                                            DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.JobSpecificationCategory.LoadByJobSpecificationTypeCode(DbContext, _ParameterDictionary("JobSpecificationTypeCode").ToString).ToList

                                        End If

                                    Else

                                        If _ShowOnlyActiveObjects Then

                                            DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.JobSpecificationCategory.Load(DbContext).Where(Function(Entity) Entity.IsInactive = 0).ToList

                                        Else

                                            DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.JobSpecificationCategory.Load(DbContext).ToList

                                        End If

                                    End If

                                Case Type.EmployeeTimesheetFunctionGroup

                                    EmployeeGroupCodes = (From Entity In AdvantageFramework.Database.Procedures.EmployeeTimesheetFunction.Load(DbContext).ToList
                                                          Select Entity.GroupCode).Distinct.ToArray

                                    DataGridViewForm_Objects.DataSource = (From Entity In AdvantageFramework.Database.Procedures.EmployeeView.Load(DbContext)
                                                                           Where EmployeeGroupCodes.Where(Function(GroupCode) GroupCode = Entity.Code).Any = True
                                                                           Select Entity).ToList

                                Case Type.ImportClientContactTemplate

                                    DataGridViewForm_Objects.DataSource = LoadImportTemplateDetails(DbContext, Importing.ImportTemplateTypes.ClientContact_Default, AgencyImportPath)

                                Case Type.ImportClientTemplate

                                    DataGridViewForm_Objects.DataSource = LoadImportTemplateDetails(DbContext, Importing.ImportTemplateTypes.Client_Default, AgencyImportPath)

                                Case Type.ImportDivisionTemplate

                                    DataGridViewForm_Objects.DataSource = LoadImportTemplateDetails(DbContext, Importing.ImportTemplateTypes.Division_Default, AgencyImportPath)

                                Case Type.ImportProductTemplate

                                    DataGridViewForm_Objects.DataSource = LoadImportTemplateDetails(DbContext, Importing.ImportTemplateTypes.Product_Default, AgencyImportPath)

                                Case Type.User

                                    DataGridViewForm_Objects.DataSource = AdvantageFramework.Security.Database.Procedures.User.Load(SecurityDbContext).Include("Employee").Include("Employee.Department").ToList

                                Case Type.ImportAccountsPayableStrataFixedInternet

                                    DataGridViewForm_Objects.DataSource = LoadImportTemplateDetails(DbContext, Importing.ImportTemplateTypes.AccountsPayable_StrataFixedInternet, AgencyImportPath)

                                Case Type.ImportAccountsPayableStrataFixedBroadcast

                                    DataGridViewForm_Objects.DataSource = LoadImportTemplateDetails(DbContext, Importing.ImportTemplateTypes.AccountsPayable_StrataFixedBroadcast, AgencyImportPath)

                                Case Type.ImportAccountsPayableStrataFixedPrint

                                    DataGridViewForm_Objects.DataSource = LoadImportTemplateDetails(DbContext, Importing.ImportTemplateTypes.AccountsPayable_StrataFixedPrint, AgencyImportPath)

                                Case Type.RecordSource

                                    DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.RecordSource.Load(DbContext).ToList

                                Case Type.ImportAccountsReceivableTemplate

                                    DataGridViewForm_Objects.DataSource = LoadImportTemplateDetails(DbContext, Importing.ImportTemplateTypes.AccountsReceivable_Default, AgencyImportPath)

                                Case Type.ImportFunctionTemplate

                                    DataGridViewForm_Objects.DataSource = LoadImportTemplateDetails(DbContext, Importing.ImportTemplateTypes.Function_Default, AgencyImportPath)

                                Case Type.ImportChartOfAccountTemplate

                                    DataGridViewForm_Objects.DataSource = LoadImportTemplateDetails(DbContext, Importing.ImportTemplateTypes.ChartOfAccounts_Default, AgencyImportPath)

                                Case Type.EmployeeHRHistory

                                    DataGridViewForm_Objects.ItemDescription = "Employee Rate History(ies)"

                                    If _ParameterDictionary IsNot Nothing AndAlso _ParameterDictionary.ContainsKey("EmployeeCode") AndAlso _ParameterDictionary("EmployeeCode") IsNot Nothing Then

                                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadCore(DbContext).SingleOrDefault(Function(Entity) Entity.Code = _ParameterDictionary("EmployeeCode"))

                                        If Employee IsNot Nothing Then

                                            Me.Text &= " - " & Employee.ToString

                                            DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.EmployeeRateHistory.LoadByEmployeeCode(DbContext, Employee.Code).Include("EmployeeTitle").Include("DepartmentTeam").ToList

                                        Else

                                            DataGridViewForm_Objects.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.EmployeeRateHistory)

                                        End If

                                    Else

                                        DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.EmployeeRateHistory.Load(DbContext).Include("EmployeeTitle").Include("DepartmentTeam").ToList

                                    End If

                                    If DataGridViewForm_Objects.Columns("DepartmentTeam") IsNot Nothing Then

                                        DataGridViewForm_Objects.Columns("DepartmentTeam").Caption = "Department/Team Name"

                                    End If

                                Case Type.PostPeriodActiveAR

                                    DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllActiveARPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList

                                    CurrentARPostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentARPostPeriod(DbContext)

                                    If CurrentARPostPeriod IsNot Nothing Then

                                        DataGridViewForm_Objects.SelectRow(CurrentARPostPeriod.Code)

                                    End If

                                Case Type.InternetOrder

                                    DataGridViewForm_Objects.DataSource = AdvantageFramework.AccountPayable.GetAvailableInternetOrders(DbContext, _ParameterDictionary("AllowVendorNotOnOrder"), _ParameterDictionary("VendorCode"),
                                                                                                                                       _ParameterDictionary("OfficeCode"), Nothing, Nothing, Nothing, Nothing, Nothing, Nothing).
                                                                                                                                       ToList.OrderByDescending(Function(Entity) Entity.OrderNumber).ThenBy(Function(Entity) Entity.LineNumber).ToList

                                    If _ParameterDictionary("AllowVendorNotOnOrder") Then

                                        DataGridViewForm_Objects.CurrentView.AFActiveFilterString = "VendorCode = '" & _ParameterDictionary("VendorCode") & "'"

                                    Else

                                        DataGridViewForm_Objects.MakeColumnNotVisible(AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableInternetOrders.Properties.VendorCode.ToString)

                                    End If

                                Case Type.MagazineOrder

                                    DataGridViewForm_Objects.DataSource = AdvantageFramework.AccountPayable.GetAvailableMagazineOrders(DbContext, _ParameterDictionary("AllowVendorNotOnOrder"), _ParameterDictionary("VendorCode"),
                                                                                                                                       _ParameterDictionary("OfficeCode"), Nothing, Nothing, Nothing, Nothing, Nothing, Nothing).
                                                                                                                                       ToList.OrderByDescending(Function(Entity) Entity.OrderNumber).ThenBy(Function(Entity) Entity.LineNumber).ToList

                                    If _ParameterDictionary("AllowVendorNotOnOrder") Then

                                        DataGridViewForm_Objects.CurrentView.AFActiveFilterString = "VendorCode = '" & _ParameterDictionary("VendorCode") & "'"

                                    Else

                                        DataGridViewForm_Objects.MakeColumnNotVisible(AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableMagazineOrders.Properties.VendorCode.ToString)

                                    End If

                                Case Type.NewspaperOrder

                                    DataGridViewForm_Objects.DataSource = AdvantageFramework.AccountPayable.GetAvailableNewspaperOrders(DbContext, _ParameterDictionary("AllowVendorNotOnOrder"), _ParameterDictionary("VendorCode"),
                                                                                                                                        _ParameterDictionary("OfficeCode"), Nothing, Nothing, Nothing, Nothing, Nothing, Nothing).
                                                                                                                                        ToList.OrderByDescending(Function(Entity) Entity.OrderNumber).ThenBy(Function(Entity) Entity.LineNumber).ToList

                                    If _ParameterDictionary("AllowVendorNotOnOrder") Then

                                        DataGridViewForm_Objects.CurrentView.AFActiveFilterString = "VendorCode = '" & _ParameterDictionary("VendorCode") & "'"

                                    Else

                                        DataGridViewForm_Objects.MakeColumnNotVisible(AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableNewspaperOrders.Properties.VendorCode.ToString)

                                    End If

                                Case Type.OutOfHomeOrder

                                    DataGridViewForm_Objects.DataSource = AdvantageFramework.AccountPayable.GetAvailableOutOfHomeOrders(DbContext, _ParameterDictionary("AllowVendorNotOnOrder"), _ParameterDictionary("VendorCode"),
                                                                                                                                        _ParameterDictionary("OfficeCode"), Nothing, Nothing, Nothing, Nothing, Nothing, Nothing).
                                                                                                                                        ToList.OrderByDescending(Function(Entity) Entity.OrderNumber).ThenBy(Function(Entity) Entity.LineNumber).ToList

                                    If _ParameterDictionary("AllowVendorNotOnOrder") Then

                                        DataGridViewForm_Objects.CurrentView.AFActiveFilterString = "VendorCode = '" & _ParameterDictionary("VendorCode") & "'"

                                    Else

                                        DataGridViewForm_Objects.MakeColumnNotVisible(AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableOutOfHomeOrders.Properties.VendorCode.ToString)

                                    End If

                                Case Type.RadioOrder

                                    DataGridViewForm_Objects.DataSource = AdvantageFramework.AccountPayable.GetAvailableRadioOrders(DbContext, _ParameterDictionary("AllowVendorNotOnOrder"), _ParameterDictionary("VendorCode"),
                                                                                                                                   _ParameterDictionary("OfficeCode"), Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing).
                                                                                                                                   Where(Function(Entity) Entity.IsOld = 0).ToList.OrderByDescending(Function(Entity) Entity.OrderNumber).ThenBy(Function(Entity) Entity.LineNumber).ToList

                                    If _ParameterDictionary("AllowVendorNotOnOrder") Then

                                        DataGridViewForm_Objects.CurrentView.AFActiveFilterString = "VendorCode = '" & _ParameterDictionary("VendorCode") & "'"

                                    Else

                                        DataGridViewForm_Objects.MakeColumnNotVisible(AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableRadioOrders.Properties.VendorCode.ToString)

                                    End If

                                Case Type.TVOrder

                                    DataGridViewForm_Objects.DataSource = AdvantageFramework.AccountPayable.GetAvailableTVOrders(DbContext, _ParameterDictionary("AllowVendorNotOnOrder"), _ParameterDictionary("VendorCode"),
                                                                                                                                 _ParameterDictionary("OfficeCode"), Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing).
                                                                                                                                 Where(Function(Entity) Entity.IsOld = 0).ToList.OrderByDescending(Function(Entity) Entity.OrderNumber).ThenBy(Function(Entity) Entity.LineNumber).ToList

                                    If _ParameterDictionary("AllowVendorNotOnOrder") Then

                                        DataGridViewForm_Objects.CurrentView.AFActiveFilterString = "VendorCode = '" & _ParameterDictionary("VendorCode") & "'"

                                    Else

                                        DataGridViewForm_Objects.MakeColumnNotVisible(AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableTVOrders.Properties.VendorCode.ToString)

                                    End If

                                Case Type.ImportDigitalResultsTemplate

                                    DataGridViewForm_Objects.DataSource = LoadImportTemplateDetails(DbContext, Importing.ImportTemplateTypes.DigitalResults_Default, AgencyImportPath)

                                Case Type.InvoiceCategory

                                    If _ShowOnlyActiveObjects Then

                                        DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.InvoiceCategory.LoadAllActive(DbContext).ToList

                                    Else

                                        DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.InvoiceCategory.Load(DbContext).ToList

                                    End If

                                Case Type.IncomeOnlyHistory

                                    DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.IncomeOnly.LoadByID(DbContext, CInt(_ParameterDictionary("ID"))).ToList _
                                                                          .Select(Function(Entity) New AdvantageFramework.IncomeOnly.Classes.IncomeOnlyHistory(Entity)).OrderBy(Function(Entity) Entity.SequenceNumber).ToList

                                Case Type.AvalaraTaxTemplate

                                    DataGridViewForm_Objects.DataSource = LoadImportTemplateDetails(DbContext, Importing.ImportTemplateTypes.AvalaraTaxCode_Default, AgencyImportPath)

                                Case Type.CashReceiptTemplate

                                    DataGridViewForm_Objects.DataSource = LoadImportTemplateDetails(DbContext, Importing.ImportTemplateTypes.CashReceipt_Generic, AgencyImportPath)

                                Case Type.CashReceiptCustomTemplate

                                    DataGridViewForm_Objects.DataSource = LoadImportTemplateDetails(DbContext, Importing.ImportTemplateTypes.CashReceipt_Custom, AgencyImportPath)

                                Case Type.ImportAccountsReceivableCustomTemplate

                                    DataGridViewForm_Objects.DataSource = LoadImportTemplateDetails(DbContext, Importing.ImportTemplateTypes.AccountsReceivable_Custom, AgencyImportPath)

                                Case Type.ImportAccountsPayableCustomTemplate

                                    DataGridViewForm_Objects.DataSource = LoadImportTemplateDetails(DbContext, Importing.ImportTemplateTypes.AccountsPayable_Custom, AgencyImportPath)

                                Case Type.APIUsers

                                    DataGridViewForm_Objects.DataSource = (From Item In AdvantageFramework.Database.Procedures.EmployeeView.Load(DbContext).ToList
                                                                           Where AdvantageFramework.Security.IsAPIUser(Item.Code, Item.IsAPIUser)
                                                                           Select Item).ToList

                                Case Type.MediaToolsUsers

                                    DataGridViewForm_Objects.DataSource = (From Item In AdvantageFramework.Security.Database.Procedures.User.Load(SecurityDbContext)
                                                                           Join MediaToolsUser In AdvantageFramework.Security.Database.Procedures.UserSetting.LoadBySettingCode(SecurityDbContext, AdvantageFramework.Security.UserSettings.IsMediaToolsUser.ToString) On Item.ID Equals MediaToolsUser.UserID
                                                                           Select User = Item, Setting = MediaToolsUser).ToList _
                                                                           .Where(Function(item) AdvantageFramework.Security.IsMediaToolUser(item.User.UserCode, item.Setting.StringValue)).Select(Function(item) item.User).ToList

                                Case Type.ImportPTOTemplate

                                    DataGridViewForm_Objects.DataSource = LoadImportTemplateDetails(DbContext, Importing.ImportTemplateTypes.PTO_Default, AgencyImportPath)

                                Case Type.ImportJournalEntryTemplate

                                    DataGridViewForm_Objects.DataSource = LoadImportTemplateDetails(DbContext, Importing.ImportTemplateTypes.JournalEntry_Default, AgencyImportPath)

                                Case Type.ImportJournalEntryMOGLIFACETemplate

                                    DataGridViewForm_Objects.DataSource = LoadImportTemplateDetails(DbContext, Importing.ImportTemplateTypes.JournalEntry_MOGLIFACE, AgencyImportPath)

                                Case Type.ClientPO

                                    Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                                        If _ParameterDictionary IsNot Nothing Then

                                            DataGridViewForm_Objects.DataSource = (From PO In AdvantageFramework.Database.Procedures.ClientPO.LoadActive(DataContext)
                                                                                   Where PO.ClientCode = DirectCast(_ParameterDictionary("ClientCode"), String) AndAlso
                                                                                         PO.DivisionCode = DirectCast(_ParameterDictionary("DivisionCode"), String) AndAlso
                                                                                         PO.ProductCode = DirectCast(_ParameterDictionary("ProductCode"), String)
                                                                                   Select PO).ToList

                                        Else

                                            DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.ClientPO.LoadActive(DataContext).ToList

                                        End If

                                    End Using

                                Case Type.ImportAccountsPayable4AsBroadcast

                                    DataGridViewForm_Objects.DataSource = LoadImportTemplateDetails(DbContext, Importing.ImportTemplateTypes.AccountsPayable_4AsBroadcast, AgencyImportPath)

                                Case Type.EmployeeHours

                                    DataGridViewForm_Objects.DataSource = LoadImportTemplateDetails(DbContext, Importing.ImportTemplateTypes.Employee_Hours, AgencyImportPath)

                                Case Type.AdNumber

                                    If _ParameterDictionary IsNot Nothing Then

                                        DataGridViewForm_Objects.DataSource = AdvantageFramework.MediaManager.GetAdNumberDatasource(DbContext, DirectCast(_ParameterDictionary("ClientCode"), String))

                                    End If

                                Case Type.AdSizeCode

                                    If _ParameterDictionary IsNot Nothing Then

                                        DataGridViewForm_Objects.DataSource = AdvantageFramework.MediaManager.GetAdSizeCodeDatasource(DbContext, DirectCast(_ParameterDictionary("MediaType"), String))

                                    End If

                                Case Type.ImportMediaRFPTemplate

                                    DataGridViewForm_Objects.DataSource = LoadImportTemplateDetails(DbContext, Importing.ImportTemplateTypes.MediaRFP_4As, AgencyImportPath)

                                Case Type.GLSummaryClearAndRepost

                                    PostPeriodCodes = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllActiveGLPostPeriods(DbContext).Where(Function(PP) PP.Month <> 99).Select(Function(PP) PP.Code).ToArray

                                    PostPeriodCodes = (From Entity In AdvantageFramework.Database.Procedures.GLASummaryData.Load(DbContext)
                                                       Where PostPeriodCodes.Contains(Entity.PostPeriodCode)
                                                       Select Entity.PostPeriodCode).Distinct.ToArray

                                    DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllActiveGLPostPeriods(DbContext).Where(Function(PP) PP.Month <> 99 AndAlso
                                                                                 PostPeriodCodes.Contains(PP.Code)).OrderByDescending(Function(Entity) Entity.Code).ToList

                                    CurrentGLPostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentGLPostPeriod(DbContext)

                                    If CurrentGLPostPeriod IsNot Nothing Then

                                        DataGridViewForm_Objects.SelectRow(CurrentGLPostPeriod.Code)

                                    End If

                                    DataGridViewForm_Objects.CurrentView.ViewCaption = DataGridViewForm_Objects.CurrentView.RowCount.ToString & " Open Post Periods"

                                Case Type.ComscoreMarket

                                    DataGridViewForm_Objects.DataSource = AdvantageFramework.Database.Procedures.Market.LoadAllActiveComscore(DbContext).ToList

                                    DataGridViewForm_Objects.FocusToFindPanel(True)

                            End Select

                        End Using

                    End Using

                End Using

            End If

            EnableButtons()

        End Sub
        Private Sub SelectRows()

            If DataGridViewForm_Objects.HasASelectedRow Then

                _SelectedObjects = DataGridViewForm_Objects.GetAllSelectedRowsDataBoundItems.OfType(Of Object).ToList

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            End If

        End Sub
        Private Sub EditImportTemplate(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportTemplateType As AdvantageFramework.Importing.ImportTemplateTypes)

            Dim ImportTemplateID As Short = Nothing
            Dim ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate = Nothing

            ImportTemplateID = DataGridViewForm_Objects.CurrentView.GetRowCellValue(DataGridViewForm_Objects.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.ImportTemplate.Properties.ID.ToString)

            ImportTemplate = AdvantageFramework.Database.Procedures.ImportTemplate.LoadByImportTemplateID(DbContext, ImportTemplateID)

            If ImportTemplate IsNot Nothing Then

                If ImportTemplate.IsSystemTemplate Then

                    AdvantageFramework.Importing.Presentation.ImportSystemTemplateEditDialog.ShowFormDialog(ImportTemplateType, ImportTemplateID)

                ElseIf ImportTemplate.FileType = AdvantageFramework.Importing.FileTypes.CSV Then

                    AdvantageFramework.Importing.Presentation.ImportCSVTemplateDialog.ShowFormDialog(ImportTemplateType, ImportTemplateID)

                ElseIf ImportTemplate.FileType = AdvantageFramework.Importing.FileTypes.Fixed Then

                    AdvantageFramework.Importing.Presentation.ImportFixedTemplateDialog.ShowFormDialog(ImportTemplateType, ImportTemplateID)

                End If

            End If

        End Sub
        Private Sub EnableButtons()

            Select Case _FormType

                Case Type.DynamicReport, Type.UserDefinedReport, Type.ServiceFeeReconciliationReport

                    ButtonForm_Add.Enabled = False
                    ButtonForm_Edit.Enabled = DataGridViewForm_Objects.HasOnlyOneSelectedRow
                    ButtonForm_Delete.Enabled = DataGridViewForm_Objects.HasOnlyOneSelectedRow
                    ButtonForm_Select.Enabled = DataGridViewForm_Objects.HasASelectedRow

                Case Type.ImportClearedChecksTemplate, Type.ImportCreditCardTemplate, Type.ImportNonCreditCardTemplate,
                        Type.ImportAccountsPayableGenericTemplate, Type.ImportClientContactTemplate, Type.ImportClientTemplate, Type.ImportDivisionTemplate, Type.ImportProductTemplate, Type.ImportAccountsReceivableTemplate,
                        Type.ImportFunctionTemplate, Type.ImportChartOfAccountTemplate, Type.ImportDigitalResultsTemplate, Type.AvalaraTaxTemplate, Type.CashReceiptTemplate, Type.ImportPTOTemplate, Type.ImportJournalEntryTemplate,
                        Type.EmployeeHours

                    If DataGridViewForm_Objects.HasOnlyOneSelectedRow Then

                        If DataGridViewForm_Objects.CurrentView.GetRowCellValue(DataGridViewForm_Objects.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.ImportTemplate.Properties.IsSystemTemplate.ToString) = True Then

                            ButtonForm_Delete.Enabled = False
                            ButtonForm_Edit.Enabled = Not _IsAgencyASP
                            ButtonForm_Copy.Enabled = True

                        Else

                            ButtonForm_Delete.Enabled = True
                            ButtonForm_Edit.Enabled = True
                            ButtonForm_Copy.Enabled = True

                        End If

                    End If

                    ButtonForm_Select.Enabled = DataGridViewForm_Objects.HasASelectedRow
                    ButtonForm_Exclude.Enabled = DataGridViewForm_Objects.HasOnlyOneSelectedRow

                Case Type.ImportAccountsPayableStrataFixedInternet, Type.ImportAccountsPayableStrataFixedBroadcast, Type.ImportAccountsPayableStrataFixedPrint, Type.ImportAccountsPayable4AsBroadcast

                    If DataGridViewForm_Objects.HasOnlyOneSelectedRow Then

                        If DataGridViewForm_Objects.CurrentView.GetRowCellValue(DataGridViewForm_Objects.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.ImportTemplate.Properties.IsSystemTemplate.ToString) = True Then

                            ButtonForm_Edit.Enabled = Not _IsAgencyASP

                        End If

                    Else

                        ButtonForm_Edit.Enabled = False

                    End If

                    ButtonForm_Add.Enabled = False
                    ButtonForm_Delete.Enabled = False
                    ButtonForm_Copy.Enabled = False
                    ButtonForm_Select.Enabled = DataGridViewForm_Objects.HasASelectedRow

                Case Type.RecordSource

                    If DataGridViewForm_Objects.HasOnlyOneSelectedRow Then

                        If DataGridViewForm_Objects.CurrentView.GetRowCellValue(DataGridViewForm_Objects.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.RecordSource.Properties.IsSystemSource.ToString) = True Then

                            ButtonForm_Edit.Enabled = False

                        Else

                            ButtonForm_Edit.Enabled = True

                        End If

                    Else

                        ButtonForm_Edit.Enabled = False

                    End If

                    ButtonForm_Select.Enabled = DataGridViewForm_Objects.HasASelectedRow

                Case Type.ExportTemplate

                    If DataGridViewForm_Objects.HasOnlyOneSelectedRow Then

                        If DataGridViewForm_Objects.CurrentView.GetRowCellValue(DataGridViewForm_Objects.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.ExportTemplate.Properties.IsSystemTemplate.ToString) = True Then

                            ButtonForm_Delete.Enabled = False
                            ButtonForm_Edit.Enabled = Not _IsAgencyASP

                            If DataGridViewForm_Objects.CurrentView.GetRowCellValue(DataGridViewForm_Objects.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.ExportTemplate.Properties.Name.ToString).ToString.ToUpper = AdvantageFramework.Exporting.AP_GENERIC_1 Then

                                ButtonForm_Copy.Enabled = False

                            Else

                                ButtonForm_Copy.Enabled = True

                            End If

                        Else

                            ButtonForm_Delete.Enabled = True
                            ButtonForm_Edit.Enabled = True

                            ButtonForm_Copy.Enabled = True

                        End If

                    End If

                    ButtonForm_Select.Enabled = DataGridViewForm_Objects.HasASelectedRow

                Case Else

                    ButtonForm_Edit.Enabled = DataGridViewForm_Objects.HasOnlyOneSelectedRow
                    ButtonForm_Delete.Enabled = DataGridViewForm_Objects.HasOnlyOneSelectedRow
                    ButtonForm_Select.Enabled = DataGridViewForm_Objects.HasASelectedRow

            End Select

        End Sub
        Private Function LoadImportTemplateDetails(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportTemplateType As AdvantageFramework.Importing.ImportTemplateTypes,
                                                   ByVal AgencyImportPath As String) As Generic.List(Of AdvantageFramework.Database.Entities.ImportTemplate)

            Dim ImportTemplateList As Generic.List(Of AdvantageFramework.Database.Entities.ImportTemplate) = Nothing
            'Dim ImportPath As String = Nothing

            'ImportPath = AdvantageFramework.Importing.GetHostedDirectory(ImportTemplateType, AgencyImportPath)

            ImportTemplateList = (From ImportTemplate In AdvantageFramework.Database.Procedures.ImportTemplate.LoadByImportType(DbContext, CShort(ImportTemplateType))
                                  Select ImportTemplate).OrderByDescending(Function(ImportTemplate) ImportTemplate.IsSystemTemplate).ThenBy(Function(ImportTemplate) ImportTemplate.Name).ToList

            'If _IsAgencyASP Then

            '    For Each ImportTemplate In ImportTemplateList

            '        ImportTemplate.DefaultDirectory = ImportPath

            '    Next

            'End If

            LoadImportTemplateDetails = ImportTemplateList

        End Function
        Private Function LoadExportTemplateDetails(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ExportType As AdvantageFramework.Exporting.ExportTypes,
                                                   ByVal AgencyImportPath As String) As Generic.List(Of AdvantageFramework.Database.Entities.ExportTemplate)

            Dim ExportTemplateList As Generic.List(Of AdvantageFramework.Database.Entities.ExportTemplate) = Nothing
            Dim ExportPath As String = Nothing

            ExportPath = AgencyImportPath & "Reports\"

            ExportTemplateList = (From ExportTemplate In AdvantageFramework.Database.Procedures.ExportTemplate.LoadByType(DbContext, CShort(ExportType))
                                  Select ExportTemplate).OrderByDescending(Function(ExportTemplate) ExportTemplate.IsSystemTemplate).ThenBy(Function(ExportTemplate) ExportTemplate.Name).ToList

            If _IsAgencyASP Then

                For Each ExportTemplate In ExportTemplateList

                    ExportTemplate.DefaultDirectory = ExportPath

                Next

            End If

            LoadExportTemplateDetails = ExportTemplateList

        End Function

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal FormType As AdvantageFramework.WinForm.Presentation.CRUDDialog.Type, ByVal IsSelecting As Boolean, ByVal ShowOnlyActiveObjects As Boolean, Optional ByRef SelectedObjects As IEnumerable = Nothing, Optional ByVal AllowMultiSelect As Boolean = True, Optional ByVal Title As String = Nothing, Optional ByVal RequireClientDivisionToBeActive As Boolean = False, Optional LimitToNewBusinessClients As Boolean = False, Optional ByVal ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing) As Windows.Forms.DialogResult

            'objects
            Dim CRUDDialog As AdvantageFramework.WinForm.Presentation.CRUDDialog = Nothing

            CRUDDialog = New AdvantageFramework.WinForm.Presentation.CRUDDialog(FormType, IsSelecting, ShowOnlyActiveObjects, AllowMultiSelect, Title, RequireClientDivisionToBeActive, LimitToNewBusinessClients, ParameterDictionary)

            ShowFormDialog = CRUDDialog.ShowDialog()

            If IsSelecting Then

                SelectedObjects = CRUDDialog.SelectedObjects

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub CRUDDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ShowUnsavedChangesOnFormClosing = False

            If _IsSelecting Then

                ButtonForm_Select.Visible = True
                ButtonForm_Cancel.Visible = True
                ButtonForm_Close.Visible = False

            Else

                ButtonForm_Select.Visible = False
                ButtonForm_Cancel.Visible = False
                ButtonForm_Close.Visible = True

            End If

            SetupCRUD()

            RefreshCRUD()

            DataGridViewForm_Objects.CurrentView.BestFitColumns()

            If _ShowOnlyActiveObjects Then

                If DataGridViewForm_Objects.Columns("IsInactive") IsNot Nothing Then

                    If DataGridViewForm_Objects.Columns("IsInactive").Visible Then

                        DataGridViewForm_Objects.Columns("IsInactive").Visible = False

                    End If

                End If

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub DataGridViewForm_Objects_RowDoubleClickEvent() Handles DataGridViewForm_Objects.RowDoubleClickEvent

            If _IsSelecting Then

                SelectRows()

            Else

                ButtonForm_Edit.PerformClick()

            End If

        End Sub
        Private Sub DataGridViewForm_Objects_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_Objects.SelectionChangedEvent

            EnableButtons()

        End Sub
        Private Sub ButtonForm_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Add.Click

            'objects
            Dim FileType As AdvantageFramework.Importing.FileTypes = AdvantageFramework.Importing.FileTypes.CSV
            Dim ClientCode As String = Nothing
            Dim MediaType As String = Nothing

            Select Case _FormType

                Case Type.DatabaseProfile

                    AdvantageFramework.Database.Presentation.DatabaseProfileDialog.ShowFormDialog(Nothing)

                Case Type.Division

                    AdvantageFramework.Maintenance.Client.Presentation.DivisionEditDialog.ShowFormDialog(False)

                Case Type.Product

                    AdvantageFramework.Maintenance.Client.Presentation.ProductEditDialog.ShowFormDialog(False)

                Case Type.AvalaraTaxTemplate

                    AdvantageFramework.Importing.Presentation.ImportCSVTemplateDialog.ShowFormDialog(AdvantageFramework.Importing.ImportTemplateTypes.AvalaraTaxCode_Default)

                Case Type.ImportCreditCardTemplate, Type.ImportNonCreditCardTemplate, Type.ImportClearedChecksTemplate, Type.ImportAccountsPayableGenericTemplate,
                        Type.ImportClientTemplate, Type.ImportDivisionTemplate, Type.ImportProductTemplate, Type.ImportAccountsReceivableTemplate, Type.ImportFunctionTemplate,
                        Type.ImportChartOfAccountTemplate, Type.ImportClientContactTemplate, Type.ImportPTOTemplate, Type.ImportJournalEntryTemplate

                    If AdvantageFramework.Importing.Presentation.FileTypeSelectionDialog.ShowFormDialog(FileType) = System.Windows.Forms.DialogResult.OK Then

                        If FileType = Importing.FileTypes.CSV Then

                            If _FormType = CRUDDialog.Type.ImportCreditCardTemplate Then

                                AdvantageFramework.Importing.Presentation.ImportCSVTemplateDialog.ShowFormDialog(AdvantageFramework.Importing.ImportTemplateTypes.ExpenseReport_CreditCard)

                            ElseIf _FormType = CRUDDialog.Type.ImportNonCreditCardTemplate Then

                                AdvantageFramework.Importing.Presentation.ImportCSVTemplateDialog.ShowFormDialog(AdvantageFramework.Importing.ImportTemplateTypes.ExpenseReport_NonCreditCard)

                            ElseIf _FormType = CRUDDialog.Type.ImportClearedChecksTemplate Then

                                AdvantageFramework.Importing.Presentation.ImportCSVTemplateDialog.ShowFormDialog(AdvantageFramework.Importing.ImportTemplateTypes.ClearedChecks_Default)

                            ElseIf _FormType = CRUDDialog.Type.ImportAccountsPayableGenericTemplate Then

                                AdvantageFramework.Importing.Presentation.ImportCSVTemplateDialog.ShowFormDialog(AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_Generic)

                            ElseIf _FormType = CRUDDialog.Type.ImportClientContactTemplate Then

                                AdvantageFramework.Importing.Presentation.ImportCSVTemplateDialog.ShowFormDialog(AdvantageFramework.Importing.ImportTemplateTypes.ClientContact_Default)

                            ElseIf _FormType = CRUDDialog.Type.ImportClientTemplate Then

                                AdvantageFramework.Importing.Presentation.ImportCSVTemplateDialog.ShowFormDialog(AdvantageFramework.Importing.ImportTemplateTypes.Client_Default)

                            ElseIf _FormType = CRUDDialog.Type.ImportDivisionTemplate Then

                                AdvantageFramework.Importing.Presentation.ImportCSVTemplateDialog.ShowFormDialog(AdvantageFramework.Importing.ImportTemplateTypes.Division_Default)

                            ElseIf _FormType = CRUDDialog.Type.ImportProductTemplate Then

                                AdvantageFramework.Importing.Presentation.ImportCSVTemplateDialog.ShowFormDialog(AdvantageFramework.Importing.ImportTemplateTypes.Product_Default)

                            ElseIf _FormType = CRUDDialog.Type.ImportAccountsReceivableTemplate Then

                                AdvantageFramework.Importing.Presentation.ImportCSVTemplateDialog.ShowFormDialog(AdvantageFramework.Importing.ImportTemplateTypes.AccountsReceivable_Default)

                            ElseIf _FormType = CRUDDialog.Type.ImportFunctionTemplate Then

                                AdvantageFramework.Importing.Presentation.ImportCSVTemplateDialog.ShowFormDialog(AdvantageFramework.Importing.ImportTemplateTypes.Function_Default)

                            ElseIf _FormType = CRUDDialog.Type.ImportChartOfAccountTemplate Then

                                AdvantageFramework.Importing.Presentation.ImportCSVTemplateDialog.ShowFormDialog(AdvantageFramework.Importing.ImportTemplateTypes.ChartOfAccounts_Default)

                            ElseIf _FormType = CRUDDialog.Type.ImportPTOTemplate Then

                                AdvantageFramework.Importing.Presentation.ImportCSVTemplateDialog.ShowFormDialog(AdvantageFramework.Importing.ImportTemplateTypes.PTO_Default)

                            ElseIf _FormType = CRUDDialog.Type.ImportJournalEntryTemplate Then

                                AdvantageFramework.Importing.Presentation.ImportCSVTemplateDialog.ShowFormDialog(AdvantageFramework.Importing.ImportTemplateTypes.JournalEntry_Default)

                            End If

                        Else

                            If _FormType = CRUDDialog.Type.ImportCreditCardTemplate Then

                                AdvantageFramework.Importing.Presentation.ImportFixedTemplateDialog.ShowFormDialog(AdvantageFramework.Importing.ImportTemplateTypes.ExpenseReport_CreditCard)

                            ElseIf _FormType = CRUDDialog.Type.ImportNonCreditCardTemplate Then

                                AdvantageFramework.Importing.Presentation.ImportFixedTemplateDialog.ShowFormDialog(AdvantageFramework.Importing.ImportTemplateTypes.ExpenseReport_NonCreditCard)

                            ElseIf _FormType = CRUDDialog.Type.ImportClearedChecksTemplate Then

                                AdvantageFramework.Importing.Presentation.ImportFixedTemplateDialog.ShowFormDialog(AdvantageFramework.Importing.ImportTemplateTypes.ClearedChecks_Default)

                            ElseIf _FormType = CRUDDialog.Type.ImportAccountsPayableGenericTemplate Then

                                AdvantageFramework.Importing.Presentation.ImportFixedTemplateDialog.ShowFormDialog(AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_Generic)

                            ElseIf _FormType = CRUDDialog.Type.ImportClientContactTemplate Then

                                AdvantageFramework.Importing.Presentation.ImportFixedTemplateDialog.ShowFormDialog(AdvantageFramework.Importing.ImportTemplateTypes.ClientContact_Default)

                            ElseIf _FormType = CRUDDialog.Type.ImportClientTemplate Then

                                AdvantageFramework.Importing.Presentation.ImportFixedTemplateDialog.ShowFormDialog(AdvantageFramework.Importing.ImportTemplateTypes.Client_Default)

                            ElseIf _FormType = CRUDDialog.Type.ImportDivisionTemplate Then

                                AdvantageFramework.Importing.Presentation.ImportFixedTemplateDialog.ShowFormDialog(AdvantageFramework.Importing.ImportTemplateTypes.Division_Default)

                            ElseIf _FormType = CRUDDialog.Type.ImportProductTemplate Then

                                AdvantageFramework.Importing.Presentation.ImportFixedTemplateDialog.ShowFormDialog(AdvantageFramework.Importing.ImportTemplateTypes.Product_Default)

                            ElseIf _FormType = CRUDDialog.Type.ImportAccountsReceivableTemplate Then

                                AdvantageFramework.Importing.Presentation.ImportFixedTemplateDialog.ShowFormDialog(AdvantageFramework.Importing.ImportTemplateTypes.AccountsReceivable_Default)

                            ElseIf _FormType = CRUDDialog.Type.ImportFunctionTemplate Then

                                AdvantageFramework.Importing.Presentation.ImportFixedTemplateDialog.ShowFormDialog(AdvantageFramework.Importing.ImportTemplateTypes.Function_Default)

                            ElseIf _FormType = CRUDDialog.Type.ImportChartOfAccountTemplate Then

                                AdvantageFramework.Importing.Presentation.ImportFixedTemplateDialog.ShowFormDialog(AdvantageFramework.Importing.ImportTemplateTypes.ChartOfAccounts_Default)

                            ElseIf _FormType = CRUDDialog.Type.ImportPTOTemplate Then

                                AdvantageFramework.Importing.Presentation.ImportFixedTemplateDialog.ShowFormDialog(AdvantageFramework.Importing.ImportTemplateTypes.PTO_Default)

                            ElseIf _FormType = CRUDDialog.Type.ImportJournalEntryTemplate Then

                                AdvantageFramework.Importing.Presentation.ImportFixedTemplateDialog.ShowFormDialog(AdvantageFramework.Importing.ImportTemplateTypes.JournalEntry_Default)

                            End If

                        End If

                    End If

                Case Type.ExportTemplate

                    AdvantageFramework.Exporting.Presentation.ExportTemplateEditDialog.ShowFormDialog(_ParameterDictionary("ExportType"), 0)

                Case Type.RecordSource

                    AdvantageFramework.Importing.Presentation.RecordSourceEditDialog.ShowFormDialog(0)

                Case Type.EmployeeHRHistory

                    AdvantageFramework.Maintenance.Accounting.Presentation.EmployeeHRHistoryDialog.ShowFormDialog(0, _ParameterDictionary("EmployeeCode").ToString)

                Case Type.ImportDigitalResultsTemplate

                    AdvantageFramework.Importing.Presentation.ImportCSVTemplateDialog.ShowFormDialog(AdvantageFramework.Importing.ImportTemplateTypes.DigitalResults_Default)

                Case Type.CashReceiptTemplate

                    AdvantageFramework.Importing.Presentation.ImportCSVTemplateDialog.ShowFormDialog(AdvantageFramework.Importing.ImportTemplateTypes.CashReceipt_Generic)

                Case Type.ImportAccountsReceivableCustomTemplate

                    AdvantageFramework.Importing.Presentation.ImportCSVTemplateDialog.ShowFormDialog(AdvantageFramework.Importing.ImportTemplateTypes.AccountsReceivable_Custom)

                Case Type.ImportAccountsPayableCustomTemplate

                    AdvantageFramework.Importing.Presentation.ImportCSVTemplateDialog.ShowFormDialog(AdvantageFramework.Importing.ImportTemplateTypes.AccountsPayable_Custom)

                Case Type.EmployeeHours

                    AdvantageFramework.Importing.Presentation.ImportCSVTemplateDialog.ShowFormDialog(AdvantageFramework.Importing.ImportTemplateTypes.Employee_Hours)

                Case Type.AdNumber

                    If _ParameterDictionary IsNot Nothing AndAlso _ParameterDictionary.Count > 0 Then

                        ClientCode = _ParameterDictionary("ClientCode")

                        AdvantageFramework.Media.Presentation.MediaPlanDetailLevelLineTagAddDialog.ShowFormDialog(AdvantageFramework.MediaPlanning.TagTypes.AdNumber, ClientCode, Nothing, Nothing, Nothing)

                    End If

                Case Type.AdSizeCode

                    If _ParameterDictionary IsNot Nothing AndAlso _ParameterDictionary.Count > 0 Then

                        MediaType = _ParameterDictionary("MediaType")

                        AdvantageFramework.Media.Presentation.MediaPlanDetailLevelLineTagAddDialog.ShowFormDialog(AdvantageFramework.MediaPlanning.TagTypes.AdSize, Nothing, MediaType, Nothing, Nothing)

                    End If

            End Select

            RefreshCRUD()

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonForm_Close_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Close.Click

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub
        Private Sub ButtonForm_Copy_Click(sender As Object, e As EventArgs) Handles ButtonForm_Copy.Click

            'objects
            Dim NewImportTemplateID As Short = Nothing
            Dim NewExportTemplateID As Integer = 0
            Dim Name As String = ""

            Select Case _FormType

                Case Type.ImportAccountsPayableGenericTemplate

                    If AdvantageFramework.Importing.Presentation.ImportTemplateCopyDialog.ShowFormDialog(DataGridViewForm_Objects.GetFirstSelectedRowBookmarkValue, Importing.ImportTemplateTypes.AccountsPayable_Generic, NewImportTemplateID) = System.Windows.Forms.DialogResult.OK Then

                        RefreshCRUD()

                        DataGridViewForm_Objects.SelectRow(NewImportTemplateID)

                    End If

                Case Type.ImportClearedChecksTemplate

                    If AdvantageFramework.Importing.Presentation.ImportTemplateCopyDialog.ShowFormDialog(DataGridViewForm_Objects.GetFirstSelectedRowBookmarkValue, Importing.ImportTemplateTypes.ClearedChecks_Default, NewImportTemplateID) = System.Windows.Forms.DialogResult.OK Then

                        RefreshCRUD()

                        DataGridViewForm_Objects.SelectRow(NewImportTemplateID)

                    End If

                Case Type.ImportClientContactTemplate

                    If AdvantageFramework.Importing.Presentation.ImportTemplateCopyDialog.ShowFormDialog(DataGridViewForm_Objects.GetFirstSelectedRowBookmarkValue, Importing.ImportTemplateTypes.ClientContact_Default, NewImportTemplateID) = System.Windows.Forms.DialogResult.OK Then

                        RefreshCRUD()

                        DataGridViewForm_Objects.SelectRow(NewImportTemplateID)

                    End If

                Case Type.ImportClientTemplate

                    If AdvantageFramework.Importing.Presentation.ImportTemplateCopyDialog.ShowFormDialog(DataGridViewForm_Objects.GetFirstSelectedRowBookmarkValue, Importing.ImportTemplateTypes.Client_Default, NewImportTemplateID) = System.Windows.Forms.DialogResult.OK Then

                        RefreshCRUD()

                        DataGridViewForm_Objects.SelectRow(NewImportTemplateID)

                    End If

                Case Type.ImportDivisionTemplate

                    If AdvantageFramework.Importing.Presentation.ImportTemplateCopyDialog.ShowFormDialog(DataGridViewForm_Objects.GetFirstSelectedRowBookmarkValue, Importing.ImportTemplateTypes.Division_Default, NewImportTemplateID) = System.Windows.Forms.DialogResult.OK Then

                        RefreshCRUD()

                        DataGridViewForm_Objects.SelectRow(NewImportTemplateID)

                    End If

                Case Type.ImportCreditCardTemplate

                    If AdvantageFramework.Importing.Presentation.ImportTemplateCopyDialog.ShowFormDialog(DataGridViewForm_Objects.GetFirstSelectedRowBookmarkValue, Importing.ImportTemplateTypes.ExpenseReport_CreditCard, NewImportTemplateID) = System.Windows.Forms.DialogResult.OK Then

                        RefreshCRUD()

                        DataGridViewForm_Objects.SelectRow(NewImportTemplateID)

                    End If

                Case Type.ImportNonCreditCardTemplate

                    If AdvantageFramework.Importing.Presentation.ImportTemplateCopyDialog.ShowFormDialog(DataGridViewForm_Objects.GetFirstSelectedRowBookmarkValue, Importing.ImportTemplateTypes.ExpenseReport_NonCreditCard, NewImportTemplateID) = System.Windows.Forms.DialogResult.OK Then

                        RefreshCRUD()

                        DataGridViewForm_Objects.SelectRow(NewImportTemplateID)

                    End If

                Case Type.ImportProductTemplate

                    If AdvantageFramework.Importing.Presentation.ImportTemplateCopyDialog.ShowFormDialog(DataGridViewForm_Objects.GetFirstSelectedRowBookmarkValue, Importing.ImportTemplateTypes.Product_Default, NewImportTemplateID) = System.Windows.Forms.DialogResult.OK Then

                        RefreshCRUD()

                        DataGridViewForm_Objects.SelectRow(NewImportTemplateID)

                    End If

                Case Type.ExportTemplate

                    If AdvantageFramework.WinForm.Presentation.InputDialog.ShowFormDialog("Copy Export Template", "Enter Export Template Name:", "", Name, AdvantageFramework.Database.Entities.ExportTemplate.Properties.Name) = System.Windows.Forms.DialogResult.OK Then

                        If AdvantageFramework.Exporting.CopyExportTemplate(New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode), DataGridViewForm_Objects.GetFirstSelectedRowBookmarkValue, NewExportTemplateID, Name) Then

                            RefreshCRUD()

                            DataGridViewForm_Objects.SelectRow(NewExportTemplateID)

                        End If

                    End If

                Case Type.ImportAccountsReceivableTemplate

                    If AdvantageFramework.Importing.Presentation.ImportTemplateCopyDialog.ShowFormDialog(DataGridViewForm_Objects.GetFirstSelectedRowBookmarkValue, Importing.ImportTemplateTypes.AccountsReceivable_Default, NewImportTemplateID) = System.Windows.Forms.DialogResult.OK Then

                        RefreshCRUD()

                        DataGridViewForm_Objects.SelectRow(NewImportTemplateID)

                    End If

                Case Type.ImportFunctionTemplate

                    If AdvantageFramework.Importing.Presentation.ImportTemplateCopyDialog.ShowFormDialog(DataGridViewForm_Objects.GetFirstSelectedRowBookmarkValue, Importing.ImportTemplateTypes.Function_Default, NewImportTemplateID) = System.Windows.Forms.DialogResult.OK Then

                        RefreshCRUD()

                        DataGridViewForm_Objects.SelectRow(NewImportTemplateID)

                    End If

                Case Type.ImportChartOfAccountTemplate

                    If AdvantageFramework.Importing.Presentation.ImportTemplateCopyDialog.ShowFormDialog(DataGridViewForm_Objects.GetFirstSelectedRowBookmarkValue, Importing.ImportTemplateTypes.ChartOfAccounts_Default, NewImportTemplateID) = System.Windows.Forms.DialogResult.OK Then

                        RefreshCRUD()

                        DataGridViewForm_Objects.SelectRow(NewImportTemplateID)

                    End If

                Case Type.ImportDigitalResultsTemplate

                    If AdvantageFramework.Importing.Presentation.ImportTemplateCopyDialog.ShowFormDialog(DataGridViewForm_Objects.GetFirstSelectedRowBookmarkValue, Importing.ImportTemplateTypes.DigitalResults_Default, NewImportTemplateID) = System.Windows.Forms.DialogResult.OK Then

                        RefreshCRUD()

                        DataGridViewForm_Objects.SelectRow(NewImportTemplateID)

                    End If

                Case Type.AvalaraTaxTemplate

                    If AdvantageFramework.Importing.Presentation.ImportTemplateCopyDialog.ShowFormDialog(DataGridViewForm_Objects.GetFirstSelectedRowBookmarkValue, Importing.ImportTemplateTypes.AvalaraTaxCode_Default, NewImportTemplateID) = System.Windows.Forms.DialogResult.OK Then

                        RefreshCRUD()

                        DataGridViewForm_Objects.SelectRow(NewImportTemplateID)

                    End If

                Case Type.CashReceiptTemplate

                    If AdvantageFramework.Importing.Presentation.ImportTemplateCopyDialog.ShowFormDialog(DataGridViewForm_Objects.GetFirstSelectedRowBookmarkValue, Importing.ImportTemplateTypes.CashReceipt_Generic, NewImportTemplateID) = System.Windows.Forms.DialogResult.OK Then

                        RefreshCRUD()

                        DataGridViewForm_Objects.SelectRow(NewImportTemplateID)

                    End If

                Case Type.ImportPTOTemplate

                    If AdvantageFramework.Importing.Presentation.ImportTemplateCopyDialog.ShowFormDialog(DataGridViewForm_Objects.GetFirstSelectedRowBookmarkValue, Importing.ImportTemplateTypes.PTO_Default, NewImportTemplateID) = System.Windows.Forms.DialogResult.OK Then

                        RefreshCRUD()

                        DataGridViewForm_Objects.SelectRow(NewImportTemplateID)

                    End If

                Case Type.ImportJournalEntryTemplate

                    If AdvantageFramework.Importing.Presentation.ImportTemplateCopyDialog.ShowFormDialog(DataGridViewForm_Objects.GetFirstSelectedRowBookmarkValue, Importing.ImportTemplateTypes.JournalEntry_Default, NewImportTemplateID) = System.Windows.Forms.DialogResult.OK Then

                        RefreshCRUD()

                        DataGridViewForm_Objects.SelectRow(NewImportTemplateID)

                    End If

                Case Type.EmployeeHours

                    If AdvantageFramework.Importing.Presentation.ImportTemplateCopyDialog.ShowFormDialog(DataGridViewForm_Objects.GetFirstSelectedRowBookmarkValue, Importing.ImportTemplateTypes.Employee_Hours, NewImportTemplateID) = System.Windows.Forms.DialogResult.OK Then

                        RefreshCRUD()

                        DataGridViewForm_Objects.SelectRow(NewImportTemplateID)

                    End If

            End Select

        End Sub
        Private Sub ButtonForm_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Delete.Click

            'objects
            Dim DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport = Nothing
            Dim UserDefinedReport As AdvantageFramework.Reporting.Database.Entities.UserDefinedReport = Nothing
            Dim ServiceFeeReconciliationReport As AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationReport = Nothing
            Dim ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate = Nothing
            Dim ExportTemplate As AdvantageFramework.Database.Entities.ExportTemplate = Nothing
            Dim EmployeeRateHistory As AdvantageFramework.Database.Entities.EmployeeRateHistory = Nothing
            Dim Message As String = ""
            Dim MessageTitle As String = ""

            Select Case _FormType

                Case Type.EmployeeHRHistory

                    Message = "Are you sure you want to delete this Employee H/R History?"
                    MessageTitle = "Employee H/R History"

                Case Else

                    Message = "Are you sure you want to delete this item?"
                    MessageTitle = AdvantageFramework.StringUtilities.GetNameAsWords(_FormType.ToString)

            End Select

            If AdvantageFramework.Navigation.ShowMessageBox(Message, AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, MessageTitle) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                If _FormType = Type.DatabaseProfile Then

                    AdvantageFramework.Database.DeleteDatabaseProfile(DataGridViewForm_Objects.GetFirstSelectedRowBookmarkValue(1))

                Else

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                Select Case _FormType

                                    Case Type.DynamicReport

                                        DynamicReport = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.LoadByDynamicReportID(ReportingDbContext, DataGridViewForm_Objects.GetFirstSelectedRowBookmarkValue)

                                        AdvantageFramework.Reporting.Database.Procedures.DynamicReport.Delete(ReportingDbContext, DataContext, DynamicReport)

                                    Case Type.UserDefinedReport

                                        UserDefinedReport = AdvantageFramework.Reporting.Database.Procedures.UserDefinedReport.LoadByUserDefinedReportID(ReportingDbContext, DataGridViewForm_Objects.GetFirstSelectedRowBookmarkValue)

                                        AdvantageFramework.Reporting.Database.Procedures.UserDefinedReport.Delete(ReportingDbContext, UserDefinedReport)

                                    Case Type.ServiceFeeReconciliationReport

                                        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                            ServiceFeeReconciliationReport = AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationReport.LoadByServiceFeeReconciliationReportID(SecurityDbContext, DataGridViewForm_Objects.GetFirstSelectedRowBookmarkValue)

                                            AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationReport.Delete(SecurityDbContext, ServiceFeeReconciliationReport)

                                        End Using

                                    Case Type.ImportCreditCardTemplate

                                        ImportTemplate = AdvantageFramework.Database.Procedures.ImportTemplate.LoadByImportTemplateID(DbContext, DataGridViewForm_Objects.GetFirstSelectedRowBookmarkValue)

                                        AdvantageFramework.Database.Procedures.ImportTemplate.Delete(DbContext, ImportTemplate)

                                    Case Type.ImportNonCreditCardTemplate

                                        ImportTemplate = AdvantageFramework.Database.Procedures.ImportTemplate.LoadByImportTemplateID(DbContext, DataGridViewForm_Objects.GetFirstSelectedRowBookmarkValue)

                                        AdvantageFramework.Database.Procedures.ImportTemplate.Delete(DbContext, ImportTemplate)

                                    Case Type.ImportClearedChecksTemplate

                                        ImportTemplate = AdvantageFramework.Database.Procedures.ImportTemplate.LoadByImportTemplateID(DbContext, DataGridViewForm_Objects.GetFirstSelectedRowBookmarkValue)

                                        AdvantageFramework.Database.Procedures.ImportTemplate.Delete(DbContext, ImportTemplate)

                                    Case Type.ImportAccountsPayableGenericTemplate

                                        ImportTemplate = AdvantageFramework.Database.Procedures.ImportTemplate.LoadByImportTemplateID(DbContext, DataGridViewForm_Objects.GetFirstSelectedRowBookmarkValue)

                                        AdvantageFramework.Database.Procedures.ImportTemplate.Delete(DbContext, ImportTemplate)

                                    Case Type.ExportTemplate

                                        ExportTemplate = AdvantageFramework.Database.Procedures.ExportTemplate.LoadByExportTemplateID(DbContext, DataGridViewForm_Objects.GetFirstSelectedRowBookmarkValue)

                                        AdvantageFramework.Database.Procedures.ExportTemplate.Delete(DbContext, ExportTemplate)

                                    Case Type.ImportClientContactTemplate

                                        ImportTemplate = AdvantageFramework.Database.Procedures.ImportTemplate.LoadByImportTemplateID(DbContext, DataGridViewForm_Objects.GetFirstSelectedRowBookmarkValue)

                                        AdvantageFramework.Database.Procedures.ImportTemplate.Delete(DbContext, ImportTemplate)

                                    Case Type.ImportClientTemplate

                                        ImportTemplate = AdvantageFramework.Database.Procedures.ImportTemplate.LoadByImportTemplateID(DbContext, DataGridViewForm_Objects.GetFirstSelectedRowBookmarkValue)

                                        AdvantageFramework.Database.Procedures.ImportTemplate.Delete(DbContext, ImportTemplate)

                                    Case Type.ImportDivisionTemplate

                                        ImportTemplate = AdvantageFramework.Database.Procedures.ImportTemplate.LoadByImportTemplateID(DbContext, DataGridViewForm_Objects.GetFirstSelectedRowBookmarkValue)

                                        AdvantageFramework.Database.Procedures.ImportTemplate.Delete(DbContext, ImportTemplate)

                                    Case Type.ImportProductTemplate

                                        ImportTemplate = AdvantageFramework.Database.Procedures.ImportTemplate.LoadByImportTemplateID(DbContext, DataGridViewForm_Objects.GetFirstSelectedRowBookmarkValue)

                                        AdvantageFramework.Database.Procedures.ImportTemplate.Delete(DbContext, ImportTemplate)

                                    Case Type.ImportAccountsReceivableTemplate

                                        ImportTemplate = AdvantageFramework.Database.Procedures.ImportTemplate.LoadByImportTemplateID(DbContext, DataGridViewForm_Objects.GetFirstSelectedRowBookmarkValue)

                                        AdvantageFramework.Database.Procedures.ImportTemplate.Delete(DbContext, ImportTemplate)

                                    Case Type.ImportFunctionTemplate

                                        ImportTemplate = AdvantageFramework.Database.Procedures.ImportTemplate.LoadByImportTemplateID(DbContext, DataGridViewForm_Objects.GetFirstSelectedRowBookmarkValue)

                                        AdvantageFramework.Database.Procedures.ImportTemplate.Delete(DbContext, ImportTemplate)

                                    Case Type.ImportChartOfAccountTemplate

                                        ImportTemplate = AdvantageFramework.Database.Procedures.ImportTemplate.LoadByImportTemplateID(DbContext, DataGridViewForm_Objects.GetFirstSelectedRowBookmarkValue)

                                        AdvantageFramework.Database.Procedures.ImportTemplate.Delete(DbContext, ImportTemplate)

                                    Case Type.EmployeeHRHistory

                                        EmployeeRateHistory = AdvantageFramework.Database.Procedures.EmployeeRateHistory.LoadByEmployeeRateHistoryID(DbContext, DataGridViewForm_Objects.GetFirstSelectedRowBookmarkValue)

                                        AdvantageFramework.Database.Procedures.EmployeeRateHistory.Delete(DbContext, EmployeeRateHistory)

                                    Case Type.ImportDigitalResultsTemplate

                                        ImportTemplate = AdvantageFramework.Database.Procedures.ImportTemplate.LoadByImportTemplateID(DbContext, DataGridViewForm_Objects.GetFirstSelectedRowBookmarkValue)

                                        AdvantageFramework.Database.Procedures.ImportTemplate.Delete(DbContext, ImportTemplate)

                                    Case Type.AvalaraTaxTemplate

                                        ImportTemplate = AdvantageFramework.Database.Procedures.ImportTemplate.LoadByImportTemplateID(DbContext, DataGridViewForm_Objects.GetFirstSelectedRowBookmarkValue)

                                        AdvantageFramework.Database.Procedures.ImportTemplate.Delete(DbContext, ImportTemplate)

                                    Case Type.CashReceiptTemplate

                                        ImportTemplate = AdvantageFramework.Database.Procedures.ImportTemplate.LoadByImportTemplateID(DbContext, DataGridViewForm_Objects.GetFirstSelectedRowBookmarkValue)

                                        AdvantageFramework.Database.Procedures.ImportTemplate.Delete(DbContext, ImportTemplate)

                                    Case Type.ImportPTOTemplate

                                        ImportTemplate = AdvantageFramework.Database.Procedures.ImportTemplate.LoadByImportTemplateID(DbContext, DataGridViewForm_Objects.GetFirstSelectedRowBookmarkValue)

                                        AdvantageFramework.Database.Procedures.ImportTemplate.Delete(DbContext, ImportTemplate)

                                    Case Type.ImportJournalEntryTemplate

                                        ImportTemplate = AdvantageFramework.Database.Procedures.ImportTemplate.LoadByImportTemplateID(DbContext, DataGridViewForm_Objects.GetFirstSelectedRowBookmarkValue)

                                        AdvantageFramework.Database.Procedures.ImportTemplate.Delete(DbContext, ImportTemplate)

                                    Case Type.EmployeeHours

                                        ImportTemplate = AdvantageFramework.Database.Procedures.ImportTemplate.LoadByImportTemplateID(DbContext, DataGridViewForm_Objects.GetFirstSelectedRowBookmarkValue)

                                        AdvantageFramework.Database.Procedures.ImportTemplate.Delete(DbContext, ImportTemplate)

                                End Select

                            End Using

                        End Using

                    End Using

                End If

            End If

            RefreshCRUD()

        End Sub
        Private Sub ButtonForm_Edit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Edit.Click

            'objects
            Dim DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport = Nothing
            Dim UserDefinedReport As AdvantageFramework.Reporting.Database.Entities.UserDefinedReport = Nothing
            Dim Description As String = ""
            Dim UserDefinedReportCategoryID As Nullable(Of Integer) = 0
            Dim Division As AdvantageFramework.Database.Entities.Division = Nothing
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing
            Dim ServiceFeeReconciliationReport As AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationReport = Nothing
            Dim ImportTemplateID As Short = Nothing
            Dim ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate = Nothing
            Dim ExportTemplateID As Integer = Nothing
            Dim ExportTemplate As AdvantageFramework.Database.Entities.ExportTemplate = Nothing
            Dim RecordSourceID As Integer = Nothing

            If _FormType = Type.DatabaseProfile Then

                AdvantageFramework.Database.Presentation.DatabaseProfileDialog.ShowFormDialog(DataGridViewForm_Objects.GetFirstSelectedRowDataBoundItem)

            Else

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Select Case _FormType

                            Case Type.DynamicReport

                                DynamicReport = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.LoadByDynamicReportID(ReportingDbContext, DataGridViewForm_Objects.GetFirstSelectedRowBookmarkValue)

                                If DynamicReport IsNot Nothing Then

                                    Description = DynamicReport.Description
                                    UserDefinedReportCategoryID = DynamicReport.UserDefinedReportCategoryID

                                    If AdvantageFramework.Desktop.Presentation.UserDefinedReportEditDialog.ShowFormDialog(Reporting.UDRTypes.Dynamic, DynamicReport.ID, DynamicReport.Type, Description, UserDefinedReportCategoryID, False) = System.Windows.Forms.DialogResult.OK Then

                                        DynamicReport.Description = Description
                                        DynamicReport.UserDefinedReportCategoryID = UserDefinedReportCategoryID
                                        DynamicReport.UpdatedDate = Now
                                        DynamicReport.UpdatedByUserCode = Me.Session.UserCode

                                        AdvantageFramework.Reporting.Database.Procedures.DynamicReport.Update(ReportingDbContext, DynamicReport)

                                    End If

                                End If

                            Case Type.UserDefinedReport

                                UserDefinedReport = AdvantageFramework.Reporting.Database.Procedures.UserDefinedReport.LoadByUserDefinedReportID(ReportingDbContext, DataGridViewForm_Objects.GetFirstSelectedRowBookmarkValue)

                                If UserDefinedReport IsNot Nothing Then

                                    Description = UserDefinedReport.Description
                                    UserDefinedReportCategoryID = UserDefinedReport.UserDefinedReportCategoryID

                                    If AdvantageFramework.Desktop.Presentation.UserDefinedReportEditDialog.ShowFormDialog(Reporting.UDRTypes.Advanced, UserDefinedReport.ID, UserDefinedReport.AdvancedReportWriterType, Description, UserDefinedReportCategoryID, False) = System.Windows.Forms.DialogResult.OK Then

                                        UserDefinedReport.Description = Description
                                        UserDefinedReport.UserDefinedReportCategoryID = UserDefinedReportCategoryID
                                        UserDefinedReport.UpdatedDate = Now
                                        UserDefinedReport.UpdatedByUserCode = Me.Session.UserCode

                                        AdvantageFramework.Reporting.Database.Procedures.UserDefinedReport.Update(ReportingDbContext, UserDefinedReport)

                                    End If

                                End If

                            Case Type.Division

                                DivisionCode = DataGridViewForm_Objects.CurrentView.GetRowCellValue(DataGridViewForm_Objects.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.Division.Properties.Code.ToString)
                                ClientCode = DataGridViewForm_Objects.CurrentView.GetRowCellValue(DataGridViewForm_Objects.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.Division.Properties.ClientCode.ToString)

                                Division = AdvantageFramework.Database.Procedures.Division.LoadByClientAndDivisionCode(DbContext, ClientCode, DivisionCode)

                                If Division IsNot Nothing Then

                                    AdvantageFramework.Maintenance.Client.Presentation.DivisionEditDialog.ShowFormDialog(False, ClientCode, DivisionCode)

                                End If

                            Case Type.Product

                                ProductCode = DataGridViewForm_Objects.CurrentView.GetRowCellValue(DataGridViewForm_Objects.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.Product.Properties.Code.ToString)
                                DivisionCode = DataGridViewForm_Objects.CurrentView.GetRowCellValue(DataGridViewForm_Objects.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.Product.Properties.DivisionCode.ToString)
                                ClientCode = DataGridViewForm_Objects.CurrentView.GetRowCellValue(DataGridViewForm_Objects.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.Product.Properties.ClientCode.ToString)

                                Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, ClientCode, DivisionCode, ProductCode)

                                If Product IsNot Nothing Then

                                    AdvantageFramework.Maintenance.Client.Presentation.ProductEditDialog.ShowFormDialog(False, ClientCode, DivisionCode, ProductCode)

                                End If

                            Case Type.ServiceFeeReconciliationReport

                                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                    ServiceFeeReconciliationReport = AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationReport.LoadByServiceFeeReconciliationReportID(SecurityDbContext, DataGridViewForm_Objects.GetFirstSelectedRowBookmarkValue)

                                    If ServiceFeeReconciliationReport IsNot Nothing Then

                                        If AdvantageFramework.WinForm.Presentation.InputDialog.ShowFormDialog("Edit Report", "Enter Report Template Description:", ServiceFeeReconciliationReport.Description, Description, AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationReport.Properties.Description) = System.Windows.Forms.DialogResult.OK Then

                                            ServiceFeeReconciliationReport.Description = Description
                                            ServiceFeeReconciliationReport.UpdatedDate = Now
                                            ServiceFeeReconciliationReport.UpdatedByUserCode = Me.Session.UserCode

                                            AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationReport.Update(SecurityDbContext, ServiceFeeReconciliationReport)

                                        End If

                                    End If

                                End Using

                            Case Type.ImportCreditCardTemplate

                                EditImportTemplate(DbContext, Importing.ImportTemplateTypes.ExpenseReport_CreditCard)

                            Case Type.ImportNonCreditCardTemplate

                                EditImportTemplate(DbContext, Importing.ImportTemplateTypes.ExpenseReport_NonCreditCard)

                            Case Type.ImportClearedChecksTemplate

                                EditImportTemplate(DbContext, Importing.ImportTemplateTypes.ClearedChecks_Default)

                            Case Type.ImportAccountsPayableGenericTemplate

                                EditImportTemplate(DbContext, Importing.ImportTemplateTypes.AccountsPayable_Generic)

                            Case Type.ExportTemplate

                                ExportTemplateID = DataGridViewForm_Objects.CurrentView.GetRowCellValue(DataGridViewForm_Objects.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.ExportTemplate.Properties.ID.ToString)

                                ExportTemplate = AdvantageFramework.Database.Procedures.ExportTemplate.LoadByExportTemplateID(DbContext, ExportTemplateID)

                                If ExportTemplate IsNot Nothing Then

                                    If ExportTemplate.IsSystemTemplate.GetValueOrDefault(False) = True Then

                                        AdvantageFramework.Exporting.Presentation.ExportSystemTemplateEditDialog.ShowFormDialog(_ParameterDictionary("ExportType"), ExportTemplateID)

                                    Else

                                        AdvantageFramework.Exporting.Presentation.ExportTemplateEditDialog.ShowFormDialog(_ParameterDictionary("ExportType"), ExportTemplateID)

                                    End If

                                End If

                            Case Type.ImportClientContactTemplate

                                EditImportTemplate(DbContext, Importing.ImportTemplateTypes.ClientContact_Default)

                            Case Type.ImportClientTemplate

                                EditImportTemplate(DbContext, Importing.ImportTemplateTypes.Client_Default)

                            Case Type.ImportDivisionTemplate

                                EditImportTemplate(DbContext, Importing.ImportTemplateTypes.Division_Default)

                            Case Type.ImportProductTemplate

                                EditImportTemplate(DbContext, Importing.ImportTemplateTypes.Product_Default)

                            Case Type.ImportAccountsPayableStrataFixedInternet

                                EditImportTemplate(DbContext, Importing.ImportTemplateTypes.AccountsPayable_StrataFixedInternet)

                            Case Type.ImportAccountsPayableStrataFixedBroadcast

                                EditImportTemplate(DbContext, Importing.ImportTemplateTypes.AccountsPayable_StrataFixedBroadcast)

                            Case Type.ImportAccountsPayableStrataFixedPrint

                                EditImportTemplate(DbContext, Importing.ImportTemplateTypes.AccountsPayable_StrataFixedPrint)

                            Case Type.RecordSource

                                AdvantageFramework.Importing.Presentation.RecordSourceEditDialog.ShowFormDialog(DataGridViewForm_Objects.GetFirstSelectedRowBookmarkValue(0))

                            Case Type.ImportAccountsReceivableTemplate

                                EditImportTemplate(DbContext, Importing.ImportTemplateTypes.AccountsReceivable_Default)

                            Case Type.ImportFunctionTemplate

                                EditImportTemplate(DbContext, Importing.ImportTemplateTypes.Function_Default)

                            Case Type.ImportChartOfAccountTemplate

                                EditImportTemplate(DbContext, Importing.ImportTemplateTypes.ChartOfAccounts_Default)

                            Case Type.EmployeeHRHistory

                                AdvantageFramework.Maintenance.Accounting.Presentation.EmployeeHRHistoryDialog.ShowFormDialog(DataGridViewForm_Objects.GetFirstSelectedRowBookmarkValue(0), _ParameterDictionary("EmployeeCode").ToString)

                            Case Type.ImportDigitalResultsTemplate

                                EditImportTemplate(DbContext, Importing.ImportTemplateTypes.DigitalResults_Default)

                            Case Type.AvalaraTaxTemplate

                                EditImportTemplate(DbContext, Importing.ImportTemplateTypes.AvalaraTaxCode_Default)

                            Case Type.CashReceiptTemplate

                                EditImportTemplate(DbContext, Importing.ImportTemplateTypes.CashReceipt_Generic)

                            Case Type.CashReceiptCustomTemplate

                                EditImportTemplate(DbContext, Importing.ImportTemplateTypes.CashReceipt_Custom)

                            Case Type.ImportAccountsReceivableCustomTemplate

                                EditImportTemplate(DbContext, Importing.ImportTemplateTypes.AccountsReceivable_Custom)

                            Case Type.ImportAccountsPayableCustomTemplate

                                EditImportTemplate(DbContext, Importing.ImportTemplateTypes.AccountsPayable_Custom)

                            Case Type.ImportPTOTemplate

                                EditImportTemplate(DbContext, Importing.ImportTemplateTypes.PTO_Default)

                            Case Type.ImportJournalEntryTemplate

                                EditImportTemplate(DbContext, Importing.ImportTemplateTypes.JournalEntry_Default)

                            Case Type.ImportJournalEntryMOGLIFACETemplate

                                EditImportTemplate(DbContext, Importing.ImportTemplateTypes.JournalEntry_MOGLIFACE)

                            Case Type.ImportAccountsPayable4AsBroadcast

                                EditImportTemplate(DbContext, Importing.ImportTemplateTypes.AccountsPayable_4AsBroadcast)

                            Case Type.EmployeeHours

                                EditImportTemplate(DbContext, Importing.ImportTemplateTypes.Employee_Hours)

                            Case Type.ImportMediaRFPTemplate

                                EditImportTemplate(DbContext, Importing.ImportTemplateTypes.MediaRFP_4As)

                        End Select

                    End Using

                End Using

            End If

            RefreshCRUD()

        End Sub
        Private Sub ButtonForm_Select_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Select.Click

            SelectRows()

        End Sub
        Private Sub DataGridViewForm_Objects_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_Objects.CellValueChangedEvent

            'objects
            Dim DatabaseProfile As AdvantageFramework.Database.DatabaseProfile = Nothing

            If _FormType = Type.DatabaseProfile Then

                DatabaseProfile = DataGridViewForm_Objects.GetRowDataBoundItem(e.RowHandle)

                If DatabaseProfile IsNot Nothing Then

                    AdvantageFramework.Database.SaveDatabaseProfile(DatabaseProfile, True)

                End If

            End If

        End Sub
        Private Sub ButtonForm_Exclude_Click(sender As Object, e As EventArgs) Handles ButtonForm_Exclude.Click

            AdvantageFramework.Importing.Presentation.ImportExcludeDialog.ShowFormDialog(DataGridViewForm_Objects.CurrentView.GetRowCellValue(DataGridViewForm_Objects.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.ImportTemplate.Properties.ID.ToString))

        End Sub

#End Region

#End Region

    End Class

End Namespace
