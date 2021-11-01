Namespace FinanceAndAccounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class RevenueResourcePlanResourceSetupForm
        Inherits AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseForm

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
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
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RevenueResourcePlanResourceSetupForm))
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Dashboard = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemDashboard_Edit = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_Resource = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemResource_ViewDetails = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Add = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Delete = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Refresh = New DevComponents.DotNetBar.ButtonItem()
            Me.ToolTipController = New DevExpress.Utils.ToolTipController(Me.components)
            Me.DataGridViewForm_Clients = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.DashboardViewerForm_Dashboard = New AdvantageFramework.WinForm.Presentation.Controls.DashboardViewerControl()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            CType(Me.DashboardViewerForm_Dashboard, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Dashboard)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Resource)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(40, 12)
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(782, 98)
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
            'RibbonBarOptions_Dashboard
            '
            Me.RibbonBarOptions_Dashboard.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Dashboard.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Dashboard.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Dashboard.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Dashboard.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Dashboard.DragDropSupport = True
            Me.RibbonBarOptions_Dashboard.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_Dashboard.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemDashboard_Edit})
            Me.RibbonBarOptions_Dashboard.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Dashboard.Location = New System.Drawing.Point(257, 0)
            Me.RibbonBarOptions_Dashboard.MinimumSize = New System.Drawing.Size(65, 0)
            Me.RibbonBarOptions_Dashboard.Name = "RibbonBarOptions_Dashboard"
            Me.RibbonBarOptions_Dashboard.SecurityEnabled = True
            Me.RibbonBarOptions_Dashboard.Size = New System.Drawing.Size(81, 98)
            Me.RibbonBarOptions_Dashboard.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Dashboard.TabIndex = 4
            Me.RibbonBarOptions_Dashboard.Text = "Dashboard"
            '
            '
            '
            Me.RibbonBarOptions_Dashboard.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Dashboard.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Dashboard.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemDashboard_Edit
            '
            Me.ButtonItemDashboard_Edit.BeginGroup = True
            Me.ButtonItemDashboard_Edit.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemDashboard_Edit.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDashboard_Edit.Name = "ButtonItemDashboard_Edit"
            Me.ButtonItemDashboard_Edit.RibbonWordWrap = False
            Me.ButtonItemDashboard_Edit.SubItemsExpandWidth = 14
            Me.ButtonItemDashboard_Edit.Text = "Edit"
            '
            'RibbonBarOptions_Resource
            '
            Me.RibbonBarOptions_Resource.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Resource.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Resource.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Resource.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Resource.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Resource.DragDropSupport = True
            Me.RibbonBarOptions_Resource.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemResource_ViewDetails})
            Me.RibbonBarOptions_Resource.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Resource.Location = New System.Drawing.Point(133, 0)
            Me.RibbonBarOptions_Resource.Name = "RibbonBarOptions_Resource"
            Me.RibbonBarOptions_Resource.SecurityEnabled = True
            Me.RibbonBarOptions_Resource.Size = New System.Drawing.Size(124, 98)
            Me.RibbonBarOptions_Resource.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Resource.TabIndex = 5
            Me.RibbonBarOptions_Resource.Text = "Resource"
            '
            '
            '
            Me.RibbonBarOptions_Resource.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Resource.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Resource.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemResource_ViewDetails
            '
            Me.ButtonItemResource_ViewDetails.BeginGroup = True
            Me.ButtonItemResource_ViewDetails.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemResource_ViewDetails.Name = "ButtonItemResource_ViewDetails"
            Me.ButtonItemResource_ViewDetails.RibbonWordWrap = False
            Me.ButtonItemResource_ViewDetails.SubItemsExpandWidth = 14
            Me.ButtonItemResource_ViewDetails.Text = "View Details"
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Add, Me.ButtonItemActions_Delete, Me.ButtonItemActions_Refresh})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(133, 98)
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
            'ButtonItemActions_Add
            '
            Me.ButtonItemActions_Add.BeginGroup = True
            Me.ButtonItemActions_Add.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Add.Name = "ButtonItemActions_Add"
            Me.ButtonItemActions_Add.RibbonWordWrap = False
            Me.ButtonItemActions_Add.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Add.Text = "Add"
            '
            'ButtonItemActions_Delete
            '
            Me.ButtonItemActions_Delete.BeginGroup = True
            Me.ButtonItemActions_Delete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Delete.Name = "ButtonItemActions_Delete"
            Me.ButtonItemActions_Delete.RibbonWordWrap = False
            Me.ButtonItemActions_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Delete.Text = "Delete"
            '
            'ButtonItemActions_Refresh
            '
            Me.ButtonItemActions_Refresh.BeginGroup = True
            Me.ButtonItemActions_Refresh.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Refresh.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Refresh.Name = "ButtonItemActions_Refresh"
            Me.ButtonItemActions_Refresh.RibbonWordWrap = False
            Me.ButtonItemActions_Refresh.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Refresh.Text = "Refresh"
            '
            'DataGridViewForm_Clients
            '
            Me.DataGridViewForm_Clients.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_Clients.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_Clients.AutoUpdateViewCaption = True
            Me.DataGridViewForm_Clients.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_Clients.ItemDescription = "Client(s)"
            Me.DataGridViewForm_Clients.Location = New System.Drawing.Point(14, 14)
            Me.DataGridViewForm_Clients.Margin = New System.Windows.Forms.Padding(5)
            Me.DataGridViewForm_Clients.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewForm_Clients.ModifyGridRowHeight = False
            Me.DataGridViewForm_Clients.MultiSelect = False
            Me.DataGridViewForm_Clients.Name = "DataGridViewForm_Clients"
            Me.DataGridViewForm_Clients.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_Clients.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewForm_Clients.ShowRowSelectionIfHidden = True
            Me.DataGridViewForm_Clients.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_Clients.Size = New System.Drawing.Size(808, 276)
            Me.DataGridViewForm_Clients.TabIndex = 6
            Me.DataGridViewForm_Clients.UseEmbeddedNavigator = False
            Me.DataGridViewForm_Clients.ViewCaptionHeight = -1
            '
            'DashboardViewerForm_Dashboard
            '
            Me.DashboardViewerForm_Dashboard.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DashboardViewerForm_Dashboard.Location = New System.Drawing.Point(14, 298)
            Me.DashboardViewerForm_Dashboard.Name = "DashboardViewerForm_Dashboard"
            Me.DashboardViewerForm_Dashboard.PdfExportOptions.DashboardStatePosition = DevExpress.DashboardCommon.DashboardStateExportPosition.SeparatePage
            Me.DashboardViewerForm_Dashboard.PrintPreviewOptions.DashboardStatePosition = DevExpress.DashboardCommon.DashboardStateExportPosition.SeparatePage
            Me.DashboardViewerForm_Dashboard.Size = New System.Drawing.Size(808, 232)
            Me.DashboardViewerForm_Dashboard.TabIndex = 5
            '
            'RevenueResourcePlanResourceSetupForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(836, 542)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.DataGridViewForm_Clients)
            Me.Controls.Add(Me.DashboardViewerForm_Dashboard)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(4)
            Me.Name = "RevenueResourcePlanResourceSetupForm"
            Me.Text = "Resource Plan"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            CType(Me.DashboardViewerForm_Dashboard, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Add As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Delete As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Refresh As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_Dashboard As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemDashboard_Edit As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ToolTipController As DevExpress.Utils.ToolTipController
        Friend WithEvents DataGridViewForm_Clients As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents DashboardViewerForm_Dashboard As WinForm.Presentation.Controls.DashboardViewerControl
        Friend WithEvents RibbonBarOptions_Resource As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemResource_ViewDetails As DevComponents.DotNetBar.ButtonItem
    End Class

End Namespace