Namespace Database.Entities

	<Table("ETF_OFFDTLCAT")>
	Public Class EmployeeTimeForecastOfficeDetailIndirectCategory
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			EmployeeTimeForecastID
			EmployeeTimeForecastOfficeDetailID
			IndirectCategoryCode
			EmployeeTimeForecastOfficeDetail
			EmployeeTimeForecast
			IndirectCategory
			EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployees
			EmployeeTimeForecastOfficeDetailIndirectCategoryEmployees

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("ETF_OFFDTLCAT_ID")>
		Public Property ID() As Integer
		<Required>
		<Column("ETF_ID")>
		Public Property EmployeeTimeForecastID() As Integer
		<Required>
		<Column("ETF_OFFDTL_ID")>
		Public Property EmployeeTimeForecastOfficeDetailID() As Integer
		<Required>
		<MaxLength(10)>
		<Column("CATEGORY", TypeName:="varchar")>
		Public Property IndirectCategoryCode() As String

        Public Overridable Property EmployeeTimeForecastOfficeDetail As Database.Entities.EmployeeTimeForecastOfficeDetail
        Public Overridable Property EmployeeTimeForecast As Database.Entities.EmployeeTimeForecast
        Public Overridable Property IndirectCategory As Database.Entities.IndirectCategory
        Public Overridable Property EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployees As ICollection(Of Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee)
        Public Overridable Property EmployeeTimeForecastOfficeDetailIndirectCategoryEmployees As ICollection(Of Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

	End Class

End Namespace
