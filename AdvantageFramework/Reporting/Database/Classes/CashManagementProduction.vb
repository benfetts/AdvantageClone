Namespace Reporting.Database.Classes

    <Serializable()>
    Public Class CashManagementProduction

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductDescription
            JobNumber
            JobDescription
            JobComponentNumber
            JobComponentDescription
            SalesClassCode
            SalesClassDescription
            JobTypeCode
            JobTypeDescription
            TypeCode
            ARInvoiceNumber
            ARInvoiceDate
            ARCostAmount
            ARTotalBillAmount
            ARNetPaidAmount
            ARGrossPaidAmount
            ARPartialAmount
            ARPaymentDescription
            AROutstandingAmount
            ARAccruedLiabilityAmount
            VendorCode
            VendorName
            APInvoiceNumber
            APInvoiceDate
            APBillableCostAmount
            APNonbillableCostAmount
            APTotalCostAmount
            APUnpaidAmount
            APPaidAmount
            APPaymentDescription
            EstimatedNetCashAvailable
            EstimatedGrossCashAvailable
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As Integer

        Public Property ClientCode() As String

        Public Property ClientName() As String

        Public Property DivisionCode() As String

        Public Property DivisionName() As String

        Public Property ProductCode() As String

        Public Property ProductDescription() As String


        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property JobNumber() As Nullable(Of Integer)

        Public Property JobDescription() As String

        Public Property JobComponentNumber() As Nullable(Of Short)

        Public Property JobComponentDescription() As String
        Public Property SalesClassCode() As String
        Public Property SalesClassDescription() As String
        Public Property JobTypeCode() As String
        Public Property JobTypeDescription() As String

        Public Property TypeCode() As String


        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property ARInvoiceNumber As Nullable(Of Integer)
        Public Property ARInvoiceDate As Nullable(Of Date)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ARCostAmount As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ARTotalBillAmount As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ARNetPaidAmount As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ARGrossPaidAmount As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ARPartialAmount As Nullable(Of Decimal)
        Public Property ARPaymentDescription As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property AROutstandingAmount As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ARAccruedLiabilityAmount As Nullable(Of Decimal)
        Public Property VendorCode As String
        Public Property VendorName As String
        Public Property APInvoiceNumber As String
        Public Property APInvoiceDate As Nullable(Of Date)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property APBillableCostAmount As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property APNonbillableCostAmount As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property APTotalCostAmount As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property APUnpaidAmount As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property APPaidAmount As Nullable(Of Decimal)
        Public Property APPaymentDescription As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property EstimatedNetCashAvailable As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property EstimatedGrossCashAvailable As Nullable(Of Decimal)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
