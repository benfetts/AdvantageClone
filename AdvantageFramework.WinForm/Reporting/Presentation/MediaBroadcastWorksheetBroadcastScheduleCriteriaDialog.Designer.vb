Namespace Reporting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaBroadcastWorksheetBroadcastScheduleCriteriaDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaBroadcastWorksheetBroadcastScheduleCriteriaDialog))
            Me.ReportOptions_ListBoxMarkets = New System.Windows.Forms.ListBox()
            Me.ReportOptions_ListBoxVendor = New System.Windows.Forms.ListBox()
            Me.ReportOptions_CheckBoxScheduleDetail = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.ReportOptions_CheckBoxScheduleMarket = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.ReportOptions_CheckBoxScheduleStation = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.ReportOptions_CheckBoxScheduleWDSummary = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.Label11 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.Label1 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.Label2 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.Label4 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.Label5 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.Label6 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.Label9 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ReportOptions_ButtonOkay = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ReportOptions_ButtonCancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ReportOptions_ComboBoxLocation = New AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox()
            Me.ReportOptions_CheckBoxShowSecondary = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.ReportOptions_ComboBoxFrom = New AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox()
            Me.ReportOptions_ComboBoxTo = New AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox()
            Me.TabControl_Criteria = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanel_PrintOptions = New DevComponents.DotNetBar.TabControlPanel()
            Me.ReportOptions_CheckBoxShowNetCost = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.ReportOptions_CheckBoxShowRF = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.ReportOptions_CheckBoxShowAddedValue = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.ReportOptions_CheckBoxShowCPPM = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.ReportOptions_CheckBoxShowTotalCosts = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.ReportOptions_CheckBoxShowBookends = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.ReportOptions_CheckBoxShowImpressions = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.ReportOptions_CheckBoxShowSpotCosts = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.ReportOptions_CheckBoxShowComments = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.ReportOptions_CheckBoxShowRatings = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.TabReportOptions = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanel_Templates = New DevComponents.DotNetBar.TabControlPanel()
            Me.Templates_ButtonSaveOK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.Templates_TextBoxSaveTemplateName = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.Label7 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.Templates_ListboxTemplates = New System.Windows.Forms.ListBox()
            Me.Label3 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabTemplate = New DevComponents.DotNetBar.TabItem(Me.components)
            CType(Me.TabControl_Criteria, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControl_Criteria.SuspendLayout()
            Me.TabControlPanel_PrintOptions.SuspendLayout()
            Me.TabControlPanel_Templates.SuspendLayout()
            Me.SuspendLayout()
            '
            'ReportOptions_ListBoxMarkets
            '
            Me.ReportOptions_ListBoxMarkets.CausesValidation = False
            Me.ReportOptions_ListBoxMarkets.FormattingEnabled = True
            Me.ReportOptions_ListBoxMarkets.ItemHeight = 17
            Me.ReportOptions_ListBoxMarkets.Location = New System.Drawing.Point(96, 268)
            Me.ReportOptions_ListBoxMarkets.Name = "ReportOptions_ListBoxMarkets"
            Me.ReportOptions_ListBoxMarkets.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
            Me.ReportOptions_ListBoxMarkets.Size = New System.Drawing.Size(602, 72)
            Me.ReportOptions_ListBoxMarkets.TabIndex = 54
            '
            'ReportOptions_ListBoxVendor
            '
            Me.ReportOptions_ListBoxVendor.CausesValidation = False
            Me.ReportOptions_ListBoxVendor.FormattingEnabled = True
            Me.ReportOptions_ListBoxVendor.ItemHeight = 17
            Me.ReportOptions_ListBoxVendor.Location = New System.Drawing.Point(96, 358)
            Me.ReportOptions_ListBoxVendor.Name = "ReportOptions_ListBoxVendor"
            Me.ReportOptions_ListBoxVendor.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
            Me.ReportOptions_ListBoxVendor.Size = New System.Drawing.Size(601, 72)
            Me.ReportOptions_ListBoxVendor.TabIndex = 55
            '
            'ReportOptions_CheckBoxScheduleDetail
            '
            Me.ReportOptions_CheckBoxScheduleDetail.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.ReportOptions_CheckBoxScheduleDetail.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ReportOptions_CheckBoxScheduleDetail.CausesValidation = False
            Me.ReportOptions_CheckBoxScheduleDetail.CheckValue = 0
            Me.ReportOptions_CheckBoxScheduleDetail.CheckValueChecked = 1
            Me.ReportOptions_CheckBoxScheduleDetail.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.ReportOptions_CheckBoxScheduleDetail.CheckValueUnchecked = 0
            Me.ReportOptions_CheckBoxScheduleDetail.ChildControls = CType(resources.GetObject("ReportOptions_CheckBoxScheduleDetail.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.ReportOptions_CheckBoxScheduleDetail.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.ReportOptions_CheckBoxScheduleDetail.Location = New System.Drawing.Point(96, 4)
            Me.ReportOptions_CheckBoxScheduleDetail.Name = "ReportOptions_CheckBoxScheduleDetail"
            Me.ReportOptions_CheckBoxScheduleDetail.OldestSibling = Nothing
            Me.ReportOptions_CheckBoxScheduleDetail.SecurityEnabled = True
            Me.ReportOptions_CheckBoxScheduleDetail.SiblingControls = CType(resources.GetObject("ReportOptions_CheckBoxScheduleDetail.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.ReportOptions_CheckBoxScheduleDetail.Size = New System.Drawing.Size(137, 23)
            Me.ReportOptions_CheckBoxScheduleDetail.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ReportOptions_CheckBoxScheduleDetail.TabIndex = 23
            Me.ReportOptions_CheckBoxScheduleDetail.TabOnEnter = True
            Me.ReportOptions_CheckBoxScheduleDetail.Text = "Detail"
            '
            'ReportOptions_CheckBoxScheduleMarket
            '
            Me.ReportOptions_CheckBoxScheduleMarket.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.ReportOptions_CheckBoxScheduleMarket.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ReportOptions_CheckBoxScheduleMarket.CausesValidation = False
            Me.ReportOptions_CheckBoxScheduleMarket.CheckValue = 0
            Me.ReportOptions_CheckBoxScheduleMarket.CheckValueChecked = 1
            Me.ReportOptions_CheckBoxScheduleMarket.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.ReportOptions_CheckBoxScheduleMarket.CheckValueUnchecked = 0
            Me.ReportOptions_CheckBoxScheduleMarket.ChildControls = CType(resources.GetObject("ReportOptions_CheckBoxScheduleMarket.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.ReportOptions_CheckBoxScheduleMarket.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.ReportOptions_CheckBoxScheduleMarket.Location = New System.Drawing.Point(96, 33)
            Me.ReportOptions_CheckBoxScheduleMarket.Name = "ReportOptions_CheckBoxScheduleMarket"
            Me.ReportOptions_CheckBoxScheduleMarket.OldestSibling = Nothing
            Me.ReportOptions_CheckBoxScheduleMarket.SecurityEnabled = True
            Me.ReportOptions_CheckBoxScheduleMarket.SiblingControls = CType(resources.GetObject("ReportOptions_CheckBoxScheduleMarket.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.ReportOptions_CheckBoxScheduleMarket.Size = New System.Drawing.Size(137, 23)
            Me.ReportOptions_CheckBoxScheduleMarket.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ReportOptions_CheckBoxScheduleMarket.TabIndex = 24
            Me.ReportOptions_CheckBoxScheduleMarket.TabOnEnter = True
            Me.ReportOptions_CheckBoxScheduleMarket.Text = "Market Summary"
            '
            'ReportOptions_CheckBoxScheduleStation
            '
            Me.ReportOptions_CheckBoxScheduleStation.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.ReportOptions_CheckBoxScheduleStation.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ReportOptions_CheckBoxScheduleStation.CausesValidation = False
            Me.ReportOptions_CheckBoxScheduleStation.CheckValue = 0
            Me.ReportOptions_CheckBoxScheduleStation.CheckValueChecked = 1
            Me.ReportOptions_CheckBoxScheduleStation.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.ReportOptions_CheckBoxScheduleStation.CheckValueUnchecked = 0
            Me.ReportOptions_CheckBoxScheduleStation.ChildControls = CType(resources.GetObject("ReportOptions_CheckBoxScheduleStation.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.ReportOptions_CheckBoxScheduleStation.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.ReportOptions_CheckBoxScheduleStation.Location = New System.Drawing.Point(302, 4)
            Me.ReportOptions_CheckBoxScheduleStation.Name = "ReportOptions_CheckBoxScheduleStation"
            Me.ReportOptions_CheckBoxScheduleStation.OldestSibling = Nothing
            Me.ReportOptions_CheckBoxScheduleStation.SecurityEnabled = True
            Me.ReportOptions_CheckBoxScheduleStation.SiblingControls = CType(resources.GetObject("ReportOptions_CheckBoxScheduleStation.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.ReportOptions_CheckBoxScheduleStation.Size = New System.Drawing.Size(165, 23)
            Me.ReportOptions_CheckBoxScheduleStation.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ReportOptions_CheckBoxScheduleStation.TabIndex = 25
            Me.ReportOptions_CheckBoxScheduleStation.TabOnEnter = True
            Me.ReportOptions_CheckBoxScheduleStation.Text = "Station Summary"
            '
            'ReportOptions_CheckBoxScheduleWDSummary
            '
            Me.ReportOptions_CheckBoxScheduleWDSummary.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.ReportOptions_CheckBoxScheduleWDSummary.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ReportOptions_CheckBoxScheduleWDSummary.CausesValidation = False
            Me.ReportOptions_CheckBoxScheduleWDSummary.CheckValue = 0
            Me.ReportOptions_CheckBoxScheduleWDSummary.CheckValueChecked = 1
            Me.ReportOptions_CheckBoxScheduleWDSummary.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.ReportOptions_CheckBoxScheduleWDSummary.CheckValueUnchecked = 0
            Me.ReportOptions_CheckBoxScheduleWDSummary.ChildControls = CType(resources.GetObject("ReportOptions_CheckBoxScheduleWDSummary.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.ReportOptions_CheckBoxScheduleWDSummary.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.ReportOptions_CheckBoxScheduleWDSummary.Location = New System.Drawing.Point(302, 33)
            Me.ReportOptions_CheckBoxScheduleWDSummary.Name = "ReportOptions_CheckBoxScheduleWDSummary"
            Me.ReportOptions_CheckBoxScheduleWDSummary.OldestSibling = Nothing
            Me.ReportOptions_CheckBoxScheduleWDSummary.SecurityEnabled = True
            Me.ReportOptions_CheckBoxScheduleWDSummary.SiblingControls = CType(resources.GetObject("ReportOptions_CheckBoxScheduleWDSummary.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.ReportOptions_CheckBoxScheduleWDSummary.Size = New System.Drawing.Size(194, 23)
            Me.ReportOptions_CheckBoxScheduleWDSummary.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ReportOptions_CheckBoxScheduleWDSummary.TabIndex = 26
            Me.ReportOptions_CheckBoxScheduleWDSummary.TabOnEnter = True
            Me.ReportOptions_CheckBoxScheduleWDSummary.Text = "Weekly / Daily Summary"
            '
            'Label11
            '
            Me.Label11.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.Label11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.Label11.Location = New System.Drawing.Point(4, 4)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(75, 23)
            Me.Label11.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Label11.TabIndex = 29
            Me.Label11.Text = "Report(s):"
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.Label1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.Label1.Location = New System.Drawing.Point(4, 62)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(75, 23)
            Me.Label1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Label1.TabIndex = 30
            Me.Label1.Text = "Location:"
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.Label2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.Label2.Location = New System.Drawing.Point(4, 91)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(75, 23)
            Me.Label2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Label2.TabIndex = 31
            Me.Label2.Text = "Options:"
            '
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.Label4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.Label4.Location = New System.Drawing.Point(4, 239)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(86, 23)
            Me.Label4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Label4.TabIndex = 33
            Me.Label4.Text = "Dates From:"
            '
            'Label5
            '
            Me.Label5.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.Label5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.Label5.Location = New System.Drawing.Point(267, 239)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(29, 23)
            Me.Label5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Label5.TabIndex = 34
            Me.Label5.Text = "To:"
            '
            'Label6
            '
            Me.Label6.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.Label6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.Label6.Location = New System.Drawing.Point(4, 268)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(75, 23)
            Me.Label6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Label6.TabIndex = 35
            Me.Label6.Text = "Market(s):"
            '
            'Label9
            '
            Me.Label9.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.Label9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.Label9.Location = New System.Drawing.Point(4, 358)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(75, 23)
            Me.Label9.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Label9.TabIndex = 38
            Me.Label9.Text = "Station(s):"
            '
            'ReportOptions_ButtonOkay
            '
            Me.ReportOptions_ButtonOkay.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ReportOptions_ButtonOkay.CausesValidation = False
            Me.ReportOptions_ButtonOkay.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ReportOptions_ButtonOkay.Location = New System.Drawing.Point(492, 448)
            Me.ReportOptions_ButtonOkay.Name = "ReportOptions_ButtonOkay"
            Me.ReportOptions_ButtonOkay.SecurityEnabled = True
            Me.ReportOptions_ButtonOkay.Size = New System.Drawing.Size(100, 25)
            Me.ReportOptions_ButtonOkay.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ReportOptions_ButtonOkay.TabIndex = 39
            Me.ReportOptions_ButtonOkay.Text = "OK"
            '
            'ReportOptions_ButtonCancel
            '
            Me.ReportOptions_ButtonCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ReportOptions_ButtonCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ReportOptions_ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.ReportOptions_ButtonCancel.Location = New System.Drawing.Point(598, 448)
            Me.ReportOptions_ButtonCancel.Name = "ReportOptions_ButtonCancel"
            Me.ReportOptions_ButtonCancel.SecurityEnabled = True
            Me.ReportOptions_ButtonCancel.Size = New System.Drawing.Size(100, 25)
            Me.ReportOptions_ButtonCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ReportOptions_ButtonCancel.TabIndex = 40
            Me.ReportOptions_ButtonCancel.Text = "Cancel"
            '
            'ReportOptions_ComboBoxLocation
            '
            Me.ReportOptions_ComboBoxLocation.AddInactiveItemsOnSelectedValue = False
            Me.ReportOptions_ComboBoxLocation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ReportOptions_ComboBoxLocation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ReportOptions_ComboBoxLocation.AutoFindItemInDataSource = False
            Me.ReportOptions_ComboBoxLocation.AutoSelectSingleItemDatasource = False
            Me.ReportOptions_ComboBoxLocation.BookmarkingEnabled = False
            Me.ReportOptions_ComboBoxLocation.CausesValidation = False
            Me.ReportOptions_ComboBoxLocation.DisableMouseWheel = False
            Me.ReportOptions_ComboBoxLocation.DisplayMember = "Text"
            Me.ReportOptions_ComboBoxLocation.DisplayName = ""
            Me.ReportOptions_ComboBoxLocation.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ReportOptions_ComboBoxLocation.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ReportOptions_ComboBoxLocation.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ReportOptions_ComboBoxLocation.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ReportOptions_ComboBoxLocation.FocusHighlightEnabled = True
            Me.ReportOptions_ComboBoxLocation.FormattingEnabled = True
            Me.ReportOptions_ComboBoxLocation.ItemHeight = 18
            Me.ReportOptions_ComboBoxLocation.Location = New System.Drawing.Point(95, 62)
            Me.ReportOptions_ComboBoxLocation.Name = "ReportOptions_ComboBoxLocation"
            Me.ReportOptions_ComboBoxLocation.ReadOnly = False
            Me.ReportOptions_ComboBoxLocation.SecurityEnabled = True
            Me.ReportOptions_ComboBoxLocation.Size = New System.Drawing.Size(602, 24)
            Me.ReportOptions_ComboBoxLocation.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ReportOptions_ComboBoxLocation.TabIndex = 27
            Me.ReportOptions_ComboBoxLocation.TabOnEnter = True
            '
            'ReportOptions_CheckBoxShowSecondary
            '
            Me.ReportOptions_CheckBoxShowSecondary.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.ReportOptions_CheckBoxShowSecondary.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ReportOptions_CheckBoxShowSecondary.CausesValidation = False
            Me.ReportOptions_CheckBoxShowSecondary.CheckValue = 0
            Me.ReportOptions_CheckBoxShowSecondary.CheckValueChecked = 1
            Me.ReportOptions_CheckBoxShowSecondary.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.ReportOptions_CheckBoxShowSecondary.CheckValueUnchecked = 0
            Me.ReportOptions_CheckBoxShowSecondary.ChildControls = CType(resources.GetObject("ReportOptions_CheckBoxShowSecondary.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.ReportOptions_CheckBoxShowSecondary.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.ReportOptions_CheckBoxShowSecondary.Location = New System.Drawing.Point(96, 92)
            Me.ReportOptions_CheckBoxShowSecondary.Name = "ReportOptions_CheckBoxShowSecondary"
            Me.ReportOptions_CheckBoxShowSecondary.OldestSibling = Nothing
            Me.ReportOptions_CheckBoxShowSecondary.SecurityEnabled = True
            Me.ReportOptions_CheckBoxShowSecondary.SiblingControls = CType(resources.GetObject("ReportOptions_CheckBoxShowSecondary.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.ReportOptions_CheckBoxShowSecondary.Size = New System.Drawing.Size(176, 23)
            Me.ReportOptions_CheckBoxShowSecondary.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ReportOptions_CheckBoxShowSecondary.TabIndex = 42
            Me.ReportOptions_CheckBoxShowSecondary.TabOnEnter = True
            Me.ReportOptions_CheckBoxShowSecondary.Text = "Show Secondary Demo"
            '
            'ReportOptions_ComboBoxFrom
            '
            Me.ReportOptions_ComboBoxFrom.AddInactiveItemsOnSelectedValue = False
            Me.ReportOptions_ComboBoxFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ReportOptions_ComboBoxFrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ReportOptions_ComboBoxFrom.AutoFindItemInDataSource = False
            Me.ReportOptions_ComboBoxFrom.AutoSelectSingleItemDatasource = False
            Me.ReportOptions_ComboBoxFrom.BookmarkingEnabled = False
            Me.ReportOptions_ComboBoxFrom.CausesValidation = False
            Me.ReportOptions_ComboBoxFrom.DisableMouseWheel = False
            Me.ReportOptions_ComboBoxFrom.DisplayMember = "Text"
            Me.ReportOptions_ComboBoxFrom.DisplayName = ""
            Me.ReportOptions_ComboBoxFrom.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ReportOptions_ComboBoxFrom.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ReportOptions_ComboBoxFrom.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ReportOptions_ComboBoxFrom.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ReportOptions_ComboBoxFrom.FocusHighlightEnabled = True
            Me.ReportOptions_ComboBoxFrom.FormattingEnabled = True
            Me.ReportOptions_ComboBoxFrom.ItemHeight = 18
            Me.ReportOptions_ComboBoxFrom.Location = New System.Drawing.Point(96, 240)
            Me.ReportOptions_ComboBoxFrom.Name = "ReportOptions_ComboBoxFrom"
            Me.ReportOptions_ComboBoxFrom.ReadOnly = False
            Me.ReportOptions_ComboBoxFrom.SecurityEnabled = True
            Me.ReportOptions_ComboBoxFrom.Size = New System.Drawing.Size(150, 24)
            Me.ReportOptions_ComboBoxFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ReportOptions_ComboBoxFrom.TabIndex = 52
            Me.ReportOptions_ComboBoxFrom.TabOnEnter = True
            '
            'ReportOptions_ComboBoxTo
            '
            Me.ReportOptions_ComboBoxTo.AddInactiveItemsOnSelectedValue = False
            Me.ReportOptions_ComboBoxTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ReportOptions_ComboBoxTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ReportOptions_ComboBoxTo.AutoFindItemInDataSource = False
            Me.ReportOptions_ComboBoxTo.AutoSelectSingleItemDatasource = False
            Me.ReportOptions_ComboBoxTo.BookmarkingEnabled = False
            Me.ReportOptions_ComboBoxTo.CausesValidation = False
            Me.ReportOptions_ComboBoxTo.DisableMouseWheel = False
            Me.ReportOptions_ComboBoxTo.DisplayMember = "Text"
            Me.ReportOptions_ComboBoxTo.DisplayName = ""
            Me.ReportOptions_ComboBoxTo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ReportOptions_ComboBoxTo.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ReportOptions_ComboBoxTo.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ReportOptions_ComboBoxTo.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ReportOptions_ComboBoxTo.FocusHighlightEnabled = True
            Me.ReportOptions_ComboBoxTo.FormattingEnabled = True
            Me.ReportOptions_ComboBoxTo.ItemHeight = 18
            Me.ReportOptions_ComboBoxTo.Location = New System.Drawing.Point(302, 240)
            Me.ReportOptions_ComboBoxTo.Name = "ReportOptions_ComboBoxTo"
            Me.ReportOptions_ComboBoxTo.ReadOnly = False
            Me.ReportOptions_ComboBoxTo.SecurityEnabled = True
            Me.ReportOptions_ComboBoxTo.Size = New System.Drawing.Size(150, 24)
            Me.ReportOptions_ComboBoxTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ReportOptions_ComboBoxTo.TabIndex = 53
            Me.ReportOptions_ComboBoxTo.TabOnEnter = True
            '
            'TabControl_Criteria
            '
            Me.TabControl_Criteria.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControl_Criteria.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer))
            Me.TabControl_Criteria.CanReorderTabs = False
            Me.TabControl_Criteria.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControl_Criteria.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControl_Criteria.Controls.Add(Me.TabControlPanel_PrintOptions)
            Me.TabControl_Criteria.Controls.Add(Me.TabControlPanel_Templates)
            Me.TabControl_Criteria.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
            Me.TabControl_Criteria.Location = New System.Drawing.Point(6, 12)
            Me.TabControl_Criteria.Margin = New System.Windows.Forms.Padding(4)
            Me.TabControl_Criteria.Name = "TabControl_Criteria"
            Me.TabControl_Criteria.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
            Me.TabControl_Criteria.SelectedTabIndex = 1
            Me.TabControl_Criteria.Size = New System.Drawing.Size(726, 534)
            Me.TabControl_Criteria.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControl_Criteria.TabIndex = 45
            Me.TabControl_Criteria.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControl_Criteria.Tabs.Add(Me.TabReportOptions)
            Me.TabControl_Criteria.Tabs.Add(Me.TabTemplate)
            Me.TabControl_Criteria.Text = "TabControl1"
            '
            'TabControlPanel_PrintOptions
            '
            Me.TabControlPanel_PrintOptions.Anchor = System.Windows.Forms.AnchorStyles.None
            Me.TabControlPanel_PrintOptions.Controls.Add(Me.ReportOptions_CheckBoxShowNetCost)
            Me.TabControlPanel_PrintOptions.Controls.Add(Me.ReportOptions_CheckBoxShowRF)
            Me.TabControlPanel_PrintOptions.Controls.Add(Me.ReportOptions_CheckBoxShowAddedValue)
            Me.TabControlPanel_PrintOptions.Controls.Add(Me.ReportOptions_CheckBoxShowCPPM)
            Me.TabControlPanel_PrintOptions.Controls.Add(Me.ReportOptions_CheckBoxShowTotalCosts)
            Me.TabControlPanel_PrintOptions.Controls.Add(Me.ReportOptions_CheckBoxShowBookends)
            Me.TabControlPanel_PrintOptions.Controls.Add(Me.ReportOptions_CheckBoxShowImpressions)
            Me.TabControlPanel_PrintOptions.Controls.Add(Me.ReportOptions_CheckBoxShowSpotCosts)
            Me.TabControlPanel_PrintOptions.Controls.Add(Me.ReportOptions_CheckBoxShowComments)
            Me.TabControlPanel_PrintOptions.Controls.Add(Me.ReportOptions_CheckBoxShowRatings)
            Me.TabControlPanel_PrintOptions.Controls.Add(Me.ReportOptions_ButtonCancel)
            Me.TabControlPanel_PrintOptions.Controls.Add(Me.ReportOptions_ButtonOkay)
            Me.TabControlPanel_PrintOptions.Controls.Add(Me.Label11)
            Me.TabControlPanel_PrintOptions.Controls.Add(Me.Label1)
            Me.TabControlPanel_PrintOptions.Controls.Add(Me.ReportOptions_CheckBoxScheduleDetail)
            Me.TabControlPanel_PrintOptions.Controls.Add(Me.ReportOptions_CheckBoxScheduleMarket)
            Me.TabControlPanel_PrintOptions.Controls.Add(Me.ReportOptions_CheckBoxScheduleStation)
            Me.TabControlPanel_PrintOptions.Controls.Add(Me.ReportOptions_CheckBoxScheduleWDSummary)
            Me.TabControlPanel_PrintOptions.Controls.Add(Me.ReportOptions_ComboBoxLocation)
            Me.TabControlPanel_PrintOptions.Controls.Add(Me.ReportOptions_CheckBoxShowSecondary)
            Me.TabControlPanel_PrintOptions.Controls.Add(Me.ReportOptions_ComboBoxFrom)
            Me.TabControlPanel_PrintOptions.Controls.Add(Me.Label2)
            Me.TabControlPanel_PrintOptions.Controls.Add(Me.ReportOptions_ComboBoxTo)
            Me.TabControlPanel_PrintOptions.Controls.Add(Me.ReportOptions_ListBoxVendor)
            Me.TabControlPanel_PrintOptions.Controls.Add(Me.Label4)
            Me.TabControlPanel_PrintOptions.Controls.Add(Me.Label9)
            Me.TabControlPanel_PrintOptions.Controls.Add(Me.ReportOptions_ListBoxMarkets)
            Me.TabControlPanel_PrintOptions.Controls.Add(Me.Label6)
            Me.TabControlPanel_PrintOptions.Controls.Add(Me.Label5)
            Me.TabControlPanel_PrintOptions.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanel_PrintOptions.Location = New System.Drawing.Point(0, 33)
            Me.TabControlPanel_PrintOptions.Name = "TabControlPanel_PrintOptions"
            Me.TabControlPanel_PrintOptions.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanel_PrintOptions.Size = New System.Drawing.Size(726, 501)
            Me.TabControlPanel_PrintOptions.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanel_PrintOptions.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanel_PrintOptions.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanel_PrintOptions.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanel_PrintOptions.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanel_PrintOptions.Style.GradientAngle = 90
            Me.TabControlPanel_PrintOptions.TabIndex = 1
            Me.TabControlPanel_PrintOptions.TabItem = Me.TabReportOptions
            '
            'ReportOptions_CheckBoxShowNetCost
            '
            Me.ReportOptions_CheckBoxShowNetCost.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.ReportOptions_CheckBoxShowNetCost.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ReportOptions_CheckBoxShowNetCost.CausesValidation = False
            Me.ReportOptions_CheckBoxShowNetCost.CheckValue = 0
            Me.ReportOptions_CheckBoxShowNetCost.CheckValueChecked = 1
            Me.ReportOptions_CheckBoxShowNetCost.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.ReportOptions_CheckBoxShowNetCost.CheckValueUnchecked = 0
            Me.ReportOptions_CheckBoxShowNetCost.ChildControls = CType(resources.GetObject("ReportOptions_CheckBoxShowNetCost.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.ReportOptions_CheckBoxShowNetCost.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.ReportOptions_CheckBoxShowNetCost.Location = New System.Drawing.Point(492, 92)
            Me.ReportOptions_CheckBoxShowNetCost.Name = "ReportOptions_CheckBoxShowNetCost"
            Me.ReportOptions_CheckBoxShowNetCost.OldestSibling = Nothing
            Me.ReportOptions_CheckBoxShowNetCost.SecurityEnabled = True
            Me.ReportOptions_CheckBoxShowNetCost.SiblingControls = CType(resources.GetObject("ReportOptions_CheckBoxShowNetCost.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.ReportOptions_CheckBoxShowNetCost.Size = New System.Drawing.Size(176, 23)
            Me.ReportOptions_CheckBoxShowNetCost.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ReportOptions_CheckBoxShowNetCost.TabIndex = 56
            Me.ReportOptions_CheckBoxShowNetCost.TabOnEnter = True
            Me.ReportOptions_CheckBoxShowNetCost.Text = "Show Net Cost"
            '
            'ReportOptions_CheckBoxShowRF
            '
            Me.ReportOptions_CheckBoxShowRF.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.ReportOptions_CheckBoxShowRF.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ReportOptions_CheckBoxShowRF.CausesValidation = False
            Me.ReportOptions_CheckBoxShowRF.CheckValue = 0
            Me.ReportOptions_CheckBoxShowRF.CheckValueChecked = 1
            Me.ReportOptions_CheckBoxShowRF.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.ReportOptions_CheckBoxShowRF.CheckValueUnchecked = 0
            Me.ReportOptions_CheckBoxShowRF.ChildControls = CType(resources.GetObject("ReportOptions_CheckBoxShowRF.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.ReportOptions_CheckBoxShowRF.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.ReportOptions_CheckBoxShowRF.Location = New System.Drawing.Point(95, 209)
            Me.ReportOptions_CheckBoxShowRF.Name = "ReportOptions_CheckBoxShowRF"
            Me.ReportOptions_CheckBoxShowRF.OldestSibling = Nothing
            Me.ReportOptions_CheckBoxShowRF.SecurityEnabled = True
            Me.ReportOptions_CheckBoxShowRF.SiblingControls = CType(resources.GetObject("ReportOptions_CheckBoxShowRF.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.ReportOptions_CheckBoxShowRF.Size = New System.Drawing.Size(176, 23)
            Me.ReportOptions_CheckBoxShowRF.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ReportOptions_CheckBoxShowRF.TabIndex = 46
            Me.ReportOptions_CheckBoxShowRF.TabOnEnter = True
            Me.ReportOptions_CheckBoxShowRF.Text = "Show R and F"
            '
            'ReportOptions_CheckBoxShowAddedValue
            '
            Me.ReportOptions_CheckBoxShowAddedValue.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.ReportOptions_CheckBoxShowAddedValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ReportOptions_CheckBoxShowAddedValue.CausesValidation = False
            Me.ReportOptions_CheckBoxShowAddedValue.CheckValue = 0
            Me.ReportOptions_CheckBoxShowAddedValue.CheckValueChecked = 1
            Me.ReportOptions_CheckBoxShowAddedValue.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.ReportOptions_CheckBoxShowAddedValue.CheckValueUnchecked = 0
            Me.ReportOptions_CheckBoxShowAddedValue.ChildControls = CType(resources.GetObject("ReportOptions_CheckBoxShowAddedValue.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.ReportOptions_CheckBoxShowAddedValue.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.ReportOptions_CheckBoxShowAddedValue.Location = New System.Drawing.Point(302, 209)
            Me.ReportOptions_CheckBoxShowAddedValue.Name = "ReportOptions_CheckBoxShowAddedValue"
            Me.ReportOptions_CheckBoxShowAddedValue.OldestSibling = Nothing
            Me.ReportOptions_CheckBoxShowAddedValue.SecurityEnabled = True
            Me.ReportOptions_CheckBoxShowAddedValue.SiblingControls = CType(resources.GetObject("ReportOptions_CheckBoxShowAddedValue.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.ReportOptions_CheckBoxShowAddedValue.Size = New System.Drawing.Size(176, 23)
            Me.ReportOptions_CheckBoxShowAddedValue.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ReportOptions_CheckBoxShowAddedValue.TabIndex = 51
            Me.ReportOptions_CheckBoxShowAddedValue.TabOnEnter = True
            Me.ReportOptions_CheckBoxShowAddedValue.Text = "Identify Added Value"
            '
            'ReportOptions_CheckBoxShowCPPM
            '
            Me.ReportOptions_CheckBoxShowCPPM.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.ReportOptions_CheckBoxShowCPPM.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ReportOptions_CheckBoxShowCPPM.CausesValidation = False
            Me.ReportOptions_CheckBoxShowCPPM.CheckValue = 0
            Me.ReportOptions_CheckBoxShowCPPM.CheckValueChecked = 1
            Me.ReportOptions_CheckBoxShowCPPM.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.ReportOptions_CheckBoxShowCPPM.CheckValueUnchecked = 0
            Me.ReportOptions_CheckBoxShowCPPM.ChildControls = CType(resources.GetObject("ReportOptions_CheckBoxShowCPPM.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.ReportOptions_CheckBoxShowCPPM.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.ReportOptions_CheckBoxShowCPPM.Location = New System.Drawing.Point(96, 180)
            Me.ReportOptions_CheckBoxShowCPPM.Name = "ReportOptions_CheckBoxShowCPPM"
            Me.ReportOptions_CheckBoxShowCPPM.OldestSibling = Nothing
            Me.ReportOptions_CheckBoxShowCPPM.SecurityEnabled = True
            Me.ReportOptions_CheckBoxShowCPPM.SiblingControls = CType(resources.GetObject("ReportOptions_CheckBoxShowCPPM.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.ReportOptions_CheckBoxShowCPPM.Size = New System.Drawing.Size(176, 23)
            Me.ReportOptions_CheckBoxShowCPPM.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ReportOptions_CheckBoxShowCPPM.TabIndex = 45
            Me.ReportOptions_CheckBoxShowCPPM.TabOnEnter = True
            Me.ReportOptions_CheckBoxShowCPPM.Text = "Show CPP/M"
            '
            'ReportOptions_CheckBoxShowTotalCosts
            '
            Me.ReportOptions_CheckBoxShowTotalCosts.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.ReportOptions_CheckBoxShowTotalCosts.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ReportOptions_CheckBoxShowTotalCosts.CausesValidation = False
            Me.ReportOptions_CheckBoxShowTotalCosts.CheckValue = 0
            Me.ReportOptions_CheckBoxShowTotalCosts.CheckValueChecked = 1
            Me.ReportOptions_CheckBoxShowTotalCosts.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.ReportOptions_CheckBoxShowTotalCosts.CheckValueUnchecked = 0
            Me.ReportOptions_CheckBoxShowTotalCosts.ChildControls = CType(resources.GetObject("ReportOptions_CheckBoxShowTotalCosts.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.ReportOptions_CheckBoxShowTotalCosts.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.ReportOptions_CheckBoxShowTotalCosts.Location = New System.Drawing.Point(302, 121)
            Me.ReportOptions_CheckBoxShowTotalCosts.Name = "ReportOptions_CheckBoxShowTotalCosts"
            Me.ReportOptions_CheckBoxShowTotalCosts.OldestSibling = Nothing
            Me.ReportOptions_CheckBoxShowTotalCosts.SecurityEnabled = True
            Me.ReportOptions_CheckBoxShowTotalCosts.SiblingControls = CType(resources.GetObject("ReportOptions_CheckBoxShowTotalCosts.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.ReportOptions_CheckBoxShowTotalCosts.Size = New System.Drawing.Size(176, 23)
            Me.ReportOptions_CheckBoxShowTotalCosts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ReportOptions_CheckBoxShowTotalCosts.TabIndex = 48
            Me.ReportOptions_CheckBoxShowTotalCosts.TabOnEnter = True
            Me.ReportOptions_CheckBoxShowTotalCosts.Text = "Show Total Costs"
            '
            'ReportOptions_CheckBoxShowBookends
            '
            Me.ReportOptions_CheckBoxShowBookends.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.ReportOptions_CheckBoxShowBookends.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ReportOptions_CheckBoxShowBookends.CausesValidation = False
            Me.ReportOptions_CheckBoxShowBookends.CheckValue = 0
            Me.ReportOptions_CheckBoxShowBookends.CheckValueChecked = 1
            Me.ReportOptions_CheckBoxShowBookends.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.ReportOptions_CheckBoxShowBookends.CheckValueUnchecked = 0
            Me.ReportOptions_CheckBoxShowBookends.ChildControls = CType(resources.GetObject("ReportOptions_CheckBoxShowBookends.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.ReportOptions_CheckBoxShowBookends.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.ReportOptions_CheckBoxShowBookends.Location = New System.Drawing.Point(302, 180)
            Me.ReportOptions_CheckBoxShowBookends.Name = "ReportOptions_CheckBoxShowBookends"
            Me.ReportOptions_CheckBoxShowBookends.OldestSibling = Nothing
            Me.ReportOptions_CheckBoxShowBookends.SecurityEnabled = True
            Me.ReportOptions_CheckBoxShowBookends.SiblingControls = CType(resources.GetObject("ReportOptions_CheckBoxShowBookends.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.ReportOptions_CheckBoxShowBookends.Size = New System.Drawing.Size(176, 23)
            Me.ReportOptions_CheckBoxShowBookends.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ReportOptions_CheckBoxShowBookends.TabIndex = 50
            Me.ReportOptions_CheckBoxShowBookends.TabOnEnter = True
            Me.ReportOptions_CheckBoxShowBookends.Text = "Identify Bookends"
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
            Me.ReportOptions_CheckBoxShowImpressions.Location = New System.Drawing.Point(95, 150)
            Me.ReportOptions_CheckBoxShowImpressions.Name = "ReportOptions_CheckBoxShowImpressions"
            Me.ReportOptions_CheckBoxShowImpressions.OldestSibling = Nothing
            Me.ReportOptions_CheckBoxShowImpressions.SecurityEnabled = True
            Me.ReportOptions_CheckBoxShowImpressions.SiblingControls = CType(resources.GetObject("ReportOptions_CheckBoxShowImpressions.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.ReportOptions_CheckBoxShowImpressions.Size = New System.Drawing.Size(176, 23)
            Me.ReportOptions_CheckBoxShowImpressions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ReportOptions_CheckBoxShowImpressions.TabIndex = 44
            Me.ReportOptions_CheckBoxShowImpressions.TabOnEnter = True
            Me.ReportOptions_CheckBoxShowImpressions.Text = "Show Impressions"
            '
            'ReportOptions_CheckBoxShowSpotCosts
            '
            Me.ReportOptions_CheckBoxShowSpotCosts.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.ReportOptions_CheckBoxShowSpotCosts.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ReportOptions_CheckBoxShowSpotCosts.CausesValidation = False
            Me.ReportOptions_CheckBoxShowSpotCosts.CheckValue = 0
            Me.ReportOptions_CheckBoxShowSpotCosts.CheckValueChecked = 1
            Me.ReportOptions_CheckBoxShowSpotCosts.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.ReportOptions_CheckBoxShowSpotCosts.CheckValueUnchecked = 0
            Me.ReportOptions_CheckBoxShowSpotCosts.ChildControls = CType(resources.GetObject("ReportOptions_CheckBoxShowSpotCosts.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.ReportOptions_CheckBoxShowSpotCosts.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.ReportOptions_CheckBoxShowSpotCosts.Location = New System.Drawing.Point(302, 92)
            Me.ReportOptions_CheckBoxShowSpotCosts.Name = "ReportOptions_CheckBoxShowSpotCosts"
            Me.ReportOptions_CheckBoxShowSpotCosts.OldestSibling = Nothing
            Me.ReportOptions_CheckBoxShowSpotCosts.SecurityEnabled = True
            Me.ReportOptions_CheckBoxShowSpotCosts.SiblingControls = CType(resources.GetObject("ReportOptions_CheckBoxShowSpotCosts.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.ReportOptions_CheckBoxShowSpotCosts.Size = New System.Drawing.Size(176, 23)
            Me.ReportOptions_CheckBoxShowSpotCosts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ReportOptions_CheckBoxShowSpotCosts.TabIndex = 47
            Me.ReportOptions_CheckBoxShowSpotCosts.TabOnEnter = True
            Me.ReportOptions_CheckBoxShowSpotCosts.Text = "Show Spot Rates"
            '
            'ReportOptions_CheckBoxShowComments
            '
            Me.ReportOptions_CheckBoxShowComments.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.ReportOptions_CheckBoxShowComments.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ReportOptions_CheckBoxShowComments.CausesValidation = False
            Me.ReportOptions_CheckBoxShowComments.CheckValue = 0
            Me.ReportOptions_CheckBoxShowComments.CheckValueChecked = 1
            Me.ReportOptions_CheckBoxShowComments.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.ReportOptions_CheckBoxShowComments.CheckValueUnchecked = 0
            Me.ReportOptions_CheckBoxShowComments.ChildControls = CType(resources.GetObject("ReportOptions_CheckBoxShowComments.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.ReportOptions_CheckBoxShowComments.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.ReportOptions_CheckBoxShowComments.Location = New System.Drawing.Point(302, 151)
            Me.ReportOptions_CheckBoxShowComments.Name = "ReportOptions_CheckBoxShowComments"
            Me.ReportOptions_CheckBoxShowComments.OldestSibling = Nothing
            Me.ReportOptions_CheckBoxShowComments.SecurityEnabled = True
            Me.ReportOptions_CheckBoxShowComments.SiblingControls = CType(resources.GetObject("ReportOptions_CheckBoxShowComments.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.ReportOptions_CheckBoxShowComments.Size = New System.Drawing.Size(176, 23)
            Me.ReportOptions_CheckBoxShowComments.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ReportOptions_CheckBoxShowComments.TabIndex = 49
            Me.ReportOptions_CheckBoxShowComments.TabOnEnter = True
            Me.ReportOptions_CheckBoxShowComments.Text = "Show Comments"
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
            Me.ReportOptions_CheckBoxShowRatings.Location = New System.Drawing.Point(96, 121)
            Me.ReportOptions_CheckBoxShowRatings.Name = "ReportOptions_CheckBoxShowRatings"
            Me.ReportOptions_CheckBoxShowRatings.OldestSibling = Nothing
            Me.ReportOptions_CheckBoxShowRatings.SecurityEnabled = True
            Me.ReportOptions_CheckBoxShowRatings.SiblingControls = CType(resources.GetObject("ReportOptions_CheckBoxShowRatings.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.ReportOptions_CheckBoxShowRatings.Size = New System.Drawing.Size(176, 23)
            Me.ReportOptions_CheckBoxShowRatings.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ReportOptions_CheckBoxShowRatings.TabIndex = 43
            Me.ReportOptions_CheckBoxShowRatings.TabOnEnter = True
            Me.ReportOptions_CheckBoxShowRatings.Text = "Show Ratings"
            '
            'TabReportOptions
            '
            Me.TabReportOptions.AttachedControl = Me.TabControlPanel_PrintOptions
            Me.TabReportOptions.Name = "TabReportOptions"
            Me.TabReportOptions.Text = "Report Options"
            '
            'TabControlPanel_Templates
            '
            Me.TabControlPanel_Templates.Controls.Add(Me.Templates_ButtonSaveOK)
            Me.TabControlPanel_Templates.Controls.Add(Me.Templates_TextBoxSaveTemplateName)
            Me.TabControlPanel_Templates.Controls.Add(Me.Label7)
            Me.TabControlPanel_Templates.Controls.Add(Me.Templates_ListboxTemplates)
            Me.TabControlPanel_Templates.Controls.Add(Me.Label3)
            Me.TabControlPanel_Templates.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanel_Templates.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanel_Templates.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanel_Templates.Name = "TabControlPanel_Templates"
            Me.TabControlPanel_Templates.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanel_Templates.Size = New System.Drawing.Size(726, 507)
            Me.TabControlPanel_Templates.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanel_Templates.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanel_Templates.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanel_Templates.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanel_Templates.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanel_Templates.Style.GradientAngle = 90
            Me.TabControlPanel_Templates.TabIndex = 5
            Me.TabControlPanel_Templates.TabItem = Me.TabTemplate
            '
            'Templates_ButtonSaveOK
            '
            Me.Templates_ButtonSaveOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.Templates_ButtonSaveOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.Templates_ButtonSaveOK.Location = New System.Drawing.Point(580, 184)
            Me.Templates_ButtonSaveOK.Name = "Templates_ButtonSaveOK"
            Me.Templates_ButtonSaveOK.SecurityEnabled = True
            Me.Templates_ButtonSaveOK.Size = New System.Drawing.Size(100, 25)
            Me.Templates_ButtonSaveOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Templates_ButtonSaveOK.TabIndex = 4
            Me.Templates_ButtonSaveOK.Text = "OK"
            '
            'Templates_TextBoxSaveTemplateName
            '
            '
            '
            '
            Me.Templates_TextBoxSaveTemplateName.Border.Class = "TextBoxBorder"
            Me.Templates_TextBoxSaveTemplateName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.Templates_TextBoxSaveTemplateName.CheckSpellingOnValidate = False
            Me.Templates_TextBoxSaveTemplateName.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.Templates_TextBoxSaveTemplateName.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.Templates_TextBoxSaveTemplateName.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.Templates_TextBoxSaveTemplateName.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.Templates_TextBoxSaveTemplateName.FocusHighlightEnabled = True
            Me.Templates_TextBoxSaveTemplateName.Location = New System.Drawing.Point(86, 156)
            Me.Templates_TextBoxSaveTemplateName.MaxFileSize = CType(0, Long)
            Me.Templates_TextBoxSaveTemplateName.Name = "Templates_TextBoxSaveTemplateName"
            Me.Templates_TextBoxSaveTemplateName.PreventEnterBeep = True
            Me.Templates_TextBoxSaveTemplateName.SecurityEnabled = True
            Me.Templates_TextBoxSaveTemplateName.ShowSpellCheckCompleteMessage = True
            Me.Templates_TextBoxSaveTemplateName.Size = New System.Drawing.Size(595, 23)
            Me.Templates_TextBoxSaveTemplateName.StartingFolderName = Nothing
            Me.Templates_TextBoxSaveTemplateName.TabIndex = 3
            Me.Templates_TextBoxSaveTemplateName.TabOnEnter = True
            '
            'Label7
            '
            Me.Label7.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.Label7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.Label7.Location = New System.Drawing.Point(5, 154)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(75, 23)
            Me.Label7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Label7.TabIndex = 2
            Me.Label7.Text = "Save As:"
            '
            'Templates_ListboxTemplates
            '
            Me.Templates_ListboxTemplates.FormattingEnabled = True
            Me.Templates_ListboxTemplates.ItemHeight = 17
            Me.Templates_ListboxTemplates.Location = New System.Drawing.Point(85, 4)
            Me.Templates_ListboxTemplates.Name = "Templates_ListboxTemplates"
            Me.Templates_ListboxTemplates.Size = New System.Drawing.Size(595, 140)
            Me.Templates_ListboxTemplates.TabIndex = 1
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.Label3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.Label3.Location = New System.Drawing.Point(4, 4)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(75, 23)
            Me.Label3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.Label3.TabIndex = 0
            Me.Label3.Text = "Templates:"
            '
            'TabTemplate
            '
            Me.TabTemplate.AttachedControl = Me.TabControlPanel_Templates
            Me.TabTemplate.Name = "TabTemplate"
            Me.TabTemplate.Text = "Templates"
            '
            'MediaBroadcastWorksheetBroadcastScheduleCriteriaDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
            Me.CausesValidation = False
            Me.ClientSize = New System.Drawing.Size(737, 560)
            Me.Controls.Add(Me.TabControl_Criteria)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaBroadcastWorksheetBroadcastScheduleCriteriaDialog"
            Me.ShowUnsavedChangesOnFormClosing = False
            Me.Text = "Broadcast Schedule Reports"
            CType(Me.TabControl_Criteria, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControl_Criteria.ResumeLayout(False)
            Me.TabControlPanel_PrintOptions.ResumeLayout(False)
            Me.TabControlPanel_Templates.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ReportOptions_ListBoxMarkets As Windows.Forms.ListBox
        Friend WithEvents ReportOptions_ListBoxVendor As Windows.Forms.ListBox
        Friend WithEvents ReportOptions_CheckBoxScheduleDetail As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents ReportOptions_CheckBoxScheduleMarket As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents ReportOptions_CheckBoxScheduleStation As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents ReportOptions_CheckBoxScheduleWDSummary As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents Label11 As WinForm.Presentation.Controls.Label
        Friend WithEvents Label1 As WinForm.Presentation.Controls.Label
        Friend WithEvents Label2 As WinForm.Presentation.Controls.Label
        Friend WithEvents Label4 As WinForm.Presentation.Controls.Label
        Friend WithEvents Label5 As WinForm.Presentation.Controls.Label
        Friend WithEvents Label6 As WinForm.Presentation.Controls.Label
        Friend WithEvents Label9 As WinForm.Presentation.Controls.Label
        Friend WithEvents ReportOptions_ButtonOkay As WinForm.Presentation.Controls.Button
        Friend WithEvents ReportOptions_ButtonCancel As WinForm.Presentation.Controls.Button
        Friend WithEvents ReportOptions_ComboBoxLocation As WinForm.MVC.Presentation.Controls.ComboBox
        Friend WithEvents ReportOptions_CheckBoxShowSecondary As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents ReportOptions_ComboBoxFrom As WinForm.MVC.Presentation.Controls.ComboBox
        Friend WithEvents ReportOptions_ComboBoxTo As WinForm.MVC.Presentation.Controls.ComboBox
        Friend WithEvents TabControl_Criteria As WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanel_Templates As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents Templates_ButtonSaveOK As WinForm.Presentation.Controls.Button
        Friend WithEvents Templates_TextBoxSaveTemplateName As WinForm.Presentation.Controls.TextBox
        Friend WithEvents Label7 As WinForm.Presentation.Controls.Label
        Friend WithEvents Templates_ListboxTemplates As Windows.Forms.ListBox
        Friend WithEvents Label3 As WinForm.Presentation.Controls.Label
        Friend WithEvents TabTemplate As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanel_PrintOptions As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabReportOptions As DevComponents.DotNetBar.TabItem
        Friend WithEvents ReportOptions_CheckBoxShowRatings As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents ReportOptions_CheckBoxShowRF As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents ReportOptions_CheckBoxShowAddedValue As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents ReportOptions_CheckBoxShowCPPM As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents ReportOptions_CheckBoxShowTotalCosts As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents ReportOptions_CheckBoxShowBookends As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents ReportOptions_CheckBoxShowImpressions As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents ReportOptions_CheckBoxShowSpotCosts As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents ReportOptions_CheckBoxShowComments As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents ReportOptions_CheckBoxShowNetCost As WinForm.MVC.Presentation.Controls.CheckBox
    End Class

End Namespace