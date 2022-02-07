Public Class MediaOrder

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

	Public Property ID As Nullable(Of System.Guid)
	Public Property UserCode As String
	Public Property OrderType As String
	Public Property OrderNumber As Nullable(Of Integer)
	Public Property OfficeCode As String
	Public Property OfficeName As String
	Public Property ClientCode As String
	Public Property ClientName As String
	Public Property DivisionCode As String
	Public Property DivisionName As String
	Public Property ProductCode As String
	Public Property ProductDescription As String
	Public Property OrderDescription As String
	Public Property OrderComment As String
	Public Property VendorCode As String
	Public Property VendorName As String
	Public Property VendorRepCode As String
	Public Property VendorRepName As String
	Public Property VendorRepCode2 As String
	Public Property VendorRepName2 As String
	Public Property CampaignCode As String
	Public Property CampaignID As Nullable(Of Short)
	Public Property CampaignName As String
    Public Property MediaType As String
    Public Property AutoCreateUnitType As String
    Public Property PostBillFlag As Nullable(Of Byte)
	Public Property NetGrossFlag As Nullable(Of Byte)
	Public Property MarketCode As String
	Public Property MarketDescription As String
	Public Property OrderDate As Nullable(Of Date)
	Public Property OrderFlightFrom As Nullable(Of Date)
	Public Property OrderFlightTo As Nullable(Of Date)
	Public Property OrderProcessControl As Nullable(Of Byte)
	Public Property Buyer As String
	Public Property ClientPO As String
	Public Property LinkID As Nullable(Of Integer)
	Public Property OrderAccepted As Nullable(Of Byte)
	Public Property LineNumber As Nullable(Of Short)
	Public Property OrderDateType As String
	Public Property OrderPeriod As Nullable(Of Integer)
	Public Property OrderMonth As String
	Public Property OrderYear As Nullable(Of Short)
	Public Property InsertionDate As Nullable(Of Date)
	Public Property OrderEndDate As Nullable(Of Date)
	Public Property DateToBill As Nullable(Of Date)
	Public Property CloseDate As Nullable(Of Date)
	Public Property MaterialCloseDate As Nullable(Of Date)
	Public Property LineDescription As String
	Public Property AdSize As String
	Public Property EditionIssue As String
	Public Property Section As String
	Public Property Material As String
	Public Property Remarks As String
	Public Property URL As String
	Public Property CopyArea As String
	Public Property MaterialNotes As String
	Public Property PositionInfo As String
	Public Property MiscellaneousInfo As String
	Public Property RateInfo As String
	Public Property JobNumber As Nullable(Of Integer)
	Public Property JobDescription As String
	Public Property JobComponentNumber As Nullable(Of Short)
	Public Property JobComponentDescription As String
	Public Property CostType As String
	Public Property RateType As String
    Public Property PrintQuantity As Decimal?
    Public Property GuaranteedImpressions As Nullable(Of Integer)
	Public Property LineLinkID As Nullable(Of Integer)
	Public Property OrderEntryType As String
	Public Property ExtendedNetAmount As Nullable(Of Decimal)
	Public Property NetChargeAmount As Nullable(Of Decimal)
	Public Property DiscountAmount As Nullable(Of Decimal)
	Public Property AdditionalChargeAmount As Nullable(Of Decimal)
	Public Property CommissionAmount As Nullable(Of Decimal)
	Public Property RebateAmount As Nullable(Of Decimal)
	Public Property VendorTaxAmount As Nullable(Of Decimal)
	Public Property ResaleTaxAmount As Nullable(Of Decimal)
	Public Property LineTotalAmount As Nullable(Of Decimal)
	Public Property NetTotalAmount As Nullable(Of Decimal)
	Public Property VendorNetAmount As Nullable(Of Decimal)
	Public Property BillAmount As Nullable(Of Decimal)
	Public Property ReconcileNoBillBillAmount As Nullable(Of Decimal)
	Public Property ReconcileNoBillNetAmount As Nullable(Of Decimal)
	Public Property SpotsQuantity As Nullable(Of Integer)
	Public Property BilledExtendedNetAmount As Nullable(Of Decimal)
	Public Property BilledDiscountAmount As Nullable(Of Decimal)
	Public Property BilledNetChargeAmount As Nullable(Of Decimal)
	Public Property BilledVendorTaxAmount As Nullable(Of Decimal)
	Public Property BilledNetAmount As Nullable(Of Decimal)
	Public Property BilledAdditionalChargeAmount As Nullable(Of Decimal)
	Public Property BilledCommissionAmount As Nullable(Of Decimal)
	Public Property BilledRebateAmount As Nullable(Of Decimal)
	Public Property BilledResaleTaxAmount As Nullable(Of Decimal)
	Public Property BilledBillAmount As Nullable(Of Decimal)
	Public Property BilledSpotsQuantity As Nullable(Of Integer)
	Public Property BillCoopCode As String
	Public Property MediaTypeDescription As String
	Public Property FiscalPeriodCode As String
	Public Property Circulation As Nullable(Of Integer)
	Public Property BuyType As String
	Public Property Date1 As Nullable(Of Date)
	Public Property Date2 As Nullable(Of Date)
	Public Property Date3 As Nullable(Of Date)
	Public Property Date4 As Nullable(Of Date)
	Public Property Date5 As Nullable(Of Date)
	Public Property Date6 As Nullable(Of Date)
	Public Property Date7 As Nullable(Of Date)
	Public Property Monday As Nullable(Of Short)
	Public Property Tuesday As Nullable(Of Short)
	Public Property Wednesday As Nullable(Of Short)
	Public Property Thursday As Nullable(Of Short)
	Public Property Friday As Nullable(Of Short)
	Public Property Saturday As Nullable(Of Short)
	Public Property Sunday As Nullable(Of Short)
    Public Property Spots1 As Nullable(Of Integer)
    Public Property Spots2 As Nullable(Of Integer)
    Public Property Spots3 As Nullable(Of Integer)
    Public Property Spots4 As Nullable(Of Integer)
    Public Property Spots5 As Nullable(Of Integer)
    Public Property Spots6 As Nullable(Of Integer)
    Public Property Spots7 As Nullable(Of Integer)
    Public Property AdNumber As String
	Public Property MaterialCompDate As Nullable(Of Date)
	Public Property Programming As String
	Public Property StartTime As String
	Public Property EndTime As String
	Public Property Tag As String
	Public Property NetworkID As String
	Public Property Days As String
    Public Property LineCancelled As Nullable(Of Byte)
    Public Property Location As String
    Public Property Week1Amount As Nullable(Of Decimal)
    Public Property Week2Amount As Nullable(Of Decimal)
    Public Property Week3Amount As Nullable(Of Decimal)
    Public Property Week4Amount As Nullable(Of Decimal)
    Public Property Week5Amount As Nullable(Of Decimal)
    Public Property Week6Amount As Nullable(Of Decimal)
    Public Property Week7Amount As Nullable(Of Decimal)
    Public Property Week1Impressions As Nullable(Of Integer)
    Public Property Week2Impressions As Nullable(Of Integer)
    Public Property Week3Impressions As Nullable(Of Integer)
    Public Property Week4Impressions As Nullable(Of Integer)
    Public Property Week5Impressions As Nullable(Of Integer)
    Public Property Week6Impressions As Nullable(Of Integer)
    Public Property Week7Impressions As Nullable(Of Integer)
    Public Property ActualImpressions As Nullable(Of Integer) 'PJH 04/16/2020 thru Headline
    Public Property GRP As Nullable(Of Decimal)
    Public Property GrossImpressions As Nullable(Of Decimal)
    'Public Property Headline As String 'Also shows in line description
    Public Property OrderModifiedDate As Nullable(Of Date)
    Public Property LineModifiedDate As Nullable(Of Date)
    Public Property LineInstructions As String
    Public Property PlanComment As String
    Public Property PlanID As Nullable(Of Integer)
    Public Property WorksheetComment As String
    Public Property WorksheetID As Nullable(Of Integer)
    Public Property ApprovedForBilling As Nullable(Of Byte)
    Public Property Length As Nullable(Of Integer)

#End Region

#Region " Methods "



#End Region

End Class
