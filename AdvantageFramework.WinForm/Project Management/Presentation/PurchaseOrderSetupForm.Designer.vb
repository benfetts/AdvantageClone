Namespace ProjectManagement.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class PurchaseOrderSetupForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PurchaseOrderSetupForm))
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Details = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemDetails_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDetails_Copy = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDetails_CopyFrom = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDetails_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDetails_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDetails_Estimate = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDetails_AP = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Spelling = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemSpelling_CheckSpelling = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ComboBoxActions_SearchBy = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ItemContainerActions_ItemContainer = New DevComponents.DotNetBar.ItemContainer()
            Me.ControlContainerItemSearch_ComboBox = New DevComponents.DotNetBar.ControlContainerItem()
            Me.ButtonItemActions_Export = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Void = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Copy = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Revise = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_CancelApproval = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_PrintOrSend = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.PanelForm_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.PurchaseOrderControlRightSection_PurchaseOrder = New AdvantageFramework.WinForm.Presentation.Controls.PurchaseOrderControl()
            Me.PanelForm_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewLeftSection_PODetails = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.DataGridViewLeftSection_PurchaseOrders = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ExpandableSplitterControl1 = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.ButtonItemActions_Refresh = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            Me.RibbonBarOptions_Actions.SuspendLayout()
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_RightSection.SuspendLayout()
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_LeftSection.SuspendLayout()
            Me.SuspendLayout()
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Details)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Spelling)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(5, 343)
            Me.RibbonBarMergeContainerForm_Options.MergeRibbonGroupName = "RibbonTabGroupDynamicReport"
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(989, 98)
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
            'RibbonBarOptions_Details
            '
            Me.RibbonBarOptions_Details.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Details.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Details.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Details.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Details.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Details.DragDropSupport = True
            Me.RibbonBarOptions_Details.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemDetails_Add, Me.ButtonItemDetails_Copy, Me.ButtonItemDetails_CopyFrom, Me.ButtonItemDetails_Delete, Me.ButtonItemDetails_Cancel, Me.ButtonItemDetails_Estimate, Me.ButtonItemDetails_AP})
            Me.RibbonBarOptions_Details.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Details.Location = New System.Drawing.Point(661, 0)
            Me.RibbonBarOptions_Details.Name = "RibbonBarOptions_Details"
            Me.RibbonBarOptions_Details.SecurityEnabled = True
            Me.RibbonBarOptions_Details.Size = New System.Drawing.Size(324, 98)
            Me.RibbonBarOptions_Details.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Details.TabIndex = 2
            Me.RibbonBarOptions_Details.Text = "Details"
            '
            '
            '
            Me.RibbonBarOptions_Details.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Details.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Details.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemDetails_Add
            '
            Me.ButtonItemDetails_Add.BeginGroup = True
            Me.ButtonItemDetails_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDetails_Add.Name = "ButtonItemDetails_Add"
            Me.ButtonItemDetails_Add.RibbonWordWrap = False
            Me.ButtonItemDetails_Add.SecurityEnabled = True
            Me.ButtonItemDetails_Add.SubItemsExpandWidth = 14
            Me.ButtonItemDetails_Add.Text = "Add"
            '
            'ButtonItemDetails_Copy
            '
            Me.ButtonItemDetails_Copy.BeginGroup = True
            Me.ButtonItemDetails_Copy.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDetails_Copy.Name = "ButtonItemDetails_Copy"
            Me.ButtonItemDetails_Copy.RibbonWordWrap = False
            Me.ButtonItemDetails_Copy.SecurityEnabled = True
            Me.ButtonItemDetails_Copy.SubItemsExpandWidth = 14
            Me.ButtonItemDetails_Copy.Text = "Copy"
            '
            'ButtonItemDetails_CopyFrom
            '
            Me.ButtonItemDetails_CopyFrom.BeginGroup = True
            Me.ButtonItemDetails_CopyFrom.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDetails_CopyFrom.Name = "ButtonItemDetails_CopyFrom"
            Me.ButtonItemDetails_CopyFrom.RibbonWordWrap = False
            Me.ButtonItemDetails_CopyFrom.SecurityEnabled = True
            Me.ButtonItemDetails_CopyFrom.SubItemsExpandWidth = 14
            Me.ButtonItemDetails_CopyFrom.Text = "Copy From"
            '
            'ButtonItemDetails_Delete
            '
            Me.ButtonItemDetails_Delete.BeginGroup = True
            Me.ButtonItemDetails_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDetails_Delete.Name = "ButtonItemDetails_Delete"
            Me.ButtonItemDetails_Delete.RibbonWordWrap = False
            Me.ButtonItemDetails_Delete.SecurityEnabled = True
            Me.ButtonItemDetails_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemDetails_Delete.Text = "Delete"
            '
            'ButtonItemDetails_Cancel
            '
            Me.ButtonItemDetails_Cancel.BeginGroup = True
            Me.ButtonItemDetails_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDetails_Cancel.Name = "ButtonItemDetails_Cancel"
            Me.ButtonItemDetails_Cancel.RibbonWordWrap = False
            Me.ButtonItemDetails_Cancel.SecurityEnabled = True
            Me.ButtonItemDetails_Cancel.SubItemsExpandWidth = 14
            Me.ButtonItemDetails_Cancel.Text = "Cancel"
            '
            'ButtonItemDetails_Estimate
            '
            Me.ButtonItemDetails_Estimate.BeginGroup = True
            Me.ButtonItemDetails_Estimate.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDetails_Estimate.Name = "ButtonItemDetails_Estimate"
            Me.ButtonItemDetails_Estimate.RibbonWordWrap = False
            Me.ButtonItemDetails_Estimate.SecurityEnabled = True
            Me.ButtonItemDetails_Estimate.SubItemsExpandWidth = 14
            Me.ButtonItemDetails_Estimate.Text = "Estimate"
            '
            'ButtonItemDetails_AP
            '
            Me.ButtonItemDetails_AP.BeginGroup = True
            Me.ButtonItemDetails_AP.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDetails_AP.Name = "ButtonItemDetails_AP"
            Me.ButtonItemDetails_AP.RibbonWordWrap = False
            Me.ButtonItemDetails_AP.SecurityEnabled = True
            Me.ButtonItemDetails_AP.SubItemsExpandWidth = 14
            Me.ButtonItemDetails_AP.Text = "AP Info"
            '
            'RibbonBarOptions_Spelling
            '
            Me.RibbonBarOptions_Spelling.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Spelling.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Spelling.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Spelling.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Spelling.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Spelling.DragDropSupport = True
            Me.RibbonBarOptions_Spelling.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemSpelling_CheckSpelling})
            Me.RibbonBarOptions_Spelling.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Spelling.Location = New System.Drawing.Point(571, 0)
            Me.RibbonBarOptions_Spelling.Name = "RibbonBarOptions_Spelling"
            Me.RibbonBarOptions_Spelling.SecurityEnabled = True
            Me.RibbonBarOptions_Spelling.Size = New System.Drawing.Size(90, 98)
            Me.RibbonBarOptions_Spelling.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Spelling.TabIndex = 1
            Me.RibbonBarOptions_Spelling.Text = "Spelling"
            '
            '
            '
            Me.RibbonBarOptions_Spelling.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Spelling.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Spelling.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemSpelling_CheckSpelling
            '
            Me.ButtonItemSpelling_CheckSpelling.BeginGroup = True
            Me.ButtonItemSpelling_CheckSpelling.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemSpelling_CheckSpelling.Name = "ButtonItemSpelling_CheckSpelling"
            Me.ButtonItemSpelling_CheckSpelling.RibbonWordWrap = False
            Me.ButtonItemSpelling_CheckSpelling.SecurityEnabled = True
            Me.ButtonItemSpelling_CheckSpelling.SubItemsExpandWidth = 14
            Me.ButtonItemSpelling_CheckSpelling.Text = "Check Spelling"
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
            Me.RibbonBarOptions_Actions.Controls.Add(Me.ComboBoxActions_SearchBy)
            Me.RibbonBarOptions_Actions.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Actions.DragDropSupport = True
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerActions_ItemContainer, Me.ButtonItemActions_Export, Me.ButtonItemActions_Add, Me.ButtonItemActions_Save, Me.ButtonItemActions_Void, Me.ButtonItemActions_Copy, Me.ButtonItemActions_Revise, Me.ButtonItemActions_CancelApproval, Me.ButtonItemActions_PrintOrSend, Me.ButtonItemActions_Refresh})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(571, 98)
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
            'ComboBoxActions_SearchBy
            '
            Me.ComboBoxActions_SearchBy.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxActions_SearchBy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxActions_SearchBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxActions_SearchBy.AutoFindItemInDataSource = False
            Me.ComboBoxActions_SearchBy.AutoSelectSingleItemDatasource = False
            Me.ComboBoxActions_SearchBy.BookmarkingEnabled = False
            Me.ComboBoxActions_SearchBy.ClientCode = ""
            Me.ComboBoxActions_SearchBy.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumObjects
            Me.ComboBoxActions_SearchBy.DisableMouseWheel = False
            Me.ComboBoxActions_SearchBy.DisplayMember = "Description"
            Me.ComboBoxActions_SearchBy.DisplayName = ""
            Me.ComboBoxActions_SearchBy.DivisionCode = ""
            Me.ComboBoxActions_SearchBy.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxActions_SearchBy.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxActions_SearchBy.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxActions_SearchBy.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxActions_SearchBy.FocusHighlightEnabled = True
            Me.ComboBoxActions_SearchBy.FormattingEnabled = True
            Me.ComboBoxActions_SearchBy.ItemHeight = 14
            Me.ComboBoxActions_SearchBy.Location = New System.Drawing.Point(6, 47)
            Me.ComboBoxActions_SearchBy.Name = "ComboBoxActions_SearchBy"
            Me.ComboBoxActions_SearchBy.ReadOnly = False
            Me.ComboBoxActions_SearchBy.SecurityEnabled = True
            Me.ComboBoxActions_SearchBy.Size = New System.Drawing.Size(132, 20)
            Me.ComboBoxActions_SearchBy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxActions_SearchBy.TabIndex = 3
            Me.ComboBoxActions_SearchBy.TabOnEnter = True
            Me.ComboBoxActions_SearchBy.ValueMember = "Code"
            Me.ComboBoxActions_SearchBy.WatermarkText = "Select"
            '
            'ItemContainerActions_ItemContainer
            '
            '
            '
            '
            Me.ItemContainerActions_ItemContainer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerActions_ItemContainer.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerActions_ItemContainer.Name = "ItemContainerActions_ItemContainer"
            Me.ItemContainerActions_ItemContainer.ResizeItemsToFit = False
            Me.ItemContainerActions_ItemContainer.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ControlContainerItemSearch_ComboBox})
            '
            '
            '
            Me.ItemContainerActions_ItemContainer.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ControlContainerItemSearch_ComboBox
            '
            Me.ControlContainerItemSearch_ComboBox.AllowItemResize = True
            Me.ControlContainerItemSearch_ComboBox.Control = Me.ComboBoxActions_SearchBy
            Me.ControlContainerItemSearch_ComboBox.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItemSearch_ComboBox.Name = "ControlContainerItemSearch_ComboBox"
            Me.ControlContainerItemSearch_ComboBox.Text = "ControlContainerItem1"
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
            'ButtonItemActions_Add
            '
            Me.ButtonItemActions_Add.BeginGroup = True
            Me.ButtonItemActions_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Add.Name = "ButtonItemActions_Add"
            Me.ButtonItemActions_Add.RibbonWordWrap = False
            Me.ButtonItemActions_Add.SecurityEnabled = True
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
            'ButtonItemActions_Void
            '
            Me.ButtonItemActions_Void.BeginGroup = True
            Me.ButtonItemActions_Void.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Void.Name = "ButtonItemActions_Void"
            Me.ButtonItemActions_Void.RibbonWordWrap = False
            Me.ButtonItemActions_Void.SecurityEnabled = True
            Me.ButtonItemActions_Void.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Void.Text = "Void"
            '
            'ButtonItemActions_Copy
            '
            Me.ButtonItemActions_Copy.BeginGroup = True
            Me.ButtonItemActions_Copy.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Copy.Name = "ButtonItemActions_Copy"
            Me.ButtonItemActions_Copy.RibbonWordWrap = False
            Me.ButtonItemActions_Copy.SecurityEnabled = True
            Me.ButtonItemActions_Copy.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Copy.Text = "Copy"
            '
            'ButtonItemActions_Revise
            '
            Me.ButtonItemActions_Revise.BeginGroup = True
            Me.ButtonItemActions_Revise.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Revise.Name = "ButtonItemActions_Revise"
            Me.ButtonItemActions_Revise.RibbonWordWrap = False
            Me.ButtonItemActions_Revise.SecurityEnabled = True
            Me.ButtonItemActions_Revise.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Revise.Text = "Revise"
            '
            'ButtonItemActions_CancelApproval
            '
            Me.ButtonItemActions_CancelApproval.BeginGroup = True
            Me.ButtonItemActions_CancelApproval.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_CancelApproval.Name = "ButtonItemActions_CancelApproval"
            Me.ButtonItemActions_CancelApproval.RibbonWordWrap = False
            Me.ButtonItemActions_CancelApproval.SecurityEnabled = True
            Me.ButtonItemActions_CancelApproval.SubItemsExpandWidth = 14
            Me.ButtonItemActions_CancelApproval.Text = "Cancel Approval"
            '
            'ButtonItemActions_PrintOrSend
            '
            Me.ButtonItemActions_PrintOrSend.BeginGroup = True
            Me.ButtonItemActions_PrintOrSend.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_PrintOrSend.Name = "ButtonItemActions_PrintOrSend"
            Me.ButtonItemActions_PrintOrSend.RibbonWordWrap = False
            Me.ButtonItemActions_PrintOrSend.SecurityEnabled = True
            Me.ButtonItemActions_PrintOrSend.SubItemsExpandWidth = 14
            Me.ButtonItemActions_PrintOrSend.Text = "Print / Send"
            '
            'PanelForm_RightSection
            '
            Me.PanelForm_RightSection.Controls.Add(Me.PurchaseOrderControlRightSection_PurchaseOrder)
            Me.PanelForm_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelForm_RightSection.Location = New System.Drawing.Point(258, 0)
            Me.PanelForm_RightSection.Name = "PanelForm_RightSection"
            Me.PanelForm_RightSection.Size = New System.Drawing.Size(741, 453)
            Me.PanelForm_RightSection.TabIndex = 8
            '
            'PurchaseOrderControlRightSection_PurchaseOrder
            '
            Me.PurchaseOrderControlRightSection_PurchaseOrder.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PurchaseOrderControlRightSection_PurchaseOrder.DisplayPONumber = ""
            Me.PurchaseOrderControlRightSection_PurchaseOrder.Location = New System.Drawing.Point(6, 12)
            Me.PurchaseOrderControlRightSection_PurchaseOrder.Name = "PurchaseOrderControlRightSection_PurchaseOrder"
            Me.PurchaseOrderControlRightSection_PurchaseOrder.Size = New System.Drawing.Size(723, 429)
            Me.PurchaseOrderControlRightSection_PurchaseOrder.TabIndex = 0
            '
            'PanelForm_LeftSection
            '
            Me.PanelForm_LeftSection.Controls.Add(Me.DataGridViewLeftSection_PODetails)
            Me.PanelForm_LeftSection.Controls.Add(Me.DataGridViewLeftSection_PurchaseOrders)
            Me.PanelForm_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelForm_LeftSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelForm_LeftSection.Name = "PanelForm_LeftSection"
            Me.PanelForm_LeftSection.Size = New System.Drawing.Size(252, 453)
            Me.PanelForm_LeftSection.TabIndex = 10
            '
            'DataGridViewLeftSection_PODetails
            '
            Me.DataGridViewLeftSection_PODetails.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewLeftSection_PODetails.AllowDragAndDrop = False
            Me.DataGridViewLeftSection_PODetails.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewLeftSection_PODetails.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_PODetails.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewLeftSection_PODetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_PODetails.AutoFilterLookupColumns = False
            Me.DataGridViewLeftSection_PODetails.AutoloadRepositoryDatasource = True
            Me.DataGridViewLeftSection_PODetails.AutoUpdateViewCaption = True
            Me.DataGridViewLeftSection_PODetails.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewLeftSection_PODetails.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewLeftSection_PODetails.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_PODetails.ItemDescription = ""
            Me.DataGridViewLeftSection_PODetails.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewLeftSection_PODetails.MultiSelect = True
            Me.DataGridViewLeftSection_PODetails.Name = "DataGridViewLeftSection_PODetails"
            Me.DataGridViewLeftSection_PODetails.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_PODetails.RunStandardValidation = True
            Me.DataGridViewLeftSection_PODetails.ShowColumnMenuOnRightClick = False
            Me.DataGridViewLeftSection_PODetails.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_PODetails.Size = New System.Drawing.Size(234, 429)
            Me.DataGridViewLeftSection_PODetails.TabIndex = 12
            Me.DataGridViewLeftSection_PODetails.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_PODetails.ViewCaptionHeight = -1
            '
            'DataGridViewLeftSection_PurchaseOrders
            '
            Me.DataGridViewLeftSection_PurchaseOrders.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewLeftSection_PurchaseOrders.AllowDragAndDrop = False
            Me.DataGridViewLeftSection_PurchaseOrders.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewLeftSection_PurchaseOrders.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_PurchaseOrders.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewLeftSection_PurchaseOrders.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_PurchaseOrders.AutoFilterLookupColumns = False
            Me.DataGridViewLeftSection_PurchaseOrders.AutoloadRepositoryDatasource = True
            Me.DataGridViewLeftSection_PurchaseOrders.AutoUpdateViewCaption = True
            Me.DataGridViewLeftSection_PurchaseOrders.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewLeftSection_PurchaseOrders.DataSource = Nothing
            Me.DataGridViewLeftSection_PurchaseOrders.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewLeftSection_PurchaseOrders.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_PurchaseOrders.ItemDescription = ""
            Me.DataGridViewLeftSection_PurchaseOrders.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewLeftSection_PurchaseOrders.MultiSelect = True
            Me.DataGridViewLeftSection_PurchaseOrders.Name = "DataGridViewLeftSection_PurchaseOrders"
            Me.DataGridViewLeftSection_PurchaseOrders.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_PurchaseOrders.RunStandardValidation = True
            Me.DataGridViewLeftSection_PurchaseOrders.ShowColumnMenuOnRightClick = False
            Me.DataGridViewLeftSection_PurchaseOrders.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_PurchaseOrders.Size = New System.Drawing.Size(234, 429)
            Me.DataGridViewLeftSection_PurchaseOrders.TabIndex = 2
            Me.DataGridViewLeftSection_PurchaseOrders.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_PurchaseOrders.ViewCaptionHeight = -1
            '
            'ExpandableSplitterControl1
            '
            Me.ExpandableSplitterControl1.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControl1.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControl1.ExpandableControl = Me.PanelForm_LeftSection
            Me.ExpandableSplitterControl1.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl1.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl1.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControl1.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControl1.ForeColor = System.Drawing.Color.Black
            Me.ExpandableSplitterControl1.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControl1.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControl1.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControl1.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControl1.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterControl1.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterControl1.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterControl1.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterControl1.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl1.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl1.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControl1.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControl1.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControl1.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControl1.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControl1.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControl1.Location = New System.Drawing.Point(252, 0)
            Me.ExpandableSplitterControl1.Name = "ExpandableSplitterControl1"
            Me.ExpandableSplitterControl1.Size = New System.Drawing.Size(6, 453)
            Me.ExpandableSplitterControl1.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControl1.TabIndex = 11
            Me.ExpandableSplitterControl1.TabStop = False
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
            'PurchaseOrderSetupForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(999, 453)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.PanelForm_RightSection)
            Me.Controls.Add(Me.ExpandableSplitterControl1)
            Me.Controls.Add(Me.PanelForm_LeftSection)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "PurchaseOrderSetupForm"
            Me.Text = "Purchase Orders"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            Me.RibbonBarOptions_Actions.ResumeLayout(False)
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_RightSection.ResumeLayout(False)
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_LeftSection.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Add As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Void As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents PanelForm_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents PanelForm_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewLeftSection_PurchaseOrders As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ButtonItemActions_Save As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ExpandableSplitterControl1 As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PurchaseOrderControlRightSection_PurchaseOrder As AdvantageFramework.WinForm.Presentation.Controls.PurchaseOrderControl
        Friend WithEvents ButtonItemActions_Copy As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Revise As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_PrintOrSend As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Spelling As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemSpelling_CheckSpelling As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Details As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemDetails_Estimate As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDetails_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDetails_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ItemContainerActions_ItemContainer As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ComboBoxActions_SearchBy As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ControlContainerItemSearch_ComboBox As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents ButtonItemActions_CancelApproval As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDetails_Copy As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDetails_Add As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents DataGridViewLeftSection_PODetails As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ButtonItemDetails_AP As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDetails_CopyFrom As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Export As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Refresh As WinForm.Presentation.Controls.ButtonItem
    End Class

End Namespace

