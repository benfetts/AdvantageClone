Namespace CashReceipts.Classes

    <Serializable()>
    Public Class ClientCashReceiptBatchReport

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            GLTransaction
            ClientCashReceiptID
            ClientCashReceiptSequenceNumber
            Status
            CheckNumber
            CheckDate
            CheckAmount
            DepositDate
            PostPeriodCode
            Client
            Bank
            CashAccount
            Office
            BankCode
            CashAccountCode
            PaymentTypeDescription
        End Enum

#End Region

#Region " Variables "

        Private _GLTransaction As Integer = Nothing
        Private _ClientCashReceiptID As Integer = Nothing
        Private _ClientCashReceiptSequenceNumber As Short = Nothing
        Private _Status As String = Nothing
        Private _CheckNumber As String = Nothing
        Private _CheckDate As Date = Nothing
        Private _CheckAmount As Decimal = Nothing
        Private _DepositDate As Date = Nothing
        Private _PostPeriodCode As String = Nothing
        Private _Client As String = Nothing
        Private _Bank As String = Nothing
        Private _CashAccount As String = Nothing
        Private _Office As String = Nothing
        Private _BankCode As String = Nothing
        Private _CashAccountCode As String = Nothing
        Private _PaymentTypeDescription As String = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property GLTransaction() As Integer
            Get
                GLTransaction = _GLTransaction
            End Get
            Set(value As Integer)
                _GLTransaction = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ClientCashReceiptID() As Integer
            Get
                ClientCashReceiptID = _ClientCashReceiptID
            End Get
            Set(value As Integer)
                _ClientCashReceiptID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
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
        Public Property Status() As String
            Get
                Status = _Status
            End Get
            Set(value As String)
                _Status = value
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
        Public Property DepositDate() As Date
            Get
                DepositDate = _DepositDate
            End Get
            Set(value As Date)
                _DepositDate = value
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
        Public Property Client() As String
            Get
                Client = _Client
            End Get
            Set(value As String)
                _Client = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Bank() As String
            Get
                Bank = _Bank
            End Get
            Set(value As String)
                _Bank = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property CashAccount() As String
            Get
                CashAccount = _CashAccount
            End Get
            Set(value As String)
                _CashAccount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Office() As String
            Get
                Office = _Office
            End Get
            Set(value As String)
                _Office = value
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
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property CashAccountCode() As String
            Get
                CashAccountCode = _CashAccountCode
            End Get
            Set(value As String)
                _CashAccountCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property PaymentTypeDescription() As String
            Get
                PaymentTypeDescription = _PaymentTypeDescription
            End Get
            Set(value As String)
                _PaymentTypeDescription = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace

