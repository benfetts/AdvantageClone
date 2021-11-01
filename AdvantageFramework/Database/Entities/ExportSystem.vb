Namespace Database.Entities

	<Table("EXPORT_SYSTEMS")>
	Public Class ExportSystem
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			SystemName
			Name
			Label
			MaxCharacters
            MinCharacters
        End Enum

        Public Enum SystemNames
            PAYMENT_MANAGER
            PAYROLL
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
		<Required>
		<MaxLength(20)>
        <Column("EXPORT_SYSTEM", Order:=0, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SystemName() As String
		<Key>
		<Required>
		<MaxLength(20)>
        <Column("ADV_COL_NAME", Order:=1, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Name() As String
		<MaxLength(30)>
		<Column("COLUMN_LABEL", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Label() As String
		<Required>
		<Column("MAX_CHAR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MaxCharacters() As Integer
		<Required>
		<Column("MIN_CHAR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MinCharacters() As Integer


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.SystemName

        End Function

#End Region

	End Class

End Namespace
