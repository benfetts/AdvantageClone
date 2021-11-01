Namespace WinForm.MVC.Presentation.Controls

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
            AdServerAdvertiserID
            AdServerCampaignID
            AdServerSiteID
            AdServerPlacementID
            BuyerEmployeeCode
            NielsenTVBook
            NielsenRadioPeriod
            NielsenRadioDaypart
            NielsenMarket
            MediaDemographic
            CableNetworkStation
            NielsenRadioStation
            NielsenTVStation
            NCCTVSyscode
            MediaRFPAvailLineStatus
            ClientDiscount
            YearMonth
            AlertTemplate
            AlertState
            NielsenCountyState
            Year
            BroadcastMediaType
            MediaTrafficRevision
            MediaTrafficCreativeGroup
            MediaTacticID
            MediaPlanEstimateTemplateMediaType
            QuarterYear
            MediaPlanEstimateTemplate
            MediaPlanDetailPeriodType
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
        Protected _ExtraComboBoxItem As ExtraComboBoxItems = ExtraComboBoxItems.Nothing
        Protected _IncludeInactive As Boolean = False
        Protected _ValueType As System.Type = Nothing
        Protected WithEvents _GridView As AdvantageFramework.WinForm.MVC.Presentation.Controls.GridView = Nothing
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

            _GridView = New AdvantageFramework.WinForm.MVC.Presentation.Controls.GridView(True)
            Me.View = _GridView

            DirectCast(Me.View, AdvantageFramework.WinForm.MVC.Presentation.Controls.GridView).OptionsView.ShowFooter = False
            DirectCast(Me.View, AdvantageFramework.WinForm.MVC.Presentation.Controls.GridView).OptionsView.ShowViewCaption = False

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

                AdvantageFramework.WinForm.MVC.Presentation.Controls.AddComboItemToExistingDataSource(BindingSource, Me.DisplayMember, Me.ValueMember, "[None]", -3, True, True, _AddedItemsToDataSource)

            Else

                AdvantageFramework.WinForm.MVC.Presentation.Controls.AddComboItemToExistingDataSource(BindingSource, Me.DisplayMember, Me.ValueMember, "[" & AdvantageFramework.StringUtilities.GetNameAsWords(ExtraComboItem.ToString) & "]", AdvantageFramework.EnumUtilities.GetValue(ExtraComboItem.GetType, ExtraComboItem.ToString), True, True, _AddedItemsToDataSource)

            End If

        End Sub
        Public Sub AddComboItemToExistingDatasource(ByVal DisplayValue As String, ByVal Value As String, ByVal InsertInFirstPosition As Boolean, Optional ByVal IsExtraComboItem As Boolean = False)

            AdvantageFramework.WinForm.MVC.Presentation.Controls.AddComboItemToExistingDataSource(Me.DataSource, Me.DisplayMember, Me.ValueMember, DisplayValue, Value, InsertInFirstPosition, IsExtraComboItem, _AddedItemsToDataSource)

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

                Case SubItemGridLookUpEditControl.Type.AdServerAdvertiserID

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "ID"

                Case SubItemGridLookUpEditControl.Type.AdServerCampaignID

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "ID"

                Case SubItemGridLookUpEditControl.Type.AdServerSiteID

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "ID"

                Case SubItemGridLookUpEditControl.Type.AdServerPlacementID

                    Me.NullText = ""
                    Me.DisplayMember = "ID"
                    Me.ValueMember = "ID"

                Case SubItemGridLookUpEditControl.Type.BuyerEmployeeCode

                    Me.NullText = ""
                    Me.DisplayMember = "Code"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.NielsenTVBook

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "ID"

                Case SubItemGridLookUpEditControl.Type.NielsenRadioPeriod

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "ID"

                Case SubItemGridLookUpEditControl.Type.NielsenRadioDaypart

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "ID"

                Case SubItemGridLookUpEditControl.Type.NielsenMarket

                    Me.NullText = ""
                    Me.DisplayMember = "Name"
                    Me.ValueMember = "Number"

                Case SubItemGridLookUpEditControl.Type.MediaDemographic

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "ID"

                Case SubItemGridLookUpEditControl.Type.CableNetworkStation

                    Me.NullText = ""
                    Me.DisplayMember = "Code"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.NielsenRadioStation

                    Me.NullText = ""
                    Me.DisplayMember = "Name"
                    Me.ValueMember = "ComboID"

                Case SubItemGridLookUpEditControl.Type.NielsenTVStation

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.NCCTVSyscode

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "ID"

                Case SubItemGridLookUpEditControl.Type.MediaRFPAvailLineStatus

                    Me.NullText = ""
                    Me.DisplayMember = "Display"
                    Me.ValueMember = "Value"

                Case SubItemGridLookUpEditControl.Type.ClientDiscount

                    Me.NullText = ""
                    Me.DisplayMember = "Code"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.YearMonth

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "ID"

                Case SubItemGridLookUpEditControl.Type.AlertTemplate

                    Me.NullText = ""
                    Me.DisplayMember = "Name"
                    Me.ValueMember = "ID"

                Case SubItemGridLookUpEditControl.Type.AlertState

                    Me.NullText = ""
                    Me.DisplayMember = "Name"
                    Me.ValueMember = "ID"

                Case SubItemGridLookUpEditControl.Type.NielsenCountyState

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.Year

                    Me.NullText = ""
                    Me.DisplayMember = "Display"
                    Me.ValueMember = "Value"

                Case SubItemGridLookUpEditControl.Type.BroadcastMediaType

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.MediaTrafficRevision

                    Me.NullText = ""
                    Me.DisplayMember = "SubItemGridLookupDescription"
                    Me.ValueMember = "ID"

                Case SubItemGridLookUpEditControl.Type.MediaTrafficCreativeGroup

                    Me.NullText = ""
                    Me.DisplayMember = "Name"
                    Me.ValueMember = "ID"

                Case SubItemGridLookUpEditControl.Type.MediaTacticID

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "ID"

                Case SubItemGridLookUpEditControl.Type.MediaPlanEstimateTemplateMediaType

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"

                Case SubItemGridLookUpEditControl.Type.QuarterYear

                    Me.NullText = ""
                    Me.DisplayMember = "Display"
                    Me.ValueMember = "Value"

                Case SubItemGridLookUpEditControl.Type.MediaPlanEstimateTemplate

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "ID"

                Case SubItemGridLookUpEditControl.Type.MediaPlanDetailPeriodType

                    Me.NullText = ""
                    Me.DisplayMember = "Description"
                    Me.ValueMember = "Code"

            End Select

            CreateDefaultColumns()

        End Sub
        Protected Sub CreateDefaultColumns()

            If Me.View.Columns.Count = 0 Then

                Select Case _ControlType

                    Case SubItemGridLookUpEditControl.Type.Default



                    Case SubItemGridLookUpEditControl.Type.Client

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Name"))

                    Case SubItemGridLookUpEditControl.Type.Division

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Name"))

                    Case SubItemGridLookUpEditControl.Type.Product

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Name"))

                    Case SubItemGridLookUpEditControl.Type.ProductCategory

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.Function

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Type", False))

                    Case SubItemGridLookUpEditControl.Type.JobComponent

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ID", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("JobNumber", False, "Job Number"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Number"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.Job

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Number"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ClientCode", False, "Client Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("DivisionCode", False, "Division Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ProductCode", False, "Product Code"))

                    Case SubItemGridLookUpEditControl.Type.PONumber

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Number"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Date"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("DueDate"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Status"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("POTotal"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("POBalance"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("WorkComplete"))

                    Case SubItemGridLookUpEditControl.Type.POLineNumber

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("LineNumber", , "Line #"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("LineDescription", , "Description"))

                    Case SubItemGridLookUpEditControl.Type.SalesTax

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("TaxCode"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.PTORule

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Name"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ID", False))

                    Case SubItemGridLookUpEditControl.Type.Office

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Name"))

                    Case SubItemGridLookUpEditControl.Type.GeneralLedgerAccount

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.AdSize

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.ManagementLevel

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ID", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.EstimateFunction

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.Status

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.WebSiteType

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.EmployeeTitle

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ID", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.Task

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.Phase

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ID", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.Employee, SubItemGridLookUpEditControl.Type.EmployeeWithDepartmentAndOffice

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Name"))

                        If _ControlType = SubItemGridLookUpEditControl.Type.EmployeeWithDepartmentAndOffice Then

                            Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("OfficeCode"))
                            Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("OfficeName"))
                            Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("DepartmentCode"))
                            Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("DepartmentName"))

                        End If

                    Case SubItemGridLookUpEditControl.Type.EmployeeFunction

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("FunctionCode", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.MagazineOrderNumber

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("VendorCode", , "Vendor"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ClientCode", , "Client"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("DivisionCode", , "Division"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ProductCode", , "Product"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("OrderNumber", , "Order #"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("LineNumber", , "Line"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("InsertDate", , "Date"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("OrderDescription", , "Description"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("LinkID", , "Link ID"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ClientPO", , "Client PO"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("MarketCode", , "Market"))

                    Case SubItemGridLookUpEditControl.Type.MagazineOrderLineNumber

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("LineNumber", , "Line #"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("InsertDate", , "Date"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Headline"))

                    Case SubItemGridLookUpEditControl.Type.Partner

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Partner"))

                    Case SubItemGridLookUpEditControl.Type.EmployeeCategory

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ID", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.MediaType

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description", , "Media Type"))

                    Case SubItemGridLookUpEditControl.Type.ExceedOption

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.ExpenseFunction

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.AdNumber

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Number"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ExpirationDate"))

                    Case SubItemGridLookUpEditControl.Type.SalesClassMediaType

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.ClientContact

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ID", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description", True, "Name"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ContactTypeID", True, "Contact Type"))

                    Case SubItemGridLookUpEditControl.Type.ProductARAddressLookup

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Address1"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Address2"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("City"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("State"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Zip"))

                    Case SubItemGridLookUpEditControl.Type.ClientARAddressLookup

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Address1"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Address2"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("City"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("State"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Zip"))

                    Case SubItemGridLookUpEditControl.Type.DepartmentTeam

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.Role

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.EmployeeHRStatus

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.EmployeeVendor

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Name"))

                    Case SubItemGridLookUpEditControl.Type.POApprovalRule

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.ReportMissingTime

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.AlertGroup

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.SalesClass

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.YesNoSkip

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.FeeTime

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.MarkupTaxFlags

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.FunctionType

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.FunctionHeading

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.Vendor

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Name"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Category"))

                    Case SubItemGridLookUpEditControl.Type.BeforeAfter

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.ResourceTaskCondition

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.VendorTerm

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.ImportVendorCategory

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.RateBy

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.RateType

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.VendorFunction

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("CPMFlag", False, "CPM"))

                    Case SubItemGridLookUpEditControl.Type.ImportTemplateProperty

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description", , "Property"))

                    Case SubItemGridLookUpEditControl.Type.ExpenseItemPayment

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.IndirectCategoryType

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ID", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.ServiceFeeType

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.Bank

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.Market

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.Daypart, SubItemGridLookUpEditControl.Type.DaypartCode

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ID", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.JobVersionDatabaseType

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ID", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.JobComponentID

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ID", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("JobNumber", False, "Job Number"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Number"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.JobDescription

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Number", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.JobComponentDescription

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ID", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("JobNumber", False, "Job Number"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Number", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.MediaApprovalStatusPendingOnly

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.NewspaperOrderNumber

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("VendorCode", , "Vendor"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ClientCode", , "Client"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("DivisionCode", , "Division"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ProductCode", , "Product"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("OrderNumber", , "Order #"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("LineNumber", , "Line"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("InsertDate", , "Date"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("OrderDescription", , "Description"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("LinkID", , "Link ID"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ClientPO", , "Client PO"))

                    Case SubItemGridLookUpEditControl.Type.NewspaperOrderLineNumber

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("LineNumber", , "Line #"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("InsertDate", , "Date"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Headline"))

                    Case (SubItemGridLookUpEditControl.Type.ExpenseReportApprovedFlag)

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description", True, "Status"))

                    Case SubItemGridLookUpEditControl.Type.ExpenseEmployee

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Name"))

                    Case SubItemGridLookUpEditControl.Type.InternetOrderNumber

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("VendorCode", , "Vendor"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ClientCode", , "Client"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("DivisionCode", , "Division"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ProductCode", , "Product"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("OrderNumber", , "Order #"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("LineNumber", , "Line"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("InsertDate", , "Date"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("OrderDescription", , "Description"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("LinkID", , "Link ID"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ClientPO", , "Client PO"))

                    Case SubItemGridLookUpEditControl.Type.InternetOrderLineNumber

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("LineNumber", , "Line #"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("InsertDate", , "Date"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Headline"))

                    Case SubItemGridLookUpEditControl.Type.OutOfHomeOrderNumber

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("VendorCode", , "Vendor"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ClientCode", , "Client"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("DivisionCode", , "Division"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ProductCode", , "Product"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("OrderNumber", , "Order #"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("LineNumber", , "Line"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("InsertDate", , "Date"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("OrderDescription", , "Description"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("LinkID", , "Link ID"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ClientPO", , "Client PO"))

                    Case SubItemGridLookUpEditControl.Type.OutOfHomeOrderLineNumber

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("LineNumber", , "Line #"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("InsertDate", , "Date"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Headline"))

                    Case SubItemGridLookUpEditControl.Type.RadioOrderNumber

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("VendorCode", , "Vendor"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ClientCode", , "Client"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("DivisionCode", , "Division"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ProductCode", , "Product"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("OrderNumber", , "Order #"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("LineNumber", , "Line"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Month", , "Month"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Year", , "Year"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("StartDate", , "Start Date"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("EndDate", , "End Date"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description", , "Description"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("LinkID", , "Link ID"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ClientPO", , "Client PO"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("MarketCode", , "Market"))

                    Case SubItemGridLookUpEditControl.Type.RadioOrderLineNumber

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("LineNumber", , "Line #"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Month", , "Month"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Year", , "Year"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Date", , "Date"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Programming", , "Programming"))

                    Case SubItemGridLookUpEditControl.Type.RadioOrderLegacyMonth

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Column", , "Month"))

                    Case SubItemGridLookUpEditControl.Type.RadioOrderLegacyYear

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Column", , "Year"))

                    Case SubItemGridLookUpEditControl.Type.TVOrderNumber

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("VendorCode", , "Vendor"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ClientCode", , "Client"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("DivisionCode", , "Division"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ProductCode", , "Product"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("OrderNumber", , "Order #"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("LineNumber", , "Line"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Month", , "Month"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Year", , "Year"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("StartDate", , "Start Date"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("EndDate", , "End Date"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description", , "Description"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("LinkID", , "Link ID"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ClientPO", , "Client PO"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("MarketCode", , "Market"))

                    Case SubItemGridLookUpEditControl.Type.TVOrderLineNumber

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("LineNumber", , "Line #"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Month", , "Month"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Year", , "Year"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Date", , "Date"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Programming", , "Programming"))

                    Case SubItemGridLookUpEditControl.Type.TVOrderLegacyMonth

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Column", , "Month"))

                    Case SubItemGridLookUpEditControl.Type.TVOrderLegacyYear

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Column", , "Year"))

                    Case SubItemGridLookUpEditControl.Type.Affiliation

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ID", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.DaypartType

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ID", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.Competition

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ID", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.ServiceFeeTypeID

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ID", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.Cycle

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Name"))

                    Case SubItemGridLookUpEditControl.Type.Blackplate

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("CodeAndDescription", False))

                    Case SubItemGridLookUpEditControl.Type.CycleType

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.AccountReceivable

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("InvoiceNumber"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("SequenceNumber"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Type"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ClientCode"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ClientName", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("InvoiceDate", False))

                    Case SubItemGridLookUpEditControl.Type.OfficeName

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Name"))

                    Case SubItemGridLookUpEditControl.Type.DepartmentTeamName

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.GeneralLedgerAccountDescription

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.EnumDataTable

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.EnumObject

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.PostPeriod

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.PostPeriodStatus

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.AccountPayableImportMediaType

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description", , "Media Type"))

                    Case SubItemGridLookUpEditControl.Type.MediaPlan

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ID", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Client"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("StartDate"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("EndDate"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("IsApproved"))

                    Case SubItemGridLookUpEditControl.Type.MediaPlanDetail

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ID", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("MediaPlanID", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("SalesClass"))

                    Case SubItemGridLookUpEditControl.Type.DateFormat

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description", True, "Format"))

                    Case SubItemGridLookUpEditControl.Type.CostType

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.Location

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ID"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Name"))

                    Case SubItemGridLookUpEditControl.Type.Campaign

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ID", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Name"))

                    Case SubItemGridLookUpEditControl.Type.CampaignID

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ID"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Name"))

                    Case SubItemGridLookUpEditControl.Type.AccountReceivableRecordType

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.TaskStatus

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.GeneralLedgerAccountTypes

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.GeneralLedgerBalanceTypes

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.CurrencyCode

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.ProductionBillHoldStatus

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.JobProcess

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ID", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.ProductionReconcileStatus

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.ServiceFeeFrequency

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.InvoiceCategory

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.CustomProductionInvoice

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.CustomMagazineInvoice

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.CustomNewspaperInvoice

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.CustomInternetInvoice

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.CustomOutdoorInvoice

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.CustomRadioInvoice

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.CustomTVInvoice

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.InternetType

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.JobProcessControl

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ID"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.VendorServiceTaxType

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.AvalaraTaxID

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ID", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.OverheadAccountCode

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.ProductionCustomInvoiceID

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ID", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Type"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.MediaCustomInvoiceID

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ID", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Type"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.BillingCoopCode

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.EstimateCustomID

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ID", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("EstimateReportType"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.ContactType

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ID", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.AccountReceivableSequenceNumber

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("SequenceNumber"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Type"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ClientCode"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ClientName", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("InvoiceDate", False))

                    Case SubItemGridLookUpEditControl.Type.VCCStatus

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.CashReceiptPaymentType

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ID", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.OutOfHomeType

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.DocumentType

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ID", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Name"))

                    Case SubItemGridLookUpEditControl.Type.IOOrderNumber

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("MediaType", , "Type"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("VendorCode", , "Vendor"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ClientCode", , "Client"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("DivisionCode", , "Division"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ProductCode", , "Product"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("OrderNumber", , "Order #"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("LineNumber", , "Line"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description", , "Description"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("LinkID", , "Link ID"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ClientPO", , "Client PO"))

                    Case SubItemGridLookUpEditControl.Type.IOOrderLineNumber

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("LineNumber", , "Line #"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description", , "Description"))

                    Case SubItemGridLookUpEditControl.Type.OrderProcess

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ID", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.StateCode

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("StateCode"))

                    Case SubItemGridLookUpEditControl.Type.StateName

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("StateCode"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("StateName"))

                    Case SubItemGridLookUpEditControl.Type.IndirectCategory

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.JobTemplateMapping

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.GeneralLedgerSource

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.AdServerAdvertiserID

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ID", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.AdServerCampaignID

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ID", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.AdServerSiteID

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ID", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.AdServerPlacementID

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ID"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.BuyerEmployeeCode

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Name"))

                    Case SubItemGridLookUpEditControl.Type.NielsenTVBook

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ID"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.NielsenRadioPeriod

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ID", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.NielsenRadioDaypart

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ID", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("AQH"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Cume"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ExclusiveCume"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Qualitative"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("DiaryAtWorkInCar", Caption:="Diary At Work / In Car"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("PPMinHomeOutofHome", Caption:="PPM In Home / Out of Home"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("IsStandard", False))

                    Case SubItemGridLookUpEditControl.Type.NielsenMarket

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Number"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Name"))

                    Case SubItemGridLookUpEditControl.Type.MediaDemographic

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ID", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Group"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Category"))

                    Case SubItemGridLookUpEditControl.Type.CableNetworkStation

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ID", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.NielsenRadioStation

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ComboID", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Name"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Frequency"))

                    Case SubItemGridLookUpEditControl.Type.NielsenTVStation

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.NCCTVSyscode

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ID", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Syscode"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Provider"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("SystemName"))

                    Case SubItemGridLookUpEditControl.Type.MediaRFPAvailLineStatus

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Value", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Display", Caption:="Description"))

                    Case SubItemGridLookUpEditControl.Type.ClientDiscount

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Name"))

                    Case SubItemGridLookUpEditControl.Type.YearMonth

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ID", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Year", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Month", False))

                    Case SubItemGridLookUpEditControl.Type.AlertTemplate

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ID", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Name"))

                    Case SubItemGridLookUpEditControl.Type.AlertState

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ID", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Name"))

                    Case SubItemGridLookUpEditControl.Type.NielsenCountyState

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.Year

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Value", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Display", Caption:="Year"))

                    Case SubItemGridLookUpEditControl.Type.BroadcastMediaType

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.MediaTrafficRevision

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ID", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("MediaTrafficID", Caption:="ID"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("RevisionNumber", Caption:="Rev"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("StartDate"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("EndDate"))

                    Case SubItemGridLookUpEditControl.Type.MediaTrafficCreativeGroup

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ID", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Name"))

                    Case SubItemGridLookUpEditControl.Type.MediaTacticID

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ID", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.MediaPlanEstimateTemplateMediaType

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                    Case SubItemGridLookUpEditControl.Type.QuarterYear

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Value", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Display"))

                    Case SubItemGridLookUpEditControl.Type.MediaPlanEstimateTemplate

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("ID", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("MediaTypeDescription", Caption:="Media Type"))

                    Case SubItemGridLookUpEditControl.Type.MediaPlanDetailPeriodType

                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code", False))
                        Me.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))

                End Select

            End If

        End Sub
        Public Sub RemoveAddedItemsFromDataSource()

            RemoveAddedItemsFromDataSource(Me.DataSource)

        End Sub
        Private Sub RemoveAddedItemsFromDataSource(ByVal BindingSource As System.Windows.Forms.BindingSource)

            AdvantageFramework.WinForm.MVC.Presentation.Controls.SuspendBindingOnABindingSource(BindingSource)

            Try

                For Each AddedItem In _AddedItemsToDataSource

                    BindingSource.Remove(AddedItem)

                Next

            Catch ex As Exception

            End Try

            AdvantageFramework.WinForm.MVC.Presentation.Controls.ResumeBindingOnABindingSource(BindingSource)

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

                            'Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            '	e.DisplayText = AdvantageFramework.Database.Procedures.PTORule.LoadByID(DbContext, e.Value).Name

                            'End Using

                        Case Type.EmployeeTitle

                            'Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            '	e.DisplayText = AdvantageFramework.Database.Procedures.EmployeeTitle.LoadByEmployeeTitleID(DbContext, e.Value).Description

                            'End Using

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

                            If e.Value = 0 Then

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

                            'Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            '	e.DisplayText = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobComponentID(DbContext, e.Value).Number

                            'End Using

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

            ElseIf _ControlType = Type.AdSize Then

                Dim FoundObject As Object = Nothing

                FoundObject = AdvantageFramework.WinForm.MVC.Presentation.Controls.FindObjectInDataSource(Me.DataSource, Me.DisplayMember, e.Value)

                If FoundObject IsNot Nothing Then

                    e.Value = FoundObject.Code

                End If

            Else

                If e.Value IsNot Nothing Then

                    _IsNewValue = False

                End If

            End If

        End Sub
        Private Sub SubItemGridLookUpEditControl_ProcessNewValue(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs) Handles Me.ProcessNewValue

            Dim FoundObject As Object = Nothing

            If _ControlType = Type.Task AndAlso (TypeOf e.DisplayValue Is String AndAlso e.DisplayValue <> "") Then

                FoundObject = AdvantageFramework.WinForm.MVC.Presentation.Controls.FindObjectInDataSource(Me.DataSource, Me.ValueMember, e.DisplayValue)

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

            ElseIf _ControlType = Type.NielsenMarket AndAlso (TypeOf e.DisplayValue Is String AndAlso e.DisplayValue <> "") Then

                FoundObject = AdvantageFramework.WinForm.MVC.Presentation.Controls.FindObjectInDataSource(Me.DataSource, Me.ValueMember, e.DisplayValue)

                If FoundObject IsNot Nothing Then

                    e.DisplayValue = FoundObject.Name

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

            'objects
            Dim GridColumnVisible As Boolean = True

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

                    Case SubItemGridLookUpEditControl.Type.MediaDemographic

                        Try

                            If DirectCast(sender, DevExpress.XtraEditors.GridLookUpEdit).Parent.Parent.Name = "DataGridViewDemos_SecondaryDemos" Then

                                If DirectCast(DirectCast(sender, DevExpress.XtraEditors.GridLookUpEdit).Parent.Parent, AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView).Tag = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Nielsen Then

                                    GridColumnVisible = False

                                End If

                                For Each GridColumn In DirectCast(sender, DevExpress.XtraEditors.GridLookUpEdit).Properties.View.Columns

                                    If GridColumn.FieldName = "Group" OrElse GridColumn.FieldName = "Category" Then

                                        GridColumn.Visible = GridColumnVisible

                                    End If

                                Next

                            End If

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

                    'Try

                    '    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    '        ContactType = AdvantageFramework.Database.Procedures.ContactType.LoadByContactTypeID(DbContext, e.Value)

                    '        If ContactType IsNot Nothing Then

                    '            e.DisplayText = ContactType.Description

                    '        End If

                    '    End Using

                    'Catch ex As Exception
                    '    e.DisplayText = ""
                    'End Try

                Else

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

#End Region

#End Region

    End Class

End Namespace
