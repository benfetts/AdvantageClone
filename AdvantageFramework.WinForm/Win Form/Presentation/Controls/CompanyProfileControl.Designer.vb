Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class CompanyProfileControl
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
            Me.DataGridViewCompanyProfile_Affiliations = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.CheckBoxCompanyProfile_Reference = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxCompanyProfile_CaseStudy = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.TextBoxCompanyProfile_Notes = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.NumericInputCompanyProfile_NumEmployees = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputCompanyProfile_Revenue = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.SearchableComboBoxCompanyProfile_Region = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewCompanyProfile_Region = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxCompanyProfile_Specialty = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewCompanyProfile_Specialty = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelCompanyProfile_Notes = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCompanyProfile_NumberOfEmployees = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCompanyProfile_Revenue = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCompanyProfile_Region = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCompanyProfile_Specialty = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxCompanyProfile_Industry = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewControl_Vendor = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelCompanyProfile_Industry = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.PanelControl_Control = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.LabelCompanyProfile_ClientType3 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCompanyProfile_ClientType2 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCompanyProfile_ClientType1 = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCompanyProfile_TurnoverPercent = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxCompanyProfile_ClientType3 = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView3 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxCompanyProfile_ClientType2 = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView2 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxCompanyProfile_ClientType1 = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView1 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.NumericInputCompanyProfile_TurnoverPercent = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            CType(Me.NumericInputCompanyProfile_NumEmployees.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputCompanyProfile_Revenue.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxCompanyProfile_Region.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewCompanyProfile_Region, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxCompanyProfile_Specialty.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewCompanyProfile_Specialty, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxCompanyProfile_Industry.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewControl_Vendor, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PanelControl_Control, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelControl_Control.SuspendLayout()
            CType(Me.SearchableComboBoxCompanyProfile_ClientType3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxCompanyProfile_ClientType2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxCompanyProfile_ClientType1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputCompanyProfile_TurnoverPercent.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'DataGridViewCompanyProfile_Affiliations
            '
            Me.DataGridViewCompanyProfile_Affiliations.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewCompanyProfile_Affiliations.AllowDragAndDrop = False
            Me.DataGridViewCompanyProfile_Affiliations.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewCompanyProfile_Affiliations.AllowSelectGroupHeaderRow = True
            Me.DataGridViewCompanyProfile_Affiliations.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewCompanyProfile_Affiliations.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewCompanyProfile_Affiliations.AutoFilterLookupColumns = False
            Me.DataGridViewCompanyProfile_Affiliations.AutoloadRepositoryDatasource = True
            Me.DataGridViewCompanyProfile_Affiliations.AutoUpdateViewCaption = True
            Me.DataGridViewCompanyProfile_Affiliations.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewCompanyProfile_Affiliations.DataSource = Nothing
            Me.DataGridViewCompanyProfile_Affiliations.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewCompanyProfile_Affiliations.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewCompanyProfile_Affiliations.ItemDescription = ""
            Me.DataGridViewCompanyProfile_Affiliations.Location = New System.Drawing.Point(394, 0)
            Me.DataGridViewCompanyProfile_Affiliations.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewCompanyProfile_Affiliations.MultiSelect = False
            Me.DataGridViewCompanyProfile_Affiliations.Name = "DataGridViewCompanyProfile_Affiliations"
            Me.DataGridViewCompanyProfile_Affiliations.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewCompanyProfile_Affiliations.RunStandardValidation = True
            Me.DataGridViewCompanyProfile_Affiliations.ShowColumnMenuOnRightClick = False
            Me.DataGridViewCompanyProfile_Affiliations.ShowSelectDeselectAllButtons = False
            Me.DataGridViewCompanyProfile_Affiliations.Size = New System.Drawing.Size(208, 176)
            Me.DataGridViewCompanyProfile_Affiliations.TabIndex = 24
            Me.DataGridViewCompanyProfile_Affiliations.UseEmbeddedNavigator = False
            Me.DataGridViewCompanyProfile_Affiliations.ViewCaptionHeight = -1
            '
            'CheckBoxCompanyProfile_Reference
            '
            Me.CheckBoxCompanyProfile_Reference.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxCompanyProfile_Reference.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxCompanyProfile_Reference.CheckValue = 0
            Me.CheckBoxCompanyProfile_Reference.CheckValueChecked = 1
            Me.CheckBoxCompanyProfile_Reference.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxCompanyProfile_Reference.CheckValueUnchecked = 0
            Me.CheckBoxCompanyProfile_Reference.ChildControls = Nothing
            Me.CheckBoxCompanyProfile_Reference.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxCompanyProfile_Reference.Location = New System.Drawing.Point(97, 156)
            Me.CheckBoxCompanyProfile_Reference.Name = "CheckBoxCompanyProfile_Reference"
            Me.CheckBoxCompanyProfile_Reference.OldestSibling = Nothing
            Me.CheckBoxCompanyProfile_Reference.SecurityEnabled = True
            Me.CheckBoxCompanyProfile_Reference.SiblingControls = Nothing
            Me.CheckBoxCompanyProfile_Reference.Size = New System.Drawing.Size(127, 20)
            Me.CheckBoxCompanyProfile_Reference.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxCompanyProfile_Reference.TabIndex = 11
            Me.CheckBoxCompanyProfile_Reference.TabOnEnter = True
            Me.CheckBoxCompanyProfile_Reference.Text = "Use as Reference"
            '
            'CheckBoxCompanyProfile_CaseStudy
            '
            Me.CheckBoxCompanyProfile_CaseStudy.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxCompanyProfile_CaseStudy.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxCompanyProfile_CaseStudy.CheckValue = 0
            Me.CheckBoxCompanyProfile_CaseStudy.CheckValueChecked = 1
            Me.CheckBoxCompanyProfile_CaseStudy.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxCompanyProfile_CaseStudy.CheckValueUnchecked = 0
            Me.CheckBoxCompanyProfile_CaseStudy.ChildControls = Nothing
            Me.CheckBoxCompanyProfile_CaseStudy.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxCompanyProfile_CaseStudy.Location = New System.Drawing.Point(97, 130)
            Me.CheckBoxCompanyProfile_CaseStudy.Name = "CheckBoxCompanyProfile_CaseStudy"
            Me.CheckBoxCompanyProfile_CaseStudy.OldestSibling = Nothing
            Me.CheckBoxCompanyProfile_CaseStudy.SecurityEnabled = True
            Me.CheckBoxCompanyProfile_CaseStudy.SiblingControls = Nothing
            Me.CheckBoxCompanyProfile_CaseStudy.Size = New System.Drawing.Size(127, 20)
            Me.CheckBoxCompanyProfile_CaseStudy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxCompanyProfile_CaseStudy.TabIndex = 10
            Me.CheckBoxCompanyProfile_CaseStudy.TabOnEnter = True
            Me.CheckBoxCompanyProfile_CaseStudy.Text = "Case Study Done"
            '
            'TextBoxCompanyProfile_Notes
            '
            Me.TextBoxCompanyProfile_Notes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxCompanyProfile_Notes.Border.Class = "TextBoxBorder"
            Me.TextBoxCompanyProfile_Notes.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxCompanyProfile_Notes.CheckSpellingOnValidate = False
            Me.TextBoxCompanyProfile_Notes.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxCompanyProfile_Notes.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxCompanyProfile_Notes.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxCompanyProfile_Notes.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxCompanyProfile_Notes.FocusHighlightEnabled = True
            Me.TextBoxCompanyProfile_Notes.Location = New System.Drawing.Point(97, 286)
            Me.TextBoxCompanyProfile_Notes.MaxFileSize = CType(0, Long)
            Me.TextBoxCompanyProfile_Notes.Multiline = True
            Me.TextBoxCompanyProfile_Notes.Name = "TextBoxCompanyProfile_Notes"
            Me.TextBoxCompanyProfile_Notes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.TextBoxCompanyProfile_Notes.SecurityEnabled = True
            Me.TextBoxCompanyProfile_Notes.ShowSpellCheckCompleteMessage = True
            Me.TextBoxCompanyProfile_Notes.Size = New System.Drawing.Size(506, 183)
            Me.TextBoxCompanyProfile_Notes.StartingFolderName = Nothing
            Me.TextBoxCompanyProfile_Notes.TabIndex = 23
            Me.TextBoxCompanyProfile_Notes.TabOnEnter = True
            '
            'NumericInputCompanyProfile_NumEmployees
            '
            Me.NumericInputCompanyProfile_NumEmployees.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputCompanyProfile_NumEmployees.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputCompanyProfile_NumEmployees.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputCompanyProfile_NumEmployees.EnterMoveNextControl = True
            Me.NumericInputCompanyProfile_NumEmployees.Location = New System.Drawing.Point(97, 104)
            Me.NumericInputCompanyProfile_NumEmployees.Name = "NumericInputCompanyProfile_NumEmployees"
            Me.NumericInputCompanyProfile_NumEmployees.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputCompanyProfile_NumEmployees.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputCompanyProfile_NumEmployees.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputCompanyProfile_NumEmployees.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputCompanyProfile_NumEmployees.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputCompanyProfile_NumEmployees.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputCompanyProfile_NumEmployees.Properties.IsFloatValue = False
            Me.NumericInputCompanyProfile_NumEmployees.Properties.Mask.EditMask = "f0"
            Me.NumericInputCompanyProfile_NumEmployees.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputCompanyProfile_NumEmployees.Properties.MaxLength = 11
            Me.NumericInputCompanyProfile_NumEmployees.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputCompanyProfile_NumEmployees.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputCompanyProfile_NumEmployees.SecurityEnabled = True
            Me.NumericInputCompanyProfile_NumEmployees.Size = New System.Drawing.Size(129, 20)
            Me.NumericInputCompanyProfile_NumEmployees.TabIndex = 9
            '
            'NumericInputCompanyProfile_Revenue
            '
            Me.NumericInputCompanyProfile_Revenue.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputCompanyProfile_Revenue.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputCompanyProfile_Revenue.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputCompanyProfile_Revenue.EnterMoveNextControl = True
            Me.NumericInputCompanyProfile_Revenue.Location = New System.Drawing.Point(97, 77)
            Me.NumericInputCompanyProfile_Revenue.Name = "NumericInputCompanyProfile_Revenue"
            Me.NumericInputCompanyProfile_Revenue.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputCompanyProfile_Revenue.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputCompanyProfile_Revenue.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputCompanyProfile_Revenue.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputCompanyProfile_Revenue.Properties.EditFormat.FormatString = "f"
            Me.NumericInputCompanyProfile_Revenue.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputCompanyProfile_Revenue.Properties.Mask.EditMask = "f"
            Me.NumericInputCompanyProfile_Revenue.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputCompanyProfile_Revenue.SecurityEnabled = True
            Me.NumericInputCompanyProfile_Revenue.Size = New System.Drawing.Size(129, 20)
            Me.NumericInputCompanyProfile_Revenue.TabIndex = 7
            '
            'SearchableComboBoxCompanyProfile_Region
            '
            Me.SearchableComboBoxCompanyProfile_Region.ActiveFilterString = ""
            Me.SearchableComboBoxCompanyProfile_Region.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxCompanyProfile_Region.AutoFillMode = False
            Me.SearchableComboBoxCompanyProfile_Region.BookmarkingEnabled = False
            Me.SearchableComboBoxCompanyProfile_Region.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.PrintSpecRegion
            Me.SearchableComboBoxCompanyProfile_Region.DataSource = Nothing
            Me.SearchableComboBoxCompanyProfile_Region.DisableMouseWheel = True
            Me.SearchableComboBoxCompanyProfile_Region.DisplayName = ""
            Me.SearchableComboBoxCompanyProfile_Region.EnterMoveNextControl = True
            Me.SearchableComboBoxCompanyProfile_Region.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxCompanyProfile_Region.Location = New System.Drawing.Point(97, 51)
            Me.SearchableComboBoxCompanyProfile_Region.Name = "SearchableComboBoxCompanyProfile_Region"
            Me.SearchableComboBoxCompanyProfile_Region.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxCompanyProfile_Region.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxCompanyProfile_Region.Properties.NullText = "Select Region"
            Me.SearchableComboBoxCompanyProfile_Region.Properties.ShowClearButton = False
            Me.SearchableComboBoxCompanyProfile_Region.Properties.ValueMember = "Code"
            Me.SearchableComboBoxCompanyProfile_Region.Properties.View = Me.SearchableComboBoxViewCompanyProfile_Region
            Me.SearchableComboBoxCompanyProfile_Region.SecurityEnabled = True
            Me.SearchableComboBoxCompanyProfile_Region.SelectedValue = Nothing
            Me.SearchableComboBoxCompanyProfile_Region.Size = New System.Drawing.Size(292, 20)
            Me.SearchableComboBoxCompanyProfile_Region.TabIndex = 5
            '
            'SearchableComboBoxViewCompanyProfile_Region
            '
            Me.SearchableComboBoxViewCompanyProfile_Region.AFActiveFilterString = ""
            Me.SearchableComboBoxViewCompanyProfile_Region.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewCompanyProfile_Region.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Region.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Region.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Region.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Region.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Region.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Region.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Region.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Region.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Region.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Region.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Region.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Region.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Region.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Region.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Region.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Region.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Region.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Region.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Region.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Region.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Region.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Region.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Region.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Region.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Region.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Region.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Region.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Region.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Region.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Region.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Region.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Region.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Region.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Region.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Region.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Region.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Region.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewCompanyProfile_Region.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewCompanyProfile_Region.DataSourceClearing = False
            Me.SearchableComboBoxViewCompanyProfile_Region.EnableDisabledRows = False
            Me.SearchableComboBoxViewCompanyProfile_Region.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewCompanyProfile_Region.Name = "SearchableComboBoxViewCompanyProfile_Region"
            Me.SearchableComboBoxViewCompanyProfile_Region.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewCompanyProfile_Region.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewCompanyProfile_Region.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewCompanyProfile_Region.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewCompanyProfile_Region.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewCompanyProfile_Region.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewCompanyProfile_Region.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewCompanyProfile_Region.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewCompanyProfile_Region.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewCompanyProfile_Region.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewCompanyProfile_Region.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewCompanyProfile_Region.RunStandardValidation = True
            '
            'SearchableComboBoxCompanyProfile_Specialty
            '
            Me.SearchableComboBoxCompanyProfile_Specialty.ActiveFilterString = ""
            Me.SearchableComboBoxCompanyProfile_Specialty.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxCompanyProfile_Specialty.AutoFillMode = False
            Me.SearchableComboBoxCompanyProfile_Specialty.BookmarkingEnabled = False
            Me.SearchableComboBoxCompanyProfile_Specialty.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Specialty
            Me.SearchableComboBoxCompanyProfile_Specialty.DataSource = Nothing
            Me.SearchableComboBoxCompanyProfile_Specialty.DisableMouseWheel = True
            Me.SearchableComboBoxCompanyProfile_Specialty.DisplayName = ""
            Me.SearchableComboBoxCompanyProfile_Specialty.EnterMoveNextControl = True
            Me.SearchableComboBoxCompanyProfile_Specialty.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxCompanyProfile_Specialty.Location = New System.Drawing.Point(97, 25)
            Me.SearchableComboBoxCompanyProfile_Specialty.Name = "SearchableComboBoxCompanyProfile_Specialty"
            Me.SearchableComboBoxCompanyProfile_Specialty.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxCompanyProfile_Specialty.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxCompanyProfile_Specialty.Properties.NullText = "Select Specialty"
            Me.SearchableComboBoxCompanyProfile_Specialty.Properties.ShowClearButton = False
            Me.SearchableComboBoxCompanyProfile_Specialty.Properties.ValueMember = "ID"
            Me.SearchableComboBoxCompanyProfile_Specialty.Properties.View = Me.SearchableComboBoxViewCompanyProfile_Specialty
            Me.SearchableComboBoxCompanyProfile_Specialty.SecurityEnabled = True
            Me.SearchableComboBoxCompanyProfile_Specialty.SelectedValue = Nothing
            Me.SearchableComboBoxCompanyProfile_Specialty.Size = New System.Drawing.Size(292, 20)
            Me.SearchableComboBoxCompanyProfile_Specialty.TabIndex = 3
            '
            'SearchableComboBoxViewCompanyProfile_Specialty
            '
            Me.SearchableComboBoxViewCompanyProfile_Specialty.AFActiveFilterString = ""
            Me.SearchableComboBoxViewCompanyProfile_Specialty.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewCompanyProfile_Specialty.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Specialty.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Specialty.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Specialty.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Specialty.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Specialty.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Specialty.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Specialty.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Specialty.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Specialty.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Specialty.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Specialty.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Specialty.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Specialty.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Specialty.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Specialty.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Specialty.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Specialty.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Specialty.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Specialty.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Specialty.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Specialty.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Specialty.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Specialty.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Specialty.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Specialty.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Specialty.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Specialty.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Specialty.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Specialty.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Specialty.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Specialty.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Specialty.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Specialty.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Specialty.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Specialty.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Specialty.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCompanyProfile_Specialty.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewCompanyProfile_Specialty.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewCompanyProfile_Specialty.DataSourceClearing = False
            Me.SearchableComboBoxViewCompanyProfile_Specialty.EnableDisabledRows = False
            Me.SearchableComboBoxViewCompanyProfile_Specialty.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewCompanyProfile_Specialty.Name = "SearchableComboBoxViewCompanyProfile_Specialty"
            Me.SearchableComboBoxViewCompanyProfile_Specialty.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewCompanyProfile_Specialty.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewCompanyProfile_Specialty.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewCompanyProfile_Specialty.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewCompanyProfile_Specialty.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewCompanyProfile_Specialty.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewCompanyProfile_Specialty.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewCompanyProfile_Specialty.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewCompanyProfile_Specialty.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewCompanyProfile_Specialty.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewCompanyProfile_Specialty.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewCompanyProfile_Specialty.RunStandardValidation = True
            '
            'LabelCompanyProfile_Notes
            '
            Me.LabelCompanyProfile_Notes.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCompanyProfile_Notes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCompanyProfile_Notes.Location = New System.Drawing.Point(1, 286)
            Me.LabelCompanyProfile_Notes.Name = "LabelCompanyProfile_Notes"
            Me.LabelCompanyProfile_Notes.Size = New System.Drawing.Size(90, 20)
            Me.LabelCompanyProfile_Notes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCompanyProfile_Notes.TabIndex = 22
            Me.LabelCompanyProfile_Notes.Text = "Notes:"
            '
            'LabelCompanyProfile_NumberOfEmployees
            '
            Me.LabelCompanyProfile_NumberOfEmployees.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCompanyProfile_NumberOfEmployees.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCompanyProfile_NumberOfEmployees.Location = New System.Drawing.Point(1, 104)
            Me.LabelCompanyProfile_NumberOfEmployees.Name = "LabelCompanyProfile_NumberOfEmployees"
            Me.LabelCompanyProfile_NumberOfEmployees.Size = New System.Drawing.Size(90, 20)
            Me.LabelCompanyProfile_NumberOfEmployees.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCompanyProfile_NumberOfEmployees.TabIndex = 8
            Me.LabelCompanyProfile_NumberOfEmployees.Text = "# of Employees:"
            '
            'LabelCompanyProfile_Revenue
            '
            Me.LabelCompanyProfile_Revenue.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCompanyProfile_Revenue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCompanyProfile_Revenue.Location = New System.Drawing.Point(1, 78)
            Me.LabelCompanyProfile_Revenue.Name = "LabelCompanyProfile_Revenue"
            Me.LabelCompanyProfile_Revenue.Size = New System.Drawing.Size(90, 20)
            Me.LabelCompanyProfile_Revenue.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCompanyProfile_Revenue.TabIndex = 6
            Me.LabelCompanyProfile_Revenue.Text = "Revenue:"
            '
            'LabelCompanyProfile_Region
            '
            Me.LabelCompanyProfile_Region.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCompanyProfile_Region.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCompanyProfile_Region.Location = New System.Drawing.Point(1, 52)
            Me.LabelCompanyProfile_Region.Name = "LabelCompanyProfile_Region"
            Me.LabelCompanyProfile_Region.Size = New System.Drawing.Size(90, 20)
            Me.LabelCompanyProfile_Region.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCompanyProfile_Region.TabIndex = 4
            Me.LabelCompanyProfile_Region.Text = "Region:"
            '
            'LabelCompanyProfile_Specialty
            '
            Me.LabelCompanyProfile_Specialty.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCompanyProfile_Specialty.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCompanyProfile_Specialty.Location = New System.Drawing.Point(1, 26)
            Me.LabelCompanyProfile_Specialty.Name = "LabelCompanyProfile_Specialty"
            Me.LabelCompanyProfile_Specialty.Size = New System.Drawing.Size(90, 20)
            Me.LabelCompanyProfile_Specialty.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCompanyProfile_Specialty.TabIndex = 2
            Me.LabelCompanyProfile_Specialty.Text = "Specialty:"
            '
            'SearchableComboBoxCompanyProfile_Industry
            '
            Me.SearchableComboBoxCompanyProfile_Industry.ActiveFilterString = ""
            Me.SearchableComboBoxCompanyProfile_Industry.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxCompanyProfile_Industry.AutoFillMode = False
            Me.SearchableComboBoxCompanyProfile_Industry.BookmarkingEnabled = False
            Me.SearchableComboBoxCompanyProfile_Industry.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Industry
            Me.SearchableComboBoxCompanyProfile_Industry.DataSource = Nothing
            Me.SearchableComboBoxCompanyProfile_Industry.DisableMouseWheel = True
            Me.SearchableComboBoxCompanyProfile_Industry.DisplayName = ""
            Me.SearchableComboBoxCompanyProfile_Industry.EnterMoveNextControl = True
            Me.SearchableComboBoxCompanyProfile_Industry.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxCompanyProfile_Industry.Location = New System.Drawing.Point(97, 0)
            Me.SearchableComboBoxCompanyProfile_Industry.Name = "SearchableComboBoxCompanyProfile_Industry"
            Me.SearchableComboBoxCompanyProfile_Industry.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxCompanyProfile_Industry.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxCompanyProfile_Industry.Properties.NullText = "Select Industry"
            Me.SearchableComboBoxCompanyProfile_Industry.Properties.ShowClearButton = False
            Me.SearchableComboBoxCompanyProfile_Industry.Properties.ValueMember = "ID"
            Me.SearchableComboBoxCompanyProfile_Industry.Properties.View = Me.SearchableComboBoxViewControl_Vendor
            Me.SearchableComboBoxCompanyProfile_Industry.SecurityEnabled = True
            Me.SearchableComboBoxCompanyProfile_Industry.SelectedValue = Nothing
            Me.SearchableComboBoxCompanyProfile_Industry.Size = New System.Drawing.Size(292, 20)
            Me.SearchableComboBoxCompanyProfile_Industry.TabIndex = 1
            '
            'SearchableComboBoxViewControl_Vendor
            '
            Me.SearchableComboBoxViewControl_Vendor.AFActiveFilterString = ""
            Me.SearchableComboBoxViewControl_Vendor.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewControl_Vendor.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_Vendor.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewControl_Vendor.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewControl_Vendor.DataSourceClearing = False
            Me.SearchableComboBoxViewControl_Vendor.EnableDisabledRows = False
            Me.SearchableComboBoxViewControl_Vendor.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewControl_Vendor.Name = "SearchableComboBoxViewControl_Vendor"
            Me.SearchableComboBoxViewControl_Vendor.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewControl_Vendor.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewControl_Vendor.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewControl_Vendor.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewControl_Vendor.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewControl_Vendor.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewControl_Vendor.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewControl_Vendor.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewControl_Vendor.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewControl_Vendor.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewControl_Vendor.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewControl_Vendor.RunStandardValidation = True
            '
            'LabelCompanyProfile_Industry
            '
            Me.LabelCompanyProfile_Industry.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCompanyProfile_Industry.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCompanyProfile_Industry.Location = New System.Drawing.Point(1, 0)
            Me.LabelCompanyProfile_Industry.Name = "LabelCompanyProfile_Industry"
            Me.LabelCompanyProfile_Industry.Size = New System.Drawing.Size(90, 20)
            Me.LabelCompanyProfile_Industry.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCompanyProfile_Industry.TabIndex = 0
            Me.LabelCompanyProfile_Industry.Text = "Industry:"
            '
            'PanelControl_Control
            '
            Me.PanelControl_Control.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelControl_Control.Controls.Add(Me.LabelCompanyProfile_ClientType3)
            Me.PanelControl_Control.Controls.Add(Me.LabelCompanyProfile_ClientType2)
            Me.PanelControl_Control.Controls.Add(Me.LabelCompanyProfile_ClientType1)
            Me.PanelControl_Control.Controls.Add(Me.LabelCompanyProfile_TurnoverPercent)
            Me.PanelControl_Control.Controls.Add(Me.SearchableComboBoxCompanyProfile_ClientType3)
            Me.PanelControl_Control.Controls.Add(Me.SearchableComboBoxCompanyProfile_ClientType2)
            Me.PanelControl_Control.Controls.Add(Me.SearchableComboBoxCompanyProfile_ClientType1)
            Me.PanelControl_Control.Controls.Add(Me.NumericInputCompanyProfile_TurnoverPercent)
            Me.PanelControl_Control.Controls.Add(Me.DataGridViewCompanyProfile_Affiliations)
            Me.PanelControl_Control.Controls.Add(Me.CheckBoxCompanyProfile_Reference)
            Me.PanelControl_Control.Controls.Add(Me.LabelCompanyProfile_Industry)
            Me.PanelControl_Control.Controls.Add(Me.CheckBoxCompanyProfile_CaseStudy)
            Me.PanelControl_Control.Controls.Add(Me.SearchableComboBoxCompanyProfile_Industry)
            Me.PanelControl_Control.Controls.Add(Me.TextBoxCompanyProfile_Notes)
            Me.PanelControl_Control.Controls.Add(Me.LabelCompanyProfile_Specialty)
            Me.PanelControl_Control.Controls.Add(Me.NumericInputCompanyProfile_NumEmployees)
            Me.PanelControl_Control.Controls.Add(Me.LabelCompanyProfile_Region)
            Me.PanelControl_Control.Controls.Add(Me.NumericInputCompanyProfile_Revenue)
            Me.PanelControl_Control.Controls.Add(Me.LabelCompanyProfile_Revenue)
            Me.PanelControl_Control.Controls.Add(Me.SearchableComboBoxCompanyProfile_Region)
            Me.PanelControl_Control.Controls.Add(Me.LabelCompanyProfile_NumberOfEmployees)
            Me.PanelControl_Control.Controls.Add(Me.SearchableComboBoxCompanyProfile_Specialty)
            Me.PanelControl_Control.Controls.Add(Me.LabelCompanyProfile_Notes)
            Me.PanelControl_Control.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelControl_Control.Location = New System.Drawing.Point(0, 0)
            Me.PanelControl_Control.Margin = New System.Windows.Forms.Padding(2)
            Me.PanelControl_Control.Name = "PanelControl_Control"
            Me.PanelControl_Control.Size = New System.Drawing.Size(602, 470)
            Me.PanelControl_Control.TabIndex = 15
            '
            'LabelCompanyProfile_ClientType3
            '
            Me.LabelCompanyProfile_ClientType3.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCompanyProfile_ClientType3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCompanyProfile_ClientType3.Location = New System.Drawing.Point(1, 260)
            Me.LabelCompanyProfile_ClientType3.Name = "LabelCompanyProfile_ClientType3"
            Me.LabelCompanyProfile_ClientType3.Size = New System.Drawing.Size(90, 20)
            Me.LabelCompanyProfile_ClientType3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCompanyProfile_ClientType3.TabIndex = 20
            Me.LabelCompanyProfile_ClientType3.Text = "Type 3:"
            '
            'LabelCompanyProfile_ClientType2
            '
            Me.LabelCompanyProfile_ClientType2.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCompanyProfile_ClientType2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCompanyProfile_ClientType2.Location = New System.Drawing.Point(1, 234)
            Me.LabelCompanyProfile_ClientType2.Name = "LabelCompanyProfile_ClientType2"
            Me.LabelCompanyProfile_ClientType2.Size = New System.Drawing.Size(90, 20)
            Me.LabelCompanyProfile_ClientType2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCompanyProfile_ClientType2.TabIndex = 18
            Me.LabelCompanyProfile_ClientType2.Text = "Type 2:"
            '
            'LabelCompanyProfile_ClientType1
            '
            Me.LabelCompanyProfile_ClientType1.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCompanyProfile_ClientType1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCompanyProfile_ClientType1.Location = New System.Drawing.Point(1, 208)
            Me.LabelCompanyProfile_ClientType1.Name = "LabelCompanyProfile_ClientType1"
            Me.LabelCompanyProfile_ClientType1.Size = New System.Drawing.Size(90, 20)
            Me.LabelCompanyProfile_ClientType1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCompanyProfile_ClientType1.TabIndex = 16
            Me.LabelCompanyProfile_ClientType1.Text = "Type 1:"
            '
            'LabelCompanyProfile_TurnoverPercent
            '
            Me.LabelCompanyProfile_TurnoverPercent.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCompanyProfile_TurnoverPercent.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCompanyProfile_TurnoverPercent.Location = New System.Drawing.Point(1, 182)
            Me.LabelCompanyProfile_TurnoverPercent.Name = "LabelCompanyProfile_TurnoverPercent"
            Me.LabelCompanyProfile_TurnoverPercent.Size = New System.Drawing.Size(90, 20)
            Me.LabelCompanyProfile_TurnoverPercent.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCompanyProfile_TurnoverPercent.TabIndex = 14
            Me.LabelCompanyProfile_TurnoverPercent.Text = "Turnover Percent:"
            '
            'SearchableComboBoxCompanyProfile_ClientType3
            '
            Me.SearchableComboBoxCompanyProfile_ClientType3.ActiveFilterString = ""
            Me.SearchableComboBoxCompanyProfile_ClientType3.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxCompanyProfile_ClientType3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxCompanyProfile_ClientType3.AutoFillMode = False
            Me.SearchableComboBoxCompanyProfile_ClientType3.BookmarkingEnabled = False
            Me.SearchableComboBoxCompanyProfile_ClientType3.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.ClientType3
            Me.SearchableComboBoxCompanyProfile_ClientType3.DataSource = Nothing
            Me.SearchableComboBoxCompanyProfile_ClientType3.DisableMouseWheel = True
            Me.SearchableComboBoxCompanyProfile_ClientType3.DisplayName = ""
            Me.SearchableComboBoxCompanyProfile_ClientType3.EnterMoveNextControl = True
            Me.SearchableComboBoxCompanyProfile_ClientType3.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxCompanyProfile_ClientType3.Location = New System.Drawing.Point(97, 260)
            Me.SearchableComboBoxCompanyProfile_ClientType3.Name = "SearchableComboBoxCompanyProfile_ClientType3"
            Me.SearchableComboBoxCompanyProfile_ClientType3.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxCompanyProfile_ClientType3.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxCompanyProfile_ClientType3.Properties.NullText = "Select Client Type3"
            Me.SearchableComboBoxCompanyProfile_ClientType3.Properties.ShowClearButton = False
            Me.SearchableComboBoxCompanyProfile_ClientType3.Properties.ValueMember = "ID"
            Me.SearchableComboBoxCompanyProfile_ClientType3.Properties.View = Me.GridView3
            Me.SearchableComboBoxCompanyProfile_ClientType3.SecurityEnabled = True
            Me.SearchableComboBoxCompanyProfile_ClientType3.SelectedValue = Nothing
            Me.SearchableComboBoxCompanyProfile_ClientType3.Size = New System.Drawing.Size(505, 20)
            Me.SearchableComboBoxCompanyProfile_ClientType3.TabIndex = 21
            '
            'GridView3
            '
            Me.GridView3.AFActiveFilterString = ""
            Me.GridView3.AllowExtraItemsInGridLookupEdits = True
            Me.GridView3.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.AutoFilterLookupColumns = False
            Me.GridView3.AutoloadRepositoryDatasource = True
            Me.GridView3.DataSourceClearing = False
            Me.GridView3.EnableDisabledRows = False
            Me.GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView3.Name = "GridView3"
            Me.GridView3.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView3.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView3.OptionsBehavior.Editable = False
            Me.GridView3.OptionsCustomization.AllowQuickHideColumns = False
            Me.GridView3.OptionsNavigation.AutoFocusNewRow = True
            Me.GridView3.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView3.OptionsSelection.MultiSelect = True
            Me.GridView3.OptionsView.ColumnAutoWidth = False
            Me.GridView3.OptionsView.ShowGroupPanel = False
            Me.GridView3.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.GridView3.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView3.RunStandardValidation = True
            '
            'SearchableComboBoxCompanyProfile_ClientType2
            '
            Me.SearchableComboBoxCompanyProfile_ClientType2.ActiveFilterString = ""
            Me.SearchableComboBoxCompanyProfile_ClientType2.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxCompanyProfile_ClientType2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxCompanyProfile_ClientType2.AutoFillMode = False
            Me.SearchableComboBoxCompanyProfile_ClientType2.BookmarkingEnabled = False
            Me.SearchableComboBoxCompanyProfile_ClientType2.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.ClientType2
            Me.SearchableComboBoxCompanyProfile_ClientType2.DataSource = Nothing
            Me.SearchableComboBoxCompanyProfile_ClientType2.DisableMouseWheel = True
            Me.SearchableComboBoxCompanyProfile_ClientType2.DisplayName = ""
            Me.SearchableComboBoxCompanyProfile_ClientType2.EnterMoveNextControl = True
            Me.SearchableComboBoxCompanyProfile_ClientType2.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxCompanyProfile_ClientType2.Location = New System.Drawing.Point(97, 234)
            Me.SearchableComboBoxCompanyProfile_ClientType2.Name = "SearchableComboBoxCompanyProfile_ClientType2"
            Me.SearchableComboBoxCompanyProfile_ClientType2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxCompanyProfile_ClientType2.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxCompanyProfile_ClientType2.Properties.NullText = "Select Client Type2"
            Me.SearchableComboBoxCompanyProfile_ClientType2.Properties.ShowClearButton = False
            Me.SearchableComboBoxCompanyProfile_ClientType2.Properties.ValueMember = "ID"
            Me.SearchableComboBoxCompanyProfile_ClientType2.Properties.View = Me.GridView2
            Me.SearchableComboBoxCompanyProfile_ClientType2.SecurityEnabled = True
            Me.SearchableComboBoxCompanyProfile_ClientType2.SelectedValue = Nothing
            Me.SearchableComboBoxCompanyProfile_ClientType2.Size = New System.Drawing.Size(505, 20)
            Me.SearchableComboBoxCompanyProfile_ClientType2.TabIndex = 19
            '
            'GridView2
            '
            Me.GridView2.AFActiveFilterString = ""
            Me.GridView2.AllowExtraItemsInGridLookupEdits = True
            Me.GridView2.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AutoFilterLookupColumns = False
            Me.GridView2.AutoloadRepositoryDatasource = True
            Me.GridView2.DataSourceClearing = False
            Me.GridView2.EnableDisabledRows = False
            Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView2.Name = "GridView2"
            Me.GridView2.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView2.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView2.OptionsBehavior.Editable = False
            Me.GridView2.OptionsCustomization.AllowQuickHideColumns = False
            Me.GridView2.OptionsNavigation.AutoFocusNewRow = True
            Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView2.OptionsSelection.MultiSelect = True
            Me.GridView2.OptionsView.ColumnAutoWidth = False
            Me.GridView2.OptionsView.ShowGroupPanel = False
            Me.GridView2.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.GridView2.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView2.RunStandardValidation = True
            '
            'SearchableComboBoxCompanyProfile_ClientType1
            '
            Me.SearchableComboBoxCompanyProfile_ClientType1.ActiveFilterString = ""
            Me.SearchableComboBoxCompanyProfile_ClientType1.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxCompanyProfile_ClientType1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxCompanyProfile_ClientType1.AutoFillMode = False
            Me.SearchableComboBoxCompanyProfile_ClientType1.BookmarkingEnabled = False
            Me.SearchableComboBoxCompanyProfile_ClientType1.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.ClientType1
            Me.SearchableComboBoxCompanyProfile_ClientType1.DataSource = Nothing
            Me.SearchableComboBoxCompanyProfile_ClientType1.DisableMouseWheel = True
            Me.SearchableComboBoxCompanyProfile_ClientType1.DisplayName = ""
            Me.SearchableComboBoxCompanyProfile_ClientType1.EnterMoveNextControl = True
            Me.SearchableComboBoxCompanyProfile_ClientType1.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxCompanyProfile_ClientType1.Location = New System.Drawing.Point(97, 208)
            Me.SearchableComboBoxCompanyProfile_ClientType1.Name = "SearchableComboBoxCompanyProfile_ClientType1"
            Me.SearchableComboBoxCompanyProfile_ClientType1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxCompanyProfile_ClientType1.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxCompanyProfile_ClientType1.Properties.NullText = "Select Client Type1"
            Me.SearchableComboBoxCompanyProfile_ClientType1.Properties.ShowClearButton = False
            Me.SearchableComboBoxCompanyProfile_ClientType1.Properties.ValueMember = "ID"
            Me.SearchableComboBoxCompanyProfile_ClientType1.Properties.View = Me.GridView1
            Me.SearchableComboBoxCompanyProfile_ClientType1.SecurityEnabled = True
            Me.SearchableComboBoxCompanyProfile_ClientType1.SelectedValue = Nothing
            Me.SearchableComboBoxCompanyProfile_ClientType1.Size = New System.Drawing.Size(505, 20)
            Me.SearchableComboBoxCompanyProfile_ClientType1.TabIndex = 17
            '
            'GridView1
            '
            Me.GridView1.AFActiveFilterString = ""
            Me.GridView1.AllowExtraItemsInGridLookupEdits = True
            Me.GridView1.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.AutoFilterLookupColumns = False
            Me.GridView1.AutoloadRepositoryDatasource = True
            Me.GridView1.DataSourceClearing = False
            Me.GridView1.EnableDisabledRows = False
            Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView1.Name = "GridView1"
            Me.GridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView1.OptionsBehavior.Editable = False
            Me.GridView1.OptionsCustomization.AllowQuickHideColumns = False
            Me.GridView1.OptionsNavigation.AutoFocusNewRow = True
            Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView1.OptionsSelection.MultiSelect = True
            Me.GridView1.OptionsView.ColumnAutoWidth = False
            Me.GridView1.OptionsView.ShowGroupPanel = False
            Me.GridView1.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.GridView1.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView1.RunStandardValidation = True
            '
            'NumericInputCompanyProfile_TurnoverPercent
            '
            Me.NumericInputCompanyProfile_TurnoverPercent.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputCompanyProfile_TurnoverPercent.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputCompanyProfile_TurnoverPercent.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputCompanyProfile_TurnoverPercent.EnterMoveNextControl = True
            Me.NumericInputCompanyProfile_TurnoverPercent.Location = New System.Drawing.Point(97, 182)
            Me.NumericInputCompanyProfile_TurnoverPercent.Name = "NumericInputCompanyProfile_TurnoverPercent"
            Me.NumericInputCompanyProfile_TurnoverPercent.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputCompanyProfile_TurnoverPercent.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputCompanyProfile_TurnoverPercent.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputCompanyProfile_TurnoverPercent.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputCompanyProfile_TurnoverPercent.Properties.EditFormat.FormatString = "f"
            Me.NumericInputCompanyProfile_TurnoverPercent.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputCompanyProfile_TurnoverPercent.Properties.Mask.EditMask = "f"
            Me.NumericInputCompanyProfile_TurnoverPercent.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputCompanyProfile_TurnoverPercent.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputCompanyProfile_TurnoverPercent.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputCompanyProfile_TurnoverPercent.SecurityEnabled = True
            Me.NumericInputCompanyProfile_TurnoverPercent.Size = New System.Drawing.Size(129, 20)
            Me.NumericInputCompanyProfile_TurnoverPercent.TabIndex = 15
            '
            'CompanyProfileControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.White
            Me.Controls.Add(Me.PanelControl_Control)
            Me.Name = "CompanyProfileControl"
            Me.Size = New System.Drawing.Size(602, 470)
            CType(Me.NumericInputCompanyProfile_NumEmployees.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputCompanyProfile_Revenue.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxCompanyProfile_Region.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewCompanyProfile_Region, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxCompanyProfile_Specialty.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewCompanyProfile_Specialty, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxCompanyProfile_Industry.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewControl_Vendor, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PanelControl_Control, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelControl_Control.ResumeLayout(False)
            CType(Me.SearchableComboBoxCompanyProfile_ClientType3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxCompanyProfile_ClientType2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxCompanyProfile_ClientType1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputCompanyProfile_TurnoverPercent.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewCompanyProfile_Affiliations As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents CheckBoxCompanyProfile_Reference As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxCompanyProfile_CaseStudy As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents TextBoxCompanyProfile_Notes As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents NumericInputCompanyProfile_NumEmployees As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputCompanyProfile_Revenue As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents SearchableComboBoxCompanyProfile_Region As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewCompanyProfile_Region As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxCompanyProfile_Specialty As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewCompanyProfile_Specialty As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents LabelCompanyProfile_Notes As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelCompanyProfile_NumberOfEmployees As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelCompanyProfile_Revenue As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelCompanyProfile_Region As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelCompanyProfile_Specialty As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxCompanyProfile_Industry As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewControl_Vendor As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents LabelCompanyProfile_Industry As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents PanelControl_Control As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents LabelCompanyProfile_ClientType3 As Label
        Friend WithEvents LabelCompanyProfile_ClientType2 As Label
        Friend WithEvents LabelCompanyProfile_ClientType1 As Label
        Friend WithEvents LabelCompanyProfile_TurnoverPercent As Label
        Friend WithEvents SearchableComboBoxCompanyProfile_ClientType3 As SearchableComboBox
        Friend WithEvents GridView3 As GridView
        Friend WithEvents SearchableComboBoxCompanyProfile_ClientType2 As SearchableComboBox
        Friend WithEvents GridView2 As GridView
        Friend WithEvents SearchableComboBoxCompanyProfile_ClientType1 As SearchableComboBox
        Friend WithEvents GridView1 As GridView
        Friend WithEvents NumericInputCompanyProfile_TurnoverPercent As NumericInput
    End Class

End Namespace
