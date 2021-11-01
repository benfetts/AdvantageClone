Namespace Reporting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaBroadcastWorksheetOtherInitialLoadingDialog
        Inherits AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseForm

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
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
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaBroadcastWorksheetOtherInitialLoadingDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.PanelForm_TopSection = New System.Windows.Forms.Panel()
            Me.LabelTopSection_Report = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.ComboBoxTopSection_Report = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.PanelForm_BottomSection = New System.Windows.Forms.Panel()
            Me.TabControlForm_JDA = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions = New DevComponents.DotNetBar.TabControlPanel()
            Me.GroupBoxUpdatedRateRequestOptions = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.CheckBoxURR_ShowSecondaryDemo = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.RadioButtonURR_ShowImpressionsCPM = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonURR_ShowRatingsCPP = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.PanelForm_Options = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.LabelReportOptions_Options = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.ReportOptions_CheckBoxShowRatings = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.ReportOptions_CheckBoxShowImpressions = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.ReportOptions_CheckBoxShowCPM = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.ReportOptions_CheckBoxShowCPP = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.ReportOptions_CheckBoxShowTotalCost = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.ReportOptions_CheckBoxShowRate = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.ReportOptions_CheckBoxShowSecondaryDemo = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.DateEditForm_EndDate = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DateEdit()
            Me.DateEditForm_StartDate = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DateEdit()
            Me.DataGridViewForm_Vendors = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.DataGridViewForm_Markets = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.LabelReportOptions_FromDate = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelReportOptions_ToDate = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.TabItemJDA_VersionAndOptionsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.PanelForm_TopSection.SuspendLayout()
            Me.PanelForm_BottomSection.SuspendLayout()
            CType(Me.TabControlForm_JDA, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlForm_JDA.SuspendLayout()
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.SuspendLayout()
            CType(Me.GroupBoxUpdatedRateRequestOptions, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxUpdatedRateRequestOptions.SuspendLayout()
            CType(Me.PanelForm_Options, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Options.SuspendLayout()
            CType(Me.DateEditForm_EndDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateEditForm_EndDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateEditForm_StartDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateEditForm_StartDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(457, 618)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 0
            Me.ButtonForm_OK.Text = "OK"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(538, 618)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 1
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'PanelForm_TopSection
            '
            Me.PanelForm_TopSection.Controls.Add(Me.LabelTopSection_Report)
            Me.PanelForm_TopSection.Controls.Add(Me.ComboBoxTopSection_Report)
            Me.PanelForm_TopSection.Dock = System.Windows.Forms.DockStyle.Top
            Me.PanelForm_TopSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelForm_TopSection.Name = "PanelForm_TopSection"
            Me.PanelForm_TopSection.Size = New System.Drawing.Size(625, 37)
            Me.PanelForm_TopSection.TabIndex = 1
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
            Me.ComboBoxTopSection_Report.Size = New System.Drawing.Size(489, 20)
            Me.ComboBoxTopSection_Report.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxTopSection_Report.TabIndex = 0
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
            Me.PanelForm_BottomSection.Size = New System.Drawing.Size(625, 650)
            Me.PanelForm_BottomSection.TabIndex = 0
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
            Me.TabControlForm_JDA.Location = New System.Drawing.Point(12, 6)
            Me.TabControlForm_JDA.Name = "TabControlForm_JDA"
            Me.TabControlForm_JDA.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlForm_JDA.SelectedTabIndex = 0
            Me.TabControlForm_JDA.Size = New System.Drawing.Size(601, 606)
            Me.TabControlForm_JDA.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlForm_JDA.TabIndex = 39
            Me.TabControlForm_JDA.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlForm_JDA.Tabs.Add(Me.TabItemJDA_VersionAndOptionsTab)
            '
            'TabControlPanelVersionAndOptionsTab_VersionAndOptions
            '
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.GroupBoxUpdatedRateRequestOptions)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.PanelForm_Options)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.ReportOptions_CheckBoxShowSecondaryDemo)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.DateEditForm_EndDate)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.DateEditForm_StartDate)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.DataGridViewForm_Vendors)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.DataGridViewForm_Markets)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.LabelReportOptions_FromDate)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.LabelReportOptions_ToDate)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Name = "TabControlPanelVersionAndOptionsTab_VersionAndOptions"
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Size = New System.Drawing.Size(601, 579)
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
            'GroupBoxUpdatedRateRequestOptions
            '
            Me.GroupBoxUpdatedRateRequestOptions.Appearance.BackColor = System.Drawing.Color.Transparent
            Me.GroupBoxUpdatedRateRequestOptions.Appearance.Options.UseBackColor = True
            Me.GroupBoxUpdatedRateRequestOptions.Controls.Add(Me.CheckBoxURR_ShowSecondaryDemo)
            Me.GroupBoxUpdatedRateRequestOptions.Controls.Add(Me.RadioButtonURR_ShowImpressionsCPM)
            Me.GroupBoxUpdatedRateRequestOptions.Controls.Add(Me.RadioButtonURR_ShowRatingsCPP)
            Me.GroupBoxUpdatedRateRequestOptions.Location = New System.Drawing.Point(4, 496)
            Me.GroupBoxUpdatedRateRequestOptions.Name = "GroupBoxUpdatedRateRequestOptions"
            Me.GroupBoxUpdatedRateRequestOptions.Size = New System.Drawing.Size(593, 79)
            Me.GroupBoxUpdatedRateRequestOptions.TabIndex = 13
            Me.GroupBoxUpdatedRateRequestOptions.Text = "Options"
            Me.GroupBoxUpdatedRateRequestOptions.Visible = False
            '
            'CheckBoxURR_ShowSecondaryDemo
            '
            Me.CheckBoxURR_ShowSecondaryDemo.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.CheckBoxURR_ShowSecondaryDemo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxURR_ShowSecondaryDemo.CausesValidation = False
            Me.CheckBoxURR_ShowSecondaryDemo.CheckValue = 0
            Me.CheckBoxURR_ShowSecondaryDemo.CheckValueChecked = 1
            Me.CheckBoxURR_ShowSecondaryDemo.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxURR_ShowSecondaryDemo.CheckValueUnchecked = 0
            Me.CheckBoxURR_ShowSecondaryDemo.ChildControls = CType(resources.GetObject("CheckBoxURR_ShowSecondaryDemo.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxURR_ShowSecondaryDemo.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxURR_ShowSecondaryDemo.Location = New System.Drawing.Point(334, 25)
            Me.CheckBoxURR_ShowSecondaryDemo.Margin = New System.Windows.Forms.Padding(2)
            Me.CheckBoxURR_ShowSecondaryDemo.Name = "CheckBoxURR_ShowSecondaryDemo"
            Me.CheckBoxURR_ShowSecondaryDemo.OldestSibling = Nothing
            Me.CheckBoxURR_ShowSecondaryDemo.SecurityEnabled = True
            Me.CheckBoxURR_ShowSecondaryDemo.SiblingControls = CType(resources.GetObject("CheckBoxURR_ShowSecondaryDemo.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxURR_ShowSecondaryDemo.Size = New System.Drawing.Size(143, 19)
            Me.CheckBoxURR_ShowSecondaryDemo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxURR_ShowSecondaryDemo.TabIndex = 7
            Me.CheckBoxURR_ShowSecondaryDemo.TabOnEnter = True
            Me.CheckBoxURR_ShowSecondaryDemo.Text = "Show Secondary Demo"
            '
            'RadioButtonURR_ShowImpressionsCPM
            '
            Me.RadioButtonURR_ShowImpressionsCPM.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonURR_ShowImpressionsCPM.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonURR_ShowImpressionsCPM.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonURR_ShowImpressionsCPM.Location = New System.Drawing.Point(170, 24)
            Me.RadioButtonURR_ShowImpressionsCPM.Name = "RadioButtonURR_ShowImpressionsCPM"
            Me.RadioButtonURR_ShowImpressionsCPM.SecurityEnabled = True
            Me.RadioButtonURR_ShowImpressionsCPM.Size = New System.Drawing.Size(159, 20)
            Me.RadioButtonURR_ShowImpressionsCPM.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonURR_ShowImpressionsCPM.TabIndex = 2
            Me.RadioButtonURR_ShowImpressionsCPM.TabOnEnter = True
            Me.RadioButtonURR_ShowImpressionsCPM.TabStop = False
            Me.RadioButtonURR_ShowImpressionsCPM.Tag = "1"
            Me.RadioButtonURR_ShowImpressionsCPM.Text = "Show Impressions / CPM"
            '
            'RadioButtonURR_ShowRatingsCPP
            '
            Me.RadioButtonURR_ShowRatingsCPP.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonURR_ShowRatingsCPP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonURR_ShowRatingsCPP.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonURR_ShowRatingsCPP.Checked = True
            Me.RadioButtonURR_ShowRatingsCPP.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonURR_ShowRatingsCPP.CheckValue = "Y"
            Me.RadioButtonURR_ShowRatingsCPP.Location = New System.Drawing.Point(5, 24)
            Me.RadioButtonURR_ShowRatingsCPP.Name = "RadioButtonURR_ShowRatingsCPP"
            Me.RadioButtonURR_ShowRatingsCPP.SecurityEnabled = True
            Me.RadioButtonURR_ShowRatingsCPP.Size = New System.Drawing.Size(159, 20)
            Me.RadioButtonURR_ShowRatingsCPP.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonURR_ShowRatingsCPP.TabIndex = 1
            Me.RadioButtonURR_ShowRatingsCPP.TabOnEnter = True
            Me.RadioButtonURR_ShowRatingsCPP.Tag = "1"
            Me.RadioButtonURR_ShowRatingsCPP.Text = "Show Ratings / CPP"
            '
            'PanelForm_Options
            '
            Me.PanelForm_Options.Appearance.BackColor = System.Drawing.Color.Transparent
            Me.PanelForm_Options.Appearance.Options.UseBackColor = True
            Me.PanelForm_Options.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelForm_Options.Controls.Add(Me.LabelReportOptions_Options)
            Me.PanelForm_Options.Controls.Add(Me.ReportOptions_CheckBoxShowRatings)
            Me.PanelForm_Options.Controls.Add(Me.ReportOptions_CheckBoxShowImpressions)
            Me.PanelForm_Options.Controls.Add(Me.ReportOptions_CheckBoxShowCPM)
            Me.PanelForm_Options.Controls.Add(Me.ReportOptions_CheckBoxShowCPP)
            Me.PanelForm_Options.Controls.Add(Me.ReportOptions_CheckBoxShowTotalCost)
            Me.PanelForm_Options.Controls.Add(Me.ReportOptions_CheckBoxShowRate)
            Me.PanelForm_Options.Location = New System.Drawing.Point(0, 519)
            Me.PanelForm_Options.LookAndFeel.SkinName = "Office 2013"
            Me.PanelForm_Options.LookAndFeel.UseDefaultLookAndFeel = False
            Me.PanelForm_Options.Name = "PanelForm_Options"
            Me.PanelForm_Options.Size = New System.Drawing.Size(601, 57)
            Me.PanelForm_Options.TabIndex = 14
            '
            'LabelReportOptions_Options
            '
            Me.LabelReportOptions_Options.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.LabelReportOptions_Options.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelReportOptions_Options.Location = New System.Drawing.Point(4, 5)
            Me.LabelReportOptions_Options.Margin = New System.Windows.Forms.Padding(2)
            Me.LabelReportOptions_Options.Name = "LabelReportOptions_Options"
            Me.LabelReportOptions_Options.Size = New System.Drawing.Size(56, 19)
            Me.LabelReportOptions_Options.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelReportOptions_Options.TabIndex = 6
            Me.LabelReportOptions_Options.Text = "Options:"
            '
            'ReportOptions_CheckBoxShowRatings
            '
            Me.ReportOptions_CheckBoxShowRatings.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.ReportOptions_CheckBoxShowRatings.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ReportOptions_CheckBoxShowRatings.CausesValidation = False
            Me.ReportOptions_CheckBoxShowRatings.CheckValue = 0
            Me.ReportOptions_CheckBoxShowRatings.CheckValueChecked = 1
            Me.ReportOptions_CheckBoxShowRatings.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.ReportOptions_CheckBoxShowRatings.CheckValueUnchecked = 0
            Me.ReportOptions_CheckBoxShowRatings.ChildControls = CType(resources.GetObject("ReportOptions_CheckBoxShowRatings.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.ReportOptions_CheckBoxShowRatings.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.ReportOptions_CheckBoxShowRatings.Location = New System.Drawing.Point(64, 5)
            Me.ReportOptions_CheckBoxShowRatings.Margin = New System.Windows.Forms.Padding(2)
            Me.ReportOptions_CheckBoxShowRatings.Name = "ReportOptions_CheckBoxShowRatings"
            Me.ReportOptions_CheckBoxShowRatings.OldestSibling = Nothing
            Me.ReportOptions_CheckBoxShowRatings.SecurityEnabled = True
            Me.ReportOptions_CheckBoxShowRatings.SiblingControls = CType(resources.GetObject("ReportOptions_CheckBoxShowRatings.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.ReportOptions_CheckBoxShowRatings.Size = New System.Drawing.Size(132, 19)
            Me.ReportOptions_CheckBoxShowRatings.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ReportOptions_CheckBoxShowRatings.TabIndex = 7
            Me.ReportOptions_CheckBoxShowRatings.TabOnEnter = True
            Me.ReportOptions_CheckBoxShowRatings.Text = "Show Ratings"
            '
            'ReportOptions_CheckBoxShowImpressions
            '
            Me.ReportOptions_CheckBoxShowImpressions.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.ReportOptions_CheckBoxShowImpressions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ReportOptions_CheckBoxShowImpressions.CausesValidation = False
            Me.ReportOptions_CheckBoxShowImpressions.CheckValue = 0
            Me.ReportOptions_CheckBoxShowImpressions.CheckValueChecked = 1
            Me.ReportOptions_CheckBoxShowImpressions.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.ReportOptions_CheckBoxShowImpressions.CheckValueUnchecked = 0
            Me.ReportOptions_CheckBoxShowImpressions.ChildControls = CType(resources.GetObject("ReportOptions_CheckBoxShowImpressions.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.ReportOptions_CheckBoxShowImpressions.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.ReportOptions_CheckBoxShowImpressions.Location = New System.Drawing.Point(200, 5)
            Me.ReportOptions_CheckBoxShowImpressions.Margin = New System.Windows.Forms.Padding(2)
            Me.ReportOptions_CheckBoxShowImpressions.Name = "ReportOptions_CheckBoxShowImpressions"
            Me.ReportOptions_CheckBoxShowImpressions.OldestSibling = Nothing
            Me.ReportOptions_CheckBoxShowImpressions.SecurityEnabled = True
            Me.ReportOptions_CheckBoxShowImpressions.SiblingControls = CType(resources.GetObject("ReportOptions_CheckBoxShowImpressions.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.ReportOptions_CheckBoxShowImpressions.Size = New System.Drawing.Size(132, 19)
            Me.ReportOptions_CheckBoxShowImpressions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ReportOptions_CheckBoxShowImpressions.TabIndex = 9
            Me.ReportOptions_CheckBoxShowImpressions.TabOnEnter = True
            Me.ReportOptions_CheckBoxShowImpressions.Text = "Show Impressions"
            '
            'ReportOptions_CheckBoxShowCPM
            '
            Me.ReportOptions_CheckBoxShowCPM.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.ReportOptions_CheckBoxShowCPM.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ReportOptions_CheckBoxShowCPM.CausesValidation = False
            Me.ReportOptions_CheckBoxShowCPM.CheckValue = 0
            Me.ReportOptions_CheckBoxShowCPM.CheckValueChecked = 1
            Me.ReportOptions_CheckBoxShowCPM.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.ReportOptions_CheckBoxShowCPM.CheckValueUnchecked = 0
            Me.ReportOptions_CheckBoxShowCPM.ChildControls = CType(resources.GetObject("ReportOptions_CheckBoxShowCPM.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.ReportOptions_CheckBoxShowCPM.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.ReportOptions_CheckBoxShowCPM.Location = New System.Drawing.Point(200, 28)
            Me.ReportOptions_CheckBoxShowCPM.Margin = New System.Windows.Forms.Padding(2)
            Me.ReportOptions_CheckBoxShowCPM.Name = "ReportOptions_CheckBoxShowCPM"
            Me.ReportOptions_CheckBoxShowCPM.OldestSibling = Nothing
            Me.ReportOptions_CheckBoxShowCPM.SecurityEnabled = True
            Me.ReportOptions_CheckBoxShowCPM.SiblingControls = CType(resources.GetObject("ReportOptions_CheckBoxShowCPM.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.ReportOptions_CheckBoxShowCPM.Size = New System.Drawing.Size(132, 19)
            Me.ReportOptions_CheckBoxShowCPM.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ReportOptions_CheckBoxShowCPM.TabIndex = 10
            Me.ReportOptions_CheckBoxShowCPM.TabOnEnter = True
            Me.ReportOptions_CheckBoxShowCPM.Text = "Show CPM"
            '
            'ReportOptions_CheckBoxShowCPP
            '
            Me.ReportOptions_CheckBoxShowCPP.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.ReportOptions_CheckBoxShowCPP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ReportOptions_CheckBoxShowCPP.CausesValidation = False
            Me.ReportOptions_CheckBoxShowCPP.CheckValue = 0
            Me.ReportOptions_CheckBoxShowCPP.CheckValueChecked = 1
            Me.ReportOptions_CheckBoxShowCPP.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.ReportOptions_CheckBoxShowCPP.CheckValueUnchecked = 0
            Me.ReportOptions_CheckBoxShowCPP.ChildControls = CType(resources.GetObject("ReportOptions_CheckBoxShowCPP.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.ReportOptions_CheckBoxShowCPP.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.ReportOptions_CheckBoxShowCPP.Location = New System.Drawing.Point(64, 28)
            Me.ReportOptions_CheckBoxShowCPP.Margin = New System.Windows.Forms.Padding(2)
            Me.ReportOptions_CheckBoxShowCPP.Name = "ReportOptions_CheckBoxShowCPP"
            Me.ReportOptions_CheckBoxShowCPP.OldestSibling = Nothing
            Me.ReportOptions_CheckBoxShowCPP.SecurityEnabled = True
            Me.ReportOptions_CheckBoxShowCPP.SiblingControls = CType(resources.GetObject("ReportOptions_CheckBoxShowCPP.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.ReportOptions_CheckBoxShowCPP.Size = New System.Drawing.Size(132, 19)
            Me.ReportOptions_CheckBoxShowCPP.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ReportOptions_CheckBoxShowCPP.TabIndex = 8
            Me.ReportOptions_CheckBoxShowCPP.TabOnEnter = True
            Me.ReportOptions_CheckBoxShowCPP.Text = "Show CPP"
            '
            'ReportOptions_CheckBoxShowTotalCost
            '
            Me.ReportOptions_CheckBoxShowTotalCost.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.ReportOptions_CheckBoxShowTotalCost.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ReportOptions_CheckBoxShowTotalCost.CausesValidation = False
            Me.ReportOptions_CheckBoxShowTotalCost.CheckValue = 0
            Me.ReportOptions_CheckBoxShowTotalCost.CheckValueChecked = 1
            Me.ReportOptions_CheckBoxShowTotalCost.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.ReportOptions_CheckBoxShowTotalCost.CheckValueUnchecked = 0
            Me.ReportOptions_CheckBoxShowTotalCost.ChildControls = CType(resources.GetObject("ReportOptions_CheckBoxShowTotalCost.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.ReportOptions_CheckBoxShowTotalCost.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.ReportOptions_CheckBoxShowTotalCost.Location = New System.Drawing.Point(336, 28)
            Me.ReportOptions_CheckBoxShowTotalCost.Margin = New System.Windows.Forms.Padding(2)
            Me.ReportOptions_CheckBoxShowTotalCost.Name = "ReportOptions_CheckBoxShowTotalCost"
            Me.ReportOptions_CheckBoxShowTotalCost.OldestSibling = Nothing
            Me.ReportOptions_CheckBoxShowTotalCost.SecurityEnabled = True
            Me.ReportOptions_CheckBoxShowTotalCost.SiblingControls = CType(resources.GetObject("ReportOptions_CheckBoxShowTotalCost.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.ReportOptions_CheckBoxShowTotalCost.Size = New System.Drawing.Size(143, 19)
            Me.ReportOptions_CheckBoxShowTotalCost.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ReportOptions_CheckBoxShowTotalCost.TabIndex = 12
            Me.ReportOptions_CheckBoxShowTotalCost.TabOnEnter = True
            Me.ReportOptions_CheckBoxShowTotalCost.Text = "Show Total Cost"
            '
            'ReportOptions_CheckBoxShowRate
            '
            Me.ReportOptions_CheckBoxShowRate.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.ReportOptions_CheckBoxShowRate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ReportOptions_CheckBoxShowRate.CausesValidation = False
            Me.ReportOptions_CheckBoxShowRate.CheckValue = 0
            Me.ReportOptions_CheckBoxShowRate.CheckValueChecked = 1
            Me.ReportOptions_CheckBoxShowRate.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.ReportOptions_CheckBoxShowRate.CheckValueUnchecked = 0
            Me.ReportOptions_CheckBoxShowRate.ChildControls = CType(resources.GetObject("ReportOptions_CheckBoxShowRate.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.ReportOptions_CheckBoxShowRate.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.ReportOptions_CheckBoxShowRate.Location = New System.Drawing.Point(336, 5)
            Me.ReportOptions_CheckBoxShowRate.Margin = New System.Windows.Forms.Padding(2)
            Me.ReportOptions_CheckBoxShowRate.Name = "ReportOptions_CheckBoxShowRate"
            Me.ReportOptions_CheckBoxShowRate.OldestSibling = Nothing
            Me.ReportOptions_CheckBoxShowRate.SecurityEnabled = True
            Me.ReportOptions_CheckBoxShowRate.SiblingControls = CType(resources.GetObject("ReportOptions_CheckBoxShowRate.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.ReportOptions_CheckBoxShowRate.Size = New System.Drawing.Size(143, 19)
            Me.ReportOptions_CheckBoxShowRate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ReportOptions_CheckBoxShowRate.TabIndex = 11
            Me.ReportOptions_CheckBoxShowRate.TabOnEnter = True
            Me.ReportOptions_CheckBoxShowRate.Text = "Show Rates"
            '
            'ReportOptions_CheckBoxShowSecondaryDemo
            '
            Me.ReportOptions_CheckBoxShowSecondaryDemo.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.ReportOptions_CheckBoxShowSecondaryDemo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ReportOptions_CheckBoxShowSecondaryDemo.CausesValidation = False
            Me.ReportOptions_CheckBoxShowSecondaryDemo.CheckValue = 0
            Me.ReportOptions_CheckBoxShowSecondaryDemo.CheckValueChecked = 1
            Me.ReportOptions_CheckBoxShowSecondaryDemo.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.ReportOptions_CheckBoxShowSecondaryDemo.CheckValueUnchecked = 0
            Me.ReportOptions_CheckBoxShowSecondaryDemo.ChildControls = CType(resources.GetObject("ReportOptions_CheckBoxShowSecondaryDemo.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.ReportOptions_CheckBoxShowSecondaryDemo.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.ReportOptions_CheckBoxShowSecondaryDemo.Location = New System.Drawing.Point(336, 495)
            Me.ReportOptions_CheckBoxShowSecondaryDemo.Margin = New System.Windows.Forms.Padding(2)
            Me.ReportOptions_CheckBoxShowSecondaryDemo.Name = "ReportOptions_CheckBoxShowSecondaryDemo"
            Me.ReportOptions_CheckBoxShowSecondaryDemo.OldestSibling = Nothing
            Me.ReportOptions_CheckBoxShowSecondaryDemo.SecurityEnabled = True
            Me.ReportOptions_CheckBoxShowSecondaryDemo.SiblingControls = CType(resources.GetObject("ReportOptions_CheckBoxShowSecondaryDemo.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.ReportOptions_CheckBoxShowSecondaryDemo.Size = New System.Drawing.Size(143, 19)
            Me.ReportOptions_CheckBoxShowSecondaryDemo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ReportOptions_CheckBoxShowSecondaryDemo.TabIndex = 6
            Me.ReportOptions_CheckBoxShowSecondaryDemo.TabOnEnter = True
            Me.ReportOptions_CheckBoxShowSecondaryDemo.Text = "Show Secondary Demo"
            '
            'DateEditForm_EndDate
            '
            Me.DateEditForm_EndDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DateEditForm_EndDate.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.DateEdit.Type.[Default]
            Me.DateEditForm_EndDate.DisplayName = ""
            Me.DateEditForm_EndDate.EditValue = Nothing
            Me.DateEditForm_EndDate.Location = New System.Drawing.Point(230, 496)
            Me.DateEditForm_EndDate.Name = "DateEditForm_EndDate"
            Me.DateEditForm_EndDate.Properties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.[False]
            Me.DateEditForm_EndDate.Properties.AllowMouseWheel = False
            Me.DateEditForm_EndDate.Properties.Appearance.BackColor = System.Drawing.Color.White
            Me.DateEditForm_EndDate.Properties.Appearance.Options.UseBackColor = True
            Me.DateEditForm_EndDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.DateEditForm_EndDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.DateEditForm_EndDate.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista
            Me.DateEditForm_EndDate.Properties.DisplayFormat.FormatString = "MM/dd/yyyy"
            Me.DateEditForm_EndDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            Me.DateEditForm_EndDate.Properties.EditFormat.FormatString = "MM/dd/yyyy"
            Me.DateEditForm_EndDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            Me.DateEditForm_EndDate.Properties.Mask.EditMask = ""
            Me.DateEditForm_EndDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
            Me.DateEditForm_EndDate.Properties.MaxValue = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateEditForm_EndDate.Properties.MinValue = New Date(1900, 1, 1, 0, 0, 0, 0)
            Me.DateEditForm_EndDate.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[True]
            Me.DateEditForm_EndDate.SecurityEnabled = True
            Me.DateEditForm_EndDate.Size = New System.Drawing.Size(95, 20)
            Me.DateEditForm_EndDate.TabIndex = 5
            Me.DateEditForm_EndDate.TabOnEnter = True
            Me.DateEditForm_EndDate.Tag = "9/2/2015"
            '
            'DateEditForm_StartDate
            '
            Me.DateEditForm_StartDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DateEditForm_StartDate.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.DateEdit.Type.[Default]
            Me.DateEditForm_StartDate.DisplayName = ""
            Me.DateEditForm_StartDate.EditValue = Nothing
            Me.DateEditForm_StartDate.Location = New System.Drawing.Point(73, 496)
            Me.DateEditForm_StartDate.Name = "DateEditForm_StartDate"
            Me.DateEditForm_StartDate.Properties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.[False]
            Me.DateEditForm_StartDate.Properties.AllowMouseWheel = False
            Me.DateEditForm_StartDate.Properties.Appearance.BackColor = System.Drawing.Color.White
            Me.DateEditForm_StartDate.Properties.Appearance.Options.UseBackColor = True
            Me.DateEditForm_StartDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.DateEditForm_StartDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.DateEditForm_StartDate.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista
            Me.DateEditForm_StartDate.Properties.DisplayFormat.FormatString = "MM/dd/yyyy"
            Me.DateEditForm_StartDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            Me.DateEditForm_StartDate.Properties.EditFormat.FormatString = "MM/dd/yyyy"
            Me.DateEditForm_StartDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            Me.DateEditForm_StartDate.Properties.Mask.EditMask = ""
            Me.DateEditForm_StartDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
            Me.DateEditForm_StartDate.Properties.MaxValue = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateEditForm_StartDate.Properties.MinValue = New Date(1900, 1, 1, 0, 0, 0, 0)
            Me.DateEditForm_StartDate.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[True]
            Me.DateEditForm_StartDate.SecurityEnabled = True
            Me.DateEditForm_StartDate.Size = New System.Drawing.Size(95, 20)
            Me.DateEditForm_StartDate.TabIndex = 3
            Me.DateEditForm_StartDate.TabOnEnter = True
            Me.DateEditForm_StartDate.Tag = "9/2/2015"
            '
            'DataGridViewForm_Vendors
            '
            Me.DataGridViewForm_Vendors.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_Vendors.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_Vendors.AutoUpdateViewCaption = True
            Me.DataGridViewForm_Vendors.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_Vendors.ItemDescription = "Vendor(s)"
            Me.DataGridViewForm_Vendors.Location = New System.Drawing.Point(4, 169)
            Me.DataGridViewForm_Vendors.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewForm_Vendors.ModifyGridRowHeight = False
            Me.DataGridViewForm_Vendors.MultiSelect = True
            Me.DataGridViewForm_Vendors.Name = "DataGridViewForm_Vendors"
            Me.DataGridViewForm_Vendors.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_Vendors.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewForm_Vendors.ShowRowSelectionIfHidden = True
            Me.DataGridViewForm_Vendors.ShowSelectDeselectAllButtons = True
            Me.DataGridViewForm_Vendors.Size = New System.Drawing.Size(593, 321)
            Me.DataGridViewForm_Vendors.TabIndex = 1
            Me.DataGridViewForm_Vendors.UseEmbeddedNavigator = False
            Me.DataGridViewForm_Vendors.ViewCaptionHeight = -1
            '
            'DataGridViewForm_Markets
            '
            Me.DataGridViewForm_Markets.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_Markets.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_Markets.AutoUpdateViewCaption = True
            Me.DataGridViewForm_Markets.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_Markets.ItemDescription = "Market(s)"
            Me.DataGridViewForm_Markets.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewForm_Markets.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewForm_Markets.ModifyGridRowHeight = False
            Me.DataGridViewForm_Markets.MultiSelect = True
            Me.DataGridViewForm_Markets.Name = "DataGridViewForm_Markets"
            Me.DataGridViewForm_Markets.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_Markets.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewForm_Markets.ShowRowSelectionIfHidden = True
            Me.DataGridViewForm_Markets.ShowSelectDeselectAllButtons = True
            Me.DataGridViewForm_Markets.Size = New System.Drawing.Size(593, 159)
            Me.DataGridViewForm_Markets.TabIndex = 0
            Me.DataGridViewForm_Markets.UseEmbeddedNavigator = False
            Me.DataGridViewForm_Markets.ViewCaptionHeight = -1
            '
            'LabelReportOptions_FromDate
            '
            Me.LabelReportOptions_FromDate.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.LabelReportOptions_FromDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelReportOptions_FromDate.Location = New System.Drawing.Point(4, 495)
            Me.LabelReportOptions_FromDate.Margin = New System.Windows.Forms.Padding(2)
            Me.LabelReportOptions_FromDate.Name = "LabelReportOptions_FromDate"
            Me.LabelReportOptions_FromDate.Size = New System.Drawing.Size(64, 19)
            Me.LabelReportOptions_FromDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelReportOptions_FromDate.TabIndex = 2
            Me.LabelReportOptions_FromDate.Text = "From Date:"
            '
            'LabelReportOptions_ToDate
            '
            Me.LabelReportOptions_ToDate.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.LabelReportOptions_ToDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelReportOptions_ToDate.Location = New System.Drawing.Point(173, 495)
            Me.LabelReportOptions_ToDate.Margin = New System.Windows.Forms.Padding(2)
            Me.LabelReportOptions_ToDate.Name = "LabelReportOptions_ToDate"
            Me.LabelReportOptions_ToDate.Size = New System.Drawing.Size(52, 19)
            Me.LabelReportOptions_ToDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelReportOptions_ToDate.TabIndex = 4
            Me.LabelReportOptions_ToDate.Text = "To Date:"
            '
            'TabItemJDA_VersionAndOptionsTab
            '
            Me.TabItemJDA_VersionAndOptionsTab.AttachedControl = Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions
            Me.TabItemJDA_VersionAndOptionsTab.Name = "TabItemJDA_VersionAndOptionsTab"
            Me.TabItemJDA_VersionAndOptionsTab.Text = "Report Options"
            '
            'MediaBroadcastWorksheetOtherInitialLoadingDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(625, 687)
            Me.Controls.Add(Me.PanelForm_BottomSection)
            Me.Controls.Add(Me.PanelForm_TopSection)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaBroadcastWorksheetOtherInitialLoadingDialog"
            Me.Text = "Other Media Broadcast Worksheet Reports"
            Me.PanelForm_TopSection.ResumeLayout(False)
            Me.PanelForm_BottomSection.ResumeLayout(False)
            CType(Me.TabControlForm_JDA, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlForm_JDA.ResumeLayout(False)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.ResumeLayout(False)
            CType(Me.GroupBoxUpdatedRateRequestOptions, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxUpdatedRateRequestOptions.ResumeLayout(False)
            CType(Me.PanelForm_Options, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Options.ResumeLayout(False)
            CType(Me.DateEditForm_EndDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateEditForm_EndDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateEditForm_StartDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateEditForm_StartDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents PanelForm_TopSection As System.Windows.Forms.Panel
        Friend WithEvents LabelTopSection_Report As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents ComboBoxTopSection_Report As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents PanelForm_BottomSection As System.Windows.Forms.Panel
        Friend WithEvents TabControlForm_JDA As WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelVersionAndOptionsTab_VersionAndOptions As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemJDA_VersionAndOptionsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents ReportOptions_CheckBoxShowCPM As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents ReportOptions_CheckBoxShowImpressions As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents ReportOptions_CheckBoxShowRatings As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents LabelReportOptions_Options As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelReportOptions_FromDate As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelReportOptions_ToDate As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents DataGridViewForm_Vendors As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents DataGridViewForm_Markets As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents ReportOptions_CheckBoxShowCPP As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents ReportOptions_CheckBoxShowTotalCost As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents ReportOptions_CheckBoxShowRate As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents DateEditForm_StartDate As WinForm.MVC.Presentation.Controls.DateEdit
        Friend WithEvents DateEditForm_EndDate As WinForm.MVC.Presentation.Controls.DateEdit
        Friend WithEvents ReportOptions_CheckBoxShowSecondaryDemo As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents GroupBoxUpdatedRateRequestOptions As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents RadioButtonURR_ShowImpressionsCPM As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonURR_ShowRatingsCPP As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents CheckBoxURR_ShowSecondaryDemo As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents PanelForm_Options As WinForm.Presentation.Controls.Panel
    End Class

End Namespace
