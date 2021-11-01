Namespace Media.Exports

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class BroadcastBuyInvoiceExportForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BroadcastBuyInvoiceExportForm))
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Export = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.TextBoxOptions_OutputFolder = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox()
            Me.LabelOptions_OutputFolder = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.RadioButtonControlOptions_Quarter = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlOptions_BroadcastMonth = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.TabControlForm_Selections = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelOptionsTab_Options = New DevComponents.DotNetBar.TabControlPanel()
            Me.ComboBoxOptions_Quarter = New AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox()
            Me.ComboBoxOptions_BroadcastMonth = New AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox()
            Me.LabelOptions_From = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.NumericInputOptions_Year = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.TabItemMCS_OptionsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanel_Clients = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewSelectClients_Clients = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.RadioButtonSelectClients_ChooseClients = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelectClients_AllClients = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.TabItemSelections_SelectClientsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            CType(Me.TabControlForm_Selections, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlForm_Selections.SuspendLayout()
            Me.TabControlPanelOptionsTab_Options.SuspendLayout()
            CType(Me.NumericInputOptions_Year.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanel_Clients.SuspendLayout()
            Me.SuspendLayout()
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(112, 4)
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(223, 98)
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Export})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(147, 98)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 1
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
            Me.ButtonItemActions_Export.BeginGroup = True
            Me.ButtonItemActions_Export.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Export.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Export.Name = "ButtonItemActions_Export"
            Me.ButtonItemActions_Export.SecurityEnabled = True
            Me.ButtonItemActions_Export.Stretch = True
            Me.ButtonItemActions_Export.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Export.Text = "Export"
            '
            'TextBoxOptions_OutputFolder
            '
            Me.TextBoxOptions_OutputFolder.AgencyImportPath = Nothing
            Me.TextBoxOptions_OutputFolder.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxOptions_OutputFolder.Border.Class = "TextBoxBorder"
            Me.TextBoxOptions_OutputFolder.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxOptions_OutputFolder.ButtonCustom.Visible = True
            Me.TextBoxOptions_OutputFolder.CheckSpellingOnValidate = False
            Me.TextBoxOptions_OutputFolder.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox.Type.Folder
            Me.TextBoxOptions_OutputFolder.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxOptions_OutputFolder.DisplayName = ""
            Me.TextBoxOptions_OutputFolder.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxOptions_OutputFolder.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxOptions_OutputFolder.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxOptions_OutputFolder.FocusHighlightEnabled = True
            Me.TextBoxOptions_OutputFolder.ForeColor = System.Drawing.Color.Black
            Me.TextBoxOptions_OutputFolder.Location = New System.Drawing.Point(147, 86)
            Me.TextBoxOptions_OutputFolder.MaxFileSize = CType(0, Long)
            Me.TextBoxOptions_OutputFolder.Name = "TextBoxOptions_OutputFolder"
            Me.TextBoxOptions_OutputFolder.PreventEnterBeep = True
            Me.TextBoxOptions_OutputFolder.SecurityEnabled = True
            Me.TextBoxOptions_OutputFolder.ShowSpellCheckCompleteMessage = True
            Me.TextBoxOptions_OutputFolder.Size = New System.Drawing.Size(554, 20)
            Me.TextBoxOptions_OutputFolder.StartingFolderName = Nothing
            Me.TextBoxOptions_OutputFolder.TabIndex = 7
            Me.TextBoxOptions_OutputFolder.TabOnEnter = True
            '
            'LabelOptions_OutputFolder
            '
            Me.LabelOptions_OutputFolder.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelOptions_OutputFolder.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelOptions_OutputFolder.Location = New System.Drawing.Point(5, 86)
            Me.LabelOptions_OutputFolder.Name = "LabelOptions_OutputFolder"
            Me.LabelOptions_OutputFolder.Size = New System.Drawing.Size(136, 20)
            Me.LabelOptions_OutputFolder.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelOptions_OutputFolder.TabIndex = 6
            Me.LabelOptions_OutputFolder.Text = "Output Folder:"
            '
            'RadioButtonControlOptions_Quarter
            '
            Me.RadioButtonControlOptions_Quarter.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlOptions_Quarter.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlOptions_Quarter.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlOptions_Quarter.Location = New System.Drawing.Point(5, 60)
            Me.RadioButtonControlOptions_Quarter.Name = "RadioButtonControlOptions_Quarter"
            Me.RadioButtonControlOptions_Quarter.SecurityEnabled = True
            Me.RadioButtonControlOptions_Quarter.Size = New System.Drawing.Size(136, 20)
            Me.RadioButtonControlOptions_Quarter.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlOptions_Quarter.TabIndex = 4
            Me.RadioButtonControlOptions_Quarter.TabOnEnter = True
            Me.RadioButtonControlOptions_Quarter.TabStop = False
            Me.RadioButtonControlOptions_Quarter.Text = "Quarter"
            '
            'RadioButtonControlOptions_BroadcastMonth
            '
            Me.RadioButtonControlOptions_BroadcastMonth.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlOptions_BroadcastMonth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlOptions_BroadcastMonth.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlOptions_BroadcastMonth.Checked = True
            Me.RadioButtonControlOptions_BroadcastMonth.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonControlOptions_BroadcastMonth.CheckValue = "Y"
            Me.RadioButtonControlOptions_BroadcastMonth.Location = New System.Drawing.Point(5, 31)
            Me.RadioButtonControlOptions_BroadcastMonth.Name = "RadioButtonControlOptions_BroadcastMonth"
            Me.RadioButtonControlOptions_BroadcastMonth.SecurityEnabled = True
            Me.RadioButtonControlOptions_BroadcastMonth.Size = New System.Drawing.Size(136, 20)
            Me.RadioButtonControlOptions_BroadcastMonth.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlOptions_BroadcastMonth.TabIndex = 2
            Me.RadioButtonControlOptions_BroadcastMonth.TabOnEnter = True
            Me.RadioButtonControlOptions_BroadcastMonth.Text = "Broadcast Month"
            '
            'TabControlForm_Selections
            '
            Me.TabControlForm_Selections.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlForm_Selections.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer))
            Me.TabControlForm_Selections.CanReorderTabs = False
            Me.TabControlForm_Selections.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlForm_Selections.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlForm_Selections.Controls.Add(Me.TabControlPanelOptionsTab_Options)
            Me.TabControlForm_Selections.Controls.Add(Me.TabControlPanel_Clients)
            Me.TabControlForm_Selections.Location = New System.Drawing.Point(12, 12)
            Me.TabControlForm_Selections.Name = "TabControlForm_Selections"
            Me.TabControlForm_Selections.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlForm_Selections.SelectedTabIndex = 0
            Me.TabControlForm_Selections.Size = New System.Drawing.Size(705, 307)
            Me.TabControlForm_Selections.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlForm_Selections.TabIndex = 20
            Me.TabControlForm_Selections.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlForm_Selections.Tabs.Add(Me.TabItemMCS_OptionsTab)
            Me.TabControlForm_Selections.Tabs.Add(Me.TabItemSelections_SelectClientsTab)
            '
            'TabControlPanelOptionsTab_Options
            '
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.ComboBoxOptions_Quarter)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.ComboBoxOptions_BroadcastMonth)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.TextBoxOptions_OutputFolder)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.LabelOptions_From)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.LabelOptions_OutputFolder)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.RadioButtonControlOptions_Quarter)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.NumericInputOptions_Year)
            Me.TabControlPanelOptionsTab_Options.Controls.Add(Me.RadioButtonControlOptions_BroadcastMonth)
            Me.TabControlPanelOptionsTab_Options.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelOptionsTab_Options.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelOptionsTab_Options.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelOptionsTab_Options.Name = "TabControlPanelOptionsTab_Options"
            Me.TabControlPanelOptionsTab_Options.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelOptionsTab_Options.Size = New System.Drawing.Size(705, 280)
            Me.TabControlPanelOptionsTab_Options.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelOptionsTab_Options.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelOptionsTab_Options.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelOptionsTab_Options.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelOptionsTab_Options.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelOptionsTab_Options.Style.GradientAngle = 90
            Me.TabControlPanelOptionsTab_Options.TabIndex = 0
            Me.TabControlPanelOptionsTab_Options.TabItem = Me.TabItemMCS_OptionsTab
            '
            'ComboBoxOptions_Quarter
            '
            Me.ComboBoxOptions_Quarter.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxOptions_Quarter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
            Me.ComboBoxOptions_Quarter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxOptions_Quarter.AutoFindItemInDataSource = True
            Me.ComboBoxOptions_Quarter.AutoSelectSingleItemDatasource = False
            Me.ComboBoxOptions_Quarter.BookmarkingEnabled = False
            Me.ComboBoxOptions_Quarter.DisableMouseWheel = True
            Me.ComboBoxOptions_Quarter.DisplayMember = "Display"
            Me.ComboBoxOptions_Quarter.DisplayName = "Quarter"
            Me.ComboBoxOptions_Quarter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxOptions_Quarter.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxOptions_Quarter.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxOptions_Quarter.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxOptions_Quarter.FocusHighlightEnabled = True
            Me.ComboBoxOptions_Quarter.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxOptions_Quarter.FormattingEnabled = True
            Me.ComboBoxOptions_Quarter.ItemHeight = 16
            Me.ComboBoxOptions_Quarter.Location = New System.Drawing.Point(147, 58)
            Me.ComboBoxOptions_Quarter.Name = "ComboBoxOptions_Quarter"
            Me.ComboBoxOptions_Quarter.ReadOnly = False
            Me.ComboBoxOptions_Quarter.SecurityEnabled = True
            Me.ComboBoxOptions_Quarter.Size = New System.Drawing.Size(148, 22)
            Me.ComboBoxOptions_Quarter.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxOptions_Quarter.TabIndex = 5
            Me.ComboBoxOptions_Quarter.TabOnEnter = True
            Me.ComboBoxOptions_Quarter.ValueMember = "Value"
            Me.ComboBoxOptions_Quarter.WatermarkText = "Select Month"
            '
            'ComboBoxOptions_BroadcastMonth
            '
            Me.ComboBoxOptions_BroadcastMonth.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxOptions_BroadcastMonth.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
            Me.ComboBoxOptions_BroadcastMonth.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxOptions_BroadcastMonth.AutoFindItemInDataSource = True
            Me.ComboBoxOptions_BroadcastMonth.AutoSelectSingleItemDatasource = False
            Me.ComboBoxOptions_BroadcastMonth.BookmarkingEnabled = False
            Me.ComboBoxOptions_BroadcastMonth.DisableMouseWheel = True
            Me.ComboBoxOptions_BroadcastMonth.DisplayMember = "Display"
            Me.ComboBoxOptions_BroadcastMonth.DisplayName = "Broadcast Month"
            Me.ComboBoxOptions_BroadcastMonth.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxOptions_BroadcastMonth.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxOptions_BroadcastMonth.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxOptions_BroadcastMonth.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxOptions_BroadcastMonth.FocusHighlightEnabled = True
            Me.ComboBoxOptions_BroadcastMonth.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxOptions_BroadcastMonth.FormattingEnabled = True
            Me.ComboBoxOptions_BroadcastMonth.ItemHeight = 16
            Me.ComboBoxOptions_BroadcastMonth.Location = New System.Drawing.Point(147, 30)
            Me.ComboBoxOptions_BroadcastMonth.Name = "ComboBoxOptions_BroadcastMonth"
            Me.ComboBoxOptions_BroadcastMonth.ReadOnly = False
            Me.ComboBoxOptions_BroadcastMonth.SecurityEnabled = True
            Me.ComboBoxOptions_BroadcastMonth.Size = New System.Drawing.Size(148, 22)
            Me.ComboBoxOptions_BroadcastMonth.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxOptions_BroadcastMonth.TabIndex = 3
            Me.ComboBoxOptions_BroadcastMonth.TabOnEnter = True
            Me.ComboBoxOptions_BroadcastMonth.ValueMember = "Value"
            Me.ComboBoxOptions_BroadcastMonth.WatermarkText = "Select Month"
            '
            'LabelOptions_From
            '
            Me.LabelOptions_From.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelOptions_From.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelOptions_From.Location = New System.Drawing.Point(5, 5)
            Me.LabelOptions_From.Name = "LabelOptions_From"
            Me.LabelOptions_From.Size = New System.Drawing.Size(136, 20)
            Me.LabelOptions_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelOptions_From.TabIndex = 0
            Me.LabelOptions_From.Text = "Year:"
            '
            'NumericInputOptions_Year
            '
            Me.NumericInputOptions_Year.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputOptions_Year.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputOptions_Year.EditValue = New Decimal(New Integer() {2020, 0, 0, 0})
            Me.NumericInputOptions_Year.EnterMoveNextControl = True
            Me.NumericInputOptions_Year.Location = New System.Drawing.Point(147, 4)
            Me.NumericInputOptions_Year.Name = "NumericInputOptions_Year"
            Me.NumericInputOptions_Year.Properties.AllowMouseWheel = False
            Me.NumericInputOptions_Year.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
            Me.NumericInputOptions_Year.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputOptions_Year.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputOptions_Year.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputOptions_Year.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputOptions_Year.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputOptions_Year.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputOptions_Year.Properties.IsFloatValue = False
            Me.NumericInputOptions_Year.Properties.Mask.EditMask = "f0"
            Me.NumericInputOptions_Year.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputOptions_Year.Properties.MaxValue = New Decimal(New Integer() {2079, 0, 0, 0})
            Me.NumericInputOptions_Year.Properties.MinValue = New Decimal(New Integer() {1997, 0, 0, 0})
            Me.NumericInputOptions_Year.SecurityEnabled = True
            Me.NumericInputOptions_Year.Size = New System.Drawing.Size(44, 20)
            Me.NumericInputOptions_Year.TabIndex = 1
            '
            'TabItemMCS_OptionsTab
            '
            Me.TabItemMCS_OptionsTab.AttachedControl = Me.TabControlPanelOptionsTab_Options
            Me.TabItemMCS_OptionsTab.Name = "TabItemMCS_OptionsTab"
            Me.TabItemMCS_OptionsTab.Text = "Options"
            '
            'TabControlPanel_Clients
            '
            Me.TabControlPanel_Clients.Controls.Add(Me.DataGridViewSelectClients_Clients)
            Me.TabControlPanel_Clients.Controls.Add(Me.RadioButtonSelectClients_ChooseClients)
            Me.TabControlPanel_Clients.Controls.Add(Me.RadioButtonSelectClients_AllClients)
            Me.TabControlPanel_Clients.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanel_Clients.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanel_Clients.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanel_Clients.Name = "TabControlPanel_Clients"
            Me.TabControlPanel_Clients.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanel_Clients.Size = New System.Drawing.Size(705, 280)
            Me.TabControlPanel_Clients.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanel_Clients.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanel_Clients.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanel_Clients.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanel_Clients.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanel_Clients.Style.GradientAngle = 90
            Me.TabControlPanel_Clients.TabIndex = 0
            Me.TabControlPanel_Clients.TabItem = Me.TabItemSelections_SelectClientsTab
            '
            'DataGridViewSelectClients_Clients
            '
            Me.DataGridViewSelectClients_Clients.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSelectClients_Clients.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewSelectClients_Clients.AutoUpdateViewCaption = True
            Me.DataGridViewSelectClients_Clients.Enabled = False
            Me.DataGridViewSelectClients_Clients.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSelectClients_Clients.ItemDescription = "Office(s)"
            Me.DataGridViewSelectClients_Clients.Location = New System.Drawing.Point(4, 30)
            Me.DataGridViewSelectClients_Clients.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewSelectClients_Clients.ModifyGridRowHeight = False
            Me.DataGridViewSelectClients_Clients.MultiSelect = True
            Me.DataGridViewSelectClients_Clients.Name = "DataGridViewSelectClients_Clients"
            Me.DataGridViewSelectClients_Clients.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewSelectClients_Clients.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewSelectClients_Clients.ShowRowSelectionIfHidden = True
            Me.DataGridViewSelectClients_Clients.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSelectClients_Clients.Size = New System.Drawing.Size(697, 246)
            Me.DataGridViewSelectClients_Clients.TabIndex = 2
            Me.DataGridViewSelectClients_Clients.UseEmbeddedNavigator = False
            Me.DataGridViewSelectClients_Clients.ViewCaptionHeight = -1
            '
            'RadioButtonSelectClients_ChooseClients
            '
            Me.RadioButtonSelectClients_ChooseClients.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectClients_ChooseClients.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectClients_ChooseClients.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectClients_ChooseClients.Location = New System.Drawing.Point(87, 4)
            Me.RadioButtonSelectClients_ChooseClients.Name = "RadioButtonSelectClients_ChooseClients"
            Me.RadioButtonSelectClients_ChooseClients.SecurityEnabled = True
            Me.RadioButtonSelectClients_ChooseClients.Size = New System.Drawing.Size(138, 20)
            Me.RadioButtonSelectClients_ChooseClients.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectClients_ChooseClients.TabIndex = 1
            Me.RadioButtonSelectClients_ChooseClients.TabOnEnter = True
            Me.RadioButtonSelectClients_ChooseClients.TabStop = False
            Me.RadioButtonSelectClients_ChooseClients.Text = "Choose Clients"
            '
            'RadioButtonSelectClients_AllClients
            '
            Me.RadioButtonSelectClients_AllClients.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectClients_AllClients.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectClients_AllClients.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectClients_AllClients.Checked = True
            Me.RadioButtonSelectClients_AllClients.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonSelectClients_AllClients.CheckValue = "Y"
            Me.RadioButtonSelectClients_AllClients.Location = New System.Drawing.Point(4, 4)
            Me.RadioButtonSelectClients_AllClients.Name = "RadioButtonSelectClients_AllClients"
            Me.RadioButtonSelectClients_AllClients.SecurityEnabled = True
            Me.RadioButtonSelectClients_AllClients.Size = New System.Drawing.Size(77, 20)
            Me.RadioButtonSelectClients_AllClients.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectClients_AllClients.TabIndex = 0
            Me.RadioButtonSelectClients_AllClients.TabOnEnter = True
            Me.RadioButtonSelectClients_AllClients.Text = "All Clients"
            '
            'TabItemSelections_SelectClientsTab
            '
            Me.TabItemSelections_SelectClientsTab.AttachedControl = Me.TabControlPanel_Clients
            Me.TabItemSelections_SelectClientsTab.Name = "TabItemSelections_SelectClientsTab"
            Me.TabItemSelections_SelectClientsTab.Text = "Select Clients"
            '
            'BroadcastBuyInvoiceExportForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(729, 331)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.TabControlForm_Selections)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "BroadcastBuyInvoiceExportForm"
            Me.Text = "Broadcast Buy/Invoice Export"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            CType(Me.TabControlForm_Selections, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlForm_Selections.ResumeLayout(False)
            Me.TabControlPanelOptionsTab_Options.ResumeLayout(False)
            CType(Me.NumericInputOptions_Year.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanel_Clients.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents TextBoxOptions_OutputFolder As WinForm.MVC.Presentation.Controls.TextBox
        Friend WithEvents LabelOptions_OutputFolder As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents ButtonItemActions_Export As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RadioButtonControlOptions_Quarter As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlOptions_BroadcastMonth As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents TabControlForm_Selections As WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanel_Clients As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewSelectClients_Clients As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents RadioButtonSelectClients_ChooseClients As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSelectClients_AllClients As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents TabItemSelections_SelectClientsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelOptionsTab_Options As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents LabelOptions_From As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents NumericInputOptions_Year As WinForm.Presentation.Controls.NumericInput
        Friend WithEvents TabItemMCS_OptionsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents ComboBoxOptions_Quarter As WinForm.MVC.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxOptions_BroadcastMonth As WinForm.MVC.Presentation.Controls.ComboBox
    End Class

End Namespace
