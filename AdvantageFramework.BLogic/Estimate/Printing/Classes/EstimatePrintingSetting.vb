Namespace Estimate.Printing.Classes

    <Serializable()>
    Public Class EstimatePrintingSetting

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            IsOneTime
            Type
            UserID
            ClientCode
            DivisionCode
            ProductCode
            CDP
            SelectBy
            DateToPrint
            DatePrint
            UseLocationOptions
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
            HideJobDescription
            HideComponentDescription
            HideRevision
            IncludeEstimateComment
            IncludeEstimateComponentComment
            IncludeEstimateQuoteComment
            IncludeEstimateRevisionComment
            IncludeEstimateFunctionComment
            IncludeSuppliedByNotes
            ReportFormat
            SummaryLevel
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
            UseEmployeeSignature
            IncludeCampaignSummary
            IncludeVendorDescription
            IncludeFunctionComment
            PrintAdNumber
            CustomEstimateID
            ShowCodes
            ContactType
            PrintContactAfterAddress
            UseAgencySetting
            FileFormat
            PrintQuantityTotals
            ShowWatermark
            DisplayQuantity
            DisplayHours
            IncludeRateMarkup
            ExcludeDateFromSignature
        End Enum

#End Region

#Region " Variables "

        Private _ID As Integer = 0
        Private _IsOneTime As Nullable(Of Boolean) = Nothing
        Private _Type As Nullable(Of Short) = Nothing
        Private _UserID As String = ""
        Private _ClientCode As String = ""
        Private _DivisionCode As String = ""
        Private _ProductCode As String = ""
        Private _CDP As String = ""
        Private _SelectBy As String = ""
        Private _DateToPrint As Boolean = False
        Private _DatePrint As Date = Nothing
        Private _UseLocationOptions As Boolean = False
        Private _LogoPath As String = Nothing
        Private _LocationCode As String = ""
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
        Private _HideJobDescription As Boolean = False
        Private _HideComponentDescription As Boolean = False
        Private _HideRevision As Boolean = False
        Private _IncludeEstimateComment As Boolean = False
        Private _IncludeEstimateComponentComment As Boolean = False
        Private _IncludeEstimateQuoteComment As Boolean = False
        Private _IncludeEstimateRevisionComment As Boolean = False
        Private _IncludeEstimateFunctionComment As Boolean = False
        Private _IncludeSuppliedByNotes As Boolean = False
        Private _ReportFormat As String = Nothing
        Private _SummaryLevel As Short = 0
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
        Private _UseEmployeeSignature As Boolean = False
        Private _IncludeCampaignSummary As Boolean = False
        Private _IncludeVendorDescription As Boolean = False
        Private _IncludeFunctionComment As Boolean = False
        Private _PrintAdNumber As Boolean = False
        Private _CustomEstimateID As Nullable(Of Integer) = Nothing
        Private _ShowCodes As Boolean = False
        Private _ContactType As Integer = 0
        Private _PrintContactAfterAddress As Boolean = False
        Private _UseAgencySetting As Nullable(Of Integer) = 0
        Private _FileFormat As Nullable(Of Short) = 0
        Private _PrintQuantityTotals As Boolean = False
        Private _ShowWatermark As Boolean = False
        Private _DisplayQuantity As Boolean = False
        Private _DisplayHours As Boolean = False
        Private _IncludeRateMarkup As Boolean = False
        Private _ExcludeDateFromSignature As Boolean = False

        Private _EstimatePrintingDefault As AdvantageFramework.Database.Entities.EstimatePrintingSetting = Nothing
        Private _EstimatePrintingSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.Browsable(False)> _
        Public Property ID() As Integer
            Get
                ID = _ID
            End Get
            Set(ByVal value As Integer)
                _ID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IsOneTime() As Nullable(Of Boolean)
            Get
                IsOneTime = _IsOneTime
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _IsOneTime = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Type() As Nullable(Of Short)
            Get
                Type = _Type
            End Get
            Set(ByVal value As Nullable(Of Short))
                _Type = value
            End Set
        End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DataAnnotations.MaxLength(100)>
		Public Property UserID() As String
			Get
				UserID = _UserID
			End Get
			Set(ByVal value As String)
				_UserID = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DataAnnotations.MaxLength(6)>
		Public Property ClientCode() As String
			Get
				ClientCode = _ClientCode
			End Get
			Set(ByVal value As String)
				_ClientCode = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DataAnnotations.MaxLength(6)>
		Public Property DivisionCode() As String
			Get
				DivisionCode = _DivisionCode
			End Get
			Set(ByVal value As String)
				_DivisionCode = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DataAnnotations.MaxLength(6)>
		Public Property ProductCode() As String
			Get
				ProductCode = _ProductCode
			End Get
			Set(ByVal value As String)
				_ProductCode = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.DataAnnotations.MaxLength(200)>
		Public Property CDP() As String
			Get
				CDP = _CDP
			End Get
			Set(ByVal value As String)
				_CDP = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.Browsable(False)>
		Public Property SelectBy() As String
			Get
				SelectBy = _SelectBy
			End Get
			Set(ByVal value As String)
				_SelectBy = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.Category("")>
		Public Property DateToPrint() As Boolean
			Get
				DateToPrint = _DateToPrint
			End Get
			Set(ByVal value As Boolean)
				_DateToPrint = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.Category("")>
		Public Property DatePrint() As Date
			Get
				DatePrint = _DatePrint
			End Get
			Set(ByVal value As Date)
				_DatePrint = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.Category("")>
		Public Property UseLocationOptions() As Boolean
			Get
				UseLocationOptions = _UseLocationOptions
			End Get
			Set(ByVal value As Boolean)
				_UseLocationOptions = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
		System.ComponentModel.Category("")>
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
		Public Property HideJobDescription() As Boolean
			Get
				HideJobDescription = _HideJobDescription
			End Get
			Set(ByVal value As Boolean)
				_HideJobDescription = value
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
        Public Property SummaryLevel() As Short
            Get
                SummaryLevel = _SummaryLevel
            End Get
            Set(ByVal value As Short)
                _SummaryLevel = value
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
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.DisplayName("Custom Estimate")> _
        Public Property CustomEstimateID() As Nullable(Of Integer)
            Get
                CustomEstimateID = _CustomEstimateID
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _CustomEstimateID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.DisplayName("Show Codes")> _
        Public Property ShowCodes() As Boolean
            Get
                ShowCodes = _ShowCodes
            End Get
            Set(ByVal value As Boolean)
                _ShowCodes = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
        System.ComponentModel.DisplayName("Contact Type")>
        Public Property ContactType() As Integer
            Get
                ContactType = _ContactType
            End Get
            Set(ByVal value As Integer)
                _ContactType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""), _
        System.ComponentModel.DisplayName("Print Contact After Address")> _
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
        System.ComponentModel.DisplayName("Setting Type")>
        Public Property UseAgencySetting() As Nullable(Of Integer)
            Get
                UseAgencySetting = _UseAgencySetting
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _UseAgencySetting = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
        System.ComponentModel.DisplayName("File Format")>
        Public Property FileFormat() As Nullable(Of Short)
            Get
                FileFormat = _FileFormat
            End Get
            Set(ByVal value As Nullable(Of Short))
                _FileFormat = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
        System.ComponentModel.DisplayName("Print Quantity Totals")>
        Public Property PrintQuantityTotals() As Boolean
            Get
                PrintQuantityTotals = _PrintQuantityTotals
            End Get
            Set(ByVal value As Boolean)
                _PrintQuantityTotals = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
        System.ComponentModel.DisplayName("Show Watermark")>
        Public Property ShowWatermark() As Boolean
            Get
                ShowWatermark = _ShowWatermark
            End Get
            Set(ByVal value As Boolean)
                _ShowWatermark = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
        System.ComponentModel.DisplayName("Display Quantity")>
        Public Property DisplayQuantity() As Boolean
            Get
                DisplayQuantity = _DisplayQuantity
            End Get
            Set(ByVal value As Boolean)
                _DisplayQuantity = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
        System.ComponentModel.DisplayName("Display Hours")>
        Public Property DisplayHours() As Boolean
            Get
                DisplayHours = _DisplayHours
            End Get
            Set(ByVal value As Boolean)
                _DisplayHours = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
        System.ComponentModel.DisplayName("Include Rate w/Markup")>
        Public Property IncludeRateMarkup() As Boolean
            Get
                IncludeRateMarkup = _IncludeRateMarkup
            End Get
            Set(ByVal value As Boolean)
                _IncludeRateMarkup = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:=""),
        System.ComponentModel.DisplayName("Exclude Date from Signatures")>
        Public Property ExcludeDateFromSignature() As Boolean
            Get
                ExcludeDateFromSignature = _ExcludeDateFromSignature
            End Get
            Set(ByVal value As Boolean)
                _ExcludeDateFromSignature = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()
            Me.Type = 0
            Me.UserID = ""
            Me.ClientCode = ""
            Me.DivisionCode = ""
            Me.ProductCode = ""
            Me.CDP = ""
            Me.SelectBy = ""
            Me.DateToPrint = 1
            Me.TotalsShowTaxSeparately = False
            Me.IndicateTaxableFunctions = False
            Me.TotalsShowCommissionSeparately = False
            Me.IndicateCommissionFunctions = False
            Me.GroupingOptionFunctionOption = "2"
            Me.GroupingOptionGroupOption = "1"
            Me.GroupingOptionSortOption = "1"
            Me.GroupingOptionInsideDescription = ""
            Me.GroupingOptionOutsideDescription = ""
            Me.IncludeEstimateComment = False
            Me.IncludeEstimateComponentComment = False
            Me.IncludeEstimateQuoteComment = False
            Me.IncludeEstimateRevisionComment = False
            Me.IncludeEstimateFunctionComment = False
            Me.DefaultFooterComment = False
            Me.IncludeClientReference = False
            Me.IncludeAccountExecutive = False
            Me.IncludeSalesClass = False
            Me.IncludeJobQuantity = False
            Me.TotalsIncludeContingency = False
            Me.SuppressZeroFunctions = True
            Me.UseLocationOptions = True
            Me.LocationCode = ""
            Me.LogoPath = ""
            Me.ReportFormat = 1
            Me.IncludeNonBillable = False
            Me.PrintClientName = True
            Me.PrintDivisionName = False
            Me.PrintProductDescription = False
            Me.IncludeQuantityHours = False
            Me.ConsolidationOverride = True
            Me.SubtotalsOnly = False
            Me.IncludeCPU = False
            Me.IncludeCPM = False
            Me.ReportTitle = "Estimate Report"
            Me.IncludeSuppliedByNotes = False
            Me.TotalsShowContingencySeparately = False
            Me.Signature = 1
            Me.HideJobDescription = False
            Me.HideComponentDescription = False
            Me.HideRevision = False
            Me.IncludeJobDueDate = False
            Me.UseEmployeeSignature = True
            Me.ExcludeEmployeeTime = False
            Me.ExcludeVendor = False
            Me.ExcludeIncomeOnly = False
            Me.ExcludeSignatures = False
            Me.IncludeCampaignSummary = False
            Me.IncludeVendorDescription = False
            Me.ExcludeNonbillable = False
            Me.CDPAddressOption = "1"
            Me.IncludeRate = False
            Me.SummaryLevel = 0
            Me.IncludeFunctionComment = False
            Me.PrintAdNumber = False
            Me.CustomEstimateID = 0
            Me.ShowCodes = False
            Me.ContactType = 1
            Me.PrintContactAfterAddress = False
            Me.UseAgencySetting = 0
            Me.FileFormat = 1
            Me.PrintQuantityTotals = False
            Me.ShowWatermark = False
            Me.DisplayQuantity = False
            Me.DisplayHours = False
            Me.IncludeRateMarkup = False
            Me.ExcludeDateFromSignature = False

        End Sub
        Public Sub New(ByVal EstimatePrintingDefault As AdvantageFramework.Database.Entities.EstimatePrintingSetting)

            Me.ID = EstimatePrintingDefault.ID
            Me.Type = EstimatePrintingDefault.ClientOrDefault
            Me.UserID = EstimatePrintingDefault.UserID
            Me.ClientCode = EstimatePrintingDefault.ClientCode
            Me.DivisionCode = EstimatePrintingDefault.DivisionCode
            Me.ProductCode = EstimatePrintingDefault.ProductCode
            Me.CDP = EstimatePrintingDefault.ClientCode & "|" & EstimatePrintingDefault.DivisionCode & "|" & EstimatePrintingDefault.ProductCode
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
            Me.IncludeJobQuantity = Convert.ToBoolean(EstimatePrintingDefault.IncludeJobQuantity.GetValueOrDefault(0))
            Me.TotalsIncludeContingency = Convert.ToBoolean(EstimatePrintingDefault.IncludeContingency.GetValueOrDefault(0))
            Me.SuppressZeroFunctions = Convert.ToBoolean(EstimatePrintingDefault.SuppressZeroFunctions.GetValueOrDefault(0))
            Me.UseLocationOptions = Convert.ToBoolean(EstimatePrintingDefault.UseLocationOptions.GetValueOrDefault(0))
            Me.LocationCode = EstimatePrintingDefault.LocationCode
            Me.LogoPath = EstimatePrintingDefault.LogoPath
            Me.ReportFormat = EstimatePrintingDefault.ReportFormat
            Me.IncludeNonBillable = Convert.ToBoolean(EstimatePrintingDefault.IncludeNonBillable.GetValueOrDefault(0))
            Me.PrintClientName = Convert.ToBoolean(EstimatePrintingDefault.PrintClientName.GetValueOrDefault(0))
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
            Me.HideJobDescription = Convert.ToBoolean(EstimatePrintingDefault.HideJobDescription.GetValueOrDefault(0))
            Me.HideComponentDescription = Convert.ToBoolean(EstimatePrintingDefault.HideComponentDescription.GetValueOrDefault(0))
            Me.HideRevision = Convert.ToBoolean(EstimatePrintingDefault.HideRevision.GetValueOrDefault(0))
            Me.IncludeJobDueDate = Convert.ToBoolean(EstimatePrintingDefault.IncludeJobDueDate.GetValueOrDefault(0))
            Me.UseEmployeeSignature = Convert.ToBoolean(EstimatePrintingDefault.UseEmployeeSignature.GetValueOrDefault(0))
            Me.ExcludeEmployeeTime = Convert.ToBoolean(EstimatePrintingDefault.ExcludeEmployeeTime.GetValueOrDefault(0))
            Me.ExcludeVendor = Convert.ToBoolean(EstimatePrintingDefault.ExcludeVendor.GetValueOrDefault(0))
            Me.ExcludeIncomeOnly = Convert.ToBoolean(EstimatePrintingDefault.ExcludeIncomeOnly.GetValueOrDefault(0))
            Me.ExcludeSignatures = Convert.ToBoolean(EstimatePrintingDefault.ExcludeSignatures.GetValueOrDefault(0))
            Me.IncludeCampaignSummary = Convert.ToBoolean(EstimatePrintingDefault.IncludeCampaignSummary.GetValueOrDefault(0))
            Me.IncludeVendorDescription = Convert.ToBoolean(EstimatePrintingDefault.IncludeVendorDescription.GetValueOrDefault(0))
            Me.ExcludeNonbillable = Convert.ToBoolean(EstimatePrintingDefault.ExcludeNonbillable.GetValueOrDefault(0))
            Me.CDPAddressOption = EstimatePrintingDefault.CDPAddressOption
            Me.IncludeRate = Convert.ToBoolean(EstimatePrintingDefault.IncludeRate.GetValueOrDefault(0))
            Me.SummaryLevel = EstimatePrintingDefault.SummaryLevel
            Me.IncludeFunctionComment = Convert.ToBoolean(EstimatePrintingDefault.IncludeFunctionComment.GetValueOrDefault(0))
            Me.PrintAdNumber = Convert.ToBoolean(EstimatePrintingDefault.PrintAdNumber.GetValueOrDefault(0))
            Me.CustomEstimateID = EstimatePrintingDefault.CustomEstimateID
            Me.ShowCodes = Convert.ToBoolean(EstimatePrintingDefault.ShowCodes.GetValueOrDefault(0))
            Me.ContactType = EstimatePrintingDefault.ContactType.GetValueOrDefault(0)
            Me.PrintContactAfterAddress = Convert.ToBoolean(EstimatePrintingDefault.PrintContactAfterAddress.GetValueOrDefault(0))
            Me.UseAgencySetting = EstimatePrintingDefault.UseAgencySetting
            Me.FileFormat = EstimatePrintingDefault.FileFormat
            Me.PrintQuantityTotals = Convert.ToBoolean(EstimatePrintingDefault.PrintQuantityTotals.GetValueOrDefault(0))
            Me.ShowWatermark = Convert.ToBoolean(EstimatePrintingDefault.ShowWatermark.GetValueOrDefault(0))
            Me.DisplayQuantity = Convert.ToBoolean(EstimatePrintingDefault.DisplayQuantity.GetValueOrDefault(0))
            Me.DisplayHours = Convert.ToBoolean(EstimatePrintingDefault.DisplayHours.GetValueOrDefault(0))
            Me.IncludeRateMarkup = Convert.ToBoolean(EstimatePrintingDefault.IncludeRateMarkup.GetValueOrDefault(0))
            Me.ExcludeDateFromSignature = Convert.ToBoolean(EstimatePrintingDefault.ExcludeDateFromSignature.GetValueOrDefault(0))

            _EstimatePrintingDefault = EstimatePrintingDefault

        End Sub
        Public Sub New(ByVal EstimatePrintingSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting)

            Me.ID = EstimatePrintingSetting.ID
            Me.Type = EstimatePrintingSetting.Type
            Me.UserID = EstimatePrintingSetting.UserID
            Me.ClientCode = EstimatePrintingSetting.ClientCode
            Me.DivisionCode = EstimatePrintingSetting.DivisionCode
            Me.ProductCode = EstimatePrintingSetting.ProductCode
            Me.CDP = EstimatePrintingSetting.CDP
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
            Me.IncludeJobQuantity = EstimatePrintingSetting.IncludeJobQuantity
            Me.TotalsIncludeContingency = EstimatePrintingSetting.TotalsIncludeContingency
            Me.SuppressZeroFunctions = EstimatePrintingSetting.SuppressZeroFunctions
            Me.UseLocationOptions = EstimatePrintingSetting.UseLocationOptions
            Me.LocationCode = EstimatePrintingSetting.LocationCode
            Me.LogoPath = EstimatePrintingSetting.LogoPath
            Me.ReportFormat = EstimatePrintingSetting.ReportFormat
            Me.IncludeNonBillable = EstimatePrintingSetting.IncludeNonBillable
            Me.PrintClientName = EstimatePrintingSetting.PrintClientName
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
            Me.HideJobDescription = EstimatePrintingSetting.HideJobDescription
            Me.HideComponentDescription = EstimatePrintingSetting.HideComponentDescription
            Me.HideRevision = EstimatePrintingSetting.HideRevision
            Me.IncludeJobDueDate = EstimatePrintingSetting.IncludeJobDueDate
            Me.UseEmployeeSignature = EstimatePrintingSetting.UseEmployeeSignature
            Me.ExcludeEmployeeTime = EstimatePrintingSetting.ExcludeEmployeeTime
            Me.ExcludeVendor = EstimatePrintingSetting.ExcludeVendor
            Me.ExcludeIncomeOnly = EstimatePrintingSetting.ExcludeIncomeOnly
            Me.ExcludeSignatures = EstimatePrintingSetting.ExcludeSignatures
            Me.IncludeCampaignSummary = EstimatePrintingSetting.IncludeCampaignSummary
            Me.IncludeVendorDescription = EstimatePrintingSetting.IncludeVendorDescription
            Me.ExcludeNonbillable = EstimatePrintingSetting.ExcludeNonbillable
            Me.CDPAddressOption = EstimatePrintingSetting.CDPAddressOption
            Me.IncludeRate = EstimatePrintingSetting.IncludeRate
            Me.SummaryLevel = EstimatePrintingSetting.SummaryLevel
            Me.IncludeFunctionComment = EstimatePrintingSetting.IncludeFunctionComment
            Me.PrintAdNumber = EstimatePrintingSetting.PrintAdNumber
            Me.CustomEstimateID = EstimatePrintingSetting.CustomEstimateID
            Me.ShowCodes = EstimatePrintingSetting.ShowCodes
            Me.ContactType = EstimatePrintingSetting.ContactType
            Me.PrintContactAfterAddress = EstimatePrintingSetting.PrintContactAfterAddress
            Me.UseAgencySetting = EstimatePrintingSetting.UseAgencySetting
            Me.FileFormat = EstimatePrintingSetting.FileFormat
            Me.PrintQuantityTotals = EstimatePrintingSetting.PrintQuantityTotals
            Me.ShowWatermark = EstimatePrintingSetting.ShowWatermark
            Me.DisplayQuantity = EstimatePrintingSetting.DisplayQuantity
            Me.DisplayHours = EstimatePrintingSetting.DisplayHours
            Me.IncludeRateMarkup = EstimatePrintingSetting.IncludeRateMarkup
            Me.ExcludeDateFromSignature = EstimatePrintingSetting.ExcludeDateFromSignature

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
        Public Sub Save(ByVal EstimatePrintingSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting)

            'EstimatePrintingSetting.Type = Me.Type
            'EstimatePrintingSetting.ClientCode = Me.ClientCode
            'EstimatePrintingSetting.DivisionCode = Me.DivisionCode
            'EstimatePrintingSetting.ProductCode = Me.ProductCode
            EstimatePrintingSetting.DateToPrint = Me.DateToPrint
            EstimatePrintingSetting.DatePrint = Me.DatePrint
            EstimatePrintingSetting.TotalsShowTaxSeparately = Me.TotalsShowTaxSeparately
            EstimatePrintingSetting.IndicateTaxableFunctions = Me.IndicateTaxableFunctions
            EstimatePrintingSetting.TotalsShowCommissionSeparately = Me.TotalsShowCommissionSeparately
            EstimatePrintingSetting.IndicateCommissionFunctions = Me.IndicateCommissionFunctions
            EstimatePrintingSetting.GroupingOptionFunctionOption = Me.GroupingOptionFunctionOption
            EstimatePrintingSetting.GroupingOptionGroupOption = Me.GroupingOptionGroupOption
            EstimatePrintingSetting.GroupingOptionSortOption = Me.GroupingOptionSortOption
            'If Me.GroupingOptionFunctionOption = "1" Then
            '    EstimatePrintingSetting.GroupingOptionFunctionOption = "F"
            'ElseIf Me.GroupingOptionFunctionOption = "2" Then
            '    EstimatePrintingSetting.GroupingOptionFunctionOption = "C"
            'ElseIf Me.GroupingOptionFunctionOption = "3" Then
            '    EstimatePrintingSetting.GroupingOptionFunctionOption = "T"
            'ElseIf Me.GroupingOptionFunctionOption = "4" Then
            '    EstimatePrintingSetting.GroupingOptionFunctionOption = "R"
            'ElseIf Me.GroupingOptionFunctionOption = "5" Then
            '    EstimatePrintingSetting.GroupingOptionFunctionOption = "N"
            'Else
            '    EstimatePrintingSetting.GroupingOptionFunctionOption = "F"
            'End If
            'If Me.GroupingOptionGroupOption = "1" Then
            '    EstimatePrintingSetting.GroupingOptionGroupOption = "N"
            'ElseIf Me.GroupingOptionGroupOption = "2" Then
            '    EstimatePrintingSetting.GroupingOptionGroupOption = "T"
            'ElseIf Me.GroupingOptionGroupOption = "3" Then
            '    EstimatePrintingSetting.GroupingOptionGroupOption = "H"
            'ElseIf Me.GroupingOptionGroupOption = "4" Then
            '    EstimatePrintingSetting.GroupingOptionGroupOption = "HT"
            'ElseIf Me.GroupingOptionGroupOption = "5" Then
            '    EstimatePrintingSetting.GroupingOptionGroupOption = "I"
            'ElseIf Me.GroupingOptionGroupOption = "6" Then
            '    EstimatePrintingSetting.GroupingOptionGroupOption = "P"
            'Else
            '    EstimatePrintingSetting.GroupingOptionGroupOption = "N"
            'End If
            'If Me.GroupingOptionSortOption = "1" Then
            '    EstimatePrintingSetting.GroupingOptionSortOption = "C"
            'ElseIf Me.GroupingOptionGroupOption = "2" Then
            '    EstimatePrintingSetting.GroupingOptionSortOption = "O"
            'Else
            '    EstimatePrintingSetting.GroupingOptionSortOption = "C"
            'End If
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
            EstimatePrintingSetting.IncludeJobQuantity = Me.IncludeJobQuantity
            EstimatePrintingSetting.TotalsIncludeContingency = Me.TotalsIncludeContingency
            EstimatePrintingSetting.SuppressZeroFunctions = Me.SuppressZeroFunctions
            EstimatePrintingSetting.UseLocationOptions = Me.UseLocationOptions
            EstimatePrintingSetting.LocationCode = Me.LocationCode
            EstimatePrintingSetting.LogoPath = Me.LogoPath

            EstimatePrintingSetting.ReportFormat = Me.ReportFormat
            EstimatePrintingSetting.IncludeNonBillable = Me.IncludeNonBillable
            EstimatePrintingSetting.PrintClientName = Me.PrintClientName
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
            EstimatePrintingSetting.HideJobDescription = Me.HideJobDescription
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
            EstimatePrintingSetting.CDPAddressOption = Me.CDPAddressOption
            'If Me.CDPAddressOption = "1" Then
            '    EstimatePrintingSetting.CDPAddressOption = "Client"
            'ElseIf Me.CDPAddressOption = "2" Then
            '    EstimatePrintingSetting.CDPAddressOption = "Division"
            'ElseIf Me.CDPAddressOption = "3" Then
            '    EstimatePrintingSetting.CDPAddressOption = "Product"
            'ElseIf Me.CDPAddressOption = "4" Then
            '    EstimatePrintingSetting.CDPAddressOption = "Contact"
            'Else
            '    EstimatePrintingSetting.CDPAddressOption = "Client"
            'End If
            EstimatePrintingSetting.IncludeRate = Me.IncludeRate
            EstimatePrintingSetting.SummaryLevel = Me.SummaryLevel
            EstimatePrintingSetting.IncludeFunctionComment = Me.IncludeFunctionComment
            EstimatePrintingSetting.PrintAdNumber = Me.PrintAdNumber
            EstimatePrintingSetting.CustomEstimateID = Me.CustomEstimateID
            EstimatePrintingSetting.ShowCodes = Me.ShowCodes
            EstimatePrintingSetting.ContactType = Me.ContactType
            EstimatePrintingSetting.PrintContactAfterAddress = Me.PrintContactAfterAddress
            EstimatePrintingSetting.UseAgencySetting = Me.UseAgencySetting
            EstimatePrintingSetting.FileFormat = Me.FileFormat
            EstimatePrintingSetting.PrintQuantityTotals = Me.PrintQuantityTotals
            EstimatePrintingSetting.ShowWatermark = Me.ShowWatermark
            EstimatePrintingSetting.DisplayQuantity = Me.DisplayQuantity
            EstimatePrintingSetting.DisplayHours = Me.DisplayHours
            EstimatePrintingSetting.IncludeRateMarkup = Me.IncludeRateMarkup
            EstimatePrintingSetting.ExcludeDateFromSignature = Me.ExcludeDateFromSignature

        End Sub
        Public Sub Save(ByVal EstimatePrintingSetting As AdvantageFramework.Database.Entities.EstimatePrintingSetting)

            'EstimatePrintingSetting.ClientOrDefault = Me.Type
            'EstimatePrintingSetting.ClientCode = Me.ClientCode
            'EstimatePrintingSetting.DivisionCode = Me.DivisionCode
            'EstimatePrintingSetting.ProductCode = Me.ProductCode
            EstimatePrintingSetting.DateToPrint = If(Me.DateToPrint = True, 2, 1)
            EstimatePrintingSetting.ShowTaxSeparately = Convert.ToInt64(Me.TotalsShowTaxSeparately)
            EstimatePrintingSetting.IndicateTaxableFunctions = Convert.ToInt64(Me.IndicateTaxableFunctions)
            EstimatePrintingSetting.ShowCommissionSeparately = Convert.ToInt64(Me.TotalsShowCommissionSeparately)
            EstimatePrintingSetting.IndicateCommissionFunctions = Convert.ToInt64(Me.IndicateCommissionFunctions)
            EstimatePrintingSetting.FunctionOption = Me.GroupingOptionFunctionOption
            EstimatePrintingSetting.GroupOption = Me.GroupingOptionGroupOption
            EstimatePrintingSetting.SortOption = Me.GroupingOptionSortOption
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
            EstimatePrintingSetting.IncludeJobQuantity = Convert.ToInt64(Me.IncludeJobQuantity)
            EstimatePrintingSetting.IncludeContingency = Convert.ToInt64(Me.TotalsIncludeContingency)
            EstimatePrintingSetting.SuppressZeroFunctions = Convert.ToInt64(Me.SuppressZeroFunctions)
            EstimatePrintingSetting.UseLocationOptions = Convert.ToInt64(Me.UseLocationOptions)
            EstimatePrintingSetting.LocationCode = Me.LocationCode
            EstimatePrintingSetting.LogoPath = Me.LogoPath
            EstimatePrintingSetting.ReportFormat = Me.ReportFormat
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
            EstimatePrintingSetting.HideJobDescription = Convert.ToInt64(Me.HideJobDescription)
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
            EstimatePrintingSetting.CDPAddressOption = Me.CDPAddressOption
            EstimatePrintingSetting.IncludeRate = Convert.ToInt64(Me.IncludeRate)
            EstimatePrintingSetting.SummaryLevel = Convert.ToInt64(Me.SummaryLevel)
            EstimatePrintingSetting.PrintClientName = Convert.ToInt64(Me.PrintClientName)
            EstimatePrintingSetting.IncludeFunctionComment = Convert.ToInt64(Me.IncludeFunctionComment)
            EstimatePrintingSetting.PrintAdNumber = Convert.ToInt64(Me.PrintAdNumber)
            EstimatePrintingSetting.CustomEstimateID = Convert.ToInt64(Me.CustomEstimateID)
            EstimatePrintingSetting.ShowCodes = Convert.ToInt64(Me.ShowCodes)
            EstimatePrintingSetting.ContactType = Convert.ToInt64(Me.ContactType)
            EstimatePrintingSetting.PrintContactAfterAddress = Convert.ToInt64(Me.PrintContactAfterAddress)
            EstimatePrintingSetting.UseAgencySetting = Convert.ToInt64(Me.UseAgencySetting)
            EstimatePrintingSetting.FileFormat = Convert.ToInt64(Me.FileFormat)
            EstimatePrintingSetting.PrintQuantityTotals = Convert.ToInt64(Me.PrintQuantityTotals)
            EstimatePrintingSetting.ShowWatermark = Convert.ToInt64(Me.ShowWatermark)
            EstimatePrintingSetting.DisplayQuantity = Convert.ToInt64(Me.DisplayQuantity)
            EstimatePrintingSetting.DisplayHours = Convert.ToInt64(Me.DisplayHours)
            EstimatePrintingSetting.IncludeRateMarkup = Convert.ToInt64(Me.IncludeRateMarkup)
            EstimatePrintingSetting.ExcludeDateFromSignature = Convert.ToInt64(Me.ExcludeDateFromSignature)

        End Sub
        Public Sub SaveDefault()

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function
        Public Sub Update(ByVal EstimatePrintingSetting As AdvantageFramework.Database.Entities.EstimatePrintingSetting, ByVal EstimatePrintingSettingClass As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting)

            EstimatePrintingSetting.DateToPrint = If(EstimatePrintingSettingClass.DateToPrint = True, 2, 1)
            EstimatePrintingSetting.ShowTaxSeparately = Convert.ToInt64(EstimatePrintingSettingClass.TotalsShowTaxSeparately)
            EstimatePrintingSetting.IndicateTaxableFunctions = Convert.ToInt64(EstimatePrintingSettingClass.IndicateTaxableFunctions)
            EstimatePrintingSetting.ShowCommissionSeparately = Convert.ToInt64(EstimatePrintingSettingClass.TotalsShowCommissionSeparately)
            EstimatePrintingSetting.IndicateCommissionFunctions = Convert.ToInt64(EstimatePrintingSettingClass.IndicateCommissionFunctions)
            EstimatePrintingSettingClass.GroupingOptionFunctionOption = EstimatePrintingSettingClass.GroupingOptionFunctionOption
            EstimatePrintingSettingClass.GroupingOptionGroupOption = EstimatePrintingSettingClass.GroupingOptionGroupOption
            EstimatePrintingSettingClass.GroupingOptionSortOption = EstimatePrintingSettingClass.GroupingOptionSortOption
            'If EstimatePrintingSettingClass.GroupingOptionFunctionOption = "1" Then
            '    EstimatePrintingSetting.FunctionOption = "F"
            'ElseIf EstimatePrintingSettingClass.GroupingOptionFunctionOption = "2" Then
            '    EstimatePrintingSetting.FunctionOption = "C"
            'ElseIf EstimatePrintingSettingClass.GroupingOptionFunctionOption = "3" Then
            '    EstimatePrintingSetting.FunctionOption = "T"
            'ElseIf EstimatePrintingSettingClass.GroupingOptionFunctionOption = "4" Then
            '    EstimatePrintingSetting.FunctionOption = "R"
            'ElseIf EstimatePrintingSettingClass.GroupingOptionFunctionOption = "5" Then
            '    EstimatePrintingSetting.FunctionOption = "N"
            'Else
            '    EstimatePrintingSetting.FunctionOption = "F"
            'End If
            'If EstimatePrintingSettingClass.GroupingOptionGroupOption = "1" Then
            '    EstimatePrintingSetting.GroupOption = "N"
            'ElseIf EstimatePrintingSettingClass.GroupingOptionGroupOption = "2" Then
            '    EstimatePrintingSetting.GroupOption = "T"
            'ElseIf EstimatePrintingSettingClass.GroupingOptionGroupOption = "3" Then
            '    EstimatePrintingSetting.GroupOption = "H"
            'ElseIf EstimatePrintingSettingClass.GroupingOptionGroupOption = "4" Then
            '    EstimatePrintingSetting.GroupOption = "HT"
            'ElseIf EstimatePrintingSettingClass.GroupingOptionGroupOption = "5" Then
            '    EstimatePrintingSetting.GroupOption = "I"
            'ElseIf EstimatePrintingSettingClass.GroupingOptionGroupOption = "6" Then
            '    EstimatePrintingSetting.GroupOption = "P"
            'Else
            '    EstimatePrintingSetting.GroupOption = "N"
            'End If
            'If EstimatePrintingSettingClass.GroupingOptionGroupOption = "1" Then
            '    EstimatePrintingSetting.SortOption = "C"
            'ElseIf EstimatePrintingSettingClass.GroupingOptionGroupOption = "2" Then
            '    EstimatePrintingSetting.SortOption = "O"
            'Else
            '    EstimatePrintingSetting.SortOption = "C"
            'End If
            EstimatePrintingSetting.InsideDescription = EstimatePrintingSettingClass.GroupingOptionInsideDescription
            EstimatePrintingSetting.OutsideDescription = EstimatePrintingSettingClass.GroupingOptionOutsideDescription
            EstimatePrintingSetting.IncludeEstimateComment = Convert.ToInt64(EstimatePrintingSettingClass.IncludeEstimateComment)
            EstimatePrintingSetting.IncludeEstimateComponentComment = Convert.ToInt64(EstimatePrintingSettingClass.IncludeEstimateComponentComment)
            EstimatePrintingSetting.IncludeEstimateQuoteComment = Convert.ToInt64(EstimatePrintingSettingClass.IncludeEstimateQuoteComment)
            EstimatePrintingSetting.IncludeEstimateRevisionComment = Convert.ToInt64(EstimatePrintingSettingClass.IncludeEstimateRevisionComment)
            EstimatePrintingSetting.IncludeEstimateFunctionComment = Convert.ToInt64(EstimatePrintingSettingClass.IncludeEstimateFunctionComment)
            EstimatePrintingSetting.DefaultFooterComment = Convert.ToInt64(EstimatePrintingSettingClass.DefaultFooterComment)
            EstimatePrintingSetting.IncludeClientReference = Convert.ToInt64(EstimatePrintingSettingClass.IncludeClientReference)
            EstimatePrintingSetting.IncludeAccountExecutive = Convert.ToInt64(EstimatePrintingSettingClass.IncludeAccountExecutive)
            EstimatePrintingSetting.IncludeSalesClass = Convert.ToInt64(EstimatePrintingSettingClass.IncludeSalesClass)
            EstimatePrintingSetting.IncludeJobQuantity = Convert.ToInt64(EstimatePrintingSettingClass.IncludeJobQuantity)
            EstimatePrintingSetting.IncludeContingency = Convert.ToInt64(EstimatePrintingSettingClass.TotalsIncludeContingency)
            EstimatePrintingSetting.SuppressZeroFunctions = Convert.ToInt64(EstimatePrintingSettingClass.SuppressZeroFunctions)
            EstimatePrintingSetting.UseLocationOptions = Convert.ToInt64(EstimatePrintingSettingClass.UseLocationOptions)
            EstimatePrintingSetting.LocationCode = EstimatePrintingSettingClass.LocationCode
            EstimatePrintingSetting.LogoPath = EstimatePrintingSettingClass.LogoPath
            'If EstimatePrintingSettingClass.ReportFormat = 1 Then
            '    EstimatePrintingSetting.ReportFormat = "001"
            'ElseIf EstimatePrintingSettingClass.ReportFormat = 2 Then
            '    EstimatePrintingSetting.ReportFormat = "002"
            'ElseIf EstimatePrintingSettingClass.ReportFormat = 3 Then
            '    EstimatePrintingSetting.ReportFormat = "003"
            'ElseIf EstimatePrintingSettingClass.ReportFormat = 4 Then
            '    EstimatePrintingSetting.ReportFormat = "004"
            'ElseIf EstimatePrintingSettingClass.ReportFormat = 5 Then
            '    EstimatePrintingSetting.ReportFormat = "005"
            'ElseIf EstimatePrintingSettingClass.ReportFormat = 6 Then
            '    EstimatePrintingSetting.ReportFormat = "006"
            'ElseIf EstimatePrintingSettingClass.ReportFormat = 7 Then
            '    EstimatePrintingSetting.ReportFormat = "007"
            'ElseIf EstimatePrintingSettingClass.ReportFormat = 8 Then
            '    EstimatePrintingSetting.ReportFormat = "008"
            'ElseIf EstimatePrintingSettingClass.ReportFormat = 9 Then
            '    EstimatePrintingSetting.ReportFormat = "009"
            'ElseIf EstimatePrintingSettingClass.ReportFormat = 10 Then
            '    EstimatePrintingSetting.ReportFormat = "300"
            'ElseIf EstimatePrintingSettingClass.ReportFormat = 11 Then
            '    EstimatePrintingSetting.ReportFormat = "301"
            'ElseIf EstimatePrintingSettingClass.ReportFormat = 12 Then
            '    EstimatePrintingSetting.ReportFormat = "302"
            'ElseIf EstimatePrintingSettingClass.ReportFormat = 13 Then
            '    EstimatePrintingSetting.ReportFormat = "303"
            'ElseIf EstimatePrintingSettingClass.ReportFormat = 14 Then
            '    EstimatePrintingSetting.ReportFormat = "304"
            'ElseIf EstimatePrintingSettingClass.ReportFormat = 15 Then
            '    EstimatePrintingSetting.ReportFormat = "305"
            'ElseIf EstimatePrintingSettingClass.ReportFormat = 16 Then
            '    EstimatePrintingSetting.ReportFormat = "306"
            'ElseIf EstimatePrintingSettingClass.ReportFormat = 17 Then
            '    EstimatePrintingSetting.ReportFormat = "307"
            'ElseIf EstimatePrintingSettingClass.ReportFormat = 18 Then
            '    EstimatePrintingSetting.ReportFormat = "308"
            'ElseIf EstimatePrintingSettingClass.ReportFormat = 19 Then
            '    EstimatePrintingSetting.ReportFormat = "309"
            'ElseIf EstimatePrintingSettingClass.ReportFormat = 20 Then
            '    EstimatePrintingSetting.ReportFormat = "310"
            'ElseIf EstimatePrintingSettingClass.ReportFormat = 21 Then
            '    EstimatePrintingSetting.ReportFormat = "311"
            'ElseIf EstimatePrintingSettingClass.ReportFormat = 22 Then
            '    EstimatePrintingSetting.ReportFormat = "312"
            'ElseIf EstimatePrintingSettingClass.ReportFormat = 23 Then
            '    EstimatePrintingSetting.ReportFormat = "313"
            'ElseIf EstimatePrintingSettingClass.ReportFormat = 24 Then
            '    EstimatePrintingSetting.ReportFormat = "314"
            'End If
            EstimatePrintingSetting.ReportFormat = EstimatePrintingSettingClass.ReportFormat
            EstimatePrintingSetting.IncludeNonBillable = Convert.ToInt64(EstimatePrintingSettingClass.IncludeNonBillable)
            EstimatePrintingSetting.PrintDivisionName = Convert.ToInt64(EstimatePrintingSettingClass.PrintDivisionName)
            EstimatePrintingSetting.PrintProductDescription = Convert.ToInt64(EstimatePrintingSettingClass.PrintProductDescription)
            EstimatePrintingSetting.IncludeQuantityHours = Convert.ToInt64(EstimatePrintingSettingClass.IncludeQuantityHours)
            EstimatePrintingSetting.ConsolidationOverride = Convert.ToInt64(EstimatePrintingSettingClass.ConsolidationOverride)
            EstimatePrintingSetting.SubtotalsOnly = Convert.ToInt64(EstimatePrintingSettingClass.SubtotalsOnly)
            EstimatePrintingSetting.IncludeCPU = Convert.ToInt64(EstimatePrintingSettingClass.IncludeCPU)
            EstimatePrintingSetting.IncludeCPM = Convert.ToInt64(EstimatePrintingSettingClass.IncludeCPM)
            EstimatePrintingSetting.ReportTitle = EstimatePrintingSettingClass.ReportTitle
            EstimatePrintingSetting.IncludeSuppliedByNotes = Convert.ToInt64(EstimatePrintingSettingClass.IncludeSuppliedByNotes)
            EstimatePrintingSetting.ShowContingencySeparately = Convert.ToInt64(EstimatePrintingSettingClass.TotalsShowContingencySeparately)
            EstimatePrintingSetting.Signature = Convert.ToInt64(EstimatePrintingSettingClass.Signature)
            EstimatePrintingSetting.HideJobDescription = Convert.ToInt64(EstimatePrintingSettingClass.HideJobDescription)
            EstimatePrintingSetting.HideComponentDescription = Convert.ToInt64(EstimatePrintingSettingClass.HideComponentDescription)
            EstimatePrintingSetting.HideRevision = Convert.ToInt64(EstimatePrintingSettingClass.HideRevision)
            EstimatePrintingSetting.IncludeJobDueDate = Convert.ToInt64(EstimatePrintingSettingClass.IncludeJobDueDate)
            EstimatePrintingSetting.UseEmployeeSignature = Convert.ToInt64(EstimatePrintingSettingClass.UseEmployeeSignature)
            EstimatePrintingSetting.ExcludeEmployeeTime = Convert.ToInt64(EstimatePrintingSettingClass.ExcludeEmployeeTime)
            EstimatePrintingSetting.ExcludeVendor = Convert.ToInt64(EstimatePrintingSettingClass.ExcludeVendor)
            EstimatePrintingSetting.ExcludeIncomeOnly = Convert.ToInt64(EstimatePrintingSettingClass.ExcludeIncomeOnly)
            EstimatePrintingSetting.ExcludeSignatures = Convert.ToInt32(EstimatePrintingSettingClass.ExcludeSignatures)
            EstimatePrintingSetting.IncludeCampaignSummary = Convert.ToInt32(EstimatePrintingSettingClass.IncludeCampaignSummary)
            EstimatePrintingSetting.IncludeVendorDescription = Convert.ToInt32(EstimatePrintingSettingClass.IncludeVendorDescription)
            EstimatePrintingSetting.ExcludeNonbillable = Convert.ToInt64(EstimatePrintingSettingClass.ExcludeNonbillable)
            EstimatePrintingSetting.CDPAddressOption = EstimatePrintingSettingClass.CDPAddressOption
            'If EstimatePrintingSettingClass.CDPAddressOption = "1" Then
            '    EstimatePrintingSetting.CDPAddressOption = "Client"
            'ElseIf EstimatePrintingSettingClass.CDPAddressOption = "2" Then
            '    EstimatePrintingSetting.CDPAddressOption = "Division"
            'ElseIf EstimatePrintingSettingClass.CDPAddressOption = "3" Then
            '    EstimatePrintingSetting.CDPAddressOption = "Product"
            'ElseIf EstimatePrintingSettingClass.CDPAddressOption = "4" Then
            '    EstimatePrintingSetting.CDPAddressOption = "Contact"
            'Else
            '    EstimatePrintingSetting.CDPAddressOption = "Client"
            'End If
            EstimatePrintingSetting.IncludeRate = Convert.ToInt64(EstimatePrintingSettingClass.IncludeRate)
            EstimatePrintingSetting.SummaryLevel = Convert.ToInt64(EstimatePrintingSettingClass.SummaryLevel)
            EstimatePrintingSetting.PrintClientName = Convert.ToInt64(EstimatePrintingSettingClass.PrintClientName)
            EstimatePrintingSetting.IncludeFunctionComment = Convert.ToInt64(EstimatePrintingSettingClass.IncludeFunctionComment)
            EstimatePrintingSetting.PrintAdNumber = Convert.ToInt64(EstimatePrintingSettingClass.PrintAdNumber)
            EstimatePrintingSetting.CustomEstimateID = Convert.ToInt64(EstimatePrintingSettingClass.CustomEstimateID)
            EstimatePrintingSetting.ShowCodes = Convert.ToInt64(EstimatePrintingSettingClass.ShowCodes)
            EstimatePrintingSetting.ContactType = Convert.ToInt64(EstimatePrintingSettingClass.ContactType)
            EstimatePrintingSetting.PrintContactAfterAddress = Convert.ToInt64(EstimatePrintingSettingClass.PrintContactAfterAddress)
            EstimatePrintingSetting.UseAgencySetting = Convert.ToInt64(EstimatePrintingSettingClass.UseAgencySetting)
            EstimatePrintingSetting.FileFormat = Convert.ToInt64(EstimatePrintingSettingClass.FileFormat)
            EstimatePrintingSetting.PrintQuantityTotals = Convert.ToInt64(EstimatePrintingSettingClass.PrintQuantityTotals)
            EstimatePrintingSetting.ShowWatermark = Convert.ToInt64(EstimatePrintingSettingClass.ShowWatermark)
            EstimatePrintingSetting.DisplayQuantity = Convert.ToInt64(EstimatePrintingSettingClass.DisplayQuantity)
            EstimatePrintingSetting.DisplayHours = Convert.ToInt64(EstimatePrintingSettingClass.DisplayHours)
            EstimatePrintingSetting.IncludeRateMarkup = Convert.ToInt64(EstimatePrintingSettingClass.IncludeRateMarkup)
            EstimatePrintingSetting.ExcludeDateFromSignature = Convert.ToInt64(EstimatePrintingSettingClass.ExcludeDateFromSignature)
        End Sub

#End Region

    End Class

End Namespace
