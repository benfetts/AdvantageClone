Namespace GeneralLedger.ReportWriter.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ReportWriterForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportWriterForm))
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_ReportTypes = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemReportTypes_BalanceSheet = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemReportTypes_IncomeStatement = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemReportTypes_All = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Export = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Process = New DevComponents.DotNetBar.ButtonItem()
            Me.DataGridViewForm_ReportWriter = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RadioButtonForm_YearToDate = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.ComboBoxForm_YearToDatePostPeriods = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.RadioButtonForm_PostPeriod = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.TextBoxForm_PostPeriodTo = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxForm_PostPeriodFrom = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelForm_PostPeriodFrom = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_PostPeriodTo = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            Me.SuspendLayout()
            '
            'DefaultLookAndFeelOffice2010Blue
            '
            Me.DefaultLookAndFeel.LookAndFeel.SkinName = "Office 2013"
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_ReportTypes)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(12, 311)
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(662, 98)
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Options.Style.Class = ""
            Me.RibbonBarMergeContainerForm_Options.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Options.StyleMouseDown.Class = ""
            Me.RibbonBarMergeContainerForm_Options.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Options.StyleMouseOver.Class = ""
            Me.RibbonBarMergeContainerForm_Options.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarMergeContainerForm_Options.TabIndex = 3
            Me.RibbonBarMergeContainerForm_Options.Visible = False
            '
            'RibbonBarOptions_ReportTypes
            '
            Me.RibbonBarOptions_ReportTypes.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_ReportTypes.BackgroundMouseOverStyle.Class = ""
            Me.RibbonBarOptions_ReportTypes.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_ReportTypes.BackgroundStyle.Class = ""
            Me.RibbonBarOptions_ReportTypes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_ReportTypes.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_ReportTypes.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_ReportTypes.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemReportTypes_BalanceSheet, Me.ButtonItemReportTypes_IncomeStatement, Me.ButtonItemReportTypes_All})
            Me.RibbonBarOptions_ReportTypes.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_ReportTypes.Location = New System.Drawing.Point(104, 0)
            Me.RibbonBarOptions_ReportTypes.Name = "RibbonBarOptions_ReportTypes"
            Me.RibbonBarOptions_ReportTypes.Size = New System.Drawing.Size(238, 98)
            Me.RibbonBarOptions_ReportTypes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_ReportTypes.TabIndex = 2
            Me.RibbonBarOptions_ReportTypes.Text = "Report Types"
            '
            '
            '
            Me.RibbonBarOptions_ReportTypes.TitleStyle.Class = ""
            Me.RibbonBarOptions_ReportTypes.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_ReportTypes.TitleStyleMouseOver.Class = ""
            Me.RibbonBarOptions_ReportTypes.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_ReportTypes.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemReportTypes_BalanceSheet
            '
            Me.ButtonItemReportTypes_BalanceSheet.AutoCheckOnClick = True
            Me.ButtonItemReportTypes_BalanceSheet.BeginGroup = True
            Me.ButtonItemReportTypes_BalanceSheet.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemReportTypes_BalanceSheet.Checked = True
            Me.ButtonItemReportTypes_BalanceSheet.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemReportTypes_BalanceSheet.Name = "ButtonItemReportTypes_BalanceSheet"
            Me.ButtonItemReportTypes_BalanceSheet.OptionGroup = "ReportTypes"
            Me.ButtonItemReportTypes_BalanceSheet.RibbonWordWrap = False
            Me.ButtonItemReportTypes_BalanceSheet.Stretch = True
            Me.ButtonItemReportTypes_BalanceSheet.SubItemsExpandWidth = 14
            Me.ButtonItemReportTypes_BalanceSheet.Text = "Balance Sheet"
            '
            'ButtonItemReportTypes_IncomeStatement
            '
            Me.ButtonItemReportTypes_IncomeStatement.AutoCheckOnClick = True
            Me.ButtonItemReportTypes_IncomeStatement.BeginGroup = True
            Me.ButtonItemReportTypes_IncomeStatement.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemReportTypes_IncomeStatement.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemReportTypes_IncomeStatement.Name = "ButtonItemReportTypes_IncomeStatement"
            Me.ButtonItemReportTypes_IncomeStatement.OptionGroup = "ReportTypes"
            Me.ButtonItemReportTypes_IncomeStatement.RibbonWordWrap = False
            Me.ButtonItemReportTypes_IncomeStatement.Stretch = True
            Me.ButtonItemReportTypes_IncomeStatement.SubItemsExpandWidth = 14
            Me.ButtonItemReportTypes_IncomeStatement.Text = "Income Statement"
            '
            'ButtonItemReportTypes_All
            '
            Me.ButtonItemReportTypes_All.AutoCheckOnClick = True
            Me.ButtonItemReportTypes_All.BeginGroup = True
            Me.ButtonItemReportTypes_All.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemReportTypes_All.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemReportTypes_All.Name = "ButtonItemReportTypes_All"
            Me.ButtonItemReportTypes_All.OptionGroup = "ReportTypes"
            Me.ButtonItemReportTypes_All.RibbonWordWrap = False
            Me.ButtonItemReportTypes_All.Stretch = True
            Me.ButtonItemReportTypes_All.SubItemsExpandWidth = 14
            Me.ButtonItemReportTypes_All.Text = "All"
            '
            'RibbonBarOptions_Actions
            '
            Me.RibbonBarOptions_Actions.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Actions.BackgroundMouseOverStyle.Class = ""
            Me.RibbonBarOptions_Actions.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Actions.BackgroundStyle.Class = ""
            Me.RibbonBarOptions_Actions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Actions.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Actions.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Export, Me.ButtonItemActions_Process})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(104, 98)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 0
            Me.RibbonBarOptions_Actions.Text = "Actions"
            '
            '
            '
            Me.RibbonBarOptions_Actions.TitleStyle.Class = ""
            Me.RibbonBarOptions_Actions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Actions.TitleStyleMouseOver.Class = ""
            Me.RibbonBarOptions_Actions.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Actions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemActions_Export
            '
            Me.ButtonItemActions_Export.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Export.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Export.Name = "ButtonItemActions_Export"
            Me.ButtonItemActions_Export.RibbonWordWrap = False
            Me.ButtonItemActions_Export.Stretch = True
            Me.ButtonItemActions_Export.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Export.Text = "Export"
            '
            'ButtonItemActions_Process
            '
            Me.ButtonItemActions_Process.BeginGroup = True
            Me.ButtonItemActions_Process.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Process.Enabled = False
            Me.ButtonItemActions_Process.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Process.Name = "ButtonItemActions_Process"
            Me.ButtonItemActions_Process.RibbonWordWrap = False
            Me.ButtonItemActions_Process.Stretch = True
            Me.ButtonItemActions_Process.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Process.Text = "Process"
            '
            'DataGridViewForm_ReportWriter
            '
            Me.DataGridViewForm_ReportWriter.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_ReportWriter.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewForm_ReportWriter.DataSource = Nothing
            Me.DataGridViewForm_ReportWriter.ItemDescription = ""
            Me.DataGridViewForm_ReportWriter.Location = New System.Drawing.Point(12, 38)
            Me.DataGridViewForm_ReportWriter.MultiSelect = True
            Me.DataGridViewForm_ReportWriter.Name = "DataGridViewForm_ReportWriter"
            Me.DataGridViewForm_ReportWriter.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_ReportWriter.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_ReportWriter.Size = New System.Drawing.Size(689, 371)
            Me.DataGridViewForm_ReportWriter.TabIndex = 4
            '
            'RadioButtonForm_YearToDate
            '
            '
            '
            '
            Me.RadioButtonForm_YearToDate.BackgroundStyle.Class = ""
            Me.RadioButtonForm_YearToDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonForm_YearToDate.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonForm_YearToDate.Checked = True
            Me.RadioButtonForm_YearToDate.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonForm_YearToDate.CheckValue = "Y"
            Me.RadioButtonForm_YearToDate.Location = New System.Drawing.Point(12, 12)
            Me.RadioButtonForm_YearToDate.Name = "RadioButtonForm_YearToDate"
            Me.RadioButtonForm_YearToDate.Size = New System.Drawing.Size(85, 20)
            Me.RadioButtonForm_YearToDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonForm_YearToDate.TabIndex = 5
            Me.RadioButtonForm_YearToDate.Text = "Year To Date"
            '
            'ComboBoxForm_YearToDatePostPeriods
            '
            Me.ComboBoxForm_YearToDatePostPeriods.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_YearToDatePostPeriods.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_YearToDatePostPeriods.BookmarkingEnabled = False
            Me.ComboBoxForm_YearToDatePostPeriods.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.PostPeriod
            Me.ComboBoxForm_YearToDatePostPeriods.DisplayMember = "Description"
            Me.ComboBoxForm_YearToDatePostPeriods.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_YearToDatePostPeriods.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_YearToDatePostPeriods.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_YearToDatePostPeriods.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_YearToDatePostPeriods.FocusHighlightEnabled = True
            Me.ComboBoxForm_YearToDatePostPeriods.FormattingEnabled = True
            Me.ComboBoxForm_YearToDatePostPeriods.ItemHeight = 14
            Me.ComboBoxForm_YearToDatePostPeriods.Location = New System.Drawing.Point(103, 12)
            Me.ComboBoxForm_YearToDatePostPeriods.Name = "ComboBoxForm_YearToDatePostPeriods"
            Me.ComboBoxForm_YearToDatePostPeriods.PreventEnterBeep = True
            Me.ComboBoxForm_YearToDatePostPeriods.Size = New System.Drawing.Size(178, 20)
            Me.ComboBoxForm_YearToDatePostPeriods.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_YearToDatePostPeriods.TabIndex = 7
            Me.ComboBoxForm_YearToDatePostPeriods.ValueMember = "Code"
            Me.ComboBoxForm_YearToDatePostPeriods.WatermarkText = "Select Post Period"
            '
            'RadioButtonForm_PostPeriod
            '
            '
            '
            '
            Me.RadioButtonForm_PostPeriod.BackgroundStyle.Class = ""
            Me.RadioButtonForm_PostPeriod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonForm_PostPeriod.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonForm_PostPeriod.Location = New System.Drawing.Point(287, 12)
            Me.RadioButtonForm_PostPeriod.Name = "RadioButtonForm_PostPeriod"
            Me.RadioButtonForm_PostPeriod.Size = New System.Drawing.Size(55, 20)
            Me.RadioButtonForm_PostPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonForm_PostPeriod.TabIndex = 9
            Me.RadioButtonForm_PostPeriod.TabStop = False
            Me.RadioButtonForm_PostPeriod.Text = "Period"
            '
            'TextBoxForm_PostPeriodTo
            '
            '
            '
            '
            Me.TextBoxForm_PostPeriodTo.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_PostPeriodTo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_PostPeriodTo.ButtonCustom.Visible = True
            Me.TextBoxForm_PostPeriodTo.CheckSpellingOnValidate = False
            Me.TextBoxForm_PostPeriodTo.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.PostPeriod
            Me.TextBoxForm_PostPeriodTo.Enabled = False
            Me.TextBoxForm_PostPeriodTo.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_PostPeriodTo.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_PostPeriodTo.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_PostPeriodTo.FocusHighlightEnabled = True
            Me.TextBoxForm_PostPeriodTo.Location = New System.Drawing.Point(495, 12)
            Me.TextBoxForm_PostPeriodTo.Name = "TextBoxForm_PostPeriodTo"
            Me.TextBoxForm_PostPeriodTo.Size = New System.Drawing.Size(80, 20)
            Me.TextBoxForm_PostPeriodTo.TabIndex = 15
            Me.TextBoxForm_PostPeriodTo.TabOnEnter = True
            '
            'TextBoxForm_PostPeriodFrom
            '
            '
            '
            '
            Me.TextBoxForm_PostPeriodFrom.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_PostPeriodFrom.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_PostPeriodFrom.ButtonCustom.Visible = True
            Me.TextBoxForm_PostPeriodFrom.CheckSpellingOnValidate = False
            Me.TextBoxForm_PostPeriodFrom.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.PostPeriod
            Me.TextBoxForm_PostPeriodFrom.Enabled = False
            Me.TextBoxForm_PostPeriodFrom.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_PostPeriodFrom.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_PostPeriodFrom.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_PostPeriodFrom.FocusHighlightEnabled = True
            Me.TextBoxForm_PostPeriodFrom.Location = New System.Drawing.Point(385, 12)
            Me.TextBoxForm_PostPeriodFrom.Name = "TextBoxForm_PostPeriodFrom"
            Me.TextBoxForm_PostPeriodFrom.Size = New System.Drawing.Size(80, 20)
            Me.TextBoxForm_PostPeriodFrom.TabIndex = 13
            Me.TextBoxForm_PostPeriodFrom.TabOnEnter = True
            '
            'LabelForm_PostPeriodFrom
            '
            Me.LabelForm_PostPeriodFrom.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_PostPeriodFrom.BackgroundStyle.Class = ""
            Me.LabelForm_PostPeriodFrom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_PostPeriodFrom.Location = New System.Drawing.Point(348, 12)
            Me.LabelForm_PostPeriodFrom.Name = "LabelForm_PostPeriodFrom"
            Me.LabelForm_PostPeriodFrom.Size = New System.Drawing.Size(31, 20)
            Me.LabelForm_PostPeriodFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_PostPeriodFrom.TabIndex = 12
            Me.LabelForm_PostPeriodFrom.Text = "From:"
            '
            'LabelForm_PostPeriodTo
            '
            Me.LabelForm_PostPeriodTo.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_PostPeriodTo.BackgroundStyle.Class = ""
            Me.LabelForm_PostPeriodTo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_PostPeriodTo.Location = New System.Drawing.Point(471, 12)
            Me.LabelForm_PostPeriodTo.Name = "LabelForm_PostPeriodTo"
            Me.LabelForm_PostPeriodTo.Size = New System.Drawing.Size(18, 20)
            Me.LabelForm_PostPeriodTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_PostPeriodTo.TabIndex = 14
            Me.LabelForm_PostPeriodTo.Text = "To:"
            '
            'ReportWriterForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(713, 421)
            Me.Controls.Add(Me.ComboBoxForm_YearToDatePostPeriods)
            Me.Controls.Add(Me.RadioButtonForm_YearToDate)
            Me.Controls.Add(Me.LabelForm_PostPeriodFrom)
            Me.Controls.Add(Me.TextBoxForm_PostPeriodTo)
            Me.Controls.Add(Me.TextBoxForm_PostPeriodFrom)
            Me.Controls.Add(Me.RadioButtonForm_PostPeriod)
            Me.Controls.Add(Me.LabelForm_PostPeriodTo)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.DataGridViewForm_ReportWriter)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "ReportWriterForm"
            Me.Text = "General Ledger Report Writer"
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Export As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_ReportTypes As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemReportTypes_BalanceSheet As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemReportTypes_IncomeStatement As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents DataGridViewForm_ReportWriter As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ButtonItemReportTypes_All As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RadioButtonForm_YearToDate As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents ComboBoxForm_YearToDatePostPeriods As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents RadioButtonForm_PostPeriod As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents TextBoxForm_PostPeriodTo As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxForm_PostPeriodFrom As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelForm_PostPeriodFrom As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_PostPeriodTo As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ButtonItemActions_Process As DevComponents.DotNetBar.ButtonItem
    End Class

End Namespace

