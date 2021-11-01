Namespace Reporting.Presentation

	Public Class ClientPLInitialLoadingDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

		Private _ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
		Private _ShowReportOption As Boolean = False
		Private _ReportType As AdvantageFramework.Reporting.ReportTypes = ReportTypes.ClientPLGrossIncomeSummaryByClientDivisionProduct

#End Region

#Region " Properties "

		Private ReadOnly Property ParameterDictionary As Generic.Dictionary(Of String, Object)
			Get
				ParameterDictionary = _ParameterDictionary
			End Get
		End Property
		Private ReadOnly Property ReportType As AdvantageFramework.Reporting.ReportTypes
			Get
				ReportType = _ReportType
			End Get
		End Property

#End Region

#Region " Methods "

		Private Sub New(ByVal ShowReportOption As Boolean, ByVal ReportType As AdvantageFramework.Reporting.ReportTypes, ByVal ParameterDictionary As Generic.Dictionary(Of String, Object))

			' This call is required by the Windows Form Designer.
			InitializeComponent()

			' Add any initialization after the InitializeComponent() call.
			_ShowReportOption = ShowReportOption
			_ReportType = ReportType
			_ParameterDictionary = ParameterDictionary

		End Sub
        Private Sub EnableOrDisableActions()

            'RadioButtonForm_Standard.Enabled = Not _ShowReportOption
            'RadioButtonForm_AlternateDirectCost.Enabled = Not _ShowReportOption
            PanelForm_PrimaryDisplayOption.Enabled = Not _ShowReportOption
            PanelForm_DataOption.Enabled = Not _ShowReportOption
            PanelForm_CoopOptions.Enabled = Not _ShowReportOption
            ComboBox_OverheadSet.Enabled = Not _ShowReportOption

            If _ShowReportOption Then

                If ComboBoxTopSection_Report.HasASelectedValue Then

                    If CInt(ComboBoxTopSection_Report.GetSelectedValue) = AdvantageFramework.Reporting.ClientPLReportTypes.ClientPLGrossIncomeSummaryByClientDivisionProduct Then

                        CheckBoxForm_Office.Enabled = True
                        CheckBoxForm_Division.Enabled = True
                        CheckBoxForm_Product.Enabled = True

                        CheckBoxForm_Client.Enabled = False
                        CheckBoxForm_Client.Checked = True
                        CheckBoxForm_PostPeriod.Enabled = False
                        CheckBoxForm_PostPeriod.Checked = True

                        CheckBoxForm_Campaign.Enabled = False
                        CheckBoxForm_Type.Enabled = False
                        CheckBoxForm_SalesClass.Enabled = False
                        CheckBoxForm_Year.Enabled = False
                        CheckBoxForm_AccountExecutive.Enabled = False
                        CheckBoxForm_ProductUDF.Enabled = False

                        CheckBoxForm_Campaign.Checked = False
                        CheckBoxForm_Type.Checked = False
                        CheckBoxForm_SalesClass.Checked = False
                        CheckBoxForm_Year.Checked = False
                        CheckBoxForm_AccountExecutive.Checked = False
                        CheckBoxForm_ProductUDF.Checked = False

                        CheckBoxForm_ManualInvoices.Checked = True
                        CheckBoxForm_ManualInvoices.Enabled = True
                        CheckBoxForm_GLEntries.Checked = True
                        CheckBoxForm_GLEntries.Enabled = True

                        CheckBoxForm_BilledIncomeRecognized.Checked = True
                        CheckBoxForm_BilledIncomeRecognized.Enabled = True

                    ElseIf CInt(ComboBoxTopSection_Report.GetSelectedValue) = AdvantageFramework.Reporting.ClientPLReportTypes.ClientPLGrossIncomeSummaryByClientDivisionProductSalesClass Then

                        CheckBoxForm_Office.Enabled = True
                        CheckBoxForm_Division.Enabled = True
                        CheckBoxForm_Product.Enabled = True

                        CheckBoxForm_Client.Enabled = False
                        CheckBoxForm_Client.Checked = True
                        CheckBoxForm_SalesClass.Enabled = False
                        CheckBoxForm_SalesClass.Checked = True
                        CheckBoxForm_PostPeriod.Enabled = False
                        CheckBoxForm_PostPeriod.Checked = True

                        CheckBoxForm_Campaign.Enabled = False
                        CheckBoxForm_Type.Enabled = False
                        CheckBoxForm_Year.Enabled = False
                        CheckBoxForm_AccountExecutive.Enabled = False
                        CheckBoxForm_ProductUDF.Enabled = False

                        CheckBoxForm_Campaign.Checked = False
                        CheckBoxForm_Type.Checked = False
                        CheckBoxForm_Year.Checked = False
                        CheckBoxForm_AccountExecutive.Checked = False
                        CheckBoxForm_ProductUDF.Checked = False

                        CheckBoxForm_ManualInvoices.Checked = True
                        CheckBoxForm_ManualInvoices.Enabled = True
                        CheckBoxForm_GLEntries.Checked = True
                        CheckBoxForm_GLEntries.Enabled = True

                        CheckBoxForm_BilledIncomeRecognized.Checked = True
                        CheckBoxForm_BilledIncomeRecognized.Enabled = True

                    ElseIf CInt(ComboBoxTopSection_Report.GetSelectedValue) = AdvantageFramework.Reporting.ClientPLReportTypes.ClientPLGrossIncomeSummaryBySalesClassClient Then

                        CheckBoxForm_Office.Enabled = True

                        CheckBoxForm_Client.Enabled = False
                        CheckBoxForm_Client.Checked = True
                        CheckBoxForm_SalesClass.Enabled = False
                        CheckBoxForm_SalesClass.Checked = True
                        CheckBoxForm_PostPeriod.Enabled = False
                        CheckBoxForm_PostPeriod.Checked = True

                        CheckBoxForm_Division.Enabled = False
                        CheckBoxForm_Product.Enabled = False
                        CheckBoxForm_Campaign.Enabled = False
                        CheckBoxForm_Type.Enabled = False
                        CheckBoxForm_Year.Enabled = False
                        CheckBoxForm_AccountExecutive.Enabled = False
                        CheckBoxForm_ProductUDF.Enabled = False

                        CheckBoxForm_Division.Checked = False
                        CheckBoxForm_Product.Checked = False
                        CheckBoxForm_Campaign.Checked = False
                        CheckBoxForm_Type.Checked = False
                        CheckBoxForm_Year.Checked = False
                        CheckBoxForm_AccountExecutive.Checked = False
                        CheckBoxForm_ProductUDF.Checked = False

                        CheckBoxForm_ManualInvoices.Checked = True
                        CheckBoxForm_ManualInvoices.Enabled = True
                        CheckBoxForm_GLEntries.Checked = True
                        CheckBoxForm_GLEntries.Enabled = True

                        CheckBoxForm_BilledIncomeRecognized.Checked = True
                        CheckBoxForm_BilledIncomeRecognized.Enabled = True

                    ElseIf CInt(ComboBoxTopSection_Report.GetSelectedValue) = AdvantageFramework.Reporting.ClientPLReportTypes.ClientPLGrossIncomeSummaryByClientDivisionProductPostPeriod Then

                        CheckBoxForm_Office.Enabled = True
                        CheckBoxForm_Division.Enabled = True
                        CheckBoxForm_Product.Enabled = True

                        CheckBoxForm_Client.Enabled = False
                        CheckBoxForm_Client.Checked = True
                        CheckBoxForm_PostPeriod.Enabled = False
                        CheckBoxForm_PostPeriod.Checked = True

                        CheckBoxForm_Campaign.Enabled = False
                        CheckBoxForm_Type.Enabled = False
                        CheckBoxForm_SalesClass.Enabled = False
                        CheckBoxForm_Year.Enabled = False
                        CheckBoxForm_AccountExecutive.Enabled = False
                        CheckBoxForm_ProductUDF.Enabled = False

                        CheckBoxForm_Campaign.Checked = False
                        CheckBoxForm_Type.Checked = False
                        CheckBoxForm_SalesClass.Checked = False
                        CheckBoxForm_Year.Checked = False
                        CheckBoxForm_AccountExecutive.Checked = False
                        CheckBoxForm_ProductUDF.Checked = False

                        CheckBoxForm_ManualInvoices.Checked = True
                        CheckBoxForm_ManualInvoices.Enabled = True
                        CheckBoxForm_GLEntries.Checked = True
                        CheckBoxForm_GLEntries.Enabled = True

                        CheckBoxForm_BilledIncomeRecognized.Checked = True
                        CheckBoxForm_BilledIncomeRecognized.Enabled = True

                        PanelForm_PrimaryDisplayOption.Enabled = True
                        PanelForm_DataOption.Enabled = True

                        If RadioButtonPrimaryDisplayOption_OverheadFactor.Checked = True Then

                            ComboBox_OverheadSet.Enabled = False

                        Else

                            ComboBox_OverheadSet.Enabled = True

                        End If

                    ElseIf CInt(ComboBoxTopSection_Report.GetSelectedValue) = AdvantageFramework.Reporting.ClientPLReportTypes.ClientSummaryGPofBilling Then

                        CheckBoxForm_Office.Enabled = True
                        CheckBoxForm_Division.Enabled = True
                        CheckBoxForm_Product.Enabled = True

                        CheckBoxForm_Client.Enabled = False
                        CheckBoxForm_Client.Checked = True
                        CheckBoxForm_Division.Checked = True
                        CheckBoxForm_Product.Checked = True

                        CheckBoxForm_Campaign.Enabled = False
                        CheckBoxForm_Type.Enabled = False
                        CheckBoxForm_SalesClass.Enabled = False
                        CheckBoxForm_PostPeriod.Enabled = False
                        CheckBoxForm_Year.Enabled = False
                        CheckBoxForm_AccountExecutive.Enabled = False
                        CheckBoxForm_ProductUDF.Enabled = False

                        CheckBoxForm_Campaign.Checked = False
                        CheckBoxForm_Type.Checked = False
                        CheckBoxForm_SalesClass.Checked = False
                        CheckBoxForm_PostPeriod.Checked = False
                        CheckBoxForm_Year.Checked = False
                        CheckBoxForm_AccountExecutive.Checked = False
                        CheckBoxForm_ProductUDF.Checked = False

                        CheckBoxForm_ManualInvoices.Checked = True
                        CheckBoxForm_ManualInvoices.Enabled = True
                        CheckBoxForm_GLEntries.Checked = True
                        CheckBoxForm_GLEntries.Enabled = True

                        CheckBoxForm_BilledIncomeRecognized.Checked = True
                        CheckBoxForm_BilledIncomeRecognized.Enabled = True

                        PanelForm_PrimaryDisplayOption.Enabled = True
                        PanelForm_DataOption.Enabled = True
                        PanelForm_CoopOptions.Enabled = True

                        If RadioButtonPrimaryDisplayOption_OverheadFactor.Checked = True Then

                            ComboBox_OverheadSet.Enabled = False

                        Else

                            ComboBox_OverheadSet.Enabled = True

                        End If

                    ElseIf CInt(ComboBoxTopSection_Report.GetSelectedValue) = AdvantageFramework.Reporting.ClientPLReportTypes.ClientSummaryExtendedGPofGI Then

                        CheckBoxForm_Office.Enabled = True

                        CheckBoxForm_Client.Enabled = False
                        CheckBoxForm_Client.Checked = True
                        CheckBoxForm_Office.Checked = True

                        CheckBoxForm_Division.Enabled = False
                        CheckBoxForm_Product.Enabled = False
                        CheckBoxForm_Campaign.Enabled = False
                        CheckBoxForm_Type.Enabled = False
                        CheckBoxForm_SalesClass.Enabled = False
                        CheckBoxForm_PostPeriod.Enabled = False
                        CheckBoxForm_Year.Enabled = False
                        CheckBoxForm_AccountExecutive.Enabled = False
                        CheckBoxForm_ProductUDF.Enabled = False

                        CheckBoxForm_Division.Checked = False
                        CheckBoxForm_Product.Checked = False
                        CheckBoxForm_Campaign.Checked = False
                        CheckBoxForm_Type.Checked = False
                        CheckBoxForm_SalesClass.Checked = False
                        CheckBoxForm_PostPeriod.Checked = False
                        CheckBoxForm_Year.Checked = False
                        CheckBoxForm_AccountExecutive.Checked = False
                        CheckBoxForm_ProductUDF.Checked = False

                        CheckBoxForm_ManualInvoices.Checked = True
                        CheckBoxForm_ManualInvoices.Enabled = True
                        CheckBoxForm_GLEntries.Checked = True
                        CheckBoxForm_GLEntries.Enabled = True

                        CheckBoxForm_BilledIncomeRecognized.Checked = True
                        CheckBoxForm_BilledIncomeRecognized.Enabled = True

                        PanelForm_PrimaryDisplayOption.Enabled = True
                        PanelForm_DataOption.Enabled = True
                        PanelForm_CoopOptions.Enabled = True

                        If RadioButtonPrimaryDisplayOption_OverheadFactor.Checked = True Then

                            ComboBox_OverheadSet.Enabled = False

                        Else

                            ComboBox_OverheadSet.Enabled = True

                        End If

                    ElseIf CInt(ComboBoxTopSection_Report.GetSelectedValue) = AdvantageFramework.Reporting.ClientPLReportTypes.GrossIncomeSummarybyCDPSCYTDMargin Then

                        CheckBoxForm_Office.Enabled = True

                        CheckBoxForm_Client.Enabled = False
                        CheckBoxForm_Client.Checked = True
                        CheckBoxForm_SalesClass.Enabled = False
                        CheckBoxForm_SalesClass.Checked = True
                        CheckBoxForm_Office.Checked = True

                        CheckBoxForm_Division.Enabled = False
                        CheckBoxForm_Product.Enabled = False
                        CheckBoxForm_Campaign.Enabled = False
                        CheckBoxForm_Type.Enabled = False
                        CheckBoxForm_PostPeriod.Enabled = False
                        CheckBoxForm_Year.Enabled = False
                        CheckBoxForm_AccountExecutive.Enabled = False
                        CheckBoxForm_ProductUDF.Enabled = False

                        CheckBoxForm_Division.Checked = False
                        CheckBoxForm_Product.Checked = False
                        CheckBoxForm_Campaign.Checked = False
                        CheckBoxForm_Type.Checked = False
                        CheckBoxForm_PostPeriod.Checked = False
                        CheckBoxForm_Year.Checked = False
                        CheckBoxForm_AccountExecutive.Checked = False
                        CheckBoxForm_ProductUDF.Checked = False

                        CheckBoxForm_ManualInvoices.Checked = True
                        CheckBoxForm_ManualInvoices.Enabled = True
                        CheckBoxForm_GLEntries.Checked = True
                        CheckBoxForm_GLEntries.Enabled = True

                        CheckBoxForm_BilledIncomeRecognized.Checked = True
                        CheckBoxForm_BilledIncomeRecognized.Enabled = True

                        PanelForm_PrimaryDisplayOption.Enabled = False
                        PanelForm_DataOption.Enabled = False
                        PanelForm_CoopOptions.Enabled = False
                        ComboBox_OverheadSet.Enabled = False

                    ElseIf CInt(ComboBoxTopSection_Report.GetSelectedValue) = AdvantageFramework.Reporting.ClientPLReportTypes.SummaryByPeriodMediaSeparate Then

                        CheckBoxForm_Office.Enabled = True

                        CheckBoxForm_PostPeriod.Enabled = False
                        CheckBoxForm_PostPeriod.Checked = True
                        CheckBoxForm_Office.Checked = True

                        CheckBoxForm_Client.Enabled = False
                        CheckBoxForm_Division.Enabled = False
                        CheckBoxForm_Product.Enabled = False
                        CheckBoxForm_Campaign.Enabled = False
                        CheckBoxForm_Type.Enabled = False
                        CheckBoxForm_SalesClass.Enabled = False
                        CheckBoxForm_Year.Enabled = False
                        CheckBoxForm_AccountExecutive.Enabled = False
                        CheckBoxForm_ProductUDF.Enabled = False

                        CheckBoxForm_Client.Checked = False
                        CheckBoxForm_Division.Checked = False
                        CheckBoxForm_Product.Checked = False
                        CheckBoxForm_Campaign.Checked = False
                        CheckBoxForm_Type.Checked = True
                        CheckBoxForm_SalesClass.Checked = False
                        CheckBoxForm_Year.Checked = False
                        CheckBoxForm_AccountExecutive.Checked = False
                        CheckBoxForm_ProductUDF.Checked = False

                        CheckBoxForm_ManualInvoices.Checked = True
                        CheckBoxForm_ManualInvoices.Enabled = True
                        CheckBoxForm_GLEntries.Checked = True
                        CheckBoxForm_GLEntries.Enabled = True

                        CheckBoxForm_BilledIncomeRecognized.Checked = True
                        CheckBoxForm_BilledIncomeRecognized.Enabled = True

                        PanelForm_PrimaryDisplayOption.Enabled = False
                        PanelForm_DataOption.Enabled = False
                        PanelForm_CoopOptions.Enabled = False
                        ComboBox_OverheadSet.Enabled = False

                    ElseIf CInt(ComboBoxTopSection_Report.GetSelectedValue) = AdvantageFramework.Reporting.ClientPLReportTypes.JobProfitabilitySummary Then

                        CheckBoxForm_Office.Checked = True
                        CheckBoxForm_Office.Enabled = False
                        CheckBoxForm_Division.Enabled = True
                        CheckBoxForm_Product.Enabled = True
                        CheckBoxForm_Division.Checked = True
                        CheckBoxForm_Product.Checked = True

                        CheckBoxForm_Client.Enabled = False
                        CheckBoxForm_Client.Checked = True
                        CheckBoxForm_SalesClass.Enabled = False
                        CheckBoxForm_SalesClass.Checked = False
                        CheckBoxForm_PostPeriod.Enabled = False
                        CheckBoxForm_PostPeriod.Checked = False

                        CheckBoxForm_Campaign.Enabled = False
                        CheckBoxForm_Type.Enabled = False
                        CheckBoxForm_Year.Enabled = False
                        CheckBoxForm_AccountExecutive.Enabled = False
                        CheckBoxForm_ProductUDF.Enabled = False

                        CheckBoxForm_Campaign.Checked = False
                        CheckBoxForm_Type.Checked = True
                        CheckBoxForm_Year.Checked = False
                        CheckBoxForm_AccountExecutive.Checked = True
                        CheckBoxForm_ProductUDF.Checked = False

                        CheckBoxForm_ManualInvoices.Checked = False
                        CheckBoxForm_ManualInvoices.Enabled = False
                        CheckBoxForm_GLEntries.Checked = False
                        CheckBoxForm_GLEntries.Enabled = False

                        CheckBoxForm_BilledIncomeRecognized.Checked = True
                        CheckBoxForm_BilledIncomeRecognized.Enabled = True

                        PanelForm_PrimaryDisplayOption.Enabled = False
                        PanelForm_DataOption.Enabled = True
                        PanelForm_CoopOptions.Enabled = True
                        ComboBox_OverheadSet.Enabled = False

                        RadioButtonForm_Standard.Enabled = True
                        RadioButtonForm_AlternateDirectCost.Enabled = True

                    ElseIf CInt(ComboBoxTopSection_Report.GetSelectedValue) = AdvantageFramework.Reporting.ClientPLReportTypes.JobProfitabilityDetail Then

                        CheckBoxForm_Office.Checked = True
                        CheckBoxForm_Office.Enabled = False
                        CheckBoxForm_Division.Enabled = True
                        CheckBoxForm_Product.Enabled = True
                        CheckBoxForm_Division.Checked = True
                        CheckBoxForm_Product.Checked = True

                        CheckBoxForm_Client.Enabled = False
                        CheckBoxForm_Client.Checked = True
                        CheckBoxForm_SalesClass.Enabled = False
                        CheckBoxForm_SalesClass.Checked = False
                        CheckBoxForm_PostPeriod.Enabled = False
                        CheckBoxForm_PostPeriod.Checked = False

                        CheckBoxForm_Campaign.Enabled = False
                        CheckBoxForm_Type.Enabled = False
                        CheckBoxForm_Year.Enabled = False
                        CheckBoxForm_AccountExecutive.Enabled = False
                        CheckBoxForm_ProductUDF.Enabled = False

                        CheckBoxForm_Campaign.Checked = False
                        CheckBoxForm_Type.Checked = True
                        CheckBoxForm_Year.Checked = False
                        CheckBoxForm_AccountExecutive.Checked = True
                        CheckBoxForm_ProductUDF.Checked = False

                        CheckBoxForm_ManualInvoices.Checked = False
                        CheckBoxForm_ManualInvoices.Enabled = False
                        CheckBoxForm_GLEntries.Checked = False
                        CheckBoxForm_GLEntries.Enabled = False

                        CheckBoxForm_BilledIncomeRecognized.Checked = True
                        CheckBoxForm_BilledIncomeRecognized.Enabled = True

                        PanelForm_PrimaryDisplayOption.Enabled = False
                        PanelForm_DataOption.Enabled = True
                        PanelForm_CoopOptions.Enabled = True
                        ComboBox_OverheadSet.Enabled = False

                        RadioButtonForm_Standard.Enabled = True
                        RadioButtonForm_AlternateDirectCost.Enabled = True

                    ElseIf CInt(ComboBoxTopSection_Report.GetSelectedValue) = AdvantageFramework.Reporting.ClientPLReportTypes.GrossIncomeSummarybyClientSCYTDBudget Then

                        CheckBoxForm_Office.Enabled = True

                        CheckBoxForm_Client.Enabled = False
                        CheckBoxForm_Client.Checked = True
                        CheckBoxForm_SalesClass.Enabled = False
                        CheckBoxForm_SalesClass.Checked = True
                        CheckBoxForm_Office.Checked = False

                        CheckBoxForm_Division.Enabled = True
                        CheckBoxForm_Product.Enabled = True
                        CheckBoxForm_Campaign.Enabled = False
                        CheckBoxForm_Type.Enabled = False
                        CheckBoxForm_PostPeriod.Enabled = False
                        CheckBoxForm_Year.Enabled = False
                        CheckBoxForm_AccountExecutive.Enabled = False
                        CheckBoxForm_ProductUDF.Enabled = False

                        CheckBoxForm_Division.Checked = False
                        CheckBoxForm_Product.Checked = False
                        CheckBoxForm_Campaign.Checked = False
                        CheckBoxForm_Type.Checked = False
                        CheckBoxForm_PostPeriod.Checked = False
                        CheckBoxForm_Year.Checked = False
                        CheckBoxForm_AccountExecutive.Checked = False
                        CheckBoxForm_ProductUDF.Checked = False

                        CheckBoxForm_ManualInvoices.Checked = True
                        CheckBoxForm_ManualInvoices.Enabled = True
                        CheckBoxForm_GLEntries.Checked = True
                        CheckBoxForm_GLEntries.Enabled = True

                        CheckBoxForm_BilledIncomeRecognized.Checked = True
                        CheckBoxForm_BilledIncomeRecognized.Enabled = True

                        PanelForm_PrimaryDisplayOption.Enabled = False
                        PanelForm_DataOption.Enabled = False
                        PanelForm_CoopOptions.Enabled = True
                        ComboBox_OverheadSet.Enabled = False

                    ElseIf CInt(ComboBoxTopSection_Report.GetSelectedValue) = AdvantageFramework.Reporting.ClientPLReportTypes.ClientSummaryGPofTimeIncAndHourlyRate Then

                        CheckBoxForm_Office.Enabled = True

                        CheckBoxForm_Client.Enabled = False
                        CheckBoxForm_Client.Checked = True
                        CheckBoxForm_SalesClass.Enabled = False
                        CheckBoxForm_SalesClass.Checked = False
                        CheckBoxForm_Office.Checked = False

                        CheckBoxForm_Division.Enabled = True
                        CheckBoxForm_Product.Enabled = True
                        CheckBoxForm_Campaign.Enabled = False
                        CheckBoxForm_Type.Enabled = False
                        CheckBoxForm_PostPeriod.Enabled = False
                        CheckBoxForm_Year.Enabled = False
                        CheckBoxForm_AccountExecutive.Enabled = False
                        CheckBoxForm_ProductUDF.Enabled = False

                        CheckBoxForm_Division.Checked = False
                        CheckBoxForm_Product.Checked = False
                        CheckBoxForm_Campaign.Checked = False
                        CheckBoxForm_Type.Checked = False
                        CheckBoxForm_PostPeriod.Checked = False
                        CheckBoxForm_Year.Checked = False
                        CheckBoxForm_AccountExecutive.Checked = False
                        CheckBoxForm_ProductUDF.Checked = False

                        CheckBoxForm_ManualInvoices.Checked = True
                        CheckBoxForm_ManualInvoices.Enabled = True
                        CheckBoxForm_GLEntries.Checked = True
                        CheckBoxForm_GLEntries.Enabled = True

                        CheckBoxForm_BilledIncomeRecognized.Checked = True
                        CheckBoxForm_BilledIncomeRecognized.Enabled = True

                        PanelForm_PrimaryDisplayOption.Enabled = True
                        PanelForm_DataOption.Enabled = True
                        PanelForm_CoopOptions.Enabled = True
                        ComboBox_OverheadSet.Enabled = True

                    ElseIf CInt(ComboBoxTopSection_Report.GetSelectedValue) = AdvantageFramework.Reporting.ClientPLReportTypes.GrossIncomeSummarybyClientYTDBudget Then

                        CheckBoxForm_Office.Enabled = True

                        CheckBoxForm_Client.Enabled = False
                        CheckBoxForm_Client.Checked = True
                        CheckBoxForm_SalesClass.Enabled = False
                        CheckBoxForm_SalesClass.Checked = False
                        CheckBoxForm_Office.Checked = False

                        CheckBoxForm_Division.Enabled = True
                        CheckBoxForm_Product.Enabled = True
                        CheckBoxForm_Campaign.Enabled = False
                        CheckBoxForm_Type.Enabled = False
                        CheckBoxForm_PostPeriod.Enabled = False
                        CheckBoxForm_Year.Enabled = False
                        CheckBoxForm_AccountExecutive.Enabled = False
                        CheckBoxForm_ProductUDF.Enabled = False

                        CheckBoxForm_Division.Checked = False
                        CheckBoxForm_Product.Checked = False
                        CheckBoxForm_Campaign.Checked = False
                        CheckBoxForm_Type.Checked = False
                        CheckBoxForm_PostPeriod.Checked = False
                        CheckBoxForm_Year.Checked = False
                        CheckBoxForm_AccountExecutive.Checked = False
                        CheckBoxForm_ProductUDF.Checked = False

                        CheckBoxForm_ManualInvoices.Checked = True
                        CheckBoxForm_ManualInvoices.Enabled = True
                        CheckBoxForm_GLEntries.Checked = True
                        CheckBoxForm_GLEntries.Enabled = True

                        CheckBoxForm_BilledIncomeRecognized.Checked = True
                        CheckBoxForm_BilledIncomeRecognized.Enabled = True

                        PanelForm_PrimaryDisplayOption.Enabled = False
                        PanelForm_DataOption.Enabled = False
                        PanelForm_CoopOptions.Enabled = True
                        ComboBox_OverheadSet.Enabled = False

                    ElseIf CInt(ComboBoxTopSection_Report.GetSelectedValue) = AdvantageFramework.Reporting.ClientPLReportTypes.GrossIncomebyClient12PeriodWtihBudget Then

                        CheckBoxForm_Office.Enabled = True

                        CheckBoxForm_Client.Enabled = False
                        CheckBoxForm_Client.Checked = True
                        CheckBoxForm_SalesClass.Enabled = False
                        CheckBoxForm_SalesClass.Checked = False
                        CheckBoxForm_Office.Checked = False

                        CheckBoxForm_Division.Enabled = True
                        CheckBoxForm_Product.Enabled = True
                        CheckBoxForm_Campaign.Enabled = False
                        CheckBoxForm_Type.Enabled = False
                        CheckBoxForm_PostPeriod.Enabled = False
                        CheckBoxForm_Year.Enabled = False
                        CheckBoxForm_AccountExecutive.Enabled = False
                        CheckBoxForm_ProductUDF.Enabled = False

                        CheckBoxForm_Division.Checked = False
                        CheckBoxForm_Product.Checked = False
                        CheckBoxForm_Campaign.Checked = False
                        CheckBoxForm_Type.Checked = False
                        CheckBoxForm_PostPeriod.Checked = True
                        CheckBoxForm_Year.Checked = False
                        CheckBoxForm_AccountExecutive.Checked = False
                        CheckBoxForm_ProductUDF.Checked = False

                        CheckBoxForm_ManualInvoices.Checked = True
                        CheckBoxForm_ManualInvoices.Enabled = True
                        CheckBoxForm_GLEntries.Checked = True
                        CheckBoxForm_GLEntries.Enabled = True

                        CheckBoxForm_BilledIncomeRecognized.Checked = True
                        CheckBoxForm_BilledIncomeRecognized.Enabled = True

                        PanelForm_PrimaryDisplayOption.Enabled = False
                        PanelForm_DataOption.Enabled = False
                        PanelForm_CoopOptions.Enabled = True
                        ComboBox_OverheadSet.Enabled = False

                    ElseIf CInt(ComboBoxTopSection_Report.GetSelectedValue) = AdvantageFramework.Reporting.ClientPLReportTypes.GrossIncomeSummarybyClientSCCurrentYTDBudget Then

                        CheckBoxForm_Office.Enabled = True

                        CheckBoxForm_Client.Enabled = False
                        CheckBoxForm_Client.Checked = True
                        CheckBoxForm_SalesClass.Enabled = False
                        CheckBoxForm_SalesClass.Checked = True
                        CheckBoxForm_Office.Checked = False

                        CheckBoxForm_Division.Enabled = True
                        CheckBoxForm_Product.Enabled = True
                        CheckBoxForm_Campaign.Enabled = False
                        CheckBoxForm_Type.Enabled = False
                        CheckBoxForm_PostPeriod.Enabled = False
                        CheckBoxForm_Year.Enabled = False
                        CheckBoxForm_AccountExecutive.Enabled = False
                        CheckBoxForm_ProductUDF.Enabled = False

                        CheckBoxForm_Division.Checked = False
                        CheckBoxForm_Product.Checked = False
                        CheckBoxForm_Campaign.Checked = False
                        CheckBoxForm_Type.Checked = False
                        CheckBoxForm_PostPeriod.Checked = True
                        CheckBoxForm_Year.Checked = False
                        CheckBoxForm_AccountExecutive.Checked = False
                        CheckBoxForm_ProductUDF.Checked = False

                        CheckBoxForm_ManualInvoices.Checked = True
                        CheckBoxForm_ManualInvoices.Enabled = True
                        CheckBoxForm_GLEntries.Checked = True
                        CheckBoxForm_GLEntries.Enabled = True

                        CheckBoxForm_BilledIncomeRecognized.Checked = True
                        CheckBoxForm_BilledIncomeRecognized.Enabled = True

                        PanelForm_PrimaryDisplayOption.Enabled = False
                        PanelForm_DataOption.Enabled = False
                        PanelForm_CoopOptions.Enabled = True
                        ComboBox_OverheadSet.Enabled = False

                    ElseIf CInt(ComboBoxTopSection_Report.GetSelectedValue) = AdvantageFramework.Reporting.ClientPLReportTypes.SummaryByClientwithBudgetIncomeCostsHours Then

                        CheckBoxForm_Office.Enabled = True

                        CheckBoxForm_Client.Enabled = False
                        CheckBoxForm_Client.Checked = True
                        CheckBoxForm_SalesClass.Enabled = False
                        CheckBoxForm_SalesClass.Checked = False
                        CheckBoxForm_Office.Checked = False

                        CheckBoxForm_Division.Enabled = True
                        CheckBoxForm_Product.Enabled = True
                        CheckBoxForm_Campaign.Enabled = False
                        CheckBoxForm_Type.Enabled = False
                        CheckBoxForm_PostPeriod.Enabled = False
                        CheckBoxForm_Year.Enabled = False
                        CheckBoxForm_AccountExecutive.Enabled = False
                        CheckBoxForm_ProductUDF.Enabled = False

                        CheckBoxForm_Division.Checked = False
                        CheckBoxForm_Product.Checked = False
                        CheckBoxForm_Campaign.Checked = False
                        CheckBoxForm_Type.Checked = False
                        CheckBoxForm_PostPeriod.Checked = True
                        CheckBoxForm_Year.Checked = False
                        CheckBoxForm_AccountExecutive.Checked = False
                        CheckBoxForm_ProductUDF.Checked = False

                        CheckBoxForm_ManualInvoices.Checked = True
                        CheckBoxForm_ManualInvoices.Enabled = True
                        CheckBoxForm_GLEntries.Checked = True
                        CheckBoxForm_GLEntries.Enabled = True

                        CheckBoxForm_BilledIncomeRecognized.Checked = True
                        CheckBoxForm_BilledIncomeRecognized.Enabled = True

                        PanelForm_PrimaryDisplayOption.Enabled = True
                        PanelForm_DataOption.Enabled = True
                        PanelForm_CoopOptions.Enabled = True
                        ComboBox_OverheadSet.Enabled = True

                    ElseIf CInt(ComboBoxTopSection_Report.GetSelectedValue) = AdvantageFramework.Reporting.ClientPLReportTypes.SummaryByClientSalesClassCurrentYTDBillingIncome Then

                        CheckBoxForm_Office.Enabled = True

                        CheckBoxForm_Client.Enabled = False
                        CheckBoxForm_Client.Checked = True
                        CheckBoxForm_SalesClass.Enabled = False
                        CheckBoxForm_SalesClass.Checked = True
                        CheckBoxForm_Office.Checked = False

                        CheckBoxForm_Division.Enabled = True
                        CheckBoxForm_Product.Enabled = True
                        CheckBoxForm_Campaign.Enabled = False
                        CheckBoxForm_Type.Enabled = False
                        CheckBoxForm_PostPeriod.Enabled = False
                        CheckBoxForm_Year.Enabled = False
                        CheckBoxForm_AccountExecutive.Enabled = False
                        CheckBoxForm_ProductUDF.Enabled = False

                        CheckBoxForm_Division.Checked = False
                        CheckBoxForm_Product.Checked = False
                        CheckBoxForm_Campaign.Checked = False
                        CheckBoxForm_Type.Checked = False
                        CheckBoxForm_PostPeriod.Checked = True
                        CheckBoxForm_Year.Checked = False
                        CheckBoxForm_AccountExecutive.Checked = False
                        CheckBoxForm_ProductUDF.Checked = False

                        CheckBoxForm_ManualInvoices.Checked = True
                        CheckBoxForm_ManualInvoices.Enabled = True
                        CheckBoxForm_GLEntries.Checked = True
                        CheckBoxForm_GLEntries.Enabled = True

                        CheckBoxForm_BilledIncomeRecognized.Checked = True
                        CheckBoxForm_BilledIncomeRecognized.Enabled = True

                        PanelForm_PrimaryDisplayOption.Enabled = False
                        PanelForm_DataOption.Enabled = False
                        PanelForm_CoopOptions.Enabled = True
                        ComboBox_OverheadSet.Enabled = False

                    ElseIf CInt(ComboBoxTopSection_Report.GetSelectedValue) = AdvantageFramework.Reporting.ClientPLReportTypes.GrossBillingByClient12PeriodWithBudget Then

                        CheckBoxForm_Office.Enabled = True

                        CheckBoxForm_Client.Enabled = False
                        CheckBoxForm_Client.Checked = True
                        CheckBoxForm_SalesClass.Enabled = False
                        CheckBoxForm_SalesClass.Checked = False
                        CheckBoxForm_Office.Checked = False

                        CheckBoxForm_Division.Enabled = True
                        CheckBoxForm_Product.Enabled = True
                        CheckBoxForm_Campaign.Enabled = False
                        CheckBoxForm_Type.Enabled = False
                        CheckBoxForm_PostPeriod.Enabled = False
                        CheckBoxForm_Year.Enabled = False
                        CheckBoxForm_AccountExecutive.Enabled = False
                        CheckBoxForm_ProductUDF.Enabled = False

                        CheckBoxForm_Division.Checked = False
                        CheckBoxForm_Product.Checked = False
                        CheckBoxForm_Campaign.Checked = False
                        CheckBoxForm_Type.Checked = False
                        CheckBoxForm_PostPeriod.Checked = True
                        CheckBoxForm_Year.Checked = False
                        CheckBoxForm_AccountExecutive.Checked = False
                        CheckBoxForm_ProductUDF.Checked = False

                        CheckBoxForm_ManualInvoices.Checked = True
                        CheckBoxForm_ManualInvoices.Enabled = True
                        CheckBoxForm_GLEntries.Checked = True
                        CheckBoxForm_GLEntries.Enabled = True

                        CheckBoxForm_BilledIncomeRecognized.Checked = True
                        CheckBoxForm_BilledIncomeRecognized.Enabled = True

                        PanelForm_PrimaryDisplayOption.Enabled = False
                        PanelForm_DataOption.Enabled = False
                        PanelForm_CoopOptions.Enabled = True
                        ComboBox_OverheadSet.Enabled = False

                    ElseIf CInt(ComboBoxTopSection_Report.GetSelectedValue) = AdvantageFramework.Reporting.ClientPLReportTypes.JobProfitabilitySummaryWithOverhead Then

                        CheckBoxForm_Office.Checked = False
                        CheckBoxForm_Office.Enabled = False
                        CheckBoxForm_Division.Enabled = True
                        CheckBoxForm_Product.Enabled = True
                        CheckBoxForm_Division.Checked = True
                        CheckBoxForm_Product.Checked = True

                        CheckBoxForm_Client.Enabled = False
                        CheckBoxForm_Client.Checked = True
                        CheckBoxForm_SalesClass.Enabled = False
                        CheckBoxForm_SalesClass.Checked = False
                        CheckBoxForm_PostPeriod.Enabled = False
                        CheckBoxForm_PostPeriod.Checked = False

                        CheckBoxForm_Campaign.Enabled = False
                        CheckBoxForm_Type.Enabled = False
                        CheckBoxForm_Year.Enabled = False
                        CheckBoxForm_AccountExecutive.Enabled = False
                        CheckBoxForm_ProductUDF.Enabled = False

                        CheckBoxForm_Campaign.Checked = False
                        CheckBoxForm_Type.Checked = True
                        CheckBoxForm_Year.Checked = False
                        CheckBoxForm_AccountExecutive.Checked = False
                        CheckBoxForm_ProductUDF.Checked = False

                        CheckBoxForm_ManualInvoices.Checked = False
                        CheckBoxForm_ManualInvoices.Enabled = False
                        CheckBoxForm_GLEntries.Checked = False
                        CheckBoxForm_GLEntries.Enabled = False

                        CheckBoxForm_BilledIncomeRecognized.Checked = True
                        CheckBoxForm_BilledIncomeRecognized.Enabled = True

                        PanelForm_PrimaryDisplayOption.Enabled = True
                        PanelForm_DataOption.Enabled = True
                        PanelForm_CoopOptions.Enabled = True
                        ComboBox_OverheadSet.Enabled = True

                        RadioButtonForm_Standard.Enabled = True
                        RadioButtonForm_AlternateDirectCost.Enabled = True

                    ElseIf CInt(ComboBoxTopSection_Report.GetSelectedValue) = AdvantageFramework.Reporting.ClientPLReportTypes.ClientProfitAndLossDetail Then

                        CheckBoxForm_Office.Checked = False
                        CheckBoxForm_Office.Enabled = True
                        CheckBoxForm_Division.Enabled = True
                        CheckBoxForm_Product.Enabled = True
                        CheckBoxForm_Division.Checked = False
                        CheckBoxForm_Product.Checked = False

                        CheckBoxForm_Client.Enabled = False
                        CheckBoxForm_Client.Checked = True
                        CheckBoxForm_SalesClass.Enabled = False
                        CheckBoxForm_SalesClass.Checked = True
                        CheckBoxForm_PostPeriod.Enabled = False
                        CheckBoxForm_PostPeriod.Checked = True

                        CheckBoxForm_Campaign.Enabled = False
                        CheckBoxForm_Type.Enabled = False
                        CheckBoxForm_Year.Enabled = False
                        CheckBoxForm_AccountExecutive.Enabled = False
                        CheckBoxForm_ProductUDF.Enabled = False

                        CheckBoxForm_Campaign.Checked = False
                        CheckBoxForm_Type.Checked = True
                        CheckBoxForm_Year.Checked = False
                        CheckBoxForm_AccountExecutive.Checked = False
                        CheckBoxForm_ProductUDF.Checked = False

                        CheckBoxForm_ManualInvoices.Checked = True
                        CheckBoxForm_ManualInvoices.Enabled = True
                        CheckBoxForm_GLEntries.Checked = True
                        CheckBoxForm_GLEntries.Enabled = True

                        CheckBoxForm_BilledIncomeRecognized.Checked = True
                        CheckBoxForm_BilledIncomeRecognized.Enabled = True

                        PanelForm_PrimaryDisplayOption.Enabled = True
                        PanelForm_DataOption.Enabled = True
                        PanelForm_CoopOptions.Enabled = True
                        ComboBox_OverheadSet.Enabled = True

                        RadioButtonForm_Standard.Enabled = True
                        RadioButtonForm_AlternateDirectCost.Enabled = True

                    ElseIf CInt(ComboBoxTopSection_Report.GetSelectedValue) = AdvantageFramework.Reporting.ClientPLReportTypes.ClientProfitAndLossDetailSalesClass Then

                        CheckBoxForm_Office.Checked = False
                        CheckBoxForm_Office.Enabled = False
                        CheckBoxForm_Division.Enabled = False
                        CheckBoxForm_Product.Enabled = False
                        CheckBoxForm_Division.Checked = False
                        CheckBoxForm_Product.Checked = False

                        CheckBoxForm_Client.Enabled = False
                        CheckBoxForm_Client.Checked = True
                        CheckBoxForm_SalesClass.Enabled = False
                        CheckBoxForm_SalesClass.Checked = True
                        CheckBoxForm_PostPeriod.Enabled = False
                        CheckBoxForm_PostPeriod.Checked = True

                        CheckBoxForm_Campaign.Enabled = False
                        CheckBoxForm_Type.Enabled = False
                        CheckBoxForm_Year.Enabled = False
                        CheckBoxForm_AccountExecutive.Enabled = False
                        CheckBoxForm_ProductUDF.Enabled = False

                        CheckBoxForm_Campaign.Checked = False
                        CheckBoxForm_Type.Checked = True
                        CheckBoxForm_Year.Checked = False
                        CheckBoxForm_AccountExecutive.Checked = False
                        CheckBoxForm_ProductUDF.Checked = False

                        CheckBoxForm_ManualInvoices.Checked = True
                        CheckBoxForm_ManualInvoices.Enabled = True
                        CheckBoxForm_GLEntries.Checked = False
                        CheckBoxForm_GLEntries.Enabled = False

                        CheckBoxForm_BilledIncomeRecognized.Checked = True
                        CheckBoxForm_BilledIncomeRecognized.Enabled = True

                        PanelForm_PrimaryDisplayOption.Enabled = True
                        PanelForm_DataOption.Enabled = True
                        PanelForm_CoopOptions.Enabled = True
                        ComboBox_OverheadSet.Enabled = True

                        RadioButtonForm_Standard.Enabled = True
                        RadioButtonForm_AlternateDirectCost.Enabled = True

                    End If

                Else

                    CheckBoxForm_Office.Enabled = False
                    CheckBoxForm_Client.Enabled = False
                    CheckBoxForm_Division.Enabled = False
                    CheckBoxForm_Product.Enabled = False
                    CheckBoxForm_Campaign.Enabled = False
                    CheckBoxForm_Type.Enabled = False
                    CheckBoxForm_SalesClass.Enabled = False
                    CheckBoxForm_PostPeriod.Enabled = False
                    CheckBoxForm_Year.Enabled = False
                    CheckBoxForm_AccountExecutive.Enabled = False
                    CheckBoxForm_ProductUDF.Enabled = False

                End If

            End If

        End Sub
        Private Sub LoadOffices()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewSelectOffices_Offices.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Office.LoadAllActiveWithOfficeLimits(DbContext, Me.Session)
                                                                Select [Code] = Entity.Code,
                                                                       [Name] = Entity.Name).ToList

                DataGridViewSelectOffices_Offices.CurrentView.BestFitColumns()

            End Using

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal ShowReportOption As Boolean, ByRef ReportType As AdvantageFramework.Reporting.ReportTypes, ByRef ParameterDictionary As Generic.Dictionary(Of String, Object)) As Windows.Forms.DialogResult

			'objects
			Dim ClientPLInitialLoadingDialog As AdvantageFramework.Reporting.Presentation.ClientPLInitialLoadingDialog = Nothing

			ClientPLInitialLoadingDialog = New AdvantageFramework.Reporting.Presentation.ClientPLInitialLoadingDialog(ShowReportOption, ReportType, ParameterDictionary)

			ShowFormDialog = ClientPLInitialLoadingDialog.ShowDialog()

			If ShowFormDialog = Windows.Forms.DialogResult.OK Then

				ParameterDictionary = ClientPLInitialLoadingDialog.ParameterDictionary
				ReportType = ClientPLInitialLoadingDialog.ReportType

			End If

		End Function

#End Region

#Region "  Form Event Handlers "

		Private Sub ClientPLInitialLoadingDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

			'objects
			Dim ClientPLReports As Generic.List(Of AdvantageFramework.Security.Database.Entities.Report) = Nothing
			Dim UserClientPLReports As Generic.List(Of AdvantageFramework.Security.Database.Classes.ReportAccess) = Nothing
            'Dim IsReportActive As Boolean = False
            Dim EnumObjects As Generic.List(Of AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute) = Nothing

            CDPChooserControl_Production.LoadControl()

            Me.ByPassUserEntryChanged = True
			Me.ShowUnsavedChangesOnFormClosing = False

			PanelForm_TopSection.Visible = _ShowReportOption

			ComboBoxForm_StartingPostPeriod.SetRequired(True)
			ComboBoxForm_EndingPostPeriod.SetRequired(True)

            If _ShowReportOption Then

                ComboBoxTopSection_Report.SetRequired(True)
                ComboBoxTopSection_Report.DisplayName = "Report"

            End If

            If _ShowReportOption = True Then    '78

                ComboBoxForm_PriorPeriod1Start.Enabled = False
                ComboBoxForm_PriorPeriod1End.Enabled = False
                ComboBoxForm_PriorPeriod2Start.Enabled = False
                ComboBoxForm_PriorPeriod2End.Enabled = False

            End If

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

				Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

					ClientPLReports = AdvantageFramework.Security.Database.Procedures.Report.LoadByReportType(SecurityDbContext, 115).Where(Function(ClientPL) ClientPL.IsActive = "A").ToList

					UserClientPLReports = (From Report In ClientPLReports
										   Select New AdvantageFramework.Security.Database.Classes.ReportAccess(Report, Session, Session.User)).ToList

					EnumObjects = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Reporting.ClientPLReportTypes)).OrderBy(Function(EO) EO.Description).ToList

					ComboBoxTopSection_Report.DataSource = (From UserClientPLReport In UserClientPLReports
															Join EnumObject In EnumObjects On EnumObject.Code Equals UserClientPLReport.ReportNumber
															Where EnumObject IsNot Nothing AndAlso
																  UserClientPLReport.Enabled = True
															Select EnumObject).OrderBy(Function(EO) EO.Description).ToList

                    ComboBoxForm_StartingPostPeriod.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList
                    ComboBoxForm_EndingPostPeriod.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList

                    ComboBoxForm_PriorPeriod1Start.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList
                    ComboBoxForm_PriorPeriod1End.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList

                    ComboBoxForm_PriorPeriod2Start.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList
                    ComboBoxForm_PriorPeriod2End.DataSource = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllNonYearEndPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Code).ToList

                    ComboBoxForm_PriorPeriod1Start.SelectedValue = Nothing
                    ComboBoxForm_PriorPeriod1End.SelectedValue = Nothing
                    ComboBoxForm_PriorPeriod2Start.SelectedValue = Nothing
                    ComboBoxForm_PriorPeriod2End.SelectedValue = Nothing

                    ComboBox_OverheadSet.DataSource = (From Entity In AdvantageFramework.Database.Procedures.OverheadAccount.LoadDistinctOverheadAccounts(DbContext)
													   Select Entity.Code,
															  Entity.Description).ToList.Select(Function(Overhead) New With {.Code = Overhead.Code,
																															 .Description = Overhead.Code & " - " & Overhead.Description}).ToList

					Try

						ComboBoxForm_StartingPostPeriod.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).Code

					Catch ex As Exception
						ComboBoxForm_StartingPostPeriod.SelectedValue = Nothing
					End Try

					Try

						ComboBoxForm_EndingPostPeriod.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).Code

					Catch ex As Exception
						ComboBoxForm_EndingPostPeriod.SelectedValue = Nothing
					End Try

				End Using

			End Using

			If _ParameterDictionary IsNot Nothing Then

				Try

					ComboBoxForm_StartingPostPeriod.SelectedValue = _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.StartingPostPeriodCode.ToString)

				Catch ex As Exception

				End Try

				Try

					ComboBoxForm_EndingPostPeriod.SelectedValue = _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.EndingPostPeriodCode.ToString)

				Catch ex As Exception

				End Try

				RadioButtonForm_Standard.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.Type.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.Type.ToString) = 1, True, False)
				RadioButtonForm_AlternateDirectCost.Checked = Not RadioButtonForm_Standard.Checked
				CheckBoxForm_Office.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeOffice.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeOffice.ToString) = 1, True, False)
				CheckBoxForm_Client.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeClient.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeClient.ToString) = 1, True, False)
				CheckBoxForm_Division.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeDivision.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeDivision.ToString) = 1, True, False)
				CheckBoxForm_Product.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeProduct.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeProduct.ToString) = 1, True, False)
				CheckBoxForm_Type.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeType.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeType.ToString) = 1, True, False)
				CheckBoxForm_SalesClass.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeSalesClass.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeSalesClass.ToString) = 1, True, False)
				CheckBoxForm_PostPeriod.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludePostPeriod.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludePostPeriod.ToString) = 1, True, False)
				CheckBoxForm_Year.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeYear.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeYear.ToString) = 1, True, False)
				CheckBoxForm_Campaign.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeCampaign.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeCampaign.ToString) = 1, True, False)
				CheckBoxForm_AccountExecutive.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeAE.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeAE.ToString) = 1, True, False)
				CheckBoxForm_ProductUDF.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeProductUDF.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeProductUDF.ToString) = 1, True, False)
				CheckBoxForm_ManualInvoices.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeManualInvoices.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeManualInvoices.ToString) = 1, True, False)
				CheckBoxForm_GLEntries.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeGLEntries.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeGLEntries.ToString) = 1, True, False)
				CheckBoxForm_BilledIncomeRecognized.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeBilledIncomeRecognized.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeBilledIncomeRecognized.ToString) = 1, True, False)
				RadioButtonPrimaryDisplayOption_OverheadFactor.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.FTEAllocation.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.FTEAllocation.ToString) = 1, True, False)
				RadioButtonPrimaryDisplayOption_OverheadAllocation.Checked = Not RadioButtonPrimaryDisplayOption_OverheadFactor.Checked
				RadioButtonDataOption_Hours.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.HoursCost.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.HoursCost.ToString) = 1, True, False)
				RadioButtonDataOption_Cost.Checked = Not RadioButtonDataOption_Hours.Checked
				RadioButtonCoopOptions_BreakoutCoop.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.CoopOption.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.CoopOption.ToString) = 1, True, False)
                RadioButtonCoopOptions_CombineCoop.Checked = Not RadioButtonCoopOptions_BreakoutCoop.Checked
                CheckBoxForm_ExcludeNewBusiness.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.ExcludeNewBusiness.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.ExcludeNewBusiness.ToString) = 1, True, False)
                CheckBoxDirectExpenseOperatingOnly.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.DirectExpenseFromExpenseOperatingOnly.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.DirectExpenseFromExpenseOperatingOnly.ToString) = 1, True, False)

            Else

				RadioButtonForm_Standard.Checked = True
				RadioButtonForm_AlternateDirectCost.Checked = False
				CheckBoxForm_Office.Checked = True
				CheckBoxForm_Client.Checked = True
				CheckBoxForm_Division.Checked = True
				CheckBoxForm_Product.Checked = True
				CheckBoxForm_Type.Checked = True
				CheckBoxForm_SalesClass.Checked = True
				CheckBoxForm_PostPeriod.Checked = True
				CheckBoxForm_Year.Checked = True
				CheckBoxForm_Campaign.Checked = True
				CheckBoxForm_AccountExecutive.Checked = True
				CheckBoxForm_ProductUDF.Checked = True
				CheckBoxForm_ManualInvoices.Checked = True
				CheckBoxForm_GLEntries.Checked = True
                CheckBoxForm_BilledIncomeRecognized.Checked = True
                CheckBoxDirectExpenseOperatingOnly.Checked = True

            End If

		End Sub
		Private Sub ClientPLInitialLoadingDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            CDPChooserControl_Production.ForceResize()
            EnableOrDisableActions()

		End Sub

