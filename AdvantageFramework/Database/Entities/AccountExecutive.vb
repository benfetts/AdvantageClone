Namespace Database.Entities

	<Table("ACCOUNT_EXECUTIVE")>
	Public Class AccountExecutive
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ClientCode
			DivisionCode
			ProductCode
			EmployeeCode
			IsInactive
			IsDefaultAccountExecutive
			ManagementLevelID
			Product
			Employee
			ManagementLevel

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<MaxLength(6)>
        <Column("CL_CODE", Order:=0, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.ClientCode)>
		Public Property ClientCode() As String
		<Key>
		<Required>
		<MaxLength(6)>
        <Column("DIV_CODE", Order:=1, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DivisionCode() As String
		<Key>
		<Required>
		<MaxLength(6)>
        <Column("PRD_CODE", Order:=2, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ProductCode() As String
		<Key>
		<Required>
		<MaxLength(6)>
        <Column("EMP_CODE", Order:=3, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EmployeeCode() As String
		<Column("INACTIVE_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property IsInactive() As Nullable(Of Short)
		<Column("DEFAULT_AE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsDefaultAccountExecutive() As Nullable(Of Short)
		<Required>
		<Column("MGMT_LVL_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ManagementLevelID() As Integer

        <ForeignKey("ClientCode, DivisionCode, ProductCode")>
        Public Overridable Property Product As Database.Entities.Product
        Public Overridable Property Employee As Database.Views.Employee
        Public Overridable Property ManagementLevel As Database.Entities.ManagementLevel

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ClientCode

        End Function

#End Region

	End Class

End Namespace
