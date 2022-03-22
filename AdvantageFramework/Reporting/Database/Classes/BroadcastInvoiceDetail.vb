Option Strict On

Namespace Reporting.Database.Classes

    <Serializable>
    Public Class BroadcastInvoiceDetail

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Market
            Media
            VendorCode
            VendorName
            OrderNumber
            OrderLineNumber
            FlightStart
            FlightEnd
            MonthOfService
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductName
            InvoiceNumber
            Calendar
            ScheduleGross
            ScheduleNet
            InvoiceDate
            [Status]
            InvoiceGross
            InvoiceNet
            WeekOf
            Days
            Times
            NetworkID
            Program
            AdNumber
            Daypart
            Length
            Rate
            GrossTotal
            Spots
            ActualSpotsTotal
            Variance
            MatchedSpots
            VariantCodes
            SpotDayOfWeek
            SpotDate
            SpotRunTime
            SpotNetworkID
            SpotProgramName
            SpotAdNumber
            SpotLength
            SpotRate
            SpotGrossTotal
            SpotSpots
            SpotVariantCode
            SpotUnmatched
            SpotApproved
        End Enum

#End Region

#Region " Variables "


#End Region

#Region " Properties "

        Public Property Market As String
        Public Property Media As String
        Public Property VendorCode As String
        Public Property VendorName As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="f0")>
        Public Property OrderNumber As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="f0")>
        Public Property OrderLineNumber As Nullable(Of Short)
        Public Property FlightStart As Nullable(Of Date)
        Public Property FlightEnd As Nullable(Of Date)
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Month of Service")>
        Public Property MonthOfService As String
        Public Property ClientCode As String
        Public Property ClientName As String
        Public Property DivisionCode As String
        Public Property DivisionName As String
        Public Property ProductCode As String
        Public Property ProductName As String
        Public Property InvoiceNumber As String
        Public Property Calendar As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property ScheduleGross As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property ScheduleNet As Nullable(Of Decimal)
        Public Property InvoiceDate As Nullable(Of Date)
        Public Property [Status] As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property InvoiceGross As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property InvoiceNet As Nullable(Of Decimal)
        Public Property WeekOf As Nullable(Of Date)
        Public Property Days As String
        Public Property Times As String
        Public Property NetworkID As String
        Public Property Program As String
        Public Property AdNumber As String
        Public Property Daypart As String
        Public Property Length As Nullable(Of Short)
        Public Property Rate As Nullable(Of Decimal)
        Public Property GrossTotal As Nullable(Of Decimal)
        Public Property Spots As Nullable(Of Integer)
        Public Property ActualSpotsTotal As Nullable(Of Integer)
        Public Property Variance As Nullable(Of Integer)
        Public Property MatchedSpots As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Line Variant Codes")>
        Public Property VariantCodes As String

        Public Property SpotDayOfWeek As String
        Public Property SpotDate As Nullable(Of Date)
        Public Property SpotRunTime As String
        Public Property SpotNetworkID As String
        Public Property SpotProgramName As String
        Public Property SpotAdNumber As String
        Public Property SpotLength As Nullable(Of Short)
        Public Property SpotRate As Nullable(Of Decimal)
        Public Property SpotGrossTotal As Nullable(Of Decimal)
        Public Property SpotSpots As Nullable(Of Short)
        Public Property SpotVariantCode As String
        Public Property SpotUnmatched As Boolean
        Public Property SpotApproved As Boolean

        Public Property WorksheetName As String

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
