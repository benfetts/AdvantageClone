<DataContract>
Public Class Offices

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

    <DataMember>
    Public Property OfficeCode As String
    <DataMember>
    Public Property OfficeName As String

    <DataMember>
    Public Property DefaultAR As String
    <DataMember>
    Public Property DefaultAP As String
    <DataMember>
    Public Property DefaultAP_Discount As String

    'Public Property DefaultAP_With As String

    <DataMember>
    Public Property ProdSales As String
    <DataMember>
    Public Property ProdCostOfSales As String
    <DataMember>
    Public Property ProdWorkInProgress As String
    <DataMember>
    Public Property ProdDeferredSales As String
    <DataMember>
    Public Property ProdDeferredCOS As String
    <DataMember>
    Public Property ProdAccruedCOS As String
    <DataMember>
    Public Property ProdAccruedAP As String
    <DataMember>
    Public Property ProdAccruedTax As String

    <DataMember>
    Public Property MediaAccruedAP As String
    <DataMember>
    Public Property MediaAccruedCOS As String
    <DataMember>
    Public Property MediaAccruedTax As String
    <DataMember>
    Public Property MediaSales As String
    <DataMember>
    Public Property MediaCostOfSales As String
    <DataMember>
    Public Property MediaDeferredAP As String 'wip
    <DataMember>
    Public Property MediaDeferredCOS As String
    <DataMember>
    Public Property MediaDeferredSales As String

    <DataMember>
    Public Property DefaultSuspense As String
    <DataMember>
    Public Property DefaultState As String
    <DataMember>
    Public Property DefaultCounty As String
    <DataMember>
    Public Property DefaultCity As String

    'Public Property GlacodeVolDisc As String

    <DataMember>
    Public Property ProdAdvBillIncomeRecognition As String
    <DataMember>
    Public Property MediaAdvBillIncomeRecognition As String

    <DataMember>
    Public Property InactiveFlag As Short

#End Region

#Region " Methods "



#End Region

End Class
