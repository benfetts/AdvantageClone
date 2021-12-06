Namespace Reporting.Database.Classes

    <Serializable>
    Public Class MonthEndAccountsPayable

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            APIdentifier
            APSequence
            APType
            APDescription
            VendorCode
            VendorName
            VendorPayToCode
            VendorPayToName
            InvoiceNumber
            InvoiceDate
            DateToPay
            APInvoiceAgingDays
            DaysToPayAging
            TotalAmount
            PaymentHold
            GLAccountCode
            GLAccountDescription
            Period
            APGlexact
            APGlseq
            CheckNumber
            CheckDate
            CheckAmount
            DiscountAmount
            BalanceAmount
            VendorServiceTax
            AgingDays
            CurrentAmount
            ThirtyDays
            SixtyDays
            NinetyDays
            OverNinetyDays
            ClientCode
            DivisionCode
            ProductCode
            DetailAmount
            DetailTax
            DetailPeriod
            DetailGLAccountCode
            DetailGLAccountDescription
            DetailReference
            DetailARInvoiceNumber
            DetailARType
            DetailARInvoiceDate
            DetailABReference
            DetailNonBillable
        End Enum

#End Region

#Region " Variables "


#End Region

#Region " Properties "

        <Required>
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As System.Guid
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property APIdentifier() As Integer
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property APSequence() As Short
        <MaxLength(2)>
        Public Property APType() As String
        <MaxLength(30)>
        Public Property APDescription() As String
        <MaxLength(6)>
        Public Property VendorCode() As String
        <MaxLength(40)>
        Public Property VendorName() As String
        <MaxLength(6)>
        Public Property VendorPayToCode() As String
        <MaxLength(40)>
        Public Property VendorPayToName() As String
        <MaxLength(20)>
        Public Property InvoiceNumber As String
        Public Property InvoiceDate As Date
        Public Property DateToPay As Date
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property APInvoiceAgingDays As Integer
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property DaysToPayAging As Integer
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property TotalAmount As Nullable(Of Decimal)
        Public Property PaymentHold As String
        <MaxLength(30)>
        Public Property GLAccountCode As String
        <MaxLength(75)>
        Public Property GLAccountDescription As String
        Public Property Period As String

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property APGlexact As Nullable(Of Integer)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property APGlseq As Nullable(Of Short)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property CheckNumber As Nullable(Of Integer)

        Public Property CheckDate As Nullable(Of Date)
        Public Property CheckAmount As Nullable(Of Decimal)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property DiscountAmount As Nullable(Of Decimal)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property BalanceAmount As Nullable(Of Decimal)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property VendorServiceTax As Nullable(Of Decimal)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property AgingDays As Nullable(Of Integer)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CurrentAmount As Nullable(Of Decimal)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="30 Days")>
        Public Property ThirtyDays As Nullable(Of Decimal)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="60 Days")>
        Public Property SixtyDays As Nullable(Of Decimal)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="90 Days")>
        Public Property NinetyDays As Nullable(Of Decimal)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="Over 90 Days")>
        Public Property OverNinetyDays As Nullable(Of Decimal)

        Public Property ClientCode As String
        Public Property DivisionCode As String
        Public Property ProductCode As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property DetailAmount As Nullable(Of Decimal)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property DetailTax As Nullable(Of Decimal)
        Public Property DetailPeriod As String
        Public Property DetailGLAccountCode As String
        Public Property DetailGLAccountDescription As String
        Public Property DetailReference As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property DetailARInvoiceNumber As Nullable(Of Integer)
        Public Property DetailARType As String
        Public Property DetailARInvoiceDate As Nullable(Of Date)
        Public Property DetailABReference As String
        Public Property DetailNonBillable As String
        Public Property GLAPID2 As String
        Public Property InvoiceID2 As String

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
