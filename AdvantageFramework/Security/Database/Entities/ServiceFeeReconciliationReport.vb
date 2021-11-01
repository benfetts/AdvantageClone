Namespace Security.Database.Entities

	<Table("SERVICE_FEE_REPORT")>
	Public Class ServiceFeeReconciliationReport
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			Description
			CreatedByUserCode
			CreatedDate
			AllowCellMerge
			AutoSizeColumnsWhenPrinting
			PrintHeader
			PrintFooter
			PrintGroupFooter
			PrintSelectedRowsOnly
			PrintFilterInformation
			ShowViewCaption
			ShowGroupByBox
			ShowAutoFilterRow
			UpdatedByUserCode
			UpdatedDate
			ActiveFilter
			GroupByOption
			SummaryStyle
			ServiceFeeReconciliationReportColumns
			ServiceFeeReconciliationReportSummaryItems

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("SERVICE_FEE_REPORT_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ID() As Integer
		<Required>
		<MaxLength(50)>
		<Column("DESCRIPTION", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Description() As String
		<Required>
		<MaxLength(100)>
		<Column("CREATED_BY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CreatedByUserCode() As String
		<Required>
		<Column("CREATED_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CreatedDate() As Date
		<Required>
		<Column("ALLOW_CELL_MERGE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AllowCellMerge() As Boolean
		<Required>
		<Column("PRINT_AUTOSIZE_COL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AutoSizeColumnsWhenPrinting() As Boolean
		<Required>
		<Column("PRINT_HEADER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PrintHeader() As Boolean
		<Required>
		<Column("PRINT_FOOTER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PrintFooter() As Boolean
		<Required>
		<Column("PRINT_GROUP_FOOTER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PrintGroupFooter() As Boolean
		<Required>
		<Column("PRINT_SEL_ROWS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PrintSelectedRowsOnly() As Boolean
		<Required>
		<Column("PRINT_FILTER_INFO")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PrintFilterInformation() As Boolean
		<Required>
		<Column("SHOW_VIEW_CAPTION")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ShowViewCaption() As Boolean
		<Required>
		<Column("SHOW_GROUPBY_BOX")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ShowGroupByBox() As Boolean
		<Required>
		<Column("SHOW_AUTOFILTER_ROW")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ShowAutoFilterRow() As Boolean
		<Required>
		<MaxLength(100)>
		<Column("UPDATED_BY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UpdatedByUserCode() As String
		<Required>
		<Column("UPDATED_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UpdatedDate() As Date
		<Required>
		<MaxLength(8000)>
		<Column("ACTIVE_FILTER", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ActiveFilter() As String
		<Required>
		<Column("SERVICE_GROUP_BY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GroupByOption() As Integer
		<Required>
		<Column("SERVICE_SUMMARY_STYLE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SummaryStyle() As Integer

        Public Overridable Property ServiceFeeReconciliationReportColumn As ICollection(Of Database.Entities.ServiceFeeReconciliationReportColumn)
        Public Overridable Property ServiceFeeReconciliationReportSummaryItem As ICollection(Of Database.Entities.ServiceFeeReconciliationReportSummaryItem)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

	End Class

End Namespace
