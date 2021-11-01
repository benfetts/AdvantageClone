Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class OfficeControl
        Inherits AdvantageFramework.WinForm.Presentation.Controls.BaseControls.BaseUserControl

        'UserControl overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
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
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OfficeControl))
            Me.ComboBoxControl_GLXREFCode = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelControl_GLXREFCode = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxControl_Description = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelControl_Description = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxControl_Inactive = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.TextBoxControl_Code = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelControl_Code = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabControlControl_Office = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelDefaultTab_Default = New DevComponents.DotNetBar.TabControlPanel()
            Me.GroupBoxDefault_SalesTaxAccountCodes = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.SearchableComboBoxDefault_CityTaxGLACode = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewDefault_CityTaxGLACode = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxDefault_CountyTaxGLACode = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxDefault_StateTaxGLACode = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewDefault_StateTaxGLACode = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelSalesTaxAccountCodes_CityTaxGLACode = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSalesTaxAccountCodes_CountyTaxGLACode = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSalesTaxAccountCodes_StateTaxGLACode = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.GroupBoxDefault_AccountCodes = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.LabelDefault_ClientLatePaymentFeeGLACode = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxDefault_ClientLatePaymentFeeGLACode = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelDefault_SuspenseGLACode = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxDefault_SuspenseGLACode = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView2 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxDefault_AccountsReceivableGLACode = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxDefault_AccountsPayableDiscountGLACode = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxDefault_AccountsPayableGLACode = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelDefault_AccountsPayableDiscountGLACode = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelDefault_AccountsPayableGLACode = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelDefault_AccountsReceivableGLACode = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemOffice_DefaultTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelSalesClassFunctionAccountsTab_SalesClassFunctionAccounts = New DevComponents.DotNetBar.TabControlPanel()
            Me.SearchableComboBoxSalesClassFunctionAccounts_SalesClass = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView1 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.GroupBoxSalesClassFunctionAccounts_GLSalesClassFunctionAccounts = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.DataGridViewGLSalesClassFunctionAccounts_GLSCFA = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.LabelSalesClassFunctionAccounts_SalesClass = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.GroupBoxSalesClassFunctionAccounts_GLSalesClassAccounts = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.SearchableComboBoxSalesClassAccounts_MediaCOS = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxSalesClassAccounts_MediaSales = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxSalesClassAccounts_ProductionCOS = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxSalesClassAccounts_ProductionSales = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelGLSalesClassAccounts_MediaCOS = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGLSalesClassAccounts_MediaSales = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGLSalesClassAccounts_ProductionCOS = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGLSalesClassAccounts_ProductionSales = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemOffice_SalesClassFunctionAccountsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelOverheadSetsTab_OverheadSets = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewOverheadSets_OverheadSets = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemOffice_OverheadSetsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelInterCompanyAccounts_InterCompanyAccounts = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewInterCompanyAccounts_InterCompanyAccounts = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemOffice_InterCompanyAccountsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelDocumentsTab_Documents = New DevComponents.DotNetBar.TabControlPanel()
            Me.DocumentManagerControlDocuments_OfficeDocuments = New AdvantageFramework.WinForm.Presentation.Controls.DocumentManagerControl()
            Me.TabItemOffice_DocumentsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelProductionDefaults_ProductionDefaults = New DevComponents.DotNetBar.TabControlPanel()
            Me.GroupBoxProductionDefaults_ABIncomeRecognition = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.RadioButtonABIncomeRecognition_InitalBilling = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonABIncomeRecognition_UponReconciliation = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.GroupBoxProductionDefaults_AccountCodes = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.SearchableComboBoxProductionDefaults_DeferredCOS = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxProductionDefaults_AccruedAP = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxProductionDefaults_AccruedCOS = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxProductionDefaults_DeferredSales = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxProductionDefaults_WIP = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewProductionDefaults_WIP = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxProductionDefaults_COS = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewProductionDefaults_COS = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxProductionDefaults_Sales = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewProductionDefaults_Sales = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelProductionDefaults_DeferredCOS = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelProductionDefaults_AccruedAP = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelProductionDefaults_AccruedCOS = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelProductionDefaults_DeferredSales = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelProductionDefaults_WIP = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelProductionDefaults_COS = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelProductionDefaults_Sales = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemOffice_ProductionDefaultsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelFunctionAccountsTab_FunctionAccounts = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewFunctionAccounts_FunctionAccounts = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemOffice_FunctionAccountsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelMediaDefaultsTab_MediaDefaults = New DevComponents.DotNetBar.TabControlPanel()
            Me.GroupBoxMediaDefaults_PrebillIncomeRecognition = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.RadioButtonPrebillIncomeRecognition_CloseDate = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonPrebillIncomeRecognition_InsertionBroadcastDate = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonPrebillIncomeRecognition_BillingDate = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.GroupBoxMediaDefaults_AccountCodes = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.SearchableComboBoxMediaDefaults_DeferredCOS = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxMediaDefaults_AccruedAP = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxMediaDefaults_AccruedCOS = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxMediaDefaults_DeferredSales = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxMediaDefaults_WIP = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewMediaDefaults_WIP = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxMediaDefaults_COS = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewMediaDefaults_COS = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxMediaDefaults_Sales = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewMediaDefaults_Sales = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelMediaDefaults_DeferredCOS = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelMediaDefaults_AccruedAP = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelMediaDefaults_AccruedCOS = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelMediaDefaults_DeferredSales = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelMediaDefaults_WIP = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelMediaDefaults_COS = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelMediaDefaults_Sales = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemOffice_MediaDefaultsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelSalesTaxAccountsTab_SalesTaxAccounts = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewSalesTaxAccounts_SalesTaxAccounts = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemOffice_SalesTaxAccountsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.PanelControl_Control = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            CType(Me.TabControlControl_Office, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlControl_Office.SuspendLayout()
            Me.TabControlPanelDefaultTab_Default.SuspendLayout()
            CType(Me.GroupBoxDefault_SalesTaxAccountCodes, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxDefault_SalesTaxAccountCodes.SuspendLayout()
            CType(Me.SearchableComboBoxDefault_CityTaxGLACode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewDefault_CityTaxGLACode, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxDefault_CountyTaxGLACode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewDefault_CountyTaxGLACode, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxDefault_StateTaxGLACode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewDefault_StateTaxGLACode, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxDefault_AccountCodes, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxDefault_AccountCodes.SuspendLayout()
            CType(Me.SearchableComboBoxDefault_ClientLatePaymentFeeGLACode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxDefault_SuspenseGLACode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxDefault_AccountsReceivableGLACode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxDefault_AccountsPayableDiscountGLACode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxDefault_AccountsPayableGLACode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewDefault_AccountsPayableGLACode, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelSalesClassFunctionAccountsTab_SalesClassFunctionAccounts.SuspendLayout()
            CType(Me.SearchableComboBoxSalesClassFunctionAccounts_SalesClass.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxSalesClassFunctionAccounts_GLSalesClassFunctionAccounts, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxSalesClassFunctionAccounts_GLSalesClassFunctionAccounts.SuspendLayout()
            CType(Me.GroupBoxSalesClassFunctionAccounts_GLSalesClassAccounts, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxSalesClassFunctionAccounts_GLSalesClassAccounts.SuspendLayout()
            CType(Me.SearchableComboBoxSalesClassAccounts_MediaCOS.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxSalesClassAccounts_MediaSales.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewSalesClassAccounts_MediaSales, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxSalesClassAccounts_ProductionCOS.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxSalesClassAccounts_ProductionSales.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelOverheadSetsTab_OverheadSets.SuspendLayout()
            Me.TabControlPanelInterCompanyAccounts_InterCompanyAccounts.SuspendLayout()
            Me.TabControlPanelDocumentsTab_Documents.SuspendLayout()
            Me.TabControlPanelProductionDefaults_ProductionDefaults.SuspendLayout()
            CType(Me.GroupBoxProductionDefaults_ABIncomeRecognition, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxProductionDefaults_ABIncomeRecognition.SuspendLayout()
            CType(Me.GroupBoxProductionDefaults_AccountCodes, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxProductionDefaults_AccountCodes.SuspendLayout()
            CType(Me.SearchableComboBoxProductionDefaults_DeferredCOS.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewProductionDefaults_DeferredCOS, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxProductionDefaults_AccruedAP.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewProductionDefaults_AccruedAP, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxProductionDefaults_AccruedCOS.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewProductionDefaults_AccruedCOS, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxProductionDefaults_DeferredSales.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewProductionDefaults_DeferredSales, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxProductionDefaults_WIP.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewProductionDefaults_WIP, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxProductionDefaults_COS.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewProductionDefaults_COS, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxProductionDefaults_Sales.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewProductionDefaults_Sales, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelFunctionAccountsTab_FunctionAccounts.SuspendLayout()
            Me.TabControlPanelMediaDefaultsTab_MediaDefaults.SuspendLayout()
            CType(Me.GroupBoxMediaDefaults_PrebillIncomeRecognition, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxMediaDefaults_PrebillIncomeRecognition.SuspendLayout()
            CType(Me.GroupBoxMediaDefaults_AccountCodes, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxMediaDefaults_AccountCodes.SuspendLayout()
            CType(Me.SearchableComboBoxMediaDefaults_DeferredCOS.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewMediaDefaults_DeferredCOS, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxMediaDefaults_AccruedAP.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewMediaDefaults_AccruedAP, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxMediaDefaults_AccruedCOS.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewMediaDefaults_AccruedCOS, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxMediaDefaults_DeferredSales.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewMediaDefaults_DeferredSales, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxMediaDefaults_WIP.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewMediaDefaults_WIP, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxMediaDefaults_COS.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewMediaDefaults_COS, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxMediaDefaults_Sales.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewMediaDefaults_Sales, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelSalesTaxAccountsTab_SalesTaxAccounts.SuspendLayout()
            CType(Me.PanelControl_Control, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelControl_Control.SuspendLayout()
            Me.SuspendLayout()
            '
            'ComboBoxControl_GLXREFCode
            '
            Me.ComboBoxControl_GLXREFCode.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxControl_GLXREFCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxControl_GLXREFCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxControl_GLXREFCode.AutoFindItemInDataSource = False
            Me.ComboBoxControl_GLXREFCode.AutoSelectSingleItemDatasource = False
            Me.ComboBoxControl_GLXREFCode.BookmarkingEnabled = False
            Me.ComboBoxControl_GLXREFCode.ClientCode = ""
            Me.ComboBoxControl_GLXREFCode.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.[Default]
            Me.ComboBoxControl_GLXREFCode.DisableMouseWheel = False
            Me.ComboBoxControl_GLXREFCode.DisplayMember = "Code"
            Me.ComboBoxControl_GLXREFCode.DisplayName = ""
            Me.ComboBoxControl_GLXREFCode.DivisionCode = ""
            Me.ComboBoxControl_GLXREFCode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxControl_GLXREFCode.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxControl_GLXREFCode.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxControl_GLXREFCode.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxControl_GLXREFCode.FocusHighlightEnabled = True
            Me.ComboBoxControl_GLXREFCode.FormattingEnabled = True
            Me.ComboBoxControl_GLXREFCode.ItemHeight = 16
            Me.ComboBoxControl_GLXREFCode.Location = New System.Drawing.Point(554, 0)
            Me.ComboBoxControl_GLXREFCode.Name = "ComboBoxControl_GLXREFCode"
            Me.ComboBoxControl_GLXREFCode.ReadOnly = False
            Me.ComboBoxControl_GLXREFCode.SecurityEnabled = True
            Me.ComboBoxControl_GLXREFCode.Size = New System.Drawing.Size(146, 22)
            Me.ComboBoxControl_GLXREFCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxControl_GLXREFCode.TabIndex = 5
            Me.ComboBoxControl_GLXREFCode.TabOnEnter = True
            Me.ComboBoxControl_GLXREFCode.ValueMember = "Code"
            '
            'LabelControl_GLXREFCode
            '
            Me.LabelControl_GLXREFCode.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_GLXREFCode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_GLXREFCode.Location = New System.Drawing.Point(406, 0)
            Me.LabelControl_GLXREFCode.Name = "LabelControl_GLXREFCode"
            Me.LabelControl_GLXREFCode.Size = New System.Drawing.Size(142, 20)
            Me.LabelControl_GLXREFCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_GLXREFCode.TabIndex = 4
            Me.LabelControl_GLXREFCode.Text = "GL Cross Reference Code:"
            '
            'TextBoxControl_Description
            '
            '
            '
            '
            Me.TextBoxControl_Description.Border.Class = "TextBoxBorder"
            Me.TextBoxControl_Description.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxControl_Description.CheckSpellingOnValidate = False
            Me.TextBoxControl_Description.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxControl_Description.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxControl_Description.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxControl_Description.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxControl_Description.FocusHighlightEnabled = True
            Me.TextBoxControl_Description.Location = New System.Drawing.Point(201, 0)
            Me.TextBoxControl_Description.MaxFileSize = CType(0, Long)
            Me.TextBoxControl_Description.Name = "TextBoxControl_Description"
            Me.TextBoxControl_Description.SecurityEnabled = True
            Me.TextBoxControl_Description.ShowSpellCheckCompleteMessage = True
            Me.TextBoxControl_Description.Size = New System.Drawing.Size(199, 21)
            Me.TextBoxControl_Description.StartingFolderName = Nothing
            Me.TextBoxControl_Description.TabIndex = 3
            Me.TextBoxControl_Description.TabOnEnter = True
            '
            'LabelControl_Description
            '
            Me.LabelControl_Description.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_Description.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_Description.Location = New System.Drawing.Point(126, 0)
            Me.LabelControl_Description.Name = "LabelControl_Description"
            Me.LabelControl_Description.Size = New System.Drawing.Size(69, 20)
            Me.LabelControl_Description.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_Description.TabIndex = 2
            Me.LabelControl_Description.Text = "Description:"
            '
            'CheckBoxControl_Inactive
            '
            Me.CheckBoxControl_Inactive.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxControl_Inactive.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxControl_Inactive.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxControl_Inactive.CheckValue = 0
            Me.CheckBoxControl_Inactive.CheckValueChecked = 1
            Me.CheckBoxControl_Inactive.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxControl_Inactive.CheckValueUnchecked = 0
            Me.CheckBoxControl_Inactive.ChildControls = CType(resources.GetObject("CheckBoxControl_Inactive.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxControl_Inactive.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxControl_Inactive.Location = New System.Drawing.Point(706, 0)
            Me.CheckBoxControl_Inactive.Name = "CheckBoxControl_Inactive"
            Me.CheckBoxControl_Inactive.OldestSibling = Nothing
            Me.CheckBoxControl_Inactive.SecurityEnabled = True
            Me.CheckBoxControl_Inactive.SiblingControls = CType(resources.GetObject("CheckBoxControl_Inactive.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxControl_Inactive.Size = New System.Drawing.Size(286, 20)
            Me.CheckBoxControl_Inactive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxControl_Inactive.TabIndex = 8
            Me.CheckBoxControl_Inactive.TabOnEnter = True
            Me.CheckBoxControl_Inactive.Text = "Inactive"
            '
            'TextBoxControl_Code
            '
            '
            '
            '
            Me.TextBoxControl_Code.Border.Class = "TextBoxBorder"
            Me.TextBoxControl_Code.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxControl_Code.CheckSpellingOnValidate = False
            Me.TextBoxControl_Code.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxControl_Code.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxControl_Code.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxControl_Code.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxControl_Code.FocusHighlightEnabled = True
            Me.TextBoxControl_Code.Location = New System.Drawing.Point(45, 0)
            Me.TextBoxControl_Code.MaxFileSize = CType(0, Long)
            Me.TextBoxControl_Code.Name = "TextBoxControl_Code"
            Me.TextBoxControl_Code.SecurityEnabled = True
            Me.TextBoxControl_Code.ShowSpellCheckCompleteMessage = True
            Me.TextBoxControl_Code.Size = New System.Drawing.Size(75, 21)
            Me.TextBoxControl_Code.StartingFolderName = Nothing
            Me.TextBoxControl_Code.TabIndex = 1
            Me.TextBoxControl_Code.TabOnEnter = True
            '
            'LabelControl_Code
            '
            Me.LabelControl_Code.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_Code.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_Code.Location = New System.Drawing.Point(0, 0)
            Me.LabelControl_Code.Name = "LabelControl_Code"
            Me.LabelControl_Code.Size = New System.Drawing.Size(40, 20)
            Me.LabelControl_Code.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_Code.TabIndex = 0
            Me.LabelControl_Code.Text = "Code:"
            '
            'TabControlControl_Office
            '
            Me.TabControlControl_Office.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlControl_Office.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer))
            Me.TabControlControl_Office.CanReorderTabs = False
            Me.TabControlControl_Office.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlControl_Office.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlControl_Office.Controls.Add(Me.TabControlPanelDefaultTab_Default)
            Me.TabControlControl_Office.Controls.Add(Me.TabControlPanelSalesClassFunctionAccountsTab_SalesClassFunctionAccounts)
            Me.TabControlControl_Office.Controls.Add(Me.TabControlPanelOverheadSetsTab_OverheadSets)
            Me.TabControlControl_Office.Controls.Add(Me.TabControlPanelInterCompanyAccounts_InterCompanyAccounts)
            Me.TabControlControl_Office.Controls.Add(Me.TabControlPanelDocumentsTab_Documents)
            Me.TabControlControl_Office.Controls.Add(Me.TabControlPanelProductionDefaults_ProductionDefaults)
            Me.TabControlControl_Office.Controls.Add(Me.TabControlPanelFunctionAccountsTab_FunctionAccounts)
            Me.TabControlControl_Office.Controls.Add(Me.TabControlPanelMediaDefaultsTab_MediaDefaults)
            Me.TabControlControl_Office.Controls.Add(Me.TabControlPanelSalesTaxAccountsTab_SalesTaxAccounts)
            Me.TabControlControl_Office.Location = New System.Drawing.Point(0, 26)
            Me.TabControlControl_Office.Name = "TabControlControl_Office"
            Me.TabControlControl_Office.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlControl_Office.SelectedTabIndex = 0
            Me.TabControlControl_Office.Size = New System.Drawing.Size(992, 589)
            Me.TabControlControl_Office.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlControl_Office.TabIndex = 9
            Me.TabControlControl_Office.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlControl_Office.Tabs.Add(Me.TabItemOffice_DefaultTab)
            Me.TabControlControl_Office.Tabs.Add(Me.TabItemOffice_ProductionDefaultsTab)
            Me.TabControlControl_Office.Tabs.Add(Me.TabItemOffice_FunctionAccountsTab)
            Me.TabControlControl_Office.Tabs.Add(Me.TabItemOffice_SalesClassFunctionAccountsTab)
            Me.TabControlControl_Office.Tabs.Add(Me.TabItemOffice_MediaDefaultsTab)
            Me.TabControlControl_Office.Tabs.Add(Me.TabItemOffice_SalesTaxAccountsTab)
            Me.TabControlControl_Office.Tabs.Add(Me.TabItemOffice_InterCompanyAccountsTab)
            Me.TabControlControl_Office.Tabs.Add(Me.TabItemOffice_OverheadSetsTab)
            Me.TabControlControl_Office.Tabs.Add(Me.TabItemOffice_DocumentsTab)
            '
            'TabControlPanelDefaultTab_Default
            '
            Me.TabControlPanelDefaultTab_Default.Controls.Add(Me.GroupBoxDefault_SalesTaxAccountCodes)
            Me.TabControlPanelDefaultTab_Default.Controls.Add(Me.GroupBoxDefault_AccountCodes)
            Me.TabControlPanelDefaultTab_Default.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelDefaultTab_Default.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelDefaultTab_Default.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelDefaultTab_Default.Name = "TabControlPanelDefaultTab_Default"
            Me.TabControlPanelDefaultTab_Default.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelDefaultTab_Default.Size = New System.Drawing.Size(992, 562)
            Me.TabControlPanelDefaultTab_Default.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelDefaultTab_Default.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDefaultTab_Default.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelDefaultTab_Default.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelDefaultTab_Default.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelDefaultTab_Default.Style.GradientAngle = 90
            Me.TabControlPanelDefaultTab_Default.TabIndex = 0
            Me.TabControlPanelDefaultTab_Default.TabItem = Me.TabItemOffice_DefaultTab
            '
            'GroupBoxDefault_SalesTaxAccountCodes
            '
            Me.GroupBoxDefault_SalesTaxAccountCodes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxDefault_SalesTaxAccountCodes.Controls.Add(Me.SearchableComboBoxDefault_CityTaxGLACode)
            Me.GroupBoxDefault_SalesTaxAccountCodes.Controls.Add(Me.SearchableComboBoxDefault_CountyTaxGLACode)
            Me.GroupBoxDefault_SalesTaxAccountCodes.Controls.Add(Me.SearchableComboBoxDefault_StateTaxGLACode)
            Me.GroupBoxDefault_SalesTaxAccountCodes.Controls.Add(Me.LabelSalesTaxAccountCodes_CityTaxGLACode)
            Me.GroupBoxDefault_SalesTaxAccountCodes.Controls.Add(Me.LabelSalesTaxAccountCodes_CountyTaxGLACode)
            Me.GroupBoxDefault_SalesTaxAccountCodes.Controls.Add(Me.LabelSalesTaxAccountCodes_StateTaxGLACode)
            Me.GroupBoxDefault_SalesTaxAccountCodes.Location = New System.Drawing.Point(4, 170)
            Me.GroupBoxDefault_SalesTaxAccountCodes.Name = "GroupBoxDefault_SalesTaxAccountCodes"
            Me.GroupBoxDefault_SalesTaxAccountCodes.Size = New System.Drawing.Size(984, 109)
            Me.GroupBoxDefault_SalesTaxAccountCodes.TabIndex = 1
            Me.GroupBoxDefault_SalesTaxAccountCodes.Text = "Sales Tax Account Codes"
            '
            'SearchableComboBoxDefault_CityTaxGLACode
            '
            Me.SearchableComboBoxDefault_CityTaxGLACode.ActiveFilterString = ""
            Me.SearchableComboBoxDefault_CityTaxGLACode.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxDefault_CityTaxGLACode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxDefault_CityTaxGLACode.AutoFillMode = False
            Me.SearchableComboBoxDefault_CityTaxGLACode.BookmarkingEnabled = False
            Me.SearchableComboBoxDefault_CityTaxGLACode.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.GeneralLedgerAccount
            Me.SearchableComboBoxDefault_CityTaxGLACode.DataSource = Nothing
            Me.SearchableComboBoxDefault_CityTaxGLACode.DisableMouseWheel = True
            Me.SearchableComboBoxDefault_CityTaxGLACode.DisplayName = ""
            Me.SearchableComboBoxDefault_CityTaxGLACode.EnterMoveNextControl = True
            Me.SearchableComboBoxDefault_CityTaxGLACode.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxDefault_CityTaxGLACode.Location = New System.Drawing.Point(169, 77)
            Me.SearchableComboBoxDefault_CityTaxGLACode.Name = "SearchableComboBoxDefault_CityTaxGLACode"
            Me.SearchableComboBoxDefault_CityTaxGLACode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxDefault_CityTaxGLACode.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxDefault_CityTaxGLACode.Properties.NullText = "[Please Select]"
            Me.SearchableComboBoxDefault_CityTaxGLACode.Properties.PopupView = Me.SearchableComboBoxViewDefault_CityTaxGLACode
            Me.SearchableComboBoxDefault_CityTaxGLACode.Properties.ValueMember = "Code"
            Me.SearchableComboBoxDefault_CityTaxGLACode.SecurityEnabled = True
            Me.SearchableComboBoxDefault_CityTaxGLACode.SelectedValue = Nothing
            Me.SearchableComboBoxDefault_CityTaxGLACode.Size = New System.Drawing.Size(810, 20)
            Me.SearchableComboBoxDefault_CityTaxGLACode.TabIndex = 5
            '
            'SearchableComboBoxViewDefault_CityTaxGLACode
            '
            Me.SearchableComboBoxViewDefault_CityTaxGLACode.AFActiveFilterString = ""
            Me.SearchableComboBoxViewDefault_CityTaxGLACode.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewDefault_CityTaxGLACode.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CityTaxGLACode.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CityTaxGLACode.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CityTaxGLACode.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CityTaxGLACode.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CityTaxGLACode.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CityTaxGLACode.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CityTaxGLACode.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CityTaxGLACode.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CityTaxGLACode.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CityTaxGLACode.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CityTaxGLACode.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CityTaxGLACode.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CityTaxGLACode.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CityTaxGLACode.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CityTaxGLACode.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CityTaxGLACode.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CityTaxGLACode.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CityTaxGLACode.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CityTaxGLACode.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CityTaxGLACode.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CityTaxGLACode.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CityTaxGLACode.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CityTaxGLACode.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CityTaxGLACode.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CityTaxGLACode.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CityTaxGLACode.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CityTaxGLACode.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CityTaxGLACode.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CityTaxGLACode.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CityTaxGLACode.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CityTaxGLACode.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CityTaxGLACode.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CityTaxGLACode.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CityTaxGLACode.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CityTaxGLACode.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CityTaxGLACode.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CityTaxGLACode.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewDefault_CityTaxGLACode.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewDefault_CityTaxGLACode.DataSourceClearing = False
            Me.SearchableComboBoxViewDefault_CityTaxGLACode.EnableDisabledRows = False
            Me.SearchableComboBoxViewDefault_CityTaxGLACode.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewDefault_CityTaxGLACode.Name = "SearchableComboBoxViewDefault_CityTaxGLACode"
            Me.SearchableComboBoxViewDefault_CityTaxGLACode.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewDefault_CityTaxGLACode.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewDefault_CityTaxGLACode.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewDefault_CityTaxGLACode.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewDefault_CityTaxGLACode.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewDefault_CityTaxGLACode.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewDefault_CityTaxGLACode.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewDefault_CityTaxGLACode.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewDefault_CityTaxGLACode.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewDefault_CityTaxGLACode.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewDefault_CityTaxGLACode.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewDefault_CityTaxGLACode.RunStandardValidation = True
            Me.SearchableComboBoxViewDefault_CityTaxGLACode.SkipAddingControlsOnModifyColumn = False
            Me.SearchableComboBoxViewDefault_CityTaxGLACode.SkipSettingFontOnModifyColumn = False
            '
            'SearchableComboBoxDefault_CountyTaxGLACode
            '
            Me.SearchableComboBoxDefault_CountyTaxGLACode.ActiveFilterString = ""
            Me.SearchableComboBoxDefault_CountyTaxGLACode.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxDefault_CountyTaxGLACode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxDefault_CountyTaxGLACode.AutoFillMode = False
            Me.SearchableComboBoxDefault_CountyTaxGLACode.BookmarkingEnabled = False
            Me.SearchableComboBoxDefault_CountyTaxGLACode.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.GeneralLedgerAccount
            Me.SearchableComboBoxDefault_CountyTaxGLACode.DataSource = Nothing
            Me.SearchableComboBoxDefault_CountyTaxGLACode.DisableMouseWheel = True
            Me.SearchableComboBoxDefault_CountyTaxGLACode.DisplayName = ""
            Me.SearchableComboBoxDefault_CountyTaxGLACode.EnterMoveNextControl = True
            Me.SearchableComboBoxDefault_CountyTaxGLACode.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxDefault_CountyTaxGLACode.Location = New System.Drawing.Point(169, 51)
            Me.SearchableComboBoxDefault_CountyTaxGLACode.Name = "SearchableComboBoxDefault_CountyTaxGLACode"
            Me.SearchableComboBoxDefault_CountyTaxGLACode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxDefault_CountyTaxGLACode.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxDefault_CountyTaxGLACode.Properties.NullText = "[Please Select]"
            Me.SearchableComboBoxDefault_CountyTaxGLACode.Properties.PopupView = Me.SearchableComboBoxViewDefault_CountyTaxGLACode
            Me.SearchableComboBoxDefault_CountyTaxGLACode.Properties.ValueMember = "Code"
            Me.SearchableComboBoxDefault_CountyTaxGLACode.SecurityEnabled = True
            Me.SearchableComboBoxDefault_CountyTaxGLACode.SelectedValue = Nothing
            Me.SearchableComboBoxDefault_CountyTaxGLACode.Size = New System.Drawing.Size(810, 20)
            Me.SearchableComboBoxDefault_CountyTaxGLACode.TabIndex = 3
            '
            'SearchableComboBoxViewDefault_CountyTaxGLACode
            '
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode.AFActiveFilterString = ""
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode.DataSourceClearing = False
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode.EnableDisabledRows = False
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode.Name = "SearchableComboBoxViewDefault_CountyTaxGLACode"
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode.RunStandardValidation = True
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode.SkipAddingControlsOnModifyColumn = False
            Me.SearchableComboBoxViewDefault_CountyTaxGLACode.SkipSettingFontOnModifyColumn = False
            '
            'SearchableComboBoxDefault_StateTaxGLACode
            '
            Me.SearchableComboBoxDefault_StateTaxGLACode.ActiveFilterString = ""
            Me.SearchableComboBoxDefault_StateTaxGLACode.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxDefault_StateTaxGLACode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxDefault_StateTaxGLACode.AutoFillMode = False
            Me.SearchableComboBoxDefault_StateTaxGLACode.BookmarkingEnabled = False
            Me.SearchableComboBoxDefault_StateTaxGLACode.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.GeneralLedgerAccount
            Me.SearchableComboBoxDefault_StateTaxGLACode.DataSource = Nothing
            Me.SearchableComboBoxDefault_StateTaxGLACode.DisableMouseWheel = True
            Me.SearchableComboBoxDefault_StateTaxGLACode.DisplayName = ""
            Me.SearchableComboBoxDefault_StateTaxGLACode.EnterMoveNextControl = True
            Me.SearchableComboBoxDefault_StateTaxGLACode.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxDefault_StateTaxGLACode.Location = New System.Drawing.Point(169, 25)
            Me.SearchableComboBoxDefault_StateTaxGLACode.Name = "SearchableComboBoxDefault_StateTaxGLACode"
            Me.SearchableComboBoxDefault_StateTaxGLACode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxDefault_StateTaxGLACode.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxDefault_StateTaxGLACode.Properties.NullText = "[Please Select]"
            Me.SearchableComboBoxDefault_StateTaxGLACode.Properties.PopupView = Me.SearchableComboBoxViewDefault_StateTaxGLACode
            Me.SearchableComboBoxDefault_StateTaxGLACode.Properties.ValueMember = "Code"
            Me.SearchableComboBoxDefault_StateTaxGLACode.SecurityEnabled = True
            Me.SearchableComboBoxDefault_StateTaxGLACode.SelectedValue = Nothing
            Me.SearchableComboBoxDefault_StateTaxGLACode.Size = New System.Drawing.Size(810, 20)
            Me.SearchableComboBoxDefault_StateTaxGLACode.TabIndex = 1
            '
            'SearchableComboBoxViewDefault_StateTaxGLACode
            '
            Me.SearchableComboBoxViewDefault_StateTaxGLACode.AFActiveFilterString = ""
            Me.SearchableComboBoxViewDefault_StateTaxGLACode.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewDefault_StateTaxGLACode.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_StateTaxGLACode.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_StateTaxGLACode.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_StateTaxGLACode.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_StateTaxGLACode.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_StateTaxGLACode.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_StateTaxGLACode.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_StateTaxGLACode.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_StateTaxGLACode.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_StateTaxGLACode.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_StateTaxGLACode.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_StateTaxGLACode.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_StateTaxGLACode.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_StateTaxGLACode.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_StateTaxGLACode.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_StateTaxGLACode.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_StateTaxGLACode.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_StateTaxGLACode.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_StateTaxGLACode.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_StateTaxGLACode.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_StateTaxGLACode.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_StateTaxGLACode.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_StateTaxGLACode.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_StateTaxGLACode.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_StateTaxGLACode.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_StateTaxGLACode.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_StateTaxGLACode.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_StateTaxGLACode.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_StateTaxGLACode.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_StateTaxGLACode.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_StateTaxGLACode.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_StateTaxGLACode.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_StateTaxGLACode.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_StateTaxGLACode.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_StateTaxGLACode.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_StateTaxGLACode.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_StateTaxGLACode.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_StateTaxGLACode.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewDefault_StateTaxGLACode.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewDefault_StateTaxGLACode.DataSourceClearing = False
            Me.SearchableComboBoxViewDefault_StateTaxGLACode.EnableDisabledRows = False
            Me.SearchableComboBoxViewDefault_StateTaxGLACode.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewDefault_StateTaxGLACode.Name = "SearchableComboBoxViewDefault_StateTaxGLACode"
            Me.SearchableComboBoxViewDefault_StateTaxGLACode.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewDefault_StateTaxGLACode.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewDefault_StateTaxGLACode.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewDefault_StateTaxGLACode.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewDefault_StateTaxGLACode.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewDefault_StateTaxGLACode.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewDefault_StateTaxGLACode.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewDefault_StateTaxGLACode.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewDefault_StateTaxGLACode.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewDefault_StateTaxGLACode.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewDefault_StateTaxGLACode.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewDefault_StateTaxGLACode.RunStandardValidation = True
            Me.SearchableComboBoxViewDefault_StateTaxGLACode.SkipAddingControlsOnModifyColumn = False
            Me.SearchableComboBoxViewDefault_StateTaxGLACode.SkipSettingFontOnModifyColumn = False
            '
            'LabelSalesTaxAccountCodes_CityTaxGLACode
            '
            Me.LabelSalesTaxAccountCodes_CityTaxGLACode.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSalesTaxAccountCodes_CityTaxGLACode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSalesTaxAccountCodes_CityTaxGLACode.Location = New System.Drawing.Point(5, 77)
            Me.LabelSalesTaxAccountCodes_CityTaxGLACode.Name = "LabelSalesTaxAccountCodes_CityTaxGLACode"
            Me.LabelSalesTaxAccountCodes_CityTaxGLACode.Size = New System.Drawing.Size(158, 20)
            Me.LabelSalesTaxAccountCodes_CityTaxGLACode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSalesTaxAccountCodes_CityTaxGLACode.TabIndex = 4
            Me.LabelSalesTaxAccountCodes_CityTaxGLACode.Text = "City:"
            '
            'LabelSalesTaxAccountCodes_CountyTaxGLACode
            '
            Me.LabelSalesTaxAccountCodes_CountyTaxGLACode.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSalesTaxAccountCodes_CountyTaxGLACode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSalesTaxAccountCodes_CountyTaxGLACode.Location = New System.Drawing.Point(5, 51)
            Me.LabelSalesTaxAccountCodes_CountyTaxGLACode.Name = "LabelSalesTaxAccountCodes_CountyTaxGLACode"
            Me.LabelSalesTaxAccountCodes_CountyTaxGLACode.Size = New System.Drawing.Size(158, 20)
            Me.LabelSalesTaxAccountCodes_CountyTaxGLACode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSalesTaxAccountCodes_CountyTaxGLACode.TabIndex = 2
            Me.LabelSalesTaxAccountCodes_CountyTaxGLACode.Text = "County:"
            '
            'LabelSalesTaxAccountCodes_StateTaxGLACode
            '
            Me.LabelSalesTaxAccountCodes_StateTaxGLACode.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSalesTaxAccountCodes_StateTaxGLACode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSalesTaxAccountCodes_StateTaxGLACode.Location = New System.Drawing.Point(5, 25)
            Me.LabelSalesTaxAccountCodes_StateTaxGLACode.Name = "LabelSalesTaxAccountCodes_StateTaxGLACode"
            Me.LabelSalesTaxAccountCodes_StateTaxGLACode.Size = New System.Drawing.Size(158, 20)
            Me.LabelSalesTaxAccountCodes_StateTaxGLACode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSalesTaxAccountCodes_StateTaxGLACode.TabIndex = 0
            Me.LabelSalesTaxAccountCodes_StateTaxGLACode.Text = "State:"
            '
            'GroupBoxDefault_AccountCodes
            '
            Me.GroupBoxDefault_AccountCodes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxDefault_AccountCodes.Controls.Add(Me.LabelDefault_ClientLatePaymentFeeGLACode)
            Me.GroupBoxDefault_AccountCodes.Controls.Add(Me.SearchableComboBoxDefault_ClientLatePaymentFeeGLACode)
            Me.GroupBoxDefault_AccountCodes.Controls.Add(Me.LabelDefault_SuspenseGLACode)
            Me.GroupBoxDefault_AccountCodes.Controls.Add(Me.SearchableComboBoxDefault_SuspenseGLACode)
            Me.GroupBoxDefault_AccountCodes.Controls.Add(Me.SearchableComboBoxDefault_AccountsReceivableGLACode)
            Me.GroupBoxDefault_AccountCodes.Controls.Add(Me.SearchableComboBoxDefault_AccountsPayableDiscountGLACode)
            Me.GroupBoxDefault_AccountCodes.Controls.Add(Me.SearchableComboBoxDefault_AccountsPayableGLACode)
            Me.GroupBoxDefault_AccountCodes.Controls.Add(Me.LabelDefault_AccountsPayableDiscountGLACode)
            Me.GroupBoxDefault_AccountCodes.Controls.Add(Me.LabelDefault_AccountsPayableGLACode)
            Me.GroupBoxDefault_AccountCodes.Controls.Add(Me.LabelDefault_AccountsReceivableGLACode)
            Me.GroupBoxDefault_AccountCodes.Location = New System.Drawing.Point(4, 4)
            Me.GroupBoxDefault_AccountCodes.Name = "GroupBoxDefault_AccountCodes"
            Me.GroupBoxDefault_AccountCodes.Size = New System.Drawing.Size(984, 158)
            Me.GroupBoxDefault_AccountCodes.TabIndex = 0
            Me.GroupBoxDefault_AccountCodes.Text = "Account Codes"
            '
            'LabelDefault_ClientLatePaymentFeeGLACode
            '
            Me.LabelDefault_ClientLatePaymentFeeGLACode.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDefault_ClientLatePaymentFeeGLACode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDefault_ClientLatePaymentFeeGLACode.Location = New System.Drawing.Point(5, 104)
            Me.LabelDefault_ClientLatePaymentFeeGLACode.Name = "LabelDefault_ClientLatePaymentFeeGLACode"
            Me.LabelDefault_ClientLatePaymentFeeGLACode.Size = New System.Drawing.Size(158, 20)
            Me.LabelDefault_ClientLatePaymentFeeGLACode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDefault_ClientLatePaymentFeeGLACode.TabIndex = 8
            Me.LabelDefault_ClientLatePaymentFeeGLACode.Text = "Client Late Payment Fees:"
            '
            'SearchableComboBoxDefault_ClientLatePaymentFeeGLACode
            '
            Me.SearchableComboBoxDefault_ClientLatePaymentFeeGLACode.ActiveFilterString = ""
            Me.SearchableComboBoxDefault_ClientLatePaymentFeeGLACode.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxDefault_ClientLatePaymentFeeGLACode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxDefault_ClientLatePaymentFeeGLACode.AutoFillMode = False
            Me.SearchableComboBoxDefault_ClientLatePaymentFeeGLACode.BookmarkingEnabled = False
            Me.SearchableComboBoxDefault_ClientLatePaymentFeeGLACode.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.GeneralLedgerAccount
            Me.SearchableComboBoxDefault_ClientLatePaymentFeeGLACode.DataSource = Nothing
            Me.SearchableComboBoxDefault_ClientLatePaymentFeeGLACode.DisableMouseWheel = True
            Me.SearchableComboBoxDefault_ClientLatePaymentFeeGLACode.DisplayName = ""
            Me.SearchableComboBoxDefault_ClientLatePaymentFeeGLACode.EnterMoveNextControl = True
            Me.SearchableComboBoxDefault_ClientLatePaymentFeeGLACode.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxDefault_ClientLatePaymentFeeGLACode.Location = New System.Drawing.Point(169, 104)
            Me.SearchableComboBoxDefault_ClientLatePaymentFeeGLACode.Name = "SearchableComboBoxDefault_ClientLatePaymentFeeGLACode"
            Me.SearchableComboBoxDefault_ClientLatePaymentFeeGLACode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxDefault_ClientLatePaymentFeeGLACode.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxDefault_ClientLatePaymentFeeGLACode.Properties.NullText = "[Please Select]"
            Me.SearchableComboBoxDefault_ClientLatePaymentFeeGLACode.Properties.PopupView = Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode
            Me.SearchableComboBoxDefault_ClientLatePaymentFeeGLACode.Properties.ValueMember = "Code"
            Me.SearchableComboBoxDefault_ClientLatePaymentFeeGLACode.SecurityEnabled = True
            Me.SearchableComboBoxDefault_ClientLatePaymentFeeGLACode.SelectedValue = Nothing
            Me.SearchableComboBoxDefault_ClientLatePaymentFeeGLACode.Size = New System.Drawing.Size(810, 20)
            Me.SearchableComboBoxDefault_ClientLatePaymentFeeGLACode.TabIndex = 9
            '
            'SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode
            '
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.AFActiveFilterString = ""
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.DataSourceClearing = False
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.EnableDisabledRows = False
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.Name = "SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode"
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.RunStandardValidation = True
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.SkipAddingControlsOnModifyColumn = False
            Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.SkipSettingFontOnModifyColumn = False
            '
            'LabelDefault_SuspenseGLACode
            '
            Me.LabelDefault_SuspenseGLACode.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDefault_SuspenseGLACode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDefault_SuspenseGLACode.Location = New System.Drawing.Point(5, 130)
            Me.LabelDefault_SuspenseGLACode.Name = "LabelDefault_SuspenseGLACode"
            Me.LabelDefault_SuspenseGLACode.Size = New System.Drawing.Size(158, 20)
            Me.LabelDefault_SuspenseGLACode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDefault_SuspenseGLACode.TabIndex = 10
            Me.LabelDefault_SuspenseGLACode.Text = "Suspense:"
            '
            'SearchableComboBoxDefault_SuspenseGLACode
            '
            Me.SearchableComboBoxDefault_SuspenseGLACode.ActiveFilterString = ""
            Me.SearchableComboBoxDefault_SuspenseGLACode.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxDefault_SuspenseGLACode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxDefault_SuspenseGLACode.AutoFillMode = False
            Me.SearchableComboBoxDefault_SuspenseGLACode.BookmarkingEnabled = False
            Me.SearchableComboBoxDefault_SuspenseGLACode.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.GeneralLedgerAccount
            Me.SearchableComboBoxDefault_SuspenseGLACode.DataSource = Nothing
            Me.SearchableComboBoxDefault_SuspenseGLACode.DisableMouseWheel = True
            Me.SearchableComboBoxDefault_SuspenseGLACode.DisplayName = ""
            Me.SearchableComboBoxDefault_SuspenseGLACode.EnterMoveNextControl = True
            Me.SearchableComboBoxDefault_SuspenseGLACode.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxDefault_SuspenseGLACode.Location = New System.Drawing.Point(169, 130)
            Me.SearchableComboBoxDefault_SuspenseGLACode.Name = "SearchableComboBoxDefault_SuspenseGLACode"
            Me.SearchableComboBoxDefault_SuspenseGLACode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxDefault_SuspenseGLACode.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxDefault_SuspenseGLACode.Properties.NullText = "[Please Select]"
            Me.SearchableComboBoxDefault_SuspenseGLACode.Properties.PopupView = Me.GridView2
            Me.SearchableComboBoxDefault_SuspenseGLACode.Properties.ValueMember = "Code"
            Me.SearchableComboBoxDefault_SuspenseGLACode.SecurityEnabled = True
            Me.SearchableComboBoxDefault_SuspenseGLACode.SelectedValue = Nothing
            Me.SearchableComboBoxDefault_SuspenseGLACode.Size = New System.Drawing.Size(810, 20)
            Me.SearchableComboBoxDefault_SuspenseGLACode.TabIndex = 11
            '
            'GridView2
            '
            Me.GridView2.AFActiveFilterString = ""
            Me.GridView2.AllowExtraItemsInGridLookupEdits = True
            Me.GridView2.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AutoFilterLookupColumns = False
            Me.GridView2.AutoloadRepositoryDatasource = True
            Me.GridView2.DataSourceClearing = False
            Me.GridView2.EnableDisabledRows = False
            Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView2.Name = "GridView2"
            Me.GridView2.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView2.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView2.OptionsBehavior.Editable = False
            Me.GridView2.OptionsCustomization.AllowQuickHideColumns = False
            Me.GridView2.OptionsNavigation.AutoFocusNewRow = True
            Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView2.OptionsSelection.MultiSelect = True
            Me.GridView2.OptionsView.ColumnAutoWidth = False
            Me.GridView2.OptionsView.ShowGroupPanel = False
            Me.GridView2.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.GridView2.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView2.RunStandardValidation = True
            Me.GridView2.SkipAddingControlsOnModifyColumn = False
            Me.GridView2.SkipSettingFontOnModifyColumn = False
            '
            'SearchableComboBoxDefault_AccountsReceivableGLACode
            '
            Me.SearchableComboBoxDefault_AccountsReceivableGLACode.ActiveFilterString = ""
            Me.SearchableComboBoxDefault_AccountsReceivableGLACode.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxDefault_AccountsReceivableGLACode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxDefault_AccountsReceivableGLACode.AutoFillMode = False
            Me.SearchableComboBoxDefault_AccountsReceivableGLACode.BookmarkingEnabled = False
            Me.SearchableComboBoxDefault_AccountsReceivableGLACode.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.GeneralLedgerAccount
            Me.SearchableComboBoxDefault_AccountsReceivableGLACode.DataSource = Nothing
            Me.SearchableComboBoxDefault_AccountsReceivableGLACode.DisableMouseWheel = True
            Me.SearchableComboBoxDefault_AccountsReceivableGLACode.DisplayName = ""
            Me.SearchableComboBoxDefault_AccountsReceivableGLACode.EnterMoveNextControl = True
            Me.SearchableComboBoxDefault_AccountsReceivableGLACode.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxDefault_AccountsReceivableGLACode.Location = New System.Drawing.Point(169, 25)
            Me.SearchableComboBoxDefault_AccountsReceivableGLACode.Name = "SearchableComboBoxDefault_AccountsReceivableGLACode"
            Me.SearchableComboBoxDefault_AccountsReceivableGLACode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxDefault_AccountsReceivableGLACode.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxDefault_AccountsReceivableGLACode.Properties.NullText = "[Please Select]"
            Me.SearchableComboBoxDefault_AccountsReceivableGLACode.Properties.PopupView = Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode
            Me.SearchableComboBoxDefault_AccountsReceivableGLACode.Properties.ValueMember = "Code"
            Me.SearchableComboBoxDefault_AccountsReceivableGLACode.SecurityEnabled = True
            Me.SearchableComboBoxDefault_AccountsReceivableGLACode.SelectedValue = Nothing
            Me.SearchableComboBoxDefault_AccountsReceivableGLACode.Size = New System.Drawing.Size(810, 20)
            Me.SearchableComboBoxDefault_AccountsReceivableGLACode.TabIndex = 1
            '
            'SearchableComboBoxViewDefault_AccountsReceivableGLACode
            '
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode.AFActiveFilterString = ""
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode.DataSourceClearing = False
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode.EnableDisabledRows = False
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode.Name = "SearchableComboBoxViewDefault_AccountsReceivableGLACode"
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode.RunStandardValidation = True
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode.SkipAddingControlsOnModifyColumn = False
            Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode.SkipSettingFontOnModifyColumn = False
            '
            'SearchableComboBoxDefault_AccountsPayableDiscountGLACode
            '
            Me.SearchableComboBoxDefault_AccountsPayableDiscountGLACode.ActiveFilterString = ""
            Me.SearchableComboBoxDefault_AccountsPayableDiscountGLACode.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxDefault_AccountsPayableDiscountGLACode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxDefault_AccountsPayableDiscountGLACode.AutoFillMode = False
            Me.SearchableComboBoxDefault_AccountsPayableDiscountGLACode.BookmarkingEnabled = False
            Me.SearchableComboBoxDefault_AccountsPayableDiscountGLACode.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.GeneralLedgerAccount
            Me.SearchableComboBoxDefault_AccountsPayableDiscountGLACode.DataSource = Nothing
            Me.SearchableComboBoxDefault_AccountsPayableDiscountGLACode.DisableMouseWheel = True
            Me.SearchableComboBoxDefault_AccountsPayableDiscountGLACode.DisplayName = ""
            Me.SearchableComboBoxDefault_AccountsPayableDiscountGLACode.EnterMoveNextControl = True
            Me.SearchableComboBoxDefault_AccountsPayableDiscountGLACode.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxDefault_AccountsPayableDiscountGLACode.Location = New System.Drawing.Point(169, 78)
            Me.SearchableComboBoxDefault_AccountsPayableDiscountGLACode.Name = "SearchableComboBoxDefault_AccountsPayableDiscountGLACode"
            Me.SearchableComboBoxDefault_AccountsPayableDiscountGLACode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxDefault_AccountsPayableDiscountGLACode.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxDefault_AccountsPayableDiscountGLACode.Properties.NullText = "[Please Select]"
            Me.SearchableComboBoxDefault_AccountsPayableDiscountGLACode.Properties.PopupView = Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode
            Me.SearchableComboBoxDefault_AccountsPayableDiscountGLACode.Properties.ValueMember = "Code"
            Me.SearchableComboBoxDefault_AccountsPayableDiscountGLACode.SecurityEnabled = True
            Me.SearchableComboBoxDefault_AccountsPayableDiscountGLACode.SelectedValue = Nothing
            Me.SearchableComboBoxDefault_AccountsPayableDiscountGLACode.Size = New System.Drawing.Size(810, 20)
            Me.SearchableComboBoxDefault_AccountsPayableDiscountGLACode.TabIndex = 5
            '
            'SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode
            '
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.AFActiveFilterString = ""
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.DataSourceClearing = False
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.EnableDisabledRows = False
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.Name = "SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode"
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.RunStandardValidation = True
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.SkipAddingControlsOnModifyColumn = False
            Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.SkipSettingFontOnModifyColumn = False
            '
            'SearchableComboBoxDefault_AccountsPayableGLACode
            '
            Me.SearchableComboBoxDefault_AccountsPayableGLACode.ActiveFilterString = ""
            Me.SearchableComboBoxDefault_AccountsPayableGLACode.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxDefault_AccountsPayableGLACode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxDefault_AccountsPayableGLACode.AutoFillMode = False
            Me.SearchableComboBoxDefault_AccountsPayableGLACode.BookmarkingEnabled = False
            Me.SearchableComboBoxDefault_AccountsPayableGLACode.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.GeneralLedgerAccount
            Me.SearchableComboBoxDefault_AccountsPayableGLACode.DataSource = Nothing
            Me.SearchableComboBoxDefault_AccountsPayableGLACode.DisableMouseWheel = True
            Me.SearchableComboBoxDefault_AccountsPayableGLACode.DisplayName = ""
            Me.SearchableComboBoxDefault_AccountsPayableGLACode.EnterMoveNextControl = True
            Me.SearchableComboBoxDefault_AccountsPayableGLACode.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxDefault_AccountsPayableGLACode.Location = New System.Drawing.Point(169, 52)
            Me.SearchableComboBoxDefault_AccountsPayableGLACode.Name = "SearchableComboBoxDefault_AccountsPayableGLACode"
            Me.SearchableComboBoxDefault_AccountsPayableGLACode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxDefault_AccountsPayableGLACode.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxDefault_AccountsPayableGLACode.Properties.NullText = "[Please Select]"
            Me.SearchableComboBoxDefault_AccountsPayableGLACode.Properties.PopupView = Me.SearchableComboBoxViewDefault_AccountsPayableGLACode
            Me.SearchableComboBoxDefault_AccountsPayableGLACode.Properties.ValueMember = "Code"
            Me.SearchableComboBoxDefault_AccountsPayableGLACode.SecurityEnabled = True
            Me.SearchableComboBoxDefault_AccountsPayableGLACode.SelectedValue = Nothing
            Me.SearchableComboBoxDefault_AccountsPayableGLACode.Size = New System.Drawing.Size(810, 20)
            Me.SearchableComboBoxDefault_AccountsPayableGLACode.TabIndex = 3
            '
            'SearchableComboBoxViewDefault_AccountsPayableGLACode
            '
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode.AFActiveFilterString = ""
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode.DataSourceClearing = False
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode.EnableDisabledRows = False
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode.Name = "SearchableComboBoxViewDefault_AccountsPayableGLACode"
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode.RunStandardValidation = True
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode.SkipAddingControlsOnModifyColumn = False
            Me.SearchableComboBoxViewDefault_AccountsPayableGLACode.SkipSettingFontOnModifyColumn = False
            '
            'LabelDefault_AccountsPayableDiscountGLACode
            '
            Me.LabelDefault_AccountsPayableDiscountGLACode.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDefault_AccountsPayableDiscountGLACode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDefault_AccountsPayableDiscountGLACode.Location = New System.Drawing.Point(5, 78)
            Me.LabelDefault_AccountsPayableDiscountGLACode.Name = "LabelDefault_AccountsPayableDiscountGLACode"
            Me.LabelDefault_AccountsPayableDiscountGLACode.Size = New System.Drawing.Size(158, 20)
            Me.LabelDefault_AccountsPayableDiscountGLACode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDefault_AccountsPayableDiscountGLACode.TabIndex = 4
            Me.LabelDefault_AccountsPayableDiscountGLACode.Text = "A/P Discount:"
            '
            'LabelDefault_AccountsPayableGLACode
            '
            Me.LabelDefault_AccountsPayableGLACode.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDefault_AccountsPayableGLACode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDefault_AccountsPayableGLACode.Location = New System.Drawing.Point(5, 52)
            Me.LabelDefault_AccountsPayableGLACode.Name = "LabelDefault_AccountsPayableGLACode"
            Me.LabelDefault_AccountsPayableGLACode.Size = New System.Drawing.Size(158, 20)
            Me.LabelDefault_AccountsPayableGLACode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDefault_AccountsPayableGLACode.TabIndex = 2
            Me.LabelDefault_AccountsPayableGLACode.Text = "A/P:"
            '
            'LabelDefault_AccountsReceivableGLACode
            '
            Me.LabelDefault_AccountsReceivableGLACode.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDefault_AccountsReceivableGLACode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDefault_AccountsReceivableGLACode.Location = New System.Drawing.Point(5, 26)
            Me.LabelDefault_AccountsReceivableGLACode.Name = "LabelDefault_AccountsReceivableGLACode"
            Me.LabelDefault_AccountsReceivableGLACode.Size = New System.Drawing.Size(158, 20)
            Me.LabelDefault_AccountsReceivableGLACode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDefault_AccountsReceivableGLACode.TabIndex = 0
            Me.LabelDefault_AccountsReceivableGLACode.Text = "A/R:"
            '
            'TabItemOffice_DefaultTab
            '
            Me.TabItemOffice_DefaultTab.AttachedControl = Me.TabControlPanelDefaultTab_Default
            Me.TabItemOffice_DefaultTab.Name = "TabItemOffice_DefaultTab"
            Me.TabItemOffice_DefaultTab.Text = "Default"
            '
            'TabControlPanelSalesClassFunctionAccountsTab_SalesClassFunctionAccounts
            '
            Me.TabControlPanelSalesClassFunctionAccountsTab_SalesClassFunctionAccounts.Controls.Add(Me.SearchableComboBoxSalesClassFunctionAccounts_SalesClass)
            Me.TabControlPanelSalesClassFunctionAccountsTab_SalesClassFunctionAccounts.Controls.Add(Me.GroupBoxSalesClassFunctionAccounts_GLSalesClassFunctionAccounts)
            Me.TabControlPanelSalesClassFunctionAccountsTab_SalesClassFunctionAccounts.Controls.Add(Me.LabelSalesClassFunctionAccounts_SalesClass)
            Me.TabControlPanelSalesClassFunctionAccountsTab_SalesClassFunctionAccounts.Controls.Add(Me.GroupBoxSalesClassFunctionAccounts_GLSalesClassAccounts)
            Me.TabControlPanelSalesClassFunctionAccountsTab_SalesClassFunctionAccounts.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelSalesClassFunctionAccountsTab_SalesClassFunctionAccounts.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelSalesClassFunctionAccountsTab_SalesClassFunctionAccounts.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelSalesClassFunctionAccountsTab_SalesClassFunctionAccounts.Name = "TabControlPanelSalesClassFunctionAccountsTab_SalesClassFunctionAccounts"
            Me.TabControlPanelSalesClassFunctionAccountsTab_SalesClassFunctionAccounts.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelSalesClassFunctionAccountsTab_SalesClassFunctionAccounts.Size = New System.Drawing.Size(992, 562)
            Me.TabControlPanelSalesClassFunctionAccountsTab_SalesClassFunctionAccounts.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelSalesClassFunctionAccountsTab_SalesClassFunctionAccounts.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelSalesClassFunctionAccountsTab_SalesClassFunctionAccounts.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelSalesClassFunctionAccountsTab_SalesClassFunctionAccounts.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelSalesClassFunctionAccountsTab_SalesClassFunctionAccounts.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelSalesClassFunctionAccountsTab_SalesClassFunctionAccounts.Style.GradientAngle = 90
            Me.TabControlPanelSalesClassFunctionAccountsTab_SalesClassFunctionAccounts.TabIndex = 0
            Me.TabControlPanelSalesClassFunctionAccountsTab_SalesClassFunctionAccounts.TabItem = Me.TabItemOffice_SalesClassFunctionAccountsTab
            '
            'SearchableComboBoxSalesClassFunctionAccounts_SalesClass
            '
            Me.SearchableComboBoxSalesClassFunctionAccounts_SalesClass.ActiveFilterString = ""
            Me.SearchableComboBoxSalesClassFunctionAccounts_SalesClass.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxSalesClassFunctionAccounts_SalesClass.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxSalesClassFunctionAccounts_SalesClass.AutoFillMode = False
            Me.SearchableComboBoxSalesClassFunctionAccounts_SalesClass.BookmarkingEnabled = False
            Me.SearchableComboBoxSalesClassFunctionAccounts_SalesClass.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.SalesClass
            Me.SearchableComboBoxSalesClassFunctionAccounts_SalesClass.DataSource = Nothing
            Me.SearchableComboBoxSalesClassFunctionAccounts_SalesClass.DisableMouseWheel = True
            Me.SearchableComboBoxSalesClassFunctionAccounts_SalesClass.DisplayName = ""
            Me.SearchableComboBoxSalesClassFunctionAccounts_SalesClass.EnterMoveNextControl = True
            Me.SearchableComboBoxSalesClassFunctionAccounts_SalesClass.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxSalesClassFunctionAccounts_SalesClass.Location = New System.Drawing.Point(110, 4)
            Me.SearchableComboBoxSalesClassFunctionAccounts_SalesClass.Name = "SearchableComboBoxSalesClassFunctionAccounts_SalesClass"
            Me.SearchableComboBoxSalesClassFunctionAccounts_SalesClass.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxSalesClassFunctionAccounts_SalesClass.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxSalesClassFunctionAccounts_SalesClass.Properties.NullText = "Select Sales Class"
            Me.SearchableComboBoxSalesClassFunctionAccounts_SalesClass.Properties.PopupView = Me.GridView1
            Me.SearchableComboBoxSalesClassFunctionAccounts_SalesClass.Properties.ShowClearButton = False
            Me.SearchableComboBoxSalesClassFunctionAccounts_SalesClass.Properties.ValueMember = "Code"
            Me.SearchableComboBoxSalesClassFunctionAccounts_SalesClass.SecurityEnabled = True
            Me.SearchableComboBoxSalesClassFunctionAccounts_SalesClass.SelectedValue = Nothing
            Me.SearchableComboBoxSalesClassFunctionAccounts_SalesClass.Size = New System.Drawing.Size(878, 20)
            Me.SearchableComboBoxSalesClassFunctionAccounts_SalesClass.TabIndex = 1
            '
            'GridView1
            '
            Me.GridView1.AFActiveFilterString = ""
            Me.GridView1.AllowExtraItemsInGridLookupEdits = True
            Me.GridView1.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.AutoFilterLookupColumns = False
            Me.GridView1.AutoloadRepositoryDatasource = True
            Me.GridView1.DataSourceClearing = False
            Me.GridView1.EnableDisabledRows = False
            Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView1.Name = "GridView1"
            Me.GridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView1.OptionsBehavior.Editable = False
            Me.GridView1.OptionsCustomization.AllowQuickHideColumns = False
            Me.GridView1.OptionsNavigation.AutoFocusNewRow = True
            Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView1.OptionsSelection.MultiSelect = True
            Me.GridView1.OptionsView.ColumnAutoWidth = False
            Me.GridView1.OptionsView.ShowGroupPanel = False
            Me.GridView1.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.GridView1.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView1.RunStandardValidation = True
            Me.GridView1.SkipAddingControlsOnModifyColumn = False
            Me.GridView1.SkipSettingFontOnModifyColumn = False
            '
            'GroupBoxSalesClassFunctionAccounts_GLSalesClassFunctionAccounts
            '
            Me.GroupBoxSalesClassFunctionAccounts_GLSalesClassFunctionAccounts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxSalesClassFunctionAccounts_GLSalesClassFunctionAccounts.Controls.Add(Me.DataGridViewGLSalesClassFunctionAccounts_GLSCFA)
            Me.GroupBoxSalesClassFunctionAccounts_GLSalesClassFunctionAccounts.Location = New System.Drawing.Point(4, 170)
            Me.GroupBoxSalesClassFunctionAccounts_GLSalesClassFunctionAccounts.Name = "GroupBoxSalesClassFunctionAccounts_GLSalesClassFunctionAccounts"
            Me.GroupBoxSalesClassFunctionAccounts_GLSalesClassFunctionAccounts.Size = New System.Drawing.Size(984, 388)
            Me.GroupBoxSalesClassFunctionAccounts_GLSalesClassFunctionAccounts.TabIndex = 3
            Me.GroupBoxSalesClassFunctionAccounts_GLSalesClassFunctionAccounts.Text = "GL Sales Class Function Accounts"
            '
            'DataGridViewGLSalesClassFunctionAccounts_GLSCFA
            '
            Me.DataGridViewGLSalesClassFunctionAccounts_GLSCFA.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewGLSalesClassFunctionAccounts_GLSCFA.AllowDragAndDrop = False
            Me.DataGridViewGLSalesClassFunctionAccounts_GLSCFA.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewGLSalesClassFunctionAccounts_GLSCFA.AllowSelectGroupHeaderRow = True
            Me.DataGridViewGLSalesClassFunctionAccounts_GLSCFA.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewGLSalesClassFunctionAccounts_GLSCFA.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewGLSalesClassFunctionAccounts_GLSCFA.AutoFilterLookupColumns = False
            Me.DataGridViewGLSalesClassFunctionAccounts_GLSCFA.AutoloadRepositoryDatasource = True
            Me.DataGridViewGLSalesClassFunctionAccounts_GLSCFA.AutoUpdateViewCaption = True
            Me.DataGridViewGLSalesClassFunctionAccounts_GLSCFA.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewGLSalesClassFunctionAccounts_GLSCFA.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewGLSalesClassFunctionAccounts_GLSCFA.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewGLSalesClassFunctionAccounts_GLSCFA.ItemDescription = ""
            Me.DataGridViewGLSalesClassFunctionAccounts_GLSCFA.Location = New System.Drawing.Point(5, 25)
            Me.DataGridViewGLSalesClassFunctionAccounts_GLSCFA.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewGLSalesClassFunctionAccounts_GLSCFA.MultiSelect = False
            Me.DataGridViewGLSalesClassFunctionAccounts_GLSCFA.Name = "DataGridViewGLSalesClassFunctionAccounts_GLSCFA"
            Me.DataGridViewGLSalesClassFunctionAccounts_GLSCFA.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewGLSalesClassFunctionAccounts_GLSCFA.RunStandardValidation = True
            Me.DataGridViewGLSalesClassFunctionAccounts_GLSCFA.ShowColumnMenuOnRightClick = False
            Me.DataGridViewGLSalesClassFunctionAccounts_GLSCFA.ShowSelectDeselectAllButtons = False
            Me.DataGridViewGLSalesClassFunctionAccounts_GLSCFA.Size = New System.Drawing.Size(974, 358)
            Me.DataGridViewGLSalesClassFunctionAccounts_GLSCFA.TabIndex = 0
            Me.DataGridViewGLSalesClassFunctionAccounts_GLSCFA.UseEmbeddedNavigator = False
            Me.DataGridViewGLSalesClassFunctionAccounts_GLSCFA.ViewCaptionHeight = -1
            '
            'LabelSalesClassFunctionAccounts_SalesClass
            '
            Me.LabelSalesClassFunctionAccounts_SalesClass.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSalesClassFunctionAccounts_SalesClass.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSalesClassFunctionAccounts_SalesClass.Location = New System.Drawing.Point(4, 4)
            Me.LabelSalesClassFunctionAccounts_SalesClass.Name = "LabelSalesClassFunctionAccounts_SalesClass"
            Me.LabelSalesClassFunctionAccounts_SalesClass.Size = New System.Drawing.Size(100, 20)
            Me.LabelSalesClassFunctionAccounts_SalesClass.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSalesClassFunctionAccounts_SalesClass.TabIndex = 0
            Me.LabelSalesClassFunctionAccounts_SalesClass.Text = "Sales Class:"
            '
            'GroupBoxSalesClassFunctionAccounts_GLSalesClassAccounts
            '
            Me.GroupBoxSalesClassFunctionAccounts_GLSalesClassAccounts.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxSalesClassFunctionAccounts_GLSalesClassAccounts.Controls.Add(Me.SearchableComboBoxSalesClassAccounts_MediaCOS)
            Me.GroupBoxSalesClassFunctionAccounts_GLSalesClassAccounts.Controls.Add(Me.SearchableComboBoxSalesClassAccounts_MediaSales)
            Me.GroupBoxSalesClassFunctionAccounts_GLSalesClassAccounts.Controls.Add(Me.SearchableComboBoxSalesClassAccounts_ProductionCOS)
            Me.GroupBoxSalesClassFunctionAccounts_GLSalesClassAccounts.Controls.Add(Me.SearchableComboBoxSalesClassAccounts_ProductionSales)
            Me.GroupBoxSalesClassFunctionAccounts_GLSalesClassAccounts.Controls.Add(Me.LabelGLSalesClassAccounts_MediaCOS)
            Me.GroupBoxSalesClassFunctionAccounts_GLSalesClassAccounts.Controls.Add(Me.LabelGLSalesClassAccounts_MediaSales)
            Me.GroupBoxSalesClassFunctionAccounts_GLSalesClassAccounts.Controls.Add(Me.LabelGLSalesClassAccounts_ProductionCOS)
            Me.GroupBoxSalesClassFunctionAccounts_GLSalesClassAccounts.Controls.Add(Me.LabelGLSalesClassAccounts_ProductionSales)
            Me.GroupBoxSalesClassFunctionAccounts_GLSalesClassAccounts.Location = New System.Drawing.Point(4, 30)
            Me.GroupBoxSalesClassFunctionAccounts_GLSalesClassAccounts.Name = "GroupBoxSalesClassFunctionAccounts_GLSalesClassAccounts"
            Me.GroupBoxSalesClassFunctionAccounts_GLSalesClassAccounts.Size = New System.Drawing.Size(984, 134)
            Me.GroupBoxSalesClassFunctionAccounts_GLSalesClassAccounts.TabIndex = 2
            Me.GroupBoxSalesClassFunctionAccounts_GLSalesClassAccounts.Text = "GL Sales Class Accounts"
            '
            'SearchableComboBoxSalesClassAccounts_MediaCOS
            '
            Me.SearchableComboBoxSalesClassAccounts_MediaCOS.ActiveFilterString = ""
            Me.SearchableComboBoxSalesClassAccounts_MediaCOS.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxSalesClassAccounts_MediaCOS.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxSalesClassAccounts_MediaCOS.AutoFillMode = False
            Me.SearchableComboBoxSalesClassAccounts_MediaCOS.BookmarkingEnabled = False
            Me.SearchableComboBoxSalesClassAccounts_MediaCOS.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.GeneralLedgerAccount
            Me.SearchableComboBoxSalesClassAccounts_MediaCOS.DataSource = Nothing
            Me.SearchableComboBoxSalesClassAccounts_MediaCOS.DisableMouseWheel = True
            Me.SearchableComboBoxSalesClassAccounts_MediaCOS.DisplayName = ""
            Me.SearchableComboBoxSalesClassAccounts_MediaCOS.EnterMoveNextControl = True
            Me.SearchableComboBoxSalesClassAccounts_MediaCOS.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxSalesClassAccounts_MediaCOS.Location = New System.Drawing.Point(106, 103)
            Me.SearchableComboBoxSalesClassAccounts_MediaCOS.Name = "SearchableComboBoxSalesClassAccounts_MediaCOS"
            Me.SearchableComboBoxSalesClassAccounts_MediaCOS.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxSalesClassAccounts_MediaCOS.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxSalesClassAccounts_MediaCOS.Properties.NullText = "[Please Select]"
            Me.SearchableComboBoxSalesClassAccounts_MediaCOS.Properties.PopupView = Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS
            Me.SearchableComboBoxSalesClassAccounts_MediaCOS.Properties.ValueMember = "Code"
            Me.SearchableComboBoxSalesClassAccounts_MediaCOS.SecurityEnabled = True
            Me.SearchableComboBoxSalesClassAccounts_MediaCOS.SelectedValue = Nothing
            Me.SearchableComboBoxSalesClassAccounts_MediaCOS.Size = New System.Drawing.Size(873, 20)
            Me.SearchableComboBoxSalesClassAccounts_MediaCOS.TabIndex = 7
            '
            'SearchableComboBoxViewSalesClassAccounts_MediaCOS
            '
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS.AFActiveFilterString = ""
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS.DataSourceClearing = False
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS.EnableDisabledRows = False
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS.Name = "SearchableComboBoxViewSalesClassAccounts_MediaCOS"
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS.RunStandardValidation = True
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS.SkipAddingControlsOnModifyColumn = False
            Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS.SkipSettingFontOnModifyColumn = False
            '
            'SearchableComboBoxSalesClassAccounts_MediaSales
            '
            Me.SearchableComboBoxSalesClassAccounts_MediaSales.ActiveFilterString = ""
            Me.SearchableComboBoxSalesClassAccounts_MediaSales.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxSalesClassAccounts_MediaSales.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxSalesClassAccounts_MediaSales.AutoFillMode = False
            Me.SearchableComboBoxSalesClassAccounts_MediaSales.BookmarkingEnabled = False
            Me.SearchableComboBoxSalesClassAccounts_MediaSales.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.GeneralLedgerAccount
            Me.SearchableComboBoxSalesClassAccounts_MediaSales.DataSource = Nothing
            Me.SearchableComboBoxSalesClassAccounts_MediaSales.DisableMouseWheel = True
            Me.SearchableComboBoxSalesClassAccounts_MediaSales.DisplayName = ""
            Me.SearchableComboBoxSalesClassAccounts_MediaSales.EnterMoveNextControl = True
            Me.SearchableComboBoxSalesClassAccounts_MediaSales.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxSalesClassAccounts_MediaSales.Location = New System.Drawing.Point(106, 77)
            Me.SearchableComboBoxSalesClassAccounts_MediaSales.Name = "SearchableComboBoxSalesClassAccounts_MediaSales"
            Me.SearchableComboBoxSalesClassAccounts_MediaSales.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxSalesClassAccounts_MediaSales.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxSalesClassAccounts_MediaSales.Properties.NullText = "[Please Select]"
            Me.SearchableComboBoxSalesClassAccounts_MediaSales.Properties.PopupView = Me.SearchableComboBoxViewSalesClassAccounts_MediaSales
            Me.SearchableComboBoxSalesClassAccounts_MediaSales.Properties.ValueMember = "Code"
            Me.SearchableComboBoxSalesClassAccounts_MediaSales.SecurityEnabled = True
            Me.SearchableComboBoxSalesClassAccounts_MediaSales.SelectedValue = Nothing
            Me.SearchableComboBoxSalesClassAccounts_MediaSales.Size = New System.Drawing.Size(873, 20)
            Me.SearchableComboBoxSalesClassAccounts_MediaSales.TabIndex = 5
            '
            'SearchableComboBoxViewSalesClassAccounts_MediaSales
            '
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales.AFActiveFilterString = ""
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales.DataSourceClearing = False
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales.EnableDisabledRows = False
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales.Name = "SearchableComboBoxViewSalesClassAccounts_MediaSales"
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales.RunStandardValidation = True
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales.SkipAddingControlsOnModifyColumn = False
            Me.SearchableComboBoxViewSalesClassAccounts_MediaSales.SkipSettingFontOnModifyColumn = False
            '
            'SearchableComboBoxSalesClassAccounts_ProductionCOS
            '
            Me.SearchableComboBoxSalesClassAccounts_ProductionCOS.ActiveFilterString = ""
            Me.SearchableComboBoxSalesClassAccounts_ProductionCOS.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxSalesClassAccounts_ProductionCOS.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxSalesClassAccounts_ProductionCOS.AutoFillMode = False
            Me.SearchableComboBoxSalesClassAccounts_ProductionCOS.BookmarkingEnabled = False
            Me.SearchableComboBoxSalesClassAccounts_ProductionCOS.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.GeneralLedgerAccount
            Me.SearchableComboBoxSalesClassAccounts_ProductionCOS.DataSource = Nothing
            Me.SearchableComboBoxSalesClassAccounts_ProductionCOS.DisableMouseWheel = True
            Me.SearchableComboBoxSalesClassAccounts_ProductionCOS.DisplayName = ""
            Me.SearchableComboBoxSalesClassAccounts_ProductionCOS.EnterMoveNextControl = True
            Me.SearchableComboBoxSalesClassAccounts_ProductionCOS.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxSalesClassAccounts_ProductionCOS.Location = New System.Drawing.Point(106, 51)
            Me.SearchableComboBoxSalesClassAccounts_ProductionCOS.Name = "SearchableComboBoxSalesClassAccounts_ProductionCOS"
            Me.SearchableComboBoxSalesClassAccounts_ProductionCOS.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxSalesClassAccounts_ProductionCOS.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxSalesClassAccounts_ProductionCOS.Properties.NullText = "[Please Select]"
            Me.SearchableComboBoxSalesClassAccounts_ProductionCOS.Properties.PopupView = Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS
            Me.SearchableComboBoxSalesClassAccounts_ProductionCOS.Properties.ValueMember = "Code"
            Me.SearchableComboBoxSalesClassAccounts_ProductionCOS.SecurityEnabled = True
            Me.SearchableComboBoxSalesClassAccounts_ProductionCOS.SelectedValue = Nothing
            Me.SearchableComboBoxSalesClassAccounts_ProductionCOS.Size = New System.Drawing.Size(873, 20)
            Me.SearchableComboBoxSalesClassAccounts_ProductionCOS.TabIndex = 3
            '
            'SearchableComboBoxViewSalesClassAccounts_ProductionCOS
            '
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS.AFActiveFilterString = ""
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS.DataSourceClearing = False
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS.EnableDisabledRows = False
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS.Name = "SearchableComboBoxViewSalesClassAccounts_ProductionCOS"
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS.RunStandardValidation = True
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS.SkipAddingControlsOnModifyColumn = False
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS.SkipSettingFontOnModifyColumn = False
            '
            'SearchableComboBoxSalesClassAccounts_ProductionSales
            '
            Me.SearchableComboBoxSalesClassAccounts_ProductionSales.ActiveFilterString = ""
            Me.SearchableComboBoxSalesClassAccounts_ProductionSales.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxSalesClassAccounts_ProductionSales.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxSalesClassAccounts_ProductionSales.AutoFillMode = False
            Me.SearchableComboBoxSalesClassAccounts_ProductionSales.BookmarkingEnabled = False
            Me.SearchableComboBoxSalesClassAccounts_ProductionSales.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.GeneralLedgerAccount
            Me.SearchableComboBoxSalesClassAccounts_ProductionSales.DataSource = Nothing
            Me.SearchableComboBoxSalesClassAccounts_ProductionSales.DisableMouseWheel = True
            Me.SearchableComboBoxSalesClassAccounts_ProductionSales.DisplayName = ""
            Me.SearchableComboBoxSalesClassAccounts_ProductionSales.EnterMoveNextControl = True
            Me.SearchableComboBoxSalesClassAccounts_ProductionSales.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxSalesClassAccounts_ProductionSales.Location = New System.Drawing.Point(106, 25)
            Me.SearchableComboBoxSalesClassAccounts_ProductionSales.Name = "SearchableComboBoxSalesClassAccounts_ProductionSales"
            Me.SearchableComboBoxSalesClassAccounts_ProductionSales.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxSalesClassAccounts_ProductionSales.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxSalesClassAccounts_ProductionSales.Properties.NullText = "[Please Select]"
            Me.SearchableComboBoxSalesClassAccounts_ProductionSales.Properties.PopupView = Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales
            Me.SearchableComboBoxSalesClassAccounts_ProductionSales.Properties.ValueMember = "Code"
            Me.SearchableComboBoxSalesClassAccounts_ProductionSales.SecurityEnabled = True
            Me.SearchableComboBoxSalesClassAccounts_ProductionSales.SelectedValue = Nothing
            Me.SearchableComboBoxSalesClassAccounts_ProductionSales.Size = New System.Drawing.Size(873, 20)
            Me.SearchableComboBoxSalesClassAccounts_ProductionSales.TabIndex = 1
            '
            'SearchableComboBoxViewSalesClassAccounts_ProductionSales
            '
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales.AFActiveFilterString = ""
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales.DataSourceClearing = False
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales.EnableDisabledRows = False
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales.Name = "SearchableComboBoxViewSalesClassAccounts_ProductionSales"
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales.RunStandardValidation = True
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales.SkipAddingControlsOnModifyColumn = False
            Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales.SkipSettingFontOnModifyColumn = False
            '
            'LabelGLSalesClassAccounts_MediaCOS
            '
            Me.LabelGLSalesClassAccounts_MediaCOS.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGLSalesClassAccounts_MediaCOS.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGLSalesClassAccounts_MediaCOS.Location = New System.Drawing.Point(5, 103)
            Me.LabelGLSalesClassAccounts_MediaCOS.Name = "LabelGLSalesClassAccounts_MediaCOS"
            Me.LabelGLSalesClassAccounts_MediaCOS.Size = New System.Drawing.Size(95, 20)
            Me.LabelGLSalesClassAccounts_MediaCOS.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGLSalesClassAccounts_MediaCOS.TabIndex = 6
            Me.LabelGLSalesClassAccounts_MediaCOS.Text = "Media COS:"
            '
            'LabelGLSalesClassAccounts_MediaSales
            '
            Me.LabelGLSalesClassAccounts_MediaSales.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGLSalesClassAccounts_MediaSales.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGLSalesClassAccounts_MediaSales.Location = New System.Drawing.Point(5, 77)
            Me.LabelGLSalesClassAccounts_MediaSales.Name = "LabelGLSalesClassAccounts_MediaSales"
            Me.LabelGLSalesClassAccounts_MediaSales.Size = New System.Drawing.Size(95, 20)
            Me.LabelGLSalesClassAccounts_MediaSales.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGLSalesClassAccounts_MediaSales.TabIndex = 4
            Me.LabelGLSalesClassAccounts_MediaSales.Text = "Media Sales:"
            '
            'LabelGLSalesClassAccounts_ProductionCOS
            '
            Me.LabelGLSalesClassAccounts_ProductionCOS.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGLSalesClassAccounts_ProductionCOS.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGLSalesClassAccounts_ProductionCOS.Location = New System.Drawing.Point(5, 51)
            Me.LabelGLSalesClassAccounts_ProductionCOS.Name = "LabelGLSalesClassAccounts_ProductionCOS"
            Me.LabelGLSalesClassAccounts_ProductionCOS.Size = New System.Drawing.Size(95, 20)
            Me.LabelGLSalesClassAccounts_ProductionCOS.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGLSalesClassAccounts_ProductionCOS.TabIndex = 2
            Me.LabelGLSalesClassAccounts_ProductionCOS.Text = "Production COS:"
            '
            'LabelGLSalesClassAccounts_ProductionSales
            '
            Me.LabelGLSalesClassAccounts_ProductionSales.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGLSalesClassAccounts_ProductionSales.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGLSalesClassAccounts_ProductionSales.Location = New System.Drawing.Point(5, 25)
            Me.LabelGLSalesClassAccounts_ProductionSales.Name = "LabelGLSalesClassAccounts_ProductionSales"
            Me.LabelGLSalesClassAccounts_ProductionSales.Size = New System.Drawing.Size(95, 20)
            Me.LabelGLSalesClassAccounts_ProductionSales.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGLSalesClassAccounts_ProductionSales.TabIndex = 0
            Me.LabelGLSalesClassAccounts_ProductionSales.Text = "Production Sales:"
            '
            'TabItemOffice_SalesClassFunctionAccountsTab
            '
            Me.TabItemOffice_SalesClassFunctionAccountsTab.AttachedControl = Me.TabControlPanelSalesClassFunctionAccountsTab_SalesClassFunctionAccounts
            Me.TabItemOffice_SalesClassFunctionAccountsTab.Name = "TabItemOffice_SalesClassFunctionAccountsTab"
            Me.TabItemOffice_SalesClassFunctionAccountsTab.Text = "Sales Class/Function Accounts"
            '
            'TabControlPanelOverheadSetsTab_OverheadSets
            '
            Me.TabControlPanelOverheadSetsTab_OverheadSets.Controls.Add(Me.DataGridViewOverheadSets_OverheadSets)
            Me.TabControlPanelOverheadSetsTab_OverheadSets.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelOverheadSetsTab_OverheadSets.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelOverheadSetsTab_OverheadSets.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelOverheadSetsTab_OverheadSets.Name = "TabControlPanelOverheadSetsTab_OverheadSets"
            Me.TabControlPanelOverheadSetsTab_OverheadSets.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelOverheadSetsTab_OverheadSets.Size = New System.Drawing.Size(992, 562)
            Me.TabControlPanelOverheadSetsTab_OverheadSets.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelOverheadSetsTab_OverheadSets.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelOverheadSetsTab_OverheadSets.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelOverheadSetsTab_OverheadSets.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelOverheadSetsTab_OverheadSets.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelOverheadSetsTab_OverheadSets.Style.GradientAngle = 90
            Me.TabControlPanelOverheadSetsTab_OverheadSets.TabIndex = 8
            Me.TabControlPanelOverheadSetsTab_OverheadSets.TabItem = Me.TabItemOffice_OverheadSetsTab
            '
            'DataGridViewOverheadSets_OverheadSets
            '
            Me.DataGridViewOverheadSets_OverheadSets.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewOverheadSets_OverheadSets.AllowDragAndDrop = False
            Me.DataGridViewOverheadSets_OverheadSets.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewOverheadSets_OverheadSets.AllowSelectGroupHeaderRow = True
            Me.DataGridViewOverheadSets_OverheadSets.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewOverheadSets_OverheadSets.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewOverheadSets_OverheadSets.AutoFilterLookupColumns = False
            Me.DataGridViewOverheadSets_OverheadSets.AutoloadRepositoryDatasource = True
            Me.DataGridViewOverheadSets_OverheadSets.AutoUpdateViewCaption = True
            Me.DataGridViewOverheadSets_OverheadSets.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewOverheadSets_OverheadSets.DataSource = Nothing
            Me.DataGridViewOverheadSets_OverheadSets.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewOverheadSets_OverheadSets.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewOverheadSets_OverheadSets.ItemDescription = ""
            Me.DataGridViewOverheadSets_OverheadSets.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewOverheadSets_OverheadSets.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewOverheadSets_OverheadSets.MultiSelect = False
            Me.DataGridViewOverheadSets_OverheadSets.Name = "DataGridViewOverheadSets_OverheadSets"
            Me.DataGridViewOverheadSets_OverheadSets.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewOverheadSets_OverheadSets.RunStandardValidation = True
            Me.DataGridViewOverheadSets_OverheadSets.ShowColumnMenuOnRightClick = False
            Me.DataGridViewOverheadSets_OverheadSets.ShowSelectDeselectAllButtons = False
            Me.DataGridViewOverheadSets_OverheadSets.Size = New System.Drawing.Size(984, 554)
            Me.DataGridViewOverheadSets_OverheadSets.TabIndex = 9
            Me.DataGridViewOverheadSets_OverheadSets.UseEmbeddedNavigator = False
            Me.DataGridViewOverheadSets_OverheadSets.ViewCaptionHeight = -1
            '
            'TabItemOffice_OverheadSetsTab
            '
            Me.TabItemOffice_OverheadSetsTab.AttachedControl = Me.TabControlPanelOverheadSetsTab_OverheadSets
            Me.TabItemOffice_OverheadSetsTab.Name = "TabItemOffice_OverheadSetsTab"
            Me.TabItemOffice_OverheadSetsTab.Text = "Overhead Sets"
            '
            'TabControlPanelInterCompanyAccounts_InterCompanyAccounts
            '
            Me.TabControlPanelInterCompanyAccounts_InterCompanyAccounts.Controls.Add(Me.DataGridViewInterCompanyAccounts_InterCompanyAccounts)
            Me.TabControlPanelInterCompanyAccounts_InterCompanyAccounts.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelInterCompanyAccounts_InterCompanyAccounts.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelInterCompanyAccounts_InterCompanyAccounts.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelInterCompanyAccounts_InterCompanyAccounts.Name = "TabControlPanelInterCompanyAccounts_InterCompanyAccounts"
            Me.TabControlPanelInterCompanyAccounts_InterCompanyAccounts.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelInterCompanyAccounts_InterCompanyAccounts.Size = New System.Drawing.Size(992, 562)
            Me.TabControlPanelInterCompanyAccounts_InterCompanyAccounts.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelInterCompanyAccounts_InterCompanyAccounts.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelInterCompanyAccounts_InterCompanyAccounts.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelInterCompanyAccounts_InterCompanyAccounts.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelInterCompanyAccounts_InterCompanyAccounts.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelInterCompanyAccounts_InterCompanyAccounts.Style.GradientAngle = 90
            Me.TabControlPanelInterCompanyAccounts_InterCompanyAccounts.TabIndex = 6
            Me.TabControlPanelInterCompanyAccounts_InterCompanyAccounts.TabItem = Me.TabItemOffice_InterCompanyAccountsTab
            '
            'DataGridViewInterCompanyAccounts_InterCompanyAccounts
            '
            Me.DataGridViewInterCompanyAccounts_InterCompanyAccounts.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewInterCompanyAccounts_InterCompanyAccounts.AllowDragAndDrop = False
            Me.DataGridViewInterCompanyAccounts_InterCompanyAccounts.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewInterCompanyAccounts_InterCompanyAccounts.AllowSelectGroupHeaderRow = True
            Me.DataGridViewInterCompanyAccounts_InterCompanyAccounts.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewInterCompanyAccounts_InterCompanyAccounts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewInterCompanyAccounts_InterCompanyAccounts.AutoFilterLookupColumns = False
            Me.DataGridViewInterCompanyAccounts_InterCompanyAccounts.AutoloadRepositoryDatasource = True
            Me.DataGridViewInterCompanyAccounts_InterCompanyAccounts.AutoUpdateViewCaption = True
            Me.DataGridViewInterCompanyAccounts_InterCompanyAccounts.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewInterCompanyAccounts_InterCompanyAccounts.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewInterCompanyAccounts_InterCompanyAccounts.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewInterCompanyAccounts_InterCompanyAccounts.ItemDescription = ""
            Me.DataGridViewInterCompanyAccounts_InterCompanyAccounts.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewInterCompanyAccounts_InterCompanyAccounts.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewInterCompanyAccounts_InterCompanyAccounts.MultiSelect = False
            Me.DataGridViewInterCompanyAccounts_InterCompanyAccounts.Name = "DataGridViewInterCompanyAccounts_InterCompanyAccounts"
            Me.DataGridViewInterCompanyAccounts_InterCompanyAccounts.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewInterCompanyAccounts_InterCompanyAccounts.RunStandardValidation = True
            Me.DataGridViewInterCompanyAccounts_InterCompanyAccounts.ShowColumnMenuOnRightClick = False
            Me.DataGridViewInterCompanyAccounts_InterCompanyAccounts.ShowSelectDeselectAllButtons = False
            Me.DataGridViewInterCompanyAccounts_InterCompanyAccounts.Size = New System.Drawing.Size(984, 554)
            Me.DataGridViewInterCompanyAccounts_InterCompanyAccounts.TabIndex = 8
            Me.DataGridViewInterCompanyAccounts_InterCompanyAccounts.UseEmbeddedNavigator = False
            Me.DataGridViewInterCompanyAccounts_InterCompanyAccounts.ViewCaptionHeight = -1
            '
            'TabItemOffice_InterCompanyAccountsTab
            '
            Me.TabItemOffice_InterCompanyAccountsTab.AttachedControl = Me.TabControlPanelInterCompanyAccounts_InterCompanyAccounts
            Me.TabItemOffice_InterCompanyAccountsTab.Name = "TabItemOffice_InterCompanyAccountsTab"
            Me.TabItemOffice_InterCompanyAccountsTab.Text = "Inter-Company Accounts"
            '
            'TabControlPanelDocumentsTab_Documents
            '
            Me.TabControlPanelDocumentsTab_Documents.Controls.Add(Me.DocumentManagerControlDocuments_OfficeDocuments)
            Me.TabControlPanelDocumentsTab_Documents.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelDocumentsTab_Documents.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelDocumentsTab_Documents.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelDocumentsTab_Documents.Name = "TabControlPanelDocumentsTab_Documents"
            Me.TabControlPanelDocumentsTab_Documents.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelDocumentsTab_Documents.Size = New System.Drawing.Size(992, 562)
            Me.TabControlPanelDocumentsTab_Documents.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelDocumentsTab_Documents.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDocumentsTab_Documents.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelDocumentsTab_Documents.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelDocumentsTab_Documents.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelDocumentsTab_Documents.Style.GradientAngle = 90
            Me.TabControlPanelDocumentsTab_Documents.TabIndex = 7
            Me.TabControlPanelDocumentsTab_Documents.TabItem = Me.TabItemOffice_DocumentsTab
            '
            'DocumentManagerControlDocuments_OfficeDocuments
            '
            Me.DocumentManagerControlDocuments_OfficeDocuments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DocumentManagerControlDocuments_OfficeDocuments.Location = New System.Drawing.Point(4, 4)
            Me.DocumentManagerControlDocuments_OfficeDocuments.Margin = New System.Windows.Forms.Padding(4)
            Me.DocumentManagerControlDocuments_OfficeDocuments.Name = "DocumentManagerControlDocuments_OfficeDocuments"
            Me.DocumentManagerControlDocuments_OfficeDocuments.Size = New System.Drawing.Size(984, 555)
            Me.DocumentManagerControlDocuments_OfficeDocuments.TabIndex = 0
            '
            'TabItemOffice_DocumentsTab
            '
            Me.TabItemOffice_DocumentsTab.AttachedControl = Me.TabControlPanelDocumentsTab_Documents
            Me.TabItemOffice_DocumentsTab.Name = "TabItemOffice_DocumentsTab"
            Me.TabItemOffice_DocumentsTab.Text = "Documents"
            '
            'TabControlPanelProductionDefaults_ProductionDefaults
            '
            Me.TabControlPanelProductionDefaults_ProductionDefaults.Controls.Add(Me.GroupBoxProductionDefaults_ABIncomeRecognition)
            Me.TabControlPanelProductionDefaults_ProductionDefaults.Controls.Add(Me.GroupBoxProductionDefaults_AccountCodes)
            Me.TabControlPanelProductionDefaults_ProductionDefaults.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelProductionDefaults_ProductionDefaults.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelProductionDefaults_ProductionDefaults.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelProductionDefaults_ProductionDefaults.Name = "TabControlPanelProductionDefaults_ProductionDefaults"
            Me.TabControlPanelProductionDefaults_ProductionDefaults.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelProductionDefaults_ProductionDefaults.Size = New System.Drawing.Size(992, 562)
            Me.TabControlPanelProductionDefaults_ProductionDefaults.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelProductionDefaults_ProductionDefaults.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelProductionDefaults_ProductionDefaults.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelProductionDefaults_ProductionDefaults.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelProductionDefaults_ProductionDefaults.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelProductionDefaults_ProductionDefaults.Style.GradientAngle = 90
            Me.TabControlPanelProductionDefaults_ProductionDefaults.TabIndex = 1
            Me.TabControlPanelProductionDefaults_ProductionDefaults.TabItem = Me.TabItemOffice_ProductionDefaultsTab
            '
            'GroupBoxProductionDefaults_ABIncomeRecognition
            '
            Me.GroupBoxProductionDefaults_ABIncomeRecognition.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxProductionDefaults_ABIncomeRecognition.Controls.Add(Me.RadioButtonABIncomeRecognition_InitalBilling)
            Me.GroupBoxProductionDefaults_ABIncomeRecognition.Controls.Add(Me.RadioButtonABIncomeRecognition_UponReconciliation)
            Me.GroupBoxProductionDefaults_ABIncomeRecognition.Location = New System.Drawing.Point(4, 222)
            Me.GroupBoxProductionDefaults_ABIncomeRecognition.Name = "GroupBoxProductionDefaults_ABIncomeRecognition"
            Me.GroupBoxProductionDefaults_ABIncomeRecognition.Size = New System.Drawing.Size(984, 55)
            Me.GroupBoxProductionDefaults_ABIncomeRecognition.TabIndex = 1
            Me.GroupBoxProductionDefaults_ABIncomeRecognition.Text = "Advance Billing Income Recognition"
            '
            'RadioButtonABIncomeRecognition_InitalBilling
            '
            Me.RadioButtonABIncomeRecognition_InitalBilling.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonABIncomeRecognition_InitalBilling.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonABIncomeRecognition_InitalBilling.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonABIncomeRecognition_InitalBilling.CheckValue = "0"
            Me.RadioButtonABIncomeRecognition_InitalBilling.CheckValueChecked = "3"
            Me.RadioButtonABIncomeRecognition_InitalBilling.CheckValueUnchecked = "0"
            Me.RadioButtonABIncomeRecognition_InitalBilling.Location = New System.Drawing.Point(150, 25)
            Me.RadioButtonABIncomeRecognition_InitalBilling.Name = "RadioButtonABIncomeRecognition_InitalBilling"
            Me.RadioButtonABIncomeRecognition_InitalBilling.SecurityEnabled = True
            Me.RadioButtonABIncomeRecognition_InitalBilling.Size = New System.Drawing.Size(121, 20)
            Me.RadioButtonABIncomeRecognition_InitalBilling.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonABIncomeRecognition_InitalBilling.TabIndex = 1
            Me.RadioButtonABIncomeRecognition_InitalBilling.TabOnEnter = True
            Me.RadioButtonABIncomeRecognition_InitalBilling.TabStop = False
            Me.RadioButtonABIncomeRecognition_InitalBilling.Text = "Initial Billing"
            '
            'RadioButtonABIncomeRecognition_UponReconciliation
            '
            Me.RadioButtonABIncomeRecognition_UponReconciliation.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonABIncomeRecognition_UponReconciliation.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonABIncomeRecognition_UponReconciliation.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonABIncomeRecognition_UponReconciliation.CheckValue = "0"
            Me.RadioButtonABIncomeRecognition_UponReconciliation.CheckValueChecked = "1"
            Me.RadioButtonABIncomeRecognition_UponReconciliation.CheckValueUnchecked = "0"
            Me.RadioButtonABIncomeRecognition_UponReconciliation.Location = New System.Drawing.Point(5, 25)
            Me.RadioButtonABIncomeRecognition_UponReconciliation.Name = "RadioButtonABIncomeRecognition_UponReconciliation"
            Me.RadioButtonABIncomeRecognition_UponReconciliation.SecurityEnabled = True
            Me.RadioButtonABIncomeRecognition_UponReconciliation.Size = New System.Drawing.Size(139, 20)
            Me.RadioButtonABIncomeRecognition_UponReconciliation.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonABIncomeRecognition_UponReconciliation.TabIndex = 0
            Me.RadioButtonABIncomeRecognition_UponReconciliation.TabOnEnter = True
            Me.RadioButtonABIncomeRecognition_UponReconciliation.TabStop = False
            Me.RadioButtonABIncomeRecognition_UponReconciliation.Text = "Upon Reconciliation"
            '
            'GroupBoxProductionDefaults_AccountCodes
            '
            Me.GroupBoxProductionDefaults_AccountCodes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxProductionDefaults_AccountCodes.Controls.Add(Me.SearchableComboBoxProductionDefaults_DeferredCOS)
            Me.GroupBoxProductionDefaults_AccountCodes.Controls.Add(Me.SearchableComboBoxProductionDefaults_AccruedAP)
            Me.GroupBoxProductionDefaults_AccountCodes.Controls.Add(Me.SearchableComboBoxProductionDefaults_AccruedCOS)
            Me.GroupBoxProductionDefaults_AccountCodes.Controls.Add(Me.SearchableComboBoxProductionDefaults_DeferredSales)
            Me.GroupBoxProductionDefaults_AccountCodes.Controls.Add(Me.SearchableComboBoxProductionDefaults_WIP)
            Me.GroupBoxProductionDefaults_AccountCodes.Controls.Add(Me.SearchableComboBoxProductionDefaults_COS)
            Me.GroupBoxProductionDefaults_AccountCodes.Controls.Add(Me.SearchableComboBoxProductionDefaults_Sales)
            Me.GroupBoxProductionDefaults_AccountCodes.Controls.Add(Me.LabelProductionDefaults_DeferredCOS)
            Me.GroupBoxProductionDefaults_AccountCodes.Controls.Add(Me.LabelProductionDefaults_AccruedAP)
            Me.GroupBoxProductionDefaults_AccountCodes.Controls.Add(Me.LabelProductionDefaults_AccruedCOS)
            Me.GroupBoxProductionDefaults_AccountCodes.Controls.Add(Me.LabelProductionDefaults_DeferredSales)
            Me.GroupBoxProductionDefaults_AccountCodes.Controls.Add(Me.LabelProductionDefaults_WIP)
            Me.GroupBoxProductionDefaults_AccountCodes.Controls.Add(Me.LabelProductionDefaults_COS)
            Me.GroupBoxProductionDefaults_AccountCodes.Controls.Add(Me.LabelProductionDefaults_Sales)
            Me.GroupBoxProductionDefaults_AccountCodes.Location = New System.Drawing.Point(4, 4)
            Me.GroupBoxProductionDefaults_AccountCodes.Name = "GroupBoxProductionDefaults_AccountCodes"
            Me.GroupBoxProductionDefaults_AccountCodes.Size = New System.Drawing.Size(984, 212)
            Me.GroupBoxProductionDefaults_AccountCodes.TabIndex = 0
            Me.GroupBoxProductionDefaults_AccountCodes.Text = "Account Codes"
            '
            'SearchableComboBoxProductionDefaults_DeferredCOS
            '
            Me.SearchableComboBoxProductionDefaults_DeferredCOS.ActiveFilterString = ""
            Me.SearchableComboBoxProductionDefaults_DeferredCOS.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxProductionDefaults_DeferredCOS.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxProductionDefaults_DeferredCOS.AutoFillMode = False
            Me.SearchableComboBoxProductionDefaults_DeferredCOS.BookmarkingEnabled = False
            Me.SearchableComboBoxProductionDefaults_DeferredCOS.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.GeneralLedgerAccount
            Me.SearchableComboBoxProductionDefaults_DeferredCOS.DataSource = Nothing
            Me.SearchableComboBoxProductionDefaults_DeferredCOS.DisableMouseWheel = True
            Me.SearchableComboBoxProductionDefaults_DeferredCOS.DisplayName = ""
            Me.SearchableComboBoxProductionDefaults_DeferredCOS.EnterMoveNextControl = True
            Me.SearchableComboBoxProductionDefaults_DeferredCOS.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxProductionDefaults_DeferredCOS.Location = New System.Drawing.Point(114, 181)
            Me.SearchableComboBoxProductionDefaults_DeferredCOS.Name = "SearchableComboBoxProductionDefaults_DeferredCOS"
            Me.SearchableComboBoxProductionDefaults_DeferredCOS.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxProductionDefaults_DeferredCOS.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxProductionDefaults_DeferredCOS.Properties.NullText = "[Please Select]"
            Me.SearchableComboBoxProductionDefaults_DeferredCOS.Properties.PopupView = Me.SearchableComboBoxViewProductionDefaults_DeferredCOS
            Me.SearchableComboBoxProductionDefaults_DeferredCOS.Properties.ValueMember = "Code"
            Me.SearchableComboBoxProductionDefaults_DeferredCOS.SecurityEnabled = True
            Me.SearchableComboBoxProductionDefaults_DeferredCOS.SelectedValue = Nothing
            Me.SearchableComboBoxProductionDefaults_DeferredCOS.Size = New System.Drawing.Size(865, 20)
            Me.SearchableComboBoxProductionDefaults_DeferredCOS.TabIndex = 13
            '
            'SearchableComboBoxViewProductionDefaults_DeferredCOS
            '
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS.AFActiveFilterString = ""
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS.DataSourceClearing = False
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS.EnableDisabledRows = False
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS.Name = "SearchableComboBoxViewProductionDefaults_DeferredCOS"
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS.RunStandardValidation = True
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS.SkipAddingControlsOnModifyColumn = False
            Me.SearchableComboBoxViewProductionDefaults_DeferredCOS.SkipSettingFontOnModifyColumn = False
            '
            'SearchableComboBoxProductionDefaults_AccruedAP
            '
            Me.SearchableComboBoxProductionDefaults_AccruedAP.ActiveFilterString = ""
            Me.SearchableComboBoxProductionDefaults_AccruedAP.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxProductionDefaults_AccruedAP.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxProductionDefaults_AccruedAP.AutoFillMode = False
            Me.SearchableComboBoxProductionDefaults_AccruedAP.BookmarkingEnabled = False
            Me.SearchableComboBoxProductionDefaults_AccruedAP.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.GeneralLedgerAccount
            Me.SearchableComboBoxProductionDefaults_AccruedAP.DataSource = Nothing
            Me.SearchableComboBoxProductionDefaults_AccruedAP.DisableMouseWheel = True
            Me.SearchableComboBoxProductionDefaults_AccruedAP.DisplayName = ""
            Me.SearchableComboBoxProductionDefaults_AccruedAP.EnterMoveNextControl = True
            Me.SearchableComboBoxProductionDefaults_AccruedAP.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxProductionDefaults_AccruedAP.Location = New System.Drawing.Point(114, 155)
            Me.SearchableComboBoxProductionDefaults_AccruedAP.Name = "SearchableComboBoxProductionDefaults_AccruedAP"
            Me.SearchableComboBoxProductionDefaults_AccruedAP.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxProductionDefaults_AccruedAP.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxProductionDefaults_AccruedAP.Properties.NullText = "[Please Select]"
            Me.SearchableComboBoxProductionDefaults_AccruedAP.Properties.PopupView = Me.SearchableComboBoxViewProductionDefaults_AccruedAP
            Me.SearchableComboBoxProductionDefaults_AccruedAP.Properties.ValueMember = "Code"
            Me.SearchableComboBoxProductionDefaults_AccruedAP.SecurityEnabled = True
            Me.SearchableComboBoxProductionDefaults_AccruedAP.SelectedValue = Nothing
            Me.SearchableComboBoxProductionDefaults_AccruedAP.Size = New System.Drawing.Size(865, 20)
            Me.SearchableComboBoxProductionDefaults_AccruedAP.TabIndex = 11
            '
            'SearchableComboBoxViewProductionDefaults_AccruedAP
            '
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP.AFActiveFilterString = ""
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP.DataSourceClearing = False
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP.EnableDisabledRows = False
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP.Name = "SearchableComboBoxViewProductionDefaults_AccruedAP"
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP.RunStandardValidation = True
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP.SkipAddingControlsOnModifyColumn = False
            Me.SearchableComboBoxViewProductionDefaults_AccruedAP.SkipSettingFontOnModifyColumn = False
            '
            'SearchableComboBoxProductionDefaults_AccruedCOS
            '
            Me.SearchableComboBoxProductionDefaults_AccruedCOS.ActiveFilterString = ""
            Me.SearchableComboBoxProductionDefaults_AccruedCOS.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxProductionDefaults_AccruedCOS.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxProductionDefaults_AccruedCOS.AutoFillMode = False
            Me.SearchableComboBoxProductionDefaults_AccruedCOS.BookmarkingEnabled = False
            Me.SearchableComboBoxProductionDefaults_AccruedCOS.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.GeneralLedgerAccount
            Me.SearchableComboBoxProductionDefaults_AccruedCOS.DataSource = Nothing
            Me.SearchableComboBoxProductionDefaults_AccruedCOS.DisableMouseWheel = True
            Me.SearchableComboBoxProductionDefaults_AccruedCOS.DisplayName = ""
            Me.SearchableComboBoxProductionDefaults_AccruedCOS.EnterMoveNextControl = True
            Me.SearchableComboBoxProductionDefaults_AccruedCOS.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxProductionDefaults_AccruedCOS.Location = New System.Drawing.Point(114, 129)
            Me.SearchableComboBoxProductionDefaults_AccruedCOS.Name = "SearchableComboBoxProductionDefaults_AccruedCOS"
            Me.SearchableComboBoxProductionDefaults_AccruedCOS.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxProductionDefaults_AccruedCOS.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxProductionDefaults_AccruedCOS.Properties.NullText = "[Please Select]"
            Me.SearchableComboBoxProductionDefaults_AccruedCOS.Properties.PopupView = Me.SearchableComboBoxViewProductionDefaults_AccruedCOS
            Me.SearchableComboBoxProductionDefaults_AccruedCOS.Properties.ValueMember = "Code"
            Me.SearchableComboBoxProductionDefaults_AccruedCOS.SecurityEnabled = True
            Me.SearchableComboBoxProductionDefaults_AccruedCOS.SelectedValue = Nothing
            Me.SearchableComboBoxProductionDefaults_AccruedCOS.Size = New System.Drawing.Size(865, 20)
            Me.SearchableComboBoxProductionDefaults_AccruedCOS.TabIndex = 9
            '
            'SearchableComboBoxViewProductionDefaults_AccruedCOS
            '
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS.AFActiveFilterString = ""
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS.DataSourceClearing = False
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS.EnableDisabledRows = False
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS.Name = "SearchableComboBoxViewProductionDefaults_AccruedCOS"
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS.RunStandardValidation = True
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS.SkipAddingControlsOnModifyColumn = False
            Me.SearchableComboBoxViewProductionDefaults_AccruedCOS.SkipSettingFontOnModifyColumn = False
            '
            'SearchableComboBoxProductionDefaults_DeferredSales
            '
            Me.SearchableComboBoxProductionDefaults_DeferredSales.ActiveFilterString = ""
            Me.SearchableComboBoxProductionDefaults_DeferredSales.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxProductionDefaults_DeferredSales.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxProductionDefaults_DeferredSales.AutoFillMode = False
            Me.SearchableComboBoxProductionDefaults_DeferredSales.BookmarkingEnabled = False
            Me.SearchableComboBoxProductionDefaults_DeferredSales.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.GeneralLedgerAccount
            Me.SearchableComboBoxProductionDefaults_DeferredSales.DataSource = Nothing
            Me.SearchableComboBoxProductionDefaults_DeferredSales.DisableMouseWheel = True
            Me.SearchableComboBoxProductionDefaults_DeferredSales.DisplayName = ""
            Me.SearchableComboBoxProductionDefaults_DeferredSales.EnterMoveNextControl = True
            Me.SearchableComboBoxProductionDefaults_DeferredSales.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxProductionDefaults_DeferredSales.Location = New System.Drawing.Point(114, 103)
            Me.SearchableComboBoxProductionDefaults_DeferredSales.Name = "SearchableComboBoxProductionDefaults_DeferredSales"
            Me.SearchableComboBoxProductionDefaults_DeferredSales.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxProductionDefaults_DeferredSales.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxProductionDefaults_DeferredSales.Properties.NullText = "[Please Select]"
            Me.SearchableComboBoxProductionDefaults_DeferredSales.Properties.PopupView = Me.SearchableComboBoxViewProductionDefaults_DeferredSales
            Me.SearchableComboBoxProductionDefaults_DeferredSales.Properties.ValueMember = "Code"
            Me.SearchableComboBoxProductionDefaults_DeferredSales.SecurityEnabled = True
            Me.SearchableComboBoxProductionDefaults_DeferredSales.SelectedValue = Nothing
            Me.SearchableComboBoxProductionDefaults_DeferredSales.Size = New System.Drawing.Size(865, 20)
            Me.SearchableComboBoxProductionDefaults_DeferredSales.TabIndex = 7
            '
            'SearchableComboBoxViewProductionDefaults_DeferredSales
            '
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales.AFActiveFilterString = ""
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales.DataSourceClearing = False
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales.EnableDisabledRows = False
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales.Name = "SearchableComboBoxViewProductionDefaults_DeferredSales"
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales.RunStandardValidation = True
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales.SkipAddingControlsOnModifyColumn = False
            Me.SearchableComboBoxViewProductionDefaults_DeferredSales.SkipSettingFontOnModifyColumn = False
            '
            'SearchableComboBoxProductionDefaults_WIP
            '
            Me.SearchableComboBoxProductionDefaults_WIP.ActiveFilterString = ""
            Me.SearchableComboBoxProductionDefaults_WIP.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxProductionDefaults_WIP.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxProductionDefaults_WIP.AutoFillMode = False
            Me.SearchableComboBoxProductionDefaults_WIP.BookmarkingEnabled = False
            Me.SearchableComboBoxProductionDefaults_WIP.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.GeneralLedgerAccount
            Me.SearchableComboBoxProductionDefaults_WIP.DataSource = Nothing
            Me.SearchableComboBoxProductionDefaults_WIP.DisableMouseWheel = True
            Me.SearchableComboBoxProductionDefaults_WIP.DisplayName = ""
            Me.SearchableComboBoxProductionDefaults_WIP.EnterMoveNextControl = True
            Me.SearchableComboBoxProductionDefaults_WIP.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxProductionDefaults_WIP.Location = New System.Drawing.Point(114, 77)
            Me.SearchableComboBoxProductionDefaults_WIP.Name = "SearchableComboBoxProductionDefaults_WIP"
            Me.SearchableComboBoxProductionDefaults_WIP.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxProductionDefaults_WIP.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxProductionDefaults_WIP.Properties.NullText = "[Please Select]"
            Me.SearchableComboBoxProductionDefaults_WIP.Properties.PopupView = Me.SearchableComboBoxViewProductionDefaults_WIP
            Me.SearchableComboBoxProductionDefaults_WIP.Properties.ValueMember = "Code"
            Me.SearchableComboBoxProductionDefaults_WIP.SecurityEnabled = True
            Me.SearchableComboBoxProductionDefaults_WIP.SelectedValue = Nothing
            Me.SearchableComboBoxProductionDefaults_WIP.Size = New System.Drawing.Size(865, 20)
            Me.SearchableComboBoxProductionDefaults_WIP.TabIndex = 5
            '
            'SearchableComboBoxViewProductionDefaults_WIP
            '
            Me.SearchableComboBoxViewProductionDefaults_WIP.AFActiveFilterString = ""
            Me.SearchableComboBoxViewProductionDefaults_WIP.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewProductionDefaults_WIP.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_WIP.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_WIP.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_WIP.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_WIP.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_WIP.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_WIP.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_WIP.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_WIP.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_WIP.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_WIP.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_WIP.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_WIP.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_WIP.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_WIP.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_WIP.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_WIP.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_WIP.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_WIP.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_WIP.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_WIP.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_WIP.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_WIP.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_WIP.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_WIP.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_WIP.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_WIP.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_WIP.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_WIP.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_WIP.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_WIP.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_WIP.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_WIP.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_WIP.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_WIP.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_WIP.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_WIP.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_WIP.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewProductionDefaults_WIP.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewProductionDefaults_WIP.DataSourceClearing = False
            Me.SearchableComboBoxViewProductionDefaults_WIP.EnableDisabledRows = False
            Me.SearchableComboBoxViewProductionDefaults_WIP.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewProductionDefaults_WIP.Name = "SearchableComboBoxViewProductionDefaults_WIP"
            Me.SearchableComboBoxViewProductionDefaults_WIP.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewProductionDefaults_WIP.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewProductionDefaults_WIP.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewProductionDefaults_WIP.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewProductionDefaults_WIP.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewProductionDefaults_WIP.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewProductionDefaults_WIP.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewProductionDefaults_WIP.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewProductionDefaults_WIP.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewProductionDefaults_WIP.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewProductionDefaults_WIP.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewProductionDefaults_WIP.RunStandardValidation = True
            Me.SearchableComboBoxViewProductionDefaults_WIP.SkipAddingControlsOnModifyColumn = False
            Me.SearchableComboBoxViewProductionDefaults_WIP.SkipSettingFontOnModifyColumn = False
            '
            'SearchableComboBoxProductionDefaults_COS
            '
            Me.SearchableComboBoxProductionDefaults_COS.ActiveFilterString = ""
            Me.SearchableComboBoxProductionDefaults_COS.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxProductionDefaults_COS.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxProductionDefaults_COS.AutoFillMode = False
            Me.SearchableComboBoxProductionDefaults_COS.BookmarkingEnabled = False
            Me.SearchableComboBoxProductionDefaults_COS.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.GeneralLedgerAccount
            Me.SearchableComboBoxProductionDefaults_COS.DataSource = Nothing
            Me.SearchableComboBoxProductionDefaults_COS.DisableMouseWheel = True
            Me.SearchableComboBoxProductionDefaults_COS.DisplayName = ""
            Me.SearchableComboBoxProductionDefaults_COS.EnterMoveNextControl = True
            Me.SearchableComboBoxProductionDefaults_COS.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxProductionDefaults_COS.Location = New System.Drawing.Point(114, 51)
            Me.SearchableComboBoxProductionDefaults_COS.Name = "SearchableComboBoxProductionDefaults_COS"
            Me.SearchableComboBoxProductionDefaults_COS.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxProductionDefaults_COS.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxProductionDefaults_COS.Properties.NullText = "[Please Select]"
            Me.SearchableComboBoxProductionDefaults_COS.Properties.PopupView = Me.SearchableComboBoxViewProductionDefaults_COS
            Me.SearchableComboBoxProductionDefaults_COS.Properties.ValueMember = "Code"
            Me.SearchableComboBoxProductionDefaults_COS.SecurityEnabled = True
            Me.SearchableComboBoxProductionDefaults_COS.SelectedValue = Nothing
            Me.SearchableComboBoxProductionDefaults_COS.Size = New System.Drawing.Size(865, 20)
            Me.SearchableComboBoxProductionDefaults_COS.TabIndex = 3
            '
            'SearchableComboBoxViewProductionDefaults_COS
            '
            Me.SearchableComboBoxViewProductionDefaults_COS.AFActiveFilterString = ""
            Me.SearchableComboBoxViewProductionDefaults_COS.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewProductionDefaults_COS.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_COS.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_COS.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_COS.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_COS.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_COS.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_COS.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_COS.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_COS.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_COS.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_COS.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_COS.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_COS.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_COS.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_COS.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_COS.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_COS.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_COS.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_COS.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_COS.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_COS.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_COS.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_COS.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_COS.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_COS.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_COS.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_COS.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_COS.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_COS.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_COS.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_COS.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_COS.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_COS.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_COS.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_COS.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_COS.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_COS.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_COS.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewProductionDefaults_COS.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewProductionDefaults_COS.DataSourceClearing = False
            Me.SearchableComboBoxViewProductionDefaults_COS.EnableDisabledRows = False
            Me.SearchableComboBoxViewProductionDefaults_COS.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewProductionDefaults_COS.Name = "SearchableComboBoxViewProductionDefaults_COS"
            Me.SearchableComboBoxViewProductionDefaults_COS.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewProductionDefaults_COS.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewProductionDefaults_COS.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewProductionDefaults_COS.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewProductionDefaults_COS.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewProductionDefaults_COS.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewProductionDefaults_COS.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewProductionDefaults_COS.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewProductionDefaults_COS.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewProductionDefaults_COS.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewProductionDefaults_COS.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewProductionDefaults_COS.RunStandardValidation = True
            Me.SearchableComboBoxViewProductionDefaults_COS.SkipAddingControlsOnModifyColumn = False
            Me.SearchableComboBoxViewProductionDefaults_COS.SkipSettingFontOnModifyColumn = False
            '
            'SearchableComboBoxProductionDefaults_Sales
            '
            Me.SearchableComboBoxProductionDefaults_Sales.ActiveFilterString = ""
            Me.SearchableComboBoxProductionDefaults_Sales.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxProductionDefaults_Sales.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxProductionDefaults_Sales.AutoFillMode = False
            Me.SearchableComboBoxProductionDefaults_Sales.BookmarkingEnabled = False
            Me.SearchableComboBoxProductionDefaults_Sales.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.GeneralLedgerAccount
            Me.SearchableComboBoxProductionDefaults_Sales.DataSource = Nothing
            Me.SearchableComboBoxProductionDefaults_Sales.DisableMouseWheel = True
            Me.SearchableComboBoxProductionDefaults_Sales.DisplayName = ""
            Me.SearchableComboBoxProductionDefaults_Sales.EnterMoveNextControl = True
            Me.SearchableComboBoxProductionDefaults_Sales.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxProductionDefaults_Sales.Location = New System.Drawing.Point(114, 25)
            Me.SearchableComboBoxProductionDefaults_Sales.Name = "SearchableComboBoxProductionDefaults_Sales"
            Me.SearchableComboBoxProductionDefaults_Sales.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxProductionDefaults_Sales.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxProductionDefaults_Sales.Properties.NullText = "[Please Select]"
            Me.SearchableComboBoxProductionDefaults_Sales.Properties.PopupView = Me.SearchableComboBoxViewProductionDefaults_Sales
            Me.SearchableComboBoxProductionDefaults_Sales.Properties.ValueMember = "Code"
            Me.SearchableComboBoxProductionDefaults_Sales.SecurityEnabled = True
            Me.SearchableComboBoxProductionDefaults_Sales.SelectedValue = Nothing
            Me.SearchableComboBoxProductionDefaults_Sales.Size = New System.Drawing.Size(865, 20)
            Me.SearchableComboBoxProductionDefaults_Sales.TabIndex = 1
            '
            'SearchableComboBoxViewProductionDefaults_Sales
            '
            Me.SearchableComboBoxViewProductionDefaults_Sales.AFActiveFilterString = ""
            Me.SearchableComboBoxViewProductionDefaults_Sales.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewProductionDefaults_Sales.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_Sales.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_Sales.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_Sales.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_Sales.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_Sales.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_Sales.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_Sales.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_Sales.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_Sales.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_Sales.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_Sales.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_Sales.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_Sales.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_Sales.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_Sales.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_Sales.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_Sales.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_Sales.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_Sales.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_Sales.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_Sales.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_Sales.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_Sales.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_Sales.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_Sales.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_Sales.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_Sales.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_Sales.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_Sales.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_Sales.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_Sales.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_Sales.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_Sales.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_Sales.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_Sales.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_Sales.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewProductionDefaults_Sales.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewProductionDefaults_Sales.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewProductionDefaults_Sales.DataSourceClearing = False
            Me.SearchableComboBoxViewProductionDefaults_Sales.EnableDisabledRows = False
            Me.SearchableComboBoxViewProductionDefaults_Sales.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewProductionDefaults_Sales.Name = "SearchableComboBoxViewProductionDefaults_Sales"
            Me.SearchableComboBoxViewProductionDefaults_Sales.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewProductionDefaults_Sales.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewProductionDefaults_Sales.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewProductionDefaults_Sales.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewProductionDefaults_Sales.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewProductionDefaults_Sales.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewProductionDefaults_Sales.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewProductionDefaults_Sales.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewProductionDefaults_Sales.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewProductionDefaults_Sales.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewProductionDefaults_Sales.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewProductionDefaults_Sales.RunStandardValidation = True
            Me.SearchableComboBoxViewProductionDefaults_Sales.SkipAddingControlsOnModifyColumn = False
            Me.SearchableComboBoxViewProductionDefaults_Sales.SkipSettingFontOnModifyColumn = False
            '
            'LabelProductionDefaults_DeferredCOS
            '
            Me.LabelProductionDefaults_DeferredCOS.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelProductionDefaults_DeferredCOS.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelProductionDefaults_DeferredCOS.Location = New System.Drawing.Point(5, 181)
            Me.LabelProductionDefaults_DeferredCOS.Name = "LabelProductionDefaults_DeferredCOS"
            Me.LabelProductionDefaults_DeferredCOS.Size = New System.Drawing.Size(103, 20)
            Me.LabelProductionDefaults_DeferredCOS.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelProductionDefaults_DeferredCOS.TabIndex = 12
            Me.LabelProductionDefaults_DeferredCOS.Text = "Deferred COS:"
            '
            'LabelProductionDefaults_AccruedAP
            '
            Me.LabelProductionDefaults_AccruedAP.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelProductionDefaults_AccruedAP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelProductionDefaults_AccruedAP.Location = New System.Drawing.Point(5, 155)
            Me.LabelProductionDefaults_AccruedAP.Name = "LabelProductionDefaults_AccruedAP"
            Me.LabelProductionDefaults_AccruedAP.Size = New System.Drawing.Size(103, 20)
            Me.LabelProductionDefaults_AccruedAP.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelProductionDefaults_AccruedAP.TabIndex = 10
            Me.LabelProductionDefaults_AccruedAP.Text = "Accrued A/P:"
            '
            'LabelProductionDefaults_AccruedCOS
            '
            Me.LabelProductionDefaults_AccruedCOS.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelProductionDefaults_AccruedCOS.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelProductionDefaults_AccruedCOS.Location = New System.Drawing.Point(5, 129)
            Me.LabelProductionDefaults_AccruedCOS.Name = "LabelProductionDefaults_AccruedCOS"
            Me.LabelProductionDefaults_AccruedCOS.Size = New System.Drawing.Size(103, 20)
            Me.LabelProductionDefaults_AccruedCOS.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelProductionDefaults_AccruedCOS.TabIndex = 8
            Me.LabelProductionDefaults_AccruedCOS.Text = "Accrued COS:"
            '
            'LabelProductionDefaults_DeferredSales
            '
            Me.LabelProductionDefaults_DeferredSales.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelProductionDefaults_DeferredSales.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelProductionDefaults_DeferredSales.Location = New System.Drawing.Point(5, 103)
            Me.LabelProductionDefaults_DeferredSales.Name = "LabelProductionDefaults_DeferredSales"
            Me.LabelProductionDefaults_DeferredSales.Size = New System.Drawing.Size(103, 20)
            Me.LabelProductionDefaults_DeferredSales.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelProductionDefaults_DeferredSales.TabIndex = 6
            Me.LabelProductionDefaults_DeferredSales.Text = "Deferred Sales:"
            '
            'LabelProductionDefaults_WIP
            '
            Me.LabelProductionDefaults_WIP.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelProductionDefaults_WIP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelProductionDefaults_WIP.Location = New System.Drawing.Point(5, 77)
            Me.LabelProductionDefaults_WIP.Name = "LabelProductionDefaults_WIP"
            Me.LabelProductionDefaults_WIP.Size = New System.Drawing.Size(103, 20)
            Me.LabelProductionDefaults_WIP.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelProductionDefaults_WIP.TabIndex = 4
            Me.LabelProductionDefaults_WIP.Text = "Work in Progress:"
            '
            'LabelProductionDefaults_COS
            '
            Me.LabelProductionDefaults_COS.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelProductionDefaults_COS.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelProductionDefaults_COS.Location = New System.Drawing.Point(5, 51)
            Me.LabelProductionDefaults_COS.Name = "LabelProductionDefaults_COS"
            Me.LabelProductionDefaults_COS.Size = New System.Drawing.Size(103, 20)
            Me.LabelProductionDefaults_COS.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelProductionDefaults_COS.TabIndex = 2
            Me.LabelProductionDefaults_COS.Text = "Cost of Sales:"
            '
            'LabelProductionDefaults_Sales
            '
            Me.LabelProductionDefaults_Sales.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelProductionDefaults_Sales.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelProductionDefaults_Sales.Location = New System.Drawing.Point(5, 25)
            Me.LabelProductionDefaults_Sales.Name = "LabelProductionDefaults_Sales"
            Me.LabelProductionDefaults_Sales.Size = New System.Drawing.Size(103, 20)
            Me.LabelProductionDefaults_Sales.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelProductionDefaults_Sales.TabIndex = 0
            Me.LabelProductionDefaults_Sales.Text = "Sales:"
            '
            'TabItemOffice_ProductionDefaultsTab
            '
            Me.TabItemOffice_ProductionDefaultsTab.AttachedControl = Me.TabControlPanelProductionDefaults_ProductionDefaults
            Me.TabItemOffice_ProductionDefaultsTab.Name = "TabItemOffice_ProductionDefaultsTab"
            Me.TabItemOffice_ProductionDefaultsTab.Text = "Production Defaults"
            '
            'TabControlPanelFunctionAccountsTab_FunctionAccounts
            '
            Me.TabControlPanelFunctionAccountsTab_FunctionAccounts.Controls.Add(Me.DataGridViewFunctionAccounts_FunctionAccounts)
            Me.TabControlPanelFunctionAccountsTab_FunctionAccounts.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelFunctionAccountsTab_FunctionAccounts.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelFunctionAccountsTab_FunctionAccounts.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelFunctionAccountsTab_FunctionAccounts.Name = "TabControlPanelFunctionAccountsTab_FunctionAccounts"
            Me.TabControlPanelFunctionAccountsTab_FunctionAccounts.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelFunctionAccountsTab_FunctionAccounts.Size = New System.Drawing.Size(992, 562)
            Me.TabControlPanelFunctionAccountsTab_FunctionAccounts.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelFunctionAccountsTab_FunctionAccounts.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelFunctionAccountsTab_FunctionAccounts.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelFunctionAccountsTab_FunctionAccounts.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelFunctionAccountsTab_FunctionAccounts.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelFunctionAccountsTab_FunctionAccounts.Style.GradientAngle = 90
            Me.TabControlPanelFunctionAccountsTab_FunctionAccounts.TabIndex = 2
            Me.TabControlPanelFunctionAccountsTab_FunctionAccounts.TabItem = Me.TabItemOffice_FunctionAccountsTab
            '
            'DataGridViewFunctionAccounts_FunctionAccounts
            '
            Me.DataGridViewFunctionAccounts_FunctionAccounts.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewFunctionAccounts_FunctionAccounts.AllowDragAndDrop = False
            Me.DataGridViewFunctionAccounts_FunctionAccounts.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewFunctionAccounts_FunctionAccounts.AllowSelectGroupHeaderRow = True
            Me.DataGridViewFunctionAccounts_FunctionAccounts.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewFunctionAccounts_FunctionAccounts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewFunctionAccounts_FunctionAccounts.AutoFilterLookupColumns = False
            Me.DataGridViewFunctionAccounts_FunctionAccounts.AutoloadRepositoryDatasource = True
            Me.DataGridViewFunctionAccounts_FunctionAccounts.AutoUpdateViewCaption = True
            Me.DataGridViewFunctionAccounts_FunctionAccounts.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewFunctionAccounts_FunctionAccounts.DataSource = Nothing
            Me.DataGridViewFunctionAccounts_FunctionAccounts.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewFunctionAccounts_FunctionAccounts.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewFunctionAccounts_FunctionAccounts.ItemDescription = ""
            Me.DataGridViewFunctionAccounts_FunctionAccounts.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewFunctionAccounts_FunctionAccounts.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewFunctionAccounts_FunctionAccounts.MultiSelect = False
            Me.DataGridViewFunctionAccounts_FunctionAccounts.Name = "DataGridViewFunctionAccounts_FunctionAccounts"
            Me.DataGridViewFunctionAccounts_FunctionAccounts.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewFunctionAccounts_FunctionAccounts.RunStandardValidation = True
            Me.DataGridViewFunctionAccounts_FunctionAccounts.ShowColumnMenuOnRightClick = False
            Me.DataGridViewFunctionAccounts_FunctionAccounts.ShowSelectDeselectAllButtons = False
            Me.DataGridViewFunctionAccounts_FunctionAccounts.Size = New System.Drawing.Size(984, 554)
            Me.DataGridViewFunctionAccounts_FunctionAccounts.TabIndex = 0
            Me.DataGridViewFunctionAccounts_FunctionAccounts.UseEmbeddedNavigator = False
            Me.DataGridViewFunctionAccounts_FunctionAccounts.ViewCaptionHeight = -1
            '
            'TabItemOffice_FunctionAccountsTab
            '
            Me.TabItemOffice_FunctionAccountsTab.AttachedControl = Me.TabControlPanelFunctionAccountsTab_FunctionAccounts
            Me.TabItemOffice_FunctionAccountsTab.Name = "TabItemOffice_FunctionAccountsTab"
            Me.TabItemOffice_FunctionAccountsTab.Text = "Function Accounts"
            '
            'TabControlPanelMediaDefaultsTab_MediaDefaults
            '
            Me.TabControlPanelMediaDefaultsTab_MediaDefaults.Controls.Add(Me.GroupBoxMediaDefaults_PrebillIncomeRecognition)
            Me.TabControlPanelMediaDefaultsTab_MediaDefaults.Controls.Add(Me.GroupBoxMediaDefaults_AccountCodes)
            Me.TabControlPanelMediaDefaultsTab_MediaDefaults.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelMediaDefaultsTab_MediaDefaults.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelMediaDefaultsTab_MediaDefaults.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelMediaDefaultsTab_MediaDefaults.Name = "TabControlPanelMediaDefaultsTab_MediaDefaults"
            Me.TabControlPanelMediaDefaultsTab_MediaDefaults.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelMediaDefaultsTab_MediaDefaults.Size = New System.Drawing.Size(992, 562)
            Me.TabControlPanelMediaDefaultsTab_MediaDefaults.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelMediaDefaultsTab_MediaDefaults.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelMediaDefaultsTab_MediaDefaults.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelMediaDefaultsTab_MediaDefaults.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelMediaDefaultsTab_MediaDefaults.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelMediaDefaultsTab_MediaDefaults.Style.GradientAngle = 90
            Me.TabControlPanelMediaDefaultsTab_MediaDefaults.TabIndex = 4
            Me.TabControlPanelMediaDefaultsTab_MediaDefaults.TabItem = Me.TabItemOffice_MediaDefaultsTab
            '
            'GroupBoxMediaDefaults_PrebillIncomeRecognition
            '
            Me.GroupBoxMediaDefaults_PrebillIncomeRecognition.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxMediaDefaults_PrebillIncomeRecognition.Controls.Add(Me.RadioButtonPrebillIncomeRecognition_CloseDate)
            Me.GroupBoxMediaDefaults_PrebillIncomeRecognition.Controls.Add(Me.RadioButtonPrebillIncomeRecognition_InsertionBroadcastDate)
            Me.GroupBoxMediaDefaults_PrebillIncomeRecognition.Controls.Add(Me.RadioButtonPrebillIncomeRecognition_BillingDate)
            Me.GroupBoxMediaDefaults_PrebillIncomeRecognition.Location = New System.Drawing.Point(4, 222)
            Me.GroupBoxMediaDefaults_PrebillIncomeRecognition.Name = "GroupBoxMediaDefaults_PrebillIncomeRecognition"
            Me.GroupBoxMediaDefaults_PrebillIncomeRecognition.Size = New System.Drawing.Size(984, 55)
            Me.GroupBoxMediaDefaults_PrebillIncomeRecognition.TabIndex = 1
            Me.GroupBoxMediaDefaults_PrebillIncomeRecognition.Text = "Prebill Income Recognition"
            '
            'RadioButtonPrebillIncomeRecognition_CloseDate
            '
            Me.RadioButtonPrebillIncomeRecognition_CloseDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonPrebillIncomeRecognition_CloseDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonPrebillIncomeRecognition_CloseDate.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonPrebillIncomeRecognition_CloseDate.CheckValue = "0"
            Me.RadioButtonPrebillIncomeRecognition_CloseDate.CheckValueChecked = "3"
            Me.RadioButtonPrebillIncomeRecognition_CloseDate.CheckValueUnchecked = "0"
            Me.RadioButtonPrebillIncomeRecognition_CloseDate.Location = New System.Drawing.Point(241, 25)
            Me.RadioButtonPrebillIncomeRecognition_CloseDate.Name = "RadioButtonPrebillIncomeRecognition_CloseDate"
            Me.RadioButtonPrebillIncomeRecognition_CloseDate.SecurityEnabled = True
            Me.RadioButtonPrebillIncomeRecognition_CloseDate.Size = New System.Drawing.Size(121, 20)
            Me.RadioButtonPrebillIncomeRecognition_CloseDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonPrebillIncomeRecognition_CloseDate.TabIndex = 2
            Me.RadioButtonPrebillIncomeRecognition_CloseDate.TabOnEnter = True
            Me.RadioButtonPrebillIncomeRecognition_CloseDate.TabStop = False
            Me.RadioButtonPrebillIncomeRecognition_CloseDate.Text = "Close Date"
            '
            'RadioButtonPrebillIncomeRecognition_InsertionBroadcastDate
            '
            Me.RadioButtonPrebillIncomeRecognition_InsertionBroadcastDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonPrebillIncomeRecognition_InsertionBroadcastDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonPrebillIncomeRecognition_InsertionBroadcastDate.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonPrebillIncomeRecognition_InsertionBroadcastDate.CheckValue = "0"
            Me.RadioButtonPrebillIncomeRecognition_InsertionBroadcastDate.CheckValueChecked = "3"
            Me.RadioButtonPrebillIncomeRecognition_InsertionBroadcastDate.CheckValueUnchecked = "0"
            Me.RadioButtonPrebillIncomeRecognition_InsertionBroadcastDate.Location = New System.Drawing.Point(114, 25)
            Me.RadioButtonPrebillIncomeRecognition_InsertionBroadcastDate.Name = "RadioButtonPrebillIncomeRecognition_InsertionBroadcastDate"
            Me.RadioButtonPrebillIncomeRecognition_InsertionBroadcastDate.SecurityEnabled = True
            Me.RadioButtonPrebillIncomeRecognition_InsertionBroadcastDate.Size = New System.Drawing.Size(121, 20)
            Me.RadioButtonPrebillIncomeRecognition_InsertionBroadcastDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonPrebillIncomeRecognition_InsertionBroadcastDate.TabIndex = 1
            Me.RadioButtonPrebillIncomeRecognition_InsertionBroadcastDate.TabOnEnter = True
            Me.RadioButtonPrebillIncomeRecognition_InsertionBroadcastDate.TabStop = False
            Me.RadioButtonPrebillIncomeRecognition_InsertionBroadcastDate.Text = "Insertion/Broadcast Date"
            '
            'RadioButtonPrebillIncomeRecognition_BillingDate
            '
            Me.RadioButtonPrebillIncomeRecognition_BillingDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonPrebillIncomeRecognition_BillingDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonPrebillIncomeRecognition_BillingDate.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonPrebillIncomeRecognition_BillingDate.CheckValue = "0"
            Me.RadioButtonPrebillIncomeRecognition_BillingDate.CheckValueChecked = "1"
            Me.RadioButtonPrebillIncomeRecognition_BillingDate.CheckValueUnchecked = "0"
            Me.RadioButtonPrebillIncomeRecognition_BillingDate.Location = New System.Drawing.Point(5, 25)
            Me.RadioButtonPrebillIncomeRecognition_BillingDate.Name = "RadioButtonPrebillIncomeRecognition_BillingDate"
            Me.RadioButtonPrebillIncomeRecognition_BillingDate.SecurityEnabled = True
            Me.RadioButtonPrebillIncomeRecognition_BillingDate.Size = New System.Drawing.Size(103, 20)
            Me.RadioButtonPrebillIncomeRecognition_BillingDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonPrebillIncomeRecognition_BillingDate.TabIndex = 0
            Me.RadioButtonPrebillIncomeRecognition_BillingDate.TabOnEnter = True
            Me.RadioButtonPrebillIncomeRecognition_BillingDate.TabStop = False
            Me.RadioButtonPrebillIncomeRecognition_BillingDate.Text = "Billing Date"
            '
            'GroupBoxMediaDefaults_AccountCodes
            '
            Me.GroupBoxMediaDefaults_AccountCodes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxMediaDefaults_AccountCodes.Controls.Add(Me.SearchableComboBoxMediaDefaults_DeferredCOS)
            Me.GroupBoxMediaDefaults_AccountCodes.Controls.Add(Me.SearchableComboBoxMediaDefaults_AccruedAP)
            Me.GroupBoxMediaDefaults_AccountCodes.Controls.Add(Me.SearchableComboBoxMediaDefaults_AccruedCOS)
            Me.GroupBoxMediaDefaults_AccountCodes.Controls.Add(Me.SearchableComboBoxMediaDefaults_DeferredSales)
            Me.GroupBoxMediaDefaults_AccountCodes.Controls.Add(Me.SearchableComboBoxMediaDefaults_WIP)
            Me.GroupBoxMediaDefaults_AccountCodes.Controls.Add(Me.SearchableComboBoxMediaDefaults_COS)
            Me.GroupBoxMediaDefaults_AccountCodes.Controls.Add(Me.SearchableComboBoxMediaDefaults_Sales)
            Me.GroupBoxMediaDefaults_AccountCodes.Controls.Add(Me.LabelMediaDefaults_DeferredCOS)
            Me.GroupBoxMediaDefaults_AccountCodes.Controls.Add(Me.LabelMediaDefaults_AccruedAP)
            Me.GroupBoxMediaDefaults_AccountCodes.Controls.Add(Me.LabelMediaDefaults_AccruedCOS)
            Me.GroupBoxMediaDefaults_AccountCodes.Controls.Add(Me.LabelMediaDefaults_DeferredSales)
            Me.GroupBoxMediaDefaults_AccountCodes.Controls.Add(Me.LabelMediaDefaults_WIP)
            Me.GroupBoxMediaDefaults_AccountCodes.Controls.Add(Me.LabelMediaDefaults_COS)
            Me.GroupBoxMediaDefaults_AccountCodes.Controls.Add(Me.LabelMediaDefaults_Sales)
            Me.GroupBoxMediaDefaults_AccountCodes.Location = New System.Drawing.Point(4, 4)
            Me.GroupBoxMediaDefaults_AccountCodes.Name = "GroupBoxMediaDefaults_AccountCodes"
            Me.GroupBoxMediaDefaults_AccountCodes.Size = New System.Drawing.Size(984, 212)
            Me.GroupBoxMediaDefaults_AccountCodes.TabIndex = 0
            Me.GroupBoxMediaDefaults_AccountCodes.Text = "Account Codes"
            '
            'SearchableComboBoxMediaDefaults_DeferredCOS
            '
            Me.SearchableComboBoxMediaDefaults_DeferredCOS.ActiveFilterString = ""
            Me.SearchableComboBoxMediaDefaults_DeferredCOS.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxMediaDefaults_DeferredCOS.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxMediaDefaults_DeferredCOS.AutoFillMode = False
            Me.SearchableComboBoxMediaDefaults_DeferredCOS.BookmarkingEnabled = False
            Me.SearchableComboBoxMediaDefaults_DeferredCOS.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.GeneralLedgerAccount
            Me.SearchableComboBoxMediaDefaults_DeferredCOS.DataSource = Nothing
            Me.SearchableComboBoxMediaDefaults_DeferredCOS.DisableMouseWheel = True
            Me.SearchableComboBoxMediaDefaults_DeferredCOS.DisplayName = ""
            Me.SearchableComboBoxMediaDefaults_DeferredCOS.EnterMoveNextControl = True
            Me.SearchableComboBoxMediaDefaults_DeferredCOS.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxMediaDefaults_DeferredCOS.Location = New System.Drawing.Point(114, 181)
            Me.SearchableComboBoxMediaDefaults_DeferredCOS.Name = "SearchableComboBoxMediaDefaults_DeferredCOS"
            Me.SearchableComboBoxMediaDefaults_DeferredCOS.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxMediaDefaults_DeferredCOS.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxMediaDefaults_DeferredCOS.Properties.NullText = "[Please Select]"
            Me.SearchableComboBoxMediaDefaults_DeferredCOS.Properties.PopupView = Me.SearchableComboBoxViewMediaDefaults_DeferredCOS
            Me.SearchableComboBoxMediaDefaults_DeferredCOS.Properties.ValueMember = "Code"
            Me.SearchableComboBoxMediaDefaults_DeferredCOS.SecurityEnabled = True
            Me.SearchableComboBoxMediaDefaults_DeferredCOS.SelectedValue = Nothing
            Me.SearchableComboBoxMediaDefaults_DeferredCOS.Size = New System.Drawing.Size(865, 20)
            Me.SearchableComboBoxMediaDefaults_DeferredCOS.TabIndex = 13
            '
            'SearchableComboBoxViewMediaDefaults_DeferredCOS
            '
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS.AFActiveFilterString = ""
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS.DataSourceClearing = False
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS.EnableDisabledRows = False
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS.Name = "SearchableComboBoxViewMediaDefaults_DeferredCOS"
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS.RunStandardValidation = True
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS.SkipAddingControlsOnModifyColumn = False
            Me.SearchableComboBoxViewMediaDefaults_DeferredCOS.SkipSettingFontOnModifyColumn = False
            '
            'SearchableComboBoxMediaDefaults_AccruedAP
            '
            Me.SearchableComboBoxMediaDefaults_AccruedAP.ActiveFilterString = ""
            Me.SearchableComboBoxMediaDefaults_AccruedAP.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxMediaDefaults_AccruedAP.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxMediaDefaults_AccruedAP.AutoFillMode = False
            Me.SearchableComboBoxMediaDefaults_AccruedAP.BookmarkingEnabled = False
            Me.SearchableComboBoxMediaDefaults_AccruedAP.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.GeneralLedgerAccount
            Me.SearchableComboBoxMediaDefaults_AccruedAP.DataSource = Nothing
            Me.SearchableComboBoxMediaDefaults_AccruedAP.DisableMouseWheel = True
            Me.SearchableComboBoxMediaDefaults_AccruedAP.DisplayName = ""
            Me.SearchableComboBoxMediaDefaults_AccruedAP.EnterMoveNextControl = True
            Me.SearchableComboBoxMediaDefaults_AccruedAP.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxMediaDefaults_AccruedAP.Location = New System.Drawing.Point(114, 155)
            Me.SearchableComboBoxMediaDefaults_AccruedAP.Name = "SearchableComboBoxMediaDefaults_AccruedAP"
            Me.SearchableComboBoxMediaDefaults_AccruedAP.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxMediaDefaults_AccruedAP.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxMediaDefaults_AccruedAP.Properties.NullText = "[Please Select]"
            Me.SearchableComboBoxMediaDefaults_AccruedAP.Properties.PopupView = Me.SearchableComboBoxViewMediaDefaults_AccruedAP
            Me.SearchableComboBoxMediaDefaults_AccruedAP.Properties.ValueMember = "Code"
            Me.SearchableComboBoxMediaDefaults_AccruedAP.SecurityEnabled = True
            Me.SearchableComboBoxMediaDefaults_AccruedAP.SelectedValue = Nothing
            Me.SearchableComboBoxMediaDefaults_AccruedAP.Size = New System.Drawing.Size(865, 20)
            Me.SearchableComboBoxMediaDefaults_AccruedAP.TabIndex = 11
            '
            'SearchableComboBoxViewMediaDefaults_AccruedAP
            '
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP.AFActiveFilterString = ""
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP.DataSourceClearing = False
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP.EnableDisabledRows = False
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP.Name = "SearchableComboBoxViewMediaDefaults_AccruedAP"
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP.RunStandardValidation = True
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP.SkipAddingControlsOnModifyColumn = False
            Me.SearchableComboBoxViewMediaDefaults_AccruedAP.SkipSettingFontOnModifyColumn = False
            '
            'SearchableComboBoxMediaDefaults_AccruedCOS
            '
            Me.SearchableComboBoxMediaDefaults_AccruedCOS.ActiveFilterString = ""
            Me.SearchableComboBoxMediaDefaults_AccruedCOS.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxMediaDefaults_AccruedCOS.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxMediaDefaults_AccruedCOS.AutoFillMode = False
            Me.SearchableComboBoxMediaDefaults_AccruedCOS.BookmarkingEnabled = False
            Me.SearchableComboBoxMediaDefaults_AccruedCOS.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.GeneralLedgerAccount
            Me.SearchableComboBoxMediaDefaults_AccruedCOS.DataSource = Nothing
            Me.SearchableComboBoxMediaDefaults_AccruedCOS.DisableMouseWheel = True
            Me.SearchableComboBoxMediaDefaults_AccruedCOS.DisplayName = ""
            Me.SearchableComboBoxMediaDefaults_AccruedCOS.EnterMoveNextControl = True
            Me.SearchableComboBoxMediaDefaults_AccruedCOS.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxMediaDefaults_AccruedCOS.Location = New System.Drawing.Point(114, 129)
            Me.SearchableComboBoxMediaDefaults_AccruedCOS.Name = "SearchableComboBoxMediaDefaults_AccruedCOS"
            Me.SearchableComboBoxMediaDefaults_AccruedCOS.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxMediaDefaults_AccruedCOS.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxMediaDefaults_AccruedCOS.Properties.NullText = "[Please Select]"
            Me.SearchableComboBoxMediaDefaults_AccruedCOS.Properties.PopupView = Me.SearchableComboBoxViewMediaDefaults_AccruedCOS
            Me.SearchableComboBoxMediaDefaults_AccruedCOS.Properties.ValueMember = "Code"
            Me.SearchableComboBoxMediaDefaults_AccruedCOS.SecurityEnabled = True
            Me.SearchableComboBoxMediaDefaults_AccruedCOS.SelectedValue = Nothing
            Me.SearchableComboBoxMediaDefaults_AccruedCOS.Size = New System.Drawing.Size(865, 20)
            Me.SearchableComboBoxMediaDefaults_AccruedCOS.TabIndex = 9
            '
            'SearchableComboBoxViewMediaDefaults_AccruedCOS
            '
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS.AFActiveFilterString = ""
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS.DataSourceClearing = False
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS.EnableDisabledRows = False
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS.Name = "SearchableComboBoxViewMediaDefaults_AccruedCOS"
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS.RunStandardValidation = True
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS.SkipAddingControlsOnModifyColumn = False
            Me.SearchableComboBoxViewMediaDefaults_AccruedCOS.SkipSettingFontOnModifyColumn = False
            '
            'SearchableComboBoxMediaDefaults_DeferredSales
            '
            Me.SearchableComboBoxMediaDefaults_DeferredSales.ActiveFilterString = ""
            Me.SearchableComboBoxMediaDefaults_DeferredSales.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxMediaDefaults_DeferredSales.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxMediaDefaults_DeferredSales.AutoFillMode = False
            Me.SearchableComboBoxMediaDefaults_DeferredSales.BookmarkingEnabled = False
            Me.SearchableComboBoxMediaDefaults_DeferredSales.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.GeneralLedgerAccount
            Me.SearchableComboBoxMediaDefaults_DeferredSales.DataSource = Nothing
            Me.SearchableComboBoxMediaDefaults_DeferredSales.DisableMouseWheel = True
            Me.SearchableComboBoxMediaDefaults_DeferredSales.DisplayName = ""
            Me.SearchableComboBoxMediaDefaults_DeferredSales.EnterMoveNextControl = True
            Me.SearchableComboBoxMediaDefaults_DeferredSales.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxMediaDefaults_DeferredSales.Location = New System.Drawing.Point(114, 103)
            Me.SearchableComboBoxMediaDefaults_DeferredSales.Name = "SearchableComboBoxMediaDefaults_DeferredSales"
            Me.SearchableComboBoxMediaDefaults_DeferredSales.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxMediaDefaults_DeferredSales.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxMediaDefaults_DeferredSales.Properties.NullText = "[Please Select]"
            Me.SearchableComboBoxMediaDefaults_DeferredSales.Properties.PopupView = Me.SearchableComboBoxViewMediaDefaults_DeferredSales
            Me.SearchableComboBoxMediaDefaults_DeferredSales.Properties.ValueMember = "Code"
            Me.SearchableComboBoxMediaDefaults_DeferredSales.SecurityEnabled = True
            Me.SearchableComboBoxMediaDefaults_DeferredSales.SelectedValue = Nothing
            Me.SearchableComboBoxMediaDefaults_DeferredSales.Size = New System.Drawing.Size(865, 20)
            Me.SearchableComboBoxMediaDefaults_DeferredSales.TabIndex = 7
            '
            'SearchableComboBoxViewMediaDefaults_DeferredSales
            '
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales.AFActiveFilterString = ""
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales.DataSourceClearing = False
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales.EnableDisabledRows = False
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales.Name = "SearchableComboBoxViewMediaDefaults_DeferredSales"
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales.RunStandardValidation = True
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales.SkipAddingControlsOnModifyColumn = False
            Me.SearchableComboBoxViewMediaDefaults_DeferredSales.SkipSettingFontOnModifyColumn = False
            '
            'SearchableComboBoxMediaDefaults_WIP
            '
            Me.SearchableComboBoxMediaDefaults_WIP.ActiveFilterString = ""
            Me.SearchableComboBoxMediaDefaults_WIP.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxMediaDefaults_WIP.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxMediaDefaults_WIP.AutoFillMode = False
            Me.SearchableComboBoxMediaDefaults_WIP.BookmarkingEnabled = False
            Me.SearchableComboBoxMediaDefaults_WIP.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.GeneralLedgerAccount
            Me.SearchableComboBoxMediaDefaults_WIP.DataSource = Nothing
            Me.SearchableComboBoxMediaDefaults_WIP.DisableMouseWheel = True
            Me.SearchableComboBoxMediaDefaults_WIP.DisplayName = ""
            Me.SearchableComboBoxMediaDefaults_WIP.EnterMoveNextControl = True
            Me.SearchableComboBoxMediaDefaults_WIP.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxMediaDefaults_WIP.Location = New System.Drawing.Point(114, 77)
            Me.SearchableComboBoxMediaDefaults_WIP.Name = "SearchableComboBoxMediaDefaults_WIP"
            Me.SearchableComboBoxMediaDefaults_WIP.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxMediaDefaults_WIP.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxMediaDefaults_WIP.Properties.NullText = "[Please Select]"
            Me.SearchableComboBoxMediaDefaults_WIP.Properties.PopupView = Me.SearchableComboBoxViewMediaDefaults_WIP
            Me.SearchableComboBoxMediaDefaults_WIP.Properties.ValueMember = "Code"
            Me.SearchableComboBoxMediaDefaults_WIP.SecurityEnabled = True
            Me.SearchableComboBoxMediaDefaults_WIP.SelectedValue = Nothing
            Me.SearchableComboBoxMediaDefaults_WIP.Size = New System.Drawing.Size(865, 20)
            Me.SearchableComboBoxMediaDefaults_WIP.TabIndex = 5
            '
            'SearchableComboBoxViewMediaDefaults_WIP
            '
            Me.SearchableComboBoxViewMediaDefaults_WIP.AFActiveFilterString = ""
            Me.SearchableComboBoxViewMediaDefaults_WIP.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewMediaDefaults_WIP.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_WIP.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_WIP.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_WIP.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_WIP.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_WIP.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_WIP.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_WIP.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_WIP.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_WIP.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_WIP.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_WIP.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_WIP.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_WIP.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_WIP.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_WIP.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_WIP.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_WIP.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_WIP.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_WIP.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_WIP.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_WIP.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_WIP.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_WIP.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_WIP.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_WIP.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_WIP.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_WIP.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_WIP.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_WIP.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_WIP.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_WIP.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_WIP.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_WIP.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_WIP.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_WIP.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_WIP.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_WIP.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewMediaDefaults_WIP.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewMediaDefaults_WIP.DataSourceClearing = False
            Me.SearchableComboBoxViewMediaDefaults_WIP.EnableDisabledRows = False
            Me.SearchableComboBoxViewMediaDefaults_WIP.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewMediaDefaults_WIP.Name = "SearchableComboBoxViewMediaDefaults_WIP"
            Me.SearchableComboBoxViewMediaDefaults_WIP.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewMediaDefaults_WIP.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewMediaDefaults_WIP.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewMediaDefaults_WIP.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewMediaDefaults_WIP.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewMediaDefaults_WIP.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewMediaDefaults_WIP.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewMediaDefaults_WIP.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewMediaDefaults_WIP.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewMediaDefaults_WIP.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewMediaDefaults_WIP.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewMediaDefaults_WIP.RunStandardValidation = True
            Me.SearchableComboBoxViewMediaDefaults_WIP.SkipAddingControlsOnModifyColumn = False
            Me.SearchableComboBoxViewMediaDefaults_WIP.SkipSettingFontOnModifyColumn = False
            '
            'SearchableComboBoxMediaDefaults_COS
            '
            Me.SearchableComboBoxMediaDefaults_COS.ActiveFilterString = ""
            Me.SearchableComboBoxMediaDefaults_COS.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxMediaDefaults_COS.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxMediaDefaults_COS.AutoFillMode = False
            Me.SearchableComboBoxMediaDefaults_COS.BookmarkingEnabled = False
            Me.SearchableComboBoxMediaDefaults_COS.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.GeneralLedgerAccount
            Me.SearchableComboBoxMediaDefaults_COS.DataSource = Nothing
            Me.SearchableComboBoxMediaDefaults_COS.DisableMouseWheel = True
            Me.SearchableComboBoxMediaDefaults_COS.DisplayName = ""
            Me.SearchableComboBoxMediaDefaults_COS.EnterMoveNextControl = True
            Me.SearchableComboBoxMediaDefaults_COS.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxMediaDefaults_COS.Location = New System.Drawing.Point(114, 51)
            Me.SearchableComboBoxMediaDefaults_COS.Name = "SearchableComboBoxMediaDefaults_COS"
            Me.SearchableComboBoxMediaDefaults_COS.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxMediaDefaults_COS.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxMediaDefaults_COS.Properties.NullText = "[Please Select]"
            Me.SearchableComboBoxMediaDefaults_COS.Properties.PopupView = Me.SearchableComboBoxViewMediaDefaults_COS
            Me.SearchableComboBoxMediaDefaults_COS.Properties.ValueMember = "Code"
            Me.SearchableComboBoxMediaDefaults_COS.SecurityEnabled = True
            Me.SearchableComboBoxMediaDefaults_COS.SelectedValue = Nothing
            Me.SearchableComboBoxMediaDefaults_COS.Size = New System.Drawing.Size(865, 20)
            Me.SearchableComboBoxMediaDefaults_COS.TabIndex = 3
            '
            'SearchableComboBoxViewMediaDefaults_COS
            '
            Me.SearchableComboBoxViewMediaDefaults_COS.AFActiveFilterString = ""
            Me.SearchableComboBoxViewMediaDefaults_COS.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewMediaDefaults_COS.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_COS.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_COS.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_COS.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_COS.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_COS.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_COS.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_COS.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_COS.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_COS.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_COS.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_COS.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_COS.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_COS.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_COS.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_COS.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_COS.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_COS.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_COS.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_COS.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_COS.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_COS.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_COS.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_COS.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_COS.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_COS.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_COS.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_COS.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_COS.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_COS.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_COS.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_COS.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_COS.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_COS.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_COS.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_COS.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_COS.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_COS.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewMediaDefaults_COS.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewMediaDefaults_COS.DataSourceClearing = False
            Me.SearchableComboBoxViewMediaDefaults_COS.EnableDisabledRows = False
            Me.SearchableComboBoxViewMediaDefaults_COS.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewMediaDefaults_COS.Name = "SearchableComboBoxViewMediaDefaults_COS"
            Me.SearchableComboBoxViewMediaDefaults_COS.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewMediaDefaults_COS.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewMediaDefaults_COS.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewMediaDefaults_COS.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewMediaDefaults_COS.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewMediaDefaults_COS.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewMediaDefaults_COS.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewMediaDefaults_COS.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewMediaDefaults_COS.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewMediaDefaults_COS.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewMediaDefaults_COS.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewMediaDefaults_COS.RunStandardValidation = True
            Me.SearchableComboBoxViewMediaDefaults_COS.SkipAddingControlsOnModifyColumn = False
            Me.SearchableComboBoxViewMediaDefaults_COS.SkipSettingFontOnModifyColumn = False
            '
            'SearchableComboBoxMediaDefaults_Sales
            '
            Me.SearchableComboBoxMediaDefaults_Sales.ActiveFilterString = ""
            Me.SearchableComboBoxMediaDefaults_Sales.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxMediaDefaults_Sales.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxMediaDefaults_Sales.AutoFillMode = False
            Me.SearchableComboBoxMediaDefaults_Sales.BookmarkingEnabled = False
            Me.SearchableComboBoxMediaDefaults_Sales.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.GeneralLedgerAccount
            Me.SearchableComboBoxMediaDefaults_Sales.DataSource = Nothing
            Me.SearchableComboBoxMediaDefaults_Sales.DisableMouseWheel = True
            Me.SearchableComboBoxMediaDefaults_Sales.DisplayName = ""
            Me.SearchableComboBoxMediaDefaults_Sales.EnterMoveNextControl = True
            Me.SearchableComboBoxMediaDefaults_Sales.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxMediaDefaults_Sales.Location = New System.Drawing.Point(114, 25)
            Me.SearchableComboBoxMediaDefaults_Sales.Name = "SearchableComboBoxMediaDefaults_Sales"
            Me.SearchableComboBoxMediaDefaults_Sales.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxMediaDefaults_Sales.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxMediaDefaults_Sales.Properties.NullText = "[Please Select]"
            Me.SearchableComboBoxMediaDefaults_Sales.Properties.PopupView = Me.SearchableComboBoxViewMediaDefaults_Sales
            Me.SearchableComboBoxMediaDefaults_Sales.Properties.ValueMember = "Code"
            Me.SearchableComboBoxMediaDefaults_Sales.SecurityEnabled = True
            Me.SearchableComboBoxMediaDefaults_Sales.SelectedValue = Nothing
            Me.SearchableComboBoxMediaDefaults_Sales.Size = New System.Drawing.Size(865, 20)
            Me.SearchableComboBoxMediaDefaults_Sales.TabIndex = 1
            '
            'SearchableComboBoxViewMediaDefaults_Sales
            '
            Me.SearchableComboBoxViewMediaDefaults_Sales.AFActiveFilterString = ""
            Me.SearchableComboBoxViewMediaDefaults_Sales.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewMediaDefaults_Sales.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_Sales.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_Sales.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_Sales.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_Sales.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_Sales.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_Sales.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_Sales.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_Sales.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_Sales.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_Sales.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_Sales.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_Sales.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_Sales.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_Sales.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_Sales.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_Sales.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_Sales.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_Sales.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_Sales.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_Sales.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_Sales.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_Sales.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_Sales.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_Sales.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_Sales.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_Sales.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_Sales.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_Sales.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_Sales.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_Sales.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_Sales.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_Sales.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_Sales.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_Sales.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_Sales.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_Sales.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewMediaDefaults_Sales.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewMediaDefaults_Sales.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewMediaDefaults_Sales.DataSourceClearing = False
            Me.SearchableComboBoxViewMediaDefaults_Sales.EnableDisabledRows = False
            Me.SearchableComboBoxViewMediaDefaults_Sales.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewMediaDefaults_Sales.Name = "SearchableComboBoxViewMediaDefaults_Sales"
            Me.SearchableComboBoxViewMediaDefaults_Sales.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewMediaDefaults_Sales.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewMediaDefaults_Sales.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewMediaDefaults_Sales.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewMediaDefaults_Sales.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewMediaDefaults_Sales.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewMediaDefaults_Sales.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewMediaDefaults_Sales.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewMediaDefaults_Sales.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewMediaDefaults_Sales.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewMediaDefaults_Sales.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewMediaDefaults_Sales.RunStandardValidation = True
            Me.SearchableComboBoxViewMediaDefaults_Sales.SkipAddingControlsOnModifyColumn = False
            Me.SearchableComboBoxViewMediaDefaults_Sales.SkipSettingFontOnModifyColumn = False
            '
            'LabelMediaDefaults_DeferredCOS
            '
            Me.LabelMediaDefaults_DeferredCOS.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMediaDefaults_DeferredCOS.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMediaDefaults_DeferredCOS.Location = New System.Drawing.Point(5, 181)
            Me.LabelMediaDefaults_DeferredCOS.Name = "LabelMediaDefaults_DeferredCOS"
            Me.LabelMediaDefaults_DeferredCOS.Size = New System.Drawing.Size(103, 20)
            Me.LabelMediaDefaults_DeferredCOS.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMediaDefaults_DeferredCOS.TabIndex = 12
            Me.LabelMediaDefaults_DeferredCOS.Text = "Deferred COS:"
            '
            'LabelMediaDefaults_AccruedAP
            '
            Me.LabelMediaDefaults_AccruedAP.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMediaDefaults_AccruedAP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMediaDefaults_AccruedAP.Location = New System.Drawing.Point(5, 155)
            Me.LabelMediaDefaults_AccruedAP.Name = "LabelMediaDefaults_AccruedAP"
            Me.LabelMediaDefaults_AccruedAP.Size = New System.Drawing.Size(103, 20)
            Me.LabelMediaDefaults_AccruedAP.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMediaDefaults_AccruedAP.TabIndex = 10
            Me.LabelMediaDefaults_AccruedAP.Text = "Deferred A/P:"
            '
            'LabelMediaDefaults_AccruedCOS
            '
            Me.LabelMediaDefaults_AccruedCOS.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMediaDefaults_AccruedCOS.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMediaDefaults_AccruedCOS.Location = New System.Drawing.Point(5, 129)
            Me.LabelMediaDefaults_AccruedCOS.Name = "LabelMediaDefaults_AccruedCOS"
            Me.LabelMediaDefaults_AccruedCOS.Size = New System.Drawing.Size(103, 20)
            Me.LabelMediaDefaults_AccruedCOS.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMediaDefaults_AccruedCOS.TabIndex = 8
            Me.LabelMediaDefaults_AccruedCOS.Text = "Accrued COS:"
            '
            'LabelMediaDefaults_DeferredSales
            '
            Me.LabelMediaDefaults_DeferredSales.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMediaDefaults_DeferredSales.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMediaDefaults_DeferredSales.Location = New System.Drawing.Point(5, 103)
            Me.LabelMediaDefaults_DeferredSales.Name = "LabelMediaDefaults_DeferredSales"
            Me.LabelMediaDefaults_DeferredSales.Size = New System.Drawing.Size(103, 20)
            Me.LabelMediaDefaults_DeferredSales.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMediaDefaults_DeferredSales.TabIndex = 6
            Me.LabelMediaDefaults_DeferredSales.Text = "Deferred Sales:"
            '
            'LabelMediaDefaults_WIP
            '
            Me.LabelMediaDefaults_WIP.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMediaDefaults_WIP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMediaDefaults_WIP.Location = New System.Drawing.Point(5, 77)
            Me.LabelMediaDefaults_WIP.Name = "LabelMediaDefaults_WIP"
            Me.LabelMediaDefaults_WIP.Size = New System.Drawing.Size(103, 20)
            Me.LabelMediaDefaults_WIP.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMediaDefaults_WIP.TabIndex = 4
            Me.LabelMediaDefaults_WIP.Text = "Accrued A/P:"
            '
            'LabelMediaDefaults_COS
            '
            Me.LabelMediaDefaults_COS.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMediaDefaults_COS.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMediaDefaults_COS.Location = New System.Drawing.Point(5, 51)
            Me.LabelMediaDefaults_COS.Name = "LabelMediaDefaults_COS"
            Me.LabelMediaDefaults_COS.Size = New System.Drawing.Size(103, 20)
            Me.LabelMediaDefaults_COS.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMediaDefaults_COS.TabIndex = 2
            Me.LabelMediaDefaults_COS.Text = "Cost of Sales:"
            '
            'LabelMediaDefaults_Sales
            '
            Me.LabelMediaDefaults_Sales.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMediaDefaults_Sales.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMediaDefaults_Sales.Location = New System.Drawing.Point(5, 25)
            Me.LabelMediaDefaults_Sales.Name = "LabelMediaDefaults_Sales"
            Me.LabelMediaDefaults_Sales.Size = New System.Drawing.Size(103, 20)
            Me.LabelMediaDefaults_Sales.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMediaDefaults_Sales.TabIndex = 0
            Me.LabelMediaDefaults_Sales.Text = "Sales:"
            '
            'TabItemOffice_MediaDefaultsTab
            '
            Me.TabItemOffice_MediaDefaultsTab.AttachedControl = Me.TabControlPanelMediaDefaultsTab_MediaDefaults
            Me.TabItemOffice_MediaDefaultsTab.Name = "TabItemOffice_MediaDefaultsTab"
            Me.TabItemOffice_MediaDefaultsTab.Text = "Media Defaults"
            '
            'TabControlPanelSalesTaxAccountsTab_SalesTaxAccounts
            '
            Me.TabControlPanelSalesTaxAccountsTab_SalesTaxAccounts.Controls.Add(Me.DataGridViewSalesTaxAccounts_SalesTaxAccounts)
            Me.TabControlPanelSalesTaxAccountsTab_SalesTaxAccounts.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelSalesTaxAccountsTab_SalesTaxAccounts.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelSalesTaxAccountsTab_SalesTaxAccounts.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelSalesTaxAccountsTab_SalesTaxAccounts.Name = "TabControlPanelSalesTaxAccountsTab_SalesTaxAccounts"
            Me.TabControlPanelSalesTaxAccountsTab_SalesTaxAccounts.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelSalesTaxAccountsTab_SalesTaxAccounts.Size = New System.Drawing.Size(992, 562)
            Me.TabControlPanelSalesTaxAccountsTab_SalesTaxAccounts.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelSalesTaxAccountsTab_SalesTaxAccounts.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelSalesTaxAccountsTab_SalesTaxAccounts.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelSalesTaxAccountsTab_SalesTaxAccounts.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelSalesTaxAccountsTab_SalesTaxAccounts.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelSalesTaxAccountsTab_SalesTaxAccounts.Style.GradientAngle = 90
            Me.TabControlPanelSalesTaxAccountsTab_SalesTaxAccounts.TabIndex = 0
            Me.TabControlPanelSalesTaxAccountsTab_SalesTaxAccounts.TabItem = Me.TabItemOffice_SalesTaxAccountsTab
            '
            'DataGridViewSalesTaxAccounts_SalesTaxAccounts
            '
            Me.DataGridViewSalesTaxAccounts_SalesTaxAccounts.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewSalesTaxAccounts_SalesTaxAccounts.AllowDragAndDrop = False
            Me.DataGridViewSalesTaxAccounts_SalesTaxAccounts.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewSalesTaxAccounts_SalesTaxAccounts.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSalesTaxAccounts_SalesTaxAccounts.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewSalesTaxAccounts_SalesTaxAccounts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewSalesTaxAccounts_SalesTaxAccounts.AutoFilterLookupColumns = False
            Me.DataGridViewSalesTaxAccounts_SalesTaxAccounts.AutoloadRepositoryDatasource = True
            Me.DataGridViewSalesTaxAccounts_SalesTaxAccounts.AutoUpdateViewCaption = True
            Me.DataGridViewSalesTaxAccounts_SalesTaxAccounts.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewSalesTaxAccounts_SalesTaxAccounts.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewSalesTaxAccounts_SalesTaxAccounts.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSalesTaxAccounts_SalesTaxAccounts.ItemDescription = ""
            Me.DataGridViewSalesTaxAccounts_SalesTaxAccounts.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewSalesTaxAccounts_SalesTaxAccounts.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewSalesTaxAccounts_SalesTaxAccounts.MultiSelect = False
            Me.DataGridViewSalesTaxAccounts_SalesTaxAccounts.Name = "DataGridViewSalesTaxAccounts_SalesTaxAccounts"
            Me.DataGridViewSalesTaxAccounts_SalesTaxAccounts.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewSalesTaxAccounts_SalesTaxAccounts.RunStandardValidation = True
            Me.DataGridViewSalesTaxAccounts_SalesTaxAccounts.ShowColumnMenuOnRightClick = False
            Me.DataGridViewSalesTaxAccounts_SalesTaxAccounts.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSalesTaxAccounts_SalesTaxAccounts.Size = New System.Drawing.Size(984, 554)
            Me.DataGridViewSalesTaxAccounts_SalesTaxAccounts.TabIndex = 0
            Me.DataGridViewSalesTaxAccounts_SalesTaxAccounts.UseEmbeddedNavigator = False
            Me.DataGridViewSalesTaxAccounts_SalesTaxAccounts.ViewCaptionHeight = -1
            '
            'TabItemOffice_SalesTaxAccountsTab
            '
            Me.TabItemOffice_SalesTaxAccountsTab.AttachedControl = Me.TabControlPanelSalesTaxAccountsTab_SalesTaxAccounts
            Me.TabItemOffice_SalesTaxAccountsTab.Name = "TabItemOffice_SalesTaxAccountsTab"
            Me.TabItemOffice_SalesTaxAccountsTab.Text = "Sales Tax Accounts"
            '
            'PanelControl_Control
            '
            Me.PanelControl_Control.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelControl_Control.Controls.Add(Me.LabelControl_Code)
            Me.PanelControl_Control.Controls.Add(Me.ComboBoxControl_GLXREFCode)
            Me.PanelControl_Control.Controls.Add(Me.TabControlControl_Office)
            Me.PanelControl_Control.Controls.Add(Me.TextBoxControl_Code)
            Me.PanelControl_Control.Controls.Add(Me.LabelControl_GLXREFCode)
            Me.PanelControl_Control.Controls.Add(Me.CheckBoxControl_Inactive)
            Me.PanelControl_Control.Controls.Add(Me.TextBoxControl_Description)
            Me.PanelControl_Control.Controls.Add(Me.LabelControl_Description)
            Me.PanelControl_Control.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelControl_Control.Location = New System.Drawing.Point(0, 0)
            Me.PanelControl_Control.Margin = New System.Windows.Forms.Padding(2)
            Me.PanelControl_Control.Name = "PanelControl_Control"
            Me.PanelControl_Control.Size = New System.Drawing.Size(992, 615)
            Me.PanelControl_Control.TabIndex = 45
            '
            'OfficeControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.PanelControl_Control)
            Me.Name = "OfficeControl"
            Me.Size = New System.Drawing.Size(992, 615)
            CType(Me.TabControlControl_Office, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlControl_Office.ResumeLayout(False)
            Me.TabControlPanelDefaultTab_Default.ResumeLayout(False)
            CType(Me.GroupBoxDefault_SalesTaxAccountCodes, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxDefault_SalesTaxAccountCodes.ResumeLayout(False)
            CType(Me.SearchableComboBoxDefault_CityTaxGLACode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewDefault_CityTaxGLACode, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxDefault_CountyTaxGLACode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewDefault_CountyTaxGLACode, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxDefault_StateTaxGLACode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewDefault_StateTaxGLACode, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxDefault_AccountCodes, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxDefault_AccountCodes.ResumeLayout(False)
            CType(Me.SearchableComboBoxDefault_ClientLatePaymentFeeGLACode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxDefault_SuspenseGLACode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxDefault_AccountsReceivableGLACode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewDefault_AccountsReceivableGLACode, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxDefault_AccountsPayableDiscountGLACode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxDefault_AccountsPayableGLACode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewDefault_AccountsPayableGLACode, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelSalesClassFunctionAccountsTab_SalesClassFunctionAccounts.ResumeLayout(False)
            CType(Me.SearchableComboBoxSalesClassFunctionAccounts_SalesClass.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxSalesClassFunctionAccounts_GLSalesClassFunctionAccounts, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxSalesClassFunctionAccounts_GLSalesClassFunctionAccounts.ResumeLayout(False)
            CType(Me.GroupBoxSalesClassFunctionAccounts_GLSalesClassAccounts, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxSalesClassFunctionAccounts_GLSalesClassAccounts.ResumeLayout(False)
            CType(Me.SearchableComboBoxSalesClassAccounts_MediaCOS.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewSalesClassAccounts_MediaCOS, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxSalesClassAccounts_MediaSales.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewSalesClassAccounts_MediaSales, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxSalesClassAccounts_ProductionCOS.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewSalesClassAccounts_ProductionCOS, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxSalesClassAccounts_ProductionSales.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewSalesClassAccounts_ProductionSales, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelOverheadSetsTab_OverheadSets.ResumeLayout(False)
            Me.TabControlPanelInterCompanyAccounts_InterCompanyAccounts.ResumeLayout(False)
            Me.TabControlPanelDocumentsTab_Documents.ResumeLayout(False)
            Me.TabControlPanelProductionDefaults_ProductionDefaults.ResumeLayout(False)
            CType(Me.GroupBoxProductionDefaults_ABIncomeRecognition, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxProductionDefaults_ABIncomeRecognition.ResumeLayout(False)
            CType(Me.GroupBoxProductionDefaults_AccountCodes, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxProductionDefaults_AccountCodes.ResumeLayout(False)
            CType(Me.SearchableComboBoxProductionDefaults_DeferredCOS.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewProductionDefaults_DeferredCOS, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxProductionDefaults_AccruedAP.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewProductionDefaults_AccruedAP, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxProductionDefaults_AccruedCOS.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewProductionDefaults_AccruedCOS, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxProductionDefaults_DeferredSales.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewProductionDefaults_DeferredSales, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxProductionDefaults_WIP.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewProductionDefaults_WIP, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxProductionDefaults_COS.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewProductionDefaults_COS, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxProductionDefaults_Sales.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewProductionDefaults_Sales, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelFunctionAccountsTab_FunctionAccounts.ResumeLayout(False)
            Me.TabControlPanelMediaDefaultsTab_MediaDefaults.ResumeLayout(False)
            CType(Me.GroupBoxMediaDefaults_PrebillIncomeRecognition, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxMediaDefaults_PrebillIncomeRecognition.ResumeLayout(False)
            CType(Me.GroupBoxMediaDefaults_AccountCodes, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxMediaDefaults_AccountCodes.ResumeLayout(False)
            CType(Me.SearchableComboBoxMediaDefaults_DeferredCOS.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewMediaDefaults_DeferredCOS, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxMediaDefaults_AccruedAP.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewMediaDefaults_AccruedAP, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxMediaDefaults_AccruedCOS.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewMediaDefaults_AccruedCOS, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxMediaDefaults_DeferredSales.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewMediaDefaults_DeferredSales, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxMediaDefaults_WIP.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewMediaDefaults_WIP, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxMediaDefaults_COS.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewMediaDefaults_COS, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxMediaDefaults_Sales.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewMediaDefaults_Sales, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelSalesTaxAccountsTab_SalesTaxAccounts.ResumeLayout(False)
            CType(Me.PanelControl_Control, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelControl_Control.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents TabControlControl_Office As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelDefaultTab_Default As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemOffice_DefaultTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelProductionDefaults_ProductionDefaults As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemOffice_ProductionDefaultsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelFunctionAccountsTab_FunctionAccounts As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabControlPanelSalesClassFunctionAccountsTab_SalesClassFunctionAccounts As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemOffice_SalesClassFunctionAccountsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents GroupBoxDefault_AccountCodes As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents GroupBoxDefault_SalesTaxAccountCodes As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents TabControlPanelMediaDefaultsTab_MediaDefaults As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemOffice_MediaDefaultsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabItemOffice_FunctionAccountsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents CheckBoxControl_Inactive As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents TextBoxControl_Code As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelControl_Code As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelControl_Description As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxControl_Description As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelControl_GLXREFCode As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxControl_GLXREFCode As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelDefault_AccountsReceivableGLACode As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelDefault_AccountsPayableDiscountGLACode As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelDefault_AccountsPayableGLACode As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSalesTaxAccountCodes_CityTaxGLACode As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSalesTaxAccountCodes_CountyTaxGLACode As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSalesTaxAccountCodes_StateTaxGLACode As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSalesClassFunctionAccounts_SalesClass As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxSalesClassFunctionAccounts_GLSalesClassAccounts As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents LabelGLSalesClassAccounts_MediaCOS As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelGLSalesClassAccounts_MediaSales As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelGLSalesClassAccounts_ProductionCOS As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelGLSalesClassAccounts_ProductionSales As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxSalesClassFunctionAccounts_GLSalesClassFunctionAccounts As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents TabControlPanelSalesTaxAccountsTab_SalesTaxAccounts As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemOffice_SalesTaxAccountsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelInterCompanyAccounts_InterCompanyAccounts As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemOffice_InterCompanyAccountsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents GroupBoxProductionDefaults_AccountCodes As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents LabelProductionDefaults_DeferredCOS As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelProductionDefaults_AccruedAP As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelProductionDefaults_AccruedCOS As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelProductionDefaults_DeferredSales As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelProductionDefaults_WIP As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelProductionDefaults_COS As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelProductionDefaults_Sales As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxProductionDefaults_ABIncomeRecognition As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents RadioButtonABIncomeRecognition_InitalBilling As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonABIncomeRecognition_UponReconciliation As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents GroupBoxMediaDefaults_AccountCodes As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents LabelMediaDefaults_DeferredCOS As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelMediaDefaults_AccruedAP As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelMediaDefaults_AccruedCOS As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelMediaDefaults_DeferredSales As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelMediaDefaults_WIP As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelMediaDefaults_COS As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelMediaDefaults_Sales As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxMediaDefaults_PrebillIncomeRecognition As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents RadioButtonPrebillIncomeRecognition_CloseDate As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonPrebillIncomeRecognition_InsertionBroadcastDate As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonPrebillIncomeRecognition_BillingDate As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Private WithEvents DataGridViewInterCompanyAccounts_InterCompanyAccounts As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents DataGridViewGLSalesClassFunctionAccounts_GLSCFA As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Private WithEvents DataGridViewSalesTaxAccounts_SalesTaxAccounts As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents DataGridViewFunctionAccounts_FunctionAccounts As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents SearchableComboBoxDefault_CityTaxGLACode As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewDefault_CityTaxGLACode As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxDefault_CountyTaxGLACode As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewDefault_CountyTaxGLACode As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxDefault_StateTaxGLACode As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewDefault_StateTaxGLACode As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxDefault_AccountsPayableDiscountGLACode As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxDefault_AccountsPayableGLACode As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewDefault_AccountsPayableGLACode As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxMediaDefaults_DeferredCOS As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewMediaDefaults_DeferredCOS As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxMediaDefaults_AccruedAP As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewMediaDefaults_AccruedAP As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxMediaDefaults_AccruedCOS As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewMediaDefaults_AccruedCOS As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxMediaDefaults_DeferredSales As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewMediaDefaults_DeferredSales As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxMediaDefaults_WIP As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewMediaDefaults_WIP As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxMediaDefaults_COS As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewMediaDefaults_COS As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxMediaDefaults_Sales As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewMediaDefaults_Sales As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxSalesClassAccounts_MediaCOS As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewSalesClassAccounts_MediaCOS As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxSalesClassAccounts_MediaSales As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewSalesClassAccounts_MediaSales As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxSalesClassAccounts_ProductionCOS As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewSalesClassAccounts_ProductionCOS As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxSalesClassAccounts_ProductionSales As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewSalesClassAccounts_ProductionSales As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxProductionDefaults_DeferredCOS As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewProductionDefaults_DeferredCOS As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxProductionDefaults_AccruedAP As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewProductionDefaults_AccruedAP As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxProductionDefaults_AccruedCOS As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewProductionDefaults_AccruedCOS As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxProductionDefaults_DeferredSales As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewProductionDefaults_DeferredSales As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxProductionDefaults_WIP As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewProductionDefaults_WIP As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxProductionDefaults_COS As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewProductionDefaults_COS As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxProductionDefaults_Sales As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewProductionDefaults_Sales As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxDefault_AccountsReceivableGLACode As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewDefault_AccountsReceivableGLACode As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents TabControlPanelDocumentsTab_Documents As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DocumentManagerControlDocuments_OfficeDocuments As AdvantageFramework.WinForm.Presentation.Controls.DocumentManagerControl
        Friend WithEvents TabItemOffice_DocumentsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents PanelControl_Control As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents TabControlPanelOverheadSetsTab_OverheadSets As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemOffice_OverheadSetsTab As DevComponents.DotNetBar.TabItem
        Private WithEvents DataGridViewOverheadSets_OverheadSets As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents SearchableComboBoxSalesClassFunctionAccounts_SalesClass As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView1 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents LabelDefault_SuspenseGLACode As Label
        Friend WithEvents SearchableComboBoxDefault_SuspenseGLACode As SearchableComboBox
        Friend WithEvents GridView2 As GridView
        Friend WithEvents LabelDefault_ClientLatePaymentFeeGLACode As Label
        Friend WithEvents SearchableComboBoxDefault_ClientLatePaymentFeeGLACode As SearchableComboBox
        Friend WithEvents SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode As GridView
    End Class

End Namespace
