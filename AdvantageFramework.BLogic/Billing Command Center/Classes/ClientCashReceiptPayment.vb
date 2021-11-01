Namespace BillingCommandCenter.Classes

    <Serializable()>
    Public Class ClientCashReceiptPayment

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            CheckNumber
            CheckDate
            PaymentAmount
            WriteoffAmount
            TotalAmount
        End Enum

#End Region

#Region " Variables "

        Private _CheckNumber As String = Nothing
        Private _CheckDate As Date = Nothing
        Private _PaymentAmount As Decimal = Nothing
        Private _WriteoffAmount As Decimal = Nothing

#End Region

#Region " Properties "

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
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property PaymentAmount() As Decimal
            Get
                PaymentAmount = _PaymentAmount
            End Get
            Set(value As Decimal)
                _PaymentAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property WriteoffAmount() As Decimal
            Get
                WriteoffAmount = _WriteoffAmount
            End Get
            Set(value As Decimal)
                _WriteoffAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public ReadOnly Property TotalAmount() As Decimal
            Get
                TotalAmount = _PaymentAmount + _WriteoffAmount
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace