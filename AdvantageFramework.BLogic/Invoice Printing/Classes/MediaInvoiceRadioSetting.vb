Namespace InvoicePrinting.Classes

    <Serializable()>
    Public Class MediaInvoiceRadioSetting

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            RadioUseInvoiceCategoryDescription
            RadioInvoiceTitle
            RadioGroupByMarket
            RadioShowOrderDescription
            RadioShowClientReference
            RadioShowClientPO
            RadioShowOrderComment
            RadioShowOrderHouseComment
            RadioPrintInvoiceDueDate
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
            RadioCustomFormatName
            RadioShowCampaign
            RadioShowCampaignComment
            RadioShowOrderSubtotals
            RadioShowSalesClass
            RadioClientPOLocation
            RadioSalesClassLocation
            RadioCampaignLocation
            RadioHeaderGroupBy
            RadioSortLinesBy
            RadioLineNumberColumn
            RadioShowZeroLineAmounts
			RadioCloseDateColumn
            RadioCustomInvoiceID
            RadioStartDateColumn
        End Enum

#End Region

#Region " Variables "

		Private _RadioUseInvoiceCategoryDescription As Boolean = False
		Private _RadioInvoiceTitle As String = Nothing
		Private _RadioGroupByMarket As Boolean = False
		Private _RadioShowOrderDescription As Boolean = False
		Private _RadioShowClientReference As Boolean = False
		Private _RadioShowClientPO As Boolean = False
		Private _RadioShowOrderComment As Boolean = False
		Private _RadioShowOrderHouseComment As Boolean = False
		Private _RadioPrintInvoiceDueDate As Boolean = False
		Private _RadioShowLineDetail As Integer = 1
		Private _RadioOrderNumberColumn As Short = 1
		Private _RadioVendorNameColumn As Short = 0
		Private _RadioShowVendorCode As Short = 0
		Private _RadioOrderMonthsColumn As Short = 0
		Private _RadioProgramColumn As Short = 0
		Private _RadioSpotLengthColumn As Short = 0
		Private _RadioTagColumn As Short = 0
		Private _RadioStartEndTimesColumn As Short = 0
		Private _RadioNumberOfSpotsColumn As Short = 0
		Private _RadioRemarksColumn As Short = 0
		Private _RadioJobComponentNumberColumn As Short = 0
		Private _RadioJobDescriptionColumn As Short = 0
		Private _RadioComponentDescriptionColumn As Short = 0
		Private _RadioOrderDetailCommentColumn As Short = 0
		Private _RadioOrderHouseDetailCommentColumn As Short = 0
		Private _RadioExtraChargesColumn As Short = 0
		Private _RadioNetAmountColumn As Short = 0
		Private _RadioCommissionAmountColumn As Short = 0
		Private _RadioTaxAmountColumn As Short = 0
		Private _RadioBillAmountColumn As Short = 0
		Private _RadioPriorBillAmountColumn As Short = 0
		Private _RadioBilledToDateAmountColumn As Short = 0
		Private _RadioShowCommissionSeparately As Boolean = False
		Private _RadioShowRebateSeparately As Boolean = False
		Private _RadioShowTaxSeparately As Boolean = False
		Private _RadioShowBillingHistory As Boolean = False
		Private _RadioCustomFormatName As String = Nothing
		Private _RadioShowCampaign As Boolean = False
		Private _RadioShowCampaignComment As Boolean = False
		Private _RadioShowOrderSubtotals As Boolean = False
		Private _RadioShowSalesClass As Boolean = False
		Private _RadioClientPOLocation As Integer = 1
		Private _RadioSalesClassLocation As Integer = 1
		Private _RadioCampaignLocation As Integer = 1
		Private _RadioHeaderGroupBy As Integer = Nothing
		Private _RadioSortLinesBy As Integer = 1
		Private _RadioLineNumberColumn As Short = 0
		Private _RadioShowZeroLineAmounts As Boolean = False
		Private _RadioCloseDateColumn As Short = 0
		Private _RadioCustomInvoiceID As Nullable(Of Integer) = Nothing

		Private _MediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault = Nothing
		Private _InvoicePrintingMediaSetting As InvoicePrintingMediaSetting = Nothing

#End Region

