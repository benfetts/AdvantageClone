Namespace Database.Entities

	<Table("JOB_TMPLT_DTL")>
	Public Class JobTemplateDetail
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			JobTemplateCode
			SequenceNumber
			ItemCode
			Label
			SectionOrder
			ItemOrder
			Include
			IsRequired
			JobTemplate
			JobTemplateItem

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<MaxLength(6)>
        <Column("JOB_TMPLT_CODE", Order:=0, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property JobTemplateCode() As String
		<Key>
		<Required>
        <Column("SEQ_NBR", Order:=1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property SequenceNumber() As Short
		<Required>
		<MaxLength(32)>
		<Column("ITEM_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ItemCode() As String
		<MaxLength(50)>
		<Column("LABEL", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Label() As String
		<Column("SECTION_ORDER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property SectionOrder() As Nullable(Of Short)
		<Column("ITEM_ORDER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ItemOrder() As Nullable(Of Short)
		<Required>
		<Column("INCLUDE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="On")>
		Public Property Include() As Byte
		<Required>
		<Column("REQUIRED")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Required")>
		Public Property IsRequired() As Byte

        Public Overridable Property JobTemplate As Database.Entities.JobTemplate
        <ForeignKey("ItemCode")>
        Public Overridable Property JobTemplateItem As Database.Entities.JobTemplateItem

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.JobTemplateCode.ToString

        End Function

#End Region

	End Class

End Namespace
