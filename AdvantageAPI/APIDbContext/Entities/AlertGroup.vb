<Table("EMAIL_GROUP")>
Public Class AlertGroup

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

	<Key>
	<Required>
	<MaxLength(50)>
	<Column("EMAIL_GR_CODE", Order:=0, TypeName:="varchar")>
	Public Property Code() As String
	<Key>
	<Required>
	<MaxLength(6)>
	<Column("EMP_CODE", Order:=1, TypeName:="varchar")>
	Public Property EmployeeCode() As String
	<Column("INACTIVE_FLAG")>
	Public Property IsInactive() As Nullable(Of Short)
	<Column("PRIMARY_EMP")>
	Public Property IncludeOnSchedule() As Nullable(Of Short)


#End Region

#Region " Methods "



#End Region

End Class
