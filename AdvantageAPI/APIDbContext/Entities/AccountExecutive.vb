<Table("ACCOUNT_EXECUTIVE")>
Public Class AccountExecutive

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
	<Column("CL_CODE", Order:=0, TypeName:="varchar")>
	Public Property ClientCode() As String
	<Key>
	<Required>
	<MaxLength(6)>
	<Column("DIV_CODE", Order:=1, TypeName:="varchar")>
	Public Property DivisionCode() As String
	<Key>
	<Required>
	<MaxLength(6)>
	<Column("PRD_CODE", Order:=2, TypeName:="varchar")>
	Public Property ProductCode() As String
	<Key>
	<Required>
	<MaxLength(6)>
	<Column("EMP_CODE", Order:=3, TypeName:="varchar")>
	Public Property EmployeeCode() As String
	<Column("INACTIVE_FLAG")>
	Public Property IsInactive() As Nullable(Of Short)
	<Column("DEFAULT_AE")>
	Public Property IsDefaultAccountExecutive() As Nullable(Of Short)

#End Region

#Region " Methods "



#End Region

End Class
