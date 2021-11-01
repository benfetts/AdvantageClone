<Table("SEC_USER")>
Public Class User

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
	<Column("SEC_USER_ID")>
	Public Property ID() As Integer
	<Required>
	<MaxLength(100)>
	<Column("USER_CODE", TypeName:="varchar")>
	Public Property UserCode() As String
	<Required>
	<MaxLength(128)>
	<Column("USER_NAME", TypeName:="varchar")>
	Public Property UserName() As String
	<Required>
	<MaxLength(6)>
	<Column("EMP_CODE", TypeName:="varchar")>
	Public Property EmployeeCode() As String
	<Required>
    <Column("CHECK_USER_ACCESS")>
    Public Property CheckForUserAccess() As Boolean
    <Required(AllowEmptyStrings:=True)>
    <Column("PASSWORD", TypeName:="varchar")>
    Public Property Password() As String

#End Region

#Region " Methods "



#End Region

End Class
