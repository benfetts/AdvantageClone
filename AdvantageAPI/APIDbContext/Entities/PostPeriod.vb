<Table("POSTPERIOD")>
Public Class PostPeriod

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
	<Column("PPPERIOD", TypeName:="varchar")>
	Public Property Code() As String
	<MaxLength(1)>
	<Column("PPARCURMTH", TypeName:="varchar")>
	Public Property ARStatus() As String
	<Column("PPGLMONTH")>
	Public Property Month() As Nullable(Of Short)
	<MaxLength(5)>
	<Column("PPGLYEAR", TypeName:="varchar")>
	Public Property Year() As String
	<MaxLength(1)>
	<Column("PPGLCURMTH", TypeName:="varchar")>
	Public Property GLStatus() As String
	<MaxLength(1)>
	<Column("PPAPCURMTH", TypeName:="varchar")>
	Public Property APStatus() As String
	<Column("PPSRTDATE")>
	Public Property StartDate() As Nullable(Of Date)
	<Column("PPENDDATE")>
	Public Property EndDate() As Nullable(Of Date)
	<Required>
	<MaxLength(10)>
	<Column("PPDESC", TypeName:="varchar")>
	Public Property Description() As String
	<MaxLength(100)>
	<Column("PPUSER", TypeName:="varchar")>
	Public Property UserCode() As String
	<Column("PPENTDATE")>
	Public Property EnteredDate() As Nullable(Of Date)
	<Column("PPMODDATE")>
	Public Property ModifiedDate() As Nullable(Of Date)
	<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
	<Required>
	<Column("ROWID")>
	Public Property ID() As Integer
	<MaxLength(1)>
	<Column("PPTECURMTH", TypeName:="varchar")>
	Public Property EmployeeTimeStatus() As String

#End Region

#Region " Methods "



#End Region

End Class
