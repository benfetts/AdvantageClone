Namespace Database.Entities

    <Table("PROD_INV_DEF")>
    Public Class ProductionInvoiceDefault
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ClientOrDefault
            ClientCode
            IncludeBackupReport
            AddressBlockType
            IncludeClientReference
            IncludeClientPO
            IncludeAccountExecutive
            IncludeSalesClass
            IncludeBillingComment
            IncludeBillingApprovalClientComment
            IncludeJobComment
            IncludeJobComponentComment
            IncludeEstimateComment
            IncludeEstimateComponentComment
            IncludeEstimateQuoteComment
            IncludeEstimateRevisionComment
            ReportFormatType
            ShowEmployeeHours
            ShowQuantity
            ApplyExchangeRate
            ExchangeRateAmount
            GroupingOptionType
            GroupingOptionInsideDescription
            GroupingOptionOutsideDescription
            SortFunctionByType
            PrintFunctionType
            ShowFunctionDetail
            ShowZeroFunctionAmounts
            TotalsShowCommissionSeparately
            TotalsShowTaxSeparately
            TotalsShowBillingHistory
            InvoiceFooterCommentType
            InvoiceFooterComment
            LocationCode
            BackupReportColumnOption
            BackupReportCommentOptionEmployeeTimeFunction
            BackupReportCommentOptionAccountsPayableFunction
            BackupReportCommentOptionIncomeOnlyFunction
            BackupReportCommentOptionBillingApprovalClientFunction
            CustomFormatName
            PrintDivisionName
            PrintProductDescription
            HideComponentNumberAndDescription
            InvoiceTitle
            UseInvoiceCategoryDescription
            IncludeInvoiceDueDate
            IndicateTaxableFunctions
            HideFunctionTotals
            PrintContactAfterAddress
            UseLocationPrintOptions
            CustomInvoiceID
            ClientPOLocation
            HideJobInfo
            PrintClientName
            ShowCampaign
            ShowCampaignComment
            ShowCodes
            TaxTotalLocation
            ClientRefLocation
            SalesClassLocation
            CampaignLocation
            HeaderGroupBy
            IncludeEstimateFunctionComment
            ShowAPDescription
            ShowAPDate
            ShowAPRate
            ShowEmployeeTimeDescription
            ShowEmployeeTimeDate
            ShowEmployeeTimeRate
            ShowIncomeOnlyDescription
            ShowIncomeOnlyDate
            ShowIncomeOnlyRate
            ContactType
            UseAgencySetting
            ShowEmployeeTimeComment
            ShowIncomeOnlyComment
            ShowAPComment
            SummaryLevel
            BreakupByJobComponent
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "
        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("PROD_INV_DEF_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Integer
        <Column("CLIENT_OR_DEF")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientOrDefault() As Nullable(Of Short)
        <MaxLength(6)>
        <Column("CL_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientCode() As String
        <Column("DTL_BCKUP_RPT_INCL")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IncludeBackupReport() As Nullable(Of Short)
        <Column("ADDRESS_BLOCK")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AddressBlockType() As Nullable(Of Short)
        <Column("INV_REF_INCL")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IncludeClientReference() As Nullable(Of Short)
        <Column("INV_CL_PO_INCL")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IncludeClientPO() As Nullable(Of Short)
        <Column("INV_AE_INCL")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IncludeAccountExecutive() As Nullable(Of Short)
        <Column("INV_CLASS_INCL")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IncludeSalesClass() As Nullable(Of Short)
        <Column("BILL_COMM_INV_INCL")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IncludeBillingComment() As Nullable(Of Short)
        <Column("BILL_APPR_CL_COMM_INCL")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IncludeBillingApprovalClientComment() As Nullable(Of Short)
        <Column("JOB_COMM_INCL")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IncludeJobComment() As Nullable(Of Short)
        <Column("COMP_COMM_INCL")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IncludeJobComponentComment() As Nullable(Of Short)
        <Column("EST_COMM_INCL")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IncludeEstimateComment() As Nullable(Of Short)
        <Column("EST_COMP_COMM_INCL")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IncludeEstimateComponentComment() As Nullable(Of Short)
        <Column("EST_QTE_COMM_INCL")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IncludeEstimateQuoteComment() As Nullable(Of Short)
        <Column("EST_REV_COMM_INCL")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IncludeEstimateRevisionComment() As Nullable(Of Short)
        <Column("COL_OPTION")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ReportFormatType() As Nullable(Of Short)
        <Column("COL_OPT_HRS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ShowEmployeeHours() As Nullable(Of Short)
        <Column("COL_OPT_QTY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ShowQuantity() As Nullable(Of Short)
        <Column("COL_OPT_XCHGE_AMTS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ApplyExchangeRate() As Nullable(Of Short)
        <Column("COL_OPT_XCHGE_DEF")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(10, 4)>
        Public Property ExchangeRateAmount() As Nullable(Of Decimal)
        <Column("GRP_OPTION")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GroupingOptionType() As Nullable(Of Short)
        <MaxLength(50)>
        <Column("GRP_INSIDE_DESC", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GroupingOptionInsideDescription() As String
        <MaxLength(50)>
        <Column("GRP_OUTSIDE_DESC", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GroupingOptionOutsideDescription() As String
        <Column("FNC_SORT_BY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SortFunctionByType() As Nullable(Of Short)
        <Column("FNC_FNC_CODE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PrintFunctionType() As Nullable(Of Short)
        <Column("SHOW_FNC_DTL")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ShowFunctionDetail() As Nullable(Of Short)
        <Column("SHOW_ZERO_FNC")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ShowZeroFunctionAmounts() As Nullable(Of Short)
        <Column("TOT_SHOW_COMM")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TotalsShowCommissionSeparately() As Nullable(Of Short)
        <Column("TOT_SHOW_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TotalsShowTaxSeparately() As Nullable(Of Short)
        <Column("TOT_SHOW_BILL_HIST")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TotalsShowBillingHistory() As Nullable(Of Short)
        <Column("TOT_PAYMNT_TERMS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InvoiceFooterCommentType() As Nullable(Of Short)
        <MaxLength(50)>
        <Column("TOT_PAYMNT_TERMS_DEF", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InvoiceFooterComment() As String
        <MaxLength(50)>
        <Column("PRT_LOC_PG_FTR_DEF", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LocationCode() As String
        <Column("BACKUP_COL_OPT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BackupReportColumnOption() As Nullable(Of Short)
        <Column("BACKUP_ET_COL_OPT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BackupReportCommentOptionEmployeeTimeFunction() As Nullable(Of Short)
        <Column("BACKUP_AP_COL_OPT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BackupReportCommentOptionAccountsPayableFunction() As Nullable(Of Short)
        <Column("BACKUP_IO_COL_OPT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BackupReportCommentOptionIncomeOnlyFunction() As Nullable(Of Short)
        <Column("BACKUP_BA_CL_FNC_CMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BackupReportCommentOptionBillingApprovalClientFunction() As Nullable(Of Short)
        <MaxLength(50)>
        <Column("CUSTOM_FORMAT", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CustomFormatName() As String
        <Column("PRINT_DIV_NAME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PrintDivisionName() As Nullable(Of Short)
        <Column("PRINT_PRD_DESC")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PrintProductDescription() As Nullable(Of Short)
        <Column("COMPONENT_INCL")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property HideComponentNumberAndDescription() As Nullable(Of Short)
        <MaxLength(20)>
        <Column("INV_TITLE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InvoiceTitle() As String
        <Column("INV_CAT_TITLE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property UseInvoiceCategoryDescription() As Nullable(Of Short)
        <Column("PRT_DUE_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IncludeInvoiceDueDate() As Nullable(Of Short)
        <Column("FNC_IND_TAXABLE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IndicateTaxableFunctions() As Nullable(Of Short)
        <Column("FNC_HIDE_TOTALS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property HideFunctionTotals() As Nullable(Of Short)
        <Column("CONTACT_POS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PrintContactAfterAddress() As Nullable(Of Short)
        <Column("PRT_LOC_PG_FTR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property UseLocationPrintOptions() As Nullable(Of Short)
        <Column("CUSTOM_INVOICE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CustomInvoiceID() As Nullable(Of Integer)
        <Required>
        <Column("CLIENT_PO_LOCATION")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientPOLocation() As Integer
        <Required>
        <Column("HIDE_JOB_INFO")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property HideJobInfo() As Boolean
        <Required>
        <Column("PRINT_CLIENT_NAME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PrintClientName() As Boolean
        <Required>
        <Column("SHOW_CAMPAIGN")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ShowCampaign() As Boolean
        <Required>
        <Column("SHOW_CAMPAIGN_COMMENT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ShowCampaignComment() As Boolean
        <Required>
        <Column("SHOW_CODES")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ShowCodes() As Boolean
        <Required>
        <Column("TAX_TOTAL_LOCATION")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaxTotalLocation() As Integer
        <Required>
        <Column("CLIENT_REF_LOCATION")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientRefLocation() As Integer
        <Required>
        <Column("SALES_CLASS_LOCATION")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SalesClassLocation() As Integer
        <Required>
        <Column("CAMPAIGN_LOCATION")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CampaignLocation() As Integer
        <Required>
        <Column("HEADER_GROUP_BY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property HeaderGroupBy() As Integer
        <Required>
        <Column("INCLUDE_ESTIMATE_FUNCTION_COMMENT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IncludeEstimateFunctionComment() As Boolean
        <Required>
        <Column("SHOW_AP_DESC")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ShowAPDescription() As Boolean
        <Required>
        <Column("SHOW_AP_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ShowAPDate() As Boolean
        <Required>
        <Column("SHOW_AP_RATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ShowAPRate() As Boolean
        <Required>
        <Column("SHOW_EMPLOYEE_TIME_DESC")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ShowEmployeeTimeDescription() As Boolean
        <Required>
        <Column("SHOW_EMPLOYEE_TIME_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ShowEmployeeTimeDate() As Boolean
        <Required>
        <Column("SHOW_EMPLOYEE_TIME_RATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ShowEmployeeTimeRate() As Boolean
        <Required>
        <Column("SHOW_INCOME_ONLY_DESC")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ShowIncomeOnlyDescription() As Boolean
        <Required>
        <Column("SHOW_INCOME_ONLY_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ShowIncomeOnlyDate() As Boolean
        <Required>
        <Column("SHOW_INCOME_ONLY_RATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ShowIncomeOnlyRate() As Boolean
        <Required>
        <Column("CONTACT_TYPE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ContactType() As Integer
        <Required>
        <Column("USE_AGENCY_SETTING")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property UseAgencySetting() As Boolean
        <Required>
        <Column("SHOW_ETD_COMMENT")>
        Public Property ShowEmployeeTimeComment() As Boolean
        <Required>
        <Column("SHOW_IO_COMMENT")>
        Public Property ShowIncomeOnlyComment() As Boolean
        <Required>
        <Column("SHOW_AP_COMMENT")>
        Public Property ShowAPComment() As Boolean
        <Required>
        <Column("SUMMARY_LEVEL")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SummaryLevel() As Integer
        <Required>
        <Column("BREAKUP_BY_JOBCOMPONENT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BreakupByJobComponent() As Boolean
        <Required>
        <Column("HIDE_EXCHANGE_RATE_MESSAGE")>
        Public Property HideExchangeRateMessage As Boolean

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.ProductionInvoiceDefault.Properties.PrintDivisionName.ToString,
                        AdvantageFramework.Database.Entities.ProductionInvoiceDefault.Properties.PrintProductDescription.ToString,
                        AdvantageFramework.Database.Entities.ProductionInvoiceDefault.Properties.UseInvoiceCategoryDescription.ToString,
                        AdvantageFramework.Database.Entities.ProductionInvoiceDefault.Properties.IncludeInvoiceDueDate.ToString,
                        AdvantageFramework.Database.Entities.ProductionInvoiceDefault.Properties.ClientOrDefault.ToString

                    If IsValid Then

                        If IsNothing(Value) Then

                            Value = CShort(0)

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace
