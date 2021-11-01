Namespace Employee.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class EmployeeTimesheeCommentViewDialog
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseRibbonForm

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmployeeTimesheeCommentViewDialog))
            Me.DataGridViewForm_Comments = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.PropertyGridControlLeftSection_HeaderData = New AdvantageFramework.WinForm.Presentation.Controls.PropertyGridControl()
            Me.PanelForm_Main = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.ExpandableSplitterControlMain_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelMain_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.PanelMain_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PropertyGridControlLeftSection_HeaderData, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PanelForm_Main, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Main.SuspendLayout()
            CType(Me.PanelMain_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelMain_RightSection.SuspendLayout()
            CType(Me.PanelMain_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelMain_LeftSection.SuspendLayout()
            Me.SuspendLayout()
            '
            'RibbonControlForm_MainRibbon
            '
            '
            '
            '
            Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(601, 154)
            Me.RibbonControlForm_MainRibbon.SystemText.MaximizeRibbonText = "&Maximize the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.QatAddItemText = "&Add to Quick Access Toolbar"
            Me.RibbonControlForm_MainRibbon.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>"
            Me.RibbonControlForm_MainRibbon.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar..."
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogAddButton = "&Add >>"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogCancelButton = "Cancel"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogCaption = "Customize Quick Access Toolbar"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogCategoriesLabel = "&Choose commands from:"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogOkButton = "OK"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogRemoveButton = "&Remove"
            Me.RibbonControlForm_MainRibbon.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar"
            Me.RibbonControlForm_MainRibbon.Controls.SetChildIndex(Me.RibbonPanelFile_FilePanel, 0)
            '
            'RibbonPanelFile_FilePanel
            '
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 57)
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(601, 95)
            '
            '
            '
            Me.RibbonPanelFile_FilePanel.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonPanelFile_FilePanel.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonPanelFile_FilePanel.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarFilePanel_System, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Actions, 0)
            '
            'RibbonBarFilePanel_System
            '
            '
            '
            '
            Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_System.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFilePanel_System.Size = New System.Drawing.Size(100, 92)
            '
            '
            '
            Me.RibbonBarFilePanel_System.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_System.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemSystem_Close
            '
            Me.ButtonItemSystem_Close.Image = AdvantageFramework.My.Resources.ExitImage
            '
            'PanelForm_Form
            '
            Me.PanelForm_Form.Size = New System.Drawing.Size(601, 330)
            '
            'BarForm_StatusBar
            '
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 485)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(601, 18)
            '
            'DataGridViewForm_Comments
            '
            Me.DataGridViewForm_Comments.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_Comments.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_Comments.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_Comments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_Comments.AutoFilterLookupColumns = False
            Me.DataGridViewForm_Comments.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_Comments.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewForm_Comments.DataSource = Nothing
            Me.DataGridViewForm_Comments.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_Comments.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_Comments.ItemDescription = "Item(s)"
            Me.DataGridViewForm_Comments.Location = New System.Drawing.Point(12, 0)
            Me.DataGridViewForm_Comments.MultiSelect = True
            Me.DataGridViewForm_Comments.Name = "DataGridViewForm_Comments"
            Me.DataGridViewForm_Comments.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_Comments.RunStandardValidation = True
            Me.DataGridViewForm_Comments.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_Comments.Size = New System.Drawing.Size(324, 324)
            Me.DataGridViewForm_Comments.TabIndex = 1
            Me.DataGridViewForm_Comments.UseEmbeddedNavigator = False
            Me.DataGridViewForm_Comments.ViewCaptionHeight = -1
            '
            'PropertyGridControlLeftSection_HeaderData
            '
            Me.PropertyGridControlLeftSection_HeaderData.AllowExtraItemsInGridLookupEdits = True
            Me.PropertyGridControlLeftSection_HeaderData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PropertyGridControlLeftSection_HeaderData.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.PropertyGridControlLeftSection_HeaderData.Appearance.Empty.Options.UseFont = True
            Me.PropertyGridControlLeftSection_HeaderData.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.PropertyGridControlLeftSection_HeaderData.Appearance.FixedLine.Options.UseFont = True
            Me.PropertyGridControlLeftSection_HeaderData.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.PropertyGridControlLeftSection_HeaderData.Appearance.FocusedCell.Options.UseFont = True
            Me.PropertyGridControlLeftSection_HeaderData.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.PropertyGridControlLeftSection_HeaderData.Appearance.FocusedRow.Options.UseFont = True
            Me.PropertyGridControlLeftSection_HeaderData.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.PropertyGridControlLeftSection_HeaderData.Appearance.HideSelectionRow.Options.UseFont = True
            Me.PropertyGridControlLeftSection_HeaderData.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.PropertyGridControlLeftSection_HeaderData.Appearance.HorzLine.Options.UseFont = True
            Me.PropertyGridControlLeftSection_HeaderData.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.PropertyGridControlLeftSection_HeaderData.Appearance.VertLine.Options.UseFont = True
            Me.PropertyGridControlLeftSection_HeaderData.AutoFilterLookupColumns = True
            Me.PropertyGridControlLeftSection_HeaderData.AutoloadRepositoryDatasource = True
            Me.PropertyGridControlLeftSection_HeaderData.ControlType = AdvantageFramework.WinForm.Presentation.Controls.PropertyGridControl.ControlTypes.Editable
            Me.PropertyGridControlLeftSection_HeaderData.Location = New System.Drawing.Point(0, 0)
            Me.PropertyGridControlLeftSection_HeaderData.Name = "PropertyGridControlLeftSection_HeaderData"
            Me.PropertyGridControlLeftSection_HeaderData.ObjectType = Nothing
            Me.PropertyGridControlLeftSection_HeaderData.Size = New System.Drawing.Size(253, 324)
            Me.PropertyGridControlLeftSection_HeaderData.TabIndex = 1
            '
            'PanelForm_Main
            '
            Me.PanelForm_Main.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PanelForm_Main.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelForm_Main.Controls.Add(Me.ExpandableSplitterControlMain_LeftRight)
            Me.PanelForm_Main.Controls.Add(Me.PanelMain_RightSection)
            Me.PanelForm_Main.Controls.Add(Me.PanelMain_LeftSection)
            Me.PanelForm_Main.Location = New System.Drawing.Point(8, 158)
            Me.PanelForm_Main.Name = "PanelForm_Main"
            Me.PanelForm_Main.Size = New System.Drawing.Size(595, 324)
            Me.PanelForm_Main.TabIndex = 0
            '
            'ExpandableSplitterControlMain_LeftRight
            '
            Me.ExpandableSplitterControlMain_LeftRight.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlMain_LeftRight.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlMain_LeftRight.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControlMain_LeftRight.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlMain_LeftRight.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlMain_LeftRight.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlMain_LeftRight.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlMain_LeftRight.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlMain_LeftRight.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlMain_LeftRight.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlMain_LeftRight.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlMain_LeftRight.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterControlMain_LeftRight.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterControlMain_LeftRight.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterControlMain_LeftRight.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterControlMain_LeftRight.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlMain_LeftRight.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlMain_LeftRight.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlMain_LeftRight.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlMain_LeftRight.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlMain_LeftRight.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlMain_LeftRight.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlMain_LeftRight.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlMain_LeftRight.Location = New System.Drawing.Point(259, 0)
            Me.ExpandableSplitterControlMain_LeftRight.Name = "ExpandableSplitterControlMain_LeftRight"
            Me.ExpandableSplitterControlMain_LeftRight.Size = New System.Drawing.Size(6, 324)
            Me.ExpandableSplitterControlMain_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControlMain_LeftRight.TabIndex = 33
            Me.ExpandableSplitterControlMain_LeftRight.TabStop = False
            '
            'PanelMain_RightSection
            '
            Me.PanelMain_RightSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelMain_RightSection.Controls.Add(Me.DataGridViewForm_Comments)
            Me.PanelMain_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelMain_RightSection.Location = New System.Drawing.Point(259, 0)
            Me.PanelMain_RightSection.Name = "PanelMain_RightSection"
            Me.PanelMain_RightSection.Size = New System.Drawing.Size(336, 324)
            Me.PanelMain_RightSection.TabIndex = 1
            '
            'PanelMain_LeftSection
            '
            Me.PanelMain_LeftSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelMain_LeftSection.Controls.Add(Me.PropertyGridControlLeftSection_HeaderData)
            Me.PanelMain_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelMain_LeftSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelMain_LeftSection.Name = "PanelMain_LeftSection"
            Me.PanelMain_LeftSection.Size = New System.Drawing.Size(259, 324)
            Me.PanelMain_LeftSection.TabIndex = 0
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Save})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(103, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(62, 92)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 3
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
            'ButtonItemActions_Save
            '
            Me.ButtonItemActions_Save.BeginGroup = True
            Me.ButtonItemActions_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Save.Name = "ButtonItemActions_Save"
            Me.ButtonItemActions_Save.RibbonWordWrap = False
            Me.ButtonItemActions_Save.SecurityEnabled = True
            Me.ButtonItemActions_Save.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Save.Text = "Save"
            '
            'EmployeeTimesheeCommentViewDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(611, 505)
            Me.Controls.Add(Me.PanelForm_Main)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "EmployeeTimesheeCommentViewDialog"
            Me.Text = "Comment View"
            Me.Controls.SetChildIndex(Me.BarForm_StatusBar, 0)
            Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
            Me.Controls.SetChildIndex(Me.PanelForm_Form, 0)
            Me.Controls.SetChildIndex(Me.PanelForm_Main, 0)
            Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.PerformLayout()
            Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PropertyGridControlLeftSection_HeaderData, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PanelForm_Main, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Main.ResumeLayout(False)
            CType(Me.PanelMain_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelMain_RightSection.ResumeLayout(False)
            CType(Me.PanelMain_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelMain_LeftSection.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewForm_Comments As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents PropertyGridControlLeftSection_HeaderData As AdvantageFramework.WinForm.Presentation.Controls.PropertyGridControl
        Friend WithEvents PanelForm_Main As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents ExpandableSplitterControlMain_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelMain_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents PanelMain_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Save As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
    End Class

End Namespace