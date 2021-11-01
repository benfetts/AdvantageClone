Namespace CashReceipts.Classes

    <Serializable()>
    Public Class ClientCashReceiptDetail

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ClientCashReceiptID
            ClientCashReceiptSequenceNumber
            ClientCode
            DivisionCode
            ProductCode
            OfficeCode
            BankCode
            ARInvoiceNumber
            CheckNumber
            PostPeriodCode
            CheckDate
            CheckAmount
            DepositDate
            GLACode
            PaymentAmount
            WriteoffAmount
        End Enum

#End Region

#Region " Variables "

        Private _ClientCashReceiptID As Integer = Nothing
        Private _ClientCashReceiptSequenceNumber As Short = Nothing
        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing
        Private _OfficeCode As String = Nothing
        Private _BankCode As String = Nothing
        Private _ARInvoiceNumber As Nullable(Of Integer) = Nothing
        Private _CheckNumber As String = Nothing
        Private _PostPeriodCode As String = Nothing
        Private _CheckDate As Date = Nothing
        Private _CheckAmount As Decimal = Nothing
        Private _DepositDate As Nullable(Of Date) = Nothing
        Private _GLACode As String = Nothing
        Private _PaymentAmount As Decimal = Nothing
        Private _WriteoffAmount As Decimal = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ClientCashReceiptID() As Integer
            Get
                ClientCashReceiptID = _ClientCashReceiptID
            End Get
            Set(value As Integer)
                _ClientCashReceiptID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ClientCashReceiptSequenceNumber() As Short
            Get
                ClientCashReceiptSequenceNumber = _ClientCashReceiptSequenceNumber
            End Get
            Set(value As Short)
                _ClientCashReceiptSequenceNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ARInvoiceNumber() As Nullable(Of Integer)
            Get
                ARInvoiceNumber = _ARInvoiceNumber
            End Get
            Set(value As Nullable(Of Integer))
                _ARInvoiceNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property PaymentAmount() As Decimal
            Get
                PaymentAmount = _PaymentAmount
            End Get
            Set(value As Decimal)
                _PaymentAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Write Off Amount")>
        Public Property WriteoffAmount() As Decimal
            Get
                WriteoffAmount = _WriteoffAmount
            End Get
            Set(value As Decimal)
                _WriteoffAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property CheckNumber() As String
            Get
                CheckNumber = _CheckNumber
            End Get
            Set(value As String)
                _CheckNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property PostPeriodCode() As String
            Get
                PostPeriodCode = _PostPeriodCode
            End Get
            Set(value As String)
                _PostPeriodCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property CheckDate() As Date
            Get
                CheckDate = _CheckDate
            End Get
            Set(value As Date)
                _CheckDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property CheckAmount() As Decimal
            Get
                CheckAmount = _CheckAmount
            End Get
            Set(value As Decimal)
                _CheckAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DepositDate() As Nullable(Of Date)
            Get
                DepositDate = _DepositDate
            End Get
            Set(value As Nullable(Of Date))
                _DepositDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property GLACode() As String
            Get
                GLACode = _GLACode
            End Get
            Set(value As String)
                _GLACode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(value As String)
                _DivisionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(value As String)
                _ProductCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property OfficeCode() As String
            Get
                OfficeCode = _OfficeCode
            End Get
            Set(value As String)
                _OfficeCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property BankCode() As String
            Get
                BankCode = _BankCode
            End Get
            Set(value As String)
                _BankCode = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ClientCashReceiptID.ToString

        End Function

#End Region

    End Class

End Namespace

