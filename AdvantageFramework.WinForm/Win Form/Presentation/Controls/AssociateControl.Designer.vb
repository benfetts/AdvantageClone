Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class AssociateControl
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AssociateControl))
            Me.CheckBoxForm_ViewAll = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.ComboBoxForm_MediaType = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_MediaType = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Product = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Division = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Client = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DataGridViewForm_VendorEmployeeAssociate = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.DataGridViewForm_AllAssociates = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.PanelControl_Control = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.SearchableComboBoxForm_Client = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView1 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxForm_Division = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView2 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxForm_Product = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView3 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            CType(Me.PanelControl_Control, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelControl_Control.SuspendLayout()
            CType(Me.SearchableComboBoxForm_Client.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxForm_Division.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxForm_Product.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'CheckBoxForm_ViewAll
            '
            Me.CheckBoxForm_ViewAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxForm_ViewAll.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_ViewAll.CheckValue = 0
            Me.CheckBoxForm_ViewAll.CheckValueChecked = 1
            Me.CheckBoxForm_ViewAll.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_ViewAll.CheckValueUnchecked = 0
            Me.CheckBoxForm_ViewAll.ChildControls = CType(resources.GetObject("CheckBoxForm_ViewAll.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_ViewAll.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_ViewAll.Location = New System.Drawing.Point(469, 78)
            Me.CheckBoxForm_ViewAll.Name = "CheckBoxForm_ViewAll"
            Me.CheckBoxForm_ViewAll.OldestSibling = Nothing
            Me.CheckBoxForm_ViewAll.SecurityEnabled = True
            Me.CheckBoxForm_ViewAll.SiblingControls = CType(resources.GetObject("CheckBoxForm_ViewAll.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_ViewAll.Size = New System.Drawing.Size(66, 20)
            Me.CheckBoxForm_ViewAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_ViewAll.TabIndex = 8
            Me.CheckBoxForm_ViewAll.TabOnEnter = True
            Me.CheckBoxForm_ViewAll.Text = "View All"
            '
            'ComboBoxForm_MediaType
            '
            Me.ComboBoxForm_MediaType.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_MediaType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_MediaType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_MediaType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_MediaType.AutoFindItemInDataSource = False
            Me.ComboBoxForm_MediaType.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_MediaType.BookmarkingEnabled = False
            Me.ComboBoxForm_MediaType.ClientCode = ""
            Me.ComboBoxForm_MediaType.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.MediaType
            Me.ComboBoxForm_MediaType.DisableMouseWheel = False
            Me.ComboBoxForm_MediaType.DisplayMember = "Description"
            Me.ComboBoxForm_MediaType.DisplayName = ""
            Me.ComboBoxForm_MediaType.DivisionCode = ""
            Me.ComboBoxForm_MediaType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_MediaType.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_MediaType.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_MediaType.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_MediaType.FocusHighlightEnabled = True
            Me.ComboBoxForm_MediaType.FormattingEnabled = True
            Me.ComboBoxForm_MediaType.ItemHeight = 15
            Me.ComboBoxForm_MediaType.Location = New System.Drawing.Point(74, 78)
            Me.ComboBoxForm_MediaType.Name = "ComboBoxForm_MediaType"
            Me.ComboBoxForm_MediaType.ReadOnly = False
            Me.ComboBoxForm_MediaType.SecurityEnabled = True
            Me.ComboBoxForm_MediaType.Size = New System.Drawing.Size(389, 21)
            Me.ComboBoxForm_MediaType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_MediaType.TabIndex = 7
            Me.ComboBoxForm_MediaType.TabOnEnter = True
            Me.ComboBoxForm_MediaType.ValueMember = "Code"
            Me.ComboBoxForm_MediaType.WatermarkText = "Select Media Type"
            '
            'LabelForm_MediaType
            '
            Me.LabelForm_MediaType.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_MediaType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_MediaType.Location = New System.Drawing.Point(0, 78)
            Me.LabelForm_MediaType.Name = "LabelForm_MediaType"
            Me.LabelForm_MediaType.Size = New System.Drawing.Size(68, 20)
            Me.LabelForm_MediaType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_MediaType.TabIndex = 6
            Me.LabelForm_MediaType.Text = "Media Type:"
            '
            'LabelForm_Product
            '
            Me.LabelForm_Product.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Product.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Product.Location = New System.Drawing.Point(0, 52)
            Me.LabelForm_Product.Name = "LabelForm_Product"
            Me.LabelForm_Product.Size = New System.Drawing.Size(68, 20)
            Me.LabelForm_Product.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Product.TabIndex = 4
            Me.LabelForm_Product.Text = "Product:"
            '
            'LabelForm_Division
            '
            Me.LabelForm_Division.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Division.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Division.Location = New System.Drawing.Point(0, 26)
            Me.LabelForm_Division.Name = "LabelForm_Division"
            Me.LabelForm_Division.Size = New System.Drawing.Size(68, 20)
            Me.LabelForm_Division.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Division.TabIndex = 2
            Me.LabelForm_Division.Text = "Division:"
            '
            'LabelForm_Client
            '
            Me.LabelForm_Client.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Client.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Client.Location = New System.Drawing.Point(0, 0)
            Me.LabelForm_Client.Name = "LabelForm_Client"
            Me.LabelForm_Client.Size = New System.Drawing.Size(68, 20)
            Me.LabelForm_Client.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Client.TabIndex = 0
            Me.LabelForm_Client.Text = "Client:"
            '
            'DataGridViewForm_VendorEmployeeAssociate
            '
            Me.DataGridViewForm_VendorEmployeeAssociate.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewForm_VendorEmployeeAssociate.AllowDragAndDrop = False
            Me.DataGridViewForm_VendorEmployeeAssociate.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_VendorEmployeeAssociate.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_VendorEmployeeAssociate.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_VendorEmployeeAssociate.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_VendorEmployeeAssociate.AutoFilterLookupColumns = False
            Me.DataGridViewForm_VendorEmployeeAssociate.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_VendorEmployeeAssociate.AutoUpdateViewCaption = True
            Me.DataGridViewForm_VendorEmployeeAssociate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewForm_VendorEmployeeAssociate.DataSource = Nothing
            Me.DataGridViewForm_VendorEmployeeAssociate.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_VendorEmployeeAssociate.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_VendorEmployeeAssociate.ItemDescription = ""
            Me.DataGridViewForm_VendorEmployeeAssociate.Location = New System.Drawing.Point(0, 104)
            Me.DataGridViewForm_VendorEmployeeAssociate.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.DataGridViewForm_VendorEmployeeAssociate.MultiSelect = True
            Me.DataGridViewForm_VendorEmployeeAssociate.Name = "DataGridViewForm_VendorEmployeeAssociate"
            Me.DataGridViewForm_VendorEmployeeAssociate.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewForm_VendorEmployeeAssociate.RunStandardValidation = True
            Me.DataGridViewForm_VendorEmployeeAssociate.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_VendorEmployeeAssociate.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_VendorEmployeeAssociate.Size = New System.Drawing.Size(535, 386)
            Me.DataGridViewForm_VendorEmployeeAssociate.TabIndex = 9
            Me.DataGridViewForm_VendorEmployeeAssociate.UseEmbeddedNavigator = False
            Me.DataGridViewForm_VendorEmployeeAssociate.ViewCaptionHeight = -1
            '
            'DataGridViewForm_AllAssociates
            '
            Me.DataGridViewForm_AllAssociates.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewForm_AllAssociates.AllowDragAndDrop = False
            Me.DataGridViewForm_AllAssociates.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_AllAssociates.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_AllAssociates.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_AllAssociates.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_AllAssociates.AutoFilterLookupColumns = False
            Me.DataGridViewForm_AllAssociates.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_AllAssociates.AutoUpdateViewCaption = True
            Me.DataGridViewForm_AllAssociates.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewForm_AllAssociates.DataSource = Nothing
            Me.DataGridViewForm_AllAssociates.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_AllAssociates.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_AllAssociates.ItemDescription = ""
            Me.DataGridViewForm_AllAssociates.Location = New System.Drawing.Point(0, 104)
            Me.DataGridViewForm_AllAssociates.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.DataGridViewForm_AllAssociates.MultiSelect = True
            Me.DataGridViewForm_AllAssociates.Name = "DataGridViewForm_AllAssociates"
            Me.DataGridViewForm_AllAssociates.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_AllAssociates.RunStandardValidation = True
            Me.DataGridViewForm_AllAssociates.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_AllAssociates.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_AllAssociates.Size = New System.Drawing.Size(535, 386)
            Me.DataGridViewForm_AllAssociates.TabIndex = 10
            Me.DataGridViewForm_AllAssociates.UseEmbeddedNavigator = False
            Me.DataGridViewForm_AllAssociates.ViewCaptionHeight = -1
            Me.DataGridViewForm_AllAssociates.Visible = False
            '
            'PanelControl_Control
            '
            Me.PanelControl_Control.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelControl_Control.Controls.Add(Me.SearchableComboBoxForm_Product)
            Me.PanelControl_Control.Controls.Add(Me.SearchableComboBoxForm_Division)
            Me.PanelControl_Control.Controls.Add(Me.SearchableComboBoxForm_Client)
            Me.PanelControl_Control.Controls.Add(Me.CheckBoxForm_ViewAll)
            Me.PanelControl_Control.Controls.Add(Me.LabelForm_Client)
            Me.PanelControl_Control.Controls.Add(Me.ComboBoxForm_MediaType)
            Me.PanelControl_Control.Controls.Add(Me.DataGridViewForm_VendorEmployeeAssociate)
            Me.PanelControl_Control.Controls.Add(Me.LabelForm_Division)
            Me.PanelControl_Control.Controls.Add(Me.LabelForm_MediaType)
            Me.PanelControl_Control.Controls.Add(Me.LabelForm_Product)
            Me.PanelControl_Control.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelControl_Control.Location = New System.Drawing.Point(0, 0)
            Me.PanelControl_Control.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
            Me.PanelControl_Control.Name = "PanelControl_Control"
            Me.PanelControl_Control.Size = New System.Drawing.Size(535, 490)
            Me.PanelControl_Control.TabIndex = 45
            '
            'SearchableComboBoxForm_Client
            '
            Me.SearchableComboBoxForm_Client.ActiveFilterString = ""
            Me.SearchableComboBoxForm_Client.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxForm_Client.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxForm_Client.AutoFillMode = False
            Me.SearchableComboBoxForm_Client.BookmarkingEnabled = False
            Me.SearchableComboBoxForm_Client.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Client
            Me.SearchableComboBoxForm_Client.DataSource = Nothing
            Me.SearchableComboBoxForm_Client.DisableMouseWheel = False
            Me.SearchableComboBoxForm_Client.DisplayName = ""
            Me.SearchableComboBoxForm_Client.EnterMoveNextControl = True
            Me.SearchableComboBoxForm_Client.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxForm_Client.Location = New System.Drawing.Point(74, 0)
            Me.SearchableComboBoxForm_Client.Name = "SearchableComboBoxForm_Client"
            Me.SearchableComboBoxForm_Client.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxForm_Client.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxForm_Client.Properties.NullText = "Select Client"
            Me.SearchableComboBoxForm_Client.Properties.ValueMember = "Code"
            Me.SearchableComboBoxForm_Client.Properties.View = Me.GridView1
            Me.SearchableComboBoxForm_Client.SecurityEnabled = True
            Me.SearchableComboBoxForm_Client.SelectedValue = Nothing
            Me.SearchableComboBoxForm_Client.Size = New System.Drawing.Size(461, 20)
            Me.SearchableComboBoxForm_Client.TabIndex = 1
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
            'SearchableComboBoxForm_Division
            '
            Me.SearchableComboBoxForm_Division.ActiveFilterString = ""
            Me.SearchableComboBoxForm_Division.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxForm_Division.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxForm_Division.AutoFillMode = False
            Me.SearchableComboBoxForm_Division.BookmarkingEnabled = False
            Me.SearchableComboBoxForm_Division.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Division
            Me.SearchableComboBoxForm_Division.DataSource = Nothing
            Me.SearchableComboBoxForm_Division.DisableMouseWheel = False
            Me.SearchableComboBoxForm_Division.DisplayName = ""
            Me.SearchableComboBoxForm_Division.EnterMoveNextControl = True
            Me.SearchableComboBoxForm_Division.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxForm_Division.Location = New System.Drawing.Point(74, 26)
            Me.SearchableComboBoxForm_Division.Name = "SearchableComboBoxForm_Division"
            Me.SearchableComboBoxForm_Division.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxForm_Division.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxForm_Division.Properties.NullText = "Select Division"
            Me.SearchableComboBoxForm_Division.Properties.ValueMember = "Code"
            Me.SearchableComboBoxForm_Division.Properties.View = Me.GridView2
            Me.SearchableComboBoxForm_Division.SecurityEnabled = True
            Me.SearchableComboBoxForm_Division.SelectedValue = Nothing
            Me.SearchableComboBoxForm_Division.Size = New System.Drawing.Size(461, 20)
            Me.SearchableComboBoxForm_Division.TabIndex = 3
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
            'SearchableComboBoxForm_Product
            '
            Me.SearchableComboBoxForm_Product.ActiveFilterString = ""
            Me.SearchableComboBoxForm_Product.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxForm_Product.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxForm_Product.AutoFillMode = False
            Me.SearchableComboBoxForm_Product.BookmarkingEnabled = False
            Me.SearchableComboBoxForm_Product.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Product
            Me.SearchableComboBoxForm_Product.DataSource = Nothing
            Me.SearchableComboBoxForm_Product.DisableMouseWheel = False
            Me.SearchableComboBoxForm_Product.DisplayName = ""
            Me.SearchableComboBoxForm_Product.EnterMoveNextControl = True
            Me.SearchableComboBoxForm_Product.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxForm_Product.Location = New System.Drawing.Point(74, 52)
            Me.SearchableComboBoxForm_Product.Name = "SearchableComboBoxForm_Product"
            Me.SearchableComboBoxForm_Product.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxForm_Product.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxForm_Product.Properties.NullText = "Select Product"
            Me.SearchableComboBoxForm_Product.Properties.ValueMember = "Code"
            Me.SearchableComboBoxForm_Product.Properties.View = Me.GridView3
            Me.SearchableComboBoxForm_Product.SecurityEnabled = True
            Me.SearchableComboBoxForm_Product.SelectedValue = Nothing
            Me.SearchableComboBoxForm_Product.Size = New System.Drawing.Size(461, 20)
            Me.SearchableComboBoxForm_Product.TabIndex = 5
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
            '
            'AssociateControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.DataGridViewForm_AllAssociates)
            Me.Controls.Add(Me.PanelControl_Control)
            Me.Name = "AssociateControl"
            Me.Size = New System.Drawing.Size(535, 490)
            CType(Me.PanelControl_Control, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelControl_Control.ResumeLayout(False)
            CType(Me.SearchableComboBoxForm_Client.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxForm_Division.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxForm_Product.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents LabelForm_Product As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Division As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Client As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents DataGridViewForm_VendorEmployeeAssociate As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents LabelForm_MediaType As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_MediaType As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents CheckBoxForm_ViewAll As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents DataGridViewForm_AllAssociates As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents PanelControl_Control As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents SearchableComboBoxForm_Client As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView1 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxForm_Division As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView2 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxForm_Product As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView3 As AdvantageFramework.WinForm.Presentation.Controls.GridView

    End Class

End Namespace
