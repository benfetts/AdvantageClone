Namespace Security.Database.Views

	<Table("V_SEC_UDR_PERMISSION")>
	Public Class UserUserDefinedReportPermission
		Inherits BaseClasses.EntityView

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			UserDefinedReportID
			UserDefinedReportName
			UserDefinedReportCategoryID
			UserID
			UserCode
			EmployeeCode
			IsBlocked
		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<Column("ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ID() As Guid
		<Required>
		<Column("UserDefinedReportID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UserDefinedReportID() As Integer
		<Required>
		<MaxLength(50)>
		<Column("UserDefinedReportName", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UserDefinedReportName() As String
		<Column("UserDefinedReportCategoryID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UserDefinedReportCategoryID() As Nullable(Of Integer)
		<Required>
		<Column("UserID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UserID() As Integer
		<Required>
		<MaxLength(100)>
		<Column("UserCode", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UserCode() As String
		<Required>
		<MaxLength(6)>
		<Column("EmployeeCode", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EmployeeCode() As String
		<Required>
		<Column("IsBlocked")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsBlocked() As Boolean

#End Region

#Region " Methods "

		Public Overrides Function ToString() As String

			ToString = Me.ID.ToString

		End Function

#End Region

	End Class

End Namespace
