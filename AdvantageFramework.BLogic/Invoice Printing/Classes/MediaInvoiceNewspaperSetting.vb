Namespace InvoicePrinting.Classes

    <Serializable()>
    Public Class MediaInvoiceNewspaperSetting

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            NewspaperUseInvoiceCategoryDescription
            NewspaperInvoiceTitle
            NewspaperGroupByMarket
            NewspaperShowOrderDescription
            NewspaperShowClientReference
            NewspaperShowClientPO
            NewspaperShowOrderComment
            NewspaperShowOrderHouseComment
            NewspaperPrintInvoiceDueDate
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
            NewspaperCustomFormatName
            NewspaperShowCampaign
            NewspaperShowCampaignComment
            NewspaperShowOrderSubtotals
            NewspaperShowSalesClass
            NewspaperClientPOLocation
            NewspaperSalesClassLocation
            NewspaperCampaignLocation
            NewspaperHeaderGroupBy
            NewspaperSortLinesBy
            NewspaperLineNumberColumn
            NewspaperShowZeroLineAmounts
			NewspaperCloseDateColumn
			NewspaperCustomInvoiceID
		End Enum

#End Region

#Region " Variables "

		Private _NewspaperUseInvoiceCategoryDescription As Boolean = False
		Private _NewspaperInvoiceTitle As String = Nothing
		Private _NewspaperGroupByMarket As Boolean = False
		Private _NewspaperShowOrderDescription As Boolean = False
		Private _NewspaperShowClientReference As Boolean = False
		Private _NewspaperShowClientPO As Boolean = False
		Private _NewspaperShowOrderComment As Boolean = False
		Private _NewspaperShowOrderHouseComment As Boolean = False
		Private _NewspaperPrintInvoiceDueDate As Boolean = False
		Private _NewspaperShowLineDetail As Integer = 1
		Private _NewspaperOrderNumberColumn As Short = 1
		Private _NewspaperVendorNameColumn As Short = 0
		Private _NewspaperShowVendorCode As Short = 0
		Private _NewspaperOrderMonthsColumn As Short = 0
		Private _NewspaperHeadlineColumn As Short = 0
		Private _NewspaperInsertDatesColumn As Short = 0
		Private _NewspaperMaterialColumn As Short = 0
		Private _NewspaperAdNumberColumn As Short = 0
		Private _NewspaperEditorialIssueColumn As Short = 0
		Private _NewspaperSectionColumn As Short = 0
		Private _NewspaperQuantityColumn As Short = 0
		Private _NewspaperAdSizeColumn As Short = 0
		Private _NewspaperJobComponentNumberColumn As Short = 0
		Private _NewspaperJobDescriptionColumn As Short = 0
		Private _NewspaperComponentDescriptionColumn As Short = 0
		Private _NewspaperOrderDetailCommentColumn As Short = 0
		Private _NewspaperOrderHouseDetailCommentColumn As Short = 0
		Private _NewspaperExtraChargesColumn As Short = 0
		Private _NewspaperNetAmountColumn As Short = 0
		Private _NewspaperCommissionAmountColumn As Short = 0
		Private _NewspaperTaxAmountColumn As Short = 0
		Private _NewspaperBillAmountColumn As Short = 0
		Private _NewspaperPriorBillAmountColumn As Short = 0
		Private _NewspaperBilledToDateAmountColumn As Short = 0
		Private _NewspaperShowCommissionSeparately As Boolean = False
		Private _NewspaperShowRebateSeparately As Boolean = False
		Private _NewspaperShowTaxSeparately As Boolean = False
		Private _NewspaperShowBillingHistory As Boolean = False
		Private _NewspaperCustomFormatName As String = Nothing
		Private _NewspaperShowCampaign As Boolean = False
		Private _NewspaperShowCampaignComment As Boolean = False
		Private _NewspaperShowOrderSubtotals As Boolean = False
		Private _NewspaperShowSalesClass As Boolean = False
		Private _NewspaperClientPOLocation As Integer = 1
		Private _NewspaperSalesClassLocation As Integer = 1
		Private _NewspaperCampaignLocation As Integer = 1
		Private _NewspaperHeaderGroupBy As Integer = Nothing
		Private _NewspaperSortLinesBy As Integer = 1
		Private _NewspaperLineNumberColumn As Short = 0
		Private _NewspaperShowZeroLineAmounts As Boolean = False
		Private _NewspaperCloseDateColumn As Short = 0
		Private _NewspaperCustomInvoiceID As Nullable(Of Integer) = Nothing

		Private _MediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault = Nothing
		Private _InvoicePrintingMediaSetting As InvoicePrintingMediaSetting = Nothing

#End Region

#Region " Properties "

		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property NewspaperUseInvoiceCategoryDescription As Boolean
			Get
				NewspaperUseInvoiceCategoryDescription = _NewspaperUseInvoiceCategoryDescription
			End Get
			Set(ByVal value As Boolean)
				_NewspaperUseInvoiceCategoryDescription = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property NewspaperInvoiceTitle As String
			Get
				NewspaperInvoiceTitle = _NewspaperInvoiceTitle
			End Get
			Set(ByVal value As String)
				_NewspaperInvoiceTitle = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property NewspaperGroupByMarket As Boolean
			Get
				NewspaperGroupByMarket = _NewspaperGroupByMarket
			End Get
			Set(ByVal value As Boolean)
				_NewspaperGroupByMarket = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property NewspaperShowOrderDescription As Boolean
			Get
				NewspaperShowOrderDescription = _NewspaperShowOrderDescription
			End Get
			Set(ByVal value As Boolean)
				_NewspaperShowOrderDescription = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property NewspaperShowClientReference As Boolean
			Get
				NewspaperShowClientReference = _NewspaperShowClientReference
			End Get
			Set(ByVal value As Boolean)
				_NewspaperShowClientReference = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property NewspaperShowClientPO As Boolean
			Get
				NewspaperShowClientPO = _NewspaperShowClientPO
			End Get
			Set(ByVal value As Boolean)
				_NewspaperShowClientPO = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property NewspaperShowOrderComment As Boolean
			Get
				NewspaperShowOrderComment = _NewspaperShowOrderComment
			End Get
			Set(ByVal value As Boolean)
				_NewspaperShowOrderComment = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property NewspaperShowOrderHouseComment As Boolean
			Get
				NewspaperShowOrderHouseComment = _NewspaperShowOrderHouseComment
			End Get
			Set(ByVal value As Boolean)
				_NewspaperShowOrderHouseComment = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property NewspaperPrintInvoiceDueDate As Boolean
			Get
				NewspaperPrintInvoiceDueDate = _NewspaperPrintInvoiceDueDate
			End Get
			Set(ByVal value As Boolean)
				_NewspaperPrintInvoiceDueDate = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property NewspaperShowLineDetail As Integer
			Get
				NewspaperShowLineDetail = _NewspaperShowLineDetail
			End Get
			Set(ByVal value As Integer)
				_NewspaperShowLineDetail = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property NewspaperOrderNumberColumn As Short
			Get
				NewspaperOrderNumberColumn = _NewspaperOrderNumberColumn
			End Get
			Set(ByVal value As Short)
				_NewspaperOrderNumberColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property NewspaperVendorNameColumn As Short
			Get
				NewspaperVendorNameColumn = _NewspaperVendorNameColumn
			End Get
			Set(ByVal value As Short)
				_NewspaperVendorNameColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property NewspaperShowVendorCode As Short
			Get
				NewspaperShowVendorCode = _NewspaperShowVendorCode
			End Get
			Set(ByVal value As Short)
				_NewspaperShowVendorCode = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property NewspaperOrderMonthsColumn As Short
			Get
				NewspaperOrderMonthsColumn = _NewspaperOrderMonthsColumn
			End Get
			Set(ByVal value As Short)
				_NewspaperOrderMonthsColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property NewspaperHeadlineColumn As Short
			Get
				NewspaperHeadlineColumn = _NewspaperHeadlineColumn
			End Get
			Set(ByVal value As Short)
				_NewspaperHeadlineColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property NewspaperInsertDatesColumn As Short
			Get
				NewspaperInsertDatesColumn = _NewspaperInsertDatesColumn
			End Get
			Set(ByVal value As Short)
				_NewspaperInsertDatesColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property NewspaperMaterialColumn As Short
			Get
				NewspaperMaterialColumn = _NewspaperMaterialColumn
			End Get
			Set(ByVal value As Short)
				_NewspaperMaterialColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property NewspaperAdNumberColumn As Short
			Get
				NewspaperAdNumberColumn = _NewspaperAdNumberColumn
			End Get
			Set(ByVal value As Short)
				_NewspaperAdNumberColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property NewspaperEditorialIssueColumn As Short
			Get
				NewspaperEditorialIssueColumn = _NewspaperEditorialIssueColumn
			End Get
			Set(ByVal value As Short)
				_NewspaperEditorialIssueColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property NewspaperSectionColumn As Short
			Get
				NewspaperSectionColumn = _NewspaperSectionColumn
			End Get
			Set(ByVal value As Short)
				_NewspaperSectionColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property NewspaperQuantityColumn As Short
			Get
				NewspaperQuantityColumn = _NewspaperQuantityColumn
			End Get
			Set(ByVal value As Short)
				_NewspaperQuantityColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property NewspaperAdSizeColumn As Short
			Get
				NewspaperAdSizeColumn = _NewspaperAdSizeColumn
			End Get
			Set(ByVal value As Short)
				_NewspaperAdSizeColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property NewspaperJobComponentNumberColumn As Short
			Get
				NewspaperJobComponentNumberColumn = _NewspaperJobComponentNumberColumn
			End Get
			Set(ByVal value As Short)
				_NewspaperJobComponentNumberColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property NewspaperJobDescriptionColumn As Short
			Get
				NewspaperJobDescriptionColumn = _NewspaperJobDescriptionColumn
			End Get
			Set(ByVal value As Short)
				_NewspaperJobDescriptionColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property NewspaperComponentDescriptionColumn As Short
			Get
				NewspaperComponentDescriptionColumn = _NewspaperComponentDescriptionColumn
			End Get
			Set(ByVal value As Short)
				_NewspaperComponentDescriptionColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property NewspaperOrderDetailCommentColumn As Short
			Get
				NewspaperOrderDetailCommentColumn = _NewspaperOrderDetailCommentColumn
			End Get
			Set(ByVal value As Short)
				_NewspaperOrderDetailCommentColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property NewspaperOrderHouseDetailCommentColumn As Short
			Get
				NewspaperOrderHouseDetailCommentColumn = _NewspaperOrderHouseDetailCommentColumn
			End Get
			Set(ByVal value As Short)
				_NewspaperOrderHouseDetailCommentColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property NewspaperExtraChargesColumn As Short
			Get
				NewspaperExtraChargesColumn = _NewspaperExtraChargesColumn
			End Get
			Set(ByVal value As Short)
				_NewspaperExtraChargesColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property NewspaperNetAmountColumn As Short
			Get
				NewspaperNetAmountColumn = _NewspaperNetAmountColumn
			End Get
			Set(ByVal value As Short)
				_NewspaperNetAmountColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property NewspaperCommissionAmountColumn As Short
			Get
				NewspaperCommissionAmountColumn = _NewspaperCommissionAmountColumn
			End Get
			Set(ByVal value As Short)
				_NewspaperCommissionAmountColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property NewspaperTaxAmountColumn As Short
			Get
				NewspaperTaxAmountColumn = _NewspaperTaxAmountColumn
			End Get
			Set(ByVal value As Short)
				_NewspaperTaxAmountColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property NewspaperBillAmountColumn As Short
			Get
				NewspaperBillAmountColumn = _NewspaperBillAmountColumn
			End Get
			Set(ByVal value As Short)
				_NewspaperBillAmountColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property NewspaperPriorBillAmountColumn As Short
			Get
				NewspaperPriorBillAmountColumn = _NewspaperPriorBillAmountColumn
			End Get
			Set(ByVal value As Short)
				_NewspaperPriorBillAmountColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property NewspaperBilledToDateAmountColumn As Short
			Get
				NewspaperBilledToDateAmountColumn = _NewspaperBilledToDateAmountColumn
			End Get
			Set(ByVal value As Short)
				_NewspaperBilledToDateAmountColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property NewspaperShowCommissionSeparately As Boolean
			Get
				NewspaperShowCommissionSeparately = _NewspaperShowCommissionSeparately
			End Get
			Set(ByVal value As Boolean)
				_NewspaperShowCommissionSeparately = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property NewspaperShowRebateSeparately As Boolean
			Get
				NewspaperShowRebateSeparately = _NewspaperShowRebateSeparately
			End Get
			Set(ByVal value As Boolean)
				_NewspaperShowRebateSeparately = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property NewspaperShowTaxSeparately As Boolean
			Get
				NewspaperShowTaxSeparately = _NewspaperShowTaxSeparately
			End Get
			Set(ByVal value As Boolean)
				_NewspaperShowTaxSeparately = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property NewspaperShowBillingHistory As Boolean
			Get
				NewspaperShowBillingHistory = _NewspaperShowBillingHistory
			End Get
			Set(ByVal value As Boolean)
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
		Public Property NewspaperShowCampaign() As Boolean
			Get
				NewspaperShowCampaign = _NewspaperShowCampaign
			End Get
			Set(ByVal value As Boolean)
				_NewspaperShowCampaign = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property NewspaperShowCampaignComment() As Boolean
			Get
				NewspaperShowCampaignComment = _NewspaperShowCampaignComment
			End Get
			Set(ByVal value As Boolean)
				_NewspaperShowCampaignComment = value
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
		Public Property NewspaperShowSalesClass() As Boolean
			Get
				NewspaperShowSalesClass = _NewspaperShowSalesClass
			End Get
			Set(value As Boolean)
				_NewspaperShowSalesClass = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property NewspaperClientPOLocation() As Integer
			Get
				NewspaperClientPOLocation = _NewspaperClientPOLocation
			End Get
			Set(value As Integer)
				_NewspaperClientPOLocation = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property NewspaperSalesClassLocation() As Integer
			Get
				NewspaperSalesClassLocation = _NewspaperSalesClassLocation
			End Get
			Set(value As Integer)
				_NewspaperSalesClassLocation = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property NewspaperCampaignLocation() As Integer
			Get
				NewspaperCampaignLocation = _NewspaperCampaignLocation
			End Get
			Set(value As Integer)
				_NewspaperCampaignLocation = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property NewspaperHeaderGroupBy() As Integer
			Get
				NewspaperHeaderGroupBy = _NewspaperHeaderGroupBy
			End Get
			Set(value As Integer)
				_NewspaperHeaderGroupBy = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property NewspaperSortLinesBy() As Integer
			Get
				NewspaperSortLinesBy = _NewspaperSortLinesBy
			End Get
			Set(value As Integer)
				_NewspaperSortLinesBy = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property NewspaperLineNumberColumn() As Short
			Get
				NewspaperLineNumberColumn = _NewspaperLineNumberColumn
			End Get
			Set(value As Short)
				_NewspaperLineNumberColumn = value
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
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property NewspaperCloseDateColumn() As Short
			Get
				NewspaperCloseDateColumn = _NewspaperCloseDateColumn
			End Get
			Set(value As Short)
				_NewspaperCloseDateColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.DisplayName("Custom Invoice")>
		Public Property NewspaperCustomInvoiceID() As Nullable(Of Integer)
			Get
				NewspaperCustomInvoiceID = _NewspaperCustomInvoiceID
			End Get
			Set(ByVal value As Nullable(Of Integer))
				_NewspaperCustomInvoiceID = value
			End Set
		End Property

