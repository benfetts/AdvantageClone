Namespace GeneralLedger.JournalEntriesBudgets.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class RecurringJournalEntrySetupForm
        Inherits AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseForm

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RecurringJournalEntrySetupForm))
            Me.PanelForm_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewLeftSection_RecurringJournalEntries = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.ExpandableSplitterControlForm_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelForm_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.RecurringJournalEntryControlRightSection_RecurringJournalEntry = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RecurringJournalEntryControl()
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Details = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemDetails_Delete = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemDetails_Cancel = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemDetails_CopyFrom = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDetails_ReverseDebitCredit = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Copy = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Print = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_RecurringJournalEntries = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemRecurringJournalEntries_Post = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_LeftSection.SuspendLayout()
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_RightSection.SuspendLayout()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            Me.SuspendLayout()
            '
            'PanelForm_LeftSection
            '
            Me.PanelForm_LeftSection.Controls.Add(Me.DataGridViewLeftSection_RecurringJournalEntries)
            Me.PanelForm_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelForm_LeftSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelForm_LeftSection.Name = "PanelForm_LeftSection"
            Me.PanelForm_LeftSection.Size = New System.Drawing.Size(326, 539)
            Me.PanelForm_LeftSection.TabIndex = 0
            '
            'DataGridViewLeftSection_RecurringJournalEntries
            '
            Me.DataGridViewLeftSection_RecurringJournalEntries.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_RecurringJournalEntries.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_RecurringJournalEntries.AutoUpdateViewCaption = True
            Me.DataGridViewLeftSection_RecurringJournalEntries.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_RecurringJournalEntries.ItemDescription = "Vendor Invoice(s)"
            Me.DataGridViewLeftSection_RecurringJournalEntries.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewLeftSection_RecurringJournalEntries.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewLeftSection_RecurringJournalEntries.ModifyGridRowHeight = False
            Me.DataGridViewLeftSection_RecurringJournalEntries.MultiSelect = False
            Me.DataGridViewLeftSection_RecurringJournalEntries.Name = "DataGridViewLeftSection_RecurringJournalEntries"
            Me.DataGridViewLeftSection_RecurringJournalEntries.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_RecurringJournalEntries.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewLeftSection_RecurringJournalEntries.ShowRowSelectionIfHidden = True
            Me.DataGridViewLeftSection_RecurringJournalEntries.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_RecurringJournalEntries.Size = New System.Drawing.Size(309, 515)
            Me.DataGridViewLeftSection_RecurringJournalEntries.TabIndex = 0
            Me.DataGridViewLeftSection_RecurringJournalEntries.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_RecurringJournalEntries.ViewCaptionHeight = -1
            '
            'ExpandableSplitterControlForm_LeftRight
            '
            Me.ExpandableSplitterControlForm_LeftRight.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlForm_LeftRight.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControlForm_LeftRight.ExpandableControl = Me.PanelForm_LeftSection
            Me.ExpandableSplitterControlForm_LeftRight.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlForm_LeftRight.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlForm_LeftRight.ForeColor = System.Drawing.Color.Black
            Me.ExpandableSplitterControlForm_LeftRight.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlForm_LeftRight.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlForm_LeftRight.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterControlForm_LeftRight.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterControlForm_LeftRight.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlForm_LeftRight.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlForm_LeftRight.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlForm_LeftRight.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlForm_LeftRight.Location = New System.Drawing.Point(326, 0)
            Me.ExpandableSplitterControlForm_LeftRight.Name = "ExpandableSplitterControlForm_LeftRight"
            Me.ExpandableSplitterControlForm_LeftRight.Size = New System.Drawing.Size(10, 539)
            Me.ExpandableSplitterControlForm_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControlForm_LeftRight.TabIndex = 1
            Me.ExpandableSplitterControlForm_LeftRight.TabStop = False
            '
            'PanelForm_RightSection
            '
            Me.PanelForm_RightSection.Controls.Add(Me.RecurringJournalEntryControlRightSection_RecurringJournalEntry)
            Me.PanelForm_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelForm_RightSection.Location = New System.Drawing.Point(336, 0)
            Me.PanelForm_RightSection.Name = "PanelForm_RightSection"
            Me.PanelForm_RightSection.Size = New System.Drawing.Size(580, 539)
            Me.PanelForm_RightSection.TabIndex = 2
            '
            'RecurringJournalEntryControlRightSection_RecurringJournalEntry
            '
            Me.RecurringJournalEntryControlRightSection_RecurringJournalEntry.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RecurringJournalEntryControlRightSection_RecurringJournalEntry.Location = New System.Drawing.Point(6, 12)
            Me.RecurringJournalEntryControlRightSection_RecurringJournalEntry.Name = "RecurringJournalEntryControlRightSection_RecurringJournalEntry"
            Me.RecurringJournalEntryControlRightSection_RecurringJournalEntry.Size = New System.Drawing.Size(562, 515)
            Me.RecurringJournalEntryControlRightSection_RecurringJournalEntry.TabIndex = 1
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_RecurringJournalEntries)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Details)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(8, 364)
            Me.RibbonBarMergeContainerForm_Options.MergeRibbonGroupName = "RibbonTabGroupDynamicReport"
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(1046, 98)
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
            Me.RibbonBarMergeContainerForm_Options.TabIndex = 8
            Me.RibbonBarMergeContainerForm_Options.Visible = False
            '
            'RibbonBarOptions_Details
            '
            Me.RibbonBarOptions_Details.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Details.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Details.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Details.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Details.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Details.DragDropSupport = True
            Me.RibbonBarOptions_Details.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemDetails_Delete, Me.ButtonItemDetails_Cancel, Me.ButtonItemDetails_CopyFrom, Me.ButtonItemDetails_ReverseDebitCredit})
            Me.RibbonBarOptions_Details.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Details.Location = New System.Drawing.Point(195, 0)
            Me.RibbonBarOptions_Details.Name = "RibbonBarOptions_Details"
            Me.RibbonBarOptions_Details.SecurityEnabled = True
            Me.RibbonBarOptions_Details.Size = New System.Drawing.Size(279, 98)
            Me.RibbonBarOptions_Details.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Details.TabIndex = 46
            Me.RibbonBarOptions_Details.Text = "Details"
            '
            '
            '
            Me.RibbonBarOptions_Details.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Details.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Details.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemDetails_Delete
            '
            Me.ButtonItemDetails_Delete.BeginGroup = True
            Me.ButtonItemDetails_Delete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemDetails_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDetails_Delete.Name = "ButtonItemDetails_Delete"
            Me.ButtonItemDetails_Delete.RibbonWordWrap = False
            Me.ButtonItemDetails_Delete.Stretch = True
            Me.ButtonItemDetails_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemDetails_Delete.Text = "Delete"
            '
            'ButtonItemDetails_Cancel
            '
            Me.ButtonItemDetails_Cancel.BeginGroup = True
            Me.ButtonItemDetails_Cancel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemDetails_Cancel.Enabled = False
            Me.ButtonItemDetails_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDetails_Cancel.Name = "ButtonItemDetails_Cancel"
            Me.ButtonItemDetails_Cancel.RibbonWordWrap = False
            Me.ButtonItemDetails_Cancel.Stretch = True
            Me.ButtonItemDetails_Cancel.SubItemsExpandWidth = 14
            Me.ButtonItemDetails_Cancel.Text = "Cancel"
            '
            'ButtonItemDetails_CopyFrom
            '
            Me.ButtonItemDetails_CopyFrom.BeginGroup = True
            Me.ButtonItemDetails_CopyFrom.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDetails_CopyFrom.Name = "ButtonItemDetails_CopyFrom"
            Me.ButtonItemDetails_CopyFrom.RibbonWordWrap = False
            Me.ButtonItemDetails_CopyFrom.SecurityEnabled = True
            Me.ButtonItemDetails_CopyFrom.SubItemsExpandWidth = 14
            Me.ButtonItemDetails_CopyFrom.Text = "Copy From"
            Me.ButtonItemDetails_CopyFrom.Visible = False
            '
            'ButtonItemDetails_ReverseDebitCredit
            '
            Me.ButtonItemDetails_ReverseDebitCredit.BeginGroup = True
            Me.ButtonItemDetails_ReverseDebitCredit.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDetails_ReverseDebitCredit.Name = "ButtonItemDetails_ReverseDebitCredit"
            Me.ButtonItemDetails_ReverseDebitCredit.RibbonWordWrap = False
            Me.ButtonItemDetails_ReverseDebitCredit.SecurityEnabled = True
            Me.ButtonItemDetails_ReverseDebitCredit.SubItemsExpandWidth = 14
            Me.ButtonItemDetails_ReverseDebitCredit.Text = "Reverse Debit/Credit"
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Add, Me.ButtonItemActions_Save, Me.ButtonItemActions_Cancel, Me.ButtonItemActions_Copy, Me.ButtonItemActions_Print})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(195, 98)
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
            Me.RibbonBarOptions_Actions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemActions_Add
            '
            Me.ButtonItemActions_Add.BeginGroup = True
            Me.ButtonItemActions_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Add.Name = "ButtonItemActions_Add"
            Me.ButtonItemActions_Add.RibbonWordWrap = False
            Me.ButtonItemActions_Add.SecurityEnabled = True
            Me.ButtonItemActions_Add.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Add.Text = "Add"
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
            'ButtonItemActions_Cancel
            '
            Me.ButtonItemActions_Cancel.BeginGroup = True
            Me.ButtonItemActions_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Cancel.Name = "ButtonItemActions_Cancel"
            Me.ButtonItemActions_Cancel.RibbonWordWrap = False
            Me.ButtonItemActions_Cancel.SecurityEnabled = True
            Me.ButtonItemActions_Cancel.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Cancel.Text = "Cancel"
            '
            'ButtonItemActions_Copy
            '
            Me.ButtonItemActions_Copy.BeginGroup = True
            Me.ButtonItemActions_Copy.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Copy.Name = "ButtonItemActions_Copy"
            Me.ButtonItemActions_Copy.RibbonWordWrap = False
            Me.ButtonItemActions_Copy.SecurityEnabled = True
            Me.ButtonItemActions_Copy.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Copy.Text = "Copy"
            '
            'ButtonItemActions_Print
            '
            Me.ButtonItemActions_Print.BeginGroup = True
            Me.ButtonItemActions_Print.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Print.Name = "ButtonItemActions_Print"
            Me.ButtonItemActions_Print.RibbonWordWrap = False
            Me.ButtonItemActions_Print.SecurityEnabled = True
            Me.ButtonItemActions_Print.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Print.Text = "Print"
            '
            'RibbonBarOptions_RecurringJournalEntries
            '
            Me.RibbonBarOptions_RecurringJournalEntries.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBarOptions_RecurringJournalEntries.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_RecurringJournalEntries.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_RecurringJournalEntries.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_RecurringJournalEntries.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_RecurringJournalEntries.DragDropSupport = True
            Me.RibbonBarOptions_RecurringJournalEntries.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemRecurringJournalEntries_Post})
            Me.RibbonBarOptions_RecurringJournalEntries.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_RecurringJournalEntries.Location = New System.Drawing.Point(474, 0)
            Me.RibbonBarOptions_RecurringJournalEntries.Name = "RibbonBarOptions_RecurringJournalEntries"
            Me.RibbonBarOptions_RecurringJournalEntries.SecurityEnabled = True
            Me.RibbonBarOptions_RecurringJournalEntries.Size = New System.Drawing.Size(87, 98)
            Me.RibbonBarOptions_RecurringJournalEntries.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_RecurringJournalEntries.TabIndex = 47
            Me.RibbonBarOptions_RecurringJournalEntries.Text = "Recur JE"
            '
            '
            '
            Me.RibbonBarOptions_RecurringJournalEntries.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_RecurringJournalEntries.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_RecurringJournalEntries.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemRecurringJournalEntries_Post
            '
            Me.ButtonItemRecurringJournalEntries_Post.BeginGroup = True
            Me.ButtonItemRecurringJournalEntries_Post.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemRecurringJournalEntries_Post.Name = "ButtonItemRecurringJournalEntries_Post"
            Me.ButtonItemRecurringJournalEntries_Post.RibbonWordWrap = False
            Me.ButtonItemRecurringJournalEntries_Post.SecurityEnabled = True
            Me.ButtonItemRecurringJournalEntries_Post.SubItemsExpandWidth = 14
            Me.ButtonItemRecurringJournalEntries_Post.Text = "Post"
            '
            'RecurringJournalEntrySetupForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(916, 539)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.PanelForm_RightSection)
            Me.Controls.Add(Me.ExpandableSplitterControlForm_LeftRight)
            Me.Controls.Add(Me.PanelForm_LeftSection)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "RecurringJournalEntrySetupForm"
            Me.Text = "Recurring Journal Entry"
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_LeftSection.ResumeLayout(False)
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_RightSection.ResumeLayout(False)
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents PanelForm_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents ExpandableSplitterControlForm_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelForm_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewLeftSection_RecurringJournalEntries As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Add As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Save As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Print As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RecurringJournalEntryControlRightSection_RecurringJournalEntry As WinForm.MVC.Presentation.Controls.RecurringJournalEntryControl
        Friend WithEvents ButtonItemActions_Cancel As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Details As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemDetails_Delete As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemDetails_Cancel As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Copy As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDetails_CopyFrom As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDetails_ReverseDebitCredit As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_RecurringJournalEntries As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemRecurringJournalEntries_Post As WinForm.Presentation.Controls.ButtonItem
    End Class

End Namespace

