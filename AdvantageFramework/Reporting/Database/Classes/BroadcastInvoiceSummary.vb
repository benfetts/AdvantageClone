Option Strict On

Namespace Reporting.Database.Classes

    <Serializable>
    Public Class BroadcastInvoiceSummary

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
        Public Property OrderNumber As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="f0")>
        Public Property OrderLineNumber As Short
        Public Property FlightStart As Date
        Public Property FlightEnd As Date
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
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property CDP As String
            Get
                CDP = Me.ClientCode & Me.DivisionCode & Me.ProductCode
            End Get
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.OrderNumber.ToString

        End Function

#End Region

    End Class

End Namespace
