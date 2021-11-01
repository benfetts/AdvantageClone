Namespace Reporting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ClientPLInitialLoadingDialog
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ClientPLInitialLoadingDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ComboBoxForm_StartingPostPeriod = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_StartingPostPeriod = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxForm_Office = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelForm_EndingPostPeriod = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_EndingPostPeriod = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_Type = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.RadioButtonForm_Standard = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonForm_AlternateDirectCost = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.LabelForm_GroupByOptions = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxForm_Client = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_Division = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_Product = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_Type = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_SalesClass = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_PostPeriod = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_Year = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.ButtonForm_2Years = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_1Year = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_MTD = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_YTD = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_2YTD = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.CheckBoxForm_Campaign = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_ProductUDF = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_AccountExecutive = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelForm_IncludeOptions = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxForm_BilledIncomeRecognized = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_GLEntries = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_ManualInvoices = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelForm_ReportOptions = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_OverheadSet = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBox_OverheadSet = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.PanelForm_PrimaryDisplayOption = New System.Windows.Forms.Panel()
            Me.RadioButtonPrimaryDisplayOption_OverheadFactor = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonPrimaryDisplayOption_OverheadAllocation = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.PanelForm_DataOption = New System.Windows.Forms.Panel()
            Me.RadioButtonDataOption_Hours = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonDataOption_Cost = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.PanelForm_CoopOptions = New System.Windows.Forms.Panel()
            Me.RadioButtonCoopOptions_BreakoutCoop = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonCoopOptions_CombineCoop = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.PanelForm_TopSection = New System.Windows.Forms.Panel()
            Me.LabelTopSection_Report = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxTopSection_Report = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.PanelForm_BottomSection = New System.Windows.Forms.Panel()
            Me.TabControlForm_JDA = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions = New DevComponents.DotNetBar.TabControlPanel()
            Me.CheckBoxDirectExpenseOperatingOnly = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_ExcludeNewBusiness = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.TabItemJDA_VersionAndOptionsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelSelectOfficesTab_SelectClients = New DevComponents.DotNetBar.TabControlPanel()
            Me.CDPChooserControl_Production = New AdvantageFramework.WinForm.Presentation.Controls.CDPChooserControl()
            Me.TabItemProductionCriteria_SelectClientsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelSelectOfficesTab_SelectOffices = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewSelectOffices_Offices = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RadioButtonSelectOffices_AllOffices = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelectOffices_ChooseOffices = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.TabItemJDA_SelectOfficesTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.LabelForm_PriorPeriod2Start = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_PriorPeriod2Start = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ComboBoxForm_PriorPeriod2End = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_PriorPeriod2End = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_PriorPeriod1Start = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_PriorPeriod1Start = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ComboBoxForm_PriorPeriod1End = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_PriorPeriod1End = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.PanelForm_PrimaryDisplayOption.SuspendLayout()
            Me.PanelForm_DataOption.SuspendLayout()
            Me.PanelForm_CoopOptions.SuspendLayout()
            Me.PanelForm_TopSection.SuspendLayout()
            Me.PanelForm_BottomSection.SuspendLayout()
            CType(Me.TabControlForm_JDA, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlForm_JDA.SuspendLayout()
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.SuspendLayout()
            Me.TabControlPanelSelectOfficesTab_SelectClients.SuspendLayout()
            Me.TabControlPanelSelectOfficesTab_SelectOffices.SuspendLayout()
            Me.SuspendLayout()
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(873, 618)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 35
            Me.ButtonForm_OK.Text = "OK"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(954, 618)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 36
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ComboBoxForm_StartingPostPeriod
            '
            Me.ComboBoxForm_StartingPostPeriod.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_StartingPostPeriod.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_StartingPostPeriod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_StartingPostPeriod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_StartingPostPeriod.AutoFindItemInDataSource = False
            Me.ComboBoxForm_StartingPostPeriod.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_StartingPostPeriod.BookmarkingEnabled = False
            Me.ComboBoxForm_StartingPostPeriod.ClientCode = ""
            Me.ComboBoxForm_StartingPostPeriod.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.PostPeriod
            Me.ComboBoxForm_StartingPostPeriod.DisableMouseWheel = False
            Me.ComboBoxForm_StartingPostPeriod.DisplayMember = "Description"
            Me.ComboBoxForm_StartingPostPeriod.DisplayName = ""
            Me.ComboBoxForm_StartingPostPeriod.DivisionCode = ""
            Me.ComboBoxForm_StartingPostPeriod.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_StartingPostPeriod.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_StartingPostPeriod.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_StartingPostPeriod.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_StartingPostPeriod.FocusHighlightEnabled = True
            Me.ComboBoxForm_StartingPostPeriod.FormattingEnabled = True
            Me.ComboBoxForm_StartingPostPeriod.ItemHeight = 14
            Me.ComboBoxForm_StartingPostPeriod.Location = New System.Drawing.Point(116, 4)
            Me.ComboBoxForm_StartingPostPeriod.Name = "ComboBoxForm_StartingPostPeriod"
            Me.ComboBoxForm_StartingPostPeriod.ReadOnly = False
            Me.ComboBoxForm_StartingPostPeriod.SecurityEnabled = True
            Me.ComboBoxForm_StartingPostPeriod.Size = New System.Drawing.Size(109, 20)
            Me.ComboBoxForm_StartingPostPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_StartingPostPeriod.TabIndex = 2
            Me.ComboBoxForm_StartingPostPeriod.TabOnEnter = True
            Me.ComboBoxForm_StartingPostPeriod.ValueMember = "Code"
            Me.ComboBoxForm_StartingPostPeriod.WatermarkText = "Select Post Period"
            '
            'LabelForm_StartingPostPeriod
            '
            Me.LabelForm_StartingPostPeriod.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_StartingPostPeriod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_StartingPostPeriod.Location = New System.Drawing.Point(4, 4)
            Me.LabelForm_StartingPostPeriod.Name = "LabelForm_StartingPostPeriod"
            Me.LabelForm_StartingPostPeriod.Size = New System.Drawing.Size(106, 20)
            Me.LabelForm_StartingPostPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_StartingPostPeriod.TabIndex = 1
            Me.LabelForm_StartingPostPeriod.Text = "Starting Post Period:"
            '
            'CheckBoxForm_Office
            '
            Me.CheckBoxForm_Office.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxForm_Office.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_Office.CheckValue = 0
            Me.CheckBoxForm_Office.CheckValueChecked = 1
            Me.CheckBoxForm_Office.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_Office.CheckValueUnchecked = 0
            Me.CheckBoxForm_Office.ChildControls = CType(resources.GetObject("CheckBoxForm_Office.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Office.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_Office.Location = New System.Drawing.Point(4, 108)
            Me.CheckBoxForm_Office.Name = "CheckBoxForm_Office"
            Me.CheckBoxForm_Office.OldestSibling = Nothing
            Me.CheckBoxForm_Office.SecurityEnabled = True
            Me.CheckBoxForm_Office.SiblingControls = CType(resources.GetObject("CheckBoxForm_Office.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Office.Size = New System.Drawing.Size(85, 20)
            Me.CheckBoxForm_Office.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_Office.TabIndex = 14
            Me.CheckBoxForm_Office.TabOnEnter = True
            Me.CheckBoxForm_Office.Text = "Office"
            '
            'LabelForm_EndingPostPeriod
            '
            Me.LabelForm_EndingPostPeriod.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_EndingPostPeriod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_EndingPostPeriod.Location = New System.Drawing.Point(4, 30)
            Me.LabelForm_EndingPostPeriod.Name = "LabelForm_EndingPostPeriod"
            Me.LabelForm_EndingPostPeriod.Size = New System.Drawing.Size(106, 20)
            Me.LabelForm_EndingPostPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_EndingPostPeriod.TabIndex = 6
            Me.LabelForm_EndingPostPeriod.Text = "Ending Post Period:"
            '
            'ComboBoxForm_EndingPostPeriod
            '
            Me.ComboBoxForm_EndingPostPeriod.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_EndingPostPeriod.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_EndingPostPeriod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_EndingPostPeriod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_EndingPostPeriod.AutoFindItemInDataSource = False
            Me.ComboBoxForm_EndingPostPeriod.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_EndingPostPeriod.BookmarkingEnabled = False
            Me.ComboBoxForm_EndingPostPeriod.ClientCode = ""
            Me.ComboBoxForm_EndingPostPeriod.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.PostPeriod
            Me.ComboBoxForm_EndingPostPeriod.DisableMouseWheel = False
            Me.ComboBoxForm_EndingPostPeriod.DisplayMember = "Description"
            Me.ComboBoxForm_EndingPostPeriod.DisplayName = ""
            Me.ComboBoxForm_EndingPostPeriod.DivisionCode = ""
            Me.ComboBoxForm_EndingPostPeriod.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_EndingPostPeriod.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_EndingPostPeriod.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_EndingPostPeriod.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_EndingPostPeriod.FocusHighlightEnabled = True
            Me.ComboBoxForm_EndingPostPeriod.FormattingEnabled = True
            Me.ComboBoxForm_EndingPostPeriod.ItemHeight = 14
            Me.ComboBoxForm_EndingPostPeriod.Location = New System.Drawing.Point(116, 30)
            Me.ComboBoxForm_EndingPostPeriod.Name = "ComboBoxForm_EndingPostPeriod"
            Me.ComboBoxForm_EndingPostPeriod.ReadOnly = False
            Me.ComboBoxForm_EndingPostPeriod.SecurityEnabled = True
            Me.ComboBoxForm_EndingPostPeriod.Size = New System.Drawing.Size(109, 20)
            Me.ComboBoxForm_EndingPostPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_EndingPostPeriod.TabIndex = 7
            Me.ComboBoxForm_EndingPostPeriod.TabOnEnter = True
            Me.ComboBoxForm_EndingPostPeriod.ValueMember = "Code"
            Me.ComboBoxForm_EndingPostPeriod.WatermarkText = "Select Post Period"
            '
            'LabelForm_Type
            '
            Me.LabelForm_Type.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Type.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Type.Location = New System.Drawing.Point(4, 56)
            Me.LabelForm_Type.Name = "LabelForm_Type"
            Me.LabelForm_Type.Size = New System.Drawing.Size(106, 20)
            Me.LabelForm_Type.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Type.TabIndex = 10
            Me.LabelForm_Type.Text = "Type:"
            '
            'RadioButtonForm_Standard
            '
            Me.RadioButtonForm_Standard.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonForm_Standard.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonForm_Standard.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonForm_Standard.Checked = True
            Me.RadioButtonForm_Standard.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonForm_Standard.CheckValue = "Y"
            Me.RadioButtonForm_Standard.Location = New System.Drawing.Point(116, 56)
            Me.RadioButtonForm_Standard.Name = "RadioButtonForm_Standard"
            Me.RadioButtonForm_Standard.SecurityEnabled = True
            Me.RadioButtonForm_Standard.Size = New System.Drawing.Size(87, 20)
            Me.RadioButtonForm_Standard.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonForm_Standard.TabIndex = 11
            Me.RadioButtonForm_Standard.TabOnEnter = True
            Me.RadioButtonForm_Standard.Text = "Standard"
            '
            'RadioButtonForm_AlternateDirectCost
            '
            Me.RadioButtonForm_AlternateDirectCost.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonForm_AlternateDirectCost.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonForm_AlternateDirectCost.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonForm_AlternateDirectCost.Location = New System.Drawing.Point(209, 56)
            Me.RadioButtonForm_AlternateDirectCost.Name = "RadioButtonForm_AlternateDirectCost"
            Me.RadioButtonForm_AlternateDirectCost.SecurityEnabled = True
            Me.RadioButtonForm_AlternateDirectCost.Size = New System.Drawing.Size(143, 20)
            Me.RadioButtonForm_AlternateDirectCost.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonForm_AlternateDirectCost.TabIndex = 12
            Me.RadioButtonForm_AlternateDirectCost.TabOnEnter = True
            Me.RadioButtonForm_AlternateDirectCost.TabStop = False
            Me.RadioButtonForm_AlternateDirectCost.Text = "Alternate Direct Cost"
            '
            'LabelForm_GroupByOptions
            '
            Me.LabelForm_GroupByOptions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_GroupByOptions.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_GroupByOptions.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_GroupByOptions.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelForm_GroupByOptions.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelForm_GroupByOptions.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_GroupByOptions.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_GroupByOptions.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_GroupByOptions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_GroupByOptions.Location = New System.Drawing.Point(4, 82)
            Me.LabelForm_GroupByOptions.Name = "LabelForm_GroupByOptions"
            Me.LabelForm_GroupByOptions.Size = New System.Drawing.Size(993, 20)
            Me.LabelForm_GroupByOptions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_GroupByOptions.TabIndex = 13
            Me.LabelForm_GroupByOptions.Text = "Group By Options"
            '
            'CheckBoxForm_Client
            '
            Me.CheckBoxForm_Client.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxForm_Client.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_Client.CheckValue = 0
            Me.CheckBoxForm_Client.CheckValueChecked = 1
            Me.CheckBoxForm_Client.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_Client.CheckValueUnchecked = 0
            Me.CheckBoxForm_Client.ChildControls = CType(resources.GetObject("CheckBoxForm_Client.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Client.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_Client.Location = New System.Drawing.Point(95, 108)
            Me.CheckBoxForm_Client.Name = "CheckBoxForm_Client"
            Me.CheckBoxForm_Client.OldestSibling = Nothing
            Me.CheckBoxForm_Client.SecurityEnabled = True
            Me.CheckBoxForm_Client.SiblingControls = CType(resources.GetObject("CheckBoxForm_Client.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Client.Size = New System.Drawing.Size(85, 20)
            Me.CheckBoxForm_Client.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_Client.TabIndex = 15
            Me.CheckBoxForm_Client.TabOnEnter = True
            Me.CheckBoxForm_Client.Text = "Client"
            '
            'CheckBoxForm_Division
            '
            Me.CheckBoxForm_Division.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxForm_Division.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_Division.CheckValue = 0
            Me.CheckBoxForm_Division.CheckValueChecked = 1
            Me.CheckBoxForm_Division.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_Division.CheckValueUnchecked = 0
            Me.CheckBoxForm_Division.ChildControls = CType(resources.GetObject("CheckBoxForm_Division.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Division.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_Division.Location = New System.Drawing.Point(186, 108)
            Me.CheckBoxForm_Division.Name = "CheckBoxForm_Division"
            Me.CheckBoxForm_Division.OldestSibling = Nothing
            Me.CheckBoxForm_Division.SecurityEnabled = True
            Me.CheckBoxForm_Division.SiblingControls = CType(resources.GetObject("CheckBoxForm_Division.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Division.Size = New System.Drawing.Size(75, 20)
            Me.CheckBoxForm_Division.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_Division.TabIndex = 16
            Me.CheckBoxForm_Division.TabOnEnter = True
            Me.CheckBoxForm_Division.Text = "Division"
            '
            'CheckBoxForm_Product
            '
            Me.CheckBoxForm_Product.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxForm_Product.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_Product.CheckValue = 0
            Me.CheckBoxForm_Product.CheckValueChecked = 1
            Me.CheckBoxForm_Product.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_Product.CheckValueUnchecked = 0
            Me.CheckBoxForm_Product.ChildControls = CType(resources.GetObject("CheckBoxForm_Product.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Product.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_Product.Location = New System.Drawing.Point(267, 108)
            Me.CheckBoxForm_Product.Name = "CheckBoxForm_Product"
            Me.CheckBoxForm_Product.OldestSibling = Nothing
            Me.CheckBoxForm_Product.SecurityEnabled = True
            Me.CheckBoxForm_Product.SiblingControls = CType(resources.GetObject("CheckBoxForm_Product.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Product.Size = New System.Drawing.Size(75, 20)
            Me.CheckBoxForm_Product.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_Product.TabIndex = 17
            Me.CheckBoxForm_Product.TabOnEnter = True
            Me.CheckBoxForm_Product.Text = "Product"
            '
            'CheckBoxForm_Type
            '
            Me.CheckBoxForm_Type.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxForm_Type.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_Type.CheckValue = 0
            Me.CheckBoxForm_Type.CheckValueChecked = 1
            Me.CheckBoxForm_Type.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_Type.CheckValueUnchecked = 0
            Me.CheckBoxForm_Type.ChildControls = CType(resources.GetObject("CheckBoxForm_Type.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Type.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_Type.Location = New System.Drawing.Point(429, 108)
            Me.CheckBoxForm_Type.Name = "CheckBoxForm_Type"
            Me.CheckBoxForm_Type.OldestSibling = Nothing
            Me.CheckBoxForm_Type.SecurityEnabled = True
            Me.CheckBoxForm_Type.SiblingControls = CType(resources.GetObject("CheckBoxForm_Type.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Type.Size = New System.Drawing.Size(121, 20)
            Me.CheckBoxForm_Type.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_Type.TabIndex = 19
            Me.CheckBoxForm_Type.TabOnEnter = True
            Me.CheckBoxForm_Type.Text = "Type"
            '
            'CheckBoxForm_SalesClass
            '
            Me.CheckBoxForm_SalesClass.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxForm_SalesClass.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_SalesClass.CheckValue = 0
            Me.CheckBoxForm_SalesClass.CheckValueChecked = 1
            Me.CheckBoxForm_SalesClass.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_SalesClass.CheckValueUnchecked = 0
            Me.CheckBoxForm_SalesClass.ChildControls = CType(resources.GetObject("CheckBoxForm_SalesClass.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_SalesClass.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_SalesClass.Location = New System.Drawing.Point(4, 134)
            Me.CheckBoxForm_SalesClass.Name = "CheckBoxForm_SalesClass"
            Me.CheckBoxForm_SalesClass.OldestSibling = Nothing
            Me.CheckBoxForm_SalesClass.SecurityEnabled = True
            Me.CheckBoxForm_SalesClass.SiblingControls = CType(resources.GetObject("CheckBoxForm_SalesClass.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_SalesClass.Size = New System.Drawing.Size(85, 20)
            Me.CheckBoxForm_SalesClass.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_SalesClass.TabIndex = 20
            Me.CheckBoxForm_SalesClass.TabOnEnter = True
            Me.CheckBoxForm_SalesClass.Text = "Sales Class"
            '
            'CheckBoxForm_PostPeriod
            '
            Me.CheckBoxForm_PostPeriod.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxForm_PostPeriod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_PostPeriod.CheckValue = 0
            Me.CheckBoxForm_PostPeriod.CheckValueChecked = 1
            Me.CheckBoxForm_PostPeriod.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_PostPeriod.CheckValueUnchecked = 0
            Me.CheckBoxForm_PostPeriod.ChildControls = CType(resources.GetObject("CheckBoxForm_PostPeriod.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_PostPeriod.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_PostPeriod.Location = New System.Drawing.Point(95, 134)
            Me.CheckBoxForm_PostPeriod.Name = "CheckBoxForm_PostPeriod"
            Me.CheckBoxForm_PostPeriod.OldestSibling = Nothing
            Me.CheckBoxForm_PostPeriod.SecurityEnabled = True
            Me.CheckBoxForm_PostPeriod.SiblingControls = CType(resources.GetObject("CheckBoxForm_PostPeriod.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_PostPeriod.Size = New System.Drawing.Size(85, 20)
            Me.CheckBoxForm_PostPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_PostPeriod.TabIndex = 21
            Me.CheckBoxForm_PostPeriod.TabOnEnter = True
            Me.CheckBoxForm_PostPeriod.Text = "Post Period"
            '
            'CheckBoxForm_Year
            '
            Me.CheckBoxForm_Year.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxForm_Year.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_Year.CheckValue = 0
            Me.CheckBoxForm_Year.CheckValueChecked = 1
            Me.CheckBoxForm_Year.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_Year.CheckValueUnchecked = 0
            Me.CheckBoxForm_Year.ChildControls = CType(resources.GetObject("CheckBoxForm_Year.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Year.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_Year.Location = New System.Drawing.Point(186, 134)
            Me.CheckBoxForm_Year.Name = "CheckBoxForm_Year"
            Me.CheckBoxForm_Year.OldestSibling = Nothing
            Me.CheckBoxForm_Year.SecurityEnabled = True
            Me.CheckBoxForm_Year.SiblingControls = CType(resources.GetObject("CheckBoxForm_Year.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Year.Size = New System.Drawing.Size(75, 20)
            Me.CheckBoxForm_Year.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_Year.TabIndex = 22
            Me.CheckBoxForm_Year.TabOnEnter = True
            Me.CheckBoxForm_Year.Text = "Year"
            '
            'ButtonForm_2Years
            '
            Me.ButtonForm_2Years.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_2Years.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_2Years.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_2Years.Location = New System.Drawing.Point(312, 30)
            Me.ButtonForm_2Years.Name = "ButtonForm_2Years"
            Me.ButtonForm_2Years.SecurityEnabled = True
            Me.ButtonForm_2Years.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_2Years.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_2Years.TabIndex = 9
            Me.ButtonForm_2Years.Text = "2 Years"
            '
            'ButtonForm_1Year
            '
            Me.ButtonForm_1Year.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_1Year.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_1Year.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_1Year.Location = New System.Drawing.Point(312, 4)
            Me.ButtonForm_1Year.Name = "ButtonForm_1Year"
            Me.ButtonForm_1Year.SecurityEnabled = True
            Me.ButtonForm_1Year.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_1Year.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_1Year.TabIndex = 4
            Me.ButtonForm_1Year.Text = "1 Year"
            '
            'ButtonForm_MTD
            '
            Me.ButtonForm_MTD.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_MTD.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_MTD.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_MTD.Location = New System.Drawing.Point(231, 30)
            Me.ButtonForm_MTD.Name = "ButtonForm_MTD"
            Me.ButtonForm_MTD.SecurityEnabled = True
            Me.ButtonForm_MTD.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_MTD.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_MTD.TabIndex = 8
            Me.ButtonForm_MTD.Text = "MTD"
            '
            'ButtonForm_YTD
            '
            Me.ButtonForm_YTD.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_YTD.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_YTD.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_YTD.Location = New System.Drawing.Point(231, 4)
            Me.ButtonForm_YTD.Name = "ButtonForm_YTD"
            Me.ButtonForm_YTD.SecurityEnabled = True
            Me.ButtonForm_YTD.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_YTD.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_YTD.TabIndex = 3
            Me.ButtonForm_YTD.Text = "YTD"
            '
            'ButtonForm_2YTD
            '
            Me.ButtonForm_2YTD.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_2YTD.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_2YTD.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_2YTD.Location = New System.Drawing.Point(393, 4)
            Me.ButtonForm_2YTD.Name = "ButtonForm_2YTD"
            Me.ButtonForm_2YTD.SecurityEnabled = True
            Me.ButtonForm_2YTD.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_2YTD.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_2YTD.TabIndex = 5
            Me.ButtonForm_2YTD.Text = "2 YTD"
            '
            'CheckBoxForm_Campaign
            '
            Me.CheckBoxForm_Campaign.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxForm_Campaign.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_Campaign.CheckValue = 0
            Me.CheckBoxForm_Campaign.CheckValueChecked = 1
            Me.CheckBoxForm_Campaign.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_Campaign.CheckValueUnchecked = 0
            Me.CheckBoxForm_Campaign.ChildControls = CType(resources.GetObject("CheckBoxForm_Campaign.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Campaign.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_Campaign.Location = New System.Drawing.Point(348, 108)
            Me.CheckBoxForm_Campaign.Name = "CheckBoxForm_Campaign"
            Me.CheckBoxForm_Campaign.OldestSibling = Nothing
            Me.CheckBoxForm_Campaign.SecurityEnabled = True
            Me.CheckBoxForm_Campaign.SiblingControls = CType(resources.GetObject("CheckBoxForm_Campaign.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_Campaign.Size = New System.Drawing.Size(75, 20)
            Me.CheckBoxForm_Campaign.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_Campaign.TabIndex = 18
            Me.CheckBoxForm_Campaign.TabOnEnter = True
            Me.CheckBoxForm_Campaign.Text = "Campaign"
            '
            'CheckBoxForm_ProductUDF
            '
            Me.CheckBoxForm_ProductUDF.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxForm_ProductUDF.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_ProductUDF.CheckValue = 0
            Me.CheckBoxForm_ProductUDF.CheckValueChecked = 1
            Me.CheckBoxForm_ProductUDF.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_ProductUDF.CheckValueUnchecked = 0
            Me.CheckBoxForm_ProductUDF.ChildControls = CType(resources.GetObject("CheckBoxForm_ProductUDF.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_ProductUDF.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_ProductUDF.Location = New System.Drawing.Point(429, 134)
            Me.CheckBoxForm_ProductUDF.Name = "CheckBoxForm_ProductUDF"
            Me.CheckBoxForm_ProductUDF.OldestSibling = Nothing
            Me.CheckBoxForm_ProductUDF.SecurityEnabled = True
            Me.CheckBoxForm_ProductUDF.SiblingControls = CType(resources.GetObject("CheckBoxForm_ProductUDF.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_ProductUDF.Size = New System.Drawing.Size(121, 20)
            Me.CheckBoxForm_ProductUDF.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_ProductUDF.TabIndex = 24
            Me.CheckBoxForm_ProductUDF.TabOnEnter = True
            Me.CheckBoxForm_ProductUDF.Text = "Product UDF"
            '
            'CheckBoxForm_AccountExecutive
            '
            Me.CheckBoxForm_AccountExecutive.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxForm_AccountExecutive.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_AccountExecutive.CheckValue = 0
            Me.CheckBoxForm_AccountExecutive.CheckValueChecked = 1
            Me.CheckBoxForm_AccountExecutive.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_AccountExecutive.CheckValueUnchecked = 0
            Me.CheckBoxForm_AccountExecutive.ChildControls = CType(resources.GetObject("CheckBoxForm_AccountExecutive.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_AccountExecutive.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_AccountExecutive.Location = New System.Drawing.Point(267, 134)
            Me.CheckBoxForm_AccountExecutive.Name = "CheckBoxForm_AccountExecutive"
            Me.CheckBoxForm_AccountExecutive.OldestSibling = Nothing
            Me.CheckBoxForm_AccountExecutive.SecurityEnabled = True
            Me.CheckBoxForm_AccountExecutive.SiblingControls = CType(resources.GetObject("CheckBoxForm_AccountExecutive.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_AccountExecutive.Size = New System.Drawing.Size(156, 20)
            Me.CheckBoxForm_AccountExecutive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_AccountExecutive.TabIndex = 23
            Me.CheckBoxForm_AccountExecutive.TabOnEnter = True
            Me.CheckBoxForm_AccountExecutive.Text = "Account Executive"
            '
            'LabelForm_IncludeOptions
            '
            Me.LabelForm_IncludeOptions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_IncludeOptions.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_IncludeOptions.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_IncludeOptions.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelForm_IncludeOptions.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelForm_IncludeOptions.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_IncludeOptions.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_IncludeOptions.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_IncludeOptions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_IncludeOptions.Location = New System.Drawing.Point(4, 160)
            Me.LabelForm_IncludeOptions.Name = "LabelForm_IncludeOptions"
            Me.LabelForm_IncludeOptions.Size = New System.Drawing.Size(993, 20)
            Me.LabelForm_IncludeOptions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_IncludeOptions.TabIndex = 25
            Me.LabelForm_IncludeOptions.Text = "Include Options"
            '
            'CheckBoxForm_BilledIncomeRecognized
            '
            Me.CheckBoxForm_BilledIncomeRecognized.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxForm_BilledIncomeRecognized.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_BilledIncomeRecognized.CheckValue = 0
            Me.CheckBoxForm_BilledIncomeRecognized.CheckValueChecked = 1
            Me.CheckBoxForm_BilledIncomeRecognized.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_BilledIncomeRecognized.CheckValueUnchecked = 0
            Me.CheckBoxForm_BilledIncomeRecognized.ChildControls = Nothing
            Me.CheckBoxForm_BilledIncomeRecognized.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_BilledIncomeRecognized.Location = New System.Drawing.Point(244, 186)
            Me.CheckBoxForm_BilledIncomeRecognized.Name = "CheckBoxForm_BilledIncomeRecognized"
            Me.CheckBoxForm_BilledIncomeRecognized.OldestSibling = Nothing
            Me.CheckBoxForm_BilledIncomeRecognized.SecurityEnabled = True
            Me.CheckBoxForm_BilledIncomeRecognized.SiblingControls = Nothing
            Me.CheckBoxForm_BilledIncomeRecognized.Size = New System.Drawing.Size(306, 20)
            Me.CheckBoxForm_BilledIncomeRecognized.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_BilledIncomeRecognized.TabIndex = 28
            Me.CheckBoxForm_BilledIncomeRecognized.TabOnEnter = True
            Me.CheckBoxForm_BilledIncomeRecognized.Text = "Billed Income Recognized"
            '
            'CheckBoxForm_GLEntries
            '
            Me.CheckBoxForm_GLEntries.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxForm_GLEntries.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_GLEntries.CheckValue = 0
            Me.CheckBoxForm_GLEntries.CheckValueChecked = 1
            Me.CheckBoxForm_GLEntries.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_GLEntries.CheckValueUnchecked = 0
            Me.CheckBoxForm_GLEntries.ChildControls = Nothing
            Me.CheckBoxForm_GLEntries.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_GLEntries.Location = New System.Drawing.Point(132, 186)
            Me.CheckBoxForm_GLEntries.Name = "CheckBoxForm_GLEntries"
            Me.CheckBoxForm_GLEntries.OldestSibling = Nothing
            Me.CheckBoxForm_GLEntries.SecurityEnabled = True
            Me.CheckBoxForm_GLEntries.SiblingControls = Nothing
            Me.CheckBoxForm_GLEntries.Size = New System.Drawing.Size(106, 20)
            Me.CheckBoxForm_GLEntries.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_GLEntries.TabIndex = 27
            Me.CheckBoxForm_GLEntries.TabOnEnter = True
            Me.CheckBoxForm_GLEntries.Text = "GL Entries"
            '
            'CheckBoxForm_ManualInvoices
            '
            Me.CheckBoxForm_ManualInvoices.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxForm_ManualInvoices.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_ManualInvoices.CheckValue = 0
            Me.CheckBoxForm_ManualInvoices.CheckValueChecked = 1
            Me.CheckBoxForm_ManualInvoices.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_ManualInvoices.CheckValueUnchecked = 0
            Me.CheckBoxForm_ManualInvoices.ChildControls = CType(resources.GetObject("CheckBoxForm_ManualInvoices.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_ManualInvoices.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_ManualInvoices.Location = New System.Drawing.Point(4, 186)
            Me.CheckBoxForm_ManualInvoices.Name = "CheckBoxForm_ManualInvoices"
            Me.CheckBoxForm_ManualInvoices.OldestSibling = Nothing
            Me.CheckBoxForm_ManualInvoices.SecurityEnabled = True
            Me.CheckBoxForm_ManualInvoices.SiblingControls = CType(resources.GetObject("CheckBoxForm_ManualInvoices.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_ManualInvoices.Size = New System.Drawing.Size(122, 20)
            Me.CheckBoxForm_ManualInvoices.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_ManualInvoices.TabIndex = 26
            Me.CheckBoxForm_ManualInvoices.TabOnEnter = True
            Me.CheckBoxForm_ManualInvoices.Text = "Manual Invoices"
            '
            'LabelForm_ReportOptions
            '
            Me.LabelForm_ReportOptions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_ReportOptions.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_ReportOptions.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_ReportOptions.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelForm_ReportOptions.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelForm_ReportOptions.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_ReportOptions.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_ReportOptions.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_ReportOptions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_ReportOptions.Location = New System.Drawing.Point(4, 212)
            Me.LabelForm_ReportOptions.Name = "LabelForm_ReportOptions"
            Me.LabelForm_ReportOptions.Size = New System.Drawing.Size(993, 20)
            Me.LabelForm_ReportOptions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_ReportOptions.TabIndex = 29
            Me.LabelForm_ReportOptions.Text = "Report Options"
            '
            'LabelForm_OverheadSet
            '
            Me.LabelForm_OverheadSet.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_OverheadSet.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_OverheadSet.Location = New System.Drawing.Point(267, 241)
            Me.LabelForm_OverheadSet.Name = "LabelForm_OverheadSet"
            Me.LabelForm_OverheadSet.Size = New System.Drawing.Size(75, 20)
            Me.LabelForm_OverheadSet.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_OverheadSet.TabIndex = 33
            Me.LabelForm_OverheadSet.Text = "Overhead Set:"
            '
            'ComboBox_OverheadSet
            '
            Me.ComboBox_OverheadSet.AddInactiveItemsOnSelectedValue = False
            Me.ComboBox_OverheadSet.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBox_OverheadSet.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBox_OverheadSet.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBox_OverheadSet.AutoFindItemInDataSource = False
            Me.ComboBox_OverheadSet.AutoSelectSingleItemDatasource = False
            Me.ComboBox_OverheadSet.BookmarkingEnabled = False
            Me.ComboBox_OverheadSet.ClientCode = ""
            Me.ComboBox_OverheadSet.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.PostPeriod
            Me.ComboBox_OverheadSet.DisableMouseWheel = False
            Me.ComboBox_OverheadSet.DisplayMember = "Description"
            Me.ComboBox_OverheadSet.DisplayName = ""
            Me.ComboBox_OverheadSet.DivisionCode = ""
            Me.ComboBox_OverheadSet.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBox_OverheadSet.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBox_OverheadSet.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBox_OverheadSet.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBox_OverheadSet.FocusHighlightEnabled = True
            Me.ComboBox_OverheadSet.FormattingEnabled = True
            Me.ComboBox_OverheadSet.ItemHeight = 14
            Me.ComboBox_OverheadSet.Location = New System.Drawing.Point(348, 241)
            Me.ComboBox_OverheadSet.Name = "ComboBox_OverheadSet"
            Me.ComboBox_OverheadSet.ReadOnly = False
            Me.ComboBox_OverheadSet.SecurityEnabled = True
            Me.ComboBox_OverheadSet.Size = New System.Drawing.Size(649, 20)
            Me.ComboBox_OverheadSet.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBox_OverheadSet.TabIndex = 34
            Me.ComboBox_OverheadSet.TabOnEnter = True
            Me.ComboBox_OverheadSet.ValueMember = "Code"
            Me.ComboBox_OverheadSet.WatermarkText = "Select Post Period"
            '
            'PanelForm_PrimaryDisplayOption
            '
            Me.PanelForm_PrimaryDisplayOption.BackColor = System.Drawing.Color.White
            Me.PanelForm_PrimaryDisplayOption.Controls.Add(Me.RadioButtonPrimaryDisplayOption_OverheadFactor)
            Me.PanelForm_PrimaryDisplayOption.Controls.Add(Me.RadioButtonPrimaryDisplayOption_OverheadAllocation)
            Me.PanelForm_PrimaryDisplayOption.Location = New System.Drawing.Point(4, 238)
            Me.PanelForm_PrimaryDisplayOption.Name = "PanelForm_PrimaryDisplayOption"
            Me.PanelForm_PrimaryDisplayOption.Size = New System.Drawing.Size(257, 25)
            Me.PanelForm_PrimaryDisplayOption.TabIndex = 30
            '
            'RadioButtonPrimaryDisplayOption_OverheadFactor
            '
            Me.RadioButtonPrimaryDisplayOption_OverheadFactor.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonPrimaryDisplayOption_OverheadFactor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonPrimaryDisplayOption_OverheadFactor.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonPrimaryDisplayOption_OverheadFactor.Location = New System.Drawing.Point(140, 3)
            Me.RadioButtonPrimaryDisplayOption_OverheadFactor.Name = "RadioButtonPrimaryDisplayOption_OverheadFactor"
            Me.RadioButtonPrimaryDisplayOption_OverheadFactor.SecurityEnabled = True
            Me.RadioButtonPrimaryDisplayOption_OverheadFactor.Size = New System.Drawing.Size(114, 20)
            Me.RadioButtonPrimaryDisplayOption_OverheadFactor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonPrimaryDisplayOption_OverheadFactor.TabIndex = 1
            Me.RadioButtonPrimaryDisplayOption_OverheadFactor.TabOnEnter = True
            Me.RadioButtonPrimaryDisplayOption_OverheadFactor.TabStop = False
            Me.RadioButtonPrimaryDisplayOption_OverheadFactor.Text = "Overhead Factor"
            '
            'RadioButtonPrimaryDisplayOption_OverheadAllocation
            '
            Me.RadioButtonPrimaryDisplayOption_OverheadAllocation.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonPrimaryDisplayOption_OverheadAllocation.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonPrimaryDisplayOption_OverheadAllocation.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonPrimaryDisplayOption_OverheadAllocation.Checked = True
            Me.RadioButtonPrimaryDisplayOption_OverheadAllocation.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonPrimaryDisplayOption_OverheadAllocation.CheckValue = "Y"
            Me.RadioButtonPrimaryDisplayOption_OverheadAllocation.Location = New System.Drawing.Point(0, 3)
            Me.RadioButtonPrimaryDisplayOption_OverheadAllocation.Name = "RadioButtonPrimaryDisplayOption_OverheadAllocation"
            Me.RadioButtonPrimaryDisplayOption_OverheadAllocation.SecurityEnabled = True
            Me.RadioButtonPrimaryDisplayOption_OverheadAllocation.Size = New System.Drawing.Size(134, 20)
            Me.RadioButtonPrimaryDisplayOption_OverheadAllocation.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonPrimaryDisplayOption_OverheadAllocation.TabIndex = 0
            Me.RadioButtonPrimaryDisplayOption_OverheadAllocation.TabOnEnter = True
            Me.RadioButtonPrimaryDisplayOption_OverheadAllocation.Text = "Overhead Allocation"
            '
            'PanelForm_DataOption
            '
            Me.PanelForm_DataOption.BackColor = System.Drawing.Color.White
            Me.PanelForm_DataOption.Controls.Add(Me.RadioButtonDataOption_Hours)
            Me.PanelForm_DataOption.Controls.Add(Me.RadioButtonDataOption_Cost)
            Me.PanelForm_DataOption.Location = New System.Drawing.Point(4, 267)
            Me.PanelForm_DataOption.Name = "PanelForm_DataOption"
            Me.PanelForm_DataOption.Size = New System.Drawing.Size(257, 25)
            Me.PanelForm_DataOption.TabIndex = 31
            '
            'RadioButtonDataOption_Hours
            '
            Me.RadioButtonDataOption_Hours.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonDataOption_Hours.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonDataOption_Hours.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonDataOption_Hours.Location = New System.Drawing.Point(140, 3)
            Me.RadioButtonDataOption_Hours.Name = "RadioButtonDataOption_Hours"
            Me.RadioButtonDataOption_Hours.SecurityEnabled = True
            Me.RadioButtonDataOption_Hours.Size = New System.Drawing.Size(114, 20)
            Me.RadioButtonDataOption_Hours.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonDataOption_Hours.TabIndex = 1
            Me.RadioButtonDataOption_Hours.TabOnEnter = True
            Me.RadioButtonDataOption_Hours.TabStop = False
            Me.RadioButtonDataOption_Hours.Text = "Hours"
            '
            'RadioButtonDataOption_Cost
            '
            Me.RadioButtonDataOption_Cost.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonDataOption_Cost.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonDataOption_Cost.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonDataOption_Cost.Checked = True
            Me.RadioButtonDataOption_Cost.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonDataOption_Cost.CheckValue = "Y"
            Me.RadioButtonDataOption_Cost.Location = New System.Drawing.Point(0, 3)
            Me.RadioButtonDataOption_Cost.Name = "RadioButtonDataOption_Cost"
            Me.RadioButtonDataOption_Cost.SecurityEnabled = True
            Me.RadioButtonDataOption_Cost.Size = New System.Drawing.Size(134, 20)
            Me.RadioButtonDataOption_Cost.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonDataOption_Cost.TabIndex = 0
            Me.RadioButtonDataOption_Cost.TabOnEnter = True
            Me.RadioButtonDataOption_Cost.Text = "Cost"
            '
            'PanelForm_CoopOptions
            '
            Me.PanelForm_CoopOptions.BackColor = System.Drawing.Color.White
            Me.PanelForm_CoopOptions.Controls.Add(Me.RadioButtonCoopOptions_BreakoutCoop)
            Me.PanelForm_CoopOptions.Controls.Add(Me.RadioButtonCoopOptions_CombineCoop)
            Me.PanelForm_CoopOptions.Location = New System.Drawing.Point(4, 295)
            Me.PanelForm_CoopOptions.Name = "PanelForm_CoopOptions"
            Me.PanelForm_CoopOptions.Size = New System.Drawing.Size(257, 25)
            Me.PanelForm_CoopOptions.TabIndex = 32
            '
            'RadioButtonCoopOptions_BreakoutCoop
            '
            Me.RadioButtonCoopOptions_BreakoutCoop.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonCoopOptions_BreakoutCoop.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonCoopOptions_BreakoutCoop.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonCoopOptions_BreakoutCoop.Location = New System.Drawing.Point(140, 3)
            Me.RadioButtonCoopOptions_BreakoutCoop.Name = "RadioButtonCoopOptions_BreakoutCoop"
            Me.RadioButtonCoopOptions_BreakoutCoop.SecurityEnabled = True
            Me.RadioButtonCoopOptions_BreakoutCoop.Size = New System.Drawing.Size(114, 20)
            Me.RadioButtonCoopOptions_BreakoutCoop.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonCoopOptions_BreakoutCoop.TabIndex = 1
            Me.RadioButtonCoopOptions_BreakoutCoop.TabOnEnter = True
            Me.RadioButtonCoopOptions_BreakoutCoop.TabStop = False
            Me.RadioButtonCoopOptions_BreakoutCoop.Text = "Breakout Co-op"
            '
            'RadioButtonCoopOptions_CombineCoop
            '
            Me.RadioButtonCoopOptions_CombineCoop.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonCoopOptions_CombineCoop.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonCoopOptions_CombineCoop.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonCoopOptions_CombineCoop.Checked = True
            Me.RadioButtonCoopOptions_CombineCoop.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonCoopOptions_CombineCoop.CheckValue = "Y"
            Me.RadioButtonCoopOptions_CombineCoop.Location = New System.Drawing.Point(0, 3)
            Me.RadioButtonCoopOptions_CombineCoop.Name = "RadioButtonCoopOptions_CombineCoop"
            Me.RadioButtonCoopOptions_CombineCoop.SecurityEnabled = True
            Me.RadioButtonCoopOptions_CombineCoop.Size = New System.Drawing.Size(134, 20)
            Me.RadioButtonCoopOptions_CombineCoop.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonCoopOptions_CombineCoop.TabIndex = 0
            Me.RadioButtonCoopOptions_CombineCoop.TabOnEnter = True
            Me.RadioButtonCoopOptions_CombineCoop.Text = "Combine Co-op"
            '
            'PanelForm_TopSection
            '
            Me.PanelForm_TopSection.Controls.Add(Me.LabelTopSection_Report)
            Me.PanelForm_TopSection.Controls.Add(Me.ComboBoxTopSection_Report)
            Me.PanelForm_TopSection.Dock = System.Windows.Forms.DockStyle.Top
            Me.PanelForm_TopSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelForm_TopSection.Name = "PanelForm_TopSection"
            Me.PanelForm_TopSection.Size = New System.Drawing.Size(1041, 37)
            Me.PanelForm_TopSection.TabIndex = 0
            Me.PanelForm_TopSection.Visible = False
            '
            'LabelTopSection_Report
            '
            Me.LabelTopSection_Report.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTopSection_Report.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTopSection_Report.Location = New System.Drawing.Point(12, 12)
            Me.LabelTopSection_Report.Name = "LabelTopSection_Report"
            Me.LabelTopSection_Report.Size = New System.Drawing.Size(106, 20)
            Me.LabelTopSection_Report.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTopSection_Report.TabIndex = 0
            Me.LabelTopSection_Report.Text = "Report:"
            '
            'ComboBoxTopSection_Report
            '
            Me.ComboBoxTopSection_Report.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxTopSection_Report.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxTopSection_Report.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxTopSection_Report.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxTopSection_Report.AutoFindItemInDataSource = False
            Me.ComboBoxTopSection_Report.AutoSelectSingleItemDatasource = False
            Me.ComboBoxTopSection_Report.BookmarkingEnabled = False
            Me.ComboBoxTopSection_Report.ClientCode = ""
            Me.ComboBoxTopSection_Report.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumObjects
            Me.ComboBoxTopSection_Report.DisableMouseWheel = False
            Me.ComboBoxTopSection_Report.DisplayMember = "Description"
            Me.ComboBoxTopSection_Report.DisplayName = ""
            Me.ComboBoxTopSection_Report.DivisionCode = ""
            Me.ComboBoxTopSection_Report.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxTopSection_Report.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxTopSection_Report.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxTopSection_Report.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxTopSection_Report.FocusHighlightEnabled = True
            Me.ComboBoxTopSection_Report.FormattingEnabled = True
            Me.ComboBoxTopSection_Report.ItemHeight = 14
            Me.ComboBoxTopSection_Report.Location = New System.Drawing.Point(124, 12)
            Me.ComboBoxTopSection_Report.Name = "ComboBoxTopSection_Report"
            Me.ComboBoxTopSection_Report.ReadOnly = False
            Me.ComboBoxTopSection_Report.SecurityEnabled = True
            Me.ComboBoxTopSection_Report.Size = New System.Drawing.Size(905, 20)
            Me.ComboBoxTopSection_Report.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxTopSection_Report.TabIndex = 1
            Me.ComboBoxTopSection_Report.TabOnEnter = True
            Me.ComboBoxTopSection_Report.ValueMember = "Code"
            Me.ComboBoxTopSection_Report.WatermarkText = "Select"
            '
            'PanelForm_BottomSection
            '
            Me.PanelForm_BottomSection.Controls.Add(Me.TabControlForm_JDA)
            Me.PanelForm_BottomSection.Controls.Add(Me.ButtonForm_OK)
            Me.PanelForm_BottomSection.Controls.Add(Me.ButtonForm_Cancel)
            Me.PanelForm_BottomSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelForm_BottomSection.Location = New System.Drawing.Point(0, 37)
            Me.PanelForm_BottomSection.Name = "PanelForm_BottomSection"
            Me.PanelForm_BottomSection.Size = New System.Drawing.Size(1041, 650)
            Me.PanelForm_BottomSection.TabIndex = 37
            '
            'TabControlForm_JDA
            '
            Me.TabControlForm_JDA.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlForm_JDA.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer))
            Me.TabControlForm_JDA.CanReorderTabs = False
            Me.TabControlForm_JDA.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlForm_JDA.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlForm_JDA.Controls.Add(Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions)
            Me.TabControlForm_JDA.Controls.Add(Me.TabControlPanelSelectOfficesTab_SelectClients)
            Me.TabControlForm_JDA.Controls.Add(Me.TabControlPanelSelectOfficesTab_SelectOffices)
            Me.TabControlForm_JDA.Location = New System.Drawing.Point(12, 6)
            Me.TabControlForm_JDA.Name = "TabControlForm_JDA"
            Me.TabControlForm_JDA.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlForm_JDA.SelectedTabIndex = 0
            Me.TabControlForm_JDA.Size = New System.Drawing.Size(1017, 606)
            Me.TabControlForm_JDA.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlForm_JDA.TabIndex = 39
            Me.TabControlForm_JDA.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlForm_JDA.Tabs.Add(Me.TabItemJDA_VersionAndOptionsTab)
            Me.TabControlForm_JDA.Tabs.Add(Me.TabItemJDA_SelectOfficesTab)
            Me.TabControlForm_JDA.Tabs.Add(Me.TabItemProductionCriteria_SelectClientsTab)
            '
            'TabControlPanelVersionAndOptionsTab_VersionAndOptions
            '
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.LabelForm_PriorPeriod2Start)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.ComboBoxForm_PriorPeriod2Start)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.ComboBoxForm_PriorPeriod2End)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.LabelForm_PriorPeriod2End)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.LabelForm_PriorPeriod1Start)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.ComboBoxForm_PriorPeriod1Start)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.ComboBoxForm_PriorPeriod1End)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.LabelForm_PriorPeriod1End)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.CheckBoxDirectExpenseOperatingOnly)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.LabelForm_StartingPostPeriod)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.CheckBoxForm_ExcludeNewBusiness)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.ButtonForm_MTD)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.ButtonForm_1Year)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.ComboBoxForm_StartingPostPeriod)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.LabelForm_OverheadSet)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.ButtonForm_YTD)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.ComboBox_OverheadSet)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.ButtonForm_2Years)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.PanelForm_PrimaryDisplayOption)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.CheckBoxForm_Year)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.PanelForm_DataOption)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.ButtonForm_2YTD)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.PanelForm_CoopOptions)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.CheckBoxForm_Office)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.LabelForm_ReportOptions)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.CheckBoxForm_PostPeriod)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.CheckBoxForm_BilledIncomeRecognized)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.CheckBoxForm_Campaign)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.CheckBoxForm_GLEntries)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.ComboBoxForm_EndingPostPeriod)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.CheckBoxForm_ManualInvoices)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.CheckBoxForm_SalesClass)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.LabelForm_IncludeOptions)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.CheckBoxForm_ProductUDF)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.LabelForm_EndingPostPeriod)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.CheckBoxForm_Type)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.CheckBoxForm_AccountExecutive)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.LabelForm_Type)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.CheckBoxForm_Product)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.CheckBoxForm_Division)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.RadioButtonForm_AlternateDirectCost)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.CheckBoxForm_Client)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.LabelForm_GroupByOptions)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.RadioButtonForm_Standard)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Name = "TabControlPanelVersionAndOptionsTab_VersionAndOptions"
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Size = New System.Drawing.Size(1017, 579)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Style.GradientAngle = 90
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.TabIndex = 0
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.TabItem = Me.TabItemJDA_VersionAndOptionsTab
            '
            'CheckBoxDirectExpenseOperatingOnly
            '
            Me.CheckBoxDirectExpenseOperatingOnly.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxDirectExpenseOperatingOnly.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxDirectExpenseOperatingOnly.CheckValue = 0
            Me.CheckBoxDirectExpenseOperatingOnly.CheckValueChecked = 1
            Me.CheckBoxDirectExpenseOperatingOnly.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxDirectExpenseOperatingOnly.CheckValueUnchecked = 0
            Me.CheckBoxDirectExpenseOperatingOnly.ChildControls = CType(resources.GetObject("CheckBoxDirectExpenseOperatingOnly.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxDirectExpenseOperatingOnly.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxDirectExpenseOperatingOnly.Location = New System.Drawing.Point(4, 350)
            Me.CheckBoxDirectExpenseOperatingOnly.Name = "CheckBoxDirectExpenseOperatingOnly"
            Me.CheckBoxDirectExpenseOperatingOnly.OldestSibling = Nothing
            Me.CheckBoxDirectExpenseOperatingOnly.SecurityEnabled = True
            Me.CheckBoxDirectExpenseOperatingOnly.SiblingControls = CType(resources.GetObject("CheckBoxDirectExpenseOperatingOnly.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxDirectExpenseOperatingOnly.Size = New System.Drawing.Size(254, 20)
            Me.CheckBoxDirectExpenseOperatingOnly.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxDirectExpenseOperatingOnly.TabIndex = 38
            Me.CheckBoxDirectExpenseOperatingOnly.TabOnEnter = True
            Me.CheckBoxDirectExpenseOperatingOnly.Text = "Direct Expense from Expense Operating Only"
            '
            'CheckBoxForm_ExcludeNewBusiness
            '
            Me.CheckBoxForm_ExcludeNewBusiness.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxForm_ExcludeNewBusiness.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_ExcludeNewBusiness.CheckValue = 0
            Me.CheckBoxForm_ExcludeNewBusiness.CheckValueChecked = 1
            Me.CheckBoxForm_ExcludeNewBusiness.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_ExcludeNewBusiness.CheckValueUnchecked = 0
            Me.CheckBoxForm_ExcludeNewBusiness.ChildControls = CType(resources.GetObject("CheckBoxForm_ExcludeNewBusiness.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_ExcludeNewBusiness.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_ExcludeNewBusiness.Location = New System.Drawing.Point(4, 324)
            Me.CheckBoxForm_ExcludeNewBusiness.Name = "CheckBoxForm_ExcludeNewBusiness"
            Me.CheckBoxForm_ExcludeNewBusiness.OldestSibling = Nothing
            Me.CheckBoxForm_ExcludeNewBusiness.SecurityEnabled = True
            Me.CheckBoxForm_ExcludeNewBusiness.SiblingControls = CType(resources.GetObject("CheckBoxForm_ExcludeNewBusiness.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_ExcludeNewBusiness.Size = New System.Drawing.Size(254, 20)
            Me.CheckBoxForm_ExcludeNewBusiness.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_ExcludeNewBusiness.TabIndex = 37
            Me.CheckBoxForm_ExcludeNewBusiness.TabOnEnter = True
            Me.CheckBoxForm_ExcludeNewBusiness.Text = "Exclude New Business"
            '
            'TabItemJDA_VersionAndOptionsTab
            '
            Me.TabItemJDA_VersionAndOptionsTab.AttachedControl = Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions
            Me.TabItemJDA_VersionAndOptionsTab.Name = "TabItemJDA_VersionAndOptionsTab"
            Me.TabItemJDA_VersionAndOptionsTab.Text = "Report Options"
            '
            'TabControlPanelSelectOfficesTab_SelectClients
            '
            Me.TabControlPanelSelectOfficesTab_SelectClients.Controls.Add(Me.CDPChooserControl_Production)
            Me.TabControlPanelSelectOfficesTab_SelectClients.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelSelectOfficesTab_SelectClients.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelSelectOfficesTab_SelectClients.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelSelectOfficesTab_SelectClients.Name = "TabControlPanelSelectOfficesTab_SelectClients"
            Me.TabControlPanelSelectOfficesTab_SelectClients.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelSelectOfficesTab_SelectClients.Size = New System.Drawing.Size(1017, 579)
            Me.TabControlPanelSelectOfficesTab_SelectClients.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelSelectOfficesTab_SelectClients.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelSelectOfficesTab_SelectClients.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelSelectOfficesTab_SelectClients.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelSelectOfficesTab_SelectClients.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelSelectOfficesTab_SelectClients.Style.GradientAngle = 90
            Me.TabControlPanelSelectOfficesTab_SelectClients.TabIndex = 0
            Me.TabControlPanelSelectOfficesTab_SelectClients.TabItem = Me.TabItemProductionCriteria_SelectClientsTab
            '
            'CDPChooserControl_Production
            '
            Me.CDPChooserControl_Production.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CDPChooserControl_Production.BackColor = System.Drawing.Color.Transparent
            Me.CDPChooserControl_Production.Location = New System.Drawing.Point(4, 4)
            Me.CDPChooserControl_Production.Name = "CDPChooserControl_Production"
            Me.CDPChooserControl_Production.Size = New System.Drawing.Size(1009, 571)
            Me.CDPChooserControl_Production.TabIndex = 1
            '
            'TabItemProductionCriteria_SelectClientsTab
            '
            Me.TabItemProductionCriteria_SelectClientsTab.AttachedControl = Me.TabControlPanelSelectOfficesTab_SelectClients
            Me.TabItemProductionCriteria_SelectClientsTab.Name = "TabItemProductionCriteria_SelectClientsTab"
            Me.TabItemProductionCriteria_SelectClientsTab.Text = "Select Clients"
            '
            'TabControlPanelSelectOfficesTab_SelectOffices
            '
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Controls.Add(Me.DataGridViewSelectOffices_Offices)
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Controls.Add(Me.RadioButtonSelectOffices_AllOffices)
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Controls.Add(Me.RadioButtonSelectOffices_ChooseOffices)
            Me.TabControlPanelSelectOfficesTab_SelectOffices.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Name = "TabControlPanelSelectOfficesTab_SelectOffices"
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Size = New System.Drawing.Size(1017, 579)
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelSelectOfficesTab_SelectOffices.Style.GradientAngle = 90
            Me.TabControlPanelSelectOfficesTab_SelectOffices.TabIndex = 0
            Me.TabControlPanelSelectOfficesTab_SelectOffices.TabItem = Me.TabItemJDA_SelectOfficesTab
            '
            'DataGridViewSelectOffices_Offices
            '
            Me.DataGridViewSelectOffices_Offices.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewSelectOffices_Offices.AllowDragAndDrop = False
            Me.DataGridViewSelectOffices_Offices.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewSelectOffices_Offices.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSelectOffices_Offices.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewSelectOffices_Offices.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewSelectOffices_Offices.AutoFilterLookupColumns = False
            Me.DataGridViewSelectOffices_Offices.AutoloadRepositoryDatasource = True
            Me.DataGridViewSelectOffices_Offices.AutoUpdateViewCaption = True
            Me.DataGridViewSelectOffices_Offices.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewSelectOffices_Offices.DataSource = Nothing
            Me.DataGridViewSelectOffices_Offices.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewSelectOffices_Offices.Enabled = False
            Me.DataGridViewSelectOffices_Offices.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSelectOffices_Offices.ItemDescription = "Office(s)"
            Me.DataGridViewSelectOffices_Offices.Location = New System.Drawing.Point(3, 30)
            Me.DataGridViewSelectOffices_Offices.MultiSelect = True
            Me.DataGridViewSelectOffices_Offices.Name = "DataGridViewSelectOffices_Offices"
            Me.DataGridViewSelectOffices_Offices.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewSelectOffices_Offices.RunStandardValidation = True
            Me.DataGridViewSelectOffices_Offices.ShowColumnMenuOnRightClick = False
            Me.DataGridViewSelectOffices_Offices.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSelectOffices_Offices.Size = New System.Drawing.Size(1009, 545)
            Me.DataGridViewSelectOffices_Offices.TabIndex = 2
            Me.DataGridViewSelectOffices_Offices.UseEmbeddedNavigator = False
            Me.DataGridViewSelectOffices_Offices.ViewCaptionHeight = -1
            '
            'RadioButtonSelectOffices_AllOffices
            '
            Me.RadioButtonSelectOffices_AllOffices.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectOffices_AllOffices.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectOffices_AllOffices.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectOffices_AllOffices.Checked = True
            Me.RadioButtonSelectOffices_AllOffices.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonSelectOffices_AllOffices.CheckValue = "Y"
            Me.RadioButtonSelectOffices_AllOffices.Location = New System.Drawing.Point(4, 4)
            Me.RadioButtonSelectOffices_AllOffices.Name = "RadioButtonSelectOffices_AllOffices"
            Me.RadioButtonSelectOffices_AllOffices.SecurityEnabled = True
            Me.RadioButtonSelectOffices_AllOffices.Size = New System.Drawing.Size(77, 20)
            Me.RadioButtonSelectOffices_AllOffices.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectOffices_AllOffices.TabIndex = 0
            Me.RadioButtonSelectOffices_AllOffices.TabOnEnter = True
            Me.RadioButtonSelectOffices_AllOffices.Text = "All Offices"
            '
            'RadioButtonSelectOffices_ChooseOffices
            '
            Me.RadioButtonSelectOffices_ChooseOffices.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectOffices_ChooseOffices.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectOffices_ChooseOffices.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectOffices_ChooseOffices.Location = New System.Drawing.Point(87, 4)
            Me.RadioButtonSelectOffices_ChooseOffices.Name = "RadioButtonSelectOffices_ChooseOffices"
            Me.RadioButtonSelectOffices_ChooseOffices.SecurityEnabled = True
            Me.RadioButtonSelectOffices_ChooseOffices.Size = New System.Drawing.Size(138, 20)
            Me.RadioButtonSelectOffices_ChooseOffices.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectOffices_ChooseOffices.TabIndex = 1
            Me.RadioButtonSelectOffices_ChooseOffices.TabOnEnter = True
            Me.RadioButtonSelectOffices_ChooseOffices.TabStop = False
            Me.RadioButtonSelectOffices_ChooseOffices.Text = "Choose Offices"
            '
            'TabItemJDA_SelectOfficesTab
            '
            Me.TabItemJDA_SelectOfficesTab.AttachedControl = Me.TabControlPanelSelectOfficesTab_SelectOffices
            Me.TabItemJDA_SelectOfficesTab.Name = "TabItemJDA_SelectOfficesTab"
            Me.TabItemJDA_SelectOfficesTab.Text = "Select Offices"
            '
            'LabelForm_PriorPeriod2Start
            '
            Me.LabelForm_PriorPeriod2Start.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_PriorPeriod2Start.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_PriorPeriod2Start.Location = New System.Drawing.Point(716, 4)
            Me.LabelForm_PriorPeriod2Start.Name = "LabelForm_PriorPeriod2Start"
            Me.LabelForm_PriorPeriod2Start.Size = New System.Drawing.Size(95, 20)
            Me.LabelForm_PriorPeriod2Start.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_PriorPeriod2Start.TabIndex = 52
            Me.LabelForm_PriorPeriod2Start.Text = "Prior Period2 Start:"
            '
            'ComboBoxForm_PriorPeriod2Start
            '
            Me.ComboBoxForm_PriorPeriod2Start.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_PriorPeriod2Start.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_PriorPeriod2Start.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_PriorPeriod2Start.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_PriorPeriod2Start.AutoFindItemInDataSource = False
            Me.ComboBoxForm_PriorPeriod2Start.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_PriorPeriod2Start.BookmarkingEnabled = False
            Me.ComboBoxForm_PriorPeriod2Start.ClientCode = ""
            Me.ComboBoxForm_PriorPeriod2Start.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.PostPeriod
            Me.ComboBoxForm_PriorPeriod2Start.DisableMouseWheel = False
            Me.ComboBoxForm_PriorPeriod2Start.DisplayMember = "Description"
            Me.ComboBoxForm_PriorPeriod2Start.DisplayName = ""
            Me.ComboBoxForm_PriorPeriod2Start.DivisionCode = ""
            Me.ComboBoxForm_PriorPeriod2Start.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_PriorPeriod2Start.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_PriorPeriod2Start.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_PriorPeriod2Start.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_PriorPeriod2Start.FocusHighlightEnabled = True
            Me.ComboBoxForm_PriorPeriod2Start.FormattingEnabled = True
            Me.ComboBoxForm_PriorPeriod2Start.ItemHeight = 14
            Me.ComboBoxForm_PriorPeriod2Start.Location = New System.Drawing.Point(815, 4)
            Me.ComboBoxForm_PriorPeriod2Start.Name = "ComboBoxForm_PriorPeriod2Start"
            Me.ComboBoxForm_PriorPeriod2Start.ReadOnly = False
            Me.ComboBoxForm_PriorPeriod2Start.SecurityEnabled = True
            Me.ComboBoxForm_PriorPeriod2Start.Size = New System.Drawing.Size(109, 20)
            Me.ComboBoxForm_PriorPeriod2Start.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_PriorPeriod2Start.TabIndex = 53
            Me.ComboBoxForm_PriorPeriod2Start.TabOnEnter = True
            Me.ComboBoxForm_PriorPeriod2Start.ValueMember = "Code"
            Me.ComboBoxForm_PriorPeriod2Start.WatermarkText = "Select Post Period"
            '
            'ComboBoxForm_PriorPeriod2End
            '
            Me.ComboBoxForm_PriorPeriod2End.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_PriorPeriod2End.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_PriorPeriod2End.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_PriorPeriod2End.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_PriorPeriod2End.AutoFindItemInDataSource = False
            Me.ComboBoxForm_PriorPeriod2End.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_PriorPeriod2End.BookmarkingEnabled = False
            Me.ComboBoxForm_PriorPeriod2End.ClientCode = ""
            Me.ComboBoxForm_PriorPeriod2End.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.PostPeriod
            Me.ComboBoxForm_PriorPeriod2End.DisableMouseWheel = False
            Me.ComboBoxForm_PriorPeriod2End.DisplayMember = "Description"
            Me.ComboBoxForm_PriorPeriod2End.DisplayName = ""
            Me.ComboBoxForm_PriorPeriod2End.DivisionCode = ""
            Me.ComboBoxForm_PriorPeriod2End.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_PriorPeriod2End.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_PriorPeriod2End.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_PriorPeriod2End.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_PriorPeriod2End.FocusHighlightEnabled = True
            Me.ComboBoxForm_PriorPeriod2End.FormattingEnabled = True
            Me.ComboBoxForm_PriorPeriod2End.ItemHeight = 14
            Me.ComboBoxForm_PriorPeriod2End.Location = New System.Drawing.Point(815, 30)
            Me.ComboBoxForm_PriorPeriod2End.Name = "ComboBoxForm_PriorPeriod2End"
            Me.ComboBoxForm_PriorPeriod2End.ReadOnly = False
            Me.ComboBoxForm_PriorPeriod2End.SecurityEnabled = True
            Me.ComboBoxForm_PriorPeriod2End.Size = New System.Drawing.Size(109, 20)
            Me.ComboBoxForm_PriorPeriod2End.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_PriorPeriod2End.TabIndex = 55
            Me.ComboBoxForm_PriorPeriod2End.TabOnEnter = True
            Me.ComboBoxForm_PriorPeriod2End.ValueMember = "Code"
            Me.ComboBoxForm_PriorPeriod2End.WatermarkText = "Select Post Period"
            '
            'LabelForm_PriorPeriod2End
            '
            Me.LabelForm_PriorPeriod2End.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_PriorPeriod2End.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_PriorPeriod2End.Location = New System.Drawing.Point(716, 30)
            Me.LabelForm_PriorPeriod2End.Name = "LabelForm_PriorPeriod2End"
            Me.LabelForm_PriorPeriod2End.Size = New System.Drawing.Size(95, 20)
            Me.LabelForm_PriorPeriod2End.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_PriorPeriod2End.TabIndex = 54
            Me.LabelForm_PriorPeriod2End.Text = "Prior Period2 End:"
            '
            'LabelForm_PriorPeriod1Start
            '
            Me.LabelForm_PriorPeriod1Start.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_PriorPeriod1Start.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_PriorPeriod1Start.Location = New System.Drawing.Point(498, 4)
            Me.LabelForm_PriorPeriod1Start.Name = "LabelForm_PriorPeriod1Start"
            Me.LabelForm_PriorPeriod1Start.Size = New System.Drawing.Size(94, 20)
            Me.LabelForm_PriorPeriod1Start.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_PriorPeriod1Start.TabIndex = 48
            Me.LabelForm_PriorPeriod1Start.Text = "Prior Period1 Start:"
            '
            'ComboBoxForm_PriorPeriod1Start
            '
            Me.ComboBoxForm_PriorPeriod1Start.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_PriorPeriod1Start.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_PriorPeriod1Start.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_PriorPeriod1Start.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_PriorPeriod1Start.AutoFindItemInDataSource = False
            Me.ComboBoxForm_PriorPeriod1Start.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_PriorPeriod1Start.BookmarkingEnabled = False
            Me.ComboBoxForm_PriorPeriod1Start.ClientCode = ""
            Me.ComboBoxForm_PriorPeriod1Start.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.PostPeriod
            Me.ComboBoxForm_PriorPeriod1Start.DisableMouseWheel = False
            Me.ComboBoxForm_PriorPeriod1Start.DisplayMember = "Description"
            Me.ComboBoxForm_PriorPeriod1Start.DisplayName = ""
            Me.ComboBoxForm_PriorPeriod1Start.DivisionCode = ""
            Me.ComboBoxForm_PriorPeriod1Start.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_PriorPeriod1Start.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_PriorPeriod1Start.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_PriorPeriod1Start.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_PriorPeriod1Start.FocusHighlightEnabled = True
            Me.ComboBoxForm_PriorPeriod1Start.FormattingEnabled = True
            Me.ComboBoxForm_PriorPeriod1Start.ItemHeight = 14
            Me.ComboBoxForm_PriorPeriod1Start.Location = New System.Drawing.Point(596, 4)
            Me.ComboBoxForm_PriorPeriod1Start.Name = "ComboBoxForm_PriorPeriod1Start"
            Me.ComboBoxForm_PriorPeriod1Start.ReadOnly = False
            Me.ComboBoxForm_PriorPeriod1Start.SecurityEnabled = True
            Me.ComboBoxForm_PriorPeriod1Start.Size = New System.Drawing.Size(109, 20)
            Me.ComboBoxForm_PriorPeriod1Start.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_PriorPeriod1Start.TabIndex = 49
            Me.ComboBoxForm_PriorPeriod1Start.TabOnEnter = True
            Me.ComboBoxForm_PriorPeriod1Start.ValueMember = "Code"
            Me.ComboBoxForm_PriorPeriod1Start.WatermarkText = "Select Post Period"
            '
            'ComboBoxForm_PriorPeriod1End
            '
            Me.ComboBoxForm_PriorPeriod1End.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_PriorPeriod1End.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_PriorPeriod1End.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_PriorPeriod1End.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_PriorPeriod1End.AutoFindItemInDataSource = False
            Me.ComboBoxForm_PriorPeriod1End.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_PriorPeriod1End.BookmarkingEnabled = False
            Me.ComboBoxForm_PriorPeriod1End.ClientCode = ""
            Me.ComboBoxForm_PriorPeriod1End.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.PostPeriod
            Me.ComboBoxForm_PriorPeriod1End.DisableMouseWheel = False
            Me.ComboBoxForm_PriorPeriod1End.DisplayMember = "Description"
            Me.ComboBoxForm_PriorPeriod1End.DisplayName = ""
            Me.ComboBoxForm_PriorPeriod1End.DivisionCode = ""
            Me.ComboBoxForm_PriorPeriod1End.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_PriorPeriod1End.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_PriorPeriod1End.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_PriorPeriod1End.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_PriorPeriod1End.FocusHighlightEnabled = True
            Me.ComboBoxForm_PriorPeriod1End.FormattingEnabled = True
            Me.ComboBoxForm_PriorPeriod1End.ItemHeight = 14
            Me.ComboBoxForm_PriorPeriod1End.Location = New System.Drawing.Point(596, 30)
            Me.ComboBoxForm_PriorPeriod1End.Name = "ComboBoxForm_PriorPeriod1End"
            Me.ComboBoxForm_PriorPeriod1End.ReadOnly = False
            Me.ComboBoxForm_PriorPeriod1End.SecurityEnabled = True
            Me.ComboBoxForm_PriorPeriod1End.Size = New System.Drawing.Size(109, 20)
            Me.ComboBoxForm_PriorPeriod1End.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_PriorPeriod1End.TabIndex = 51
            Me.ComboBoxForm_PriorPeriod1End.TabOnEnter = True
            Me.ComboBoxForm_PriorPeriod1End.ValueMember = "Code"
            Me.ComboBoxForm_PriorPeriod1End.WatermarkText = "Select Post Period"
            '
            'LabelForm_PriorPeriod1End
            '
            Me.LabelForm_PriorPeriod1End.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_PriorPeriod1End.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_PriorPeriod1End.Location = New System.Drawing.Point(498, 30)
            Me.LabelForm_PriorPeriod1End.Name = "LabelForm_PriorPeriod1End"
            Me.LabelForm_PriorPeriod1End.Size = New System.Drawing.Size(94, 20)
            Me.LabelForm_PriorPeriod1End.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_PriorPeriod1End.TabIndex = 50
            Me.LabelForm_PriorPeriod1End.Text = "Prior Period1 End:"
            '
            'ClientPLInitialLoadingDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1041, 687)
            Me.Controls.Add(Me.PanelForm_BottomSection)
            Me.Controls.Add(Me.PanelForm_TopSection)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "ClientPLInitialLoadingDialog"
            Me.Text = "Client PL Initial Criteria"
            Me.PanelForm_PrimaryDisplayOption.ResumeLayout(False)
            Me.PanelForm_DataOption.ResumeLayout(False)
            Me.PanelForm_CoopOptions.ResumeLayout(False)
            Me.PanelForm_TopSection.ResumeLayout(False)
            Me.PanelForm_BottomSection.ResumeLayout(False)
            CType(Me.TabControlForm_JDA, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlForm_JDA.ResumeLayout(False)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.ResumeLayout(False)
            Me.TabControlPanelSelectOfficesTab_SelectClients.ResumeLayout(False)
            Me.TabControlPanelSelectOfficesTab_SelectOffices.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ComboBoxForm_StartingPostPeriod As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_StartingPostPeriod As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxForm_Office As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelForm_EndingPostPeriod As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_EndingPostPeriod As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_Type As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents RadioButtonForm_Standard As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonForm_AlternateDirectCost As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents LabelForm_GroupByOptions As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxForm_Client As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_Division As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_Product As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_Type As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_SalesClass As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_PostPeriod As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_Year As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents ButtonForm_2Years As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_1Year As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_MTD As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_YTD As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_2YTD As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents CheckBoxForm_Campaign As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_ProductUDF As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_AccountExecutive As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelForm_IncludeOptions As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents CheckBoxForm_BilledIncomeRecognized As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Private WithEvents CheckBoxForm_GLEntries As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Private WithEvents CheckBoxForm_ManualInvoices As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelForm_ReportOptions As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_OverheadSet As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBox_OverheadSet As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents PanelForm_PrimaryDisplayOption As System.Windows.Forms.Panel
        Friend WithEvents RadioButtonPrimaryDisplayOption_OverheadFactor As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonPrimaryDisplayOption_OverheadAllocation As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents PanelForm_DataOption As System.Windows.Forms.Panel
        Friend WithEvents RadioButtonDataOption_Hours As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonDataOption_Cost As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents PanelForm_CoopOptions As System.Windows.Forms.Panel
        Friend WithEvents RadioButtonCoopOptions_BreakoutCoop As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonCoopOptions_CombineCoop As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents PanelForm_TopSection As System.Windows.Forms.Panel
        Friend WithEvents LabelTopSection_Report As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxTopSection_Report As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents PanelForm_BottomSection As System.Windows.Forms.Panel
        Private WithEvents CheckBoxForm_ExcludeNewBusiness As WinForm.Presentation.Controls.CheckBox
        Private WithEvents CheckBoxDirectExpenseOperatingOnly As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents TabControlForm_JDA As WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelVersionAndOptionsTab_VersionAndOptions As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemJDA_VersionAndOptionsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelSelectOfficesTab_SelectOffices As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabControlPanelSelectOfficesTab_SelectClients As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewSelectOffices_Offices As WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RadioButtonSelectOffices_AllOffices As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSelectOffices_ChooseOffices As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents TabItemJDA_SelectOfficesTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabItemProductionCriteria_SelectClientsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents CDPChooserControl_Production As WinForm.Presentation.Controls.CDPChooserControl
        Friend WithEvents LabelForm_PriorPeriod2Start As WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_PriorPeriod2Start As WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxForm_PriorPeriod2End As WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_PriorPeriod2End As WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_PriorPeriod1Start As WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_PriorPeriod1Start As WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxForm_PriorPeriod1End As WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_PriorPeriod1End As WinForm.Presentation.Controls.Label
    End Class

End Namespace