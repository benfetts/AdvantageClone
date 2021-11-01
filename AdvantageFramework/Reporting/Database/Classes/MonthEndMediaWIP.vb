Namespace Reporting.Database.Classes

    <Serializable>
    Public Class MonthEndMediaWIP

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            OfficeCode
            OfficeDescription
            CDPSortCode
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductDescription
            VendorCode
            VendorName
            SalesClassCode
            SalesClassDescription
            ClientPO
            OrderType
            OrderNumber
            LineNumber
            OrderDescription
            OrderStartDate
            OrderEndDate
            OrderProcessingControl
            OrderProcessingStatus
            TransactionType
            GLAccountCode
            GLAccountDescription
            GLXact
            GLSequence
            Reference
            BillingMonthYear
            BilledAmount
            AccountsPayableAmount
            BalanceAmount
            PostingPeriod
            PostingPeriodEndDate
            CurrentAmount
            ThirtyDays
            SixtyDays
            NinetyDays
            OneHundredTwentyDays
            Over120Days
            CashReceived
            BillingPeriod
            APPeriod
        End Enum

#End Region

#Region " Variables "


#End Region

#Region " Properties "

        <Required>
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As System.Guid
        <MaxLength(4)>
        Public Property OfficeCode() As String
        <MaxLength(30)>
        Public Property OfficeDescription() As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property CDPSortCode() As String
        <MaxLength(6)>
        Public Property ClientCode() As String
        <MaxLength(40)>
        Public Property ClientName() As String
        <MaxLength(6)>
        Public Property DivisionCode() As String
        <MaxLength(40)>
        Public Property DivisionName() As String
        <MaxLength(6)>
        Public Property ProductCode As String
        <MaxLength(40)>
        Public Property ProductDescription As String
        <MaxLength(6)>
        Public Property VendorCode As String
        <MaxLength(40)>
        Public Property VendorName As String
        <MaxLength(6)>
        Public Property SalesClassCode As String
        <MaxLength(40)>
        Public Property SalesClassDescription As String

        Public Property ClientPO As String
        Public Property OrderType As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property OrderNumber As Nullable(Of Integer)
        Public Property LineNumber As Nullable(Of Integer)
        Public Property OrderDescription As String
        Public Property OrderStartDate As Nullable(Of Date)
        Public Property OrderEndDate As Nullable(Of Date)
        Public Property OrderProcessingControl As Nullable(Of Short)
        Public Property OrderProcessingStatus As String
        Public Property TransactionType As String
        Public Property GLAccountCode As String
        Public Property GLAccountDescription As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property GLXact As Nullable(Of Integer)
        Public Property GLSequence As Nullable(Of Short)
        Public Property Reference As String
        Public Property BillingMonthYear As String
        Public Property BilledAmount As Nullable(Of Decimal)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="AP Amount")>
        Public Property AccountsPayableAmount As Nullable(Of Decimal)
        Public Property BalanceAmount As Nullable(Of Decimal)
        Public Property PostingPeriod As String
        Public Property PostingPeriodEndDate As String
        Public Property CurrentAmount As Nullable(Of Decimal)

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="30 Days")>
        Public Property ThirtyDays As Nullable(Of Decimal)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="60 Days")>
        Public Property SixtyDays As Nullable(Of Decimal)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="90 Days")>
        Public Property NinetyDays As Nullable(Of Decimal)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="120 Days")>
        Public Property OneHundredTwentyDays As Nullable(Of Decimal)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Over 120 Days")>
        Public Property Over120Days As Nullable(Of Decimal)
        Public Property CashReceived As String
        Public Property BillingPeriod As String
        Public Property APPeriod As String

        '<System.Runtime.Serialization.DataMemberAttribute(),
        'AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
