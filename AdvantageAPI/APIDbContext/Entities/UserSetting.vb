<Table("SEC_USER_SETTING")>
Public Class UserSetting

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

	<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
	<Required>
	<Column("SEC_USER_SETTING_ID")>
	Public Property ID() As Integer
	<Key>
	<Required>
	<Column("SEC_USER_ID", Order:=0)>
	Public Property UserID() As Integer
	<Key>
	<Required>
	<MaxLength(100)>
	<Column("SETTING_CODE", Order:=1, TypeName:="varchar")>
	Public Property SettingCode() As String
	<MaxLength(8000)>
	<Column("STRING_VALUE", TypeName:="varchar")>
	Public Property StringValue() As String
	<Column("NUMERIC_VALUE")>
	Public Property NumericValue() As Nullable(Of Decimal)
	<Column("DATE_VALUE")>
	Public Property DateValue() As Nullable(Of Date)

#End Region

#Region " Methods "



#End Region

End Class
