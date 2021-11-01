Namespace Reporting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class MediaSpecificationReportsForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaSpecificationReportsForm))
            Me.DataGridViewForm_Reports = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_View = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Add = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_EditReport = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_UpdateInfo = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Delete = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Copy = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Refresh = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_ReportCategory = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ItemContainerReportCategory_ReportCategory = New DevComponents.DotNetBar.ItemContainer()
            Me.ComboBoxItemReportCategory_ReportCategory = New DevComponents.DotNetBar.ComboBoxItem()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            Me.SuspendLayout()
            '
            'DataGridViewForm_Reports
            '
            Me.DataGridViewForm_Reports.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewForm_Reports.AllowDragAndDrop = False
            Me.DataGridViewForm_Reports.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_Reports.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_Reports.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_Reports.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_Reports.AutoFilterLookupColumns = False
            Me.DataGridViewForm_Reports.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_Reports.AutoUpdateViewCaption = True
            Me.DataGridViewForm_Reports.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewForm_Reports.DataSource = Nothing
            Me.DataGridViewForm_Reports.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_Reports.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_Reports.ItemDescription = "Report(s)"
            Me.DataGridViewForm_Reports.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewForm_Reports.MultiSelect = False
            Me.DataGridViewForm_Reports.Name = "DataGridViewForm_Reports"
            Me.DataGridViewForm_Reports.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_Reports.RunStandardValidation = True
            Me.DataGridViewForm_Reports.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_Reports.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_Reports.Size = New System.Drawing.Size(676, 408)
            Me.DataGridViewForm_Reports.TabIndex = 1
            Me.DataGridViewForm_Reports.UseEmbeddedNavigator = False
            Me.DataGridViewForm_Reports.ViewCaptionHeight = -1
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_ReportCategory)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(12, 52)
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(676, 98)
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
            Me.RibbonBarMergeContainerForm_Options.TabIndex = 3
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
            Me.RibbonBarOptions_Actions.DragDropSupport = True
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_View, Me.ButtonItemActions_Add, Me.ButtonItemActions_EditReport, Me.ButtonItemActions_UpdateInfo, Me.ButtonItemActions_Delete, Me.ButtonItemActions_Copy, Me.ButtonItemActions_Refresh})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(211, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(367, 98)
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
            '
            'ButtonItemActions_View
            '
            Me.ButtonItemActions_View.BeginGroup = True
            Me.ButtonItemActions_View.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_View.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_View.Name = "ButtonItemActions_View"
            Me.ButtonItemActions_View.RibbonWordWrap = False
            Me.ButtonItemActions_View.SubItemsExpandWidth = 14
            Me.ButtonItemActions_View.Text = "View"
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
            'ButtonItemActions_EditReport
            '
            Me.ButtonItemActions_EditReport.BeginGroup = True
            Me.ButtonItemActions_EditReport.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_EditReport.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_EditReport.Name = "ButtonItemActions_EditReport"
            Me.ButtonItemActions_EditReport.RibbonWordWrap = False
            Me.ButtonItemActions_EditReport.SubItemsExpandWidth = 14
            Me.ButtonItemActions_EditReport.Text = "Edit Report"
            '
            'ButtonItemActions_UpdateInfo
            '
            Me.ButtonItemActions_UpdateInfo.BeginGroup = True
            Me.ButtonItemActions_UpdateInfo.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_UpdateInfo.Name = "ButtonItemActions_UpdateInfo"
            Me.ButtonItemActions_UpdateInfo.RibbonWordWrap = False
            Me.ButtonItemActions_UpdateInfo.SubItemsExpandWidth = 14
            Me.ButtonItemActions_UpdateInfo.Text = "Update Info"
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
            'ButtonItemActions_Copy
            '
            Me.ButtonItemActions_Copy.BeginGroup = True
            Me.ButtonItemActions_Copy.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Copy.Name = "ButtonItemActions_Copy"
            Me.ButtonItemActions_Copy.RibbonWordWrap = False
            Me.ButtonItemActions_Copy.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Copy.Text = "Copy"
            Me.ButtonItemActions_Copy.Visible = False
            '
            'ButtonItemActions_Refresh
            '
            Me.ButtonItemActions_Refresh.BeginGroup = True
            Me.ButtonItemActions_Refresh.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Refresh.Name = "ButtonItemActions_Refresh"
            Me.ButtonItemActions_Refresh.RibbonWordWrap = False
            Me.ButtonItemActions_Refresh.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Refresh.Text = "Refresh"
            '
            'RibbonBarOptions_ReportCategory
            '
            Me.RibbonBarOptions_ReportCategory.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_ReportCategory.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_ReportCategory.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_ReportCategory.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_ReportCategory.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_ReportCategory.DragDropSupport = True
            Me.RibbonBarOptions_ReportCategory.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_ReportCategory.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerReportCategory_ReportCategory})
            Me.RibbonBarOptions_ReportCategory.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_ReportCategory.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_ReportCategory.Name = "RibbonBarOptions_ReportCategory"
            Me.RibbonBarOptions_ReportCategory.SecurityEnabled = True
            Me.RibbonBarOptions_ReportCategory.Size = New System.Drawing.Size(211, 98)
            Me.RibbonBarOptions_ReportCategory.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_ReportCategory.TabIndex = 2
            Me.RibbonBarOptions_ReportCategory.Text = "Report Category"
            '
            '
            '
            Me.RibbonBarOptions_ReportCategory.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_ReportCategory.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_ReportCategory.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ItemContainerReportCategory_ReportCategory
            '
            '
            '
            '
            Me.ItemContainerReportCategory_ReportCategory.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerReportCategory_ReportCategory.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerReportCategory_ReportCategory.Name = "ItemContainerReportCategory_ReportCategory"
            Me.ItemContainerReportCategory_ReportCategory.ResizeItemsToFit = False
            Me.ItemContainerReportCategory_ReportCategory.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ComboBoxItemReportCategory_ReportCategory})
            '
            '
            '
            Me.ItemContainerReportCategory_ReportCategory.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerReportCategory_ReportCategory.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ComboBoxItemReportCategory_ReportCategory
            '
            Me.ComboBoxItemReportCategory_ReportCategory.ComboWidth = 200
            Me.ComboBoxItemReportCategory_ReportCategory.DisplayMember = "Value"
            Me.ComboBoxItemReportCategory_ReportCategory.DropDownHeight = 106
            Me.ComboBoxItemReportCategory_ReportCategory.Name = "ComboBoxItemReportCategory_ReportCategory"
            Me.ComboBoxItemReportCategory_ReportCategory.Stretch = True
            Me.ComboBoxItemReportCategory_ReportCategory.WatermarkFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ComboBoxItemReportCategory_ReportCategory.WatermarkText = "Select Report"
            '
            'MediaSpecificationReportsForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(700, 432)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.DataGridViewForm_Reports)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaSpecificationReportsForm"
            Me.Text = "Media Specification Reports"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewForm_Reports As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_View As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Copy As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Delete As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Add As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_ReportCategory As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ItemContainerReportCategory_ReportCategory As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ComboBoxItemReportCategory_ReportCategory As DevComponents.DotNetBar.ComboBoxItem
        Friend WithEvents ButtonItemActions_UpdateInfo As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_EditReport As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Refresh As DevComponents.DotNetBar.ButtonItem
    End Class

End Namespace