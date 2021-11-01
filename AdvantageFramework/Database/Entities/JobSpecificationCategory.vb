Namespace Database.Entities

	<Table("JOB_SPEC_CATEGORY")>
	Public Class JobSpecificationCategory
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			Description
			JobSpecificationTypeCode
			SequenceNumber
			IsInactive
			JobSpecificationType
			JobSpecificationFields

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <DatabaseGenerated(DatabaseGeneratedOption.None)>
        <Required>
		<Column("CATEGORY_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ID() As Integer
		<Required>
		<MaxLength(32)>
		<Column("CATEGORY_DESC", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Description() As String
		<Required>
		<MaxLength(6)>
		<Column("SPEC_TYPE_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property JobSpecificationTypeCode() As String
		<Required>
		<Column("CATEGORY_SEQ")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property SequenceNumber() As Short
		<Required>
		<Column("INACTIVE_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property IsInactive() As Short

        Public Overridable Property JobSpecificationType As Database.Entities.JobSpecificationType
        Public Overridable Property JobSpecificationFields As ICollection(Of Database.Entities.JobSpecificationField)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

	End Class

End Namespace
