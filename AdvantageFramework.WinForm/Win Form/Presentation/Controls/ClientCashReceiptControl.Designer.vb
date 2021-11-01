Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ClientCashReceiptControl
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ClientCashReceiptControl))
            Me.DataGridViewPanel_ClientInvoices = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.PanelControl_Header = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.SearchableComboBoxPanel_PaymentType = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView1 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelPanel_PaymentType = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxPanel_MessageDetails = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelPanel_Message = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabControlControl_InvoiceDetails = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelDistributionTab_Distribution = New DevComponents.DotNetBar.TabControlPanel()
            Me.NumericInputDisbursedTo_Balance = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputDisbursedTo_ClientInvoice = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelDisbursedTo_Balance = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelDisbursedTo_OnAccount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.NumericInputDisbursedTo_OnAccount = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelDisbursedTo_ClientInvoice = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemInvoiceDetails_DistributionTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelTransactionsTab_Transactions = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewTransactions_GLTransactions = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemInvoiceDetails_TransactionsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.ComboBoxPanel_PostPeriodForMod = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ComboBoxPanel_PostPeriod = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.SearchableComboBoxPanel_CheckNumber = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewPanel_CheckNumber = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelPanel_ClientARComment = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxDropDownPanel_ARComment = New DevComponents.DotNetBar.Controls.TextBoxDropDown()
            Me.TextBoxPanel_ClientARComment = New System.Windows.Forms.TextBox()
            Me.LabelPanel_PostingPeriodForMod = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.GroupBoxPanel_OnAccount = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.SearchableComboBoxOnAccount_Office = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewOnAccount_Office = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.TextBoxOnAccount_Comment = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.NumericInputOnAccount_Amount = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelOnAccount_Comment = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelOnAccount_Amount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelOnAccount_GLAccount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxOnAccount_GLAccount = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewOnAccount_GLAccount = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelOnAccount_Campaign = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxOnAccount_Campaign = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewOnAccount_Campaign = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelOnAccount_Office = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelOnAccount_Product = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxOnAccount_Product = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewOnAccount_Product = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelOnAccount_Division = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxOnAccount_Division = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewOnAccount_Division = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
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
            Me.SearchableComboBoxPanel_Client = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewPanel_Client = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelPanel_CheckNumber = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelPanel_Client = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelPanel_PostingPeriod = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxPanel_CheckNumber = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            CType(Me.PanelControl_Header, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelControl_Header.SuspendLayout()
            CType(Me.SearchableComboBoxPanel_PaymentType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.TabControlControl_InvoiceDetails, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlControl_InvoiceDetails.SuspendLayout()
            Me.TabControlPanelDistributionTab_Distribution.SuspendLayout()
            CType(Me.NumericInputDisbursedTo_Balance.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputDisbursedTo_ClientInvoice.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputDisbursedTo_OnAccount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelTransactionsTab_Transactions.SuspendLayout()
            CType(Me.SearchableComboBoxPanel_CheckNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewPanel_CheckNumber, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxPanel_OnAccount, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxPanel_OnAccount.SuspendLayout()
            CType(Me.SearchableComboBoxOnAccount_Office.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewOnAccount_Office, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputOnAccount_Amount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxOnAccount_GLAccount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewOnAccount_GLAccount, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxOnAccount_Campaign.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewOnAccount_Campaign, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxOnAccount_Product.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewOnAccount_Product, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxOnAccount_Division.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewOnAccount_Division, System.ComponentModel.ISupportInitialize).BeginInit()
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
            CType(Me.SearchableComboBoxPanel_Client.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewPanel_Client, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'DataGridViewPanel_ClientInvoices
            '
            Me.DataGridViewPanel_ClientInvoices.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewPanel_ClientInvoices.AllowDragAndDrop = False
            Me.DataGridViewPanel_ClientInvoices.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewPanel_ClientInvoices.AllowSelectGroupHeaderRow = True
            Me.DataGridViewPanel_ClientInvoices.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewPanel_ClientInvoices.AutoFilterLookupColumns = True
            Me.DataGridViewPanel_ClientInvoices.AutoloadRepositoryDatasource = True
            Me.DataGridViewPanel_ClientInvoices.AutoUpdateViewCaption = True
            Me.DataGridViewPanel_ClientInvoices.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewPanel_ClientInvoices.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewPanel_ClientInvoices.Dock = System.Windows.Forms.DockStyle.Fill
            Me.DataGridViewPanel_ClientInvoices.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewPanel_ClientInvoices.ItemDescription = "Client Invoice(s)"
            Me.DataGridViewPanel_ClientInvoices.Location = New System.Drawing.Point(0, 306)
            Me.DataGridViewPanel_ClientInvoices.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewPanel_ClientInvoices.MultiSelect = True
            Me.DataGridViewPanel_ClientInvoices.Name = "DataGridViewPanel_ClientInvoices"
            Me.DataGridViewPanel_ClientInvoices.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewPanel_ClientInvoices.RunStandardValidation = True
            Me.DataGridViewPanel_ClientInvoices.ShowColumnMenuOnRightClick = False
            Me.DataGridViewPanel_ClientInvoices.ShowSelectDeselectAllButtons = False
            Me.DataGridViewPanel_ClientInvoices.Size = New System.Drawing.Size(992, 309)
            Me.DataGridViewPanel_ClientInvoices.TabIndex = 1
            Me.DataGridViewPanel_ClientInvoices.UseEmbeddedNavigator = False
            Me.DataGridViewPanel_ClientInvoices.ViewCaptionHeight = -1
            '
            'PanelControl_Header
            '
            Me.PanelControl_Header.Controls.Add(Me.SearchableComboBoxPanel_PaymentType)
            Me.PanelControl_Header.Controls.Add(Me.LabelPanel_PaymentType)
            Me.PanelControl_Header.Controls.Add(Me.TextBoxPanel_MessageDetails)
            Me.PanelControl_Header.Controls.Add(Me.LabelPanel_Message)
            Me.PanelControl_Header.Controls.Add(Me.TabControlControl_InvoiceDetails)
            Me.PanelControl_Header.Controls.Add(Me.ComboBoxPanel_PostPeriodForMod)
            Me.PanelControl_Header.Controls.Add(Me.ComboBoxPanel_PostPeriod)
            Me.PanelControl_Header.Controls.Add(Me.SearchableComboBoxPanel_CheckNumber)
            Me.PanelControl_Header.Controls.Add(Me.LabelPanel_ClientARComment)
            Me.PanelControl_Header.Controls.Add(Me.TextBoxDropDownPanel_ARComment)
            Me.PanelControl_Header.Controls.Add(Me.LabelPanel_PostingPeriodForMod)
            Me.PanelControl_Header.Controls.Add(Me.GroupBoxPanel_OnAccount)
            Me.PanelControl_Header.Controls.Add(Me.GroupBoxPanel_DepositInformation)
            Me.PanelControl_Header.Controls.Add(Me.GroupBoxPanel_CheckInformation)
            Me.PanelControl_Header.Controls.Add(Me.SearchableComboBoxPanel_Client)
            Me.PanelControl_Header.Controls.Add(Me.LabelPanel_CheckNumber)
            Me.PanelControl_Header.Controls.Add(Me.LabelPanel_Client)
            Me.PanelControl_Header.Controls.Add(Me.LabelPanel_PostingPeriod)
            Me.PanelControl_Header.Controls.Add(Me.TextBoxPanel_ClientARComment)
            Me.PanelControl_Header.Controls.Add(Me.TextBoxPanel_CheckNumber)
            Me.PanelControl_Header.Dock = System.Windows.Forms.DockStyle.Top
            Me.PanelControl_Header.Location = New System.Drawing.Point(0, 0)
            Me.PanelControl_Header.Name = "PanelControl_Header"
            Me.PanelControl_Header.Size = New System.Drawing.Size(992, 306)
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
            Me.SearchableComboBoxPanel_PaymentType.Location = New System.Drawing.Point(412, 59)
            Me.SearchableComboBoxPanel_PaymentType.Name = "SearchableComboBoxPanel_PaymentType"
            Me.SearchableComboBoxPanel_PaymentType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxPanel_PaymentType.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxPanel_PaymentType.Properties.NullText = "Select Payment Type"
            Me.SearchableComboBoxPanel_PaymentType.Properties.ShowClearButton = False
            Me.SearchableComboBoxPanel_PaymentType.Properties.ValueMember = "ID"
            Me.SearchableComboBoxPanel_PaymentType.Properties.View = Me.GridView1
            Me.SearchableComboBoxPanel_PaymentType.SecurityEnabled = True
            Me.SearchableComboBoxPanel_PaymentType.SelectedValue = Nothing
            Me.SearchableComboBoxPanel_PaymentType.Size = New System.Drawing.Size(148, 20)
            Me.SearchableComboBoxPanel_PaymentType.TabIndex = 14
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
            Me.LabelPanel_PaymentType.Location = New System.Drawing.Point(319, 57)
            Me.LabelPanel_PaymentType.Name = "LabelPanel_PaymentType"
            Me.LabelPanel_PaymentType.Size = New System.Drawing.Size(82, 20)
            Me.LabelPanel_PaymentType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPanel_PaymentType.TabIndex = 13
            Me.LabelPanel_PaymentType.Text = "Payment Type:"
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
            Me.TextBoxPanel_MessageDetails.Location = New System.Drawing.Point(718, 206)
            Me.TextBoxPanel_MessageDetails.MaxFileSize = CType(0, Long)
            Me.TextBoxPanel_MessageDetails.Multiline = True
            Me.TextBoxPanel_MessageDetails.Name = "TextBoxPanel_MessageDetails"
            Me.TextBoxPanel_MessageDetails.ReadOnly = True
            Me.TextBoxPanel_MessageDetails.SecurityEnabled = True
            Me.TextBoxPanel_MessageDetails.ShowSpellCheckCompleteMessage = True
            Me.TextBoxPanel_MessageDetails.Size = New System.Drawing.Size(269, 96)
            Me.TextBoxPanel_MessageDetails.StartingFolderName = Nothing
            Me.TextBoxPanel_MessageDetails.TabIndex = 49
            Me.TextBoxPanel_MessageDetails.TabOnEnter = True
            Me.TextBoxPanel_MessageDetails.TabStop = False
            '
            'LabelPanel_Message
            '
            Me.LabelPanel_Message.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPanel_Message.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPanel_Message.Location = New System.Drawing.Point(657, 206)
            Me.LabelPanel_Message.Name = "LabelPanel_Message"
            Me.LabelPanel_Message.Size = New System.Drawing.Size(55, 20)
            Me.LabelPanel_Message.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPanel_Message.TabIndex = 48
            Me.LabelPanel_Message.Text = "Message:"
            '
            'TabControlControl_InvoiceDetails
            '
            Me.TabControlControl_InvoiceDetails.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlControl_InvoiceDetails.BackColor = System.Drawing.Color.White
            Me.TabControlControl_InvoiceDetails.CanReorderTabs = False
            Me.TabControlControl_InvoiceDetails.Controls.Add(Me.TabControlPanelDistributionTab_Distribution)
            Me.TabControlControl_InvoiceDetails.Controls.Add(Me.TabControlPanelTransactionsTab_Transactions)
            Me.TabControlControl_InvoiceDetails.ForeColor = System.Drawing.Color.Black
            Me.TabControlControl_InvoiceDetails.Location = New System.Drawing.Point(657, 3)
            Me.TabControlControl_InvoiceDetails.Name = "TabControlControl_InvoiceDetails"
            Me.TabControlControl_InvoiceDetails.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlControl_InvoiceDetails.SelectedTabIndex = 2
            Me.TabControlControl_InvoiceDetails.Size = New System.Drawing.Size(330, 197)
            Me.TabControlControl_InvoiceDetails.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlControl_InvoiceDetails.TabIndex = 47
            Me.TabControlControl_InvoiceDetails.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlControl_InvoiceDetails.Tabs.Add(Me.TabItemInvoiceDetails_DistributionTab)
            Me.TabControlControl_InvoiceDetails.Tabs.Add(Me.TabItemInvoiceDetails_TransactionsTab)
            Me.TabControlControl_InvoiceDetails.TabStop = False
            '
            'TabControlPanelDistributionTab_Distribution
            '
            Me.TabControlPanelDistributionTab_Distribution.Controls.Add(Me.NumericInputDisbursedTo_Balance)
            Me.TabControlPanelDistributionTab_Distribution.Controls.Add(Me.NumericInputDisbursedTo_ClientInvoice)
            Me.TabControlPanelDistributionTab_Distribution.Controls.Add(Me.LabelDisbursedTo_Balance)
            Me.TabControlPanelDistributionTab_Distribution.Controls.Add(Me.LabelDisbursedTo_OnAccount)
            Me.TabControlPanelDistributionTab_Distribution.Controls.Add(Me.NumericInputDisbursedTo_OnAccount)
            Me.TabControlPanelDistributionTab_Distribution.Controls.Add(Me.LabelDisbursedTo_ClientInvoice)
            Me.TabControlPanelDistributionTab_Distribution.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelDistributionTab_Distribution.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelDistributionTab_Distribution.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelDistributionTab_Distribution.Name = "TabControlPanelDistributionTab_Distribution"
            Me.TabControlPanelDistributionTab_Distribution.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelDistributionTab_Distribution.Size = New System.Drawing.Size(330, 170)
            Me.TabControlPanelDistributionTab_Distribution.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDistributionTab_Distribution.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDistributionTab_Distribution.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelDistributionTab_Distribution.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelDistributionTab_Distribution.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelDistributionTab_Distribution.Style.GradientAngle = 90
            Me.TabControlPanelDistributionTab_Distribution.TabIndex = 0
            Me.TabControlPanelDistributionTab_Distribution.TabItem = Me.TabItemInvoiceDetails_DistributionTab
            '
            'NumericInputDisbursedTo_Balance
            '
            Me.NumericInputDisbursedTo_Balance.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputDisbursedTo_Balance.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputDisbursedTo_Balance.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputDisbursedTo_Balance.EnterMoveNextControl = True
            Me.NumericInputDisbursedTo_Balance.Location = New System.Drawing.Point(88, 56)
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
            Me.NumericInputDisbursedTo_Balance.Size = New System.Drawing.Size(115, 20)
            Me.NumericInputDisbursedTo_Balance.TabIndex = 5
            Me.NumericInputDisbursedTo_Balance.TabStop = False
            '
            'NumericInputDisbursedTo_ClientInvoice
            '
            Me.NumericInputDisbursedTo_ClientInvoice.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputDisbursedTo_ClientInvoice.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputDisbursedTo_ClientInvoice.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputDisbursedTo_ClientInvoice.EnterMoveNextControl = True
            Me.NumericInputDisbursedTo_ClientInvoice.Location = New System.Drawing.Point(88, 4)
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
            Me.NumericInputDisbursedTo_ClientInvoice.Size = New System.Drawing.Size(115, 20)
            Me.NumericInputDisbursedTo_ClientInvoice.TabIndex = 1
            Me.NumericInputDisbursedTo_ClientInvoice.TabStop = False
            '
            'LabelDisbursedTo_Balance
            '
            Me.LabelDisbursedTo_Balance.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDisbursedTo_Balance.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDisbursedTo_Balance.Location = New System.Drawing.Point(4, 56)
            Me.LabelDisbursedTo_Balance.Name = "LabelDisbursedTo_Balance"
            Me.LabelDisbursedTo_Balance.Size = New System.Drawing.Size(78, 20)
            Me.LabelDisbursedTo_Balance.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDisbursedTo_Balance.TabIndex = 4
            Me.LabelDisbursedTo_Balance.Text = "Balance:"
            '
            'LabelDisbursedTo_OnAccount
            '
            Me.LabelDisbursedTo_OnAccount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDisbursedTo_OnAccount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDisbursedTo_OnAccount.Location = New System.Drawing.Point(4, 30)
            Me.LabelDisbursedTo_OnAccount.Name = "LabelDisbursedTo_OnAccount"
            Me.LabelDisbursedTo_OnAccount.Size = New System.Drawing.Size(78, 20)
            Me.LabelDisbursedTo_OnAccount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDisbursedTo_OnAccount.TabIndex = 2
            Me.LabelDisbursedTo_OnAccount.Text = "On Account:"
            '
            'NumericInputDisbursedTo_OnAccount
            '
            Me.NumericInputDisbursedTo_OnAccount.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputDisbursedTo_OnAccount.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputDisbursedTo_OnAccount.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputDisbursedTo_OnAccount.EnterMoveNextControl = True
            Me.NumericInputDisbursedTo_OnAccount.Location = New System.Drawing.Point(88, 30)
            Me.NumericInputDisbursedTo_OnAccount.Name = "NumericInputDisbursedTo_OnAccount"
            Me.NumericInputDisbursedTo_OnAccount.Properties.AllowMouseWheel = False
            Me.NumericInputDisbursedTo_OnAccount.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control
            Me.NumericInputDisbursedTo_OnAccount.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputDisbursedTo_OnAccount.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputDisbursedTo_OnAccount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDisbursedTo_OnAccount.Properties.EditFormat.FormatString = "f"
            Me.NumericInputDisbursedTo_OnAccount.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDisbursedTo_OnAccount.Properties.Mask.EditMask = "f"
            Me.NumericInputDisbursedTo_OnAccount.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputDisbursedTo_OnAccount.Properties.ReadOnly = True
            Me.NumericInputDisbursedTo_OnAccount.SecurityEnabled = True
            Me.NumericInputDisbursedTo_OnAccount.Size = New System.Drawing.Size(115, 20)
            Me.NumericInputDisbursedTo_OnAccount.TabIndex = 3
            Me.NumericInputDisbursedTo_OnAccount.TabStop = False
            '
            'LabelDisbursedTo_ClientInvoice
            '
            Me.LabelDisbursedTo_ClientInvoice.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDisbursedTo_ClientInvoice.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDisbursedTo_ClientInvoice.Location = New System.Drawing.Point(4, 4)
            Me.LabelDisbursedTo_ClientInvoice.Name = "LabelDisbursedTo_ClientInvoice"
            Me.LabelDisbursedTo_ClientInvoice.Size = New System.Drawing.Size(78, 20)
            Me.LabelDisbursedTo_ClientInvoice.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDisbursedTo_ClientInvoice.TabIndex = 0
            Me.LabelDisbursedTo_ClientInvoice.Text = "Client Invoice:"
            '
            'TabItemInvoiceDetails_DistributionTab
            '
            Me.TabItemInvoiceDetails_DistributionTab.AttachedControl = Me.TabControlPanelDistributionTab_Distribution
            Me.TabItemInvoiceDetails_DistributionTab.Name = "TabItemInvoiceDetails_DistributionTab"
            Me.TabItemInvoiceDetails_DistributionTab.Text = "Distribution"
            '
            'TabControlPanelTransactionsTab_Transactions
            '
            Me.TabControlPanelTransactionsTab_Transactions.Controls.Add(Me.DataGridViewTransactions_GLTransactions)
            Me.TabControlPanelTransactionsTab_Transactions.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelTransactionsTab_Transactions.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelTransactionsTab_Transactions.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelTransactionsTab_Transactions.Name = "TabControlPanelTransactionsTab_Transactions"
            Me.TabControlPanelTransactionsTab_Transactions.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelTransactionsTab_Transactions.Size = New System.Drawing.Size(330, 170)
            Me.TabControlPanelTransactionsTab_Transactions.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelTransactionsTab_Transactions.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelTransactionsTab_Transactions.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelTransactionsTab_Transactions.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelTransactionsTab_Transactions.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelTransactionsTab_Transactions.Style.GradientAngle = 90
            Me.TabControlPanelTransactionsTab_Transactions.TabIndex = 2
            Me.TabControlPanelTransactionsTab_Transactions.TabItem = Me.TabItemInvoiceDetails_TransactionsTab
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
            Me.DataGridViewTransactions_GLTransactions.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewTransactions_GLTransactions.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewTransactions_GLTransactions.ItemDescription = "GL Transaction(s)"
            Me.DataGridViewTransactions_GLTransactions.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewTransactions_GLTransactions.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewTransactions_GLTransactions.MultiSelect = False
            Me.DataGridViewTransactions_GLTransactions.Name = "DataGridViewTransactions_GLTransactions"
            Me.DataGridViewTransactions_GLTransactions.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewTransactions_GLTransactions.RunStandardValidation = True
            Me.DataGridViewTransactions_GLTransactions.ShowColumnMenuOnRightClick = False
            Me.DataGridViewTransactions_GLTransactions.ShowSelectDeselectAllButtons = False
            Me.DataGridViewTransactions_GLTransactions.Size = New System.Drawing.Size(322, 162)
            Me.DataGridViewTransactions_GLTransactions.TabIndex = 13
            Me.DataGridViewTransactions_GLTransactions.TabStop = False
            Me.DataGridViewTransactions_GLTransactions.UseEmbeddedNavigator = False
            Me.DataGridViewTransactions_GLTransactions.ViewCaptionHeight = -1
            '
            'TabItemInvoiceDetails_TransactionsTab
            '
            Me.TabItemInvoiceDetails_TransactionsTab.AttachedControl = Me.TabControlPanelTransactionsTab_Transactions
            Me.TabItemInvoiceDetails_TransactionsTab.Name = "TabItemInvoiceDetails_TransactionsTab"
            Me.TabItemInvoiceDetails_TransactionsTab.Text = "Transactions"
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
            Me.ComboBoxPanel_PostPeriodForMod.Location = New System.Drawing.Point(412, 32)
            Me.ComboBoxPanel_PostPeriodForMod.Name = "ComboBoxPanel_PostPeriodForMod"
            Me.ComboBoxPanel_PostPeriodForMod.ReadOnly = False
            Me.ComboBoxPanel_PostPeriodForMod.SecurityEnabled = True
            Me.ComboBoxPanel_PostPeriodForMod.Size = New System.Drawing.Size(148, 21)
            Me.ComboBoxPanel_PostPeriodForMod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxPanel_PostPeriodForMod.TabIndex = 12
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
            Me.ComboBoxPanel_PostPeriod.Location = New System.Drawing.Point(412, 5)
            Me.ComboBoxPanel_PostPeriod.Name = "ComboBoxPanel_PostPeriod"
            Me.ComboBoxPanel_PostPeriod.ReadOnly = False
            Me.ComboBoxPanel_PostPeriod.SecurityEnabled = True
            Me.ComboBoxPanel_PostPeriod.Size = New System.Drawing.Size(148, 21)
            Me.ComboBoxPanel_PostPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxPanel_PostPeriod.TabIndex = 10
            Me.ComboBoxPanel_PostPeriod.TabOnEnter = True
            Me.ComboBoxPanel_PostPeriod.ValueMember = "Code"
            Me.ComboBoxPanel_PostPeriod.WatermarkText = "Select Post Period"
            '
            'SearchableComboBoxPanel_CheckNumber
            '
            Me.SearchableComboBoxPanel_CheckNumber.ActiveFilterString = ""
            Me.SearchableComboBoxPanel_CheckNumber.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxPanel_CheckNumber.AutoFillMode = False
            Me.SearchableComboBoxPanel_CheckNumber.BookmarkingEnabled = False
            Me.SearchableComboBoxPanel_CheckNumber.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.CheckNumber
            Me.SearchableComboBoxPanel_CheckNumber.DataSource = Nothing
            Me.SearchableComboBoxPanel_CheckNumber.DisableMouseWheel = True
            Me.SearchableComboBoxPanel_CheckNumber.DisplayName = ""
            Me.SearchableComboBoxPanel_CheckNumber.Enabled = False
            Me.SearchableComboBoxPanel_CheckNumber.EnterMoveNextControl = True
            Me.SearchableComboBoxPanel_CheckNumber.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxPanel_CheckNumber.Location = New System.Drawing.Point(92, 31)
            Me.SearchableComboBoxPanel_CheckNumber.Name = "SearchableComboBoxPanel_CheckNumber"
            Me.SearchableComboBoxPanel_CheckNumber.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxPanel_CheckNumber.Properties.DisplayMember = "CheckNumber"
            Me.SearchableComboBoxPanel_CheckNumber.Properties.NullText = "Select Check Number"
            Me.SearchableComboBoxPanel_CheckNumber.Properties.ShowClearButton = False
            Me.SearchableComboBoxPanel_CheckNumber.Properties.ValueMember = "CheckNumber"
            Me.SearchableComboBoxPanel_CheckNumber.Properties.View = Me.SearchableComboBoxViewPanel_CheckNumber
            Me.SearchableComboBoxPanel_CheckNumber.SecurityEnabled = True
            Me.SearchableComboBoxPanel_CheckNumber.SelectedValue = Nothing
            Me.SearchableComboBoxPanel_CheckNumber.Size = New System.Drawing.Size(222, 20)
            Me.SearchableComboBoxPanel_CheckNumber.TabIndex = 3
            '
            'SearchableComboBoxViewPanel_CheckNumber
            '
            Me.SearchableComboBoxViewPanel_CheckNumber.AFActiveFilterString = ""
            Me.SearchableComboBoxViewPanel_CheckNumber.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewPanel_CheckNumber.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_CheckNumber.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_CheckNumber.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_CheckNumber.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_CheckNumber.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_CheckNumber.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_CheckNumber.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_CheckNumber.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_CheckNumber.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_CheckNumber.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_CheckNumber.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_CheckNumber.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_CheckNumber.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_CheckNumber.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_CheckNumber.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_CheckNumber.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_CheckNumber.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_CheckNumber.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_CheckNumber.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_CheckNumber.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_CheckNumber.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_CheckNumber.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_CheckNumber.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_CheckNumber.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_CheckNumber.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_CheckNumber.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_CheckNumber.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_CheckNumber.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_CheckNumber.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_CheckNumber.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_CheckNumber.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_CheckNumber.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_CheckNumber.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_CheckNumber.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_CheckNumber.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_CheckNumber.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_CheckNumber.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_CheckNumber.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewPanel_CheckNumber.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewPanel_CheckNumber.DataSourceClearing = False
            Me.SearchableComboBoxViewPanel_CheckNumber.EnableDisabledRows = False
            Me.SearchableComboBoxViewPanel_CheckNumber.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewPanel_CheckNumber.Name = "SearchableComboBoxViewPanel_CheckNumber"
            Me.SearchableComboBoxViewPanel_CheckNumber.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewPanel_CheckNumber.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewPanel_CheckNumber.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewPanel_CheckNumber.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewPanel_CheckNumber.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewPanel_CheckNumber.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewPanel_CheckNumber.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewPanel_CheckNumber.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewPanel_CheckNumber.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewPanel_CheckNumber.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewPanel_CheckNumber.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewPanel_CheckNumber.RunStandardValidation = True
            '
            'LabelPanel_ClientARComment
            '
            Me.LabelPanel_ClientARComment.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPanel_ClientARComment.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPanel_ClientARComment.Location = New System.Drawing.Point(5, 57)
            Me.LabelPanel_ClientARComment.Name = "LabelPanel_ClientARComment"
            Me.LabelPanel_ClientARComment.Size = New System.Drawing.Size(81, 20)
            Me.LabelPanel_ClientARComment.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPanel_ClientARComment.TabIndex = 4
            Me.LabelPanel_ClientARComment.Text = "A/R Comment:"
            '
            'TextBoxDropDownPanel_ARComment
            '
            '
            '
            '
            Me.TextBoxDropDownPanel_ARComment.BackgroundStyle.Class = "TextBoxBorder"
            Me.TextBoxDropDownPanel_ARComment.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxDropDownPanel_ARComment.ButtonDropDown.Visible = True
            Me.TextBoxDropDownPanel_ARComment.DropDownControl = Me.TextBoxPanel_ClientARComment
            Me.TextBoxDropDownPanel_ARComment.Location = New System.Drawing.Point(92, 57)
            Me.TextBoxDropDownPanel_ARComment.Name = "TextBoxDropDownPanel_ARComment"
            Me.TextBoxDropDownPanel_ARComment.ReadOnly = True
            Me.TextBoxDropDownPanel_ARComment.Size = New System.Drawing.Size(221, 20)
            Me.TextBoxDropDownPanel_ARComment.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.TextBoxDropDownPanel_ARComment.TabIndex = 5
            Me.TextBoxDropDownPanel_ARComment.TabStop = False
            Me.TextBoxDropDownPanel_ARComment.Text = ""
            '
            'TextBoxPanel_ClientARComment
            '
            Me.TextBoxPanel_ClientARComment.Location = New System.Drawing.Point(92, 54)
            Me.TextBoxPanel_ClientARComment.Multiline = True
            Me.TextBoxPanel_ClientARComment.Name = "TextBoxPanel_ClientARComment"
            Me.TextBoxPanel_ClientARComment.ReadOnly = True
            Me.TextBoxPanel_ClientARComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.TextBoxPanel_ClientARComment.Size = New System.Drawing.Size(222, 98)
            Me.TextBoxPanel_ClientARComment.TabIndex = 6
            Me.TextBoxPanel_ClientARComment.TabStop = False
            Me.TextBoxPanel_ClientARComment.Visible = False
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
            Me.LabelPanel_PostingPeriodForMod.TabIndex = 11
            Me.LabelPanel_PostingPeriodForMod.Text = "P/P for Mod:"
            '
            'GroupBoxPanel_OnAccount
            '
            Me.GroupBoxPanel_OnAccount.Controls.Add(Me.SearchableComboBoxOnAccount_Office)
            Me.GroupBoxPanel_OnAccount.Controls.Add(Me.TextBoxOnAccount_Comment)
            Me.GroupBoxPanel_OnAccount.Controls.Add(Me.NumericInputOnAccount_Amount)
            Me.GroupBoxPanel_OnAccount.Controls.Add(Me.LabelOnAccount_Comment)
            Me.GroupBoxPanel_OnAccount.Controls.Add(Me.LabelOnAccount_Amount)
            Me.GroupBoxPanel_OnAccount.Controls.Add(Me.LabelOnAccount_GLAccount)
            Me.GroupBoxPanel_OnAccount.Controls.Add(Me.SearchableComboBoxOnAccount_GLAccount)
            Me.GroupBoxPanel_OnAccount.Controls.Add(Me.LabelOnAccount_Campaign)
            Me.GroupBoxPanel_OnAccount.Controls.Add(Me.SearchableComboBoxOnAccount_Campaign)
            Me.GroupBoxPanel_OnAccount.Controls.Add(Me.LabelOnAccount_Office)
            Me.GroupBoxPanel_OnAccount.Controls.Add(Me.LabelOnAccount_Product)
            Me.GroupBoxPanel_OnAccount.Controls.Add(Me.SearchableComboBoxOnAccount_Product)
            Me.GroupBoxPanel_OnAccount.Controls.Add(Me.LabelOnAccount_Division)
            Me.GroupBoxPanel_OnAccount.Controls.Add(Me.SearchableComboBoxOnAccount_Division)
            Me.GroupBoxPanel_OnAccount.Location = New System.Drawing.Point(320, 82)
            Me.GroupBoxPanel_OnAccount.Name = "GroupBoxPanel_OnAccount"
            Me.GroupBoxPanel_OnAccount.Size = New System.Drawing.Size(331, 220)
            Me.GroupBoxPanel_OnAccount.TabIndex = 15
            Me.GroupBoxPanel_OnAccount.Text = "On Account"
            '
            'SearchableComboBoxOnAccount_Office
            '
            Me.SearchableComboBoxOnAccount_Office.ActiveFilterString = ""
            Me.SearchableComboBoxOnAccount_Office.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxOnAccount_Office.AutoFillMode = False
            Me.SearchableComboBoxOnAccount_Office.BookmarkingEnabled = False
            Me.SearchableComboBoxOnAccount_Office.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Office
            Me.SearchableComboBoxOnAccount_Office.DataSource = Nothing
            Me.SearchableComboBoxOnAccount_Office.DisableMouseWheel = True
            Me.SearchableComboBoxOnAccount_Office.DisplayName = ""
            Me.SearchableComboBoxOnAccount_Office.EnterMoveNextControl = True
            Me.SearchableComboBoxOnAccount_Office.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.None
            Me.SearchableComboBoxOnAccount_Office.Location = New System.Drawing.Point(92, 76)
            Me.SearchableComboBoxOnAccount_Office.Name = "SearchableComboBoxOnAccount_Office"
            Me.SearchableComboBoxOnAccount_Office.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxOnAccount_Office.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxOnAccount_Office.Properties.NullText = "Select Office"
            Me.SearchableComboBoxOnAccount_Office.Properties.ReadOnly = True
            Me.SearchableComboBoxOnAccount_Office.Properties.ShowClearButton = False
            Me.SearchableComboBoxOnAccount_Office.Properties.ValueMember = "Code"
            Me.SearchableComboBoxOnAccount_Office.Properties.View = Me.SearchableComboBoxViewOnAccount_Office
            Me.SearchableComboBoxOnAccount_Office.SecurityEnabled = True
            Me.SearchableComboBoxOnAccount_Office.SelectedValue = Nothing
            Me.SearchableComboBoxOnAccount_Office.Size = New System.Drawing.Size(234, 20)
            Me.SearchableComboBoxOnAccount_Office.TabIndex = 5
            Me.SearchableComboBoxOnAccount_Office.TabStop = False
            '
            'SearchableComboBoxViewOnAccount_Office
            '
            Me.SearchableComboBoxViewOnAccount_Office.AFActiveFilterString = ""
            Me.SearchableComboBoxViewOnAccount_Office.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewOnAccount_Office.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Office.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Office.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Office.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Office.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Office.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Office.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Office.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Office.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Office.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Office.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Office.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Office.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Office.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Office.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Office.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Office.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Office.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Office.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Office.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Office.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Office.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Office.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Office.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Office.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Office.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Office.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Office.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Office.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Office.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Office.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Office.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Office.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Office.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Office.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Office.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Office.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Office.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewOnAccount_Office.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewOnAccount_Office.DataSourceClearing = False
            Me.SearchableComboBoxViewOnAccount_Office.EnableDisabledRows = False
            Me.SearchableComboBoxViewOnAccount_Office.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewOnAccount_Office.Name = "SearchableComboBoxViewOnAccount_Office"
            Me.SearchableComboBoxViewOnAccount_Office.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewOnAccount_Office.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewOnAccount_Office.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewOnAccount_Office.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewOnAccount_Office.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewOnAccount_Office.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewOnAccount_Office.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewOnAccount_Office.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewOnAccount_Office.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewOnAccount_Office.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewOnAccount_Office.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewOnAccount_Office.RunStandardValidation = True
            '
            'TextBoxOnAccount_Comment
            '
            '
            '
            '
            Me.TextBoxOnAccount_Comment.Border.Class = "TextBoxBorder"
            Me.TextBoxOnAccount_Comment.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxOnAccount_Comment.CheckSpellingOnValidate = False
            Me.TextBoxOnAccount_Comment.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxOnAccount_Comment.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxOnAccount_Comment.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxOnAccount_Comment.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxOnAccount_Comment.FocusHighlightEnabled = True
            Me.TextBoxOnAccount_Comment.Location = New System.Drawing.Point(92, 180)
            Me.TextBoxOnAccount_Comment.MaxFileSize = CType(0, Long)
            Me.TextBoxOnAccount_Comment.Multiline = True
            Me.TextBoxOnAccount_Comment.Name = "TextBoxOnAccount_Comment"
            Me.TextBoxOnAccount_Comment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.TextBoxOnAccount_Comment.SecurityEnabled = True
            Me.TextBoxOnAccount_Comment.ShowSpellCheckCompleteMessage = True
            Me.TextBoxOnAccount_Comment.Size = New System.Drawing.Size(234, 33)
            Me.TextBoxOnAccount_Comment.StartingFolderName = Nothing
            Me.TextBoxOnAccount_Comment.TabIndex = 13
            Me.TextBoxOnAccount_Comment.TabOnEnter = True
            '
            'NumericInputOnAccount_Amount
            '
            Me.NumericInputOnAccount_Amount.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputOnAccount_Amount.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputOnAccount_Amount.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputOnAccount_Amount.EnterMoveNextControl = True
            Me.NumericInputOnAccount_Amount.Location = New System.Drawing.Point(92, 154)
            Me.NumericInputOnAccount_Amount.Name = "NumericInputOnAccount_Amount"
            Me.NumericInputOnAccount_Amount.Properties.AllowMouseWheel = False
            Me.NumericInputOnAccount_Amount.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control
            Me.NumericInputOnAccount_Amount.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputOnAccount_Amount.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputOnAccount_Amount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputOnAccount_Amount.Properties.EditFormat.FormatString = "f"
            Me.NumericInputOnAccount_Amount.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputOnAccount_Amount.Properties.Mask.EditMask = "f"
            Me.NumericInputOnAccount_Amount.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputOnAccount_Amount.SecurityEnabled = True
            Me.NumericInputOnAccount_Amount.Size = New System.Drawing.Size(234, 20)
            Me.NumericInputOnAccount_Amount.TabIndex = 11
            '
            'LabelOnAccount_Comment
            '
            Me.LabelOnAccount_Comment.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelOnAccount_Comment.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelOnAccount_Comment.Location = New System.Drawing.Point(5, 180)
            Me.LabelOnAccount_Comment.Name = "LabelOnAccount_Comment"
            Me.LabelOnAccount_Comment.Size = New System.Drawing.Size(81, 20)
            Me.LabelOnAccount_Comment.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelOnAccount_Comment.TabIndex = 12
            Me.LabelOnAccount_Comment.Text = "Comment:"
            '
            'LabelOnAccount_Amount
            '
            Me.LabelOnAccount_Amount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelOnAccount_Amount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelOnAccount_Amount.Location = New System.Drawing.Point(5, 154)
            Me.LabelOnAccount_Amount.Name = "LabelOnAccount_Amount"
            Me.LabelOnAccount_Amount.Size = New System.Drawing.Size(81, 20)
            Me.LabelOnAccount_Amount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelOnAccount_Amount.TabIndex = 10
            Me.LabelOnAccount_Amount.Text = "Amount:"
            '
            'LabelOnAccount_GLAccount
            '
            Me.LabelOnAccount_GLAccount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelOnAccount_GLAccount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelOnAccount_GLAccount.Location = New System.Drawing.Point(5, 128)
            Me.LabelOnAccount_GLAccount.Name = "LabelOnAccount_GLAccount"
            Me.LabelOnAccount_GLAccount.Size = New System.Drawing.Size(81, 20)
            Me.LabelOnAccount_GLAccount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelOnAccount_GLAccount.TabIndex = 8
            Me.LabelOnAccount_GLAccount.Text = "GL Account:"
            '
            'SearchableComboBoxOnAccount_GLAccount
            '
            Me.SearchableComboBoxOnAccount_GLAccount.ActiveFilterString = ""
            Me.SearchableComboBoxOnAccount_GLAccount.AddInactiveItemsOnSelectedValue = True
            Me.SearchableComboBoxOnAccount_GLAccount.AutoFillMode = False
            Me.SearchableComboBoxOnAccount_GLAccount.BookmarkingEnabled = False
            Me.SearchableComboBoxOnAccount_GLAccount.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.GeneralLedgerAccount
            Me.SearchableComboBoxOnAccount_GLAccount.DataSource = Nothing
            Me.SearchableComboBoxOnAccount_GLAccount.DisableMouseWheel = True
            Me.SearchableComboBoxOnAccount_GLAccount.DisplayName = ""
            Me.SearchableComboBoxOnAccount_GLAccount.EnterMoveNextControl = True
            Me.SearchableComboBoxOnAccount_GLAccount.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.None
            Me.SearchableComboBoxOnAccount_GLAccount.Location = New System.Drawing.Point(92, 128)
            Me.SearchableComboBoxOnAccount_GLAccount.Name = "SearchableComboBoxOnAccount_GLAccount"
            Me.SearchableComboBoxOnAccount_GLAccount.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxOnAccount_GLAccount.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxOnAccount_GLAccount.Properties.NullText = "Select General Ledger Account"
            Me.SearchableComboBoxOnAccount_GLAccount.Properties.ShowClearButton = False
            Me.SearchableComboBoxOnAccount_GLAccount.Properties.ValueMember = "Code"
            Me.SearchableComboBoxOnAccount_GLAccount.Properties.View = Me.SearchableComboBoxViewOnAccount_GLAccount
            Me.SearchableComboBoxOnAccount_GLAccount.SecurityEnabled = True
            Me.SearchableComboBoxOnAccount_GLAccount.SelectedValue = Nothing
            Me.SearchableComboBoxOnAccount_GLAccount.Size = New System.Drawing.Size(234, 20)
            Me.SearchableComboBoxOnAccount_GLAccount.TabIndex = 9
            '
            'SearchableComboBoxViewOnAccount_GLAccount
            '
            Me.SearchableComboBoxViewOnAccount_GLAccount.AFActiveFilterString = ""
            Me.SearchableComboBoxViewOnAccount_GLAccount.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewOnAccount_GLAccount.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_GLAccount.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_GLAccount.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_GLAccount.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_GLAccount.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_GLAccount.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_GLAccount.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_GLAccount.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_GLAccount.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_GLAccount.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_GLAccount.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_GLAccount.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_GLAccount.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_GLAccount.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_GLAccount.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_GLAccount.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_GLAccount.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_GLAccount.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_GLAccount.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_GLAccount.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_GLAccount.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_GLAccount.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_GLAccount.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_GLAccount.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_GLAccount.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_GLAccount.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_GLAccount.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_GLAccount.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_GLAccount.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_GLAccount.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_GLAccount.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_GLAccount.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_GLAccount.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_GLAccount.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_GLAccount.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_GLAccount.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_GLAccount.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_GLAccount.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewOnAccount_GLAccount.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewOnAccount_GLAccount.DataSourceClearing = False
            Me.SearchableComboBoxViewOnAccount_GLAccount.EnableDisabledRows = False
            Me.SearchableComboBoxViewOnAccount_GLAccount.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewOnAccount_GLAccount.Name = "SearchableComboBoxViewOnAccount_GLAccount"
            Me.SearchableComboBoxViewOnAccount_GLAccount.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewOnAccount_GLAccount.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewOnAccount_GLAccount.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewOnAccount_GLAccount.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewOnAccount_GLAccount.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewOnAccount_GLAccount.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewOnAccount_GLAccount.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewOnAccount_GLAccount.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewOnAccount_GLAccount.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewOnAccount_GLAccount.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewOnAccount_GLAccount.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewOnAccount_GLAccount.RunStandardValidation = True
            '
            'LabelOnAccount_Campaign
            '
            Me.LabelOnAccount_Campaign.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelOnAccount_Campaign.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelOnAccount_Campaign.Location = New System.Drawing.Point(5, 102)
            Me.LabelOnAccount_Campaign.Name = "LabelOnAccount_Campaign"
            Me.LabelOnAccount_Campaign.Size = New System.Drawing.Size(81, 20)
            Me.LabelOnAccount_Campaign.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelOnAccount_Campaign.TabIndex = 6
            Me.LabelOnAccount_Campaign.Text = "Campaign:"
            '
            'SearchableComboBoxOnAccount_Campaign
            '
            Me.SearchableComboBoxOnAccount_Campaign.ActiveFilterString = ""
            Me.SearchableComboBoxOnAccount_Campaign.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxOnAccount_Campaign.AutoFillMode = False
            Me.SearchableComboBoxOnAccount_Campaign.BookmarkingEnabled = False
            Me.SearchableComboBoxOnAccount_Campaign.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Campaign
            Me.SearchableComboBoxOnAccount_Campaign.DataSource = Nothing
            Me.SearchableComboBoxOnAccount_Campaign.DisableMouseWheel = True
            Me.SearchableComboBoxOnAccount_Campaign.DisplayName = ""
            Me.SearchableComboBoxOnAccount_Campaign.EnterMoveNextControl = True
            Me.SearchableComboBoxOnAccount_Campaign.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.None
            Me.SearchableComboBoxOnAccount_Campaign.Location = New System.Drawing.Point(92, 102)
            Me.SearchableComboBoxOnAccount_Campaign.Name = "SearchableComboBoxOnAccount_Campaign"
            Me.SearchableComboBoxOnAccount_Campaign.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxOnAccount_Campaign.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxOnAccount_Campaign.Properties.NullText = "Select Campaign"
            Me.SearchableComboBoxOnAccount_Campaign.Properties.ShowClearButton = False
            Me.SearchableComboBoxOnAccount_Campaign.Properties.ValueMember = "ID"
            Me.SearchableComboBoxOnAccount_Campaign.Properties.View = Me.SearchableComboBoxViewOnAccount_Campaign
            Me.SearchableComboBoxOnAccount_Campaign.SecurityEnabled = True
            Me.SearchableComboBoxOnAccount_Campaign.SelectedValue = Nothing
            Me.SearchableComboBoxOnAccount_Campaign.Size = New System.Drawing.Size(234, 20)
            Me.SearchableComboBoxOnAccount_Campaign.TabIndex = 7
            '
            'SearchableComboBoxViewOnAccount_Campaign
            '
            Me.SearchableComboBoxViewOnAccount_Campaign.AFActiveFilterString = ""
            Me.SearchableComboBoxViewOnAccount_Campaign.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewOnAccount_Campaign.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Campaign.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Campaign.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Campaign.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Campaign.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Campaign.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Campaign.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Campaign.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Campaign.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Campaign.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Campaign.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Campaign.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Campaign.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Campaign.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Campaign.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Campaign.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Campaign.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Campaign.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Campaign.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Campaign.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Campaign.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Campaign.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Campaign.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Campaign.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Campaign.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Campaign.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Campaign.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Campaign.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Campaign.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Campaign.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Campaign.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Campaign.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Campaign.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Campaign.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Campaign.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Campaign.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Campaign.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Campaign.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewOnAccount_Campaign.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewOnAccount_Campaign.DataSourceClearing = False
            Me.SearchableComboBoxViewOnAccount_Campaign.EnableDisabledRows = False
            Me.SearchableComboBoxViewOnAccount_Campaign.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewOnAccount_Campaign.Name = "SearchableComboBoxViewOnAccount_Campaign"
            Me.SearchableComboBoxViewOnAccount_Campaign.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewOnAccount_Campaign.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewOnAccount_Campaign.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewOnAccount_Campaign.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewOnAccount_Campaign.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewOnAccount_Campaign.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewOnAccount_Campaign.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewOnAccount_Campaign.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewOnAccount_Campaign.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewOnAccount_Campaign.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewOnAccount_Campaign.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewOnAccount_Campaign.RunStandardValidation = True
            '
            'LabelOnAccount_Office
            '
            Me.LabelOnAccount_Office.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelOnAccount_Office.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelOnAccount_Office.Location = New System.Drawing.Point(5, 76)
            Me.LabelOnAccount_Office.Name = "LabelOnAccount_Office"
            Me.LabelOnAccount_Office.Size = New System.Drawing.Size(81, 20)
            Me.LabelOnAccount_Office.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelOnAccount_Office.TabIndex = 4
            Me.LabelOnAccount_Office.Text = "Office:"
            '
            'LabelOnAccount_Product
            '
            Me.LabelOnAccount_Product.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelOnAccount_Product.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelOnAccount_Product.Location = New System.Drawing.Point(5, 50)
            Me.LabelOnAccount_Product.Name = "LabelOnAccount_Product"
            Me.LabelOnAccount_Product.Size = New System.Drawing.Size(81, 20)
            Me.LabelOnAccount_Product.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelOnAccount_Product.TabIndex = 2
            Me.LabelOnAccount_Product.Text = "Product:"
            '
            'SearchableComboBoxOnAccount_Product
            '
            Me.SearchableComboBoxOnAccount_Product.ActiveFilterString = ""
            Me.SearchableComboBoxOnAccount_Product.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxOnAccount_Product.AutoFillMode = False
            Me.SearchableComboBoxOnAccount_Product.BookmarkingEnabled = False
            Me.SearchableComboBoxOnAccount_Product.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Product
            Me.SearchableComboBoxOnAccount_Product.DataSource = Nothing
            Me.SearchableComboBoxOnAccount_Product.DisableMouseWheel = True
            Me.SearchableComboBoxOnAccount_Product.DisplayName = ""
            Me.SearchableComboBoxOnAccount_Product.EnterMoveNextControl = True
            Me.SearchableComboBoxOnAccount_Product.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.None
            Me.SearchableComboBoxOnAccount_Product.Location = New System.Drawing.Point(92, 50)
            Me.SearchableComboBoxOnAccount_Product.Name = "SearchableComboBoxOnAccount_Product"
            Me.SearchableComboBoxOnAccount_Product.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxOnAccount_Product.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxOnAccount_Product.Properties.NullText = "Select Product"
            Me.SearchableComboBoxOnAccount_Product.Properties.ShowClearButton = False
            Me.SearchableComboBoxOnAccount_Product.Properties.ValueMember = "Code"
            Me.SearchableComboBoxOnAccount_Product.Properties.View = Me.SearchableComboBoxViewOnAccount_Product
            Me.SearchableComboBoxOnAccount_Product.SecurityEnabled = True
            Me.SearchableComboBoxOnAccount_Product.SelectedValue = Nothing
            Me.SearchableComboBoxOnAccount_Product.Size = New System.Drawing.Size(234, 20)
            Me.SearchableComboBoxOnAccount_Product.TabIndex = 3
            '
            'SearchableComboBoxViewOnAccount_Product
            '
            Me.SearchableComboBoxViewOnAccount_Product.AFActiveFilterString = ""
            Me.SearchableComboBoxViewOnAccount_Product.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewOnAccount_Product.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Product.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Product.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Product.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Product.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Product.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Product.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Product.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Product.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Product.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Product.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Product.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Product.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Product.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Product.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Product.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Product.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Product.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Product.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Product.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Product.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Product.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Product.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Product.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Product.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Product.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Product.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Product.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Product.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Product.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Product.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Product.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Product.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Product.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Product.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Product.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Product.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Product.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewOnAccount_Product.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewOnAccount_Product.DataSourceClearing = False
            Me.SearchableComboBoxViewOnAccount_Product.EnableDisabledRows = False
            Me.SearchableComboBoxViewOnAccount_Product.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewOnAccount_Product.Name = "SearchableComboBoxViewOnAccount_Product"
            Me.SearchableComboBoxViewOnAccount_Product.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewOnAccount_Product.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewOnAccount_Product.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewOnAccount_Product.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewOnAccount_Product.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewOnAccount_Product.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewOnAccount_Product.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewOnAccount_Product.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewOnAccount_Product.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewOnAccount_Product.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewOnAccount_Product.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewOnAccount_Product.RunStandardValidation = True
            '
            'LabelOnAccount_Division
            '
            Me.LabelOnAccount_Division.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelOnAccount_Division.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelOnAccount_Division.Location = New System.Drawing.Point(5, 24)
            Me.LabelOnAccount_Division.Name = "LabelOnAccount_Division"
            Me.LabelOnAccount_Division.Size = New System.Drawing.Size(81, 20)
            Me.LabelOnAccount_Division.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelOnAccount_Division.TabIndex = 0
            Me.LabelOnAccount_Division.Text = "Division:"
            '
            'SearchableComboBoxOnAccount_Division
            '
            Me.SearchableComboBoxOnAccount_Division.ActiveFilterString = ""
            Me.SearchableComboBoxOnAccount_Division.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxOnAccount_Division.AutoFillMode = False
            Me.SearchableComboBoxOnAccount_Division.BookmarkingEnabled = False
            Me.SearchableComboBoxOnAccount_Division.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Division
            Me.SearchableComboBoxOnAccount_Division.DataSource = Nothing
            Me.SearchableComboBoxOnAccount_Division.DisableMouseWheel = True
            Me.SearchableComboBoxOnAccount_Division.DisplayName = ""
            Me.SearchableComboBoxOnAccount_Division.EnterMoveNextControl = True
            Me.SearchableComboBoxOnAccount_Division.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.None
            Me.SearchableComboBoxOnAccount_Division.Location = New System.Drawing.Point(92, 24)
            Me.SearchableComboBoxOnAccount_Division.Name = "SearchableComboBoxOnAccount_Division"
            Me.SearchableComboBoxOnAccount_Division.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxOnAccount_Division.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxOnAccount_Division.Properties.NullText = "Select Division"
            Me.SearchableComboBoxOnAccount_Division.Properties.ShowClearButton = False
            Me.SearchableComboBoxOnAccount_Division.Properties.ValueMember = "Code"
            Me.SearchableComboBoxOnAccount_Division.Properties.View = Me.SearchableComboBoxViewOnAccount_Division
            Me.SearchableComboBoxOnAccount_Division.SecurityEnabled = True
            Me.SearchableComboBoxOnAccount_Division.SelectedValue = Nothing
            Me.SearchableComboBoxOnAccount_Division.Size = New System.Drawing.Size(234, 20)
            Me.SearchableComboBoxOnAccount_Division.TabIndex = 1
            '
            'SearchableComboBoxViewOnAccount_Division
            '
            Me.SearchableComboBoxViewOnAccount_Division.AFActiveFilterString = ""
            Me.SearchableComboBoxViewOnAccount_Division.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewOnAccount_Division.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Division.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Division.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Division.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Division.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Division.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Division.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Division.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Division.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Division.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Division.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Division.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Division.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Division.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Division.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Division.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Division.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Division.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Division.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Division.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Division.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Division.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Division.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Division.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Division.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Division.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Division.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Division.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Division.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Division.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Division.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Division.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Division.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Division.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Division.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Division.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Division.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewOnAccount_Division.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewOnAccount_Division.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewOnAccount_Division.DataSourceClearing = False
            Me.SearchableComboBoxViewOnAccount_Division.EnableDisabledRows = False
            Me.SearchableComboBoxViewOnAccount_Division.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewOnAccount_Division.Name = "SearchableComboBoxViewOnAccount_Division"
            Me.SearchableComboBoxViewOnAccount_Division.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewOnAccount_Division.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewOnAccount_Division.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewOnAccount_Division.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewOnAccount_Division.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewOnAccount_Division.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewOnAccount_Division.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewOnAccount_Division.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewOnAccount_Division.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewOnAccount_Division.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewOnAccount_Division.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewOnAccount_Division.RunStandardValidation = True
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
            Me.GroupBoxPanel_DepositInformation.Location = New System.Drawing.Point(5, 167)
            Me.GroupBoxPanel_DepositInformation.Name = "GroupBoxPanel_DepositInformation"
            Me.GroupBoxPanel_DepositInformation.Size = New System.Drawing.Size(309, 135)
            Me.GroupBoxPanel_DepositInformation.TabIndex = 7
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
            Me.DateTimePickerDepositInfo_Date.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
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
            Me.DateTimePickerDepositInfo_Date.Value = New Date(2013, 11, 4, 16, 40, 15, 605)
            '
            'GroupBoxPanel_CheckInformation
            '
            Me.GroupBoxPanel_CheckInformation.Controls.Add(Me.LabelCheckInfo_Amount)
            Me.GroupBoxPanel_CheckInformation.Controls.Add(Me.NumericInputCheckInfo_Amount)
            Me.GroupBoxPanel_CheckInformation.Controls.Add(Me.LabelCheckInfo_Date)
            Me.GroupBoxPanel_CheckInformation.Controls.Add(Me.DateTimePickerCheckInfo_Date)
            Me.GroupBoxPanel_CheckInformation.Location = New System.Drawing.Point(5, 82)
            Me.GroupBoxPanel_CheckInformation.Name = "GroupBoxPanel_CheckInformation"
            Me.GroupBoxPanel_CheckInformation.Size = New System.Drawing.Size(309, 79)
            Me.GroupBoxPanel_CheckInformation.TabIndex = 6
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
            Me.DateTimePickerCheckInfo_Date.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
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
            Me.DateTimePickerCheckInfo_Date.Value = New Date(2013, 11, 4, 16, 40, 15, 644)
            '
            'SearchableComboBoxPanel_Client
            '
            Me.SearchableComboBoxPanel_Client.ActiveFilterString = ""
            Me.SearchableComboBoxPanel_Client.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxPanel_Client.AutoFillMode = False
            Me.SearchableComboBoxPanel_Client.BookmarkingEnabled = False
            Me.SearchableComboBoxPanel_Client.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Client
            Me.SearchableComboBoxPanel_Client.DataSource = Nothing
            Me.SearchableComboBoxPanel_Client.DisableMouseWheel = True
            Me.SearchableComboBoxPanel_Client.DisplayName = ""
            Me.SearchableComboBoxPanel_Client.EnterMoveNextControl = True
            Me.SearchableComboBoxPanel_Client.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxPanel_Client.Location = New System.Drawing.Point(92, 5)
            Me.SearchableComboBoxPanel_Client.Name = "SearchableComboBoxPanel_Client"
            Me.SearchableComboBoxPanel_Client.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxPanel_Client.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxPanel_Client.Properties.NullText = "Select Client"
            Me.SearchableComboBoxPanel_Client.Properties.ShowClearButton = False
            Me.SearchableComboBoxPanel_Client.Properties.ValueMember = "Code"
            Me.SearchableComboBoxPanel_Client.Properties.View = Me.SearchableComboBoxViewPanel_Client
            Me.SearchableComboBoxPanel_Client.SecurityEnabled = True
            Me.SearchableComboBoxPanel_Client.SelectedValue = Nothing
            Me.SearchableComboBoxPanel_Client.Size = New System.Drawing.Size(222, 20)
            Me.SearchableComboBoxPanel_Client.TabIndex = 1
            '
            'SearchableComboBoxViewPanel_Client
            '
            Me.SearchableComboBoxViewPanel_Client.AFActiveFilterString = ""
            Me.SearchableComboBoxViewPanel_Client.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewPanel_Client.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_Client.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_Client.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_Client.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_Client.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_Client.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_Client.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_Client.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_Client.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_Client.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_Client.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_Client.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_Client.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_Client.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_Client.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_Client.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_Client.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_Client.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_Client.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_Client.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_Client.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_Client.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_Client.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_Client.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_Client.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_Client.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_Client.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_Client.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_Client.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_Client.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_Client.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_Client.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_Client.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_Client.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_Client.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_Client.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_Client.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewPanel_Client.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewPanel_Client.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewPanel_Client.DataSourceClearing = False
            Me.SearchableComboBoxViewPanel_Client.EnableDisabledRows = False
            Me.SearchableComboBoxViewPanel_Client.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewPanel_Client.Name = "SearchableComboBoxViewPanel_Client"
            Me.SearchableComboBoxViewPanel_Client.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewPanel_Client.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewPanel_Client.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewPanel_Client.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewPanel_Client.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewPanel_Client.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewPanel_Client.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewPanel_Client.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewPanel_Client.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewPanel_Client.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewPanel_Client.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewPanel_Client.RunStandardValidation = True
            '
            'LabelPanel_CheckNumber
            '
            Me.LabelPanel_CheckNumber.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPanel_CheckNumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPanel_CheckNumber.Location = New System.Drawing.Point(5, 31)
            Me.LabelPanel_CheckNumber.Name = "LabelPanel_CheckNumber"
            Me.LabelPanel_CheckNumber.Size = New System.Drawing.Size(81, 20)
            Me.LabelPanel_CheckNumber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPanel_CheckNumber.TabIndex = 2
            Me.LabelPanel_CheckNumber.Text = "Check Number:"
            '
            'LabelPanel_Client
            '
            Me.LabelPanel_Client.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPanel_Client.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPanel_Client.Location = New System.Drawing.Point(5, 5)
            Me.LabelPanel_Client.Name = "LabelPanel_Client"
            Me.LabelPanel_Client.Size = New System.Drawing.Size(81, 20)
            Me.LabelPanel_Client.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPanel_Client.TabIndex = 0
            Me.LabelPanel_Client.Text = "Client:"
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
            Me.LabelPanel_PostingPeriod.TabIndex = 9
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
            Me.TextBoxPanel_CheckNumber.Location = New System.Drawing.Point(92, 31)
            Me.TextBoxPanel_CheckNumber.MaxFileSize = CType(0, Long)
            Me.TextBoxPanel_CheckNumber.Name = "TextBoxPanel_CheckNumber"
            Me.TextBoxPanel_CheckNumber.SecurityEnabled = True
            Me.TextBoxPanel_CheckNumber.ShowSpellCheckCompleteMessage = True
            Me.TextBoxPanel_CheckNumber.Size = New System.Drawing.Size(222, 21)
            Me.TextBoxPanel_CheckNumber.StartingFolderName = Nothing
            Me.TextBoxPanel_CheckNumber.TabIndex = 3
            Me.TextBoxPanel_CheckNumber.TabOnEnter = True
            '
            'ClientCashReceiptControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.DataGridViewPanel_ClientInvoices)
            Me.Controls.Add(Me.PanelControl_Header)
            Me.Name = "ClientCashReceiptControl"
            Me.Size = New System.Drawing.Size(992, 615)
            CType(Me.PanelControl_Header, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelControl_Header.ResumeLayout(False)
            Me.PanelControl_Header.PerformLayout()
            CType(Me.SearchableComboBoxPanel_PaymentType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.TabControlControl_InvoiceDetails, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlControl_InvoiceDetails.ResumeLayout(False)
            Me.TabControlPanelDistributionTab_Distribution.ResumeLayout(False)
            CType(Me.NumericInputDisbursedTo_Balance.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputDisbursedTo_ClientInvoice.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputDisbursedTo_OnAccount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelTransactionsTab_Transactions.ResumeLayout(False)
            CType(Me.SearchableComboBoxPanel_CheckNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewPanel_CheckNumber, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxPanel_OnAccount, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxPanel_OnAccount.ResumeLayout(False)
            CType(Me.SearchableComboBoxOnAccount_Office.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewOnAccount_Office, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputOnAccount_Amount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxOnAccount_GLAccount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewOnAccount_GLAccount, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxOnAccount_Campaign.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewOnAccount_Campaign, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxOnAccount_Product.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewOnAccount_Product, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxOnAccount_Division.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewOnAccount_Division, System.ComponentModel.ISupportInitialize).EndInit()
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
            CType(Me.SearchableComboBoxPanel_Client.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewPanel_Client, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents PanelControl_Header As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents GroupBoxPanel_CheckInformation As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents LabelCheckInfo_Date As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents DateTimePickerCheckInfo_Date As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents SearchableComboBoxPanel_Client As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewPanel_Client As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents LabelPanel_CheckNumber As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelPanel_Client As AdvantageFramework.WinForm.Presentation.Controls.Label
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
        Friend WithEvents NumericInputDisbursedTo_Balance As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents LabelDisbursedTo_Balance As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents NumericInputDisbursedTo_OnAccount As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputDisbursedTo_ClientInvoice As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents LabelDisbursedTo_ClientInvoice As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelDisbursedTo_OnAccount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxPanel_OnAccount As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents LabelOnAccount_Campaign As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxOnAccount_Campaign As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewOnAccount_Campaign As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents LabelOnAccount_Office As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelOnAccount_Product As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxOnAccount_Product As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewOnAccount_Product As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents LabelOnAccount_Division As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxOnAccount_Division As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewOnAccount_Division As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents LabelOnAccount_Comment As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelOnAccount_Amount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelOnAccount_GLAccount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxOnAccount_GLAccount As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewOnAccount_GLAccount As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents NumericInputOnAccount_Amount As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents TextBoxOnAccount_Comment As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelDepositInfo_Office As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelPanel_PostingPeriodForMod As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxPanel_ClientARComment As System.Windows.Forms.TextBox
        Friend WithEvents LabelPanel_ClientARComment As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxDropDownPanel_ARComment As DevComponents.DotNetBar.Controls.TextBoxDropDown
        Friend WithEvents DataGridViewPanel_ClientInvoices As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TextBoxPanel_CheckNumber As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents SearchableComboBoxOnAccount_Office As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewOnAccount_Office As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxDepositInfo_GLAccount As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewDepositInfo_GLAccount As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxDepositInfo_Office As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewDepositInfo_Office As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxPanel_CheckNumber As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewPanel_CheckNumber As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents ComboBoxPanel_PostPeriodForMod As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxPanel_PostPeriod As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents TabControlControl_InvoiceDetails As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelDistributionTab_Distribution As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemInvoiceDetails_DistributionTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelTransactionsTab_Transactions As DevComponents.DotNetBar.TabControlPanel
        Private WithEvents DataGridViewTransactions_GLTransactions As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TabItemInvoiceDetails_TransactionsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents LabelPanel_Message As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxPanel_MessageDetails As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents CheckBoxDepositInfo_Cleared As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelPanel_PaymentType As Label
        Friend WithEvents SearchableComboBoxPanel_PaymentType As SearchableComboBox
        Friend WithEvents GridView1 As GridView
    End Class

End Namespace
