Namespace FinanceAndAccounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ClientCashReceiptForm
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm

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
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ClientCashReceiptForm))
            Me.PanelForm_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewLeftSection_ClientReceipts = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.DataGridViewLeftSection_CashReceiptDetail = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.DataGridViewLeftSection_OtherReceipts = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ExpandableSplitterControlForm_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelForm_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.ClientCashReceiptControlRightSection_CR = New AdvantageFramework.WinForm.Presentation.Controls.ClientCashReceiptControl()
            Me.OtherCashReceiptControlRightSection_OCR = New AdvantageFramework.WinForm.Presentation.Controls.OtherCashReceiptControl()
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_OtherCashReceiptDetail = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemOtherCashReceiptDetail_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemOtherCashReceiptDetail_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Writeoff = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemWriteoff_Apply = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemWriteoff_Undo = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_OnAccount = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemOnAccount_Apply = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemOnAccount_Undo = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Payment = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemPayment_Apply = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemPayment_Partial = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemPayment_Undo = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_InvoiceDetails = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemInvoiceDetails_ShowAllOpen = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_DefaultNew = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemDefaultNew_LastBank = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_View = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemView_OtherReceipts = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ItemContainerActions_View = New DevComponents.DotNetBar.ItemContainer()
            Me.ComboBoxItemActions_View = New DevComponents.DotNetBar.ComboBoxItem()
            Me.ButtonItemActions_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Print = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Import = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_AddSearch = New DevComponents.DotNetBar.ButtonItem()
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_LeftSection.SuspendLayout()
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_RightSection.SuspendLayout()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            Me.SuspendLayout()
            '
            'PanelForm_LeftSection
            '
            Me.PanelForm_LeftSection.Controls.Add(Me.DataGridViewLeftSection_ClientReceipts)
            Me.PanelForm_LeftSection.Controls.Add(Me.DataGridViewLeftSection_CashReceiptDetail)
            Me.PanelForm_LeftSection.Controls.Add(Me.DataGridViewLeftSection_OtherReceipts)
            Me.PanelForm_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelForm_LeftSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelForm_LeftSection.Name = "PanelForm_LeftSection"
            Me.PanelForm_LeftSection.Size = New System.Drawing.Size(197, 691)
            Me.PanelForm_LeftSection.TabIndex = 0
            '
            'DataGridViewLeftSection_ClientReceipts
            '
            Me.DataGridViewLeftSection_ClientReceipts.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewLeftSection_ClientReceipts.AllowDragAndDrop = False
            Me.DataGridViewLeftSection_ClientReceipts.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewLeftSection_ClientReceipts.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_ClientReceipts.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewLeftSection_ClientReceipts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_ClientReceipts.AutoFilterLookupColumns = False
            Me.DataGridViewLeftSection_ClientReceipts.AutoloadRepositoryDatasource = True
            Me.DataGridViewLeftSection_ClientReceipts.AutoUpdateViewCaption = True
            Me.DataGridViewLeftSection_ClientReceipts.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewLeftSection_ClientReceipts.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewLeftSection_ClientReceipts.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_ClientReceipts.ItemDescription = "Active Client(s)"
            Me.DataGridViewLeftSection_ClientReceipts.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewLeftSection_ClientReceipts.MultiSelect = True
            Me.DataGridViewLeftSection_ClientReceipts.Name = "DataGridViewLeftSection_ClientReceipts"
            Me.DataGridViewLeftSection_ClientReceipts.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_ClientReceipts.RunStandardValidation = True
            Me.DataGridViewLeftSection_ClientReceipts.ShowColumnMenuOnRightClick = False
            Me.DataGridViewLeftSection_ClientReceipts.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_ClientReceipts.Size = New System.Drawing.Size(180, 667)
            Me.DataGridViewLeftSection_ClientReceipts.TabIndex = 0
            Me.DataGridViewLeftSection_ClientReceipts.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_ClientReceipts.ViewCaptionHeight = -1
            '
            'DataGridViewLeftSection_CashReceiptDetail
            '
            Me.DataGridViewLeftSection_CashReceiptDetail.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewLeftSection_CashReceiptDetail.AllowDragAndDrop = False
            Me.DataGridViewLeftSection_CashReceiptDetail.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewLeftSection_CashReceiptDetail.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_CashReceiptDetail.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewLeftSection_CashReceiptDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_CashReceiptDetail.AutoFilterLookupColumns = False
            Me.DataGridViewLeftSection_CashReceiptDetail.AutoloadRepositoryDatasource = True
            Me.DataGridViewLeftSection_CashReceiptDetail.AutoUpdateViewCaption = True
            Me.DataGridViewLeftSection_CashReceiptDetail.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewLeftSection_CashReceiptDetail.DataSource = Nothing
            Me.DataGridViewLeftSection_CashReceiptDetail.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewLeftSection_CashReceiptDetail.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_CashReceiptDetail.ItemDescription = "Client Cash Receipts"
            Me.DataGridViewLeftSection_CashReceiptDetail.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewLeftSection_CashReceiptDetail.MultiSelect = True
            Me.DataGridViewLeftSection_CashReceiptDetail.Name = "DataGridViewLeftSection_CashReceiptDetail"
            Me.DataGridViewLeftSection_CashReceiptDetail.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_CashReceiptDetail.RunStandardValidation = True
            Me.DataGridViewLeftSection_CashReceiptDetail.ShowColumnMenuOnRightClick = False
            Me.DataGridViewLeftSection_CashReceiptDetail.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_CashReceiptDetail.Size = New System.Drawing.Size(180, 667)
            Me.DataGridViewLeftSection_CashReceiptDetail.TabIndex = 1
            Me.DataGridViewLeftSection_CashReceiptDetail.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_CashReceiptDetail.ViewCaptionHeight = -1
            '
            'DataGridViewLeftSection_OtherReceipts
            '
            Me.DataGridViewLeftSection_OtherReceipts.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewLeftSection_OtherReceipts.AllowDragAndDrop = False
            Me.DataGridViewLeftSection_OtherReceipts.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewLeftSection_OtherReceipts.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_OtherReceipts.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewLeftSection_OtherReceipts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_OtherReceipts.AutoFilterLookupColumns = False
            Me.DataGridViewLeftSection_OtherReceipts.AutoloadRepositoryDatasource = True
            Me.DataGridViewLeftSection_OtherReceipts.AutoUpdateViewCaption = True
            Me.DataGridViewLeftSection_OtherReceipts.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewLeftSection_OtherReceipts.DataSource = Nothing
            Me.DataGridViewLeftSection_OtherReceipts.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewLeftSection_OtherReceipts.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_OtherReceipts.ItemDescription = "Other Cash Receipt(s)"
            Me.DataGridViewLeftSection_OtherReceipts.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewLeftSection_OtherReceipts.MultiSelect = True
            Me.DataGridViewLeftSection_OtherReceipts.Name = "DataGridViewLeftSection_OtherReceipts"
            Me.DataGridViewLeftSection_OtherReceipts.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_OtherReceipts.RunStandardValidation = True
            Me.DataGridViewLeftSection_OtherReceipts.ShowColumnMenuOnRightClick = False
            Me.DataGridViewLeftSection_OtherReceipts.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_OtherReceipts.Size = New System.Drawing.Size(180, 667)
            Me.DataGridViewLeftSection_OtherReceipts.TabIndex = 2
            Me.DataGridViewLeftSection_OtherReceipts.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_OtherReceipts.ViewCaptionHeight = -1
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
            Me.ExpandableSplitterControlForm_LeftRight.Location = New System.Drawing.Point(197, 0)
            Me.ExpandableSplitterControlForm_LeftRight.Name = "ExpandableSplitterControlForm_LeftRight"
            Me.ExpandableSplitterControlForm_LeftRight.Size = New System.Drawing.Size(6, 691)
            Me.ExpandableSplitterControlForm_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControlForm_LeftRight.TabIndex = 1
            Me.ExpandableSplitterControlForm_LeftRight.TabStop = False
            '
            'PanelForm_RightSection
            '
            Me.PanelForm_RightSection.Controls.Add(Me.ClientCashReceiptControlRightSection_CR)
            Me.PanelForm_RightSection.Controls.Add(Me.OtherCashReceiptControlRightSection_OCR)
            Me.PanelForm_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelForm_RightSection.Location = New System.Drawing.Point(203, 0)
            Me.PanelForm_RightSection.Name = "PanelForm_RightSection"
            Me.PanelForm_RightSection.Size = New System.Drawing.Size(1078, 691)
            Me.PanelForm_RightSection.TabIndex = 2
            '
            'ClientCashReceiptControlRightSection_CR
            '
            Me.ClientCashReceiptControlRightSection_CR.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ClientCashReceiptControlRightSection_CR.Location = New System.Drawing.Point(6, 12)
            Me.ClientCashReceiptControlRightSection_CR.Name = "ClientCashReceiptControlRightSection_CR"
            Me.ClientCashReceiptControlRightSection_CR.Size = New System.Drawing.Size(1060, 667)
            Me.ClientCashReceiptControlRightSection_CR.TabIndex = 0
            '
            'OtherCashReceiptControlRightSection_OCR
            '
            Me.OtherCashReceiptControlRightSection_OCR.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.OtherCashReceiptControlRightSection_OCR.Location = New System.Drawing.Point(6, 12)
            Me.OtherCashReceiptControlRightSection_OCR.Name = "OtherCashReceiptControlRightSection_OCR"
            Me.OtherCashReceiptControlRightSection_OCR.Size = New System.Drawing.Size(1060, 667)
            Me.OtherCashReceiptControlRightSection_OCR.TabIndex = 1
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_OtherCashReceiptDetail)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Writeoff)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_OnAccount)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Payment)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_InvoiceDetails)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_DefaultNew)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_View)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(5, 0)
            Me.RibbonBarMergeContainerForm_Options.MergeRibbonGroupName = "RibbonTabGroupDynamicReport"
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(1264, 98)
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
            Me.RibbonBarMergeContainerForm_Options.TabIndex = 7
            Me.RibbonBarMergeContainerForm_Options.Visible = False
            '
            'RibbonBarOptions_OtherCashReceiptDetail
            '
            Me.RibbonBarOptions_OtherCashReceiptDetail.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBarOptions_OtherCashReceiptDetail.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_OtherCashReceiptDetail.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_OtherCashReceiptDetail.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_OtherCashReceiptDetail.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_OtherCashReceiptDetail.DragDropSupport = True
            Me.RibbonBarOptions_OtherCashReceiptDetail.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemOtherCashReceiptDetail_Delete, Me.ButtonItemOtherCashReceiptDetail_Cancel})
            Me.RibbonBarOptions_OtherCashReceiptDetail.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_OtherCashReceiptDetail.Location = New System.Drawing.Point(995, 0)
            Me.RibbonBarOptions_OtherCashReceiptDetail.Name = "RibbonBarOptions_OtherCashReceiptDetail"
            Me.RibbonBarOptions_OtherCashReceiptDetail.SecurityEnabled = True
            Me.RibbonBarOptions_OtherCashReceiptDetail.Size = New System.Drawing.Size(116, 98)
            Me.RibbonBarOptions_OtherCashReceiptDetail.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_OtherCashReceiptDetail.TabIndex = 15
            Me.RibbonBarOptions_OtherCashReceiptDetail.Text = "Receipt Detail"
            '
            '
            '
            Me.RibbonBarOptions_OtherCashReceiptDetail.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_OtherCashReceiptDetail.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_OtherCashReceiptDetail.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemOtherCashReceiptDetail_Delete
            '
            Me.ButtonItemOtherCashReceiptDetail_Delete.BeginGroup = True
            Me.ButtonItemOtherCashReceiptDetail_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemOtherCashReceiptDetail_Delete.Name = "ButtonItemOtherCashReceiptDetail_Delete"
            Me.ButtonItemOtherCashReceiptDetail_Delete.RibbonWordWrap = False
            Me.ButtonItemOtherCashReceiptDetail_Delete.SecurityEnabled = True
            Me.ButtonItemOtherCashReceiptDetail_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemOtherCashReceiptDetail_Delete.Text = "Delete"
            '
            'ButtonItemOtherCashReceiptDetail_Cancel
            '
            Me.ButtonItemOtherCashReceiptDetail_Cancel.BeginGroup = True
            Me.ButtonItemOtherCashReceiptDetail_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemOtherCashReceiptDetail_Cancel.Name = "ButtonItemOtherCashReceiptDetail_Cancel"
            Me.ButtonItemOtherCashReceiptDetail_Cancel.RibbonWordWrap = False
            Me.ButtonItemOtherCashReceiptDetail_Cancel.SecurityEnabled = True
            Me.ButtonItemOtherCashReceiptDetail_Cancel.SubItemsExpandWidth = 14
            Me.ButtonItemOtherCashReceiptDetail_Cancel.Text = "Cancel"
            '
            'RibbonBarOptions_Writeoff
            '
            Me.RibbonBarOptions_Writeoff.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBarOptions_Writeoff.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Writeoff.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Writeoff.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Writeoff.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Writeoff.DragDropSupport = True
            Me.RibbonBarOptions_Writeoff.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemWriteoff_Apply, Me.ButtonItemWriteoff_Undo})
            Me.RibbonBarOptions_Writeoff.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Writeoff.Location = New System.Drawing.Point(879, 0)
            Me.RibbonBarOptions_Writeoff.Name = "RibbonBarOptions_Writeoff"
            Me.RibbonBarOptions_Writeoff.SecurityEnabled = True
            Me.RibbonBarOptions_Writeoff.Size = New System.Drawing.Size(116, 98)
            Me.RibbonBarOptions_Writeoff.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Writeoff.TabIndex = 12
            Me.RibbonBarOptions_Writeoff.Text = "Write Off"
            '
            '
            '
            Me.RibbonBarOptions_Writeoff.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Writeoff.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Writeoff.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemWriteoff_Apply
            '
            Me.ButtonItemWriteoff_Apply.BeginGroup = True
            Me.ButtonItemWriteoff_Apply.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemWriteoff_Apply.Name = "ButtonItemWriteoff_Apply"
            Me.ButtonItemWriteoff_Apply.RibbonWordWrap = False
            Me.ButtonItemWriteoff_Apply.SecurityEnabled = True
            Me.ButtonItemWriteoff_Apply.SubItemsExpandWidth = 14
            Me.ButtonItemWriteoff_Apply.Text = "Apply"
            '
            'ButtonItemWriteoff_Undo
            '
            Me.ButtonItemWriteoff_Undo.BeginGroup = True
            Me.ButtonItemWriteoff_Undo.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemWriteoff_Undo.Name = "ButtonItemWriteoff_Undo"
            Me.ButtonItemWriteoff_Undo.RibbonWordWrap = False
            Me.ButtonItemWriteoff_Undo.SecurityEnabled = True
            Me.ButtonItemWriteoff_Undo.SubItemsExpandWidth = 14
            Me.ButtonItemWriteoff_Undo.Text = "Undo"
            '
            'RibbonBarOptions_OnAccount
            '
            Me.RibbonBarOptions_OnAccount.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBarOptions_OnAccount.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_OnAccount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_OnAccount.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_OnAccount.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_OnAccount.DragDropSupport = True
            Me.RibbonBarOptions_OnAccount.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemOnAccount_Apply, Me.ButtonItemOnAccount_Undo})
            Me.RibbonBarOptions_OnAccount.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_OnAccount.Location = New System.Drawing.Point(763, 0)
            Me.RibbonBarOptions_OnAccount.Name = "RibbonBarOptions_OnAccount"
            Me.RibbonBarOptions_OnAccount.SecurityEnabled = True
            Me.RibbonBarOptions_OnAccount.Size = New System.Drawing.Size(116, 98)
            Me.RibbonBarOptions_OnAccount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_OnAccount.TabIndex = 13
            Me.RibbonBarOptions_OnAccount.Text = "On Account"
            '
            '
            '
            Me.RibbonBarOptions_OnAccount.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_OnAccount.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_OnAccount.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemOnAccount_Apply
            '
            Me.ButtonItemOnAccount_Apply.BeginGroup = True
            Me.ButtonItemOnAccount_Apply.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemOnAccount_Apply.Name = "ButtonItemOnAccount_Apply"
            Me.ButtonItemOnAccount_Apply.RibbonWordWrap = False
            Me.ButtonItemOnAccount_Apply.SecurityEnabled = True
            Me.ButtonItemOnAccount_Apply.SubItemsExpandWidth = 14
            Me.ButtonItemOnAccount_Apply.Text = "Apply"
            '
            'ButtonItemOnAccount_Undo
            '
            Me.ButtonItemOnAccount_Undo.BeginGroup = True
            Me.ButtonItemOnAccount_Undo.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemOnAccount_Undo.Name = "ButtonItemOnAccount_Undo"
            Me.ButtonItemOnAccount_Undo.RibbonWordWrap = False
            Me.ButtonItemOnAccount_Undo.SecurityEnabled = True
            Me.ButtonItemOnAccount_Undo.SubItemsExpandWidth = 14
            Me.ButtonItemOnAccount_Undo.Text = "Undo"
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
            Me.RibbonBarOptions_Payment.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemPayment_Apply, Me.ButtonItemPayment_Partial, Me.ButtonItemPayment_Undo})
            Me.RibbonBarOptions_Payment.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Payment.Location = New System.Drawing.Point(647, 0)
            Me.RibbonBarOptions_Payment.Name = "RibbonBarOptions_Payment"
            Me.RibbonBarOptions_Payment.SecurityEnabled = True
            Me.RibbonBarOptions_Payment.Size = New System.Drawing.Size(116, 98)
            Me.RibbonBarOptions_Payment.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Payment.TabIndex = 11
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
            Me.ButtonItemPayment_Apply.BeginGroup = True
            Me.ButtonItemPayment_Apply.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemPayment_Apply.Name = "ButtonItemPayment_Apply"
            Me.ButtonItemPayment_Apply.RibbonWordWrap = False
            Me.ButtonItemPayment_Apply.SecurityEnabled = True
            Me.ButtonItemPayment_Apply.SubItemsExpandWidth = 14
            Me.ButtonItemPayment_Apply.Text = "Apply"
            '
            'ButtonItemPayment_Partial
            '
            Me.ButtonItemPayment_Partial.BeginGroup = True
            Me.ButtonItemPayment_Partial.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemPayment_Partial.Name = "ButtonItemPayment_Partial"
            Me.ButtonItemPayment_Partial.RibbonWordWrap = False
            Me.ButtonItemPayment_Partial.SecurityEnabled = True
            Me.ButtonItemPayment_Partial.SubItemsExpandWidth = 14
            Me.ButtonItemPayment_Partial.Text = "Partial"
            '
            'ButtonItemPayment_Undo
            '
            Me.ButtonItemPayment_Undo.BeginGroup = True
            Me.ButtonItemPayment_Undo.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemPayment_Undo.Name = "ButtonItemPayment_Undo"
            Me.ButtonItemPayment_Undo.RibbonWordWrap = False
            Me.ButtonItemPayment_Undo.SecurityEnabled = True
            Me.ButtonItemPayment_Undo.SubItemsExpandWidth = 14
            Me.ButtonItemPayment_Undo.Text = "Undo"
            '
            'RibbonBarOptions_InvoiceDetails
            '
            Me.RibbonBarOptions_InvoiceDetails.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBarOptions_InvoiceDetails.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_InvoiceDetails.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_InvoiceDetails.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_InvoiceDetails.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_InvoiceDetails.DragDropSupport = True
            Me.RibbonBarOptions_InvoiceDetails.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemInvoiceDetails_ShowAllOpen})
            Me.RibbonBarOptions_InvoiceDetails.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_InvoiceDetails.Location = New System.Drawing.Point(562, 0)
            Me.RibbonBarOptions_InvoiceDetails.Name = "RibbonBarOptions_InvoiceDetails"
            Me.RibbonBarOptions_InvoiceDetails.SecurityEnabled = True
            Me.RibbonBarOptions_InvoiceDetails.Size = New System.Drawing.Size(85, 98)
            Me.RibbonBarOptions_InvoiceDetails.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_InvoiceDetails.TabIndex = 14
            Me.RibbonBarOptions_InvoiceDetails.Text = "Invoice Details"
            '
            '
            '
            Me.RibbonBarOptions_InvoiceDetails.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_InvoiceDetails.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_InvoiceDetails.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemInvoiceDetails_ShowAllOpen
            '
            Me.ButtonItemInvoiceDetails_ShowAllOpen.BeginGroup = True
            Me.ButtonItemInvoiceDetails_ShowAllOpen.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemInvoiceDetails_ShowAllOpen.Name = "ButtonItemInvoiceDetails_ShowAllOpen"
            Me.ButtonItemInvoiceDetails_ShowAllOpen.RibbonWordWrap = False
            Me.ButtonItemInvoiceDetails_ShowAllOpen.SecurityEnabled = True
            Me.ButtonItemInvoiceDetails_ShowAllOpen.SubItemsExpandWidth = 14
            Me.ButtonItemInvoiceDetails_ShowAllOpen.Text = "Show All Open"
            '
            'RibbonBarOptions_DefaultNew
            '
            Me.RibbonBarOptions_DefaultNew.AutoOverflowEnabled = True
            Me.RibbonBarOptions_DefaultNew.AutoSizeItems = False
            '
            '
            '
            Me.RibbonBarOptions_DefaultNew.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_DefaultNew.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_DefaultNew.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_DefaultNew.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_DefaultNew.DragDropSupport = True
            Me.RibbonBarOptions_DefaultNew.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemDefaultNew_LastBank})
            Me.RibbonBarOptions_DefaultNew.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_DefaultNew.Location = New System.Drawing.Point(485, 0)
            Me.RibbonBarOptions_DefaultNew.Name = "RibbonBarOptions_DefaultNew"
            Me.RibbonBarOptions_DefaultNew.SecurityEnabled = True
            Me.RibbonBarOptions_DefaultNew.Size = New System.Drawing.Size(77, 98)
            Me.RibbonBarOptions_DefaultNew.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_DefaultNew.TabIndex = 16
            Me.RibbonBarOptions_DefaultNew.Text = "Default New"
            '
            '
            '
            Me.RibbonBarOptions_DefaultNew.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_DefaultNew.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_DefaultNew.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemDefaultNew_LastBank
            '
            Me.ButtonItemDefaultNew_LastBank.AutoCheckOnClick = True
            Me.ButtonItemDefaultNew_LastBank.BeginGroup = True
            Me.ButtonItemDefaultNew_LastBank.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDefaultNew_LastBank.Name = "ButtonItemDefaultNew_LastBank"
            Me.ButtonItemDefaultNew_LastBank.RibbonWordWrap = False
            Me.ButtonItemDefaultNew_LastBank.SecurityEnabled = True
            Me.ButtonItemDefaultNew_LastBank.SubItemsExpandWidth = 14
            Me.ButtonItemDefaultNew_LastBank.Text = "Use Last Bank"
            '
            'RibbonBarOptions_View
            '
            Me.RibbonBarOptions_View.AutoOverflowEnabled = True
            Me.RibbonBarOptions_View.AutoSizeItems = False
            '
            '
            '
            Me.RibbonBarOptions_View.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_View.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_View.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_View.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_View.DragDropSupport = True
            Me.RibbonBarOptions_View.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemView_OtherReceipts})
            Me.RibbonBarOptions_View.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_View.Location = New System.Drawing.Point(408, 0)
            Me.RibbonBarOptions_View.Name = "RibbonBarOptions_View"
            Me.RibbonBarOptions_View.SecurityEnabled = True
            Me.RibbonBarOptions_View.Size = New System.Drawing.Size(77, 98)
            Me.RibbonBarOptions_View.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_View.TabIndex = 17
            Me.RibbonBarOptions_View.Text = "View"
            '
            '
            '
            Me.RibbonBarOptions_View.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_View.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_View.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemView_OtherReceipts
            '
            Me.ButtonItemView_OtherReceipts.AutoCheckOnClick = True
            Me.ButtonItemView_OtherReceipts.BeginGroup = True
            Me.ButtonItemView_OtherReceipts.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemView_OtherReceipts.Name = "ButtonItemView_OtherReceipts"
            Me.ButtonItemView_OtherReceipts.RibbonWordWrap = False
            Me.ButtonItemView_OtherReceipts.SecurityEnabled = True
            Me.ButtonItemView_OtherReceipts.SubItemsExpandWidth = 14
            Me.ButtonItemView_OtherReceipts.Text = "Other Receipts"
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerActions_View, Me.ButtonItemActions_Add, Me.ButtonItemActions_Save, Me.ButtonItemActions_Delete, Me.ButtonItemActions_Print, Me.ButtonItemActions_Import})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(408, 98)
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
            Me.RibbonBarOptions_Actions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ItemContainerActions_View
            '
            '
            '
            '
            Me.ItemContainerActions_View.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerActions_View.FixedSize = New System.Drawing.Size(150, 0)
            Me.ItemContainerActions_View.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerActions_View.Name = "ItemContainerActions_View"
            Me.ItemContainerActions_View.ResizeItemsToFit = False
            Me.ItemContainerActions_View.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ComboBoxItemActions_View})
            '
            '
            '
            Me.ItemContainerActions_View.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerActions_View.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ComboBoxItemActions_View
            '
            Me.ComboBoxItemActions_View.ComboWidth = 140
            Me.ComboBoxItemActions_View.DropDownHeight = 106
            Me.ComboBoxItemActions_View.Name = "ComboBoxItemActions_View"
            Me.ComboBoxItemActions_View.Text = "ComboBoxItem1"
            '
            'ButtonItemActions_Add
            '
            Me.ButtonItemActions_Add.BeginGroup = True
            Me.ButtonItemActions_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Add.Name = "ButtonItemActions_Add"
            Me.ButtonItemActions_Add.RibbonWordWrap = False
            Me.ButtonItemActions_Add.SecurityEnabled = True
            Me.ButtonItemActions_Add.SplitButton = True
            Me.ButtonItemActions_Add.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_AddSearch})
            Me.ButtonItemActions_Add.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Add.Text = "Add"
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
            'ButtonItemActions_Delete
            '
            Me.ButtonItemActions_Delete.BeginGroup = True
            Me.ButtonItemActions_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Delete.Name = "ButtonItemActions_Delete"
            Me.ButtonItemActions_Delete.RibbonWordWrap = False
            Me.ButtonItemActions_Delete.SecurityEnabled = True
            Me.ButtonItemActions_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Delete.Text = "Delete"
            '
            'ButtonItemActions_Print
            '
            Me.ButtonItemActions_Print.BeginGroup = True
            Me.ButtonItemActions_Print.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Print.Name = "ButtonItemActions_Print"
            Me.ButtonItemActions_Print.RibbonWordWrap = False
            Me.ButtonItemActions_Print.SecurityEnabled = True
            Me.ButtonItemActions_Print.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Print.Text = "Print"
            '
            'ButtonItemActions_Import
            '
            Me.ButtonItemActions_Import.BeginGroup = True
            Me.ButtonItemActions_Import.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Import.Name = "ButtonItemActions_Import"
            Me.ButtonItemActions_Import.RibbonWordWrap = False
            Me.ButtonItemActions_Import.SecurityEnabled = True
            Me.ButtonItemActions_Import.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Import.Text = "Import"
            '
            'ButtonItemActions_AddSearch
            '
            Me.ButtonItemActions_AddSearch.Name = "ButtonItemActions_AddSearch"
            Me.ButtonItemActions_AddSearch.Text = "Search for Invoice"
            '
            'ClientCashReceiptForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1281, 691)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.PanelForm_RightSection)
            Me.Controls.Add(Me.ExpandableSplitterControlForm_LeftRight)
            Me.Controls.Add(Me.PanelForm_LeftSection)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "ClientCashReceiptForm"
            Me.Text = "Cash Receipts"
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_LeftSection.ResumeLayout(False)
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_RightSection.ResumeLayout(False)
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents PanelForm_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents ExpandableSplitterControlForm_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelForm_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewLeftSection_ClientReceipts As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ClientCashReceiptControlRightSection_CR As AdvantageFramework.WinForm.Presentation.Controls.ClientCashReceiptControl
        Friend WithEvents ItemContainerActions_View As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ComboBoxItemActions_View As DevComponents.DotNetBar.ComboBoxItem
        Friend WithEvents DataGridViewLeftSection_CashReceiptDetail As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarOptions_Payment As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents RibbonBarOptions_OnAccount As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents RibbonBarOptions_InvoiceDetails As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemInvoiceDetails_ShowAllOpen As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemOnAccount_Apply As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemOnAccount_Undo As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Writeoff As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemWriteoff_Apply As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemWriteoff_Undo As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemPayment_Apply As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemPayment_Undo As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Add As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Save As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Print As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents DataGridViewLeftSection_OtherReceipts As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents OtherCashReceiptControlRightSection_OCR As AdvantageFramework.WinForm.Presentation.Controls.OtherCashReceiptControl
        Friend WithEvents RibbonBarOptions_OtherCashReceiptDetail As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemOtherCashReceiptDetail_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemOtherCashReceiptDetail_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemPayment_Partial As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_DefaultNew As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemDefaultNew_LastBank As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_View As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemView_OtherReceipts As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Import As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_AddSearch As DevComponents.DotNetBar.ButtonItem
    End Class

End Namespace

