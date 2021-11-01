Namespace Maintenance.General.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class MyObjectDefinitionSetupForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MyObjectDefinitionSetupForm))
            Me.DataGridViewForm_MyObjectDefinitionObjects = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Add = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Delete = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_View = New DevComponents.DotNetBar.ButtonItem()
            Me.LabelForm_ObjectType = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_ObjectType = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.DataGridViewForm_MyObjectDefinitions = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.SuspendLayout()
            '
            'DataGridViewForm_MyObjectDefinitionObjects
            '
            Me.DataGridViewForm_MyObjectDefinitionObjects.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewForm_MyObjectDefinitionObjects.AllowDragAndDrop = False
            Me.DataGridViewForm_MyObjectDefinitionObjects.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_MyObjectDefinitionObjects.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_MyObjectDefinitionObjects.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_MyObjectDefinitionObjects.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_MyObjectDefinitionObjects.AutoFilterLookupColumns = False
            Me.DataGridViewForm_MyObjectDefinitionObjects.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_MyObjectDefinitionObjects.AutoUpdateViewCaption = True
            Me.DataGridViewForm_MyObjectDefinitionObjects.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewForm_MyObjectDefinitionObjects.DataSource = Nothing
            Me.DataGridViewForm_MyObjectDefinitionObjects.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_MyObjectDefinitionObjects.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_MyObjectDefinitionObjects.ItemDescription = "My Dashboard Definition Dashboard(s)"
            Me.DataGridViewForm_MyObjectDefinitionObjects.Location = New System.Drawing.Point(12, 38)
            Me.DataGridViewForm_MyObjectDefinitionObjects.MultiSelect = True
            Me.DataGridViewForm_MyObjectDefinitionObjects.Name = "DataGridViewForm_MyObjectDefinitionObjects"
            Me.DataGridViewForm_MyObjectDefinitionObjects.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_MyObjectDefinitionObjects.RunStandardValidation = True
            Me.DataGridViewForm_MyObjectDefinitionObjects.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_MyObjectDefinitionObjects.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_MyObjectDefinitionObjects.Size = New System.Drawing.Size(291, 371)
            Me.DataGridViewForm_MyObjectDefinitionObjects.TabIndex = 4
            Me.DataGridViewForm_MyObjectDefinitionObjects.UseEmbeddedNavigator = False
            Me.DataGridViewForm_MyObjectDefinitionObjects.ViewCaptionHeight = -1
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Add, Me.ButtonItemActions_Delete, Me.ButtonItemActions_View})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(103, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(178, 92)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 1
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
            Me.ButtonItemActions_Add.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Add.Name = "ButtonItemActions_Add"
            Me.ButtonItemActions_Add.RibbonWordWrap = False
            Me.ButtonItemActions_Add.Stretch = True
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
            Me.ButtonItemActions_Delete.Stretch = True
            Me.ButtonItemActions_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Delete.Text = "Delete"
            '
            'ButtonItemActions_View
            '
            Me.ButtonItemActions_View.BeginGroup = True
            Me.ButtonItemActions_View.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_View.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_View.Name = "ButtonItemActions_View"
            Me.ButtonItemActions_View.RibbonWordWrap = False
            Me.ButtonItemActions_View.Stretch = True
            Me.ButtonItemActions_View.SubItemsExpandWidth = 14
            Me.ButtonItemActions_View.Text = "View"
            '
            'LabelForm_ObjectType
            '
            Me.LabelForm_ObjectType.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_ObjectType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_ObjectType.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_ObjectType.Name = "LabelForm_ObjectType"
            Me.LabelForm_ObjectType.Size = New System.Drawing.Size(92, 20)
            Me.LabelForm_ObjectType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_ObjectType.TabIndex = 8
            Me.LabelForm_ObjectType.Text = "Dashboard Type:"
            '
            'ComboBoxForm_ObjectType
            '
            Me.ComboBoxForm_ObjectType.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_ObjectType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_ObjectType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_ObjectType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_ObjectType.AutoFindItemInDataSource = False
            Me.ComboBoxForm_ObjectType.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_ObjectType.BookmarkingEnabled = False
            Me.ComboBoxForm_ObjectType.ClientCode = ""
            Me.ComboBoxForm_ObjectType.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.KeyValuePair
            Me.ComboBoxForm_ObjectType.DisableMouseWheel = False
            Me.ComboBoxForm_ObjectType.DisplayMember = "Value"
            Me.ComboBoxForm_ObjectType.DisplayName = ""
            Me.ComboBoxForm_ObjectType.DivisionCode = ""
            Me.ComboBoxForm_ObjectType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_ObjectType.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_ObjectType.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_ObjectType.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_ObjectType.FocusHighlightEnabled = True
            Me.ComboBoxForm_ObjectType.FormattingEnabled = True
            Me.ComboBoxForm_ObjectType.ItemHeight = 14
            Me.ComboBoxForm_ObjectType.Location = New System.Drawing.Point(110, 12)
            Me.ComboBoxForm_ObjectType.Name = "ComboBoxForm_ObjectType"
            Me.ComboBoxForm_ObjectType.ReadOnly = False
            Me.ComboBoxForm_ObjectType.SecurityEnabled = True
            Me.ComboBoxForm_ObjectType.Size = New System.Drawing.Size(591, 20)
            Me.ComboBoxForm_ObjectType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_ObjectType.TabIndex = 7
            Me.ComboBoxForm_ObjectType.TabOnEnter = True
            Me.ComboBoxForm_ObjectType.ValueMember = "Key"
            Me.ComboBoxForm_ObjectType.WatermarkText = "Please Select"
            '
            'DataGridViewForm_MyObjectDefinitions
            '
            Me.DataGridViewForm_MyObjectDefinitions.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewForm_MyObjectDefinitions.AllowDragAndDrop = False
            Me.DataGridViewForm_MyObjectDefinitions.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_MyObjectDefinitions.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_MyObjectDefinitions.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_MyObjectDefinitions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_MyObjectDefinitions.AutoFilterLookupColumns = False
            Me.DataGridViewForm_MyObjectDefinitions.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_MyObjectDefinitions.AutoUpdateViewCaption = True
            Me.DataGridViewForm_MyObjectDefinitions.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewForm_MyObjectDefinitions.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_MyObjectDefinitions.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_MyObjectDefinitions.ItemDescription = "My Dashboard Definition(s)"
            Me.DataGridViewForm_MyObjectDefinitions.Location = New System.Drawing.Point(309, 38)
            Me.DataGridViewForm_MyObjectDefinitions.MultiSelect = True
            Me.DataGridViewForm_MyObjectDefinitions.Name = "DataGridViewForm_MyObjectDefinitions"
            Me.DataGridViewForm_MyObjectDefinitions.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_MyObjectDefinitions.RunStandardValidation = True
            Me.DataGridViewForm_MyObjectDefinitions.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_MyObjectDefinitions.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_MyObjectDefinitions.Size = New System.Drawing.Size(392, 371)
            Me.DataGridViewForm_MyObjectDefinitions.TabIndex = 9
            Me.DataGridViewForm_MyObjectDefinitions.UseEmbeddedNavigator = False
            Me.DataGridViewForm_MyObjectDefinitions.ViewCaptionHeight = -1
            '
            'MyObjectDefinitionSetupForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(713, 421)
            Me.Controls.Add(Me.DataGridViewForm_MyObjectDefinitions)
            Me.Controls.Add(Me.LabelForm_ObjectType)
            Me.Controls.Add(Me.ComboBoxForm_ObjectType)
            Me.Controls.Add(Me.DataGridViewForm_MyObjectDefinitionObjects)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MyObjectDefinitionSetupForm"
            Me.Text = "My Dashboard Definition Maintenance"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewForm_MyObjectDefinitionObjects As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Add As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Delete As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_View As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents LabelForm_ObjectType As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_ObjectType As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents DataGridViewForm_MyObjectDefinitions As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
    End Class

End Namespace

