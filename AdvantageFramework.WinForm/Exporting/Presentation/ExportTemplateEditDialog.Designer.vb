Namespace Exporting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ExportTemplateEditDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ExportTemplateEditDialog))
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Add = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_Name = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxForm_Name = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.ButtonForm_Update = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.PanelForm_TemplateDetails = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.PanelTemplateDetails_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.ButtonRightSection_MoveDown = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonRightSection_MoveUp = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonRightSection_RemoveTemplateDetail = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonRightSection_AddTemplateDetail = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DataGridViewRightSection_TemplateDetails = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ExpandableSplitterRightSection_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelTemplateDetails_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewLeftSection_AvailableTemplateDetails = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.LabelForm_FileType = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.RadioButtonForm_CSV = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonForm_Fixed = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.LabelForm_DefaultDirectory = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxForm_DefaultDirectory = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.CheckBoxForm_IncludeColumnHeaders = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            CType(Me.PanelForm_TemplateDetails, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_TemplateDetails.SuspendLayout()
            CType(Me.PanelTemplateDetails_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelTemplateDetails_RightSection.SuspendLayout()
            CType(Me.PanelTemplateDetails_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelTemplateDetails_LeftSection.SuspendLayout()
            Me.SuspendLayout()
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(591, 457)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 11
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ButtonForm_Add
            '
            Me.ButtonForm_Add.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Add.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Add.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Add.Location = New System.Drawing.Point(510, 457)
            Me.ButtonForm_Add.Name = "ButtonForm_Add"
            Me.ButtonForm_Add.SecurityEnabled = True
            Me.ButtonForm_Add.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Add.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Add.TabIndex = 10
            Me.ButtonForm_Add.Text = "Add"
            '
            'LabelForm_Name
            '
            Me.LabelForm_Name.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Name.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Name.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_Name.Name = "LabelForm_Name"
            Me.LabelForm_Name.Size = New System.Drawing.Size(99, 20)
            Me.LabelForm_Name.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Name.TabIndex = 0
            Me.LabelForm_Name.Text = "Name:"
            '
            'TextBoxForm_Name
            '
            Me.TextBoxForm_Name.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxForm_Name.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxForm_Name.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Name.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Name.CheckSpellingOnValidate = False
            Me.TextBoxForm_Name.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Name.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxForm_Name.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Name.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Name.FocusHighlightEnabled = True
            Me.TextBoxForm_Name.ForeColor = System.Drawing.Color.Black
            Me.TextBoxForm_Name.Location = New System.Drawing.Point(117, 12)
            Me.TextBoxForm_Name.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Name.Name = "TextBoxForm_Name"
            Me.TextBoxForm_Name.SecurityEnabled = True
            Me.TextBoxForm_Name.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Name.Size = New System.Drawing.Size(376, 20)
            Me.TextBoxForm_Name.StartingFolderName = Nothing
            Me.TextBoxForm_Name.TabIndex = 1
            Me.TextBoxForm_Name.TabOnEnter = True
            '
            'ButtonForm_Update
            '
            Me.ButtonForm_Update.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Update.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Update.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Update.Location = New System.Drawing.Point(510, 457)
            Me.ButtonForm_Update.Name = "ButtonForm_Update"
            Me.ButtonForm_Update.SecurityEnabled = True
            Me.ButtonForm_Update.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Update.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Update.TabIndex = 9
            Me.ButtonForm_Update.Text = "Update"
            '
            'PanelForm_TemplateDetails
            '
            Me.PanelForm_TemplateDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PanelForm_TemplateDetails.Controls.Add(Me.PanelTemplateDetails_RightSection)
            Me.PanelForm_TemplateDetails.Controls.Add(Me.ExpandableSplitterRightSection_LeftRight)
            Me.PanelForm_TemplateDetails.Controls.Add(Me.PanelTemplateDetails_LeftSection)
            Me.PanelForm_TemplateDetails.Location = New System.Drawing.Point(12, 65)
            Me.PanelForm_TemplateDetails.Name = "PanelForm_TemplateDetails"
            Me.PanelForm_TemplateDetails.Size = New System.Drawing.Size(654, 386)
            Me.PanelForm_TemplateDetails.TabIndex = 8
            '
            'PanelTemplateDetails_RightSection
            '
            Me.PanelTemplateDetails_RightSection.Controls.Add(Me.ButtonRightSection_MoveDown)
            Me.PanelTemplateDetails_RightSection.Controls.Add(Me.ButtonRightSection_MoveUp)
            Me.PanelTemplateDetails_RightSection.Controls.Add(Me.ButtonRightSection_RemoveTemplateDetail)
            Me.PanelTemplateDetails_RightSection.Controls.Add(Me.ButtonRightSection_AddTemplateDetail)
            Me.PanelTemplateDetails_RightSection.Controls.Add(Me.DataGridViewRightSection_TemplateDetails)
            Me.PanelTemplateDetails_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelTemplateDetails_RightSection.Location = New System.Drawing.Point(205, 2)
            Me.PanelTemplateDetails_RightSection.Name = "PanelTemplateDetails_RightSection"
            Me.PanelTemplateDetails_RightSection.Size = New System.Drawing.Size(447, 382)
            Me.PanelTemplateDetails_RightSection.TabIndex = 0
            '
            'ButtonRightSection_MoveDown
            '
            Me.ButtonRightSection_MoveDown.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSection_MoveDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonRightSection_MoveDown.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSection_MoveDown.Location = New System.Drawing.Point(369, 31)
            Me.ButtonRightSection_MoveDown.Name = "ButtonRightSection_MoveDown"
            Me.ButtonRightSection_MoveDown.SecurityEnabled = True
            Me.ButtonRightSection_MoveDown.Size = New System.Drawing.Size(75, 20)
            Me.ButtonRightSection_MoveDown.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSection_MoveDown.TabIndex = 4
            Me.ButtonRightSection_MoveDown.Text = "Move Down"
            '
            'ButtonRightSection_MoveUp
            '
            Me.ButtonRightSection_MoveUp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSection_MoveUp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonRightSection_MoveUp.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSection_MoveUp.Location = New System.Drawing.Point(369, 5)
            Me.ButtonRightSection_MoveUp.Name = "ButtonRightSection_MoveUp"
            Me.ButtonRightSection_MoveUp.SecurityEnabled = True
            Me.ButtonRightSection_MoveUp.Size = New System.Drawing.Size(75, 20)
            Me.ButtonRightSection_MoveUp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSection_MoveUp.TabIndex = 3
            Me.ButtonRightSection_MoveUp.Text = "Move Up"
            '
            'ButtonRightSection_RemoveTemplateDetail
            '
            Me.ButtonRightSection_RemoveTemplateDetail.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSection_RemoveTemplateDetail.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSection_RemoveTemplateDetail.Location = New System.Drawing.Point(6, 31)
            Me.ButtonRightSection_RemoveTemplateDetail.Name = "ButtonRightSection_RemoveTemplateDetail"
            Me.ButtonRightSection_RemoveTemplateDetail.SecurityEnabled = True
            Me.ButtonRightSection_RemoveTemplateDetail.Size = New System.Drawing.Size(75, 20)
            Me.ButtonRightSection_RemoveTemplateDetail.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSection_RemoveTemplateDetail.TabIndex = 1
            Me.ButtonRightSection_RemoveTemplateDetail.Text = "<"
            '
            'ButtonRightSection_AddTemplateDetail
            '
            Me.ButtonRightSection_AddTemplateDetail.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSection_AddTemplateDetail.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSection_AddTemplateDetail.Location = New System.Drawing.Point(6, 5)
            Me.ButtonRightSection_AddTemplateDetail.Name = "ButtonRightSection_AddTemplateDetail"
            Me.ButtonRightSection_AddTemplateDetail.SecurityEnabled = True
            Me.ButtonRightSection_AddTemplateDetail.Size = New System.Drawing.Size(75, 20)
            Me.ButtonRightSection_AddTemplateDetail.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSection_AddTemplateDetail.TabIndex = 0
            Me.ButtonRightSection_AddTemplateDetail.Text = ">"
            '
            'DataGridViewRightSection_TemplateDetails
            '
            Me.DataGridViewRightSection_TemplateDetails.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewRightSection_TemplateDetails.AllowDragAndDrop = False
            Me.DataGridViewRightSection_TemplateDetails.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewRightSection_TemplateDetails.AllowSelectGroupHeaderRow = True
            Me.DataGridViewRightSection_TemplateDetails.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewRightSection_TemplateDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewRightSection_TemplateDetails.AutoFilterLookupColumns = False
            Me.DataGridViewRightSection_TemplateDetails.AutoloadRepositoryDatasource = True
            Me.DataGridViewRightSection_TemplateDetails.AutoUpdateViewCaption = True
            Me.DataGridViewRightSection_TemplateDetails.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewRightSection_TemplateDetails.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewRightSection_TemplateDetails.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewRightSection_TemplateDetails.ItemDescription = "Field(s)"
            Me.DataGridViewRightSection_TemplateDetails.Location = New System.Drawing.Point(87, 0)
            Me.DataGridViewRightSection_TemplateDetails.MultiSelect = True
            Me.DataGridViewRightSection_TemplateDetails.Name = "DataGridViewRightSection_TemplateDetails"
            Me.DataGridViewRightSection_TemplateDetails.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewRightSection_TemplateDetails.RunStandardValidation = False
            Me.DataGridViewRightSection_TemplateDetails.ShowColumnMenuOnRightClick = False
            Me.DataGridViewRightSection_TemplateDetails.ShowSelectDeselectAllButtons = False
            Me.DataGridViewRightSection_TemplateDetails.Size = New System.Drawing.Size(276, 382)
            Me.DataGridViewRightSection_TemplateDetails.TabIndex = 2
            Me.DataGridViewRightSection_TemplateDetails.UseEmbeddedNavigator = False
            Me.DataGridViewRightSection_TemplateDetails.ViewCaptionHeight = -1
            '
            'ExpandableSplitterRightSection_LeftRight
            '
            Me.ExpandableSplitterRightSection_LeftRight.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterRightSection_LeftRight.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterRightSection_LeftRight.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterRightSection_LeftRight.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterRightSection_LeftRight.Expandable = False
            Me.ExpandableSplitterRightSection_LeftRight.ExpandableControl = Me.PanelTemplateDetails_LeftSection
            Me.ExpandableSplitterRightSection_LeftRight.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterRightSection_LeftRight.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterRightSection_LeftRight.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterRightSection_LeftRight.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterRightSection_LeftRight.ForeColor = System.Drawing.Color.Black
            Me.ExpandableSplitterRightSection_LeftRight.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterRightSection_LeftRight.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterRightSection_LeftRight.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterRightSection_LeftRight.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterRightSection_LeftRight.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterRightSection_LeftRight.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterRightSection_LeftRight.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterRightSection_LeftRight.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterRightSection_LeftRight.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterRightSection_LeftRight.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterRightSection_LeftRight.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterRightSection_LeftRight.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterRightSection_LeftRight.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterRightSection_LeftRight.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterRightSection_LeftRight.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterRightSection_LeftRight.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterRightSection_LeftRight.Location = New System.Drawing.Point(199, 2)
            Me.ExpandableSplitterRightSection_LeftRight.Name = "ExpandableSplitterRightSection_LeftRight"
            Me.ExpandableSplitterRightSection_LeftRight.Size = New System.Drawing.Size(6, 382)
            Me.ExpandableSplitterRightSection_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterRightSection_LeftRight.TabIndex = 1
            Me.ExpandableSplitterRightSection_LeftRight.TabStop = False
            '
            'PanelTemplateDetails_LeftSection
            '
            Me.PanelTemplateDetails_LeftSection.Controls.Add(Me.DataGridViewLeftSection_AvailableTemplateDetails)
            Me.PanelTemplateDetails_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelTemplateDetails_LeftSection.Location = New System.Drawing.Point(2, 2)
            Me.PanelTemplateDetails_LeftSection.Name = "PanelTemplateDetails_LeftSection"
            Me.PanelTemplateDetails_LeftSection.Size = New System.Drawing.Size(197, 382)
            Me.PanelTemplateDetails_LeftSection.TabIndex = 0
            '
            'DataGridViewLeftSection_AvailableTemplateDetails
            '
            Me.DataGridViewLeftSection_AvailableTemplateDetails.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewLeftSection_AvailableTemplateDetails.AllowDragAndDrop = False
            Me.DataGridViewLeftSection_AvailableTemplateDetails.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewLeftSection_AvailableTemplateDetails.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_AvailableTemplateDetails.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewLeftSection_AvailableTemplateDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_AvailableTemplateDetails.AutoFilterLookupColumns = False
            Me.DataGridViewLeftSection_AvailableTemplateDetails.AutoloadRepositoryDatasource = True
            Me.DataGridViewLeftSection_AvailableTemplateDetails.AutoUpdateViewCaption = True
            Me.DataGridViewLeftSection_AvailableTemplateDetails.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewLeftSection_AvailableTemplateDetails.DataSource = Nothing
            Me.DataGridViewLeftSection_AvailableTemplateDetails.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewLeftSection_AvailableTemplateDetails.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_AvailableTemplateDetails.ItemDescription = ""
            Me.DataGridViewLeftSection_AvailableTemplateDetails.Location = New System.Drawing.Point(0, 0)
            Me.DataGridViewLeftSection_AvailableTemplateDetails.MultiSelect = True
            Me.DataGridViewLeftSection_AvailableTemplateDetails.Name = "DataGridViewLeftSection_AvailableTemplateDetails"
            Me.DataGridViewLeftSection_AvailableTemplateDetails.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_AvailableTemplateDetails.RunStandardValidation = True
            Me.DataGridViewLeftSection_AvailableTemplateDetails.ShowColumnMenuOnRightClick = False
            Me.DataGridViewLeftSection_AvailableTemplateDetails.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_AvailableTemplateDetails.Size = New System.Drawing.Size(191, 377)
            Me.DataGridViewLeftSection_AvailableTemplateDetails.TabIndex = 0
            Me.DataGridViewLeftSection_AvailableTemplateDetails.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_AvailableTemplateDetails.ViewCaptionHeight = -1
            '
            'LabelForm_FileType
            '
            Me.LabelForm_FileType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_FileType.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_FileType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_FileType.Location = New System.Drawing.Point(499, 12)
            Me.LabelForm_FileType.Name = "LabelForm_FileType"
            Me.LabelForm_FileType.Size = New System.Drawing.Size(54, 20)
            Me.LabelForm_FileType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_FileType.TabIndex = 2
            Me.LabelForm_FileType.Text = "File Type:"
            '
            'RadioButtonForm_CSV
            '
            Me.RadioButtonForm_CSV.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonForm_CSV.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonForm_CSV.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonForm_CSV.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonForm_CSV.Checked = True
            Me.RadioButtonForm_CSV.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonForm_CSV.CheckValue = "Y"
            Me.RadioButtonForm_CSV.Location = New System.Drawing.Point(559, 12)
            Me.RadioButtonForm_CSV.Name = "RadioButtonForm_CSV"
            Me.RadioButtonForm_CSV.SecurityEnabled = True
            Me.RadioButtonForm_CSV.Size = New System.Drawing.Size(47, 20)
            Me.RadioButtonForm_CSV.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonForm_CSV.TabIndex = 3
            Me.RadioButtonForm_CSV.Text = "CSV"
            '
            'RadioButtonForm_Fixed
            '
            Me.RadioButtonForm_Fixed.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RadioButtonForm_Fixed.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonForm_Fixed.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonForm_Fixed.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonForm_Fixed.Location = New System.Drawing.Point(612, 12)
            Me.RadioButtonForm_Fixed.Name = "RadioButtonForm_Fixed"
            Me.RadioButtonForm_Fixed.SecurityEnabled = True
            Me.RadioButtonForm_Fixed.Size = New System.Drawing.Size(52, 20)
            Me.RadioButtonForm_Fixed.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonForm_Fixed.TabIndex = 4
            Me.RadioButtonForm_Fixed.TabStop = False
            Me.RadioButtonForm_Fixed.Text = "Fixed"
            '
            'LabelForm_DefaultDirectory
            '
            Me.LabelForm_DefaultDirectory.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_DefaultDirectory.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_DefaultDirectory.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_DefaultDirectory.Name = "LabelForm_DefaultDirectory"
            Me.LabelForm_DefaultDirectory.Size = New System.Drawing.Size(99, 20)
            Me.LabelForm_DefaultDirectory.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_DefaultDirectory.TabIndex = 5
            Me.LabelForm_DefaultDirectory.Text = "Default Directory:"
            '
            'TextBoxForm_DefaultDirectory
            '
            Me.TextBoxForm_DefaultDirectory.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxForm_DefaultDirectory.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_DefaultDirectory.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_DefaultDirectory.ButtonCustom.Visible = True
            Me.TextBoxForm_DefaultDirectory.CheckSpellingOnValidate = False
            Me.TextBoxForm_DefaultDirectory.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.Folder
            Me.TextBoxForm_DefaultDirectory.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxForm_DefaultDirectory.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.CSV
            Me.TextBoxForm_DefaultDirectory.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_DefaultDirectory.FocusHighlightEnabled = True
            Me.TextBoxForm_DefaultDirectory.Location = New System.Drawing.Point(117, 38)
            Me.TextBoxForm_DefaultDirectory.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_DefaultDirectory.Name = "TextBoxForm_DefaultDirectory"
            Me.TextBoxForm_DefaultDirectory.SecurityEnabled = True
            Me.TextBoxForm_DefaultDirectory.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_DefaultDirectory.Size = New System.Drawing.Size(376, 20)
            Me.TextBoxForm_DefaultDirectory.StartingFolderName = Nothing
            Me.TextBoxForm_DefaultDirectory.TabIndex = 6
            Me.TextBoxForm_DefaultDirectory.TabOnEnter = True
            '
            'CheckBoxForm_IncludeColumnHeaders
            '
            Me.CheckBoxForm_IncludeColumnHeaders.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxForm_IncludeColumnHeaders.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_IncludeColumnHeaders.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_IncludeColumnHeaders.ChildControls = CType(resources.GetObject("CheckBoxForm_IncludeColumnHeaders.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_IncludeColumnHeaders.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_IncludeColumnHeaders.Location = New System.Drawing.Point(499, 38)
            Me.CheckBoxForm_IncludeColumnHeaders.Name = "CheckBoxForm_IncludeColumnHeaders"
            Me.CheckBoxForm_IncludeColumnHeaders.OldestSibling = Nothing
            Me.CheckBoxForm_IncludeColumnHeaders.SecurityEnabled = True
            Me.CheckBoxForm_IncludeColumnHeaders.SiblingControls = CType(resources.GetObject("CheckBoxForm_IncludeColumnHeaders.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_IncludeColumnHeaders.Size = New System.Drawing.Size(165, 20)
            Me.CheckBoxForm_IncludeColumnHeaders.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_IncludeColumnHeaders.TabIndex = 7
            Me.CheckBoxForm_IncludeColumnHeaders.Text = "Include Column Headers"
            '
            'ExportTemplateEditDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(678, 489)
            Me.Controls.Add(Me.CheckBoxForm_IncludeColumnHeaders)
            Me.Controls.Add(Me.TextBoxForm_DefaultDirectory)
            Me.Controls.Add(Me.LabelForm_DefaultDirectory)
            Me.Controls.Add(Me.RadioButtonForm_Fixed)
            Me.Controls.Add(Me.RadioButtonForm_CSV)
            Me.Controls.Add(Me.LabelForm_FileType)
            Me.Controls.Add(Me.PanelForm_TemplateDetails)
            Me.Controls.Add(Me.ButtonForm_Update)
            Me.Controls.Add(Me.TextBoxForm_Name)
            Me.Controls.Add(Me.LabelForm_Name)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.ButtonForm_Add)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "ExportTemplateEditDialog"
            Me.Text = "Export Template"
            CType(Me.PanelForm_TemplateDetails, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_TemplateDetails.ResumeLayout(False)
            CType(Me.PanelTemplateDetails_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelTemplateDetails_RightSection.ResumeLayout(False)
            CType(Me.PanelTemplateDetails_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelTemplateDetails_LeftSection.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Add As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_Name As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_Name As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents ButtonForm_Update As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents PanelForm_TemplateDetails As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents PanelTemplateDetails_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents ButtonRightSection_RemoveTemplateDetail As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonRightSection_AddTemplateDetail As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents DataGridViewRightSection_TemplateDetails As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ExpandableSplitterRightSection_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelTemplateDetails_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewLeftSection_AvailableTemplateDetails As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents LabelForm_FileType As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents RadioButtonForm_CSV As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonForm_Fixed As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents ButtonRightSection_MoveDown As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonRightSection_MoveUp As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_DefaultDirectory As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_DefaultDirectory As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents CheckBoxForm_IncludeColumnHeaders As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
    End Class

End Namespace