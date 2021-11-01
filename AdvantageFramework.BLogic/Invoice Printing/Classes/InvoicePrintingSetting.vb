Namespace InvoicePrinting.Classes

    <Serializable()>
    Public Class InvoicePrintingSetting

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            IsOneTime
            Type
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
            PrintContactAfterAddress
            ContactType
            IndicateTaxableFunctions
            HideFunctionTotals
            PageHeaderComment
            PageFooterComment
            PageHeaderLogoPath
            PageHeaderLogoPathLandscape
            PageFooterLogoPath
            PageFooterLogoPathLandscape
            CityTaxLabel
            CountyTaxLabel
            StateTaxLabel
            ProductionInvoicePrintingOptionsID
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
            ShowEmployeeTimeFunctionComment
            ShowAccountsPayableFunctionComment
            ShowIncomeOnlyFunctionComment
            SummaryLevel
            PageSetting
            ClientDaysToPay
            BreakupByJobComponent
            ShowPageHeaderLogo
            ShowPageFooterLogo
            HideExchangeRateMessage
        End Enum

#End Region

#Region " Variables "

        Private _IsOneTime As Nullable(Of Boolean) = Nothing
        Private _Type As Nullable(Of Short) = Nothing
        Private _ClientCode As String = Nothing
        Private _IncludeBackupReport As Nullable(Of Boolean) = Nothing
        Private _AddressBlockType As Nullable(Of Short) = Nothing
        Private _IncludeClientReference As Nullable(Of Boolean) = Nothing
        Private _IncludeClientPO As Nullable(Of Boolean) = Nothing
        Private _IncludeAccountExecutive As Nullable(Of Boolean) = Nothing
        Private _IncludeSalesClass As Nullable(Of Boolean) = Nothing
        Private _IncludeBillingComment As Nullable(Of Boolean) = Nothing
        Private _IncludeBillingApprovalClientComment As Nullable(Of Boolean) = Nothing
        Private _IncludeJobComment As Nullable(Of Boolean) = Nothing
        Private _IncludeJobComponentComment As Nullable(Of Boolean) = Nothing
        Private _IncludeEstimateComment As Nullable(Of Boolean) = Nothing
        Private _IncludeEstimateComponentComment As Nullable(Of Boolean) = Nothing
        Private _IncludeEstimateQuoteComment As Nullable(Of Boolean) = Nothing
        Private _IncludeEstimateRevisionComment As Nullable(Of Boolean) = Nothing
        Private _ReportFormatType As Nullable(Of Short) = Nothing
        Private _ShowEmployeeHours As Nullable(Of Boolean) = Nothing
        Private _ShowQuantity As Nullable(Of Boolean) = Nothing
        Private _ApplyExchangeRate As Nullable(Of Short) = Nothing
        Private _ExchangeRateAmount As Nullable(Of Decimal) = Nothing
        Private _GroupingOptionType As Nullable(Of Short) = Nothing
        Private _GroupingOptionInsideDescription As String = Nothing
        Private _GroupingOptionOutsideDescription As String = Nothing
        Private _SortFunctionByType As Nullable(Of Short) = Nothing
        Private _PrintFunctionType As Nullable(Of Short) = Nothing
        Private _ShowFunctionDetail As Nullable(Of Boolean) = Nothing
        Private _ShowZeroFunctionAmounts As Nullable(Of Boolean) = Nothing
        Private _TotalsShowCommissionSeparately As Nullable(Of Boolean) = Nothing
        Private _TotalsShowTaxSeparately As Nullable(Of Boolean) = Nothing
        Private _TotalsShowBillingHistory As Nullable(Of Boolean) = Nothing
        Private _InvoiceFooterCommentType As Nullable(Of Short) = Nothing
        Private _InvoiceFooterComment As String = Nothing
        Private _LocationCode As String = Nothing
        Private _BackupReportColumnOption As Nullable(Of Short) = Nothing
        Private _BackupReportCommentOptionEmployeeTimeFunction As Nullable(Of Boolean) = Nothing
        Private _BackupReportCommentOptionAccountsPayableFunction As Nullable(Of Boolean) = Nothing
        Private _BackupReportCommentOptionIncomeOnlyFunction As Nullable(Of Boolean) = Nothing
        Private _BackupReportCommentOptionBillingApprovalClientFunction As Nullable(Of Boolean) = Nothing
        Private _CustomFormatName As String = Nothing
        Private _PrintDivisionName As Nullable(Of Boolean) = Nothing
        Private _PrintProductDescription As Nullable(Of Boolean) = Nothing
        Private _HideComponentNumberAndDescription As Nullable(Of Boolean) = Nothing
        Private _InvoiceTitle As String = Nothing
        Private _UseInvoiceCategoryDescription As Nullable(Of Boolean) = Nothing
        Private _IncludeInvoiceDueDate As Nullable(Of Boolean) = Nothing
        Private _PrintContactAfterAddress As Nullable(Of Boolean) = Nothing
        Private _ContactType As Integer = 0
        Private _IndicateTaxableFunctions As Nullable(Of Boolean) = Nothing
        Private _HideFunctionTotals As Nullable(Of Boolean) = Nothing
        Private _PageHeaderComment As String = Nothing
        Private _PageFooterComment As String = Nothing
        Private _PageHeaderLogoPath As String = Nothing
        Private _PageHeaderLogoPathLandscape As String = Nothing
        Private _PageFooterLogoPath As String = Nothing
        Private _PageFooterLogoPathLandscape As String = Nothing
        Private _CityTaxLabel As String = Nothing
        Private _CountyTaxLabel As String = Nothing
        Private _StateTaxLabel As String = Nothing
        Private _ProductionInvoicePrintingOptionsID As Nullable(Of Integer) = Nothing
        Private _UseLocationPrintOptions As Nullable(Of Boolean) = Nothing
        Private _CustomInvoiceID As Nullable(Of Integer) = Nothing
        Private _ClientPOLocation As Integer = Nothing
        Private _CommissionLabel As String = Nothing
        Private _HideJobInfo As Boolean = Nothing
        Private _PrintClientName As Boolean = Nothing
        Private _ShowCampaign As Boolean = Nothing
        Private _ShowCampaignComment As Boolean = Nothing
        Private _ShowCodes As Boolean = Nothing
        Private _TaxTotalLocation As Integer = Nothing
        Private _ClientRefLocation As Integer = Nothing
        Private _SalesClassLocation As Integer = Nothing
        Private _CampaignLocation As Integer = Nothing
        Private _HeaderGroupBy As Integer = Nothing
        Private _IncludeEstimateFunctionComment As Boolean = Nothing
        Private _ShowAPDescription As Boolean = Nothing
        Private _ShowAPDate As Boolean = Nothing
        Private _ShowAPRate As Boolean = Nothing
        Private _ShowEmployeeTimeDescription As Boolean = Nothing
        Private _ShowEmployeeTimeDate As Boolean = Nothing
        Private _ShowEmployeeTimeRate As Boolean = Nothing
        Private _ShowIncomeOnlyDescription As Boolean = Nothing
        Private _ShowIncomeOnlyDate As Boolean = Nothing
        Private _ShowIncomeOnlyRate As Boolean = Nothing
        Private _ShowEmployeeTimeFunctionComment As Boolean = Nothing
        Private _ShowAccountsPayableFunctionComment As Boolean = Nothing
        Private _ShowIncomeOnlyFunctionComment As Boolean = Nothing
        Private _SummaryLevel As Integer = Nothing
        Private _BreakupByJobComponent As Boolean = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IsOneTime() As Nullable(Of Boolean)
            Get
                IsOneTime = _IsOneTime
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _IsOneTime = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Type() As Nullable(Of Short)
            Get
                Type = _Type
            End Get
            Set(ByVal value As Nullable(Of Short))
                _Type = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(ByVal value As String)
                _ClientCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IncludeBackupReport() As Nullable(Of Boolean)
            Get
                IncludeBackupReport = _IncludeBackupReport
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _IncludeBackupReport = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AddressBlockType() As Nullable(Of Short)
            Get
                AddressBlockType = _AddressBlockType
            End Get
            Set(ByVal value As Nullable(Of Short))
                _AddressBlockType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IncludeClientReference() As Nullable(Of Boolean)
            Get
                IncludeClientReference = _IncludeClientReference
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _IncludeClientReference = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IncludeClientPO() As Nullable(Of Boolean)
            Get
                IncludeClientPO = _IncludeClientPO
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _IncludeClientPO = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IncludeAccountExecutive() As Nullable(Of Boolean)
            Get
                IncludeAccountExecutive = _IncludeAccountExecutive
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _IncludeAccountExecutive = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IncludeSalesClass() As Nullable(Of Boolean)
            Get
                IncludeSalesClass = _IncludeSalesClass
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _IncludeSalesClass = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IncludeBillingComment() As Nullable(Of Boolean)
            Get
                IncludeBillingComment = _IncludeBillingComment
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _IncludeBillingComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IncludeBillingApprovalClientComment() As Nullable(Of Boolean)
            Get
                IncludeBillingApprovalClientComment = _IncludeBillingApprovalClientComment
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _IncludeBillingApprovalClientComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IncludeJobComment() As Nullable(Of Boolean)
            Get
                IncludeJobComment = _IncludeJobComment
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _IncludeJobComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IncludeJobComponentComment() As Nullable(Of Boolean)
            Get
                IncludeJobComponentComment = _IncludeJobComponentComment
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _IncludeJobComponentComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IncludeEstimateComment() As Nullable(Of Boolean)
            Get
                IncludeEstimateComment = _IncludeEstimateComment
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _IncludeEstimateComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IncludeEstimateComponentComment() As Nullable(Of Boolean)
            Get
                IncludeEstimateComponentComment = _IncludeEstimateComponentComment
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _IncludeEstimateComponentComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IncludeEstimateQuoteComment() As Nullable(Of Boolean)
            Get
                IncludeEstimateQuoteComment = _IncludeEstimateQuoteComment
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _IncludeEstimateQuoteComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IncludeEstimateRevisionComment() As Nullable(Of Boolean)
            Get
                IncludeEstimateRevisionComment = _IncludeEstimateRevisionComment
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _IncludeEstimateRevisionComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ReportFormatType() As Nullable(Of Short)
            Get
                ReportFormatType = _ReportFormatType
            End Get
            Set(ByVal value As Nullable(Of Short))
                _ReportFormatType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShowEmployeeHours() As Nullable(Of Boolean)
            Get
                ShowEmployeeHours = _ShowEmployeeHours
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _ShowEmployeeHours = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShowQuantity() As Nullable(Of Boolean)
            Get
                ShowQuantity = _ShowQuantity
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _ShowQuantity = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ApplyExchangeRate() As Nullable(Of Short)
            Get
                ApplyExchangeRate = _ApplyExchangeRate
            End Get
            Set(ByVal value As Nullable(Of Short))
                _ApplyExchangeRate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ExchangeRateAmount() As Nullable(Of Decimal)
            Get
                ExchangeRateAmount = _ExchangeRateAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _ExchangeRateAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property GroupingOptionType() As Nullable(Of Short)
            Get
                GroupingOptionType = _GroupingOptionType
            End Get
            Set(ByVal value As Nullable(Of Short))
                _GroupingOptionType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property GroupingOptionInsideDescription() As String
            Get
                GroupingOptionInsideDescription = _GroupingOptionInsideDescription
            End Get
            Set(ByVal value As String)
                _GroupingOptionInsideDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property GroupingOptionOutsideDescription() As String
            Get
                GroupingOptionOutsideDescription = _GroupingOptionOutsideDescription
            End Get
            Set(ByVal value As String)
                _GroupingOptionOutsideDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SortFunctionByType() As Nullable(Of Short)
            Get
                SortFunctionByType = _SortFunctionByType
            End Get
            Set(ByVal value As Nullable(Of Short))
                _SortFunctionByType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PrintFunctionType() As Nullable(Of Short)
            Get
                PrintFunctionType = _PrintFunctionType
            End Get
            Set(ByVal value As Nullable(Of Short))
                _PrintFunctionType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShowFunctionDetail() As Nullable(Of Boolean)
            Get
                ShowFunctionDetail = _ShowFunctionDetail
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _ShowFunctionDetail = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShowZeroFunctionAmounts() As Nullable(Of Boolean)
            Get
                ShowZeroFunctionAmounts = _ShowZeroFunctionAmounts
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _ShowZeroFunctionAmounts = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TotalsShowCommissionSeparately() As Nullable(Of Boolean)
            Get
                TotalsShowCommissionSeparately = _TotalsShowCommissionSeparately
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _TotalsShowCommissionSeparately = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TotalsShowTaxSeparately() As Nullable(Of Boolean)
            Get
                TotalsShowTaxSeparately = _TotalsShowTaxSeparately
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _TotalsShowTaxSeparately = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TotalsShowBillingHistory() As Nullable(Of Boolean)
            Get
                TotalsShowBillingHistory = _TotalsShowBillingHistory
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _TotalsShowBillingHistory = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InvoiceFooterCommentType() As Nullable(Of Short)
            Get
                InvoiceFooterCommentType = _InvoiceFooterCommentType
            End Get
            Set(ByVal value As Nullable(Of Short))
                _InvoiceFooterCommentType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InvoiceFooterComment() As String
            Get
                InvoiceFooterComment = _InvoiceFooterComment
            End Get
            Set(ByVal value As String)
                _InvoiceFooterComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property LocationCode() As String
            Get
                LocationCode = _LocationCode
            End Get
            Set(ByVal value As String)
                _LocationCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BackupReportColumnOption() As Nullable(Of Short)
            Get
                BackupReportColumnOption = _BackupReportColumnOption
            End Get
            Set(ByVal value As Nullable(Of Short))
                _BackupReportColumnOption = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BackupReportCommentOptionEmployeeTimeFunction() As Nullable(Of Boolean)
            Get
                BackupReportCommentOptionEmployeeTimeFunction = _BackupReportCommentOptionEmployeeTimeFunction
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _BackupReportCommentOptionEmployeeTimeFunction = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BackupReportCommentOptionAccountsPayableFunction() As Nullable(Of Boolean)
            Get
                BackupReportCommentOptionAccountsPayableFunction = _BackupReportCommentOptionAccountsPayableFunction
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _BackupReportCommentOptionAccountsPayableFunction = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BackupReportCommentOptionIncomeOnlyFunction() As Nullable(Of Boolean)
            Get
                BackupReportCommentOptionIncomeOnlyFunction = _BackupReportCommentOptionIncomeOnlyFunction
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _BackupReportCommentOptionIncomeOnlyFunction = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BackupReportCommentOptionBillingApprovalClientFunction() As Nullable(Of Boolean)
            Get
                BackupReportCommentOptionBillingApprovalClientFunction = _BackupReportCommentOptionBillingApprovalClientFunction
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _BackupReportCommentOptionBillingApprovalClientFunction = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CustomFormatName() As String
            Get
                CustomFormatName = _CustomFormatName
            End Get
            Set(ByVal value As String)
                _CustomFormatName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PrintDivisionName() As Nullable(Of Boolean)
            Get
                PrintDivisionName = _PrintDivisionName
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _PrintDivisionName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PrintProductDescription() As Nullable(Of Boolean)
            Get
                PrintProductDescription = _PrintProductDescription
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _PrintProductDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property HideComponentNumberAndDescription() As Nullable(Of Boolean)
            Get
                HideComponentNumberAndDescription = _HideComponentNumberAndDescription
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _HideComponentNumberAndDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InvoiceTitle() As String
            Get
                InvoiceTitle = _InvoiceTitle
            End Get
            Set(ByVal value As String)
                _InvoiceTitle = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property UseInvoiceCategoryDescription() As Nullable(Of Boolean)
            Get
                UseInvoiceCategoryDescription = _UseInvoiceCategoryDescription
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _UseInvoiceCategoryDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IncludeInvoiceDueDate() As Nullable(Of Boolean)
            Get
                IncludeInvoiceDueDate = _IncludeInvoiceDueDate
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _IncludeInvoiceDueDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PrintContactAfterAddress() As Nullable(Of Boolean)
            Get
                PrintContactAfterAddress = _PrintContactAfterAddress
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _PrintContactAfterAddress = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IndicateTaxableFunctions() As Nullable(Of Boolean)
            Get
                IndicateTaxableFunctions = _IndicateTaxableFunctions
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _IndicateTaxableFunctions = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property HideFunctionTotals() As Nullable(Of Boolean)
            Get
                HideFunctionTotals = _HideFunctionTotals
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _HideFunctionTotals = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PageHeaderComment() As String
            Get
                PageHeaderComment = _PageHeaderComment
            End Get
            Set(ByVal value As String)
                _PageHeaderComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PageFooterComment() As String
            Get
                PageFooterComment = _PageFooterComment
            End Get
            Set(ByVal value As String)
                _PageFooterComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PageHeaderLogoPath() As String
            Get
                PageHeaderLogoPath = _PageHeaderLogoPath
            End Get
            Set(ByVal value As String)
                _PageHeaderLogoPath = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PageHeaderLogoPathLandscape() As String
            Get
                PageHeaderLogoPathLandscape = _PageHeaderLogoPathLandscape
            End Get
            Set(ByVal value As String)
                _PageHeaderLogoPathLandscape = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PageFooterLogoPath() As String
            Get
                PageFooterLogoPath = _PageFooterLogoPath
            End Get
            Set(ByVal value As String)
                _PageFooterLogoPath = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PageFooterLogoPathLandscape() As String
            Get
                PageFooterLogoPathLandscape = _PageFooterLogoPathLandscape
            End Get
            Set(ByVal value As String)
                _PageFooterLogoPathLandscape = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CityTaxLabel() As String
            Get
                CityTaxLabel = _CityTaxLabel
            End Get
            Set(ByVal value As String)
                _CityTaxLabel = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CountyTaxLabel() As String
            Get
                CountyTaxLabel = _CountyTaxLabel
            End Get
            Set(ByVal value As String)
                _CountyTaxLabel = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property StateTaxLabel() As String
            Get
                StateTaxLabel = _StateTaxLabel
            End Get
            Set(ByVal value As String)
                _StateTaxLabel = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductionInvoicePrintingOptionsID() As Nullable(Of Integer)
            Get
                ProductionInvoicePrintingOptionsID = _ProductionInvoicePrintingOptionsID
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _ProductionInvoicePrintingOptionsID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property UseLocationPrintOptions() As Nullable(Of Boolean)
            Get
                UseLocationPrintOptions = _UseLocationPrintOptions
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _UseLocationPrintOptions = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CustomInvoiceID() As Nullable(Of Integer)
            Get
                CustomInvoiceID = _CustomInvoiceID
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _CustomInvoiceID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientPOLocation() As Integer
            Get
                ClientPOLocation = _ClientPOLocation
            End Get
            Set(value As Integer)
                _ClientPOLocation = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property HideJobInfo() As Boolean
            Get
                HideJobInfo = _HideJobInfo
            End Get
            Set(value As Boolean)
                _HideJobInfo = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PrintClientName() As Boolean
            Get
                PrintClientName = _PrintClientName
            End Get
            Set(value As Boolean)
                _PrintClientName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShowCampaign() As Boolean
            Get
                ShowCampaign = _ShowCampaign
            End Get
            Set(value As Boolean)
                _ShowCampaign = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShowCampaignComment() As Boolean
            Get
                ShowCampaignComment = _ShowCampaignComment
            End Get
            Set(value As Boolean)
                _ShowCampaignComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShowCodes() As Boolean
            Get
                ShowCodes = _ShowCodes
            End Get
            Set(value As Boolean)
                _ShowCodes = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TaxTotalLocation() As Integer
            Get
                TaxTotalLocation = _TaxTotalLocation
            End Get
            Set(value As Integer)
                _TaxTotalLocation = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientRefLocation() As Integer
            Get
                ClientRefLocation = _ClientRefLocation
            End Get
            Set(value As Integer)
                _ClientRefLocation = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SalesClassLocation() As Integer
            Get
                SalesClassLocation = _SalesClassLocation
            End Get
            Set(value As Integer)
                _SalesClassLocation = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CampaignLocation() As Integer
            Get
                CampaignLocation = _CampaignLocation
            End Get
            Set(value As Integer)
                _CampaignLocation = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property HeaderGroupBy() As Integer
            Get
                HeaderGroupBy = _HeaderGroupBy
            End Get
            Set(value As Integer)
                _HeaderGroupBy = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IncludeEstimateFunctionComment() As Boolean
            Get
                IncludeEstimateFunctionComment = _IncludeEstimateFunctionComment
            End Get
            Set(value As Boolean)
                _IncludeEstimateFunctionComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShowAPDescription() As Boolean
            Get
                ShowAPDescription = _ShowAPDescription
            End Get
            Set(value As Boolean)
                _ShowAPDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShowAPDate() As Boolean
            Get
                ShowAPDate = _ShowAPDate
            End Get
            Set(value As Boolean)
                _ShowAPDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShowAPRate() As Boolean
            Get
                ShowAPRate = _ShowAPRate
            End Get
            Set(value As Boolean)
                _ShowAPRate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShowEmployeeTimeDescription() As Boolean
            Get
                ShowEmployeeTimeDescription = _ShowEmployeeTimeDescription
            End Get
            Set(value As Boolean)
                _ShowEmployeeTimeDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShowEmployeeTimeDate() As Boolean
            Get
                ShowEmployeeTimeDate = _ShowEmployeeTimeDate
            End Get
            Set(value As Boolean)
                _ShowEmployeeTimeDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShowEmployeeTimeRate() As Boolean
            Get
                ShowEmployeeTimeRate = _ShowEmployeeTimeRate
            End Get
            Set(value As Boolean)
                _ShowEmployeeTimeRate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShowIncomeOnlyDescription() As Boolean
            Get
                ShowIncomeOnlyDescription = _ShowIncomeOnlyDescription
            End Get
            Set(value As Boolean)
                _ShowIncomeOnlyDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShowIncomeOnlyDate() As Boolean
            Get
                ShowIncomeOnlyDate = _ShowIncomeOnlyDate
            End Get
            Set(value As Boolean)
                _ShowIncomeOnlyDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShowIncomeOnlyRate() As Boolean
            Get
                ShowIncomeOnlyRate = _ShowIncomeOnlyRate
            End Get
            Set(value As Boolean)
                _ShowIncomeOnlyRate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ContactType() As Integer
            Get
                ContactType = _ContactType
            End Get
            Set(value As Integer)
                _ContactType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShowEmployeeTimeFunctionComment() As Boolean
            Get
                ShowEmployeeTimeFunctionComment = _ShowEmployeeTimeFunctionComment
            End Get
            Set(value As Boolean)
                _ShowEmployeeTimeFunctionComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShowIncomeOnlyFunctionComment() As Boolean
            Get
                ShowIncomeOnlyFunctionComment = _ShowIncomeOnlyFunctionComment
            End Get
            Set(value As Boolean)
                _ShowIncomeOnlyFunctionComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShowAccountsPayableFunctionComment() As Boolean
            Get
                ShowAccountsPayableFunctionComment = _ShowAccountsPayableFunctionComment
            End Get
            Set(value As Boolean)
                _ShowAccountsPayableFunctionComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SummaryLevel() As Integer
            Get
                SummaryLevel = _SummaryLevel
            End Get
            Set(value As Integer)
                _SummaryLevel = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BreakupByJobComponent() As Boolean
            Get
                BreakupByJobComponent = _BreakupByJobComponent
            End Get
            Set(value As Boolean)
                _BreakupByJobComponent = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PageSetting() As Short
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientDaysToPay() As Short
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShowPageHeaderLogo() As Boolean
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ShowPageFooterLogo() As Boolean
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property HideExchangeRateMessage() As Boolean

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.IsOneTime.ToString

        End Function

#End Region

    End Class

End Namespace
