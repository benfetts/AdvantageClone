Namespace BillingCommandCenter.Classes

    <Serializable()>
    Public Class MediaBillingHistory
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            InvoiceNumber
            InvoiceType
            InvoiceDate
            PostingPeriod
            Amount
            ResaleTax
            InvoiceTotal
            CurrencyCode
            CurrencyRate
            CurrencyAmount
            HasDocuments
            GLTransaction
        End Enum

#End Region

#Region " Variables "

        Private _InvoiceNumber As Nullable(Of Integer) = Nothing
        Private _InvoiceType As String = Nothing
        Private _InvoiceDate As Nullable(Of Date) = Nothing
        Private _PostingPeriod As String = Nothing
        Private _Amount As Nullable(Of Decimal) = Nothing
        Private _ResaleTax As Nullable(Of Decimal) = Nothing
        Private _InvoiceTotal As Nullable(Of Decimal) = Nothing
        Private _HasDocuments As Nullable(Of Boolean) = Nothing
        Private _GLTransaction As Nullable(Of Integer) = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InvoiceNumber() As Nullable(Of Integer)
            Get
                InvoiceNumber = _InvoiceNumber
            End Get
            Set(value As Nullable(Of Integer))
                _InvoiceNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InvoiceType() As String
            Get
                InvoiceType = _InvoiceType
            End Get
            Set(value As String)
                _InvoiceType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InvoiceDate() As Nullable(Of Date)
            Get
                InvoiceDate = _InvoiceDate
            End Get
            Set(value As Nullable(Of Date))
                _InvoiceDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PostingPeriod() As String
            Get
                PostingPeriod = _PostingPeriod
            End Get
            Set(value As String)
                _PostingPeriod = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property Amount() As Nullable(Of Decimal)
            Get
                Amount = _Amount
            End Get
            Set(value As Nullable(Of Decimal))
                _Amount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property ResaleTax() As Nullable(Of Decimal)
            Get
                ResaleTax = _ResaleTax
            End Get
            Set(value As Nullable(Of Decimal))
                _ResaleTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property InvoiceTotal() As Nullable(Of Decimal)
            Get
                InvoiceTotal = _InvoiceTotal
            End Get
            Set(value As Nullable(Of Decimal))
                _InvoiceTotal = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property CurrencyCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n6")>
        Public Property CurrencyRate() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property CurrencyAmount() As Nullable(Of Decimal)
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property HasDocuments() As Nullable(Of Boolean)
            Get
                HasDocuments = _HasDocuments
            End Get
            Set(value As Nullable(Of Boolean))
                _HasDocuments = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property GLTransaction() As Nullable(Of Integer)
            Get
                GLTransaction = _GLTransaction
            End Get
            Set(value As Nullable(Of Integer))
                _GLTransaction = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.InvoiceNumber.ToString

        End Function

#End Region

    End Class

End Namespace
