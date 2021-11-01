<Table("PRODUCT")>
Public Class Product

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
	<Column("CL_CODE", Order:=0, TypeName:="varchar")>
	Public Property ClientCode() As String
	<Key>
	<Required>
	<MaxLength(6)>
	<Column("DIV_CODE", Order:=1, TypeName:="varchar")>
	Public Property DivisionCode() As String
	<Key>
	<Required>
	<MaxLength(6)>
	<Column("PRD_CODE", Order:=2, TypeName:="varchar")>
	Public Property Code() As String
	<MaxLength(40)>
	<Column("PRD_DESCRIPTION", TypeName:="varchar")>
	Public Property Name() As String
	<Column("ACTIVE_FLAG")>
	Public Property IsActive() As Nullable(Of Short)
	<MaxLength(40)>
	<Column("PRD_BILL_ADDRESS1", TypeName:="varchar")>
	Public Property BillingAddress() As String
	<MaxLength(40)>
	<Column("PRD_BILL_ADDRESS2", TypeName:="varchar")>
	Public Property BillingAddress2() As String
	<MaxLength(30)>
	<Column("PRD_BILL_CITY", TypeName:="varchar")>
	Public Property BillingCity() As String
	<MaxLength(20)>
	<Column("PRD_BILL_COUNTY", TypeName:="varchar")>
	Public Property BillingCounty() As String
	<MaxLength(10)>
	<Column("PRD_BILL_STATE", TypeName:="varchar")>
	Public Property BillingState() As String
	<MaxLength(10)>
	<Column("PRD_BILL_ZIP", TypeName:="varchar")>
	Public Property BillingZip() As String
	<MaxLength(20)>
	<Column("PRD_BILL_COUNTRY", TypeName:="varchar")>
	Public Property BillingCountry() As String
	<MaxLength(13)>
	<Column("PRD_BILL_TELEPHONE", TypeName:="varchar")>
	Public Property BillingPhone() As String
	<MaxLength(4)>
	<Column("PRD_BILL_EXTENTION", TypeName:="varchar")>
	Public Property BillingPhoneExtension() As String
	<MaxLength(13)>
	<Column("PRD_BILL_FAX", TypeName:="varchar")>
	Public Property BillingFax() As String
	<MaxLength(4)>
	<Column("PRD_BILL_FAX_EXT", TypeName:="varchar")>
	Public Property BillingFaxExtension() As String
	<MaxLength(40)>
	<Column("PRD_STATE_ADDR1", TypeName:="varchar")>
	Public Property StatementAddress() As String
	<MaxLength(40)>
	<Column("PRD_STATE_ADDR2", TypeName:="varchar")>
	Public Property StatementAddress2() As String
	<MaxLength(30)>
	<Column("PRD_STATE_CITY", TypeName:="varchar")>
	Public Property StatementCity() As String
	<MaxLength(20)>
	<Column("PRD_STATE_COUNTY", TypeName:="varchar")>
	Public Property StatementCounty() As String
	<MaxLength(10)>
	<Column("PRD_STATE_STATE", TypeName:="varchar")>
	Public Property StatementState() As String
	<MaxLength(10)>
	<Column("PRD_STATE_ZIP", TypeName:="varchar")>
	Public Property StatementZip() As String
	<MaxLength(20)>
	<Column("PRD_STATE_COUNTRY", TypeName:="varchar")>
	Public Property StatementCountry() As String
	<MaxLength(13)>
	<Column("PRD_STATE_TELEPHON", TypeName:="varchar")>
	Public Property StatementPhone() As String
	<MaxLength(4)>
	<Column("PRD_STATE_EXT", TypeName:="varchar")>
	Public Property StatementPhoneExtension() As String
	<MaxLength(13)>
	<Column("PRD_STATE_FAX", TypeName:="varchar")>
	Public Property StatementFax() As String
	<MaxLength(4)>
	<Column("PRD_STATE_FAX_EXT", TypeName:="varchar")>
	Public Property StatementFaxExtension() As String
	<Required>
	<MaxLength(4)>
	<Column("OFFICE_CODE", TypeName:="varchar")>
	Public Property OfficeCode() As String

#End Region

#Region " Methods "



#End Region

End Class