#End Region

#Region "  Control Event Handlers "

		Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

			'objects
			Dim ErrorMessage As String = Nothing

			If Me.Validator Then

				If ComboBoxForm_StartingPostPeriod.SelectedValue <= ComboBoxForm_EndingPostPeriod.SelectedValue Then

					If _ShowReportOption Then

						_ReportType = CInt(ComboBoxTopSection_Report.GetSelectedValue)

					End If

					If _ParameterDictionary Is Nothing Then

						_ParameterDictionary = New Generic.Dictionary(Of String, Object)

					End If

					_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.StartingPostPeriodCode.ToString) = ComboBoxForm_StartingPostPeriod.SelectedValue
					_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.EndingPostPeriodCode.ToString) = ComboBoxForm_EndingPostPeriod.SelectedValue
					_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.Type.ToString) = If(RadioButtonForm_Standard.Checked, 1, 0)
					_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeOffice.ToString) = CheckBoxForm_Office.Checked
					_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeClient.ToString) = CheckBoxForm_Client.Checked
					_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeDivision.ToString) = CheckBoxForm_Division.Checked
					_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeProduct.ToString) = CheckBoxForm_Product.Checked
					_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeType.ToString) = CheckBoxForm_Type.Checked
					_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeSalesClass.ToString) = CheckBoxForm_SalesClass.Checked
					_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludePostPeriod.ToString) = CheckBoxForm_PostPeriod.Checked
					_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeYear.ToString) = CheckBoxForm_Year.Checked
					_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeCampaign.ToString) = CheckBoxForm_Campaign.Checked
					_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeAE.ToString) = CheckBoxForm_AccountExecutive.Checked
					_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeProductUDF.ToString) = CheckBoxForm_ProductUDF.Checked
					_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeManualInvoices.ToString) = CheckBoxForm_ManualInvoices.Checked
					_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeGLEntries.ToString) = CheckBoxForm_GLEntries.Checked
                    _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeBilledIncomeRecognized.ToString) = CheckBoxForm_BilledIncomeRecognized.Checked
                    If _ReportType = 88 Or _ReportType = 89 Or _ReportType = 99 Then
                        _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeCREntries.ToString) = 0
                    Else
                        _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.IncludeCREntries.ToString) = 1
                    End If
                    _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.FTEAllocation.ToString) = If(RadioButtonPrimaryDisplayOption_OverheadFactor.Checked, 1, 2)
					_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.HoursCost.ToString) = If(RadioButtonDataOption_Hours.Checked, 1, 2)
					_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.CoopOption.ToString) = If(RadioButtonCoopOptions_BreakoutCoop.Checked, 1, 2)
					_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.Summary.ToString) = If(_ReportType = 88, 1, 0)
					_ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.UserId.ToString) = Session.UserCode
                    _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.ExcludeNewBusiness.ToString) = CheckBoxForm_ExcludeNewBusiness.Checked
                    _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.DirectExpenseFromExpenseOperatingOnly.ToString) = CheckBoxDirectExpenseOperatingOnly.Checked

                    'ComboBoxForm_PriorPeriod1Start
                    _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.StartingPostPeriod1Code.ToString) = ComboBoxForm_PriorPeriod1Start.SelectedValue
                    _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.EndingPostPeriod1Code.ToString) = ComboBoxForm_PriorPeriod1End.SelectedValue
                    _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.StartingPostPeriod2Code.ToString) = ComboBoxForm_PriorPeriod2Start.SelectedValue
                    _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.EndingPostPeriod2Code.ToString) = ComboBoxForm_PriorPeriod2End.SelectedValue

                    If Me.ComboBox_OverheadSet.SelectedValue Is Nothing Then

                        _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.OverheadSet.ToString) = ""

                    Else

                        _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.OverheadSet.ToString) = ComboBox_OverheadSet.SelectedValue

                    End If

                    If RadioButtonSelectOffices_AllOffices.Checked Then

                        _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.SelectedOffices.ToString) = Nothing
                        _ParameterDictionary("SelectedOfficeDescriptions") = Nothing

                    Else

                        _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.SelectedOffices.ToString) = DataGridViewSelectOffices_Offices.GetAllSelectedRowsBookmarkValues(0).OfType(Of String).ToList
                        _ParameterDictionary("SelectedOfficeDescriptions") = DataGridViewSelectOffices_Offices.GetAllSelectedRowsBookmarkValues(1).OfType(Of String).ToList

                    End If

                    _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.SelectedClients.ToString) = CDPChooserControl_Production.ClientCodeList
                    _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.SelectedDivisions.ToString) = CDPChooserControl_Production.DivisionCodeList
                    _ParameterDictionary(AdvantageFramework.Reporting.ClientPLParameters.SelectedProducts.ToString) = CDPChooserControl_Production.ProductCodeList


                    If _ShowReportOption Then

						AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, _ReportType, ParameterDictionary, Nothing, Nothing, Nothing, Nothing)

					Else

						Me.DialogResult = System.Windows.Forms.DialogResult.OK
						Me.Close()

					End If

				Else

					AdvantageFramework.WinForm.MessageBox.Show("Please select a starting post period that is before the ending post period.")

				End If

			Else

				For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

					ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

				Next

				AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

			End If

		End Sub
		Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

			Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.Close()

		End Sub
		Private Sub ButtonForm_YTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_YTD.Click

			Dim CurrentPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
			Dim PostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing

			Try

				Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

					CurrentPostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext)
					PostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadFirstPeriodByYear(DbContext, CurrentPostPeriod.Year)

					Try
						Me.ComboBoxForm_StartingPostPeriod.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadByMonthAndYear(DbContext, PostPeriod.Month.GetValueOrDefault(1), PostPeriod.Year.ToString).Code
					Catch ex As Exception
						ComboBoxForm_StartingPostPeriod.SelectedValue = Nothing
					End Try
					Try
						Me.ComboBoxForm_EndingPostPeriod.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).Code
					Catch ex As Exception
						ComboBoxForm_EndingPostPeriod.SelectedValue = Nothing
					End Try

				End Using

			Catch ex As Exception

			End Try

		End Sub
		Private Sub ButtonForm_MTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_MTD.Click

			Try

				Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

					Try
						ComboBoxForm_StartingPostPeriod.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).Code
					Catch ex As Exception
						ComboBoxForm_StartingPostPeriod.SelectedValue = Nothing
					End Try
					Try
						ComboBoxForm_EndingPostPeriod.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).Code
					Catch ex As Exception
						ComboBoxForm_EndingPostPeriod.SelectedValue = Nothing
					End Try

				End Using

			Catch ex As Exception

			End Try

		End Sub
		Private Sub ButtonForm_1Year_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_1Year.Click

			Dim CurrentPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
			Dim Month As Integer = 0
			Dim Year As Integer = 0

			Try

				Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

					CurrentPostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext)

					If CurrentPostPeriod IsNot Nothing Then

						Month = CInt(CurrentPostPeriod.Month.GetValueOrDefault(1))
						Year = CInt(CurrentPostPeriod.Year) - 1

					End If

					Try
						ComboBoxForm_StartingPostPeriod.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadByMonthAndYear(DbContext, Month, Year).Code
					Catch ex As Exception
						ComboBoxForm_StartingPostPeriod.SelectedValue = Nothing
					End Try

					Try
						ComboBoxForm_EndingPostPeriod.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).Code
					Catch ex As Exception
						ComboBoxForm_EndingPostPeriod.SelectedValue = Nothing
					End Try

				End Using

			Catch ex As Exception

			End Try

		End Sub
		Private Sub ButtonForm_2Years_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_2Years.Click

			Dim CurrentPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
			Dim Month As Integer = 0
			Dim Year As Integer = 0

			Try

				Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

					CurrentPostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext)

					If CurrentPostPeriod IsNot Nothing Then

						Month = CInt(CurrentPostPeriod.Month.GetValueOrDefault(1))
						Year = CInt(CurrentPostPeriod.Year) - 2

					End If

					Try
						ComboBoxForm_StartingPostPeriod.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadByMonthAndYear(DbContext, Month, Year).Code
					Catch ex As Exception
						ComboBoxForm_StartingPostPeriod.SelectedValue = Nothing
					End Try

					Try
						ComboBoxForm_EndingPostPeriod.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).Code
					Catch ex As Exception
						ComboBoxForm_EndingPostPeriod.SelectedValue = Nothing
					End Try

				End Using

			Catch ex As Exception

			End Try

		End Sub
		Private Sub ButtonForm_2YTD_Click(sender As Object, e As EventArgs) Handles ButtonForm_2YTD.Click

			Dim CurrentPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
			Dim PostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing

			Try

				Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

					CurrentPostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext)
					PostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadFirstPeriodByYear(DbContext, CurrentPostPeriod.Year)

					Try
						ComboBoxForm_StartingPostPeriod.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadByMonthAndYear(DbContext, PostPeriod.Month.GetValueOrDefault(1), CInt(PostPeriod.Year) - 1).Code
					Catch ex As Exception
						ComboBoxForm_StartingPostPeriod.SelectedValue = Nothing
					End Try

					Try
						ComboBoxForm_EndingPostPeriod.SelectedValue = AdvantageFramework.Database.Procedures.PostPeriod.LoadCurrentPostPeriod(DbContext).Code
					Catch ex As Exception
						ComboBoxForm_EndingPostPeriod.SelectedValue = Nothing
					End Try

				End Using

			Catch ex As Exception

			End Try

		End Sub
		Private Sub RadioButtonPrimaryDisplayOption_OverheadFactor_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonPrimaryDisplayOption_OverheadFactor.CheckedChanged

			If RadioButtonPrimaryDisplayOption_OverheadFactor.Checked = True Then

				ComboBox_OverheadSet.Enabled = False

			Else

				ComboBox_OverheadSet.Enabled = True

			End If

		End Sub
        Private Sub ComboBoxTopSection_Report_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxTopSection_Report.SelectedValueChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None AndAlso _ShowReportOption Then

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub RadioButtonSelectOffices_AllOffices_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonSelectOffices_AllOffices.CheckedChanged

            If Me.FormShown Then

                If RadioButtonSelectOffices_AllOffices.Checked Then

                    DataGridViewSelectOffices_Offices.Enabled = False

                End If

            End If

        End Sub
        Private Sub RadioButtonSelectOffices_ChooseOffices_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonSelectOffices_ChooseOffices.CheckedChanged

            If Me.FormShown Then

                If RadioButtonSelectOffices_ChooseOffices.Checked Then

                    If DataGridViewSelectOffices_Offices.HasRows = False Then

                        LoadOffices()

                    End If

                    DataGridViewSelectOffices_Offices.Enabled = True

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
