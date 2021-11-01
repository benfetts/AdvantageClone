Namespace Reporting.Database.Classes

    <Serializable>
    Public Class MediaResultsComparisonByClientAndTypeReport

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
            ProductName
            VendorCode
            VendorName
            Placement
            SalesClassCode
            SalesClassDescription
            ClientState
            Region
            NumberOfEmployees
            TurnoverPercent
            Revenue
            Type1
            Type2
            Type3
            Period
            Month
            MonthName
            MonthAbbreviation
            Year
            MediaType
            MediaTypeDescription
            NetDollars
            GrossDollars
            MediaOrderNetDollars
            MediaOrderGrossDollars
            ClientSales
            Units
            Leads1
            Leads2
            Impressions
            Clicks
            ClickRate
            Calls
            Conversions
            ConversionsB
            ConversionsC
            LikesOrganic
            LikesPaid
            Visits
            UniqueVisitors
            ReachOrganic
            ReachPaid
            PageViews
            PageEngagement
            AdNumber
            AdNumberDescription
            DaypartCode
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID() As Nullable(Of System.Guid)

        Public Property ClientCode() As String

        Public Property ClientName() As String

        Public Property DivisionCode() As String

        Public Property DivisionName() As String

        Public Property ProductCode() As String

        Public Property ProductName() As String

        Public Property VendorCode() As String

        Public Property VendorName() As String

        Public Property Placement() As String

        Public Property SalesClassCode() As String

        Public Property SalesClassDescription() As String

        Public Property ClientState() As String

        Public Property Region() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="f0")>
        Public Property NumberOfEmployees() As Nullable(Of Integer)

        Public Property TurnoverPercent() As Nullable(Of Decimal)

        Public Property Revenue() As Nullable(Of Decimal)

        Public Property Type1() As String

        Public Property Type2() As String

        Public Property Type3() As String

        Public Property Period As String

        Public Property Month() As String

        Public Property MonthName() As String

        Public Property MonthAbbreviation() As String

        Public Property Year() As String

        Public Property MediaType() As String

        Public Property MediaTypeDescription() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property NetDollars() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property GrossDollars() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property MediaOrderNetDollars() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property MediaOrderGrossDollars() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property Units() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property Leads1() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property Leads2() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property Impressions() As Nullable(Of Integer)

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property Clicks() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="f0")>
        Public Property ClickRate() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property Calls() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property Conversions() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property ConversionsB() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property ConversionsC() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property LikesOrganic() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property LikesPaid() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property Visits() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property UniqueVisitors() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property ReachOrganic() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property ReachPaid() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property PageViews() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property PageEngagement() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property ClientSales() As Nullable(Of Decimal)

        Public Property AdNumber() As String

        Public Property AdNumberDescription() As String

        Public Property DaypartCode() As String

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
