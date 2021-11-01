Namespace Reporting.Database.Classes

    <Serializable()>
    Public Class MediaCurrentStatusCoopBreakout
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            UserCode
            OrderType
            OfficeCode
            OfficeName
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductDescription
            CoopDivisionCode
            CoopDivisionName
            CoopProductCode
            CoopProductDescription
            OrderNumber
            OrderDescription
            OrderComment
            VendorCode
            VendorName
            CampaignCode
            CampaignID
            CampaignName
            SalesClassCode
            SalesClassDescription
            MarketCode
            MarketDescription
            OrderDate
            OrderFlightFrom
            OrderFlightTo
            Buyer
            ClientPO
            NetGrossFlag
            BillCoopCode
            BillCoopDescription
            BillCoopPercent
            AcctExecCode
            AcctExecName

            LineNumber
            LineDescription
            OrderPeriod
            OrderMonth
            OrderYear
            InsertionDate
            OrderEndDate
            CloseDate
            MaterialCloseDate
            ExtendedMaterialCloseDate
            ExtendedSpaceCloseDate
            JobNumber
            JobDescription
            JobComponentNumber
            JobComponentDescription
            NetTotalAmount
            LineTotalAmount
            BillAmount
            AdditionalChargeAmount
            CommissionAmount
            RebateAmount
            ResaleTaxAmount
            AdNumber
            AdNumberDescription
            LineCancelled
            DateToBill
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As Nullable(Of System.Guid)

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property UserCode() As String

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderType() As String

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OfficeCode() As String

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OfficeName() As String

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientCode() As String

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientName() As String

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DivisionCode() As String

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DivisionName() As String

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductCode() As String

        <System.Runtime.Serialization.DataMemberAttribute()>
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Product Name")>
        Public Property ProductDescription() As String

        <System.Runtime.Serialization.DataMemberAttribute()>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property CoopDivisionCode() As String

        <System.Runtime.Serialization.DataMemberAttribute()>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property CoopDivisionName() As String

        <System.Runtime.Serialization.DataMemberAttribute()>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property CoopProductCode() As String

        <System.Runtime.Serialization.DataMemberAttribute()>
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Coop Product Name")>
        Public Property CoopProductDescription() As String

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property OrderNumber() As Integer

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderDescription() As String

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderComment() As String

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorCode() As String

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property VendorName() As String

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CampaignCode() As String

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property CampaignID() As Nullable(Of Integer)

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CampaignName() As String

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SalesClassCode() As String 'MediaType

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SalesClassDescription() As String 'MediaTypeDescription

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MarketCode() As String

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MarketDescription() As String

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderDate() As Nullable(Of Date)

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderFlightFrom() As Nullable(Of Date)

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderFlightTo() As Nullable(Of Date)

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Buyer() As String

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientPO() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Billing Coop Code")>
        Public Property BillCoopCode() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Billing Coop Description")>
        Public Property BillCoopDescription() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Billing Coop %", DisplayFormat:="n3")>
        Public Property BillCoopPercent() As Nullable(Of Decimal)

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AcctExecCode() As String

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AcctExecName() As String

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AdNumber() As String

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AdNumberDescription() As String

        <Runtime.Serialization.DataMemberAttribute()>
        Public Property LineNumber() As Short

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property LineDescription() As String

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property OrderPeriod() As String

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderMonth() As String

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0", CustomColumnCaption:="Order Year")>
        Public Property OrderYear() As Nullable(Of Integer)

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InsertionDate() As Nullable(Of Date)

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderEndDate() As Nullable(Of Date)

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CloseDate() As Nullable(Of Date)

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MaterialCloseDate() As Nullable(Of Date)

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ExtendedMaterialCloseDate() As Nullable(Of Date)

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ExtendedSpaceCloseDate() As Nullable(Of Date)

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.EntityAttribute(DisplayFormat:="f0")>
        Public Property JobNumber() As Nullable(Of Integer)

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobDescription() As String

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobComponentNumber() As Nullable(Of Short)

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobComponentDescription() As String

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NetTotalAmount() As Nullable(Of Decimal)

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property LineTotalAmount() As Nullable(Of Decimal)

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BillAmount() As Nullable(Of Decimal)

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property LineCancelled() As Boolean

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DateToBill() As Nullable(Of Date)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
