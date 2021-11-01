Namespace Database.Entities

	<Table("COMBO_INV_DEF")>
	Public Class ComboInvoiceDefault
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
			ID
			ClientOrDefault
			ClientCode
			AddressBlockType
			LocationCode
			CustomFormatName
			ApplyExchangeRate
			ExchangeRateAmount
			PrintClientName
			PrintDivisionName
			PrintProductDescription
			PrintContactAfterAddress
			UseInvoiceCategoryDescription
			InvoiceTitle
			InvoiceFooterCommentType
			InvoiceFooterComment
			ShowCodes
			ContactType
			IncludeInvoiceDueDate
            PageSetting
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("COMBO_INV_DEF_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ID() As Integer
		<Column("CLIENT_OR_DEF")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ClientOrDefault() As Nullable(Of Short)
		<MaxLength(6)>
		<Column("CL_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ClientCode() As String
		<Column("ADDRESS_BLOCK")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AddressBlockType() As Nullable(Of Short)
		<MaxLength(50)>
		<Column("PRT_LOC_PG_FTR_DEF", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property LocationCode() As String
		<MaxLength(255)>
		<Column("CUSTOM_FORMAT", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CustomFormatName() As String
		<Column("COL_OPT_XCHGE_AMTS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ApplyExchangeRate() As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(10, 4)>
        <Column("COL_OPT_XCHGE_DEF")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ExchangeRateAmount() As Nullable(Of Decimal)
		<Required>
		<Column("PRINT_CLIENT_NAME")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PrintClientName() As Boolean
		<Required>
		<Column("PRINT_DIV_NAME")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PrintDivisionName() As Boolean
		<Required>
		<Column("PRINT_PRD_DESC")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PrintProductDescription() As Boolean
		<Required>
		<Column("CONTACT_POS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PrintContactAfterAddress() As Boolean
		<Required>
		<Column("INV_CAT_TITLE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UseInvoiceCategoryDescription() As Boolean
		<MaxLength(20)>
		<Column("INV_TITLE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InvoiceTitle() As String
		<Required>
		<Column("TOT_PAYMNT_TERMS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InvoiceFooterCommentType() As Short
		<MaxLength(50)>
		<Column("TOT_PAYMNT_TERMS_DEF", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InvoiceFooterComment() As String
		<Required>
		<Column("SHOW_CODES")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ShowCodes() As Boolean
		<Required>
		<Column("CONTACT_TYPE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ContactType() As Integer
		<Required>
		<Column("PRT_DUE_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IncludeInvoiceDueDate() As Boolean
        <Required>
        <Column("PAGE_SETTING")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PageSetting() As Short

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

	End Class

End Namespace
