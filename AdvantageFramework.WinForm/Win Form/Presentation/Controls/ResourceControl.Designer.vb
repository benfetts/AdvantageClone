Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ResourceControl
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ResourceControl))
            Me.NumericInputControl_Priority = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelControl_Priority = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelControl_ResourceType = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxControl_Code = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelControl_Code = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DataGridViewControl_ResourceTasks = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TextBoxControl_Description = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelControl_Name = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxControl_Inactive = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.PanelControl_Control = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.SearchableComboBoxControl_ResourceType = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBox1View = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            CType(Me.NumericInputControl_Priority.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PanelControl_Control, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelControl_Control.SuspendLayout()
            CType(Me.SearchableComboBoxControl_ResourceType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBox1View, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'NumericInputControl_Priority
            '
            Me.NumericInputControl_Priority.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputControl_Priority.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Short]
            Me.NumericInputControl_Priority.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputControl_Priority.EnterMoveNextControl = True
            Me.NumericInputControl_Priority.Location = New System.Drawing.Point(56, 78)
            Me.NumericInputControl_Priority.Name = "NumericInputControl_Priority"
            Me.NumericInputControl_Priority.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.NumericInputControl_Priority.Properties.DisplayFormat.FormatString = "n0"
            Me.NumericInputControl_Priority.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputControl_Priority.Properties.EditFormat.FormatString = "n0"
            Me.NumericInputControl_Priority.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputControl_Priority.Properties.IsFloatValue = False
            Me.NumericInputControl_Priority.Properties.Mask.EditMask = "n0"
            Me.NumericInputControl_Priority.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputControl_Priority.Properties.MaxLength = 4
            Me.NumericInputControl_Priority.Properties.MaxValue = New Decimal(New Integer() {32767, 0, 0, 0})
            Me.NumericInputControl_Priority.Properties.MinValue = New Decimal(New Integer() {32768, 0, 0, -2147483648})
            Me.NumericInputControl_Priority.SecurityEnabled = True
            Me.NumericInputControl_Priority.Size = New System.Drawing.Size(75, 20)
            Me.NumericInputControl_Priority.TabIndex = 8
            '
            'LabelControl_Priority
            '
            Me.LabelControl_Priority.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_Priority.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_Priority.Location = New System.Drawing.Point(0, 78)
            Me.LabelControl_Priority.Name = "LabelControl_Priority"
            Me.LabelControl_Priority.Size = New System.Drawing.Size(50, 20)
            Me.LabelControl_Priority.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_Priority.TabIndex = 7
            Me.LabelControl_Priority.Text = "Priority:"
            '
            'LabelControl_ResourceType
            '
            Me.LabelControl_ResourceType.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_ResourceType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_ResourceType.Location = New System.Drawing.Point(0, 52)
            Me.LabelControl_ResourceType.Name = "LabelControl_ResourceType"
            Me.LabelControl_ResourceType.Size = New System.Drawing.Size(42, 20)
            Me.LabelControl_ResourceType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_ResourceType.TabIndex = 5
            Me.LabelControl_ResourceType.Text = "Type:"
            '
            'TextBoxControl_Code
            '
            '
            '
            '
            Me.TextBoxControl_Code.Border.Class = "TextBoxBorder"
            Me.TextBoxControl_Code.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxControl_Code.CheckSpellingOnValidate = False
            Me.TextBoxControl_Code.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxControl_Code.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxControl_Code.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxControl_Code.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxControl_Code.FocusHighlightEnabled = True
            Me.TextBoxControl_Code.Location = New System.Drawing.Point(56, 1)
            Me.TextBoxControl_Code.MaxFileSize = CType(0, Long)
            Me.TextBoxControl_Code.Name = "TextBoxControl_Code"
            Me.TextBoxControl_Code.SecurityEnabled = True
            Me.TextBoxControl_Code.ShowSpellCheckCompleteMessage = True
            Me.TextBoxControl_Code.Size = New System.Drawing.Size(65, 21)
            Me.TextBoxControl_Code.StartingFolderName = Nothing
            Me.TextBoxControl_Code.TabIndex = 1
            Me.TextBoxControl_Code.TabOnEnter = True
            '
            'LabelControl_Code
            '
            Me.LabelControl_Code.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_Code.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_Code.Location = New System.Drawing.Point(0, 0)
            Me.LabelControl_Code.Name = "LabelControl_Code"
            Me.LabelControl_Code.Size = New System.Drawing.Size(50, 20)
            Me.LabelControl_Code.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_Code.TabIndex = 0
            Me.LabelControl_Code.Text = "Code:"
            '
            'DataGridViewControl_ResourceTasks
            '
            Me.DataGridViewControl_ResourceTasks.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewControl_ResourceTasks.AllowDragAndDrop = False
            Me.DataGridViewControl_ResourceTasks.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewControl_ResourceTasks.AllowSelectGroupHeaderRow = True
            Me.DataGridViewControl_ResourceTasks.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewControl_ResourceTasks.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewControl_ResourceTasks.AutoFilterLookupColumns = False
            Me.DataGridViewControl_ResourceTasks.AutoloadRepositoryDatasource = True
            Me.DataGridViewControl_ResourceTasks.AutoUpdateViewCaption = True
            Me.DataGridViewControl_ResourceTasks.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewControl_ResourceTasks.DataSource = Nothing
            Me.DataGridViewControl_ResourceTasks.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewControl_ResourceTasks.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewControl_ResourceTasks.ItemDescription = ""
            Me.DataGridViewControl_ResourceTasks.Location = New System.Drawing.Point(0, 105)
            Me.DataGridViewControl_ResourceTasks.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewControl_ResourceTasks.MultiSelect = False
            Me.DataGridViewControl_ResourceTasks.Name = "DataGridViewControl_ResourceTasks"
            Me.DataGridViewControl_ResourceTasks.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewControl_ResourceTasks.RunStandardValidation = True
            Me.DataGridViewControl_ResourceTasks.ShowColumnMenuOnRightClick = False
            Me.DataGridViewControl_ResourceTasks.ShowSelectDeselectAllButtons = False
            Me.DataGridViewControl_ResourceTasks.Size = New System.Drawing.Size(603, 309)
            Me.DataGridViewControl_ResourceTasks.TabIndex = 9
            Me.DataGridViewControl_ResourceTasks.UseEmbeddedNavigator = False
            Me.DataGridViewControl_ResourceTasks.ViewCaptionHeight = -1
            '
            'TextBoxControl_Description
            '
            Me.TextBoxControl_Description.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxControl_Description.Border.Class = "TextBoxBorder"
            Me.TextBoxControl_Description.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxControl_Description.CheckSpellingOnValidate = False
            Me.TextBoxControl_Description.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxControl_Description.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxControl_Description.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxControl_Description.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxControl_Description.FocusHighlightEnabled = True
            Me.TextBoxControl_Description.Location = New System.Drawing.Point(56, 26)
            Me.TextBoxControl_Description.MaxFileSize = CType(0, Long)
            Me.TextBoxControl_Description.Name = "TextBoxControl_Description"
            Me.TextBoxControl_Description.SecurityEnabled = True
            Me.TextBoxControl_Description.ShowSpellCheckCompleteMessage = True
            Me.TextBoxControl_Description.Size = New System.Drawing.Size(547, 21)
            Me.TextBoxControl_Description.StartingFolderName = Nothing
            Me.TextBoxControl_Description.TabIndex = 4
            Me.TextBoxControl_Description.TabOnEnter = True
            '
            'LabelControl_Name
            '
            Me.LabelControl_Name.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_Name.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_Name.Location = New System.Drawing.Point(0, 26)
            Me.LabelControl_Name.Name = "LabelControl_Name"
            Me.LabelControl_Name.Size = New System.Drawing.Size(42, 20)
            Me.LabelControl_Name.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_Name.TabIndex = 3
            Me.LabelControl_Name.Text = "Name:"
            '
            'CheckBoxControl_Inactive
            '
            Me.CheckBoxControl_Inactive.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxControl_Inactive.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxControl_Inactive.CheckValue = 0
            Me.CheckBoxControl_Inactive.CheckValueChecked = 1
            Me.CheckBoxControl_Inactive.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxControl_Inactive.CheckValueUnchecked = 0
            Me.CheckBoxControl_Inactive.ChildControls = CType(resources.GetObject("CheckBoxControl_Inactive.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxControl_Inactive.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxControl_Inactive.Location = New System.Drawing.Point(540, 0)
            Me.CheckBoxControl_Inactive.Name = "CheckBoxControl_Inactive"
            Me.CheckBoxControl_Inactive.OldestSibling = Nothing
            Me.CheckBoxControl_Inactive.SecurityEnabled = True
            Me.CheckBoxControl_Inactive.SiblingControls = CType(resources.GetObject("CheckBoxControl_Inactive.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxControl_Inactive.Size = New System.Drawing.Size(63, 23)
            Me.CheckBoxControl_Inactive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxControl_Inactive.TabIndex = 2
            Me.CheckBoxControl_Inactive.TabOnEnter = True
            Me.CheckBoxControl_Inactive.Text = "Inactive"
            '
            'PanelControl_Control
            '
            Me.PanelControl_Control.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelControl_Control.Controls.Add(Me.SearchableComboBoxControl_ResourceType)
            Me.PanelControl_Control.Controls.Add(Me.NumericInputControl_Priority)
            Me.PanelControl_Control.Controls.Add(Me.LabelControl_Code)
            Me.PanelControl_Control.Controls.Add(Me.LabelControl_Priority)
            Me.PanelControl_Control.Controls.Add(Me.CheckBoxControl_Inactive)
            Me.PanelControl_Control.Controls.Add(Me.LabelControl_Name)
            Me.PanelControl_Control.Controls.Add(Me.TextBoxControl_Description)
            Me.PanelControl_Control.Controls.Add(Me.LabelControl_ResourceType)
            Me.PanelControl_Control.Controls.Add(Me.DataGridViewControl_ResourceTasks)
            Me.PanelControl_Control.Controls.Add(Me.TextBoxControl_Code)
            Me.PanelControl_Control.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelControl_Control.Location = New System.Drawing.Point(0, 0)
            Me.PanelControl_Control.Margin = New System.Windows.Forms.Padding(2)
            Me.PanelControl_Control.Name = "PanelControl_Control"
            Me.PanelControl_Control.Size = New System.Drawing.Size(603, 414)
            Me.PanelControl_Control.TabIndex = 45
            '
            'SearchableComboBoxControl_ResourceType
            '
            Me.SearchableComboBoxControl_ResourceType.ActiveFilterString = ""
            Me.SearchableComboBoxControl_ResourceType.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxControl_ResourceType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxControl_ResourceType.AutoFillMode = False
            Me.SearchableComboBoxControl_ResourceType.BookmarkingEnabled = False
            Me.SearchableComboBoxControl_ResourceType.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.ResourceType
            Me.SearchableComboBoxControl_ResourceType.DataSource = Nothing
            Me.SearchableComboBoxControl_ResourceType.DisableMouseWheel = False
            Me.SearchableComboBoxControl_ResourceType.DisplayName = ""
            Me.SearchableComboBoxControl_ResourceType.EnterMoveNextControl = True
            Me.SearchableComboBoxControl_ResourceType.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxControl_ResourceType.Location = New System.Drawing.Point(56, 52)
            Me.SearchableComboBoxControl_ResourceType.Name = "SearchableComboBoxControl_ResourceType"
            Me.SearchableComboBoxControl_ResourceType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxControl_ResourceType.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxControl_ResourceType.Properties.NullText = "Select Resource Type"
            Me.SearchableComboBoxControl_ResourceType.Properties.ValueMember = "Code"
            Me.SearchableComboBoxControl_ResourceType.Properties.View = Me.SearchableComboBox1View
            Me.SearchableComboBoxControl_ResourceType.SecurityEnabled = True
            Me.SearchableComboBoxControl_ResourceType.SelectedValue = Nothing
            Me.SearchableComboBoxControl_ResourceType.Size = New System.Drawing.Size(547, 20)
            Me.SearchableComboBoxControl_ResourceType.TabIndex = 6
            '
            'SearchableComboBox1View
            '
            Me.SearchableComboBox1View.AFActiveFilterString = ""
            Me.SearchableComboBox1View.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBox1View.AutoFilterLookupColumns = False
            Me.SearchableComboBox1View.AutoloadRepositoryDatasource = True
            Me.SearchableComboBox1View.DataSourceClearing = False
            Me.SearchableComboBox1View.EnableDisabledRows = False
            Me.SearchableComboBox1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBox1View.Name = "SearchableComboBox1View"
            Me.SearchableComboBox1View.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBox1View.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBox1View.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBox1View.RunStandardValidation = True
            '
            'ResourceControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.PanelControl_Control)
            Me.Name = "ResourceControl"
            Me.Size = New System.Drawing.Size(603, 414)
            CType(Me.NumericInputControl_Priority.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PanelControl_Control, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelControl_Control.ResumeLayout(False)
            CType(Me.SearchableComboBoxControl_ResourceType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBox1View, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents CheckBoxControl_Inactive As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelControl_Name As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxControl_Description As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents DataGridViewControl_ResourceTasks As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents LabelControl_Code As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxControl_Code As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelControl_ResourceType As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelControl_Priority As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents NumericInputControl_Priority As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents PanelControl_Control As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents SearchableComboBoxControl_ResourceType As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBox1View As AdvantageFramework.WinForm.Presentation.Controls.GridView

    End Class

End Namespace
