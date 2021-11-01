Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class PartnerAllocationControl
        Inherits AdvantageFramework.WinForm.Presentation.Controls.BaseControls.BaseUserControl

        'UserControl overrides dispose to clean up the component list.
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
            Me.PanelControl_TopSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.LabelTopSection_WarningMessage = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabControlControl_PartnerAllocation = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelAllocationTab_Allocation = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewAllocation_PartnerAllocation = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.NumericInputAllocation_ClientPercent = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelAllocation_ClientPercent = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemPartnerAllocation_AllocationTab = New DevComponents.DotNetBar.TabItem()
            Me.TabControlPanelMediaOrdersTab_MediaOrders = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewMediaOrders_MediaOrders = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemPartnerAllocation_MediaOrdersTab = New DevComponents.DotNetBar.TabItem()
            CType(Me.PanelControl_TopSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelControl_TopSection.SuspendLayout()
            CType(Me.TabControlControl_PartnerAllocation, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlControl_PartnerAllocation.SuspendLayout()
            Me.TabControlPanelAllocationTab_Allocation.SuspendLayout()
            CType(Me.NumericInputAllocation_ClientPercent.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelMediaOrdersTab_MediaOrders.SuspendLayout()
            Me.SuspendLayout()
            '
            'PanelControl_TopSection
            '
            Me.PanelControl_TopSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelControl_TopSection.Controls.Add(Me.LabelTopSection_WarningMessage)
            Me.PanelControl_TopSection.Dock = System.Windows.Forms.DockStyle.Top
            Me.PanelControl_TopSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelControl_TopSection.Name = "PanelControl_TopSection"
            Me.PanelControl_TopSection.Size = New System.Drawing.Size(603, 28)
            Me.PanelControl_TopSection.TabIndex = 0
            Me.PanelControl_TopSection.Visible = False
            '
            'LabelTopSection_WarningMessage
            '
            Me.LabelTopSection_WarningMessage.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTopSection_WarningMessage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTopSection_WarningMessage.ForeColor = System.Drawing.Color.Red
            Me.LabelTopSection_WarningMessage.Location = New System.Drawing.Point(4, 4)
            Me.LabelTopSection_WarningMessage.Name = "LabelTopSection_WarningMessage"
            Me.LabelTopSection_WarningMessage.Size = New System.Drawing.Size(594, 20)
            Me.LabelTopSection_WarningMessage.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTopSection_WarningMessage.TabIndex = 0
            Me.LabelTopSection_WarningMessage.Text = "Warning Message"
            '
            'TabControlControl_PartnerAllocation
            '
            Me.TabControlControl_PartnerAllocation.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer))
            Me.TabControlControl_PartnerAllocation.CanReorderTabs = False
            Me.TabControlControl_PartnerAllocation.Controls.Add(Me.TabControlPanelMediaOrdersTab_MediaOrders)
            Me.TabControlControl_PartnerAllocation.Controls.Add(Me.TabControlPanelAllocationTab_Allocation)
            Me.TabControlControl_PartnerAllocation.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlControl_PartnerAllocation.Location = New System.Drawing.Point(0, 28)
            Me.TabControlControl_PartnerAllocation.Name = "TabControlControl_PartnerAllocation"
            Me.TabControlControl_PartnerAllocation.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlControl_PartnerAllocation.SelectedTabIndex = 0
            Me.TabControlControl_PartnerAllocation.Size = New System.Drawing.Size(603, 401)
            Me.TabControlControl_PartnerAllocation.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlControl_PartnerAllocation.TabIndex = 1
            Me.TabControlControl_PartnerAllocation.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlControl_PartnerAllocation.Tabs.Add(Me.TabItemPartnerAllocation_AllocationTab)
            Me.TabControlControl_PartnerAllocation.Tabs.Add(Me.TabItemPartnerAllocation_MediaOrdersTab)
            Me.TabControlControl_PartnerAllocation.Text = "TabControl1"
            '
            'TabControlPanelAllocationTab_Allocation
            '
            Me.TabControlPanelAllocationTab_Allocation.Controls.Add(Me.DataGridViewAllocation_PartnerAllocation)
            Me.TabControlPanelAllocationTab_Allocation.Controls.Add(Me.NumericInputAllocation_ClientPercent)
            Me.TabControlPanelAllocationTab_Allocation.Controls.Add(Me.LabelAllocation_ClientPercent)
            Me.TabControlPanelAllocationTab_Allocation.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelAllocationTab_Allocation.Location = New System.Drawing.Point(0, 22)
            Me.TabControlPanelAllocationTab_Allocation.Name = "TabControlPanelAllocationTab_Allocation"
            Me.TabControlPanelAllocationTab_Allocation.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelAllocationTab_Allocation.Size = New System.Drawing.Size(603, 379)
            Me.TabControlPanelAllocationTab_Allocation.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(254, Byte), Integer))
            Me.TabControlPanelAllocationTab_Allocation.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(157, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(227, Byte), Integer))
            Me.TabControlPanelAllocationTab_Allocation.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelAllocationTab_Allocation.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelAllocationTab_Allocation.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelAllocationTab_Allocation.Style.GradientAngle = 90
            Me.TabControlPanelAllocationTab_Allocation.TabIndex = 1
            Me.TabControlPanelAllocationTab_Allocation.TabItem = Me.TabItemPartnerAllocation_AllocationTab
            '
            'DataGridViewAllocation_PartnerAllocation
            '
            Me.DataGridViewAllocation_PartnerAllocation.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewAllocation_PartnerAllocation.AutoFilterLookupColumns = False
            Me.DataGridViewAllocation_PartnerAllocation.AutoloadRepositoryDatasource = True
            Me.DataGridViewAllocation_PartnerAllocation.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewAllocation_PartnerAllocation.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewAllocation_PartnerAllocation.ItemDescription = ""
            Me.DataGridViewAllocation_PartnerAllocation.Location = New System.Drawing.Point(4, 30)
            Me.DataGridViewAllocation_PartnerAllocation.MultiSelect = True
            Me.DataGridViewAllocation_PartnerAllocation.Name = "DataGridViewAllocation_PartnerAllocation"
            Me.DataGridViewAllocation_PartnerAllocation.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewAllocation_PartnerAllocation.ShowSelectDeselectAllButtons = False
            Me.DataGridViewAllocation_PartnerAllocation.Size = New System.Drawing.Size(595, 345)
            Me.DataGridViewAllocation_PartnerAllocation.TabIndex = 2
            Me.DataGridViewAllocation_PartnerAllocation.UseEmbeddedNavigator = False
            Me.DataGridViewAllocation_PartnerAllocation.ViewCaptionHeight = -1
            '
            'NumericInputAllocation_ClientPercent
            '
            Me.NumericInputAllocation_ClientPercent.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputAllocation_ClientPercent.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputAllocation_ClientPercent.Location = New System.Drawing.Point(89, 4)
            Me.NumericInputAllocation_ClientPercent.Name = "NumericInputAllocation_ClientPercent"
            Me.NumericInputAllocation_ClientPercent.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputAllocation_ClientPercent.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputAllocation_ClientPercent.Properties.EditFormat.FormatString = "f"
            Me.NumericInputAllocation_ClientPercent.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputAllocation_ClientPercent.Properties.Mask.EditMask = "f"
            Me.NumericInputAllocation_ClientPercent.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputAllocation_ClientPercent.Size = New System.Drawing.Size(89, 20)
            Me.NumericInputAllocation_ClientPercent.TabIndex = 1
            '
            'LabelAllocation_ClientPercent
            '
            Me.LabelAllocation_ClientPercent.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAllocation_ClientPercent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAllocation_ClientPercent.Location = New System.Drawing.Point(4, 4)
            Me.LabelAllocation_ClientPercent.Name = "LabelAllocation_ClientPercent"
            Me.LabelAllocation_ClientPercent.Size = New System.Drawing.Size(79, 20)
            Me.LabelAllocation_ClientPercent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAllocation_ClientPercent.TabIndex = 0
            Me.LabelAllocation_ClientPercent.Text = "Client Percent:"
            '
            'TabItemPartnerAllocation_AllocationTab
            '
            Me.TabItemPartnerAllocation_AllocationTab.AttachedControl = Me.TabControlPanelAllocationTab_Allocation
            Me.TabItemPartnerAllocation_AllocationTab.Name = "TabItemPartnerAllocation_AllocationTab"
            Me.TabItemPartnerAllocation_AllocationTab.Text = "Allocation"
            '
            'TabControlPanelMediaOrdersTab_MediaOrders
            '
            Me.TabControlPanelMediaOrdersTab_MediaOrders.Controls.Add(Me.DataGridViewMediaOrders_MediaOrders)
            Me.TabControlPanelMediaOrdersTab_MediaOrders.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelMediaOrdersTab_MediaOrders.Location = New System.Drawing.Point(0, 22)
            Me.TabControlPanelMediaOrdersTab_MediaOrders.Name = "TabControlPanelMediaOrdersTab_MediaOrders"
            Me.TabControlPanelMediaOrdersTab_MediaOrders.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelMediaOrdersTab_MediaOrders.Size = New System.Drawing.Size(603, 379)
            Me.TabControlPanelMediaOrdersTab_MediaOrders.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(254, Byte), Integer))
            Me.TabControlPanelMediaOrdersTab_MediaOrders.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(157, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(227, Byte), Integer))
            Me.TabControlPanelMediaOrdersTab_MediaOrders.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelMediaOrdersTab_MediaOrders.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelMediaOrdersTab_MediaOrders.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelMediaOrdersTab_MediaOrders.Style.GradientAngle = 90
            Me.TabControlPanelMediaOrdersTab_MediaOrders.TabIndex = 2
            Me.TabControlPanelMediaOrdersTab_MediaOrders.TabItem = Me.TabItemPartnerAllocation_MediaOrdersTab
            '
            'DataGridViewMediaOrders_MediaOrders
            '
            Me.DataGridViewMediaOrders_MediaOrders.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewMediaOrders_MediaOrders.AutoFilterLookupColumns = False
            Me.DataGridViewMediaOrders_MediaOrders.AutoloadRepositoryDatasource = True
            Me.DataGridViewMediaOrders_MediaOrders.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewMediaOrders_MediaOrders.DataSource = Nothing
            Me.DataGridViewMediaOrders_MediaOrders.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewMediaOrders_MediaOrders.ItemDescription = ""
            Me.DataGridViewMediaOrders_MediaOrders.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewMediaOrders_MediaOrders.MultiSelect = True
            Me.DataGridViewMediaOrders_MediaOrders.Name = "DataGridViewMediaOrders_MediaOrders"
            Me.DataGridViewMediaOrders_MediaOrders.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewMediaOrders_MediaOrders.ShowSelectDeselectAllButtons = False
            Me.DataGridViewMediaOrders_MediaOrders.Size = New System.Drawing.Size(595, 371)
            Me.DataGridViewMediaOrders_MediaOrders.TabIndex = 3
            Me.DataGridViewMediaOrders_MediaOrders.UseEmbeddedNavigator = False
            Me.DataGridViewMediaOrders_MediaOrders.ViewCaptionHeight = -1
            '
            'TabItemPartnerAllocation_MediaOrdersTab
            '
            Me.TabItemPartnerAllocation_MediaOrdersTab.AttachedControl = Me.TabControlPanelMediaOrdersTab_MediaOrders
            Me.TabItemPartnerAllocation_MediaOrdersTab.Name = "TabItemPartnerAllocation_MediaOrdersTab"
            Me.TabItemPartnerAllocation_MediaOrdersTab.Text = "Media Orders"
            '
            'PartnerAllocationControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.TabControlControl_PartnerAllocation)
            Me.Controls.Add(Me.PanelControl_TopSection)
            Me.Name = "PartnerAllocationControl"
            Me.Size = New System.Drawing.Size(603, 429)
            CType(Me.PanelControl_TopSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelControl_TopSection.ResumeLayout(False)
            CType(Me.TabControlControl_PartnerAllocation, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlControl_PartnerAllocation.ResumeLayout(False)
            Me.TabControlPanelAllocationTab_Allocation.ResumeLayout(False)
            CType(Me.NumericInputAllocation_ClientPercent.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelMediaOrdersTab_MediaOrders.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents PanelControl_TopSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents LabelTopSection_WarningMessage As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TabControlControl_PartnerAllocation As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelAllocationTab_Allocation As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewAllocation_PartnerAllocation As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents NumericInputAllocation_ClientPercent As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents LabelAllocation_ClientPercent As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TabItemPartnerAllocation_AllocationTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelMediaOrdersTab_MediaOrders As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewMediaOrders_MediaOrders As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TabItemPartnerAllocation_MediaOrdersTab As DevComponents.DotNetBar.TabItem

    End Class

End Namespace
