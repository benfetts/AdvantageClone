Namespace Billing.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class BillingCommandCenterJobDetailDialog
        Inherits WinForm.Presentation.BaseForms.BaseRibbonForm

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BillingCommandCenterJobDetailDialog))
            Me.RibbonBarOptions_AdvanceBilling = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemAdvanceBilling_Create = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemAdvanceBilling_CreateAll = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemAdvanceBilling_CreateSelected = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemAdvanceBilling_CreateActuals = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemAdvanceBilling_CreateActualsOpenPO = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemAdvanceBilling_CreateApproved = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemAdvanceBilling_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemAdvanceBilling_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Refresh = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Documents = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemDocuments_Download = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDocuments_OpenURL = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Vendor = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemVendor_MarkupDown = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemVendorMarkupDown_Markdown100 = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemVendorMarkupDown_SetPercent = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemVendor_WriteOff = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemVendor_BillHold = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemVendorBillHold_Temporary = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemVendorBillHold_Permanent = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemVendorBillHold_RemoveAll = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemVendor_Transfer = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemVendor_HideNonBillable = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemVendor_ChooseColumns = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemVendor_RestoreDefaults = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_IncomeOnly = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemIncomeOnly_UpdateRate = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemIOUpdateRate_FromHierarchy = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemIOUpdateRate_SetRate = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemIncomeOnly_BillHold = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemIOBillHold_Temporary = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemIOBillHold_Permanent = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemIOBillHold_RemoveAll = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemIncomeOnly_Transfer = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemIncomeOnly_HideNonBillable = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemIncomeOnly_ChooseColumns = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemIncomeOnly_RestoreDefaults = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_EmployeeTime = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemEmployeeTime_MarkBillable = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemEmployeeTime_MarkNonBillable = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemEmployeeTime_FeeTime = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemFeeTime_No = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemFeeTime_TimeAgainstFee = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemFeeTime_TimeAgainstCommissionP = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemFeeTime_TimeAgainstCommissionM = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemEmployeeTime_UpdateRate = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemETUpdateRate_FromHierarchy = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemETUpdateRate_SetRate = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemEmployeeTime_MarkupDown = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemETMarkupDown_Markdown100 = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemETMarkupDown_SetPercent = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemETMarkupDown_ToEstimateAmountForFunction = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemETMarkupDown_ToBilledAmountForFunction = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemETMarkupDown_ToApprovedAmountForFunction = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemETMarkupDown_ToApprovedAmountForItem = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemEmployeeTime_BillHold = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemETBillHold_Temporary = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemETBillHold_Permanent = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemETBillHold_RemoveAll = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemEmployeeTime_Transfer = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemEmployeeTime_HideNonBillable = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemEmployeeTime_ChooseColumns = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemEmployeeTime_RestoreDefaults = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Include = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemInclude_Contingency = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_FunctionGrid = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemFunctionGrid_ChooseColumns = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemFunctionGrid_RestoreDefaults = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemFunctionGrid_SelectAll = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.PanelForm_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewLeftSection_Jobs = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ExpandableSplitterControlForm_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelForm_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.PanelRightSection_Bottom = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.TabControlRightSection_FunctionItems = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelEmployeeTimeTab_EmployeeTime = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewEmployeeTime_Details = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemFunctionItems_EmployeeTime = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelOpenPOTab_OpenPO = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewOpenPO_Details = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemFunctionItems_OpenPO = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelAdvanceBillingTab_AdvanceBilling = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewAdvanceBilling_Details = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemFunctionItems_AdvanceBilling = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelDocumentsTab_Documents = New DevComponents.DotNetBar.TabControlPanel()
            Me.DocumentManagerControlDocuments_Documents = New AdvantageFramework.WinForm.Presentation.Controls.DocumentManagerControl()
            Me.TabItemFunctionItems_Documents = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelVendorTab_Vendor = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewVendor_Details = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemFunctionItems_Vendor = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelIncomeOnlyTab_IncomeOnly = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewIncomeOnly_Details = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemFunctionItems_IncomeOnly = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.ExpandableSplitterControlRightSection_TopBottom = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelRightSection_Top = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewTop_JobComponentFunctions = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.NumericInputControl_PercentOfQuote = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.RibbonBarOptions_IncomeMethod = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ItemContainerIncomeMethod_Vertical = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemIncomeMethod_UponReconciliation = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemIncomeMethod_InitialBilling = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_BillMethod = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ItemContainerBillMethod_Vertical = New DevComponents.DotNetBar.ItemContainer()
            Me.ItemContainerBillMethod_HorizontalTop = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemBillMethod_PercentOfQuote = New DevComponents.DotNetBar.LabelItem()
            Me.ControlContainerItemBillMethod_PctQuote = New DevComponents.DotNetBar.ControlContainerItem()
            Me.CheckBoxItemBillMethod_ExcludeNonBillableFunctions = New DevComponents.DotNetBar.CheckBoxItem()
            Me.LabelItemBillMethod_AdvanceRequested = New DevComponents.DotNetBar.LabelItem()
            Me.LabelItemABVertical_MethodDescription = New DevComponents.DotNetBar.LabelItem()
            Me.RibbonBarOptions_PercentOfQuoteBilled = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.LabelItemPctOfQuoteBilled_PCT = New DevComponents.DotNetBar.LabelItem()
            Me.RibbonBarOptions_Status = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemStatus_Adjusted = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_ReconcileFunctions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ItemContainerVertical_ReconcileFunctions = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemReconcileFunctions_CheckSelected = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemReconcileFunctions_UncheckSelected = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_ReconcileEmployeeTime = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ItemContainerVertical_ReconcileEmployeeTime = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemReconcileEmployeeTime_CheckSelected = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemReconcileEmployeeTime_UncheckSelected = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_ReconcileIncomeOnly = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ItemContainerVertical_ReconcileIncomeOnly = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemReconcileIncomeOnly_CheckSelected = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemReconcileIncomeOnly_UncheckSelected = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_ReconcileVendor = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ItemContainerVertical_ReconcileVendor = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemReconcileVendor_CheckSelected = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemReconcileVendor_UncheckSelected = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_IncomeRecognition = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemIncomeRecognition_Create = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemIncomeRecognition_CreateByPercentCompleteTime = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemPercentCompleteTime_ByJob = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemPercentCompleteTime_ByJobFunction = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemIncomeRecognition_CreateByPercentCompleteAll = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemPercentCompleteAll_ByJob = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemPercentCompleteAll_ByJobFunction = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_OpenPO = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemOpenPO_ChooseColumns = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemOpenPO_RestoreDefaults = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Form.SuspendLayout()
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_LeftSection.SuspendLayout()
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_RightSection.SuspendLayout()
            CType(Me.PanelRightSection_Bottom, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelRightSection_Bottom.SuspendLayout()
            CType(Me.TabControlRightSection_FunctionItems, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlRightSection_FunctionItems.SuspendLayout()
            Me.TabControlPanelEmployeeTimeTab_EmployeeTime.SuspendLayout()
            Me.TabControlPanelOpenPOTab_OpenPO.SuspendLayout()
            Me.TabControlPanelAdvanceBillingTab_AdvanceBilling.SuspendLayout()
            Me.TabControlPanelDocumentsTab_Documents.SuspendLayout()
            Me.TabControlPanelVendorTab_Vendor.SuspendLayout()
            Me.TabControlPanelIncomeOnlyTab_IncomeOnly.SuspendLayout()
            CType(Me.PanelRightSection_Top, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelRightSection_Top.SuspendLayout()
            CType(Me.NumericInputControl_PercentOfQuote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.RibbonBarOptions_BillMethod.SuspendLayout()
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
            Me.PanelForm_Form.Controls.Add(Me.PanelForm_RightSection)
            Me.PanelForm_Form.Controls.Add(Me.ExpandableSplitterControlForm_LeftRight)
            Me.PanelForm_Form.Controls.Add(Me.PanelForm_LeftSection)
            Me.PanelForm_Form.LookAndFeel.SkinName = "Office 2013"
            Me.PanelForm_Form.LookAndFeel.UseDefaultLookAndFeel = False
            Me.PanelForm_Form.Size = New System.Drawing.Size(1169, 555)
            '
            'RibbonControlForm_MainRibbon
            '
            '
            '
            '
            Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(1169, 154)
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
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_OpenPO)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_ReconcileVendor)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_ReconcileIncomeOnly)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_ReconcileEmployeeTime)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_ReconcileFunctions)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_IncomeRecognition)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_AdvanceBilling)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_PercentOfQuoteBilled)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_BillMethod)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_IncomeMethod)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Documents)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Vendor)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_IncomeOnly)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_EmployeeTime)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_FunctionGrid)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Include)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Status)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 57)
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(1169, 94)
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
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarFilePanel_System, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Actions, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Status, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Include, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_FunctionGrid, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_EmployeeTime, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_IncomeOnly, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Vendor, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Documents, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_IncomeMethod, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_BillMethod, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_PercentOfQuoteBilled, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_AdvanceBilling, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_IncomeRecognition, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_ReconcileFunctions, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_ReconcileEmployeeTime, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_ReconcileIncomeOnly, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_ReconcileVendor, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_OpenPO, 0)
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
            Me.RibbonBarFilePanel_System.Size = New System.Drawing.Size(52, 92)
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
            Me.Office2007StartButtonMainRibbon_Home.ImagePaddingVertical = 0
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
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 710)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(1169, 18)
            '
            'RibbonBarOptions_AdvanceBilling
            '
            Me.RibbonBarOptions_AdvanceBilling.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_AdvanceBilling.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_AdvanceBilling.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_AdvanceBilling.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_AdvanceBilling.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_AdvanceBilling.DragDropSupport = True
            Me.RibbonBarOptions_AdvanceBilling.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemAdvanceBilling_Create, Me.ButtonItemAdvanceBilling_Delete, Me.ButtonItemAdvanceBilling_Cancel})
            Me.RibbonBarOptions_AdvanceBilling.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_AdvanceBilling.Location = New System.Drawing.Point(1365, 0)
            Me.RibbonBarOptions_AdvanceBilling.Name = "RibbonBarOptions_AdvanceBilling"
            Me.RibbonBarOptions_AdvanceBilling.SecurityEnabled = True
            Me.RibbonBarOptions_AdvanceBilling.Size = New System.Drawing.Size(90, 92)
            Me.RibbonBarOptions_AdvanceBilling.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_AdvanceBilling.TabIndex = 12
            Me.RibbonBarOptions_AdvanceBilling.Text = "Advance Billing"
            '
            '
            '
            Me.RibbonBarOptions_AdvanceBilling.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_AdvanceBilling.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_AdvanceBilling.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemAdvanceBilling_Create
            '
            Me.ButtonItemAdvanceBilling_Create.AutoExpandOnClick = True
            Me.ButtonItemAdvanceBilling_Create.BeginGroup = True
            Me.ButtonItemAdvanceBilling_Create.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemAdvanceBilling_Create.Name = "ButtonItemAdvanceBilling_Create"
            Me.ButtonItemAdvanceBilling_Create.RibbonWordWrap = False
            Me.ButtonItemAdvanceBilling_Create.SecurityEnabled = True
            Me.ButtonItemAdvanceBilling_Create.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemAdvanceBilling_CreateAll, Me.ButtonItemAdvanceBilling_CreateSelected, Me.ButtonItemAdvanceBilling_CreateActuals, Me.ButtonItemAdvanceBilling_CreateActualsOpenPO, Me.ButtonItemAdvanceBilling_CreateApproved})
            Me.ButtonItemAdvanceBilling_Create.SubItemsExpandWidth = 14
            Me.ButtonItemAdvanceBilling_Create.Text = "Create"
            '
            'ButtonItemAdvanceBilling_CreateAll
            '
            Me.ButtonItemAdvanceBilling_CreateAll.Name = "ButtonItemAdvanceBilling_CreateAll"
            Me.ButtonItemAdvanceBilling_CreateAll.Text = "All Functions"
            '
            'ButtonItemAdvanceBilling_CreateSelected
            '
            Me.ButtonItemAdvanceBilling_CreateSelected.Name = "ButtonItemAdvanceBilling_CreateSelected"
            Me.ButtonItemAdvanceBilling_CreateSelected.Text = "Selected Functions"
            '
            'ButtonItemAdvanceBilling_CreateActuals
            '
            Me.ButtonItemAdvanceBilling_CreateActuals.Name = "ButtonItemAdvanceBilling_CreateActuals"
            Me.ButtonItemAdvanceBilling_CreateActuals.Text = "Functions with Actuals"
            '
            'ButtonItemAdvanceBilling_CreateActualsOpenPO
            '
            Me.ButtonItemAdvanceBilling_CreateActualsOpenPO.Name = "ButtonItemAdvanceBilling_CreateActualsOpenPO"
            Me.ButtonItemAdvanceBilling_CreateActualsOpenPO.Text = "Functions with Actuals/Open PO"
            '
            'ButtonItemAdvanceBilling_CreateApproved
            '
            Me.ButtonItemAdvanceBilling_CreateApproved.Name = "ButtonItemAdvanceBilling_CreateApproved"
            Me.ButtonItemAdvanceBilling_CreateApproved.Text = "Approved Functions"
            '
            'ButtonItemAdvanceBilling_Delete
            '
            Me.ButtonItemAdvanceBilling_Delete.BeginGroup = True
            Me.ButtonItemAdvanceBilling_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemAdvanceBilling_Delete.Name = "ButtonItemAdvanceBilling_Delete"
            Me.ButtonItemAdvanceBilling_Delete.RibbonWordWrap = False
            Me.ButtonItemAdvanceBilling_Delete.SecurityEnabled = True
            Me.ButtonItemAdvanceBilling_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemAdvanceBilling_Delete.Text = "Delete"
            '
            'ButtonItemAdvanceBilling_Cancel
            '
            Me.ButtonItemAdvanceBilling_Cancel.BeginGroup = True
            Me.ButtonItemAdvanceBilling_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemAdvanceBilling_Cancel.Name = "ButtonItemAdvanceBilling_Cancel"
            Me.ButtonItemAdvanceBilling_Cancel.RibbonWordWrap = False
            Me.ButtonItemAdvanceBilling_Cancel.SecurityEnabled = True
            Me.ButtonItemAdvanceBilling_Cancel.SubItemsExpandWidth = 14
            Me.ButtonItemAdvanceBilling_Cancel.Text = "Cancel"
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Save, Me.ButtonItemActions_Cancel, Me.ButtonItemActions_Refresh})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(55, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(147, 92)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 1
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
            'ButtonItemActions_Save
            '
            Me.ButtonItemActions_Save.BeginGroup = True
            Me.ButtonItemActions_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Save.Name = "ButtonItemActions_Save"
            Me.ButtonItemActions_Save.RibbonWordWrap = False
            Me.ButtonItemActions_Save.SecurityEnabled = True
            Me.ButtonItemActions_Save.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Save.Text = "Save"
            '
            'ButtonItemActions_Cancel
            '
            Me.ButtonItemActions_Cancel.BeginGroup = True
            Me.ButtonItemActions_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Cancel.Name = "ButtonItemActions_Cancel"
            Me.ButtonItemActions_Cancel.RibbonWordWrap = False
            Me.ButtonItemActions_Cancel.SecurityEnabled = True
            Me.ButtonItemActions_Cancel.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Cancel.Text = "Cancel"
            '
            'ButtonItemActions_Refresh
            '
            Me.ButtonItemActions_Refresh.BeginGroup = True
            Me.ButtonItemActions_Refresh.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Refresh.Name = "ButtonItemActions_Refresh"
            Me.ButtonItemActions_Refresh.RibbonWordWrap = False
            Me.ButtonItemActions_Refresh.SecurityEnabled = True
            Me.ButtonItemActions_Refresh.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Refresh.Text = "Refresh"
            '
            'RibbonBarOptions_Documents
            '
            Me.RibbonBarOptions_Documents.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Documents.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Documents.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Documents.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Documents.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Documents.DragDropSupport = True
            Me.RibbonBarOptions_Documents.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemDocuments_Download, Me.ButtonItemDocuments_OpenURL})
            Me.RibbonBarOptions_Documents.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Documents.Location = New System.Drawing.Point(850, 0)
            Me.RibbonBarOptions_Documents.Name = "RibbonBarOptions_Documents"
            Me.RibbonBarOptions_Documents.SecurityEnabled = True
            Me.RibbonBarOptions_Documents.Size = New System.Drawing.Size(80, 92)
            Me.RibbonBarOptions_Documents.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Documents.TabIndex = 8
            Me.RibbonBarOptions_Documents.Text = "AP Documents"
            '
            '
            '
            Me.RibbonBarOptions_Documents.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Documents.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Documents.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            Me.RibbonBarOptions_Documents.Visible = False
            '
            'ButtonItemDocuments_Download
            '
            Me.ButtonItemDocuments_Download.BeginGroup = True
            Me.ButtonItemDocuments_Download.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDocuments_Download.Name = "ButtonItemDocuments_Download"
            Me.ButtonItemDocuments_Download.RibbonWordWrap = False
            Me.ButtonItemDocuments_Download.SecurityEnabled = True
            Me.ButtonItemDocuments_Download.SubItemsExpandWidth = 14
            Me.ButtonItemDocuments_Download.Text = "Download"
            '
            'ButtonItemDocuments_OpenURL
            '
            Me.ButtonItemDocuments_OpenURL.BeginGroup = True
            Me.ButtonItemDocuments_OpenURL.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDocuments_OpenURL.Name = "ButtonItemDocuments_OpenURL"
            Me.ButtonItemDocuments_OpenURL.RibbonWordWrap = False
            Me.ButtonItemDocuments_OpenURL.SecurityEnabled = True
            Me.ButtonItemDocuments_OpenURL.SubItemsExpandWidth = 14
            Me.ButtonItemDocuments_OpenURL.Text = "Open URL"
            '
            'RibbonBarOptions_Vendor
            '
            Me.RibbonBarOptions_Vendor.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Vendor.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Vendor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Vendor.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Vendor.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Vendor.DragDropSupport = True
            Me.RibbonBarOptions_Vendor.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemVendor_MarkupDown, Me.ButtonItemVendor_WriteOff, Me.ButtonItemVendor_BillHold, Me.ButtonItemVendor_Transfer, Me.ButtonItemVendor_HideNonBillable, Me.ButtonItemVendor_ChooseColumns, Me.ButtonItemVendor_RestoreDefaults})
            Me.RibbonBarOptions_Vendor.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Vendor.Location = New System.Drawing.Point(797, 0)
            Me.RibbonBarOptions_Vendor.Name = "RibbonBarOptions_Vendor"
            Me.RibbonBarOptions_Vendor.SecurityEnabled = True
            Me.RibbonBarOptions_Vendor.Size = New System.Drawing.Size(53, 92)
            Me.RibbonBarOptions_Vendor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Vendor.TabIndex = 7
            Me.RibbonBarOptions_Vendor.Text = "Vendor"
            '
            '
            '
            Me.RibbonBarOptions_Vendor.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Vendor.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Vendor.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            Me.RibbonBarOptions_Vendor.Visible = False
            '
            'ButtonItemVendor_MarkupDown
            '
            Me.ButtonItemVendor_MarkupDown.AutoExpandOnClick = True
            Me.ButtonItemVendor_MarkupDown.BeginGroup = True
            Me.ButtonItemVendor_MarkupDown.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemVendor_MarkupDown.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemVendor_MarkupDown.Name = "ButtonItemVendor_MarkupDown"
            Me.ButtonItemVendor_MarkupDown.RibbonWordWrap = False
            Me.ButtonItemVendor_MarkupDown.SecurityEnabled = True
            Me.ButtonItemVendor_MarkupDown.Stretch = True
            Me.ButtonItemVendor_MarkupDown.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemVendorMarkupDown_Markdown100, Me.ButtonItemVendorMarkupDown_SetPercent})
            Me.ButtonItemVendor_MarkupDown.SubItemsExpandWidth = 14
            Me.ButtonItemVendor_MarkupDown.Text = "Markup/Down"
            '
            'ButtonItemVendorMarkupDown_Markdown100
            '
            Me.ButtonItemVendorMarkupDown_Markdown100.Name = "ButtonItemVendorMarkupDown_Markdown100"
            Me.ButtonItemVendorMarkupDown_Markdown100.Text = "Markdown 100%"
            '
            'ButtonItemVendorMarkupDown_SetPercent
            '
            Me.ButtonItemVendorMarkupDown_SetPercent.Name = "ButtonItemVendorMarkupDown_SetPercent"
            Me.ButtonItemVendorMarkupDown_SetPercent.Text = "Set %"
            '
            'ButtonItemVendor_WriteOff
            '
            Me.ButtonItemVendor_WriteOff.BeginGroup = True
            Me.ButtonItemVendor_WriteOff.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemVendor_WriteOff.Name = "ButtonItemVendor_WriteOff"
            Me.ButtonItemVendor_WriteOff.RibbonWordWrap = False
            Me.ButtonItemVendor_WriteOff.SecurityEnabled = True
            Me.ButtonItemVendor_WriteOff.SubItemsExpandWidth = 14
            Me.ButtonItemVendor_WriteOff.Text = "Write-off"
            '
            'ButtonItemVendor_BillHold
            '
            Me.ButtonItemVendor_BillHold.AutoExpandOnClick = True
            Me.ButtonItemVendor_BillHold.BeginGroup = True
            Me.ButtonItemVendor_BillHold.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemVendor_BillHold.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemVendor_BillHold.Name = "ButtonItemVendor_BillHold"
            Me.ButtonItemVendor_BillHold.RibbonWordWrap = False
            Me.ButtonItemVendor_BillHold.SecurityEnabled = True
            Me.ButtonItemVendor_BillHold.Stretch = True
            Me.ButtonItemVendor_BillHold.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemVendorBillHold_Temporary, Me.ButtonItemVendorBillHold_Permanent, Me.ButtonItemVendorBillHold_RemoveAll})
            Me.ButtonItemVendor_BillHold.SubItemsExpandWidth = 14
            Me.ButtonItemVendor_BillHold.Text = "Bill Hold"
            '
            'ButtonItemVendorBillHold_Temporary
            '
            Me.ButtonItemVendorBillHold_Temporary.Name = "ButtonItemVendorBillHold_Temporary"
            Me.ButtonItemVendorBillHold_Temporary.Text = "Temporary"
            '
            'ButtonItemVendorBillHold_Permanent
            '
            Me.ButtonItemVendorBillHold_Permanent.Name = "ButtonItemVendorBillHold_Permanent"
            Me.ButtonItemVendorBillHold_Permanent.Text = "Permanent"
            '
            'ButtonItemVendorBillHold_RemoveAll
            '
            Me.ButtonItemVendorBillHold_RemoveAll.Name = "ButtonItemVendorBillHold_RemoveAll"
            Me.ButtonItemVendorBillHold_RemoveAll.Text = "Remove All"
            '
            'ButtonItemVendor_Transfer
            '
            Me.ButtonItemVendor_Transfer.BeginGroup = True
            Me.ButtonItemVendor_Transfer.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemVendor_Transfer.Name = "ButtonItemVendor_Transfer"
            Me.ButtonItemVendor_Transfer.RibbonWordWrap = False
            Me.ButtonItemVendor_Transfer.SecurityEnabled = True
            Me.ButtonItemVendor_Transfer.SubItemsExpandWidth = 14
            Me.ButtonItemVendor_Transfer.Text = "Transfer"
            '
            'ButtonItemVendor_HideNonBillable
            '
            Me.ButtonItemVendor_HideNonBillable.AutoCheckOnClick = True
            Me.ButtonItemVendor_HideNonBillable.BeginGroup = True
            Me.ButtonItemVendor_HideNonBillable.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemVendor_HideNonBillable.Name = "ButtonItemVendor_HideNonBillable"
            Me.ButtonItemVendor_HideNonBillable.RibbonWordWrap = False
            Me.ButtonItemVendor_HideNonBillable.SecurityEnabled = True
            Me.ButtonItemVendor_HideNonBillable.SubItemsExpandWidth = 14
            Me.ButtonItemVendor_HideNonBillable.Text = "Hide Non-Billable"
            '
            'ButtonItemVendor_ChooseColumns
            '
            Me.ButtonItemVendor_ChooseColumns.AutoCheckOnClick = True
            Me.ButtonItemVendor_ChooseColumns.BeginGroup = True
            Me.ButtonItemVendor_ChooseColumns.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemVendor_ChooseColumns.Name = "ButtonItemVendor_ChooseColumns"
            Me.ButtonItemVendor_ChooseColumns.RibbonWordWrap = False
            Me.ButtonItemVendor_ChooseColumns.SecurityEnabled = True
            Me.ButtonItemVendor_ChooseColumns.SubItemsExpandWidth = 14
            Me.ButtonItemVendor_ChooseColumns.Text = "Choose Columns"
            '
            'ButtonItemVendor_RestoreDefaults
            '
            Me.ButtonItemVendor_RestoreDefaults.BeginGroup = True
            Me.ButtonItemVendor_RestoreDefaults.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemVendor_RestoreDefaults.Name = "ButtonItemVendor_RestoreDefaults"
            Me.ButtonItemVendor_RestoreDefaults.RibbonWordWrap = False
            Me.ButtonItemVendor_RestoreDefaults.SecurityEnabled = True
            Me.ButtonItemVendor_RestoreDefaults.SubItemsExpandWidth = 14
            Me.ButtonItemVendor_RestoreDefaults.Text = "Restore Defaults"
            '
            'RibbonBarOptions_IncomeOnly
            '
            Me.RibbonBarOptions_IncomeOnly.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_IncomeOnly.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_IncomeOnly.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_IncomeOnly.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_IncomeOnly.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_IncomeOnly.DragDropSupport = True
            Me.RibbonBarOptions_IncomeOnly.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemIncomeOnly_UpdateRate, Me.ButtonItemIncomeOnly_BillHold, Me.ButtonItemIncomeOnly_Transfer, Me.ButtonItemIncomeOnly_HideNonBillable, Me.ButtonItemIncomeOnly_ChooseColumns, Me.ButtonItemIncomeOnly_RestoreDefaults})
            Me.RibbonBarOptions_IncomeOnly.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_IncomeOnly.Location = New System.Drawing.Point(729, 0)
            Me.RibbonBarOptions_IncomeOnly.Name = "RibbonBarOptions_IncomeOnly"
            Me.RibbonBarOptions_IncomeOnly.SecurityEnabled = True
            Me.RibbonBarOptions_IncomeOnly.Size = New System.Drawing.Size(68, 92)
            Me.RibbonBarOptions_IncomeOnly.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_IncomeOnly.TabIndex = 6
            Me.RibbonBarOptions_IncomeOnly.Text = "Income Only"
            '
            '
            '
            Me.RibbonBarOptions_IncomeOnly.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_IncomeOnly.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_IncomeOnly.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            Me.RibbonBarOptions_IncomeOnly.Visible = False
            '
            'ButtonItemIncomeOnly_UpdateRate
            '
            Me.ButtonItemIncomeOnly_UpdateRate.AutoExpandOnClick = True
            Me.ButtonItemIncomeOnly_UpdateRate.BeginGroup = True
            Me.ButtonItemIncomeOnly_UpdateRate.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemIncomeOnly_UpdateRate.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemIncomeOnly_UpdateRate.Name = "ButtonItemIncomeOnly_UpdateRate"
            Me.ButtonItemIncomeOnly_UpdateRate.RibbonWordWrap = False
            Me.ButtonItemIncomeOnly_UpdateRate.SecurityEnabled = True
            Me.ButtonItemIncomeOnly_UpdateRate.Stretch = True
            Me.ButtonItemIncomeOnly_UpdateRate.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemIOUpdateRate_FromHierarchy, Me.ButtonItemIOUpdateRate_SetRate})
            Me.ButtonItemIncomeOnly_UpdateRate.SubItemsExpandWidth = 14
            Me.ButtonItemIncomeOnly_UpdateRate.Text = "Update Rate"
            Me.ButtonItemIncomeOnly_UpdateRate.Tooltip = "Marks selected rows with the rates/flags from billing hierarchy."
            '
            'ButtonItemIOUpdateRate_FromHierarchy
            '
            Me.ButtonItemIOUpdateRate_FromHierarchy.Name = "ButtonItemIOUpdateRate_FromHierarchy"
            Me.ButtonItemIOUpdateRate_FromHierarchy.Text = "From Hierarchy"
            '
            'ButtonItemIOUpdateRate_SetRate
            '
            Me.ButtonItemIOUpdateRate_SetRate.Name = "ButtonItemIOUpdateRate_SetRate"
            Me.ButtonItemIOUpdateRate_SetRate.Text = "Set Rate"
            '
            'ButtonItemIncomeOnly_BillHold
            '
            Me.ButtonItemIncomeOnly_BillHold.AutoExpandOnClick = True
            Me.ButtonItemIncomeOnly_BillHold.BeginGroup = True
            Me.ButtonItemIncomeOnly_BillHold.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemIncomeOnly_BillHold.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemIncomeOnly_BillHold.Name = "ButtonItemIncomeOnly_BillHold"
            Me.ButtonItemIncomeOnly_BillHold.RibbonWordWrap = False
            Me.ButtonItemIncomeOnly_BillHold.SecurityEnabled = True
            Me.ButtonItemIncomeOnly_BillHold.Stretch = True
            Me.ButtonItemIncomeOnly_BillHold.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemIOBillHold_Temporary, Me.ButtonItemIOBillHold_Permanent, Me.ButtonItemIOBillHold_RemoveAll})
            Me.ButtonItemIncomeOnly_BillHold.SubItemsExpandWidth = 14
            Me.ButtonItemIncomeOnly_BillHold.Text = "Bill Hold"
            '
            'ButtonItemIOBillHold_Temporary
            '
            Me.ButtonItemIOBillHold_Temporary.Name = "ButtonItemIOBillHold_Temporary"
            Me.ButtonItemIOBillHold_Temporary.Text = "Temporary"
            '
            'ButtonItemIOBillHold_Permanent
            '
            Me.ButtonItemIOBillHold_Permanent.Name = "ButtonItemIOBillHold_Permanent"
            Me.ButtonItemIOBillHold_Permanent.Text = "Permanent"
            '
            'ButtonItemIOBillHold_RemoveAll
            '
            Me.ButtonItemIOBillHold_RemoveAll.Name = "ButtonItemIOBillHold_RemoveAll"
            Me.ButtonItemIOBillHold_RemoveAll.Text = "Remove All"
            '
            'ButtonItemIncomeOnly_Transfer
            '
            Me.ButtonItemIncomeOnly_Transfer.BeginGroup = True
            Me.ButtonItemIncomeOnly_Transfer.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemIncomeOnly_Transfer.Name = "ButtonItemIncomeOnly_Transfer"
            Me.ButtonItemIncomeOnly_Transfer.RibbonWordWrap = False
            Me.ButtonItemIncomeOnly_Transfer.SecurityEnabled = True
            Me.ButtonItemIncomeOnly_Transfer.SubItemsExpandWidth = 14
            Me.ButtonItemIncomeOnly_Transfer.Text = "Transfer"
            '
            'ButtonItemIncomeOnly_HideNonBillable
            '
            Me.ButtonItemIncomeOnly_HideNonBillable.AutoCheckOnClick = True
            Me.ButtonItemIncomeOnly_HideNonBillable.BeginGroup = True
            Me.ButtonItemIncomeOnly_HideNonBillable.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemIncomeOnly_HideNonBillable.Name = "ButtonItemIncomeOnly_HideNonBillable"
            Me.ButtonItemIncomeOnly_HideNonBillable.RibbonWordWrap = False
            Me.ButtonItemIncomeOnly_HideNonBillable.SecurityEnabled = True
            Me.ButtonItemIncomeOnly_HideNonBillable.SubItemsExpandWidth = 14
            Me.ButtonItemIncomeOnly_HideNonBillable.Text = "Hide Non-Billable"
            '
            'ButtonItemIncomeOnly_ChooseColumns
            '
            Me.ButtonItemIncomeOnly_ChooseColumns.AutoCheckOnClick = True
            Me.ButtonItemIncomeOnly_ChooseColumns.BeginGroup = True
            Me.ButtonItemIncomeOnly_ChooseColumns.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemIncomeOnly_ChooseColumns.Name = "ButtonItemIncomeOnly_ChooseColumns"
            Me.ButtonItemIncomeOnly_ChooseColumns.RibbonWordWrap = False
            Me.ButtonItemIncomeOnly_ChooseColumns.SecurityEnabled = True
            Me.ButtonItemIncomeOnly_ChooseColumns.SubItemsExpandWidth = 14
            Me.ButtonItemIncomeOnly_ChooseColumns.Text = "Choose Columns"
            '
            'ButtonItemIncomeOnly_RestoreDefaults
            '
            Me.ButtonItemIncomeOnly_RestoreDefaults.BeginGroup = True
            Me.ButtonItemIncomeOnly_RestoreDefaults.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemIncomeOnly_RestoreDefaults.Name = "ButtonItemIncomeOnly_RestoreDefaults"
            Me.ButtonItemIncomeOnly_RestoreDefaults.RibbonWordWrap = False
            Me.ButtonItemIncomeOnly_RestoreDefaults.SecurityEnabled = True
            Me.ButtonItemIncomeOnly_RestoreDefaults.SubItemsExpandWidth = 14
            Me.ButtonItemIncomeOnly_RestoreDefaults.Text = "Restore Defaults"
            '
            'RibbonBarOptions_EmployeeTime
            '
            Me.RibbonBarOptions_EmployeeTime.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_EmployeeTime.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_EmployeeTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_EmployeeTime.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_EmployeeTime.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_EmployeeTime.DragDropSupport = True
            Me.RibbonBarOptions_EmployeeTime.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemEmployeeTime_MarkBillable, Me.ButtonItemEmployeeTime_MarkNonBillable, Me.ButtonItemEmployeeTime_FeeTime, Me.ButtonItemEmployeeTime_UpdateRate, Me.ButtonItemEmployeeTime_MarkupDown, Me.ButtonItemEmployeeTime_BillHold, Me.ButtonItemEmployeeTime_Transfer, Me.ButtonItemEmployeeTime_HideNonBillable, Me.ButtonItemEmployeeTime_ChooseColumns, Me.ButtonItemEmployeeTime_RestoreDefaults})
            Me.RibbonBarOptions_EmployeeTime.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_EmployeeTime.Location = New System.Drawing.Point(638, 0)
            Me.RibbonBarOptions_EmployeeTime.Name = "RibbonBarOptions_EmployeeTime"
            Me.RibbonBarOptions_EmployeeTime.SecurityEnabled = True
            Me.RibbonBarOptions_EmployeeTime.Size = New System.Drawing.Size(91, 92)
            Me.RibbonBarOptions_EmployeeTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_EmployeeTime.TabIndex = 5
            Me.RibbonBarOptions_EmployeeTime.Text = "Employee Time"
            '
            '
            '
            Me.RibbonBarOptions_EmployeeTime.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_EmployeeTime.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_EmployeeTime.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemEmployeeTime_MarkBillable
            '
            Me.ButtonItemEmployeeTime_MarkBillable.BeginGroup = True
            Me.ButtonItemEmployeeTime_MarkBillable.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemEmployeeTime_MarkBillable.Name = "ButtonItemEmployeeTime_MarkBillable"
            Me.ButtonItemEmployeeTime_MarkBillable.RibbonWordWrap = False
            Me.ButtonItemEmployeeTime_MarkBillable.SecurityEnabled = True
            Me.ButtonItemEmployeeTime_MarkBillable.SubItemsExpandWidth = 14
            Me.ButtonItemEmployeeTime_MarkBillable.Text = "Mark Billable"
            '
            'ButtonItemEmployeeTime_MarkNonBillable
            '
            Me.ButtonItemEmployeeTime_MarkNonBillable.BeginGroup = True
            Me.ButtonItemEmployeeTime_MarkNonBillable.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemEmployeeTime_MarkNonBillable.Name = "ButtonItemEmployeeTime_MarkNonBillable"
            Me.ButtonItemEmployeeTime_MarkNonBillable.RibbonWordWrap = False
            Me.ButtonItemEmployeeTime_MarkNonBillable.SecurityEnabled = True
            Me.ButtonItemEmployeeTime_MarkNonBillable.SubItemsExpandWidth = 14
            Me.ButtonItemEmployeeTime_MarkNonBillable.Text = "Mark Nonbillable"
            '
            'ButtonItemEmployeeTime_FeeTime
            '
            Me.ButtonItemEmployeeTime_FeeTime.AutoExpandOnClick = True
            Me.ButtonItemEmployeeTime_FeeTime.BeginGroup = True
            Me.ButtonItemEmployeeTime_FeeTime.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemEmployeeTime_FeeTime.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemEmployeeTime_FeeTime.Name = "ButtonItemEmployeeTime_FeeTime"
            Me.ButtonItemEmployeeTime_FeeTime.RibbonWordWrap = False
            Me.ButtonItemEmployeeTime_FeeTime.SecurityEnabled = True
            Me.ButtonItemEmployeeTime_FeeTime.Stretch = True
            Me.ButtonItemEmployeeTime_FeeTime.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemFeeTime_No, Me.ButtonItemFeeTime_TimeAgainstFee, Me.ButtonItemFeeTime_TimeAgainstCommissionP, Me.ButtonItemFeeTime_TimeAgainstCommissionM})
            Me.ButtonItemEmployeeTime_FeeTime.SubItemsExpandWidth = 14
            Me.ButtonItemEmployeeTime_FeeTime.Text = "Fee Time"
            Me.ButtonItemEmployeeTime_FeeTime.Tooltip = "Marks selected rows with the Fee Time Flag as indicated where applicable."
            '
            'ButtonItemFeeTime_No
            '
            Me.ButtonItemFeeTime_No.Name = "ButtonItemFeeTime_No"
            Me.ButtonItemFeeTime_No.Text = "No"
            '
            'ButtonItemFeeTime_TimeAgainstFee
            '
            Me.ButtonItemFeeTime_TimeAgainstFee.Name = "ButtonItemFeeTime_TimeAgainstFee"
            Me.ButtonItemFeeTime_TimeAgainstFee.Text = "Time Against Fee"
            '
            'ButtonItemFeeTime_TimeAgainstCommissionP
            '
            Me.ButtonItemFeeTime_TimeAgainstCommissionP.Name = "ButtonItemFeeTime_TimeAgainstCommissionP"
            Me.ButtonItemFeeTime_TimeAgainstCommissionP.Text = "Time Against Commission (P)"
            '
            'ButtonItemFeeTime_TimeAgainstCommissionM
            '
            Me.ButtonItemFeeTime_TimeAgainstCommissionM.Name = "ButtonItemFeeTime_TimeAgainstCommissionM"
            Me.ButtonItemFeeTime_TimeAgainstCommissionM.Text = "Time Against Commission (M)"
            '
            'ButtonItemEmployeeTime_UpdateRate
            '
            Me.ButtonItemEmployeeTime_UpdateRate.AutoExpandOnClick = True
            Me.ButtonItemEmployeeTime_UpdateRate.BeginGroup = True
            Me.ButtonItemEmployeeTime_UpdateRate.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemEmployeeTime_UpdateRate.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemEmployeeTime_UpdateRate.Name = "ButtonItemEmployeeTime_UpdateRate"
            Me.ButtonItemEmployeeTime_UpdateRate.RibbonWordWrap = False
            Me.ButtonItemEmployeeTime_UpdateRate.SecurityEnabled = True
            Me.ButtonItemEmployeeTime_UpdateRate.Stretch = True
            Me.ButtonItemEmployeeTime_UpdateRate.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemETUpdateRate_FromHierarchy, Me.ButtonItemETUpdateRate_SetRate})
            Me.ButtonItemEmployeeTime_UpdateRate.SubItemsExpandWidth = 14
            Me.ButtonItemEmployeeTime_UpdateRate.Text = "Update Rate"
            Me.ButtonItemEmployeeTime_UpdateRate.Tooltip = "Marks selected rows with the rates/flags from billing hierarchy."
            '
            'ButtonItemETUpdateRate_FromHierarchy
            '
            Me.ButtonItemETUpdateRate_FromHierarchy.Name = "ButtonItemETUpdateRate_FromHierarchy"
            Me.ButtonItemETUpdateRate_FromHierarchy.Text = "From Hierarchy"
            '
            'ButtonItemETUpdateRate_SetRate
            '
            Me.ButtonItemETUpdateRate_SetRate.Name = "ButtonItemETUpdateRate_SetRate"
            Me.ButtonItemETUpdateRate_SetRate.Text = "Set Rate"
            '
            'ButtonItemEmployeeTime_MarkupDown
            '
            Me.ButtonItemEmployeeTime_MarkupDown.AutoExpandOnClick = True
            Me.ButtonItemEmployeeTime_MarkupDown.BeginGroup = True
            Me.ButtonItemEmployeeTime_MarkupDown.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemEmployeeTime_MarkupDown.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemEmployeeTime_MarkupDown.Name = "ButtonItemEmployeeTime_MarkupDown"
            Me.ButtonItemEmployeeTime_MarkupDown.RibbonWordWrap = False
            Me.ButtonItemEmployeeTime_MarkupDown.SecurityEnabled = True
            Me.ButtonItemEmployeeTime_MarkupDown.Stretch = True
            Me.ButtonItemEmployeeTime_MarkupDown.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemETMarkupDown_Markdown100, Me.ButtonItemETMarkupDown_SetPercent, Me.ButtonItemETMarkupDown_ToEstimateAmountForFunction, Me.ButtonItemETMarkupDown_ToBilledAmountForFunction, Me.ButtonItemETMarkupDown_ToApprovedAmountForFunction, Me.ButtonItemETMarkupDown_ToApprovedAmountForItem})
            Me.ButtonItemEmployeeTime_MarkupDown.SubItemsExpandWidth = 14
            Me.ButtonItemEmployeeTime_MarkupDown.Text = "Markup/Down"
            '
            'ButtonItemETMarkupDown_Markdown100
            '
            Me.ButtonItemETMarkupDown_Markdown100.Name = "ButtonItemETMarkupDown_Markdown100"
            Me.ButtonItemETMarkupDown_Markdown100.Text = "Markdown 100%"
            '
            'ButtonItemETMarkupDown_SetPercent
            '
            Me.ButtonItemETMarkupDown_SetPercent.Name = "ButtonItemETMarkupDown_SetPercent"
            Me.ButtonItemETMarkupDown_SetPercent.Text = "Set %"
            '
            'ButtonItemETMarkupDown_ToEstimateAmountForFunction
            '
            Me.ButtonItemETMarkupDown_ToEstimateAmountForFunction.Name = "ButtonItemETMarkupDown_ToEstimateAmountForFunction"
            Me.ButtonItemETMarkupDown_ToEstimateAmountForFunction.Text = "To Estimate Amount for Function"
            '
            'ButtonItemETMarkupDown_ToBilledAmountForFunction
            '
            Me.ButtonItemETMarkupDown_ToBilledAmountForFunction.Name = "ButtonItemETMarkupDown_ToBilledAmountForFunction"
            Me.ButtonItemETMarkupDown_ToBilledAmountForFunction.Text = "To Billed Amount for Function"
            '
            'ButtonItemETMarkupDown_ToApprovedAmountForFunction
            '
            Me.ButtonItemETMarkupDown_ToApprovedAmountForFunction.Name = "ButtonItemETMarkupDown_ToApprovedAmountForFunction"
            Me.ButtonItemETMarkupDown_ToApprovedAmountForFunction.Text = "To Approved Amount for Function"
            '
            'ButtonItemETMarkupDown_ToApprovedAmountForItem
            '
            Me.ButtonItemETMarkupDown_ToApprovedAmountForItem.Name = "ButtonItemETMarkupDown_ToApprovedAmountForItem"
            Me.ButtonItemETMarkupDown_ToApprovedAmountForItem.Text = "To Approved Amount for Item"
            '
            'ButtonItemEmployeeTime_BillHold
            '
            Me.ButtonItemEmployeeTime_BillHold.AutoExpandOnClick = True
            Me.ButtonItemEmployeeTime_BillHold.BeginGroup = True
            Me.ButtonItemEmployeeTime_BillHold.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemEmployeeTime_BillHold.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemEmployeeTime_BillHold.Name = "ButtonItemEmployeeTime_BillHold"
            Me.ButtonItemEmployeeTime_BillHold.RibbonWordWrap = False
            Me.ButtonItemEmployeeTime_BillHold.SecurityEnabled = True
            Me.ButtonItemEmployeeTime_BillHold.Stretch = True
            Me.ButtonItemEmployeeTime_BillHold.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemETBillHold_Temporary, Me.ButtonItemETBillHold_Permanent, Me.ButtonItemETBillHold_RemoveAll})
            Me.ButtonItemEmployeeTime_BillHold.SubItemsExpandWidth = 14
            Me.ButtonItemEmployeeTime_BillHold.Text = "Bill Hold"
            '
            'ButtonItemETBillHold_Temporary
            '
            Me.ButtonItemETBillHold_Temporary.Name = "ButtonItemETBillHold_Temporary"
            Me.ButtonItemETBillHold_Temporary.Text = "Temporary"
            '
            'ButtonItemETBillHold_Permanent
            '
            Me.ButtonItemETBillHold_Permanent.Name = "ButtonItemETBillHold_Permanent"
            Me.ButtonItemETBillHold_Permanent.Text = "Permanent"
            '
            'ButtonItemETBillHold_RemoveAll
            '
            Me.ButtonItemETBillHold_RemoveAll.Name = "ButtonItemETBillHold_RemoveAll"
            Me.ButtonItemETBillHold_RemoveAll.Text = "Remove All"
            '
            'ButtonItemEmployeeTime_Transfer
            '
            Me.ButtonItemEmployeeTime_Transfer.BeginGroup = True
            Me.ButtonItemEmployeeTime_Transfer.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemEmployeeTime_Transfer.Name = "ButtonItemEmployeeTime_Transfer"
            Me.ButtonItemEmployeeTime_Transfer.RibbonWordWrap = False
            Me.ButtonItemEmployeeTime_Transfer.SecurityEnabled = True
            Me.ButtonItemEmployeeTime_Transfer.SubItemsExpandWidth = 14
            Me.ButtonItemEmployeeTime_Transfer.Text = "Transfer"
            '
            'ButtonItemEmployeeTime_HideNonBillable
            '
            Me.ButtonItemEmployeeTime_HideNonBillable.AutoCheckOnClick = True
            Me.ButtonItemEmployeeTime_HideNonBillable.BeginGroup = True
            Me.ButtonItemEmployeeTime_HideNonBillable.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemEmployeeTime_HideNonBillable.Name = "ButtonItemEmployeeTime_HideNonBillable"
            Me.ButtonItemEmployeeTime_HideNonBillable.RibbonWordWrap = False
            Me.ButtonItemEmployeeTime_HideNonBillable.SecurityEnabled = True
            Me.ButtonItemEmployeeTime_HideNonBillable.SubItemsExpandWidth = 14
            Me.ButtonItemEmployeeTime_HideNonBillable.Text = "Hide Non-Billable"
            '
            'ButtonItemEmployeeTime_ChooseColumns
            '
            Me.ButtonItemEmployeeTime_ChooseColumns.AutoCheckOnClick = True
            Me.ButtonItemEmployeeTime_ChooseColumns.BeginGroup = True
            Me.ButtonItemEmployeeTime_ChooseColumns.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemEmployeeTime_ChooseColumns.Name = "ButtonItemEmployeeTime_ChooseColumns"
            Me.ButtonItemEmployeeTime_ChooseColumns.RibbonWordWrap = False
            Me.ButtonItemEmployeeTime_ChooseColumns.SecurityEnabled = True
            Me.ButtonItemEmployeeTime_ChooseColumns.SubItemsExpandWidth = 14
            Me.ButtonItemEmployeeTime_ChooseColumns.Text = "Choose Columns"
            '
            'ButtonItemEmployeeTime_RestoreDefaults
            '
            Me.ButtonItemEmployeeTime_RestoreDefaults.BeginGroup = True
            Me.ButtonItemEmployeeTime_RestoreDefaults.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemEmployeeTime_RestoreDefaults.Name = "ButtonItemEmployeeTime_RestoreDefaults"
            Me.ButtonItemEmployeeTime_RestoreDefaults.RibbonWordWrap = False
            Me.ButtonItemEmployeeTime_RestoreDefaults.SecurityEnabled = True
            Me.ButtonItemEmployeeTime_RestoreDefaults.SubItemsExpandWidth = 14
            Me.ButtonItemEmployeeTime_RestoreDefaults.Text = "Restore Defaults"
            '
            'RibbonBarOptions_Include
            '
            Me.RibbonBarOptions_Include.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Include.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Include.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Include.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Include.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Include.DragDropSupport = True
            Me.RibbonBarOptions_Include.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemInclude_Contingency})
            Me.RibbonBarOptions_Include.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Include.Location = New System.Drawing.Point(279, 0)
            Me.RibbonBarOptions_Include.Name = "RibbonBarOptions_Include"
            Me.RibbonBarOptions_Include.SecurityEnabled = True
            Me.RibbonBarOptions_Include.Size = New System.Drawing.Size(106, 92)
            Me.RibbonBarOptions_Include.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Include.TabIndex = 3
            Me.RibbonBarOptions_Include.Text = "Include"
            '
            '
            '
            Me.RibbonBarOptions_Include.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Include.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Include.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemInclude_Contingency
            '
            Me.ButtonItemInclude_Contingency.AutoCheckOnClick = True
            Me.ButtonItemInclude_Contingency.BeginGroup = True
            Me.ButtonItemInclude_Contingency.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemInclude_Contingency.Name = "ButtonItemInclude_Contingency"
            Me.ButtonItemInclude_Contingency.RibbonWordWrap = False
            Me.ButtonItemInclude_Contingency.SecurityEnabled = True
            Me.ButtonItemInclude_Contingency.SubItemsExpandWidth = 14
            Me.ButtonItemInclude_Contingency.Text = "Contingency"
            '
            'RibbonBarOptions_FunctionGrid
            '
            Me.RibbonBarOptions_FunctionGrid.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_FunctionGrid.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_FunctionGrid.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_FunctionGrid.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_FunctionGrid.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_FunctionGrid.DragDropSupport = True
            Me.RibbonBarOptions_FunctionGrid.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemFunctionGrid_ChooseColumns, Me.ButtonItemFunctionGrid_RestoreDefaults, Me.ButtonItemFunctionGrid_SelectAll})
            Me.RibbonBarOptions_FunctionGrid.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_FunctionGrid.Location = New System.Drawing.Point(385, 0)
            Me.RibbonBarOptions_FunctionGrid.Name = "RibbonBarOptions_FunctionGrid"
            Me.RibbonBarOptions_FunctionGrid.SecurityEnabled = True
            Me.RibbonBarOptions_FunctionGrid.Size = New System.Drawing.Size(253, 92)
            Me.RibbonBarOptions_FunctionGrid.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_FunctionGrid.TabIndex = 4
            Me.RibbonBarOptions_FunctionGrid.Text = "Function Grid"
            '
            '
            '
            Me.RibbonBarOptions_FunctionGrid.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_FunctionGrid.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_FunctionGrid.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemFunctionGrid_ChooseColumns
            '
            Me.ButtonItemFunctionGrid_ChooseColumns.AutoCheckOnClick = True
            Me.ButtonItemFunctionGrid_ChooseColumns.BeginGroup = True
            Me.ButtonItemFunctionGrid_ChooseColumns.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemFunctionGrid_ChooseColumns.Name = "ButtonItemFunctionGrid_ChooseColumns"
            Me.ButtonItemFunctionGrid_ChooseColumns.RibbonWordWrap = False
            Me.ButtonItemFunctionGrid_ChooseColumns.SecurityEnabled = True
            Me.ButtonItemFunctionGrid_ChooseColumns.SubItemsExpandWidth = 14
            Me.ButtonItemFunctionGrid_ChooseColumns.Text = "Choose Columns"
            '
            'ButtonItemFunctionGrid_RestoreDefaults
            '
            Me.ButtonItemFunctionGrid_RestoreDefaults.BeginGroup = True
            Me.ButtonItemFunctionGrid_RestoreDefaults.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemFunctionGrid_RestoreDefaults.Name = "ButtonItemFunctionGrid_RestoreDefaults"
            Me.ButtonItemFunctionGrid_RestoreDefaults.RibbonWordWrap = False
            Me.ButtonItemFunctionGrid_RestoreDefaults.SecurityEnabled = True
            Me.ButtonItemFunctionGrid_RestoreDefaults.SubItemsExpandWidth = 14
            Me.ButtonItemFunctionGrid_RestoreDefaults.Text = "Restore Defaults"
            '
            'ButtonItemFunctionGrid_SelectAll
            '
            Me.ButtonItemFunctionGrid_SelectAll.AutoCheckOnClick = True
            Me.ButtonItemFunctionGrid_SelectAll.BeginGroup = True
            Me.ButtonItemFunctionGrid_SelectAll.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemFunctionGrid_SelectAll.Name = "ButtonItemFunctionGrid_SelectAll"
            Me.ButtonItemFunctionGrid_SelectAll.RibbonWordWrap = False
            Me.ButtonItemFunctionGrid_SelectAll.SecurityEnabled = True
            Me.ButtonItemFunctionGrid_SelectAll.SubItemsExpandWidth = 14
            Me.ButtonItemFunctionGrid_SelectAll.Text = "Select All"
            '
            'PanelForm_LeftSection
            '
            Me.PanelForm_LeftSection.Controls.Add(Me.DataGridViewLeftSection_Jobs)
            Me.PanelForm_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelForm_LeftSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelForm_LeftSection.Name = "PanelForm_LeftSection"
            Me.PanelForm_LeftSection.Size = New System.Drawing.Size(155, 555)
            Me.PanelForm_LeftSection.TabIndex = 10
            '
            'DataGridViewLeftSection_Jobs
            '
            Me.DataGridViewLeftSection_Jobs.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewLeftSection_Jobs.AllowDragAndDrop = False
            Me.DataGridViewLeftSection_Jobs.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewLeftSection_Jobs.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_Jobs.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewLeftSection_Jobs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_Jobs.AutoFilterLookupColumns = False
            Me.DataGridViewLeftSection_Jobs.AutoloadRepositoryDatasource = True
            Me.DataGridViewLeftSection_Jobs.AutoUpdateViewCaption = True
            Me.DataGridViewLeftSection_Jobs.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewLeftSection_Jobs.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewLeftSection_Jobs.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_Jobs.ItemDescription = "Job(s)"
            Me.DataGridViewLeftSection_Jobs.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewLeftSection_Jobs.MultiSelect = True
            Me.DataGridViewLeftSection_Jobs.Name = "DataGridViewLeftSection_Jobs"
            Me.DataGridViewLeftSection_Jobs.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_Jobs.RunStandardValidation = True
            Me.DataGridViewLeftSection_Jobs.ShowColumnMenuOnRightClick = False
            Me.DataGridViewLeftSection_Jobs.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_Jobs.Size = New System.Drawing.Size(137, 531)
            Me.DataGridViewLeftSection_Jobs.TabIndex = 0
            Me.DataGridViewLeftSection_Jobs.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_Jobs.ViewCaptionHeight = -1
            '
            'ExpandableSplitterControlForm_LeftRight
            '
            Me.ExpandableSplitterControlForm_LeftRight.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlForm_LeftRight.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControlForm_LeftRight.ExpandableControl = Me.PanelForm_LeftSection
            Me.ExpandableSplitterControlForm_LeftRight.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlForm_LeftRight.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlForm_LeftRight.ForeColor = System.Drawing.Color.Black
            Me.ExpandableSplitterControlForm_LeftRight.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlForm_LeftRight.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlForm_LeftRight.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterControlForm_LeftRight.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterControlForm_LeftRight.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlForm_LeftRight.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlForm_LeftRight.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlForm_LeftRight.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlForm_LeftRight.Location = New System.Drawing.Point(155, 0)
            Me.ExpandableSplitterControlForm_LeftRight.Name = "ExpandableSplitterControlForm_LeftRight"
            Me.ExpandableSplitterControlForm_LeftRight.Size = New System.Drawing.Size(5, 555)
            Me.ExpandableSplitterControlForm_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControlForm_LeftRight.TabIndex = 11
            Me.ExpandableSplitterControlForm_LeftRight.TabStop = False
            '
            'PanelForm_RightSection
            '
            Me.PanelForm_RightSection.Controls.Add(Me.PanelRightSection_Bottom)
            Me.PanelForm_RightSection.Controls.Add(Me.ExpandableSplitterControlRightSection_TopBottom)
            Me.PanelForm_RightSection.Controls.Add(Me.PanelRightSection_Top)
            Me.PanelForm_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelForm_RightSection.Location = New System.Drawing.Point(160, 0)
            Me.PanelForm_RightSection.Name = "PanelForm_RightSection"
            Me.PanelForm_RightSection.Size = New System.Drawing.Size(1009, 555)
            Me.PanelForm_RightSection.TabIndex = 12
            '
            'PanelRightSection_Bottom
            '
            Me.PanelRightSection_Bottom.Controls.Add(Me.TabControlRightSection_FunctionItems)
            Me.PanelRightSection_Bottom.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelRightSection_Bottom.Location = New System.Drawing.Point(2, 246)
            Me.PanelRightSection_Bottom.Name = "PanelRightSection_Bottom"
            Me.PanelRightSection_Bottom.Size = New System.Drawing.Size(1005, 307)
            Me.PanelRightSection_Bottom.TabIndex = 17
            '
            'TabControlRightSection_FunctionItems
            '
            Me.TabControlRightSection_FunctionItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlRightSection_FunctionItems.BackColor = System.Drawing.Color.White
            Me.TabControlRightSection_FunctionItems.CanReorderTabs = False
            Me.TabControlRightSection_FunctionItems.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlRightSection_FunctionItems.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlRightSection_FunctionItems.Controls.Add(Me.TabControlPanelEmployeeTimeTab_EmployeeTime)
            Me.TabControlRightSection_FunctionItems.Controls.Add(Me.TabControlPanelOpenPOTab_OpenPO)
            Me.TabControlRightSection_FunctionItems.Controls.Add(Me.TabControlPanelAdvanceBillingTab_AdvanceBilling)
            Me.TabControlRightSection_FunctionItems.Controls.Add(Me.TabControlPanelDocumentsTab_Documents)
            Me.TabControlRightSection_FunctionItems.Controls.Add(Me.TabControlPanelVendorTab_Vendor)
            Me.TabControlRightSection_FunctionItems.Controls.Add(Me.TabControlPanelIncomeOnlyTab_IncomeOnly)
            Me.TabControlRightSection_FunctionItems.ForeColor = System.Drawing.Color.Black
            Me.TabControlRightSection_FunctionItems.Location = New System.Drawing.Point(6, 6)
            Me.TabControlRightSection_FunctionItems.Name = "TabControlRightSection_FunctionItems"
            Me.TabControlRightSection_FunctionItems.SelectedTabFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlRightSection_FunctionItems.SelectedTabIndex = 0
            Me.TabControlRightSection_FunctionItems.Size = New System.Drawing.Size(989, 305)
            Me.TabControlRightSection_FunctionItems.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlRightSection_FunctionItems.TabIndex = 0
            Me.TabControlRightSection_FunctionItems.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlRightSection_FunctionItems.Tabs.Add(Me.TabItemFunctionItems_EmployeeTime)
            Me.TabControlRightSection_FunctionItems.Tabs.Add(Me.TabItemFunctionItems_IncomeOnly)
            Me.TabControlRightSection_FunctionItems.Tabs.Add(Me.TabItemFunctionItems_Vendor)
            Me.TabControlRightSection_FunctionItems.Tabs.Add(Me.TabItemFunctionItems_AdvanceBilling)
            Me.TabControlRightSection_FunctionItems.Tabs.Add(Me.TabItemFunctionItems_OpenPO)
            Me.TabControlRightSection_FunctionItems.Tabs.Add(Me.TabItemFunctionItems_Documents)
            '
            'TabControlPanelEmployeeTimeTab_EmployeeTime
            '
            Me.TabControlPanelEmployeeTimeTab_EmployeeTime.Controls.Add(Me.DataGridViewEmployeeTime_Details)
            Me.TabControlPanelEmployeeTimeTab_EmployeeTime.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelEmployeeTimeTab_EmployeeTime.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelEmployeeTimeTab_EmployeeTime.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelEmployeeTimeTab_EmployeeTime.Name = "TabControlPanelEmployeeTimeTab_EmployeeTime"
            Me.TabControlPanelEmployeeTimeTab_EmployeeTime.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelEmployeeTimeTab_EmployeeTime.Size = New System.Drawing.Size(989, 278)
            Me.TabControlPanelEmployeeTimeTab_EmployeeTime.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelEmployeeTimeTab_EmployeeTime.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelEmployeeTimeTab_EmployeeTime.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelEmployeeTimeTab_EmployeeTime.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelEmployeeTimeTab_EmployeeTime.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelEmployeeTimeTab_EmployeeTime.Style.GradientAngle = 90
            Me.TabControlPanelEmployeeTimeTab_EmployeeTime.TabIndex = 1
            Me.TabControlPanelEmployeeTimeTab_EmployeeTime.TabItem = Me.TabItemFunctionItems_EmployeeTime
            '
            'DataGridViewEmployeeTime_Details
            '
            Me.DataGridViewEmployeeTime_Details.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewEmployeeTime_Details.AllowDragAndDrop = False
            Me.DataGridViewEmployeeTime_Details.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewEmployeeTime_Details.AllowSelectGroupHeaderRow = True
            Me.DataGridViewEmployeeTime_Details.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewEmployeeTime_Details.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewEmployeeTime_Details.AutoFilterLookupColumns = False
            Me.DataGridViewEmployeeTime_Details.AutoloadRepositoryDatasource = True
            Me.DataGridViewEmployeeTime_Details.AutoUpdateViewCaption = True
            Me.DataGridViewEmployeeTime_Details.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewEmployeeTime_Details.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewEmployeeTime_Details.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewEmployeeTime_Details.ItemDescription = "Item(s)"
            Me.DataGridViewEmployeeTime_Details.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewEmployeeTime_Details.MultiSelect = True
            Me.DataGridViewEmployeeTime_Details.Name = "DataGridViewEmployeeTime_Details"
            Me.DataGridViewEmployeeTime_Details.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewEmployeeTime_Details.RunStandardValidation = True
            Me.DataGridViewEmployeeTime_Details.ShowColumnMenuOnRightClick = False
            Me.DataGridViewEmployeeTime_Details.ShowSelectDeselectAllButtons = False
            Me.DataGridViewEmployeeTime_Details.Size = New System.Drawing.Size(981, 278)
            Me.DataGridViewEmployeeTime_Details.TabIndex = 0
            Me.DataGridViewEmployeeTime_Details.UseEmbeddedNavigator = False
            Me.DataGridViewEmployeeTime_Details.ViewCaptionHeight = -1
            '
            'TabItemFunctionItems_EmployeeTime
            '
            Me.TabItemFunctionItems_EmployeeTime.AttachedControl = Me.TabControlPanelEmployeeTimeTab_EmployeeTime
            Me.TabItemFunctionItems_EmployeeTime.Name = "TabItemFunctionItems_EmployeeTime"
            Me.TabItemFunctionItems_EmployeeTime.Text = "Employee Time"
            '
            'TabControlPanelOpenPOTab_OpenPO
            '
            Me.TabControlPanelOpenPOTab_OpenPO.Controls.Add(Me.DataGridViewOpenPO_Details)
            Me.TabControlPanelOpenPOTab_OpenPO.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelOpenPOTab_OpenPO.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelOpenPOTab_OpenPO.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelOpenPOTab_OpenPO.Name = "TabControlPanelOpenPOTab_OpenPO"
            Me.TabControlPanelOpenPOTab_OpenPO.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelOpenPOTab_OpenPO.Size = New System.Drawing.Size(989, 278)
            Me.TabControlPanelOpenPOTab_OpenPO.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelOpenPOTab_OpenPO.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelOpenPOTab_OpenPO.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelOpenPOTab_OpenPO.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelOpenPOTab_OpenPO.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelOpenPOTab_OpenPO.Style.GradientAngle = 90
            Me.TabControlPanelOpenPOTab_OpenPO.TabIndex = 6
            Me.TabControlPanelOpenPOTab_OpenPO.TabItem = Me.TabItemFunctionItems_OpenPO
            '
            'DataGridViewOpenPO_Details
            '
            Me.DataGridViewOpenPO_Details.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewOpenPO_Details.AllowDragAndDrop = False
            Me.DataGridViewOpenPO_Details.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewOpenPO_Details.AllowSelectGroupHeaderRow = True
            Me.DataGridViewOpenPO_Details.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewOpenPO_Details.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewOpenPO_Details.AutoFilterLookupColumns = False
            Me.DataGridViewOpenPO_Details.AutoloadRepositoryDatasource = True
            Me.DataGridViewOpenPO_Details.AutoUpdateViewCaption = True
            Me.DataGridViewOpenPO_Details.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewOpenPO_Details.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewOpenPO_Details.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewOpenPO_Details.ItemDescription = ""
            Me.DataGridViewOpenPO_Details.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewOpenPO_Details.MultiSelect = True
            Me.DataGridViewOpenPO_Details.Name = "DataGridViewOpenPO_Details"
            Me.DataGridViewOpenPO_Details.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewOpenPO_Details.RunStandardValidation = True
            Me.DataGridViewOpenPO_Details.ShowColumnMenuOnRightClick = False
            Me.DataGridViewOpenPO_Details.ShowSelectDeselectAllButtons = False
            Me.DataGridViewOpenPO_Details.Size = New System.Drawing.Size(981, 278)
            Me.DataGridViewOpenPO_Details.TabIndex = 4
            Me.DataGridViewOpenPO_Details.UseEmbeddedNavigator = False
            Me.DataGridViewOpenPO_Details.ViewCaptionHeight = -1
            '
            'TabItemFunctionItems_OpenPO
            '
            Me.TabItemFunctionItems_OpenPO.AttachedControl = Me.TabControlPanelOpenPOTab_OpenPO
            Me.TabItemFunctionItems_OpenPO.Name = "TabItemFunctionItems_OpenPO"
            Me.TabItemFunctionItems_OpenPO.Text = "Open PO"
            '
            'TabControlPanelAdvanceBillingTab_AdvanceBilling
            '
            Me.TabControlPanelAdvanceBillingTab_AdvanceBilling.Controls.Add(Me.DataGridViewAdvanceBilling_Details)
            Me.TabControlPanelAdvanceBillingTab_AdvanceBilling.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelAdvanceBillingTab_AdvanceBilling.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelAdvanceBillingTab_AdvanceBilling.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelAdvanceBillingTab_AdvanceBilling.Name = "TabControlPanelAdvanceBillingTab_AdvanceBilling"
            Me.TabControlPanelAdvanceBillingTab_AdvanceBilling.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelAdvanceBillingTab_AdvanceBilling.Size = New System.Drawing.Size(989, 278)
            Me.TabControlPanelAdvanceBillingTab_AdvanceBilling.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelAdvanceBillingTab_AdvanceBilling.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelAdvanceBillingTab_AdvanceBilling.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelAdvanceBillingTab_AdvanceBilling.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelAdvanceBillingTab_AdvanceBilling.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelAdvanceBillingTab_AdvanceBilling.Style.GradientAngle = 90
            Me.TabControlPanelAdvanceBillingTab_AdvanceBilling.TabIndex = 4
            Me.TabControlPanelAdvanceBillingTab_AdvanceBilling.TabItem = Me.TabItemFunctionItems_AdvanceBilling
            '
            'DataGridViewAdvanceBilling_Details
            '
            Me.DataGridViewAdvanceBilling_Details.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewAdvanceBilling_Details.AllowDragAndDrop = False
            Me.DataGridViewAdvanceBilling_Details.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewAdvanceBilling_Details.AllowSelectGroupHeaderRow = True
            Me.DataGridViewAdvanceBilling_Details.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewAdvanceBilling_Details.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewAdvanceBilling_Details.AutoFilterLookupColumns = False
            Me.DataGridViewAdvanceBilling_Details.AutoloadRepositoryDatasource = True
            Me.DataGridViewAdvanceBilling_Details.AutoUpdateViewCaption = True
            Me.DataGridViewAdvanceBilling_Details.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewAdvanceBilling_Details.DataSource = Nothing
            Me.DataGridViewAdvanceBilling_Details.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewAdvanceBilling_Details.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewAdvanceBilling_Details.ItemDescription = ""
            Me.DataGridViewAdvanceBilling_Details.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewAdvanceBilling_Details.MultiSelect = True
            Me.DataGridViewAdvanceBilling_Details.Name = "DataGridViewAdvanceBilling_Details"
            Me.DataGridViewAdvanceBilling_Details.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewAdvanceBilling_Details.RunStandardValidation = True
            Me.DataGridViewAdvanceBilling_Details.ShowColumnMenuOnRightClick = False
            Me.DataGridViewAdvanceBilling_Details.ShowSelectDeselectAllButtons = False
            Me.DataGridViewAdvanceBilling_Details.Size = New System.Drawing.Size(981, 278)
            Me.DataGridViewAdvanceBilling_Details.TabIndex = 3
            Me.DataGridViewAdvanceBilling_Details.UseEmbeddedNavigator = False
            Me.DataGridViewAdvanceBilling_Details.ViewCaptionHeight = -1
            '
            'TabItemFunctionItems_AdvanceBilling
            '
            Me.TabItemFunctionItems_AdvanceBilling.AttachedControl = Me.TabControlPanelAdvanceBillingTab_AdvanceBilling
            Me.TabItemFunctionItems_AdvanceBilling.Name = "TabItemFunctionItems_AdvanceBilling"
            Me.TabItemFunctionItems_AdvanceBilling.Text = "Advance Billing"
            '
            'TabControlPanelDocumentsTab_Documents
            '
            Me.TabControlPanelDocumentsTab_Documents.Controls.Add(Me.DocumentManagerControlDocuments_Documents)
            Me.TabControlPanelDocumentsTab_Documents.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelDocumentsTab_Documents.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelDocumentsTab_Documents.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelDocumentsTab_Documents.Name = "TabControlPanelDocumentsTab_Documents"
            Me.TabControlPanelDocumentsTab_Documents.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelDocumentsTab_Documents.Size = New System.Drawing.Size(989, 278)
            Me.TabControlPanelDocumentsTab_Documents.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelDocumentsTab_Documents.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDocumentsTab_Documents.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelDocumentsTab_Documents.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelDocumentsTab_Documents.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelDocumentsTab_Documents.Style.GradientAngle = 90
            Me.TabControlPanelDocumentsTab_Documents.TabIndex = 5
            Me.TabControlPanelDocumentsTab_Documents.TabItem = Me.TabItemFunctionItems_Documents
            '
            'DocumentManagerControlDocuments_Documents
            '
            Me.DocumentManagerControlDocuments_Documents.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DocumentManagerControlDocuments_Documents.Location = New System.Drawing.Point(4, 4)
            Me.DocumentManagerControlDocuments_Documents.Name = "DocumentManagerControlDocuments_Documents"
            Me.DocumentManagerControlDocuments_Documents.Size = New System.Drawing.Size(981, 278)
            Me.DocumentManagerControlDocuments_Documents.TabIndex = 0
            '
            'TabItemFunctionItems_Documents
            '
            Me.TabItemFunctionItems_Documents.AttachedControl = Me.TabControlPanelDocumentsTab_Documents
            Me.TabItemFunctionItems_Documents.Name = "TabItemFunctionItems_Documents"
            Me.TabItemFunctionItems_Documents.Text = "Documents"
            '
            'TabControlPanelVendorTab_Vendor
            '
            Me.TabControlPanelVendorTab_Vendor.Controls.Add(Me.DataGridViewVendor_Details)
            Me.TabControlPanelVendorTab_Vendor.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelVendorTab_Vendor.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelVendorTab_Vendor.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelVendorTab_Vendor.Name = "TabControlPanelVendorTab_Vendor"
            Me.TabControlPanelVendorTab_Vendor.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelVendorTab_Vendor.Size = New System.Drawing.Size(989, 278)
            Me.TabControlPanelVendorTab_Vendor.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelVendorTab_Vendor.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelVendorTab_Vendor.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelVendorTab_Vendor.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelVendorTab_Vendor.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelVendorTab_Vendor.Style.GradientAngle = 90
            Me.TabControlPanelVendorTab_Vendor.TabIndex = 3
            Me.TabControlPanelVendorTab_Vendor.TabItem = Me.TabItemFunctionItems_Vendor
            '
            'DataGridViewVendor_Details
            '
            Me.DataGridViewVendor_Details.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewVendor_Details.AllowDragAndDrop = False
            Me.DataGridViewVendor_Details.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewVendor_Details.AllowSelectGroupHeaderRow = True
            Me.DataGridViewVendor_Details.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewVendor_Details.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewVendor_Details.AutoFilterLookupColumns = False
            Me.DataGridViewVendor_Details.AutoloadRepositoryDatasource = True
            Me.DataGridViewVendor_Details.AutoUpdateViewCaption = True
            Me.DataGridViewVendor_Details.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewVendor_Details.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewVendor_Details.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewVendor_Details.ItemDescription = "Item(s)"
            Me.DataGridViewVendor_Details.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewVendor_Details.MultiSelect = True
            Me.DataGridViewVendor_Details.Name = "DataGridViewVendor_Details"
            Me.DataGridViewVendor_Details.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewVendor_Details.RunStandardValidation = True
            Me.DataGridViewVendor_Details.ShowColumnMenuOnRightClick = False
            Me.DataGridViewVendor_Details.ShowSelectDeselectAllButtons = False
            Me.DataGridViewVendor_Details.Size = New System.Drawing.Size(981, 278)
            Me.DataGridViewVendor_Details.TabIndex = 2
            Me.DataGridViewVendor_Details.UseEmbeddedNavigator = False
            Me.DataGridViewVendor_Details.ViewCaptionHeight = -1
            '
            'TabItemFunctionItems_Vendor
            '
            Me.TabItemFunctionItems_Vendor.AttachedControl = Me.TabControlPanelVendorTab_Vendor
            Me.TabItemFunctionItems_Vendor.Name = "TabItemFunctionItems_Vendor"
            Me.TabItemFunctionItems_Vendor.Text = "Vendor"
            '
            'TabControlPanelIncomeOnlyTab_IncomeOnly
            '
            Me.TabControlPanelIncomeOnlyTab_IncomeOnly.Controls.Add(Me.DataGridViewIncomeOnly_Details)
            Me.TabControlPanelIncomeOnlyTab_IncomeOnly.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelIncomeOnlyTab_IncomeOnly.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelIncomeOnlyTab_IncomeOnly.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelIncomeOnlyTab_IncomeOnly.Name = "TabControlPanelIncomeOnlyTab_IncomeOnly"
            Me.TabControlPanelIncomeOnlyTab_IncomeOnly.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelIncomeOnlyTab_IncomeOnly.Size = New System.Drawing.Size(989, 278)
            Me.TabControlPanelIncomeOnlyTab_IncomeOnly.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelIncomeOnlyTab_IncomeOnly.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelIncomeOnlyTab_IncomeOnly.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelIncomeOnlyTab_IncomeOnly.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelIncomeOnlyTab_IncomeOnly.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelIncomeOnlyTab_IncomeOnly.Style.GradientAngle = 90
            Me.TabControlPanelIncomeOnlyTab_IncomeOnly.TabIndex = 2
            Me.TabControlPanelIncomeOnlyTab_IncomeOnly.TabItem = Me.TabItemFunctionItems_IncomeOnly
            '
            'DataGridViewIncomeOnly_Details
            '
            Me.DataGridViewIncomeOnly_Details.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewIncomeOnly_Details.AllowDragAndDrop = False
            Me.DataGridViewIncomeOnly_Details.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewIncomeOnly_Details.AllowSelectGroupHeaderRow = True
            Me.DataGridViewIncomeOnly_Details.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewIncomeOnly_Details.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewIncomeOnly_Details.AutoFilterLookupColumns = False
            Me.DataGridViewIncomeOnly_Details.AutoloadRepositoryDatasource = True
            Me.DataGridViewIncomeOnly_Details.AutoUpdateViewCaption = True
            Me.DataGridViewIncomeOnly_Details.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewIncomeOnly_Details.DataSource = Nothing
            Me.DataGridViewIncomeOnly_Details.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewIncomeOnly_Details.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewIncomeOnly_Details.ItemDescription = "Item(s)"
            Me.DataGridViewIncomeOnly_Details.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewIncomeOnly_Details.MultiSelect = True
            Me.DataGridViewIncomeOnly_Details.Name = "DataGridViewIncomeOnly_Details"
            Me.DataGridViewIncomeOnly_Details.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewIncomeOnly_Details.RunStandardValidation = True
            Me.DataGridViewIncomeOnly_Details.ShowColumnMenuOnRightClick = False
            Me.DataGridViewIncomeOnly_Details.ShowSelectDeselectAllButtons = False
            Me.DataGridViewIncomeOnly_Details.Size = New System.Drawing.Size(981, 278)
            Me.DataGridViewIncomeOnly_Details.TabIndex = 1
            Me.DataGridViewIncomeOnly_Details.UseEmbeddedNavigator = False
            Me.DataGridViewIncomeOnly_Details.ViewCaptionHeight = -1
            '
            'TabItemFunctionItems_IncomeOnly
            '
            Me.TabItemFunctionItems_IncomeOnly.AttachedControl = Me.TabControlPanelIncomeOnlyTab_IncomeOnly
            Me.TabItemFunctionItems_IncomeOnly.Name = "TabItemFunctionItems_IncomeOnly"
            Me.TabItemFunctionItems_IncomeOnly.Text = "Income Only"
            '
            'ExpandableSplitterControlRightSection_TopBottom
            '
            Me.ExpandableSplitterControlRightSection_TopBottom.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlRightSection_TopBottom.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlRightSection_TopBottom.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlRightSection_TopBottom.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControlRightSection_TopBottom.Cursor = System.Windows.Forms.Cursors.HSplit
            Me.ExpandableSplitterControlRightSection_TopBottom.Dock = System.Windows.Forms.DockStyle.Top
            Me.ExpandableSplitterControlRightSection_TopBottom.ExpandableControl = Me.PanelRightSection_Top
            Me.ExpandableSplitterControlRightSection_TopBottom.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlRightSection_TopBottom.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlRightSection_TopBottom.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlRightSection_TopBottom.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlRightSection_TopBottom.ForeColor = System.Drawing.Color.Black
            Me.ExpandableSplitterControlRightSection_TopBottom.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlRightSection_TopBottom.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlRightSection_TopBottom.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlRightSection_TopBottom.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlRightSection_TopBottom.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterControlRightSection_TopBottom.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterControlRightSection_TopBottom.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterControlRightSection_TopBottom.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterControlRightSection_TopBottom.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlRightSection_TopBottom.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlRightSection_TopBottom.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlRightSection_TopBottom.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlRightSection_TopBottom.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlRightSection_TopBottom.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlRightSection_TopBottom.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlRightSection_TopBottom.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlRightSection_TopBottom.Location = New System.Drawing.Point(2, 241)
            Me.ExpandableSplitterControlRightSection_TopBottom.Name = "ExpandableSplitterControlRightSection_TopBottom"
            Me.ExpandableSplitterControlRightSection_TopBottom.Size = New System.Drawing.Size(1005, 5)
            Me.ExpandableSplitterControlRightSection_TopBottom.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControlRightSection_TopBottom.TabIndex = 16
            Me.ExpandableSplitterControlRightSection_TopBottom.TabStop = False
            '
            'PanelRightSection_Top
            '
            Me.PanelRightSection_Top.Controls.Add(Me.DataGridViewTop_JobComponentFunctions)
            Me.PanelRightSection_Top.Dock = System.Windows.Forms.DockStyle.Top
            Me.PanelRightSection_Top.Location = New System.Drawing.Point(2, 2)
            Me.PanelRightSection_Top.Name = "PanelRightSection_Top"
            Me.PanelRightSection_Top.Size = New System.Drawing.Size(1005, 239)
            Me.PanelRightSection_Top.TabIndex = 14
            '
            'DataGridViewTop_JobComponentFunctions
            '
            Me.DataGridViewTop_JobComponentFunctions.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewTop_JobComponentFunctions.AllowDragAndDrop = False
            Me.DataGridViewTop_JobComponentFunctions.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewTop_JobComponentFunctions.AllowSelectGroupHeaderRow = True
            Me.DataGridViewTop_JobComponentFunctions.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewTop_JobComponentFunctions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewTop_JobComponentFunctions.AutoFilterLookupColumns = False
            Me.DataGridViewTop_JobComponentFunctions.AutoloadRepositoryDatasource = False
            Me.DataGridViewTop_JobComponentFunctions.AutoUpdateViewCaption = True
            Me.DataGridViewTop_JobComponentFunctions.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewTop_JobComponentFunctions.DataSource = Nothing
            Me.DataGridViewTop_JobComponentFunctions.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewTop_JobComponentFunctions.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewTop_JobComponentFunctions.ItemDescription = ""
            Me.DataGridViewTop_JobComponentFunctions.Location = New System.Drawing.Point(6, 10)
            Me.DataGridViewTop_JobComponentFunctions.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewTop_JobComponentFunctions.MultiSelect = True
            Me.DataGridViewTop_JobComponentFunctions.Name = "DataGridViewTop_JobComponentFunctions"
            Me.DataGridViewTop_JobComponentFunctions.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewTop_JobComponentFunctions.RunStandardValidation = True
            Me.DataGridViewTop_JobComponentFunctions.ShowColumnMenuOnRightClick = False
            Me.DataGridViewTop_JobComponentFunctions.ShowSelectDeselectAllButtons = False
            Me.DataGridViewTop_JobComponentFunctions.Size = New System.Drawing.Size(988, 222)
            Me.DataGridViewTop_JobComponentFunctions.TabIndex = 4
            Me.DataGridViewTop_JobComponentFunctions.UseEmbeddedNavigator = False
            Me.DataGridViewTop_JobComponentFunctions.ViewCaptionHeight = -1
            '
            'NumericInputControl_PercentOfQuote
            '
            Me.NumericInputControl_PercentOfQuote.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputControl_PercentOfQuote.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputControl_PercentOfQuote.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputControl_PercentOfQuote.EnterMoveNextControl = True
            Me.NumericInputControl_PercentOfQuote.Location = New System.Drawing.Point(70, 3)
            Me.NumericInputControl_PercentOfQuote.Name = "NumericInputControl_PercentOfQuote"
            Me.NumericInputControl_PercentOfQuote.Properties.AllowMouseWheel = False
            Me.NumericInputControl_PercentOfQuote.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputControl_PercentOfQuote.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputControl_PercentOfQuote.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputControl_PercentOfQuote.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputControl_PercentOfQuote.Properties.EditFormat.FormatString = "f"
            Me.NumericInputControl_PercentOfQuote.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputControl_PercentOfQuote.Properties.Mask.EditMask = "f"
            Me.NumericInputControl_PercentOfQuote.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputControl_PercentOfQuote.SecurityEnabled = True
            Me.NumericInputControl_PercentOfQuote.Size = New System.Drawing.Size(50, 20)
            Me.NumericInputControl_PercentOfQuote.TabIndex = 30
            Me.NumericInputControl_PercentOfQuote.TabStop = False
            '
            'RibbonBarOptions_IncomeMethod
            '
            Me.RibbonBarOptions_IncomeMethod.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_IncomeMethod.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_IncomeMethod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_IncomeMethod.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_IncomeMethod.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_IncomeMethod.DragDropSupport = True
            Me.RibbonBarOptions_IncomeMethod.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerIncomeMethod_Vertical})
            Me.RibbonBarOptions_IncomeMethod.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_IncomeMethod.Location = New System.Drawing.Point(930, 0)
            Me.RibbonBarOptions_IncomeMethod.Name = "RibbonBarOptions_IncomeMethod"
            Me.RibbonBarOptions_IncomeMethod.SecurityEnabled = True
            Me.RibbonBarOptions_IncomeMethod.Size = New System.Drawing.Size(45, 92)
            Me.RibbonBarOptions_IncomeMethod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_IncomeMethod.TabIndex = 9
            Me.RibbonBarOptions_IncomeMethod.Text = "Income Method"
            '
            '
            '
            Me.RibbonBarOptions_IncomeMethod.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_IncomeMethod.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_IncomeMethod.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ItemContainerIncomeMethod_Vertical
            '
            '
            '
            '
            Me.ItemContainerIncomeMethod_Vertical.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerIncomeMethod_Vertical.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerIncomeMethod_Vertical.Name = "ItemContainerIncomeMethod_Vertical"
            Me.ItemContainerIncomeMethod_Vertical.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemIncomeMethod_UponReconciliation, Me.ButtonItemIncomeMethod_InitialBilling})
            '
            '
            '
            Me.ItemContainerIncomeMethod_Vertical.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerIncomeMethod_Vertical.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemIncomeMethod_UponReconciliation
            '
            Me.ButtonItemIncomeMethod_UponReconciliation.AutoCheckOnClick = True
            Me.ButtonItemIncomeMethod_UponReconciliation.Name = "ButtonItemIncomeMethod_UponReconciliation"
            Me.ButtonItemIncomeMethod_UponReconciliation.OptionGroup = "IncomeMethod"
            Me.ButtonItemIncomeMethod_UponReconciliation.Text = "Upon Reconciliation"
            '
            'ButtonItemIncomeMethod_InitialBilling
            '
            Me.ButtonItemIncomeMethod_InitialBilling.AutoCheckOnClick = True
            Me.ButtonItemIncomeMethod_InitialBilling.BeginGroup = True
            Me.ButtonItemIncomeMethod_InitialBilling.Name = "ButtonItemIncomeMethod_InitialBilling"
            Me.ButtonItemIncomeMethod_InitialBilling.OptionGroup = "IncomeMethod"
            Me.ButtonItemIncomeMethod_InitialBilling.Text = "Initial Billing"
            '
            'RibbonBarOptions_BillMethod
            '
            Me.RibbonBarOptions_BillMethod.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_BillMethod.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_BillMethod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_BillMethod.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_BillMethod.Controls.Add(Me.NumericInputControl_PercentOfQuote)
            Me.RibbonBarOptions_BillMethod.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_BillMethod.DragDropSupport = True
            Me.RibbonBarOptions_BillMethod.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerBillMethod_Vertical})
            Me.RibbonBarOptions_BillMethod.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_BillMethod.Location = New System.Drawing.Point(975, 0)
            Me.RibbonBarOptions_BillMethod.Name = "RibbonBarOptions_BillMethod"
            Me.RibbonBarOptions_BillMethod.SecurityEnabled = True
            Me.RibbonBarOptions_BillMethod.Size = New System.Drawing.Size(140, 92)
            Me.RibbonBarOptions_BillMethod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_BillMethod.TabIndex = 10
            Me.RibbonBarOptions_BillMethod.Text = "Bill Method"
            '
            '
            '
            Me.RibbonBarOptions_BillMethod.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_BillMethod.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_BillMethod.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ItemContainerBillMethod_Vertical
            '
            '
            '
            '
            Me.ItemContainerBillMethod_Vertical.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerBillMethod_Vertical.BeginGroup = True
            Me.ItemContainerBillMethod_Vertical.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerBillMethod_Vertical.Name = "ItemContainerBillMethod_Vertical"
            Me.ItemContainerBillMethod_Vertical.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerBillMethod_HorizontalTop, Me.CheckBoxItemBillMethod_ExcludeNonBillableFunctions, Me.LabelItemBillMethod_AdvanceRequested, Me.LabelItemABVertical_MethodDescription})
            '
            '
            '
            Me.ItemContainerBillMethod_Vertical.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerBillMethod_Vertical.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ItemContainerBillMethod_HorizontalTop
            '
            '
            '
            '
            Me.ItemContainerBillMethod_HorizontalTop.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerBillMethod_HorizontalTop.FixedSize = New System.Drawing.Size(130, 0)
            Me.ItemContainerBillMethod_HorizontalTop.Name = "ItemContainerBillMethod_HorizontalTop"
            Me.ItemContainerBillMethod_HorizontalTop.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemBillMethod_PercentOfQuote, Me.ControlContainerItemBillMethod_PctQuote})
            '
            '
            '
            Me.ItemContainerBillMethod_HorizontalTop.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerBillMethod_HorizontalTop.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemBillMethod_PercentOfQuote
            '
            Me.LabelItemBillMethod_PercentOfQuote.Name = "LabelItemBillMethod_PercentOfQuote"
            Me.LabelItemBillMethod_PercentOfQuote.Text = " % of Quote:"
            '
            'ControlContainerItemBillMethod_PctQuote
            '
            Me.ControlContainerItemBillMethod_PctQuote.AllowItemResize = True
            Me.ControlContainerItemBillMethod_PctQuote.Control = Me.NumericInputControl_PercentOfQuote
            Me.ControlContainerItemBillMethod_PctQuote.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItemBillMethod_PctQuote.Name = "ControlContainerItemBillMethod_PctQuote"
            Me.ControlContainerItemBillMethod_PctQuote.Text = "ControlContainerItem1"
            '
            'CheckBoxItemBillMethod_ExcludeNonBillableFunctions
            '
            Me.CheckBoxItemBillMethod_ExcludeNonBillableFunctions.Name = "CheckBoxItemBillMethod_ExcludeNonBillableFunctions"
            Me.CheckBoxItemBillMethod_ExcludeNonBillableFunctions.Text = "Exclude NB Functions"
            Me.CheckBoxItemBillMethod_ExcludeNonBillableFunctions.Tooltip = "Exclude Non-Billable Functions"
            '
            'LabelItemBillMethod_AdvanceRequested
            '
            Me.LabelItemBillMethod_AdvanceRequested.Name = "LabelItemBillMethod_AdvanceRequested"
            Me.LabelItemBillMethod_AdvanceRequested.PaddingTop = 2
            Me.LabelItemBillMethod_AdvanceRequested.Text = "Advance Requested"
            Me.LabelItemBillMethod_AdvanceRequested.TextAlignment = System.Drawing.StringAlignment.Center
            '
            'LabelItemABVertical_MethodDescription
            '
            Me.LabelItemABVertical_MethodDescription.ForeColor = System.Drawing.Color.Red
            Me.LabelItemABVertical_MethodDescription.Name = "LabelItemABVertical_MethodDescription"
            Me.LabelItemABVertical_MethodDescription.PaddingTop = 2
            Me.LabelItemABVertical_MethodDescription.Text = "Reconciled to Actual"
            Me.LabelItemABVertical_MethodDescription.TextAlignment = System.Drawing.StringAlignment.Center
            '
            'RibbonBarOptions_PercentOfQuoteBilled
            '
            Me.RibbonBarOptions_PercentOfQuoteBilled.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_PercentOfQuoteBilled.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_PercentOfQuoteBilled.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_PercentOfQuoteBilled.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_PercentOfQuoteBilled.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_PercentOfQuoteBilled.DragDropSupport = True
            Me.RibbonBarOptions_PercentOfQuoteBilled.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemPctOfQuoteBilled_PCT})
            Me.RibbonBarOptions_PercentOfQuoteBilled.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_PercentOfQuoteBilled.Location = New System.Drawing.Point(1115, 0)
            Me.RibbonBarOptions_PercentOfQuoteBilled.Name = "RibbonBarOptions_PercentOfQuoteBilled"
            Me.RibbonBarOptions_PercentOfQuoteBilled.SecurityEnabled = True
            Me.RibbonBarOptions_PercentOfQuoteBilled.Size = New System.Drawing.Size(250, 92)
            Me.RibbonBarOptions_PercentOfQuoteBilled.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_PercentOfQuoteBilled.TabIndex = 11
            Me.RibbonBarOptions_PercentOfQuoteBilled.Text = "PCT of Quote Billed"
            '
            '
            '
            Me.RibbonBarOptions_PercentOfQuoteBilled.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_PercentOfQuoteBilled.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_PercentOfQuoteBilled.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'LabelItemPctOfQuoteBilled_PCT
            '
            Me.LabelItemPctOfQuoteBilled_PCT.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelItemPctOfQuoteBilled_PCT.ForeColor = System.Drawing.Color.Blue
            Me.LabelItemPctOfQuoteBilled_PCT.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center
            Me.LabelItemPctOfQuoteBilled_PCT.Name = "LabelItemPctOfQuoteBilled_PCT"
            Me.LabelItemPctOfQuoteBilled_PCT.Text = "  0%"
            '
            'RibbonBarOptions_Status
            '
            Me.RibbonBarOptions_Status.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Status.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Status.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Status.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Status.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Status.DragDropSupport = True
            Me.RibbonBarOptions_Status.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemStatus_Adjusted})
            Me.RibbonBarOptions_Status.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Status.Location = New System.Drawing.Point(202, 0)
            Me.RibbonBarOptions_Status.Name = "RibbonBarOptions_Status"
            Me.RibbonBarOptions_Status.SecurityEnabled = True
            Me.RibbonBarOptions_Status.Size = New System.Drawing.Size(77, 92)
            Me.RibbonBarOptions_Status.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Status.TabIndex = 2
            Me.RibbonBarOptions_Status.Text = "Status"
            '
            '
            '
            Me.RibbonBarOptions_Status.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Status.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Status.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemStatus_Adjusted
            '
            Me.ButtonItemStatus_Adjusted.AutoCheckOnClick = True
            Me.ButtonItemStatus_Adjusted.BeginGroup = True
            Me.ButtonItemStatus_Adjusted.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemStatus_Adjusted.Name = "ButtonItemStatus_Adjusted"
            Me.ButtonItemStatus_Adjusted.RibbonWordWrap = False
            Me.ButtonItemStatus_Adjusted.SecurityEnabled = True
            Me.ButtonItemStatus_Adjusted.SubItemsExpandWidth = 14
            Me.ButtonItemStatus_Adjusted.Text = "Adjusted"
            '
            'RibbonBarOptions_ReconcileFunctions
            '
            Me.RibbonBarOptions_ReconcileFunctions.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_ReconcileFunctions.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_ReconcileFunctions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_ReconcileFunctions.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_ReconcileFunctions.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_ReconcileFunctions.DragDropSupport = True
            Me.RibbonBarOptions_ReconcileFunctions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerVertical_ReconcileFunctions})
            Me.RibbonBarOptions_ReconcileFunctions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_ReconcileFunctions.Location = New System.Drawing.Point(1508, 0)
            Me.RibbonBarOptions_ReconcileFunctions.Name = "RibbonBarOptions_ReconcileFunctions"
            Me.RibbonBarOptions_ReconcileFunctions.SecurityEnabled = True
            Me.RibbonBarOptions_ReconcileFunctions.Size = New System.Drawing.Size(45, 92)
            Me.RibbonBarOptions_ReconcileFunctions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_ReconcileFunctions.TabIndex = 14
            Me.RibbonBarOptions_ReconcileFunctions.Text = "Functions"
            '
            '
            '
            Me.RibbonBarOptions_ReconcileFunctions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_ReconcileFunctions.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_ReconcileFunctions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ItemContainerVertical_ReconcileFunctions
            '
            '
            '
            '
            Me.ItemContainerVertical_ReconcileFunctions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerVertical_ReconcileFunctions.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerVertical_ReconcileFunctions.Name = "ItemContainerVertical_ReconcileFunctions"
            Me.ItemContainerVertical_ReconcileFunctions.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemReconcileFunctions_CheckSelected, Me.ButtonItemReconcileFunctions_UncheckSelected})
            '
            '
            '
            Me.ItemContainerVertical_ReconcileFunctions.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerVertical_ReconcileFunctions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemReconcileFunctions_CheckSelected
            '
            Me.ButtonItemReconcileFunctions_CheckSelected.Name = "ButtonItemReconcileFunctions_CheckSelected"
            Me.ButtonItemReconcileFunctions_CheckSelected.Text = "Check Selected"
            '
            'ButtonItemReconcileFunctions_UncheckSelected
            '
            Me.ButtonItemReconcileFunctions_UncheckSelected.Name = "ButtonItemReconcileFunctions_UncheckSelected"
            Me.ButtonItemReconcileFunctions_UncheckSelected.Text = "Uncheck Selected"
            '
            'RibbonBarOptions_ReconcileEmployeeTime
            '
            Me.RibbonBarOptions_ReconcileEmployeeTime.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_ReconcileEmployeeTime.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_ReconcileEmployeeTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_ReconcileEmployeeTime.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_ReconcileEmployeeTime.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_ReconcileEmployeeTime.DragDropSupport = True
            Me.RibbonBarOptions_ReconcileEmployeeTime.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerVertical_ReconcileEmployeeTime})
            Me.RibbonBarOptions_ReconcileEmployeeTime.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_ReconcileEmployeeTime.Location = New System.Drawing.Point(1553, 0)
            Me.RibbonBarOptions_ReconcileEmployeeTime.Name = "RibbonBarOptions_ReconcileEmployeeTime"
            Me.RibbonBarOptions_ReconcileEmployeeTime.SecurityEnabled = True
            Me.RibbonBarOptions_ReconcileEmployeeTime.Size = New System.Drawing.Size(57, 92)
            Me.RibbonBarOptions_ReconcileEmployeeTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_ReconcileEmployeeTime.TabIndex = 15
            Me.RibbonBarOptions_ReconcileEmployeeTime.Text = "Employee Time"
            '
            '
            '
            Me.RibbonBarOptions_ReconcileEmployeeTime.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_ReconcileEmployeeTime.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_ReconcileEmployeeTime.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ItemContainerVertical_ReconcileEmployeeTime
            '
            '
            '
            '
            Me.ItemContainerVertical_ReconcileEmployeeTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerVertical_ReconcileEmployeeTime.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerVertical_ReconcileEmployeeTime.Name = "ItemContainerVertical_ReconcileEmployeeTime"
            Me.ItemContainerVertical_ReconcileEmployeeTime.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemReconcileEmployeeTime_CheckSelected, Me.ButtonItemReconcileEmployeeTime_UncheckSelected})
            '
            '
            '
            Me.ItemContainerVertical_ReconcileEmployeeTime.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerVertical_ReconcileEmployeeTime.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemReconcileEmployeeTime_CheckSelected
            '
            Me.ButtonItemReconcileEmployeeTime_CheckSelected.Name = "ButtonItemReconcileEmployeeTime_CheckSelected"
            Me.ButtonItemReconcileEmployeeTime_CheckSelected.Text = "Check Selected"
            '
            'ButtonItemReconcileEmployeeTime_UncheckSelected
            '
            Me.ButtonItemReconcileEmployeeTime_UncheckSelected.Name = "ButtonItemReconcileEmployeeTime_UncheckSelected"
            Me.ButtonItemReconcileEmployeeTime_UncheckSelected.Text = "Uncheck Selected"
            '
            'RibbonBarOptions_ReconcileIncomeOnly
            '
            Me.RibbonBarOptions_ReconcileIncomeOnly.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_ReconcileIncomeOnly.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_ReconcileIncomeOnly.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_ReconcileIncomeOnly.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_ReconcileIncomeOnly.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_ReconcileIncomeOnly.DragDropSupport = True
            Me.RibbonBarOptions_ReconcileIncomeOnly.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerVertical_ReconcileIncomeOnly})
            Me.RibbonBarOptions_ReconcileIncomeOnly.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_ReconcileIncomeOnly.Location = New System.Drawing.Point(1610, 0)
            Me.RibbonBarOptions_ReconcileIncomeOnly.Name = "RibbonBarOptions_ReconcileIncomeOnly"
            Me.RibbonBarOptions_ReconcileIncomeOnly.SecurityEnabled = True
            Me.RibbonBarOptions_ReconcileIncomeOnly.Size = New System.Drawing.Size(57, 92)
            Me.RibbonBarOptions_ReconcileIncomeOnly.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_ReconcileIncomeOnly.TabIndex = 16
            Me.RibbonBarOptions_ReconcileIncomeOnly.Text = "Income Only"
            '
            '
            '
            Me.RibbonBarOptions_ReconcileIncomeOnly.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_ReconcileIncomeOnly.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_ReconcileIncomeOnly.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ItemContainerVertical_ReconcileIncomeOnly
            '
            '
            '
            '
            Me.ItemContainerVertical_ReconcileIncomeOnly.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerVertical_ReconcileIncomeOnly.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerVertical_ReconcileIncomeOnly.Name = "ItemContainerVertical_ReconcileIncomeOnly"
            Me.ItemContainerVertical_ReconcileIncomeOnly.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemReconcileIncomeOnly_CheckSelected, Me.ButtonItemReconcileIncomeOnly_UncheckSelected})
            '
            '
            '
            Me.ItemContainerVertical_ReconcileIncomeOnly.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerVertical_ReconcileIncomeOnly.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemReconcileIncomeOnly_CheckSelected
            '
            Me.ButtonItemReconcileIncomeOnly_CheckSelected.Name = "ButtonItemReconcileIncomeOnly_CheckSelected"
            Me.ButtonItemReconcileIncomeOnly_CheckSelected.Text = "Check Selected"
            '
            'ButtonItemReconcileIncomeOnly_UncheckSelected
            '
            Me.ButtonItemReconcileIncomeOnly_UncheckSelected.Name = "ButtonItemReconcileIncomeOnly_UncheckSelected"
            Me.ButtonItemReconcileIncomeOnly_UncheckSelected.Text = "Uncheck Selected"
            '
            'RibbonBarOptions_ReconcileVendor
            '
            Me.RibbonBarOptions_ReconcileVendor.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_ReconcileVendor.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_ReconcileVendor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_ReconcileVendor.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_ReconcileVendor.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_ReconcileVendor.DragDropSupport = True
            Me.RibbonBarOptions_ReconcileVendor.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerVertical_ReconcileVendor})
            Me.RibbonBarOptions_ReconcileVendor.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_ReconcileVendor.Location = New System.Drawing.Point(1667, 0)
            Me.RibbonBarOptions_ReconcileVendor.Name = "RibbonBarOptions_ReconcileVendor"
            Me.RibbonBarOptions_ReconcileVendor.SecurityEnabled = True
            Me.RibbonBarOptions_ReconcileVendor.Size = New System.Drawing.Size(24, 92)
            Me.RibbonBarOptions_ReconcileVendor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_ReconcileVendor.TabIndex = 17
            Me.RibbonBarOptions_ReconcileVendor.Text = "Vendor"
            '
            '
            '
            Me.RibbonBarOptions_ReconcileVendor.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_ReconcileVendor.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_ReconcileVendor.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ItemContainerVertical_ReconcileVendor
            '
            '
            '
            '
            Me.ItemContainerVertical_ReconcileVendor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerVertical_ReconcileVendor.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerVertical_ReconcileVendor.Name = "ItemContainerVertical_ReconcileVendor"
            Me.ItemContainerVertical_ReconcileVendor.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemReconcileVendor_CheckSelected, Me.ButtonItemReconcileVendor_UncheckSelected})
            '
            '
            '
            Me.ItemContainerVertical_ReconcileVendor.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerVertical_ReconcileVendor.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemReconcileVendor_CheckSelected
            '
            Me.ButtonItemReconcileVendor_CheckSelected.Name = "ButtonItemReconcileVendor_CheckSelected"
            Me.ButtonItemReconcileVendor_CheckSelected.Text = "Check Selected"
            '
            'ButtonItemReconcileVendor_UncheckSelected
            '
            Me.ButtonItemReconcileVendor_UncheckSelected.Name = "ButtonItemReconcileVendor_UncheckSelected"
            Me.ButtonItemReconcileVendor_UncheckSelected.Text = "Uncheck Selected"
            '
            'RibbonBarOptions_IncomeRecognition
            '
            Me.RibbonBarOptions_IncomeRecognition.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_IncomeRecognition.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_IncomeRecognition.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_IncomeRecognition.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_IncomeRecognition.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_IncomeRecognition.DragDropSupport = True
            Me.RibbonBarOptions_IncomeRecognition.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemIncomeRecognition_Create})
            Me.RibbonBarOptions_IncomeRecognition.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_IncomeRecognition.Location = New System.Drawing.Point(1455, 0)
            Me.RibbonBarOptions_IncomeRecognition.Name = "RibbonBarOptions_IncomeRecognition"
            Me.RibbonBarOptions_IncomeRecognition.SecurityEnabled = True
            Me.RibbonBarOptions_IncomeRecognition.Size = New System.Drawing.Size(53, 92)
            Me.RibbonBarOptions_IncomeRecognition.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_IncomeRecognition.TabIndex = 18
            Me.RibbonBarOptions_IncomeRecognition.Text = "Income Recognition"
            '
            '
            '
            Me.RibbonBarOptions_IncomeRecognition.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_IncomeRecognition.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_IncomeRecognition.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemIncomeRecognition_Create
            '
            Me.ButtonItemIncomeRecognition_Create.AutoExpandOnClick = True
            Me.ButtonItemIncomeRecognition_Create.BeginGroup = True
            Me.ButtonItemIncomeRecognition_Create.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemIncomeRecognition_Create.Name = "ButtonItemIncomeRecognition_Create"
            Me.ButtonItemIncomeRecognition_Create.RibbonWordWrap = False
            Me.ButtonItemIncomeRecognition_Create.SecurityEnabled = True
            Me.ButtonItemIncomeRecognition_Create.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemIncomeRecognition_CreateByPercentCompleteTime, Me.ButtonItemIncomeRecognition_CreateByPercentCompleteAll})
            Me.ButtonItemIncomeRecognition_Create.SubItemsExpandWidth = 14
            Me.ButtonItemIncomeRecognition_Create.Text = "Create Income Recognition"
            '
            'ButtonItemIncomeRecognition_CreateByPercentCompleteTime
            '
            Me.ButtonItemIncomeRecognition_CreateByPercentCompleteTime.Name = "ButtonItemIncomeRecognition_CreateByPercentCompleteTime"
            Me.ButtonItemIncomeRecognition_CreateByPercentCompleteTime.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemPercentCompleteTime_ByJob, Me.ButtonItemPercentCompleteTime_ByJobFunction})
            Me.ButtonItemIncomeRecognition_CreateByPercentCompleteTime.Text = "Percent Complete Time"
            '
            'ButtonItemPercentCompleteTime_ByJob
            '
            Me.ButtonItemPercentCompleteTime_ByJob.Name = "ButtonItemPercentCompleteTime_ByJob"
            Me.ButtonItemPercentCompleteTime_ByJob.Text = "By Job"
            '
            'ButtonItemPercentCompleteTime_ByJobFunction
            '
            Me.ButtonItemPercentCompleteTime_ByJobFunction.Name = "ButtonItemPercentCompleteTime_ByJobFunction"
            Me.ButtonItemPercentCompleteTime_ByJobFunction.Text = "By Job/Function"
            '
            'ButtonItemIncomeRecognition_CreateByPercentCompleteAll
            '
            Me.ButtonItemIncomeRecognition_CreateByPercentCompleteAll.Name = "ButtonItemIncomeRecognition_CreateByPercentCompleteAll"
            Me.ButtonItemIncomeRecognition_CreateByPercentCompleteAll.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemPercentCompleteAll_ByJob, Me.ButtonItemPercentCompleteAll_ByJobFunction})
            Me.ButtonItemIncomeRecognition_CreateByPercentCompleteAll.Text = "Percent Complete All"
            '
            'ButtonItemPercentCompleteAll_ByJob
            '
            Me.ButtonItemPercentCompleteAll_ByJob.Name = "ButtonItemPercentCompleteAll_ByJob"
            Me.ButtonItemPercentCompleteAll_ByJob.Text = "By Job"
            '
            'ButtonItemPercentCompleteAll_ByJobFunction
            '
            Me.ButtonItemPercentCompleteAll_ByJobFunction.Name = "ButtonItemPercentCompleteAll_ByJobFunction"
            Me.ButtonItemPercentCompleteAll_ByJobFunction.Text = "By Job/Function"
            '
            'RibbonBarOptions_OpenPO
            '
            Me.RibbonBarOptions_OpenPO.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_OpenPO.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_OpenPO.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_OpenPO.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_OpenPO.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_OpenPO.DragDropSupport = True
            Me.RibbonBarOptions_OpenPO.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemOpenPO_ChooseColumns, Me.ButtonItemOpenPO_RestoreDefaults})
            Me.RibbonBarOptions_OpenPO.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_OpenPO.Location = New System.Drawing.Point(1691, 0)
            Me.RibbonBarOptions_OpenPO.Name = "RibbonBarOptions_OpenPO"
            Me.RibbonBarOptions_OpenPO.SecurityEnabled = True
            Me.RibbonBarOptions_OpenPO.Size = New System.Drawing.Size(118, 92)
            Me.RibbonBarOptions_OpenPO.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_OpenPO.TabIndex = 19
            Me.RibbonBarOptions_OpenPO.Text = "Open PO"
            '
            '
            '
            Me.RibbonBarOptions_OpenPO.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_OpenPO.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_OpenPO.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemOpenPO_ChooseColumns
            '
            Me.ButtonItemOpenPO_ChooseColumns.AutoCheckOnClick = True
            Me.ButtonItemOpenPO_ChooseColumns.BeginGroup = True
            Me.ButtonItemOpenPO_ChooseColumns.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemOpenPO_ChooseColumns.Name = "ButtonItemOpenPO_ChooseColumns"
            Me.ButtonItemOpenPO_ChooseColumns.RibbonWordWrap = False
            Me.ButtonItemOpenPO_ChooseColumns.SecurityEnabled = True
            Me.ButtonItemOpenPO_ChooseColumns.SubItemsExpandWidth = 14
            Me.ButtonItemOpenPO_ChooseColumns.Text = "Choose Columns"
            '
            'ButtonItemOpenPO_RestoreDefaults
            '
            Me.ButtonItemOpenPO_RestoreDefaults.BeginGroup = True
            Me.ButtonItemOpenPO_RestoreDefaults.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemOpenPO_RestoreDefaults.Name = "ButtonItemOpenPO_RestoreDefaults"
            Me.ButtonItemOpenPO_RestoreDefaults.RibbonWordWrap = False
            Me.ButtonItemOpenPO_RestoreDefaults.SecurityEnabled = True
            Me.ButtonItemOpenPO_RestoreDefaults.SubItemsExpandWidth = 14
            Me.ButtonItemOpenPO_RestoreDefaults.Text = "Restore Defaults"
            '
            'BillingCommandCenterJobDetailDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(1179, 730)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "BillingCommandCenterJobDetailDialog"
            Me.Text = "Billing Command Center Job Details"
            Me.Controls.SetChildIndex(Me.BarForm_StatusBar, 0)
            Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
            Me.Controls.SetChildIndex(Me.PanelForm_Form, 0)
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Form.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.PerformLayout()
            Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_LeftSection.ResumeLayout(False)
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_RightSection.ResumeLayout(False)
            CType(Me.PanelRightSection_Bottom, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelRightSection_Bottom.ResumeLayout(False)
            CType(Me.TabControlRightSection_FunctionItems, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlRightSection_FunctionItems.ResumeLayout(False)
            Me.TabControlPanelEmployeeTimeTab_EmployeeTime.ResumeLayout(False)
            Me.TabControlPanelOpenPOTab_OpenPO.ResumeLayout(False)
            Me.TabControlPanelAdvanceBillingTab_AdvanceBilling.ResumeLayout(False)
            Me.TabControlPanelDocumentsTab_Documents.ResumeLayout(False)
            Me.TabControlPanelVendorTab_Vendor.ResumeLayout(False)
            Me.TabControlPanelIncomeOnlyTab_IncomeOnly.ResumeLayout(False)
            CType(Me.PanelRightSection_Top, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelRightSection_Top.ResumeLayout(False)
            CType(Me.NumericInputControl_PercentOfQuote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.RibbonBarOptions_BillMethod.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarOptions_AdvanceBilling As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemAdvanceBilling_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemAdvanceBilling_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Save As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Documents As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemDocuments_Download As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDocuments_OpenURL As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Vendor As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemVendor_MarkupDown As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemVendorMarkupDown_Markdown100 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemVendorMarkupDown_SetPercent As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemVendor_BillHold As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemVendorBillHold_Temporary As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemVendorBillHold_Permanent As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemVendorBillHold_RemoveAll As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemVendor_Transfer As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_IncomeOnly As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemIncomeOnly_UpdateRate As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemIOUpdateRate_FromHierarchy As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemIOUpdateRate_SetRate As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemIncomeOnly_BillHold As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemIOBillHold_Temporary As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemIOBillHold_Permanent As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemIOBillHold_RemoveAll As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemIncomeOnly_Transfer As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_EmployeeTime As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemEmployeeTime_MarkBillable As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemEmployeeTime_MarkNonBillable As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemEmployeeTime_FeeTime As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemFeeTime_No As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemFeeTime_TimeAgainstFee As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemFeeTime_TimeAgainstCommissionP As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemFeeTime_TimeAgainstCommissionM As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemEmployeeTime_UpdateRate As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemETUpdateRate_FromHierarchy As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemETUpdateRate_SetRate As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemEmployeeTime_MarkupDown As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemETMarkupDown_Markdown100 As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemETMarkupDown_SetPercent As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemEmployeeTime_BillHold As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemETBillHold_Temporary As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemETBillHold_Permanent As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemETBillHold_RemoveAll As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemEmployeeTime_Transfer As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Include As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemInclude_Contingency As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_FunctionGrid As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemFunctionGrid_ChooseColumns As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemFunctionGrid_RestoreDefaults As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemFunctionGrid_SelectAll As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents PanelForm_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Private WithEvents DataGridViewLeftSection_Jobs As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Private WithEvents ExpandableSplitterControlForm_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Private WithEvents PanelForm_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Private WithEvents PanelRightSection_Top As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewTop_JobComponentFunctions As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Private WithEvents ExpandableSplitterControlRightSection_TopBottom As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Private WithEvents PanelRightSection_Bottom As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents TabControlRightSection_FunctionItems As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelEmployeeTimeTab_EmployeeTime As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewEmployeeTime_Details As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TabItemFunctionItems_EmployeeTime As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelIncomeOnlyTab_IncomeOnly As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewIncomeOnly_Details As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TabItemFunctionItems_IncomeOnly As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelVendorTab_Vendor As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewVendor_Details As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TabItemFunctionItems_Vendor As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelAdvanceBillingTab_AdvanceBilling As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemFunctionItems_AdvanceBilling As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelDocumentsTab_Documents As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemFunctionItems_Documents As DevComponents.DotNetBar.TabItem
        Friend WithEvents DataGridViewAdvanceBilling_Details As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents DocumentManagerControlDocuments_Documents As AdvantageFramework.WinForm.Presentation.Controls.DocumentManagerControl
        Friend WithEvents ButtonItemAdvanceBilling_Create As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemAdvanceBilling_CreateAll As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemAdvanceBilling_CreateSelected As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemAdvanceBilling_CreateActuals As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_BillMethod As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents RibbonBarOptions_IncomeMethod As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ItemContainerIncomeMethod_Vertical As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemIncomeMethod_UponReconciliation As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemIncomeMethod_InitialBilling As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_PercentOfQuoteBilled As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents LabelItemPctOfQuoteBilled_PCT As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ItemContainerBillMethod_Vertical As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ItemContainerBillMethod_HorizontalTop As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ControlContainerItemBillMethod_PctQuote As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents NumericInputControl_PercentOfQuote As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents CheckBoxItemBillMethod_ExcludeNonBillableFunctions As DevComponents.DotNetBar.CheckBoxItem
        Friend WithEvents RibbonBarOptions_Status As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemStatus_Adjusted As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemAdvanceBilling_CreateActualsOpenPO As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemVendor_WriteOff As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemETMarkupDown_ToEstimateAmountForFunction As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemETMarkupDown_ToBilledAmountForFunction As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemETMarkupDown_ToApprovedAmountForFunction As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemETMarkupDown_ToApprovedAmountForItem As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemAdvanceBilling_CreateApproved As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents LabelItemBillMethod_PercentOfQuote As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ButtonItemEmployeeTime_HideNonBillable As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemVendor_HideNonBillable As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemIncomeOnly_HideNonBillable As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemVendor_ChooseColumns As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemVendor_RestoreDefaults As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemIncomeOnly_ChooseColumns As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemIncomeOnly_RestoreDefaults As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemEmployeeTime_ChooseColumns As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemEmployeeTime_RestoreDefaults As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_ReconcileEmployeeTime As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ItemContainerVertical_ReconcileEmployeeTime As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemReconcileEmployeeTime_CheckSelected As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemReconcileEmployeeTime_UncheckSelected As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_ReconcileFunctions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ItemContainerVertical_ReconcileFunctions As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemReconcileFunctions_CheckSelected As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemReconcileFunctions_UncheckSelected As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_ReconcileVendor As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ItemContainerVertical_ReconcileVendor As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemReconcileVendor_CheckSelected As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemReconcileVendor_UncheckSelected As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_ReconcileIncomeOnly As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ItemContainerVertical_ReconcileIncomeOnly As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemReconcileIncomeOnly_CheckSelected As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemReconcileIncomeOnly_UncheckSelected As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Refresh As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_IncomeRecognition As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemIncomeRecognition_Create As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemIncomeRecognition_CreateByPercentCompleteTime As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemIncomeRecognition_CreateByPercentCompleteAll As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemPercentCompleteTime_ByJob As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemPercentCompleteTime_ByJobFunction As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemPercentCompleteAll_ByJob As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemPercentCompleteAll_ByJobFunction As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents LabelItemABVertical_MethodDescription As DevComponents.DotNetBar.LabelItem
        Friend WithEvents RibbonBarOptions_OpenPO As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemOpenPO_ChooseColumns As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemOpenPO_RestoreDefaults As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents TabControlPanelOpenPOTab_OpenPO As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemFunctionItems_OpenPO As DevComponents.DotNetBar.TabItem
        Friend WithEvents DataGridViewOpenPO_Details As WinForm.Presentation.Controls.DataGridView
        Friend WithEvents LabelItemBillMethod_AdvanceRequested As DevComponents.DotNetBar.LabelItem
    End Class

End Namespace