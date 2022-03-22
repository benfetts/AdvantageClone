Namespace Billing.Reports.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class InvoicePrintingOptionsDialog
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseRibbonForm

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InvoicePrintingOptionsDialog))
        Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
        Me.ButtonItemActions_Export = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
        Me.ButtonItemActions_Save = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItemActions_Cancel = New DevComponents.DotNetBar.ButtonItem()
        Me.VerticalGridProduction_Settings = New AdvantageFramework.WinForm.Presentation.Controls.VerticalGrid()
        Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.category65 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
        Me.rowUseLocationPrintOptions = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowLocationCode = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowCustomInvoiceID = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowApplyExchangeRate = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowExchangeRateAmount = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowHideExchangeRateMessage = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.category = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
        Me.rowUseInvoiceCategoryDescription = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowInvoiceTitle = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowIncludeInvoiceDueDate = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.category2 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
        Me.category3 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
        Me.rowAddressBlockType = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowPrintClientName = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowPrintDivisionName = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowPrintProductDescription = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowPrintContactAfterAddress = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowContactType = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowShowCodes = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.category4 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
        Me.rowIncludeClientReference = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowClientRefLocation = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowIncludeClientPO = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowClientPOLocation = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowIncludeAccountExecutive = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowIncludeSalesClass = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowSalesClassLocation = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowShowCampaign = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowCampaignLocation = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.category5 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
        Me.rowIncludeInvoiceComment = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowIncludeBillingApprovalComment = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowIncludeBillingApprovalFunctionComment = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowIncludeJobComment = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowIncludeJobComponentComment = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowIncludeEstimateComment = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowIncludeEstimateComponentComment = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowIncludeEstimateQuoteComment = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowIncludeEstimateRevisionComment = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowIncludeEstimateFunctionComment = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowShowCampaignComment = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.category1 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
        Me.rowHeaderGroupBy = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowHideJobInfo = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowHideComponentNumberAndDescription = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.category6 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
        Me.category7 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
        Me.rowReportFormatType = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowSummaryLevel = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.category8 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
        Me.rowGroupingOptionType = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowGroupingOptionInsideDescription = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowGroupingOptionOutsideDescription = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.category9 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
        Me.rowSortFunctionByType = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowPrintFunctionType = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowShowFunctionDetail = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowShowZeroFunctionAmounts = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowIndicateTaxableFunctions = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowHideFunctionTotals = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowShowEmployeeHours = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowShowQuantity = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.category66 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
        Me.row0 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.row1 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.row2 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowEmployeeTimeFunctionComment = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.row3 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.row4 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.row5 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowIncomeOnlyFunctionComment = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.row6 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.row7 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.row8 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowAccountsPayableFunctionComment = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.category10 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
        Me.category11 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
        Me.rowTotalsShowTaxSeparately = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowTaxTotalLocation = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowTotalsShowCommissionSeparately = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowTotalsShowBillingHistory = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.category12 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
        Me.rowInvoiceFooterCommentType = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowInvoiceFooterComment = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.categoryBackupReportOptions = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
        Me.rowIncludeBackupReport = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowBackupReportColumnOption = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowBackupReportCommentOptionEmployeeTimeFunction = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowBackupReportCommentOptionAccountsPayableFunction = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowBackupReportCommentOptionIncomeOnlyFunction = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowBackupReportBreakupByJobComponent = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.RibbonBarOptions_SaveOptions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
        Me.ButtonItemSaveOptions_Agency = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItemSaveOptions_Clients = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItemSaveOptions_OneTime = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItemSaveOptions_Products = New DevComponents.DotNetBar.ButtonItem()
        Me.TabControlForm_Options = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelInternetTab_Internet = New DevComponents.DotNetBar.TabControlPanel()
            Me.VerticalGridInternet_Settings = New AdvantageFramework.WinForm.Presentation.Controls.VerticalGrid()
            Me.MediaInvoiceInternetSettingBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.rowInternetCustomInvoiceID = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category33 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.category34 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowInternetUseInvoiceCategoryDescription = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowInternetInvoiceTitle = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowInternetPrintInvoiceDueDate = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category35 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowInternetShowClientPO = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowInternetClientPOLocation = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowInternetShowSalesClass = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowInternetSalesClassLocation = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowInternetShowCampaign = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowInternetCampaignLocation = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowInternetShowClientReference = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category32 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowInternetShowOrderComment = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowInternetShowOrderHouseComment = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowInternetShowCampaignComment = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category71 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowInternetHeaderGroupBy = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowInternetShowOrderDescription = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowInternetShowOrderSubtotals = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category36 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowInternetShowLineDetail = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category37 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowInternetOrderNumberColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowInternetVendorNameColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowInternetShowVendorCode = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowInternetOrderMonthsColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowInternetNetAmountColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowInternetCommissionAmountColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowInternetTaxAmountColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowInternetBillAmountColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowInternetPriorBillAmountColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowInternetBilledToDateAmountColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category38 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowInternetShowZeroLineAmounts = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowInternetSortLinesBy = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowInternetLineNumberColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowInternetHeadlineColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowInternetStartDatesColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowInternetEndDatesColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowInternetCreativeSizeColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowInternetAdNumberColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowInternetURLColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowInternetInternetTypeColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowInternetCloseDateColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowInternetJobComponentNumberColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowInternetJobDescriptionColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowInternetComponentDescriptionColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowInternetExtraChargesColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowInternetGuaranteedImpressionsColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category39 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowInternetShowCommissionSeparately = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowInternetShowRebateSeparately = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowInternetShowTaxSeparately = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowInternetShowBillingHistory = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.TabItemOptions_InternetTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelComboTab_Combo = New DevComponents.DotNetBar.TabControlPanel()
            Me.VerticalGridCombo_Settings = New AdvantageFramework.WinForm.Presentation.Controls.VerticalGrid()
            Me.ComboInvoiceSettingBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.CategoryRow1 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowComboLocationCode = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowComboApplyExchangeRate = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowComboExchangeRateAmount = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.CategoryRow2 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowComboUseInvoiceCategoryDescription = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowComboInvoiceTitle = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowComboIncludeInvoiceDueDate = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.CategoryRow3 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.CategoryRow4 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowComboAddressBlockType = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowComboPrintClientName = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowComboPrintDivisionName = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowComboPrintProductDescription = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowComboPrintContactAfterAddress = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowComboContactType = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowComboShowCodes = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category24 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowComboInvoiceFooterCommentType = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowComboInvoiceFooterComment = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.TabItemOptions_ComboTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelMediaTab_Media = New DevComponents.DotNetBar.TabControlPanel()
            Me.VerticalGridMedia_Settings = New AdvantageFramework.WinForm.Presentation.Controls.VerticalGrid()
            Me.MediaInvoiceSettingBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.rowUseLocationPrintOptions1 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowLocationCode1 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowApplyExchangeRate1 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowExchangeRateAmount1 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowHideExchangeRateMessage1 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category13 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.category14 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowAddressBlockType1 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowPrintClientName1 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowPrintDivisionName1 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowPrintProductDescription1 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowPrintContactAfterAddress1 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowContactType1 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowShowCodes1 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category15 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowIncludeBillingComment1 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category16 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowInvoiceFooterCommentType1 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowInvoiceFooterComment1 = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.TabItemOptions_MediaTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelProductionTab_Production = New DevComponents.DotNetBar.TabControlPanel()
            Me.TabItemOptions_ProductionTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelTVTab_TV = New DevComponents.DotNetBar.TabControlPanel()
            Me.VerticalGridTV_Settings = New AdvantageFramework.WinForm.Presentation.Controls.VerticalGrid()
            Me.MediaInvoiceTVSettingBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.rowTVCustomInvoiceID = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category57 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.category58 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowTVUseInvoiceCategoryDescription = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowTVInvoiceTitle = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowTVPrintInvoiceDueDate = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category59 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowTVShowClientPO = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowTVClientPOLocation = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowTVShowSalesClass = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowTVSalesClassLocation = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowTVShowCampaign = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowTVCampaignLocation = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowTVShowClientReference = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category74 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowTVShowOrderComment = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowTVShowOrderHouseComment = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowTVShowCampaignComment = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category73 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowTVHeaderGroupBy = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowTVShowOrderDescription = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowTVShowOrderSubtotals = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category60 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowTVShowLineDetail = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category61 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowTVOrderNumberColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowTVVendorNameColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowTVShowVendorCode = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowTVOrderMonthsColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowTVNetAmountColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowTVCommissionAmountColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowTVTaxAmountColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowTVBillAmountColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowTVPriorBillAmountColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowTVBilledToDateAmountColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category62 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowTVShowZeroLineAmounts = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowTVSortLinesBy = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowTVLineNumberColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowTVProgramColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowTVSpotLengthColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowTVTagColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowTVStartEndTimesColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowTVNumberOfSpotsColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowTVRemarksColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowTVCloseDateColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowTVJobComponentNumberColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowTVJobDescriptionColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowTVComponentDescriptionColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowTVOrderDetailCommentColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowTVOrderHouseDetailCommentColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowTVExtraChargesColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category63 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowTVShowCommissionSeparately = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowTVShowRebateSeparately = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowTVShowTaxSeparately = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowTVShowBillingHistory = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.TabItemOptions_TVTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelRadioTab_Radio = New DevComponents.DotNetBar.TabControlPanel()
            Me.VerticalGridRadio_Settings = New AdvantageFramework.WinForm.Presentation.Controls.VerticalGrid()
            Me.MediaInvoiceRadioSettingBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.rowRadioCustomInvoiceID = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category49 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.category50 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowRadioUseInvoiceCategoryDescription = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowRadioInvoiceTitle = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowRadioPrintInvoiceDueDate = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category51 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowRadioShowClientPO = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowRadioClientPOLocation = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowRadioShowSalesClass = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowRadioSalesClassLocation = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowRadioShowCampaign = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowRadioCampaignLocation = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowRadioShowClientReference = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category72 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowRadioShowOrderComment = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowRadioShowOrderHouseComment = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowRadioShowCampaignComment = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category56 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowRadioHeaderGroupBy = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowRadioShowOrderDescription = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowRadioShowOrderSubtotals = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category52 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowRadioShowLineDetail = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category53 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowRadioOrderNumberColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowRadioVendorNameColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowRadioShowVendorCode = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowRadioOrderMonthsColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowRadioNetAmountColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowRadioCommissionAmountColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowRadioTaxAmountColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowRadioBillAmountColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowRadioPriorBillAmountColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowRadioBilledToDateAmountColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category54 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowRadioShowZeroLineAmounts = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowRadioSortLinesBy = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowRadioLineNumberColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowRadioProgramColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowRadioSpotLengthColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowRadioTagColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowRadioStartEndTimesColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowRadioNumberOfSpotsColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowRadioRemarksColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowRadioCloseDateColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowRadioJobComponentNumberColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowRadioJobDescriptionColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowRadioComponentDescriptionColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowRadioOrderDetailCommentColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowRadioOrderHouseDetailCommentColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowRadioExtraChargesColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category55 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowRadioShowCommissionSeparately = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowRadioShowRebateSeparately = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowRadioShowTaxSeparately = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowRadioShowBillingHistory = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.TabItemOptions_RadioTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelOutdoorTab_Outdoor = New DevComponents.DotNetBar.TabControlPanel()
            Me.VerticalGridOutdoor_Settings = New AdvantageFramework.WinForm.Presentation.Controls.VerticalGrid()
            Me.MediaInvoiceOutdoorSettingBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.rowOutdoorCustomInvoiceID = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category41 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.category42 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowOutdoorUseInvoiceCategoryDescription = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowOutdoorInvoiceTitle = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowOutdoorPrintInvoiceDueDate = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category43 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowOutdoorShowClientPO = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowOutdoorClientPOLocation = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowOutdoorShowSalesClass = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowOutdoorSalesClassLocation = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowOutdoorShowCampaign = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowOutdoorCampaignLocation = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowOutdoorShowClientReference = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category40 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowOutdoorShowOrderComment = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowOutdoorShowOrderHouseComment = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowOutdoorShowCampaignComment = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category48 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowOutdoorHeaderGroupBy = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowOutdoorShowOrderDescription = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowOutdoorShowOrderSubtotals = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category44 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowOutdoorShowLineDetail = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category45 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowOutdoorOrderNumberColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowOutdoorVendorNameColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowOutdoorShowVendorCode = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowOutdoorOrderMonthsColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowOutdoorNetAmountColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowOutdoorCommissionAmountColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowOutdoorTaxAmountColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowOutdoorBillAmountColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowOutdoorPriorBillAmountColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowOutdoorBilledToDateAmountColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category46 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowOutdoorShowZeroLineAmounts = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowOutdoorSortLinesBy = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowOutdoorLineNumberColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowOutdoorHeadlineColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowOutdoorInsertDatesColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowOutdoorEndDateColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowOutdoorCopyAreaColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowOutdoorAdNumberColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowOutdoorLocationColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowOutdoorOutdoorTypeColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowOutdoorSizeColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowOutdoorCloseDateColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowOutdoorJobComponentNumberColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowOutdoorJobDescriptionColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowOutdoorComponentDescriptionColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowOutdoorExtraChargesColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category47 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowOutdoorShowCommissionSeparately = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowOutdoorShowRebateSeparately = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowOutdoorShowTaxSeparately = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowOutdoorShowBillingHistory = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.TabItemOptions_OutdoorTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelNewspaperTab_Newspaper = New DevComponents.DotNetBar.TabControlPanel()
            Me.VerticalGridNewspaper_Settings = New AdvantageFramework.WinForm.Presentation.Controls.VerticalGrid()
            Me.MediaInvoiceNewspaperSettingBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.rowNewspaperCustomInvoiceID = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category25 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.category26 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowNewspaperUseInvoiceCategoryDescription = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowNewspaperInvoiceTitle = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowNewspaperPrintInvoiceDueDate = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category27 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowNewspaperShowClientPO = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowNewspaperClientPOLocation = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowNewspaperShowSalesClass = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowNewspaperSalesClassLocation = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowNewspaperShowCampaign = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowNewspaperCampaignLocation = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowNewspaperShowClientReference = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category70 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowNewspaperShowOrderComment = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowNewspaperShowOrderHouseComment = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowNewspaperShowCampaignComment = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category69 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowNewspaperHeaderGroupBy = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowNewspaperShowOrderDescription = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowNewspaperShowOrderSubtotals = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category28 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowNewspaperShowLineDetail = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category29 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowNewspaperOrderNumberColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowNewspaperVendorNameColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowNewspaperShowVendorCode = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowNewspaperOrderMonthsColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowNewspaperNetAmountColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowNewspaperCommissionAmountColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowNewspaperTaxAmountColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowNewspaperBillAmountColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowNewspaperPriorBillAmountColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowNewspaperBilledToDateAmountColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category30 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowNewspaperShowZeroLineAmounts = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowNewspaperSortLinesBy = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowNewspaperLineNumberColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowNewspaperHeadlineColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowNewspaperInsertDatesColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowNewspaperMaterialColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowNewspaperAdNumberColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowNewspaperEditorialIssueColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowNewspaperSectionColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowNewspaperQuantityColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowNewspaperAdSizeColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowNewspaperCloseDateColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowNewspaperJobComponentNumberColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowNewspaperJobDescriptionColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowNewspaperComponentDescriptionColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowNewspaperOrderDetailCommentColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowNewspaperOrderHouseDetailCommentColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowNewspaperExtraChargesColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category31 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowNewspaperShowCommissionSeparately = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowNewspaperShowRebateSeparately = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowNewspaperShowTaxSeparately = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowNewspaperShowBillingHistory = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.TabItemOptions_NewspaperTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelMagazineTab_Magazine = New DevComponents.DotNetBar.TabControlPanel()
            Me.VerticalGridMagazine_Settings = New AdvantageFramework.WinForm.Presentation.Controls.VerticalGrid()
            Me.MediaInvoiceMagazineSettingBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.rowMagazineCustomInvoiceID = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category18 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.category17 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowMagazineUseInvoiceCategoryDescription = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowMagazineInvoiceTitle = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowMagazinePrintInvoiceDueDate = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category19 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowMagazineShowClientPO = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowMagazineClientPOLocation = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowMagazineShowSalesClass = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowMagazineSalesClassLocation = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowMagazineShowCampaign = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowMagazineCampaignLocation = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowMagazineShowClientReference = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category67 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowMagazineShowOrderComment = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowMagazineShowOrderHouseComment = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowMagazineShowCampaignComment = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category68 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowMagazineHeaderGroupBy = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowMagazineShowOrderDescription = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowMagazineShowOrderSubtotals = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category20 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowMagazineShowLineDetail = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category21 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowMagazineOrderNumberColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowMagazineVendorNameColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowMagazineShowVendorCode = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowMagazineOrderMonthsColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowMagazineNetAmountColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowMagazineCommissionAmountColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowMagazineTaxAmountColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowMagazineBillAmountColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowMagazinePriorBillAmountColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowMagazineBilledToDateAmountColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category22 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowMagazineShowZeroLineAmounts = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowMagazineSortLinesBy = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowMagazineLineNumberColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowMagazineHeadlineColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowMagazineInsertDatesColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowMagazineMaterialColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowMagazineAdNumberColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowMagazineEditorialIssueColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowMagazineAdSizeColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowMagazineCloseDateColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowMagazineJobComponentNumberColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowMagazineJobDescriptionColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowMagazineComponentDescriptionColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowMagazineOrderDetailCommentColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowMagazineOrderHouseDetailCommentColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowMagazineExtraChargesColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.category23 = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowMagazineShowCommissionSeparately = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowMagazineShowRebateSeparately = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowMagazineShowTaxSeparately = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowMagazineShowBillingHistory = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.TabItemOptions_MagazineTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.LabelForm_FormatLabel = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Format = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.rowRadioStartDateColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowTVStartDateColumn = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Form.SuspendLayout()
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.VerticalGridProduction_Settings, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.TabControlForm_Options, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlForm_Options.SuspendLayout()
            Me.TabControlPanelInternetTab_Internet.SuspendLayout()
            CType(Me.VerticalGridInternet_Settings, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.MediaInvoiceInternetSettingBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelComboTab_Combo.SuspendLayout()
            CType(Me.VerticalGridCombo_Settings, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ComboInvoiceSettingBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelMediaTab_Media.SuspendLayout()
            CType(Me.VerticalGridMedia_Settings, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.MediaInvoiceSettingBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelProductionTab_Production.SuspendLayout()
            Me.TabControlPanelTVTab_TV.SuspendLayout()
            CType(Me.VerticalGridTV_Settings, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.MediaInvoiceTVSettingBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelRadioTab_Radio.SuspendLayout()
            CType(Me.VerticalGridRadio_Settings, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.MediaInvoiceRadioSettingBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelOutdoorTab_Outdoor.SuspendLayout()
            CType(Me.VerticalGridOutdoor_Settings, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.MediaInvoiceOutdoorSettingBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelNewspaperTab_Newspaper.SuspendLayout()
            CType(Me.VerticalGridNewspaper_Settings, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.MediaInvoiceNewspaperSettingBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelMagazineTab_Magazine.SuspendLayout()
            CType(Me.VerticalGridMagazine_Settings, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.MediaInvoiceMagazineSettingBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            '_DefaultLookAndFeel
            '
            Me._DefaultLookAndFeel.LookAndFeel.SkinName = "Office 2016 Colorful"
            '
            'PanelForm_Form
            '
            Me.PanelForm_Form.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelForm_Form.Appearance.Options.UseBackColor = True
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_Format)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_FormatLabel)
            Me.PanelForm_Form.Controls.Add(Me.TabControlForm_Options)
            Me.PanelForm_Form.LookAndFeel.SkinName = "Office 2013"
            Me.PanelForm_Form.LookAndFeel.UseDefaultLookAndFeel = False
            Me.PanelForm_Form.Size = New System.Drawing.Size(703, 523)
            Me.PanelForm_Form.TabIndex = 0
            '
            'RibbonControlForm_MainRibbon
            '
            '
            '
            '
            Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonControlForm_MainRibbon.Margin = New System.Windows.Forms.Padding(4)
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(703, 154)
            Me.RibbonControlForm_MainRibbon.SystemText.MaximizeRibbonText = "&Maximize the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.QatAddItemText = "&Add to Quick Access Toolbar"
            Me.RibbonControlForm_MainRibbon.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>"
            Me.RibbonControlForm_MainRibbon.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar..."
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogAddButton = "&Add >>"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogCancelButton = "Cancel"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogCaption = "Customize Quick Access Toolbar"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogCategoriesLabel = "&Choose commands from:"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogOkButton = "OK"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogRemoveButton = "&Remove"
            Me.RibbonControlForm_MainRibbon.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar"
            Me.RibbonControlForm_MainRibbon.Controls.SetChildIndex(Me.RibbonPanelFile_FilePanel, 0)
            '
            'RibbonPanelFile_FilePanel
            '
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_SaveOptions)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 57)
            Me.RibbonPanelFile_FilePanel.Margin = New System.Windows.Forms.Padding(4)
            Me.RibbonPanelFile_FilePanel.Padding = New System.Windows.Forms.Padding(4, 0, 4, 2)
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(703, 94)
            '
            '
            '
            Me.RibbonPanelFile_FilePanel.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonPanelFile_FilePanel.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonPanelFile_FilePanel.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonPanelFile_FilePanel.Visible = True
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarFilePanel_System, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Actions, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_SaveOptions, 0)
            '
            'RibbonBarFilePanel_System
            '
            '
            '
            '
            Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.BorderColor = System.Drawing.Color.DarkGray
            Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.BorderColor2 = System.Drawing.Color.DarkGray
            Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.BorderRightWidth = 2
            Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_System.BackgroundStyle.BorderColor = System.Drawing.Color.DarkGray
            Me.RibbonBarFilePanel_System.BackgroundStyle.BorderColor2 = System.Drawing.Color.DarkGray
            Me.RibbonBarFilePanel_System.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.RibbonBarFilePanel_System.BackgroundStyle.BorderRightWidth = 2
            Me.RibbonBarFilePanel_System.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFilePanel_System.Location = New System.Drawing.Point(4, 0)
            Me.RibbonBarFilePanel_System.Margin = New System.Windows.Forms.Padding(4)
            Me.RibbonBarFilePanel_System.Size = New System.Drawing.Size(100, 92)
            '
            '
            '
            Me.RibbonBarFilePanel_System.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_System.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemSystem_Close
            '
            Me.ButtonItemSystem_Close.Image = CType(resources.GetObject("ButtonItemSystem_Close.Image"), System.Drawing.Image)
            '
            'Office2007StartButtonMainRibbon_Home
            '
            Me.Office2007StartButtonMainRibbon_Home.Image = CType(resources.GetObject("Office2007StartButtonMainRibbon_Home.Image"), System.Drawing.Image)
            '
            'ProgressBarItemStatusBar_ProgressBar
            '
            '
            '
            '
            Me.ProgressBarItemStatusBar_ProgressBar.BackStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'BarForm_StatusBar
            '
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 678)
            Me.BarForm_StatusBar.Margin = New System.Windows.Forms.Padding(4)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(703, 18)
            '
            'RibbonBarOptions_Actions
            '
            Me.RibbonBarOptions_Actions.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Actions.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Actions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Actions.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Actions.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Actions.DragDropSupport = True
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Export, Me.ButtonItemActions_Save, Me.ButtonItemActions_Cancel})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(104, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(142, 92)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 13
            Me.RibbonBarOptions_Actions.Text = "Actions"
            '
            '
            '
            Me.RibbonBarOptions_Actions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Actions.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Actions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemActions_Export
            '
            Me.ButtonItemActions_Export.BeginGroup = True
            Me.ButtonItemActions_Export.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Export.Name = "ButtonItemActions_Export"
            Me.ButtonItemActions_Export.RibbonWordWrap = False
            Me.ButtonItemActions_Export.SecurityEnabled = True
            Me.ButtonItemActions_Export.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Export.Text = "Export"
            '
            'ButtonItemActions_Save
            '
            Me.ButtonItemActions_Save.BeginGroup = True
            Me.ButtonItemActions_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Save.Name = "ButtonItemActions_Save"
            Me.ButtonItemActions_Save.RibbonWordWrap = False
            Me.ButtonItemActions_Save.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Save.Text = "Save"
            '
            'ButtonItemActions_Cancel
            '
            Me.ButtonItemActions_Cancel.BeginGroup = True
            Me.ButtonItemActions_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Cancel.Name = "ButtonItemActions_Cancel"
            Me.ButtonItemActions_Cancel.RibbonWordWrap = False
            Me.ButtonItemActions_Cancel.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Cancel.Text = "Cancel"
            '
            'VerticalGridProduction_Settings
            '
            Me.VerticalGridProduction_Settings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.VerticalGridProduction_Settings.Appearance.RowHeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            Me.VerticalGridProduction_Settings.Appearance.RowHeaderPanel.Options.UseFont = True
            Me.VerticalGridProduction_Settings.Cursor = System.Windows.Forms.Cursors.Default
            Me.VerticalGridProduction_Settings.CustomizationFormBounds = New System.Drawing.Rectangle(1384, 433, 216, 265)
            Me.VerticalGridProduction_Settings.DataSource = Me.BindingSource
            Me.VerticalGridProduction_Settings.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView
            Me.VerticalGridProduction_Settings.Location = New System.Drawing.Point(4, 4)
            Me.VerticalGridProduction_Settings.Name = "VerticalGridProduction_Settings"
            Me.VerticalGridProduction_Settings.OptionsBehavior.RecordsMouseWheel = True
            Me.VerticalGridProduction_Settings.OptionsBehavior.ResizeRowHeaders = False
            Me.VerticalGridProduction_Settings.OptionsBehavior.UseEnterAsTab = True
            Me.VerticalGridProduction_Settings.Rows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.category65, Me.category, Me.category2, Me.category1, Me.category6, Me.category10, Me.categoryBackupReportOptions})
            Me.VerticalGridProduction_Settings.ShowButtonMode = DevExpress.XtraVerticalGrid.ShowButtonModeEnum.ShowAlways
            Me.VerticalGridProduction_Settings.Size = New System.Drawing.Size(671, 448)
            Me.VerticalGridProduction_Settings.TabIndex = 0
            Me.VerticalGridProduction_Settings.TreeButtonStyle = DevExpress.XtraVerticalGrid.TreeButtonStyle.TreeView
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting)
            '
            'category65
            '
            Me.category65.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowUseLocationPrintOptions, Me.rowLocationCode, Me.rowCustomInvoiceID, Me.rowApplyExchangeRate, Me.rowExchangeRateAmount, Me.rowHideExchangeRateMessage})
            Me.category65.Name = "category65"
            Me.category65.Properties.Caption = "Output Options"
            '
            'rowUseLocationPrintOptions
            '
            Me.rowUseLocationPrintOptions.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            Me.rowUseLocationPrintOptions.AppearanceCell.Options.UseFont = True
            Me.rowUseLocationPrintOptions.Height = 17
            Me.rowUseLocationPrintOptions.Name = "rowUseLocationPrintOptions"
            Me.rowUseLocationPrintOptions.OptionsRow.AllowMove = False
            Me.rowUseLocationPrintOptions.OptionsRow.AllowMoveToCustomizationForm = False
            Me.rowUseLocationPrintOptions.Properties.Caption = "Use Location Print Options"
            Me.rowUseLocationPrintOptions.Properties.FieldName = "UseLocationPrintOptions"
            '
            'rowLocationCode
            '
            Me.rowLocationCode.Height = 16
            Me.rowLocationCode.Name = "rowLocationCode"
            Me.rowLocationCode.Properties.Caption = "Location"
            Me.rowLocationCode.Properties.FieldName = "LocationCode"
            '
            'rowCustomInvoiceID
            '
            Me.rowCustomInvoiceID.Name = "rowCustomInvoiceID"
            Me.rowCustomInvoiceID.Properties.Caption = "Custom Invoice"
            Me.rowCustomInvoiceID.Properties.FieldName = "CustomInvoiceID"
            '
            'rowApplyExchangeRate
            '
            Me.rowApplyExchangeRate.Name = "rowApplyExchangeRate"
            Me.rowApplyExchangeRate.Properties.Caption = "Apply Exchange Rate"
            Me.rowApplyExchangeRate.Properties.FieldName = "ApplyExchangeRate"
            '
            'rowExchangeRateAmount
            '
            Me.rowExchangeRateAmount.Name = "rowExchangeRateAmount"
            Me.rowExchangeRateAmount.Properties.Caption = "Exchange Rate Amount"
            Me.rowExchangeRateAmount.Properties.FieldName = "ExchangeRateAmount"
            Me.rowExchangeRateAmount.Properties.Format.FormatString = "{0:n4}"
            '
            'rowHideExchangeRateMessage
            '
            Me.rowHideExchangeRateMessage.Name = "rowHideExchangeRateMessage"
            Me.rowHideExchangeRateMessage.Properties.Caption = "Hide Exchange Rate Message"
            Me.rowHideExchangeRateMessage.Properties.FieldName = "HideExchangeRateMessage"
            '
            'category
            '
            Me.category.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowUseInvoiceCategoryDescription, Me.rowInvoiceTitle, Me.rowIncludeInvoiceDueDate})
            Me.category.Name = "category"
            Me.category.Properties.Caption = "Header Options"
            '
            'rowUseInvoiceCategoryDescription
            '
            Me.rowUseInvoiceCategoryDescription.Name = "rowUseInvoiceCategoryDescription"
            Me.rowUseInvoiceCategoryDescription.Properties.Caption = "Use Invoice Category Description"
            Me.rowUseInvoiceCategoryDescription.Properties.FieldName = "UseInvoiceCategoryDescription"
            '
            'rowInvoiceTitle
            '
            Me.rowInvoiceTitle.Height = 17
            Me.rowInvoiceTitle.Name = "rowInvoiceTitle"
            Me.rowInvoiceTitle.Properties.Caption = "Invoice Title"
            Me.rowInvoiceTitle.Properties.FieldName = "InvoiceTitle"
            '
            'rowIncludeInvoiceDueDate
            '
            Me.rowIncludeInvoiceDueDate.Name = "rowIncludeInvoiceDueDate"
            Me.rowIncludeInvoiceDueDate.Properties.Caption = "Invoice Due Date"
            Me.rowIncludeInvoiceDueDate.Properties.FieldName = "IncludeInvoiceDueDate"
            '
            'category2
            '
            Me.category2.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.category3, Me.category4, Me.category5})
            Me.category2.Name = "category2"
            Me.category2.Properties.Caption = "Header"
            '
            'category3
            '
            Me.category3.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowAddressBlockType, Me.rowPrintClientName, Me.rowPrintDivisionName, Me.rowPrintProductDescription, Me.rowPrintContactAfterAddress, Me.rowContactType, Me.rowShowCodes})
            Me.category3.Name = "category3"
            Me.category3.Properties.Caption = "Address Block"
            '
            'rowAddressBlockType
            '
            Me.rowAddressBlockType.Name = "rowAddressBlockType"
            Me.rowAddressBlockType.Properties.Caption = "Address Block Type"
            Me.rowAddressBlockType.Properties.FieldName = "AddressBlockType"
            '
            'rowPrintClientName
            '
            Me.rowPrintClientName.Name = "rowPrintClientName"
            Me.rowPrintClientName.Properties.Caption = "Print Client Name"
            Me.rowPrintClientName.Properties.FieldName = "PrintClientName"
            '
            'rowPrintDivisionName
            '
            Me.rowPrintDivisionName.Name = "rowPrintDivisionName"
            Me.rowPrintDivisionName.Properties.Caption = "Print Division Name"
            Me.rowPrintDivisionName.Properties.FieldName = "PrintDivisionName"
            '
            'rowPrintProductDescription
            '
            Me.rowPrintProductDescription.Name = "rowPrintProductDescription"
            Me.rowPrintProductDescription.Properties.Caption = "Print Product Description"
            Me.rowPrintProductDescription.Properties.FieldName = "PrintProductDescription"
            '
            'rowPrintContactAfterAddress
            '
            Me.rowPrintContactAfterAddress.Name = "rowPrintContactAfterAddress"
            Me.rowPrintContactAfterAddress.Properties.Caption = "Print Contact After Address"
            Me.rowPrintContactAfterAddress.Properties.FieldName = "PrintContactAfterAddress"
            '
            'rowContactType
            '
            Me.rowContactType.Name = "rowContactType"
            Me.rowContactType.Properties.Caption = "Contact Type"
            Me.rowContactType.Properties.FieldName = "ContactType"
            '
            'rowShowCodes
            '
            Me.rowShowCodes.Name = "rowShowCodes"
            Me.rowShowCodes.Properties.Caption = "Show Codes"
            Me.rowShowCodes.Properties.FieldName = "ShowCodes"
            '
            'category4
            '
            Me.category4.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowIncludeClientReference, Me.rowClientRefLocation, Me.rowIncludeClientPO, Me.rowClientPOLocation, Me.rowIncludeAccountExecutive, Me.rowIncludeSalesClass, Me.rowSalesClassLocation, Me.rowShowCampaign, Me.rowCampaignLocation})
            Me.category4.Name = "category4"
            Me.category4.Properties.Caption = "Include Fields"
            '
            'rowIncludeClientReference
            '
            Me.rowIncludeClientReference.Name = "rowIncludeClientReference"
            Me.rowIncludeClientReference.Properties.Caption = "Client Reference"
            Me.rowIncludeClientReference.Properties.FieldName = "IncludeClientReference"
            '
            'rowClientRefLocation
            '
            Me.rowClientRefLocation.Name = "rowClientRefLocation"
            Me.rowClientRefLocation.Properties.Caption = "Client Reference Location"
            Me.rowClientRefLocation.Properties.FieldName = "ClientRefLocation"
            '
            'rowIncludeClientPO
            '
            Me.rowIncludeClientPO.Name = "rowIncludeClientPO"
            Me.rowIncludeClientPO.Properties.Caption = "Client PO"
            Me.rowIncludeClientPO.Properties.FieldName = "IncludeClientPO"
            '
            'rowClientPOLocation
            '
            Me.rowClientPOLocation.Name = "rowClientPOLocation"
            Me.rowClientPOLocation.Properties.Caption = "Client PO Location"
            Me.rowClientPOLocation.Properties.FieldName = "ClientPOLocation"
            '
            'rowIncludeAccountExecutive
            '
            Me.rowIncludeAccountExecutive.Name = "rowIncludeAccountExecutive"
            Me.rowIncludeAccountExecutive.Properties.Caption = "Account Executive"
            Me.rowIncludeAccountExecutive.Properties.FieldName = "IncludeAccountExecutive"
            '
            'rowIncludeSalesClass
            '
            Me.rowIncludeSalesClass.Name = "rowIncludeSalesClass"
            Me.rowIncludeSalesClass.Properties.Caption = "Sales Class"
            Me.rowIncludeSalesClass.Properties.FieldName = "IncludeSalesClass"
            '
            'rowSalesClassLocation
            '
            Me.rowSalesClassLocation.Name = "rowSalesClassLocation"
            Me.rowSalesClassLocation.Properties.Caption = "Sales Class Location"
            Me.rowSalesClassLocation.Properties.FieldName = "SalesClassLocation"
            '
            'rowShowCampaign
            '
            Me.rowShowCampaign.Name = "rowShowCampaign"
            Me.rowShowCampaign.Properties.Caption = "Campaign"
            Me.rowShowCampaign.Properties.FieldName = "ShowCampaign"
            '
            'rowCampaignLocation
            '
            Me.rowCampaignLocation.Name = "rowCampaignLocation"
            Me.rowCampaignLocation.Properties.Caption = "Campaign Location"
            Me.rowCampaignLocation.Properties.FieldName = "CampaignLocation"
            '
            'category5
            '
            Me.category5.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowIncludeInvoiceComment, Me.rowIncludeBillingApprovalComment, Me.rowIncludeBillingApprovalFunctionComment, Me.rowIncludeJobComment, Me.rowIncludeJobComponentComment, Me.rowIncludeEstimateComment, Me.rowIncludeEstimateComponentComment, Me.rowIncludeEstimateQuoteComment, Me.rowIncludeEstimateRevisionComment, Me.rowIncludeEstimateFunctionComment, Me.rowShowCampaignComment})
            Me.category5.Name = "category5"
            Me.category5.Properties.Caption = "Comments"
            '
            'rowIncludeInvoiceComment
            '
            Me.rowIncludeInvoiceComment.Name = "rowIncludeInvoiceComment"
            Me.rowIncludeInvoiceComment.Properties.Caption = "Invoice Comment"
            Me.rowIncludeInvoiceComment.Properties.FieldName = "IncludeBillingComment"
            '
            'rowIncludeBillingApprovalComment
            '
            Me.rowIncludeBillingApprovalComment.Name = "rowIncludeBillingApprovalComment"
            Me.rowIncludeBillingApprovalComment.Properties.Caption = "Billing Approval Comment"
            Me.rowIncludeBillingApprovalComment.Properties.FieldName = "IncludeBillingApprovalClientComment"
            '
            'rowIncludeBillingApprovalFunctionComment
            '
            Me.rowIncludeBillingApprovalFunctionComment.Name = "rowIncludeBillingApprovalFunctionComment"
            Me.rowIncludeBillingApprovalFunctionComment.Properties.Caption = "Billing Approval Function Comment"
            Me.rowIncludeBillingApprovalFunctionComment.Properties.FieldName = "BackupReportCommentOptionBillingApprovalClientFunction"
            '
            'rowIncludeJobComment
            '
            Me.rowIncludeJobComment.Name = "rowIncludeJobComment"
            Me.rowIncludeJobComment.Properties.Caption = "Job Comment"
            Me.rowIncludeJobComment.Properties.FieldName = "IncludeJobComment"
            '
            'rowIncludeJobComponentComment
            '
            Me.rowIncludeJobComponentComment.Name = "rowIncludeJobComponentComment"
            Me.rowIncludeJobComponentComment.OptionsRow.AllowMove = False
            Me.rowIncludeJobComponentComment.OptionsRow.AllowMoveToCustomizationForm = False
            Me.rowIncludeJobComponentComment.Properties.Caption = "Job Component Comment"
            Me.rowIncludeJobComponentComment.Properties.FieldName = "IncludeJobComponentComment"
            '
            'rowIncludeEstimateComment
            '
            Me.rowIncludeEstimateComment.Name = "rowIncludeEstimateComment"
            Me.rowIncludeEstimateComment.Properties.Caption = "Estimate Comment"
            Me.rowIncludeEstimateComment.Properties.FieldName = "IncludeEstimateComment"
            '
            'rowIncludeEstimateComponentComment
            '
            Me.rowIncludeEstimateComponentComment.Name = "rowIncludeEstimateComponentComment"
            Me.rowIncludeEstimateComponentComment.Properties.Caption = "Estimate Component Comment"
            Me.rowIncludeEstimateComponentComment.Properties.FieldName = "IncludeEstimateComponentComment"
            '
            'rowIncludeEstimateQuoteComment
            '
            Me.rowIncludeEstimateQuoteComment.Name = "rowIncludeEstimateQuoteComment"
            Me.rowIncludeEstimateQuoteComment.Properties.Caption = "Estimate Quote Comment"
            Me.rowIncludeEstimateQuoteComment.Properties.FieldName = "IncludeEstimateQuoteComment"
            '
            'rowIncludeEstimateRevisionComment
            '
            Me.rowIncludeEstimateRevisionComment.Name = "rowIncludeEstimateRevisionComment"
            Me.rowIncludeEstimateRevisionComment.Properties.Caption = "Estimate Revision Comment"
            Me.rowIncludeEstimateRevisionComment.Properties.FieldName = "IncludeEstimateRevisionComment"
            '
            'rowIncludeEstimateFunctionComment
            '
            Me.rowIncludeEstimateFunctionComment.Name = "rowIncludeEstimateFunctionComment"
            Me.rowIncludeEstimateFunctionComment.Properties.Caption = "Estimate Function Comment"
            Me.rowIncludeEstimateFunctionComment.Properties.FieldName = "IncludeEstimateFunctionComment"
            '
            'rowShowCampaignComment
            '
            Me.rowShowCampaignComment.Name = "rowShowCampaignComment"
            Me.rowShowCampaignComment.Properties.Caption = "Campaign Comment"
            Me.rowShowCampaignComment.Properties.FieldName = "ShowCampaignComment"
            '
            'category1
            '
            Me.category1.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowHeaderGroupBy, Me.rowHideJobInfo, Me.rowHideComponentNumberAndDescription})
            Me.category1.Name = "category1"
            Me.category1.Properties.Caption = "Job Options"
            '
            'rowHeaderGroupBy
            '
            Me.rowHeaderGroupBy.Name = "rowHeaderGroupBy"
            Me.rowHeaderGroupBy.Properties.Caption = "Group Jobs By"
            Me.rowHeaderGroupBy.Properties.FieldName = "HeaderGroupBy"
            '
            'rowHideJobInfo
            '
            Me.rowHideJobInfo.Name = "rowHideJobInfo"
            Me.rowHideJobInfo.Properties.Caption = "Hide Job Number And Description"
            Me.rowHideJobInfo.Properties.FieldName = "HideJobInfo"
            '
            'rowHideComponentNumberAndDescription
            '
            Me.rowHideComponentNumberAndDescription.Name = "rowHideComponentNumberAndDescription"
            Me.rowHideComponentNumberAndDescription.OptionsRow.AllowMove = False
            Me.rowHideComponentNumberAndDescription.OptionsRow.AllowMoveToCustomizationForm = False
            Me.rowHideComponentNumberAndDescription.Properties.Caption = "Hide Component Number And Description"
            Me.rowHideComponentNumberAndDescription.Properties.FieldName = "HideComponentNumberAndDescription"
            '
            'category6
            '
            Me.category6.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.category7, Me.category8, Me.category9, Me.category66})
            Me.category6.Name = "category6"
            Me.category6.Properties.Caption = "Detail, Sorting & Grouping"
            '
            'category7
            '
            Me.category7.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowReportFormatType, Me.rowSummaryLevel})
            Me.category7.Name = "category7"
            Me.category7.Properties.Caption = "Report Format Options"
            '
            'rowReportFormatType
            '
            Me.rowReportFormatType.Name = "rowReportFormatType"
            Me.rowReportFormatType.Properties.Caption = "Format Type"
            Me.rowReportFormatType.Properties.FieldName = "ReportFormatType"
            '
            'rowSummaryLevel
            '
            Me.rowSummaryLevel.Name = "rowSummaryLevel"
            Me.rowSummaryLevel.Properties.Caption = "Summary Level"
            Me.rowSummaryLevel.Properties.FieldName = "SummaryLevel"
            '
            'category8
            '
            Me.category8.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowGroupingOptionType, Me.rowGroupingOptionInsideDescription, Me.rowGroupingOptionOutsideDescription})
            Me.category8.Name = "category8"
            Me.category8.Properties.Caption = "Grouping Options"
            '
            'rowGroupingOptionType
            '
            Me.rowGroupingOptionType.Name = "rowGroupingOptionType"
            Me.rowGroupingOptionType.Properties.Caption = "Option"
            Me.rowGroupingOptionType.Properties.FieldName = "GroupingOptionType"
            '
            'rowGroupingOptionInsideDescription
            '
            Me.rowGroupingOptionInsideDescription.Name = "rowGroupingOptionInsideDescription"
            Me.rowGroupingOptionInsideDescription.Properties.Caption = "Inside Description"
            Me.rowGroupingOptionInsideDescription.Properties.FieldName = "GroupingOptionInsideDescription"
            '
            'rowGroupingOptionOutsideDescription
            '
            Me.rowGroupingOptionOutsideDescription.Name = "rowGroupingOptionOutsideDescription"
            Me.rowGroupingOptionOutsideDescription.Properties.Caption = "Outside Description"
            Me.rowGroupingOptionOutsideDescription.Properties.FieldName = "GroupingOptionOutsideDescription"
            '
            'category9
            '
            Me.category9.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowSortFunctionByType, Me.rowPrintFunctionType, Me.rowShowFunctionDetail, Me.rowShowZeroFunctionAmounts, Me.rowIndicateTaxableFunctions, Me.rowHideFunctionTotals, Me.rowShowEmployeeHours, Me.rowShowQuantity})
            Me.category9.Name = "category9"
            Me.category9.Properties.Caption = "Function Options"
            '
            'rowSortFunctionByType
            '
            Me.rowSortFunctionByType.Name = "rowSortFunctionByType"
            Me.rowSortFunctionByType.Properties.Caption = "Sort By"
            Me.rowSortFunctionByType.Properties.FieldName = "SortFunctionByType"
            '
            'rowPrintFunctionType
            '
            Me.rowPrintFunctionType.Name = "rowPrintFunctionType"
            Me.rowPrintFunctionType.Properties.Caption = "Print Option"
            Me.rowPrintFunctionType.Properties.FieldName = "PrintFunctionType"
            '
            'rowShowFunctionDetail
            '
            Me.rowShowFunctionDetail.Name = "rowShowFunctionDetail"
            Me.rowShowFunctionDetail.Properties.Caption = "Show Function Detail"
            Me.rowShowFunctionDetail.Properties.FieldName = "ShowFunctionDetail"
            Me.rowShowFunctionDetail.Visible = False
            '
            'rowShowZeroFunctionAmounts
            '
            Me.rowShowZeroFunctionAmounts.Name = "rowShowZeroFunctionAmounts"
            Me.rowShowZeroFunctionAmounts.Properties.Caption = "Show Zero Function Amounts"
            Me.rowShowZeroFunctionAmounts.Properties.FieldName = "ShowZeroFunctionAmounts"
            '
            'rowIndicateTaxableFunctions
            '
            Me.rowIndicateTaxableFunctions.Name = "rowIndicateTaxableFunctions"
            Me.rowIndicateTaxableFunctions.Properties.Caption = "Indicate Taxable Functions"
            Me.rowIndicateTaxableFunctions.Properties.FieldName = "IndicateTaxableFunctions"
            '
            'rowHideFunctionTotals
            '
            Me.rowHideFunctionTotals.Name = "rowHideFunctionTotals"
            Me.rowHideFunctionTotals.Properties.Caption = "Hide Function Totals"
            Me.rowHideFunctionTotals.Properties.FieldName = "HideFunctionTotals"
            '
            'rowShowEmployeeHours
            '
            Me.rowShowEmployeeHours.Name = "rowShowEmployeeHours"
            Me.rowShowEmployeeHours.Properties.Caption = "Show Employee Hours"
            Me.rowShowEmployeeHours.Properties.FieldName = "ShowEmployeeHours"
            '
            'rowShowQuantity
            '
            Me.rowShowQuantity.Name = "rowShowQuantity"
            Me.rowShowQuantity.Properties.Caption = "Show Quantity"
            Me.rowShowQuantity.Properties.FieldName = "ShowQuantity"
            '
            'category66
            '
            Me.category66.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.row0, Me.row1, Me.row2, Me.rowEmployeeTimeFunctionComment, Me.row3, Me.row4, Me.row5, Me.rowIncomeOnlyFunctionComment, Me.row6, Me.row7, Me.row8, Me.rowAccountsPayableFunctionComment})
            Me.category66.Name = "category66"
            Me.category66.Properties.Caption = "Item Detail Options "
            '
            'row0
            '
            Me.row0.Name = "row0"
            Me.row0.Properties.Caption = "Show Employee Time Description"
            Me.row0.Properties.FieldName = "ShowEmployeeTimeDescription"
            '
            'row1
            '
            Me.row1.Name = "row1"
            Me.row1.Properties.Caption = "Show Employee Time Date"
            Me.row1.Properties.FieldName = "ShowEmployeeTimeDate"
            '
            'row2
            '
            Me.row2.Name = "row2"
            Me.row2.Properties.Caption = "Show Employee Time Rate"
            Me.row2.Properties.FieldName = "ShowEmployeeTimeRate"
            '
            'rowEmployeeTimeFunctionComment
            '
            Me.rowEmployeeTimeFunctionComment.Name = "rowEmployeeTimeFunctionComment"
            Me.rowEmployeeTimeFunctionComment.Properties.Caption = "Show Employee Time Comment"
            Me.rowEmployeeTimeFunctionComment.Properties.FieldName = "ShowEmployeeTimeComment"
            '
            'row3
            '
            Me.row3.Name = "row3"
            Me.row3.Properties.Caption = "Show Income Only Description"
            Me.row3.Properties.FieldName = "ShowIncomeOnlyDescription"
            '
            'row4
            '
            Me.row4.Name = "row4"
            Me.row4.Properties.Caption = "Show Income Only Date"
            Me.row4.Properties.FieldName = "ShowIncomeOnlyDate"
            '
            'row5
            '
            Me.row5.Name = "row5"
            Me.row5.Properties.Caption = "Show Income Only Rate"
            Me.row5.Properties.FieldName = "ShowIncomeOnlyRate"
            '
            'rowIncomeOnlyFunctionComment
            '
            Me.rowIncomeOnlyFunctionComment.Name = "rowIncomeOnlyFunctionComment"
            Me.rowIncomeOnlyFunctionComment.Properties.Caption = "Show Income Only Comment"
            Me.rowIncomeOnlyFunctionComment.Properties.FieldName = "ShowIncomeOnlyComment"
            '
            'row6
            '
            Me.row6.Name = "row6"
            Me.row6.Properties.Caption = "Show AP Description"
            Me.row6.Properties.FieldName = "ShowAPDescription"
            '
            'row7
            '
            Me.row7.Name = "row7"
            Me.row7.Properties.Caption = "Show AP Date"
            Me.row7.Properties.FieldName = "ShowAPDate"
            '
            'row8
            '
            Me.row8.Name = "row8"
            Me.row8.Properties.Caption = "Show AP Rate"
            Me.row8.Properties.FieldName = "ShowAPRate"
            '
            'rowAccountsPayableFunctionComment
            '
            Me.rowAccountsPayableFunctionComment.Name = "rowAccountsPayableFunctionComment"
            Me.rowAccountsPayableFunctionComment.Properties.Caption = "Show AP Comment"
            Me.rowAccountsPayableFunctionComment.Properties.FieldName = "ShowAPComment"
            '
            'category10
            '
            Me.category10.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.category11, Me.category12})
            Me.category10.Name = "category10"
            Me.category10.Properties.Caption = "Totals and Footer"
            '
            'category11
            '
            Me.category11.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowTotalsShowTaxSeparately, Me.rowTaxTotalLocation, Me.rowTotalsShowCommissionSeparately, Me.rowTotalsShowBillingHistory})
            Me.category11.Name = "category11"
            Me.category11.Properties.Caption = "Total Options"
            '
            'rowTotalsShowTaxSeparately
            '
            Me.rowTotalsShowTaxSeparately.Name = "rowTotalsShowTaxSeparately"
            Me.rowTotalsShowTaxSeparately.Properties.Caption = "Show Tax Separately"
            Me.rowTotalsShowTaxSeparately.Properties.FieldName = "TotalsShowTaxSeparately"
            '
            'rowTaxTotalLocation
            '
            Me.rowTaxTotalLocation.Name = "rowTaxTotalLocation"
            Me.rowTaxTotalLocation.Properties.Caption = "Tax Total Location"
            Me.rowTaxTotalLocation.Properties.FieldName = "TaxTotalLocation"
            '
            'rowTotalsShowCommissionSeparately
            '
            Me.rowTotalsShowCommissionSeparately.Name = "rowTotalsShowCommissionSeparately"
            Me.rowTotalsShowCommissionSeparately.Properties.Caption = "Show Commission Separately"
            Me.rowTotalsShowCommissionSeparately.Properties.FieldName = "TotalsShowCommissionSeparately"
            '
            'rowTotalsShowBillingHistory
            '
            Me.rowTotalsShowBillingHistory.Name = "rowTotalsShowBillingHistory"
            Me.rowTotalsShowBillingHistory.Properties.Caption = "Show Billing History"
            Me.rowTotalsShowBillingHistory.Properties.FieldName = "TotalsShowBillingHistory"
            '
            'category12
            '
            Me.category12.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowInvoiceFooterCommentType, Me.rowInvoiceFooterComment})
            Me.category12.Name = "category12"
            Me.category12.Properties.Caption = "Invoice Footer Comments"
            '
            'rowInvoiceFooterCommentType
            '
            Me.rowInvoiceFooterCommentType.Name = "rowInvoiceFooterCommentType"
            Me.rowInvoiceFooterCommentType.Properties.Caption = "Type"
            Me.rowInvoiceFooterCommentType.Properties.FieldName = "InvoiceFooterCommentType"
            '
            'rowInvoiceFooterComment
            '
            Me.rowInvoiceFooterComment.Name = "rowInvoiceFooterComment"
            Me.rowInvoiceFooterComment.Properties.Caption = "Comment"
            Me.rowInvoiceFooterComment.Properties.FieldName = "InvoiceFooterComment"
            '
            'categoryBackupReportOptions
            '
            Me.categoryBackupReportOptions.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowIncludeBackupReport, Me.rowBackupReportColumnOption, Me.rowBackupReportCommentOptionEmployeeTimeFunction, Me.rowBackupReportCommentOptionAccountsPayableFunction, Me.rowBackupReportCommentOptionIncomeOnlyFunction, Me.rowBackupReportBreakupByJobComponent})
            Me.categoryBackupReportOptions.Name = "categoryBackupReportOptions"
            Me.categoryBackupReportOptions.Properties.Caption = "Backup Options"
            '
            'rowIncludeBackupReport
            '
            Me.rowIncludeBackupReport.Name = "rowIncludeBackupReport"
            Me.rowIncludeBackupReport.Properties.Caption = "Include Backup Report"
            Me.rowIncludeBackupReport.Properties.FieldName = "IncludeBackupReport"
            '
            'rowBackupReportColumnOption
            '
            Me.rowBackupReportColumnOption.Name = "rowBackupReportColumnOption"
            Me.rowBackupReportColumnOption.Properties.Caption = "Backup Report Column Option"
            Me.rowBackupReportColumnOption.Properties.FieldName = "BackupReportColumnOption"
            '
            'rowBackupReportCommentOptionEmployeeTimeFunction
            '
            Me.rowBackupReportCommentOptionEmployeeTimeFunction.Name = "rowBackupReportCommentOptionEmployeeTimeFunction"
            Me.rowBackupReportCommentOptionEmployeeTimeFunction.Properties.Caption = "Employee Time Comment"
            Me.rowBackupReportCommentOptionEmployeeTimeFunction.Properties.FieldName = "BackupReportCommentOptionEmployeeTimeFunction"
            '
            'rowBackupReportCommentOptionAccountsPayableFunction
            '
            Me.rowBackupReportCommentOptionAccountsPayableFunction.Name = "rowBackupReportCommentOptionAccountsPayableFunction"
            Me.rowBackupReportCommentOptionAccountsPayableFunction.Properties.Caption = "Accounts Payable Comment"
            Me.rowBackupReportCommentOptionAccountsPayableFunction.Properties.FieldName = "BackupReportCommentOptionAccountsPayableFunction"
            '
            'rowBackupReportCommentOptionIncomeOnlyFunction
            '
            Me.rowBackupReportCommentOptionIncomeOnlyFunction.Name = "rowBackupReportCommentOptionIncomeOnlyFunction"
            Me.rowBackupReportCommentOptionIncomeOnlyFunction.Properties.Caption = "Income Only Comment"
            Me.rowBackupReportCommentOptionIncomeOnlyFunction.Properties.FieldName = "BackupReportCommentOptionIncomeOnlyFunction"
            '
            'rowBackupReportBreakupByJobComponent
            '
            Me.rowBackupReportBreakupByJobComponent.Name = "rowBackupReportBreakupByJobComponent"
            Me.rowBackupReportBreakupByJobComponent.Properties.Caption = "Breakup By Job/Comp"
            Me.rowBackupReportBreakupByJobComponent.Properties.FieldName = "BreakupByJobComponent"
            '
            'RibbonBarOptions_SaveOptions
            '
            Me.RibbonBarOptions_SaveOptions.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_SaveOptions.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_SaveOptions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_SaveOptions.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_SaveOptions.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_SaveOptions.DragDropSupport = True
            Me.RibbonBarOptions_SaveOptions.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_SaveOptions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemSaveOptions_Agency, Me.ButtonItemSaveOptions_Clients, Me.ButtonItemSaveOptions_OneTime, Me.ButtonItemSaveOptions_Products})
            Me.RibbonBarOptions_SaveOptions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_SaveOptions.Location = New System.Drawing.Point(246, 0)
            Me.RibbonBarOptions_SaveOptions.MinimumSize = New System.Drawing.Size(100, 0)
            Me.RibbonBarOptions_SaveOptions.Name = "RibbonBarOptions_SaveOptions"
            Me.RibbonBarOptions_SaveOptions.SecurityEnabled = True
            Me.RibbonBarOptions_SaveOptions.Size = New System.Drawing.Size(250, 92)
            Me.RibbonBarOptions_SaveOptions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_SaveOptions.TabIndex = 14
            Me.RibbonBarOptions_SaveOptions.Text = "Save Options"
            '
            '
            '
            Me.RibbonBarOptions_SaveOptions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_SaveOptions.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_SaveOptions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemSaveOptions_Agency
            '
            Me.ButtonItemSaveOptions_Agency.AutoCheckOnClick = True
            Me.ButtonItemSaveOptions_Agency.BeginGroup = True
            Me.ButtonItemSaveOptions_Agency.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemSaveOptions_Agency.Name = "ButtonItemSaveOptions_Agency"
            Me.ButtonItemSaveOptions_Agency.RibbonWordWrap = False
            Me.ButtonItemSaveOptions_Agency.SubItemsExpandWidth = 14
            Me.ButtonItemSaveOptions_Agency.Text = "Agency"
            '
            'ButtonItemSaveOptions_Clients
            '
            Me.ButtonItemSaveOptions_Clients.AutoCheckOnClick = True
            Me.ButtonItemSaveOptions_Clients.BeginGroup = True
            Me.ButtonItemSaveOptions_Clients.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemSaveOptions_Clients.Name = "ButtonItemSaveOptions_Clients"
            Me.ButtonItemSaveOptions_Clients.RibbonWordWrap = False
            Me.ButtonItemSaveOptions_Clients.SubItemsExpandWidth = 14
            Me.ButtonItemSaveOptions_Clients.Text = "Clients"
            '
            'ButtonItemSaveOptions_OneTime
            '
            Me.ButtonItemSaveOptions_OneTime.AutoCheckOnClick = True
            Me.ButtonItemSaveOptions_OneTime.BeginGroup = True
            Me.ButtonItemSaveOptions_OneTime.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemSaveOptions_OneTime.Name = "ButtonItemSaveOptions_OneTime"
            Me.ButtonItemSaveOptions_OneTime.RibbonWordWrap = False
            Me.ButtonItemSaveOptions_OneTime.SubItemsExpandWidth = 14
            Me.ButtonItemSaveOptions_OneTime.Text = "One Time"
            '
            'ButtonItemSaveOptions_Products
            '
            Me.ButtonItemSaveOptions_Products.AutoCheckOnClick = True
            Me.ButtonItemSaveOptions_Products.BeginGroup = True
            Me.ButtonItemSaveOptions_Products.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemSaveOptions_Products.Name = "ButtonItemSaveOptions_Products"
            Me.ButtonItemSaveOptions_Products.RibbonWordWrap = False
            Me.ButtonItemSaveOptions_Products.SubItemsExpandWidth = 14
            Me.ButtonItemSaveOptions_Products.Text = "Products"
            '
            'TabControlForm_Options
            '
            Me.TabControlForm_Options.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlForm_Options.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
            Me.TabControlForm_Options.CanReorderTabs = True
            Me.TabControlForm_Options.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlForm_Options.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlForm_Options.Controls.Add(Me.TabControlPanelComboTab_Combo)
            Me.TabControlForm_Options.Controls.Add(Me.TabControlPanelTVTab_TV)
            Me.TabControlForm_Options.Controls.Add(Me.TabControlPanelRadioTab_Radio)
            Me.TabControlForm_Options.Controls.Add(Me.TabControlPanelInternetTab_Internet)
            Me.TabControlForm_Options.Controls.Add(Me.TabControlPanelMediaTab_Media)
            Me.TabControlForm_Options.Controls.Add(Me.TabControlPanelProductionTab_Production)
            Me.TabControlForm_Options.Controls.Add(Me.TabControlPanelOutdoorTab_Outdoor)
            Me.TabControlForm_Options.Controls.Add(Me.TabControlPanelNewspaperTab_Newspaper)
            Me.TabControlForm_Options.Controls.Add(Me.TabControlPanelMagazineTab_Magazine)
            Me.TabControlForm_Options.ForeColor = System.Drawing.Color.Black
            Me.TabControlForm_Options.Location = New System.Drawing.Point(12, 33)
            Me.TabControlForm_Options.Name = "TabControlForm_Options"
            Me.TabControlForm_Options.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlForm_Options.SelectedTabIndex = 1
            Me.TabControlForm_Options.Size = New System.Drawing.Size(679, 483)
            Me.TabControlForm_Options.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlForm_Options.TabIndex = 2
            Me.TabControlForm_Options.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlForm_Options.Tabs.Add(Me.TabItemOptions_ComboTab)
            Me.TabControlForm_Options.Tabs.Add(Me.TabItemOptions_ProductionTab)
            Me.TabControlForm_Options.Tabs.Add(Me.TabItemOptions_MediaTab)
            Me.TabControlForm_Options.Tabs.Add(Me.TabItemOptions_MagazineTab)
            Me.TabControlForm_Options.Tabs.Add(Me.TabItemOptions_NewspaperTab)
            Me.TabControlForm_Options.Tabs.Add(Me.TabItemOptions_InternetTab)
            Me.TabControlForm_Options.Tabs.Add(Me.TabItemOptions_OutdoorTab)
            Me.TabControlForm_Options.Tabs.Add(Me.TabItemOptions_RadioTab)
            Me.TabControlForm_Options.Tabs.Add(Me.TabItemOptions_TVTab)
            '
            'TabControlPanelInternetTab_Internet
            '
            Me.TabControlPanelInternetTab_Internet.Controls.Add(Me.VerticalGridInternet_Settings)
            Me.TabControlPanelInternetTab_Internet.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelInternetTab_Internet.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelInternetTab_Internet.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelInternetTab_Internet.Name = "TabControlPanelInternetTab_Internet"
            Me.TabControlPanelInternetTab_Internet.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelInternetTab_Internet.Size = New System.Drawing.Size(679, 456)
            Me.TabControlPanelInternetTab_Internet.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelInternetTab_Internet.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelInternetTab_Internet.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelInternetTab_Internet.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelInternetTab_Internet.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelInternetTab_Internet.Style.GradientAngle = 90
            Me.TabControlPanelInternetTab_Internet.TabIndex = 5
            Me.TabControlPanelInternetTab_Internet.TabItem = Me.TabItemOptions_InternetTab
            '
            'VerticalGridInternet_Settings
            '
            Me.VerticalGridInternet_Settings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.VerticalGridInternet_Settings.Appearance.RowHeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            Me.VerticalGridInternet_Settings.Appearance.RowHeaderPanel.Options.UseFont = True
            Me.VerticalGridInternet_Settings.Cursor = System.Windows.Forms.Cursors.Default
            Me.VerticalGridInternet_Settings.CustomizationFormBounds = New System.Drawing.Rectangle(1384, 433, 216, 265)
            Me.VerticalGridInternet_Settings.DataSource = Me.MediaInvoiceInternetSettingBindingSource
            Me.VerticalGridInternet_Settings.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView
            Me.VerticalGridInternet_Settings.Location = New System.Drawing.Point(4, 4)
            Me.VerticalGridInternet_Settings.Name = "VerticalGridInternet_Settings"
            Me.VerticalGridInternet_Settings.OptionsBehavior.RecordsMouseWheel = True
            Me.VerticalGridInternet_Settings.OptionsBehavior.ResizeRowHeaders = False
            Me.VerticalGridInternet_Settings.OptionsBehavior.UseEnterAsTab = True
            Me.VerticalGridInternet_Settings.Rows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowInternetCustomInvoiceID, Me.category33, Me.category71, Me.category36, Me.category39})
            Me.VerticalGridInternet_Settings.ShowButtonMode = DevExpress.XtraVerticalGrid.ShowButtonModeEnum.ShowAlways
            Me.VerticalGridInternet_Settings.Size = New System.Drawing.Size(671, 448)
            Me.VerticalGridInternet_Settings.TabIndex = 2
            Me.VerticalGridInternet_Settings.TreeButtonStyle = DevExpress.XtraVerticalGrid.TreeButtonStyle.TreeView
            '
            'MediaInvoiceInternetSettingBindingSource
            '
            Me.MediaInvoiceInternetSettingBindingSource.DataSource = GetType(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceInternetSetting)
            '
            'rowInternetCustomInvoiceID
            '
            Me.rowInternetCustomInvoiceID.Name = "rowInternetCustomInvoiceID"
            Me.rowInternetCustomInvoiceID.Properties.Caption = "Custom Invoice"
            Me.rowInternetCustomInvoiceID.Properties.FieldName = "InternetCustomInvoiceID"
            '
            'category33
            '
            Me.category33.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.category34, Me.category35, Me.category32})
            Me.category33.Name = "category33"
            Me.category33.Properties.Caption = "Header Options"
            '
            'category34
            '
            Me.category34.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowInternetUseInvoiceCategoryDescription, Me.rowInternetInvoiceTitle, Me.rowInternetPrintInvoiceDueDate})
            Me.category34.Height = 17
            Me.category34.Name = "category34"
            Me.category34.Properties.Caption = "Title Options"
            '
            'rowInternetUseInvoiceCategoryDescription
            '
            Me.rowInternetUseInvoiceCategoryDescription.Name = "rowInternetUseInvoiceCategoryDescription"
            Me.rowInternetUseInvoiceCategoryDescription.Properties.Caption = "Use Invoice Category Description"
            Me.rowInternetUseInvoiceCategoryDescription.Properties.FieldName = "InternetUseInvoiceCategoryDescription"
            '
            'rowInternetInvoiceTitle
            '
            Me.rowInternetInvoiceTitle.Name = "rowInternetInvoiceTitle"
            Me.rowInternetInvoiceTitle.Properties.Caption = "Invoice Title"
            Me.rowInternetInvoiceTitle.Properties.FieldName = "InternetInvoiceTitle"
            '
            'rowInternetPrintInvoiceDueDate
            '
            Me.rowInternetPrintInvoiceDueDate.Name = "rowInternetPrintInvoiceDueDate"
            Me.rowInternetPrintInvoiceDueDate.Properties.Caption = "Invoice Due Date"
            Me.rowInternetPrintInvoiceDueDate.Properties.FieldName = "InternetPrintInvoiceDueDate"
            '
            'category35
            '
            Me.category35.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowInternetShowClientPO, Me.rowInternetClientPOLocation, Me.rowInternetShowSalesClass, Me.rowInternetSalesClassLocation, Me.rowInternetShowCampaign, Me.rowInternetCampaignLocation, Me.rowInternetShowClientReference})
            Me.category35.Name = "category35"
            Me.category35.Properties.Caption = "Include Fields"
            '
            'rowInternetShowClientPO
            '
            Me.rowInternetShowClientPO.Name = "rowInternetShowClientPO"
            Me.rowInternetShowClientPO.Properties.Caption = "Show Client PO"
            Me.rowInternetShowClientPO.Properties.FieldName = "InternetShowClientPO"
            '
            'rowInternetClientPOLocation
            '
            Me.rowInternetClientPOLocation.Name = "rowInternetClientPOLocation"
            Me.rowInternetClientPOLocation.Properties.Caption = "Client PO Location"
            Me.rowInternetClientPOLocation.Properties.FieldName = "InternetClientPOLocation"
            '
            'rowInternetShowSalesClass
            '
            Me.rowInternetShowSalesClass.Name = "rowInternetShowSalesClass"
            Me.rowInternetShowSalesClass.Properties.Caption = "Show Sales Class"
            Me.rowInternetShowSalesClass.Properties.FieldName = "InternetShowSalesClass"
            '
            'rowInternetSalesClassLocation
            '
            Me.rowInternetSalesClassLocation.Name = "rowInternetSalesClassLocation"
            Me.rowInternetSalesClassLocation.Properties.Caption = "Sales Class Location"
            Me.rowInternetSalesClassLocation.Properties.FieldName = "InternetSalesClassLocation"
            '
            'rowInternetShowCampaign
            '
            Me.rowInternetShowCampaign.Name = "rowInternetShowCampaign"
            Me.rowInternetShowCampaign.Properties.Caption = "Show Campaign"
            Me.rowInternetShowCampaign.Properties.FieldName = "InternetShowCampaign"
            '
            'rowInternetCampaignLocation
            '
            Me.rowInternetCampaignLocation.Name = "rowInternetCampaignLocation"
            Me.rowInternetCampaignLocation.Properties.Caption = "Campaign Location"
            Me.rowInternetCampaignLocation.Properties.FieldName = "InternetCampaignLocation"
            '
            'rowInternetShowClientReference
            '
            Me.rowInternetShowClientReference.Name = "rowInternetShowClientReference"
            Me.rowInternetShowClientReference.Properties.Caption = "Show Client Reference"
            Me.rowInternetShowClientReference.Properties.FieldName = "InternetShowClientReference"
            Me.rowInternetShowClientReference.Visible = False
            '
            'category32
            '
            Me.category32.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowInternetShowOrderComment, Me.rowInternetShowOrderHouseComment, Me.rowInternetShowCampaignComment})
            Me.category32.Name = "category32"
            Me.category32.Properties.Caption = "Comments"
            '
            'rowInternetShowOrderComment
            '
            Me.rowInternetShowOrderComment.Name = "rowInternetShowOrderComment"
            Me.rowInternetShowOrderComment.Properties.Caption = "Show Order Comment"
            Me.rowInternetShowOrderComment.Properties.FieldName = "InternetShowOrderComment"
            '
            'rowInternetShowOrderHouseComment
            '
            Me.rowInternetShowOrderHouseComment.Name = "rowInternetShowOrderHouseComment"
            Me.rowInternetShowOrderHouseComment.Properties.Caption = "Show Order House Comment"
            Me.rowInternetShowOrderHouseComment.Properties.FieldName = "InternetShowOrderHouseComment"
            '
            'rowInternetShowCampaignComment
            '
            Me.rowInternetShowCampaignComment.Name = "rowInternetShowCampaignComment"
            Me.rowInternetShowCampaignComment.Properties.Caption = "Show Campaign Comment"
            Me.rowInternetShowCampaignComment.Properties.FieldName = "InternetShowCampaignComment"
            '
            'category71
            '
            Me.category71.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowInternetHeaderGroupBy, Me.rowInternetShowOrderDescription, Me.rowInternetShowOrderSubtotals})
            Me.category71.Name = "category71"
            Me.category71.Properties.Caption = "Order Options"
            '
            'rowInternetHeaderGroupBy
            '
            Me.rowInternetHeaderGroupBy.Name = "rowInternetHeaderGroupBy"
            Me.rowInternetHeaderGroupBy.Properties.Caption = "Group Orders By"
            Me.rowInternetHeaderGroupBy.Properties.FieldName = "InternetHeaderGroupBy"
            '
            'rowInternetShowOrderDescription
            '
            Me.rowInternetShowOrderDescription.Name = "rowInternetShowOrderDescription"
            Me.rowInternetShowOrderDescription.Properties.Caption = "Show Order Description"
            Me.rowInternetShowOrderDescription.Properties.FieldName = "InternetShowOrderDescription"
            '
            'rowInternetShowOrderSubtotals
            '
            Me.rowInternetShowOrderSubtotals.Name = "rowInternetShowOrderSubtotals"
            Me.rowInternetShowOrderSubtotals.Properties.Caption = "Show Order Subtotals"
            Me.rowInternetShowOrderSubtotals.Properties.FieldName = "InternetShowOrderSubtotals"
            '
            'category36
            '
            Me.category36.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowInternetShowLineDetail, Me.category37, Me.category38})
            Me.category36.Name = "category36"
            Me.category36.Properties.Caption = "Detail, Sorting & Grouping"
            '
            'rowInternetShowLineDetail
            '
            Me.rowInternetShowLineDetail.Name = "rowInternetShowLineDetail"
            Me.rowInternetShowLineDetail.Properties.Caption = "Grouping Option"
            Me.rowInternetShowLineDetail.Properties.FieldName = "InternetShowLineDetail"
            '
            'category37
            '
            Me.category37.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowInternetOrderNumberColumn, Me.rowInternetVendorNameColumn, Me.rowInternetShowVendorCode, Me.rowInternetOrderMonthsColumn, Me.rowInternetNetAmountColumn, Me.rowInternetCommissionAmountColumn, Me.rowInternetTaxAmountColumn, Me.rowInternetBillAmountColumn, Me.rowInternetPriorBillAmountColumn, Me.rowInternetBilledToDateAmountColumn})
            Me.category37.Name = "category37"
            Me.category37.Properties.Caption = "Order Column Options"
            '
            'rowInternetOrderNumberColumn
            '
            Me.rowInternetOrderNumberColumn.Name = "rowInternetOrderNumberColumn"
            Me.rowInternetOrderNumberColumn.Properties.Caption = "Order Number"
            Me.rowInternetOrderNumberColumn.Properties.FieldName = "InternetOrderNumberColumn"
            '
            'rowInternetVendorNameColumn
            '
            Me.rowInternetVendorNameColumn.Name = "rowInternetVendorNameColumn"
            Me.rowInternetVendorNameColumn.Properties.Caption = "Vendor Name"
            Me.rowInternetVendorNameColumn.Properties.FieldName = "InternetVendorNameColumn"
            '
            'rowInternetShowVendorCode
            '
            Me.rowInternetShowVendorCode.Name = "rowInternetShowVendorCode"
            Me.rowInternetShowVendorCode.Properties.Caption = "Vendor Code"
            Me.rowInternetShowVendorCode.Properties.FieldName = "InternetShowVendorCode"
            '
            'rowInternetOrderMonthsColumn
            '
            Me.rowInternetOrderMonthsColumn.Name = "rowInternetOrderMonthsColumn"
            Me.rowInternetOrderMonthsColumn.Properties.Caption = "Order Months"
            Me.rowInternetOrderMonthsColumn.Properties.FieldName = "InternetOrderMonthsColumn"
            '
            'rowInternetNetAmountColumn
            '
            Me.rowInternetNetAmountColumn.Name = "rowInternetNetAmountColumn"
            Me.rowInternetNetAmountColumn.Properties.Caption = "Net Amount"
            Me.rowInternetNetAmountColumn.Properties.FieldName = "InternetNetAmountColumn"
            '
            'rowInternetCommissionAmountColumn
            '
            Me.rowInternetCommissionAmountColumn.Name = "rowInternetCommissionAmountColumn"
            Me.rowInternetCommissionAmountColumn.Properties.Caption = "Commission Amount"
            Me.rowInternetCommissionAmountColumn.Properties.FieldName = "InternetCommissionAmountColumn"
            '
            'rowInternetTaxAmountColumn
            '
            Me.rowInternetTaxAmountColumn.Name = "rowInternetTaxAmountColumn"
            Me.rowInternetTaxAmountColumn.Properties.Caption = "Tax Amount"
            Me.rowInternetTaxAmountColumn.Properties.FieldName = "InternetTaxAmountColumn"
            '
            'rowInternetBillAmountColumn
            '
            Me.rowInternetBillAmountColumn.Name = "rowInternetBillAmountColumn"
            Me.rowInternetBillAmountColumn.Properties.Caption = "Bill Amount"
            Me.rowInternetBillAmountColumn.Properties.FieldName = "InternetBillAmountColumn"
            '
            'rowInternetPriorBillAmountColumn
            '
            Me.rowInternetPriorBillAmountColumn.Name = "rowInternetPriorBillAmountColumn"
            Me.rowInternetPriorBillAmountColumn.Properties.Caption = "Prior Bill Amount"
            Me.rowInternetPriorBillAmountColumn.Properties.FieldName = "InternetPriorBillAmountColumn"
            '
            'rowInternetBilledToDateAmountColumn
            '
            Me.rowInternetBilledToDateAmountColumn.Name = "rowInternetBilledToDateAmountColumn"
            Me.rowInternetBilledToDateAmountColumn.Properties.Caption = "Billed To Date Amount"
            Me.rowInternetBilledToDateAmountColumn.Properties.FieldName = "InternetBilledToDateAmountColumn"
            '
            'category38
            '
            Me.category38.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowInternetShowZeroLineAmounts, Me.rowInternetSortLinesBy, Me.rowInternetLineNumberColumn, Me.rowInternetHeadlineColumn, Me.rowInternetStartDatesColumn, Me.rowInternetEndDatesColumn, Me.rowInternetCreativeSizeColumn, Me.rowInternetAdNumberColumn, Me.rowInternetURLColumn, Me.rowInternetInternetTypeColumn, Me.rowInternetCloseDateColumn, Me.rowInternetJobComponentNumberColumn, Me.rowInternetJobDescriptionColumn, Me.rowInternetComponentDescriptionColumn, Me.rowInternetExtraChargesColumn, Me.rowInternetGuaranteedImpressionsColumn})
            Me.category38.Name = "category38"
            Me.category38.Properties.Caption = "Order/Line Options"
            '
            'rowInternetShowZeroLineAmounts
            '
            Me.rowInternetShowZeroLineAmounts.Name = "rowInternetShowZeroLineAmounts"
            Me.rowInternetShowZeroLineAmounts.Properties.Caption = "Show Zero Line Amounts"
            Me.rowInternetShowZeroLineAmounts.Properties.FieldName = "InternetShowZeroLineAmounts"
            '
            'rowInternetSortLinesBy
            '
            Me.rowInternetSortLinesBy.Name = "rowInternetSortLinesBy"
            Me.rowInternetSortLinesBy.Properties.Caption = "Sort Lines By"
            Me.rowInternetSortLinesBy.Properties.FieldName = "InternetSortLinesBy"
            '
            'rowInternetLineNumberColumn
            '
            Me.rowInternetLineNumberColumn.Name = "rowInternetLineNumberColumn"
            Me.rowInternetLineNumberColumn.Properties.Caption = "Line Number"
            Me.rowInternetLineNumberColumn.Properties.FieldName = "InternetLineNumberColumn"
            '
            'rowInternetHeadlineColumn
            '
            Me.rowInternetHeadlineColumn.Name = "rowInternetHeadlineColumn"
            Me.rowInternetHeadlineColumn.Properties.Caption = "Headline"
            Me.rowInternetHeadlineColumn.Properties.FieldName = "InternetHeadlineColumn"
            '
            'rowInternetStartDatesColumn
            '
            Me.rowInternetStartDatesColumn.Name = "rowInternetStartDatesColumn"
            Me.rowInternetStartDatesColumn.Properties.Caption = "Start Dates"
            Me.rowInternetStartDatesColumn.Properties.FieldName = "InternetStartDatesColumn"
            '
            'rowInternetEndDatesColumn
            '
            Me.rowInternetEndDatesColumn.Name = "rowInternetEndDatesColumn"
            Me.rowInternetEndDatesColumn.Properties.Caption = "End Dates"
            Me.rowInternetEndDatesColumn.Properties.FieldName = "InternetEndDatesColumn"
            '
            'rowInternetCreativeSizeColumn
            '
            Me.rowInternetCreativeSizeColumn.Name = "rowInternetCreativeSizeColumn"
            Me.rowInternetCreativeSizeColumn.Properties.Caption = "Creative Size"
            Me.rowInternetCreativeSizeColumn.Properties.FieldName = "InternetCreativeSizeColumn"
            '
            'rowInternetAdNumberColumn
            '
            Me.rowInternetAdNumberColumn.Name = "rowInternetAdNumberColumn"
            Me.rowInternetAdNumberColumn.Properties.Caption = "Ad Number"
            Me.rowInternetAdNumberColumn.Properties.FieldName = "InternetAdNumberColumn"
            '
            'rowInternetURLColumn
            '
            Me.rowInternetURLColumn.Name = "rowInternetURLColumn"
            Me.rowInternetURLColumn.Properties.Caption = "URL"
            Me.rowInternetURLColumn.Properties.FieldName = "InternetURLColumn"
            '
            'rowInternetInternetTypeColumn
            '
            Me.rowInternetInternetTypeColumn.Name = "rowInternetInternetTypeColumn"
            Me.rowInternetInternetTypeColumn.Properties.Caption = "Type"
            Me.rowInternetInternetTypeColumn.Properties.FieldName = "InternetInternetTypeColumn"
            '
            'rowInternetCloseDateColumn
            '
            Me.rowInternetCloseDateColumn.Name = "rowInternetCloseDateColumn"
            Me.rowInternetCloseDateColumn.Properties.Caption = "Close Date"
            Me.rowInternetCloseDateColumn.Properties.FieldName = "InternetCloseDateColumn"
            '
            'rowInternetJobComponentNumberColumn
            '
            Me.rowInternetJobComponentNumberColumn.Name = "rowInternetJobComponentNumberColumn"
            Me.rowInternetJobComponentNumberColumn.Properties.Caption = "Job Component Number"
            Me.rowInternetJobComponentNumberColumn.Properties.FieldName = "InternetJobComponentNumberColumn"
            '
            'rowInternetJobDescriptionColumn
            '
            Me.rowInternetJobDescriptionColumn.Name = "rowInternetJobDescriptionColumn"
            Me.rowInternetJobDescriptionColumn.Properties.Caption = "Job Description"
            Me.rowInternetJobDescriptionColumn.Properties.FieldName = "InternetJobDescriptionColumn"
            '
            'rowInternetComponentDescriptionColumn
            '
            Me.rowInternetComponentDescriptionColumn.Name = "rowInternetComponentDescriptionColumn"
            Me.rowInternetComponentDescriptionColumn.Properties.Caption = "Component Description"
            Me.rowInternetComponentDescriptionColumn.Properties.FieldName = "InternetComponentDescriptionColumn"
            '
            'rowInternetExtraChargesColumn
            '
            Me.rowInternetExtraChargesColumn.Name = "rowInternetExtraChargesColumn"
            Me.rowInternetExtraChargesColumn.Properties.Caption = "Extra Charges"
            Me.rowInternetExtraChargesColumn.Properties.FieldName = "InternetExtraChargesColumn"
            '
            'rowInternetGuaranteedImpressionsColumn
            '
            Me.rowInternetGuaranteedImpressionsColumn.Name = "rowInternetGuaranteedImpressionsColumn"
            Me.rowInternetGuaranteedImpressionsColumn.Properties.Caption = "Guaranteed Impressions"
            Me.rowInternetGuaranteedImpressionsColumn.Properties.FieldName = "InternetGuaranteedImpressionsColumn"
            '
            'category39
            '
            Me.category39.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowInternetShowCommissionSeparately, Me.rowInternetShowRebateSeparately, Me.rowInternetShowTaxSeparately, Me.rowInternetShowBillingHistory})
            Me.category39.Name = "category39"
            Me.category39.Properties.Caption = "Footer Options"
            '
            'rowInternetShowCommissionSeparately
            '
            Me.rowInternetShowCommissionSeparately.Name = "rowInternetShowCommissionSeparately"
            Me.rowInternetShowCommissionSeparately.Properties.Caption = "Show Commission Separately"
            Me.rowInternetShowCommissionSeparately.Properties.FieldName = "InternetShowCommissionSeparately"
            '
            'rowInternetShowRebateSeparately
            '
            Me.rowInternetShowRebateSeparately.Name = "rowInternetShowRebateSeparately"
            Me.rowInternetShowRebateSeparately.Properties.Caption = "Show Rebate Separately"
            Me.rowInternetShowRebateSeparately.Properties.FieldName = "InternetShowRebateSeparately"
            '
            'rowInternetShowTaxSeparately
            '
            Me.rowInternetShowTaxSeparately.Name = "rowInternetShowTaxSeparately"
            Me.rowInternetShowTaxSeparately.Properties.Caption = "Show Tax Separately"
            Me.rowInternetShowTaxSeparately.Properties.FieldName = "InternetShowTaxSeparately"
            '
            'rowInternetShowBillingHistory
            '
            Me.rowInternetShowBillingHistory.Name = "rowInternetShowBillingHistory"
            Me.rowInternetShowBillingHistory.Properties.Caption = "Show Billing History"
            Me.rowInternetShowBillingHistory.Properties.FieldName = "InternetShowBillingHistory"
            '
            'TabItemOptions_InternetTab
            '
            Me.TabItemOptions_InternetTab.AttachedControl = Me.TabControlPanelInternetTab_Internet
            Me.TabItemOptions_InternetTab.Name = "TabItemOptions_InternetTab"
            Me.TabItemOptions_InternetTab.Text = "Internet"
            '
            'TabControlPanelComboTab_Combo
            '
            Me.TabControlPanelComboTab_Combo.Controls.Add(Me.VerticalGridCombo_Settings)
            Me.TabControlPanelComboTab_Combo.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelComboTab_Combo.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelComboTab_Combo.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelComboTab_Combo.Name = "TabControlPanelComboTab_Combo"
            Me.TabControlPanelComboTab_Combo.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelComboTab_Combo.Size = New System.Drawing.Size(679, 456)
            Me.TabControlPanelComboTab_Combo.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelComboTab_Combo.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelComboTab_Combo.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelComboTab_Combo.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelComboTab_Combo.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelComboTab_Combo.Style.GradientAngle = 90
            Me.TabControlPanelComboTab_Combo.TabIndex = 9
            Me.TabControlPanelComboTab_Combo.TabItem = Me.TabItemOptions_ComboTab
            '
            'VerticalGridCombo_Settings
            '
            Me.VerticalGridCombo_Settings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.VerticalGridCombo_Settings.Appearance.RowHeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            Me.VerticalGridCombo_Settings.Appearance.RowHeaderPanel.Options.UseFont = True
            Me.VerticalGridCombo_Settings.Cursor = System.Windows.Forms.Cursors.Default
            Me.VerticalGridCombo_Settings.CustomizationFormBounds = New System.Drawing.Rectangle(1384, 433, 216, 265)
            Me.VerticalGridCombo_Settings.DataSource = Me.ComboInvoiceSettingBindingSource
            Me.VerticalGridCombo_Settings.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView
            Me.VerticalGridCombo_Settings.Location = New System.Drawing.Point(4, 4)
            Me.VerticalGridCombo_Settings.Name = "VerticalGridCombo_Settings"
            Me.VerticalGridCombo_Settings.OptionsBehavior.RecordsMouseWheel = True
            Me.VerticalGridCombo_Settings.OptionsBehavior.ResizeRowHeaders = False
            Me.VerticalGridCombo_Settings.OptionsBehavior.UseEnterAsTab = True
            Me.VerticalGridCombo_Settings.Rows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.CategoryRow1, Me.CategoryRow2, Me.CategoryRow3, Me.category24})
            Me.VerticalGridCombo_Settings.ShowButtonMode = DevExpress.XtraVerticalGrid.ShowButtonModeEnum.ShowAlways
            Me.VerticalGridCombo_Settings.Size = New System.Drawing.Size(671, 448)
            Me.VerticalGridCombo_Settings.TabIndex = 1
            Me.VerticalGridCombo_Settings.TreeButtonStyle = DevExpress.XtraVerticalGrid.TreeButtonStyle.TreeView
            '
            'ComboInvoiceSettingBindingSource
            '
            Me.ComboInvoiceSettingBindingSource.DataSource = GetType(AdvantageFramework.InvoicePrinting.Classes.ComboInvoiceSetting)
            '
            'CategoryRow1
            '
            Me.CategoryRow1.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowComboLocationCode, Me.rowComboApplyExchangeRate, Me.rowComboExchangeRateAmount})
            Me.CategoryRow1.Name = "CategoryRow1"
            Me.CategoryRow1.Properties.Caption = "Output Options"
            '
            'rowComboLocationCode
            '
            Me.rowComboLocationCode.Height = 16
            Me.rowComboLocationCode.Name = "rowComboLocationCode"
            Me.rowComboLocationCode.Properties.Caption = "Location"
            Me.rowComboLocationCode.Properties.FieldName = "LocationCode"
            '
            'rowComboApplyExchangeRate
            '
            Me.rowComboApplyExchangeRate.Name = "rowComboApplyExchangeRate"
            Me.rowComboApplyExchangeRate.Properties.Caption = "Apply Exchange Rate"
            Me.rowComboApplyExchangeRate.Properties.FieldName = "ApplyExchangeRate"
            '
            'rowComboExchangeRateAmount
            '
            Me.rowComboExchangeRateAmount.Name = "rowComboExchangeRateAmount"
            Me.rowComboExchangeRateAmount.Properties.Caption = "Exchange Rate Amount"
            Me.rowComboExchangeRateAmount.Properties.FieldName = "ExchangeRateAmount"
            Me.rowComboExchangeRateAmount.Properties.Format.FormatString = "{0:n4}"
            '
            'CategoryRow2
            '
            Me.CategoryRow2.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowComboUseInvoiceCategoryDescription, Me.rowComboInvoiceTitle, Me.rowComboIncludeInvoiceDueDate})
            Me.CategoryRow2.Name = "CategoryRow2"
            Me.CategoryRow2.Properties.Caption = "Header Options"
            '
            'rowComboUseInvoiceCategoryDescription
            '
            Me.rowComboUseInvoiceCategoryDescription.Name = "rowComboUseInvoiceCategoryDescription"
            Me.rowComboUseInvoiceCategoryDescription.Properties.Caption = "Use Invoice Category Description"
            Me.rowComboUseInvoiceCategoryDescription.Properties.FieldName = "UseInvoiceCategoryDescription"
            '
            'rowComboInvoiceTitle
            '
            Me.rowComboInvoiceTitle.Height = 17
            Me.rowComboInvoiceTitle.Name = "rowComboInvoiceTitle"
            Me.rowComboInvoiceTitle.Properties.Caption = "Invoice Title"
            Me.rowComboInvoiceTitle.Properties.FieldName = "InvoiceTitle"
            '
            'rowComboIncludeInvoiceDueDate
            '
            Me.rowComboIncludeInvoiceDueDate.Name = "rowComboIncludeInvoiceDueDate"
            Me.rowComboIncludeInvoiceDueDate.Properties.Caption = "Invoice Due Date"
            Me.rowComboIncludeInvoiceDueDate.Properties.FieldName = "IncludeInvoiceDueDate"
            '
            'CategoryRow3
            '
            Me.CategoryRow3.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.CategoryRow4})
            Me.CategoryRow3.Name = "CategoryRow3"
            Me.CategoryRow3.Properties.Caption = "Header"
            '
            'CategoryRow4
            '
            Me.CategoryRow4.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowComboAddressBlockType, Me.rowComboPrintClientName, Me.rowComboPrintDivisionName, Me.rowComboPrintProductDescription, Me.rowComboPrintContactAfterAddress, Me.rowComboContactType, Me.rowComboShowCodes})
            Me.CategoryRow4.Name = "CategoryRow4"
            Me.CategoryRow4.Properties.Caption = "Address Block"
            '
            'rowComboAddressBlockType
            '
            Me.rowComboAddressBlockType.Name = "rowComboAddressBlockType"
            Me.rowComboAddressBlockType.Properties.Caption = "Address Block Type"
            Me.rowComboAddressBlockType.Properties.FieldName = "AddressBlockType"
            '
            'rowComboPrintClientName
            '
            Me.rowComboPrintClientName.Name = "rowComboPrintClientName"
            Me.rowComboPrintClientName.Properties.Caption = "Print Client Name"
            Me.rowComboPrintClientName.Properties.FieldName = "PrintClientName"
            '
            'rowComboPrintDivisionName
            '
            Me.rowComboPrintDivisionName.Name = "rowComboPrintDivisionName"
            Me.rowComboPrintDivisionName.Properties.Caption = "Print Division Name"
            Me.rowComboPrintDivisionName.Properties.FieldName = "PrintDivisionName"
            '
            'rowComboPrintProductDescription
            '
            Me.rowComboPrintProductDescription.Name = "rowComboPrintProductDescription"
            Me.rowComboPrintProductDescription.Properties.Caption = "Print Product Description"
            Me.rowComboPrintProductDescription.Properties.FieldName = "PrintProductDescription"
            '
            'rowComboPrintContactAfterAddress
            '
            Me.rowComboPrintContactAfterAddress.Name = "rowComboPrintContactAfterAddress"
            Me.rowComboPrintContactAfterAddress.Properties.Caption = "Print Contact After Address"
            Me.rowComboPrintContactAfterAddress.Properties.FieldName = "PrintContactAfterAddress"
            '
            'rowComboContactType
            '
            Me.rowComboContactType.Name = "rowComboContactType"
            Me.rowComboContactType.Properties.Caption = "Contact Type"
            Me.rowComboContactType.Properties.FieldName = "ContactType"
            '
            'rowComboShowCodes
            '
            Me.rowComboShowCodes.Name = "rowComboShowCodes"
            Me.rowComboShowCodes.Properties.Caption = "Show Codes"
            Me.rowComboShowCodes.Properties.FieldName = "ShowCodes"
            '
            'category24
            '
            Me.category24.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowComboInvoiceFooterCommentType, Me.rowComboInvoiceFooterComment})
            Me.category24.Name = "category24"
            Me.category24.Properties.Caption = "Footer Options"
            '
            'rowComboInvoiceFooterCommentType
            '
            Me.rowComboInvoiceFooterCommentType.Name = "rowComboInvoiceFooterCommentType"
            Me.rowComboInvoiceFooterCommentType.Properties.Caption = "Type"
            Me.rowComboInvoiceFooterCommentType.Properties.FieldName = "InvoiceFooterCommentType"
            '
            'rowComboInvoiceFooterComment
            '
            Me.rowComboInvoiceFooterComment.Name = "rowComboInvoiceFooterComment"
            Me.rowComboInvoiceFooterComment.Properties.Caption = "Comment"
            Me.rowComboInvoiceFooterComment.Properties.FieldName = "InvoiceFooterComment"
            '
            'TabItemOptions_ComboTab
            '
            Me.TabItemOptions_ComboTab.AttachedControl = Me.TabControlPanelComboTab_Combo
            Me.TabItemOptions_ComboTab.Name = "TabItemOptions_ComboTab"
            Me.TabItemOptions_ComboTab.Text = "Combo"
            Me.TabItemOptions_ComboTab.Visible = False
            '
            'TabControlPanelMediaTab_Media
            '
            Me.TabControlPanelMediaTab_Media.Controls.Add(Me.VerticalGridMedia_Settings)
            Me.TabControlPanelMediaTab_Media.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelMediaTab_Media.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelMediaTab_Media.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelMediaTab_Media.Name = "TabControlPanelMediaTab_Media"
            Me.TabControlPanelMediaTab_Media.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelMediaTab_Media.Size = New System.Drawing.Size(679, 456)
            Me.TabControlPanelMediaTab_Media.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelMediaTab_Media.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelMediaTab_Media.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelMediaTab_Media.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelMediaTab_Media.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelMediaTab_Media.Style.GradientAngle = 90
            Me.TabControlPanelMediaTab_Media.TabIndex = 2
            Me.TabControlPanelMediaTab_Media.TabItem = Me.TabItemOptions_MediaTab
            '
            'VerticalGridMedia_Settings
            '
            Me.VerticalGridMedia_Settings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.VerticalGridMedia_Settings.Appearance.RowHeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            Me.VerticalGridMedia_Settings.Appearance.RowHeaderPanel.Options.UseFont = True
            Me.VerticalGridMedia_Settings.Cursor = System.Windows.Forms.Cursors.Default
            Me.VerticalGridMedia_Settings.CustomizationFormBounds = New System.Drawing.Rectangle(1384, 433, 216, 265)
            Me.VerticalGridMedia_Settings.DataSource = Me.MediaInvoiceSettingBindingSource
            Me.VerticalGridMedia_Settings.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView
            Me.VerticalGridMedia_Settings.Location = New System.Drawing.Point(4, 4)
            Me.VerticalGridMedia_Settings.Name = "VerticalGridMedia_Settings"
            Me.VerticalGridMedia_Settings.OptionsBehavior.RecordsMouseWheel = True
            Me.VerticalGridMedia_Settings.OptionsBehavior.ResizeRowHeaders = False
            Me.VerticalGridMedia_Settings.OptionsBehavior.UseEnterAsTab = True
            Me.VerticalGridMedia_Settings.Rows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowUseLocationPrintOptions1, Me.rowLocationCode1, Me.rowApplyExchangeRate1, Me.rowExchangeRateAmount1, Me.rowHideExchangeRateMessage1, Me.category13, Me.category16})
            Me.VerticalGridMedia_Settings.ShowButtonMode = DevExpress.XtraVerticalGrid.ShowButtonModeEnum.ShowAlways
            Me.VerticalGridMedia_Settings.Size = New System.Drawing.Size(671, 448)
            Me.VerticalGridMedia_Settings.TabIndex = 1
            Me.VerticalGridMedia_Settings.TreeButtonStyle = DevExpress.XtraVerticalGrid.TreeButtonStyle.TreeView
            '
            'MediaInvoiceSettingBindingSource
            '
            Me.MediaInvoiceSettingBindingSource.DataSource = GetType(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceSetting)
            '
            'rowUseLocationPrintOptions1
            '
            Me.rowUseLocationPrintOptions1.Name = "rowUseLocationPrintOptions1"
            Me.rowUseLocationPrintOptions1.Properties.Caption = "Use Location Print Options"
            Me.rowUseLocationPrintOptions1.Properties.FieldName = "UseLocationPrintOptions"
            '
            'rowLocationCode1
            '
            Me.rowLocationCode1.Name = "rowLocationCode1"
            Me.rowLocationCode1.Properties.Caption = "Location"
            Me.rowLocationCode1.Properties.FieldName = "LocationCode"
            '
            'rowApplyExchangeRate1
            '
            Me.rowApplyExchangeRate1.Name = "rowApplyExchangeRate1"
            Me.rowApplyExchangeRate1.Properties.Caption = "Apply Exchange Rate"
            Me.rowApplyExchangeRate1.Properties.FieldName = "ApplyExchangeRate"
            '
            'rowExchangeRateAmount1
            '
            Me.rowExchangeRateAmount1.Name = "rowExchangeRateAmount1"
            Me.rowExchangeRateAmount1.Properties.Caption = "Exchange Rate Amount"
            Me.rowExchangeRateAmount1.Properties.FieldName = "ExchangeRateAmount"
            '
            'rowHideExchangeRateMessage1
            '
            Me.rowHideExchangeRateMessage1.Name = "rowHideExchangeRateMessage1"
            Me.rowHideExchangeRateMessage1.Properties.Caption = "Hide Exchange Rate Message"
            Me.rowHideExchangeRateMessage1.Properties.FieldName = "HideExchangeRateMessage"
            '
            'category13
            '
            Me.category13.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.category14, Me.category15})
            Me.category13.Height = 17
            Me.category13.Name = "category13"
            Me.category13.Properties.Caption = "Header Options"
            '
            'category14
            '
            Me.category14.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowAddressBlockType1, Me.rowPrintClientName1, Me.rowPrintDivisionName1, Me.rowPrintProductDescription1, Me.rowPrintContactAfterAddress1, Me.rowContactType1, Me.rowShowCodes1})
            Me.category14.Name = "category14"
            Me.category14.Properties.Caption = "Address Block"
            '
            'rowAddressBlockType1
            '
            Me.rowAddressBlockType1.Name = "rowAddressBlockType1"
            Me.rowAddressBlockType1.Properties.Caption = "Address Block Type"
            Me.rowAddressBlockType1.Properties.FieldName = "AddressBlockType"
            '
            'rowPrintClientName1
            '
            Me.rowPrintClientName1.Name = "rowPrintClientName1"
            Me.rowPrintClientName1.Properties.Caption = "Print Client Name"
            Me.rowPrintClientName1.Properties.FieldName = "PrintClientName"
            '
            'rowPrintDivisionName1
            '
            Me.rowPrintDivisionName1.Name = "rowPrintDivisionName1"
            Me.rowPrintDivisionName1.Properties.Caption = "Print Division Name"
            Me.rowPrintDivisionName1.Properties.FieldName = "PrintDivisionName"
            '
            'rowPrintProductDescription1
            '
            Me.rowPrintProductDescription1.Name = "rowPrintProductDescription1"
            Me.rowPrintProductDescription1.Properties.Caption = "Print Product Description"
            Me.rowPrintProductDescription1.Properties.FieldName = "PrintProductDescription"
            '
            'rowPrintContactAfterAddress1
            '
            Me.rowPrintContactAfterAddress1.Name = "rowPrintContactAfterAddress1"
            Me.rowPrintContactAfterAddress1.Properties.Caption = "Print Contact After Address"
            Me.rowPrintContactAfterAddress1.Properties.FieldName = "PrintContactAfterAddress"
            '
            'rowContactType1
            '
            Me.rowContactType1.Name = "rowContactType1"
            Me.rowContactType1.Properties.Caption = "Contact Type"
            Me.rowContactType1.Properties.FieldName = "ContactType"
            '
            'rowShowCodes1
            '
            Me.rowShowCodes1.Name = "rowShowCodes1"
            Me.rowShowCodes1.Properties.Caption = "Show Codes"
            Me.rowShowCodes1.Properties.FieldName = "ShowCodes"
            '
            'category15
            '
            Me.category15.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowIncludeBillingComment1})
            Me.category15.Name = "category15"
            Me.category15.Properties.Caption = "Comments"
            '
            'rowIncludeBillingComment1
            '
            Me.rowIncludeBillingComment1.Name = "rowIncludeBillingComment1"
            Me.rowIncludeBillingComment1.Properties.Caption = "Invoice Comment"
            Me.rowIncludeBillingComment1.Properties.FieldName = "IncludeBillingComment"
            '
            'category16
            '
            Me.category16.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowInvoiceFooterCommentType1, Me.rowInvoiceFooterComment1})
            Me.category16.Name = "category16"
            Me.category16.Properties.Caption = "Footer Options"
            '
            'rowInvoiceFooterCommentType1
            '
            Me.rowInvoiceFooterCommentType1.Name = "rowInvoiceFooterCommentType1"
            Me.rowInvoiceFooterCommentType1.Properties.Caption = "Type"
            Me.rowInvoiceFooterCommentType1.Properties.FieldName = "InvoiceFooterCommentType"
            '
            'rowInvoiceFooterComment1
            '
            Me.rowInvoiceFooterComment1.Name = "rowInvoiceFooterComment1"
            Me.rowInvoiceFooterComment1.Properties.Caption = "Comment"
            Me.rowInvoiceFooterComment1.Properties.FieldName = "InvoiceFooterComment"
            '
            'TabItemOptions_MediaTab
            '
            Me.TabItemOptions_MediaTab.AttachedControl = Me.TabControlPanelMediaTab_Media
            Me.TabItemOptions_MediaTab.Name = "TabItemOptions_MediaTab"
            Me.TabItemOptions_MediaTab.Text = "Media"
            '
            'TabControlPanelProductionTab_Production
            '
            Me.TabControlPanelProductionTab_Production.Controls.Add(Me.VerticalGridProduction_Settings)
            Me.TabControlPanelProductionTab_Production.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelProductionTab_Production.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelProductionTab_Production.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelProductionTab_Production.Name = "TabControlPanelProductionTab_Production"
            Me.TabControlPanelProductionTab_Production.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelProductionTab_Production.Size = New System.Drawing.Size(679, 456)
            Me.TabControlPanelProductionTab_Production.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelProductionTab_Production.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelProductionTab_Production.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelProductionTab_Production.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelProductionTab_Production.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelProductionTab_Production.Style.GradientAngle = 90
            Me.TabControlPanelProductionTab_Production.TabIndex = 1
            Me.TabControlPanelProductionTab_Production.TabItem = Me.TabItemOptions_ProductionTab
            '
            'TabItemOptions_ProductionTab
            '
            Me.TabItemOptions_ProductionTab.AttachedControl = Me.TabControlPanelProductionTab_Production
            Me.TabItemOptions_ProductionTab.Name = "TabItemOptions_ProductionTab"
            Me.TabItemOptions_ProductionTab.Text = "Production"
            '
            'TabControlPanelTVTab_TV
            '
            Me.TabControlPanelTVTab_TV.Controls.Add(Me.VerticalGridTV_Settings)
            Me.TabControlPanelTVTab_TV.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelTVTab_TV.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelTVTab_TV.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelTVTab_TV.Name = "TabControlPanelTVTab_TV"
            Me.TabControlPanelTVTab_TV.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelTVTab_TV.Size = New System.Drawing.Size(679, 456)
            Me.TabControlPanelTVTab_TV.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelTVTab_TV.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelTVTab_TV.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelTVTab_TV.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelTVTab_TV.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelTVTab_TV.Style.GradientAngle = 90
            Me.TabControlPanelTVTab_TV.TabIndex = 8
            Me.TabControlPanelTVTab_TV.TabItem = Me.TabItemOptions_TVTab
            '
            'VerticalGridTV_Settings
            '
            Me.VerticalGridTV_Settings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.VerticalGridTV_Settings.Appearance.RowHeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            Me.VerticalGridTV_Settings.Appearance.RowHeaderPanel.Options.UseFont = True
            Me.VerticalGridTV_Settings.Cursor = System.Windows.Forms.Cursors.Default
            Me.VerticalGridTV_Settings.CustomizationFormBounds = New System.Drawing.Rectangle(1384, 433, 216, 265)
            Me.VerticalGridTV_Settings.DataSource = Me.MediaInvoiceTVSettingBindingSource
            Me.VerticalGridTV_Settings.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView
            Me.VerticalGridTV_Settings.Location = New System.Drawing.Point(4, 4)
            Me.VerticalGridTV_Settings.Name = "VerticalGridTV_Settings"
            Me.VerticalGridTV_Settings.OptionsBehavior.RecordsMouseWheel = True
            Me.VerticalGridTV_Settings.OptionsBehavior.ResizeRowHeaders = False
            Me.VerticalGridTV_Settings.OptionsBehavior.UseEnterAsTab = True
            Me.VerticalGridTV_Settings.Rows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowTVCustomInvoiceID, Me.category57, Me.category73, Me.category60, Me.category63})
            Me.VerticalGridTV_Settings.ShowButtonMode = DevExpress.XtraVerticalGrid.ShowButtonModeEnum.ShowAlways
            Me.VerticalGridTV_Settings.Size = New System.Drawing.Size(671, 448)
            Me.VerticalGridTV_Settings.TabIndex = 2
            Me.VerticalGridTV_Settings.TreeButtonStyle = DevExpress.XtraVerticalGrid.TreeButtonStyle.TreeView
            '
            'MediaInvoiceTVSettingBindingSource
            '
            Me.MediaInvoiceTVSettingBindingSource.DataSource = GetType(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceTVSetting)
            '
            'rowTVCustomInvoiceID
            '
            Me.rowTVCustomInvoiceID.Name = "rowTVCustomInvoiceID"
            Me.rowTVCustomInvoiceID.Properties.Caption = "Custom Invoice"
            Me.rowTVCustomInvoiceID.Properties.FieldName = "TVCustomInvoiceID"
            '
            'category57
            '
            Me.category57.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.category58, Me.category59, Me.category74})
            Me.category57.Name = "category57"
            Me.category57.Properties.Caption = "Header Options"
            '
            'category58
            '
            Me.category58.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowTVUseInvoiceCategoryDescription, Me.rowTVInvoiceTitle, Me.rowTVPrintInvoiceDueDate})
            Me.category58.Name = "category58"
            Me.category58.Properties.Caption = "Title Options"
            '
            'rowTVUseInvoiceCategoryDescription
            '
            Me.rowTVUseInvoiceCategoryDescription.Name = "rowTVUseInvoiceCategoryDescription"
            Me.rowTVUseInvoiceCategoryDescription.Properties.Caption = "Use Invoice Category Description"
            Me.rowTVUseInvoiceCategoryDescription.Properties.FieldName = "TVUseInvoiceCategoryDescription"
            '
            'rowTVInvoiceTitle
            '
            Me.rowTVInvoiceTitle.Name = "rowTVInvoiceTitle"
            Me.rowTVInvoiceTitle.Properties.Caption = "Invoice Title"
            Me.rowTVInvoiceTitle.Properties.FieldName = "TVInvoiceTitle"
            '
            'rowTVPrintInvoiceDueDate
            '
            Me.rowTVPrintInvoiceDueDate.Name = "rowTVPrintInvoiceDueDate"
            Me.rowTVPrintInvoiceDueDate.Properties.Caption = "Invoice Due Date"
            Me.rowTVPrintInvoiceDueDate.Properties.FieldName = "TVPrintInvoiceDueDate"
            '
            'category59
            '
            Me.category59.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowTVShowClientPO, Me.rowTVClientPOLocation, Me.rowTVShowSalesClass, Me.rowTVSalesClassLocation, Me.rowTVShowCampaign, Me.rowTVCampaignLocation, Me.rowTVShowClientReference})
            Me.category59.Name = "category59"
            Me.category59.Properties.Caption = "Include Fields"
            '
            'rowTVShowClientPO
            '
            Me.rowTVShowClientPO.Name = "rowTVShowClientPO"
            Me.rowTVShowClientPO.Properties.Caption = "Show Client PO"
            Me.rowTVShowClientPO.Properties.FieldName = "TVShowClientPO"
            '
            'rowTVClientPOLocation
            '
            Me.rowTVClientPOLocation.Name = "rowTVClientPOLocation"
            Me.rowTVClientPOLocation.Properties.Caption = "Client PO Location"
            Me.rowTVClientPOLocation.Properties.FieldName = "TVClientPOLocation"
            '
            'rowTVShowSalesClass
            '
            Me.rowTVShowSalesClass.Name = "rowTVShowSalesClass"
            Me.rowTVShowSalesClass.Properties.Caption = "Show Sales Class"
            Me.rowTVShowSalesClass.Properties.FieldName = "TVShowSalesClass"
            '
            'rowTVSalesClassLocation
            '
            Me.rowTVSalesClassLocation.Name = "rowTVSalesClassLocation"
            Me.rowTVSalesClassLocation.Properties.Caption = "Sales Class Location"
            Me.rowTVSalesClassLocation.Properties.FieldName = "TVSalesClassLocation"
            '
            'rowTVShowCampaign
            '
            Me.rowTVShowCampaign.Name = "rowTVShowCampaign"
            Me.rowTVShowCampaign.Properties.Caption = "Show Campaign"
            Me.rowTVShowCampaign.Properties.FieldName = "TVShowCampaign"
            '
            'rowTVCampaignLocation
            '
            Me.rowTVCampaignLocation.Name = "rowTVCampaignLocation"
            Me.rowTVCampaignLocation.Properties.Caption = "Campaign Location"
            Me.rowTVCampaignLocation.Properties.FieldName = "TVCampaignLocation"
            '
            'rowTVShowClientReference
            '
            Me.rowTVShowClientReference.Name = "rowTVShowClientReference"
            Me.rowTVShowClientReference.Properties.Caption = "Show Client Reference"
            Me.rowTVShowClientReference.Properties.FieldName = "TVShowClientReference"
            Me.rowTVShowClientReference.Visible = False
            '
            'category74
            '
            Me.category74.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowTVShowOrderComment, Me.rowTVShowOrderHouseComment, Me.rowTVShowCampaignComment})
            Me.category74.Name = "category74"
            Me.category74.Properties.Caption = "Comments"
            '
            'rowTVShowOrderComment
            '
            Me.rowTVShowOrderComment.Name = "rowTVShowOrderComment"
            Me.rowTVShowOrderComment.Properties.Caption = "Show Order Comment"
            Me.rowTVShowOrderComment.Properties.FieldName = "TVShowOrderComment"
            '
            'rowTVShowOrderHouseComment
            '
            Me.rowTVShowOrderHouseComment.Name = "rowTVShowOrderHouseComment"
            Me.rowTVShowOrderHouseComment.Properties.Caption = "Show Order House Comment"
            Me.rowTVShowOrderHouseComment.Properties.FieldName = "TVShowOrderHouseComment"
            '
            'rowTVShowCampaignComment
            '
            Me.rowTVShowCampaignComment.Name = "rowTVShowCampaignComment"
            Me.rowTVShowCampaignComment.Properties.Caption = "Show Campaign Comment"
            Me.rowTVShowCampaignComment.Properties.FieldName = "TVShowCampaignComment"
            '
            'category73
            '
            Me.category73.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowTVHeaderGroupBy, Me.rowTVShowOrderDescription, Me.rowTVShowOrderSubtotals})
            Me.category73.Name = "category73"
            Me.category73.Properties.Caption = "Order Options"
            '
            'rowTVHeaderGroupBy
            '
            Me.rowTVHeaderGroupBy.Name = "rowTVHeaderGroupBy"
            Me.rowTVHeaderGroupBy.Properties.Caption = "Group Orders By"
            Me.rowTVHeaderGroupBy.Properties.FieldName = "TVHeaderGroupBy"
            '
            'rowTVShowOrderDescription
            '
            Me.rowTVShowOrderDescription.Name = "rowTVShowOrderDescription"
            Me.rowTVShowOrderDescription.Properties.Caption = "Show Order Description"
            Me.rowTVShowOrderDescription.Properties.FieldName = "TVShowOrderDescription"
            '
            'rowTVShowOrderSubtotals
            '
            Me.rowTVShowOrderSubtotals.Name = "rowTVShowOrderSubtotals"
            Me.rowTVShowOrderSubtotals.Properties.Caption = "Show Order Subtotals"
            Me.rowTVShowOrderSubtotals.Properties.FieldName = "TVShowOrderSubtotals"
            '
            'category60
            '
            Me.category60.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowTVShowLineDetail, Me.category61, Me.category62})
            Me.category60.Name = "category60"
            Me.category60.Properties.Caption = "Detail, Sorting & Grouping"
            '
            'rowTVShowLineDetail
            '
            Me.rowTVShowLineDetail.Name = "rowTVShowLineDetail"
            Me.rowTVShowLineDetail.Properties.Caption = "Grouping Option"
            Me.rowTVShowLineDetail.Properties.FieldName = "TVShowLineDetail"
            '
            'category61
            '
            Me.category61.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowTVOrderNumberColumn, Me.rowTVVendorNameColumn, Me.rowTVShowVendorCode, Me.rowTVOrderMonthsColumn, Me.rowTVNetAmountColumn, Me.rowTVCommissionAmountColumn, Me.rowTVTaxAmountColumn, Me.rowTVBillAmountColumn, Me.rowTVPriorBillAmountColumn, Me.rowTVBilledToDateAmountColumn})
            Me.category61.Name = "category61"
            Me.category61.Properties.Caption = "Order Options"
            '
            'rowTVOrderNumberColumn
            '
            Me.rowTVOrderNumberColumn.Name = "rowTVOrderNumberColumn"
            Me.rowTVOrderNumberColumn.Properties.Caption = "Order Number"
            Me.rowTVOrderNumberColumn.Properties.FieldName = "TVOrderNumberColumn"
            '
            'rowTVVendorNameColumn
            '
            Me.rowTVVendorNameColumn.Name = "rowTVVendorNameColumn"
            Me.rowTVVendorNameColumn.Properties.Caption = "Vendor Name"
            Me.rowTVVendorNameColumn.Properties.FieldName = "TVVendorNameColumn"
            '
            'rowTVShowVendorCode
            '
            Me.rowTVShowVendorCode.Name = "rowTVShowVendorCode"
            Me.rowTVShowVendorCode.Properties.Caption = "Vendor Code"
            Me.rowTVShowVendorCode.Properties.FieldName = "TVShowVendorCode"
            '
            'rowTVOrderMonthsColumn
            '
            Me.rowTVOrderMonthsColumn.Name = "rowTVOrderMonthsColumn"
            Me.rowTVOrderMonthsColumn.Properties.Caption = "Order Months"
            Me.rowTVOrderMonthsColumn.Properties.FieldName = "TVOrderMonthsColumn"
            '
            'rowTVNetAmountColumn
            '
            Me.rowTVNetAmountColumn.Name = "rowTVNetAmountColumn"
            Me.rowTVNetAmountColumn.Properties.Caption = "Net Amount"
            Me.rowTVNetAmountColumn.Properties.FieldName = "TVNetAmountColumn"
            '
            'rowTVCommissionAmountColumn
            '
            Me.rowTVCommissionAmountColumn.Name = "rowTVCommissionAmountColumn"
            Me.rowTVCommissionAmountColumn.Properties.Caption = "Commission Amount"
            Me.rowTVCommissionAmountColumn.Properties.FieldName = "TVCommissionAmountColumn"
            '
            'rowTVTaxAmountColumn
            '
            Me.rowTVTaxAmountColumn.Name = "rowTVTaxAmountColumn"
            Me.rowTVTaxAmountColumn.Properties.Caption = "Tax Amount"
            Me.rowTVTaxAmountColumn.Properties.FieldName = "TVTaxAmountColumn"
            '
            'rowTVBillAmountColumn
            '
            Me.rowTVBillAmountColumn.Name = "rowTVBillAmountColumn"
            Me.rowTVBillAmountColumn.Properties.Caption = "Bill Amount"
            Me.rowTVBillAmountColumn.Properties.FieldName = "TVBillAmountColumn"
            '
            'rowTVPriorBillAmountColumn
            '
            Me.rowTVPriorBillAmountColumn.Name = "rowTVPriorBillAmountColumn"
            Me.rowTVPriorBillAmountColumn.Properties.Caption = "Prior Bill Amount"
            Me.rowTVPriorBillAmountColumn.Properties.FieldName = "TVPriorBillAmountColumn"
            '
            'rowTVBilledToDateAmountColumn
            '
            Me.rowTVBilledToDateAmountColumn.Name = "rowTVBilledToDateAmountColumn"
            Me.rowTVBilledToDateAmountColumn.Properties.Caption = "Billed To Date Amount"
            Me.rowTVBilledToDateAmountColumn.Properties.FieldName = "TVBilledToDateAmountColumn"
            '
            'category62
            '
            Me.category62.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowTVShowZeroLineAmounts, Me.rowTVSortLinesBy, Me.rowTVLineNumberColumn, Me.rowTVProgramColumn, Me.rowTVSpotLengthColumn, Me.rowTVTagColumn, Me.rowTVStartEndTimesColumn, Me.rowTVNumberOfSpotsColumn, Me.rowTVRemarksColumn, Me.rowTVCloseDateColumn, Me.rowTVJobComponentNumberColumn, Me.rowTVJobDescriptionColumn, Me.rowTVComponentDescriptionColumn, Me.rowTVOrderDetailCommentColumn, Me.rowTVOrderHouseDetailCommentColumn, Me.rowTVExtraChargesColumn, Me.rowTVStartDateColumn})
            Me.category62.Name = "category62"
            Me.category62.Properties.Caption = "Order/Line Options"
            '
            'rowTVShowZeroLineAmounts
            '
            Me.rowTVShowZeroLineAmounts.Name = "rowTVShowZeroLineAmounts"
            Me.rowTVShowZeroLineAmounts.Properties.Caption = "Show Zero Line Amounts"
            Me.rowTVShowZeroLineAmounts.Properties.FieldName = "TVShowZeroLineAmounts"
            '
            'rowTVSortLinesBy
            '
            Me.rowTVSortLinesBy.Name = "rowTVSortLinesBy"
            Me.rowTVSortLinesBy.Properties.Caption = "Sort Lines By"
            Me.rowTVSortLinesBy.Properties.FieldName = "TVSortLinesBy"
            '
            'rowTVLineNumberColumn
            '
            Me.rowTVLineNumberColumn.Name = "rowTVLineNumberColumn"
            Me.rowTVLineNumberColumn.Properties.Caption = "Line Number"
            Me.rowTVLineNumberColumn.Properties.FieldName = "TVLineNumberColumn"
            '
            'rowTVProgramColumn
            '
            Me.rowTVProgramColumn.Name = "rowTVProgramColumn"
            Me.rowTVProgramColumn.Properties.Caption = "Program"
            Me.rowTVProgramColumn.Properties.FieldName = "TVProgramColumn"
            '
            'rowTVSpotLengthColumn
            '
            Me.rowTVSpotLengthColumn.Name = "rowTVSpotLengthColumn"
            Me.rowTVSpotLengthColumn.Properties.Caption = "Spot Length"
            Me.rowTVSpotLengthColumn.Properties.FieldName = "TVSpotLengthColumn"
            '
            'rowTVTagColumn
            '
            Me.rowTVTagColumn.Name = "rowTVTagColumn"
            Me.rowTVTagColumn.Properties.Caption = "Tag"
            Me.rowTVTagColumn.Properties.FieldName = "TVTagColumn"
            '
            'rowTVStartEndTimesColumn
            '
            Me.rowTVStartEndTimesColumn.Name = "rowTVStartEndTimesColumn"
            Me.rowTVStartEndTimesColumn.Properties.Caption = "Start-End Times"
            Me.rowTVStartEndTimesColumn.Properties.FieldName = "TVStartEndTimesColumn"
            '
            'rowTVNumberOfSpotsColumn
            '
            Me.rowTVNumberOfSpotsColumn.Name = "rowTVNumberOfSpotsColumn"
            Me.rowTVNumberOfSpotsColumn.Properties.Caption = "Number Of Spots"
            Me.rowTVNumberOfSpotsColumn.Properties.FieldName = "TVNumberOfSpotsColumn"
            '
            'rowTVRemarksColumn
            '
            Me.rowTVRemarksColumn.Name = "rowTVRemarksColumn"
            Me.rowTVRemarksColumn.Properties.Caption = "Remarks"
            Me.rowTVRemarksColumn.Properties.FieldName = "TVRemarksColumn"
            '
            'rowTVCloseDateColumn
            '
            Me.rowTVCloseDateColumn.Name = "rowTVCloseDateColumn"
            Me.rowTVCloseDateColumn.Properties.Caption = "Close Date"
            Me.rowTVCloseDateColumn.Properties.FieldName = "TVCloseDateColumn"
            '
            'rowTVJobComponentNumberColumn
            '
            Me.rowTVJobComponentNumberColumn.Name = "rowTVJobComponentNumberColumn"
            Me.rowTVJobComponentNumberColumn.Properties.Caption = "Job Component Number"
            Me.rowTVJobComponentNumberColumn.Properties.FieldName = "TVJobComponentNumberColumn"
            '
            'rowTVJobDescriptionColumn
            '
            Me.rowTVJobDescriptionColumn.Name = "rowTVJobDescriptionColumn"
            Me.rowTVJobDescriptionColumn.Properties.Caption = "Job Description"
            Me.rowTVJobDescriptionColumn.Properties.FieldName = "TVJobDescriptionColumn"
            '
            'rowTVComponentDescriptionColumn
            '
            Me.rowTVComponentDescriptionColumn.Name = "rowTVComponentDescriptionColumn"
            Me.rowTVComponentDescriptionColumn.Properties.Caption = "Component Description"
            Me.rowTVComponentDescriptionColumn.Properties.FieldName = "TVComponentDescriptionColumn"
            '
            'rowTVOrderDetailCommentColumn
            '
            Me.rowTVOrderDetailCommentColumn.Name = "rowTVOrderDetailCommentColumn"
            Me.rowTVOrderDetailCommentColumn.Properties.Caption = "Order Instructions"
            Me.rowTVOrderDetailCommentColumn.Properties.FieldName = "TVOrderDetailCommentColumn"
            '
            'rowTVOrderHouseDetailCommentColumn
            '
            Me.rowTVOrderHouseDetailCommentColumn.Name = "rowTVOrderHouseDetailCommentColumn"
            Me.rowTVOrderHouseDetailCommentColumn.Properties.Caption = "Order House Detail Comment"
            Me.rowTVOrderHouseDetailCommentColumn.Properties.FieldName = "TVOrderHouseDetailCommentColumn"
            '
            'rowTVExtraChargesColumn
            '
            Me.rowTVExtraChargesColumn.Name = "rowTVExtraChargesColumn"
            Me.rowTVExtraChargesColumn.Properties.Caption = "Extra Charges"
            Me.rowTVExtraChargesColumn.Properties.FieldName = "TVExtraChargesColumn"
            '
            'category63
            '
            Me.category63.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowTVShowCommissionSeparately, Me.rowTVShowRebateSeparately, Me.rowTVShowTaxSeparately, Me.rowTVShowBillingHistory})
            Me.category63.Name = "category63"
            Me.category63.Properties.Caption = "Footer Options"
            '
            'rowTVShowCommissionSeparately
            '
            Me.rowTVShowCommissionSeparately.Name = "rowTVShowCommissionSeparately"
            Me.rowTVShowCommissionSeparately.Properties.Caption = "Show Commission Separately"
            Me.rowTVShowCommissionSeparately.Properties.FieldName = "TVShowCommissionSeparately"
            '
            'rowTVShowRebateSeparately
            '
            Me.rowTVShowRebateSeparately.Name = "rowTVShowRebateSeparately"
            Me.rowTVShowRebateSeparately.Properties.Caption = "Show Rebate Separately"
            Me.rowTVShowRebateSeparately.Properties.FieldName = "TVShowRebateSeparately"
            '
            'rowTVShowTaxSeparately
            '
            Me.rowTVShowTaxSeparately.Name = "rowTVShowTaxSeparately"
            Me.rowTVShowTaxSeparately.Properties.Caption = "Show Tax Separately"
            Me.rowTVShowTaxSeparately.Properties.FieldName = "TVShowTaxSeparately"
            '
            'rowTVShowBillingHistory
            '
            Me.rowTVShowBillingHistory.Name = "rowTVShowBillingHistory"
            Me.rowTVShowBillingHistory.Properties.Caption = "Show Billing History"
            Me.rowTVShowBillingHistory.Properties.FieldName = "TVShowBillingHistory"
            '
            'TabItemOptions_TVTab
            '
            Me.TabItemOptions_TVTab.AttachedControl = Me.TabControlPanelTVTab_TV
            Me.TabItemOptions_TVTab.Name = "TabItemOptions_TVTab"
            Me.TabItemOptions_TVTab.Text = "TV"
            '
            'TabControlPanelRadioTab_Radio
            '
            Me.TabControlPanelRadioTab_Radio.Controls.Add(Me.VerticalGridRadio_Settings)
            Me.TabControlPanelRadioTab_Radio.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelRadioTab_Radio.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelRadioTab_Radio.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelRadioTab_Radio.Name = "TabControlPanelRadioTab_Radio"
            Me.TabControlPanelRadioTab_Radio.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelRadioTab_Radio.Size = New System.Drawing.Size(679, 456)
            Me.TabControlPanelRadioTab_Radio.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelRadioTab_Radio.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelRadioTab_Radio.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelRadioTab_Radio.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelRadioTab_Radio.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelRadioTab_Radio.Style.GradientAngle = 90
            Me.TabControlPanelRadioTab_Radio.TabIndex = 7
            Me.TabControlPanelRadioTab_Radio.TabItem = Me.TabItemOptions_RadioTab
            '
            'VerticalGridRadio_Settings
            '
            Me.VerticalGridRadio_Settings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.VerticalGridRadio_Settings.Appearance.RowHeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            Me.VerticalGridRadio_Settings.Appearance.RowHeaderPanel.Options.UseFont = True
            Me.VerticalGridRadio_Settings.Cursor = System.Windows.Forms.Cursors.Default
            Me.VerticalGridRadio_Settings.CustomizationFormBounds = New System.Drawing.Rectangle(1384, 433, 216, 265)
            Me.VerticalGridRadio_Settings.DataSource = Me.MediaInvoiceRadioSettingBindingSource
            Me.VerticalGridRadio_Settings.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView
            Me.VerticalGridRadio_Settings.Location = New System.Drawing.Point(4, 4)
            Me.VerticalGridRadio_Settings.Name = "VerticalGridRadio_Settings"
            Me.VerticalGridRadio_Settings.OptionsBehavior.RecordsMouseWheel = True
            Me.VerticalGridRadio_Settings.OptionsBehavior.ResizeRowHeaders = False
            Me.VerticalGridRadio_Settings.OptionsBehavior.UseEnterAsTab = True
            Me.VerticalGridRadio_Settings.Rows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowRadioCustomInvoiceID, Me.category49, Me.category56, Me.category52, Me.category55})
            Me.VerticalGridRadio_Settings.ShowButtonMode = DevExpress.XtraVerticalGrid.ShowButtonModeEnum.ShowAlways
            Me.VerticalGridRadio_Settings.Size = New System.Drawing.Size(671, 448)
            Me.VerticalGridRadio_Settings.TabIndex = 2
            Me.VerticalGridRadio_Settings.TreeButtonStyle = DevExpress.XtraVerticalGrid.TreeButtonStyle.TreeView
            '
            'MediaInvoiceRadioSettingBindingSource
            '
            Me.MediaInvoiceRadioSettingBindingSource.DataSource = GetType(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceRadioSetting)
            '
            'rowRadioCustomInvoiceID
            '
            Me.rowRadioCustomInvoiceID.Name = "rowRadioCustomInvoiceID"
            Me.rowRadioCustomInvoiceID.Properties.Caption = "Custom Invoice"
            Me.rowRadioCustomInvoiceID.Properties.FieldName = "RadioCustomInvoiceID"
            '
            'category49
            '
            Me.category49.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.category50, Me.category51, Me.category72})
            Me.category49.Height = 17
            Me.category49.Name = "category49"
            Me.category49.Properties.Caption = "Header Options"
            '
            'category50
            '
            Me.category50.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowRadioUseInvoiceCategoryDescription, Me.rowRadioInvoiceTitle, Me.rowRadioPrintInvoiceDueDate})
            Me.category50.Name = "category50"
            Me.category50.Properties.Caption = "Title Options"
            '
            'rowRadioUseInvoiceCategoryDescription
            '
            Me.rowRadioUseInvoiceCategoryDescription.Name = "rowRadioUseInvoiceCategoryDescription"
            Me.rowRadioUseInvoiceCategoryDescription.Properties.Caption = "Use Invoice Category Description"
            Me.rowRadioUseInvoiceCategoryDescription.Properties.FieldName = "RadioUseInvoiceCategoryDescription"
            '
            'rowRadioInvoiceTitle
            '
            Me.rowRadioInvoiceTitle.Name = "rowRadioInvoiceTitle"
            Me.rowRadioInvoiceTitle.Properties.Caption = "Invoice Title"
            Me.rowRadioInvoiceTitle.Properties.FieldName = "RadioInvoiceTitle"
            '
            'rowRadioPrintInvoiceDueDate
            '
            Me.rowRadioPrintInvoiceDueDate.Name = "rowRadioPrintInvoiceDueDate"
            Me.rowRadioPrintInvoiceDueDate.Properties.Caption = "Invoice Due Date"
            Me.rowRadioPrintInvoiceDueDate.Properties.FieldName = "RadioPrintInvoiceDueDate"
            '
            'category51
            '
            Me.category51.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowRadioShowClientPO, Me.rowRadioClientPOLocation, Me.rowRadioShowSalesClass, Me.rowRadioSalesClassLocation, Me.rowRadioShowCampaign, Me.rowRadioCampaignLocation, Me.rowRadioShowClientReference})
            Me.category51.Name = "category51"
            Me.category51.Properties.Caption = "Include Fields"
            '
            'rowRadioShowClientPO
            '
            Me.rowRadioShowClientPO.Name = "rowRadioShowClientPO"
            Me.rowRadioShowClientPO.Properties.Caption = "Show Client PO"
            Me.rowRadioShowClientPO.Properties.FieldName = "RadioShowClientPO"
            '
            'rowRadioClientPOLocation
            '
            Me.rowRadioClientPOLocation.Name = "rowRadioClientPOLocation"
            Me.rowRadioClientPOLocation.Properties.Caption = "Client PO Location"
            Me.rowRadioClientPOLocation.Properties.FieldName = "RadioClientPOLocation"
            '
            'rowRadioShowSalesClass
            '
            Me.rowRadioShowSalesClass.Name = "rowRadioShowSalesClass"
            Me.rowRadioShowSalesClass.Properties.Caption = "Show Sales Class"
            Me.rowRadioShowSalesClass.Properties.FieldName = "RadioShowSalesClass"
            '
            'rowRadioSalesClassLocation
            '
            Me.rowRadioSalesClassLocation.Name = "rowRadioSalesClassLocation"
            Me.rowRadioSalesClassLocation.Properties.Caption = "Sales Class Location"
            Me.rowRadioSalesClassLocation.Properties.FieldName = "RadioSalesClassLocation"
            '
            'rowRadioShowCampaign
            '
            Me.rowRadioShowCampaign.Name = "rowRadioShowCampaign"
            Me.rowRadioShowCampaign.Properties.Caption = "Show Campaign"
            Me.rowRadioShowCampaign.Properties.FieldName = "RadioShowCampaign"
            '
            'rowRadioCampaignLocation
            '
            Me.rowRadioCampaignLocation.Name = "rowRadioCampaignLocation"
            Me.rowRadioCampaignLocation.Properties.Caption = "Campaign Location"
            Me.rowRadioCampaignLocation.Properties.FieldName = "RadioCampaignLocation"
            '
            'rowRadioShowClientReference
            '
            Me.rowRadioShowClientReference.Name = "rowRadioShowClientReference"
            Me.rowRadioShowClientReference.Properties.Caption = "Show Client Reference"
            Me.rowRadioShowClientReference.Properties.FieldName = "RadioShowClientReference"
            Me.rowRadioShowClientReference.Visible = False
            '
            'category72
            '
            Me.category72.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowRadioShowOrderComment, Me.rowRadioShowOrderHouseComment, Me.rowRadioShowCampaignComment})
            Me.category72.Name = "category72"
            Me.category72.Properties.Caption = "Comments"
            '
            'rowRadioShowOrderComment
            '
            Me.rowRadioShowOrderComment.Name = "rowRadioShowOrderComment"
            Me.rowRadioShowOrderComment.Properties.Caption = "Show Order Comment"
            Me.rowRadioShowOrderComment.Properties.FieldName = "RadioShowOrderComment"
            '
            'rowRadioShowOrderHouseComment
            '
            Me.rowRadioShowOrderHouseComment.Name = "rowRadioShowOrderHouseComment"
            Me.rowRadioShowOrderHouseComment.Properties.Caption = "Show Order House Comment"
            Me.rowRadioShowOrderHouseComment.Properties.FieldName = "RadioShowOrderHouseComment"
            '
            'rowRadioShowCampaignComment
            '
            Me.rowRadioShowCampaignComment.Name = "rowRadioShowCampaignComment"
            Me.rowRadioShowCampaignComment.Properties.Caption = "Show Campaign Comment"
            Me.rowRadioShowCampaignComment.Properties.FieldName = "RadioShowCampaignComment"
            '
            'category56
            '
            Me.category56.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowRadioHeaderGroupBy, Me.rowRadioShowOrderDescription, Me.rowRadioShowOrderSubtotals})
            Me.category56.Name = "category56"
            Me.category56.Properties.Caption = "Order Options"
            '
            'rowRadioHeaderGroupBy
            '
            Me.rowRadioHeaderGroupBy.Name = "rowRadioHeaderGroupBy"
            Me.rowRadioHeaderGroupBy.Properties.Caption = "Group Orders By"
            Me.rowRadioHeaderGroupBy.Properties.FieldName = "RadioHeaderGroupBy"
            '
            'rowRadioShowOrderDescription
            '
            Me.rowRadioShowOrderDescription.Name = "rowRadioShowOrderDescription"
            Me.rowRadioShowOrderDescription.Properties.Caption = "Show Order Description"
            Me.rowRadioShowOrderDescription.Properties.FieldName = "RadioShowOrderDescription"
            '
            'rowRadioShowOrderSubtotals
            '
            Me.rowRadioShowOrderSubtotals.Name = "rowRadioShowOrderSubtotals"
            Me.rowRadioShowOrderSubtotals.Properties.Caption = "Show Order Subtotals"
            Me.rowRadioShowOrderSubtotals.Properties.FieldName = "RadioShowOrderSubtotals"
            '
            'category52
            '
            Me.category52.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowRadioShowLineDetail, Me.category53, Me.category54})
            Me.category52.Name = "category52"
            Me.category52.Properties.Caption = "Detail, Sorting & Grouping"
            '
            'rowRadioShowLineDetail
            '
            Me.rowRadioShowLineDetail.Name = "rowRadioShowLineDetail"
            Me.rowRadioShowLineDetail.Properties.Caption = "Grouping Option"
            Me.rowRadioShowLineDetail.Properties.FieldName = "RadioShowLineDetail"
            '
            'category53
            '
            Me.category53.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowRadioOrderNumberColumn, Me.rowRadioVendorNameColumn, Me.rowRadioShowVendorCode, Me.rowRadioOrderMonthsColumn, Me.rowRadioNetAmountColumn, Me.rowRadioCommissionAmountColumn, Me.rowRadioTaxAmountColumn, Me.rowRadioBillAmountColumn, Me.rowRadioPriorBillAmountColumn, Me.rowRadioBilledToDateAmountColumn})
            Me.category53.Name = "category53"
            Me.category53.Properties.Caption = "Order Options"
            '
            'rowRadioOrderNumberColumn
            '
            Me.rowRadioOrderNumberColumn.Name = "rowRadioOrderNumberColumn"
            Me.rowRadioOrderNumberColumn.Properties.Caption = "Order Number"
            Me.rowRadioOrderNumberColumn.Properties.FieldName = "RadioOrderNumberColumn"
            '
            'rowRadioVendorNameColumn
            '
            Me.rowRadioVendorNameColumn.Name = "rowRadioVendorNameColumn"
            Me.rowRadioVendorNameColumn.Properties.Caption = "Vendor Name"
            Me.rowRadioVendorNameColumn.Properties.FieldName = "RadioVendorNameColumn"
            '
            'rowRadioShowVendorCode
            '
            Me.rowRadioShowVendorCode.Name = "rowRadioShowVendorCode"
            Me.rowRadioShowVendorCode.Properties.Caption = "Vendor Code"
            Me.rowRadioShowVendorCode.Properties.FieldName = "RadioShowVendorCode"
            '
            'rowRadioOrderMonthsColumn
            '
            Me.rowRadioOrderMonthsColumn.Name = "rowRadioOrderMonthsColumn"
            Me.rowRadioOrderMonthsColumn.Properties.Caption = "Order Months"
            Me.rowRadioOrderMonthsColumn.Properties.FieldName = "RadioOrderMonthsColumn"
            '
            'rowRadioNetAmountColumn
            '
            Me.rowRadioNetAmountColumn.Name = "rowRadioNetAmountColumn"
            Me.rowRadioNetAmountColumn.Properties.Caption = "Net Amount"
            Me.rowRadioNetAmountColumn.Properties.FieldName = "RadioNetAmountColumn"
            '
            'rowRadioCommissionAmountColumn
            '
            Me.rowRadioCommissionAmountColumn.Name = "rowRadioCommissionAmountColumn"
            Me.rowRadioCommissionAmountColumn.Properties.Caption = "Commission Amount"
            Me.rowRadioCommissionAmountColumn.Properties.FieldName = "RadioCommissionAmountColumn"
            '
            'rowRadioTaxAmountColumn
            '
            Me.rowRadioTaxAmountColumn.Name = "rowRadioTaxAmountColumn"
            Me.rowRadioTaxAmountColumn.Properties.Caption = "Tax Amount"
            Me.rowRadioTaxAmountColumn.Properties.FieldName = "RadioTaxAmountColumn"
            '
            'rowRadioBillAmountColumn
            '
            Me.rowRadioBillAmountColumn.Name = "rowRadioBillAmountColumn"
            Me.rowRadioBillAmountColumn.Properties.Caption = "Bill Amount"
            Me.rowRadioBillAmountColumn.Properties.FieldName = "RadioBillAmountColumn"
            '
            'rowRadioPriorBillAmountColumn
            '
            Me.rowRadioPriorBillAmountColumn.Name = "rowRadioPriorBillAmountColumn"
            Me.rowRadioPriorBillAmountColumn.Properties.Caption = "Prior Bill Amount"
            Me.rowRadioPriorBillAmountColumn.Properties.FieldName = "RadioPriorBillAmountColumn"
            '
            'rowRadioBilledToDateAmountColumn
            '
            Me.rowRadioBilledToDateAmountColumn.Name = "rowRadioBilledToDateAmountColumn"
            Me.rowRadioBilledToDateAmountColumn.Properties.Caption = "Billed To Date Amount"
            Me.rowRadioBilledToDateAmountColumn.Properties.FieldName = "RadioBilledToDateAmountColumn"
            '
            'category54
            '
            Me.category54.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowRadioShowZeroLineAmounts, Me.rowRadioSortLinesBy, Me.rowRadioLineNumberColumn, Me.rowRadioProgramColumn, Me.rowRadioSpotLengthColumn, Me.rowRadioTagColumn, Me.rowRadioStartEndTimesColumn, Me.rowRadioNumberOfSpotsColumn, Me.rowRadioRemarksColumn, Me.rowRadioCloseDateColumn, Me.rowRadioJobComponentNumberColumn, Me.rowRadioJobDescriptionColumn, Me.rowRadioComponentDescriptionColumn, Me.rowRadioOrderDetailCommentColumn, Me.rowRadioOrderHouseDetailCommentColumn, Me.rowRadioExtraChargesColumn, Me.rowRadioStartDateColumn})
            Me.category54.Name = "category54"
            Me.category54.Properties.Caption = "Order/Line Options"
            '
            'rowRadioShowZeroLineAmounts
            '
            Me.rowRadioShowZeroLineAmounts.Name = "rowRadioShowZeroLineAmounts"
            Me.rowRadioShowZeroLineAmounts.Properties.Caption = "Show Zero Line Amounts"
            Me.rowRadioShowZeroLineAmounts.Properties.FieldName = "RadioShowZeroLineAmounts"
            '
            'rowRadioSortLinesBy
            '
            Me.rowRadioSortLinesBy.Name = "rowRadioSortLinesBy"
            Me.rowRadioSortLinesBy.Properties.Caption = "Sort Lines By"
            Me.rowRadioSortLinesBy.Properties.FieldName = "RadioSortLinesBy"
            '
            'rowRadioLineNumberColumn
            '
            Me.rowRadioLineNumberColumn.Name = "rowRadioLineNumberColumn"
            Me.rowRadioLineNumberColumn.Properties.Caption = "Line Number"
            Me.rowRadioLineNumberColumn.Properties.FieldName = "RadioLineNumberColumn"
            '
            'rowRadioProgramColumn
            '
            Me.rowRadioProgramColumn.Name = "rowRadioProgramColumn"
            Me.rowRadioProgramColumn.Properties.Caption = "Program"
            Me.rowRadioProgramColumn.Properties.FieldName = "RadioProgramColumn"
            '
            'rowRadioSpotLengthColumn
            '
            Me.rowRadioSpotLengthColumn.Name = "rowRadioSpotLengthColumn"
            Me.rowRadioSpotLengthColumn.Properties.Caption = "Spot Length"
            Me.rowRadioSpotLengthColumn.Properties.FieldName = "RadioSpotLengthColumn"
            '
            'rowRadioTagColumn
            '
            Me.rowRadioTagColumn.Name = "rowRadioTagColumn"
            Me.rowRadioTagColumn.Properties.Caption = "Tag"
            Me.rowRadioTagColumn.Properties.FieldName = "RadioTagColumn"
            '
            'rowRadioStartEndTimesColumn
            '
            Me.rowRadioStartEndTimesColumn.Name = "rowRadioStartEndTimesColumn"
            Me.rowRadioStartEndTimesColumn.Properties.Caption = "Start-End Times"
            Me.rowRadioStartEndTimesColumn.Properties.FieldName = "RadioStartEndTimesColumn"
            '
            'rowRadioNumberOfSpotsColumn
            '
            Me.rowRadioNumberOfSpotsColumn.Name = "rowRadioNumberOfSpotsColumn"
            Me.rowRadioNumberOfSpotsColumn.Properties.Caption = "Number Of Spots"
            Me.rowRadioNumberOfSpotsColumn.Properties.FieldName = "RadioNumberOfSpotsColumn"
            '
            'rowRadioRemarksColumn
            '
            Me.rowRadioRemarksColumn.Name = "rowRadioRemarksColumn"
            Me.rowRadioRemarksColumn.Properties.Caption = "Remarks"
            Me.rowRadioRemarksColumn.Properties.FieldName = "RadioRemarksColumn"
            '
            'rowRadioCloseDateColumn
            '
            Me.rowRadioCloseDateColumn.Name = "rowRadioCloseDateColumn"
            Me.rowRadioCloseDateColumn.Properties.Caption = "Close Date"
            Me.rowRadioCloseDateColumn.Properties.FieldName = "RadioCloseDateColumn"
            '
            'rowRadioJobComponentNumberColumn
            '
            Me.rowRadioJobComponentNumberColumn.Name = "rowRadioJobComponentNumberColumn"
            Me.rowRadioJobComponentNumberColumn.Properties.Caption = "Job Component Number"
            Me.rowRadioJobComponentNumberColumn.Properties.FieldName = "RadioJobComponentNumberColumn"
            '
            'rowRadioJobDescriptionColumn
            '
            Me.rowRadioJobDescriptionColumn.Name = "rowRadioJobDescriptionColumn"
            Me.rowRadioJobDescriptionColumn.Properties.Caption = "Job Description"
            Me.rowRadioJobDescriptionColumn.Properties.FieldName = "RadioJobDescriptionColumn"
            '
            'rowRadioComponentDescriptionColumn
            '
            Me.rowRadioComponentDescriptionColumn.Name = "rowRadioComponentDescriptionColumn"
            Me.rowRadioComponentDescriptionColumn.Properties.Caption = "Component Description"
            Me.rowRadioComponentDescriptionColumn.Properties.FieldName = "RadioComponentDescriptionColumn"
            '
            'rowRadioOrderDetailCommentColumn
            '
            Me.rowRadioOrderDetailCommentColumn.Name = "rowRadioOrderDetailCommentColumn"
            Me.rowRadioOrderDetailCommentColumn.Properties.Caption = "Order Instructions"
            Me.rowRadioOrderDetailCommentColumn.Properties.FieldName = "RadioOrderDetailCommentColumn"
            '
            'rowRadioOrderHouseDetailCommentColumn
            '
            Me.rowRadioOrderHouseDetailCommentColumn.Name = "rowRadioOrderHouseDetailCommentColumn"
            Me.rowRadioOrderHouseDetailCommentColumn.Properties.Caption = "Order House Detail Comment"
            Me.rowRadioOrderHouseDetailCommentColumn.Properties.FieldName = "RadioOrderHouseDetailCommentColumn"
            '
            'rowRadioExtraChargesColumn
            '
            Me.rowRadioExtraChargesColumn.Name = "rowRadioExtraChargesColumn"
            Me.rowRadioExtraChargesColumn.Properties.Caption = "Extra Charges"
            Me.rowRadioExtraChargesColumn.Properties.FieldName = "RadioExtraChargesColumn"
            '
            'category55
            '
            Me.category55.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowRadioShowCommissionSeparately, Me.rowRadioShowRebateSeparately, Me.rowRadioShowTaxSeparately, Me.rowRadioShowBillingHistory})
            Me.category55.Name = "category55"
            Me.category55.Properties.Caption = "Footer Options"
            '
            'rowRadioShowCommissionSeparately
            '
            Me.rowRadioShowCommissionSeparately.Name = "rowRadioShowCommissionSeparately"
            Me.rowRadioShowCommissionSeparately.Properties.Caption = "Show Commission Separately"
            Me.rowRadioShowCommissionSeparately.Properties.FieldName = "RadioShowCommissionSeparately"
            '
            'rowRadioShowRebateSeparately
            '
            Me.rowRadioShowRebateSeparately.Name = "rowRadioShowRebateSeparately"
            Me.rowRadioShowRebateSeparately.Properties.Caption = "Show Rebate Separately"
            Me.rowRadioShowRebateSeparately.Properties.FieldName = "RadioShowRebateSeparately"
            '
            'rowRadioShowTaxSeparately
            '
            Me.rowRadioShowTaxSeparately.Name = "rowRadioShowTaxSeparately"
            Me.rowRadioShowTaxSeparately.Properties.Caption = "Show Tax Separately"
            Me.rowRadioShowTaxSeparately.Properties.FieldName = "RadioShowTaxSeparately"
            '
            'rowRadioShowBillingHistory
            '
            Me.rowRadioShowBillingHistory.Name = "rowRadioShowBillingHistory"
            Me.rowRadioShowBillingHistory.Properties.Caption = "Show Billing History"
            Me.rowRadioShowBillingHistory.Properties.FieldName = "RadioShowBillingHistory"
            '
            'TabItemOptions_RadioTab
            '
            Me.TabItemOptions_RadioTab.AttachedControl = Me.TabControlPanelRadioTab_Radio
            Me.TabItemOptions_RadioTab.Name = "TabItemOptions_RadioTab"
            Me.TabItemOptions_RadioTab.Text = "Radio"
            '
            'TabControlPanelOutdoorTab_Outdoor
            '
            Me.TabControlPanelOutdoorTab_Outdoor.Controls.Add(Me.VerticalGridOutdoor_Settings)
            Me.TabControlPanelOutdoorTab_Outdoor.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelOutdoorTab_Outdoor.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelOutdoorTab_Outdoor.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelOutdoorTab_Outdoor.Name = "TabControlPanelOutdoorTab_Outdoor"
            Me.TabControlPanelOutdoorTab_Outdoor.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelOutdoorTab_Outdoor.Size = New System.Drawing.Size(679, 456)
            Me.TabControlPanelOutdoorTab_Outdoor.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelOutdoorTab_Outdoor.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelOutdoorTab_Outdoor.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelOutdoorTab_Outdoor.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelOutdoorTab_Outdoor.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelOutdoorTab_Outdoor.Style.GradientAngle = 90
            Me.TabControlPanelOutdoorTab_Outdoor.TabIndex = 6
            Me.TabControlPanelOutdoorTab_Outdoor.TabItem = Me.TabItemOptions_OutdoorTab
            '
            'VerticalGridOutdoor_Settings
            '
            Me.VerticalGridOutdoor_Settings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.VerticalGridOutdoor_Settings.Appearance.RowHeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            Me.VerticalGridOutdoor_Settings.Appearance.RowHeaderPanel.Options.UseFont = True
            Me.VerticalGridOutdoor_Settings.Cursor = System.Windows.Forms.Cursors.Default
            Me.VerticalGridOutdoor_Settings.CustomizationFormBounds = New System.Drawing.Rectangle(1384, 433, 216, 265)
            Me.VerticalGridOutdoor_Settings.DataSource = Me.MediaInvoiceOutdoorSettingBindingSource
            Me.VerticalGridOutdoor_Settings.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView
            Me.VerticalGridOutdoor_Settings.Location = New System.Drawing.Point(4, 4)
            Me.VerticalGridOutdoor_Settings.Name = "VerticalGridOutdoor_Settings"
            Me.VerticalGridOutdoor_Settings.OptionsBehavior.RecordsMouseWheel = True
            Me.VerticalGridOutdoor_Settings.OptionsBehavior.ResizeRowHeaders = False
            Me.VerticalGridOutdoor_Settings.OptionsBehavior.UseEnterAsTab = True
            Me.VerticalGridOutdoor_Settings.Rows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowOutdoorCustomInvoiceID, Me.category41, Me.category48, Me.category44, Me.category47})
            Me.VerticalGridOutdoor_Settings.ShowButtonMode = DevExpress.XtraVerticalGrid.ShowButtonModeEnum.ShowAlways
            Me.VerticalGridOutdoor_Settings.Size = New System.Drawing.Size(671, 448)
            Me.VerticalGridOutdoor_Settings.TabIndex = 2
            Me.VerticalGridOutdoor_Settings.TreeButtonStyle = DevExpress.XtraVerticalGrid.TreeButtonStyle.TreeView
            '
            'MediaInvoiceOutdoorSettingBindingSource
            '
            Me.MediaInvoiceOutdoorSettingBindingSource.DataSource = GetType(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceOutdoorSetting)
            '
            'rowOutdoorCustomInvoiceID
            '
            Me.rowOutdoorCustomInvoiceID.Name = "rowOutdoorCustomInvoiceID"
            Me.rowOutdoorCustomInvoiceID.Properties.Caption = "Custom Invoice"
            Me.rowOutdoorCustomInvoiceID.Properties.FieldName = "OutdoorCustomInvoiceID"
            '
            'category41
            '
            Me.category41.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.category42, Me.category43, Me.category40})
            Me.category41.Height = 17
            Me.category41.Name = "category41"
            Me.category41.Properties.Caption = "Header Options"
            '
            'category42
            '
            Me.category42.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowOutdoorUseInvoiceCategoryDescription, Me.rowOutdoorInvoiceTitle, Me.rowOutdoorPrintInvoiceDueDate})
            Me.category42.Name = "category42"
            Me.category42.Properties.Caption = "Title Options"
            '
            'rowOutdoorUseInvoiceCategoryDescription
            '
            Me.rowOutdoorUseInvoiceCategoryDescription.Name = "rowOutdoorUseInvoiceCategoryDescription"
            Me.rowOutdoorUseInvoiceCategoryDescription.Properties.Caption = "Use Invoice Category Description"
            Me.rowOutdoorUseInvoiceCategoryDescription.Properties.FieldName = "OutdoorUseInvoiceCategoryDescription"
            '
            'rowOutdoorInvoiceTitle
            '
            Me.rowOutdoorInvoiceTitle.Name = "rowOutdoorInvoiceTitle"
            Me.rowOutdoorInvoiceTitle.Properties.Caption = "Invoice Title"
            Me.rowOutdoorInvoiceTitle.Properties.FieldName = "OutdoorInvoiceTitle"
            '
            'rowOutdoorPrintInvoiceDueDate
            '
            Me.rowOutdoorPrintInvoiceDueDate.Name = "rowOutdoorPrintInvoiceDueDate"
            Me.rowOutdoorPrintInvoiceDueDate.Properties.Caption = "Invoice Due Date"
            Me.rowOutdoorPrintInvoiceDueDate.Properties.FieldName = "OutdoorPrintInvoiceDueDate"
            '
            'category43
            '
            Me.category43.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowOutdoorShowClientPO, Me.rowOutdoorClientPOLocation, Me.rowOutdoorShowSalesClass, Me.rowOutdoorSalesClassLocation, Me.rowOutdoorShowCampaign, Me.rowOutdoorCampaignLocation, Me.rowOutdoorShowClientReference})
            Me.category43.Name = "category43"
            Me.category43.Properties.Caption = "Include Fields"
            '
            'rowOutdoorShowClientPO
            '
            Me.rowOutdoorShowClientPO.Name = "rowOutdoorShowClientPO"
            Me.rowOutdoorShowClientPO.Properties.Caption = "Show Client PO"
            Me.rowOutdoorShowClientPO.Properties.FieldName = "OutdoorShowClientPO"
            '
            'rowOutdoorClientPOLocation
            '
            Me.rowOutdoorClientPOLocation.Name = "rowOutdoorClientPOLocation"
            Me.rowOutdoorClientPOLocation.Properties.Caption = "Client PO Location"
            Me.rowOutdoorClientPOLocation.Properties.FieldName = "OutdoorClientPOLocation"
            '
            'rowOutdoorShowSalesClass
            '
            Me.rowOutdoorShowSalesClass.Name = "rowOutdoorShowSalesClass"
            Me.rowOutdoorShowSalesClass.Properties.Caption = "Show Sales Class"
            Me.rowOutdoorShowSalesClass.Properties.FieldName = "OutdoorShowSalesClass"
            '
            'rowOutdoorSalesClassLocation
            '
            Me.rowOutdoorSalesClassLocation.Name = "rowOutdoorSalesClassLocation"
            Me.rowOutdoorSalesClassLocation.Properties.Caption = "Sales Class Location"
            Me.rowOutdoorSalesClassLocation.Properties.FieldName = "OutdoorSalesClassLocation"
            '
            'rowOutdoorShowCampaign
            '
            Me.rowOutdoorShowCampaign.Name = "rowOutdoorShowCampaign"
            Me.rowOutdoorShowCampaign.Properties.Caption = "Show Campaign"
            Me.rowOutdoorShowCampaign.Properties.FieldName = "OutdoorShowCampaign"
            '
            'rowOutdoorCampaignLocation
            '
            Me.rowOutdoorCampaignLocation.Name = "rowOutdoorCampaignLocation"
            Me.rowOutdoorCampaignLocation.Properties.Caption = "Campaign Location"
            Me.rowOutdoorCampaignLocation.Properties.FieldName = "OutdoorCampaignLocation"
            '
            'rowOutdoorShowClientReference
            '
            Me.rowOutdoorShowClientReference.Name = "rowOutdoorShowClientReference"
            Me.rowOutdoorShowClientReference.Properties.Caption = "Show Client Reference"
            Me.rowOutdoorShowClientReference.Properties.FieldName = "OutdoorShowClientReference"
            Me.rowOutdoorShowClientReference.Visible = False
            '
            'category40
            '
            Me.category40.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowOutdoorShowOrderComment, Me.rowOutdoorShowOrderHouseComment, Me.rowOutdoorShowCampaignComment})
            Me.category40.Name = "category40"
            Me.category40.Properties.Caption = "Comments"
            '
            'rowOutdoorShowOrderComment
            '
            Me.rowOutdoorShowOrderComment.Name = "rowOutdoorShowOrderComment"
            Me.rowOutdoorShowOrderComment.Properties.Caption = "Show Order Comment"
            Me.rowOutdoorShowOrderComment.Properties.FieldName = "OutdoorShowOrderComment"
            '
            'rowOutdoorShowOrderHouseComment
            '
            Me.rowOutdoorShowOrderHouseComment.Name = "rowOutdoorShowOrderHouseComment"
            Me.rowOutdoorShowOrderHouseComment.Properties.Caption = "Show Order House Comment"
            Me.rowOutdoorShowOrderHouseComment.Properties.FieldName = "OutdoorShowOrderHouseComment"
            '
            'rowOutdoorShowCampaignComment
            '
            Me.rowOutdoorShowCampaignComment.Name = "rowOutdoorShowCampaignComment"
            Me.rowOutdoorShowCampaignComment.Properties.Caption = "Show Campaign Comment"
            Me.rowOutdoorShowCampaignComment.Properties.FieldName = "OutdoorShowCampaignComment"
            '
            'category48
            '
            Me.category48.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowOutdoorHeaderGroupBy, Me.rowOutdoorShowOrderDescription, Me.rowOutdoorShowOrderSubtotals})
            Me.category48.Name = "category48"
            Me.category48.Properties.Caption = "Order Options"
            '
            'rowOutdoorHeaderGroupBy
            '
            Me.rowOutdoorHeaderGroupBy.Name = "rowOutdoorHeaderGroupBy"
            Me.rowOutdoorHeaderGroupBy.Properties.Caption = "Group Orders By"
            Me.rowOutdoorHeaderGroupBy.Properties.FieldName = "OutdoorHeaderGroupBy"
            '
            'rowOutdoorShowOrderDescription
            '
            Me.rowOutdoorShowOrderDescription.Name = "rowOutdoorShowOrderDescription"
            Me.rowOutdoorShowOrderDescription.Properties.Caption = "Show Order Description"
            Me.rowOutdoorShowOrderDescription.Properties.FieldName = "OutdoorShowOrderDescription"
            '
            'rowOutdoorShowOrderSubtotals
            '
            Me.rowOutdoorShowOrderSubtotals.Name = "rowOutdoorShowOrderSubtotals"
            Me.rowOutdoorShowOrderSubtotals.Properties.Caption = "Show Order Subtotals"
            Me.rowOutdoorShowOrderSubtotals.Properties.FieldName = "OutdoorShowOrderSubtotals"
            '
            'category44
            '
            Me.category44.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowOutdoorShowLineDetail, Me.category45, Me.category46})
            Me.category44.Name = "category44"
            Me.category44.Properties.Caption = "Detail, Sorting & Grouping"
            '
            'rowOutdoorShowLineDetail
            '
            Me.rowOutdoorShowLineDetail.Name = "rowOutdoorShowLineDetail"
            Me.rowOutdoorShowLineDetail.Properties.Caption = "Grouping Option"
            Me.rowOutdoorShowLineDetail.Properties.FieldName = "OutdoorShowLineDetail"
            '
            'category45
            '
            Me.category45.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowOutdoorOrderNumberColumn, Me.rowOutdoorVendorNameColumn, Me.rowOutdoorShowVendorCode, Me.rowOutdoorOrderMonthsColumn, Me.rowOutdoorNetAmountColumn, Me.rowOutdoorCommissionAmountColumn, Me.rowOutdoorTaxAmountColumn, Me.rowOutdoorBillAmountColumn, Me.rowOutdoorPriorBillAmountColumn, Me.rowOutdoorBilledToDateAmountColumn})
            Me.category45.Name = "category45"
            Me.category45.Properties.Caption = "Order Options"
            '
            'rowOutdoorOrderNumberColumn
            '
            Me.rowOutdoorOrderNumberColumn.Name = "rowOutdoorOrderNumberColumn"
            Me.rowOutdoorOrderNumberColumn.Properties.Caption = "Order Number"
            Me.rowOutdoorOrderNumberColumn.Properties.FieldName = "OutdoorOrderNumberColumn"
            '
            'rowOutdoorVendorNameColumn
            '
            Me.rowOutdoorVendorNameColumn.Name = "rowOutdoorVendorNameColumn"
            Me.rowOutdoorVendorNameColumn.Properties.Caption = "Vendor Name"
            Me.rowOutdoorVendorNameColumn.Properties.FieldName = "OutdoorVendorNameColumn"
            '
            'rowOutdoorShowVendorCode
            '
            Me.rowOutdoorShowVendorCode.Name = "rowOutdoorShowVendorCode"
            Me.rowOutdoorShowVendorCode.Properties.Caption = "Vendor Code"
            Me.rowOutdoorShowVendorCode.Properties.FieldName = "OutdoorShowVendorCode"
            '
            'rowOutdoorOrderMonthsColumn
            '
            Me.rowOutdoorOrderMonthsColumn.Name = "rowOutdoorOrderMonthsColumn"
            Me.rowOutdoorOrderMonthsColumn.Properties.Caption = "Order Months"
            Me.rowOutdoorOrderMonthsColumn.Properties.FieldName = "OutdoorOrderMonthsColumn"
            '
            'rowOutdoorNetAmountColumn
            '
            Me.rowOutdoorNetAmountColumn.Name = "rowOutdoorNetAmountColumn"
            Me.rowOutdoorNetAmountColumn.Properties.Caption = "Net Amount"
            Me.rowOutdoorNetAmountColumn.Properties.FieldName = "OutdoorNetAmountColumn"
            '
            'rowOutdoorCommissionAmountColumn
            '
            Me.rowOutdoorCommissionAmountColumn.Name = "rowOutdoorCommissionAmountColumn"
            Me.rowOutdoorCommissionAmountColumn.Properties.Caption = "Commission Amount"
            Me.rowOutdoorCommissionAmountColumn.Properties.FieldName = "OutdoorCommissionAmountColumn"
            '
            'rowOutdoorTaxAmountColumn
            '
            Me.rowOutdoorTaxAmountColumn.Name = "rowOutdoorTaxAmountColumn"
            Me.rowOutdoorTaxAmountColumn.Properties.Caption = "Tax Amount"
            Me.rowOutdoorTaxAmountColumn.Properties.FieldName = "OutdoorTaxAmountColumn"
            '
            'rowOutdoorBillAmountColumn
            '
            Me.rowOutdoorBillAmountColumn.Name = "rowOutdoorBillAmountColumn"
            Me.rowOutdoorBillAmountColumn.Properties.Caption = "Bill Amount"
            Me.rowOutdoorBillAmountColumn.Properties.FieldName = "OutdoorBillAmountColumn"
            '
            'rowOutdoorPriorBillAmountColumn
            '
            Me.rowOutdoorPriorBillAmountColumn.Name = "rowOutdoorPriorBillAmountColumn"
            Me.rowOutdoorPriorBillAmountColumn.Properties.Caption = "Prior Bill Amount"
            Me.rowOutdoorPriorBillAmountColumn.Properties.FieldName = "OutdoorPriorBillAmountColumn"
            '
            'rowOutdoorBilledToDateAmountColumn
            '
            Me.rowOutdoorBilledToDateAmountColumn.Name = "rowOutdoorBilledToDateAmountColumn"
            Me.rowOutdoorBilledToDateAmountColumn.Properties.Caption = "Billed To Date Amount"
            Me.rowOutdoorBilledToDateAmountColumn.Properties.FieldName = "OutdoorBilledToDateAmountColumn"
            '
            'category46
            '
            Me.category46.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowOutdoorShowZeroLineAmounts, Me.rowOutdoorSortLinesBy, Me.rowOutdoorLineNumberColumn, Me.rowOutdoorHeadlineColumn, Me.rowOutdoorInsertDatesColumn, Me.rowOutdoorEndDateColumn, Me.rowOutdoorCopyAreaColumn, Me.rowOutdoorAdNumberColumn, Me.rowOutdoorLocationColumn, Me.rowOutdoorOutdoorTypeColumn, Me.rowOutdoorSizeColumn, Me.rowOutdoorCloseDateColumn, Me.rowOutdoorJobComponentNumberColumn, Me.rowOutdoorJobDescriptionColumn, Me.rowOutdoorComponentDescriptionColumn, Me.rowOutdoorExtraChargesColumn})
            Me.category46.Name = "category46"
            Me.category46.Properties.Caption = "Order/Line Options"
            '
            'rowOutdoorShowZeroLineAmounts
            '
            Me.rowOutdoorShowZeroLineAmounts.Name = "rowOutdoorShowZeroLineAmounts"
            Me.rowOutdoorShowZeroLineAmounts.Properties.Caption = "Show Zero Line Amounts"
            Me.rowOutdoorShowZeroLineAmounts.Properties.FieldName = "OutdoorShowZeroLineAmounts"
            '
            'rowOutdoorSortLinesBy
            '
            Me.rowOutdoorSortLinesBy.Name = "rowOutdoorSortLinesBy"
            Me.rowOutdoorSortLinesBy.Properties.Caption = "Sort Lines By"
            Me.rowOutdoorSortLinesBy.Properties.FieldName = "OutdoorSortLinesBy"
            '
            'rowOutdoorLineNumberColumn
            '
            Me.rowOutdoorLineNumberColumn.Name = "rowOutdoorLineNumberColumn"
            Me.rowOutdoorLineNumberColumn.Properties.Caption = "Line Number"
            Me.rowOutdoorLineNumberColumn.Properties.FieldName = "OutdoorLineNumberColumn"
            '
            'rowOutdoorHeadlineColumn
            '
            Me.rowOutdoorHeadlineColumn.Name = "rowOutdoorHeadlineColumn"
            Me.rowOutdoorHeadlineColumn.Properties.Caption = "Headline"
            Me.rowOutdoorHeadlineColumn.Properties.FieldName = "OutdoorHeadlineColumn"
            '
            'rowOutdoorInsertDatesColumn
            '
            Me.rowOutdoorInsertDatesColumn.Name = "rowOutdoorInsertDatesColumn"
            Me.rowOutdoorInsertDatesColumn.Properties.Caption = "Start Date"
            Me.rowOutdoorInsertDatesColumn.Properties.FieldName = "OutdoorInsertDatesColumn"
            '
            'rowOutdoorEndDateColumn
            '
            Me.rowOutdoorEndDateColumn.Name = "rowOutdoorEndDateColumn"
            Me.rowOutdoorEndDateColumn.Properties.Caption = "End Date"
            Me.rowOutdoorEndDateColumn.Properties.FieldName = "OutdoorEndDateColumn"
            '
            'rowOutdoorCopyAreaColumn
            '
            Me.rowOutdoorCopyAreaColumn.Name = "rowOutdoorCopyAreaColumn"
            Me.rowOutdoorCopyAreaColumn.Properties.Caption = "Copy Area"
            Me.rowOutdoorCopyAreaColumn.Properties.FieldName = "OutdoorCopyAreaColumn"
            '
            'rowOutdoorAdNumberColumn
            '
            Me.rowOutdoorAdNumberColumn.Name = "rowOutdoorAdNumberColumn"
            Me.rowOutdoorAdNumberColumn.Properties.Caption = "Ad Number"
            Me.rowOutdoorAdNumberColumn.Properties.FieldName = "OutdoorAdNumberColumn"
            '
            'rowOutdoorLocationColumn
            '
            Me.rowOutdoorLocationColumn.Name = "rowOutdoorLocationColumn"
            Me.rowOutdoorLocationColumn.Properties.Caption = "Location"
            Me.rowOutdoorLocationColumn.Properties.FieldName = "OutdoorLocationColumn"
            '
            'rowOutdoorOutdoorTypeColumn
            '
            Me.rowOutdoorOutdoorTypeColumn.Name = "rowOutdoorOutdoorTypeColumn"
            Me.rowOutdoorOutdoorTypeColumn.Properties.Caption = "Type"
            Me.rowOutdoorOutdoorTypeColumn.Properties.FieldName = "OutdoorOutdoorTypeColumn"
            '
            'rowOutdoorSizeColumn
            '
            Me.rowOutdoorSizeColumn.Name = "rowOutdoorSizeColumn"
            Me.rowOutdoorSizeColumn.Properties.Caption = "Size"
            Me.rowOutdoorSizeColumn.Properties.FieldName = "OutdoorSizeColumn"
            '
            'rowOutdoorCloseDateColumn
            '
            Me.rowOutdoorCloseDateColumn.Name = "rowOutdoorCloseDateColumn"
            Me.rowOutdoorCloseDateColumn.Properties.Caption = "Close Date"
            Me.rowOutdoorCloseDateColumn.Properties.FieldName = "OutdoorCloseDateColumn"
            '
            'rowOutdoorJobComponentNumberColumn
            '
            Me.rowOutdoorJobComponentNumberColumn.Name = "rowOutdoorJobComponentNumberColumn"
            Me.rowOutdoorJobComponentNumberColumn.Properties.Caption = "Job Component Number"
            Me.rowOutdoorJobComponentNumberColumn.Properties.FieldName = "OutdoorJobComponentNumberColumn"
            '
            'rowOutdoorJobDescriptionColumn
            '
            Me.rowOutdoorJobDescriptionColumn.Name = "rowOutdoorJobDescriptionColumn"
            Me.rowOutdoorJobDescriptionColumn.Properties.Caption = "Job Description"
            Me.rowOutdoorJobDescriptionColumn.Properties.FieldName = "OutdoorJobDescriptionColumn"
            '
            'rowOutdoorComponentDescriptionColumn
            '
            Me.rowOutdoorComponentDescriptionColumn.Name = "rowOutdoorComponentDescriptionColumn"
            Me.rowOutdoorComponentDescriptionColumn.Properties.Caption = "Component Description"
            Me.rowOutdoorComponentDescriptionColumn.Properties.FieldName = "OutdoorComponentDescriptionColumn"
            '
            'rowOutdoorExtraChargesColumn
            '
            Me.rowOutdoorExtraChargesColumn.Name = "rowOutdoorExtraChargesColumn"
            Me.rowOutdoorExtraChargesColumn.Properties.Caption = "Extra Charges"
            Me.rowOutdoorExtraChargesColumn.Properties.FieldName = "OutdoorExtraChargesColumn"
            '
            'category47
            '
            Me.category47.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowOutdoorShowCommissionSeparately, Me.rowOutdoorShowRebateSeparately, Me.rowOutdoorShowTaxSeparately, Me.rowOutdoorShowBillingHistory})
            Me.category47.Name = "category47"
            Me.category47.Properties.Caption = "Footer Options"
            '
            'rowOutdoorShowCommissionSeparately
            '
            Me.rowOutdoorShowCommissionSeparately.Name = "rowOutdoorShowCommissionSeparately"
            Me.rowOutdoorShowCommissionSeparately.Properties.Caption = "Show Commission Separately"
            Me.rowOutdoorShowCommissionSeparately.Properties.FieldName = "OutdoorShowCommissionSeparately"
            '
            'rowOutdoorShowRebateSeparately
            '
            Me.rowOutdoorShowRebateSeparately.Name = "rowOutdoorShowRebateSeparately"
            Me.rowOutdoorShowRebateSeparately.Properties.Caption = "Show Rebate Separately"
            Me.rowOutdoorShowRebateSeparately.Properties.FieldName = "OutdoorShowRebateSeparately"
            '
            'rowOutdoorShowTaxSeparately
            '
            Me.rowOutdoorShowTaxSeparately.Name = "rowOutdoorShowTaxSeparately"
            Me.rowOutdoorShowTaxSeparately.Properties.Caption = "Show Tax Separately"
            Me.rowOutdoorShowTaxSeparately.Properties.FieldName = "OutdoorShowTaxSeparately"
            '
            'rowOutdoorShowBillingHistory
            '
            Me.rowOutdoorShowBillingHistory.Name = "rowOutdoorShowBillingHistory"
            Me.rowOutdoorShowBillingHistory.Properties.Caption = "Show Billing History"
            Me.rowOutdoorShowBillingHistory.Properties.FieldName = "OutdoorShowBillingHistory"
            '
            'TabItemOptions_OutdoorTab
            '
            Me.TabItemOptions_OutdoorTab.AttachedControl = Me.TabControlPanelOutdoorTab_Outdoor
            Me.TabItemOptions_OutdoorTab.Name = "TabItemOptions_OutdoorTab"
            Me.TabItemOptions_OutdoorTab.Text = "Outdoor"
            '
            'TabControlPanelNewspaperTab_Newspaper
            '
            Me.TabControlPanelNewspaperTab_Newspaper.Controls.Add(Me.VerticalGridNewspaper_Settings)
            Me.TabControlPanelNewspaperTab_Newspaper.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelNewspaperTab_Newspaper.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelNewspaperTab_Newspaper.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelNewspaperTab_Newspaper.Name = "TabControlPanelNewspaperTab_Newspaper"
            Me.TabControlPanelNewspaperTab_Newspaper.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelNewspaperTab_Newspaper.Size = New System.Drawing.Size(679, 456)
            Me.TabControlPanelNewspaperTab_Newspaper.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelNewspaperTab_Newspaper.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelNewspaperTab_Newspaper.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelNewspaperTab_Newspaper.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelNewspaperTab_Newspaper.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelNewspaperTab_Newspaper.Style.GradientAngle = 90
            Me.TabControlPanelNewspaperTab_Newspaper.TabIndex = 4
            Me.TabControlPanelNewspaperTab_Newspaper.TabItem = Me.TabItemOptions_NewspaperTab
            '
            'VerticalGridNewspaper_Settings
            '
            Me.VerticalGridNewspaper_Settings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.VerticalGridNewspaper_Settings.Appearance.RowHeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            Me.VerticalGridNewspaper_Settings.Appearance.RowHeaderPanel.Options.UseFont = True
            Me.VerticalGridNewspaper_Settings.Cursor = System.Windows.Forms.Cursors.SizeWE
            Me.VerticalGridNewspaper_Settings.CustomizationFormBounds = New System.Drawing.Rectangle(1384, 433, 216, 265)
            Me.VerticalGridNewspaper_Settings.DataSource = Me.MediaInvoiceNewspaperSettingBindingSource
            Me.VerticalGridNewspaper_Settings.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView
            Me.VerticalGridNewspaper_Settings.Location = New System.Drawing.Point(4, 4)
            Me.VerticalGridNewspaper_Settings.Name = "VerticalGridNewspaper_Settings"
            Me.VerticalGridNewspaper_Settings.OptionsBehavior.RecordsMouseWheel = True
            Me.VerticalGridNewspaper_Settings.OptionsBehavior.ResizeRowHeaders = False
            Me.VerticalGridNewspaper_Settings.OptionsBehavior.UseEnterAsTab = True
            Me.VerticalGridNewspaper_Settings.Rows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowNewspaperCustomInvoiceID, Me.category25, Me.category69, Me.category28, Me.category31})
            Me.VerticalGridNewspaper_Settings.ShowButtonMode = DevExpress.XtraVerticalGrid.ShowButtonModeEnum.ShowAlways
            Me.VerticalGridNewspaper_Settings.Size = New System.Drawing.Size(671, 448)
            Me.VerticalGridNewspaper_Settings.TabIndex = 2
            Me.VerticalGridNewspaper_Settings.TreeButtonStyle = DevExpress.XtraVerticalGrid.TreeButtonStyle.TreeView
            '
            'MediaInvoiceNewspaperSettingBindingSource
            '
            Me.MediaInvoiceNewspaperSettingBindingSource.DataSource = GetType(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceNewspaperSetting)
            '
            'rowNewspaperCustomInvoiceID
            '
            Me.rowNewspaperCustomInvoiceID.Name = "rowNewspaperCustomInvoiceID"
            Me.rowNewspaperCustomInvoiceID.Properties.Caption = "Custom Invoice"
            Me.rowNewspaperCustomInvoiceID.Properties.FieldName = "NewspaperCustomInvoiceID"
            '
            'category25
            '
            Me.category25.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.category26, Me.category27, Me.category70})
            Me.category25.Name = "category25"
            Me.category25.Properties.Caption = "Header Options"
            '
            'category26
            '
            Me.category26.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowNewspaperUseInvoiceCategoryDescription, Me.rowNewspaperInvoiceTitle, Me.rowNewspaperPrintInvoiceDueDate})
            Me.category26.Name = "category26"
            Me.category26.Properties.Caption = "Title Options"
            '
            'rowNewspaperUseInvoiceCategoryDescription
            '
            Me.rowNewspaperUseInvoiceCategoryDescription.Name = "rowNewspaperUseInvoiceCategoryDescription"
            Me.rowNewspaperUseInvoiceCategoryDescription.Properties.Caption = "Use Invoice Category Description"
            Me.rowNewspaperUseInvoiceCategoryDescription.Properties.FieldName = "NewspaperUseInvoiceCategoryDescription"
            '
            'rowNewspaperInvoiceTitle
            '
            Me.rowNewspaperInvoiceTitle.Name = "rowNewspaperInvoiceTitle"
            Me.rowNewspaperInvoiceTitle.Properties.Caption = "Invoice Title"
            Me.rowNewspaperInvoiceTitle.Properties.FieldName = "NewspaperInvoiceTitle"
            '
            'rowNewspaperPrintInvoiceDueDate
            '
            Me.rowNewspaperPrintInvoiceDueDate.Name = "rowNewspaperPrintInvoiceDueDate"
            Me.rowNewspaperPrintInvoiceDueDate.Properties.Caption = "Invoice Due Date"
            Me.rowNewspaperPrintInvoiceDueDate.Properties.FieldName = "NewspaperPrintInvoiceDueDate"
            '
            'category27
            '
            Me.category27.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowNewspaperShowClientPO, Me.rowNewspaperClientPOLocation, Me.rowNewspaperShowSalesClass, Me.rowNewspaperSalesClassLocation, Me.rowNewspaperShowCampaign, Me.rowNewspaperCampaignLocation, Me.rowNewspaperShowClientReference})
            Me.category27.Name = "category27"
            Me.category27.Properties.Caption = "Include Fields"
            '
            'rowNewspaperShowClientPO
            '
            Me.rowNewspaperShowClientPO.Name = "rowNewspaperShowClientPO"
            Me.rowNewspaperShowClientPO.Properties.Caption = "Show Client PO"
            Me.rowNewspaperShowClientPO.Properties.FieldName = "NewspaperShowClientPO"
            '
            'rowNewspaperClientPOLocation
            '
            Me.rowNewspaperClientPOLocation.Name = "rowNewspaperClientPOLocation"
            Me.rowNewspaperClientPOLocation.Properties.Caption = "Client PO Location"
            Me.rowNewspaperClientPOLocation.Properties.FieldName = "NewspaperClientPOLocation"
            '
            'rowNewspaperShowSalesClass
            '
            Me.rowNewspaperShowSalesClass.Name = "rowNewspaperShowSalesClass"
            Me.rowNewspaperShowSalesClass.Properties.Caption = "Show Sales Class"
            Me.rowNewspaperShowSalesClass.Properties.FieldName = "NewspaperShowSalesClass"
            '
            'rowNewspaperSalesClassLocation
            '
            Me.rowNewspaperSalesClassLocation.Name = "rowNewspaperSalesClassLocation"
            Me.rowNewspaperSalesClassLocation.Properties.Caption = "Sales Class Location"
            Me.rowNewspaperSalesClassLocation.Properties.FieldName = "NewspaperSalesClassLocation"
            '
            'rowNewspaperShowCampaign
            '
            Me.rowNewspaperShowCampaign.Name = "rowNewspaperShowCampaign"
            Me.rowNewspaperShowCampaign.Properties.Caption = "Show Campaign"
            Me.rowNewspaperShowCampaign.Properties.FieldName = "NewspaperShowCampaign"
            '
            'rowNewspaperCampaignLocation
            '
            Me.rowNewspaperCampaignLocation.Name = "rowNewspaperCampaignLocation"
            Me.rowNewspaperCampaignLocation.Properties.Caption = "Campaign Location"
            Me.rowNewspaperCampaignLocation.Properties.FieldName = "NewspaperCampaignLocation"
            '
            'rowNewspaperShowClientReference
            '
            Me.rowNewspaperShowClientReference.Name = "rowNewspaperShowClientReference"
            Me.rowNewspaperShowClientReference.Properties.Caption = "Show Client Reference"
            Me.rowNewspaperShowClientReference.Properties.FieldName = "NewspaperShowClientReference"
            Me.rowNewspaperShowClientReference.Visible = False
            '
            'category70
            '
            Me.category70.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowNewspaperShowOrderComment, Me.rowNewspaperShowOrderHouseComment, Me.rowNewspaperShowCampaignComment})
            Me.category70.Name = "category70"
            Me.category70.Properties.Caption = "Comments"
            '
            'rowNewspaperShowOrderComment
            '
            Me.rowNewspaperShowOrderComment.Name = "rowNewspaperShowOrderComment"
            Me.rowNewspaperShowOrderComment.Properties.Caption = "Show Order Comment"
            Me.rowNewspaperShowOrderComment.Properties.FieldName = "NewspaperShowOrderComment"
            '
            'rowNewspaperShowOrderHouseComment
            '
            Me.rowNewspaperShowOrderHouseComment.Name = "rowNewspaperShowOrderHouseComment"
            Me.rowNewspaperShowOrderHouseComment.Properties.Caption = "Show Order House Comment"
            Me.rowNewspaperShowOrderHouseComment.Properties.FieldName = "NewspaperShowOrderHouseComment"
            '
            'rowNewspaperShowCampaignComment
            '
            Me.rowNewspaperShowCampaignComment.Name = "rowNewspaperShowCampaignComment"
            Me.rowNewspaperShowCampaignComment.Properties.Caption = "Show Campaign Comment"
            Me.rowNewspaperShowCampaignComment.Properties.FieldName = "NewspaperShowCampaignComment"
            '
            'category69
            '
            Me.category69.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowNewspaperHeaderGroupBy, Me.rowNewspaperShowOrderDescription, Me.rowNewspaperShowOrderSubtotals})
            Me.category69.Name = "category69"
            Me.category69.Properties.Caption = "Order Options"
            '
            'rowNewspaperHeaderGroupBy
            '
            Me.rowNewspaperHeaderGroupBy.Name = "rowNewspaperHeaderGroupBy"
            Me.rowNewspaperHeaderGroupBy.Properties.Caption = "Group Orders By"
            Me.rowNewspaperHeaderGroupBy.Properties.FieldName = "NewspaperHeaderGroupBy"
            '
            'rowNewspaperShowOrderDescription
            '
            Me.rowNewspaperShowOrderDescription.Name = "rowNewspaperShowOrderDescription"
            Me.rowNewspaperShowOrderDescription.Properties.Caption = "Show Order Description"
            Me.rowNewspaperShowOrderDescription.Properties.FieldName = "NewspaperShowOrderDescription"
            '
            'rowNewspaperShowOrderSubtotals
            '
            Me.rowNewspaperShowOrderSubtotals.Name = "rowNewspaperShowOrderSubtotals"
            Me.rowNewspaperShowOrderSubtotals.Properties.Caption = "Show Order Subtotals"
            Me.rowNewspaperShowOrderSubtotals.Properties.FieldName = "NewspaperShowOrderSubtotals"
            '
            'category28
            '
            Me.category28.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowNewspaperShowLineDetail, Me.category29, Me.category30})
            Me.category28.Name = "category28"
            Me.category28.Properties.Caption = "Detail, Sorting & Grouping"
            '
            'rowNewspaperShowLineDetail
            '
            Me.rowNewspaperShowLineDetail.Name = "rowNewspaperShowLineDetail"
            Me.rowNewspaperShowLineDetail.Properties.Caption = "Grouping Option"
            Me.rowNewspaperShowLineDetail.Properties.FieldName = "NewspaperShowLineDetail"
            '
            'category29
            '
            Me.category29.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowNewspaperOrderNumberColumn, Me.rowNewspaperVendorNameColumn, Me.rowNewspaperShowVendorCode, Me.rowNewspaperOrderMonthsColumn, Me.rowNewspaperNetAmountColumn, Me.rowNewspaperCommissionAmountColumn, Me.rowNewspaperTaxAmountColumn, Me.rowNewspaperBillAmountColumn, Me.rowNewspaperPriorBillAmountColumn, Me.rowNewspaperBilledToDateAmountColumn})
            Me.category29.Name = "category29"
            Me.category29.Properties.Caption = "Order Column Options"
            '
            'rowNewspaperOrderNumberColumn
            '
            Me.rowNewspaperOrderNumberColumn.Name = "rowNewspaperOrderNumberColumn"
            Me.rowNewspaperOrderNumberColumn.Properties.Caption = "Order Number"
            Me.rowNewspaperOrderNumberColumn.Properties.FieldName = "NewspaperOrderNumberColumn"
            '
            'rowNewspaperVendorNameColumn
            '
            Me.rowNewspaperVendorNameColumn.Name = "rowNewspaperVendorNameColumn"
            Me.rowNewspaperVendorNameColumn.Properties.Caption = "Vendor Name"
            Me.rowNewspaperVendorNameColumn.Properties.FieldName = "NewspaperVendorNameColumn"
            '
            'rowNewspaperShowVendorCode
            '
            Me.rowNewspaperShowVendorCode.Name = "rowNewspaperShowVendorCode"
            Me.rowNewspaperShowVendorCode.Properties.Caption = "Vendor Code"
            Me.rowNewspaperShowVendorCode.Properties.FieldName = "NewspaperShowVendorCode"
            '
            'rowNewspaperOrderMonthsColumn
            '
            Me.rowNewspaperOrderMonthsColumn.Name = "rowNewspaperOrderMonthsColumn"
            Me.rowNewspaperOrderMonthsColumn.Properties.Caption = "Order Months"
            Me.rowNewspaperOrderMonthsColumn.Properties.FieldName = "NewspaperOrderMonthsColumn"
            '
            'rowNewspaperNetAmountColumn
            '
            Me.rowNewspaperNetAmountColumn.Name = "rowNewspaperNetAmountColumn"
            Me.rowNewspaperNetAmountColumn.Properties.Caption = "Net Amount"
            Me.rowNewspaperNetAmountColumn.Properties.FieldName = "NewspaperNetAmountColumn"
            '
            'rowNewspaperCommissionAmountColumn
            '
            Me.rowNewspaperCommissionAmountColumn.Name = "rowNewspaperCommissionAmountColumn"
            Me.rowNewspaperCommissionAmountColumn.Properties.Caption = "Commission Amount"
            Me.rowNewspaperCommissionAmountColumn.Properties.FieldName = "NewspaperCommissionAmountColumn"
            '
            'rowNewspaperTaxAmountColumn
            '
            Me.rowNewspaperTaxAmountColumn.Name = "rowNewspaperTaxAmountColumn"
            Me.rowNewspaperTaxAmountColumn.Properties.Caption = "Tax Amount"
            Me.rowNewspaperTaxAmountColumn.Properties.FieldName = "NewspaperTaxAmountColumn"
            '
            'rowNewspaperBillAmountColumn
            '
            Me.rowNewspaperBillAmountColumn.Name = "rowNewspaperBillAmountColumn"
            Me.rowNewspaperBillAmountColumn.Properties.Caption = "Bill Amount"
            Me.rowNewspaperBillAmountColumn.Properties.FieldName = "NewspaperBillAmountColumn"
            '
            'rowNewspaperPriorBillAmountColumn
            '
            Me.rowNewspaperPriorBillAmountColumn.Name = "rowNewspaperPriorBillAmountColumn"
            Me.rowNewspaperPriorBillAmountColumn.Properties.Caption = "Prior Bill Amount"
            Me.rowNewspaperPriorBillAmountColumn.Properties.FieldName = "NewspaperPriorBillAmountColumn"
            '
            'rowNewspaperBilledToDateAmountColumn
            '
            Me.rowNewspaperBilledToDateAmountColumn.Name = "rowNewspaperBilledToDateAmountColumn"
            Me.rowNewspaperBilledToDateAmountColumn.Properties.Caption = "Billed To Date Amount"
            Me.rowNewspaperBilledToDateAmountColumn.Properties.FieldName = "NewspaperBilledToDateAmountColumn"
            '
            'category30
            '
            Me.category30.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowNewspaperShowZeroLineAmounts, Me.rowNewspaperSortLinesBy, Me.rowNewspaperLineNumberColumn, Me.rowNewspaperHeadlineColumn, Me.rowNewspaperInsertDatesColumn, Me.rowNewspaperMaterialColumn, Me.rowNewspaperAdNumberColumn, Me.rowNewspaperEditorialIssueColumn, Me.rowNewspaperSectionColumn, Me.rowNewspaperQuantityColumn, Me.rowNewspaperAdSizeColumn, Me.rowNewspaperCloseDateColumn, Me.rowNewspaperJobComponentNumberColumn, Me.rowNewspaperJobDescriptionColumn, Me.rowNewspaperComponentDescriptionColumn, Me.rowNewspaperOrderDetailCommentColumn, Me.rowNewspaperOrderHouseDetailCommentColumn, Me.rowNewspaperExtraChargesColumn})
            Me.category30.Name = "category30"
            Me.category30.Properties.Caption = "Order/Line Options"
            '
            'rowNewspaperShowZeroLineAmounts
            '
            Me.rowNewspaperShowZeroLineAmounts.Name = "rowNewspaperShowZeroLineAmounts"
            Me.rowNewspaperShowZeroLineAmounts.Properties.Caption = "Show Zero Line Amounts"
            Me.rowNewspaperShowZeroLineAmounts.Properties.FieldName = "NewspaperShowZeroLineAmounts"
            '
            'rowNewspaperSortLinesBy
            '
            Me.rowNewspaperSortLinesBy.Name = "rowNewspaperSortLinesBy"
            Me.rowNewspaperSortLinesBy.Properties.Caption = "Sort Lines By"
            Me.rowNewspaperSortLinesBy.Properties.FieldName = "NewspaperSortLinesBy"
            '
            'rowNewspaperLineNumberColumn
            '
            Me.rowNewspaperLineNumberColumn.Name = "rowNewspaperLineNumberColumn"
            Me.rowNewspaperLineNumberColumn.Properties.Caption = "Line Number"
            Me.rowNewspaperLineNumberColumn.Properties.FieldName = "NewspaperLineNumberColumn"
            '
            'rowNewspaperHeadlineColumn
            '
            Me.rowNewspaperHeadlineColumn.Name = "rowNewspaperHeadlineColumn"
            Me.rowNewspaperHeadlineColumn.Properties.Caption = "Headline"
            Me.rowNewspaperHeadlineColumn.Properties.FieldName = "NewspaperHeadlineColumn"
            '
            'rowNewspaperInsertDatesColumn
            '
            Me.rowNewspaperInsertDatesColumn.Name = "rowNewspaperInsertDatesColumn"
            Me.rowNewspaperInsertDatesColumn.Properties.Caption = "Insert Dates"
            Me.rowNewspaperInsertDatesColumn.Properties.FieldName = "NewspaperInsertDatesColumn"
            '
            'rowNewspaperMaterialColumn
            '
            Me.rowNewspaperMaterialColumn.Name = "rowNewspaperMaterialColumn"
            Me.rowNewspaperMaterialColumn.Properties.Caption = "Material"
            Me.rowNewspaperMaterialColumn.Properties.FieldName = "NewspaperMaterialColumn"
            '
            'rowNewspaperAdNumberColumn
            '
            Me.rowNewspaperAdNumberColumn.Name = "rowNewspaperAdNumberColumn"
            Me.rowNewspaperAdNumberColumn.Properties.Caption = "Ad Number"
            Me.rowNewspaperAdNumberColumn.Properties.FieldName = "NewspaperAdNumberColumn"
            '
            'rowNewspaperEditorialIssueColumn
            '
            Me.rowNewspaperEditorialIssueColumn.Name = "rowNewspaperEditorialIssueColumn"
            Me.rowNewspaperEditorialIssueColumn.Properties.Caption = "Editorial Issue"
            Me.rowNewspaperEditorialIssueColumn.Properties.FieldName = "NewspaperEditorialIssueColumn"
            '
            'rowNewspaperSectionColumn
            '
            Me.rowNewspaperSectionColumn.Name = "rowNewspaperSectionColumn"
            Me.rowNewspaperSectionColumn.Properties.Caption = "Section"
            Me.rowNewspaperSectionColumn.Properties.FieldName = "NewspaperSectionColumn"
            '
            'rowNewspaperQuantityColumn
            '
            Me.rowNewspaperQuantityColumn.Name = "rowNewspaperQuantityColumn"
            Me.rowNewspaperQuantityColumn.Properties.Caption = "Quantity"
            Me.rowNewspaperQuantityColumn.Properties.FieldName = "NewspaperQuantityColumn"
            '
            'rowNewspaperAdSizeColumn
            '
            Me.rowNewspaperAdSizeColumn.Name = "rowNewspaperAdSizeColumn"
            Me.rowNewspaperAdSizeColumn.Properties.Caption = "Ad Size"
            Me.rowNewspaperAdSizeColumn.Properties.FieldName = "NewspaperAdSizeColumn"
            '
            'rowNewspaperCloseDateColumn
            '
            Me.rowNewspaperCloseDateColumn.Name = "rowNewspaperCloseDateColumn"
            Me.rowNewspaperCloseDateColumn.Properties.Caption = "Close Date"
            Me.rowNewspaperCloseDateColumn.Properties.FieldName = "NewspaperCloseDateColumn"
            '
            'rowNewspaperJobComponentNumberColumn
            '
            Me.rowNewspaperJobComponentNumberColumn.Name = "rowNewspaperJobComponentNumberColumn"
            Me.rowNewspaperJobComponentNumberColumn.Properties.Caption = "Job Component Number"
            Me.rowNewspaperJobComponentNumberColumn.Properties.FieldName = "NewspaperJobComponentNumberColumn"
            '
            'rowNewspaperJobDescriptionColumn
            '
            Me.rowNewspaperJobDescriptionColumn.Name = "rowNewspaperJobDescriptionColumn"
            Me.rowNewspaperJobDescriptionColumn.Properties.Caption = "Job Description"
            Me.rowNewspaperJobDescriptionColumn.Properties.FieldName = "NewspaperJobDescriptionColumn"
            '
            'rowNewspaperComponentDescriptionColumn
            '
            Me.rowNewspaperComponentDescriptionColumn.Name = "rowNewspaperComponentDescriptionColumn"
            Me.rowNewspaperComponentDescriptionColumn.Properties.Caption = "Component Description"
            Me.rowNewspaperComponentDescriptionColumn.Properties.FieldName = "NewspaperComponentDescriptionColumn"
            '
            'rowNewspaperOrderDetailCommentColumn
            '
            Me.rowNewspaperOrderDetailCommentColumn.Name = "rowNewspaperOrderDetailCommentColumn"
            Me.rowNewspaperOrderDetailCommentColumn.Properties.Caption = "Order Instructions"
            Me.rowNewspaperOrderDetailCommentColumn.Properties.FieldName = "NewspaperOrderDetailCommentColumn"
            '
            'rowNewspaperOrderHouseDetailCommentColumn
            '
            Me.rowNewspaperOrderHouseDetailCommentColumn.Name = "rowNewspaperOrderHouseDetailCommentColumn"
            Me.rowNewspaperOrderHouseDetailCommentColumn.Properties.Caption = "Order House Detail Comment"
            Me.rowNewspaperOrderHouseDetailCommentColumn.Properties.FieldName = "NewspaperOrderHouseDetailCommentColumn"
            '
            'rowNewspaperExtraChargesColumn
            '
            Me.rowNewspaperExtraChargesColumn.Name = "rowNewspaperExtraChargesColumn"
            Me.rowNewspaperExtraChargesColumn.Properties.Caption = "Extra Charges"
            Me.rowNewspaperExtraChargesColumn.Properties.FieldName = "NewspaperExtraChargesColumn"
            '
            'category31
            '
            Me.category31.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowNewspaperShowCommissionSeparately, Me.rowNewspaperShowRebateSeparately, Me.rowNewspaperShowTaxSeparately, Me.rowNewspaperShowBillingHistory})
            Me.category31.Name = "category31"
            Me.category31.Properties.Caption = "Footer Options"
            '
            'rowNewspaperShowCommissionSeparately
            '
            Me.rowNewspaperShowCommissionSeparately.Name = "rowNewspaperShowCommissionSeparately"
            Me.rowNewspaperShowCommissionSeparately.Properties.Caption = "Show Commission Separately"
            Me.rowNewspaperShowCommissionSeparately.Properties.FieldName = "NewspaperShowCommissionSeparately"
            '
            'rowNewspaperShowRebateSeparately
            '
            Me.rowNewspaperShowRebateSeparately.Name = "rowNewspaperShowRebateSeparately"
            Me.rowNewspaperShowRebateSeparately.Properties.Caption = "Show Rebate Separately"
            Me.rowNewspaperShowRebateSeparately.Properties.FieldName = "NewspaperShowRebateSeparately"
            '
            'rowNewspaperShowTaxSeparately
            '
            Me.rowNewspaperShowTaxSeparately.Name = "rowNewspaperShowTaxSeparately"
            Me.rowNewspaperShowTaxSeparately.Properties.Caption = "Show Tax Separately"
            Me.rowNewspaperShowTaxSeparately.Properties.FieldName = "NewspaperShowTaxSeparately"
            '
            'rowNewspaperShowBillingHistory
            '
            Me.rowNewspaperShowBillingHistory.Name = "rowNewspaperShowBillingHistory"
            Me.rowNewspaperShowBillingHistory.Properties.Caption = "Show Billing History"
            Me.rowNewspaperShowBillingHistory.Properties.FieldName = "NewspaperShowBillingHistory"
            '
            'TabItemOptions_NewspaperTab
            '
            Me.TabItemOptions_NewspaperTab.AttachedControl = Me.TabControlPanelNewspaperTab_Newspaper
            Me.TabItemOptions_NewspaperTab.Name = "TabItemOptions_NewspaperTab"
            Me.TabItemOptions_NewspaperTab.Text = "Newspaper"
            '
            'TabControlPanelMagazineTab_Magazine
            '
            Me.TabControlPanelMagazineTab_Magazine.Controls.Add(Me.VerticalGridMagazine_Settings)
            Me.TabControlPanelMagazineTab_Magazine.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelMagazineTab_Magazine.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelMagazineTab_Magazine.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelMagazineTab_Magazine.Name = "TabControlPanelMagazineTab_Magazine"
            Me.TabControlPanelMagazineTab_Magazine.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelMagazineTab_Magazine.Size = New System.Drawing.Size(679, 456)
            Me.TabControlPanelMagazineTab_Magazine.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelMagazineTab_Magazine.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelMagazineTab_Magazine.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelMagazineTab_Magazine.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelMagazineTab_Magazine.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelMagazineTab_Magazine.Style.GradientAngle = 90
            Me.TabControlPanelMagazineTab_Magazine.TabIndex = 3
            Me.TabControlPanelMagazineTab_Magazine.TabItem = Me.TabItemOptions_MagazineTab
            '
            'VerticalGridMagazine_Settings
            '
            Me.VerticalGridMagazine_Settings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.VerticalGridMagazine_Settings.Appearance.RowHeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            Me.VerticalGridMagazine_Settings.Appearance.RowHeaderPanel.Options.UseFont = True
            Me.VerticalGridMagazine_Settings.Cursor = System.Windows.Forms.Cursors.Default
            Me.VerticalGridMagazine_Settings.CustomizationFormBounds = New System.Drawing.Rectangle(1384, 433, 216, 265)
            Me.VerticalGridMagazine_Settings.DataSource = Me.MediaInvoiceMagazineSettingBindingSource
            Me.VerticalGridMagazine_Settings.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView
            Me.VerticalGridMagazine_Settings.Location = New System.Drawing.Point(4, 4)
            Me.VerticalGridMagazine_Settings.Name = "VerticalGridMagazine_Settings"
            Me.VerticalGridMagazine_Settings.OptionsBehavior.RecordsMouseWheel = True
            Me.VerticalGridMagazine_Settings.OptionsBehavior.ResizeRowHeaders = False
            Me.VerticalGridMagazine_Settings.OptionsBehavior.UseEnterAsTab = True
            Me.VerticalGridMagazine_Settings.Rows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowMagazineCustomInvoiceID, Me.category18, Me.category68, Me.category20, Me.category23})
            Me.VerticalGridMagazine_Settings.ShowButtonMode = DevExpress.XtraVerticalGrid.ShowButtonModeEnum.ShowAlways
            Me.VerticalGridMagazine_Settings.Size = New System.Drawing.Size(671, 448)
            Me.VerticalGridMagazine_Settings.TabIndex = 2
            Me.VerticalGridMagazine_Settings.TreeButtonStyle = DevExpress.XtraVerticalGrid.TreeButtonStyle.TreeView
            '
            'MediaInvoiceMagazineSettingBindingSource
            '
            Me.MediaInvoiceMagazineSettingBindingSource.DataSource = GetType(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceMagazineSetting)
            '
            'rowMagazineCustomInvoiceID
            '
            Me.rowMagazineCustomInvoiceID.Name = "rowMagazineCustomInvoiceID"
            Me.rowMagazineCustomInvoiceID.Properties.Caption = "Custom Invoice"
            Me.rowMagazineCustomInvoiceID.Properties.FieldName = "MagazineCustomInvoiceID"
            '
            'category18
            '
            Me.category18.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.category17, Me.category19, Me.category67})
            Me.category18.Height = 17
            Me.category18.Name = "category18"
            Me.category18.Properties.Caption = "Header Options"
            '
            'category17
            '
            Me.category17.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowMagazineUseInvoiceCategoryDescription, Me.rowMagazineInvoiceTitle, Me.rowMagazinePrintInvoiceDueDate})
            Me.category17.Name = "category17"
            Me.category17.Properties.Caption = "Title Options"
            '
            'rowMagazineUseInvoiceCategoryDescription
            '
            Me.rowMagazineUseInvoiceCategoryDescription.Name = "rowMagazineUseInvoiceCategoryDescription"
            Me.rowMagazineUseInvoiceCategoryDescription.Properties.Caption = "Use Invoice Category Description"
            Me.rowMagazineUseInvoiceCategoryDescription.Properties.FieldName = "MagazineUseInvoiceCategoryDescription"
            '
            'rowMagazineInvoiceTitle
            '
            Me.rowMagazineInvoiceTitle.Name = "rowMagazineInvoiceTitle"
            Me.rowMagazineInvoiceTitle.Properties.Caption = "Invoice Title"
            Me.rowMagazineInvoiceTitle.Properties.FieldName = "MagazineInvoiceTitle"
            '
            'rowMagazinePrintInvoiceDueDate
            '
            Me.rowMagazinePrintInvoiceDueDate.Name = "rowMagazinePrintInvoiceDueDate"
            Me.rowMagazinePrintInvoiceDueDate.Properties.Caption = "Invoice Due Date"
            Me.rowMagazinePrintInvoiceDueDate.Properties.FieldName = "MagazinePrintInvoiceDueDate"
            '
            'category19
            '
            Me.category19.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowMagazineShowClientPO, Me.rowMagazineClientPOLocation, Me.rowMagazineShowSalesClass, Me.rowMagazineSalesClassLocation, Me.rowMagazineShowCampaign, Me.rowMagazineCampaignLocation, Me.rowMagazineShowClientReference})
            Me.category19.Name = "category19"
            Me.category19.Properties.Caption = "Include Fields"
            '
            'rowMagazineShowClientPO
            '
            Me.rowMagazineShowClientPO.Name = "rowMagazineShowClientPO"
            Me.rowMagazineShowClientPO.Properties.Caption = "Show Client PO"
            Me.rowMagazineShowClientPO.Properties.FieldName = "MagazineShowClientPO"
            '
            'rowMagazineClientPOLocation
            '
            Me.rowMagazineClientPOLocation.Name = "rowMagazineClientPOLocation"
            Me.rowMagazineClientPOLocation.Properties.Caption = "Client PO Location"
            Me.rowMagazineClientPOLocation.Properties.FieldName = "MagazineClientPOLocation"
            '
            'rowMagazineShowSalesClass
            '
            Me.rowMagazineShowSalesClass.Name = "rowMagazineShowSalesClass"
            Me.rowMagazineShowSalesClass.Properties.Caption = "Show Sales Class"
            Me.rowMagazineShowSalesClass.Properties.FieldName = "MagazineShowSalesClass"
            '
            'rowMagazineSalesClassLocation
            '
            Me.rowMagazineSalesClassLocation.Name = "rowMagazineSalesClassLocation"
            Me.rowMagazineSalesClassLocation.Properties.Caption = "Sales Class Location"
            Me.rowMagazineSalesClassLocation.Properties.FieldName = "MagazineSalesClassLocation"
            '
            'rowMagazineShowCampaign
            '
            Me.rowMagazineShowCampaign.Name = "rowMagazineShowCampaign"
            Me.rowMagazineShowCampaign.Properties.Caption = "Show Campaign"
            Me.rowMagazineShowCampaign.Properties.FieldName = "MagazineShowCampaign"
            '
            'rowMagazineCampaignLocation
            '
            Me.rowMagazineCampaignLocation.Name = "rowMagazineCampaignLocation"
            Me.rowMagazineCampaignLocation.Properties.Caption = "Campaign Location"
            Me.rowMagazineCampaignLocation.Properties.FieldName = "MagazineCampaignLocation"
            '
            'rowMagazineShowClientReference
            '
            Me.rowMagazineShowClientReference.Name = "rowMagazineShowClientReference"
            Me.rowMagazineShowClientReference.Properties.Caption = "Show Client Reference"
            Me.rowMagazineShowClientReference.Properties.FieldName = "MagazineShowClientReference"
            Me.rowMagazineShowClientReference.Visible = False
            '
            'category67
            '
            Me.category67.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowMagazineShowOrderComment, Me.rowMagazineShowOrderHouseComment, Me.rowMagazineShowCampaignComment})
            Me.category67.Name = "category67"
            Me.category67.Properties.Caption = "Comments"
            '
            'rowMagazineShowOrderComment
            '
            Me.rowMagazineShowOrderComment.Name = "rowMagazineShowOrderComment"
            Me.rowMagazineShowOrderComment.Properties.Caption = "Show Order Comment"
            Me.rowMagazineShowOrderComment.Properties.FieldName = "MagazineShowOrderComment"
            '
            'rowMagazineShowOrderHouseComment
            '
            Me.rowMagazineShowOrderHouseComment.Name = "rowMagazineShowOrderHouseComment"
            Me.rowMagazineShowOrderHouseComment.Properties.Caption = "Show Order House Comment"
            Me.rowMagazineShowOrderHouseComment.Properties.FieldName = "MagazineShowOrderHouseComment"
            '
            'rowMagazineShowCampaignComment
            '
            Me.rowMagazineShowCampaignComment.Name = "rowMagazineShowCampaignComment"
            Me.rowMagazineShowCampaignComment.Properties.Caption = "Show Campaign Comment"
            Me.rowMagazineShowCampaignComment.Properties.FieldName = "MagazineShowCampaignComment"
            '
            'category68
            '
            Me.category68.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowMagazineHeaderGroupBy, Me.rowMagazineShowOrderDescription, Me.rowMagazineShowOrderSubtotals})
            Me.category68.Name = "category68"
            Me.category68.Properties.Caption = "Order Options"
            '
            'rowMagazineHeaderGroupBy
            '
            Me.rowMagazineHeaderGroupBy.Name = "rowMagazineHeaderGroupBy"
            Me.rowMagazineHeaderGroupBy.Properties.Caption = "Group Orders By"
            Me.rowMagazineHeaderGroupBy.Properties.FieldName = "MagazineHeaderGroupBy"
            '
            'rowMagazineShowOrderDescription
            '
            Me.rowMagazineShowOrderDescription.Name = "rowMagazineShowOrderDescription"
            Me.rowMagazineShowOrderDescription.Properties.Caption = "Show Order Description"
            Me.rowMagazineShowOrderDescription.Properties.FieldName = "MagazineShowOrderDescription"
            '
            'rowMagazineShowOrderSubtotals
            '
            Me.rowMagazineShowOrderSubtotals.Name = "rowMagazineShowOrderSubtotals"
            Me.rowMagazineShowOrderSubtotals.Properties.Caption = "Show Order Subtotals"
            Me.rowMagazineShowOrderSubtotals.Properties.FieldName = "MagazineShowOrderSubtotals"
            '
            'category20
            '
            Me.category20.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowMagazineShowLineDetail, Me.category21, Me.category22})
            Me.category20.Name = "category20"
            Me.category20.Properties.Caption = "Detail, Sorting & Grouping"
            '
            'rowMagazineShowLineDetail
            '
            Me.rowMagazineShowLineDetail.Name = "rowMagazineShowLineDetail"
            Me.rowMagazineShowLineDetail.Properties.Caption = "Grouping Option"
            Me.rowMagazineShowLineDetail.Properties.FieldName = "MagazineShowLineDetail"
            '
            'category21
            '
            Me.category21.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowMagazineOrderNumberColumn, Me.rowMagazineVendorNameColumn, Me.rowMagazineShowVendorCode, Me.rowMagazineOrderMonthsColumn, Me.rowMagazineNetAmountColumn, Me.rowMagazineCommissionAmountColumn, Me.rowMagazineTaxAmountColumn, Me.rowMagazineBillAmountColumn, Me.rowMagazinePriorBillAmountColumn, Me.rowMagazineBilledToDateAmountColumn})
            Me.category21.Name = "category21"
            Me.category21.Properties.Caption = "Order Column Options  "
            '
            'rowMagazineOrderNumberColumn
            '
            Me.rowMagazineOrderNumberColumn.Name = "rowMagazineOrderNumberColumn"
            Me.rowMagazineOrderNumberColumn.Properties.Caption = "Order Number"
            Me.rowMagazineOrderNumberColumn.Properties.FieldName = "MagazineOrderNumberColumn"
            '
            'rowMagazineVendorNameColumn
            '
            Me.rowMagazineVendorNameColumn.Name = "rowMagazineVendorNameColumn"
            Me.rowMagazineVendorNameColumn.Properties.Caption = "Vendor Name"
            Me.rowMagazineVendorNameColumn.Properties.FieldName = "MagazineVendorNameColumn"
            '
            'rowMagazineShowVendorCode
            '
            Me.rowMagazineShowVendorCode.Name = "rowMagazineShowVendorCode"
            Me.rowMagazineShowVendorCode.Properties.Caption = "Vendor Code"
            Me.rowMagazineShowVendorCode.Properties.FieldName = "MagazineShowVendorCode"
            '
            'rowMagazineOrderMonthsColumn
            '
            Me.rowMagazineOrderMonthsColumn.Name = "rowMagazineOrderMonthsColumn"
            Me.rowMagazineOrderMonthsColumn.Properties.Caption = "Order Months"
            Me.rowMagazineOrderMonthsColumn.Properties.FieldName = "MagazineOrderMonthsColumn"
            '
            'rowMagazineNetAmountColumn
            '
            Me.rowMagazineNetAmountColumn.Name = "rowMagazineNetAmountColumn"
            Me.rowMagazineNetAmountColumn.Properties.Caption = "Net Amount"
            Me.rowMagazineNetAmountColumn.Properties.FieldName = "MagazineNetAmountColumn"
            '
            'rowMagazineCommissionAmountColumn
            '
            Me.rowMagazineCommissionAmountColumn.Name = "rowMagazineCommissionAmountColumn"
            Me.rowMagazineCommissionAmountColumn.Properties.Caption = "Commission Amount"
            Me.rowMagazineCommissionAmountColumn.Properties.FieldName = "MagazineCommissionAmountColumn"
            '
            'rowMagazineTaxAmountColumn
            '
            Me.rowMagazineTaxAmountColumn.Name = "rowMagazineTaxAmountColumn"
            Me.rowMagazineTaxAmountColumn.Properties.Caption = "Tax Amount"
            Me.rowMagazineTaxAmountColumn.Properties.FieldName = "MagazineTaxAmountColumn"
            '
            'rowMagazineBillAmountColumn
            '
            Me.rowMagazineBillAmountColumn.Name = "rowMagazineBillAmountColumn"
            Me.rowMagazineBillAmountColumn.Properties.Caption = "Bill Amount"
            Me.rowMagazineBillAmountColumn.Properties.FieldName = "MagazineBillAmountColumn"
            '
            'rowMagazinePriorBillAmountColumn
            '
            Me.rowMagazinePriorBillAmountColumn.Name = "rowMagazinePriorBillAmountColumn"
            Me.rowMagazinePriorBillAmountColumn.Properties.Caption = "Prior Bill Amount"
            Me.rowMagazinePriorBillAmountColumn.Properties.FieldName = "MagazinePriorBillAmountColumn"
            '
            'rowMagazineBilledToDateAmountColumn
            '
            Me.rowMagazineBilledToDateAmountColumn.Name = "rowMagazineBilledToDateAmountColumn"
            Me.rowMagazineBilledToDateAmountColumn.Properties.Caption = "Billed To Date Amount"
            Me.rowMagazineBilledToDateAmountColumn.Properties.FieldName = "MagazineBilledToDateAmountColumn"
            '
            'category22
            '
            Me.category22.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowMagazineShowZeroLineAmounts, Me.rowMagazineSortLinesBy, Me.rowMagazineLineNumberColumn, Me.rowMagazineHeadlineColumn, Me.rowMagazineInsertDatesColumn, Me.rowMagazineMaterialColumn, Me.rowMagazineAdNumberColumn, Me.rowMagazineEditorialIssueColumn, Me.rowMagazineAdSizeColumn, Me.rowMagazineCloseDateColumn, Me.rowMagazineJobComponentNumberColumn, Me.rowMagazineJobDescriptionColumn, Me.rowMagazineComponentDescriptionColumn, Me.rowMagazineOrderDetailCommentColumn, Me.rowMagazineOrderHouseDetailCommentColumn, Me.rowMagazineExtraChargesColumn})
            Me.category22.Name = "category22"
            Me.category22.Properties.Caption = "Order/Line Options"
            '
            'rowMagazineShowZeroLineAmounts
            '
            Me.rowMagazineShowZeroLineAmounts.Name = "rowMagazineShowZeroLineAmounts"
            Me.rowMagazineShowZeroLineAmounts.Properties.Caption = "Show Zero Line Amounts"
            Me.rowMagazineShowZeroLineAmounts.Properties.FieldName = "MagazineShowZeroLineAmounts"
            '
            'rowMagazineSortLinesBy
            '
            Me.rowMagazineSortLinesBy.Name = "rowMagazineSortLinesBy"
            Me.rowMagazineSortLinesBy.Properties.Caption = "Sort Lines By"
            Me.rowMagazineSortLinesBy.Properties.FieldName = "MagazineSortLinesBy"
            '
            'rowMagazineLineNumberColumn
            '
            Me.rowMagazineLineNumberColumn.Name = "rowMagazineLineNumberColumn"
            Me.rowMagazineLineNumberColumn.Properties.Caption = "Line Number"
            Me.rowMagazineLineNumberColumn.Properties.FieldName = "MagazineLineNumberColumn"
            '
            'rowMagazineHeadlineColumn
            '
            Me.rowMagazineHeadlineColumn.Name = "rowMagazineHeadlineColumn"
            Me.rowMagazineHeadlineColumn.Properties.Caption = "Headline"
            Me.rowMagazineHeadlineColumn.Properties.FieldName = "MagazineHeadlineColumn"
            '
            'rowMagazineInsertDatesColumn
            '
            Me.rowMagazineInsertDatesColumn.Name = "rowMagazineInsertDatesColumn"
            Me.rowMagazineInsertDatesColumn.Properties.Caption = "Insert Dates"
            Me.rowMagazineInsertDatesColumn.Properties.FieldName = "MagazineInsertDatesColumn"
            '
            'rowMagazineMaterialColumn
            '
            Me.rowMagazineMaterialColumn.Name = "rowMagazineMaterialColumn"
            Me.rowMagazineMaterialColumn.Properties.Caption = "Material"
            Me.rowMagazineMaterialColumn.Properties.FieldName = "MagazineMaterialColumn"
            '
            'rowMagazineAdNumberColumn
            '
            Me.rowMagazineAdNumberColumn.Name = "rowMagazineAdNumberColumn"
            Me.rowMagazineAdNumberColumn.Properties.Caption = "Ad Number"
            Me.rowMagazineAdNumberColumn.Properties.FieldName = "MagazineAdNumberColumn"
            '
            'rowMagazineEditorialIssueColumn
            '
            Me.rowMagazineEditorialIssueColumn.Name = "rowMagazineEditorialIssueColumn"
            Me.rowMagazineEditorialIssueColumn.Properties.Caption = "Editorial Issue"
            Me.rowMagazineEditorialIssueColumn.Properties.FieldName = "MagazineEditorialIssueColumn"
            '
            'rowMagazineAdSizeColumn
            '
            Me.rowMagazineAdSizeColumn.Name = "rowMagazineAdSizeColumn"
            Me.rowMagazineAdSizeColumn.Properties.Caption = "Ad Size"
            Me.rowMagazineAdSizeColumn.Properties.FieldName = "MagazineAdSizeColumn"
            '
            'rowMagazineCloseDateColumn
            '
            Me.rowMagazineCloseDateColumn.Name = "rowMagazineCloseDateColumn"
            Me.rowMagazineCloseDateColumn.Properties.Caption = "Close Date"
            Me.rowMagazineCloseDateColumn.Properties.FieldName = "MagazineCloseDateColumn"
            '
            'rowMagazineJobComponentNumberColumn
            '
            Me.rowMagazineJobComponentNumberColumn.Name = "rowMagazineJobComponentNumberColumn"
            Me.rowMagazineJobComponentNumberColumn.Properties.Caption = "Job Component Number"
            Me.rowMagazineJobComponentNumberColumn.Properties.FieldName = "MagazineJobComponentNumberColumn"
            '
            'rowMagazineJobDescriptionColumn
            '
            Me.rowMagazineJobDescriptionColumn.Name = "rowMagazineJobDescriptionColumn"
            Me.rowMagazineJobDescriptionColumn.Properties.Caption = "Job Description"
            Me.rowMagazineJobDescriptionColumn.Properties.FieldName = "MagazineJobDescriptionColumn"
            '
            'rowMagazineComponentDescriptionColumn
            '
            Me.rowMagazineComponentDescriptionColumn.Name = "rowMagazineComponentDescriptionColumn"
            Me.rowMagazineComponentDescriptionColumn.Properties.Caption = "Component Description"
            Me.rowMagazineComponentDescriptionColumn.Properties.FieldName = "MagazineComponentDescriptionColumn"
            '
            'rowMagazineOrderDetailCommentColumn
            '
            Me.rowMagazineOrderDetailCommentColumn.Name = "rowMagazineOrderDetailCommentColumn"
            Me.rowMagazineOrderDetailCommentColumn.Properties.Caption = "Order Instructions"
            Me.rowMagazineOrderDetailCommentColumn.Properties.FieldName = "MagazineOrderDetailCommentColumn"
            '
            'rowMagazineOrderHouseDetailCommentColumn
            '
            Me.rowMagazineOrderHouseDetailCommentColumn.Name = "rowMagazineOrderHouseDetailCommentColumn"
            Me.rowMagazineOrderHouseDetailCommentColumn.Properties.Caption = "Order House Detail Comment"
            Me.rowMagazineOrderHouseDetailCommentColumn.Properties.FieldName = "MagazineOrderHouseDetailCommentColumn"
            '
            'rowMagazineExtraChargesColumn
            '
            Me.rowMagazineExtraChargesColumn.Name = "rowMagazineExtraChargesColumn"
            Me.rowMagazineExtraChargesColumn.Properties.Caption = "Extra Charges"
            Me.rowMagazineExtraChargesColumn.Properties.FieldName = "MagazineExtraChargesColumn"
            '
            'category23
            '
            Me.category23.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowMagazineShowCommissionSeparately, Me.rowMagazineShowRebateSeparately, Me.rowMagazineShowTaxSeparately, Me.rowMagazineShowBillingHistory})
            Me.category23.Name = "category23"
            Me.category23.Properties.Caption = "Footer Options"
            '
            'rowMagazineShowCommissionSeparately
            '
            Me.rowMagazineShowCommissionSeparately.Name = "rowMagazineShowCommissionSeparately"
            Me.rowMagazineShowCommissionSeparately.Properties.Caption = "Show Commission Separately"
            Me.rowMagazineShowCommissionSeparately.Properties.FieldName = "MagazineShowCommissionSeparately"
            '
            'rowMagazineShowRebateSeparately
            '
            Me.rowMagazineShowRebateSeparately.Name = "rowMagazineShowRebateSeparately"
            Me.rowMagazineShowRebateSeparately.Properties.Caption = "Show Rebate Separately"
            Me.rowMagazineShowRebateSeparately.Properties.FieldName = "MagazineShowRebateSeparately"
            '
            'rowMagazineShowTaxSeparately
            '
            Me.rowMagazineShowTaxSeparately.Name = "rowMagazineShowTaxSeparately"
            Me.rowMagazineShowTaxSeparately.Properties.Caption = "Show Tax Separately"
            Me.rowMagazineShowTaxSeparately.Properties.FieldName = "MagazineShowTaxSeparately"
            '
            'rowMagazineShowBillingHistory
            '
            Me.rowMagazineShowBillingHistory.Name = "rowMagazineShowBillingHistory"
            Me.rowMagazineShowBillingHistory.Properties.Caption = "Show Billing History"
            Me.rowMagazineShowBillingHistory.Properties.FieldName = "MagazineShowBillingHistory"
            '
            'TabItemOptions_MagazineTab
            '
            Me.TabItemOptions_MagazineTab.AttachedControl = Me.TabControlPanelMagazineTab_Magazine
            Me.TabItemOptions_MagazineTab.Name = "TabItemOptions_MagazineTab"
            Me.TabItemOptions_MagazineTab.Text = "Magazine"
            '
            'LabelForm_FormatLabel
            '
            Me.LabelForm_FormatLabel.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_FormatLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_FormatLabel.Location = New System.Drawing.Point(12, 7)
            Me.LabelForm_FormatLabel.Name = "LabelForm_FormatLabel"
            Me.LabelForm_FormatLabel.Size = New System.Drawing.Size(51, 20)
            Me.LabelForm_FormatLabel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_FormatLabel.TabIndex = 0
            Me.LabelForm_FormatLabel.Text = "Format:"
            '
            'LabelForm_Format
            '
            Me.LabelForm_Format.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_Format.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Format.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Format.Location = New System.Drawing.Point(69, 7)
            Me.LabelForm_Format.Name = "LabelForm_Format"
            Me.LabelForm_Format.Size = New System.Drawing.Size(622, 20)
            Me.LabelForm_Format.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Format.TabIndex = 1
            '
            'rowRadioStartDateColumn
            '
            Me.rowRadioStartDateColumn.Name = "rowRadioStartDateColumn"
            Me.rowRadioStartDateColumn.Properties.Caption = "Start Date"
            Me.rowRadioStartDateColumn.Properties.FieldName = "RadioStartDateColumn"
            '
            'rowTVStartDateColumn
            '
            Me.rowTVStartDateColumn.Name = "rowTVStartDateColumn"
            Me.rowTVStartDateColumn.Properties.Caption = "Start Date"
            Me.rowTVStartDateColumn.Properties.FieldName = "TVStartDateColumn"
            '
            'InvoicePrintingOptionsDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(713, 698)
            Me.CloseButtonVisible = False
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(4)
            Me.Name = "InvoicePrintingOptionsDialog"
            Me.Text = "Invoice Printing Options"
            Me.Controls.SetChildIndex(Me.BarForm_StatusBar, 0)
            Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
            Me.Controls.SetChildIndex(Me.PanelForm_Form, 0)
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Form.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.PerformLayout()
            Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.VerticalGridProduction_Settings, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.TabControlForm_Options, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlForm_Options.ResumeLayout(False)
            Me.TabControlPanelInternetTab_Internet.ResumeLayout(False)
            CType(Me.VerticalGridInternet_Settings, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.MediaInvoiceInternetSettingBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelComboTab_Combo.ResumeLayout(False)
            CType(Me.VerticalGridCombo_Settings, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ComboInvoiceSettingBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelMediaTab_Media.ResumeLayout(False)
            CType(Me.VerticalGridMedia_Settings, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.MediaInvoiceSettingBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelProductionTab_Production.ResumeLayout(False)
            Me.TabControlPanelTVTab_TV.ResumeLayout(False)
            CType(Me.VerticalGridTV_Settings, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.MediaInvoiceTVSettingBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelRadioTab_Radio.ResumeLayout(False)
            CType(Me.VerticalGridRadio_Settings, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.MediaInvoiceRadioSettingBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelOutdoorTab_Outdoor.ResumeLayout(False)
            CType(Me.VerticalGridOutdoor_Settings, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.MediaInvoiceOutdoorSettingBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelNewspaperTab_Newspaper.ResumeLayout(False)
            CType(Me.VerticalGridNewspaper_Settings, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.MediaInvoiceNewspaperSettingBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        Me.TabControlPanelMagazineTab_Magazine.ResumeLayout(false)
        CType(Me.VerticalGridMagazine_Settings,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.MediaInvoiceMagazineSettingBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
        Private WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemActions_Save As DevComponents.DotNetBar.ButtonItem
        Private WithEvents ButtonItemActions_Cancel As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents VerticalGridProduction_Settings As AdvantageFramework.WinForm.Presentation.Controls.VerticalGrid
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents rowUseLocationPrintOptions As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowLocationCode As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents category As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowUseInvoiceCategoryDescription As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowInvoiceTitle As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents category2 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents category3 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowAddressBlockType As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowPrintDivisionName As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowPrintProductDescription As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowPrintContactAfterAddress As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents category4 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowIncludeClientReference As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowIncludeClientPO As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowIncludeAccountExecutive As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowIncludeSalesClass As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowIncludeInvoiceDueDate As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowHideComponentNumberAndDescription As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents category5 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowIncludeInvoiceComment As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowIncludeBillingApprovalComment As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowIncludeJobComment As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowIncludeJobComponentComment As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowIncludeEstimateComment As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowIncludeEstimateComponentComment As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowIncludeEstimateQuoteComment As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowIncludeEstimateRevisionComment As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowApplyExchangeRate As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowExchangeRateAmount As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents category6 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents category7 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowReportFormatType As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowSummaryLevel As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowShowEmployeeHours As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowShowQuantity As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents category8 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowGroupingOptionType As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowGroupingOptionInsideDescription As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowGroupingOptionOutsideDescription As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents category9 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowSortFunctionByType As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowPrintFunctionType As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowShowFunctionDetail As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowShowZeroFunctionAmounts As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowIndicateTaxableFunctions As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowHideFunctionTotals As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents category10 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents category11 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowTotalsShowTaxSeparately As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowTotalsShowCommissionSeparately As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowTotalsShowBillingHistory As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents category12 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowInvoiceFooterCommentType As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowInvoiceFooterComment As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowIncludeBackupReport As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents categoryBackupReportOptions As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowBackupReportColumnOption As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowBackupReportCommentOptionEmployeeTimeFunction As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowBackupReportCommentOptionAccountsPayableFunction As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowBackupReportCommentOptionIncomeOnlyFunction As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowIncludeBillingApprovalFunctionComment As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Private WithEvents RibbonBarOptions_SaveOptions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemSaveOptions_Agency As DevComponents.DotNetBar.ButtonItem
        Private WithEvents ButtonItemSaveOptions_Clients As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents TabControlForm_Options As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelProductionTab_Production As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemOptions_ProductionTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelMediaTab_Media As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents VerticalGridMedia_Settings As AdvantageFramework.WinForm.Presentation.Controls.VerticalGrid
        Friend WithEvents TabItemOptions_MediaTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents MediaInvoiceSettingBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents TabControlPanelNewspaperTab_Newspaper As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents VerticalGridNewspaper_Settings As AdvantageFramework.WinForm.Presentation.Controls.VerticalGrid
        Friend WithEvents MediaInvoiceNewspaperSettingBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents TabItemOptions_NewspaperTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelMagazineTab_Magazine As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents VerticalGridMagazine_Settings As AdvantageFramework.WinForm.Presentation.Controls.VerticalGrid
        Friend WithEvents MediaInvoiceMagazineSettingBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents TabItemOptions_MagazineTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelInternetTab_Internet As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents VerticalGridInternet_Settings As AdvantageFramework.WinForm.Presentation.Controls.VerticalGrid
        Friend WithEvents MediaInvoiceInternetSettingBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents TabItemOptions_InternetTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelOutdoorTab_Outdoor As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents VerticalGridOutdoor_Settings As AdvantageFramework.WinForm.Presentation.Controls.VerticalGrid
        Friend WithEvents MediaInvoiceOutdoorSettingBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents TabItemOptions_OutdoorTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelRadioTab_Radio As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents VerticalGridRadio_Settings As AdvantageFramework.WinForm.Presentation.Controls.VerticalGrid
        Friend WithEvents MediaInvoiceRadioSettingBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents TabItemOptions_RadioTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelTVTab_TV As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents VerticalGridTV_Settings As AdvantageFramework.WinForm.Presentation.Controls.VerticalGrid
        Friend WithEvents MediaInvoiceTVSettingBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents TabItemOptions_TVTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents rowUseLocationPrintOptions1 As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowLocationCode1 As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents category13 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents category14 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowAddressBlockType1 As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowPrintDivisionName1 As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowPrintProductDescription1 As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowPrintContactAfterAddress1 As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents category15 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowIncludeBillingComment1 As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowApplyExchangeRate1 As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowExchangeRateAmount1 As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents category16 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowInvoiceFooterCommentType1 As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowInvoiceFooterComment1 As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents category25 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents category26 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowNewspaperUseInvoiceCategoryDescription As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowNewspaperInvoiceTitle As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents category27 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowNewspaperShowOrderDescription As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowNewspaperShowClientReference As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowNewspaperShowClientPO As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowNewspaperShowOrderComment As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowNewspaperShowOrderHouseComment As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowNewspaperPrintInvoiceDueDate As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents category28 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents category29 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowNewspaperOrderNumberColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowNewspaperVendorNameColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowNewspaperShowVendorCode As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowNewspaperOrderMonthsColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowNewspaperNetAmountColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowNewspaperCommissionAmountColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowNewspaperTaxAmountColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowNewspaperBillAmountColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowNewspaperPriorBillAmountColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowNewspaperBilledToDateAmountColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents category30 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowNewspaperHeadlineColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowNewspaperInsertDatesColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowNewspaperMaterialColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowNewspaperAdNumberColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowNewspaperEditorialIssueColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowNewspaperSectionColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowNewspaperQuantityColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowNewspaperAdSizeColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowNewspaperJobComponentNumberColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowNewspaperJobDescriptionColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowNewspaperComponentDescriptionColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowNewspaperOrderDetailCommentColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowNewspaperOrderHouseDetailCommentColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowNewspaperExtraChargesColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowNewspaperShowLineDetail As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents category31 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowNewspaperShowCommissionSeparately As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowNewspaperShowRebateSeparately As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowNewspaperShowTaxSeparately As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowNewspaperShowBillingHistory As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents category33 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents category34 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowInternetUseInvoiceCategoryDescription As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowInternetInvoiceTitle As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents category35 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowInternetShowOrderDescription As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowInternetShowClientReference As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowInternetShowClientPO As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowInternetShowOrderComment As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowInternetShowOrderHouseComment As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowInternetPrintInvoiceDueDate As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents category36 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents category37 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowInternetOrderNumberColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowInternetVendorNameColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowInternetShowVendorCode As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowInternetOrderMonthsColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowInternetNetAmountColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowInternetCommissionAmountColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowInternetTaxAmountColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowInternetBillAmountColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowInternetPriorBillAmountColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowInternetBilledToDateAmountColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents category38 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowInternetHeadlineColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowInternetStartDatesColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowInternetEndDatesColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowInternetCreativeSizeColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowInternetAdNumberColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowInternetURLColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowInternetInternetTypeColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowInternetJobComponentNumberColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowInternetJobDescriptionColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowInternetComponentDescriptionColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowInternetExtraChargesColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowInternetShowLineDetail As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents category39 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowInternetShowCommissionSeparately As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowInternetShowTaxSeparately As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowInternetShowRebateSeparately As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowInternetShowBillingHistory As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents category41 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents category42 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowOutdoorUseInvoiceCategoryDescription As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowOutdoorInvoiceTitle As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents category43 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowOutdoorShowOrderDescription As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowOutdoorShowClientReference As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowOutdoorShowClientPO As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowOutdoorShowOrderComment As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowOutdoorShowOrderHouseComment As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowOutdoorPrintInvoiceDueDate As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents category44 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents category45 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowOutdoorOrderNumberColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowOutdoorVendorNameColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowOutdoorShowVendorCode As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowOutdoorOrderMonthsColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowOutdoorNetAmountColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowOutdoorCommissionAmountColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowOutdoorTaxAmountColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowOutdoorBillAmountColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowOutdoorPriorBillAmountColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowOutdoorBilledToDateAmountColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents category46 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowOutdoorHeadlineColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowOutdoorInsertDatesColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowOutdoorCopyAreaColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowOutdoorAdNumberColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowOutdoorLocationColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowOutdoorOutdoorTypeColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowOutdoorSizeColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowOutdoorJobComponentNumberColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowOutdoorJobDescriptionColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowOutdoorComponentDescriptionColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowOutdoorExtraChargesColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowOutdoorShowLineDetail As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents category47 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowOutdoorShowCommissionSeparately As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowOutdoorShowRebateSeparately As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowOutdoorShowTaxSeparately As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowOutdoorShowBillingHistory As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents category57 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents category58 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowTVUseInvoiceCategoryDescription As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowTVInvoiceTitle As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents category59 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowTVShowOrderDescription As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowTVShowClientReference As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowTVShowClientPO As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowTVShowOrderComment As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowTVShowOrderHouseComment As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowTVPrintInvoiceDueDate As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents category60 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents category61 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowTVOrderNumberColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowTVVendorNameColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowTVShowVendorCode As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowTVOrderMonthsColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowTVNetAmountColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowTVCommissionAmountColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowTVTaxAmountColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowTVBillAmountColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowTVPriorBillAmountColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowTVBilledToDateAmountColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents category62 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowTVProgramColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowTVSpotLengthColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowTVTagColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowTVStartEndTimesColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowTVNumberOfSpotsColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowTVRemarksColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowTVJobComponentNumberColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowTVJobDescriptionColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowTVComponentDescriptionColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowTVOrderDetailCommentColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowTVOrderHouseDetailCommentColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowTVExtraChargesColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowTVShowLineDetail As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents category63 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowTVShowCommissionSeparately As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowTVShowRebateSeparately As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowTVShowTaxSeparately As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowTVShowBillingHistory As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents category49 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents category50 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowRadioUseInvoiceCategoryDescription As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowRadioInvoiceTitle As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents category51 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowRadioShowOrderDescription As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowRadioShowClientReference As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowRadioShowClientPO As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowRadioShowOrderComment As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowRadioShowOrderHouseComment As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowRadioPrintInvoiceDueDate As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents category52 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents category53 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowRadioOrderNumberColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowRadioVendorNameColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowRadioShowVendorCode As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowRadioOrderMonthsColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowRadioNetAmountColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowRadioCommissionAmountColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowRadioTaxAmountColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowRadioBillAmountColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowRadioPriorBillAmountColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowRadioBilledToDateAmountColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents category54 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowRadioProgramColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowRadioSpotLengthColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowRadioTagColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowRadioStartEndTimesColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowRadioNumberOfSpotsColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowRadioRemarksColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowRadioJobComponentNumberColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowRadioJobDescriptionColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowRadioComponentDescriptionColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowRadioOrderDetailCommentColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowRadioOrderHouseDetailCommentColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowRadioExtraChargesColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowRadioShowLineDetail As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents category55 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowRadioShowCommissionSeparately As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowRadioShowRebateSeparately As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowRadioShowTaxSeparately As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowRadioShowBillingHistory As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents category18 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents category17 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowMagazineUseInvoiceCategoryDescription As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowMagazineInvoiceTitle As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents category19 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowMagazineShowOrderDescription As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowMagazineShowClientReference As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowMagazineShowClientPO As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowMagazineShowOrderComment As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowMagazineShowOrderHouseComment As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowMagazinePrintInvoiceDueDate As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents category20 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents category21 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowMagazineOrderNumberColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowMagazineVendorNameColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowMagazineShowVendorCode As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowMagazineOrderMonthsColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowMagazineNetAmountColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowMagazineCommissionAmountColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowMagazineTaxAmountColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowMagazineBillAmountColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowMagazinePriorBillAmountColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowMagazineBilledToDateAmountColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents category22 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowMagazineHeadlineColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowMagazineInsertDatesColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowMagazineMaterialColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowMagazineAdNumberColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowMagazineEditorialIssueColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowMagazineAdSizeColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowMagazineJobComponentNumberColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowMagazineJobDescriptionColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowMagazineComponentDescriptionColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowMagazineOrderDetailCommentColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowMagazineOrderHouseDetailCommentColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowMagazineExtraChargesColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowMagazineShowLineDetail As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents category23 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowMagazineShowCommissionSeparately As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowMagazineShowRebateSeparately As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowMagazineShowTaxSeparately As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowMagazineShowBillingHistory As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents LabelForm_FormatLabel As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Format As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents ButtonItemSaveOptions_Products As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents rowCustomInvoiceID As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowPrintClientName As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowClientPOLocation As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowHideJobInfo As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowShowCampaign As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowShowCampaignComment As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowShowCodes As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowTaxTotalLocation As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowPrintClientName1 As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowNewspaperShowCampaign As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowNewspaperShowCampaignComment As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowMagazineShowCampaign As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowMagazineShowCampaignComment As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowRadioShowCampaign As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowRadioShowCampaignComment As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowOutdoorShowCampaign As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowOutdoorShowCampaignComment As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowInternetShowCampaign As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowInternetShowCampaignComment As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowTVShowCampaign As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowTVShowCampaignComment As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowClientRefLocation As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowSalesClassLocation As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowCampaignLocation As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowHeaderGroupBy As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents category65 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents category1 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowIncludeEstimateFunctionComment As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowMagazineShowOrderSubtotals As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowRadioShowOrderSubtotals As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowOutdoorShowOrderSubtotals As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowInternetShowOrderSubtotals As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowTVShowOrderSubtotals As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents category66 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents row0 As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents row1 As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents row2 As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents row3 As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents row4 As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents row5 As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents row6 As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents row7 As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents row8 As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowShowCodes1 As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowContactType As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowContactType1 As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowNewspaperShowOrderSubtotals As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowMagazineClientPOLocation As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowMagazineShowSalesClass As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowMagazineSalesClassLocation As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowMagazineCampaignLocation As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents category67 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents category68 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowMagazineHeaderGroupBy As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowNewspaperClientPOLocation As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowNewspaperShowSalesClass As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowNewspaperSalesClassLocation As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowNewspaperCampaignLocation As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowNewspaperHeaderGroupBy As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowInternetClientPOLocation As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowInternetShowSalesClass As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowInternetSalesClassLocation As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowInternetCampaignLocation As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowInternetHeaderGroupBy As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowOutdoorClientPOLocation As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowOutdoorShowSalesClass As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowOutdoorSalesClassLocation As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowOutdoorCampaignLocation As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowOutdoorHeaderGroupBy As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowRadioClientPOLocation As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowRadioShowSalesClass As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowRadioSalesClassLocation As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowRadioCampaignLocation As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowRadioHeaderGroupBy As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowTVClientPOLocation As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowTVShowSalesClass As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowTVSalesClassLocation As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowTVCampaignLocation As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowTVHeaderGroupBy As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents category70 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents category69 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents category32 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents category71 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents category40 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents category48 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents category72 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents category56 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents category74 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents category73 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowMagazineSortLinesBy As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowNewspaperSortLinesBy As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowInternetSortLinesBy As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowOutdoorSortLinesBy As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowRadioSortLinesBy As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowTVSortLinesBy As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowEmployeeTimeFunctionComment As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowIncomeOnlyFunctionComment As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowAccountsPayableFunctionComment As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowMagazineLineNumberColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowNewspaperLineNumberColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowInternetLineNumberColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowOutdoorLineNumberColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowRadioLineNumberColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowTVLineNumberColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Private WithEvents ButtonItemSaveOptions_OneTime As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents TabControlPanelComboTab_Combo As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents VerticalGridCombo_Settings As WinForm.Presentation.Controls.VerticalGrid
        Friend WithEvents CategoryRow1 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowComboLocationCode As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowComboApplyExchangeRate As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowComboExchangeRateAmount As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents CategoryRow2 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowComboUseInvoiceCategoryDescription As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowComboInvoiceTitle As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents CategoryRow3 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents CategoryRow4 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowComboAddressBlockType As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowComboPrintClientName As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowComboPrintDivisionName As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowComboPrintProductDescription As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowComboPrintContactAfterAddress As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowComboContactType As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowComboShowCodes As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents TabItemOptions_ComboTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents ComboInvoiceSettingBindingSource As Windows.Forms.BindingSource
        Friend WithEvents category24 As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowComboInvoiceFooterCommentType As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowComboInvoiceFooterComment As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowComboIncludeInvoiceDueDate As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowTVShowZeroLineAmounts As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowRadioShowZeroLineAmounts As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowOutdoorShowZeroLineAmounts As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowMagazineShowZeroLineAmounts As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowNewspaperShowZeroLineAmounts As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowInternetShowZeroLineAmounts As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents ButtonItemActions_Export As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents rowMagazineCloseDateColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowTVCloseDateColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowRadioCloseDateColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowOutdoorCloseDateColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowInternetCloseDateColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowNewspaperCloseDateColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowMagazineCustomInvoiceID As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowNewspaperCustomInvoiceID As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowInternetCustomInvoiceID As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowOutdoorCustomInvoiceID As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowRadioCustomInvoiceID As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowTVCustomInvoiceID As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowOutdoorEndDateColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowBackupReportBreakupByJobComponent As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowHideExchangeRateMessage As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowHideExchangeRateMessage1 As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowInternetGuaranteedImpressionsColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowTVStartDateColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowRadioStartDateColumn As DevExpress.XtraVerticalGrid.Rows.EditorRow
    End Class

End Namespace

