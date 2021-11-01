Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class OtherCashReceiptControl
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
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OtherCashReceiptControl))
            Me.DataGridViewPanel_OtherReceiptDetails = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.PanelControl_Header = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.SearchableComboBoxPanel_PaymentType = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView1 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelPanel_PaymentType = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxPanel_PostPeriodForMod = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ComboBoxPanel_PostPeriod = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.TextBoxPanel_Description = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelPanel_Description = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelPanel_PostingPeriodForMod = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.GroupBoxPanel_Amounts = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.NumericInputDisbursedTo_Balance = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelDisbursedTo_Balance = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.NumericInputDisbursedTo_ClientInvoice = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelAmounts_Disbursed = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.GroupBoxPanel_GLTransactions = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.DataGridViewTransactions_GLTransactions = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.GroupBoxPanel_DepositInformation = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.SearchableComboBoxDepositInfo_GLAccount = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewDepositInfo_GLAccount = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxDepositInfo_Office = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewDepositInfo_Office = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.CheckBoxDepositInfo_Cleared = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelDepositInfo_Office = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelDepositInfo_Account = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxDepositInfo_Bank = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewDepositInfo_Bank = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelDepositInfo_Bank = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelDepositInfo_Date = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DateTimePickerDepositInfo_Date = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.GroupBoxPanel_CheckInformation = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.LabelCheckInfo_Amount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.NumericInputCheckInfo_Amount = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelCheckInfo_Date = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DateTimePickerCheckInfo_Date = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelPanel_CheckNumber = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelPanel_PostingPeriod = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxPanel_CheckNumber = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelPanel_Message = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxPanel_MessageDetails = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            CType(Me.PanelControl_Header, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelControl_Header.SuspendLayout()
            CType(Me.SearchableComboBoxPanel_PaymentType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxPanel_Amounts, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxPanel_Amounts.SuspendLayout()
            CType(Me.NumericInputDisbursedTo_Balance.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputDisbursedTo_ClientInvoice.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxPanel_GLTransactions, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxPanel_GLTransactions.SuspendLayout()
            CType(Me.GroupBoxPanel_DepositInformation, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxPanel_DepositInformation.SuspendLayout()
            CType(Me.SearchableComboBoxDepositInfo_GLAccount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewDepositInfo_GLAccount, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxDepositInfo_Office.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewDepositInfo_Office, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxDepositInfo_Bank.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewDepositInfo_Bank, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerDepositInfo_Date, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxPanel_CheckInformation, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxPanel_CheckInformation.SuspendLayout()
            CType(Me.NumericInputCheckInfo_Amount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerCheckInfo_Date, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'DataGridViewPanel_OtherReceiptDetails
            '
            Me.DataGridViewPanel_OtherReceiptDetails.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewPanel_OtherReceiptDetails.AllowDragAndDrop = False
            Me.DataGridViewPanel_OtherReceiptDetails.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewPanel_OtherReceiptDetails.AllowSelectGroupHeaderRow = True
            Me.DataGridViewPanel_OtherReceiptDetails.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewPanel_OtherReceiptDetails.AutoFilterLookupColumns = False
            Me.DataGridViewPanel_OtherReceiptDetails.AutoloadRepositoryDatasource = True
            Me.DataGridViewPanel_OtherReceiptDetails.AutoUpdateViewCaption = True
            Me.DataGridViewPanel_OtherReceiptDetails.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewPanel_OtherReceiptDetails.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewPanel_OtherReceiptDetails.Dock = System.Windows.Forms.DockStyle.Fill
            Me.DataGridViewPanel_OtherReceiptDetails.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewPanel_OtherReceiptDetails.ItemDescription = ""
            Me.DataGridViewPanel_OtherReceiptDetails.Location = New System.Drawing.Point(0, 282)
            Me.DataGridViewPanel_OtherReceiptDetails.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewPanel_OtherReceiptDetails.MultiSelect = True
            Me.DataGridViewPanel_OtherReceiptDetails.Name = "DataGridViewPanel_OtherReceiptDetails"
            Me.DataGridViewPanel_OtherReceiptDetails.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewPanel_OtherReceiptDetails.RunStandardValidation = True
            Me.DataGridViewPanel_OtherReceiptDetails.ShowColumnMenuOnRightClick = False
            Me.DataGridViewPanel_OtherReceiptDetails.ShowSelectDeselectAllButtons = False
            Me.DataGridViewPanel_OtherReceiptDetails.Size = New System.Drawing.Size(992, 333)
            Me.DataGridViewPanel_OtherReceiptDetails.TabIndex = 1
            Me.DataGridViewPanel_OtherReceiptDetails.UseEmbeddedNavigator = False
            Me.DataGridViewPanel_OtherReceiptDetails.ViewCaptionHeight = -1
            '
            'PanelControl_Header
            '
            Me.PanelControl_Header.Controls.Add(Me.TextBoxPanel_MessageDetails)
            Me.PanelControl_Header.Controls.Add(Me.LabelPanel_Message)
            Me.PanelControl_Header.Controls.Add(Me.SearchableComboBoxPanel_PaymentType)
            Me.PanelControl_Header.Controls.Add(Me.LabelPanel_PaymentType)
            Me.PanelControl_Header.Controls.Add(Me.ComboBoxPanel_PostPeriodForMod)
            Me.PanelControl_Header.Controls.Add(Me.ComboBoxPanel_PostPeriod)
            Me.PanelControl_Header.Controls.Add(Me.TextBoxPanel_Description)
            Me.PanelControl_Header.Controls.Add(Me.LabelPanel_Description)
            Me.PanelControl_Header.Controls.Add(Me.LabelPanel_PostingPeriodForMod)
            Me.PanelControl_Header.Controls.Add(Me.GroupBoxPanel_Amounts)
            Me.PanelControl_Header.Controls.Add(Me.GroupBoxPanel_GLTransactions)
            Me.PanelControl_Header.Controls.Add(Me.GroupBoxPanel_DepositInformation)
            Me.PanelControl_Header.Controls.Add(Me.GroupBoxPanel_CheckInformation)
            Me.PanelControl_Header.Controls.Add(Me.LabelPanel_CheckNumber)
            Me.PanelControl_Header.Controls.Add(Me.LabelPanel_PostingPeriod)
            Me.PanelControl_Header.Controls.Add(Me.TextBoxPanel_CheckNumber)
            Me.PanelControl_Header.Dock = System.Windows.Forms.DockStyle.Top
            Me.PanelControl_Header.Location = New System.Drawing.Point(0, 0)
            Me.PanelControl_Header.Name = "PanelControl_Header"
            Me.PanelControl_Header.Size = New System.Drawing.Size(992, 282)
            Me.PanelControl_Header.TabIndex = 0
            '
            'SearchableComboBoxPanel_PaymentType
            '
            Me.SearchableComboBoxPanel_PaymentType.ActiveFilterString = ""
            Me.SearchableComboBoxPanel_PaymentType.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxPanel_PaymentType.AutoFillMode = False
            Me.SearchableComboBoxPanel_PaymentType.BookmarkingEnabled = False
            Me.SearchableComboBoxPanel_PaymentType.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.PaymentType
            Me.SearchableComboBoxPanel_PaymentType.DataSource = Nothing
            Me.SearchableComboBoxPanel_PaymentType.DisableMouseWheel = True
            Me.SearchableComboBoxPanel_PaymentType.DisplayName = ""
            Me.SearchableComboBoxPanel_PaymentType.Enabled = False
            Me.SearchableComboBoxPanel_PaymentType.EnterMoveNextControl = True
            Me.SearchableComboBoxPanel_PaymentType.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.None
            Me.SearchableComboBoxPanel_PaymentType.Location = New System.Drawing.Point(407, 59)
            Me.SearchableComboBoxPanel_PaymentType.Name = "SearchableComboBoxPanel_PaymentType"
            Me.SearchableComboBoxPanel_PaymentType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxPanel_PaymentType.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxPanel_PaymentType.Properties.NullText = "Select Payment Type"
            Me.SearchableComboBoxPanel_PaymentType.Properties.ShowClearButton = False
            Me.SearchableComboBoxPanel_PaymentType.Properties.ValueMember = "ID"
            Me.SearchableComboBoxPanel_PaymentType.Properties.View = Me.GridView1
            Me.SearchableComboBoxPanel_PaymentType.SecurityEnabled = True
            Me.SearchableComboBoxPanel_PaymentType.SelectedValue = Nothing
            Me.SearchableComboBoxPanel_PaymentType.Size = New System.Drawing.Size(135, 20)
            Me.SearchableComboBoxPanel_PaymentType.TabIndex = 11
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
            'LabelPanel_PaymentType
            '
            Me.LabelPanel_PaymentType.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPanel_PaymentType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPanel_PaymentType.Location = New System.Drawing.Point(320, 57)
            Me.LabelPanel_PaymentType.Name = "LabelPanel_PaymentType"
            Me.LabelPanel_PaymentType.Size = New System.Drawing.Size(81, 20)
            Me.LabelPanel_PaymentType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPanel_PaymentType.TabIndex = 10
            Me.LabelPanel_PaymentType.Text = "Payment Type:"
            '
            'ComboBoxPanel_PostPeriodForMod
            '
            Me.ComboBoxPanel_PostPeriodForMod.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxPanel_PostPeriodForMod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxPanel_PostPeriodForMod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxPanel_PostPeriodForMod.AutoFindItemInDataSource = False
            Me.ComboBoxPanel_PostPeriodForMod.AutoSelectSingleItemDatasource = False
            Me.ComboBoxPanel_PostPeriodForMod.BookmarkingEnabled = False
            Me.ComboBoxPanel_PostPeriodForMod.ClientCode = ""
            Me.ComboBoxPanel_PostPeriodForMod.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.PostPeriod
            Me.ComboBoxPanel_PostPeriodForMod.DisableMouseWheel = True
            Me.ComboBoxPanel_PostPeriodForMod.DisplayMember = "Description"
            Me.ComboBoxPanel_PostPeriodForMod.DisplayName = ""
            Me.ComboBoxPanel_PostPeriodForMod.DivisionCode = ""
            Me.ComboBoxPanel_PostPeriodForMod.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxPanel_PostPeriodForMod.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxPanel_PostPeriodForMod.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxPanel_PostPeriodForMod.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxPanel_PostPeriodForMod.FocusHighlightEnabled = True
            Me.ComboBoxPanel_PostPeriodForMod.FormattingEnabled = True
            Me.ComboBoxPanel_PostPeriodForMod.ItemHeight = 15
            Me.ComboBoxPanel_PostPeriodForMod.Location = New System.Drawing.Point(407, 32)
            Me.ComboBoxPanel_PostPeriodForMod.Name = "ComboBoxPanel_PostPeriodForMod"
            Me.ComboBoxPanel_PostPeriodForMod.ReadOnly = False
            Me.ComboBoxPanel_PostPeriodForMod.SecurityEnabled = True
            Me.ComboBoxPanel_PostPeriodForMod.Size = New System.Drawing.Size(135, 21)
            Me.ComboBoxPanel_PostPeriodForMod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxPanel_PostPeriodForMod.TabIndex = 9
            Me.ComboBoxPanel_PostPeriodForMod.TabOnEnter = True
            Me.ComboBoxPanel_PostPeriodForMod.ValueMember = "Code"
            Me.ComboBoxPanel_PostPeriodForMod.WatermarkText = "Select Post Period"
            '
            'ComboBoxPanel_PostPeriod
            '
            Me.ComboBoxPanel_PostPeriod.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxPanel_PostPeriod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxPanel_PostPeriod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxPanel_PostPeriod.AutoFindItemInDataSource = False
            Me.ComboBoxPanel_PostPeriod.AutoSelectSingleItemDatasource = False
            Me.ComboBoxPanel_PostPeriod.BookmarkingEnabled = False
            Me.ComboBoxPanel_PostPeriod.ClientCode = ""
            Me.ComboBoxPanel_PostPeriod.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.PostPeriod
            Me.ComboBoxPanel_PostPeriod.DisableMouseWheel = True
            Me.ComboBoxPanel_PostPeriod.DisplayMember = "Description"
            Me.ComboBoxPanel_PostPeriod.DisplayName = ""
            Me.ComboBoxPanel_PostPeriod.DivisionCode = ""
            Me.ComboBoxPanel_PostPeriod.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxPanel_PostPeriod.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxPanel_PostPeriod.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxPanel_PostPeriod.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxPanel_PostPeriod.FocusHighlightEnabled = True
            Me.ComboBoxPanel_PostPeriod.FormattingEnabled = True
            Me.ComboBoxPanel_PostPeriod.ItemHeight = 15
            Me.ComboBoxPanel_PostPeriod.Location = New System.Drawing.Point(407, 5)
            Me.ComboBoxPanel_PostPeriod.Name = "ComboBoxPanel_PostPeriod"
            Me.ComboBoxPanel_PostPeriod.ReadOnly = False
            Me.ComboBoxPanel_PostPeriod.SecurityEnabled = True
            Me.ComboBoxPanel_PostPeriod.Size = New System.Drawing.Size(135, 21)
            Me.ComboBoxPanel_PostPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxPanel_PostPeriod.TabIndex = 7
            Me.ComboBoxPanel_PostPeriod.TabOnEnter = True
            Me.ComboBoxPanel_PostPeriod.ValueMember = "Code"
            Me.ComboBoxPanel_PostPeriod.WatermarkText = "Select Post Period"
            '
            'TextBoxPanel_Description
            '
            Me.TextBoxPanel_Description.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxPanel_Description.Border.Class = "TextBoxBorder"
            Me.TextBoxPanel_Description.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxPanel_Description.CheckSpellingOnValidate = False
            Me.TextBoxPanel_Description.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxPanel_Description.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxPanel_Description.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxPanel_Description.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxPanel_Description.FocusHighlightEnabled = True
            Me.TextBoxPanel_Description.ForeColor = System.Drawing.Color.Black
            Me.TextBoxPanel_Description.Location = New System.Drawing.Point(92, 34)
            Me.TextBoxPanel_Description.MaxFileSize = CType(0, Long)
            Me.TextBoxPanel_Description.Name = "TextBoxPanel_Description"
            Me.TextBoxPanel_Description.SecurityEnabled = True
            Me.TextBoxPanel_Description.ShowSpellCheckCompleteMessage = True
            Me.TextBoxPanel_Description.Size = New System.Drawing.Size(222, 21)
            Me.TextBoxPanel_Description.StartingFolderName = Nothing
            Me.TextBoxPanel_Description.TabIndex = 3
            Me.TextBoxPanel_Description.TabOnEnter = True
            '
            'LabelPanel_Description
            '
            Me.LabelPanel_Description.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPanel_Description.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPanel_Description.Location = New System.Drawing.Point(5, 31)
            Me.LabelPanel_Description.Name = "LabelPanel_Description"
            Me.LabelPanel_Description.Size = New System.Drawing.Size(81, 20)
            Me.LabelPanel_Description.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPanel_Description.TabIndex = 2
            Me.LabelPanel_Description.Text = "Description:"
            '
            'LabelPanel_PostingPeriodForMod
            '
            Me.LabelPanel_PostingPeriodForMod.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPanel_PostingPeriodForMod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPanel_PostingPeriodForMod.Location = New System.Drawing.Point(320, 31)
            Me.LabelPanel_PostingPeriodForMod.Name = "LabelPanel_PostingPeriodForMod"
            Me.LabelPanel_PostingPeriodForMod.Size = New System.Drawing.Size(81, 20)
            Me.LabelPanel_PostingPeriodForMod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPanel_PostingPeriodForMod.TabIndex = 8
            Me.LabelPanel_PostingPeriodForMod.Text = "P/P for Mod:"
            '
            'GroupBoxPanel_Amounts
            '
            Me.GroupBoxPanel_Amounts.Controls.Add(Me.NumericInputDisbursedTo_Balance)
            Me.GroupBoxPanel_Amounts.Controls.Add(Me.LabelDisbursedTo_Balance)
            Me.GroupBoxPanel_Amounts.Controls.Add(Me.NumericInputDisbursedTo_ClientInvoice)
            Me.GroupBoxPanel_Amounts.Controls.Add(Me.LabelAmounts_Disbursed)
            Me.GroupBoxPanel_Amounts.Location = New System.Drawing.Point(320, 144)
            Me.GroupBoxPanel_Amounts.Name = "GroupBoxPanel_Amounts"
            Me.GroupBoxPanel_Amounts.Size = New System.Drawing.Size(227, 79)
            Me.GroupBoxPanel_Amounts.TabIndex = 12
            Me.GroupBoxPanel_Amounts.Text = "Amounts"
            '
            'NumericInputDisbursedTo_Balance
            '
            Me.NumericInputDisbursedTo_Balance.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputDisbursedTo_Balance.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputDisbursedTo_Balance.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputDisbursedTo_Balance.EnterMoveNextControl = True
            Me.NumericInputDisbursedTo_Balance.Location = New System.Drawing.Point(86, 50)
            Me.NumericInputDisbursedTo_Balance.Name = "NumericInputDisbursedTo_Balance"
            Me.NumericInputDisbursedTo_Balance.Properties.AllowMouseWheel = False
            Me.NumericInputDisbursedTo_Balance.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control
            Me.NumericInputDisbursedTo_Balance.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputDisbursedTo_Balance.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputDisbursedTo_Balance.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDisbursedTo_Balance.Properties.EditFormat.FormatString = "f"
            Me.NumericInputDisbursedTo_Balance.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDisbursedTo_Balance.Properties.Mask.EditMask = "f"
            Me.NumericInputDisbursedTo_Balance.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputDisbursedTo_Balance.Properties.ReadOnly = True
            Me.NumericInputDisbursedTo_Balance.SecurityEnabled = True
            Me.NumericInputDisbursedTo_Balance.Size = New System.Drawing.Size(135, 20)
            Me.NumericInputDisbursedTo_Balance.TabIndex = 3
            Me.NumericInputDisbursedTo_Balance.TabStop = False
            '
            'LabelDisbursedTo_Balance
            '
            Me.LabelDisbursedTo_Balance.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDisbursedTo_Balance.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDisbursedTo_Balance.Location = New System.Drawing.Point(5, 50)
            Me.LabelDisbursedTo_Balance.Name = "LabelDisbursedTo_Balance"
            Me.LabelDisbursedTo_Balance.Size = New System.Drawing.Size(78, 20)
            Me.LabelDisbursedTo_Balance.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDisbursedTo_Balance.TabIndex = 2
            Me.LabelDisbursedTo_Balance.Text = "Balance:"
            '
            'NumericInputDisbursedTo_ClientInvoice
            '
            Me.NumericInputDisbursedTo_ClientInvoice.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputDisbursedTo_ClientInvoice.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputDisbursedTo_ClientInvoice.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputDisbursedTo_ClientInvoice.EnterMoveNextControl = True
            Me.NumericInputDisbursedTo_ClientInvoice.Location = New System.Drawing.Point(86, 24)
            Me.NumericInputDisbursedTo_ClientInvoice.Name = "NumericInputDisbursedTo_ClientInvoice"
            Me.NumericInputDisbursedTo_ClientInvoice.Properties.AllowMouseWheel = False
            Me.NumericInputDisbursedTo_ClientInvoice.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control
            Me.NumericInputDisbursedTo_ClientInvoice.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputDisbursedTo_ClientInvoice.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputDisbursedTo_ClientInvoice.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDisbursedTo_ClientInvoice.Properties.EditFormat.FormatString = "f"
            Me.NumericInputDisbursedTo_ClientInvoice.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDisbursedTo_ClientInvoice.Properties.Mask.EditMask = "f"
            Me.NumericInputDisbursedTo_ClientInvoice.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputDisbursedTo_ClientInvoice.Properties.ReadOnly = True
            Me.NumericInputDisbursedTo_ClientInvoice.SecurityEnabled = True
            Me.NumericInputDisbursedTo_ClientInvoice.Size = New System.Drawing.Size(135, 20)
            Me.NumericInputDisbursedTo_ClientInvoice.TabIndex = 1
            Me.NumericInputDisbursedTo_ClientInvoice.TabStop = False
            '
            'LabelAmounts_Disbursed
            '
            Me.LabelAmounts_Disbursed.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAmounts_Disbursed.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAmounts_Disbursed.Location = New System.Drawing.Point(6, 24)
            Me.LabelAmounts_Disbursed.Name = "LabelAmounts_Disbursed"
            Me.LabelAmounts_Disbursed.Size = New System.Drawing.Size(78, 20)
            Me.LabelAmounts_Disbursed.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAmounts_Disbursed.TabIndex = 0
            Me.LabelAmounts_Disbursed.Text = "Disbursed:"
            '
            'GroupBoxPanel_GLTransactions
            '
            Me.GroupBoxPanel_GLTransactions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxPanel_GLTransactions.Controls.Add(Me.DataGridViewTransactions_GLTransactions)
            Me.GroupBoxPanel_GLTransactions.Location = New System.Drawing.Point(553, 5)
            Me.GroupBoxPanel_GLTransactions.Name = "GroupBoxPanel_GLTransactions"
            Me.GroupBoxPanel_GLTransactions.Size = New System.Drawing.Size(434, 218)
            Me.GroupBoxPanel_GLTransactions.TabIndex = 13
            Me.GroupBoxPanel_GLTransactions.Text = "GL Transactions"
            '
            'DataGridViewTransactions_GLTransactions
            '
            Me.DataGridViewTransactions_GLTransactions.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewTransactions_GLTransactions.AllowDragAndDrop = False
            Me.DataGridViewTransactions_GLTransactions.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewTransactions_GLTransactions.AllowSelectGroupHeaderRow = True
            Me.DataGridViewTransactions_GLTransactions.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewTransactions_GLTransactions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewTransactions_GLTransactions.AutoFilterLookupColumns = False
            Me.DataGridViewTransactions_GLTransactions.AutoloadRepositoryDatasource = True
            Me.DataGridViewTransactions_GLTransactions.AutoUpdateViewCaption = True
            Me.DataGridViewTransactions_GLTransactions.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewTransactions_GLTransactions.DataSource = Nothing
            Me.DataGridViewTransactions_GLTransactions.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewTransactions_GLTransactions.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewTransactions_GLTransactions.ItemDescription = "GL Transaction(s)"
            Me.DataGridViewTransactions_GLTransactions.Location = New System.Drawing.Point(6, 25)
            Me.DataGridViewTransactions_GLTransactions.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewTransactions_GLTransactions.MultiSelect = False
            Me.DataGridViewTransactions_GLTransactions.Name = "DataGridViewTransactions_GLTransactions"
            Me.DataGridViewTransactions_GLTransactions.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewTransactions_GLTransactions.RunStandardValidation = True
            Me.DataGridViewTransactions_GLTransactions.ShowColumnMenuOnRightClick = False
            Me.DataGridViewTransactions_GLTransactions.ShowSelectDeselectAllButtons = False
            Me.DataGridViewTransactions_GLTransactions.Size = New System.Drawing.Size(422, 187)
            Me.DataGridViewTransactions_GLTransactions.TabIndex = 0
            Me.DataGridViewTransactions_GLTransactions.TabStop = False
            Me.DataGridViewTransactions_GLTransactions.UseEmbeddedNavigator = False
            Me.DataGridViewTransactions_GLTransactions.ViewCaptionHeight = -1
            '
            'GroupBoxPanel_DepositInformation
            '
            Me.GroupBoxPanel_DepositInformation.Controls.Add(Me.SearchableComboBoxDepositInfo_GLAccount)
            Me.GroupBoxPanel_DepositInformation.Controls.Add(Me.SearchableComboBoxDepositInfo_Office)
            Me.GroupBoxPanel_DepositInformation.Controls.Add(Me.CheckBoxDepositInfo_Cleared)
            Me.GroupBoxPanel_DepositInformation.Controls.Add(Me.LabelDepositInfo_Office)
            Me.GroupBoxPanel_DepositInformation.Controls.Add(Me.LabelDepositInfo_Account)
            Me.GroupBoxPanel_DepositInformation.Controls.Add(Me.SearchableComboBoxDepositInfo_Bank)
            Me.GroupBoxPanel_DepositInformation.Controls.Add(Me.LabelDepositInfo_Bank)
            Me.GroupBoxPanel_DepositInformation.Controls.Add(Me.LabelDepositInfo_Date)
            Me.GroupBoxPanel_DepositInformation.Controls.Add(Me.DateTimePickerDepositInfo_Date)
            Me.GroupBoxPanel_DepositInformation.Location = New System.Drawing.Point(5, 144)
            Me.GroupBoxPanel_DepositInformation.Name = "GroupBoxPanel_DepositInformation"
            Me.GroupBoxPanel_DepositInformation.Size = New System.Drawing.Size(309, 128)
            Me.GroupBoxPanel_DepositInformation.TabIndex = 5
            Me.GroupBoxPanel_DepositInformation.Text = "Deposit Information"
            '
            'SearchableComboBoxDepositInfo_GLAccount
            '
            Me.SearchableComboBoxDepositInfo_GLAccount.ActiveFilterString = ""
            Me.SearchableComboBoxDepositInfo_GLAccount.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxDepositInfo_GLAccount.AutoFillMode = False
            Me.SearchableComboBoxDepositInfo_GLAccount.BookmarkingEnabled = False
            Me.SearchableComboBoxDepositInfo_GLAccount.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.GeneralLedgerAccount
            Me.SearchableComboBoxDepositInfo_GLAccount.DataSource = Nothing
            Me.SearchableComboBoxDepositInfo_GLAccount.DisableMouseWheel = True
            Me.SearchableComboBoxDepositInfo_GLAccount.DisplayName = ""
            Me.SearchableComboBoxDepositInfo_GLAccount.EnterMoveNextControl = True
            Me.SearchableComboBoxDepositInfo_GLAccount.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.None
            Me.SearchableComboBoxDepositInfo_GLAccount.Location = New System.Drawing.Point(60, 102)
            Me.SearchableComboBoxDepositInfo_GLAccount.Name = "SearchableComboBoxDepositInfo_GLAccount"
            Me.SearchableComboBoxDepositInfo_GLAccount.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxDepositInfo_GLAccount.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxDepositInfo_GLAccount.Properties.NullText = "Select General Ledger Account"
            Me.SearchableComboBoxDepositInfo_GLAccount.Properties.ReadOnly = True
            Me.SearchableComboBoxDepositInfo_GLAccount.Properties.ShowClearButton = False
            Me.SearchableComboBoxDepositInfo_GLAccount.Properties.ValueMember = "Code"
            Me.SearchableComboBoxDepositInfo_GLAccount.Properties.View = Me.SearchableComboBoxViewDepositInfo_GLAccount
            Me.SearchableComboBoxDepositInfo_GLAccount.SecurityEnabled = True
            Me.SearchableComboBoxDepositInfo_GLAccount.SelectedValue = Nothing
            Me.SearchableComboBoxDepositInfo_GLAccount.Size = New System.Drawing.Size(244, 20)
            Me.SearchableComboBoxDepositInfo_GLAccount.TabIndex = 8
            Me.SearchableComboBoxDepositInfo_GLAccount.TabStop = False
            '
            'SearchableComboBoxViewDepositInfo_GLAccount
            '
            Me.SearchableComboBoxViewDepositInfo_GLAccount.AFActiveFilterString = ""
            Me.SearchableComboBoxViewDepositInfo_GLAccount.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewDepositInfo_GLAccount.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_GLAccount.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_GLAccount.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_GLAccount.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_GLAccount.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_GLAccount.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_GLAccount.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_GLAccount.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_GLAccount.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_GLAccount.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_GLAccount.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_GLAccount.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_GLAccount.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_GLAccount.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_GLAccount.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_GLAccount.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_GLAccount.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_GLAccount.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_GLAccount.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_GLAccount.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_GLAccount.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_GLAccount.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_GLAccount.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_GLAccount.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_GLAccount.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_GLAccount.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_GLAccount.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_GLAccount.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_GLAccount.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_GLAccount.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_GLAccount.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_GLAccount.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_GLAccount.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_GLAccount.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_GLAccount.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_GLAccount.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_GLAccount.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_GLAccount.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewDepositInfo_GLAccount.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewDepositInfo_GLAccount.DataSourceClearing = False
            Me.SearchableComboBoxViewDepositInfo_GLAccount.EnableDisabledRows = False
            Me.SearchableComboBoxViewDepositInfo_GLAccount.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewDepositInfo_GLAccount.Name = "SearchableComboBoxViewDepositInfo_GLAccount"
            Me.SearchableComboBoxViewDepositInfo_GLAccount.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewDepositInfo_GLAccount.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewDepositInfo_GLAccount.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewDepositInfo_GLAccount.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewDepositInfo_GLAccount.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewDepositInfo_GLAccount.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewDepositInfo_GLAccount.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewDepositInfo_GLAccount.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewDepositInfo_GLAccount.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewDepositInfo_GLAccount.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewDepositInfo_GLAccount.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewDepositInfo_GLAccount.RunStandardValidation = True
            '
            'SearchableComboBoxDepositInfo_Office
            '
            Me.SearchableComboBoxDepositInfo_Office.ActiveFilterString = ""
            Me.SearchableComboBoxDepositInfo_Office.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxDepositInfo_Office.AutoFillMode = False
            Me.SearchableComboBoxDepositInfo_Office.BookmarkingEnabled = False
            Me.SearchableComboBoxDepositInfo_Office.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Office
            Me.SearchableComboBoxDepositInfo_Office.DataSource = Nothing
            Me.SearchableComboBoxDepositInfo_Office.DisableMouseWheel = True
            Me.SearchableComboBoxDepositInfo_Office.DisplayName = ""
            Me.SearchableComboBoxDepositInfo_Office.EnterMoveNextControl = True
            Me.SearchableComboBoxDepositInfo_Office.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.None
            Me.SearchableComboBoxDepositInfo_Office.Location = New System.Drawing.Point(60, 76)
            Me.SearchableComboBoxDepositInfo_Office.Name = "SearchableComboBoxDepositInfo_Office"
            Me.SearchableComboBoxDepositInfo_Office.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxDepositInfo_Office.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxDepositInfo_Office.Properties.NullText = "Select Office"
            Me.SearchableComboBoxDepositInfo_Office.Properties.ReadOnly = True
            Me.SearchableComboBoxDepositInfo_Office.Properties.ShowClearButton = False
            Me.SearchableComboBoxDepositInfo_Office.Properties.ValueMember = "Code"
            Me.SearchableComboBoxDepositInfo_Office.Properties.View = Me.SearchableComboBoxViewDepositInfo_Office
            Me.SearchableComboBoxDepositInfo_Office.SecurityEnabled = True
            Me.SearchableComboBoxDepositInfo_Office.SelectedValue = Nothing
            Me.SearchableComboBoxDepositInfo_Office.Size = New System.Drawing.Size(244, 20)
            Me.SearchableComboBoxDepositInfo_Office.TabIndex = 6
            Me.SearchableComboBoxDepositInfo_Office.TabStop = False
            '
            'SearchableComboBoxViewDepositInfo_Office
            '
            Me.SearchableComboBoxViewDepositInfo_Office.AFActiveFilterString = ""
            Me.SearchableComboBoxViewDepositInfo_Office.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewDepositInfo_Office.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Office.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Office.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Office.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Office.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Office.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Office.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Office.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Office.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Office.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Office.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Office.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Office.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Office.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Office.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Office.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Office.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Office.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Office.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Office.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Office.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Office.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Office.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Office.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Office.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Office.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Office.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Office.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Office.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Office.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Office.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Office.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Office.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Office.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Office.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Office.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Office.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Office.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewDepositInfo_Office.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewDepositInfo_Office.DataSourceClearing = False
            Me.SearchableComboBoxViewDepositInfo_Office.EnableDisabledRows = False
            Me.SearchableComboBoxViewDepositInfo_Office.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewDepositInfo_Office.Name = "SearchableComboBoxViewDepositInfo_Office"
            Me.SearchableComboBoxViewDepositInfo_Office.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewDepositInfo_Office.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewDepositInfo_Office.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewDepositInfo_Office.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewDepositInfo_Office.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewDepositInfo_Office.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewDepositInfo_Office.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewDepositInfo_Office.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewDepositInfo_Office.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewDepositInfo_Office.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewDepositInfo_Office.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewDepositInfo_Office.RunStandardValidation = True
            '
            'CheckBoxDepositInfo_Cleared
            '
            Me.CheckBoxDepositInfo_Cleared.AutoCheck = False
            '
            '
            '
            Me.CheckBoxDepositInfo_Cleared.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxDepositInfo_Cleared.CheckValue = 0
            Me.CheckBoxDepositInfo_Cleared.CheckValueChecked = 1
            Me.CheckBoxDepositInfo_Cleared.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxDepositInfo_Cleared.CheckValueUnchecked = 0
            Me.CheckBoxDepositInfo_Cleared.ChildControls = CType(resources.GetObject("CheckBoxDepositInfo_Cleared.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxDepositInfo_Cleared.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxDepositInfo_Cleared.Location = New System.Drawing.Point(163, 24)
            Me.CheckBoxDepositInfo_Cleared.Name = "CheckBoxDepositInfo_Cleared"
            Me.CheckBoxDepositInfo_Cleared.OldestSibling = Nothing
            Me.CheckBoxDepositInfo_Cleared.SecurityEnabled = True
            Me.CheckBoxDepositInfo_Cleared.SiblingControls = CType(resources.GetObject("CheckBoxDepositInfo_Cleared.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxDepositInfo_Cleared.Size = New System.Drawing.Size(100, 23)
            Me.CheckBoxDepositInfo_Cleared.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxDepositInfo_Cleared.TabIndex = 2
            Me.CheckBoxDepositInfo_Cleared.TabOnEnter = True
            Me.CheckBoxDepositInfo_Cleared.TabStop = False
            Me.CheckBoxDepositInfo_Cleared.Text = "Is Cleared"
            '
            'LabelDepositInfo_Office
            '
            Me.LabelDepositInfo_Office.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDepositInfo_Office.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDepositInfo_Office.Location = New System.Drawing.Point(5, 76)
            Me.LabelDepositInfo_Office.Name = "LabelDepositInfo_Office"
            Me.LabelDepositInfo_Office.Size = New System.Drawing.Size(49, 20)
            Me.LabelDepositInfo_Office.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDepositInfo_Office.TabIndex = 5
            Me.LabelDepositInfo_Office.Text = "Office:"
            '
            'LabelDepositInfo_Account
            '
            Me.LabelDepositInfo_Account.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDepositInfo_Account.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDepositInfo_Account.Location = New System.Drawing.Point(5, 102)
            Me.LabelDepositInfo_Account.Name = "LabelDepositInfo_Account"
            Me.LabelDepositInfo_Account.Size = New System.Drawing.Size(49, 20)
            Me.LabelDepositInfo_Account.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDepositInfo_Account.TabIndex = 7
            Me.LabelDepositInfo_Account.Text = "Account:"
            '
            'SearchableComboBoxDepositInfo_Bank
            '
            Me.SearchableComboBoxDepositInfo_Bank.ActiveFilterString = ""
            Me.SearchableComboBoxDepositInfo_Bank.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxDepositInfo_Bank.AutoFillMode = False
            Me.SearchableComboBoxDepositInfo_Bank.BookmarkingEnabled = False
            Me.SearchableComboBoxDepositInfo_Bank.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Bank
            Me.SearchableComboBoxDepositInfo_Bank.DataSource = Nothing
            Me.SearchableComboBoxDepositInfo_Bank.DisableMouseWheel = True
            Me.SearchableComboBoxDepositInfo_Bank.DisplayName = ""
            Me.SearchableComboBoxDepositInfo_Bank.EnterMoveNextControl = True
            Me.SearchableComboBoxDepositInfo_Bank.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxDepositInfo_Bank.Location = New System.Drawing.Point(60, 50)
            Me.SearchableComboBoxDepositInfo_Bank.Name = "SearchableComboBoxDepositInfo_Bank"
            Me.SearchableComboBoxDepositInfo_Bank.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxDepositInfo_Bank.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxDepositInfo_Bank.Properties.NullText = "Select Bank"
            Me.SearchableComboBoxDepositInfo_Bank.Properties.ShowClearButton = False
            Me.SearchableComboBoxDepositInfo_Bank.Properties.ValueMember = "Code"
            Me.SearchableComboBoxDepositInfo_Bank.Properties.View = Me.SearchableComboBoxViewDepositInfo_Bank
            Me.SearchableComboBoxDepositInfo_Bank.SecurityEnabled = True
            Me.SearchableComboBoxDepositInfo_Bank.SelectedValue = Nothing
            Me.SearchableComboBoxDepositInfo_Bank.Size = New System.Drawing.Size(244, 20)
            Me.SearchableComboBoxDepositInfo_Bank.TabIndex = 4
            '
            'SearchableComboBoxViewDepositInfo_Bank
            '
            Me.SearchableComboBoxViewDepositInfo_Bank.AFActiveFilterString = ""
            Me.SearchableComboBoxViewDepositInfo_Bank.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewDepositInfo_Bank.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Bank.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Bank.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Bank.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Bank.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Bank.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Bank.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Bank.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Bank.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Bank.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Bank.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Bank.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Bank.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Bank.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Bank.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Bank.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Bank.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Bank.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Bank.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Bank.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Bank.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Bank.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Bank.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Bank.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Bank.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Bank.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Bank.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Bank.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Bank.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Bank.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Bank.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Bank.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Bank.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Bank.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Bank.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Bank.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Bank.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewDepositInfo_Bank.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewDepositInfo_Bank.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewDepositInfo_Bank.DataSourceClearing = False
            Me.SearchableComboBoxViewDepositInfo_Bank.EnableDisabledRows = False
            Me.SearchableComboBoxViewDepositInfo_Bank.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewDepositInfo_Bank.Name = "SearchableComboBoxViewDepositInfo_Bank"
            Me.SearchableComboBoxViewDepositInfo_Bank.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewDepositInfo_Bank.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewDepositInfo_Bank.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewDepositInfo_Bank.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewDepositInfo_Bank.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewDepositInfo_Bank.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewDepositInfo_Bank.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewDepositInfo_Bank.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewDepositInfo_Bank.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewDepositInfo_Bank.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewDepositInfo_Bank.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewDepositInfo_Bank.RunStandardValidation = True
            '
            'LabelDepositInfo_Bank
            '
            Me.LabelDepositInfo_Bank.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDepositInfo_Bank.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDepositInfo_Bank.Location = New System.Drawing.Point(5, 50)
            Me.LabelDepositInfo_Bank.Name = "LabelDepositInfo_Bank"
            Me.LabelDepositInfo_Bank.Size = New System.Drawing.Size(49, 20)
            Me.LabelDepositInfo_Bank.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDepositInfo_Bank.TabIndex = 3
            Me.LabelDepositInfo_Bank.Text = "Bank:"
            '
            'LabelDepositInfo_Date
            '
            Me.LabelDepositInfo_Date.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDepositInfo_Date.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDepositInfo_Date.Location = New System.Drawing.Point(5, 24)
            Me.LabelDepositInfo_Date.Name = "LabelDepositInfo_Date"
            Me.LabelDepositInfo_Date.Size = New System.Drawing.Size(49, 20)
            Me.LabelDepositInfo_Date.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDepositInfo_Date.TabIndex = 0
            Me.LabelDepositInfo_Date.Text = "Date:"
            '
            'DateTimePickerDepositInfo_Date
            '
            Me.DateTimePickerDepositInfo_Date.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerDepositInfo_Date.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerDepositInfo_Date.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDepositInfo_Date.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerDepositInfo_Date.ButtonDropDown.Visible = True
            Me.DateTimePickerDepositInfo_Date.ButtonFreeText.Checked = True
            Me.DateTimePickerDepositInfo_Date.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.ShortDate
            Me.DateTimePickerDepositInfo_Date.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector
            Me.DateTimePickerDepositInfo_Date.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerDepositInfo_Date.DisplayName = ""
            Me.DateTimePickerDepositInfo_Date.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.DateTimePickerDepositInfo_Date.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerDepositInfo_Date.FocusHighlightEnabled = True
            Me.DateTimePickerDepositInfo_Date.FreeTextEntryMode = True
            Me.DateTimePickerDepositInfo_Date.IsPopupCalendarOpen = False
            Me.DateTimePickerDepositInfo_Date.Location = New System.Drawing.Point(60, 24)
            Me.DateTimePickerDepositInfo_Date.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerDepositInfo_Date.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerDepositInfo_Date.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerDepositInfo_Date.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerDepositInfo_Date.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDepositInfo_Date.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerDepositInfo_Date.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerDepositInfo_Date.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerDepositInfo_Date.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerDepositInfo_Date.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerDepositInfo_Date.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerDepositInfo_Date.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerDepositInfo_Date.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerDepositInfo_Date.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDepositInfo_Date.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            Me.DateTimePickerDepositInfo_Date.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerDepositInfo_Date.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerDepositInfo_Date.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerDepositInfo_Date.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerDepositInfo_Date.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerDepositInfo_Date.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDepositInfo_Date.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerDepositInfo_Date.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerDepositInfo_Date.Name = "DateTimePickerDepositInfo_Date"
            Me.DateTimePickerDepositInfo_Date.ReadOnly = False
            Me.DateTimePickerDepositInfo_Date.Size = New System.Drawing.Size(97, 21)
            Me.DateTimePickerDepositInfo_Date.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerDepositInfo_Date.TabIndex = 1
            Me.DateTimePickerDepositInfo_Date.TabOnEnter = True
            Me.DateTimePickerDepositInfo_Date.Value = New Date(2014, 11, 4, 9, 11, 53, 24)
            '
            'GroupBoxPanel_CheckInformation
            '
            Me.GroupBoxPanel_CheckInformation.Controls.Add(Me.LabelCheckInfo_Amount)
            Me.GroupBoxPanel_CheckInformation.Controls.Add(Me.NumericInputCheckInfo_Amount)
            Me.GroupBoxPanel_CheckInformation.Controls.Add(Me.LabelCheckInfo_Date)
            Me.GroupBoxPanel_CheckInformation.Controls.Add(Me.DateTimePickerCheckInfo_Date)
            Me.GroupBoxPanel_CheckInformation.Location = New System.Drawing.Point(5, 60)
            Me.GroupBoxPanel_CheckInformation.Name = "GroupBoxPanel_CheckInformation"
            Me.GroupBoxPanel_CheckInformation.Size = New System.Drawing.Size(309, 79)
            Me.GroupBoxPanel_CheckInformation.TabIndex = 4
            Me.GroupBoxPanel_CheckInformation.Text = "Check Information"
            '
            'LabelCheckInfo_Amount
            '
            Me.LabelCheckInfo_Amount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCheckInfo_Amount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCheckInfo_Amount.Location = New System.Drawing.Point(5, 50)
            Me.LabelCheckInfo_Amount.Name = "LabelCheckInfo_Amount"
            Me.LabelCheckInfo_Amount.Size = New System.Drawing.Size(49, 20)
            Me.LabelCheckInfo_Amount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCheckInfo_Amount.TabIndex = 2
            Me.LabelCheckInfo_Amount.Text = "Amount:"
            '
            'NumericInputCheckInfo_Amount
            '
            Me.NumericInputCheckInfo_Amount.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputCheckInfo_Amount.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputCheckInfo_Amount.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputCheckInfo_Amount.EnterMoveNextControl = True
            Me.NumericInputCheckInfo_Amount.Location = New System.Drawing.Point(60, 50)
            Me.NumericInputCheckInfo_Amount.Name = "NumericInputCheckInfo_Amount"
            Me.NumericInputCheckInfo_Amount.Properties.AllowMouseWheel = False
            Me.NumericInputCheckInfo_Amount.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control
            Me.NumericInputCheckInfo_Amount.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputCheckInfo_Amount.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputCheckInfo_Amount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputCheckInfo_Amount.Properties.EditFormat.FormatString = "f"
            Me.NumericInputCheckInfo_Amount.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputCheckInfo_Amount.Properties.Mask.EditMask = "f"
            Me.NumericInputCheckInfo_Amount.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputCheckInfo_Amount.SecurityEnabled = True
            Me.NumericInputCheckInfo_Amount.Size = New System.Drawing.Size(244, 20)
            Me.NumericInputCheckInfo_Amount.TabIndex = 3
            '
            'LabelCheckInfo_Date
            '
            Me.LabelCheckInfo_Date.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCheckInfo_Date.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCheckInfo_Date.Location = New System.Drawing.Point(5, 24)
            Me.LabelCheckInfo_Date.Name = "LabelCheckInfo_Date"
            Me.LabelCheckInfo_Date.Size = New System.Drawing.Size(49, 20)
            Me.LabelCheckInfo_Date.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCheckInfo_Date.TabIndex = 0
            Me.LabelCheckInfo_Date.Text = "Date:"
            '
            'DateTimePickerCheckInfo_Date
            '
            Me.DateTimePickerCheckInfo_Date.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerCheckInfo_Date.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerCheckInfo_Date.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerCheckInfo_Date.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerCheckInfo_Date.ButtonDropDown.Visible = True
            Me.DateTimePickerCheckInfo_Date.ButtonFreeText.Checked = True
            Me.DateTimePickerCheckInfo_Date.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.ShortDate
            Me.DateTimePickerCheckInfo_Date.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector
            Me.DateTimePickerCheckInfo_Date.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerCheckInfo_Date.DisplayName = ""
            Me.DateTimePickerCheckInfo_Date.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.DateTimePickerCheckInfo_Date.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerCheckInfo_Date.FocusHighlightEnabled = True
            Me.DateTimePickerCheckInfo_Date.FreeTextEntryMode = True
            Me.DateTimePickerCheckInfo_Date.IsPopupCalendarOpen = False
            Me.DateTimePickerCheckInfo_Date.Location = New System.Drawing.Point(60, 24)
            Me.DateTimePickerCheckInfo_Date.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerCheckInfo_Date.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerCheckInfo_Date.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerCheckInfo_Date.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerCheckInfo_Date.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerCheckInfo_Date.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerCheckInfo_Date.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerCheckInfo_Date.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerCheckInfo_Date.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerCheckInfo_Date.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerCheckInfo_Date.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerCheckInfo_Date.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerCheckInfo_Date.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerCheckInfo_Date.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerCheckInfo_Date.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            Me.DateTimePickerCheckInfo_Date.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerCheckInfo_Date.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerCheckInfo_Date.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerCheckInfo_Date.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerCheckInfo_Date.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerCheckInfo_Date.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerCheckInfo_Date.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerCheckInfo_Date.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerCheckInfo_Date.Name = "DateTimePickerCheckInfo_Date"
            Me.DateTimePickerCheckInfo_Date.ReadOnly = False
            Me.DateTimePickerCheckInfo_Date.Size = New System.Drawing.Size(97, 21)
            Me.DateTimePickerCheckInfo_Date.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerCheckInfo_Date.TabIndex = 1
            Me.DateTimePickerCheckInfo_Date.TabOnEnter = True
            Me.DateTimePickerCheckInfo_Date.Value = New Date(2014, 11, 4, 9, 11, 47, 932)
            '
            'LabelPanel_CheckNumber
            '
            Me.LabelPanel_CheckNumber.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPanel_CheckNumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPanel_CheckNumber.Location = New System.Drawing.Point(5, 5)
            Me.LabelPanel_CheckNumber.Name = "LabelPanel_CheckNumber"
            Me.LabelPanel_CheckNumber.Size = New System.Drawing.Size(81, 20)
            Me.LabelPanel_CheckNumber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPanel_CheckNumber.TabIndex = 0
            Me.LabelPanel_CheckNumber.Text = "Check Number:"
            '
            'LabelPanel_PostingPeriod
            '
            Me.LabelPanel_PostingPeriod.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPanel_PostingPeriod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPanel_PostingPeriod.Location = New System.Drawing.Point(320, 5)
            Me.LabelPanel_PostingPeriod.Name = "LabelPanel_PostingPeriod"
            Me.LabelPanel_PostingPeriod.Size = New System.Drawing.Size(81, 20)
            Me.LabelPanel_PostingPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPanel_PostingPeriod.TabIndex = 6
            Me.LabelPanel_PostingPeriod.Text = "Posting Period:"
            '
            'TextBoxPanel_CheckNumber
            '
            Me.TextBoxPanel_CheckNumber.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxPanel_CheckNumber.Border.Class = "TextBoxBorder"
            Me.TextBoxPanel_CheckNumber.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxPanel_CheckNumber.CheckSpellingOnValidate = False
            Me.TextBoxPanel_CheckNumber.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxPanel_CheckNumber.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxPanel_CheckNumber.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxPanel_CheckNumber.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxPanel_CheckNumber.FocusHighlightEnabled = True
            Me.TextBoxPanel_CheckNumber.ForeColor = System.Drawing.Color.Black
            Me.TextBoxPanel_CheckNumber.Location = New System.Drawing.Point(92, 5)
            Me.TextBoxPanel_CheckNumber.MaxFileSize = CType(0, Long)
            Me.TextBoxPanel_CheckNumber.Name = "TextBoxPanel_CheckNumber"
            Me.TextBoxPanel_CheckNumber.ReadOnly = True
            Me.TextBoxPanel_CheckNumber.SecurityEnabled = True
            Me.TextBoxPanel_CheckNumber.ShowSpellCheckCompleteMessage = True
            Me.TextBoxPanel_CheckNumber.Size = New System.Drawing.Size(222, 21)
            Me.TextBoxPanel_CheckNumber.StartingFolderName = Nothing
            Me.TextBoxPanel_CheckNumber.TabIndex = 1
            Me.TextBoxPanel_CheckNumber.TabOnEnter = True
            '
            'LabelPanel_Message
            '
            Me.LabelPanel_Message.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPanel_Message.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPanel_Message.Location = New System.Drawing.Point(320, 229)
            Me.LabelPanel_Message.Name = "LabelPanel_Message"
            Me.LabelPanel_Message.Size = New System.Drawing.Size(55, 20)
            Me.LabelPanel_Message.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPanel_Message.TabIndex = 10
            Me.LabelPanel_Message.Text = "Message:"
            '
            'TextBoxPanel_MessageDetails
            '
            Me.TextBoxPanel_MessageDetails.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxPanel_MessageDetails.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxPanel_MessageDetails.Border.Class = "TextBoxBorder"
            Me.TextBoxPanel_MessageDetails.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxPanel_MessageDetails.CheckSpellingOnValidate = False
            Me.TextBoxPanel_MessageDetails.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxPanel_MessageDetails.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxPanel_MessageDetails.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxPanel_MessageDetails.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxPanel_MessageDetails.FocusHighlightEnabled = True
            Me.TextBoxPanel_MessageDetails.ForeColor = System.Drawing.Color.Black
            Me.TextBoxPanel_MessageDetails.Location = New System.Drawing.Point(381, 229)
            Me.TextBoxPanel_MessageDetails.MaxFileSize = CType(0, Long)
            Me.TextBoxPanel_MessageDetails.Multiline = True
            Me.TextBoxPanel_MessageDetails.Name = "TextBoxPanel_MessageDetails"
            Me.TextBoxPanel_MessageDetails.ReadOnly = True
            Me.TextBoxPanel_MessageDetails.SecurityEnabled = True
            Me.TextBoxPanel_MessageDetails.ShowSpellCheckCompleteMessage = True
            Me.TextBoxPanel_MessageDetails.Size = New System.Drawing.Size(606, 43)
            Me.TextBoxPanel_MessageDetails.StartingFolderName = Nothing
            Me.TextBoxPanel_MessageDetails.TabIndex = 11
            Me.TextBoxPanel_MessageDetails.TabOnEnter = True
            Me.TextBoxPanel_MessageDetails.TabStop = False
            '
            'OtherCashReceiptControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.DataGridViewPanel_OtherReceiptDetails)
            Me.Controls.Add(Me.PanelControl_Header)
            Me.Name = "OtherCashReceiptControl"
            Me.Size = New System.Drawing.Size(992, 615)
            CType(Me.PanelControl_Header, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelControl_Header.ResumeLayout(False)
            CType(Me.SearchableComboBoxPanel_PaymentType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxPanel_Amounts, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxPanel_Amounts.ResumeLayout(False)
            CType(Me.NumericInputDisbursedTo_Balance.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputDisbursedTo_ClientInvoice.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxPanel_GLTransactions, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxPanel_GLTransactions.ResumeLayout(False)
            CType(Me.GroupBoxPanel_DepositInformation, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxPanel_DepositInformation.ResumeLayout(False)
            CType(Me.SearchableComboBoxDepositInfo_GLAccount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewDepositInfo_GLAccount, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxDepositInfo_Office.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewDepositInfo_Office, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxDepositInfo_Bank.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewDepositInfo_Bank, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerDepositInfo_Date, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxPanel_CheckInformation, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxPanel_CheckInformation.ResumeLayout(False)
            CType(Me.NumericInputCheckInfo_Amount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerCheckInfo_Date, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents PanelControl_Header As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents GroupBoxPanel_CheckInformation As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents LabelCheckInfo_Date As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents DateTimePickerCheckInfo_Date As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents LabelPanel_CheckNumber As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelPanel_PostingPeriod As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelCheckInfo_Amount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents NumericInputCheckInfo_Amount As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents GroupBoxPanel_DepositInformation As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents LabelDepositInfo_Account As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxDepositInfo_Bank As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewDepositInfo_Bank As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents LabelDepositInfo_Bank As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelDepositInfo_Date As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents DateTimePickerDepositInfo_Date As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents GroupBoxPanel_Amounts As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents NumericInputDisbursedTo_Balance As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents LabelDisbursedTo_Balance As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents NumericInputDisbursedTo_ClientInvoice As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents LabelAmounts_Disbursed As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxPanel_GLTransactions As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Private WithEvents DataGridViewTransactions_GLTransactions As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents LabelDepositInfo_Office As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelPanel_PostingPeriodForMod As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents DataGridViewPanel_OtherReceiptDetails As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TextBoxPanel_CheckNumber As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents CheckBoxDepositInfo_Cleared As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents SearchableComboBoxDepositInfo_GLAccount As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewDepositInfo_GLAccount As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxDepositInfo_Office As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewDepositInfo_Office As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents TextBoxPanel_Description As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelPanel_Description As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxPanel_PostPeriodForMod As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxPanel_PostPeriod As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelPanel_PaymentType As Label
        Friend WithEvents SearchableComboBoxPanel_PaymentType As SearchableComboBox
        Friend WithEvents GridView1 As GridView
        Friend WithEvents LabelPanel_Message As Label
        Friend WithEvents TextBoxPanel_MessageDetails As TextBox
    End Class

End Namespace
