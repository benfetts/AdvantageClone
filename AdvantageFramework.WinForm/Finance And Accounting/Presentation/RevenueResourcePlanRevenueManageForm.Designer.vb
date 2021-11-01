Namespace FinanceAndAccounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class RevenueResourcePlanRevenueManageForm
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
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RevenueResourcePlanRevenueManageForm))
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Actuals = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActuals_Show = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_Details = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemDetails_Add = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemDetails_Delete = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_Approval = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemApproval_Approve = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemApproval_Unapprove = New DevComponents.DotNetBar.ButtonItem()
            Me.ItemContainerApproval_ApprovalInfo = New DevComponents.DotNetBar.ItemContainer()
            Me.ItemContainerApprovalInfo_ApprovalInfo1 = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemApprovalInfo_ApprovedByLabel = New DevComponents.DotNetBar.LabelItem()
            Me.LabelItemApprovalInfo_ApprovedBy = New DevComponents.DotNetBar.LabelItem()
            Me.ItemContainerApprovalInfo_ApprovalInfo2 = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemApprovalInfo_ApprovedDateLabel = New DevComponents.DotNetBar.LabelItem()
            Me.LabelItemApprovalInfo_ApprovedDate = New DevComponents.DotNetBar.LabelItem()
            Me.RibbonBarOptions_Revisions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ItemContainerRevisions = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemRevisions_View = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemRevisions_Create = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemRevisions_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ItemContainerRevisions2 = New DevComponents.DotNetBar.ItemContainer()
            Me.ComboBoxItemRevisions_Revisions = New DevComponents.DotNetBar.ComboBoxItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Save = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Cancel = New DevComponents.DotNetBar.ButtonItem()
            Me.ToolTipController = New DevExpress.Utils.ToolTipController(Me.components)
            Me.DataGridViewForm_RevenueDetails = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            Me.SuspendLayout()
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actuals)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Details)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Approval)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Revisions)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(28, 97)
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(776, 98)
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
            'RibbonBarOptions_Actuals
            '
            Me.RibbonBarOptions_Actuals.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Actuals.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Actuals.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Actuals.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Actuals.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Actuals.DragDropSupport = True
            Me.RibbonBarOptions_Actuals.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActuals_Show})
            Me.RibbonBarOptions_Actuals.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actuals.Location = New System.Drawing.Point(573, 0)
            Me.RibbonBarOptions_Actuals.Name = "RibbonBarOptions_Actuals"
            Me.RibbonBarOptions_Actuals.SecurityEnabled = True
            Me.RibbonBarOptions_Actuals.Size = New System.Drawing.Size(95, 98)
            Me.RibbonBarOptions_Actuals.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actuals.TabIndex = 33
            Me.RibbonBarOptions_Actuals.Text = "Actuals"
            '
            '
            '
            Me.RibbonBarOptions_Actuals.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Actuals.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Actuals.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemActuals_Show
            '
            Me.ButtonItemActuals_Show.AutoCheckOnClick = True
            Me.ButtonItemActuals_Show.BeginGroup = True
            Me.ButtonItemActuals_Show.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActuals_Show.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActuals_Show.Name = "ButtonItemActuals_Show"
            Me.ButtonItemActuals_Show.RibbonWordWrap = False
            Me.ButtonItemActuals_Show.SubItemsExpandWidth = 14
            Me.ButtonItemActuals_Show.Text = "Show"
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
            Me.RibbonBarOptions_Details.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemDetails_Add, Me.ButtonItemDetails_Delete})
            Me.RibbonBarOptions_Details.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Details.Location = New System.Drawing.Point(478, 0)
            Me.RibbonBarOptions_Details.Name = "RibbonBarOptions_Details"
            Me.RibbonBarOptions_Details.SecurityEnabled = True
            Me.RibbonBarOptions_Details.Size = New System.Drawing.Size(95, 98)
            Me.RibbonBarOptions_Details.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Details.TabIndex = 32
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
            Me.ButtonItemDetails_Add.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemDetails_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDetails_Add.Name = "ButtonItemDetails_Add"
            Me.ButtonItemDetails_Add.RibbonWordWrap = False
            Me.ButtonItemDetails_Add.SubItemsExpandWidth = 14
            Me.ButtonItemDetails_Add.Text = "Add"
            '
            'ButtonItemDetails_Delete
            '
            Me.ButtonItemDetails_Delete.BeginGroup = True
            Me.ButtonItemDetails_Delete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemDetails_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDetails_Delete.Name = "ButtonItemDetails_Delete"
            Me.ButtonItemDetails_Delete.RibbonWordWrap = False
            Me.ButtonItemDetails_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemDetails_Delete.Text = "Delete"
            '
            'RibbonBarOptions_Approval
            '
            Me.RibbonBarOptions_Approval.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Approval.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Approval.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Approval.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Approval.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Approval.DragDropSupport = True
            Me.RibbonBarOptions_Approval.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemApproval_Approve, Me.ButtonItemApproval_Unapprove, Me.ItemContainerApproval_ApprovalInfo})
            Me.RibbonBarOptions_Approval.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Approval.Location = New System.Drawing.Point(201, 0)
            Me.RibbonBarOptions_Approval.Name = "RibbonBarOptions_Approval"
            Me.RibbonBarOptions_Approval.SecurityEnabled = True
            Me.RibbonBarOptions_Approval.Size = New System.Drawing.Size(277, 98)
            Me.RibbonBarOptions_Approval.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Approval.TabIndex = 31
            Me.RibbonBarOptions_Approval.Text = "Approval"
            '
            '
            '
            Me.RibbonBarOptions_Approval.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Approval.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Approval.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemApproval_Approve
            '
            Me.ButtonItemApproval_Approve.BeginGroup = True
            Me.ButtonItemApproval_Approve.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemApproval_Approve.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemApproval_Approve.Name = "ButtonItemApproval_Approve"
            Me.ButtonItemApproval_Approve.RibbonWordWrap = False
            Me.ButtonItemApproval_Approve.SubItemsExpandWidth = 14
            Me.ButtonItemApproval_Approve.Text = "Approve"
            '
            'ButtonItemApproval_Unapprove
            '
            Me.ButtonItemApproval_Unapprove.BeginGroup = True
            Me.ButtonItemApproval_Unapprove.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemApproval_Unapprove.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemApproval_Unapprove.Name = "ButtonItemApproval_Unapprove"
            Me.ButtonItemApproval_Unapprove.RibbonWordWrap = False
            Me.ButtonItemApproval_Unapprove.SubItemsExpandWidth = 14
            Me.ButtonItemApproval_Unapprove.Text = "Unapprove"
            '
            'ItemContainerApproval_ApprovalInfo
            '
            '
            '
            '
            Me.ItemContainerApproval_ApprovalInfo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerApproval_ApprovalInfo.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerApproval_ApprovalInfo.Name = "ItemContainerApproval_ApprovalInfo"
            Me.ItemContainerApproval_ApprovalInfo.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerApprovalInfo_ApprovalInfo1, Me.ItemContainerApprovalInfo_ApprovalInfo2})
            '
            '
            '
            Me.ItemContainerApproval_ApprovalInfo.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerApproval_ApprovalInfo.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerApproval_ApprovalInfo.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ItemContainerApprovalInfo_ApprovalInfo1
            '
            '
            '
            '
            Me.ItemContainerApprovalInfo_ApprovalInfo1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerApprovalInfo_ApprovalInfo1.MinimumSize = New System.Drawing.Size(145, 0)
            Me.ItemContainerApprovalInfo_ApprovalInfo1.Name = "ItemContainerApprovalInfo_ApprovalInfo1"
            Me.ItemContainerApprovalInfo_ApprovalInfo1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemApprovalInfo_ApprovedByLabel, Me.LabelItemApprovalInfo_ApprovedBy})
            '
            '
            '
            Me.ItemContainerApprovalInfo_ApprovalInfo1.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerApprovalInfo_ApprovalInfo1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemApprovalInfo_ApprovedByLabel
            '
            Me.LabelItemApprovalInfo_ApprovedByLabel.Name = "LabelItemApprovalInfo_ApprovedByLabel"
            Me.LabelItemApprovalInfo_ApprovedByLabel.Text = "Approved By:"
            '
            'LabelItemApprovalInfo_ApprovedBy
            '
            Me.LabelItemApprovalInfo_ApprovedBy.Name = "LabelItemApprovalInfo_ApprovedBy"
            '
            'ItemContainerApprovalInfo_ApprovalInfo2
            '
            '
            '
            '
            Me.ItemContainerApprovalInfo_ApprovalInfo2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerApprovalInfo_ApprovalInfo2.MinimumSize = New System.Drawing.Size(145, 0)
            Me.ItemContainerApprovalInfo_ApprovalInfo2.Name = "ItemContainerApprovalInfo_ApprovalInfo2"
            Me.ItemContainerApprovalInfo_ApprovalInfo2.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemApprovalInfo_ApprovedDateLabel, Me.LabelItemApprovalInfo_ApprovedDate})
            '
            '
            '
            Me.ItemContainerApprovalInfo_ApprovalInfo2.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerApprovalInfo_ApprovalInfo2.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemApprovalInfo_ApprovedDateLabel
            '
            Me.LabelItemApprovalInfo_ApprovedDateLabel.Name = "LabelItemApprovalInfo_ApprovedDateLabel"
            Me.LabelItemApprovalInfo_ApprovedDateLabel.Text = "Approved Date:"
            '
            'LabelItemApprovalInfo_ApprovedDate
            '
            Me.LabelItemApprovalInfo_ApprovedDate.Name = "LabelItemApprovalInfo_ApprovedDate"
            '
            'RibbonBarOptions_Revisions
            '
            Me.RibbonBarOptions_Revisions.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Revisions.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Revisions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Revisions.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Revisions.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Revisions.DragDropSupport = True
            Me.RibbonBarOptions_Revisions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerRevisions, Me.ItemContainerRevisions2})
            Me.RibbonBarOptions_Revisions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Revisions.Location = New System.Drawing.Point(100, 0)
            Me.RibbonBarOptions_Revisions.Name = "RibbonBarOptions_Revisions"
            Me.RibbonBarOptions_Revisions.SecurityEnabled = True
            Me.RibbonBarOptions_Revisions.Size = New System.Drawing.Size(101, 98)
            Me.RibbonBarOptions_Revisions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Revisions.TabIndex = 30
            Me.RibbonBarOptions_Revisions.Text = "Revisions"
            '
            '
            '
            Me.RibbonBarOptions_Revisions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Revisions.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ItemContainerRevisions
            '
            '
            '
            '
            Me.ItemContainerRevisions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerRevisions.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerRevisions.Name = "ItemContainerRevisions"
            Me.ItemContainerRevisions.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemRevisions_View, Me.ButtonItemRevisions_Create, Me.ButtonItemRevisions_Delete})
            '
            '
            '
            Me.ItemContainerRevisions.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerRevisions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemRevisions_View
            '
            Me.ButtonItemRevisions_View.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemRevisions_View.ImageFixedSize = New System.Drawing.Size(16, 16)
            Me.ButtonItemRevisions_View.Name = "ButtonItemRevisions_View"
            Me.ButtonItemRevisions_View.RibbonWordWrap = False
            Me.ButtonItemRevisions_View.SecurityEnabled = True
            Me.ButtonItemRevisions_View.SubItemsExpandWidth = 14
            Me.ButtonItemRevisions_View.Text = "View"
            Me.ButtonItemRevisions_View.Tooltip = "View revision"
            '
            'ButtonItemRevisions_Create
            '
            Me.ButtonItemRevisions_Create.BeginGroup = True
            Me.ButtonItemRevisions_Create.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemRevisions_Create.ImageFixedSize = New System.Drawing.Size(16, 16)
            Me.ButtonItemRevisions_Create.Name = "ButtonItemRevisions_Create"
            Me.ButtonItemRevisions_Create.RibbonWordWrap = False
            Me.ButtonItemRevisions_Create.SecurityEnabled = True
            Me.ButtonItemRevisions_Create.SubItemsExpandWidth = 14
            Me.ButtonItemRevisions_Create.Text = "Create"
            Me.ButtonItemRevisions_Create.Tooltip = "Create revision"
            '
            'ButtonItemRevisions_Delete
            '
            Me.ButtonItemRevisions_Delete.BeginGroup = True
            Me.ButtonItemRevisions_Delete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemRevisions_Delete.ImageFixedSize = New System.Drawing.Size(16, 16)
            Me.ButtonItemRevisions_Delete.Name = "ButtonItemRevisions_Delete"
            Me.ButtonItemRevisions_Delete.RibbonWordWrap = False
            Me.ButtonItemRevisions_Delete.SecurityEnabled = True
            Me.ButtonItemRevisions_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemRevisions_Delete.Text = "Delete"
            Me.ButtonItemRevisions_Delete.Tooltip = "Delete revision"
            '
            'ItemContainerRevisions2
            '
            '
            '
            '
            Me.ItemContainerRevisions2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerRevisions2.BeginGroup = True
            Me.ItemContainerRevisions2.Name = "ItemContainerRevisions2"
            Me.ItemContainerRevisions2.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ComboBoxItemRevisions_Revisions})
            '
            '
            '
            Me.ItemContainerRevisions2.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerRevisions2.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ComboBoxItemRevisions_Revisions
            '
            Me.ComboBoxItemRevisions_Revisions.ComboWidth = 45
            Me.ComboBoxItemRevisions_Revisions.DisplayMember = "RevisionNumberText"
            Me.ComboBoxItemRevisions_Revisions.DropDownHeight = 106
            Me.ComboBoxItemRevisions_Revisions.Name = "ComboBoxItemRevisions_Revisions"
            Me.ComboBoxItemRevisions_Revisions.Tooltip = "Select to view revision"
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
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(100, 98)
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
            'ButtonItemActions_Save
            '
            Me.ButtonItemActions_Save.BeginGroup = True
            Me.ButtonItemActions_Save.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Save.Name = "ButtonItemActions_Save"
            Me.ButtonItemActions_Save.RibbonWordWrap = False
            Me.ButtonItemActions_Save.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Save.Text = "Save"
            '
            'ButtonItemActions_Cancel
            '
            Me.ButtonItemActions_Cancel.BeginGroup = True
            Me.ButtonItemActions_Cancel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Cancel.Name = "ButtonItemActions_Cancel"
            Me.ButtonItemActions_Cancel.RibbonWordWrap = False
            Me.ButtonItemActions_Cancel.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Cancel.Text = "Cancel"
            '
            'DataGridViewForm_RevenueDetails
            '
            Me.DataGridViewForm_RevenueDetails.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_RevenueDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_RevenueDetails.AutoUpdateViewCaption = True
            Me.DataGridViewForm_RevenueDetails.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_RevenueDetails.ItemDescription = "Detail(s)"
            Me.DataGridViewForm_RevenueDetails.Location = New System.Drawing.Point(14, 14)
            Me.DataGridViewForm_RevenueDetails.Margin = New System.Windows.Forms.Padding(5)
            Me.DataGridViewForm_RevenueDetails.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewForm_RevenueDetails.ModifyGridRowHeight = False
            Me.DataGridViewForm_RevenueDetails.MultiSelect = False
            Me.DataGridViewForm_RevenueDetails.Name = "DataGridViewForm_RevenueDetails"
            Me.DataGridViewForm_RevenueDetails.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_RevenueDetails.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewForm_RevenueDetails.ShowRowSelectionIfHidden = True
            Me.DataGridViewForm_RevenueDetails.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_RevenueDetails.Size = New System.Drawing.Size(832, 245)
            Me.DataGridViewForm_RevenueDetails.TabIndex = 6
            Me.DataGridViewForm_RevenueDetails.UseEmbeddedNavigator = False
            Me.DataGridViewForm_RevenueDetails.ViewCaptionHeight = -1
            '
            'RevenueResourcePlanRevenueManageForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(860, 273)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.DataGridViewForm_RevenueDetails)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(4)
            Me.Name = "RevenueResourcePlanRevenueManageForm"
            Me.Text = "Revenue Plan"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Save As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Cancel As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ToolTipController As DevExpress.Utils.ToolTipController
        Friend WithEvents DataGridViewForm_RevenueDetails As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarOptions_Revisions As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ItemContainerRevisions As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemRevisions_View As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemRevisions_Create As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemRevisions_Delete As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ItemContainerRevisions2 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ComboBoxItemRevisions_Revisions As DevComponents.DotNetBar.ComboBoxItem
        Friend WithEvents RibbonBarOptions_Approval As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemApproval_Approve As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemApproval_Unapprove As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ItemContainerApproval_ApprovalInfo As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ItemContainerApprovalInfo_ApprovalInfo1 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemApprovalInfo_ApprovedByLabel As DevComponents.DotNetBar.LabelItem
        Friend WithEvents LabelItemApprovalInfo_ApprovedBy As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ItemContainerApprovalInfo_ApprovalInfo2 As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemApprovalInfo_ApprovedDateLabel As DevComponents.DotNetBar.LabelItem
        Friend WithEvents LabelItemApprovalInfo_ApprovedDate As DevComponents.DotNetBar.LabelItem
        Friend WithEvents RibbonBarOptions_Details As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemDetails_Add As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemDetails_Delete As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_Actuals As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActuals_Show As DevComponents.DotNetBar.ButtonItem
    End Class

End Namespace