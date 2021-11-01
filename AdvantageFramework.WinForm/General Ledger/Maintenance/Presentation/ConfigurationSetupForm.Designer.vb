Namespace GeneralLedger.Maintenance.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class ConfigurationSetupForm
        Inherits AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseForm

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConfigurationSetupForm))
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_SegmentTypes = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemSegmentTypes_Edit = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Save = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Cancel = New DevComponents.DotNetBar.ButtonItem()
            Me.TabControlPanel_Tabs = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelStatus_Status = New DevComponents.DotNetBar.TabControlPanel()
            Me.GroupBoxOptions_BudgetMaintenance = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.GroupBoxOptions_LastYearsActualAmounts = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.CheckBoxVarianceToLastYear_IncludeYearEndEntries = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.PanelVarianceToLastYear_Columns = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.RadioButtonVarianceToLastYear_Column6 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonVarianceToLastYear_Column3 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonVarianceToLastYear_Column5 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonVarianceToLastYear_Exclude = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonVarianceToLastYear_Column4 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonVarianceToLastYear_Column2 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonVarianceToLastYear_Column1 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.PanelLastYearsActualAmounts_Columns = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.RadioButtonLastYearsActualAmounts_Column6 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonLastYearsActualAmounts_Column3 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonLastYearsActualAmounts_Column5 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonLastYearsActualAmounts_Exclude = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonLastYearsActualAmounts_Column4 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonLastYearsActualAmounts_Column2 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonLastYearsActualAmounts_Column1 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.LabelBudgetMaintenance_VarianceToLastYear = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.GroupBoxOptions_CurrentBudget = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.PanelVarianceToCurrentBudget_Columns = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.RadioButtonVarianceToCurrentBudget_Column6 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonVarianceToCurrentBudget_Column3 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonVarianceToCurrentBudget_Column5 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonVarianceToCurrentBudget_Exclude = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonVarianceToCurrentBudget_Column4 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonVarianceToCurrentBudget_Column2 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonVarianceToCurrentBudget_Column1 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.PanelCompareUsingCurrentBudget_Columns = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.RadioButtonCompareUsingCurrentBudget_Column6 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonCompareUsingCurrentBudget_Column3 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonCompareUsingCurrentBudget_Column5 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonCompareUsingCurrentBudget_Exclude = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonCompareUsingCurrentBudget_Column4 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonCompareUsingCurrentBudget_Column2 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonCompareUsingCurrentBudget_Column1 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.LabelCurrentBudget_VarianceToCurrentBudget = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelCurrentBudget_CompareUsingCurrentBudget = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.GroupBoxOptions_ClientBudget = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.PanelClientBudget_Columns = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.RadioButtonClientBudget_Column6 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonClientBudget_Column3 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonClientBudget_Column5 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonClientBudget_Exclude = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonClientBudget_Column4 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonClientBudget_Column2 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonClientBudget_Column1 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.GroupBoxOptions_YTDActualAmounts = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.PanelYTDActualAmounts_Columns = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.RadioButtonYTDActualAmounts_Column6 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonYTDActualAmounts_Column3 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonYTDActualAmounts_Column5 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonYTDActualAmounts_Exclude = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonYTDActualAmounts_Column4 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonYTDActualAmounts_Column2 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonYTDActualAmounts_Column1 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.GroupBoxOptions_AccountsToBudget = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.CheckBoxAccountsToBudget_ExpenseCOS = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.CheckBoxAccountsToBudget_ExpenseOperating = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.CheckBoxAccountsToBudget_ExpenseOther = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.CheckBoxAccountsToBudget_ExpenseTaxes = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.CheckBoxAccountsToBudget_IncomeOther = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.CheckBoxAccountsToBudget_Income = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.CheckBoxAccountsToBudget_NonCurrentLiabilities = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.CheckBoxAccountsToBudget_CurrentLiabilities = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.CheckBoxAccountsToBudget_FixedAssets = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.CheckBoxAccountsToBudget_NonCurrentAssets = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.CheckBoxAccountsToBudget_CurrentAssets = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.TabItemTabs_Options = New DevComponents.DotNetBar.TabItem()
            Me.TabControlPanelVendors_Vendors = New DevComponents.DotNetBar.TabControlPanel()
            Me.TextBoxDefaults_DefaultFormat = New System.Windows.Forms.Label()
            Me.LabelDefaults_DefaultFormat = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.GroupBoxDefaults_CurrencyFormat = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.TextBoxCurrencyFormat_CurrencySymbol = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox()
            Me.LabelCurrencyFormat_CurrencySymbol = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.GroupBoxDefaults_PostingPeriodFormat = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.LabelPostingPeriodFormat_Option2 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelPostingPeriodFormat_Option1 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.RadioButtonPostingPeriodFormat_Option2 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonPostingPeriodFormat_Option1 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.GroupBoxDefaults_FiscalYearOptions = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.RadioButtonFiscalYearOptions_BeginsInCurrent = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonFiscalYearOptions_BeginsInPrevious = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.GroupBoxDefaults_AccountCodeFormat = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.Panel2AccountCodeFormat_Segment3 = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.CheckBoxAccountCodeFormat_Segment3Hyphen = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.CheckBoxAccountCodeFormat_Segment3Period = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.LabelAccountCodeFormat_Segment3Or = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelAccountCodeFormat_Segment3After = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelDefaults_FiscalYearStartMonth = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.ComboBoxDefaults_FiscalYearStartMonth = New AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox()
            Me.Panel2AccountCodeFormat_Segment2 = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.CheckBoxAccountCodeFormat_Segment2Hyphen = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.CheckBoxAccountCodeFormat_Segment2Period = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.LabelAccountCodeFormat_Segment2Or = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelAccountCodeFormat_Segment2After = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.Panel1AccountCodeFormat_Segment3 = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.RadioButtonAccountCodeFormat_Segment3Base = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonAccountCodeFormat_Segment3Other = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonAccountCodeFormat_Segment3Office = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonAccountCodeFormat_Segment3Department = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.Panel2AccountCodeFormat_Segment1 = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.CheckBoxAccountCodeFormat_Segment1Hyphen = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.CheckBoxAccountCodeFormat_Segment1Period = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.LabelAccountCodeFormat_Segment1Or = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelAccountCodeFormat_Segment1After = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.Panel1AccountCodeFormat_Segment4 = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.RadioButtonAccountCodeFormat_Segment4Base = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonAccountCodeFormat_Segment4Office = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonAccountCodeFormat_Segment4Department = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonAccountCodeFormat_Segment4Other = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.Panel1AccountCodeFormat_Segment1 = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.RadioButtonAccountCodeFormat_Segment1Other = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonAccountCodeFormat_Segment1Base = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonAccountCodeFormat_Segment1Department = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonAccountCodeFormat_Segment1Office = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.TextBoxAccountCodeFormat_Segment4Description = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox()
            Me.Panel1AccountCodeFormat_Segment2 = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.RadioButtonAccountCodeFormat_Segment2Base = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonAccountCodeFormat_Segment2Other = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonAccountCodeFormat_Segment2Department = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonAccountCodeFormat_Segment2Office = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.TextBoxAccountCodeFormat_Segment4 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox()
            Me.LabelAccountCodeFormat_Segment4 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.TextBoxAccountCodeFormat_Segment3Description = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox()
            Me.TextBoxAccountCodeFormat_Segment3 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox()
            Me.LabelAccountCodeFormat_Segment3 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.TextBoxAccountCodeFormat_Segment2Description = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox()
            Me.TextBoxAccountCodeFormat_Segment2 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox()
            Me.LabelAccountCodeFormat_Segment2 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.TextBoxAccountCodeFormat_Segment1Description = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox()
            Me.TextBoxAccountCodeFormat_Segment1 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox()
            Me.LabelAccountCodeFormat_Segment1 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.TabItemTabs_Defaults = New DevComponents.DotNetBar.TabItem()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            CType(Me.TabControlPanel_Tabs, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanel_Tabs.SuspendLayout()
            Me.TabControlPanelStatus_Status.SuspendLayout()
            CType(Me.GroupBoxOptions_BudgetMaintenance, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxOptions_BudgetMaintenance.SuspendLayout()
            CType(Me.GroupBoxOptions_LastYearsActualAmounts, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxOptions_LastYearsActualAmounts.SuspendLayout()
            CType(Me.PanelVarianceToLastYear_Columns, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelVarianceToLastYear_Columns.SuspendLayout()
            CType(Me.PanelLastYearsActualAmounts_Columns, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelLastYearsActualAmounts_Columns.SuspendLayout()
            CType(Me.GroupBoxOptions_CurrentBudget, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxOptions_CurrentBudget.SuspendLayout()
            CType(Me.PanelVarianceToCurrentBudget_Columns, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelVarianceToCurrentBudget_Columns.SuspendLayout()
            CType(Me.PanelCompareUsingCurrentBudget_Columns, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelCompareUsingCurrentBudget_Columns.SuspendLayout()
            CType(Me.GroupBoxOptions_ClientBudget, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxOptions_ClientBudget.SuspendLayout()
            CType(Me.PanelClientBudget_Columns, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelClientBudget_Columns.SuspendLayout()
            CType(Me.GroupBoxOptions_YTDActualAmounts, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxOptions_YTDActualAmounts.SuspendLayout()
            CType(Me.PanelYTDActualAmounts_Columns, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelYTDActualAmounts_Columns.SuspendLayout()
            CType(Me.GroupBoxOptions_AccountsToBudget, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxOptions_AccountsToBudget.SuspendLayout()
            Me.TabControlPanelVendors_Vendors.SuspendLayout()
            CType(Me.GroupBoxDefaults_CurrencyFormat, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxDefaults_CurrencyFormat.SuspendLayout()
            CType(Me.GroupBoxDefaults_PostingPeriodFormat, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxDefaults_PostingPeriodFormat.SuspendLayout()
            CType(Me.GroupBoxDefaults_FiscalYearOptions, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxDefaults_FiscalYearOptions.SuspendLayout()
            CType(Me.GroupBoxDefaults_AccountCodeFormat, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxDefaults_AccountCodeFormat.SuspendLayout()
            CType(Me.Panel2AccountCodeFormat_Segment3, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel2AccountCodeFormat_Segment3.SuspendLayout()
            CType(Me.Panel2AccountCodeFormat_Segment2, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel2AccountCodeFormat_Segment2.SuspendLayout()
            CType(Me.Panel1AccountCodeFormat_Segment3, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel1AccountCodeFormat_Segment3.SuspendLayout()
            CType(Me.Panel2AccountCodeFormat_Segment1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel2AccountCodeFormat_Segment1.SuspendLayout()
            CType(Me.Panel1AccountCodeFormat_Segment4, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel1AccountCodeFormat_Segment4.SuspendLayout()
            CType(Me.Panel1AccountCodeFormat_Segment1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel1AccountCodeFormat_Segment1.SuspendLayout()
            CType(Me.Panel1AccountCodeFormat_Segment2, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel1AccountCodeFormat_Segment2.SuspendLayout()
            Me.SuspendLayout()
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_SegmentTypes)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(0, 3)
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(473, 98)
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Options.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Options.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Options.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarMergeContainerForm_Options.TabIndex = 3
            Me.RibbonBarMergeContainerForm_Options.Visible = False
            '
            'RibbonBarOptions_SegmentTypes
            '
            Me.RibbonBarOptions_SegmentTypes.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_SegmentTypes.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_SegmentTypes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_SegmentTypes.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_SegmentTypes.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_SegmentTypes.DragDropSupport = True
            Me.RibbonBarOptions_SegmentTypes.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemSegmentTypes_Edit})
            Me.RibbonBarOptions_SegmentTypes.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_SegmentTypes.Location = New System.Drawing.Point(209, 0)
            Me.RibbonBarOptions_SegmentTypes.Name = "RibbonBarOptions_SegmentTypes"
            Me.RibbonBarOptions_SegmentTypes.SecurityEnabled = True
            Me.RibbonBarOptions_SegmentTypes.Size = New System.Drawing.Size(209, 98)
            Me.RibbonBarOptions_SegmentTypes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_SegmentTypes.TabIndex = 1
            Me.RibbonBarOptions_SegmentTypes.Text = "Segment Types"
            '
            '
            '
            Me.RibbonBarOptions_SegmentTypes.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_SegmentTypes.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_SegmentTypes.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemSegmentTypes_Edit
            '
            Me.ButtonItemSegmentTypes_Edit.BeginGroup = True
            Me.ButtonItemSegmentTypes_Edit.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemSegmentTypes_Edit.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemSegmentTypes_Edit.Name = "ButtonItemSegmentTypes_Edit"
            Me.ButtonItemSegmentTypes_Edit.RibbonWordWrap = False
            Me.ButtonItemSegmentTypes_Edit.Stretch = True
            Me.ButtonItemSegmentTypes_Edit.SubItemsExpandWidth = 14
            Me.ButtonItemSegmentTypes_Edit.Text = "Edit"
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Save, Me.ButtonItemActions_Cancel})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(209, 98)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 0
            Me.RibbonBarOptions_Actions.Text = "Actions"
            '
            '
            '
            Me.RibbonBarOptions_Actions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Actions.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Actions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemActions_Save
            '
            Me.ButtonItemActions_Save.BeginGroup = True
            Me.ButtonItemActions_Save.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Save.Name = "ButtonItemActions_Save"
            Me.ButtonItemActions_Save.RibbonWordWrap = False
            Me.ButtonItemActions_Save.Stretch = True
            Me.ButtonItemActions_Save.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Save.Text = "Save"
            '
            'ButtonItemActions_Cancel
            '
            Me.ButtonItemActions_Cancel.BeginGroup = True
            Me.ButtonItemActions_Cancel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Cancel.Enabled = False
            Me.ButtonItemActions_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Cancel.Name = "ButtonItemActions_Cancel"
            Me.ButtonItemActions_Cancel.RibbonWordWrap = False
            Me.ButtonItemActions_Cancel.Stretch = True
            Me.ButtonItemActions_Cancel.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Cancel.Text = "Cancel"
            '
            'TabControlPanel_Tabs
            '
            Me.TabControlPanel_Tabs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlPanel_Tabs.BackColor = System.Drawing.Color.White
            Me.TabControlPanel_Tabs.CanReorderTabs = False
            Me.TabControlPanel_Tabs.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlPanel_Tabs.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlPanel_Tabs.Controls.Add(Me.TabControlPanelVendors_Vendors)
            Me.TabControlPanel_Tabs.Controls.Add(Me.TabControlPanelStatus_Status)
            Me.TabControlPanel_Tabs.ForeColor = System.Drawing.Color.Black
            Me.TabControlPanel_Tabs.Location = New System.Drawing.Point(9, 9)
            Me.TabControlPanel_Tabs.Name = "TabControlPanel_Tabs"
            Me.TabControlPanel_Tabs.SelectedTabFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlPanel_Tabs.SelectedTabIndex = 0
            Me.TabControlPanel_Tabs.Size = New System.Drawing.Size(827, 432)
            Me.TabControlPanel_Tabs.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlPanel_Tabs.TabIndex = 5
            Me.TabControlPanel_Tabs.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlPanel_Tabs.Tabs.Add(Me.TabItemTabs_Defaults)
            Me.TabControlPanel_Tabs.Tabs.Add(Me.TabItemTabs_Options)
            '
            'TabControlPanelStatus_Status
            '
            Me.TabControlPanelStatus_Status.Controls.Add(Me.GroupBoxOptions_BudgetMaintenance)
            Me.TabControlPanelStatus_Status.Controls.Add(Me.GroupBoxOptions_AccountsToBudget)
            Me.TabControlPanelStatus_Status.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelStatus_Status.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelStatus_Status.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelStatus_Status.Name = "TabControlPanelStatus_Status"
            Me.TabControlPanelStatus_Status.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelStatus_Status.Size = New System.Drawing.Size(827, 405)
            Me.TabControlPanelStatus_Status.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelStatus_Status.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelStatus_Status.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelStatus_Status.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelStatus_Status.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelStatus_Status.Style.GradientAngle = 90
            Me.TabControlPanelStatus_Status.TabIndex = 19
            Me.TabControlPanelStatus_Status.TabItem = Me.TabItemTabs_Options
            '
            'GroupBoxOptions_BudgetMaintenance
            '
            Me.GroupBoxOptions_BudgetMaintenance.Controls.Add(Me.GroupBoxOptions_LastYearsActualAmounts)
            Me.GroupBoxOptions_BudgetMaintenance.Controls.Add(Me.GroupBoxOptions_CurrentBudget)
            Me.GroupBoxOptions_BudgetMaintenance.Controls.Add(Me.GroupBoxOptions_ClientBudget)
            Me.GroupBoxOptions_BudgetMaintenance.Controls.Add(Me.GroupBoxOptions_YTDActualAmounts)
            Me.GroupBoxOptions_BudgetMaintenance.Location = New System.Drawing.Point(4, 4)
            Me.GroupBoxOptions_BudgetMaintenance.Name = "GroupBoxOptions_BudgetMaintenance"
            Me.GroupBoxOptions_BudgetMaintenance.Size = New System.Drawing.Size(583, 397)
            Me.GroupBoxOptions_BudgetMaintenance.TabIndex = 34
            Me.GroupBoxOptions_BudgetMaintenance.Text = "Budget Maintenance"
            '
            'GroupBoxOptions_LastYearsActualAmounts
            '
            Me.GroupBoxOptions_LastYearsActualAmounts.Controls.Add(Me.CheckBoxVarianceToLastYear_IncludeYearEndEntries)
            Me.GroupBoxOptions_LastYearsActualAmounts.Controls.Add(Me.PanelVarianceToLastYear_Columns)
            Me.GroupBoxOptions_LastYearsActualAmounts.Controls.Add(Me.PanelLastYearsActualAmounts_Columns)
            Me.GroupBoxOptions_LastYearsActualAmounts.Controls.Add(Me.LabelBudgetMaintenance_VarianceToLastYear)
            Me.GroupBoxOptions_LastYearsActualAmounts.Location = New System.Drawing.Point(6, 24)
            Me.GroupBoxOptions_LastYearsActualAmounts.Name = "GroupBoxOptions_LastYearsActualAmounts"
            Me.GroupBoxOptions_LastYearsActualAmounts.Size = New System.Drawing.Size(560, 112)
            Me.GroupBoxOptions_LastYearsActualAmounts.TabIndex = 29
            Me.GroupBoxOptions_LastYearsActualAmounts.Text = "Last Year's Actual Amounts"
            '
            'CheckBoxVarianceToLastYear_IncludeYearEndEntries
            '
            '
            '
            '
            Me.CheckBoxVarianceToLastYear_IncludeYearEndEntries.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxVarianceToLastYear_IncludeYearEndEntries.CheckValue = 0
            Me.CheckBoxVarianceToLastYear_IncludeYearEndEntries.CheckValueChecked = 1
            Me.CheckBoxVarianceToLastYear_IncludeYearEndEntries.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxVarianceToLastYear_IncludeYearEndEntries.CheckValueUnchecked = 0
            Me.CheckBoxVarianceToLastYear_IncludeYearEndEntries.ChildControls = CType(resources.GetObject("CheckBoxVarianceToLastYear_IncludeYearEndEntries.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxVarianceToLastYear_IncludeYearEndEntries.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxVarianceToLastYear_IncludeYearEndEntries.Location = New System.Drawing.Point(45, 87)
            Me.CheckBoxVarianceToLastYear_IncludeYearEndEntries.Margin = New System.Windows.Forms.Padding(2)
            Me.CheckBoxVarianceToLastYear_IncludeYearEndEntries.Name = "CheckBoxVarianceToLastYear_IncludeYearEndEntries"
            Me.CheckBoxVarianceToLastYear_IncludeYearEndEntries.OldestSibling = Nothing
            Me.CheckBoxVarianceToLastYear_IncludeYearEndEntries.SecurityEnabled = True
            Me.CheckBoxVarianceToLastYear_IncludeYearEndEntries.SiblingControls = CType(resources.GetObject("CheckBoxVarianceToLastYear_IncludeYearEndEntries.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxVarianceToLastYear_IncludeYearEndEntries.Size = New System.Drawing.Size(141, 15)
            Me.CheckBoxVarianceToLastYear_IncludeYearEndEntries.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxVarianceToLastYear_IncludeYearEndEntries.TabIndex = 54
            Me.CheckBoxVarianceToLastYear_IncludeYearEndEntries.TabOnEnter = True
            Me.CheckBoxVarianceToLastYear_IncludeYearEndEntries.Tag = "0"
            Me.CheckBoxVarianceToLastYear_IncludeYearEndEntries.Text = "Include Year End Entries"
            '
            'PanelVarianceToLastYear_Columns
            '
            Me.PanelVarianceToLastYear_Columns.Appearance.BackColor = System.Drawing.Color.Transparent
            Me.PanelVarianceToLastYear_Columns.Appearance.Options.UseBackColor = True
            Me.PanelVarianceToLastYear_Columns.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelVarianceToLastYear_Columns.Controls.Add(Me.RadioButtonVarianceToLastYear_Column6)
            Me.PanelVarianceToLastYear_Columns.Controls.Add(Me.RadioButtonVarianceToLastYear_Column3)
            Me.PanelVarianceToLastYear_Columns.Controls.Add(Me.RadioButtonVarianceToLastYear_Column5)
            Me.PanelVarianceToLastYear_Columns.Controls.Add(Me.RadioButtonVarianceToLastYear_Exclude)
            Me.PanelVarianceToLastYear_Columns.Controls.Add(Me.RadioButtonVarianceToLastYear_Column4)
            Me.PanelVarianceToLastYear_Columns.Controls.Add(Me.RadioButtonVarianceToLastYear_Column2)
            Me.PanelVarianceToLastYear_Columns.Controls.Add(Me.RadioButtonVarianceToLastYear_Column1)
            Me.PanelVarianceToLastYear_Columns.Location = New System.Drawing.Point(30, 64)
            Me.PanelVarianceToLastYear_Columns.LookAndFeel.SkinName = "Office 2013"
            Me.PanelVarianceToLastYear_Columns.LookAndFeel.UseDefaultLookAndFeel = False
            Me.PanelVarianceToLastYear_Columns.Margin = New System.Windows.Forms.Padding(2)
            Me.PanelVarianceToLastYear_Columns.Name = "PanelVarianceToLastYear_Columns"
            Me.PanelVarianceToLastYear_Columns.Size = New System.Drawing.Size(483, 18)
            Me.PanelVarianceToLastYear_Columns.TabIndex = 53
            '
            'RadioButtonVarianceToLastYear_Column6
            '
            Me.RadioButtonVarianceToLastYear_Column6.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonVarianceToLastYear_Column6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonVarianceToLastYear_Column6.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonVarianceToLastYear_Column6.Location = New System.Drawing.Point(419, 0)
            Me.RadioButtonVarianceToLastYear_Column6.Name = "RadioButtonVarianceToLastYear_Column6"
            Me.RadioButtonVarianceToLastYear_Column6.SecurityEnabled = True
            Me.RadioButtonVarianceToLastYear_Column6.Size = New System.Drawing.Size(65, 18)
            Me.RadioButtonVarianceToLastYear_Column6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonVarianceToLastYear_Column6.TabIndex = 55
            Me.RadioButtonVarianceToLastYear_Column6.TabOnEnter = True
            Me.RadioButtonVarianceToLastYear_Column6.TabStop = False
            Me.RadioButtonVarianceToLastYear_Column6.Tag = "6"
            Me.RadioButtonVarianceToLastYear_Column6.Text = "Column 6"
            '
            'RadioButtonVarianceToLastYear_Column3
            '
            Me.RadioButtonVarianceToLastYear_Column3.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonVarianceToLastYear_Column3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonVarianceToLastYear_Column3.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonVarianceToLastYear_Column3.Location = New System.Drawing.Point(209, 0)
            Me.RadioButtonVarianceToLastYear_Column3.Name = "RadioButtonVarianceToLastYear_Column3"
            Me.RadioButtonVarianceToLastYear_Column3.SecurityEnabled = True
            Me.RadioButtonVarianceToLastYear_Column3.Size = New System.Drawing.Size(65, 18)
            Me.RadioButtonVarianceToLastYear_Column3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonVarianceToLastYear_Column3.TabIndex = 15
            Me.RadioButtonVarianceToLastYear_Column3.TabOnEnter = True
            Me.RadioButtonVarianceToLastYear_Column3.TabStop = False
            Me.RadioButtonVarianceToLastYear_Column3.Tag = "3"
            Me.RadioButtonVarianceToLastYear_Column3.Text = "Column 3"
            '
            'RadioButtonVarianceToLastYear_Column5
            '
            Me.RadioButtonVarianceToLastYear_Column5.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonVarianceToLastYear_Column5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonVarianceToLastYear_Column5.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonVarianceToLastYear_Column5.Location = New System.Drawing.Point(349, 0)
            Me.RadioButtonVarianceToLastYear_Column5.Name = "RadioButtonVarianceToLastYear_Column5"
            Me.RadioButtonVarianceToLastYear_Column5.SecurityEnabled = True
            Me.RadioButtonVarianceToLastYear_Column5.Size = New System.Drawing.Size(65, 18)
            Me.RadioButtonVarianceToLastYear_Column5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonVarianceToLastYear_Column5.TabIndex = 54
            Me.RadioButtonVarianceToLastYear_Column5.TabOnEnter = True
            Me.RadioButtonVarianceToLastYear_Column5.TabStop = False
            Me.RadioButtonVarianceToLastYear_Column5.Tag = "5"
            Me.RadioButtonVarianceToLastYear_Column5.Text = "Column 5"
            '
            'RadioButtonVarianceToLastYear_Exclude
            '
            Me.RadioButtonVarianceToLastYear_Exclude.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonVarianceToLastYear_Exclude.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonVarianceToLastYear_Exclude.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonVarianceToLastYear_Exclude.Location = New System.Drawing.Point(-1, 0)
            Me.RadioButtonVarianceToLastYear_Exclude.Name = "RadioButtonVarianceToLastYear_Exclude"
            Me.RadioButtonVarianceToLastYear_Exclude.SecurityEnabled = True
            Me.RadioButtonVarianceToLastYear_Exclude.Size = New System.Drawing.Size(65, 18)
            Me.RadioButtonVarianceToLastYear_Exclude.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonVarianceToLastYear_Exclude.TabIndex = 0
            Me.RadioButtonVarianceToLastYear_Exclude.TabOnEnter = True
            Me.RadioButtonVarianceToLastYear_Exclude.TabStop = False
            Me.RadioButtonVarianceToLastYear_Exclude.Tag = "0"
            Me.RadioButtonVarianceToLastYear_Exclude.Text = "Exclude"
            '
            'RadioButtonVarianceToLastYear_Column4
            '
            Me.RadioButtonVarianceToLastYear_Column4.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonVarianceToLastYear_Column4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonVarianceToLastYear_Column4.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonVarianceToLastYear_Column4.Location = New System.Drawing.Point(279, 0)
            Me.RadioButtonVarianceToLastYear_Column4.Name = "RadioButtonVarianceToLastYear_Column4"
            Me.RadioButtonVarianceToLastYear_Column4.SecurityEnabled = True
            Me.RadioButtonVarianceToLastYear_Column4.Size = New System.Drawing.Size(65, 18)
            Me.RadioButtonVarianceToLastYear_Column4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonVarianceToLastYear_Column4.TabIndex = 53
            Me.RadioButtonVarianceToLastYear_Column4.TabOnEnter = True
            Me.RadioButtonVarianceToLastYear_Column4.TabStop = False
            Me.RadioButtonVarianceToLastYear_Column4.Tag = "4"
            Me.RadioButtonVarianceToLastYear_Column4.Text = "Column 4"
            '
            'RadioButtonVarianceToLastYear_Column2
            '
            Me.RadioButtonVarianceToLastYear_Column2.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonVarianceToLastYear_Column2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonVarianceToLastYear_Column2.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonVarianceToLastYear_Column2.Location = New System.Drawing.Point(139, 0)
            Me.RadioButtonVarianceToLastYear_Column2.Name = "RadioButtonVarianceToLastYear_Column2"
            Me.RadioButtonVarianceToLastYear_Column2.SecurityEnabled = True
            Me.RadioButtonVarianceToLastYear_Column2.Size = New System.Drawing.Size(65, 18)
            Me.RadioButtonVarianceToLastYear_Column2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonVarianceToLastYear_Column2.TabIndex = 14
            Me.RadioButtonVarianceToLastYear_Column2.TabOnEnter = True
            Me.RadioButtonVarianceToLastYear_Column2.TabStop = False
            Me.RadioButtonVarianceToLastYear_Column2.Tag = "2"
            Me.RadioButtonVarianceToLastYear_Column2.Text = "Column 2"
            '
            'RadioButtonVarianceToLastYear_Column1
            '
            Me.RadioButtonVarianceToLastYear_Column1.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonVarianceToLastYear_Column1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonVarianceToLastYear_Column1.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonVarianceToLastYear_Column1.Location = New System.Drawing.Point(69, 0)
            Me.RadioButtonVarianceToLastYear_Column1.Name = "RadioButtonVarianceToLastYear_Column1"
            Me.RadioButtonVarianceToLastYear_Column1.SecurityEnabled = True
            Me.RadioButtonVarianceToLastYear_Column1.Size = New System.Drawing.Size(65, 18)
            Me.RadioButtonVarianceToLastYear_Column1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonVarianceToLastYear_Column1.TabIndex = 13
            Me.RadioButtonVarianceToLastYear_Column1.TabOnEnter = True
            Me.RadioButtonVarianceToLastYear_Column1.TabStop = False
            Me.RadioButtonVarianceToLastYear_Column1.Tag = "1"
            Me.RadioButtonVarianceToLastYear_Column1.Text = "Column 1"
            '
            'PanelLastYearsActualAmounts_Columns
            '
            Me.PanelLastYearsActualAmounts_Columns.Appearance.BackColor = System.Drawing.Color.Transparent
            Me.PanelLastYearsActualAmounts_Columns.Appearance.Options.UseBackColor = True
            Me.PanelLastYearsActualAmounts_Columns.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelLastYearsActualAmounts_Columns.Controls.Add(Me.RadioButtonLastYearsActualAmounts_Column6)
            Me.PanelLastYearsActualAmounts_Columns.Controls.Add(Me.RadioButtonLastYearsActualAmounts_Column3)
            Me.PanelLastYearsActualAmounts_Columns.Controls.Add(Me.RadioButtonLastYearsActualAmounts_Column5)
            Me.PanelLastYearsActualAmounts_Columns.Controls.Add(Me.RadioButtonLastYearsActualAmounts_Exclude)
            Me.PanelLastYearsActualAmounts_Columns.Controls.Add(Me.RadioButtonLastYearsActualAmounts_Column4)
            Me.PanelLastYearsActualAmounts_Columns.Controls.Add(Me.RadioButtonLastYearsActualAmounts_Column2)
            Me.PanelLastYearsActualAmounts_Columns.Controls.Add(Me.RadioButtonLastYearsActualAmounts_Column1)
            Me.PanelLastYearsActualAmounts_Columns.Location = New System.Drawing.Point(29, 22)
            Me.PanelLastYearsActualAmounts_Columns.LookAndFeel.SkinName = "Office 2013"
            Me.PanelLastYearsActualAmounts_Columns.LookAndFeel.UseDefaultLookAndFeel = False
            Me.PanelLastYearsActualAmounts_Columns.Margin = New System.Windows.Forms.Padding(2)
            Me.PanelLastYearsActualAmounts_Columns.Name = "PanelLastYearsActualAmounts_Columns"
            Me.PanelLastYearsActualAmounts_Columns.Size = New System.Drawing.Size(483, 18)
            Me.PanelLastYearsActualAmounts_Columns.TabIndex = 52
            '
            'RadioButtonLastYearsActualAmounts_Column6
            '
            Me.RadioButtonLastYearsActualAmounts_Column6.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonLastYearsActualAmounts_Column6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonLastYearsActualAmounts_Column6.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonLastYearsActualAmounts_Column6.Location = New System.Drawing.Point(419, 0)
            Me.RadioButtonLastYearsActualAmounts_Column6.Name = "RadioButtonLastYearsActualAmounts_Column6"
            Me.RadioButtonLastYearsActualAmounts_Column6.SecurityEnabled = True
            Me.RadioButtonLastYearsActualAmounts_Column6.Size = New System.Drawing.Size(65, 18)
            Me.RadioButtonLastYearsActualAmounts_Column6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonLastYearsActualAmounts_Column6.TabIndex = 55
            Me.RadioButtonLastYearsActualAmounts_Column6.TabOnEnter = True
            Me.RadioButtonLastYearsActualAmounts_Column6.TabStop = False
            Me.RadioButtonLastYearsActualAmounts_Column6.Tag = "6"
            Me.RadioButtonLastYearsActualAmounts_Column6.Text = "Column 6"
            '
            'RadioButtonLastYearsActualAmounts_Column3
            '
            Me.RadioButtonLastYearsActualAmounts_Column3.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonLastYearsActualAmounts_Column3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonLastYearsActualAmounts_Column3.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonLastYearsActualAmounts_Column3.Location = New System.Drawing.Point(209, 0)
            Me.RadioButtonLastYearsActualAmounts_Column3.Name = "RadioButtonLastYearsActualAmounts_Column3"
            Me.RadioButtonLastYearsActualAmounts_Column3.SecurityEnabled = True
            Me.RadioButtonLastYearsActualAmounts_Column3.Size = New System.Drawing.Size(65, 18)
            Me.RadioButtonLastYearsActualAmounts_Column3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonLastYearsActualAmounts_Column3.TabIndex = 15
            Me.RadioButtonLastYearsActualAmounts_Column3.TabOnEnter = True
            Me.RadioButtonLastYearsActualAmounts_Column3.TabStop = False
            Me.RadioButtonLastYearsActualAmounts_Column3.Tag = "3"
            Me.RadioButtonLastYearsActualAmounts_Column3.Text = "Column 3"
            '
            'RadioButtonLastYearsActualAmounts_Column5
            '
            Me.RadioButtonLastYearsActualAmounts_Column5.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonLastYearsActualAmounts_Column5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonLastYearsActualAmounts_Column5.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonLastYearsActualAmounts_Column5.Location = New System.Drawing.Point(349, 0)
            Me.RadioButtonLastYearsActualAmounts_Column5.Name = "RadioButtonLastYearsActualAmounts_Column5"
            Me.RadioButtonLastYearsActualAmounts_Column5.SecurityEnabled = True
            Me.RadioButtonLastYearsActualAmounts_Column5.Size = New System.Drawing.Size(65, 18)
            Me.RadioButtonLastYearsActualAmounts_Column5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonLastYearsActualAmounts_Column5.TabIndex = 54
            Me.RadioButtonLastYearsActualAmounts_Column5.TabOnEnter = True
            Me.RadioButtonLastYearsActualAmounts_Column5.TabStop = False
            Me.RadioButtonLastYearsActualAmounts_Column5.Tag = "5"
            Me.RadioButtonLastYearsActualAmounts_Column5.Text = "Column 5"
            '
            'RadioButtonLastYearsActualAmounts_Exclude
            '
            Me.RadioButtonLastYearsActualAmounts_Exclude.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonLastYearsActualAmounts_Exclude.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonLastYearsActualAmounts_Exclude.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonLastYearsActualAmounts_Exclude.Location = New System.Drawing.Point(0, 0)
            Me.RadioButtonLastYearsActualAmounts_Exclude.Name = "RadioButtonLastYearsActualAmounts_Exclude"
            Me.RadioButtonLastYearsActualAmounts_Exclude.SecurityEnabled = True
            Me.RadioButtonLastYearsActualAmounts_Exclude.Size = New System.Drawing.Size(65, 18)
            Me.RadioButtonLastYearsActualAmounts_Exclude.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonLastYearsActualAmounts_Exclude.TabIndex = 0
            Me.RadioButtonLastYearsActualAmounts_Exclude.TabOnEnter = True
            Me.RadioButtonLastYearsActualAmounts_Exclude.TabStop = False
            Me.RadioButtonLastYearsActualAmounts_Exclude.Tag = "0"
            Me.RadioButtonLastYearsActualAmounts_Exclude.Text = "Exclude"
            '
            'RadioButtonLastYearsActualAmounts_Column4
            '
            Me.RadioButtonLastYearsActualAmounts_Column4.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonLastYearsActualAmounts_Column4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonLastYearsActualAmounts_Column4.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonLastYearsActualAmounts_Column4.Location = New System.Drawing.Point(279, 0)
            Me.RadioButtonLastYearsActualAmounts_Column4.Name = "RadioButtonLastYearsActualAmounts_Column4"
            Me.RadioButtonLastYearsActualAmounts_Column4.SecurityEnabled = True
            Me.RadioButtonLastYearsActualAmounts_Column4.Size = New System.Drawing.Size(65, 18)
            Me.RadioButtonLastYearsActualAmounts_Column4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonLastYearsActualAmounts_Column4.TabIndex = 53
            Me.RadioButtonLastYearsActualAmounts_Column4.TabOnEnter = True
            Me.RadioButtonLastYearsActualAmounts_Column4.TabStop = False
            Me.RadioButtonLastYearsActualAmounts_Column4.Tag = "4"
            Me.RadioButtonLastYearsActualAmounts_Column4.Text = "Column 4"
            '
            'RadioButtonLastYearsActualAmounts_Column2
            '
            Me.RadioButtonLastYearsActualAmounts_Column2.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonLastYearsActualAmounts_Column2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonLastYearsActualAmounts_Column2.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonLastYearsActualAmounts_Column2.Location = New System.Drawing.Point(139, 0)
            Me.RadioButtonLastYearsActualAmounts_Column2.Name = "RadioButtonLastYearsActualAmounts_Column2"
            Me.RadioButtonLastYearsActualAmounts_Column2.SecurityEnabled = True
            Me.RadioButtonLastYearsActualAmounts_Column2.Size = New System.Drawing.Size(65, 18)
            Me.RadioButtonLastYearsActualAmounts_Column2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonLastYearsActualAmounts_Column2.TabIndex = 14
            Me.RadioButtonLastYearsActualAmounts_Column2.TabOnEnter = True
            Me.RadioButtonLastYearsActualAmounts_Column2.TabStop = False
            Me.RadioButtonLastYearsActualAmounts_Column2.Tag = "2"
            Me.RadioButtonLastYearsActualAmounts_Column2.Text = "Column 2"
            '
            'RadioButtonLastYearsActualAmounts_Column1
            '
            Me.RadioButtonLastYearsActualAmounts_Column1.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonLastYearsActualAmounts_Column1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonLastYearsActualAmounts_Column1.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonLastYearsActualAmounts_Column1.Location = New System.Drawing.Point(69, 0)
            Me.RadioButtonLastYearsActualAmounts_Column1.Name = "RadioButtonLastYearsActualAmounts_Column1"
            Me.RadioButtonLastYearsActualAmounts_Column1.SecurityEnabled = True
            Me.RadioButtonLastYearsActualAmounts_Column1.Size = New System.Drawing.Size(65, 18)
            Me.RadioButtonLastYearsActualAmounts_Column1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonLastYearsActualAmounts_Column1.TabIndex = 13
            Me.RadioButtonLastYearsActualAmounts_Column1.TabOnEnter = True
            Me.RadioButtonLastYearsActualAmounts_Column1.TabStop = False
            Me.RadioButtonLastYearsActualAmounts_Column1.Tag = "1"
            Me.RadioButtonLastYearsActualAmounts_Column1.Text = "Column 1"
            '
            'LabelBudgetMaintenance_VarianceToLastYear
            '
            Me.LabelBudgetMaintenance_VarianceToLastYear.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelBudgetMaintenance_VarianceToLastYear.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelBudgetMaintenance_VarianceToLastYear.Location = New System.Drawing.Point(4, 45)
            Me.LabelBudgetMaintenance_VarianceToLastYear.Margin = New System.Windows.Forms.Padding(2)
            Me.LabelBudgetMaintenance_VarianceToLastYear.Name = "LabelBudgetMaintenance_VarianceToLastYear"
            Me.LabelBudgetMaintenance_VarianceToLastYear.Size = New System.Drawing.Size(144, 15)
            Me.LabelBudgetMaintenance_VarianceToLastYear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelBudgetMaintenance_VarianceToLastYear.TabIndex = 1
            Me.LabelBudgetMaintenance_VarianceToLastYear.Text = "Variance To Last Year:"
            '
            'GroupBoxOptions_CurrentBudget
            '
            Me.GroupBoxOptions_CurrentBudget.Controls.Add(Me.PanelVarianceToCurrentBudget_Columns)
            Me.GroupBoxOptions_CurrentBudget.Controls.Add(Me.PanelCompareUsingCurrentBudget_Columns)
            Me.GroupBoxOptions_CurrentBudget.Controls.Add(Me.LabelCurrentBudget_VarianceToCurrentBudget)
            Me.GroupBoxOptions_CurrentBudget.Controls.Add(Me.LabelCurrentBudget_CompareUsingCurrentBudget)
            Me.GroupBoxOptions_CurrentBudget.Location = New System.Drawing.Point(6, 196)
            Me.GroupBoxOptions_CurrentBudget.Name = "GroupBoxOptions_CurrentBudget"
            Me.GroupBoxOptions_CurrentBudget.Size = New System.Drawing.Size(560, 123)
            Me.GroupBoxOptions_CurrentBudget.TabIndex = 31
            Me.GroupBoxOptions_CurrentBudget.Text = "Current Budget"
            '
            'PanelVarianceToCurrentBudget_Columns
            '
            Me.PanelVarianceToCurrentBudget_Columns.Appearance.BackColor = System.Drawing.Color.Transparent
            Me.PanelVarianceToCurrentBudget_Columns.Appearance.Options.UseBackColor = True
            Me.PanelVarianceToCurrentBudget_Columns.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelVarianceToCurrentBudget_Columns.Controls.Add(Me.RadioButtonVarianceToCurrentBudget_Column6)
            Me.PanelVarianceToCurrentBudget_Columns.Controls.Add(Me.RadioButtonVarianceToCurrentBudget_Column3)
            Me.PanelVarianceToCurrentBudget_Columns.Controls.Add(Me.RadioButtonVarianceToCurrentBudget_Column5)
            Me.PanelVarianceToCurrentBudget_Columns.Controls.Add(Me.RadioButtonVarianceToCurrentBudget_Exclude)
            Me.PanelVarianceToCurrentBudget_Columns.Controls.Add(Me.RadioButtonVarianceToCurrentBudget_Column4)
            Me.PanelVarianceToCurrentBudget_Columns.Controls.Add(Me.RadioButtonVarianceToCurrentBudget_Column2)
            Me.PanelVarianceToCurrentBudget_Columns.Controls.Add(Me.RadioButtonVarianceToCurrentBudget_Column1)
            Me.PanelVarianceToCurrentBudget_Columns.Location = New System.Drawing.Point(30, 91)
            Me.PanelVarianceToCurrentBudget_Columns.LookAndFeel.SkinName = "Office 2013"
            Me.PanelVarianceToCurrentBudget_Columns.LookAndFeel.UseDefaultLookAndFeel = False
            Me.PanelVarianceToCurrentBudget_Columns.Margin = New System.Windows.Forms.Padding(2)
            Me.PanelVarianceToCurrentBudget_Columns.Name = "PanelVarianceToCurrentBudget_Columns"
            Me.PanelVarianceToCurrentBudget_Columns.Size = New System.Drawing.Size(483, 18)
            Me.PanelVarianceToCurrentBudget_Columns.TabIndex = 54
            '
            'RadioButtonVarianceToCurrentBudget_Column6
            '
            Me.RadioButtonVarianceToCurrentBudget_Column6.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonVarianceToCurrentBudget_Column6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonVarianceToCurrentBudget_Column6.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonVarianceToCurrentBudget_Column6.Location = New System.Drawing.Point(419, 0)
            Me.RadioButtonVarianceToCurrentBudget_Column6.Name = "RadioButtonVarianceToCurrentBudget_Column6"
            Me.RadioButtonVarianceToCurrentBudget_Column6.SecurityEnabled = True
            Me.RadioButtonVarianceToCurrentBudget_Column6.Size = New System.Drawing.Size(65, 18)
            Me.RadioButtonVarianceToCurrentBudget_Column6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonVarianceToCurrentBudget_Column6.TabIndex = 55
            Me.RadioButtonVarianceToCurrentBudget_Column6.TabOnEnter = True
            Me.RadioButtonVarianceToCurrentBudget_Column6.TabStop = False
            Me.RadioButtonVarianceToCurrentBudget_Column6.Tag = "6"
            Me.RadioButtonVarianceToCurrentBudget_Column6.Text = "Column 6"
            '
            'RadioButtonVarianceToCurrentBudget_Column3
            '
            Me.RadioButtonVarianceToCurrentBudget_Column3.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonVarianceToCurrentBudget_Column3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonVarianceToCurrentBudget_Column3.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonVarianceToCurrentBudget_Column3.Location = New System.Drawing.Point(209, 0)
            Me.RadioButtonVarianceToCurrentBudget_Column3.Name = "RadioButtonVarianceToCurrentBudget_Column3"
            Me.RadioButtonVarianceToCurrentBudget_Column3.SecurityEnabled = True
            Me.RadioButtonVarianceToCurrentBudget_Column3.Size = New System.Drawing.Size(65, 18)
            Me.RadioButtonVarianceToCurrentBudget_Column3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonVarianceToCurrentBudget_Column3.TabIndex = 15
            Me.RadioButtonVarianceToCurrentBudget_Column3.TabOnEnter = True
            Me.RadioButtonVarianceToCurrentBudget_Column3.TabStop = False
            Me.RadioButtonVarianceToCurrentBudget_Column3.Tag = "3"
            Me.RadioButtonVarianceToCurrentBudget_Column3.Text = "Column 3"
            '
            'RadioButtonVarianceToCurrentBudget_Column5
            '
            Me.RadioButtonVarianceToCurrentBudget_Column5.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonVarianceToCurrentBudget_Column5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonVarianceToCurrentBudget_Column5.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonVarianceToCurrentBudget_Column5.Location = New System.Drawing.Point(349, 0)
            Me.RadioButtonVarianceToCurrentBudget_Column5.Name = "RadioButtonVarianceToCurrentBudget_Column5"
            Me.RadioButtonVarianceToCurrentBudget_Column5.SecurityEnabled = True
            Me.RadioButtonVarianceToCurrentBudget_Column5.Size = New System.Drawing.Size(65, 18)
            Me.RadioButtonVarianceToCurrentBudget_Column5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonVarianceToCurrentBudget_Column5.TabIndex = 54
            Me.RadioButtonVarianceToCurrentBudget_Column5.TabOnEnter = True
            Me.RadioButtonVarianceToCurrentBudget_Column5.TabStop = False
            Me.RadioButtonVarianceToCurrentBudget_Column5.Tag = "5"
            Me.RadioButtonVarianceToCurrentBudget_Column5.Text = "Column 5"
            '
            'RadioButtonVarianceToCurrentBudget_Exclude
            '
            Me.RadioButtonVarianceToCurrentBudget_Exclude.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonVarianceToCurrentBudget_Exclude.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonVarianceToCurrentBudget_Exclude.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonVarianceToCurrentBudget_Exclude.Location = New System.Drawing.Point(-1, 0)
            Me.RadioButtonVarianceToCurrentBudget_Exclude.Name = "RadioButtonVarianceToCurrentBudget_Exclude"
            Me.RadioButtonVarianceToCurrentBudget_Exclude.SecurityEnabled = True
            Me.RadioButtonVarianceToCurrentBudget_Exclude.Size = New System.Drawing.Size(65, 18)
            Me.RadioButtonVarianceToCurrentBudget_Exclude.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonVarianceToCurrentBudget_Exclude.TabIndex = 0
            Me.RadioButtonVarianceToCurrentBudget_Exclude.TabOnEnter = True
            Me.RadioButtonVarianceToCurrentBudget_Exclude.TabStop = False
            Me.RadioButtonVarianceToCurrentBudget_Exclude.Tag = "0"
            Me.RadioButtonVarianceToCurrentBudget_Exclude.Text = "Exclude"
            '
            'RadioButtonVarianceToCurrentBudget_Column4
            '
            Me.RadioButtonVarianceToCurrentBudget_Column4.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonVarianceToCurrentBudget_Column4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonVarianceToCurrentBudget_Column4.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonVarianceToCurrentBudget_Column4.Location = New System.Drawing.Point(279, 0)
            Me.RadioButtonVarianceToCurrentBudget_Column4.Name = "RadioButtonVarianceToCurrentBudget_Column4"
            Me.RadioButtonVarianceToCurrentBudget_Column4.SecurityEnabled = True
            Me.RadioButtonVarianceToCurrentBudget_Column4.Size = New System.Drawing.Size(65, 18)
            Me.RadioButtonVarianceToCurrentBudget_Column4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonVarianceToCurrentBudget_Column4.TabIndex = 53
            Me.RadioButtonVarianceToCurrentBudget_Column4.TabOnEnter = True
            Me.RadioButtonVarianceToCurrentBudget_Column4.TabStop = False
            Me.RadioButtonVarianceToCurrentBudget_Column4.Tag = "4"
            Me.RadioButtonVarianceToCurrentBudget_Column4.Text = "Column 4"
            '
            'RadioButtonVarianceToCurrentBudget_Column2
            '
            Me.RadioButtonVarianceToCurrentBudget_Column2.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonVarianceToCurrentBudget_Column2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonVarianceToCurrentBudget_Column2.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonVarianceToCurrentBudget_Column2.Location = New System.Drawing.Point(139, 0)
            Me.RadioButtonVarianceToCurrentBudget_Column2.Name = "RadioButtonVarianceToCurrentBudget_Column2"
            Me.RadioButtonVarianceToCurrentBudget_Column2.SecurityEnabled = True
            Me.RadioButtonVarianceToCurrentBudget_Column2.Size = New System.Drawing.Size(65, 18)
            Me.RadioButtonVarianceToCurrentBudget_Column2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonVarianceToCurrentBudget_Column2.TabIndex = 14
            Me.RadioButtonVarianceToCurrentBudget_Column2.TabOnEnter = True
            Me.RadioButtonVarianceToCurrentBudget_Column2.TabStop = False
            Me.RadioButtonVarianceToCurrentBudget_Column2.Tag = "2"
            Me.RadioButtonVarianceToCurrentBudget_Column2.Text = "Column 2"
            '
            'RadioButtonVarianceToCurrentBudget_Column1
            '
            Me.RadioButtonVarianceToCurrentBudget_Column1.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonVarianceToCurrentBudget_Column1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonVarianceToCurrentBudget_Column1.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonVarianceToCurrentBudget_Column1.Location = New System.Drawing.Point(69, 0)
            Me.RadioButtonVarianceToCurrentBudget_Column1.Name = "RadioButtonVarianceToCurrentBudget_Column1"
            Me.RadioButtonVarianceToCurrentBudget_Column1.SecurityEnabled = True
            Me.RadioButtonVarianceToCurrentBudget_Column1.Size = New System.Drawing.Size(65, 18)
            Me.RadioButtonVarianceToCurrentBudget_Column1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonVarianceToCurrentBudget_Column1.TabIndex = 13
            Me.RadioButtonVarianceToCurrentBudget_Column1.TabOnEnter = True
            Me.RadioButtonVarianceToCurrentBudget_Column1.TabStop = False
            Me.RadioButtonVarianceToCurrentBudget_Column1.Tag = "1"
            Me.RadioButtonVarianceToCurrentBudget_Column1.Text = "Column 1"
            '
            'PanelCompareUsingCurrentBudget_Columns
            '
            Me.PanelCompareUsingCurrentBudget_Columns.Appearance.BackColor = System.Drawing.Color.Transparent
            Me.PanelCompareUsingCurrentBudget_Columns.Appearance.Options.UseBackColor = True
            Me.PanelCompareUsingCurrentBudget_Columns.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelCompareUsingCurrentBudget_Columns.Controls.Add(Me.RadioButtonCompareUsingCurrentBudget_Column6)
            Me.PanelCompareUsingCurrentBudget_Columns.Controls.Add(Me.RadioButtonCompareUsingCurrentBudget_Column3)
            Me.PanelCompareUsingCurrentBudget_Columns.Controls.Add(Me.RadioButtonCompareUsingCurrentBudget_Column5)
            Me.PanelCompareUsingCurrentBudget_Columns.Controls.Add(Me.RadioButtonCompareUsingCurrentBudget_Exclude)
            Me.PanelCompareUsingCurrentBudget_Columns.Controls.Add(Me.RadioButtonCompareUsingCurrentBudget_Column4)
            Me.PanelCompareUsingCurrentBudget_Columns.Controls.Add(Me.RadioButtonCompareUsingCurrentBudget_Column2)
            Me.PanelCompareUsingCurrentBudget_Columns.Controls.Add(Me.RadioButtonCompareUsingCurrentBudget_Column1)
            Me.PanelCompareUsingCurrentBudget_Columns.Location = New System.Drawing.Point(30, 41)
            Me.PanelCompareUsingCurrentBudget_Columns.LookAndFeel.SkinName = "Office 2013"
            Me.PanelCompareUsingCurrentBudget_Columns.LookAndFeel.UseDefaultLookAndFeel = False
            Me.PanelCompareUsingCurrentBudget_Columns.Margin = New System.Windows.Forms.Padding(2)
            Me.PanelCompareUsingCurrentBudget_Columns.Name = "PanelCompareUsingCurrentBudget_Columns"
            Me.PanelCompareUsingCurrentBudget_Columns.Size = New System.Drawing.Size(483, 18)
            Me.PanelCompareUsingCurrentBudget_Columns.TabIndex = 53
            '
            'RadioButtonCompareUsingCurrentBudget_Column6
            '
            Me.RadioButtonCompareUsingCurrentBudget_Column6.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonCompareUsingCurrentBudget_Column6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonCompareUsingCurrentBudget_Column6.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonCompareUsingCurrentBudget_Column6.Location = New System.Drawing.Point(419, 0)
            Me.RadioButtonCompareUsingCurrentBudget_Column6.Name = "RadioButtonCompareUsingCurrentBudget_Column6"
            Me.RadioButtonCompareUsingCurrentBudget_Column6.SecurityEnabled = True
            Me.RadioButtonCompareUsingCurrentBudget_Column6.Size = New System.Drawing.Size(65, 18)
            Me.RadioButtonCompareUsingCurrentBudget_Column6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonCompareUsingCurrentBudget_Column6.TabIndex = 55
            Me.RadioButtonCompareUsingCurrentBudget_Column6.TabOnEnter = True
            Me.RadioButtonCompareUsingCurrentBudget_Column6.TabStop = False
            Me.RadioButtonCompareUsingCurrentBudget_Column6.Tag = "6"
            Me.RadioButtonCompareUsingCurrentBudget_Column6.Text = "Column 6"
            '
            'RadioButtonCompareUsingCurrentBudget_Column3
            '
            Me.RadioButtonCompareUsingCurrentBudget_Column3.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonCompareUsingCurrentBudget_Column3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonCompareUsingCurrentBudget_Column3.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonCompareUsingCurrentBudget_Column3.Location = New System.Drawing.Point(209, 0)
            Me.RadioButtonCompareUsingCurrentBudget_Column3.Name = "RadioButtonCompareUsingCurrentBudget_Column3"
            Me.RadioButtonCompareUsingCurrentBudget_Column3.SecurityEnabled = True
            Me.RadioButtonCompareUsingCurrentBudget_Column3.Size = New System.Drawing.Size(65, 18)
            Me.RadioButtonCompareUsingCurrentBudget_Column3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonCompareUsingCurrentBudget_Column3.TabIndex = 15
            Me.RadioButtonCompareUsingCurrentBudget_Column3.TabOnEnter = True
            Me.RadioButtonCompareUsingCurrentBudget_Column3.TabStop = False
            Me.RadioButtonCompareUsingCurrentBudget_Column3.Tag = "3"
            Me.RadioButtonCompareUsingCurrentBudget_Column3.Text = "Column 3"
            '
            'RadioButtonCompareUsingCurrentBudget_Column5
            '
            Me.RadioButtonCompareUsingCurrentBudget_Column5.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonCompareUsingCurrentBudget_Column5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonCompareUsingCurrentBudget_Column5.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonCompareUsingCurrentBudget_Column5.Location = New System.Drawing.Point(349, 0)
            Me.RadioButtonCompareUsingCurrentBudget_Column5.Name = "RadioButtonCompareUsingCurrentBudget_Column5"
            Me.RadioButtonCompareUsingCurrentBudget_Column5.SecurityEnabled = True
            Me.RadioButtonCompareUsingCurrentBudget_Column5.Size = New System.Drawing.Size(65, 18)
            Me.RadioButtonCompareUsingCurrentBudget_Column5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonCompareUsingCurrentBudget_Column5.TabIndex = 54
            Me.RadioButtonCompareUsingCurrentBudget_Column5.TabOnEnter = True
            Me.RadioButtonCompareUsingCurrentBudget_Column5.TabStop = False
            Me.RadioButtonCompareUsingCurrentBudget_Column5.Tag = "5"
            Me.RadioButtonCompareUsingCurrentBudget_Column5.Text = "Column 5"
            '
            'RadioButtonCompareUsingCurrentBudget_Exclude
            '
            Me.RadioButtonCompareUsingCurrentBudget_Exclude.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonCompareUsingCurrentBudget_Exclude.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonCompareUsingCurrentBudget_Exclude.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonCompareUsingCurrentBudget_Exclude.Location = New System.Drawing.Point(-1, 0)
            Me.RadioButtonCompareUsingCurrentBudget_Exclude.Name = "RadioButtonCompareUsingCurrentBudget_Exclude"
            Me.RadioButtonCompareUsingCurrentBudget_Exclude.SecurityEnabled = True
            Me.RadioButtonCompareUsingCurrentBudget_Exclude.Size = New System.Drawing.Size(65, 18)
            Me.RadioButtonCompareUsingCurrentBudget_Exclude.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonCompareUsingCurrentBudget_Exclude.TabIndex = 0
            Me.RadioButtonCompareUsingCurrentBudget_Exclude.TabOnEnter = True
            Me.RadioButtonCompareUsingCurrentBudget_Exclude.TabStop = False
            Me.RadioButtonCompareUsingCurrentBudget_Exclude.Tag = "0"
            Me.RadioButtonCompareUsingCurrentBudget_Exclude.Text = "Exclude"
            '
            'RadioButtonCompareUsingCurrentBudget_Column4
            '
            Me.RadioButtonCompareUsingCurrentBudget_Column4.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonCompareUsingCurrentBudget_Column4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonCompareUsingCurrentBudget_Column4.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonCompareUsingCurrentBudget_Column4.Location = New System.Drawing.Point(279, 0)
            Me.RadioButtonCompareUsingCurrentBudget_Column4.Name = "RadioButtonCompareUsingCurrentBudget_Column4"
            Me.RadioButtonCompareUsingCurrentBudget_Column4.SecurityEnabled = True
            Me.RadioButtonCompareUsingCurrentBudget_Column4.Size = New System.Drawing.Size(65, 18)
            Me.RadioButtonCompareUsingCurrentBudget_Column4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonCompareUsingCurrentBudget_Column4.TabIndex = 53
            Me.RadioButtonCompareUsingCurrentBudget_Column4.TabOnEnter = True
            Me.RadioButtonCompareUsingCurrentBudget_Column4.TabStop = False
            Me.RadioButtonCompareUsingCurrentBudget_Column4.Tag = "4"
            Me.RadioButtonCompareUsingCurrentBudget_Column4.Text = "Column 4"
            '
            'RadioButtonCompareUsingCurrentBudget_Column2
            '
            Me.RadioButtonCompareUsingCurrentBudget_Column2.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonCompareUsingCurrentBudget_Column2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonCompareUsingCurrentBudget_Column2.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonCompareUsingCurrentBudget_Column2.Location = New System.Drawing.Point(139, 0)
            Me.RadioButtonCompareUsingCurrentBudget_Column2.Name = "RadioButtonCompareUsingCurrentBudget_Column2"
            Me.RadioButtonCompareUsingCurrentBudget_Column2.SecurityEnabled = True
            Me.RadioButtonCompareUsingCurrentBudget_Column2.Size = New System.Drawing.Size(65, 18)
            Me.RadioButtonCompareUsingCurrentBudget_Column2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonCompareUsingCurrentBudget_Column2.TabIndex = 14
            Me.RadioButtonCompareUsingCurrentBudget_Column2.TabOnEnter = True
            Me.RadioButtonCompareUsingCurrentBudget_Column2.TabStop = False
            Me.RadioButtonCompareUsingCurrentBudget_Column2.Tag = "2"
            Me.RadioButtonCompareUsingCurrentBudget_Column2.Text = "Column 2"
            '
            'RadioButtonCompareUsingCurrentBudget_Column1
            '
            Me.RadioButtonCompareUsingCurrentBudget_Column1.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonCompareUsingCurrentBudget_Column1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonCompareUsingCurrentBudget_Column1.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonCompareUsingCurrentBudget_Column1.Location = New System.Drawing.Point(69, 0)
            Me.RadioButtonCompareUsingCurrentBudget_Column1.Name = "RadioButtonCompareUsingCurrentBudget_Column1"
            Me.RadioButtonCompareUsingCurrentBudget_Column1.SecurityEnabled = True
            Me.RadioButtonCompareUsingCurrentBudget_Column1.Size = New System.Drawing.Size(65, 18)
            Me.RadioButtonCompareUsingCurrentBudget_Column1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonCompareUsingCurrentBudget_Column1.TabIndex = 13
            Me.RadioButtonCompareUsingCurrentBudget_Column1.TabOnEnter = True
            Me.RadioButtonCompareUsingCurrentBudget_Column1.TabStop = False
            Me.RadioButtonCompareUsingCurrentBudget_Column1.Tag = "1"
            Me.RadioButtonCompareUsingCurrentBudget_Column1.Text = "Column 1"
            '
            'LabelCurrentBudget_VarianceToCurrentBudget
            '
            Me.LabelCurrentBudget_VarianceToCurrentBudget.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCurrentBudget_VarianceToCurrentBudget.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCurrentBudget_VarianceToCurrentBudget.Location = New System.Drawing.Point(3, 72)
            Me.LabelCurrentBudget_VarianceToCurrentBudget.Margin = New System.Windows.Forms.Padding(2)
            Me.LabelCurrentBudget_VarianceToCurrentBudget.Name = "LabelCurrentBudget_VarianceToCurrentBudget"
            Me.LabelCurrentBudget_VarianceToCurrentBudget.Size = New System.Drawing.Size(171, 15)
            Me.LabelCurrentBudget_VarianceToCurrentBudget.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCurrentBudget_VarianceToCurrentBudget.TabIndex = 2
            Me.LabelCurrentBudget_VarianceToCurrentBudget.Text = "Variance To Current Budget:"
            '
            'LabelCurrentBudget_CompareUsingCurrentBudget
            '
            Me.LabelCurrentBudget_CompareUsingCurrentBudget.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCurrentBudget_CompareUsingCurrentBudget.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCurrentBudget_CompareUsingCurrentBudget.Location = New System.Drawing.Point(3, 22)
            Me.LabelCurrentBudget_CompareUsingCurrentBudget.Margin = New System.Windows.Forms.Padding(2)
            Me.LabelCurrentBudget_CompareUsingCurrentBudget.Name = "LabelCurrentBudget_CompareUsingCurrentBudget"
            Me.LabelCurrentBudget_CompareUsingCurrentBudget.Size = New System.Drawing.Size(171, 15)
            Me.LabelCurrentBudget_CompareUsingCurrentBudget.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCurrentBudget_CompareUsingCurrentBudget.TabIndex = 1
            Me.LabelCurrentBudget_CompareUsingCurrentBudget.Text = "Compare Using Current Budget:"
            '
            'GroupBoxOptions_ClientBudget
            '
            Me.GroupBoxOptions_ClientBudget.Controls.Add(Me.PanelClientBudget_Columns)
            Me.GroupBoxOptions_ClientBudget.Location = New System.Drawing.Point(5, 325)
            Me.GroupBoxOptions_ClientBudget.Name = "GroupBoxOptions_ClientBudget"
            Me.GroupBoxOptions_ClientBudget.Size = New System.Drawing.Size(560, 49)
            Me.GroupBoxOptions_ClientBudget.TabIndex = 32
            Me.GroupBoxOptions_ClientBudget.Text = "Client Budget:"
            '
            'PanelClientBudget_Columns
            '
            Me.PanelClientBudget_Columns.Appearance.BackColor = System.Drawing.Color.Transparent
            Me.PanelClientBudget_Columns.Appearance.Options.UseBackColor = True
            Me.PanelClientBudget_Columns.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelClientBudget_Columns.Controls.Add(Me.RadioButtonClientBudget_Column6)
            Me.PanelClientBudget_Columns.Controls.Add(Me.RadioButtonClientBudget_Column3)
            Me.PanelClientBudget_Columns.Controls.Add(Me.RadioButtonClientBudget_Column5)
            Me.PanelClientBudget_Columns.Controls.Add(Me.RadioButtonClientBudget_Exclude)
            Me.PanelClientBudget_Columns.Controls.Add(Me.RadioButtonClientBudget_Column4)
            Me.PanelClientBudget_Columns.Controls.Add(Me.RadioButtonClientBudget_Column2)
            Me.PanelClientBudget_Columns.Controls.Add(Me.RadioButtonClientBudget_Column1)
            Me.PanelClientBudget_Columns.Location = New System.Drawing.Point(30, 22)
            Me.PanelClientBudget_Columns.LookAndFeel.SkinName = "Office 2013"
            Me.PanelClientBudget_Columns.LookAndFeel.UseDefaultLookAndFeel = False
            Me.PanelClientBudget_Columns.Margin = New System.Windows.Forms.Padding(2)
            Me.PanelClientBudget_Columns.Name = "PanelClientBudget_Columns"
            Me.PanelClientBudget_Columns.Size = New System.Drawing.Size(483, 18)
            Me.PanelClientBudget_Columns.TabIndex = 53
            '
            'RadioButtonClientBudget_Column6
            '
            Me.RadioButtonClientBudget_Column6.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonClientBudget_Column6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonClientBudget_Column6.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonClientBudget_Column6.Location = New System.Drawing.Point(419, 0)
            Me.RadioButtonClientBudget_Column6.Name = "RadioButtonClientBudget_Column6"
            Me.RadioButtonClientBudget_Column6.SecurityEnabled = True
            Me.RadioButtonClientBudget_Column6.Size = New System.Drawing.Size(65, 18)
            Me.RadioButtonClientBudget_Column6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonClientBudget_Column6.TabIndex = 55
            Me.RadioButtonClientBudget_Column6.TabOnEnter = True
            Me.RadioButtonClientBudget_Column6.TabStop = False
            Me.RadioButtonClientBudget_Column6.Tag = "6"
            Me.RadioButtonClientBudget_Column6.Text = "Column 6"
            '
            'RadioButtonClientBudget_Column3
            '
            Me.RadioButtonClientBudget_Column3.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonClientBudget_Column3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonClientBudget_Column3.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonClientBudget_Column3.Location = New System.Drawing.Point(209, 0)
            Me.RadioButtonClientBudget_Column3.Name = "RadioButtonClientBudget_Column3"
            Me.RadioButtonClientBudget_Column3.SecurityEnabled = True
            Me.RadioButtonClientBudget_Column3.Size = New System.Drawing.Size(65, 18)
            Me.RadioButtonClientBudget_Column3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonClientBudget_Column3.TabIndex = 15
            Me.RadioButtonClientBudget_Column3.TabOnEnter = True
            Me.RadioButtonClientBudget_Column3.TabStop = False
            Me.RadioButtonClientBudget_Column3.Tag = "3"
            Me.RadioButtonClientBudget_Column3.Text = "Column 3"
            '
            'RadioButtonClientBudget_Column5
            '
            Me.RadioButtonClientBudget_Column5.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonClientBudget_Column5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonClientBudget_Column5.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonClientBudget_Column5.Location = New System.Drawing.Point(349, 0)
            Me.RadioButtonClientBudget_Column5.Name = "RadioButtonClientBudget_Column5"
            Me.RadioButtonClientBudget_Column5.SecurityEnabled = True
            Me.RadioButtonClientBudget_Column5.Size = New System.Drawing.Size(65, 18)
            Me.RadioButtonClientBudget_Column5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonClientBudget_Column5.TabIndex = 54
            Me.RadioButtonClientBudget_Column5.TabOnEnter = True
            Me.RadioButtonClientBudget_Column5.TabStop = False
            Me.RadioButtonClientBudget_Column5.Tag = "5"
            Me.RadioButtonClientBudget_Column5.Text = "Column 5"
            '
            'RadioButtonClientBudget_Exclude
            '
            Me.RadioButtonClientBudget_Exclude.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonClientBudget_Exclude.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonClientBudget_Exclude.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonClientBudget_Exclude.Location = New System.Drawing.Point(-1, 0)
            Me.RadioButtonClientBudget_Exclude.Name = "RadioButtonClientBudget_Exclude"
            Me.RadioButtonClientBudget_Exclude.SecurityEnabled = True
            Me.RadioButtonClientBudget_Exclude.Size = New System.Drawing.Size(65, 18)
            Me.RadioButtonClientBudget_Exclude.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonClientBudget_Exclude.TabIndex = 0
            Me.RadioButtonClientBudget_Exclude.TabOnEnter = True
            Me.RadioButtonClientBudget_Exclude.TabStop = False
            Me.RadioButtonClientBudget_Exclude.Tag = "0"
            Me.RadioButtonClientBudget_Exclude.Text = "Exclude"
            '
            'RadioButtonClientBudget_Column4
            '
            Me.RadioButtonClientBudget_Column4.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonClientBudget_Column4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonClientBudget_Column4.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonClientBudget_Column4.Location = New System.Drawing.Point(279, 0)
            Me.RadioButtonClientBudget_Column4.Name = "RadioButtonClientBudget_Column4"
            Me.RadioButtonClientBudget_Column4.SecurityEnabled = True
            Me.RadioButtonClientBudget_Column4.Size = New System.Drawing.Size(65, 18)
            Me.RadioButtonClientBudget_Column4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonClientBudget_Column4.TabIndex = 53
            Me.RadioButtonClientBudget_Column4.TabOnEnter = True
            Me.RadioButtonClientBudget_Column4.TabStop = False
            Me.RadioButtonClientBudget_Column4.Tag = "4"
            Me.RadioButtonClientBudget_Column4.Text = "Column 4"
            '
            'RadioButtonClientBudget_Column2
            '
            Me.RadioButtonClientBudget_Column2.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonClientBudget_Column2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonClientBudget_Column2.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonClientBudget_Column2.Location = New System.Drawing.Point(139, 0)
            Me.RadioButtonClientBudget_Column2.Name = "RadioButtonClientBudget_Column2"
            Me.RadioButtonClientBudget_Column2.SecurityEnabled = True
            Me.RadioButtonClientBudget_Column2.Size = New System.Drawing.Size(65, 18)
            Me.RadioButtonClientBudget_Column2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonClientBudget_Column2.TabIndex = 14
            Me.RadioButtonClientBudget_Column2.TabOnEnter = True
            Me.RadioButtonClientBudget_Column2.TabStop = False
            Me.RadioButtonClientBudget_Column2.Tag = "2"
            Me.RadioButtonClientBudget_Column2.Text = "Column 2"
            '
            'RadioButtonClientBudget_Column1
            '
            Me.RadioButtonClientBudget_Column1.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonClientBudget_Column1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonClientBudget_Column1.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonClientBudget_Column1.Location = New System.Drawing.Point(69, 0)
            Me.RadioButtonClientBudget_Column1.Name = "RadioButtonClientBudget_Column1"
            Me.RadioButtonClientBudget_Column1.SecurityEnabled = True
            Me.RadioButtonClientBudget_Column1.Size = New System.Drawing.Size(65, 18)
            Me.RadioButtonClientBudget_Column1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonClientBudget_Column1.TabIndex = 13
            Me.RadioButtonClientBudget_Column1.TabOnEnter = True
            Me.RadioButtonClientBudget_Column1.TabStop = False
            Me.RadioButtonClientBudget_Column1.Tag = "1"
            Me.RadioButtonClientBudget_Column1.Text = "Column 1"
            '
            'GroupBoxOptions_YTDActualAmounts
            '
            Me.GroupBoxOptions_YTDActualAmounts.Controls.Add(Me.PanelYTDActualAmounts_Columns)
            Me.GroupBoxOptions_YTDActualAmounts.Location = New System.Drawing.Point(6, 142)
            Me.GroupBoxOptions_YTDActualAmounts.Name = "GroupBoxOptions_YTDActualAmounts"
            Me.GroupBoxOptions_YTDActualAmounts.Size = New System.Drawing.Size(559, 48)
            Me.GroupBoxOptions_YTDActualAmounts.TabIndex = 30
            Me.GroupBoxOptions_YTDActualAmounts.Text = "YTD Actual Amounts:"
            '
            'PanelYTDActualAmounts_Columns
            '
            Me.PanelYTDActualAmounts_Columns.Appearance.BackColor = System.Drawing.Color.Transparent
            Me.PanelYTDActualAmounts_Columns.Appearance.Options.UseBackColor = True
            Me.PanelYTDActualAmounts_Columns.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelYTDActualAmounts_Columns.Controls.Add(Me.RadioButtonYTDActualAmounts_Column6)
            Me.PanelYTDActualAmounts_Columns.Controls.Add(Me.RadioButtonYTDActualAmounts_Column3)
            Me.PanelYTDActualAmounts_Columns.Controls.Add(Me.RadioButtonYTDActualAmounts_Column5)
            Me.PanelYTDActualAmounts_Columns.Controls.Add(Me.RadioButtonYTDActualAmounts_Exclude)
            Me.PanelYTDActualAmounts_Columns.Controls.Add(Me.RadioButtonYTDActualAmounts_Column4)
            Me.PanelYTDActualAmounts_Columns.Controls.Add(Me.RadioButtonYTDActualAmounts_Column2)
            Me.PanelYTDActualAmounts_Columns.Controls.Add(Me.RadioButtonYTDActualAmounts_Column1)
            Me.PanelYTDActualAmounts_Columns.Location = New System.Drawing.Point(30, 22)
            Me.PanelYTDActualAmounts_Columns.LookAndFeel.SkinName = "Office 2013"
            Me.PanelYTDActualAmounts_Columns.LookAndFeel.UseDefaultLookAndFeel = False
            Me.PanelYTDActualAmounts_Columns.Margin = New System.Windows.Forms.Padding(2)
            Me.PanelYTDActualAmounts_Columns.Name = "PanelYTDActualAmounts_Columns"
            Me.PanelYTDActualAmounts_Columns.Size = New System.Drawing.Size(483, 18)
            Me.PanelYTDActualAmounts_Columns.TabIndex = 53
            '
            'RadioButtonYTDActualAmounts_Column6
            '
            Me.RadioButtonYTDActualAmounts_Column6.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonYTDActualAmounts_Column6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonYTDActualAmounts_Column6.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonYTDActualAmounts_Column6.Location = New System.Drawing.Point(419, 0)
            Me.RadioButtonYTDActualAmounts_Column6.Name = "RadioButtonYTDActualAmounts_Column6"
            Me.RadioButtonYTDActualAmounts_Column6.SecurityEnabled = True
            Me.RadioButtonYTDActualAmounts_Column6.Size = New System.Drawing.Size(65, 18)
            Me.RadioButtonYTDActualAmounts_Column6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonYTDActualAmounts_Column6.TabIndex = 55
            Me.RadioButtonYTDActualAmounts_Column6.TabOnEnter = True
            Me.RadioButtonYTDActualAmounts_Column6.TabStop = False
            Me.RadioButtonYTDActualAmounts_Column6.Tag = "6"
            Me.RadioButtonYTDActualAmounts_Column6.Text = "Column 6"
            '
            'RadioButtonYTDActualAmounts_Column3
            '
            Me.RadioButtonYTDActualAmounts_Column3.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonYTDActualAmounts_Column3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonYTDActualAmounts_Column3.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonYTDActualAmounts_Column3.Location = New System.Drawing.Point(209, 0)
            Me.RadioButtonYTDActualAmounts_Column3.Name = "RadioButtonYTDActualAmounts_Column3"
            Me.RadioButtonYTDActualAmounts_Column3.SecurityEnabled = True
            Me.RadioButtonYTDActualAmounts_Column3.Size = New System.Drawing.Size(65, 18)
            Me.RadioButtonYTDActualAmounts_Column3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonYTDActualAmounts_Column3.TabIndex = 15
            Me.RadioButtonYTDActualAmounts_Column3.TabOnEnter = True
            Me.RadioButtonYTDActualAmounts_Column3.TabStop = False
            Me.RadioButtonYTDActualAmounts_Column3.Tag = "3"
            Me.RadioButtonYTDActualAmounts_Column3.Text = "Column 3"
            '
            'RadioButtonYTDActualAmounts_Column5
            '
            Me.RadioButtonYTDActualAmounts_Column5.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonYTDActualAmounts_Column5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonYTDActualAmounts_Column5.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonYTDActualAmounts_Column5.Location = New System.Drawing.Point(349, 0)
            Me.RadioButtonYTDActualAmounts_Column5.Name = "RadioButtonYTDActualAmounts_Column5"
            Me.RadioButtonYTDActualAmounts_Column5.SecurityEnabled = True
            Me.RadioButtonYTDActualAmounts_Column5.Size = New System.Drawing.Size(65, 18)
            Me.RadioButtonYTDActualAmounts_Column5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonYTDActualAmounts_Column5.TabIndex = 54
            Me.RadioButtonYTDActualAmounts_Column5.TabOnEnter = True
            Me.RadioButtonYTDActualAmounts_Column5.TabStop = False
            Me.RadioButtonYTDActualAmounts_Column5.Tag = "5"
            Me.RadioButtonYTDActualAmounts_Column5.Text = "Column 5"
            '
            'RadioButtonYTDActualAmounts_Exclude
            '
            Me.RadioButtonYTDActualAmounts_Exclude.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonYTDActualAmounts_Exclude.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonYTDActualAmounts_Exclude.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonYTDActualAmounts_Exclude.Location = New System.Drawing.Point(-1, 0)
            Me.RadioButtonYTDActualAmounts_Exclude.Name = "RadioButtonYTDActualAmounts_Exclude"
            Me.RadioButtonYTDActualAmounts_Exclude.SecurityEnabled = True
            Me.RadioButtonYTDActualAmounts_Exclude.Size = New System.Drawing.Size(65, 18)
            Me.RadioButtonYTDActualAmounts_Exclude.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonYTDActualAmounts_Exclude.TabIndex = 0
            Me.RadioButtonYTDActualAmounts_Exclude.TabOnEnter = True
            Me.RadioButtonYTDActualAmounts_Exclude.TabStop = False
            Me.RadioButtonYTDActualAmounts_Exclude.Tag = "0"
            Me.RadioButtonYTDActualAmounts_Exclude.Text = "Exclude"
            '
            'RadioButtonYTDActualAmounts_Column4
            '
            Me.RadioButtonYTDActualAmounts_Column4.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonYTDActualAmounts_Column4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonYTDActualAmounts_Column4.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonYTDActualAmounts_Column4.Location = New System.Drawing.Point(279, 0)
            Me.RadioButtonYTDActualAmounts_Column4.Name = "RadioButtonYTDActualAmounts_Column4"
            Me.RadioButtonYTDActualAmounts_Column4.SecurityEnabled = True
            Me.RadioButtonYTDActualAmounts_Column4.Size = New System.Drawing.Size(65, 18)
            Me.RadioButtonYTDActualAmounts_Column4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonYTDActualAmounts_Column4.TabIndex = 53
            Me.RadioButtonYTDActualAmounts_Column4.TabOnEnter = True
            Me.RadioButtonYTDActualAmounts_Column4.TabStop = False
            Me.RadioButtonYTDActualAmounts_Column4.Tag = "4"
            Me.RadioButtonYTDActualAmounts_Column4.Text = "Column 4"
            '
            'RadioButtonYTDActualAmounts_Column2
            '
            Me.RadioButtonYTDActualAmounts_Column2.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonYTDActualAmounts_Column2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonYTDActualAmounts_Column2.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonYTDActualAmounts_Column2.Location = New System.Drawing.Point(139, 0)
            Me.RadioButtonYTDActualAmounts_Column2.Name = "RadioButtonYTDActualAmounts_Column2"
            Me.RadioButtonYTDActualAmounts_Column2.SecurityEnabled = True
            Me.RadioButtonYTDActualAmounts_Column2.Size = New System.Drawing.Size(65, 18)
            Me.RadioButtonYTDActualAmounts_Column2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonYTDActualAmounts_Column2.TabIndex = 14
            Me.RadioButtonYTDActualAmounts_Column2.TabOnEnter = True
            Me.RadioButtonYTDActualAmounts_Column2.TabStop = False
            Me.RadioButtonYTDActualAmounts_Column2.Tag = "2"
            Me.RadioButtonYTDActualAmounts_Column2.Text = "Column 2"
            '
            'RadioButtonYTDActualAmounts_Column1
            '
            Me.RadioButtonYTDActualAmounts_Column1.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonYTDActualAmounts_Column1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonYTDActualAmounts_Column1.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonYTDActualAmounts_Column1.Location = New System.Drawing.Point(69, 0)
            Me.RadioButtonYTDActualAmounts_Column1.Name = "RadioButtonYTDActualAmounts_Column1"
            Me.RadioButtonYTDActualAmounts_Column1.SecurityEnabled = True
            Me.RadioButtonYTDActualAmounts_Column1.Size = New System.Drawing.Size(65, 18)
            Me.RadioButtonYTDActualAmounts_Column1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonYTDActualAmounts_Column1.TabIndex = 13
            Me.RadioButtonYTDActualAmounts_Column1.TabOnEnter = True
            Me.RadioButtonYTDActualAmounts_Column1.TabStop = False
            Me.RadioButtonYTDActualAmounts_Column1.Tag = "1"
            Me.RadioButtonYTDActualAmounts_Column1.Text = "Column 1"
            '
            'GroupBoxOptions_AccountsToBudget
            '
            Me.GroupBoxOptions_AccountsToBudget.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxOptions_AccountsToBudget.Controls.Add(Me.CheckBoxAccountsToBudget_ExpenseCOS)
            Me.GroupBoxOptions_AccountsToBudget.Controls.Add(Me.CheckBoxAccountsToBudget_ExpenseOperating)
            Me.GroupBoxOptions_AccountsToBudget.Controls.Add(Me.CheckBoxAccountsToBudget_ExpenseOther)
            Me.GroupBoxOptions_AccountsToBudget.Controls.Add(Me.CheckBoxAccountsToBudget_ExpenseTaxes)
            Me.GroupBoxOptions_AccountsToBudget.Controls.Add(Me.CheckBoxAccountsToBudget_IncomeOther)
            Me.GroupBoxOptions_AccountsToBudget.Controls.Add(Me.CheckBoxAccountsToBudget_Income)
            Me.GroupBoxOptions_AccountsToBudget.Controls.Add(Me.CheckBoxAccountsToBudget_NonCurrentLiabilities)
            Me.GroupBoxOptions_AccountsToBudget.Controls.Add(Me.CheckBoxAccountsToBudget_CurrentLiabilities)
            Me.GroupBoxOptions_AccountsToBudget.Controls.Add(Me.CheckBoxAccountsToBudget_FixedAssets)
            Me.GroupBoxOptions_AccountsToBudget.Controls.Add(Me.CheckBoxAccountsToBudget_NonCurrentAssets)
            Me.GroupBoxOptions_AccountsToBudget.Controls.Add(Me.CheckBoxAccountsToBudget_CurrentAssets)
            Me.GroupBoxOptions_AccountsToBudget.Location = New System.Drawing.Point(593, 5)
            Me.GroupBoxOptions_AccountsToBudget.Name = "GroupBoxOptions_AccountsToBudget"
            Me.GroupBoxOptions_AccountsToBudget.Size = New System.Drawing.Size(230, 252)
            Me.GroupBoxOptions_AccountsToBudget.TabIndex = 33
            Me.GroupBoxOptions_AccountsToBudget.Text = "Accounts To Budget"
            '
            'CheckBoxAccountsToBudget_ExpenseCOS
            '
            '
            '
            '
            Me.CheckBoxAccountsToBudget_ExpenseCOS.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxAccountsToBudget_ExpenseCOS.CheckValue = 0
            Me.CheckBoxAccountsToBudget_ExpenseCOS.CheckValueChecked = 1
            Me.CheckBoxAccountsToBudget_ExpenseCOS.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxAccountsToBudget_ExpenseCOS.CheckValueUnchecked = 0
            Me.CheckBoxAccountsToBudget_ExpenseCOS.ChildControls = CType(resources.GetObject("CheckBoxAccountsToBudget_ExpenseCOS.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAccountsToBudget_ExpenseCOS.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxAccountsToBudget_ExpenseCOS.Location = New System.Drawing.Point(3, 173)
            Me.CheckBoxAccountsToBudget_ExpenseCOS.Margin = New System.Windows.Forms.Padding(2)
            Me.CheckBoxAccountsToBudget_ExpenseCOS.Name = "CheckBoxAccountsToBudget_ExpenseCOS"
            Me.CheckBoxAccountsToBudget_ExpenseCOS.OldestSibling = Nothing
            Me.CheckBoxAccountsToBudget_ExpenseCOS.SecurityEnabled = True
            Me.CheckBoxAccountsToBudget_ExpenseCOS.SiblingControls = CType(resources.GetObject("CheckBoxAccountsToBudget_ExpenseCOS.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAccountsToBudget_ExpenseCOS.Size = New System.Drawing.Size(141, 15)
            Me.CheckBoxAccountsToBudget_ExpenseCOS.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxAccountsToBudget_ExpenseCOS.TabIndex = 65
            Me.CheckBoxAccountsToBudget_ExpenseCOS.TabOnEnter = True
            Me.CheckBoxAccountsToBudget_ExpenseCOS.Tag = "0"
            Me.CheckBoxAccountsToBudget_ExpenseCOS.Text = "Expense-COS"
            '
            'CheckBoxAccountsToBudget_ExpenseOperating
            '
            '
            '
            '
            Me.CheckBoxAccountsToBudget_ExpenseOperating.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxAccountsToBudget_ExpenseOperating.CheckValue = 0
            Me.CheckBoxAccountsToBudget_ExpenseOperating.CheckValueChecked = 1
            Me.CheckBoxAccountsToBudget_ExpenseOperating.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxAccountsToBudget_ExpenseOperating.CheckValueUnchecked = 0
            Me.CheckBoxAccountsToBudget_ExpenseOperating.ChildControls = CType(resources.GetObject("CheckBoxAccountsToBudget_ExpenseOperating.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAccountsToBudget_ExpenseOperating.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxAccountsToBudget_ExpenseOperating.Location = New System.Drawing.Point(3, 192)
            Me.CheckBoxAccountsToBudget_ExpenseOperating.Margin = New System.Windows.Forms.Padding(2)
            Me.CheckBoxAccountsToBudget_ExpenseOperating.Name = "CheckBoxAccountsToBudget_ExpenseOperating"
            Me.CheckBoxAccountsToBudget_ExpenseOperating.OldestSibling = Nothing
            Me.CheckBoxAccountsToBudget_ExpenseOperating.SecurityEnabled = True
            Me.CheckBoxAccountsToBudget_ExpenseOperating.SiblingControls = CType(resources.GetObject("CheckBoxAccountsToBudget_ExpenseOperating.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAccountsToBudget_ExpenseOperating.Size = New System.Drawing.Size(141, 15)
            Me.CheckBoxAccountsToBudget_ExpenseOperating.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxAccountsToBudget_ExpenseOperating.TabIndex = 64
            Me.CheckBoxAccountsToBudget_ExpenseOperating.TabOnEnter = True
            Me.CheckBoxAccountsToBudget_ExpenseOperating.Tag = "0"
            Me.CheckBoxAccountsToBudget_ExpenseOperating.Text = "Expense-Operating"
            '
            'CheckBoxAccountsToBudget_ExpenseOther
            '
            '
            '
            '
            Me.CheckBoxAccountsToBudget_ExpenseOther.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxAccountsToBudget_ExpenseOther.CheckValue = 0
            Me.CheckBoxAccountsToBudget_ExpenseOther.CheckValueChecked = 1
            Me.CheckBoxAccountsToBudget_ExpenseOther.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxAccountsToBudget_ExpenseOther.CheckValueUnchecked = 0
            Me.CheckBoxAccountsToBudget_ExpenseOther.ChildControls = CType(resources.GetObject("CheckBoxAccountsToBudget_ExpenseOther.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAccountsToBudget_ExpenseOther.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxAccountsToBudget_ExpenseOther.Location = New System.Drawing.Point(3, 211)
            Me.CheckBoxAccountsToBudget_ExpenseOther.Margin = New System.Windows.Forms.Padding(2)
            Me.CheckBoxAccountsToBudget_ExpenseOther.Name = "CheckBoxAccountsToBudget_ExpenseOther"
            Me.CheckBoxAccountsToBudget_ExpenseOther.OldestSibling = Nothing
            Me.CheckBoxAccountsToBudget_ExpenseOther.SecurityEnabled = True
            Me.CheckBoxAccountsToBudget_ExpenseOther.SiblingControls = CType(resources.GetObject("CheckBoxAccountsToBudget_ExpenseOther.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAccountsToBudget_ExpenseOther.Size = New System.Drawing.Size(141, 15)
            Me.CheckBoxAccountsToBudget_ExpenseOther.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxAccountsToBudget_ExpenseOther.TabIndex = 63
            Me.CheckBoxAccountsToBudget_ExpenseOther.TabOnEnter = True
            Me.CheckBoxAccountsToBudget_ExpenseOther.Tag = "0"
            Me.CheckBoxAccountsToBudget_ExpenseOther.Text = "Expense-Other"
            '
            'CheckBoxAccountsToBudget_ExpenseTaxes
            '
            '
            '
            '
            Me.CheckBoxAccountsToBudget_ExpenseTaxes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxAccountsToBudget_ExpenseTaxes.CheckValue = 0
            Me.CheckBoxAccountsToBudget_ExpenseTaxes.CheckValueChecked = 1
            Me.CheckBoxAccountsToBudget_ExpenseTaxes.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxAccountsToBudget_ExpenseTaxes.CheckValueUnchecked = 0
            Me.CheckBoxAccountsToBudget_ExpenseTaxes.ChildControls = CType(resources.GetObject("CheckBoxAccountsToBudget_ExpenseTaxes.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAccountsToBudget_ExpenseTaxes.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxAccountsToBudget_ExpenseTaxes.Location = New System.Drawing.Point(3, 229)
            Me.CheckBoxAccountsToBudget_ExpenseTaxes.Margin = New System.Windows.Forms.Padding(2)
            Me.CheckBoxAccountsToBudget_ExpenseTaxes.Name = "CheckBoxAccountsToBudget_ExpenseTaxes"
            Me.CheckBoxAccountsToBudget_ExpenseTaxes.OldestSibling = Nothing
            Me.CheckBoxAccountsToBudget_ExpenseTaxes.SecurityEnabled = True
            Me.CheckBoxAccountsToBudget_ExpenseTaxes.SiblingControls = CType(resources.GetObject("CheckBoxAccountsToBudget_ExpenseTaxes.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAccountsToBudget_ExpenseTaxes.Size = New System.Drawing.Size(141, 15)
            Me.CheckBoxAccountsToBudget_ExpenseTaxes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxAccountsToBudget_ExpenseTaxes.TabIndex = 62
            Me.CheckBoxAccountsToBudget_ExpenseTaxes.TabOnEnter = True
            Me.CheckBoxAccountsToBudget_ExpenseTaxes.Tag = "0"
            Me.CheckBoxAccountsToBudget_ExpenseTaxes.Text = "Expense-Taxes"
            '
            'CheckBoxAccountsToBudget_IncomeOther
            '
            '
            '
            '
            Me.CheckBoxAccountsToBudget_IncomeOther.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxAccountsToBudget_IncomeOther.CheckValue = 0
            Me.CheckBoxAccountsToBudget_IncomeOther.CheckValueChecked = 1
            Me.CheckBoxAccountsToBudget_IncomeOther.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxAccountsToBudget_IncomeOther.CheckValueUnchecked = 0
            Me.CheckBoxAccountsToBudget_IncomeOther.ChildControls = CType(resources.GetObject("CheckBoxAccountsToBudget_IncomeOther.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAccountsToBudget_IncomeOther.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxAccountsToBudget_IncomeOther.Location = New System.Drawing.Point(3, 154)
            Me.CheckBoxAccountsToBudget_IncomeOther.Margin = New System.Windows.Forms.Padding(2)
            Me.CheckBoxAccountsToBudget_IncomeOther.Name = "CheckBoxAccountsToBudget_IncomeOther"
            Me.CheckBoxAccountsToBudget_IncomeOther.OldestSibling = Nothing
            Me.CheckBoxAccountsToBudget_IncomeOther.SecurityEnabled = True
            Me.CheckBoxAccountsToBudget_IncomeOther.SiblingControls = CType(resources.GetObject("CheckBoxAccountsToBudget_IncomeOther.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAccountsToBudget_IncomeOther.Size = New System.Drawing.Size(141, 15)
            Me.CheckBoxAccountsToBudget_IncomeOther.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxAccountsToBudget_IncomeOther.TabIndex = 61
            Me.CheckBoxAccountsToBudget_IncomeOther.TabOnEnter = True
            Me.CheckBoxAccountsToBudget_IncomeOther.Tag = "0"
            Me.CheckBoxAccountsToBudget_IncomeOther.Text = "Income-Other"
            '
            'CheckBoxAccountsToBudget_Income
            '
            '
            '
            '
            Me.CheckBoxAccountsToBudget_Income.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxAccountsToBudget_Income.CheckValue = 0
            Me.CheckBoxAccountsToBudget_Income.CheckValueChecked = 1
            Me.CheckBoxAccountsToBudget_Income.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxAccountsToBudget_Income.CheckValueUnchecked = 0
            Me.CheckBoxAccountsToBudget_Income.ChildControls = CType(resources.GetObject("CheckBoxAccountsToBudget_Income.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAccountsToBudget_Income.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxAccountsToBudget_Income.Location = New System.Drawing.Point(3, 135)
            Me.CheckBoxAccountsToBudget_Income.Margin = New System.Windows.Forms.Padding(2)
            Me.CheckBoxAccountsToBudget_Income.Name = "CheckBoxAccountsToBudget_Income"
            Me.CheckBoxAccountsToBudget_Income.OldestSibling = Nothing
            Me.CheckBoxAccountsToBudget_Income.SecurityEnabled = True
            Me.CheckBoxAccountsToBudget_Income.SiblingControls = CType(resources.GetObject("CheckBoxAccountsToBudget_Income.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAccountsToBudget_Income.Size = New System.Drawing.Size(141, 15)
            Me.CheckBoxAccountsToBudget_Income.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxAccountsToBudget_Income.TabIndex = 60
            Me.CheckBoxAccountsToBudget_Income.TabOnEnter = True
            Me.CheckBoxAccountsToBudget_Income.Tag = "0"
            Me.CheckBoxAccountsToBudget_Income.Text = "Income"
            '
            'CheckBoxAccountsToBudget_NonCurrentLiabilities
            '
            '
            '
            '
            Me.CheckBoxAccountsToBudget_NonCurrentLiabilities.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxAccountsToBudget_NonCurrentLiabilities.CheckValue = 0
            Me.CheckBoxAccountsToBudget_NonCurrentLiabilities.CheckValueChecked = 1
            Me.CheckBoxAccountsToBudget_NonCurrentLiabilities.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxAccountsToBudget_NonCurrentLiabilities.CheckValueUnchecked = 0
            Me.CheckBoxAccountsToBudget_NonCurrentLiabilities.ChildControls = CType(resources.GetObject("CheckBoxAccountsToBudget_NonCurrentLiabilities.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAccountsToBudget_NonCurrentLiabilities.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxAccountsToBudget_NonCurrentLiabilities.Location = New System.Drawing.Point(3, 97)
            Me.CheckBoxAccountsToBudget_NonCurrentLiabilities.Margin = New System.Windows.Forms.Padding(2)
            Me.CheckBoxAccountsToBudget_NonCurrentLiabilities.Name = "CheckBoxAccountsToBudget_NonCurrentLiabilities"
            Me.CheckBoxAccountsToBudget_NonCurrentLiabilities.OldestSibling = Nothing
            Me.CheckBoxAccountsToBudget_NonCurrentLiabilities.SecurityEnabled = True
            Me.CheckBoxAccountsToBudget_NonCurrentLiabilities.SiblingControls = CType(resources.GetObject("CheckBoxAccountsToBudget_NonCurrentLiabilities.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAccountsToBudget_NonCurrentLiabilities.Size = New System.Drawing.Size(141, 15)
            Me.CheckBoxAccountsToBudget_NonCurrentLiabilities.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxAccountsToBudget_NonCurrentLiabilities.TabIndex = 59
            Me.CheckBoxAccountsToBudget_NonCurrentLiabilities.TabOnEnter = True
            Me.CheckBoxAccountsToBudget_NonCurrentLiabilities.Tag = "0"
            Me.CheckBoxAccountsToBudget_NonCurrentLiabilities.Text = "Non Current Liabilities"
            '
            'CheckBoxAccountsToBudget_CurrentLiabilities
            '
            '
            '
            '
            Me.CheckBoxAccountsToBudget_CurrentLiabilities.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxAccountsToBudget_CurrentLiabilities.CheckValue = 0
            Me.CheckBoxAccountsToBudget_CurrentLiabilities.CheckValueChecked = 1
            Me.CheckBoxAccountsToBudget_CurrentLiabilities.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxAccountsToBudget_CurrentLiabilities.CheckValueUnchecked = 0
            Me.CheckBoxAccountsToBudget_CurrentLiabilities.ChildControls = CType(resources.GetObject("CheckBoxAccountsToBudget_CurrentLiabilities.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAccountsToBudget_CurrentLiabilities.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxAccountsToBudget_CurrentLiabilities.Location = New System.Drawing.Point(3, 79)
            Me.CheckBoxAccountsToBudget_CurrentLiabilities.Margin = New System.Windows.Forms.Padding(2)
            Me.CheckBoxAccountsToBudget_CurrentLiabilities.Name = "CheckBoxAccountsToBudget_CurrentLiabilities"
            Me.CheckBoxAccountsToBudget_CurrentLiabilities.OldestSibling = Nothing
            Me.CheckBoxAccountsToBudget_CurrentLiabilities.SecurityEnabled = True
            Me.CheckBoxAccountsToBudget_CurrentLiabilities.SiblingControls = CType(resources.GetObject("CheckBoxAccountsToBudget_CurrentLiabilities.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAccountsToBudget_CurrentLiabilities.Size = New System.Drawing.Size(141, 15)
            Me.CheckBoxAccountsToBudget_CurrentLiabilities.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxAccountsToBudget_CurrentLiabilities.TabIndex = 58
            Me.CheckBoxAccountsToBudget_CurrentLiabilities.TabOnEnter = True
            Me.CheckBoxAccountsToBudget_CurrentLiabilities.Tag = "0"
            Me.CheckBoxAccountsToBudget_CurrentLiabilities.Text = "Current Liabilities"
            '
            'CheckBoxAccountsToBudget_FixedAssets
            '
            '
            '
            '
            Me.CheckBoxAccountsToBudget_FixedAssets.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxAccountsToBudget_FixedAssets.CheckValue = 0
            Me.CheckBoxAccountsToBudget_FixedAssets.CheckValueChecked = 1
            Me.CheckBoxAccountsToBudget_FixedAssets.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxAccountsToBudget_FixedAssets.CheckValueUnchecked = 0
            Me.CheckBoxAccountsToBudget_FixedAssets.ChildControls = CType(resources.GetObject("CheckBoxAccountsToBudget_FixedAssets.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAccountsToBudget_FixedAssets.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxAccountsToBudget_FixedAssets.Location = New System.Drawing.Point(3, 60)
            Me.CheckBoxAccountsToBudget_FixedAssets.Margin = New System.Windows.Forms.Padding(2)
            Me.CheckBoxAccountsToBudget_FixedAssets.Name = "CheckBoxAccountsToBudget_FixedAssets"
            Me.CheckBoxAccountsToBudget_FixedAssets.OldestSibling = Nothing
            Me.CheckBoxAccountsToBudget_FixedAssets.SecurityEnabled = True
            Me.CheckBoxAccountsToBudget_FixedAssets.SiblingControls = CType(resources.GetObject("CheckBoxAccountsToBudget_FixedAssets.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAccountsToBudget_FixedAssets.Size = New System.Drawing.Size(141, 15)
            Me.CheckBoxAccountsToBudget_FixedAssets.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxAccountsToBudget_FixedAssets.TabIndex = 57
            Me.CheckBoxAccountsToBudget_FixedAssets.TabOnEnter = True
            Me.CheckBoxAccountsToBudget_FixedAssets.Tag = "0"
            Me.CheckBoxAccountsToBudget_FixedAssets.Text = "Fixed Assets"
            '
            'CheckBoxAccountsToBudget_NonCurrentAssets
            '
            '
            '
            '
            Me.CheckBoxAccountsToBudget_NonCurrentAssets.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxAccountsToBudget_NonCurrentAssets.CheckValue = 0
            Me.CheckBoxAccountsToBudget_NonCurrentAssets.CheckValueChecked = 1
            Me.CheckBoxAccountsToBudget_NonCurrentAssets.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxAccountsToBudget_NonCurrentAssets.CheckValueUnchecked = 0
            Me.CheckBoxAccountsToBudget_NonCurrentAssets.ChildControls = CType(resources.GetObject("CheckBoxAccountsToBudget_NonCurrentAssets.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAccountsToBudget_NonCurrentAssets.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxAccountsToBudget_NonCurrentAssets.Location = New System.Drawing.Point(3, 41)
            Me.CheckBoxAccountsToBudget_NonCurrentAssets.Margin = New System.Windows.Forms.Padding(2)
            Me.CheckBoxAccountsToBudget_NonCurrentAssets.Name = "CheckBoxAccountsToBudget_NonCurrentAssets"
            Me.CheckBoxAccountsToBudget_NonCurrentAssets.OldestSibling = Nothing
            Me.CheckBoxAccountsToBudget_NonCurrentAssets.SecurityEnabled = True
            Me.CheckBoxAccountsToBudget_NonCurrentAssets.SiblingControls = CType(resources.GetObject("CheckBoxAccountsToBudget_NonCurrentAssets.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAccountsToBudget_NonCurrentAssets.Size = New System.Drawing.Size(141, 15)
            Me.CheckBoxAccountsToBudget_NonCurrentAssets.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxAccountsToBudget_NonCurrentAssets.TabIndex = 56
            Me.CheckBoxAccountsToBudget_NonCurrentAssets.TabOnEnter = True
            Me.CheckBoxAccountsToBudget_NonCurrentAssets.Tag = "0"
            Me.CheckBoxAccountsToBudget_NonCurrentAssets.Text = "Non Current Assets"
            '
            'CheckBoxAccountsToBudget_CurrentAssets
            '
            '
            '
            '
            Me.CheckBoxAccountsToBudget_CurrentAssets.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxAccountsToBudget_CurrentAssets.CheckValue = 0
            Me.CheckBoxAccountsToBudget_CurrentAssets.CheckValueChecked = 1
            Me.CheckBoxAccountsToBudget_CurrentAssets.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxAccountsToBudget_CurrentAssets.CheckValueUnchecked = 0
            Me.CheckBoxAccountsToBudget_CurrentAssets.ChildControls = CType(resources.GetObject("CheckBoxAccountsToBudget_CurrentAssets.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAccountsToBudget_CurrentAssets.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxAccountsToBudget_CurrentAssets.Location = New System.Drawing.Point(3, 22)
            Me.CheckBoxAccountsToBudget_CurrentAssets.Margin = New System.Windows.Forms.Padding(2)
            Me.CheckBoxAccountsToBudget_CurrentAssets.Name = "CheckBoxAccountsToBudget_CurrentAssets"
            Me.CheckBoxAccountsToBudget_CurrentAssets.OldestSibling = Nothing
            Me.CheckBoxAccountsToBudget_CurrentAssets.SecurityEnabled = True
            Me.CheckBoxAccountsToBudget_CurrentAssets.SiblingControls = CType(resources.GetObject("CheckBoxAccountsToBudget_CurrentAssets.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAccountsToBudget_CurrentAssets.Size = New System.Drawing.Size(141, 15)
            Me.CheckBoxAccountsToBudget_CurrentAssets.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxAccountsToBudget_CurrentAssets.TabIndex = 55
            Me.CheckBoxAccountsToBudget_CurrentAssets.TabOnEnter = True
            Me.CheckBoxAccountsToBudget_CurrentAssets.Tag = "0"
            Me.CheckBoxAccountsToBudget_CurrentAssets.Text = "Current Assets"
            '
            'TabItemTabs_Options
            '
            Me.TabItemTabs_Options.AttachedControl = Me.TabControlPanelStatus_Status
            Me.TabItemTabs_Options.Name = "TabItemTabs_Options"
            Me.TabItemTabs_Options.Text = "Options"
            '
            'TabControlPanelVendors_Vendors
            '
            Me.TabControlPanelVendors_Vendors.Controls.Add(Me.TextBoxDefaults_DefaultFormat)
            Me.TabControlPanelVendors_Vendors.Controls.Add(Me.LabelDefaults_DefaultFormat)
            Me.TabControlPanelVendors_Vendors.Controls.Add(Me.GroupBoxDefaults_CurrencyFormat)
            Me.TabControlPanelVendors_Vendors.Controls.Add(Me.GroupBoxDefaults_PostingPeriodFormat)
            Me.TabControlPanelVendors_Vendors.Controls.Add(Me.GroupBoxDefaults_FiscalYearOptions)
            Me.TabControlPanelVendors_Vendors.Controls.Add(Me.GroupBoxDefaults_AccountCodeFormat)
            Me.TabControlPanelVendors_Vendors.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelVendors_Vendors.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelVendors_Vendors.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelVendors_Vendors.Name = "TabControlPanelVendors_Vendors"
            Me.TabControlPanelVendors_Vendors.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelVendors_Vendors.Size = New System.Drawing.Size(827, 405)
            Me.TabControlPanelVendors_Vendors.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelVendors_Vendors.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelVendors_Vendors.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelVendors_Vendors.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelVendors_Vendors.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelVendors_Vendors.Style.GradientAngle = 90
            Me.TabControlPanelVendors_Vendors.TabIndex = 0
            Me.TabControlPanelVendors_Vendors.TabItem = Me.TabItemTabs_Defaults
            '
            'TextBoxDefaults_DefaultFormat
            '
            Me.TextBoxDefaults_DefaultFormat.Location = New System.Drawing.Point(89, 6)
            Me.TextBoxDefaults_DefaultFormat.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
            Me.TextBoxDefaults_DefaultFormat.Name = "TextBoxDefaults_DefaultFormat"
            Me.TextBoxDefaults_DefaultFormat.Size = New System.Drawing.Size(98, 13)
            Me.TextBoxDefaults_DefaultFormat.TabIndex = 36
            '
            'LabelDefaults_DefaultFormat
            '
            Me.LabelDefaults_DefaultFormat.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDefaults_DefaultFormat.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDefaults_DefaultFormat.Location = New System.Drawing.Point(7, 3)
            Me.LabelDefaults_DefaultFormat.Margin = New System.Windows.Forms.Padding(2)
            Me.LabelDefaults_DefaultFormat.Name = "LabelDefaults_DefaultFormat"
            Me.LabelDefaults_DefaultFormat.Size = New System.Drawing.Size(78, 18)
            Me.LabelDefaults_DefaultFormat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDefaults_DefaultFormat.TabIndex = 32
            Me.LabelDefaults_DefaultFormat.Text = "Default Format"
            '
            'GroupBoxDefaults_CurrencyFormat
            '
            Me.GroupBoxDefaults_CurrencyFormat.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxDefaults_CurrencyFormat.Controls.Add(Me.TextBoxCurrencyFormat_CurrencySymbol)
            Me.GroupBoxDefaults_CurrencyFormat.Controls.Add(Me.LabelCurrencyFormat_CurrencySymbol)
            Me.GroupBoxDefaults_CurrencyFormat.Location = New System.Drawing.Point(406, 190)
            Me.GroupBoxDefaults_CurrencyFormat.Name = "GroupBoxDefaults_CurrencyFormat"
            Me.GroupBoxDefaults_CurrencyFormat.Size = New System.Drawing.Size(417, 121)
            Me.GroupBoxDefaults_CurrencyFormat.TabIndex = 31
            Me.GroupBoxDefaults_CurrencyFormat.Text = "Currency Format - G/L Report Writer"
            '
            'TextBoxCurrencyFormat_CurrencySymbol
            '
            Me.TextBoxCurrencyFormat_CurrencySymbol.AgencyImportPath = Nothing
            '
            '
            '
            Me.TextBoxCurrencyFormat_CurrencySymbol.Border.Class = "TextBoxBorder"
            Me.TextBoxCurrencyFormat_CurrencySymbol.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxCurrencyFormat_CurrencySymbol.CheckSpellingOnValidate = False
            Me.TextBoxCurrencyFormat_CurrencySymbol.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxCurrencyFormat_CurrencySymbol.DisplayName = ""
            Me.TextBoxCurrencyFormat_CurrencySymbol.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxCurrencyFormat_CurrencySymbol.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxCurrencyFormat_CurrencySymbol.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxCurrencyFormat_CurrencySymbol.FocusHighlightEnabled = True
            Me.TextBoxCurrencyFormat_CurrencySymbol.Location = New System.Drawing.Point(97, 23)
            Me.TextBoxCurrencyFormat_CurrencySymbol.Margin = New System.Windows.Forms.Padding(2)
            Me.TextBoxCurrencyFormat_CurrencySymbol.MaxFileSize = CType(0, Long)
            Me.TextBoxCurrencyFormat_CurrencySymbol.Name = "TextBoxCurrencyFormat_CurrencySymbol"
            Me.TextBoxCurrencyFormat_CurrencySymbol.PreventEnterBeep = True
            Me.TextBoxCurrencyFormat_CurrencySymbol.SecurityEnabled = True
            Me.TextBoxCurrencyFormat_CurrencySymbol.ShowSpellCheckCompleteMessage = True
            Me.TextBoxCurrencyFormat_CurrencySymbol.Size = New System.Drawing.Size(81, 21)
            Me.TextBoxCurrencyFormat_CurrencySymbol.StartingFolderName = Nothing
            Me.TextBoxCurrencyFormat_CurrencySymbol.TabIndex = 51
            Me.TextBoxCurrencyFormat_CurrencySymbol.TabOnEnter = True
            Me.TextBoxCurrencyFormat_CurrencySymbol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'LabelCurrencyFormat_CurrencySymbol
            '
            Me.LabelCurrencyFormat_CurrencySymbol.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCurrencyFormat_CurrencySymbol.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCurrencyFormat_CurrencySymbol.Location = New System.Drawing.Point(4, 23)
            Me.LabelCurrencyFormat_CurrencySymbol.Margin = New System.Windows.Forms.Padding(2)
            Me.LabelCurrencyFormat_CurrencySymbol.Name = "LabelCurrencyFormat_CurrencySymbol"
            Me.LabelCurrencyFormat_CurrencySymbol.Size = New System.Drawing.Size(89, 18)
            Me.LabelCurrencyFormat_CurrencySymbol.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCurrencyFormat_CurrencySymbol.TabIndex = 20
            Me.LabelCurrencyFormat_CurrencySymbol.Text = "Currency Symbol"
            '
            'GroupBoxDefaults_PostingPeriodFormat
            '
            Me.GroupBoxDefaults_PostingPeriodFormat.Controls.Add(Me.LabelPostingPeriodFormat_Option2)
            Me.GroupBoxDefaults_PostingPeriodFormat.Controls.Add(Me.LabelPostingPeriodFormat_Option1)
            Me.GroupBoxDefaults_PostingPeriodFormat.Controls.Add(Me.RadioButtonPostingPeriodFormat_Option2)
            Me.GroupBoxDefaults_PostingPeriodFormat.Controls.Add(Me.RadioButtonPostingPeriodFormat_Option1)
            Me.GroupBoxDefaults_PostingPeriodFormat.Location = New System.Drawing.Point(5, 190)
            Me.GroupBoxDefaults_PostingPeriodFormat.Name = "GroupBoxDefaults_PostingPeriodFormat"
            Me.GroupBoxDefaults_PostingPeriodFormat.Size = New System.Drawing.Size(396, 121)
            Me.GroupBoxDefaults_PostingPeriodFormat.TabIndex = 29
            Me.GroupBoxDefaults_PostingPeriodFormat.Text = "Posting Period Format"
            '
            'LabelPostingPeriodFormat_Option2
            '
            Me.LabelPostingPeriodFormat_Option2.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPostingPeriodFormat_Option2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPostingPeriodFormat_Option2.Location = New System.Drawing.Point(68, 97)
            Me.LabelPostingPeriodFormat_Option2.Margin = New System.Windows.Forms.Padding(2)
            Me.LabelPostingPeriodFormat_Option2.Name = "LabelPostingPeriodFormat_Option2"
            Me.LabelPostingPeriodFormat_Option2.Size = New System.Drawing.Size(271, 18)
            Me.LabelPostingPeriodFormat_Option2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPostingPeriodFormat_Option2.TabIndex = 37
            Me.LabelPostingPeriodFormat_Option2.Text = "(YYYYMM - where MM does not equal calendar month)"
            '
            'LabelPostingPeriodFormat_Option1
            '
            Me.LabelPostingPeriodFormat_Option1.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPostingPeriodFormat_Option1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPostingPeriodFormat_Option1.Location = New System.Drawing.Point(68, 46)
            Me.LabelPostingPeriodFormat_Option1.Margin = New System.Windows.Forms.Padding(2)
            Me.LabelPostingPeriodFormat_Option1.Name = "LabelPostingPeriodFormat_Option1"
            Me.LabelPostingPeriodFormat_Option1.Size = New System.Drawing.Size(271, 18)
            Me.LabelPostingPeriodFormat_Option1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPostingPeriodFormat_Option1.TabIndex = 36
            Me.LabelPostingPeriodFormat_Option1.Text = "(YYYYMM - where MM is equal to calendar month)"
            '
            'RadioButtonPostingPeriodFormat_Option2
            '
            Me.RadioButtonPostingPeriodFormat_Option2.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonPostingPeriodFormat_Option2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonPostingPeriodFormat_Option2.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonPostingPeriodFormat_Option2.Location = New System.Drawing.Point(5, 75)
            Me.RadioButtonPostingPeriodFormat_Option2.Name = "RadioButtonPostingPeriodFormat_Option2"
            Me.RadioButtonPostingPeriodFormat_Option2.SecurityEnabled = True
            Me.RadioButtonPostingPeriodFormat_Option2.Size = New System.Drawing.Size(375, 18)
            Me.RadioButtonPostingPeriodFormat_Option2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonPostingPeriodFormat_Option2.TabIndex = 15
            Me.RadioButtonPostingPeriodFormat_Option2.TabOnEnter = True
            Me.RadioButtonPostingPeriodFormat_Option2.TabStop = False
            Me.RadioButtonPostingPeriodFormat_Option2.Tag = "2"
            Me.RadioButtonPostingPeriodFormat_Option2.Text = "Option 2 - Posting period month does not equal calendar month"
            '
            'RadioButtonPostingPeriodFormat_Option1
            '
            Me.RadioButtonPostingPeriodFormat_Option1.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonPostingPeriodFormat_Option1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonPostingPeriodFormat_Option1.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonPostingPeriodFormat_Option1.Location = New System.Drawing.Point(5, 23)
            Me.RadioButtonPostingPeriodFormat_Option1.Name = "RadioButtonPostingPeriodFormat_Option1"
            Me.RadioButtonPostingPeriodFormat_Option1.SecurityEnabled = True
            Me.RadioButtonPostingPeriodFormat_Option1.Size = New System.Drawing.Size(374, 18)
            Me.RadioButtonPostingPeriodFormat_Option1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonPostingPeriodFormat_Option1.TabIndex = 14
            Me.RadioButtonPostingPeriodFormat_Option1.TabOnEnter = True
            Me.RadioButtonPostingPeriodFormat_Option1.TabStop = False
            Me.RadioButtonPostingPeriodFormat_Option1.Tag = "1"
            Me.RadioButtonPostingPeriodFormat_Option1.Text = "Option 1 - Posting period month equals calendar month"
            '
            'GroupBoxDefaults_FiscalYearOptions
            '
            Me.GroupBoxDefaults_FiscalYearOptions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxDefaults_FiscalYearOptions.Controls.Add(Me.RadioButtonFiscalYearOptions_BeginsInCurrent)
            Me.GroupBoxDefaults_FiscalYearOptions.Controls.Add(Me.RadioButtonFiscalYearOptions_BeginsInPrevious)
            Me.GroupBoxDefaults_FiscalYearOptions.Location = New System.Drawing.Point(5, 317)
            Me.GroupBoxDefaults_FiscalYearOptions.Name = "GroupBoxDefaults_FiscalYearOptions"
            Me.GroupBoxDefaults_FiscalYearOptions.Size = New System.Drawing.Size(819, 73)
            Me.GroupBoxDefaults_FiscalYearOptions.TabIndex = 30
            Me.GroupBoxDefaults_FiscalYearOptions.Text = "Fiscal Year Options"
            '
            'RadioButtonFiscalYearOptions_BeginsInCurrent
            '
            Me.RadioButtonFiscalYearOptions_BeginsInCurrent.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonFiscalYearOptions_BeginsInCurrent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonFiscalYearOptions_BeginsInCurrent.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonFiscalYearOptions_BeginsInCurrent.Location = New System.Drawing.Point(5, 47)
            Me.RadioButtonFiscalYearOptions_BeginsInCurrent.Name = "RadioButtonFiscalYearOptions_BeginsInCurrent"
            Me.RadioButtonFiscalYearOptions_BeginsInCurrent.SecurityEnabled = True
            Me.RadioButtonFiscalYearOptions_BeginsInCurrent.Size = New System.Drawing.Size(353, 18)
            Me.RadioButtonFiscalYearOptions_BeginsInCurrent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonFiscalYearOptions_BeginsInCurrent.TabIndex = 45
            Me.RadioButtonFiscalYearOptions_BeginsInCurrent.TabOnEnter = True
            Me.RadioButtonFiscalYearOptions_BeginsInCurrent.TabStop = False
            Me.RadioButtonFiscalYearOptions_BeginsInCurrent.Tag = "3"
            Me.RadioButtonFiscalYearOptions_BeginsInCurrent.Text = "Fiscal year begins in the current calendar year"
            '
            'RadioButtonFiscalYearOptions_BeginsInPrevious
            '
            Me.RadioButtonFiscalYearOptions_BeginsInPrevious.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonFiscalYearOptions_BeginsInPrevious.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonFiscalYearOptions_BeginsInPrevious.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonFiscalYearOptions_BeginsInPrevious.Location = New System.Drawing.Point(5, 23)
            Me.RadioButtonFiscalYearOptions_BeginsInPrevious.Name = "RadioButtonFiscalYearOptions_BeginsInPrevious"
            Me.RadioButtonFiscalYearOptions_BeginsInPrevious.SecurityEnabled = True
            Me.RadioButtonFiscalYearOptions_BeginsInPrevious.Size = New System.Drawing.Size(353, 18)
            Me.RadioButtonFiscalYearOptions_BeginsInPrevious.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonFiscalYearOptions_BeginsInPrevious.TabIndex = 44
            Me.RadioButtonFiscalYearOptions_BeginsInPrevious.TabOnEnter = True
            Me.RadioButtonFiscalYearOptions_BeginsInPrevious.TabStop = False
            Me.RadioButtonFiscalYearOptions_BeginsInPrevious.Tag = "2"
            Me.RadioButtonFiscalYearOptions_BeginsInPrevious.Text = "Fiscal year begins in the previous calendar year"
            '
            'GroupBoxDefaults_AccountCodeFormat
            '
            Me.GroupBoxDefaults_AccountCodeFormat.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxDefaults_AccountCodeFormat.Controls.Add(Me.Panel2AccountCodeFormat_Segment3)
            Me.GroupBoxDefaults_AccountCodeFormat.Controls.Add(Me.LabelDefaults_FiscalYearStartMonth)
            Me.GroupBoxDefaults_AccountCodeFormat.Controls.Add(Me.ComboBoxDefaults_FiscalYearStartMonth)
            Me.GroupBoxDefaults_AccountCodeFormat.Controls.Add(Me.Panel2AccountCodeFormat_Segment2)
            Me.GroupBoxDefaults_AccountCodeFormat.Controls.Add(Me.Panel1AccountCodeFormat_Segment3)
            Me.GroupBoxDefaults_AccountCodeFormat.Controls.Add(Me.Panel2AccountCodeFormat_Segment1)
            Me.GroupBoxDefaults_AccountCodeFormat.Controls.Add(Me.Panel1AccountCodeFormat_Segment4)
            Me.GroupBoxDefaults_AccountCodeFormat.Controls.Add(Me.Panel1AccountCodeFormat_Segment1)
            Me.GroupBoxDefaults_AccountCodeFormat.Controls.Add(Me.TextBoxAccountCodeFormat_Segment4Description)
            Me.GroupBoxDefaults_AccountCodeFormat.Controls.Add(Me.Panel1AccountCodeFormat_Segment2)
            Me.GroupBoxDefaults_AccountCodeFormat.Controls.Add(Me.TextBoxAccountCodeFormat_Segment4)
            Me.GroupBoxDefaults_AccountCodeFormat.Controls.Add(Me.LabelAccountCodeFormat_Segment4)
            Me.GroupBoxDefaults_AccountCodeFormat.Controls.Add(Me.TextBoxAccountCodeFormat_Segment3Description)
            Me.GroupBoxDefaults_AccountCodeFormat.Controls.Add(Me.TextBoxAccountCodeFormat_Segment3)
            Me.GroupBoxDefaults_AccountCodeFormat.Controls.Add(Me.LabelAccountCodeFormat_Segment3)
            Me.GroupBoxDefaults_AccountCodeFormat.Controls.Add(Me.TextBoxAccountCodeFormat_Segment2Description)
            Me.GroupBoxDefaults_AccountCodeFormat.Controls.Add(Me.TextBoxAccountCodeFormat_Segment2)
            Me.GroupBoxDefaults_AccountCodeFormat.Controls.Add(Me.LabelAccountCodeFormat_Segment2)
            Me.GroupBoxDefaults_AccountCodeFormat.Controls.Add(Me.TextBoxAccountCodeFormat_Segment1Description)
            Me.GroupBoxDefaults_AccountCodeFormat.Controls.Add(Me.TextBoxAccountCodeFormat_Segment1)
            Me.GroupBoxDefaults_AccountCodeFormat.Controls.Add(Me.LabelAccountCodeFormat_Segment1)
            Me.GroupBoxDefaults_AccountCodeFormat.Location = New System.Drawing.Point(5, 25)
            Me.GroupBoxDefaults_AccountCodeFormat.Name = "GroupBoxDefaults_AccountCodeFormat"
            Me.GroupBoxDefaults_AccountCodeFormat.Size = New System.Drawing.Size(819, 159)
            Me.GroupBoxDefaults_AccountCodeFormat.TabIndex = 28
            Me.GroupBoxDefaults_AccountCodeFormat.Text = "Account Code Format"
            '
            'Panel2AccountCodeFormat_Segment3
            '
            Me.Panel2AccountCodeFormat_Segment3.Appearance.BackColor = System.Drawing.Color.Transparent
            Me.Panel2AccountCodeFormat_Segment3.Appearance.Options.UseBackColor = True
            Me.Panel2AccountCodeFormat_Segment3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.Panel2AccountCodeFormat_Segment3.Controls.Add(Me.CheckBoxAccountCodeFormat_Segment3Hyphen)
            Me.Panel2AccountCodeFormat_Segment3.Controls.Add(Me.CheckBoxAccountCodeFormat_Segment3Period)
            Me.Panel2AccountCodeFormat_Segment3.Controls.Add(Me.LabelAccountCodeFormat_Segment3Or)
            Me.Panel2AccountCodeFormat_Segment3.Controls.Add(Me.LabelAccountCodeFormat_Segment3After)
            Me.Panel2AccountCodeFormat_Segment3.Location = New System.Drawing.Point(480, 75)
            Me.Panel2AccountCodeFormat_Segment3.LookAndFeel.SkinName = "Office 2013"
            Me.Panel2AccountCodeFormat_Segment3.LookAndFeel.UseDefaultLookAndFeel = False
            Me.Panel2AccountCodeFormat_Segment3.Margin = New System.Windows.Forms.Padding(2)
            Me.Panel2AccountCodeFormat_Segment3.Name = "Panel2AccountCodeFormat_Segment3"
            Me.Panel2AccountCodeFormat_Segment3.Size = New System.Drawing.Size(222, 18)
            Me.Panel2AccountCodeFormat_Segment3.TabIndex = 12
            '
            'CheckBoxAccountCodeFormat_Segment3Hyphen
            '
            '
            '
            '
            Me.CheckBoxAccountCodeFormat_Segment3Hyphen.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxAccountCodeFormat_Segment3Hyphen.CheckValue = 0
            Me.CheckBoxAccountCodeFormat_Segment3Hyphen.CheckValueChecked = 1
            Me.CheckBoxAccountCodeFormat_Segment3Hyphen.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxAccountCodeFormat_Segment3Hyphen.CheckValueUnchecked = 0
            Me.CheckBoxAccountCodeFormat_Segment3Hyphen.ChildControls = CType(resources.GetObject("CheckBoxAccountCodeFormat_Segment3Hyphen.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAccountCodeFormat_Segment3Hyphen.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxAccountCodeFormat_Segment3Hyphen.Enabled = False
            Me.CheckBoxAccountCodeFormat_Segment3Hyphen.Location = New System.Drawing.Point(0, 0)
            Me.CheckBoxAccountCodeFormat_Segment3Hyphen.Margin = New System.Windows.Forms.Padding(2)
            Me.CheckBoxAccountCodeFormat_Segment3Hyphen.Name = "CheckBoxAccountCodeFormat_Segment3Hyphen"
            Me.CheckBoxAccountCodeFormat_Segment3Hyphen.OldestSibling = Nothing
            Me.CheckBoxAccountCodeFormat_Segment3Hyphen.SecurityEnabled = True
            Me.CheckBoxAccountCodeFormat_Segment3Hyphen.SiblingControls = CType(resources.GetObject("CheckBoxAccountCodeFormat_Segment3Hyphen.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAccountCodeFormat_Segment3Hyphen.Size = New System.Drawing.Size(105, 20)
            Me.CheckBoxAccountCodeFormat_Segment3Hyphen.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxAccountCodeFormat_Segment3Hyphen.TabIndex = 34
            Me.CheckBoxAccountCodeFormat_Segment3Hyphen.TabOnEnter = True
            Me.CheckBoxAccountCodeFormat_Segment3Hyphen.Tag = "1"
            Me.CheckBoxAccountCodeFormat_Segment3Hyphen.Text = "Insert Hyphen (-)"
            '
            'CheckBoxAccountCodeFormat_Segment3Period
            '
            '
            '
            '
            Me.CheckBoxAccountCodeFormat_Segment3Period.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxAccountCodeFormat_Segment3Period.CheckValue = 0
            Me.CheckBoxAccountCodeFormat_Segment3Period.CheckValueChecked = 1
            Me.CheckBoxAccountCodeFormat_Segment3Period.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxAccountCodeFormat_Segment3Period.CheckValueUnchecked = 0
            Me.CheckBoxAccountCodeFormat_Segment3Period.ChildControls = CType(resources.GetObject("CheckBoxAccountCodeFormat_Segment3Period.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAccountCodeFormat_Segment3Period.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxAccountCodeFormat_Segment3Period.Enabled = False
            Me.CheckBoxAccountCodeFormat_Segment3Period.Location = New System.Drawing.Point(129, 0)
            Me.CheckBoxAccountCodeFormat_Segment3Period.Margin = New System.Windows.Forms.Padding(2)
            Me.CheckBoxAccountCodeFormat_Segment3Period.Name = "CheckBoxAccountCodeFormat_Segment3Period"
            Me.CheckBoxAccountCodeFormat_Segment3Period.OldestSibling = Nothing
            Me.CheckBoxAccountCodeFormat_Segment3Period.SecurityEnabled = True
            Me.CheckBoxAccountCodeFormat_Segment3Period.SiblingControls = CType(resources.GetObject("CheckBoxAccountCodeFormat_Segment3Period.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAccountCodeFormat_Segment3Period.Size = New System.Drawing.Size(64, 20)
            Me.CheckBoxAccountCodeFormat_Segment3Period.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxAccountCodeFormat_Segment3Period.TabIndex = 40
            Me.CheckBoxAccountCodeFormat_Segment3Period.TabOnEnter = True
            Me.CheckBoxAccountCodeFormat_Segment3Period.Tag = "2"
            Me.CheckBoxAccountCodeFormat_Segment3Period.Text = "Period (.)"
            '
            'LabelAccountCodeFormat_Segment3Or
            '
            Me.LabelAccountCodeFormat_Segment3Or.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAccountCodeFormat_Segment3Or.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAccountCodeFormat_Segment3Or.Location = New System.Drawing.Point(109, 0)
            Me.LabelAccountCodeFormat_Segment3Or.Margin = New System.Windows.Forms.Padding(2)
            Me.LabelAccountCodeFormat_Segment3Or.Name = "LabelAccountCodeFormat_Segment3Or"
            Me.LabelAccountCodeFormat_Segment3Or.Size = New System.Drawing.Size(14, 18)
            Me.LabelAccountCodeFormat_Segment3Or.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAccountCodeFormat_Segment3Or.TabIndex = 41
            Me.LabelAccountCodeFormat_Segment3Or.Text = "Or"
            '
            'LabelAccountCodeFormat_Segment3After
            '
            Me.LabelAccountCodeFormat_Segment3After.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAccountCodeFormat_Segment3After.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAccountCodeFormat_Segment3After.Location = New System.Drawing.Point(197, 0)
            Me.LabelAccountCodeFormat_Segment3After.Margin = New System.Windows.Forms.Padding(2)
            Me.LabelAccountCodeFormat_Segment3After.Name = "LabelAccountCodeFormat_Segment3After"
            Me.LabelAccountCodeFormat_Segment3After.Size = New System.Drawing.Size(25, 18)
            Me.LabelAccountCodeFormat_Segment3After.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAccountCodeFormat_Segment3After.TabIndex = 42
            Me.LabelAccountCodeFormat_Segment3After.Text = "After"
            '
            'LabelDefaults_FiscalYearStartMonth
            '
            Me.LabelDefaults_FiscalYearStartMonth.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDefaults_FiscalYearStartMonth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDefaults_FiscalYearStartMonth.Location = New System.Drawing.Point(4, 127)
            Me.LabelDefaults_FiscalYearStartMonth.Margin = New System.Windows.Forms.Padding(2)
            Me.LabelDefaults_FiscalYearStartMonth.Name = "LabelDefaults_FiscalYearStartMonth"
            Me.LabelDefaults_FiscalYearStartMonth.Size = New System.Drawing.Size(121, 18)
            Me.LabelDefaults_FiscalYearStartMonth.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDefaults_FiscalYearStartMonth.TabIndex = 35
            Me.LabelDefaults_FiscalYearStartMonth.Text = "Fiscal Year Start Month"
            '
            'ComboBoxDefaults_FiscalYearStartMonth
            '
            Me.ComboBoxDefaults_FiscalYearStartMonth.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxDefaults_FiscalYearStartMonth.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
            Me.ComboBoxDefaults_FiscalYearStartMonth.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxDefaults_FiscalYearStartMonth.AutoFindItemInDataSource = True
            Me.ComboBoxDefaults_FiscalYearStartMonth.AutoSelectSingleItemDatasource = False
            Me.ComboBoxDefaults_FiscalYearStartMonth.BookmarkingEnabled = False
            Me.ComboBoxDefaults_FiscalYearStartMonth.DisableMouseWheel = True
            Me.ComboBoxDefaults_FiscalYearStartMonth.DisplayMember = "Display"
            Me.ComboBoxDefaults_FiscalYearStartMonth.DisplayName = "Report Type"
            Me.ComboBoxDefaults_FiscalYearStartMonth.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxDefaults_FiscalYearStartMonth.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxDefaults_FiscalYearStartMonth.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxDefaults_FiscalYearStartMonth.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxDefaults_FiscalYearStartMonth.FocusHighlightEnabled = True
            Me.ComboBoxDefaults_FiscalYearStartMonth.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxDefaults_FiscalYearStartMonth.FormattingEnabled = True
            Me.ComboBoxDefaults_FiscalYearStartMonth.ItemHeight = 16
            Me.ComboBoxDefaults_FiscalYearStartMonth.Location = New System.Drawing.Point(130, 127)
            Me.ComboBoxDefaults_FiscalYearStartMonth.Name = "ComboBoxDefaults_FiscalYearStartMonth"
            Me.ComboBoxDefaults_FiscalYearStartMonth.ReadOnly = False
            Me.ComboBoxDefaults_FiscalYearStartMonth.SecurityEnabled = True
            Me.ComboBoxDefaults_FiscalYearStartMonth.Size = New System.Drawing.Size(122, 22)
            Me.ComboBoxDefaults_FiscalYearStartMonth.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxDefaults_FiscalYearStartMonth.TabIndex = 16
            Me.ComboBoxDefaults_FiscalYearStartMonth.TabOnEnter = True
            Me.ComboBoxDefaults_FiscalYearStartMonth.ValueMember = "Value"
            Me.ComboBoxDefaults_FiscalYearStartMonth.WatermarkText = "Select Month"
            '
            'Panel2AccountCodeFormat_Segment2
            '
            Me.Panel2AccountCodeFormat_Segment2.Appearance.BackColor = System.Drawing.Color.Transparent
            Me.Panel2AccountCodeFormat_Segment2.Appearance.Options.UseBackColor = True
            Me.Panel2AccountCodeFormat_Segment2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.Panel2AccountCodeFormat_Segment2.Controls.Add(Me.CheckBoxAccountCodeFormat_Segment2Hyphen)
            Me.Panel2AccountCodeFormat_Segment2.Controls.Add(Me.CheckBoxAccountCodeFormat_Segment2Period)
            Me.Panel2AccountCodeFormat_Segment2.Controls.Add(Me.LabelAccountCodeFormat_Segment2Or)
            Me.Panel2AccountCodeFormat_Segment2.Controls.Add(Me.LabelAccountCodeFormat_Segment2After)
            Me.Panel2AccountCodeFormat_Segment2.Location = New System.Drawing.Point(480, 49)
            Me.Panel2AccountCodeFormat_Segment2.LookAndFeel.SkinName = "Office 2013"
            Me.Panel2AccountCodeFormat_Segment2.LookAndFeel.UseDefaultLookAndFeel = False
            Me.Panel2AccountCodeFormat_Segment2.Margin = New System.Windows.Forms.Padding(2)
            Me.Panel2AccountCodeFormat_Segment2.Name = "Panel2AccountCodeFormat_Segment2"
            Me.Panel2AccountCodeFormat_Segment2.Size = New System.Drawing.Size(222, 18)
            Me.Panel2AccountCodeFormat_Segment2.TabIndex = 8
            '
            'CheckBoxAccountCodeFormat_Segment2Hyphen
            '
            '
            '
            '
            Me.CheckBoxAccountCodeFormat_Segment2Hyphen.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxAccountCodeFormat_Segment2Hyphen.CheckValue = 0
            Me.CheckBoxAccountCodeFormat_Segment2Hyphen.CheckValueChecked = 1
            Me.CheckBoxAccountCodeFormat_Segment2Hyphen.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxAccountCodeFormat_Segment2Hyphen.CheckValueUnchecked = 0
            Me.CheckBoxAccountCodeFormat_Segment2Hyphen.ChildControls = CType(resources.GetObject("CheckBoxAccountCodeFormat_Segment2Hyphen.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAccountCodeFormat_Segment2Hyphen.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxAccountCodeFormat_Segment2Hyphen.Enabled = False
            Me.CheckBoxAccountCodeFormat_Segment2Hyphen.Location = New System.Drawing.Point(0, 0)
            Me.CheckBoxAccountCodeFormat_Segment2Hyphen.Margin = New System.Windows.Forms.Padding(2)
            Me.CheckBoxAccountCodeFormat_Segment2Hyphen.Name = "CheckBoxAccountCodeFormat_Segment2Hyphen"
            Me.CheckBoxAccountCodeFormat_Segment2Hyphen.OldestSibling = Nothing
            Me.CheckBoxAccountCodeFormat_Segment2Hyphen.SecurityEnabled = True
            Me.CheckBoxAccountCodeFormat_Segment2Hyphen.SiblingControls = CType(resources.GetObject("CheckBoxAccountCodeFormat_Segment2Hyphen.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAccountCodeFormat_Segment2Hyphen.Size = New System.Drawing.Size(105, 20)
            Me.CheckBoxAccountCodeFormat_Segment2Hyphen.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxAccountCodeFormat_Segment2Hyphen.TabIndex = 23
            Me.CheckBoxAccountCodeFormat_Segment2Hyphen.TabOnEnter = True
            Me.CheckBoxAccountCodeFormat_Segment2Hyphen.Tag = "1"
            Me.CheckBoxAccountCodeFormat_Segment2Hyphen.Text = "Insert Hyphen (-)"
            '
            'CheckBoxAccountCodeFormat_Segment2Period
            '
            '
            '
            '
            Me.CheckBoxAccountCodeFormat_Segment2Period.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxAccountCodeFormat_Segment2Period.CheckValue = 0
            Me.CheckBoxAccountCodeFormat_Segment2Period.CheckValueChecked = 1
            Me.CheckBoxAccountCodeFormat_Segment2Period.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxAccountCodeFormat_Segment2Period.CheckValueUnchecked = 0
            Me.CheckBoxAccountCodeFormat_Segment2Period.ChildControls = CType(resources.GetObject("CheckBoxAccountCodeFormat_Segment2Period.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAccountCodeFormat_Segment2Period.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxAccountCodeFormat_Segment2Period.Enabled = False
            Me.CheckBoxAccountCodeFormat_Segment2Period.Location = New System.Drawing.Point(129, 0)
            Me.CheckBoxAccountCodeFormat_Segment2Period.Margin = New System.Windows.Forms.Padding(2)
            Me.CheckBoxAccountCodeFormat_Segment2Period.Name = "CheckBoxAccountCodeFormat_Segment2Period"
            Me.CheckBoxAccountCodeFormat_Segment2Period.OldestSibling = Nothing
            Me.CheckBoxAccountCodeFormat_Segment2Period.SecurityEnabled = True
            Me.CheckBoxAccountCodeFormat_Segment2Period.SiblingControls = CType(resources.GetObject("CheckBoxAccountCodeFormat_Segment2Period.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAccountCodeFormat_Segment2Period.Size = New System.Drawing.Size(64, 20)
            Me.CheckBoxAccountCodeFormat_Segment2Period.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxAccountCodeFormat_Segment2Period.TabIndex = 29
            Me.CheckBoxAccountCodeFormat_Segment2Period.TabOnEnter = True
            Me.CheckBoxAccountCodeFormat_Segment2Period.Tag = "2"
            Me.CheckBoxAccountCodeFormat_Segment2Period.Text = "Period (.)"
            '
            'LabelAccountCodeFormat_Segment2Or
            '
            Me.LabelAccountCodeFormat_Segment2Or.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAccountCodeFormat_Segment2Or.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAccountCodeFormat_Segment2Or.Location = New System.Drawing.Point(109, 0)
            Me.LabelAccountCodeFormat_Segment2Or.Margin = New System.Windows.Forms.Padding(2)
            Me.LabelAccountCodeFormat_Segment2Or.Name = "LabelAccountCodeFormat_Segment2Or"
            Me.LabelAccountCodeFormat_Segment2Or.Size = New System.Drawing.Size(14, 18)
            Me.LabelAccountCodeFormat_Segment2Or.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAccountCodeFormat_Segment2Or.TabIndex = 30
            Me.LabelAccountCodeFormat_Segment2Or.Text = "Or"
            '
            'LabelAccountCodeFormat_Segment2After
            '
            Me.LabelAccountCodeFormat_Segment2After.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAccountCodeFormat_Segment2After.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAccountCodeFormat_Segment2After.Location = New System.Drawing.Point(197, 0)
            Me.LabelAccountCodeFormat_Segment2After.Margin = New System.Windows.Forms.Padding(2)
            Me.LabelAccountCodeFormat_Segment2After.Name = "LabelAccountCodeFormat_Segment2After"
            Me.LabelAccountCodeFormat_Segment2After.Size = New System.Drawing.Size(25, 18)
            Me.LabelAccountCodeFormat_Segment2After.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAccountCodeFormat_Segment2After.TabIndex = 31
            Me.LabelAccountCodeFormat_Segment2After.Text = "After"
            '
            'Panel1AccountCodeFormat_Segment3
            '
            Me.Panel1AccountCodeFormat_Segment3.Appearance.BackColor = System.Drawing.Color.Transparent
            Me.Panel1AccountCodeFormat_Segment3.Appearance.Options.UseBackColor = True
            Me.Panel1AccountCodeFormat_Segment3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.Panel1AccountCodeFormat_Segment3.Controls.Add(Me.RadioButtonAccountCodeFormat_Segment3Base)
            Me.Panel1AccountCodeFormat_Segment3.Controls.Add(Me.RadioButtonAccountCodeFormat_Segment3Other)
            Me.Panel1AccountCodeFormat_Segment3.Controls.Add(Me.RadioButtonAccountCodeFormat_Segment3Office)
            Me.Panel1AccountCodeFormat_Segment3.Controls.Add(Me.RadioButtonAccountCodeFormat_Segment3Department)
            Me.Panel1AccountCodeFormat_Segment3.Location = New System.Drawing.Point(154, 75)
            Me.Panel1AccountCodeFormat_Segment3.LookAndFeel.SkinName = "Office 2013"
            Me.Panel1AccountCodeFormat_Segment3.LookAndFeel.UseDefaultLookAndFeel = False
            Me.Panel1AccountCodeFormat_Segment3.Margin = New System.Windows.Forms.Padding(2)
            Me.Panel1AccountCodeFormat_Segment3.Name = "Panel1AccountCodeFormat_Segment3"
            Me.Panel1AccountCodeFormat_Segment3.Size = New System.Drawing.Size(237, 18)
            Me.Panel1AccountCodeFormat_Segment3.TabIndex = 10
            '
            'RadioButtonAccountCodeFormat_Segment3Base
            '
            Me.RadioButtonAccountCodeFormat_Segment3Base.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonAccountCodeFormat_Segment3Base.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonAccountCodeFormat_Segment3Base.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonAccountCodeFormat_Segment3Base.Location = New System.Drawing.Point(0, 0)
            Me.RadioButtonAccountCodeFormat_Segment3Base.Name = "RadioButtonAccountCodeFormat_Segment3Base"
            Me.RadioButtonAccountCodeFormat_Segment3Base.SecurityEnabled = True
            Me.RadioButtonAccountCodeFormat_Segment3Base.Size = New System.Drawing.Size(45, 18)
            Me.RadioButtonAccountCodeFormat_Segment3Base.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonAccountCodeFormat_Segment3Base.TabIndex = 32
            Me.RadioButtonAccountCodeFormat_Segment3Base.TabOnEnter = True
            Me.RadioButtonAccountCodeFormat_Segment3Base.TabStop = False
            Me.RadioButtonAccountCodeFormat_Segment3Base.Tag = "1"
            Me.RadioButtonAccountCodeFormat_Segment3Base.Text = "Base"
            '
            'RadioButtonAccountCodeFormat_Segment3Other
            '
            Me.RadioButtonAccountCodeFormat_Segment3Other.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonAccountCodeFormat_Segment3Other.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonAccountCodeFormat_Segment3Other.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonAccountCodeFormat_Segment3Other.Location = New System.Drawing.Point(191, 0)
            Me.RadioButtonAccountCodeFormat_Segment3Other.Name = "RadioButtonAccountCodeFormat_Segment3Other"
            Me.RadioButtonAccountCodeFormat_Segment3Other.SecurityEnabled = True
            Me.RadioButtonAccountCodeFormat_Segment3Other.Size = New System.Drawing.Size(46, 18)
            Me.RadioButtonAccountCodeFormat_Segment3Other.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonAccountCodeFormat_Segment3Other.TabIndex = 37
            Me.RadioButtonAccountCodeFormat_Segment3Other.TabOnEnter = True
            Me.RadioButtonAccountCodeFormat_Segment3Other.TabStop = False
            Me.RadioButtonAccountCodeFormat_Segment3Other.Tag = "4"
            Me.RadioButtonAccountCodeFormat_Segment3Other.Text = "Other"
            '
            'RadioButtonAccountCodeFormat_Segment3Office
            '
            Me.RadioButtonAccountCodeFormat_Segment3Office.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonAccountCodeFormat_Segment3Office.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonAccountCodeFormat_Segment3Office.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonAccountCodeFormat_Segment3Office.Location = New System.Drawing.Point(51, 0)
            Me.RadioButtonAccountCodeFormat_Segment3Office.Name = "RadioButtonAccountCodeFormat_Segment3Office"
            Me.RadioButtonAccountCodeFormat_Segment3Office.SecurityEnabled = True
            Me.RadioButtonAccountCodeFormat_Segment3Office.Size = New System.Drawing.Size(46, 18)
            Me.RadioButtonAccountCodeFormat_Segment3Office.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonAccountCodeFormat_Segment3Office.TabIndex = 35
            Me.RadioButtonAccountCodeFormat_Segment3Office.TabOnEnter = True
            Me.RadioButtonAccountCodeFormat_Segment3Office.TabStop = False
            Me.RadioButtonAccountCodeFormat_Segment3Office.Tag = "2"
            Me.RadioButtonAccountCodeFormat_Segment3Office.Text = "Office"
            '
            'RadioButtonAccountCodeFormat_Segment3Department
            '
            Me.RadioButtonAccountCodeFormat_Segment3Department.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonAccountCodeFormat_Segment3Department.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonAccountCodeFormat_Segment3Department.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonAccountCodeFormat_Segment3Department.Location = New System.Drawing.Point(102, 0)
            Me.RadioButtonAccountCodeFormat_Segment3Department.Name = "RadioButtonAccountCodeFormat_Segment3Department"
            Me.RadioButtonAccountCodeFormat_Segment3Department.SecurityEnabled = True
            Me.RadioButtonAccountCodeFormat_Segment3Department.Size = New System.Drawing.Size(84, 18)
            Me.RadioButtonAccountCodeFormat_Segment3Department.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonAccountCodeFormat_Segment3Department.TabIndex = 36
            Me.RadioButtonAccountCodeFormat_Segment3Department.TabOnEnter = True
            Me.RadioButtonAccountCodeFormat_Segment3Department.TabStop = False
            Me.RadioButtonAccountCodeFormat_Segment3Department.Tag = "3"
            Me.RadioButtonAccountCodeFormat_Segment3Department.Text = "Department"
            '
            'Panel2AccountCodeFormat_Segment1
            '
            Me.Panel2AccountCodeFormat_Segment1.Appearance.BackColor = System.Drawing.Color.Transparent
            Me.Panel2AccountCodeFormat_Segment1.Appearance.Options.UseBackColor = True
            Me.Panel2AccountCodeFormat_Segment1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.Panel2AccountCodeFormat_Segment1.Controls.Add(Me.CheckBoxAccountCodeFormat_Segment1Hyphen)
            Me.Panel2AccountCodeFormat_Segment1.Controls.Add(Me.CheckBoxAccountCodeFormat_Segment1Period)
            Me.Panel2AccountCodeFormat_Segment1.Controls.Add(Me.LabelAccountCodeFormat_Segment1Or)
            Me.Panel2AccountCodeFormat_Segment1.Controls.Add(Me.LabelAccountCodeFormat_Segment1After)
            Me.Panel2AccountCodeFormat_Segment1.Location = New System.Drawing.Point(480, 23)
            Me.Panel2AccountCodeFormat_Segment1.LookAndFeel.SkinName = "Office 2013"
            Me.Panel2AccountCodeFormat_Segment1.LookAndFeel.UseDefaultLookAndFeel = False
            Me.Panel2AccountCodeFormat_Segment1.Margin = New System.Windows.Forms.Padding(2)
            Me.Panel2AccountCodeFormat_Segment1.Name = "Panel2AccountCodeFormat_Segment1"
            Me.Panel2AccountCodeFormat_Segment1.Size = New System.Drawing.Size(222, 18)
            Me.Panel2AccountCodeFormat_Segment1.TabIndex = 4
            '
            'CheckBoxAccountCodeFormat_Segment1Hyphen
            '
            '
            '
            '
            Me.CheckBoxAccountCodeFormat_Segment1Hyphen.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxAccountCodeFormat_Segment1Hyphen.CheckValue = 0
            Me.CheckBoxAccountCodeFormat_Segment1Hyphen.CheckValueChecked = 1
            Me.CheckBoxAccountCodeFormat_Segment1Hyphen.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxAccountCodeFormat_Segment1Hyphen.CheckValueUnchecked = 0
            Me.CheckBoxAccountCodeFormat_Segment1Hyphen.ChildControls = CType(resources.GetObject("CheckBoxAccountCodeFormat_Segment1Hyphen.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAccountCodeFormat_Segment1Hyphen.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxAccountCodeFormat_Segment1Hyphen.Enabled = False
            Me.CheckBoxAccountCodeFormat_Segment1Hyphen.Location = New System.Drawing.Point(0, 0)
            Me.CheckBoxAccountCodeFormat_Segment1Hyphen.Margin = New System.Windows.Forms.Padding(2)
            Me.CheckBoxAccountCodeFormat_Segment1Hyphen.Name = "CheckBoxAccountCodeFormat_Segment1Hyphen"
            Me.CheckBoxAccountCodeFormat_Segment1Hyphen.OldestSibling = Nothing
            Me.CheckBoxAccountCodeFormat_Segment1Hyphen.SecurityEnabled = True
            Me.CheckBoxAccountCodeFormat_Segment1Hyphen.SiblingControls = CType(resources.GetObject("CheckBoxAccountCodeFormat_Segment1Hyphen.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAccountCodeFormat_Segment1Hyphen.Size = New System.Drawing.Size(105, 20)
            Me.CheckBoxAccountCodeFormat_Segment1Hyphen.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxAccountCodeFormat_Segment1Hyphen.TabIndex = 9
            Me.CheckBoxAccountCodeFormat_Segment1Hyphen.TabOnEnter = True
            Me.CheckBoxAccountCodeFormat_Segment1Hyphen.Tag = "1"
            Me.CheckBoxAccountCodeFormat_Segment1Hyphen.Text = "Insert Hyphen (-)"
            '
            'CheckBoxAccountCodeFormat_Segment1Period
            '
            '
            '
            '
            Me.CheckBoxAccountCodeFormat_Segment1Period.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxAccountCodeFormat_Segment1Period.CheckValue = 0
            Me.CheckBoxAccountCodeFormat_Segment1Period.CheckValueChecked = 1
            Me.CheckBoxAccountCodeFormat_Segment1Period.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxAccountCodeFormat_Segment1Period.CheckValueUnchecked = 0
            Me.CheckBoxAccountCodeFormat_Segment1Period.ChildControls = CType(resources.GetObject("CheckBoxAccountCodeFormat_Segment1Period.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAccountCodeFormat_Segment1Period.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxAccountCodeFormat_Segment1Period.Enabled = False
            Me.CheckBoxAccountCodeFormat_Segment1Period.Location = New System.Drawing.Point(129, 0)
            Me.CheckBoxAccountCodeFormat_Segment1Period.Margin = New System.Windows.Forms.Padding(2)
            Me.CheckBoxAccountCodeFormat_Segment1Period.Name = "CheckBoxAccountCodeFormat_Segment1Period"
            Me.CheckBoxAccountCodeFormat_Segment1Period.OldestSibling = Nothing
            Me.CheckBoxAccountCodeFormat_Segment1Period.SecurityEnabled = True
            Me.CheckBoxAccountCodeFormat_Segment1Period.SiblingControls = CType(resources.GetObject("CheckBoxAccountCodeFormat_Segment1Period.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAccountCodeFormat_Segment1Period.Size = New System.Drawing.Size(64, 20)
            Me.CheckBoxAccountCodeFormat_Segment1Period.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxAccountCodeFormat_Segment1Period.TabIndex = 18
            Me.CheckBoxAccountCodeFormat_Segment1Period.TabOnEnter = True
            Me.CheckBoxAccountCodeFormat_Segment1Period.Tag = "2"
            Me.CheckBoxAccountCodeFormat_Segment1Period.Text = "Period (.)"
            '
            'LabelAccountCodeFormat_Segment1Or
            '
            Me.LabelAccountCodeFormat_Segment1Or.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAccountCodeFormat_Segment1Or.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAccountCodeFormat_Segment1Or.Location = New System.Drawing.Point(109, 0)
            Me.LabelAccountCodeFormat_Segment1Or.Margin = New System.Windows.Forms.Padding(2)
            Me.LabelAccountCodeFormat_Segment1Or.Name = "LabelAccountCodeFormat_Segment1Or"
            Me.LabelAccountCodeFormat_Segment1Or.Size = New System.Drawing.Size(14, 18)
            Me.LabelAccountCodeFormat_Segment1Or.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAccountCodeFormat_Segment1Or.TabIndex = 19
            Me.LabelAccountCodeFormat_Segment1Or.Text = "Or"
            '
            'LabelAccountCodeFormat_Segment1After
            '
            Me.LabelAccountCodeFormat_Segment1After.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAccountCodeFormat_Segment1After.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAccountCodeFormat_Segment1After.Location = New System.Drawing.Point(197, 0)
            Me.LabelAccountCodeFormat_Segment1After.Margin = New System.Windows.Forms.Padding(2)
            Me.LabelAccountCodeFormat_Segment1After.Name = "LabelAccountCodeFormat_Segment1After"
            Me.LabelAccountCodeFormat_Segment1After.Size = New System.Drawing.Size(25, 18)
            Me.LabelAccountCodeFormat_Segment1After.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAccountCodeFormat_Segment1After.TabIndex = 20
            Me.LabelAccountCodeFormat_Segment1After.Text = "After"
            '
            'Panel1AccountCodeFormat_Segment4
            '
            Me.Panel1AccountCodeFormat_Segment4.Appearance.BackColor = System.Drawing.Color.Transparent
            Me.Panel1AccountCodeFormat_Segment4.Appearance.Options.UseBackColor = True
            Me.Panel1AccountCodeFormat_Segment4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.Panel1AccountCodeFormat_Segment4.Controls.Add(Me.RadioButtonAccountCodeFormat_Segment4Base)
            Me.Panel1AccountCodeFormat_Segment4.Controls.Add(Me.RadioButtonAccountCodeFormat_Segment4Office)
            Me.Panel1AccountCodeFormat_Segment4.Controls.Add(Me.RadioButtonAccountCodeFormat_Segment4Department)
            Me.Panel1AccountCodeFormat_Segment4.Controls.Add(Me.RadioButtonAccountCodeFormat_Segment4Other)
            Me.Panel1AccountCodeFormat_Segment4.Location = New System.Drawing.Point(154, 101)
            Me.Panel1AccountCodeFormat_Segment4.LookAndFeel.SkinName = "Office 2013"
            Me.Panel1AccountCodeFormat_Segment4.LookAndFeel.UseDefaultLookAndFeel = False
            Me.Panel1AccountCodeFormat_Segment4.Margin = New System.Windows.Forms.Padding(2)
            Me.Panel1AccountCodeFormat_Segment4.Name = "Panel1AccountCodeFormat_Segment4"
            Me.Panel1AccountCodeFormat_Segment4.Size = New System.Drawing.Size(237, 18)
            Me.Panel1AccountCodeFormat_Segment4.TabIndex = 14
            '
            'RadioButtonAccountCodeFormat_Segment4Base
            '
            Me.RadioButtonAccountCodeFormat_Segment4Base.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonAccountCodeFormat_Segment4Base.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonAccountCodeFormat_Segment4Base.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonAccountCodeFormat_Segment4Base.Location = New System.Drawing.Point(0, 0)
            Me.RadioButtonAccountCodeFormat_Segment4Base.Name = "RadioButtonAccountCodeFormat_Segment4Base"
            Me.RadioButtonAccountCodeFormat_Segment4Base.SecurityEnabled = True
            Me.RadioButtonAccountCodeFormat_Segment4Base.Size = New System.Drawing.Size(45, 18)
            Me.RadioButtonAccountCodeFormat_Segment4Base.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonAccountCodeFormat_Segment4Base.TabIndex = 43
            Me.RadioButtonAccountCodeFormat_Segment4Base.TabOnEnter = True
            Me.RadioButtonAccountCodeFormat_Segment4Base.TabStop = False
            Me.RadioButtonAccountCodeFormat_Segment4Base.Tag = "1"
            Me.RadioButtonAccountCodeFormat_Segment4Base.Text = "Base"
            '
            'RadioButtonAccountCodeFormat_Segment4Office
            '
            Me.RadioButtonAccountCodeFormat_Segment4Office.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonAccountCodeFormat_Segment4Office.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonAccountCodeFormat_Segment4Office.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonAccountCodeFormat_Segment4Office.Location = New System.Drawing.Point(51, 0)
            Me.RadioButtonAccountCodeFormat_Segment4Office.Name = "RadioButtonAccountCodeFormat_Segment4Office"
            Me.RadioButtonAccountCodeFormat_Segment4Office.SecurityEnabled = True
            Me.RadioButtonAccountCodeFormat_Segment4Office.Size = New System.Drawing.Size(46, 18)
            Me.RadioButtonAccountCodeFormat_Segment4Office.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonAccountCodeFormat_Segment4Office.TabIndex = 46
            Me.RadioButtonAccountCodeFormat_Segment4Office.TabOnEnter = True
            Me.RadioButtonAccountCodeFormat_Segment4Office.TabStop = False
            Me.RadioButtonAccountCodeFormat_Segment4Office.Tag = "2"
            Me.RadioButtonAccountCodeFormat_Segment4Office.Text = "Office"
            '
            'RadioButtonAccountCodeFormat_Segment4Department
            '
            Me.RadioButtonAccountCodeFormat_Segment4Department.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonAccountCodeFormat_Segment4Department.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonAccountCodeFormat_Segment4Department.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonAccountCodeFormat_Segment4Department.Location = New System.Drawing.Point(102, 0)
            Me.RadioButtonAccountCodeFormat_Segment4Department.Name = "RadioButtonAccountCodeFormat_Segment4Department"
            Me.RadioButtonAccountCodeFormat_Segment4Department.SecurityEnabled = True
            Me.RadioButtonAccountCodeFormat_Segment4Department.Size = New System.Drawing.Size(84, 18)
            Me.RadioButtonAccountCodeFormat_Segment4Department.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonAccountCodeFormat_Segment4Department.TabIndex = 47
            Me.RadioButtonAccountCodeFormat_Segment4Department.TabOnEnter = True
            Me.RadioButtonAccountCodeFormat_Segment4Department.TabStop = False
            Me.RadioButtonAccountCodeFormat_Segment4Department.Tag = "3"
            Me.RadioButtonAccountCodeFormat_Segment4Department.Text = "Department"
            '
            'RadioButtonAccountCodeFormat_Segment4Other
            '
            Me.RadioButtonAccountCodeFormat_Segment4Other.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonAccountCodeFormat_Segment4Other.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonAccountCodeFormat_Segment4Other.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonAccountCodeFormat_Segment4Other.Location = New System.Drawing.Point(191, 0)
            Me.RadioButtonAccountCodeFormat_Segment4Other.Name = "RadioButtonAccountCodeFormat_Segment4Other"
            Me.RadioButtonAccountCodeFormat_Segment4Other.SecurityEnabled = True
            Me.RadioButtonAccountCodeFormat_Segment4Other.Size = New System.Drawing.Size(46, 18)
            Me.RadioButtonAccountCodeFormat_Segment4Other.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonAccountCodeFormat_Segment4Other.TabIndex = 48
            Me.RadioButtonAccountCodeFormat_Segment4Other.TabOnEnter = True
            Me.RadioButtonAccountCodeFormat_Segment4Other.TabStop = False
            Me.RadioButtonAccountCodeFormat_Segment4Other.Tag = "4"
            Me.RadioButtonAccountCodeFormat_Segment4Other.Text = "Other"
            '
            'Panel1AccountCodeFormat_Segment1
            '
            Me.Panel1AccountCodeFormat_Segment1.Appearance.BackColor = System.Drawing.Color.Transparent
            Me.Panel1AccountCodeFormat_Segment1.Appearance.Options.UseBackColor = True
            Me.Panel1AccountCodeFormat_Segment1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.Panel1AccountCodeFormat_Segment1.Controls.Add(Me.RadioButtonAccountCodeFormat_Segment1Other)
            Me.Panel1AccountCodeFormat_Segment1.Controls.Add(Me.RadioButtonAccountCodeFormat_Segment1Base)
            Me.Panel1AccountCodeFormat_Segment1.Controls.Add(Me.RadioButtonAccountCodeFormat_Segment1Department)
            Me.Panel1AccountCodeFormat_Segment1.Controls.Add(Me.RadioButtonAccountCodeFormat_Segment1Office)
            Me.Panel1AccountCodeFormat_Segment1.Location = New System.Drawing.Point(154, 23)
            Me.Panel1AccountCodeFormat_Segment1.LookAndFeel.SkinName = "Office 2013"
            Me.Panel1AccountCodeFormat_Segment1.LookAndFeel.UseDefaultLookAndFeel = False
            Me.Panel1AccountCodeFormat_Segment1.Margin = New System.Windows.Forms.Padding(2)
            Me.Panel1AccountCodeFormat_Segment1.Name = "Panel1AccountCodeFormat_Segment1"
            Me.Panel1AccountCodeFormat_Segment1.Size = New System.Drawing.Size(237, 18)
            Me.Panel1AccountCodeFormat_Segment1.TabIndex = 2
            '
            'RadioButtonAccountCodeFormat_Segment1Other
            '
            Me.RadioButtonAccountCodeFormat_Segment1Other.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonAccountCodeFormat_Segment1Other.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonAccountCodeFormat_Segment1Other.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonAccountCodeFormat_Segment1Other.Location = New System.Drawing.Point(191, 0)
            Me.RadioButtonAccountCodeFormat_Segment1Other.Name = "RadioButtonAccountCodeFormat_Segment1Other"
            Me.RadioButtonAccountCodeFormat_Segment1Other.SecurityEnabled = True
            Me.RadioButtonAccountCodeFormat_Segment1Other.Size = New System.Drawing.Size(46, 18)
            Me.RadioButtonAccountCodeFormat_Segment1Other.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonAccountCodeFormat_Segment1Other.TabIndex = 15
            Me.RadioButtonAccountCodeFormat_Segment1Other.TabOnEnter = True
            Me.RadioButtonAccountCodeFormat_Segment1Other.TabStop = False
            Me.RadioButtonAccountCodeFormat_Segment1Other.Tag = "4"
            Me.RadioButtonAccountCodeFormat_Segment1Other.Text = "Other"
            '
            'RadioButtonAccountCodeFormat_Segment1Base
            '
            Me.RadioButtonAccountCodeFormat_Segment1Base.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonAccountCodeFormat_Segment1Base.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonAccountCodeFormat_Segment1Base.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonAccountCodeFormat_Segment1Base.Location = New System.Drawing.Point(0, 0)
            Me.RadioButtonAccountCodeFormat_Segment1Base.Name = "RadioButtonAccountCodeFormat_Segment1Base"
            Me.RadioButtonAccountCodeFormat_Segment1Base.SecurityEnabled = True
            Me.RadioButtonAccountCodeFormat_Segment1Base.Size = New System.Drawing.Size(45, 18)
            Me.RadioButtonAccountCodeFormat_Segment1Base.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonAccountCodeFormat_Segment1Base.TabIndex = 0
            Me.RadioButtonAccountCodeFormat_Segment1Base.TabOnEnter = True
            Me.RadioButtonAccountCodeFormat_Segment1Base.TabStop = False
            Me.RadioButtonAccountCodeFormat_Segment1Base.Tag = "1"
            Me.RadioButtonAccountCodeFormat_Segment1Base.Text = "Base"
            '
            'RadioButtonAccountCodeFormat_Segment1Department
            '
            Me.RadioButtonAccountCodeFormat_Segment1Department.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonAccountCodeFormat_Segment1Department.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonAccountCodeFormat_Segment1Department.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonAccountCodeFormat_Segment1Department.Location = New System.Drawing.Point(102, 0)
            Me.RadioButtonAccountCodeFormat_Segment1Department.Name = "RadioButtonAccountCodeFormat_Segment1Department"
            Me.RadioButtonAccountCodeFormat_Segment1Department.SecurityEnabled = True
            Me.RadioButtonAccountCodeFormat_Segment1Department.Size = New System.Drawing.Size(84, 18)
            Me.RadioButtonAccountCodeFormat_Segment1Department.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonAccountCodeFormat_Segment1Department.TabIndex = 14
            Me.RadioButtonAccountCodeFormat_Segment1Department.TabOnEnter = True
            Me.RadioButtonAccountCodeFormat_Segment1Department.TabStop = False
            Me.RadioButtonAccountCodeFormat_Segment1Department.Tag = "3"
            Me.RadioButtonAccountCodeFormat_Segment1Department.Text = "Department"
            '
            'RadioButtonAccountCodeFormat_Segment1Office
            '
            Me.RadioButtonAccountCodeFormat_Segment1Office.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonAccountCodeFormat_Segment1Office.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonAccountCodeFormat_Segment1Office.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonAccountCodeFormat_Segment1Office.Location = New System.Drawing.Point(51, 0)
            Me.RadioButtonAccountCodeFormat_Segment1Office.Name = "RadioButtonAccountCodeFormat_Segment1Office"
            Me.RadioButtonAccountCodeFormat_Segment1Office.SecurityEnabled = True
            Me.RadioButtonAccountCodeFormat_Segment1Office.Size = New System.Drawing.Size(46, 18)
            Me.RadioButtonAccountCodeFormat_Segment1Office.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonAccountCodeFormat_Segment1Office.TabIndex = 13
            Me.RadioButtonAccountCodeFormat_Segment1Office.TabOnEnter = True
            Me.RadioButtonAccountCodeFormat_Segment1Office.TabStop = False
            Me.RadioButtonAccountCodeFormat_Segment1Office.Tag = "2"
            Me.RadioButtonAccountCodeFormat_Segment1Office.Text = "Office"
            '
            'TextBoxAccountCodeFormat_Segment4Description
            '
            Me.TextBoxAccountCodeFormat_Segment4Description.AgencyImportPath = Nothing
            '
            '
            '
            Me.TextBoxAccountCodeFormat_Segment4Description.Border.Class = "TextBoxBorder"
            Me.TextBoxAccountCodeFormat_Segment4Description.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxAccountCodeFormat_Segment4Description.CheckSpellingOnValidate = False
            Me.TextBoxAccountCodeFormat_Segment4Description.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxAccountCodeFormat_Segment4Description.DisplayName = ""
            Me.TextBoxAccountCodeFormat_Segment4Description.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxAccountCodeFormat_Segment4Description.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxAccountCodeFormat_Segment4Description.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxAccountCodeFormat_Segment4Description.FocusHighlightEnabled = True
            Me.TextBoxAccountCodeFormat_Segment4Description.Location = New System.Drawing.Point(394, 101)
            Me.TextBoxAccountCodeFormat_Segment4Description.Margin = New System.Windows.Forms.Padding(2)
            Me.TextBoxAccountCodeFormat_Segment4Description.MaxFileSize = CType(0, Long)
            Me.TextBoxAccountCodeFormat_Segment4Description.Name = "TextBoxAccountCodeFormat_Segment4Description"
            Me.TextBoxAccountCodeFormat_Segment4Description.PreventEnterBeep = True
            Me.TextBoxAccountCodeFormat_Segment4Description.SecurityEnabled = True
            Me.TextBoxAccountCodeFormat_Segment4Description.ShowSpellCheckCompleteMessage = True
            Me.TextBoxAccountCodeFormat_Segment4Description.Size = New System.Drawing.Size(81, 21)
            Me.TextBoxAccountCodeFormat_Segment4Description.StartingFolderName = Nothing
            Me.TextBoxAccountCodeFormat_Segment4Description.TabIndex = 15
            Me.TextBoxAccountCodeFormat_Segment4Description.TabOnEnter = True
            '
            'Panel1AccountCodeFormat_Segment2
            '
            Me.Panel1AccountCodeFormat_Segment2.Appearance.BackColor = System.Drawing.Color.Transparent
            Me.Panel1AccountCodeFormat_Segment2.Appearance.Options.UseBackColor = True
            Me.Panel1AccountCodeFormat_Segment2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.Panel1AccountCodeFormat_Segment2.Controls.Add(Me.RadioButtonAccountCodeFormat_Segment2Base)
            Me.Panel1AccountCodeFormat_Segment2.Controls.Add(Me.RadioButtonAccountCodeFormat_Segment2Other)
            Me.Panel1AccountCodeFormat_Segment2.Controls.Add(Me.RadioButtonAccountCodeFormat_Segment2Department)
            Me.Panel1AccountCodeFormat_Segment2.Controls.Add(Me.RadioButtonAccountCodeFormat_Segment2Office)
            Me.Panel1AccountCodeFormat_Segment2.Location = New System.Drawing.Point(154, 49)
            Me.Panel1AccountCodeFormat_Segment2.LookAndFeel.SkinName = "Office 2013"
            Me.Panel1AccountCodeFormat_Segment2.LookAndFeel.UseDefaultLookAndFeel = False
            Me.Panel1AccountCodeFormat_Segment2.Margin = New System.Windows.Forms.Padding(2)
            Me.Panel1AccountCodeFormat_Segment2.Name = "Panel1AccountCodeFormat_Segment2"
            Me.Panel1AccountCodeFormat_Segment2.Size = New System.Drawing.Size(237, 18)
            Me.Panel1AccountCodeFormat_Segment2.TabIndex = 6
            '
            'RadioButtonAccountCodeFormat_Segment2Base
            '
            Me.RadioButtonAccountCodeFormat_Segment2Base.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonAccountCodeFormat_Segment2Base.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonAccountCodeFormat_Segment2Base.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonAccountCodeFormat_Segment2Base.Location = New System.Drawing.Point(0, 0)
            Me.RadioButtonAccountCodeFormat_Segment2Base.Name = "RadioButtonAccountCodeFormat_Segment2Base"
            Me.RadioButtonAccountCodeFormat_Segment2Base.SecurityEnabled = True
            Me.RadioButtonAccountCodeFormat_Segment2Base.Size = New System.Drawing.Size(45, 18)
            Me.RadioButtonAccountCodeFormat_Segment2Base.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonAccountCodeFormat_Segment2Base.TabIndex = 21
            Me.RadioButtonAccountCodeFormat_Segment2Base.TabOnEnter = True
            Me.RadioButtonAccountCodeFormat_Segment2Base.TabStop = False
            Me.RadioButtonAccountCodeFormat_Segment2Base.Tag = "1"
            Me.RadioButtonAccountCodeFormat_Segment2Base.Text = "Base"
            '
            'RadioButtonAccountCodeFormat_Segment2Other
            '
            Me.RadioButtonAccountCodeFormat_Segment2Other.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonAccountCodeFormat_Segment2Other.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonAccountCodeFormat_Segment2Other.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonAccountCodeFormat_Segment2Other.Location = New System.Drawing.Point(191, 0)
            Me.RadioButtonAccountCodeFormat_Segment2Other.Name = "RadioButtonAccountCodeFormat_Segment2Other"
            Me.RadioButtonAccountCodeFormat_Segment2Other.SecurityEnabled = True
            Me.RadioButtonAccountCodeFormat_Segment2Other.Size = New System.Drawing.Size(46, 18)
            Me.RadioButtonAccountCodeFormat_Segment2Other.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonAccountCodeFormat_Segment2Other.TabIndex = 26
            Me.RadioButtonAccountCodeFormat_Segment2Other.TabOnEnter = True
            Me.RadioButtonAccountCodeFormat_Segment2Other.TabStop = False
            Me.RadioButtonAccountCodeFormat_Segment2Other.Tag = "4"
            Me.RadioButtonAccountCodeFormat_Segment2Other.Text = "Other"
            '
            'RadioButtonAccountCodeFormat_Segment2Department
            '
            Me.RadioButtonAccountCodeFormat_Segment2Department.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonAccountCodeFormat_Segment2Department.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonAccountCodeFormat_Segment2Department.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonAccountCodeFormat_Segment2Department.Location = New System.Drawing.Point(102, 0)
            Me.RadioButtonAccountCodeFormat_Segment2Department.Name = "RadioButtonAccountCodeFormat_Segment2Department"
            Me.RadioButtonAccountCodeFormat_Segment2Department.SecurityEnabled = True
            Me.RadioButtonAccountCodeFormat_Segment2Department.Size = New System.Drawing.Size(84, 18)
            Me.RadioButtonAccountCodeFormat_Segment2Department.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonAccountCodeFormat_Segment2Department.TabIndex = 25
            Me.RadioButtonAccountCodeFormat_Segment2Department.TabOnEnter = True
            Me.RadioButtonAccountCodeFormat_Segment2Department.TabStop = False
            Me.RadioButtonAccountCodeFormat_Segment2Department.Tag = "3"
            Me.RadioButtonAccountCodeFormat_Segment2Department.Text = "Department"
            '
            'RadioButtonAccountCodeFormat_Segment2Office
            '
            Me.RadioButtonAccountCodeFormat_Segment2Office.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonAccountCodeFormat_Segment2Office.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonAccountCodeFormat_Segment2Office.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonAccountCodeFormat_Segment2Office.Location = New System.Drawing.Point(51, 0)
            Me.RadioButtonAccountCodeFormat_Segment2Office.Name = "RadioButtonAccountCodeFormat_Segment2Office"
            Me.RadioButtonAccountCodeFormat_Segment2Office.SecurityEnabled = True
            Me.RadioButtonAccountCodeFormat_Segment2Office.Size = New System.Drawing.Size(46, 18)
            Me.RadioButtonAccountCodeFormat_Segment2Office.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonAccountCodeFormat_Segment2Office.TabIndex = 24
            Me.RadioButtonAccountCodeFormat_Segment2Office.TabOnEnter = True
            Me.RadioButtonAccountCodeFormat_Segment2Office.TabStop = False
            Me.RadioButtonAccountCodeFormat_Segment2Office.Tag = "2"
            Me.RadioButtonAccountCodeFormat_Segment2Office.Text = "Office"
            '
            'TextBoxAccountCodeFormat_Segment4
            '
            Me.TextBoxAccountCodeFormat_Segment4.AgencyImportPath = Nothing
            '
            '
            '
            Me.TextBoxAccountCodeFormat_Segment4.Border.Class = "TextBoxBorder"
            Me.TextBoxAccountCodeFormat_Segment4.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxAccountCodeFormat_Segment4.CheckSpellingOnValidate = False
            Me.TextBoxAccountCodeFormat_Segment4.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxAccountCodeFormat_Segment4.DisplayName = ""
            Me.TextBoxAccountCodeFormat_Segment4.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxAccountCodeFormat_Segment4.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxAccountCodeFormat_Segment4.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxAccountCodeFormat_Segment4.FocusHighlightEnabled = True
            Me.TextBoxAccountCodeFormat_Segment4.Location = New System.Drawing.Point(69, 101)
            Me.TextBoxAccountCodeFormat_Segment4.Margin = New System.Windows.Forms.Padding(2)
            Me.TextBoxAccountCodeFormat_Segment4.MaxFileSize = CType(0, Long)
            Me.TextBoxAccountCodeFormat_Segment4.Name = "TextBoxAccountCodeFormat_Segment4"
            Me.TextBoxAccountCodeFormat_Segment4.PreventEnterBeep = True
            Me.TextBoxAccountCodeFormat_Segment4.SecurityEnabled = True
            Me.TextBoxAccountCodeFormat_Segment4.ShowSpellCheckCompleteMessage = True
            Me.TextBoxAccountCodeFormat_Segment4.Size = New System.Drawing.Size(81, 21)
            Me.TextBoxAccountCodeFormat_Segment4.StartingFolderName = Nothing
            Me.TextBoxAccountCodeFormat_Segment4.TabIndex = 13
            Me.TextBoxAccountCodeFormat_Segment4.TabOnEnter = True
            '
            'LabelAccountCodeFormat_Segment4
            '
            Me.LabelAccountCodeFormat_Segment4.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAccountCodeFormat_Segment4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAccountCodeFormat_Segment4.Location = New System.Drawing.Point(4, 101)
            Me.LabelAccountCodeFormat_Segment4.Margin = New System.Windows.Forms.Padding(2)
            Me.LabelAccountCodeFormat_Segment4.Name = "LabelAccountCodeFormat_Segment4"
            Me.LabelAccountCodeFormat_Segment4.Size = New System.Drawing.Size(61, 18)
            Me.LabelAccountCodeFormat_Segment4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAccountCodeFormat_Segment4.TabIndex = 44
            Me.LabelAccountCodeFormat_Segment4.Text = "Segment 4 -"
            '
            'TextBoxAccountCodeFormat_Segment3Description
            '
            Me.TextBoxAccountCodeFormat_Segment3Description.AgencyImportPath = Nothing
            '
            '
            '
            Me.TextBoxAccountCodeFormat_Segment3Description.Border.Class = "TextBoxBorder"
            Me.TextBoxAccountCodeFormat_Segment3Description.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxAccountCodeFormat_Segment3Description.CheckSpellingOnValidate = False
            Me.TextBoxAccountCodeFormat_Segment3Description.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxAccountCodeFormat_Segment3Description.DisplayName = ""
            Me.TextBoxAccountCodeFormat_Segment3Description.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxAccountCodeFormat_Segment3Description.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxAccountCodeFormat_Segment3Description.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxAccountCodeFormat_Segment3Description.FocusHighlightEnabled = True
            Me.TextBoxAccountCodeFormat_Segment3Description.Location = New System.Drawing.Point(394, 75)
            Me.TextBoxAccountCodeFormat_Segment3Description.Margin = New System.Windows.Forms.Padding(2)
            Me.TextBoxAccountCodeFormat_Segment3Description.MaxFileSize = CType(0, Long)
            Me.TextBoxAccountCodeFormat_Segment3Description.Name = "TextBoxAccountCodeFormat_Segment3Description"
            Me.TextBoxAccountCodeFormat_Segment3Description.PreventEnterBeep = True
            Me.TextBoxAccountCodeFormat_Segment3Description.SecurityEnabled = True
            Me.TextBoxAccountCodeFormat_Segment3Description.ShowSpellCheckCompleteMessage = True
            Me.TextBoxAccountCodeFormat_Segment3Description.Size = New System.Drawing.Size(81, 21)
            Me.TextBoxAccountCodeFormat_Segment3Description.StartingFolderName = Nothing
            Me.TextBoxAccountCodeFormat_Segment3Description.TabIndex = 11
            Me.TextBoxAccountCodeFormat_Segment3Description.TabOnEnter = True
            '
            'TextBoxAccountCodeFormat_Segment3
            '
            Me.TextBoxAccountCodeFormat_Segment3.AgencyImportPath = Nothing
            '
            '
            '
            Me.TextBoxAccountCodeFormat_Segment3.Border.Class = "TextBoxBorder"
            Me.TextBoxAccountCodeFormat_Segment3.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxAccountCodeFormat_Segment3.CheckSpellingOnValidate = False
            Me.TextBoxAccountCodeFormat_Segment3.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxAccountCodeFormat_Segment3.DisplayName = ""
            Me.TextBoxAccountCodeFormat_Segment3.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxAccountCodeFormat_Segment3.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxAccountCodeFormat_Segment3.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxAccountCodeFormat_Segment3.FocusHighlightEnabled = True
            Me.TextBoxAccountCodeFormat_Segment3.Location = New System.Drawing.Point(69, 75)
            Me.TextBoxAccountCodeFormat_Segment3.Margin = New System.Windows.Forms.Padding(2)
            Me.TextBoxAccountCodeFormat_Segment3.MaxFileSize = CType(0, Long)
            Me.TextBoxAccountCodeFormat_Segment3.Name = "TextBoxAccountCodeFormat_Segment3"
            Me.TextBoxAccountCodeFormat_Segment3.PreventEnterBeep = True
            Me.TextBoxAccountCodeFormat_Segment3.SecurityEnabled = True
            Me.TextBoxAccountCodeFormat_Segment3.ShowSpellCheckCompleteMessage = True
            Me.TextBoxAccountCodeFormat_Segment3.Size = New System.Drawing.Size(81, 21)
            Me.TextBoxAccountCodeFormat_Segment3.StartingFolderName = Nothing
            Me.TextBoxAccountCodeFormat_Segment3.TabIndex = 9
            Me.TextBoxAccountCodeFormat_Segment3.TabOnEnter = True
            '
            'LabelAccountCodeFormat_Segment3
            '
            Me.LabelAccountCodeFormat_Segment3.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAccountCodeFormat_Segment3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAccountCodeFormat_Segment3.Location = New System.Drawing.Point(4, 75)
            Me.LabelAccountCodeFormat_Segment3.Margin = New System.Windows.Forms.Padding(2)
            Me.LabelAccountCodeFormat_Segment3.Name = "LabelAccountCodeFormat_Segment3"
            Me.LabelAccountCodeFormat_Segment3.Size = New System.Drawing.Size(61, 18)
            Me.LabelAccountCodeFormat_Segment3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAccountCodeFormat_Segment3.TabIndex = 33
            Me.LabelAccountCodeFormat_Segment3.Text = "Segment 3 -"
            '
            'TextBoxAccountCodeFormat_Segment2Description
            '
            Me.TextBoxAccountCodeFormat_Segment2Description.AgencyImportPath = Nothing
            '
            '
            '
            Me.TextBoxAccountCodeFormat_Segment2Description.Border.Class = "TextBoxBorder"
            Me.TextBoxAccountCodeFormat_Segment2Description.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxAccountCodeFormat_Segment2Description.CheckSpellingOnValidate = False
            Me.TextBoxAccountCodeFormat_Segment2Description.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxAccountCodeFormat_Segment2Description.DisplayName = ""
            Me.TextBoxAccountCodeFormat_Segment2Description.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxAccountCodeFormat_Segment2Description.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxAccountCodeFormat_Segment2Description.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxAccountCodeFormat_Segment2Description.FocusHighlightEnabled = True
            Me.TextBoxAccountCodeFormat_Segment2Description.Location = New System.Drawing.Point(394, 49)
            Me.TextBoxAccountCodeFormat_Segment2Description.Margin = New System.Windows.Forms.Padding(2)
            Me.TextBoxAccountCodeFormat_Segment2Description.MaxFileSize = CType(0, Long)
            Me.TextBoxAccountCodeFormat_Segment2Description.Name = "TextBoxAccountCodeFormat_Segment2Description"
            Me.TextBoxAccountCodeFormat_Segment2Description.PreventEnterBeep = True
            Me.TextBoxAccountCodeFormat_Segment2Description.SecurityEnabled = True
            Me.TextBoxAccountCodeFormat_Segment2Description.ShowSpellCheckCompleteMessage = True
            Me.TextBoxAccountCodeFormat_Segment2Description.Size = New System.Drawing.Size(81, 21)
            Me.TextBoxAccountCodeFormat_Segment2Description.StartingFolderName = Nothing
            Me.TextBoxAccountCodeFormat_Segment2Description.TabIndex = 7
            Me.TextBoxAccountCodeFormat_Segment2Description.TabOnEnter = True
            '
            'TextBoxAccountCodeFormat_Segment2
            '
            Me.TextBoxAccountCodeFormat_Segment2.AgencyImportPath = Nothing
            '
            '
            '
            Me.TextBoxAccountCodeFormat_Segment2.Border.Class = "TextBoxBorder"
            Me.TextBoxAccountCodeFormat_Segment2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxAccountCodeFormat_Segment2.CheckSpellingOnValidate = False
            Me.TextBoxAccountCodeFormat_Segment2.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxAccountCodeFormat_Segment2.DisplayName = ""
            Me.TextBoxAccountCodeFormat_Segment2.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxAccountCodeFormat_Segment2.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxAccountCodeFormat_Segment2.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxAccountCodeFormat_Segment2.FocusHighlightEnabled = True
            Me.TextBoxAccountCodeFormat_Segment2.Location = New System.Drawing.Point(69, 49)
            Me.TextBoxAccountCodeFormat_Segment2.Margin = New System.Windows.Forms.Padding(2)
            Me.TextBoxAccountCodeFormat_Segment2.MaxFileSize = CType(0, Long)
            Me.TextBoxAccountCodeFormat_Segment2.Name = "TextBoxAccountCodeFormat_Segment2"
            Me.TextBoxAccountCodeFormat_Segment2.PreventEnterBeep = True
            Me.TextBoxAccountCodeFormat_Segment2.SecurityEnabled = True
            Me.TextBoxAccountCodeFormat_Segment2.ShowSpellCheckCompleteMessage = True
            Me.TextBoxAccountCodeFormat_Segment2.Size = New System.Drawing.Size(81, 21)
            Me.TextBoxAccountCodeFormat_Segment2.StartingFolderName = Nothing
            Me.TextBoxAccountCodeFormat_Segment2.TabIndex = 5
            Me.TextBoxAccountCodeFormat_Segment2.TabOnEnter = True
            '
            'LabelAccountCodeFormat_Segment2
            '
            Me.LabelAccountCodeFormat_Segment2.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAccountCodeFormat_Segment2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAccountCodeFormat_Segment2.Location = New System.Drawing.Point(4, 49)
            Me.LabelAccountCodeFormat_Segment2.Margin = New System.Windows.Forms.Padding(2)
            Me.LabelAccountCodeFormat_Segment2.Name = "LabelAccountCodeFormat_Segment2"
            Me.LabelAccountCodeFormat_Segment2.Size = New System.Drawing.Size(61, 18)
            Me.LabelAccountCodeFormat_Segment2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAccountCodeFormat_Segment2.TabIndex = 22
            Me.LabelAccountCodeFormat_Segment2.Text = "Segment 2 -"
            '
            'TextBoxAccountCodeFormat_Segment1Description
            '
            Me.TextBoxAccountCodeFormat_Segment1Description.AgencyImportPath = Nothing
            '
            '
            '
            Me.TextBoxAccountCodeFormat_Segment1Description.Border.Class = "TextBoxBorder"
            Me.TextBoxAccountCodeFormat_Segment1Description.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxAccountCodeFormat_Segment1Description.CheckSpellingOnValidate = False
            Me.TextBoxAccountCodeFormat_Segment1Description.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxAccountCodeFormat_Segment1Description.DisplayName = ""
            Me.TextBoxAccountCodeFormat_Segment1Description.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxAccountCodeFormat_Segment1Description.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxAccountCodeFormat_Segment1Description.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxAccountCodeFormat_Segment1Description.FocusHighlightEnabled = True
            Me.TextBoxAccountCodeFormat_Segment1Description.Location = New System.Drawing.Point(394, 23)
            Me.TextBoxAccountCodeFormat_Segment1Description.Margin = New System.Windows.Forms.Padding(2)
            Me.TextBoxAccountCodeFormat_Segment1Description.MaxFileSize = CType(0, Long)
            Me.TextBoxAccountCodeFormat_Segment1Description.Name = "TextBoxAccountCodeFormat_Segment1Description"
            Me.TextBoxAccountCodeFormat_Segment1Description.PreventEnterBeep = True
            Me.TextBoxAccountCodeFormat_Segment1Description.SecurityEnabled = True
            Me.TextBoxAccountCodeFormat_Segment1Description.ShowSpellCheckCompleteMessage = True
            Me.TextBoxAccountCodeFormat_Segment1Description.Size = New System.Drawing.Size(81, 21)
            Me.TextBoxAccountCodeFormat_Segment1Description.StartingFolderName = Nothing
            Me.TextBoxAccountCodeFormat_Segment1Description.TabIndex = 3
            Me.TextBoxAccountCodeFormat_Segment1Description.TabOnEnter = True
            '
            'TextBoxAccountCodeFormat_Segment1
            '
            Me.TextBoxAccountCodeFormat_Segment1.AgencyImportPath = Nothing
            '
            '
            '
            Me.TextBoxAccountCodeFormat_Segment1.Border.Class = "TextBoxBorder"
            Me.TextBoxAccountCodeFormat_Segment1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxAccountCodeFormat_Segment1.CheckSpellingOnValidate = False
            Me.TextBoxAccountCodeFormat_Segment1.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxAccountCodeFormat_Segment1.DisplayName = ""
            Me.TextBoxAccountCodeFormat_Segment1.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxAccountCodeFormat_Segment1.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxAccountCodeFormat_Segment1.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxAccountCodeFormat_Segment1.FocusHighlightEnabled = True
            Me.TextBoxAccountCodeFormat_Segment1.Location = New System.Drawing.Point(69, 23)
            Me.TextBoxAccountCodeFormat_Segment1.Margin = New System.Windows.Forms.Padding(2)
            Me.TextBoxAccountCodeFormat_Segment1.MaxFileSize = CType(0, Long)
            Me.TextBoxAccountCodeFormat_Segment1.Name = "TextBoxAccountCodeFormat_Segment1"
            Me.TextBoxAccountCodeFormat_Segment1.PreventEnterBeep = True
            Me.TextBoxAccountCodeFormat_Segment1.SecurityEnabled = True
            Me.TextBoxAccountCodeFormat_Segment1.ShowSpellCheckCompleteMessage = True
            Me.TextBoxAccountCodeFormat_Segment1.Size = New System.Drawing.Size(81, 21)
            Me.TextBoxAccountCodeFormat_Segment1.StartingFolderName = Nothing
            Me.TextBoxAccountCodeFormat_Segment1.TabIndex = 1
            Me.TextBoxAccountCodeFormat_Segment1.TabOnEnter = True
            '
            'LabelAccountCodeFormat_Segment1
            '
            Me.LabelAccountCodeFormat_Segment1.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAccountCodeFormat_Segment1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAccountCodeFormat_Segment1.Location = New System.Drawing.Point(4, 23)
            Me.LabelAccountCodeFormat_Segment1.Margin = New System.Windows.Forms.Padding(2)
            Me.LabelAccountCodeFormat_Segment1.Name = "LabelAccountCodeFormat_Segment1"
            Me.LabelAccountCodeFormat_Segment1.Size = New System.Drawing.Size(61, 18)
            Me.LabelAccountCodeFormat_Segment1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAccountCodeFormat_Segment1.TabIndex = 8
            Me.LabelAccountCodeFormat_Segment1.Text = "Segment 1 -"
            '
            'TabItemTabs_Defaults
            '
            Me.TabItemTabs_Defaults.AttachedControl = Me.TabControlPanelVendors_Vendors
            Me.TabItemTabs_Defaults.Name = "TabItemTabs_Defaults"
            Me.TabItemTabs_Defaults.Text = "Defaults"
            '
            'ConfigurationSetupForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(844, 450)
            Me.Controls.Add(Me.TabControlPanel_Tabs)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
            Me.Name = "ConfigurationSetupForm"
            Me.Text = "GL Configuration"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            CType(Me.TabControlPanel_Tabs, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanel_Tabs.ResumeLayout(False)
            Me.TabControlPanelStatus_Status.ResumeLayout(False)
            CType(Me.GroupBoxOptions_BudgetMaintenance, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxOptions_BudgetMaintenance.ResumeLayout(False)
            CType(Me.GroupBoxOptions_LastYearsActualAmounts, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxOptions_LastYearsActualAmounts.ResumeLayout(False)
            CType(Me.PanelVarianceToLastYear_Columns, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelVarianceToLastYear_Columns.ResumeLayout(False)
            CType(Me.PanelLastYearsActualAmounts_Columns, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelLastYearsActualAmounts_Columns.ResumeLayout(False)
            CType(Me.GroupBoxOptions_CurrentBudget, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxOptions_CurrentBudget.ResumeLayout(False)
            CType(Me.PanelVarianceToCurrentBudget_Columns, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelVarianceToCurrentBudget_Columns.ResumeLayout(False)
            CType(Me.PanelCompareUsingCurrentBudget_Columns, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelCompareUsingCurrentBudget_Columns.ResumeLayout(False)
            CType(Me.GroupBoxOptions_ClientBudget, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxOptions_ClientBudget.ResumeLayout(False)
            CType(Me.PanelClientBudget_Columns, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelClientBudget_Columns.ResumeLayout(False)
            CType(Me.GroupBoxOptions_YTDActualAmounts, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxOptions_YTDActualAmounts.ResumeLayout(False)
            CType(Me.PanelYTDActualAmounts_Columns, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelYTDActualAmounts_Columns.ResumeLayout(False)
            CType(Me.GroupBoxOptions_AccountsToBudget, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxOptions_AccountsToBudget.ResumeLayout(False)
            Me.TabControlPanelVendors_Vendors.ResumeLayout(False)
            CType(Me.GroupBoxDefaults_CurrencyFormat, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxDefaults_CurrencyFormat.ResumeLayout(False)
            CType(Me.GroupBoxDefaults_PostingPeriodFormat, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxDefaults_PostingPeriodFormat.ResumeLayout(False)
            CType(Me.GroupBoxDefaults_FiscalYearOptions, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxDefaults_FiscalYearOptions.ResumeLayout(False)
            CType(Me.GroupBoxDefaults_AccountCodeFormat, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxDefaults_AccountCodeFormat.ResumeLayout(False)
            CType(Me.Panel2AccountCodeFormat_Segment3, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel2AccountCodeFormat_Segment3.ResumeLayout(False)
            CType(Me.Panel2AccountCodeFormat_Segment2, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel2AccountCodeFormat_Segment2.ResumeLayout(False)
            CType(Me.Panel1AccountCodeFormat_Segment3, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel1AccountCodeFormat_Segment3.ResumeLayout(False)
            CType(Me.Panel2AccountCodeFormat_Segment1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel2AccountCodeFormat_Segment1.ResumeLayout(False)
            CType(Me.Panel1AccountCodeFormat_Segment4, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel1AccountCodeFormat_Segment4.ResumeLayout(False)
            CType(Me.Panel1AccountCodeFormat_Segment1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel1AccountCodeFormat_Segment1.ResumeLayout(False)
            CType(Me.Panel1AccountCodeFormat_Segment2, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel1AccountCodeFormat_Segment2.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Save As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Cancel As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents TabControlPanel_Tabs As WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelVendors_Vendors As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemTabs_Defaults As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelStatus_Status As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemTabs_Options As DevComponents.DotNetBar.TabItem
        Friend WithEvents LabelDefaults_FiscalYearStartMonth As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelDefaults_DefaultFormat As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents GroupBoxDefaults_CurrencyFormat As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents TextBoxCurrencyFormat_CurrencySymbol As WinForm.MVC.Presentation.Controls.TextBox
        Friend WithEvents LabelCurrencyFormat_CurrencySymbol As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents GroupBoxDefaults_PostingPeriodFormat As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents RadioButtonPostingPeriodFormat_Option2 As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonPostingPeriodFormat_Option1 As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents GroupBoxDefaults_FiscalYearOptions As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents RadioButtonFiscalYearOptions_BeginsInCurrent As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonFiscalYearOptions_BeginsInPrevious As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents GroupBoxDefaults_AccountCodeFormat As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents Panel2AccountCodeFormat_Segment3 As WinForm.Presentation.Controls.Panel
        Friend WithEvents CheckBoxAccountCodeFormat_Segment3Hyphen As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxAccountCodeFormat_Segment3Period As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents LabelAccountCodeFormat_Segment3Or As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelAccountCodeFormat_Segment3After As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents Panel2AccountCodeFormat_Segment2 As WinForm.Presentation.Controls.Panel
        Friend WithEvents CheckBoxAccountCodeFormat_Segment2Hyphen As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxAccountCodeFormat_Segment2Period As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents LabelAccountCodeFormat_Segment2Or As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelAccountCodeFormat_Segment2After As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents Panel1AccountCodeFormat_Segment3 As WinForm.Presentation.Controls.Panel
        Friend WithEvents RadioButtonAccountCodeFormat_Segment3Base As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonAccountCodeFormat_Segment3Other As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonAccountCodeFormat_Segment3Office As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonAccountCodeFormat_Segment3Department As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents Panel2AccountCodeFormat_Segment1 As WinForm.Presentation.Controls.Panel
        Friend WithEvents CheckBoxAccountCodeFormat_Segment1Hyphen As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxAccountCodeFormat_Segment1Period As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents LabelAccountCodeFormat_Segment1Or As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelAccountCodeFormat_Segment1After As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents Panel1AccountCodeFormat_Segment4 As WinForm.Presentation.Controls.Panel
        Friend WithEvents RadioButtonAccountCodeFormat_Segment4Base As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonAccountCodeFormat_Segment4Office As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonAccountCodeFormat_Segment4Department As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonAccountCodeFormat_Segment4Other As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents Panel1AccountCodeFormat_Segment1 As WinForm.Presentation.Controls.Panel
        Friend WithEvents RadioButtonAccountCodeFormat_Segment1Other As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonAccountCodeFormat_Segment1Base As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonAccountCodeFormat_Segment1Department As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonAccountCodeFormat_Segment1Office As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents TextBoxAccountCodeFormat_Segment4Description As WinForm.MVC.Presentation.Controls.TextBox
        Friend WithEvents Panel1AccountCodeFormat_Segment2 As WinForm.Presentation.Controls.Panel
        Friend WithEvents RadioButtonAccountCodeFormat_Segment2Base As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonAccountCodeFormat_Segment2Other As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonAccountCodeFormat_Segment2Department As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonAccountCodeFormat_Segment2Office As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents TextBoxAccountCodeFormat_Segment4 As WinForm.MVC.Presentation.Controls.TextBox
        Friend WithEvents LabelAccountCodeFormat_Segment4 As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents TextBoxAccountCodeFormat_Segment3Description As WinForm.MVC.Presentation.Controls.TextBox
        Friend WithEvents TextBoxAccountCodeFormat_Segment3 As WinForm.MVC.Presentation.Controls.TextBox
        Friend WithEvents LabelAccountCodeFormat_Segment3 As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents TextBoxAccountCodeFormat_Segment2Description As WinForm.MVC.Presentation.Controls.TextBox
        Friend WithEvents TextBoxAccountCodeFormat_Segment2 As WinForm.MVC.Presentation.Controls.TextBox
        Friend WithEvents LabelAccountCodeFormat_Segment2 As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents TextBoxAccountCodeFormat_Segment1Description As WinForm.MVC.Presentation.Controls.TextBox
        Friend WithEvents TextBoxAccountCodeFormat_Segment1 As WinForm.MVC.Presentation.Controls.TextBox
        Friend WithEvents LabelAccountCodeFormat_Segment1 As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelPostingPeriodFormat_Option2 As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelPostingPeriodFormat_Option1 As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents GroupBoxOptions_ClientBudget As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents GroupBoxOptions_CurrentBudget As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents GroupBoxOptions_YTDActualAmounts As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents GroupBoxOptions_LastYearsActualAmounts As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents LabelCurrentBudget_VarianceToCurrentBudget As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelCurrentBudget_CompareUsingCurrentBudget As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents PanelLastYearsActualAmounts_Columns As WinForm.Presentation.Controls.Panel
        Friend WithEvents RadioButtonLastYearsActualAmounts_Column6 As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonLastYearsActualAmounts_Column3 As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonLastYearsActualAmounts_Column5 As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonLastYearsActualAmounts_Exclude As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonLastYearsActualAmounts_Column4 As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonLastYearsActualAmounts_Column2 As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonLastYearsActualAmounts_Column1 As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents LabelBudgetMaintenance_VarianceToLastYear As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents PanelClientBudget_Columns As WinForm.Presentation.Controls.Panel
        Friend WithEvents RadioButtonClientBudget_Column6 As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonClientBudget_Column3 As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonClientBudget_Column5 As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonClientBudget_Exclude As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonClientBudget_Column4 As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonClientBudget_Column2 As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonClientBudget_Column1 As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents PanelVarianceToCurrentBudget_Columns As WinForm.Presentation.Controls.Panel
        Friend WithEvents RadioButtonVarianceToCurrentBudget_Column6 As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonVarianceToCurrentBudget_Column3 As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonVarianceToCurrentBudget_Column5 As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonVarianceToCurrentBudget_Exclude As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonVarianceToCurrentBudget_Column4 As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonVarianceToCurrentBudget_Column2 As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonVarianceToCurrentBudget_Column1 As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents PanelCompareUsingCurrentBudget_Columns As WinForm.Presentation.Controls.Panel
        Friend WithEvents RadioButtonCompareUsingCurrentBudget_Column6 As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonCompareUsingCurrentBudget_Column3 As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonCompareUsingCurrentBudget_Column5 As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonCompareUsingCurrentBudget_Column4 As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonCompareUsingCurrentBudget_Column2 As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonCompareUsingCurrentBudget_Column1 As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents PanelYTDActualAmounts_Columns As WinForm.Presentation.Controls.Panel
        Friend WithEvents RadioButtonYTDActualAmounts_Column6 As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonYTDActualAmounts_Column3 As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonYTDActualAmounts_Column5 As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonYTDActualAmounts_Exclude As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonYTDActualAmounts_Column4 As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonYTDActualAmounts_Column2 As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonYTDActualAmounts_Column1 As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents PanelVarianceToLastYear_Columns As WinForm.Presentation.Controls.Panel
        Friend WithEvents RadioButtonVarianceToLastYear_Column6 As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonVarianceToLastYear_Column3 As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonVarianceToLastYear_Column5 As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonVarianceToLastYear_Exclude As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonVarianceToLastYear_Column4 As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonVarianceToLastYear_Column2 As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonVarianceToLastYear_Column1 As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents CheckBoxVarianceToLastYear_IncludeYearEndEntries As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents GroupBoxOptions_AccountsToBudget As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents CheckBoxAccountsToBudget_IncomeOther As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxAccountsToBudget_Income As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxAccountsToBudget_NonCurrentLiabilities As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxAccountsToBudget_CurrentLiabilities As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxAccountsToBudget_FixedAssets As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxAccountsToBudget_NonCurrentAssets As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxAccountsToBudget_CurrentAssets As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxAccountsToBudget_ExpenseCOS As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxAccountsToBudget_ExpenseOperating As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxAccountsToBudget_ExpenseOther As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxAccountsToBudget_ExpenseTaxes As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents RadioButtonCompareUsingCurrentBudget_Exclude As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents TextBoxDefaults_DefaultFormat As Windows.Forms.Label
        Friend WithEvents RibbonBarOptions_SegmentTypes As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemSegmentTypes_Edit As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ComboBoxDefaults_FiscalYearStartMonth As WinForm.MVC.Presentation.Controls.ComboBox
        Friend WithEvents GroupBoxOptions_BudgetMaintenance As WinForm.Presentation.Controls.GroupBox
    End Class

End Namespace

