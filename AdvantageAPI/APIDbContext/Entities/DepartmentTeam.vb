<Table("DEPT_TEAM")>
Public Class DepartmentTeam

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

	<Key>
	<Required>
	<MaxLength(4)>
	<Column("DP_TM_CODE", TypeName:="varchar")>
	Public Property Code() As String
	<MaxLength(30)>
	<Column("DP_TM_DESC", TypeName:="varchar")>
	Public Property Description() As String
	<Column("INACTIVE_FLAG")>
	Public Property IsInactive() As Nullable(Of Short)

#End Region

#Region " Methods "



#End Region

End Class
