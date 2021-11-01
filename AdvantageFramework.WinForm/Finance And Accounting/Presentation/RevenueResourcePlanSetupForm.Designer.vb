Namespace FinanceAndAccounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class RevenueResourcePlanSetupForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RevenueResourcePlanSetupForm))
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Dashboard = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemDashboard_Edit = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Add = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Update = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Delete = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Copy = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Refresh = New DevComponents.DotNetBar.ButtonItem()
            Me.ToolTipController = New DevExpress.Utils.ToolTipController(Me.components)
            Me.DataGridViewForm_Plans = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.DashboardViewerForm_Dashboard = New AdvantageFramework.WinForm.Presentation.Controls.DashboardViewerControl()
            Me.RibbonBarOptions_Manage = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemManage_Resources = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemManage_Staff = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemManage_Revenue = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            CType(Me.DashboardViewerForm_Dashboard, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Dashboard)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Manage)
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
            Me.RibbonBarOptions_Dashboard.Location = New System.Drawing.Point(383, 0)
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Add, Me.ButtonItemActions_Update, Me.ButtonItemActions_Delete, Me.ButtonItemActions_Copy, Me.ButtonItemActions_Refresh})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(211, 98)
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
            'ButtonItemActions_Update
            '
            Me.ButtonItemActions_Update.BeginGroup = True
            Me.ButtonItemActions_Update.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Update.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Update.Name = "ButtonItemActions_Update"
            Me.ButtonItemActions_Update.RibbonWordWrap = False
            Me.ButtonItemActions_Update.SecurityEnabled = True
            Me.ButtonItemActions_Update.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Update.Text = "Update"
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
            'ButtonItemActions_Copy
            '
            Me.ButtonItemActions_Copy.BeginGroup = True
            Me.ButtonItemActions_Copy.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Copy.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Copy.Name = "ButtonItemActions_Copy"
            Me.ButtonItemActions_Copy.RibbonWordWrap = False
            Me.ButtonItemActions_Copy.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Copy.Text = "Copy"
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
            'DataGridViewForm_Plans
            '
            Me.DataGridViewForm_Plans.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_Plans.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_Plans.AutoUpdateViewCaption = True
            Me.DataGridViewForm_Plans.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_Plans.ItemDescription = "Plan(s)"
            Me.DataGridViewForm_Plans.Location = New System.Drawing.Point(14, 14)
            Me.DataGridViewForm_Plans.Margin = New System.Windows.Forms.Padding(5)
            Me.DataGridViewForm_Plans.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewForm_Plans.ModifyGridRowHeight = False
            Me.DataGridViewForm_Plans.MultiSelect = False
            Me.DataGridViewForm_Plans.Name = "DataGridViewForm_Plans"
            Me.DataGridViewForm_Plans.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_Plans.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewForm_Plans.ShowRowSelectionIfHidden = True
            Me.DataGridViewForm_Plans.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_Plans.Size = New System.Drawing.Size(808, 276)
            Me.DataGridViewForm_Plans.TabIndex = 6
            Me.DataGridViewForm_Plans.UseEmbeddedNavigator = False
            Me.DataGridViewForm_Plans.ViewCaptionHeight = -1
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
            'RibbonBarOptions_Manage
            '
            Me.RibbonBarOptions_Manage.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Manage.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Manage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Manage.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Manage.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Manage.DragDropSupport = True
            Me.RibbonBarOptions_Manage.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_Manage.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemManage_Staff, Me.ButtonItemManage_Revenue, Me.ButtonItemManage_Resources})
            Me.RibbonBarOptions_Manage.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Manage.Location = New System.Drawing.Point(211, 0)
            Me.RibbonBarOptions_Manage.MinimumSize = New System.Drawing.Size(65, 0)
            Me.RibbonBarOptions_Manage.Name = "RibbonBarOptions_Manage"
            Me.RibbonBarOptions_Manage.SecurityEnabled = True
            Me.RibbonBarOptions_Manage.Size = New System.Drawing.Size(172, 98)
            Me.RibbonBarOptions_Manage.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Manage.TabIndex = 7
            Me.RibbonBarOptions_Manage.Text = "Manage"
            '
            '
            '
            Me.RibbonBarOptions_Manage.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Manage.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Manage.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemManage_Resources
            '
            Me.ButtonItemManage_Resources.BeginGroup = True
            Me.ButtonItemManage_Resources.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemManage_Resources.Name = "ButtonItemManage_Resources"
            Me.ButtonItemManage_Resources.RibbonWordWrap = False
            Me.ButtonItemManage_Resources.SubItemsExpandWidth = 14
            Me.ButtonItemManage_Resources.Text = "Resources"
            '
            'ButtonItemManage_Staff
            '
            Me.ButtonItemManage_Staff.BeginGroup = True
            Me.ButtonItemManage_Staff.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemManage_Staff.Name = "ButtonItemManage_Staff"
            Me.ButtonItemManage_Staff.RibbonWordWrap = False
            Me.ButtonItemManage_Staff.SubItemsExpandWidth = 14
            Me.ButtonItemManage_Staff.Text = "Staff"
            '
            'ButtonItemManage_Revenue
            '
            Me.ButtonItemManage_Revenue.BeginGroup = True
            Me.ButtonItemManage_Revenue.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemManage_Revenue.Name = "ButtonItemManage_Revenue"
            Me.ButtonItemManage_Revenue.RibbonWordWrap = False
            Me.ButtonItemManage_Revenue.SubItemsExpandWidth = 14
            Me.ButtonItemManage_Revenue.Text = "Revenue"
            '
            'RevenueResourcePlanSetupForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(836, 542)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.DataGridViewForm_Plans)
            Me.Controls.Add(Me.DashboardViewerForm_Dashboard)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(4)
            Me.Name = "RevenueResourcePlanSetupForm"
            Me.Text = "Revenue & Resource Plans"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            CType(Me.DashboardViewerForm_Dashboard, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Add As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Delete As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Update As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Refresh As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_Dashboard As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemDashboard_Edit As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Copy As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ToolTipController As DevExpress.Utils.ToolTipController
        Friend WithEvents DataGridViewForm_Plans As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents DashboardViewerForm_Dashboard As WinForm.Presentation.Controls.DashboardViewerControl
        Friend WithEvents RibbonBarOptions_Manage As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemManage_Staff As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemManage_Revenue As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemManage_Resources As DevComponents.DotNetBar.ButtonItem
    End Class

End Namespace