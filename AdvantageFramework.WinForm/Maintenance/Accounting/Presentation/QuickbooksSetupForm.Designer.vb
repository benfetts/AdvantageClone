Namespace Maintenance.Accounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class QuickbooksSetupForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(QuickbooksSetupForm))
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Save = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Cancel = New DevComponents.DotNetBar.ButtonItem()
            Me.GroupBoxForm_InvoiceFunctionItemMapping = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.SearchableComboBoxMedia_Order = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox()
            Me.OrderView = New AdvantageFramework.WinForm.MVC.Presentation.Controls.GridView()
            Me.SearchableComboBoxFunction_IncomeOnly = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox()
            Me.IncomeOnlyView = New AdvantageFramework.WinForm.MVC.Presentation.Controls.GridView()
            Me.LabelMedia_Order = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.SearchableComboBoxFunction_ProductionVendorCost = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox()
            Me.ProductionVendorCostView = New AdvantageFramework.WinForm.MVC.Presentation.Controls.GridView()
            Me.LabelFunction_IncomeOnly = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelFunction_ProductionVendorCost = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.SearchableComboBoxFunction_EmployeeTime = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox()
            Me.EmployeeTimeView = New AdvantageFramework.WinForm.MVC.Presentation.Controls.GridView()
            Me.LabelFunction_EmployeeTime = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelForm_InvoiceSuffix = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.TextBoxForm_InvoiceSuffix = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox()
            Me.GroupBox_BillAccountMapping = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.SearchableComboBoxBill_Production = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox()
            Me.GridView3 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.GridView()
            Me.LabelBill_Production = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.SearchableComboBoxBill_NonClient = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox()
            Me.GridView2 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.GridView()
            Me.LabelBill_NonClient = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.SearchableComboBoxBill_Media = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox()
            Me.GridView1 = New AdvantageFramework.WinForm.MVC.Presentation.Controls.GridView()
            Me.LabelBill_Media = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.GroupBoxForm_InvoiceLineItemDescription = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.GroupBoxInvoiceMedia_Include = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.CheckBoxInvoiceMedia_IncludeOrderLineNumber = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.CheckBoxInvoiceMedia_IncludeOrderNumber = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.CheckBoxInvoiceMedia_IncludeSalesClass = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.GroupBoxInvoiceProduction_Include = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.CheckBoxInvoiceProduction_IncludeFunctionDescription = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.CheckBoxInvoiceProduction_IncludeComponentDescription = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.CheckBoxInvoiceProduction_IncludeJobDescription = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.CheckBoxInvoiceProduction_IncludeComponentNumber = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.CheckBoxInvoiceProduction_IncludeJobNumber = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.CheckBoxInvoiceProduction_IncludeSalesClass = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            CType(Me.GroupBoxForm_InvoiceFunctionItemMapping, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxForm_InvoiceFunctionItemMapping.SuspendLayout()
            CType(Me.SearchableComboBoxMedia_Order.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.OrderView, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxFunction_IncomeOnly.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.IncomeOnlyView, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxFunction_ProductionVendorCost.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ProductionVendorCostView, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxFunction_EmployeeTime.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.EmployeeTimeView, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBox_BillAccountMapping, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBox_BillAccountMapping.SuspendLayout()
            CType(Me.SearchableComboBoxBill_Production.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxBill_NonClient.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxBill_Media.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxForm_InvoiceLineItemDescription, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxForm_InvoiceLineItemDescription.SuspendLayout()
            CType(Me.GroupBoxInvoiceMedia_Include, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxInvoiceMedia_Include.SuspendLayout()
            CType(Me.GroupBoxInvoiceProduction_Include, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxInvoiceProduction_Include.SuspendLayout()
            Me.SuspendLayout()
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(228, 5)
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
            'GroupBoxForm_InvoiceFunctionItemMapping
            '
            Me.GroupBoxForm_InvoiceFunctionItemMapping.Controls.Add(Me.SearchableComboBoxMedia_Order)
            Me.GroupBoxForm_InvoiceFunctionItemMapping.Controls.Add(Me.SearchableComboBoxFunction_IncomeOnly)
            Me.GroupBoxForm_InvoiceFunctionItemMapping.Controls.Add(Me.LabelMedia_Order)
            Me.GroupBoxForm_InvoiceFunctionItemMapping.Controls.Add(Me.SearchableComboBoxFunction_ProductionVendorCost)
            Me.GroupBoxForm_InvoiceFunctionItemMapping.Controls.Add(Me.LabelFunction_IncomeOnly)
            Me.GroupBoxForm_InvoiceFunctionItemMapping.Controls.Add(Me.LabelFunction_ProductionVendorCost)
            Me.GroupBoxForm_InvoiceFunctionItemMapping.Controls.Add(Me.SearchableComboBoxFunction_EmployeeTime)
            Me.GroupBoxForm_InvoiceFunctionItemMapping.Controls.Add(Me.LabelFunction_EmployeeTime)
            Me.GroupBoxForm_InvoiceFunctionItemMapping.Location = New System.Drawing.Point(12, 12)
            Me.GroupBoxForm_InvoiceFunctionItemMapping.Name = "GroupBoxForm_InvoiceFunctionItemMapping"
            Me.GroupBoxForm_InvoiceFunctionItemMapping.Size = New System.Drawing.Size(499, 134)
            Me.GroupBoxForm_InvoiceFunctionItemMapping.TabIndex = 0
            Me.GroupBoxForm_InvoiceFunctionItemMapping.Text = "Client Invoice - Product / Service Mapping"
            '
            'SearchableComboBoxMedia_Order
            '
            Me.SearchableComboBoxMedia_Order.ActiveFilterString = ""
            Me.SearchableComboBoxMedia_Order.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxMedia_Order.AutoFillMode = False
            Me.SearchableComboBoxMedia_Order.BookmarkingEnabled = False
            Me.SearchableComboBoxMedia_Order.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.Type.[Default]
            Me.SearchableComboBoxMedia_Order.DataSource = Nothing
            Me.SearchableComboBoxMedia_Order.DisableMouseWheel = True
            Me.SearchableComboBoxMedia_Order.DisplayName = "Order Mapping"
            Me.SearchableComboBoxMedia_Order.EditValue = ""
            Me.SearchableComboBoxMedia_Order.EnterMoveNextControl = True
            Me.SearchableComboBoxMedia_Order.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxMedia_Order.Location = New System.Drawing.Point(138, 103)
            Me.SearchableComboBoxMedia_Order.Name = "SearchableComboBoxMedia_Order"
            Me.SearchableComboBoxMedia_Order.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxMedia_Order.Properties.NullText = ""
            Me.SearchableComboBoxMedia_Order.Properties.PopupView = Me.OrderView
            Me.SearchableComboBoxMedia_Order.Properties.ShowClearButton = False
            Me.SearchableComboBoxMedia_Order.SecurityEnabled = True
            Me.SearchableComboBoxMedia_Order.SelectedValue = ""
            Me.SearchableComboBoxMedia_Order.Size = New System.Drawing.Size(347, 20)
            Me.SearchableComboBoxMedia_Order.TabIndex = 7
            '
            'OrderView
            '
            Me.OrderView.AFActiveFilterString = ""
            Me.OrderView.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.OrderView.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.OrderView.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.OrderView.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.OrderView.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.OrderView.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.OrderView.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.OrderView.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.OrderView.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.OrderView.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.OrderView.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.OrderView.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.OrderView.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.OrderView.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.OrderView.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.OrderView.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.OrderView.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.OrderView.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.OrderView.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.OrderView.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.OrderView.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.OrderView.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.OrderView.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.OrderView.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.OrderView.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.OrderView.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.OrderView.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.OrderView.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.OrderView.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.OrderView.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.OrderView.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.OrderView.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.OrderView.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.OrderView.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.OrderView.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.OrderView.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.OrderView.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.OrderView.EnableDisabledRows = False
            Me.OrderView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.OrderView.ModifyColumnSettingsOnEachDataSource = True
            Me.OrderView.ModifyGridRowHeight = False
            Me.OrderView.Name = "OrderView"
            Me.OrderView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.OrderView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.OrderView.OptionsBehavior.Editable = False
            Me.OrderView.OptionsCustomization.AllowQuickHideColumns = False
            Me.OrderView.OptionsNavigation.AutoFocusNewRow = True
            Me.OrderView.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.OrderView.OptionsSelection.MultiSelect = True
            Me.OrderView.OptionsView.ColumnAutoWidth = False
            Me.OrderView.OptionsView.ShowGroupPanel = False
            Me.OrderView.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.OrderView.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.OrderView.SkipAddingControlsOnModifyColumn = False
            Me.OrderView.SkipSettingFontOnModifyColumn = False
            '
            'SearchableComboBoxFunction_IncomeOnly
            '
            Me.SearchableComboBoxFunction_IncomeOnly.ActiveFilterString = ""
            Me.SearchableComboBoxFunction_IncomeOnly.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxFunction_IncomeOnly.AutoFillMode = False
            Me.SearchableComboBoxFunction_IncomeOnly.BookmarkingEnabled = False
            Me.SearchableComboBoxFunction_IncomeOnly.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.Type.[Default]
            Me.SearchableComboBoxFunction_IncomeOnly.DataSource = Nothing
            Me.SearchableComboBoxFunction_IncomeOnly.DisableMouseWheel = True
            Me.SearchableComboBoxFunction_IncomeOnly.DisplayName = "Income Only Mapping"
            Me.SearchableComboBoxFunction_IncomeOnly.EditValue = ""
            Me.SearchableComboBoxFunction_IncomeOnly.EnterMoveNextControl = True
            Me.SearchableComboBoxFunction_IncomeOnly.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxFunction_IncomeOnly.Location = New System.Drawing.Point(138, 77)
            Me.SearchableComboBoxFunction_IncomeOnly.Name = "SearchableComboBoxFunction_IncomeOnly"
            Me.SearchableComboBoxFunction_IncomeOnly.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxFunction_IncomeOnly.Properties.NullText = ""
            Me.SearchableComboBoxFunction_IncomeOnly.Properties.PopupView = Me.IncomeOnlyView
            Me.SearchableComboBoxFunction_IncomeOnly.Properties.ShowClearButton = False
            Me.SearchableComboBoxFunction_IncomeOnly.SecurityEnabled = True
            Me.SearchableComboBoxFunction_IncomeOnly.SelectedValue = ""
            Me.SearchableComboBoxFunction_IncomeOnly.Size = New System.Drawing.Size(347, 20)
            Me.SearchableComboBoxFunction_IncomeOnly.TabIndex = 5
            '
            'IncomeOnlyView
            '
            Me.IncomeOnlyView.AFActiveFilterString = ""
            Me.IncomeOnlyView.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.IncomeOnlyView.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.IncomeOnlyView.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.IncomeOnlyView.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.IncomeOnlyView.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.IncomeOnlyView.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.IncomeOnlyView.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.IncomeOnlyView.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.IncomeOnlyView.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.IncomeOnlyView.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.IncomeOnlyView.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.IncomeOnlyView.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.IncomeOnlyView.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.IncomeOnlyView.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.IncomeOnlyView.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.IncomeOnlyView.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.IncomeOnlyView.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.IncomeOnlyView.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.IncomeOnlyView.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.IncomeOnlyView.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.IncomeOnlyView.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.IncomeOnlyView.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.IncomeOnlyView.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.IncomeOnlyView.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.IncomeOnlyView.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.IncomeOnlyView.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.IncomeOnlyView.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.IncomeOnlyView.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.IncomeOnlyView.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.IncomeOnlyView.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.IncomeOnlyView.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.IncomeOnlyView.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.IncomeOnlyView.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.IncomeOnlyView.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.IncomeOnlyView.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.IncomeOnlyView.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.IncomeOnlyView.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.IncomeOnlyView.EnableDisabledRows = False
            Me.IncomeOnlyView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.IncomeOnlyView.ModifyColumnSettingsOnEachDataSource = True
            Me.IncomeOnlyView.ModifyGridRowHeight = False
            Me.IncomeOnlyView.Name = "IncomeOnlyView"
            Me.IncomeOnlyView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.IncomeOnlyView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.IncomeOnlyView.OptionsBehavior.Editable = False
            Me.IncomeOnlyView.OptionsCustomization.AllowQuickHideColumns = False
            Me.IncomeOnlyView.OptionsNavigation.AutoFocusNewRow = True
            Me.IncomeOnlyView.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.IncomeOnlyView.OptionsSelection.MultiSelect = True
            Me.IncomeOnlyView.OptionsView.ColumnAutoWidth = False
            Me.IncomeOnlyView.OptionsView.ShowGroupPanel = False
            Me.IncomeOnlyView.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.IncomeOnlyView.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.IncomeOnlyView.SkipAddingControlsOnModifyColumn = False
            Me.IncomeOnlyView.SkipSettingFontOnModifyColumn = False
            '
            'LabelMedia_Order
            '
            Me.LabelMedia_Order.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelMedia_Order.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelMedia_Order.Location = New System.Drawing.Point(5, 102)
            Me.LabelMedia_Order.Name = "LabelMedia_Order"
            Me.LabelMedia_Order.Size = New System.Drawing.Size(127, 20)
            Me.LabelMedia_Order.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelMedia_Order.TabIndex = 6
            Me.LabelMedia_Order.Text = "Media:"
            '
            'SearchableComboBoxFunction_ProductionVendorCost
            '
            Me.SearchableComboBoxFunction_ProductionVendorCost.ActiveFilterString = ""
            Me.SearchableComboBoxFunction_ProductionVendorCost.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxFunction_ProductionVendorCost.AutoFillMode = False
            Me.SearchableComboBoxFunction_ProductionVendorCost.BookmarkingEnabled = False
            Me.SearchableComboBoxFunction_ProductionVendorCost.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.Type.[Default]
            Me.SearchableComboBoxFunction_ProductionVendorCost.DataSource = Nothing
            Me.SearchableComboBoxFunction_ProductionVendorCost.DisableMouseWheel = True
            Me.SearchableComboBoxFunction_ProductionVendorCost.DisplayName = "Production Vendor Cost Mapping"
            Me.SearchableComboBoxFunction_ProductionVendorCost.EditValue = ""
            Me.SearchableComboBoxFunction_ProductionVendorCost.EnterMoveNextControl = True
            Me.SearchableComboBoxFunction_ProductionVendorCost.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxFunction_ProductionVendorCost.Location = New System.Drawing.Point(138, 51)
            Me.SearchableComboBoxFunction_ProductionVendorCost.Name = "SearchableComboBoxFunction_ProductionVendorCost"
            Me.SearchableComboBoxFunction_ProductionVendorCost.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxFunction_ProductionVendorCost.Properties.NullText = ""
            Me.SearchableComboBoxFunction_ProductionVendorCost.Properties.PopupView = Me.ProductionVendorCostView
            Me.SearchableComboBoxFunction_ProductionVendorCost.Properties.ShowClearButton = False
            Me.SearchableComboBoxFunction_ProductionVendorCost.SecurityEnabled = True
            Me.SearchableComboBoxFunction_ProductionVendorCost.SelectedValue = ""
            Me.SearchableComboBoxFunction_ProductionVendorCost.Size = New System.Drawing.Size(347, 20)
            Me.SearchableComboBoxFunction_ProductionVendorCost.TabIndex = 3
            '
            'ProductionVendorCostView
            '
            Me.ProductionVendorCostView.AFActiveFilterString = ""
            Me.ProductionVendorCostView.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.ProductionVendorCostView.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.ProductionVendorCostView.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.ProductionVendorCostView.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.ProductionVendorCostView.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.ProductionVendorCostView.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.ProductionVendorCostView.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.ProductionVendorCostView.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.ProductionVendorCostView.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.ProductionVendorCostView.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.ProductionVendorCostView.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.ProductionVendorCostView.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.ProductionVendorCostView.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.ProductionVendorCostView.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.ProductionVendorCostView.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.ProductionVendorCostView.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.ProductionVendorCostView.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.ProductionVendorCostView.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.ProductionVendorCostView.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.ProductionVendorCostView.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.ProductionVendorCostView.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.ProductionVendorCostView.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.ProductionVendorCostView.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.ProductionVendorCostView.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.ProductionVendorCostView.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.ProductionVendorCostView.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.ProductionVendorCostView.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.ProductionVendorCostView.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.ProductionVendorCostView.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.ProductionVendorCostView.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.ProductionVendorCostView.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.ProductionVendorCostView.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.ProductionVendorCostView.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.ProductionVendorCostView.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.ProductionVendorCostView.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.ProductionVendorCostView.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.ProductionVendorCostView.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.ProductionVendorCostView.EnableDisabledRows = False
            Me.ProductionVendorCostView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.ProductionVendorCostView.ModifyColumnSettingsOnEachDataSource = True
            Me.ProductionVendorCostView.ModifyGridRowHeight = False
            Me.ProductionVendorCostView.Name = "ProductionVendorCostView"
            Me.ProductionVendorCostView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.ProductionVendorCostView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.ProductionVendorCostView.OptionsBehavior.Editable = False
            Me.ProductionVendorCostView.OptionsCustomization.AllowQuickHideColumns = False
            Me.ProductionVendorCostView.OptionsNavigation.AutoFocusNewRow = True
            Me.ProductionVendorCostView.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.ProductionVendorCostView.OptionsSelection.MultiSelect = True
            Me.ProductionVendorCostView.OptionsView.ColumnAutoWidth = False
            Me.ProductionVendorCostView.OptionsView.ShowGroupPanel = False
            Me.ProductionVendorCostView.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.ProductionVendorCostView.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.ProductionVendorCostView.SkipAddingControlsOnModifyColumn = False
            Me.ProductionVendorCostView.SkipSettingFontOnModifyColumn = False
            '
            'LabelFunction_IncomeOnly
            '
            Me.LabelFunction_IncomeOnly.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelFunction_IncomeOnly.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelFunction_IncomeOnly.Location = New System.Drawing.Point(5, 76)
            Me.LabelFunction_IncomeOnly.Name = "LabelFunction_IncomeOnly"
            Me.LabelFunction_IncomeOnly.Size = New System.Drawing.Size(127, 20)
            Me.LabelFunction_IncomeOnly.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelFunction_IncomeOnly.TabIndex = 4
            Me.LabelFunction_IncomeOnly.Text = "Income Only:"
            '
            'LabelFunction_ProductionVendorCost
            '
            Me.LabelFunction_ProductionVendorCost.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelFunction_ProductionVendorCost.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelFunction_ProductionVendorCost.Location = New System.Drawing.Point(5, 50)
            Me.LabelFunction_ProductionVendorCost.Name = "LabelFunction_ProductionVendorCost"
            Me.LabelFunction_ProductionVendorCost.Size = New System.Drawing.Size(127, 20)
            Me.LabelFunction_ProductionVendorCost.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelFunction_ProductionVendorCost.TabIndex = 2
            Me.LabelFunction_ProductionVendorCost.Text = "Production Vendor:"
            '
            'SearchableComboBoxFunction_EmployeeTime
            '
            Me.SearchableComboBoxFunction_EmployeeTime.ActiveFilterString = ""
            Me.SearchableComboBoxFunction_EmployeeTime.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxFunction_EmployeeTime.AutoFillMode = False
            Me.SearchableComboBoxFunction_EmployeeTime.BookmarkingEnabled = False
            Me.SearchableComboBoxFunction_EmployeeTime.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.Type.[Default]
            Me.SearchableComboBoxFunction_EmployeeTime.DataSource = Nothing
            Me.SearchableComboBoxFunction_EmployeeTime.DisableMouseWheel = True
            Me.SearchableComboBoxFunction_EmployeeTime.DisplayName = "Employee Time Mapping"
            Me.SearchableComboBoxFunction_EmployeeTime.EditValue = ""
            Me.SearchableComboBoxFunction_EmployeeTime.EnterMoveNextControl = True
            Me.SearchableComboBoxFunction_EmployeeTime.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxFunction_EmployeeTime.Location = New System.Drawing.Point(138, 24)
            Me.SearchableComboBoxFunction_EmployeeTime.Name = "SearchableComboBoxFunction_EmployeeTime"
            Me.SearchableComboBoxFunction_EmployeeTime.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxFunction_EmployeeTime.Properties.NullText = ""
            Me.SearchableComboBoxFunction_EmployeeTime.Properties.PopupView = Me.EmployeeTimeView
            Me.SearchableComboBoxFunction_EmployeeTime.Properties.ShowClearButton = False
            Me.SearchableComboBoxFunction_EmployeeTime.SecurityEnabled = True
            Me.SearchableComboBoxFunction_EmployeeTime.SelectedValue = ""
            Me.SearchableComboBoxFunction_EmployeeTime.Size = New System.Drawing.Size(347, 20)
            Me.SearchableComboBoxFunction_EmployeeTime.TabIndex = 1
            '
            'EmployeeTimeView
            '
            Me.EmployeeTimeView.AFActiveFilterString = ""
            Me.EmployeeTimeView.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.EmployeeTimeView.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.EmployeeTimeView.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.EmployeeTimeView.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.EmployeeTimeView.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.EmployeeTimeView.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.EmployeeTimeView.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.EmployeeTimeView.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.EmployeeTimeView.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.EmployeeTimeView.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.EmployeeTimeView.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.EmployeeTimeView.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.EmployeeTimeView.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.EmployeeTimeView.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.EmployeeTimeView.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.EmployeeTimeView.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.EmployeeTimeView.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.EmployeeTimeView.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.EmployeeTimeView.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.EmployeeTimeView.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.EmployeeTimeView.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.EmployeeTimeView.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.EmployeeTimeView.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.EmployeeTimeView.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.EmployeeTimeView.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.EmployeeTimeView.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.EmployeeTimeView.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.EmployeeTimeView.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.EmployeeTimeView.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.EmployeeTimeView.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.EmployeeTimeView.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.EmployeeTimeView.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.EmployeeTimeView.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.EmployeeTimeView.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.EmployeeTimeView.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.EmployeeTimeView.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.EmployeeTimeView.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.EmployeeTimeView.EnableDisabledRows = False
            Me.EmployeeTimeView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.EmployeeTimeView.ModifyColumnSettingsOnEachDataSource = True
            Me.EmployeeTimeView.ModifyGridRowHeight = False
            Me.EmployeeTimeView.Name = "EmployeeTimeView"
            Me.EmployeeTimeView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.EmployeeTimeView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.EmployeeTimeView.OptionsBehavior.Editable = False
            Me.EmployeeTimeView.OptionsCustomization.AllowQuickHideColumns = False
            Me.EmployeeTimeView.OptionsNavigation.AutoFocusNewRow = True
            Me.EmployeeTimeView.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.EmployeeTimeView.OptionsSelection.MultiSelect = True
            Me.EmployeeTimeView.OptionsView.ColumnAutoWidth = False
            Me.EmployeeTimeView.OptionsView.ShowGroupPanel = False
            Me.EmployeeTimeView.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.EmployeeTimeView.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.EmployeeTimeView.SkipAddingControlsOnModifyColumn = False
            Me.EmployeeTimeView.SkipSettingFontOnModifyColumn = False
            '
            'LabelFunction_EmployeeTime
            '
            Me.LabelFunction_EmployeeTime.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelFunction_EmployeeTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelFunction_EmployeeTime.Location = New System.Drawing.Point(5, 24)
            Me.LabelFunction_EmployeeTime.Name = "LabelFunction_EmployeeTime"
            Me.LabelFunction_EmployeeTime.Size = New System.Drawing.Size(127, 20)
            Me.LabelFunction_EmployeeTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelFunction_EmployeeTime.TabIndex = 0
            Me.LabelFunction_EmployeeTime.Text = "Employee Time:"
            '
            'LabelForm_InvoiceSuffix
            '
            Me.LabelForm_InvoiceSuffix.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_InvoiceSuffix.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_InvoiceSuffix.Location = New System.Drawing.Point(12, 152)
            Me.LabelForm_InvoiceSuffix.Name = "LabelForm_InvoiceSuffix"
            Me.LabelForm_InvoiceSuffix.Size = New System.Drawing.Size(152, 20)
            Me.LabelForm_InvoiceSuffix.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_InvoiceSuffix.TabIndex = 2
            Me.LabelForm_InvoiceSuffix.Text = "Client Invoice Number Suffix:"
            '
            'TextBoxForm_InvoiceSuffix
            '
            Me.TextBoxForm_InvoiceSuffix.AgencyImportPath = Nothing
            Me.TextBoxForm_InvoiceSuffix.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxForm_InvoiceSuffix.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_InvoiceSuffix.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_InvoiceSuffix.CheckSpellingOnValidate = False
            Me.TextBoxForm_InvoiceSuffix.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_InvoiceSuffix.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxForm_InvoiceSuffix.DisplayName = "Invoice Number Suffix"
            Me.TextBoxForm_InvoiceSuffix.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxForm_InvoiceSuffix.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_InvoiceSuffix.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_InvoiceSuffix.FocusHighlightEnabled = True
            Me.TextBoxForm_InvoiceSuffix.ForeColor = System.Drawing.Color.Black
            Me.TextBoxForm_InvoiceSuffix.Location = New System.Drawing.Point(170, 152)
            Me.TextBoxForm_InvoiceSuffix.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_InvoiceSuffix.Name = "TextBoxForm_InvoiceSuffix"
            Me.TextBoxForm_InvoiceSuffix.SecurityEnabled = True
            Me.TextBoxForm_InvoiceSuffix.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_InvoiceSuffix.Size = New System.Drawing.Size(81, 20)
            Me.TextBoxForm_InvoiceSuffix.StartingFolderName = Nothing
            Me.TextBoxForm_InvoiceSuffix.TabIndex = 3
            Me.TextBoxForm_InvoiceSuffix.TabOnEnter = True
            '
            'GroupBox_BillAccountMapping
            '
            Me.GroupBox_BillAccountMapping.Controls.Add(Me.SearchableComboBoxBill_Production)
            Me.GroupBox_BillAccountMapping.Controls.Add(Me.LabelBill_Production)
            Me.GroupBox_BillAccountMapping.Controls.Add(Me.SearchableComboBoxBill_NonClient)
            Me.GroupBox_BillAccountMapping.Controls.Add(Me.LabelBill_NonClient)
            Me.GroupBox_BillAccountMapping.Controls.Add(Me.SearchableComboBoxBill_Media)
            Me.GroupBox_BillAccountMapping.Controls.Add(Me.LabelBill_Media)
            Me.GroupBox_BillAccountMapping.Location = New System.Drawing.Point(12, 322)
            Me.GroupBox_BillAccountMapping.Name = "GroupBox_BillAccountMapping"
            Me.GroupBox_BillAccountMapping.Size = New System.Drawing.Size(499, 109)
            Me.GroupBox_BillAccountMapping.TabIndex = 5
            Me.GroupBox_BillAccountMapping.Text = "Vendor Invoice - Account Mapping"
            '
            'SearchableComboBoxBill_Production
            '
            Me.SearchableComboBoxBill_Production.ActiveFilterString = ""
            Me.SearchableComboBoxBill_Production.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxBill_Production.AutoFillMode = False
            Me.SearchableComboBoxBill_Production.BookmarkingEnabled = False
            Me.SearchableComboBoxBill_Production.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.Type.[Default]
            Me.SearchableComboBoxBill_Production.DataSource = Nothing
            Me.SearchableComboBoxBill_Production.DisableMouseWheel = True
            Me.SearchableComboBoxBill_Production.DisplayName = "Media Mapping"
            Me.SearchableComboBoxBill_Production.EditValue = ""
            Me.SearchableComboBoxBill_Production.EnterMoveNextControl = True
            Me.SearchableComboBoxBill_Production.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxBill_Production.Location = New System.Drawing.Point(138, 25)
            Me.SearchableComboBoxBill_Production.Name = "SearchableComboBoxBill_Production"
            Me.SearchableComboBoxBill_Production.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxBill_Production.Properties.NullText = ""
            Me.SearchableComboBoxBill_Production.Properties.PopupView = Me.GridView3
            Me.SearchableComboBoxBill_Production.Properties.ShowClearButton = False
            Me.SearchableComboBoxBill_Production.SecurityEnabled = True
            Me.SearchableComboBoxBill_Production.SelectedValue = ""
            Me.SearchableComboBoxBill_Production.Size = New System.Drawing.Size(347, 20)
            Me.SearchableComboBoxBill_Production.TabIndex = 1
            '
            'GridView3
            '
            Me.GridView3.AFActiveFilterString = ""
            Me.GridView3.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.EnableDisabledRows = False
            Me.GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView3.ModifyColumnSettingsOnEachDataSource = True
            Me.GridView3.ModifyGridRowHeight = False
            Me.GridView3.Name = "GridView3"
            Me.GridView3.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView3.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView3.OptionsBehavior.Editable = False
            Me.GridView3.OptionsCustomization.AllowQuickHideColumns = False
            Me.GridView3.OptionsNavigation.AutoFocusNewRow = True
            Me.GridView3.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView3.OptionsSelection.MultiSelect = True
            Me.GridView3.OptionsView.ColumnAutoWidth = False
            Me.GridView3.OptionsView.ShowGroupPanel = False
            Me.GridView3.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.GridView3.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView3.SkipAddingControlsOnModifyColumn = False
            Me.GridView3.SkipSettingFontOnModifyColumn = False
            '
            'LabelBill_Production
            '
            Me.LabelBill_Production.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelBill_Production.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelBill_Production.Location = New System.Drawing.Point(5, 24)
            Me.LabelBill_Production.Name = "LabelBill_Production"
            Me.LabelBill_Production.Size = New System.Drawing.Size(127, 20)
            Me.LabelBill_Production.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelBill_Production.TabIndex = 0
            Me.LabelBill_Production.Text = "Production:"
            '
            'SearchableComboBoxBill_NonClient
            '
            Me.SearchableComboBoxBill_NonClient.ActiveFilterString = ""
            Me.SearchableComboBoxBill_NonClient.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxBill_NonClient.AutoFillMode = False
            Me.SearchableComboBoxBill_NonClient.BookmarkingEnabled = False
            Me.SearchableComboBoxBill_NonClient.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.Type.[Default]
            Me.SearchableComboBoxBill_NonClient.DataSource = Nothing
            Me.SearchableComboBoxBill_NonClient.DisableMouseWheel = True
            Me.SearchableComboBoxBill_NonClient.DisplayName = "Non-Client Mapping"
            Me.SearchableComboBoxBill_NonClient.EditValue = ""
            Me.SearchableComboBoxBill_NonClient.EnterMoveNextControl = True
            Me.SearchableComboBoxBill_NonClient.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxBill_NonClient.Location = New System.Drawing.Point(138, 77)
            Me.SearchableComboBoxBill_NonClient.Name = "SearchableComboBoxBill_NonClient"
            Me.SearchableComboBoxBill_NonClient.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxBill_NonClient.Properties.NullText = ""
            Me.SearchableComboBoxBill_NonClient.Properties.PopupView = Me.GridView2
            Me.SearchableComboBoxBill_NonClient.Properties.ShowClearButton = False
            Me.SearchableComboBoxBill_NonClient.SecurityEnabled = True
            Me.SearchableComboBoxBill_NonClient.SelectedValue = ""
            Me.SearchableComboBoxBill_NonClient.Size = New System.Drawing.Size(347, 20)
            Me.SearchableComboBoxBill_NonClient.TabIndex = 5
            '
            'GridView2
            '
            Me.GridView2.AFActiveFilterString = ""
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
            Me.GridView2.EnableDisabledRows = False
            Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView2.ModifyColumnSettingsOnEachDataSource = True
            Me.GridView2.ModifyGridRowHeight = False
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
            Me.GridView2.SkipAddingControlsOnModifyColumn = False
            Me.GridView2.SkipSettingFontOnModifyColumn = False
            '
            'LabelBill_NonClient
            '
            Me.LabelBill_NonClient.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelBill_NonClient.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelBill_NonClient.Location = New System.Drawing.Point(5, 76)
            Me.LabelBill_NonClient.Name = "LabelBill_NonClient"
            Me.LabelBill_NonClient.Size = New System.Drawing.Size(127, 20)
            Me.LabelBill_NonClient.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelBill_NonClient.TabIndex = 4
            Me.LabelBill_NonClient.Text = "Non-Client:"
            '
            'SearchableComboBoxBill_Media
            '
            Me.SearchableComboBoxBill_Media.ActiveFilterString = ""
            Me.SearchableComboBoxBill_Media.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxBill_Media.AutoFillMode = False
            Me.SearchableComboBoxBill_Media.BookmarkingEnabled = False
            Me.SearchableComboBoxBill_Media.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.Type.[Default]
            Me.SearchableComboBoxBill_Media.DataSource = Nothing
            Me.SearchableComboBoxBill_Media.DisableMouseWheel = True
            Me.SearchableComboBoxBill_Media.DisplayName = "Media Mapping"
            Me.SearchableComboBoxBill_Media.EditValue = ""
            Me.SearchableComboBoxBill_Media.EnterMoveNextControl = True
            Me.SearchableComboBoxBill_Media.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxBill_Media.Location = New System.Drawing.Point(138, 51)
            Me.SearchableComboBoxBill_Media.Name = "SearchableComboBoxBill_Media"
            Me.SearchableComboBoxBill_Media.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxBill_Media.Properties.NullText = ""
            Me.SearchableComboBoxBill_Media.Properties.PopupView = Me.GridView1
            Me.SearchableComboBoxBill_Media.Properties.ShowClearButton = False
            Me.SearchableComboBoxBill_Media.SecurityEnabled = True
            Me.SearchableComboBoxBill_Media.SelectedValue = ""
            Me.SearchableComboBoxBill_Media.Size = New System.Drawing.Size(347, 20)
            Me.SearchableComboBoxBill_Media.TabIndex = 3
            '
            'GridView1
            '
            Me.GridView1.AFActiveFilterString = ""
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
            Me.GridView1.EnableDisabledRows = False
            Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView1.ModifyColumnSettingsOnEachDataSource = True
            Me.GridView1.ModifyGridRowHeight = False
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
            Me.GridView1.SkipAddingControlsOnModifyColumn = False
            Me.GridView1.SkipSettingFontOnModifyColumn = False
            '
            'LabelBill_Media
            '
            Me.LabelBill_Media.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelBill_Media.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelBill_Media.Location = New System.Drawing.Point(5, 50)
            Me.LabelBill_Media.Name = "LabelBill_Media"
            Me.LabelBill_Media.Size = New System.Drawing.Size(127, 20)
            Me.LabelBill_Media.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelBill_Media.TabIndex = 2
            Me.LabelBill_Media.Text = "Media:"
            '
            'GroupBoxForm_InvoiceLineItemDescription
            '
            Me.GroupBoxForm_InvoiceLineItemDescription.Controls.Add(Me.GroupBoxInvoiceMedia_Include)
            Me.GroupBoxForm_InvoiceLineItemDescription.Controls.Add(Me.GroupBoxInvoiceProduction_Include)
            Me.GroupBoxForm_InvoiceLineItemDescription.Location = New System.Drawing.Point(12, 178)
            Me.GroupBoxForm_InvoiceLineItemDescription.Name = "GroupBoxForm_InvoiceLineItemDescription"
            Me.GroupBoxForm_InvoiceLineItemDescription.Size = New System.Drawing.Size(499, 138)
            Me.GroupBoxForm_InvoiceLineItemDescription.TabIndex = 4
            Me.GroupBoxForm_InvoiceLineItemDescription.Text = "Invoice Line Item Description"
            '
            'GroupBoxInvoiceMedia_Include
            '
            Me.GroupBoxInvoiceMedia_Include.Controls.Add(Me.CheckBoxInvoiceMedia_IncludeOrderLineNumber)
            Me.GroupBoxInvoiceMedia_Include.Controls.Add(Me.CheckBoxInvoiceMedia_IncludeOrderNumber)
            Me.GroupBoxInvoiceMedia_Include.Controls.Add(Me.CheckBoxInvoiceMedia_IncludeSalesClass)
            Me.GroupBoxInvoiceMedia_Include.Location = New System.Drawing.Point(318, 24)
            Me.GroupBoxInvoiceMedia_Include.Name = "GroupBoxInvoiceMedia_Include"
            Me.GroupBoxInvoiceMedia_Include.Size = New System.Drawing.Size(167, 107)
            Me.GroupBoxInvoiceMedia_Include.TabIndex = 1
            Me.GroupBoxInvoiceMedia_Include.Text = "Media Include"
            '
            'CheckBoxInvoiceMedia_IncludeOrderLineNumber
            '
            Me.CheckBoxInvoiceMedia_IncludeOrderLineNumber.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxInvoiceMedia_IncludeOrderLineNumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxInvoiceMedia_IncludeOrderLineNumber.CheckValue = 0
            Me.CheckBoxInvoiceMedia_IncludeOrderLineNumber.CheckValueChecked = 1
            Me.CheckBoxInvoiceMedia_IncludeOrderLineNumber.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxInvoiceMedia_IncludeOrderLineNumber.CheckValueUnchecked = 0
            Me.CheckBoxInvoiceMedia_IncludeOrderLineNumber.ChildControls = CType(resources.GetObject("CheckBoxInvoiceMedia_IncludeOrderLineNumber.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxInvoiceMedia_IncludeOrderLineNumber.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxInvoiceMedia_IncludeOrderLineNumber.Location = New System.Drawing.Point(5, 76)
            Me.CheckBoxInvoiceMedia_IncludeOrderLineNumber.Name = "CheckBoxInvoiceMedia_IncludeOrderLineNumber"
            Me.CheckBoxInvoiceMedia_IncludeOrderLineNumber.OldestSibling = Nothing
            Me.CheckBoxInvoiceMedia_IncludeOrderLineNumber.SecurityEnabled = True
            Me.CheckBoxInvoiceMedia_IncludeOrderLineNumber.SiblingControls = CType(resources.GetObject("CheckBoxInvoiceMedia_IncludeOrderLineNumber.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxInvoiceMedia_IncludeOrderLineNumber.Size = New System.Drawing.Size(142, 20)
            Me.CheckBoxInvoiceMedia_IncludeOrderLineNumber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxInvoiceMedia_IncludeOrderLineNumber.TabIndex = 2
            Me.CheckBoxInvoiceMedia_IncludeOrderLineNumber.TabOnEnter = True
            Me.CheckBoxInvoiceMedia_IncludeOrderLineNumber.Text = "Order Line Number"
            '
            'CheckBoxInvoiceMedia_IncludeOrderNumber
            '
            Me.CheckBoxInvoiceMedia_IncludeOrderNumber.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxInvoiceMedia_IncludeOrderNumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxInvoiceMedia_IncludeOrderNumber.CheckValue = 0
            Me.CheckBoxInvoiceMedia_IncludeOrderNumber.CheckValueChecked = 1
            Me.CheckBoxInvoiceMedia_IncludeOrderNumber.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxInvoiceMedia_IncludeOrderNumber.CheckValueUnchecked = 0
            Me.CheckBoxInvoiceMedia_IncludeOrderNumber.ChildControls = CType(resources.GetObject("CheckBoxInvoiceMedia_IncludeOrderNumber.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxInvoiceMedia_IncludeOrderNumber.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxInvoiceMedia_IncludeOrderNumber.Location = New System.Drawing.Point(5, 50)
            Me.CheckBoxInvoiceMedia_IncludeOrderNumber.Name = "CheckBoxInvoiceMedia_IncludeOrderNumber"
            Me.CheckBoxInvoiceMedia_IncludeOrderNumber.OldestSibling = Nothing
            Me.CheckBoxInvoiceMedia_IncludeOrderNumber.SecurityEnabled = True
            Me.CheckBoxInvoiceMedia_IncludeOrderNumber.SiblingControls = CType(resources.GetObject("CheckBoxInvoiceMedia_IncludeOrderNumber.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxInvoiceMedia_IncludeOrderNumber.Size = New System.Drawing.Size(142, 20)
            Me.CheckBoxInvoiceMedia_IncludeOrderNumber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxInvoiceMedia_IncludeOrderNumber.TabIndex = 1
            Me.CheckBoxInvoiceMedia_IncludeOrderNumber.TabOnEnter = True
            Me.CheckBoxInvoiceMedia_IncludeOrderNumber.Text = "Order Number / Desc"
            '
            'CheckBoxInvoiceMedia_IncludeSalesClass
            '
            Me.CheckBoxInvoiceMedia_IncludeSalesClass.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxInvoiceMedia_IncludeSalesClass.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxInvoiceMedia_IncludeSalesClass.CheckValue = 0
            Me.CheckBoxInvoiceMedia_IncludeSalesClass.CheckValueChecked = 1
            Me.CheckBoxInvoiceMedia_IncludeSalesClass.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxInvoiceMedia_IncludeSalesClass.CheckValueUnchecked = 0
            Me.CheckBoxInvoiceMedia_IncludeSalesClass.ChildControls = CType(resources.GetObject("CheckBoxInvoiceMedia_IncludeSalesClass.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxInvoiceMedia_IncludeSalesClass.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxInvoiceMedia_IncludeSalesClass.Location = New System.Drawing.Point(5, 24)
            Me.CheckBoxInvoiceMedia_IncludeSalesClass.Name = "CheckBoxInvoiceMedia_IncludeSalesClass"
            Me.CheckBoxInvoiceMedia_IncludeSalesClass.OldestSibling = Nothing
            Me.CheckBoxInvoiceMedia_IncludeSalesClass.SecurityEnabled = True
            Me.CheckBoxInvoiceMedia_IncludeSalesClass.SiblingControls = CType(resources.GetObject("CheckBoxInvoiceMedia_IncludeSalesClass.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxInvoiceMedia_IncludeSalesClass.Size = New System.Drawing.Size(142, 20)
            Me.CheckBoxInvoiceMedia_IncludeSalesClass.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxInvoiceMedia_IncludeSalesClass.TabIndex = 0
            Me.CheckBoxInvoiceMedia_IncludeSalesClass.TabOnEnter = True
            Me.CheckBoxInvoiceMedia_IncludeSalesClass.Text = "Sales Class"
            '
            'GroupBoxInvoiceProduction_Include
            '
            Me.GroupBoxInvoiceProduction_Include.Controls.Add(Me.CheckBoxInvoiceProduction_IncludeFunctionDescription)
            Me.GroupBoxInvoiceProduction_Include.Controls.Add(Me.CheckBoxInvoiceProduction_IncludeComponentDescription)
            Me.GroupBoxInvoiceProduction_Include.Controls.Add(Me.CheckBoxInvoiceProduction_IncludeJobDescription)
            Me.GroupBoxInvoiceProduction_Include.Controls.Add(Me.CheckBoxInvoiceProduction_IncludeComponentNumber)
            Me.GroupBoxInvoiceProduction_Include.Controls.Add(Me.CheckBoxInvoiceProduction_IncludeJobNumber)
            Me.GroupBoxInvoiceProduction_Include.Controls.Add(Me.CheckBoxInvoiceProduction_IncludeSalesClass)
            Me.GroupBoxInvoiceProduction_Include.Location = New System.Drawing.Point(5, 24)
            Me.GroupBoxInvoiceProduction_Include.Name = "GroupBoxInvoiceProduction_Include"
            Me.GroupBoxInvoiceProduction_Include.Size = New System.Drawing.Size(307, 107)
            Me.GroupBoxInvoiceProduction_Include.TabIndex = 0
            Me.GroupBoxInvoiceProduction_Include.Text = "Production Include"
            '
            'CheckBoxInvoiceProduction_IncludeFunctionDescription
            '
            Me.CheckBoxInvoiceProduction_IncludeFunctionDescription.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxInvoiceProduction_IncludeFunctionDescription.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxInvoiceProduction_IncludeFunctionDescription.CheckValue = 0
            Me.CheckBoxInvoiceProduction_IncludeFunctionDescription.CheckValueChecked = 1
            Me.CheckBoxInvoiceProduction_IncludeFunctionDescription.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxInvoiceProduction_IncludeFunctionDescription.CheckValueUnchecked = 0
            Me.CheckBoxInvoiceProduction_IncludeFunctionDescription.ChildControls = CType(resources.GetObject("CheckBoxInvoiceProduction_IncludeFunctionDescription.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxInvoiceProduction_IncludeFunctionDescription.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxInvoiceProduction_IncludeFunctionDescription.Location = New System.Drawing.Point(153, 76)
            Me.CheckBoxInvoiceProduction_IncludeFunctionDescription.Name = "CheckBoxInvoiceProduction_IncludeFunctionDescription"
            Me.CheckBoxInvoiceProduction_IncludeFunctionDescription.OldestSibling = Nothing
            Me.CheckBoxInvoiceProduction_IncludeFunctionDescription.SecurityEnabled = True
            Me.CheckBoxInvoiceProduction_IncludeFunctionDescription.SiblingControls = CType(resources.GetObject("CheckBoxInvoiceProduction_IncludeFunctionDescription.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxInvoiceProduction_IncludeFunctionDescription.Size = New System.Drawing.Size(142, 20)
            Me.CheckBoxInvoiceProduction_IncludeFunctionDescription.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxInvoiceProduction_IncludeFunctionDescription.TabIndex = 5
            Me.CheckBoxInvoiceProduction_IncludeFunctionDescription.TabOnEnter = True
            Me.CheckBoxInvoiceProduction_IncludeFunctionDescription.Text = "Function Description"
            '
            'CheckBoxInvoiceProduction_IncludeComponentDescription
            '
            Me.CheckBoxInvoiceProduction_IncludeComponentDescription.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxInvoiceProduction_IncludeComponentDescription.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxInvoiceProduction_IncludeComponentDescription.CheckValue = 0
            Me.CheckBoxInvoiceProduction_IncludeComponentDescription.CheckValueChecked = 1
            Me.CheckBoxInvoiceProduction_IncludeComponentDescription.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxInvoiceProduction_IncludeComponentDescription.CheckValueUnchecked = 0
            Me.CheckBoxInvoiceProduction_IncludeComponentDescription.ChildControls = CType(resources.GetObject("CheckBoxInvoiceProduction_IncludeComponentDescription.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxInvoiceProduction_IncludeComponentDescription.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxInvoiceProduction_IncludeComponentDescription.Location = New System.Drawing.Point(153, 50)
            Me.CheckBoxInvoiceProduction_IncludeComponentDescription.Name = "CheckBoxInvoiceProduction_IncludeComponentDescription"
            Me.CheckBoxInvoiceProduction_IncludeComponentDescription.OldestSibling = Nothing
            Me.CheckBoxInvoiceProduction_IncludeComponentDescription.SecurityEnabled = True
            Me.CheckBoxInvoiceProduction_IncludeComponentDescription.SiblingControls = CType(resources.GetObject("CheckBoxInvoiceProduction_IncludeComponentDescription.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxInvoiceProduction_IncludeComponentDescription.Size = New System.Drawing.Size(142, 20)
            Me.CheckBoxInvoiceProduction_IncludeComponentDescription.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxInvoiceProduction_IncludeComponentDescription.TabIndex = 4
            Me.CheckBoxInvoiceProduction_IncludeComponentDescription.TabOnEnter = True
            Me.CheckBoxInvoiceProduction_IncludeComponentDescription.Text = "Component Description"
            '
            'CheckBoxInvoiceProduction_IncludeJobDescription
            '
            Me.CheckBoxInvoiceProduction_IncludeJobDescription.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxInvoiceProduction_IncludeJobDescription.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxInvoiceProduction_IncludeJobDescription.CheckValue = 0
            Me.CheckBoxInvoiceProduction_IncludeJobDescription.CheckValueChecked = 1
            Me.CheckBoxInvoiceProduction_IncludeJobDescription.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxInvoiceProduction_IncludeJobDescription.CheckValueUnchecked = 0
            Me.CheckBoxInvoiceProduction_IncludeJobDescription.ChildControls = CType(resources.GetObject("CheckBoxInvoiceProduction_IncludeJobDescription.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxInvoiceProduction_IncludeJobDescription.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxInvoiceProduction_IncludeJobDescription.Location = New System.Drawing.Point(153, 24)
            Me.CheckBoxInvoiceProduction_IncludeJobDescription.Name = "CheckBoxInvoiceProduction_IncludeJobDescription"
            Me.CheckBoxInvoiceProduction_IncludeJobDescription.OldestSibling = Nothing
            Me.CheckBoxInvoiceProduction_IncludeJobDescription.SecurityEnabled = True
            Me.CheckBoxInvoiceProduction_IncludeJobDescription.SiblingControls = CType(resources.GetObject("CheckBoxInvoiceProduction_IncludeJobDescription.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxInvoiceProduction_IncludeJobDescription.Size = New System.Drawing.Size(142, 20)
            Me.CheckBoxInvoiceProduction_IncludeJobDescription.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxInvoiceProduction_IncludeJobDescription.TabIndex = 3
            Me.CheckBoxInvoiceProduction_IncludeJobDescription.TabOnEnter = True
            Me.CheckBoxInvoiceProduction_IncludeJobDescription.Text = "Job Description"
            '
            'CheckBoxInvoiceProduction_IncludeComponentNumber
            '
            Me.CheckBoxInvoiceProduction_IncludeComponentNumber.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxInvoiceProduction_IncludeComponentNumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxInvoiceProduction_IncludeComponentNumber.CheckValue = 0
            Me.CheckBoxInvoiceProduction_IncludeComponentNumber.CheckValueChecked = 1
            Me.CheckBoxInvoiceProduction_IncludeComponentNumber.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxInvoiceProduction_IncludeComponentNumber.CheckValueUnchecked = 0
            Me.CheckBoxInvoiceProduction_IncludeComponentNumber.ChildControls = CType(resources.GetObject("CheckBoxInvoiceProduction_IncludeComponentNumber.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxInvoiceProduction_IncludeComponentNumber.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxInvoiceProduction_IncludeComponentNumber.Location = New System.Drawing.Point(5, 76)
            Me.CheckBoxInvoiceProduction_IncludeComponentNumber.Name = "CheckBoxInvoiceProduction_IncludeComponentNumber"
            Me.CheckBoxInvoiceProduction_IncludeComponentNumber.OldestSibling = Nothing
            Me.CheckBoxInvoiceProduction_IncludeComponentNumber.SecurityEnabled = True
            Me.CheckBoxInvoiceProduction_IncludeComponentNumber.SiblingControls = CType(resources.GetObject("CheckBoxInvoiceProduction_IncludeComponentNumber.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxInvoiceProduction_IncludeComponentNumber.Size = New System.Drawing.Size(142, 20)
            Me.CheckBoxInvoiceProduction_IncludeComponentNumber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxInvoiceProduction_IncludeComponentNumber.TabIndex = 2
            Me.CheckBoxInvoiceProduction_IncludeComponentNumber.TabOnEnter = True
            Me.CheckBoxInvoiceProduction_IncludeComponentNumber.Text = "Component Number"
            '
            'CheckBoxInvoiceProduction_IncludeJobNumber
            '
            Me.CheckBoxInvoiceProduction_IncludeJobNumber.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxInvoiceProduction_IncludeJobNumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxInvoiceProduction_IncludeJobNumber.CheckValue = 0
            Me.CheckBoxInvoiceProduction_IncludeJobNumber.CheckValueChecked = 1
            Me.CheckBoxInvoiceProduction_IncludeJobNumber.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxInvoiceProduction_IncludeJobNumber.CheckValueUnchecked = 0
            Me.CheckBoxInvoiceProduction_IncludeJobNumber.ChildControls = CType(resources.GetObject("CheckBoxInvoiceProduction_IncludeJobNumber.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxInvoiceProduction_IncludeJobNumber.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxInvoiceProduction_IncludeJobNumber.Location = New System.Drawing.Point(5, 50)
            Me.CheckBoxInvoiceProduction_IncludeJobNumber.Name = "CheckBoxInvoiceProduction_IncludeJobNumber"
            Me.CheckBoxInvoiceProduction_IncludeJobNumber.OldestSibling = Nothing
            Me.CheckBoxInvoiceProduction_IncludeJobNumber.SecurityEnabled = True
            Me.CheckBoxInvoiceProduction_IncludeJobNumber.SiblingControls = CType(resources.GetObject("CheckBoxInvoiceProduction_IncludeJobNumber.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxInvoiceProduction_IncludeJobNumber.Size = New System.Drawing.Size(142, 20)
            Me.CheckBoxInvoiceProduction_IncludeJobNumber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxInvoiceProduction_IncludeJobNumber.TabIndex = 1
            Me.CheckBoxInvoiceProduction_IncludeJobNumber.TabOnEnter = True
            Me.CheckBoxInvoiceProduction_IncludeJobNumber.Text = "Job Number"
            '
            'CheckBoxInvoiceProduction_IncludeSalesClass
            '
            Me.CheckBoxInvoiceProduction_IncludeSalesClass.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxInvoiceProduction_IncludeSalesClass.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxInvoiceProduction_IncludeSalesClass.CheckValue = 0
            Me.CheckBoxInvoiceProduction_IncludeSalesClass.CheckValueChecked = 1
            Me.CheckBoxInvoiceProduction_IncludeSalesClass.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxInvoiceProduction_IncludeSalesClass.CheckValueUnchecked = 0
            Me.CheckBoxInvoiceProduction_IncludeSalesClass.ChildControls = CType(resources.GetObject("CheckBoxInvoiceProduction_IncludeSalesClass.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxInvoiceProduction_IncludeSalesClass.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxInvoiceProduction_IncludeSalesClass.Location = New System.Drawing.Point(5, 24)
            Me.CheckBoxInvoiceProduction_IncludeSalesClass.Name = "CheckBoxInvoiceProduction_IncludeSalesClass"
            Me.CheckBoxInvoiceProduction_IncludeSalesClass.OldestSibling = Nothing
            Me.CheckBoxInvoiceProduction_IncludeSalesClass.SecurityEnabled = True
            Me.CheckBoxInvoiceProduction_IncludeSalesClass.SiblingControls = CType(resources.GetObject("CheckBoxInvoiceProduction_IncludeSalesClass.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxInvoiceProduction_IncludeSalesClass.Size = New System.Drawing.Size(142, 20)
            Me.CheckBoxInvoiceProduction_IncludeSalesClass.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxInvoiceProduction_IncludeSalesClass.TabIndex = 0
            Me.CheckBoxInvoiceProduction_IncludeSalesClass.TabOnEnter = True
            Me.CheckBoxInvoiceProduction_IncludeSalesClass.Text = "Sales Class"
            '
            'QuickbooksSetupForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(992, 730)
            Me.Controls.Add(Me.GroupBoxForm_InvoiceLineItemDescription)
            Me.Controls.Add(Me.GroupBox_BillAccountMapping)
            Me.Controls.Add(Me.TextBoxForm_InvoiceSuffix)
            Me.Controls.Add(Me.LabelForm_InvoiceSuffix)
            Me.Controls.Add(Me.GroupBoxForm_InvoiceFunctionItemMapping)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "QuickbooksSetupForm"
            Me.Text = "QuickBooks Settings"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            CType(Me.GroupBoxForm_InvoiceFunctionItemMapping, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxForm_InvoiceFunctionItemMapping.ResumeLayout(False)
            CType(Me.SearchableComboBoxMedia_Order.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.OrderView, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxFunction_IncomeOnly.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.IncomeOnlyView, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxFunction_ProductionVendorCost.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ProductionVendorCostView, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxFunction_EmployeeTime.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.EmployeeTimeView, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBox_BillAccountMapping, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBox_BillAccountMapping.ResumeLayout(False)
            CType(Me.SearchableComboBoxBill_Production.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxBill_NonClient.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxBill_Media.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxForm_InvoiceLineItemDescription, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxForm_InvoiceLineItemDescription.ResumeLayout(False)
            CType(Me.GroupBoxInvoiceMedia_Include, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxInvoiceMedia_Include.ResumeLayout(False)
            CType(Me.GroupBoxInvoiceProduction_Include, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxInvoiceProduction_Include.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Save As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Cancel As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents GroupBoxForm_InvoiceFunctionItemMapping As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents LabelFunction_EmployeeTime As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxFunction_EmployeeTime As WinForm.MVC.Presentation.Controls.SearchableComboBox
        Friend WithEvents EmployeeTimeView As WinForm.MVC.Presentation.Controls.GridView
        Friend WithEvents LabelFunction_IncomeOnly As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelFunction_ProductionVendorCost As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxFunction_IncomeOnly As WinForm.MVC.Presentation.Controls.SearchableComboBox
        Friend WithEvents IncomeOnlyView As WinForm.MVC.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxFunction_ProductionVendorCost As WinForm.MVC.Presentation.Controls.SearchableComboBox
        Friend WithEvents ProductionVendorCostView As WinForm.MVC.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxMedia_Order As WinForm.MVC.Presentation.Controls.SearchableComboBox
        Friend WithEvents OrderView As WinForm.MVC.Presentation.Controls.GridView
        Friend WithEvents LabelMedia_Order As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelForm_InvoiceSuffix As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_InvoiceSuffix As WinForm.MVC.Presentation.Controls.TextBox
        Friend WithEvents GroupBox_BillAccountMapping As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents SearchableComboBoxBill_Media As WinForm.MVC.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView1 As WinForm.MVC.Presentation.Controls.GridView
        Friend WithEvents LabelBill_Media As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxBill_NonClient As WinForm.MVC.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView2 As WinForm.MVC.Presentation.Controls.GridView
        Friend WithEvents LabelBill_NonClient As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents GroupBoxForm_InvoiceLineItemDescription As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents GroupBoxInvoiceProduction_Include As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents CheckBoxRightColumn_NewBusiness As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxInvoiceProduction_IncludeSalesClass As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents GroupBoxInvoiceMedia_Include As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents CheckBoxInvoiceMedia_IncludeOrderLineNumber As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxInvoiceMedia_IncludeOrderNumber As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxInvoiceMedia_IncludeSalesClass As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxInvoiceProduction_IncludeFunctionDescription As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxInvoiceProduction_IncludeComponentDescription As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxInvoiceProduction_IncludeJobDescription As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxInvoiceProduction_IncludeComponentNumber As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxInvoiceProduction_IncludeJobNumber As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents SearchableComboBoxBill_Production As WinForm.MVC.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView3 As WinForm.MVC.Presentation.Controls.GridView
        Friend WithEvents LabelBill_Production As WinForm.MVC.Presentation.Controls.Label
    End Class

End Namespace

