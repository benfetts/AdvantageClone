Namespace Security.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ReportSelectionSetupForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportSelectionSetupForm))
            Me.DataGridViewInvoiceFormats_InvoiceFormats = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabControlForm_Reports = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelReportFormatsTab_ReportFormats = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewReportFormats_ReportFormats = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemReports_ReportFormatsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelMediaOrderFormatsTab_MediaOrderFormats = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewMediaOrderFormats_MediaOrderFormats = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemReports_MediaOrderFormatsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelInvoiceFormatsTab_InvoiceFormats = New DevComponents.DotNetBar.TabControlPanel()
            Me.TabItemReports_InvoiceFormatsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            CType(Me.TabControlForm_Reports, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlForm_Reports.SuspendLayout()
            Me.TabControlPanelReportFormatsTab_ReportFormats.SuspendLayout()
            Me.TabControlPanelMediaOrderFormatsTab_MediaOrderFormats.SuspendLayout()
            Me.TabControlPanelInvoiceFormatsTab_InvoiceFormats.SuspendLayout()
            Me.SuspendLayout()
            '
            'DataGridViewInvoiceFormats_InvoiceFormats
            '
            Me.DataGridViewInvoiceFormats_InvoiceFormats.AllowSelectGroupHeaderRow = True
            Me.DataGridViewInvoiceFormats_InvoiceFormats.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewInvoiceFormats_InvoiceFormats.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewInvoiceFormats_InvoiceFormats.AutoFilterLookupColumns = False
            Me.DataGridViewInvoiceFormats_InvoiceFormats.AutoloadRepositoryDatasource = True
            Me.DataGridViewInvoiceFormats_InvoiceFormats.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewInvoiceFormats_InvoiceFormats.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewInvoiceFormats_InvoiceFormats.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewInvoiceFormats_InvoiceFormats.ItemDescription = "Invoice Report(s)"
            Me.DataGridViewInvoiceFormats_InvoiceFormats.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewInvoiceFormats_InvoiceFormats.MultiSelect = True
            Me.DataGridViewInvoiceFormats_InvoiceFormats.Name = "DataGridViewInvoiceFormats_InvoiceFormats"
            Me.DataGridViewInvoiceFormats_InvoiceFormats.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewInvoiceFormats_InvoiceFormats.RunStandardValidation = True
            Me.DataGridViewInvoiceFormats_InvoiceFormats.ShowSelectDeselectAllButtons = False
            Me.DataGridViewInvoiceFormats_InvoiceFormats.Size = New System.Drawing.Size(681, 362)
            Me.DataGridViewInvoiceFormats_InvoiceFormats.TabIndex = 4
            Me.DataGridViewInvoiceFormats_InvoiceFormats.UseEmbeddedNavigator = False
            Me.DataGridViewInvoiceFormats_InvoiceFormats.ViewCaptionHeight = -1
            '
            'TabControlForm_Reports
            '
            Me.TabControlForm_Reports.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlForm_Reports.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(247, Byte), Integer))
            Me.TabControlForm_Reports.CanReorderTabs = True
            Me.TabControlForm_Reports.Controls.Add(Me.TabControlPanelMediaOrderFormatsTab_MediaOrderFormats)
            Me.TabControlForm_Reports.Controls.Add(Me.TabControlPanelInvoiceFormatsTab_InvoiceFormats)
            Me.TabControlForm_Reports.Controls.Add(Me.TabControlPanelReportFormatsTab_ReportFormats)
            Me.TabControlForm_Reports.Location = New System.Drawing.Point(12, 12)
            Me.TabControlForm_Reports.Name = "TabControlForm_Reports"
            Me.TabControlForm_Reports.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlForm_Reports.SelectedTabIndex = 0
            Me.TabControlForm_Reports.Size = New System.Drawing.Size(689, 397)
            Me.TabControlForm_Reports.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlForm_Reports.TabIndex = 5
            Me.TabControlForm_Reports.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlForm_Reports.Tabs.Add(Me.TabItemReports_InvoiceFormatsTab)
            Me.TabControlForm_Reports.Tabs.Add(Me.TabItemReports_MediaOrderFormatsTab)
            Me.TabControlForm_Reports.Tabs.Add(Me.TabItemReports_ReportFormatsTab)
            Me.TabControlForm_Reports.Text = "TabControl1"
            '
            'TabControlPanelReportFormatsTab_ReportFormats
            '
            Me.TabControlPanelReportFormatsTab_ReportFormats.Controls.Add(Me.DataGridViewReportFormats_ReportFormats)
            Me.TabControlPanelReportFormatsTab_ReportFormats.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelReportFormatsTab_ReportFormats.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelReportFormatsTab_ReportFormats.Name = "TabControlPanelReportFormatsTab_ReportFormats"
            Me.TabControlPanelReportFormatsTab_ReportFormats.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelReportFormatsTab_ReportFormats.Size = New System.Drawing.Size(689, 370)
            Me.TabControlPanelReportFormatsTab_ReportFormats.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelReportFormatsTab_ReportFormats.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelReportFormatsTab_ReportFormats.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelReportFormatsTab_ReportFormats.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelReportFormatsTab_ReportFormats.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelReportFormatsTab_ReportFormats.Style.GradientAngle = 90
            Me.TabControlPanelReportFormatsTab_ReportFormats.TabIndex = 3
            Me.TabControlPanelReportFormatsTab_ReportFormats.TabItem = Me.TabItemReports_ReportFormatsTab
            '
            'DataGridViewReportFormats_ReportFormats
            '
            Me.DataGridViewReportFormats_ReportFormats.AllowSelectGroupHeaderRow = True
            Me.DataGridViewReportFormats_ReportFormats.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewReportFormats_ReportFormats.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewReportFormats_ReportFormats.AutoFilterLookupColumns = False
            Me.DataGridViewReportFormats_ReportFormats.AutoloadRepositoryDatasource = True
            Me.DataGridViewReportFormats_ReportFormats.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewReportFormats_ReportFormats.DataSource = Nothing
            Me.DataGridViewReportFormats_ReportFormats.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewReportFormats_ReportFormats.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewReportFormats_ReportFormats.ItemDescription = ""
            Me.DataGridViewReportFormats_ReportFormats.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewReportFormats_ReportFormats.MultiSelect = True
            Me.DataGridViewReportFormats_ReportFormats.Name = "DataGridViewReportFormats_ReportFormats"
            Me.DataGridViewReportFormats_ReportFormats.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewReportFormats_ReportFormats.RunStandardValidation = True
            Me.DataGridViewReportFormats_ReportFormats.ShowSelectDeselectAllButtons = False
            Me.DataGridViewReportFormats_ReportFormats.Size = New System.Drawing.Size(681, 362)
            Me.DataGridViewReportFormats_ReportFormats.TabIndex = 5
            Me.DataGridViewReportFormats_ReportFormats.UseEmbeddedNavigator = False
            Me.DataGridViewReportFormats_ReportFormats.ViewCaptionHeight = -1
            '
            'TabItemReports_ReportFormatsTab
            '
            Me.TabItemReports_ReportFormatsTab.AttachedControl = Me.TabControlPanelReportFormatsTab_ReportFormats
            Me.TabItemReports_ReportFormatsTab.Name = "TabItemReports_ReportFormatsTab"
            Me.TabItemReports_ReportFormatsTab.Text = "Report Formats"
            '
            'TabControlPanelMediaOrderFormatsTab_MediaOrderFormats
            '
            Me.TabControlPanelMediaOrderFormatsTab_MediaOrderFormats.Controls.Add(Me.DataGridViewMediaOrderFormats_MediaOrderFormats)
            Me.TabControlPanelMediaOrderFormatsTab_MediaOrderFormats.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelMediaOrderFormatsTab_MediaOrderFormats.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelMediaOrderFormatsTab_MediaOrderFormats.Name = "TabControlPanelMediaOrderFormatsTab_MediaOrderFormats"
            Me.TabControlPanelMediaOrderFormatsTab_MediaOrderFormats.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelMediaOrderFormatsTab_MediaOrderFormats.Size = New System.Drawing.Size(689, 370)
            Me.TabControlPanelMediaOrderFormatsTab_MediaOrderFormats.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelMediaOrderFormatsTab_MediaOrderFormats.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelMediaOrderFormatsTab_MediaOrderFormats.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelMediaOrderFormatsTab_MediaOrderFormats.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelMediaOrderFormatsTab_MediaOrderFormats.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelMediaOrderFormatsTab_MediaOrderFormats.Style.GradientAngle = 90
            Me.TabControlPanelMediaOrderFormatsTab_MediaOrderFormats.TabIndex = 2
            Me.TabControlPanelMediaOrderFormatsTab_MediaOrderFormats.TabItem = Me.TabItemReports_MediaOrderFormatsTab
            '
            'DataGridViewMediaOrderFormats_MediaOrderFormats
            '
            Me.DataGridViewMediaOrderFormats_MediaOrderFormats.AllowSelectGroupHeaderRow = True
            Me.DataGridViewMediaOrderFormats_MediaOrderFormats.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewMediaOrderFormats_MediaOrderFormats.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewMediaOrderFormats_MediaOrderFormats.AutoFilterLookupColumns = False
            Me.DataGridViewMediaOrderFormats_MediaOrderFormats.AutoloadRepositoryDatasource = True
            Me.DataGridViewMediaOrderFormats_MediaOrderFormats.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewMediaOrderFormats_MediaOrderFormats.DataSource = Nothing
            Me.DataGridViewMediaOrderFormats_MediaOrderFormats.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewMediaOrderFormats_MediaOrderFormats.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewMediaOrderFormats_MediaOrderFormats.ItemDescription = "Media Order Report(s)"
            Me.DataGridViewMediaOrderFormats_MediaOrderFormats.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewMediaOrderFormats_MediaOrderFormats.MultiSelect = True
            Me.DataGridViewMediaOrderFormats_MediaOrderFormats.Name = "DataGridViewMediaOrderFormats_MediaOrderFormats"
            Me.DataGridViewMediaOrderFormats_MediaOrderFormats.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewMediaOrderFormats_MediaOrderFormats.RunStandardValidation = True
            Me.DataGridViewMediaOrderFormats_MediaOrderFormats.ShowSelectDeselectAllButtons = False
            Me.DataGridViewMediaOrderFormats_MediaOrderFormats.Size = New System.Drawing.Size(681, 362)
            Me.DataGridViewMediaOrderFormats_MediaOrderFormats.TabIndex = 5
            Me.DataGridViewMediaOrderFormats_MediaOrderFormats.UseEmbeddedNavigator = False
            Me.DataGridViewMediaOrderFormats_MediaOrderFormats.ViewCaptionHeight = -1
            '
            'TabItemReports_MediaOrderFormatsTab
            '
            Me.TabItemReports_MediaOrderFormatsTab.AttachedControl = Me.TabControlPanelMediaOrderFormatsTab_MediaOrderFormats
            Me.TabItemReports_MediaOrderFormatsTab.Name = "TabItemReports_MediaOrderFormatsTab"
            Me.TabItemReports_MediaOrderFormatsTab.Text = "Media Order Formats"
            '
            'TabControlPanelInvoiceFormatsTab_InvoiceFormats
            '
            Me.TabControlPanelInvoiceFormatsTab_InvoiceFormats.Controls.Add(Me.DataGridViewInvoiceFormats_InvoiceFormats)
            Me.TabControlPanelInvoiceFormatsTab_InvoiceFormats.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelInvoiceFormatsTab_InvoiceFormats.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelInvoiceFormatsTab_InvoiceFormats.Name = "TabControlPanelInvoiceFormatsTab_InvoiceFormats"
            Me.TabControlPanelInvoiceFormatsTab_InvoiceFormats.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelInvoiceFormatsTab_InvoiceFormats.Size = New System.Drawing.Size(689, 370)
            Me.TabControlPanelInvoiceFormatsTab_InvoiceFormats.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelInvoiceFormatsTab_InvoiceFormats.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelInvoiceFormatsTab_InvoiceFormats.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelInvoiceFormatsTab_InvoiceFormats.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelInvoiceFormatsTab_InvoiceFormats.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelInvoiceFormatsTab_InvoiceFormats.Style.GradientAngle = 90
            Me.TabControlPanelInvoiceFormatsTab_InvoiceFormats.TabIndex = 1
            Me.TabControlPanelInvoiceFormatsTab_InvoiceFormats.TabItem = Me.TabItemReports_InvoiceFormatsTab
            '
            'TabItemReports_InvoiceFormatsTab
            '
            Me.TabItemReports_InvoiceFormatsTab.AttachedControl = Me.TabControlPanelInvoiceFormatsTab_InvoiceFormats
            Me.TabItemReports_InvoiceFormatsTab.Name = "TabItemReports_InvoiceFormatsTab"
            Me.TabItemReports_InvoiceFormatsTab.Text = "Invoice Formats"
            '
            'ReportSelectionSetupForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(713, 421)
            Me.Controls.Add(Me.TabControlForm_Reports)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "ReportSelectionSetupForm"
            Me.Text = "Report Selection Maintenance"
            CType(Me.TabControlForm_Reports, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlForm_Reports.ResumeLayout(False)
            Me.TabControlPanelReportFormatsTab_ReportFormats.ResumeLayout(False)
            Me.TabControlPanelMediaOrderFormatsTab_MediaOrderFormats.ResumeLayout(False)
            Me.TabControlPanelInvoiceFormatsTab_InvoiceFormats.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewInvoiceFormats_InvoiceFormats As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TabControlForm_Reports As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelInvoiceFormatsTab_InvoiceFormats As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemReports_InvoiceFormatsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelMediaOrderFormatsTab_MediaOrderFormats As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemReports_MediaOrderFormatsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelReportFormatsTab_ReportFormats As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemReports_ReportFormatsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents DataGridViewMediaOrderFormats_MediaOrderFormats As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents DataGridViewReportFormats_ReportFormats As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
    End Class

End Namespace

