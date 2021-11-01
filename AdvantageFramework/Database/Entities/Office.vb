Namespace Database.Entities

	<Table("OFFICE")>
	Public Class Office
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
			Code
			Name
			IsInactive
			AccountsReceivableGLACode
			AccountsPayableGLACode
			AccountsPayableDiscountGLACode
			ProductionSalesGLACode
			ProductionCostOfSalesGLACode
			ProductionWorkInProgressGLACode
			ProductionDeferredSalesGLACode
			ProductionDeferredCostOfSalesGLACode
			ProductionAccruedCostOfSalesGLACode
			ProductionAccruedAccountsPayableGLACode
			SuspenseGLACode
			StateTaxGLACode
			CountyTaxGLACode
			CityTaxGLACode
			ProductionAccruedSalesTaxGLACode
			MediaAccruedAccountsPayableGLACode
			MediaAccruedCostOfSalesGLACode
			MediaCostOfSalesGLACode
			MediaDeferredCostOfSalesGLACode
			MediaDeferredSalesGLACode
			MediaSalesGLACode
			MediaWorkInProgressGLACode
			MediaAccruedSalesTaxGLACode
			ProductionAdvancedBillingIncome
			MediaAdvancedBillingIncome
			AvaTaxCompanyCode
            CurrencyGainLossGLACode
            ClientLatePaymentFeeGLACode
            Products
			Jobs
			EmployeeTimeForecastOfficeDetails
			EmployeeTimeForecastOfficeDetailJobComponents
			EmployeeTimeForecastOfficeDetailAlternateEmployees
			Employees
			EmployeeOffices
			Campaigns
			ExecutiveDesktopDocuments
			AccountsPayableGeneralLedgerAccount
			AccountsPayableDiscountGeneralLedgerAccount
			AccountsReceivableGeneralLedgerAccount
			CityTaxGeneralLedgerAccount
			CountyTaxGeneralLedgerAccount
			ProductionAccruedAccountsPayableGeneralLedgerAccount
			ProductionAccruedCostOfSalesGeneralLedgerAccount
			ProductionCostOfSalesGeneralLedgerAccount
			ProductionDeferredCostOfSalesGeneralLedgerAccount
			ProductionDeferredSalesGeneralLedgerAccount
			ProductionSalesGeneralLedgerAccount
			ProductionWorkInProgressGeneralLedgerAccount
			StateTaxGeneralLedgerAccount
			SuspenseGeneralLedgerAccount
			StandardComments
			AgencyDesktopDocuments
			OfficeDocuments
			OfficeSalesClassAccounts
			OfficeSalesTaxAccounts
			GeneralLedgerOfficeCrossReferences
			OfficeFunctionAccounts
			OfficeInterCompanies
			OfficeInterCompanies2
			Vendors
			AccountPayableInternets
			AccountPayableOutOfHomes
			GLReportTemplateOfficePresets
			AccountPayables
			AccountReceivables
			BudgetDetails
			OtherCashReceipts

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<MaxLength(4)>
		<Column("OFFICE_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.Code)>
		Public Property Code() As String
		<MaxLength(30)>
		<Column("OFFICE_NAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Name() As String
		<Column("INACTIVE_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property IsInactive() As Nullable(Of Short)
		<MaxLength(30)>
		<Column("GLACODE_AR", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property AccountsReceivableGLACode() As String
		<MaxLength(30)>
		<Column("GLACODE_AP", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property AccountsPayableGLACode() As String
		<MaxLength(30)>
		<Column("GLACODE_AP_DISC", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property AccountsPayableDiscountGLACode() As String
		<MaxLength(30)>
		<Column("PGLACODE_SALES", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property ProductionSalesGLACode() As String
		<MaxLength(30)>
		<Column("PGLACODE_COS", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property ProductionCostOfSalesGLACode() As String
		<MaxLength(30)>
		<Column("PGLACODE_WIP", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property ProductionWorkInProgressGLACode() As String
		<MaxLength(30)>
		<Column("PGLACODE_DEF_SALES", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property ProductionDeferredSalesGLACode() As String
		<MaxLength(30)>
		<Column("PGLACODE_DEF_COS", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property ProductionDeferredCostOfSalesGLACode() As String
		<MaxLength(30)>
		<Column("PGLACODE_ACC_COS", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property ProductionAccruedCostOfSalesGLACode() As String
		<MaxLength(30)>
		<Column("PGLACODE_ACC_AP", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property ProductionAccruedAccountsPayableGLACode() As String
		<MaxLength(30)>
		<Column("GLACODE_SUSPENSE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property SuspenseGLACode() As String
		<MaxLength(30)>
		<Column("GLACODE_STATE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property StateTaxGLACode() As String
		<MaxLength(30)>
		<Column("GLACODE_COUNTY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property CountyTaxGLACode() As String
		<MaxLength(30)>
		<Column("GLACODE_CITY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property CityTaxGLACode() As String
		<MaxLength(30)>
		<Column("PGLACODE_ACC_TAX", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ProductionAccruedSalesTaxGLACode() As String
		<MaxLength(30)>
		<Column("MGLACODE_ACC_AP", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property MediaAccruedAccountsPayableGLACode() As String
		<MaxLength(30)>
		<Column("MGLACODE_ACC_COS", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property MediaAccruedCostOfSalesGLACode() As String
		<MaxLength(30)>
		<Column("MGLACODE_COS", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property MediaCostOfSalesGLACode() As String
		<MaxLength(30)>
		<Column("MGLACODE_DEF_COS", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property MediaDeferredCostOfSalesGLACode() As String
		<MaxLength(30)>
		<Column("MGLACODE_DEF_SALES", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property MediaDeferredSalesGLACode() As String
		<MaxLength(30)>
		<Column("MGLACODE_SALES", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property MediaSalesGLACode() As String
		<MaxLength(30)>
		<Column("MGLACODE_WIP", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property MediaWorkInProgressGLACode() As String
		<MaxLength(30)>
		<Column("MGLACODE_ACC_TAX", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MediaAccruedSalesTaxGLACode() As String
		<Column("PRD_AB_INCOME")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ProductionAdvancedBillingIncome() As Nullable(Of Short)
		<Column("MED_AB_INCOME")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MediaAdvancedBillingIncome() As Nullable(Of Short)
		<MaxLength(25)>
		<Column("AVATAX_COMPANY_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AvaTaxCompanyCode() As String
		<MaxLength(30)>
		<Column("GLACODE_CRNCY_GAIN_LOSS", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CurrencyGainLossGLACode() As String
        <MaxLength(30)>
        <Column("GLACODE_CLIENT_LATE_PAYMENT_FEE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientLatePaymentFeeGLACode() As String

        Public Overridable Property Products As ICollection(Of Database.Entities.Product)
        Public Overridable Property Jobs As ICollection(Of Database.Entities.Job)
        Public Overridable Property EmployeeTimeForecastOfficeDetails As ICollection(Of Database.Entities.EmployeeTimeForecastOfficeDetail)
        Public Overridable Property EmployeeTimeForecastOfficeDetailJobComponents As ICollection(Of Database.Entities.EmployeeTimeForecastOfficeDetailJobComponent)
        Public Overridable Property EmployeeTimeForecastOfficeDetailAlternateEmployees As ICollection(Of Database.Entities.EmployeeTimeForecastOfficeDetailAlternateEmployee)
        Public Overridable Property Employees As ICollection(Of Database.Views.Employee)
        Public Overridable Property EmployeeOffices As ICollection(Of Database.Entities.EmployeeOffice)
        Public Overridable Property Campaigns As ICollection(Of Database.Entities.Campaign)
        Public Overridable Property ExecutiveDesktopDocuments As ICollection(Of Database.Entities.ExecutiveDesktopDocument)
        <ForeignKey("AccountsPayableGLACode")>
        Public Overridable Property AccountsPayableGeneralLedgerAccount As Database.Entities.GeneralLedgerAccount
        <ForeignKey("AccountsPayableDiscountGLACode")>
        Public Overridable Property AccountsPayableDiscountGeneralLedgerAccount As Database.Entities.GeneralLedgerAccount
        <ForeignKey("AccountsReceivableGLACode")>
        Public Overridable Property AccountsReceivableGeneralLedgerAccount As Database.Entities.GeneralLedgerAccount
        <ForeignKey("CityTaxGLACode")>
        Public Overridable Property CityTaxGeneralLedgerAccount As Database.Entities.GeneralLedgerAccount
        <ForeignKey("CountyTaxGLACode")>
        Public Overridable Property CountyTaxGeneralLedgerAccount As Database.Entities.GeneralLedgerAccount
        <ForeignKey("ProductionAccruedAccountsPayableGLACode")>
        Public Overridable Property ProductionAccruedAccountsPayableGeneralLedgerAccount As Database.Entities.GeneralLedgerAccount
        <ForeignKey("ProductionAccruedCostOfSalesGLACode")>
        Public Overridable Property ProductionAccruedCostOfSalesGeneralLedgerAccount As Database.Entities.GeneralLedgerAccount
        <ForeignKey("ProductionCostOfSalesGLACode")>
        Public Overridable Property ProductionCostOfSalesGeneralLedgerAccount As Database.Entities.GeneralLedgerAccount
        <ForeignKey("ProductionDeferredCostOfSalesGLACode")>
        Public Overridable Property ProductionDeferredCostOfSalesGeneralLedgerAccount As Database.Entities.GeneralLedgerAccount
        <ForeignKey("ProductionDeferredSalesGLACode")>
        Public Overridable Property ProductionDeferredSalesGeneralLedgerAccount As Database.Entities.GeneralLedgerAccount
        <ForeignKey("ProductionSalesGLACode")>
        Public Overridable Property ProductionSalesGeneralLedgerAccount As Database.Entities.GeneralLedgerAccount
        <ForeignKey("ProductionWorkInProgressGLACode")>
        Public Overridable Property ProductionWorkInProgressGeneralLedgerAccount As Database.Entities.GeneralLedgerAccount
        <ForeignKey("StateTaxGLACode")>
        Public Overridable Property StateTaxGeneralLedgerAccount As Database.Entities.GeneralLedgerAccount
        <ForeignKey("SuspenseGLACode")>
        Public Overridable Property SuspenseGeneralLedgerAccount As Database.Entities.GeneralLedgerAccount
        Public Overridable Property StandardComments As ICollection(Of Database.Entities.StandardComment)
        Public Overridable Property AgencyDesktopDocuments As ICollection(Of Database.Entities.AgencyDesktopDocument)
        Public Overridable Property OfficeDocuments As ICollection(Of Database.Entities.OfficeDocument)
        Public Overridable Property OfficeSalesClassAccounts As ICollection(Of Database.Entities.OfficeSalesClassAccount)
        Public Overridable Property OfficeSalesTaxAccounts As ICollection(Of Database.Entities.OfficeSalesTaxAccount)
        Public Overridable Property GeneralLedgerOfficeCrossReferences As ICollection(Of Database.Entities.GeneralLedgerOfficeCrossReference)
        Public Overridable Property OfficeFunctionAccounts As ICollection(Of Database.Entities.OfficeFunctionAccount)
        Public Overridable Property OfficeInterCompanies As ICollection(Of Database.Entities.OfficeInterCompany)
        Public Overridable Property Vendors As ICollection(Of Database.Entities.Vendor)
        Public Overridable Property AccountPayableInternets As ICollection(Of Database.Entities.AccountPayableInternet)
        Public Overridable Property AccountPayableOutOfHomes As ICollection(Of Database.Entities.AccountPayableOutOfHome)
        Public Overridable Property GLReportTemplateOfficePresets As ICollection(Of Database.Entities.GLReportTemplateOfficePreset)
        Public Overridable Property AccountPayables As ICollection(Of Database.Entities.AccountPayable)
        Public Overridable Property AccountReceivables As ICollection(Of Database.Entities.AccountReceivable)
        Public Overridable Property BudgetDetails As ICollection(Of Database.Entities.BudgetDetail)
        Public Overridable Property OtherCashReceipts As ICollection(Of Database.Entities.OtherCashReceipt)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Code & " - " & Me.Name

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.Office.Properties.Code.ToString

                    If Value Is Nothing OrElse Value.Trim = "" Then

                        IsValid = False
                        ErrorText = "Please enter a office code."

                    End If

                    If IsValid Then

                        PropertyValue = Value

                        If Me.IsEntityBeingAdded() Then

                            If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).Offices
                                Where Entity.Code.ToUpper = DirectCast(PropertyValue, String).ToUpper
                                Select Entity).Any Then

                                IsValid = False
                                ErrorText = "Please enter a unique office code."

                            End If

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function
        Public Overrides Function ValidateEntity(ByRef IsValid As Boolean) As String

            'SetRequiredFields()

            ValidateEntity = MyBase.ValidateEntity(IsValid)

        End Function
        'Public Overrides Sub SetRequiredFields()

        '    Dim PropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing

        '    PropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(Me).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

        '    For Each PropertyDescriptor In PropertyDescriptors

        '        Select Case PropertyDescriptor.Name

        '            Case AdvantageFramework.Database.Entities.Office.Properties.CurrencyGainLossGLACode.ToString

        '                If AdvantageFramework.Database.Procedures.Agency.IsMultiCurrencyEnabled(DbContext) Then

        '                    SetRequired(PropertyDescriptor, True)

        '                Else

        '                    SetRequired(PropertyDescriptor, False)

        '                End If

        '        End Select

        '    Next

        'End Sub

#End Region

    End Class

End Namespace
