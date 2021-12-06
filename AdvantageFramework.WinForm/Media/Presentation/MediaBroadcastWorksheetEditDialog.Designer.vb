Namespace Media.Presentation

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
	Partial Class MediaBroadcastWorksheetEditDialog
		Inherits AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseRibbonForm

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaBroadcastWorksheetEditDialog))
            Me.CheckBoxInformation_ArePiggybacksOK = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.CheckBoxInformation_DefaultToLatestSharebook = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.ComboBoxInformation_DateType = New AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox()
            Me.LabelInformation_DateType = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.ComboBoxInformation_MediaPlan = New AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox()
            Me.LabelInformation_MediaPlan = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.ComboBoxInformation_Campaign = New AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox()
            Me.LabelInformation_Campaign = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.DateEditInformation_EndDate = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DateEdit()
            Me.DateEditInformation_StartDate = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DateEdit()
            Me.CheckBoxInformation_IsInactive = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.LabelInformation_EndDate = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelInformation_StartDate = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.ComboBoxInformation_Product = New AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox()
            Me.ComboBoxInformation_Division = New AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox()
            Me.ComboBoxInformation_Client = New AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox()
            Me.LabelInformation_Product = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelInformation_Division = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelInformation_Client = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.ComboBoxInformation_SalesClass = New AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox()
            Me.TextBoxInformation_Name = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox()
            Me.LabelInformation_Name = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelInformation_SalesClass = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.RibbonBarFilePanel_Actions = New DevComponents.DotNetBar.RibbonBar()
            Me.ButtonItemActions_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Update = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ComboBoxInformation_Calendar = New AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox()
            Me.LabelInformation_Calendar = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.CheckBoxInformation_ProrateSecondaryDemosToPrimary = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.ComboBoxInformation_MediaType = New AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox()
            Me.LabelInformation_MediaType = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.TabControlForm_WorksheetDetails = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelInformationTab_Information = New DevComponents.DotNetBar.TabControlPanel()
            Me.LabelInformation_Country = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.ComboBoxInformation_Country = New AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox()
            Me.RadioButtonInformation_Net = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonInformation_Gross = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.NumericInputInformation_Length = New AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput()
            Me.LabelInformation_Length = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.TabItemWorksheetDetails_InformationTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelMatchingTab_Matching = New DevComponents.DotNetBar.TabControlPanel()
            Me.VerticalGridMatching_Settings = New AdvantageFramework.WinForm.MVC.Presentation.Controls.VerticalGrid()
            Me.InvoiceMatchingSettingBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.categorySpotMatchingSettings = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowGrossRate = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowNetwork = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowScheduleDates = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowDayOfWeek = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowTimeOfDay = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowTimeSeparation = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowAdNumber = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowLength = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowAdjacencyBefore = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowAdjacencyAfter = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowBookendMaxSeparation = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.TabItemWorksheetDetails_MatchingTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelCommentsTab_Comments = New DevComponents.DotNetBar.TabControlPanel()
            Me.LabelComments_MediaPlanComments = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.TextBoxComments_MediaPlanComments = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxComments_Comment = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelComments_Comment = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.TabItemWorksheetDetails_CommentsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelDemosTab_Demos = New DevComponents.DotNetBar.TabControlPanel()
            Me.LabelDemos_Source = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.ComboBoxDemos_Source = New AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox()
            Me.SearchableComboBoxDemos_PrimaryDemo = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewDemos_PrimaryDemo = New AdvantageFramework.WinForm.MVC.Presentation.Controls.GridView()
            Me.DataGridViewDemos_SecondaryDemos = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.LabelDemos_PrimaryDemo = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.TabItemWorksheetDetails_DemosTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.RibbonBarFilePanel_Demos = New DevComponents.DotNetBar.RibbonBar()
            Me.ButtonItemDemos_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDemos_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarFilePanel_Matching = New DevComponents.DotNetBar.RibbonBar()
            Me.ButtonItemMatching_Defaults = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemMatching_SeparationSettings = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.CheckBoxInformation_DefaultToMostRecentFourWeekRatings = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Form.SuspendLayout()
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateEditInformation_EndDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateEditInformation_EndDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateEditInformation_StartDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateEditInformation_StartDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.TabControlForm_WorksheetDetails, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlForm_WorksheetDetails.SuspendLayout()
            Me.TabControlPanelInformationTab_Information.SuspendLayout()
            CType(Me.NumericInputInformation_Length.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelMatchingTab_Matching.SuspendLayout()
            CType(Me.VerticalGridMatching_Settings, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.InvoiceMatchingSettingBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelCommentsTab_Comments.SuspendLayout()
            Me.TabControlPanelDemosTab_Demos.SuspendLayout()
            CType(Me.SearchableComboBoxDemos_PrimaryDemo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewDemos_PrimaryDemo, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            '_DefaultLookAndFeel
            '
            Me._DefaultLookAndFeel.LookAndFeel.SkinName = "Office 2016 Colorful"
            '
            'PanelForm_Form
            '
            Me.PanelForm_Form.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelForm_Form.Appearance.Options.UseBackColor = True
            Me.PanelForm_Form.Controls.Add(Me.TabControlForm_WorksheetDetails)
            Me.PanelForm_Form.LookAndFeel.SkinName = "Office 2013"
            Me.PanelForm_Form.LookAndFeel.UseDefaultLookAndFeel = False
            Me.PanelForm_Form.Size = New System.Drawing.Size(551, 449)
            Me.PanelForm_Form.TabIndex = 0
            '
            'RibbonControlForm_MainRibbon
            '
            '
            '
            '
            Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(551, 154)
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
            Me.RibbonControlForm_MainRibbon.Controls.SetChildIndex(Me.RibbonPanelFile_FilePanel, 0)
            '
            'RibbonPanelFile_FilePanel
            '
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarFilePanel_Matching)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarFilePanel_Demos)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarFilePanel_Actions)
            Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 57)
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(551, 94)
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
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarFilePanel_System, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarFilePanel_Actions, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarFilePanel_Demos, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarFilePanel_Matching, 0)
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
            Me.RibbonBarFilePanel_System.Size = New System.Drawing.Size(100, 92)
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
            'ProgressBarItemStatusBar_ProgressBar
            '
            '
            '
            '
            Me.ProgressBarItemStatusBar_ProgressBar.BackStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'BarForm_StatusBar
            '
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 604)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(551, 18)
            '
            'CheckBoxInformation_ArePiggybacksOK
            '
            Me.CheckBoxInformation_ArePiggybacksOK.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxInformation_ArePiggybacksOK.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxInformation_ArePiggybacksOK.CheckValue = 0
            Me.CheckBoxInformation_ArePiggybacksOK.CheckValueChecked = 1
            Me.CheckBoxInformation_ArePiggybacksOK.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxInformation_ArePiggybacksOK.CheckValueUnchecked = 0
            Me.CheckBoxInformation_ArePiggybacksOK.ChildControls = Nothing
            Me.CheckBoxInformation_ArePiggybacksOK.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxInformation_ArePiggybacksOK.Location = New System.Drawing.Point(255, 370)
            Me.CheckBoxInformation_ArePiggybacksOK.Name = "CheckBoxInformation_ArePiggybacksOK"
            Me.CheckBoxInformation_ArePiggybacksOK.OldestSibling = Nothing
            Me.CheckBoxInformation_ArePiggybacksOK.SecurityEnabled = True
            Me.CheckBoxInformation_ArePiggybacksOK.SiblingControls = Nothing
            Me.CheckBoxInformation_ArePiggybacksOK.Size = New System.Drawing.Size(226, 20)
            Me.CheckBoxInformation_ArePiggybacksOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxInformation_ArePiggybacksOK.TabIndex = 33
            Me.CheckBoxInformation_ArePiggybacksOK.TabOnEnter = True
            Me.CheckBoxInformation_ArePiggybacksOK.Text = "Piggybacks OK?"
            Me.CheckBoxInformation_ArePiggybacksOK.Visible = False
            '
            'CheckBoxInformation_DefaultToLatestSharebook
            '
            Me.CheckBoxInformation_DefaultToLatestSharebook.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxInformation_DefaultToLatestSharebook.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxInformation_DefaultToLatestSharebook.CheckValue = 0
            Me.CheckBoxInformation_DefaultToLatestSharebook.CheckValueChecked = 1
            Me.CheckBoxInformation_DefaultToLatestSharebook.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxInformation_DefaultToLatestSharebook.CheckValueUnchecked = 0
            Me.CheckBoxInformation_DefaultToLatestSharebook.ChildControls = Nothing
            Me.CheckBoxInformation_DefaultToLatestSharebook.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxInformation_DefaultToLatestSharebook.Location = New System.Drawing.Point(255, 318)
            Me.CheckBoxInformation_DefaultToLatestSharebook.Name = "CheckBoxInformation_DefaultToLatestSharebook"
            Me.CheckBoxInformation_DefaultToLatestSharebook.OldestSibling = Nothing
            Me.CheckBoxInformation_DefaultToLatestSharebook.SecurityEnabled = True
            Me.CheckBoxInformation_DefaultToLatestSharebook.SiblingControls = Nothing
            Me.CheckBoxInformation_DefaultToLatestSharebook.Size = New System.Drawing.Size(226, 20)
            Me.CheckBoxInformation_DefaultToLatestSharebook.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxInformation_DefaultToLatestSharebook.TabIndex = 30
            Me.CheckBoxInformation_DefaultToLatestSharebook.TabOnEnter = True
            Me.CheckBoxInformation_DefaultToLatestSharebook.Text = "Default to latest Share book"
            '
            'ComboBoxInformation_DateType
            '
            Me.ComboBoxInformation_DateType.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxInformation_DateType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxInformation_DateType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxInformation_DateType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxInformation_DateType.AutoFindItemInDataSource = False
            Me.ComboBoxInformation_DateType.AutoSelectSingleItemDatasource = False
            Me.ComboBoxInformation_DateType.BookmarkingEnabled = False
            Me.ComboBoxInformation_DateType.DisableMouseWheel = False
            Me.ComboBoxInformation_DateType.DisplayName = ""
            Me.ComboBoxInformation_DateType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxInformation_DateType.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxInformation_DateType.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxInformation_DateType.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxInformation_DateType.FocusHighlightEnabled = True
            Me.ComboBoxInformation_DateType.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxInformation_DateType.FormattingEnabled = True
            Me.ComboBoxInformation_DateType.ItemHeight = 16
            Me.ComboBoxInformation_DateType.Location = New System.Drawing.Point(97, 210)
            Me.ComboBoxInformation_DateType.Name = "ComboBoxInformation_DateType"
            Me.ComboBoxInformation_DateType.ReadOnly = False
            Me.ComboBoxInformation_DateType.SecurityEnabled = True
            Me.ComboBoxInformation_DateType.Size = New System.Drawing.Size(426, 22)
            Me.ComboBoxInformation_DateType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxInformation_DateType.TabIndex = 17
            Me.ComboBoxInformation_DateType.TabOnEnter = True
            Me.ComboBoxInformation_DateType.WatermarkText = "Select"
            '
            'LabelInformation_DateType
            '
            Me.LabelInformation_DateType.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelInformation_DateType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelInformation_DateType.Location = New System.Drawing.Point(4, 210)
            Me.LabelInformation_DateType.Name = "LabelInformation_DateType"
            Me.LabelInformation_DateType.Size = New System.Drawing.Size(87, 20)
            Me.LabelInformation_DateType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelInformation_DateType.TabIndex = 16
            Me.LabelInformation_DateType.Text = "Date Type:"
            '
            'ComboBoxInformation_MediaPlan
            '
            Me.ComboBoxInformation_MediaPlan.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxInformation_MediaPlan.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxInformation_MediaPlan.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxInformation_MediaPlan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxInformation_MediaPlan.AutoFindItemInDataSource = False
            Me.ComboBoxInformation_MediaPlan.AutoSelectSingleItemDatasource = False
            Me.ComboBoxInformation_MediaPlan.BookmarkingEnabled = False
            Me.ComboBoxInformation_MediaPlan.DisableMouseWheel = False
            Me.ComboBoxInformation_MediaPlan.DisplayName = ""
            Me.ComboBoxInformation_MediaPlan.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxInformation_MediaPlan.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxInformation_MediaPlan.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxInformation_MediaPlan.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxInformation_MediaPlan.FocusHighlightEnabled = True
            Me.ComboBoxInformation_MediaPlan.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxInformation_MediaPlan.FormattingEnabled = True
            Me.ComboBoxInformation_MediaPlan.ItemHeight = 16
            Me.ComboBoxInformation_MediaPlan.Location = New System.Drawing.Point(97, 158)
            Me.ComboBoxInformation_MediaPlan.Name = "ComboBoxInformation_MediaPlan"
            Me.ComboBoxInformation_MediaPlan.ReadOnly = False
            Me.ComboBoxInformation_MediaPlan.SecurityEnabled = True
            Me.ComboBoxInformation_MediaPlan.Size = New System.Drawing.Size(426, 22)
            Me.ComboBoxInformation_MediaPlan.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxInformation_MediaPlan.TabIndex = 13
            Me.ComboBoxInformation_MediaPlan.TabOnEnter = True
            Me.ComboBoxInformation_MediaPlan.WatermarkText = "Select Media Plan"
            '
            'LabelInformation_MediaPlan
            '
            Me.LabelInformation_MediaPlan.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelInformation_MediaPlan.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelInformation_MediaPlan.Location = New System.Drawing.Point(4, 158)
            Me.LabelInformation_MediaPlan.Name = "LabelInformation_MediaPlan"
            Me.LabelInformation_MediaPlan.Size = New System.Drawing.Size(87, 20)
            Me.LabelInformation_MediaPlan.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelInformation_MediaPlan.TabIndex = 12
            Me.LabelInformation_MediaPlan.Text = "Media Plan:"
            '
            'ComboBoxInformation_Campaign
            '
            Me.ComboBoxInformation_Campaign.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxInformation_Campaign.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxInformation_Campaign.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxInformation_Campaign.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxInformation_Campaign.AutoFindItemInDataSource = False
            Me.ComboBoxInformation_Campaign.AutoSelectSingleItemDatasource = False
            Me.ComboBoxInformation_Campaign.BookmarkingEnabled = False
            Me.ComboBoxInformation_Campaign.DisableMouseWheel = False
            Me.ComboBoxInformation_Campaign.DisplayName = ""
            Me.ComboBoxInformation_Campaign.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxInformation_Campaign.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxInformation_Campaign.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxInformation_Campaign.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxInformation_Campaign.FocusHighlightEnabled = True
            Me.ComboBoxInformation_Campaign.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxInformation_Campaign.FormattingEnabled = True
            Me.ComboBoxInformation_Campaign.ItemHeight = 16
            Me.ComboBoxInformation_Campaign.Location = New System.Drawing.Point(97, 184)
            Me.ComboBoxInformation_Campaign.Name = "ComboBoxInformation_Campaign"
            Me.ComboBoxInformation_Campaign.ReadOnly = False
            Me.ComboBoxInformation_Campaign.SecurityEnabled = True
            Me.ComboBoxInformation_Campaign.Size = New System.Drawing.Size(426, 22)
            Me.ComboBoxInformation_Campaign.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxInformation_Campaign.TabIndex = 15
            Me.ComboBoxInformation_Campaign.TabOnEnter = True
            Me.ComboBoxInformation_Campaign.WatermarkText = "Select Campaign"
            '
            'LabelInformation_Campaign
            '
            Me.LabelInformation_Campaign.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelInformation_Campaign.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelInformation_Campaign.Location = New System.Drawing.Point(4, 184)
            Me.LabelInformation_Campaign.Name = "LabelInformation_Campaign"
            Me.LabelInformation_Campaign.Size = New System.Drawing.Size(87, 20)
            Me.LabelInformation_Campaign.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelInformation_Campaign.TabIndex = 14
            Me.LabelInformation_Campaign.Text = "Campaign:"
            '
            'DateEditInformation_EndDate
            '
            Me.DateEditInformation_EndDate.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.DateEdit.Type.[Default]
            Me.DateEditInformation_EndDate.DisplayName = ""
            Me.DateEditInformation_EndDate.EditValue = Nothing
            Me.DateEditInformation_EndDate.Location = New System.Drawing.Point(329, 266)
            Me.DateEditInformation_EndDate.Name = "DateEditInformation_EndDate"
            Me.DateEditInformation_EndDate.Properties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.[False]
            Me.DateEditInformation_EndDate.Properties.AllowMouseWheel = False
            Me.DateEditInformation_EndDate.Properties.Appearance.BackColor = System.Drawing.Color.White
            Me.DateEditInformation_EndDate.Properties.Appearance.Options.UseBackColor = True
            Me.DateEditInformation_EndDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.DateEditInformation_EndDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.DateEditInformation_EndDate.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista
            Me.DateEditInformation_EndDate.Properties.DisplayFormat.FormatString = "MM/dd/yyyy"
            Me.DateEditInformation_EndDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            Me.DateEditInformation_EndDate.Properties.EditFormat.FormatString = "MM/dd/yyyy"
            Me.DateEditInformation_EndDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            Me.DateEditInformation_EndDate.Properties.Mask.EditMask = ""
            Me.DateEditInformation_EndDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
            Me.DateEditInformation_EndDate.Properties.MaxValue = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateEditInformation_EndDate.Properties.MinValue = New Date(1900, 1, 1, 0, 0, 0, 0)
            Me.DateEditInformation_EndDate.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[True]
            Me.DateEditInformation_EndDate.SecurityEnabled = True
            Me.DateEditInformation_EndDate.Size = New System.Drawing.Size(152, 20)
            Me.DateEditInformation_EndDate.TabIndex = 23
            Me.DateEditInformation_EndDate.TabOnEnter = True
            Me.DateEditInformation_EndDate.Tag = "9/2/2015"
            '
            'DateEditInformation_StartDate
            '
            Me.DateEditInformation_StartDate.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.DateEdit.Type.[Default]
            Me.DateEditInformation_StartDate.DisplayName = ""
            Me.DateEditInformation_StartDate.EditValue = Nothing
            Me.DateEditInformation_StartDate.Location = New System.Drawing.Point(97, 266)
            Me.DateEditInformation_StartDate.Name = "DateEditInformation_StartDate"
            Me.DateEditInformation_StartDate.Properties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.[False]
            Me.DateEditInformation_StartDate.Properties.AllowMouseWheel = False
            Me.DateEditInformation_StartDate.Properties.Appearance.BackColor = System.Drawing.Color.White
            Me.DateEditInformation_StartDate.Properties.Appearance.Options.UseBackColor = True
            Me.DateEditInformation_StartDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.DateEditInformation_StartDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.DateEditInformation_StartDate.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista
            Me.DateEditInformation_StartDate.Properties.DisplayFormat.FormatString = "MM/dd/yyyy"
            Me.DateEditInformation_StartDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            Me.DateEditInformation_StartDate.Properties.EditFormat.FormatString = "MM/dd/yyyy"
            Me.DateEditInformation_StartDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            Me.DateEditInformation_StartDate.Properties.Mask.EditMask = ""
            Me.DateEditInformation_StartDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
            Me.DateEditInformation_StartDate.Properties.MaxValue = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateEditInformation_StartDate.Properties.MinValue = New Date(1900, 1, 1, 0, 0, 0, 0)
            Me.DateEditInformation_StartDate.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[True]
            Me.DateEditInformation_StartDate.SecurityEnabled = True
            Me.DateEditInformation_StartDate.Size = New System.Drawing.Size(152, 20)
            Me.DateEditInformation_StartDate.TabIndex = 21
            Me.DateEditInformation_StartDate.TabOnEnter = True
            Me.DateEditInformation_StartDate.Tag = "9/2/2015"
            '
            'CheckBoxInformation_IsInactive
            '
            Me.CheckBoxInformation_IsInactive.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxInformation_IsInactive.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxInformation_IsInactive.CheckValue = 0
            Me.CheckBoxInformation_IsInactive.CheckValueChecked = 1
            Me.CheckBoxInformation_IsInactive.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxInformation_IsInactive.CheckValueUnchecked = 0
            Me.CheckBoxInformation_IsInactive.ChildControls = Nothing
            Me.CheckBoxInformation_IsInactive.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxInformation_IsInactive.Location = New System.Drawing.Point(97, 344)
            Me.CheckBoxInformation_IsInactive.Name = "CheckBoxInformation_IsInactive"
            Me.CheckBoxInformation_IsInactive.OldestSibling = Nothing
            Me.CheckBoxInformation_IsInactive.SecurityEnabled = True
            Me.CheckBoxInformation_IsInactive.SiblingControls = Nothing
            Me.CheckBoxInformation_IsInactive.Size = New System.Drawing.Size(152, 20)
            Me.CheckBoxInformation_IsInactive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxInformation_IsInactive.TabIndex = 31
            Me.CheckBoxInformation_IsInactive.TabOnEnter = True
            Me.CheckBoxInformation_IsInactive.Text = "Inactive"
            '
            'LabelInformation_EndDate
            '
            Me.LabelInformation_EndDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelInformation_EndDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelInformation_EndDate.Location = New System.Drawing.Point(255, 266)
            Me.LabelInformation_EndDate.Name = "LabelInformation_EndDate"
            Me.LabelInformation_EndDate.Size = New System.Drawing.Size(68, 20)
            Me.LabelInformation_EndDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelInformation_EndDate.TabIndex = 22
            Me.LabelInformation_EndDate.Text = "End Date:"
            '
            'LabelInformation_StartDate
            '
            Me.LabelInformation_StartDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelInformation_StartDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelInformation_StartDate.Location = New System.Drawing.Point(4, 266)
            Me.LabelInformation_StartDate.Name = "LabelInformation_StartDate"
            Me.LabelInformation_StartDate.Size = New System.Drawing.Size(87, 20)
            Me.LabelInformation_StartDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelInformation_StartDate.TabIndex = 20
            Me.LabelInformation_StartDate.Text = "Start Date:"
            '
            'ComboBoxInformation_Product
            '
            Me.ComboBoxInformation_Product.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxInformation_Product.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxInformation_Product.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxInformation_Product.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxInformation_Product.AutoFindItemInDataSource = False
            Me.ComboBoxInformation_Product.AutoSelectSingleItemDatasource = False
            Me.ComboBoxInformation_Product.BookmarkingEnabled = False
            Me.ComboBoxInformation_Product.DisableMouseWheel = False
            Me.ComboBoxInformation_Product.DisplayName = ""
            Me.ComboBoxInformation_Product.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxInformation_Product.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxInformation_Product.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxInformation_Product.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxInformation_Product.FocusHighlightEnabled = True
            Me.ComboBoxInformation_Product.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxInformation_Product.FormattingEnabled = True
            Me.ComboBoxInformation_Product.ItemHeight = 16
            Me.ComboBoxInformation_Product.Location = New System.Drawing.Point(97, 106)
            Me.ComboBoxInformation_Product.Name = "ComboBoxInformation_Product"
            Me.ComboBoxInformation_Product.ReadOnly = False
            Me.ComboBoxInformation_Product.SecurityEnabled = True
            Me.ComboBoxInformation_Product.Size = New System.Drawing.Size(426, 22)
            Me.ComboBoxInformation_Product.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxInformation_Product.TabIndex = 9
            Me.ComboBoxInformation_Product.TabOnEnter = True
            Me.ComboBoxInformation_Product.WatermarkText = "Product"
            '
            'ComboBoxInformation_Division
            '
            Me.ComboBoxInformation_Division.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxInformation_Division.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxInformation_Division.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxInformation_Division.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxInformation_Division.AutoFindItemInDataSource = False
            Me.ComboBoxInformation_Division.AutoSelectSingleItemDatasource = False
            Me.ComboBoxInformation_Division.BookmarkingEnabled = False
            Me.ComboBoxInformation_Division.DisableMouseWheel = False
            Me.ComboBoxInformation_Division.DisplayName = ""
            Me.ComboBoxInformation_Division.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxInformation_Division.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxInformation_Division.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxInformation_Division.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxInformation_Division.FocusHighlightEnabled = True
            Me.ComboBoxInformation_Division.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxInformation_Division.FormattingEnabled = True
            Me.ComboBoxInformation_Division.ItemHeight = 16
            Me.ComboBoxInformation_Division.Location = New System.Drawing.Point(97, 81)
            Me.ComboBoxInformation_Division.Name = "ComboBoxInformation_Division"
            Me.ComboBoxInformation_Division.ReadOnly = False
            Me.ComboBoxInformation_Division.SecurityEnabled = True
            Me.ComboBoxInformation_Division.Size = New System.Drawing.Size(426, 22)
            Me.ComboBoxInformation_Division.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxInformation_Division.TabIndex = 7
            Me.ComboBoxInformation_Division.TabOnEnter = True
            Me.ComboBoxInformation_Division.WatermarkText = "Division"
            '
            'ComboBoxInformation_Client
            '
            Me.ComboBoxInformation_Client.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxInformation_Client.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxInformation_Client.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxInformation_Client.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxInformation_Client.AutoFindItemInDataSource = False
            Me.ComboBoxInformation_Client.AutoSelectSingleItemDatasource = False
            Me.ComboBoxInformation_Client.BookmarkingEnabled = False
            Me.ComboBoxInformation_Client.DisableMouseWheel = False
            Me.ComboBoxInformation_Client.DisplayName = ""
            Me.ComboBoxInformation_Client.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxInformation_Client.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxInformation_Client.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxInformation_Client.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxInformation_Client.FocusHighlightEnabled = True
            Me.ComboBoxInformation_Client.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxInformation_Client.FormattingEnabled = True
            Me.ComboBoxInformation_Client.ItemHeight = 16
            Me.ComboBoxInformation_Client.Location = New System.Drawing.Point(97, 56)
            Me.ComboBoxInformation_Client.Name = "ComboBoxInformation_Client"
            Me.ComboBoxInformation_Client.ReadOnly = False
            Me.ComboBoxInformation_Client.SecurityEnabled = True
            Me.ComboBoxInformation_Client.Size = New System.Drawing.Size(426, 22)
            Me.ComboBoxInformation_Client.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxInformation_Client.TabIndex = 5
            Me.ComboBoxInformation_Client.TabOnEnter = True
            Me.ComboBoxInformation_Client.WatermarkText = "Select Client"
            '
            'LabelInformation_Product
            '
            Me.LabelInformation_Product.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelInformation_Product.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelInformation_Product.Location = New System.Drawing.Point(4, 106)
            Me.LabelInformation_Product.Name = "LabelInformation_Product"
            Me.LabelInformation_Product.Size = New System.Drawing.Size(87, 20)
            Me.LabelInformation_Product.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelInformation_Product.TabIndex = 8
            Me.LabelInformation_Product.Text = "Product:"
            '
            'LabelInformation_Division
            '
            Me.LabelInformation_Division.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelInformation_Division.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelInformation_Division.Location = New System.Drawing.Point(4, 81)
            Me.LabelInformation_Division.Name = "LabelInformation_Division"
            Me.LabelInformation_Division.Size = New System.Drawing.Size(87, 20)
            Me.LabelInformation_Division.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelInformation_Division.TabIndex = 6
            Me.LabelInformation_Division.Text = "Division:"
            '
            'LabelInformation_Client
            '
            Me.LabelInformation_Client.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelInformation_Client.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelInformation_Client.Location = New System.Drawing.Point(4, 56)
            Me.LabelInformation_Client.Name = "LabelInformation_Client"
            Me.LabelInformation_Client.Size = New System.Drawing.Size(87, 20)
            Me.LabelInformation_Client.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelInformation_Client.TabIndex = 4
            Me.LabelInformation_Client.Text = "Client:"
            '
            'ComboBoxInformation_SalesClass
            '
            Me.ComboBoxInformation_SalesClass.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxInformation_SalesClass.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxInformation_SalesClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxInformation_SalesClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxInformation_SalesClass.AutoFindItemInDataSource = False
            Me.ComboBoxInformation_SalesClass.AutoSelectSingleItemDatasource = False
            Me.ComboBoxInformation_SalesClass.BookmarkingEnabled = False
            Me.ComboBoxInformation_SalesClass.DisableMouseWheel = False
            Me.ComboBoxInformation_SalesClass.DisplayName = ""
            Me.ComboBoxInformation_SalesClass.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxInformation_SalesClass.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxInformation_SalesClass.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxInformation_SalesClass.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxInformation_SalesClass.FocusHighlightEnabled = True
            Me.ComboBoxInformation_SalesClass.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxInformation_SalesClass.FormattingEnabled = True
            Me.ComboBoxInformation_SalesClass.ItemHeight = 16
            Me.ComboBoxInformation_SalesClass.Location = New System.Drawing.Point(97, 132)
            Me.ComboBoxInformation_SalesClass.Name = "ComboBoxInformation_SalesClass"
            Me.ComboBoxInformation_SalesClass.ReadOnly = False
            Me.ComboBoxInformation_SalesClass.SecurityEnabled = True
            Me.ComboBoxInformation_SalesClass.Size = New System.Drawing.Size(426, 22)
            Me.ComboBoxInformation_SalesClass.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxInformation_SalesClass.TabIndex = 11
            Me.ComboBoxInformation_SalesClass.TabOnEnter = True
            Me.ComboBoxInformation_SalesClass.WatermarkText = "Select Job"
            '
            'TextBoxInformation_Name
            '
            Me.TextBoxInformation_Name.AgencyImportPath = Nothing
            Me.TextBoxInformation_Name.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxInformation_Name.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxInformation_Name.Border.Class = "TextBoxBorder"
            Me.TextBoxInformation_Name.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxInformation_Name.CheckSpellingOnValidate = False
            Me.TextBoxInformation_Name.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxInformation_Name.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxInformation_Name.DisplayName = ""
            Me.TextBoxInformation_Name.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxInformation_Name.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxInformation_Name.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxInformation_Name.FocusHighlightEnabled = True
            Me.TextBoxInformation_Name.ForeColor = System.Drawing.Color.Black
            Me.TextBoxInformation_Name.Location = New System.Drawing.Point(97, 30)
            Me.TextBoxInformation_Name.MaxFileSize = CType(0, Long)
            Me.TextBoxInformation_Name.Name = "TextBoxInformation_Name"
            Me.TextBoxInformation_Name.SecurityEnabled = True
            Me.TextBoxInformation_Name.ShowSpellCheckCompleteMessage = True
            Me.TextBoxInformation_Name.Size = New System.Drawing.Size(426, 21)
            Me.TextBoxInformation_Name.StartingFolderName = Nothing
            Me.TextBoxInformation_Name.TabIndex = 3
            Me.TextBoxInformation_Name.TabOnEnter = True
            '
            'LabelInformation_Name
            '
            Me.LabelInformation_Name.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelInformation_Name.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelInformation_Name.Location = New System.Drawing.Point(4, 30)
            Me.LabelInformation_Name.Name = "LabelInformation_Name"
            Me.LabelInformation_Name.Size = New System.Drawing.Size(87, 20)
            Me.LabelInformation_Name.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelInformation_Name.TabIndex = 2
            Me.LabelInformation_Name.Text = "Name:"
            '
            'LabelInformation_SalesClass
            '
            Me.LabelInformation_SalesClass.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelInformation_SalesClass.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelInformation_SalesClass.Location = New System.Drawing.Point(4, 132)
            Me.LabelInformation_SalesClass.Name = "LabelInformation_SalesClass"
            Me.LabelInformation_SalesClass.Size = New System.Drawing.Size(87, 20)
            Me.LabelInformation_SalesClass.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelInformation_SalesClass.TabIndex = 10
            Me.LabelInformation_SalesClass.Text = "Sales Class:"
            '
            'RibbonBarFilePanel_Actions
            '
            Me.RibbonBarFilePanel_Actions.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBarFilePanel_Actions.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_Actions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFilePanel_Actions.ContainerControlProcessDialogKey = True
            Me.RibbonBarFilePanel_Actions.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarFilePanel_Actions.DragDropSupport = True
            Me.RibbonBarFilePanel_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Add, Me.ButtonItemActions_Update, Me.ButtonItemActions_Cancel})
            Me.RibbonBarFilePanel_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarFilePanel_Actions.Location = New System.Drawing.Point(103, 0)
            Me.RibbonBarFilePanel_Actions.Name = "RibbonBarFilePanel_Actions"
            Me.RibbonBarFilePanel_Actions.Size = New System.Drawing.Size(145, 92)
            Me.RibbonBarFilePanel_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarFilePanel_Actions.TabIndex = 1
            Me.RibbonBarFilePanel_Actions.Text = "Actions"
            '
            '
            '
            Me.RibbonBarFilePanel_Actions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_Actions.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemActions_Add
            '
            Me.ButtonItemActions_Add.BeginGroup = True
            Me.ButtonItemActions_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Add.Name = "ButtonItemActions_Add"
            Me.ButtonItemActions_Add.RibbonWordWrap = False
            Me.ButtonItemActions_Add.SecurityEnabled = True
            Me.ButtonItemActions_Add.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Add.Text = "Add"
            '
            'ButtonItemActions_Update
            '
            Me.ButtonItemActions_Update.BeginGroup = True
            Me.ButtonItemActions_Update.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Update.Name = "ButtonItemActions_Update"
            Me.ButtonItemActions_Update.RibbonWordWrap = False
            Me.ButtonItemActions_Update.SecurityEnabled = True
            Me.ButtonItemActions_Update.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Update.Text = "Update"
            '
            'ButtonItemActions_Cancel
            '
            Me.ButtonItemActions_Cancel.BeginGroup = True
            Me.ButtonItemActions_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Cancel.Name = "ButtonItemActions_Cancel"
            Me.ButtonItemActions_Cancel.RibbonWordWrap = False
            Me.ButtonItemActions_Cancel.SecurityEnabled = True
            Me.ButtonItemActions_Cancel.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Cancel.Text = "Cancel"
            '
            'ComboBoxInformation_Calendar
            '
            Me.ComboBoxInformation_Calendar.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxInformation_Calendar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxInformation_Calendar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxInformation_Calendar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxInformation_Calendar.AutoFindItemInDataSource = False
            Me.ComboBoxInformation_Calendar.AutoSelectSingleItemDatasource = False
            Me.ComboBoxInformation_Calendar.BookmarkingEnabled = False
            Me.ComboBoxInformation_Calendar.DisableMouseWheel = False
            Me.ComboBoxInformation_Calendar.DisplayName = ""
            Me.ComboBoxInformation_Calendar.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxInformation_Calendar.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxInformation_Calendar.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxInformation_Calendar.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxInformation_Calendar.FocusHighlightEnabled = True
            Me.ComboBoxInformation_Calendar.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxInformation_Calendar.FormattingEnabled = True
            Me.ComboBoxInformation_Calendar.ItemHeight = 16
            Me.ComboBoxInformation_Calendar.Location = New System.Drawing.Point(97, 238)
            Me.ComboBoxInformation_Calendar.Name = "ComboBoxInformation_Calendar"
            Me.ComboBoxInformation_Calendar.ReadOnly = False
            Me.ComboBoxInformation_Calendar.SecurityEnabled = True
            Me.ComboBoxInformation_Calendar.Size = New System.Drawing.Size(426, 22)
            Me.ComboBoxInformation_Calendar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxInformation_Calendar.TabIndex = 19
            Me.ComboBoxInformation_Calendar.TabOnEnter = True
            Me.ComboBoxInformation_Calendar.WatermarkText = "Select"
            '
            'LabelInformation_Calendar
            '
            Me.LabelInformation_Calendar.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelInformation_Calendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelInformation_Calendar.Location = New System.Drawing.Point(4, 238)
            Me.LabelInformation_Calendar.Name = "LabelInformation_Calendar"
            Me.LabelInformation_Calendar.Size = New System.Drawing.Size(87, 20)
            Me.LabelInformation_Calendar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelInformation_Calendar.TabIndex = 18
            Me.LabelInformation_Calendar.Text = "Calendar:"
            '
            'CheckBoxInformation_ProrateSecondaryDemosToPrimary
            '
            Me.CheckBoxInformation_ProrateSecondaryDemosToPrimary.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxInformation_ProrateSecondaryDemosToPrimary.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxInformation_ProrateSecondaryDemosToPrimary.CheckValue = 0
            Me.CheckBoxInformation_ProrateSecondaryDemosToPrimary.CheckValueChecked = 1
            Me.CheckBoxInformation_ProrateSecondaryDemosToPrimary.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxInformation_ProrateSecondaryDemosToPrimary.CheckValueUnchecked = 0
            Me.CheckBoxInformation_ProrateSecondaryDemosToPrimary.ChildControls = Nothing
            Me.CheckBoxInformation_ProrateSecondaryDemosToPrimary.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxInformation_ProrateSecondaryDemosToPrimary.Location = New System.Drawing.Point(255, 344)
            Me.CheckBoxInformation_ProrateSecondaryDemosToPrimary.Name = "CheckBoxInformation_ProrateSecondaryDemosToPrimary"
            Me.CheckBoxInformation_ProrateSecondaryDemosToPrimary.OldestSibling = Nothing
            Me.CheckBoxInformation_ProrateSecondaryDemosToPrimary.SecurityEnabled = True
            Me.CheckBoxInformation_ProrateSecondaryDemosToPrimary.SiblingControls = Nothing
            Me.CheckBoxInformation_ProrateSecondaryDemosToPrimary.Size = New System.Drawing.Size(226, 20)
            Me.CheckBoxInformation_ProrateSecondaryDemosToPrimary.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxInformation_ProrateSecondaryDemosToPrimary.TabIndex = 32
            Me.CheckBoxInformation_ProrateSecondaryDemosToPrimary.TabOnEnter = True
            Me.CheckBoxInformation_ProrateSecondaryDemosToPrimary.Text = "Prorate secondary demos to primary"
            '
            'ComboBoxInformation_MediaType
            '
            Me.ComboBoxInformation_MediaType.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxInformation_MediaType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxInformation_MediaType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxInformation_MediaType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxInformation_MediaType.AutoFindItemInDataSource = False
            Me.ComboBoxInformation_MediaType.AutoSelectSingleItemDatasource = False
            Me.ComboBoxInformation_MediaType.BookmarkingEnabled = False
            Me.ComboBoxInformation_MediaType.DisableMouseWheel = False
            Me.ComboBoxInformation_MediaType.DisplayName = ""
            Me.ComboBoxInformation_MediaType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxInformation_MediaType.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxInformation_MediaType.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxInformation_MediaType.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxInformation_MediaType.FocusHighlightEnabled = True
            Me.ComboBoxInformation_MediaType.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxInformation_MediaType.FormattingEnabled = True
            Me.ComboBoxInformation_MediaType.ItemHeight = 16
            Me.ComboBoxInformation_MediaType.Location = New System.Drawing.Point(97, 2)
            Me.ComboBoxInformation_MediaType.Name = "ComboBoxInformation_MediaType"
            Me.ComboBoxInformation_MediaType.ReadOnly = False
            Me.ComboBoxInformation_MediaType.SecurityEnabled = True
            Me.ComboBoxInformation_MediaType.Size = New System.Drawing.Size(426, 22)
            Me.ComboBoxInformation_MediaType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxInformation_MediaType.TabIndex = 1
            Me.ComboBoxInformation_MediaType.TabOnEnter = True
            Me.ComboBoxInformation_MediaType.WatermarkText = "Select Client"
            '
            'LabelInformation_MediaType
            '
            Me.LabelInformation_MediaType.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelInformation_MediaType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelInformation_MediaType.Location = New System.Drawing.Point(4, 4)
            Me.LabelInformation_MediaType.Name = "LabelInformation_MediaType"
            Me.LabelInformation_MediaType.Size = New System.Drawing.Size(87, 20)
            Me.LabelInformation_MediaType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelInformation_MediaType.TabIndex = 0
            Me.LabelInformation_MediaType.Text = "Media Type:"
            '
            'TabControlForm_WorksheetDetails
            '
            Me.TabControlForm_WorksheetDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlForm_WorksheetDetails.BackColor = System.Drawing.Color.White
            Me.TabControlForm_WorksheetDetails.CanReorderTabs = False
            Me.TabControlForm_WorksheetDetails.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlForm_WorksheetDetails.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlForm_WorksheetDetails.Controls.Add(Me.TabControlPanelInformationTab_Information)
            Me.TabControlForm_WorksheetDetails.Controls.Add(Me.TabControlPanelMatchingTab_Matching)
            Me.TabControlForm_WorksheetDetails.Controls.Add(Me.TabControlPanelCommentsTab_Comments)
            Me.TabControlForm_WorksheetDetails.Controls.Add(Me.TabControlPanelDemosTab_Demos)
            Me.TabControlForm_WorksheetDetails.Location = New System.Drawing.Point(12, 6)
            Me.TabControlForm_WorksheetDetails.Name = "TabControlForm_WorksheetDetails"
            Me.TabControlForm_WorksheetDetails.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlForm_WorksheetDetails.SelectedTabIndex = 0
            Me.TabControlForm_WorksheetDetails.Size = New System.Drawing.Size(527, 437)
            Me.TabControlForm_WorksheetDetails.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlForm_WorksheetDetails.TabIndex = 28
            Me.TabControlForm_WorksheetDetails.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlForm_WorksheetDetails.Tabs.Add(Me.TabItemWorksheetDetails_InformationTab)
            Me.TabControlForm_WorksheetDetails.Tabs.Add(Me.TabItemWorksheetDetails_DemosTab)
            Me.TabControlForm_WorksheetDetails.Tabs.Add(Me.TabItemWorksheetDetails_CommentsTab)
            Me.TabControlForm_WorksheetDetails.Tabs.Add(Me.TabItemWorksheetDetails_MatchingTab)
            Me.TabControlForm_WorksheetDetails.Text = "TabControl1"
            '
            'TabControlPanelInformationTab_Information
            '
            Me.TabControlPanelInformationTab_Information.Controls.Add(Me.LabelInformation_Country)
            Me.TabControlPanelInformationTab_Information.Controls.Add(Me.ComboBoxInformation_Country)
            Me.TabControlPanelInformationTab_Information.Controls.Add(Me.RadioButtonInformation_Net)
            Me.TabControlPanelInformationTab_Information.Controls.Add(Me.RadioButtonInformation_Gross)
            Me.TabControlPanelInformationTab_Information.Controls.Add(Me.NumericInputInformation_Length)
            Me.TabControlPanelInformationTab_Information.Controls.Add(Me.LabelInformation_Length)
            Me.TabControlPanelInformationTab_Information.Controls.Add(Me.LabelInformation_MediaType)
            Me.TabControlPanelInformationTab_Information.Controls.Add(Me.ComboBoxInformation_MediaType)
            Me.TabControlPanelInformationTab_Information.Controls.Add(Me.LabelInformation_SalesClass)
            Me.TabControlPanelInformationTab_Information.Controls.Add(Me.LabelInformation_Name)
            Me.TabControlPanelInformationTab_Information.Controls.Add(Me.TextBoxInformation_Name)
            Me.TabControlPanelInformationTab_Information.Controls.Add(Me.CheckBoxInformation_ProrateSecondaryDemosToPrimary)
            Me.TabControlPanelInformationTab_Information.Controls.Add(Me.ComboBoxInformation_Calendar)
            Me.TabControlPanelInformationTab_Information.Controls.Add(Me.ComboBoxInformation_SalesClass)
            Me.TabControlPanelInformationTab_Information.Controls.Add(Me.LabelInformation_Client)
            Me.TabControlPanelInformationTab_Information.Controls.Add(Me.LabelInformation_Calendar)
            Me.TabControlPanelInformationTab_Information.Controls.Add(Me.LabelInformation_Division)
            Me.TabControlPanelInformationTab_Information.Controls.Add(Me.CheckBoxInformation_ArePiggybacksOK)
            Me.TabControlPanelInformationTab_Information.Controls.Add(Me.LabelInformation_Product)
            Me.TabControlPanelInformationTab_Information.Controls.Add(Me.CheckBoxInformation_DefaultToLatestSharebook)
            Me.TabControlPanelInformationTab_Information.Controls.Add(Me.ComboBoxInformation_DateType)
            Me.TabControlPanelInformationTab_Information.Controls.Add(Me.ComboBoxInformation_Client)
            Me.TabControlPanelInformationTab_Information.Controls.Add(Me.LabelInformation_DateType)
            Me.TabControlPanelInformationTab_Information.Controls.Add(Me.ComboBoxInformation_Division)
            Me.TabControlPanelInformationTab_Information.Controls.Add(Me.ComboBoxInformation_MediaPlan)
            Me.TabControlPanelInformationTab_Information.Controls.Add(Me.ComboBoxInformation_Product)
            Me.TabControlPanelInformationTab_Information.Controls.Add(Me.LabelInformation_MediaPlan)
            Me.TabControlPanelInformationTab_Information.Controls.Add(Me.LabelInformation_StartDate)
            Me.TabControlPanelInformationTab_Information.Controls.Add(Me.ComboBoxInformation_Campaign)
            Me.TabControlPanelInformationTab_Information.Controls.Add(Me.LabelInformation_EndDate)
            Me.TabControlPanelInformationTab_Information.Controls.Add(Me.CheckBoxInformation_IsInactive)
            Me.TabControlPanelInformationTab_Information.Controls.Add(Me.LabelInformation_Campaign)
            Me.TabControlPanelInformationTab_Information.Controls.Add(Me.DateEditInformation_StartDate)
            Me.TabControlPanelInformationTab_Information.Controls.Add(Me.DateEditInformation_EndDate)
            Me.TabControlPanelInformationTab_Information.Controls.Add(Me.CheckBoxInformation_DefaultToMostRecentFourWeekRatings)
            Me.TabControlPanelInformationTab_Information.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelInformationTab_Information.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelInformationTab_Information.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelInformationTab_Information.Name = "TabControlPanelInformationTab_Information"
            Me.TabControlPanelInformationTab_Information.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelInformationTab_Information.Size = New System.Drawing.Size(527, 410)
            Me.TabControlPanelInformationTab_Information.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelInformationTab_Information.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelInformationTab_Information.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelInformationTab_Information.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelInformationTab_Information.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelInformationTab_Information.Style.GradientAngle = 90
            Me.TabControlPanelInformationTab_Information.TabIndex = 0
            Me.TabControlPanelInformationTab_Information.TabItem = Me.TabItemWorksheetDetails_InformationTab
            '
            'LabelInformation_Country
            '
            Me.LabelInformation_Country.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelInformation_Country.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelInformation_Country.Location = New System.Drawing.Point(4, 318)
            Me.LabelInformation_Country.Name = "LabelInformation_Country"
            Me.LabelInformation_Country.Size = New System.Drawing.Size(87, 20)
            Me.LabelInformation_Country.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelInformation_Country.TabIndex = 28
            Me.LabelInformation_Country.Text = "Country/Region:"
            '
            'ComboBoxInformation_Country
            '
            Me.ComboBoxInformation_Country.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxInformation_Country.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxInformation_Country.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxInformation_Country.AutoFindItemInDataSource = False
            Me.ComboBoxInformation_Country.AutoSelectSingleItemDatasource = False
            Me.ComboBoxInformation_Country.BookmarkingEnabled = False
            Me.ComboBoxInformation_Country.DisableMouseWheel = False
            Me.ComboBoxInformation_Country.DisplayName = ""
            Me.ComboBoxInformation_Country.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxInformation_Country.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxInformation_Country.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxInformation_Country.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxInformation_Country.FocusHighlightEnabled = True
            Me.ComboBoxInformation_Country.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxInformation_Country.FormattingEnabled = True
            Me.ComboBoxInformation_Country.ItemHeight = 16
            Me.ComboBoxInformation_Country.Location = New System.Drawing.Point(97, 318)
            Me.ComboBoxInformation_Country.Name = "ComboBoxInformation_Country"
            Me.ComboBoxInformation_Country.ReadOnly = False
            Me.ComboBoxInformation_Country.SecurityEnabled = True
            Me.ComboBoxInformation_Country.Size = New System.Drawing.Size(152, 22)
            Me.ComboBoxInformation_Country.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxInformation_Country.TabIndex = 29
            Me.ComboBoxInformation_Country.TabOnEnter = True
            Me.ComboBoxInformation_Country.WatermarkText = "Select Country"
            '
            'RadioButtonInformation_Net
            '
            Me.RadioButtonInformation_Net.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonInformation_Net.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonInformation_Net.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonInformation_Net.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonInformation_Net.Location = New System.Drawing.Point(348, 292)
            Me.RadioButtonInformation_Net.Name = "RadioButtonInformation_Net"
            Me.RadioButtonInformation_Net.SecurityEnabled = True
            Me.RadioButtonInformation_Net.Size = New System.Drawing.Size(154, 20)
            Me.RadioButtonInformation_Net.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonInformation_Net.TabIndex = 27
            Me.RadioButtonInformation_Net.TabOnEnter = True
            Me.RadioButtonInformation_Net.TabStop = False
            Me.RadioButtonInformation_Net.Tag = "1"
            Me.RadioButtonInformation_Net.Text = "Net Rates"
            '
            'RadioButtonInformation_Gross
            '
            Me.RadioButtonInformation_Gross.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonInformation_Gross.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonInformation_Gross.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonInformation_Gross.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonInformation_Gross.Checked = True
            Me.RadioButtonInformation_Gross.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonInformation_Gross.CheckValue = "Y"
            Me.RadioButtonInformation_Gross.Location = New System.Drawing.Point(236, 292)
            Me.RadioButtonInformation_Gross.Name = "RadioButtonInformation_Gross"
            Me.RadioButtonInformation_Gross.SecurityEnabled = True
            Me.RadioButtonInformation_Gross.Size = New System.Drawing.Size(146, 20)
            Me.RadioButtonInformation_Gross.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonInformation_Gross.TabIndex = 26
            Me.RadioButtonInformation_Gross.TabOnEnter = True
            Me.RadioButtonInformation_Gross.Tag = "1"
            Me.RadioButtonInformation_Gross.Text = "Gross Rates"
            '
            'NumericInputInformation_Length
            '
            Me.NumericInputInformation_Length.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputInformation_Length.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput.Type.[Short]
            Me.NumericInputInformation_Length.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputInformation_Length.EnterMoveNextControl = True
            Me.NumericInputInformation_Length.Location = New System.Drawing.Point(97, 292)
            Me.NumericInputInformation_Length.Name = "NumericInputInformation_Length"
            Me.NumericInputInformation_Length.Properties.AllowMouseWheel = False
            Me.NumericInputInformation_Length.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
            Me.NumericInputInformation_Length.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputInformation_Length.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputInformation_Length.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputInformation_Length.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputInformation_Length.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputInformation_Length.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputInformation_Length.Properties.IsFloatValue = False
            Me.NumericInputInformation_Length.Properties.Mask.EditMask = "f0"
            Me.NumericInputInformation_Length.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputInformation_Length.Properties.MaxValue = New Decimal(New Integer() {999, 0, 0, 0})
            Me.NumericInputInformation_Length.Properties.MinValue = New Decimal(New Integer() {32768, 0, 0, -2147483648})
            Me.NumericInputInformation_Length.SecurityEnabled = True
            Me.NumericInputInformation_Length.Size = New System.Drawing.Size(133, 20)
            Me.NumericInputInformation_Length.TabIndex = 25
            '
            'LabelInformation_Length
            '
            Me.LabelInformation_Length.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelInformation_Length.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelInformation_Length.Location = New System.Drawing.Point(4, 292)
            Me.LabelInformation_Length.Name = "LabelInformation_Length"
            Me.LabelInformation_Length.Size = New System.Drawing.Size(87, 20)
            Me.LabelInformation_Length.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelInformation_Length.TabIndex = 24
            Me.LabelInformation_Length.Text = "Length:"
            '
            'TabItemWorksheetDetails_InformationTab
            '
            Me.TabItemWorksheetDetails_InformationTab.AttachedControl = Me.TabControlPanelInformationTab_Information
            Me.TabItemWorksheetDetails_InformationTab.Name = "TabItemWorksheetDetails_InformationTab"
            Me.TabItemWorksheetDetails_InformationTab.Text = "Information"
            '
            'TabControlPanelMatchingTab_Matching
            '
            Me.TabControlPanelMatchingTab_Matching.Controls.Add(Me.VerticalGridMatching_Settings)
            Me.TabControlPanelMatchingTab_Matching.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelMatchingTab_Matching.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelMatchingTab_Matching.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelMatchingTab_Matching.Name = "TabControlPanelMatchingTab_Matching"
            Me.TabControlPanelMatchingTab_Matching.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelMatchingTab_Matching.Size = New System.Drawing.Size(527, 410)
            Me.TabControlPanelMatchingTab_Matching.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelMatchingTab_Matching.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelMatchingTab_Matching.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelMatchingTab_Matching.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelMatchingTab_Matching.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelMatchingTab_Matching.Style.GradientAngle = 90
            Me.TabControlPanelMatchingTab_Matching.TabIndex = 17
            Me.TabControlPanelMatchingTab_Matching.TabItem = Me.TabItemWorksheetDetails_MatchingTab
            '
            'VerticalGridMatching_Settings
            '
            Me.VerticalGridMatching_Settings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.VerticalGridMatching_Settings.Appearance.RowHeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            Me.VerticalGridMatching_Settings.Appearance.RowHeaderPanel.Options.UseFont = True
            Me.VerticalGridMatching_Settings.CustomizationFormBounds = New System.Drawing.Rectangle(1384, 433, 216, 265)
            Me.VerticalGridMatching_Settings.DataSource = Me.InvoiceMatchingSettingBindingSource
            Me.VerticalGridMatching_Settings.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView
            Me.VerticalGridMatching_Settings.Location = New System.Drawing.Point(4, 4)
            Me.VerticalGridMatching_Settings.Name = "VerticalGridMatching_Settings"
            Me.VerticalGridMatching_Settings.OptionsBehavior.ResizeRowHeaders = False
            Me.VerticalGridMatching_Settings.OptionsBehavior.UseEnterAsTab = True
            Me.VerticalGridMatching_Settings.RecordWidth = 88
            Me.VerticalGridMatching_Settings.RowHeaderWidth = 112
            Me.VerticalGridMatching_Settings.Rows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.categorySpotMatchingSettings})
            Me.VerticalGridMatching_Settings.ShowButtonMode = DevExpress.XtraVerticalGrid.ShowButtonModeEnum.ShowAlways
            Me.VerticalGridMatching_Settings.Size = New System.Drawing.Size(519, 402)
            Me.VerticalGridMatching_Settings.TabIndex = 3
            Me.VerticalGridMatching_Settings.TreeButtonStyle = DevExpress.XtraVerticalGrid.TreeButtonStyle.TreeView
            '
            'InvoiceMatchingSettingBindingSource
            '
            Me.InvoiceMatchingSettingBindingSource.DataSource = GetType(AdvantageFramework.DTO.Media.SpotMatchingSetting)
            '
            'categorySpotMatchingSettings
            '
            Me.categorySpotMatchingSettings.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowGrossRate, Me.rowNetwork, Me.rowScheduleDates, Me.rowDayOfWeek, Me.rowTimeOfDay, Me.rowTimeSeparation, Me.rowAdNumber, Me.rowLength, Me.rowAdjacencyBefore, Me.rowAdjacencyAfter, Me.rowBookendMaxSeparation})
            Me.categorySpotMatchingSettings.Name = "categorySpotMatchingSettings"
            Me.categorySpotMatchingSettings.Properties.Caption = "Spot Matching Settings"
            '
            'rowGrossRate
            '
            Me.rowGrossRate.Name = "rowGrossRate"
            Me.rowGrossRate.Properties.Caption = "Rate"
            Me.rowGrossRate.Properties.FieldName = "VerifyRate"
            '
            'rowNetwork
            '
            Me.rowNetwork.Name = "rowNetwork"
            Me.rowNetwork.Properties.Caption = "Network"
            Me.rowNetwork.Properties.FieldName = "VerifyNetwork"
            '
            'rowScheduleDates
            '
            Me.rowScheduleDates.Name = "rowScheduleDates"
            Me.rowScheduleDates.Properties.Caption = "Schedule Dates"
            Me.rowScheduleDates.Properties.FieldName = "VerifySchedule"
            '
            'rowDayOfWeek
            '
            Me.rowDayOfWeek.Name = "rowDayOfWeek"
            Me.rowDayOfWeek.Properties.Caption = "Day of Week"
            Me.rowDayOfWeek.Properties.FieldName = "VerifyDay"
            '
            'rowTimeOfDay
            '
            Me.rowTimeOfDay.Name = "rowTimeOfDay"
            Me.rowTimeOfDay.Properties.Caption = "Time of Day"
            Me.rowTimeOfDay.Properties.FieldName = "VerifyTime"
            '
            'rowTimeSeparation
            '
            Me.rowTimeSeparation.Name = "rowTimeSeparation"
            Me.rowTimeSeparation.Properties.Caption = "Time Separation"
            Me.rowTimeSeparation.Properties.FieldName = "VerifyTimeSep"
            '
            'rowAdNumber
            '
            Me.rowAdNumber.Name = "rowAdNumber"
            Me.rowAdNumber.Properties.Caption = "Ad Number"
            Me.rowAdNumber.Properties.FieldName = "VerifyAdNumber"
            '
            'rowLength
            '
            Me.rowLength.Name = "rowLength"
            Me.rowLength.Properties.Caption = "Length"
            Me.rowLength.Properties.FieldName = "VerifyLength"
            '
            'rowAdjacencyBefore
            '
            Me.rowAdjacencyBefore.Name = "rowAdjacencyBefore"
            Me.rowAdjacencyBefore.Properties.Caption = "Adjacency Before"
            Me.rowAdjacencyBefore.Properties.FieldName = "AdjacencyBefore"
            Me.rowAdjacencyBefore.Properties.ToolTip = "Allow spots airing this many minutes before scheduled air time"
            '
            'rowAdjacencyAfter
            '
            Me.rowAdjacencyAfter.Name = "rowAdjacencyAfter"
            Me.rowAdjacencyAfter.Properties.Caption = "Adjacency After"
            Me.rowAdjacencyAfter.Properties.FieldName = "AdjacencyAfter"
            Me.rowAdjacencyAfter.Properties.ToolTip = "Allow spots airing this many minutes after scheduled air time"
            '
            'rowBookendMaxSeparation
            '
            Me.rowBookendMaxSeparation.Name = "rowBookendMaxSeparation"
            Me.rowBookendMaxSeparation.Properties.Caption = "Bookend Max Separation"
            Me.rowBookendMaxSeparation.Properties.FieldName = "BookendMaxSeparation"
            Me.rowBookendMaxSeparation.Properties.ToolTip = "Length-specific separation in minutes; 0 means ignore; range 0-999"
            '
            'TabItemWorksheetDetails_MatchingTab
            '
            Me.TabItemWorksheetDetails_MatchingTab.AttachedControl = Me.TabControlPanelMatchingTab_Matching
            Me.TabItemWorksheetDetails_MatchingTab.Name = "TabItemWorksheetDetails_MatchingTab"
            Me.TabItemWorksheetDetails_MatchingTab.Text = "Matching"
            '
            'TabControlPanelCommentsTab_Comments
            '
            Me.TabControlPanelCommentsTab_Comments.Controls.Add(Me.LabelComments_MediaPlanComments)
            Me.TabControlPanelCommentsTab_Comments.Controls.Add(Me.TextBoxComments_MediaPlanComments)
            Me.TabControlPanelCommentsTab_Comments.Controls.Add(Me.TextBoxComments_Comment)
            Me.TabControlPanelCommentsTab_Comments.Controls.Add(Me.LabelComments_Comment)
            Me.TabControlPanelCommentsTab_Comments.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelCommentsTab_Comments.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelCommentsTab_Comments.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelCommentsTab_Comments.Name = "TabControlPanelCommentsTab_Comments"
            Me.TabControlPanelCommentsTab_Comments.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelCommentsTab_Comments.Size = New System.Drawing.Size(527, 410)
            Me.TabControlPanelCommentsTab_Comments.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelCommentsTab_Comments.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelCommentsTab_Comments.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelCommentsTab_Comments.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelCommentsTab_Comments.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelCommentsTab_Comments.Style.GradientAngle = 90
            Me.TabControlPanelCommentsTab_Comments.TabIndex = 7
            Me.TabControlPanelCommentsTab_Comments.TabItem = Me.TabItemWorksheetDetails_CommentsTab
            '
            'LabelComments_MediaPlanComments
            '
            Me.LabelComments_MediaPlanComments.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelComments_MediaPlanComments.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelComments_MediaPlanComments.Location = New System.Drawing.Point(4, 204)
            Me.LabelComments_MediaPlanComments.Name = "LabelComments_MediaPlanComments"
            Me.LabelComments_MediaPlanComments.Size = New System.Drawing.Size(118, 20)
            Me.LabelComments_MediaPlanComments.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelComments_MediaPlanComments.TabIndex = 26
            Me.LabelComments_MediaPlanComments.Text = "Media Plan Comments:"
            '
            'TextBoxComments_MediaPlanComments
            '
            Me.TextBoxComments_MediaPlanComments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxComments_MediaPlanComments.Border.Class = "TextBoxBorder"
            Me.TextBoxComments_MediaPlanComments.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxComments_MediaPlanComments.CheckSpellingOnValidate = False
            Me.TextBoxComments_MediaPlanComments.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxComments_MediaPlanComments.Enabled = False
            Me.TextBoxComments_MediaPlanComments.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxComments_MediaPlanComments.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxComments_MediaPlanComments.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxComments_MediaPlanComments.FocusHighlightEnabled = True
            Me.TextBoxComments_MediaPlanComments.Location = New System.Drawing.Point(128, 204)
            Me.TextBoxComments_MediaPlanComments.MaxFileSize = CType(0, Long)
            Me.TextBoxComments_MediaPlanComments.Multiline = True
            Me.TextBoxComments_MediaPlanComments.Name = "TextBoxComments_MediaPlanComments"
            Me.TextBoxComments_MediaPlanComments.SecurityEnabled = True
            Me.TextBoxComments_MediaPlanComments.ShowSpellCheckCompleteMessage = True
            Me.TextBoxComments_MediaPlanComments.Size = New System.Drawing.Size(395, 225)
            Me.TextBoxComments_MediaPlanComments.StartingFolderName = Nothing
            Me.TextBoxComments_MediaPlanComments.TabIndex = 25
            Me.TextBoxComments_MediaPlanComments.TabOnEnter = False
            '
            'TextBoxComments_Comment
            '
            Me.TextBoxComments_Comment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxComments_Comment.Border.Class = "TextBoxBorder"
            Me.TextBoxComments_Comment.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxComments_Comment.CheckSpellingOnValidate = False
            Me.TextBoxComments_Comment.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxComments_Comment.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxComments_Comment.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxComments_Comment.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxComments_Comment.FocusHighlightEnabled = True
            Me.TextBoxComments_Comment.Location = New System.Drawing.Point(128, 5)
            Me.TextBoxComments_Comment.MaxFileSize = CType(0, Long)
            Me.TextBoxComments_Comment.Multiline = True
            Me.TextBoxComments_Comment.Name = "TextBoxComments_Comment"
            Me.TextBoxComments_Comment.SecurityEnabled = True
            Me.TextBoxComments_Comment.ShowSpellCheckCompleteMessage = True
            Me.TextBoxComments_Comment.Size = New System.Drawing.Size(395, 193)
            Me.TextBoxComments_Comment.StartingFolderName = Nothing
            Me.TextBoxComments_Comment.TabIndex = 24
            Me.TextBoxComments_Comment.TabOnEnter = False
            '
            'LabelComments_Comment
            '
            Me.LabelComments_Comment.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelComments_Comment.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelComments_Comment.Location = New System.Drawing.Point(4, 4)
            Me.LabelComments_Comment.Name = "LabelComments_Comment"
            Me.LabelComments_Comment.Size = New System.Drawing.Size(118, 20)
            Me.LabelComments_Comment.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelComments_Comment.TabIndex = 23
            Me.LabelComments_Comment.Text = "Comment:"
            '
            'TabItemWorksheetDetails_CommentsTab
            '
            Me.TabItemWorksheetDetails_CommentsTab.AttachedControl = Me.TabControlPanelCommentsTab_Comments
            Me.TabItemWorksheetDetails_CommentsTab.Name = "TabItemWorksheetDetails_CommentsTab"
            Me.TabItemWorksheetDetails_CommentsTab.Text = "Comments"
            '
            'TabControlPanelDemosTab_Demos
            '
            Me.TabControlPanelDemosTab_Demos.Controls.Add(Me.LabelDemos_Source)
            Me.TabControlPanelDemosTab_Demos.Controls.Add(Me.ComboBoxDemos_Source)
            Me.TabControlPanelDemosTab_Demos.Controls.Add(Me.SearchableComboBoxDemos_PrimaryDemo)
            Me.TabControlPanelDemosTab_Demos.Controls.Add(Me.DataGridViewDemos_SecondaryDemos)
            Me.TabControlPanelDemosTab_Demos.Controls.Add(Me.LabelDemos_PrimaryDemo)
            Me.TabControlPanelDemosTab_Demos.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelDemosTab_Demos.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelDemosTab_Demos.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelDemosTab_Demos.Name = "TabControlPanelDemosTab_Demos"
            Me.TabControlPanelDemosTab_Demos.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelDemosTab_Demos.Size = New System.Drawing.Size(527, 410)
            Me.TabControlPanelDemosTab_Demos.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelDemosTab_Demos.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDemosTab_Demos.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelDemosTab_Demos.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelDemosTab_Demos.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelDemosTab_Demos.Style.GradientAngle = 90
            Me.TabControlPanelDemosTab_Demos.TabIndex = 0
            Me.TabControlPanelDemosTab_Demos.TabItem = Me.TabItemWorksheetDetails_DemosTab
            '
            'LabelDemos_Source
            '
            Me.LabelDemos_Source.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDemos_Source.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDemos_Source.Location = New System.Drawing.Point(4, 4)
            Me.LabelDemos_Source.Name = "LabelDemos_Source"
            Me.LabelDemos_Source.Size = New System.Drawing.Size(100, 20)
            Me.LabelDemos_Source.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDemos_Source.TabIndex = 0
            Me.LabelDemos_Source.Text = "Source:"
            '
            'ComboBoxDemos_Source
            '
            Me.ComboBoxDemos_Source.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxDemos_Source.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxDemos_Source.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
            Me.ComboBoxDemos_Source.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxDemos_Source.AutoFindItemInDataSource = True
            Me.ComboBoxDemos_Source.AutoSelectSingleItemDatasource = False
            Me.ComboBoxDemos_Source.BookmarkingEnabled = False
            Me.ComboBoxDemos_Source.DisableMouseWheel = True
            Me.ComboBoxDemos_Source.DisplayMember = "Display"
            Me.ComboBoxDemos_Source.DisplayName = "Source"
            Me.ComboBoxDemos_Source.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxDemos_Source.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxDemos_Source.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxDemos_Source.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxDemos_Source.FocusHighlightEnabled = True
            Me.ComboBoxDemos_Source.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxDemos_Source.FormattingEnabled = True
            Me.ComboBoxDemos_Source.ItemHeight = 16
            Me.ComboBoxDemos_Source.Location = New System.Drawing.Point(110, 5)
            Me.ComboBoxDemos_Source.Name = "ComboBoxDemos_Source"
            Me.ComboBoxDemos_Source.ReadOnly = False
            Me.ComboBoxDemos_Source.SecurityEnabled = True
            Me.ComboBoxDemos_Source.Size = New System.Drawing.Size(413, 22)
            Me.ComboBoxDemos_Source.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxDemos_Source.TabIndex = 1
            Me.ComboBoxDemos_Source.TabOnEnter = True
            Me.ComboBoxDemos_Source.ValueMember = "Value"
            Me.ComboBoxDemos_Source.WatermarkText = "Select Month"
            '
            'SearchableComboBoxDemos_PrimaryDemo
            '
            Me.SearchableComboBoxDemos_PrimaryDemo.ActiveFilterString = ""
            Me.SearchableComboBoxDemos_PrimaryDemo.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxDemos_PrimaryDemo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxDemos_PrimaryDemo.AutoFillMode = False
            Me.SearchableComboBoxDemos_PrimaryDemo.BookmarkingEnabled = False
            Me.SearchableComboBoxDemos_PrimaryDemo.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.Type.MediaDemographic
            Me.SearchableComboBoxDemos_PrimaryDemo.DataSource = Nothing
            Me.SearchableComboBoxDemos_PrimaryDemo.DisableMouseWheel = True
            Me.SearchableComboBoxDemos_PrimaryDemo.DisplayName = ""
            Me.SearchableComboBoxDemos_PrimaryDemo.EditValue = ""
            Me.SearchableComboBoxDemos_PrimaryDemo.EnterMoveNextControl = True
            Me.SearchableComboBoxDemos_PrimaryDemo.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxDemos_PrimaryDemo.Location = New System.Drawing.Point(110, 33)
            Me.SearchableComboBoxDemos_PrimaryDemo.Name = "SearchableComboBoxDemos_PrimaryDemo"
            Me.SearchableComboBoxDemos_PrimaryDemo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxDemos_PrimaryDemo.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxDemos_PrimaryDemo.Properties.NullText = "Select Demographic"
            Me.SearchableComboBoxDemos_PrimaryDemo.Properties.PopupView = Me.SearchableComboBoxViewDemos_PrimaryDemo
            Me.SearchableComboBoxDemos_PrimaryDemo.Properties.ValueMember = "ID"
            Me.SearchableComboBoxDemos_PrimaryDemo.SecurityEnabled = True
            Me.SearchableComboBoxDemos_PrimaryDemo.SelectedValue = ""
            Me.SearchableComboBoxDemos_PrimaryDemo.Size = New System.Drawing.Size(413, 20)
            Me.SearchableComboBoxDemos_PrimaryDemo.TabIndex = 3
            '
            'SearchableComboBoxViewDemos_PrimaryDemo
            '
            Me.SearchableComboBoxViewDemos_PrimaryDemo.AFActiveFilterString = ""
            Me.SearchableComboBoxViewDemos_PrimaryDemo.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDemos_PrimaryDemo.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDemos_PrimaryDemo.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDemos_PrimaryDemo.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDemos_PrimaryDemo.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDemos_PrimaryDemo.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDemos_PrimaryDemo.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDemos_PrimaryDemo.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDemos_PrimaryDemo.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDemos_PrimaryDemo.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDemos_PrimaryDemo.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDemos_PrimaryDemo.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDemos_PrimaryDemo.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDemos_PrimaryDemo.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDemos_PrimaryDemo.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDemos_PrimaryDemo.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDemos_PrimaryDemo.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDemos_PrimaryDemo.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDemos_PrimaryDemo.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDemos_PrimaryDemo.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDemos_PrimaryDemo.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDemos_PrimaryDemo.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDemos_PrimaryDemo.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDemos_PrimaryDemo.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDemos_PrimaryDemo.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDemos_PrimaryDemo.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDemos_PrimaryDemo.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDemos_PrimaryDemo.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDemos_PrimaryDemo.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDemos_PrimaryDemo.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDemos_PrimaryDemo.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDemos_PrimaryDemo.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDemos_PrimaryDemo.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDemos_PrimaryDemo.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDemos_PrimaryDemo.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDemos_PrimaryDemo.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDemos_PrimaryDemo.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDemos_PrimaryDemo.EnableDisabledRows = False
            Me.SearchableComboBoxViewDemos_PrimaryDemo.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewDemos_PrimaryDemo.ModifyColumnSettingsOnEachDataSource = True
            Me.SearchableComboBoxViewDemos_PrimaryDemo.ModifyGridRowHeight = False
            Me.SearchableComboBoxViewDemos_PrimaryDemo.Name = "SearchableComboBoxViewDemos_PrimaryDemo"
            Me.SearchableComboBoxViewDemos_PrimaryDemo.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewDemos_PrimaryDemo.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewDemos_PrimaryDemo.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewDemos_PrimaryDemo.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewDemos_PrimaryDemo.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewDemos_PrimaryDemo.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewDemos_PrimaryDemo.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewDemos_PrimaryDemo.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewDemos_PrimaryDemo.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewDemos_PrimaryDemo.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewDemos_PrimaryDemo.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewDemos_PrimaryDemo.SkipAddingControlsOnModifyColumn = False
            Me.SearchableComboBoxViewDemos_PrimaryDemo.SkipSettingFontOnModifyColumn = False
            '
            'DataGridViewDemos_SecondaryDemos
            '
            Me.DataGridViewDemos_SecondaryDemos.AllowSelectGroupHeaderRow = True
            Me.DataGridViewDemos_SecondaryDemos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewDemos_SecondaryDemos.AutoUpdateViewCaption = True
            Me.DataGridViewDemos_SecondaryDemos.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewDemos_SecondaryDemos.ItemDescription = "Secondary Demographic(s)"
            Me.DataGridViewDemos_SecondaryDemos.Location = New System.Drawing.Point(4, 63)
            Me.DataGridViewDemos_SecondaryDemos.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewDemos_SecondaryDemos.ModifyGridRowHeight = False
            Me.DataGridViewDemos_SecondaryDemos.MultiSelect = True
            Me.DataGridViewDemos_SecondaryDemos.Name = "DataGridViewDemos_SecondaryDemos"
            Me.DataGridViewDemos_SecondaryDemos.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewDemos_SecondaryDemos.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewDemos_SecondaryDemos.ShowRowSelectionIfHidden = True
            Me.DataGridViewDemos_SecondaryDemos.ShowSelectDeselectAllButtons = False
            Me.DataGridViewDemos_SecondaryDemos.Size = New System.Drawing.Size(519, 342)
            Me.DataGridViewDemos_SecondaryDemos.TabIndex = 4
            Me.DataGridViewDemos_SecondaryDemos.UseEmbeddedNavigator = False
            Me.DataGridViewDemos_SecondaryDemos.ViewCaptionHeight = -1
            '
            'LabelDemos_PrimaryDemo
            '
            Me.LabelDemos_PrimaryDemo.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDemos_PrimaryDemo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDemos_PrimaryDemo.Location = New System.Drawing.Point(4, 32)
            Me.LabelDemos_PrimaryDemo.Name = "LabelDemos_PrimaryDemo"
            Me.LabelDemos_PrimaryDemo.Size = New System.Drawing.Size(100, 20)
            Me.LabelDemos_PrimaryDemo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDemos_PrimaryDemo.TabIndex = 2
            Me.LabelDemos_PrimaryDemo.Text = "Primary Demo:"
            '
            'TabItemWorksheetDetails_DemosTab
            '
            Me.TabItemWorksheetDetails_DemosTab.AttachedControl = Me.TabControlPanelDemosTab_Demos
            Me.TabItemWorksheetDetails_DemosTab.Name = "TabItemWorksheetDetails_DemosTab"
            Me.TabItemWorksheetDetails_DemosTab.Text = "Demos"
            '
            'RibbonBarFilePanel_Demos
            '
            Me.RibbonBarFilePanel_Demos.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBarFilePanel_Demos.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_Demos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFilePanel_Demos.ContainerControlProcessDialogKey = True
            Me.RibbonBarFilePanel_Demos.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarFilePanel_Demos.DragDropSupport = True
            Me.RibbonBarFilePanel_Demos.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemDemos_Delete, Me.ButtonItemDemos_Cancel})
            Me.RibbonBarFilePanel_Demos.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarFilePanel_Demos.Location = New System.Drawing.Point(248, 0)
            Me.RibbonBarFilePanel_Demos.Name = "RibbonBarFilePanel_Demos"
            Me.RibbonBarFilePanel_Demos.Size = New System.Drawing.Size(106, 92)
            Me.RibbonBarFilePanel_Demos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarFilePanel_Demos.TabIndex = 3
            Me.RibbonBarFilePanel_Demos.Text = "Demos"
            '
            '
            '
            Me.RibbonBarFilePanel_Demos.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_Demos.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFilePanel_Demos.Visible = False
            '
            'ButtonItemDemos_Delete
            '
            Me.ButtonItemDemos_Delete.BeginGroup = True
            Me.ButtonItemDemos_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDemos_Delete.Name = "ButtonItemDemos_Delete"
            Me.ButtonItemDemos_Delete.RibbonWordWrap = False
            Me.ButtonItemDemos_Delete.SecurityEnabled = True
            Me.ButtonItemDemos_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemDemos_Delete.Text = "Delete"
            '
            'ButtonItemDemos_Cancel
            '
            Me.ButtonItemDemos_Cancel.BeginGroup = True
            Me.ButtonItemDemos_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDemos_Cancel.Name = "ButtonItemDemos_Cancel"
            Me.ButtonItemDemos_Cancel.RibbonWordWrap = False
            Me.ButtonItemDemos_Cancel.SecurityEnabled = True
            Me.ButtonItemDemos_Cancel.SubItemsExpandWidth = 14
            Me.ButtonItemDemos_Cancel.Text = "Cancel"
            '
            'RibbonBarFilePanel_Matching
            '
            Me.RibbonBarFilePanel_Matching.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBarFilePanel_Matching.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_Matching.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFilePanel_Matching.ContainerControlProcessDialogKey = True
            Me.RibbonBarFilePanel_Matching.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarFilePanel_Matching.DragDropSupport = True
            Me.RibbonBarFilePanel_Matching.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemMatching_Defaults, Me.ButtonItemMatching_SeparationSettings})
            Me.RibbonBarFilePanel_Matching.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarFilePanel_Matching.Location = New System.Drawing.Point(354, 0)
            Me.RibbonBarFilePanel_Matching.Name = "RibbonBarFilePanel_Matching"
            Me.RibbonBarFilePanel_Matching.Size = New System.Drawing.Size(106, 92)
            Me.RibbonBarFilePanel_Matching.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarFilePanel_Matching.TabIndex = 4
            Me.RibbonBarFilePanel_Matching.Text = "Matching"
            '
            '
            '
            Me.RibbonBarFilePanel_Matching.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_Matching.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFilePanel_Matching.Visible = False
            '
            'ButtonItemMatching_Defaults
            '
            Me.ButtonItemMatching_Defaults.BeginGroup = True
            Me.ButtonItemMatching_Defaults.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemMatching_Defaults.Name = "ButtonItemMatching_Defaults"
            Me.ButtonItemMatching_Defaults.RibbonWordWrap = False
            Me.ButtonItemMatching_Defaults.SecurityEnabled = True
            Me.ButtonItemMatching_Defaults.SubItemsExpandWidth = 14
            Me.ButtonItemMatching_Defaults.Text = "Defaults"
            Me.ButtonItemMatching_Defaults.Tooltip = "Restore Defaults"
            '
            'ButtonItemMatching_SeparationSettings
            '
            Me.ButtonItemMatching_SeparationSettings.BeginGroup = True
            Me.ButtonItemMatching_SeparationSettings.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemMatching_SeparationSettings.Name = "ButtonItemMatching_SeparationSettings"
            Me.ButtonItemMatching_SeparationSettings.RibbonWordWrap = False
            Me.ButtonItemMatching_SeparationSettings.SecurityEnabled = True
            Me.ButtonItemMatching_SeparationSettings.SubItemsExpandWidth = 14
            Me.ButtonItemMatching_SeparationSettings.Text = "Separation Settings"
            '
            'CheckBoxInformation_DefaultToMostRecentFourWeekRatings
            '
            Me.CheckBoxInformation_DefaultToMostRecentFourWeekRatings.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxInformation_DefaultToMostRecentFourWeekRatings.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxInformation_DefaultToMostRecentFourWeekRatings.CheckValue = 0
            Me.CheckBoxInformation_DefaultToMostRecentFourWeekRatings.CheckValueChecked = 1
            Me.CheckBoxInformation_DefaultToMostRecentFourWeekRatings.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxInformation_DefaultToMostRecentFourWeekRatings.CheckValueUnchecked = 0
            Me.CheckBoxInformation_DefaultToMostRecentFourWeekRatings.ChildControls = Nothing
            Me.CheckBoxInformation_DefaultToMostRecentFourWeekRatings.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxInformation_DefaultToMostRecentFourWeekRatings.Location = New System.Drawing.Point(255, 318)
            Me.CheckBoxInformation_DefaultToMostRecentFourWeekRatings.Name = "CheckBoxInformation_DefaultToMostRecentFourWeekRatings"
            Me.CheckBoxInformation_DefaultToMostRecentFourWeekRatings.OldestSibling = Nothing
            Me.CheckBoxInformation_DefaultToMostRecentFourWeekRatings.SecurityEnabled = True
            Me.CheckBoxInformation_DefaultToMostRecentFourWeekRatings.SiblingControls = Nothing
            Me.CheckBoxInformation_DefaultToMostRecentFourWeekRatings.Size = New System.Drawing.Size(226, 20)
            Me.CheckBoxInformation_DefaultToMostRecentFourWeekRatings.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxInformation_DefaultToMostRecentFourWeekRatings.TabIndex = 30
            Me.CheckBoxInformation_DefaultToMostRecentFourWeekRatings.TabOnEnter = True
            Me.CheckBoxInformation_DefaultToMostRecentFourWeekRatings.Text = "Default to most recent 4-week ratings"
            '
            'MediaBroadcastWorksheetEditDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(561, 624)
            Me.CloseButtonVisible = False
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaBroadcastWorksheetEditDialog"
            Me.Text = "Media Broadcast Worksheet"
            Me.Controls.SetChildIndex(Me.BarForm_StatusBar, 0)
            Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
            Me.Controls.SetChildIndex(Me.PanelForm_Form, 0)
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Form.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.PerformLayout()
            Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateEditInformation_EndDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateEditInformation_EndDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateEditInformation_StartDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateEditInformation_StartDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.TabControlForm_WorksheetDetails, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlForm_WorksheetDetails.ResumeLayout(False)
            Me.TabControlPanelInformationTab_Information.ResumeLayout(False)
            CType(Me.NumericInputInformation_Length.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelMatchingTab_Matching.ResumeLayout(False)
            CType(Me.VerticalGridMatching_Settings, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.InvoiceMatchingSettingBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelCommentsTab_Comments.ResumeLayout(False)
            Me.TabControlPanelDemosTab_Demos.ResumeLayout(False)
            CType(Me.SearchableComboBoxDemos_PrimaryDemo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewDemos_PrimaryDemo, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents CheckBoxInformation_ArePiggybacksOK As AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox
		Friend WithEvents CheckBoxInformation_DefaultToLatestSharebook As AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox
		Friend WithEvents ComboBoxInformation_DateType As AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox
		Friend WithEvents LabelInformation_DateType As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
		Friend WithEvents ComboBoxInformation_MediaPlan As AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox
		Friend WithEvents LabelInformation_MediaPlan As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
		Friend WithEvents ComboBoxInformation_Campaign As AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox
		Friend WithEvents LabelInformation_Campaign As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
		Friend WithEvents DateEditInformation_EndDate As AdvantageFramework.WinForm.MVC.Presentation.Controls.DateEdit
		Friend WithEvents DateEditInformation_StartDate As AdvantageFramework.WinForm.MVC.Presentation.Controls.DateEdit
		Friend WithEvents CheckBoxInformation_IsInactive As AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox
		Friend WithEvents LabelInformation_EndDate As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
		Friend WithEvents LabelInformation_StartDate As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
		Friend WithEvents ComboBoxInformation_Product As AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox
		Friend WithEvents ComboBoxInformation_Division As AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox
		Friend WithEvents ComboBoxInformation_Client As AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox
		Friend WithEvents LabelInformation_Product As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
		Friend WithEvents LabelInformation_Division As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
		Friend WithEvents LabelInformation_Client As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
		Friend WithEvents ComboBoxInformation_SalesClass As AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox
		Friend WithEvents TextBoxInformation_Name As AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox
		Friend WithEvents LabelInformation_Name As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
		Friend WithEvents LabelInformation_SalesClass As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
		Friend WithEvents RibbonBarFilePanel_Actions As DevComponents.DotNetBar.RibbonBar
		Friend WithEvents ButtonItemActions_Add As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
		Friend WithEvents ButtonItemActions_Update As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
		Friend WithEvents ButtonItemActions_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
		Friend WithEvents CheckBoxInformation_ProrateSecondaryDemosToPrimary As AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox
		Friend WithEvents ComboBoxInformation_Calendar As AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox
		Friend WithEvents LabelInformation_Calendar As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
		Friend WithEvents ComboBoxInformation_MediaType As AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox
		Friend WithEvents LabelInformation_MediaType As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
		Friend WithEvents TabControlForm_WorksheetDetails As AdvantageFramework.WinForm.Presentation.Controls.TabControl
		Friend WithEvents TabControlPanelDemosTab_Demos As DevComponents.DotNetBar.TabControlPanel
		Friend WithEvents LabelDemos_PrimaryDemo As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
		Friend WithEvents TabItemWorksheetDetails_DemosTab As DevComponents.DotNetBar.TabItem
		Friend WithEvents TabControlPanelInformationTab_Information As DevComponents.DotNetBar.TabControlPanel
		Friend WithEvents TabItemWorksheetDetails_InformationTab As DevComponents.DotNetBar.TabItem
		Friend WithEvents DataGridViewDemos_SecondaryDemos As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView
		Friend WithEvents RibbonBarFilePanel_Demos As DevComponents.DotNetBar.RibbonBar
		Friend WithEvents ButtonItemDemos_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
		Friend WithEvents ButtonItemDemos_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
		Friend WithEvents SearchableComboBoxDemos_PrimaryDemo As AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox
		Friend WithEvents SearchableComboBoxViewDemos_PrimaryDemo As AdvantageFramework.WinForm.MVC.Presentation.Controls.GridView
        Friend WithEvents NumericInputInformation_Length As WinForm.MVC.Presentation.Controls.NumericInput
        Friend WithEvents LabelInformation_Length As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents ComboBoxDemos_Source As WinForm.MVC.Presentation.Controls.ComboBox
        Friend WithEvents LabelDemos_Source As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents TabControlPanelCommentsTab_Comments As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents LabelComments_MediaPlanComments As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents TextBoxComments_MediaPlanComments As WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxComments_Comment As WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelComments_Comment As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents TabItemWorksheetDetails_CommentsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents RadioButtonInformation_Net As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonInformation_Gross As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents TabControlPanelMatchingTab_Matching As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemWorksheetDetails_MatchingTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents VerticalGridMatching_Settings As WinForm.MVC.Presentation.Controls.VerticalGrid
        Friend WithEvents rowGrossRate As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents RibbonBarFilePanel_Matching As DevComponents.DotNetBar.RibbonBar
        Friend WithEvents ButtonItemMatching_Defaults As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemMatching_SeparationSettings As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents InvoiceMatchingSettingBindingSource As Windows.Forms.BindingSource
        Friend WithEvents rowNetwork As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowScheduleDates As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowDayOfWeek As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowTimeOfDay As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowTimeSeparation As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowAdNumber As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowLength As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowAdjacencyBefore As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowAdjacencyAfter As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowBookendMaxSeparation As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents categorySpotMatchingSettings As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents LabelInformation_Country As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents ComboBoxInformation_Country As WinForm.MVC.Presentation.Controls.ComboBox
        Friend WithEvents CheckBoxInformation_DefaultToMostRecentFourWeekRatings As WinForm.MVC.Presentation.Controls.CheckBox
    End Class

End Namespace