#End Region

#Region " Methods "

		Public Sub New()



		End Sub
		Public Sub New(ByVal MediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault)

			Me.NewspaperUseInvoiceCategoryDescription = Convert.ToBoolean(MediaInvoiceDefault.NewspaperUseInvoiceCategoryDescription.GetValueOrDefault(0))
			Me.NewspaperInvoiceTitle = MediaInvoiceDefault.NewspaperInvoiceTitle
			Me.NewspaperGroupByMarket = Convert.ToBoolean(MediaInvoiceDefault.NewspaperGroupByMarket.GetValueOrDefault(0))
			Me.NewspaperShowOrderDescription = Convert.ToBoolean(MediaInvoiceDefault.NewspaperShowOrderDescription.GetValueOrDefault(0))
			Me.NewspaperShowClientReference = Convert.ToBoolean(MediaInvoiceDefault.NewspaperShowClientReference.GetValueOrDefault(0))
			Me.NewspaperShowClientPO = Convert.ToBoolean(MediaInvoiceDefault.NewspaperShowClientPO.GetValueOrDefault(0))
			Me.NewspaperShowOrderComment = Convert.ToBoolean(MediaInvoiceDefault.NewspaperShowOrderComment.GetValueOrDefault(0))
			Me.NewspaperShowOrderHouseComment = Convert.ToBoolean(MediaInvoiceDefault.NewspaperShowOrderHouseComment.GetValueOrDefault(0))
			Me.NewspaperPrintInvoiceDueDate = Convert.ToBoolean(MediaInvoiceDefault.NewspaperPrintInvoiceDueDate.GetValueOrDefault(0))
			Me.NewspaperShowLineDetail = Convert.ToInt32(MediaInvoiceDefault.NewspaperShowLineDetail.GetValueOrDefault(0))

			Me.NewspaperOrderNumberColumn = MediaInvoiceDefault.NewspaperOrderNumberColumn.GetValueOrDefault(1)
			Me.NewspaperVendorNameColumn = MediaInvoiceDefault.NewspaperVendorNameColumn.GetValueOrDefault(2)
			Me.NewspaperShowVendorCode = MediaInvoiceDefault.NewspaperShowVendorCode.GetValueOrDefault(0)
			Me.NewspaperOrderMonthsColumn = MediaInvoiceDefault.NewspaperOrderMonthsColumn.GetValueOrDefault(0)
			Me.NewspaperNetAmountColumn = MediaInvoiceDefault.NewspaperNetAmountColumn.GetValueOrDefault(0)
			Me.NewspaperCommissionAmountColumn = MediaInvoiceDefault.NewspaperCommissionAmountColumn.GetValueOrDefault(0)
			Me.NewspaperTaxAmountColumn = MediaInvoiceDefault.NewspaperTaxAmountColumn.GetValueOrDefault(0)
			Me.NewspaperBillAmountColumn = MediaInvoiceDefault.NewspaperBillAmountColumn.GetValueOrDefault(0)
			Me.NewspaperPriorBillAmountColumn = MediaInvoiceDefault.NewspaperPriorBillAmountColumn.GetValueOrDefault(0)
			Me.NewspaperBilledToDateAmountColumn = MediaInvoiceDefault.NewspaperBilledToDateAmountColumn.GetValueOrDefault(0)
			Me.NewspaperHeadlineColumn = MediaInvoiceDefault.NewspaperHeadlineColumn.GetValueOrDefault(0)
			Me.NewspaperInsertDatesColumn = MediaInvoiceDefault.NewspaperInsertDatesColumn.GetValueOrDefault(0)
			Me.NewspaperMaterialColumn = MediaInvoiceDefault.NewspaperMaterialColumn.GetValueOrDefault(0)
			Me.NewspaperAdNumberColumn = MediaInvoiceDefault.NewspaperAdNumberColumn.GetValueOrDefault(0)
			Me.NewspaperEditorialIssueColumn = MediaInvoiceDefault.NewspaperEditorialIssueColumn.GetValueOrDefault(0)
			Me.NewspaperSectionColumn = MediaInvoiceDefault.NewspaperSectionColumn.GetValueOrDefault(0)
			Me.NewspaperQuantityColumn = MediaInvoiceDefault.NewspaperQuantityColumn.GetValueOrDefault(0)
			Me.NewspaperAdSizeColumn = MediaInvoiceDefault.NewspaperAdSizeColumn.GetValueOrDefault(0)
			Me.NewspaperJobComponentNumberColumn = MediaInvoiceDefault.NewspaperJobComponentNumberColumn.GetValueOrDefault(0)
			Me.NewspaperJobDescriptionColumn = MediaInvoiceDefault.NewspaperJobDescriptionColumn.GetValueOrDefault(0)
			Me.NewspaperComponentDescriptionColumn = MediaInvoiceDefault.NewspaperComponentDescriptionColumn.GetValueOrDefault(0)
			Me.NewspaperOrderDetailCommentColumn = MediaInvoiceDefault.NewspaperOrderDetailCommentColumn.GetValueOrDefault(0)
			Me.NewspaperOrderHouseDetailCommentColumn = MediaInvoiceDefault.NewspaperOrderHouseDetailCommentColumn.GetValueOrDefault(0)
			Me.NewspaperExtraChargesColumn = MediaInvoiceDefault.NewspaperExtraChargesColumn.GetValueOrDefault(0)

			Me.NewspaperShowCommissionSeparately = Convert.ToBoolean(MediaInvoiceDefault.NewspaperShowCommissionSeparately.GetValueOrDefault(0))
			Me.NewspaperShowRebateSeparately = Convert.ToBoolean(MediaInvoiceDefault.NewspaperShowRebateSeparately.GetValueOrDefault(0))
			Me.NewspaperShowTaxSeparately = Convert.ToBoolean(MediaInvoiceDefault.NewspaperShowTaxSeparately.GetValueOrDefault(0))
			Me.NewspaperShowBillingHistory = Convert.ToBoolean(MediaInvoiceDefault.NewspaperShowBillingHistory.GetValueOrDefault(0))
			Me.NewspaperShowCampaign = MediaInvoiceDefault.NewspaperShowCampaign
			Me.NewspaperShowCampaignComment = MediaInvoiceDefault.NewspaperShowCampaignComment
			Me.NewspaperShowOrderSubtotals = MediaInvoiceDefault.NewspaperShowOrderSubtotals

			Me.NewspaperShowSalesClass = MediaInvoiceDefault.NewspaperShowSalesClass
			Me.NewspaperClientPOLocation = MediaInvoiceDefault.NewspaperClientPOLocation
			Me.NewspaperSalesClassLocation = MediaInvoiceDefault.NewspaperSalesClassLocation
			Me.NewspaperCampaignLocation = MediaInvoiceDefault.NewspaperCampaignLocation
			Me.NewspaperHeaderGroupBy = MediaInvoiceDefault.NewspaperHeaderGroupBy
			Me.NewspaperSortLinesBy = MediaInvoiceDefault.NewspaperSortLinesBy
			Me.NewspaperLineNumberColumn = MediaInvoiceDefault.NewspaperLineNumberColumn
			Me.NewspaperShowZeroLineAmounts = MediaInvoiceDefault.NewspaperShowZeroLineAmounts
			Me.NewspaperCloseDateColumn = MediaInvoiceDefault.NewspaperCloseDateColumn
			Me.NewspaperCustomInvoiceID = MediaInvoiceDefault.NewspaperCustomInvoiceID

			_MediaInvoiceDefault = MediaInvoiceDefault

		End Sub
		Public Sub New(ByVal InvoicePrintingMediaSetting As InvoicePrintingMediaSetting)

			Me.NewspaperUseInvoiceCategoryDescription = InvoicePrintingMediaSetting.NewspaperUseInvoiceCategoryDescription.GetValueOrDefault(False)
			Me.NewspaperInvoiceTitle = InvoicePrintingMediaSetting.NewspaperInvoiceTitle
			Me.NewspaperGroupByMarket = InvoicePrintingMediaSetting.NewspaperGroupByMarket.GetValueOrDefault(False)
			Me.NewspaperShowOrderDescription = InvoicePrintingMediaSetting.NewspaperShowOrderDescription.GetValueOrDefault(False)
			Me.NewspaperShowClientReference = InvoicePrintingMediaSetting.NewspaperShowClientReference.GetValueOrDefault(False)
			Me.NewspaperShowClientPO = InvoicePrintingMediaSetting.NewspaperShowClientPO.GetValueOrDefault(False)
			Me.NewspaperShowOrderComment = InvoicePrintingMediaSetting.NewspaperShowOrderComment.GetValueOrDefault(False)
			Me.NewspaperShowOrderHouseComment = InvoicePrintingMediaSetting.NewspaperShowOrderHouseComment.GetValueOrDefault(False)
			Me.NewspaperPrintInvoiceDueDate = InvoicePrintingMediaSetting.NewspaperPrintInvoiceDueDate.GetValueOrDefault(False)
			Me.NewspaperShowLineDetail = If(InvoicePrintingMediaSetting.NewspaperShowLineDetail.GetValueOrDefault(False) = True, 1, 0)

			Me.NewspaperOrderNumberColumn = InvoicePrintingMediaSetting.NewspaperOrderNumberColumn.GetValueOrDefault(1)
			Me.NewspaperVendorNameColumn = InvoicePrintingMediaSetting.NewspaperVendorNameColumn.GetValueOrDefault(2)
			Me.NewspaperShowVendorCode = InvoicePrintingMediaSetting.NewspaperShowVendorCode.GetValueOrDefault(0)
			Me.NewspaperOrderMonthsColumn = InvoicePrintingMediaSetting.NewspaperOrderMonthsColumn.GetValueOrDefault(0)
			Me.NewspaperNetAmountColumn = InvoicePrintingMediaSetting.NewspaperNetAmountColumn.GetValueOrDefault(0)
			Me.NewspaperCommissionAmountColumn = InvoicePrintingMediaSetting.NewspaperCommissionAmountColumn.GetValueOrDefault(0)
			Me.NewspaperTaxAmountColumn = InvoicePrintingMediaSetting.NewspaperTaxAmountColumn.GetValueOrDefault(0)
			Me.NewspaperBillAmountColumn = InvoicePrintingMediaSetting.NewspaperBillAmountColumn.GetValueOrDefault(0)
			Me.NewspaperPriorBillAmountColumn = InvoicePrintingMediaSetting.NewspaperPriorBillAmountColumn.GetValueOrDefault(0)
			Me.NewspaperBilledToDateAmountColumn = InvoicePrintingMediaSetting.NewspaperBilledToDateAmountColumn.GetValueOrDefault(0)
			Me.NewspaperHeadlineColumn = InvoicePrintingMediaSetting.NewspaperHeadlineColumn.GetValueOrDefault(0)
			Me.NewspaperInsertDatesColumn = InvoicePrintingMediaSetting.NewspaperInsertDatesColumn.GetValueOrDefault(0)
			Me.NewspaperMaterialColumn = InvoicePrintingMediaSetting.NewspaperMaterialColumn.GetValueOrDefault(0)
			Me.NewspaperAdNumberColumn = InvoicePrintingMediaSetting.NewspaperAdNumberColumn.GetValueOrDefault(0)
			Me.NewspaperEditorialIssueColumn = InvoicePrintingMediaSetting.NewspaperEditorialIssueColumn.GetValueOrDefault(0)
			Me.NewspaperSectionColumn = InvoicePrintingMediaSetting.NewspaperSectionColumn.GetValueOrDefault(0)
			Me.NewspaperQuantityColumn = InvoicePrintingMediaSetting.NewspaperQuantityColumn.GetValueOrDefault(0)
			Me.NewspaperAdSizeColumn = InvoicePrintingMediaSetting.NewspaperAdSizeColumn.GetValueOrDefault(0)
			Me.NewspaperJobComponentNumberColumn = InvoicePrintingMediaSetting.NewspaperJobComponentNumberColumn.GetValueOrDefault(0)
			Me.NewspaperJobDescriptionColumn = InvoicePrintingMediaSetting.NewspaperJobDescriptionColumn.GetValueOrDefault(0)
			Me.NewspaperComponentDescriptionColumn = InvoicePrintingMediaSetting.NewspaperComponentDescriptionColumn.GetValueOrDefault(0)
			Me.NewspaperOrderDetailCommentColumn = InvoicePrintingMediaSetting.NewspaperOrderDetailCommentColumn.GetValueOrDefault(0)
			Me.NewspaperOrderHouseDetailCommentColumn = InvoicePrintingMediaSetting.NewspaperOrderHouseDetailCommentColumn.GetValueOrDefault(0)
			Me.NewspaperExtraChargesColumn = InvoicePrintingMediaSetting.NewspaperExtraChargesColumn.GetValueOrDefault(0)

			Me.NewspaperShowCommissionSeparately = InvoicePrintingMediaSetting.NewspaperShowCommissionSeparately.GetValueOrDefault(False)
			Me.NewspaperShowRebateSeparately = InvoicePrintingMediaSetting.NewspaperShowRebateSeparately.GetValueOrDefault(False)
			Me.NewspaperShowTaxSeparately = InvoicePrintingMediaSetting.NewspaperShowTaxSeparately.GetValueOrDefault(False)
			Me.NewspaperShowBillingHistory = InvoicePrintingMediaSetting.NewspaperShowBillingHistory.GetValueOrDefault(False)
			Me.NewspaperShowCampaign = InvoicePrintingMediaSetting.NewspaperShowCampaign
			Me.NewspaperShowCampaignComment = InvoicePrintingMediaSetting.NewspaperShowCampaignComment
			Me.NewspaperShowOrderSubtotals = InvoicePrintingMediaSetting.NewspaperShowOrderSubtotals

			Me.NewspaperShowSalesClass = InvoicePrintingMediaSetting.NewspaperShowSalesClass
			Me.NewspaperClientPOLocation = InvoicePrintingMediaSetting.NewspaperClientPOLocation
			Me.NewspaperSalesClassLocation = InvoicePrintingMediaSetting.NewspaperSalesClassLocation
			Me.NewspaperCampaignLocation = InvoicePrintingMediaSetting.NewspaperCampaignLocation
			Me.NewspaperHeaderGroupBy = InvoicePrintingMediaSetting.NewspaperHeaderGroupBy
			Me.NewspaperSortLinesBy = InvoicePrintingMediaSetting.NewspaperSortLinesBy
			Me.NewspaperLineNumberColumn = InvoicePrintingMediaSetting.NewspaperLineNumberColumn
			Me.NewspaperShowZeroLineAmounts = InvoicePrintingMediaSetting.NewspaperShowZeroLineAmounts
			Me.NewspaperCloseDateColumn = InvoicePrintingMediaSetting.NewspaperCloseDateColumn
			Me.NewspaperCustomInvoiceID = InvoicePrintingMediaSetting.NewspaperCustomInvoiceID

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

			InvoicePrintingMediaSetting.NewspaperUseInvoiceCategoryDescription = Me.NewspaperUseInvoiceCategoryDescription
			InvoicePrintingMediaSetting.NewspaperInvoiceTitle = Me.NewspaperInvoiceTitle
			InvoicePrintingMediaSetting.NewspaperGroupByMarket = Me.NewspaperGroupByMarket
			InvoicePrintingMediaSetting.NewspaperShowOrderDescription = Me.NewspaperShowOrderDescription
			InvoicePrintingMediaSetting.NewspaperShowClientReference = Me.NewspaperShowClientReference
			InvoicePrintingMediaSetting.NewspaperShowClientPO = Me.NewspaperShowClientPO
			InvoicePrintingMediaSetting.NewspaperShowOrderComment = Me.NewspaperShowOrderComment
			InvoicePrintingMediaSetting.NewspaperShowOrderHouseComment = Me.NewspaperShowOrderHouseComment
			InvoicePrintingMediaSetting.NewspaperPrintInvoiceDueDate = Me.NewspaperPrintInvoiceDueDate
			InvoicePrintingMediaSetting.NewspaperShowLineDetail = Convert.ToBoolean(Me.NewspaperShowLineDetail)

			InvoicePrintingMediaSetting.NewspaperOrderNumberColumn = Me.NewspaperOrderNumberColumn
			InvoicePrintingMediaSetting.NewspaperVendorNameColumn = Me.NewspaperVendorNameColumn
			InvoicePrintingMediaSetting.NewspaperShowVendorCode = Me.NewspaperShowVendorCode
			InvoicePrintingMediaSetting.NewspaperOrderMonthsColumn = Me.NewspaperOrderMonthsColumn
			InvoicePrintingMediaSetting.NewspaperNetAmountColumn = Me.NewspaperNetAmountColumn
			InvoicePrintingMediaSetting.NewspaperCommissionAmountColumn = Me.NewspaperCommissionAmountColumn
			InvoicePrintingMediaSetting.NewspaperTaxAmountColumn = Me.NewspaperTaxAmountColumn
			InvoicePrintingMediaSetting.NewspaperBillAmountColumn = Me.NewspaperBillAmountColumn
			InvoicePrintingMediaSetting.NewspaperPriorBillAmountColumn = Me.NewspaperPriorBillAmountColumn
			InvoicePrintingMediaSetting.NewspaperBilledToDateAmountColumn = Me.NewspaperBilledToDateAmountColumn
			InvoicePrintingMediaSetting.NewspaperHeadlineColumn = Me.NewspaperHeadlineColumn
			InvoicePrintingMediaSetting.NewspaperInsertDatesColumn = Me.NewspaperInsertDatesColumn
			InvoicePrintingMediaSetting.NewspaperMaterialColumn = Me.NewspaperMaterialColumn
			InvoicePrintingMediaSetting.NewspaperAdNumberColumn = Me.NewspaperAdNumberColumn
			InvoicePrintingMediaSetting.NewspaperEditorialIssueColumn = Me.NewspaperEditorialIssueColumn
			InvoicePrintingMediaSetting.NewspaperSectionColumn = Me.NewspaperSectionColumn
			InvoicePrintingMediaSetting.NewspaperQuantityColumn = Me.NewspaperQuantityColumn
			InvoicePrintingMediaSetting.NewspaperAdSizeColumn = Me.NewspaperAdSizeColumn
			InvoicePrintingMediaSetting.NewspaperJobComponentNumberColumn = Me.NewspaperJobComponentNumberColumn
			InvoicePrintingMediaSetting.NewspaperJobDescriptionColumn = Me.NewspaperJobDescriptionColumn
			InvoicePrintingMediaSetting.NewspaperComponentDescriptionColumn = Me.NewspaperComponentDescriptionColumn
			InvoicePrintingMediaSetting.NewspaperOrderDetailCommentColumn = Me.NewspaperOrderDetailCommentColumn
			InvoicePrintingMediaSetting.NewspaperOrderHouseDetailCommentColumn = Me.NewspaperOrderHouseDetailCommentColumn
			InvoicePrintingMediaSetting.NewspaperExtraChargesColumn = Me.NewspaperExtraChargesColumn

			InvoicePrintingMediaSetting.NewspaperShowCommissionSeparately = Me.NewspaperShowCommissionSeparately
			InvoicePrintingMediaSetting.NewspaperShowRebateSeparately = Me.NewspaperShowRebateSeparately
			InvoicePrintingMediaSetting.NewspaperShowTaxSeparately = Me.NewspaperShowTaxSeparately
			InvoicePrintingMediaSetting.NewspaperShowBillingHistory = Me.NewspaperShowBillingHistory
			InvoicePrintingMediaSetting.NewspaperShowCampaign = Me.NewspaperShowCampaign
			InvoicePrintingMediaSetting.NewspaperShowCampaignComment = Me.NewspaperShowCampaignComment
			InvoicePrintingMediaSetting.NewspaperShowOrderSubtotals = Me.NewspaperShowOrderSubtotals

			InvoicePrintingMediaSetting.NewspaperShowSalesClass = Me.NewspaperShowSalesClass
			InvoicePrintingMediaSetting.NewspaperClientPOLocation = Me.NewspaperClientPOLocation
			InvoicePrintingMediaSetting.NewspaperSalesClassLocation = Me.NewspaperSalesClassLocation
			InvoicePrintingMediaSetting.NewspaperCampaignLocation = Me.NewspaperCampaignLocation
			InvoicePrintingMediaSetting.NewspaperHeaderGroupBy = Me.NewspaperHeaderGroupBy
			InvoicePrintingMediaSetting.NewspaperSortLinesBy = Me.NewspaperSortLinesBy
			InvoicePrintingMediaSetting.NewspaperLineNumberColumn = Me.NewspaperLineNumberColumn
			InvoicePrintingMediaSetting.NewspaperShowZeroLineAmounts = Me.NewspaperShowZeroLineAmounts
			InvoicePrintingMediaSetting.NewspaperCloseDateColumn = Me.NewspaperCloseDateColumn
			InvoicePrintingMediaSetting.NewspaperCustomInvoiceID = Me.NewspaperCustomInvoiceID

		End Sub
		Public Sub Save(ByVal MediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault)

			MediaInvoiceDefault.NewspaperUseInvoiceCategoryDescription = Convert.ToInt16(Me.NewspaperUseInvoiceCategoryDescription)
			MediaInvoiceDefault.NewspaperInvoiceTitle = Me.NewspaperInvoiceTitle
			MediaInvoiceDefault.NewspaperGroupByMarket = Convert.ToInt16(Me.NewspaperGroupByMarket)
			MediaInvoiceDefault.NewspaperShowOrderDescription = Convert.ToInt16(Me.NewspaperShowOrderDescription)
			MediaInvoiceDefault.NewspaperShowClientReference = Convert.ToInt16(Me.NewspaperShowClientReference)
			MediaInvoiceDefault.NewspaperShowClientPO = Convert.ToInt16(Me.NewspaperShowClientPO)
			MediaInvoiceDefault.NewspaperShowOrderComment = Convert.ToInt16(Me.NewspaperShowOrderComment)
			MediaInvoiceDefault.NewspaperShowOrderHouseComment = Convert.ToInt16(Me.NewspaperShowOrderHouseComment)
			MediaInvoiceDefault.NewspaperPrintInvoiceDueDate = Convert.ToInt16(Me.NewspaperPrintInvoiceDueDate)
			MediaInvoiceDefault.NewspaperShowLineDetail = Convert.ToInt16(Me.NewspaperShowLineDetail)

			MediaInvoiceDefault.NewspaperOrderNumberColumn = Me.NewspaperOrderNumberColumn
			MediaInvoiceDefault.NewspaperVendorNameColumn = Me.NewspaperVendorNameColumn
			MediaInvoiceDefault.NewspaperShowVendorCode = Me.NewspaperShowVendorCode
			MediaInvoiceDefault.NewspaperOrderMonthsColumn = Me.NewspaperOrderMonthsColumn
			MediaInvoiceDefault.NewspaperNetAmountColumn = Me.NewspaperNetAmountColumn
			MediaInvoiceDefault.NewspaperCommissionAmountColumn = Me.NewspaperCommissionAmountColumn
			MediaInvoiceDefault.NewspaperTaxAmountColumn = Me.NewspaperTaxAmountColumn
			MediaInvoiceDefault.NewspaperBillAmountColumn = Me.NewspaperBillAmountColumn
			MediaInvoiceDefault.NewspaperPriorBillAmountColumn = Me.NewspaperPriorBillAmountColumn
			MediaInvoiceDefault.NewspaperBilledToDateAmountColumn = Me.NewspaperBilledToDateAmountColumn
			MediaInvoiceDefault.NewspaperHeadlineColumn = Me.NewspaperHeadlineColumn
			MediaInvoiceDefault.NewspaperInsertDatesColumn = Me.NewspaperInsertDatesColumn
			MediaInvoiceDefault.NewspaperMaterialColumn = Me.NewspaperMaterialColumn
			MediaInvoiceDefault.NewspaperAdNumberColumn = Me.NewspaperAdNumberColumn
			MediaInvoiceDefault.NewspaperEditorialIssueColumn = Me.NewspaperEditorialIssueColumn
			MediaInvoiceDefault.NewspaperSectionColumn = Me.NewspaperSectionColumn
			MediaInvoiceDefault.NewspaperQuantityColumn = Me.NewspaperQuantityColumn
			MediaInvoiceDefault.NewspaperAdSizeColumn = Me.NewspaperAdSizeColumn
			MediaInvoiceDefault.NewspaperJobComponentNumberColumn = Me.NewspaperJobComponentNumberColumn
			MediaInvoiceDefault.NewspaperJobDescriptionColumn = Me.NewspaperJobDescriptionColumn
			MediaInvoiceDefault.NewspaperComponentDescriptionColumn = Me.NewspaperComponentDescriptionColumn
			MediaInvoiceDefault.NewspaperOrderDetailCommentColumn = Me.NewspaperOrderDetailCommentColumn
			MediaInvoiceDefault.NewspaperOrderHouseDetailCommentColumn = Me.NewspaperOrderHouseDetailCommentColumn
			MediaInvoiceDefault.NewspaperExtraChargesColumn = Me.NewspaperExtraChargesColumn

			MediaInvoiceDefault.NewspaperShowCommissionSeparately = Convert.ToInt16(Me.NewspaperShowCommissionSeparately)
			MediaInvoiceDefault.NewspaperShowRebateSeparately = Convert.ToInt16(Me.NewspaperShowRebateSeparately)
			MediaInvoiceDefault.NewspaperShowTaxSeparately = Convert.ToInt16(Me.NewspaperShowTaxSeparately)
			MediaInvoiceDefault.NewspaperShowBillingHistory = Convert.ToInt16(Me.NewspaperShowBillingHistory)
			MediaInvoiceDefault.NewspaperShowCampaign = Me.NewspaperShowCampaign
			MediaInvoiceDefault.NewspaperShowCampaignComment = Me.NewspaperShowCampaignComment
			MediaInvoiceDefault.NewspaperShowOrderSubtotals = Me.NewspaperShowOrderSubtotals

			MediaInvoiceDefault.NewspaperShowSalesClass = Me.NewspaperShowSalesClass
			MediaInvoiceDefault.NewspaperClientPOLocation = Me.NewspaperClientPOLocation
			MediaInvoiceDefault.NewspaperSalesClassLocation = Me.NewspaperSalesClassLocation
			MediaInvoiceDefault.NewspaperCampaignLocation = Me.NewspaperCampaignLocation
			MediaInvoiceDefault.NewspaperHeaderGroupBy = Me.NewspaperHeaderGroupBy
			MediaInvoiceDefault.NewspaperSortLinesBy = Me.NewspaperSortLinesBy
			MediaInvoiceDefault.NewspaperLineNumberColumn = Me.NewspaperLineNumberColumn
			MediaInvoiceDefault.NewspaperShowZeroLineAmounts = Me.NewspaperShowZeroLineAmounts
			MediaInvoiceDefault.NewspaperCloseDateColumn = Me.NewspaperCloseDateColumn
			MediaInvoiceDefault.NewspaperCustomInvoiceID = Me.NewspaperCustomInvoiceID

		End Sub
        Public Overrides Function ToString() As String

            ToString = ""

        End Function

#End Region

    End Class

End Namespace
