<Table("CLIENT")>
Public Class Client

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
	<Column("CL_CODE", TypeName:="varchar")>
	Public Property Code() As String
	<MaxLength(40)>
	<Column("CL_NAME", TypeName:="varchar")>
	Public Property Name() As String
	<MaxLength(40)>
	<Column("CL_ADDRESS1", TypeName:="varchar")>
	Public Property Address() As String
	<MaxLength(40)>
	<Column("CL_ADDRESS2", TypeName:="varchar")>
	Public Property Address2() As String
	<MaxLength(30)>
	<Column("CL_CITY", TypeName:="varchar")>
	Public Property City() As String
	<MaxLength(20)>
	<Column("CL_COUNTY", TypeName:="varchar")>
	Public Property County() As String
	<MaxLength(10)>
	<Column("CL_STATE", TypeName:="varchar")>
	Public Property State() As String
	<MaxLength(20)>
	<Column("CL_COUNTRY", TypeName:="varchar")>
	Public Property Country() As String
	<MaxLength(10)>
	<Column("CL_ZIP", TypeName:="varchar")>
	Public Property Zip() As String
	<Column("ACTIVE_FLAG")>
	Public Property IsActive() As Nullable(Of Short)
	<MaxLength(40)>
	<Column("CL_BADDRESS1", TypeName:="varchar")>
	Public Property BillingAddress() As String
	<MaxLength(40)>
	<Column("CL_BADDRESS2", TypeName:="varchar")>
	Public Property BillingAddress2() As String
	<MaxLength(30)>
	<Column("CL_BCITY", TypeName:="varchar")>
	Public Property BillingCity() As String
	<MaxLength(20)>
	<Column("CL_BCOUNTY", TypeName:="varchar")>
	Public Property BillingCounty() As String
	<MaxLength(10)>
	<Column("CL_BSTATE", TypeName:="varchar")>
	Public Property BillingState() As String
	<MaxLength(10)>
	<Column("CL_BZIP", TypeName:="varchar")>
	Public Property BillingZip() As String
	<MaxLength(20)>
	<Column("CL_BCOUNTRY", TypeName:="varchar")>
	Public Property BillingCountry() As String
	<MaxLength(40)>
	<Column("CL_SADDRESS1", TypeName:="varchar")>
	Public Property StatementAddress() As String
	<MaxLength(40)>
	<Column("CL_SADDRESS2", TypeName:="varchar")>
	Public Property StatementAddress2() As String
	<MaxLength(30)>
	<Column("CL_SCITY", TypeName:="varchar")>
	Public Property StatementCity() As String
	<MaxLength(20)>
	<Column("CL_SCOUNTY", TypeName:="varchar")>
	Public Property StatementCounty() As String
	<MaxLength(10)>
	<Column("CL_SSTATE", TypeName:="varchar")>
	Public Property StatementState() As String
	<MaxLength(10)>
	<Column("CL_SZIP", TypeName:="varchar")>
	Public Property StatementZip() As String
	<MaxLength(20)>
	<Column("CL_SCOUNTRY", TypeName:="varchar")>
	Public Property StatementCountry() As String
	<Required>
	<Column("REQ_TIME_COMMENT")>
	Public Property RequireTimeComment() As Boolean

#End Region

#Region " Methods "



#End Region

End Class
