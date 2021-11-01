Namespace Security.Reports.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ReportSelectionForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportSelectionForm))
            Me.DataGridViewForm_Selection = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RadioButtonForm_Select = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonForm_All = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.CheckBoxForm_ShowOnlyAccessibleModules = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ItemContainerReport_ReportCategory = New DevComponents.DotNetBar.ItemContainer()
            Me.ComboBoxItemReportType_Report = New DevComponents.DotNetBar.ComboBoxItem()
            Me.ButtonItemActions_ViewReport = New DevComponents.DotNetBar.ButtonItem()
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            Me.SuspendLayout()
            '
            'DefaultLookAndFeelOffice2010Blue
            '
            Me.DefaultLookAndFeel.LookAndFeel.SkinName = "Office 2016 Colorful"
            '
            'DataGridViewForm_Selection
            '
            Me.DataGridViewForm_Selection.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_Selection.AutoFilterLookupColumns = False
            Me.DataGridViewForm_Selection.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_Selection.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewForm_Selection.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_Selection.ItemDescription = ""
            Me.DataGridViewForm_Selection.Location = New System.Drawing.Point(12, 38)
            Me.DataGridViewForm_Selection.MultiSelect = True
            Me.DataGridViewForm_Selection.Name = "DataGridViewForm_Selection"
            Me.DataGridViewForm_Selection.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_Selection.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_Selection.Size = New System.Drawing.Size(659, 388)
            Me.DataGridViewForm_Selection.TabIndex = 5
            Me.DataGridViewForm_Selection.UseEmbeddedNavigator = False
            Me.DataGridViewForm_Selection.ViewCaptionHeight = -1
            '
            'RadioButtonForm_Select
            '
            '
            '
            '
            Me.RadioButtonForm_Select.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonForm_Select.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonForm_Select.Location = New System.Drawing.Point(57, 12)
            Me.RadioButtonForm_Select.Name = "RadioButtonForm_Select"
            Me.RadioButtonForm_Select.Size = New System.Drawing.Size(57, 20)
            Me.RadioButtonForm_Select.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonForm_Select.TabIndex = 3
            Me.RadioButtonForm_Select.TabStop = False
            Me.RadioButtonForm_Select.Text = "Select"
            '
            'RadioButtonForm_All
            '
            '
            '
            '
            Me.RadioButtonForm_All.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonForm_All.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonForm_All.Checked = True
            Me.RadioButtonForm_All.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonForm_All.CheckValue = "Y"
            Me.RadioButtonForm_All.Location = New System.Drawing.Point(12, 12)
            Me.RadioButtonForm_All.Name = "RadioButtonForm_All"
            Me.RadioButtonForm_All.Size = New System.Drawing.Size(39, 20)
            Me.RadioButtonForm_All.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonForm_All.TabIndex = 2
            Me.RadioButtonForm_All.Text = "All"
            '
            'CheckBoxForm_ShowOnlyAccessibleModules
            '
            Me.CheckBoxForm_ShowOnlyAccessibleModules.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxForm_ShowOnlyAccessibleModules.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_ShowOnlyAccessibleModules.CheckValue = 0
            Me.CheckBoxForm_ShowOnlyAccessibleModules.CheckValueChecked = 1
            Me.CheckBoxForm_ShowOnlyAccessibleModules.CheckValueUnchecked = 0
            Me.CheckBoxForm_ShowOnlyAccessibleModules.ChildControls = CType(resources.GetObject("CheckBoxForm_ShowOnlyAccessibleModules.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_ShowOnlyAccessibleModules.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_ShowOnlyAccessibleModules.Location = New System.Drawing.Point(493, 12)
            Me.CheckBoxForm_ShowOnlyAccessibleModules.Name = "CheckBoxForm_ShowOnlyAccessibleModules"
            Me.CheckBoxForm_ShowOnlyAccessibleModules.OldestSibling = Nothing
            Me.CheckBoxForm_ShowOnlyAccessibleModules.SecurityEnabled = True
            Me.CheckBoxForm_ShowOnlyAccessibleModules.SiblingControls = CType(resources.GetObject("CheckBoxForm_ShowOnlyAccessibleModules.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_ShowOnlyAccessibleModules.Size = New System.Drawing.Size(178, 20)
            Me.CheckBoxForm_ShowOnlyAccessibleModules.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_ShowOnlyAccessibleModules.TabIndex = 4
            Me.CheckBoxForm_ShowOnlyAccessibleModules.Text = "Show Only Accessible Modules"
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(162, 170)
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(358, 98)
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
            Me.RibbonBarMergeContainerForm_Options.TabIndex = 6
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerReport_ReportCategory, Me.ButtonItemActions_ViewReport})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(255, 98)
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
            'ItemContainerReport_ReportCategory
            '
            '
            '
            '
            Me.ItemContainerReport_ReportCategory.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerReport_ReportCategory.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerReport_ReportCategory.Name = "ItemContainerReport_ReportCategory"
            Me.ItemContainerReport_ReportCategory.ResizeItemsToFit = False
            Me.ItemContainerReport_ReportCategory.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ComboBoxItemReportType_Report})
            '
            '
            '
            Me.ItemContainerReport_ReportCategory.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerReport_ReportCategory.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ComboBoxItemReportType_Report
            '
            Me.ComboBoxItemReportType_Report.ComboWidth = 150
            Me.ComboBoxItemReportType_Report.DropDownHeight = 106
            Me.ComboBoxItemReportType_Report.Name = "ComboBoxItemReportType_Report"
            Me.ComboBoxItemReportType_Report.PreventEnterBeep = False
            Me.ComboBoxItemReportType_Report.Stretch = True
            Me.ComboBoxItemReportType_Report.WatermarkFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ComboBoxItemReportType_Report.WatermarkText = "Select Report"
            '
            'ButtonItemActions_ViewReport
            '
            Me.ButtonItemActions_ViewReport.BeginGroup = True
            Me.ButtonItemActions_ViewReport.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_ViewReport.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_ViewReport.Name = "ButtonItemActions_ViewReport"
            Me.ButtonItemActions_ViewReport.RibbonWordWrap = False
            Me.ButtonItemActions_ViewReport.SubItemsExpandWidth = 14
            Me.ButtonItemActions_ViewReport.Text = "View Report"
            '
            'ReportSelectionForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(683, 438)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.CheckBoxForm_ShowOnlyAccessibleModules)
            Me.Controls.Add(Me.RadioButtonForm_Select)
            Me.Controls.Add(Me.RadioButtonForm_All)
            Me.Controls.Add(Me.DataGridViewForm_Selection)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "ReportSelectionForm"
            Me.Text = "Security Reports"
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewForm_Selection As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RadioButtonForm_Select As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonForm_All As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents CheckBoxForm_ShowOnlyAccessibleModules As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ItemContainerReport_ReportCategory As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ComboBoxItemReportType_Report As DevComponents.DotNetBar.ComboBoxItem
        Friend WithEvents ButtonItemActions_ViewReport As DevComponents.DotNetBar.ButtonItem

    End Class

End Namespace