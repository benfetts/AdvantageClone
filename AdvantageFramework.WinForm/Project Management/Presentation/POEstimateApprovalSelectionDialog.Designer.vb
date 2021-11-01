Namespace ProjectManagement.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class POEstimateApprovalSelectionDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(POEstimateApprovalSelectionDialog))
            Me.ButtonForm_Ok = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DataGridViewRightSection_EstimateFunctions = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RadioButtonControlForm_AddByJob = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlForm_AddByCampaign = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.PanelForm_Main = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.PanelMain_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.ExpandableSplitterControlMain_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelMain_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewLeftSection_JobsAndComponents = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.DataGridViewLeftSection_Campaign = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.PanelMain_TopSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.CheckBoxForm_ItemsAssociatedToPOVendorOnly = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            CType(Me.PanelForm_Main, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Main.SuspendLayout()
            CType(Me.PanelMain_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelMain_RightSection.SuspendLayout()
            CType(Me.PanelMain_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelMain_LeftSection.SuspendLayout()
            CType(Me.PanelMain_TopSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelMain_TopSection.SuspendLayout()
            Me.SuspendLayout()
            '
            'ButtonForm_Ok
            '
            Me.ButtonForm_Ok.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Ok.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Ok.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Ok.Location = New System.Drawing.Point(605, 351)
            Me.ButtonForm_Ok.Name = "ButtonForm_Ok"
            Me.ButtonForm_Ok.SecurityEnabled = True
            Me.ButtonForm_Ok.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Ok.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Ok.TabIndex = 1
            Me.ButtonForm_Ok.Text = "Ok"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(686, 351)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 2
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'DataGridViewRightSection_EstimateFunctions
            '
            Me.DataGridViewRightSection_EstimateFunctions.AllowSelectGroupHeaderRow = True
            Me.DataGridViewRightSection_EstimateFunctions.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewRightSection_EstimateFunctions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewRightSection_EstimateFunctions.AutoFilterLookupColumns = False
            Me.DataGridViewRightSection_EstimateFunctions.AutoloadRepositoryDatasource = True
            Me.DataGridViewRightSection_EstimateFunctions.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewRightSection_EstimateFunctions.DataSource = Nothing
            Me.DataGridViewRightSection_EstimateFunctions.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewRightSection_EstimateFunctions.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewRightSection_EstimateFunctions.ItemDescription = "Item(s)"
            Me.DataGridViewRightSection_EstimateFunctions.Location = New System.Drawing.Point(6, 0)
            Me.DataGridViewRightSection_EstimateFunctions.MultiSelect = True
            Me.DataGridViewRightSection_EstimateFunctions.Name = "DataGridViewRightSection_EstimateFunctions"
            Me.DataGridViewRightSection_EstimateFunctions.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewRightSection_EstimateFunctions.RunStandardValidation = True
            Me.DataGridViewRightSection_EstimateFunctions.ShowSelectDeselectAllButtons = True
            Me.DataGridViewRightSection_EstimateFunctions.Size = New System.Drawing.Size(521, 281)
            Me.DataGridViewRightSection_EstimateFunctions.TabIndex = 0
            Me.DataGridViewRightSection_EstimateFunctions.UseEmbeddedNavigator = False
            Me.DataGridViewRightSection_EstimateFunctions.ViewCaptionHeight = -1
            '
            'RadioButtonControlForm_AddByJob
            '
            Me.RadioButtonControlForm_AddByJob.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlForm_AddByJob.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlForm_AddByJob.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlForm_AddByJob.Location = New System.Drawing.Point(103, 0)
            Me.RadioButtonControlForm_AddByJob.Name = "RadioButtonControlForm_AddByJob"
            Me.RadioButtonControlForm_AddByJob.SecurityEnabled = True
            Me.RadioButtonControlForm_AddByJob.Size = New System.Drawing.Size(646, 20)
            Me.RadioButtonControlForm_AddByJob.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlForm_AddByJob.TabIndex = 1
            Me.RadioButtonControlForm_AddByJob.TabStop = False
            Me.RadioButtonControlForm_AddByJob.Text = "By Job"
            '
            'RadioButtonControlForm_AddByCampaign
            '
            Me.RadioButtonControlForm_AddByCampaign.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControlForm_AddByCampaign.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlForm_AddByCampaign.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlForm_AddByCampaign.Checked = True
            Me.RadioButtonControlForm_AddByCampaign.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonControlForm_AddByCampaign.CheckValue = "Y"
            Me.RadioButtonControlForm_AddByCampaign.Location = New System.Drawing.Point(0, 0)
            Me.RadioButtonControlForm_AddByCampaign.Name = "RadioButtonControlForm_AddByCampaign"
            Me.RadioButtonControlForm_AddByCampaign.SecurityEnabled = True
            Me.RadioButtonControlForm_AddByCampaign.Size = New System.Drawing.Size(97, 20)
            Me.RadioButtonControlForm_AddByCampaign.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlForm_AddByCampaign.TabIndex = 0
            Me.RadioButtonControlForm_AddByCampaign.Text = "By Campaign"
            '
            'PanelForm_Main
            '
            Me.PanelForm_Main.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PanelForm_Main.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelForm_Main.Controls.Add(Me.PanelMain_RightSection)
            Me.PanelForm_Main.Controls.Add(Me.ExpandableSplitterControlMain_LeftRight)
            Me.PanelForm_Main.Controls.Add(Me.PanelMain_LeftSection)
            Me.PanelForm_Main.Controls.Add(Me.PanelMain_TopSection)
            Me.PanelForm_Main.Location = New System.Drawing.Point(12, 12)
            Me.PanelForm_Main.Name = "PanelForm_Main"
            Me.PanelForm_Main.Size = New System.Drawing.Size(749, 333)
            Me.PanelForm_Main.TabIndex = 0
            '
            'PanelMain_RightSection
            '
            Me.PanelMain_RightSection.Controls.Add(Me.DataGridViewRightSection_EstimateFunctions)
            Me.PanelMain_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelMain_RightSection.Location = New System.Drawing.Point(222, 52)
            Me.PanelMain_RightSection.Name = "PanelMain_RightSection"
            Me.PanelMain_RightSection.Size = New System.Drawing.Size(527, 281)
            Me.PanelMain_RightSection.TabIndex = 6
            '
            'ExpandableSplitterControlMain_LeftRight
            '
            Me.ExpandableSplitterControlMain_LeftRight.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlMain_LeftRight.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlMain_LeftRight.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControlMain_LeftRight.ExpandableControl = Me.PanelMain_LeftSection
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
            Me.ExpandableSplitterControlMain_LeftRight.Location = New System.Drawing.Point(216, 52)
            Me.ExpandableSplitterControlMain_LeftRight.Name = "ExpandableSplitterControlMain_LeftRight"
            Me.ExpandableSplitterControlMain_LeftRight.Size = New System.Drawing.Size(6, 281)
            Me.ExpandableSplitterControlMain_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControlMain_LeftRight.TabIndex = 5
            Me.ExpandableSplitterControlMain_LeftRight.TabStop = False
            '
            'PanelMain_LeftSection
            '
            Me.PanelMain_LeftSection.Controls.Add(Me.DataGridViewLeftSection_JobsAndComponents)
            Me.PanelMain_LeftSection.Controls.Add(Me.DataGridViewLeftSection_Campaign)
            Me.PanelMain_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelMain_LeftSection.Location = New System.Drawing.Point(0, 52)
            Me.PanelMain_LeftSection.Name = "PanelMain_LeftSection"
            Me.PanelMain_LeftSection.Size = New System.Drawing.Size(216, 281)
            Me.PanelMain_LeftSection.TabIndex = 4
            '
            'DataGridViewLeftSection_JobsAndComponents
            '
            Me.DataGridViewLeftSection_JobsAndComponents.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_JobsAndComponents.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewLeftSection_JobsAndComponents.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_JobsAndComponents.AutoFilterLookupColumns = False
            Me.DataGridViewLeftSection_JobsAndComponents.AutoloadRepositoryDatasource = True
            Me.DataGridViewLeftSection_JobsAndComponents.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewLeftSection_JobsAndComponents.DataSource = Nothing
            Me.DataGridViewLeftSection_JobsAndComponents.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewLeftSection_JobsAndComponents.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_JobsAndComponents.ItemDescription = "Job Component(s)"
            Me.DataGridViewLeftSection_JobsAndComponents.Location = New System.Drawing.Point(0, 0)
            Me.DataGridViewLeftSection_JobsAndComponents.MultiSelect = True
            Me.DataGridViewLeftSection_JobsAndComponents.Name = "DataGridViewLeftSection_JobsAndComponents"
            Me.DataGridViewLeftSection_JobsAndComponents.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_JobsAndComponents.RunStandardValidation = True
            Me.DataGridViewLeftSection_JobsAndComponents.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_JobsAndComponents.Size = New System.Drawing.Size(210, 281)
            Me.DataGridViewLeftSection_JobsAndComponents.TabIndex = 1
            Me.DataGridViewLeftSection_JobsAndComponents.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_JobsAndComponents.ViewCaptionHeight = -1
            '
            'DataGridViewLeftSection_Campaign
            '
            Me.DataGridViewLeftSection_Campaign.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_Campaign.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewLeftSection_Campaign.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_Campaign.AutoFilterLookupColumns = False
            Me.DataGridViewLeftSection_Campaign.AutoloadRepositoryDatasource = True
            Me.DataGridViewLeftSection_Campaign.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewLeftSection_Campaign.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewLeftSection_Campaign.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_Campaign.ItemDescription = "Campaign(s)"
            Me.DataGridViewLeftSection_Campaign.Location = New System.Drawing.Point(0, 0)
            Me.DataGridViewLeftSection_Campaign.MultiSelect = True
            Me.DataGridViewLeftSection_Campaign.Name = "DataGridViewLeftSection_Campaign"
            Me.DataGridViewLeftSection_Campaign.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_Campaign.RunStandardValidation = True
            Me.DataGridViewLeftSection_Campaign.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_Campaign.Size = New System.Drawing.Size(210, 281)
            Me.DataGridViewLeftSection_Campaign.TabIndex = 0
            Me.DataGridViewLeftSection_Campaign.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_Campaign.ViewCaptionHeight = -1
            '
            'PanelMain_TopSection
            '
            Me.PanelMain_TopSection.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelMain_TopSection.Controls.Add(Me.CheckBoxForm_ItemsAssociatedToPOVendorOnly)
            Me.PanelMain_TopSection.Controls.Add(Me.RadioButtonControlForm_AddByJob)
            Me.PanelMain_TopSection.Controls.Add(Me.RadioButtonControlForm_AddByCampaign)
            Me.PanelMain_TopSection.Dock = System.Windows.Forms.DockStyle.Top
            Me.PanelMain_TopSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelMain_TopSection.Name = "PanelMain_TopSection"
            Me.PanelMain_TopSection.Size = New System.Drawing.Size(749, 52)
            Me.PanelMain_TopSection.TabIndex = 2
            '
            'CheckBoxForm_ItemsAssociatedToPOVendorOnly
            '
            Me.CheckBoxForm_ItemsAssociatedToPOVendorOnly.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxForm_ItemsAssociatedToPOVendorOnly.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_ItemsAssociatedToPOVendorOnly.CheckValue = 0
            Me.CheckBoxForm_ItemsAssociatedToPOVendorOnly.CheckValueChecked = 1
            Me.CheckBoxForm_ItemsAssociatedToPOVendorOnly.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_ItemsAssociatedToPOVendorOnly.CheckValueUnchecked = 0
            Me.CheckBoxForm_ItemsAssociatedToPOVendorOnly.ChildControls = CType(resources.GetObject("CheckBoxForm_ItemsAssociatedToPOVendorOnly.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_ItemsAssociatedToPOVendorOnly.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_ItemsAssociatedToPOVendorOnly.Location = New System.Drawing.Point(0, 26)
            Me.CheckBoxForm_ItemsAssociatedToPOVendorOnly.Name = "CheckBoxForm_ItemsAssociatedToPOVendorOnly"
            Me.CheckBoxForm_ItemsAssociatedToPOVendorOnly.OldestSibling = Nothing
            Me.CheckBoxForm_ItemsAssociatedToPOVendorOnly.SecurityEnabled = True
            Me.CheckBoxForm_ItemsAssociatedToPOVendorOnly.SiblingControls = CType(resources.GetObject("CheckBoxForm_ItemsAssociatedToPOVendorOnly.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_ItemsAssociatedToPOVendorOnly.Size = New System.Drawing.Size(749, 20)
            Me.CheckBoxForm_ItemsAssociatedToPOVendorOnly.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_ItemsAssociatedToPOVendorOnly.TabIndex = 0
            Me.CheckBoxForm_ItemsAssociatedToPOVendorOnly.Text = "Only Show Items Associated to PO Vendor"
            '
            'POEstimateApprovalSelectionDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(773, 383)
            Me.Controls.Add(Me.PanelForm_Main)
            Me.Controls.Add(Me.ButtonForm_Ok)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "POEstimateApprovalSelectionDialog"
            Me.Text = "Select"
            CType(Me.PanelForm_Main, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Main.ResumeLayout(False)
            CType(Me.PanelMain_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelMain_RightSection.ResumeLayout(False)
            CType(Me.PanelMain_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelMain_LeftSection.ResumeLayout(False)
            CType(Me.PanelMain_TopSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelMain_TopSection.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Ok As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents DataGridViewRightSection_EstimateFunctions As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents PanelForm_Main As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents CheckBoxForm_ItemsAssociatedToPOVendorOnly As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents RadioButtonControlForm_AddByJob As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlForm_AddByCampaign As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents PanelMain_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents ExpandableSplitterControlMain_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelMain_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewLeftSection_JobsAndComponents As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents DataGridViewLeftSection_Campaign As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents PanelMain_TopSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
    End Class

End Namespace
