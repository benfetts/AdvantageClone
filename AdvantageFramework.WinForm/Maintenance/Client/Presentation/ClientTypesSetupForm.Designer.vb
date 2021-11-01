Namespace Maintenance.Client.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class ClientTypesSetupForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ClientTypesSetupForm))
            Me.DataGridViewForm_ClientType = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ItemContainerActions_View = New DevComponents.DotNetBar.ItemContainer()
            Me.ComboBoxItemActions_View = New DevComponents.DotNetBar.ComboBoxItem()
            Me.ButtonItemActions_Export = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Save = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Delete = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Cancel = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            Me.SuspendLayout()
            '
            'DataGridViewForm_ClientType
            '
            Me.DataGridViewForm_ClientType.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewForm_ClientType.AllowDragAndDrop = False
            Me.DataGridViewForm_ClientType.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_ClientType.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_ClientType.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_ClientType.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_ClientType.AutoFilterLookupColumns = False
            Me.DataGridViewForm_ClientType.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_ClientType.AutoUpdateViewCaption = False
            Me.DataGridViewForm_ClientType.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewForm_ClientType.DataSource = Nothing
            Me.DataGridViewForm_ClientType.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_ClientType.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_ClientType.ItemDescription = ""
            Me.DataGridViewForm_ClientType.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewForm_ClientType.MultiSelect = True
            Me.DataGridViewForm_ClientType.Name = "DataGridViewForm_ClientType"
            Me.DataGridViewForm_ClientType.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewForm_ClientType.RunStandardValidation = True
            Me.DataGridViewForm_ClientType.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_ClientType.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_ClientType.Size = New System.Drawing.Size(689, 397)
            Me.DataGridViewForm_ClientType.TabIndex = 4
            Me.DataGridViewForm_ClientType.UseEmbeddedNavigator = False
            Me.DataGridViewForm_ClientType.ViewCaptionHeight = -1
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(120, 161)
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
            Me.RibbonBarMergeContainerForm_Options.TabIndex = 5
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
            Me.RibbonBarOptions_Actions.DragDropSupport = True
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerActions_View, Me.ButtonItemActions_Export, Me.ButtonItemActions_Save, Me.ButtonItemActions_Delete, Me.ButtonItemActions_Cancel})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(428, 98)
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
            'ItemContainerActions_View
            '
            '
            '
            '
            Me.ItemContainerActions_View.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerActions_View.FixedSize = New System.Drawing.Size(125, 0)
            Me.ItemContainerActions_View.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerActions_View.Name = "ItemContainerActions_View"
            Me.ItemContainerActions_View.ResizeItemsToFit = False
            Me.ItemContainerActions_View.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ComboBoxItemActions_View})
            '
            '
            '
            Me.ItemContainerActions_View.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerActions_View.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ComboBoxItemActions_View
            '
            Me.ComboBoxItemActions_View.ComboWidth = 115
            Me.ComboBoxItemActions_View.DropDownHeight = 106
            Me.ComboBoxItemActions_View.Name = "ComboBoxItemActions_View"
            Me.ComboBoxItemActions_View.Text = "ComboBoxItem1"
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
            'ClientTypesSetupForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(713, 421)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.DataGridViewForm_ClientType)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "ClientTypesSetupForm"
            Me.Text = "Client Types Maintenance"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewForm_ClientType As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Export As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Save As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Delete As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Cancel As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ItemContainerActions_View As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ComboBoxItemActions_View As DevComponents.DotNetBar.ComboBoxItem
    End Class

End Namespace

