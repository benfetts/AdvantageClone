Namespace InvoicePrinting.Classes

    <Serializable()>
    Public Class MediaInvoiceMagazineSetting

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            MagazineUseInvoiceCategoryDescription
            MagazineInvoiceTitle
            MagazineGroupByMarket
            MagazineShowOrderDescription
            MagazineShowClientReference
            MagazineShowClientPO
            MagazineShowOrderComment
            MagazineShowOrderHouseComment
            MagazinePrintInvoiceDueDate
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
            MagazineCustomFormatName
            MagazineShowCampaign
            MagazineShowCampaignComment
            MagazineShowOrderSubtotals
            MagazineShowSalesClass
            MagazineClientPOLocation
            MagazineSalesClassLocation
            MagazineCampaignLocation
            MagazineHeaderGroupBy
            MagazineSortLinesBy
            MagazineLineNumberColumn
            MagazineShowZeroLineAmounts
			MagazineCloseDateColumn
			MagazineCustomInvoiceID
		End Enum

#End Region

#Region " Variables "

		Private _MagazineUseInvoiceCategoryDescription As Boolean = False
		Private _MagazineInvoiceTitle As String = Nothing
		Private _MagazineGroupByMarket As Boolean = False
		Private _MagazineShowOrderDescription As Boolean = False
		Private _MagazineShowClientReference As Boolean = False
		Private _MagazineShowClientPO As Boolean = False
		Private _MagazineShowOrderComment As Boolean = False
		Private _MagazineShowOrderHouseComment As Boolean = False
		Private _MagazinePrintInvoiceDueDate As Boolean = False
		Private _MagazineShowLineDetail As Integer = 0
		Private _MagazineOrderNumberColumn As Short = 1
		Private _MagazineVendorNameColumn As Short = 0
		Private _MagazineShowVendorCode As Short = 0
		Private _MagazineOrderMonthsColumn As Short = 0
		Private _MagazineHeadlineColumn As Short = 0
		Private _MagazineInsertDatesColumn As Short = 0
		Private _MagazineMaterialColumn As Short = 0
		Private _MagazineAdNumberColumn As Short = 0
		Private _MagazineEditorialIssueColumn As Short = 0
		Private _MagazineAdSizeColumn As Short = 0
		Private _MagazineJobComponentNumberColumn As Short = 0
		Private _MagazineJobDescriptionColumn As Short = 0
		Private _MagazineComponentDescriptionColumn As Short = 0
		Private _MagazineOrderDetailCommentColumn As Short = 0
		Private _MagazineOrderHouseDetailCommentColumn As Short = 0
		Private _MagazineExtraChargesColumn As Short = 0
		Private _MagazineNetAmountColumn As Short = 0
		Private _MagazineCommissionAmountColumn As Short = 0
		Private _MagazineTaxAmountColumn As Short = 0
		Private _MagazineBillAmountColumn As Short = 0
		Private _MagazinePriorBillAmountColumn As Short = 0
		Private _MagazineBilledToDateAmountColumn As Short = 0
		Private _MagazineShowCommissionSeparately As Boolean = False
		Private _MagazineShowRebateSeparately As Boolean = False
		Private _MagazineShowTaxSeparately As Boolean = False
		Private _MagazineShowBillingHistory As Boolean = False
		Private _MagazineCustomFormatName As String = Nothing
		Private _MagazineShowCampaign As Boolean = False
		Private _MagazineShowCampaignComment As Boolean = False
		Private _MagazineShowOrderSubtotals As Boolean = False
		Private _MagazineShowSalesClass As Boolean = False
		Private _MagazineClientPOLocation As Integer = 1
		Private _MagazineSalesClassLocation As Integer = 1
		Private _MagazineCampaignLocation As Integer = 1
		Private _MagazineHeaderGroupBy As Integer = Nothing
		Private _MagazineSortLinesBy As Integer = 1
		Private _MagazineLineNumberColumn As Short = 0
		Private _MagazineShowZeroLineAmounts As Boolean = False
		Private _MagazineCloseDateColumn As Short = 0
		Private _MagazineCustomInvoiceID As Nullable(Of Integer) = Nothing

		Private _MediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault = Nothing
		Private _InvoicePrintingMediaSetting As InvoicePrintingMediaSetting = Nothing

#End Region

#Region " Properties "

		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property MagazineUseInvoiceCategoryDescription As Boolean
			Get
				MagazineUseInvoiceCategoryDescription = _MagazineUseInvoiceCategoryDescription
			End Get
			Set(ByVal value As Boolean)
				_MagazineUseInvoiceCategoryDescription = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property MagazineInvoiceTitle As String
			Get
				MagazineInvoiceTitle = _MagazineInvoiceTitle
			End Get
			Set(ByVal value As String)
				_MagazineInvoiceTitle = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property MagazineGroupByMarket As Boolean
			Get
				MagazineGroupByMarket = _MagazineGroupByMarket
			End Get
			Set(ByVal value As Boolean)
				_MagazineGroupByMarket = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property MagazineShowOrderDescription As Boolean
			Get
				MagazineShowOrderDescription = _MagazineShowOrderDescription
			End Get
			Set(ByVal value As Boolean)
				_MagazineShowOrderDescription = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property MagazineShowClientReference As Boolean
			Get
				MagazineShowClientReference = _MagazineShowClientReference
			End Get
			Set(ByVal value As Boolean)
				_MagazineShowClientReference = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property MagazineShowClientPO As Boolean
			Get
				MagazineShowClientPO = _MagazineShowClientPO
			End Get
			Set(ByVal value As Boolean)
				_MagazineShowClientPO = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property MagazineShowOrderComment As Boolean
			Get
				MagazineShowOrderComment = _MagazineShowOrderComment
			End Get
			Set(ByVal value As Boolean)
				_MagazineShowOrderComment = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property MagazineShowOrderHouseComment As Boolean
			Get
				MagazineShowOrderHouseComment = _MagazineShowOrderHouseComment
			End Get
			Set(ByVal value As Boolean)
				_MagazineShowOrderHouseComment = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property MagazinePrintInvoiceDueDate As Boolean
			Get
				MagazinePrintInvoiceDueDate = _MagazinePrintInvoiceDueDate
			End Get
			Set(ByVal value As Boolean)
				_MagazinePrintInvoiceDueDate = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property MagazineShowLineDetail As Integer
			Get
				MagazineShowLineDetail = _MagazineShowLineDetail
			End Get
			Set(ByVal value As Integer)
				_MagazineShowLineDetail = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property MagazineOrderNumberColumn As Short
			Get
				MagazineOrderNumberColumn = _MagazineOrderNumberColumn
			End Get
			Set(ByVal value As Short)
				_MagazineOrderNumberColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property MagazineVendorNameColumn As Short
			Get
				MagazineVendorNameColumn = _MagazineVendorNameColumn
			End Get
			Set(ByVal value As Short)
				_MagazineVendorNameColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property MagazineShowVendorCode As Short
			Get
				MagazineShowVendorCode = _MagazineShowVendorCode
			End Get
			Set(ByVal value As Short)
				_MagazineShowVendorCode = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property MagazineOrderMonthsColumn As Short
			Get
				MagazineOrderMonthsColumn = _MagazineOrderMonthsColumn
			End Get
			Set(ByVal value As Short)
				_MagazineOrderMonthsColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property MagazineHeadlineColumn As Short
			Get
				MagazineHeadlineColumn = _MagazineHeadlineColumn
			End Get
			Set(ByVal value As Short)
				_MagazineHeadlineColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property MagazineInsertDatesColumn As Short
			Get
				MagazineInsertDatesColumn = _MagazineInsertDatesColumn
			End Get
			Set(ByVal value As Short)
				_MagazineInsertDatesColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property MagazineMaterialColumn As Short
			Get
				MagazineMaterialColumn = _MagazineMaterialColumn
			End Get
			Set(ByVal value As Short)
				_MagazineMaterialColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property MagazineAdNumberColumn As Short
			Get
				MagazineAdNumberColumn = _MagazineAdNumberColumn
			End Get
			Set(ByVal value As Short)
				_MagazineAdNumberColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property MagazineEditorialIssueColumn As Short
			Get
				MagazineEditorialIssueColumn = _MagazineEditorialIssueColumn
			End Get
			Set(ByVal value As Short)
				_MagazineEditorialIssueColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property MagazineAdSizeColumn As Short
			Get
				MagazineAdSizeColumn = _MagazineAdSizeColumn
			End Get
			Set(ByVal value As Short)
				_MagazineAdSizeColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property MagazineJobComponentNumberColumn As Short
			Get
				MagazineJobComponentNumberColumn = _MagazineJobComponentNumberColumn
			End Get
			Set(ByVal value As Short)
				_MagazineJobComponentNumberColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property MagazineJobDescriptionColumn As Short
			Get
				MagazineJobDescriptionColumn = _MagazineJobDescriptionColumn
			End Get
			Set(ByVal value As Short)
				_MagazineJobDescriptionColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property MagazineComponentDescriptionColumn As Short
			Get
				MagazineComponentDescriptionColumn = _MagazineComponentDescriptionColumn
			End Get
			Set(ByVal value As Short)
				_MagazineComponentDescriptionColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property MagazineOrderDetailCommentColumn As Short
			Get
				MagazineOrderDetailCommentColumn = _MagazineOrderDetailCommentColumn
			End Get
			Set(ByVal value As Short)
				_MagazineOrderDetailCommentColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property MagazineOrderHouseDetailCommentColumn As Short
			Get
				MagazineOrderHouseDetailCommentColumn = _MagazineOrderHouseDetailCommentColumn
			End Get
			Set(ByVal value As Short)
				_MagazineOrderHouseDetailCommentColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property MagazineExtraChargesColumn As Short
			Get
				MagazineExtraChargesColumn = _MagazineExtraChargesColumn
			End Get
			Set(ByVal value As Short)
				_MagazineExtraChargesColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property MagazineNetAmountColumn As Short
			Get
				MagazineNetAmountColumn = _MagazineNetAmountColumn
			End Get
			Set(ByVal value As Short)
				_MagazineNetAmountColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property MagazineCommissionAmountColumn As Short
			Get
				MagazineCommissionAmountColumn = _MagazineCommissionAmountColumn
			End Get
			Set(ByVal value As Short)
				_MagazineCommissionAmountColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property MagazineTaxAmountColumn As Short
			Get
				MagazineTaxAmountColumn = _MagazineTaxAmountColumn
			End Get
			Set(ByVal value As Short)
				_MagazineTaxAmountColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property MagazineBillAmountColumn As Short
			Get
				MagazineBillAmountColumn = _MagazineBillAmountColumn
			End Get
			Set(ByVal value As Short)
				_MagazineBillAmountColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property MagazinePriorBillAmountColumn As Short
			Get
				MagazinePriorBillAmountColumn = _MagazinePriorBillAmountColumn
			End Get
			Set(ByVal value As Short)
				_MagazinePriorBillAmountColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property MagazineBilledToDateAmountColumn As Short
			Get
				MagazineBilledToDateAmountColumn = _MagazineBilledToDateAmountColumn
			End Get
			Set(ByVal value As Short)
				_MagazineBilledToDateAmountColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property MagazineShowCommissionSeparately As Boolean
			Get
				MagazineShowCommissionSeparately = _MagazineShowCommissionSeparately
			End Get
			Set(ByVal value As Boolean)
				_MagazineShowCommissionSeparately = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property MagazineShowRebateSeparately As Boolean
			Get
				MagazineShowRebateSeparately = _MagazineShowRebateSeparately
			End Get
			Set(ByVal value As Boolean)
				_MagazineShowRebateSeparately = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property MagazineShowTaxSeparately As Boolean
			Get
				MagazineShowTaxSeparately = _MagazineShowTaxSeparately
			End Get
			Set(ByVal value As Boolean)
				_MagazineShowTaxSeparately = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property MagazineShowBillingHistory As Boolean
			Get
				MagazineShowBillingHistory = _MagazineShowBillingHistory
			End Get
			Set(ByVal value As Boolean)
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
		Public Property MagazineShowCampaign() As Boolean
			Get
				MagazineShowCampaign = _MagazineShowCampaign
			End Get
			Set(ByVal value As Boolean)
				_MagazineShowCampaign = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property MagazineShowCampaignComment() As Boolean
			Get
				MagazineShowCampaignComment = _MagazineShowCampaignComment
			End Get
			Set(ByVal value As Boolean)
				_MagazineShowCampaignComment = value
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
		Public Property MagazineShowSalesClass() As Boolean
			Get
				MagazineShowSalesClass = _MagazineShowSalesClass
			End Get
			Set(value As Boolean)
				_MagazineShowSalesClass = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property MagazineClientPOLocation() As Integer
			Get
				MagazineClientPOLocation = _MagazineClientPOLocation
			End Get
			Set(value As Integer)
				_MagazineClientPOLocation = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property MagazineSalesClassLocation() As Integer
			Get
				MagazineSalesClassLocation = _MagazineSalesClassLocation
			End Get
			Set(value As Integer)
				_MagazineSalesClassLocation = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property MagazineCampaignLocation() As Integer
			Get
				MagazineCampaignLocation = _MagazineCampaignLocation
			End Get
			Set(value As Integer)
				_MagazineCampaignLocation = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property MagazineHeaderGroupBy() As Integer
			Get
				MagazineHeaderGroupBy = _MagazineHeaderGroupBy
			End Get
			Set(value As Integer)
				_MagazineHeaderGroupBy = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
		Public Property MagazineSortLinesBy() As Integer
			Get
				MagazineSortLinesBy = _MagazineSortLinesBy
			End Get
			Set(value As Integer)
				_MagazineSortLinesBy = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property MagazineLineNumberColumn() As Short
			Get
				MagazineLineNumberColumn = _MagazineLineNumberColumn
			End Get
			Set(value As Short)
				_MagazineLineNumberColumn = value
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
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.Category("Columns")>
		Public Property MagazineCloseDateColumn() As Short
			Get
				MagazineCloseDateColumn = _MagazineCloseDateColumn
			End Get
			Set(value As Short)
				_MagazineCloseDateColumn = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		System.ComponentModel.DisplayName("Custom Invoice")>
		Public Property MagazineCustomInvoiceID() As Nullable(Of Integer)
			Get
				MagazineCustomInvoiceID = _MagazineCustomInvoiceID
			End Get
			Set(ByVal value As Nullable(Of Integer))
				_MagazineCustomInvoiceID = value
			End Set
		End Property

