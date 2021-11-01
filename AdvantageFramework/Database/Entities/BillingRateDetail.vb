Namespace Database.Entities

	<Table("BILLING_RATE")>
	Public Class BillingRateDetail
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			BillingRateLevelID
			EmployeeCode
			FunctionCode
			ClientCode
			DivisionCode
			ProductCode
			SalesClassCode
			EffectiveDate
			RateAmount
			IsNonBillable
			IsFeeTime
			IsTaxCommission
			IsCommission
			IsTax
			TaxCode
			IsInactive
			EmployeeTitleID
			BillingRateLevel
			[Function]
			Product
			SalesClass
			EmployeeTitle
			Employee
			Client
			Division

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("BILLING_RATE_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ID() As Integer
		<Required>
		<Column("BILL_RATE_PREC_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property BillingRateLevelID() As Short
		<MaxLength(6)>
		<Column("EMP_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Employee", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.EmployeeCode)>
		Public Property EmployeeCode() As String
		<MaxLength(6)>
		<Column("FNC_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Function", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.FunctionCode)>
		Public Property FunctionCode() As String
		<MaxLength(6)>
		<Column("CL_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Client", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.ClientCode)>
		Public Property ClientCode() As String
		<MaxLength(6)>
		<Column("DIV_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Division", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.DivisionCode)>
		Public Property DivisionCode() As String
		<MaxLength(6)>
		<Column("PRD_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Product", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.ProductCode)>
		Public Property ProductCode() As String
		<MaxLength(6)>
		<Column("SC_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Sales Class", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.SalesClassCode)>
		Public Property SalesClassCode() As String
		<Column("EFFECTIVE_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EffectiveDate() As Nullable(Of Date)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(10, 3)>
        <Column("BILLING_RATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="F3", CustomColumnCaption:="Rate")>
		Public Property RateAmount() As Nullable(Of Decimal)
		<Column("NOBILL_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Non Billable")>
		Public Property IsNonBillable() As Nullable(Of Short)
		<Column("FEE_TIME")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Fee Time")>
		Public Property IsFeeTime() As Nullable(Of Short)
		<Column("TAX_COMM_FLAGS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Markup Tax Flags")>
        Public Property IsTaxCommission() As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(9, 3)>
        <Column("COMMISSION")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="F3", CustomColumnCaption:="Markup Percent")>
		Public Property IsCommission() As Nullable(Of Decimal)
		<Column("TAX_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Tax Flag")>
		Public Property IsTax() As Nullable(Of Short)
		<MaxLength(6)>
		<Column("TAX_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.SalesTaxCode)>
		Public Property TaxCode() As String
		<Column("INACTIVE_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsInactive() As Nullable(Of Short)
		<Column("EMPLOYEE_TITLE_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Employee Title", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.EmployeeTitleID)>
		Public Property EmployeeTitleID() As Nullable(Of Integer)

        Public Overridable Property BillingRateLevel As Database.Entities.BillingRateLevel
        Public Overridable Property [Function] As Database.Entities.Function
        <ForeignKey("ClientCode, DivisionCode, ProductCode")>
        Public Overridable Property Product As Database.Entities.Product
        Public Overridable Property SalesClass As Database.Entities.SalesClass
        Public Overridable Property EmployeeTitle As Database.Entities.EmployeeTitle
        Public Overridable Property Employee As Database.Views.Employee
        Public Overridable Property Client As Database.Entities.Client
        <ForeignKey("ClientCode, DivisionCode")>
        Public Overridable Property Division As Database.Entities.Division

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function
        Public Overrides Function ValidateEntity(ByRef IsValid As Boolean) As String

            SetRequiredFields()

            ValidateEntity = MyBase.ValidateEntity(IsValid)

        End Function
        Protected Overrides Sub FinalizeEntityPropertyValidation(PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object, ByRef ErrorText As String, IsEntityKey As Boolean, IsNullable As Boolean, IsRequired As Boolean, MaxLength As Integer, Precision As Long, Scale As Long, PropertyType As BaseClasses.Methods.PropertyTypes)

            If IsValid Then

                ErrorText = ""

            End If

        End Sub
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing
            Dim BillingRateDetail As AdvantageFramework.Database.Entities.BillingRateDetail = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.BillingRateDetail.Properties.BillingRateLevelID.ToString

                    If Me.IsEntityBeingAdded() Then

						If DbContext.Database.SqlQuery(Of Boolean)(String.Format("EXEC [dbo].[advsp_billing_rate_check_for_unique] {0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}',{8}",
																				 Me.BillingRateLevelID,
																				 If(String.IsNullOrWhiteSpace(Me.EmployeeCode), "", Me.EmployeeCode),
																				 If(String.IsNullOrWhiteSpace(Me.FunctionCode), "", Me.FunctionCode),
																				 If(String.IsNullOrWhiteSpace(Me.ClientCode), "", Me.ClientCode),
																				 If(String.IsNullOrWhiteSpace(Me.DivisionCode), "", Me.DivisionCode),
																				 If(String.IsNullOrWhiteSpace(Me.ProductCode), "", Me.ProductCode),
																				 If(String.IsNullOrWhiteSpace(Me.SalesClassCode), "", Me.SalesClassCode),
																				 If(Me.EffectiveDate.HasValue = False, "01/01/1900", Me.EffectiveDate.Value.ToString("MM/dd/yyyy")),
																				 Me.EmployeeTitleID.GetValueOrDefault(0))).First = False Then

							IsValid = False

							ErrorText = "Please enter a unique billing rate detail."

						End If

						'For Each BillingRateDetail In Me.DbContext.BillingRateDetails.Where(Function(Entity) Entity.BillingRateLevelID = Me.BillingRateLevelID).ToList

						'	If BillingRateDetail.BillingRateLevelID = Me.BillingRateLevelID Then

						'		If BillingRateDetail.EmployeeCode = Me.EmployeeCode Then

						'			If BillingRateDetail.FunctionCode = Me.FunctionCode Then

						'				If BillingRateDetail.ClientCode = Me.ClientCode Then

						'					If BillingRateDetail.DivisionCode = Me.DivisionCode Then

						'						If BillingRateDetail.ProductCode = Me.ProductCode Then

						'							If BillingRateDetail.SalesClassCode = Me.SalesClassCode Then

						'								If (BillingRateDetail.EffectiveDate Is Nothing AndAlso Me.EffectiveDate Is Nothing) OrElse System.DateTime.Compare(BillingRateDetail.EffectiveDate, Me.EffectiveDate) = 0 Then

						'									If BillingRateDetail.EmployeeTitleID.GetValueOrDefault(0) = Me.EmployeeTitleID.GetValueOrDefault(0) Then

						'										IsValid = False

						'										ErrorText = "Please enter a unique billing rate detail."

						'										Exit For

						'									End If

						'								End If

						'							End If

						'						End If

						'					End If

						'				End If

						'			End If

						'		End If

						'	End If

						'Next

					End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function
        Public Overrides Sub SetRequiredFields()

            Dim PropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing
            Dim EntityAttribute As AdvantageFramework.BaseClasses.Attributes.EntityAttribute = Nothing
            Dim BillingRateLevel As AdvantageFramework.Database.Entities.BillingRateLevel = Nothing

            Try

                BillingRateLevel = (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).BillingRateLevels _
                                    Where Entity.ID = Me.BillingRateLevelID _
                                    Select Entity).FirstOrDefault

            Catch ex As Exception
                BillingRateLevel = Nothing
            End Try

            If BillingRateLevel IsNot Nothing Then

                PropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(Me).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

                For Each PropertyDescriptor In PropertyDescriptors

                    Select Case PropertyDescriptor.Name

                        Case AdvantageFramework.Database.Entities.BillingRateDetail.Properties.ClientCode.ToString

                            SetRequired(PropertyDescriptor, Convert.ToBoolean(BillingRateLevel.IsClientIncluded.GetValueOrDefault(0)))

                        Case AdvantageFramework.Database.Entities.BillingRateDetail.Properties.DivisionCode.ToString

                            SetRequired(PropertyDescriptor, Convert.ToBoolean(BillingRateLevel.IsDivisionIncluded.GetValueOrDefault(0)))

                        Case AdvantageFramework.Database.Entities.BillingRateDetail.Properties.ProductCode.ToString

                            SetRequired(PropertyDescriptor, Convert.ToBoolean(BillingRateLevel.IsProductIncluded.GetValueOrDefault(0)))

                        Case AdvantageFramework.Database.Entities.BillingRateDetail.Properties.SalesClassCode.ToString

                            SetRequired(PropertyDescriptor, Convert.ToBoolean(BillingRateLevel.IsSalesClassIncluded.GetValueOrDefault(0)))

                        Case AdvantageFramework.Database.Entities.BillingRateDetail.Properties.FunctionCode.ToString

                            SetRequired(PropertyDescriptor, Convert.ToBoolean(BillingRateLevel.IsFunctionIncluded.GetValueOrDefault(0)))

                        Case AdvantageFramework.Database.Entities.BillingRateDetail.Properties.EmployeeTitleID.ToString

                            SetRequired(PropertyDescriptor, Convert.ToBoolean(BillingRateLevel.IsEmployeeTitleIncluded.GetValueOrDefault(0)))

                        Case AdvantageFramework.Database.Entities.BillingRateDetail.Properties.EmployeeCode.ToString

                            SetRequired(PropertyDescriptor, Convert.ToBoolean(BillingRateLevel.IsEmployeeIncluded.GetValueOrDefault(0)))

                        Case AdvantageFramework.Database.Entities.BillingRateDetail.Properties.EffectiveDate.ToString

                            SetRequired(PropertyDescriptor, Convert.ToBoolean(BillingRateLevel.IsEffectiveDateIncluded.GetValueOrDefault(0)))

                    End Select

                Next

            End If

        End Sub

#End Region

	End Class

End Namespace
