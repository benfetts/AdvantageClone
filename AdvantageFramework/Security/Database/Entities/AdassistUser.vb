Namespace Security.Database.Entities

	<Table("APPR_PASSWORD")>
	Public Class AdassistUser
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			EmployeeCode
			Password
			UserCode
			CreatedDate
			IsInactive
			Employee

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<MaxLength(6)>
		<Column("ACCT_EXEC", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EmployeeCode() As String
		<Required>
		<MaxLength(20)>
		<Column("PASSWORD_ID", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Password() As String
		<Required>
		<MaxLength(100)>
		<Column("USER_ID", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UserCode() As String
		<Column("DATE_CREATED")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CreatedDate() As Nullable(Of Date)
		<Column("INACTIVE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsInactive() As Nullable(Of Short)

        Public Overridable Property Employee As Database.Views.Employee

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.EmployeeCode

        End Function

#End Region

	End Class

End Namespace
