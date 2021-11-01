<Table("MARKET")>
Public Class Market

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
	<Column("MARKET_CODE", TypeName:="varchar")>
	Public Property Code() As String
	<MaxLength(40)>
	<Column("MARKET_DESC", TypeName:="varchar")>
	Public Property Description() As String
	<Column("INACTIVE_FLAG")>
	Public Property IsInactive() As Nullable(Of Short)

#End Region

#Region " Methods "



#End Region

End Class
