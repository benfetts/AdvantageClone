Namespace Database.Entities

	<Table("ETF_OFFDTLAE")>
	Public Class EmployeeTimeForecastOfficeDetailAlternateEmployee
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			EmployeeTimeForecastID
			EmployeeTimeForecastOfficeDetailID
			EmployeeTitleID
			BillRate
			CostRate
			Description
			OfficeCode
			EmployeeTimeForecastOfficeDetail
			EmployeeTimeForecast
			EmployeeTitle
			EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployees
			EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployees
			Office

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("ETF_OFFDTLAE_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ID() As Integer
		<Required>
		<Column("ETF_ID")>
		Public Property EmployeeTimeForecastID() As Integer
		<Required>
		<Column("ETF_OFFDTL_ID")>
		Public Property EmployeeTimeForecastOfficeDetailID() As Integer
		<Required>
		<Column("EMPLOYEE_TITLE_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property EmployeeTitleID() As Integer
		<Required>
		<AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(9, 2)>
		<Column("BILL_RATE")>
		Public Property BillRate() As Decimal
		<Required>
		<AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(9, 2)>
		<Column("COST_RATE")>
		Public Property CostRate() As Decimal
		<Required>
		<MaxLength(50)>
		<Column("DESCRIPTION", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Description() As String
		<Required>
		<MaxLength(4)>
		<Column("OFFICE_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property OfficeCode() As String

        Public Overridable Property EmployeeTimeForecastOfficeDetail As Database.Entities.EmployeeTimeForecastOfficeDetail
        Public Overridable Property EmployeeTimeForecast As Database.Entities.EmployeeTimeForecast
        Public Overridable Property EmployeeTitle As Database.Entities.EmployeeTitle
        Public Overridable Property EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployees As ICollection(Of Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee)
        Public Overridable Property EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployees As ICollection(Of Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee)
        Public Overridable Property Office As Database.Entities.Office

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.EmployeeTitle.Description & " - (" & Me.Description & ")"

        End Function
        Public Overrides Function ValidateEntity(ByRef IsValid As Boolean) As String

            'objects 
            Dim ErrorText As String = ""

            ErrorText = MyBase.ValidateEntity(IsValid)

            If IsValid Then

                If Me.IsEntityBeingAdded() Then

                    If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).EmployeeTimeForecastOfficeDetailAlternateEmployees.ToList
                        Where Entity.EmployeeTimeForecastOfficeDetailID = Me.EmployeeTimeForecastOfficeDetailID AndAlso
                                  Entity.Description.ToUpper = Me.Description.ToUpper
                        Select Entity).Any Then

                        IsValid = False
                        ErrorText = "Please enter a unique description."

                    End If

                End If

            End If

            ValidateEntity = ErrorText

        End Function

#End Region

	End Class

End Namespace
