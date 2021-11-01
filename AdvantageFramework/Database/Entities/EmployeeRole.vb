Namespace Database.Entities

	<Table("EMP_TRAFFIC_ROLE")>
	Public Class EmployeeRole
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			EmployeeCode
			RoleCode
			Role

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<MaxLength(6)>
        <Column("EMP_CODE", Order:=0, TypeName:="varchar")>
        Public Property EmployeeCode() As String
		<Key>
		<Required>
		<MaxLength(6)>
        <Column("ROLE_CODE", Order:=1, TypeName:="varchar")>
        Public Property RoleCode() As String

        Public Overridable Property Role As Database.Entities.Role

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.EmployeeCode

        End Function

#End Region

	End Class

End Namespace
