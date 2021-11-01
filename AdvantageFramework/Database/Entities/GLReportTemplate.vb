Namespace Database.Entities

	<Table("GL_REPORT")>
	Public Class GLReportTemplate
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Description
            DashboardLayout
            PostPeriodCode
            ReportType
            CreatedByUserCode
            CreatedDate
            ModifiedByUserCode
            ModifiedDate
            GLReportUserDefReportID
            PrintColumnHeadingsOnEveryPage
            SortRowsBy
            CurrencyCode
            CurrencyRate
            GLReportTemplateColumns
            GLReportTemplateRows
            GLReportTemplateRowRelations
            GLReportTemplateDepartmentTeamPresets
            GLReportTemplateOfficePresets
            GLReportTemplatePctOfRowColumnRelations
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("GL_REPORT_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ID() As Integer
		<Required>
		<MaxLength(100)>
		<Column("DESCRIPTION", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Description() As String
		<Required>
		<Column("DASHBOARD_LAYOUT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property DashboardLayout() As Byte()
		<Required>
		<MaxLength(6)>
		<Column("PPPERIOD", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property PostPeriodCode() As String
		<Required>
		<Column("REPORT_TYPE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ReportType() As Integer
		<Required>
		<MaxLength(100)>
		<Column("USER_CREATED", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CreatedByUserCode() As String
		<Required>
		<Column("CREATED_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CreatedDate() As Date
		<MaxLength(100)>
		<Column("USER_MODIFIED", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ModifiedByUserCode() As String
		<Column("MODIFIED_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ModifiedDate() As Nullable(Of Date)
		<Column("GL_REPORT_UDR_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property GLReportUserDefReportID() As Nullable(Of Integer)
		<Required>
		<Column("PRINT_COLUMN_HEADINGS_EVERY_PAGE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PrintColumnHeadingsOnEveryPage() As Boolean
		<Required>
		<Column("SORT_ROWS_BY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SortRowsBy() As Integer
        <Column("CURRENCY_CODE", TypeName:="varchar")>
        <MaxLength(5)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CurrencyCode() As String
        <Column("CURRENCY_RATE")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(12, 6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n6", UseMinValue:=True, MinValue:=0.000001)>
        Public Property CurrencyRate() As Nullable(Of Decimal)

        Public Overridable Property GLReportTemplateColumns As ICollection(Of Database.Entities.GLReportTemplateColumn)
        Public Overridable Property GLReportTemplateRows As ICollection(Of Database.Entities.GLReportTemplateRow)
        Public Overridable Property GLReportTemplateRowRelations As ICollection(Of Database.Entities.GLReportTemplateRowRelation)
        Public Overridable Property GLReportTemplateDepartmentTeamPresets As ICollection(Of Database.Entities.GLReportTemplateDepartmentTeamPreset)
        Public Overridable Property GLReportTemplateOfficePresets As ICollection(Of Database.Entities.GLReportTemplateOfficePreset)
        Public Overridable Property GLReportTemplatePctOfRowColumnRelations As ICollection(Of Database.Entities.GLReportTemplatePctOfRowColumnRelation)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

	End Class

End Namespace
