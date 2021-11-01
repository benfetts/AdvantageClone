Namespace Database.Entities

	<Table("IMP_EMP_STAGING")>
	Public Class ImportEmployeeStaging
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			EmployeeCode
			DepartmentTeamCode
			LastName
			FirstName
			MiddleInitial
			CostRate
			Address
			Address2
			City
			County
			PhoneNumber
			State
            OtherInfo
            Zip
			Title
			StartDate
			TerminationDate
			BirthDate
			LastIncrease
			NextReview
			AnnualSalary
			MonthlySalary
			Email
			MonthHoursGoal
			OfficeCode
			SupervisorEmployeeCode
			FunctionCode
			PurchaseOrderLimit
			AccountNumber
			WorkPhoneNumber
			CellPhoneNumber
			AlternatePhoneNumber
			WorkPhoneNumberExtension
			AnnualHours
			DirectHours
			RoleCode
			PurchaseOrderApprovalRuleCode
			IsNew
			BillRate
			IsOnHold

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("IMPORT_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ID() As Integer
		<MaxLength(6)>
		<Column("EMP_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.Code)>
		Public Property EmployeeCode() As String
		<MaxLength(4)>
		<Column("DP_TM_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.DepartmentTeamCode)>
		Public Property DepartmentTeamCode() As String
		<MaxLength(30)>
		<Column("EMP_LNAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property LastName() As String
		<MaxLength(30)>
		<Column("EMP_FNAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property FirstName() As String
		<MaxLength(1)>
		<Column("EMP_MI", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MiddleInitial() As String
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(9, 2)>
        <Column("EMP_COST_RATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="c2")>
		Public Property CostRate() As Nullable(Of Decimal)
		<MaxLength(30)>
		<Column("EMP_ADDRESS1", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Address() As String
		<MaxLength(30)>
		<Column("EMP_ADDRESS2", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Address2() As String
		<MaxLength(20)>
		<Column("EMP_CITY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property City() As String
		<MaxLength(20)>
		<Column("EMP_COUNTY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property County() As String
		<MaxLength(13)>
		<Column("EMP_PHONE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PhoneNumber() As String
		<MaxLength(10)>
		<Column("EMP_STATE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property State() As String
		<MaxLength(20)>
        <Column("EMP_OTHER_INFO", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.SocialSecurityNumber)>
        Public Property OtherInfo() As String
        <MaxLength(10)>
		<Column("EMP_ZIP", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Zip() As String
		<MaxLength(50)>
		<Column("EMP_TITLE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Title() As String
		<Column("EMP_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property StartDate() As Nullable(Of Date)
		<Column("EMP_TERM_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TerminationDate() As Nullable(Of Date)
		<Column("EMP_BIRTH_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BirthDate() As Nullable(Of Date)
		<Column("EMP_LAST_INCREASE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property LastIncrease() As Nullable(Of Date)
		<Column("EMP_NEXT_REVIEW")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NextReview() As Nullable(Of Date)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(15, 2)>
        <Column("EMP_ANNUAL_SALARY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="c2")>
        Public Property AnnualSalary() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(11, 2)>
        <Column("EMP_MONTHLY_SALARY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="c2")>
		Public Property MonthlySalary() As Nullable(Of Decimal)
		<MaxLength(50)>
		<Column("EMP_EMAIL", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.Email)>
        Public Property Email() As String
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(9, 3)>
        <Column("MTH_HRS_GOAL")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MonthHoursGoal() As Nullable(Of Decimal)
		<MaxLength(4)>
		<Column("OFFICE_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.OfficeCode)>
		Public Property OfficeCode() As String
		<MaxLength(6)>
		<Column("SUPERVISOR_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.EmployeeCode)>
		Public Property SupervisorEmployeeCode() As String
		<MaxLength(6)>
		<Column("DEF_FNC_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.EmployeeFunctionCode)>
        Public Property FunctionCode() As String
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(15, 2)>
        <Column("PO_LIMIT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="c2")>
		Public Property PurchaseOrderLimit() As Nullable(Of Decimal)
		<MaxLength(30)>
		<Column("EMP_ACCOUNT_NBR", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AccountNumber() As String
		<MaxLength(13)>
		<Column("EMP_PHONE_WORK", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property WorkPhoneNumber() As String
		<MaxLength(13)>
		<Column("EMP_PHONE_CELL", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CellPhoneNumber() As String
		<MaxLength(13)>
		<Column("EMP_PHONE_ALT", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AlternatePhoneNumber() As String
		<MaxLength(10)>
		<Column("EMP_PHONE_WORK_EXT", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property WorkPhoneNumberExtension() As String
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(9, 3)>
        <Column("STD_ANNUAL_HRS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AnnualHours() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 4)>
        <Column("DIRECT_HRS_PER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DirectHours() As Nullable(Of Decimal)
		<MaxLength(6)>
		<Column("DEF_TRF_ROLE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.RoleCode)>
		Public Property RoleCode() As String
		<MaxLength(6)>
		<Column("PO_APPR_RULE_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.PurchaseOrderApprovalRuleCode)>
		Public Property PurchaseOrderApprovalRuleCode() As String
		<Required>
		<Column("IS_NEW")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property IsNew() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(9, 2)>
        <Column("EMP_BILL_RATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="c2")>
		Public Property BillRate() As Nullable(Of Decimal)
		<Required>
		<Column("ON_HOLD")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsOnHold() As Boolean


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function
        Protected Overrides Sub FinalizeEntityPropertyValidation(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object, ByRef ErrorText As String,
                                                                 ByVal IsEntityKey As Boolean, ByVal IsNullable As Boolean, ByVal IsRequired As Boolean, ByVal MaxLength As Integer,
                                                                 ByVal Precision As Long, ByVal Scale As Long, ByVal PropertyType As AdvantageFramework.BaseClasses.PropertyTypes)

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.PhoneNumber.ToString,
                        AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.OtherInfo.ToString,
                        AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.Zip.ToString,
                        AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.Email.ToString,
                        AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.WorkPhoneNumber.ToString,
                        AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.CellPhoneNumber.ToString,
                        AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.AlternatePhoneNumber.ToString,
                        AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.Email.ToString,
                        AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.OfficeCode.ToString,
                        AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.Title.ToString,
                        AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.PurchaseOrderApprovalRuleCode.ToString,
                        AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.RoleCode.ToString,
                        AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.FunctionCode.ToString,
                        AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.SupervisorEmployeeCode.ToString

                    If Me.IsNew = False AndAlso Value = "*" Then

                        IsValid = True
                        ErrorText = ""

                    End If

            End Select

        End Sub
        Protected Overrides Sub ClearNonRequiredPropertiesWithInvalidBlankValues(ByVal PropertyName As String, ByRef Value As Object)

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.OfficeCode.ToString, _
                        AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.Title.ToString, _
                        AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.PurchaseOrderApprovalRuleCode.ToString, _
                        AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.RoleCode.ToString, _
                        AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.FunctionCode.ToString, _
                        AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.SupervisorEmployeeCode.ToString

                    Try

                        If Me.IsNew Then

                            Value = Nothing

                        Else

                            Value = ""

                        End If

                    Catch ex As Exception

                    End Try

            End Select

        End Sub
        Public Shadows Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim [Function] As AdvantageFramework.Database.Entities.Function = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.EmployeeCode.ToString

                    If Me.IsNew Then

                        If AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(_DbContext, Value) IsNot Nothing Then

                            IsValid = False
                            ErrorText = "Employee Code already exist in the system."

                        End If

                    Else

                        If AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(_DbContext, Value) Is Nothing Then

                            IsValid = False
                            ErrorText = "Employee Code does not exist in the system."

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.LastName.ToString

                    If Value <> Nothing Then

                        If Me.IsNew = False Then

                            If Value = "*" Then

                                IsValid = False
                                ErrorText = "You cannot clear an employee's last name."

                            End If

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.FirstName.ToString

                    If Value <> Nothing Then

                        If Me.IsNew = False Then

                            If Value = "*" Then

                                IsValid = False
                                ErrorText = "You cannot clear an employee's first name."

                            End If

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.Title.ToString

                    If AdvantageFramework.Database.Procedures.EmployeeTitle.LoadByEmployeeTitleDescription(_DbContext, Value) Is Nothing Then

                        If Me.IsNew = True OrElse (Value = Nothing OrElse Value <> "*") Then

                            IsValid = False
                            ErrorText = "Employee Title does not exist in the system."

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.DirectHours.ToString

                    If IsNumeric(Value) Then

                        If CDec(Value) > 100 OrElse CDec(Value) < 0 Then

                            IsValid = False
                            ErrorText = "Direct Hours needs to be between 100 and 0."

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function
        Public Shadows Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object, _
                                                         ByVal DepartmentTeams As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.DepartmentTeam), _
                                                         ByVal Offices As System.Collections.Generic.List(Of AdvantageFramework.Database.Core.Office), _
                                                         ByVal Employees As System.Collections.Generic.List(Of AdvantageFramework.Database.Core.Employee), _
                                                         ByVal Functions As System.Collections.Generic.List(Of AdvantageFramework.Database.Core.Function), _
                                                         ByVal Roles As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.Role), _
                                                         ByVal PurchaseOrderApprovalRules As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.PurchaseOrderApprovalRule), _
                                                         ByVal EmployeeTitles As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.EmployeeTitle)) As String

            'objects
            Dim ErrorText As String = ""
            Dim [Function] As AdvantageFramework.Database.Entities.Function = Nothing
            Dim PropertyValue As String = Nothing

            PropertyValue = Value

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.EmployeeCode.ToString

                    If Me.IsNew Then

                        If Employees.Any(Function(Entity) Entity.Code = PropertyValue) Then

                            IsValid = False
                            ErrorText = "Employee Code already exist in the system."

                        End If

                    Else

                        If Employees.Any(Function(Entity) Entity.Code = PropertyValue) = False Then

                            IsValid = False
                            ErrorText = "Employee Code does not exist in the system."

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.LastName.ToString

                    If Value <> Nothing Then

                        If Me.IsNew = False Then

                            If Value = "*" Then

                                IsValid = False
                                ErrorText = "You cannot clear an employee's last name."

                            End If

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.FirstName.ToString

                    If Value <> Nothing Then

                        If Me.IsNew = False Then

                            If Value = "*" Then

                                IsValid = False
                                ErrorText = "You cannot clear an employee's first name."

                            End If

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.Title.ToString

                    If EmployeeTitles.Any(Function(Entity) Entity.Description = PropertyValue) = False Then

                        If Me.IsNew = True OrElse (Value = Nothing OrElse Value <> "*") Then

                            IsValid = False
                            ErrorText = "Employee Title does not exist in the system."

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.ImportEmployeeStaging.Properties.DirectHours.ToString

                    If IsNumeric(Value) Then

                        If CDec(Value) > 100 OrElse CDec(Value) < 0 Then

                            IsValid = False
                            ErrorText = "Direct Hours needs to be between 100 and 0."

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function
        Public Shadows Function ValidateEntity(ByRef IsValid As Boolean, ByVal Properties As Generic.List(Of System.ComponentModel.PropertyDescriptor),
                                               ByVal DepartmentTeams As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.DepartmentTeam),
                                               ByVal Offices As System.Collections.Generic.List(Of AdvantageFramework.Database.Core.Office),
                                               ByVal Employees As System.Collections.Generic.List(Of AdvantageFramework.Database.Core.Employee),
                                               ByVal Functions As System.Collections.Generic.List(Of AdvantageFramework.Database.Core.Function),
                                               ByVal Roles As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.Role),
                                               ByVal PurchaseOrderApprovalRules As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.PurchaseOrderApprovalRule),
                                               ByVal EmployeeTitles As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.EmployeeTitle)) As String

            'objects
            Dim PropertyIsValid As Boolean = True
            Dim PropertyErrorText As String = ""
            Dim ErrorText As String = ""
            Dim Value As Object = Nothing
            Dim OldValue As Object = Nothing

            For Each PropertyDescriptor In Properties

				If PropertyDescriptor.PropertyType IsNot GetType(Byte()) AndAlso (PropertyDescriptor.PropertyType.IsValueType OrElse PropertyDescriptor.PropertyType Is GetType(String)) Then

					OldValue = PropertyDescriptor.GetValue(Me)
					Value = OldValue

					PropertyErrorText = ValidateEntityProperty(PropertyDescriptor, PropertyIsValid, Value, DepartmentTeams, Offices, Employees, Functions, Roles, PurchaseOrderApprovalRules, EmployeeTitles)

					If Value <> OldValue OrElse (Value Is Nothing AndAlso OldValue IsNot Nothing) Then

						PropertyDescriptor.SetValue(Me, Value)

					End If

					If PropertyIsValid = False Then

						If IsValid Then

							IsValid = False

						End If

						ErrorText = IIf(ErrorText = "", PropertyErrorText, ErrorText & Environment.NewLine & PropertyErrorText)

					ElseIf PropertyIsValid AndAlso PropertyErrorText IsNot Nothing AndAlso PropertyErrorText <> "" Then

						ErrorText = IIf(ErrorText = "", PropertyErrorText, ErrorText & Environment.NewLine & PropertyErrorText)

					End If

				End If

			Next

            _EntityError = ErrorText

            ValidateEntity = ErrorText

        End Function
        Public Shadows Function ValidateEntityProperty(ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor, ByRef IsValid As Boolean, ByRef Value As Object,
                                                       ByVal DepartmentTeams As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.DepartmentTeam),
                                                       ByVal Offices As System.Collections.Generic.List(Of AdvantageFramework.Database.Core.Office),
                                                       ByVal Employees As System.Collections.Generic.List(Of AdvantageFramework.Database.Core.Employee),
                                                       ByVal Functions As System.Collections.Generic.List(Of AdvantageFramework.Database.Core.Function),
                                                       ByVal Roles As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.Role),
                                                       ByVal PurchaseOrderApprovalRules As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.PurchaseOrderApprovalRule),
                                                       ByVal EmployeeTitles As System.Collections.Generic.List(Of AdvantageFramework.Database.Entities.EmployeeTitle)) As String

            'objects
            Dim ErrorText As String = ""
            Dim IsEntityKey As Boolean = False
            Dim IsNullable As Boolean = False
            Dim IsRequired As Boolean = False
            Dim MaxLength As Integer = 0
            Dim Precision As Long = 0
            Dim Scale As Long = 0
            Dim PropertyType As AdvantageFramework.BaseClasses.PropertyTypes = AdvantageFramework.BaseClasses.PropertyTypes.Default
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim DisplayName As String = Nothing
            Dim PropertyValue As String = Nothing

            IsValid = True

            LoadPropertyAttributes(Me.GetType, PropertyDescriptor.Name, IsEntityKey, IsNullable, IsRequired, MaxLength, Precision, Scale, PropertyType, DisplayName)

            If DisplayName Is Nothing OrElse DisplayName = "" Then

                DisplayName = AdvantageFramework.StringUtilities.GetNameAsWords(PropertyDescriptor.Name)

            End If

            Try

                ErrorText = AdvantageFramework.BaseClasses.ValidateData(Value, IsValid, DisplayName, IsEntityKey, IsRequired, IsNullable, MaxLength, Precision, Scale)

                If IsValid Then

                    Try

                        If _DataContext Is Nothing AndAlso _DbContext IsNot Nothing Then

                            _DataContext = New AdvantageFramework.Database.DataContext(_DbContext.ConnectionString, _DbContext.UserCode)

                        End If

                    Catch ex As Exception
                        _DataContext = Nothing
                    End Try

                    If PropertyType <> BaseClasses.PropertyTypes.Default Then

                        PropertyValue = Value

                        Select Case PropertyType

                            Case BaseClasses.PropertyTypes.Code

                                If Value <> AdvantageFramework.StringUtilities.RemoveAllNonAlphaNumeric(Value) Then

                                    IsValid = False

                                End If

                            Case BaseClasses.PropertyTypes.Email

                                If AdvantageFramework.StringUtilities.IsValidEmailAddress(Value) = False Then

                                    IsValid = False

                                End If

                            Case BaseClasses.PropertyTypes.SocialSecurityNumber

                                If AdvantageFramework.StringUtilities.IsValidSocialSecurityNumber(Value, True) = False Then

                                    IsValid = False

                                End If

                            Case BaseClasses.PropertyTypes.DepartmentTeamCode

                                If (From DepartmentTeam In DepartmentTeams
                                    Where DepartmentTeam.Code = DirectCast(PropertyValue, String)
                                    Select DepartmentTeam).Any = False Then

                                    IsValid = False

                                End If

                            Case BaseClasses.PropertyTypes.PurchaseOrderApprovalRuleCode

                                If (From PurchaseOrderApprovalRule In PurchaseOrderApprovalRules
                                    Where PurchaseOrderApprovalRule.Code = DirectCast(PropertyValue, String)
                                    Select PurchaseOrderApprovalRule).Any = False Then

                                    IsValid = False

                                End If

                            Case BaseClasses.PropertyTypes.RoleCode

                                If (From Role In Roles
                                    Where Role.Code = DirectCast(PropertyValue, String)
                                    Select Role).Any = False Then

                                    IsValid = False

                                End If

                            Case BaseClasses.PropertyTypes.OfficeCode

                                If (From Office In Offices
                                    Where Office.Code = PropertyValue
                                    Select Office).Any = False Then

                                    IsValid = False

                                End If

                            Case BaseClasses.PropertyTypes.EmployeeCode

                                If (From Employee In Employees
                                    Where Employee.Code = DirectCast(PropertyValue, String)
                                    Select Employee).Any = False Then

                                    IsValid = False

                                End If

                            Case BaseClasses.PropertyTypes.EmployeeFunctionCode

                                If (From [Function] In Functions
                                    Where [Function].Code = DirectCast(PropertyValue, String) AndAlso
                                          [Function].Type = "E"
                                    Select [Function]).Any = False Then

                                    IsValid = False

                                End If

                        End Select

                        If IsValid = False Then

                            ErrorText = AdvantageFramework.BaseClasses.LoadPropertyTypeErrorText(PropertyType)

                        End If

                    End If

                End If

                ErrorText &= ValidateCustomProperties(PropertyDescriptor.Name, IsValid, Value, DepartmentTeams, Offices, Employees, Functions, Roles, PurchaseOrderApprovalRules, EmployeeTitles)

            Catch ex As Exception
                IsValid = True
            End Try

            FinalizeEntityPropertyValidation(PropertyDescriptor.Name, IsValid, Value, ErrorText, IsEntityKey, IsNullable, IsRequired, MaxLength, Precision, Scale, PropertyType)

            If IsValid = False AndAlso ErrorText = "" AndAlso PropertyType <> AdvantageFramework.BaseClasses.PropertyTypes.Default Then

                ErrorText = AdvantageFramework.BaseClasses.LoadPropertyTypeErrorText(PropertyType)

            End If

            If IsValid = False AndAlso IsRequired = False AndAlso
                    (Value = Nothing OrElse Value Is Nothing OrElse (Value IsNot Nothing AndAlso Value.ToString = "")) Then

                IsValid = True
                ErrorText = ""

                ClearNonRequiredPropertiesWithInvalidBlankValues(PropertyDescriptor.Name, Value)

            End If

            _ErrorHashtable(PropertyDescriptor.Name) = ErrorText

            ValidateEntityProperty = ErrorText

        End Function
        Public Shadows Function ValidateEntity(ByRef IsValid As Boolean, ByVal Properties As Generic.List(Of System.ComponentModel.PropertyDescriptor)) As String

            'objects
            Dim PropertyIsValid As Boolean = True
            Dim PropertyErrorText As String = ""
            Dim ErrorText As String = ""
            Dim Value As Object = Nothing
            Dim OldValue As Object = Nothing

            For Each PropertyDescriptor In Properties

				If PropertyDescriptor.PropertyType IsNot GetType(Byte()) AndAlso (PropertyDescriptor.PropertyType.IsValueType OrElse PropertyDescriptor.PropertyType Is GetType(String)) Then

					OldValue = PropertyDescriptor.GetValue(Me)
					Value = OldValue

					PropertyErrorText = ValidateEntityProperty(PropertyDescriptor, PropertyIsValid, Value)

					If Value <> OldValue OrElse (Value Is Nothing AndAlso OldValue IsNot Nothing) Then

						PropertyDescriptor.SetValue(Me, Value)

					End If

					If PropertyIsValid = False Then

						If IsValid Then

							IsValid = False

						End If

						ErrorText = IIf(ErrorText = "", PropertyErrorText, ErrorText & Environment.NewLine & PropertyErrorText)

					ElseIf PropertyIsValid AndAlso PropertyErrorText IsNot Nothing AndAlso PropertyErrorText <> "" Then

						ErrorText = IIf(ErrorText = "", PropertyErrorText, ErrorText & Environment.NewLine & PropertyErrorText)

					End If

				End If

			Next

            _EntityError = ErrorText

            ValidateEntity = ErrorText

        End Function
        Public Shadows Function ValidateEntityProperty(ByVal PropertyDescriptor As System.ComponentModel.PropertyDescriptor, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim IsEntityKey As Boolean = False
            Dim IsNullable As Boolean = False
            Dim IsRequired As Boolean = False
            Dim MaxLength As Integer = 0
            Dim Precision As Long = 0
            Dim Scale As Long = 0
            Dim PropertyType As AdvantageFramework.BaseClasses.PropertyTypes = AdvantageFramework.BaseClasses.PropertyTypes.Default
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim DisplayName As String = Nothing

            IsValid = True

            LoadPropertyAttributes(Me.GetType, PropertyDescriptor.Name, IsEntityKey, IsNullable, IsRequired, MaxLength, Precision, Scale, PropertyType, DisplayName)

            If DisplayName Is Nothing OrElse DisplayName = "" Then

                DisplayName = AdvantageFramework.StringUtilities.GetNameAsWords(PropertyDescriptor.Name)

            End If

            Try

                ErrorText = AdvantageFramework.BaseClasses.ValidateData(Value, IsValid, DisplayName, IsEntityKey, IsRequired, IsNullable, MaxLength, Precision, Scale)

                If IsValid Then

                    Try

                        If _DataContext Is Nothing AndAlso _DbContext IsNot Nothing Then

                            _DataContext = New AdvantageFramework.Database.DataContext(_DbContext.ConnectionString, _DbContext.UserCode)

                        End If

                    Catch ex As Exception
                        _DataContext = Nothing
                    End Try

                    ErrorText = AdvantageFramework.BaseClasses.ValidatePropertyType(_DbContext, _DataContext, Me, Me.GetType, PropertyType, Value, IsValid)

                End If

                ErrorText &= ValidateCustomProperties(PropertyDescriptor.Name, IsValid, Value)

            Catch ex As Exception
                IsValid = True
            End Try

            FinalizeEntityPropertyValidation(PropertyDescriptor.Name, IsValid, Value, ErrorText, IsEntityKey, IsNullable, IsRequired, MaxLength, Precision, Scale, PropertyType)

            If IsValid = False AndAlso ErrorText = "" AndAlso PropertyType <> AdvantageFramework.BaseClasses.PropertyTypes.Default Then

                ErrorText = AdvantageFramework.BaseClasses.LoadPropertyTypeErrorText(PropertyType)

            End If

            If IsValid = False AndAlso IsRequired = False AndAlso
                    (Value = Nothing OrElse Value Is Nothing OrElse (Value IsNot Nothing AndAlso Value.ToString = "")) Then

                IsValid = True
                ErrorText = ""

                ClearNonRequiredPropertiesWithInvalidBlankValues(PropertyDescriptor.Name, Value)

            End If

            _ErrorHashtable(PropertyDescriptor.Name) = ErrorText

            ValidateEntityProperty = ErrorText

        End Function

#End Region

    End Class

End Namespace
