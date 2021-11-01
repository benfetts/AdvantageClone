Namespace WinForm.Presentation.Controls

    Public Class SubItemGridLookUpEditControl
        Inherits DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum [Type]
            [Default]
            Client
            Division
            Product
            [Function]
            JobComponent
            Job
            PONumber
            POLineNumber
            SalesTax
            PTORule
            Office
            GeneralLedgerAccount
            AdSize
            ManagementLevel
            EstimateFunction
            Status
            WebSiteType
            EmployeeTitle
            Task
            Phase
            Employee
            EmployeeFunction
            MagazineOrderNumber
            MagazineOrderLineNumber
            Partner
            EmployeeCategory
            MediaType
            ExceedOption
            ExpenseFunction
            AdNumber
            SalesClassMediaType
            ClientContact
            ProductARAddressLookup
            ClientARAddressLookup
            DepartmentTeam
            Role
            EmployeeHRStatus
            EmployeeVendor
            POApprovalRule
            ReportMissingTime
            AlertGroup
            SalesClass
            YesNoSkip
            FeeTime
            MarkupTaxFlags
            FunctionType
            FunctionHeading
            Vendor
            BeforeAfter
            ResourceTaskCondition
            VendorTerm
            ImportVendorCategory
            RateBy
            RateType
            VendorFunction
            ImportTemplateProperty
            ExpenseItemPayment
            IndirectCategoryType
            ServiceFeeType
            Bank
            Market
            Daypart
            JobVersionDatabaseType
            JobComponentID
            JobDescription
            JobComponentDescription
            MediaApprovalStatusPendingOnly
            NewspaperOrderNumber
            NewspaperOrderLineNumber
            ExpenseReportApprovedFlag
            ExpenseEmployee
            InternetOrderNumber
            InternetOrderLineNumber
            OutOfHomeOrderNumber
            OutOfHomeOrderLineNumber
            RadioOrderNumber
            RadioOrderLineNumber
            RadioOrderLegacyMonth
            RadioOrderLegacyYear
            TVOrderNumber
            TVOrderLineNumber
            TVOrderLegacyMonth
            TVOrderLegacyYear
            Affiliation
            DaypartType
            Competition
            ServiceFeeTypeID
            Cycle
            Blackplate
            CycleType
            AccountReceivable
            OfficeName
            DepartmentTeamName
            GeneralLedgerAccountDescription
            EnumDataTable
            EnumObject
            PostPeriod
            PostPeriodStatus
            AccountPayableImportMediaType
            AccountPayableImportMediaOrderNumber
            AccountPayableImportMediaOrderLineNumber
            MediaPlan
            MediaPlanDetail
            DateFormat
            CostType
            Location
            ProductCategory
            Campaign
            CampaignID
            AccountReceivableRecordType
            TaskStatus
            DaypartCode
            GeneralLedgerAccountTypes
            GeneralLedgerBalanceTypes
            CurrencyCode
            ProductionBillHoldStatus
            JobProcess
            ProductionReconcileStatus
            ServiceFeeFrequency
            InvoiceCategory
            CustomProductionInvoice
            CustomMagazineInvoice
            CustomNewspaperInvoice
            CustomInternetInvoice
            CustomOutdoorInvoice
            CustomRadioInvoice
            CustomTVInvoice
            InternetType
            JobProcessControl
            VendorServiceTaxType
            AvalaraTaxID
            OverheadAccountCode
            ProductionCustomInvoiceID
            MediaCustomInvoiceID
            BillingCoopCode
            EstimateCustomID
            ContactType
            AccountReceivableSequenceNumber
            VCCStatus
            EmployeeWithDepartmentAndOffice
            CashReceiptPaymentType
            OutOfHomeType
            DocumentType
            IOOrderNumber
            IOOrderLineNumber
            OrderProcess
            StateCode
            StateName
            IndirectCategory
            JobTemplateMapping
            GeneralLedgerSource
            BuyerEmployeeCode
            ClientPO
            CableNetworkStation
            ClientDiscount
            AccountPayableImportMediaOrderNumberAutoFill
            AlertTemplate
            AlertState
            CampaignID2
            MediaChannelID
            MediaTacticID
            Assignment
        End Enum

        Public Enum ExtraComboBoxItems
            [Nothing] = 0
            PleaseSelect = -1
            None = -2
            NullValue = -3
            AgencyDefault = -4
            Skip = -5
        End Enum

#End Region

#Region " Variables "

        Protected _ControlType As SubItemGridLookUpEditControl.Type = SubItemGridLookUpEditControl.Type.Default
        Protected _Session As AdvantageFramework.Security.Session = Nothing
        Protected _ExtraComboBoxItem As ExtraComboBoxItems = ExtraComboBoxItems.Nothing
        Protected _IncludeInactive As Boolean = False
        Protected _ValueType As System.Type = Nothing
        Protected WithEvents _GridView As AdvantageFramework.WinForm.Presentation.Controls.GridView = Nothing
        Protected _CancelPopup As Boolean = False
        Protected _IsNewValue As Boolean = False
        Protected _AddedItemsToDataSource As Generic.List(Of Object) = Nothing
        Protected _GridLookUpEdit As DevExpress.XtraEditors.GridLookUpEdit = Nothing
        Protected _EnumType As System.Type = Nothing
        Protected _EnumObjects As Generic.List(Of AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute) = Nothing

#End Region

#Region " Properties "

        Public Property EnumType() As System.Type
            Get
                EnumType = _EnumType
            End Get
            Set(ByVal value As System.Type)
                _EnumType = value
            End Set
        End Property
        Public Property ValueType() As System.Type
            Get
                ValueType = _ValueType
            End Get
            Set(ByVal value As System.Type)
                _ValueType = value
            End Set
        End Property
        Public Property ControlType() As SubItemGridLookUpEditControl.Type
            Get
                ControlType = _ControlType
            End Get
            Set(ByVal value As SubItemGridLookUpEditControl.Type)
                _ControlType = value
                SetControlType()
            End Set
        End Property
        Public Property Session As AdvantageFramework.Security.Session
            Get
                Session = _Session
            End Get
            Set(ByVal value As AdvantageFramework.Security.Session)
                _Session = value
            End Set
        End Property
        Public Shadows Property DataSource() As Object
            Get
                DataSource = MyBase.DataSource
            End Get
            Set(ByVal value As Object)
                LoadDataSource(value)
            End Set
        End Property
        Public Property ExtraComboBoxItem() As ExtraComboBoxItems
            Get
                ExtraComboBoxItem = _ExtraComboBoxItem
            End Get
            Set(ByVal value As ExtraComboBoxItems)
                _ExtraComboBoxItem = value
            End Set
        End Property
        Public Property IncludeInactive() As Boolean
            Get
                IncludeInactive = _IncludeInactive
            End Get
            Set(ByVal value As Boolean)
                _IncludeInactive = value
            End Set
        End Property
        Public Property IsNewValue() As Boolean
            Get
                IsNewValue = _IsNewValue
            End Get
            Set(ByVal value As Boolean)
                _IsNewValue = value
            End Set
        End Property
        Public ReadOnly Property AddExtraComboBoxItem As Boolean
            Get

                If Me.ExtraComboBoxItem <> ExtraComboBoxItems.Nothing Then

                    AddExtraComboBoxItem = True

                Else

                    AddExtraComboBoxItem = False

                End If

            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            Me.LookAndFeel.SkinName = "Office 2016 Colorful"
            Me.LookAndFeel.UseDefaultLookAndFeel = False

            _GridView = New AdvantageFramework.WinForm.Presentation.Controls.GridView(True)
            Me.View = _GridView

            DirectCast(Me.View, AdvantageFramework.WinForm.Presentation.Controls.GridView).ControlType = DataGridView.Type.NonEditableGrid
            DirectCast(Me.View, AdvantageFramework.WinForm.Presentation.Controls.GridView).OptionsView.ShowFooter = False
            DirectCast(Me.View, AdvantageFramework.WinForm.Presentation.Controls.GridView).OptionsView.ShowViewCaption = False

            Me.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
            Me.View.OptionsView.ShowAutoFilterRow = True
            Me.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
            Me.ImmediatePopup = False
            Me.AutoComplete = False
            Me.ValidateOnEnterKey = True

            _AddedItemsToDataSource = New Generic.List(Of Object)

        End Sub
        Protected Overrides Sub Dispose(disposing As Boolean)
            _GridView.Dispose()
            MyBase.Dispose(disposing)
        End Sub
        Protected Sub LoadExtraComboItem(ByVal ExtraComboItem As ExtraComboBoxItems, ByRef BindingSource As System.Windows.Forms.BindingSource)

            If ExtraComboBoxItem = ExtraComboBoxItems.NullValue Then

                AdvantageFramework.WinForm.Presentation.Controls.AddComboItemToExistingDataSource(BindingSource, Me.DisplayMember, Me.ValueMember, "[None]", -3, True, True, _AddedItemsToDataSource)

            Else

                AdvantageFramework.WinForm.Presentation.Controls.AddComboItemToExistingDataSource(BindingSource, Me.DisplayMember, Me.ValueMember, "[" & AdvantageFramework.StringUtilities.GetNameAsWords(ExtraComboItem.ToString) & "]", AdvantageFramework.EnumUtilities.GetValue(ExtraComboItem.GetType, ExtraComboItem.ToString), True, True, _AddedItemsToDataSource)

            End If

        End Sub
        Public Sub AddComboItemToExistingDatasource(ByVal DisplayValue As String, ByVal Value As String, ByVal InsertInFirstPosition As Boolean, Optional ByVal IsExtraComboItem As Boolean = False)

            AdvantageFramework.WinForm.Presentation.Controls.AddComboItemToExistingDataSource(Me.DataSource, Me.DisplayMember, Me.ValueMember, DisplayValue, Value, InsertInFirstPosition, IsExtraComboItem, _AddedItemsToDataSource)

        End Sub
        Protected Sub LoadDataSource(ByVal Value As Object)

            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing

            If Me.DesignMode = False Then

                BindingSource = New System.Windows.Forms.BindingSource

                BindingSource.DataSource = AdvantageFramework.WinForm.Presentation.Controls.LoadGridViewDataSourceView(Value)

                If Value IsNot Nothing Then

                    If Me.ExtraComboBoxItem <> ExtraComboBoxItems.Nothing Then

                        LoadExtraComboItem(Me.ExtraComboBoxItem, BindingSource)

                    End If

                End If

                MyBase.DataSource = BindingSource

            End If

        End Sub
        Protected Sub SetControlType()

            Select Case _ControlType

                Case SubItemGridLookUpEditControl.Type.Default



                Case SubItemGridLookUpEditControl.Type.Client

                    Me.NullText = ""
                    Me.DisplayMember = "Code"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.Division

                    Me.NullText = ""
                    Me.DisplayMember = "Code"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.Product

                    Me.NullText = ""
                    Me.DisplayMember = "Code"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.ProductCategory

                    Me.NullText = ""
                    Me.DisplayMember = "Code"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.Function

                    Me.NullText = ""
                    Me.DisplayMember = "Code"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.JobComponent

                    Me.NullText = ""
                    Me.DisplayMember = "Number"
                    Me.ValueMember = "Number"

                Case SubItemGridLookUpEditControl.Type.Job

                    Me.NullText = ""
                    Me.DisplayMember = "Number"
                    Me.ValueMember = "Number"

                Case SubItemGridLookUpEditControl.Type.PONumber

                    Me.NullText = ""
                    Me.DisplayMember = "Number"
                    Me.ValueMember = "Number"

                Case SubItemGridLookUpEditControl.Type.POLineNumber

                    Me.NullText = ""
                    Me.DisplayMember = "LineNumber"
                    Me.ValueMember = "LineNumber"

                Case SubItemGridLookUpEditControl.Type.SalesTax

                    Me.NullText = ""
                    Me.DisplayMember = "TaxCode"
                    Me.ValueMember = "TaxCode"

                Case SubItemGridLookUpEditControl.Type.PTORule

                    Me.NullText = ""
                    Me.DisplayMember = "Name"
                    Me.ValueMember = "ID"

                Case SubItemGridLookUpEditControl.Type.Office

                    Me.NullText = ""
                    Me.DisplayMember = "Code"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.GeneralLedgerAccount

                    Me.NullText = ""
                    Me.DisplayMember = "Code"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.AdSize

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.ManagementLevel

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "ID"

                Case SubItemGridLookUpEditControl.Type.EstimateFunction

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.Status

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.WebSiteType

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.EmployeeTitle

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "ID"
                    Me.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.DisplayText

                Case SubItemGridLookUpEditControl.Type.Task

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.Phase

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "ID"

                Case SubItemGridLookUpEditControl.Type.Employee, SubItemGridLookUpEditControl.Type.EmployeeWithDepartmentAndOffice

                    Me.NullText = ""
                    Me.DisplayMember = "Code"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.EmployeeFunction

                    Me.NullText = ""
                    Me.DisplayMember = "Code"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.MagazineOrderNumber

                    Me.NullText = ""
                    Me.DisplayMember = "OrderNumber"
                    Me.ValueMember = "ID"

                Case SubItemGridLookUpEditControl.Type.MagazineOrderLineNumber

                    Me.NullText = ""
                    Me.DisplayMember = "LineNumber"
                    Me.ValueMember = "LineNumber"

                Case SubItemGridLookUpEditControl.Type.Partner

                    Me.NullText = ""
                    Me.DisplayMember = "Partner"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.EmployeeCategory

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "ID"

                Case SubItemGridLookUpEditControl.Type.MediaType

                    Me.NullText = ""
                    Me.DisplayMember = "Code"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.ExceedOption

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.ExpenseFunction

                    Me.NullText = ""
                    Me.DisplayMember = "Code"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.AdNumber

                    Me.NullText = ""
                    Me.DisplayMember = "Number"
                    Me.ValueMember = "Number"

                Case SubItemGridLookUpEditControl.Type.SalesClassMediaType

                    Me.NullText = ""
                    Me.DisplayMember = "Code"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.ClientContact

                    Me.NullText = ""
                    Me.DisplayMember = "Code"
                    Me.ValueMember = "ID"

                Case SubItemGridLookUpEditControl.Type.ProductARAddressLookup

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.ClientARAddressLookup

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.DepartmentTeam

                    Me.NullText = ""
                    Me.DisplayMember = "Code"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.Role

                    Me.NullText = ""
                    Me.DisplayMember = "Code"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.EmployeeHRStatus

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.EmployeeVendor

                    Me.NullText = ""
                    Me.DisplayMember = "Code"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.POApprovalRule

                    Me.NullText = ""
                    Me.DisplayMember = "Code"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.ReportMissingTime

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"
                    Me.ExtraComboBoxItem = ExtraComboBoxItems.AgencyDefault

                Case SubItemGridLookUpEditControl.Type.AlertGroup

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.SalesClass

                    Me.NullText = ""
                    Me.DisplayMember = "Code"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.YesNoSkip

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"
                    Me.ExtraComboBoxItem = ExtraComboBoxItems.Skip

                Case SubItemGridLookUpEditControl.Type.FeeTime

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"
                    Me.ExtraComboBoxItem = ExtraComboBoxItems.Skip
                    Me.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.DisplayText

                Case SubItemGridLookUpEditControl.Type.MarkupTaxFlags

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"
                    Me.ExtraComboBoxItem = ExtraComboBoxItems.Skip

                Case SubItemGridLookUpEditControl.Type.FunctionType

                    Me.NullText = ""
                    Me.DisplayMember = "Code"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.FunctionHeading

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"
                    Me.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.DisplayText

                Case SubItemGridLookUpEditControl.Type.Vendor

                    Me.NullText = ""
                    Me.DisplayMember = "Code"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.BeforeAfter

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.ResourceTaskCondition

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.VendorTerm

                    Me.NullText = ""
                    Me.DisplayMember = "Code"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.ImportVendorCategory

                    Me.NullText = ""
                    Me.DisplayMember = "Code"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.RateBy

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.RateType

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.VendorFunction

                    Me.NullText = ""
                    Me.DisplayMember = "Code"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.ImportTemplateProperty

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"
                    Me.ExtraComboBoxItem = ExtraComboBoxItems.Skip

                Case SubItemGridLookUpEditControl.Type.ExpenseItemPayment

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.IndirectCategoryType

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "ID"

                Case SubItemGridLookUpEditControl.Type.ServiceFeeType

                    Me.NullText = ""
                    Me.DisplayMember = "Code"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.Bank

                    Me.NullText = ""
                    Me.DisplayMember = "Code"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.Market

                    Me.NullText = ""
                    Me.DisplayMember = "Code"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.Daypart

                    Me.NullText = ""
                    Me.DisplayMember = "Code"
                    Me.ValueMember = "ID"

                Case SubItemGridLookUpEditControl.Type.JobVersionDatabaseType

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "ID"

                Case SubItemGridLookUpEditControl.Type.JobComponentID

                    Me.NullText = ""
                    Me.DisplayMember = "Number"
                    Me.ValueMember = "ID"

                Case SubItemGridLookUpEditControl.Type.JobDescription

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Number"

                Case SubItemGridLookUpEditControl.Type.JobComponentDescription

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "ID"

                Case SubItemGridLookUpEditControl.Type.MediaApprovalStatusPendingOnly

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.NewspaperOrderNumber

                    Me.NullText = ""
                    Me.DisplayMember = "OrderNumber"
                    Me.ValueMember = "ID"

                Case SubItemGridLookUpEditControl.Type.NewspaperOrderLineNumber

                    Me.NullText = ""
                    Me.DisplayMember = "LineNumber"
                    Me.ValueMember = "LineNumber"

                Case SubItemGridLookUpEditControl.Type.ExpenseReportApprovedFlag

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.ExpenseEmployee

                    Me.NullText = ""
                    Me.DisplayMember = "Code"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.InternetOrderNumber

                    Me.NullText = ""
                    Me.DisplayMember = "OrderNumber"
                    Me.ValueMember = "ID"

                Case SubItemGridLookUpEditControl.Type.InternetOrderLineNumber

                    Me.NullText = ""
                    Me.DisplayMember = "LineNumber"
                    Me.ValueMember = "LineNumber"

                Case SubItemGridLookUpEditControl.Type.OutOfHomeOrderNumber

                    Me.NullText = ""
                    Me.DisplayMember = "OrderNumber"
                    Me.ValueMember = "ID"

                Case SubItemGridLookUpEditControl.Type.OutOfHomeOrderLineNumber

                    Me.NullText = ""
                    Me.DisplayMember = "LineNumber"
                    Me.ValueMember = "LineNumber"

                Case SubItemGridLookUpEditControl.Type.RadioOrderNumber

                    Me.NullText = ""
                    Me.DisplayMember = "OrderNumber"
                    Me.ValueMember = "ID"

                Case SubItemGridLookUpEditControl.Type.RadioOrderLineNumber

                    Me.NullText = ""
                    Me.DisplayMember = "LineNumber"
                    Me.ValueMember = "LineNumber"

                Case SubItemGridLookUpEditControl.Type.RadioOrderLegacyMonth

                    Me.NullText = ""
                    Me.DisplayMember = "Month"
                    Me.ValueMember = "Month"

                Case SubItemGridLookUpEditControl.Type.RadioOrderLegacyYear

                    Me.NullText = ""
                    Me.DisplayMember = "Year"
                    Me.ValueMember = "Year"

                Case SubItemGridLookUpEditControl.Type.TVOrderNumber

                    Me.NullText = ""
                    Me.DisplayMember = "OrderNumber"
                    Me.ValueMember = "ID"

                Case SubItemGridLookUpEditControl.Type.TVOrderLineNumber

                    Me.NullText = ""
                    Me.DisplayMember = "LineNumber"
                    Me.ValueMember = "LineNumber"

                Case SubItemGridLookUpEditControl.Type.TVOrderLegacyMonth

                    Me.NullText = ""
                    Me.DisplayMember = "Month"
                    Me.ValueMember = "Month"

                Case SubItemGridLookUpEditControl.Type.TVOrderLegacyYear

                    Me.NullText = ""
                    Me.DisplayMember = "Year"
                    Me.ValueMember = "Year"

                Case SubItemGridLookUpEditControl.Type.Affiliation

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "ID"

                Case SubItemGridLookUpEditControl.Type.DaypartType

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "ID"

                Case SubItemGridLookUpEditControl.Type.Competition

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "ID"

                Case SubItemGridLookUpEditControl.Type.ServiceFeeTypeID

                    Me.NullText = ""
                    Me.DisplayMember = "Code"
                    Me.ValueMember = "ID"

                Case SubItemGridLookUpEditControl.Type.Cycle

                    Me.NullText = ""
                    Me.DisplayMember = "Name"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.Blackplate

                    Me.NullText = ""
                    Me.DisplayMember = "CodeAndDescription"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.CycleType

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.AccountReceivable

                    Me.NullText = ""
                    Me.DisplayMember = "InvoiceNumber"
                    Me.ValueMember = "InvoiceNumber"

                Case SubItemGridLookUpEditControl.Type.OfficeName

                    Me.NullText = ""
                    Me.DisplayMember = "Name"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.DepartmentTeamName

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.GeneralLedgerAccountDescription

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.EnumDataTable

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.EnumObject

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.PostPeriod

                    Me.NullText = ""
                    Me.DisplayMember = "Code"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.PostPeriodStatus

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.AccountPayableImportMediaType

                    Me.NullText = ""
                    Me.DisplayMember = "Code"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.AccountPayableImportMediaOrderNumber

                    Me.NullText = ""
                    Me.DisplayMember = "OrderNumber"
                    Me.ValueMember = "ID"

                Case SubItemGridLookUpEditControl.Type.AccountPayableImportMediaOrderLineNumber

                    Me.NullText = ""
                    Me.DisplayMember = "LineNumber"
                    Me.ValueMember = "LineNumber"

                Case SubItemGridLookUpEditControl.Type.MediaPlan

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "ID"

                Case SubItemGridLookUpEditControl.Type.MediaPlanDetail

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "ID"

                Case SubItemGridLookUpEditControl.Type.DateFormat

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.CostType

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.Location

                    Me.NullText = ""
                    Me.DisplayMember = "Name"
                    Me.ValueMember = "ID"

                Case SubItemGridLookUpEditControl.Type.Campaign

                    Me.NullText = ""
                    Me.DisplayMember = "Code"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.CampaignID

                    Me.NullText = ""
                    Me.DisplayMember = "ID"
                    Me.ValueMember = "ID"

                Case SubItemGridLookUpEditControl.Type.AccountReceivableRecordType

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.TaskStatus

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.DaypartCode

                    Me.NullText = ""
                    Me.DisplayMember = "Code"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.GeneralLedgerAccountTypes

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.GeneralLedgerBalanceTypes

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.CurrencyCode

                    Me.NullText = ""
                    Me.DisplayMember = "Code"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.ProductionBillHoldStatus

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"
                    Me.ExtraComboBoxItem = ExtraComboBoxItems.None

                Case SubItemGridLookUpEditControl.Type.JobProcess

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "ID"

                Case SubItemGridLookUpEditControl.Type.ProductionReconcileStatus

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"
                    Me.ExtraComboBoxItem = ExtraComboBoxItems.Nothing

                Case SubItemGridLookUpEditControl.Type.ServiceFeeFrequency

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.InvoiceCategory

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.CustomProductionInvoice

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.CustomMagazineInvoice

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.CustomNewspaperInvoice

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.CustomInternetInvoice

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.CustomOutdoorInvoice

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.CustomRadioInvoice

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.CustomTVInvoice

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.InternetType

                    Me.NullText = ""
                    Me.DisplayMember = "Code"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.JobProcessControl

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "ID"

                Case SubItemGridLookUpEditControl.Type.VendorServiceTaxType

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.AvalaraTaxID

                    Me.NullText = ""
                    Me.DisplayMember = "Code"
                    Me.ValueMember = "ID"

                Case SubItemGridLookUpEditControl.Type.OverheadAccountCode

                    Me.NullText = ""
                    Me.DisplayMember = "Code"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.ProductionCustomInvoiceID

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "ID"

                Case SubItemGridLookUpEditControl.Type.MediaCustomInvoiceID

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "ID"

                Case SubItemGridLookUpEditControl.Type.BillingCoopCode

                    Me.NullText = ""
                    Me.DisplayMember = "Code"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.EstimateCustomID

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "ID"

                Case SubItemGridLookUpEditControl.Type.ContactType

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "ID"

                Case SubItemGridLookUpEditControl.Type.AccountReceivableSequenceNumber

                    Me.NullText = ""
                    Me.DisplayMember = "SequenceNumber"
                    Me.ValueMember = "SequenceNumber"

                Case SubItemGridLookUpEditControl.Type.VCCStatus

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.CashReceiptPaymentType

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Description"

                Case SubItemGridLookUpEditControl.Type.OutOfHomeType

                    Me.NullText = ""
                    Me.DisplayMember = "Code"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.DocumentType

                    Me.NullText = ""
                    Me.DisplayMember = "Name"
                    Me.ValueMember = "ID"

                Case SubItemGridLookUpEditControl.Type.IOOrderNumber

                    Me.NullText = ""
                    Me.DisplayMember = "OrderNumber"
                    Me.ValueMember = "ID"

                Case SubItemGridLookUpEditControl.Type.IOOrderLineNumber

                    Me.NullText = ""
                    Me.DisplayMember = "LineNumber"
                    Me.ValueMember = "LineNumber"

                Case SubItemGridLookUpEditControl.Type.OrderProcess

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "ID"

                Case SubItemGridLookUpEditControl.Type.StateCode

                    Me.NullText = ""
                    Me.DisplayMember = "StateCode"
                    Me.ValueMember = "StateCode"

                Case SubItemGridLookUpEditControl.Type.StateName

                    Me.NullText = ""
                    Me.DisplayMember = "StateName"
                    Me.ValueMember = "StateCode"

                Case SubItemGridLookUpEditControl.Type.IndirectCategory

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.JobTemplateMapping

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.GeneralLedgerSource

                    Me.NullText = ""
                    Me.DisplayMember = "Code"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.BuyerEmployeeCode

                    Me.NullText = ""
                    Me.DisplayMember = "Code"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.ClientPO

                    Me.NullText = ""
                    Me.DisplayMember = "ClientPONumber"
                    Me.ValueMember = "ClientPONumber"

                Case SubItemGridLookUpEditControl.Type.CableNetworkStation

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "ID"

                Case SubItemGridLookUpEditControl.Type.ClientDiscount

                    Me.NullText = ""
                    Me.DisplayMember = "Code"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.AccountPayableImportMediaOrderNumberAutoFill

                    Me.NullText = ""
                    Me.DisplayMember = "OrderNumber"
                    Me.ValueMember = "OrderNumber"

                Case SubItemGridLookUpEditControl.Type.AlertTemplate

                    Me.NullText = ""
                    Me.DisplayMember = "Name"
                    Me.ValueMember = "ID"

                Case SubItemGridLookUpEditControl.Type.AlertState

                    Me.NullText = ""
                    Me.DisplayMember = "Name"
                    Me.ValueMember = "ID"

                Case SubItemGridLookUpEditControl.Type.CampaignID2

                    Me.NullText = ""
                    Me.DisplayMember = "CodeName"
                    Me.ValueMember = "ID"

                Case SubItemGridLookUpEditControl.Type.MediaChannelID

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "ID"

                Case SubItemGridLookUpEditControl.Type.MediaTacticID

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "ID"

                Case SubItemGridLookUpEditControl.Type.Assignment

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "ID"

            End Select

            CreateDefaultColumns()

        End Sub
        Protected Sub CreateDefaultColumns()

            If Me.View.Columns.Count = 0 Then

                Select Case _ControlType

                    Case SubItemGridLookUpEditControl.Type.Default



                    Case SubItemGridLookUpEditControl.Type.Client

                        Me.View.Columns.Add(GetNewColumn("Code"))
                        Me.View.Columns.Add(GetNewColumn("Name"))

                    Case SubItemGridLookUpEditControl.Type.Division

                        Me.View.Columns.Add(GetNewColumn("Code"))
                        Me.View.Columns.Add(GetNewColumn("Name"))

                    Case SubItemGridLookUpEditControl.Type.Product

                        Me.View.Columns.Add(GetNewColumn("Code"))
                        Me.View.Columns.Add(GetNewColumn("Name"))

                    Case SubItemGridLookUpEditControl.Type.ProductCategory

                        Me.View.Columns.Add(GetNewColumn("Code"))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.Function

                        Me.View.Columns.Add(GetNewColumn("Code"))
                        Me.View.Columns.Add(GetNewColumn("Description"))
                        Me.View.Columns.Add(GetNewColumn("Type", False))

                    Case SubItemGridLookUpEditControl.Type.JobComponent

                        Me.View.Columns.Add(GetNewColumn("ID", False))
                        Me.View.Columns.Add(GetNewColumn("JobNumber", False, "Job Number"))
                        Me.View.Columns.Add(GetNewColumn("Number"))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.Job

                        Me.View.Columns.Add(GetNewColumn("Number"))
                        Me.View.Columns.Add(GetNewColumn("Description"))
                        Me.View.Columns.Add(GetNewColumn("ClientCode", False, "Client Code"))
                        Me.View.Columns.Add(GetNewColumn("DivisionCode", False, "Division Code"))
                        Me.View.Columns.Add(GetNewColumn("ProductCode", False, "Product Code"))

                    Case SubItemGridLookUpEditControl.Type.PONumber

                        Me.View.Columns.Add(GetNewColumn("Number"))
                        Me.View.Columns.Add(GetNewColumn("Description"))
                        Me.View.Columns.Add(GetNewColumn("Date"))
                        Me.View.Columns.Add(GetNewColumn("DueDate"))
                        Me.View.Columns.Add(GetNewColumn("Status"))
                        Me.View.Columns.Add(GetNewColumn("POTotal"))
                        Me.View.Columns.Add(GetNewColumn("POBalance"))
                        Me.View.Columns.Add(GetNewColumn("WorkComplete"))

                    Case SubItemGridLookUpEditControl.Type.POLineNumber

                        Me.View.Columns.Add(GetNewColumn("LineNumber", , "Line #"))
                        Me.View.Columns.Add(GetNewColumn("LineDescription", , "Description"))

                    Case SubItemGridLookUpEditControl.Type.SalesTax

                        Me.View.Columns.Add(GetNewColumn("TaxCode"))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.PTORule

                        Me.View.Columns.Add(GetNewColumn("Name"))
                        Me.View.Columns.Add(GetNewColumn("ID", False))

                    Case SubItemGridLookUpEditControl.Type.Office

                        Me.View.Columns.Add(GetNewColumn("Code"))
                        Me.View.Columns.Add(GetNewColumn("Name"))

                    Case SubItemGridLookUpEditControl.Type.GeneralLedgerAccount

                        Me.View.Columns.Add(GetNewColumn("Code"))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.AdSize

                        Me.View.Columns.Add(GetNewColumn("Code"))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.ManagementLevel

                        Me.View.Columns.Add(GetNewColumn("ID", False))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.EstimateFunction

                        Me.View.Columns.Add(GetNewColumn("Code"))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.Status

                        Me.View.Columns.Add(GetNewColumn("Code"))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.WebSiteType

                        Me.View.Columns.Add(GetNewColumn("Code"))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.EmployeeTitle

                        Me.View.Columns.Add(GetNewColumn("ID", False))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.Task

                        Me.View.Columns.Add(GetNewColumn("Code"))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.Phase

                        Me.View.Columns.Add(GetNewColumn("ID", False))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.Employee, SubItemGridLookUpEditControl.Type.EmployeeWithDepartmentAndOffice

                        Me.View.Columns.Add(GetNewColumn("Code"))
                        Me.View.Columns.Add(GetNewColumn("Name"))

                        If _ControlType = SubItemGridLookUpEditControl.Type.EmployeeWithDepartmentAndOffice Then

                            Me.View.Columns.Add(GetNewColumn("OfficeCode"))
                            Me.View.Columns.Add(GetNewColumn("OfficeName"))
                            Me.View.Columns.Add(GetNewColumn("DepartmentCode"))
                            Me.View.Columns.Add(GetNewColumn("DepartmentName"))

                        End If

                    Case SubItemGridLookUpEditControl.Type.EmployeeFunction

                        Me.View.Columns.Add(GetNewColumn("Code"))
                        Me.View.Columns.Add(GetNewColumn("FunctionCode", False))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.MagazineOrderNumber

                        Me.View.Columns.Add(GetNewColumn("VendorCode", , "Vendor"))
                        Me.View.Columns.Add(GetNewColumn("ClientCode", , "Client"))
                        Me.View.Columns.Add(GetNewColumn("DivisionCode", , "Division"))
                        Me.View.Columns.Add(GetNewColumn("ProductCode", , "Product"))
                        Me.View.Columns.Add(GetNewColumn("OrderNumber", , "Order #"))
                        Me.View.Columns.Add(GetNewColumn("LineNumber", , "Line"))
                        Me.View.Columns.Add(GetNewColumn("InsertDate", , "Date"))
                        Me.View.Columns.Add(GetNewColumn("OrderDescription", , "Description"))
                        Me.View.Columns.Add(GetNewColumn("LinkID", , "Link ID"))
                        Me.View.Columns.Add(GetNewColumn("ClientPO", , "Client PO"))
                        Me.View.Columns.Add(GetNewColumn("MarketCode", , "Market"))

                    Case SubItemGridLookUpEditControl.Type.MagazineOrderLineNumber

                        Me.View.Columns.Add(GetNewColumn("LineNumber", , "Line #"))
                        Me.View.Columns.Add(GetNewColumn("InsertDate", , "Date"))
                        Me.View.Columns.Add(GetNewColumn("Headline"))

                    Case SubItemGridLookUpEditControl.Type.Partner

                        Me.View.Columns.Add(GetNewColumn("Code"))
                        Me.View.Columns.Add(GetNewColumn("Partner"))

                    Case SubItemGridLookUpEditControl.Type.EmployeeCategory

                        Me.View.Columns.Add(GetNewColumn("ID", False))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.MediaType

                        Me.View.Columns.Add(GetNewColumn("Code", False))
                        Me.View.Columns.Add(GetNewColumn("Description", , "Media Type"))

                    Case SubItemGridLookUpEditControl.Type.ExceedOption

                        Me.View.Columns.Add(GetNewColumn("Code", False))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.ExpenseFunction

                        Me.View.Columns.Add(GetNewColumn("Code"))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.AdNumber

                        Me.View.Columns.Add(GetNewColumn("Number"))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.SalesClassMediaType

                        Me.View.Columns.Add(GetNewColumn("Code", False))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.ClientContact

                        Me.View.Columns.Add(GetNewColumn("ID", False))
                        Me.View.Columns.Add(GetNewColumn("Code"))
                        Me.View.Columns.Add(GetNewColumn("Description", True, "Name"))
                        Me.View.Columns.Add(GetNewColumn("ContactTypeID", True, "Contact Type"))

                    Case SubItemGridLookUpEditControl.Type.ProductARAddressLookup

                        Me.View.Columns.Add(GetNewColumn("Code", False))
                        Me.View.Columns.Add(GetNewColumn("Description"))
                        Me.View.Columns.Add(GetNewColumn("Address1"))
                        Me.View.Columns.Add(GetNewColumn("Address2"))
                        Me.View.Columns.Add(GetNewColumn("City"))
                        Me.View.Columns.Add(GetNewColumn("State"))
                        Me.View.Columns.Add(GetNewColumn("Zip"))

                    Case SubItemGridLookUpEditControl.Type.ClientARAddressLookup

                        Me.View.Columns.Add(GetNewColumn("Code", False))
                        Me.View.Columns.Add(GetNewColumn("Description"))
                        Me.View.Columns.Add(GetNewColumn("Address1"))
                        Me.View.Columns.Add(GetNewColumn("Address2"))
                        Me.View.Columns.Add(GetNewColumn("City"))
                        Me.View.Columns.Add(GetNewColumn("State"))
                        Me.View.Columns.Add(GetNewColumn("Zip"))

                    Case SubItemGridLookUpEditControl.Type.DepartmentTeam

                        Me.View.Columns.Add(GetNewColumn("Code"))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.Role

                        Me.View.Columns.Add(GetNewColumn("Code"))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.EmployeeHRStatus

                        Me.View.Columns.Add(GetNewColumn("Code", False))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.EmployeeVendor

                        Me.View.Columns.Add(GetNewColumn("Code"))
                        Me.View.Columns.Add(GetNewColumn("Name"))

                    Case SubItemGridLookUpEditControl.Type.POApprovalRule

                        Me.View.Columns.Add(GetNewColumn("Code"))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.ReportMissingTime

                        Me.View.Columns.Add(GetNewColumn("Code", False))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.AlertGroup

                        Me.View.Columns.Add(GetNewColumn("Code", False))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.SalesClass

                        Me.View.Columns.Add(GetNewColumn("Code"))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.YesNoSkip

                        Me.View.Columns.Add(GetNewColumn("Code", False))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.FeeTime

                        Me.View.Columns.Add(GetNewColumn("Code", False))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.MarkupTaxFlags

                        Me.View.Columns.Add(GetNewColumn("Code", False))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.FunctionType

                        Me.View.Columns.Add(GetNewColumn("Code"))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.FunctionHeading

                        Me.View.Columns.Add(GetNewColumn("Code", False))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.Vendor

                        Me.View.Columns.Add(GetNewColumn("Code"))
                        Me.View.Columns.Add(GetNewColumn("Name"))
                        Me.View.Columns.Add(GetNewColumn("Category"))

                    Case SubItemGridLookUpEditControl.Type.BeforeAfter

                        Me.View.Columns.Add(GetNewColumn("Code", False))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.ResourceTaskCondition

                        Me.View.Columns.Add(GetNewColumn("Code", False))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.VendorTerm

                        Me.View.Columns.Add(GetNewColumn("Code"))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.ImportVendorCategory

                        Me.View.Columns.Add(GetNewColumn("Code"))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.RateBy

                        Me.View.Columns.Add(GetNewColumn("Code", False))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.RateType

                        Me.View.Columns.Add(GetNewColumn("Code", False))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.VendorFunction

                        Me.View.Columns.Add(GetNewColumn("Code"))
                        Me.View.Columns.Add(GetNewColumn("Description"))
                        Me.View.Columns.Add(GetNewColumn("CPMFlag", False, "CPM"))

                    Case SubItemGridLookUpEditControl.Type.ImportTemplateProperty

                        Me.View.Columns.Add(GetNewColumn("Code", False))
                        Me.View.Columns.Add(GetNewColumn("Description", , "Property"))

                    Case SubItemGridLookUpEditControl.Type.ExpenseItemPayment

                        Me.View.Columns.Add(GetNewColumn("Code", False))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.IndirectCategoryType

                        Me.View.Columns.Add(GetNewColumn("ID", False))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.ServiceFeeType

                        Me.View.Columns.Add(GetNewColumn("Code"))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.Bank

                        Me.View.Columns.Add(GetNewColumn("Code"))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.Market

                        Me.View.Columns.Add(GetNewColumn("Code"))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.Daypart, SubItemGridLookUpEditControl.Type.DaypartCode

                        Me.View.Columns.Add(GetNewColumn("ID", False))
                        Me.View.Columns.Add(GetNewColumn("Code"))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.JobVersionDatabaseType

                        Me.View.Columns.Add(GetNewColumn("ID", False))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.JobComponentID

                        Me.View.Columns.Add(GetNewColumn("ID", False))
                        Me.View.Columns.Add(GetNewColumn("JobNumber", False, "Job Number"))
                        Me.View.Columns.Add(GetNewColumn("Number"))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.JobDescription

                        Me.View.Columns.Add(GetNewColumn("Number", False))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.JobComponentDescription

                        Me.View.Columns.Add(GetNewColumn("ID", False))
                        Me.View.Columns.Add(GetNewColumn("JobNumber", False, "Job Number"))
                        Me.View.Columns.Add(GetNewColumn("Number", False))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.MediaApprovalStatusPendingOnly

                        Me.View.Columns.Add(GetNewColumn("Code", False))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.NewspaperOrderNumber

                        Me.View.Columns.Add(GetNewColumn("VendorCode", , "Vendor"))
                        Me.View.Columns.Add(GetNewColumn("ClientCode", , "Client"))
                        Me.View.Columns.Add(GetNewColumn("DivisionCode", , "Division"))
                        Me.View.Columns.Add(GetNewColumn("ProductCode", , "Product"))
                        Me.View.Columns.Add(GetNewColumn("OrderNumber", , "Order #"))
                        Me.View.Columns.Add(GetNewColumn("LineNumber", , "Line"))
                        Me.View.Columns.Add(GetNewColumn("InsertDate", , "Date"))
                        Me.View.Columns.Add(GetNewColumn("OrderDescription", , "Description"))
                        Me.View.Columns.Add(GetNewColumn("LinkID", , "Link ID"))
                        Me.View.Columns.Add(GetNewColumn("ClientPO", , "Client PO"))

                    Case SubItemGridLookUpEditControl.Type.NewspaperOrderLineNumber

                        Me.View.Columns.Add(GetNewColumn("LineNumber", , "Line #"))
                        Me.View.Columns.Add(GetNewColumn("InsertDate", , "Date"))
                        Me.View.Columns.Add(GetNewColumn("Headline"))

                    Case (SubItemGridLookUpEditControl.Type.ExpenseReportApprovedFlag)

                        Me.View.Columns.Add(GetNewColumn("Code", False))
                        Me.View.Columns.Add(GetNewColumn("Description", True, "Status"))

                    Case SubItemGridLookUpEditControl.Type.ExpenseEmployee

                        Me.View.Columns.Add(GetNewColumn("Code"))
                        Me.View.Columns.Add(GetNewColumn("Name"))

                    Case SubItemGridLookUpEditControl.Type.InternetOrderNumber

                        Me.View.Columns.Add(GetNewColumn("VendorCode", , "Vendor"))
                        Me.View.Columns.Add(GetNewColumn("ClientCode", , "Client"))
                        Me.View.Columns.Add(GetNewColumn("DivisionCode", , "Division"))
                        Me.View.Columns.Add(GetNewColumn("ProductCode", , "Product"))
                        Me.View.Columns.Add(GetNewColumn("OrderNumber", , "Order #"))
                        Me.View.Columns.Add(GetNewColumn("LineNumber", , "Line"))
                        Me.View.Columns.Add(GetNewColumn("InsertDate", , "Date"))
                        Me.View.Columns.Add(GetNewColumn("OrderDescription", , "Description"))
                        Me.View.Columns.Add(GetNewColumn("Placement", , "Placement"))
                        Me.View.Columns.Add(GetNewColumn("LinkID", , "Link ID"))
                        Me.View.Columns.Add(GetNewColumn("ClientPO", , "Client PO"))
                        Me.View.Columns.Add(GetNewColumn("Type", , "Type"))

                    Case SubItemGridLookUpEditControl.Type.InternetOrderLineNumber

                        Me.View.Columns.Add(GetNewColumn("LineNumber", , "Line #"))
                        Me.View.Columns.Add(GetNewColumn("InsertDate", , "Date"))
                        Me.View.Columns.Add(GetNewColumn("Headline"))

                    Case SubItemGridLookUpEditControl.Type.OutOfHomeOrderNumber

                        Me.View.Columns.Add(GetNewColumn("VendorCode", , "Vendor"))
                        Me.View.Columns.Add(GetNewColumn("ClientCode", , "Client"))
                        Me.View.Columns.Add(GetNewColumn("DivisionCode", , "Division"))
                        Me.View.Columns.Add(GetNewColumn("ProductCode", , "Product"))
                        Me.View.Columns.Add(GetNewColumn("OrderNumber", , "Order #"))
                        Me.View.Columns.Add(GetNewColumn("LineNumber", , "Line"))
                        Me.View.Columns.Add(GetNewColumn("InsertDate", , "Date"))
                        Me.View.Columns.Add(GetNewColumn("OrderDescription", , "Description"))
                        Me.View.Columns.Add(GetNewColumn("LinkID", , "Link ID"))
                        Me.View.Columns.Add(GetNewColumn("ClientPO", , "Client PO"))
                        Me.View.Columns.Add(GetNewColumn("MarketCode", , "Market"))
                        Me.View.Columns.Add(GetNewColumn("Type", , "Type"))

                    Case SubItemGridLookUpEditControl.Type.OutOfHomeOrderLineNumber

                        Me.View.Columns.Add(GetNewColumn("LineNumber", , "Line #"))
                        Me.View.Columns.Add(GetNewColumn("InsertDate", , "Date"))
                        Me.View.Columns.Add(GetNewColumn("Headline"))

                    Case SubItemGridLookUpEditControl.Type.RadioOrderNumber

                        Me.View.Columns.Add(GetNewColumn("VendorCode", , "Vendor"))
                        Me.View.Columns.Add(GetNewColumn("ClientCode", , "Client"))
                        Me.View.Columns.Add(GetNewColumn("DivisionCode", , "Division"))
                        Me.View.Columns.Add(GetNewColumn("ProductCode", , "Product"))
                        Me.View.Columns.Add(GetNewColumn("OrderNumber", , "Order #"))
                        Me.View.Columns.Add(GetNewColumn("Description", , "Description"))
                        Me.View.Columns.Add(GetNewColumn("LinkID", , "Link ID"))
                        Me.View.Columns.Add(GetNewColumn("ClientPO", , "Client PO"))
                        Me.View.Columns.Add(GetNewColumn("MarketCode", , "Market"))
                        Me.View.Columns.Add(GetNewColumn("LineNumber", , "Line"))
                        Me.View.Columns.Add(GetNewColumn("Month", , "Month"))
                        Me.View.Columns.Add(GetNewColumn("Year", , "Year"))
                        Me.View.Columns.Add(GetNewColumn("StartDate", , "Start Date"))
                        Me.View.Columns.Add(GetNewColumn("EndDate", , "End Date"))
                        Me.View.Columns.Add(GetNewColumn("Quantity", , "Quantity"))
                        Me.View.Columns.Add(GetNewColumn("GrossRate", , "Gross Rate"))
                        Me.View.Columns.Add(GetNewColumn("StartTime", , "StartTime"))
                        Me.View.Columns.Add(GetNewColumn("EndTime", , "EndTime"))

                    Case SubItemGridLookUpEditControl.Type.RadioOrderLineNumber

                        Me.View.Columns.Add(GetNewColumn("LineNumber", , "Line #"))
                        Me.View.Columns.Add(GetNewColumn("Month", , "Month"))
                        Me.View.Columns.Add(GetNewColumn("Year", , "Year"))
                        Me.View.Columns.Add(GetNewColumn("StartDate", , "Start Date"))
                        Me.View.Columns.Add(GetNewColumn("EndDate", , "End Date"))
                        Me.View.Columns.Add(GetNewColumn("Quantity", , "Quantity"))
                        Me.View.Columns.Add(GetNewColumn("NetRate", , "Net Rate"))
                        Me.View.Columns.Add(GetNewColumn("GrossRate", , "Gross Rate"))
                        Me.View.Columns.Add(GetNewColumn("Length", , "Length"))
                        Me.View.Columns.Add(GetNewColumn("Programming", , "Programming"))
                        Me.View.Columns.Add(GetNewColumn("StartTime", , "StartTime"))
                        Me.View.Columns.Add(GetNewColumn("EndTime", , "EndTime"))

                    Case SubItemGridLookUpEditControl.Type.RadioOrderLegacyMonth

                        Me.View.Columns.Add(GetNewColumn("Column", , "Month"))

                    Case SubItemGridLookUpEditControl.Type.RadioOrderLegacyYear

                        Me.View.Columns.Add(GetNewColumn("Column", , "Year"))

                    Case SubItemGridLookUpEditControl.Type.TVOrderNumber

                        Me.View.Columns.Add(GetNewColumn("VendorCode", , "Vendor"))
                        Me.View.Columns.Add(GetNewColumn("ClientCode", , "Client"))
                        Me.View.Columns.Add(GetNewColumn("DivisionCode", , "Division"))
                        Me.View.Columns.Add(GetNewColumn("ProductCode", , "Product"))
                        Me.View.Columns.Add(GetNewColumn("OrderNumber", , "Order #"))
                        Me.View.Columns.Add(GetNewColumn("Description", , "Description"))
                        Me.View.Columns.Add(GetNewColumn("LinkID", , "Link ID"))
                        Me.View.Columns.Add(GetNewColumn("ClientPO", , "Client PO"))
                        Me.View.Columns.Add(GetNewColumn("MarketCode", , "Market"))
                        Me.View.Columns.Add(GetNewColumn("LineNumber", , "Line"))
                        Me.View.Columns.Add(GetNewColumn("NetworkID", , "Network ID"))
                        Me.View.Columns.Add(GetNewColumn("Month", , "Month"))
                        Me.View.Columns.Add(GetNewColumn("Year", , "Year"))
                        Me.View.Columns.Add(GetNewColumn("StartDate", , "Start Date"))
                        Me.View.Columns.Add(GetNewColumn("EndDate", , "End Date"))
                        Me.View.Columns.Add(GetNewColumn("Quantity", , "Quantity"))
                        Me.View.Columns.Add(GetNewColumn("GrossRate", , "Gross Rate"))
                        Me.View.Columns.Add(GetNewColumn("StartTime", , "StartTime"))
                        Me.View.Columns.Add(GetNewColumn("EndTime", , "EndTime"))

                    Case SubItemGridLookUpEditControl.Type.TVOrderLineNumber

                        Me.View.Columns.Add(GetNewColumn("LineNumber", , "Line #"))
                        Me.View.Columns.Add(GetNewColumn("NetworkID", , "Network ID"))
                        Me.View.Columns.Add(GetNewColumn("Month", , "Month"))
                        Me.View.Columns.Add(GetNewColumn("Year", , "Year"))
                        Me.View.Columns.Add(GetNewColumn("StartDate", , "Start Date"))
                        Me.View.Columns.Add(GetNewColumn("EndDate", , "End Date"))
                        Me.View.Columns.Add(GetNewColumn("Quantity", , "Quantity"))
                        Me.View.Columns.Add(GetNewColumn("NetRate", , "Net Rate"))
                        Me.View.Columns.Add(GetNewColumn("GrossRate", , "Gross Rate"))
                        Me.View.Columns.Add(GetNewColumn("Length", , "Length"))
                        Me.View.Columns.Add(GetNewColumn("Programming", , "Programming"))
                        Me.View.Columns.Add(GetNewColumn("StartTime", , "StartTime"))
                        Me.View.Columns.Add(GetNewColumn("EndTime", , "EndTime"))

                    Case SubItemGridLookUpEditControl.Type.TVOrderLegacyMonth

                        Me.View.Columns.Add(GetNewColumn("Column", , "Month"))

                    Case SubItemGridLookUpEditControl.Type.TVOrderLegacyYear

                        Me.View.Columns.Add(GetNewColumn("Column", , "Year"))

                    Case SubItemGridLookUpEditControl.Type.Affiliation

                        Me.View.Columns.Add(GetNewColumn("ID", False))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.DaypartType

                        Me.View.Columns.Add(GetNewColumn("ID", False))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.Competition

                        Me.View.Columns.Add(GetNewColumn("ID", False))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.ServiceFeeTypeID

                        Me.View.Columns.Add(GetNewColumn("ID", False))
                        Me.View.Columns.Add(GetNewColumn("Code"))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.Cycle

                        Me.View.Columns.Add(GetNewColumn("Code", False))
                        Me.View.Columns.Add(GetNewColumn("Name"))

                    Case SubItemGridLookUpEditControl.Type.Blackplate

                        Me.View.Columns.Add(GetNewColumn("Code"))
                        Me.View.Columns.Add(GetNewColumn("Description"))
                        Me.View.Columns.Add(GetNewColumn("CodeAndDescription", False))

                    Case SubItemGridLookUpEditControl.Type.CycleType

                        Me.View.Columns.Add(GetNewColumn("Code", False))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.AccountReceivable

                        Me.View.Columns.Add(GetNewColumn("InvoiceNumber"))
                        Me.View.Columns.Add(GetNewColumn("SequenceNumber"))
                        Me.View.Columns.Add(GetNewColumn("Type"))
                        Me.View.Columns.Add(GetNewColumn("ClientCode"))
                        Me.View.Columns.Add(GetNewColumn("ClientName", False))
                        Me.View.Columns.Add(GetNewColumn("InvoiceDate", False))

                    Case SubItemGridLookUpEditControl.Type.OfficeName

                        Me.View.Columns.Add(GetNewColumn("Code"))
                        Me.View.Columns.Add(GetNewColumn("Name"))

                    Case SubItemGridLookUpEditControl.Type.DepartmentTeamName

                        Me.View.Columns.Add(GetNewColumn("Code"))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.GeneralLedgerAccountDescription

                        Me.View.Columns.Add(GetNewColumn("Code"))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.EnumDataTable

                        Me.View.Columns.Add(GetNewColumn("Code", False))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.EnumObject

                        Me.View.Columns.Add(GetNewColumn("Code", False))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.PostPeriod

                        Me.View.Columns.Add(GetNewColumn("Code"))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.PostPeriodStatus

                        Me.View.Columns.Add(GetNewColumn("Code", False))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.AccountPayableImportMediaType

                        Me.View.Columns.Add(GetNewColumn("Code"))
                        Me.View.Columns.Add(GetNewColumn("Description", , "Media Type"))

                    Case SubItemGridLookUpEditControl.Type.MediaPlan

                        Me.View.Columns.Add(GetNewColumn("ID", False))
                        Me.View.Columns.Add(GetNewColumn("Description"))
                        Me.View.Columns.Add(GetNewColumn("Client"))
                        Me.View.Columns.Add(GetNewColumn("StartDate"))
                        Me.View.Columns.Add(GetNewColumn("EndDate"))
                        Me.View.Columns.Add(GetNewColumn("IsApproved"))

                    Case SubItemGridLookUpEditControl.Type.MediaPlanDetail

                        Me.View.Columns.Add(GetNewColumn("ID", False))
                        Me.View.Columns.Add(GetNewColumn("Description"))
                        Me.View.Columns.Add(GetNewColumn("MediaPlanID", False))
                        Me.View.Columns.Add(GetNewColumn("SalesClass"))

                    Case SubItemGridLookUpEditControl.Type.DateFormat

                        Me.View.Columns.Add(GetNewColumn("Code", False))
                        Me.View.Columns.Add(GetNewColumn("Description", True, "Format"))

                    Case SubItemGridLookUpEditControl.Type.CostType

                        Me.View.Columns.Add(GetNewColumn("Code", False))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.Location

                        Me.View.Columns.Add(GetNewColumn("ID"))
                        Me.View.Columns.Add(GetNewColumn("Name"))

                    Case SubItemGridLookUpEditControl.Type.Campaign

                        Me.View.Columns.Add(GetNewColumn("ID", False))
                        Me.View.Columns.Add(GetNewColumn("Code"))
                        Me.View.Columns.Add(GetNewColumn("Name"))

                    Case SubItemGridLookUpEditControl.Type.CampaignID

                        Me.View.Columns.Add(GetNewColumn("ID"))
                        Me.View.Columns.Add(GetNewColumn("Code"))
                        Me.View.Columns.Add(GetNewColumn("Name"))

                    Case SubItemGridLookUpEditControl.Type.AccountReceivableRecordType

                        Me.View.Columns.Add(GetNewColumn("Code"))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.TaskStatus

                        Me.View.Columns.Add(GetNewColumn("Code", False))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.GeneralLedgerAccountTypes

                        Me.View.Columns.Add(GetNewColumn("Code", False))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.GeneralLedgerBalanceTypes

                        Me.View.Columns.Add(GetNewColumn("Code", False))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.CurrencyCode

                        Me.View.Columns.Add(GetNewColumn("Code"))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.ProductionBillHoldStatus

                        Me.View.Columns.Add(GetNewColumn("Code", False))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.JobProcess

                        Me.View.Columns.Add(GetNewColumn("ID", False))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.ProductionReconcileStatus

                        Me.View.Columns.Add(GetNewColumn("Code", False))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.ServiceFeeFrequency

                        Me.View.Columns.Add(GetNewColumn("Code", False))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.InvoiceCategory

                        Me.View.Columns.Add(GetNewColumn("Code", False))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.CustomProductionInvoice

                        Me.View.Columns.Add(GetNewColumn("Code"))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.CustomMagazineInvoice

                        Me.View.Columns.Add(GetNewColumn("Code"))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.CustomNewspaperInvoice

                        Me.View.Columns.Add(GetNewColumn("Code"))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.CustomInternetInvoice

                        Me.View.Columns.Add(GetNewColumn("Code"))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.CustomOutdoorInvoice

                        Me.View.Columns.Add(GetNewColumn("Code"))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.CustomRadioInvoice

                        Me.View.Columns.Add(GetNewColumn("Code"))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.CustomTVInvoice

                        Me.View.Columns.Add(GetNewColumn("Code"))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.InternetType

                        Me.View.Columns.Add(GetNewColumn("Code"))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.JobProcessControl

                        Me.View.Columns.Add(GetNewColumn("ID"))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.VendorServiceTaxType

                        Me.View.Columns.Add(GetNewColumn("Code", False))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.AvalaraTaxID

                        Me.View.Columns.Add(GetNewColumn("ID", False))
                        Me.View.Columns.Add(GetNewColumn("Code"))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.OverheadAccountCode

                        Me.View.Columns.Add(GetNewColumn("Code"))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.ProductionCustomInvoiceID

                        Me.View.Columns.Add(GetNewColumn("ID", False))
                        Me.View.Columns.Add(GetNewColumn("Type"))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.MediaCustomInvoiceID

                        Me.View.Columns.Add(GetNewColumn("ID", False))
                        Me.View.Columns.Add(GetNewColumn("Type"))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.BillingCoopCode

                        Me.View.Columns.Add(GetNewColumn("Code"))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.EstimateCustomID

                        Me.View.Columns.Add(GetNewColumn("ID", False))
                        Me.View.Columns.Add(GetNewColumn("EstimateReportType"))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.ContactType

                        Me.View.Columns.Add(GetNewColumn("ID", False))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.AccountReceivableSequenceNumber

                        Me.View.Columns.Add(GetNewColumn("SequenceNumber"))
                        Me.View.Columns.Add(GetNewColumn("Type"))
                        Me.View.Columns.Add(GetNewColumn("ClientCode"))
                        Me.View.Columns.Add(GetNewColumn("ClientName", False))
                        Me.View.Columns.Add(GetNewColumn("InvoiceDate", False))

                    Case SubItemGridLookUpEditControl.Type.VCCStatus

                        Me.View.Columns.Add(GetNewColumn("Code", False))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.CashReceiptPaymentType

                        Me.View.Columns.Add(GetNewColumn("ID", False))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.OutOfHomeType

                        Me.View.Columns.Add(GetNewColumn("Code"))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.DocumentType

                        Me.View.Columns.Add(GetNewColumn("ID", False))
                        Me.View.Columns.Add(GetNewColumn("Name"))

                    Case SubItemGridLookUpEditControl.Type.IOOrderNumber

                        Me.View.Columns.Add(GetNewColumn("MediaType", , "Type"))
                        Me.View.Columns.Add(GetNewColumn("VendorCode", , "Vendor"))
                        Me.View.Columns.Add(GetNewColumn("ClientCode", , "Client"))
                        Me.View.Columns.Add(GetNewColumn("DivisionCode", , "Division"))
                        Me.View.Columns.Add(GetNewColumn("ProductCode", , "Product"))
                        Me.View.Columns.Add(GetNewColumn("OrderNumber", , "Order #"))
                        Me.View.Columns.Add(GetNewColumn("LineNumber", , "Line"))
                        Me.View.Columns.Add(GetNewColumn("Description", , "Description"))
                        Me.View.Columns.Add(GetNewColumn("LinkID", , "Link ID"))
                        Me.View.Columns.Add(GetNewColumn("ClientPO", , "Client PO"))

                    Case SubItemGridLookUpEditControl.Type.IOOrderLineNumber

                        Me.View.Columns.Add(GetNewColumn("LineNumber", , "Line #"))
                        Me.View.Columns.Add(GetNewColumn("Description", , "Description"))

                    Case SubItemGridLookUpEditControl.Type.OrderProcess

                        Me.View.Columns.Add(GetNewColumn("ID", False))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.StateCode

                        Me.View.Columns.Add(GetNewColumn("StateCode"))

                    Case SubItemGridLookUpEditControl.Type.StateName

                        Me.View.Columns.Add(GetNewColumn("StateCode"))
                        Me.View.Columns.Add(GetNewColumn("StateName"))

                    Case SubItemGridLookUpEditControl.Type.IndirectCategory

                        Me.View.Columns.Add(GetNewColumn("Code"))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.JobTemplateMapping

                        Me.View.Columns.Add(GetNewColumn("Code", False))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.GeneralLedgerSource

                        Me.View.Columns.Add(GetNewColumn("Code"))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.BuyerEmployeeCode

                        Me.View.Columns.Add(GetNewColumn("Code"))
                        Me.View.Columns.Add(GetNewColumn("Name"))

                    Case SubItemGridLookUpEditControl.Type.ClientPO

                        Me.View.Columns.Add(GetNewColumn("ClientPONumber"))
                        Me.View.Columns.Add(GetNewColumn("ClientPODescription"))

                    Case SubItemGridLookUpEditControl.Type.CableNetworkStation

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ID", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.ClientDiscount

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Name"))

                    Case SubItemGridLookUpEditControl.Type.AlertTemplate

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ID", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Name"))

                    Case SubItemGridLookUpEditControl.Type.AlertState

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ID", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Name"))

                    Case SubItemGridLookUpEditControl.Type.CampaignID2

                        Me.View.Columns.Add(GetNewColumn("ID", False))
                        Me.View.Columns.Add(GetNewColumn("Code"))
                        Me.View.Columns.Add(GetNewColumn("Name"))

                    Case SubItemGridLookUpEditControl.Type.MediaChannelID

                        Me.View.Columns.Add(GetNewColumn("ID", False))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.MediaTacticID

                        Me.View.Columns.Add(GetNewColumn("ID", False))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.Assignment

                        Me.View.Columns.Add(GetNewColumn("ID", False))
                        Me.View.Columns.Add(GetNewColumn("Description"))

                End Select

            End If

        End Sub
        Public Sub LoadDefaultDataSourceView(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ReportingDbContext As AdvantageFramework.Reporting.Database.DbContext,
                                             ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                             ByVal DataContext As AdvantageFramework.Database.DataContext)

            Dim EnumObjectsList As Generic.List(Of AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute) = Nothing

            If DbContext IsNot Nothing AndAlso ReportingDbContext IsNot Nothing AndAlso DataContext IsNot Nothing AndAlso SecurityDbContext IsNot Nothing Then

                Select Case _ControlType

                    Case SubItemGridLookUpEditControl.Type.Default



                    Case SubItemGridLookUpEditControl.Type.Client

                        Me.DataSource = AdvantageFramework.Database.Procedures.Client.LoadCore(AdvantageFramework.Database.Procedures.Client.LoadAllActive(DbContext))

                    Case SubItemGridLookUpEditControl.Type.Division

                        Me.DataSource = AdvantageFramework.Database.Procedures.Division.LoadCore(AdvantageFramework.Database.Procedures.Division.LoadAllActive(DbContext))

                    Case SubItemGridLookUpEditControl.Type.Product

                        Me.DataSource = AdvantageFramework.Database.Procedures.Product.LoadCore(AdvantageFramework.Database.Procedures.Product.LoadAllActive(DbContext))

                    Case SubItemGridLookUpEditControl.Type.ProductCategory

                        Me.DataSource = AdvantageFramework.Database.Procedures.ProductCategory.LoadAllActive(DbContext)

                    Case SubItemGridLookUpEditControl.Type.Function

                        If Me.IncludeInactive Then

                            Me.DataSource = AdvantageFramework.Database.Procedures.Function.LoadForSubItemGridLookupEdit(DbContext)

                        Else

                            Me.DataSource = AdvantageFramework.Database.Procedures.Function.LoadForSubItemGridLookupEditAllActive(DbContext)

                        End If

                    Case SubItemGridLookUpEditControl.Type.JobComponent, SubItemGridLookUpEditControl.Type.JobComponentID

                        Me.DataSource = AdvantageFramework.Database.Procedures.JobComponentView.Load(DbContext)

                    Case SubItemGridLookUpEditControl.Type.JobComponentDescription

                        Me.DataSource = AdvantageFramework.Database.Procedures.JobComponentView.Load(DbContext)

                    Case SubItemGridLookUpEditControl.Type.Job

                        Me.DataSource = AdvantageFramework.Database.Procedures.JobView.LoadAllOpen(DbContext)

                    Case SubItemGridLookUpEditControl.Type.JobDescription

                        Me.DataSource = AdvantageFramework.Database.Procedures.JobView.Load(DbContext)

                    Case SubItemGridLookUpEditControl.Type.PONumber

                        Me.DataSource = DbContext.Database.SqlQuery(Of AdvantageFramework.AccountPayable.Classes.AccountPayableGLPurchaseOrders)(String.Format("exec advsp_ap_gl_purchase_orders '{0}'", ""))

                    Case SubItemGridLookUpEditControl.Type.POLineNumber

                        Me.DataSource = AdvantageFramework.Database.Procedures.PurchaseOrderDetail.Load(DbContext)

                    Case SubItemGridLookUpEditControl.Type.SalesTax

                        If _IncludeInactive Then

                            Me.DataSource = AdvantageFramework.Database.Procedures.SalesTax.Load(DbContext)

                        Else

                            Me.DataSource = AdvantageFramework.Database.Procedures.SalesTax.LoadAllActive(DbContext)

                        End If

                    Case SubItemGridLookUpEditControl.Type.PTORule

                        Me.DataSource = AdvantageFramework.Database.Procedures.PTORule.LoadAllActive(DbContext)
                        Me.View.Columns.AddField("ID").Visible = False

                    Case SubItemGridLookUpEditControl.Type.Office, SubItemGridLookUpEditControl.Type.OfficeName

                        Me.DataSource = AdvantageFramework.Database.Procedures.Office.LoadCore(AdvantageFramework.Database.Procedures.Office.LoadAllActive(DbContext))

                    Case SubItemGridLookUpEditControl.Type.GeneralLedgerAccount, SubItemGridLookUpEditControl.Type.GeneralLedgerAccountDescription

                        Me.DataSource = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadCore(AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActive(DbContext))

                    Case SubItemGridLookUpEditControl.Type.AdSize

                        Me.DataSource = AdvantageFramework.Database.Procedures.AdSize.Load(DbContext)

                    Case SubItemGridLookUpEditControl.Type.ManagementLevel

                        Me.DataSource = AdvantageFramework.Database.Procedures.ManagementLevel.LoadAllActive(DbContext)

                    Case SubItemGridLookUpEditControl.Type.EstimateFunction

                        Me.DataSource = AdvantageFramework.Database.Procedures.Function.LoadForSubItemGridLookupEditActiveByType(DbContext, "E")

                    Case SubItemGridLookUpEditControl.Type.Status

                        Me.DataSource = AdvantageFramework.Database.Procedures.Status.LoadAllActive(DbContext)

                    Case SubItemGridLookUpEditControl.Type.WebSiteType

                        Me.DataSource = AdvantageFramework.Database.Procedures.WebsiteType.LoadAllActive(DbContext)

                    Case SubItemGridLookUpEditControl.Type.EmployeeTitle

                        Me.DataSource = AdvantageFramework.Database.Procedures.EmployeeTitle.LoadAllActive(DbContext)

                    Case SubItemGridLookUpEditControl.Type.Task

                        Me.DataSource = AdvantageFramework.Database.Procedures.Task.LoadAllActive(DbContext)

                    Case SubItemGridLookUpEditControl.Type.Phase

                        Me.DataSource = AdvantageFramework.Database.Procedures.Phase.LoadAllActive(DbContext)

                    Case SubItemGridLookUpEditControl.Type.Employee

                        Me.DataSource = AdvantageFramework.Database.Procedures.EmployeeView.LoadCore(AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActiveEmployeesByUserandOffice(_Session, DbContext, SecurityDbContext))

                    Case SubItemGridLookUpEditControl.Type.EmployeeWithDepartmentAndOffice

                        Me.DataSource = AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActiveEmployeesByUserandOffice(_Session, DbContext, SecurityDbContext).Include("Office").Include("DepartmentTeam")

                    Case SubItemGridLookUpEditControl.Type.EmployeeFunction

                        Me.DataSource = AdvantageFramework.Database.Procedures.Function.LoadForSubItemGridLookupEditActiveByType(DbContext, "E")

                    Case SubItemGridLookUpEditControl.Type.MagazineOrderNumber

                        Me.DataSource = New Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableMagazineOrders)

                    Case SubItemGridLookUpEditControl.Type.MagazineOrderLineNumber

                        Me.DataSource = AdvantageFramework.Database.Procedures.MagazineDetailView.Load(DbContext)

                    Case SubItemGridLookUpEditControl.Type.Partner

                        Me.DataSource = AdvantageFramework.Database.Procedures.Partner.LoadAllActive(DbContext)

                    Case SubItemGridLookUpEditControl.Type.EmployeeCategory

                        Me.DataSource = AdvantageFramework.Database.Procedures.EmployeeCategory.LoadAllActive(DbContext)

                    Case SubItemGridLookUpEditControl.Type.MediaType

                        Me.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.MediaType))

                    Case SubItemGridLookUpEditControl.Type.ExceedOption

                        Me.DataSource = (From EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.ExceedEstimateOptions)).ToList
                                         Select [Code] = CShort(EnumObject.Code),
                                                [Description] = EnumObject.Description).ToList

                    Case SubItemGridLookUpEditControl.Type.ExpenseFunction

                        Me.DataSource = AdvantageFramework.Database.Procedures.Function.LoadCore(AdvantageFramework.Database.Procedures.Function.LoadAllActiveEmployeeExpenseVendorFunctions(DbContext))

                    Case SubItemGridLookUpEditControl.Type.AdNumber

                        Me.DataSource = AdvantageFramework.Database.Procedures.Ad.LoadAllActive(DbContext)

                    Case SubItemGridLookUpEditControl.Type.SalesClassMediaType

                        Me.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.SalesClassMediaType))

                    Case SubItemGridLookUpEditControl.Type.ClientContact

                        Me.DataSource = AdvantageFramework.Database.Procedures.ClientContact.LoadAllActive(DbContext)

                    Case SubItemGridLookUpEditControl.Type.ProductARAddressLookup

                        Me.DataSource = (From EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.ProductARAddressSelection)).ToList
                                         Select [Code] = CShort(EnumObject.Code),
                                                [Description] = EnumObject.Description).ToList

                    Case SubItemGridLookUpEditControl.Type.ClientARAddressLookup

                        Me.DataSource = (From EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.ClientARAddressSelection)).ToList
                                         Select [Code] = CShort(EnumObject.Code),
                                                [Description] = EnumObject.Description).ToList

                    Case SubItemGridLookUpEditControl.Type.DepartmentTeam, SubItemGridLookUpEditControl.Type.DepartmentTeamName

                        Me.DataSource = AdvantageFramework.Database.Procedures.DepartmentTeam.LoadAllActive(DbContext)

                    Case SubItemGridLookUpEditControl.Type.Role

                        Me.DataSource = AdvantageFramework.Database.Procedures.Role.Load(DbContext)

                    Case SubItemGridLookUpEditControl.Type.EmployeeHRStatus

                        Me.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Database.Entities.EmployeeHRStatus), GetType(Int16))

                    Case SubItemGridLookUpEditControl.Type.EmployeeVendor

                        Me.DataSource = AdvantageFramework.Database.Procedures.Vendor.LoadCore(AdvantageFramework.Database.Procedures.Vendor.LoadEmployeeVendors(DbContext))

                    Case SubItemGridLookUpEditControl.Type.POApprovalRule

                        Me.DataSource = AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRule.LoadAllActive(DbContext)

                    Case SubItemGridLookUpEditControl.Type.ReportMissingTime

                        Me.DataSource = (From EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.ReportMissingTime)).ToList
                                         Select [Code] = CShort(EnumObject.Code),
                                                [Description] = EnumObject.Description).ToList

                    Case SubItemGridLookUpEditControl.Type.AlertGroup

                        Me.DataSource = AdvantageFramework.Database.Procedures.AlertGroup.LoadDistinctAlertGroups(DbContext)

                    Case SubItemGridLookUpEditControl.Type.SalesClass

                        Me.DataSource = AdvantageFramework.Database.Procedures.SalesClass.LoadAllActive(DbContext)

                    Case SubItemGridLookUpEditControl.Type.YesNoSkip

                        Me.DataSource = (From EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.Yes1No0)).ToList
                                         Select [Code] = CShort(EnumObject.Code),
                                                [Description] = EnumObject.Description).ToList

                    Case SubItemGridLookUpEditControl.Type.FeeTime

                        Me.DataSource = (From EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.FeeTimes)).ToList
                                         Select [Code] = CShort(EnumObject.Code),
                                                [Description] = EnumObject.Description).ToList

                    Case SubItemGridLookUpEditControl.Type.MarkupTaxFlags

                        Me.DataSource = (From EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.MarkupTaxFlags)).ToList
                                         Select [Code] = CShort(EnumObject.Code),
                                                [Description] = EnumObject.Description).ToList

                    Case SubItemGridLookUpEditControl.Type.FunctionType

                        Me.DataSource = (From EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.FunctionTypes)).ToList
                                         Select [Code] = EnumObject.Code,
                                                [Description] = EnumObject.Description).ToList

                    Case SubItemGridLookUpEditControl.Type.FunctionHeading

                        Me.DataSource = AdvantageFramework.Database.Procedures.FunctionHeading.LoadAllActive(DbContext)

                    Case SubItemGridLookUpEditControl.Type.Vendor

                        If Me.IncludeInactive Then

                            Me.DataSource = AdvantageFramework.Database.Procedures.Vendor.LoadCore(AdvantageFramework.Database.Procedures.Vendor.LoadWithOfficeLimits(DbContext, _Session))

                        Else

                            Me.DataSource = AdvantageFramework.Database.Procedures.Vendor.LoadCore(AdvantageFramework.Database.Procedures.Vendor.LoadAllActiveWithOfficeLimits(DbContext, _Session))

                        End If

                    Case SubItemGridLookUpEditControl.Type.BeforeAfter

                        Me.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Database.Entities.BeforeAfter), GetType(Int16))

                    Case SubItemGridLookUpEditControl.Type.ResourceTaskCondition

                        Me.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Database.Entities.ResourceTaskCondition), GetType(Int16))

                    Case SubItemGridLookUpEditControl.Type.VendorTerm

                        Me.DataSource = AdvantageFramework.Database.Procedures.VendorTerm.LoadAllActive(DbContext)

                    Case SubItemGridLookUpEditControl.Type.ImportVendorCategory

                        Me.DataSource = From Entity In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.ImportVendorCategories))
                                        Select Entity.Code,
                                               [Description] = Entity.ToString

                    Case SubItemGridLookUpEditControl.Type.RateBy

                        Me.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Database.Entities.RateBy), GetType(Int16))

                    Case SubItemGridLookUpEditControl.Type.RateType

                        Me.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Database.Entities.RateType), GetType(Int16))

                    Case SubItemGridLookUpEditControl.Type.VendorFunction

                        Me.DataSource = AdvantageFramework.Database.Procedures.Function.LoadForSubItemGridLookupByType(DbContext, "V")

                    Case SubItemGridLookUpEditControl.Type.ImportTemplateProperty

                        Me.DataSource = (From EnumObject In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Database.Entities.ImportCreditCardStaging.Properties)).ToList
                                         Where EnumObject.Key > 1
                                         Select [Code] = CShort(EnumObject.Key),
                                                [Description] = EnumObject.Value).ToList

                    Case SubItemGridLookUpEditControl.Type.ExpenseItemPayment

                        Me.DataSource = (From EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.ExpenseItemPaymentType)).ToList
                                         Select [Code] = CShort(EnumObject.Code),
                                                [Description] = EnumObject.Description).ToList

                    Case SubItemGridLookUpEditControl.Type.IndirectCategoryType

                        'Me.DataSource = (From KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Database.Entities.TimeCategoryTypes)) _
                        '                 Select [Name] = KeyValuePair.Value, _
                        '                        [ID] = CShort(KeyValuePair.Key)).ToList

                        Me.DataSource = AdvantageFramework.Database.Procedures.TimeCategoryType.Load(DbContext)

                    Case SubItemGridLookUpEditControl.Type.ServiceFeeType

                        Me.DataSource = AdvantageFramework.Database.Procedures.ServiceFeeType.LoadAllActive(DbContext).OrderBy(Function(Entity) Entity.Code)

                    Case SubItemGridLookUpEditControl.Type.Bank

                        Me.DataSource = AdvantageFramework.Database.Procedures.Bank.LoadAllActive(DbContext)

                    Case SubItemGridLookUpEditControl.Type.Market

                        Me.DataSource = AdvantageFramework.Database.Procedures.Market.LoadAllActive(DbContext)

                    Case SubItemGridLookUpEditControl.Type.Daypart, SubItemGridLookUpEditControl.Type.DaypartCode

                        Me.DataSource = AdvantageFramework.Database.Procedures.Daypart.Load(DbContext)

                    Case SubItemGridLookUpEditControl.Type.JobVersionDatabaseType

                        Me.DataSource = AdvantageFramework.Database.Procedures.JobVersionDatabaseType.Load(DbContext)

                    Case SubItemGridLookUpEditControl.Type.MediaApprovalStatusPendingOnly

                        Me.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Database.Entities.MediaApprovalStatusPendingOnly), GetType(Int16))

                    Case SubItemGridLookUpEditControl.Type.NewspaperOrderNumber

                        Me.DataSource = New Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableNewspaperOrders)

                    Case SubItemGridLookUpEditControl.Type.NewspaperOrderLineNumber

                        Me.DataSource = AdvantageFramework.Database.Procedures.NewspaperDetailView.Load(DbContext)

                    Case SubItemGridLookUpEditControl.Type.ExpenseReportApprovedFlag

                        Me.DataSource = (From EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.ExpenseReports.ApprovedFlag)).ToList
                                         Select [Code] = CShort(EnumObject.Code),
                                                [Description] = EnumObject.Description).ToList

                    Case SubItemGridLookUpEditControl.Type.ExpenseEmployee

                        Me.DataSource = AdvantageFramework.Database.Procedures.EmployeeView.LoadCore(AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActiveExpenseEmployees(DbContext))

                    Case SubItemGridLookUpEditControl.Type.InternetOrderNumber

                        Me.DataSource = New Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableInternetOrders)

                    Case SubItemGridLookUpEditControl.Type.InternetOrderLineNumber

                        Me.DataSource = AdvantageFramework.Database.Procedures.InternetOrderDetail.Load(DbContext)

                    Case SubItemGridLookUpEditControl.Type.OutOfHomeOrderNumber

                        Me.DataSource = New Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableOutOfHomeOrders)

                    Case SubItemGridLookUpEditControl.Type.OutOfHomeOrderLineNumber

                        Me.DataSource = AdvantageFramework.Database.Procedures.OutOfHomeOrderDetail.Load(DbContext)

                    Case SubItemGridLookUpEditControl.Type.RadioOrderNumber

                        Me.DataSource = New Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableRadioOrders)

                    Case SubItemGridLookUpEditControl.Type.RadioOrderLineNumber

                        Me.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.RadioOrderDetail) 'AdvantageFramework.Database.Procedures.RadioOrderDetail.Load(DbContext)

                    Case SubItemGridLookUpEditControl.Type.RadioOrderLegacyMonth

                        Me.DataSource = AdvantageFramework.Database.Procedures.RadioOrderLegacy.GetMonthsByOrderNumber(DbContext, 0)

                    Case SubItemGridLookUpEditControl.Type.RadioOrderLegacyYear

                        Me.DataSource = AdvantageFramework.Database.Procedures.RadioOrderLegacy.GetYearsByOrderNumberMonth(DbContext, 0, "")

                    Case SubItemGridLookUpEditControl.Type.TVOrderNumber

                        Me.DataSource = New Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableTVOrders)

                    Case SubItemGridLookUpEditControl.Type.TVOrderLineNumber

                        Me.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.TVOrderDetail) 'AdvantageFramework.Database.Procedures.TVOrderDetail.Load(DbContext)

                    Case SubItemGridLookUpEditControl.Type.TVOrderLegacyMonth

                        Me.DataSource = AdvantageFramework.Database.Procedures.TVOrderLegacy.GetMonthsByOrderNumber(DbContext, 0)

                    Case SubItemGridLookUpEditControl.Type.TVOrderLegacyYear

                        Me.DataSource = AdvantageFramework.Database.Procedures.TVOrderLegacy.GetYearsByOrderNumberMonth(DbContext, 0, "")

                    Case SubItemGridLookUpEditControl.Type.Affiliation

                        Me.DataSource = AdvantageFramework.Database.Procedures.Affiliation.LoadAllActive(DbContext)

                    Case SubItemGridLookUpEditControl.Type.DaypartType

                        Me.DataSource = AdvantageFramework.Database.Procedures.DaypartType.LoadAllActive(DbContext)

                    Case SubItemGridLookUpEditControl.Type.Competition

                        Me.DataSource = AdvantageFramework.Database.Procedures.Competition.LoadAllActive(DbContext)

                    Case SubItemGridLookUpEditControl.Type.ServiceFeeTypeID

                        Me.DataSource = AdvantageFramework.Database.Procedures.ServiceFeeType.LoadAllActive(DbContext)

                    Case SubItemGridLookUpEditControl.Type.Cycle

                        Me.DataSource = AdvantageFramework.Database.Procedures.Cycle.LoadAllActive(DbContext)

                    Case SubItemGridLookUpEditControl.Type.Blackplate

                        Me.DataSource = AdvantageFramework.Database.Procedures.Blackplate.LoadAllActive(DbContext)

                    Case SubItemGridLookUpEditControl.Type.CycleType

                        Me.DataSource = (From EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.CycleTypes)).ToList
                                         Select [Code] = EnumObject.Code,
                                                [Description] = EnumObject.Description).ToList

                    Case SubItemGridLookUpEditControl.Type.AccountReceivable

                        Me.DataSource = AdvantageFramework.Database.Procedures.AccountReceivable.LoadNonVoidedInvoices(DbContext).OrderByDescending(Function(Entity) Entity.InvoiceNumber)

                    Case SubItemGridLookUpEditControl.Type.EnumDataTable

                        Me.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(_EnumType, _ValueType)

                    Case SubItemGridLookUpEditControl.Type.EnumObject

                        Me.DataSource = (From EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(_EnumType)
                                         Select New With {.[Code] = Convert.ChangeType(EnumObject.Code, _ValueType),
                                                          .[Description] = EnumObject.Description}).ToList

                    Case SubItemGridLookUpEditControl.Type.PostPeriod

                        If Me.IncludeInactive Then

                            Me.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList

                        Else

                            Me.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllActiveNonYearEndPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList

                        End If

                    Case SubItemGridLookUpEditControl.Type.PostPeriodStatus

                        Me.DataSource = (From EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.PostPeriodStatus)).ToList
                                         Select [Code] = EnumObject.Code,
                                                [Description] = EnumObject.Description).ToList

                    Case SubItemGridLookUpEditControl.Type.AccountPayableImportMediaType

                        Me.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.AccountPayableImportMediaType))

                    Case SubItemGridLookUpEditControl.Type.AccountPayableImportMediaOrderNumber

                        Me.DataSource = Nothing

                    Case SubItemGridLookUpEditControl.Type.AccountPayableImportMediaOrderLineNumber

                        Me.DataSource = Nothing

                    Case SubItemGridLookUpEditControl.Type.MediaPlan

                        Me.DataSource = AdvantageFramework.Database.Procedures.MediaPlan.Load(DbContext).Include("Client")

                    Case SubItemGridLookUpEditControl.Type.MediaPlanDetail

                        Me.DataSource = AdvantageFramework.Database.Procedures.MediaPlanDetail.Load(DbContext).Include("SalesClass")

                    Case SubItemGridLookUpEditControl.Type.DateFormat

                        Me.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.DateUtilities.DateFormat))

                    Case SubItemGridLookUpEditControl.Type.CostType

                        Me.DataSource = From Entity In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.CostType))
                                        Select Entity.Code,
                                               [Description] = Entity.Description

                    Case SubItemGridLookUpEditControl.Type.Location

                        Me.DataSource = AdvantageFramework.Database.Procedures.Location.Load(DataContext)

                    Case SubItemGridLookUpEditControl.Type.Campaign, SubItemGridLookUpEditControl.Type.CampaignID

                        Me.DataSource = AdvantageFramework.Database.Procedures.Campaign.LoadCore(DbContext)

                    Case SubItemGridLookUpEditControl.Type.CampaignID2

                        Me.DataSource = From Entity In AdvantageFramework.Database.Procedures.Campaign.LoadCore(DbContext)
                                        Select Entity.ID,
                                               Entity.Code,
                                               Entity.Name,
                                               [CodeName] = Entity.Code & " - " & Entity.Name

                    Case SubItemGridLookUpEditControl.Type.AccountReceivableRecordType

                        Me.DataSource = From Entity In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.AccountReceivableRecordType))
                                        Select Entity.Code,
                                               [Description] = Entity.Description

                    Case SubItemGridLookUpEditControl.Type.TaskStatus

                        Me.DataSource = From Entity In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.ProjectSchedule.TaskStatus))
                                        Select Entity.Code,
                                               [Description] = Entity.Description

                    Case SubItemGridLookUpEditControl.Type.GeneralLedgerAccountTypes

                        EnumObjectsList = New Generic.List(Of AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute)

                        EnumObjectsList.Add(AdvantageFramework.EnumUtilities.LoadEnumObject(GeneralLedger.ReportWriter.AccountTypes.CurrentAsset))
                        EnumObjectsList.Add(AdvantageFramework.EnumUtilities.LoadEnumObject(GeneralLedger.ReportWriter.AccountTypes.NonCurrentAsset))
                        EnumObjectsList.Add(AdvantageFramework.EnumUtilities.LoadEnumObject(GeneralLedger.ReportWriter.AccountTypes.FixedAsset))
                        EnumObjectsList.Add(AdvantageFramework.EnumUtilities.LoadEnumObject(GeneralLedger.ReportWriter.AccountTypes.CurrentLiability))
                        EnumObjectsList.Add(AdvantageFramework.EnumUtilities.LoadEnumObject(GeneralLedger.ReportWriter.AccountTypes.NonCurrentLiability))
                        EnumObjectsList.Add(AdvantageFramework.EnumUtilities.LoadEnumObject(GeneralLedger.ReportWriter.AccountTypes.Equity))
                        EnumObjectsList.Add(AdvantageFramework.EnumUtilities.LoadEnumObject(GeneralLedger.ReportWriter.AccountTypes.Income))
                        EnumObjectsList.Add(AdvantageFramework.EnumUtilities.LoadEnumObject(GeneralLedger.ReportWriter.AccountTypes.IncomeOther))
                        EnumObjectsList.Add(AdvantageFramework.EnumUtilities.LoadEnumObject(GeneralLedger.ReportWriter.AccountTypes.ExpenseCOS))
                        EnumObjectsList.Add(AdvantageFramework.EnumUtilities.LoadEnumObject(GeneralLedger.ReportWriter.AccountTypes.ExpenseOperating))
                        EnumObjectsList.Add(AdvantageFramework.EnumUtilities.LoadEnumObject(GeneralLedger.ReportWriter.AccountTypes.ExpenseOther))
                        EnumObjectsList.Add(AdvantageFramework.EnumUtilities.LoadEnumObject(GeneralLedger.ReportWriter.AccountTypes.ExpenseTaxes))

                        Me.DataSource = EnumObjectsList

                    Case SubItemGridLookUpEditControl.Type.GeneralLedgerBalanceTypes

                        Me.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.GeneralLedger.BalanceTypes), GetType(Int16))

                    Case SubItemGridLookUpEditControl.Type.CurrencyCode

                        Me.DataSource = AdvantageFramework.Database.Procedures.CurrencyCode.Load(DbContext)

                    Case SubItemGridLookUpEditControl.Type.ProductionBillHoldStatus

                        Me.DataSource = (From EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.BillingCommandCenter.ProductionBillHoldStatus)).ToList
                                         Select [Code] = CShort(EnumObject.Code),
                                                [Description] = EnumObject.Description).ToList

                    Case SubItemGridLookUpEditControl.Type.JobProcess

                        Me.DataSource = AdvantageFramework.Database.Procedures.JobProcess.Load(DataContext)

                    Case SubItemGridLookUpEditControl.Type.ProductionReconcileStatus

                        Me.DataSource = From Entity In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.BillingCommandCenter.ProductionReconcileStatus))
                                        Select Entity.Code,
                                               [Description] = Entity.Description

                    Case SubItemGridLookUpEditControl.Type.ServiceFeeFrequency

                        Me.DataSource = From Entity In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Database.Entities.ServiceFeeFrequency))
                                        Select [Code] = CShort(Entity.Key),
                                               [Description] = Entity.Value

                    Case SubItemGridLookUpEditControl.Type.InvoiceCategory

                        Me.DataSource = AdvantageFramework.Database.Procedures.InvoiceCategory.LoadAllActive(DbContext)

                    Case SubItemGridLookUpEditControl.Type.CustomProductionInvoice

                        Me.DataSource = AdvantageFramework.Database.Procedures.CustomReport.LoadAllActiveProductionReports(DbContext)

                    Case SubItemGridLookUpEditControl.Type.CustomMagazineInvoice

                        Me.DataSource = AdvantageFramework.Database.Procedures.CustomReport.LoadAllActiveMagazineReports(DbContext)

                    Case SubItemGridLookUpEditControl.Type.CustomNewspaperInvoice

                        Me.DataSource = AdvantageFramework.Database.Procedures.CustomReport.LoadAllActiveNewspaperReports(DbContext)

                    Case SubItemGridLookUpEditControl.Type.CustomInternetInvoice

                        Me.DataSource = AdvantageFramework.Database.Procedures.CustomReport.LoadAllActiveInternetReports(DbContext)

                    Case SubItemGridLookUpEditControl.Type.CustomOutdoorInvoice

                        Me.DataSource = AdvantageFramework.Database.Procedures.CustomReport.LoadAllActiveOutOfHomeReports(DbContext)

                    Case SubItemGridLookUpEditControl.Type.CustomRadioInvoice

                        Me.DataSource = AdvantageFramework.Database.Procedures.CustomReport.LoadAllActiveRadioReports(DbContext)

                    Case SubItemGridLookUpEditControl.Type.CustomTVInvoice

                        Me.DataSource = AdvantageFramework.Database.Procedures.CustomReport.LoadAllActiveTVReports(DbContext)

                    Case SubItemGridLookUpEditControl.Type.InternetType

                        Me.DataSource = AdvantageFramework.Database.Procedures.InternetType.LoadAllActive(DbContext)

                    Case SubItemGridLookUpEditControl.Type.JobProcessControl

                        Me.DataSource = AdvantageFramework.Database.Procedures.JobProcess.Load(DataContext)

                    Case SubItemGridLookUpEditControl.Type.VendorServiceTaxType

                        Me.DataSource = From Entity In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.VendorServiceTaxType))
                                        Select Entity.Code,
                                               [Description] = Entity.Description

                    Case SubItemGridLookUpEditControl.Type.AvalaraTaxID

                        Me.DataSource = AdvantageFramework.Database.Procedures.AvalaraTax.LoadAllActive(DataContext)

                    Case SubItemGridLookUpEditControl.Type.OverheadAccountCode

                        Me.DataSource = AdvantageFramework.Database.Procedures.OverheadAccount.LoadDistinctOverheadAccounts(DbContext)

                    Case SubItemGridLookUpEditControl.Type.ProductionCustomInvoiceID

                        Me.DataSource = AdvantageFramework.Reporting.Database.Procedures.CustomInvoice.LoadProductionCustomInvoices(ReportingDbContext)

                    Case SubItemGridLookUpEditControl.Type.MediaCustomInvoiceID

                        Me.DataSource = AdvantageFramework.Reporting.Database.Procedures.CustomInvoice.LoadMediaCustomInvoices(ReportingDbContext)

                    Case SubItemGridLookUpEditControl.Type.BillingCoopCode

                        Me.DataSource = AdvantageFramework.Database.Procedures.BillingCoop.LoadAllActive(DbContext)

                    Case SubItemGridLookUpEditControl.Type.EstimateCustomID

                        Me.DataSource = AdvantageFramework.Reporting.Database.Procedures.EstimateReport.LoadEstimateReports(ReportingDbContext)

                    Case SubItemGridLookUpEditControl.Type.ContactType

                        Me.DataSource = AdvantageFramework.Database.Procedures.ContactType.Load(DbContext)

                    Case SubItemGridLookUpEditControl.Type.AccountReceivableSequenceNumber

                        Me.DataSource = Nothing

                    Case SubItemGridLookUpEditControl.Type.VCCStatus

                        Me.DataSource = (From EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.VCCStatus)).ToList
                                         Select [Code] = EnumObject.Code,
                                                [Description] = EnumObject.Description).ToList

                    Case SubItemGridLookUpEditControl.Type.CashReceiptPaymentType

                        Me.DataSource = AdvantageFramework.Database.Procedures.CashReceiptPaymentType.LoadAllActive(DbContext).ToList

                    Case SubItemGridLookUpEditControl.Type.OutOfHomeType

                        Me.DataSource = AdvantageFramework.Database.Procedures.OutOfHomeType.LoadAllActive(DbContext)

                    Case SubItemGridLookUpEditControl.Type.DocumentType

                        Me.DataSource = AdvantageFramework.Database.Procedures.DocumentType.LoadActive(DataContext)

                    Case SubItemGridLookUpEditControl.Type.IOOrderNumber

                        Me.DataSource = New Generic.List(Of AdvantageFramework.IncomeOnly.Classes.Order)

                    Case SubItemGridLookUpEditControl.Type.IOOrderLineNumber

                        Me.DataSource = New Generic.List(Of AdvantageFramework.IncomeOnly.Classes.OrderLine)

                    Case SubItemGridLookUpEditControl.Type.OrderProcess

                        Me.DataSource = AdvantageFramework.Database.Procedures.JobProcess.LoadMediaProcesses(DataContext)

                    Case SubItemGridLookUpEditControl.Type.StateCode, SubItemGridLookUpEditControl.Type.StateName

                        Me.DataSource = (From State In DbContext.States
                                         Select State).ToList

                    Case SubItemGridLookUpEditControl.Type.IndirectCategory

                        Me.DataSource = AdvantageFramework.Database.Procedures.IndirectCategory.LoadAllActive(DbContext)

                    Case SubItemGridLookUpEditControl.Type.JobTemplateMapping

                        Me.DataSource = (From Entity In AdvantageFramework.Database.Procedures.JobTemplateItem.Load(DbContext)
                                         Select Entity.Code, Entity.Description).ToList

                    Case SubItemGridLookUpEditControl.Type.GeneralLedgerSource

                        Me.DataSource = AdvantageFramework.Database.Procedures.GeneralLedgerSource.Load(DbContext)

                    Case SubItemGridLookUpEditControl.Type.BuyerEmployeeCode

                        Me.DataSource = (From Entity In AdvantageFramework.Database.Procedures.MediaBuyer.LoadAllActive(DbContext).ToList
                                         Select [Code] = Entity.EmployeeCode,
                                                [Name] = Entity.Employee.ToString).ToList

                    Case SubItemGridLookUpEditControl.Type.ClientPO

                        Me.DataSource = AdvantageFramework.Database.Procedures.ClientPO.LoadActive(DataContext)

                    Case SubItemGridLookUpEditControl.Type.CableNetworkStation

                        Me.DataSource = AdvantageFramework.Database.Procedures.CableNetworkStation.Load(DbContext).OrderBy(Function(cableNetwork) cableNetwork.Code).ToList

                    Case SubItemGridLookUpEditControl.Type.ClientDiscount

                        Me.DataSource = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.ClientDiscount)
                                         Where Entity.IsInactive = False
                                         Select [Code] = Entity.Code,
                                                [Name] = Entity.Name).ToList

                    Case SubItemGridLookUpEditControl.Type.AccountPayableImportMediaOrderNumberAutoFill

                        Me.DataSource = Nothing

                    Case SubItemGridLookUpEditControl.Type.AlertTemplate

                        Me.DataSource = (From Entity In AdvantageFramework.Database.Procedures.AlertAssignmentTemplate.Load(DbContext)
                                         Select [ID] = Entity.ID,
                                                [Name] = Entity.Name).ToList

                    Case SubItemGridLookUpEditControl.Type.AlertState

                        Me.DataSource = (From Entity In AdvantageFramework.Database.Procedures.AlertState.Load(DbContext)
                                         Select [ID] = Entity.ID,
                                                [Name] = Entity.Name).ToList

                    Case SubItemGridLookUpEditControl.Type.MediaChannelID

                        Me.DataSource = (From Entity In AdvantageFramework.Database.Procedures.MediaChannel.Load(DbContext)
                                         Select Entity.ID,
                                                Entity.Description).ToList

                    Case SubItemGridLookUpEditControl.Type.MediaTacticID

                        Me.DataSource = (From Entity In AdvantageFramework.Database.Procedures.MediaTactic.Load(DbContext)
                                         Select Entity.ID,
                                                Entity.Description).ToList

                    Case SubItemGridLookUpEditControl.Type.Assignment

                        Me.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Alert.Load(DbContext)
                                         Where Entity.AlertTypeID = 6
                                         Select New With {.ID = Entity.ID,
                                                          .Description = Entity.Subject}).ToList

                End Select

            End If

        End Sub
        Public Sub LoadDefaultDataSourceView(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext)

            If _Session IsNot Nothing AndAlso DbContext IsNot Nothing Then

                Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        LoadDefaultDataSourceView(DbContext, ReportingDbContext, SecurityDbContext, DataContext)

                    End Using

                End Using

            End If

        End Sub
        Public Sub LoadDefaultDataSourceView()

            'objects
            Dim CustomList As IEnumerable = Nothing

            If _Session IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                                LoadDefaultDataSourceView(DbContext, ReportingDbContext, SecurityDbContext, DataContext)

                            End Using

                        End Using

                    End Using

                End Using

            End If

        End Sub
        Public Sub RemoveAddedItemsFromDataSource()

            RemoveAddedItemsFromDataSource(Me.DataSource)

        End Sub
        Public Sub RemoveFromDataSource(Value As Object)

            AdvantageFramework.WinForm.Presentation.Controls.SuspendBindingOnABindingSource(Me.DataSource)

            Try

                For Each Item In CType(Me.DataSource, System.Windows.Forms.BindingSource).OfType(Of Object).ToList

                    If Item.Code = Value Then

                        CType(Me.DataSource, System.Windows.Forms.BindingSource).Remove(Item)

                    End If

                Next

            Catch ex As Exception

            End Try

            AdvantageFramework.WinForm.Presentation.Controls.ResumeBindingOnABindingSource(Me.DataSource)

        End Sub
        Private Sub RemoveAddedItemsFromDataSource(ByVal BindingSource As System.Windows.Forms.BindingSource)

            AdvantageFramework.WinForm.Presentation.Controls.SuspendBindingOnABindingSource(BindingSource)

            Try

                For Each AddedItem In _AddedItemsToDataSource

                    BindingSource.Remove(AddedItem)

                Next

            Catch ex As Exception

            End Try

            AdvantageFramework.WinForm.Presentation.Controls.ResumeBindingOnABindingSource(BindingSource)

        End Sub

