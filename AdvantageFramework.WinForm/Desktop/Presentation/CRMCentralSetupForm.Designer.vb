Namespace Desktop.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class CRMCentralSetupForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CRMCentralSetupForm))
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Activity = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActivity_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Diary = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemDiary_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_ClientContacts = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemClientContacts_View = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Product = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemProduct_Edit = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemProduct_CompanyProfile = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemProduct_ActivitySummary = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemProduct_Contracts = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Division = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemDivision_Edit = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Client = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemClient_Edit = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Export = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Print = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ItemContainerActions_Actions = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemActions_ShowCodes = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_ShowDescriptions = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_ShowBoth = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.DataGridViewForm_Products = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            Me.SuspendLayout()
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Activity)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Diary)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_ClientContacts)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Product)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Division)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Client)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(12, 126)
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(840, 98)
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
            'RibbonBarOptions_Activity
            '
            Me.RibbonBarOptions_Activity.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Activity.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Activity.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Activity.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Activity.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Activity.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_Activity.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActivity_Add})
            Me.RibbonBarOptions_Activity.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Activity.Location = New System.Drawing.Point(753, 0)
            Me.RibbonBarOptions_Activity.Name = "RibbonBarOptions_Activity"
            Me.RibbonBarOptions_Activity.Size = New System.Drawing.Size(70, 98)
            Me.RibbonBarOptions_Activity.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Activity.TabIndex = 25
            Me.RibbonBarOptions_Activity.Text = "Activity"
            '
            '
            '
            Me.RibbonBarOptions_Activity.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Activity.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Activity.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemActivity_Add
            '
            Me.ButtonItemActivity_Add.BeginGroup = True
            Me.ButtonItemActivity_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActivity_Add.Name = "ButtonItemActivity_Add"
            Me.ButtonItemActivity_Add.PopupSide = DevComponents.DotNetBar.ePopupSide.Right
            Me.ButtonItemActivity_Add.RibbonWordWrap = False
            Me.ButtonItemActivity_Add.SplitButton = True
            Me.ButtonItemActivity_Add.SubItemsExpandWidth = 14
            Me.ButtonItemActivity_Add.Text = "Add"
            '
            'RibbonBarOptions_Diary
            '
            Me.RibbonBarOptions_Diary.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Diary.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Diary.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Diary.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Diary.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Diary.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_Diary.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemDiary_Add})
            Me.RibbonBarOptions_Diary.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Diary.Location = New System.Drawing.Point(683, 0)
            Me.RibbonBarOptions_Diary.Name = "RibbonBarOptions_Diary"
            Me.RibbonBarOptions_Diary.Size = New System.Drawing.Size(70, 98)
            Me.RibbonBarOptions_Diary.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Diary.TabIndex = 20
            Me.RibbonBarOptions_Diary.Text = "Diary"
            '
            '
            '
            Me.RibbonBarOptions_Diary.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Diary.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Diary.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemDiary_Add
            '
            Me.ButtonItemDiary_Add.BeginGroup = True
            Me.ButtonItemDiary_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDiary_Add.Name = "ButtonItemDiary_Add"
            Me.ButtonItemDiary_Add.RibbonWordWrap = False
            Me.ButtonItemDiary_Add.SubItemsExpandWidth = 14
            Me.ButtonItemDiary_Add.Text = "Add"
            '
            'RibbonBarOptions_ClientContacts
            '
            Me.RibbonBarOptions_ClientContacts.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_ClientContacts.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_ClientContacts.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_ClientContacts.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_ClientContacts.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_ClientContacts.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_ClientContacts.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemClientContacts_View})
            Me.RibbonBarOptions_ClientContacts.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_ClientContacts.Location = New System.Drawing.Point(601, 0)
            Me.RibbonBarOptions_ClientContacts.MinimumSize = New System.Drawing.Size(82, 0)
            Me.RibbonBarOptions_ClientContacts.Name = "RibbonBarOptions_ClientContacts"
            Me.RibbonBarOptions_ClientContacts.Size = New System.Drawing.Size(82, 98)
            Me.RibbonBarOptions_ClientContacts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_ClientContacts.TabIndex = 24
            Me.RibbonBarOptions_ClientContacts.Text = "Client Contacts"
            '
            '
            '
            Me.RibbonBarOptions_ClientContacts.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_ClientContacts.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_ClientContacts.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemClientContacts_View
            '
            Me.ButtonItemClientContacts_View.BeginGroup = True
            Me.ButtonItemClientContacts_View.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemClientContacts_View.Name = "ButtonItemClientContacts_View"
            Me.ButtonItemClientContacts_View.RibbonWordWrap = False
            Me.ButtonItemClientContacts_View.SecurityEnabled = True
            Me.ButtonItemClientContacts_View.SubItemsExpandWidth = 14
            Me.ButtonItemClientContacts_View.Text = "View"
            '
            'RibbonBarOptions_Product
            '
            Me.RibbonBarOptions_Product.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Product.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Product.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Product.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Product.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Product.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_Product.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemProduct_Edit, Me.ButtonItemProduct_CompanyProfile, Me.ButtonItemProduct_ActivitySummary, Me.ButtonItemProduct_Contracts})
            Me.RibbonBarOptions_Product.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Product.Location = New System.Drawing.Point(293, 0)
            Me.RibbonBarOptions_Product.Name = "RibbonBarOptions_Product"
            Me.RibbonBarOptions_Product.Size = New System.Drawing.Size(308, 98)
            Me.RibbonBarOptions_Product.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Product.TabIndex = 21
            Me.RibbonBarOptions_Product.Text = "Product"
            '
            '
            '
            Me.RibbonBarOptions_Product.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Product.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Product.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemProduct_Edit
            '
            Me.ButtonItemProduct_Edit.BeginGroup = True
            Me.ButtonItemProduct_Edit.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemProduct_Edit.Name = "ButtonItemProduct_Edit"
            Me.ButtonItemProduct_Edit.RibbonWordWrap = False
            Me.ButtonItemProduct_Edit.SecurityEnabled = True
            Me.ButtonItemProduct_Edit.SubItemsExpandWidth = 14
            Me.ButtonItemProduct_Edit.Text = "Edit"
            '
            'ButtonItemProduct_CompanyProfile
            '
            Me.ButtonItemProduct_CompanyProfile.BeginGroup = True
            Me.ButtonItemProduct_CompanyProfile.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemProduct_CompanyProfile.Name = "ButtonItemProduct_CompanyProfile"
            Me.ButtonItemProduct_CompanyProfile.RibbonWordWrap = False
            Me.ButtonItemProduct_CompanyProfile.SecurityEnabled = True
            Me.ButtonItemProduct_CompanyProfile.SubItemsExpandWidth = 14
            Me.ButtonItemProduct_CompanyProfile.Text = "Company Profile"
            '
            'ButtonItemProduct_ActivitySummary
            '
            Me.ButtonItemProduct_ActivitySummary.BeginGroup = True
            Me.ButtonItemProduct_ActivitySummary.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemProduct_ActivitySummary.Name = "ButtonItemProduct_ActivitySummary"
            Me.ButtonItemProduct_ActivitySummary.RibbonWordWrap = False
            Me.ButtonItemProduct_ActivitySummary.SecurityEnabled = True
            Me.ButtonItemProduct_ActivitySummary.SubItemsExpandWidth = 14
            Me.ButtonItemProduct_ActivitySummary.Text = "Activity Summary"
            '
            'ButtonItemProduct_Contracts
            '
            Me.ButtonItemProduct_Contracts.BeginGroup = True
            Me.ButtonItemProduct_Contracts.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemProduct_Contracts.Name = "ButtonItemProduct_Contracts"
            Me.ButtonItemProduct_Contracts.RibbonWordWrap = False
            Me.ButtonItemProduct_Contracts.SecurityEnabled = True
            Me.ButtonItemProduct_Contracts.SubItemsExpandWidth = 14
            Me.ButtonItemProduct_Contracts.Text = "<span width=""6""> </span>Contracts /<br></br>Opportunities"
            '
            'RibbonBarOptions_Division
            '
            Me.RibbonBarOptions_Division.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Division.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Division.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Division.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Division.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Division.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_Division.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemDivision_Edit})
            Me.RibbonBarOptions_Division.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Division.Location = New System.Drawing.Point(242, 0)
            Me.RibbonBarOptions_Division.Name = "RibbonBarOptions_Division"
            Me.RibbonBarOptions_Division.Size = New System.Drawing.Size(51, 98)
            Me.RibbonBarOptions_Division.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Division.TabIndex = 23
            Me.RibbonBarOptions_Division.Text = "Division"
            '
            '
            '
            Me.RibbonBarOptions_Division.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Division.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Division.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemDivision_Edit
            '
            Me.ButtonItemDivision_Edit.BeginGroup = True
            Me.ButtonItemDivision_Edit.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDivision_Edit.Name = "ButtonItemDivision_Edit"
            Me.ButtonItemDivision_Edit.RibbonWordWrap = False
            Me.ButtonItemDivision_Edit.SecurityEnabled = True
            Me.ButtonItemDivision_Edit.SubItemsExpandWidth = 14
            Me.ButtonItemDivision_Edit.Text = "Edit"
            '
            'RibbonBarOptions_Client
            '
            Me.RibbonBarOptions_Client.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Client.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Client.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Client.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Client.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Client.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_Client.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemClient_Edit})
            Me.RibbonBarOptions_Client.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Client.Location = New System.Drawing.Point(198, 0)
            Me.RibbonBarOptions_Client.Name = "RibbonBarOptions_Client"
            Me.RibbonBarOptions_Client.Size = New System.Drawing.Size(44, 98)
            Me.RibbonBarOptions_Client.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Client.TabIndex = 22
            Me.RibbonBarOptions_Client.Text = "Client"
            '
            '
            '
            Me.RibbonBarOptions_Client.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Client.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Client.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemClient_Edit
            '
            Me.ButtonItemClient_Edit.BeginGroup = True
            Me.ButtonItemClient_Edit.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemClient_Edit.Name = "ButtonItemClient_Edit"
            Me.ButtonItemClient_Edit.RibbonWordWrap = False
            Me.ButtonItemClient_Edit.SecurityEnabled = True
            Me.ButtonItemClient_Edit.SubItemsExpandWidth = 14
            Me.ButtonItemClient_Edit.Text = "Edit"
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
            Me.RibbonBarOptions_Actions.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Export, Me.ButtonItemActions_Print, Me.ItemContainerActions_Actions})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(198, 98)
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
            'ButtonItemActions_Export
            '
            Me.ButtonItemActions_Export.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Export.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Export.Name = "ButtonItemActions_Export"
            Me.ButtonItemActions_Export.RibbonWordWrap = False
            Me.ButtonItemActions_Export.Stretch = True
            Me.ButtonItemActions_Export.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Export.Text = "Export"
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
            'ItemContainerActions_Actions
            '
            '
            '
            '
            Me.ItemContainerActions_Actions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerActions_Actions.BeginGroup = True
            Me.ItemContainerActions_Actions.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerActions_Actions.Name = "ItemContainerActions_Actions"
            Me.ItemContainerActions_Actions.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_ShowCodes, Me.ButtonItemActions_ShowDescriptions, Me.ButtonItemActions_ShowBoth})
            '
            '
            '
            Me.ItemContainerActions_Actions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemActions_ShowCodes
            '
            Me.ButtonItemActions_ShowCodes.AutoCheckOnClick = True
            Me.ButtonItemActions_ShowCodes.BeginGroup = True
            Me.ButtonItemActions_ShowCodes.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_ShowCodes.Name = "ButtonItemActions_ShowCodes"
            Me.ButtonItemActions_ShowCodes.OptionGroup = "Show"
            Me.ButtonItemActions_ShowCodes.SecurityEnabled = True
            Me.ButtonItemActions_ShowCodes.Stretch = True
            Me.ButtonItemActions_ShowCodes.SubItemsExpandWidth = 14
            Me.ButtonItemActions_ShowCodes.Text = "Show Codes"
            '
            'ButtonItemActions_ShowDescriptions
            '
            Me.ButtonItemActions_ShowDescriptions.AutoCheckOnClick = True
            Me.ButtonItemActions_ShowDescriptions.BeginGroup = True
            Me.ButtonItemActions_ShowDescriptions.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_ShowDescriptions.Name = "ButtonItemActions_ShowDescriptions"
            Me.ButtonItemActions_ShowDescriptions.OptionGroup = "Show"
            Me.ButtonItemActions_ShowDescriptions.SecurityEnabled = True
            Me.ButtonItemActions_ShowDescriptions.SubItemsExpandWidth = 14
            Me.ButtonItemActions_ShowDescriptions.Text = "Show Descriptions"
            '
            'ButtonItemActions_ShowBoth
            '
            Me.ButtonItemActions_ShowBoth.AutoCheckOnClick = True
            Me.ButtonItemActions_ShowBoth.BeginGroup = True
            Me.ButtonItemActions_ShowBoth.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_ShowBoth.Checked = True
            Me.ButtonItemActions_ShowBoth.Name = "ButtonItemActions_ShowBoth"
            Me.ButtonItemActions_ShowBoth.OptionGroup = "Show"
            Me.ButtonItemActions_ShowBoth.SecurityEnabled = True
            Me.ButtonItemActions_ShowBoth.Stretch = True
            Me.ButtonItemActions_ShowBoth.SubItemsExpandWidth = 14
            Me.ButtonItemActions_ShowBoth.Text = "Show Both"
            '
            'DataGridViewForm_Products
            '
            Me.DataGridViewForm_Products.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_Products.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_Products.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_Products.AutoFilterLookupColumns = False
            Me.DataGridViewForm_Products.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_Products.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewForm_Products.DataSource = Nothing
            Me.DataGridViewForm_Products.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_Products.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_Products.ItemDescription = "CRM Activity(ies)"
            Me.DataGridViewForm_Products.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewForm_Products.MultiSelect = True
            Me.DataGridViewForm_Products.Name = "DataGridViewForm_Products"
            Me.DataGridViewForm_Products.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_Products.RunStandardValidation = True
            Me.DataGridViewForm_Products.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_Products.Size = New System.Drawing.Size(840, 397)
            Me.DataGridViewForm_Products.TabIndex = 4
            Me.DataGridViewForm_Products.UseEmbeddedNavigator = False
            Me.DataGridViewForm_Products.ViewCaptionHeight = -1
            '
            'CRMCentralSetupForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(864, 421)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.DataGridViewForm_Products)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "CRMCentralSetupForm"
            Me.Text = "CRM Central"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Export As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents DataGridViewForm_Products As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarOptions_Diary As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemDiary_Add As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Product As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemProduct_Edit As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Division As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemDivision_Edit As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Client As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemClient_Edit As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_ClientContacts As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemClientContacts_View As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemProduct_CompanyProfile As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemProduct_ActivitySummary As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemProduct_Contracts As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Print As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ItemContainerActions_Actions As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemActions_ShowCodes As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_ShowDescriptions As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_ShowBoth As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Activity As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActivity_Add As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
    End Class

End Namespace

