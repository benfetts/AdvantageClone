Namespace Database.Entities

	<Table("GL_REPORT_ROW_RELATION")>
	Public Class GLReportTemplateRowRelation
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			GLReportTemplateID
			GLReportTemplateRowID
			RelatedRowIndex
			CreatedByUserCode
			CreatedDate
			Order
			GLReportTemplate
			GLReportTemplateRow

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("GL_REPORT_ROW_RELATION_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ID() As Integer
		<Required>
		<Column("GL_REPORT_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLReportTemplateID() As Integer
		<Required>
		<Column("GL_REPORT_ROW_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLReportTemplateRowID() As Integer
		<Required>
		<Column("RELATED_ROW_INDEX")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RelatedRowIndex() As Integer
		<Required>
		<MaxLength(100)>
		<Column("USER_CREATED", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CreatedByUserCode() As String
		<Required>
		<Column("CREATED_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CreatedDate() As Date
		<Required>
		<Column("ORDER")>
		Public Property Order() As Integer

        Public Overridable Property GLReportTemplate As Database.Entities.GLReportTemplate
        Public Overridable Property GLReportTemplateRow As Database.Entities.GLReportTemplateRow

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

	End Class

End Namespace
