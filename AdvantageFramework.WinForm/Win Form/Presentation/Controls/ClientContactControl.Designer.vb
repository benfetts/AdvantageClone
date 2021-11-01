Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ClientContactControl
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ClientContactControl))
            Me.TabControlControl_ClientContactDetails = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelSetup_Setup = New DevComponents.DotNetBar.TabControlPanel()
            Me.SearchableComboBoxSetup_Client = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView2 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxSetup_ContactType = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView1 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelSetup_ContactType = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.GroupBoxSetup_Options = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.CheckBoxOptions_EmailRecipient = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxOptions_GetsAlerts = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxOptions_ClientPortalUser = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxOptions_ScheduleUser = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.GroupBoxSetup_Comment = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.TextBoxComment_Comment = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.GroupBoxInformation_Contact = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.TextBoxContactInformation_FaxExtension = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxContactInformation_PhoneExtension = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelContactInformation_FaxExtension = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelContactInformation_PhoneExtension = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxContactInformation_Fax = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxContactInformation_CellPhone = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxContactInformation_Phone = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxContactInformation_Email = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxContactInformation_Title = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxContactInformation_LastName = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxContactInformation_MiddleInitial = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelContactInformation_MiddleInitial = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxContactInformation_FirstName = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelContactInformation_Email = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelContactInformation_Title = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelContactInformation_Fax = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelContactInformation_CellPhone = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelContactInformation_Phone = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelContactInformation_LastName = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelContactInformation_FirstName = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ButtonSetup_BillingRefresh = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonItemAddressRefresh_Client = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemAddressRefresh_Division = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemAddressRefresh_Product = New DevComponents.DotNetBar.ButtonItem()
            Me.LabelSetup_Code = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxSetup_Code = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelSetup_Client = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxForm_Inactive = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.AddressControlSetup_Address = New AdvantageFramework.WinForm.Presentation.Controls.AddressControl()
            Me.TabItemClientContactDetails_Setup = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelDivisionProductsTab_DivisionProducts = New DevComponents.DotNetBar.TabControlPanel()
            Me.RadTreeViewRightSection_DivisionProducts = New Telerik.WinControls.UI.RadTreeView()
            Me.TabItemClientContactDetails_DivisionProducts = New DevComponents.DotNetBar.TabItem(Me.components)
            CType(Me.TabControlControl_ClientContactDetails, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlControl_ClientContactDetails.SuspendLayout()
            Me.TabControlPanelSetup_Setup.SuspendLayout()
            CType(Me.SearchableComboBoxSetup_Client.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxSetup_ContactType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxSetup_Options, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxSetup_Options.SuspendLayout()
            CType(Me.GroupBoxSetup_Comment, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxSetup_Comment.SuspendLayout()
            CType(Me.GroupBoxInformation_Contact, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxInformation_Contact.SuspendLayout()
            Me.TabControlPanelDivisionProductsTab_DivisionProducts.SuspendLayout()
            CType(Me.RadTreeViewRightSection_DivisionProducts, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'TabControlControl_ClientContactDetails
            '
            Me.TabControlControl_ClientContactDetails.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
            Me.TabControlControl_ClientContactDetails.CanReorderTabs = False
            Me.TabControlControl_ClientContactDetails.Controls.Add(Me.TabControlPanelSetup_Setup)
            Me.TabControlControl_ClientContactDetails.Controls.Add(Me.TabControlPanelDivisionProductsTab_DivisionProducts)
            Me.TabControlControl_ClientContactDetails.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlControl_ClientContactDetails.Location = New System.Drawing.Point(0, 0)
            Me.TabControlControl_ClientContactDetails.Name = "TabControlControl_ClientContactDetails"
            Me.TabControlControl_ClientContactDetails.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlControl_ClientContactDetails.SelectedTabIndex = 0
            Me.TabControlControl_ClientContactDetails.Size = New System.Drawing.Size(603, 427)
            Me.TabControlControl_ClientContactDetails.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlControl_ClientContactDetails.TabIndex = 0
            Me.TabControlControl_ClientContactDetails.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlControl_ClientContactDetails.Tabs.Add(Me.TabItemClientContactDetails_Setup)
            Me.TabControlControl_ClientContactDetails.Tabs.Add(Me.TabItemClientContactDetails_DivisionProducts)
            Me.TabControlControl_ClientContactDetails.Text = "TabControlForm"
            '
            'TabControlPanelSetup_Setup
            '
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.SearchableComboBoxSetup_Client)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.SearchableComboBoxSetup_ContactType)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.LabelSetup_ContactType)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.GroupBoxSetup_Options)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.GroupBoxSetup_Comment)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.GroupBoxInformation_Contact)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.ButtonSetup_BillingRefresh)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.LabelSetup_Code)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.TextBoxSetup_Code)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.LabelSetup_Client)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.CheckBoxForm_Inactive)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.AddressControlSetup_Address)
            Me.TabControlPanelSetup_Setup.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelSetup_Setup.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelSetup_Setup.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelSetup_Setup.Name = "TabControlPanelSetup_Setup"
            Me.TabControlPanelSetup_Setup.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelSetup_Setup.Size = New System.Drawing.Size(603, 400)
            Me.TabControlPanelSetup_Setup.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelSetup_Setup.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelSetup_Setup.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelSetup_Setup.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelSetup_Setup.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelSetup_Setup.Style.GradientAngle = 90
            Me.TabControlPanelSetup_Setup.TabIndex = 0
            Me.TabControlPanelSetup_Setup.TabItem = Me.TabItemClientContactDetails_Setup
            '
            'SearchableComboBoxSetup_Client
            '
            Me.SearchableComboBoxSetup_Client.ActiveFilterString = ""
            Me.SearchableComboBoxSetup_Client.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxSetup_Client.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxSetup_Client.AutoFillMode = False
            Me.SearchableComboBoxSetup_Client.BookmarkingEnabled = False
            Me.SearchableComboBoxSetup_Client.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Client
            Me.SearchableComboBoxSetup_Client.DataSource = Nothing
            Me.SearchableComboBoxSetup_Client.DisableMouseWheel = False
            Me.SearchableComboBoxSetup_Client.DisplayName = ""
            Me.SearchableComboBoxSetup_Client.EnterMoveNextControl = True
            Me.SearchableComboBoxSetup_Client.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxSetup_Client.Location = New System.Drawing.Point(56, 6)
            Me.SearchableComboBoxSetup_Client.Name = "SearchableComboBoxSetup_Client"
            Me.SearchableComboBoxSetup_Client.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxSetup_Client.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxSetup_Client.Properties.NullText = "Select Client"
            Me.SearchableComboBoxSetup_Client.Properties.ValueMember = "Code"
            Me.SearchableComboBoxSetup_Client.Properties.View = Me.GridView2
            Me.SearchableComboBoxSetup_Client.SecurityEnabled = True
            Me.SearchableComboBoxSetup_Client.SelectedValue = Nothing
            Me.SearchableComboBoxSetup_Client.Size = New System.Drawing.Size(540, 20)
            Me.SearchableComboBoxSetup_Client.TabIndex = 1
            '
            'GridView2
            '
            Me.GridView2.AFActiveFilterString = ""
            Me.GridView2.AllowExtraItemsInGridLookupEdits = True
            Me.GridView2.AutoFilterLookupColumns = False
            Me.GridView2.AutoloadRepositoryDatasource = True
            Me.GridView2.DataSourceClearing = False
            Me.GridView2.EnableDisabledRows = False
            Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView2.Name = "GridView2"
            Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView2.OptionsView.ShowGroupPanel = False
            Me.GridView2.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView2.RunStandardValidation = True
            '
            'SearchableComboBoxSetup_ContactType
            '
            Me.SearchableComboBoxSetup_ContactType.ActiveFilterString = ""
            Me.SearchableComboBoxSetup_ContactType.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxSetup_ContactType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxSetup_ContactType.AutoFillMode = False
            Me.SearchableComboBoxSetup_ContactType.BookmarkingEnabled = False
            Me.SearchableComboBoxSetup_ContactType.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.ContactType
            Me.SearchableComboBoxSetup_ContactType.DataSource = Nothing
            Me.SearchableComboBoxSetup_ContactType.DisableMouseWheel = False
            Me.SearchableComboBoxSetup_ContactType.DisplayName = ""
            Me.SearchableComboBoxSetup_ContactType.EnterMoveNextControl = True
            Me.SearchableComboBoxSetup_ContactType.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxSetup_ContactType.Location = New System.Drawing.Point(233, 32)
            Me.SearchableComboBoxSetup_ContactType.Name = "SearchableComboBoxSetup_ContactType"
            Me.SearchableComboBoxSetup_ContactType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxSetup_ContactType.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxSetup_ContactType.Properties.NullText = "Select Contact Type"
            Me.SearchableComboBoxSetup_ContactType.Properties.ValueMember = "ID"
            Me.SearchableComboBoxSetup_ContactType.Properties.View = Me.GridView1
            Me.SearchableComboBoxSetup_ContactType.SecurityEnabled = True
            Me.SearchableComboBoxSetup_ContactType.SelectedValue = Nothing
            Me.SearchableComboBoxSetup_ContactType.Size = New System.Drawing.Size(282, 20)
            Me.SearchableComboBoxSetup_ContactType.TabIndex = 5
            '
            'GridView1
            '
            Me.GridView1.AFActiveFilterString = ""
            Me.GridView1.AllowExtraItemsInGridLookupEdits = True
            Me.GridView1.AutoFilterLookupColumns = False
            Me.GridView1.AutoloadRepositoryDatasource = True
            Me.GridView1.DataSourceClearing = False
            Me.GridView1.EnableDisabledRows = False
            Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView1.Name = "GridView1"
            Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView1.OptionsView.ShowGroupPanel = False
            Me.GridView1.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView1.RunStandardValidation = True
            '
            'LabelSetup_ContactType
            '
            Me.LabelSetup_ContactType.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSetup_ContactType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSetup_ContactType.Location = New System.Drawing.Point(143, 32)
            Me.LabelSetup_ContactType.Name = "LabelSetup_ContactType"
            Me.LabelSetup_ContactType.Size = New System.Drawing.Size(84, 20)
            Me.LabelSetup_ContactType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSetup_ContactType.TabIndex = 4
            Me.LabelSetup_ContactType.Text = "Contact Type:"
            '
            'GroupBoxSetup_Options
            '
            Me.GroupBoxSetup_Options.Controls.Add(Me.CheckBoxOptions_EmailRecipient)
            Me.GroupBoxSetup_Options.Controls.Add(Me.CheckBoxOptions_GetsAlerts)
            Me.GroupBoxSetup_Options.Controls.Add(Me.CheckBoxOptions_ClientPortalUser)
            Me.GroupBoxSetup_Options.Controls.Add(Me.CheckBoxOptions_ScheduleUser)
            Me.GroupBoxSetup_Options.Location = New System.Drawing.Point(6, 271)
            Me.GroupBoxSetup_Options.Name = "GroupBoxSetup_Options"
            Me.GroupBoxSetup_Options.Size = New System.Drawing.Size(151, 127)
            Me.GroupBoxSetup_Options.TabIndex = 10
            Me.GroupBoxSetup_Options.Text = "Options"
            '
            'CheckBoxOptions_EmailRecipient
            '
            '
            '
            '
            Me.CheckBoxOptions_EmailRecipient.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxOptions_EmailRecipient.CheckValue = 0
            Me.CheckBoxOptions_EmailRecipient.CheckValueChecked = 1
            Me.CheckBoxOptions_EmailRecipient.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxOptions_EmailRecipient.CheckValueUnchecked = 0
            Me.CheckBoxOptions_EmailRecipient.ChildControls = CType(resources.GetObject("CheckBoxOptions_EmailRecipient.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxOptions_EmailRecipient.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxOptions_EmailRecipient.Location = New System.Drawing.Point(26, 104)
            Me.CheckBoxOptions_EmailRecipient.Name = "CheckBoxOptions_EmailRecipient"
            Me.CheckBoxOptions_EmailRecipient.OldestSibling = Nothing
            Me.CheckBoxOptions_EmailRecipient.SecurityEnabled = True
            Me.CheckBoxOptions_EmailRecipient.SiblingControls = CType(resources.GetObject("CheckBoxOptions_EmailRecipient.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxOptions_EmailRecipient.Size = New System.Drawing.Size(123, 20)
            Me.CheckBoxOptions_EmailRecipient.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxOptions_EmailRecipient.TabIndex = 3
            Me.CheckBoxOptions_EmailRecipient.TabOnEnter = True
            Me.CheckBoxOptions_EmailRecipient.Text = "Email Recipient"
            '
            'CheckBoxOptions_GetsAlerts
            '
            '
            '
            '
            Me.CheckBoxOptions_GetsAlerts.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxOptions_GetsAlerts.CheckValue = 0
            Me.CheckBoxOptions_GetsAlerts.CheckValueChecked = 1
            Me.CheckBoxOptions_GetsAlerts.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxOptions_GetsAlerts.CheckValueUnchecked = 0
            Me.CheckBoxOptions_GetsAlerts.ChildControls = CType(resources.GetObject("CheckBoxOptions_GetsAlerts.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxOptions_GetsAlerts.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxOptions_GetsAlerts.Location = New System.Drawing.Point(26, 78)
            Me.CheckBoxOptions_GetsAlerts.Name = "CheckBoxOptions_GetsAlerts"
            Me.CheckBoxOptions_GetsAlerts.OldestSibling = Nothing
            Me.CheckBoxOptions_GetsAlerts.SecurityEnabled = True
            Me.CheckBoxOptions_GetsAlerts.SiblingControls = CType(resources.GetObject("CheckBoxOptions_GetsAlerts.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxOptions_GetsAlerts.Size = New System.Drawing.Size(123, 20)
            Me.CheckBoxOptions_GetsAlerts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxOptions_GetsAlerts.TabIndex = 2
            Me.CheckBoxOptions_GetsAlerts.TabOnEnter = True
            Me.CheckBoxOptions_GetsAlerts.Text = "Gets Alerts"
            '
            'CheckBoxOptions_ClientPortalUser
            '
            '
            '
            '
            Me.CheckBoxOptions_ClientPortalUser.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxOptions_ClientPortalUser.CheckValue = 0
            Me.CheckBoxOptions_ClientPortalUser.CheckValueChecked = 1
            Me.CheckBoxOptions_ClientPortalUser.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxOptions_ClientPortalUser.CheckValueUnchecked = 0
            Me.CheckBoxOptions_ClientPortalUser.ChildControls = CType(resources.GetObject("CheckBoxOptions_ClientPortalUser.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxOptions_ClientPortalUser.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxOptions_ClientPortalUser.Location = New System.Drawing.Point(6, 52)
            Me.CheckBoxOptions_ClientPortalUser.Name = "CheckBoxOptions_ClientPortalUser"
            Me.CheckBoxOptions_ClientPortalUser.OldestSibling = Nothing
            Me.CheckBoxOptions_ClientPortalUser.SecurityEnabled = True
            Me.CheckBoxOptions_ClientPortalUser.SiblingControls = CType(resources.GetObject("CheckBoxOptions_ClientPortalUser.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxOptions_ClientPortalUser.Size = New System.Drawing.Size(123, 20)
            Me.CheckBoxOptions_ClientPortalUser.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxOptions_ClientPortalUser.TabIndex = 1
            Me.CheckBoxOptions_ClientPortalUser.TabOnEnter = True
            Me.CheckBoxOptions_ClientPortalUser.Text = "Client Portal User"
            '
            'CheckBoxOptions_ScheduleUser
            '
            '
            '
            '
            Me.CheckBoxOptions_ScheduleUser.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxOptions_ScheduleUser.CheckValue = 0
            Me.CheckBoxOptions_ScheduleUser.CheckValueChecked = 1
            Me.CheckBoxOptions_ScheduleUser.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxOptions_ScheduleUser.CheckValueUnchecked = 0
            Me.CheckBoxOptions_ScheduleUser.ChildControls = CType(resources.GetObject("CheckBoxOptions_ScheduleUser.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxOptions_ScheduleUser.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxOptions_ScheduleUser.Location = New System.Drawing.Point(6, 26)
            Me.CheckBoxOptions_ScheduleUser.Name = "CheckBoxOptions_ScheduleUser"
            Me.CheckBoxOptions_ScheduleUser.OldestSibling = Nothing
            Me.CheckBoxOptions_ScheduleUser.SecurityEnabled = True
            Me.CheckBoxOptions_ScheduleUser.SiblingControls = CType(resources.GetObject("CheckBoxOptions_ScheduleUser.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxOptions_ScheduleUser.Size = New System.Drawing.Size(100, 20)
            Me.CheckBoxOptions_ScheduleUser.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxOptions_ScheduleUser.TabIndex = 0
            Me.CheckBoxOptions_ScheduleUser.TabOnEnter = True
            Me.CheckBoxOptions_ScheduleUser.Text = "Schedule User"
            '
            'GroupBoxSetup_Comment
            '
            Me.GroupBoxSetup_Comment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxSetup_Comment.Controls.Add(Me.TextBoxComment_Comment)
            Me.GroupBoxSetup_Comment.Location = New System.Drawing.Point(163, 271)
            Me.GroupBoxSetup_Comment.Name = "GroupBoxSetup_Comment"
            Me.GroupBoxSetup_Comment.Size = New System.Drawing.Size(433, 127)
            Me.GroupBoxSetup_Comment.TabIndex = 11
            Me.GroupBoxSetup_Comment.Text = "Comment"
            '
            'TextBoxComment_Comment
            '
            Me.TextBoxComment_Comment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxComment_Comment.Border.Class = "TextBoxBorder"
            Me.TextBoxComment_Comment.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxComment_Comment.CheckSpellingOnValidate = False
            Me.TextBoxComment_Comment.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxComment_Comment.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxComment_Comment.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxComment_Comment.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxComment_Comment.FocusHighlightEnabled = True
            Me.TextBoxComment_Comment.Location = New System.Drawing.Point(5, 25)
            Me.TextBoxComment_Comment.MaxFileSize = CType(0, Long)
            Me.TextBoxComment_Comment.Multiline = True
            Me.TextBoxComment_Comment.Name = "TextBoxComment_Comment"
            Me.TextBoxComment_Comment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.TextBoxComment_Comment.SecurityEnabled = True
            Me.TextBoxComment_Comment.ShowSpellCheckCompleteMessage = True
            Me.TextBoxComment_Comment.Size = New System.Drawing.Size(423, 97)
            Me.TextBoxComment_Comment.StartingFolderName = Nothing
            Me.TextBoxComment_Comment.TabIndex = 1
            Me.TextBoxComment_Comment.TabOnEnter = True
            '
            'GroupBoxInformation_Contact
            '
            Me.GroupBoxInformation_Contact.Controls.Add(Me.TextBoxContactInformation_FaxExtension)
            Me.GroupBoxInformation_Contact.Controls.Add(Me.TextBoxContactInformation_PhoneExtension)
            Me.GroupBoxInformation_Contact.Controls.Add(Me.LabelContactInformation_FaxExtension)
            Me.GroupBoxInformation_Contact.Controls.Add(Me.LabelContactInformation_PhoneExtension)
            Me.GroupBoxInformation_Contact.Controls.Add(Me.TextBoxContactInformation_Fax)
            Me.GroupBoxInformation_Contact.Controls.Add(Me.TextBoxContactInformation_CellPhone)
            Me.GroupBoxInformation_Contact.Controls.Add(Me.TextBoxContactInformation_Phone)
            Me.GroupBoxInformation_Contact.Controls.Add(Me.TextBoxContactInformation_Email)
            Me.GroupBoxInformation_Contact.Controls.Add(Me.TextBoxContactInformation_Title)
            Me.GroupBoxInformation_Contact.Controls.Add(Me.TextBoxContactInformation_LastName)
            Me.GroupBoxInformation_Contact.Controls.Add(Me.TextBoxContactInformation_MiddleInitial)
            Me.GroupBoxInformation_Contact.Controls.Add(Me.LabelContactInformation_MiddleInitial)
            Me.GroupBoxInformation_Contact.Controls.Add(Me.TextBoxContactInformation_FirstName)
            Me.GroupBoxInformation_Contact.Controls.Add(Me.LabelContactInformation_Email)
            Me.GroupBoxInformation_Contact.Controls.Add(Me.LabelContactInformation_Title)
            Me.GroupBoxInformation_Contact.Controls.Add(Me.LabelContactInformation_Fax)
            Me.GroupBoxInformation_Contact.Controls.Add(Me.LabelContactInformation_CellPhone)
            Me.GroupBoxInformation_Contact.Controls.Add(Me.LabelContactInformation_Phone)
            Me.GroupBoxInformation_Contact.Controls.Add(Me.LabelContactInformation_LastName)
            Me.GroupBoxInformation_Contact.Controls.Add(Me.LabelContactInformation_FirstName)
            Me.GroupBoxInformation_Contact.Location = New System.Drawing.Point(6, 58)
            Me.GroupBoxInformation_Contact.Name = "GroupBoxInformation_Contact"
            Me.GroupBoxInformation_Contact.Size = New System.Drawing.Size(292, 207)
            Me.GroupBoxInformation_Contact.TabIndex = 7
            Me.GroupBoxInformation_Contact.Text = "Contact Information"
            '
            'TextBoxContactInformation_FaxExtension
            '
            '
            '
            '
            Me.TextBoxContactInformation_FaxExtension.Border.Class = "TextBoxBorder"
            Me.TextBoxContactInformation_FaxExtension.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxContactInformation_FaxExtension.CheckSpellingOnValidate = False
            Me.TextBoxContactInformation_FaxExtension.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxContactInformation_FaxExtension.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxContactInformation_FaxExtension.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxContactInformation_FaxExtension.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxContactInformation_FaxExtension.FocusHighlightEnabled = True
            Me.TextBoxContactInformation_FaxExtension.Location = New System.Drawing.Point(244, 181)
            Me.TextBoxContactInformation_FaxExtension.MaxFileSize = CType(0, Long)
            Me.TextBoxContactInformation_FaxExtension.Name = "TextBoxContactInformation_FaxExtension"
            Me.TextBoxContactInformation_FaxExtension.SecurityEnabled = True
            Me.TextBoxContactInformation_FaxExtension.ShowSpellCheckCompleteMessage = True
            Me.TextBoxContactInformation_FaxExtension.Size = New System.Drawing.Size(43, 21)
            Me.TextBoxContactInformation_FaxExtension.StartingFolderName = Nothing
            Me.TextBoxContactInformation_FaxExtension.TabIndex = 20
            Me.TextBoxContactInformation_FaxExtension.TabOnEnter = True
            '
            'TextBoxContactInformation_PhoneExtension
            '
            '
            '
            '
            Me.TextBoxContactInformation_PhoneExtension.Border.Class = "TextBoxBorder"
            Me.TextBoxContactInformation_PhoneExtension.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxContactInformation_PhoneExtension.CheckSpellingOnValidate = False
            Me.TextBoxContactInformation_PhoneExtension.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxContactInformation_PhoneExtension.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxContactInformation_PhoneExtension.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxContactInformation_PhoneExtension.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxContactInformation_PhoneExtension.FocusHighlightEnabled = True
            Me.TextBoxContactInformation_PhoneExtension.Location = New System.Drawing.Point(244, 129)
            Me.TextBoxContactInformation_PhoneExtension.MaxFileSize = CType(0, Long)
            Me.TextBoxContactInformation_PhoneExtension.Name = "TextBoxContactInformation_PhoneExtension"
            Me.TextBoxContactInformation_PhoneExtension.SecurityEnabled = True
            Me.TextBoxContactInformation_PhoneExtension.ShowSpellCheckCompleteMessage = True
            Me.TextBoxContactInformation_PhoneExtension.Size = New System.Drawing.Size(43, 21)
            Me.TextBoxContactInformation_PhoneExtension.StartingFolderName = Nothing
            Me.TextBoxContactInformation_PhoneExtension.TabIndex = 14
            Me.TextBoxContactInformation_PhoneExtension.TabOnEnter = True
            '
            'LabelContactInformation_FaxExtension
            '
            Me.LabelContactInformation_FaxExtension.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelContactInformation_FaxExtension.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelContactInformation_FaxExtension.Location = New System.Drawing.Point(217, 183)
            Me.LabelContactInformation_FaxExtension.Name = "LabelContactInformation_FaxExtension"
            Me.LabelContactInformation_FaxExtension.Size = New System.Drawing.Size(21, 20)
            Me.LabelContactInformation_FaxExtension.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelContactInformation_FaxExtension.TabIndex = 19
            Me.LabelContactInformation_FaxExtension.Text = "Ext:"
            '
            'LabelContactInformation_PhoneExtension
            '
            Me.LabelContactInformation_PhoneExtension.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelContactInformation_PhoneExtension.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelContactInformation_PhoneExtension.Location = New System.Drawing.Point(217, 129)
            Me.LabelContactInformation_PhoneExtension.Name = "LabelContactInformation_PhoneExtension"
            Me.LabelContactInformation_PhoneExtension.Size = New System.Drawing.Size(21, 20)
            Me.LabelContactInformation_PhoneExtension.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelContactInformation_PhoneExtension.TabIndex = 13
            Me.LabelContactInformation_PhoneExtension.Text = "Ext:"
            '
            'TextBoxContactInformation_Fax
            '
            '
            '
            '
            Me.TextBoxContactInformation_Fax.Border.Class = "TextBoxBorder"
            Me.TextBoxContactInformation_Fax.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxContactInformation_Fax.CheckSpellingOnValidate = False
            Me.TextBoxContactInformation_Fax.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxContactInformation_Fax.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxContactInformation_Fax.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxContactInformation_Fax.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxContactInformation_Fax.FocusHighlightEnabled = True
            Me.TextBoxContactInformation_Fax.Location = New System.Drawing.Point(75, 181)
            Me.TextBoxContactInformation_Fax.MaxFileSize = CType(0, Long)
            Me.TextBoxContactInformation_Fax.Name = "TextBoxContactInformation_Fax"
            Me.TextBoxContactInformation_Fax.SecurityEnabled = True
            Me.TextBoxContactInformation_Fax.ShowSpellCheckCompleteMessage = True
            Me.TextBoxContactInformation_Fax.Size = New System.Drawing.Size(136, 21)
            Me.TextBoxContactInformation_Fax.StartingFolderName = Nothing
            Me.TextBoxContactInformation_Fax.TabIndex = 18
            Me.TextBoxContactInformation_Fax.TabOnEnter = True
            '
            'TextBoxContactInformation_CellPhone
            '
            '
            '
            '
            Me.TextBoxContactInformation_CellPhone.Border.Class = "TextBoxBorder"
            Me.TextBoxContactInformation_CellPhone.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxContactInformation_CellPhone.CheckSpellingOnValidate = False
            Me.TextBoxContactInformation_CellPhone.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxContactInformation_CellPhone.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxContactInformation_CellPhone.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxContactInformation_CellPhone.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxContactInformation_CellPhone.FocusHighlightEnabled = True
            Me.TextBoxContactInformation_CellPhone.Location = New System.Drawing.Point(75, 155)
            Me.TextBoxContactInformation_CellPhone.MaxFileSize = CType(0, Long)
            Me.TextBoxContactInformation_CellPhone.Name = "TextBoxContactInformation_CellPhone"
            Me.TextBoxContactInformation_CellPhone.SecurityEnabled = True
            Me.TextBoxContactInformation_CellPhone.ShowSpellCheckCompleteMessage = True
            Me.TextBoxContactInformation_CellPhone.Size = New System.Drawing.Size(136, 21)
            Me.TextBoxContactInformation_CellPhone.StartingFolderName = Nothing
            Me.TextBoxContactInformation_CellPhone.TabIndex = 16
            Me.TextBoxContactInformation_CellPhone.TabOnEnter = True
            '
            'TextBoxContactInformation_Phone
            '
            '
            '
            '
            Me.TextBoxContactInformation_Phone.Border.Class = "TextBoxBorder"
            Me.TextBoxContactInformation_Phone.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxContactInformation_Phone.CheckSpellingOnValidate = False
            Me.TextBoxContactInformation_Phone.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxContactInformation_Phone.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxContactInformation_Phone.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxContactInformation_Phone.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxContactInformation_Phone.FocusHighlightEnabled = True
            Me.TextBoxContactInformation_Phone.Location = New System.Drawing.Point(75, 129)
            Me.TextBoxContactInformation_Phone.MaxFileSize = CType(0, Long)
            Me.TextBoxContactInformation_Phone.Name = "TextBoxContactInformation_Phone"
            Me.TextBoxContactInformation_Phone.SecurityEnabled = True
            Me.TextBoxContactInformation_Phone.ShowSpellCheckCompleteMessage = True
            Me.TextBoxContactInformation_Phone.Size = New System.Drawing.Size(136, 21)
            Me.TextBoxContactInformation_Phone.StartingFolderName = Nothing
            Me.TextBoxContactInformation_Phone.TabIndex = 12
            Me.TextBoxContactInformation_Phone.TabOnEnter = True
            '
            'TextBoxContactInformation_Email
            '
            '
            '
            '
            Me.TextBoxContactInformation_Email.Border.Class = "TextBoxBorder"
            Me.TextBoxContactInformation_Email.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxContactInformation_Email.CheckSpellingOnValidate = False
            Me.TextBoxContactInformation_Email.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.Email
            Me.TextBoxContactInformation_Email.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxContactInformation_Email.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxContactInformation_Email.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxContactInformation_Email.FocusHighlightEnabled = True
            Me.TextBoxContactInformation_Email.Location = New System.Drawing.Point(75, 103)
            Me.TextBoxContactInformation_Email.MaxFileSize = CType(0, Long)
            Me.TextBoxContactInformation_Email.Name = "TextBoxContactInformation_Email"
            Me.TextBoxContactInformation_Email.SecurityEnabled = True
            Me.TextBoxContactInformation_Email.ShowSpellCheckCompleteMessage = True
            Me.TextBoxContactInformation_Email.Size = New System.Drawing.Size(212, 21)
            Me.TextBoxContactInformation_Email.StartingFolderName = Nothing
            Me.TextBoxContactInformation_Email.TabIndex = 10
            Me.TextBoxContactInformation_Email.TabOnEnter = True
            '
            'TextBoxContactInformation_Title
            '
            '
            '
            '
            Me.TextBoxContactInformation_Title.Border.Class = "TextBoxBorder"
            Me.TextBoxContactInformation_Title.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxContactInformation_Title.CheckSpellingOnValidate = False
            Me.TextBoxContactInformation_Title.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxContactInformation_Title.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxContactInformation_Title.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxContactInformation_Title.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxContactInformation_Title.FocusHighlightEnabled = True
            Me.TextBoxContactInformation_Title.Location = New System.Drawing.Point(75, 77)
            Me.TextBoxContactInformation_Title.MaxFileSize = CType(0, Long)
            Me.TextBoxContactInformation_Title.Name = "TextBoxContactInformation_Title"
            Me.TextBoxContactInformation_Title.SecurityEnabled = True
            Me.TextBoxContactInformation_Title.ShowSpellCheckCompleteMessage = True
            Me.TextBoxContactInformation_Title.Size = New System.Drawing.Size(212, 21)
            Me.TextBoxContactInformation_Title.StartingFolderName = Nothing
            Me.TextBoxContactInformation_Title.TabIndex = 8
            Me.TextBoxContactInformation_Title.TabOnEnter = True
            '
            'TextBoxContactInformation_LastName
            '
            '
            '
            '
            Me.TextBoxContactInformation_LastName.Border.Class = "TextBoxBorder"
            Me.TextBoxContactInformation_LastName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxContactInformation_LastName.CheckSpellingOnValidate = False
            Me.TextBoxContactInformation_LastName.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxContactInformation_LastName.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxContactInformation_LastName.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxContactInformation_LastName.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxContactInformation_LastName.FocusHighlightEnabled = True
            Me.TextBoxContactInformation_LastName.Location = New System.Drawing.Point(75, 51)
            Me.TextBoxContactInformation_LastName.MaxFileSize = CType(0, Long)
            Me.TextBoxContactInformation_LastName.Name = "TextBoxContactInformation_LastName"
            Me.TextBoxContactInformation_LastName.SecurityEnabled = True
            Me.TextBoxContactInformation_LastName.ShowSpellCheckCompleteMessage = True
            Me.TextBoxContactInformation_LastName.Size = New System.Drawing.Size(212, 21)
            Me.TextBoxContactInformation_LastName.StartingFolderName = Nothing
            Me.TextBoxContactInformation_LastName.TabIndex = 6
            Me.TextBoxContactInformation_LastName.TabOnEnter = True
            '
            'TextBoxContactInformation_MiddleInitial
            '
            '
            '
            '
            Me.TextBoxContactInformation_MiddleInitial.Border.Class = "TextBoxBorder"
            Me.TextBoxContactInformation_MiddleInitial.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxContactInformation_MiddleInitial.CheckSpellingOnValidate = False
            Me.TextBoxContactInformation_MiddleInitial.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxContactInformation_MiddleInitial.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxContactInformation_MiddleInitial.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxContactInformation_MiddleInitial.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxContactInformation_MiddleInitial.FocusHighlightEnabled = True
            Me.TextBoxContactInformation_MiddleInitial.Location = New System.Drawing.Point(264, 25)
            Me.TextBoxContactInformation_MiddleInitial.MaxFileSize = CType(0, Long)
            Me.TextBoxContactInformation_MiddleInitial.Name = "TextBoxContactInformation_MiddleInitial"
            Me.TextBoxContactInformation_MiddleInitial.SecurityEnabled = True
            Me.TextBoxContactInformation_MiddleInitial.ShowSpellCheckCompleteMessage = True
            Me.TextBoxContactInformation_MiddleInitial.Size = New System.Drawing.Size(23, 21)
            Me.TextBoxContactInformation_MiddleInitial.StartingFolderName = Nothing
            Me.TextBoxContactInformation_MiddleInitial.TabIndex = 4
            Me.TextBoxContactInformation_MiddleInitial.TabOnEnter = True
            '
            'LabelContactInformation_MiddleInitial
            '
            Me.LabelContactInformation_MiddleInitial.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelContactInformation_MiddleInitial.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelContactInformation_MiddleInitial.Location = New System.Drawing.Point(237, 25)
            Me.LabelContactInformation_MiddleInitial.Name = "LabelContactInformation_MiddleInitial"
            Me.LabelContactInformation_MiddleInitial.Size = New System.Drawing.Size(21, 20)
            Me.LabelContactInformation_MiddleInitial.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelContactInformation_MiddleInitial.TabIndex = 3
            Me.LabelContactInformation_MiddleInitial.Text = "MI:"
            '
            'TextBoxContactInformation_FirstName
            '
            '
            '
            '
            Me.TextBoxContactInformation_FirstName.Border.Class = "TextBoxBorder"
            Me.TextBoxContactInformation_FirstName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxContactInformation_FirstName.CheckSpellingOnValidate = False
            Me.TextBoxContactInformation_FirstName.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxContactInformation_FirstName.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxContactInformation_FirstName.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxContactInformation_FirstName.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxContactInformation_FirstName.FocusHighlightEnabled = True
            Me.TextBoxContactInformation_FirstName.Location = New System.Drawing.Point(75, 25)
            Me.TextBoxContactInformation_FirstName.MaxFileSize = CType(0, Long)
            Me.TextBoxContactInformation_FirstName.Name = "TextBoxContactInformation_FirstName"
            Me.TextBoxContactInformation_FirstName.SecurityEnabled = True
            Me.TextBoxContactInformation_FirstName.ShowSpellCheckCompleteMessage = True
            Me.TextBoxContactInformation_FirstName.Size = New System.Drawing.Size(156, 21)
            Me.TextBoxContactInformation_FirstName.StartingFolderName = Nothing
            Me.TextBoxContactInformation_FirstName.TabIndex = 2
            Me.TextBoxContactInformation_FirstName.TabOnEnter = True
            '
            'LabelContactInformation_Email
            '
            Me.LabelContactInformation_Email.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelContactInformation_Email.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelContactInformation_Email.Location = New System.Drawing.Point(5, 103)
            Me.LabelContactInformation_Email.Name = "LabelContactInformation_Email"
            Me.LabelContactInformation_Email.Size = New System.Drawing.Size(64, 20)
            Me.LabelContactInformation_Email.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelContactInformation_Email.TabIndex = 9
            Me.LabelContactInformation_Email.Text = "Email:"
            '
            'LabelContactInformation_Title
            '
            Me.LabelContactInformation_Title.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelContactInformation_Title.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelContactInformation_Title.Location = New System.Drawing.Point(5, 77)
            Me.LabelContactInformation_Title.Name = "LabelContactInformation_Title"
            Me.LabelContactInformation_Title.Size = New System.Drawing.Size(64, 20)
            Me.LabelContactInformation_Title.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelContactInformation_Title.TabIndex = 7
            Me.LabelContactInformation_Title.Text = "Title:"
            '
            'LabelContactInformation_Fax
            '
            Me.LabelContactInformation_Fax.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelContactInformation_Fax.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelContactInformation_Fax.Location = New System.Drawing.Point(5, 181)
            Me.LabelContactInformation_Fax.Name = "LabelContactInformation_Fax"
            Me.LabelContactInformation_Fax.Size = New System.Drawing.Size(64, 20)
            Me.LabelContactInformation_Fax.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelContactInformation_Fax.TabIndex = 17
            Me.LabelContactInformation_Fax.Text = "Fax:"
            '
            'LabelContactInformation_CellPhone
            '
            Me.LabelContactInformation_CellPhone.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelContactInformation_CellPhone.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelContactInformation_CellPhone.Location = New System.Drawing.Point(5, 155)
            Me.LabelContactInformation_CellPhone.Name = "LabelContactInformation_CellPhone"
            Me.LabelContactInformation_CellPhone.Size = New System.Drawing.Size(64, 20)
            Me.LabelContactInformation_CellPhone.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelContactInformation_CellPhone.TabIndex = 15
            Me.LabelContactInformation_CellPhone.Text = "Cell:"
            '
            'LabelContactInformation_Phone
            '
            Me.LabelContactInformation_Phone.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelContactInformation_Phone.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelContactInformation_Phone.Location = New System.Drawing.Point(5, 129)
            Me.LabelContactInformation_Phone.Name = "LabelContactInformation_Phone"
            Me.LabelContactInformation_Phone.Size = New System.Drawing.Size(64, 20)
            Me.LabelContactInformation_Phone.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelContactInformation_Phone.TabIndex = 11
            Me.LabelContactInformation_Phone.Text = "Phone:"
            '
            'LabelContactInformation_LastName
            '
            Me.LabelContactInformation_LastName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelContactInformation_LastName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelContactInformation_LastName.Location = New System.Drawing.Point(5, 51)
            Me.LabelContactInformation_LastName.Name = "LabelContactInformation_LastName"
            Me.LabelContactInformation_LastName.Size = New System.Drawing.Size(64, 20)
            Me.LabelContactInformation_LastName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelContactInformation_LastName.TabIndex = 5
            Me.LabelContactInformation_LastName.Text = "Last Name:"
            '
            'LabelContactInformation_FirstName
            '
            Me.LabelContactInformation_FirstName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelContactInformation_FirstName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelContactInformation_FirstName.Location = New System.Drawing.Point(5, 25)
            Me.LabelContactInformation_FirstName.Name = "LabelContactInformation_FirstName"
            Me.LabelContactInformation_FirstName.Size = New System.Drawing.Size(64, 20)
            Me.LabelContactInformation_FirstName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelContactInformation_FirstName.TabIndex = 1
            Me.LabelContactInformation_FirstName.Text = "First Name:"
            '
            'ButtonSetup_BillingRefresh
            '
            Me.ButtonSetup_BillingRefresh.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonSetup_BillingRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonSetup_BillingRefresh.AutoExpandOnClick = True
            Me.ButtonSetup_BillingRefresh.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonSetup_BillingRefresh.CommandParameter = "AddressControlSetup_BillingAddress"
            Me.ButtonSetup_BillingRefresh.Location = New System.Drawing.Point(521, 58)
            Me.ButtonSetup_BillingRefresh.Name = "ButtonSetup_BillingRefresh"
            Me.ButtonSetup_BillingRefresh.SecurityEnabled = True
            Me.ButtonSetup_BillingRefresh.Size = New System.Drawing.Size(75, 20)
            Me.ButtonSetup_BillingRefresh.SplitButton = True
            Me.ButtonSetup_BillingRefresh.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonSetup_BillingRefresh.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemAddressRefresh_Client, Me.ButtonItemAddressRefresh_Division, Me.ButtonItemAddressRefresh_Product})
            Me.ButtonSetup_BillingRefresh.TabIndex = 8
            Me.ButtonSetup_BillingRefresh.Text = "Refresh"
            '
            'ButtonItemAddressRefresh_Client
            '
            Me.ButtonItemAddressRefresh_Client.ImageFixedSize = New System.Drawing.Size(16, 16)
            Me.ButtonItemAddressRefresh_Client.Name = "ButtonItemAddressRefresh_Client"
            Me.ButtonItemAddressRefresh_Client.Text = "Client"
            '
            'ButtonItemAddressRefresh_Division
            '
            Me.ButtonItemAddressRefresh_Division.ImageFixedSize = New System.Drawing.Size(16, 16)
            Me.ButtonItemAddressRefresh_Division.Name = "ButtonItemAddressRefresh_Division"
            Me.ButtonItemAddressRefresh_Division.Text = "Division"
            '
            'ButtonItemAddressRefresh_Product
            '
            Me.ButtonItemAddressRefresh_Product.ImageFixedSize = New System.Drawing.Size(16, 16)
            Me.ButtonItemAddressRefresh_Product.Name = "ButtonItemAddressRefresh_Product"
            Me.ButtonItemAddressRefresh_Product.Text = "Product"
            '
            'LabelSetup_Code
            '
            Me.LabelSetup_Code.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSetup_Code.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSetup_Code.Location = New System.Drawing.Point(6, 32)
            Me.LabelSetup_Code.Name = "LabelSetup_Code"
            Me.LabelSetup_Code.Size = New System.Drawing.Size(36, 20)
            Me.LabelSetup_Code.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSetup_Code.TabIndex = 2
            Me.LabelSetup_Code.Text = "Code:"
            '
            'TextBoxSetup_Code
            '
            '
            '
            '
            Me.TextBoxSetup_Code.Border.Class = "TextBoxBorder"
            Me.TextBoxSetup_Code.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxSetup_Code.CheckSpellingOnValidate = False
            Me.TextBoxSetup_Code.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxSetup_Code.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxSetup_Code.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxSetup_Code.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxSetup_Code.FocusHighlightEnabled = True
            Me.TextBoxSetup_Code.Location = New System.Drawing.Point(56, 32)
            Me.TextBoxSetup_Code.MaxFileSize = CType(0, Long)
            Me.TextBoxSetup_Code.Name = "TextBoxSetup_Code"
            Me.TextBoxSetup_Code.ReadOnly = True
            Me.TextBoxSetup_Code.SecurityEnabled = True
            Me.TextBoxSetup_Code.ShowSpellCheckCompleteMessage = True
            Me.TextBoxSetup_Code.Size = New System.Drawing.Size(81, 20)
            Me.TextBoxSetup_Code.StartingFolderName = Nothing
            Me.TextBoxSetup_Code.TabIndex = 3
            Me.TextBoxSetup_Code.TabOnEnter = True
            '
            'LabelSetup_Client
            '
            Me.LabelSetup_Client.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSetup_Client.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSetup_Client.Location = New System.Drawing.Point(6, 6)
            Me.LabelSetup_Client.Name = "LabelSetup_Client"
            Me.LabelSetup_Client.Size = New System.Drawing.Size(43, 20)
            Me.LabelSetup_Client.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSetup_Client.TabIndex = 0
            Me.LabelSetup_Client.Text = "Client: "
            '
            'CheckBoxForm_Inactive
            '
            Me.CheckBoxForm_Inactive.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxForm_Inactive.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxForm_Inactive.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_Inactive.CheckValue = 0
            Me.CheckBoxForm_Inactive.CheckValueChecked = 1
            Me.CheckBoxForm_Inactive.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_Inactive.CheckValueUnchecked = 0
            Me.CheckBoxForm_Inactive.ChildControls = CType(resources.GetObject("CheckBoxForm_Inactive.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Inactive.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_Inactive.Location = New System.Drawing.Point(521, 32)
            Me.CheckBoxForm_Inactive.Name = "CheckBoxForm_Inactive"
            Me.CheckBoxForm_Inactive.OldestSibling = Nothing
            Me.CheckBoxForm_Inactive.SecurityEnabled = True
            Me.CheckBoxForm_Inactive.SiblingControls = CType(resources.GetObject("CheckBoxForm_Inactive.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Inactive.Size = New System.Drawing.Size(76, 20)
            Me.CheckBoxForm_Inactive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_Inactive.TabIndex = 6
            Me.CheckBoxForm_Inactive.TabOnEnter = True
            Me.CheckBoxForm_Inactive.Text = "Inactive"
            '
            'AddressControlSetup_Address
            '
            Me.AddressControlSetup_Address.Address = Nothing
            Me.AddressControlSetup_Address.Address2 = Nothing
            Me.AddressControlSetup_Address.Address3 = Nothing
            Me.AddressControlSetup_Address.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.AddressControlSetup_Address.City = Nothing
            Me.AddressControlSetup_Address.Country = Nothing
            Me.AddressControlSetup_Address.County = Nothing
            Me.AddressControlSetup_Address.DisableCountry = False
            Me.AddressControlSetup_Address.DisableCounty = False
            Me.AddressControlSetup_Address.Location = New System.Drawing.Point(304, 84)
            Me.AddressControlSetup_Address.Margin = New System.Windows.Forms.Padding(4)
            Me.AddressControlSetup_Address.Name = "AddressControlSetup_Address"
            Me.AddressControlSetup_Address.ReadOnly = False
            Me.AddressControlSetup_Address.ShowCountry = True
            Me.AddressControlSetup_Address.ShowCounty = True
            Me.AddressControlSetup_Address.Size = New System.Drawing.Size(292, 181)
            Me.AddressControlSetup_Address.State = Nothing
            Me.AddressControlSetup_Address.TabIndex = 9
            Me.AddressControlSetup_Address.Title = "Address"
            Me.AddressControlSetup_Address.Zip = Nothing
            '
            'TabItemClientContactDetails_Setup
            '
            Me.TabItemClientContactDetails_Setup.AttachedControl = Me.TabControlPanelSetup_Setup
            Me.TabItemClientContactDetails_Setup.Name = "TabItemClientContactDetails_Setup"
            Me.TabItemClientContactDetails_Setup.Text = "Setup"
            '
            'TabControlPanelDivisionProductsTab_DivisionProducts
            '
            Me.TabControlPanelDivisionProductsTab_DivisionProducts.Controls.Add(Me.RadTreeViewRightSection_DivisionProducts)
            Me.TabControlPanelDivisionProductsTab_DivisionProducts.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelDivisionProductsTab_DivisionProducts.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelDivisionProductsTab_DivisionProducts.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelDivisionProductsTab_DivisionProducts.Name = "TabControlPanelDivisionProductsTab_DivisionProducts"
            Me.TabControlPanelDivisionProductsTab_DivisionProducts.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelDivisionProductsTab_DivisionProducts.Size = New System.Drawing.Size(603, 400)
            Me.TabControlPanelDivisionProductsTab_DivisionProducts.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDivisionProductsTab_DivisionProducts.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDivisionProductsTab_DivisionProducts.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelDivisionProductsTab_DivisionProducts.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelDivisionProductsTab_DivisionProducts.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelDivisionProductsTab_DivisionProducts.Style.GradientAngle = 90
            Me.TabControlPanelDivisionProductsTab_DivisionProducts.TabIndex = 1
            Me.TabControlPanelDivisionProductsTab_DivisionProducts.TabItem = Me.TabItemClientContactDetails_DivisionProducts
            '
            'RadTreeViewRightSection_DivisionProducts
            '
            Me.RadTreeViewRightSection_DivisionProducts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadTreeViewRightSection_DivisionProducts.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
            Me.RadTreeViewRightSection_DivisionProducts.CheckBoxes = True
            Me.RadTreeViewRightSection_DivisionProducts.Cursor = System.Windows.Forms.Cursors.Default
            Me.RadTreeViewRightSection_DivisionProducts.Font = New System.Drawing.Font("Segoe UI", 8.25!)
            Me.RadTreeViewRightSection_DivisionProducts.ForeColor = System.Drawing.Color.Black
            Me.RadTreeViewRightSection_DivisionProducts.Location = New System.Drawing.Point(6, 6)
            Me.RadTreeViewRightSection_DivisionProducts.Name = "RadTreeViewRightSection_DivisionProducts"
            Me.RadTreeViewRightSection_DivisionProducts.RightToLeft = System.Windows.Forms.RightToLeft.No
            '
            '
            '
            Me.RadTreeViewRightSection_DivisionProducts.RootElement.AccessibleDescription = Nothing
            Me.RadTreeViewRightSection_DivisionProducts.RootElement.AccessibleName = Nothing
            Me.RadTreeViewRightSection_DivisionProducts.RootElement.ControlBounds = New System.Drawing.Rectangle(6, 6, 150, 250)
            Me.RadTreeViewRightSection_DivisionProducts.Size = New System.Drawing.Size(591, 390)
            Me.RadTreeViewRightSection_DivisionProducts.SpacingBetweenNodes = -1
            Me.RadTreeViewRightSection_DivisionProducts.TabIndex = 0
            Me.RadTreeViewRightSection_DivisionProducts.Text = "RadTreeView1"
            '
            'TabItemClientContactDetails_DivisionProducts
            '
            Me.TabItemClientContactDetails_DivisionProducts.AttachedControl = Me.TabControlPanelDivisionProductsTab_DivisionProducts
            Me.TabItemClientContactDetails_DivisionProducts.Name = "TabItemClientContactDetails_DivisionProducts"
            Me.TabItemClientContactDetails_DivisionProducts.Text = "Division / Product"
            '
            'ClientContactControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.TabControlControl_ClientContactDetails)
            Me.Name = "ClientContactControl"
            Me.Size = New System.Drawing.Size(603, 427)
            CType(Me.TabControlControl_ClientContactDetails, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlControl_ClientContactDetails.ResumeLayout(False)
            Me.TabControlPanelSetup_Setup.ResumeLayout(False)
            CType(Me.SearchableComboBoxSetup_Client.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxSetup_ContactType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxSetup_Options, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxSetup_Options.ResumeLayout(False)
            CType(Me.GroupBoxSetup_Comment, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxSetup_Comment.ResumeLayout(False)
            CType(Me.GroupBoxInformation_Contact, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxInformation_Contact.ResumeLayout(False)
            Me.TabControlPanelDivisionProductsTab_DivisionProducts.ResumeLayout(False)
            CType(Me.RadTreeViewRightSection_DivisionProducts, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents TabControlControl_ClientContactDetails As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelSetup_Setup As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents GroupBoxSetup_Options As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents CheckBoxOptions_EmailRecipient As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxOptions_GetsAlerts As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxOptions_ClientPortalUser As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxOptions_ScheduleUser As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents GroupBoxSetup_Comment As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents TextBoxComment_Comment As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents GroupBoxInformation_Contact As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents TextBoxContactInformation_FaxExtension As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxContactInformation_PhoneExtension As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelContactInformation_FaxExtension As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelContactInformation_PhoneExtension As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxContactInformation_Fax As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxContactInformation_CellPhone As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxContactInformation_Phone As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxContactInformation_Email As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxContactInformation_Title As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxContactInformation_LastName As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxContactInformation_MiddleInitial As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelContactInformation_MiddleInitial As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxContactInformation_FirstName As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelContactInformation_Email As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelContactInformation_Title As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelContactInformation_Fax As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelContactInformation_CellPhone As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelContactInformation_Phone As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelContactInformation_LastName As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelContactInformation_FirstName As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ButtonSetup_BillingRefresh As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonItemAddressRefresh_Client As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemAddressRefresh_Division As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemAddressRefresh_Product As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents LabelSetup_Code As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxSetup_Code As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelSetup_Client As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents AddressControlSetup_Address As AdvantageFramework.WinForm.Presentation.Controls.AddressControl
        Friend WithEvents CheckBoxForm_Inactive As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents TabItemClientContactDetails_Setup As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelDivisionProductsTab_DivisionProducts As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemClientContactDetails_DivisionProducts As DevComponents.DotNetBar.TabItem
        Private WithEvents RadTreeViewRightSection_DivisionProducts As Telerik.WinControls.UI.RadTreeView
        Friend WithEvents LabelSetup_ContactType As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxSetup_ContactType As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView1 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxSetup_Client As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView2 As AdvantageFramework.WinForm.Presentation.Controls.GridView

    End Class

End Namespace
