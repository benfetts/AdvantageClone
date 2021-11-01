Namespace Database.Entities

	<Table("DEPT_TEAM")>
	Public Class DepartmentTeam
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
			Code
			Description
			IsInactive
			DirectHoursPercentGoal
			Category
			PurchaseOrderApprovalRuleCode
			ServiceFeeTypeCode
			Functions
			EmployeeDepartments
			Employees
			PurchaseOrderApprovalRule
			AgencyDesktopDocuments
			EmployeeTimeDetails
			EmployeeTimeIndirects
			AccountPayableProduction
			GLReportTemplateDepartmentTeamPresets
			GeneralLedgerDepartmentTeamCrossReferences
			EmployeeTimeTemplates
			EmployeeRateHistories
			IncomeOnlys

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<MaxLength(4)>
		<Column("DP_TM_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.Code)>
		Public Property Code() As String
		<MaxLength(30)>
		<Column("DP_TM_DESC", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Description() As String
		<Column("INACTIVE_FLAG")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property IsInactive() As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(5, 2)>
        <Column("DIRECT_HRS_PER_GOAL")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property DirectHoursPercentGoal() As Nullable(Of Decimal)
		<MaxLength(30)>
		<Column("CATEGORY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Category() As String
		<MaxLength(6)>
		<Column("PO_APPR_RULE_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.PurchaseOrderApprovalRuleCode)>
		Public Property PurchaseOrderApprovalRuleCode() As String
		<MaxLength(6)>
		<Column("SERVICE_FEE_TYPE_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.ServiceFeeTypeCode)>
		Public Property ServiceFeeTypeCode() As String

        Public Overridable Property Functions As ICollection(Of Database.Entities.Function)
        Public Overridable Property EmployeeDepartments As ICollection(Of Database.Entities.EmployeeDepartment)
        Public Overridable Property Employees As ICollection(Of Database.Views.Employee)
        Public Overridable Property PurchaseOrderApprovalRule As Database.Entities.PurchaseOrderApprovalRule
        Public Overridable Property AgencyDesktopDocuments As ICollection(Of Database.Entities.AgencyDesktopDocument)
        Public Overridable Property EmployeeTimeDetails As ICollection(Of Database.Entities.EmployeeTimeDetail)
        Public Overridable Property EmployeeTimeIndirects As ICollection(Of Database.Entities.EmployeeTimeIndirect)
        Public Overridable Property AccountPayableProduction As ICollection(Of Database.Entities.AccountPayableProduction)
        Public Overridable Property GLReportTemplateDepartmentTeamPresets As ICollection(Of Database.Entities.GLReportTemplateDepartmentTeamPreset)
        Public Overridable Property GeneralLedgerDepartmentTeamCrossReferences As ICollection(Of Database.Entities.GeneralLedgerDepartmentTeamCrossReference)
        Public Overridable Property EmployeeTimeTemplates As ICollection(Of Database.Entities.EmployeeTimeTemplate)
        Public Overridable Property EmployeeRateHistories As ICollection(Of Database.Entities.EmployeeRateHistory)
        Public Overridable Property IncomeOnlys As ICollection(Of Database.Entities.IncomeOnly)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Code & " - " & Me.Description

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.DepartmentTeam.Properties.Code.ToString

                    If Value Is Nothing OrElse Value.Trim = "" Then

                        IsValid = False
                        ErrorText = "Please enter a department/team code."

                    End If

                    If IsValid Then

                        If Value <> AdvantageFramework.StringUtilities.RemoveAllNonAlphaNumeric(Value) Then

                            IsValid = False
                            ErrorText = "Please enter a valid department/team code."

                        End If

                    End If

                    If IsValid Then

                        PropertyValue = Value

                        If Me.IsEntityBeingAdded() Then

                            If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).DepartmentTeams
                                Where Entity.Code.ToUpper = DirectCast(PropertyValue, String).ToUpper
                                Select Entity).Any Then

                                IsValid = False
                                ErrorText = "Please enter a unique department/team code."

                            End If

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.DepartmentTeam.Properties.PurchaseOrderApprovalRuleCode.ToString

                    If Value <> Nothing AndAlso Value <> "" Then

                        If AdvantageFramework.Database.Procedures.PurchaseOrderApprovalRule.LoadByPurchaseOrderApprovalRuleCode(_DbContext, Value) Is Nothing Then

                            IsValid = False
                            ErrorText = "Purchase Order Approval Rule Code does not exist in the system"

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.DepartmentTeam.Properties.ServiceFeeTypeCode.ToString

                    If Value <> Nothing AndAlso Value <> "" Then

                        If AdvantageFramework.Database.Procedures.ServiceFeeType.LoadByServiceFeeTypeCode(_DbContext, Value) Is Nothing Then

                            IsValid = False
                            ErrorText = "Service Fee Type Code does not exist in the system"

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

	End Class

End Namespace
