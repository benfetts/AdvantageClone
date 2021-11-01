Namespace Reporting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaPlanInitialLoadingDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaPlanInitialLoadingDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.TabControlForm_MCS = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.OptionsControlSelect = New DevComponents.DotNetBar.TabControlPanel()
            Me.LabelOptions_MonthlyBroadcast = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.PanelOptions_Display = New System.Windows.Forms.Panel()
            Me.RadioButtonStandardDates = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonBroadcastDates2 = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.CheckBoxBroadcastDates = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.TabItemJDA_OptionsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanel1 = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewSelectOffices_Offices = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RadioButtonSelectOffices_ChooseOffices = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelectOffices_AllOffices = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.TabItemJDA_SelectOfficesTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanel2 = New DevComponents.DotNetBar.TabControlPanel()
            Me.CDPChooserControlSelectClients_SelectClients = New AdvantageFramework.WinForm.Presentation.Controls.CDPChooserControl()
            Me.TabItemMCS_SelectClientsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            CType(Me.TabControlForm_MCS, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlForm_MCS.SuspendLayout()
            Me.OptionsControlSelect.SuspendLayout()
            Me.PanelOptions_Display.SuspendLayout()
            Me.TabControlPanel1.SuspendLayout()
            Me.TabControlPanel2.SuspendLayout()
            Me.SuspendLayout()
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(541, 324)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 7
            Me.ButtonForm_OK.Text = "OK"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(622, 324)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 8
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'TabControlForm_MCS
            '
            Me.TabControlForm_MCS.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlForm_MCS.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer))
            Me.TabControlForm_MCS.CanReorderTabs = False
            Me.TabControlForm_MCS.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlForm_MCS.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlForm_MCS.Controls.Add(Me.OptionsControlSelect)
            Me.TabControlForm_MCS.Controls.Add(Me.TabControlPanel1)
            Me.TabControlForm_MCS.Controls.Add(Me.TabControlPanel2)
            Me.TabControlForm_MCS.Location = New System.Drawing.Point(12, 12)
            Me.TabControlForm_MCS.Name = "TabControlForm_MCS"
            Me.TabControlForm_MCS.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlForm_MCS.SelectedTabIndex = 0
            Me.TabControlForm_MCS.Size = New System.Drawing.Size(685, 306)
            Me.TabControlForm_MCS.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlForm_MCS.TabIndex = 25
            Me.TabControlForm_MCS.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlForm_MCS.Tabs.Add(Me.TabItemJDA_OptionsTab)
            Me.TabControlForm_MCS.Tabs.Add(Me.TabItemJDA_SelectOfficesTab)
            Me.TabControlForm_MCS.Tabs.Add(Me.TabItemMCS_SelectClientsTab)
            '
            'OptionsControlSelect
            '
            Me.OptionsControlSelect.Controls.Add(Me.LabelOptions_MonthlyBroadcast)
            Me.OptionsControlSelect.Controls.Add(Me.PanelOptions_Display)
            Me.OptionsControlSelect.Controls.Add(Me.CheckBoxBroadcastDates)
            Me.OptionsControlSelect.DisabledBackColor = System.Drawing.Color.Empty
            Me.OptionsControlSelect.Dock = System.Windows.Forms.DockStyle.Fill
            Me.OptionsControlSelect.Location = New System.Drawing.Point(0, 27)
            Me.OptionsControlSelect.Name = "OptionsControlSelect"
            Me.OptionsControlSelect.Padding = New System.Windows.Forms.Padding(1)
            Me.OptionsControlSelect.Size = New System.Drawing.Size(685, 279)
            Me.OptionsControlSelect.Style.BackColor1.Color = System.Drawing.Color.White
            Me.OptionsControlSelect.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.OptionsControlSelect.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.OptionsControlSelect.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.OptionsControlSelect.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.OptionsControlSelect.Style.GradientAngle = 90
            Me.OptionsControlSelect.TabIndex = 12
            Me.OptionsControlSelect.TabItem = Me.TabItemJDA_OptionsTab
            '
            'LabelOptions_MonthlyBroadcast
            '
            Me.LabelOptions_MonthlyBroadcast.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.LabelOptions_MonthlyBroadcast.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelOptions_MonthlyBroadcast.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelOptions_MonthlyBroadcast.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelOptions_MonthlyBroadcast.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelOptions_MonthlyBroadcast.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelOptions_MonthlyBroadcast.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelOptions_MonthlyBroadcast.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelOptions_MonthlyBroadcast.Location = New System.Drawing.Point(14, 11)
            Me.LabelOptions_MonthlyBroadcast.Name = "LabelOptions_MonthlyBroadcast"
            Me.LabelOptions_MonthlyBroadcast.Size = New System.Drawing.Size(152, 20)
            Me.LabelOptions_MonthlyBroadcast.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelOptions_MonthlyBroadcast.TabIndex = 24
            Me.LabelOptions_MonthlyBroadcast.Text = " Display Month/Year"
            '
            'PanelOptions_Display
            '
            Me.PanelOptions_Display.BackColor = System.Drawing.Color.Transparent
            Me.PanelOptions_Display.Controls.Add(Me.RadioButtonStandardDates)
            Me.PanelOptions_Display.Controls.Add(Me.RadioButtonBroadcastDates2)
            Me.PanelOptions_Display.Location = New System.Drawing.Point(14, 32)
            Me.PanelOptions_Display.Name = "PanelOptions_Display"
            Me.PanelOptions_Display.Size = New System.Drawing.Size(152, 53)
            Me.PanelOptions_Display.TabIndex = 23
            '
            'RadioButtonStandardDates
            '
            Me.RadioButtonStandardDates.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.RadioButtonStandardDates.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonStandardDates.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonStandardDates.Checked = True
            Me.RadioButtonStandardDates.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonStandardDates.CheckValue = "Y"
            Me.RadioButtonStandardDates.Location = New System.Drawing.Point(4, 2)
            Me.RadioButtonStandardDates.Name = "RadioButtonStandardDates"
            Me.RadioButtonStandardDates.SecurityEnabled = True
            Me.RadioButtonStandardDates.Size = New System.Drawing.Size(140, 20)
            Me.RadioButtonStandardDates.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonStandardDates.TabIndex = 0
            Me.RadioButtonStandardDates.TabOnEnter = True
            Me.RadioButtonStandardDates.Text = "Standard Month/Year"
            '
            'RadioButtonBroadcastDates2
            '
            Me.RadioButtonBroadcastDates2.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.RadioButtonBroadcastDates2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonBroadcastDates2.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonBroadcastDates2.Location = New System.Drawing.Point(4, 28)
            Me.RadioButtonBroadcastDates2.Name = "RadioButtonBroadcastDates2"
            Me.RadioButtonBroadcastDates2.SecurityEnabled = True
            Me.RadioButtonBroadcastDates2.Size = New System.Drawing.Size(140, 20)
            Me.RadioButtonBroadcastDates2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonBroadcastDates2.TabIndex = 1
            Me.RadioButtonBroadcastDates2.TabOnEnter = True
            Me.RadioButtonBroadcastDates2.TabStop = False
            Me.RadioButtonBroadcastDates2.Text = "Broadcast Month/Year"
            '
            'CheckBoxBroadcastDates
            '
            Me.CheckBoxBroadcastDates.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.CheckBoxBroadcastDates.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxBroadcastDates.CheckValue = 0
            Me.CheckBoxBroadcastDates.CheckValueChecked = 1
            Me.CheckBoxBroadcastDates.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxBroadcastDates.CheckValueUnchecked = 0
            Me.CheckBoxBroadcastDates.ChildControls = CType(resources.GetObject("CheckBoxBroadcastDates.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxBroadcastDates.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxBroadcastDates.Enabled = False
            Me.CheckBoxBroadcastDates.Location = New System.Drawing.Point(14, 107)
            Me.CheckBoxBroadcastDates.Name = "CheckBoxBroadcastDates"
            Me.CheckBoxBroadcastDates.OldestSibling = Nothing
            Me.CheckBoxBroadcastDates.SecurityEnabled = True
            Me.CheckBoxBroadcastDates.SiblingControls = CType(resources.GetObject("CheckBoxBroadcastDates.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxBroadcastDates.Size = New System.Drawing.Size(194, 20)
            Me.CheckBoxBroadcastDates.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxBroadcastDates.TabIndex = 22
            Me.CheckBoxBroadcastDates.TabOnEnter = True
            Me.CheckBoxBroadcastDates.Text = "Display Broadcast Month/Year"
            Me.CheckBoxBroadcastDates.Visible = False
            '
            'TabItemJDA_OptionsTab
            '
            Me.TabItemJDA_OptionsTab.AttachedControl = Me.OptionsControlSelect
            Me.TabItemJDA_OptionsTab.Name = "TabItemJDA_OptionsTab"
            Me.TabItemJDA_OptionsTab.Text = "Options"
            '
            'TabControlPanel1
            '
            Me.TabControlPanel1.Controls.Add(Me.DataGridViewSelectOffices_Offices)
            Me.TabControlPanel1.Controls.Add(Me.RadioButtonSelectOffices_ChooseOffices)
            Me.TabControlPanel1.Controls.Add(Me.RadioButtonSelectOffices_AllOffices)
            Me.TabControlPanel1.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanel1.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanel1.Name = "TabControlPanel1"
            Me.TabControlPanel1.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanel1.Size = New System.Drawing.Size(685, 279)
            Me.TabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanel1.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanel1.Style.GradientAngle = 90
            Me.TabControlPanel1.TabIndex = 4
            Me.TabControlPanel1.TabItem = Me.TabItemJDA_SelectOfficesTab
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
            Me.DataGridViewSelectOffices_Offices.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewSelectOffices_Offices.Enabled = False
            Me.DataGridViewSelectOffices_Offices.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSelectOffices_Offices.ItemDescription = "Office(s)"
            Me.DataGridViewSelectOffices_Offices.Location = New System.Drawing.Point(4, 30)
            Me.DataGridViewSelectOffices_Offices.MultiSelect = False
            Me.DataGridViewSelectOffices_Offices.Name = "DataGridViewSelectOffices_Offices"
            Me.DataGridViewSelectOffices_Offices.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewSelectOffices_Offices.RunStandardValidation = True
            Me.DataGridViewSelectOffices_Offices.ShowColumnMenuOnRightClick = False
            Me.DataGridViewSelectOffices_Offices.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSelectOffices_Offices.Size = New System.Drawing.Size(677, 245)
            Me.DataGridViewSelectOffices_Offices.TabIndex = 3
            Me.DataGridViewSelectOffices_Offices.UseEmbeddedNavigator = False
            Me.DataGridViewSelectOffices_Offices.ViewCaptionHeight = -1
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
            Me.RadioButtonSelectOffices_ChooseOffices.TabIndex = 2
            Me.RadioButtonSelectOffices_ChooseOffices.TabOnEnter = True
            Me.RadioButtonSelectOffices_ChooseOffices.TabStop = False
            Me.RadioButtonSelectOffices_ChooseOffices.Text = "Choose Offices"
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
            Me.RadioButtonSelectOffices_AllOffices.TabIndex = 1
            Me.RadioButtonSelectOffices_AllOffices.TabOnEnter = True
            Me.RadioButtonSelectOffices_AllOffices.Text = "All Offices"
            '
            'TabItemJDA_SelectOfficesTab
            '
            Me.TabItemJDA_SelectOfficesTab.AttachedControl = Me.TabControlPanel1
            Me.TabItemJDA_SelectOfficesTab.Name = "TabItemJDA_SelectOfficesTab"
            Me.TabItemJDA_SelectOfficesTab.Text = "Select Offices"
            '
            'TabControlPanel2
            '
            Me.TabControlPanel2.Controls.Add(Me.CDPChooserControlSelectClients_SelectClients)
            Me.TabControlPanel2.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanel2.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanel2.Name = "TabControlPanel2"
            Me.TabControlPanel2.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanel2.Size = New System.Drawing.Size(685, 279)
            Me.TabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanel2.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanel2.Style.GradientAngle = 90
            Me.TabControlPanel2.TabIndex = 8
            Me.TabControlPanel2.TabItem = Me.TabItemMCS_SelectClientsTab
            '
            'CDPChooserControlSelectClients_SelectClients
            '
            Me.CDPChooserControlSelectClients_SelectClients.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CDPChooserControlSelectClients_SelectClients.BackColor = System.Drawing.Color.Transparent
            Me.CDPChooserControlSelectClients_SelectClients.Location = New System.Drawing.Point(4, 4)
            Me.CDPChooserControlSelectClients_SelectClients.Name = "CDPChooserControlSelectClients_SelectClients"
            Me.CDPChooserControlSelectClients_SelectClients.Size = New System.Drawing.Size(677, 271)
            Me.CDPChooserControlSelectClients_SelectClients.TabIndex = 2
            '
            'TabItemMCS_SelectClientsTab
            '
            Me.TabItemMCS_SelectClientsTab.AttachedControl = Me.TabControlPanel2
            Me.TabItemMCS_SelectClientsTab.Name = "TabItemMCS_SelectClientsTab"
            Me.TabItemMCS_SelectClientsTab.Text = "Select C/D/P"
            '
            'MediaPlanInitialLoadingDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(709, 356)
            Me.Controls.Add(Me.TabControlForm_MCS)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaPlanInitialLoadingDialog"
            Me.Text = "Media Plan Initial Criteria"
            CType(Me.TabControlForm_MCS, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlForm_MCS.ResumeLayout(False)
            Me.OptionsControlSelect.ResumeLayout(False)
            Me.PanelOptions_Display.ResumeLayout(False)
            Me.TabControlPanel1.ResumeLayout(False)
            Me.TabControlPanel2.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents TabControlForm_MCS As WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanel2 As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents CDPChooserControlSelectClients_SelectClients As WinForm.Presentation.Controls.CDPChooserControl
        Friend WithEvents TabItemMCS_SelectClientsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanel1 As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewSelectOffices_Offices As WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RadioButtonSelectOffices_ChooseOffices As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSelectOffices_AllOffices As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents TabItemJDA_SelectOfficesTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents OptionsControlSelect As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents CheckBoxBroadcastDates As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents TabItemJDA_OptionsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents PanelOptions_Display As Windows.Forms.Panel
        Friend WithEvents RadioButtonStandardDates As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonBroadcastDates2 As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents LabelOptions_MonthlyBroadcast As WinForm.Presentation.Controls.Label
    End Class

End Namespace