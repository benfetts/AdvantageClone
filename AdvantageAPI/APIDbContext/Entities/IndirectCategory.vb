<Table("TIME_CATEGORY")>
Public Class IndirectCategory

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
	<Column("CATEGORY", TypeName:="varchar")>
	Public Property Code() As String
	<MaxLength(40)>
	<Column("DESCRIPTION", TypeName:="varchar")>
	Public Property Description() As String
	<Column("INACTIVE_FLAG")>
	Public Property IsInactive() As Nullable(Of Short)

#End Region

#Region " Methods "



#End Region

End Class
