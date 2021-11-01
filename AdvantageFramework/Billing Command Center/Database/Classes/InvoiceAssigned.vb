Namespace BillingCommandCenter.Database.Classes

    <Serializable()>
    Public Class InvoiceAssigned

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ARInvoiceNumber
            ARInvoiceSequence
            ARInvoiceDate
            ARInvoiceAmount
            CurrencyCode
            CurrencyRate
            CurrencyAmount
            RecordType
            AssignBy
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "


        Public Property ARInvoiceNumber() As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="AR Inv SEQ")>
        Public Property ARInvoiceSequence() As Short

        Public Property ARInvoiceDate() As Nullable(Of Date)

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property ARInvoiceAmount() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property CurrencyCode() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n6")>
        Public Property CurrencyRate() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property CurrencyAmount() As Nullable(Of Decimal)

        Public Property RecordType() As String

        Public Property AssignBy() As String

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ARInvoiceNumber.ToString

        End Function

#End Region

    End Class

End Namespace