#End Region

#Region " Methods "

		Public Sub New()



		End Sub
		Public Sub New(ByVal MediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault)

			Me.MagazineUseInvoiceCategoryDescription = Convert.ToBoolean(MediaInvoiceDefault.MagazineUseInvoiceCategoryDescription.GetValueOrDefault(0))
			Me.MagazineInvoiceTitle = MediaInvoiceDefault.MagazineInvoiceTitle
			Me.MagazineGroupByMarket = Convert.ToBoolean(MediaInvoiceDefault.MagazineGroupByMarket.GetValueOrDefault(0))
			Me.MagazineShowOrderDescription = Convert.ToBoolean(MediaInvoiceDefault.MagazineShowOrderDescription.GetValueOrDefault(0))
			Me.MagazineShowClientReference = Convert.ToBoolean(MediaInvoiceDefault.MagazineShowClientReference.GetValueOrDefault(0))
			Me.MagazineShowClientPO = Convert.ToBoolean(MediaInvoiceDefault.MagazineShowClientPO.GetValueOrDefault(0))
			Me.MagazineShowOrderComment = Convert.ToBoolean(MediaInvoiceDefault.MagazineShowOrderComment.GetValueOrDefault(0))
			Me.MagazineShowOrderHouseComment = Convert.ToBoolean(MediaInvoiceDefault.MagazineShowOrderHouseComment.GetValueOrDefault(0))
			Me.MagazinePrintInvoiceDueDate = Convert.ToBoolean(MediaInvoiceDefault.MagazinePrintInvoiceDueDate.GetValueOrDefault(0))
			Me.MagazineShowLineDetail = Convert.ToInt32(MediaInvoiceDefault.MagazineShowLineDetail.GetValueOrDefault(0))

			Me.MagazineOrderNumberColumn = MediaInvoiceDefault.MagazineOrderNumberColumn.GetValueOrDefault(1)
			Me.MagazineVendorNameColumn = MediaInvoiceDefault.MagazineVendorNameColumn.GetValueOrDefault(2)
			Me.MagazineShowVendorCode = MediaInvoiceDefault.MagazineShowVendorCode.GetValueOrDefault(0)
			Me.MagazineOrderMonthsColumn = MediaInvoiceDefault.MagazineOrderMonthsColumn.GetValueOrDefault(0)
			Me.MagazineNetAmountColumn = MediaInvoiceDefault.MagazineNetAmountColumn.GetValueOrDefault(0)
			Me.MagazineCommissionAmountColumn = MediaInvoiceDefault.MagazineCommissionAmountColumn.GetValueOrDefault(0)
			Me.MagazineTaxAmountColumn = MediaInvoiceDefault.MagazineTaxAmountColumn.GetValueOrDefault(0)
			Me.MagazineBillAmountColumn = MediaInvoiceDefault.MagazineBillAmountColumn.GetValueOrDefault(0)
			Me.MagazinePriorBillAmountColumn = MediaInvoiceDefault.MagazinePriorBillAmountColumn.GetValueOrDefault(0)
			Me.MagazineBilledToDateAmountColumn = MediaInvoiceDefault.MagazineBilledToDateAmountColumn.GetValueOrDefault(0)
			Me.MagazineHeadlineColumn = MediaInvoiceDefault.MagazineHeadlineColumn.GetValueOrDefault(0)
			Me.MagazineInsertDatesColumn = MediaInvoiceDefault.MagazineInsertDatesColumn.GetValueOrDefault(0)
			Me.MagazineMaterialColumn = MediaInvoiceDefault.MagazineMaterialColumn.GetValueOrDefault(0)
			Me.MagazineAdNumberColumn = MediaInvoiceDefault.MagazineAdNumberColumn.GetValueOrDefault(0)
			Me.MagazineEditorialIssueColumn = MediaInvoiceDefault.MagazineEditorialIssueColumn.GetValueOrDefault(0)
			Me.MagazineAdSizeColumn = MediaInvoiceDefault.MagazineAdSizeColumn.GetValueOrDefault(0)
			Me.MagazineJobComponentNumberColumn = MediaInvoiceDefault.MagazineJobComponentNumberColumn.GetValueOrDefault(0)
			Me.MagazineJobDescriptionColumn = MediaInvoiceDefault.MagazineJobDescriptionColumn.GetValueOrDefault(0)
			Me.MagazineComponentDescriptionColumn = MediaInvoiceDefault.MagazineComponentDescriptionColumn.GetValueOrDefault(0)
			Me.MagazineOrderDetailCommentColumn = MediaInvoiceDefault.MagazineOrderDetailCommentColumn.GetValueOrDefault(0)
			Me.MagazineOrderHouseDetailCommentColumn = MediaInvoiceDefault.MagazineOrderHouseDetailCommentColumn.GetValueOrDefault(0)
			Me.MagazineExtraChargesColumn = MediaInvoiceDefault.MagazineExtraChargesColumn.GetValueOrDefault(0)

			Me.MagazineShowCommissionSeparately = Convert.ToBoolean(MediaInvoiceDefault.MagazineShowCommissionSeparately.GetValueOrDefault(0))
			Me.MagazineShowRebateSeparately = Convert.ToBoolean(MediaInvoiceDefault.MagazineShowRebateSeparately.GetValueOrDefault(0))
			Me.MagazineShowTaxSeparately = Convert.ToBoolean(MediaInvoiceDefault.MagazineShowTaxSeparately.GetValueOrDefault(0))
			Me.MagazineShowBillingHistory = Convert.ToBoolean(MediaInvoiceDefault.MagazineShowBillingHistory.GetValueOrDefault(0))
			Me.MagazineShowCampaign = MediaInvoiceDefault.MagazineShowCampaign
			Me.MagazineShowCampaignComment = MediaInvoiceDefault.MagazineShowCampaignComment
			Me.MagazineShowOrderSubtotals = MediaInvoiceDefault.MagazineShowOrderSubtotals

			Me.MagazineShowSalesClass = MediaInvoiceDefault.MagazineShowSalesClass
			Me.MagazineClientPOLocation = MediaInvoiceDefault.MagazineClientPOLocation
			Me.MagazineSalesClassLocation = MediaInvoiceDefault.MagazineSalesClassLocation
			Me.MagazineCampaignLocation = MediaInvoiceDefault.MagazineCampaignLocation
			Me.MagazineHeaderGroupBy = MediaInvoiceDefault.MagazineHeaderGroupBy
			Me.MagazineSortLinesBy = MediaInvoiceDefault.MagazineSortLinesBy
			Me.MagazineLineNumberColumn = MediaInvoiceDefault.MagazineLineNumberColumn
			Me.MagazineShowZeroLineAmounts = MediaInvoiceDefault.MagazineShowZeroLineAmounts
			Me.MagazineCloseDateColumn = MediaInvoiceDefault.MagazineCloseDateColumn
			Me.MagazineCustomInvoiceID = MediaInvoiceDefault.MagazineCustomInvoiceID

			_MediaInvoiceDefault = MediaInvoiceDefault

		End Sub
		Public Sub New(ByVal InvoicePrintingMediaSetting As InvoicePrintingMediaSetting)

			Me.MagazineUseInvoiceCategoryDescription = InvoicePrintingMediaSetting.MagazineUseInvoiceCategoryDescription.GetValueOrDefault(False)
			Me.MagazineInvoiceTitle = InvoicePrintingMediaSetting.MagazineInvoiceTitle
			Me.MagazineGroupByMarket = InvoicePrintingMediaSetting.MagazineGroupByMarket.GetValueOrDefault(False)
			Me.MagazineShowOrderDescription = InvoicePrintingMediaSetting.MagazineShowOrderDescription.GetValueOrDefault(False)
			Me.MagazineShowClientReference = InvoicePrintingMediaSetting.MagazineShowClientReference.GetValueOrDefault(False)
			Me.MagazineShowClientPO = InvoicePrintingMediaSetting.MagazineShowClientPO.GetValueOrDefault(False)
			Me.MagazineShowOrderComment = InvoicePrintingMediaSetting.MagazineShowOrderComment.GetValueOrDefault(False)
			Me.MagazineShowOrderHouseComment = InvoicePrintingMediaSetting.MagazineShowOrderHouseComment.GetValueOrDefault(False)
			Me.MagazinePrintInvoiceDueDate = InvoicePrintingMediaSetting.MagazinePrintInvoiceDueDate.GetValueOrDefault(False)
			Me.MagazineShowLineDetail = If(InvoicePrintingMediaSetting.MagazineShowLineDetail.GetValueOrDefault(False) = True, 1, 0)

			Me.MagazineOrderNumberColumn = InvoicePrintingMediaSetting.MagazineOrderNumberColumn.GetValueOrDefault(1)
			Me.MagazineVendorNameColumn = InvoicePrintingMediaSetting.MagazineVendorNameColumn.GetValueOrDefault(2)
			Me.MagazineShowVendorCode = InvoicePrintingMediaSetting.MagazineShowVendorCode.GetValueOrDefault(0)
			Me.MagazineOrderMonthsColumn = InvoicePrintingMediaSetting.MagazineOrderMonthsColumn.GetValueOrDefault(0)
			Me.MagazineNetAmountColumn = InvoicePrintingMediaSetting.MagazineNetAmountColumn.GetValueOrDefault(0)
			Me.MagazineCommissionAmountColumn = InvoicePrintingMediaSetting.MagazineCommissionAmountColumn.GetValueOrDefault(0)
			Me.MagazineTaxAmountColumn = InvoicePrintingMediaSetting.MagazineTaxAmountColumn.GetValueOrDefault(0)
			Me.MagazineBillAmountColumn = InvoicePrintingMediaSetting.MagazineBillAmountColumn.GetValueOrDefault(0)
			Me.MagazinePriorBillAmountColumn = InvoicePrintingMediaSetting.MagazinePriorBillAmountColumn.GetValueOrDefault(0)
			Me.MagazineBilledToDateAmountColumn = InvoicePrintingMediaSetting.MagazineBilledToDateAmountColumn.GetValueOrDefault(0)
			Me.MagazineHeadlineColumn = InvoicePrintingMediaSetting.MagazineHeadlineColumn.GetValueOrDefault(0)
			Me.MagazineInsertDatesColumn = InvoicePrintingMediaSetting.MagazineInsertDatesColumn.GetValueOrDefault(0)
			Me.MagazineMaterialColumn = InvoicePrintingMediaSetting.MagazineMaterialColumn.GetValueOrDefault(0)
			Me.MagazineAdNumberColumn = InvoicePrintingMediaSetting.MagazineAdNumberColumn.GetValueOrDefault(0)
			Me.MagazineEditorialIssueColumn = InvoicePrintingMediaSetting.MagazineEditorialIssueColumn.GetValueOrDefault(0)
			Me.MagazineAdSizeColumn = InvoicePrintingMediaSetting.MagazineAdSizeColumn.GetValueOrDefault(0)
			Me.MagazineJobComponentNumberColumn = InvoicePrintingMediaSetting.MagazineJobComponentNumberColumn.GetValueOrDefault(0)
			Me.MagazineJobDescriptionColumn = InvoicePrintingMediaSetting.MagazineJobDescriptionColumn.GetValueOrDefault(0)
			Me.MagazineComponentDescriptionColumn = InvoicePrintingMediaSetting.MagazineComponentDescriptionColumn.GetValueOrDefault(0)
			Me.MagazineOrderDetailCommentColumn = InvoicePrintingMediaSetting.MagazineOrderDetailCommentColumn.GetValueOrDefault(0)
			Me.MagazineOrderHouseDetailCommentColumn = InvoicePrintingMediaSetting.MagazineOrderHouseDetailCommentColumn.GetValueOrDefault(0)
			Me.MagazineExtraChargesColumn = InvoicePrintingMediaSetting.MagazineExtraChargesColumn.GetValueOrDefault(0)

			Me.MagazineShowCommissionSeparately = InvoicePrintingMediaSetting.MagazineShowCommissionSeparately.GetValueOrDefault(False)
			Me.MagazineShowRebateSeparately = InvoicePrintingMediaSetting.MagazineShowRebateSeparately.GetValueOrDefault(False)
			Me.MagazineShowTaxSeparately = InvoicePrintingMediaSetting.MagazineShowTaxSeparately.GetValueOrDefault(False)
			Me.MagazineShowBillingHistory = InvoicePrintingMediaSetting.MagazineShowBillingHistory.GetValueOrDefault(False)
			Me.MagazineShowCampaign = InvoicePrintingMediaSetting.MagazineShowCampaign
			Me.MagazineShowCampaignComment = InvoicePrintingMediaSetting.MagazineShowCampaignComment
			Me.MagazineShowOrderSubtotals = InvoicePrintingMediaSetting.MagazineShowOrderSubtotals

			Me.MagazineShowSalesClass = InvoicePrintingMediaSetting.MagazineShowSalesClass
			Me.MagazineClientPOLocation = InvoicePrintingMediaSetting.MagazineClientPOLocation
			Me.MagazineSalesClassLocation = InvoicePrintingMediaSetting.MagazineSalesClassLocation
			Me.MagazineCampaignLocation = InvoicePrintingMediaSetting.MagazineCampaignLocation
			Me.MagazineHeaderGroupBy = InvoicePrintingMediaSetting.MagazineHeaderGroupBy
			Me.MagazineSortLinesBy = InvoicePrintingMediaSetting.MagazineSortLinesBy
			Me.MagazineLineNumberColumn = InvoicePrintingMediaSetting.MagazineLineNumberColumn
			Me.MagazineShowZeroLineAmounts = InvoicePrintingMediaSetting.MagazineShowZeroLineAmounts
			Me.MagazineCloseDateColumn = InvoicePrintingMediaSetting.MagazineCloseDateColumn
			Me.MagazineCustomInvoiceID = InvoicePrintingMediaSetting.MagazineCustomInvoiceID

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

			InvoicePrintingMediaSetting.MagazineUseInvoiceCategoryDescription = Me.MagazineUseInvoiceCategoryDescription
			InvoicePrintingMediaSetting.MagazineInvoiceTitle = Me.MagazineInvoiceTitle
			InvoicePrintingMediaSetting.MagazineGroupByMarket = Me.MagazineGroupByMarket
			InvoicePrintingMediaSetting.MagazineShowOrderDescription = Me.MagazineShowOrderDescription
			InvoicePrintingMediaSetting.MagazineShowClientReference = Me.MagazineShowClientReference
			InvoicePrintingMediaSetting.MagazineShowClientPO = Me.MagazineShowClientPO
			InvoicePrintingMediaSetting.MagazineShowOrderComment = Me.MagazineShowOrderComment
			InvoicePrintingMediaSetting.MagazineShowOrderHouseComment = Me.MagazineShowOrderHouseComment
			InvoicePrintingMediaSetting.MagazinePrintInvoiceDueDate = Me.MagazinePrintInvoiceDueDate
			InvoicePrintingMediaSetting.MagazineShowLineDetail = Convert.ToBoolean(Me.MagazineShowLineDetail)

			InvoicePrintingMediaSetting.MagazineOrderNumberColumn = Me.MagazineOrderNumberColumn
			InvoicePrintingMediaSetting.MagazineVendorNameColumn = Me.MagazineVendorNameColumn
			InvoicePrintingMediaSetting.MagazineShowVendorCode = Me.MagazineShowVendorCode
			InvoicePrintingMediaSetting.MagazineOrderMonthsColumn = Me.MagazineOrderMonthsColumn
			InvoicePrintingMediaSetting.MagazineNetAmountColumn = Me.MagazineNetAmountColumn
			InvoicePrintingMediaSetting.MagazineCommissionAmountColumn = Me.MagazineCommissionAmountColumn
			InvoicePrintingMediaSetting.MagazineTaxAmountColumn = Me.MagazineTaxAmountColumn
			InvoicePrintingMediaSetting.MagazineBillAmountColumn = Me.MagazineBillAmountColumn
			InvoicePrintingMediaSetting.MagazinePriorBillAmountColumn = Me.MagazinePriorBillAmountColumn
			InvoicePrintingMediaSetting.MagazineBilledToDateAmountColumn = Me.MagazineBilledToDateAmountColumn
			InvoicePrintingMediaSetting.MagazineHeadlineColumn = Me.MagazineHeadlineColumn
			InvoicePrintingMediaSetting.MagazineInsertDatesColumn = Me.MagazineInsertDatesColumn
			InvoicePrintingMediaSetting.MagazineMaterialColumn = Me.MagazineMaterialColumn
			InvoicePrintingMediaSetting.MagazineAdNumberColumn = Me.MagazineAdNumberColumn
			InvoicePrintingMediaSetting.MagazineEditorialIssueColumn = Me.MagazineEditorialIssueColumn
			InvoicePrintingMediaSetting.MagazineAdSizeColumn = Me.MagazineAdSizeColumn
			InvoicePrintingMediaSetting.MagazineJobComponentNumberColumn = Me.MagazineJobComponentNumberColumn
			InvoicePrintingMediaSetting.MagazineJobDescriptionColumn = Me.MagazineJobDescriptionColumn
			InvoicePrintingMediaSetting.MagazineComponentDescriptionColumn = Me.MagazineComponentDescriptionColumn
			InvoicePrintingMediaSetting.MagazineOrderDetailCommentColumn = Me.MagazineOrderDetailCommentColumn
			InvoicePrintingMediaSetting.MagazineOrderHouseDetailCommentColumn = Me.MagazineOrderHouseDetailCommentColumn
			InvoicePrintingMediaSetting.MagazineExtraChargesColumn = Me.MagazineExtraChargesColumn

			InvoicePrintingMediaSetting.MagazineShowCommissionSeparately = Me.MagazineShowCommissionSeparately
			InvoicePrintingMediaSetting.MagazineShowRebateSeparately = Me.MagazineShowRebateSeparately
			InvoicePrintingMediaSetting.MagazineShowTaxSeparately = Me.MagazineShowTaxSeparately
			InvoicePrintingMediaSetting.MagazineShowBillingHistory = Me.MagazineShowBillingHistory
			InvoicePrintingMediaSetting.MagazineShowCampaign = Me.MagazineShowCampaign
			InvoicePrintingMediaSetting.MagazineShowCampaignComment = Me.MagazineShowCampaignComment
			InvoicePrintingMediaSetting.MagazineShowOrderSubtotals = Me.MagazineShowOrderSubtotals

			InvoicePrintingMediaSetting.MagazineShowSalesClass = Me.MagazineShowSalesClass
			InvoicePrintingMediaSetting.MagazineClientPOLocation = Me.MagazineClientPOLocation
			InvoicePrintingMediaSetting.MagazineSalesClassLocation = Me.MagazineSalesClassLocation
			InvoicePrintingMediaSetting.MagazineCampaignLocation = Me.MagazineCampaignLocation
			InvoicePrintingMediaSetting.MagazineHeaderGroupBy = Me.MagazineHeaderGroupBy
			InvoicePrintingMediaSetting.MagazineSortLinesBy = Me.MagazineSortLinesBy
			InvoicePrintingMediaSetting.MagazineLineNumberColumn = Me.MagazineLineNumberColumn
			InvoicePrintingMediaSetting.MagazineShowZeroLineAmounts = Me.MagazineShowZeroLineAmounts
			InvoicePrintingMediaSetting.MagazineCloseDateColumn = Me.MagazineCloseDateColumn
			InvoicePrintingMediaSetting.MagazineCustomInvoiceID = Me.MagazineCustomInvoiceID

		End Sub
		Public Sub Save(ByVal MediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault)

			MediaInvoiceDefault.MagazineUseInvoiceCategoryDescription = Convert.ToInt16(Me.MagazineUseInvoiceCategoryDescription)
			MediaInvoiceDefault.MagazineInvoiceTitle = Me.MagazineInvoiceTitle
			MediaInvoiceDefault.MagazineGroupByMarket = Convert.ToInt16(Me.MagazineGroupByMarket)
			MediaInvoiceDefault.MagazineShowOrderDescription = Convert.ToInt16(Me.MagazineShowOrderDescription)
			MediaInvoiceDefault.MagazineShowClientReference = Convert.ToInt16(Me.MagazineShowClientReference)
			MediaInvoiceDefault.MagazineShowClientPO = Convert.ToInt16(Me.MagazineShowClientPO)
			MediaInvoiceDefault.MagazineShowOrderComment = Convert.ToInt16(Me.MagazineShowOrderComment)
			MediaInvoiceDefault.MagazineShowOrderHouseComment = Convert.ToInt16(Me.MagazineShowOrderHouseComment)
			MediaInvoiceDefault.MagazinePrintInvoiceDueDate = Convert.ToInt16(Me.MagazinePrintInvoiceDueDate)
			MediaInvoiceDefault.MagazineShowLineDetail = Convert.ToInt16(Me.MagazineShowLineDetail)

			MediaInvoiceDefault.MagazineOrderNumberColumn = Me.MagazineOrderNumberColumn
			MediaInvoiceDefault.MagazineVendorNameColumn = Me.MagazineVendorNameColumn
			MediaInvoiceDefault.MagazineShowVendorCode = Me.MagazineShowVendorCode
			MediaInvoiceDefault.MagazineOrderMonthsColumn = Me.MagazineOrderMonthsColumn
			MediaInvoiceDefault.MagazineNetAmountColumn = Me.MagazineNetAmountColumn
			MediaInvoiceDefault.MagazineCommissionAmountColumn = Me.MagazineCommissionAmountColumn
			MediaInvoiceDefault.MagazineTaxAmountColumn = Me.MagazineTaxAmountColumn
			MediaInvoiceDefault.MagazineBillAmountColumn = Me.MagazineBillAmountColumn
			MediaInvoiceDefault.MagazinePriorBillAmountColumn = Me.MagazinePriorBillAmountColumn
			MediaInvoiceDefault.MagazineBilledToDateAmountColumn = Me.MagazineBilledToDateAmountColumn
			MediaInvoiceDefault.MagazineHeadlineColumn = Me.MagazineHeadlineColumn
			MediaInvoiceDefault.MagazineInsertDatesColumn = Me.MagazineInsertDatesColumn
			MediaInvoiceDefault.MagazineMaterialColumn = Me.MagazineMaterialColumn
			MediaInvoiceDefault.MagazineAdNumberColumn = Me.MagazineAdNumberColumn
			MediaInvoiceDefault.MagazineEditorialIssueColumn = Me.MagazineEditorialIssueColumn
			MediaInvoiceDefault.MagazineAdSizeColumn = Me.MagazineAdSizeColumn
			MediaInvoiceDefault.MagazineJobComponentNumberColumn = Me.MagazineJobComponentNumberColumn
			MediaInvoiceDefault.MagazineJobDescriptionColumn = Me.MagazineJobDescriptionColumn
			MediaInvoiceDefault.MagazineComponentDescriptionColumn = Me.MagazineComponentDescriptionColumn
			MediaInvoiceDefault.MagazineOrderDetailCommentColumn = Me.MagazineOrderDetailCommentColumn
			MediaInvoiceDefault.MagazineOrderHouseDetailCommentColumn = Me.MagazineOrderHouseDetailCommentColumn
			MediaInvoiceDefault.MagazineExtraChargesColumn = Me.MagazineExtraChargesColumn

			MediaInvoiceDefault.MagazineShowCommissionSeparately = Convert.ToInt16(Me.MagazineShowCommissionSeparately)
			MediaInvoiceDefault.MagazineShowRebateSeparately = Convert.ToInt16(Me.MagazineShowRebateSeparately)
			MediaInvoiceDefault.MagazineShowTaxSeparately = Convert.ToInt16(Me.MagazineShowTaxSeparately)
			MediaInvoiceDefault.MagazineShowBillingHistory = Convert.ToInt16(Me.MagazineShowBillingHistory)
			MediaInvoiceDefault.MagazineShowCampaign = Me.MagazineShowCampaign
			MediaInvoiceDefault.MagazineShowCampaignComment = Me.MagazineShowCampaignComment
			MediaInvoiceDefault.MagazineShowOrderSubtotals = Me.MagazineShowOrderSubtotals

			MediaInvoiceDefault.MagazineShowSalesClass = Me.MagazineShowSalesClass
			MediaInvoiceDefault.MagazineClientPOLocation = Me.MagazineClientPOLocation
			MediaInvoiceDefault.MagazineSalesClassLocation = Me.MagazineSalesClassLocation
			MediaInvoiceDefault.MagazineCampaignLocation = Me.MagazineCampaignLocation
			MediaInvoiceDefault.MagazineHeaderGroupBy = Me.MagazineHeaderGroupBy
			MediaInvoiceDefault.MagazineSortLinesBy = Me.MagazineSortLinesBy
			MediaInvoiceDefault.MagazineLineNumberColumn = Me.MagazineLineNumberColumn
			MediaInvoiceDefault.MagazineShowZeroLineAmounts = Me.MagazineShowZeroLineAmounts
			MediaInvoiceDefault.MagazineCloseDateColumn = Me.MagazineCloseDateColumn
			MediaInvoiceDefault.MagazineCustomInvoiceID = Me.MagazineCustomInvoiceID

		End Sub
        Public Overrides Function ToString() As String

            ToString = ""

        End Function

#End Region

    End Class

End Namespace
