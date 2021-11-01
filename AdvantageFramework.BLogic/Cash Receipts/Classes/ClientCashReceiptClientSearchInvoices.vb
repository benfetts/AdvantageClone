Namespace CashReceipts.Classes

    <Serializable()>
    Public Class ClientCashReceiptClientSearchInvoice
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ARInvoiceNumber
            ARInvoiceDate
            ClientName
            ClientCode
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property ARInvoiceNumber() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ARInvoiceDate() As Nullable(Of DateTime)
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ClientName() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ClientCode() As String

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace
