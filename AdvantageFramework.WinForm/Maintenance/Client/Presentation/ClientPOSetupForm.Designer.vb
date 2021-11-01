Namespace Maintenance.Client.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class ClientPOSetupForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ClientPOSetupForm))
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_View = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemView_ShowDescriptions = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_AutoGenerate = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.NumericInputControlVertical_LastNumberUsed = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.ButtonItemAutoGenerate_Enabled = New DevComponents.DotNetBar.ButtonItem()
            Me.ItemContainerAutoGenerate_Vertical = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemVertical_LastNumberUserd = New DevComponents.DotNetBar.LabelItem()
            Me.ItemContainerVertical_Horizontal = New DevComponents.DotNetBar.ItemContainer()
            Me.ControlContainerItem2 = New DevComponents.DotNetBar.ControlContainerItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Export = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Cancel = New DevComponents.DotNetBar.ButtonItem()
            Me.DataGridViewForm_ClientPO = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ControlContainerItem1 = New DevComponents.DotNetBar.ControlContainerItem()
            Me.ButtonItemActions_Save = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            Me.RibbonBarOptions_AutoGenerate.SuspendLayout()
            CType(Me.NumericInputControlVertical_LastNumberUsed.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_View)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_AutoGenerate)
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
            'RibbonBarOptions_View
            '
            Me.RibbonBarOptions_View.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_View.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_View.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_View.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_View.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_View.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemView_ShowDescriptions})
            Me.RibbonBarOptions_View.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_View.Location = New System.Drawing.Point(351, 0)
            Me.RibbonBarOptions_View.Name = "RibbonBarOptions_View"
            Me.RibbonBarOptions_View.SecurityEnabled = True
            Me.RibbonBarOptions_View.Size = New System.Drawing.Size(117, 98)
            Me.RibbonBarOptions_View.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_View.TabIndex = 2
            Me.RibbonBarOptions_View.Text = "View"
            '
            '
            '
            Me.RibbonBarOptions_View.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_View.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_View.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemView_ShowDescriptions
            '
            Me.ButtonItemView_ShowDescriptions.AutoCheckOnClick = True
            Me.ButtonItemView_ShowDescriptions.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemView_ShowDescriptions.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemView_ShowDescriptions.Name = "ButtonItemView_ShowDescriptions"
            Me.ButtonItemView_ShowDescriptions.RibbonWordWrap = False
            Me.ButtonItemView_ShowDescriptions.Stretch = True
            Me.ButtonItemView_ShowDescriptions.SubItemsExpandWidth = 14
            Me.ButtonItemView_ShowDescriptions.Text = "Show Descriptions"
            '
            'RibbonBarOptions_AutoGenerate
            '
            Me.RibbonBarOptions_AutoGenerate.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_AutoGenerate.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_AutoGenerate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_AutoGenerate.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_AutoGenerate.Controls.Add(Me.NumericInputControlVertical_LastNumberUsed)
            Me.RibbonBarOptions_AutoGenerate.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_AutoGenerate.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemAutoGenerate_Enabled, Me.ItemContainerAutoGenerate_Vertical})
            Me.RibbonBarOptions_AutoGenerate.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_AutoGenerate.Location = New System.Drawing.Point(172, 0)
            Me.RibbonBarOptions_AutoGenerate.Name = "RibbonBarOptions_AutoGenerate"
            Me.RibbonBarOptions_AutoGenerate.SecurityEnabled = True
            Me.RibbonBarOptions_AutoGenerate.Size = New System.Drawing.Size(179, 98)
            Me.RibbonBarOptions_AutoGenerate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_AutoGenerate.TabIndex = 1
            Me.RibbonBarOptions_AutoGenerate.Text = "Auto Generate"
            '
            '
            '
            Me.RibbonBarOptions_AutoGenerate.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_AutoGenerate.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_AutoGenerate.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'NumericInputControlVertical_LastNumberUsed
            '
            Me.NumericInputControlVertical_LastNumberUsed.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputControlVertical_LastNumberUsed.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Long]
            Me.NumericInputControlVertical_LastNumberUsed.EditValue = 0
            Me.NumericInputControlVertical_LastNumberUsed.EnterMoveNextControl = True
            Me.NumericInputControlVertical_LastNumberUsed.Location = New System.Drawing.Point(56, 38)
            Me.NumericInputControlVertical_LastNumberUsed.Name = "NumericInputControlVertical_LastNumberUsed"
            Me.NumericInputControlVertical_LastNumberUsed.Properties.AllowMouseWheel = False
            Me.NumericInputControlVertical_LastNumberUsed.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputControlVertical_LastNumberUsed.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputControlVertical_LastNumberUsed.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputControlVertical_LastNumberUsed.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputControlVertical_LastNumberUsed.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputControlVertical_LastNumberUsed.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputControlVertical_LastNumberUsed.Properties.IsFloatValue = False
            Me.NumericInputControlVertical_LastNumberUsed.Properties.Mask.EditMask = "f0"
            Me.NumericInputControlVertical_LastNumberUsed.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputControlVertical_LastNumberUsed.Properties.MaxValue = New Decimal(9223372036854775807)
            Me.NumericInputControlVertical_LastNumberUsed.Properties.MinValue = 0
            Me.NumericInputControlVertical_LastNumberUsed.SecurityEnabled = True
            Me.NumericInputControlVertical_LastNumberUsed.Size = New System.Drawing.Size(86, 20)
            Me.NumericInputControlVertical_LastNumberUsed.TabIndex = 33
            Me.NumericInputControlVertical_LastNumberUsed.TabStop = False
            '
            'ButtonItemAutoGenerate_Enabled
            '
            Me.ButtonItemAutoGenerate_Enabled.AutoCheckOnClick = True
            Me.ButtonItemAutoGenerate_Enabled.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemAutoGenerate_Enabled.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemAutoGenerate_Enabled.Name = "ButtonItemAutoGenerate_Enabled"
            Me.ButtonItemAutoGenerate_Enabled.RibbonWordWrap = False
            Me.ButtonItemAutoGenerate_Enabled.Stretch = True
            Me.ButtonItemAutoGenerate_Enabled.SubItemsExpandWidth = 14
            Me.ButtonItemAutoGenerate_Enabled.Text = "Enabled"
            '
            'ItemContainerAutoGenerate_Vertical
            '
            '
            '
            '
            Me.ItemContainerAutoGenerate_Vertical.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerAutoGenerate_Vertical.BeginGroup = True
            Me.ItemContainerAutoGenerate_Vertical.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerAutoGenerate_Vertical.Name = "ItemContainerAutoGenerate_Vertical"
            Me.ItemContainerAutoGenerate_Vertical.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemVertical_LastNumberUserd, Me.ItemContainerVertical_Horizontal})
            '
            '
            '
            Me.ItemContainerAutoGenerate_Vertical.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemVertical_LastNumberUserd
            '
            Me.LabelItemVertical_LastNumberUserd.Name = "LabelItemVertical_LastNumberUserd"
            Me.LabelItemVertical_LastNumberUserd.Text = "Last Number Used"
            '
            'ItemContainerVertical_Horizontal
            '
            '
            '
            '
            Me.ItemContainerVertical_Horizontal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerVertical_Horizontal.Name = "ItemContainerVertical_Horizontal"
            Me.ItemContainerVertical_Horizontal.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ControlContainerItem2})
            '
            '
            '
            Me.ItemContainerVertical_Horizontal.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ControlContainerItem2
            '
            Me.ControlContainerItem2.AllowItemResize = False
            Me.ControlContainerItem2.Control = Me.NumericInputControlVertical_LastNumberUsed
            Me.ControlContainerItem2.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItem2.Name = "ControlContainerItem2"
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Export, Me.ButtonItemActions_Save, Me.ButtonItemActions_Cancel})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(172, 98)
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
            'ButtonItemActions_Export
            '
            Me.ButtonItemActions_Export.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Export.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Export.Name = "ButtonItemActions_Export"
            Me.ButtonItemActions_Export.RibbonWordWrap = False
            Me.ButtonItemActions_Export.Stretch = True
            Me.ButtonItemActions_Export.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Export.Text = "Export"
            '
            'ButtonItemActions_Cancel
            '
            Me.ButtonItemActions_Cancel.BeginGroup = True
            Me.ButtonItemActions_Cancel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Cancel.Name = "ButtonItemActions_Cancel"
            Me.ButtonItemActions_Cancel.RibbonWordWrap = False
            Me.ButtonItemActions_Cancel.Stretch = True
            Me.ButtonItemActions_Cancel.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Cancel.Text = "Cancel"
            '
            'DataGridViewForm_ClientPO
            '
            Me.DataGridViewForm_ClientPO.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewForm_ClientPO.AllowDragAndDrop = False
            Me.DataGridViewForm_ClientPO.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_ClientPO.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_ClientPO.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_ClientPO.AutoFilterLookupColumns = False
            Me.DataGridViewForm_ClientPO.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_ClientPO.AutoUpdateViewCaption = True
            Me.DataGridViewForm_ClientPO.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewForm_ClientPO.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_ClientPO.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_ClientPO.ItemDescription = "ClientPO(s)"
            Me.DataGridViewForm_ClientPO.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewForm_ClientPO.MultiSelect = True
            Me.DataGridViewForm_ClientPO.Name = "DataGridViewForm_ClientPO"
            Me.DataGridViewForm_ClientPO.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewForm_ClientPO.RunStandardValidation = True
            Me.DataGridViewForm_ClientPO.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_ClientPO.Size = New System.Drawing.Size(689, 397)
            Me.DataGridViewForm_ClientPO.TabIndex = 4
            Me.DataGridViewForm_ClientPO.UseEmbeddedNavigator = False
            Me.DataGridViewForm_ClientPO.ViewCaptionHeight = -1
            '
            'ControlContainerItem1
            '
            Me.ControlContainerItem1.AllowItemResize = False
            Me.ControlContainerItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItem1.Name = "ControlContainerItem1"
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
            'ClientPOSetupForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(713, 421)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.DataGridViewForm_ClientPO)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "ClientPOSetupForm"
            Me.Text = "Client PO Maintenance"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            Me.RibbonBarOptions_AutoGenerate.ResumeLayout(False)
            CType(Me.NumericInputControlVertical_LastNumberUsed.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewForm_ClientPO As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Private WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Private WithEvents RibbonBarOptions_Actions As WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemActions_Export As DevComponents.DotNetBar.ButtonItem
        Private WithEvents RibbonBarOptions_View As WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemView_ShowDescriptions As DevComponents.DotNetBar.ButtonItem
        Private WithEvents RibbonBarOptions_AutoGenerate As WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemAutoGenerate_Enabled As DevComponents.DotNetBar.ButtonItem
        Private WithEvents ButtonItemActions_Cancel As DevComponents.DotNetBar.ButtonItem
        Private WithEvents ItemContainerAutoGenerate_Vertical As DevComponents.DotNetBar.ItemContainer
        Private WithEvents LabelItemVertical_LastNumberUserd As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ControlContainerItem1 As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents ItemContainerVertical_Horizontal As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents NumericInputControlVertical_LastNumberUsed As WinForm.Presentation.Controls.NumericInput
        Friend WithEvents ControlContainerItem2 As DevComponents.DotNetBar.ControlContainerItem
        Private WithEvents ButtonItemActions_Save As DevComponents.DotNetBar.ButtonItem
    End Class

End Namespace

