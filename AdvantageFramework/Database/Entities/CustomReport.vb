Namespace Database.Entities

	<Table("ACCESS_FORMAT")>
	Public Class CustomReport
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			Name
			Description
			LegacyModuleCode
			IsCustom
			ReportCode
			IsInactive

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<MaxLength(50)>
		<Column("REPORT_NAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, CustomColumnCaption:="Report Name")>
		Public Property Name() As String
		<MaxLength(100)>
		<Column("DESCRIPTION", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
		Public Property Description() As String
		<MaxLength(2)>
		<Column("MODULE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, CustomColumnCaption:="Module")>
		Public Property LegacyModuleCode() As String
		<Column("CUSTOM")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Client Custom", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property IsCustom() As Nullable(Of Short)
		<Column("RPT_CODE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ReportCode() As Nullable(Of Integer)
		<Column("USE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.ReversedCheckBox)>
		Public Property IsInactive() As Nullable(Of Short)


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Name & " - " & Me.Description

        End Function

#End Region

	End Class

End Namespace
