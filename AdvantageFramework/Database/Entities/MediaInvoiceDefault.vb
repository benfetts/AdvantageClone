Namespace Database.Entities

	<Table("MEDIA_INV_DEF")>
	Public Class MediaInvoiceDefault
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			ClientOrDefault
			ClientCode
			LocationID
			LocationCode
			AddressBlockType
			PrintDivisionName
			PrintProductDescription
			IncludeBillingComment
			IncludeSalesClass
			IncludeCampaignDescription
			InvoiceFooterCommentType
			InvoiceFooterComment
			ApplyExchangeRate
			ExchangeRateAmount
			CustomFormatName
			MagazineGroupByMarket
			MagazineShowOrderDescription
			MagazineShowClientReference
			MagazineShowClientPO
			MagazineShowOrderComment
			MagazineShowOrderHouseComment
			MagazineShowLineDetail
			MagazineOrderNumberColumn
			MagazineVendorNameColumn
			MagazineShowVendorCode
			MagazineOrderMonthsColumn
			MagazineHeadlineColumn
			MagazineInsertDatesColumn
			MagazineMaterialColumn
			MagazineAdNumberColumn
			MagazineEditorialIssueColumn
			MagazineAdSizeColumn
			MagazineJobComponentNumberColumn
			MagazineJobDescriptionColumn
			MagazineComponentDescriptionColumn
			MagazineOrderDetailCommentColumn
			MagazineOrderHouseDetailCommentColumn
			MagazineExtraChargesColumn
			MagazineNetAmountColumn
			MagazineCommissionAmountColumn
			MagazineTaxAmountColumn
			MagazineBillAmountColumn
			MagazinePriorBillAmountColumn
			MagazineBilledToDateAmountColumn
			MagazineShowCommissionSeparately
			MagazineShowRebateSeparately
			MagazineShowTaxSeparately
			MagazineShowBillingHistory
			MagazineCustomFormat
			NewspaperGroupByMarket
			NewspaperShowOrderDescription
			NewspaperShowClientReference
			NewspaperShowClientPO
			NewspaperShowOrderComment
			NewspaperShowOrderHouseComment
			NewspaperShowLineDetail
			NewspaperOrderNumberColumn
			NewspaperVendorNameColumn
			NewspaperShowVendorCode
			NewspaperOrderMonthsColumn
			NewspaperHeadlineColumn
			NewspaperInsertDatesColumn
			NewspaperMaterialColumn
			NewspaperAdNumberColumn
			NewspaperEditorialIssueColumn
			NewspaperSectionColumn
			NewspaperQuantityColumn
			NewspaperAdSizeColumn
			NewspaperJobComponentNumberColumn
			NewspaperJobDescriptionColumn
			NewspaperComponentDescriptionColumn
			NewspaperOrderDetailCommentColumn
			NewspaperOrderHouseDetailCommentColumn
			NewspaperExtraChargesColumn
			NewspaperNetAmountColumn
			NewspaperCommissionAmountColumn
			NewspaperTaxAmountColumn
			NewspaperBillAmountColumn
			NewspaperPriorBillAmountColumn
			NewspaperBilledToDateAmountColumn
			NewspaperShowCommissionSeparately
			NewspaperShowRebateSeparately
			NewspaperShowTaxSeparately
			NewspaperShowBillingHistory
			NewspaperCustomFormat
			InternetGroupByMarket
			InternetShowOrderDescription
			InternetShowClientReference
			InternetShowClientPO
			InternetShowOrderComment
			InternetShowOrderHouseComment
			InternetShowLineDetail
			InternetOrderNumberColumn
			InternetVendorNameColumn
			InternetShowVendorCode
			InternetOrderMonthsColumn
			InternetHeadlineColumn
			InternetEndDatesColumn
			InternetCreativeSizeColumn
			InternetAdNumberColumn
			InternetURLColumn
			InternetInternetTypeColumn
			InternetJobComponentNumberColumn
			InternetJobDescriptionColumn
			InternetComponentDescriptionColumn
			InternetExtraChargesColumn
			InternetNetAmountColumn
			InternetCommissionAmountColumn
			InternetTaxAmountColumn
			InternetBillAmountColumn
			InternetPriorBillAmountColumn
			InternetBilledToDateAmountColumn
			InternetShowCommissionSeparately
			InternetShowRebateSeparately
			InternetShowTaxSeparately
			InternetShowBillingHistory
			InternetCustomFormat
			OutdoorGroupByMarket
			OutdoorShowOrderDescription
			OutdoorShowClientReference
			OutdoorShowClientPO
			OutdoorShowOrderComment
			OutdoorShowOrderHouseComment
			OutdoorShowLineDetail
			OutdoorOrderNumberColumn
			OutdoorVendorNameColumn
			OutdoorShowVendorCode
			OutdoorOrderMonthsColumn
			OutdoorHeadlineColumn
			OutdoorInsertDatesColumn
			OutdoorCopyAreaColumn
			OutdoorAdNumberColumn
			OutdoorLocationColumn
			OutdoorOutdoorTypeColumn
			OutdoorSizeColumn
			OutdoorJobComponentNumberColumn
			OutdoorJobDescriptionColumn
			OutdoorComponentDescriptionColumn
			OutdoorExtraChargesColumn
			OutdoorNetAmountColumn
			OutdoorCommissionAmountColumn
			OutdoorTaxAmountColumn
			OutdoorBillAmountColumn
			OutdoorPriorBillAmountColumn
			OutdoorBilledToDateAmountColumn
			OutdoorShowCommissionSeparately
			OutdoorShowRebateSeparately
			OutdoorShowTaxSeparately
			OutdoorShowBillingHistory
			OutOfHomeCustomFormat
			RadioGroupByMarket
			RadioShowOrderDescription
			RadioShowClientReference
			RadioShowClientPO
			RadioShowOrderComment
			RadioShowOrderHouseComment
			RadioShowLineDetail
			RadioOrderNumberColumn
			RadioVendorNameColumn
			RadioShowVendorCode
			RadioOrderMonthsColumn
			RadioProgramColumn
			RadioSpotLengthColumn
			RadioTagColumn
			RadioStartEndTimesColumn
			RadioNumberOfSpotsColumn
			RadioRemarksColumn
			RadioJobComponentNumberColumn
			RadioJobDescriptionColumn
			RadioComponentDescriptionColumn
			RadioOrderDetailCommentColumn
			RadioOrderHouseDetailCommentColumn
			RadioExtraChargesColumn
			RadioNetAmountColumn
			RadioCommissionAmountColumn
			RadioTaxAmountColumn
			RadioBillAmountColumn
			RadioPriorBillAmountColumn
			RadioBilledToDateAmountColumn
			RadioShowCommissionSeparately
			RadioShowRebateSeparately
			RadioShowTaxSeparately
			RadioShowBillingHistory
			RadioCustomFormat
			TVGroupByMarket
			TVShowOrderDescription
			TVShowClientReference
			TVShowClientPO
			TVShowOrderComment
			TVShowOrderHouseComment
			TVShowLineDetail
			TVOrderNumberColumn
			TVVendorNameColumn
			TVShowVendorCode
			TVOrderMonthsColumn
			TVProgramColumn
			TVSpotLengthColumn
			TVTagColumn
			TVStartEndTimesColumn
			TVNumberOfSpotsColumn
			TVRemarksColumn
			TVJobComponentNumberColumn
			TVJobDescriptionColumn
			TVComponentDescriptionColumn
			TVOrderDetailCommentColumn
			TVOrderHouseDetailCommentColumn
			TVExtraChargesColumn
			TVNetAmountColumn
			TVCommissionAmountColumn
			TVTaxAmountColumn
			TVBillAmountColumn
			TVPriorBillAmountColumn
			TVBilledToDateAmountColumn
			TVShowCommissionSeparately
			TVShowRebateSeparately
			TVShowTaxSeparately
			TVShowBillingHistory
			TVCustomFormat
			MagazineInvoiceTitle
			NewspaperInvoiceTitle
			InternetInvoiceTitle
			OutdoorInvoiceTitle
			RadioInvoiceTitle
			TVInvoiceTitle
			MagazineUseInvoiceCategoryDescription
			NewspaperUseInvoiceCategoryDescription
			InternetUseInvoiceCategoryDescription
			OutdoorUseInvoiceCategoryDescription
			RadioUseInvoiceCategoryDescription
			TVUseInvoiceCategoryDescription
			MagazinePrintInvoiceDueDate
			NewspaperPrintInvoiceDueDate
			InternetPrintInvoiceDueDate
			OutdoorPrintInvoiceDueDate
			RadioPrintInvoiceDueDate
			TVPrintInvoiceDueDate
			PrintContactAfterAddress
			InternetStartDatesColumn
			UseLocationPrintOptions
			CustomInvoiceID
			PrintClientName
			MagazineShowCampaign
			NewspaperShowCampaign
			InternetShowCampaign
			OutdoorShowCampaign
			RadioShowCampaign
			TVShowCampaign
			MagazineShowCampaignComment
			NewspaperShowCampaignComment
			InternetShowCampaignComment
			OutdoorShowCampaignComment
			RadioShowCampaignComment
			TVShowCampaignComment
			MagazineShowOrderSubtotals
			NewspaperShowOrderSubtotals
			InternetShowOrderSubtotals
			OutdoorShowOrderSubtotals
			RadioShowOrderSubtotals
			TVShowOrderSubtotals
			ShowCodes
			ContactType
			MagazineHeaderGroupBy
			NewspaperHeaderGroupBy
			InternetHeaderGroupBy
			OutdoorHeaderGroupBy
			RadioHeaderGroupBy
			TVHeaderGroupBy
			MagazineShowSalesClass
			NewspaperShowSalesClass
			InternetShowSalesClass
			OutdoorShowSalesClass
			RadioShowSalesClass
			TVShowSalesClass
			MagazineSalesClassLocation
			NewspaperSalesClassLocation
			InternetSalesClassLocation
			OutdoorSalesClassLocation
			RadioSalesClassLocation
			TVSalesClassLocation
			MagazineClientPOLocation
			NewspaperClientPOLocation
			InternetClientPOLocation
			OutdoorClientPOLocation
			RadioClientPOLocation
			TVClientPOLocation
			MagazineCampaignLocation
			NewspaperCampaignLocation
			InternetCampaignLocation
			OutdoorCampaignLocation
			RadioCampaignLocation
			TVCampaignLocation
			MagazineUseAgencySetting
			NewspaperUseAgencySetting
			InternetUseAgencySetting
			OutdoorUseAgencySetting
			RadioUseAgencySetting
			TVUseAgencySetting
			MagazineSortLinesBy
			NewspaperSortLinesBy
			InternetSortLinesBy
			OutdoorSortLinesBy
			RadioSortLinesBy
			TVSortLinesBy
			MagazineLineNumberColumn
			NewspaperLineNumberColumn
			InternetLineNumberColumn
			OutdoorLineNumberColumn
			RadioLineNumberColumn
			TVLineNumberColumn
			MagazineShowZeroLineAmounts
			NewspaperShowZeroLineAmounts
			InternetShowZeroLineAmounts
			OutdoorShowZeroLineAmounts
			RadioShowZeroLineAmounts
			TVShowZeroLineAmounts
			MagazineCloseDateColumn
			NewspaperCloseDateColumn
			InternetCloseDateColumn
			OutdoorCloseDateColumn
			RadioCloseDateColumn
			TVCloseDateColumn
			MagazineCustomInvoiceID
			NewspaperCustomInvoiceID
			InternetCustomInvoiceID
			OutdoorCustomInvoiceID
			RadioCustomInvoiceID
            TVCustomInvoiceID
            InternetGuaranteedImpressionsColumn
            RadioStartDateColumn
            TVStartDateColumn
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("MEDIA_INV_DEF_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ID() As Integer
		<Column("CLIENT_OR_DEF")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ClientOrDefault() As Nullable(Of Short)
		<MaxLength(6)>
		<Column("CL_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ClientCode() As String
		<MaxLength(6)>
		<Column("LOCATION_ID", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property LocationID() As String
		<MaxLength(50)>
		<Column("PRT_LOC_PG_FTR_DEF", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property LocationCode() As String
		<Column("ADDRESS_BLOCK")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AddressBlockType() As Nullable(Of Short)
		<Column("PRINT_DIV_NAME")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PrintDivisionName() As Nullable(Of Short)
		<Column("PRINT_PRD_DESC")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PrintProductDescription() As Nullable(Of Short)
		<Column("BILL_COMM_INV_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IncludeBillingComment() As Nullable(Of Short)
		<Column("MEDIA_TYPE_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IncludeSalesClass() As Nullable(Of Short)
		<Column("INV_CMP_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IncludeCampaignDescription() As Nullable(Of Short)
		<Column("TOT_PAYMNT_TERMS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InvoiceFooterCommentType() As Nullable(Of Short)
		<MaxLength(50)>
		<Column("TOT_PAYMNT_TERMS_DEF", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InvoiceFooterComment() As String
		<Column("COL_OPT_XCHGE_AMTS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ApplyExchangeRate() As Nullable(Of Short)
		<Column("COL_OPT_XCHGE_DEF")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(10, 4)>
        Public Property ExchangeRateAmount() As Nullable(Of Decimal)
		<MaxLength(50)>
		<Column("CUSTOM_FORMAT", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CustomFormatName() As String
		<Column("M_GROUP_BY_MKT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MagazineGroupByMarket() As Nullable(Of Short)
		<Column("M_ORDER_DESC_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MagazineShowOrderDescription() As Nullable(Of Short)
		<Column("M_INV_REF_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MagazineShowClientReference() As Nullable(Of Short)
		<Column("M_INV_CL_PO_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MagazineShowClientPO() As Nullable(Of Short)
		<Column("M_ORDER_COMM_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MagazineShowOrderComment() As Nullable(Of Short)
		<Column("M_HOUSE_COMM_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MagazineShowOrderHouseComment() As Nullable(Of Short)
		<Column("M_SHOW_LINE_DTL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MagazineShowLineDetail() As Nullable(Of Short)
		<Column("M_ORDER_NBR_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MagazineOrderNumberColumn() As Nullable(Of Short)
		<Column("M_VN_NAME_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MagazineVendorNameColumn() As Nullable(Of Short)
		<Column("M_VN_CODE_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MagazineShowVendorCode() As Nullable(Of Short)
		<Column("M_MONTHS_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MagazineOrderMonthsColumn() As Nullable(Of Short)
		<Column("M_PROG_HDLN_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MagazineHeadlineColumn() As Nullable(Of Short)
		<Column("M_DATES_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MagazineInsertDatesColumn() As Nullable(Of Short)
		<Column("M_LGH_MATL_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MagazineMaterialColumn() As Nullable(Of Short)
		<Column("M_TAG_AD_NBR_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MagazineAdNumberColumn() As Nullable(Of Short)
		<Column("M_TIME_EDIT_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MagazineEditorialIssueColumn() As Nullable(Of Short)
		<Column("M_AD_SIZE_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MagazineAdSizeColumn() As Nullable(Of Short)
		<Column("M_JOB_COMP_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MagazineJobComponentNumberColumn() As Nullable(Of Short)
		<Column("M_JOB_DESC_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MagazineJobDescriptionColumn() As Nullable(Of Short)
		<Column("M_COMP_DESC_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MagazineComponentDescriptionColumn() As Nullable(Of Short)
		<Column("M_ORD_DTL_CMT_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MagazineOrderDetailCommentColumn() As Nullable(Of Short)
		<Column("M_HSE_DTL_CMT_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MagazineOrderHouseDetailCommentColumn() As Nullable(Of Short)
		<Column("M_SHOW_CHARGES_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MagazineExtraChargesColumn() As Nullable(Of Short)
		<Column("M_CUR_NET_AMT_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MagazineNetAmountColumn() As Nullable(Of Short)
		<Column("M_CUR_COMM_AMT_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MagazineCommissionAmountColumn() As Nullable(Of Short)
		<Column("M_CUR_TAX_AMT_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MagazineTaxAmountColumn() As Nullable(Of Short)
		<Column("M_CUR_BILL_AMT_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MagazineBillAmountColumn() As Nullable(Of Short)
		<Column("M_PREV_BILL_AMT_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MagazinePriorBillAmountColumn() As Nullable(Of Short)
		<Column("M_TOT_BILL_AMT_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MagazineBilledToDateAmountColumn() As Nullable(Of Short)
		<Column("M_SHOW_COMM")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MagazineShowCommissionSeparately() As Nullable(Of Short)
		<Column("M_SHOW_REBATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MagazineShowRebateSeparately() As Nullable(Of Short)
		<Column("M_SHOW_TAX")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MagazineShowTaxSeparately() As Nullable(Of Short)
		<Column("M_TOT_SHOW_BILL_HIST")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MagazineShowBillingHistory() As Nullable(Of Short)
		<MaxLength(50)>
		<Column("M_CUSTOM_FORMAT", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MagazineCustomFormat() As String
		<Column("N_GROUP_BY_MKT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NewspaperGroupByMarket() As Nullable(Of Short)
		<Column("N_ORDER_DESC_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NewspaperShowOrderDescription() As Nullable(Of Short)
		<Column("N_INV_REF_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NewspaperShowClientReference() As Nullable(Of Short)
		<Column("N_INV_CL_PO_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NewspaperShowClientPO() As Nullable(Of Short)
		<Column("N_ORDER_COMM_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NewspaperShowOrderComment() As Nullable(Of Short)
		<Column("N_HOUSE_COMM_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NewspaperShowOrderHouseComment() As Nullable(Of Short)
		<Column("N_SHOW_LINE_DTL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NewspaperShowLineDetail() As Nullable(Of Short)
		<Column("N_ORDER_NBR_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NewspaperOrderNumberColumn() As Nullable(Of Short)
		<Column("N_VN_NAME_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NewspaperVendorNameColumn() As Nullable(Of Short)
		<Column("N_VN_CODE_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NewspaperShowVendorCode() As Nullable(Of Short)
		<Column("N_MONTHS_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NewspaperOrderMonthsColumn() As Nullable(Of Short)
		<Column("N_PROG_HDLN_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NewspaperHeadlineColumn() As Nullable(Of Short)
		<Column("N_DATES_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NewspaperInsertDatesColumn() As Nullable(Of Short)
		<Column("N_LGH_MATL_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NewspaperMaterialColumn() As Nullable(Of Short)
		<Column("N_TAG_AD_NBR_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NewspaperAdNumberColumn() As Nullable(Of Short)
		<Column("N_TIME_EDIT_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NewspaperEditorialIssueColumn() As Nullable(Of Short)
		<Column("N_SECTION_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NewspaperSectionColumn() As Nullable(Of Short)
		<Column("N_SPOTS_QTY_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NewspaperQuantityColumn() As Nullable(Of Short)
		<Column("N_AD_SIZE_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NewspaperAdSizeColumn() As Nullable(Of Short)
		<Column("N_JOB_COMP_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NewspaperJobComponentNumberColumn() As Nullable(Of Short)
		<Column("N_JOB_DESC_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NewspaperJobDescriptionColumn() As Nullable(Of Short)
		<Column("N_COMP_DESC_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NewspaperComponentDescriptionColumn() As Nullable(Of Short)
		<Column("N_ORD_DTL_CMT_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NewspaperOrderDetailCommentColumn() As Nullable(Of Short)
		<Column("N_HSE_DTL_CMT_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NewspaperOrderHouseDetailCommentColumn() As Nullable(Of Short)
		<Column("N_SHOW_CHARGES_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NewspaperExtraChargesColumn() As Nullable(Of Short)
		<Column("N_CUR_NET_AMT_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NewspaperNetAmountColumn() As Nullable(Of Short)
		<Column("N_CUR_COMM_AMT_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NewspaperCommissionAmountColumn() As Nullable(Of Short)
		<Column("N_CUR_TAX_AMT_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NewspaperTaxAmountColumn() As Nullable(Of Short)
		<Column("N_CUR_BILL_AMT_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NewspaperBillAmountColumn() As Nullable(Of Short)
		<Column("N_PREV_BILL_AMT_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NewspaperPriorBillAmountColumn() As Nullable(Of Short)
		<Column("N_TOT_BILL_AMT_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NewspaperBilledToDateAmountColumn() As Nullable(Of Short)
		<Column("N_SHOW_COMM")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NewspaperShowCommissionSeparately() As Nullable(Of Short)
		<Column("N_SHOW_REBATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NewspaperShowRebateSeparately() As Nullable(Of Short)
		<Column("N_SHOW_TAX")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NewspaperShowTaxSeparately() As Nullable(Of Short)
		<Column("N_TOT_SHOW_BILL_HIST")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NewspaperShowBillingHistory() As Nullable(Of Short)
		<MaxLength(50)>
		<Column("N_CUSTOM_FORMAT", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NewspaperCustomFormat() As String
		<Column("I_GROUP_BY_MKT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InternetGroupByMarket() As Nullable(Of Short)
		<Column("I_ORDER_DESC_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InternetShowOrderDescription() As Nullable(Of Short)
		<Column("I_INV_REF_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InternetShowClientReference() As Nullable(Of Short)
		<Column("I_INV_CL_PO_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InternetShowClientPO() As Nullable(Of Short)
		<Column("I_ORDER_COMM_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InternetShowOrderComment() As Nullable(Of Short)
		<Column("I_HOUSE_COMM_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InternetShowOrderHouseComment() As Nullable(Of Short)
		<Column("I_SHOW_LINE_DTL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InternetShowLineDetail() As Nullable(Of Short)
		<Column("I_ORDER_NBR_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InternetOrderNumberColumn() As Nullable(Of Short)
		<Column("I_VN_NAME_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InternetVendorNameColumn() As Nullable(Of Short)
		<Column("I_VN_CODE_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InternetShowVendorCode() As Nullable(Of Short)
		<Column("I_MONTHS_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InternetOrderMonthsColumn() As Nullable(Of Short)
		<Column("I_PROG_HDLN_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InternetHeadlineColumn() As Nullable(Of Short)
		<Column("I_DATES_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InternetEndDatesColumn() As Nullable(Of Short)
		<Column("I_LGH_MATL_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InternetCreativeSizeColumn() As Nullable(Of Short)
		<Column("I_TAG_AD_NBR_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InternetAdNumberColumn() As Nullable(Of Short)
		<Column("I_TIME_EDIT_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InternetURLColumn() As Nullable(Of Short)
		<Column("I_SUB_TYPE_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InternetInternetTypeColumn() As Nullable(Of Short)
		<Column("I_JOB_COMP_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InternetJobComponentNumberColumn() As Nullable(Of Short)
		<Column("I_JOB_DESC_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InternetJobDescriptionColumn() As Nullable(Of Short)
		<Column("I_COMP_DESC_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InternetComponentDescriptionColumn() As Nullable(Of Short)
		<Column("I_SHOW_CHARGES_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InternetExtraChargesColumn() As Nullable(Of Short)
		<Column("I_CUR_NET_AMT_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InternetNetAmountColumn() As Nullable(Of Short)
		<Column("I_CUR_COMM_AMT_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InternetCommissionAmountColumn() As Nullable(Of Short)
		<Column("I_CUR_TAX_AMT_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InternetTaxAmountColumn() As Nullable(Of Short)
		<Column("I_CUR_BILL_AMT_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InternetBillAmountColumn() As Nullable(Of Short)
		<Column("I_PREV_BILL_AMT_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InternetPriorBillAmountColumn() As Nullable(Of Short)
		<Column("I_TOT_BILL_AMT_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InternetBilledToDateAmountColumn() As Nullable(Of Short)
		<Column("I_SHOW_COMM")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InternetShowCommissionSeparately() As Nullable(Of Short)
		<Column("I_SHOW_REBATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InternetShowRebateSeparately() As Nullable(Of Short)
		<Column("I_SHOW_TAX")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InternetShowTaxSeparately() As Nullable(Of Short)
		<Column("I_TOT_SHOW_BILL_HIST")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InternetShowBillingHistory() As Nullable(Of Short)
		<MaxLength(50)>
		<Column("I_CUSTOM_FORMAT", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InternetCustomFormat() As String
		<Column("O_GROUP_BY_MKT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OutdoorGroupByMarket() As Nullable(Of Short)
		<Column("O_ORDER_DESC_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OutdoorShowOrderDescription() As Nullable(Of Short)
		<Column("O_INV_REF_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OutdoorShowClientReference() As Nullable(Of Short)
		<Column("O_INV_CL_PO_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OutdoorShowClientPO() As Nullable(Of Short)
		<Column("O_ORDER_COMM_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OutdoorShowOrderComment() As Nullable(Of Short)
		<Column("O_HOUSE_COMM_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OutdoorShowOrderHouseComment() As Nullable(Of Short)
		<Column("O_SHOW_LINE_DTL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OutdoorShowLineDetail() As Nullable(Of Short)
		<Column("O_ORDER_NBR_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OutdoorOrderNumberColumn() As Nullable(Of Short)
		<Column("O_VN_NAME_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OutdoorVendorNameColumn() As Nullable(Of Short)
		<Column("O_VN_CODE_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OutdoorShowVendorCode() As Nullable(Of Short)
		<Column("O_MONTHS_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OutdoorOrderMonthsColumn() As Nullable(Of Short)
		<Column("O_PROG_HDLN_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OutdoorHeadlineColumn() As Nullable(Of Short)
		<Column("O_DATES_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OutdoorInsertDatesColumn() As Nullable(Of Short)
		<Column("O_LGH_MATL_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OutdoorCopyAreaColumn() As Nullable(Of Short)
		<Column("O_TAG_AD_NBR_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OutdoorAdNumberColumn() As Nullable(Of Short)
		<Column("O_TIME_EDIT_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OutdoorLocationColumn() As Nullable(Of Short)
		<Column("O_SUB_TYPE_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OutdoorOutdoorTypeColumn() As Nullable(Of Short)
		<Column("O_AD_SIZE_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OutdoorSizeColumn() As Nullable(Of Short)
		<Column("O_JOB_COMP_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OutdoorJobComponentNumberColumn() As Nullable(Of Short)
		<Column("O_JOB_DESC_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OutdoorJobDescriptionColumn() As Nullable(Of Short)
		<Column("O_COMP_DESC_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OutdoorComponentDescriptionColumn() As Nullable(Of Short)
		<Column("O_SHOW_CHARGES_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OutdoorExtraChargesColumn() As Nullable(Of Short)
		<Column("O_CUR_NET_AMT_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OutdoorNetAmountColumn() As Nullable(Of Short)
		<Column("O_CUR_COMM_AMT_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OutdoorCommissionAmountColumn() As Nullable(Of Short)
		<Column("O_CUR_TAX_AMT_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OutdoorTaxAmountColumn() As Nullable(Of Short)
		<Column("O_CUR_BILL_AMT_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OutdoorBillAmountColumn() As Nullable(Of Short)
		<Column("O_PREV_BILL_AMT_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OutdoorPriorBillAmountColumn() As Nullable(Of Short)
		<Column("O_TOT_BILL_AMT_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OutdoorBilledToDateAmountColumn() As Nullable(Of Short)
		<Column("O_SHOW_COMM")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OutdoorShowCommissionSeparately() As Nullable(Of Short)
		<Column("O_SHOW_REBATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OutdoorShowRebateSeparately() As Nullable(Of Short)
		<Column("O_SHOW_TAX")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OutdoorShowTaxSeparately() As Nullable(Of Short)
		<Column("O_TOT_SHOW_BILL_HIST")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OutdoorShowBillingHistory() As Nullable(Of Short)
		<MaxLength(50)>
		<Column("O_CUSTOM_FORMAT", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OutOfHomeCustomFormat() As String
		<Column("R_GROUP_BY_MKT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RadioGroupByMarket() As Nullable(Of Short)
		<Column("R_ORDER_DESC_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RadioShowOrderDescription() As Nullable(Of Short)
		<Column("R_INV_REF_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RadioShowClientReference() As Nullable(Of Short)
		<Column("R_INV_CL_PO_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RadioShowClientPO() As Nullable(Of Short)
		<Column("R_ORDER_COMM_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RadioShowOrderComment() As Nullable(Of Short)
		<Column("R_HOUSE_COMM_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RadioShowOrderHouseComment() As Nullable(Of Short)
		<Column("R_SHOW_LINE_DTL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RadioShowLineDetail() As Nullable(Of Short)
		<Column("R_ORDER_NBR_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RadioOrderNumberColumn() As Nullable(Of Short)
		<Column("R_VN_NAME_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RadioVendorNameColumn() As Nullable(Of Short)
		<Column("R_VN_CODE_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RadioShowVendorCode() As Nullable(Of Short)
		<Column("R_MONTHS_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RadioOrderMonthsColumn() As Nullable(Of Short)
		<Column("R_PROG_HDLN_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RadioProgramColumn() As Nullable(Of Short)
		<Column("R_LGH_MATL_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RadioSpotLengthColumn() As Nullable(Of Short)
		<Column("R_TAG_AD_NBR_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RadioTagColumn() As Nullable(Of Short)
		<Column("R_TIME_EDIT_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RadioStartEndTimesColumn() As Nullable(Of Short)
		<Column("R_SPOTS_QTY_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RadioNumberOfSpotsColumn() As Nullable(Of Short)
		<Column("R_REMARKS_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RadioRemarksColumn() As Nullable(Of Short)
		<Column("R_JOB_COMP_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RadioJobComponentNumberColumn() As Nullable(Of Short)
		<Column("R_JOB_DESC_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RadioJobDescriptionColumn() As Nullable(Of Short)
		<Column("R_COMP_DESC_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RadioComponentDescriptionColumn() As Nullable(Of Short)
		<Column("R_ORD_DTL_CMT_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RadioOrderDetailCommentColumn() As Nullable(Of Short)
		<Column("R_HSE_DTL_CMT_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RadioOrderHouseDetailCommentColumn() As Nullable(Of Short)
		<Column("R_SHOW_CHARGES_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RadioExtraChargesColumn() As Nullable(Of Short)
		<Column("R_CUR_NET_AMT_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RadioNetAmountColumn() As Nullable(Of Short)
		<Column("R_CUR_COMM_AMT_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RadioCommissionAmountColumn() As Nullable(Of Short)
		<Column("R_CUR_TAX_AMT_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RadioTaxAmountColumn() As Nullable(Of Short)
		<Column("R_CUR_BILL_AMT_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RadioBillAmountColumn() As Nullable(Of Short)
		<Column("R_PREV_BILL_AMT_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RadioPriorBillAmountColumn() As Nullable(Of Short)
		<Column("R_TOT_BILL_AMT_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RadioBilledToDateAmountColumn() As Nullable(Of Short)
		<Column("R_SHOW_COMM")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RadioShowCommissionSeparately() As Nullable(Of Short)
		<Column("R_SHOW_REBATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RadioShowRebateSeparately() As Nullable(Of Short)
		<Column("R_SHOW_TAX")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RadioShowTaxSeparately() As Nullable(Of Short)
		<Column("R_TOT_SHOW_BILL_HIST")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RadioShowBillingHistory() As Nullable(Of Short)
		<MaxLength(50)>
		<Column("R_CUSTOM_FORMAT", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RadioCustomFormat() As String
		<Column("T_GROUP_BY_MKT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TVGroupByMarket() As Nullable(Of Short)
		<Column("T_ORDER_DESC_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TVShowOrderDescription() As Nullable(Of Short)
		<Column("T_INV_REF_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TVShowClientReference() As Nullable(Of Short)
		<Column("T_INV_CL_PO_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TVShowClientPO() As Nullable(Of Short)
		<Column("T_ORDER_COMM_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TVShowOrderComment() As Nullable(Of Short)
		<Column("T_HOUSE_COMM_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TVShowOrderHouseComment() As Nullable(Of Short)
		<Column("T_SHOW_LINE_DTL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TVShowLineDetail() As Nullable(Of Short)
		<Column("T_ORDER_NBR_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TVOrderNumberColumn() As Nullable(Of Short)
		<Column("T_VN_NAME_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TVVendorNameColumn() As Nullable(Of Short)
		<Column("T_VN_CODE_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TVShowVendorCode() As Nullable(Of Short)
		<Column("T_MONTHS_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TVOrderMonthsColumn() As Nullable(Of Short)
		<Column("T_PROG_HDLN_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TVProgramColumn() As Nullable(Of Short)
		<Column("T_LGH_MATL_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TVSpotLengthColumn() As Nullable(Of Short)
		<Column("T_TAG_AD_NBR_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TVTagColumn() As Nullable(Of Short)
		<Column("T_TIME_EDIT_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TVStartEndTimesColumn() As Nullable(Of Short)
		<Column("T_SPOTS_QTY_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TVNumberOfSpotsColumn() As Nullable(Of Short)
		<Column("T_REMARKS_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TVRemarksColumn() As Nullable(Of Short)
		<Column("T_JOB_COMP_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TVJobComponentNumberColumn() As Nullable(Of Short)
		<Column("T_JOB_DESC_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TVJobDescriptionColumn() As Nullable(Of Short)
		<Column("T_COMP_DESC_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TVComponentDescriptionColumn() As Nullable(Of Short)
		<Column("T_ORD_DTL_CMT_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TVOrderDetailCommentColumn() As Nullable(Of Short)
		<Column("T_HSE_DTL_CMT_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TVOrderHouseDetailCommentColumn() As Nullable(Of Short)
		<Column("T_SHOW_CHARGES_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TVExtraChargesColumn() As Nullable(Of Short)
		<Column("T_CUR_NET_AMT_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TVNetAmountColumn() As Nullable(Of Short)
		<Column("T_CUR_COMM_AMT_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TVCommissionAmountColumn() As Nullable(Of Short)
		<Column("T_CUR_TAX_AMT_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TVTaxAmountColumn() As Nullable(Of Short)
		<Column("T_CUR_BILL_AMT_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TVBillAmountColumn() As Nullable(Of Short)
		<Column("T_PREV_BILL_AMT_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TVPriorBillAmountColumn() As Nullable(Of Short)
		<Column("T_TOT_BILL_AMT_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TVBilledToDateAmountColumn() As Nullable(Of Short)
		<Column("T_SHOW_COMM")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TVShowCommissionSeparately() As Nullable(Of Short)
		<Column("T_SHOW_REBATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TVShowRebateSeparately() As Nullable(Of Short)
		<Column("T_SHOW_TAX")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TVShowTaxSeparately() As Nullable(Of Short)
		<Column("T_TOT_SHOW_BILL_HIST")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TVShowBillingHistory() As Nullable(Of Short)
		<MaxLength(50)>
		<Column("T_CUSTOM_FORMAT", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TVCustomFormat() As String
		<MaxLength(20)>
		<Column("M_INV_TITLE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MagazineInvoiceTitle() As String
		<MaxLength(20)>
		<Column("N_INV_TITLE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NewspaperInvoiceTitle() As String
		<MaxLength(20)>
		<Column("I_INV_TITLE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InternetInvoiceTitle() As String
		<MaxLength(20)>
		<Column("O_INV_TITLE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OutdoorInvoiceTitle() As String
		<MaxLength(20)>
		<Column("R_INV_TITLE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RadioInvoiceTitle() As String
		<MaxLength(20)>
		<Column("T_INV_TITLE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TVInvoiceTitle() As String
		<Column("M_INV_CAT_TITLE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MagazineUseInvoiceCategoryDescription() As Nullable(Of Short)
		<Column("N_INV_CAT_TITLE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NewspaperUseInvoiceCategoryDescription() As Nullable(Of Short)
		<Column("I_INV_CAT_TITLE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InternetUseInvoiceCategoryDescription() As Nullable(Of Short)
		<Column("O_INV_CAT_TITLE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OutdoorUseInvoiceCategoryDescription() As Nullable(Of Short)
		<Column("R_INV_CAT_TITLE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RadioUseInvoiceCategoryDescription() As Nullable(Of Short)
		<Column("T_INV_CAT_TITLE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TVUseInvoiceCategoryDescription() As Nullable(Of Short)
		<Column("M_PRT_DUE_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MagazinePrintInvoiceDueDate() As Nullable(Of Short)
		<Column("N_PRT_DUE_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NewspaperPrintInvoiceDueDate() As Nullable(Of Short)
		<Column("I_PRT_DUE_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InternetPrintInvoiceDueDate() As Nullable(Of Short)
		<Column("O_PRT_DUE_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OutdoorPrintInvoiceDueDate() As Nullable(Of Short)
		<Column("R_PRT_DUE_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RadioPrintInvoiceDueDate() As Nullable(Of Short)
		<Column("T_PRT_DUE_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TVPrintInvoiceDueDate() As Nullable(Of Short)
		<Column("CONTACT_POS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PrintContactAfterAddress() As Nullable(Of Short)
		<Column("I_START_DATE_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InternetStartDatesColumn() As Nullable(Of Short)
		<Column("PRT_LOC_PG_FTR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UseLocationPrintOptions() As Nullable(Of Short)
		<Column("CUSTOM_INVOICE_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CustomInvoiceID() As Nullable(Of Integer)
		<Required>
		<Column("PRINT_CLIENT_NAME")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PrintClientName() As Boolean
		<Required>
		<Column("M_SHOW_CAMPAIGN")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MagazineShowCampaign() As Boolean
		<Required>
		<Column("N_SHOW_CAMPAIGN")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NewspaperShowCampaign() As Boolean
		<Required>
		<Column("I_SHOW_CAMPAIGN")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InternetShowCampaign() As Boolean
		<Required>
		<Column("O_SHOW_CAMPAIGN")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OutdoorShowCampaign() As Boolean
		<Required>
		<Column("R_SHOW_CAMPAIGN")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RadioShowCampaign() As Boolean
		<Required>
		<Column("T_SHOW_CAMPAIGN")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TVShowCampaign() As Boolean
		<Required>
		<Column("M_SHOW_CAMPAIGN_COMMENT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MagazineShowCampaignComment() As Boolean
		<Required>
		<Column("N_SHOW_CAMPAIGN_COMMENT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NewspaperShowCampaignComment() As Boolean
		<Required>
		<Column("I_SHOW_CAMPAIGN_COMMENT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InternetShowCampaignComment() As Boolean
		<Required>
		<Column("O_SHOW_CAMPAIGN_COMMENT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OutdoorShowCampaignComment() As Boolean
		<Required>
		<Column("R_SHOW_CAMPAIGN_COMMENT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RadioShowCampaignComment() As Boolean
		<Required>
		<Column("T_SHOW_CAMPAIGN_COMMENT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TVShowCampaignComment() As Boolean
		<Required>
		<Column("M_SHOW_ORDER_SUBTOTALS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MagazineShowOrderSubtotals() As Boolean
		<Required>
		<Column("N_SHOW_ORDER_SUBTOTALS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NewspaperShowOrderSubtotals() As Boolean
		<Required>
		<Column("I_SHOW_ORDER_SUBTOTALS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InternetShowOrderSubtotals() As Boolean
		<Required>
		<Column("O_SHOW_ORDER_SUBTOTALS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OutdoorShowOrderSubtotals() As Boolean
		<Required>
		<Column("R_SHOW_ORDER_SUBTOTALS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RadioShowOrderSubtotals() As Boolean
		<Required>
		<Column("T_SHOW_ORDER_SUBTOTALS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TVShowOrderSubtotals() As Boolean
		<Required>
		<Column("SHOW_CODES")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ShowCodes() As Boolean
		<Required>
		<Column("CONTACT_TYPE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ContactType() As Integer
		<Required>
		<Column("M_HEADER_GROUP_BY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MagazineHeaderGroupBy() As Integer
		<Required>
		<Column("N_HEADER_GROUP_BY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NewspaperHeaderGroupBy() As Integer
		<Required>
		<Column("I_HEADER_GROUP_BY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InternetHeaderGroupBy() As Integer
		<Required>
		<Column("O_HEADER_GROUP_BY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OutdoorHeaderGroupBy() As Integer
		<Required>
		<Column("R_HEADER_GROUP_BY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RadioHeaderGroupBy() As Integer
		<Required>
		<Column("T_HEADER_GROUP_BY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TVHeaderGroupBy() As Integer
		<Required>
		<Column("M_SHOW_SALES_CLASS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MagazineShowSalesClass() As Boolean
		<Required>
		<Column("N_SHOW_SALES_CLASS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NewspaperShowSalesClass() As Boolean
		<Required>
		<Column("I_SHOW_SALES_CLASS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InternetShowSalesClass() As Boolean
		<Required>
		<Column("O_SHOW_SALES_CLASS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OutdoorShowSalesClass() As Boolean
		<Required>
		<Column("R_SHOW_SALES_CLASS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RadioShowSalesClass() As Boolean
		<Required>
		<Column("T_SHOW_SALES_CLASS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TVShowSalesClass() As Boolean
		<Required>
		<Column("M_SALES_CLASS_LOCATION")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MagazineSalesClassLocation() As Integer
		<Required>
		<Column("N_SALES_CLASS_LOCATION")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NewspaperSalesClassLocation() As Integer
		<Required>
		<Column("I_SALES_CLASS_LOCATION")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InternetSalesClassLocation() As Integer
		<Required>
		<Column("O_SALES_CLASS_LOCATION")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OutdoorSalesClassLocation() As Integer
		<Required>
		<Column("R_SALES_CLASS_LOCATION")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RadioSalesClassLocation() As Integer
		<Required>
		<Column("T_SALES_CLASS_LOCATION")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TVSalesClassLocation() As Integer
		<Required>
		<Column("M_CLIENT_PO_LOCATION")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MagazineClientPOLocation() As Integer
		<Required>
		<Column("N_CLIENT_PO_LOCATION")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NewspaperClientPOLocation() As Integer
		<Required>
		<Column("I_CLIENT_PO_LOCATION")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InternetClientPOLocation() As Integer
		<Required>
		<Column("O_CLIENT_PO_LOCATION")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OutdoorClientPOLocation() As Integer
		<Required>
		<Column("R_CLIENT_PO_LOCATION")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RadioClientPOLocation() As Integer
		<Required>
		<Column("T_CLIENT_PO_LOCATION")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TVClientPOLocation() As Integer
		<Required>
		<Column("M_CAMPAIGN_LOCATION")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MagazineCampaignLocation() As Integer
		<Required>
		<Column("N_CAMPAIGN_LOCATION")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NewspaperCampaignLocation() As Integer
		<Required>
		<Column("I_CAMPAIGN_LOCATION")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InternetCampaignLocation() As Integer
		<Required>
		<Column("O_CAMPAIGN_LOCATION")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OutdoorCampaignLocation() As Integer
		<Required>
		<Column("R_CAMPAIGN_LOCATION")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RadioCampaignLocation() As Integer
		<Required>
		<Column("T_CAMPAIGN_LOCATION")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TVCampaignLocation() As Integer
		<Required>
		<Column("M_USE_AGENCY_SETTING")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MagazineUseAgencySetting() As Boolean
		<Required>
		<Column("N_USE_AGENCY_SETTING")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NewspaperUseAgencySetting() As Boolean
		<Required>
		<Column("I_USE_AGENCY_SETTING")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InternetUseAgencySetting() As Boolean
		<Required>
		<Column("O_USE_AGENCY_SETTING")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OutdoorUseAgencySetting() As Boolean
		<Required>
		<Column("R_USE_AGENCY_SETTING")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RadioUseAgencySetting() As Boolean
		<Required>
		<Column("T_USE_AGENCY_SETTING")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TVUseAgencySetting() As Boolean
		<Required>
		<Column("M_SORT_LINES_BY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MagazineSortLinesBy() As Integer
		<Required>
		<Column("N_SORT_LINES_BY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NewspaperSortLinesBy() As Integer
		<Required>
		<Column("I_SORT_LINES_BY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InternetSortLinesBy() As Integer
		<Required>
		<Column("O_SORT_LINES_BY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OutdoorSortLinesBy() As Integer
		<Required>
		<Column("R_SORT_LINES_BY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RadioSortLinesBy() As Integer
		<Required>
		<Column("T_SORT_LINES_BY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TVSortLinesBy() As Integer
		<Required>
		<Column("M_LINE_NUMBER_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MagazineLineNumberColumn() As Short
		<Required>
		<Column("N_LINE_NUMBER_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NewspaperLineNumberColumn() As Short
		<Required>
		<Column("I_LINE_NUMBER_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InternetLineNumberColumn() As Short
		<Required>
		<Column("O_LINE_NUMBER_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OutdoorLineNumberColumn() As Short
		<Required>
		<Column("R_LINE_NUMBER_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RadioLineNumberColumn() As Short
		<Required>
		<Column("T_LINE_NUMBER_INCL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TVLineNumberColumn() As Short
		<Required>
		<Column("M_SHOW_ZERO_LINE_AMOUNTS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MagazineShowZeroLineAmounts() As Boolean
		<Required>
		<Column("N_SHOW_ZERO_LINE_AMOUNTS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NewspaperShowZeroLineAmounts() As Boolean
		<Required>
		<Column("I_SHOW_ZERO_LINE_AMOUNTS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InternetShowZeroLineAmounts() As Boolean
		<Required>
		<Column("O_SHOW_ZERO_LINE_AMOUNTS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OutdoorShowZeroLineAmounts() As Boolean
		<Required>
		<Column("R_SHOW_ZERO_LINE_AMOUNTS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RadioShowZeroLineAmounts() As Boolean
		<Required>
		<Column("T_SHOW_ZERO_LINE_AMOUNTS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TVShowZeroLineAmounts() As Boolean
		<Required>
		<Column("M_CLOSE_DATE_INCL")>
		Public Property MagazineCloseDateColumn() As Short
		<Required>
		<Column("N_CLOSE_DATE_INCL")>
		Public Property NewspaperCloseDateColumn() As Short
		<Required>
		<Column("I_CLOSE_DATE_INCL")>
		Public Property InternetCloseDateColumn() As Short
		<Required>
		<Column("O_CLOSE_DATE_INCL")>
		Public Property OutdoorCloseDateColumn() As Short
		<Required>
		<Column("R_CLOSE_DATE_INCL")>
		Public Property RadioCloseDateColumn() As Short
		<Required>
		<Column("T_CLOSE_DATE_INCL")>
		Public Property TVCloseDateColumn() As Short
		<Column("M_CUSTOM_INVOICE_ID")>
		Public Property MagazineCustomInvoiceID() As Nullable(Of Integer)
		<Column("N_CUSTOM_INVOICE_ID")>
		Public Property NewspaperCustomInvoiceID() As Nullable(Of Integer)
		<Column("I_CUSTOM_INVOICE_ID")>
		Public Property InternetCustomInvoiceID() As Nullable(Of Integer)
		<Column("O_CUSTOM_INVOICE_ID")>
		Public Property OutdoorCustomInvoiceID() As Nullable(Of Integer)
		<Column("R_CUSTOM_INVOICE_ID")>
		Public Property RadioCustomInvoiceID() As Nullable(Of Integer)
		<Column("T_CUSTOM_INVOICE_ID")>
		Public Property TVCustomInvoiceID() As Nullable(Of Integer)
        <Column("O_END_DATE_INCL")>
        Public Property OutdoorEndDateColumn() As Short
        <Required>
        <Column("HIDE_EXCHANGE_RATE_MESSAGE")>
        Public Property HideExchangeRateMessage As Boolean
        <Required>
        <Column("I_GUARANTEED_IMPRESSIONS_COLUMN")>
        Public Property InternetGuaranteedImpressionsColumn As Short
        <Required>
        <Column("R_START_DATE_COLUMN")>
        Public Property RadioStartDateColumn As Short
        <Required>
        <Column("T_START_DATE_COLUMN")>
        Public Property TVStartDateColumn As Short

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

	End Class

End Namespace
