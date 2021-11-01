Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class StandardCommentControl
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StandardCommentControl))
            Me.GroupBoxRightSection_Settings = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.SearchableComboBoxSettings_MediaType = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView6 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelSettings_MediaType = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxSettings_Vendor = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView5 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxSettings_Products = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView4 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxSettings_Divisions = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView3 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxSettings_Clients = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView1 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxSettings_Office = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView2 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelSettings_Vendor = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSettings_Office = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSettings_Product = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSettings_Division = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSettings_Client = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxRightSection_FontSize = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ComboBoxRightSection_Type = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelRightSection_Application = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxRightSection_Application = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelRightSection_Type = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxRightSection_Comment = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelRightSection_FontSize = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelRightSection_Comment = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.PanelControl_Control = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.RichEditControl_Comment = New AdvantageFramework.WinForm.Presentation.Controls.RichEditControl()
            CType(Me.GroupBoxRightSection_Settings, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxRightSection_Settings.SuspendLayout()
            CType(Me.SearchableComboBoxSettings_MediaType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView6, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxSettings_Vendor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView5, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxSettings_Products.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxSettings_Divisions.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxSettings_Clients.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxSettings_Office.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PanelControl_Control, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelControl_Control.SuspendLayout()
            Me.SuspendLayout()
            '
            'GroupBoxRightSection_Settings
            '
            Me.GroupBoxRightSection_Settings.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxRightSection_Settings.Controls.Add(Me.SearchableComboBoxSettings_MediaType)
            Me.GroupBoxRightSection_Settings.Controls.Add(Me.LabelSettings_MediaType)
            Me.GroupBoxRightSection_Settings.Controls.Add(Me.SearchableComboBoxSettings_Vendor)
            Me.GroupBoxRightSection_Settings.Controls.Add(Me.SearchableComboBoxSettings_Products)
            Me.GroupBoxRightSection_Settings.Controls.Add(Me.SearchableComboBoxSettings_Divisions)
            Me.GroupBoxRightSection_Settings.Controls.Add(Me.SearchableComboBoxSettings_Clients)
            Me.GroupBoxRightSection_Settings.Controls.Add(Me.SearchableComboBoxSettings_Office)
            Me.GroupBoxRightSection_Settings.Controls.Add(Me.LabelSettings_Vendor)
            Me.GroupBoxRightSection_Settings.Controls.Add(Me.LabelSettings_Office)
            Me.GroupBoxRightSection_Settings.Controls.Add(Me.LabelSettings_Product)
            Me.GroupBoxRightSection_Settings.Controls.Add(Me.LabelSettings_Division)
            Me.GroupBoxRightSection_Settings.Controls.Add(Me.LabelSettings_Client)
            Me.GroupBoxRightSection_Settings.Location = New System.Drawing.Point(0, 76)
            Me.GroupBoxRightSection_Settings.Name = "GroupBoxRightSection_Settings"
            Me.GroupBoxRightSection_Settings.Size = New System.Drawing.Size(319, 182)
            Me.GroupBoxRightSection_Settings.TabIndex = 6
            Me.GroupBoxRightSection_Settings.Text = "Settings"
            '
            'SearchableComboBoxSettings_MediaType
            '
            Me.SearchableComboBoxSettings_MediaType.ActiveFilterString = ""
            Me.SearchableComboBoxSettings_MediaType.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxSettings_MediaType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxSettings_MediaType.AutoFillMode = False
            Me.SearchableComboBoxSettings_MediaType.BookmarkingEnabled = False
            Me.SearchableComboBoxSettings_MediaType.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.EnumObjects
            Me.SearchableComboBoxSettings_MediaType.DataSource = Nothing
            Me.SearchableComboBoxSettings_MediaType.DisableMouseWheel = False
            Me.SearchableComboBoxSettings_MediaType.DisplayName = ""
            Me.SearchableComboBoxSettings_MediaType.EnterMoveNextControl = True
            Me.SearchableComboBoxSettings_MediaType.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxSettings_MediaType.Location = New System.Drawing.Point(74, 151)
            Me.SearchableComboBoxSettings_MediaType.Name = "SearchableComboBoxSettings_MediaType"
            Me.SearchableComboBoxSettings_MediaType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxSettings_MediaType.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxSettings_MediaType.Properties.NullText = "Select"
            Me.SearchableComboBoxSettings_MediaType.Properties.PopupView = Me.GridView6
            Me.SearchableComboBoxSettings_MediaType.Properties.ValueMember = "Code"
            Me.SearchableComboBoxSettings_MediaType.SecurityEnabled = True
            Me.SearchableComboBoxSettings_MediaType.SelectedValue = Nothing
            Me.SearchableComboBoxSettings_MediaType.Size = New System.Drawing.Size(240, 20)
            Me.SearchableComboBoxSettings_MediaType.TabIndex = 11
            '
            'GridView6
            '
            Me.GridView6.AFActiveFilterString = ""
            Me.GridView6.AllowExtraItemsInGridLookupEdits = True
            Me.GridView6.AutoFilterLookupColumns = False
            Me.GridView6.AutoloadRepositoryDatasource = True
            Me.GridView6.DataSourceClearing = False
            Me.GridView6.EnableDisabledRows = False
            Me.GridView6.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView6.Name = "GridView6"
            Me.GridView6.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView6.OptionsView.ShowGroupPanel = False
            Me.GridView6.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView6.RunStandardValidation = True
            Me.GridView6.SkipAddingControlsOnModifyColumn = False
            Me.GridView6.SkipSettingFontOnModifyColumn = False
            '
            'LabelSettings_MediaType
            '
            Me.LabelSettings_MediaType.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSettings_MediaType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSettings_MediaType.Location = New System.Drawing.Point(6, 151)
            Me.LabelSettings_MediaType.Name = "LabelSettings_MediaType"
            Me.LabelSettings_MediaType.Size = New System.Drawing.Size(62, 20)
            Me.LabelSettings_MediaType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSettings_MediaType.TabIndex = 10
            Me.LabelSettings_MediaType.Text = "Media Type:"
            '
            'SearchableComboBoxSettings_Vendor
            '
            Me.SearchableComboBoxSettings_Vendor.ActiveFilterString = ""
            Me.SearchableComboBoxSettings_Vendor.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxSettings_Vendor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxSettings_Vendor.AutoFillMode = False
            Me.SearchableComboBoxSettings_Vendor.BookmarkingEnabled = False
            Me.SearchableComboBoxSettings_Vendor.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Vendor
            Me.SearchableComboBoxSettings_Vendor.DataSource = Nothing
            Me.SearchableComboBoxSettings_Vendor.DisableMouseWheel = False
            Me.SearchableComboBoxSettings_Vendor.DisplayName = ""
            Me.SearchableComboBoxSettings_Vendor.EnterMoveNextControl = True
            Me.SearchableComboBoxSettings_Vendor.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxSettings_Vendor.Location = New System.Drawing.Point(74, 125)
            Me.SearchableComboBoxSettings_Vendor.Name = "SearchableComboBoxSettings_Vendor"
            Me.SearchableComboBoxSettings_Vendor.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxSettings_Vendor.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxSettings_Vendor.Properties.NullText = "Select Vendor"
            Me.SearchableComboBoxSettings_Vendor.Properties.PopupView = Me.GridView5
            Me.SearchableComboBoxSettings_Vendor.Properties.ValueMember = "Code"
            Me.SearchableComboBoxSettings_Vendor.SecurityEnabled = True
            Me.SearchableComboBoxSettings_Vendor.SelectedValue = Nothing
            Me.SearchableComboBoxSettings_Vendor.Size = New System.Drawing.Size(240, 20)
            Me.SearchableComboBoxSettings_Vendor.TabIndex = 9
            '
            'GridView5
            '
            Me.GridView5.AFActiveFilterString = ""
            Me.GridView5.AllowExtraItemsInGridLookupEdits = True
            Me.GridView5.AutoFilterLookupColumns = False
            Me.GridView5.AutoloadRepositoryDatasource = True
            Me.GridView5.DataSourceClearing = False
            Me.GridView5.EnableDisabledRows = False
            Me.GridView5.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView5.Name = "GridView5"
            Me.GridView5.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView5.OptionsView.ShowGroupPanel = False
            Me.GridView5.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView5.RunStandardValidation = True
            Me.GridView5.SkipAddingControlsOnModifyColumn = False
            Me.GridView5.SkipSettingFontOnModifyColumn = False
            '
            'SearchableComboBoxSettings_Products
            '
            Me.SearchableComboBoxSettings_Products.ActiveFilterString = ""
            Me.SearchableComboBoxSettings_Products.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxSettings_Products.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxSettings_Products.AutoFillMode = False
            Me.SearchableComboBoxSettings_Products.BookmarkingEnabled = False
            Me.SearchableComboBoxSettings_Products.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Product
            Me.SearchableComboBoxSettings_Products.DataSource = Nothing
            Me.SearchableComboBoxSettings_Products.DisableMouseWheel = False
            Me.SearchableComboBoxSettings_Products.DisplayName = ""
            Me.SearchableComboBoxSettings_Products.EnterMoveNextControl = True
            Me.SearchableComboBoxSettings_Products.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxSettings_Products.Location = New System.Drawing.Point(74, 100)
            Me.SearchableComboBoxSettings_Products.Name = "SearchableComboBoxSettings_Products"
            Me.SearchableComboBoxSettings_Products.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxSettings_Products.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxSettings_Products.Properties.NullText = "Select Product"
            Me.SearchableComboBoxSettings_Products.Properties.PopupView = Me.GridView4
            Me.SearchableComboBoxSettings_Products.Properties.ValueMember = "Code"
            Me.SearchableComboBoxSettings_Products.SecurityEnabled = True
            Me.SearchableComboBoxSettings_Products.SelectedValue = Nothing
            Me.SearchableComboBoxSettings_Products.Size = New System.Drawing.Size(240, 20)
            Me.SearchableComboBoxSettings_Products.TabIndex = 7
            '
            'GridView4
            '
            Me.GridView4.AFActiveFilterString = ""
            Me.GridView4.AllowExtraItemsInGridLookupEdits = True
            Me.GridView4.AutoFilterLookupColumns = False
            Me.GridView4.AutoloadRepositoryDatasource = True
            Me.GridView4.DataSourceClearing = False
            Me.GridView4.EnableDisabledRows = False
            Me.GridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView4.Name = "GridView4"
            Me.GridView4.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView4.OptionsView.ShowGroupPanel = False
            Me.GridView4.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView4.RunStandardValidation = True
            Me.GridView4.SkipAddingControlsOnModifyColumn = False
            Me.GridView4.SkipSettingFontOnModifyColumn = False
            '
            'SearchableComboBoxSettings_Divisions
            '
            Me.SearchableComboBoxSettings_Divisions.ActiveFilterString = ""
            Me.SearchableComboBoxSettings_Divisions.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxSettings_Divisions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxSettings_Divisions.AutoFillMode = False
            Me.SearchableComboBoxSettings_Divisions.BookmarkingEnabled = False
            Me.SearchableComboBoxSettings_Divisions.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Division
            Me.SearchableComboBoxSettings_Divisions.DataSource = Nothing
            Me.SearchableComboBoxSettings_Divisions.DisableMouseWheel = False
            Me.SearchableComboBoxSettings_Divisions.DisplayName = ""
            Me.SearchableComboBoxSettings_Divisions.EnterMoveNextControl = True
            Me.SearchableComboBoxSettings_Divisions.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxSettings_Divisions.Location = New System.Drawing.Point(74, 75)
            Me.SearchableComboBoxSettings_Divisions.Name = "SearchableComboBoxSettings_Divisions"
            Me.SearchableComboBoxSettings_Divisions.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxSettings_Divisions.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxSettings_Divisions.Properties.NullText = "Select Division"
            Me.SearchableComboBoxSettings_Divisions.Properties.PopupView = Me.GridView3
            Me.SearchableComboBoxSettings_Divisions.Properties.ValueMember = "Code"
            Me.SearchableComboBoxSettings_Divisions.SecurityEnabled = True
            Me.SearchableComboBoxSettings_Divisions.SelectedValue = Nothing
            Me.SearchableComboBoxSettings_Divisions.Size = New System.Drawing.Size(240, 20)
            Me.SearchableComboBoxSettings_Divisions.TabIndex = 5
            '
            'GridView3
            '
            Me.GridView3.AFActiveFilterString = ""
            Me.GridView3.AllowExtraItemsInGridLookupEdits = True
            Me.GridView3.AutoFilterLookupColumns = False
            Me.GridView3.AutoloadRepositoryDatasource = True
            Me.GridView3.DataSourceClearing = False
            Me.GridView3.EnableDisabledRows = False
            Me.GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView3.Name = "GridView3"
            Me.GridView3.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView3.OptionsView.ShowGroupPanel = False
            Me.GridView3.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView3.RunStandardValidation = True
            Me.GridView3.SkipAddingControlsOnModifyColumn = False
            Me.GridView3.SkipSettingFontOnModifyColumn = False
            '
            'SearchableComboBoxSettings_Clients
            '
            Me.SearchableComboBoxSettings_Clients.ActiveFilterString = ""
            Me.SearchableComboBoxSettings_Clients.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxSettings_Clients.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxSettings_Clients.AutoFillMode = False
            Me.SearchableComboBoxSettings_Clients.BookmarkingEnabled = False
            Me.SearchableComboBoxSettings_Clients.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Client
            Me.SearchableComboBoxSettings_Clients.DataSource = Nothing
            Me.SearchableComboBoxSettings_Clients.DisableMouseWheel = False
            Me.SearchableComboBoxSettings_Clients.DisplayName = ""
            Me.SearchableComboBoxSettings_Clients.EnterMoveNextControl = True
            Me.SearchableComboBoxSettings_Clients.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxSettings_Clients.Location = New System.Drawing.Point(74, 50)
            Me.SearchableComboBoxSettings_Clients.Name = "SearchableComboBoxSettings_Clients"
            Me.SearchableComboBoxSettings_Clients.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxSettings_Clients.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxSettings_Clients.Properties.NullText = "Select Client"
            Me.SearchableComboBoxSettings_Clients.Properties.PopupView = Me.GridView1
            Me.SearchableComboBoxSettings_Clients.Properties.ValueMember = "Code"
            Me.SearchableComboBoxSettings_Clients.SecurityEnabled = True
            Me.SearchableComboBoxSettings_Clients.SelectedValue = Nothing
            Me.SearchableComboBoxSettings_Clients.Size = New System.Drawing.Size(240, 20)
            Me.SearchableComboBoxSettings_Clients.TabIndex = 3
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
            Me.GridView1.SkipAddingControlsOnModifyColumn = False
            Me.GridView1.SkipSettingFontOnModifyColumn = False
            '
            'SearchableComboBoxSettings_Office
            '
            Me.SearchableComboBoxSettings_Office.ActiveFilterString = ""
            Me.SearchableComboBoxSettings_Office.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxSettings_Office.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxSettings_Office.AutoFillMode = False
            Me.SearchableComboBoxSettings_Office.BookmarkingEnabled = False
            Me.SearchableComboBoxSettings_Office.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Office
            Me.SearchableComboBoxSettings_Office.DataSource = Nothing
            Me.SearchableComboBoxSettings_Office.DisableMouseWheel = False
            Me.SearchableComboBoxSettings_Office.DisplayName = ""
            Me.SearchableComboBoxSettings_Office.EnterMoveNextControl = True
            Me.SearchableComboBoxSettings_Office.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxSettings_Office.Location = New System.Drawing.Point(74, 25)
            Me.SearchableComboBoxSettings_Office.Name = "SearchableComboBoxSettings_Office"
            Me.SearchableComboBoxSettings_Office.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxSettings_Office.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxSettings_Office.Properties.NullText = "Select Office"
            Me.SearchableComboBoxSettings_Office.Properties.PopupView = Me.GridView2
            Me.SearchableComboBoxSettings_Office.Properties.ValueMember = "Code"
            Me.SearchableComboBoxSettings_Office.SecurityEnabled = True
            Me.SearchableComboBoxSettings_Office.SelectedValue = Nothing
            Me.SearchableComboBoxSettings_Office.Size = New System.Drawing.Size(240, 20)
            Me.SearchableComboBoxSettings_Office.TabIndex = 1
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
            Me.GridView2.SkipAddingControlsOnModifyColumn = False
            Me.GridView2.SkipSettingFontOnModifyColumn = False
            '
            'LabelSettings_Vendor
            '
            Me.LabelSettings_Vendor.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSettings_Vendor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSettings_Vendor.Location = New System.Drawing.Point(6, 125)
            Me.LabelSettings_Vendor.Name = "LabelSettings_Vendor"
            Me.LabelSettings_Vendor.Size = New System.Drawing.Size(62, 20)
            Me.LabelSettings_Vendor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSettings_Vendor.TabIndex = 8
            Me.LabelSettings_Vendor.Text = "Vendor:"
            '
            'LabelSettings_Office
            '
            Me.LabelSettings_Office.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSettings_Office.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSettings_Office.Location = New System.Drawing.Point(6, 25)
            Me.LabelSettings_Office.Name = "LabelSettings_Office"
            Me.LabelSettings_Office.Size = New System.Drawing.Size(62, 20)
            Me.LabelSettings_Office.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSettings_Office.TabIndex = 0
            Me.LabelSettings_Office.Text = "Office:"
            '
            'LabelSettings_Product
            '
            Me.LabelSettings_Product.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSettings_Product.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSettings_Product.Location = New System.Drawing.Point(6, 100)
            Me.LabelSettings_Product.Name = "LabelSettings_Product"
            Me.LabelSettings_Product.Size = New System.Drawing.Size(62, 20)
            Me.LabelSettings_Product.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSettings_Product.TabIndex = 6
            Me.LabelSettings_Product.Text = "Product:"
            '
            'LabelSettings_Division
            '
            Me.LabelSettings_Division.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSettings_Division.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSettings_Division.Location = New System.Drawing.Point(6, 75)
            Me.LabelSettings_Division.Name = "LabelSettings_Division"
            Me.LabelSettings_Division.Size = New System.Drawing.Size(62, 20)
            Me.LabelSettings_Division.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSettings_Division.TabIndex = 4
            Me.LabelSettings_Division.Text = "Division:"
            '
            'LabelSettings_Client
            '
            Me.LabelSettings_Client.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSettings_Client.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSettings_Client.Location = New System.Drawing.Point(6, 50)
            Me.LabelSettings_Client.Name = "LabelSettings_Client"
            Me.LabelSettings_Client.Size = New System.Drawing.Size(62, 20)
            Me.LabelSettings_Client.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSettings_Client.TabIndex = 2
            Me.LabelSettings_Client.Text = "Client:"
            '
            'ComboBoxRightSection_FontSize
            '
            Me.ComboBoxRightSection_FontSize.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxRightSection_FontSize.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxRightSection_FontSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxRightSection_FontSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxRightSection_FontSize.AutoFindItemInDataSource = False
            Me.ComboBoxRightSection_FontSize.AutoSelectSingleItemDatasource = False
            Me.ComboBoxRightSection_FontSize.BookmarkingEnabled = False
            Me.ComboBoxRightSection_FontSize.ClientCode = ""
            Me.ComboBoxRightSection_FontSize.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.FontSize
            Me.ComboBoxRightSection_FontSize.DisableMouseWheel = False
            Me.ComboBoxRightSection_FontSize.DisplayMember = "FontSize"
            Me.ComboBoxRightSection_FontSize.DisplayName = ""
            Me.ComboBoxRightSection_FontSize.DivisionCode = ""
            Me.ComboBoxRightSection_FontSize.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxRightSection_FontSize.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxRightSection_FontSize.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxRightSection_FontSize.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxRightSection_FontSize.FocusHighlightEnabled = True
            Me.ComboBoxRightSection_FontSize.FormattingEnabled = True
            Me.ComboBoxRightSection_FontSize.ItemHeight = 16
            Me.ComboBoxRightSection_FontSize.Location = New System.Drawing.Point(71, 50)
            Me.ComboBoxRightSection_FontSize.Name = "ComboBoxRightSection_FontSize"
            Me.ComboBoxRightSection_FontSize.ReadOnly = False
            Me.ComboBoxRightSection_FontSize.SecurityEnabled = True
            Me.ComboBoxRightSection_FontSize.Size = New System.Drawing.Size(248, 22)
            Me.ComboBoxRightSection_FontSize.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxRightSection_FontSize.TabIndex = 5
            Me.ComboBoxRightSection_FontSize.TabOnEnter = True
            Me.ComboBoxRightSection_FontSize.ValueMember = "FontSize"
            Me.ComboBoxRightSection_FontSize.WatermarkText = "Select Font Size"
            '
            'ComboBoxRightSection_Type
            '
            Me.ComboBoxRightSection_Type.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxRightSection_Type.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxRightSection_Type.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxRightSection_Type.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxRightSection_Type.AutoFindItemInDataSource = False
            Me.ComboBoxRightSection_Type.AutoSelectSingleItemDatasource = False
            Me.ComboBoxRightSection_Type.BookmarkingEnabled = False
            Me.ComboBoxRightSection_Type.ClientCode = ""
            Me.ComboBoxRightSection_Type.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.StandardCommentType
            Me.ComboBoxRightSection_Type.DisableMouseWheel = False
            Me.ComboBoxRightSection_Type.DisplayMember = "Description"
            Me.ComboBoxRightSection_Type.DisplayName = ""
            Me.ComboBoxRightSection_Type.DivisionCode = ""
            Me.ComboBoxRightSection_Type.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxRightSection_Type.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxRightSection_Type.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxRightSection_Type.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxRightSection_Type.FocusHighlightEnabled = True
            Me.ComboBoxRightSection_Type.FormattingEnabled = True
            Me.ComboBoxRightSection_Type.ItemHeight = 16
            Me.ComboBoxRightSection_Type.Location = New System.Drawing.Point(71, 25)
            Me.ComboBoxRightSection_Type.Name = "ComboBoxRightSection_Type"
            Me.ComboBoxRightSection_Type.ReadOnly = False
            Me.ComboBoxRightSection_Type.SecurityEnabled = True
            Me.ComboBoxRightSection_Type.Size = New System.Drawing.Size(248, 22)
            Me.ComboBoxRightSection_Type.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxRightSection_Type.TabIndex = 3
            Me.ComboBoxRightSection_Type.TabOnEnter = True
            Me.ComboBoxRightSection_Type.ValueMember = "Code"
            Me.ComboBoxRightSection_Type.WatermarkText = "Select Type"
            '
            'LabelRightSection_Application
            '
            Me.LabelRightSection_Application.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRightSection_Application.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRightSection_Application.Location = New System.Drawing.Point(0, 0)
            Me.LabelRightSection_Application.Name = "LabelRightSection_Application"
            Me.LabelRightSection_Application.Size = New System.Drawing.Size(65, 20)
            Me.LabelRightSection_Application.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRightSection_Application.TabIndex = 0
            Me.LabelRightSection_Application.Text = "Application:"
            '
            'ComboBoxRightSection_Application
            '
            Me.ComboBoxRightSection_Application.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxRightSection_Application.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxRightSection_Application.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxRightSection_Application.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxRightSection_Application.AutoFindItemInDataSource = False
            Me.ComboBoxRightSection_Application.AutoSelectSingleItemDatasource = False
            Me.ComboBoxRightSection_Application.BookmarkingEnabled = False
            Me.ComboBoxRightSection_Application.ClientCode = ""
            Me.ComboBoxRightSection_Application.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.StandardCommentApplication
            Me.ComboBoxRightSection_Application.DisableMouseWheel = True
            Me.ComboBoxRightSection_Application.DisplayMember = "Description"
            Me.ComboBoxRightSection_Application.DisplayName = ""
            Me.ComboBoxRightSection_Application.DivisionCode = ""
            Me.ComboBoxRightSection_Application.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxRightSection_Application.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxRightSection_Application.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxRightSection_Application.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxRightSection_Application.FocusHighlightEnabled = True
            Me.ComboBoxRightSection_Application.FormattingEnabled = True
            Me.ComboBoxRightSection_Application.ItemHeight = 16
            Me.ComboBoxRightSection_Application.Location = New System.Drawing.Point(71, 0)
            Me.ComboBoxRightSection_Application.Name = "ComboBoxRightSection_Application"
            Me.ComboBoxRightSection_Application.ReadOnly = False
            Me.ComboBoxRightSection_Application.SecurityEnabled = True
            Me.ComboBoxRightSection_Application.Size = New System.Drawing.Size(248, 22)
            Me.ComboBoxRightSection_Application.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxRightSection_Application.TabIndex = 1
            Me.ComboBoxRightSection_Application.TabOnEnter = True
            Me.ComboBoxRightSection_Application.ValueMember = "Code"
            Me.ComboBoxRightSection_Application.WatermarkText = "Select Application"
            '
            'LabelRightSection_Type
            '
            Me.LabelRightSection_Type.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRightSection_Type.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRightSection_Type.Location = New System.Drawing.Point(0, 25)
            Me.LabelRightSection_Type.Name = "LabelRightSection_Type"
            Me.LabelRightSection_Type.Size = New System.Drawing.Size(65, 20)
            Me.LabelRightSection_Type.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRightSection_Type.TabIndex = 2
            Me.LabelRightSection_Type.Text = "Type:"
            '
            'TextBoxRightSection_Comment
            '
            Me.TextBoxRightSection_Comment.AcceptsReturn = True
            Me.TextBoxRightSection_Comment.AcceptsTab = True
            Me.TextBoxRightSection_Comment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxRightSection_Comment.Border.Class = "TextBoxBorder"
            Me.TextBoxRightSection_Comment.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxRightSection_Comment.CheckSpellingOnValidate = False
            Me.TextBoxRightSection_Comment.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxRightSection_Comment.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxRightSection_Comment.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxRightSection_Comment.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxRightSection_Comment.FocusHighlightEnabled = True
            Me.TextBoxRightSection_Comment.Location = New System.Drawing.Point(71, 264)
            Me.TextBoxRightSection_Comment.MaxFileSize = CType(0, Long)
            Me.TextBoxRightSection_Comment.Multiline = True
            Me.TextBoxRightSection_Comment.Name = "TextBoxRightSection_Comment"
            Me.TextBoxRightSection_Comment.ScrollBars = System.Windows.Forms.ScrollBars.Both
            Me.TextBoxRightSection_Comment.SecurityEnabled = True
            Me.TextBoxRightSection_Comment.ShowSpellCheckCompleteMessage = True
            Me.TextBoxRightSection_Comment.Size = New System.Drawing.Size(248, 57)
            Me.TextBoxRightSection_Comment.StartingFolderName = Nothing
            Me.TextBoxRightSection_Comment.TabIndex = 8
            Me.TextBoxRightSection_Comment.TabOnEnter = False
            '
            'LabelRightSection_FontSize
            '
            Me.LabelRightSection_FontSize.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRightSection_FontSize.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRightSection_FontSize.Location = New System.Drawing.Point(0, 50)
            Me.LabelRightSection_FontSize.Name = "LabelRightSection_FontSize"
            Me.LabelRightSection_FontSize.Size = New System.Drawing.Size(65, 20)
            Me.LabelRightSection_FontSize.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRightSection_FontSize.TabIndex = 4
            Me.LabelRightSection_FontSize.Text = "Font Size:"
            '
            'LabelRightSection_Comment
            '
            Me.LabelRightSection_Comment.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelRightSection_Comment.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelRightSection_Comment.Location = New System.Drawing.Point(3, 262)
            Me.LabelRightSection_Comment.Name = "LabelRightSection_Comment"
            Me.LabelRightSection_Comment.Size = New System.Drawing.Size(65, 20)
            Me.LabelRightSection_Comment.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelRightSection_Comment.TabIndex = 7
            Me.LabelRightSection_Comment.Text = "Comment:"
            '
            'PanelControl_Control
            '
            Me.PanelControl_Control.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelControl_Control.Controls.Add(Me.GroupBoxRightSection_Settings)
            Me.PanelControl_Control.Controls.Add(Me.LabelRightSection_Application)
            Me.PanelControl_Control.Controls.Add(Me.ComboBoxRightSection_FontSize)
            Me.PanelControl_Control.Controls.Add(Me.LabelRightSection_Comment)
            Me.PanelControl_Control.Controls.Add(Me.ComboBoxRightSection_Type)
            Me.PanelControl_Control.Controls.Add(Me.LabelRightSection_FontSize)
            Me.PanelControl_Control.Controls.Add(Me.TextBoxRightSection_Comment)
            Me.PanelControl_Control.Controls.Add(Me.LabelRightSection_Type)
            Me.PanelControl_Control.Controls.Add(Me.ComboBoxRightSection_Application)
            Me.PanelControl_Control.Controls.Add(Me.RichEditControl_Comment)
            Me.PanelControl_Control.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelControl_Control.Location = New System.Drawing.Point(0, 0)
            Me.PanelControl_Control.Margin = New System.Windows.Forms.Padding(2)
            Me.PanelControl_Control.Name = "PanelControl_Control"
            Me.PanelControl_Control.Size = New System.Drawing.Size(319, 321)
            Me.PanelControl_Control.TabIndex = 45
            '
            'RichEditControl_Comment
            '
            Me.RichEditControl_Comment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RichEditControl_Comment.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.RichEditControl_Comment.HtmlText = resources.GetString("RichEditControl_Comment.HtmlText")
            Me.RichEditControl_Comment.Location = New System.Drawing.Point(71, 262)
            Me.RichEditControl_Comment.Margin = New System.Windows.Forms.Padding(4)
            Me.RichEditControl_Comment.MhtText = resources.GetString("RichEditControl_Comment.MhtText")
            Me.RichEditControl_Comment.Name = "RichEditControl_Comment"
            Me.RichEditControl_Comment.ReadOnly = False
            Me.RichEditControl_Comment.RtfText = resources.GetString("RichEditControl_Comment.RtfText")
            Me.RichEditControl_Comment.SecurityEnabled = True
            Me.RichEditControl_Comment.ShowEditButtons = True
            Me.RichEditControl_Comment.Size = New System.Drawing.Size(247, 59)
            Me.RichEditControl_Comment.TabIndex = 9
            Me.RichEditControl_Comment.Visible = False
            Me.RichEditControl_Comment.WordMLText = resources.GetString("RichEditControl_Comment.WordMLText")
            '
            'StandardCommentControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.PanelControl_Control)
            Me.Name = "StandardCommentControl"
            Me.Size = New System.Drawing.Size(319, 321)
            CType(Me.GroupBoxRightSection_Settings, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxRightSection_Settings.ResumeLayout(False)
            CType(Me.SearchableComboBoxSettings_MediaType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView6, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxSettings_Vendor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView5, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxSettings_Products.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxSettings_Divisions.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxSettings_Clients.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxSettings_Office.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PanelControl_Control, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelControl_Control.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ComboBoxRightSection_FontSize As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxRightSection_Type As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelRightSection_Application As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxRightSection_Application As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelRightSection_Type As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxRightSection_Comment As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelRightSection_FontSize As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelRightSection_Comment As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxRightSection_Settings As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents LabelSettings_Vendor As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSettings_Office As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSettings_Product As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSettings_Division As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSettings_Client As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents PanelControl_Control As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents SearchableComboBoxSettings_Office As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView2 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxSettings_Clients As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView1 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxSettings_Divisions As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView3 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxSettings_Vendor As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView5 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxSettings_Products As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView4 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents RichEditControl_Comment As RichEditControl
        Friend WithEvents SearchableComboBoxSettings_MediaType As SearchableComboBox
        Friend WithEvents GridView6 As GridView
        Friend WithEvents LabelSettings_MediaType As Label
    End Class

End Namespace
