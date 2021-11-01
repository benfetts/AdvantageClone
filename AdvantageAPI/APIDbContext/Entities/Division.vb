<Table("DIVISION")>
Public Class Division

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
	Public Property Code() As String
	<MaxLength(40)>
	<Column("DIV_NAME", TypeName:="varchar")>
	Public Property Name() As String
	<MaxLength(40)>
	<Column("DIV_SADDRESS1", TypeName:="varchar")>
	Public Property Address() As String
	<MaxLength(40)>
	<Column("DIV_SADDRESS2", TypeName:="varchar")>
	Public Property Address2() As String
	<MaxLength(30)>
	<Column("DIV_SCITY", TypeName:="varchar")>
	Public Property City() As String
	<MaxLength(20)>
	<Column("DIV_SCOUNTY", TypeName:="varchar")>
	Public Property County() As String
	<MaxLength(10)>
	<Column("DIV_SSTATE", TypeName:="varchar")>
	Public Property State() As String
	<MaxLength(20)>
	<Column("DIV_SCOUNTRY", TypeName:="varchar")>
	Public Property Country() As String
	<MaxLength(10)>
	<Column("DIV_SZIP", TypeName:="varchar")>
	Public Property Zip() As String
	<Column("ACTIVE_FLAG")>
	Public Property IsActive() As Nullable(Of Short)
	<MaxLength(40)>
	<Column("DIV_BADDRESS1", TypeName:="varchar")>
	Public Property BillingAddress() As String
	<MaxLength(40)>
	<Column("DIV_BADDRESS2", TypeName:="varchar")>
	Public Property BillingAddress2() As String
	<MaxLength(30)>
	<Column("DIV_BCITY", TypeName:="varchar")>
	Public Property BillingCity() As String
	<MaxLength(20)>
	<Column("DIV_BCOUNTY", TypeName:="varchar")>
	Public Property BillingCounty() As String
	<MaxLength(10)>
	<Column("DIV_BSTATE", TypeName:="varchar")>
	Public Property BillingState() As String
	<MaxLength(10)>
	<Column("DIV_BZIP", TypeName:="varchar")>
	Public Property BillingZip() As String
	<MaxLength(20)>
	<Column("DIV_BCOUNTRY", TypeName:="varchar")>
	Public Property BillingCountry() As String

#End Region

#Region " Methods "



#End Region

End Class
