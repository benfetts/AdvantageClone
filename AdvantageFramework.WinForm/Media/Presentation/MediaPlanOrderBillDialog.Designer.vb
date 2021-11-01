Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class MediaPlanOrderBillDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaPlanOrderBillDialog))
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_EndDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_StartDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_GroupingOptions = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxOrders_Grouping = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.DateEditForm_EndDate = New AdvantageFramework.WinForm.Presentation.Controls.DateEdit()
            Me.DateEditForm_StartDate = New AdvantageFramework.WinForm.Presentation.Controls.DateEdit()
            Me.PanelForm_CreateOrderOptions = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.LabelForm_CreateOrderOptions = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DataGridViewForm_DetailsLevelLines = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.CheckBoxCreateOrderOptions_AlwaysAddToCurrentOrder = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxCreateOrderOptions_Default = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxCreateOrderOptions_NewOrderLineForEveryPeriod = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            CType(Me.DateEditForm_EndDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateEditForm_EndDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateEditForm_StartDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateEditForm_StartDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PanelForm_CreateOrderOptions, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_CreateOrderOptions.SuspendLayout()
            Me.SuspendLayout()
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(743, 474)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 10
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(662, 474)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 9
            Me.ButtonForm_OK.Text = "OK"
            '
            'LabelForm_EndDate
            '
            Me.LabelForm_EndDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_EndDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_EndDate.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_EndDate.Name = "LabelForm_EndDate"
            Me.LabelForm_EndDate.Size = New System.Drawing.Size(103, 20)
            Me.LabelForm_EndDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_EndDate.TabIndex = 2
            Me.LabelForm_EndDate.Text = "End Date:"
            '
            'LabelForm_StartDate
            '
            Me.LabelForm_StartDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_StartDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_StartDate.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_StartDate.Name = "LabelForm_StartDate"
            Me.LabelForm_StartDate.Size = New System.Drawing.Size(103, 20)
            Me.LabelForm_StartDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_StartDate.TabIndex = 0
            Me.LabelForm_StartDate.Text = "Start Date:"
            '
            'LabelForm_GroupingOptions
            '
            Me.LabelForm_GroupingOptions.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_GroupingOptions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_GroupingOptions.Location = New System.Drawing.Point(12, 64)
            Me.LabelForm_GroupingOptions.Name = "LabelForm_GroupingOptions"
            Me.LabelForm_GroupingOptions.Size = New System.Drawing.Size(103, 20)
            Me.LabelForm_GroupingOptions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_GroupingOptions.TabIndex = 4
            Me.LabelForm_GroupingOptions.Text = "Grouping Options:"
            '
            'ComboBoxOrders_Grouping
            '
            Me.ComboBoxOrders_Grouping.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxOrders_Grouping.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxOrders_Grouping.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxOrders_Grouping.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxOrders_Grouping.AutoFindItemInDataSource = False
            Me.ComboBoxOrders_Grouping.AutoSelectSingleItemDatasource = False
            Me.ComboBoxOrders_Grouping.BookmarkingEnabled = False
            Me.ComboBoxOrders_Grouping.ClientCode = ""
            Me.ComboBoxOrders_Grouping.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumObjects
            Me.ComboBoxOrders_Grouping.DisableMouseWheel = False
            Me.ComboBoxOrders_Grouping.DisplayMember = "Description"
            Me.ComboBoxOrders_Grouping.DisplayName = ""
            Me.ComboBoxOrders_Grouping.DivisionCode = ""
            Me.ComboBoxOrders_Grouping.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxOrders_Grouping.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxOrders_Grouping.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxOrders_Grouping.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxOrders_Grouping.FocusHighlightEnabled = True
            Me.ComboBoxOrders_Grouping.FormattingEnabled = True
            Me.ComboBoxOrders_Grouping.ItemHeight = 14
            Me.ComboBoxOrders_Grouping.Location = New System.Drawing.Point(121, 64)
            Me.ComboBoxOrders_Grouping.Name = "ComboBoxOrders_Grouping"
            Me.ComboBoxOrders_Grouping.ReadOnly = False
            Me.ComboBoxOrders_Grouping.SecurityEnabled = True
            Me.ComboBoxOrders_Grouping.Size = New System.Drawing.Size(697, 20)
            Me.ComboBoxOrders_Grouping.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxOrders_Grouping.TabIndex = 5
            Me.ComboBoxOrders_Grouping.TabOnEnter = True
            Me.ComboBoxOrders_Grouping.ValueMember = "Code"
            Me.ComboBoxOrders_Grouping.WatermarkText = "Select"
            '
            'DateEditForm_EndDate
            '
            Me.DateEditForm_EndDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DateEditForm_EndDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateEdit.Type.[Default]
            Me.DateEditForm_EndDate.DisplayName = ""
            Me.DateEditForm_EndDate.EditValue = Nothing
            Me.DateEditForm_EndDate.Location = New System.Drawing.Point(121, 38)
            Me.DateEditForm_EndDate.Name = "DateEditForm_EndDate"
            Me.DateEditForm_EndDate.Properties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.[False]
            Me.DateEditForm_EndDate.Properties.AllowMouseWheel = False
            Me.DateEditForm_EndDate.Properties.Appearance.BackColor = System.Drawing.Color.White
            Me.DateEditForm_EndDate.Properties.Appearance.Options.UseBackColor = True
            Me.DateEditForm_EndDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.DateEditForm_EndDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.DateEditForm_EndDate.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista
            Me.DateEditForm_EndDate.Properties.Mask.EditMask = ""
            Me.DateEditForm_EndDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
            Me.DateEditForm_EndDate.Properties.MaxValue = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateEditForm_EndDate.Properties.MinValue = New Date(1900, 1, 1, 0, 0, 0, 0)
            Me.DateEditForm_EndDate.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[True]
            Me.DateEditForm_EndDate.Size = New System.Drawing.Size(697, 20)
            Me.DateEditForm_EndDate.TabIndex = 3
            Me.DateEditForm_EndDate.TabOnEnter = True
            Me.DateEditForm_EndDate.Tag = "9/2/2015"
            '
            'DateEditForm_StartDate
            '
            Me.DateEditForm_StartDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DateEditForm_StartDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateEdit.Type.[Default]
            Me.DateEditForm_StartDate.DisplayName = ""
            Me.DateEditForm_StartDate.EditValue = Nothing
            Me.DateEditForm_StartDate.Location = New System.Drawing.Point(121, 12)
            Me.DateEditForm_StartDate.Name = "DateEditForm_StartDate"
            Me.DateEditForm_StartDate.Properties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.[False]
            Me.DateEditForm_StartDate.Properties.AllowMouseWheel = False
            Me.DateEditForm_StartDate.Properties.Appearance.BackColor = System.Drawing.Color.White
            Me.DateEditForm_StartDate.Properties.Appearance.Options.UseBackColor = True
            Me.DateEditForm_StartDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.DateEditForm_StartDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.DateEditForm_StartDate.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista
            Me.DateEditForm_StartDate.Properties.Mask.EditMask = ""
            Me.DateEditForm_StartDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
            Me.DateEditForm_StartDate.Properties.MaxValue = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateEditForm_StartDate.Properties.MinValue = New Date(1900, 1, 1, 0, 0, 0, 0)
            Me.DateEditForm_StartDate.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[True]
            Me.DateEditForm_StartDate.Size = New System.Drawing.Size(697, 20)
            Me.DateEditForm_StartDate.TabIndex = 1
            Me.DateEditForm_StartDate.TabOnEnter = True
            Me.DateEditForm_StartDate.Tag = "9/2/2015"
            '
            'PanelForm_CreateOrderOptions
            '
            Me.PanelForm_CreateOrderOptions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PanelForm_CreateOrderOptions.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelForm_CreateOrderOptions.Appearance.Options.UseBackColor = True
            Me.PanelForm_CreateOrderOptions.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelForm_CreateOrderOptions.Controls.Add(Me.CheckBoxCreateOrderOptions_NewOrderLineForEveryPeriod)
            Me.PanelForm_CreateOrderOptions.Controls.Add(Me.CheckBoxCreateOrderOptions_AlwaysAddToCurrentOrder)
            Me.PanelForm_CreateOrderOptions.Controls.Add(Me.CheckBoxCreateOrderOptions_Default)
            Me.PanelForm_CreateOrderOptions.Location = New System.Drawing.Point(12, 116)
            Me.PanelForm_CreateOrderOptions.Name = "PanelForm_CreateOrderOptions"
            Me.PanelForm_CreateOrderOptions.Size = New System.Drawing.Size(806, 77)
            Me.PanelForm_CreateOrderOptions.TabIndex = 7
            '
            'LabelForm_CreateOrderOptions
            '
            Me.LabelForm_CreateOrderOptions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_CreateOrderOptions.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_CreateOrderOptions.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_CreateOrderOptions.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelForm_CreateOrderOptions.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelForm_CreateOrderOptions.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_CreateOrderOptions.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_CreateOrderOptions.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_CreateOrderOptions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_CreateOrderOptions.Location = New System.Drawing.Point(12, 90)
            Me.LabelForm_CreateOrderOptions.Name = "LabelForm_CreateOrderOptions"
            Me.LabelForm_CreateOrderOptions.Size = New System.Drawing.Size(806, 20)
            Me.LabelForm_CreateOrderOptions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_CreateOrderOptions.TabIndex = 6
            Me.LabelForm_CreateOrderOptions.Text = "Create Order Option"
            '
            'DataGridViewForm_DetailsLevelLines
            '
            Me.DataGridViewForm_DetailsLevelLines.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewForm_DetailsLevelLines.AllowDragAndDrop = False
            Me.DataGridViewForm_DetailsLevelLines.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_DetailsLevelLines.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_DetailsLevelLines.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_DetailsLevelLines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_DetailsLevelLines.AutoFilterLookupColumns = False
            Me.DataGridViewForm_DetailsLevelLines.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_DetailsLevelLines.AutoUpdateViewCaption = True
            Me.DataGridViewForm_DetailsLevelLines.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewForm_DetailsLevelLines.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_DetailsLevelLines.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_DetailsLevelLines.ItemDescription = "Level/Line(s)"
            Me.DataGridViewForm_DetailsLevelLines.Location = New System.Drawing.Point(12, 199)
            Me.DataGridViewForm_DetailsLevelLines.MultiSelect = True
            Me.DataGridViewForm_DetailsLevelLines.Name = "DataGridViewForm_DetailsLevelLines"
            Me.DataGridViewForm_DetailsLevelLines.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_DetailsLevelLines.RunStandardValidation = True
            Me.DataGridViewForm_DetailsLevelLines.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_DetailsLevelLines.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_DetailsLevelLines.Size = New System.Drawing.Size(806, 269)
            Me.DataGridViewForm_DetailsLevelLines.TabIndex = 8
            Me.DataGridViewForm_DetailsLevelLines.UseEmbeddedNavigator = False
            Me.DataGridViewForm_DetailsLevelLines.ViewCaptionHeight = -1
            '
            'CheckBoxCreateOrderOptions_AlwaysAddToCurrentOrder
            '
            Me.CheckBoxCreateOrderOptions_AlwaysAddToCurrentOrder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxCreateOrderOptions_AlwaysAddToCurrentOrder.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxCreateOrderOptions_AlwaysAddToCurrentOrder.CheckValue = 0
            Me.CheckBoxCreateOrderOptions_AlwaysAddToCurrentOrder.CheckValueChecked = 1
            Me.CheckBoxCreateOrderOptions_AlwaysAddToCurrentOrder.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxCreateOrderOptions_AlwaysAddToCurrentOrder.CheckValueUnchecked = 0
            Me.CheckBoxCreateOrderOptions_AlwaysAddToCurrentOrder.ChildControls = CType(resources.GetObject("CheckBoxCreateOrderOptions_AlwaysAddToCurrentOrder.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxCreateOrderOptions_AlwaysAddToCurrentOrder.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxCreateOrderOptions_AlwaysAddToCurrentOrder.Location = New System.Drawing.Point(0, 0)
            Me.CheckBoxCreateOrderOptions_AlwaysAddToCurrentOrder.Name = "CheckBoxCreateOrderOptions_AlwaysAddToCurrentOrder"
            Me.CheckBoxCreateOrderOptions_AlwaysAddToCurrentOrder.OldestSibling = Nothing
            Me.CheckBoxCreateOrderOptions_AlwaysAddToCurrentOrder.SecurityEnabled = True
            Me.CheckBoxCreateOrderOptions_AlwaysAddToCurrentOrder.SiblingControls = CType(resources.GetObject("CheckBoxCreateOrderOptions_AlwaysAddToCurrentOrder.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxCreateOrderOptions_AlwaysAddToCurrentOrder.Size = New System.Drawing.Size(806, 20)
            Me.CheckBoxCreateOrderOptions_AlwaysAddToCurrentOrder.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxCreateOrderOptions_AlwaysAddToCurrentOrder.TabIndex = 11
            Me.CheckBoxCreateOrderOptions_AlwaysAddToCurrentOrder.TabOnEnter = True
            Me.CheckBoxCreateOrderOptions_AlwaysAddToCurrentOrder.Text = "Add new lines to existing order"
            '
            'CheckBoxCreateOrderOptions_Default
            '
            Me.CheckBoxCreateOrderOptions_Default.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxCreateOrderOptions_Default.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxCreateOrderOptions_Default.Checked = True
            Me.CheckBoxCreateOrderOptions_Default.CheckState = System.Windows.Forms.CheckState.Checked
            Me.CheckBoxCreateOrderOptions_Default.CheckValue = 1
            Me.CheckBoxCreateOrderOptions_Default.CheckValueChecked = 1
            Me.CheckBoxCreateOrderOptions_Default.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxCreateOrderOptions_Default.CheckValueUnchecked = 0
            Me.CheckBoxCreateOrderOptions_Default.ChildControls = CType(resources.GetObject("CheckBoxCreateOrderOptions_Default.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxCreateOrderOptions_Default.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxCreateOrderOptions_Default.Location = New System.Drawing.Point(0, 26)
            Me.CheckBoxCreateOrderOptions_Default.Name = "CheckBoxCreateOrderOptions_Default"
            Me.CheckBoxCreateOrderOptions_Default.OldestSibling = Nothing
            Me.CheckBoxCreateOrderOptions_Default.SecurityEnabled = True
            Me.CheckBoxCreateOrderOptions_Default.SiblingControls = CType(resources.GetObject("CheckBoxCreateOrderOptions_Default.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxCreateOrderOptions_Default.Size = New System.Drawing.Size(806, 20)
            Me.CheckBoxCreateOrderOptions_Default.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxCreateOrderOptions_Default.TabIndex = 12
            Me.CheckBoxCreateOrderOptions_Default.TabOnEnter = True
            Me.CheckBoxCreateOrderOptions_Default.Text = "Create one order per Market/Vendor"
            Me.CheckBoxCreateOrderOptions_Default.Visible = False
            '
            'CheckBoxCreateOrderOptions_NewOrderLineForEveryPeriod
            '
            Me.CheckBoxCreateOrderOptions_NewOrderLineForEveryPeriod.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxCreateOrderOptions_NewOrderLineForEveryPeriod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxCreateOrderOptions_NewOrderLineForEveryPeriod.CheckValue = 0
            Me.CheckBoxCreateOrderOptions_NewOrderLineForEveryPeriod.CheckValueChecked = 1
            Me.CheckBoxCreateOrderOptions_NewOrderLineForEveryPeriod.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxCreateOrderOptions_NewOrderLineForEveryPeriod.CheckValueUnchecked = 0
            Me.CheckBoxCreateOrderOptions_NewOrderLineForEveryPeriod.ChildControls = CType(resources.GetObject("CheckBoxCreateOrderOptions_NewOrderLineForEveryPeriod.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxCreateOrderOptions_NewOrderLineForEveryPeriod.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxCreateOrderOptions_NewOrderLineForEveryPeriod.Location = New System.Drawing.Point(0, 52)
            Me.CheckBoxCreateOrderOptions_NewOrderLineForEveryPeriod.Name = "CheckBoxCreateOrderOptions_NewOrderLineForEveryPeriod"
            Me.CheckBoxCreateOrderOptions_NewOrderLineForEveryPeriod.OldestSibling = Nothing
            Me.CheckBoxCreateOrderOptions_NewOrderLineForEveryPeriod.SecurityEnabled = True
            Me.CheckBoxCreateOrderOptions_NewOrderLineForEveryPeriod.SiblingControls = CType(resources.GetObject("CheckBoxCreateOrderOptions_NewOrderLineForEveryPeriod.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxCreateOrderOptions_NewOrderLineForEveryPeriod.Size = New System.Drawing.Size(806, 20)
            Me.CheckBoxCreateOrderOptions_NewOrderLineForEveryPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxCreateOrderOptions_NewOrderLineForEveryPeriod.TabIndex = 13
            Me.CheckBoxCreateOrderOptions_NewOrderLineForEveryPeriod.TabOnEnter = True
            Me.CheckBoxCreateOrderOptions_NewOrderLineForEveryPeriod.Text = "New order/line for every period"
            Me.CheckBoxCreateOrderOptions_NewOrderLineForEveryPeriod.Visible = False
            '
            'MediaPlanOrderBillDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(830, 506)
            Me.Controls.Add(Me.DataGridViewForm_DetailsLevelLines)
            Me.Controls.Add(Me.LabelForm_CreateOrderOptions)
            Me.Controls.Add(Me.PanelForm_CreateOrderOptions)
            Me.Controls.Add(Me.DateEditForm_EndDate)
            Me.Controls.Add(Me.DateEditForm_StartDate)
            Me.Controls.Add(Me.ComboBoxOrders_Grouping)
            Me.Controls.Add(Me.LabelForm_GroupingOptions)
            Me.Controls.Add(Me.LabelForm_EndDate)
            Me.Controls.Add(Me.LabelForm_StartDate)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaPlanOrderBillDialog"
            Me.Text = "Create Order Criteria"
            CType(Me.DateEditForm_EndDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateEditForm_EndDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateEditForm_StartDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateEditForm_StartDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PanelForm_CreateOrderOptions, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_CreateOrderOptions.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_EndDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_StartDate As AdvantageFramework.WinForm.Presentation.Controls.Label
		Friend WithEvents LabelForm_GroupingOptions As AdvantageFramework.WinForm.Presentation.Controls.Label
		Friend WithEvents ComboBoxOrders_Grouping As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
		Friend WithEvents DateEditForm_EndDate As AdvantageFramework.WinForm.Presentation.Controls.DateEdit
		Friend WithEvents DateEditForm_StartDate As AdvantageFramework.WinForm.Presentation.Controls.DateEdit
        Friend WithEvents PanelForm_CreateOrderOptions As WinForm.Presentation.Controls.Panel
        Friend WithEvents LabelForm_CreateOrderOptions As WinForm.Presentation.Controls.Label
        Friend WithEvents DataGridViewForm_DetailsLevelLines As WinForm.Presentation.Controls.DataGridView
        Friend WithEvents CheckBoxCreateOrderOptions_AlwaysAddToCurrentOrder As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxCreateOrderOptions_Default As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxCreateOrderOptions_NewOrderLineForEveryPeriod As WinForm.Presentation.Controls.CheckBox
    End Class

End Namespace