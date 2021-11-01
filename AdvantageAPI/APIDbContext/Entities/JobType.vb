<Table("JOB_TYPE")>
Public Class JobType

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

	<Key>
	<Required>
	<MaxLength(10)>
	<Column("JT_CODE", TypeName:="varchar")>
	Public Property Code() As String
	<Required>
	<MaxLength(30)>
	<Column("JT_DESC", TypeName:="varchar")>
	Public Property Description() As String
	<Column("INACTIVE_FLAG")>
	Public Property IsInactive() As Nullable(Of Short)
	<MaxLength(6)>
	<Column("SC_CODE", TypeName:="varchar")>
	Public Property SalesClassCode() As String

#End Region

#Region " Methods "



#End Region

End Class
