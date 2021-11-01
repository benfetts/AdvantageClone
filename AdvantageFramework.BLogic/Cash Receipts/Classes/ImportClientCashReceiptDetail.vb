Namespace CashReceipts.Classes

    <Serializable()>
    Public Class ImportClientCashReceiptDetail
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ARInvoiceNumber
            ARInvoiceSequence
            ClientCode
            ClientName
            PaymentAmount
            DetailID
            AltInvoiceNumber
        End Enum

#End Region

#Region " Variables "

        Private _ImportCashReceiptDetail As AdvantageFramework.Database.Entities.ImportCashReceiptDetail = Nothing
        Private _ClientCode As String = Nothing
        Private _ClientName As String = Nothing
        Private _ImportClientCashReceiptHeader As AdvantageFramework.CashReceipts.Classes.ImportClientCashReceiptHeader = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ARInvoiceNumber() As Nullable(Of Integer)
            Get
                ARInvoiceNumber = _ImportCashReceiptDetail.ARInvoiceNumber
            End Get
            Set(value As Nullable(Of Integer))
                _ImportCashReceiptDetail.ARInvoiceNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property ARInvoiceSequence() As Nullable(Of Short)
            Get
                ARInvoiceSequence = _ImportCashReceiptDetail.ARInvoiceSequence
            End Get
            Set(value As Nullable(Of Short))
                _ImportCashReceiptDetail.ARInvoiceSequence = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientName() As String
            Get
                ClientName = _ClientName
            End Get
            Set(value As String)
                _ClientName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n2")>
        Public Property PaymentAmount() As Nullable(Of Decimal)
            Get
                PaymentAmount = _ImportCashReceiptDetail.PaymentAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _ImportCashReceiptDetail.PaymentAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DetailID() As Integer
            Get
                DetailID = _ImportCashReceiptDetail.ID
            End Get
            Set(value As Integer)
                _ImportCashReceiptDetail.ID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property AltInvoiceNumber() As String
            Get
                AltInvoiceNumber = _ImportCashReceiptDetail.AltInvoiceNumber
            End Get
            Set(value As String)
                _ImportCashReceiptDetail.AltInvoiceNumber = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            _ImportCashReceiptDetail = New AdvantageFramework.Database.Entities.ImportCashReceiptDetail
            _ImportClientCashReceiptHeader = New AdvantageFramework.CashReceipts.Classes.ImportClientCashReceiptHeader

        End Sub
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.CashReceipts.Classes.ImportClientCashReceiptDetail.Properties.ARInvoiceNumber.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing AndAlso Me.ARInvoiceSequence IsNot Nothing AndAlso
                              (From AR In AdvantageFramework.Database.Procedures.AccountReceivable.LoadNonVoidedInvoices(DbContext)
                               Where AR.InvoiceNumber = DirectCast(PropertyValue, Integer) AndAlso
                                     AR.SequenceNumber = Me.ARInvoiceSequence
                               Select AR).Any = False Then

                        IsValid = True

                        ErrorText = "Invalid invoice number."

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function
        Public Function ErrorHashtable() As System.Collections.Hashtable

            ErrorHashtable = Me._ErrorHashtable

        End Function

#End Region

    End Class

End Namespace
