Namespace MediaManager.Classes

    <Serializable()>
    Public Class MediaManagerAPInvoice

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            MediaType
            OrderNumber
            LineNumber
            OrderDescription
            VendorCode
            VendorName
            InvoiceNumber
            InvoiceDate
            InvoiceDescription
            InvoiceTotal
            Hold
            QTY
            Rate
            NetAmount
            DiscountAmount
            NetCharges
            VendorTax
            DisbursedAmount
            AccountPayableID
        End Enum

#End Region

#Region " Variables "

        Private _MediaType As String = Nothing
        Private _OrderNumber As Integer = Nothing
        Private _LineNumber As Short = Nothing
        Private _OrderDescription As String = Nothing
        Private _VendorCode As String = Nothing
        Private _VendorName As String = Nothing
        Private _InvoiceNumber As String = Nothing
        Private _InvoiceDate As Date = Nothing
        Private _InvoiceDescription As String = Nothing
        Private _InvoiceTotal As Decimal = Nothing
        Private _Hold As Boolean = False
        Private _QTY As Nullable(Of Decimal) = Nothing
        Private _Rate As Nullable(Of Decimal) = Nothing
        Private _NetAmount As Nullable(Of Decimal) = Nothing
        Private _DiscountAmount As Nullable(Of Decimal) = Nothing
        Private _NetCharges As Nullable(Of Decimal) = Nothing
        Private _VendorTax As Nullable(Of Decimal) = Nothing
        Private _DisbursedAmount As Decimal = Nothing
        Private _AccountPayableID As Integer = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MediaType() As String
            Get
                MediaType = _MediaType
            End Get
            Set(value As String)
                _MediaType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property OrderNumber() As Integer
            Get
                OrderNumber = _OrderNumber
            End Get
            Set(value As Integer)
                _OrderNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property LineNumber() As Short
            Get
                LineNumber = _LineNumber
            End Get
            Set(value As Short)
                _LineNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property OrderDescription() As String
            Get
                OrderDescription = _OrderDescription
            End Get
            Set(value As String)
                _OrderDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property VendorCode() As String
            Get
                VendorCode = _VendorCode
            End Get
            Set(value As String)
                _VendorCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property VendorName() As String
            Get
                VendorName = _VendorName
            End Get
            Set(value As String)
                _VendorName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property InvoiceNumber() As String
            Get
                InvoiceNumber = _InvoiceNumber
            End Get
            Set(value As String)
                _InvoiceNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property InvoiceDate() As Date
            Get
                InvoiceDate = _InvoiceDate
            End Get
            Set(value As Date)
                _InvoiceDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property InvoiceDescription() As String
            Get
                InvoiceDescription = _InvoiceDescription
            End Get
            Set(value As String)
                _InvoiceDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property InvoiceTotal() As Decimal
            Get
                InvoiceTotal = _InvoiceTotal
            End Get
            Set(value As Decimal)
                _InvoiceTotal = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Hold() As Boolean
            Get
                Hold = _Hold
            End Get
            Set(value As Boolean)
                _Hold = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property QTY() As Nullable(Of Decimal)
            Get
                QTY = _QTY
            End Get
            Set(value As Nullable(Of Decimal))
                _QTY = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property Rate() As Nullable(Of Decimal)
            Get
                Rate = _Rate
            End Get
            Set(value As Nullable(Of Decimal))
                _Rate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property NetAmount() As Nullable(Of Decimal)
            Get
                NetAmount = _NetAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _NetAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property DiscountAmount() As Nullable(Of Decimal)
            Get
                DiscountAmount = _DiscountAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _DiscountAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property NetCharges() As Nullable(Of Decimal)
            Get
                NetCharges = _NetCharges
            End Get
            Set(value As Nullable(Of Decimal))
                _NetCharges = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property VendorTax() As Nullable(Of Decimal)
            Get
                VendorTax = _VendorTax
            End Get
            Set(value As Nullable(Of Decimal))
                _VendorTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property DisbursedAmount() As Decimal
            Get
                DisbursedAmount = _DisbursedAmount
            End Get
            Set(value As Decimal)
                _DisbursedAmount = value
            End Set
        End Property
        '
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property AccountPayableID() As Integer
            Get
                AccountPayableID = _AccountPayableID
            End Get
            Set(value As Integer)
                _AccountPayableID = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace