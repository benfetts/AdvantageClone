Namespace FinanceAndAccounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ClientCashReceiptPartialPaymentEditDialog
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseRibbonForm

        'Form overrides dispose to clean up the component list.
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ClientCashReceiptPartialPaymentEditDialog))
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Payment = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemPayment_Apply = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemPayment_Undo = New DevComponents.DotNetBar.ButtonItem()
            Me.DataGridViewPanel_PaymentDetail = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.NumericInputPanel_Remaining = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelPanel_Remaining = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.NumericInputPanel_BalanceToPaymentAmount = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelPanel_BalanceToPaymentAmount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.RibbonBarOptions_Balance = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ItemContainerBalance_Vertical = New DevComponents.DotNetBar.ItemContainer()
            Me.ItemContainerVertical_Horizontal = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemBalance_CurrentBalance = New DevComponents.DotNetBar.LabelItem()
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Form.SuspendLayout()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputPanel_Remaining.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputPanel_BalanceToPaymentAmount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'RibbonControlForm_MainRibbon
            '
            '
            '
            '
            Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(1011, 154)
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
            Me.RibbonControlForm_MainRibbon.TabIndex = 0
            Me.RibbonControlForm_MainRibbon.Controls.SetChildIndex(Me.RibbonPanelFile_FilePanel, 0)
            '
            'RibbonPanelFile_FilePanel
            '
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Balance)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Payment)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 57)
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(1011, 94)
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
            Me.RibbonPanelFile_FilePanel.TabIndex = 0
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarFilePanel_System, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Actions, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Payment, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Balance, 0)
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
            'PanelForm_Form
            '
            Me.PanelForm_Form.Controls.Add(Me.DataGridViewPanel_PaymentDetail)
            Me.PanelForm_Form.Controls.Add(Me.NumericInputPanel_Remaining)
            Me.PanelForm_Form.Controls.Add(Me.LabelPanel_BalanceToPaymentAmount)
            Me.PanelForm_Form.Controls.Add(Me.LabelPanel_Remaining)
            Me.PanelForm_Form.Controls.Add(Me.NumericInputPanel_BalanceToPaymentAmount)
            Me.PanelForm_Form.Size = New System.Drawing.Size(1011, 489)
            Me.PanelForm_Form.TabIndex = 1
            '
            'BarForm_StatusBar
            '
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 644)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(1011, 18)
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
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(103, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(91, 92)
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
            'RibbonBarOptions_Payment
            '
            Me.RibbonBarOptions_Payment.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBarOptions_Payment.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Payment.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Payment.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Payment.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Payment.DragDropSupport = True
            Me.RibbonBarOptions_Payment.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemPayment_Apply, Me.ButtonItemPayment_Undo})
            Me.RibbonBarOptions_Payment.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Payment.Location = New System.Drawing.Point(194, 0)
            Me.RibbonBarOptions_Payment.Name = "RibbonBarOptions_Payment"
            Me.RibbonBarOptions_Payment.SecurityEnabled = True
            Me.RibbonBarOptions_Payment.Size = New System.Drawing.Size(91, 92)
            Me.RibbonBarOptions_Payment.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Payment.TabIndex = 2
            Me.RibbonBarOptions_Payment.Text = "Payment"
            '
            '
            '
            Me.RibbonBarOptions_Payment.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Payment.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Payment.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemPayment_Apply
            '
            Me.ButtonItemPayment_Apply.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemPayment_Apply.Name = "ButtonItemPayment_Apply"
            Me.ButtonItemPayment_Apply.Text = "Apply"
            '
            'ButtonItemPayment_Undo
            '
            Me.ButtonItemPayment_Undo.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemPayment_Undo.Name = "ButtonItemPayment_Undo"
            Me.ButtonItemPayment_Undo.Text = "Undo"
            '
            'DataGridViewPanel_PaymentDetail
            '
            Me.DataGridViewPanel_PaymentDetail.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewPanel_PaymentDetail.AllowDragAndDrop = False
            Me.DataGridViewPanel_PaymentDetail.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewPanel_PaymentDetail.AllowSelectGroupHeaderRow = True
            Me.DataGridViewPanel_PaymentDetail.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewPanel_PaymentDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewPanel_PaymentDetail.AutoFilterLookupColumns = False
            Me.DataGridViewPanel_PaymentDetail.AutoloadRepositoryDatasource = True
            Me.DataGridViewPanel_PaymentDetail.AutoUpdateViewCaption = True
            Me.DataGridViewPanel_PaymentDetail.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewPanel_PaymentDetail.DataSource = Nothing
            Me.DataGridViewPanel_PaymentDetail.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewPanel_PaymentDetail.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewPanel_PaymentDetail.ItemDescription = "Client Cash Receipt Partial Payment(s)"
            Me.DataGridViewPanel_PaymentDetail.Location = New System.Drawing.Point(4, 59)
            Me.DataGridViewPanel_PaymentDetail.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewPanel_PaymentDetail.MultiSelect = True
            Me.DataGridViewPanel_PaymentDetail.Name = "DataGridViewPanel_PaymentDetail"
            Me.DataGridViewPanel_PaymentDetail.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewPanel_PaymentDetail.RunStandardValidation = True
            Me.DataGridViewPanel_PaymentDetail.ShowColumnMenuOnRightClick = False
            Me.DataGridViewPanel_PaymentDetail.ShowSelectDeselectAllButtons = True
            Me.DataGridViewPanel_PaymentDetail.Size = New System.Drawing.Size(1003, 426)
            Me.DataGridViewPanel_PaymentDetail.TabIndex = 4
            Me.DataGridViewPanel_PaymentDetail.UseEmbeddedNavigator = False
            Me.DataGridViewPanel_PaymentDetail.ViewCaptionHeight = -1
            '
            'NumericInputPanel_Remaining
            '
            Me.NumericInputPanel_Remaining.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputPanel_Remaining.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputPanel_Remaining.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputPanel_Remaining.EnterMoveNextControl = True
            Me.NumericInputPanel_Remaining.Location = New System.Drawing.Point(158, 32)
            Me.NumericInputPanel_Remaining.Name = "NumericInputPanel_Remaining"
            Me.NumericInputPanel_Remaining.Properties.AllowMouseWheel = False
            Me.NumericInputPanel_Remaining.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control
            Me.NumericInputPanel_Remaining.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputPanel_Remaining.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputPanel_Remaining.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputPanel_Remaining.Properties.EditFormat.FormatString = "f"
            Me.NumericInputPanel_Remaining.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputPanel_Remaining.Properties.Mask.EditMask = "f"
            Me.NumericInputPanel_Remaining.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputPanel_Remaining.Properties.ReadOnly = True
            Me.NumericInputPanel_Remaining.SecurityEnabled = True
            Me.NumericInputPanel_Remaining.Size = New System.Drawing.Size(115, 20)
            Me.NumericInputPanel_Remaining.TabIndex = 3
            Me.NumericInputPanel_Remaining.TabStop = False
            '
            'LabelPanel_Remaining
            '
            Me.LabelPanel_Remaining.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPanel_Remaining.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPanel_Remaining.Location = New System.Drawing.Point(3, 32)
            Me.LabelPanel_Remaining.Name = "LabelPanel_Remaining"
            Me.LabelPanel_Remaining.Size = New System.Drawing.Size(149, 20)
            Me.LabelPanel_Remaining.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPanel_Remaining.TabIndex = 2
            Me.LabelPanel_Remaining.Text = "Remaining:"
            '
            'NumericInputPanel_BalanceToPaymentAmount
            '
            Me.NumericInputPanel_BalanceToPaymentAmount.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputPanel_BalanceToPaymentAmount.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputPanel_BalanceToPaymentAmount.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputPanel_BalanceToPaymentAmount.EnterMoveNextControl = True
            Me.NumericInputPanel_BalanceToPaymentAmount.Location = New System.Drawing.Point(158, 6)
            Me.NumericInputPanel_BalanceToPaymentAmount.Name = "NumericInputPanel_BalanceToPaymentAmount"
            Me.NumericInputPanel_BalanceToPaymentAmount.Properties.AllowMouseWheel = False
            Me.NumericInputPanel_BalanceToPaymentAmount.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control
            Me.NumericInputPanel_BalanceToPaymentAmount.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputPanel_BalanceToPaymentAmount.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputPanel_BalanceToPaymentAmount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputPanel_BalanceToPaymentAmount.Properties.EditFormat.FormatString = "f"
            Me.NumericInputPanel_BalanceToPaymentAmount.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputPanel_BalanceToPaymentAmount.Properties.Mask.EditMask = "f"
            Me.NumericInputPanel_BalanceToPaymentAmount.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputPanel_BalanceToPaymentAmount.Properties.ReadOnly = True
            Me.NumericInputPanel_BalanceToPaymentAmount.SecurityEnabled = True
            Me.NumericInputPanel_BalanceToPaymentAmount.Size = New System.Drawing.Size(115, 20)
            Me.NumericInputPanel_BalanceToPaymentAmount.TabIndex = 1
            Me.NumericInputPanel_BalanceToPaymentAmount.TabStop = False
            '
            'LabelPanel_BalanceToPaymentAmount
            '
            Me.LabelPanel_BalanceToPaymentAmount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPanel_BalanceToPaymentAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPanel_BalanceToPaymentAmount.Location = New System.Drawing.Point(3, 6)
            Me.LabelPanel_BalanceToPaymentAmount.Name = "LabelPanel_BalanceToPaymentAmount"
            Me.LabelPanel_BalanceToPaymentAmount.Size = New System.Drawing.Size(149, 20)
            Me.LabelPanel_BalanceToPaymentAmount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPanel_BalanceToPaymentAmount.TabIndex = 0
            Me.LabelPanel_BalanceToPaymentAmount.Text = "Balance to Payment Amount:"
            '
            'RibbonBarOptions_Balance
            '
            Me.RibbonBarOptions_Balance.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBarOptions_Balance.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Balance.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Balance.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Balance.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Balance.DragDropSupport = True
            Me.RibbonBarOptions_Balance.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerBalance_Vertical})
            Me.RibbonBarOptions_Balance.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Balance.Location = New System.Drawing.Point(285, 0)
            Me.RibbonBarOptions_Balance.Name = "RibbonBarOptions_Balance"
            Me.RibbonBarOptions_Balance.SecurityEnabled = True
            Me.RibbonBarOptions_Balance.Size = New System.Drawing.Size(111, 92)
            Me.RibbonBarOptions_Balance.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Balance.TabIndex = 3
            Me.RibbonBarOptions_Balance.Text = "Current Balance"
            '
            '
            '
            Me.RibbonBarOptions_Balance.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Balance.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Balance.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ItemContainerBalance_Vertical
            '
            '
            '
            '
            Me.ItemContainerBalance_Vertical.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerBalance_Vertical.FixedSize = New System.Drawing.Size(100, 0)
            Me.ItemContainerBalance_Vertical.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerBalance_Vertical.Name = "ItemContainerBalance_Vertical"
            Me.ItemContainerBalance_Vertical.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerVertical_Horizontal})
            '
            '
            '
            Me.ItemContainerBalance_Vertical.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerBalance_Vertical.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ItemContainerVertical_Horizontal
            '
            '
            '
            '
            Me.ItemContainerVertical_Horizontal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerVertical_Horizontal.FixedSize = New System.Drawing.Size(100, 0)
            Me.ItemContainerVertical_Horizontal.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.ItemContainerVertical_Horizontal.Name = "ItemContainerVertical_Horizontal"
            Me.ItemContainerVertical_Horizontal.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemBalance_CurrentBalance})
            '
            '
            '
            Me.ItemContainerVertical_Horizontal.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemBalance_CurrentBalance
            '
            Me.LabelItemBalance_CurrentBalance.Name = "LabelItemBalance_CurrentBalance"
            Me.LabelItemBalance_CurrentBalance.Stretch = True
            Me.LabelItemBalance_CurrentBalance.Text = "LabelItem1"
            Me.LabelItemBalance_CurrentBalance.TextAlignment = System.Drawing.StringAlignment.Center
            '
            'ClientCashReceiptPartialPaymentEditDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1021, 664)
            Me.CloseButtonVisible = False
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "ClientCashReceiptPartialPaymentEditDialog"
            Me.Text = "Client Cash Receipt Partial Payment"
            Me.Controls.SetChildIndex(Me.BarForm_StatusBar, 0)
            Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
            Me.Controls.SetChildIndex(Me.PanelForm_Form, 0)
            Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.PerformLayout()
            Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Form.ResumeLayout(False)
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputPanel_Remaining.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputPanel_BalanceToPaymentAmount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Save As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Payment As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemPayment_Apply As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemPayment_Undo As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents DataGridViewPanel_PaymentDetail As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents NumericInputPanel_Remaining As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents LabelPanel_Remaining As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents NumericInputPanel_BalanceToPaymentAmount As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents LabelPanel_BalanceToPaymentAmount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents RibbonBarOptions_Balance As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ItemContainerBalance_Vertical As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ItemContainerVertical_Horizontal As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemBalance_CurrentBalance As DevComponents.DotNetBar.LabelItem
    End Class

End Namespace