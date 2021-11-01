Namespace BillingCommandCenter.Database.Classes

    <Serializable()>
    Public Class BillingHistory

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            InvoiceNumber
            InvoiceType
            InvoiceDate
            PostingPeriod
            RetainedAdvanceBilling
            IncomeRecognized
            HasDocuments
            Hours
            QTY
            Actual
            AdvanceAmount
            Amount
            ResaleTax
            InvoiceTotal
            ReconciledMethod
            GLTransaction
            CurrencyCode
            CurrencyRate
            CurrencyAmount
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property InvoiceNumber() As Nullable(Of Integer)

        Public Property InvoiceType() As String

        Public Property InvoiceDate() As Nullable(Of Date)

        Public Property PostingPeriod() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property Hours() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property QTY() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property Actual() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AdvanceAmount() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property RetainedAdvanceBilling() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property Amount() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property ResaleTax() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property InvoiceTotal() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property CurrencyCode() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n6")>
        Public Property CurrencyRate() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property CurrencyAmount() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property IncomeRecognized() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.ImageWhenCheckedCheckBox)>
        Public Property HasDocuments() As Nullable(Of Boolean)

        Public Property ReconciledMethod() As String

        Public Property GLTransaction() As Nullable(Of Integer)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.InvoiceNumber.ToString

        End Function

#End Region

    End Class

End Namespace
