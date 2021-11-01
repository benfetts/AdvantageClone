Namespace Estimate.Printing.Classes

    <Serializable()>
    Public Class EstimatePrintSetting

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            UserID
            SelectBy
            DateToPrint
            DatePrint
            LogoPath
            LocationCode
            ReportTitle
            PrintClientName
            PrintDivisionName
            PrintProductDescription
            CDPAddressOption
            IncludeClientReference
            IncludeAccountExecutive
            IncludeSalesClass
            IncludeJobDueDate
            IncludeJobQuantity
            SuppressZeroFunctions
            IncludeNonBillable
            IncludeQuantityHours
            IncludeRate
            SubtotalsOnly
            IncludeCPU
            IncludeCPM
            HideComponentDescription
            HideRevision
            IncludeEstimateComment
            IncludeEstimateComponentComment
            IncludeEstimateQuoteComment
            IncludeEstimateRevisionComment
            IncludeEstimateFunctionComment
            IncludeSuppliedByNotes
            ReportFormat
            CombineComponents
            ExcludeEmployeeTime
            ExcludeVendor
            ExcludeIncomeOnly
            ExcludeNonbillable
            ConsolidationOverride
            GroupingOptionFunctionOption
            GroupingOptionGroupOption
            GroupingOptionInsideDescription
            GroupingOptionOutsideDescription
            GroupingOptionSortOption
            TotalsShowTaxSeparately
            IndicateTaxableFunctions
            TotalsShowCommissionSeparately
            IndicateCommissionFunctions
            TotalsShowContingencySeparately
            TotalsIncludeContingency
            DefaultFooterComment
            Signature
            ExcludeSignatures
            IncludeSpecifications
            UseEmployeeSignature
            IncludeCampaignSummary
            IncludeVendorDescription
            IncludeFunctionComment
            PrintAdNumber
        End Enum

#End Region

#Region " Variables "

        Private _UserID As String = ""
        Private _SelectBy As String = ""
        Private _DateToPrint As Boolean = False
        Private _DatePrint As Date = Nothing
        Private _LogoPath As String = Nothing
        Private _LocationCode As String = Nothing
        Private _ReportTitle As String = Nothing
        Private _PrintClientName As Boolean = False
        Private _PrintDivisionName As Boolean = False
        Private _PrintProductDescription As Boolean = False
        Private _CDPAddressOption As String = Nothing
        Private _IncludeClientReference As Boolean = False
        Private _IncludeAccountExecutive As Boolean = False
        Private _IncludeSalesClass As Boolean = False
        Private _IncludeJobDueDate As Boolean = False
        Private _IncludeJobQuantity As Boolean = False
        Private _SuppressZeroFunctions As Boolean = False
        Private _IncludeNonBillable As Boolean = False
        Private _IncludeQuantityHours As Boolean = False
        Private _IncludeRate As Boolean = False
        Private _SubtotalsOnly As Boolean = False
        Private _IncludeCPU As Boolean = False
        Private _IncludeCPM As Boolean = False
        Private _HideComponentDescription As Boolean = False
        Private _HideRevision As Boolean = False
        Private _IncludeEstimateComment As Boolean = False
        Private _IncludeEstimateComponentComment As Boolean = False
        Private _IncludeEstimateQuoteComment As Boolean = False
        Private _IncludeEstimateRevisionComment As Boolean = False
        Private _IncludeEstimateFunctionComment As Boolean = False
        Private _IncludeSuppliedByNotes As Boolean = False
        Private _ReportFormat As String = Nothing
        Private _CombineComponents As Boolean = False
        Private _ExcludeEmployeeTime As Boolean = False
        Private _ExcludeVendor As Boolean = False
        Private _ExcludeIncomeOnly As Boolean = False
        Private _ExcludeNonbillable As Boolean = False
        Private _ConsolidationOverride As Boolean = False
        Private _GroupingOptionFunctionOption As String = ""
        Private _GroupingOptionGroupOption As String = ""
        Private _GroupingOptionInsideDescription As String = ""
        Private _GroupingOptionOutsideDescription As String = ""
        Private _GroupingOptionSortOption As String = ""
        Private _TotalsShowTaxSeparately As Boolean = False
        Private _IndicateTaxableFunctions As Boolean = False
        Private _TotalsShowCommissionSeparately As Boolean = False
        Private _IndicateCommissionFunctions As Boolean = False
        Private _TotalsShowContingencySeparately As Boolean = False
        Private _TotalsIncludeContingency As Boolean = False
        Private _DefaultFooterComment As Boolean = False
        Private _Signature As Short = 0
        Private _ExcludeSignatures As Boolean = False
        Private _IncludeSpecifications As Boolean = False
        Private _UseEmployeeSignature As Boolean = False
        Private _IncludeCampaignSummary As Boolean = False
        Private _IncludeVendorDescription As Boolean = False
        Private _IncludeFunctionComment As Boolean = False
        Private _PrintAdNumber As Boolean = False

        Private _EstimatePrintingDefault As AdvantageFramework.Database.Entities.EstimatePrintSetting = Nothing
        Private _EstimatePrintingSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintSetting = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.Browsable(False)> _
        Public Property UserID() As String
            Get
                UserID = _UserID
            End Get
            Set(ByVal value As String)
                _UserID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.Browsable(False)> _
        Public Property SelectBy() As String
            Get
                SelectBy = _SelectBy
            End Get
            Set(ByVal value As String)
                _SelectBy = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.Category("")> _
        Public Property DateToPrint() As Boolean
            Get
                DateToPrint = _DateToPrint
            End Get
            Set(ByVal value As Boolean)
                _DateToPrint = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.Category("")> _
        Public Property DatePrint() As Date
            Get
                DatePrint = _DatePrint
            End Get
            Set(ByVal value As Date)
                _DatePrint = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.Category("")> _
        Public Property LogoPath() As String
            Get
                LogoPath = _LogoPath
            End Get
            Set(ByVal value As String)
                _LogoPath = value
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
		System.ComponentModel.DataAnnotations.MaxLength(30),
		System.ComponentModel.Category("Title")>
		Public Property ReportTitle() As String
			Get
				ReportTitle = _ReportTitle
			End Get
			Set(ByVal value As String)
				_ReportTitle = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DisplayName("Print Client Name")>
		Public Property PrintClientName() As Boolean
			Get
				PrintClientName = _PrintClientName
			End Get
			Set(ByVal value As Boolean)
				_PrintClientName = value
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
		System.ComponentModel.DataAnnotations.MaxLength(10)>
		Public Property CDPAddressOption() As String
			Get
				CDPAddressOption = _CDPAddressOption
			End Get
			Set(ByVal value As String)
				_CDPAddressOption = value
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
		System.ComponentModel.DisplayName("Include Job Due Date")>
		Public Property IncludeJobDueDate() As Boolean
			Get
				IncludeJobDueDate = _IncludeJobDueDate
			End Get
			Set(ByVal value As Boolean)
				_IncludeJobDueDate = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DisplayName("Estimate Quantity")>
		Public Property IncludeJobQuantity() As Boolean
			Get
				IncludeJobQuantity = _IncludeJobQuantity
			End Get
			Set(ByVal value As Boolean)
				_IncludeJobQuantity = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DisplayName("Suppress Zero Functions")>
		Public Property SuppressZeroFunctions() As Boolean
			Get
				SuppressZeroFunctions = _SuppressZeroFunctions
			End Get
			Set(ByVal value As Boolean)
				_SuppressZeroFunctions = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DisplayName("NonBillable")>
		Public Property IncludeNonBillable() As Boolean
			Get
				IncludeNonBillable = _IncludeNonBillable
			End Get
			Set(ByVal value As Boolean)
				_IncludeNonBillable = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DisplayName("Quantity/Hours")>
		Public Property IncludeQuantityHours() As Boolean
			Get
				IncludeQuantityHours = _IncludeQuantityHours
			End Get
			Set(ByVal value As Boolean)
				_IncludeQuantityHours = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DisplayName("Include Rate")>
		Public Property IncludeRate() As Boolean
			Get
				IncludeRate = _IncludeRate
			End Get
			Set(ByVal value As Boolean)
				_IncludeRate = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DisplayName("Subtotals Only")>
		Public Property SubtotalsOnly() As Boolean
			Get
				SubtotalsOnly = _SubtotalsOnly
			End Get
			Set(ByVal value As Boolean)
				_SubtotalsOnly = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DisplayName("Include CPU")>
		Public Property IncludeCPU() As Boolean
			Get
				IncludeCPU = _IncludeCPU
			End Get
			Set(ByVal value As Boolean)
				_IncludeCPU = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DisplayName("Include CPM")>
		Public Property IncludeCPM() As Boolean
			Get
				IncludeCPM = _IncludeCPM
			End Get
			Set(ByVal value As Boolean)
				_IncludeCPM = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DisplayName("Hide Component Description")>
		Public Property HideComponentDescription() As Boolean
			Get
				HideComponentDescription = _HideComponentDescription
			End Get
			Set(ByVal value As Boolean)
				_HideComponentDescription = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DisplayName("Hide Revision Info")>
		Public Property HideRevision() As Boolean
			Get
				HideRevision = _HideRevision
			End Get
			Set(ByVal value As Boolean)
				_HideRevision = value
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
		System.ComponentModel.DisplayName("Estimate Function Comment")>
		Public Property IncludeEstimateFunctionComment() As Boolean
			Get
				IncludeEstimateFunctionComment = _IncludeEstimateFunctionComment
			End Get
			Set(ByVal value As Boolean)
				_IncludeEstimateFunctionComment = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DisplayName("Supplied By Notes")>
		Public Property IncludeSuppliedByNotes() As Boolean
			Get
				IncludeSuppliedByNotes = _IncludeSuppliedByNotes
			End Get
			Set(ByVal value As Boolean)
				_IncludeSuppliedByNotes = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DataAnnotations.MaxLength(50)>
		Public Property ReportFormat() As String
            Get
                ReportFormat = _ReportFormat
            End Get
            Set(ByVal value As String)
                _ReportFormat = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.DisplayName("Combine Components")> _
        Public Property CombineComponents() As Boolean
            Get
                CombineComponents = _CombineComponents
            End Get
            Set(ByVal value As Boolean)
                _CombineComponents = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.DisplayName("Exclude Employee Time")> _
        Public Property ExcludeEmployeeTime() As Boolean
            Get
                ExcludeEmployeeTime = _ExcludeEmployeeTime
            End Get
            Set(ByVal value As Boolean)
                _ExcludeEmployeeTime = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.DisplayName("Exclude Vendor")> _
        Public Property ExcludeVendor() As Boolean
            Get
                ExcludeVendor = _ExcludeVendor
            End Get
            Set(ByVal value As Boolean)
                _ExcludeVendor = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.DisplayName("Exclude Income Only")> _
        Public Property ExcludeIncomeOnly() As Boolean
            Get
                ExcludeIncomeOnly = _ExcludeIncomeOnly
            End Get
            Set(ByVal value As Boolean)
                _ExcludeIncomeOnly = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.DisplayName("Exclude NonBillable")> _
        Public Property ExcludeNonbillable() As Boolean
            Get
                ExcludeNonbillable = _ExcludeNonbillable
            End Get
            Set(ByVal value As Boolean)
                _ExcludeNonbillable = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.DisplayName("Override product consolidation setting")> _
        Public Property ConsolidationOverride() As Boolean
            Get
                ConsolidationOverride = _ConsolidationOverride
            End Get
            Set(ByVal value As Boolean)
                _ConsolidationOverride = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.DisplayName("Function Option")> _
        Public Property GroupingOptionFunctionOption As String
            Get
                GroupingOptionFunctionOption = _GroupingOptionFunctionOption
            End Get
            Set(ByVal value As String)
                _GroupingOptionFunctionOption = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.DisplayName("Group Option")> _
        Public Property GroupingOptionGroupOption As String
            Get
                GroupingOptionGroupOption = _GroupingOptionGroupOption
            End Get
            Set(ByVal value As String)
                _GroupingOptionGroupOption = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.DisplayName("Inside Description")> _
        Public Property GroupingOptionInsideDescription As String
            Get
                GroupingOptionInsideDescription = _GroupingOptionInsideDescription
            End Get
            Set(ByVal value As String)
                _GroupingOptionInsideDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.DisplayName("Outside Description")> _
        Public Property GroupingOptionOutsideDescription() As String
            Get
                GroupingOptionOutsideDescription = _GroupingOptionOutsideDescription
            End Get
            Set(ByVal value As String)
                _GroupingOptionOutsideDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.DisplayName("Sort Option")> _
        Public Property GroupingOptionSortOption As String
            Get
                GroupingOptionSortOption = _GroupingOptionSortOption
            End Get
            Set(ByVal value As String)
                _GroupingOptionSortOption = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.DisplayName("Show Tax Separately")> _
        Public Property TotalsShowTaxSeparately() As Boolean
            Get
                TotalsShowTaxSeparately = _TotalsShowTaxSeparately
            End Get
            Set(ByVal value As Boolean)
                _TotalsShowTaxSeparately = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.DisplayName("Indicate Taxable Functions")> _
        Public Property IndicateTaxableFunctions() As Boolean
            Get
                IndicateTaxableFunctions = _IndicateTaxableFunctions
            End Get
            Set(ByVal value As Boolean)
                _IndicateTaxableFunctions = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.DisplayName("Show Commission Separately")> _
        Public Property TotalsShowCommissionSeparately() As Boolean
            Get
                TotalsShowCommissionSeparately = _TotalsShowCommissionSeparately
            End Get
            Set(ByVal value As Boolean)
                _TotalsShowCommissionSeparately = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.DisplayName("Indicate Commission Functions")> _
        Public Property IndicateCommissionFunctions() As Boolean
            Get
                IndicateCommissionFunctions = _IndicateCommissionFunctions
            End Get
            Set(ByVal value As Boolean)
                _IndicateCommissionFunctions = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.DisplayName("Show Contingency Separately")> _
        Public Property TotalsShowContingencySeparately() As Boolean
            Get
                TotalsShowContingencySeparately = _TotalsShowContingencySeparately
            End Get
            Set(ByVal value As Boolean)
                _TotalsShowContingencySeparately = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.DisplayName("Contingency")> _
        Public Property TotalsIncludeContingency() As Boolean
            Get
                TotalsIncludeContingency = _TotalsIncludeContingency
            End Get
            Set(ByVal value As Boolean)
                _TotalsIncludeContingency = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.DisplayName("Default Footer Comment")> _
        Public Property DefaultFooterComment() As Boolean
            Get
                DefaultFooterComment = _DefaultFooterComment
            End Get
            Set(ByVal value As Boolean)
                _DefaultFooterComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.DisplayName("Signature")> _
        Public Property Signature() As Short
            Get
                Signature = _Signature
            End Get
            Set(ByVal value As Short)
                _Signature = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.DisplayName("Exclude Signatures")> _
        Public Property ExcludeSignatures() As Boolean
            Get
                ExcludeSignatures = _ExcludeSignatures
            End Get
            Set(ByVal value As Boolean)
                _ExcludeSignatures = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.DisplayName("Specifications")> _
        Public Property IncludeSpecifications() As Boolean
            Get
                IncludeSpecifications = _IncludeSpecifications
            End Get
            Set(ByVal value As Boolean)
                _IncludeSpecifications = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.DisplayName("Use Employee Signature")> _
        Public Property UseEmployeeSignature() As Boolean
            Get
                UseEmployeeSignature = _UseEmployeeSignature
            End Get
            Set(ByVal value As Boolean)
                _UseEmployeeSignature = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.DisplayName("Campaign Summary")> _
        Public Property IncludeCampaignSummary() As Boolean
            Get
                IncludeCampaignSummary = _IncludeCampaignSummary
            End Get
            Set(ByVal value As Boolean)
                _IncludeCampaignSummary = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.DisplayName("Vendor Description")> _
        Public Property IncludeVendorDescription() As Boolean
            Get
                IncludeVendorDescription = _IncludeVendorDescription
            End Get
            Set(ByVal value As Boolean)
                _IncludeVendorDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.DisplayName("Include Function Comment")> _
        Public Property IncludeFunctionComment() As Boolean
            Get
                IncludeFunctionComment = _IncludeFunctionComment
            End Get
            Set(ByVal value As Boolean)
                _IncludeFunctionComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.DisplayName("Print Ad Number")> _
        Public Property PrintAdNumber() As Boolean
            Get
                PrintAdNumber = _PrintAdNumber
            End Get
            Set(ByVal value As Boolean)
                _PrintAdNumber = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

        End Sub
        Public Sub New(ByVal EstimatePrintingDefault As AdvantageFramework.Database.Entities.EstimatePrintSetting)

            Me.UserID = EstimatePrintingDefault.UserID
            Me.SelectBy = EstimatePrintingDefault.SelectBy
            Me.DateToPrint = EstimatePrintingDefault.DateToPrint
            Me.TotalsShowTaxSeparately = Convert.ToBoolean(EstimatePrintingDefault.ShowTaxSeparately.GetValueOrDefault(0))
            Me.IndicateTaxableFunctions = Convert.ToBoolean(EstimatePrintingDefault.IndicateTaxableFunctions.GetValueOrDefault(0))
            Me.TotalsShowCommissionSeparately = Convert.ToBoolean(EstimatePrintingDefault.ShowCommissionSeparately.GetValueOrDefault(0))
            Me.IndicateCommissionFunctions = Convert.ToBoolean(EstimatePrintingDefault.IndicateCommissionFunctions.GetValueOrDefault(0))
            Me.GroupingOptionFunctionOption = EstimatePrintingDefault.FunctionOption
            Me.GroupingOptionGroupOption = EstimatePrintingDefault.GroupOption
            Me.GroupingOptionSortOption = EstimatePrintingDefault.SortOption
            Me.GroupingOptionInsideDescription = EstimatePrintingDefault.InsideDescription
            Me.GroupingOptionOutsideDescription = EstimatePrintingDefault.OutsideDescription
            Me.IncludeEstimateComment = Convert.ToBoolean(EstimatePrintingDefault.IncludeEstimateComment.GetValueOrDefault(0))
            Me.IncludeEstimateComponentComment = Convert.ToBoolean(EstimatePrintingDefault.IncludeEstimateComponentComment.GetValueOrDefault(0))
            Me.IncludeEstimateQuoteComment = Convert.ToBoolean(EstimatePrintingDefault.IncludeEstimateQuoteComment.GetValueOrDefault(0))
            Me.IncludeEstimateRevisionComment = Convert.ToBoolean(EstimatePrintingDefault.IncludeEstimateRevisionComment.GetValueOrDefault(0))
            Me.IncludeEstimateFunctionComment = Convert.ToBoolean(EstimatePrintingDefault.IncludeEstimateFunctionComment.GetValueOrDefault(0))
            Me.DefaultFooterComment = Convert.ToBoolean(EstimatePrintingDefault.DefaultFooterComment.GetValueOrDefault(0))
            Me.IncludeClientReference = Convert.ToBoolean(EstimatePrintingDefault.IncludeClientReference.GetValueOrDefault(0))
            Me.IncludeAccountExecutive = Convert.ToBoolean(EstimatePrintingDefault.IncludeAccountExecutive.GetValueOrDefault(0))
            Me.IncludeSalesClass = Convert.ToBoolean(EstimatePrintingDefault.IncludeSalesClass.GetValueOrDefault(0))
            Me.IncludeSpecifications = Convert.ToBoolean(EstimatePrintingDefault.IncludeSpecifications.GetValueOrDefault(0))
            Me.IncludeJobQuantity = Convert.ToBoolean(EstimatePrintingDefault.IncludeJobQuantity.GetValueOrDefault(0))
            Me.TotalsIncludeContingency = Convert.ToBoolean(EstimatePrintingDefault.IncludeContingency.GetValueOrDefault(0))
            Me.SuppressZeroFunctions = Convert.ToBoolean(EstimatePrintingDefault.SuppressZeroFunctions.GetValueOrDefault(0))
            Me.LocationCode = EstimatePrintingDefault.LocationCode
            Me.LogoPath = EstimatePrintingDefault.LogoPath
            Me.ReportFormat = EstimatePrintingDefault.ReportFormat
            Me.IncludeNonBillable = Convert.ToBoolean(EstimatePrintingDefault.IncludeNonBillable.GetValueOrDefault(0))
            Me.PrintDivisionName = Convert.ToBoolean(EstimatePrintingDefault.PrintDivisionName.GetValueOrDefault(0))
            Me.PrintProductDescription = Convert.ToBoolean(EstimatePrintingDefault.PrintProductDescription.GetValueOrDefault(0))
            Me.IncludeQuantityHours = Convert.ToBoolean(EstimatePrintingDefault.IncludeQuantityHours.GetValueOrDefault(0))
            Me.ConsolidationOverride = Convert.ToBoolean(EstimatePrintingDefault.ConsolidationOverride.GetValueOrDefault(0))
            Me.SubtotalsOnly = Convert.ToBoolean(EstimatePrintingDefault.SubtotalsOnly.GetValueOrDefault(0))
            Me.IncludeCPU = Convert.ToBoolean(EstimatePrintingDefault.IncludeCPU.GetValueOrDefault(0))
            Me.IncludeCPM = Convert.ToBoolean(EstimatePrintingDefault.IncludeCPM.GetValueOrDefault(0))
            Me.ReportTitle = EstimatePrintingDefault.ReportTitle
            Me.IncludeSuppliedByNotes = Convert.ToBoolean(EstimatePrintingDefault.IncludeSuppliedByNotes.GetValueOrDefault(0))
            Me.TotalsShowContingencySeparately = Convert.ToBoolean(EstimatePrintingDefault.ShowContingencySeparately.GetValueOrDefault(0))
            Me.Signature = EstimatePrintingDefault.Signature.GetValueOrDefault(0)
            Me.HideComponentDescription = Convert.ToBoolean(EstimatePrintingDefault.HideComponentDescription.GetValueOrDefault(0))
            Me.HideRevision = Convert.ToBoolean(EstimatePrintingDefault.HideRevision.GetValueOrDefault(0))
            Me.IncludeJobDueDate = Convert.ToBoolean(EstimatePrintingDefault.IncludeJobDueDate.GetValueOrDefault(0))
            Me.UseEmployeeSignature = Convert.ToBoolean(EstimatePrintingDefault.UseEmployeeSignature.GetValueOrDefault(0))
            Me.ExcludeEmployeeTime = Convert.ToBoolean(EstimatePrintingDefault.ExcludeEmployeeTime.GetValueOrDefault(0))
            Me.ExcludeVendor = Convert.ToBoolean(EstimatePrintingDefault.ExcludeVendor.GetValueOrDefault(0))
            Me.ExcludeIncomeOnly = Convert.ToBoolean(EstimatePrintingDefault.ExcludeIncomeOnly.GetValueOrDefault(0))
            Me.ExcludeSignatures = Convert.ToBoolean(EstimatePrintingDefault.ExcludeSignatures.GetValueOrDefault(0))
            Me.IncludeCampaignSummary = Convert.ToBoolean(EstimatePrintingDefault.IncludeCampaignSummary.GetValueOrDefault(0))
            Me.IncludeVendorDescription = Convert.ToBoolean(EstimatePrintingDefault.SuppressZeroFunctions.GetValueOrDefault(0))
            Me.ExcludeNonbillable = Convert.ToBoolean(EstimatePrintingDefault.IncludeVendorDescription.GetValueOrDefault(0))
            Me.CDPAddressOption = EstimatePrintingDefault.CDPAddressOption
            Me.IncludeRate = Convert.ToBoolean(EstimatePrintingDefault.IncludeRate.GetValueOrDefault(0))
            Me.CombineComponents = Convert.ToBoolean(EstimatePrintingDefault.CombineComponents.GetValueOrDefault(0))
            Me.PrintClientName = Convert.ToBoolean(EstimatePrintingDefault.PrintClientName.GetValueOrDefault(0))
            Me.IncludeFunctionComment = Convert.ToBoolean(EstimatePrintingDefault.IncludeFunctionComment.GetValueOrDefault(0))
            Me.PrintAdNumber = Convert.ToBoolean(EstimatePrintingDefault.PrintAdNumber.GetValueOrDefault(0))

            _EstimatePrintingDefault = EstimatePrintingDefault

        End Sub
        Public Sub New(ByVal EstimatePrintingSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintSetting)

            Me.UserID = EstimatePrintingSetting.UserID
            Me.SelectBy = EstimatePrintingSetting.SelectBy
            Me.DateToPrint = EstimatePrintingSetting.DateToPrint
            Me.TotalsShowTaxSeparately = EstimatePrintingSetting.TotalsShowTaxSeparately
            Me.IndicateTaxableFunctions = EstimatePrintingSetting.IndicateTaxableFunctions
            Me.TotalsShowCommissionSeparately = EstimatePrintingSetting.TotalsShowCommissionSeparately
            Me.IndicateCommissionFunctions = EstimatePrintingSetting.IndicateCommissionFunctions
            Me.GroupingOptionFunctionOption = EstimatePrintingSetting.GroupingOptionFunctionOption
            Me.GroupingOptionGroupOption = EstimatePrintingSetting.GroupingOptionGroupOption
            Me.GroupingOptionSortOption = EstimatePrintingSetting.GroupingOptionSortOption
            Me.GroupingOptionInsideDescription = EstimatePrintingSetting.GroupingOptionInsideDescription
            Me.GroupingOptionOutsideDescription = EstimatePrintingSetting.GroupingOptionOutsideDescription
            Me.IncludeEstimateComment = EstimatePrintingSetting.IncludeEstimateComment
            Me.IncludeEstimateComponentComment = EstimatePrintingSetting.IncludeEstimateComponentComment
            Me.IncludeEstimateQuoteComment = EstimatePrintingSetting.IncludeEstimateQuoteComment
            Me.IncludeEstimateRevisionComment = EstimatePrintingSetting.IncludeEstimateRevisionComment
            Me.IncludeEstimateFunctionComment = EstimatePrintingSetting.IncludeEstimateFunctionComment
            Me.DefaultFooterComment = EstimatePrintingSetting.DefaultFooterComment
            Me.IncludeClientReference = EstimatePrintingSetting.IncludeClientReference
            Me.IncludeAccountExecutive = EstimatePrintingSetting.IncludeAccountExecutive
            Me.IncludeSalesClass = EstimatePrintingSetting.IncludeSalesClass
            Me.IncludeSpecifications = EstimatePrintingSetting.IncludeSpecifications
            Me.IncludeJobQuantity = EstimatePrintingSetting.IncludeJobQuantity
            Me.TotalsIncludeContingency = EstimatePrintingSetting.TotalsIncludeContingency
            Me.SuppressZeroFunctions = EstimatePrintingSetting.SuppressZeroFunctions
            Me.LocationCode = EstimatePrintingSetting.LocationCode
            Me.LogoPath = EstimatePrintingSetting.LogoPath
            Me.ReportFormat = EstimatePrintingSetting.ReportFormat
            Me.IncludeNonBillable = EstimatePrintingSetting.IncludeNonBillable
            Me.PrintDivisionName = EstimatePrintingSetting.PrintDivisionName
            Me.PrintProductDescription = EstimatePrintingSetting.PrintProductDescription
            Me.IncludeQuantityHours = EstimatePrintingSetting.IncludeQuantityHours
            Me.ConsolidationOverride = EstimatePrintingSetting.ConsolidationOverride
            Me.SubtotalsOnly = EstimatePrintingSetting.SubtotalsOnly
            Me.IncludeCPU = EstimatePrintingSetting.IncludeCPU
            Me.IncludeCPM = EstimatePrintingSetting.IncludeCPM
            Me.ReportTitle = EstimatePrintingSetting.ReportTitle
            Me.IncludeSuppliedByNotes = EstimatePrintingSetting.IncludeSuppliedByNotes
            Me.TotalsShowContingencySeparately = EstimatePrintingSetting.TotalsShowContingencySeparately
            Me.Signature = EstimatePrintingSetting.Signature
            Me.HideComponentDescription = EstimatePrintingSetting.HideComponentDescription
            Me.HideRevision = EstimatePrintingSetting.HideRevision
            Me.IncludeJobDueDate = EstimatePrintingSetting.IncludeJobDueDate
            Me.UseEmployeeSignature = EstimatePrintingSetting.UseEmployeeSignature
            Me.ExcludeEmployeeTime = EstimatePrintingSetting.ExcludeEmployeeTime
            Me.ExcludeVendor = EstimatePrintingSetting.ExcludeVendor
            Me.ExcludeIncomeOnly = EstimatePrintingSetting.ExcludeIncomeOnly
            Me.ExcludeSignatures = EstimatePrintingSetting.ExcludeSignatures
            Me.IncludeCampaignSummary = EstimatePrintingSetting.IncludeCampaignSummary
            Me.IncludeVendorDescription = EstimatePrintingSetting.SuppressZeroFunctions
            Me.ExcludeNonbillable = EstimatePrintingSetting.IncludeVendorDescription
            Me.CDPAddressOption = EstimatePrintingSetting.CDPAddressOption
            Me.IncludeRate = EstimatePrintingSetting.IncludeRate
            Me.CombineComponents = EstimatePrintingSetting.CombineComponents
            Me.PrintClientName = EstimatePrintingSetting.PrintClientName
            Me.IncludeFunctionComment = EstimatePrintingSetting.IncludeFunctionComment
            Me.PrintAdNumber = EstimatePrintingSetting.PrintAdNumber

            _EstimatePrintingSetting = EstimatePrintingSetting

        End Sub
        Public Function GetEntity() As Object

            If _EstimatePrintingSetting IsNot Nothing Then

                GetEntity = _EstimatePrintingSetting

            ElseIf _EstimatePrintingDefault IsNot Nothing Then

                GetEntity = _EstimatePrintingDefault
            Else

                GetEntity = Nothing

            End If

        End Function
        Public Function SaveAndGetEntity() As Object

            Save()

            If _EstimatePrintingSetting IsNot Nothing Then

                SaveAndGetEntity = _EstimatePrintingSetting

            ElseIf _EstimatePrintingDefault IsNot Nothing Then

                SaveAndGetEntity = _EstimatePrintingDefault

            Else

                SaveAndGetEntity = Nothing

            End If

        End Function
        Public Sub Save()

            If _EstimatePrintingSetting IsNot Nothing Then

                Save(_EstimatePrintingSetting)

            ElseIf _EstimatePrintingDefault IsNot Nothing Then

                Save(_EstimatePrintingDefault)

            End If

        End Sub
        Public Sub Save(ByVal EstimatePrintingSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintSetting)

            EstimatePrintingSetting.UserID = Me.UserID
            EstimatePrintingSetting.DateToPrint = Me.DateToPrint
            EstimatePrintingSetting.DatePrint = Me.DatePrint
            EstimatePrintingSetting.TotalsShowTaxSeparately = Me.TotalsShowTaxSeparately
            EstimatePrintingSetting.IndicateTaxableFunctions = Me.IndicateTaxableFunctions
            EstimatePrintingSetting.TotalsShowCommissionSeparately = Me.TotalsShowCommissionSeparately
            EstimatePrintingSetting.IndicateCommissionFunctions = Me.IndicateCommissionFunctions
            If Me.GroupingOptionFunctionOption = "1" Then
                EstimatePrintingSetting.GroupingOptionFunctionOption = "F"
            ElseIf Me.GroupingOptionFunctionOption = "2" Then
                EstimatePrintingSetting.GroupingOptionFunctionOption = "C"
            ElseIf Me.GroupingOptionFunctionOption = "3" Then
                EstimatePrintingSetting.GroupingOptionFunctionOption = "T"
            ElseIf Me.GroupingOptionFunctionOption = "4" Then
                EstimatePrintingSetting.GroupingOptionFunctionOption = "R"
            ElseIf Me.GroupingOptionFunctionOption = "5" Then
                EstimatePrintingSetting.GroupingOptionFunctionOption = "N"
            Else
                EstimatePrintingSetting.GroupingOptionFunctionOption = "F"
            End If
            If Me.GroupingOptionGroupOption = "1" Then
                EstimatePrintingSetting.GroupingOptionGroupOption = "N"
            ElseIf Me.GroupingOptionGroupOption = "2" Then
                EstimatePrintingSetting.GroupingOptionGroupOption = "T"
            ElseIf Me.GroupingOptionGroupOption = "3" Then
                EstimatePrintingSetting.GroupingOptionGroupOption = "H"
            ElseIf Me.GroupingOptionGroupOption = "4" Then
                EstimatePrintingSetting.GroupingOptionGroupOption = "HT"
            ElseIf Me.GroupingOptionGroupOption = "5" Then
                EstimatePrintingSetting.GroupingOptionGroupOption = "I"
            ElseIf Me.GroupingOptionGroupOption = "6" Then
                EstimatePrintingSetting.GroupingOptionGroupOption = "P"
            Else
                EstimatePrintingSetting.GroupingOptionGroupOption = "N"
            End If
            If Me.GroupingOptionGroupOption = "1" Then
                EstimatePrintingSetting.GroupingOptionGroupOption = "C"
            ElseIf Me.GroupingOptionGroupOption = "2" Then
                EstimatePrintingSetting.GroupingOptionGroupOption = "O"
            Else
                EstimatePrintingSetting.GroupingOptionGroupOption = "C"
            End If
            EstimatePrintingSetting.GroupingOptionInsideDescription = Me.GroupingOptionInsideDescription
            EstimatePrintingSetting.GroupingOptionOutsideDescription = Me.GroupingOptionOutsideDescription
            EstimatePrintingSetting.IncludeEstimateComment = Me.IncludeEstimateComment
            EstimatePrintingSetting.IncludeEstimateComponentComment = Me.IncludeEstimateComponentComment
            EstimatePrintingSetting.IncludeEstimateQuoteComment = Me.IncludeEstimateQuoteComment
            EstimatePrintingSetting.IncludeEstimateRevisionComment = Me.IncludeEstimateRevisionComment
            EstimatePrintingSetting.IncludeEstimateFunctionComment = Me.IncludeEstimateFunctionComment
            EstimatePrintingSetting.DefaultFooterComment = Me.DefaultFooterComment
            EstimatePrintingSetting.IncludeClientReference = Me.IncludeClientReference
            EstimatePrintingSetting.IncludeAccountExecutive = Me.IncludeAccountExecutive
            EstimatePrintingSetting.IncludeSalesClass = Me.IncludeSalesClass
            EstimatePrintingSetting.IncludeSpecifications = Me.IncludeSpecifications
            EstimatePrintingSetting.IncludeJobQuantity = Me.IncludeJobQuantity
            EstimatePrintingSetting.TotalsIncludeContingency = Me.TotalsIncludeContingency
            EstimatePrintingSetting.SuppressZeroFunctions = Me.SuppressZeroFunctions
            EstimatePrintingSetting.LocationCode = Me.LocationCode
            EstimatePrintingSetting.LogoPath = Me.LogoPath
            If Me.ReportFormat = 1 Then
                EstimatePrintingSetting.ReportFormat = "001"
            ElseIf Me.ReportFormat = 2 Then
                EstimatePrintingSetting.ReportFormat = "002"
            ElseIf Me.ReportFormat = 3 Then
                EstimatePrintingSetting.ReportFormat = "003"
            ElseIf Me.ReportFormat = 4 Then
                EstimatePrintingSetting.ReportFormat = "004"
            ElseIf Me.ReportFormat = 5 Then
                EstimatePrintingSetting.ReportFormat = "005"
            ElseIf Me.ReportFormat = 6 Then
                EstimatePrintingSetting.ReportFormat = "006"
            ElseIf Me.ReportFormat = 7 Then
                EstimatePrintingSetting.ReportFormat = "007"
            ElseIf Me.ReportFormat = 8 Then
                EstimatePrintingSetting.ReportFormat = "008"
            ElseIf Me.ReportFormat = 9 Then
                EstimatePrintingSetting.ReportFormat = "009"
            ElseIf Me.ReportFormat = 10 Then
                EstimatePrintingSetting.ReportFormat = "300"
            ElseIf Me.ReportFormat = 11 Then
                EstimatePrintingSetting.ReportFormat = "301"
            ElseIf Me.ReportFormat = 12 Then
                EstimatePrintingSetting.ReportFormat = "302"
            ElseIf Me.ReportFormat = 13 Then
                EstimatePrintingSetting.ReportFormat = "303"
            ElseIf Me.ReportFormat = 14 Then
                EstimatePrintingSetting.ReportFormat = "304"
            ElseIf Me.ReportFormat = 15 Then
                EstimatePrintingSetting.ReportFormat = "305"
            ElseIf Me.ReportFormat = 16 Then
                EstimatePrintingSetting.ReportFormat = "306"
            ElseIf Me.ReportFormat = 17 Then
                EstimatePrintingSetting.ReportFormat = "307"
            ElseIf Me.ReportFormat = 18 Then
                EstimatePrintingSetting.ReportFormat = "308"
            ElseIf Me.ReportFormat = 19 Then
                EstimatePrintingSetting.ReportFormat = "309"
            ElseIf Me.ReportFormat = 20 Then
                EstimatePrintingSetting.ReportFormat = "310"
            ElseIf Me.ReportFormat = 21 Then
                EstimatePrintingSetting.ReportFormat = "311"
            ElseIf Me.ReportFormat = 22 Then
                EstimatePrintingSetting.ReportFormat = "312"
            ElseIf Me.ReportFormat = 23 Then
                EstimatePrintingSetting.ReportFormat = "313"
            ElseIf Me.ReportFormat = 24 Then
                EstimatePrintingSetting.ReportFormat = "314"
            End If
            'EstimatePrintingSetting.ReportFormat = Me.ReportFormat
            EstimatePrintingSetting.IncludeNonBillable = Me.IncludeNonBillable
            EstimatePrintingSetting.PrintDivisionName = Me.PrintDivisionName
            EstimatePrintingSetting.PrintProductDescription = Me.PrintProductDescription
            EstimatePrintingSetting.IncludeQuantityHours = Me.IncludeQuantityHours
            EstimatePrintingSetting.ConsolidationOverride = Me.ConsolidationOverride
            EstimatePrintingSetting.SubtotalsOnly = Me.SubtotalsOnly
            EstimatePrintingSetting.IncludeCPU = Me.IncludeCPU
            EstimatePrintingSetting.IncludeCPM = Me.IncludeCPM
            EstimatePrintingSetting.ReportTitle = Me.ReportTitle
            EstimatePrintingSetting.IncludeSuppliedByNotes = Me.IncludeSuppliedByNotes
            EstimatePrintingSetting.TotalsShowContingencySeparately = Me.TotalsShowContingencySeparately
            EstimatePrintingSetting.Signature = Me.Signature
            EstimatePrintingSetting.HideComponentDescription = Me.HideComponentDescription
            EstimatePrintingSetting.HideRevision = Me.HideRevision
            EstimatePrintingSetting.IncludeJobDueDate = Me.IncludeJobDueDate
            EstimatePrintingSetting.UseEmployeeSignature = Me.UseEmployeeSignature
            EstimatePrintingSetting.ExcludeEmployeeTime = Me.ExcludeEmployeeTime
            EstimatePrintingSetting.ExcludeVendor = Me.ExcludeVendor
            EstimatePrintingSetting.ExcludeIncomeOnly = Me.ExcludeIncomeOnly
            EstimatePrintingSetting.ExcludeSignatures = Me.ExcludeSignatures
            EstimatePrintingSetting.IncludeCampaignSummary = Me.IncludeCampaignSummary
            EstimatePrintingSetting.IncludeVendorDescription = Me.IncludeVendorDescription
            EstimatePrintingSetting.ExcludeNonbillable = Me.ExcludeNonbillable
            If Me.CDPAddressOption = "1" Then
                EstimatePrintingSetting.CDPAddressOption = "Client"
            ElseIf Me.CDPAddressOption = "2" Then
                EstimatePrintingSetting.CDPAddressOption = "Division"
            ElseIf Me.CDPAddressOption = "3" Then
                EstimatePrintingSetting.CDPAddressOption = "Product"
            ElseIf Me.CDPAddressOption = "4" Then
                EstimatePrintingSetting.CDPAddressOption = "Contact"
            Else
                EstimatePrintingSetting.CDPAddressOption = "Client"
            End If
            EstimatePrintingSetting.IncludeRate = Me.IncludeRate
            EstimatePrintingSetting.CombineComponents = Me.CombineComponents
            EstimatePrintingSetting.PrintClientName = Me.PrintClientName
            EstimatePrintingSetting.IncludeFunctionComment = Me.IncludeFunctionComment
            EstimatePrintingSetting.PrintAdNumber = Me.PrintAdNumber

        End Sub
        Public Sub Save(ByVal EstimatePrintingSetting As AdvantageFramework.Database.Entities.EstimatePrintSetting)

            EstimatePrintingSetting.UserID = Me.UserID
            EstimatePrintingSetting.DateToPrint = If(Me.DateToPrint = True, 2, 1)
            EstimatePrintingSetting.ShowTaxSeparately = Convert.ToInt64(Me.TotalsShowTaxSeparately)
            EstimatePrintingSetting.IndicateTaxableFunctions = Convert.ToInt64(Me.IndicateTaxableFunctions)
            EstimatePrintingSetting.ShowCommissionSeparately = Convert.ToInt64(Me.TotalsShowCommissionSeparately)
            EstimatePrintingSetting.IndicateCommissionFunctions = Convert.ToInt64(Me.IndicateCommissionFunctions)
            If Me.GroupingOptionFunctionOption = "1" Then
                EstimatePrintingSetting.FunctionOption = "F"
            ElseIf Me.GroupingOptionFunctionOption = "2" Then
                EstimatePrintingSetting.FunctionOption = "C"
            ElseIf Me.GroupingOptionFunctionOption = "3" Then
                EstimatePrintingSetting.FunctionOption = "T"
            ElseIf Me.GroupingOptionFunctionOption = "4" Then
                EstimatePrintingSetting.FunctionOption = "R"
            ElseIf Me.GroupingOptionFunctionOption = "5" Then
                EstimatePrintingSetting.FunctionOption = "N"
            Else
                EstimatePrintingSetting.FunctionOption = "F"
            End If
            If Me.GroupingOptionGroupOption = "1" Then
                EstimatePrintingSetting.GroupOption = "N"
            ElseIf Me.GroupingOptionGroupOption = "2" Then
                EstimatePrintingSetting.GroupOption = "T"
            ElseIf Me.GroupingOptionGroupOption = "3" Then
                EstimatePrintingSetting.GroupOption = "H"
            ElseIf Me.GroupingOptionGroupOption = "4" Then
                EstimatePrintingSetting.GroupOption = "HT"
            ElseIf Me.GroupingOptionGroupOption = "5" Then
                EstimatePrintingSetting.GroupOption = "I"
            ElseIf Me.GroupingOptionGroupOption = "6" Then
                EstimatePrintingSetting.GroupOption = "P"
            Else
                EstimatePrintingSetting.GroupOption = "N"
            End If
            If Me.GroupingOptionGroupOption = "1" Then
                EstimatePrintingSetting.SortOption = "C"
            ElseIf Me.GroupingOptionGroupOption = "2" Then
                EstimatePrintingSetting.SortOption = "O"
            Else
                EstimatePrintingSetting.SortOption = "C"
            End If
            EstimatePrintingSetting.InsideDescription = Me.GroupingOptionInsideDescription
            EstimatePrintingSetting.OutsideDescription = Me.GroupingOptionOutsideDescription
            EstimatePrintingSetting.IncludeEstimateComment = Convert.ToInt64(Me.IncludeEstimateComment)
            EstimatePrintingSetting.IncludeEstimateComponentComment = Convert.ToInt64(Me.IncludeEstimateComponentComment)
            EstimatePrintingSetting.IncludeEstimateQuoteComment = Convert.ToInt64(Me.IncludeEstimateQuoteComment)
            EstimatePrintingSetting.IncludeEstimateRevisionComment = Convert.ToInt64(Me.IncludeEstimateRevisionComment)
            EstimatePrintingSetting.IncludeEstimateFunctionComment = Convert.ToInt64(Me.IncludeEstimateFunctionComment)
            EstimatePrintingSetting.DefaultFooterComment = Convert.ToInt64(Me.DefaultFooterComment)
            EstimatePrintingSetting.IncludeClientReference = Convert.ToInt64(Me.IncludeClientReference)
            EstimatePrintingSetting.IncludeAccountExecutive = Convert.ToInt64(Me.IncludeAccountExecutive)
            EstimatePrintingSetting.IncludeSalesClass = Convert.ToInt64(Me.IncludeSalesClass)
            EstimatePrintingSetting.IncludeSpecifications = Convert.ToInt64(Me.IncludeSpecifications)
            EstimatePrintingSetting.IncludeJobQuantity = Convert.ToInt64(Me.IncludeJobQuantity)
            EstimatePrintingSetting.IncludeContingency = Convert.ToInt64(Me.TotalsIncludeContingency)
            EstimatePrintingSetting.SuppressZeroFunctions = Convert.ToInt64(Me.SuppressZeroFunctions)
            EstimatePrintingSetting.LocationCode = Me.LocationCode
            EstimatePrintingSetting.LogoPath = Me.LogoPath
            If Me.ReportFormat = 1 Then
                EstimatePrintingSetting.ReportFormat = "001"
            ElseIf Me.ReportFormat = 2 Then
                EstimatePrintingSetting.ReportFormat = "002"
            ElseIf Me.ReportFormat = 3 Then
                EstimatePrintingSetting.ReportFormat = "003"
            ElseIf Me.ReportFormat = 4 Then
                EstimatePrintingSetting.ReportFormat = "004"
            ElseIf Me.ReportFormat = 5 Then
                EstimatePrintingSetting.ReportFormat = "005"
            ElseIf Me.ReportFormat = 6 Then
                EstimatePrintingSetting.ReportFormat = "006"
            ElseIf Me.ReportFormat = 7 Then
                EstimatePrintingSetting.ReportFormat = "007"
            ElseIf Me.ReportFormat = 8 Then
                EstimatePrintingSetting.ReportFormat = "008"
            ElseIf Me.ReportFormat = 9 Then
                EstimatePrintingSetting.ReportFormat = "009"
            ElseIf Me.ReportFormat = 10 Then
                EstimatePrintingSetting.ReportFormat = "300"
            ElseIf Me.ReportFormat = 11 Then
                EstimatePrintingSetting.ReportFormat = "301"
            ElseIf Me.ReportFormat = 12 Then
                EstimatePrintingSetting.ReportFormat = "302"
            ElseIf Me.ReportFormat = 13 Then
                EstimatePrintingSetting.ReportFormat = "303"
            ElseIf Me.ReportFormat = 14 Then
                EstimatePrintingSetting.ReportFormat = "304"
            ElseIf Me.ReportFormat = 15 Then
                EstimatePrintingSetting.ReportFormat = "305"
            ElseIf Me.ReportFormat = 16 Then
                EstimatePrintingSetting.ReportFormat = "306"
            ElseIf Me.ReportFormat = 17 Then
                EstimatePrintingSetting.ReportFormat = "307"
            ElseIf Me.ReportFormat = 18 Then
                EstimatePrintingSetting.ReportFormat = "308"
            ElseIf Me.ReportFormat = 19 Then
                EstimatePrintingSetting.ReportFormat = "309"
            ElseIf Me.ReportFormat = 20 Then
                EstimatePrintingSetting.ReportFormat = "310"
            ElseIf Me.ReportFormat = 21 Then
                EstimatePrintingSetting.ReportFormat = "311"
            ElseIf Me.ReportFormat = 22 Then
                EstimatePrintingSetting.ReportFormat = "312"
            ElseIf Me.ReportFormat = 23 Then
                EstimatePrintingSetting.ReportFormat = "313"
            ElseIf Me.ReportFormat = 24 Then
                EstimatePrintingSetting.ReportFormat = "314"
            End If
            'EstimatePrintingSetting.ReportFormat = Me.ReportFormat
            EstimatePrintingSetting.IncludeNonBillable = Convert.ToInt64(Me.IncludeNonBillable)
            EstimatePrintingSetting.PrintDivisionName = Convert.ToInt64(Me.PrintDivisionName)
            EstimatePrintingSetting.PrintProductDescription = Convert.ToInt64(Me.PrintProductDescription)
            EstimatePrintingSetting.IncludeQuantityHours = Convert.ToInt64(Me.IncludeQuantityHours)
            EstimatePrintingSetting.ConsolidationOverride = Convert.ToInt64(Me.ConsolidationOverride)
            EstimatePrintingSetting.SubtotalsOnly = Convert.ToInt64(Me.SubtotalsOnly)
            EstimatePrintingSetting.IncludeCPU = Convert.ToInt64(Me.IncludeCPU)
            EstimatePrintingSetting.IncludeCPM = Convert.ToInt64(Me.IncludeCPM)
            EstimatePrintingSetting.ReportTitle = Me.ReportTitle
            EstimatePrintingSetting.IncludeSuppliedByNotes = Convert.ToInt64(Me.IncludeSuppliedByNotes)
            EstimatePrintingSetting.ShowContingencySeparately = Convert.ToInt64(Me.TotalsShowContingencySeparately)
            EstimatePrintingSetting.Signature = Convert.ToInt64(Me.Signature)
            EstimatePrintingSetting.HideComponentDescription = Convert.ToInt64(Me.HideComponentDescription)
            EstimatePrintingSetting.HideRevision = Convert.ToInt64(Me.HideRevision)
            EstimatePrintingSetting.IncludeJobDueDate = Convert.ToInt64(Me.IncludeJobDueDate)
            EstimatePrintingSetting.UseEmployeeSignature = Convert.ToInt64(Me.UseEmployeeSignature)
            EstimatePrintingSetting.ExcludeEmployeeTime = Convert.ToInt64(Me.ExcludeEmployeeTime)
            EstimatePrintingSetting.ExcludeVendor = Convert.ToInt64(Me.ExcludeVendor)
            EstimatePrintingSetting.ExcludeIncomeOnly = Convert.ToInt64(Me.ExcludeIncomeOnly)
            EstimatePrintingSetting.ExcludeSignatures = Convert.ToInt32(Me.ExcludeSignatures)
            EstimatePrintingSetting.IncludeCampaignSummary = Convert.ToInt32(Me.IncludeCampaignSummary)
            EstimatePrintingSetting.IncludeVendorDescription = Convert.ToInt32(Me.IncludeVendorDescription)
            EstimatePrintingSetting.ExcludeNonbillable = Convert.ToInt64(Me.ExcludeNonbillable)
            If Me.CDPAddressOption = "1" Then
                EstimatePrintingSetting.CDPAddressOption = "Client"
            ElseIf Me.CDPAddressOption = "2" Then
                EstimatePrintingSetting.CDPAddressOption = "Division"
            ElseIf Me.CDPAddressOption = "3" Then
                EstimatePrintingSetting.CDPAddressOption = "Product"
            ElseIf Me.CDPAddressOption = "4" Then
                EstimatePrintingSetting.CDPAddressOption = "Contact"
            Else
                EstimatePrintingSetting.CDPAddressOption = "Client"
            End If
            EstimatePrintingSetting.IncludeRate = Convert.ToInt64(Me.IncludeRate)
            EstimatePrintingSetting.CombineComponents = Convert.ToInt64(Me.CombineComponents)
            EstimatePrintingSetting.PrintClientName = Convert.ToInt64(Me.PrintClientName)
            EstimatePrintingSetting.IncludeFunctionComment = Convert.ToInt64(Me.IncludeFunctionComment)
            EstimatePrintingSetting.PrintAdNumber = Convert.ToInt64(Me.PrintAdNumber)

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.UserID.ToString

        End Function

#End Region


    End Class

End Namespace
