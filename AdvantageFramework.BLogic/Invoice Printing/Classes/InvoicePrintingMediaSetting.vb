Namespace InvoicePrinting.Classes

    <Serializable()>
    Public Class InvoicePrintingMediaSetting

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            IsOneTime
            Type
            ClientCode
            AddressBlockType
            CustomFormatName
            PrintDivisionName
            PrintProductDescription
            PrintContactAfterAddress
            ContactType
            IncludeBillingComment
            ApplyExchangeRate
            ExchangeRateAmount
            InvoiceFooterCommentType
            InvoiceFooterComment
            LocationCode
            ShowCodes
            MagazineInvoiceTitle
            MagazineUseInvoiceCategoryDescription
            MagazineGroupByMarket
            MagazineShowOrderDescription
            MagazineShowClientReference
            MagazineShowClientPO
            MagazineShowOrderComment
            MagazineShowOrderHouseComment
            MagazinePrintInvoiceDueDate
            MagazineOrderNumberColumn
            MagazineVendorNameColumn
            MagazineShowVendorCode
            MagazineOrderMonthsColumn
            MagazineNetAmountColumn
            MagazineCommissionAmountColumn
            MagazineTaxAmountColumn
            MagazineBillAmountColumn
            MagazinePriorBillAmountColumn
            MagazineBilledToDateAmountColumn
            MagazineShowLineDetail
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
            MagazineShowCommissionSeparately
            MagazineShowRebateSeparately
            MagazineShowTaxSeparately
            MagazineShowBillingHistory
            MagazineCustomFormatName
            NewspaperInvoiceTitle
            NewspaperUseInvoiceCategoryDescription
            NewspaperGroupByMarket
            NewspaperShowOrderDescription
            NewspaperShowClientReference
            NewspaperShowClientPO
            NewspaperShowOrderComment
            NewspaperShowOrderHouseComment
            NewspaperPrintInvoiceDueDate
            NewspaperOrderNumberColumn
            NewspaperVendorNameColumn
            NewspaperShowVendorCode
            NewspaperOrderMonthsColumn
            NewspaperNetAmountColumn
            NewspaperCommissionAmountColumn
            NewspaperTaxAmountColumn
            NewspaperBillAmountColumn
            NewspaperPriorBillAmountColumn
            NewspaperBilledToDateAmountColumn
            NewspaperShowLineDetail
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
            NewspaperShowCommissionSeparately
            NewspaperShowRebateSeparately
            NewspaperShowTaxSeparately
            NewspaperShowBillingHistory
            NewspaperCustomFormatName
            InternetInvoiceTitle
            InternetUseInvoiceCategoryDescription
            InternetGroupByMarket
            InternetShowOrderDescription
            InternetShowClientReference
            InternetShowClientPO
            InternetShowOrderComment
            InternetShowOrderHouseComment
            InternetPrintInvoiceDueDate
            InternetOrderNumberColumn
            InternetVendorNameColumn
            InternetShowVendorCode
            InternetOrderMonthsColumn
            InternetNetAmountColumn
            InternetCommissionAmountColumn
            InternetTaxAmountColumn
            InternetBillAmountColumn
            InternetPriorBillAmountColumn
            InternetBilledToDateAmountColumn
            InternetShowLineDetail
            InternetHeadlineColumn
            InternetStartDatesColumn
            InternetEndDatesColumn
            InternetCreativeSizeColumn
            InternetAdNumberColumn
            InternetURLColumn
            InternetInternetTypeColumn
            InternetJobComponentNumberColumn
            InternetJobDescriptionColumn
            InternetComponentDescriptionColumn
            InternetExtraChargesColumn
            InternetShowCommissionSeparately
            InternetShowRebateSeparately
            InternetShowTaxSeparately
            InternetShowBillingHistory
            InternetCustomFormatName
            OutdoorInvoiceTitle
            OutdoorUseInvoiceCategoryDescription
            OutdoorGroupByMarket
            OutdoorShowOrderDescription
            OutdoorShowClientReference
            OutdoorShowClientPO
            OutdoorShowOrderComment
            OutdoorShowOrderHouseComment
            OutdoorPrintInvoiceDueDate
            OutdoorOrderNumberColumn
            OutdoorVendorNameColumn
            OutdoorShowVendorCode
            OutdoorOrderMonthsColumn
            OutdoorNetAmountColumn
            OutdoorCommissionAmountColumn
            OutdoorTaxAmountColumn
            OutdoorBillAmountColumn
            OutdoorPriorBillAmountColumn
            OutdoorBilledToDateAmountColumn
            OutdoorShowLineDetail
            OutdoorHeadlineColumn
			OutdoorInsertDatesColumn
			OutdoorEndDateColumn
			OutdoorCopyAreaColumn
            OutdoorAdNumberColumn
            OutdoorLocationColumn
            OutdoorOutdoorTypeColumn
            OutdoorSizeColumn
            OutdoorJobComponentNumberColumn
            OutdoorJobDescriptionColumn
            OutdoorComponentDescriptionColumn
            OutdoorExtraChargesColumn
            OutdoorShowCommissionSeparately
            OutdoorShowRebateSeparately
            OutdoorShowTaxSeparately
            OutdoorShowBillingHistory
            OutdoorCustomFormatName
            RadioInvoiceTitle
            RadioUseInvoiceCategoryDescription
            RadioGroupByMarket
            RadioShowOrderDescription
            RadioShowClientReference
            RadioShowClientPO
            RadioShowOrderComment
            RadioShowOrderHouseComment
            RadioPrintInvoiceDueDate
            RadioOrderNumberColumn
            RadioVendorNameColumn
            RadioShowVendorCode
            RadioOrderMonthsColumn
            RadioNetAmountColumn
            RadioCommissionAmountColumn
            RadioTaxAmountColumn
            RadioBillAmountColumn
            RadioPriorBillAmountColumn
            RadioBilledToDateAmountColumn
            RadioShowLineDetail
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
            RadioShowCommissionSeparately
            RadioShowRebateSeparately
            RadioShowTaxSeparately
            RadioShowBillingHistory
            RadioCustomFormatName
            TVInvoiceTitle
            TVUseInvoiceCategoryDescription
            TVGroupByMarket
            TVShowOrderDescription
            TVShowClientReference
            TVShowClientPO
            TVShowOrderComment
            TVShowOrderHouseComment
            TVPrintInvoiceDueDate
            TVOrderNumberColumn
            TVVendorNameColumn
            TVShowVendorCode
            TVOrderMonthsColumn
            TVNetAmountColumn
            TVCommissionAmountColumn
            TVTaxAmountColumn
            TVBillAmountColumn
            TVPriorBillAmountColumn
            TVBilledToDateAmountColumn
            TVShowLineDetail
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
            TVShowCommissionSeparately
            TVShowRebateSeparately
            TVShowTaxSeparately
            TVShowBillingHistory
            TVCustomFormatName
            PageHeaderComment
            PageFooterComment
            PageHeaderLogoPath
            PageHeaderLogoPathLandscape
            PageFooterLogoPath
            PageFooterLogoPathLandscape
            CityTaxLabel
            CountyTaxLabel
            StateTaxLabel
            MediaInvoiceSettingID
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
            MagazineShowSalesClass
            NewspaperShowSalesClass
            InternetShowSalesClass
            OutdoorShowSalesClass
            RadioShowSalesClass
            TVShowSalesClass
            MagazineClientPOLocation
            NewspaperClientPOLocation
            InternetClientPOLocation
            OutdoorClientPOLocation
            RadioClientPOLocation
            TVClientPOLocation
            MagazineSalesClassLocation
            NewspaperSalesClassLocation
            InternetSalesClassLocation
            OutdoorSalesClassLocation
            RadioSalesClassLocation
            TVSalesClassLocation
            MagazineCampaignLocation
            NewspaperCampaignLocation
            InternetCampaignLocation
            OutdoorCampaignLocation
            RadioCampaignLocation
            TVCampaignLocation
            MagazineHeaderGroupBy
            NewspaperHeaderGroupBy
            InternetHeaderGroupBy
            OutdoorHeaderGroupBy
            RadioHeaderGroupBy
            TVHeaderGroupBy
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
            MagazineUseAgencySetting
            NewspaperUseAgencySetting
            InternetUseAgencySetting
            OutdoorUseAgencySetting
            RadioUseAgencySetting
            TVUseAgencySetting
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
            ShowPageHeaderLogo
            ShowPageFooterLogo
            HideExchangeRateMessage
        End Enum

#End Region

#Region " Variables "

        Private _IsOneTime As Nullable(Of Boolean) = Nothing
        Private _Type As Nullable(Of Short) = Nothing
        Private _ClientCode As String = Nothing
        Private _AddressBlockType As Nullable(Of Short) = Nothing
        Private _CustomFormatName As String = Nothing
        Private _PrintDivisionName As Nullable(Of Boolean) = Nothing
        Private _PrintProductDescription As Nullable(Of Boolean) = Nothing
        Private _PrintContactAfterAddress As Nullable(Of Boolean) = Nothing
        Private _ContactType As Integer = 0
        Private _IncludeBillingComment As Nullable(Of Boolean) = Nothing
        Private _ApplyExchangeRate As Nullable(Of Short) = Nothing
        Private _ExchangeRateAmount As Nullable(Of Decimal) = Nothing
        Private _InvoiceFooterCommentType As Nullable(Of Short) = Nothing
        Private _InvoiceFooterComment As String = Nothing
        Private _LocationCode As String = Nothing
        Private _ShowCodes As Boolean = Nothing
        Private _MagazineInvoiceTitle As String = Nothing
        Private _MagazineUseInvoiceCategoryDescription As Nullable(Of Boolean) = Nothing
        Private _MagazineGroupByMarket As Nullable(Of Boolean) = Nothing
        Private _MagazineShowOrderDescription As Nullable(Of Boolean) = Nothing
        Private _MagazineShowClientReference As Nullable(Of Boolean) = Nothing
        Private _MagazineShowClientPO As Nullable(Of Boolean) = Nothing
        Private _MagazineShowOrderComment As Nullable(Of Boolean) = Nothing
        Private _MagazineShowOrderHouseComment As Nullable(Of Boolean) = Nothing
        Private _MagazinePrintInvoiceDueDate As Nullable(Of Boolean) = Nothing
        Private _MagazineOrderNumberColumn As Nullable(Of Short) = Nothing
        Private _MagazineVendorNameColumn As Nullable(Of Short) = Nothing
        Private _MagazineShowVendorCode As Nullable(Of Short) = Nothing
        Private _MagazineOrderMonthsColumn As Nullable(Of Short) = Nothing
        Private _MagazineNetAmountColumn As Nullable(Of Short) = Nothing
        Private _MagazineCommissionAmountColumn As Nullable(Of Short) = Nothing
        Private _MagazineTaxAmountColumn As Nullable(Of Short) = Nothing
        Private _MagazineBillAmountColumn As Nullable(Of Short) = Nothing
        Private _MagazinePriorBillAmountColumn As Nullable(Of Short) = Nothing
        Private _MagazineBilledToDateAmountColumn As Nullable(Of Short) = Nothing
        Private _MagazineShowLineDetail As Nullable(Of Boolean) = Nothing
        Private _MagazineHeadlineColumn As Nullable(Of Short) = Nothing
        Private _MagazineInsertDatesColumn As Nullable(Of Short) = Nothing
        Private _MagazineMaterialColumn As Nullable(Of Short) = Nothing
        Private _MagazineAdNumberColumn As Nullable(Of Short) = Nothing
        Private _MagazineEditorialIssueColumn As Nullable(Of Short) = Nothing
        Private _MagazineAdSizeColumn As Nullable(Of Short) = Nothing
        Private _MagazineJobComponentNumberColumn As Nullable(Of Short) = Nothing
        Private _MagazineJobDescriptionColumn As Nullable(Of Short) = Nothing
        Private _MagazineComponentDescriptionColumn As Nullable(Of Short) = Nothing
        Private _MagazineOrderDetailCommentColumn As Nullable(Of Short) = Nothing
        Private _MagazineOrderHouseDetailCommentColumn As Nullable(Of Short) = Nothing
        Private _MagazineExtraChargesColumn As Nullable(Of Short) = Nothing
        Private _MagazineShowCommissionSeparately As Nullable(Of Boolean) = Nothing
        Private _MagazineShowRebateSeparately As Nullable(Of Boolean) = Nothing
        Private _MagazineShowTaxSeparately As Nullable(Of Boolean) = Nothing
        Private _MagazineShowBillingHistory As Nullable(Of Boolean) = Nothing
        Private _MagazineCustomFormatName As String = Nothing
        Private _NewspaperInvoiceTitle As String = Nothing
        Private _NewspaperUseInvoiceCategoryDescription As Nullable(Of Boolean) = Nothing
        Private _NewspaperGroupByMarket As Nullable(Of Boolean) = Nothing
        Private _NewspaperShowOrderDescription As Nullable(Of Boolean) = Nothing
        Private _NewspaperShowClientReference As Nullable(Of Boolean) = Nothing
        Private _NewspaperShowClientPO As Nullable(Of Boolean) = Nothing
        Private _NewspaperShowOrderComment As Nullable(Of Boolean) = Nothing
        Private _NewspaperShowOrderHouseComment As Nullable(Of Boolean) = Nothing
        Private _NewspaperPrintInvoiceDueDate As Nullable(Of Boolean) = Nothing
        Private _NewspaperOrderNumberColumn As Nullable(Of Short) = Nothing
        Private _NewspaperVendorNameColumn As Nullable(Of Short) = Nothing
        Private _NewspaperShowVendorCode As Nullable(Of Short) = Nothing
        Private _NewspaperOrderMonthsColumn As Nullable(Of Short) = Nothing
        Private _NewspaperNetAmountColumn As Nullable(Of Short) = Nothing
        Private _NewspaperCommissionAmountColumn As Nullable(Of Short) = Nothing
        Private _NewspaperTaxAmountColumn As Nullable(Of Short) = Nothing
        Private _NewspaperBillAmountColumn As Nullable(Of Short) = Nothing
        Private _NewspaperPriorBillAmountColumn As Nullable(Of Short) = Nothing
        Private _NewspaperBilledToDateAmountColumn As Nullable(Of Short) = Nothing
        Private _NewspaperShowLineDetail As Nullable(Of Boolean) = Nothing
        Private _NewspaperHeadlineColumn As Nullable(Of Short) = Nothing
        Private _NewspaperInsertDatesColumn As Nullable(Of Short) = Nothing
        Private _NewspaperMaterialColumn As Nullable(Of Short) = Nothing
        Private _NewspaperAdNumberColumn As Nullable(Of Short) = Nothing
        Private _NewspaperEditorialIssueColumn As Nullable(Of Short) = Nothing
        Private _NewspaperSectionColumn As Nullable(Of Short) = Nothing
        Private _NewspaperQuantityColumn As Nullable(Of Short) = Nothing
        Private _NewspaperAdSizeColumn As Nullable(Of Short) = Nothing
        Private _NewspaperJobComponentNumberColumn As Nullable(Of Short) = Nothing
        Private _NewspaperJobDescriptionColumn As Nullable(Of Short) = Nothing
        Private _NewspaperComponentDescriptionColumn As Nullable(Of Short) = Nothing
        Private _NewspaperOrderDetailCommentColumn As Nullable(Of Short) = Nothing
        Private _NewspaperOrderHouseDetailCommentColumn As Nullable(Of Short) = Nothing
        Private _NewspaperExtraChargesColumn As Nullable(Of Short) = Nothing
        Private _NewspaperShowCommissionSeparately As Nullable(Of Boolean) = Nothing
        Private _NewspaperShowRebateSeparately As Nullable(Of Boolean) = Nothing
        Private _NewspaperShowTaxSeparately As Nullable(Of Boolean) = Nothing
        Private _NewspaperShowBillingHistory As Nullable(Of Boolean) = Nothing
        Private _NewspaperCustomFormatName As String = Nothing
        Private _InternetInvoiceTitle As String = Nothing
        Private _InternetUseInvoiceCategoryDescription As Nullable(Of Boolean) = Nothing
        Private _InternetGroupByMarket As Nullable(Of Boolean) = Nothing
        Private _InternetShowOrderDescription As Nullable(Of Boolean) = Nothing
        Private _InternetShowClientReference As Nullable(Of Boolean) = Nothing
        Private _InternetShowClientPO As Nullable(Of Boolean) = Nothing
        Private _InternetShowOrderComment As Nullable(Of Boolean) = Nothing
        Private _InternetShowOrderHouseComment As Nullable(Of Boolean) = Nothing
        Private _InternetPrintInvoiceDueDate As Nullable(Of Boolean) = Nothing
        Private _InternetOrderNumberColumn As Nullable(Of Short) = Nothing
        Private _InternetVendorNameColumn As Nullable(Of Short) = Nothing
        Private _InternetShowVendorCode As Nullable(Of Short) = Nothing
        Private _InternetOrderMonthsColumn As Nullable(Of Short) = Nothing
        Private _InternetNetAmountColumn As Nullable(Of Short) = Nothing
        Private _InternetCommissionAmountColumn As Nullable(Of Short) = Nothing
        Private _InternetTaxAmountColumn As Nullable(Of Short) = Nothing
        Private _InternetBillAmountColumn As Nullable(Of Short) = Nothing
        Private _InternetPriorBillAmountColumn As Nullable(Of Short) = Nothing
        Private _InternetBilledToDateAmountColumn As Nullable(Of Short) = Nothing
        Private _InternetShowLineDetail As Nullable(Of Boolean) = Nothing
        Private _InternetHeadlineColumn As Nullable(Of Short) = Nothing
        Private _InternetStartDatesColumn As Nullable(Of Short) = Nothing
        Private _InternetEndDatesColumn As Nullable(Of Short) = Nothing
        Private _InternetCreativeSizeColumn As Nullable(Of Short) = Nothing
        Private _InternetAdNumberColumn As Nullable(Of Short) = Nothing
        Private _InternetURLColumn As Nullable(Of Short) = Nothing
        Private _InternetInternetTypeColumn As Nullable(Of Short) = Nothing
        Private _InternetJobComponentNumberColumn As Nullable(Of Short) = Nothing
        Private _InternetJobDescriptionColumn As Nullable(Of Short) = Nothing
        Private _InternetComponentDescriptionColumn As Nullable(Of Short) = Nothing
        Private _InternetExtraChargesColumn As Nullable(Of Short) = Nothing
        Private _InternetShowCommissionSeparately As Nullable(Of Boolean) = Nothing
        Private _InternetShowRebateSeparately As Nullable(Of Boolean) = Nothing
        Private _InternetShowTaxSeparately As Nullable(Of Boolean) = Nothing
        Private _InternetShowBillingHistory As Nullable(Of Boolean) = Nothing
        Private _InternetCustomFormatName As String = Nothing
        Private _OutdoorInvoiceTitle As String = Nothing
        Private _OutdoorUseInvoiceCategoryDescription As Nullable(Of Boolean) = Nothing
        Private _OutdoorGroupByMarket As Nullable(Of Boolean) = Nothing
        Private _OutdoorShowOrderDescription As Nullable(Of Boolean) = Nothing
        Private _OutdoorShowClientReference As Nullable(Of Boolean) = Nothing
        Private _OutdoorShowClientPO As Nullable(Of Boolean) = Nothing
        Private _OutdoorShowOrderComment As Nullable(Of Boolean) = Nothing
        Private _OutdoorShowOrderHouseComment As Nullable(Of Boolean) = Nothing
        Private _OutdoorPrintInvoiceDueDate As Nullable(Of Boolean) = Nothing
        Private _OutdoorOrderNumberColumn As Nullable(Of Short) = Nothing
        Private _OutdoorVendorNameColumn As Nullable(Of Short) = Nothing
        Private _OutdoorShowVendorCode As Nullable(Of Short) = Nothing
        Private _OutdoorOrderMonthsColumn As Nullable(Of Short) = Nothing
        Private _OutdoorNetAmountColumn As Nullable(Of Short) = Nothing
        Private _OutdoorCommissionAmountColumn As Nullable(Of Short) = Nothing
        Private _OutdoorTaxAmountColumn As Nullable(Of Short) = Nothing
        Private _OutdoorBillAmountColumn As Nullable(Of Short) = Nothing
        Private _OutdoorPriorBillAmountColumn As Nullable(Of Short) = Nothing
        Private _OutdoorBilledToDateAmountColumn As Nullable(Of Short) = Nothing
        Private _OutdoorShowLineDetail As Nullable(Of Boolean) = Nothing
        Private _OutdoorHeadlineColumn As Nullable(Of Short) = Nothing
		Private _OutdoorInsertDatesColumn As Nullable(Of Short) = Nothing
		Private _OutdoorEndDateColumn As Nullable(Of Short) = Nothing
		Private _OutdoorCopyAreaColumn As Nullable(Of Short) = Nothing
        Private _OutdoorAdNumberColumn As Nullable(Of Short) = Nothing
        Private _OutdoorLocationColumn As Nullable(Of Short) = Nothing
        Private _OutdoorOutdoorTypeColumn As Nullable(Of Short) = Nothing
        Private _OutdoorSizeColumn As Nullable(Of Short) = Nothing
        Private _OutdoorJobComponentNumberColumn As Nullable(Of Short) = Nothing
        Private _OutdoorJobDescriptionColumn As Nullable(Of Short) = Nothing
        Private _OutdoorComponentDescriptionColumn As Nullable(Of Short) = Nothing
        Private _OutdoorExtraChargesColumn As Nullable(Of Short) = Nothing
        Private _OutdoorShowCommissionSeparately As Nullable(Of Boolean) = Nothing
        Private _OutdoorShowRebateSeparately As Nullable(Of Boolean) = Nothing
        Private _OutdoorShowTaxSeparately As Nullable(Of Boolean) = Nothing
        Private _OutdoorShowBillingHistory As Nullable(Of Boolean) = Nothing
        Private _OutdoorCustomFormatName As String = Nothing
        Private _RadioInvoiceTitle As String = Nothing
        Private _RadioUseInvoiceCategoryDescription As Nullable(Of Boolean) = Nothing
        Private _RadioGroupByMarket As Nullable(Of Boolean) = Nothing
        Private _RadioShowOrderDescription As Nullable(Of Boolean) = Nothing
        Private _RadioShowClientReference As Nullable(Of Boolean) = Nothing
        Private _RadioShowClientPO As Nullable(Of Boolean) = Nothing
        Private _RadioShowOrderComment As Nullable(Of Boolean) = Nothing
        Private _RadioShowOrderHouseComment As Nullable(Of Boolean) = Nothing
        Private _RadioPrintInvoiceDueDate As Nullable(Of Boolean) = Nothing
        Private _RadioOrderNumberColumn As Nullable(Of Short) = Nothing
        Private _RadioVendorNameColumn As Nullable(Of Short) = Nothing
        Private _RadioShowVendorCode As Nullable(Of Short) = Nothing
        Private _RadioOrderMonthsColumn As Nullable(Of Short) = Nothing
        Private _RadioNetAmountColumn As Nullable(Of Short) = Nothing
        Private _RadioCommissionAmountColumn As Nullable(Of Short) = Nothing
        Private _RadioTaxAmountColumn As Nullable(Of Short) = Nothing
        Private _RadioBillAmountColumn As Nullable(Of Short) = Nothing
        Private _RadioPriorBillAmountColumn As Nullable(Of Short) = Nothing
        Private _RadioBilledToDateAmountColumn As Nullable(Of Short) = Nothing
        Private _RadioShowLineDetail As Nullable(Of Boolean) = Nothing
        Private _RadioProgramColumn As Nullable(Of Short) = Nothing
        Private _RadioSpotLengthColumn As Nullable(Of Short) = Nothing
        Private _RadioTagColumn As Nullable(Of Short) = Nothing
        Private _RadioStartEndTimesColumn As Nullable(Of Short) = Nothing
        Private _RadioNumberOfSpotsColumn As Nullable(Of Short) = Nothing
        Private _RadioRemarksColumn As Nullable(Of Short) = Nothing
        Private _RadioJobComponentNumberColumn As Nullable(Of Short) = Nothing
        Private _RadioJobDescriptionColumn As Nullable(Of Short) = Nothing
        Private _RadioComponentDescriptionColumn As Nullable(Of Short) = Nothing
        Private _RadioOrderDetailCommentColumn As Nullable(Of Short) = Nothing
        Private _RadioOrderHouseDetailCommentColumn As Nullable(Of Short) = Nothing
        Private _RadioExtraChargesColumn As Nullable(Of Short) = Nothing
        Private _RadioShowCommissionSeparately As Nullable(Of Boolean) = Nothing
        Private _RadioShowRebateSeparately As Nullable(Of Boolean) = Nothing
        Private _RadioShowTaxSeparately As Nullable(Of Boolean) = Nothing
        Private _RadioShowBillingHistory As Nullable(Of Boolean) = Nothing
        Private _RadioCustomFormatName As String = Nothing
        Private _TVInvoiceTitle As String = Nothing
        Private _TVUseInvoiceCategoryDescription As Nullable(Of Boolean) = Nothing
        Private _TVGroupByMarket As Nullable(Of Boolean) = Nothing
        Private _TVShowOrderDescription As Nullable(Of Boolean) = Nothing
        Private _TVShowClientReference As Nullable(Of Boolean) = Nothing
        Private _TVShowClientPO As Nullable(Of Boolean) = Nothing
        Private _TVShowOrderComment As Nullable(Of Boolean) = Nothing
        Private _TVShowOrderHouseComment As Nullable(Of Boolean) = Nothing
        Private _TVPrintInvoiceDueDate As Nullable(Of Boolean) = Nothing
        Private _TVOrderNumberColumn As Nullable(Of Short) = Nothing
        Private _TVVendorNameColumn As Nullable(Of Short) = Nothing
        Private _TVShowVendorCode As Nullable(Of Short) = Nothing
        Private _TVOrderMonthsColumn As Nullable(Of Short) = Nothing
        Private _TVNetAmountColumn As Nullable(Of Short) = Nothing
        Private _TVCommissionAmountColumn As Nullable(Of Short) = Nothing
        Private _TVTaxAmountColumn As Nullable(Of Short) = Nothing
        Private _TVBillAmountColumn As Nullable(Of Short) = Nothing
        Private _TVPriorBillAmountColumn As Nullable(Of Short) = Nothing
        Private _TVBilledToDateAmountColumn As Nullable(Of Short) = Nothing
        Private _TVShowLineDetail As Nullable(Of Boolean) = Nothing
        Private _TVProgramColumn As Nullable(Of Short) = Nothing
        Private _TVSpotLengthColumn As Nullable(Of Short) = Nothing
        Private _TVTagColumn As Nullable(Of Short) = Nothing
        Private _TVStartEndTimesColumn As Nullable(Of Short) = Nothing
        Private _TVNumberOfSpotsColumn As Nullable(Of Short) = Nothing
        Private _TVRemarksColumn As Nullable(Of Short) = Nothing
        Private _TVJobComponentNumberColumn As Nullable(Of Short) = Nothing
        Private _TVJobDescriptionColumn As Nullable(Of Short) = Nothing
        Private _TVComponentDescriptionColumn As Nullable(Of Short) = Nothing
        Private _TVOrderDetailCommentColumn As Nullable(Of Short) = Nothing
        Private _TVOrderHouseDetailCommentColumn As Nullable(Of Short) = Nothing
        Private _TVExtraChargesColumn As Nullable(Of Short) = Nothing
        Private _TVShowCommissionSeparately As Nullable(Of Boolean) = Nothing
        Private _TVShowRebateSeparately As Nullable(Of Boolean) = Nothing
        Private _TVShowTaxSeparately As Nullable(Of Boolean) = Nothing
        Private _TVShowBillingHistory As Nullable(Of Boolean) = Nothing
        Private _TVCustomFormatName As String = Nothing
        Private _PageHeaderComment As String = Nothing
        Private _PageFooterComment As String = Nothing
        Private _PageHeaderLogoPath As String = Nothing
        Private _PageHeaderLogoPathLandscape As String = Nothing
        Private _PageFooterLogoPath As String = Nothing
        Private _PageFooterLogoPathLandscape As String = Nothing
        Private _CityTaxLabel As String = Nothing
        Private _CountyTaxLabel As String = Nothing
        Private _StateTaxLabel As String = Nothing
        Private _MediaInvoiceSettingID As Nullable(Of Integer) = Nothing
        Private _UseLocationPrintOptions As Nullable(Of Boolean) = Nothing
        Private _CustomInvoiceID As Nullable(Of Integer) = Nothing
        Private _PrintClientName As Boolean = Nothing
        Private _MagazineShowCampaign As Boolean = Nothing
        Private _NewspaperShowCampaign As Boolean = Nothing
        Private _InternetShowCampaign As Boolean = Nothing
        Private _OutdoorShowCampaign As Boolean = Nothing
        Private _RadioShowCampaign As Boolean = Nothing
        Private _TVShowCampaign As Boolean = Nothing
        Private _MagazineShowCampaignComment As Boolean = Nothing
        Private _NewspaperShowCampaignComment As Boolean = Nothing
        Private _InternetShowCampaignComment As Boolean = Nothing
        Private _OutdoorShowCampaignComment As Boolean = Nothing
        Private _RadioShowCampaignComment As Boolean = Nothing
        Private _TVShowCampaignComment As Boolean = Nothing
        Private _MagazineShowOrderSubtotals As Boolean = Nothing
        Private _NewspaperShowOrderSubtotals As Boolean = Nothing
        Private _InternetShowOrderSubtotals As Boolean = Nothing
        Private _OutdoorShowOrderSubtotals As Boolean = Nothing
        Private _RadioShowOrderSubtotals As Boolean = Nothing
        Private _TVShowOrderSubtotals As Boolean = Nothing
        Private _MagazineShowSalesClass As Boolean = Nothing
        Private _NewspaperShowSalesClass As Boolean = Nothing
        Private _InternetShowSalesClass As Boolean = Nothing
        Private _OutdoorShowSalesClass As Boolean = Nothing
        Private _RadioShowSalesClass As Boolean = Nothing
        Private _TVShowSalesClass As Boolean = Nothing
        Private _MagazineClientPOLocation As Nullable(Of Integer) = Nothing
        Private _NewspaperClientPOLocation As Nullable(Of Integer) = Nothing
        Private _InternetClientPOLocation As Nullable(Of Integer) = Nothing
        Private _OutdoorClientPOLocation As Nullable(Of Integer) = Nothing
        Private _RadioClientPOLocation As Nullable(Of Integer) = Nothing
        Private _TVClientPOLocation As Nullable(Of Integer) = Nothing
        Private _MagazineSalesClassLocation As Nullable(Of Integer) = Nothing
        Private _NewspaperSalesClassLocation As Nullable(Of Integer) = Nothing
        Private _InternetSalesClassLocation As Nullable(Of Integer) = Nothing
        Private _OutdoorSalesClassLocation As Nullable(Of Integer) = Nothing
        Private _RadioSalesClassLocation As Nullable(Of Integer) = Nothing
        Private _TVSalesClassLocation As Nullable(Of Integer) = Nothing
        Private _MagazineCampaignLocation As Nullable(Of Integer) = Nothing
        Private _NewspaperCampaignLocation As Nullable(Of Integer) = Nothing
        Private _InternetCampaignLocation As Nullable(Of Integer) = Nothing
        Private _OutdoorCampaignLocation As Nullable(Of Integer) = Nothing
        Private _RadioCampaignLocation As Nullable(Of Integer) = Nothing
        Private _TVCampaignLocation As Nullable(Of Integer) = Nothing
        Private _MagazineHeaderGroupBy As Nullable(Of Integer) = Nothing
        Private _NewspaperHeaderGroupBy As Nullable(Of Integer) = Nothing
        Private _InternetHeaderGroupBy As Nullable(Of Integer) = Nothing
        Private _OutdoorHeaderGroupBy As Nullable(Of Integer) = Nothing
        Private _RadioHeaderGroupBy As Nullable(Of Integer) = Nothing
        Private _TVHeaderGroupBy As Nullable(Of Integer) = Nothing
        Private _MagazineSortLinesBy As Nullable(Of Integer) = Nothing
        Private _NewspaperSortLinesBy As Nullable(Of Integer) = Nothing
        Private _InternetSortLinesBy As Nullable(Of Integer) = Nothing
        Private _OutdoorSortLinesBy As Nullable(Of Integer) = Nothing
        Private _RadioSortLinesBy As Nullable(Of Integer) = Nothing
        Private _TVSortLinesBy As Nullable(Of Integer) = Nothing
        Private _MagazineLineNumberColumn As Nullable(Of Short) = Nothing
        Private _NewspaperLineNumberColumn As Nullable(Of Short) = Nothing
        Private _InternetLineNumberColumn As Nullable(Of Short) = Nothing
        Private _OutdoorLineNumberColumn As Nullable(Of Short) = Nothing
        Private _RadioLineNumberColumn As Nullable(Of Short) = Nothing
        Private _TVLineNumberColumn As Nullable(Of Short) = Nothing
        Private _MagazineShowZeroLineAmounts As Boolean = Nothing
        Private _NewspaperShowZeroLineAmounts As Boolean = Nothing
        Private _InternetShowZeroLineAmounts As Boolean = Nothing
        Private _OutdoorShowZeroLineAmounts As Boolean = Nothing
        Private _RadioShowZeroLineAmounts As Boolean = Nothing
        Private _TVShowZeroLineAmounts As Boolean = Nothing
        Private _MagazineUseAgencySetting As Boolean = Nothing
        Private _NewspaperUseAgencySetting As Boolean = Nothing
        Private _InternetUseAgencySetting As Boolean = Nothing
        Private _OutdoorUseAgencySetting As Boolean = Nothing
        Private _RadioUseAgencySetting As Boolean = Nothing
        Private _TVUseAgencySetting As Boolean = Nothing
        Private _MagazineCloseDateColumn As Nullable(Of Short) = Nothing
        Private _NewspaperCloseDateColumn As Nullable(Of Short) = Nothing
        Private _InternetCloseDateColumn As Nullable(Of Short) = Nothing
        Private _OutdoorCloseDateColumn As Nullable(Of Short) = Nothing
        Private _RadioCloseDateColumn As Nullable(Of Short) = Nothing
        Private _TVCloseDateColumn As Nullable(Of Short) = Nothing

#End Region

#Region " Properties "

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
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(ByVal value As String)
                _ClientCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AddressBlockType() As Nullable(Of Short)
            Get
                AddressBlockType = _AddressBlockType
            End Get
            Set(ByVal value As Nullable(Of Short))
                _AddressBlockType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CustomFormatName() As String
            Get
                CustomFormatName = _CustomFormatName
            End Get
            Set(ByVal value As String)
                _CustomFormatName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PrintDivisionName() As Nullable(Of Boolean)
            Get
                PrintDivisionName = _PrintDivisionName
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _PrintDivisionName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PrintProductDescription() As Nullable(Of Boolean)
            Get
                PrintProductDescription = _PrintProductDescription
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _PrintProductDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PrintContactAfterAddress() As Nullable(Of Boolean)
            Get
                PrintContactAfterAddress = _PrintContactAfterAddress
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _PrintContactAfterAddress = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ContactType() As Integer
            Get
                ContactType = _ContactType
            End Get
            Set(value As Integer)
                _ContactType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IncludeBillingComment() As Nullable(Of Boolean)
            Get
                IncludeBillingComment = _IncludeBillingComment
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _IncludeBillingComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ApplyExchangeRate() As Nullable(Of Short)
            Get
                ApplyExchangeRate = _ApplyExchangeRate
            End Get
            Set(ByVal value As Nullable(Of Short))
                _ApplyExchangeRate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ExchangeRateAmount() As Nullable(Of Decimal)
            Get
                ExchangeRateAmount = _ExchangeRateAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _ExchangeRateAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InvoiceFooterCommentType() As Nullable(Of Short)
            Get
                InvoiceFooterCommentType = _InvoiceFooterCommentType
            End Get
            Set(ByVal value As Nullable(Of Short))
                _InvoiceFooterCommentType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InvoiceFooterComment() As String
            Get
                InvoiceFooterComment = _InvoiceFooterComment
            End Get
            Set(ByVal value As String)
                _InvoiceFooterComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property LocationCode() As String
            Get
                LocationCode = _LocationCode
            End Get
            Set(ByVal value As String)
                _LocationCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()> _
        Public Property ShowCodes() As Boolean
            Get
                ShowCodes = _ShowCodes
            End Get
            Set(ByVal value As Boolean)
                _ShowCodes = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MagazineInvoiceTitle() As String
            Get
                MagazineInvoiceTitle = _MagazineInvoiceTitle
            End Get
            Set(ByVal value As String)
                _MagazineInvoiceTitle = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MagazineUseInvoiceCategoryDescription() As Nullable(Of Boolean)
            Get
                MagazineUseInvoiceCategoryDescription = _MagazineUseInvoiceCategoryDescription
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _MagazineUseInvoiceCategoryDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MagazineGroupByMarket() As Nullable(Of Boolean)
            Get
                MagazineGroupByMarket = _MagazineGroupByMarket
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _MagazineGroupByMarket = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MagazineShowOrderDescription() As Nullable(Of Boolean)
            Get
                MagazineShowOrderDescription = _MagazineShowOrderDescription
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _MagazineShowOrderDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MagazineShowClientReference() As Nullable(Of Boolean)
            Get
                MagazineShowClientReference = _MagazineShowClientReference
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _MagazineShowClientReference = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MagazineShowClientPO() As Nullable(Of Boolean)
            Get
                MagazineShowClientPO = _MagazineShowClientPO
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _MagazineShowClientPO = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MagazineShowOrderComment() As Nullable(Of Boolean)
            Get
                MagazineShowOrderComment = _MagazineShowOrderComment
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _MagazineShowOrderComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MagazineShowOrderHouseComment() As Nullable(Of Boolean)
            Get
                MagazineShowOrderHouseComment = _MagazineShowOrderHouseComment
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _MagazineShowOrderHouseComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MagazinePrintInvoiceDueDate() As Nullable(Of Boolean)
            Get
                MagazinePrintInvoiceDueDate = _MagazinePrintInvoiceDueDate
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _MagazinePrintInvoiceDueDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MagazineOrderNumberColumn() As Nullable(Of Short)
            Get
                MagazineOrderNumberColumn = _MagazineOrderNumberColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _MagazineOrderNumberColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MagazineVendorNameColumn() As Nullable(Of Short)
            Get
                MagazineVendorNameColumn = _MagazineVendorNameColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _MagazineVendorNameColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MagazineShowVendorCode() As Nullable(Of Short)
            Get
                MagazineShowVendorCode = _MagazineShowVendorCode
            End Get
            Set(ByVal value As Nullable(Of Short))
                _MagazineShowVendorCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MagazineOrderMonthsColumn() As Nullable(Of Short)
            Get
                MagazineOrderMonthsColumn = _MagazineOrderMonthsColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _MagazineOrderMonthsColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MagazineNetAmountColumn() As Nullable(Of Short)
            Get
                MagazineNetAmountColumn = _MagazineNetAmountColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _MagazineNetAmountColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MagazineCommissionAmountColumn() As Nullable(Of Short)
            Get
                MagazineCommissionAmountColumn = _MagazineCommissionAmountColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _MagazineCommissionAmountColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MagazineTaxAmountColumn() As Nullable(Of Short)
            Get
                MagazineTaxAmountColumn = _MagazineTaxAmountColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _MagazineTaxAmountColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MagazineBillAmountColumn() As Nullable(Of Short)
            Get
                MagazineBillAmountColumn = _MagazineBillAmountColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _MagazineBillAmountColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MagazinePriorBillAmountColumn() As Nullable(Of Short)
            Get
                MagazinePriorBillAmountColumn = _MagazinePriorBillAmountColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _MagazinePriorBillAmountColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MagazineBilledToDateAmountColumn() As Nullable(Of Short)
            Get
                MagazineBilledToDateAmountColumn = _MagazineBilledToDateAmountColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _MagazineBilledToDateAmountColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MagazineShowLineDetail() As Nullable(Of Boolean)
            Get
                MagazineShowLineDetail = _MagazineShowLineDetail
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _MagazineShowLineDetail = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MagazineHeadlineColumn() As Nullable(Of Short)
            Get
                MagazineHeadlineColumn = _MagazineHeadlineColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _MagazineHeadlineColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MagazineInsertDatesColumn() As Nullable(Of Short)
            Get
                MagazineInsertDatesColumn = _MagazineInsertDatesColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _MagazineInsertDatesColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MagazineMaterialColumn() As Nullable(Of Short)
            Get
                MagazineMaterialColumn = _MagazineMaterialColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _MagazineMaterialColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MagazineAdNumberColumn() As Nullable(Of Short)
            Get
                MagazineAdNumberColumn = _MagazineAdNumberColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _MagazineAdNumberColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MagazineEditorialIssueColumn() As Nullable(Of Short)
            Get
                MagazineEditorialIssueColumn = _MagazineEditorialIssueColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _MagazineEditorialIssueColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MagazineAdSizeColumn() As Nullable(Of Short)
            Get
                MagazineAdSizeColumn = _MagazineAdSizeColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _MagazineAdSizeColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MagazineJobComponentNumberColumn() As Nullable(Of Short)
            Get
                MagazineJobComponentNumberColumn = _MagazineJobComponentNumberColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _MagazineJobComponentNumberColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MagazineJobDescriptionColumn() As Nullable(Of Short)
            Get
                MagazineJobDescriptionColumn = _MagazineJobDescriptionColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _MagazineJobDescriptionColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MagazineComponentDescriptionColumn() As Nullable(Of Short)
            Get
                MagazineComponentDescriptionColumn = _MagazineComponentDescriptionColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _MagazineComponentDescriptionColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MagazineOrderDetailCommentColumn() As Nullable(Of Short)
            Get
                MagazineOrderDetailCommentColumn = _MagazineOrderDetailCommentColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _MagazineOrderDetailCommentColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MagazineOrderHouseDetailCommentColumn() As Nullable(Of Short)
            Get
                MagazineOrderHouseDetailCommentColumn = _MagazineOrderHouseDetailCommentColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _MagazineOrderHouseDetailCommentColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MagazineExtraChargesColumn() As Nullable(Of Short)
            Get
                MagazineExtraChargesColumn = _MagazineExtraChargesColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _MagazineExtraChargesColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MagazineShowCommissionSeparately() As Nullable(Of Boolean)
            Get
                MagazineShowCommissionSeparately = _MagazineShowCommissionSeparately
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _MagazineShowCommissionSeparately = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MagazineShowRebateSeparately() As Nullable(Of Boolean)
            Get
                MagazineShowRebateSeparately = _MagazineShowRebateSeparately
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _MagazineShowRebateSeparately = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MagazineShowTaxSeparately() As Nullable(Of Boolean)
            Get
                MagazineShowTaxSeparately = _MagazineShowTaxSeparately
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _MagazineShowTaxSeparately = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MagazineShowBillingHistory() As Nullable(Of Boolean)
            Get
                MagazineShowBillingHistory = _MagazineShowBillingHistory
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _MagazineShowBillingHistory = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MagazineCustomFormatName() As String
            Get
                MagazineCustomFormatName = _MagazineCustomFormatName
            End Get
            Set(ByVal value As String)
                _MagazineCustomFormatName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewspaperInvoiceTitle() As String
            Get
                NewspaperInvoiceTitle = _NewspaperInvoiceTitle
            End Get
            Set(ByVal value As String)
                _NewspaperInvoiceTitle = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewspaperUseInvoiceCategoryDescription() As Nullable(Of Boolean)
            Get
                NewspaperUseInvoiceCategoryDescription = _NewspaperUseInvoiceCategoryDescription
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _NewspaperUseInvoiceCategoryDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewspaperGroupByMarket() As Nullable(Of Boolean)
            Get
                NewspaperGroupByMarket = _NewspaperGroupByMarket
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _NewspaperGroupByMarket = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewspaperShowOrderDescription() As Nullable(Of Boolean)
            Get
                NewspaperShowOrderDescription = _NewspaperShowOrderDescription
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _NewspaperShowOrderDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewspaperShowClientReference() As Nullable(Of Boolean)
            Get
                NewspaperShowClientReference = _NewspaperShowClientReference
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _NewspaperShowClientReference = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewspaperShowClientPO() As Nullable(Of Boolean)
            Get
                NewspaperShowClientPO = _NewspaperShowClientPO
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _NewspaperShowClientPO = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewspaperShowOrderComment() As Nullable(Of Boolean)
            Get
                NewspaperShowOrderComment = _NewspaperShowOrderComment
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _NewspaperShowOrderComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewspaperShowOrderHouseComment() As Nullable(Of Boolean)
            Get
                NewspaperShowOrderHouseComment = _NewspaperShowOrderHouseComment
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _NewspaperShowOrderHouseComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewspaperPrintInvoiceDueDate() As Nullable(Of Boolean)
            Get
                NewspaperPrintInvoiceDueDate = _NewspaperPrintInvoiceDueDate
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _NewspaperPrintInvoiceDueDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewspaperOrderNumberColumn() As Nullable(Of Short)
            Get
                NewspaperOrderNumberColumn = _NewspaperOrderNumberColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _NewspaperOrderNumberColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewspaperVendorNameColumn() As Nullable(Of Short)
            Get
                NewspaperVendorNameColumn = _NewspaperVendorNameColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _NewspaperVendorNameColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewspaperShowVendorCode() As Nullable(Of Short)
            Get
                NewspaperShowVendorCode = _NewspaperShowVendorCode
            End Get
            Set(ByVal value As Nullable(Of Short))
                _NewspaperShowVendorCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewspaperOrderMonthsColumn() As Nullable(Of Short)
            Get
                NewspaperOrderMonthsColumn = _NewspaperOrderMonthsColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _NewspaperOrderMonthsColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewspaperNetAmountColumn() As Nullable(Of Short)
            Get
                NewspaperNetAmountColumn = _NewspaperNetAmountColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _NewspaperNetAmountColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewspaperCommissionAmountColumn() As Nullable(Of Short)
            Get
                NewspaperCommissionAmountColumn = _NewspaperCommissionAmountColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _NewspaperCommissionAmountColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewspaperTaxAmountColumn() As Nullable(Of Short)
            Get
                NewspaperTaxAmountColumn = _NewspaperTaxAmountColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _NewspaperTaxAmountColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewspaperBillAmountColumn() As Nullable(Of Short)
            Get
                NewspaperBillAmountColumn = _NewspaperBillAmountColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _NewspaperBillAmountColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewspaperPriorBillAmountColumn() As Nullable(Of Short)
            Get
                NewspaperPriorBillAmountColumn = _NewspaperPriorBillAmountColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _NewspaperPriorBillAmountColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewspaperBilledToDateAmountColumn() As Nullable(Of Short)
            Get
                NewspaperBilledToDateAmountColumn = _NewspaperBilledToDateAmountColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _NewspaperBilledToDateAmountColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewspaperShowLineDetail() As Nullable(Of Boolean)
            Get
                NewspaperShowLineDetail = _NewspaperShowLineDetail
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _NewspaperShowLineDetail = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewspaperHeadlineColumn() As Nullable(Of Short)
            Get
                NewspaperHeadlineColumn = _NewspaperHeadlineColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _NewspaperHeadlineColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewspaperInsertDatesColumn() As Nullable(Of Short)
            Get
                NewspaperInsertDatesColumn = _NewspaperInsertDatesColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _NewspaperInsertDatesColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewspaperMaterialColumn() As Nullable(Of Short)
            Get
                NewspaperMaterialColumn = _NewspaperMaterialColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _NewspaperMaterialColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewspaperAdNumberColumn() As Nullable(Of Short)
            Get
                NewspaperAdNumberColumn = _NewspaperAdNumberColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _NewspaperAdNumberColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewspaperEditorialIssueColumn() As Nullable(Of Short)
            Get
                NewspaperEditorialIssueColumn = _NewspaperEditorialIssueColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _NewspaperEditorialIssueColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewspaperSectionColumn() As Nullable(Of Short)
            Get
                NewspaperSectionColumn = _NewspaperSectionColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _NewspaperSectionColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewspaperQuantityColumn() As Nullable(Of Short)
            Get
                NewspaperQuantityColumn = _NewspaperQuantityColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _NewspaperQuantityColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewspaperAdSizeColumn() As Nullable(Of Short)
            Get
                NewspaperAdSizeColumn = _NewspaperAdSizeColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _NewspaperAdSizeColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewspaperJobComponentNumberColumn() As Nullable(Of Short)
            Get
                NewspaperJobComponentNumberColumn = _NewspaperJobComponentNumberColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _NewspaperJobComponentNumberColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewspaperJobDescriptionColumn() As Nullable(Of Short)
            Get
                NewspaperJobDescriptionColumn = _NewspaperJobDescriptionColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _NewspaperJobDescriptionColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewspaperComponentDescriptionColumn() As Nullable(Of Short)
            Get
                NewspaperComponentDescriptionColumn = _NewspaperComponentDescriptionColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _NewspaperComponentDescriptionColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewspaperOrderDetailCommentColumn() As Nullable(Of Short)
            Get
                NewspaperOrderDetailCommentColumn = _NewspaperOrderDetailCommentColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _NewspaperOrderDetailCommentColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewspaperOrderHouseDetailCommentColumn() As Nullable(Of Short)
            Get
                NewspaperOrderHouseDetailCommentColumn = _NewspaperOrderHouseDetailCommentColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _NewspaperOrderHouseDetailCommentColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewspaperExtraChargesColumn() As Nullable(Of Short)
            Get
                NewspaperExtraChargesColumn = _NewspaperExtraChargesColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _NewspaperExtraChargesColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewspaperShowCommissionSeparately() As Nullable(Of Boolean)
            Get
                NewspaperShowCommissionSeparately = _NewspaperShowCommissionSeparately
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _NewspaperShowCommissionSeparately = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewspaperShowRebateSeparately() As Nullable(Of Boolean)
            Get
                NewspaperShowRebateSeparately = _NewspaperShowRebateSeparately
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _NewspaperShowRebateSeparately = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewspaperShowTaxSeparately() As Nullable(Of Boolean)
            Get
                NewspaperShowTaxSeparately = _NewspaperShowTaxSeparately
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _NewspaperShowTaxSeparately = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewspaperShowBillingHistory() As Nullable(Of Boolean)
            Get
                NewspaperShowBillingHistory = _NewspaperShowBillingHistory
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _NewspaperShowBillingHistory = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewspaperCustomFormatName() As String
            Get
                NewspaperCustomFormatName = _NewspaperCustomFormatName
            End Get
            Set(ByVal value As String)
                _NewspaperCustomFormatName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetInvoiceTitle() As String
            Get
                InternetInvoiceTitle = _InternetInvoiceTitle
            End Get
            Set(ByVal value As String)
                _InternetInvoiceTitle = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetUseInvoiceCategoryDescription() As Nullable(Of Boolean)
            Get
                InternetUseInvoiceCategoryDescription = _InternetUseInvoiceCategoryDescription
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _InternetUseInvoiceCategoryDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetGroupByMarket() As Nullable(Of Boolean)
            Get
                InternetGroupByMarket = _InternetGroupByMarket
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _InternetGroupByMarket = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetShowOrderDescription() As Nullable(Of Boolean)
            Get
                InternetShowOrderDescription = _InternetShowOrderDescription
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _InternetShowOrderDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetShowClientReference() As Nullable(Of Boolean)
            Get
                InternetShowClientReference = _InternetShowClientReference
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _InternetShowClientReference = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetShowClientPO() As Nullable(Of Boolean)
            Get
                InternetShowClientPO = _InternetShowClientPO
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _InternetShowClientPO = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetShowOrderComment() As Nullable(Of Boolean)
            Get
                InternetShowOrderComment = _InternetShowOrderComment
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _InternetShowOrderComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetShowOrderHouseComment() As Nullable(Of Boolean)
            Get
                InternetShowOrderHouseComment = _InternetShowOrderHouseComment
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _InternetShowOrderHouseComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetPrintInvoiceDueDate() As Nullable(Of Boolean)
            Get
                InternetPrintInvoiceDueDate = _InternetPrintInvoiceDueDate
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _InternetPrintInvoiceDueDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetOrderNumberColumn() As Nullable(Of Short)
            Get
                InternetOrderNumberColumn = _InternetOrderNumberColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _InternetOrderNumberColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetVendorNameColumn() As Nullable(Of Short)
            Get
                InternetVendorNameColumn = _InternetVendorNameColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _InternetVendorNameColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetShowVendorCode() As Nullable(Of Short)
            Get
                InternetShowVendorCode = _InternetShowVendorCode
            End Get
            Set(ByVal value As Nullable(Of Short))
                _InternetShowVendorCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetOrderMonthsColumn() As Nullable(Of Short)
            Get
                InternetOrderMonthsColumn = _InternetOrderMonthsColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _InternetOrderMonthsColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetNetAmountColumn() As Nullable(Of Short)
            Get
                InternetNetAmountColumn = _InternetNetAmountColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _InternetNetAmountColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetCommissionAmountColumn() As Nullable(Of Short)
            Get
                InternetCommissionAmountColumn = _InternetCommissionAmountColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _InternetCommissionAmountColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetTaxAmountColumn() As Nullable(Of Short)
            Get
                InternetTaxAmountColumn = _InternetTaxAmountColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _InternetTaxAmountColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetBillAmountColumn() As Nullable(Of Short)
            Get
                InternetBillAmountColumn = _InternetBillAmountColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _InternetBillAmountColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetPriorBillAmountColumn() As Nullable(Of Short)
            Get
                InternetPriorBillAmountColumn = _InternetPriorBillAmountColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _InternetPriorBillAmountColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetBilledToDateAmountColumn() As Nullable(Of Short)
            Get
                InternetBilledToDateAmountColumn = _InternetBilledToDateAmountColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _InternetBilledToDateAmountColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetShowLineDetail() As Nullable(Of Boolean)
            Get
                InternetShowLineDetail = _InternetShowLineDetail
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _InternetShowLineDetail = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetHeadlineColumn() As Nullable(Of Short)
            Get
                InternetHeadlineColumn = _InternetHeadlineColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _InternetHeadlineColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetStartDatesColumn() As Nullable(Of Short)
            Get
                InternetStartDatesColumn = _InternetStartDatesColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _InternetStartDatesColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetEndDatesColumn() As Nullable(Of Short)
            Get
                InternetEndDatesColumn = _InternetEndDatesColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _InternetEndDatesColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetCreativeSizeColumn() As Nullable(Of Short)
            Get
                InternetCreativeSizeColumn = _InternetCreativeSizeColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _InternetCreativeSizeColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetAdNumberColumn() As Nullable(Of Short)
            Get
                InternetAdNumberColumn = _InternetAdNumberColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _InternetAdNumberColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetURLColumn() As Nullable(Of Short)
            Get
                InternetURLColumn = _InternetURLColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _InternetURLColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetInternetTypeColumn() As Nullable(Of Short)
            Get
                InternetInternetTypeColumn = _InternetInternetTypeColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _InternetInternetTypeColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetJobComponentNumberColumn() As Nullable(Of Short)
            Get
                InternetJobComponentNumberColumn = _InternetJobComponentNumberColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _InternetJobComponentNumberColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetJobDescriptionColumn() As Nullable(Of Short)
            Get
                InternetJobDescriptionColumn = _InternetJobDescriptionColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _InternetJobDescriptionColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetComponentDescriptionColumn() As Nullable(Of Short)
            Get
                InternetComponentDescriptionColumn = _InternetComponentDescriptionColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _InternetComponentDescriptionColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetExtraChargesColumn() As Nullable(Of Short)
            Get
                InternetExtraChargesColumn = _InternetExtraChargesColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _InternetExtraChargesColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetShowCommissionSeparately() As Nullable(Of Boolean)
            Get
                InternetShowCommissionSeparately = _InternetShowCommissionSeparately
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _InternetShowCommissionSeparately = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetShowRebateSeparately() As Nullable(Of Boolean)
            Get
                InternetShowRebateSeparately = _InternetShowRebateSeparately
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _InternetShowRebateSeparately = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetShowTaxSeparately() As Nullable(Of Boolean)
            Get
                InternetShowTaxSeparately = _InternetShowTaxSeparately
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _InternetShowTaxSeparately = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetShowBillingHistory() As Nullable(Of Boolean)
            Get
                InternetShowBillingHistory = _InternetShowBillingHistory
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _InternetShowBillingHistory = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetCustomFormatName() As String
            Get
                InternetCustomFormatName = _InternetCustomFormatName
            End Get
            Set(ByVal value As String)
                _InternetCustomFormatName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OutdoorInvoiceTitle() As String
            Get
                OutdoorInvoiceTitle = _OutdoorInvoiceTitle
            End Get
            Set(ByVal value As String)
                _OutdoorInvoiceTitle = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OutdoorUseInvoiceCategoryDescription() As Nullable(Of Boolean)
            Get
                OutdoorUseInvoiceCategoryDescription = _OutdoorUseInvoiceCategoryDescription
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _OutdoorUseInvoiceCategoryDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OutdoorGroupByMarket() As Nullable(Of Boolean)
            Get
                OutdoorGroupByMarket = _OutdoorGroupByMarket
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _OutdoorGroupByMarket = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OutdoorShowOrderDescription() As Nullable(Of Boolean)
            Get
                OutdoorShowOrderDescription = _OutdoorShowOrderDescription
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _OutdoorShowOrderDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OutdoorShowClientReference() As Nullable(Of Boolean)
            Get
                OutdoorShowClientReference = _OutdoorShowClientReference
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _OutdoorShowClientReference = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OutdoorShowClientPO() As Nullable(Of Boolean)
            Get
                OutdoorShowClientPO = _OutdoorShowClientPO
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _OutdoorShowClientPO = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OutdoorShowOrderComment() As Nullable(Of Boolean)
            Get
                OutdoorShowOrderComment = _OutdoorShowOrderComment
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _OutdoorShowOrderComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OutdoorShowOrderHouseComment() As Nullable(Of Boolean)
            Get
                OutdoorShowOrderHouseComment = _OutdoorShowOrderHouseComment
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _OutdoorShowOrderHouseComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OutdoorPrintInvoiceDueDate() As Nullable(Of Boolean)
            Get
                OutdoorPrintInvoiceDueDate = _OutdoorPrintInvoiceDueDate
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _OutdoorPrintInvoiceDueDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OutdoorOrderNumberColumn() As Nullable(Of Short)
            Get
                OutdoorOrderNumberColumn = _OutdoorOrderNumberColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _OutdoorOrderNumberColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OutdoorVendorNameColumn() As Nullable(Of Short)
            Get
                OutdoorVendorNameColumn = _OutdoorVendorNameColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _OutdoorVendorNameColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OutdoorShowVendorCode() As Nullable(Of Short)
            Get
                OutdoorShowVendorCode = _OutdoorShowVendorCode
            End Get
            Set(ByVal value As Nullable(Of Short))
                _OutdoorShowVendorCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OutdoorOrderMonthsColumn() As Nullable(Of Short)
            Get
                OutdoorOrderMonthsColumn = _OutdoorOrderMonthsColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _OutdoorOrderMonthsColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OutdoorNetAmountColumn() As Nullable(Of Short)
            Get
                OutdoorNetAmountColumn = _OutdoorNetAmountColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _OutdoorNetAmountColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OutdoorCommissionAmountColumn() As Nullable(Of Short)
            Get
                OutdoorCommissionAmountColumn = _OutdoorCommissionAmountColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _OutdoorCommissionAmountColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OutdoorTaxAmountColumn() As Nullable(Of Short)
            Get
                OutdoorTaxAmountColumn = _OutdoorTaxAmountColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _OutdoorTaxAmountColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OutdoorBillAmountColumn() As Nullable(Of Short)
            Get
                OutdoorBillAmountColumn = _OutdoorBillAmountColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _OutdoorBillAmountColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OutdoorPriorBillAmountColumn() As Nullable(Of Short)
            Get
                OutdoorPriorBillAmountColumn = _OutdoorPriorBillAmountColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _OutdoorPriorBillAmountColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OutdoorBilledToDateAmountColumn() As Nullable(Of Short)
            Get
                OutdoorBilledToDateAmountColumn = _OutdoorBilledToDateAmountColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _OutdoorBilledToDateAmountColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OutdoorShowLineDetail() As Nullable(Of Boolean)
            Get
                OutdoorShowLineDetail = _OutdoorShowLineDetail
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _OutdoorShowLineDetail = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OutdoorHeadlineColumn() As Nullable(Of Short)
            Get
                OutdoorHeadlineColumn = _OutdoorHeadlineColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _OutdoorHeadlineColumn = value
            End Set
        End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property OutdoorInsertDatesColumn() As Nullable(Of Short)
			Get
				OutdoorInsertDatesColumn = _OutdoorInsertDatesColumn
			End Get
			Set(ByVal value As Nullable(Of Short))
				_OutdoorInsertDatesColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property OutdoorEndDateColumn() As Nullable(Of Short)
			Get
				OutdoorEndDateColumn = _OutdoorEndDateColumn
			End Get
			Set(ByVal value As Nullable(Of Short))
				_OutdoorEndDateColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OutdoorCopyAreaColumn() As Nullable(Of Short)
            Get
                OutdoorCopyAreaColumn = _OutdoorCopyAreaColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _OutdoorCopyAreaColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OutdoorAdNumberColumn() As Nullable(Of Short)
            Get
                OutdoorAdNumberColumn = _OutdoorAdNumberColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _OutdoorAdNumberColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OutdoorLocationColumn() As Nullable(Of Short)
            Get
                OutdoorLocationColumn = _OutdoorLocationColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _OutdoorLocationColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OutdoorOutdoorTypeColumn() As Nullable(Of Short)
            Get
                OutdoorOutdoorTypeColumn = _OutdoorOutdoorTypeColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _OutdoorOutdoorTypeColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OutdoorSizeColumn() As Nullable(Of Short)
            Get
                OutdoorSizeColumn = _OutdoorSizeColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _OutdoorSizeColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OutdoorJobComponentNumberColumn() As Nullable(Of Short)
            Get
                OutdoorJobComponentNumberColumn = _OutdoorJobComponentNumberColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _OutdoorJobComponentNumberColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OutdoorJobDescriptionColumn() As Nullable(Of Short)
            Get
                OutdoorJobDescriptionColumn = _OutdoorJobDescriptionColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _OutdoorJobDescriptionColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OutdoorComponentDescriptionColumn() As Nullable(Of Short)
            Get
                OutdoorComponentDescriptionColumn = _OutdoorComponentDescriptionColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _OutdoorComponentDescriptionColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OutdoorExtraChargesColumn() As Nullable(Of Short)
            Get
                OutdoorExtraChargesColumn = _OutdoorExtraChargesColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _OutdoorExtraChargesColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OutdoorShowCommissionSeparately() As Nullable(Of Boolean)
            Get
                OutdoorShowCommissionSeparately = _OutdoorShowCommissionSeparately
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _OutdoorShowCommissionSeparately = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OutdoorShowRebateSeparately() As Nullable(Of Boolean)
            Get
                OutdoorShowRebateSeparately = _OutdoorShowRebateSeparately
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _OutdoorShowRebateSeparately = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OutdoorShowTaxSeparately() As Nullable(Of Boolean)
            Get
                OutdoorShowTaxSeparately = _OutdoorShowTaxSeparately
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _OutdoorShowTaxSeparately = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OutdoorShowBillingHistory() As Nullable(Of Boolean)
            Get
                OutdoorShowBillingHistory = _OutdoorShowBillingHistory
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _OutdoorShowBillingHistory = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OutdoorCustomFormatName() As String
            Get
                OutdoorCustomFormatName = _OutdoorCustomFormatName
            End Get
            Set(ByVal value As String)
                _OutdoorCustomFormatName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RadioInvoiceTitle() As String
            Get
                RadioInvoiceTitle = _RadioInvoiceTitle
            End Get
            Set(ByVal value As String)
                _RadioInvoiceTitle = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RadioUseInvoiceCategoryDescription() As Nullable(Of Boolean)
            Get
                RadioUseInvoiceCategoryDescription = _RadioUseInvoiceCategoryDescription
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _RadioUseInvoiceCategoryDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RadioGroupByMarket() As Nullable(Of Boolean)
            Get
                RadioGroupByMarket = _RadioGroupByMarket
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _RadioGroupByMarket = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RadioShowOrderDescription() As Nullable(Of Boolean)
            Get
                RadioShowOrderDescription = _RadioShowOrderDescription
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _RadioShowOrderDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RadioShowClientReference() As Nullable(Of Boolean)
            Get
                RadioShowClientReference = _RadioShowClientReference
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _RadioShowClientReference = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RadioShowClientPO() As Nullable(Of Boolean)
            Get
                RadioShowClientPO = _RadioShowClientPO
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _RadioShowClientPO = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RadioShowOrderComment() As Nullable(Of Boolean)
            Get
                RadioShowOrderComment = _RadioShowOrderComment
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _RadioShowOrderComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RadioShowOrderHouseComment() As Nullable(Of Boolean)
            Get
                RadioShowOrderHouseComment = _RadioShowOrderHouseComment
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _RadioShowOrderHouseComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RadioPrintInvoiceDueDate() As Nullable(Of Boolean)
            Get
                RadioPrintInvoiceDueDate = _RadioPrintInvoiceDueDate
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _RadioPrintInvoiceDueDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RadioOrderNumberColumn() As Nullable(Of Short)
            Get
                RadioOrderNumberColumn = _RadioOrderNumberColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _RadioOrderNumberColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RadioVendorNameColumn() As Nullable(Of Short)
            Get
                RadioVendorNameColumn = _RadioVendorNameColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _RadioVendorNameColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RadioShowVendorCode() As Nullable(Of Short)
            Get
                RadioShowVendorCode = _RadioShowVendorCode
            End Get
            Set(ByVal value As Nullable(Of Short))
                _RadioShowVendorCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RadioOrderMonthsColumn() As Nullable(Of Short)
            Get
                RadioOrderMonthsColumn = _RadioOrderMonthsColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _RadioOrderMonthsColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RadioNetAmountColumn() As Nullable(Of Short)
            Get
                RadioNetAmountColumn = _RadioNetAmountColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _RadioNetAmountColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RadioCommissionAmountColumn() As Nullable(Of Short)
            Get
                RadioCommissionAmountColumn = _RadioCommissionAmountColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _RadioCommissionAmountColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RadioTaxAmountColumn() As Nullable(Of Short)
            Get
                RadioTaxAmountColumn = _RadioTaxAmountColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _RadioTaxAmountColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RadioBillAmountColumn() As Nullable(Of Short)
            Get
                RadioBillAmountColumn = _RadioBillAmountColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _RadioBillAmountColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RadioPriorBillAmountColumn() As Nullable(Of Short)
            Get
                RadioPriorBillAmountColumn = _RadioPriorBillAmountColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _RadioPriorBillAmountColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RadioBilledToDateAmountColumn() As Nullable(Of Short)
            Get
                RadioBilledToDateAmountColumn = _RadioBilledToDateAmountColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _RadioBilledToDateAmountColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RadioShowLineDetail() As Nullable(Of Boolean)
            Get
                RadioShowLineDetail = _RadioShowLineDetail
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _RadioShowLineDetail = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RadioProgramColumn() As Nullable(Of Short)
            Get
                RadioProgramColumn = _RadioProgramColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _RadioProgramColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RadioSpotLengthColumn() As Nullable(Of Short)
            Get
                RadioSpotLengthColumn = _RadioSpotLengthColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _RadioSpotLengthColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RadioTagColumn() As Nullable(Of Short)
            Get
                RadioTagColumn = _RadioTagColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _RadioTagColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RadioStartEndTimesColumn() As Nullable(Of Short)
            Get
                RadioStartEndTimesColumn = _RadioStartEndTimesColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _RadioStartEndTimesColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RadioNumberOfSpotsColumn() As Nullable(Of Short)
            Get
                RadioNumberOfSpotsColumn = _RadioNumberOfSpotsColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _RadioNumberOfSpotsColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RadioRemarksColumn() As Nullable(Of Short)
            Get
                RadioRemarksColumn = _RadioRemarksColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _RadioRemarksColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RadioJobComponentNumberColumn() As Nullable(Of Short)
            Get
                RadioJobComponentNumberColumn = _RadioJobComponentNumberColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _RadioJobComponentNumberColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RadioJobDescriptionColumn() As Nullable(Of Short)
            Get
                RadioJobDescriptionColumn = _RadioJobDescriptionColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _RadioJobDescriptionColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RadioComponentDescriptionColumn() As Nullable(Of Short)
            Get
                RadioComponentDescriptionColumn = _RadioComponentDescriptionColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _RadioComponentDescriptionColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RadioOrderDetailCommentColumn() As Nullable(Of Short)
            Get
                RadioOrderDetailCommentColumn = _RadioOrderDetailCommentColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _RadioOrderDetailCommentColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RadioOrderHouseDetailCommentColumn() As Nullable(Of Short)
            Get
                RadioOrderHouseDetailCommentColumn = _RadioOrderHouseDetailCommentColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _RadioOrderHouseDetailCommentColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RadioExtraChargesColumn() As Nullable(Of Short)
            Get
                RadioExtraChargesColumn = _RadioExtraChargesColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _RadioExtraChargesColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RadioShowCommissionSeparately() As Nullable(Of Boolean)
            Get
                RadioShowCommissionSeparately = _RadioShowCommissionSeparately
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _RadioShowCommissionSeparately = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RadioShowRebateSeparately() As Nullable(Of Boolean)
            Get
                RadioShowRebateSeparately = _RadioShowRebateSeparately
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _RadioShowRebateSeparately = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RadioShowTaxSeparately() As Nullable(Of Boolean)
            Get
                RadioShowTaxSeparately = _RadioShowTaxSeparately
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _RadioShowTaxSeparately = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RadioShowBillingHistory() As Nullable(Of Boolean)
            Get
                RadioShowBillingHistory = _RadioShowBillingHistory
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _RadioShowBillingHistory = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RadioCustomFormatName() As String
            Get
                RadioCustomFormatName = _RadioCustomFormatName
            End Get
            Set(ByVal value As String)
                _RadioCustomFormatName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TVInvoiceTitle() As String
            Get
                TVInvoiceTitle = _TVInvoiceTitle
            End Get
            Set(ByVal value As String)
                _TVInvoiceTitle = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TVUseInvoiceCategoryDescription() As Nullable(Of Boolean)
            Get
                TVUseInvoiceCategoryDescription = _TVUseInvoiceCategoryDescription
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _TVUseInvoiceCategoryDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TVGroupByMarket() As Nullable(Of Boolean)
            Get
                TVGroupByMarket = _TVGroupByMarket
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _TVGroupByMarket = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TVShowOrderDescription() As Nullable(Of Boolean)
            Get
                TVShowOrderDescription = _TVShowOrderDescription
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _TVShowOrderDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TVShowClientReference() As Nullable(Of Boolean)
            Get
                TVShowClientReference = _TVShowClientReference
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _TVShowClientReference = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TVShowClientPO() As Nullable(Of Boolean)
            Get
                TVShowClientPO = _TVShowClientPO
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _TVShowClientPO = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TVShowOrderComment() As Nullable(Of Boolean)
            Get
                TVShowOrderComment = _TVShowOrderComment
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _TVShowOrderComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TVShowOrderHouseComment() As Nullable(Of Boolean)
            Get
                TVShowOrderHouseComment = _TVShowOrderHouseComment
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _TVShowOrderHouseComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TVPrintInvoiceDueDate() As Nullable(Of Boolean)
            Get
                TVPrintInvoiceDueDate = _TVPrintInvoiceDueDate
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _TVPrintInvoiceDueDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TVOrderNumberColumn() As Nullable(Of Short)
            Get
                TVOrderNumberColumn = _TVOrderNumberColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _TVOrderNumberColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TVVendorNameColumn() As Nullable(Of Short)
            Get
                TVVendorNameColumn = _TVVendorNameColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _TVVendorNameColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TVShowVendorCode() As Nullable(Of Short)
            Get
                TVShowVendorCode = _TVShowVendorCode
            End Get
            Set(ByVal value As Nullable(Of Short))
                _TVShowVendorCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TVOrderMonthsColumn() As Nullable(Of Short)
            Get
                TVOrderMonthsColumn = _TVOrderMonthsColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _TVOrderMonthsColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TVNetAmountColumn() As Nullable(Of Short)
            Get
                TVNetAmountColumn = _TVNetAmountColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _TVNetAmountColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TVCommissionAmountColumn() As Nullable(Of Short)
            Get
                TVCommissionAmountColumn = _TVCommissionAmountColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _TVCommissionAmountColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TVTaxAmountColumn() As Nullable(Of Short)
            Get
                TVTaxAmountColumn = _TVTaxAmountColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _TVTaxAmountColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TVBillAmountColumn() As Nullable(Of Short)
            Get
                TVBillAmountColumn = _TVBillAmountColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _TVBillAmountColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TVPriorBillAmountColumn() As Nullable(Of Short)
            Get
                TVPriorBillAmountColumn = _TVPriorBillAmountColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _TVPriorBillAmountColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TVBilledToDateAmountColumn() As Nullable(Of Short)
            Get
                TVBilledToDateAmountColumn = _TVBilledToDateAmountColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _TVBilledToDateAmountColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TVShowLineDetail() As Nullable(Of Boolean)
            Get
                TVShowLineDetail = _TVShowLineDetail
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _TVShowLineDetail = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TVProgramColumn() As Nullable(Of Short)
            Get
                TVProgramColumn = _TVProgramColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _TVProgramColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TVSpotLengthColumn() As Nullable(Of Short)
            Get
                TVSpotLengthColumn = _TVSpotLengthColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _TVSpotLengthColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TVTagColumn() As Nullable(Of Short)
            Get
                TVTagColumn = _TVTagColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _TVTagColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TVStartEndTimesColumn() As Nullable(Of Short)
            Get
                TVStartEndTimesColumn = _TVStartEndTimesColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _TVStartEndTimesColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TVNumberOfSpotsColumn() As Nullable(Of Short)
            Get
                TVNumberOfSpotsColumn = _TVNumberOfSpotsColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _TVNumberOfSpotsColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TVRemarksColumn() As Nullable(Of Short)
            Get
                TVRemarksColumn = _TVRemarksColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _TVRemarksColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TVJobComponentNumberColumn() As Nullable(Of Short)
            Get
                TVJobComponentNumberColumn = _TVJobComponentNumberColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _TVJobComponentNumberColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TVJobDescriptionColumn() As Nullable(Of Short)
            Get
                TVJobDescriptionColumn = _TVJobDescriptionColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _TVJobDescriptionColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TVComponentDescriptionColumn() As Nullable(Of Short)
            Get
                TVComponentDescriptionColumn = _TVComponentDescriptionColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _TVComponentDescriptionColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TVOrderDetailCommentColumn() As Nullable(Of Short)
            Get
                TVOrderDetailCommentColumn = _TVOrderDetailCommentColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _TVOrderDetailCommentColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TVOrderHouseDetailCommentColumn() As Nullable(Of Short)
            Get
                TVOrderHouseDetailCommentColumn = _TVOrderHouseDetailCommentColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _TVOrderHouseDetailCommentColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TVExtraChargesColumn() As Nullable(Of Short)
            Get
                TVExtraChargesColumn = _TVExtraChargesColumn
            End Get
            Set(ByVal value As Nullable(Of Short))
                _TVExtraChargesColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TVShowCommissionSeparately() As Nullable(Of Boolean)
            Get
                TVShowCommissionSeparately = _TVShowCommissionSeparately
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _TVShowCommissionSeparately = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TVShowRebateSeparately() As Nullable(Of Boolean)
            Get
                TVShowRebateSeparately = _TVShowRebateSeparately
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _TVShowRebateSeparately = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TVShowTaxSeparately() As Nullable(Of Boolean)
            Get
                TVShowTaxSeparately = _TVShowTaxSeparately
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _TVShowTaxSeparately = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TVShowBillingHistory() As Nullable(Of Boolean)
            Get
                TVShowBillingHistory = _TVShowBillingHistory
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _TVShowBillingHistory = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TVCustomFormatName() As String
            Get
                TVCustomFormatName = _TVCustomFormatName
            End Get
            Set(ByVal value As String)
                _TVCustomFormatName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PageHeaderComment() As String
            Get
                PageHeaderComment = _PageHeaderComment
            End Get
            Set(ByVal value As String)
                _PageHeaderComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PageFooterComment() As String
            Get
                PageFooterComment = _PageFooterComment
            End Get
            Set(ByVal value As String)
                _PageFooterComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PageHeaderLogoPath() As String
            Get
                PageHeaderLogoPath = _PageHeaderLogoPath
            End Get
            Set(ByVal value As String)
                _PageHeaderLogoPath = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PageHeaderLogoPathLandscape() As String
            Get
                PageHeaderLogoPathLandscape = _PageHeaderLogoPathLandscape
            End Get
            Set(ByVal value As String)
                _PageHeaderLogoPathLandscape = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PageFooterLogoPath() As String
            Get
                PageFooterLogoPath = _PageFooterLogoPath
            End Get
            Set(ByVal value As String)
                _PageFooterLogoPath = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PageFooterLogoPathLandscape() As String
            Get
                PageFooterLogoPathLandscape = _PageFooterLogoPathLandscape
            End Get
            Set(ByVal value As String)
                _PageFooterLogoPathLandscape = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CityTaxLabel() As String
            Get
                CityTaxLabel = _CityTaxLabel
            End Get
            Set(ByVal value As String)
                _CityTaxLabel = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CountyTaxLabel() As String
            Get
                CountyTaxLabel = _CountyTaxLabel
            End Get
            Set(ByVal value As String)
                _CountyTaxLabel = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property StateTaxLabel() As String
            Get
                StateTaxLabel = _StateTaxLabel
            End Get
            Set(ByVal value As String)
                _StateTaxLabel = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MediaInvoiceSettingID() As Nullable(Of Integer)
            Get
                MediaInvoiceSettingID = _MediaInvoiceSettingID
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _MediaInvoiceSettingID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property UseLocationPrintOptions() As Nullable(Of Boolean)
            Get
                UseLocationPrintOptions = _UseLocationPrintOptions
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _UseLocationPrintOptions = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CustomInvoiceID() As Nullable(Of Integer)
            Get
                CustomInvoiceID = _CustomInvoiceID
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _CustomInvoiceID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PrintClientName() As Boolean
            Get
                PrintClientName = _PrintClientName
            End Get
            Set(value As Boolean)
                _PrintClientName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MagazineShowCampaign() As Boolean
            Get
                MagazineShowCampaign = _MagazineShowCampaign
            End Get
            Set(value As Boolean)
                _MagazineShowCampaign = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewspaperShowCampaign() As Boolean
            Get
                NewspaperShowCampaign = _NewspaperShowCampaign
            End Get
            Set(value As Boolean)
                _NewspaperShowCampaign = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetShowCampaign() As Boolean
            Get
                InternetShowCampaign = _InternetShowCampaign
            End Get
            Set(value As Boolean)
                _InternetShowCampaign = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OutdoorShowCampaign() As Boolean
            Get
                OutdoorShowCampaign = _OutdoorShowCampaign
            End Get
            Set(value As Boolean)
                _OutdoorShowCampaign = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RadioShowCampaign() As Boolean
            Get
                RadioShowCampaign = _RadioShowCampaign
            End Get
            Set(value As Boolean)
                _RadioShowCampaign = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TVShowCampaign() As Boolean
            Get
                TVShowCampaign = _TVShowCampaign
            End Get
            Set(value As Boolean)
                _TVShowCampaign = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MagazineShowCampaignComment() As Boolean
            Get
                MagazineShowCampaignComment = _MagazineShowCampaignComment
            End Get
            Set(value As Boolean)
                _MagazineShowCampaignComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewspaperShowCampaignComment() As Boolean
            Get
                NewspaperShowCampaignComment = _NewspaperShowCampaignComment
            End Get
            Set(value As Boolean)
                _NewspaperShowCampaignComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetShowCampaignComment() As Boolean
            Get
                InternetShowCampaignComment = _InternetShowCampaignComment
            End Get
            Set(value As Boolean)
                _InternetShowCampaignComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OutdoorShowCampaignComment() As Boolean
            Get
                OutdoorShowCampaignComment = _OutdoorShowCampaignComment
            End Get
            Set(value As Boolean)
                _OutdoorShowCampaignComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RadioShowCampaignComment() As Boolean
            Get
                RadioShowCampaignComment = _RadioShowCampaignComment
            End Get
            Set(value As Boolean)
                _RadioShowCampaignComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TVShowCampaignComment() As Boolean
            Get
                TVShowCampaignComment = _TVShowCampaignComment
            End Get
            Set(value As Boolean)
                _TVShowCampaignComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MagazineShowOrderSubtotals() As Boolean
            Get
                MagazineShowOrderSubtotals = _MagazineShowOrderSubtotals
            End Get
            Set(value As Boolean)
                _MagazineShowOrderSubtotals = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewspaperShowOrderSubtotals() As Boolean
            Get
                NewspaperShowOrderSubtotals = _NewspaperShowOrderSubtotals
            End Get
            Set(value As Boolean)
                _NewspaperShowOrderSubtotals = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetShowOrderSubtotals() As Boolean
            Get
                InternetShowOrderSubtotals = _InternetShowOrderSubtotals
            End Get
            Set(value As Boolean)
                _InternetShowOrderSubtotals = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OutdoorShowOrderSubtotals() As Boolean
            Get
                OutdoorShowOrderSubtotals = _OutdoorShowOrderSubtotals
            End Get
            Set(value As Boolean)
                _OutdoorShowOrderSubtotals = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RadioShowOrderSubtotals() As Boolean
            Get
                RadioShowOrderSubtotals = _RadioShowOrderSubtotals
            End Get
            Set(value As Boolean)
                _RadioShowOrderSubtotals = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TVShowOrderSubtotals() As Boolean
            Get
                TVShowOrderSubtotals = _TVShowOrderSubtotals
            End Get
            Set(value As Boolean)
                _TVShowOrderSubtotals = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MagazineShowSalesClass() As Boolean
            Get
                MagazineShowSalesClass = _MagazineShowSalesClass
            End Get
            Set(value As Boolean)
                _MagazineShowSalesClass = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewspaperShowSalesClass() As Boolean
            Get
                NewspaperShowSalesClass = _NewspaperShowSalesClass
            End Get
            Set(value As Boolean)
                _NewspaperShowSalesClass = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetShowSalesClass() As Boolean
            Get
                InternetShowSalesClass = _InternetShowSalesClass
            End Get
            Set(value As Boolean)
                _InternetShowSalesClass = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OutdoorShowSalesClass() As Boolean
            Get
                OutdoorShowSalesClass = _OutdoorShowSalesClass
            End Get
            Set(value As Boolean)
                _OutdoorShowSalesClass = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RadioShowSalesClass() As Boolean
            Get
                RadioShowSalesClass = _RadioShowSalesClass
            End Get
            Set(value As Boolean)
                _RadioShowSalesClass = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TVShowSalesClass() As Boolean
            Get
                TVShowSalesClass = _TVShowSalesClass
            End Get
            Set(value As Boolean)
                _TVShowSalesClass = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MagazineClientPOLocation() As Nullable(Of Integer)
            Get
                MagazineClientPOLocation = _MagazineClientPOLocation
            End Get
            Set(value As Nullable(Of Integer))
                _MagazineClientPOLocation = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewspaperClientPOLocation() As Nullable(Of Integer)
            Get
                NewspaperClientPOLocation = _NewspaperClientPOLocation
            End Get
            Set(value As Nullable(Of Integer))
                _NewspaperClientPOLocation = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetClientPOLocation() As Nullable(Of Integer)
            Get
                InternetClientPOLocation = _InternetClientPOLocation
            End Get
            Set(value As Nullable(Of Integer))
                _InternetClientPOLocation = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OutdoorClientPOLocation() As Nullable(Of Integer)
            Get
                OutdoorClientPOLocation = _OutdoorClientPOLocation
            End Get
            Set(value As Nullable(Of Integer))
                _OutdoorClientPOLocation = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RadioClientPOLocation() As Nullable(Of Integer)
            Get
                RadioClientPOLocation = _RadioClientPOLocation
            End Get
            Set(value As Nullable(Of Integer))
                _RadioClientPOLocation = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TVClientPOLocation() As Nullable(Of Integer)
            Get
                TVClientPOLocation = _TVClientPOLocation
            End Get
            Set(value As Nullable(Of Integer))
                _TVClientPOLocation = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MagazineSalesClassLocation() As Nullable(Of Integer)
            Get
                MagazineSalesClassLocation = _MagazineSalesClassLocation
            End Get
            Set(value As Nullable(Of Integer))
                _MagazineSalesClassLocation = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewspaperSalesClassLocation() As Nullable(Of Integer)
            Get
                NewspaperSalesClassLocation = _NewspaperSalesClassLocation
            End Get
            Set(value As Nullable(Of Integer))
                _NewspaperSalesClassLocation = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetSalesClassLocation() As Nullable(Of Integer)
            Get
                InternetSalesClassLocation = _InternetSalesClassLocation
            End Get
            Set(value As Nullable(Of Integer))
                _InternetSalesClassLocation = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OutdoorSalesClassLocation() As Nullable(Of Integer)
            Get
                OutdoorSalesClassLocation = _OutdoorSalesClassLocation
            End Get
            Set(value As Nullable(Of Integer))
                _OutdoorSalesClassLocation = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RadioSalesClassLocation() As Nullable(Of Integer)
            Get
                RadioSalesClassLocation = _RadioSalesClassLocation
            End Get
            Set(value As Nullable(Of Integer))
                _RadioSalesClassLocation = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TVSalesClassLocation() As Nullable(Of Integer)
            Get
                TVSalesClassLocation = _TVSalesClassLocation
            End Get
            Set(value As Nullable(Of Integer))
                _TVSalesClassLocation = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MagazineCampaignLocation() As Nullable(Of Integer)
            Get
                MagazineCampaignLocation = _MagazineCampaignLocation
            End Get
            Set(value As Nullable(Of Integer))
                _MagazineCampaignLocation = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewspaperCampaignLocation() As Nullable(Of Integer)
            Get
                NewspaperCampaignLocation = _NewspaperCampaignLocation
            End Get
            Set(value As Nullable(Of Integer))
                _NewspaperCampaignLocation = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetCampaignLocation() As Nullable(Of Integer)
            Get
                InternetCampaignLocation = _InternetCampaignLocation
            End Get
            Set(value As Nullable(Of Integer))
                _InternetCampaignLocation = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OutdoorCampaignLocation() As Nullable(Of Integer)
            Get
                OutdoorCampaignLocation = _OutdoorCampaignLocation
            End Get
            Set(value As Nullable(Of Integer))
                _OutdoorCampaignLocation = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RadioCampaignLocation() As Nullable(Of Integer)
            Get
                RadioCampaignLocation = _RadioCampaignLocation
            End Get
            Set(value As Nullable(Of Integer))
                _RadioCampaignLocation = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TVCampaignLocation() As Nullable(Of Integer)
            Get
                TVCampaignLocation = _TVCampaignLocation
            End Get
            Set(value As Nullable(Of Integer))
                _TVCampaignLocation = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MagazineHeaderGroupBy() As Nullable(Of Integer)
            Get
                MagazineHeaderGroupBy = _MagazineHeaderGroupBy
            End Get
            Set(value As Nullable(Of Integer))
                _MagazineHeaderGroupBy = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewspaperHeaderGroupBy() As Nullable(Of Integer)
            Get
                NewspaperHeaderGroupBy = _NewspaperHeaderGroupBy
            End Get
            Set(value As Nullable(Of Integer))
                _NewspaperHeaderGroupBy = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetHeaderGroupBy() As Nullable(Of Integer)
            Get
                InternetHeaderGroupBy = _InternetHeaderGroupBy
            End Get
            Set(value As Nullable(Of Integer))
                _InternetHeaderGroupBy = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OutdoorHeaderGroupBy() As Nullable(Of Integer)
            Get
                OutdoorHeaderGroupBy = _OutdoorHeaderGroupBy
            End Get
            Set(value As Nullable(Of Integer))
                _OutdoorHeaderGroupBy = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RadioHeaderGroupBy() As Nullable(Of Integer)
            Get
                RadioHeaderGroupBy = _RadioHeaderGroupBy
            End Get
            Set(value As Nullable(Of Integer))
                _RadioHeaderGroupBy = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TVHeaderGroupBy() As Nullable(Of Integer)
            Get
                TVHeaderGroupBy = _TVHeaderGroupBy
            End Get
            Set(value As Nullable(Of Integer))
                _TVHeaderGroupBy = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MagazineSortLinesBy() As Nullable(Of Integer)
            Get
                MagazineSortLinesBy = _MagazineSortLinesBy
            End Get
            Set(value As Nullable(Of Integer))
                _MagazineSortLinesBy = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewspaperSortLinesBy() As Nullable(Of Integer)
            Get
                NewspaperSortLinesBy = _NewspaperSortLinesBy
            End Get
            Set(value As Nullable(Of Integer))
                _NewspaperSortLinesBy = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetSortLinesBy() As Nullable(Of Integer)
            Get
                InternetSortLinesBy = _InternetSortLinesBy
            End Get
            Set(value As Nullable(Of Integer))
                _InternetSortLinesBy = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OutdoorSortLinesBy() As Nullable(Of Integer)
            Get
                OutdoorSortLinesBy = _OutdoorSortLinesBy
            End Get
            Set(value As Nullable(Of Integer))
                _OutdoorSortLinesBy = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RadioSortLinesBy() As Nullable(Of Integer)
            Get
                RadioSortLinesBy = _RadioSortLinesBy
            End Get
            Set(value As Nullable(Of Integer))
                _RadioSortLinesBy = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TVSortLinesBy() As Nullable(Of Integer)
            Get
                TVSortLinesBy = _TVSortLinesBy
            End Get
            Set(value As Nullable(Of Integer))
                _TVSortLinesBy = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MagazineLineNumberColumn() As Nullable(Of Short)
            Get
                MagazineLineNumberColumn = _MagazineLineNumberColumn
            End Get
            Set(value As Nullable(Of Short))
                _MagazineLineNumberColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewspaperLineNumberColumn() As Nullable(Of Short)
            Get
                NewspaperLineNumberColumn = _NewspaperLineNumberColumn
            End Get
            Set(value As Nullable(Of Short))
                _NewspaperLineNumberColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetLineNumberColumn() As Nullable(Of Short)
            Get
                InternetLineNumberColumn = _InternetLineNumberColumn
            End Get
            Set(value As Nullable(Of Short))
                _InternetLineNumberColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OutdoorLineNumberColumn() As Nullable(Of Short)
            Get
                OutdoorLineNumberColumn = _OutdoorLineNumberColumn
            End Get
            Set(value As Nullable(Of Short))
                _OutdoorLineNumberColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RadioLineNumberColumn() As Nullable(Of Short)
            Get
                RadioLineNumberColumn = _RadioLineNumberColumn
            End Get
            Set(value As Nullable(Of Short))
                _RadioLineNumberColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TVLineNumberColumn() As Nullable(Of Short)
            Get
                TVLineNumberColumn = _TVLineNumberColumn
            End Get
            Set(value As Nullable(Of Short))
                _TVLineNumberColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MagazineShowZeroLineAmounts() As Boolean
            Get
                MagazineShowZeroLineAmounts = _MagazineShowZeroLineAmounts
            End Get
            Set(value As Boolean)
                _MagazineShowZeroLineAmounts = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewspaperShowZeroLineAmounts() As Boolean
            Get
                NewspaperShowZeroLineAmounts = _NewspaperShowZeroLineAmounts
            End Get
            Set(value As Boolean)
                _NewspaperShowZeroLineAmounts = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetShowZeroLineAmounts() As Boolean
            Get
                InternetShowZeroLineAmounts = _InternetShowZeroLineAmounts
            End Get
            Set(value As Boolean)
                _InternetShowZeroLineAmounts = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OutdoorShowZeroLineAmounts() As Boolean
            Get
                OutdoorShowZeroLineAmounts = _OutdoorShowZeroLineAmounts
            End Get
            Set(value As Boolean)
                _OutdoorShowZeroLineAmounts = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RadioShowZeroLineAmounts() As Boolean
            Get
                RadioShowZeroLineAmounts = _RadioShowZeroLineAmounts
            End Get
            Set(value As Boolean)
                _RadioShowZeroLineAmounts = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TVShowZeroLineAmounts() As Boolean
            Get
                TVShowZeroLineAmounts = _TVShowZeroLineAmounts
            End Get
            Set(value As Boolean)
                _TVShowZeroLineAmounts = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MagazineUseAgencySetting() As Boolean
            Get
                MagazineUseAgencySetting = _MagazineUseAgencySetting
            End Get
            Set(value As Boolean)
                _MagazineUseAgencySetting = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewspaperUseAgencySetting() As Boolean
            Get
                NewspaperUseAgencySetting = _NewspaperUseAgencySetting
            End Get
            Set(value As Boolean)
                _NewspaperUseAgencySetting = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetUseAgencySetting() As Boolean
            Get
                InternetUseAgencySetting = _InternetUseAgencySetting
            End Get
            Set(value As Boolean)
                _InternetUseAgencySetting = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OutdoorUseAgencySetting() As Boolean
            Get
                OutdoorUseAgencySetting = _OutdoorUseAgencySetting
            End Get
            Set(value As Boolean)
                _OutdoorUseAgencySetting = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RadioUseAgencySetting() As Boolean
            Get
                RadioUseAgencySetting = _RadioUseAgencySetting
            End Get
            Set(value As Boolean)
                _RadioUseAgencySetting = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TVUseAgencySetting() As Boolean
            Get
                TVUseAgencySetting = _TVUseAgencySetting
            End Get
            Set(value As Boolean)
                _TVUseAgencySetting = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MagazineCloseDateColumn() As Nullable(Of Short)
            Get
                MagazineCloseDateColumn = _MagazineCloseDateColumn
            End Get
            Set(value As Nullable(Of Short))
                _MagazineCloseDateColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NewspaperCloseDateColumn() As Nullable(Of Short)
            Get
                NewspaperCloseDateColumn = _NewspaperCloseDateColumn
            End Get
            Set(value As Nullable(Of Short))
                _NewspaperCloseDateColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetCloseDateColumn() As Nullable(Of Short)
            Get
                InternetCloseDateColumn = _InternetCloseDateColumn
            End Get
            Set(value As Nullable(Of Short))
                _InternetCloseDateColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OutdoorCloseDateColumn() As Nullable(Of Short)
            Get
                OutdoorCloseDateColumn = _OutdoorCloseDateColumn
            End Get
            Set(value As Nullable(Of Short))
                _OutdoorCloseDateColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RadioCloseDateColumn() As Nullable(Of Short)
            Get
                RadioCloseDateColumn = _RadioCloseDateColumn
            End Get
            Set(value As Nullable(Of Short))
                _RadioCloseDateColumn = value
            End Set
        End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property TVCloseDateColumn() As Nullable(Of Short)
			Get
				TVCloseDateColumn = _TVCloseDateColumn
			End Get
			Set(value As Nullable(Of Short))
				_TVCloseDateColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property MagazineCustomInvoiceID() As Nullable(Of Integer)
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property NewspaperCustomInvoiceID() As Nullable(Of Integer)
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property InternetCustomInvoiceID() As Nullable(Of Integer)
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property OutdoorCustomInvoiceID() As Nullable(Of Integer)
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property RadioCustomInvoiceID() As Nullable(Of Integer)
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TVCustomInvoiceID() As Nullable(Of Integer)
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShowPageHeaderLogo() As Boolean
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShowPageFooterLogo() As Boolean
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property HideExchangeRateMessage() As Boolean

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.IsOneTime.ToString

        End Function

#End Region

    End Class

End Namespace
