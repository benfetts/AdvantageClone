Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class VendorRepresentativeControl
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VendorRepresentativeControl))
            Me.TabControlControl_VendorRepDetails = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelSetup_Setup = New DevComponents.DotNetBar.TabControlPanel()
            Me.LabelSetup_ContactType = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TableLayoutPanelSetup_TableLayout = New System.Windows.Forms.TableLayoutPanel()
            Me.PanelTableLayout_RightColumn = New System.Windows.Forms.Panel()
            Me.LabelSetup_Contact = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSetup_Phone = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxSetup_FaxExt = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelSetup_Fax = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSetup_FaxExt = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSetup_Cell = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxSetup_PhoneExt = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxSetup_Phone = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelSetup_PhoneExt = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxSetup_Fax = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxSetup_Email = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxSetup_Cell = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelSetup_Email = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.PanelTableLayout_LeftColumn = New System.Windows.Forms.Panel()
            Me.AddressControlSetup_Address = New AdvantageFramework.WinForm.Presentation.Controls.AddressControl()
            Me.ButtonSetup_Refresh = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonItemRefresh_Vendor = New DevComponents.DotNetBar.ButtonItem()
            Me.CheckBoxSetup_Inactive = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.TextBoxSetup_LastName = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxSetup_MiddleInitial = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelSetup_MiddleInitial = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxSetup_FirstName = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxSetup_FirmName = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelSetup_LastName = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSetup_FirstName = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSetup_FirmName = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSetup_Representative = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSetup_Vendor = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxSetup_Code = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TabItemVendorRepDetails_Setup = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelClients_Clients = New DevComponents.DotNetBar.TabControlPanel()
            Me.PanelClients_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.ButtonRightSection_RemoveClient = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonRightSection_AddClient = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DataGridViewRightSection_SelectedClients = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ExpandableSplitterControlClients_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelClients_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewLeftSection_AvailableClients = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemVendorRepDetails_Clients = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.SearchableComboBoxSetup_Vendor = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView1 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxSetup_ContactType = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView2 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            CType(Me.TabControlControl_VendorRepDetails, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlControl_VendorRepDetails.SuspendLayout()
            Me.TabControlPanelSetup_Setup.SuspendLayout()
            Me.TableLayoutPanelSetup_TableLayout.SuspendLayout()
            Me.PanelTableLayout_RightColumn.SuspendLayout()
            Me.PanelTableLayout_LeftColumn.SuspendLayout()
            Me.TabControlPanelClients_Clients.SuspendLayout()
            CType(Me.PanelClients_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelClients_RightSection.SuspendLayout()
            CType(Me.PanelClients_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelClients_LeftSection.SuspendLayout()
            CType(Me.SearchableComboBoxSetup_Vendor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxSetup_ContactType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'TabControlControl_VendorRepDetails
            '
            Me.TabControlControl_VendorRepDetails.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
            Me.TabControlControl_VendorRepDetails.CanReorderTabs = False
            Me.TabControlControl_VendorRepDetails.Controls.Add(Me.TabControlPanelSetup_Setup)
            Me.TabControlControl_VendorRepDetails.Controls.Add(Me.TabControlPanelClients_Clients)
            Me.TabControlControl_VendorRepDetails.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlControl_VendorRepDetails.Location = New System.Drawing.Point(0, 0)
            Me.TabControlControl_VendorRepDetails.Name = "TabControlControl_VendorRepDetails"
            Me.TabControlControl_VendorRepDetails.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlControl_VendorRepDetails.SelectedTabIndex = 0
            Me.TabControlControl_VendorRepDetails.Size = New System.Drawing.Size(603, 398)
            Me.TabControlControl_VendorRepDetails.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlControl_VendorRepDetails.TabIndex = 0
            Me.TabControlControl_VendorRepDetails.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlControl_VendorRepDetails.Tabs.Add(Me.TabItemVendorRepDetails_Setup)
            Me.TabControlControl_VendorRepDetails.Tabs.Add(Me.TabItemVendorRepDetails_Clients)
            Me.TabControlControl_VendorRepDetails.Text = "TabControl1"
            '
            'TabControlPanelSetup_Setup
            '
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.SearchableComboBoxSetup_ContactType)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.SearchableComboBoxSetup_Vendor)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.LabelSetup_ContactType)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.TableLayoutPanelSetup_TableLayout)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.CheckBoxSetup_Inactive)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.TextBoxSetup_LastName)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.TextBoxSetup_MiddleInitial)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.LabelSetup_MiddleInitial)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.TextBoxSetup_FirstName)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.TextBoxSetup_FirmName)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.LabelSetup_LastName)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.LabelSetup_FirstName)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.LabelSetup_FirmName)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.LabelSetup_Representative)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.LabelSetup_Vendor)
            Me.TabControlPanelSetup_Setup.Controls.Add(Me.TextBoxSetup_Code)
            Me.TabControlPanelSetup_Setup.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelSetup_Setup.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelSetup_Setup.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelSetup_Setup.Name = "TabControlPanelSetup_Setup"
            Me.TabControlPanelSetup_Setup.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelSetup_Setup.Size = New System.Drawing.Size(603, 371)
            Me.TabControlPanelSetup_Setup.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelSetup_Setup.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelSetup_Setup.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelSetup_Setup.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelSetup_Setup.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelSetup_Setup.Style.GradientAngle = 90
            Me.TabControlPanelSetup_Setup.TabIndex = 0
            Me.TabControlPanelSetup_Setup.TabItem = Me.TabItemVendorRepDetails_Setup
            '
            'LabelSetup_ContactType
            '
            Me.LabelSetup_ContactType.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSetup_ContactType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSetup_ContactType.Location = New System.Drawing.Point(6, 84)
            Me.LabelSetup_ContactType.Name = "LabelSetup_ContactType"
            Me.LabelSetup_ContactType.Size = New System.Drawing.Size(84, 20)
            Me.LabelSetup_ContactType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSetup_ContactType.TabIndex = 7
            Me.LabelSetup_ContactType.Text = "Contact Type:"
            '
            'TableLayoutPanelSetup_TableLayout
            '
            Me.TableLayoutPanelSetup_TableLayout.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TableLayoutPanelSetup_TableLayout.BackColor = System.Drawing.Color.White
            Me.TableLayoutPanelSetup_TableLayout.ColumnCount = 2
            Me.TableLayoutPanelSetup_TableLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanelSetup_TableLayout.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanelSetup_TableLayout.Controls.Add(Me.PanelTableLayout_RightColumn, 1, 0)
            Me.TableLayoutPanelSetup_TableLayout.Controls.Add(Me.PanelTableLayout_LeftColumn, 0, 0)
            Me.TableLayoutPanelSetup_TableLayout.Location = New System.Drawing.Point(7, 163)
            Me.TableLayoutPanelSetup_TableLayout.Name = "TableLayoutPanelSetup_TableLayout"
            Me.TableLayoutPanelSetup_TableLayout.RowCount = 1
            Me.TableLayoutPanelSetup_TableLayout.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanelSetup_TableLayout.Size = New System.Drawing.Size(589, 209)
            Me.TableLayoutPanelSetup_TableLayout.TabIndex = 30
            '
            'PanelTableLayout_RightColumn
            '
            Me.PanelTableLayout_RightColumn.Controls.Add(Me.LabelSetup_Contact)
            Me.PanelTableLayout_RightColumn.Controls.Add(Me.LabelSetup_Phone)
            Me.PanelTableLayout_RightColumn.Controls.Add(Me.TextBoxSetup_FaxExt)
            Me.PanelTableLayout_RightColumn.Controls.Add(Me.LabelSetup_Fax)
            Me.PanelTableLayout_RightColumn.Controls.Add(Me.LabelSetup_FaxExt)
            Me.PanelTableLayout_RightColumn.Controls.Add(Me.LabelSetup_Cell)
            Me.PanelTableLayout_RightColumn.Controls.Add(Me.TextBoxSetup_PhoneExt)
            Me.PanelTableLayout_RightColumn.Controls.Add(Me.TextBoxSetup_Phone)
            Me.PanelTableLayout_RightColumn.Controls.Add(Me.LabelSetup_PhoneExt)
            Me.PanelTableLayout_RightColumn.Controls.Add(Me.TextBoxSetup_Fax)
            Me.PanelTableLayout_RightColumn.Controls.Add(Me.TextBoxSetup_Email)
            Me.PanelTableLayout_RightColumn.Controls.Add(Me.TextBoxSetup_Cell)
            Me.PanelTableLayout_RightColumn.Controls.Add(Me.LabelSetup_Email)
            Me.PanelTableLayout_RightColumn.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelTableLayout_RightColumn.Location = New System.Drawing.Point(294, 0)
            Me.PanelTableLayout_RightColumn.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelTableLayout_RightColumn.Name = "PanelTableLayout_RightColumn"
            Me.PanelTableLayout_RightColumn.Size = New System.Drawing.Size(295, 209)
            Me.PanelTableLayout_RightColumn.TabIndex = 1
            '
            'LabelSetup_Contact
            '
            Me.LabelSetup_Contact.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelSetup_Contact.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSetup_Contact.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelSetup_Contact.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelSetup_Contact.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelSetup_Contact.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelSetup_Contact.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelSetup_Contact.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelSetup_Contact.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSetup_Contact.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelSetup_Contact.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelSetup_Contact.Location = New System.Drawing.Point(3, 25)
            Me.LabelSetup_Contact.Name = "LabelSetup_Contact"
            Me.LabelSetup_Contact.Size = New System.Drawing.Size(292, 20)
            Me.LabelSetup_Contact.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSetup_Contact.TabIndex = 17
            Me.LabelSetup_Contact.Text = "Contact"
            '
            'LabelSetup_Phone
            '
            Me.LabelSetup_Phone.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSetup_Phone.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSetup_Phone.Location = New System.Drawing.Point(3, 51)
            Me.LabelSetup_Phone.Name = "LabelSetup_Phone"
            Me.LabelSetup_Phone.Size = New System.Drawing.Size(43, 20)
            Me.LabelSetup_Phone.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSetup_Phone.TabIndex = 18
            Me.LabelSetup_Phone.Text = "Phone:"
            '
            'TextBoxSetup_FaxExt
            '
            Me.TextBoxSetup_FaxExt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxSetup_FaxExt.Border.Class = "TextBoxBorder"
            Me.TextBoxSetup_FaxExt.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxSetup_FaxExt.CheckSpellingOnValidate = False
            Me.TextBoxSetup_FaxExt.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxSetup_FaxExt.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxSetup_FaxExt.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxSetup_FaxExt.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxSetup_FaxExt.FocusHighlightEnabled = True
            Me.TextBoxSetup_FaxExt.Location = New System.Drawing.Point(245, 77)
            Me.TextBoxSetup_FaxExt.MaxFileSize = CType(0, Long)
            Me.TextBoxSetup_FaxExt.Name = "TextBoxSetup_FaxExt"
            Me.TextBoxSetup_FaxExt.SecurityEnabled = True
            Me.TextBoxSetup_FaxExt.ShowSpellCheckCompleteMessage = True
            Me.TextBoxSetup_FaxExt.Size = New System.Drawing.Size(50, 20)
            Me.TextBoxSetup_FaxExt.StartingFolderName = Nothing
            Me.TextBoxSetup_FaxExt.TabIndex = 25
            Me.TextBoxSetup_FaxExt.TabOnEnter = True
            '
            'LabelSetup_Fax
            '
            Me.LabelSetup_Fax.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSetup_Fax.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSetup_Fax.Location = New System.Drawing.Point(3, 77)
            Me.LabelSetup_Fax.Name = "LabelSetup_Fax"
            Me.LabelSetup_Fax.Size = New System.Drawing.Size(43, 20)
            Me.LabelSetup_Fax.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSetup_Fax.TabIndex = 22
            Me.LabelSetup_Fax.Text = "Fax:"
            '
            'LabelSetup_FaxExt
            '
            Me.LabelSetup_FaxExt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelSetup_FaxExt.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSetup_FaxExt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSetup_FaxExt.Location = New System.Drawing.Point(217, 77)
            Me.LabelSetup_FaxExt.Name = "LabelSetup_FaxExt"
            Me.LabelSetup_FaxExt.Size = New System.Drawing.Size(22, 20)
            Me.LabelSetup_FaxExt.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSetup_FaxExt.TabIndex = 24
            Me.LabelSetup_FaxExt.Text = "Ext:"
            '
            'LabelSetup_Cell
            '
            Me.LabelSetup_Cell.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSetup_Cell.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSetup_Cell.Location = New System.Drawing.Point(3, 103)
            Me.LabelSetup_Cell.Name = "LabelSetup_Cell"
            Me.LabelSetup_Cell.Size = New System.Drawing.Size(43, 20)
            Me.LabelSetup_Cell.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSetup_Cell.TabIndex = 26
            Me.LabelSetup_Cell.Text = "Cell:"
            '
            'TextBoxSetup_PhoneExt
            '
            Me.TextBoxSetup_PhoneExt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxSetup_PhoneExt.Border.Class = "TextBoxBorder"
            Me.TextBoxSetup_PhoneExt.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxSetup_PhoneExt.CheckSpellingOnValidate = False
            Me.TextBoxSetup_PhoneExt.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxSetup_PhoneExt.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxSetup_PhoneExt.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxSetup_PhoneExt.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxSetup_PhoneExt.FocusHighlightEnabled = True
            Me.TextBoxSetup_PhoneExt.Location = New System.Drawing.Point(245, 51)
            Me.TextBoxSetup_PhoneExt.MaxFileSize = CType(0, Long)
            Me.TextBoxSetup_PhoneExt.Name = "TextBoxSetup_PhoneExt"
            Me.TextBoxSetup_PhoneExt.SecurityEnabled = True
            Me.TextBoxSetup_PhoneExt.ShowSpellCheckCompleteMessage = True
            Me.TextBoxSetup_PhoneExt.Size = New System.Drawing.Size(50, 20)
            Me.TextBoxSetup_PhoneExt.StartingFolderName = Nothing
            Me.TextBoxSetup_PhoneExt.TabIndex = 21
            Me.TextBoxSetup_PhoneExt.TabOnEnter = True
            '
            'TextBoxSetup_Phone
            '
            Me.TextBoxSetup_Phone.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxSetup_Phone.Border.Class = "TextBoxBorder"
            Me.TextBoxSetup_Phone.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxSetup_Phone.CheckSpellingOnValidate = False
            Me.TextBoxSetup_Phone.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxSetup_Phone.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxSetup_Phone.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxSetup_Phone.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxSetup_Phone.FocusHighlightEnabled = True
            Me.TextBoxSetup_Phone.Location = New System.Drawing.Point(52, 51)
            Me.TextBoxSetup_Phone.MaxFileSize = CType(0, Long)
            Me.TextBoxSetup_Phone.Name = "TextBoxSetup_Phone"
            Me.TextBoxSetup_Phone.SecurityEnabled = True
            Me.TextBoxSetup_Phone.ShowSpellCheckCompleteMessage = True
            Me.TextBoxSetup_Phone.Size = New System.Drawing.Size(159, 20)
            Me.TextBoxSetup_Phone.StartingFolderName = Nothing
            Me.TextBoxSetup_Phone.TabIndex = 19
            Me.TextBoxSetup_Phone.TabOnEnter = True
            '
            'LabelSetup_PhoneExt
            '
            Me.LabelSetup_PhoneExt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelSetup_PhoneExt.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSetup_PhoneExt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSetup_PhoneExt.Location = New System.Drawing.Point(217, 51)
            Me.LabelSetup_PhoneExt.Name = "LabelSetup_PhoneExt"
            Me.LabelSetup_PhoneExt.Size = New System.Drawing.Size(22, 20)
            Me.LabelSetup_PhoneExt.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSetup_PhoneExt.TabIndex = 20
            Me.LabelSetup_PhoneExt.Text = "Ext:"
            '
            'TextBoxSetup_Fax
            '
            Me.TextBoxSetup_Fax.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxSetup_Fax.Border.Class = "TextBoxBorder"
            Me.TextBoxSetup_Fax.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxSetup_Fax.CheckSpellingOnValidate = False
            Me.TextBoxSetup_Fax.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxSetup_Fax.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxSetup_Fax.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxSetup_Fax.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxSetup_Fax.FocusHighlightEnabled = True
            Me.TextBoxSetup_Fax.Location = New System.Drawing.Point(52, 77)
            Me.TextBoxSetup_Fax.MaxFileSize = CType(0, Long)
            Me.TextBoxSetup_Fax.Name = "TextBoxSetup_Fax"
            Me.TextBoxSetup_Fax.SecurityEnabled = True
            Me.TextBoxSetup_Fax.ShowSpellCheckCompleteMessage = True
            Me.TextBoxSetup_Fax.Size = New System.Drawing.Size(159, 20)
            Me.TextBoxSetup_Fax.StartingFolderName = Nothing
            Me.TextBoxSetup_Fax.TabIndex = 23
            Me.TextBoxSetup_Fax.TabOnEnter = True
            '
            'TextBoxSetup_Email
            '
            Me.TextBoxSetup_Email.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxSetup_Email.Border.Class = "TextBoxBorder"
            Me.TextBoxSetup_Email.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxSetup_Email.CheckSpellingOnValidate = False
            Me.TextBoxSetup_Email.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.Email
            Me.TextBoxSetup_Email.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxSetup_Email.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxSetup_Email.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxSetup_Email.FocusHighlightEnabled = True
            Me.TextBoxSetup_Email.Location = New System.Drawing.Point(52, 129)
            Me.TextBoxSetup_Email.MaxFileSize = CType(0, Long)
            Me.TextBoxSetup_Email.Name = "TextBoxSetup_Email"
            Me.TextBoxSetup_Email.SecurityEnabled = True
            Me.TextBoxSetup_Email.ShowSpellCheckCompleteMessage = True
            Me.TextBoxSetup_Email.Size = New System.Drawing.Size(243, 20)
            Me.TextBoxSetup_Email.StartingFolderName = Nothing
            Me.TextBoxSetup_Email.TabIndex = 29
            Me.TextBoxSetup_Email.TabOnEnter = True
            '
            'TextBoxSetup_Cell
            '
            Me.TextBoxSetup_Cell.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxSetup_Cell.Border.Class = "TextBoxBorder"
            Me.TextBoxSetup_Cell.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxSetup_Cell.CheckSpellingOnValidate = False
            Me.TextBoxSetup_Cell.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxSetup_Cell.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxSetup_Cell.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxSetup_Cell.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxSetup_Cell.FocusHighlightEnabled = True
            Me.TextBoxSetup_Cell.Location = New System.Drawing.Point(52, 103)
            Me.TextBoxSetup_Cell.MaxFileSize = CType(0, Long)
            Me.TextBoxSetup_Cell.Name = "TextBoxSetup_Cell"
            Me.TextBoxSetup_Cell.SecurityEnabled = True
            Me.TextBoxSetup_Cell.ShowSpellCheckCompleteMessage = True
            Me.TextBoxSetup_Cell.Size = New System.Drawing.Size(159, 20)
            Me.TextBoxSetup_Cell.StartingFolderName = Nothing
            Me.TextBoxSetup_Cell.TabIndex = 27
            Me.TextBoxSetup_Cell.TabOnEnter = True
            '
            'LabelSetup_Email
            '
            Me.LabelSetup_Email.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSetup_Email.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSetup_Email.Location = New System.Drawing.Point(3, 129)
            Me.LabelSetup_Email.Name = "LabelSetup_Email"
            Me.LabelSetup_Email.Size = New System.Drawing.Size(43, 20)
            Me.LabelSetup_Email.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSetup_Email.TabIndex = 28
            Me.LabelSetup_Email.Text = "Email:"
            '
            'PanelTableLayout_LeftColumn
            '
            Me.PanelTableLayout_LeftColumn.Controls.Add(Me.AddressControlSetup_Address)
            Me.PanelTableLayout_LeftColumn.Controls.Add(Me.ButtonSetup_Refresh)
            Me.PanelTableLayout_LeftColumn.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelTableLayout_LeftColumn.Location = New System.Drawing.Point(0, 0)
            Me.PanelTableLayout_LeftColumn.Margin = New System.Windows.Forms.Padding(0)
            Me.PanelTableLayout_LeftColumn.Name = "PanelTableLayout_LeftColumn"
            Me.PanelTableLayout_LeftColumn.Size = New System.Drawing.Size(294, 209)
            Me.PanelTableLayout_LeftColumn.TabIndex = 0
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
            Me.AddressControlSetup_Address.Location = New System.Drawing.Point(0, 25)
            Me.AddressControlSetup_Address.Margin = New System.Windows.Forms.Padding(4)
            Me.AddressControlSetup_Address.Name = "AddressControlSetup_Address"
            Me.AddressControlSetup_Address.ReadOnly = False
            Me.AddressControlSetup_Address.ShowCountry = True
            Me.AddressControlSetup_Address.ShowCounty = True
            Me.AddressControlSetup_Address.Size = New System.Drawing.Size(291, 181)
            Me.AddressControlSetup_Address.State = Nothing
            Me.AddressControlSetup_Address.TabIndex = 16
            Me.AddressControlSetup_Address.Title = "Address"
            Me.AddressControlSetup_Address.Zip = Nothing
            '
            'ButtonSetup_Refresh
            '
            Me.ButtonSetup_Refresh.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonSetup_Refresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonSetup_Refresh.AutoExpandOnClick = True
            Me.ButtonSetup_Refresh.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonSetup_Refresh.Location = New System.Drawing.Point(216, 0)
            Me.ButtonSetup_Refresh.Name = "ButtonSetup_Refresh"
            Me.ButtonSetup_Refresh.SecurityEnabled = True
            Me.ButtonSetup_Refresh.Size = New System.Drawing.Size(75, 20)
            Me.ButtonSetup_Refresh.SplitButton = True
            Me.ButtonSetup_Refresh.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonSetup_Refresh.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemRefresh_Vendor})
            Me.ButtonSetup_Refresh.TabIndex = 15
            Me.ButtonSetup_Refresh.Text = "Refresh"
            '
            'ButtonItemRefresh_Vendor
            '
            Me.ButtonItemRefresh_Vendor.Name = "ButtonItemRefresh_Vendor"
            Me.ButtonItemRefresh_Vendor.Text = "Vendor"
            '
            'CheckBoxSetup_Inactive
            '
            Me.CheckBoxSetup_Inactive.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxSetup_Inactive.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxSetup_Inactive.CheckValue = 0
            Me.CheckBoxSetup_Inactive.CheckValueChecked = 1
            Me.CheckBoxSetup_Inactive.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxSetup_Inactive.CheckValueUnchecked = 0
            Me.CheckBoxSetup_Inactive.ChildControls = CType(resources.GetObject("CheckBoxSetup_Inactive.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSetup_Inactive.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxSetup_Inactive.Location = New System.Drawing.Point(183, 32)
            Me.CheckBoxSetup_Inactive.Name = "CheckBoxSetup_Inactive"
            Me.CheckBoxSetup_Inactive.OldestSibling = Nothing
            Me.CheckBoxSetup_Inactive.SecurityEnabled = True
            Me.CheckBoxSetup_Inactive.SiblingControls = CType(resources.GetObject("CheckBoxSetup_Inactive.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSetup_Inactive.Size = New System.Drawing.Size(77, 20)
            Me.CheckBoxSetup_Inactive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxSetup_Inactive.TabIndex = 4
            Me.CheckBoxSetup_Inactive.TabOnEnter = True
            Me.CheckBoxSetup_Inactive.Text = "Inactive"
            '
            'TextBoxSetup_LastName
            '
            Me.TextBoxSetup_LastName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxSetup_LastName.Border.Class = "TextBoxBorder"
            Me.TextBoxSetup_LastName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxSetup_LastName.CheckSpellingOnValidate = False
            Me.TextBoxSetup_LastName.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxSetup_LastName.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxSetup_LastName.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxSetup_LastName.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxSetup_LastName.FocusHighlightEnabled = True
            Me.TextBoxSetup_LastName.Location = New System.Drawing.Point(96, 137)
            Me.TextBoxSetup_LastName.MaxFileSize = CType(0, Long)
            Me.TextBoxSetup_LastName.Name = "TextBoxSetup_LastName"
            Me.TextBoxSetup_LastName.SecurityEnabled = True
            Me.TextBoxSetup_LastName.ShowSpellCheckCompleteMessage = True
            Me.TextBoxSetup_LastName.Size = New System.Drawing.Size(501, 20)
            Me.TextBoxSetup_LastName.StartingFolderName = Nothing
            Me.TextBoxSetup_LastName.TabIndex = 14
            Me.TextBoxSetup_LastName.TabOnEnter = True
            '
            'TextBoxSetup_MiddleInitial
            '
            Me.TextBoxSetup_MiddleInitial.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxSetup_MiddleInitial.Border.Class = "TextBoxBorder"
            Me.TextBoxSetup_MiddleInitial.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxSetup_MiddleInitial.CheckSpellingOnValidate = False
            Me.TextBoxSetup_MiddleInitial.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxSetup_MiddleInitial.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxSetup_MiddleInitial.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxSetup_MiddleInitial.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxSetup_MiddleInitial.FocusHighlightEnabled = True
            Me.TextBoxSetup_MiddleInitial.Location = New System.Drawing.Point(564, 111)
            Me.TextBoxSetup_MiddleInitial.MaxFileSize = CType(0, Long)
            Me.TextBoxSetup_MiddleInitial.Name = "TextBoxSetup_MiddleInitial"
            Me.TextBoxSetup_MiddleInitial.SecurityEnabled = True
            Me.TextBoxSetup_MiddleInitial.ShowSpellCheckCompleteMessage = True
            Me.TextBoxSetup_MiddleInitial.Size = New System.Drawing.Size(33, 20)
            Me.TextBoxSetup_MiddleInitial.StartingFolderName = Nothing
            Me.TextBoxSetup_MiddleInitial.TabIndex = 12
            Me.TextBoxSetup_MiddleInitial.TabOnEnter = True
            '
            'LabelSetup_MiddleInitial
            '
            Me.LabelSetup_MiddleInitial.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelSetup_MiddleInitial.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSetup_MiddleInitial.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSetup_MiddleInitial.Location = New System.Drawing.Point(539, 111)
            Me.LabelSetup_MiddleInitial.Name = "LabelSetup_MiddleInitial"
            Me.LabelSetup_MiddleInitial.Size = New System.Drawing.Size(19, 20)
            Me.LabelSetup_MiddleInitial.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSetup_MiddleInitial.TabIndex = 11
            Me.LabelSetup_MiddleInitial.Text = "MI:"
            '
            'TextBoxSetup_FirstName
            '
            Me.TextBoxSetup_FirstName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxSetup_FirstName.Border.Class = "TextBoxBorder"
            Me.TextBoxSetup_FirstName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxSetup_FirstName.CheckSpellingOnValidate = False
            Me.TextBoxSetup_FirstName.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxSetup_FirstName.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxSetup_FirstName.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxSetup_FirstName.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxSetup_FirstName.FocusHighlightEnabled = True
            Me.TextBoxSetup_FirstName.Location = New System.Drawing.Point(96, 111)
            Me.TextBoxSetup_FirstName.MaxFileSize = CType(0, Long)
            Me.TextBoxSetup_FirstName.Name = "TextBoxSetup_FirstName"
            Me.TextBoxSetup_FirstName.SecurityEnabled = True
            Me.TextBoxSetup_FirstName.ShowSpellCheckCompleteMessage = True
            Me.TextBoxSetup_FirstName.Size = New System.Drawing.Size(437, 20)
            Me.TextBoxSetup_FirstName.StartingFolderName = Nothing
            Me.TextBoxSetup_FirstName.TabIndex = 10
            Me.TextBoxSetup_FirstName.TabOnEnter = True
            '
            'TextBoxSetup_FirmName
            '
            Me.TextBoxSetup_FirmName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxSetup_FirmName.Border.Class = "TextBoxBorder"
            Me.TextBoxSetup_FirmName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxSetup_FirmName.CheckSpellingOnValidate = False
            Me.TextBoxSetup_FirmName.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxSetup_FirmName.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxSetup_FirmName.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxSetup_FirmName.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxSetup_FirmName.FocusHighlightEnabled = True
            Me.TextBoxSetup_FirmName.Location = New System.Drawing.Point(96, 58)
            Me.TextBoxSetup_FirmName.MaxFileSize = CType(0, Long)
            Me.TextBoxSetup_FirmName.Name = "TextBoxSetup_FirmName"
            Me.TextBoxSetup_FirmName.SecurityEnabled = True
            Me.TextBoxSetup_FirmName.ShowSpellCheckCompleteMessage = True
            Me.TextBoxSetup_FirmName.Size = New System.Drawing.Size(501, 20)
            Me.TextBoxSetup_FirmName.StartingFolderName = Nothing
            Me.TextBoxSetup_FirmName.TabIndex = 6
            Me.TextBoxSetup_FirmName.TabOnEnter = True
            '
            'LabelSetup_LastName
            '
            Me.LabelSetup_LastName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSetup_LastName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSetup_LastName.Location = New System.Drawing.Point(6, 136)
            Me.LabelSetup_LastName.Name = "LabelSetup_LastName"
            Me.LabelSetup_LastName.Size = New System.Drawing.Size(84, 20)
            Me.LabelSetup_LastName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSetup_LastName.TabIndex = 13
            Me.LabelSetup_LastName.Text = "Last Name:"
            '
            'LabelSetup_FirstName
            '
            Me.LabelSetup_FirstName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSetup_FirstName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSetup_FirstName.Location = New System.Drawing.Point(6, 110)
            Me.LabelSetup_FirstName.Name = "LabelSetup_FirstName"
            Me.LabelSetup_FirstName.Size = New System.Drawing.Size(84, 20)
            Me.LabelSetup_FirstName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSetup_FirstName.TabIndex = 9
            Me.LabelSetup_FirstName.Text = "First Name:"
            '
            'LabelSetup_FirmName
            '
            Me.LabelSetup_FirmName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSetup_FirmName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSetup_FirmName.Location = New System.Drawing.Point(6, 58)
            Me.LabelSetup_FirmName.Name = "LabelSetup_FirmName"
            Me.LabelSetup_FirmName.Size = New System.Drawing.Size(84, 20)
            Me.LabelSetup_FirmName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSetup_FirmName.TabIndex = 5
            Me.LabelSetup_FirmName.Text = "Firm Name:"
            '
            'LabelSetup_Representative
            '
            Me.LabelSetup_Representative.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSetup_Representative.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSetup_Representative.Location = New System.Drawing.Point(6, 32)
            Me.LabelSetup_Representative.Name = "LabelSetup_Representative"
            Me.LabelSetup_Representative.Size = New System.Drawing.Size(84, 20)
            Me.LabelSetup_Representative.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSetup_Representative.TabIndex = 2
            Me.LabelSetup_Representative.Text = "Representative:"
            '
            'LabelSetup_Vendor
            '
            Me.LabelSetup_Vendor.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSetup_Vendor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSetup_Vendor.Location = New System.Drawing.Point(6, 6)
            Me.LabelSetup_Vendor.Name = "LabelSetup_Vendor"
            Me.LabelSetup_Vendor.Size = New System.Drawing.Size(44, 20)
            Me.LabelSetup_Vendor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSetup_Vendor.TabIndex = 0
            Me.LabelSetup_Vendor.Text = "Vendor:"
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
            Me.TextBoxSetup_Code.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxSetup_Code.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxSetup_Code.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxSetup_Code.FocusHighlightEnabled = True
            Me.TextBoxSetup_Code.Location = New System.Drawing.Point(96, 32)
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
            'TabItemVendorRepDetails_Setup
            '
            Me.TabItemVendorRepDetails_Setup.AttachedControl = Me.TabControlPanelSetup_Setup
            Me.TabItemVendorRepDetails_Setup.Name = "TabItemVendorRepDetails_Setup"
            Me.TabItemVendorRepDetails_Setup.Text = "Setup"
            '
            'TabControlPanelClients_Clients
            '
            Me.TabControlPanelClients_Clients.Controls.Add(Me.PanelClients_RightSection)
            Me.TabControlPanelClients_Clients.Controls.Add(Me.ExpandableSplitterControlClients_LeftRight)
            Me.TabControlPanelClients_Clients.Controls.Add(Me.PanelClients_LeftSection)
            Me.TabControlPanelClients_Clients.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelClients_Clients.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelClients_Clients.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelClients_Clients.Name = "TabControlPanelClients_Clients"
            Me.TabControlPanelClients_Clients.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelClients_Clients.Size = New System.Drawing.Size(603, 371)
            Me.TabControlPanelClients_Clients.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelClients_Clients.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelClients_Clients.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelClients_Clients.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelClients_Clients.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelClients_Clients.Style.GradientAngle = 90
            Me.TabControlPanelClients_Clients.TabIndex = 1
            Me.TabControlPanelClients_Clients.TabItem = Me.TabItemVendorRepDetails_Clients
            '
            'PanelClients_RightSection
            '
            Me.PanelClients_RightSection.Controls.Add(Me.ButtonRightSection_RemoveClient)
            Me.PanelClients_RightSection.Controls.Add(Me.ButtonRightSection_AddClient)
            Me.PanelClients_RightSection.Controls.Add(Me.DataGridViewRightSection_SelectedClients)
            Me.PanelClients_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelClients_RightSection.Location = New System.Drawing.Point(209, 1)
            Me.PanelClients_RightSection.Name = "PanelClients_RightSection"
            Me.PanelClients_RightSection.Size = New System.Drawing.Size(393, 369)
            Me.PanelClients_RightSection.TabIndex = 2
            '
            'ButtonRightSection_RemoveClient
            '
            Me.ButtonRightSection_RemoveClient.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSection_RemoveClient.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSection_RemoveClient.Location = New System.Drawing.Point(6, 32)
            Me.ButtonRightSection_RemoveClient.Name = "ButtonRightSection_RemoveClient"
            Me.ButtonRightSection_RemoveClient.SecurityEnabled = True
            Me.ButtonRightSection_RemoveClient.Size = New System.Drawing.Size(75, 20)
            Me.ButtonRightSection_RemoveClient.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSection_RemoveClient.TabIndex = 2
            Me.ButtonRightSection_RemoveClient.Text = "<"
            '
            'ButtonRightSection_AddClient
            '
            Me.ButtonRightSection_AddClient.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSection_AddClient.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSection_AddClient.Location = New System.Drawing.Point(6, 6)
            Me.ButtonRightSection_AddClient.Name = "ButtonRightSection_AddClient"
            Me.ButtonRightSection_AddClient.SecurityEnabled = True
            Me.ButtonRightSection_AddClient.Size = New System.Drawing.Size(75, 20)
            Me.ButtonRightSection_AddClient.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSection_AddClient.TabIndex = 1
            Me.ButtonRightSection_AddClient.Text = ">"
            '
            'DataGridViewRightSection_SelectedClients
            '
            Me.DataGridViewRightSection_SelectedClients.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewRightSection_SelectedClients.AllowDragAndDrop = False
            Me.DataGridViewRightSection_SelectedClients.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewRightSection_SelectedClients.AllowSelectGroupHeaderRow = True
            Me.DataGridViewRightSection_SelectedClients.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewRightSection_SelectedClients.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewRightSection_SelectedClients.AutoFilterLookupColumns = False
            Me.DataGridViewRightSection_SelectedClients.AutoloadRepositoryDatasource = True
            Me.DataGridViewRightSection_SelectedClients.AutoUpdateViewCaption = True
            Me.DataGridViewRightSection_SelectedClients.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.[Default]
            Me.DataGridViewRightSection_SelectedClients.DataSource = Nothing
            Me.DataGridViewRightSection_SelectedClients.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewRightSection_SelectedClients.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewRightSection_SelectedClients.ItemDescription = ""
            Me.DataGridViewRightSection_SelectedClients.Location = New System.Drawing.Point(87, 6)
            Me.DataGridViewRightSection_SelectedClients.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewRightSection_SelectedClients.MultiSelect = True
            Me.DataGridViewRightSection_SelectedClients.Name = "DataGridViewRightSection_SelectedClients"
            Me.DataGridViewRightSection_SelectedClients.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewRightSection_SelectedClients.RunStandardValidation = True
            Me.DataGridViewRightSection_SelectedClients.ShowColumnMenuOnRightClick = False
            Me.DataGridViewRightSection_SelectedClients.ShowSelectDeselectAllButtons = False
            Me.DataGridViewRightSection_SelectedClients.Size = New System.Drawing.Size(300, 357)
            Me.DataGridViewRightSection_SelectedClients.TabIndex = 3
            Me.DataGridViewRightSection_SelectedClients.UseEmbeddedNavigator = False
            Me.DataGridViewRightSection_SelectedClients.ViewCaptionHeight = -1
            '
            'ExpandableSplitterControlClients_LeftRight
            '
            Me.ExpandableSplitterControlClients_LeftRight.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlClients_LeftRight.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlClients_LeftRight.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControlClients_LeftRight.ExpandableControl = Me.PanelClients_LeftSection
            Me.ExpandableSplitterControlClients_LeftRight.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlClients_LeftRight.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlClients_LeftRight.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlClients_LeftRight.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlClients_LeftRight.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlClients_LeftRight.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlClients_LeftRight.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlClients_LeftRight.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlClients_LeftRight.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterControlClients_LeftRight.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterControlClients_LeftRight.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterControlClients_LeftRight.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterControlClients_LeftRight.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlClients_LeftRight.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlClients_LeftRight.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlClients_LeftRight.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlClients_LeftRight.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlClients_LeftRight.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlClients_LeftRight.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlClients_LeftRight.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlClients_LeftRight.Location = New System.Drawing.Point(203, 1)
            Me.ExpandableSplitterControlClients_LeftRight.Name = "ExpandableSplitterControlClients_LeftRight"
            Me.ExpandableSplitterControlClients_LeftRight.Size = New System.Drawing.Size(6, 369)
            Me.ExpandableSplitterControlClients_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControlClients_LeftRight.TabIndex = 1
            Me.ExpandableSplitterControlClients_LeftRight.TabStop = False
            '
            'PanelClients_LeftSection
            '
            Me.PanelClients_LeftSection.Controls.Add(Me.DataGridViewLeftSection_AvailableClients)
            Me.PanelClients_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelClients_LeftSection.Location = New System.Drawing.Point(1, 1)
            Me.PanelClients_LeftSection.Name = "PanelClients_LeftSection"
            Me.PanelClients_LeftSection.Size = New System.Drawing.Size(202, 369)
            Me.PanelClients_LeftSection.TabIndex = 0
            '
            'DataGridViewLeftSection_AvailableClients
            '
            Me.DataGridViewLeftSection_AvailableClients.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewLeftSection_AvailableClients.AllowDragAndDrop = False
            Me.DataGridViewLeftSection_AvailableClients.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewLeftSection_AvailableClients.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_AvailableClients.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewLeftSection_AvailableClients.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_AvailableClients.AutoFilterLookupColumns = False
            Me.DataGridViewLeftSection_AvailableClients.AutoloadRepositoryDatasource = True
            Me.DataGridViewLeftSection_AvailableClients.AutoUpdateViewCaption = True
            Me.DataGridViewLeftSection_AvailableClients.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.[Default]
            Me.DataGridViewLeftSection_AvailableClients.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewLeftSection_AvailableClients.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_AvailableClients.ItemDescription = ""
            Me.DataGridViewLeftSection_AvailableClients.Location = New System.Drawing.Point(6, 6)
            Me.DataGridViewLeftSection_AvailableClients.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewLeftSection_AvailableClients.MultiSelect = True
            Me.DataGridViewLeftSection_AvailableClients.Name = "DataGridViewLeftSection_AvailableClients"
            Me.DataGridViewLeftSection_AvailableClients.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_AvailableClients.RunStandardValidation = True
            Me.DataGridViewLeftSection_AvailableClients.ShowColumnMenuOnRightClick = False
            Me.DataGridViewLeftSection_AvailableClients.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_AvailableClients.Size = New System.Drawing.Size(190, 357)
            Me.DataGridViewLeftSection_AvailableClients.TabIndex = 0
            Me.DataGridViewLeftSection_AvailableClients.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_AvailableClients.ViewCaptionHeight = -1
            '
            'TabItemVendorRepDetails_Clients
            '
            Me.TabItemVendorRepDetails_Clients.AttachedControl = Me.TabControlPanelClients_Clients
            Me.TabItemVendorRepDetails_Clients.Name = "TabItemVendorRepDetails_Clients"
            Me.TabItemVendorRepDetails_Clients.Text = "Clients"
            '
            'SearchableComboBoxSetup_Vendor
            '
            Me.SearchableComboBoxSetup_Vendor.ActiveFilterString = ""
            Me.SearchableComboBoxSetup_Vendor.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxSetup_Vendor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxSetup_Vendor.AutoFillMode = False
            Me.SearchableComboBoxSetup_Vendor.BookmarkingEnabled = False
            Me.SearchableComboBoxSetup_Vendor.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Vendor
            Me.SearchableComboBoxSetup_Vendor.DataSource = Nothing
            Me.SearchableComboBoxSetup_Vendor.DisableMouseWheel = False
            Me.SearchableComboBoxSetup_Vendor.DisplayName = ""
            Me.SearchableComboBoxSetup_Vendor.EnterMoveNextControl = True
            Me.SearchableComboBoxSetup_Vendor.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxSetup_Vendor.Location = New System.Drawing.Point(96, 6)
            Me.SearchableComboBoxSetup_Vendor.Name = "SearchableComboBoxSetup_Vendor"
            Me.SearchableComboBoxSetup_Vendor.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxSetup_Vendor.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxSetup_Vendor.Properties.NullText = "Select Vendor"
            Me.SearchableComboBoxSetup_Vendor.Properties.ValueMember = "Code"
            Me.SearchableComboBoxSetup_Vendor.Properties.View = Me.GridView1
            Me.SearchableComboBoxSetup_Vendor.SecurityEnabled = True
            Me.SearchableComboBoxSetup_Vendor.SelectedValue = Nothing
            Me.SearchableComboBoxSetup_Vendor.Size = New System.Drawing.Size(501, 20)
            Me.SearchableComboBoxSetup_Vendor.TabIndex = 1
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
            Me.SearchableComboBoxSetup_ContactType.Location = New System.Drawing.Point(96, 84)
            Me.SearchableComboBoxSetup_ContactType.Name = "SearchableComboBoxSetup_ContactType"
            Me.SearchableComboBoxSetup_ContactType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxSetup_ContactType.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxSetup_ContactType.Properties.NullText = "Select Contact Type"
            Me.SearchableComboBoxSetup_ContactType.Properties.ValueMember = "ID"
            Me.SearchableComboBoxSetup_ContactType.Properties.View = Me.GridView2
            Me.SearchableComboBoxSetup_ContactType.SecurityEnabled = True
            Me.SearchableComboBoxSetup_ContactType.SelectedValue = Nothing
            Me.SearchableComboBoxSetup_ContactType.Size = New System.Drawing.Size(501, 20)
            Me.SearchableComboBoxSetup_ContactType.TabIndex = 8
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
            'VendorRepresentativeControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.TabControlControl_VendorRepDetails)
            Me.Name = "VendorRepresentativeControl"
            Me.Size = New System.Drawing.Size(603, 398)
            CType(Me.TabControlControl_VendorRepDetails, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlControl_VendorRepDetails.ResumeLayout(False)
            Me.TabControlPanelSetup_Setup.ResumeLayout(False)
            Me.TableLayoutPanelSetup_TableLayout.ResumeLayout(False)
            Me.PanelTableLayout_RightColumn.ResumeLayout(False)
            Me.PanelTableLayout_LeftColumn.ResumeLayout(False)
            Me.TabControlPanelClients_Clients.ResumeLayout(False)
            CType(Me.PanelClients_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelClients_RightSection.ResumeLayout(False)
            CType(Me.PanelClients_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelClients_LeftSection.ResumeLayout(False)
            CType(Me.SearchableComboBoxSetup_Vendor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxSetup_ContactType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents TabControlControl_VendorRepDetails As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelSetup_Setup As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents LabelSetup_Vendor As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxSetup_Code As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TabItemVendorRepDetails_Setup As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelClients_Clients As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemVendorRepDetails_Clients As DevComponents.DotNetBar.TabItem
        Friend WithEvents LabelSetup_Representative As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxSetup_LastName As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxSetup_MiddleInitial As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelSetup_MiddleInitial As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxSetup_FirstName As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxSetup_FirmName As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents CheckBoxSetup_Inactive As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents AddressControlSetup_Address As AdvantageFramework.WinForm.Presentation.Controls.AddressControl
        Friend WithEvents LabelSetup_LastName As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSetup_FirstName As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSetup_FirmName As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ButtonSetup_Refresh As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonItemRefresh_Vendor As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents TextBoxSetup_FaxExt As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelSetup_FaxExt As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxSetup_PhoneExt As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelSetup_PhoneExt As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxSetup_Email As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelSetup_Email As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxSetup_Cell As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxSetup_Fax As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxSetup_Phone As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelSetup_Cell As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSetup_Fax As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSetup_Phone As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSetup_Contact As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents PanelClients_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents ButtonRightSection_RemoveClient As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonRightSection_AddClient As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents DataGridViewRightSection_SelectedClients As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ExpandableSplitterControlClients_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelClients_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewLeftSection_AvailableClients As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TableLayoutPanelSetup_TableLayout As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents PanelTableLayout_RightColumn As System.Windows.Forms.Panel
        Friend WithEvents PanelTableLayout_LeftColumn As System.Windows.Forms.Panel
        Friend WithEvents LabelSetup_ContactType As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxSetup_Vendor As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView1 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxSetup_ContactType As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView2 As AdvantageFramework.WinForm.Presentation.Controls.GridView

    End Class

End Namespace
