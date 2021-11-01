Namespace CashReceipts.Classes

    <Serializable()>
    Public Class ClientCashReceiptPaymentDetail
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            JobNumber
            JobComponentNumber
            FunctionType
            FunctionCode
            MediaType
            OrderNumber
            OrderLineNumber
            PaymentAmount
            TotalBill
        End Enum

#End Region

#Region " Variables "

        Private _JobNumber As Nullable(Of Integer) = Nothing
        Private _JobComponentNumber As Nullable(Of Short) = Nothing
        Private _FunctionType As String = Nothing
        Private _FunctionCode As String = Nothing
        Private _MediaType As String = Nothing
        Private _OrderNumber As Nullable(Of Integer) = Nothing
        Private _OrderLineNumber As Nullable(Of Short) = Nothing
        Private _PaymentAmount As Nullable(Of Decimal) = Nothing
        Private _TotalBill As Nullable(Of Decimal) = Nothing
        Private _ClientCashReceiptsPartialPaymentRequired As Boolean = False

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property JobNumber() As Nullable(Of Integer)
            Get
                JobNumber = _JobNumber
            End Get
            Set(value As Nullable(Of Integer))
                _JobNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Job Comp")>
        Public Property JobComponentNumber() As Nullable(Of Short)
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(value As Nullable(Of Short))
                _JobComponentNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property FunctionType() As String
            Get
                FunctionType = _FunctionType
            End Get
            Set(value As String)
                _FunctionType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Function")>
        Public Property FunctionCode() As String
            Get
                FunctionCode = _FunctionCode
            End Get
            Set(value As String)
                _FunctionCode = value
            End Set
        End Property
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
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Order")>
        Public Property OrderNumber() As Nullable(Of Integer)
            Get
                OrderNumber = _OrderNumber
            End Get
            Set(value As Nullable(Of Integer))
                _OrderNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Line")>
        Public Property OrderLineNumber() As Nullable(Of Short)
            Get
                OrderLineNumber = _OrderLineNumber
            End Get
            Set(value As Nullable(Of Short))
                _OrderLineNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property PaymentAmount() As Nullable(Of Decimal)
            Get
                PaymentAmount = _PaymentAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _PaymentAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property TotalBill() As Nullable(Of Decimal)
            Get
                TotalBill = _TotalBill
            End Get
            Set(value As Nullable(Of Decimal))
                _TotalBill = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property ClientCashReceiptsPartialPaymentRequired() As Boolean
            Get
                ClientCashReceiptsPartialPaymentRequired = _ClientCashReceiptsPartialPaymentRequired
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(ByVal AccountReceivableSummary As AdvantageFramework.Database.Entities.AccountReceivableSummary, ByVal ClientCashReceiptsPartialPaymentRequired As Boolean)

            _JobNumber = AccountReceivableSummary.JobNumber
            _JobComponentNumber = AccountReceivableSummary.JobComponentNumber
            _FunctionType = AccountReceivableSummary.FunctionType
            _FunctionCode = AccountReceivableSummary.FunctionCode
            _MediaType = AccountReceivableSummary.MediaType
            _OrderNumber = AccountReceivableSummary.OrderNumber
            _OrderLineNumber = AccountReceivableSummary.OrderLineNumber
            _TotalBill = AccountReceivableSummary.TotalBillAmount

            _ClientCashReceiptsPartialPaymentRequired = ClientCashReceiptsPartialPaymentRequired

        End Sub
        Public Sub New(ByVal ClientCashReceiptPaymentDetail As AdvantageFramework.CashReceipts.Classes.ClientCashReceiptPaymentDetail)

            _JobNumber = ClientCashReceiptPaymentDetail.JobNumber
            _JobComponentNumber = ClientCashReceiptPaymentDetail.JobComponentNumber
            _FunctionType = ClientCashReceiptPaymentDetail.FunctionType
            _FunctionCode = ClientCashReceiptPaymentDetail.FunctionCode
            _MediaType = ClientCashReceiptPaymentDetail.MediaType
            _OrderNumber = ClientCashReceiptPaymentDetail.OrderNumber
            _OrderLineNumber = ClientCashReceiptPaymentDetail.OrderLineNumber
            _PaymentAmount = ClientCashReceiptPaymentDetail.PaymentAmount
            _TotalBill = ClientCashReceiptPaymentDetail.TotalBill
            _ClientCashReceiptsPartialPaymentRequired = ClientCashReceiptPaymentDetail.ClientCashReceiptsPartialPaymentRequired

        End Sub

#End Region

    End Class

End Namespace

