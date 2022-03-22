Namespace Reporting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class DeferredSalesVsOpenARInitialLoadingDialog
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DeferredSalesVsOpenARInitialLoadingDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.PanelForm_TopSection = New System.Windows.Forms.Panel()
            Me.ComboBoxTopSection_ReportSeries = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelTopSection_Report = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelTopSection_ReportSeries = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxTopSection_Report = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions = New DevComponents.DotNetBar.TabControlPanel()
            Me.LabelForm_StartingPostPeriod = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_EndPostPeriod = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.PanelForm_Bottom = New System.Windows.Forms.Panel()
            Me.TabControlForm_JDA = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabItemJDA_VersionAndOptionsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.CheckBoxFrom_IncludeMarkup = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.PanelForm_TopSection.SuspendLayout()
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.SuspendLayout()
            Me.PanelForm_Bottom.SuspendLayout()
            CType(Me.TabControlForm_JDA, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlForm_JDA.SuspendLayout()
            Me.Panel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(872, 11)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 8
            Me.ButtonForm_OK.Text = "OK"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(953, 11)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 9
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'PanelForm_TopSection
            '
            Me.PanelForm_TopSection.Controls.Add(Me.ComboBoxTopSection_ReportSeries)
            Me.PanelForm_TopSection.Controls.Add(Me.LabelTopSection_Report)
            Me.PanelForm_TopSection.Controls.Add(Me.LabelTopSection_ReportSeries)
            Me.PanelForm_TopSection.Controls.Add(Me.ComboBoxTopSection_Report)
            Me.PanelForm_TopSection.Dock = System.Windows.Forms.DockStyle.Top
            Me.PanelForm_TopSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelForm_TopSection.Name = "PanelForm_TopSection"
            Me.PanelForm_TopSection.Size = New System.Drawing.Size(1041, 68)
            Me.PanelForm_TopSection.TabIndex = 11
            Me.PanelForm_TopSection.Visible = False
            '
            'ComboBoxTopSection_ReportSeries
            '
            Me.ComboBoxTopSection_ReportSeries.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxTopSection_ReportSeries.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxTopSection_ReportSeries.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxTopSection_ReportSeries.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxTopSection_ReportSeries.AutoFindItemInDataSource = False
            Me.ComboBoxTopSection_ReportSeries.AutoSelectSingleItemDatasource = False
            Me.ComboBoxTopSection_ReportSeries.BookmarkingEnabled = False
            Me.ComboBoxTopSection_ReportSeries.ClientCode = ""
            Me.ComboBoxTopSection_ReportSeries.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumObjects
            Me.ComboBoxTopSection_ReportSeries.DisableMouseWheel = False
            Me.ComboBoxTopSection_ReportSeries.DisplayMember = "Description"
            Me.ComboBoxTopSection_ReportSeries.DisplayName = ""
            Me.ComboBoxTopSection_ReportSeries.DivisionCode = ""
            Me.ComboBoxTopSection_ReportSeries.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxTopSection_ReportSeries.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxTopSection_ReportSeries.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxTopSection_ReportSeries.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxTopSection_ReportSeries.FocusHighlightEnabled = True
            Me.ComboBoxTopSection_ReportSeries.FormattingEnabled = True
            Me.ComboBoxTopSection_ReportSeries.ItemHeight = 15
            Me.ComboBoxTopSection_ReportSeries.Location = New System.Drawing.Point(124, 13)
            Me.ComboBoxTopSection_ReportSeries.Name = "ComboBoxTopSection_ReportSeries"
            Me.ComboBoxTopSection_ReportSeries.ReadOnly = False
            Me.ComboBoxTopSection_ReportSeries.SecurityEnabled = True
            Me.ComboBoxTopSection_ReportSeries.Size = New System.Drawing.Size(905, 21)
            Me.ComboBoxTopSection_ReportSeries.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxTopSection_ReportSeries.TabIndex = 3
            Me.ComboBoxTopSection_ReportSeries.TabOnEnter = True
            Me.ComboBoxTopSection_ReportSeries.ValueMember = "Code"
            Me.ComboBoxTopSection_ReportSeries.WatermarkText = "Select"
            '
            'LabelTopSection_Report
            '
            Me.LabelTopSection_Report.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTopSection_Report.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTopSection_Report.Location = New System.Drawing.Point(12, 39)
            Me.LabelTopSection_Report.Name = "LabelTopSection_Report"
            Me.LabelTopSection_Report.Size = New System.Drawing.Size(106, 20)
            Me.LabelTopSection_Report.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTopSection_Report.TabIndex = 2
            Me.LabelTopSection_Report.Text = "Report:"
            '
            'LabelTopSection_ReportSeries
            '
            Me.LabelTopSection_ReportSeries.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTopSection_ReportSeries.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTopSection_ReportSeries.Location = New System.Drawing.Point(12, 13)
            Me.LabelTopSection_ReportSeries.Name = "LabelTopSection_ReportSeries"
            Me.LabelTopSection_ReportSeries.Size = New System.Drawing.Size(106, 20)
            Me.LabelTopSection_ReportSeries.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTopSection_ReportSeries.TabIndex = 0
            Me.LabelTopSection_ReportSeries.Text = "Report Series:"
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
            Me.ComboBoxTopSection_Report.ItemHeight = 15
            Me.ComboBoxTopSection_Report.Location = New System.Drawing.Point(124, 38)
            Me.ComboBoxTopSection_Report.Name = "ComboBoxTopSection_Report"
            Me.ComboBoxTopSection_Report.ReadOnly = False
            Me.ComboBoxTopSection_Report.SecurityEnabled = True
            Me.ComboBoxTopSection_Report.Size = New System.Drawing.Size(905, 21)
            Me.ComboBoxTopSection_Report.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxTopSection_Report.TabIndex = 1
            Me.ComboBoxTopSection_Report.TabOnEnter = True
            Me.ComboBoxTopSection_Report.ValueMember = "Code"
            Me.ComboBoxTopSection_Report.WatermarkText = "Select"
            '
            'TabControlPanelVersionAndOptionsTab_VersionAndOptions
            '
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.CheckBoxFrom_IncludeMarkup)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.LabelForm_StartingPostPeriod)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Controls.Add(Me.ComboBoxForm_EndPostPeriod)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Name = "TabControlPanelVersionAndOptionsTab_VersionAndOptions"
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.Size = New System.Drawing.Size(1017, 540)
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
            'LabelForm_StartingPostPeriod
            '
            Me.LabelForm_StartingPostPeriod.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_StartingPostPeriod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_StartingPostPeriod.Location = New System.Drawing.Point(11, 14)
            Me.LabelForm_StartingPostPeriod.Name = "LabelForm_StartingPostPeriod"
            Me.LabelForm_StartingPostPeriod.Size = New System.Drawing.Size(70, 20)
            Me.LabelForm_StartingPostPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_StartingPostPeriod.TabIndex = 48
            Me.LabelForm_StartingPostPeriod.Text = "End Period:"
            '
            'ComboBoxForm_EndPostPeriod
            '
            Me.ComboBoxForm_EndPostPeriod.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_EndPostPeriod.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_EndPostPeriod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_EndPostPeriod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_EndPostPeriod.AutoFindItemInDataSource = False
            Me.ComboBoxForm_EndPostPeriod.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_EndPostPeriod.BookmarkingEnabled = False
            Me.ComboBoxForm_EndPostPeriod.ClientCode = ""
            Me.ComboBoxForm_EndPostPeriod.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.PostPeriod
            Me.ComboBoxForm_EndPostPeriod.DisableMouseWheel = False
            Me.ComboBoxForm_EndPostPeriod.DisplayMember = "Description"
            Me.ComboBoxForm_EndPostPeriod.DisplayName = ""
            Me.ComboBoxForm_EndPostPeriod.DivisionCode = ""
            Me.ComboBoxForm_EndPostPeriod.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_EndPostPeriod.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_EndPostPeriod.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_EndPostPeriod.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_EndPostPeriod.FocusHighlightEnabled = True
            Me.ComboBoxForm_EndPostPeriod.FormattingEnabled = True
            Me.ComboBoxForm_EndPostPeriod.ItemHeight = 15
            Me.ComboBoxForm_EndPostPeriod.Location = New System.Drawing.Point(87, 14)
            Me.ComboBoxForm_EndPostPeriod.Name = "ComboBoxForm_EndPostPeriod"
            Me.ComboBoxForm_EndPostPeriod.ReadOnly = False
            Me.ComboBoxForm_EndPostPeriod.SecurityEnabled = True
            Me.ComboBoxForm_EndPostPeriod.Size = New System.Drawing.Size(191, 21)
            Me.ComboBoxForm_EndPostPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_EndPostPeriod.TabIndex = 49
            Me.ComboBoxForm_EndPostPeriod.TabOnEnter = True
            Me.ComboBoxForm_EndPostPeriod.ValueMember = "Code"
            Me.ComboBoxForm_EndPostPeriod.WatermarkText = "Select Post Period"
            '
            'PanelForm_Bottom
            '
            Me.PanelForm_Bottom.Controls.Add(Me.ButtonForm_OK)
            Me.PanelForm_Bottom.Controls.Add(Me.ButtonForm_Cancel)
            Me.PanelForm_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.PanelForm_Bottom.Location = New System.Drawing.Point(0, 644)
            Me.PanelForm_Bottom.Name = "PanelForm_Bottom"
            Me.PanelForm_Bottom.Size = New System.Drawing.Size(1041, 43)
            Me.PanelForm_Bottom.TabIndex = 13
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
            Me.TabControlForm_JDA.Location = New System.Drawing.Point(12, 3)
            Me.TabControlForm_JDA.Name = "TabControlForm_JDA"
            Me.TabControlForm_JDA.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlForm_JDA.SelectedTabIndex = 0
            Me.TabControlForm_JDA.Size = New System.Drawing.Size(1017, 567)
            Me.TabControlForm_JDA.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlForm_JDA.TabIndex = 37
            Me.TabControlForm_JDA.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlForm_JDA.Tabs.Add(Me.TabItemJDA_VersionAndOptionsTab)
            '
            'TabItemJDA_VersionAndOptionsTab
            '
            Me.TabItemJDA_VersionAndOptionsTab.AttachedControl = Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions
            Me.TabItemJDA_VersionAndOptionsTab.Name = "TabItemJDA_VersionAndOptionsTab"
            Me.TabItemJDA_VersionAndOptionsTab.Text = "Report Options"
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.TabControlForm_JDA)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Panel1.Location = New System.Drawing.Point(0, 68)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(1041, 576)
            Me.Panel1.TabIndex = 12
            '
            'CheckBoxFrom_IncludeMarkup
            '
            Me.CheckBoxFrom_IncludeMarkup.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxFrom_IncludeMarkup.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxFrom_IncludeMarkup.CheckValue = 0
            Me.CheckBoxFrom_IncludeMarkup.CheckValueChecked = 1
            Me.CheckBoxFrom_IncludeMarkup.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxFrom_IncludeMarkup.CheckValueUnchecked = 0
            Me.CheckBoxFrom_IncludeMarkup.ChildControls = Nothing
            Me.CheckBoxFrom_IncludeMarkup.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxFrom_IncludeMarkup.Location = New System.Drawing.Point(87, 41)
            Me.CheckBoxFrom_IncludeMarkup.Name = "CheckBoxFrom_IncludeMarkup"
            Me.CheckBoxFrom_IncludeMarkup.OldestSibling = Nothing
            Me.CheckBoxFrom_IncludeMarkup.SecurityEnabled = True
            Me.CheckBoxFrom_IncludeMarkup.SiblingControls = Nothing
            Me.CheckBoxFrom_IncludeMarkup.Size = New System.Drawing.Size(107, 20)
            Me.CheckBoxFrom_IncludeMarkup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxFrom_IncludeMarkup.TabIndex = 50
            Me.CheckBoxFrom_IncludeMarkup.TabOnEnter = True
            Me.CheckBoxFrom_IncludeMarkup.Text = "Include Media"
            '
            'DeferredSalesVsOpenARInitialLoadingDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1041, 687)
            Me.Controls.Add(Me.Panel1)
            Me.Controls.Add(Me.PanelForm_Bottom)
            Me.Controls.Add(Me.PanelForm_TopSection)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "DeferredSalesVsOpenARInitialLoadingDialog"
            Me.Text = "Deferred Sales Vs Open AR Initial Criteria"
            Me.PanelForm_TopSection.ResumeLayout(False)
            Me.TabControlPanelVersionAndOptionsTab_VersionAndOptions.ResumeLayout(False)
            Me.PanelForm_Bottom.ResumeLayout(False)
            CType(Me.TabControlForm_JDA, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlForm_JDA.ResumeLayout(False)
            Me.Panel1.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents PanelForm_TopSection As Windows.Forms.Panel
        Friend WithEvents LabelTopSection_ReportSeries As WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxTopSection_Report As WinForm.Presentation.Controls.ComboBox
        Friend WithEvents TabControlPanelVersionAndOptionsTab_VersionAndOptions As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents PanelForm_Bottom As Windows.Forms.Panel
        Friend WithEvents LabelForm_StartingPostPeriod As WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_EndPostPeriod As WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxTopSection_ReportSeries As WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelTopSection_Report As WinForm.Presentation.Controls.Label
        Friend WithEvents TabItemJDA_VersionAndOptionsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlForm_JDA As WinForm.Presentation.Controls.TabControl
        Friend WithEvents Panel1 As Windows.Forms.Panel
        Friend WithEvents CheckBoxFrom_IncludeMarkup As WinForm.Presentation.Controls.CheckBox
    End Class

End Namespace
