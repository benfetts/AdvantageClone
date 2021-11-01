Namespace AccountReceivable.Classes

    <Serializable()>
    Public Class ClientInvoicePaymentCheckDetail
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            InvoiceNumber
            SequenceNumber
            InvoiceDate
            AmountPaid
            WriteoffAmount
            OnAccountAmount
            Comment
            ClientCashReceiptID
        End Enum

#End Region

#Region " Variables "

        Private _InvoiceNumber As Nullable(Of Integer) = Nothing
        Private _SequenceNumber As Nullable(Of Short) = Nothing
        Private _InvoiceDate As Nullable(Of Date) = Nothing
        Private _AmountPaid As Nullable(Of Decimal) = Nothing
        Private _WriteoffAmount As Nullable(Of Decimal) = Nothing
        Private _OnAccountAmount As Nullable(Of Decimal) = Nothing
        Private _Comment As String = Nothing
        Private _ClientCashReceiptID As Integer = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property InvoiceNumber() As Nullable(Of Integer)
            Get
                InvoiceNumber = _InvoiceNumber
            End Get
            Set(value As Nullable(Of Integer))
                _InvoiceNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property SequenceNumber() As Nullable(Of Short)
            Get
                SequenceNumber = _SequenceNumber
            End Get
            Set(value As Nullable(Of Short))
                _SequenceNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property InvoiceDate() As Nullable(Of Date)
            Get
                InvoiceDate = _InvoiceDate
            End Get
            Set(value As Nullable(Of Date))
                _InvoiceDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, DisplayFormat:="n2")>
        Public Property AmountPaid() As Nullable(Of Decimal)
            Get
                AmountPaid = _AmountPaid
            End Get
            Set(value As Nullable(Of Decimal))
                _AmountPaid = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Write Off Amount")>
        Public Property WriteoffAmount() As Nullable(Of Decimal)
            Get
                WriteoffAmount = _WriteoffAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _WriteoffAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property OnAccountAmount() As Nullable(Of Decimal)
            Get
                OnAccountAmount = _OnAccountAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _OnAccountAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Comment() As String
            Get
                Comment = _Comment
            End Get
            Set(value As String)
                _Comment = value
            End Set
        End Property
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

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace

