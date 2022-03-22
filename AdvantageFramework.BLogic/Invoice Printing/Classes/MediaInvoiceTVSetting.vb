Namespace InvoicePrinting.Classes

    <Serializable()>
    Public Class MediaInvoiceTVSetting

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            TVUseInvoiceCategoryDescription
            TVInvoiceTitle
            TVGroupByMarket
            TVShowOrderDescription
            TVShowClientReference
            TVShowClientPO
            TVShowOrderComment
            TVShowOrderHouseComment
            TVPrintInvoiceDueDate
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
            TVCustomFormatName
            TVShowCampaign
            TVShowCampaignComment
            TVShowOrderSubtotals
            TVShowSalesClass
            TVClientPOLocation
            TVSalesClassLocation
            TVCampaignLocation
            TVHeaderGroupBy
            TVSortLinesBy
            TVLineNumberColumn
            TVShowZeroLineAmounts
			TVCloseDateColumn
            TVCustomInvoiceID
            TVStartDateColumn
        End Enum

#End Region

#Region " Variables "

		Private _TVUseInvoiceCategoryDescription As Boolean = False
		Private _TVInvoiceTitle As String = Nothing
		Private _TVGroupByMarket As Boolean = False
		Private _TVShowOrderDescription As Boolean = False
		Private _TVShowClientReference As Boolean = False
		Private _TVShowClientPO As Boolean = False
		Private _TVShowOrderComment As Boolean = False
		Private _TVShowOrderHouseComment As Boolean = False
		Private _TVPrintInvoiceDueDate As Boolean = False
		Private _TVShowLineDetail As Integer = 1
		Private _TVOrderNumberColumn As Short = 1
		Private _TVVendorNameColumn As Short = 0
		Private _TVShowVendorCode As Short = 0
		Private _TVOrderMonthsColumn As Short = 0
		Private _TVProgramColumn As Short = 0
		Private _TVSpotLengthColumn As Short = 0
		Private _TVTagColumn As Short = 0
		Private _TVStartEndTimesColumn As Short = 0
		Private _TVNumberOfSpotsColumn As Short = 0
		Private _TVRemarksColumn As Short = 0
		Private _TVJobComponentNumberColumn As Short = 0
		Private _TVJobDescriptionColumn As Short = 0
		Private _TVComponentDescriptionColumn As Short = 0
		Private _TVOrderDetailCommentColumn As Short = 0
		Private _TVOrderHouseDetailCommentColumn As Short = 0
		Private _TVExtraChargesColumn As Short = 0
		Private _TVNetAmountColumn As Short = 0
		Private _TVCommissionAmountColumn As Short = 0
		Private _TVTaxAmountColumn As Short = 0
		Private _TVBillAmountColumn As Short = 0
		Private _TVPriorBillAmountColumn As Short = 0
		Private _TVBilledToDateAmountColumn As Short = 0
		Private _TVShowCommissionSeparately As Boolean = False
		Private _TVShowRebateSeparately As Boolean = False
		Private _TVShowTaxSeparately As Boolean = False
		Private _TVShowBillingHistory As Boolean = False
		Private _TVCustomFormatName As String = Nothing
		Private _TVShowCampaign As Boolean = False
		Private _TVShowCampaignComment As Boolean = False
		Private _TVShowOrderSubtotals As Boolean = False
		Private _TVShowSalesClass As Boolean = False
		Private _TVClientPOLocation As Integer = 1
		Private _TVSalesClassLocation As Integer = 1
		Private _TVCampaignLocation As Integer = 1
		Private _TVHeaderGroupBy As Integer = Nothing
		Private _TVSortLinesBy As Integer = 1
		Private _TVLineNumberColumn As Short = 0
		Private _TVShowZeroLineAmounts As Boolean = False
		Private _TVCloseDateColumn As Short = 0
		Private _TVCustomInvoiceID As Nullable(Of Integer) = Nothing

		Private _MediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault = Nothing
		Private _InvoicePrintingMediaSetting As InvoicePrintingMediaSetting = Nothing

#End Region

#Region " Properties "

		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property TVUseInvoiceCategoryDescription As Boolean
			Get
				TVUseInvoiceCategoryDescription = _TVUseInvoiceCategoryDescription
			End Get
			Set(ByVal value As Boolean)
				_TVUseInvoiceCategoryDescription = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property TVInvoiceTitle As String
			Get
				TVInvoiceTitle = _TVInvoiceTitle
			End Get
			Set(ByVal value As String)
				_TVInvoiceTitle = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property TVGroupByMarket As Boolean
			Get
				TVGroupByMarket = _TVGroupByMarket
			End Get
			Set(ByVal value As Boolean)
				_TVGroupByMarket = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property TVShowOrderDescription As Boolean
			Get
				TVShowOrderDescription = _TVShowOrderDescription
			End Get
			Set(ByVal value As Boolean)
				_TVShowOrderDescription = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property TVShowClientReference As Boolean
			Get
				TVShowClientReference = _TVShowClientReference
			End Get
			Set(ByVal value As Boolean)
				_TVShowClientReference = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property TVShowClientPO As Boolean
			Get
				TVShowClientPO = _TVShowClientPO
			End Get
			Set(ByVal value As Boolean)
				_TVShowClientPO = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property TVShowOrderComment As Boolean
			Get
				TVShowOrderComment = _TVShowOrderComment
			End Get
			Set(ByVal value As Boolean)
				_TVShowOrderComment = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property TVShowOrderHouseComment As Boolean
			Get
				TVShowOrderHouseComment = _TVShowOrderHouseComment
			End Get
			Set(ByVal value As Boolean)
				_TVShowOrderHouseComment = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property TVPrintInvoiceDueDate As Boolean
			Get
				TVPrintInvoiceDueDate = _TVPrintInvoiceDueDate
			End Get
			Set(ByVal value As Boolean)
				_TVPrintInvoiceDueDate = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property TVShowLineDetail As Integer
			Get
				TVShowLineDetail = _TVShowLineDetail
			End Get
			Set(ByVal value As Integer)
				_TVShowLineDetail = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property TVOrderNumberColumn As Short
			Get
				TVOrderNumberColumn = _TVOrderNumberColumn
			End Get
			Set(ByVal value As Short)
				_TVOrderNumberColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property TVVendorNameColumn As Short
			Get
				TVVendorNameColumn = _TVVendorNameColumn
			End Get
			Set(ByVal value As Short)
				_TVVendorNameColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property TVShowVendorCode As Short
			Get
				TVShowVendorCode = _TVShowVendorCode
			End Get
			Set(ByVal value As Short)
				_TVShowVendorCode = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property TVOrderMonthsColumn As Short
			Get
				TVOrderMonthsColumn = _TVOrderMonthsColumn
			End Get
			Set(ByVal value As Short)
				_TVOrderMonthsColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property TVProgramColumn As Short
			Get
				TVProgramColumn = _TVProgramColumn
			End Get
			Set(ByVal value As Short)
				_TVProgramColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property TVSpotLengthColumn As Short
			Get
				TVSpotLengthColumn = _TVSpotLengthColumn
			End Get
			Set(ByVal value As Short)
				_TVSpotLengthColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property TVTagColumn As Short
			Get
				TVTagColumn = _TVTagColumn
			End Get
			Set(ByVal value As Short)
				_TVTagColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property TVStartEndTimesColumn As Short
			Get
				TVStartEndTimesColumn = _TVStartEndTimesColumn
			End Get
			Set(ByVal value As Short)
				_TVStartEndTimesColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property TVNumberOfSpotsColumn As Short
			Get
				TVNumberOfSpotsColumn = _TVNumberOfSpotsColumn
			End Get
			Set(ByVal value As Short)
				_TVNumberOfSpotsColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property TVRemarksColumn As Short
			Get
				TVRemarksColumn = _TVRemarksColumn
			End Get
			Set(ByVal value As Short)
				_TVRemarksColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property TVJobComponentNumberColumn As Short
			Get
				TVJobComponentNumberColumn = _TVJobComponentNumberColumn
			End Get
			Set(ByVal value As Short)
				_TVJobComponentNumberColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property TVJobDescriptionColumn As Short
			Get
				TVJobDescriptionColumn = _TVJobDescriptionColumn
			End Get
			Set(ByVal value As Short)
				_TVJobDescriptionColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property TVComponentDescriptionColumn As Short
			Get
				TVComponentDescriptionColumn = _TVComponentDescriptionColumn
			End Get
			Set(ByVal value As Short)
				_TVComponentDescriptionColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property TVOrderDetailCommentColumn As Short
			Get
				TVOrderDetailCommentColumn = _TVOrderDetailCommentColumn
			End Get
			Set(ByVal value As Short)
				_TVOrderDetailCommentColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property TVOrderHouseDetailCommentColumn As Short
			Get
				TVOrderHouseDetailCommentColumn = _TVOrderHouseDetailCommentColumn
			End Get
			Set(ByVal value As Short)
				_TVOrderHouseDetailCommentColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property TVExtraChargesColumn As Short
			Get
				TVExtraChargesColumn = _TVExtraChargesColumn
			End Get
			Set(ByVal value As Short)
				_TVExtraChargesColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property TVNetAmountColumn As Short
			Get
				TVNetAmountColumn = _TVNetAmountColumn
			End Get
			Set(ByVal value As Short)
				_TVNetAmountColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property TVCommissionAmountColumn As Short
			Get
				TVCommissionAmountColumn = _TVCommissionAmountColumn
			End Get
			Set(ByVal value As Short)
				_TVCommissionAmountColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property TVTaxAmountColumn As Short
			Get
				TVTaxAmountColumn = _TVTaxAmountColumn
			End Get
			Set(ByVal value As Short)
				_TVTaxAmountColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property TVBillAmountColumn As Short
			Get
				TVBillAmountColumn = _TVBillAmountColumn
			End Get
			Set(ByVal value As Short)
				_TVBillAmountColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property TVPriorBillAmountColumn As Short
			Get
				TVPriorBillAmountColumn = _TVPriorBillAmountColumn
			End Get
			Set(ByVal value As Short)
				_TVPriorBillAmountColumn = value
			End Set
		End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        System.ComponentModel.Category("Columns")>
        Public Property TVBilledToDateAmountColumn As Short
            Get
                TVBilledToDateAmountColumn = _TVBilledToDateAmountColumn
            End Get
            Set(ByVal value As Short)
                _TVBilledToDateAmountColumn = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        System.ComponentModel.Category("Columns")>
        Public Property TVStartDateColumn As Short
        <System.Runtime.Serialization.DataMemberAttribute()>
		Public Property TVShowCommissionSeparately As Boolean
			Get
				TVShowCommissionSeparately = _TVShowCommissionSeparately
			End Get
			Set(ByVal value As Boolean)
				_TVShowCommissionSeparately = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property TVShowRebateSeparately As Boolean
			Get
				TVShowRebateSeparately = _TVShowRebateSeparately
			End Get
			Set(ByVal value As Boolean)
				_TVShowRebateSeparately = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property TVShowTaxSeparately As Boolean
			Get
				TVShowTaxSeparately = _TVShowTaxSeparately
			End Get
			Set(ByVal value As Boolean)
				_TVShowTaxSeparately = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property TVShowBillingHistory As Boolean
			Get
				TVShowBillingHistory = _TVShowBillingHistory
			End Get
			Set(ByVal value As Boolean)
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
		Public Property TVShowCampaign() As Boolean
			Get
				TVShowCampaign = _TVShowCampaign
			End Get
			Set(ByVal value As Boolean)
				_TVShowCampaign = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property TVShowCampaignComment() As Boolean
			Get
				TVShowCampaignComment = _TVShowCampaignComment
			End Get
			Set(ByVal value As Boolean)
				_TVShowCampaignComment = value
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
		Public Property TVShowSalesClass() As Boolean
			Get
				TVShowSalesClass = _TVShowSalesClass
			End Get
			Set(value As Boolean)
				_TVShowSalesClass = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property TVClientPOLocation() As Integer
			Get
				TVClientPOLocation = _TVClientPOLocation
			End Get
			Set(value As Integer)
				_TVClientPOLocation = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property TVSalesClassLocation() As Integer
			Get
				TVSalesClassLocation = _TVSalesClassLocation
			End Get
			Set(value As Integer)
				_TVSalesClassLocation = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property TVCampaignLocation() As Integer
			Get
				TVCampaignLocation = _TVCampaignLocation
			End Get
			Set(value As Integer)
				_TVCampaignLocation = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property TVHeaderGroupBy() As Integer
			Get
				TVHeaderGroupBy = _TVHeaderGroupBy
			End Get
			Set(value As Integer)
				_TVHeaderGroupBy = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property TVSortLinesBy() As Integer
			Get
				TVSortLinesBy = _TVSortLinesBy
			End Get
			Set(value As Integer)
				_TVSortLinesBy = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property TVLineNumberColumn() As Short
			Get
				TVLineNumberColumn = _TVLineNumberColumn
			End Get
			Set(value As Short)
				_TVLineNumberColumn = value
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
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property TVCloseDateColumn() As Short
			Get
				TVCloseDateColumn = _TVCloseDateColumn
			End Get
			Set(value As Short)
				_TVCloseDateColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.DisplayName("Custom Invoice")>
		Public Property TVCustomInvoiceID() As Nullable(Of Integer)
			Get
				TVCustomInvoiceID = _TVCustomInvoiceID
			End Get
			Set(ByVal value As Nullable(Of Integer))
				_TVCustomInvoiceID = value
			End Set
		End Property

#End Region

#Region " Methods "

		Public Sub New()



		End Sub
		Public Sub New(ByVal MediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault)

			Me.TVUseInvoiceCategoryDescription = Convert.ToBoolean(MediaInvoiceDefault.TVUseInvoiceCategoryDescription.GetValueOrDefault(0))
			Me.TVInvoiceTitle = MediaInvoiceDefault.TVInvoiceTitle
			Me.TVGroupByMarket = Convert.ToBoolean(MediaInvoiceDefault.TVGroupByMarket.GetValueOrDefault(0))
			Me.TVShowOrderDescription = Convert.ToBoolean(MediaInvoiceDefault.TVShowOrderDescription.GetValueOrDefault(0))
			Me.TVShowClientReference = Convert.ToBoolean(MediaInvoiceDefault.TVShowClientReference.GetValueOrDefault(0))
			Me.TVShowClientPO = Convert.ToBoolean(MediaInvoiceDefault.TVShowClientPO.GetValueOrDefault(0))
			Me.TVShowOrderComment = Convert.ToBoolean(MediaInvoiceDefault.TVShowOrderComment.GetValueOrDefault(0))
			Me.TVShowOrderHouseComment = Convert.ToBoolean(MediaInvoiceDefault.TVShowOrderHouseComment.GetValueOrDefault(0))
			Me.TVPrintInvoiceDueDate = Convert.ToBoolean(MediaInvoiceDefault.TVPrintInvoiceDueDate.GetValueOrDefault(0))
			Me.TVShowLineDetail = Convert.ToInt32(MediaInvoiceDefault.TVShowLineDetail.GetValueOrDefault(0))

			Me.TVOrderNumberColumn = MediaInvoiceDefault.TVOrderNumberColumn.GetValueOrDefault(1)
			Me.TVVendorNameColumn = MediaInvoiceDefault.TVVendorNameColumn.GetValueOrDefault(2)
			Me.TVShowVendorCode = MediaInvoiceDefault.TVShowVendorCode.GetValueOrDefault(0)
			Me.TVOrderMonthsColumn = MediaInvoiceDefault.TVOrderMonthsColumn.GetValueOrDefault(0)
			Me.TVNetAmountColumn = MediaInvoiceDefault.TVNetAmountColumn.GetValueOrDefault(0)
			Me.TVCommissionAmountColumn = MediaInvoiceDefault.TVCommissionAmountColumn.GetValueOrDefault(0)
			Me.TVTaxAmountColumn = MediaInvoiceDefault.TVTaxAmountColumn.GetValueOrDefault(0)
			Me.TVBillAmountColumn = MediaInvoiceDefault.TVBillAmountColumn.GetValueOrDefault(0)
			Me.TVPriorBillAmountColumn = MediaInvoiceDefault.TVPriorBillAmountColumn.GetValueOrDefault(0)
			Me.TVBilledToDateAmountColumn = MediaInvoiceDefault.TVBilledToDateAmountColumn.GetValueOrDefault(0)
			Me.TVProgramColumn = MediaInvoiceDefault.TVProgramColumn.GetValueOrDefault(0)
			Me.TVSpotLengthColumn = MediaInvoiceDefault.TVSpotLengthColumn.GetValueOrDefault(0)
			Me.TVTagColumn = MediaInvoiceDefault.TVTagColumn.GetValueOrDefault(0)
			Me.TVStartEndTimesColumn = MediaInvoiceDefault.TVStartEndTimesColumn.GetValueOrDefault(0)
			Me.TVNumberOfSpotsColumn = MediaInvoiceDefault.TVNumberOfSpotsColumn.GetValueOrDefault(0)
			Me.TVRemarksColumn = MediaInvoiceDefault.TVRemarksColumn.GetValueOrDefault(0)
			Me.TVJobComponentNumberColumn = MediaInvoiceDefault.TVJobComponentNumberColumn.GetValueOrDefault(0)
			Me.TVJobDescriptionColumn = MediaInvoiceDefault.TVJobDescriptionColumn.GetValueOrDefault(0)
			Me.TVComponentDescriptionColumn = MediaInvoiceDefault.TVComponentDescriptionColumn.GetValueOrDefault(0)
			Me.TVOrderDetailCommentColumn = MediaInvoiceDefault.TVOrderDetailCommentColumn.GetValueOrDefault(0)
			Me.TVOrderHouseDetailCommentColumn = MediaInvoiceDefault.TVOrderHouseDetailCommentColumn.GetValueOrDefault(0)
			Me.TVExtraChargesColumn = MediaInvoiceDefault.TVExtraChargesColumn.GetValueOrDefault(0)
            Me.TVStartDateColumn = MediaInvoiceDefault.TVStartDateColumn

            Me.TVShowCommissionSeparately = Convert.ToBoolean(MediaInvoiceDefault.TVShowCommissionSeparately.GetValueOrDefault(0))
			Me.TVShowRebateSeparately = Convert.ToBoolean(MediaInvoiceDefault.TVShowRebateSeparately.GetValueOrDefault(0))
			Me.TVShowTaxSeparately = Convert.ToBoolean(MediaInvoiceDefault.TVShowTaxSeparately.GetValueOrDefault(0))
			Me.TVShowBillingHistory = Convert.ToBoolean(MediaInvoiceDefault.TVShowBillingHistory.GetValueOrDefault(0))
			Me.TVShowCampaign = MediaInvoiceDefault.TVShowCampaign
			Me.TVShowCampaignComment = MediaInvoiceDefault.TVShowCampaignComment
			Me.TVShowOrderSubtotals = MediaInvoiceDefault.TVShowOrderSubtotals

			Me.TVShowSalesClass = MediaInvoiceDefault.TVShowSalesClass
			Me.TVClientPOLocation = MediaInvoiceDefault.TVClientPOLocation
			Me.TVSalesClassLocation = MediaInvoiceDefault.TVSalesClassLocation
			Me.TVCampaignLocation = MediaInvoiceDefault.TVCampaignLocation
			Me.TVHeaderGroupBy = MediaInvoiceDefault.TVHeaderGroupBy
			Me.TVSortLinesBy = MediaInvoiceDefault.TVSortLinesBy
			Me.TVLineNumberColumn = MediaInvoiceDefault.TVLineNumberColumn
			Me.TVShowZeroLineAmounts = MediaInvoiceDefault.TVShowZeroLineAmounts
			Me.TVCloseDateColumn = MediaInvoiceDefault.TVCloseDateColumn
			Me.TVCustomInvoiceID = MediaInvoiceDefault.TVCustomInvoiceID

			_MediaInvoiceDefault = MediaInvoiceDefault

		End Sub
		Public Sub New(ByVal InvoicePrintingMediaSetting As InvoicePrintingMediaSetting)

			Me.TVUseInvoiceCategoryDescription = InvoicePrintingMediaSetting.TVUseInvoiceCategoryDescription.GetValueOrDefault(False)
			Me.TVInvoiceTitle = InvoicePrintingMediaSetting.TVInvoiceTitle
			Me.TVGroupByMarket = InvoicePrintingMediaSetting.TVGroupByMarket.GetValueOrDefault(False)
			Me.TVShowOrderDescription = InvoicePrintingMediaSetting.TVShowOrderDescription.GetValueOrDefault(False)
			Me.TVShowClientReference = InvoicePrintingMediaSetting.TVShowClientReference.GetValueOrDefault(False)
			Me.TVShowClientPO = InvoicePrintingMediaSetting.TVShowClientPO.GetValueOrDefault(False)
			Me.TVShowOrderComment = InvoicePrintingMediaSetting.TVShowOrderComment.GetValueOrDefault(False)
			Me.TVShowOrderHouseComment = InvoicePrintingMediaSetting.TVShowOrderHouseComment.GetValueOrDefault(False)
			Me.TVPrintInvoiceDueDate = InvoicePrintingMediaSetting.TVPrintInvoiceDueDate.GetValueOrDefault(False)
			Me.TVShowLineDetail = If(InvoicePrintingMediaSetting.TVShowLineDetail.GetValueOrDefault(False) = True, 1, 0)

			Me.TVOrderNumberColumn = InvoicePrintingMediaSetting.TVOrderNumberColumn.GetValueOrDefault(1)
			Me.TVVendorNameColumn = InvoicePrintingMediaSetting.TVVendorNameColumn.GetValueOrDefault(2)
			Me.TVShowVendorCode = InvoicePrintingMediaSetting.TVShowVendorCode.GetValueOrDefault(0)
			Me.TVOrderMonthsColumn = InvoicePrintingMediaSetting.TVOrderMonthsColumn.GetValueOrDefault(0)
			Me.TVNetAmountColumn = InvoicePrintingMediaSetting.TVNetAmountColumn.GetValueOrDefault(0)
			Me.TVCommissionAmountColumn = InvoicePrintingMediaSetting.TVCommissionAmountColumn.GetValueOrDefault(0)
			Me.TVTaxAmountColumn = InvoicePrintingMediaSetting.TVTaxAmountColumn.GetValueOrDefault(0)
			Me.TVBillAmountColumn = InvoicePrintingMediaSetting.TVBillAmountColumn.GetValueOrDefault(0)
			Me.TVPriorBillAmountColumn = InvoicePrintingMediaSetting.TVPriorBillAmountColumn.GetValueOrDefault(0)
			Me.TVBilledToDateAmountColumn = InvoicePrintingMediaSetting.TVBilledToDateAmountColumn.GetValueOrDefault(0)
			Me.TVProgramColumn = InvoicePrintingMediaSetting.TVProgramColumn.GetValueOrDefault(0)
			Me.TVSpotLengthColumn = InvoicePrintingMediaSetting.TVSpotLengthColumn.GetValueOrDefault(0)
			Me.TVTagColumn = InvoicePrintingMediaSetting.TVTagColumn.GetValueOrDefault(0)
			Me.TVStartEndTimesColumn = InvoicePrintingMediaSetting.TVStartEndTimesColumn.GetValueOrDefault(0)
			Me.TVNumberOfSpotsColumn = InvoicePrintingMediaSetting.TVNumberOfSpotsColumn.GetValueOrDefault(0)
			Me.TVRemarksColumn = InvoicePrintingMediaSetting.TVRemarksColumn.GetValueOrDefault(0)
			Me.TVJobComponentNumberColumn = InvoicePrintingMediaSetting.TVJobComponentNumberColumn.GetValueOrDefault(0)
			Me.TVJobDescriptionColumn = InvoicePrintingMediaSetting.TVJobDescriptionColumn.GetValueOrDefault(0)
			Me.TVComponentDescriptionColumn = InvoicePrintingMediaSetting.TVComponentDescriptionColumn.GetValueOrDefault(0)
			Me.TVOrderDetailCommentColumn = InvoicePrintingMediaSetting.TVOrderDetailCommentColumn.GetValueOrDefault(0)
			Me.TVOrderHouseDetailCommentColumn = InvoicePrintingMediaSetting.TVOrderHouseDetailCommentColumn.GetValueOrDefault(0)
			Me.TVExtraChargesColumn = InvoicePrintingMediaSetting.TVExtraChargesColumn.GetValueOrDefault(0)
            Me.TVStartDateColumn = InvoicePrintingMediaSetting.TVStartDateColumn.GetValueOrDefault(0)

            Me.TVShowCommissionSeparately = InvoicePrintingMediaSetting.TVShowCommissionSeparately.GetValueOrDefault(False)
			Me.TVShowRebateSeparately = InvoicePrintingMediaSetting.TVShowRebateSeparately.GetValueOrDefault(False)
			Me.TVShowTaxSeparately = InvoicePrintingMediaSetting.TVShowTaxSeparately.GetValueOrDefault(False)
			Me.TVShowBillingHistory = InvoicePrintingMediaSetting.TVShowBillingHistory.GetValueOrDefault(False)
			Me.TVShowCampaign = InvoicePrintingMediaSetting.TVShowCampaign
			Me.TVShowCampaignComment = InvoicePrintingMediaSetting.TVShowCampaignComment
			Me.TVShowOrderSubtotals = InvoicePrintingMediaSetting.TVShowOrderSubtotals

			Me.TVShowSalesClass = InvoicePrintingMediaSetting.TVShowSalesClass
			Me.TVClientPOLocation = InvoicePrintingMediaSetting.TVClientPOLocation
			Me.TVSalesClassLocation = InvoicePrintingMediaSetting.TVSalesClassLocation
			Me.TVCampaignLocation = InvoicePrintingMediaSetting.TVCampaignLocation
			Me.TVHeaderGroupBy = InvoicePrintingMediaSetting.TVHeaderGroupBy
			Me.TVSortLinesBy = InvoicePrintingMediaSetting.TVSortLinesBy
			Me.TVLineNumberColumn = InvoicePrintingMediaSetting.TVLineNumberColumn
			Me.TVShowZeroLineAmounts = InvoicePrintingMediaSetting.TVShowZeroLineAmounts
			Me.TVCloseDateColumn = InvoicePrintingMediaSetting.TVCloseDateColumn
			Me.TVCustomInvoiceID = InvoicePrintingMediaSetting.TVCustomInvoiceID

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

			InvoicePrintingMediaSetting.TVUseInvoiceCategoryDescription = Me.TVUseInvoiceCategoryDescription
			InvoicePrintingMediaSetting.TVInvoiceTitle = Me.TVInvoiceTitle
			InvoicePrintingMediaSetting.TVGroupByMarket = Me.TVGroupByMarket
			InvoicePrintingMediaSetting.TVShowOrderDescription = Me.TVShowOrderDescription
			InvoicePrintingMediaSetting.TVShowClientReference = Me.TVShowClientReference
			InvoicePrintingMediaSetting.TVShowClientPO = Me.TVShowClientPO
			InvoicePrintingMediaSetting.TVShowOrderComment = Me.TVShowOrderComment
			InvoicePrintingMediaSetting.TVShowOrderHouseComment = Me.TVShowOrderHouseComment
			InvoicePrintingMediaSetting.TVPrintInvoiceDueDate = Me.TVPrintInvoiceDueDate
			InvoicePrintingMediaSetting.TVShowLineDetail = Convert.ToBoolean(Me.TVShowLineDetail)

			InvoicePrintingMediaSetting.TVOrderNumberColumn = Me.TVOrderNumberColumn
			InvoicePrintingMediaSetting.TVVendorNameColumn = Me.TVVendorNameColumn
			InvoicePrintingMediaSetting.TVShowVendorCode = Me.TVShowVendorCode
			InvoicePrintingMediaSetting.TVOrderMonthsColumn = Me.TVOrderMonthsColumn
			InvoicePrintingMediaSetting.TVNetAmountColumn = Me.TVNetAmountColumn
			InvoicePrintingMediaSetting.TVCommissionAmountColumn = Me.TVCommissionAmountColumn
			InvoicePrintingMediaSetting.TVTaxAmountColumn = Me.TVTaxAmountColumn
			InvoicePrintingMediaSetting.TVBillAmountColumn = Me.TVBillAmountColumn
			InvoicePrintingMediaSetting.TVPriorBillAmountColumn = Me.TVPriorBillAmountColumn
			InvoicePrintingMediaSetting.TVBilledToDateAmountColumn = Me.TVBilledToDateAmountColumn
			InvoicePrintingMediaSetting.TVProgramColumn = Me.TVProgramColumn
			InvoicePrintingMediaSetting.TVSpotLengthColumn = Me.TVSpotLengthColumn
			InvoicePrintingMediaSetting.TVTagColumn = Me.TVTagColumn
			InvoicePrintingMediaSetting.TVStartEndTimesColumn = Me.TVStartEndTimesColumn
			InvoicePrintingMediaSetting.TVNumberOfSpotsColumn = Me.TVNumberOfSpotsColumn
			InvoicePrintingMediaSetting.TVRemarksColumn = Me.TVRemarksColumn
			InvoicePrintingMediaSetting.TVJobComponentNumberColumn = Me.TVJobComponentNumberColumn
			InvoicePrintingMediaSetting.TVJobDescriptionColumn = Me.TVJobDescriptionColumn
			InvoicePrintingMediaSetting.TVComponentDescriptionColumn = Me.TVComponentDescriptionColumn
			InvoicePrintingMediaSetting.TVOrderDetailCommentColumn = Me.TVOrderDetailCommentColumn
			InvoicePrintingMediaSetting.TVOrderHouseDetailCommentColumn = Me.TVOrderHouseDetailCommentColumn
			InvoicePrintingMediaSetting.TVExtraChargesColumn = Me.TVExtraChargesColumn
            InvoicePrintingMediaSetting.TVStartDateColumn = Me.TVStartDateColumn

            InvoicePrintingMediaSetting.TVShowCommissionSeparately = Me.TVShowCommissionSeparately
			InvoicePrintingMediaSetting.TVShowRebateSeparately = Me.TVShowRebateSeparately
			InvoicePrintingMediaSetting.TVShowTaxSeparately = Me.TVShowTaxSeparately
			InvoicePrintingMediaSetting.TVShowBillingHistory = Me.TVShowBillingHistory
			InvoicePrintingMediaSetting.TVShowCampaign = Me.TVShowCampaign
			InvoicePrintingMediaSetting.TVShowCampaignComment = Me.TVShowCampaignComment
			InvoicePrintingMediaSetting.TVShowOrderSubtotals = Me.TVShowOrderSubtotals

			InvoicePrintingMediaSetting.TVShowSalesClass = Me.TVShowSalesClass
			InvoicePrintingMediaSetting.TVClientPOLocation = Me.TVClientPOLocation
			InvoicePrintingMediaSetting.TVSalesClassLocation = Me.TVSalesClassLocation
			InvoicePrintingMediaSetting.TVCampaignLocation = Me.TVCampaignLocation
			InvoicePrintingMediaSetting.TVHeaderGroupBy = Me.TVHeaderGroupBy
			InvoicePrintingMediaSetting.TVSortLinesBy = Me.TVSortLinesBy
			InvoicePrintingMediaSetting.TVLineNumberColumn = Me.TVLineNumberColumn
			InvoicePrintingMediaSetting.TVShowZeroLineAmounts = Me.TVShowZeroLineAmounts
			InvoicePrintingMediaSetting.TVCloseDateColumn = Me.TVCloseDateColumn
			InvoicePrintingMediaSetting.TVCustomInvoiceID = Me.TVCustomInvoiceID

		End Sub
		Public Sub Save(ByVal MediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault)

			MediaInvoiceDefault.TVUseInvoiceCategoryDescription = Convert.ToInt16(Me.TVUseInvoiceCategoryDescription)
			MediaInvoiceDefault.TVInvoiceTitle = Me.TVInvoiceTitle
			MediaInvoiceDefault.TVGroupByMarket = Convert.ToInt16(Me.TVGroupByMarket)
			MediaInvoiceDefault.TVShowOrderDescription = Convert.ToInt16(Me.TVShowOrderDescription)
			MediaInvoiceDefault.TVShowClientReference = Convert.ToInt16(Me.TVShowClientReference)
			MediaInvoiceDefault.TVShowClientPO = Convert.ToInt16(Me.TVShowClientPO)
			MediaInvoiceDefault.TVShowOrderComment = Convert.ToInt16(Me.TVShowOrderComment)
			MediaInvoiceDefault.TVShowOrderHouseComment = Convert.ToInt16(Me.TVShowOrderHouseComment)
			MediaInvoiceDefault.TVPrintInvoiceDueDate = Convert.ToInt16(Me.TVPrintInvoiceDueDate)
			MediaInvoiceDefault.TVShowLineDetail = Convert.ToInt16(Me.TVShowLineDetail)

			MediaInvoiceDefault.TVOrderNumberColumn = Me.TVOrderNumberColumn
			MediaInvoiceDefault.TVVendorNameColumn = Me.TVVendorNameColumn
			MediaInvoiceDefault.TVShowVendorCode = Me.TVShowVendorCode
			MediaInvoiceDefault.TVOrderMonthsColumn = Me.TVOrderMonthsColumn
			MediaInvoiceDefault.TVNetAmountColumn = Me.TVNetAmountColumn
			MediaInvoiceDefault.TVCommissionAmountColumn = Me.TVCommissionAmountColumn
			MediaInvoiceDefault.TVTaxAmountColumn = Me.TVTaxAmountColumn
			MediaInvoiceDefault.TVBillAmountColumn = Me.TVBillAmountColumn
			MediaInvoiceDefault.TVPriorBillAmountColumn = Me.TVPriorBillAmountColumn
			MediaInvoiceDefault.TVBilledToDateAmountColumn = Me.TVBilledToDateAmountColumn
			MediaInvoiceDefault.TVProgramColumn = Me.TVProgramColumn
			MediaInvoiceDefault.TVSpotLengthColumn = Me.TVSpotLengthColumn
			MediaInvoiceDefault.TVTagColumn = Me.TVTagColumn
			MediaInvoiceDefault.TVStartEndTimesColumn = Me.TVStartEndTimesColumn
			MediaInvoiceDefault.TVNumberOfSpotsColumn = Me.TVNumberOfSpotsColumn
			MediaInvoiceDefault.TVRemarksColumn = Me.TVRemarksColumn
			MediaInvoiceDefault.TVJobComponentNumberColumn = Me.TVJobComponentNumberColumn
			MediaInvoiceDefault.TVJobDescriptionColumn = Me.TVJobDescriptionColumn
			MediaInvoiceDefault.TVComponentDescriptionColumn = Me.TVComponentDescriptionColumn
			MediaInvoiceDefault.TVOrderDetailCommentColumn = Me.TVOrderDetailCommentColumn
			MediaInvoiceDefault.TVOrderHouseDetailCommentColumn = Me.TVOrderHouseDetailCommentColumn
			MediaInvoiceDefault.TVExtraChargesColumn = Me.TVExtraChargesColumn
            MediaInvoiceDefault.TVStartDateColumn = Me.TVStartDateColumn

            MediaInvoiceDefault.TVShowCommissionSeparately = Convert.ToInt16(Me.TVShowCommissionSeparately)
			MediaInvoiceDefault.TVShowRebateSeparately = Convert.ToInt16(Me.TVShowRebateSeparately)
			MediaInvoiceDefault.TVShowTaxSeparately = Convert.ToInt16(Me.TVShowTaxSeparately)
			MediaInvoiceDefault.TVShowBillingHistory = Convert.ToInt16(Me.TVShowBillingHistory)
			MediaInvoiceDefault.TVShowCampaign = Me.TVShowCampaign
			MediaInvoiceDefault.TVShowCampaignComment = Me.TVShowCampaignComment
			MediaInvoiceDefault.TVShowOrderSubtotals = Me.TVShowOrderSubtotals

			MediaInvoiceDefault.TVShowSalesClass = Me.TVShowSalesClass
			MediaInvoiceDefault.TVClientPOLocation = Me.TVClientPOLocation
			MediaInvoiceDefault.TVSalesClassLocation = Me.TVSalesClassLocation
			MediaInvoiceDefault.TVCampaignLocation = Me.TVCampaignLocation
			MediaInvoiceDefault.TVHeaderGroupBy = Me.TVHeaderGroupBy
			MediaInvoiceDefault.TVSortLinesBy = Me.TVSortLinesBy
			MediaInvoiceDefault.TVLineNumberColumn = Me.TVLineNumberColumn
			MediaInvoiceDefault.TVShowZeroLineAmounts = Me.TVShowZeroLineAmounts
			MediaInvoiceDefault.TVCloseDateColumn = Me.TVCloseDateColumn
			MediaInvoiceDefault.TVCustomInvoiceID = Me.TVCustomInvoiceID

		End Sub
        Public Overrides Function ToString() As String

            ToString = ""

        End Function

#End Region

    End Class

End Namespace
