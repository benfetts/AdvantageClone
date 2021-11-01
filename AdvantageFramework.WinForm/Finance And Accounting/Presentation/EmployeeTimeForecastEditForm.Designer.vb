Namespace FinanceAndAccounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class EmployeeTimeForecastEditForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmployeeTimeForecastEditForm))
            Me.TextBoxForm_Description = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelForm_Description = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxForm_Comment = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelForm_RevisionNumber = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_OfficeLabel = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_PostPeriodLabel = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_AssignedEmployeeLabel = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Comment = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_RevisionNumber = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_Office = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_PostPeriod = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_AssignedEmployee = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_ApprovedBy = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_ModifiedBy = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_CreatedBy = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_ApprovedByLabel = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_ModifiedByLabel = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_CreatedByLabel = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Print = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemPrint_Export = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_View = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ItemContainerView_ETF = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemETF_ExpandAll = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemETF_CollapseAll = New DevComponents.DotNetBar.ButtonItem()
            Me.ItemContainerView_Office = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemOffice_ExpandOfficeLevel = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemOffice_CollapseOfficeLevel = New DevComponents.DotNetBar.ButtonItem()
            Me.ItemContainerView_Client = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemClient_ExpandClientLevel = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemClient_CollapseClientLevel = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Save = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_JobComponents = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Employees = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_AlternateEmployees = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_IndirectCategories = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_CreateRevision = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Delete = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Approve = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Unapprove = New DevComponents.DotNetBar.ButtonItem()
            Me.TreeListForm_ETF = New DevExpress.XtraTreeList.TreeList()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            CType(Me.TreeListForm_ETF, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'TextBoxForm_Description
            '
            Me.TextBoxForm_Description.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxForm_Description.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Description.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Description.CheckSpellingOnValidate = False
            Me.TextBoxForm_Description.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Description.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxForm_Description.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Description.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Description.FocusHighlightEnabled = True
            Me.TextBoxForm_Description.Location = New System.Drawing.Point(80, 12)
            Me.TextBoxForm_Description.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Description.Name = "TextBoxForm_Description"
            Me.TextBoxForm_Description.SecurityEnabled = True
            Me.TextBoxForm_Description.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Description.Size = New System.Drawing.Size(231, 20)
            Me.TextBoxForm_Description.StartingFolderName = Nothing
            Me.TextBoxForm_Description.TabIndex = 1
            Me.TextBoxForm_Description.TabOnEnter = True
            '
            'LabelForm_Description
            '
            Me.LabelForm_Description.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Description.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Description.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_Description.Name = "LabelForm_Description"
            Me.LabelForm_Description.Size = New System.Drawing.Size(62, 20)
            Me.LabelForm_Description.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Description.TabIndex = 0
            Me.LabelForm_Description.Text = "Description:"
            '
            'TextBoxForm_Comment
            '
            Me.TextBoxForm_Comment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxForm_Comment.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Comment.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Comment.CheckSpellingOnValidate = False
            Me.TextBoxForm_Comment.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Comment.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxForm_Comment.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Comment.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Comment.FocusHighlightEnabled = True
            Me.TextBoxForm_Comment.Location = New System.Drawing.Point(80, 38)
            Me.TextBoxForm_Comment.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Comment.Multiline = True
            Me.TextBoxForm_Comment.Name = "TextBoxForm_Comment"
            Me.TextBoxForm_Comment.SecurityEnabled = True
            Me.TextBoxForm_Comment.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Comment.Size = New System.Drawing.Size(231, 72)
            Me.TextBoxForm_Comment.StartingFolderName = Nothing
            Me.TextBoxForm_Comment.TabIndex = 3
            Me.TextBoxForm_Comment.TabOnEnter = True
            '
            'LabelForm_RevisionNumber
            '
            Me.LabelForm_RevisionNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_RevisionNumber.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_RevisionNumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_RevisionNumber.Location = New System.Drawing.Point(317, 12)
            Me.LabelForm_RevisionNumber.Name = "LabelForm_RevisionNumber"
            Me.LabelForm_RevisionNumber.Size = New System.Drawing.Size(103, 20)
            Me.LabelForm_RevisionNumber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_RevisionNumber.TabIndex = 4
            Me.LabelForm_RevisionNumber.Text = "Revision Number:"
            '
            'LabelForm_OfficeLabel
            '
            Me.LabelForm_OfficeLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_OfficeLabel.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_OfficeLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_OfficeLabel.Location = New System.Drawing.Point(317, 38)
            Me.LabelForm_OfficeLabel.Name = "LabelForm_OfficeLabel"
            Me.LabelForm_OfficeLabel.Size = New System.Drawing.Size(103, 20)
            Me.LabelForm_OfficeLabel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_OfficeLabel.TabIndex = 6
            Me.LabelForm_OfficeLabel.Text = "Office:"
            '
            'LabelForm_PostPeriodLabel
            '
            Me.LabelForm_PostPeriodLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_PostPeriodLabel.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_PostPeriodLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_PostPeriodLabel.Location = New System.Drawing.Point(317, 64)
            Me.LabelForm_PostPeriodLabel.Name = "LabelForm_PostPeriodLabel"
            Me.LabelForm_PostPeriodLabel.Size = New System.Drawing.Size(103, 20)
            Me.LabelForm_PostPeriodLabel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_PostPeriodLabel.TabIndex = 8
            Me.LabelForm_PostPeriodLabel.Text = "Post Period:"
            '
            'LabelForm_AssignedEmployeeLabel
            '
            Me.LabelForm_AssignedEmployeeLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_AssignedEmployeeLabel.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_AssignedEmployeeLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_AssignedEmployeeLabel.Location = New System.Drawing.Point(317, 90)
            Me.LabelForm_AssignedEmployeeLabel.Name = "LabelForm_AssignedEmployeeLabel"
            Me.LabelForm_AssignedEmployeeLabel.Size = New System.Drawing.Size(103, 20)
            Me.LabelForm_AssignedEmployeeLabel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_AssignedEmployeeLabel.TabIndex = 10
            Me.LabelForm_AssignedEmployeeLabel.Text = "Assigned Employee:"
            '
            'LabelForm_Comment
            '
            Me.LabelForm_Comment.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Comment.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Comment.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_Comment.Name = "LabelForm_Comment"
            Me.LabelForm_Comment.Size = New System.Drawing.Size(62, 20)
            Me.LabelForm_Comment.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Comment.TabIndex = 2
            Me.LabelForm_Comment.Text = "Comment:"
            '
            'ComboBoxForm_RevisionNumber
            '
            Me.ComboBoxForm_RevisionNumber.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_RevisionNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_RevisionNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_RevisionNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_RevisionNumber.AutoFindItemInDataSource = False
            Me.ComboBoxForm_RevisionNumber.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_RevisionNumber.BookmarkingEnabled = False
            Me.ComboBoxForm_RevisionNumber.ClientCode = ""
            Me.ComboBoxForm_RevisionNumber.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EmployeeTimeForecastOfficeDetailRevision
            Me.ComboBoxForm_RevisionNumber.DisableMouseWheel = False
            Me.ComboBoxForm_RevisionNumber.DisplayMember = "RevisionNumber"
            Me.ComboBoxForm_RevisionNumber.DisplayName = ""
            Me.ComboBoxForm_RevisionNumber.DivisionCode = ""
            Me.ComboBoxForm_RevisionNumber.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_RevisionNumber.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_RevisionNumber.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_RevisionNumber.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_RevisionNumber.FocusHighlightEnabled = True
            Me.ComboBoxForm_RevisionNumber.FormattingEnabled = True
            Me.ComboBoxForm_RevisionNumber.ItemHeight = 14
            Me.ComboBoxForm_RevisionNumber.Location = New System.Drawing.Point(426, 12)
            Me.ComboBoxForm_RevisionNumber.Name = "ComboBoxForm_RevisionNumber"
            Me.ComboBoxForm_RevisionNumber.ReadOnly = False
            Me.ComboBoxForm_RevisionNumber.SecurityEnabled = True
            Me.ComboBoxForm_RevisionNumber.Size = New System.Drawing.Size(85, 20)
            Me.ComboBoxForm_RevisionNumber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_RevisionNumber.TabIndex = 5
            Me.ComboBoxForm_RevisionNumber.TabOnEnter = True
            Me.ComboBoxForm_RevisionNumber.ValueMember = "ID"
            Me.ComboBoxForm_RevisionNumber.WatermarkText = "Select Employee Time Forecast"
            '
            'LabelForm_Office
            '
            Me.LabelForm_Office.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_Office.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Office.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Office.Location = New System.Drawing.Point(426, 38)
            Me.LabelForm_Office.Name = "LabelForm_Office"
            Me.LabelForm_Office.Size = New System.Drawing.Size(218, 20)
            Me.LabelForm_Office.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Office.TabIndex = 7
            '
            'LabelForm_PostPeriod
            '
            Me.LabelForm_PostPeriod.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_PostPeriod.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_PostPeriod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_PostPeriod.Location = New System.Drawing.Point(426, 64)
            Me.LabelForm_PostPeriod.Name = "LabelForm_PostPeriod"
            Me.LabelForm_PostPeriod.Size = New System.Drawing.Size(218, 20)
            Me.LabelForm_PostPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_PostPeriod.TabIndex = 9
            '
            'LabelForm_AssignedEmployee
            '
            Me.LabelForm_AssignedEmployee.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_AssignedEmployee.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_AssignedEmployee.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_AssignedEmployee.Location = New System.Drawing.Point(426, 90)
            Me.LabelForm_AssignedEmployee.Name = "LabelForm_AssignedEmployee"
            Me.LabelForm_AssignedEmployee.Size = New System.Drawing.Size(218, 20)
            Me.LabelForm_AssignedEmployee.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_AssignedEmployee.TabIndex = 11
            '
            'LabelForm_ApprovedBy
            '
            Me.LabelForm_ApprovedBy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_ApprovedBy.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_ApprovedBy.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_ApprovedBy.Location = New System.Drawing.Point(725, 90)
            Me.LabelForm_ApprovedBy.Name = "LabelForm_ApprovedBy"
            Me.LabelForm_ApprovedBy.Size = New System.Drawing.Size(229, 20)
            Me.LabelForm_ApprovedBy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_ApprovedBy.TabIndex = 17
            '
            'LabelForm_ModifiedBy
            '
            Me.LabelForm_ModifiedBy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_ModifiedBy.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_ModifiedBy.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_ModifiedBy.Location = New System.Drawing.Point(725, 64)
            Me.LabelForm_ModifiedBy.Name = "LabelForm_ModifiedBy"
            Me.LabelForm_ModifiedBy.Size = New System.Drawing.Size(229, 20)
            Me.LabelForm_ModifiedBy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_ModifiedBy.TabIndex = 15
            '
            'LabelForm_CreatedBy
            '
            Me.LabelForm_CreatedBy.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_CreatedBy.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_CreatedBy.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_CreatedBy.Location = New System.Drawing.Point(725, 38)
            Me.LabelForm_CreatedBy.Name = "LabelForm_CreatedBy"
            Me.LabelForm_CreatedBy.Size = New System.Drawing.Size(229, 20)
            Me.LabelForm_CreatedBy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_CreatedBy.TabIndex = 13
            '
            'LabelForm_ApprovedByLabel
            '
            Me.LabelForm_ApprovedByLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_ApprovedByLabel.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_ApprovedByLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_ApprovedByLabel.Location = New System.Drawing.Point(650, 90)
            Me.LabelForm_ApprovedByLabel.Name = "LabelForm_ApprovedByLabel"
            Me.LabelForm_ApprovedByLabel.Size = New System.Drawing.Size(69, 20)
            Me.LabelForm_ApprovedByLabel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_ApprovedByLabel.TabIndex = 16
            Me.LabelForm_ApprovedByLabel.Text = "Approved By:"
            '
            'LabelForm_ModifiedByLabel
            '
            Me.LabelForm_ModifiedByLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_ModifiedByLabel.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_ModifiedByLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_ModifiedByLabel.Location = New System.Drawing.Point(650, 64)
            Me.LabelForm_ModifiedByLabel.Name = "LabelForm_ModifiedByLabel"
            Me.LabelForm_ModifiedByLabel.Size = New System.Drawing.Size(69, 20)
            Me.LabelForm_ModifiedByLabel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_ModifiedByLabel.TabIndex = 14
            Me.LabelForm_ModifiedByLabel.Text = "Modified By:"
            '
            'LabelForm_CreatedByLabel
            '
            Me.LabelForm_CreatedByLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_CreatedByLabel.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_CreatedByLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_CreatedByLabel.Location = New System.Drawing.Point(650, 38)
            Me.LabelForm_CreatedByLabel.Name = "LabelForm_CreatedByLabel"
            Me.LabelForm_CreatedByLabel.Size = New System.Drawing.Size(69, 20)
            Me.LabelForm_CreatedByLabel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_CreatedByLabel.TabIndex = 12
            Me.LabelForm_CreatedByLabel.Text = "Created By:"
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Print)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_View)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(12, 218)
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(942, 98)
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
            Me.RibbonBarMergeContainerForm_Options.TabIndex = 19
            Me.RibbonBarMergeContainerForm_Options.Visible = False
            '
            'RibbonBarOptions_Print
            '
            Me.RibbonBarOptions_Print.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Print.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Print.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Print.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Print.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Print.DragDropSupport = True
            Me.RibbonBarOptions_Print.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemPrint_Export})
            Me.RibbonBarOptions_Print.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Print.Location = New System.Drawing.Point(831, 0)
            Me.RibbonBarOptions_Print.Name = "RibbonBarOptions_Print"
            Me.RibbonBarOptions_Print.SecurityEnabled = True
            Me.RibbonBarOptions_Print.Size = New System.Drawing.Size(70, 98)
            Me.RibbonBarOptions_Print.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Print.TabIndex = 2
            Me.RibbonBarOptions_Print.Text = "Print"
            '
            '
            '
            Me.RibbonBarOptions_Print.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Print.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemPrint_Export
            '
            Me.ButtonItemPrint_Export.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemPrint_Export.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemPrint_Export.Name = "ButtonItemPrint_Export"
            Me.ButtonItemPrint_Export.RibbonWordWrap = False
            Me.ButtonItemPrint_Export.Stretch = True
            Me.ButtonItemPrint_Export.SubItemsExpandWidth = 14
            Me.ButtonItemPrint_Export.Text = "Export"
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
            Me.RibbonBarOptions_View.DragDropSupport = True
            Me.RibbonBarOptions_View.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerView_ETF, Me.ItemContainerView_Office, Me.ItemContainerView_Client})
            Me.RibbonBarOptions_View.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_View.Location = New System.Drawing.Point(532, 0)
            Me.RibbonBarOptions_View.Name = "RibbonBarOptions_View"
            Me.RibbonBarOptions_View.SecurityEnabled = True
            Me.RibbonBarOptions_View.Size = New System.Drawing.Size(299, 98)
            Me.RibbonBarOptions_View.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_View.TabIndex = 1
            Me.RibbonBarOptions_View.Text = "View"
            '
            '
            '
            Me.RibbonBarOptions_View.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_View.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ItemContainerView_ETF
            '
            '
            '
            '
            Me.ItemContainerView_ETF.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerView_ETF.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerView_ETF.Name = "ItemContainerView_ETF"
            Me.ItemContainerView_ETF.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemETF_ExpandAll, Me.ButtonItemETF_CollapseAll})
            '
            '
            '
            Me.ItemContainerView_ETF.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerView_ETF.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemETF_ExpandAll
            '
            Me.ButtonItemETF_ExpandAll.Name = "ButtonItemETF_ExpandAll"
            Me.ButtonItemETF_ExpandAll.Stretch = True
            Me.ButtonItemETF_ExpandAll.SubItemsExpandWidth = 14
            Me.ButtonItemETF_ExpandAll.Text = "Expand All"
            '
            'ButtonItemETF_CollapseAll
            '
            Me.ButtonItemETF_CollapseAll.BeginGroup = True
            Me.ButtonItemETF_CollapseAll.Name = "ButtonItemETF_CollapseAll"
            Me.ButtonItemETF_CollapseAll.SubItemsExpandWidth = 14
            Me.ButtonItemETF_CollapseAll.Text = "Collapse All"
            '
            'ItemContainerView_Office
            '
            '
            '
            '
            Me.ItemContainerView_Office.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerView_Office.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerView_Office.Name = "ItemContainerView_Office"
            Me.ItemContainerView_Office.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemOffice_ExpandOfficeLevel, Me.ButtonItemOffice_CollapseOfficeLevel})
            '
            '
            '
            Me.ItemContainerView_Office.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerView_Office.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemOffice_ExpandOfficeLevel
            '
            Me.ButtonItemOffice_ExpandOfficeLevel.Name = "ButtonItemOffice_ExpandOfficeLevel"
            Me.ButtonItemOffice_ExpandOfficeLevel.Stretch = True
            Me.ButtonItemOffice_ExpandOfficeLevel.SubItemsExpandWidth = 14
            Me.ButtonItemOffice_ExpandOfficeLevel.Text = "Expand Office Level"
            '
            'ButtonItemOffice_CollapseOfficeLevel
            '
            Me.ButtonItemOffice_CollapseOfficeLevel.BeginGroup = True
            Me.ButtonItemOffice_CollapseOfficeLevel.Name = "ButtonItemOffice_CollapseOfficeLevel"
            Me.ButtonItemOffice_CollapseOfficeLevel.SubItemsExpandWidth = 14
            Me.ButtonItemOffice_CollapseOfficeLevel.Text = "Collapse Office Level"
            '
            'ItemContainerView_Client
            '
            '
            '
            '
            Me.ItemContainerView_Client.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerView_Client.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerView_Client.Name = "ItemContainerView_Client"
            Me.ItemContainerView_Client.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemClient_ExpandClientLevel, Me.ButtonItemClient_CollapseClientLevel})
            '
            '
            '
            Me.ItemContainerView_Client.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerView_Client.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemClient_ExpandClientLevel
            '
            Me.ButtonItemClient_ExpandClientLevel.Name = "ButtonItemClient_ExpandClientLevel"
            Me.ButtonItemClient_ExpandClientLevel.Stretch = True
            Me.ButtonItemClient_ExpandClientLevel.SubItemsExpandWidth = 14
            Me.ButtonItemClient_ExpandClientLevel.Text = "Expand Client Level"
            '
            'ButtonItemClient_CollapseClientLevel
            '
            Me.ButtonItemClient_CollapseClientLevel.BeginGroup = True
            Me.ButtonItemClient_CollapseClientLevel.Name = "ButtonItemClient_CollapseClientLevel"
            Me.ButtonItemClient_CollapseClientLevel.SubItemsExpandWidth = 14
            Me.ButtonItemClient_CollapseClientLevel.Text = "Collapse Client Level"
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Save, Me.ButtonItemActions_JobComponents, Me.ButtonItemActions_Employees, Me.ButtonItemActions_AlternateEmployees, Me.ButtonItemActions_IndirectCategories, Me.ButtonItemActions_CreateRevision, Me.ButtonItemActions_Delete, Me.ButtonItemActions_Approve, Me.ButtonItemActions_Unapprove})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(532, 98)
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
            '
            'ButtonItemActions_Save
            '
            Me.ButtonItemActions_Save.BeginGroup = True
            Me.ButtonItemActions_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Save.Name = "ButtonItemActions_Save"
            Me.ButtonItemActions_Save.RibbonWordWrap = False
            Me.ButtonItemActions_Save.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Save.Text = "Save"
            '
            'ButtonItemActions_JobComponents
            '
            Me.ButtonItemActions_JobComponents.BeginGroup = True
            Me.ButtonItemActions_JobComponents.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_JobComponents.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_JobComponents.Name = "ButtonItemActions_JobComponents"
            Me.ButtonItemActions_JobComponents.RibbonWordWrap = False
            Me.ButtonItemActions_JobComponents.SubItemsExpandWidth = 14
            Me.ButtonItemActions_JobComponents.Text = "Job " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Components"
            '
            'ButtonItemActions_Employees
            '
            Me.ButtonItemActions_Employees.BeginGroup = True
            Me.ButtonItemActions_Employees.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Employees.Name = "ButtonItemActions_Employees"
            Me.ButtonItemActions_Employees.RibbonWordWrap = False
            Me.ButtonItemActions_Employees.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Employees.Text = "Employees"
            '
            'ButtonItemActions_AlternateEmployees
            '
            Me.ButtonItemActions_AlternateEmployees.BeginGroup = True
            Me.ButtonItemActions_AlternateEmployees.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_AlternateEmployees.Name = "ButtonItemActions_AlternateEmployees"
            Me.ButtonItemActions_AlternateEmployees.RibbonWordWrap = False
            Me.ButtonItemActions_AlternateEmployees.SubItemsExpandWidth = 14
            Me.ButtonItemActions_AlternateEmployees.Text = "Alternate " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Employees"
            '
            'ButtonItemActions_IndirectCategories
            '
            Me.ButtonItemActions_IndirectCategories.BeginGroup = True
            Me.ButtonItemActions_IndirectCategories.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_IndirectCategories.Name = "ButtonItemActions_IndirectCategories"
            Me.ButtonItemActions_IndirectCategories.RibbonWordWrap = False
            Me.ButtonItemActions_IndirectCategories.SubItemsExpandWidth = 14
            Me.ButtonItemActions_IndirectCategories.Text = "Indirect " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Categories"
            '
            'ButtonItemActions_CreateRevision
            '
            Me.ButtonItemActions_CreateRevision.BeginGroup = True
            Me.ButtonItemActions_CreateRevision.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_CreateRevision.Name = "ButtonItemActions_CreateRevision"
            Me.ButtonItemActions_CreateRevision.RibbonWordWrap = False
            Me.ButtonItemActions_CreateRevision.SubItemsExpandWidth = 14
            Me.ButtonItemActions_CreateRevision.Text = "Create " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Revision"
            '
            'ButtonItemActions_Delete
            '
            Me.ButtonItemActions_Delete.BeginGroup = True
            Me.ButtonItemActions_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Delete.Name = "ButtonItemActions_Delete"
            Me.ButtonItemActions_Delete.RibbonWordWrap = False
            Me.ButtonItemActions_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Delete.Text = "Delete " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Revision"
            Me.ButtonItemActions_Delete.Visible = False
            '
            'ButtonItemActions_Approve
            '
            Me.ButtonItemActions_Approve.BeginGroup = True
            Me.ButtonItemActions_Approve.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Approve.Name = "ButtonItemActions_Approve"
            Me.ButtonItemActions_Approve.RibbonWordWrap = False
            Me.ButtonItemActions_Approve.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Approve.Text = "Approve"
            Me.ButtonItemActions_Approve.Visible = False
            '
            'ButtonItemActions_Unapprove
            '
            Me.ButtonItemActions_Unapprove.BeginGroup = True
            Me.ButtonItemActions_Unapprove.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Unapprove.Name = "ButtonItemActions_Unapprove"
            Me.ButtonItemActions_Unapprove.RibbonWordWrap = False
            Me.ButtonItemActions_Unapprove.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Unapprove.Text = "Unapprove"
            Me.ButtonItemActions_Unapprove.Visible = False
            '
            'TreeListForm_ETF
            '
            Me.TreeListForm_ETF.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TreeListForm_ETF.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.TreeListForm_ETF.KeyFieldName = "OfficeCode"
            Me.TreeListForm_ETF.Location = New System.Drawing.Point(12, 116)
            Me.TreeListForm_ETF.Name = "TreeListForm_ETF"
            Me.TreeListForm_ETF.OptionsBehavior.PopulateServiceColumns = True
            Me.TreeListForm_ETF.OptionsMenu.EnableColumnMenu = False
            Me.TreeListForm_ETF.OptionsMenu.EnableFooterMenu = False
            Me.TreeListForm_ETF.OptionsNavigation.AutoMoveRowFocus = True
            Me.TreeListForm_ETF.OptionsNavigation.EnterMovesNextColumn = True
            Me.TreeListForm_ETF.OptionsSelection.EnableAppearanceFocusedRow = False
            Me.TreeListForm_ETF.OptionsView.AutoWidth = False
            Me.TreeListForm_ETF.OptionsView.BestFitNodes = DevExpress.XtraTreeList.TreeListBestFitNodes.Visible
            Me.TreeListForm_ETF.ParentFieldName = "ParentOfficeCode"
            Me.TreeListForm_ETF.RootValue = ""
            Me.TreeListForm_ETF.Size = New System.Drawing.Size(942, 406)
            Me.TreeListForm_ETF.TabIndex = 20
            '
            'EmployeeTimeForecastEditForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(966, 534)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.LabelForm_ApprovedBy)
            Me.Controls.Add(Me.LabelForm_ModifiedBy)
            Me.Controls.Add(Me.LabelForm_CreatedBy)
            Me.Controls.Add(Me.LabelForm_ApprovedByLabel)
            Me.Controls.Add(Me.LabelForm_ModifiedByLabel)
            Me.Controls.Add(Me.LabelForm_CreatedByLabel)
            Me.Controls.Add(Me.LabelForm_AssignedEmployee)
            Me.Controls.Add(Me.LabelForm_PostPeriod)
            Me.Controls.Add(Me.LabelForm_Office)
            Me.Controls.Add(Me.ComboBoxForm_RevisionNumber)
            Me.Controls.Add(Me.LabelForm_Comment)
            Me.Controls.Add(Me.LabelForm_AssignedEmployeeLabel)
            Me.Controls.Add(Me.LabelForm_PostPeriodLabel)
            Me.Controls.Add(Me.LabelForm_OfficeLabel)
            Me.Controls.Add(Me.LabelForm_RevisionNumber)
            Me.Controls.Add(Me.TextBoxForm_Comment)
            Me.Controls.Add(Me.TextBoxForm_Description)
            Me.Controls.Add(Me.LabelForm_Description)
            Me.Controls.Add(Me.TreeListForm_ETF)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "EmployeeTimeForecastEditForm"
            Me.Text = "Employee Time Forecast"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            CType(Me.TreeListForm_ETF, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents TextBoxForm_Description As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelForm_Description As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_Comment As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelForm_RevisionNumber As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_OfficeLabel As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_PostPeriodLabel As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_AssignedEmployeeLabel As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Comment As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_RevisionNumber As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_PostPeriod As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_AssignedEmployee As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Office As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_ApprovedBy As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_ModifiedBy As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_CreatedBy As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_ApprovedByLabel As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_ModifiedByLabel As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_CreatedByLabel As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_JobComponents As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Employees As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_AlternateEmployees As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_IndirectCategories As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_CreateRevision As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Save As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Delete As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Approve As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Unapprove As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_View As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ItemContainerView_ETF As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemETF_ExpandAll As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemETF_CollapseAll As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ItemContainerView_Office As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemOffice_ExpandOfficeLevel As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemOffice_CollapseOfficeLevel As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ItemContainerView_Client As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemClient_ExpandClientLevel As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemClient_CollapseClientLevel As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents TreeListForm_ETF As DevExpress.XtraTreeList.TreeList
        Friend WithEvents RibbonBarOptions_Print As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemPrint_Export As DevComponents.DotNetBar.ButtonItem
    End Class

End Namespace