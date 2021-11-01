Namespace Desktop.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ActivityEditDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ActivityEditDialog))
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Add = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Save = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Delete = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Cancel = New DevComponents.DotNetBar.ButtonItem()
            Me.TabControlForm_ActivitySettings = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelGeneralTab_General = New DevComponents.DotNetBar.TabControlPanel()
            Me.TimePickerGeneral_EndTime = New AdvantageFramework.WinForm.Presentation.Controls.TimePicker()
            Me.TimePickerGeneral_StartTime = New AdvantageFramework.WinForm.Presentation.Controls.TimePicker()
            Me.ComboBoxGeneral_Contact = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelGeneral_Contact = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxGeneral_Category = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelGeneral_Category = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxGeneral_Component = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxGeneral_ComponentView = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxGeneral_Job = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxGeneral_JobView = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxGeneral_Product = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxGeneral_ProductView = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxGeneral_Division = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxGeneral_DivisionView = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxGeneral_Client = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxGeneral_ClientView = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.ComboBoxGeneral_Function = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelGeneral_Function = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGeneral_Component = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGeneral_Job = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGeneral_Product = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGeneral_Client = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGeneral_Division = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxGeneral_Reminder = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelGeneral_Reminder = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxGeneral_Priority = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelGeneral_Priority = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxGeneral_AllDay = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.DateTimePickerGeneral_End = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelGeneral_End = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DateTimePickerGeneral_Start = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelGeneral_Start = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGeneral_Subject = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxGeneral_Subject = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.ComboBoxGeneral_Type = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelGeneral_Type = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemActivitySettings_GeneralTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelDetailsTab_Details = New DevComponents.DotNetBar.TabControlPanel()
            Me.RichEditDetails_Description = New AdvantageFramework.WinForm.Presentation.Controls.RichEditControl()
            Me.TabItemActivitySettings_DetailsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelEmployeeTab_Employee = New DevComponents.DotNetBar.TabControlPanel()
            Me.PanelEmployee_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.ButtonEmployeeRightSection_RemoveEmployee = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonEmployeeRightSection_AddEmployee = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DataGridViewEmployeeRightSection_SelectedEmployees = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ExpandableSplitterEmployee_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelEmployee_EmployeeLeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewEmployeeLeftSection_AvailableEmployees = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemActivitySettings_EmployeeTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Form.SuspendLayout()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.TabControlForm_ActivitySettings, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlForm_ActivitySettings.SuspendLayout()
            Me.TabControlPanelGeneralTab_General.SuspendLayout()
            CType(Me.TimePickerGeneral_EndTime, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.TimePickerGeneral_StartTime, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxGeneral_Component.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxGeneral_ComponentView, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxGeneral_Job.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxGeneral_JobView, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxGeneral_Product.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxGeneral_ProductView, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxGeneral_Division.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxGeneral_DivisionView, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxGeneral_Client.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxGeneral_ClientView, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerGeneral_End, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerGeneral_Start, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelDetailsTab_Details.SuspendLayout()
            Me.TabControlPanelEmployeeTab_Employee.SuspendLayout()
            CType(Me.PanelEmployee_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelEmployee_RightSection.SuspendLayout()
            CType(Me.PanelEmployee_EmployeeLeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelEmployee_EmployeeLeftSection.SuspendLayout()
            Me.SuspendLayout()
            '
            'RibbonControlForm_MainRibbon
            '
            '
            '
            '
            Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonControlForm_MainRibbon.Margin = New System.Windows.Forms.Padding(4)
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(839, 154)
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
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(839, 95)
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
            Me.RibbonBarFilePanel_System.Margin = New System.Windows.Forms.Padding(2)
            Me.RibbonBarFilePanel_System.Size = New System.Drawing.Size(100, 91)
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
            Me.PanelForm_Form.Controls.Add(Me.TabControlForm_ActivitySettings)
            Me.PanelForm_Form.Size = New System.Drawing.Size(839, 255)
            '
            'BarForm_StatusBar
            '
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 410)
            Me.BarForm_StatusBar.Margin = New System.Windows.Forms.Padding(4)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(839, 18)
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Add, Me.ButtonItemActions_Save, Me.ButtonItemActions_Delete, Me.ButtonItemActions_Cancel})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(104, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(164, 91)
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
            'ButtonItemActions_Add
            '
            Me.ButtonItemActions_Add.BeginGroup = True
            Me.ButtonItemActions_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Add.Name = "ButtonItemActions_Add"
            Me.ButtonItemActions_Add.RibbonWordWrap = False
            Me.ButtonItemActions_Add.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Add.Text = "Add"
            '
            'ButtonItemActions_Save
            '
            Me.ButtonItemActions_Save.BeginGroup = True
            Me.ButtonItemActions_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Save.Name = "ButtonItemActions_Save"
            Me.ButtonItemActions_Save.RibbonWordWrap = False
            Me.ButtonItemActions_Save.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Save.Text = "Save"
            '
            'ButtonItemActions_Delete
            '
            Me.ButtonItemActions_Delete.BeginGroup = True
            Me.ButtonItemActions_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Delete.Name = "ButtonItemActions_Delete"
            Me.ButtonItemActions_Delete.RibbonWordWrap = False
            Me.ButtonItemActions_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Delete.Text = "Delete"
            '
            'ButtonItemActions_Cancel
            '
            Me.ButtonItemActions_Cancel.BeginGroup = True
            Me.ButtonItemActions_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Cancel.Name = "ButtonItemActions_Cancel"
            Me.ButtonItemActions_Cancel.RibbonWordWrap = False
            Me.ButtonItemActions_Cancel.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Cancel.Text = "Cancel"
            '
            'TabControlForm_ActivitySettings
            '
            Me.TabControlForm_ActivitySettings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlForm_ActivitySettings.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
            Me.TabControlForm_ActivitySettings.CanReorderTabs = False
            Me.TabControlForm_ActivitySettings.Controls.Add(Me.TabControlPanelGeneralTab_General)
            Me.TabControlForm_ActivitySettings.Controls.Add(Me.TabControlPanelDetailsTab_Details)
            Me.TabControlForm_ActivitySettings.Controls.Add(Me.TabControlPanelEmployeeTab_Employee)
            Me.TabControlForm_ActivitySettings.Location = New System.Drawing.Point(3, 3)
            Me.TabControlForm_ActivitySettings.Name = "TabControlForm_ActivitySettings"
            Me.TabControlForm_ActivitySettings.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlForm_ActivitySettings.SelectedTabIndex = 0
            Me.TabControlForm_ActivitySettings.Size = New System.Drawing.Size(833, 249)
            Me.TabControlForm_ActivitySettings.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlForm_ActivitySettings.TabIndex = 1
            Me.TabControlForm_ActivitySettings.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlForm_ActivitySettings.Tabs.Add(Me.TabItemActivitySettings_GeneralTab)
            Me.TabControlForm_ActivitySettings.Tabs.Add(Me.TabItemActivitySettings_EmployeeTab)
            Me.TabControlForm_ActivitySettings.Tabs.Add(Me.TabItemActivitySettings_DetailsTab)
            Me.TabControlForm_ActivitySettings.Text = "TabControl1"
            '
            'TabControlPanelGeneralTab_General
            '
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.TimePickerGeneral_EndTime)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.TimePickerGeneral_StartTime)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.ComboBoxGeneral_Contact)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.LabelGeneral_Contact)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.ComboBoxGeneral_Category)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.LabelGeneral_Category)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.SearchableComboBoxGeneral_Component)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.SearchableComboBoxGeneral_Job)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.SearchableComboBoxGeneral_Product)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.SearchableComboBoxGeneral_Division)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.SearchableComboBoxGeneral_Client)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.ComboBoxGeneral_Function)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.LabelGeneral_Function)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.LabelGeneral_Component)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.LabelGeneral_Job)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.LabelGeneral_Product)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.LabelGeneral_Client)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.LabelGeneral_Division)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.ComboBoxGeneral_Reminder)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.LabelGeneral_Reminder)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.ComboBoxGeneral_Priority)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.LabelGeneral_Priority)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.CheckBoxGeneral_AllDay)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.DateTimePickerGeneral_End)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.LabelGeneral_End)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.DateTimePickerGeneral_Start)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.LabelGeneral_Start)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.LabelGeneral_Subject)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.TextBoxGeneral_Subject)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.ComboBoxGeneral_Type)
            Me.TabControlPanelGeneralTab_General.Controls.Add(Me.LabelGeneral_Type)
            Me.TabControlPanelGeneralTab_General.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelGeneralTab_General.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelGeneralTab_General.Name = "TabControlPanelGeneralTab_General"
            Me.TabControlPanelGeneralTab_General.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelGeneralTab_General.Size = New System.Drawing.Size(833, 222)
            Me.TabControlPanelGeneralTab_General.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelGeneralTab_General.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelGeneralTab_General.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelGeneralTab_General.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelGeneralTab_General.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelGeneralTab_General.Style.GradientAngle = 90
            Me.TabControlPanelGeneralTab_General.TabIndex = 0
            Me.TabControlPanelGeneralTab_General.TabItem = Me.TabItemActivitySettings_GeneralTab
            '
            'TimePickerGeneral_EndTime
            '
            Me.TimePickerGeneral_EndTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TimePickerGeneral_EndTime.AutoSize = False
            Me.TimePickerGeneral_EndTime.ClockPosition = Telerik.WinControls.UI.ClockPosition.HideClock
            Me.TimePickerGeneral_EndTime.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TimePicker.Type.[Default]
            Me.TimePickerGeneral_EndTime.DisplayName = ""
            Me.TimePickerGeneral_EndTime.Location = New System.Drawing.Point(219, 82)
            Me.TimePickerGeneral_EndTime.Name = "TimePickerGeneral_EndTime"
            Me.TimePickerGeneral_EndTime.Size = New System.Drawing.Size(133, 20)
            Me.TimePickerGeneral_EndTime.Step = 30
            Me.TimePickerGeneral_EndTime.TabIndex = 12
            Me.TimePickerGeneral_EndTime.TimeTables = Telerik.WinControls.UI.TimeTables.HoursAndMinutesInOneTable
            Me.TimePickerGeneral_EndTime.Value = New Date(2015, 4, 13, 11, 15, 39, 0)
            '
            'TimePickerGeneral_StartTime
            '
            Me.TimePickerGeneral_StartTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TimePickerGeneral_StartTime.AutoSize = False
            Me.TimePickerGeneral_StartTime.ClockPosition = Telerik.WinControls.UI.ClockPosition.HideClock
            Me.TimePickerGeneral_StartTime.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TimePicker.Type.[Default]
            Me.TimePickerGeneral_StartTime.DisplayName = ""
            Me.TimePickerGeneral_StartTime.Location = New System.Drawing.Point(219, 56)
            Me.TimePickerGeneral_StartTime.Name = "TimePickerGeneral_StartTime"
            Me.TimePickerGeneral_StartTime.Size = New System.Drawing.Size(133, 20)
            Me.TimePickerGeneral_StartTime.Step = 30
            Me.TimePickerGeneral_StartTime.TabIndex = 8
            Me.TimePickerGeneral_StartTime.TimeTables = Telerik.WinControls.UI.TimeTables.HoursAndMinutesInOneTable
            Me.TimePickerGeneral_StartTime.Value = New Date(2015, 4, 13, 11, 15, 39, 0)
            '
            'ComboBoxGeneral_Contact
            '
            Me.ComboBoxGeneral_Contact.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxGeneral_Contact.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxGeneral_Contact.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxGeneral_Contact.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxGeneral_Contact.AutoFindItemInDataSource = False
            Me.ComboBoxGeneral_Contact.AutoSelectSingleItemDatasource = False
            Me.ComboBoxGeneral_Contact.BookmarkingEnabled = False
            Me.ComboBoxGeneral_Contact.ClientCode = ""
            Me.ComboBoxGeneral_Contact.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.ClientContact
            Me.ComboBoxGeneral_Contact.DisableMouseWheel = False
            Me.ComboBoxGeneral_Contact.DisplayMember = "FullNameFML"
            Me.ComboBoxGeneral_Contact.DisplayName = ""
            Me.ComboBoxGeneral_Contact.DivisionCode = ""
            Me.ComboBoxGeneral_Contact.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxGeneral_Contact.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxGeneral_Contact.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxGeneral_Contact.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxGeneral_Contact.FocusHighlightEnabled = True
            Me.ComboBoxGeneral_Contact.FormattingEnabled = True
            Me.ComboBoxGeneral_Contact.ItemHeight = 14
            Me.ComboBoxGeneral_Contact.Location = New System.Drawing.Point(536, 134)
            Me.ComboBoxGeneral_Contact.Name = "ComboBoxGeneral_Contact"
            Me.ComboBoxGeneral_Contact.PreventEnterBeep = False
            Me.ComboBoxGeneral_Contact.ReadOnly = False
            Me.ComboBoxGeneral_Contact.SecurityEnabled = True
            Me.ComboBoxGeneral_Contact.Size = New System.Drawing.Size(293, 20)
            Me.ComboBoxGeneral_Contact.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxGeneral_Contact.TabIndex = 28
            Me.ComboBoxGeneral_Contact.ValueMember = "ID"
            Me.ComboBoxGeneral_Contact.WatermarkText = "Select Client Contact"
            '
            'LabelGeneral_Contact
            '
            Me.LabelGeneral_Contact.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelGeneral_Contact.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_Contact.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_Contact.Location = New System.Drawing.Point(425, 134)
            Me.LabelGeneral_Contact.Name = "LabelGeneral_Contact"
            Me.LabelGeneral_Contact.Size = New System.Drawing.Size(105, 20)
            Me.LabelGeneral_Contact.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_Contact.TabIndex = 27
            Me.LabelGeneral_Contact.Text = "Contact:"
            '
            'ComboBoxGeneral_Category
            '
            Me.ComboBoxGeneral_Category.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxGeneral_Category.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxGeneral_Category.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxGeneral_Category.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxGeneral_Category.AutoFindItemInDataSource = False
            Me.ComboBoxGeneral_Category.AutoSelectSingleItemDatasource = False
            Me.ComboBoxGeneral_Category.BookmarkingEnabled = False
            Me.ComboBoxGeneral_Category.ClientCode = ""
            Me.ComboBoxGeneral_Category.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.IndirectCategory
            Me.ComboBoxGeneral_Category.DisableMouseWheel = False
            Me.ComboBoxGeneral_Category.DisplayMember = "Description"
            Me.ComboBoxGeneral_Category.DisplayName = ""
            Me.ComboBoxGeneral_Category.DivisionCode = ""
            Me.ComboBoxGeneral_Category.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxGeneral_Category.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxGeneral_Category.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxGeneral_Category.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxGeneral_Category.FocusHighlightEnabled = True
            Me.ComboBoxGeneral_Category.FormattingEnabled = True
            Me.ComboBoxGeneral_Category.ItemHeight = 14
            Me.ComboBoxGeneral_Category.Location = New System.Drawing.Point(275, 4)
            Me.ComboBoxGeneral_Category.Name = "ComboBoxGeneral_Category"
            Me.ComboBoxGeneral_Category.PreventEnterBeep = False
            Me.ComboBoxGeneral_Category.ReadOnly = False
            Me.ComboBoxGeneral_Category.SecurityEnabled = True
            Me.ComboBoxGeneral_Category.Size = New System.Drawing.Size(143, 20)
            Me.ComboBoxGeneral_Category.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxGeneral_Category.TabIndex = 3
            Me.ComboBoxGeneral_Category.ValueMember = "Code"
            Me.ComboBoxGeneral_Category.WatermarkText = "Select Indirect Category"
            '
            'LabelGeneral_Category
            '
            Me.LabelGeneral_Category.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelGeneral_Category.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_Category.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_Category.Location = New System.Drawing.Point(219, 4)
            Me.LabelGeneral_Category.Name = "LabelGeneral_Category"
            Me.LabelGeneral_Category.Size = New System.Drawing.Size(50, 20)
            Me.LabelGeneral_Category.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_Category.TabIndex = 2
            Me.LabelGeneral_Category.Text = "Category:"
            '
            'SearchableComboBoxGeneral_Component
            '
            Me.SearchableComboBoxGeneral_Component.ActiveFilterString = ""
            Me.SearchableComboBoxGeneral_Component.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxGeneral_Component.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxGeneral_Component.BookmarkingEnabled = False
            Me.SearchableComboBoxGeneral_Component.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.JobComponent
            Me.SearchableComboBoxGeneral_Component.DataSource = Nothing
            Me.SearchableComboBoxGeneral_Component.DisableMouseWheel = False
            Me.SearchableComboBoxGeneral_Component.DisplayName = ""
            Me.SearchableComboBoxGeneral_Component.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxGeneral_Component.Location = New System.Drawing.Point(536, 108)
            Me.SearchableComboBoxGeneral_Component.Name = "SearchableComboBoxGeneral_Component"
            Me.SearchableComboBoxGeneral_Component.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxGeneral_Component.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxGeneral_Component.Properties.NullText = "Select Job Component"
            Me.SearchableComboBoxGeneral_Component.Properties.ValueMember = "Number"
            Me.SearchableComboBoxGeneral_Component.Properties.View = Me.SearchableComboBoxGeneral_ComponentView
            Me.SearchableComboBoxGeneral_Component.SecurityEnabled = True
            Me.SearchableComboBoxGeneral_Component.SelectedValue = Nothing
            Me.SearchableComboBoxGeneral_Component.Size = New System.Drawing.Size(293, 20)
            Me.SearchableComboBoxGeneral_Component.TabIndex = 26
            '
            'SearchableComboBoxGeneral_ComponentView
            '
            Me.SearchableComboBoxGeneral_ComponentView.AFActiveFilterString = ""
            Me.SearchableComboBoxGeneral_ComponentView.AutoFilterLookupColumns = False
            Me.SearchableComboBoxGeneral_ComponentView.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxGeneral_ComponentView.DataSourceClearing = False
            Me.SearchableComboBoxGeneral_ComponentView.EnableDisabledRows = False
            Me.SearchableComboBoxGeneral_ComponentView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxGeneral_ComponentView.Name = "SearchableComboBoxGeneral_ComponentView"
            Me.SearchableComboBoxGeneral_ComponentView.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxGeneral_ComponentView.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxGeneral_ComponentView.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxGeneral_ComponentView.RunStandardValidation = True
            '
            'SearchableComboBoxGeneral_Job
            '
            Me.SearchableComboBoxGeneral_Job.ActiveFilterString = ""
            Me.SearchableComboBoxGeneral_Job.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxGeneral_Job.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxGeneral_Job.BookmarkingEnabled = False
            Me.SearchableComboBoxGeneral_Job.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Job
            Me.SearchableComboBoxGeneral_Job.DataSource = Nothing
            Me.SearchableComboBoxGeneral_Job.DisableMouseWheel = False
            Me.SearchableComboBoxGeneral_Job.DisplayName = ""
            Me.SearchableComboBoxGeneral_Job.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxGeneral_Job.Location = New System.Drawing.Point(536, 82)
            Me.SearchableComboBoxGeneral_Job.Name = "SearchableComboBoxGeneral_Job"
            Me.SearchableComboBoxGeneral_Job.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxGeneral_Job.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxGeneral_Job.Properties.NullText = "Select Job"
            Me.SearchableComboBoxGeneral_Job.Properties.ValueMember = "Number"
            Me.SearchableComboBoxGeneral_Job.Properties.View = Me.SearchableComboBoxGeneral_JobView
            Me.SearchableComboBoxGeneral_Job.SecurityEnabled = True
            Me.SearchableComboBoxGeneral_Job.SelectedValue = Nothing
            Me.SearchableComboBoxGeneral_Job.Size = New System.Drawing.Size(293, 20)
            Me.SearchableComboBoxGeneral_Job.TabIndex = 24
            '
            'SearchableComboBoxGeneral_JobView
            '
            Me.SearchableComboBoxGeneral_JobView.AFActiveFilterString = ""
            Me.SearchableComboBoxGeneral_JobView.AutoFilterLookupColumns = False
            Me.SearchableComboBoxGeneral_JobView.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxGeneral_JobView.DataSourceClearing = False
            Me.SearchableComboBoxGeneral_JobView.EnableDisabledRows = False
            Me.SearchableComboBoxGeneral_JobView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxGeneral_JobView.Name = "SearchableComboBoxGeneral_JobView"
            Me.SearchableComboBoxGeneral_JobView.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxGeneral_JobView.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxGeneral_JobView.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxGeneral_JobView.RunStandardValidation = True
            '
            'SearchableComboBoxGeneral_Product
            '
            Me.SearchableComboBoxGeneral_Product.ActiveFilterString = ""
            Me.SearchableComboBoxGeneral_Product.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxGeneral_Product.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxGeneral_Product.BookmarkingEnabled = False
            Me.SearchableComboBoxGeneral_Product.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Product
            Me.SearchableComboBoxGeneral_Product.DataSource = Nothing
            Me.SearchableComboBoxGeneral_Product.DisableMouseWheel = False
            Me.SearchableComboBoxGeneral_Product.DisplayName = ""
            Me.SearchableComboBoxGeneral_Product.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxGeneral_Product.Location = New System.Drawing.Point(536, 56)
            Me.SearchableComboBoxGeneral_Product.Name = "SearchableComboBoxGeneral_Product"
            Me.SearchableComboBoxGeneral_Product.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxGeneral_Product.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxGeneral_Product.Properties.NullText = "Select Product"
            Me.SearchableComboBoxGeneral_Product.Properties.ValueMember = "Code"
            Me.SearchableComboBoxGeneral_Product.Properties.View = Me.SearchableComboBoxGeneral_ProductView
            Me.SearchableComboBoxGeneral_Product.SecurityEnabled = True
            Me.SearchableComboBoxGeneral_Product.SelectedValue = Nothing
            Me.SearchableComboBoxGeneral_Product.Size = New System.Drawing.Size(293, 20)
            Me.SearchableComboBoxGeneral_Product.TabIndex = 22
            '
            'SearchableComboBoxGeneral_ProductView
            '
            Me.SearchableComboBoxGeneral_ProductView.AFActiveFilterString = ""
            Me.SearchableComboBoxGeneral_ProductView.AutoFilterLookupColumns = False
            Me.SearchableComboBoxGeneral_ProductView.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxGeneral_ProductView.DataSourceClearing = False
            Me.SearchableComboBoxGeneral_ProductView.EnableDisabledRows = False
            Me.SearchableComboBoxGeneral_ProductView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxGeneral_ProductView.Name = "SearchableComboBoxGeneral_ProductView"
            Me.SearchableComboBoxGeneral_ProductView.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxGeneral_ProductView.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxGeneral_ProductView.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxGeneral_ProductView.RunStandardValidation = True
            '
            'SearchableComboBoxGeneral_Division
            '
            Me.SearchableComboBoxGeneral_Division.ActiveFilterString = ""
            Me.SearchableComboBoxGeneral_Division.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxGeneral_Division.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxGeneral_Division.BookmarkingEnabled = False
            Me.SearchableComboBoxGeneral_Division.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Division
            Me.SearchableComboBoxGeneral_Division.DataSource = Nothing
            Me.SearchableComboBoxGeneral_Division.DisableMouseWheel = False
            Me.SearchableComboBoxGeneral_Division.DisplayName = ""
            Me.SearchableComboBoxGeneral_Division.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxGeneral_Division.Location = New System.Drawing.Point(536, 30)
            Me.SearchableComboBoxGeneral_Division.Name = "SearchableComboBoxGeneral_Division"
            Me.SearchableComboBoxGeneral_Division.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxGeneral_Division.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxGeneral_Division.Properties.NullText = "Select Division"
            Me.SearchableComboBoxGeneral_Division.Properties.ValueMember = "Code"
            Me.SearchableComboBoxGeneral_Division.Properties.View = Me.SearchableComboBoxGeneral_DivisionView
            Me.SearchableComboBoxGeneral_Division.SecurityEnabled = True
            Me.SearchableComboBoxGeneral_Division.SelectedValue = Nothing
            Me.SearchableComboBoxGeneral_Division.Size = New System.Drawing.Size(293, 20)
            Me.SearchableComboBoxGeneral_Division.TabIndex = 20
            '
            'SearchableComboBoxGeneral_DivisionView
            '
            Me.SearchableComboBoxGeneral_DivisionView.AFActiveFilterString = ""
            Me.SearchableComboBoxGeneral_DivisionView.AutoFilterLookupColumns = False
            Me.SearchableComboBoxGeneral_DivisionView.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxGeneral_DivisionView.DataSourceClearing = False
            Me.SearchableComboBoxGeneral_DivisionView.EnableDisabledRows = False
            Me.SearchableComboBoxGeneral_DivisionView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxGeneral_DivisionView.Name = "SearchableComboBoxGeneral_DivisionView"
            Me.SearchableComboBoxGeneral_DivisionView.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxGeneral_DivisionView.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxGeneral_DivisionView.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxGeneral_DivisionView.RunStandardValidation = True
            '
            'SearchableComboBoxGeneral_Client
            '
            Me.SearchableComboBoxGeneral_Client.ActiveFilterString = ""
            Me.SearchableComboBoxGeneral_Client.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxGeneral_Client.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxGeneral_Client.BookmarkingEnabled = False
            Me.SearchableComboBoxGeneral_Client.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Client
            Me.SearchableComboBoxGeneral_Client.DataSource = Nothing
            Me.SearchableComboBoxGeneral_Client.DisableMouseWheel = False
            Me.SearchableComboBoxGeneral_Client.DisplayName = ""
            Me.SearchableComboBoxGeneral_Client.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxGeneral_Client.Location = New System.Drawing.Point(536, 4)
            Me.SearchableComboBoxGeneral_Client.Name = "SearchableComboBoxGeneral_Client"
            Me.SearchableComboBoxGeneral_Client.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxGeneral_Client.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxGeneral_Client.Properties.NullText = "Select Client"
            Me.SearchableComboBoxGeneral_Client.Properties.ValueMember = "Code"
            Me.SearchableComboBoxGeneral_Client.Properties.View = Me.SearchableComboBoxGeneral_ClientView
            Me.SearchableComboBoxGeneral_Client.SecurityEnabled = True
            Me.SearchableComboBoxGeneral_Client.SelectedValue = Nothing
            Me.SearchableComboBoxGeneral_Client.Size = New System.Drawing.Size(293, 20)
            Me.SearchableComboBoxGeneral_Client.TabIndex = 18
            '
            'SearchableComboBoxGeneral_ClientView
            '
            Me.SearchableComboBoxGeneral_ClientView.AFActiveFilterString = ""
            Me.SearchableComboBoxGeneral_ClientView.AutoFilterLookupColumns = False
            Me.SearchableComboBoxGeneral_ClientView.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxGeneral_ClientView.DataSourceClearing = False
            Me.SearchableComboBoxGeneral_ClientView.EnableDisabledRows = False
            Me.SearchableComboBoxGeneral_ClientView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxGeneral_ClientView.Name = "SearchableComboBoxGeneral_ClientView"
            Me.SearchableComboBoxGeneral_ClientView.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxGeneral_ClientView.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxGeneral_ClientView.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxGeneral_ClientView.RunStandardValidation = True
            '
            'ComboBoxGeneral_Function
            '
            Me.ComboBoxGeneral_Function.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxGeneral_Function.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxGeneral_Function.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxGeneral_Function.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxGeneral_Function.AutoFindItemInDataSource = False
            Me.ComboBoxGeneral_Function.AutoSelectSingleItemDatasource = False
            Me.ComboBoxGeneral_Function.BookmarkingEnabled = False
            Me.ComboBoxGeneral_Function.ClientCode = ""
            Me.ComboBoxGeneral_Function.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.[Function]
            Me.ComboBoxGeneral_Function.DisableMouseWheel = False
            Me.ComboBoxGeneral_Function.DisplayMember = "Description"
            Me.ComboBoxGeneral_Function.DisplayName = ""
            Me.ComboBoxGeneral_Function.DivisionCode = ""
            Me.ComboBoxGeneral_Function.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxGeneral_Function.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxGeneral_Function.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxGeneral_Function.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxGeneral_Function.FocusHighlightEnabled = True
            Me.ComboBoxGeneral_Function.FormattingEnabled = True
            Me.ComboBoxGeneral_Function.ItemHeight = 14
            Me.ComboBoxGeneral_Function.Location = New System.Drawing.Point(536, 160)
            Me.ComboBoxGeneral_Function.Name = "ComboBoxGeneral_Function"
            Me.ComboBoxGeneral_Function.PreventEnterBeep = False
            Me.ComboBoxGeneral_Function.ReadOnly = False
            Me.ComboBoxGeneral_Function.SecurityEnabled = True
            Me.ComboBoxGeneral_Function.Size = New System.Drawing.Size(293, 20)
            Me.ComboBoxGeneral_Function.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxGeneral_Function.TabIndex = 30
            Me.ComboBoxGeneral_Function.ValueMember = "Code"
            Me.ComboBoxGeneral_Function.WatermarkText = "Select Function"
            '
            'LabelGeneral_Function
            '
            Me.LabelGeneral_Function.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelGeneral_Function.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_Function.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_Function.Location = New System.Drawing.Point(425, 160)
            Me.LabelGeneral_Function.Name = "LabelGeneral_Function"
            Me.LabelGeneral_Function.Size = New System.Drawing.Size(105, 20)
            Me.LabelGeneral_Function.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_Function.TabIndex = 29
            Me.LabelGeneral_Function.Text = "Function:"
            '
            'LabelGeneral_Component
            '
            Me.LabelGeneral_Component.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelGeneral_Component.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_Component.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_Component.Location = New System.Drawing.Point(425, 108)
            Me.LabelGeneral_Component.Name = "LabelGeneral_Component"
            Me.LabelGeneral_Component.Size = New System.Drawing.Size(105, 20)
            Me.LabelGeneral_Component.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_Component.TabIndex = 25
            Me.LabelGeneral_Component.Text = "Component:"
            '
            'LabelGeneral_Job
            '
            Me.LabelGeneral_Job.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelGeneral_Job.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_Job.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_Job.Location = New System.Drawing.Point(425, 82)
            Me.LabelGeneral_Job.Name = "LabelGeneral_Job"
            Me.LabelGeneral_Job.Size = New System.Drawing.Size(105, 20)
            Me.LabelGeneral_Job.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_Job.TabIndex = 23
            Me.LabelGeneral_Job.Text = "Job: "
            '
            'LabelGeneral_Product
            '
            Me.LabelGeneral_Product.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelGeneral_Product.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_Product.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_Product.Location = New System.Drawing.Point(425, 56)
            Me.LabelGeneral_Product.Name = "LabelGeneral_Product"
            Me.LabelGeneral_Product.Size = New System.Drawing.Size(105, 20)
            Me.LabelGeneral_Product.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_Product.TabIndex = 21
            Me.LabelGeneral_Product.Text = "Product:"
            '
            'LabelGeneral_Client
            '
            Me.LabelGeneral_Client.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelGeneral_Client.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_Client.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_Client.Location = New System.Drawing.Point(425, 4)
            Me.LabelGeneral_Client.Name = "LabelGeneral_Client"
            Me.LabelGeneral_Client.Size = New System.Drawing.Size(105, 20)
            Me.LabelGeneral_Client.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_Client.TabIndex = 17
            Me.LabelGeneral_Client.Text = "Client: "
            '
            'LabelGeneral_Division
            '
            Me.LabelGeneral_Division.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelGeneral_Division.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_Division.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_Division.Location = New System.Drawing.Point(425, 30)
            Me.LabelGeneral_Division.Name = "LabelGeneral_Division"
            Me.LabelGeneral_Division.Size = New System.Drawing.Size(105, 20)
            Me.LabelGeneral_Division.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_Division.TabIndex = 19
            Me.LabelGeneral_Division.Text = "Division: "
            '
            'ComboBoxGeneral_Reminder
            '
            Me.ComboBoxGeneral_Reminder.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxGeneral_Reminder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxGeneral_Reminder.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxGeneral_Reminder.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxGeneral_Reminder.AutoFindItemInDataSource = False
            Me.ComboBoxGeneral_Reminder.AutoSelectSingleItemDatasource = False
            Me.ComboBoxGeneral_Reminder.BookmarkingEnabled = False
            Me.ComboBoxGeneral_Reminder.ClientCode = ""
            Me.ComboBoxGeneral_Reminder.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumObjects
            Me.ComboBoxGeneral_Reminder.DisableMouseWheel = False
            Me.ComboBoxGeneral_Reminder.DisplayMember = "Description"
            Me.ComboBoxGeneral_Reminder.DisplayName = ""
            Me.ComboBoxGeneral_Reminder.DivisionCode = ""
            Me.ComboBoxGeneral_Reminder.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxGeneral_Reminder.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxGeneral_Reminder.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.None
            Me.ComboBoxGeneral_Reminder.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxGeneral_Reminder.FocusHighlightEnabled = True
            Me.ComboBoxGeneral_Reminder.FormattingEnabled = True
            Me.ComboBoxGeneral_Reminder.ItemHeight = 14
            Me.ComboBoxGeneral_Reminder.Location = New System.Drawing.Point(67, 134)
            Me.ComboBoxGeneral_Reminder.Name = "ComboBoxGeneral_Reminder"
            Me.ComboBoxGeneral_Reminder.PreventEnterBeep = False
            Me.ComboBoxGeneral_Reminder.ReadOnly = False
            Me.ComboBoxGeneral_Reminder.SecurityEnabled = True
            Me.ComboBoxGeneral_Reminder.Size = New System.Drawing.Size(146, 20)
            Me.ComboBoxGeneral_Reminder.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxGeneral_Reminder.TabIndex = 16
            Me.ComboBoxGeneral_Reminder.ValueMember = "Code"
            Me.ComboBoxGeneral_Reminder.WatermarkText = "Select"
            '
            'LabelGeneral_Reminder
            '
            Me.LabelGeneral_Reminder.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_Reminder.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_Reminder.Location = New System.Drawing.Point(4, 134)
            Me.LabelGeneral_Reminder.Name = "LabelGeneral_Reminder"
            Me.LabelGeneral_Reminder.Size = New System.Drawing.Size(57, 20)
            Me.LabelGeneral_Reminder.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_Reminder.TabIndex = 15
            Me.LabelGeneral_Reminder.Text = "Reminder:"
            '
            'ComboBoxGeneral_Priority
            '
            Me.ComboBoxGeneral_Priority.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxGeneral_Priority.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxGeneral_Priority.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxGeneral_Priority.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxGeneral_Priority.AutoFindItemInDataSource = False
            Me.ComboBoxGeneral_Priority.AutoSelectSingleItemDatasource = False
            Me.ComboBoxGeneral_Priority.BookmarkingEnabled = False
            Me.ComboBoxGeneral_Priority.ClientCode = ""
            Me.ComboBoxGeneral_Priority.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumDataTable
            Me.ComboBoxGeneral_Priority.DisableMouseWheel = False
            Me.ComboBoxGeneral_Priority.DisplayMember = "Name"
            Me.ComboBoxGeneral_Priority.DisplayName = ""
            Me.ComboBoxGeneral_Priority.DivisionCode = ""
            Me.ComboBoxGeneral_Priority.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxGeneral_Priority.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxGeneral_Priority.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxGeneral_Priority.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxGeneral_Priority.FocusHighlightEnabled = True
            Me.ComboBoxGeneral_Priority.FormattingEnabled = True
            Me.ComboBoxGeneral_Priority.ItemHeight = 14
            Me.ComboBoxGeneral_Priority.Location = New System.Drawing.Point(67, 108)
            Me.ComboBoxGeneral_Priority.Name = "ComboBoxGeneral_Priority"
            Me.ComboBoxGeneral_Priority.PreventEnterBeep = False
            Me.ComboBoxGeneral_Priority.ReadOnly = False
            Me.ComboBoxGeneral_Priority.SecurityEnabled = True
            Me.ComboBoxGeneral_Priority.Size = New System.Drawing.Size(146, 20)
            Me.ComboBoxGeneral_Priority.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxGeneral_Priority.TabIndex = 14
            Me.ComboBoxGeneral_Priority.ValueMember = "Value"
            Me.ComboBoxGeneral_Priority.WatermarkText = "Select"
            '
            'LabelGeneral_Priority
            '
            Me.LabelGeneral_Priority.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_Priority.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_Priority.Location = New System.Drawing.Point(4, 108)
            Me.LabelGeneral_Priority.Name = "LabelGeneral_Priority"
            Me.LabelGeneral_Priority.Size = New System.Drawing.Size(57, 20)
            Me.LabelGeneral_Priority.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_Priority.TabIndex = 13
            Me.LabelGeneral_Priority.Text = "Priority:"
            '
            'CheckBoxGeneral_AllDay
            '
            Me.CheckBoxGeneral_AllDay.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CheckBoxGeneral_AllDay.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxGeneral_AllDay.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxGeneral_AllDay.CheckValue = 0
            Me.CheckBoxGeneral_AllDay.CheckValueChecked = 1
            Me.CheckBoxGeneral_AllDay.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxGeneral_AllDay.CheckValueUnchecked = 0
            Me.CheckBoxGeneral_AllDay.ChildControls = CType(resources.GetObject("CheckBoxGeneral_AllDay.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxGeneral_AllDay.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxGeneral_AllDay.Location = New System.Drawing.Point(358, 56)
            Me.CheckBoxGeneral_AllDay.Name = "CheckBoxGeneral_AllDay"
            Me.CheckBoxGeneral_AllDay.OldestSibling = Nothing
            Me.CheckBoxGeneral_AllDay.SecurityEnabled = True
            Me.CheckBoxGeneral_AllDay.SiblingControls = CType(resources.GetObject("CheckBoxGeneral_AllDay.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxGeneral_AllDay.Size = New System.Drawing.Size(60, 20)
            Me.CheckBoxGeneral_AllDay.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxGeneral_AllDay.TabIndex = 9
            Me.CheckBoxGeneral_AllDay.Text = "All Day"
            '
            'DateTimePickerGeneral_End
            '
            Me.DateTimePickerGeneral_End.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DateTimePickerGeneral_End.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerGeneral_End.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerGeneral_End.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerGeneral_End.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerGeneral_End.ButtonDropDown.Visible = True
            Me.DateTimePickerGeneral_End.ButtonFreeText.Checked = True
            Me.DateTimePickerGeneral_End.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.ShortDate
            Me.DateTimePickerGeneral_End.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector
            Me.DateTimePickerGeneral_End.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerGeneral_End.DisplayName = ""
            Me.DateTimePickerGeneral_End.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerGeneral_End.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerGeneral_End.FocusHighlightEnabled = True
            Me.DateTimePickerGeneral_End.FreeTextEntryMode = True
            Me.DateTimePickerGeneral_End.IsPopupCalendarOpen = False
            Me.DateTimePickerGeneral_End.Location = New System.Drawing.Point(67, 82)
            Me.DateTimePickerGeneral_End.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerGeneral_End.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerGeneral_End.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerGeneral_End.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerGeneral_End.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerGeneral_End.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerGeneral_End.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerGeneral_End.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerGeneral_End.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerGeneral_End.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerGeneral_End.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerGeneral_End.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerGeneral_End.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerGeneral_End.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerGeneral_End.MonthCalendar.DisplayMonth = New Date(2012, 5, 1, 0, 0, 0, 0)
            Me.DateTimePickerGeneral_End.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerGeneral_End.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerGeneral_End.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerGeneral_End.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerGeneral_End.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerGeneral_End.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerGeneral_End.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerGeneral_End.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerGeneral_End.Name = "DateTimePickerGeneral_End"
            Me.DateTimePickerGeneral_End.ReadOnly = False
            Me.DateTimePickerGeneral_End.Size = New System.Drawing.Size(146, 20)
            Me.DateTimePickerGeneral_End.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerGeneral_End.TabIndex = 11
            Me.DateTimePickerGeneral_End.Value = New Date(2015, 4, 13, 10, 57, 18, 508)
            '
            'LabelGeneral_End
            '
            Me.LabelGeneral_End.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_End.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_End.Location = New System.Drawing.Point(4, 82)
            Me.LabelGeneral_End.Name = "LabelGeneral_End"
            Me.LabelGeneral_End.Size = New System.Drawing.Size(57, 20)
            Me.LabelGeneral_End.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_End.TabIndex = 10
            Me.LabelGeneral_End.Text = "End:"
            '
            'DateTimePickerGeneral_Start
            '
            Me.DateTimePickerGeneral_Start.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DateTimePickerGeneral_Start.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerGeneral_Start.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerGeneral_Start.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerGeneral_Start.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerGeneral_Start.ButtonDropDown.Visible = True
            Me.DateTimePickerGeneral_Start.ButtonFreeText.Checked = True
            Me.DateTimePickerGeneral_Start.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.ShortDate
            Me.DateTimePickerGeneral_Start.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector
            Me.DateTimePickerGeneral_Start.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerGeneral_Start.DisplayName = ""
            Me.DateTimePickerGeneral_Start.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerGeneral_Start.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerGeneral_Start.FocusHighlightEnabled = True
            Me.DateTimePickerGeneral_Start.FreeTextEntryMode = True
            Me.DateTimePickerGeneral_Start.IsPopupCalendarOpen = False
            Me.DateTimePickerGeneral_Start.Location = New System.Drawing.Point(67, 56)
            Me.DateTimePickerGeneral_Start.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerGeneral_Start.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerGeneral_Start.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerGeneral_Start.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerGeneral_Start.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerGeneral_Start.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerGeneral_Start.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerGeneral_Start.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerGeneral_Start.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerGeneral_Start.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerGeneral_Start.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerGeneral_Start.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerGeneral_Start.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerGeneral_Start.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerGeneral_Start.MonthCalendar.DisplayMonth = New Date(2012, 5, 1, 0, 0, 0, 0)
            Me.DateTimePickerGeneral_Start.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerGeneral_Start.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerGeneral_Start.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerGeneral_Start.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerGeneral_Start.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerGeneral_Start.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerGeneral_Start.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerGeneral_Start.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerGeneral_Start.Name = "DateTimePickerGeneral_Start"
            Me.DateTimePickerGeneral_Start.ReadOnly = False
            Me.DateTimePickerGeneral_Start.Size = New System.Drawing.Size(146, 20)
            Me.DateTimePickerGeneral_Start.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerGeneral_Start.TabIndex = 7
            Me.DateTimePickerGeneral_Start.Value = New Date(2015, 4, 13, 10, 56, 57, 675)
            '
            'LabelGeneral_Start
            '
            Me.LabelGeneral_Start.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_Start.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_Start.Location = New System.Drawing.Point(4, 56)
            Me.LabelGeneral_Start.Name = "LabelGeneral_Start"
            Me.LabelGeneral_Start.Size = New System.Drawing.Size(57, 20)
            Me.LabelGeneral_Start.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_Start.TabIndex = 6
            Me.LabelGeneral_Start.Text = "Start:"
            '
            'LabelGeneral_Subject
            '
            Me.LabelGeneral_Subject.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_Subject.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_Subject.Location = New System.Drawing.Point(4, 30)
            Me.LabelGeneral_Subject.Name = "LabelGeneral_Subject"
            Me.LabelGeneral_Subject.Size = New System.Drawing.Size(57, 20)
            Me.LabelGeneral_Subject.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_Subject.TabIndex = 4
            Me.LabelGeneral_Subject.Text = "Subject:"
            '
            'TextBoxGeneral_Subject
            '
            Me.TextBoxGeneral_Subject.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxGeneral_Subject.Border.Class = "TextBoxBorder"
            Me.TextBoxGeneral_Subject.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxGeneral_Subject.CheckSpellingOnValidate = False
            Me.TextBoxGeneral_Subject.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxGeneral_Subject.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxGeneral_Subject.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxGeneral_Subject.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxGeneral_Subject.FocusHighlightEnabled = True
            Me.TextBoxGeneral_Subject.Location = New System.Drawing.Point(67, 30)
            Me.TextBoxGeneral_Subject.MaxFileSize = CType(0, Long)
            Me.TextBoxGeneral_Subject.Name = "TextBoxGeneral_Subject"
            Me.TextBoxGeneral_Subject.SecurityEnabled = True
            Me.TextBoxGeneral_Subject.ShowSpellCheckCompleteMessage = True
            Me.TextBoxGeneral_Subject.Size = New System.Drawing.Size(351, 20)
            Me.TextBoxGeneral_Subject.StartingFolderName = Nothing
            Me.TextBoxGeneral_Subject.TabIndex = 5
            Me.TextBoxGeneral_Subject.TabOnEnter = True
            '
            'ComboBoxGeneral_Type
            '
            Me.ComboBoxGeneral_Type.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxGeneral_Type.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxGeneral_Type.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxGeneral_Type.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxGeneral_Type.AutoFindItemInDataSource = False
            Me.ComboBoxGeneral_Type.AutoSelectSingleItemDatasource = False
            Me.ComboBoxGeneral_Type.BookmarkingEnabled = False
            Me.ComboBoxGeneral_Type.ClientCode = ""
            Me.ComboBoxGeneral_Type.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumObjects
            Me.ComboBoxGeneral_Type.DisableMouseWheel = False
            Me.ComboBoxGeneral_Type.DisplayMember = "Description"
            Me.ComboBoxGeneral_Type.DisplayName = ""
            Me.ComboBoxGeneral_Type.DivisionCode = ""
            Me.ComboBoxGeneral_Type.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxGeneral_Type.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxGeneral_Type.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxGeneral_Type.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxGeneral_Type.FocusHighlightEnabled = True
            Me.ComboBoxGeneral_Type.FormattingEnabled = True
            Me.ComboBoxGeneral_Type.ItemHeight = 14
            Me.ComboBoxGeneral_Type.Location = New System.Drawing.Point(67, 4)
            Me.ComboBoxGeneral_Type.Name = "ComboBoxGeneral_Type"
            Me.ComboBoxGeneral_Type.PreventEnterBeep = False
            Me.ComboBoxGeneral_Type.ReadOnly = False
            Me.ComboBoxGeneral_Type.SecurityEnabled = True
            Me.ComboBoxGeneral_Type.Size = New System.Drawing.Size(146, 20)
            Me.ComboBoxGeneral_Type.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxGeneral_Type.TabIndex = 1
            Me.ComboBoxGeneral_Type.ValueMember = "Code"
            Me.ComboBoxGeneral_Type.WatermarkText = "Select"
            '
            'LabelGeneral_Type
            '
            Me.LabelGeneral_Type.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGeneral_Type.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGeneral_Type.Location = New System.Drawing.Point(4, 4)
            Me.LabelGeneral_Type.Name = "LabelGeneral_Type"
            Me.LabelGeneral_Type.Size = New System.Drawing.Size(57, 20)
            Me.LabelGeneral_Type.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGeneral_Type.TabIndex = 0
            Me.LabelGeneral_Type.Text = "Type:"
            '
            'TabItemActivitySettings_GeneralTab
            '
            Me.TabItemActivitySettings_GeneralTab.AttachedControl = Me.TabControlPanelGeneralTab_General
            Me.TabItemActivitySettings_GeneralTab.Name = "TabItemActivitySettings_GeneralTab"
            Me.TabItemActivitySettings_GeneralTab.Text = "General"
            '
            'TabControlPanelDetailsTab_Details
            '
            Me.TabControlPanelDetailsTab_Details.Controls.Add(Me.RichEditDetails_Description)
            Me.TabControlPanelDetailsTab_Details.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelDetailsTab_Details.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelDetailsTab_Details.Name = "TabControlPanelDetailsTab_Details"
            Me.TabControlPanelDetailsTab_Details.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelDetailsTab_Details.Size = New System.Drawing.Size(833, 222)
            Me.TabControlPanelDetailsTab_Details.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDetailsTab_Details.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDetailsTab_Details.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelDetailsTab_Details.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelDetailsTab_Details.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelDetailsTab_Details.Style.GradientAngle = 90
            Me.TabControlPanelDetailsTab_Details.TabIndex = 2
            Me.TabControlPanelDetailsTab_Details.TabItem = Me.TabItemActivitySettings_DetailsTab
            '
            'RichEditDetails_Description
            '
            Me.RichEditDetails_Description.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RichEditDetails_Description.HtmlText = resources.GetString("RichEditDetails_Description.HtmlText")
            Me.RichEditDetails_Description.Location = New System.Drawing.Point(4, 4)
            Me.RichEditDetails_Description.Margin = New System.Windows.Forms.Padding(4)
            Me.RichEditDetails_Description.MhtText = resources.GetString("RichEditDetails_Description.MhtText")
            Me.RichEditDetails_Description.Name = "RichEditDetails_Description"
            Me.RichEditDetails_Description.ReadOnly = False
            Me.RichEditDetails_Description.RtfText = resources.GetString("RichEditDetails_Description.RtfText")
            Me.RichEditDetails_Description.SecurityEnabled = True
            Me.RichEditDetails_Description.ShowEditButtons = True
            Me.RichEditDetails_Description.Size = New System.Drawing.Size(825, 214)
            Me.RichEditDetails_Description.TabIndex = 0
            Me.RichEditDetails_Description.WordMLText = resources.GetString("RichEditDetails_Description.WordMLText")
            '
            'TabItemActivitySettings_DetailsTab
            '
            Me.TabItemActivitySettings_DetailsTab.AttachedControl = Me.TabControlPanelDetailsTab_Details
            Me.TabItemActivitySettings_DetailsTab.Name = "TabItemActivitySettings_DetailsTab"
            Me.TabItemActivitySettings_DetailsTab.Text = "Details"
            '
            'TabControlPanelEmployeeTab_Employee
            '
            Me.TabControlPanelEmployeeTab_Employee.Controls.Add(Me.PanelEmployee_RightSection)
            Me.TabControlPanelEmployeeTab_Employee.Controls.Add(Me.ExpandableSplitterEmployee_LeftRight)
            Me.TabControlPanelEmployeeTab_Employee.Controls.Add(Me.PanelEmployee_EmployeeLeftSection)
            Me.TabControlPanelEmployeeTab_Employee.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelEmployeeTab_Employee.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelEmployeeTab_Employee.Name = "TabControlPanelEmployeeTab_Employee"
            Me.TabControlPanelEmployeeTab_Employee.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelEmployeeTab_Employee.Size = New System.Drawing.Size(833, 222)
            Me.TabControlPanelEmployeeTab_Employee.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelEmployeeTab_Employee.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelEmployeeTab_Employee.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelEmployeeTab_Employee.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelEmployeeTab_Employee.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelEmployeeTab_Employee.Style.GradientAngle = 90
            Me.TabControlPanelEmployeeTab_Employee.TabIndex = 0
            Me.TabControlPanelEmployeeTab_Employee.TabItem = Me.TabItemActivitySettings_EmployeeTab
            '
            'PanelEmployee_RightSection
            '
            Me.PanelEmployee_RightSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelEmployee_RightSection.Appearance.Options.UseBackColor = True
            Me.PanelEmployee_RightSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelEmployee_RightSection.Controls.Add(Me.ButtonEmployeeRightSection_RemoveEmployee)
            Me.PanelEmployee_RightSection.Controls.Add(Me.ButtonEmployeeRightSection_AddEmployee)
            Me.PanelEmployee_RightSection.Controls.Add(Me.DataGridViewEmployeeRightSection_SelectedEmployees)
            Me.PanelEmployee_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelEmployee_RightSection.Location = New System.Drawing.Point(354, 1)
            Me.PanelEmployee_RightSection.Name = "PanelEmployee_RightSection"
            Me.PanelEmployee_RightSection.Size = New System.Drawing.Size(478, 220)
            Me.PanelEmployee_RightSection.TabIndex = 2
            '
            'ButtonEmployeeRightSection_RemoveEmployee
            '
            Me.ButtonEmployeeRightSection_RemoveEmployee.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonEmployeeRightSection_RemoveEmployee.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonEmployeeRightSection_RemoveEmployee.Location = New System.Drawing.Point(6, 32)
            Me.ButtonEmployeeRightSection_RemoveEmployee.Name = "ButtonEmployeeRightSection_RemoveEmployee"
            Me.ButtonEmployeeRightSection_RemoveEmployee.SecurityEnabled = True
            Me.ButtonEmployeeRightSection_RemoveEmployee.Size = New System.Drawing.Size(73, 20)
            Me.ButtonEmployeeRightSection_RemoveEmployee.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonEmployeeRightSection_RemoveEmployee.TabIndex = 1
            Me.ButtonEmployeeRightSection_RemoveEmployee.Text = "<"
            '
            'ButtonEmployeeRightSection_AddEmployee
            '
            Me.ButtonEmployeeRightSection_AddEmployee.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonEmployeeRightSection_AddEmployee.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonEmployeeRightSection_AddEmployee.Location = New System.Drawing.Point(6, 6)
            Me.ButtonEmployeeRightSection_AddEmployee.Name = "ButtonEmployeeRightSection_AddEmployee"
            Me.ButtonEmployeeRightSection_AddEmployee.SecurityEnabled = True
            Me.ButtonEmployeeRightSection_AddEmployee.Size = New System.Drawing.Size(73, 20)
            Me.ButtonEmployeeRightSection_AddEmployee.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonEmployeeRightSection_AddEmployee.TabIndex = 0
            Me.ButtonEmployeeRightSection_AddEmployee.Text = ">"
            '
            'DataGridViewEmployeeRightSection_SelectedEmployees
            '
            Me.DataGridViewEmployeeRightSection_SelectedEmployees.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewEmployeeRightSection_SelectedEmployees.AllowDragAndDrop = False
            Me.DataGridViewEmployeeRightSection_SelectedEmployees.AllowSelectGroupHeaderRow = True
            Me.DataGridViewEmployeeRightSection_SelectedEmployees.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewEmployeeRightSection_SelectedEmployees.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewEmployeeRightSection_SelectedEmployees.AutoFilterLookupColumns = False
            Me.DataGridViewEmployeeRightSection_SelectedEmployees.AutoloadRepositoryDatasource = True
            Me.DataGridViewEmployeeRightSection_SelectedEmployees.AutoUpdateViewCaption = True
            Me.DataGridViewEmployeeRightSection_SelectedEmployees.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewEmployeeRightSection_SelectedEmployees.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewEmployeeRightSection_SelectedEmployees.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewEmployeeRightSection_SelectedEmployees.ItemDescription = "Employee(s)"
            Me.DataGridViewEmployeeRightSection_SelectedEmployees.Location = New System.Drawing.Point(85, 3)
            Me.DataGridViewEmployeeRightSection_SelectedEmployees.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewEmployeeRightSection_SelectedEmployees.MultiSelect = True
            Me.DataGridViewEmployeeRightSection_SelectedEmployees.Name = "DataGridViewEmployeeRightSection_SelectedEmployees"
            Me.DataGridViewEmployeeRightSection_SelectedEmployees.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewEmployeeRightSection_SelectedEmployees.RunStandardValidation = True
            Me.DataGridViewEmployeeRightSection_SelectedEmployees.ShowSelectDeselectAllButtons = False
            Me.DataGridViewEmployeeRightSection_SelectedEmployees.Size = New System.Drawing.Size(390, 215)
            Me.DataGridViewEmployeeRightSection_SelectedEmployees.TabIndex = 2
            Me.DataGridViewEmployeeRightSection_SelectedEmployees.UseEmbeddedNavigator = False
            Me.DataGridViewEmployeeRightSection_SelectedEmployees.ViewCaptionHeight = -1
            '
            'ExpandableSplitterEmployee_LeftRight
            '
            Me.ExpandableSplitterEmployee_LeftRight.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterEmployee_LeftRight.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterEmployee_LeftRight.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterEmployee_LeftRight.ExpandableControl = Me.PanelEmployee_EmployeeLeftSection
            Me.ExpandableSplitterEmployee_LeftRight.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterEmployee_LeftRight.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterEmployee_LeftRight.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterEmployee_LeftRight.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterEmployee_LeftRight.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterEmployee_LeftRight.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterEmployee_LeftRight.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterEmployee_LeftRight.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterEmployee_LeftRight.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterEmployee_LeftRight.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterEmployee_LeftRight.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterEmployee_LeftRight.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterEmployee_LeftRight.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterEmployee_LeftRight.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterEmployee_LeftRight.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterEmployee_LeftRight.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterEmployee_LeftRight.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterEmployee_LeftRight.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterEmployee_LeftRight.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterEmployee_LeftRight.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterEmployee_LeftRight.Location = New System.Drawing.Point(348, 1)
            Me.ExpandableSplitterEmployee_LeftRight.Name = "ExpandableSplitterEmployee_LeftRight"
            Me.ExpandableSplitterEmployee_LeftRight.Size = New System.Drawing.Size(6, 220)
            Me.ExpandableSplitterEmployee_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterEmployee_LeftRight.TabIndex = 1
            Me.ExpandableSplitterEmployee_LeftRight.TabStop = False
            '
            'PanelEmployee_EmployeeLeftSection
            '
            Me.PanelEmployee_EmployeeLeftSection.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelEmployee_EmployeeLeftSection.Appearance.Options.UseBackColor = True
            Me.PanelEmployee_EmployeeLeftSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelEmployee_EmployeeLeftSection.Controls.Add(Me.DataGridViewEmployeeLeftSection_AvailableEmployees)
            Me.PanelEmployee_EmployeeLeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelEmployee_EmployeeLeftSection.Location = New System.Drawing.Point(1, 1)
            Me.PanelEmployee_EmployeeLeftSection.Name = "PanelEmployee_EmployeeLeftSection"
            Me.PanelEmployee_EmployeeLeftSection.Size = New System.Drawing.Size(347, 220)
            Me.PanelEmployee_EmployeeLeftSection.TabIndex = 0
            '
            'DataGridViewEmployeeLeftSection_AvailableEmployees
            '
            Me.DataGridViewEmployeeLeftSection_AvailableEmployees.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewEmployeeLeftSection_AvailableEmployees.AllowDragAndDrop = False
            Me.DataGridViewEmployeeLeftSection_AvailableEmployees.AllowSelectGroupHeaderRow = True
            Me.DataGridViewEmployeeLeftSection_AvailableEmployees.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewEmployeeLeftSection_AvailableEmployees.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewEmployeeLeftSection_AvailableEmployees.AutoFilterLookupColumns = False
            Me.DataGridViewEmployeeLeftSection_AvailableEmployees.AutoloadRepositoryDatasource = True
            Me.DataGridViewEmployeeLeftSection_AvailableEmployees.AutoUpdateViewCaption = True
            Me.DataGridViewEmployeeLeftSection_AvailableEmployees.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewEmployeeLeftSection_AvailableEmployees.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewEmployeeLeftSection_AvailableEmployees.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewEmployeeLeftSection_AvailableEmployees.ItemDescription = "Employee(s)"
            Me.DataGridViewEmployeeLeftSection_AvailableEmployees.Location = New System.Drawing.Point(3, 3)
            Me.DataGridViewEmployeeLeftSection_AvailableEmployees.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewEmployeeLeftSection_AvailableEmployees.MultiSelect = True
            Me.DataGridViewEmployeeLeftSection_AvailableEmployees.Name = "DataGridViewEmployeeLeftSection_AvailableEmployees"
            Me.DataGridViewEmployeeLeftSection_AvailableEmployees.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewEmployeeLeftSection_AvailableEmployees.RunStandardValidation = True
            Me.DataGridViewEmployeeLeftSection_AvailableEmployees.ShowSelectDeselectAllButtons = False
            Me.DataGridViewEmployeeLeftSection_AvailableEmployees.Size = New System.Drawing.Size(338, 215)
            Me.DataGridViewEmployeeLeftSection_AvailableEmployees.TabIndex = 0
            Me.DataGridViewEmployeeLeftSection_AvailableEmployees.UseEmbeddedNavigator = False
            Me.DataGridViewEmployeeLeftSection_AvailableEmployees.ViewCaptionHeight = -1
            '
            'TabItemActivitySettings_EmployeeTab
            '
            Me.TabItemActivitySettings_EmployeeTab.AttachedControl = Me.TabControlPanelEmployeeTab_Employee
            Me.TabItemActivitySettings_EmployeeTab.Name = "TabItemActivitySettings_EmployeeTab"
            Me.TabItemActivitySettings_EmployeeTab.Text = "Employee"
            '
            'ActivityEditDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(849, 430)
            Me.CloseButtonVisible = False
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(4)
            Me.Name = "ActivityEditDialog"
            Me.Text = "Activity"
            Me.Controls.SetChildIndex(Me.BarForm_StatusBar, 0)
            Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
            Me.Controls.SetChildIndex(Me.PanelForm_Form, 0)
            Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.PerformLayout()
            Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Form.ResumeLayout(False)
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.TabControlForm_ActivitySettings, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlForm_ActivitySettings.ResumeLayout(False)
            Me.TabControlPanelGeneralTab_General.ResumeLayout(False)
            CType(Me.TimePickerGeneral_EndTime, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.TimePickerGeneral_StartTime, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxGeneral_Component.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxGeneral_ComponentView, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxGeneral_Job.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxGeneral_JobView, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxGeneral_Product.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxGeneral_ProductView, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxGeneral_Division.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxGeneral_DivisionView, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxGeneral_Client.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxGeneral_ClientView, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerGeneral_End, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerGeneral_Start, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelDetailsTab_Details.ResumeLayout(False)
            Me.TabControlPanelEmployeeTab_Employee.ResumeLayout(False)
            CType(Me.PanelEmployee_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelEmployee_RightSection.ResumeLayout(False)
            CType(Me.PanelEmployee_EmployeeLeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelEmployee_EmployeeLeftSection.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Add As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Save As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Cancel As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Delete As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents TabControlForm_ActivitySettings As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelGeneralTab_General As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemActivitySettings_GeneralTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelEmployeeTab_Employee As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemActivitySettings_EmployeeTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelDetailsTab_Details As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemActivitySettings_DetailsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents ComboBoxGeneral_Type As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelGeneral_Type As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelGeneral_Subject As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxGeneral_Subject As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents DateTimePickerGeneral_End As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents LabelGeneral_End As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents DateTimePickerGeneral_Start As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents LabelGeneral_Start As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxGeneral_AllDay As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents ComboBoxGeneral_Reminder As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelGeneral_Reminder As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxGeneral_Priority As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelGeneral_Priority As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelGeneral_Product As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelGeneral_Client As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelGeneral_Division As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelGeneral_Component As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelGeneral_Job As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxGeneral_Function As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelGeneral_Function As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxGeneral_Component As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxGeneral_ComponentView As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxGeneral_Job As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxGeneral_JobView As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxGeneral_Product As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxGeneral_ProductView As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxGeneral_Division As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxGeneral_DivisionView As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxGeneral_Client As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxGeneral_ClientView As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents PanelEmployee_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents ButtonEmployeeRightSection_RemoveEmployee As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonEmployeeRightSection_AddEmployee As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents DataGridViewEmployeeRightSection_SelectedEmployees As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ExpandableSplitterEmployee_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelEmployee_EmployeeLeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewEmployeeLeftSection_AvailableEmployees As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RichEditDetails_Description As AdvantageFramework.WinForm.Presentation.Controls.RichEditControl
        Friend WithEvents ComboBoxGeneral_Category As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelGeneral_Category As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxGeneral_Contact As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelGeneral_Contact As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TimePickerGeneral_EndTime As AdvantageFramework.WinForm.Presentation.Controls.TimePicker
        Friend WithEvents TimePickerGeneral_StartTime As AdvantageFramework.WinForm.Presentation.Controls.TimePicker

    End Class

End Namespace