Namespace DTO.FinanceAndAccounting

    <Serializable()>
    Public Class PaymentManagerReport

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            APCheckNumber
            APCheckDate
            APCheckAmount
            APDiscountAmount
            APGLTransaction
            PayToVenderCode
            EmailDate
            ExportDate
            EFileDate
            APInvoiceNumber
            APInvoiceDate
            APInvoiceAmount
            APGrossAmount
            APPaidDate
            VendorName
            VendorFaxNumber
            VendorEmail
            CheckAmount
            DiscountAmount
            PostPeriodCode
            CheckRunID
            BankCode
            APInvoiceDescription
            VendorPaymentManagerEmailAddress
            APID
            CheckNumber
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property APCheckNumber() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property APCheckDate() As Date
        <System.Runtime.Serialization.DataMemberAttribute()>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property APCheckAmount() As Nullable(Of Decimal)
        <System.Runtime.Serialization.DataMemberAttribute()>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property APDiscountAmount() As Nullable(Of Decimal)
        <System.Runtime.Serialization.DataMemberAttribute()>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property APGLTransaction() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property PayToVendorCode() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property EmailDate() As Nullable(Of Date)
        <System.Runtime.Serialization.DataMemberAttribute()>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ExportDate() As Nullable(Of Date)
        <System.Runtime.Serialization.DataMemberAttribute()>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property EFileDate() As Nullable(Of Date)
        <System.Runtime.Serialization.DataMemberAttribute()>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property APInvoiceNumber() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property APInvoiceDate() As Date
        <System.Runtime.Serialization.DataMemberAttribute()>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property APInvoiceAmount() As Decimal
        <System.Runtime.Serialization.DataMemberAttribute()>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property APGrossAmount() As Decimal
        <System.Runtime.Serialization.DataMemberAttribute()>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property APPaidDate() As Date
        <System.Runtime.Serialization.DataMemberAttribute()>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property VendorName() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property VendorFaxNumber() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property VendorEmail() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property CheckAmount() As Nullable(Of Decimal)
        <System.Runtime.Serialization.DataMemberAttribute()>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DiscountAmount() As Nullable(Of Decimal)
        <System.Runtime.Serialization.DataMemberAttribute()>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property PostPeriodCode() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property CheckRunID() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property BankCode() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property APInvoiceDescription() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property VendorPaymentManagerEmailAddress() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property APID() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property CheckNumber() As Integer

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace

