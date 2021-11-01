<Table("VEN_CONT")>
Public Class VendorContact

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
	<Column("VN_CODE", Order:=0, TypeName:="varchar")>
	Public Property VendorCode() As String
	<Key>
	<Required>
	<MaxLength(4)>
	<Column("VC_CODE", Order:=1, TypeName:="varchar")>
	Public Property Code() As String
	<MaxLength(30)>
	<Column("VC_FNAME", TypeName:="varchar")>
	Public Property FirstName() As String
	<MaxLength(30)>
	<Column("VC_LNAME", TypeName:="varchar")>
	Public Property LastName() As String
	<MaxLength(1)>
	<Column("VC_MI", TypeName:="varchar")>
	Public Property MiddleInitial() As String
	<MaxLength(40)>
	<Column("VC_TITLE", TypeName:="varchar")>
	Public Property Title() As String
	<MaxLength(40)>
	<Column("VC_ADDRESS1", TypeName:="varchar")>
	Public Property Address1() As String
	<MaxLength(40)>
	<Column("VC_ADDRESS2", TypeName:="varchar")>
	Public Property Address2() As String
	<MaxLength(20)>
	<Column("VC_CITY", TypeName:="varchar")>
	Public Property City() As String
	<MaxLength(20)>
	<Column("VC_COUNTY", TypeName:="varchar")>
	Public Property County() As String
	<MaxLength(10)>
	<Column("VC_STATE", TypeName:="varchar")>
	Public Property State() As String
	<MaxLength(20)>
	<Column("VC_COUNTRY", TypeName:="varchar")>
	Public Property Country() As String
	<MaxLength(10)>
	<Column("VC_ZIP", TypeName:="varchar")>
	Public Property Zip() As String
	<MaxLength(13)>
	<Column("VC_TELEPHONE", TypeName:="varchar")>
	Public Property Phone() As String
	<MaxLength(4)>
	<Column("VC_EXTENTION", TypeName:="varchar")>
	Public Property PhoneExt() As String
	<MaxLength(13)>
	<Column("VC_FAX", TypeName:="varchar")>
	Public Property Fax() As String
	<MaxLength(4)>
	<Column("VC_FAX_EXTENTION", TypeName:="varchar")>
	Public Property FaxExt() As String
	<MaxLength(50)>
	<Column("EMAIL_ADDRESS", TypeName:="varchar")>
	Public Property Email() As String
	<Column("VC_INACTIVE_FLAG")>
	Public Property IsInactive() As Nullable(Of Short)
	<MaxLength(13)>
	<Column("VC_PHONE_CELL", TypeName:="varchar")>
	Public Property Cell() As String
	<Column("CONTACT_TYPE_ID")>
	Public Property ContactTypeID() As Nullable(Of Integer)

#End Region

#Region " Methods "



#End Region

End Class

