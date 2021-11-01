Namespace FinanceAndAccounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class AccountsPayableRecurPostForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AccountsPayableRecurPostForm))
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Post = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Print = New DevComponents.DotNetBar.ButtonItem()
            Me.DataGridViewForm_APRecur = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ComboBoxControl_Cycle = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_Cycle = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_PostingPeriod = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_PostingPeriod = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DateTimePickerForm_InvoiceDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelForm_InvoiceDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            CType(Me.DateTimePickerForm_InvoiceDate, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(12, 156)
            Me.RibbonBarMergeContainerForm_Options.MergeRibbonGroupName = "RibbonTabGroupDynamicReport"
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(253, 92)
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
            Me.RibbonBarMergeContainerForm_Options.TabIndex = 7
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Post, Me.ButtonItemActions_Print})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(147, 92)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 0
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
            'ButtonItemActions_Post
            '
            Me.ButtonItemActions_Post.BeginGroup = True
            Me.ButtonItemActions_Post.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Post.Name = "ButtonItemActions_Post"
            Me.ButtonItemActions_Post.RibbonWordWrap = False
            Me.ButtonItemActions_Post.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Post.Text = "Post"
            '
            'ButtonItemActions_Print
            '
            Me.ButtonItemActions_Print.BeginGroup = True
            Me.ButtonItemActions_Print.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Print.Name = "ButtonItemActions_Print"
            Me.ButtonItemActions_Print.RibbonWordWrap = False
            Me.ButtonItemActions_Print.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Print.Text = "Print"
            '
            'DataGridViewForm_APRecur
            '
            Me.DataGridViewForm_APRecur.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_APRecur.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_APRecur.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_APRecur.AutoFilterLookupColumns = False
            Me.DataGridViewForm_APRecur.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_APRecur.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewForm_APRecur.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_APRecur.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_APRecur.ItemDescription = ""
            Me.DataGridViewForm_APRecur.Location = New System.Drawing.Point(12, 38)
            Me.DataGridViewForm_APRecur.MultiSelect = False
            Me.DataGridViewForm_APRecur.Name = "DataGridViewForm_APRecur"
            Me.DataGridViewForm_APRecur.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_APRecur.RunStandardValidation = True
            Me.DataGridViewForm_APRecur.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_APRecur.Size = New System.Drawing.Size(886, 340)
            Me.DataGridViewForm_APRecur.TabIndex = 6
            Me.DataGridViewForm_APRecur.UseEmbeddedNavigator = False
            Me.DataGridViewForm_APRecur.ViewCaptionHeight = -1
            '
            'ComboBoxControl_Cycle
            '
            Me.ComboBoxControl_Cycle.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxControl_Cycle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxControl_Cycle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxControl_Cycle.AutoFindItemInDataSource = False
            Me.ComboBoxControl_Cycle.AutoSelectSingleItemDatasource = False
            Me.ComboBoxControl_Cycle.BookmarkingEnabled = False
            Me.ComboBoxControl_Cycle.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Cycle
            Me.ComboBoxControl_Cycle.DisableMouseWheel = True
            Me.ComboBoxControl_Cycle.DisplayMember = "Name"
            Me.ComboBoxControl_Cycle.DisplayName = ""
            Me.ComboBoxControl_Cycle.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxControl_Cycle.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxControl_Cycle.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxControl_Cycle.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxControl_Cycle.FocusHighlightEnabled = True
            Me.ComboBoxControl_Cycle.FormattingEnabled = True
            Me.ComboBoxControl_Cycle.ItemHeight = 14
            Me.ComboBoxControl_Cycle.Location = New System.Drawing.Point(290, 12)
            Me.ComboBoxControl_Cycle.Name = "ComboBoxControl_Cycle"
            Me.ComboBoxControl_Cycle.PreventEnterBeep = False
            Me.ComboBoxControl_Cycle.ReadOnly = False
            Me.ComboBoxControl_Cycle.SecurityEnabled = True
            Me.ComboBoxControl_Cycle.Size = New System.Drawing.Size(122, 20)
            Me.ComboBoxControl_Cycle.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxControl_Cycle.TabIndex = 3
            Me.ComboBoxControl_Cycle.ValueMember = "Code"
            Me.ComboBoxControl_Cycle.WatermarkText = "Select Cycle"
            '
            'LabelForm_Cycle
            '
            Me.LabelForm_Cycle.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Cycle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Cycle.Location = New System.Drawing.Point(245, 12)
            Me.LabelForm_Cycle.Name = "LabelForm_Cycle"
            Me.LabelForm_Cycle.Size = New System.Drawing.Size(39, 20)
            Me.LabelForm_Cycle.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Cycle.TabIndex = 2
            Me.LabelForm_Cycle.Text = "Cycle:"
            '
            'ComboBoxForm_PostingPeriod
            '
            Me.ComboBoxForm_PostingPeriod.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_PostingPeriod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_PostingPeriod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_PostingPeriod.AutoFindItemInDataSource = False
            Me.ComboBoxForm_PostingPeriod.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_PostingPeriod.BookmarkingEnabled = False
            Me.ComboBoxForm_PostingPeriod.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.PostPeriod
            Me.ComboBoxForm_PostingPeriod.DisableMouseWheel = True
            Me.ComboBoxForm_PostingPeriod.DisplayMember = "Description"
            Me.ComboBoxForm_PostingPeriod.DisplayName = ""
            Me.ComboBoxForm_PostingPeriod.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_PostingPeriod.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_PostingPeriod.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_PostingPeriod.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_PostingPeriod.FocusHighlightEnabled = True
            Me.ComboBoxForm_PostingPeriod.FormattingEnabled = True
            Me.ComboBoxForm_PostingPeriod.ItemHeight = 14
            Me.ComboBoxForm_PostingPeriod.Location = New System.Drawing.Point(100, 12)
            Me.ComboBoxForm_PostingPeriod.Name = "ComboBoxForm_PostingPeriod"
            Me.ComboBoxForm_PostingPeriod.PreventEnterBeep = False
            Me.ComboBoxForm_PostingPeriod.ReadOnly = False
            Me.ComboBoxForm_PostingPeriod.SecurityEnabled = True
            Me.ComboBoxForm_PostingPeriod.Size = New System.Drawing.Size(122, 20)
            Me.ComboBoxForm_PostingPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_PostingPeriod.TabIndex = 1
            Me.ComboBoxForm_PostingPeriod.ValueMember = "Code"
            Me.ComboBoxForm_PostingPeriod.WatermarkText = "Select Post Period"
            '
            'LabelForm_PostingPeriod
            '
            Me.LabelForm_PostingPeriod.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_PostingPeriod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_PostingPeriod.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_PostingPeriod.Name = "LabelForm_PostingPeriod"
            Me.LabelForm_PostingPeriod.Size = New System.Drawing.Size(82, 20)
            Me.LabelForm_PostingPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_PostingPeriod.TabIndex = 0
            Me.LabelForm_PostingPeriod.Text = "Posting Period:"
            '
            'DateTimePickerForm_InvoiceDate
            '
            Me.DateTimePickerForm_InvoiceDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerForm_InvoiceDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerForm_InvoiceDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_InvoiceDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerForm_InvoiceDate.ButtonDropDown.Visible = True
            Me.DateTimePickerForm_InvoiceDate.ButtonFreeText.Checked = True
            Me.DateTimePickerForm_InvoiceDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerForm_InvoiceDate.CustomFormat = ""
            Me.DateTimePickerForm_InvoiceDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerForm_InvoiceDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerForm_InvoiceDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerForm_InvoiceDate.FocusHighlightEnabled = True
            Me.DateTimePickerForm_InvoiceDate.Format = DevComponents.Editors.eDateTimePickerFormat.Short
            Me.DateTimePickerForm_InvoiceDate.FreeTextEntryMode = True
            Me.DateTimePickerForm_InvoiceDate.IsPopupCalendarOpen = False
            Me.DateTimePickerForm_InvoiceDate.Location = New System.Drawing.Point(530, 12)
            Me.DateTimePickerForm_InvoiceDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerForm_InvoiceDate.Name = "DateTimePickerForm_InvoiceDate"
            Me.DateTimePickerForm_InvoiceDate.ReadOnly = False
            Me.DateTimePickerForm_InvoiceDate.Size = New System.Drawing.Size(97, 20)
            Me.DateTimePickerForm_InvoiceDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerForm_InvoiceDate.TabIndex = 5
            Me.DateTimePickerForm_InvoiceDate.Value = New Date(2013, 10, 1, 10, 10, 25, 377)
            '
            'LabelForm_InvoiceDate
            '
            Me.LabelForm_InvoiceDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_InvoiceDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_InvoiceDate.Location = New System.Drawing.Point(451, 12)
            Me.LabelForm_InvoiceDate.Name = "LabelForm_InvoiceDate"
            Me.LabelForm_InvoiceDate.Size = New System.Drawing.Size(73, 20)
            Me.LabelForm_InvoiceDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_InvoiceDate.TabIndex = 4
            Me.LabelForm_InvoiceDate.Text = "Invoice Date:"
            '
            'AccountsPayableRecurPostForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(910, 390)
            Me.Controls.Add(Me.DateTimePickerForm_InvoiceDate)
            Me.Controls.Add(Me.LabelForm_InvoiceDate)
            Me.Controls.Add(Me.ComboBoxControl_Cycle)
            Me.Controls.Add(Me.LabelForm_Cycle)
            Me.Controls.Add(Me.ComboBoxForm_PostingPeriod)
            Me.Controls.Add(Me.LabelForm_PostingPeriod)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.DataGridViewForm_APRecur)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "AccountsPayableRecurPostForm"
            Me.Text = "Accounts Payable Recur Post"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            CType(Me.DateTimePickerForm_InvoiceDate, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Post As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Print As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents DataGridViewForm_APRecur As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ComboBoxControl_Cycle As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_Cycle As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_PostingPeriod As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_PostingPeriod As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents DateTimePickerForm_InvoiceDate As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents LabelForm_InvoiceDate As AdvantageFramework.WinForm.Presentation.Controls.Label
    End Class

End Namespace

