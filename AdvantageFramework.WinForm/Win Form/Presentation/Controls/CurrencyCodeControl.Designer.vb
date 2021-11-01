Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class CurrencyCodeControl
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CurrencyCodeControl))
            Me.LabelControl_ForeignCurrency = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxControl_Inactive = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelControl_APForeignCurrencyExchangeAccount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelControl_DefaultAPAccount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxControl_APForeignCurrencyExchangeAccount = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.DataGridViewControl_CurrencyDetails = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.PanelControl_Control = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.SearchableComboBoxControl_HomeCurrency = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView3 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelControl_HomeCurrency = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxControl_APForeignCurrencyExchangeAccount = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView2 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxControl_DefaultAPAccount = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView1 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxControl_Currency = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView4 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            CType(Me.PanelControl_Control, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelControl_Control.SuspendLayout()
            CType(Me.SearchableComboBoxControl_HomeCurrency.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxControl_APForeignCurrencyExchangeAccount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxControl_DefaultAPAccount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxControl_Currency.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'LabelControl_ForeignCurrency
            '
            Me.LabelControl_ForeignCurrency.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_ForeignCurrency.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_ForeignCurrency.Location = New System.Drawing.Point(0, 26)
            Me.LabelControl_ForeignCurrency.Name = "LabelControl_ForeignCurrency"
            Me.LabelControl_ForeignCurrency.Size = New System.Drawing.Size(125, 20)
            Me.LabelControl_ForeignCurrency.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_ForeignCurrency.TabIndex = 2
            Me.LabelControl_ForeignCurrency.Text = "Foreign Currency:"
            '
            'CheckBoxControl_Inactive
            '
            Me.CheckBoxControl_Inactive.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxControl_Inactive.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxControl_Inactive.CheckValue = 0
            Me.CheckBoxControl_Inactive.CheckValueChecked = 1
            Me.CheckBoxControl_Inactive.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxControl_Inactive.CheckValueUnchecked = 0
            Me.CheckBoxControl_Inactive.ChildControls = CType(resources.GetObject("CheckBoxControl_Inactive.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxControl_Inactive.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxControl_Inactive.Location = New System.Drawing.Point(537, 26)
            Me.CheckBoxControl_Inactive.Name = "CheckBoxControl_Inactive"
            Me.CheckBoxControl_Inactive.OldestSibling = Nothing
            Me.CheckBoxControl_Inactive.SecurityEnabled = True
            Me.CheckBoxControl_Inactive.SiblingControls = CType(resources.GetObject("CheckBoxControl_Inactive.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxControl_Inactive.Size = New System.Drawing.Size(63, 20)
            Me.CheckBoxControl_Inactive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxControl_Inactive.TabIndex = 4
            Me.CheckBoxControl_Inactive.TabOnEnter = True
            Me.CheckBoxControl_Inactive.Text = "Inactive"
            '
            'LabelControl_APForeignCurrencyExchangeAccount
            '
            Me.LabelControl_APForeignCurrencyExchangeAccount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_APForeignCurrencyExchangeAccount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_APForeignCurrencyExchangeAccount.Location = New System.Drawing.Point(0, 85)
            Me.LabelControl_APForeignCurrencyExchangeAccount.Name = "LabelControl_APForeignCurrencyExchangeAccount"
            Me.LabelControl_APForeignCurrencyExchangeAccount.Size = New System.Drawing.Size(202, 20)
            Me.LabelControl_APForeignCurrencyExchangeAccount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_APForeignCurrencyExchangeAccount.TabIndex = 5
            Me.LabelControl_APForeignCurrencyExchangeAccount.Text = "AP Foreign Currency Exchange Account:"
            Me.LabelControl_APForeignCurrencyExchangeAccount.Visible = False
            '
            'LabelControl_DefaultAPAccount
            '
            Me.LabelControl_DefaultAPAccount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_DefaultAPAccount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_DefaultAPAccount.Location = New System.Drawing.Point(0, 59)
            Me.LabelControl_DefaultAPAccount.Name = "LabelControl_DefaultAPAccount"
            Me.LabelControl_DefaultAPAccount.Size = New System.Drawing.Size(202, 20)
            Me.LabelControl_DefaultAPAccount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_DefaultAPAccount.TabIndex = 3
            Me.LabelControl_DefaultAPAccount.Text = "Default AP Account:"
            Me.LabelControl_DefaultAPAccount.Visible = False
            '
            'ComboBoxControl_APForeignCurrencyExchangeAccount
            '
            Me.ComboBoxControl_APForeignCurrencyExchangeAccount.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxControl_APForeignCurrencyExchangeAccount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxControl_APForeignCurrencyExchangeAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxControl_APForeignCurrencyExchangeAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxControl_APForeignCurrencyExchangeAccount.AutoFindItemInDataSource = False
            Me.ComboBoxControl_APForeignCurrencyExchangeAccount.AutoSelectSingleItemDatasource = False
            Me.ComboBoxControl_APForeignCurrencyExchangeAccount.BookmarkingEnabled = False
            Me.ComboBoxControl_APForeignCurrencyExchangeAccount.ClientCode = ""
            Me.ComboBoxControl_APForeignCurrencyExchangeAccount.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.GeneralLedgerAccount
            Me.ComboBoxControl_APForeignCurrencyExchangeAccount.DisableMouseWheel = False
            Me.ComboBoxControl_APForeignCurrencyExchangeAccount.DisplayMember = "Description"
            Me.ComboBoxControl_APForeignCurrencyExchangeAccount.DisplayName = ""
            Me.ComboBoxControl_APForeignCurrencyExchangeAccount.DivisionCode = ""
            Me.ComboBoxControl_APForeignCurrencyExchangeAccount.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxControl_APForeignCurrencyExchangeAccount.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxControl_APForeignCurrencyExchangeAccount.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxControl_APForeignCurrencyExchangeAccount.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxControl_APForeignCurrencyExchangeAccount.FocusHighlightEnabled = True
            Me.ComboBoxControl_APForeignCurrencyExchangeAccount.FormattingEnabled = True
            Me.ComboBoxControl_APForeignCurrencyExchangeAccount.ItemHeight = 16
            Me.ComboBoxControl_APForeignCurrencyExchangeAccount.Location = New System.Drawing.Point(84, 130)
            Me.ComboBoxControl_APForeignCurrencyExchangeAccount.Name = "ComboBoxControl_APForeignCurrencyExchangeAccount"
            Me.ComboBoxControl_APForeignCurrencyExchangeAccount.ReadOnly = False
            Me.ComboBoxControl_APForeignCurrencyExchangeAccount.SecurityEnabled = True
            Me.ComboBoxControl_APForeignCurrencyExchangeAccount.Size = New System.Drawing.Size(392, 22)
            Me.ComboBoxControl_APForeignCurrencyExchangeAccount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxControl_APForeignCurrencyExchangeAccount.TabIndex = 16
            Me.ComboBoxControl_APForeignCurrencyExchangeAccount.TabOnEnter = True
            Me.ComboBoxControl_APForeignCurrencyExchangeAccount.ValueMember = "Code"
            Me.ComboBoxControl_APForeignCurrencyExchangeAccount.WatermarkText = "Select General Ledger Account"
            '
            'DataGridViewControl_CurrencyDetails
            '
            Me.DataGridViewControl_CurrencyDetails.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewControl_CurrencyDetails.AllowDragAndDrop = False
            Me.DataGridViewControl_CurrencyDetails.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewControl_CurrencyDetails.AllowSelectGroupHeaderRow = True
            Me.DataGridViewControl_CurrencyDetails.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewControl_CurrencyDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewControl_CurrencyDetails.AutoFilterLookupColumns = False
            Me.DataGridViewControl_CurrencyDetails.AutoloadRepositoryDatasource = True
            Me.DataGridViewControl_CurrencyDetails.AutoUpdateViewCaption = True
            Me.DataGridViewControl_CurrencyDetails.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewControl_CurrencyDetails.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewControl_CurrencyDetails.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewControl_CurrencyDetails.ItemDescription = ""
            Me.DataGridViewControl_CurrencyDetails.Location = New System.Drawing.Point(0, 53)
            Me.DataGridViewControl_CurrencyDetails.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewControl_CurrencyDetails.MultiSelect = True
            Me.DataGridViewControl_CurrencyDetails.Name = "DataGridViewControl_CurrencyDetails"
            Me.DataGridViewControl_CurrencyDetails.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewControl_CurrencyDetails.RunStandardValidation = True
            Me.DataGridViewControl_CurrencyDetails.ShowColumnMenuOnRightClick = False
            Me.DataGridViewControl_CurrencyDetails.ShowSelectDeselectAllButtons = False
            Me.DataGridViewControl_CurrencyDetails.Size = New System.Drawing.Size(600, 324)
            Me.DataGridViewControl_CurrencyDetails.TabIndex = 5
            Me.DataGridViewControl_CurrencyDetails.UseEmbeddedNavigator = False
            Me.DataGridViewControl_CurrencyDetails.ViewCaptionHeight = -1
            '
            'PanelControl_Control
            '
            Me.PanelControl_Control.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelControl_Control.Controls.Add(Me.SearchableComboBoxControl_HomeCurrency)
            Me.PanelControl_Control.Controls.Add(Me.LabelControl_HomeCurrency)
            Me.PanelControl_Control.Controls.Add(Me.DataGridViewControl_CurrencyDetails)
            Me.PanelControl_Control.Controls.Add(Me.SearchableComboBoxControl_APForeignCurrencyExchangeAccount)
            Me.PanelControl_Control.Controls.Add(Me.SearchableComboBoxControl_DefaultAPAccount)
            Me.PanelControl_Control.Controls.Add(Me.SearchableComboBoxControl_Currency)
            Me.PanelControl_Control.Controls.Add(Me.LabelControl_ForeignCurrency)
            Me.PanelControl_Control.Controls.Add(Me.ComboBoxControl_APForeignCurrencyExchangeAccount)
            Me.PanelControl_Control.Controls.Add(Me.LabelControl_DefaultAPAccount)
            Me.PanelControl_Control.Controls.Add(Me.LabelControl_APForeignCurrencyExchangeAccount)
            Me.PanelControl_Control.Controls.Add(Me.CheckBoxControl_Inactive)
            Me.PanelControl_Control.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelControl_Control.Location = New System.Drawing.Point(0, 0)
            Me.PanelControl_Control.Margin = New System.Windows.Forms.Padding(2)
            Me.PanelControl_Control.Name = "PanelControl_Control"
            Me.PanelControl_Control.Size = New System.Drawing.Size(600, 377)
            Me.PanelControl_Control.TabIndex = 45
            '
            'SearchableComboBoxControl_HomeCurrency
            '
            Me.SearchableComboBoxControl_HomeCurrency.ActiveFilterString = ""
            Me.SearchableComboBoxControl_HomeCurrency.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxControl_HomeCurrency.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxControl_HomeCurrency.AutoFillMode = False
            Me.SearchableComboBoxControl_HomeCurrency.BookmarkingEnabled = False
            Me.SearchableComboBoxControl_HomeCurrency.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.CurrencyCode
            Me.SearchableComboBoxControl_HomeCurrency.DataSource = Nothing
            Me.SearchableComboBoxControl_HomeCurrency.DisableMouseWheel = False
            Me.SearchableComboBoxControl_HomeCurrency.DisplayName = ""
            Me.SearchableComboBoxControl_HomeCurrency.EnterMoveNextControl = True
            Me.SearchableComboBoxControl_HomeCurrency.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxControl_HomeCurrency.Location = New System.Drawing.Point(131, 0)
            Me.SearchableComboBoxControl_HomeCurrency.Name = "SearchableComboBoxControl_HomeCurrency"
            Me.SearchableComboBoxControl_HomeCurrency.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxControl_HomeCurrency.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxControl_HomeCurrency.Properties.NullText = "Select Currency Code"
            Me.SearchableComboBoxControl_HomeCurrency.Properties.ValueMember = "Code"
            Me.SearchableComboBoxControl_HomeCurrency.Properties.View = Me.GridView3
            Me.SearchableComboBoxControl_HomeCurrency.SecurityEnabled = True
            Me.SearchableComboBoxControl_HomeCurrency.SelectedValue = Nothing
            Me.SearchableComboBoxControl_HomeCurrency.Size = New System.Drawing.Size(399, 20)
            Me.SearchableComboBoxControl_HomeCurrency.TabIndex = 1
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
            'LabelControl_HomeCurrency
            '
            Me.LabelControl_HomeCurrency.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_HomeCurrency.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_HomeCurrency.Location = New System.Drawing.Point(0, 0)
            Me.LabelControl_HomeCurrency.Name = "LabelControl_HomeCurrency"
            Me.LabelControl_HomeCurrency.Size = New System.Drawing.Size(125, 20)
            Me.LabelControl_HomeCurrency.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_HomeCurrency.TabIndex = 0
            Me.LabelControl_HomeCurrency.Text = "Home Currency:"
            '
            'SearchableComboBoxControl_APForeignCurrencyExchangeAccount
            '
            Me.SearchableComboBoxControl_APForeignCurrencyExchangeAccount.ActiveFilterString = ""
            Me.SearchableComboBoxControl_APForeignCurrencyExchangeAccount.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxControl_APForeignCurrencyExchangeAccount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxControl_APForeignCurrencyExchangeAccount.AutoFillMode = False
            Me.SearchableComboBoxControl_APForeignCurrencyExchangeAccount.BookmarkingEnabled = False
            Me.SearchableComboBoxControl_APForeignCurrencyExchangeAccount.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.GeneralLedgerAccount
            Me.SearchableComboBoxControl_APForeignCurrencyExchangeAccount.DataSource = Nothing
            Me.SearchableComboBoxControl_APForeignCurrencyExchangeAccount.DisableMouseWheel = False
            Me.SearchableComboBoxControl_APForeignCurrencyExchangeAccount.DisplayName = ""
            Me.SearchableComboBoxControl_APForeignCurrencyExchangeAccount.EnterMoveNextControl = True
            Me.SearchableComboBoxControl_APForeignCurrencyExchangeAccount.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxControl_APForeignCurrencyExchangeAccount.Location = New System.Drawing.Point(208, 85)
            Me.SearchableComboBoxControl_APForeignCurrencyExchangeAccount.Name = "SearchableComboBoxControl_APForeignCurrencyExchangeAccount"
            Me.SearchableComboBoxControl_APForeignCurrencyExchangeAccount.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxControl_APForeignCurrencyExchangeAccount.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxControl_APForeignCurrencyExchangeAccount.Properties.NullText = "Select General Ledger Account"
            Me.SearchableComboBoxControl_APForeignCurrencyExchangeAccount.Properties.ValueMember = "Code"
            Me.SearchableComboBoxControl_APForeignCurrencyExchangeAccount.Properties.View = Me.GridView2
            Me.SearchableComboBoxControl_APForeignCurrencyExchangeAccount.SecurityEnabled = True
            Me.SearchableComboBoxControl_APForeignCurrencyExchangeAccount.SelectedValue = Nothing
            Me.SearchableComboBoxControl_APForeignCurrencyExchangeAccount.Size = New System.Drawing.Size(392, 20)
            Me.SearchableComboBoxControl_APForeignCurrencyExchangeAccount.TabIndex = 6
            Me.SearchableComboBoxControl_APForeignCurrencyExchangeAccount.Visible = False
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
            'SearchableComboBoxControl_DefaultAPAccount
            '
            Me.SearchableComboBoxControl_DefaultAPAccount.ActiveFilterString = ""
            Me.SearchableComboBoxControl_DefaultAPAccount.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxControl_DefaultAPAccount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxControl_DefaultAPAccount.AutoFillMode = False
            Me.SearchableComboBoxControl_DefaultAPAccount.BookmarkingEnabled = False
            Me.SearchableComboBoxControl_DefaultAPAccount.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.GeneralLedgerAccount
            Me.SearchableComboBoxControl_DefaultAPAccount.DataSource = Nothing
            Me.SearchableComboBoxControl_DefaultAPAccount.DisableMouseWheel = False
            Me.SearchableComboBoxControl_DefaultAPAccount.DisplayName = ""
            Me.SearchableComboBoxControl_DefaultAPAccount.EnterMoveNextControl = True
            Me.SearchableComboBoxControl_DefaultAPAccount.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxControl_DefaultAPAccount.Location = New System.Drawing.Point(208, 59)
            Me.SearchableComboBoxControl_DefaultAPAccount.Name = "SearchableComboBoxControl_DefaultAPAccount"
            Me.SearchableComboBoxControl_DefaultAPAccount.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxControl_DefaultAPAccount.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxControl_DefaultAPAccount.Properties.NullText = "Select General Ledger Account"
            Me.SearchableComboBoxControl_DefaultAPAccount.Properties.ValueMember = "Code"
            Me.SearchableComboBoxControl_DefaultAPAccount.Properties.View = Me.GridView1
            Me.SearchableComboBoxControl_DefaultAPAccount.SecurityEnabled = True
            Me.SearchableComboBoxControl_DefaultAPAccount.SelectedValue = Nothing
            Me.SearchableComboBoxControl_DefaultAPAccount.Size = New System.Drawing.Size(392, 20)
            Me.SearchableComboBoxControl_DefaultAPAccount.TabIndex = 4
            Me.SearchableComboBoxControl_DefaultAPAccount.Visible = False
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
            'SearchableComboBoxControl_Currency
            '
            Me.SearchableComboBoxControl_Currency.ActiveFilterString = ""
            Me.SearchableComboBoxControl_Currency.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxControl_Currency.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxControl_Currency.AutoFillMode = False
            Me.SearchableComboBoxControl_Currency.BookmarkingEnabled = False
            Me.SearchableComboBoxControl_Currency.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.CurrencyCode
            Me.SearchableComboBoxControl_Currency.DataSource = Nothing
            Me.SearchableComboBoxControl_Currency.DisableMouseWheel = False
            Me.SearchableComboBoxControl_Currency.DisplayName = ""
            Me.SearchableComboBoxControl_Currency.EnterMoveNextControl = True
            Me.SearchableComboBoxControl_Currency.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxControl_Currency.Location = New System.Drawing.Point(131, 26)
            Me.SearchableComboBoxControl_Currency.Name = "SearchableComboBoxControl_Currency"
            Me.SearchableComboBoxControl_Currency.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxControl_Currency.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxControl_Currency.Properties.NullText = "Select Currency Code"
            Me.SearchableComboBoxControl_Currency.Properties.ValueMember = "Code"
            Me.SearchableComboBoxControl_Currency.Properties.View = Me.GridView4
            Me.SearchableComboBoxControl_Currency.SecurityEnabled = True
            Me.SearchableComboBoxControl_Currency.SelectedValue = Nothing
            Me.SearchableComboBoxControl_Currency.Size = New System.Drawing.Size(399, 20)
            Me.SearchableComboBoxControl_Currency.TabIndex = 3
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
            '
            'CurrencyCodeControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.PanelControl_Control)
            Me.Name = "CurrencyCodeControl"
            Me.Size = New System.Drawing.Size(600, 377)
            CType(Me.PanelControl_Control, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelControl_Control.ResumeLayout(False)
            CType(Me.SearchableComboBoxControl_HomeCurrency.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxControl_APForeignCurrencyExchangeAccount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxControl_DefaultAPAccount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxControl_Currency.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents LabelControl_ForeignCurrency As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxControl_Inactive As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelControl_APForeignCurrencyExchangeAccount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelControl_DefaultAPAccount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxControl_APForeignCurrencyExchangeAccount As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents DataGridViewControl_CurrencyDetails As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents PanelControl_Control As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents SearchableComboBoxControl_Currency As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView4 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxControl_DefaultAPAccount As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView1 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxControl_APForeignCurrencyExchangeAccount As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView2 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxControl_HomeCurrency As SearchableComboBox
        Friend WithEvents GridView3 As GridView
        Friend WithEvents LabelControl_HomeCurrency As Label
    End Class

End Namespace