#Region " Properties "

		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property RadioUseInvoiceCategoryDescription As Boolean
			Get
				RadioUseInvoiceCategoryDescription = _RadioUseInvoiceCategoryDescription
			End Get
			Set(ByVal value As Boolean)
				_RadioUseInvoiceCategoryDescription = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property RadioInvoiceTitle As String
			Get
				RadioInvoiceTitle = _RadioInvoiceTitle
			End Get
			Set(ByVal value As String)
				_RadioInvoiceTitle = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property RadioGroupByMarket As Boolean
			Get
				RadioGroupByMarket = _RadioGroupByMarket
			End Get
			Set(ByVal value As Boolean)
				_RadioGroupByMarket = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property RadioShowOrderDescription As Boolean
			Get
				RadioShowOrderDescription = _RadioShowOrderDescription
			End Get
			Set(ByVal value As Boolean)
				_RadioShowOrderDescription = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property RadioShowClientReference As Boolean
			Get
				RadioShowClientReference = _RadioShowClientReference
			End Get
			Set(ByVal value As Boolean)
				_RadioShowClientReference = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property RadioShowClientPO As Boolean
			Get
				RadioShowClientPO = _RadioShowClientPO
			End Get
			Set(ByVal value As Boolean)
				_RadioShowClientPO = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property RadioShowOrderComment As Boolean
			Get
				RadioShowOrderComment = _RadioShowOrderComment
			End Get
			Set(ByVal value As Boolean)
				_RadioShowOrderComment = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property RadioShowOrderHouseComment As Boolean
			Get
				RadioShowOrderHouseComment = _RadioShowOrderHouseComment
			End Get
			Set(ByVal value As Boolean)
				_RadioShowOrderHouseComment = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property RadioPrintInvoiceDueDate As Boolean
			Get
				RadioPrintInvoiceDueDate = _RadioPrintInvoiceDueDate
			End Get
			Set(ByVal value As Boolean)
				_RadioPrintInvoiceDueDate = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property RadioShowLineDetail As Integer
			Get
				RadioShowLineDetail = _RadioShowLineDetail
			End Get
			Set(ByVal value As Integer)
				_RadioShowLineDetail = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property RadioOrderNumberColumn As Short
			Get
				RadioOrderNumberColumn = _RadioOrderNumberColumn
			End Get
			Set(ByVal value As Short)
				_RadioOrderNumberColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property RadioVendorNameColumn As Short
			Get
				RadioVendorNameColumn = _RadioVendorNameColumn
			End Get
			Set(ByVal value As Short)
				_RadioVendorNameColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property RadioShowVendorCode As Short
			Get
				RadioShowVendorCode = _RadioShowVendorCode
			End Get
			Set(ByVal value As Short)
				_RadioShowVendorCode = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property RadioOrderMonthsColumn As Short
			Get
				RadioOrderMonthsColumn = _RadioOrderMonthsColumn
			End Get
			Set(ByVal value As Short)
				_RadioOrderMonthsColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property RadioProgramColumn As Short
			Get
				RadioProgramColumn = _RadioProgramColumn
			End Get
			Set(ByVal value As Short)
				_RadioProgramColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property RadioSpotLengthColumn As Short
			Get
				RadioSpotLengthColumn = _RadioSpotLengthColumn
			End Get
			Set(ByVal value As Short)
				_RadioSpotLengthColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property RadioTagColumn As Short
			Get
				RadioTagColumn = _RadioTagColumn
			End Get
			Set(ByVal value As Short)
				_RadioTagColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property RadioStartEndTimesColumn As Short
			Get
				RadioStartEndTimesColumn = _RadioStartEndTimesColumn
			End Get
			Set(ByVal value As Short)
				_RadioStartEndTimesColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property RadioNumberOfSpotsColumn As Short
			Get
				RadioNumberOfSpotsColumn = _RadioNumberOfSpotsColumn
			End Get
			Set(ByVal value As Short)
				_RadioNumberOfSpotsColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property RadioRemarksColumn As Short
			Get
				RadioRemarksColumn = _RadioRemarksColumn
			End Get
			Set(ByVal value As Short)
				_RadioRemarksColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property RadioJobComponentNumberColumn As Short
			Get
				RadioJobComponentNumberColumn = _RadioJobComponentNumberColumn
			End Get
			Set(ByVal value As Short)
				_RadioJobComponentNumberColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property RadioJobDescriptionColumn As Short
			Get
				RadioJobDescriptionColumn = _RadioJobDescriptionColumn
			End Get
			Set(ByVal value As Short)
				_RadioJobDescriptionColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property RadioComponentDescriptionColumn As Short
			Get
				RadioComponentDescriptionColumn = _RadioComponentDescriptionColumn
			End Get
			Set(ByVal value As Short)
				_RadioComponentDescriptionColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property RadioOrderDetailCommentColumn As Short
			Get
				RadioOrderDetailCommentColumn = _RadioOrderDetailCommentColumn
			End Get
			Set(ByVal value As Short)
				_RadioOrderDetailCommentColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property RadioOrderHouseDetailCommentColumn As Short
			Get
				RadioOrderHouseDetailCommentColumn = _RadioOrderHouseDetailCommentColumn
			End Get
			Set(ByVal value As Short)
				_RadioOrderHouseDetailCommentColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property RadioExtraChargesColumn As Short
			Get
				RadioExtraChargesColumn = _RadioExtraChargesColumn
			End Get
			Set(ByVal value As Short)
				_RadioExtraChargesColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property RadioNetAmountColumn As Short
			Get
				RadioNetAmountColumn = _RadioNetAmountColumn
			End Get
			Set(ByVal value As Short)
				_RadioNetAmountColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property RadioCommissionAmountColumn As Short
			Get
				RadioCommissionAmountColumn = _RadioCommissionAmountColumn
			End Get
			Set(ByVal value As Short)
				_RadioCommissionAmountColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property RadioTaxAmountColumn As Short
			Get
				RadioTaxAmountColumn = _RadioTaxAmountColumn
			End Get
			Set(ByVal value As Short)
				_RadioTaxAmountColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property RadioBillAmountColumn As Short
			Get
				RadioBillAmountColumn = _RadioBillAmountColumn
			End Get
			Set(ByVal value As Short)
				_RadioBillAmountColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property RadioPriorBillAmountColumn As Short
			Get
				RadioPriorBillAmountColumn = _RadioPriorBillAmountColumn
			End Get
			Set(ByVal value As Short)
				_RadioPriorBillAmountColumn = value
			End Set
		End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        System.ComponentModel.Category("Columns")>
        Public Property RadioBilledToDateAmountColumn As Short
            Get
                RadioBilledToDateAmountColumn = _RadioBilledToDateAmountColumn
            End Get
            Set(ByVal value As Short)
                _RadioBilledToDateAmountColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        System.ComponentModel.Category("Columns")>
        Public Property RadioStartDateColumn As Short
        <System.Runtime.Serialization.DataMemberAttribute()>
		Public Property RadioShowCommissionSeparately As Boolean
			Get
				RadioShowCommissionSeparately = _RadioShowCommissionSeparately
			End Get
			Set(ByVal value As Boolean)
				_RadioShowCommissionSeparately = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property RadioShowRebateSeparately As Boolean
			Get
				RadioShowRebateSeparately = _RadioShowRebateSeparately
			End Get
			Set(ByVal value As Boolean)
				_RadioShowRebateSeparately = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property RadioShowTaxSeparately As Boolean
			Get
				RadioShowTaxSeparately = _RadioShowTaxSeparately
			End Get
			Set(ByVal value As Boolean)
				_RadioShowTaxSeparately = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property RadioShowBillingHistory As Boolean
			Get
				RadioShowBillingHistory = _RadioShowBillingHistory
			End Get
			Set(ByVal value As Boolean)
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
		Public Property RadioShowCampaign() As Boolean
			Get
				RadioShowCampaign = _RadioShowCampaign
			End Get
			Set(ByVal value As Boolean)
				_RadioShowCampaign = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property RadioShowCampaignComment() As Boolean
			Get
				RadioShowCampaignComment = _RadioShowCampaignComment
			End Get
			Set(ByVal value As Boolean)
				_RadioShowCampaignComment = value
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
		Public Property RadioShowSalesClass() As Boolean
			Get
				RadioShowSalesClass = _RadioShowSalesClass
			End Get
			Set(value As Boolean)
				_RadioShowSalesClass = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property RadioClientPOLocation() As Integer
			Get
				RadioClientPOLocation = _RadioClientPOLocation
			End Get
			Set(value As Integer)
				_RadioClientPOLocation = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property RadioSalesClassLocation() As Integer
			Get
				RadioSalesClassLocation = _RadioSalesClassLocation
			End Get
			Set(value As Integer)
				_RadioSalesClassLocation = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property RadioCampaignLocation() As Integer
			Get
				RadioCampaignLocation = _RadioCampaignLocation
			End Get
			Set(value As Integer)
				_RadioCampaignLocation = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property RadioHeaderGroupBy() As Integer
			Get
				RadioHeaderGroupBy = _RadioHeaderGroupBy
			End Get
			Set(value As Integer)
				_RadioHeaderGroupBy = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property RadioSortLinesBy() As Integer
			Get
				RadioSortLinesBy = _RadioSortLinesBy
			End Get
			Set(value As Integer)
				_RadioSortLinesBy = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property RadioLineNumberColumn() As Short
			Get
				RadioLineNumberColumn = _RadioLineNumberColumn
			End Get
			Set(value As Short)
				_RadioLineNumberColumn = value
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
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property RadioCloseDateColumn() As Short
			Get
				RadioCloseDateColumn = _RadioCloseDateColumn
			End Get
			Set(value As Short)
				_RadioCloseDateColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.DisplayName("Custom Invoice")>
		Public Property RadioCustomInvoiceID() As Nullable(Of Integer)
			Get
				RadioCustomInvoiceID = _RadioCustomInvoiceID
			End Get
			Set(ByVal value As Nullable(Of Integer))
				_RadioCustomInvoiceID = value
			End Set
		End Property

#End Region

#Region " Methods "

		Public Sub New()



		End Sub
		Public Sub New(ByVal MediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault)

			Me.RadioUseInvoiceCategoryDescription = Convert.ToBoolean(MediaInvoiceDefault.RadioUseInvoiceCategoryDescription.GetValueOrDefault(0))
			Me.RadioInvoiceTitle = MediaInvoiceDefault.RadioInvoiceTitle
			Me.RadioGroupByMarket = Convert.ToBoolean(MediaInvoiceDefault.RadioGroupByMarket.GetValueOrDefault(0))
			Me.RadioShowOrderDescription = Convert.ToBoolean(MediaInvoiceDefault.RadioShowOrderDescription.GetValueOrDefault(0))
			Me.RadioShowClientReference = Convert.ToBoolean(MediaInvoiceDefault.RadioShowClientReference.GetValueOrDefault(0))
			Me.RadioShowClientPO = Convert.ToBoolean(MediaInvoiceDefault.RadioShowClientPO.GetValueOrDefault(0))
			Me.RadioShowOrderComment = Convert.ToBoolean(MediaInvoiceDefault.RadioShowOrderComment.GetValueOrDefault(0))
			Me.RadioShowOrderHouseComment = Convert.ToBoolean(MediaInvoiceDefault.RadioShowOrderHouseComment.GetValueOrDefault(0))
			Me.RadioPrintInvoiceDueDate = Convert.ToBoolean(MediaInvoiceDefault.RadioPrintInvoiceDueDate.GetValueOrDefault(0))
			Me.RadioShowLineDetail = Convert.ToInt32(MediaInvoiceDefault.RadioShowLineDetail.GetValueOrDefault(0))

			Me.RadioOrderNumberColumn = MediaInvoiceDefault.RadioOrderNumberColumn.GetValueOrDefault(1)
			Me.RadioVendorNameColumn = MediaInvoiceDefault.RadioVendorNameColumn.GetValueOrDefault(2)
			Me.RadioShowVendorCode = MediaInvoiceDefault.RadioShowVendorCode.GetValueOrDefault(0)
			Me.RadioOrderMonthsColumn = MediaInvoiceDefault.RadioOrderMonthsColumn.GetValueOrDefault(0)
			Me.RadioNetAmountColumn = MediaInvoiceDefault.RadioNetAmountColumn.GetValueOrDefault(0)
			Me.RadioCommissionAmountColumn = MediaInvoiceDefault.RadioCommissionAmountColumn.GetValueOrDefault(0)
			Me.RadioTaxAmountColumn = MediaInvoiceDefault.RadioTaxAmountColumn.GetValueOrDefault(0)
			Me.RadioBillAmountColumn = MediaInvoiceDefault.RadioBillAmountColumn.GetValueOrDefault(0)
			Me.RadioPriorBillAmountColumn = MediaInvoiceDefault.RadioPriorBillAmountColumn.GetValueOrDefault(0)
			Me.RadioBilledToDateAmountColumn = MediaInvoiceDefault.RadioBilledToDateAmountColumn.GetValueOrDefault(0)
			Me.RadioProgramColumn = MediaInvoiceDefault.RadioProgramColumn.GetValueOrDefault(0)
			Me.RadioSpotLengthColumn = MediaInvoiceDefault.RadioSpotLengthColumn.GetValueOrDefault(0)
			Me.RadioTagColumn = MediaInvoiceDefault.RadioTagColumn.GetValueOrDefault(0)
			Me.RadioStartEndTimesColumn = MediaInvoiceDefault.RadioStartEndTimesColumn.GetValueOrDefault(0)
			Me.RadioNumberOfSpotsColumn = MediaInvoiceDefault.RadioNumberOfSpotsColumn.GetValueOrDefault(0)
			Me.RadioRemarksColumn = MediaInvoiceDefault.RadioRemarksColumn.GetValueOrDefault(0)
			Me.RadioJobComponentNumberColumn = MediaInvoiceDefault.RadioJobComponentNumberColumn.GetValueOrDefault(0)
			Me.RadioJobDescriptionColumn = MediaInvoiceDefault.RadioJobDescriptionColumn.GetValueOrDefault(0)
			Me.RadioComponentDescriptionColumn = MediaInvoiceDefault.RadioComponentDescriptionColumn.GetValueOrDefault(0)
			Me.RadioOrderDetailCommentColumn = MediaInvoiceDefault.RadioOrderDetailCommentColumn.GetValueOrDefault(0)
			Me.RadioOrderHouseDetailCommentColumn = MediaInvoiceDefault.RadioOrderHouseDetailCommentColumn.GetValueOrDefault(0)
            Me.RadioExtraChargesColumn = MediaInvoiceDefault.RadioExtraChargesColumn.GetValueOrDefault(0)
            Me.RadioStartDateColumn = MediaInvoiceDefault.RadioStartDateColumn

            Me.RadioShowCommissionSeparately = Convert.ToBoolean(MediaInvoiceDefault.RadioShowCommissionSeparately.GetValueOrDefault(0))
			Me.RadioShowRebateSeparately = Convert.ToBoolean(MediaInvoiceDefault.RadioShowRebateSeparately.GetValueOrDefault(0))
			Me.RadioShowTaxSeparately = Convert.ToBoolean(MediaInvoiceDefault.RadioShowTaxSeparately.GetValueOrDefault(0))
			Me.RadioShowBillingHistory = Convert.ToBoolean(MediaInvoiceDefault.RadioShowBillingHistory.GetValueOrDefault(0))
			Me.RadioShowCampaign = MediaInvoiceDefault.RadioShowCampaign
			Me.RadioShowCampaignComment = MediaInvoiceDefault.RadioShowCampaignComment
			Me.RadioShowOrderSubtotals = MediaInvoiceDefault.RadioShowOrderSubtotals

			Me.RadioShowSalesClass = MediaInvoiceDefault.RadioShowSalesClass
			Me.RadioClientPOLocation = MediaInvoiceDefault.RadioClientPOLocation
			Me.RadioSalesClassLocation = MediaInvoiceDefault.RadioSalesClassLocation
			Me.RadioCampaignLocation = MediaInvoiceDefault.RadioCampaignLocation
			Me.RadioHeaderGroupBy = MediaInvoiceDefault.RadioHeaderGroupBy
			Me.RadioSortLinesBy = MediaInvoiceDefault.RadioSortLinesBy
			Me.RadioLineNumberColumn = MediaInvoiceDefault.RadioLineNumberColumn
			Me.RadioShowZeroLineAmounts = MediaInvoiceDefault.RadioShowZeroLineAmounts
			Me.RadioCloseDateColumn = MediaInvoiceDefault.RadioCloseDateColumn
			Me.RadioCustomInvoiceID = MediaInvoiceDefault.RadioCustomInvoiceID

			_MediaInvoiceDefault = MediaInvoiceDefault

		End Sub
		Public Sub New(ByVal InvoicePrintingMediaSetting As InvoicePrintingMediaSetting)

			Me.RadioUseInvoiceCategoryDescription = InvoicePrintingMediaSetting.RadioUseInvoiceCategoryDescription.GetValueOrDefault(False)
			Me.RadioInvoiceTitle = InvoicePrintingMediaSetting.RadioInvoiceTitle
			Me.RadioGroupByMarket = InvoicePrintingMediaSetting.RadioGroupByMarket.GetValueOrDefault(False)
			Me.RadioShowOrderDescription = InvoicePrintingMediaSetting.RadioShowOrderDescription.GetValueOrDefault(False)
			Me.RadioShowClientReference = InvoicePrintingMediaSetting.RadioShowClientReference.GetValueOrDefault(False)
			Me.RadioShowClientPO = InvoicePrintingMediaSetting.RadioShowClientPO.GetValueOrDefault(False)
			Me.RadioShowOrderComment = InvoicePrintingMediaSetting.RadioShowOrderComment.GetValueOrDefault(False)
			Me.RadioShowOrderHouseComment = InvoicePrintingMediaSetting.RadioShowOrderHouseComment.GetValueOrDefault(False)
			Me.RadioPrintInvoiceDueDate = InvoicePrintingMediaSetting.RadioPrintInvoiceDueDate.GetValueOrDefault(False)
			Me.RadioShowLineDetail = If(InvoicePrintingMediaSetting.RadioShowLineDetail.GetValueOrDefault(False) = True, 1, 0)

			Me.RadioOrderNumberColumn = InvoicePrintingMediaSetting.RadioOrderNumberColumn.GetValueOrDefault(1)
			Me.RadioVendorNameColumn = InvoicePrintingMediaSetting.RadioVendorNameColumn.GetValueOrDefault(2)
			Me.RadioShowVendorCode = InvoicePrintingMediaSetting.RadioShowVendorCode.GetValueOrDefault(0)
			Me.RadioOrderMonthsColumn = InvoicePrintingMediaSetting.RadioOrderMonthsColumn.GetValueOrDefault(0)
			Me.RadioNetAmountColumn = InvoicePrintingMediaSetting.RadioNetAmountColumn.GetValueOrDefault(0)
			Me.RadioCommissionAmountColumn = InvoicePrintingMediaSetting.RadioCommissionAmountColumn.GetValueOrDefault(0)
			Me.RadioTaxAmountColumn = InvoicePrintingMediaSetting.RadioTaxAmountColumn.GetValueOrDefault(0)
			Me.RadioBillAmountColumn = InvoicePrintingMediaSetting.RadioBillAmountColumn.GetValueOrDefault(0)
			Me.RadioPriorBillAmountColumn = InvoicePrintingMediaSetting.RadioPriorBillAmountColumn.GetValueOrDefault(0)
			Me.RadioBilledToDateAmountColumn = InvoicePrintingMediaSetting.RadioBilledToDateAmountColumn.GetValueOrDefault(0)
			Me.RadioProgramColumn = InvoicePrintingMediaSetting.RadioProgramColumn.GetValueOrDefault(0)
			Me.RadioSpotLengthColumn = InvoicePrintingMediaSetting.RadioSpotLengthColumn.GetValueOrDefault(0)
			Me.RadioTagColumn = InvoicePrintingMediaSetting.RadioTagColumn.GetValueOrDefault(0)
			Me.RadioStartEndTimesColumn = InvoicePrintingMediaSetting.RadioStartEndTimesColumn.GetValueOrDefault(0)
			Me.RadioNumberOfSpotsColumn = InvoicePrintingMediaSetting.RadioNumberOfSpotsColumn.GetValueOrDefault(0)
			Me.RadioRemarksColumn = InvoicePrintingMediaSetting.RadioRemarksColumn.GetValueOrDefault(0)
			Me.RadioJobComponentNumberColumn = InvoicePrintingMediaSetting.RadioJobComponentNumberColumn.GetValueOrDefault(0)
			Me.RadioJobDescriptionColumn = InvoicePrintingMediaSetting.RadioJobDescriptionColumn.GetValueOrDefault(0)
			Me.RadioComponentDescriptionColumn = InvoicePrintingMediaSetting.RadioComponentDescriptionColumn.GetValueOrDefault(0)
			Me.RadioOrderDetailCommentColumn = InvoicePrintingMediaSetting.RadioOrderDetailCommentColumn.GetValueOrDefault(0)
			Me.RadioOrderHouseDetailCommentColumn = InvoicePrintingMediaSetting.RadioOrderHouseDetailCommentColumn.GetValueOrDefault(0)
			Me.RadioExtraChargesColumn = InvoicePrintingMediaSetting.RadioExtraChargesColumn.GetValueOrDefault(0)
            Me.RadioStartDateColumn = InvoicePrintingMediaSetting.RadioStartDateColumn.GetValueOrDefault(0)

            Me.RadioShowCommissionSeparately = InvoicePrintingMediaSetting.RadioShowCommissionSeparately.GetValueOrDefault(False)
			Me.RadioShowRebateSeparately = InvoicePrintingMediaSetting.RadioShowRebateSeparately.GetValueOrDefault(False)
			Me.RadioShowTaxSeparately = InvoicePrintingMediaSetting.RadioShowTaxSeparately.GetValueOrDefault(False)
			Me.RadioShowBillingHistory = InvoicePrintingMediaSetting.RadioShowBillingHistory.GetValueOrDefault(False)
			Me.RadioShowCampaign = InvoicePrintingMediaSetting.RadioShowCampaign
			Me.RadioShowCampaignComment = InvoicePrintingMediaSetting.RadioShowCampaignComment
			Me.RadioShowOrderSubtotals = InvoicePrintingMediaSetting.RadioShowOrderSubtotals

			Me.RadioShowSalesClass = InvoicePrintingMediaSetting.RadioShowSalesClass
			Me.RadioClientPOLocation = InvoicePrintingMediaSetting.RadioClientPOLocation
			Me.RadioSalesClassLocation = InvoicePrintingMediaSetting.RadioSalesClassLocation
			Me.RadioCampaignLocation = InvoicePrintingMediaSetting.RadioCampaignLocation
			Me.RadioHeaderGroupBy = InvoicePrintingMediaSetting.RadioHeaderGroupBy
			Me.RadioSortLinesBy = InvoicePrintingMediaSetting.RadioSortLinesBy
			Me.RadioLineNumberColumn = InvoicePrintingMediaSetting.RadioLineNumberColumn
			Me.RadioShowZeroLineAmounts = InvoicePrintingMediaSetting.RadioShowZeroLineAmounts
			Me.RadioCloseDateColumn = InvoicePrintingMediaSetting.RadioCloseDateColumn
			Me.RadioCustomInvoiceID = InvoicePrintingMediaSetting.RadioCustomInvoiceID

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

			InvoicePrintingMediaSetting.RadioUseInvoiceCategoryDescription = Me.RadioUseInvoiceCategoryDescription
			InvoicePrintingMediaSetting.RadioInvoiceTitle = Me.RadioInvoiceTitle
			InvoicePrintingMediaSetting.RadioGroupByMarket = Me.RadioGroupByMarket
			InvoicePrintingMediaSetting.RadioShowOrderDescription = Me.RadioShowOrderDescription
			InvoicePrintingMediaSetting.RadioShowClientReference = Me.RadioShowClientReference
			InvoicePrintingMediaSetting.RadioShowClientPO = Me.RadioShowClientPO
			InvoicePrintingMediaSetting.RadioShowOrderComment = Me.RadioShowOrderComment
			InvoicePrintingMediaSetting.RadioShowOrderHouseComment = Me.RadioShowOrderHouseComment
			InvoicePrintingMediaSetting.RadioPrintInvoiceDueDate = Me.RadioPrintInvoiceDueDate
			InvoicePrintingMediaSetting.RadioShowLineDetail = Convert.ToBoolean(Me.RadioShowLineDetail)

			InvoicePrintingMediaSetting.RadioOrderNumberColumn = Me.RadioOrderNumberColumn
			InvoicePrintingMediaSetting.RadioVendorNameColumn = Me.RadioVendorNameColumn
			InvoicePrintingMediaSetting.RadioShowVendorCode = Me.RadioShowVendorCode
			InvoicePrintingMediaSetting.RadioOrderMonthsColumn = Me.RadioOrderMonthsColumn
			InvoicePrintingMediaSetting.RadioNetAmountColumn = Me.RadioNetAmountColumn
			InvoicePrintingMediaSetting.RadioCommissionAmountColumn = Me.RadioCommissionAmountColumn
			InvoicePrintingMediaSetting.RadioTaxAmountColumn = Me.RadioTaxAmountColumn
			InvoicePrintingMediaSetting.RadioBillAmountColumn = Me.RadioBillAmountColumn
			InvoicePrintingMediaSetting.RadioPriorBillAmountColumn = Me.RadioPriorBillAmountColumn
			InvoicePrintingMediaSetting.RadioBilledToDateAmountColumn = Me.RadioBilledToDateAmountColumn
			InvoicePrintingMediaSetting.RadioProgramColumn = Me.RadioProgramColumn
			InvoicePrintingMediaSetting.RadioSpotLengthColumn = Me.RadioSpotLengthColumn
			InvoicePrintingMediaSetting.RadioTagColumn = Me.RadioTagColumn
			InvoicePrintingMediaSetting.RadioStartEndTimesColumn = Me.RadioStartEndTimesColumn
			InvoicePrintingMediaSetting.RadioNumberOfSpotsColumn = Me.RadioNumberOfSpotsColumn
			InvoicePrintingMediaSetting.RadioRemarksColumn = Me.RadioRemarksColumn
			InvoicePrintingMediaSetting.RadioJobComponentNumberColumn = Me.RadioJobComponentNumberColumn
			InvoicePrintingMediaSetting.RadioJobDescriptionColumn = Me.RadioJobDescriptionColumn
			InvoicePrintingMediaSetting.RadioComponentDescriptionColumn = Me.RadioComponentDescriptionColumn
			InvoicePrintingMediaSetting.RadioOrderDetailCommentColumn = Me.RadioOrderDetailCommentColumn
			InvoicePrintingMediaSetting.RadioOrderHouseDetailCommentColumn = Me.RadioOrderHouseDetailCommentColumn
            InvoicePrintingMediaSetting.RadioExtraChargesColumn = Me.RadioExtraChargesColumn
            InvoicePrintingMediaSetting.RadioStartDateColumn = Me.RadioStartDateColumn

            InvoicePrintingMediaSetting.RadioShowCommissionSeparately = Me.RadioShowCommissionSeparately
			InvoicePrintingMediaSetting.RadioShowRebateSeparately = Me.RadioShowRebateSeparately
			InvoicePrintingMediaSetting.RadioShowTaxSeparately = Me.RadioShowTaxSeparately
			InvoicePrintingMediaSetting.RadioShowBillingHistory = Me.RadioShowBillingHistory
			InvoicePrintingMediaSetting.RadioShowCampaign = Me.RadioShowCampaign
			InvoicePrintingMediaSetting.RadioShowCampaignComment = Me.RadioShowCampaignComment
			InvoicePrintingMediaSetting.RadioShowOrderSubtotals = Me.RadioShowOrderSubtotals

			InvoicePrintingMediaSetting.RadioShowSalesClass = Me.RadioShowSalesClass
			InvoicePrintingMediaSetting.RadioClientPOLocation = Me.RadioClientPOLocation
			InvoicePrintingMediaSetting.RadioSalesClassLocation = Me.RadioSalesClassLocation
			InvoicePrintingMediaSetting.RadioCampaignLocation = Me.RadioCampaignLocation
			InvoicePrintingMediaSetting.RadioHeaderGroupBy = Me.RadioHeaderGroupBy
			InvoicePrintingMediaSetting.RadioSortLinesBy = Me.RadioSortLinesBy
			InvoicePrintingMediaSetting.RadioLineNumberColumn = Me.RadioLineNumberColumn
			InvoicePrintingMediaSetting.RadioShowZeroLineAmounts = Me.RadioShowZeroLineAmounts
			InvoicePrintingMediaSetting.RadioCloseDateColumn = Me.RadioCloseDateColumn
			InvoicePrintingMediaSetting.RadioCustomInvoiceID = Me.RadioCustomInvoiceID

		End Sub
		Public Sub Save(ByVal MediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault)

			MediaInvoiceDefault.RadioUseInvoiceCategoryDescription = Convert.ToInt16(Me.RadioUseInvoiceCategoryDescription)
			MediaInvoiceDefault.RadioInvoiceTitle = Me.RadioInvoiceTitle
			MediaInvoiceDefault.RadioGroupByMarket = Convert.ToInt16(Me.RadioGroupByMarket)
			MediaInvoiceDefault.RadioShowOrderDescription = Convert.ToInt16(Me.RadioShowOrderDescription)
			MediaInvoiceDefault.RadioShowClientReference = Convert.ToInt16(Me.RadioShowClientReference)
			MediaInvoiceDefault.RadioShowClientPO = Convert.ToInt16(Me.RadioShowClientPO)
			MediaInvoiceDefault.RadioShowOrderComment = Convert.ToInt16(Me.RadioShowOrderComment)
			MediaInvoiceDefault.RadioShowOrderHouseComment = Convert.ToInt16(Me.RadioShowOrderHouseComment)
			MediaInvoiceDefault.RadioPrintInvoiceDueDate = Convert.ToInt16(Me.RadioPrintInvoiceDueDate)
			MediaInvoiceDefault.RadioShowLineDetail = Convert.ToInt16(Me.RadioShowLineDetail)

			MediaInvoiceDefault.RadioOrderNumberColumn = Me.RadioOrderNumberColumn
			MediaInvoiceDefault.RadioVendorNameColumn = Me.RadioVendorNameColumn
			MediaInvoiceDefault.RadioShowVendorCode = Me.RadioShowVendorCode
			MediaInvoiceDefault.RadioOrderMonthsColumn = Me.RadioOrderMonthsColumn
			MediaInvoiceDefault.RadioNetAmountColumn = Me.RadioNetAmountColumn
			MediaInvoiceDefault.RadioCommissionAmountColumn = Me.RadioCommissionAmountColumn
			MediaInvoiceDefault.RadioTaxAmountColumn = Me.RadioTaxAmountColumn
			MediaInvoiceDefault.RadioBillAmountColumn = Me.RadioBillAmountColumn
			MediaInvoiceDefault.RadioPriorBillAmountColumn = Me.RadioPriorBillAmountColumn
			MediaInvoiceDefault.RadioBilledToDateAmountColumn = Me.RadioBilledToDateAmountColumn
			MediaInvoiceDefault.RadioProgramColumn = Me.RadioProgramColumn
			MediaInvoiceDefault.RadioSpotLengthColumn = Me.RadioSpotLengthColumn
			MediaInvoiceDefault.RadioTagColumn = Me.RadioTagColumn
			MediaInvoiceDefault.RadioStartEndTimesColumn = Me.RadioStartEndTimesColumn
			MediaInvoiceDefault.RadioNumberOfSpotsColumn = Me.RadioNumberOfSpotsColumn
			MediaInvoiceDefault.RadioRemarksColumn = Me.RadioRemarksColumn
			MediaInvoiceDefault.RadioJobComponentNumberColumn = Me.RadioJobComponentNumberColumn
			MediaInvoiceDefault.RadioJobDescriptionColumn = Me.RadioJobDescriptionColumn
			MediaInvoiceDefault.RadioComponentDescriptionColumn = Me.RadioComponentDescriptionColumn
			MediaInvoiceDefault.RadioOrderDetailCommentColumn = Me.RadioOrderDetailCommentColumn
			MediaInvoiceDefault.RadioOrderHouseDetailCommentColumn = Me.RadioOrderHouseDetailCommentColumn
            MediaInvoiceDefault.RadioExtraChargesColumn = Me.RadioExtraChargesColumn
            MediaInvoiceDefault.RadioStartDateColumn = Me.RadioStartDateColumn

            MediaInvoiceDefault.RadioShowCommissionSeparately = Convert.ToInt16(Me.RadioShowCommissionSeparately)
			MediaInvoiceDefault.RadioShowRebateSeparately = Convert.ToInt16(Me.RadioShowRebateSeparately)
			MediaInvoiceDefault.RadioShowTaxSeparately = Convert.ToInt16(Me.RadioShowTaxSeparately)
			MediaInvoiceDefault.RadioShowBillingHistory = Convert.ToInt16(Me.RadioShowBillingHistory)
			MediaInvoiceDefault.RadioShowCampaign = Me.RadioShowCampaign
			MediaInvoiceDefault.RadioShowCampaignComment = Me.RadioShowCampaignComment
			MediaInvoiceDefault.RadioShowOrderSubtotals = Me.RadioShowOrderSubtotals

			MediaInvoiceDefault.RadioShowSalesClass = Me.RadioShowSalesClass
			MediaInvoiceDefault.RadioClientPOLocation = Me.RadioClientPOLocation
			MediaInvoiceDefault.RadioSalesClassLocation = Me.RadioSalesClassLocation
			MediaInvoiceDefault.RadioCampaignLocation = Me.RadioCampaignLocation
			MediaInvoiceDefault.RadioHeaderGroupBy = Me.RadioHeaderGroupBy
			MediaInvoiceDefault.RadioSortLinesBy = Me.RadioSortLinesBy
			MediaInvoiceDefault.RadioLineNumberColumn = Me.RadioLineNumberColumn
			MediaInvoiceDefault.RadioShowZeroLineAmounts = Me.RadioShowZeroLineAmounts
			MediaInvoiceDefault.RadioCloseDateColumn = Me.RadioCloseDateColumn
			MediaInvoiceDefault.RadioCustomInvoiceID = Me.RadioCustomInvoiceID

		End Sub
        Public Overrides Function ToString() As String

            ToString = ""

        End Function

#End Region

    End Class

End Namespace
