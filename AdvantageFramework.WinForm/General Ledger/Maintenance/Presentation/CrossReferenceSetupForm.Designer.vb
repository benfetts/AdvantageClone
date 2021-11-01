Namespace GeneralLedger.Maintenance.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class CrossReferenceSetupForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CrossReferenceSetupForm))
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Print = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Save = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Delete = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Cancel = New DevComponents.DotNetBar.ButtonItem()
            Me.DataGridViewOffice_CrossReferences = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabControlForm_CrossReference = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelOfficeTab_Office = New DevComponents.DotNetBar.TabControlPanel()
            Me.TabItemCrossReference_OfficeTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelDepartmentTab_Department = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewDepartment_CrossReferences = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemCrossReference_Department = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            CType(Me.TabControlForm_CrossReference, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlForm_CrossReference.SuspendLayout()
            Me.TabControlPanelOfficeTab_Office.SuspendLayout()
            Me.TabControlPanelDepartmentTab_Department.SuspendLayout()
            Me.SuspendLayout()
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(98, 126)
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(473, 98)
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Print, Me.ButtonItemActions_Save, Me.ButtonItemActions_Delete, Me.ButtonItemActions_Cancel})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(167, 98)
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
            Me.RibbonBarOptions_Actions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemActions_Print
            '
            Me.ButtonItemActions_Print.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Print.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Print.Name = "ButtonItemActions_Print"
            Me.ButtonItemActions_Print.RibbonWordWrap = False
            Me.ButtonItemActions_Print.Stretch = True
            Me.ButtonItemActions_Print.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Print.Text = "Print"
            '
            'ButtonItemActions_Save
            '
            Me.ButtonItemActions_Save.BeginGroup = True
            Me.ButtonItemActions_Save.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Save.Name = "ButtonItemActions_Save"
            Me.ButtonItemActions_Save.RibbonWordWrap = False
            Me.ButtonItemActions_Save.Stretch = True
            Me.ButtonItemActions_Save.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Save.Text = "Save"
            '
            'ButtonItemActions_Delete
            '
            Me.ButtonItemActions_Delete.BeginGroup = True
            Me.ButtonItemActions_Delete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Delete.Name = "ButtonItemActions_Delete"
            Me.ButtonItemActions_Delete.RibbonWordWrap = False
            Me.ButtonItemActions_Delete.Stretch = True
            Me.ButtonItemActions_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Delete.Text = "Delete"
            '
            'ButtonItemActions_Cancel
            '
            Me.ButtonItemActions_Cancel.BeginGroup = True
            Me.ButtonItemActions_Cancel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Cancel.Enabled = False
            Me.ButtonItemActions_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Cancel.Name = "ButtonItemActions_Cancel"
            Me.ButtonItemActions_Cancel.RibbonWordWrap = False
            Me.ButtonItemActions_Cancel.Stretch = True
            Me.ButtonItemActions_Cancel.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Cancel.Text = "Cancel"
            Me.ButtonItemActions_Cancel.Tooltip = "Cancel adding new row"
            '
            'DataGridViewOffice_CrossReferences
            '
            Me.DataGridViewOffice_CrossReferences.AllowSelectGroupHeaderRow = True
            Me.DataGridViewOffice_CrossReferences.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewOffice_CrossReferences.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewOffice_CrossReferences.AutoFilterLookupColumns = False
            Me.DataGridViewOffice_CrossReferences.AutoloadRepositoryDatasource = True
            Me.DataGridViewOffice_CrossReferences.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewOffice_CrossReferences.DataSource = Nothing
            Me.DataGridViewOffice_CrossReferences.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewOffice_CrossReferences.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewOffice_CrossReferences.ItemDescription = ""
            Me.DataGridViewOffice_CrossReferences.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewOffice_CrossReferences.MultiSelect = True
            Me.DataGridViewOffice_CrossReferences.Name = "DataGridViewOffice_CrossReferences"
            Me.DataGridViewOffice_CrossReferences.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewOffice_CrossReferences.ShowSelectDeselectAllButtons = False
            Me.DataGridViewOffice_CrossReferences.Size = New System.Drawing.Size(584, 372)
            Me.DataGridViewOffice_CrossReferences.TabIndex = 4
            Me.DataGridViewOffice_CrossReferences.UseEmbeddedNavigator = False
            Me.DataGridViewOffice_CrossReferences.ViewCaptionHeight = -1
            '
            'TabControlForm_CrossReference
            '
            Me.TabControlForm_CrossReference.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlForm_CrossReference.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer))
            Me.TabControlForm_CrossReference.CanReorderTabs = False
            Me.TabControlForm_CrossReference.Controls.Add(Me.TabControlPanelOfficeTab_Office)
            Me.TabControlForm_CrossReference.Controls.Add(Me.TabControlPanelDepartmentTab_Department)
            Me.TabControlForm_CrossReference.Location = New System.Drawing.Point(12, 12)
            Me.TabControlForm_CrossReference.Name = "TabControlForm_CrossReference"
            Me.TabControlForm_CrossReference.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlForm_CrossReference.SelectedTabIndex = 0
            Me.TabControlForm_CrossReference.Size = New System.Drawing.Size(592, 407)
            Me.TabControlForm_CrossReference.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlForm_CrossReference.TabIndex = 23
            Me.TabControlForm_CrossReference.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlForm_CrossReference.Tabs.Add(Me.TabItemCrossReference_OfficeTab)
            Me.TabControlForm_CrossReference.Tabs.Add(Me.TabItemCrossReference_Department)
            '
            'TabControlPanelOfficeTab_Office
            '
            Me.TabControlPanelOfficeTab_Office.Controls.Add(Me.DataGridViewOffice_CrossReferences)
            Me.TabControlPanelOfficeTab_Office.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelOfficeTab_Office.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelOfficeTab_Office.Name = "TabControlPanelOfficeTab_Office"
            Me.TabControlPanelOfficeTab_Office.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelOfficeTab_Office.Size = New System.Drawing.Size(592, 380)
            Me.TabControlPanelOfficeTab_Office.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelOfficeTab_Office.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelOfficeTab_Office.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelOfficeTab_Office.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelOfficeTab_Office.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelOfficeTab_Office.Style.GradientAngle = 90
            Me.TabControlPanelOfficeTab_Office.TabIndex = 1
            Me.TabControlPanelOfficeTab_Office.TabItem = Me.TabItemCrossReference_OfficeTab
            '
            'TabItemCrossReference_OfficeTab
            '
            Me.TabItemCrossReference_OfficeTab.AttachedControl = Me.TabControlPanelOfficeTab_Office
            Me.TabItemCrossReference_OfficeTab.Name = "TabItemCrossReference_OfficeTab"
            Me.TabItemCrossReference_OfficeTab.Text = "Office"
            '
            'TabControlPanelDepartmentTab_Department
            '
            Me.TabControlPanelDepartmentTab_Department.Controls.Add(Me.DataGridViewDepartment_CrossReferences)
            Me.TabControlPanelDepartmentTab_Department.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelDepartmentTab_Department.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelDepartmentTab_Department.Name = "TabControlPanelDepartmentTab_Department"
            Me.TabControlPanelDepartmentTab_Department.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelDepartmentTab_Department.Size = New System.Drawing.Size(592, 380)
            Me.TabControlPanelDepartmentTab_Department.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDepartmentTab_Department.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDepartmentTab_Department.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelDepartmentTab_Department.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelDepartmentTab_Department.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelDepartmentTab_Department.Style.GradientAngle = 90
            Me.TabControlPanelDepartmentTab_Department.TabIndex = 5
            Me.TabControlPanelDepartmentTab_Department.TabItem = Me.TabItemCrossReference_Department
            '
            'DataGridViewDepartment_CrossReferences
            '
            Me.DataGridViewDepartment_CrossReferences.AllowSelectGroupHeaderRow = True
            Me.DataGridViewDepartment_CrossReferences.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewDepartment_CrossReferences.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewDepartment_CrossReferences.AutoFilterLookupColumns = False
            Me.DataGridViewDepartment_CrossReferences.AutoloadRepositoryDatasource = True
            Me.DataGridViewDepartment_CrossReferences.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewDepartment_CrossReferences.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewDepartment_CrossReferences.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewDepartment_CrossReferences.ItemDescription = ""
            Me.DataGridViewDepartment_CrossReferences.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewDepartment_CrossReferences.MultiSelect = True
            Me.DataGridViewDepartment_CrossReferences.Name = "DataGridViewDepartment_CrossReferences"
            Me.DataGridViewDepartment_CrossReferences.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewDepartment_CrossReferences.ShowSelectDeselectAllButtons = False
            Me.DataGridViewDepartment_CrossReferences.Size = New System.Drawing.Size(584, 372)
            Me.DataGridViewDepartment_CrossReferences.TabIndex = 24
            Me.DataGridViewDepartment_CrossReferences.UseEmbeddedNavigator = False
            Me.DataGridViewDepartment_CrossReferences.ViewCaptionHeight = -1
            '
            'TabItemCrossReference_Department
            '
            Me.TabItemCrossReference_Department.AttachedControl = Me.TabControlPanelDepartmentTab_Department
            Me.TabItemCrossReference_Department.Name = "TabItemCrossReference_Department"
            Me.TabItemCrossReference_Department.Text = "Department"
            '
            'CrossReferenceSetupForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(616, 431)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.TabControlForm_CrossReference)
            Me.DoubleBuffered = True
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "CrossReferenceSetupForm"
            Me.Text = "GL Cross Reference"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            CType(Me.TabControlForm_CrossReference, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlForm_CrossReference.ResumeLayout(False)
            Me.TabControlPanelOfficeTab_Office.ResumeLayout(False)
            Me.TabControlPanelDepartmentTab_Department.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Save As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Delete As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents DataGridViewOffice_CrossReferences As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ButtonItemActions_Cancel As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Print As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents TabControlForm_CrossReference As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelOfficeTab_Office As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemCrossReference_OfficeTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelDepartmentTab_Department As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewDepartment_CrossReferences As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TabItemCrossReference_Department As DevComponents.DotNetBar.TabItem
    End Class

End Namespace

