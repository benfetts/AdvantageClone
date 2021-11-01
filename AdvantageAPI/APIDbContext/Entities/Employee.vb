<Table("EMPLOYEE")>
Public Class Employee

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
	<Column("EMP_CODE", TypeName:="varchar")>
	Public Property Code() As String
	<MaxLength(4)>
	<Column("DP_TM_CODE", TypeName:="varchar")>
	Public Property DepartmentTeamCode() As String
	<MaxLength(30)>
	<Column("EMP_LNAME", TypeName:="varchar")>
	Public Property LastName() As String
	<MaxLength(30)>
	<Column("EMP_FNAME", TypeName:="varchar")>
	Public Property FirstName() As String
	<MaxLength(1)>
	<Column("EMP_MI", TypeName:="varchar")>
	Public Property MiddleInitial() As String
	<Required>
	<Column("IS_ACTIVE_FREELANCE")>
	Public Property IsActiveFreelance() As Boolean
	<Column("IS_API_USER", TypeName:="varchar(MAX)")>
	Public Property IsAPIUser() As String
	<Column("EMP_TERM_DATE")>
	Public Property TerminationDate() As Nullable(Of Date)
	<MaxLength(50)>
	<Column("EMP_EMAIL", TypeName:="varchar")>
	Public Property Email() As String
	<MaxLength(6)>
	<Column("DEF_FNC_CODE", TypeName:="varchar")>
	Public Property FunctionCode() As String

#End Region

#Region " Methods "



#End Region

End Class
