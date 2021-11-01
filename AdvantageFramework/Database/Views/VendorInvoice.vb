Namespace Database.Views

    <Table("VENDOR_INVOICE")>
    Public Class VendorInvoice
        Inherits BaseClasses.EntityView

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            AccountPayableID
            SequenceNumber
            VendorCode
            VendorName
            VendorPayToName
            VendorCategory
            OfficeCode
            OfficeName
            MarketCode
            MarketDescription
            InvoiceNumber
            InvoiceDate
            EntryDate
            InvoiceDescription
            InvoiceAmount
            PaymentHold
            Is1099Invoice
            VendorOfficeCode
            QuickBooks
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <Column("AccountPayableID", Order:=0)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property AccountPayableID() As Integer
        <Key>
        <Required>
        <Column("SequenceNumber", Order:=1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property SequenceNumber() As Short
        <Key>
        <Required>
        <MaxLength(6)>
        <Column("VendorCode", Order:=2, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorCode() As String
        <MaxLength(40)>
        <Column("VendorName", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorName() As String
        <MaxLength(40)>
        <Column("VendorPayToName", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorPayToName() As String
        <MaxLength(1)>
        <Column("VendorCategory", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Category")>
        Public Property VendorCategory() As String
        <Key>
        <Required>
        <MaxLength(20)>
        <Column("InvoiceNumber", Order:=3, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InvoiceNumber() As String
        <Required>
        <Column("InvoiceDate")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InvoiceDate() As Date
        <Column("EntryDate")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EntryDate() As Nullable(Of Date)
        <MaxLength(30)>
        <Column("InvoiceDescription", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InvoiceDescription() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("InvoiceAmount")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Invoice Total")>
        Public Property InvoiceAmount() As Decimal
        <Column("PaymentHold")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property PaymentHold() As Nullable(Of Short)
        <Column("Is1099Invoice")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Is 1099 Invoice", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property Is1099Invoice() As Nullable(Of Short)
        <MaxLength(4)>
        <Column("OfficeCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OfficeCode() As String
        <MaxLength(30)>
        <Column("OfficeName", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OfficeName() As String
        <MaxLength(10)>
        <Column("MarketCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MarketCode() As String
        <MaxLength(40)>
        <Column("MarketDescription", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MarketDescription() As String
        <MaxLength(4)>
        <Column("VendorOfficeCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property VendorOfficeCode() As String
        <Column("QuickBooks")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="QuickBooks")>
        Public Property QuickBooks() As Boolean

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.AccountPayableID.ToString

        End Function

#End Region

    End Class

End Namespace
