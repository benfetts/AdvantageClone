Namespace DTO.FinanceAndAccounting

    Public Class VATExportRow
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            DocumentType
            TransactionDate
            InvoiceNumber
            SupplierInvoiceNumber
            DocumentIndicator
            InvoiceDate
            Currency
            VATCode
            SupplierID
            SupplierName
            SupplierCountry
            SupplierVATNumberUsed
            SupplierCountryVATNumberUsed
            CustomerID
            CustomerName
            CustomerCountry
            CustomerVATNumberUsed
            CustomerCountryVATNumberUsed
            TaxableBasis
            ValueVAT
            SalesVATDueReverseCharge
            TotalValueLine
            AmountVATDeducted
            AmountVATReverseCharged
            Source
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property DocumentType() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property TransactionDate() As Nullable(Of Date)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property InvoiceNumber() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property SupplierInvoiceNumber() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property DocumentIndicator() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property InvoiceDate() As Nullable(Of Date)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Currency() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property VATCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property SupplierID() As String 'Long
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property SupplierName As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property SupplierCountry As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SupplierVATNumberUsed() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property SupplierCountryVATNumberUsed() As String
            Get
                SupplierCountryVATNumberUsed = If(SupplierVATNumberUsed IsNot Nothing AndAlso SupplierVATNumberUsed.Length > 2, Mid(SupplierVATNumberUsed, 1, 2), SupplierVATNumberUsed)
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property CustomerID() As String 'Long
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property CustomerName() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property CustomerCountry() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CustomerVATNumberUsed() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property CustomerCountryVATNumberUsed() As String
            Get
                CustomerCountryVATNumberUsed = If(CustomerVATNumberUsed IsNot Nothing AndAlso CustomerVATNumberUsed.Length > 2, Mid(CustomerVATNumberUsed, 1, 2), CustomerVATNumberUsed)
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n4")>
        Public Property TaxableBasis() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n4")>
        Public Property ValueVAT() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property SalesVATDueReverseCharge() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n4")>
        Public ReadOnly Property TotalValueLine() As Decimal
            Get
                TotalValueLine = TaxableBasis + ValueVAT
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n4")>
        Public Property AmountVATDeducted() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n4")>
        Public Property AmountVATReverseCharged() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Source() As String

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace
