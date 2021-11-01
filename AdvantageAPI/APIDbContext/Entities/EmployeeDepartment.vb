<Table("EMP_DP_TM")>
Public Class EmployeeDepartmentTeam

#Region " Constants "



#End Region

#Region " Enum "



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
	<Column("DP_TM_CODE", Order:=1, TypeName:="varchar")>
	Public Property DepartmentTeamCode() As String
	<MaxLength(30)>
	<Column("DP_TM_DESC", TypeName:="varchar")>
	Public Property DepartmentName() As String

#End Region

#Region " Methods "



#End Region

End Class
