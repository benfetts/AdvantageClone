Namespace Database.Entities

    <NotMapped>
    <System.Data.Linq.Mapping.Table(Name:="dbo.ESTIMATE_PRINT_DEF")>
    Public Class EstimatePrintSetting
        Inherits AdvantageFramework.BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            UserID
            SelectBy
            DateToPrint
            ShowTaxSeparately
            IndicateTaxableFunctions
            ShowCommissionSeparately
            IndicateCommissionFunctions
            FunctionOption
            GroupOption
            SortOption
            InsideDescription
            OutsideDescription
            IncludeEstimateComment
            IncludeEstimateComponentComment
            IncludeEstimateQuoteComment
            IncludeEstimateRevisionComment
            IncludeEstimateFunctionComment
            DefaultFooterComment
            IncludeClientReference
            IncludeAccountExecutive
            IncludeSalesClass
            IncludeSpecifications
            IncludeJobQuantity
            IncludeContingency
            SuppressZeroFunctions
            LocationCode
            LogoPath
            ReportFormat
            IncludeNonBillable
            PrintDivisionName
            PrintProductDescription
            IncludeQuantityHours
            ConsolidationOverride
            SubtotalsOnly
            IncludeCPU
            IncludeCPM
            ReportTitle
            IncludeSuppliedByNotes
            ShowContingencySeparately
            Signature
            HideComponentDescription
            HideRevision
            IncludeJobDueDate
            UseEmployeeSignature
            ExcludeEmployeeTime
            ExcludeVendor
            ExcludeIncomeOnly
            ExcludeSignatures
            IncludeCampaignSummary
            IncludeVendorDescription
            ExcludeNonbillable
            CDPAddressOption
            IncludeRate
            CombineComponents
            PrintClientName
            IncludeFunctionComment
            PrintAdNumber
            FileFormat
            PrintCustom
        End Enum

#End Region

#Region " Variables "

        Private _UserID As String = ""
        Private _SelectBy As String = ""
        Private _DateToPrint As Nullable(Of Long) = 0
        Private _ShowTaxSeparately As Nullable(Of Long) = 0
        Private _IndicateTaxableFunctions As Nullable(Of Long) = 0
        Private _ShowCommissionSeparately As Nullable(Of Long) = 0
        Private _IndicateCommissionFunctions As Nullable(Of Long) = 0
        Private _FunctionOption As String = ""
        Private _GroupOption As String = ""
        Private _SortOption As String = ""
        Private _InsideDescription As String = ""
        Private _OutsideDescription As String = ""
        Private _IncludeEstimateComment As Nullable(Of Long) = 0
        Private _IncludeEstimateComponentComment As Nullable(Of Long) = 0
        Private _IncludeEstimateQuoteComment As Nullable(Of Long) = 0
        Private _IncludeEstimateRevisionComment As Nullable(Of Long) = 0
        Private _IncludeEstimateFunctionComment As Nullable(Of Long) = 0
        Private _DefaultFooterComment As Nullable(Of Long) = 0
        Private _IncludeClientReference As Nullable(Of Long) = 0
        Private _IncludeAccountExecutive As Nullable(Of Long) = 0
        Private _IncludeSalesClass As Nullable(Of Long) = 0
        Private _IncludeSpecifications As Nullable(Of Long) = 0
        Private _IncludeJobQuantity As Nullable(Of Long) = 0
        Private _IncludeContingency As Nullable(Of Long) = 0
        Private _SuppressZeroFunctions As Nullable(Of Long) = 0
        Private _LocationCode As String = ""
        Private _LogoPath As String = ""
        Private _ReportFormat As String = ""
        Private _IncludeNonBillable As Nullable(Of Long) = 0
        Private _PrintDivisionName As Nullable(Of Long) = 0
        Private _PrintProductDescription As Nullable(Of Long) = 0
        Private _IncludeQuantityHours As Nullable(Of Long) = 0
        Private _ConsolidationOverride As Nullable(Of Long) = 0
        Private _SubtotalsOnly As Nullable(Of Long) = 0
        Private _IncludeCPU As Nullable(Of Long) = 0
        Private _IncludeCPM As Nullable(Of Long) = 0
        Private _ReportTitle As String = ""
        Private _IncludeSuppliedByNotes As Nullable(Of Long) = 0
        Private _ShowContingencySeparately As Nullable(Of Long) = 0
        Private _Signature As Nullable(Of Long) = 0
        Private _HideComponentDescription As Nullable(Of Long) = 0
        Private _HideRevision As Nullable(Of Long) = 0
        Private _IncludeJobDueDate As Nullable(Of Long) = 0
        Private _UseEmployeeSignature As Nullable(Of Long) = 0
        Private _ExcludeEmployeeTime As Nullable(Of Long) = 0
        Private _ExcludeVendor As Nullable(Of Long) = 0
        Private _ExcludeIncomeOnly As Nullable(Of Long) = 0
        Private _ExcludeSignatures As Nullable(Of Long) = 0
        Private _IncludeCampaignSummary As Nullable(Of Long) = 0
        Private _IncludeVendorDescription As Nullable(Of Long) = 0
        Private _ExcludeNonbillable As Nullable(Of Long) = 0
        Private _CDPAddressOption As String = ""
        Private _IncludeRate As Nullable(Of Long) = 0
        Private _CombineComponents As Nullable(Of Long) = 0
        Private _PrintClientName As Nullable(Of Long) = 0
        Private _IncludeFunctionComment As Nullable(Of Long) = 0
        Private _PrintAdNumber As Nullable(Of Long) = 0
        Private _FileFormat As String = ""
        Private _PrintCustom As Boolean = Nothing

#End Region

#Region " Properties "

		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="USER_ID", Storage:="_UserID", IsPrimaryKey:=True, DbType:="varchar NOT NULL"),
		 System.ComponentModel.DisplayName("UserID"),
		System.ComponentModel.DataAnnotations.MaxLength(100)>
		Public Property UserID() As String
			Get
				UserID = _UserID
			End Get
			Set(ByVal value As String)
				_UserID = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="SELECT_BY", Storage:="_SelectBy", DbType:="varchar"),
		System.ComponentModel.DisplayName("SelectBy"),
		System.ComponentModel.DataAnnotations.MaxLength(2)>
		Public Property SelectBy() As String
			Get
				SelectBy = _SelectBy
			End Get
			Set(ByVal value As String)
				_SelectBy = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="DATE_TO_PRINT", Storage:="_DateToPrint", DbType:="smallint NULL"),
		System.ComponentModel.DisplayName("DateToPrint")>
		Public Property DateToPrint() As Nullable(Of Long)
			Get
				DateToPrint = _DateToPrint
			End Get
			Set(value As Nullable(Of Long))
				_DateToPrint = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="TAX_SEPARATE", Storage:="_ShowTaxSeparately", DbType:="smallint NULL"),
		System.ComponentModel.DisplayName("ShowTaxSeparately")>
		Public Property ShowTaxSeparately() As Nullable(Of Long)
			Get
				ShowTaxSeparately = _ShowTaxSeparately
			End Get
			Set(value As Nullable(Of Long))
				_ShowTaxSeparately = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="TAX_INDICATOR", Storage:="_IndicateTaxableFunctions", DbType:="smallint NULL"),
		System.ComponentModel.DisplayName("IndicateTaxableFunctions")>
		Public Property IndicateTaxableFunctions() As Nullable(Of Long)
			Get
				IndicateTaxableFunctions = _IndicateTaxableFunctions
			End Get
			Set(value As Nullable(Of Long))
				_IndicateTaxableFunctions = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="COMM_MU_SEPARATE", Storage:="_ShowCommissionSeparately", DbType:="smallint NULL"),
		System.ComponentModel.DisplayName("ShowCommissionSeparately")>
		Public Property ShowCommissionSeparately() As Nullable(Of Long)
			Get
				ShowCommissionSeparately = _ShowCommissionSeparately
			End Get
			Set(value As Nullable(Of Long))
				_ShowCommissionSeparately = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="COMM_MU_INDICATOR", Storage:="_IndicateCommissionFunctions", DbType:="smallint NULL"),
		System.ComponentModel.DisplayName("IndicateCommissionFunctions")>
		Public Property IndicateCommissionFunctions() As Nullable(Of Long)
			Get
				IndicateCommissionFunctions = _IndicateCommissionFunctions
			End Get
			Set(value As Nullable(Of Long))
				_IndicateCommissionFunctions = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="FUNCTION_OPTION", Storage:="_FunctionOption", DbType:="varchar"),
		System.ComponentModel.DisplayName("FunctionOption"),
		System.ComponentModel.DataAnnotations.MaxLength(2)>
		Public Property FunctionOption() As String
			Get
				FunctionOption = _FunctionOption
			End Get
			Set(ByVal value As String)
				_FunctionOption = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="GROUP_OPTION", Storage:="_GroupOption", DbType:="varchar"),
		System.ComponentModel.DisplayName("GroupOption"),
		System.ComponentModel.DataAnnotations.MaxLength(2)>
		Public Property GroupOption() As String
			Get
				GroupOption = _GroupOption
			End Get
			Set(ByVal value As String)
				_GroupOption = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="SORT_OPTION", Storage:="_SortOption", DbType:="varchar"),
		System.ComponentModel.DisplayName("SortOption"),
		System.ComponentModel.DataAnnotations.MaxLength(2)>
		Public Property SortOption() As String
			Get
				SortOption = _SortOption
			End Get
			Set(ByVal value As String)
				_SortOption = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="INSIDE_CHG_DESC", Storage:="_InsideDescription", DbType:="varchar"),
		System.ComponentModel.DisplayName("InsideDescription"),
		System.ComponentModel.DataAnnotations.MaxLength(30)>
		Public Property InsideDescription() As String
			Get
				InsideDescription = _InsideDescription
			End Get
			Set(ByVal value As String)
				_InsideDescription = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="OUTSIDE_CHG_DESC", Storage:="_OutsideDescription", DbType:="varchar"),
		System.ComponentModel.DisplayName("OutsideDescription"),
		System.ComponentModel.DataAnnotations.MaxLength(30)>
		Public Property OutsideDescription() As String
			Get
				OutsideDescription = _OutsideDescription
			End Get
			Set(ByVal value As String)
				_OutsideDescription = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="EST_COMMENT", Storage:="_IncludeEstimateComment", DbType:="smallint NULL"),
		System.ComponentModel.DisplayName("IncludeEstimateComment")>
		Public Property IncludeEstimateComment() As Nullable(Of Long)
			Get
				IncludeEstimateComment = _IncludeEstimateComment
			End Get
			Set(value As Nullable(Of Long))
				_IncludeEstimateComment = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="EST_COMP_COMMENT", Storage:="_IncludeEstimateComponentComment", DbType:="smallint NULL"),
		System.ComponentModel.DisplayName("IncludeEstimateComponentComment")>
		Public Property IncludeEstimateComponentComment() As Nullable(Of Long)
			Get
				IncludeEstimateComponentComment = _IncludeEstimateComponentComment
			End Get
			Set(value As Nullable(Of Long))
				_IncludeEstimateComponentComment = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="QTE_COMMENT", Storage:="_IncludeEstimateQuoteComment", DbType:="smallint NULL"),
		System.ComponentModel.DisplayName("IncludeEstimateQuoteComment")>
		Public Property IncludeEstimateQuoteComment() As Nullable(Of Long)
			Get
				IncludeEstimateQuoteComment = _IncludeEstimateQuoteComment
			End Get
			Set(ByVal value As Nullable(Of Long))
				_IncludeEstimateQuoteComment = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="REV_COMMENT", Storage:="_IncludeEstimateRevisionComment", DbType:="smallint NULL"),
		System.ComponentModel.DisplayName("IncludeEstimateRevisionComment")>
		Public Property IncludeEstimateRevisionComment() As Nullable(Of Long)
			Get
				IncludeEstimateRevisionComment = _IncludeEstimateRevisionComment
			End Get
			Set(ByVal value As Nullable(Of Long))
				_IncludeEstimateRevisionComment = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="FUNC_COMMENT", Storage:="_IncludeEstimateFunctionComment", DbType:="smallint NULL"),
		System.ComponentModel.DisplayName("IncludeEstimateFunctionComment")>
		Public Property IncludeEstimateFunctionComment() As Nullable(Of Long)
			Get
				IncludeEstimateFunctionComment = _IncludeEstimateFunctionComment
			End Get
			Set(ByVal value As Nullable(Of Long))
				_IncludeEstimateFunctionComment = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="DEF_FOOTER_COMMENT", Storage:="_DefaultFooterComment", DbType:="smallint NULL"),
		System.ComponentModel.DisplayName("DefaultFooterComment")>
		Public Property DefaultFooterComment() As Nullable(Of Long)
			Get
				DefaultFooterComment = _DefaultFooterComment
			End Get
			Set(ByVal value As Nullable(Of Long))
				_DefaultFooterComment = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CLI_REF", Storage:="_IncludeClientReference", DbType:="smallint NULL"),
		System.ComponentModel.DisplayName("IncludeClientReference")>
		Public Property IncludeClientReference() As Nullable(Of Long)
			Get
				IncludeClientReference = _IncludeClientReference
			End Get
			Set(ByVal value As Nullable(Of Long))
				_IncludeClientReference = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="AE_NAME", Storage:="_IncludeAccountExecutive", DbType:="smallint NULL"),
		System.ComponentModel.DisplayName("IncludeAccountExecutive")>
		Public Property IncludeAccountExecutive() As Nullable(Of Long)
			Get
				IncludeAccountExecutive = _IncludeAccountExecutive
			End Get
			Set(ByVal value As Nullable(Of Long))
				_IncludeAccountExecutive = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="PRT_SALES_CLASS", Storage:="_IncludeSalesClass", DbType:="smallint NULL"),
		System.ComponentModel.DisplayName("IncludeSalesClass")>
		Public Property IncludeSalesClass() As Nullable(Of Long)
			Get
				IncludeSalesClass = _IncludeSalesClass
			End Get
			Set(ByVal value As Nullable(Of Long))
				_IncludeSalesClass = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="SPECS", Storage:="_IncludeSpecifications", DbType:="smallint NULL"),
		System.ComponentModel.DisplayName("IncludeSpecifications")>
		Public Property IncludeSpecifications() As Nullable(Of Long)
			Get
				IncludeSpecifications = _IncludeSpecifications
			End Get
			Set(ByVal value As Nullable(Of Long))
				_IncludeSpecifications = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="JOB_QTY", Storage:="_IncludeJobQuantity", DbType:="smallint NULL"),
		System.ComponentModel.DisplayName("IncludeJobQuantity")>
		Public Property IncludeJobQuantity() As Nullable(Of Long)
			Get
				IncludeJobQuantity = _IncludeJobQuantity
			End Get
			Set(ByVal value As Nullable(Of Long))
				_IncludeJobQuantity = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CONTINGENCY", Storage:="_IncludeContingency", DbType:="smallint NULL"),
		System.ComponentModel.DisplayName("IncludeContingency")>
		Public Property IncludeContingency() As Nullable(Of Long)
			Get
				IncludeContingency = _IncludeContingency
			End Get
			Set(ByVal value As Nullable(Of Long))
				_IncludeContingency = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="SUPPRESS_ZERO", Storage:="_SuppressZeroFunctions", DbType:="smallint NULL"),
		System.ComponentModel.DisplayName("SuppressZeroFunctions")>
		Public Property SuppressZeroFunctions() As Nullable(Of Long)
			Get
				SuppressZeroFunctions = _SuppressZeroFunctions
			End Get
			Set(ByVal value As Nullable(Of Long))
				_SuppressZeroFunctions = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="LOCATION_ID", Storage:="_LocationCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("LocationCode"),
		System.ComponentModel.DataAnnotations.MaxLength(6)>
		Public Property LocationCode() As String
			Get
				LocationCode = _LocationCode
			End Get
			Set(ByVal value As String)
				_LocationCode = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="LOGO_PATH", Storage:="_LogoPath", DbType:="varchar"),
		System.ComponentModel.DisplayName("LogoPath"),
		System.ComponentModel.DataAnnotations.MaxLength(254)>
		Public Property LogoPath() As String
			Get
				LogoPath = _LogoPath
			End Get
			Set(ByVal value As String)
				_LogoPath = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="REPORT_FORMAT", Storage:="_ReportFormat", DbType:="varchar"),
		System.ComponentModel.DisplayName("ReportFormat"),
		System.ComponentModel.DataAnnotations.MaxLength(50)>
		Public Property ReportFormat() As String
			Get
				ReportFormat = _ReportFormat
			End Get
			Set(ByVal value As String)
				_ReportFormat = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="PRT_NONBILL", Storage:="_IncludeNonBillable", DbType:="smallint NULL"),
		System.ComponentModel.DisplayName("IncludeNonBillable")>
		Public Property IncludeNonBillable() As Nullable(Of Long)
			Get
				IncludeNonBillable = _IncludeNonBillable
			End Get
			Set(ByVal value As Nullable(Of Long))
				_IncludeNonBillable = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="PRT_DIV_NAME", Storage:="_PrintDivisionName", DbType:="smallint NULL"),
		System.ComponentModel.DisplayName("PrintDivisionName")>
		Public Property PrintDivisionName() As Nullable(Of Long)
			Get
				PrintDivisionName = _PrintDivisionName
			End Get
			Set(ByVal value As Nullable(Of Long))
				_PrintDivisionName = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="PRT_PRD_NAME", Storage:="_PrintProductDescription", DbType:="smallint NULL"),
		System.ComponentModel.DisplayName("PrintProductDescription")>
		Public Property PrintProductDescription() As Nullable(Of Long)
			Get
				PrintProductDescription = _PrintProductDescription
			End Get
			Set(ByVal value As Nullable(Of Long))
				_PrintProductDescription = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="QTY_HRS", Storage:="_IncludeQuantityHours", DbType:="smallint NULL"),
		System.ComponentModel.DisplayName("IncludeQuantityHours")>
		Public Property IncludeQuantityHours() As Nullable(Of Long)
			Get
				IncludeQuantityHours = _IncludeQuantityHours
			End Get
			Set(ByVal value As Nullable(Of Long))
				_IncludeQuantityHours = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CONSOL_OVERRIDE", Storage:="_ConsolidationOverride", DbType:="smallint NULL"),
		System.ComponentModel.DisplayName("ConsolidationOverride")>
		Public Property ConsolidationOverride() As Nullable(Of Long)
			Get
				ConsolidationOverride = _ConsolidationOverride
			End Get
			Set(ByVal value As Nullable(Of Long))
				_ConsolidationOverride = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="SUBTOT_ONLY", Storage:="_SubtotalsOnly", DbType:="smallint NULL"),
		System.ComponentModel.DisplayName("SubtotalsOnly")>
		Public Property SubtotalsOnly() As Nullable(Of Long)
			Get
				SubtotalsOnly = _SubtotalsOnly
			End Get
			Set(ByVal value As Nullable(Of Long))
				_SubtotalsOnly = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="PRT_CPU", Storage:="_IncludeCPU", DbType:="smallint NULL"),
		System.ComponentModel.DisplayName("IncludeCPU")>
		Public Property IncludeCPU() As Nullable(Of Long)
			Get
				IncludeCPU = _IncludeCPU
			End Get
			Set(ByVal value As Nullable(Of Long))
				_IncludeCPU = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="PRT_CPM", Storage:="_IncludeCPM", DbType:="smallint NULL"),
		System.ComponentModel.DisplayName("IncludeCPM")>
		Public Property IncludeCPM() As Nullable(Of Long)
			Get
				IncludeCPM = _IncludeCPM
			End Get
			Set(ByVal value As Nullable(Of Long))
				_IncludeCPM = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="RPT_TITLE", Storage:="_ReportTitle", DbType:="varchar"),
		System.ComponentModel.DisplayName("ReportTitle"),
		System.ComponentModel.DataAnnotations.MaxLength(30)>
		Public Property ReportTitle() As String
			Get
				ReportTitle = _ReportTitle
			End Get
			Set(ByVal value As String)
				_ReportTitle = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="SUP_BY_NOTES", Storage:="_IncludeSuppliedByNotes", DbType:="smallint NULL"),
		System.ComponentModel.DisplayName("IncludeSuppliedByNotes")>
		Public Property IncludeSuppliedByNotes() As Nullable(Of Long)
			Get
				IncludeSuppliedByNotes = _IncludeSuppliedByNotes
			End Get
			Set(value As Nullable(Of Long))
				_IncludeSuppliedByNotes = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CONT_SEPARATE", Storage:="_ShowContingencySeparately", DbType:="smallint NULL"),
		System.ComponentModel.DisplayName("ShowContingencySeparately")>
		Public Property ShowContingencySeparately() As Nullable(Of Long)
			Get
				ShowContingencySeparately = _ShowContingencySeparately
			End Get
			Set(ByVal value As Nullable(Of Long))
				_ShowContingencySeparately = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="SIGNATURE", Storage:="_Signature", DbType:="smallint NULL"),
		System.ComponentModel.DisplayName("Signature")>
		Public Property Signature() As Nullable(Of Long)
			Get
				Signature = _Signature
			End Get
			Set(ByVal value As Nullable(Of Long))
				_Signature = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="HIDE_COMP_DESC", Storage:="_HideComponentDescription", DbType:="smallint NULL"),
		System.ComponentModel.DisplayName("HideComponentDescription")>
		Public Property HideComponentDescription() As Nullable(Of Long)
			Get
				HideComponentDescription = _HideComponentDescription
			End Get
			Set(ByVal value As Nullable(Of Long))
				_HideComponentDescription = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="HIDE_REVISION", Storage:="_HideRevision", DbType:="smallint NULL"),
		System.ComponentModel.DisplayName("HideRevision")>
		Public Property HideRevision() As Nullable(Of Long)
			Get
				HideRevision = _HideRevision
			End Get
			Set(value As Nullable(Of Long))
				_HideRevision = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="JOB_DUE_DATE", Storage:="_IncludeJobDueDate", DbType:="smallint NULL"),
		System.ComponentModel.DisplayName("IncludeJobDueDate")>
		Public Property IncludeJobDueDate() As Nullable(Of Long)
			Get
				IncludeJobDueDate = _IncludeJobDueDate
			End Get
			Set(ByVal value As Nullable(Of Long))
				_IncludeJobDueDate = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="USE_EMP_SIG", Storage:="_UseEmployeeSignature", DbType:="smallint NULL"),
		System.ComponentModel.DisplayName("UseEmployeeSignature")>
		Public Property UseEmployeeSignature() As Nullable(Of Long)
			Get
				UseEmployeeSignature = _UseEmployeeSignature
			End Get
			Set(ByVal value As Nullable(Of Long))
				_UseEmployeeSignature = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="EXCL_EMP_TIME", Storage:="_ExcludeEmployeeTime", DbType:="smallint NULL"),
		System.ComponentModel.DisplayName("ExcludeEmployeeTime")>
		Public Property ExcludeEmployeeTime() As Nullable(Of Long)
			Get
				ExcludeEmployeeTime = _ExcludeEmployeeTime
			End Get
			Set(ByVal value As Nullable(Of Long))
				_ExcludeEmployeeTime = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="EXCL_VENDOR", Storage:="_ExcludeVendor", DbType:="smallint NULL"),
		System.ComponentModel.DisplayName("ExcludeVendor")>
		Public Property ExcludeVendor() As Nullable(Of Long)
			Get
				ExcludeVendor = _ExcludeVendor
			End Get
			Set(value As Nullable(Of Long))
				_ExcludeVendor = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="EXCL_IO", Storage:="_ExcludeIncomeOnly", DbType:="smallint NULL"),
		System.ComponentModel.DisplayName("ExcludeIncomeOnly")>
		Public Property ExcludeIncomeOnly() As Nullable(Of Long)
			Get
				ExcludeIncomeOnly = _ExcludeIncomeOnly
			End Get
			Set(value As Nullable(Of Long))
				_ExcludeIncomeOnly = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="EXCL_SIGNATURES", Storage:="_ExcludeSignatures", DbType:="int NULL"),
		System.ComponentModel.DisplayName("ExcludeSignatures")>
		Public Property ExcludeSignatures() As Nullable(Of Long)
			Get
				ExcludeSignatures = _ExcludeSignatures
			End Get
			Set(value As Nullable(Of Long))
				_ExcludeSignatures = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CMP_SUMMARY", Storage:="_IncludeCampaignSummary", DbType:="int NULL"),
		System.ComponentModel.DisplayName("IncludeCampaignSummary")>
		Public Property IncludeCampaignSummary() As Nullable(Of Long)
			Get
				IncludeCampaignSummary = _IncludeCampaignSummary
			End Get
			Set(value As Nullable(Of Long))
				_IncludeCampaignSummary = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="VENDOR_DESC", Storage:="_IncludeVendorDescription", DbType:="int NULL"),
		System.ComponentModel.DisplayName("IncludeVendorDescription")>
		Public Property IncludeVendorDescription() As Nullable(Of Long)
			Get
				IncludeVendorDescription = _IncludeVendorDescription
			End Get
			Set(value As Nullable(Of Long))
				_IncludeVendorDescription = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="EXCL_NONBILL", Storage:="_ExcludeNonbillable", DbType:="smallint NULL"),
		System.ComponentModel.DisplayName("ExcludeNonbillable")>
		Public Property ExcludeNonbillable() As Nullable(Of Long)
			Get
				ExcludeNonbillable = _ExcludeNonbillable
			End Get
			Set(value As Nullable(Of Long))
				_ExcludeNonbillable = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="CDP_ADDRESS", Storage:="_CDPAddressOption", DbType:="varchar"),
		System.ComponentModel.DisplayName("CDPAddressOption"),
		System.ComponentModel.DataAnnotations.MaxLength(10)>
		Public Property CDPAddressOption() As String
			Get
				CDPAddressOption = _CDPAddressOption
			End Get
			Set(ByVal value As String)
				_CDPAddressOption = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="INCL_RATE", Storage:="_IncludeRate", DbType:="smallint NULL"),
		System.ComponentModel.DisplayName("IncludeRate")>
		Public Property IncludeRate() As Nullable(Of Long)
			Get
				IncludeRate = _IncludeRate
			End Get
			Set(value As Nullable(Of Long))
				_IncludeRate = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="COMBINE_COMPS", Storage:="_CombineComponents", DbType:="smallint NULL"),
		System.ComponentModel.DisplayName("CombineComponents")>
		Public Property CombineComponents() As Nullable(Of Long)
			Get
				CombineComponents = _CombineComponents
			End Get
			Set(value As Nullable(Of Long))
				_CombineComponents = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="PRT_CL_NAME", Storage:="_PrintClientName", DbType:="smallint NULL"),
		System.ComponentModel.DisplayName("PrintClientName")>
		Public Property PrintClientName() As Nullable(Of Long)
			Get
				PrintClientName = _PrintClientName
			End Get
			Set(value As Nullable(Of Long))
				_PrintClientName = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="FNC_COMMENT", Storage:="_IncludeFunctionComment", DbType:="smallint NULL"),
		System.ComponentModel.DisplayName("IncludeFunctionComment")>
		Public Property IncludeFunctionComment() As Nullable(Of Long)
			Get
				IncludeFunctionComment = _IncludeFunctionComment
			End Get
			Set(value As Nullable(Of Long))
				_IncludeFunctionComment = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="PRT_AD_NBR", Storage:="_PrintAdNumber", DbType:="smallint NULL"),
		System.ComponentModel.DisplayName("PrintAdNumber")>
		Public Property PrintAdNumber() As Nullable(Of Long)
			Get
				PrintAdNumber = _PrintAdNumber
			End Get
			Set(value As Nullable(Of Long))
				_PrintAdNumber = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="FILE_FORMAT", Storage:="_FileFormat", DbType:="varchar"),
		System.ComponentModel.DisplayName("FileFormat"),
		System.ComponentModel.DataAnnotations.MaxLength(2)>
		Public Property FileFormat() As String
            Get
                FileFormat = _FileFormat
            End Get
            Set(ByVal value As String)
                _FileFormat = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="PRINT_CUSTOM", Storage:="_PrintCustom", DBType:="bit"), _
        System.ComponentModel.DisplayName("PrintCustom")> _
        Public Property PrintCustom() As Boolean
            Get
                PrintCustom = _PrintCustom
            End Get
            Set(value As Boolean)
                _PrintCustom = value
            End Set
        End Property

#End Region

#Region " Methods "

#End Region

    End Class

End Namespace
