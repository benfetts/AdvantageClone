Namespace Database.Entities

	<Table("JOB_SPEC_FIELDS")>
	Public Class JobSpecificationField
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			Name
			JobSpecificationTypeCode
			Description
			OldTableName
			OldFieldName
			JobSpecificationCategoryID
			SequenceNumber
			IsInactive
			IsRequired
			ValidationRule
			SeparatorLine
			JobSpecificationCategory
			JobSpecificationType

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<MaxLength(18)>
        <Column("FIELD_NAME", Order:=0, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Name() As String
		<Key>
		<Required>
		<MaxLength(6)>
        <Column("SPEC_TYPE_CODE", Order:=1, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobSpecificationTypeCode() As String
		<Required>
		<MaxLength(32)>
		<Column("FIELD_DESC", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Description() As String
		<MaxLength(18)>
		<Column("OLD_TABLE_NAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OldTableName() As String
		<MaxLength(18)>
		<Column("OLD_FIELD_NAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OldFieldName() As String
		<Required>
		<Column("CATEGORY_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobSpecificationCategoryID() As Integer
		<Required>
		<Column("FIELD_SEQ")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SequenceNumber() As Integer
		<Required>
		<Column("INACTIVE_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsInactive() As Short
		<Required>
		<Column("REQUIRED")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsRequired() As Short
		<MaxLength(254)>
		<Column("VALIDATION_RULE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ValidationRule() As String
		<Column("SEPARATOR_LINE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SeparatorLine() As Nullable(Of Short)

        Public Overridable Property JobSpecificationCategory As Database.Entities.JobSpecificationCategory
        Public Overridable Property JobSpecificationType As Database.Entities.JobSpecificationType

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Name.ToString

        End Function

#End Region

	End Class

End Namespace
