Namespace Database.Entities

	<Table("EMPLOYEE_TITLE")>
	Public Class EmployeeTitle
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			Description
			EmployeeCategoryID
			IsInactive
			BillingRateDetails
			EmployeeTimeForecastOfficeDetailAlternateEmployees
            EmployeeCategory
            DepartmentTeam
            EmployeeTimeDetails
			EmployeeRateHistories

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("EMPLOYEE_TITLE_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ID() As Integer
		<Required>
		<MaxLength(50)>
		<Column("EMPLOYEE_TITLE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Description() As String
		<Column("EMPLOYEE_CATEGORY_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.EmployeeCategoryID)>
        Public Property EmployeeCategoryID() As Nullable(Of Integer)
        <Column("DP_TM_CODE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.DepartmentTeamName)>
        Public Property DepartmentTeamCode() As String

        <Column("INACTIVE_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property IsInactive() As Nullable(Of Short)

        Public Overridable Property BillingRateDetails As ICollection(Of Database.Entities.BillingRateDetail)
        Public Overridable Property EmployeeTimeForecastOfficeDetailAlternateEmployees As ICollection(Of Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee)
        Public Overridable Property EmployeeCategory As Database.Entities.EmployeeCategory
        Public Overridable Property DepartmentTeam As Database.Entities.DepartmentTeam
        Public Overridable Property EmployeeTimeDetails As ICollection(Of Database.Entities.EmployeeTimeDetail)
        Public Overridable Property EmployeeRateHistories As ICollection(Of Database.Entities.EmployeeRateHistory)

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

                Case AdvantageFramework.Database.Entities.EmployeeTitle.Properties.Description.ToString

                    If Me.IsEntityBeingAdded() Then

                        PropertyValue = Value

                        If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).EmployeeTitles
                            Where Entity.Description.ToUpper = DirectCast(PropertyValue, String).ToUpper
                            Select Entity).Any Then

                            IsValid = False

                            ErrorText = "Please enter a unique employee title."

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

	End Class

End Namespace
