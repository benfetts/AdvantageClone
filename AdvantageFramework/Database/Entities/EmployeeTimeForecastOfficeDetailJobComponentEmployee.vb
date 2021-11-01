Namespace Database.Entities

	<Table("ETF_OFFDTLJC_EMP")>
	Public Class EmployeeTimeForecastOfficeDetailJobComponentEmployee
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			EmployeeTimeForecastID
			EmployeeTimeForecastOfficeDetailID
			EmployeeTimeForecastOfficeDetailJobComponentID
			EmployeeTimeForecastOfficeDetailEmployeeID
			Hours
			EmployeeTimeForecastOfficeDetail
			EmployeeTimeForecast
			EmployeeTimeForecastOfficeDetailJobComponent
			EmployeeTimeForecastOfficeDetailEmployee

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("ETF_OFFDTLJC_EMP_ID")>
		Public Property ID() As Integer
		<Required>
		<Column("ETF_ID")>
		Public Property EmployeeTimeForecastID() As Integer
		<Required>
		<Column("ETF_OFFDTL_ID")>
		Public Property EmployeeTimeForecastOfficeDetailID() As Integer
		<Required>
		<Column("ETF_OFFDTLJC_ID")>
		Public Property EmployeeTimeForecastOfficeDetailJobComponentID() As Integer
		<Required>
		<Column("ETF_OFFDTLEMP_ID")>
		Public Property EmployeeTimeForecastOfficeDetailEmployeeID() As Integer
		<Required>
		<AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(9, 2)>
		<Column("HOURS")>
		Public Property Hours() As Decimal

        Public Overridable Property EmployeeTimeForecastOfficeDetail As Database.Entities.EmployeeTimeForecastOfficeDetail
        Public Overridable Property EmployeeTimeForecast As Database.Entities.EmployeeTimeForecast
        Public Overridable Property EmployeeTimeForecastOfficeDetailJobComponent As Database.Entities.EmployeeTimeForecastOfficeDetailJobComponent
        Public Overridable Property EmployeeTimeForecastOfficeDetailEmployee As Database.Entities.EmployeeTimeForecastOfficeDetailEmployee

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

	End Class

End Namespace
