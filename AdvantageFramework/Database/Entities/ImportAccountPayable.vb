Namespace Database.Entities

	<Table("IMP_AP_HEADER")>
	Public Class ImportAccountPayable
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			BatchName
			VendorCode
			VendorName
			InvoiceNumber
			InvoiceDescription
			InvoiceDate
			InvoiceTotalNet
			InvoiceTotalTax
			OfficeCode
			IsOnHold
			ImportTemplateID
			GLAccount
            SourceCode
            StateTaxGLAccount
            CityTaxGLAccount
            StateTaxAmount
            CityTaxAmount
            ImportAccountPayableGLs
			ImportAccountPayableJobs
			ImportAccountPayableMedias
            ImportAccountPayableErrors
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("IMPORT_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Integer
        <MaxLength(50)>
        <Column("BATCH_NAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BatchName() As String
        <MaxLength(6)>
        <Column("VN_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorCode() As String
        <MaxLength(40)>
        <Column("VN_NAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorName() As String
        <MaxLength(20)>
        <Column("INV_NUMBER", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InvoiceNumber() As String
        <MaxLength(30)>
        <Column("INV_DESC", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InvoiceDescription() As String
        <Column("INV_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InvoiceDate() As Nullable(Of Date)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("INV_TOTAL_NET")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InvoiceTotalNet() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(11, 2)>
        <Column("INV_TOTAL_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InvoiceTotalTax() As Nullable(Of Decimal)
        <MaxLength(4)>
        <Column("OFFICE_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OfficeCode() As String
        <Required>
        <Column("ON_HOLD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsOnHold() As Boolean
        <Required>
        <Column("TEMPLATE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ImportTemplateID() As Short
        <MaxLength(30)>
        <Column("GLACODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLAccount() As String
        <MaxLength(2)>
        <Column("SOURCE_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SourceCode() As String
        <NotMapped>
        Public Property Is4AsCommissionOnly() As Boolean
        <MaxLength(30)>
        <Column("STATE_TAX_GLACCOUNT", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StateTaxGLAccount() As String
        <MaxLength(30)>
        <Column("CITY_TAX_GLACCOUNT", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CityTaxGLAccount() As String
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(11, 2)>
        <Column("STATE_TAX_AMOUNT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StateTaxAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(11, 2)>
        <Column("CITY_TAX_AMOUNT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CityTaxAmount() As Nullable(Of Decimal)

        Public Overridable Property ImportAccountPayableGLs As ICollection(Of Database.Entities.ImportAccountPayableGL)
        Public Overridable Property ImportAccountPayableJobs As ICollection(Of Database.Entities.ImportAccountPayableJob)
        Public Overridable Property ImportAccountPayableMedias As ICollection(Of Database.Entities.ImportAccountPayableMedia)
        Public Overridable Property ImportAccountPayableErrors As ICollection(Of Database.Entities.ImportAccountPayableError)

#End Region

#Region " Methods "

        Public Sub New()

            Me.ImportAccountPayableErrors = New HashSet(Of AdvantageFramework.Database.Entities.ImportAccountPayableError)
            Me.ImportAccountPayableGLs = New HashSet(Of AdvantageFramework.Database.Entities.ImportAccountPayableGL)
            Me.ImportAccountPayableJobs = New HashSet(Of AdvantageFramework.Database.Entities.ImportAccountPayableJob)
            Me.ImportAccountPayableMedias = New HashSet(Of AdvantageFramework.Database.Entities.ImportAccountPayableMedia)

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
