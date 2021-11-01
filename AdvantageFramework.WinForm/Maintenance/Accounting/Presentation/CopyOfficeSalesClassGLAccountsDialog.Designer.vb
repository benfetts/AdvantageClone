Namespace Maintenance.Accounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class CopyOfficeSalesClassGLAccountsDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CopyOfficeSalesClassGLAccountsDialog))
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_CopyUsingOffice = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ButtonForm_Copy = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ComboBoxForm_Office = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ComboBoxForm_SalesClass = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_CopyUsingSalesClass = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.GroupBoxForm_GLSalesClassFunctionAccounts = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.DataGridViewGLSalesClassFunctionAccounts_GLSCFA = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.GroupBoxForm_GLSalesClassAccounts = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.LabelGLSalesClassAccounts_MediaCOS = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGLSalesClassAccounts_MediaSales = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGLSalesClassAccounts_ProductionCOS = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxGLSalesClassAccounts_MediaSales = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxGLSalesClassAccounts_MediaCOS = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxGLSalesClassAccounts_ProductionCOS = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelGLSalesClassAccounts_ProductionSales = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxGLSalesClassAccounts_ProductionSales = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.CheckBoxForm_ReplaceOfficeSegment = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            CType(Me.GroupBoxForm_GLSalesClassFunctionAccounts, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxForm_GLSalesClassFunctionAccounts.SuspendLayout()
            CType(Me.GroupBoxForm_GLSalesClassAccounts, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxForm_GLSalesClassAccounts.SuspendLayout()
            CType(Me.SearchableComboBoxGLSalesClassAccounts_MediaSales.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxGLSalesClassAccounts_MediaCOS.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxGLSalesClassAccounts_ProductionCOS.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxGLSalesClassAccounts_ProductionSales.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(570, 419)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 8
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'LabelForm_CopyUsingOffice
            '
            Me.LabelForm_CopyUsingOffice.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_CopyUsingOffice.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_CopyUsingOffice.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_CopyUsingOffice.Name = "LabelForm_CopyUsingOffice"
            Me.LabelForm_CopyUsingOffice.Size = New System.Drawing.Size(130, 20)
            Me.LabelForm_CopyUsingOffice.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_CopyUsingOffice.TabIndex = 0
            Me.LabelForm_CopyUsingOffice.Text = "Copy Using Office:"
            '
            'ButtonForm_Copy
            '
            Me.ButtonForm_Copy.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Copy.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Copy.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Copy.Location = New System.Drawing.Point(489, 419)
            Me.ButtonForm_Copy.Name = "ButtonForm_Copy"
            Me.ButtonForm_Copy.SecurityEnabled = True
            Me.ButtonForm_Copy.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Copy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Copy.TabIndex = 7
            Me.ButtonForm_Copy.Text = "Copy"
            '
            'ComboBoxForm_Office
            '
            Me.ComboBoxForm_Office.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_Office.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_Office.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Office.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Office.AutoFindItemInDataSource = False
            Me.ComboBoxForm_Office.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_Office.BookmarkingEnabled = False
            Me.ComboBoxForm_Office.ClientCode = ""
            Me.ComboBoxForm_Office.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Office
            Me.ComboBoxForm_Office.DisableMouseWheel = False
            Me.ComboBoxForm_Office.DisplayMember = "Name"
            Me.ComboBoxForm_Office.DisplayName = ""
            Me.ComboBoxForm_Office.DivisionCode = ""
            Me.ComboBoxForm_Office.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Office.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxForm_Office.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_Office.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Office.FocusHighlightEnabled = True
            Me.ComboBoxForm_Office.FormattingEnabled = True
            Me.ComboBoxForm_Office.ItemHeight = 14
            Me.ComboBoxForm_Office.Location = New System.Drawing.Point(148, 12)
            Me.ComboBoxForm_Office.Name = "ComboBoxForm_Office"
            Me.ComboBoxForm_Office.ReadOnly = False
            Me.ComboBoxForm_Office.SecurityEnabled = True
            Me.ComboBoxForm_Office.Size = New System.Drawing.Size(277, 20)
            Me.ComboBoxForm_Office.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Office.TabIndex = 1
            Me.ComboBoxForm_Office.TabOnEnter = True
            Me.ComboBoxForm_Office.ValueMember = "Code"
            Me.ComboBoxForm_Office.WatermarkText = "Select Office"
            '
            'ComboBoxForm_SalesClass
            '
            Me.ComboBoxForm_SalesClass.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_SalesClass.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_SalesClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_SalesClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_SalesClass.AutoFindItemInDataSource = False
            Me.ComboBoxForm_SalesClass.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_SalesClass.BookmarkingEnabled = False
            Me.ComboBoxForm_SalesClass.ClientCode = ""
            Me.ComboBoxForm_SalesClass.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.[Default]
            Me.ComboBoxForm_SalesClass.DisableMouseWheel = False
            Me.ComboBoxForm_SalesClass.DisplayName = ""
            Me.ComboBoxForm_SalesClass.DivisionCode = ""
            Me.ComboBoxForm_SalesClass.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_SalesClass.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxForm_SalesClass.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_SalesClass.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_SalesClass.FocusHighlightEnabled = True
            Me.ComboBoxForm_SalesClass.FormattingEnabled = True
            Me.ComboBoxForm_SalesClass.ItemHeight = 14
            Me.ComboBoxForm_SalesClass.Location = New System.Drawing.Point(148, 38)
            Me.ComboBoxForm_SalesClass.Name = "ComboBoxForm_SalesClass"
            Me.ComboBoxForm_SalesClass.ReadOnly = False
            Me.ComboBoxForm_SalesClass.SecurityEnabled = True
            Me.ComboBoxForm_SalesClass.Size = New System.Drawing.Size(277, 20)
            Me.ComboBoxForm_SalesClass.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_SalesClass.TabIndex = 3
            Me.ComboBoxForm_SalesClass.TabOnEnter = True
            '
            'LabelForm_CopyUsingSalesClass
            '
            Me.LabelForm_CopyUsingSalesClass.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_CopyUsingSalesClass.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_CopyUsingSalesClass.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_CopyUsingSalesClass.Name = "LabelForm_CopyUsingSalesClass"
            Me.LabelForm_CopyUsingSalesClass.Size = New System.Drawing.Size(130, 20)
            Me.LabelForm_CopyUsingSalesClass.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_CopyUsingSalesClass.TabIndex = 2
            Me.LabelForm_CopyUsingSalesClass.Text = "Copy Using Sales Class:"
            '
            'GroupBoxForm_GLSalesClassFunctionAccounts
            '
            Me.GroupBoxForm_GLSalesClassFunctionAccounts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxForm_GLSalesClassFunctionAccounts.Controls.Add(Me.DataGridViewGLSalesClassFunctionAccounts_GLSCFA)
            Me.GroupBoxForm_GLSalesClassFunctionAccounts.Location = New System.Drawing.Point(12, 203)
            Me.GroupBoxForm_GLSalesClassFunctionAccounts.Name = "GroupBoxForm_GLSalesClassFunctionAccounts"
            Me.GroupBoxForm_GLSalesClassFunctionAccounts.Size = New System.Drawing.Size(633, 210)
            Me.GroupBoxForm_GLSalesClassFunctionAccounts.TabIndex = 5
            Me.GroupBoxForm_GLSalesClassFunctionAccounts.Text = "GL Sales Class Function Accounts"
            '
            'DataGridViewGLSalesClassFunctionAccounts_GLSCFA
            '
            Me.DataGridViewGLSalesClassFunctionAccounts_GLSCFA.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewGLSalesClassFunctionAccounts_GLSCFA.AllowDragAndDrop = False
            Me.DataGridViewGLSalesClassFunctionAccounts_GLSCFA.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewGLSalesClassFunctionAccounts_GLSCFA.AllowSelectGroupHeaderRow = True
            Me.DataGridViewGLSalesClassFunctionAccounts_GLSCFA.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewGLSalesClassFunctionAccounts_GLSCFA.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewGLSalesClassFunctionAccounts_GLSCFA.AutoFilterLookupColumns = False
            Me.DataGridViewGLSalesClassFunctionAccounts_GLSCFA.AutoloadRepositoryDatasource = True
            Me.DataGridViewGLSalesClassFunctionAccounts_GLSCFA.AutoUpdateViewCaption = True
            Me.DataGridViewGLSalesClassFunctionAccounts_GLSCFA.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewGLSalesClassFunctionAccounts_GLSCFA.DataSource = Nothing
            Me.DataGridViewGLSalesClassFunctionAccounts_GLSCFA.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewGLSalesClassFunctionAccounts_GLSCFA.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewGLSalesClassFunctionAccounts_GLSCFA.ItemDescription = ""
            Me.DataGridViewGLSalesClassFunctionAccounts_GLSCFA.Location = New System.Drawing.Point(5, 25)
            Me.DataGridViewGLSalesClassFunctionAccounts_GLSCFA.MultiSelect = True
            Me.DataGridViewGLSalesClassFunctionAccounts_GLSCFA.Name = "DataGridViewGLSalesClassFunctionAccounts_GLSCFA"
            Me.DataGridViewGLSalesClassFunctionAccounts_GLSCFA.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewGLSalesClassFunctionAccounts_GLSCFA.RunStandardValidation = True
            Me.DataGridViewGLSalesClassFunctionAccounts_GLSCFA.ShowColumnMenuOnRightClick = False
            Me.DataGridViewGLSalesClassFunctionAccounts_GLSCFA.ShowSelectDeselectAllButtons = False
            Me.DataGridViewGLSalesClassFunctionAccounts_GLSCFA.Size = New System.Drawing.Size(623, 180)
            Me.DataGridViewGLSalesClassFunctionAccounts_GLSCFA.TabIndex = 0
            Me.DataGridViewGLSalesClassFunctionAccounts_GLSCFA.UseEmbeddedNavigator = False
            Me.DataGridViewGLSalesClassFunctionAccounts_GLSCFA.ViewCaptionHeight = -1
            '
            'GroupBoxForm_GLSalesClassAccounts
            '
            Me.GroupBoxForm_GLSalesClassAccounts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxForm_GLSalesClassAccounts.Controls.Add(Me.LabelGLSalesClassAccounts_MediaCOS)
            Me.GroupBoxForm_GLSalesClassAccounts.Controls.Add(Me.LabelGLSalesClassAccounts_MediaSales)
            Me.GroupBoxForm_GLSalesClassAccounts.Controls.Add(Me.LabelGLSalesClassAccounts_ProductionCOS)
            Me.GroupBoxForm_GLSalesClassAccounts.Controls.Add(Me.SearchableComboBoxGLSalesClassAccounts_MediaSales)
            Me.GroupBoxForm_GLSalesClassAccounts.Controls.Add(Me.SearchableComboBoxGLSalesClassAccounts_MediaCOS)
            Me.GroupBoxForm_GLSalesClassAccounts.Controls.Add(Me.SearchableComboBoxGLSalesClassAccounts_ProductionCOS)
            Me.GroupBoxForm_GLSalesClassAccounts.Controls.Add(Me.LabelGLSalesClassAccounts_ProductionSales)
            Me.GroupBoxForm_GLSalesClassAccounts.Controls.Add(Me.SearchableComboBoxGLSalesClassAccounts_ProductionSales)
            Me.GroupBoxForm_GLSalesClassAccounts.Location = New System.Drawing.Point(12, 64)
            Me.GroupBoxForm_GLSalesClassAccounts.Name = "GroupBoxForm_GLSalesClassAccounts"
            Me.GroupBoxForm_GLSalesClassAccounts.Size = New System.Drawing.Size(633, 133)
            Me.GroupBoxForm_GLSalesClassAccounts.TabIndex = 4
            Me.GroupBoxForm_GLSalesClassAccounts.Text = "GL Sales Class Accounts"
            '
            'LabelGLSalesClassAccounts_MediaCOS
            '
            Me.LabelGLSalesClassAccounts_MediaCOS.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGLSalesClassAccounts_MediaCOS.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGLSalesClassAccounts_MediaCOS.Location = New System.Drawing.Point(5, 103)
            Me.LabelGLSalesClassAccounts_MediaCOS.Name = "LabelGLSalesClassAccounts_MediaCOS"
            Me.LabelGLSalesClassAccounts_MediaCOS.Size = New System.Drawing.Size(95, 20)
            Me.LabelGLSalesClassAccounts_MediaCOS.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGLSalesClassAccounts_MediaCOS.TabIndex = 6
            Me.LabelGLSalesClassAccounts_MediaCOS.Text = "Media COS:"
            '
            'LabelGLSalesClassAccounts_MediaSales
            '
            Me.LabelGLSalesClassAccounts_MediaSales.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGLSalesClassAccounts_MediaSales.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGLSalesClassAccounts_MediaSales.Location = New System.Drawing.Point(5, 77)
            Me.LabelGLSalesClassAccounts_MediaSales.Name = "LabelGLSalesClassAccounts_MediaSales"
            Me.LabelGLSalesClassAccounts_MediaSales.Size = New System.Drawing.Size(95, 20)
            Me.LabelGLSalesClassAccounts_MediaSales.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGLSalesClassAccounts_MediaSales.TabIndex = 4
            Me.LabelGLSalesClassAccounts_MediaSales.Text = "Media Sales:"
            '
            'LabelGLSalesClassAccounts_ProductionCOS
            '
            Me.LabelGLSalesClassAccounts_ProductionCOS.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGLSalesClassAccounts_ProductionCOS.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGLSalesClassAccounts_ProductionCOS.Location = New System.Drawing.Point(5, 51)
            Me.LabelGLSalesClassAccounts_ProductionCOS.Name = "LabelGLSalesClassAccounts_ProductionCOS"
            Me.LabelGLSalesClassAccounts_ProductionCOS.Size = New System.Drawing.Size(95, 20)
            Me.LabelGLSalesClassAccounts_ProductionCOS.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGLSalesClassAccounts_ProductionCOS.TabIndex = 2
            Me.LabelGLSalesClassAccounts_ProductionCOS.Text = "Production COS:"
            '
            'SearchableComboBoxGLSalesClassAccounts_MediaSales
            '
            Me.SearchableComboBoxGLSalesClassAccounts_MediaSales.ActiveFilterString = ""
            Me.SearchableComboBoxGLSalesClassAccounts_MediaSales.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxGLSalesClassAccounts_MediaSales.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxGLSalesClassAccounts_MediaSales.AutoFillMode = False
            Me.SearchableComboBoxGLSalesClassAccounts_MediaSales.BookmarkingEnabled = False
            Me.SearchableComboBoxGLSalesClassAccounts_MediaSales.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.GeneralLedgerAccount
            Me.SearchableComboBoxGLSalesClassAccounts_MediaSales.DataSource = Nothing
            Me.SearchableComboBoxGLSalesClassAccounts_MediaSales.DisableMouseWheel = True
            Me.SearchableComboBoxGLSalesClassAccounts_MediaSales.DisplayName = ""
            Me.SearchableComboBoxGLSalesClassAccounts_MediaSales.EnterMoveNextControl = True
            Me.SearchableComboBoxGLSalesClassAccounts_MediaSales.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxGLSalesClassAccounts_MediaSales.Location = New System.Drawing.Point(136, 77)
            Me.SearchableComboBoxGLSalesClassAccounts_MediaSales.Name = "SearchableComboBoxGLSalesClassAccounts_MediaSales"
            Me.SearchableComboBoxGLSalesClassAccounts_MediaSales.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxGLSalesClassAccounts_MediaSales.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxGLSalesClassAccounts_MediaSales.Properties.NullText = "[Please Select]"
            Me.SearchableComboBoxGLSalesClassAccounts_MediaSales.Properties.ValueMember = "Code"
            Me.SearchableComboBoxGLSalesClassAccounts_MediaSales.Properties.View = Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales
            Me.SearchableComboBoxGLSalesClassAccounts_MediaSales.SecurityEnabled = True
            Me.SearchableComboBoxGLSalesClassAccounts_MediaSales.SelectedValue = Nothing
            Me.SearchableComboBoxGLSalesClassAccounts_MediaSales.Size = New System.Drawing.Size(277, 20)
            Me.SearchableComboBoxGLSalesClassAccounts_MediaSales.TabIndex = 5
            '
            'SearchableComboBoxViewGLSalesClassAccounts_MediaSales
            '
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales.AFActiveFilterString = ""
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales.DataSourceClearing = False
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales.EnableDisabledRows = False
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales.Name = "SearchableComboBoxViewGLSalesClassAccounts_MediaSales"
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales.RunStandardValidation = True
            '
            'SearchableComboBoxGLSalesClassAccounts_MediaCOS
            '
            Me.SearchableComboBoxGLSalesClassAccounts_MediaCOS.ActiveFilterString = ""
            Me.SearchableComboBoxGLSalesClassAccounts_MediaCOS.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxGLSalesClassAccounts_MediaCOS.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxGLSalesClassAccounts_MediaCOS.AutoFillMode = False
            Me.SearchableComboBoxGLSalesClassAccounts_MediaCOS.BookmarkingEnabled = False
            Me.SearchableComboBoxGLSalesClassAccounts_MediaCOS.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.GeneralLedgerAccount
            Me.SearchableComboBoxGLSalesClassAccounts_MediaCOS.DataSource = Nothing
            Me.SearchableComboBoxGLSalesClassAccounts_MediaCOS.DisableMouseWheel = True
            Me.SearchableComboBoxGLSalesClassAccounts_MediaCOS.DisplayName = ""
            Me.SearchableComboBoxGLSalesClassAccounts_MediaCOS.EnterMoveNextControl = True
            Me.SearchableComboBoxGLSalesClassAccounts_MediaCOS.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxGLSalesClassAccounts_MediaCOS.Location = New System.Drawing.Point(136, 103)
            Me.SearchableComboBoxGLSalesClassAccounts_MediaCOS.Name = "SearchableComboBoxGLSalesClassAccounts_MediaCOS"
            Me.SearchableComboBoxGLSalesClassAccounts_MediaCOS.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxGLSalesClassAccounts_MediaCOS.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxGLSalesClassAccounts_MediaCOS.Properties.NullText = "[Please Select]"
            Me.SearchableComboBoxGLSalesClassAccounts_MediaCOS.Properties.ValueMember = "Code"
            Me.SearchableComboBoxGLSalesClassAccounts_MediaCOS.Properties.View = Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS
            Me.SearchableComboBoxGLSalesClassAccounts_MediaCOS.SecurityEnabled = True
            Me.SearchableComboBoxGLSalesClassAccounts_MediaCOS.SelectedValue = Nothing
            Me.SearchableComboBoxGLSalesClassAccounts_MediaCOS.Size = New System.Drawing.Size(277, 20)
            Me.SearchableComboBoxGLSalesClassAccounts_MediaCOS.TabIndex = 7
            '
            'SearchableComboBoxViewGLSalesClassAccounts_MediaCOS
            '
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS.AFActiveFilterString = ""
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS.DataSourceClearing = False
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS.EnableDisabledRows = False
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS.Name = "SearchableComboBoxViewGLSalesClassAccounts_MediaCOS"
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS.RunStandardValidation = True
            '
            'SearchableComboBoxGLSalesClassAccounts_ProductionCOS
            '
            Me.SearchableComboBoxGLSalesClassAccounts_ProductionCOS.ActiveFilterString = ""
            Me.SearchableComboBoxGLSalesClassAccounts_ProductionCOS.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxGLSalesClassAccounts_ProductionCOS.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxGLSalesClassAccounts_ProductionCOS.AutoFillMode = False
            Me.SearchableComboBoxGLSalesClassAccounts_ProductionCOS.BookmarkingEnabled = False
            Me.SearchableComboBoxGLSalesClassAccounts_ProductionCOS.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.GeneralLedgerAccount
            Me.SearchableComboBoxGLSalesClassAccounts_ProductionCOS.DataSource = Nothing
            Me.SearchableComboBoxGLSalesClassAccounts_ProductionCOS.DisableMouseWheel = True
            Me.SearchableComboBoxGLSalesClassAccounts_ProductionCOS.DisplayName = ""
            Me.SearchableComboBoxGLSalesClassAccounts_ProductionCOS.EnterMoveNextControl = True
            Me.SearchableComboBoxGLSalesClassAccounts_ProductionCOS.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxGLSalesClassAccounts_ProductionCOS.Location = New System.Drawing.Point(136, 51)
            Me.SearchableComboBoxGLSalesClassAccounts_ProductionCOS.Name = "SearchableComboBoxGLSalesClassAccounts_ProductionCOS"
            Me.SearchableComboBoxGLSalesClassAccounts_ProductionCOS.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxGLSalesClassAccounts_ProductionCOS.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxGLSalesClassAccounts_ProductionCOS.Properties.NullText = "[Please Select]"
            Me.SearchableComboBoxGLSalesClassAccounts_ProductionCOS.Properties.ValueMember = "Code"
            Me.SearchableComboBoxGLSalesClassAccounts_ProductionCOS.Properties.View = Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS
            Me.SearchableComboBoxGLSalesClassAccounts_ProductionCOS.SecurityEnabled = True
            Me.SearchableComboBoxGLSalesClassAccounts_ProductionCOS.SelectedValue = Nothing
            Me.SearchableComboBoxGLSalesClassAccounts_ProductionCOS.Size = New System.Drawing.Size(277, 20)
            Me.SearchableComboBoxGLSalesClassAccounts_ProductionCOS.TabIndex = 3
            '
            'SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS
            '
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS.AFActiveFilterString = ""
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS.DataSourceClearing = False
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS.EnableDisabledRows = False
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS.Name = "SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS"
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS.RunStandardValidation = True
            '
            'LabelGLSalesClassAccounts_ProductionSales
            '
            Me.LabelGLSalesClassAccounts_ProductionSales.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGLSalesClassAccounts_ProductionSales.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGLSalesClassAccounts_ProductionSales.Location = New System.Drawing.Point(5, 25)
            Me.LabelGLSalesClassAccounts_ProductionSales.Name = "LabelGLSalesClassAccounts_ProductionSales"
            Me.LabelGLSalesClassAccounts_ProductionSales.Size = New System.Drawing.Size(95, 20)
            Me.LabelGLSalesClassAccounts_ProductionSales.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGLSalesClassAccounts_ProductionSales.TabIndex = 0
            Me.LabelGLSalesClassAccounts_ProductionSales.Text = "Production Sales:"
            '
            'SearchableComboBoxGLSalesClassAccounts_ProductionSales
            '
            Me.SearchableComboBoxGLSalesClassAccounts_ProductionSales.ActiveFilterString = ""
            Me.SearchableComboBoxGLSalesClassAccounts_ProductionSales.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxGLSalesClassAccounts_ProductionSales.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxGLSalesClassAccounts_ProductionSales.AutoFillMode = False
            Me.SearchableComboBoxGLSalesClassAccounts_ProductionSales.BookmarkingEnabled = False
            Me.SearchableComboBoxGLSalesClassAccounts_ProductionSales.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.GeneralLedgerAccount
            Me.SearchableComboBoxGLSalesClassAccounts_ProductionSales.DataSource = Nothing
            Me.SearchableComboBoxGLSalesClassAccounts_ProductionSales.DisableMouseWheel = True
            Me.SearchableComboBoxGLSalesClassAccounts_ProductionSales.DisplayName = ""
            Me.SearchableComboBoxGLSalesClassAccounts_ProductionSales.EnterMoveNextControl = True
            Me.SearchableComboBoxGLSalesClassAccounts_ProductionSales.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxGLSalesClassAccounts_ProductionSales.Location = New System.Drawing.Point(136, 25)
            Me.SearchableComboBoxGLSalesClassAccounts_ProductionSales.Name = "SearchableComboBoxGLSalesClassAccounts_ProductionSales"
            Me.SearchableComboBoxGLSalesClassAccounts_ProductionSales.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxGLSalesClassAccounts_ProductionSales.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxGLSalesClassAccounts_ProductionSales.Properties.NullText = "[Please Select]"
            Me.SearchableComboBoxGLSalesClassAccounts_ProductionSales.Properties.ValueMember = "Code"
            Me.SearchableComboBoxGLSalesClassAccounts_ProductionSales.Properties.View = Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales
            Me.SearchableComboBoxGLSalesClassAccounts_ProductionSales.SecurityEnabled = True
            Me.SearchableComboBoxGLSalesClassAccounts_ProductionSales.SelectedValue = Nothing
            Me.SearchableComboBoxGLSalesClassAccounts_ProductionSales.Size = New System.Drawing.Size(277, 20)
            Me.SearchableComboBoxGLSalesClassAccounts_ProductionSales.TabIndex = 1
            '
            'SearchableComboBoxViewGLSalesClassAccounts_ProductionSales
            '
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales.AFActiveFilterString = ""
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales.DataSourceClearing = False
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales.EnableDisabledRows = False
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales.Name = "SearchableComboBoxViewGLSalesClassAccounts_ProductionSales"
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales.RunStandardValidation = True
            '
            'CheckBoxForm_ReplaceOfficeSegment
            '
            Me.CheckBoxForm_ReplaceOfficeSegment.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxForm_ReplaceOfficeSegment.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_ReplaceOfficeSegment.CheckValue = 0
            Me.CheckBoxForm_ReplaceOfficeSegment.CheckValueChecked = 1
            Me.CheckBoxForm_ReplaceOfficeSegment.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_ReplaceOfficeSegment.CheckValueUnchecked = 0
            Me.CheckBoxForm_ReplaceOfficeSegment.ChildControls = CType(resources.GetObject("CheckBoxForm_ReplaceOfficeSegment.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_ReplaceOfficeSegment.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_ReplaceOfficeSegment.Location = New System.Drawing.Point(12, 419)
            Me.CheckBoxForm_ReplaceOfficeSegment.Name = "CheckBoxForm_ReplaceOfficeSegment"
            Me.CheckBoxForm_ReplaceOfficeSegment.OldestSibling = Nothing
            Me.CheckBoxForm_ReplaceOfficeSegment.SecurityEnabled = True
            Me.CheckBoxForm_ReplaceOfficeSegment.SiblingControls = CType(resources.GetObject("CheckBoxForm_ReplaceOfficeSegment.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_ReplaceOfficeSegment.Size = New System.Drawing.Size(250, 20)
            Me.CheckBoxForm_ReplaceOfficeSegment.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_ReplaceOfficeSegment.TabIndex = 6
            Me.CheckBoxForm_ReplaceOfficeSegment.TabOnEnter = True
            Me.CheckBoxForm_ReplaceOfficeSegment.Text = "Replace Office Segment in GL Accounts"
            '
            'CopyOfficeSalesClassGLAccountsDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(657, 451)
            Me.Controls.Add(Me.CheckBoxForm_ReplaceOfficeSegment)
            Me.Controls.Add(Me.GroupBoxForm_GLSalesClassFunctionAccounts)
            Me.Controls.Add(Me.GroupBoxForm_GLSalesClassAccounts)
            Me.Controls.Add(Me.ComboBoxForm_Office)
            Me.Controls.Add(Me.ComboBoxForm_SalesClass)
            Me.Controls.Add(Me.LabelForm_CopyUsingSalesClass)
            Me.Controls.Add(Me.LabelForm_CopyUsingOffice)
            Me.Controls.Add(Me.ButtonForm_Copy)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "CopyOfficeSalesClassGLAccountsDialog"
            Me.Text = "Office - Copy Sales Class GL Accounts"
            CType(Me.GroupBoxForm_GLSalesClassFunctionAccounts, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxForm_GLSalesClassFunctionAccounts.ResumeLayout(False)
            CType(Me.GroupBoxForm_GLSalesClassAccounts, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxForm_GLSalesClassAccounts.ResumeLayout(False)
            CType(Me.SearchableComboBoxGLSalesClassAccounts_MediaSales.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewGLSalesClassAccounts_MediaSales, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxGLSalesClassAccounts_MediaCOS.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewGLSalesClassAccounts_MediaCOS, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxGLSalesClassAccounts_ProductionCOS.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxGLSalesClassAccounts_ProductionSales.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewGLSalesClassAccounts_ProductionSales, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_CopyUsingOffice As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ButtonForm_Copy As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ComboBoxForm_Office As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxForm_SalesClass As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_CopyUsingSalesClass As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxForm_GLSalesClassFunctionAccounts As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents DataGridViewGLSalesClassFunctionAccounts_GLSCFA As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents GroupBoxForm_GLSalesClassAccounts As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents LabelGLSalesClassAccounts_MediaCOS As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelGLSalesClassAccounts_MediaSales As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelGLSalesClassAccounts_ProductionCOS As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelGLSalesClassAccounts_ProductionSales As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxGLSalesClassAccounts_ProductionSales As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewGLSalesClassAccounts_ProductionSales As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxGLSalesClassAccounts_MediaCOS As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewGLSalesClassAccounts_MediaCOS As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxGLSalesClassAccounts_MediaSales As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewGLSalesClassAccounts_MediaSales As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxGLSalesClassAccounts_ProductionCOS As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewGLSalesClassAccounts_ProductionCOS As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents CheckBoxForm_ReplaceOfficeSegment As WinForm.Presentation.Controls.CheckBox
    End Class

End Namespace