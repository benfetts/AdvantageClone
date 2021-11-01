Namespace GeneralLedger.ReportWriter.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class GeneralLedgerReportForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GeneralLedgerReportForm))
            Me.DataGridViewForm_GLReportTemplates = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Templates = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemTemplates_Add = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemTemplates_Delete = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemTemplates_Copy = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemTemplates_Export = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_View = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemTemplates_Import = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            Me.SuspendLayout()
            '
            'DataGridViewForm_GLReportTemplates
            '
            Me.DataGridViewForm_GLReportTemplates.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewForm_GLReportTemplates.AllowDragAndDrop = False
            Me.DataGridViewForm_GLReportTemplates.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_GLReportTemplates.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_GLReportTemplates.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_GLReportTemplates.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_GLReportTemplates.AutoFilterLookupColumns = False
            Me.DataGridViewForm_GLReportTemplates.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_GLReportTemplates.AutoUpdateViewCaption = True
            Me.DataGridViewForm_GLReportTemplates.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewForm_GLReportTemplates.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_GLReportTemplates.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_GLReportTemplates.ItemDescription = "General Ledger Report(s)"
            Me.DataGridViewForm_GLReportTemplates.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewForm_GLReportTemplates.MultiSelect = False
            Me.DataGridViewForm_GLReportTemplates.Name = "DataGridViewForm_GLReportTemplates"
            Me.DataGridViewForm_GLReportTemplates.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_GLReportTemplates.RunStandardValidation = True
            Me.DataGridViewForm_GLReportTemplates.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_GLReportTemplates.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_GLReportTemplates.Size = New System.Drawing.Size(864, 408)
            Me.DataGridViewForm_GLReportTemplates.TabIndex = 1
            Me.DataGridViewForm_GLReportTemplates.UseEmbeddedNavigator = False
            Me.DataGridViewForm_GLReportTemplates.ViewCaptionHeight = -1
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Templates)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(12, 167)
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(601, 98)
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
            'RibbonBarOptions_Templates
            '
            Me.RibbonBarOptions_Templates.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Templates.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Templates.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Templates.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Templates.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Templates.DragDropSupport = True
            Me.RibbonBarOptions_Templates.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemTemplates_Add, Me.ButtonItemTemplates_Delete, Me.ButtonItemTemplates_Copy, Me.ButtonItemTemplates_Export, Me.ButtonItemTemplates_Import})
            Me.RibbonBarOptions_Templates.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Templates.Location = New System.Drawing.Point(61, 0)
            Me.RibbonBarOptions_Templates.Name = "RibbonBarOptions_Templates"
            Me.RibbonBarOptions_Templates.SecurityEnabled = True
            Me.RibbonBarOptions_Templates.Size = New System.Drawing.Size(200, 98)
            Me.RibbonBarOptions_Templates.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Templates.TabIndex = 1
            Me.RibbonBarOptions_Templates.Text = "Templates"
            '
            '
            '
            Me.RibbonBarOptions_Templates.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Templates.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Templates.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemTemplates_Add
            '
            Me.ButtonItemTemplates_Add.BeginGroup = True
            Me.ButtonItemTemplates_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemTemplates_Add.Name = "ButtonItemTemplates_Add"
            Me.ButtonItemTemplates_Add.RibbonWordWrap = False
            Me.ButtonItemTemplates_Add.SubItemsExpandWidth = 14
            Me.ButtonItemTemplates_Add.Text = "Add"
            '
            'ButtonItemTemplates_Delete
            '
            Me.ButtonItemTemplates_Delete.BeginGroup = True
            Me.ButtonItemTemplates_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemTemplates_Delete.Name = "ButtonItemTemplates_Delete"
            Me.ButtonItemTemplates_Delete.RibbonWordWrap = False
            Me.ButtonItemTemplates_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemTemplates_Delete.Text = "Delete"
            '
            'ButtonItemTemplates_Copy
            '
            Me.ButtonItemTemplates_Copy.BeginGroup = True
            Me.ButtonItemTemplates_Copy.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemTemplates_Copy.Name = "ButtonItemTemplates_Copy"
            Me.ButtonItemTemplates_Copy.RibbonWordWrap = False
            Me.ButtonItemTemplates_Copy.SubItemsExpandWidth = 14
            Me.ButtonItemTemplates_Copy.Text = "Copy"
            '
            'ButtonItemTemplates_Export
            '
            Me.ButtonItemTemplates_Export.BeginGroup = True
            Me.ButtonItemTemplates_Export.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemTemplates_Export.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemTemplates_Export.Name = "ButtonItemTemplates_Export"
            Me.ButtonItemTemplates_Export.RibbonWordWrap = False
            Me.ButtonItemTemplates_Export.SubItemsExpandWidth = 14
            Me.ButtonItemTemplates_Export.Text = "Export"
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_View})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(61, 98)
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
            'ButtonItemTemplates_Import
            '
            Me.ButtonItemTemplates_Import.BeginGroup = True
            Me.ButtonItemTemplates_Import.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemTemplates_Import.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemTemplates_Import.Name = "ButtonItemTemplates_Import"
            Me.ButtonItemTemplates_Import.RibbonWordWrap = False
            Me.ButtonItemTemplates_Import.SubItemsExpandWidth = 14
            Me.ButtonItemTemplates_Import.Text = "Import"
            '
            'GeneralLedgerReportForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(888, 432)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.DataGridViewForm_GLReportTemplates)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "GeneralLedgerReportForm"
            Me.Text = "General Ledger Reports"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewForm_GLReportTemplates As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ButtonItemTemplates_Copy As DevComponents.DotNetBar.ButtonItem
        Private WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Private WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemActions_View As DevComponents.DotNetBar.ButtonItem
        Private WithEvents RibbonBarOptions_Templates As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemTemplates_Add As DevComponents.DotNetBar.ButtonItem
        Private WithEvents ButtonItemTemplates_Delete As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemTemplates_Export As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemTemplates_Import As DevComponents.DotNetBar.ButtonItem
    End Class

End Namespace