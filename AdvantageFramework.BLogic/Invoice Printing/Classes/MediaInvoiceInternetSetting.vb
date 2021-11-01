Namespace InvoicePrinting.Classes

    <Serializable()>
    Public Class MediaInvoiceInternetSetting

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            InternetUseInvoiceCategoryDescription
            InternetInvoiceTitle
            InternetGroupByMarket
            InternetShowOrderDescription
            InternetShowClientReference
            InternetShowClientPO
            InternetShowOrderComment
            InternetShowOrderHouseComment
            InternetPrintInvoiceDueDate
            InternetShowLineDetail
            InternetOrderNumberColumn
            InternetVendorNameColumn
            InternetShowVendorCode
            InternetOrderMonthsColumn
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
            InternetCustomFormatName
            InternetShowCampaign
            InternetShowCampaignComment
            InternetShowOrderSubtotals
            InternetShowSalesClass
            InternetClientPOLocation
            InternetSalesClassLocation
            InternetCampaignLocation
            InternetHeaderGroupBy
            InternetSortLinesBy
            InternetLineNumberColumn
            InternetShowZeroLineAmounts
			InternetCloseDateColumn
			InternetCustomInvoiceID
		End Enum

#End Region

#Region " Variables "

        Private _InternetUseInvoiceCategoryDescription As Boolean = False
        Private _InternetInvoiceTitle As String = Nothing
        Private _InternetGroupByMarket As Boolean = False
        Private _InternetShowOrderDescription As Boolean = False
        Private _InternetShowClientReference As Boolean = False
        Private _InternetShowClientPO As Boolean = False
        Private _InternetShowOrderComment As Boolean = False
        Private _InternetShowOrderHouseComment As Boolean = False
        Private _InternetPrintInvoiceDueDate As Boolean = False
        Private _InternetShowLineDetail As Integer = False
        Private _InternetOrderNumberColumn As Short = 1
        Private _InternetVendorNameColumn As Short = 0
        Private _InternetShowVendorCode As Short = 0
        Private _InternetOrderMonthsColumn As Short = 0
        Private _InternetHeadlineColumn As Short = 0
        Private _InternetStartDatesColumn As Short = 0
        Private _InternetEndDatesColumn As Short = 0
        Private _InternetCreativeSizeColumn As Short = 0
        Private _InternetAdNumberColumn As Short = 0
        Private _InternetURLColumn As Short = 0
        Private _InternetInternetTypeColumn As Short = 0
        Private _InternetJobComponentNumberColumn As Short = 0
        Private _InternetJobDescriptionColumn As Short = 0
        Private _InternetComponentDescriptionColumn As Short = 0
        Private _InternetExtraChargesColumn As Short = 0
        Private _InternetNetAmountColumn As Short = 0
        Private _InternetCommissionAmountColumn As Short = 0
        Private _InternetTaxAmountColumn As Short = 0
        Private _InternetBillAmountColumn As Short = 0
        Private _InternetPriorBillAmountColumn As Short = 0
        Private _InternetBilledToDateAmountColumn As Short = 0
        Private _InternetShowCommissionSeparately As Boolean = False
        Private _InternetShowRebateSeparately As Boolean = False
        Private _InternetShowTaxSeparately As Boolean = False
        Private _InternetShowBillingHistory As Boolean = False
        Private _InternetCustomFormatName As String = Nothing
        Private _InternetShowCampaign As Boolean = False
        Private _InternetShowCampaignComment As Boolean = False
        Private _InternetShowOrderSubtotals As Boolean = False
        Private _InternetShowSalesClass As Boolean = False
        Private _InternetClientPOLocation As Integer = 1
        Private _InternetSalesClassLocation As Integer = 1
        Private _InternetCampaignLocation As Integer = 1
        Private _InternetHeaderGroupBy As Integer = Nothing
        Private _InternetSortLinesBy As Integer = 1
        Private _InternetLineNumberColumn As Short = 0
        Private _InternetShowZeroLineAmounts As Boolean = False
        Private _InternetCloseDateColumn As Short = 0
		Private _InternetCustomInvoiceID As Nullable(Of Integer) = Nothing

		Private _MediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault = Nothing
        Private _InvoicePrintingMediaSetting As InvoicePrintingMediaSetting = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetUseInvoiceCategoryDescription As Boolean
            Get
                InternetUseInvoiceCategoryDescription = _InternetUseInvoiceCategoryDescription
            End Get
            Set(ByVal value As Boolean)
                _InternetUseInvoiceCategoryDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetInvoiceTitle As String
            Get
                InternetInvoiceTitle = _InternetInvoiceTitle
            End Get
            Set(ByVal value As String)
                _InternetInvoiceTitle = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetGroupByMarket As Boolean
            Get
                InternetGroupByMarket = _InternetGroupByMarket
            End Get
            Set(ByVal value As Boolean)
                _InternetGroupByMarket = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetShowOrderDescription As Boolean
            Get
                InternetShowOrderDescription = _InternetShowOrderDescription
            End Get
            Set(ByVal value As Boolean)
                _InternetShowOrderDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetShowClientReference As Boolean
            Get
                InternetShowClientReference = _InternetShowClientReference
            End Get
            Set(ByVal value As Boolean)
                _InternetShowClientReference = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetShowClientPO As Boolean
            Get
                InternetShowClientPO = _InternetShowClientPO
            End Get
            Set(ByVal value As Boolean)
                _InternetShowClientPO = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetShowOrderComment As Boolean
            Get
                InternetShowOrderComment = _InternetShowOrderComment
            End Get
            Set(ByVal value As Boolean)
                _InternetShowOrderComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetShowOrderHouseComment As Boolean
            Get
                InternetShowOrderHouseComment = _InternetShowOrderHouseComment
            End Get
            Set(ByVal value As Boolean)
                _InternetShowOrderHouseComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetPrintInvoiceDueDate As Boolean
            Get
                InternetPrintInvoiceDueDate = _InternetPrintInvoiceDueDate
            End Get
            Set(ByVal value As Boolean)
                _InternetPrintInvoiceDueDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetShowLineDetail As Integer
            Get
                InternetShowLineDetail = _InternetShowLineDetail
            End Get
            Set(ByVal value As Integer)
                _InternetShowLineDetail = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetOrderNumberColumn As Short
            Get
                InternetOrderNumberColumn = _InternetOrderNumberColumn
            End Get
            Set(ByVal value As Short)
                _InternetOrderNumberColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetVendorNameColumn As Short
            Get
                InternetVendorNameColumn = _InternetVendorNameColumn
            End Get
            Set(ByVal value As Short)
                _InternetVendorNameColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetShowVendorCode As Short
            Get
                InternetShowVendorCode = _InternetShowVendorCode
            End Get
            Set(ByVal value As Short)
                _InternetShowVendorCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        System.ComponentModel.Category("Columns")>
        Public Property InternetOrderMonthsColumn As Short
            Get
                InternetOrderMonthsColumn = _InternetOrderMonthsColumn
            End Get
            Set(ByVal value As Short)
                _InternetOrderMonthsColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        System.ComponentModel.Category("Columns")>
        Public Property InternetHeadlineColumn As Short
            Get
                InternetHeadlineColumn = _InternetHeadlineColumn
            End Get
            Set(ByVal value As Short)
                _InternetHeadlineColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        System.ComponentModel.Category("Columns")>
        Public Property InternetStartDatesColumn As Short
            Get
                InternetStartDatesColumn = _InternetStartDatesColumn
            End Get
            Set(ByVal value As Short)
                _InternetStartDatesColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        System.ComponentModel.Category("Columns")>
        Public Property InternetEndDatesColumn As Short
            Get
                InternetEndDatesColumn = _InternetEndDatesColumn
            End Get
            Set(ByVal value As Short)
                _InternetEndDatesColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        System.ComponentModel.Category("Columns")>
        Public Property InternetCreativeSizeColumn As Short
            Get
                InternetCreativeSizeColumn = _InternetCreativeSizeColumn
            End Get
            Set(ByVal value As Short)
                _InternetCreativeSizeColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        System.ComponentModel.Category("Columns")>
        Public Property InternetAdNumberColumn As Short
            Get
                InternetAdNumberColumn = _InternetAdNumberColumn
            End Get
            Set(ByVal value As Short)
                _InternetAdNumberColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        System.ComponentModel.Category("Columns")>
        Public Property InternetURLColumn As Short
            Get
                InternetURLColumn = _InternetURLColumn
            End Get
            Set(ByVal value As Short)
                _InternetURLColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        System.ComponentModel.Category("Columns")>
        Public Property InternetInternetTypeColumn As Short
            Get
                InternetInternetTypeColumn = _InternetInternetTypeColumn
            End Get
            Set(ByVal value As Short)
                _InternetInternetTypeColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        System.ComponentModel.Category("Columns")>
        Public Property InternetJobComponentNumberColumn As Short
            Get
                InternetJobComponentNumberColumn = _InternetJobComponentNumberColumn
            End Get
            Set(ByVal value As Short)
                _InternetJobComponentNumberColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        System.ComponentModel.Category("Columns")>
        Public Property InternetJobDescriptionColumn As Short
            Get
                InternetJobDescriptionColumn = _InternetJobDescriptionColumn
            End Get
            Set(ByVal value As Short)
                _InternetJobDescriptionColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        System.ComponentModel.Category("Columns")>
        Public Property InternetComponentDescriptionColumn As Short
            Get
                InternetComponentDescriptionColumn = _InternetComponentDescriptionColumn
            End Get
            Set(ByVal value As Short)
                _InternetComponentDescriptionColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetExtraChargesColumn As Short
            Get
                InternetExtraChargesColumn = _InternetExtraChargesColumn
            End Get
            Set(ByVal value As Short)
                _InternetExtraChargesColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        System.ComponentModel.Category("Columns")>
        Public Property InternetNetAmountColumn As Short
            Get
                InternetNetAmountColumn = _InternetNetAmountColumn
            End Get
            Set(ByVal value As Short)
                _InternetNetAmountColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        System.ComponentModel.Category("Columns")>
        Public Property InternetCommissionAmountColumn As Short
            Get
                InternetCommissionAmountColumn = _InternetCommissionAmountColumn
            End Get
            Set(ByVal value As Short)
                _InternetCommissionAmountColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        System.ComponentModel.Category("Columns")>
        Public Property InternetTaxAmountColumn As Short
            Get
                InternetTaxAmountColumn = _InternetTaxAmountColumn
            End Get
            Set(ByVal value As Short)
                _InternetTaxAmountColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        System.ComponentModel.Category("Columns")>
        Public Property InternetBillAmountColumn As Short
            Get
                InternetBillAmountColumn = _InternetBillAmountColumn
            End Get
            Set(ByVal value As Short)
                _InternetBillAmountColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        System.ComponentModel.Category("Columns")>
        Public Property InternetPriorBillAmountColumn As Short
            Get
                InternetPriorBillAmountColumn = _InternetPriorBillAmountColumn
            End Get
            Set(ByVal value As Short)
                _InternetPriorBillAmountColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        System.ComponentModel.Category("Columns")>
        Public Property InternetBilledToDateAmountColumn As Short
            Get
                InternetBilledToDateAmountColumn = _InternetBilledToDateAmountColumn
            End Get
            Set(ByVal value As Short)
                _InternetBilledToDateAmountColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetShowCommissionSeparately As Boolean
            Get
                InternetShowCommissionSeparately = _InternetShowCommissionSeparately
            End Get
            Set(ByVal value As Boolean)
                _InternetShowCommissionSeparately = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetShowRebateSeparately As Boolean
            Get
                InternetShowRebateSeparately = _InternetShowRebateSeparately
            End Get
            Set(ByVal value As Boolean)
                _InternetShowRebateSeparately = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetShowTaxSeparately As Boolean
            Get
                InternetShowTaxSeparately = _InternetShowTaxSeparately
            End Get
            Set(ByVal value As Boolean)
                _InternetShowTaxSeparately = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetShowBillingHistory As Boolean
            Get
                InternetShowBillingHistory = _InternetShowBillingHistory
            End Get
            Set(ByVal value As Boolean)
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
        Public Property InternetShowCampaign() As Boolean
            Get
                InternetShowCampaign = _InternetShowCampaign
            End Get
            Set(ByVal value As Boolean)
                _InternetShowCampaign = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetShowCampaignComment() As Boolean
            Get
                InternetShowCampaignComment = _InternetShowCampaignComment
            End Get
            Set(ByVal value As Boolean)
                _InternetShowCampaignComment = value
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
        Public Property InternetShowSalesClass() As Boolean
            Get
                InternetShowSalesClass = _InternetShowSalesClass
            End Get
            Set(value As Boolean)
                _InternetShowSalesClass = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetClientPOLocation() As Integer
            Get
                InternetClientPOLocation = _InternetClientPOLocation
            End Get
            Set(value As Integer)
                _InternetClientPOLocation = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetSalesClassLocation() As Integer
            Get
                InternetSalesClassLocation = _InternetSalesClassLocation
            End Get
            Set(value As Integer)
                _InternetSalesClassLocation = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetCampaignLocation() As Integer
            Get
                InternetCampaignLocation = _InternetCampaignLocation
            End Get
            Set(value As Integer)
                _InternetCampaignLocation = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetHeaderGroupBy() As Integer
            Get
                InternetHeaderGroupBy = _InternetHeaderGroupBy
            End Get
            Set(value As Integer)
                _InternetHeaderGroupBy = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InternetSortLinesBy() As Integer
            Get
                InternetSortLinesBy = _InternetSortLinesBy
            End Get
            Set(value As Integer)
                _InternetSortLinesBy = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        System.ComponentModel.Category("Columns")>
        Public Property InternetLineNumberColumn() As Short
            Get
                InternetLineNumberColumn = _InternetLineNumberColumn
            End Get
            Set(value As Short)
                _InternetLineNumberColumn = value
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
        <System.Runtime.Serialization.DataMemberAttribute(),
        System.ComponentModel.Category("Columns")>
        Public Property InternetCloseDateColumn() As Short
            Get
                InternetCloseDateColumn = _InternetCloseDateColumn
            End Get
            Set(value As Short)
                _InternetCloseDateColumn = value
            End Set
        End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.DisplayName("Custom Invoice")>
		Public Property InternetCustomInvoiceID() As Nullable(Of Integer)
			Get
				InternetCustomInvoiceID = _InternetCustomInvoiceID
			End Get
			Set(ByVal value As Nullable(Of Integer))
				_InternetCustomInvoiceID = value
			End Set
		End Property

#End Region

#Region " Methods "

		Public Sub New()



        End Sub
        Public Sub New(ByVal MediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault)

            Me.InternetUseInvoiceCategoryDescription = Convert.ToBoolean(MediaInvoiceDefault.InternetUseInvoiceCategoryDescription.GetValueOrDefault(0))
            Me.InternetInvoiceTitle = MediaInvoiceDefault.InternetInvoiceTitle
            Me.InternetGroupByMarket = Convert.ToBoolean(MediaInvoiceDefault.InternetGroupByMarket.GetValueOrDefault(0))
            Me.InternetShowOrderDescription = Convert.ToBoolean(MediaInvoiceDefault.InternetShowOrderDescription.GetValueOrDefault(0))
            Me.InternetShowClientReference = Convert.ToBoolean(MediaInvoiceDefault.InternetShowClientReference.GetValueOrDefault(0))
            Me.InternetShowClientPO = Convert.ToBoolean(MediaInvoiceDefault.InternetShowClientPO.GetValueOrDefault(0))
            Me.InternetShowOrderComment = Convert.ToBoolean(MediaInvoiceDefault.InternetShowOrderComment.GetValueOrDefault(0))
            Me.InternetShowOrderHouseComment = Convert.ToBoolean(MediaInvoiceDefault.InternetShowOrderHouseComment.GetValueOrDefault(0))
            Me.InternetPrintInvoiceDueDate = Convert.ToBoolean(MediaInvoiceDefault.InternetPrintInvoiceDueDate.GetValueOrDefault(0))
            Me.InternetShowLineDetail = Convert.ToInt32(MediaInvoiceDefault.InternetShowLineDetail.GetValueOrDefault(0))

            Me.InternetOrderNumberColumn = MediaInvoiceDefault.InternetOrderNumberColumn.GetValueOrDefault(1)
            Me.InternetVendorNameColumn = MediaInvoiceDefault.InternetVendorNameColumn.GetValueOrDefault(2)
            Me.InternetShowVendorCode = MediaInvoiceDefault.InternetShowVendorCode.GetValueOrDefault(0)
            Me.InternetOrderMonthsColumn = MediaInvoiceDefault.InternetOrderMonthsColumn.GetValueOrDefault(0)
            Me.InternetNetAmountColumn = MediaInvoiceDefault.InternetNetAmountColumn.GetValueOrDefault(0)
            Me.InternetCommissionAmountColumn = MediaInvoiceDefault.InternetCommissionAmountColumn.GetValueOrDefault(0)
            Me.InternetTaxAmountColumn = MediaInvoiceDefault.InternetTaxAmountColumn.GetValueOrDefault(0)
            Me.InternetBillAmountColumn = MediaInvoiceDefault.InternetBillAmountColumn.GetValueOrDefault(0)
            Me.InternetPriorBillAmountColumn = MediaInvoiceDefault.InternetPriorBillAmountColumn.GetValueOrDefault(0)
            Me.InternetBilledToDateAmountColumn = MediaInvoiceDefault.InternetBilledToDateAmountColumn.GetValueOrDefault(0)
            Me.InternetHeadlineColumn = MediaInvoiceDefault.InternetHeadlineColumn.GetValueOrDefault(0)
            Me.InternetStartDatesColumn = MediaInvoiceDefault.InternetStartDatesColumn.GetValueOrDefault(0)
            Me.InternetEndDatesColumn = MediaInvoiceDefault.InternetEndDatesColumn.GetValueOrDefault(0)
            Me.InternetCreativeSizeColumn = MediaInvoiceDefault.InternetCreativeSizeColumn.GetValueOrDefault(0)
            Me.InternetAdNumberColumn = MediaInvoiceDefault.InternetAdNumberColumn.GetValueOrDefault(0)
            Me.InternetURLColumn = MediaInvoiceDefault.InternetURLColumn.GetValueOrDefault(0)
            Me.InternetInternetTypeColumn = MediaInvoiceDefault.InternetInternetTypeColumn.GetValueOrDefault(0)
            Me.InternetJobComponentNumberColumn = MediaInvoiceDefault.InternetJobComponentNumberColumn.GetValueOrDefault(0)
            Me.InternetJobDescriptionColumn = MediaInvoiceDefault.InternetJobDescriptionColumn.GetValueOrDefault(0)
            Me.InternetComponentDescriptionColumn = MediaInvoiceDefault.InternetComponentDescriptionColumn.GetValueOrDefault(0)
            Me.InternetExtraChargesColumn = MediaInvoiceDefault.InternetExtraChargesColumn.GetValueOrDefault(0)

            Me.InternetShowCommissionSeparately = Convert.ToBoolean(MediaInvoiceDefault.InternetShowCommissionSeparately.GetValueOrDefault(0))
            Me.InternetShowRebateSeparately = Convert.ToBoolean(MediaInvoiceDefault.InternetShowRebateSeparately.GetValueOrDefault(0))
            Me.InternetShowTaxSeparately = Convert.ToBoolean(MediaInvoiceDefault.InternetShowTaxSeparately.GetValueOrDefault(0))
            Me.InternetShowBillingHistory = Convert.ToBoolean(MediaInvoiceDefault.InternetShowBillingHistory.GetValueOrDefault(0))
            Me.InternetShowCampaign = MediaInvoiceDefault.InternetShowCampaign
            Me.InternetShowCampaignComment = MediaInvoiceDefault.InternetShowCampaignComment
            Me.InternetShowOrderSubtotals = MediaInvoiceDefault.InternetShowOrderSubtotals

            Me.InternetShowSalesClass = MediaInvoiceDefault.InternetShowSalesClass
            Me.InternetClientPOLocation = MediaInvoiceDefault.InternetClientPOLocation
            Me.InternetSalesClassLocation = MediaInvoiceDefault.InternetSalesClassLocation
            Me.InternetCampaignLocation = MediaInvoiceDefault.InternetCampaignLocation
            Me.InternetHeaderGroupBy = MediaInvoiceDefault.InternetHeaderGroupBy
            Me.InternetSortLinesBy = MediaInvoiceDefault.InternetSortLinesBy
            Me.InternetLineNumberColumn = MediaInvoiceDefault.InternetLineNumberColumn
            Me.InternetShowZeroLineAmounts = MediaInvoiceDefault.InternetShowZeroLineAmounts
            Me.InternetCloseDateColumn = MediaInvoiceDefault.InternetCloseDateColumn
			Me.InternetCustomInvoiceID = MediaInvoiceDefault.InternetCustomInvoiceID

			_MediaInvoiceDefault = MediaInvoiceDefault

        End Sub
        Public Sub New(ByVal InvoicePrintingMediaSetting As InvoicePrintingMediaSetting)

            Me.InternetUseInvoiceCategoryDescription = InvoicePrintingMediaSetting.InternetUseInvoiceCategoryDescription.GetValueOrDefault(False)
            Me.InternetInvoiceTitle = InvoicePrintingMediaSetting.InternetInvoiceTitle
            Me.InternetGroupByMarket = InvoicePrintingMediaSetting.InternetGroupByMarket.GetValueOrDefault(False)
            Me.InternetShowOrderDescription = InvoicePrintingMediaSetting.InternetShowOrderDescription.GetValueOrDefault(False)
            Me.InternetShowClientReference = InvoicePrintingMediaSetting.InternetShowClientReference.GetValueOrDefault(False)
            Me.InternetShowClientPO = InvoicePrintingMediaSetting.InternetShowClientPO.GetValueOrDefault(False)
            Me.InternetShowOrderComment = InvoicePrintingMediaSetting.InternetShowOrderComment.GetValueOrDefault(False)
            Me.InternetShowOrderHouseComment = InvoicePrintingMediaSetting.InternetShowOrderHouseComment.GetValueOrDefault(False)
            Me.InternetPrintInvoiceDueDate = InvoicePrintingMediaSetting.InternetPrintInvoiceDueDate.GetValueOrDefault(False)
            Me.InternetShowLineDetail = If(InvoicePrintingMediaSetting.InternetShowLineDetail.GetValueOrDefault(False) = True, 1, 0)

            Me.InternetOrderNumberColumn = InvoicePrintingMediaSetting.InternetOrderNumberColumn.GetValueOrDefault(1)
            Me.InternetVendorNameColumn = InvoicePrintingMediaSetting.InternetVendorNameColumn.GetValueOrDefault(2)
            Me.InternetShowVendorCode = InvoicePrintingMediaSetting.InternetShowVendorCode.GetValueOrDefault(0)
            Me.InternetOrderMonthsColumn = InvoicePrintingMediaSetting.InternetOrderMonthsColumn.GetValueOrDefault(0)
            Me.InternetNetAmountColumn = InvoicePrintingMediaSetting.InternetNetAmountColumn.GetValueOrDefault(0)
            Me.InternetCommissionAmountColumn = InvoicePrintingMediaSetting.InternetCommissionAmountColumn.GetValueOrDefault(0)
            Me.InternetTaxAmountColumn = InvoicePrintingMediaSetting.InternetTaxAmountColumn.GetValueOrDefault(0)
            Me.InternetBillAmountColumn = InvoicePrintingMediaSetting.InternetBillAmountColumn.GetValueOrDefault(0)
            Me.InternetPriorBillAmountColumn = InvoicePrintingMediaSetting.InternetPriorBillAmountColumn.GetValueOrDefault(0)
            Me.InternetBilledToDateAmountColumn = InvoicePrintingMediaSetting.InternetBilledToDateAmountColumn.GetValueOrDefault(0)
            Me.InternetHeadlineColumn = InvoicePrintingMediaSetting.InternetHeadlineColumn.GetValueOrDefault(0)
            Me.InternetStartDatesColumn = InvoicePrintingMediaSetting.InternetStartDatesColumn.GetValueOrDefault(0)
            Me.InternetEndDatesColumn = InvoicePrintingMediaSetting.InternetEndDatesColumn.GetValueOrDefault(0)
            Me.InternetCreativeSizeColumn = InvoicePrintingMediaSetting.InternetCreativeSizeColumn.GetValueOrDefault(0)
            Me.InternetAdNumberColumn = InvoicePrintingMediaSetting.InternetAdNumberColumn.GetValueOrDefault(0)
            Me.InternetURLColumn = InvoicePrintingMediaSetting.InternetURLColumn.GetValueOrDefault(0)
            Me.InternetInternetTypeColumn = InvoicePrintingMediaSetting.InternetInternetTypeColumn.GetValueOrDefault(0)
            Me.InternetJobComponentNumberColumn = InvoicePrintingMediaSetting.InternetJobComponentNumberColumn.GetValueOrDefault(0)
            Me.InternetJobDescriptionColumn = InvoicePrintingMediaSetting.InternetJobDescriptionColumn.GetValueOrDefault(0)
            Me.InternetComponentDescriptionColumn = InvoicePrintingMediaSetting.InternetComponentDescriptionColumn.GetValueOrDefault(0)
            Me.InternetExtraChargesColumn = InvoicePrintingMediaSetting.InternetExtraChargesColumn.GetValueOrDefault(0)

            Me.InternetShowCommissionSeparately = InvoicePrintingMediaSetting.InternetShowCommissionSeparately.GetValueOrDefault(False)
            Me.InternetShowRebateSeparately = InvoicePrintingMediaSetting.InternetShowRebateSeparately.GetValueOrDefault(False)
            Me.InternetShowTaxSeparately = InvoicePrintingMediaSetting.InternetShowTaxSeparately.GetValueOrDefault(False)
            Me.InternetShowBillingHistory = InvoicePrintingMediaSetting.InternetShowBillingHistory.GetValueOrDefault(False)
            Me.InternetShowCampaign = InvoicePrintingMediaSetting.InternetShowCampaign
            Me.InternetShowCampaignComment = InvoicePrintingMediaSetting.InternetShowCampaignComment
            Me.InternetShowOrderSubtotals = InvoicePrintingMediaSetting.InternetShowOrderSubtotals

            Me.InternetShowSalesClass = InvoicePrintingMediaSetting.InternetShowSalesClass
            Me.InternetClientPOLocation = InvoicePrintingMediaSetting.InternetClientPOLocation
            Me.InternetSalesClassLocation = InvoicePrintingMediaSetting.InternetSalesClassLocation
            Me.InternetCampaignLocation = InvoicePrintingMediaSetting.InternetCampaignLocation
            Me.InternetHeaderGroupBy = InvoicePrintingMediaSetting.InternetHeaderGroupBy
            Me.InternetSortLinesBy = InvoicePrintingMediaSetting.InternetSortLinesBy
            Me.InternetLineNumberColumn = InvoicePrintingMediaSetting.InternetLineNumberColumn
            Me.InternetShowZeroLineAmounts = InvoicePrintingMediaSetting.InternetShowZeroLineAmounts
            Me.InternetCloseDateColumn = InvoicePrintingMediaSetting.InternetCloseDateColumn
			Me.InternetCustomInvoiceID = InvoicePrintingMediaSetting.InternetCustomInvoiceID

			_InvoicePrintingMediaSetting = InvoicePrintingMediaSetting

        End Sub
        Public Function GetEntity() As Object

            If _InvoicePrintingMediaSetting IsNot Nothing Then

                GetEntity = _InvoicePrintingMediaSetting

            ElseIf _MediaInvoiceDefault IsNot Nothing Then

                GetEntity = _MediaInvoiceDefault

            Else

                GetEntity = Nothing

            End If

        End Function
        Public Function SaveAndGetEntity() As Object

            Save()

            If _InvoicePrintingMediaSetting IsNot Nothing Then

                SaveAndGetEntity = _InvoicePrintingMediaSetting

            ElseIf _MediaInvoiceDefault IsNot Nothing Then

                SaveAndGetEntity = _MediaInvoiceDefault

            Else

                SaveAndGetEntity = Nothing

            End If

        End Function
        Public Sub Save()

            If _InvoicePrintingMediaSetting IsNot Nothing Then

                Save(_InvoicePrintingMediaSetting)

            ElseIf _MediaInvoiceDefault IsNot Nothing Then

                Save(_MediaInvoiceDefault)

            End If

        End Sub
        Public Sub Save(ByVal MediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault)

            MediaInvoiceDefault.InternetUseInvoiceCategoryDescription = Convert.ToInt16(Me.InternetUseInvoiceCategoryDescription)
            MediaInvoiceDefault.InternetInvoiceTitle = Me.InternetInvoiceTitle
            MediaInvoiceDefault.InternetGroupByMarket = Convert.ToInt16(Me.InternetGroupByMarket)
            MediaInvoiceDefault.InternetShowOrderDescription = Convert.ToInt16(Me.InternetShowOrderDescription)
            MediaInvoiceDefault.InternetShowClientReference = Convert.ToInt16(Me.InternetShowClientReference)
            MediaInvoiceDefault.InternetShowClientPO = Convert.ToInt16(Me.InternetShowClientPO)
            MediaInvoiceDefault.InternetShowOrderComment = Convert.ToInt16(Me.InternetShowOrderComment)
            MediaInvoiceDefault.InternetShowOrderHouseComment = Convert.ToInt16(Me.InternetShowOrderHouseComment)
            MediaInvoiceDefault.InternetPrintInvoiceDueDate = Convert.ToInt16(Me.InternetPrintInvoiceDueDate)
            MediaInvoiceDefault.InternetShowLineDetail = Convert.ToInt16(Me.InternetShowLineDetail)

            MediaInvoiceDefault.InternetOrderNumberColumn = Me.InternetOrderNumberColumn
            MediaInvoiceDefault.InternetVendorNameColumn = Me.InternetVendorNameColumn
            MediaInvoiceDefault.InternetShowVendorCode = Me.InternetShowVendorCode
            MediaInvoiceDefault.InternetOrderMonthsColumn = Me.InternetOrderMonthsColumn
            MediaInvoiceDefault.InternetNetAmountColumn = Me.InternetNetAmountColumn
            MediaInvoiceDefault.InternetCommissionAmountColumn = Me.InternetCommissionAmountColumn
            MediaInvoiceDefault.InternetTaxAmountColumn = Me.InternetTaxAmountColumn
            MediaInvoiceDefault.InternetBillAmountColumn = Me.InternetBillAmountColumn
            MediaInvoiceDefault.InternetPriorBillAmountColumn = Me.InternetPriorBillAmountColumn
            MediaInvoiceDefault.InternetBilledToDateAmountColumn = Me.InternetBilledToDateAmountColumn
            MediaInvoiceDefault.InternetHeadlineColumn = Me.InternetHeadlineColumn
            MediaInvoiceDefault.InternetStartDatesColumn = Me.InternetStartDatesColumn
            MediaInvoiceDefault.InternetEndDatesColumn = Me.InternetEndDatesColumn
            MediaInvoiceDefault.InternetCreativeSizeColumn = Me.InternetCreativeSizeColumn
            MediaInvoiceDefault.InternetAdNumberColumn = Me.InternetAdNumberColumn
            MediaInvoiceDefault.InternetURLColumn = Me.InternetURLColumn
            MediaInvoiceDefault.InternetInternetTypeColumn = Me.InternetInternetTypeColumn
            MediaInvoiceDefault.InternetJobComponentNumberColumn = Me.InternetJobComponentNumberColumn
            MediaInvoiceDefault.InternetJobDescriptionColumn = Me.InternetJobDescriptionColumn
            MediaInvoiceDefault.InternetComponentDescriptionColumn = Me.InternetComponentDescriptionColumn
            MediaInvoiceDefault.InternetExtraChargesColumn = Me.InternetExtraChargesColumn

            MediaInvoiceDefault.InternetShowCommissionSeparately = Convert.ToInt16(Me.InternetShowCommissionSeparately)
            MediaInvoiceDefault.InternetShowRebateSeparately = Convert.ToInt16(Me.InternetShowRebateSeparately)
            MediaInvoiceDefault.InternetShowTaxSeparately = Convert.ToInt16(Me.InternetShowTaxSeparately)
            MediaInvoiceDefault.InternetShowBillingHistory = Convert.ToInt16(Me.InternetShowBillingHistory)
            MediaInvoiceDefault.InternetShowCampaign = Me.InternetShowCampaign
            MediaInvoiceDefault.InternetShowCampaignComment = Me.InternetShowCampaignComment
            MediaInvoiceDefault.InternetShowOrderSubtotals = Me.InternetShowOrderSubtotals

            MediaInvoiceDefault.InternetShowSalesClass = Me.InternetShowSalesClass
            MediaInvoiceDefault.InternetClientPOLocation = Me.InternetClientPOLocation
            MediaInvoiceDefault.InternetSalesClassLocation = Me.InternetSalesClassLocation
            MediaInvoiceDefault.InternetCampaignLocation = Me.InternetCampaignLocation
            MediaInvoiceDefault.InternetHeaderGroupBy = Me.InternetHeaderGroupBy
            MediaInvoiceDefault.InternetSortLinesBy = Me.InternetSortLinesBy
            MediaInvoiceDefault.InternetLineNumberColumn = Me.InternetLineNumberColumn
            MediaInvoiceDefault.InternetShowZeroLineAmounts = Me.InternetShowZeroLineAmounts
            MediaInvoiceDefault.InternetCloseDateColumn = Me.InternetCloseDateColumn
			MediaInvoiceDefault.InternetCustomInvoiceID = Me.InternetCustomInvoiceID

		End Sub
        Public Sub Save(ByVal InvoicePrintingMediaSetting As InvoicePrintingMediaSetting)

            InvoicePrintingMediaSetting.InternetUseInvoiceCategoryDescription = Me.InternetUseInvoiceCategoryDescription
            InvoicePrintingMediaSetting.InternetInvoiceTitle = Me.InternetInvoiceTitle
            InvoicePrintingMediaSetting.InternetGroupByMarket = Me.InternetGroupByMarket
            InvoicePrintingMediaSetting.InternetShowOrderDescription = Me.InternetShowOrderDescription
            InvoicePrintingMediaSetting.InternetShowClientReference = Me.InternetShowClientReference
            InvoicePrintingMediaSetting.InternetShowClientPO = Me.InternetShowClientPO
            InvoicePrintingMediaSetting.InternetShowOrderComment = Me.InternetShowOrderComment
            InvoicePrintingMediaSetting.InternetShowOrderHouseComment = Me.InternetShowOrderHouseComment
            InvoicePrintingMediaSetting.InternetPrintInvoiceDueDate = Me.InternetPrintInvoiceDueDate
            InvoicePrintingMediaSetting.InternetShowLineDetail = Convert.ToBoolean(Me.InternetShowLineDetail)

            InvoicePrintingMediaSetting.InternetOrderNumberColumn = Me.InternetOrderNumberColumn
            InvoicePrintingMediaSetting.InternetVendorNameColumn = Me.InternetVendorNameColumn
            InvoicePrintingMediaSetting.InternetShowVendorCode = Me.InternetShowVendorCode
            InvoicePrintingMediaSetting.InternetOrderMonthsColumn = Me.InternetOrderMonthsColumn
            InvoicePrintingMediaSetting.InternetNetAmountColumn = Me.InternetNetAmountColumn
            InvoicePrintingMediaSetting.InternetCommissionAmountColumn = Me.InternetCommissionAmountColumn
            InvoicePrintingMediaSetting.InternetTaxAmountColumn = Me.InternetTaxAmountColumn
            InvoicePrintingMediaSetting.InternetBillAmountColumn = Me.InternetBillAmountColumn
            InvoicePrintingMediaSetting.InternetPriorBillAmountColumn = Me.InternetPriorBillAmountColumn
            InvoicePrintingMediaSetting.InternetBilledToDateAmountColumn = Me.InternetBilledToDateAmountColumn
            InvoicePrintingMediaSetting.InternetHeadlineColumn = Me.InternetHeadlineColumn
            InvoicePrintingMediaSetting.InternetStartDatesColumn = Me.InternetStartDatesColumn
            InvoicePrintingMediaSetting.InternetEndDatesColumn = Me.InternetEndDatesColumn
            InvoicePrintingMediaSetting.InternetCreativeSizeColumn = Me.InternetCreativeSizeColumn
            InvoicePrintingMediaSetting.InternetAdNumberColumn = Me.InternetAdNumberColumn
            InvoicePrintingMediaSetting.InternetURLColumn = Me.InternetURLColumn
            InvoicePrintingMediaSetting.InternetInternetTypeColumn = Me.InternetInternetTypeColumn
            InvoicePrintingMediaSetting.InternetJobComponentNumberColumn = Me.InternetJobComponentNumberColumn
            InvoicePrintingMediaSetting.InternetJobDescriptionColumn = Me.InternetJobDescriptionColumn
            InvoicePrintingMediaSetting.InternetComponentDescriptionColumn = Me.InternetComponentDescriptionColumn
            InvoicePrintingMediaSetting.InternetExtraChargesColumn = Me.InternetExtraChargesColumn

            InvoicePrintingMediaSetting.InternetShowCommissionSeparately = Me.InternetShowCommissionSeparately
            InvoicePrintingMediaSetting.InternetShowRebateSeparately = Me.InternetShowRebateSeparately
            InvoicePrintingMediaSetting.InternetShowTaxSeparately = Me.InternetShowTaxSeparately
            InvoicePrintingMediaSetting.InternetShowBillingHistory = Me.InternetShowBillingHistory
            InvoicePrintingMediaSetting.InternetShowCampaign = Me.InternetShowCampaign
            InvoicePrintingMediaSetting.InternetShowCampaignComment = Me.InternetShowCampaignComment
            InvoicePrintingMediaSetting.InternetShowOrderSubtotals = Me.InternetShowOrderSubtotals

            InvoicePrintingMediaSetting.InternetShowSalesClass = Me.InternetShowSalesClass
            InvoicePrintingMediaSetting.InternetClientPOLocation = Me.InternetClientPOLocation
            InvoicePrintingMediaSetting.InternetSalesClassLocation = Me.InternetSalesClassLocation
            InvoicePrintingMediaSetting.InternetCampaignLocation = Me.InternetCampaignLocation
            InvoicePrintingMediaSetting.InternetHeaderGroupBy = Me.InternetHeaderGroupBy
            InvoicePrintingMediaSetting.InternetSortLinesBy = Me.InternetSortLinesBy
            InvoicePrintingMediaSetting.InternetLineNumberColumn = Me.InternetLineNumberColumn
            InvoicePrintingMediaSetting.InternetShowZeroLineAmounts = Me.InternetShowZeroLineAmounts
            InvoicePrintingMediaSetting.InternetCloseDateColumn = Me.InternetCloseDateColumn
			InvoicePrintingMediaSetting.InternetCustomInvoiceID = Me.InternetCustomInvoiceID

		End Sub
        Public Overrides Function ToString() As String

            ToString = ""

        End Function

#End Region

    End Class

End Namespace
