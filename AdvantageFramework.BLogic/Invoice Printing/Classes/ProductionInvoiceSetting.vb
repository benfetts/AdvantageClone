Namespace InvoicePrinting.Classes

    <Serializable()>
    Public Class ProductionInvoiceSetting

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ProductionInvoicePrintingOptionsID
            CustomFormatName
            UseLocationPrintOptions
            LocationCode
            UseInvoiceCategoryDescription
            InvoiceTitle
            AddressBlockType
            PrintDivisionName
            PrintProductDescription
            PrintContactAfterAddress
            ContactType
            ShowCodes
            IncludeClientReference
            IncludeClientPO
            IncludeAccountExecutive
            IncludeSalesClass
            IncludeInvoiceDueDate
            HideComponentNumberAndDescription
            IncludeBillingComment
            IncludeBillingApprovalClientComment
            IncludeJobComment
            IncludeJobComponentComment
            IncludeEstimateComment
            IncludeEstimateComponentComment
            IncludeEstimateQuoteComment
            IncludeEstimateRevisionComment
            ApplyExchangeRate
            ExchangeRateAmount
            ReportFormatType
            ShowEmployeeHours
            ShowQuantity
            GroupingOptionType
            GroupingOptionInsideDescription
            GroupingOptionOutsideDescription
            SortFunctionByType
            PrintFunctionType
            ShowFunctionDetail
            ShowZeroFunctionAmounts
            IndicateTaxableFunctions
            HideFunctionTotals
            TotalsShowCommissionSeparately
            TotalsShowTaxSeparately
            TotalsShowBillingHistory
            InvoiceFooterCommentType
            InvoiceFooterComment
            IncludeBackupReport
            BackupReportColumnOption
            BackupReportCommentOptionEmployeeTimeFunction
            BackupReportCommentOptionAccountsPayableFunction
            BackupReportCommentOptionIncomeOnlyFunction
            BackupReportCommentOptionBillingApprovalClientFunction
            CustomInvoiceID
            ClientPOLocation
            HideJobInfo
            PrintClientName
            ShowCampaign
            ShowCampaignComment
            TaxTotalLocation
            ClientRefLocation
            SalesClassLocation
            CampaignLocation
            HeaderGroupBy
            IncludeEstimateFunctionComment
            ShowAPDescription
            ShowAPDate
            ShowAPRate
            ShowEmployeeTimeDescription
            ShowEmployeeTimeDate
            ShowEmployeeTimeRate
            ShowIncomeOnlyDescription
            ShowIncomeOnlyDate
			ShowIncomeOnlyRate
			ShowEmployeeTimeComment
			ShowAPComment
            ShowIncomeOnlyComment
            SummaryLevel
            BreakupByJobComponent
            HideExchangeRateMessage
        End Enum

#End Region

#Region " Variables "

        Private _ProductionInvoicePrintingOptionsID As Integer = 0
        Private _CustomFormatName As String = ""
        Private _UseLocationPrintOptions As Boolean = False
        Private _LocationCode As String = Nothing
        Private _UseInvoiceCategoryDescription As Boolean = False
        Private _InvoiceTitle As String = Nothing
        Private _AddressBlockType As Short = 3
        Private _PrintDivisionName As Boolean = True
        Private _PrintProductDescription As Boolean = True
        Private _PrintContactAfterAddress As Boolean = False
        Private _ContactType As Integer = 0
        Private _IncludeClientReference As Boolean = False
        Private _IncludeClientPO As Boolean = False
        Private _IncludeAccountExecutive As Boolean = False
        Private _IncludeSalesClass As Boolean = False
        Private _IncludeInvoiceDueDate As Boolean = False
        Private _HideComponentNumberAndDescription As Boolean = False
        Private _IncludeBillingComment As Boolean = False
        Private _IncludeBillingApprovalClientComment As Boolean = False
        Private _IncludeJobComment As Boolean = False
        Private _IncludeJobComponentComment As Boolean = False
        Private _IncludeEstimateComment As Boolean = False
        Private _IncludeEstimateComponentComment As Boolean = False
        Private _IncludeEstimateQuoteComment As Boolean = False
        Private _IncludeEstimateRevisionComment As Boolean = False
        Private _ApplyExchangeRate As Boolean = False
        Private _ExchangeRateAmount As System.Nullable(Of Decimal) = 1.0
        Private _ReportFormatType As Short = 1
        Private _ShowEmployeeHours As Boolean = False
        Private _ShowQuantity As Boolean = False
        Private _GroupingOptionType As Short = 1
        Private _GroupingOptionInsideDescription As String = "Services"
        Private _GroupingOptionOutsideDescription As String = "Outside Expenses"
        Private _SortFunctionByType As Short = 1
        Private _PrintFunctionType As Short = 1
        Private _ShowFunctionDetail As Boolean = False
        Private _ShowZeroFunctionAmounts As Boolean = False
        Private _IndicateTaxableFunctions As Boolean = False
        Private _HideFunctionTotals As Boolean = False
        Private _TotalsShowCommissionSeparately As Boolean = False
        Private _TotalsShowTaxSeparately As Boolean = False
        Private _TotalsShowBillingHistory As Boolean = False
        Private _InvoiceFooterCommentType As Short = 1
        Private _InvoiceFooterComment As String = Nothing
        Private _IncludeBackupReport As Boolean = False
        Private _BackupReportColumnOption As Short = 1
        Private _BackupReportCommentOptionEmployeeTimeFunction As Boolean = False
        Private _BackupReportCommentOptionAccountsPayableFunction As Boolean = False
        Private _BackupReportCommentOptionIncomeOnlyFunction As Boolean = False
        Private _BackupReportCommentOptionBillingApprovalClientFunction As Boolean = False
        Private _CustomInvoiceID As Nullable(Of Integer) = Nothing
        Private _ClientPOLocation As Integer = 2
        Private _HideJobInfo As Boolean = False
        Private _PrintClientName As Boolean = False
        Private _ShowCampaign As Boolean = False
        Private _ShowCampaignComment As Boolean = False
        Private _ShowCodes As Boolean = False
        Private _TaxTotalLocation As Integer = 2
        Private _ClientRefLocation As Integer = 2
        Private _SalesClassLocation As Integer = 2
        Private _CampaignLocation As Integer = 2
        Private _HeaderGroupBy As Integer = 0
        Private _IncludeEstimateFunctionComment As Boolean = False
        Private _ShowAPDescription As Boolean = False
        Private _ShowAPDate As Boolean = False
        Private _ShowAPRate As Boolean = False
        Private _ShowEmployeeTimeDescription As Boolean = False
        Private _ShowEmployeeTimeDate As Boolean = False
        Private _ShowEmployeeTimeRate As Boolean = False
        Private _ShowIncomeOnlyDescription As Boolean = False
        Private _ShowIncomeOnlyDate As Boolean = False
        Private _ShowIncomeOnlyRate As Boolean = False
        Private _ShowEmployeeTimeFunctionComment As Boolean = Nothing
        Private _ShowAccountsPayableFunctionComment As Boolean = Nothing
        Private _ShowIncomeOnlyFunctionComment As Boolean = Nothing
        Private _SummaryLevel As Integer = Nothing
        Private _BreakupByJobComponent As Boolean = True
        Private _HideExchangeRateMessage As Boolean = False

        Private _ProductionInvoiceDefault As AdvantageFramework.Database.Entities.ProductionInvoiceDefault = Nothing
        Private _InvoicePrintingSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.Browsable(False)> _
        Public Property ProductionInvoicePrintingOptionsID() As Long
            Get
                ProductionInvoicePrintingOptionsID = _ProductionInvoicePrintingOptionsID
            End Get
            Set(ByVal value As Long)
                _ProductionInvoicePrintingOptionsID = value
            End Set
        End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DataAnnotations.MaxLength(50),
		System.ComponentModel.Browsable(False)>
		Public Property CustomFormatName() As String
			Get
				CustomFormatName = _CustomFormatName
			End Get
			Set(ByVal value As String)
				_CustomFormatName = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.Category("")>
		Public Property UseLocationPrintOptions() As Boolean
			Get
				UseLocationPrintOptions = _UseLocationPrintOptions
			End Get
			Set(ByVal value As Boolean)
				_UseLocationPrintOptions = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.LocationID),
		System.ComponentModel.DataAnnotations.MaxLength(50),
		System.ComponentModel.DisplayName("Location"),
		System.ComponentModel.Category("")>
		Public Property LocationCode() As String
			Get
				LocationCode = _LocationCode
			End Get
			Set(ByVal value As String)
				_LocationCode = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.Category("Title")>
		Public Property UseInvoiceCategoryDescription() As Boolean
			Get
				UseInvoiceCategoryDescription = _UseInvoiceCategoryDescription
			End Get
			Set(ByVal value As Boolean)
				_UseInvoiceCategoryDescription = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DataAnnotations.MaxLength(20),
		System.ComponentModel.Category("Title")>
		Public Property InvoiceTitle() As String
			Get
				InvoiceTitle = _InvoiceTitle
			End Get
			Set(ByVal value As String)
				_InvoiceTitle = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DisplayName("Address Block Type")>
		Public Property AddressBlockType() As Short
			Get
				AddressBlockType = _AddressBlockType
			End Get
			Set(ByVal value As Short)
				_AddressBlockType = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DisplayName("Print Division Name")>
		Public Property PrintDivisionName() As Boolean
			Get
				PrintDivisionName = _PrintDivisionName
			End Get
			Set(ByVal value As Boolean)
				_PrintDivisionName = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DisplayName("Print Product Description")>
		Public Property PrintProductDescription() As Boolean
			Get
				PrintProductDescription = _PrintProductDescription
			End Get
			Set(ByVal value As Boolean)
				_PrintProductDescription = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DisplayName("Print Contact After Address")>
		Public Property PrintContactAfterAddress() As Boolean
			Get
				PrintContactAfterAddress = _PrintContactAfterAddress
			End Get
			Set(ByVal value As Boolean)
				_PrintContactAfterAddress = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DisplayName("Contact Type")>
		Public Property ContactType() As Integer
			Get
				ContactType = _ContactType
			End Get
			Set(value As Integer)
				_ContactType = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DisplayName("Client Reference")>
		Public Property IncludeClientReference() As Boolean
			Get
				IncludeClientReference = _IncludeClientReference
			End Get
			Set(ByVal value As Boolean)
				_IncludeClientReference = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DisplayName("Client PO")>
		Public Property IncludeClientPO() As Boolean
			Get
				IncludeClientPO = _IncludeClientPO
			End Get
			Set(ByVal value As Boolean)
				_IncludeClientPO = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DisplayName("Account Executive")>
		Public Property IncludeAccountExecutive() As Boolean
			Get
				IncludeAccountExecutive = _IncludeAccountExecutive
			End Get
			Set(ByVal value As Boolean)
				_IncludeAccountExecutive = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DisplayName("Sales Class")>
		Public Property IncludeSalesClass() As Boolean
			Get
				IncludeSalesClass = _IncludeSalesClass
			End Get
			Set(ByVal value As Boolean)
				_IncludeSalesClass = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DisplayName("Invoice Due Date")>
		Public Property IncludeInvoiceDueDate() As Boolean
			Get
				IncludeInvoiceDueDate = _IncludeInvoiceDueDate
			End Get
			Set(ByVal value As Boolean)
				_IncludeInvoiceDueDate = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.Category("Header")>
		Public Property HideComponentNumberAndDescription() As Boolean
			Get
				HideComponentNumberAndDescription = _HideComponentNumberAndDescription
			End Get
			Set(ByVal value As Boolean)
				_HideComponentNumberAndDescription = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DisplayName("Billing Comment")>
		Public Property IncludeBillingComment() As Boolean
			Get
				IncludeBillingComment = _IncludeBillingComment
			End Get
			Set(ByVal value As Boolean)
				_IncludeBillingComment = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DisplayName("Billing Approval Client Comment")>
		Public Property IncludeBillingApprovalClientComment() As Boolean
			Get
				IncludeBillingApprovalClientComment = _IncludeBillingApprovalClientComment
			End Get
			Set(ByVal value As Boolean)
				_IncludeBillingApprovalClientComment = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DisplayName("Job Comment")>
		Public Property IncludeJobComment() As Boolean
			Get
				IncludeJobComment = _IncludeJobComment
			End Get
			Set(ByVal value As Boolean)
				_IncludeJobComment = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DisplayName("Job Component Comment")>
		Public Property IncludeJobComponentComment() As Boolean
			Get
				IncludeJobComponentComment = _IncludeJobComponentComment
			End Get
			Set(ByVal value As Boolean)
				_IncludeJobComponentComment = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DisplayName("Estimate Comment")>
		Public Property IncludeEstimateComment() As Boolean
			Get
				IncludeEstimateComment = _IncludeEstimateComment
			End Get
			Set(ByVal value As Boolean)
				_IncludeEstimateComment = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DisplayName("Estimate Component Comment")>
		Public Property IncludeEstimateComponentComment() As Boolean
			Get
				IncludeEstimateComponentComment = _IncludeEstimateComponentComment
			End Get
			Set(ByVal value As Boolean)
				_IncludeEstimateComponentComment = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DisplayName("Estimate Quote Comment")>
		Public Property IncludeEstimateQuoteComment() As Boolean
			Get
				IncludeEstimateQuoteComment = _IncludeEstimateQuoteComment
			End Get
			Set(ByVal value As Boolean)
				_IncludeEstimateQuoteComment = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DisplayName("Estimate Revision Comment")>
		Public Property IncludeEstimateRevisionComment() As Boolean
			Get
				IncludeEstimateRevisionComment = _IncludeEstimateRevisionComment
			End Get
			Set(ByVal value As Boolean)
				_IncludeEstimateRevisionComment = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.Category("Header")>
		Public Property ApplyExchangeRate() As Boolean
			Get
				ApplyExchangeRate = _ApplyExchangeRate
			End Get
			Set(ByVal value As Boolean)
				_ApplyExchangeRate = value
			End Set
		End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
        System.ComponentModel.Category("Header")>
        Public Property ExchangeRateAmount() As System.Nullable(Of Decimal)
            Get
                ExchangeRateAmount = _ExchangeRateAmount
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _ExchangeRateAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
        System.ComponentModel.Category("Header")>
        Public Property HideExchangeRateMessage() As Boolean
            Get
                HideExchangeRateMessage = _HideExchangeRateMessage
            End Get
            Set(ByVal value As Boolean)
                _HideExchangeRateMessage = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DisplayName("Format Type")>
		Public Property ReportFormatType As Short
			Get
				ReportFormatType = _ReportFormatType
			End Get
			Set(ByVal value As Short)
				_ReportFormatType = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DisplayName("Show Employee Hours")>
		Public Property ShowEmployeeHours() As Boolean
			Get
				ShowEmployeeHours = _ShowEmployeeHours
			End Get
			Set(ByVal value As Boolean)
				_ShowEmployeeHours = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DisplayName("Show Quantity")>
		Public Property ShowQuantity() As Boolean
			Get
				ShowQuantity = _ShowQuantity
			End Get
			Set(ByVal value As Boolean)
				_ShowQuantity = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DisplayName("Option")>
		Public Property GroupingOptionType As Short
			Get
				GroupingOptionType = _GroupingOptionType
			End Get
			Set(ByVal value As Short)
				_GroupingOptionType = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DisplayName("Inside Description")>
		Public Property GroupingOptionInsideDescription As String
			Get
				GroupingOptionInsideDescription = _GroupingOptionInsideDescription
			End Get
			Set(ByVal value As String)
				_GroupingOptionInsideDescription = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DisplayName("Outside Description")>
		Public Property GroupingOptionOutsideDescription() As String
			Get
				GroupingOptionOutsideDescription = _GroupingOptionOutsideDescription
			End Get
			Set(ByVal value As String)
				_GroupingOptionOutsideDescription = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DisplayName("Sort By")>
		Public Property SortFunctionByType() As Short
			Get
				SortFunctionByType = _SortFunctionByType
			End Get
			Set(ByVal value As Short)
				_SortFunctionByType = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DisplayName("Print Option")>
		Public Property PrintFunctionType() As Short
			Get
				PrintFunctionType = _PrintFunctionType
			End Get
			Set(ByVal value As Short)
				_PrintFunctionType = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DisplayName("Show Function Detail")>
		Public Property ShowFunctionDetail() As Boolean
			Get
				ShowFunctionDetail = _ShowFunctionDetail
			End Get
			Set(ByVal value As Boolean)
				_ShowFunctionDetail = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DisplayName("Show Zero Function Amounts")>
		Public Property ShowZeroFunctionAmounts() As Boolean
			Get
				ShowZeroFunctionAmounts = _ShowZeroFunctionAmounts
			End Get
			Set(ByVal value As Boolean)
				_ShowZeroFunctionAmounts = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DisplayName("Indicate Taxable Functions")>
		Public Property IndicateTaxableFunctions() As Boolean
			Get
				IndicateTaxableFunctions = _IndicateTaxableFunctions
			End Get
			Set(ByVal value As Boolean)
				_IndicateTaxableFunctions = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DisplayName("Hide Function Totals")>
		Public Property HideFunctionTotals() As Boolean
			Get
				HideFunctionTotals = _HideFunctionTotals
			End Get
			Set(ByVal value As Boolean)
				_HideFunctionTotals = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DisplayName("Show Tax Separately")>
		Public Property TotalsShowTaxSeparately() As Boolean
			Get
				TotalsShowTaxSeparately = _TotalsShowTaxSeparately
			End Get
			Set(ByVal value As Boolean)
				_TotalsShowTaxSeparately = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DisplayName("Show Commission Separately")>
		Public Property TotalsShowCommissionSeparately() As Boolean
			Get
				TotalsShowCommissionSeparately = _TotalsShowCommissionSeparately
			End Get
			Set(ByVal value As Boolean)
				_TotalsShowCommissionSeparately = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DisplayName("Show Billing History")>
		Public Property TotalsShowBillingHistory() As Boolean
			Get
				TotalsShowBillingHistory = _TotalsShowBillingHistory
			End Get
			Set(ByVal value As Boolean)
				_TotalsShowBillingHistory = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DisplayName("Type")>
		Public Property InvoiceFooterCommentType() As Short
			Get
				InvoiceFooterCommentType = _InvoiceFooterCommentType
			End Get
			Set(ByVal value As Short)
				_InvoiceFooterCommentType = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DataAnnotations.MaxLength(50),
		System.ComponentModel.DisplayName("Comment")>
		Public Property InvoiceFooterComment() As String
            Get
                InvoiceFooterComment = _InvoiceFooterComment
            End Get
            Set(ByVal value As String)
                _InvoiceFooterComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.Category("Totals, Footer & Backup")> _
        Public Property IncludeBackupReport() As Boolean
            Get
                IncludeBackupReport = _IncludeBackupReport
            End Get
            Set(ByVal value As Boolean)
                _IncludeBackupReport = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.Category("Totals, Footer & Backup")> _
        Public Property BackupReportColumnOption() As Short
            Get
                BackupReportColumnOption = _BackupReportColumnOption
            End Get
            Set(ByVal value As Short)
                _BackupReportColumnOption = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.DisplayName("Employee Time Function Comment")> _
        Public Property BackupReportCommentOptionEmployeeTimeFunction() As Boolean
            Get
                BackupReportCommentOptionEmployeeTimeFunction = _BackupReportCommentOptionEmployeeTimeFunction
            End Get
            Set(ByVal value As Boolean)
                _BackupReportCommentOptionEmployeeTimeFunction = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.DisplayName("Accounts Payable Function Comment")> _
        Public Property BackupReportCommentOptionAccountsPayableFunction() As Boolean
            Get
                BackupReportCommentOptionAccountsPayableFunction = _BackupReportCommentOptionAccountsPayableFunction
            End Get
            Set(ByVal value As Boolean)
                _BackupReportCommentOptionAccountsPayableFunction = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.DisplayName("Income Only Function Comment")> _
        Public Property BackupReportCommentOptionIncomeOnlyFunction() As Boolean
            Get
                BackupReportCommentOptionIncomeOnlyFunction = _BackupReportCommentOptionIncomeOnlyFunction
            End Get
            Set(ByVal value As Boolean)
                _BackupReportCommentOptionIncomeOnlyFunction = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.DisplayName("Billing Approval Client Function Comment")> _
        Public Property BackupReportCommentOptionBillingApprovalClientFunction() As Boolean
            Get
                BackupReportCommentOptionBillingApprovalClientFunction = _BackupReportCommentOptionBillingApprovalClientFunction
            End Get
            Set(ByVal value As Boolean)
                _BackupReportCommentOptionBillingApprovalClientFunction = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.DisplayName("Custom Invoice")> _
        Public Property CustomInvoiceID() As Nullable(Of Integer)
            Get
                CustomInvoiceID = _CustomInvoiceID
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _CustomInvoiceID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.DisplayName("Client PO Location")>
        Public Property ClientPOLocation() As Integer
            Get
                ClientPOLocation = _ClientPOLocation
            End Get
            Set(value As Integer)
                _ClientPOLocation = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.DisplayName("Hide Job Info")>
        Public Property HideJobInfo() As Boolean
            Get
                HideJobInfo = _HideJobInfo
            End Get
            Set(value As Boolean)
                _HideJobInfo = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.DisplayName("Print Client Name")>
        Public Property PrintClientName() As Boolean
            Get
                PrintClientName = _PrintClientName
            End Get
            Set(value As Boolean)
                _PrintClientName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.DisplayName("Show Campaign")>
        Public Property ShowCampaign() As Boolean
            Get
                ShowCampaign = _ShowCampaign
            End Get
            Set(value As Boolean)
                _ShowCampaign = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.DisplayName("Show Campaign Comment")>
        Public Property ShowCampaignComment() As Boolean
            Get
                ShowCampaignComment = _ShowCampaignComment
            End Get
            Set(value As Boolean)
                _ShowCampaignComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.DisplayName("Show Codes")>
        Public Property ShowCodes() As Boolean
            Get
                ShowCodes = _ShowCodes
            End Get
            Set(value As Boolean)
                _ShowCodes = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.DisplayName("Tax Total Location")>
        Public Property TaxTotalLocation() As Integer
            Get
                TaxTotalLocation = _TaxTotalLocation
            End Get
            Set(value As Integer)
                _TaxTotalLocation = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.DisplayName("Client Reference Location")>
        Public Property ClientRefLocation() As Integer
            Get
                ClientRefLocation = _ClientRefLocation
            End Get
            Set(value As Integer)
                _ClientRefLocation = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.DisplayName("Sales Class Location")>
        Public Property SalesClassLocation() As Integer
            Get
                SalesClassLocation = _SalesClassLocation
            End Get
            Set(value As Integer)
                _SalesClassLocation = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.DisplayName("Campaign Location")>
        Public Property CampaignLocation() As Integer
            Get
                CampaignLocation = _CampaignLocation
            End Get
            Set(value As Integer)
                _CampaignLocation = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.DisplayName("Header Group By")>
        Public Property HeaderGroupBy() As Integer
            Get
                HeaderGroupBy = _HeaderGroupBy
            End Get
            Set(value As Integer)
                _HeaderGroupBy = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.DisplayName("Include Estimate Function Comment")>
        Public Property IncludeEstimateFunctionComment() As Boolean
            Get
                IncludeEstimateFunctionComment = _IncludeEstimateFunctionComment
            End Get
            Set(value As Boolean)
                _IncludeEstimateFunctionComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShowAPDescription() As Boolean
            Get
                ShowAPDescription = _ShowAPDescription
            End Get
            Set(value As Boolean)
                _ShowAPDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShowAPDate() As Boolean
            Get
                ShowAPDate = _ShowAPDate
            End Get
            Set(value As Boolean)
                _ShowAPDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShowAPRate() As Boolean
            Get
                ShowAPRate = _ShowAPRate
            End Get
            Set(value As Boolean)
                _ShowAPRate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShowEmployeeTimeDescription() As Boolean
            Get
                ShowEmployeeTimeDescription = _ShowEmployeeTimeDescription
            End Get
            Set(value As Boolean)
                _ShowEmployeeTimeDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShowEmployeeTimeDate() As Boolean
            Get
                ShowEmployeeTimeDate = _ShowEmployeeTimeDate
            End Get
            Set(value As Boolean)
                _ShowEmployeeTimeDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShowEmployeeTimeRate() As Boolean
            Get
                ShowEmployeeTimeRate = _ShowEmployeeTimeRate
            End Get
            Set(value As Boolean)
                _ShowEmployeeTimeRate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShowIncomeOnlyDescription() As Boolean
            Get
                ShowIncomeOnlyDescription = _ShowIncomeOnlyDescription
            End Get
            Set(value As Boolean)
                _ShowIncomeOnlyDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShowIncomeOnlyDate() As Boolean
            Get
                ShowIncomeOnlyDate = _ShowIncomeOnlyDate
            End Get
            Set(value As Boolean)
                _ShowIncomeOnlyDate = value
            End Set
        End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property ShowIncomeOnlyRate() As Boolean
			Get
				ShowIncomeOnlyRate = _ShowIncomeOnlyRate
			End Get
			Set(value As Boolean)
				_ShowIncomeOnlyRate = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DisplayName("Show Employee Time Comment")>
		Public Property ShowEmployeeTimeComment() As Boolean
			Get
                ShowEmployeeTimeComment = _ShowEmployeeTimeFunctionComment
            End Get
			Set(ByVal value As Boolean)
                _ShowEmployeeTimeFunctionComment = value
            End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DisplayName("Show Income Only Comment")>
		Public Property ShowIncomeOnlyComment() As Boolean
			Get
                ShowIncomeOnlyComment = _ShowIncomeOnlyFunctionComment
            End Get
			Set(ByVal value As Boolean)
                _ShowIncomeOnlyFunctionComment = value
            End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DisplayName("Show AP Comment")>
		Public Property ShowAPComment() As Boolean
			Get
                ShowAPComment = _ShowAccountsPayableFunctionComment
            End Get
			Set(ByVal value As Boolean)
                _ShowAccountsPayableFunctionComment = value
            End Set
		End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SummaryLevel() As Integer
            Get
                SummaryLevel = _SummaryLevel
            End Get
            Set(value As Integer)
                _SummaryLevel = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        System.ComponentModel.DisplayName("Breakup By Job/Comp")>
        Public Property BreakupByJobComponent() As Boolean
            Get
                BreakupByJobComponent = _BreakupByJobComponent
            End Get
            Set(value As Boolean)
                _BreakupByJobComponent = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(ByVal ProductionInvoiceDefault As AdvantageFramework.Database.Entities.ProductionInvoiceDefault)

            Me.ProductionInvoicePrintingOptionsID = ProductionInvoiceDefault.ID
            Me.CustomFormatName = ProductionInvoiceDefault.CustomFormatName
            Me.UseLocationPrintOptions = If(ProductionInvoiceDefault.UseLocationPrintOptions.GetValueOrDefault(1) = 2, True, False)
            Me.LocationCode = ProductionInvoiceDefault.LocationCode
            Me.UseInvoiceCategoryDescription = Convert.ToBoolean(ProductionInvoiceDefault.UseInvoiceCategoryDescription.GetValueOrDefault(0))
            Me.InvoiceTitle = ProductionInvoiceDefault.InvoiceTitle
            Me.AddressBlockType = ProductionInvoiceDefault.AddressBlockType.GetValueOrDefault(1)
            Me.PrintDivisionName = Convert.ToBoolean(ProductionInvoiceDefault.PrintDivisionName.GetValueOrDefault(0))
            Me.PrintProductDescription = Convert.ToBoolean(ProductionInvoiceDefault.PrintProductDescription.GetValueOrDefault(0))
            Me.PrintContactAfterAddress = Convert.ToBoolean(ProductionInvoiceDefault.PrintContactAfterAddress.GetValueOrDefault(0))
            Me.ContactType = ProductionInvoiceDefault.ContactType
            Me.IncludeClientReference = Convert.ToBoolean(ProductionInvoiceDefault.IncludeClientReference.GetValueOrDefault(0))
            Me.IncludeClientPO = Convert.ToBoolean(ProductionInvoiceDefault.IncludeClientPO.GetValueOrDefault(0))
            Me.IncludeAccountExecutive = Convert.ToBoolean(ProductionInvoiceDefault.IncludeAccountExecutive.GetValueOrDefault(0))
            Me.IncludeSalesClass = Convert.ToBoolean(ProductionInvoiceDefault.IncludeSalesClass.GetValueOrDefault(0))
            Me.IncludeInvoiceDueDate = Convert.ToBoolean(ProductionInvoiceDefault.IncludeInvoiceDueDate.GetValueOrDefault(0))
            Me.HideComponentNumberAndDescription = Convert.ToBoolean(ProductionInvoiceDefault.HideComponentNumberAndDescription.GetValueOrDefault(0))
            Me.IncludeBillingComment = Convert.ToBoolean(ProductionInvoiceDefault.IncludeBillingComment.GetValueOrDefault(0))
            Me.IncludeBillingApprovalClientComment = Convert.ToBoolean(ProductionInvoiceDefault.IncludeBillingApprovalClientComment.GetValueOrDefault(0))
            Me.IncludeJobComment = Convert.ToBoolean(ProductionInvoiceDefault.IncludeJobComment.GetValueOrDefault(0))
            Me.IncludeJobComponentComment = Convert.ToBoolean(ProductionInvoiceDefault.IncludeJobComponentComment.GetValueOrDefault(0))
            Me.IncludeEstimateComment = Convert.ToBoolean(ProductionInvoiceDefault.IncludeEstimateComment.GetValueOrDefault(0))
            Me.IncludeEstimateComponentComment = Convert.ToBoolean(ProductionInvoiceDefault.IncludeEstimateComponentComment.GetValueOrDefault(0))
            Me.IncludeEstimateQuoteComment = Convert.ToBoolean(ProductionInvoiceDefault.IncludeEstimateQuoteComment.GetValueOrDefault(0))
            Me.IncludeEstimateRevisionComment = Convert.ToBoolean(ProductionInvoiceDefault.IncludeEstimateRevisionComment.GetValueOrDefault(0))
            Me.ApplyExchangeRate = If(ProductionInvoiceDefault.ApplyExchangeRate.GetValueOrDefault(1) = 2, True, False)
            Me.ExchangeRateAmount = ProductionInvoiceDefault.ExchangeRateAmount.GetValueOrDefault(1)
            Me.HideExchangeRateMessage = ProductionInvoiceDefault.HideExchangeRateMessage
            Me.ReportFormatType = ProductionInvoiceDefault.ReportFormatType.GetValueOrDefault(1)
            Me.ShowEmployeeHours = Convert.ToBoolean(ProductionInvoiceDefault.ShowEmployeeHours.GetValueOrDefault(0))
            Me.ShowQuantity = Convert.ToBoolean(ProductionInvoiceDefault.ShowQuantity.GetValueOrDefault(0))
            Me.GroupingOptionType = ProductionInvoiceDefault.GroupingOptionType.GetValueOrDefault(1)
            Me.GroupingOptionInsideDescription = ProductionInvoiceDefault.GroupingOptionInsideDescription
            Me.GroupingOptionOutsideDescription = ProductionInvoiceDefault.GroupingOptionOutsideDescription
            Me.SortFunctionByType = ProductionInvoiceDefault.SortFunctionByType.GetValueOrDefault(1)
            Me.PrintFunctionType = ProductionInvoiceDefault.PrintFunctionType.GetValueOrDefault(1)
            Me.ShowFunctionDetail = Convert.ToBoolean(ProductionInvoiceDefault.ShowFunctionDetail.GetValueOrDefault(0))
            Me.ShowZeroFunctionAmounts = Convert.ToBoolean(ProductionInvoiceDefault.ShowZeroFunctionAmounts.GetValueOrDefault(0))
            Me.IndicateTaxableFunctions = Convert.ToBoolean(ProductionInvoiceDefault.IndicateTaxableFunctions.GetValueOrDefault(0))
            Me.HideFunctionTotals = Convert.ToBoolean(ProductionInvoiceDefault.HideFunctionTotals.GetValueOrDefault(0))
            Me.TotalsShowCommissionSeparately = Convert.ToBoolean(ProductionInvoiceDefault.TotalsShowCommissionSeparately.GetValueOrDefault(0))
            Me.TotalsShowTaxSeparately = Convert.ToBoolean(ProductionInvoiceDefault.TotalsShowTaxSeparately.GetValueOrDefault(0))
            Me.TotalsShowBillingHistory = Convert.ToBoolean(ProductionInvoiceDefault.TotalsShowBillingHistory.GetValueOrDefault(0))
            Me.InvoiceFooterCommentType = ProductionInvoiceDefault.InvoiceFooterCommentType.GetValueOrDefault(1)
            Me.InvoiceFooterComment = ProductionInvoiceDefault.InvoiceFooterComment
            Me.IncludeBackupReport = If(ProductionInvoiceDefault.IncludeBackupReport.GetValueOrDefault(1) = 2, True, False)
            Me.BackupReportColumnOption = ProductionInvoiceDefault.BackupReportColumnOption.GetValueOrDefault(1)
            Me.BackupReportCommentOptionEmployeeTimeFunction = Convert.ToBoolean(ProductionInvoiceDefault.BackupReportCommentOptionEmployeeTimeFunction.GetValueOrDefault(0))
            Me.BackupReportCommentOptionAccountsPayableFunction = Convert.ToBoolean(ProductionInvoiceDefault.BackupReportCommentOptionAccountsPayableFunction.GetValueOrDefault(0))
            Me.BackupReportCommentOptionIncomeOnlyFunction = Convert.ToBoolean(ProductionInvoiceDefault.BackupReportCommentOptionIncomeOnlyFunction.GetValueOrDefault(0))
            Me.BackupReportCommentOptionBillingApprovalClientFunction = Convert.ToBoolean(ProductionInvoiceDefault.BackupReportCommentOptionBillingApprovalClientFunction.GetValueOrDefault(0))
            Me.CustomInvoiceID = ProductionInvoiceDefault.CustomInvoiceID
            Me.ClientPOLocation = ProductionInvoiceDefault.ClientPOLocation
            Me.HideJobInfo = ProductionInvoiceDefault.HideJobInfo
            Me.PrintClientName = ProductionInvoiceDefault.PrintClientName
            Me.ShowCampaign = ProductionInvoiceDefault.ShowCampaign
            Me.ShowCampaignComment = ProductionInvoiceDefault.ShowCampaignComment
            Me.ShowCodes = ProductionInvoiceDefault.ShowCodes
            Me.TaxTotalLocation = ProductionInvoiceDefault.TaxTotalLocation
            Me.ClientRefLocation = ProductionInvoiceDefault.ClientRefLocation
            Me.SalesClassLocation = ProductionInvoiceDefault.SalesClassLocation
            Me.CampaignLocation = ProductionInvoiceDefault.CampaignLocation
            Me.HeaderGroupBy = ProductionInvoiceDefault.HeaderGroupBy
            Me.IncludeEstimateFunctionComment = ProductionInvoiceDefault.IncludeEstimateFunctionComment
            Me.ShowAPDescription = ProductionInvoiceDefault.ShowAPDescription
            Me.ShowAPDate = ProductionInvoiceDefault.ShowAPDate
            Me.ShowAPRate = ProductionInvoiceDefault.ShowAPRate
            Me.ShowEmployeeTimeDescription = ProductionInvoiceDefault.ShowEmployeeTimeDescription
            Me.ShowEmployeeTimeDate = ProductionInvoiceDefault.ShowEmployeeTimeDate
            Me.ShowEmployeeTimeRate = ProductionInvoiceDefault.ShowEmployeeTimeRate
            Me.ShowIncomeOnlyDescription = ProductionInvoiceDefault.ShowIncomeOnlyDescription
            Me.ShowIncomeOnlyDate = ProductionInvoiceDefault.ShowIncomeOnlyDate
			Me.ShowIncomeOnlyRate = ProductionInvoiceDefault.ShowIncomeOnlyRate
            Me.ShowEmployeeTimeComment = ProductionInvoiceDefault.ShowEmployeeTimeComment
            Me.ShowAPComment = ProductionInvoiceDefault.ShowAPComment
            Me.ShowIncomeOnlyComment = ProductionInvoiceDefault.ShowIncomeOnlyComment
            Me.SummaryLevel = ProductionInvoiceDefault.SummaryLevel
            Me.BreakupByJobComponent = ProductionInvoiceDefault.BreakupByJobComponent

            _ProductionInvoiceDefault = ProductionInvoiceDefault

        End Sub
        Public Sub New(ByVal InvoicePrintingSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting)

            Me.ProductionInvoicePrintingOptionsID = InvoicePrintingSetting.ProductionInvoicePrintingOptionsID.GetValueOrDefault(0)
            Me.CustomFormatName = InvoicePrintingSetting.CustomFormatName
            Me.UseLocationPrintOptions = InvoicePrintingSetting.UseLocationPrintOptions.GetValueOrDefault(False)
            Me.LocationCode = InvoicePrintingSetting.LocationCode
            Me.UseInvoiceCategoryDescription = InvoicePrintingSetting.UseInvoiceCategoryDescription.GetValueOrDefault(False)
            Me.InvoiceTitle = InvoicePrintingSetting.InvoiceTitle
            Me.AddressBlockType = InvoicePrintingSetting.AddressBlockType.GetValueOrDefault(1)
            Me.PrintDivisionName = InvoicePrintingSetting.PrintDivisionName.GetValueOrDefault(False)
            Me.PrintProductDescription = InvoicePrintingSetting.PrintProductDescription.GetValueOrDefault(False)
            Me.PrintContactAfterAddress = InvoicePrintingSetting.PrintContactAfterAddress.GetValueOrDefault(False)
            Me.ContactType = InvoicePrintingSetting.ContactType
            Me.IncludeClientReference = InvoicePrintingSetting.IncludeClientReference.GetValueOrDefault(False)
            Me.IncludeClientPO = InvoicePrintingSetting.IncludeClientPO.GetValueOrDefault(False)
            Me.IncludeAccountExecutive = InvoicePrintingSetting.IncludeAccountExecutive.GetValueOrDefault(False)
            Me.IncludeSalesClass = InvoicePrintingSetting.IncludeSalesClass.GetValueOrDefault(False)
            Me.IncludeInvoiceDueDate = InvoicePrintingSetting.IncludeInvoiceDueDate.GetValueOrDefault(False)
            Me.HideComponentNumberAndDescription = InvoicePrintingSetting.HideComponentNumberAndDescription.GetValueOrDefault(False)
            Me.IncludeBillingComment = InvoicePrintingSetting.IncludeBillingComment.GetValueOrDefault(False)
            Me.IncludeBillingApprovalClientComment = InvoicePrintingSetting.IncludeBillingApprovalClientComment.GetValueOrDefault(False)
            Me.IncludeJobComment = InvoicePrintingSetting.IncludeJobComment.GetValueOrDefault(False)
            Me.IncludeJobComponentComment = InvoicePrintingSetting.IncludeJobComponentComment.GetValueOrDefault(False)
            Me.IncludeEstimateComment = InvoicePrintingSetting.IncludeEstimateComment.GetValueOrDefault(False)
            Me.IncludeEstimateComponentComment = InvoicePrintingSetting.IncludeEstimateComponentComment.GetValueOrDefault(False)
            Me.IncludeEstimateQuoteComment = InvoicePrintingSetting.IncludeEstimateQuoteComment.GetValueOrDefault(False)
            Me.IncludeEstimateRevisionComment = InvoicePrintingSetting.IncludeEstimateRevisionComment.GetValueOrDefault(False)
            Me.ApplyExchangeRate = If(InvoicePrintingSetting.ApplyExchangeRate.GetValueOrDefault(1) = 2, True, False)
            Me.ExchangeRateAmount = InvoicePrintingSetting.ExchangeRateAmount.GetValueOrDefault(1)
            Me.HideExchangeRateMessage = InvoicePrintingSetting.HideExchangeRateMessage
            Me.ReportFormatType = InvoicePrintingSetting.ReportFormatType.GetValueOrDefault(1)
            Me.ShowEmployeeHours = InvoicePrintingSetting.ShowEmployeeHours.GetValueOrDefault(False)
            Me.ShowQuantity = InvoicePrintingSetting.ShowQuantity.GetValueOrDefault(False)
            Me.GroupingOptionType = InvoicePrintingSetting.GroupingOptionType.GetValueOrDefault(1)
            Me.GroupingOptionInsideDescription = InvoicePrintingSetting.GroupingOptionInsideDescription
            Me.GroupingOptionOutsideDescription = InvoicePrintingSetting.GroupingOptionOutsideDescription
            Me.SortFunctionByType = InvoicePrintingSetting.SortFunctionByType.GetValueOrDefault(1)
            Me.PrintFunctionType = InvoicePrintingSetting.PrintFunctionType.GetValueOrDefault(1)
            Me.ShowFunctionDetail = InvoicePrintingSetting.ShowFunctionDetail.GetValueOrDefault(False)
            Me.ShowZeroFunctionAmounts = InvoicePrintingSetting.ShowZeroFunctionAmounts.GetValueOrDefault(False)
            Me.IndicateTaxableFunctions = InvoicePrintingSetting.IndicateTaxableFunctions.GetValueOrDefault(False)
            Me.HideFunctionTotals = InvoicePrintingSetting.HideFunctionTotals.GetValueOrDefault(False)
            Me.TotalsShowCommissionSeparately = InvoicePrintingSetting.TotalsShowCommissionSeparately.GetValueOrDefault(False)
            Me.TotalsShowTaxSeparately = InvoicePrintingSetting.TotalsShowTaxSeparately.GetValueOrDefault(False)
            Me.TotalsShowBillingHistory = InvoicePrintingSetting.TotalsShowBillingHistory.GetValueOrDefault(False)
            Me.InvoiceFooterCommentType = InvoicePrintingSetting.InvoiceFooterCommentType.GetValueOrDefault(1)
            Me.InvoiceFooterComment = InvoicePrintingSetting.InvoiceFooterComment
            Me.IncludeBackupReport = InvoicePrintingSetting.IncludeBackupReport.GetValueOrDefault(False)
            Me.BackupReportColumnOption = InvoicePrintingSetting.BackupReportColumnOption.GetValueOrDefault(1)
            Me.BackupReportCommentOptionEmployeeTimeFunction = InvoicePrintingSetting.BackupReportCommentOptionEmployeeTimeFunction.GetValueOrDefault(False)
            Me.BackupReportCommentOptionAccountsPayableFunction = InvoicePrintingSetting.BackupReportCommentOptionAccountsPayableFunction.GetValueOrDefault(False)
            Me.BackupReportCommentOptionIncomeOnlyFunction = InvoicePrintingSetting.BackupReportCommentOptionIncomeOnlyFunction.GetValueOrDefault(False)
            Me.BackupReportCommentOptionBillingApprovalClientFunction = InvoicePrintingSetting.BackupReportCommentOptionBillingApprovalClientFunction.GetValueOrDefault(False)
            Me.CustomInvoiceID = InvoicePrintingSetting.CustomInvoiceID
            Me.ClientPOLocation = InvoicePrintingSetting.ClientPOLocation
            Me.HideJobInfo = InvoicePrintingSetting.HideJobInfo
            Me.PrintClientName = InvoicePrintingSetting.PrintClientName
            Me.ShowCampaign = InvoicePrintingSetting.ShowCampaign
            Me.ShowCampaignComment = InvoicePrintingSetting.ShowCampaignComment
            Me.ShowCodes = InvoicePrintingSetting.ShowCodes
            Me.TaxTotalLocation = InvoicePrintingSetting.TaxTotalLocation
            Me.ClientRefLocation = InvoicePrintingSetting.ClientRefLocation
            Me.SalesClassLocation = InvoicePrintingSetting.SalesClassLocation
            Me.CampaignLocation = InvoicePrintingSetting.CampaignLocation
            Me.HeaderGroupBy = InvoicePrintingSetting.HeaderGroupBy
            Me.IncludeEstimateFunctionComment = InvoicePrintingSetting.IncludeEstimateFunctionComment
            Me.ShowAPDescription = InvoicePrintingSetting.ShowAPDescription
            Me.ShowAPDate = InvoicePrintingSetting.ShowAPDate
            Me.ShowAPRate = InvoicePrintingSetting.ShowAPRate
            Me.ShowEmployeeTimeDescription = InvoicePrintingSetting.ShowEmployeeTimeDescription
            Me.ShowEmployeeTimeDate = InvoicePrintingSetting.ShowEmployeeTimeDate
            Me.ShowEmployeeTimeRate = InvoicePrintingSetting.ShowEmployeeTimeRate
            Me.ShowIncomeOnlyDescription = InvoicePrintingSetting.ShowIncomeOnlyDescription
            Me.ShowIncomeOnlyDate = InvoicePrintingSetting.ShowIncomeOnlyDate
            Me.ShowIncomeOnlyRate = InvoicePrintingSetting.ShowIncomeOnlyRate
            Me.ShowEmployeeTimeComment = InvoicePrintingSetting.ShowEmployeeTimeFunctionComment
            Me.ShowAPComment = InvoicePrintingSetting.ShowAccountsPayableFunctionComment
            Me.ShowIncomeOnlyComment = InvoicePrintingSetting.ShowIncomeOnlyFunctionComment
            Me.SummaryLevel = InvoicePrintingSetting.SummaryLevel
            Me.BreakupByJobComponent = InvoicePrintingSetting.BreakupByJobComponent

            _InvoicePrintingSetting = InvoicePrintingSetting

        End Sub
        Public Function GetEntity() As Object

            If _InvoicePrintingSetting IsNot Nothing Then

                GetEntity = _InvoicePrintingSetting

            ElseIf _ProductionInvoiceDefault IsNot Nothing Then

                GetEntity = _ProductionInvoiceDefault

            Else

                GetEntity = Nothing

            End If

        End Function
        Public Function SaveAndGetEntity() As Object

            Save()

            If _InvoicePrintingSetting IsNot Nothing Then

                SaveAndGetEntity = _InvoicePrintingSetting

            ElseIf _ProductionInvoiceDefault IsNot Nothing Then

                SaveAndGetEntity = _ProductionInvoiceDefault

            Else

                SaveAndGetEntity = Nothing

            End If

        End Function
        Public Sub Save()

            If _InvoicePrintingSetting IsNot Nothing Then

                Save(_InvoicePrintingSetting)

            ElseIf _ProductionInvoiceDefault IsNot Nothing Then

                Save(_ProductionInvoiceDefault)

            End If

        End Sub
        Public Sub Save(ByVal InvoicePrintingSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting)

            InvoicePrintingSetting.UseLocationPrintOptions = Me.UseLocationPrintOptions
            InvoicePrintingSetting.LocationCode = Me.LocationCode
            InvoicePrintingSetting.UseInvoiceCategoryDescription = Me.UseInvoiceCategoryDescription
            InvoicePrintingSetting.InvoiceTitle = Me.InvoiceTitle
            InvoicePrintingSetting.AddressBlockType = Me.AddressBlockType
            InvoicePrintingSetting.PrintDivisionName = Me.PrintDivisionName
            InvoicePrintingSetting.PrintProductDescription = Me.PrintProductDescription
            InvoicePrintingSetting.PrintContactAfterAddress = Me.PrintContactAfterAddress
            InvoicePrintingSetting.ContactType = Me.ContactType
            InvoicePrintingSetting.IncludeClientReference = Me.IncludeClientReference
            InvoicePrintingSetting.IncludeClientPO = Me.IncludeClientPO
            InvoicePrintingSetting.IncludeAccountExecutive = Me.IncludeAccountExecutive
            InvoicePrintingSetting.IncludeSalesClass = Me.IncludeSalesClass
            InvoicePrintingSetting.IncludeInvoiceDueDate = Me.IncludeInvoiceDueDate
            InvoicePrintingSetting.HideComponentNumberAndDescription = Me.HideComponentNumberAndDescription
            InvoicePrintingSetting.IncludeBillingComment = Me.IncludeBillingComment
            InvoicePrintingSetting.IncludeBillingApprovalClientComment = Me.IncludeBillingApprovalClientComment
            InvoicePrintingSetting.IncludeJobComment = Me.IncludeJobComment
            InvoicePrintingSetting.IncludeJobComponentComment = Me.IncludeJobComponentComment
            InvoicePrintingSetting.IncludeEstimateComment = Me.IncludeEstimateComment
            InvoicePrintingSetting.IncludeEstimateComponentComment = Me.IncludeEstimateComponentComment
            InvoicePrintingSetting.IncludeEstimateQuoteComment = Me.IncludeEstimateQuoteComment
            InvoicePrintingSetting.IncludeEstimateRevisionComment = Me.IncludeEstimateRevisionComment
            InvoicePrintingSetting.ApplyExchangeRate = If(Me.ApplyExchangeRate, 2, 1)
            InvoicePrintingSetting.ExchangeRateAmount = Me.ExchangeRateAmount
            InvoicePrintingSetting.HideExchangeRateMessage = Me.HideExchangeRateMessage
            InvoicePrintingSetting.ReportFormatType = Me.ReportFormatType
            InvoicePrintingSetting.ShowEmployeeHours = Me.ShowEmployeeHours
            InvoicePrintingSetting.ShowQuantity = Me.ShowQuantity
            InvoicePrintingSetting.GroupingOptionType = Me.GroupingOptionType
            InvoicePrintingSetting.GroupingOptionInsideDescription = Me.GroupingOptionInsideDescription
            InvoicePrintingSetting.GroupingOptionOutsideDescription = Me.GroupingOptionOutsideDescription
            InvoicePrintingSetting.SortFunctionByType = Me.SortFunctionByType
            InvoicePrintingSetting.PrintFunctionType = Me.PrintFunctionType
            InvoicePrintingSetting.ShowFunctionDetail = Me.ShowFunctionDetail
            InvoicePrintingSetting.ShowZeroFunctionAmounts = Me.ShowZeroFunctionAmounts
            InvoicePrintingSetting.IndicateTaxableFunctions = Me.IndicateTaxableFunctions
            InvoicePrintingSetting.HideFunctionTotals = Me.HideFunctionTotals
            InvoicePrintingSetting.TotalsShowCommissionSeparately = Me.TotalsShowCommissionSeparately
            InvoicePrintingSetting.TotalsShowTaxSeparately = Me.TotalsShowTaxSeparately
            InvoicePrintingSetting.TotalsShowBillingHistory = Me.TotalsShowBillingHistory
            InvoicePrintingSetting.InvoiceFooterCommentType = Me.InvoiceFooterCommentType
            InvoicePrintingSetting.InvoiceFooterComment = Me.InvoiceFooterComment
            InvoicePrintingSetting.IncludeBackupReport = Me.IncludeBackupReport
            InvoicePrintingSetting.BackupReportColumnOption = Me.BackupReportColumnOption
            InvoicePrintingSetting.BackupReportCommentOptionEmployeeTimeFunction = Me.BackupReportCommentOptionEmployeeTimeFunction
            InvoicePrintingSetting.BackupReportCommentOptionAccountsPayableFunction = Me.BackupReportCommentOptionAccountsPayableFunction
            InvoicePrintingSetting.BackupReportCommentOptionIncomeOnlyFunction = Me.BackupReportCommentOptionIncomeOnlyFunction
            InvoicePrintingSetting.BackupReportCommentOptionBillingApprovalClientFunction = Me.BackupReportCommentOptionBillingApprovalClientFunction
            InvoicePrintingSetting.CustomInvoiceID = Me.CustomInvoiceID
            InvoicePrintingSetting.ClientPOLocation = Me.ClientPOLocation
            InvoicePrintingSetting.HideJobInfo = Me.HideJobInfo
            InvoicePrintingSetting.PrintClientName = Me.PrintClientName
            InvoicePrintingSetting.ShowCampaign = Me.ShowCampaign
            InvoicePrintingSetting.ShowCampaignComment = Me.ShowCampaignComment
            InvoicePrintingSetting.ShowCodes = Me.ShowCodes
            InvoicePrintingSetting.TaxTotalLocation = Me.TaxTotalLocation
            InvoicePrintingSetting.ClientRefLocation = Me.ClientRefLocation
            InvoicePrintingSetting.SalesClassLocation = Me.SalesClassLocation
            InvoicePrintingSetting.CampaignLocation = Me.CampaignLocation
            InvoicePrintingSetting.HeaderGroupBy = Me.HeaderGroupBy
            InvoicePrintingSetting.IncludeEstimateFunctionComment = Me.IncludeEstimateFunctionComment
            InvoicePrintingSetting.ShowAPDescription = Me.ShowAPDescription
            InvoicePrintingSetting.ShowAPDate = Me.ShowAPDate
            InvoicePrintingSetting.ShowAPRate = Me.ShowAPRate
            InvoicePrintingSetting.ShowEmployeeTimeDescription = Me.ShowEmployeeTimeDescription
            InvoicePrintingSetting.ShowEmployeeTimeDate = Me.ShowEmployeeTimeDate
            InvoicePrintingSetting.ShowEmployeeTimeRate = Me.ShowEmployeeTimeRate
            InvoicePrintingSetting.ShowIncomeOnlyDescription = Me.ShowIncomeOnlyDescription
            InvoicePrintingSetting.ShowIncomeOnlyDate = Me.ShowIncomeOnlyDate
			InvoicePrintingSetting.ShowIncomeOnlyRate = Me.ShowIncomeOnlyRate
            InvoicePrintingSetting.ShowEmployeeTimeFunctionComment = Me.ShowEmployeeTimeComment
            InvoicePrintingSetting.ShowAccountsPayableFunctionComment = Me.ShowAPComment
            InvoicePrintingSetting.ShowIncomeOnlyFunctionComment = Me.ShowIncomeOnlyComment
            InvoicePrintingSetting.SummaryLevel = Me.SummaryLevel
            InvoicePrintingSetting.BreakupByJobComponent = Me.BreakupByJobComponent

        End Sub
        Public Sub Save(ByVal ProductionInvoiceDefault As AdvantageFramework.Database.Entities.ProductionInvoiceDefault)

            ProductionInvoiceDefault.UseLocationPrintOptions = If(Me.UseLocationPrintOptions, 2, 1)
            ProductionInvoiceDefault.LocationCode = Me.LocationCode
            ProductionInvoiceDefault.UseInvoiceCategoryDescription = Convert.ToInt16(Me.UseInvoiceCategoryDescription)
            ProductionInvoiceDefault.InvoiceTitle = Me.InvoiceTitle
            ProductionInvoiceDefault.AddressBlockType = Me.AddressBlockType
            ProductionInvoiceDefault.PrintDivisionName = Convert.ToInt16(Me.PrintDivisionName)
            ProductionInvoiceDefault.PrintProductDescription = Convert.ToInt16(Me.PrintProductDescription)
            ProductionInvoiceDefault.PrintContactAfterAddress = Convert.ToInt16(Me.PrintContactAfterAddress)
            ProductionInvoiceDefault.ContactType = Me.ContactType
            ProductionInvoiceDefault.IncludeClientReference = Convert.ToInt16(Me.IncludeClientReference)
            ProductionInvoiceDefault.IncludeClientPO = Convert.ToInt16(Me.IncludeClientPO)
            ProductionInvoiceDefault.IncludeAccountExecutive = Convert.ToInt16(Me.IncludeAccountExecutive)
            ProductionInvoiceDefault.IncludeSalesClass = Convert.ToInt16(Me.IncludeSalesClass)

            If Me.IncludeInvoiceDueDate = False Then

                ProductionInvoiceDefault.IncludeInvoiceDueDate = Nothing

            Else

                ProductionInvoiceDefault.IncludeInvoiceDueDate = Convert.ToInt16(Me.IncludeInvoiceDueDate)

            End If

            ProductionInvoiceDefault.HideComponentNumberAndDescription = Convert.ToInt16(Me.HideComponentNumberAndDescription)
            ProductionInvoiceDefault.IncludeBillingComment = Convert.ToInt16(Me.IncludeBillingComment)
            ProductionInvoiceDefault.IncludeBillingApprovalClientComment = Convert.ToInt16(Me.IncludeBillingApprovalClientComment)
            ProductionInvoiceDefault.IncludeJobComment = Convert.ToInt16(Me.IncludeJobComment)
            ProductionInvoiceDefault.IncludeJobComponentComment = Convert.ToInt16(Me.IncludeJobComponentComment)
            ProductionInvoiceDefault.IncludeEstimateComment = Convert.ToInt16(Me.IncludeEstimateComment)
            ProductionInvoiceDefault.IncludeEstimateComponentComment = Convert.ToInt16(Me.IncludeEstimateComponentComment)
            ProductionInvoiceDefault.IncludeEstimateQuoteComment = Convert.ToInt16(Me.IncludeEstimateQuoteComment)
            ProductionInvoiceDefault.IncludeEstimateRevisionComment = Convert.ToInt16(Me.IncludeEstimateRevisionComment)
            ProductionInvoiceDefault.ApplyExchangeRate = Convert.ToInt16(If(Me.ApplyExchangeRate = True, 2, 1))
            ProductionInvoiceDefault.ExchangeRateAmount = Me.ExchangeRateAmount
            ProductionInvoiceDefault.HideExchangeRateMessage = Me.HideExchangeRateMessage
            ProductionInvoiceDefault.ReportFormatType = Me.ReportFormatType
            ProductionInvoiceDefault.ShowEmployeeHours = Convert.ToInt16(Me.ShowEmployeeHours)
            ProductionInvoiceDefault.ShowQuantity = Convert.ToInt16(Me.ShowQuantity)
            ProductionInvoiceDefault.GroupingOptionType = Me.GroupingOptionType
            ProductionInvoiceDefault.GroupingOptionInsideDescription = Me.GroupingOptionInsideDescription
            ProductionInvoiceDefault.GroupingOptionOutsideDescription = Me.GroupingOptionOutsideDescription
            ProductionInvoiceDefault.SortFunctionByType = Me.SortFunctionByType
            ProductionInvoiceDefault.PrintFunctionType = Me.PrintFunctionType
            ProductionInvoiceDefault.ShowFunctionDetail = Convert.ToInt16(Me.ShowFunctionDetail)
            ProductionInvoiceDefault.ShowZeroFunctionAmounts = Convert.ToInt16(Me.ShowZeroFunctionAmounts)
            ProductionInvoiceDefault.IndicateTaxableFunctions = Convert.ToInt16(Me.IndicateTaxableFunctions)
            ProductionInvoiceDefault.HideFunctionTotals = Convert.ToInt16(Me.HideFunctionTotals)
            ProductionInvoiceDefault.TotalsShowCommissionSeparately = Convert.ToInt16(Me.TotalsShowCommissionSeparately)
            ProductionInvoiceDefault.TotalsShowTaxSeparately = Convert.ToInt16(Me.TotalsShowTaxSeparately)
            ProductionInvoiceDefault.TotalsShowBillingHistory = Convert.ToInt16(Me.TotalsShowBillingHistory)
            ProductionInvoiceDefault.InvoiceFooterCommentType = Me.InvoiceFooterCommentType
            ProductionInvoiceDefault.InvoiceFooterComment = Me.InvoiceFooterComment
            ProductionInvoiceDefault.IncludeBackupReport = If(Me.IncludeBackupReport, 2, 1)
            ProductionInvoiceDefault.BackupReportColumnOption = Me.BackupReportColumnOption
            ProductionInvoiceDefault.BackupReportCommentOptionEmployeeTimeFunction = Convert.ToInt16(Me.BackupReportCommentOptionEmployeeTimeFunction)
            ProductionInvoiceDefault.BackupReportCommentOptionAccountsPayableFunction = Convert.ToInt16(Me.BackupReportCommentOptionAccountsPayableFunction)
            ProductionInvoiceDefault.BackupReportCommentOptionIncomeOnlyFunction = Convert.ToInt16(Me.BackupReportCommentOptionIncomeOnlyFunction)
            ProductionInvoiceDefault.BackupReportCommentOptionBillingApprovalClientFunction = Convert.ToInt16(Me.BackupReportCommentOptionBillingApprovalClientFunction)
            ProductionInvoiceDefault.CustomInvoiceID = Me.CustomInvoiceID
            ProductionInvoiceDefault.ClientPOLocation = Me.ClientPOLocation
            ProductionInvoiceDefault.HideJobInfo = Me.HideJobInfo
            ProductionInvoiceDefault.PrintClientName = Me.PrintClientName
            ProductionInvoiceDefault.ShowCampaign = Me.ShowCampaign
            ProductionInvoiceDefault.ShowCampaignComment = Me.ShowCampaignComment
            ProductionInvoiceDefault.ShowCodes = Me.ShowCodes
            ProductionInvoiceDefault.TaxTotalLocation = Me.TaxTotalLocation
            ProductionInvoiceDefault.ClientRefLocation = Me.ClientRefLocation
            ProductionInvoiceDefault.SalesClassLocation = Me.SalesClassLocation
            ProductionInvoiceDefault.CampaignLocation = Me.CampaignLocation
            ProductionInvoiceDefault.HeaderGroupBy = Me.HeaderGroupBy
            ProductionInvoiceDefault.IncludeEstimateFunctionComment = Me.IncludeEstimateFunctionComment
            ProductionInvoiceDefault.ShowAPDescription = Me.ShowAPDescription
            ProductionInvoiceDefault.ShowAPDate = Me.ShowAPDate
            ProductionInvoiceDefault.ShowAPRate = Me.ShowAPRate
            ProductionInvoiceDefault.ShowEmployeeTimeDescription = Me.ShowEmployeeTimeDescription
            ProductionInvoiceDefault.ShowEmployeeTimeDate = Me.ShowEmployeeTimeDate
            ProductionInvoiceDefault.ShowEmployeeTimeRate = Me.ShowEmployeeTimeRate
            ProductionInvoiceDefault.ShowIncomeOnlyDescription = Me.ShowIncomeOnlyDescription
            ProductionInvoiceDefault.ShowIncomeOnlyDate = Me.ShowIncomeOnlyDate
            ProductionInvoiceDefault.ShowIncomeOnlyRate = Me.ShowIncomeOnlyRate
            ProductionInvoiceDefault.ShowEmployeeTimeComment = Me.ShowEmployeeTimeComment
            ProductionInvoiceDefault.ShowAPComment = Me.ShowAPComment
            ProductionInvoiceDefault.ShowIncomeOnlyComment = Me.ShowIncomeOnlyComment
            ProductionInvoiceDefault.SummaryLevel = Me.SummaryLevel
            ProductionInvoiceDefault.BreakupByJobComponent = Me.BreakupByJobComponent

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ProductionInvoicePrintingOptionsID.ToString

        End Function

#End Region

    End Class

End Namespace