#Region "  Control Event Handlers "

        Private Sub SubItemGridLookUpEditControl_CloseUp(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.CloseUpEventArgs) Handles Me.CloseUp

            If e.Value IsNot Nothing AndAlso
                    IsNumeric(e.Value) AndAlso
                    CDbl(e.Value) < 0 Then

                e.Value = Nothing

            End If

            Try

                DirectCast(sender, DevExpress.XtraEditors.GridLookUpEdit).Properties.View.ClearSorting()

            Catch ex As Exception

            End Try

        End Sub
        Private Sub SubItemGridLookUpEditControl_CustomDisplayText(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs) Handles Me.CustomDisplayText

            If e.DisplayText = "" AndAlso (IsNothing(e.Value) = False AndAlso IsDBNull(e.Value) = False) Then

                Try

                    Select Case _ControlType

                        Case Type.PTORule

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                e.DisplayText = AdvantageFramework.Database.Procedures.PTORule.LoadByID(DbContext, e.Value).Name

                            End Using

                        Case Type.EmployeeTitle

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                e.DisplayText = AdvantageFramework.Database.Procedures.EmployeeTitle.LoadByEmployeeTitleID(DbContext, e.Value).Description

                            End Using

                        Case Type.ClientARAddressLookup

                            If e.Value <> 0 Then

                                e.DisplayText = AdvantageFramework.EnumUtilities.GetNameAsWords(GetType(AdvantageFramework.Database.Entities.ClientARAddressSelection), CInt(e.Value))

                            Else

                                e.DisplayText = ""

                            End If

                        Case Type.ProductARAddressLookup

                            If e.Value <> 0 Then

                                e.DisplayText = AdvantageFramework.EnumUtilities.GetNameAsWords(GetType(AdvantageFramework.Database.Entities.ProductARAddressSelection), CInt(e.Value))

                            Else

                                e.DisplayText = ""

                            End If

                        Case Type.ClientContact

                            If IsNumeric(e.Value) = False OrElse e.Value = 0 Then

                                e.DisplayText = ""

                            End If

                        Case Type.JobVersionDatabaseType

                            If e.Value = 0 Then

                                e.DisplayText = ""

                            End If

                        Case Type.JobTemplateMapping

                            If e.Value = "" Then

                                e.DisplayText = ""

                            End If

                        Case Type.PostPeriodStatus

                            If e.Value = "" Then

                                e.DisplayText = AdvantageFramework.Database.Entities.PostPeriodStatus.Open.ToString

                            End If

                        Case Type.MediaPlan

                            If e.Value = 0 Then

                                e.DisplayText = ""

                            Else

                                e.DisplayText = CStr(e.Value)

                            End If

                        Case Type.MediaPlanDetail

                            If e.Value = 0 Then

                                e.DisplayText = ""

                            Else

                                e.DisplayText = CStr(e.Value)

                            End If

                        Case Type.JobComponentID

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                e.DisplayText = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobComponentID(DbContext, e.Value).Number

                            End Using

                        Case Else

                            e.DisplayText = e.Value.ToString

                    End Select

                Catch ex As Exception
                    e.DisplayText = e.Value.ToString
                End Try

            ElseIf e.DisplayText = "" AndAlso (IsNothing(e.Value) OrElse IsDBNull(e.Value)) AndAlso _ExtraComboBoxItem <> ExtraComboBoxItems.Nothing Then

                Select Case _ExtraComboBoxItem

                    Case ExtraComboBoxItems.NullValue


                    Case ExtraComboBoxItems.Nothing


                    Case ExtraComboBoxItems.None

                        e.DisplayText = ""

                    Case Else

                        e.DisplayText = "[" & AdvantageFramework.StringUtilities.GetNameAsWords(_ExtraComboBoxItem.ToString) & "]"

                End Select

            End If

        End Sub
        Private Sub SubItemGridLookUpEditControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.Validating

            If _IsNewValue Then

                e.Cancel = True
                _CancelPopup = False

            End If

        End Sub
        Private Sub SubItemGridLookUpEditControl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

            'objects
            Dim GridLookUpEdit As DevExpress.XtraEditors.GridLookUpEdit = Nothing

            If e.KeyCode = Windows.Forms.Keys.F4 Then

                _CancelPopup = False

            ElseIf e.KeyCode = Windows.Forms.Keys.Delete Then

                If TypeOf sender Is DevExpress.XtraEditors.GridLookUpEdit Then

                    GridLookUpEdit = DirectCast(sender, DevExpress.XtraEditors.GridLookUpEdit)

                    GridLookUpEdit.SelectAll()

                    If GridLookUpEdit.Properties.AllowNullInput <> DevExpress.Utils.DefaultBoolean.False Then

                        GridLookUpEdit.EditValue = Nothing

                    End If

                End If

            ElseIf e.KeyCode = Windows.Forms.Keys.Escape Then

                DirectCast(sender, DevExpress.XtraEditors.GridLookUpEdit).EditValue = DirectCast(sender, DevExpress.XtraEditors.GridLookUpEdit).OldEditValue

            Else

                _CancelPopup = True

            End If

        End Sub
        Private Sub SubItemGridLookUpEditControl_KeyUp(sender As Object, e As Windows.Forms.KeyEventArgs) Handles Me.KeyUp

            'objects
            Dim GridLookUpEdit As DevExpress.XtraEditors.GridLookUpEdit = Nothing

            If e.KeyCode = Windows.Forms.Keys.Back Then

                If TypeOf sender Is DevExpress.XtraEditors.GridLookUpEdit Then

                    GridLookUpEdit = DirectCast(sender, DevExpress.XtraEditors.GridLookUpEdit)

                    If GridLookUpEdit.Properties.GetDisplayText(GridLookUpEdit.EditValue) = "" AndAlso GridLookUpEdit.Properties.AllowNullInput <> DevExpress.Utils.DefaultBoolean.False Then

                        GridLookUpEdit.EditValue = Nothing

                    End If

                End If

            End If

        End Sub
        Private Sub SubItemGridLookUpEditControl_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown

            If e.Button = Windows.Forms.MouseButtons.Left Then

                _CancelPopup = False

            End If

        End Sub
        Private Sub SubItemGridLookUpEditControl_ParseEditValue(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs) Handles Me.ParseEditValue

            'If (_ExtraComboBoxItem = ExtraComboBoxItems.AgencyDefault OrElse _
            '_ExtraComboBoxItem = ExtraComboBoxItems.Skip OrElse _
            '_ExtraComboBoxItem = ExtraComboBoxItems.NullValue) Then

            'If e.Value Is Nothing Then

            '    If DirectCast(sender, DevExpress.XtraEditors.GridLookUpEdit).Focused Then

            '        e.Value = Conversion.CTypeDynamic(_ExtraComboBoxItem, _ValueType)
            '        DirectCast(sender, DevExpress.XtraEditors.GridLookUpEdit).Text = ""
            '        DirectCast(sender, DevExpress.XtraEditors.GridLookUpEdit).Properties.View.FocusedRowHandle = 0

            '    End If

            '    e.Handled = True

            'ElseIf e.Value IsNot Nothing AndAlso _
            '        IsNumeric(e.Value) AndAlso _
            '        CDbl(e.Value) < 0 Then

            '    e.Handled = True

            '    DirectCast(sender, DevExpress.XtraEditors.GridLookUpEdit).Text = ""
            '    e.Value = Nothing
            '    DirectCast(sender, DevExpress.XtraEditors.GridLookUpEdit).Properties.View.FocusedRowHandle = 0

            'End If

            'Else

            If _ControlType = SubItemGridLookUpEditControl.Type.MagazineOrderNumber OrElse
                    _ControlType = SubItemGridLookUpEditControl.Type.NewspaperOrderNumber OrElse
                    _ControlType = SubItemGridLookUpEditControl.Type.InternetOrderNumber OrElse
                    _ControlType = SubItemGridLookUpEditControl.Type.OutOfHomeOrderNumber OrElse
                    _ControlType = SubItemGridLookUpEditControl.Type.RadioOrderNumber OrElse
                    _ControlType = SubItemGridLookUpEditControl.Type.TVOrderNumber OrElse
                    _ControlType = SubItemGridLookUpEditControl.Type.AccountPayableImportMediaOrderNumber Then

                If Me.ValueMember = "OrderNumber" AndAlso InStr(e.Value, "|") > 0 Then

                    e.Value = CInt(Strings.Mid(e.Value, 1, InStr(e.Value, "|") - 1))

                End If

            ElseIf _ControlType = Type.AccountReceivable Then

                If Me.ValueMember = "InvoiceNumber" AndAlso InStr(e.Value, "|") > 0 Then

                    e.Value = CInt(Strings.Mid(e.Value, 1, InStr(e.Value, "|") - 1))

                End If

            ElseIf _ControlType = Type.PostPeriodStatus Then

                If IsNothing(e.Value) Then

                    e.Value = ""

                End If

            End If

        End Sub
        Private Sub SubItemGridLookUpEditControl_ProcessNewValue(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs) Handles Me.ProcessNewValue

            Dim FoundObject As Object = Nothing

            If (_ControlType = Type.Task) AndAlso (TypeOf e.DisplayValue Is String AndAlso e.DisplayValue <> "") Then

                FoundObject = AdvantageFramework.WinForm.Presentation.Controls.FindObjectInDataSource(Me.DataSource, Me.ValueMember, e.DisplayValue)

                If FoundObject IsNot Nothing Then

                    e.DisplayValue = FoundObject.Description

                    _CancelPopup = True
                    _IsNewValue = False
                    e.Handled = True

                Else

                    _CancelPopup = False
                    _IsNewValue = True
                    e.Handled = True

                End If

            ElseIf (TypeOf e.DisplayValue Is String AndAlso e.DisplayValue <> "") OrElse
                    (TypeOf e.DisplayValue Is Int32 AndAlso e.DisplayValue <> 0) OrElse
                    (TypeOf e.DisplayValue Is Short AndAlso e.DisplayValue <> 0) Then

                _CancelPopup = False
                _IsNewValue = True
                e.Handled = True

            Else

                e.Handled = True

            End If

        End Sub
        Private Sub SubItemGridLookUpEditControl_QueryPopUp(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.QueryPopUp

            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim PTORule As AdvantageFramework.Database.Entities.PTORule = Nothing

            If Not _CancelPopup Then

                Me.RemoveAddedItemsFromDataSource()

                Select Case Me.ControlType

                    Case SubItemGridLookUpEditControl.Type.PONumber, SubItemGridLookUpEditControl.Type.Job

                        Try

                            DirectCast(sender, DevExpress.XtraEditors.GridLookUpEdit).Properties.View.ClearSorting()

                        Catch ex As Exception

                        End Try

                        Try

                            DirectCast(sender, DevExpress.XtraEditors.GridLookUpEdit).Properties.View.Columns("Number").SortOrder = DevExpress.Data.ColumnSortOrder.Descending

                        Catch ex As Exception

                        End Try

                    Case SubItemGridLookUpEditControl.Type.MagazineOrderNumber, SubItemGridLookUpEditControl.Type.NewspaperOrderNumber,
                         SubItemGridLookUpEditControl.Type.InternetOrderNumber, SubItemGridLookUpEditControl.Type.OutOfHomeOrderNumber,
                         SubItemGridLookUpEditControl.Type.RadioOrderNumber, SubItemGridLookUpEditControl.Type.TVOrderNumber,
                         SubItemGridLookUpEditControl.Type.AccountPayableImportMediaOrderNumber

                        If Me.ControlType = SubItemGridLookUpEditControl.Type.AccountPayableImportMediaOrderNumber Then

                            Try

                                For Each GridColumn In DirectCast(sender, DevExpress.XtraEditors.GridLookUpEdit).Properties.View.Columns

                                    If GridColumn.FieldName <> "VendorCode" AndAlso
                                            GridColumn.FieldName <> "ClientCode" AndAlso
                                            GridColumn.FieldName <> "DivisionCode" AndAlso
                                            GridColumn.FieldName <> "ProductCode" AndAlso
                                            GridColumn.FieldName <> "OrderNumber" AndAlso
                                            GridColumn.FieldName <> "LineNumber" AndAlso
                                            GridColumn.FieldName <> "InsertDate" AndAlso
                                            GridColumn.FieldName <> "OrderDescription" AndAlso
                                            GridColumn.FieldName <> "LinkID" AndAlso
                                            GridColumn.FieldName <> "ClientPO" AndAlso
                                            GridColumn.FieldName <> "MarketCode" AndAlso
                                            GridColumn.FieldName <> "Month" AndAlso
                                            GridColumn.FieldName <> "Year" AndAlso
                                            GridColumn.FieldName <> "StartDate" AndAlso
                                            GridColumn.FieldName <> "EndDate" AndAlso
                                            GridColumn.FieldName <> "Description" AndAlso
                                            GridColumn.FieldName <> "GrossRate" AndAlso
                                            GridColumn.FieldName <> "NetworkID" AndAlso
                                            GridColumn.FieldName <> "Quantity" AndAlso
                                            GridColumn.FieldName <> "NetRate" AndAlso
                                            GridColumn.FieldName <> "StartTime" AndAlso
                                            GridColumn.FieldName <> "EndTime" AndAlso
                                            GridColumn.FieldName <> "Type" Then

                                        GridColumn.Visible = False

                                    ElseIf (Me.ControlType = SubItemGridLookUpEditControl.Type.InternetOrderNumber OrElse Me.ControlType = SubItemGridLookUpEditControl.Type.AccountPayableImportMediaOrderNumber) AndAlso
                                            GridColumn.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableInternetOrders.Properties.EndDate.ToString Then

                                        GridColumn.Visible = False

                                    End If

                                Next

                            Catch ex As Exception

                            End Try

                        End If

                        Try

                            DirectCast(sender, DevExpress.XtraEditors.GridLookUpEdit).Properties.View.ClearSorting()

                        Catch ex As Exception

                        End Try

                        Try

                            DirectCast(sender, DevExpress.XtraEditors.GridLookUpEdit).Properties.View.Columns("OrderNumber").SortOrder = DevExpress.Data.ColumnSortOrder.Descending
                            DirectCast(sender, DevExpress.XtraEditors.GridLookUpEdit).Properties.View.Columns("LineNumber").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending

                        Catch ex As Exception

                        End Try

                    Case SubItemGridLookUpEditControl.Type.PTORule

                        If IsNothing(DirectCast(sender, DevExpress.XtraEditors.GridLookUpEdit).EditValue) = False AndAlso
                                AdvantageFramework.WinForm.Presentation.Controls.FindObjectInDataSource(Me.DataSource, Me.ValueMember, DirectCast(sender, DevExpress.XtraEditors.GridLookUpEdit).EditValue) Is Nothing Then

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                PTORule = AdvantageFramework.Database.Procedures.PTORule.LoadByID(DbContext, DirectCast(sender, DevExpress.XtraEditors.GridLookUpEdit).EditValue)

                                If PTORule IsNot Nothing Then

                                    AddComboItemToExistingDatasource(PTORule.Name, PTORule.ID, False)

                                End If

                            End Using

                        End If

                    Case SubItemGridLookUpEditControl.Type.RadioOrderLegacyYear, SubItemGridLookUpEditControl.Type.TVOrderLegacyYear

                        Try

                            DirectCast(sender, DevExpress.XtraEditors.GridLookUpEdit).Properties.View.ClearSorting()

                        Catch ex As Exception

                        End Try

                        Try

                            DirectCast(sender, DevExpress.XtraEditors.GridLookUpEdit).Properties.View.Columns("Column").SortOrder = DevExpress.Data.ColumnSortOrder.Descending

                        Catch ex As Exception

                        End Try

                    Case SubItemGridLookUpEditControl.Type.AccountPayableImportMediaOrderLineNumber

                        Try

                            For Each GridColumn In DirectCast(sender, DevExpress.XtraEditors.GridLookUpEdit).Properties.View.Columns

                                If GridColumn.FieldName <> "LineNumber" AndAlso
                                        GridColumn.FieldName <> "InsertDate" AndAlso
                                        GridColumn.FieldName <> "Headline" AndAlso
                                        GridColumn.FieldName <> "Month" AndAlso
                                        GridColumn.FieldName <> "Year" AndAlso
                                        GridColumn.FieldName <> "Date" AndAlso
                                        GridColumn.FieldName <> "Programming" AndAlso
                                        GridColumn.FieldName <> "NetworkID" AndAlso
                                        GridColumn.FieldName <> "StartDate" AndAlso
                                        GridColumn.FieldName <> "EndDate" AndAlso
                                        GridColumn.FieldName <> "Quantity" AndAlso
                                        GridColumn.FieldName <> "GrossRate" AndAlso
                                        GridColumn.FieldName <> "Length" AndAlso
                                        GridColumn.FieldName <> "NetRate" AndAlso
                                        GridColumn.FieldName <> "StartTime" AndAlso
                                        GridColumn.FieldName <> "EndTime" Then

                                    GridColumn.Visible = False

                                End If

                            Next

                        Catch ex As Exception

                        End Try

                End Select

                DirectCast(sender, DevExpress.XtraEditors.GridLookUpEdit).Properties.View.BestFitColumns()

            End If

            e.Cancel = _CancelPopup

            If e.Cancel = False Then

                _GridLookUpEdit = sender

            End If

        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub _GridView_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles _GridView.CustomColumnDisplayText

            'objects
            Dim EnumObject As AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute = Nothing
            Dim ContactType As AdvantageFramework.Database.Entities.ContactType = Nothing

            If _ControlType = Type.PONumber AndAlso
                    (e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableGLPurchaseOrders.Properties.POBalance.ToString OrElse
                     e.Column.FieldName = AdvantageFramework.AccountPayable.Classes.AccountPayableProductionPurchaseOrders.Properties.POBalance.ToString) Then

                If CDec(e.Value) < 0 Then

                    e.DisplayText = e.Value

                End If

            ElseIf (_ControlType = Type.ProductionCustomInvoiceID OrElse _ControlType = Type.MediaCustomInvoiceID) AndAlso
                    e.Column.FieldName = AdvantageFramework.Reporting.Database.Entities.CustomInvoice.Properties.Type.ToString Then

                If _EnumObjects Is Nothing Then

                    _EnumObjects = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.InvoicePrinting.InvoiceTypes))

                End If

                If _EnumObjects IsNot Nothing Then

                    Try

                        EnumObject = _EnumObjects.SingleOrDefault(Function(Entity) Entity.Code = CStr(e.Value))

                    Catch ex As Exception
                        EnumObject = Nothing
                    End Try

                    If EnumObject IsNot Nothing Then

                        e.DisplayText = EnumObject.Description

                    Else

                        e.DisplayText = ""

                    End If

                End If

            ElseIf (_ControlType = Type.EstimateCustomID) AndAlso
                e.Column.FieldName = AdvantageFramework.Reporting.Database.Entities.EstimateReport.Properties.EstimateReportType.ToString Then

                If _EnumObjects Is Nothing Then

                    _EnumObjects = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Estimate.Printing.ReportFormats))

                End If

                If _EnumObjects IsNot Nothing Then

                    Try

                        EnumObject = _EnumObjects.SingleOrDefault(Function(Entity) Entity.Code = "00" & CStr(e.Value))

                    Catch ex As Exception
                        EnumObject = Nothing
                    End Try

                    If EnumObject IsNot Nothing Then

                        e.DisplayText = EnumObject.Description

                    Else

                        e.DisplayText = ""

                    End If

                End If

            ElseIf _ControlType = Type.ClientContact AndAlso
                    e.Column.FieldName = AdvantageFramework.Database.Entities.ClientContact.Properties.ContactTypeID.ToString Then

                e.Column.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near

                If IsNumeric(e.Value) AndAlso e.Value > 0 Then

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            ContactType = AdvantageFramework.Database.Procedures.ContactType.LoadByContactTypeID(DbContext, e.Value)

                            If ContactType IsNot Nothing Then

                                e.DisplayText = ContactType.Description

                            End If

                        End Using

                    Catch ex As Exception
                        e.DisplayText = ""
                    End Try

                Else

                    e.DisplayText = ""

                End If

            ElseIf IsNumeric(e.DisplayText) AndAlso Decimal.TryParse(e.DisplayText, 0) AndAlso CDec(e.DisplayText) < 0 Then

                If Not Me.ExtraComboBoxItem.Equals(ExtraComboBoxItems.Nothing) Then

                    e.DisplayText = ""

                End If

            End If

        End Sub
        Private Sub _GridView_RowClick(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles _GridView.RowClick

            Dim GridHitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = Nothing

            Try

                If e.Button = Windows.Forms.MouseButtons.Left Then

                    If e.Clicks = 2 Then

                        GridHitInfo = DirectCast(sender, DevExpress.XtraGrid.Views.Grid.GridView).CalcHitInfo(e.Location)

                        If GridHitInfo.InRowCell Then

                            If DirectCast(sender, DevExpress.XtraGrid.Views.Grid.GridView).IsRowSelected(GridHitInfo.RowHandle) = False Then

                                DirectCast(sender, DevExpress.XtraGrid.Views.Grid.GridView).ClearSelection()

                                DirectCast(sender, DevExpress.XtraGrid.Views.Grid.GridView).SelectRow(GridHitInfo.RowHandle)

                            End If

                            '_GridLookUpEdit.EditValue = DirectCast(sender, DevExpress.XtraGrid.Views.Grid.GridView).GetRowCellValue(GridHitInfo.RowHandle, Me.ValueMember)
                            '_GridLookUpEdit.Text = DirectCast(sender, DevExpress.XtraGrid.Views.Grid.GridView).GetRowCellValue(GridHitInfo.RowHandle, Me.ValueMember)
                            _GridLookUpEdit.ClosePopup()

                            e.Handled = True

                        End If

                    End If

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub SubItemGridLookUpEditControl_BeforePopup(sender As Object, e As EventArgs) Handles Me.BeforePopup

            Select Case Me.ControlType

                Case SubItemGridLookUpEditControl.Type.AccountPayableImportMediaOrderNumberAutoFill

                    For Each GridColumn In DirectCast(sender, DevExpress.XtraEditors.GridLookUpEdit).Properties.View.Columns

                        If GridColumn.FieldName <> "VendorCode" AndAlso
                                GridColumn.FieldName <> "ClientCode" AndAlso
                                GridColumn.FieldName <> "DivisionCode" AndAlso
                                GridColumn.FieldName <> "ProductCode" AndAlso
                                GridColumn.FieldName <> "OrderNumber" AndAlso
                                GridColumn.FieldName <> "OrderDescription" AndAlso
                                GridColumn.FieldName <> "Description" Then

                            GridColumn.Visible = False

                        End If

                    Next

                    DirectCast(sender, DevExpress.XtraEditors.GridLookUpEdit).Properties.View.ClearSorting()

                    If DirectCast(sender, DevExpress.XtraEditors.GridLookUpEdit).Properties.View.Columns("OrderNumber") IsNot Nothing Then

                        DirectCast(sender, DevExpress.XtraEditors.GridLookUpEdit).Properties.View.Columns("OrderNumber").SortOrder = DevExpress.Data.ColumnSortOrder.Descending

                    End If

            End Select

            DirectCast(sender, DevExpress.XtraEditors.GridLookUpEdit).Properties.View.BestFitColumns()

        End Sub

#End Region

#End Region

    End Class

End Namespace
