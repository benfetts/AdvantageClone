Namespace Database.Views

    <Table("VENDOR_INVOICE_ALERT")>
    Public Class VendorInvoiceAlert
        Inherits BaseClasses.EntityView

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            AccountPayableID
            AccountPayableSequenceNumber
            VendorCode
            VendorName
            OfficeCode
            OfficeName
            VendorCategory
            InvoiceNumber
            InvoiceDate
            EntryDate
            InvoiceDescription
            InvoiceAmount
            PaymentHold
            Is1099Invoice
            Template
            State
            AssignedTo
            Priority
            DueDate
            TimeDue
            VendorOfficeCode
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
        <Column("AccountPayableSequenceNumber", Order:=1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property AccountPayableSequenceNumber() As Short
        <Required>
        <MaxLength(6)>
        <Column("VendorCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorCode() As String
        <MaxLength(40)>
        <Column("VendorName", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorName() As String
        <MaxLength(4)>
        <Column("OfficeCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OfficeCode() As String
        <MaxLength(30)>
        <Column("OfficeName", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OfficeName() As String
        <MaxLength(1)>
        <Column("VendorCategory", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Category")>
        Public Property VendorCategory() As String
        <Required>
        <MaxLength(20)>
        <Column("InvoiceNumber", TypeName:="varchar")>
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
        <BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("InvoiceAmount")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Invoice Total")>
        Public Property InvoiceAmount() As Decimal
        <Column("PaymentHold")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property PaymentHold() As Nullable(Of Short)
        <Column("Is1099Invoice")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Is 1099 Invoice", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property Is1099Invoice() As Nullable(Of Short)
        <MaxLength(100)>
        <Column("Template", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Template() As String
        <MaxLength(100)>
        <Column("State", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property State() As String
        <MaxLength(64)>
        <Column("AssignedTo", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AssignedTo() As String
        <MaxLength(7)>
        <Column("Priority", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Priority() As String
        <Column("DueDate")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DueDate() As Nullable(Of Date)
        <MaxLength(10)>
        <Column("TimeDue", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TimeDue() As String
        <MaxLength(4)>
        <Column("VendorOfficeCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property VendorOfficeCode() As String

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.AccountPayableID.ToString

        End Function

#End Region

    End Class

End Namespace
