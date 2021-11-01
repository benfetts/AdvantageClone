Namespace Security.Database.Entities

	<Table("SERVICE_FEE_REPORT_SUM")>
	Public Class ServiceFeeReconciliationReportSummaryItem
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			ServiceFeeReconciliationReportID
			SummaryItemType
			FieldName
			ColumnName
			DisplayFormat
			OnFooter
			GridViewID
			ServiceFeeReconciliationReport

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("SERVICE_FEE_REPORT_SUM_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ID() As Integer
		<Required>
		<Column("SERVICE_FEE_REPORT_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ServiceFeeReconciliationReportID() As Integer
		<Required>
		<Column("SUM_TYPE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SummaryItemType() As Integer
		<Required>
		<MaxLength(100)>
		<Column("FIELD_NAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property FieldName() As String
		<Required>
		<MaxLength(100)>
		<Column("COLUMN_NAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ColumnName() As String
		<Required>
		<MaxLength(1000)>
		<Column("DISPLAY_FORMAT", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DisplayFormat() As String
		<Required>
		<Column("ON_FOOTER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OnFooter() As Boolean
		<Required>
		<Column("GRIDVIEW_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GridViewID() As Integer

        Public Overridable Property ServiceFeeReconciliationReport As Database.Entities.ServiceFeeReconciliationReport

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

	End Class

End Namespace
