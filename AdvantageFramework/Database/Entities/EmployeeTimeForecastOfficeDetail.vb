Namespace Database.Entities

	<Table("ETF_OFFDTL")>
	Public Class EmployeeTimeForecastOfficeDetail
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			EmployeeTimeForecastID
			RevisionNumber
			CreatedByUserCode
			ModifiedByUserCode
			CreatedDate
			ModifiedDate
			OfficeCode
			IsApproved
			Comment
			ApprovedByEmployeeCode
			ApprovedDate
			AssignedToEmployeeCode
			EmployeeTimeForecast
			Office
			EmployeeTimeForecastOfficeDetailAlternateEmployees
			EmployeeTimeForecastOfficeDetailEmployees
			EmployeeTimeForecastOfficeDetailIndirectCategories
			EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployees
			EmployeeTimeForecastOfficeDetailIndirectCategoryEmployees
			EmployeeTimeForecastOfficeDetailJobComponents
			EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployees
			EmployeeTimeForecastOfficeDetailJobComponentEmployees
			ApprovedByEmployee
			AssignedToEmployee

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("ETF_OFFDTL_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ID() As Integer
		<Required>
		<Column("ETF_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EmployeeTimeForecastID() As Integer
		<Required>
		<Column("REV_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RevisionNumber() As Integer
		<Required>
		<MaxLength(100)>
		<Column("USER_CREATED", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CreatedByUserCode() As String
		<MaxLength(100)>
		<Column("USER_MODIFIED", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ModifiedByUserCode() As String
		<Required>
		<Column("CREATED_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CreatedDate() As Date
		<Column("MODIFIED_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ModifiedDate() As Nullable(Of Date)
		<Required>
		<MaxLength(4)>
		<Column("OFFICE_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property OfficeCode() As String
		<Required>
		<Column("APPROVED")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsApproved() As Boolean
		<Required>
		<MaxLength(100)>
		<Column("FC_COMMENT", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Comment() As String
		<MaxLength(100)>
		<Column("APPROVED_BY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ApprovedByEmployeeCode() As String
		<Column("APPROVED_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ApprovedDate() As Nullable(Of Date)
		<Required>
		<MaxLength(100)>
		<Column("USER_ASSIGNED", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property AssignedToEmployeeCode() As String

        Public Overridable Property EmployeeTimeForecast As Database.Entities.EmployeeTimeForecast
        Public Overridable Property Office As Database.Entities.Office
        Public Overridable Property EmployeeTimeForecastOfficeDetailAlternateEmployees As ICollection(Of Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee)
        Public Overridable Property EmployeeTimeForecastOfficeDetailEmployees As ICollection(Of Database.Entities.EmployeeTimeForecastOfficeDetailEmployee)
        Public Overridable Property EmployeeTimeForecastOfficeDetailIndirectCategories As ICollection(Of Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategory)
        Public Overridable Property EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployees As ICollection(Of Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryAlternateEmployee)
        Public Overridable Property EmployeeTimeForecastOfficeDetailIndirectCategoryEmployees As ICollection(Of Database.Entities.EmployeeTimeForecastOfficeDetailIndirectCategoryEmployee)
        Public Overridable Property EmployeeTimeForecastOfficeDetailJobComponents As ICollection(Of Database.Entities.EmployeeTimeForecastOfficeDetailJobComponent)
        Public Overridable Property EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployees As ICollection(Of Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentAlternateEmployee)
        Public Overridable Property EmployeeTimeForecastOfficeDetailJobComponentEmployees As ICollection(Of Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentEmployee)
        <ForeignKey("ApprovedByEmployeeCode")>
        Public Overridable Property ApprovedByEmployee As Database.Views.Employee
        <ForeignKey("AssignedToEmployeeCode")>
        Public Overridable Property AssignedToEmployee As Database.Views.Employee

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

	End Class

End Namespace
