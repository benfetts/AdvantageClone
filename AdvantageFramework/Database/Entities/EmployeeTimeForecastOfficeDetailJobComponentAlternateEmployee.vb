﻿Namespace Database.Entities

	<Table("ETF_OFFDTLJC_AE")>
	Public Class EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			EmployeeTimeForecastID
			EmployeeTimeForecastOfficeDetailID
			EmployeeTimeForecastOfficeDetailJobComponentID
			EmployeeTimeForecastOfficeDetailAlternateEmployeeID
			Hours
			EmployeeTimeForecastOfficeDetail
			EmployeeTimeForecast
			EmployeeTimeForecastOfficeDetailJobComponent
			EmployeeTimeForecastOfficeDetailAlternateEmployee

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("ETF_OFFDTLJC_AE_ID")>
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
		<Column("ETF_OFFDTLAE_ID")>
		Public Property EmployeeTimeForecastOfficeDetailAlternateEmployeeID() As Integer
		<Required>
		<AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(9, 2)>
		<Column("HOURS")>
		Public Property Hours() As Decimal

        Public Overridable Property EmployeeTimeForecastOfficeDetail As Database.Entities.EmployeeTimeForecastOfficeDetail
        Public Overridable Property EmployeeTimeForecast As Database.Entities.EmployeeTimeForecast
        Public Overridable Property EmployeeTimeForecastOfficeDetailJobComponent As Database.Entities.EmployeeTimeForecastOfficeDetailJobComponent
        Public Overridable Property EmployeeTimeForecastOfficeDetailAlternateEmployee As Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

	End Class

End Namespace
