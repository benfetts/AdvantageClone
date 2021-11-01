Namespace Database.Entities

	<Table("ETF_OFFDTLEMP")>
	Public Class EmployeeTimeForecastOfficeDetailEmployee
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			EmployeeTimeForecastID
			EmployeeTimeForecastOfficeDetailID
			EmployeeCode
			BillRate
			CostRate
			EmployeeTimeForecastOfficeDetail
			EmployeeTimeForecast
			Employee
			EmployeeTimeForecastOfficeDetailJobComponentEmployees
			EmployeeTimeForecastOfficeDetailIndirectCategoryEmployees

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("ETF_OFFDTLEMP_ID")>
		Public Property ID() As Integer
		<Required>
		<Column("ETF_ID")>
		Public Property EmployeeTimeForecastID() As Integer
		<Required>
		<Column("ETF_OFFDTL_ID")>
		Public Property EmployeeTimeForecastOfficeDetailID() As Integer
		<Required>
		<MaxLength(6)>
		<Column("EMP_CODE", TypeName:="varchar")>
		Public Property EmployeeCode() As String
		<Required>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(10, 3)>
        <Column("BILL_RATE")>
        Public Property BillRate() As Decimal
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(10, 3)>
        <Column("COST_RATE")>
		Public Property CostRate() As Decimal

        Public Overridable Property EmployeeTimeForecastOfficeDetail As Database.Entities.EmployeeTimeForecastOfficeDetail
        Public Overridable Property EmployeeTimeForecast As Database.Entities.EmployeeTimeForecast
        Public Overridable Property Employee As Database.Views.Employee
        Public Overridable Property EmployeeTimeForecastOfficeDetailJobComponentEmployees As ICollection(Of Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentEmployee)
        Public Overridable Property EmployeeTimeForecastOfficeDetailIndirectCategoryEmployees As ICollection(Of Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

	End Class

End Namespace
