Namespace Billing.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class BillingCommandCenterOtherUsersSelectionsDialog
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BillingCommandCenterOtherUsersSelectionsDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.TabControlForm_BillingSelections = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelProduction_Details = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewProduction_Selections = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemBillingSelections_ProductionTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelMedia_Details = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewMedia_Selections = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemBillingSelections_MediaTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.ButtonForm_Delete = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            CType(Me.TabControlForm_BillingSelections, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlForm_BillingSelections.SuspendLayout()
            Me.TabControlPanelProduction_Details.SuspendLayout()
            Me.TabControlPanelMedia_Details.SuspendLayout()
            Me.SuspendLayout()
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(699, 406)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 1
            Me.ButtonForm_OK.Text = "OK"
            '
            'TabControlForm_BillingSelections
            '
            Me.TabControlForm_BillingSelections.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlForm_BillingSelections.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer))
            Me.TabControlForm_BillingSelections.CanReorderTabs = False
            Me.TabControlForm_BillingSelections.Controls.Add(Me.TabControlPanelProduction_Details)
            Me.TabControlForm_BillingSelections.Controls.Add(Me.TabControlPanelMedia_Details)
            Me.TabControlForm_BillingSelections.ForeColor = System.Drawing.Color.Black
            Me.TabControlForm_BillingSelections.Location = New System.Drawing.Point(12, 12)
            Me.TabControlForm_BillingSelections.Name = "TabControlForm_BillingSelections"
            Me.TabControlForm_BillingSelections.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlForm_BillingSelections.SelectedTabIndex = 0
            Me.TabControlForm_BillingSelections.Size = New System.Drawing.Size(762, 388)
            Me.TabControlForm_BillingSelections.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlForm_BillingSelections.TabIndex = 0
            Me.TabControlForm_BillingSelections.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlForm_BillingSelections.Tabs.Add(Me.TabItemBillingSelections_ProductionTab)
            Me.TabControlForm_BillingSelections.Tabs.Add(Me.TabItemBillingSelections_MediaTab)
            Me.TabControlForm_BillingSelections.TabStop = False
            '
            'TabControlPanelProduction_Details
            '
            Me.TabControlPanelProduction_Details.Controls.Add(Me.DataGridViewProduction_Selections)
            Me.TabControlPanelProduction_Details.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelProduction_Details.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelProduction_Details.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelProduction_Details.Name = "TabControlPanelProduction_Details"
            Me.TabControlPanelProduction_Details.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelProduction_Details.Size = New System.Drawing.Size(762, 361)
            Me.TabControlPanelProduction_Details.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelProduction_Details.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelProduction_Details.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelProduction_Details.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelProduction_Details.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelProduction_Details.Style.GradientAngle = 90
            Me.TabControlPanelProduction_Details.TabIndex = 0
            Me.TabControlPanelProduction_Details.TabItem = Me.TabItemBillingSelections_ProductionTab
            '
            'DataGridViewProduction_Selections
            '
            Me.DataGridViewProduction_Selections.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewProduction_Selections.AllowDragAndDrop = False
            Me.DataGridViewProduction_Selections.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewProduction_Selections.AllowSelectGroupHeaderRow = True
            Me.DataGridViewProduction_Selections.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewProduction_Selections.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewProduction_Selections.AutoFilterLookupColumns = False
            Me.DataGridViewProduction_Selections.AutoloadRepositoryDatasource = False
            Me.DataGridViewProduction_Selections.AutoUpdateViewCaption = True
            Me.DataGridViewProduction_Selections.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewProduction_Selections.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewProduction_Selections.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewProduction_Selections.ItemDescription = ""
            Me.DataGridViewProduction_Selections.Location = New System.Drawing.Point(5, 5)
            Me.DataGridViewProduction_Selections.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewProduction_Selections.MultiSelect = True
            Me.DataGridViewProduction_Selections.Name = "DataGridViewProduction_Selections"
            Me.DataGridViewProduction_Selections.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewProduction_Selections.RunStandardValidation = True
            Me.DataGridViewProduction_Selections.ShowColumnMenuOnRightClick = False
            Me.DataGridViewProduction_Selections.ShowSelectDeselectAllButtons = False
            Me.DataGridViewProduction_Selections.Size = New System.Drawing.Size(752, 351)
            Me.DataGridViewProduction_Selections.TabIndex = 0
            Me.DataGridViewProduction_Selections.UseEmbeddedNavigator = False
            Me.DataGridViewProduction_Selections.ViewCaptionHeight = -1
            '
            'TabItemBillingSelections_ProductionTab
            '
            Me.TabItemBillingSelections_ProductionTab.AttachedControl = Me.TabControlPanelProduction_Details
            Me.TabItemBillingSelections_ProductionTab.Name = "TabItemBillingSelections_ProductionTab"
            Me.TabItemBillingSelections_ProductionTab.Text = "Production"
            '
            'TabControlPanelMedia_Details
            '
            Me.TabControlPanelMedia_Details.Controls.Add(Me.DataGridViewMedia_Selections)
            Me.TabControlPanelMedia_Details.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelMedia_Details.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelMedia_Details.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelMedia_Details.Name = "TabControlPanelMedia_Details"
            Me.TabControlPanelMedia_Details.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelMedia_Details.Size = New System.Drawing.Size(762, 361)
            Me.TabControlPanelMedia_Details.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelMedia_Details.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelMedia_Details.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelMedia_Details.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelMedia_Details.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelMedia_Details.Style.GradientAngle = 90
            Me.TabControlPanelMedia_Details.TabIndex = 12
            Me.TabControlPanelMedia_Details.TabItem = Me.TabItemBillingSelections_MediaTab
            '
            'DataGridViewMedia_Selections
            '
            Me.DataGridViewMedia_Selections.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewMedia_Selections.AllowDragAndDrop = False
            Me.DataGridViewMedia_Selections.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewMedia_Selections.AllowSelectGroupHeaderRow = True
            Me.DataGridViewMedia_Selections.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewMedia_Selections.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewMedia_Selections.AutoFilterLookupColumns = False
            Me.DataGridViewMedia_Selections.AutoloadRepositoryDatasource = False
            Me.DataGridViewMedia_Selections.AutoUpdateViewCaption = True
            Me.DataGridViewMedia_Selections.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewMedia_Selections.DataSource = Nothing
            Me.DataGridViewMedia_Selections.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewMedia_Selections.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewMedia_Selections.ItemDescription = ""
            Me.DataGridViewMedia_Selections.Location = New System.Drawing.Point(5, 5)
            Me.DataGridViewMedia_Selections.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewMedia_Selections.MultiSelect = True
            Me.DataGridViewMedia_Selections.Name = "DataGridViewMedia_Selections"
            Me.DataGridViewMedia_Selections.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewMedia_Selections.RunStandardValidation = True
            Me.DataGridViewMedia_Selections.ShowColumnMenuOnRightClick = False
            Me.DataGridViewMedia_Selections.ShowSelectDeselectAllButtons = False
            Me.DataGridViewMedia_Selections.Size = New System.Drawing.Size(752, 351)
            Me.DataGridViewMedia_Selections.TabIndex = 7
            Me.DataGridViewMedia_Selections.UseEmbeddedNavigator = False
            Me.DataGridViewMedia_Selections.ViewCaptionHeight = -1
            '
            'TabItemBillingSelections_MediaTab
            '
            Me.TabItemBillingSelections_MediaTab.AttachedControl = Me.TabControlPanelMedia_Details
            Me.TabItemBillingSelections_MediaTab.Name = "TabItemBillingSelections_MediaTab"
            Me.TabItemBillingSelections_MediaTab.Text = "Media"
            '
            'ButtonForm_Delete
            '
            Me.ButtonForm_Delete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Delete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Delete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Delete.Location = New System.Drawing.Point(12, 406)
            Me.ButtonForm_Delete.Name = "ButtonForm_Delete"
            Me.ButtonForm_Delete.SecurityEnabled = True
            Me.ButtonForm_Delete.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Delete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Delete.TabIndex = 2
            Me.ButtonForm_Delete.Text = "Delete"
            '
            'BillingCommandCenterOtherUsersSelectionsDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(786, 438)
            Me.Controls.Add(Me.ButtonForm_Delete)
            Me.Controls.Add(Me.TabControlForm_BillingSelections)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "BillingCommandCenterOtherUsersSelectionsDialog"
            Me.Text = "Billing Selections By Other Users"
            CType(Me.TabControlForm_BillingSelections, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlForm_BillingSelections.ResumeLayout(False)
            Me.TabControlPanelProduction_Details.ResumeLayout(False)
            Me.TabControlPanelMedia_Details.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents TabControlForm_BillingSelections As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelProduction_Details As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewProduction_Selections As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TabItemBillingSelections_ProductionTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelMedia_Details As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemBillingSelections_MediaTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents DataGridViewMedia_Selections As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ButtonForm_Delete As WinForm.Presentation.Controls.Button
    End Class

End Namespace