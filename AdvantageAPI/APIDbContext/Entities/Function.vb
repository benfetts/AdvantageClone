<Table("FUNCTIONS")>
Public Class [Function]

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
	<Column("FNC_CODE", TypeName:="varchar")>
	Public Property Code() As String
	<MaxLength(30)>
	<Column("FNC_DESCRIPTION", TypeName:="varchar")>
	Public Property Description() As String
	<Required>
	<MaxLength(1)>
	<Column("FNC_TYPE", TypeName:="varchar")>
	Public Property Type() As String
	<MaxLength(4)>
	<Column("DP_TM_CODE", TypeName:="varchar")>
	Public Property DepartmentTeamCode() As String
	<Column("FNC_INACTIVE")>
	Public Property IsInactive() As Nullable(Of Short)

#End Region

#Region " Methods "



#End Region

End Class
