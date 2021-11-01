Namespace Database.Entities

    <Table("QUICKBOOKS_SETTING")>
    Public Class QuickbooksSetting
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            InvoiceEmployeeTimeItem
            InvoiceProductionItem
            InvoiceIncomeOnlyItem
            InvoiceOrderItem
            InvoiceNumberSuffix
            InvoiceLineProductionSalesClass
            InvoiceLineProductionJobNumber
            InvoiceLineProductionComponentNumber
            InvoiceLineProductionJobDescription
            InvoiceLineProductionComponentDescription
            InvoiceLineProductionFunctionDescription
            InvoiceLineMediaSalesClass
            InvoiceLineMediaOrderNumber
            InvoiceLineMediaOrderLineNumber
            BillMediaAccount
            BillNonClientAccount
            BillProductionAccount
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)>
        <Required>
        <Column("ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <MaxLength(21)>
        <Column("INVOICE_EMPLOYEE_TIME_ITEM", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InvoiceEmployeeTimeItem() As String
        <Required>
        <MaxLength(21)>
        <Column("INVOICE_PRODUCTION_ITEM", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InvoiceProductionItem() As String
        <Required>
        <MaxLength(21)>
        <Column("INVOICE_INCOME_ONLY_ITEM", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InvoiceIncomeOnlyItem() As String
        <Required>
        <MaxLength(21)>
        <Column("INVOICE_ORDER_ITEM", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InvoiceOrderItem() As String
        <Required>
        <MaxLength(5)>
        <Column("INVOICE_NUMBER_SUFFIX", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InvoiceNumberSuffix() As String
        <Required>
        <Column("INVOICE_LINE_PROD_SALES_CLASS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InvoiceLineProductionSalesClass() As Boolean
        <Required>
        <Column("INVOICE_LINE_PROD_JOB_NUMBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InvoiceLineProductionJobNumber() As Boolean
        <Required>
        <Column("INVOICE_LINE_PROD_COMPONENT_NUMBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InvoiceLineProductionComponentNumber() As Boolean
        <Required>
        <Column("INVOICE_LINE_PROD_JOB_DESCRIPTION")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InvoiceLineProductionJobDescription() As Boolean
        <Required>
        <Column("INVOICE_LINE_PROD_COMPONENT_DESCRIPTION")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InvoiceLineProductionComponentDescription() As Boolean
        <Required>
        <Column("INVOICE_LINE_PROD_FUNCTION_DESCRIPTION")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InvoiceLineProductionFunctionDescription() As Boolean
        <Required>
        <Column("INVOICE_LINE_MEDIA_SALES_CLASS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InvoiceLineMediaSalesClass() As Boolean
        <Required>
        <Column("INVOICE_LINE_MEDIA_ORDER_NUMBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InvoiceLineMediaOrderNumber() As Boolean
        <Required>
        <Column("INVOICE_LINE_MEDIA_ORDER_LINE_NUMBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InvoiceLineMediaOrderLineNumber() As Boolean
        <Required>
        <MaxLength(21)>
        <Column("BILL_MEDIA_ACCOUNT", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillMediaAccount() As String
        <Required>
        <MaxLength(21)>
        <Column("BILL_NON_CLIENT_ACCOUNT", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillNonClientAccount() As String
        <Required>
        <MaxLength(21)>
        <Column("BILL_PRODUCTION_ACCOUNT", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillProductionAccount() As String

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

    End Class

End Namespace
