Namespace InvoicePrinting.Classes

    <Serializable()>
    Public Class MediaInvoiceOutdoorSetting

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            OutdoorUseInvoiceCategoryDescription
            OutdoorInvoiceTitle
            OutdoorGroupByMarket
            OutdoorShowOrderDescription
            OutdoorShowClientReference
            OutdoorShowClientPO
            OutdoorShowOrderComment
            OutdoorShowOrderHouseComment
            OutdoorPrintInvoiceDueDate
            OutdoorShowLineDetail
            OutdoorOrderNumberColumn
            OutdoorVendorNameColumn
            OutdoorShowVendorCode
            OutdoorOrderMonthsColumn
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
            OutdoorCustomFormatName
            OutdoorShowCampaign
            OutdoorShowCampaignComment
            OutdoorShowOrderSubtotals
            OutdoorShowSalesClass
            OutdoorClientPOLocation
            OutdoorSalesClassLocation
            OutdoorCampaignLocation
            OutdoorHeaderGroupBy
            OutdoorSortLinesBy
            OutdoorLineNumberColumn
            OutdoorShowZeroLineAmounts
			OutdoorCloseDateColumn
			OutdoorCustomInvoiceID
		End Enum

#End Region

#Region " Variables "

		Private _OutdoorUseInvoiceCategoryDescription As Boolean = False
		Private _OutdoorInvoiceTitle As String = Nothing
		Private _OutdoorGroupByMarket As Boolean = False
		Private _OutdoorShowOrderDescription As Boolean = False
		Private _OutdoorShowClientReference As Boolean = False
		Private _OutdoorShowClientPO As Boolean = False
		Private _OutdoorShowOrderComment As Boolean = False
		Private _OutdoorShowOrderHouseComment As Boolean = False
		Private _OutdoorPrintInvoiceDueDate As Boolean = False
		Private _OutdoorShowLineDetail As Integer = 1
		Private _OutdoorOrderNumberColumn As Short = 1
		Private _OutdoorVendorNameColumn As Short = 0
		Private _OutdoorShowVendorCode As Short = 0
		Private _OutdoorOrderMonthsColumn As Short = 0
		Private _OutdoorHeadlineColumn As Short = 0
		Private _OutdoorInsertDatesColumn As Short = 0
		Private _OutdoorEndDateColumn As Short = 0
		Private _OutdoorCopyAreaColumn As Short = 0
		Private _OutdoorAdNumberColumn As Short = 0
		Private _OutdoorLocationColumn As Short = 0
		Private _OutdoorOutdoorTypeColumn As Short = 0
		Private _OutdoorSizeColumn As Short = 0
		Private _OutdoorJobComponentNumberColumn As Short = 0
		Private _OutdoorJobDescriptionColumn As Short = 0
		Private _OutdoorComponentDescriptionColumn As Short = 0
		Private _OutdoorExtraChargesColumn As Short = 0
		Private _OutdoorNetAmountColumn As Short = 0
		Private _OutdoorCommissionAmountColumn As Short = 0
		Private _OutdoorTaxAmountColumn As Short = 0
		Private _OutdoorBillAmountColumn As Short = 0
		Private _OutdoorPriorBillAmountColumn As Short = 0
		Private _OutdoorBilledToDateAmountColumn As Short = 0
		Private _OutdoorShowCommissionSeparately As Boolean = False
		Private _OutdoorShowRebateSeparately As Boolean = False
		Private _OutdoorShowTaxSeparately As Boolean = False
		Private _OutdoorShowBillingHistory As Boolean = False
		Private _OutdoorCustomFormatName As String = Nothing
		Private _OutdoorShowCampaign As Boolean = False
		Private _OutdoorShowCampaignComment As Boolean = False
		Private _OutdoorShowOrderSubtotals As Boolean = False
		Private _OutdoorShowSalesClass As Boolean = False
		Private _OutdoorClientPOLocation As Integer = 1
		Private _OutdoorSalesClassLocation As Integer = 1
		Private _OutdoorCampaignLocation As Integer = 1
		Private _OutdoorHeaderGroupBy As Integer = Nothing
		Private _OutdoorSortLinesBy As Integer = 1
		Private _OutdoorLineNumberColumn As Short = 0
		Private _OutdoorShowZeroLineAmounts As Boolean = False
		Private _OutdoorCloseDateColumn As Short = 0
		Private _OutdoorCustomInvoiceID As Nullable(Of Integer) = Nothing

		Private _MediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault = Nothing
		Private _InvoicePrintingMediaSetting As InvoicePrintingMediaSetting = Nothing

#End Region

#Region " Properties "

		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property OutdoorUseInvoiceCategoryDescription As Boolean
			Get
				OutdoorUseInvoiceCategoryDescription = _OutdoorUseInvoiceCategoryDescription
			End Get
			Set(ByVal value As Boolean)
				_OutdoorUseInvoiceCategoryDescription = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property OutdoorInvoiceTitle As String
			Get
				OutdoorInvoiceTitle = _OutdoorInvoiceTitle
			End Get
			Set(ByVal value As String)
				_OutdoorInvoiceTitle = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property OutdoorGroupByMarket As Boolean
			Get
				OutdoorGroupByMarket = _OutdoorGroupByMarket
			End Get
			Set(ByVal value As Boolean)
				_OutdoorGroupByMarket = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property OutdoorShowOrderDescription As Boolean
			Get
				OutdoorShowOrderDescription = _OutdoorShowOrderDescription
			End Get
			Set(ByVal value As Boolean)
				_OutdoorShowOrderDescription = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property OutdoorShowClientReference As Boolean
			Get
				OutdoorShowClientReference = _OutdoorShowClientReference
			End Get
			Set(ByVal value As Boolean)
				_OutdoorShowClientReference = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property OutdoorShowClientPO As Boolean
			Get
				OutdoorShowClientPO = _OutdoorShowClientPO
			End Get
			Set(ByVal value As Boolean)
				_OutdoorShowClientPO = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property OutdoorShowOrderComment As Boolean
			Get
				OutdoorShowOrderComment = _OutdoorShowOrderComment
			End Get
			Set(ByVal value As Boolean)
				_OutdoorShowOrderComment = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property OutdoorShowOrderHouseComment As Boolean
			Get
				OutdoorShowOrderHouseComment = _OutdoorShowOrderHouseComment
			End Get
			Set(ByVal value As Boolean)
				_OutdoorShowOrderHouseComment = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property OutdoorPrintInvoiceDueDate As Boolean
			Get
				OutdoorPrintInvoiceDueDate = _OutdoorPrintInvoiceDueDate
			End Get
			Set(ByVal value As Boolean)
				_OutdoorPrintInvoiceDueDate = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property OutdoorShowLineDetail As Integer
			Get
				OutdoorShowLineDetail = _OutdoorShowLineDetail
			End Get
			Set(ByVal value As Integer)
				_OutdoorShowLineDetail = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property OutdoorOrderNumberColumn As Short
			Get
				OutdoorOrderNumberColumn = _OutdoorOrderNumberColumn
			End Get
			Set(ByVal value As Short)
				_OutdoorOrderNumberColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property OutdoorVendorNameColumn As Short
			Get
				OutdoorVendorNameColumn = _OutdoorVendorNameColumn
			End Get
			Set(ByVal value As Short)
				_OutdoorVendorNameColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property OutdoorShowVendorCode As Short
			Get
				OutdoorShowVendorCode = _OutdoorShowVendorCode
			End Get
			Set(ByVal value As Short)
				_OutdoorShowVendorCode = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property OutdoorOrderMonthsColumn As Short
			Get
				OutdoorOrderMonthsColumn = _OutdoorOrderMonthsColumn
			End Get
			Set(ByVal value As Short)
				_OutdoorOrderMonthsColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property OutdoorHeadlineColumn As Short
			Get
				OutdoorHeadlineColumn = _OutdoorHeadlineColumn
			End Get
			Set(ByVal value As Short)
				_OutdoorHeadlineColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property OutdoorInsertDatesColumn As Short
			Get
				OutdoorInsertDatesColumn = _OutdoorInsertDatesColumn
			End Get
			Set(ByVal value As Short)
				_OutdoorInsertDatesColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property OutdoorEndDateColumn As Short
			Get
				OutdoorEndDateColumn = _OutdoorEndDateColumn
			End Get
			Set(ByVal value As Short)
				_OutdoorEndDateColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property OutdoorCopyAreaColumn As Short
			Get
				OutdoorCopyAreaColumn = _OutdoorCopyAreaColumn
			End Get
			Set(ByVal value As Short)
				_OutdoorCopyAreaColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property OutdoorAdNumberColumn As Short
			Get
				OutdoorAdNumberColumn = _OutdoorAdNumberColumn
			End Get
			Set(ByVal value As Short)
				_OutdoorAdNumberColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property OutdoorLocationColumn As Short
			Get
				OutdoorLocationColumn = _OutdoorLocationColumn
			End Get
			Set(ByVal value As Short)
				_OutdoorLocationColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property OutdoorOutdoorTypeColumn As Short
			Get
				OutdoorOutdoorTypeColumn = _OutdoorOutdoorTypeColumn
			End Get
			Set(ByVal value As Short)
				_OutdoorOutdoorTypeColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property OutdoorSizeColumn As Short
			Get
				OutdoorSizeColumn = _OutdoorSizeColumn
			End Get
			Set(ByVal value As Short)
				_OutdoorSizeColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property OutdoorJobComponentNumberColumn As Short
			Get
				OutdoorJobComponentNumberColumn = _OutdoorJobComponentNumberColumn
			End Get
			Set(ByVal value As Short)
				_OutdoorJobComponentNumberColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property OutdoorJobDescriptionColumn As Short
			Get
				OutdoorJobDescriptionColumn = _OutdoorJobDescriptionColumn
			End Get
			Set(ByVal value As Short)
				_OutdoorJobDescriptionColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property OutdoorComponentDescriptionColumn As Short
			Get
				OutdoorComponentDescriptionColumn = _OutdoorComponentDescriptionColumn
			End Get
			Set(ByVal value As Short)
				_OutdoorComponentDescriptionColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property OutdoorExtraChargesColumn As Short
			Get
				OutdoorExtraChargesColumn = _OutdoorExtraChargesColumn
			End Get
			Set(ByVal value As Short)
				_OutdoorExtraChargesColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property OutdoorNetAmountColumn As Short
			Get
				OutdoorNetAmountColumn = _OutdoorNetAmountColumn
			End Get
			Set(ByVal value As Short)
				_OutdoorNetAmountColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property OutdoorCommissionAmountColumn As Short
			Get
				OutdoorCommissionAmountColumn = _OutdoorCommissionAmountColumn
			End Get
			Set(ByVal value As Short)
				_OutdoorCommissionAmountColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property OutdoorTaxAmountColumn As Short
			Get
				OutdoorTaxAmountColumn = _OutdoorTaxAmountColumn
			End Get
			Set(ByVal value As Short)
				_OutdoorTaxAmountColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property OutdoorBillAmountColumn As Short
			Get
				OutdoorBillAmountColumn = _OutdoorBillAmountColumn
			End Get
			Set(ByVal value As Short)
				_OutdoorBillAmountColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property OutdoorPriorBillAmountColumn As Short
			Get
				OutdoorPriorBillAmountColumn = _OutdoorPriorBillAmountColumn
			End Get
			Set(ByVal value As Short)
				_OutdoorPriorBillAmountColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property OutdoorBilledToDateAmountColumn As Short
			Get
				OutdoorBilledToDateAmountColumn = _OutdoorBilledToDateAmountColumn
			End Get
			Set(ByVal value As Short)
				_OutdoorBilledToDateAmountColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property OutdoorShowCommissionSeparately As Boolean
			Get
				OutdoorShowCommissionSeparately = _OutdoorShowCommissionSeparately
			End Get
			Set(ByVal value As Boolean)
				_OutdoorShowCommissionSeparately = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property OutdoorShowRebateSeparately As Boolean
			Get
				OutdoorShowRebateSeparately = _OutdoorShowRebateSeparately
			End Get
			Set(ByVal value As Boolean)
				_OutdoorShowRebateSeparately = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property OutdoorShowTaxSeparately As Boolean
			Get
				OutdoorShowTaxSeparately = _OutdoorShowTaxSeparately
			End Get
			Set(ByVal value As Boolean)
				_OutdoorShowTaxSeparately = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property OutdoorShowBillingHistory As Boolean
			Get
				OutdoorShowBillingHistory = _OutdoorShowBillingHistory
			End Get
			Set(ByVal value As Boolean)
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
		Public Property OutdoorShowCampaign() As Boolean
			Get
				OutdoorShowCampaign = _OutdoorShowCampaign
			End Get
			Set(ByVal value As Boolean)
				_OutdoorShowCampaign = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property OutdoorShowCampaignComment() As Boolean
			Get
				OutdoorShowCampaignComment = _OutdoorShowCampaignComment
			End Get
			Set(ByVal value As Boolean)
				_OutdoorShowCampaignComment = value
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
		Public Property OutdoorShowSalesClass() As Boolean
			Get
				OutdoorShowSalesClass = _OutdoorShowSalesClass
			End Get
			Set(value As Boolean)
				_OutdoorShowSalesClass = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property OutdoorClientPOLocation() As Integer
			Get
				OutdoorClientPOLocation = _OutdoorClientPOLocation
			End Get
			Set(value As Integer)
				_OutdoorClientPOLocation = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property OutdoorSalesClassLocation() As Integer
			Get
				OutdoorSalesClassLocation = _OutdoorSalesClassLocation
			End Get
			Set(value As Integer)
				_OutdoorSalesClassLocation = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property OutdoorCampaignLocation() As Integer
			Get
				OutdoorCampaignLocation = _OutdoorCampaignLocation
			End Get
			Set(value As Integer)
				_OutdoorCampaignLocation = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property OutdoorHeaderGroupBy() As Integer
			Get
				OutdoorHeaderGroupBy = _OutdoorHeaderGroupBy
			End Get
			Set(value As Integer)
				_OutdoorHeaderGroupBy = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property OutdoorSortLinesBy() As Integer
			Get
				OutdoorSortLinesBy = _OutdoorSortLinesBy
			End Get
			Set(value As Integer)
				_OutdoorSortLinesBy = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property OutdoorLineNumberColumn() As Short
			Get
				OutdoorLineNumberColumn = _OutdoorLineNumberColumn
			End Get
			Set(value As Short)
				_OutdoorLineNumberColumn = value
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
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property OutdoorCloseDateColumn() As Short
			Get
				OutdoorCloseDateColumn = _OutdoorCloseDateColumn
			End Get
			Set(value As Short)
				_OutdoorCloseDateColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.DisplayName("Custom Invoice")>
		Public Property OutdoorCustomInvoiceID() As Nullable(Of Integer)
			Get
				OutdoorCustomInvoiceID = _OutdoorCustomInvoiceID
			End Get
			Set(ByVal value As Nullable(Of Integer))
				_OutdoorCustomInvoiceID = value
			End Set
		End Property

#End Region

#Region " Methods "

		Public Sub New()



		End Sub
		Public Sub New(ByVal MediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault)

			Me.OutdoorUseInvoiceCategoryDescription = Convert.ToBoolean(MediaInvoiceDefault.OutdoorUseInvoiceCategoryDescription.GetValueOrDefault(0))
			Me.OutdoorInvoiceTitle = MediaInvoiceDefault.OutdoorInvoiceTitle
			Me.OutdoorGroupByMarket = Convert.ToBoolean(MediaInvoiceDefault.OutdoorGroupByMarket.GetValueOrDefault(0))
			Me.OutdoorShowOrderDescription = Convert.ToBoolean(MediaInvoiceDefault.OutdoorShowOrderDescription.GetValueOrDefault(0))
			Me.OutdoorShowClientReference = Convert.ToBoolean(MediaInvoiceDefault.OutdoorShowClientReference.GetValueOrDefault(0))
			Me.OutdoorShowClientPO = Convert.ToBoolean(MediaInvoiceDefault.OutdoorShowClientPO.GetValueOrDefault(0))
			Me.OutdoorShowOrderComment = Convert.ToBoolean(MediaInvoiceDefault.OutdoorShowOrderComment.GetValueOrDefault(0))
			Me.OutdoorShowOrderHouseComment = Convert.ToBoolean(MediaInvoiceDefault.OutdoorShowOrderHouseComment.GetValueOrDefault(0))
			Me.OutdoorPrintInvoiceDueDate = Convert.ToBoolean(MediaInvoiceDefault.OutdoorPrintInvoiceDueDate.GetValueOrDefault(0))
			Me.OutdoorShowLineDetail = Convert.ToInt32(MediaInvoiceDefault.OutdoorShowLineDetail.GetValueOrDefault(0))

			Me.OutdoorOrderNumberColumn = MediaInvoiceDefault.OutdoorOrderNumberColumn.GetValueOrDefault(1)
			Me.OutdoorVendorNameColumn = MediaInvoiceDefault.OutdoorVendorNameColumn.GetValueOrDefault(2)
			Me.OutdoorShowVendorCode = MediaInvoiceDefault.OutdoorShowVendorCode.GetValueOrDefault(0)
			Me.OutdoorOrderMonthsColumn = MediaInvoiceDefault.OutdoorOrderMonthsColumn.GetValueOrDefault(0)
			Me.OutdoorNetAmountColumn = MediaInvoiceDefault.OutdoorNetAmountColumn.GetValueOrDefault(0)
			Me.OutdoorCommissionAmountColumn = MediaInvoiceDefault.OutdoorCommissionAmountColumn.GetValueOrDefault(0)
			Me.OutdoorTaxAmountColumn = MediaInvoiceDefault.OutdoorTaxAmountColumn.GetValueOrDefault(0)
			Me.OutdoorBillAmountColumn = MediaInvoiceDefault.OutdoorBillAmountColumn.GetValueOrDefault(0)
			Me.OutdoorPriorBillAmountColumn = MediaInvoiceDefault.OutdoorPriorBillAmountColumn.GetValueOrDefault(0)
			Me.OutdoorBilledToDateAmountColumn = MediaInvoiceDefault.OutdoorBilledToDateAmountColumn.GetValueOrDefault(0)
			Me.OutdoorHeadlineColumn = MediaInvoiceDefault.OutdoorHeadlineColumn.GetValueOrDefault(0)
			Me.OutdoorInsertDatesColumn = MediaInvoiceDefault.OutdoorInsertDatesColumn.GetValueOrDefault(0)
			Me.OutdoorEndDateColumn = MediaInvoiceDefault.OutdoorEndDateColumn
			Me.OutdoorCopyAreaColumn = MediaInvoiceDefault.OutdoorCopyAreaColumn.GetValueOrDefault(0)
			Me.OutdoorAdNumberColumn = MediaInvoiceDefault.OutdoorAdNumberColumn.GetValueOrDefault(0)
			Me.OutdoorLocationColumn = MediaInvoiceDefault.OutdoorLocationColumn.GetValueOrDefault(0)
			Me.OutdoorOutdoorTypeColumn = MediaInvoiceDefault.OutdoorOutdoorTypeColumn.GetValueOrDefault(0)
			Me.OutdoorSizeColumn = MediaInvoiceDefault.OutdoorSizeColumn.GetValueOrDefault(0)
			Me.OutdoorJobComponentNumberColumn = MediaInvoiceDefault.OutdoorJobComponentNumberColumn.GetValueOrDefault(0)
			Me.OutdoorJobDescriptionColumn = MediaInvoiceDefault.OutdoorJobDescriptionColumn.GetValueOrDefault(0)
			Me.OutdoorComponentDescriptionColumn = MediaInvoiceDefault.OutdoorComponentDescriptionColumn.GetValueOrDefault(0)
			Me.OutdoorExtraChargesColumn = MediaInvoiceDefault.OutdoorExtraChargesColumn.GetValueOrDefault(0)

			Me.OutdoorShowCommissionSeparately = Convert.ToBoolean(MediaInvoiceDefault.OutdoorShowCommissionSeparately.GetValueOrDefault(0))
			Me.OutdoorShowRebateSeparately = Convert.ToBoolean(MediaInvoiceDefault.OutdoorShowRebateSeparately.GetValueOrDefault(0))
			Me.OutdoorShowTaxSeparately = Convert.ToBoolean(MediaInvoiceDefault.OutdoorShowTaxSeparately.GetValueOrDefault(0))
			Me.OutdoorShowBillingHistory = Convert.ToBoolean(MediaInvoiceDefault.OutdoorShowBillingHistory.GetValueOrDefault(0))
			Me.OutdoorShowCampaign = MediaInvoiceDefault.OutdoorShowCampaign
			Me.OutdoorShowCampaignComment = MediaInvoiceDefault.OutdoorShowCampaignComment
			Me.OutdoorShowOrderSubtotals = MediaInvoiceDefault.OutdoorShowOrderSubtotals

			Me.OutdoorShowSalesClass = MediaInvoiceDefault.OutdoorShowSalesClass
			Me.OutdoorClientPOLocation = MediaInvoiceDefault.OutdoorClientPOLocation
			Me.OutdoorSalesClassLocation = MediaInvoiceDefault.OutdoorSalesClassLocation
			Me.OutdoorCampaignLocation = MediaInvoiceDefault.OutdoorCampaignLocation
			Me.OutdoorHeaderGroupBy = MediaInvoiceDefault.OutdoorHeaderGroupBy
			Me.OutdoorSortLinesBy = MediaInvoiceDefault.OutdoorSortLinesBy
			Me.OutdoorLineNumberColumn = MediaInvoiceDefault.OutdoorLineNumberColumn
			Me.OutdoorShowZeroLineAmounts = MediaInvoiceDefault.OutdoorShowZeroLineAmounts
			Me.OutdoorCloseDateColumn = MediaInvoiceDefault.OutdoorCloseDateColumn
			Me.OutdoorCustomInvoiceID = MediaInvoiceDefault.OutdoorCustomInvoiceID

			_MediaInvoiceDefault = MediaInvoiceDefault

		End Sub
		Public Sub New(ByVal InvoicePrintingMediaSetting As InvoicePrintingMediaSetting)

			Me.OutdoorUseInvoiceCategoryDescription = InvoicePrintingMediaSetting.OutdoorUseInvoiceCategoryDescription.GetValueOrDefault(False)
			Me.OutdoorInvoiceTitle = InvoicePrintingMediaSetting.OutdoorInvoiceTitle
			Me.OutdoorGroupByMarket = InvoicePrintingMediaSetting.OutdoorGroupByMarket.GetValueOrDefault(False)
			Me.OutdoorShowOrderDescription = InvoicePrintingMediaSetting.OutdoorShowOrderDescription.GetValueOrDefault(False)
			Me.OutdoorShowClientReference = InvoicePrintingMediaSetting.OutdoorShowClientReference.GetValueOrDefault(False)
			Me.OutdoorShowClientPO = InvoicePrintingMediaSetting.OutdoorShowClientPO.GetValueOrDefault(False)
			Me.OutdoorShowOrderComment = InvoicePrintingMediaSetting.OutdoorShowOrderComment.GetValueOrDefault(False)
			Me.OutdoorShowOrderHouseComment = InvoicePrintingMediaSetting.OutdoorShowOrderHouseComment.GetValueOrDefault(False)
			Me.OutdoorPrintInvoiceDueDate = InvoicePrintingMediaSetting.OutdoorPrintInvoiceDueDate.GetValueOrDefault(False)
			Me.OutdoorShowLineDetail = If(InvoicePrintingMediaSetting.OutdoorShowLineDetail.GetValueOrDefault(False) = True, 1, 0)

			Me.OutdoorOrderNumberColumn = InvoicePrintingMediaSetting.OutdoorOrderNumberColumn.GetValueOrDefault(1)
			Me.OutdoorVendorNameColumn = InvoicePrintingMediaSetting.OutdoorVendorNameColumn.GetValueOrDefault(2)
			Me.OutdoorShowVendorCode = InvoicePrintingMediaSetting.OutdoorShowVendorCode.GetValueOrDefault(0)
			Me.OutdoorOrderMonthsColumn = InvoicePrintingMediaSetting.OutdoorOrderMonthsColumn.GetValueOrDefault(0)
			Me.OutdoorNetAmountColumn = InvoicePrintingMediaSetting.OutdoorNetAmountColumn.GetValueOrDefault(0)
			Me.OutdoorCommissionAmountColumn = InvoicePrintingMediaSetting.OutdoorCommissionAmountColumn.GetValueOrDefault(0)
			Me.OutdoorTaxAmountColumn = InvoicePrintingMediaSetting.OutdoorTaxAmountColumn.GetValueOrDefault(0)
			Me.OutdoorBillAmountColumn = InvoicePrintingMediaSetting.OutdoorBillAmountColumn.GetValueOrDefault(0)
			Me.OutdoorPriorBillAmountColumn = InvoicePrintingMediaSetting.OutdoorPriorBillAmountColumn.GetValueOrDefault(0)
			Me.OutdoorBilledToDateAmountColumn = InvoicePrintingMediaSetting.OutdoorBilledToDateAmountColumn.GetValueOrDefault(0)
			Me.OutdoorHeadlineColumn = InvoicePrintingMediaSetting.OutdoorHeadlineColumn.GetValueOrDefault(0)
			Me.OutdoorInsertDatesColumn = InvoicePrintingMediaSetting.OutdoorInsertDatesColumn.GetValueOrDefault(0)
			Me.OutdoorEndDateColumn = InvoicePrintingMediaSetting.OutdoorEndDateColumn.GetValueOrDefault(0)
			Me.OutdoorCopyAreaColumn = InvoicePrintingMediaSetting.OutdoorCopyAreaColumn.GetValueOrDefault(0)
			Me.OutdoorAdNumberColumn = InvoicePrintingMediaSetting.OutdoorAdNumberColumn.GetValueOrDefault(0)
			Me.OutdoorLocationColumn = InvoicePrintingMediaSetting.OutdoorLocationColumn.GetValueOrDefault(0)
			Me.OutdoorOutdoorTypeColumn = InvoicePrintingMediaSetting.OutdoorOutdoorTypeColumn.GetValueOrDefault(0)
			Me.OutdoorSizeColumn = InvoicePrintingMediaSetting.OutdoorSizeColumn.GetValueOrDefault(0)
			Me.OutdoorJobComponentNumberColumn = InvoicePrintingMediaSetting.OutdoorJobComponentNumberColumn.GetValueOrDefault(0)
			Me.OutdoorJobDescriptionColumn = InvoicePrintingMediaSetting.OutdoorJobDescriptionColumn.GetValueOrDefault(0)
			Me.OutdoorComponentDescriptionColumn = InvoicePrintingMediaSetting.OutdoorComponentDescriptionColumn.GetValueOrDefault(0)
			Me.OutdoorExtraChargesColumn = InvoicePrintingMediaSetting.OutdoorExtraChargesColumn.GetValueOrDefault(0)

			Me.OutdoorShowCommissionSeparately = InvoicePrintingMediaSetting.OutdoorShowCommissionSeparately.GetValueOrDefault(False)
			Me.OutdoorShowRebateSeparately = InvoicePrintingMediaSetting.OutdoorShowRebateSeparately.GetValueOrDefault(False)
			Me.OutdoorShowTaxSeparately = InvoicePrintingMediaSetting.OutdoorShowTaxSeparately.GetValueOrDefault(False)
			Me.OutdoorShowBillingHistory = InvoicePrintingMediaSetting.OutdoorShowBillingHistory.GetValueOrDefault(False)
			Me.OutdoorShowCampaign = InvoicePrintingMediaSetting.OutdoorShowCampaign
			Me.OutdoorShowCampaignComment = InvoicePrintingMediaSetting.OutdoorShowCampaignComment
			Me.OutdoorShowOrderSubtotals = InvoicePrintingMediaSetting.OutdoorShowOrderSubtotals

			Me.OutdoorShowSalesClass = InvoicePrintingMediaSetting.OutdoorShowSalesClass
			Me.OutdoorClientPOLocation = InvoicePrintingMediaSetting.OutdoorClientPOLocation
			Me.OutdoorSalesClassLocation = InvoicePrintingMediaSetting.OutdoorSalesClassLocation
			Me.OutdoorCampaignLocation = InvoicePrintingMediaSetting.OutdoorCampaignLocation
			Me.OutdoorHeaderGroupBy = InvoicePrintingMediaSetting.OutdoorHeaderGroupBy
			Me.OutdoorSortLinesBy = InvoicePrintingMediaSetting.OutdoorSortLinesBy
			Me.OutdoorLineNumberColumn = InvoicePrintingMediaSetting.OutdoorLineNumberColumn
			Me.OutdoorShowZeroLineAmounts = InvoicePrintingMediaSetting.OutdoorShowZeroLineAmounts
			Me.OutdoorCloseDateColumn = InvoicePrintingMediaSetting.OutdoorCloseDateColumn
			Me.OutdoorCustomInvoiceID = InvoicePrintingMediaSetting.OutdoorCustomInvoiceID

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
		Public Sub Save(ByVal InvoicePrintingMediaSetting As InvoicePrintingMediaSetting)

			InvoicePrintingMediaSetting.OutdoorUseInvoiceCategoryDescription = Me.OutdoorUseInvoiceCategoryDescription
			InvoicePrintingMediaSetting.OutdoorInvoiceTitle = Me.OutdoorInvoiceTitle
			InvoicePrintingMediaSetting.OutdoorGroupByMarket = Me.OutdoorGroupByMarket
			InvoicePrintingMediaSetting.OutdoorShowOrderDescription = Me.OutdoorShowOrderDescription
			InvoicePrintingMediaSetting.OutdoorShowClientReference = Me.OutdoorShowClientReference
			InvoicePrintingMediaSetting.OutdoorShowClientPO = Me.OutdoorShowClientPO
			InvoicePrintingMediaSetting.OutdoorShowOrderComment = Me.OutdoorShowOrderComment
			InvoicePrintingMediaSetting.OutdoorShowOrderHouseComment = Me.OutdoorShowOrderHouseComment
			InvoicePrintingMediaSetting.OutdoorPrintInvoiceDueDate = Me.OutdoorPrintInvoiceDueDate
			InvoicePrintingMediaSetting.OutdoorShowLineDetail = Convert.ToBoolean(Me.OutdoorShowLineDetail)

			InvoicePrintingMediaSetting.OutdoorOrderNumberColumn = Me.OutdoorOrderNumberColumn
			InvoicePrintingMediaSetting.OutdoorVendorNameColumn = Me.OutdoorVendorNameColumn
			InvoicePrintingMediaSetting.OutdoorShowVendorCode = Me.OutdoorShowVendorCode
			InvoicePrintingMediaSetting.OutdoorOrderMonthsColumn = Me.OutdoorOrderMonthsColumn
			InvoicePrintingMediaSetting.OutdoorNetAmountColumn = Me.OutdoorNetAmountColumn
			InvoicePrintingMediaSetting.OutdoorCommissionAmountColumn = Me.OutdoorCommissionAmountColumn
			InvoicePrintingMediaSetting.OutdoorTaxAmountColumn = Me.OutdoorTaxAmountColumn
			InvoicePrintingMediaSetting.OutdoorBillAmountColumn = Me.OutdoorBillAmountColumn
			InvoicePrintingMediaSetting.OutdoorPriorBillAmountColumn = Me.OutdoorPriorBillAmountColumn
			InvoicePrintingMediaSetting.OutdoorBilledToDateAmountColumn = Me.OutdoorBilledToDateAmountColumn
			InvoicePrintingMediaSetting.OutdoorHeadlineColumn = Me.OutdoorHeadlineColumn
			InvoicePrintingMediaSetting.OutdoorInsertDatesColumn = Me.OutdoorInsertDatesColumn
			InvoicePrintingMediaSetting.OutdoorEndDateColumn = Me.OutdoorEndDateColumn
			InvoicePrintingMediaSetting.OutdoorCopyAreaColumn = Me.OutdoorCopyAreaColumn
			InvoicePrintingMediaSetting.OutdoorAdNumberColumn = Me.OutdoorAdNumberColumn
			InvoicePrintingMediaSetting.OutdoorLocationColumn = Me.OutdoorLocationColumn
			InvoicePrintingMediaSetting.OutdoorOutdoorTypeColumn = Me.OutdoorOutdoorTypeColumn
			InvoicePrintingMediaSetting.OutdoorSizeColumn = Me.OutdoorSizeColumn
			InvoicePrintingMediaSetting.OutdoorJobComponentNumberColumn = Me.OutdoorJobComponentNumberColumn
			InvoicePrintingMediaSetting.OutdoorJobDescriptionColumn = Me.OutdoorJobDescriptionColumn
			InvoicePrintingMediaSetting.OutdoorComponentDescriptionColumn = Me.OutdoorComponentDescriptionColumn
			InvoicePrintingMediaSetting.OutdoorExtraChargesColumn = Me.OutdoorExtraChargesColumn

			InvoicePrintingMediaSetting.OutdoorShowCommissionSeparately = Me.OutdoorShowCommissionSeparately
			InvoicePrintingMediaSetting.OutdoorShowRebateSeparately = Me.OutdoorShowRebateSeparately
			InvoicePrintingMediaSetting.OutdoorShowTaxSeparately = Me.OutdoorShowTaxSeparately
			InvoicePrintingMediaSetting.OutdoorShowBillingHistory = Me.OutdoorShowBillingHistory
			InvoicePrintingMediaSetting.OutdoorShowCampaign = Me.OutdoorShowCampaign
			InvoicePrintingMediaSetting.OutdoorShowCampaignComment = Me.OutdoorShowCampaignComment
			InvoicePrintingMediaSetting.OutdoorShowOrderSubtotals = Me.OutdoorShowOrderSubtotals

			InvoicePrintingMediaSetting.OutdoorShowSalesClass = Me.OutdoorShowSalesClass
			InvoicePrintingMediaSetting.OutdoorClientPOLocation = Me.OutdoorClientPOLocation
			InvoicePrintingMediaSetting.OutdoorSalesClassLocation = Me.OutdoorSalesClassLocation
			InvoicePrintingMediaSetting.OutdoorCampaignLocation = Me.OutdoorCampaignLocation
			InvoicePrintingMediaSetting.OutdoorHeaderGroupBy = Me.OutdoorHeaderGroupBy
			InvoicePrintingMediaSetting.OutdoorSortLinesBy = Me.OutdoorSortLinesBy
			InvoicePrintingMediaSetting.OutdoorLineNumberColumn = Me.OutdoorLineNumberColumn
			InvoicePrintingMediaSetting.OutdoorShowZeroLineAmounts = Me.OutdoorShowZeroLineAmounts
			InvoicePrintingMediaSetting.OutdoorCloseDateColumn = Me.OutdoorCloseDateColumn
			InvoicePrintingMediaSetting.OutdoorCustomInvoiceID = Me.OutdoorCustomInvoiceID

		End Sub
		Public Sub Save(ByVal MediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault)

			MediaInvoiceDefault.OutdoorUseInvoiceCategoryDescription = Convert.ToInt16(Me.OutdoorUseInvoiceCategoryDescription)
			MediaInvoiceDefault.OutdoorInvoiceTitle = Me.OutdoorInvoiceTitle
			MediaInvoiceDefault.OutdoorGroupByMarket = Convert.ToInt16(Me.OutdoorGroupByMarket)
			MediaInvoiceDefault.OutdoorShowOrderDescription = Convert.ToInt16(Me.OutdoorShowOrderDescription)
			MediaInvoiceDefault.OutdoorShowClientReference = Convert.ToInt16(Me.OutdoorShowClientReference)
			MediaInvoiceDefault.OutdoorShowClientPO = Convert.ToInt16(Me.OutdoorShowClientPO)
			MediaInvoiceDefault.OutdoorShowOrderComment = Convert.ToInt16(Me.OutdoorShowOrderComment)
			MediaInvoiceDefault.OutdoorShowOrderHouseComment = Convert.ToInt16(Me.OutdoorShowOrderHouseComment)
			MediaInvoiceDefault.OutdoorPrintInvoiceDueDate = Convert.ToInt16(Me.OutdoorPrintInvoiceDueDate)
			MediaInvoiceDefault.OutdoorShowLineDetail = Convert.ToInt16(Me.OutdoorShowLineDetail)

			MediaInvoiceDefault.OutdoorOrderNumberColumn = Me.OutdoorOrderNumberColumn
			MediaInvoiceDefault.OutdoorVendorNameColumn = Me.OutdoorVendorNameColumn
			MediaInvoiceDefault.OutdoorShowVendorCode = Me.OutdoorShowVendorCode
			MediaInvoiceDefault.OutdoorOrderMonthsColumn = Me.OutdoorOrderMonthsColumn
			MediaInvoiceDefault.OutdoorNetAmountColumn = Me.OutdoorNetAmountColumn
			MediaInvoiceDefault.OutdoorCommissionAmountColumn = Me.OutdoorCommissionAmountColumn
			MediaInvoiceDefault.OutdoorTaxAmountColumn = Me.OutdoorTaxAmountColumn
			MediaInvoiceDefault.OutdoorBillAmountColumn = Me.OutdoorBillAmountColumn
			MediaInvoiceDefault.OutdoorPriorBillAmountColumn = Me.OutdoorPriorBillAmountColumn
			MediaInvoiceDefault.OutdoorBilledToDateAmountColumn = Me.OutdoorBilledToDateAmountColumn
			MediaInvoiceDefault.OutdoorHeadlineColumn = Me.OutdoorHeadlineColumn
			MediaInvoiceDefault.OutdoorInsertDatesColumn = Me.OutdoorInsertDatesColumn
			MediaInvoiceDefault.OutdoorEndDateColumn = Me.OutdoorEndDateColumn
			MediaInvoiceDefault.OutdoorCopyAreaColumn = Me.OutdoorCopyAreaColumn
			MediaInvoiceDefault.OutdoorAdNumberColumn = Me.OutdoorAdNumberColumn
			MediaInvoiceDefault.OutdoorLocationColumn = Me.OutdoorLocationColumn
			MediaInvoiceDefault.OutdoorOutdoorTypeColumn = Me.OutdoorOutdoorTypeColumn
			MediaInvoiceDefault.OutdoorSizeColumn = Me.OutdoorSizeColumn
			MediaInvoiceDefault.OutdoorJobComponentNumberColumn = Me.OutdoorJobComponentNumberColumn
			MediaInvoiceDefault.OutdoorJobDescriptionColumn = Me.OutdoorJobDescriptionColumn
			MediaInvoiceDefault.OutdoorComponentDescriptionColumn = Me.OutdoorComponentDescriptionColumn
			MediaInvoiceDefault.OutdoorExtraChargesColumn = Me.OutdoorExtraChargesColumn

			MediaInvoiceDefault.OutdoorShowCommissionSeparately = Convert.ToInt16(Me.OutdoorShowCommissionSeparately)
			MediaInvoiceDefault.OutdoorShowRebateSeparately = Convert.ToInt16(Me.OutdoorShowRebateSeparately)
			MediaInvoiceDefault.OutdoorShowTaxSeparately = Convert.ToInt16(Me.OutdoorShowTaxSeparately)
			MediaInvoiceDefault.OutdoorShowBillingHistory = Convert.ToInt16(Me.OutdoorShowBillingHistory)
			MediaInvoiceDefault.OutdoorShowCampaign = Me.OutdoorShowCampaign
			MediaInvoiceDefault.OutdoorShowCampaignComment = Me.OutdoorShowCampaignComment
			MediaInvoiceDefault.OutdoorShowOrderSubtotals = Me.OutdoorShowOrderSubtotals

			MediaInvoiceDefault.OutdoorShowSalesClass = Me.OutdoorShowSalesClass
			MediaInvoiceDefault.OutdoorClientPOLocation = Me.OutdoorClientPOLocation
			MediaInvoiceDefault.OutdoorSalesClassLocation = Me.OutdoorSalesClassLocation
			MediaInvoiceDefault.OutdoorCampaignLocation = Me.OutdoorCampaignLocation
			MediaInvoiceDefault.OutdoorHeaderGroupBy = Me.OutdoorHeaderGroupBy
			MediaInvoiceDefault.OutdoorSortLinesBy = Me.OutdoorSortLinesBy
			MediaInvoiceDefault.OutdoorLineNumberColumn = Me.OutdoorLineNumberColumn
			MediaInvoiceDefault.OutdoorShowZeroLineAmounts = Me.OutdoorShowZeroLineAmounts
			MediaInvoiceDefault.OutdoorCloseDateColumn = Me.OutdoorCloseDateColumn
			MediaInvoiceDefault.OutdoorCustomInvoiceID = Me.OutdoorCustomInvoiceID

		End Sub
        Public Overrides Function ToString() As String

            ToString = ""

        End Function

#End Region

    End Class

End Namespace
