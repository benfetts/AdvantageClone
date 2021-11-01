Namespace Database.Entities

	<Table("EMP_OFFICE")>
	Public Class EmployeeOffice
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			EmployeeCode
			OfficeCode
			UserGroupCode
			Employee
			Office

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
		<MaxLength(4)>
        <Column("OFFICE_CODE", Order:=1, TypeName:="varchar")>
        Public Property OfficeCode() As String
		<MaxLength(6)>
		<Column("GROUP_CODE", TypeName:="varchar")>
		Public Property UserGroupCode() As String

        Public Overridable Property Employee As Database.Views.Employee
        Public Overridable Property Office As Database.Entities.Office

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.EmployeeCode

        End Function

#End Region

	End Class

End Namespace
