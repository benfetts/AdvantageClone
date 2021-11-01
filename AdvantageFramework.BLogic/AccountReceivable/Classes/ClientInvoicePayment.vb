Namespace AccountReceivable.Classes

    <Serializable()>
    Public Class ClientInvoicePayment

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            CheckNumber
            CheckDate
            AmountPaid
            AdjustmentAmount
            GLACodeAdjustment
            ClientCashReceiptID
            PaymentType
        End Enum

#End Region

#Region " Variables "

        Private _CheckNumber As String = Nothing
        Private _CheckDate As Date = Nothing
        Private _AmountPaid As Decimal = Nothing
        Private _AdjustmentAmount As Decimal = Nothing
        Private _GLACodeAdjustment As String = Nothing
        Private _ClientCashReceiptID As Integer = Nothing
        Private _PaymentType As String = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property CheckNumber() As String
            Get
                CheckNumber = _CheckNumber
            End Get
            Set(value As String)
                _CheckNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property CheckDate() As Date
            Get
                CheckDate = _CheckDate
            End Get
            Set(value As Date)
                _CheckDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, DisplayFormat:="n2")>
        Public Property AmountPaid() As Decimal
            Get
                AmountPaid = _AmountPaid
            End Get
            Set(value As Decimal)
                _AmountPaid = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, DisplayFormat:="n2")>
        Public Property AdjustmentAmount() As Decimal
            Get
                AdjustmentAmount = _AdjustmentAmount
            End Get
            Set(value As Decimal)
                _AdjustmentAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Adjustment GL Account")>
        Public Property GLACodeAdjustment() As String
            Get
                GLACodeAdjustment = _GLACodeAdjustment
            End Get
            Set(value As String)
                _GLACodeAdjustment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property ClientCashReceiptID() As Integer
            Get
                ClientCashReceiptID = _ClientCashReceiptID
            End Get
            Set(value As Integer)
                _ClientCashReceiptID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property PaymentType() As String
            Get
                PaymentType = _PaymentType
            End Get
            Set(value As String)
                _PaymentType = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace

