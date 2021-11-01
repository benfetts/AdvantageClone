<Table("CAMPAIGN")>
Public Class Campaign

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

	<Key>
	<DatabaseGenerated(DatabaseGeneratedOption.None)>
	<Required>
	<Column("CMP_IDENTIFIER")>
	Public Property ID() As Integer
	<Required>
	<MaxLength(6)>
	<Column("CL_CODE", TypeName:="varchar")>
	Public Property ClientCode() As String
	<MaxLength(6)>
	<Column("DIV_CODE", TypeName:="varchar")>
	Public Property DivisionCode() As String
	<MaxLength(6)>
	<Column("PRD_CODE", TypeName:="varchar")>
	Public Property ProductCode() As String
	<Required>
	<MaxLength(6)>
	<Column("CMP_CODE", TypeName:="varchar")>
	Public Property Code() As String
	<MaxLength(60)>
	<Column("CMP_NAME", TypeName:="varchar")>
	Public Property Name() As String
	<Column("CMP_CLOSED")>
	Public Property IsClosed() As Nullable(Of Short)
	<Column("ACTIVE_FLAG")>
	Public Property IsActive() As Nullable(Of Short)

#End Region

#Region " Methods "



#End Region

End Class
