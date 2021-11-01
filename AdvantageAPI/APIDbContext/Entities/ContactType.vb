<Table("CONTACT_TYPE")>
Public Class ContactType

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

	<Key>
	<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
	<Required>
	<Column("CONTACT_TYPE_ID")>
	Public Property ID() As Integer
	<Required>
	<MaxLength(100)>
	<Column("DESCRIPTION", TypeName:="varchar")>
	Public Property Description() As String

#End Region

#Region " Methods "



#End Region

End Class
