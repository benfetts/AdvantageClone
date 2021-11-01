Namespace Database.Classes

    <Serializable()>
    Public Class AccountReceivableClientInvoicesForVoid
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            InvoiceNumber
            InvoiceDate
            PostPeriodCode
            ClientCode
            ClientName
            InvoiceAmount
            Description
            IsManualInvoice
            RecordType
            QuickBooks
            AvaTaxPosted
        End Enum

#End Region

#Region " Variables "

        Private _InvoiceNumber As Integer = Nothing
        Private _InvoiceDate As Date = Nothing
        Private _PostPeriodCode As String = Nothing
        Private _ClientCode As String = Nothing
        Private _ClientName As String = Nothing
        Private _InvoiceAmount As Decimal = Nothing
        Private _Description As String = Nothing
        Private _IsManualInvoice As Boolean = Nothing
        Private _RecordType As String = Nothing
        Private _AvaTaxPosted As Boolean = False
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing
        Private _OfficeCode As String = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property InvoiceNumber() As Integer
            Get
                InvoiceNumber = _InvoiceNumber
            End Get
            Set(ByVal value As Integer)
                _InvoiceNumber = value
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
        Public Property PostPeriodCode() As String
            Get
                PostPeriodCode = _PostPeriodCode
            End Get
            Set(ByVal value As String)
                _PostPeriodCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(ByVal value As String)
                _ClientCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ClientName() As String
            Get
                ClientName = _ClientName
            End Get
            Set(ByVal value As String)
                _ClientName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(ByVal value As String)
                _DivisionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(ByVal value As String)
                _ProductCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property OfficeCode() As String
            Get
                OfficeCode = _OfficeCode
            End Get
            Set(ByVal value As String)
                _OfficeCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property InvoiceAmount() As Decimal
            Get
                InvoiceAmount = _InvoiceAmount
            End Get
            Set(ByVal value As Decimal)
                _InvoiceAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Description() As String
            Get
                Description = _Description
            End Get
            Set(ByVal value As String)
                _Description = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IsManualInvoice() As Boolean
            Get
                IsManualInvoice = _IsManualInvoice
            End Get
            Set(ByVal value As Boolean)
                _IsManualInvoice = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property RecordType() As String
            Get
                RecordType = _RecordType
            End Get
            Set(ByVal value As String)
                _RecordType = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property QuickBooks() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property AvaTaxPosted() As Boolean
            Get
                AvaTaxPosted = _AvaTaxPosted
            End Get
            Set(ByVal value As Boolean)
                _AvaTaxPosted = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

        End Sub

#End Region

    End Class

End Namespace

