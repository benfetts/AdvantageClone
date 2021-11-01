Namespace Database.Entities

	<Table("ETF_HDR")>
	Public Class EmployeeTimeForecast
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			Description
			PostPeriodCode
			ID
			PostPeriod
			EmployeeTimeForecastOfficeDetails
			EmployeeTimeForecastOfficeDetailAlternateEmployees
			EmployeeTimeForecastOfficeDetailEmployees
			EmployeeTimeForecastOfficeDetailIndirectCategories
			EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployees
			EmployeeTimeForecastOfficeDetailIndirectCategoryEmployees
			EmployeeTimeForecastOfficeDetailJobComponents
			EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployees
			EmployeeTimeForecastOfficeDetailJobComponentEmployees

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Required>
		<MaxLength(100)>
		<Column("FC_DESCRIPTION", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Description() As String
		<Required>
		<MaxLength(6)>
		<Column("PPPERIOD", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property PostPeriodCode() As String
		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("ETF_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ID() As Integer

        Public Overridable Property PostPeriod As Database.Entities.PostPeriod
        Public Overridable Property EmployeeTimeForecastOfficeDetails As ICollection(Of Database.Entities.EmployeeTimeForecastOfficeDetail)
        Public Overridable Property EmployeeTimeForecastOfficeDetailAlternateEmployees As ICollection(Of Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee)
        Public Overridable Property EmployeeTimeForecastOfficeDetailEmployees As ICollection(Of Database.Entities.EmployeeTimeForecastOfficeDetailEmployee)
        Public Overridable Property EmployeeTimeForecastOfficeDetailIndirectCategories As ICollection(Of Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategory)
        Public Overridable Property EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployees As ICollection(Of Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee)
        Public Overridable Property EmployeeTimeForecastOfficeDetailIndirectCategoryEmployees As ICollection(Of Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee)
        Public Overridable Property EmployeeTimeForecastOfficeDetailJobComponents As ICollection(Of Database.Entities.EmployeeTimeForecastOfficeDetailJobComponent)
        Public Overridable Property EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployees As ICollection(Of Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee)
        Public Overridable Property EmployeeTimeForecastOfficeDetailJobComponentEmployees As ICollection(Of Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentEmployee)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Description

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.EmployeeTimeForecast.Properties.Description.ToString

                    If Value Is Nothing OrElse Value.Trim = "" Then

                        IsValid = False
                        ErrorText = "Please enter a description."

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

	End Class

End Namespace
