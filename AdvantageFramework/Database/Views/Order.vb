Namespace Database.Views

	<Table("V_ORDER")>
	Public Class Order
		Inherits BaseClasses.EntityView

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			MediaType
			OrderNumber
			OrderDescription
			OfficeCode
			OfficeName
			ClientCode
			ClientName
			DivisionCode
			DivisionName
			ProductCode
			ProductDescription
			VendorCode
			VendorName
		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<MaxLength(1)>
		<Column("MediaType", Order:=0, TypeName:="varchar")>
		Public Property MediaType() As String
		<Key>
		<Column("OrderNumber", Order:=1)>
		Public Property OrderNumber() As Integer
		<MaxLength(40)>
		<Column("OrderDescription", TypeName:="varchar")>
		Public Property OrderDescription() As String
		<MaxLength(6)>
		<Column("OfficeCode", TypeName:="varchar")>
		Public Property OfficeCode() As String
		<MaxLength(30)>
		<Column("OfficeName", TypeName:="varchar")>
		Public Property OfficeName() As String
		<MaxLength(6)>
		<Column("ClientCode", TypeName:="varchar")>
		Public Property ClientCode() As String
		<MaxLength(40)>
		<Column("ClientName", TypeName:="varchar")>
		Public Property ClientName() As String
		<MaxLength(6)>
		<Column("DivisionCode", TypeName:="varchar")>
		Public Property DivisionCode() As String
		<MaxLength(40)>
		<Column("DivisionName", TypeName:="varchar")>
		Public Property DivisionName() As String
		<MaxLength(6)>
		<Column("ProductCode", TypeName:="varchar")>
		Public Property ProductCode() As String
		<MaxLength(40)>
		<Column("ProductDescription", TypeName:="varchar")>
		Public Property ProductDescription() As String
		<MaxLength(6)>
		<Column("VendorCode", TypeName:="varchar")>
		Public Property VendorCode() As String
		<MaxLength(40)>
		<Column("VendorName", TypeName:="varchar")>
		Public Property VendorName() As String


#End Region

#Region " Methods "

		Public Overrides Function ToString() As String

			ToString = Me.OrderNumber.ToString & " - " & Me.OrderDescription

		End Function

#End Region

	End Class

End Namespace
