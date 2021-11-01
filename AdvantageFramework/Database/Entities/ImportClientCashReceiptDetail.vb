Namespace Database.Entities

    <NotMapped>
    <System.Data.Linq.Mapping.Table(Name:="dbo.IMP_CR_DETAIL")>
    Public Class ImportCashReceiptDetail
        Inherits AdvantageFramework.BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ImportCashReceiptID
            ARInvoiceNumber
            ARInvoiceSequence
            PaymentAmount
            AltInvoiceNumber
        End Enum

#End Region

#Region " Variables "

        Private _ID As Integer = 0
        Private _ImportCashReceiptID As Integer = 0
        Private _ARInvoiceNumber As System.Nullable(Of Integer) = Nothing
        Private _ARInvoiceSequence As System.Nullable(Of Short) = Nothing
        Private _PaymentAmount As System.Nullable(Of Decimal) = Nothing
        Private _AltInvoiceNumber As String = Nothing

#End Region

#Region " Properties "

        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ID", Storage:="_ID", IsPrimaryKey:=True, IsDbGenerated:=True, AutoSync:=System.Data.Linq.Mapping.AutoSync.OnInsert, DBType:="int NOT NULL IDENTITY"), _
        System.ComponentModel.DisplayName("ID")> _
        Public Property ID() As Integer
            Get
                ID = _ID
            End Get
            Set(ByVal value As Integer)
                _ID = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="IMPORT_ID", Storage:="_ImportCashReceiptID", DBType:="int"), _
        System.ComponentModel.DisplayName("ImportCashReceiptID")> _
        Public Property ImportCashReceiptID() As Integer
            Get
                ImportCashReceiptID = _ImportCashReceiptID
            End Get
            Set(ByVal value As Integer)
                _ImportCashReceiptID = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="AR_INV_NBR", Storage:="_ARInvoiceNumber", DBType:="int"), _
        System.ComponentModel.DisplayName("ARInvoiceNumber")> _
        Public Property ARInvoiceNumber() As System.Nullable(Of Integer)
            Get
                ARInvoiceNumber = _ARInvoiceNumber
            End Get
            Set(ByVal value As System.Nullable(Of Integer))
                _ARInvoiceNumber = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="AR_INV_SEQ", Storage:="_ARInvoiceSequence", DBType:="smallint"), _
        System.ComponentModel.DisplayName("ARInvoiceSequence")> _
        Public Property ARInvoiceSequence() As System.Nullable(Of Short)
            Get
                ARInvoiceSequence = _ARInvoiceSequence
            End Get
            Set(ByVal value As System.Nullable(Of Short))
                _ARInvoiceSequence = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="PAYMENT_AMT", Storage:="_PaymentAmount", DBType:="decimal"), _
        System.ComponentModel.DisplayName("PaymentAmount")> _
        Public Property PaymentAmount() As System.Nullable(Of Decimal)
            Get
                PaymentAmount = _PaymentAmount
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _PaymentAmount = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="ALT_INV_NBR", Storage:="_AltInvoiceNumber", DbType:="varchar"),
        System.ComponentModel.DisplayName("AltInvoiceNumber"),
        System.ComponentModel.DataAnnotations.MaxLength(40)>
        Public Property AltInvoiceNumber() As String
            Get
                AltInvoiceNumber = _AltInvoiceNumber
            End Get
            Set(ByVal value As String)
                _AltInvoiceNumber = value
            End Set
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
