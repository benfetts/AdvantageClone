Namespace Desktop.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class AlertAssignmentEditDialog
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseRibbonForm

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AlertAssignmentEditDialog))
            Me.GroupBoxForm_AlertLevel = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.LabelAlertLevel_ItemFilter = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxAlertLevel_ItemFilter = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.SearchableComboBoxAlertLevel_Item = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxAlertLevel_ItemView = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelAlertLevel_Item = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxAlertLevel_IsAssignment = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelAlertLevel_Level = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxAlertLevel_Level = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.GroupBoxForm_AlertAssignment = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.ComboBoxAlertAssignment_AssignTo = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ComboBoxAlertAssignment_State = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelAlertAssignment_AssignTo = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelAlertAssignment_State = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelAlertAssignment_Template = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxAlertAssignment_Template = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_Details = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Category = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_Category = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.CheckBoxForm_ExcludeAttachmentFromEmail = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelForm_Priority = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_Priority = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_DueDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DateTimePickerForm_DueDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.DateTimePickerForm_DueTime = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelForm_DueTime = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Subject = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxForm_Subject = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Send = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Cancel = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Clear = New DevComponents.DotNetBar.ButtonItem()
            Me.RichEditForm_Description = New AdvantageFramework.WinForm.Presentation.Controls.RichEditControl()
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Form.SuspendLayout()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxForm_AlertLevel, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxForm_AlertLevel.SuspendLayout()
            CType(Me.SearchableComboBoxAlertLevel_Item.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxAlertLevel_ItemView, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxForm_AlertAssignment, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxForm_AlertAssignment.SuspendLayout()
            CType(Me.DateTimePickerForm_DueDate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerForm_DueTime, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'RibbonControlForm_MainRibbon
            '
            '
            '
            '
            Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonControlForm_MainRibbon.Margin = New System.Windows.Forms.Padding(4)
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(771, 154)
            Me.RibbonControlForm_MainRibbon.SystemText.MaximizeRibbonText = "&Maximize the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.QatAddItemText = "&Add to Quick Access Toolbar"
            Me.RibbonControlForm_MainRibbon.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>"
            Me.RibbonControlForm_MainRibbon.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar..."
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogAddButton = "&Add >>"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogCancelButton = "Cancel"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogCaption = "Customize Quick Access Toolbar"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogCategoriesLabel = "&Choose commands from:"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogOkButton = "OK"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogRemoveButton = "&Remove"
            Me.RibbonControlForm_MainRibbon.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar"
            Me.RibbonControlForm_MainRibbon.TabIndex = 0
            Me.RibbonControlForm_MainRibbon.Controls.SetChildIndex(Me.RibbonPanelFile_FilePanel, 0)
            '
            'RibbonPanelFile_FilePanel
            '
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 57)
            Me.RibbonPanelFile_FilePanel.Margin = New System.Windows.Forms.Padding(4)
            Me.RibbonPanelFile_FilePanel.Padding = New System.Windows.Forms.Padding(4, 0, 4, 4)
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(771, 95)
            '
            '
            '
            Me.RibbonPanelFile_FilePanel.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonPanelFile_FilePanel.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonPanelFile_FilePanel.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonPanelFile_FilePanel.TabIndex = 0
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarFilePanel_System, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Actions, 0)
            '
            'RibbonBarFilePanel_System
            '
            '
            '
            '
            Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.BorderColor = System.Drawing.Color.DarkGray
            Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.BorderColor2 = System.Drawing.Color.DarkGray
            Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.BorderRightWidth = 2
            Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_System.BackgroundStyle.BorderColor = System.Drawing.Color.DarkGray
            Me.RibbonBarFilePanel_System.BackgroundStyle.BorderColor2 = System.Drawing.Color.DarkGray
            Me.RibbonBarFilePanel_System.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.RibbonBarFilePanel_System.BackgroundStyle.BorderRightWidth = 2
            Me.RibbonBarFilePanel_System.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFilePanel_System.Location = New System.Drawing.Point(4, 0)
            Me.RibbonBarFilePanel_System.Margin = New System.Windows.Forms.Padding(4)
            Me.RibbonBarFilePanel_System.Size = New System.Drawing.Size(64, 91)
            '
            '
            '
            Me.RibbonBarFilePanel_System.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_System.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemSystem_Close
            '
            Me.ButtonItemSystem_Close.Image = CType(resources.GetObject("ButtonItemSystem_Close.Image"), System.Drawing.Image)
            '
            'PanelForm_Form
            '
            Me.PanelForm_Form.Controls.Add(Me.RichEditForm_Description)
            Me.PanelForm_Form.Controls.Add(Me.GroupBoxForm_AlertLevel)
            Me.PanelForm_Form.Controls.Add(Me.TextBoxForm_Subject)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_Subject)
            Me.PanelForm_Form.Controls.Add(Me.DateTimePickerForm_DueTime)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_DueTime)
            Me.PanelForm_Form.Controls.Add(Me.DateTimePickerForm_DueDate)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_DueDate)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_Priority)
            Me.PanelForm_Form.Controls.Add(Me.ComboBoxForm_Priority)
            Me.PanelForm_Form.Controls.Add(Me.CheckBoxForm_ExcludeAttachmentFromEmail)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_Category)
            Me.PanelForm_Form.Controls.Add(Me.ComboBoxForm_Category)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_Details)
            Me.PanelForm_Form.Controls.Add(Me.GroupBoxForm_AlertAssignment)
            Me.PanelForm_Form.Size = New System.Drawing.Size(771, 388)
            '
            'BarForm_StatusBar
            '
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 543)
            Me.BarForm_StatusBar.Margin = New System.Windows.Forms.Padding(4)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(771, 18)
            '
            'GroupBoxForm_AlertLevel
            '
            Me.GroupBoxForm_AlertLevel.Controls.Add(Me.LabelAlertLevel_ItemFilter)
            Me.GroupBoxForm_AlertLevel.Controls.Add(Me.ComboBoxAlertLevel_ItemFilter)
            Me.GroupBoxForm_AlertLevel.Controls.Add(Me.SearchableComboBoxAlertLevel_Item)
            Me.GroupBoxForm_AlertLevel.Controls.Add(Me.LabelAlertLevel_Item)
            Me.GroupBoxForm_AlertLevel.Controls.Add(Me.CheckBoxAlertLevel_IsAssignment)
            Me.GroupBoxForm_AlertLevel.Controls.Add(Me.LabelAlertLevel_Level)
            Me.GroupBoxForm_AlertLevel.Controls.Add(Me.ComboBoxAlertLevel_Level)
            Me.GroupBoxForm_AlertLevel.Location = New System.Drawing.Point(3, 3)
            Me.GroupBoxForm_AlertLevel.Name = "GroupBoxForm_AlertLevel"
            Me.GroupBoxForm_AlertLevel.Size = New System.Drawing.Size(327, 101)
            Me.GroupBoxForm_AlertLevel.TabIndex = 1
            Me.GroupBoxForm_AlertLevel.Text = "Alert Level"
            '
            'LabelAlertLevel_ItemFilter
            '
            Me.LabelAlertLevel_ItemFilter.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAlertLevel_ItemFilter.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAlertLevel_ItemFilter.Location = New System.Drawing.Point(5, 50)
            Me.LabelAlertLevel_ItemFilter.Name = "LabelAlertLevel_ItemFilter"
            Me.LabelAlertLevel_ItemFilter.Size = New System.Drawing.Size(55, 20)
            Me.LabelAlertLevel_ItemFilter.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAlertLevel_ItemFilter.TabIndex = 3
            Me.LabelAlertLevel_ItemFilter.Text = "Item Filter:"
            '
            'ComboBoxAlertLevel_ItemFilter
            '
            Me.ComboBoxAlertLevel_ItemFilter.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxAlertLevel_ItemFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxAlertLevel_ItemFilter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxAlertLevel_ItemFilter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxAlertLevel_ItemFilter.AutoFindItemInDataSource = False
            Me.ComboBoxAlertLevel_ItemFilter.AutoSelectSingleItemDatasource = False
            Me.ComboBoxAlertLevel_ItemFilter.BookmarkingEnabled = False
            Me.ComboBoxAlertLevel_ItemFilter.ClientCode = ""
            Me.ComboBoxAlertLevel_ItemFilter.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.[Default]
            Me.ComboBoxAlertLevel_ItemFilter.DisableMouseWheel = False
            Me.ComboBoxAlertLevel_ItemFilter.DisplayName = ""
            Me.ComboBoxAlertLevel_ItemFilter.DivisionCode = ""
            Me.ComboBoxAlertLevel_ItemFilter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxAlertLevel_ItemFilter.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxAlertLevel_ItemFilter.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxAlertLevel_ItemFilter.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxAlertLevel_ItemFilter.FocusHighlightEnabled = True
            Me.ComboBoxAlertLevel_ItemFilter.FormattingEnabled = True
            Me.ComboBoxAlertLevel_ItemFilter.ItemHeight = 14
            Me.ComboBoxAlertLevel_ItemFilter.Location = New System.Drawing.Point(66, 50)
            Me.ComboBoxAlertLevel_ItemFilter.Name = "ComboBoxAlertLevel_ItemFilter"
            Me.ComboBoxAlertLevel_ItemFilter.PreventEnterBeep = False
            Me.ComboBoxAlertLevel_ItemFilter.ReadOnly = False
            Me.ComboBoxAlertLevel_ItemFilter.SecurityEnabled = True
            Me.ComboBoxAlertLevel_ItemFilter.Size = New System.Drawing.Size(256, 20)
            Me.ComboBoxAlertLevel_ItemFilter.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxAlertLevel_ItemFilter.TabIndex = 4
            '
            'SearchableComboBoxAlertLevel_Item
            '
            Me.SearchableComboBoxAlertLevel_Item.ActiveFilterString = ""
            Me.SearchableComboBoxAlertLevel_Item.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxAlertLevel_Item.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxAlertLevel_Item.AutoFillMode = False
            Me.SearchableComboBoxAlertLevel_Item.BookmarkingEnabled = False
            Me.SearchableComboBoxAlertLevel_Item.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.[Default]
            Me.SearchableComboBoxAlertLevel_Item.DataSource = Nothing
            Me.SearchableComboBoxAlertLevel_Item.DisableMouseWheel = False
            Me.SearchableComboBoxAlertLevel_Item.DisplayName = ""
            Me.SearchableComboBoxAlertLevel_Item.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxAlertLevel_Item.Location = New System.Drawing.Point(66, 76)
            Me.SearchableComboBoxAlertLevel_Item.Name = "SearchableComboBoxAlertLevel_Item"
            Me.SearchableComboBoxAlertLevel_Item.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxAlertLevel_Item.Properties.NullText = ""
            Me.SearchableComboBoxAlertLevel_Item.Properties.ShowClearButton = False
            Me.SearchableComboBoxAlertLevel_Item.Properties.View = Me.SearchableComboBoxAlertLevel_ItemView
            Me.SearchableComboBoxAlertLevel_Item.SecurityEnabled = True
            Me.SearchableComboBoxAlertLevel_Item.SelectedValue = Nothing
            Me.SearchableComboBoxAlertLevel_Item.Size = New System.Drawing.Size(256, 20)
            Me.SearchableComboBoxAlertLevel_Item.TabIndex = 6
            '
            'SearchableComboBoxAlertLevel_ItemView
            '
            Me.SearchableComboBoxAlertLevel_ItemView.AFActiveFilterString = ""
            Me.SearchableComboBoxAlertLevel_ItemView.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxAlertLevel_ItemView.AutoFilterLookupColumns = False
            Me.SearchableComboBoxAlertLevel_ItemView.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxAlertLevel_ItemView.DataSourceClearing = False
            Me.SearchableComboBoxAlertLevel_ItemView.EnableDisabledRows = False
            Me.SearchableComboBoxAlertLevel_ItemView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxAlertLevel_ItemView.Name = "SearchableComboBoxAlertLevel_ItemView"
            Me.SearchableComboBoxAlertLevel_ItemView.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxAlertLevel_ItemView.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxAlertLevel_ItemView.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxAlertLevel_ItemView.RunStandardValidation = True
            '
            'LabelAlertLevel_Item
            '
            Me.LabelAlertLevel_Item.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAlertLevel_Item.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAlertLevel_Item.Location = New System.Drawing.Point(5, 76)
            Me.LabelAlertLevel_Item.Name = "LabelAlertLevel_Item"
            Me.LabelAlertLevel_Item.Size = New System.Drawing.Size(55, 20)
            Me.LabelAlertLevel_Item.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAlertLevel_Item.TabIndex = 5
            Me.LabelAlertLevel_Item.Text = "Item:"
            '
            'CheckBoxAlertLevel_IsAssignment
            '
            Me.CheckBoxAlertLevel_IsAssignment.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxAlertLevel_IsAssignment.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxAlertLevel_IsAssignment.CheckValue = 0
            Me.CheckBoxAlertLevel_IsAssignment.CheckValueChecked = 1
            Me.CheckBoxAlertLevel_IsAssignment.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxAlertLevel_IsAssignment.CheckValueUnchecked = 0
            Me.CheckBoxAlertLevel_IsAssignment.ChildControls = CType(resources.GetObject("CheckBoxAlertLevel_IsAssignment.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAlertLevel_IsAssignment.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxAlertLevel_IsAssignment.Location = New System.Drawing.Point(242, 24)
            Me.CheckBoxAlertLevel_IsAssignment.Name = "CheckBoxAlertLevel_IsAssignment"
            Me.CheckBoxAlertLevel_IsAssignment.OldestSibling = Nothing
            Me.CheckBoxAlertLevel_IsAssignment.SecurityEnabled = True
            Me.CheckBoxAlertLevel_IsAssignment.SiblingControls = CType(resources.GetObject("CheckBoxAlertLevel_IsAssignment.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxAlertLevel_IsAssignment.Size = New System.Drawing.Size(80, 20)
            Me.CheckBoxAlertLevel_IsAssignment.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxAlertLevel_IsAssignment.TabIndex = 2
            Me.CheckBoxAlertLevel_IsAssignment.Text = "Assignment"
            '
            'LabelAlertLevel_Level
            '
            Me.LabelAlertLevel_Level.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAlertLevel_Level.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAlertLevel_Level.Location = New System.Drawing.Point(5, 24)
            Me.LabelAlertLevel_Level.Name = "LabelAlertLevel_Level"
            Me.LabelAlertLevel_Level.Size = New System.Drawing.Size(55, 20)
            Me.LabelAlertLevel_Level.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAlertLevel_Level.TabIndex = 0
            Me.LabelAlertLevel_Level.Text = "Level:"
            '
            'ComboBoxAlertLevel_Level
            '
            Me.ComboBoxAlertLevel_Level.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxAlertLevel_Level.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxAlertLevel_Level.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxAlertLevel_Level.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxAlertLevel_Level.AutoFindItemInDataSource = False
            Me.ComboBoxAlertLevel_Level.AutoSelectSingleItemDatasource = False
            Me.ComboBoxAlertLevel_Level.BookmarkingEnabled = False
            Me.ComboBoxAlertLevel_Level.ClientCode = ""
            Me.ComboBoxAlertLevel_Level.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumObjects
            Me.ComboBoxAlertLevel_Level.DisableMouseWheel = False
            Me.ComboBoxAlertLevel_Level.DisplayMember = "Description"
            Me.ComboBoxAlertLevel_Level.DisplayName = ""
            Me.ComboBoxAlertLevel_Level.DivisionCode = ""
            Me.ComboBoxAlertLevel_Level.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxAlertLevel_Level.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxAlertLevel_Level.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxAlertLevel_Level.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxAlertLevel_Level.FocusHighlightEnabled = True
            Me.ComboBoxAlertLevel_Level.FormattingEnabled = True
            Me.ComboBoxAlertLevel_Level.ItemHeight = 14
            Me.ComboBoxAlertLevel_Level.Location = New System.Drawing.Point(66, 24)
            Me.ComboBoxAlertLevel_Level.Name = "ComboBoxAlertLevel_Level"
            Me.ComboBoxAlertLevel_Level.PreventEnterBeep = False
            Me.ComboBoxAlertLevel_Level.ReadOnly = False
            Me.ComboBoxAlertLevel_Level.SecurityEnabled = True
            Me.ComboBoxAlertLevel_Level.Size = New System.Drawing.Size(170, 20)
            Me.ComboBoxAlertLevel_Level.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxAlertLevel_Level.TabIndex = 1
            Me.ComboBoxAlertLevel_Level.ValueMember = "Code"
            Me.ComboBoxAlertLevel_Level.WatermarkText = "Select"
            '
            'GroupBoxForm_AlertAssignment
            '
            Me.GroupBoxForm_AlertAssignment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxForm_AlertAssignment.Controls.Add(Me.ComboBoxAlertAssignment_AssignTo)
            Me.GroupBoxForm_AlertAssignment.Controls.Add(Me.ComboBoxAlertAssignment_State)
            Me.GroupBoxForm_AlertAssignment.Controls.Add(Me.LabelAlertAssignment_AssignTo)
            Me.GroupBoxForm_AlertAssignment.Controls.Add(Me.LabelAlertAssignment_State)
            Me.GroupBoxForm_AlertAssignment.Controls.Add(Me.LabelAlertAssignment_Template)
            Me.GroupBoxForm_AlertAssignment.Controls.Add(Me.ComboBoxAlertAssignment_Template)
            Me.GroupBoxForm_AlertAssignment.Location = New System.Drawing.Point(340, 4)
            Me.GroupBoxForm_AlertAssignment.Name = "GroupBoxForm_AlertAssignment"
            Me.GroupBoxForm_AlertAssignment.Size = New System.Drawing.Size(428, 101)
            Me.GroupBoxForm_AlertAssignment.TabIndex = 2
            Me.GroupBoxForm_AlertAssignment.Text = "Alert Assignment"
            '
            'ComboBoxAlertAssignment_AssignTo
            '
            Me.ComboBoxAlertAssignment_AssignTo.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxAlertAssignment_AssignTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxAlertAssignment_AssignTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxAlertAssignment_AssignTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxAlertAssignment_AssignTo.AutoFindItemInDataSource = False
            Me.ComboBoxAlertAssignment_AssignTo.AutoSelectSingleItemDatasource = False
            Me.ComboBoxAlertAssignment_AssignTo.BookmarkingEnabled = False
            Me.ComboBoxAlertAssignment_AssignTo.ClientCode = ""
            Me.ComboBoxAlertAssignment_AssignTo.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Employee
            Me.ComboBoxAlertAssignment_AssignTo.DisableMouseWheel = False
            Me.ComboBoxAlertAssignment_AssignTo.DisplayMember = "FullName"
            Me.ComboBoxAlertAssignment_AssignTo.DisplayName = ""
            Me.ComboBoxAlertAssignment_AssignTo.DivisionCode = ""
            Me.ComboBoxAlertAssignment_AssignTo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxAlertAssignment_AssignTo.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxAlertAssignment_AssignTo.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxAlertAssignment_AssignTo.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxAlertAssignment_AssignTo.FocusHighlightEnabled = True
            Me.ComboBoxAlertAssignment_AssignTo.FormattingEnabled = True
            Me.ComboBoxAlertAssignment_AssignTo.ItemHeight = 14
            Me.ComboBoxAlertAssignment_AssignTo.Location = New System.Drawing.Point(68, 76)
            Me.ComboBoxAlertAssignment_AssignTo.Name = "ComboBoxAlertAssignment_AssignTo"
            Me.ComboBoxAlertAssignment_AssignTo.PreventEnterBeep = False
            Me.ComboBoxAlertAssignment_AssignTo.ReadOnly = False
            Me.ComboBoxAlertAssignment_AssignTo.SecurityEnabled = True
            Me.ComboBoxAlertAssignment_AssignTo.Size = New System.Drawing.Size(355, 20)
            Me.ComboBoxAlertAssignment_AssignTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxAlertAssignment_AssignTo.TabIndex = 7
            Me.ComboBoxAlertAssignment_AssignTo.ValueMember = "Code"
            Me.ComboBoxAlertAssignment_AssignTo.WatermarkText = "Select Employee"
            '
            'ComboBoxAlertAssignment_State
            '
            Me.ComboBoxAlertAssignment_State.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxAlertAssignment_State.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxAlertAssignment_State.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxAlertAssignment_State.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxAlertAssignment_State.AutoFindItemInDataSource = False
            Me.ComboBoxAlertAssignment_State.AutoSelectSingleItemDatasource = False
            Me.ComboBoxAlertAssignment_State.BookmarkingEnabled = False
            Me.ComboBoxAlertAssignment_State.ClientCode = ""
            Me.ComboBoxAlertAssignment_State.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.AlertState
            Me.ComboBoxAlertAssignment_State.DisableMouseWheel = False
            Me.ComboBoxAlertAssignment_State.DisplayMember = "Name"
            Me.ComboBoxAlertAssignment_State.DisplayName = ""
            Me.ComboBoxAlertAssignment_State.DivisionCode = ""
            Me.ComboBoxAlertAssignment_State.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxAlertAssignment_State.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxAlertAssignment_State.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxAlertAssignment_State.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxAlertAssignment_State.FocusHighlightEnabled = True
            Me.ComboBoxAlertAssignment_State.FormattingEnabled = True
            Me.ComboBoxAlertAssignment_State.ItemHeight = 14
            Me.ComboBoxAlertAssignment_State.Location = New System.Drawing.Point(68, 50)
            Me.ComboBoxAlertAssignment_State.Name = "ComboBoxAlertAssignment_State"
            Me.ComboBoxAlertAssignment_State.PreventEnterBeep = False
            Me.ComboBoxAlertAssignment_State.ReadOnly = False
            Me.ComboBoxAlertAssignment_State.SecurityEnabled = True
            Me.ComboBoxAlertAssignment_State.Size = New System.Drawing.Size(355, 20)
            Me.ComboBoxAlertAssignment_State.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxAlertAssignment_State.TabIndex = 6
            Me.ComboBoxAlertAssignment_State.ValueMember = "ID"
            Me.ComboBoxAlertAssignment_State.WatermarkText = "Select Alert State"
            '
            'LabelAlertAssignment_AssignTo
            '
            Me.LabelAlertAssignment_AssignTo.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAlertAssignment_AssignTo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAlertAssignment_AssignTo.Location = New System.Drawing.Point(5, 76)
            Me.LabelAlertAssignment_AssignTo.Name = "LabelAlertAssignment_AssignTo"
            Me.LabelAlertAssignment_AssignTo.Size = New System.Drawing.Size(57, 20)
            Me.LabelAlertAssignment_AssignTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAlertAssignment_AssignTo.TabIndex = 4
            Me.LabelAlertAssignment_AssignTo.Text = "Assign To:"
            '
            'LabelAlertAssignment_State
            '
            Me.LabelAlertAssignment_State.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAlertAssignment_State.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAlertAssignment_State.Location = New System.Drawing.Point(5, 50)
            Me.LabelAlertAssignment_State.Name = "LabelAlertAssignment_State"
            Me.LabelAlertAssignment_State.Size = New System.Drawing.Size(57, 20)
            Me.LabelAlertAssignment_State.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAlertAssignment_State.TabIndex = 2
            Me.LabelAlertAssignment_State.Text = "State:"
            '
            'LabelAlertAssignment_Template
            '
            Me.LabelAlertAssignment_Template.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAlertAssignment_Template.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAlertAssignment_Template.Location = New System.Drawing.Point(5, 24)
            Me.LabelAlertAssignment_Template.Name = "LabelAlertAssignment_Template"
            Me.LabelAlertAssignment_Template.Size = New System.Drawing.Size(57, 20)
            Me.LabelAlertAssignment_Template.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAlertAssignment_Template.TabIndex = 0
            Me.LabelAlertAssignment_Template.Text = "Template:"
            '
            'ComboBoxAlertAssignment_Template
            '
            Me.ComboBoxAlertAssignment_Template.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxAlertAssignment_Template.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxAlertAssignment_Template.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxAlertAssignment_Template.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxAlertAssignment_Template.AutoFindItemInDataSource = False
            Me.ComboBoxAlertAssignment_Template.AutoSelectSingleItemDatasource = False
            Me.ComboBoxAlertAssignment_Template.BookmarkingEnabled = False
            Me.ComboBoxAlertAssignment_Template.ClientCode = ""
            Me.ComboBoxAlertAssignment_Template.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.AlertAssignmentTemplate
            Me.ComboBoxAlertAssignment_Template.DisableMouseWheel = False
            Me.ComboBoxAlertAssignment_Template.DisplayMember = "Name"
            Me.ComboBoxAlertAssignment_Template.DisplayName = ""
            Me.ComboBoxAlertAssignment_Template.DivisionCode = ""
            Me.ComboBoxAlertAssignment_Template.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxAlertAssignment_Template.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxAlertAssignment_Template.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxAlertAssignment_Template.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxAlertAssignment_Template.FocusHighlightEnabled = True
            Me.ComboBoxAlertAssignment_Template.FormattingEnabled = True
            Me.ComboBoxAlertAssignment_Template.ItemHeight = 14
            Me.ComboBoxAlertAssignment_Template.Location = New System.Drawing.Point(68, 24)
            Me.ComboBoxAlertAssignment_Template.Name = "ComboBoxAlertAssignment_Template"
            Me.ComboBoxAlertAssignment_Template.PreventEnterBeep = False
            Me.ComboBoxAlertAssignment_Template.ReadOnly = False
            Me.ComboBoxAlertAssignment_Template.SecurityEnabled = True
            Me.ComboBoxAlertAssignment_Template.Size = New System.Drawing.Size(355, 20)
            Me.ComboBoxAlertAssignment_Template.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxAlertAssignment_Template.TabIndex = 1
            Me.ComboBoxAlertAssignment_Template.ValueMember = "ID"
            Me.ComboBoxAlertAssignment_Template.WatermarkText = "Please Alert Assignment Template"
            '
            'LabelForm_Details
            '
            Me.LabelForm_Details.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_Details.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Details.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_Details.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelForm_Details.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelForm_Details.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_Details.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_Details.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_Details.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Details.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelForm_Details.Location = New System.Drawing.Point(4, 111)
            Me.LabelForm_Details.Name = "LabelForm_Details"
            Me.LabelForm_Details.Size = New System.Drawing.Size(764, 20)
            Me.LabelForm_Details.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Details.TabIndex = 3
            Me.LabelForm_Details.Text = "Details"
            '
            'LabelForm_Category
            '
            Me.LabelForm_Category.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Category.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Category.Location = New System.Drawing.Point(4, 137)
            Me.LabelForm_Category.Name = "LabelForm_Category"
            Me.LabelForm_Category.Size = New System.Drawing.Size(55, 20)
            Me.LabelForm_Category.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Category.TabIndex = 4
            Me.LabelForm_Category.Text = "Category:"
            '
            'ComboBoxForm_Category
            '
            Me.ComboBoxForm_Category.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_Category.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Category.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Category.AutoFindItemInDataSource = False
            Me.ComboBoxForm_Category.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_Category.BookmarkingEnabled = False
            Me.ComboBoxForm_Category.ClientCode = ""
            Me.ComboBoxForm_Category.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.AlertCategory
            Me.ComboBoxForm_Category.DisableMouseWheel = False
            Me.ComboBoxForm_Category.DisplayMember = "Description"
            Me.ComboBoxForm_Category.DisplayName = ""
            Me.ComboBoxForm_Category.DivisionCode = ""
            Me.ComboBoxForm_Category.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Category.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_Category.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_Category.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Category.FocusHighlightEnabled = True
            Me.ComboBoxForm_Category.FormattingEnabled = True
            Me.ComboBoxForm_Category.ItemHeight = 14
            Me.ComboBoxForm_Category.Location = New System.Drawing.Point(64, 137)
            Me.ComboBoxForm_Category.Name = "ComboBoxForm_Category"
            Me.ComboBoxForm_Category.PreventEnterBeep = False
            Me.ComboBoxForm_Category.ReadOnly = False
            Me.ComboBoxForm_Category.SecurityEnabled = True
            Me.ComboBoxForm_Category.Size = New System.Drawing.Size(266, 20)
            Me.ComboBoxForm_Category.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Category.TabIndex = 5
            Me.ComboBoxForm_Category.ValueMember = "ID"
            Me.ComboBoxForm_Category.WatermarkText = "Select Alert Category"
            '
            'CheckBoxForm_ExcludeAttachmentFromEmail
            '
            '
            '
            '
            Me.CheckBoxForm_ExcludeAttachmentFromEmail.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_ExcludeAttachmentFromEmail.CheckValue = 0
            Me.CheckBoxForm_ExcludeAttachmentFromEmail.CheckValueChecked = 1
            Me.CheckBoxForm_ExcludeAttachmentFromEmail.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_ExcludeAttachmentFromEmail.CheckValueUnchecked = 0
            Me.CheckBoxForm_ExcludeAttachmentFromEmail.ChildControls = CType(resources.GetObject("CheckBoxForm_ExcludeAttachmentFromEmail.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_ExcludeAttachmentFromEmail.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_ExcludeAttachmentFromEmail.Location = New System.Drawing.Point(337, 137)
            Me.CheckBoxForm_ExcludeAttachmentFromEmail.Name = "CheckBoxForm_ExcludeAttachmentFromEmail"
            Me.CheckBoxForm_ExcludeAttachmentFromEmail.OldestSibling = Nothing
            Me.CheckBoxForm_ExcludeAttachmentFromEmail.SecurityEnabled = True
            Me.CheckBoxForm_ExcludeAttachmentFromEmail.SiblingControls = CType(resources.GetObject("CheckBoxForm_ExcludeAttachmentFromEmail.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_ExcludeAttachmentFromEmail.Size = New System.Drawing.Size(175, 20)
            Me.CheckBoxForm_ExcludeAttachmentFromEmail.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_ExcludeAttachmentFromEmail.TabIndex = 6
            Me.CheckBoxForm_ExcludeAttachmentFromEmail.Text = "Exclude attachment from Email"
            '
            'LabelForm_Priority
            '
            Me.LabelForm_Priority.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Priority.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Priority.Location = New System.Drawing.Point(4, 163)
            Me.LabelForm_Priority.Name = "LabelForm_Priority"
            Me.LabelForm_Priority.Size = New System.Drawing.Size(55, 20)
            Me.LabelForm_Priority.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Priority.TabIndex = 7
            Me.LabelForm_Priority.Text = "Priority:"
            '
            'ComboBoxForm_Priority
            '
            Me.ComboBoxForm_Priority.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_Priority.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Priority.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Priority.AutoFindItemInDataSource = False
            Me.ComboBoxForm_Priority.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_Priority.BookmarkingEnabled = False
            Me.ComboBoxForm_Priority.ClientCode = ""
            Me.ComboBoxForm_Priority.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumDataTable
            Me.ComboBoxForm_Priority.DisableMouseWheel = False
            Me.ComboBoxForm_Priority.DisplayMember = "Name"
            Me.ComboBoxForm_Priority.DisplayName = ""
            Me.ComboBoxForm_Priority.DivisionCode = ""
            Me.ComboBoxForm_Priority.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Priority.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_Priority.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_Priority.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Priority.FocusHighlightEnabled = True
            Me.ComboBoxForm_Priority.FormattingEnabled = True
            Me.ComboBoxForm_Priority.ItemHeight = 14
            Me.ComboBoxForm_Priority.Location = New System.Drawing.Point(64, 163)
            Me.ComboBoxForm_Priority.Name = "ComboBoxForm_Priority"
            Me.ComboBoxForm_Priority.PreventEnterBeep = False
            Me.ComboBoxForm_Priority.ReadOnly = False
            Me.ComboBoxForm_Priority.SecurityEnabled = True
            Me.ComboBoxForm_Priority.Size = New System.Drawing.Size(266, 20)
            Me.ComboBoxForm_Priority.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Priority.TabIndex = 8
            Me.ComboBoxForm_Priority.ValueMember = "Value"
            Me.ComboBoxForm_Priority.WatermarkText = "Select"
            '
            'LabelForm_DueDate
            '
            Me.LabelForm_DueDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_DueDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_DueDate.Location = New System.Drawing.Point(337, 163)
            Me.LabelForm_DueDate.Name = "LabelForm_DueDate"
            Me.LabelForm_DueDate.Size = New System.Drawing.Size(55, 20)
            Me.LabelForm_DueDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_DueDate.TabIndex = 9
            Me.LabelForm_DueDate.Text = "Due Date:"
            '
            'DateTimePickerForm_DueDate
            '
            Me.DateTimePickerForm_DueDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerForm_DueDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerForm_DueDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_DueDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerForm_DueDate.ButtonDropDown.Visible = True
            Me.DateTimePickerForm_DueDate.ButtonFreeText.Checked = True
            Me.DateTimePickerForm_DueDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.ShortDate
            Me.DateTimePickerForm_DueDate.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector
            Me.DateTimePickerForm_DueDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerForm_DueDate.DisplayName = ""
            Me.DateTimePickerForm_DueDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerForm_DueDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerForm_DueDate.FocusHighlightEnabled = True
            Me.DateTimePickerForm_DueDate.FreeTextEntryMode = True
            Me.DateTimePickerForm_DueDate.IsPopupCalendarOpen = False
            Me.DateTimePickerForm_DueDate.Location = New System.Drawing.Point(398, 163)
            Me.DateTimePickerForm_DueDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerForm_DueDate.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerForm_DueDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_DueDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerForm_DueDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerForm_DueDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerForm_DueDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_DueDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerForm_DueDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerForm_DueDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerForm_DueDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerForm_DueDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_DueDate.MonthCalendar.DisplayMonth = New Date(2013, 7, 1, 0, 0, 0, 0)
            Me.DateTimePickerForm_DueDate.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerForm_DueDate.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerForm_DueDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerForm_DueDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_DueDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerForm_DueDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_DueDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerForm_DueDate.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerForm_DueDate.Name = "DateTimePickerForm_DueDate"
            Me.DateTimePickerForm_DueDate.ReadOnly = False
            Me.DateTimePickerForm_DueDate.Size = New System.Drawing.Size(114, 20)
            Me.DateTimePickerForm_DueDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerForm_DueDate.TabIndex = 10
            Me.DateTimePickerForm_DueDate.Value = New Date(2013, 7, 15, 11, 1, 42, 892)
            '
            'DateTimePickerForm_DueTime
            '
            Me.DateTimePickerForm_DueTime.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerForm_DueTime.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerForm_DueTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_DueTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerForm_DueTime.ButtonFreeText.Checked = True
            Me.DateTimePickerForm_DueTime.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.TimeOnly
            Me.DateTimePickerForm_DueTime.CustomFormat = "hh:mm tt"
            Me.DateTimePickerForm_DueTime.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.TimeSelector
            Me.DateTimePickerForm_DueTime.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerForm_DueTime.DisplayName = ""
            Me.DateTimePickerForm_DueTime.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerForm_DueTime.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerForm_DueTime.FocusHighlightEnabled = True
            Me.DateTimePickerForm_DueTime.Format = DevComponents.Editors.eDateTimePickerFormat.ShortTime
            Me.DateTimePickerForm_DueTime.FreeTextEntryMode = True
            Me.DateTimePickerForm_DueTime.IsPopupCalendarOpen = False
            Me.DateTimePickerForm_DueTime.Location = New System.Drawing.Point(557, 163)
            Me.DateTimePickerForm_DueTime.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerForm_DueTime.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerForm_DueTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_DueTime.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerForm_DueTime.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerForm_DueTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerForm_DueTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_DueTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerForm_DueTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerForm_DueTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerForm_DueTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerForm_DueTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_DueTime.MonthCalendar.DisplayMonth = New Date(2013, 7, 1, 0, 0, 0, 0)
            Me.DateTimePickerForm_DueTime.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerForm_DueTime.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerForm_DueTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerForm_DueTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_DueTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerForm_DueTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_DueTime.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerForm_DueTime.MonthCalendar.Visible = False
            Me.DateTimePickerForm_DueTime.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerForm_DueTime.Name = "DateTimePickerForm_DueTime"
            Me.DateTimePickerForm_DueTime.ReadOnly = False
            Me.DateTimePickerForm_DueTime.Size = New System.Drawing.Size(122, 20)
            Me.DateTimePickerForm_DueTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerForm_DueTime.TabIndex = 12
            Me.DateTimePickerForm_DueTime.TimeSelectorTimeFormat = DevComponents.Editors.DateTimeAdv.eTimeSelectorFormat.Time12H
            Me.DateTimePickerForm_DueTime.Value = New Date(2014, 11, 3, 14, 14, 30, 314)
            '
            'LabelForm_DueTime
            '
            Me.LabelForm_DueTime.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_DueTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_DueTime.Location = New System.Drawing.Point(518, 163)
            Me.LabelForm_DueTime.Name = "LabelForm_DueTime"
            Me.LabelForm_DueTime.Size = New System.Drawing.Size(34, 20)
            Me.LabelForm_DueTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_DueTime.TabIndex = 11
            Me.LabelForm_DueTime.Text = "Time:"
            '
            'LabelForm_Subject
            '
            Me.LabelForm_Subject.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Subject.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Subject.Location = New System.Drawing.Point(4, 189)
            Me.LabelForm_Subject.Name = "LabelForm_Subject"
            Me.LabelForm_Subject.Size = New System.Drawing.Size(55, 20)
            Me.LabelForm_Subject.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Subject.TabIndex = 13
            Me.LabelForm_Subject.Text = "Subject:"
            '
            'TextBoxForm_Subject
            '
            Me.TextBoxForm_Subject.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxForm_Subject.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Subject.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Subject.CheckSpellingOnValidate = False
            Me.TextBoxForm_Subject.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Subject.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_Subject.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Subject.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Subject.FocusHighlightEnabled = True
            Me.TextBoxForm_Subject.Location = New System.Drawing.Point(64, 189)
            Me.TextBoxForm_Subject.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Subject.Name = "TextBoxForm_Subject"
            Me.TextBoxForm_Subject.SecurityEnabled = True
            Me.TextBoxForm_Subject.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Subject.Size = New System.Drawing.Size(703, 20)
            Me.TextBoxForm_Subject.StartingFolderName = Nothing
            Me.TextBoxForm_Subject.TabIndex = 14
            Me.TextBoxForm_Subject.TabOnEnter = True
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
            Me.RibbonBarOptions_Actions.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Send, Me.ButtonItemActions_Cancel, Me.ButtonItemActions_Clear})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(68, 0)
            Me.RibbonBarOptions_Actions.MinimumSize = New System.Drawing.Size(94, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(158, 91)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 3
            Me.RibbonBarOptions_Actions.Text = "Actions"
            '
            '
            '
            Me.RibbonBarOptions_Actions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Actions.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Actions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemActions_Send
            '
            Me.ButtonItemActions_Send.BeginGroup = True
            Me.ButtonItemActions_Send.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Send.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Send.Name = "ButtonItemActions_Send"
            Me.ButtonItemActions_Send.RibbonWordWrap = False
            Me.ButtonItemActions_Send.Stretch = True
            Me.ButtonItemActions_Send.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Send.Text = "Send"
            '
            'ButtonItemActions_Cancel
            '
            Me.ButtonItemActions_Cancel.BeginGroup = True
            Me.ButtonItemActions_Cancel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Cancel.Name = "ButtonItemActions_Cancel"
            Me.ButtonItemActions_Cancel.RibbonWordWrap = False
            Me.ButtonItemActions_Cancel.Stretch = True
            Me.ButtonItemActions_Cancel.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Cancel.Text = "Cancel"
            '
            'ButtonItemActions_Clear
            '
            Me.ButtonItemActions_Clear.BeginGroup = True
            Me.ButtonItemActions_Clear.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Clear.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Clear.Name = "ButtonItemActions_Clear"
            Me.ButtonItemActions_Clear.RibbonWordWrap = False
            Me.ButtonItemActions_Clear.Stretch = True
            Me.ButtonItemActions_Clear.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Clear.Text = "Clear"
            '
            'RichEditForm_Description
            '
            Me.RichEditForm_Description.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RichEditForm_Description.HtmlText = resources.GetString("RichEditForm_Description.HtmlText")
            Me.RichEditForm_Description.Location = New System.Drawing.Point(3, 215)
            Me.RichEditForm_Description.MhtText = resources.GetString("RichEditForm_Description.MhtText")
            Me.RichEditForm_Description.Name = "RichEditForm_Description"
            Me.RichEditForm_Description.ReadOnly = False
            Me.RichEditForm_Description.RtfText = resources.GetString("RichEditForm_Description.RtfText")
            Me.RichEditForm_Description.SecurityEnabled = True
            Me.RichEditForm_Description.ShowEditButtons = True
            Me.RichEditForm_Description.Size = New System.Drawing.Size(764, 170)
            Me.RichEditForm_Description.TabIndex = 15
            Me.RichEditForm_Description.WordMLText = resources.GetString("RichEditForm_Description.WordMLText")
            '
            'AlertAssignmentEditDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(781, 563)
            Me.CloseButtonVisible = False
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(4)
            Me.Name = "AlertAssignmentEditDialog"
            Me.Text = "Alert Assignment"
            Me.Controls.SetChildIndex(Me.BarForm_StatusBar, 0)
            Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
            Me.Controls.SetChildIndex(Me.PanelForm_Form, 0)
            Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.PerformLayout()
            Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Form.ResumeLayout(False)
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxForm_AlertLevel, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxForm_AlertLevel.ResumeLayout(False)
            CType(Me.SearchableComboBoxAlertLevel_Item.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxAlertLevel_ItemView, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxForm_AlertAssignment, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxForm_AlertAssignment.ResumeLayout(False)
            CType(Me.DateTimePickerForm_DueDate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerForm_DueTime, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents GroupBoxForm_AlertLevel As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents GroupBoxForm_AlertAssignment As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents SearchableComboBoxAlertLevel_Item As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxAlertLevel_ItemView As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents LabelAlertLevel_Item As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxAlertLevel_IsAssignment As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelAlertLevel_Level As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxAlertLevel_Level As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelAlertAssignment_AssignTo As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelAlertAssignment_State As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelAlertAssignment_Template As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxAlertAssignment_Template As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_Details As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Category As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_Category As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents CheckBoxForm_ExcludeAttachmentFromEmail As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelForm_Priority As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_Priority As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_DueDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents DateTimePickerForm_DueDate As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents DateTimePickerForm_DueTime As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents LabelForm_DueTime As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Subject As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_Subject As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Send As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Cancel As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Clear As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ComboBoxAlertAssignment_State As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxAlertAssignment_AssignTo As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelAlertLevel_ItemFilter As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxAlertLevel_ItemFilter As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents RichEditForm_Description As AdvantageFramework.WinForm.Presentation.Controls.RichEditControl
    End Class

End Namespace