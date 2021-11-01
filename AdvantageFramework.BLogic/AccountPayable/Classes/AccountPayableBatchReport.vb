Namespace AccountPayable.Classes

    <Serializable()>
    Public Class AccountPayableBatchReport
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Status
            AccountPayableID
            GLTransaction
            SumAmount
            SumShipping
            SumSalesTax
            Vendor
            Invoice
            InvoiceDate
            DateToPay
            Office
            Is1099Flag
            PaymentHold
            Terms
            DiscountPercent
            GLAccount
            PostPeriodCode
        End Enum

#End Region

#Region " Variables "

        Private _Status As String = Nothing
        Private _AccountPayableID As Integer = Nothing
        Private _GLTransaction As Integer = Nothing
        Private _SumAmount As Decimal = Nothing
        Private _SumShipping As Decimal = Nothing
        Private _SumSalesTax As Decimal = Nothing
        Private _Vendor As String = Nothing
        Private _Invoice As String = Nothing
        Private _InvoiceDate As Date = Nothing
        Private _DateToPay As Date = Nothing
        Private _Office As String = Nothing
        Private _Is1099Flag As Integer = Nothing
        Private _PaymentHold As Integer = Nothing
        Private _Terms As String = Nothing
        Private _DiscountPercent As Decimal = Nothing
        Private _GLACode As String = Nothing
        Private _GLAccount As String = Nothing
        Private _PostPeriodCode As String = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Status() As String
            Get
                Status = _Status
            End Get
            Set(ByVal value As String)
                _Status = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property AccountPayableID() As Integer
            Get
                AccountPayableID = _AccountPayableID
            End Get
            Set(ByVal value As Integer)
                _AccountPayableID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property GLTransaction() As Integer
            Get
                GLTransaction = _GLTransaction
            End Get
            Set(ByVal value As Integer)
                _GLTransaction = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property SumAmount() As Decimal
            Get
                SumAmount = _SumAmount
            End Get
            Set(ByVal value As Decimal)
                _SumAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property SumShipping() As Decimal
            Get
                SumShipping = _SumShipping
            End Get
            Set(ByVal value As Decimal)
                _SumShipping = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property SumSalesTax() As Decimal
            Get
                SumSalesTax = _SumSalesTax
            End Get
            Set(ByVal value As Decimal)
                _SumSalesTax = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Vendor() As String
            Get
                Vendor = _Vendor
            End Get
            Set(ByVal value As String)
                _Vendor = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Invoice() As String
            Get
                Invoice = _Invoice
            End Get
            Set(ByVal value As String)
                _Invoice = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property InvoiceDate() As Date
            Get
                InvoiceDate = _InvoiceDate
            End Get
            Set(ByVal value As Date)
                _InvoiceDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DateToPay() As Date
            Get
                DateToPay = _DateToPay
            End Get
            Set(ByVal value As Date)
                _DateToPay = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Office() As String
            Get
                Office = _Office
            End Get
            Set(ByVal value As String)
                _Office = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Is1099Flag() As Integer
            Get
                Is1099Flag = _Is1099Flag
            End Get
            Set(ByVal value As Integer)
                _Is1099Flag = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property PaymentHold() As Integer
            Get
                PaymentHold = _PaymentHold
            End Get
            Set(ByVal value As Integer)
                _PaymentHold = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Terms() As String
            Get
                Terms = _Terms
            End Get
            Set(ByVal value As String)
                _Terms = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DiscountPercent() As Decimal
            Get
                DiscountPercent = _DiscountPercent
            End Get
            Set(ByVal value As Decimal)
                _DiscountPercent = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property GLACode() As String
            Get
                GLACode = _GLACode
            End Get
            Set(ByVal value As String)
                _GLACode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property GLAccount() As String
            Get
                GLAccount = _GLAccount
            End Get
            Set(ByVal value As String)
                _GLAccount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property PostPeriodCode() As String
            Get
                PostPeriodCode = _PostPeriodCode
            End Get
            Set(ByVal value As String)
                _PostPeriodCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property CurrencyCode As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ForeignCurrencyTotal As Nullable(Of Decimal)

#End Region

#Region " Methods "

        Public Sub New()

        End Sub

#End Region

    End Class

End Namespace