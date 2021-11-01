Namespace Database.Entities

	<Table("ETF_OFFDTLJC")>
	Public Class EmployeeTimeForecastOfficeDetailJobComponent
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			EmployeeTimeForecastID
			EmployeeTimeForecastOfficeDetailID
			JobNumber
			RevenueAmount
			JobComponentNumber
			ClientCode
			DivisionCode
			ProductCode
			OfficeCode
			EmployeeTimeForecastOfficeDetail
			EmployeeTimeForecast
			Office
			Client
			Division
			Product
			Job
			JobComponent
			EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployees
			EmployeeTimeForecastOfficeDetailJobComponentEmployees

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("ETF_OFFDTLJC_ID")>
		Public Property ID() As Integer
		<Required>
		<Column("ETF_ID")>
		Public Property EmployeeTimeForecastID() As Integer
		<Required>
		<Column("ETF_OFFDTL_ID")>
		Public Property EmployeeTimeForecastOfficeDetailID() As Integer
        <Required>
        <Column("JOB_NUMBER", Order:=0)>
        <ForeignKey("JobComponent")>
        Public Property JobNumber() As Integer
		<Required>
		<AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(15, 2)>
		<Column("REV_AMT")>
		Public Property RevenueAmount() As Decimal
		<Required>
        <Column("JOB_COMPONENT_NBR", Order:=1)>
        <ForeignKey("JobComponent")>
        Public Property JobComponentNumber() As Short
		<Required>
		<MaxLength(6)>
		<Column("CL_CODE", TypeName:="varchar")>
		Public Property ClientCode() As String
		<Required>
		<MaxLength(6)>
		<Column("DIV_CODE", TypeName:="varchar")>
		Public Property DivisionCode() As String
		<Required>
		<MaxLength(6)>
		<Column("PRD_CODE", TypeName:="varchar")>
		Public Property ProductCode() As String
		<Required>
		<MaxLength(4)>
		<Column("OFFICE_CODE", TypeName:="varchar")>
		Public Property OfficeCode() As String

        Public Overridable Property EmployeeTimeForecastOfficeDetail As Database.Entities.EmployeeTimeForecastOfficeDetail
        Public Overridable Property EmployeeTimeForecast As Database.Entities.EmployeeTimeForecast
        Public Overridable Property Office As Database.Entities.Office
        Public Overridable Property Client As Database.Entities.Client
        <ForeignKey("ClientCode, DivisionCode")>
        Public Overridable Property Division As Database.Entities.Division
        <ForeignKey("ClientCode, DivisionCode, ProductCode")>
        Public Overridable Property Product As Database.Entities.Product
        Public Overridable Property Job As Database.Entities.Job
        <ForeignKey("JobNumber, JobComponentNumber")>
        Public Overridable Property JobComponent As Database.Entities.JobComponent
        Public Overridable Property EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployees As ICollection(Of Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee)
        Public Overridable Property EmployeeTimeForecastOfficeDetailJobComponentEmployees As ICollection(Of Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentEmployee)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

	End Class

End Namespace
