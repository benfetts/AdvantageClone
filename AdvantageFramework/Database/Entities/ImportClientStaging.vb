Namespace Database.Entities

	<Table("IMP_CLIENT_STAGING")>
	Public Class ImportClientStaging
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			BatchName
			IsNew
			Code
			Name
			Address
			Address2
			City
			County
			State
			Country
			Zip
			ProductionAttentionLine
			BillingAddress
			BillingAddress2
			BillingCity
			BillingCounty
			BillingState
			BillingCountry
			BillingZip
			StatementAddress
			StatementAddress2
			StatementCity
			StatementCounty
			StatementState
			StatementCountry
			StatementZip
			ProductionFooterComments
			FiscalStart
			CreditLimit
			AssignProductionInvoicesBy
			MediaAttentionLine
			AssignMediaInvoicesBy
			MediaFooterComments
			IsActive
			IsNewBusiness
			CampaignCodeRequired
			AccountNumberRequired
			JobTypeRequired
			PromotionRequired
			OverrideAgencySettings
			DueDateRequired
			ComplexityCodeRequired
			SCFormatRequired
			DepartmentCodeRequired
			MarketCodeRequired
			AlertGroupRequired
			CoopBillingCodeRequired
			AdNumberRequired
			ClientReferenceRequired
			DateOpenedRequired
			FormatRequired
			ProductContactRequired
			ComponentBudgetRequired
			JobLogCustom1
			JobLogCustom2
			JobLogCustom3
			JobLogCustom4
			JobLogCustom5
			JobCustomComponent1Required
			JobCustomComponent2Required
			JobCustomComponent3Required
			JobCustomComponent4Required
			JobCustomComponent5Required
			ARComment
			ProductCategoryInTimesheetRequired
            'TaxFlagRequired
            FiscalPeriodRequired
			Blackplate1Required
			Blackplate2Required
			ProductionDaysToPay
			MediaDaysToPay
			ServiceFeeTypeRequired
			RequireTimeComment
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
		<MaxLength(50)>
		<Column("BATCH_NAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property BatchName() As String
		<Required>
		<Column("IS_NEW")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
		Public Property IsNew() As Boolean
		<MaxLength(6)>
		<Column("CL_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.Code)>
		Public Property Code() As String
		<MaxLength(40)>
		<Column("CL_NAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Name() As String
		<MaxLength(40)>
		<Column("CL_ADDRESS1", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Address 1")>
		Public Property Address() As String
		<MaxLength(40)>
		<Column("CL_ADDRESS2", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Address 2")>
		Public Property Address2() As String
		<MaxLength(30)>
		<Column("CL_CITY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property City() As String
		<MaxLength(20)>
		<Column("CL_COUNTY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property County() As String
		<MaxLength(10)>
		<Column("CL_STATE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property State() As String
		<MaxLength(20)>
		<Column("CL_COUNTRY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Country() As String
		<MaxLength(10)>
		<Column("CL_ZIP", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Zip() As String
		<MaxLength(40)>
		<Column("CL_ATTENTION", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ProductionAttentionLine() As String
		<MaxLength(40)>
		<Column("CL_BADDRESS1", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Billing Address 1")>
		Public Property BillingAddress() As String
		<MaxLength(40)>
		<Column("CL_BADDRESS2", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Billing Address 2")>
		Public Property BillingAddress2() As String
		<MaxLength(30)>
		<Column("CL_BCITY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BillingCity() As String
		<MaxLength(20)>
		<Column("CL_BCOUNTY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BillingCounty() As String
		<MaxLength(10)>
		<Column("CL_BSTATE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BillingState() As String
		<MaxLength(20)>
		<Column("CL_BCOUNTRY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BillingCountry() As String
		<MaxLength(10)>
		<Column("CL_BZIP", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BillingZip() As String
		<MaxLength(40)>
		<Column("CL_SADDRESS1", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Statement Address 1")>
		Public Property StatementAddress() As String
		<MaxLength(40)>
		<Column("CL_SADDRESS2", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Statement Address 2")>
		Public Property StatementAddress2() As String
		<MaxLength(30)>
		<Column("CL_SCITY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property StatementCity() As String
		<MaxLength(20)>
		<Column("CL_SCOUNTY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property StatementCounty() As String
		<MaxLength(10)>
		<Column("CL_SSTATE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property StatementState() As String
		<MaxLength(20)>
		<Column("CL_SCOUNTRY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property StatementCountry() As String
		<MaxLength(10)>
		<Column("CL_SZIP", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property StatementZip() As String
		<MaxLength(60)>
		<Column("CL_FOOTER", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Production Invoice Footer Comments")>
		Public Property ProductionFooterComments() As String
		<Column("CL_FISCAL_START")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FiscalStart() As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(15, 2)>
        <Column("CL_CREDIT_LIMIT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CreditLimit() As Nullable(Of Decimal)
		<Column("CL_INV_BY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AssignProductionInvoicesBy() As Nullable(Of Short)
		<MaxLength(40)>
		<Column("CL_MATTENTION", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MediaAttentionLine() As String
		<Column("CL_MINV_BY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AssignMediaInvoicesBy() As Nullable(Of Short)
		<MaxLength(60)>
		<Column("CL_MFOOTER", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Media Invoice Footer Comments")>
		Public Property MediaFooterComments() As String
		<Column("ACTIVE_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property IsActive() As Nullable(Of Short)
		<Column("NEW_BUSINESS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property IsNewBusiness() As Nullable(Of Short)
		<Column("CMP_CODE_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property CampaignCodeRequired() As Nullable(Of Short)
		<Column("ACCT_NBR_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property AccountNumberRequired() As Nullable(Of Short)
		<Column("JT_CODE_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property JobTypeRequired() As Nullable(Of Short)
		<Column("PROMO_CODE_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property PromotionRequired() As Nullable(Of Short)
		<Column("REQ_FLDS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property OverrideAgencySettings() As Nullable(Of Short)
		<Column("JOB_FIRST_USE_DT_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property DueDateRequired() As Nullable(Of Short)
		<Column("COMPLEX_CODE_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property ComplexityCodeRequired() As Nullable(Of Short)
		<Column("FORMAT_SC_CODE_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Sales Class Format Required", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property SCFormatRequired() As Nullable(Of Short)
		<Column("DP_TM_CODE_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property DepartmentCodeRequired() As Nullable(Of Short)
		<Column("MARKET_CODE_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property MarketCodeRequired() As Nullable(Of Short)
		<Column("EMAIL_GR_CODE_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property AlertGroupRequired() As Nullable(Of Short)
		<Column("BILL_COOP_CODE_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property CoopBillingCodeRequired() As Nullable(Of Short)
		<Column("AD_NBR_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property AdNumberRequired() As Nullable(Of Short)
		<Column("JOB_CLI_REF_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property ClientReferenceRequired() As Nullable(Of Short)
		<Column("JOB_DATE_OPENED_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property DateOpenedRequired() As Nullable(Of Short)
		<Column("JOB_AD_SIZE_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property FormatRequired() As Nullable(Of Short)
		<Column("PROD_CONT_CODE_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property ProductContactRequired() As Nullable(Of Short)
		<Column("JOB_COMP_BUDGET_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property ComponentBudgetRequired() As Nullable(Of Short)
		<Column("JOB_LOG_UDV1_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Job Custom 1 Required", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property JobLogCustom1() As Nullable(Of Short)
		<Column("JOB_LOG_UDV2_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Job Custom 2 Required", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property JobLogCustom2() As Nullable(Of Short)
		<Column("JOB_LOG_UDV3_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Job Custom 3 Required", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property JobLogCustom3() As Nullable(Of Short)
		<Column("JOB_LOG_UDV4_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Job Custom 4 Required", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property JobLogCustom4() As Nullable(Of Short)
		<Column("JOB_LOG_UDV5_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Job Custom 5 Required", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property JobLogCustom5() As Nullable(Of Short)
		<Column("JOB_CMP_UDV1_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Job Custom Component 1 Required", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property JobCustomComponent1Required() As Nullable(Of Short)
		<Column("JOB_CMP_UDV2_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Job Custom Component 2 Required", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property JobCustomComponent2Required() As Nullable(Of Short)
		<Column("JOB_CMP_UDV3_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Job Custom Component 3 Required", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property JobCustomComponent3Required() As Nullable(Of Short)
		<Column("JOB_CMP_UDV4_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Job Custom Component 4 Required", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property JobCustomComponent4Required() As Nullable(Of Short)
		<Column("JOB_CMP_UDV5_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Job Custom Component 5 Required", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property JobCustomComponent5Required() As Nullable(Of Short)
		<Column("CL_AR_COMMENT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ARComment() As String
		<Column("REQ_PROD_CAT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property ProductCategoryInTimesheetRequired() As Nullable(Of Short)
		<Column("TAX_FLAG_R")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property TaxFlagRequired() As Nullable(Of Short)
		<Column("FISCAL_PD_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property FiscalPeriodRequired() As Nullable(Of Short)
		<Column("BLACKPLATE_VER_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Blackplate 1 Required", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property Blackplate1Required() As Nullable(Of Short)
		<Column("BLACKPLATE_VER2_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Blackplate 2 Required", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property Blackplate2Required() As Nullable(Of Short)
		<Column("CL_P_PAYDAYS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ProductionDaysToPay() As Nullable(Of Short)
		<Column("CL_M_PAYDAYS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MediaDaysToPay() As Nullable(Of Short)
		<Column("SERVICE_FEE_TYPE_R")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.StandardCheckBox)>
		Public Property ServiceFeeTypeRequired() As Nullable(Of Short)
		<Required>
		<Column("REQ_TIME_COMMENT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RequireTimeComment() As Boolean
		<Required>
		<Column("ON_HOLD")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsOnHold() As Boolean


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As String = Nothing

            PropertyValue = Value

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.ImportClientStaging.Properties.Code.ToString

                    If Me.IsNew Then

                        If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).Clients _
                                Where Entity.Code.ToUpper = DirectCast(PropertyValue, String).ToUpper _
                                Select Entity).Any Then

                            IsValid = False
                            ErrorText = "Client code already exists in the system."

                        Else

                            Try

                                If _DataContext IsNot Nothing Then

                                    _DataContext = New AdvantageFramework.Database.DataContext(_DbContext.ConnectionString, _DbContext.UserCode)

                                End If

                            Catch ex As Exception
                                _DataContext = Nothing
                            End Try

                            ErrorText = AdvantageFramework.BaseClasses.ValidatePropertyType(DbContext, DataContext, BaseClasses.PropertyTypes.Code, Value, IsValid)

                        End If

                    Else

                        If AdvantageFramework.Database.Procedures.Client.LoadByClientCode(_DbContext, PropertyValue) Is Nothing Then

                            IsValid = False
                            ErrorText = "Client code does not exist in the system."

                        End If

                    End If

                Case AdvantageFramework.Database.Entities.ImportClientStaging.Properties.Name.ToString

                    If Value <> Nothing Then

                        If Me.IsNew = False Then

                            If Value = "*" Then

                                IsValid = False
                                ErrorText = "You cannot clear a client's name."

                            End If

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

	End Class

End Namespace
