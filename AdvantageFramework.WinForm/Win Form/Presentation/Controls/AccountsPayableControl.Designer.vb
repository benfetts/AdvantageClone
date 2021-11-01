Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class AccountsPayableControl
        Inherits AdvantageFramework.WinForm.Presentation.Controls.BaseControls.BaseUserControl

        'UserControl overrides dispose to clean up the component list.
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
            Me.ExpandablePanelControl_HeaderInfo = New DevComponents.DotNetBar.ExpandablePanel()
            Me.PictureUpdateCurrency_Image = New DevExpress.XtraEditors.PictureEdit()
            Me.SearchableComboBoxControl_CurrencyCode = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView2 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.NumericInputControl_ExchangeAmount = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelControl_ExchangeAmount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.Address3LineControlControl_Address = New AdvantageFramework.WinForm.Presentation.Controls.Address3LineControl()
            Me.NumericInputControl_HomeCurrencyAmount = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelControl_HomeCurrency = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.NumericInputControl_VendorCurrencyRate = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputControl_VendorTaxableAmount = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelControl_VendorTaxCode = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxControl_VendorTaxEnabled = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.SearchableComboBoxControl_VendorTaxCode = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView1 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelControl_Tax = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.NumericInputControl_SalesTax = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.TextBoxControl_MessageDetails = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelControl_Message = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxDropDownControl_Note = New DevComponents.DotNetBar.Controls.TextBoxDropDown()
            Me.TextBoxControl_VendorNote = New System.Windows.Forms.TextBox()
            Me.NumericInputInvoiceInformation_TotalPaidToVendor = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelControl_TotalPaid = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxControl_Vendor = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewControl_Vendor = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.TabControlControl_InvoiceDetails = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelDistributionTab_Distribution = New DevComponents.DotNetBar.TabControlPanel()
            Me.NumericInputDistribution_ForeignTotal = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelDistribution_ForeignTotal = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.NumericInputDistribution_Balance = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelDistribution_BalanceToApply = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.NumericInputDistribution_NonClient = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputDistribution_Clients = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelDistribution_ClientTotal = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelDistribution_NonClientTotal = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabItemInvoiceDetails_DistributionTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelTransactionsTab_Transactions = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewTransactions_GLTransactions = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemInvoiceDetails_TransactionsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelChecksWrittenTab_ChecksWritten = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewChecksWritten_ChecksWritten = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemInvoiceDetails_ChecksWrittenTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.LabelControl_TotalDue = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.NumericInputControl_DiscountPercentage = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputControl_Discount = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelControl_DiscountPercentage = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.NumericInputControl_InvoiceTotal = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelControl_Currency = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelControl_InvoiceTotal = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxControl_PostPeriodForMod = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.DateTimePickerControl_InvoiceDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.ComboBoxControl_Terms = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelControl_Note = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelControl_PostingPeriodForMod = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DateTimePickerControl_DateToPay = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.ComboBoxControl_APAccount = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelControl_InvoiceDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxControl_Office = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ComboBoxControl_PostPeriod = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelControl_Terms = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.NumericInputControl_InvoiceAmount = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelControl_Office = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelControl_DateToPay = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelControl_APAccount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DateTimePickerControl_EntryDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.CheckBoxControl_OnHold = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxControl_1099Invoice = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelControl_EntryDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxControl_Description = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelControl_InvoiceAmount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelControl_Description = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelControl_InvoiceNumber = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelControl_Vendor = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelControl_PayTo = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelControl_PostingPeriod = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxControl_PayTo = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.NumericInputControl_TotalDue = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.SearchableComboBoxControl_InvoiceNumber = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewControl_InvoiceNumber = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.TextBoxControl_InvoiceNumber = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelControl_VendorTaxableAmount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TabControlControl_APDetails = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelRadioTab_Radio = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewRadio_DistributionDetails = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemAPDetails_RadioTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelRadioDetailsTab_RadioDetails = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewRadioDetails_BroadcastDetails = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemAPDetails_RadioDetailsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelMagazineTab_Magazine = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewMagazine_DistributionDetails = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemAPDetails_MagazineTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelTVTab_TV = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewTV_DistributionDetails = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemAPDetails_TVTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelTVDetailsTab_TVDetails = New DevComponents.DotNetBar.TabControlPanel()
            Me.TabItemAPDetails_TVDetailsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelProductionTab_Production = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewProduction_DistributionDetails = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemAPDetails_ProductionTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelInternetTab_Internet = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewInternet_DistributionDetails = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemAPDetails_InternetTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelNonClientTab_NonClient = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewNonClient_DistributionDetails = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemAPDetails_NonClientTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelDocumentsTab_Documents = New DevComponents.DotNetBar.TabControlPanel()
            Me.DocumentManagerControlDocuments_APDocuments = New AdvantageFramework.WinForm.Presentation.Controls.DocumentManagerControl()
            Me.TabItemAPDetails_DocumentsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelExpenseReceiptsTab_ExpenseReceipts = New DevComponents.DotNetBar.TabControlPanel()
            Me.DocumentManagerControlExpenseReceipts_Receipts = New AdvantageFramework.WinForm.Presentation.Controls.DocumentManagerControl()
            Me.TabItemAPDetails_ExpenseReceiptsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelOutOfHomeTab_OutOfHome = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewOutOfHome_DistributionDetails = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemAPDetails_OutOfHomeTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelNewspaperTab_Newspaper = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewNewspaper_DistributionDetails = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemAPDetails_NewspaperTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.DataGridViewTVDetails_BroadcastDetails = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ExpandablePanelControl_HeaderInfo.SuspendLayout()
            CType(Me.PictureUpdateCurrency_Image.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxControl_CurrencyCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputControl_ExchangeAmount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputControl_HomeCurrencyAmount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputControl_VendorCurrencyRate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputControl_VendorTaxableAmount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxControl_VendorTaxCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputControl_SalesTax.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputInvoiceInformation_TotalPaidToVendor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxControl_Vendor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewControl_Vendor, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.TabControlControl_InvoiceDetails, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlControl_InvoiceDetails.SuspendLayout()
            Me.TabControlPanelDistributionTab_Distribution.SuspendLayout()
            CType(Me.NumericInputDistribution_ForeignTotal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputDistribution_Balance.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputDistribution_NonClient.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputDistribution_Clients.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlPanelTransactionsTab_Transactions.SuspendLayout()
            Me.TabControlPanelChecksWrittenTab_ChecksWritten.SuspendLayout()
            CType(Me.NumericInputControl_DiscountPercentage.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputControl_Discount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputControl_InvoiceTotal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerControl_InvoiceDate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerControl_DateToPay, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputControl_InvoiceAmount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerControl_EntryDate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputControl_TotalDue.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxControl_InvoiceNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewControl_InvoiceNumber, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.TabControlControl_APDetails, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlControl_APDetails.SuspendLayout()
            Me.TabControlPanelRadioTab_Radio.SuspendLayout()
            Me.TabControlPanelRadioDetailsTab_RadioDetails.SuspendLayout()
            Me.TabControlPanelMagazineTab_Magazine.SuspendLayout()
            Me.TabControlPanelTVTab_TV.SuspendLayout()
            Me.TabControlPanelTVDetailsTab_TVDetails.SuspendLayout()
            Me.TabControlPanelProductionTab_Production.SuspendLayout()
            Me.TabControlPanelInternetTab_Internet.SuspendLayout()
            Me.TabControlPanelNonClientTab_NonClient.SuspendLayout()
            Me.TabControlPanelDocumentsTab_Documents.SuspendLayout()
            Me.TabControlPanelExpenseReceiptsTab_ExpenseReceipts.SuspendLayout()
            Me.TabControlPanelOutOfHomeTab_OutOfHome.SuspendLayout()
            Me.TabControlPanelNewspaperTab_Newspaper.SuspendLayout()
            Me.SuspendLayout()
            '
            'ExpandablePanelControl_HeaderInfo
            '
            Me.ExpandablePanelControl_HeaderInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
            Me.ExpandablePanelControl_HeaderInfo.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.PictureUpdateCurrency_Image)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.SearchableComboBoxControl_CurrencyCode)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.NumericInputControl_ExchangeAmount)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.LabelControl_ExchangeAmount)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.Address3LineControlControl_Address)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.NumericInputControl_HomeCurrencyAmount)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.LabelControl_HomeCurrency)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.NumericInputControl_VendorCurrencyRate)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.NumericInputControl_VendorTaxableAmount)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.LabelControl_VendorTaxCode)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.CheckBoxControl_VendorTaxEnabled)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.SearchableComboBoxControl_VendorTaxCode)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.LabelControl_Tax)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.NumericInputControl_SalesTax)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.TextBoxControl_MessageDetails)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.LabelControl_Message)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.TextBoxDropDownControl_Note)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.NumericInputInvoiceInformation_TotalPaidToVendor)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.LabelControl_TotalPaid)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.SearchableComboBoxControl_Vendor)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.TabControlControl_InvoiceDetails)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.LabelControl_TotalDue)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.NumericInputControl_DiscountPercentage)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.NumericInputControl_Discount)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.LabelControl_DiscountPercentage)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.NumericInputControl_InvoiceTotal)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.LabelControl_Currency)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.LabelControl_InvoiceTotal)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.ComboBoxControl_PostPeriodForMod)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.DateTimePickerControl_InvoiceDate)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.ComboBoxControl_Terms)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.LabelControl_Note)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.LabelControl_PostingPeriodForMod)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.DateTimePickerControl_DateToPay)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.ComboBoxControl_APAccount)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.LabelControl_InvoiceDate)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.ComboBoxControl_Office)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.ComboBoxControl_PostPeriod)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.LabelControl_Terms)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.NumericInputControl_InvoiceAmount)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.LabelControl_Office)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.LabelControl_DateToPay)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.LabelControl_APAccount)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.DateTimePickerControl_EntryDate)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.CheckBoxControl_OnHold)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.CheckBoxControl_1099Invoice)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.LabelControl_EntryDate)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.TextBoxControl_Description)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.LabelControl_InvoiceAmount)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.LabelControl_Description)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.LabelControl_InvoiceNumber)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.LabelControl_Vendor)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.LabelControl_PayTo)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.LabelControl_PostingPeriod)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.TextBoxControl_PayTo)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.TextBoxControl_VendorNote)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.NumericInputControl_TotalDue)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.SearchableComboBoxControl_InvoiceNumber)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.TextBoxControl_InvoiceNumber)
            Me.ExpandablePanelControl_HeaderInfo.Controls.Add(Me.LabelControl_VendorTaxableAmount)
            Me.ExpandablePanelControl_HeaderInfo.DisabledBackColor = System.Drawing.Color.Empty
            Me.ExpandablePanelControl_HeaderInfo.Dock = System.Windows.Forms.DockStyle.Top
            Me.ExpandablePanelControl_HeaderInfo.Location = New System.Drawing.Point(0, 0)
            Me.ExpandablePanelControl_HeaderInfo.Name = "ExpandablePanelControl_HeaderInfo"
            Me.ExpandablePanelControl_HeaderInfo.Size = New System.Drawing.Size(992, 353)
            Me.ExpandablePanelControl_HeaderInfo.Style.Alignment = System.Drawing.StringAlignment.Center
            Me.ExpandablePanelControl_HeaderInfo.Style.BackColor1.Color = System.Drawing.Color.White
            Me.ExpandablePanelControl_HeaderInfo.Style.BackColor2.Color = System.Drawing.Color.White
            Me.ExpandablePanelControl_HeaderInfo.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.ExpandablePanelControl_HeaderInfo.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(154, Byte), Integer))
            Me.ExpandablePanelControl_HeaderInfo.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandablePanelControl_HeaderInfo.Style.GradientAngle = 90
            Me.ExpandablePanelControl_HeaderInfo.TabIndex = 2
            Me.ExpandablePanelControl_HeaderInfo.TextDockConstrained = False
            Me.ExpandablePanelControl_HeaderInfo.TitleStyle.Alignment = System.Drawing.StringAlignment.Center
            Me.ExpandablePanelControl_HeaderInfo.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandablePanelControl_HeaderInfo.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner
            Me.ExpandablePanelControl_HeaderInfo.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandablePanelControl_HeaderInfo.TitleStyle.ForeColor.Color = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(154, Byte), Integer))
            Me.ExpandablePanelControl_HeaderInfo.TitleStyle.GradientAngle = 90
            Me.ExpandablePanelControl_HeaderInfo.TitleText = "General Info"
            '
            'PictureUpdateCurrency_Image
            '
            Me.PictureUpdateCurrency_Image.Cursor = System.Windows.Forms.Cursors.Help
            Me.PictureUpdateCurrency_Image.Location = New System.Drawing.Point(379, 210)
            Me.PictureUpdateCurrency_Image.Name = "PictureUpdateCurrency_Image"
            Me.PictureUpdateCurrency_Image.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze
            Me.PictureUpdateCurrency_Image.Properties.ZoomAccelerationFactor = 1.0R
            Me.PictureUpdateCurrency_Image.Size = New System.Drawing.Size(20, 20)
            Me.PictureUpdateCurrency_Image.TabIndex = 104
            Me.PictureUpdateCurrency_Image.ToolTip = "Click the image to sign-up for free at:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "https://currencylayer.com/" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
            Me.PictureUpdateCurrency_Image.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
            '
            'SearchableComboBoxControl_CurrencyCode
            '
            Me.SearchableComboBoxControl_CurrencyCode.ActiveFilterString = ""
            Me.SearchableComboBoxControl_CurrencyCode.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxControl_CurrencyCode.AutoFillMode = False
            Me.SearchableComboBoxControl_CurrencyCode.BookmarkingEnabled = False
            Me.SearchableComboBoxControl_CurrencyCode.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.CurrencyCode
            Me.SearchableComboBoxControl_CurrencyCode.DataSource = Nothing
            Me.SearchableComboBoxControl_CurrencyCode.DisableMouseWheel = True
            Me.SearchableComboBoxControl_CurrencyCode.DisplayName = ""
            Me.SearchableComboBoxControl_CurrencyCode.EditValue = ""
            Me.SearchableComboBoxControl_CurrencyCode.EnterMoveNextControl = True
            Me.SearchableComboBoxControl_CurrencyCode.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxControl_CurrencyCode.Location = New System.Drawing.Point(405, 210)
            Me.SearchableComboBoxControl_CurrencyCode.Name = "SearchableComboBoxControl_CurrencyCode"
            Me.SearchableComboBoxControl_CurrencyCode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxControl_CurrencyCode.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxControl_CurrencyCode.Properties.NullText = "Select Currency Code"
            Me.SearchableComboBoxControl_CurrencyCode.Properties.ShowClearButton = False
            Me.SearchableComboBoxControl_CurrencyCode.Properties.ValueMember = "Code"
            Me.SearchableComboBoxControl_CurrencyCode.Properties.View = Me.GridView2
            Me.SearchableComboBoxControl_CurrencyCode.SecurityEnabled = True
            Me.SearchableComboBoxControl_CurrencyCode.SelectedValue = ""
            Me.SearchableComboBoxControl_CurrencyCode.Size = New System.Drawing.Size(50, 20)
            Me.SearchableComboBoxControl_CurrencyCode.TabIndex = 103
            Me.SearchableComboBoxControl_CurrencyCode.TabStop = False
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
            'NumericInputControl_ExchangeAmount
            '
            Me.NumericInputControl_ExchangeAmount.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputControl_ExchangeAmount.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputControl_ExchangeAmount.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputControl_ExchangeAmount.EnterMoveNextControl = True
            Me.NumericInputControl_ExchangeAmount.Location = New System.Drawing.Point(864, 210)
            Me.NumericInputControl_ExchangeAmount.Name = "NumericInputControl_ExchangeAmount"
            Me.NumericInputControl_ExchangeAmount.Properties.AllowMouseWheel = False
            Me.NumericInputControl_ExchangeAmount.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control
            Me.NumericInputControl_ExchangeAmount.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputControl_ExchangeAmount.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputControl_ExchangeAmount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputControl_ExchangeAmount.Properties.EditFormat.FormatString = "f"
            Me.NumericInputControl_ExchangeAmount.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputControl_ExchangeAmount.Properties.Mask.EditMask = "f"
            Me.NumericInputControl_ExchangeAmount.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputControl_ExchangeAmount.Properties.ReadOnly = True
            Me.NumericInputControl_ExchangeAmount.SecurityEnabled = True
            Me.NumericInputControl_ExchangeAmount.Size = New System.Drawing.Size(96, 20)
            Me.NumericInputControl_ExchangeAmount.TabIndex = 102
            Me.NumericInputControl_ExchangeAmount.TabStop = False
            '
            'LabelControl_ExchangeAmount
            '
            Me.LabelControl_ExchangeAmount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_ExchangeAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_ExchangeAmount.Location = New System.Drawing.Point(763, 210)
            Me.LabelControl_ExchangeAmount.Name = "LabelControl_ExchangeAmount"
            Me.LabelControl_ExchangeAmount.Size = New System.Drawing.Size(95, 20)
            Me.LabelControl_ExchangeAmount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_ExchangeAmount.TabIndex = 6
            Me.LabelControl_ExchangeAmount.Text = "Exchange Amount:"
            '
            'Address3LineControlControl_Address
            '
            Me.Address3LineControlControl_Address.Address = Nothing
            Me.Address3LineControlControl_Address.Address2 = Nothing
            Me.Address3LineControlControl_Address.Address3 = Nothing
            Me.Address3LineControlControl_Address.City = Nothing
            Me.Address3LineControlControl_Address.Country = Nothing
            Me.Address3LineControlControl_Address.County = Nothing
            Me.Address3LineControlControl_Address.DisableCountry = False
            Me.Address3LineControlControl_Address.DisableCounty = False
            Me.Address3LineControlControl_Address.Location = New System.Drawing.Point(3, 80)
            Me.Address3LineControlControl_Address.Name = "Address3LineControlControl_Address"
            Me.Address3LineControlControl_Address.ReadOnly = False
            Me.Address3LineControlControl_Address.ShowCountry = True
            Me.Address3LineControlControl_Address.ShowCounty = True
            Me.Address3LineControlControl_Address.Size = New System.Drawing.Size(309, 207)
            Me.Address3LineControlControl_Address.State = Nothing
            Me.Address3LineControlControl_Address.TabIndex = 101
            Me.Address3LineControlControl_Address.TabStop = False
            Me.Address3LineControlControl_Address.Title = "Address"
            Me.Address3LineControlControl_Address.Zip = Nothing
            '
            'NumericInputControl_HomeCurrencyAmount
            '
            Me.NumericInputControl_HomeCurrencyAmount.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputControl_HomeCurrencyAmount.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputControl_HomeCurrencyAmount.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputControl_HomeCurrencyAmount.EnterMoveNextControl = True
            Me.NumericInputControl_HomeCurrencyAmount.Location = New System.Drawing.Point(628, 210)
            Me.NumericInputControl_HomeCurrencyAmount.Name = "NumericInputControl_HomeCurrencyAmount"
            Me.NumericInputControl_HomeCurrencyAmount.Properties.AllowMouseWheel = False
            Me.NumericInputControl_HomeCurrencyAmount.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control
            Me.NumericInputControl_HomeCurrencyAmount.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputControl_HomeCurrencyAmount.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputControl_HomeCurrencyAmount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputControl_HomeCurrencyAmount.Properties.EditFormat.FormatString = "f"
            Me.NumericInputControl_HomeCurrencyAmount.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputControl_HomeCurrencyAmount.Properties.Mask.EditMask = "f"
            Me.NumericInputControl_HomeCurrencyAmount.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputControl_HomeCurrencyAmount.Properties.ReadOnly = True
            Me.NumericInputControl_HomeCurrencyAmount.SecurityEnabled = True
            Me.NumericInputControl_HomeCurrencyAmount.Size = New System.Drawing.Size(129, 20)
            Me.NumericInputControl_HomeCurrencyAmount.TabIndex = 100
            Me.NumericInputControl_HomeCurrencyAmount.TabStop = False
            '
            'LabelControl_HomeCurrency
            '
            Me.LabelControl_HomeCurrency.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_HomeCurrency.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelControl_HomeCurrency.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelControl_HomeCurrency.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelControl_HomeCurrency.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelControl_HomeCurrency.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelControl_HomeCurrency.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_HomeCurrency.Location = New System.Drawing.Point(559, 210)
            Me.LabelControl_HomeCurrency.Name = "LabelControl_HomeCurrency"
            Me.LabelControl_HomeCurrency.Size = New System.Drawing.Size(63, 20)
            Me.LabelControl_HomeCurrency.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_HomeCurrency.TabIndex = 99
            '
            'NumericInputControl_VendorCurrencyRate
            '
            Me.NumericInputControl_VendorCurrencyRate.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputControl_VendorCurrencyRate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputControl_VendorCurrencyRate.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputControl_VendorCurrencyRate.EnterMoveNextControl = True
            Me.NumericInputControl_VendorCurrencyRate.Location = New System.Drawing.Point(461, 210)
            Me.NumericInputControl_VendorCurrencyRate.Name = "NumericInputControl_VendorCurrencyRate"
            Me.NumericInputControl_VendorCurrencyRate.Properties.AllowMouseWheel = False
            Me.NumericInputControl_VendorCurrencyRate.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputControl_VendorCurrencyRate.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputControl_VendorCurrencyRate.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputControl_VendorCurrencyRate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputControl_VendorCurrencyRate.Properties.EditFormat.FormatString = "f"
            Me.NumericInputControl_VendorCurrencyRate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputControl_VendorCurrencyRate.Properties.Mask.EditMask = "f"
            Me.NumericInputControl_VendorCurrencyRate.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputControl_VendorCurrencyRate.SecurityEnabled = True
            Me.NumericInputControl_VendorCurrencyRate.Size = New System.Drawing.Size(92, 20)
            Me.NumericInputControl_VendorCurrencyRate.TabIndex = 97
            '
            'NumericInputControl_VendorTaxableAmount
            '
            Me.NumericInputControl_VendorTaxableAmount.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputControl_VendorTaxableAmount.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputControl_VendorTaxableAmount.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputControl_VendorTaxableAmount.EnterMoveNextControl = True
            Me.NumericInputControl_VendorTaxableAmount.Location = New System.Drawing.Point(628, 288)
            Me.NumericInputControl_VendorTaxableAmount.Name = "NumericInputControl_VendorTaxableAmount"
            Me.NumericInputControl_VendorTaxableAmount.Properties.AllowMouseWheel = False
            Me.NumericInputControl_VendorTaxableAmount.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputControl_VendorTaxableAmount.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputControl_VendorTaxableAmount.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputControl_VendorTaxableAmount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputControl_VendorTaxableAmount.Properties.EditFormat.FormatString = "f"
            Me.NumericInputControl_VendorTaxableAmount.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputControl_VendorTaxableAmount.Properties.Mask.EditMask = "f"
            Me.NumericInputControl_VendorTaxableAmount.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputControl_VendorTaxableAmount.SecurityEnabled = True
            Me.NumericInputControl_VendorTaxableAmount.Size = New System.Drawing.Size(129, 20)
            Me.NumericInputControl_VendorTaxableAmount.TabIndex = 29
            '
            'LabelControl_VendorTaxCode
            '
            Me.LabelControl_VendorTaxCode.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_VendorTaxCode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_VendorTaxCode.Location = New System.Drawing.Point(559, 262)
            Me.LabelControl_VendorTaxCode.Name = "LabelControl_VendorTaxCode"
            Me.LabelControl_VendorTaxCode.Size = New System.Drawing.Size(63, 20)
            Me.LabelControl_VendorTaxCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_VendorTaxCode.TabIndex = 95
            Me.LabelControl_VendorTaxCode.Text = "VST Code:"
            '
            'CheckBoxControl_VendorTaxEnabled
            '
            Me.CheckBoxControl_VendorTaxEnabled.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxControl_VendorTaxEnabled.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxControl_VendorTaxEnabled.CheckValue = 0
            Me.CheckBoxControl_VendorTaxEnabled.CheckValueChecked = 1
            Me.CheckBoxControl_VendorTaxEnabled.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxControl_VendorTaxEnabled.CheckValueUnchecked = 0
            Me.CheckBoxControl_VendorTaxEnabled.ChildControls = Nothing
            Me.CheckBoxControl_VendorTaxEnabled.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxControl_VendorTaxEnabled.Location = New System.Drawing.Point(628, 236)
            Me.CheckBoxControl_VendorTaxEnabled.Name = "CheckBoxControl_VendorTaxEnabled"
            Me.CheckBoxControl_VendorTaxEnabled.OldestSibling = Nothing
            Me.CheckBoxControl_VendorTaxEnabled.SecurityEnabled = True
            Me.CheckBoxControl_VendorTaxEnabled.SiblingControls = Nothing
            Me.CheckBoxControl_VendorTaxEnabled.Size = New System.Drawing.Size(129, 20)
            Me.CheckBoxControl_VendorTaxEnabled.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxControl_VendorTaxEnabled.TabIndex = 27
            Me.CheckBoxControl_VendorTaxEnabled.TabOnEnter = True
            Me.CheckBoxControl_VendorTaxEnabled.Text = "Subject to VST"
            '
            'SearchableComboBoxControl_VendorTaxCode
            '
            Me.SearchableComboBoxControl_VendorTaxCode.ActiveFilterString = ""
            Me.SearchableComboBoxControl_VendorTaxCode.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxControl_VendorTaxCode.AutoFillMode = False
            Me.SearchableComboBoxControl_VendorTaxCode.BookmarkingEnabled = False
            Me.SearchableComboBoxControl_VendorTaxCode.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.VendorServiceTax
            Me.SearchableComboBoxControl_VendorTaxCode.DataSource = Nothing
            Me.SearchableComboBoxControl_VendorTaxCode.DisableMouseWheel = False
            Me.SearchableComboBoxControl_VendorTaxCode.DisplayName = "VST Code"
            Me.SearchableComboBoxControl_VendorTaxCode.EnterMoveNextControl = True
            Me.SearchableComboBoxControl_VendorTaxCode.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.None
            Me.SearchableComboBoxControl_VendorTaxCode.Location = New System.Drawing.Point(628, 262)
            Me.SearchableComboBoxControl_VendorTaxCode.Name = "SearchableComboBoxControl_VendorTaxCode"
            Me.SearchableComboBoxControl_VendorTaxCode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxControl_VendorTaxCode.Properties.DisplayMember = "CodeAndDescription"
            Me.SearchableComboBoxControl_VendorTaxCode.Properties.NullText = "Select Vendor Service Tax"
            Me.SearchableComboBoxControl_VendorTaxCode.Properties.ShowClearButton = False
            Me.SearchableComboBoxControl_VendorTaxCode.Properties.ValueMember = "ID"
            Me.SearchableComboBoxControl_VendorTaxCode.Properties.View = Me.GridView1
            Me.SearchableComboBoxControl_VendorTaxCode.SecurityEnabled = True
            Me.SearchableComboBoxControl_VendorTaxCode.SelectedValue = Nothing
            Me.SearchableComboBoxControl_VendorTaxCode.Size = New System.Drawing.Size(129, 20)
            Me.SearchableComboBoxControl_VendorTaxCode.TabIndex = 28
            '
            'GridView1
            '
            Me.GridView1.AFActiveFilterString = ""
            Me.GridView1.AllowExtraItemsInGridLookupEdits = True
            Me.GridView1.AutoFilterLookupColumns = False
            Me.GridView1.AutoloadRepositoryDatasource = True
            Me.GridView1.DataSourceClearing = False
            Me.GridView1.EnableDisabledRows = False
            Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView1.Name = "GridView1"
            Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView1.OptionsView.ShowGroupPanel = False
            Me.GridView1.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridView1.RunStandardValidation = True
            '
            'LabelControl_Tax
            '
            Me.LabelControl_Tax.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_Tax.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_Tax.Location = New System.Drawing.Point(559, 106)
            Me.LabelControl_Tax.Name = "LabelControl_Tax"
            Me.LabelControl_Tax.Size = New System.Drawing.Size(63, 20)
            Me.LabelControl_Tax.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_Tax.TabIndex = 18
            Me.LabelControl_Tax.Text = "Tax:"
            '
            'NumericInputControl_SalesTax
            '
            Me.NumericInputControl_SalesTax.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputControl_SalesTax.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputControl_SalesTax.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputControl_SalesTax.EnterMoveNextControl = True
            Me.NumericInputControl_SalesTax.Location = New System.Drawing.Point(628, 106)
            Me.NumericInputControl_SalesTax.Name = "NumericInputControl_SalesTax"
            Me.NumericInputControl_SalesTax.Properties.AllowMouseWheel = False
            Me.NumericInputControl_SalesTax.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputControl_SalesTax.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputControl_SalesTax.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputControl_SalesTax.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputControl_SalesTax.Properties.EditFormat.FormatString = "f"
            Me.NumericInputControl_SalesTax.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputControl_SalesTax.Properties.Mask.EditMask = "f"
            Me.NumericInputControl_SalesTax.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputControl_SalesTax.SecurityEnabled = True
            Me.NumericInputControl_SalesTax.Size = New System.Drawing.Size(129, 20)
            Me.NumericInputControl_SalesTax.TabIndex = 19
            '
            'TextBoxControl_MessageDetails
            '
            Me.TextBoxControl_MessageDetails.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxControl_MessageDetails.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxControl_MessageDetails.Border.Class = "TextBoxBorder"
            Me.TextBoxControl_MessageDetails.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxControl_MessageDetails.CheckSpellingOnValidate = False
            Me.TextBoxControl_MessageDetails.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxControl_MessageDetails.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxControl_MessageDetails.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxControl_MessageDetails.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxControl_MessageDetails.FocusHighlightEnabled = True
            Me.TextBoxControl_MessageDetails.ForeColor = System.Drawing.Color.Black
            Me.TextBoxControl_MessageDetails.Location = New System.Drawing.Point(405, 314)
            Me.TextBoxControl_MessageDetails.MaxFileSize = CType(0, Long)
            Me.TextBoxControl_MessageDetails.Multiline = True
            Me.TextBoxControl_MessageDetails.Name = "TextBoxControl_MessageDetails"
            Me.TextBoxControl_MessageDetails.ReadOnly = True
            Me.TextBoxControl_MessageDetails.SecurityEnabled = True
            Me.TextBoxControl_MessageDetails.ShowSpellCheckCompleteMessage = True
            Me.TextBoxControl_MessageDetails.Size = New System.Drawing.Size(580, 31)
            Me.TextBoxControl_MessageDetails.StartingFolderName = Nothing
            Me.TextBoxControl_MessageDetails.TabIndex = 34
            Me.TextBoxControl_MessageDetails.TabOnEnter = True
            Me.TextBoxControl_MessageDetails.TabStop = False
            '
            'LabelControl_Message
            '
            Me.LabelControl_Message.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_Message.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_Message.Location = New System.Drawing.Point(318, 314)
            Me.LabelControl_Message.Name = "LabelControl_Message"
            Me.LabelControl_Message.Size = New System.Drawing.Size(81, 20)
            Me.LabelControl_Message.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_Message.TabIndex = 33
            Me.LabelControl_Message.Text = "Message:"
            '
            'TextBoxDropDownControl_Note
            '
            '
            '
            '
            Me.TextBoxDropDownControl_Note.BackgroundStyle.Class = "TextBoxBorder"
            Me.TextBoxDropDownControl_Note.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxDropDownControl_Note.ButtonDropDown.Visible = True
            Me.TextBoxDropDownControl_Note.DropDownControl = Me.TextBoxControl_VendorNote
            Me.TextBoxDropDownControl_Note.Location = New System.Drawing.Point(75, 293)
            Me.TextBoxDropDownControl_Note.Name = "TextBoxDropDownControl_Note"
            Me.TextBoxDropDownControl_Note.ReadOnly = True
            Me.TextBoxDropDownControl_Note.Size = New System.Drawing.Size(237, 20)
            Me.TextBoxDropDownControl_Note.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.TextBoxDropDownControl_Note.TabIndex = 44
            Me.TextBoxDropDownControl_Note.TabStop = False
            Me.TextBoxDropDownControl_Note.Text = ""
            '
            'TextBoxControl_VendorNote
            '
            Me.TextBoxControl_VendorNote.Location = New System.Drawing.Point(75, 215)
            Me.TextBoxControl_VendorNote.Multiline = True
            Me.TextBoxControl_VendorNote.Name = "TextBoxControl_VendorNote"
            Me.TextBoxControl_VendorNote.ReadOnly = True
            Me.TextBoxControl_VendorNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.TextBoxControl_VendorNote.Size = New System.Drawing.Size(237, 98)
            Me.TextBoxControl_VendorNote.TabIndex = 91
            Me.TextBoxControl_VendorNote.TabStop = False
            Me.TextBoxControl_VendorNote.Visible = False
            '
            'NumericInputInvoiceInformation_TotalPaidToVendor
            '
            Me.NumericInputInvoiceInformation_TotalPaidToVendor.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputInvoiceInformation_TotalPaidToVendor.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputInvoiceInformation_TotalPaidToVendor.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputInvoiceInformation_TotalPaidToVendor.EnterMoveNextControl = True
            Me.NumericInputInvoiceInformation_TotalPaidToVendor.Location = New System.Drawing.Point(864, 236)
            Me.NumericInputInvoiceInformation_TotalPaidToVendor.Name = "NumericInputInvoiceInformation_TotalPaidToVendor"
            Me.NumericInputInvoiceInformation_TotalPaidToVendor.Properties.AllowMouseWheel = False
            Me.NumericInputInvoiceInformation_TotalPaidToVendor.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control
            Me.NumericInputInvoiceInformation_TotalPaidToVendor.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputInvoiceInformation_TotalPaidToVendor.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputInvoiceInformation_TotalPaidToVendor.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputInvoiceInformation_TotalPaidToVendor.Properties.EditFormat.FormatString = "f"
            Me.NumericInputInvoiceInformation_TotalPaidToVendor.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputInvoiceInformation_TotalPaidToVendor.Properties.Mask.EditMask = "f"
            Me.NumericInputInvoiceInformation_TotalPaidToVendor.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputInvoiceInformation_TotalPaidToVendor.Properties.ReadOnly = True
            Me.NumericInputInvoiceInformation_TotalPaidToVendor.SecurityEnabled = True
            Me.NumericInputInvoiceInformation_TotalPaidToVendor.Size = New System.Drawing.Size(96, 20)
            Me.NumericInputInvoiceInformation_TotalPaidToVendor.TabIndex = 40
            Me.NumericInputInvoiceInformation_TotalPaidToVendor.TabStop = False
            '
            'LabelControl_TotalPaid
            '
            Me.LabelControl_TotalPaid.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_TotalPaid.BackgroundStyle.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelControl_TotalPaid.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelControl_TotalPaid.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelControl_TotalPaid.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelControl_TotalPaid.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelControl_TotalPaid.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_TotalPaid.Location = New System.Drawing.Point(763, 236)
            Me.LabelControl_TotalPaid.Name = "LabelControl_TotalPaid"
            Me.LabelControl_TotalPaid.Size = New System.Drawing.Size(95, 20)
            Me.LabelControl_TotalPaid.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_TotalPaid.TabIndex = 39
            Me.LabelControl_TotalPaid.Text = "Total Paid:"
            '
            'SearchableComboBoxControl_Vendor
            '
            Me.SearchableComboBoxControl_Vendor.ActiveFilterString = ""
            Me.SearchableComboBoxControl_Vendor.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxControl_Vendor.AutoFillMode = False
            Me.SearchableComboBoxControl_Vendor.BookmarkingEnabled = False
            Me.SearchableComboBoxControl_Vendor.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Vendor
            Me.SearchableComboBoxControl_Vendor.DataSource = Nothing
            Me.SearchableComboBoxControl_Vendor.DisableMouseWheel = True
            Me.SearchableComboBoxControl_Vendor.DisplayName = ""
            Me.SearchableComboBoxControl_Vendor.EnterMoveNextControl = True
            Me.SearchableComboBoxControl_Vendor.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxControl_Vendor.Location = New System.Drawing.Point(50, 28)
            Me.SearchableComboBoxControl_Vendor.Name = "SearchableComboBoxControl_Vendor"
            Me.SearchableComboBoxControl_Vendor.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxControl_Vendor.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxControl_Vendor.Properties.NullText = "Select Vendor"
            Me.SearchableComboBoxControl_Vendor.Properties.ShowClearButton = False
            Me.SearchableComboBoxControl_Vendor.Properties.ValueMember = "Code"
            Me.SearchableComboBoxControl_Vendor.Properties.View = Me.SearchableComboBoxViewControl_Vendor
            Me.SearchableComboBoxControl_Vendor.SecurityEnabled = True
            Me.SearchableComboBoxControl_Vendor.SelectedValue = Nothing
            Me.SearchableComboBoxControl_Vendor.Size = New System.Drawing.Size(262, 20)
            Me.SearchableComboBoxControl_Vendor.TabIndex = 1
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
            'TabControlControl_InvoiceDetails
            '
            Me.TabControlControl_InvoiceDetails.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlControl_InvoiceDetails.BackColor = System.Drawing.Color.White
            Me.TabControlControl_InvoiceDetails.CanReorderTabs = False
            Me.TabControlControl_InvoiceDetails.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlControl_InvoiceDetails.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlControl_InvoiceDetails.Controls.Add(Me.TabControlPanelDistributionTab_Distribution)
            Me.TabControlControl_InvoiceDetails.Controls.Add(Me.TabControlPanelTransactionsTab_Transactions)
            Me.TabControlControl_InvoiceDetails.Controls.Add(Me.TabControlPanelChecksWrittenTab_ChecksWritten)
            Me.TabControlControl_InvoiceDetails.ForeColor = System.Drawing.Color.Black
            Me.TabControlControl_InvoiceDetails.Location = New System.Drawing.Point(763, 26)
            Me.TabControlControl_InvoiceDetails.Name = "TabControlControl_InvoiceDetails"
            Me.TabControlControl_InvoiceDetails.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlControl_InvoiceDetails.SelectedTabIndex = 2
            Me.TabControlControl_InvoiceDetails.Size = New System.Drawing.Size(226, 178)
            Me.TabControlControl_InvoiceDetails.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlControl_InvoiceDetails.TabIndex = 46
            Me.TabControlControl_InvoiceDetails.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlControl_InvoiceDetails.Tabs.Add(Me.TabItemInvoiceDetails_DistributionTab)
            Me.TabControlControl_InvoiceDetails.Tabs.Add(Me.TabItemInvoiceDetails_TransactionsTab)
            Me.TabControlControl_InvoiceDetails.Tabs.Add(Me.TabItemInvoiceDetails_ChecksWrittenTab)
            Me.TabControlControl_InvoiceDetails.TabStop = False
            '
            'TabControlPanelDistributionTab_Distribution
            '
            Me.TabControlPanelDistributionTab_Distribution.Controls.Add(Me.NumericInputDistribution_ForeignTotal)
            Me.TabControlPanelDistributionTab_Distribution.Controls.Add(Me.LabelDistribution_ForeignTotal)
            Me.TabControlPanelDistributionTab_Distribution.Controls.Add(Me.NumericInputDistribution_Balance)
            Me.TabControlPanelDistributionTab_Distribution.Controls.Add(Me.LabelDistribution_BalanceToApply)
            Me.TabControlPanelDistributionTab_Distribution.Controls.Add(Me.NumericInputDistribution_NonClient)
            Me.TabControlPanelDistributionTab_Distribution.Controls.Add(Me.NumericInputDistribution_Clients)
            Me.TabControlPanelDistributionTab_Distribution.Controls.Add(Me.LabelDistribution_ClientTotal)
            Me.TabControlPanelDistributionTab_Distribution.Controls.Add(Me.LabelDistribution_NonClientTotal)
            Me.TabControlPanelDistributionTab_Distribution.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelDistributionTab_Distribution.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelDistributionTab_Distribution.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelDistributionTab_Distribution.Name = "TabControlPanelDistributionTab_Distribution"
            Me.TabControlPanelDistributionTab_Distribution.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelDistributionTab_Distribution.Size = New System.Drawing.Size(226, 151)
            Me.TabControlPanelDistributionTab_Distribution.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelDistributionTab_Distribution.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDistributionTab_Distribution.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelDistributionTab_Distribution.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelDistributionTab_Distribution.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelDistributionTab_Distribution.Style.GradientAngle = 90
            Me.TabControlPanelDistributionTab_Distribution.TabIndex = 0
            Me.TabControlPanelDistributionTab_Distribution.TabItem = Me.TabItemInvoiceDetails_DistributionTab
            '
            'NumericInputDistribution_ForeignTotal
            '
            Me.NumericInputDistribution_ForeignTotal.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputDistribution_ForeignTotal.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputDistribution_ForeignTotal.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputDistribution_ForeignTotal.EnterMoveNextControl = True
            Me.NumericInputDistribution_ForeignTotal.Location = New System.Drawing.Point(101, 82)
            Me.NumericInputDistribution_ForeignTotal.Name = "NumericInputDistribution_ForeignTotal"
            Me.NumericInputDistribution_ForeignTotal.Properties.AllowMouseWheel = False
            Me.NumericInputDistribution_ForeignTotal.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control
            Me.NumericInputDistribution_ForeignTotal.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputDistribution_ForeignTotal.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputDistribution_ForeignTotal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDistribution_ForeignTotal.Properties.EditFormat.FormatString = "f"
            Me.NumericInputDistribution_ForeignTotal.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDistribution_ForeignTotal.Properties.Mask.EditMask = "f"
            Me.NumericInputDistribution_ForeignTotal.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputDistribution_ForeignTotal.Properties.ReadOnly = True
            Me.NumericInputDistribution_ForeignTotal.SecurityEnabled = True
            Me.NumericInputDistribution_ForeignTotal.Size = New System.Drawing.Size(96, 20)
            Me.NumericInputDistribution_ForeignTotal.TabIndex = 7
            Me.NumericInputDistribution_ForeignTotal.TabStop = False
            '
            'LabelDistribution_ForeignTotal
            '
            Me.LabelDistribution_ForeignTotal.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDistribution_ForeignTotal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDistribution_ForeignTotal.Location = New System.Drawing.Point(4, 82)
            Me.LabelDistribution_ForeignTotal.Name = "LabelDistribution_ForeignTotal"
            Me.LabelDistribution_ForeignTotal.Size = New System.Drawing.Size(91, 20)
            Me.LabelDistribution_ForeignTotal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDistribution_ForeignTotal.TabIndex = 6
            Me.LabelDistribution_ForeignTotal.Text = "Foreign Total:"
            '
            'NumericInputDistribution_Balance
            '
            Me.NumericInputDistribution_Balance.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputDistribution_Balance.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputDistribution_Balance.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputDistribution_Balance.EnterMoveNextControl = True
            Me.NumericInputDistribution_Balance.Location = New System.Drawing.Point(101, 56)
            Me.NumericInputDistribution_Balance.Name = "NumericInputDistribution_Balance"
            Me.NumericInputDistribution_Balance.Properties.AllowMouseWheel = False
            Me.NumericInputDistribution_Balance.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control
            Me.NumericInputDistribution_Balance.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputDistribution_Balance.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputDistribution_Balance.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDistribution_Balance.Properties.EditFormat.FormatString = "f"
            Me.NumericInputDistribution_Balance.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDistribution_Balance.Properties.Mask.EditMask = "f"
            Me.NumericInputDistribution_Balance.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputDistribution_Balance.Properties.ReadOnly = True
            Me.NumericInputDistribution_Balance.SecurityEnabled = True
            Me.NumericInputDistribution_Balance.Size = New System.Drawing.Size(96, 20)
            Me.NumericInputDistribution_Balance.TabIndex = 5
            Me.NumericInputDistribution_Balance.TabStop = False
            '
            'LabelDistribution_BalanceToApply
            '
            Me.LabelDistribution_BalanceToApply.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDistribution_BalanceToApply.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDistribution_BalanceToApply.Location = New System.Drawing.Point(4, 56)
            Me.LabelDistribution_BalanceToApply.Name = "LabelDistribution_BalanceToApply"
            Me.LabelDistribution_BalanceToApply.Size = New System.Drawing.Size(91, 20)
            Me.LabelDistribution_BalanceToApply.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDistribution_BalanceToApply.TabIndex = 4
            Me.LabelDistribution_BalanceToApply.Text = "Balance to Apply:"
            '
            'NumericInputDistribution_NonClient
            '
            Me.NumericInputDistribution_NonClient.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputDistribution_NonClient.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputDistribution_NonClient.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputDistribution_NonClient.EnterMoveNextControl = True
            Me.NumericInputDistribution_NonClient.Location = New System.Drawing.Point(101, 30)
            Me.NumericInputDistribution_NonClient.Name = "NumericInputDistribution_NonClient"
            Me.NumericInputDistribution_NonClient.Properties.AllowMouseWheel = False
            Me.NumericInputDistribution_NonClient.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control
            Me.NumericInputDistribution_NonClient.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputDistribution_NonClient.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputDistribution_NonClient.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDistribution_NonClient.Properties.EditFormat.FormatString = "f"
            Me.NumericInputDistribution_NonClient.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDistribution_NonClient.Properties.Mask.EditMask = "f"
            Me.NumericInputDistribution_NonClient.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputDistribution_NonClient.Properties.ReadOnly = True
            Me.NumericInputDistribution_NonClient.SecurityEnabled = True
            Me.NumericInputDistribution_NonClient.Size = New System.Drawing.Size(96, 20)
            Me.NumericInputDistribution_NonClient.TabIndex = 3
            Me.NumericInputDistribution_NonClient.TabStop = False
            '
            'NumericInputDistribution_Clients
            '
            Me.NumericInputDistribution_Clients.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputDistribution_Clients.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputDistribution_Clients.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputDistribution_Clients.EnterMoveNextControl = True
            Me.NumericInputDistribution_Clients.Location = New System.Drawing.Point(101, 4)
            Me.NumericInputDistribution_Clients.Name = "NumericInputDistribution_Clients"
            Me.NumericInputDistribution_Clients.Properties.AllowMouseWheel = False
            Me.NumericInputDistribution_Clients.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control
            Me.NumericInputDistribution_Clients.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputDistribution_Clients.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputDistribution_Clients.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDistribution_Clients.Properties.EditFormat.FormatString = "f"
            Me.NumericInputDistribution_Clients.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDistribution_Clients.Properties.Mask.EditMask = "f"
            Me.NumericInputDistribution_Clients.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputDistribution_Clients.Properties.ReadOnly = True
            Me.NumericInputDistribution_Clients.SecurityEnabled = True
            Me.NumericInputDistribution_Clients.Size = New System.Drawing.Size(96, 20)
            Me.NumericInputDistribution_Clients.TabIndex = 1
            Me.NumericInputDistribution_Clients.TabStop = False
            '
            'LabelDistribution_ClientTotal
            '
            Me.LabelDistribution_ClientTotal.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDistribution_ClientTotal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDistribution_ClientTotal.Location = New System.Drawing.Point(4, 4)
            Me.LabelDistribution_ClientTotal.Name = "LabelDistribution_ClientTotal"
            Me.LabelDistribution_ClientTotal.Size = New System.Drawing.Size(91, 20)
            Me.LabelDistribution_ClientTotal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDistribution_ClientTotal.TabIndex = 0
            Me.LabelDistribution_ClientTotal.Text = "Client Total:"
            '
            'LabelDistribution_NonClientTotal
            '
            Me.LabelDistribution_NonClientTotal.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDistribution_NonClientTotal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDistribution_NonClientTotal.Location = New System.Drawing.Point(4, 30)
            Me.LabelDistribution_NonClientTotal.Name = "LabelDistribution_NonClientTotal"
            Me.LabelDistribution_NonClientTotal.Size = New System.Drawing.Size(91, 20)
            Me.LabelDistribution_NonClientTotal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDistribution_NonClientTotal.TabIndex = 2
            Me.LabelDistribution_NonClientTotal.Text = "Non Client Total:"
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
            Me.TabControlPanelTransactionsTab_Transactions.Size = New System.Drawing.Size(226, 151)
            Me.TabControlPanelTransactionsTab_Transactions.Style.BackColor1.Color = System.Drawing.Color.White
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
            Me.DataGridViewTransactions_GLTransactions.Size = New System.Drawing.Size(218, 143)
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
            'TabControlPanelChecksWrittenTab_ChecksWritten
            '
            Me.TabControlPanelChecksWrittenTab_ChecksWritten.Controls.Add(Me.DataGridViewChecksWritten_ChecksWritten)
            Me.TabControlPanelChecksWrittenTab_ChecksWritten.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelChecksWrittenTab_ChecksWritten.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelChecksWrittenTab_ChecksWritten.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelChecksWrittenTab_ChecksWritten.Name = "TabControlPanelChecksWrittenTab_ChecksWritten"
            Me.TabControlPanelChecksWrittenTab_ChecksWritten.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelChecksWrittenTab_ChecksWritten.Size = New System.Drawing.Size(226, 151)
            Me.TabControlPanelChecksWrittenTab_ChecksWritten.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelChecksWrittenTab_ChecksWritten.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelChecksWrittenTab_ChecksWritten.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelChecksWrittenTab_ChecksWritten.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelChecksWrittenTab_ChecksWritten.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelChecksWrittenTab_ChecksWritten.Style.GradientAngle = 90
            Me.TabControlPanelChecksWrittenTab_ChecksWritten.TabIndex = 3
            Me.TabControlPanelChecksWrittenTab_ChecksWritten.TabItem = Me.TabItemInvoiceDetails_ChecksWrittenTab
            '
            'DataGridViewChecksWritten_ChecksWritten
            '
            Me.DataGridViewChecksWritten_ChecksWritten.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewChecksWritten_ChecksWritten.AllowDragAndDrop = False
            Me.DataGridViewChecksWritten_ChecksWritten.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewChecksWritten_ChecksWritten.AllowSelectGroupHeaderRow = True
            Me.DataGridViewChecksWritten_ChecksWritten.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewChecksWritten_ChecksWritten.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewChecksWritten_ChecksWritten.AutoFilterLookupColumns = False
            Me.DataGridViewChecksWritten_ChecksWritten.AutoloadRepositoryDatasource = True
            Me.DataGridViewChecksWritten_ChecksWritten.AutoUpdateViewCaption = True
            Me.DataGridViewChecksWritten_ChecksWritten.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewChecksWritten_ChecksWritten.DataSource = Nothing
            Me.DataGridViewChecksWritten_ChecksWritten.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewChecksWritten_ChecksWritten.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewChecksWritten_ChecksWritten.ItemDescription = "Check(s) Written"
            Me.DataGridViewChecksWritten_ChecksWritten.Location = New System.Drawing.Point(4, 4)
            Me.DataGridViewChecksWritten_ChecksWritten.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewChecksWritten_ChecksWritten.MultiSelect = False
            Me.DataGridViewChecksWritten_ChecksWritten.Name = "DataGridViewChecksWritten_ChecksWritten"
            Me.DataGridViewChecksWritten_ChecksWritten.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewChecksWritten_ChecksWritten.RunStandardValidation = True
            Me.DataGridViewChecksWritten_ChecksWritten.ShowColumnMenuOnRightClick = False
            Me.DataGridViewChecksWritten_ChecksWritten.ShowSelectDeselectAllButtons = False
            Me.DataGridViewChecksWritten_ChecksWritten.Size = New System.Drawing.Size(218, 143)
            Me.DataGridViewChecksWritten_ChecksWritten.TabIndex = 14
            Me.DataGridViewChecksWritten_ChecksWritten.TabStop = False
            Me.DataGridViewChecksWritten_ChecksWritten.UseEmbeddedNavigator = False
            Me.DataGridViewChecksWritten_ChecksWritten.ViewCaptionHeight = -1
            '
            'TabItemInvoiceDetails_ChecksWrittenTab
            '
            Me.TabItemInvoiceDetails_ChecksWrittenTab.AttachedControl = Me.TabControlPanelChecksWrittenTab_ChecksWritten
            Me.TabItemInvoiceDetails_ChecksWrittenTab.Name = "TabItemInvoiceDetails_ChecksWrittenTab"
            Me.TabItemInvoiceDetails_ChecksWrittenTab.Text = "Checks Written"
            '
            'LabelControl_TotalDue
            '
            Me.LabelControl_TotalDue.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_TotalDue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_TotalDue.Location = New System.Drawing.Point(559, 184)
            Me.LabelControl_TotalDue.Name = "LabelControl_TotalDue"
            Me.LabelControl_TotalDue.Size = New System.Drawing.Size(63, 20)
            Me.LabelControl_TotalDue.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_TotalDue.TabIndex = 25
            Me.LabelControl_TotalDue.Text = "Total Due:"
            '
            'NumericInputControl_DiscountPercentage
            '
            Me.NumericInputControl_DiscountPercentage.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputControl_DiscountPercentage.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputControl_DiscountPercentage.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputControl_DiscountPercentage.EnterMoveNextControl = True
            Me.NumericInputControl_DiscountPercentage.Location = New System.Drawing.Point(628, 158)
            Me.NumericInputControl_DiscountPercentage.Name = "NumericInputControl_DiscountPercentage"
            Me.NumericInputControl_DiscountPercentage.Properties.AllowMouseWheel = False
            Me.NumericInputControl_DiscountPercentage.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputControl_DiscountPercentage.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputControl_DiscountPercentage.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
            Me.NumericInputControl_DiscountPercentage.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputControl_DiscountPercentage.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputControl_DiscountPercentage.Properties.EditFormat.FormatString = "f"
            Me.NumericInputControl_DiscountPercentage.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputControl_DiscountPercentage.Properties.Mask.EditMask = "f"
            Me.NumericInputControl_DiscountPercentage.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputControl_DiscountPercentage.SecurityEnabled = True
            Me.NumericInputControl_DiscountPercentage.Size = New System.Drawing.Size(58, 20)
            Me.NumericInputControl_DiscountPercentage.TabIndex = 23
            '
            'NumericInputControl_Discount
            '
            Me.NumericInputControl_Discount.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputControl_Discount.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputControl_Discount.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputControl_Discount.EnterMoveNextControl = True
            Me.NumericInputControl_Discount.Location = New System.Drawing.Point(692, 158)
            Me.NumericInputControl_Discount.Name = "NumericInputControl_Discount"
            Me.NumericInputControl_Discount.Properties.AllowMouseWheel = False
            Me.NumericInputControl_Discount.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputControl_Discount.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputControl_Discount.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputControl_Discount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputControl_Discount.Properties.EditFormat.FormatString = "f"
            Me.NumericInputControl_Discount.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputControl_Discount.Properties.Mask.EditMask = "f"
            Me.NumericInputControl_Discount.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputControl_Discount.SecurityEnabled = True
            Me.NumericInputControl_Discount.Size = New System.Drawing.Size(65, 20)
            Me.NumericInputControl_Discount.TabIndex = 24
            '
            'LabelControl_DiscountPercentage
            '
            Me.LabelControl_DiscountPercentage.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_DiscountPercentage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_DiscountPercentage.Location = New System.Drawing.Point(559, 158)
            Me.LabelControl_DiscountPercentage.Name = "LabelControl_DiscountPercentage"
            Me.LabelControl_DiscountPercentage.Size = New System.Drawing.Size(63, 20)
            Me.LabelControl_DiscountPercentage.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_DiscountPercentage.TabIndex = 22
            Me.LabelControl_DiscountPercentage.Text = "Discount %:"
            '
            'NumericInputControl_InvoiceTotal
            '
            Me.NumericInputControl_InvoiceTotal.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputControl_InvoiceTotal.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputControl_InvoiceTotal.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputControl_InvoiceTotal.EnterMoveNextControl = True
            Me.NumericInputControl_InvoiceTotal.Location = New System.Drawing.Point(628, 132)
            Me.NumericInputControl_InvoiceTotal.Name = "NumericInputControl_InvoiceTotal"
            Me.NumericInputControl_InvoiceTotal.Properties.AllowMouseWheel = False
            Me.NumericInputControl_InvoiceTotal.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control
            Me.NumericInputControl_InvoiceTotal.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputControl_InvoiceTotal.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputControl_InvoiceTotal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputControl_InvoiceTotal.Properties.EditFormat.FormatString = "f"
            Me.NumericInputControl_InvoiceTotal.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputControl_InvoiceTotal.Properties.Mask.EditMask = "f"
            Me.NumericInputControl_InvoiceTotal.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputControl_InvoiceTotal.Properties.ReadOnly = True
            Me.NumericInputControl_InvoiceTotal.SecurityEnabled = True
            Me.NumericInputControl_InvoiceTotal.Size = New System.Drawing.Size(129, 20)
            Me.NumericInputControl_InvoiceTotal.TabIndex = 21
            Me.NumericInputControl_InvoiceTotal.TabStop = False
            '
            'LabelControl_Currency
            '
            Me.LabelControl_Currency.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_Currency.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_Currency.Location = New System.Drawing.Point(318, 210)
            Me.LabelControl_Currency.Name = "LabelControl_Currency"
            Me.LabelControl_Currency.Size = New System.Drawing.Size(55, 20)
            Me.LabelControl_Currency.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_Currency.TabIndex = 41
            Me.LabelControl_Currency.Text = "Currency:"
            '
            'LabelControl_InvoiceTotal
            '
            Me.LabelControl_InvoiceTotal.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_InvoiceTotal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_InvoiceTotal.Location = New System.Drawing.Point(559, 132)
            Me.LabelControl_InvoiceTotal.Name = "LabelControl_InvoiceTotal"
            Me.LabelControl_InvoiceTotal.Size = New System.Drawing.Size(63, 20)
            Me.LabelControl_InvoiceTotal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_InvoiceTotal.TabIndex = 20
            Me.LabelControl_InvoiceTotal.Text = "Total:"
            '
            'ComboBoxControl_PostPeriodForMod
            '
            Me.ComboBoxControl_PostPeriodForMod.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxControl_PostPeriodForMod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxControl_PostPeriodForMod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxControl_PostPeriodForMod.AutoFindItemInDataSource = False
            Me.ComboBoxControl_PostPeriodForMod.AutoSelectSingleItemDatasource = False
            Me.ComboBoxControl_PostPeriodForMod.BookmarkingEnabled = False
            Me.ComboBoxControl_PostPeriodForMod.ClientCode = ""
            Me.ComboBoxControl_PostPeriodForMod.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.PostPeriod
            Me.ComboBoxControl_PostPeriodForMod.DisableMouseWheel = True
            Me.ComboBoxControl_PostPeriodForMod.DisplayMember = "Description"
            Me.ComboBoxControl_PostPeriodForMod.DisplayName = ""
            Me.ComboBoxControl_PostPeriodForMod.DivisionCode = ""
            Me.ComboBoxControl_PostPeriodForMod.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxControl_PostPeriodForMod.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxControl_PostPeriodForMod.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxControl_PostPeriodForMod.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxControl_PostPeriodForMod.FocusHighlightEnabled = True
            Me.ComboBoxControl_PostPeriodForMod.FormattingEnabled = True
            Me.ComboBoxControl_PostPeriodForMod.ItemHeight = 14
            Me.ComboBoxControl_PostPeriodForMod.Location = New System.Drawing.Point(405, 184)
            Me.ComboBoxControl_PostPeriodForMod.Name = "ComboBoxControl_PostPeriodForMod"
            Me.ComboBoxControl_PostPeriodForMod.ReadOnly = False
            Me.ComboBoxControl_PostPeriodForMod.SecurityEnabled = True
            Me.ComboBoxControl_PostPeriodForMod.Size = New System.Drawing.Size(148, 20)
            Me.ComboBoxControl_PostPeriodForMod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxControl_PostPeriodForMod.TabIndex = 15
            Me.ComboBoxControl_PostPeriodForMod.TabOnEnter = True
            Me.ComboBoxControl_PostPeriodForMod.ValueMember = "Code"
            Me.ComboBoxControl_PostPeriodForMod.WatermarkText = "Select Post Period"
            '
            'DateTimePickerControl_InvoiceDate
            '
            Me.DateTimePickerControl_InvoiceDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerControl_InvoiceDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerControl_InvoiceDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerControl_InvoiceDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerControl_InvoiceDate.ButtonDropDown.Visible = True
            Me.DateTimePickerControl_InvoiceDate.ButtonFreeText.Checked = True
            Me.DateTimePickerControl_InvoiceDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerControl_InvoiceDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerControl_InvoiceDate.DisplayName = ""
            Me.DateTimePickerControl_InvoiceDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerControl_InvoiceDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerControl_InvoiceDate.FocusHighlightEnabled = True
            Me.DateTimePickerControl_InvoiceDate.FreeTextEntryMode = True
            Me.DateTimePickerControl_InvoiceDate.IsPopupCalendarOpen = False
            Me.DateTimePickerControl_InvoiceDate.Location = New System.Drawing.Point(405, 106)
            Me.DateTimePickerControl_InvoiceDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerControl_InvoiceDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerControl_InvoiceDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerControl_InvoiceDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerControl_InvoiceDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerControl_InvoiceDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerControl_InvoiceDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerControl_InvoiceDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerControl_InvoiceDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerControl_InvoiceDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerControl_InvoiceDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerControl_InvoiceDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerControl_InvoiceDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerControl_InvoiceDate.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerControl_InvoiceDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerControl_InvoiceDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerControl_InvoiceDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerControl_InvoiceDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerControl_InvoiceDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerControl_InvoiceDate.Name = "DateTimePickerControl_InvoiceDate"
            Me.DateTimePickerControl_InvoiceDate.ReadOnly = False
            Me.DateTimePickerControl_InvoiceDate.Size = New System.Drawing.Size(97, 20)
            Me.DateTimePickerControl_InvoiceDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerControl_InvoiceDate.TabIndex = 9
            Me.DateTimePickerControl_InvoiceDate.TabOnEnter = True
            Me.DateTimePickerControl_InvoiceDate.Value = New Date(2013, 7, 23, 13, 58, 57, 288)
            '
            'ComboBoxControl_Terms
            '
            Me.ComboBoxControl_Terms.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxControl_Terms.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxControl_Terms.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxControl_Terms.AutoFindItemInDataSource = False
            Me.ComboBoxControl_Terms.AutoSelectSingleItemDatasource = False
            Me.ComboBoxControl_Terms.BookmarkingEnabled = False
            Me.ComboBoxControl_Terms.ClientCode = ""
            Me.ComboBoxControl_Terms.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.VendorTerm
            Me.ComboBoxControl_Terms.DisableMouseWheel = True
            Me.ComboBoxControl_Terms.DisplayMember = "Description"
            Me.ComboBoxControl_Terms.DisplayName = ""
            Me.ComboBoxControl_Terms.DivisionCode = ""
            Me.ComboBoxControl_Terms.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxControl_Terms.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxControl_Terms.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxControl_Terms.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxControl_Terms.FocusHighlightEnabled = True
            Me.ComboBoxControl_Terms.FormattingEnabled = True
            Me.ComboBoxControl_Terms.ItemHeight = 14
            Me.ComboBoxControl_Terms.Location = New System.Drawing.Point(405, 262)
            Me.ComboBoxControl_Terms.Name = "ComboBoxControl_Terms"
            Me.ComboBoxControl_Terms.ReadOnly = False
            Me.ComboBoxControl_Terms.SecurityEnabled = True
            Me.ComboBoxControl_Terms.Size = New System.Drawing.Size(148, 20)
            Me.ComboBoxControl_Terms.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxControl_Terms.TabIndex = 31
            Me.ComboBoxControl_Terms.TabOnEnter = True
            Me.ComboBoxControl_Terms.ValueMember = "Code"
            Me.ComboBoxControl_Terms.WatermarkText = "Select Term"
            '
            'LabelControl_Note
            '
            Me.LabelControl_Note.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_Note.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_Note.Location = New System.Drawing.Point(3, 293)
            Me.LabelControl_Note.Name = "LabelControl_Note"
            Me.LabelControl_Note.Size = New System.Drawing.Size(66, 20)
            Me.LabelControl_Note.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_Note.TabIndex = 43
            Me.LabelControl_Note.Text = "Note:"
            '
            'LabelControl_PostingPeriodForMod
            '
            Me.LabelControl_PostingPeriodForMod.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_PostingPeriodForMod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_PostingPeriodForMod.Location = New System.Drawing.Point(318, 184)
            Me.LabelControl_PostingPeriodForMod.Name = "LabelControl_PostingPeriodForMod"
            Me.LabelControl_PostingPeriodForMod.Size = New System.Drawing.Size(81, 20)
            Me.LabelControl_PostingPeriodForMod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_PostingPeriodForMod.TabIndex = 14
            Me.LabelControl_PostingPeriodForMod.Text = "P/P for Mod:"
            '
            'DateTimePickerControl_DateToPay
            '
            Me.DateTimePickerControl_DateToPay.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerControl_DateToPay.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerControl_DateToPay.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerControl_DateToPay.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerControl_DateToPay.ButtonDropDown.Visible = True
            Me.DateTimePickerControl_DateToPay.ButtonFreeText.Checked = True
            Me.DateTimePickerControl_DateToPay.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerControl_DateToPay.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerControl_DateToPay.DisplayName = ""
            Me.DateTimePickerControl_DateToPay.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerControl_DateToPay.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerControl_DateToPay.FocusHighlightEnabled = True
            Me.DateTimePickerControl_DateToPay.FreeTextEntryMode = True
            Me.DateTimePickerControl_DateToPay.IsPopupCalendarOpen = False
            Me.DateTimePickerControl_DateToPay.Location = New System.Drawing.Point(405, 132)
            Me.DateTimePickerControl_DateToPay.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerControl_DateToPay.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerControl_DateToPay.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerControl_DateToPay.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerControl_DateToPay.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerControl_DateToPay.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerControl_DateToPay.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerControl_DateToPay.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerControl_DateToPay.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerControl_DateToPay.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerControl_DateToPay.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerControl_DateToPay.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerControl_DateToPay.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerControl_DateToPay.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerControl_DateToPay.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerControl_DateToPay.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerControl_DateToPay.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerControl_DateToPay.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerControl_DateToPay.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerControl_DateToPay.Name = "DateTimePickerControl_DateToPay"
            Me.DateTimePickerControl_DateToPay.ReadOnly = False
            Me.DateTimePickerControl_DateToPay.Size = New System.Drawing.Size(97, 20)
            Me.DateTimePickerControl_DateToPay.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerControl_DateToPay.TabIndex = 11
            Me.DateTimePickerControl_DateToPay.TabOnEnter = True
            Me.DateTimePickerControl_DateToPay.Value = New Date(2013, 7, 23, 13, 58, 57, 313)
            '
            'ComboBoxControl_APAccount
            '
            Me.ComboBoxControl_APAccount.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxControl_APAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxControl_APAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxControl_APAccount.AutoFindItemInDataSource = False
            Me.ComboBoxControl_APAccount.AutoSelectSingleItemDatasource = False
            Me.ComboBoxControl_APAccount.BookmarkingEnabled = False
            Me.ComboBoxControl_APAccount.ClientCode = ""
            Me.ComboBoxControl_APAccount.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.GeneralLedgerAccount
            Me.ComboBoxControl_APAccount.DisableMouseWheel = True
            Me.ComboBoxControl_APAccount.DisplayMember = "Description"
            Me.ComboBoxControl_APAccount.DisplayName = ""
            Me.ComboBoxControl_APAccount.DivisionCode = ""
            Me.ComboBoxControl_APAccount.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxControl_APAccount.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxControl_APAccount.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxControl_APAccount.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxControl_APAccount.FocusHighlightEnabled = True
            Me.ComboBoxControl_APAccount.FormattingEnabled = True
            Me.ComboBoxControl_APAccount.ItemHeight = 14
            Me.ComboBoxControl_APAccount.Location = New System.Drawing.Point(405, 288)
            Me.ComboBoxControl_APAccount.Name = "ComboBoxControl_APAccount"
            Me.ComboBoxControl_APAccount.ReadOnly = False
            Me.ComboBoxControl_APAccount.SecurityEnabled = True
            Me.ComboBoxControl_APAccount.Size = New System.Drawing.Size(148, 20)
            Me.ComboBoxControl_APAccount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxControl_APAccount.TabIndex = 32
            Me.ComboBoxControl_APAccount.TabOnEnter = True
            Me.ComboBoxControl_APAccount.ValueMember = "Code"
            Me.ComboBoxControl_APAccount.WatermarkText = "Select General Ledger Account"
            '
            'LabelControl_InvoiceDate
            '
            Me.LabelControl_InvoiceDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_InvoiceDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_InvoiceDate.Location = New System.Drawing.Point(318, 106)
            Me.LabelControl_InvoiceDate.Name = "LabelControl_InvoiceDate"
            Me.LabelControl_InvoiceDate.Size = New System.Drawing.Size(81, 20)
            Me.LabelControl_InvoiceDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_InvoiceDate.TabIndex = 8
            Me.LabelControl_InvoiceDate.Text = "Invoice Date:"
            '
            'ComboBoxControl_Office
            '
            Me.ComboBoxControl_Office.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxControl_Office.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxControl_Office.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxControl_Office.AutoFindItemInDataSource = False
            Me.ComboBoxControl_Office.AutoSelectSingleItemDatasource = False
            Me.ComboBoxControl_Office.BookmarkingEnabled = False
            Me.ComboBoxControl_Office.ClientCode = ""
            Me.ComboBoxControl_Office.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Office
            Me.ComboBoxControl_Office.DisableMouseWheel = True
            Me.ComboBoxControl_Office.DisplayMember = "Name"
            Me.ComboBoxControl_Office.DisplayName = ""
            Me.ComboBoxControl_Office.DivisionCode = ""
            Me.ComboBoxControl_Office.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxControl_Office.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxControl_Office.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxControl_Office.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxControl_Office.FocusHighlightEnabled = True
            Me.ComboBoxControl_Office.FormattingEnabled = True
            Me.ComboBoxControl_Office.ItemHeight = 14
            Me.ComboBoxControl_Office.Location = New System.Drawing.Point(405, 236)
            Me.ComboBoxControl_Office.Name = "ComboBoxControl_Office"
            Me.ComboBoxControl_Office.ReadOnly = False
            Me.ComboBoxControl_Office.SecurityEnabled = True
            Me.ComboBoxControl_Office.Size = New System.Drawing.Size(148, 20)
            Me.ComboBoxControl_Office.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxControl_Office.TabIndex = 30
            Me.ComboBoxControl_Office.TabOnEnter = True
            Me.ComboBoxControl_Office.ValueMember = "Code"
            Me.ComboBoxControl_Office.WatermarkText = "Select Office"
            '
            'ComboBoxControl_PostPeriod
            '
            Me.ComboBoxControl_PostPeriod.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxControl_PostPeriod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxControl_PostPeriod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxControl_PostPeriod.AutoFindItemInDataSource = False
            Me.ComboBoxControl_PostPeriod.AutoSelectSingleItemDatasource = False
            Me.ComboBoxControl_PostPeriod.BookmarkingEnabled = False
            Me.ComboBoxControl_PostPeriod.ClientCode = ""
            Me.ComboBoxControl_PostPeriod.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.PostPeriod
            Me.ComboBoxControl_PostPeriod.DisableMouseWheel = True
            Me.ComboBoxControl_PostPeriod.DisplayMember = "Description"
            Me.ComboBoxControl_PostPeriod.DisplayName = ""
            Me.ComboBoxControl_PostPeriod.DivisionCode = ""
            Me.ComboBoxControl_PostPeriod.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxControl_PostPeriod.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxControl_PostPeriod.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxControl_PostPeriod.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxControl_PostPeriod.FocusHighlightEnabled = True
            Me.ComboBoxControl_PostPeriod.FormattingEnabled = True
            Me.ComboBoxControl_PostPeriod.ItemHeight = 14
            Me.ComboBoxControl_PostPeriod.Location = New System.Drawing.Point(405, 158)
            Me.ComboBoxControl_PostPeriod.Name = "ComboBoxControl_PostPeriod"
            Me.ComboBoxControl_PostPeriod.ReadOnly = False
            Me.ComboBoxControl_PostPeriod.SecurityEnabled = True
            Me.ComboBoxControl_PostPeriod.Size = New System.Drawing.Size(148, 20)
            Me.ComboBoxControl_PostPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxControl_PostPeriod.TabIndex = 13
            Me.ComboBoxControl_PostPeriod.TabOnEnter = True
            Me.ComboBoxControl_PostPeriod.ValueMember = "Code"
            Me.ComboBoxControl_PostPeriod.WatermarkText = "Select Post Period"
            '
            'LabelControl_Terms
            '
            Me.LabelControl_Terms.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_Terms.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_Terms.Location = New System.Drawing.Point(318, 262)
            Me.LabelControl_Terms.Name = "LabelControl_Terms"
            Me.LabelControl_Terms.Size = New System.Drawing.Size(81, 20)
            Me.LabelControl_Terms.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_Terms.TabIndex = 29
            Me.LabelControl_Terms.Text = "Terms:"
            '
            'NumericInputControl_InvoiceAmount
            '
            Me.NumericInputControl_InvoiceAmount.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputControl_InvoiceAmount.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputControl_InvoiceAmount.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputControl_InvoiceAmount.EnterMoveNextControl = True
            Me.NumericInputControl_InvoiceAmount.Location = New System.Drawing.Point(628, 80)
            Me.NumericInputControl_InvoiceAmount.Name = "NumericInputControl_InvoiceAmount"
            Me.NumericInputControl_InvoiceAmount.Properties.AllowMouseWheel = False
            Me.NumericInputControl_InvoiceAmount.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputControl_InvoiceAmount.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputControl_InvoiceAmount.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputControl_InvoiceAmount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputControl_InvoiceAmount.Properties.EditFormat.FormatString = "f"
            Me.NumericInputControl_InvoiceAmount.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputControl_InvoiceAmount.Properties.Mask.EditMask = "f"
            Me.NumericInputControl_InvoiceAmount.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputControl_InvoiceAmount.SecurityEnabled = True
            Me.NumericInputControl_InvoiceAmount.Size = New System.Drawing.Size(129, 20)
            Me.NumericInputControl_InvoiceAmount.TabIndex = 17
            '
            'LabelControl_Office
            '
            Me.LabelControl_Office.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_Office.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_Office.Location = New System.Drawing.Point(318, 236)
            Me.LabelControl_Office.Name = "LabelControl_Office"
            Me.LabelControl_Office.Size = New System.Drawing.Size(81, 20)
            Me.LabelControl_Office.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_Office.TabIndex = 27
            Me.LabelControl_Office.Text = "Office:"
            '
            'LabelControl_DateToPay
            '
            Me.LabelControl_DateToPay.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_DateToPay.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_DateToPay.Location = New System.Drawing.Point(318, 132)
            Me.LabelControl_DateToPay.Name = "LabelControl_DateToPay"
            Me.LabelControl_DateToPay.Size = New System.Drawing.Size(81, 20)
            Me.LabelControl_DateToPay.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_DateToPay.TabIndex = 10
            Me.LabelControl_DateToPay.Text = "Date to Pay:"
            '
            'LabelControl_APAccount
            '
            Me.LabelControl_APAccount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_APAccount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_APAccount.Location = New System.Drawing.Point(318, 288)
            Me.LabelControl_APAccount.Name = "LabelControl_APAccount"
            Me.LabelControl_APAccount.Size = New System.Drawing.Size(81, 20)
            Me.LabelControl_APAccount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_APAccount.TabIndex = 31
            Me.LabelControl_APAccount.Text = "GL Account:"
            '
            'DateTimePickerControl_EntryDate
            '
            Me.DateTimePickerControl_EntryDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerControl_EntryDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerControl_EntryDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerControl_EntryDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerControl_EntryDate.ButtonDropDown.Visible = True
            Me.DateTimePickerControl_EntryDate.ButtonFreeText.Checked = True
            Me.DateTimePickerControl_EntryDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerControl_EntryDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerControl_EntryDate.DisplayName = ""
            Me.DateTimePickerControl_EntryDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerControl_EntryDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerControl_EntryDate.FocusHighlightEnabled = True
            Me.DateTimePickerControl_EntryDate.FreeTextEntryMode = True
            Me.DateTimePickerControl_EntryDate.IsPopupCalendarOpen = False
            Me.DateTimePickerControl_EntryDate.Location = New System.Drawing.Point(405, 80)
            Me.DateTimePickerControl_EntryDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerControl_EntryDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerControl_EntryDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerControl_EntryDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerControl_EntryDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerControl_EntryDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerControl_EntryDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerControl_EntryDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerControl_EntryDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerControl_EntryDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerControl_EntryDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerControl_EntryDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerControl_EntryDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerControl_EntryDate.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerControl_EntryDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerControl_EntryDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerControl_EntryDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerControl_EntryDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerControl_EntryDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerControl_EntryDate.Name = "DateTimePickerControl_EntryDate"
            Me.DateTimePickerControl_EntryDate.ReadOnly = False
            Me.DateTimePickerControl_EntryDate.Size = New System.Drawing.Size(97, 20)
            Me.DateTimePickerControl_EntryDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerControl_EntryDate.TabIndex = 7
            Me.DateTimePickerControl_EntryDate.TabOnEnter = True
            Me.DateTimePickerControl_EntryDate.Value = New Date(2013, 7, 23, 13, 58, 57, 366)
            '
            'CheckBoxControl_OnHold
            '
            Me.CheckBoxControl_OnHold.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxControl_OnHold.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxControl_OnHold.CheckValue = 0
            Me.CheckBoxControl_OnHold.CheckValueChecked = 1
            Me.CheckBoxControl_OnHold.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxControl_OnHold.CheckValueUnchecked = 0
            Me.CheckBoxControl_OnHold.ChildControls = Nothing
            Me.CheckBoxControl_OnHold.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxControl_OnHold.Location = New System.Drawing.Point(763, 262)
            Me.CheckBoxControl_OnHold.Name = "CheckBoxControl_OnHold"
            Me.CheckBoxControl_OnHold.OldestSibling = Nothing
            Me.CheckBoxControl_OnHold.SecurityEnabled = True
            Me.CheckBoxControl_OnHold.SiblingControls = Nothing
            Me.CheckBoxControl_OnHold.Size = New System.Drawing.Size(72, 20)
            Me.CheckBoxControl_OnHold.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxControl_OnHold.TabIndex = 28
            Me.CheckBoxControl_OnHold.TabOnEnter = True
            Me.CheckBoxControl_OnHold.Text = "On Hold"
            '
            'CheckBoxControl_1099Invoice
            '
            Me.CheckBoxControl_1099Invoice.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxControl_1099Invoice.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxControl_1099Invoice.CheckValue = 0
            Me.CheckBoxControl_1099Invoice.CheckValueChecked = 1
            Me.CheckBoxControl_1099Invoice.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxControl_1099Invoice.CheckValueUnchecked = 0
            Me.CheckBoxControl_1099Invoice.ChildControls = Nothing
            Me.CheckBoxControl_1099Invoice.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxControl_1099Invoice.Location = New System.Drawing.Point(864, 262)
            Me.CheckBoxControl_1099Invoice.Name = "CheckBoxControl_1099Invoice"
            Me.CheckBoxControl_1099Invoice.OldestSibling = Nothing
            Me.CheckBoxControl_1099Invoice.SecurityEnabled = True
            Me.CheckBoxControl_1099Invoice.SiblingControls = Nothing
            Me.CheckBoxControl_1099Invoice.Size = New System.Drawing.Size(89, 20)
            Me.CheckBoxControl_1099Invoice.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxControl_1099Invoice.TabIndex = 29
            Me.CheckBoxControl_1099Invoice.TabOnEnter = True
            Me.CheckBoxControl_1099Invoice.Text = "1099 Invoice"
            '
            'LabelControl_EntryDate
            '
            Me.LabelControl_EntryDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_EntryDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_EntryDate.Location = New System.Drawing.Point(318, 80)
            Me.LabelControl_EntryDate.Name = "LabelControl_EntryDate"
            Me.LabelControl_EntryDate.Size = New System.Drawing.Size(81, 20)
            Me.LabelControl_EntryDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_EntryDate.TabIndex = 6
            Me.LabelControl_EntryDate.Text = "Entry Date:"
            '
            'TextBoxControl_Description
            '
            Me.TextBoxControl_Description.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxControl_Description.Border.Class = "TextBoxBorder"
            Me.TextBoxControl_Description.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxControl_Description.CheckSpellingOnValidate = False
            Me.TextBoxControl_Description.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxControl_Description.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxControl_Description.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxControl_Description.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxControl_Description.FocusHighlightEnabled = True
            Me.TextBoxControl_Description.ForeColor = System.Drawing.Color.Black
            Me.TextBoxControl_Description.Location = New System.Drawing.Point(405, 54)
            Me.TextBoxControl_Description.MaxFileSize = CType(0, Long)
            Me.TextBoxControl_Description.Name = "TextBoxControl_Description"
            Me.TextBoxControl_Description.SecurityEnabled = True
            Me.TextBoxControl_Description.ShowSpellCheckCompleteMessage = True
            Me.TextBoxControl_Description.Size = New System.Drawing.Size(352, 20)
            Me.TextBoxControl_Description.StartingFolderName = Nothing
            Me.TextBoxControl_Description.TabIndex = 5
            Me.TextBoxControl_Description.TabOnEnter = True
            '
            'LabelControl_InvoiceAmount
            '
            Me.LabelControl_InvoiceAmount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_InvoiceAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_InvoiceAmount.Location = New System.Drawing.Point(559, 80)
            Me.LabelControl_InvoiceAmount.Name = "LabelControl_InvoiceAmount"
            Me.LabelControl_InvoiceAmount.Size = New System.Drawing.Size(63, 20)
            Me.LabelControl_InvoiceAmount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_InvoiceAmount.TabIndex = 16
            Me.LabelControl_InvoiceAmount.Text = "Amount:"
            '
            'LabelControl_Description
            '
            Me.LabelControl_Description.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_Description.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_Description.Location = New System.Drawing.Point(318, 54)
            Me.LabelControl_Description.Name = "LabelControl_Description"
            Me.LabelControl_Description.Size = New System.Drawing.Size(81, 20)
            Me.LabelControl_Description.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_Description.TabIndex = 4
            Me.LabelControl_Description.Text = "Description:"
            '
            'LabelControl_InvoiceNumber
            '
            Me.LabelControl_InvoiceNumber.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_InvoiceNumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_InvoiceNumber.Location = New System.Drawing.Point(318, 28)
            Me.LabelControl_InvoiceNumber.Name = "LabelControl_InvoiceNumber"
            Me.LabelControl_InvoiceNumber.Size = New System.Drawing.Size(81, 20)
            Me.LabelControl_InvoiceNumber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_InvoiceNumber.TabIndex = 2
            Me.LabelControl_InvoiceNumber.Text = "Invoice Number:"
            '
            'LabelControl_Vendor
            '
            Me.LabelControl_Vendor.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_Vendor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_Vendor.Location = New System.Drawing.Point(3, 28)
            Me.LabelControl_Vendor.Name = "LabelControl_Vendor"
            Me.LabelControl_Vendor.Size = New System.Drawing.Size(41, 20)
            Me.LabelControl_Vendor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_Vendor.TabIndex = 0
            Me.LabelControl_Vendor.Text = "Vendor:"
            '
            'LabelControl_PayTo
            '
            Me.LabelControl_PayTo.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_PayTo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_PayTo.Location = New System.Drawing.Point(3, 54)
            Me.LabelControl_PayTo.Name = "LabelControl_PayTo"
            Me.LabelControl_PayTo.Size = New System.Drawing.Size(41, 20)
            Me.LabelControl_PayTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_PayTo.TabIndex = 43
            Me.LabelControl_PayTo.Text = "Pay To:"
            '
            'LabelControl_PostingPeriod
            '
            Me.LabelControl_PostingPeriod.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_PostingPeriod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_PostingPeriod.Location = New System.Drawing.Point(318, 158)
            Me.LabelControl_PostingPeriod.Name = "LabelControl_PostingPeriod"
            Me.LabelControl_PostingPeriod.Size = New System.Drawing.Size(81, 20)
            Me.LabelControl_PostingPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_PostingPeriod.TabIndex = 12
            Me.LabelControl_PostingPeriod.Text = "Posting Period:"
            '
            'TextBoxControl_PayTo
            '
            Me.TextBoxControl_PayTo.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxControl_PayTo.Border.Class = "TextBoxBorder"
            Me.TextBoxControl_PayTo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxControl_PayTo.CheckSpellingOnValidate = False
            Me.TextBoxControl_PayTo.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxControl_PayTo.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxControl_PayTo.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxControl_PayTo.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxControl_PayTo.FocusHighlightEnabled = True
            Me.TextBoxControl_PayTo.ForeColor = System.Drawing.Color.Black
            Me.TextBoxControl_PayTo.Location = New System.Drawing.Point(50, 54)
            Me.TextBoxControl_PayTo.MaxFileSize = CType(0, Long)
            Me.TextBoxControl_PayTo.Name = "TextBoxControl_PayTo"
            Me.TextBoxControl_PayTo.ReadOnly = True
            Me.TextBoxControl_PayTo.SecurityEnabled = True
            Me.TextBoxControl_PayTo.ShowSpellCheckCompleteMessage = True
            Me.TextBoxControl_PayTo.Size = New System.Drawing.Size(262, 20)
            Me.TextBoxControl_PayTo.StartingFolderName = Nothing
            Me.TextBoxControl_PayTo.TabIndex = 44
            Me.TextBoxControl_PayTo.TabOnEnter = True
            Me.TextBoxControl_PayTo.TabStop = False
            '
            'NumericInputControl_TotalDue
            '
            Me.NumericInputControl_TotalDue.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputControl_TotalDue.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputControl_TotalDue.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputControl_TotalDue.EnterMoveNextControl = True
            Me.NumericInputControl_TotalDue.Location = New System.Drawing.Point(628, 184)
            Me.NumericInputControl_TotalDue.Name = "NumericInputControl_TotalDue"
            Me.NumericInputControl_TotalDue.Properties.AllowMouseWheel = False
            Me.NumericInputControl_TotalDue.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control
            Me.NumericInputControl_TotalDue.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputControl_TotalDue.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputControl_TotalDue.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputControl_TotalDue.Properties.EditFormat.FormatString = "f"
            Me.NumericInputControl_TotalDue.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputControl_TotalDue.Properties.Mask.EditMask = "f"
            Me.NumericInputControl_TotalDue.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputControl_TotalDue.Properties.ReadOnly = True
            Me.NumericInputControl_TotalDue.SecurityEnabled = True
            Me.NumericInputControl_TotalDue.Size = New System.Drawing.Size(129, 20)
            Me.NumericInputControl_TotalDue.TabIndex = 26
            Me.NumericInputControl_TotalDue.TabStop = False
            '
            'SearchableComboBoxControl_InvoiceNumber
            '
            Me.SearchableComboBoxControl_InvoiceNumber.ActiveFilterString = ""
            Me.SearchableComboBoxControl_InvoiceNumber.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxControl_InvoiceNumber.AutoFillMode = False
            Me.SearchableComboBoxControl_InvoiceNumber.BookmarkingEnabled = False
            Me.SearchableComboBoxControl_InvoiceNumber.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.InvoiceNumber
            Me.SearchableComboBoxControl_InvoiceNumber.DataSource = Nothing
            Me.SearchableComboBoxControl_InvoiceNumber.DisableMouseWheel = True
            Me.SearchableComboBoxControl_InvoiceNumber.DisplayName = ""
            Me.SearchableComboBoxControl_InvoiceNumber.EditValue = "12345678901234567890"
            Me.SearchableComboBoxControl_InvoiceNumber.EnterMoveNextControl = True
            Me.SearchableComboBoxControl_InvoiceNumber.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxControl_InvoiceNumber.Location = New System.Drawing.Point(405, 28)
            Me.SearchableComboBoxControl_InvoiceNumber.Name = "SearchableComboBoxControl_InvoiceNumber"
            Me.SearchableComboBoxControl_InvoiceNumber.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxControl_InvoiceNumber.Properties.DisplayMember = "InvoiceNumber"
            Me.SearchableComboBoxControl_InvoiceNumber.Properties.NullText = "Select Invoice"
            Me.SearchableComboBoxControl_InvoiceNumber.Properties.ShowClearButton = False
            Me.SearchableComboBoxControl_InvoiceNumber.Properties.ValueMember = "InvoiceNumber"
            Me.SearchableComboBoxControl_InvoiceNumber.Properties.View = Me.SearchableComboBoxViewControl_InvoiceNumber
            Me.SearchableComboBoxControl_InvoiceNumber.SecurityEnabled = True
            Me.SearchableComboBoxControl_InvoiceNumber.SelectedValue = "12345678901234567890"
            Me.SearchableComboBoxControl_InvoiceNumber.Size = New System.Drawing.Size(352, 20)
            Me.SearchableComboBoxControl_InvoiceNumber.TabIndex = 3
            '
            'SearchableComboBoxViewControl_InvoiceNumber
            '
            Me.SearchableComboBoxViewControl_InvoiceNumber.AFActiveFilterString = ""
            Me.SearchableComboBoxViewControl_InvoiceNumber.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewControl_InvoiceNumber.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewControl_InvoiceNumber.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewControl_InvoiceNumber.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewControl_InvoiceNumber.DataSourceClearing = False
            Me.SearchableComboBoxViewControl_InvoiceNumber.EnableDisabledRows = False
            Me.SearchableComboBoxViewControl_InvoiceNumber.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewControl_InvoiceNumber.Name = "SearchableComboBoxViewControl_InvoiceNumber"
            Me.SearchableComboBoxViewControl_InvoiceNumber.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewControl_InvoiceNumber.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewControl_InvoiceNumber.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewControl_InvoiceNumber.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewControl_InvoiceNumber.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewControl_InvoiceNumber.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewControl_InvoiceNumber.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewControl_InvoiceNumber.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewControl_InvoiceNumber.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewControl_InvoiceNumber.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewControl_InvoiceNumber.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewControl_InvoiceNumber.RunStandardValidation = True
            '
            'TextBoxControl_InvoiceNumber
            '
            Me.TextBoxControl_InvoiceNumber.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxControl_InvoiceNumber.Border.Class = "TextBoxBorder"
            Me.TextBoxControl_InvoiceNumber.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxControl_InvoiceNumber.CheckSpellingOnValidate = False
            Me.TextBoxControl_InvoiceNumber.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxControl_InvoiceNumber.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxControl_InvoiceNumber.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxControl_InvoiceNumber.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxControl_InvoiceNumber.FocusHighlightEnabled = True
            Me.TextBoxControl_InvoiceNumber.ForeColor = System.Drawing.Color.Black
            Me.TextBoxControl_InvoiceNumber.Location = New System.Drawing.Point(405, 28)
            Me.TextBoxControl_InvoiceNumber.MaxFileSize = CType(0, Long)
            Me.TextBoxControl_InvoiceNumber.Name = "TextBoxControl_InvoiceNumber"
            Me.TextBoxControl_InvoiceNumber.ReadOnly = True
            Me.TextBoxControl_InvoiceNumber.SecurityEnabled = True
            Me.TextBoxControl_InvoiceNumber.ShowSpellCheckCompleteMessage = True
            Me.TextBoxControl_InvoiceNumber.Size = New System.Drawing.Size(352, 20)
            Me.TextBoxControl_InvoiceNumber.StartingFolderName = Nothing
            Me.TextBoxControl_InvoiceNumber.TabIndex = 3
            Me.TextBoxControl_InvoiceNumber.TabOnEnter = True
            '
            'LabelControl_VendorTaxableAmount
            '
            Me.LabelControl_VendorTaxableAmount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_VendorTaxableAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_VendorTaxableAmount.Location = New System.Drawing.Point(559, 288)
            Me.LabelControl_VendorTaxableAmount.Name = "LabelControl_VendorTaxableAmount"
            Me.LabelControl_VendorTaxableAmount.Size = New System.Drawing.Size(72, 20)
            Me.LabelControl_VendorTaxableAmount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_VendorTaxableAmount.TabIndex = 96
            Me.LabelControl_VendorTaxableAmount.Text = "VST Amount:"
            '
            'TabControlControl_APDetails
            '
            Me.TabControlControl_APDetails.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer))
            Me.TabControlControl_APDetails.CanReorderTabs = False
            Me.TabControlControl_APDetails.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlControl_APDetails.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlControl_APDetails.Controls.Add(Me.TabControlPanelTVDetailsTab_TVDetails)
            Me.TabControlControl_APDetails.Controls.Add(Me.TabControlPanelTVTab_TV)
            Me.TabControlControl_APDetails.Controls.Add(Me.TabControlPanelExpenseReceiptsTab_ExpenseReceipts)
            Me.TabControlControl_APDetails.Controls.Add(Me.TabControlPanelRadioDetailsTab_RadioDetails)
            Me.TabControlControl_APDetails.Controls.Add(Me.TabControlPanelProductionTab_Production)
            Me.TabControlControl_APDetails.Controls.Add(Me.TabControlPanelRadioTab_Radio)
            Me.TabControlControl_APDetails.Controls.Add(Me.TabControlPanelMagazineTab_Magazine)
            Me.TabControlControl_APDetails.Controls.Add(Me.TabControlPanelInternetTab_Internet)
            Me.TabControlControl_APDetails.Controls.Add(Me.TabControlPanelNonClientTab_NonClient)
            Me.TabControlControl_APDetails.Controls.Add(Me.TabControlPanelDocumentsTab_Documents)
            Me.TabControlControl_APDetails.Controls.Add(Me.TabControlPanelOutOfHomeTab_OutOfHome)
            Me.TabControlControl_APDetails.Controls.Add(Me.TabControlPanelNewspaperTab_Newspaper)
            Me.TabControlControl_APDetails.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlControl_APDetails.ForeColor = System.Drawing.Color.Black
            Me.TabControlControl_APDetails.Location = New System.Drawing.Point(0, 353)
            Me.TabControlControl_APDetails.Name = "TabControlControl_APDetails"
            Me.TabControlControl_APDetails.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlControl_APDetails.SelectedTabIndex = 0
            Me.TabControlControl_APDetails.Size = New System.Drawing.Size(992, 262)
            Me.TabControlControl_APDetails.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlControl_APDetails.TabIndex = 3
            Me.TabControlControl_APDetails.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlControl_APDetails.Tabs.Add(Me.TabItemAPDetails_ProductionTab)
            Me.TabControlControl_APDetails.Tabs.Add(Me.TabItemAPDetails_NewspaperTab)
            Me.TabControlControl_APDetails.Tabs.Add(Me.TabItemAPDetails_MagazineTab)
            Me.TabControlControl_APDetails.Tabs.Add(Me.TabItemAPDetails_RadioTab)
            Me.TabControlControl_APDetails.Tabs.Add(Me.TabItemAPDetails_RadioDetailsTab)
            Me.TabControlControl_APDetails.Tabs.Add(Me.TabItemAPDetails_TVTab)
            Me.TabControlControl_APDetails.Tabs.Add(Me.TabItemAPDetails_TVDetailsTab)
            Me.TabControlControl_APDetails.Tabs.Add(Me.TabItemAPDetails_OutOfHomeTab)
            Me.TabControlControl_APDetails.Tabs.Add(Me.TabItemAPDetails_InternetTab)
            Me.TabControlControl_APDetails.Tabs.Add(Me.TabItemAPDetails_NonClientTab)
            Me.TabControlControl_APDetails.Tabs.Add(Me.TabItemAPDetails_DocumentsTab)
            Me.TabControlControl_APDetails.Tabs.Add(Me.TabItemAPDetails_ExpenseReceiptsTab)
            Me.TabControlControl_APDetails.TabStop = False
            '
            'TabControlPanelRadioTab_Radio
            '
            Me.TabControlPanelRadioTab_Radio.Controls.Add(Me.DataGridViewRadio_DistributionDetails)
            Me.TabControlPanelRadioTab_Radio.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelRadioTab_Radio.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelRadioTab_Radio.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelRadioTab_Radio.Name = "TabControlPanelRadioTab_Radio"
            Me.TabControlPanelRadioTab_Radio.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelRadioTab_Radio.Size = New System.Drawing.Size(992, 235)
            Me.TabControlPanelRadioTab_Radio.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelRadioTab_Radio.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelRadioTab_Radio.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelRadioTab_Radio.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelRadioTab_Radio.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelRadioTab_Radio.Style.GradientAngle = 90
            Me.TabControlPanelRadioTab_Radio.TabIndex = 7
            Me.TabControlPanelRadioTab_Radio.TabItem = Me.TabItemAPDetails_RadioTab
            '
            'DataGridViewRadio_DistributionDetails
            '
            Me.DataGridViewRadio_DistributionDetails.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewRadio_DistributionDetails.AllowDragAndDrop = False
            Me.DataGridViewRadio_DistributionDetails.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewRadio_DistributionDetails.AllowSelectGroupHeaderRow = True
            Me.DataGridViewRadio_DistributionDetails.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewRadio_DistributionDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewRadio_DistributionDetails.AutoFilterLookupColumns = False
            Me.DataGridViewRadio_DistributionDetails.AutoloadRepositoryDatasource = True
            Me.DataGridViewRadio_DistributionDetails.AutoUpdateViewCaption = True
            Me.DataGridViewRadio_DistributionDetails.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewRadio_DistributionDetails.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewRadio_DistributionDetails.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewRadio_DistributionDetails.ItemDescription = ""
            Me.DataGridViewRadio_DistributionDetails.Location = New System.Drawing.Point(3, 4)
            Me.DataGridViewRadio_DistributionDetails.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewRadio_DistributionDetails.MultiSelect = True
            Me.DataGridViewRadio_DistributionDetails.Name = "DataGridViewRadio_DistributionDetails"
            Me.DataGridViewRadio_DistributionDetails.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewRadio_DistributionDetails.RunStandardValidation = True
            Me.DataGridViewRadio_DistributionDetails.ShowColumnMenuOnRightClick = False
            Me.DataGridViewRadio_DistributionDetails.ShowSelectDeselectAllButtons = False
            Me.DataGridViewRadio_DistributionDetails.Size = New System.Drawing.Size(986, 227)
            Me.DataGridViewRadio_DistributionDetails.TabIndex = 1
            Me.DataGridViewRadio_DistributionDetails.UseEmbeddedNavigator = False
            Me.DataGridViewRadio_DistributionDetails.ViewCaptionHeight = -1
            '
            'TabItemAPDetails_RadioTab
            '
            Me.TabItemAPDetails_RadioTab.AttachedControl = Me.TabControlPanelRadioTab_Radio
            Me.TabItemAPDetails_RadioTab.Name = "TabItemAPDetails_RadioTab"
            Me.TabItemAPDetails_RadioTab.Text = "Radio"
            '
            'TabControlPanelRadioDetailsTab_RadioDetails
            '
            Me.TabControlPanelRadioDetailsTab_RadioDetails.Controls.Add(Me.DataGridViewRadioDetails_BroadcastDetails)
            Me.TabControlPanelRadioDetailsTab_RadioDetails.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelRadioDetailsTab_RadioDetails.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelRadioDetailsTab_RadioDetails.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelRadioDetailsTab_RadioDetails.Name = "TabControlPanelRadioDetailsTab_RadioDetails"
            Me.TabControlPanelRadioDetailsTab_RadioDetails.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelRadioDetailsTab_RadioDetails.Size = New System.Drawing.Size(992, 235)
            Me.TabControlPanelRadioDetailsTab_RadioDetails.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelRadioDetailsTab_RadioDetails.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelRadioDetailsTab_RadioDetails.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelRadioDetailsTab_RadioDetails.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelRadioDetailsTab_RadioDetails.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelRadioDetailsTab_RadioDetails.Style.GradientAngle = 90
            Me.TabControlPanelRadioDetailsTab_RadioDetails.TabIndex = 35
            Me.TabControlPanelRadioDetailsTab_RadioDetails.TabItem = Me.TabItemAPDetails_RadioDetailsTab
            '
            'DataGridViewRadioDetails_BroadcastDetails
            '
            Me.DataGridViewRadioDetails_BroadcastDetails.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewRadioDetails_BroadcastDetails.AllowDragAndDrop = False
            Me.DataGridViewRadioDetails_BroadcastDetails.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewRadioDetails_BroadcastDetails.AllowSelectGroupHeaderRow = True
            Me.DataGridViewRadioDetails_BroadcastDetails.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewRadioDetails_BroadcastDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewRadioDetails_BroadcastDetails.AutoFilterLookupColumns = False
            Me.DataGridViewRadioDetails_BroadcastDetails.AutoloadRepositoryDatasource = True
            Me.DataGridViewRadioDetails_BroadcastDetails.AutoUpdateViewCaption = True
            Me.DataGridViewRadioDetails_BroadcastDetails.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewRadioDetails_BroadcastDetails.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewRadioDetails_BroadcastDetails.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewRadioDetails_BroadcastDetails.ItemDescription = "Item(s)"
            Me.DataGridViewRadioDetails_BroadcastDetails.Location = New System.Drawing.Point(3, 4)
            Me.DataGridViewRadioDetails_BroadcastDetails.MultiSelect = True
            Me.DataGridViewRadioDetails_BroadcastDetails.Name = "DataGridViewRadioDetails_BroadcastDetails"
            Me.DataGridViewRadioDetails_BroadcastDetails.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewRadioDetails_BroadcastDetails.RunStandardValidation = True
            Me.DataGridViewRadioDetails_BroadcastDetails.ShowColumnMenuOnRightClick = False
            Me.DataGridViewRadioDetails_BroadcastDetails.ShowSelectDeselectAllButtons = False
            Me.DataGridViewRadioDetails_BroadcastDetails.Size = New System.Drawing.Size(986, 227)
            Me.DataGridViewRadioDetails_BroadcastDetails.TabIndex = 0
            Me.DataGridViewRadioDetails_BroadcastDetails.UseEmbeddedNavigator = False
            Me.DataGridViewRadioDetails_BroadcastDetails.ViewCaptionHeight = -1
            '
            'TabItemAPDetails_RadioDetailsTab
            '
            Me.TabItemAPDetails_RadioDetailsTab.AttachedControl = Me.TabControlPanelRadioDetailsTab_RadioDetails
            Me.TabItemAPDetails_RadioDetailsTab.Name = "TabItemAPDetails_RadioDetailsTab"
            Me.TabItemAPDetails_RadioDetailsTab.Text = "Radio Details"
            '
            'TabControlPanelMagazineTab_Magazine
            '
            Me.TabControlPanelMagazineTab_Magazine.Controls.Add(Me.DataGridViewMagazine_DistributionDetails)
            Me.TabControlPanelMagazineTab_Magazine.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelMagazineTab_Magazine.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelMagazineTab_Magazine.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelMagazineTab_Magazine.Name = "TabControlPanelMagazineTab_Magazine"
            Me.TabControlPanelMagazineTab_Magazine.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelMagazineTab_Magazine.Size = New System.Drawing.Size(992, 235)
            Me.TabControlPanelMagazineTab_Magazine.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelMagazineTab_Magazine.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelMagazineTab_Magazine.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelMagazineTab_Magazine.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelMagazineTab_Magazine.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelMagazineTab_Magazine.Style.GradientAngle = 90
            Me.TabControlPanelMagazineTab_Magazine.TabIndex = 5
            Me.TabControlPanelMagazineTab_Magazine.TabItem = Me.TabItemAPDetails_MagazineTab
            '
            'DataGridViewMagazine_DistributionDetails
            '
            Me.DataGridViewMagazine_DistributionDetails.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewMagazine_DistributionDetails.AllowDragAndDrop = False
            Me.DataGridViewMagazine_DistributionDetails.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewMagazine_DistributionDetails.AllowSelectGroupHeaderRow = True
            Me.DataGridViewMagazine_DistributionDetails.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewMagazine_DistributionDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewMagazine_DistributionDetails.AutoFilterLookupColumns = False
            Me.DataGridViewMagazine_DistributionDetails.AutoloadRepositoryDatasource = True
            Me.DataGridViewMagazine_DistributionDetails.AutoUpdateViewCaption = True
            Me.DataGridViewMagazine_DistributionDetails.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewMagazine_DistributionDetails.DataSource = Nothing
            Me.DataGridViewMagazine_DistributionDetails.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewMagazine_DistributionDetails.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewMagazine_DistributionDetails.ItemDescription = ""
            Me.DataGridViewMagazine_DistributionDetails.Location = New System.Drawing.Point(3, 4)
            Me.DataGridViewMagazine_DistributionDetails.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewMagazine_DistributionDetails.MultiSelect = True
            Me.DataGridViewMagazine_DistributionDetails.Name = "DataGridViewMagazine_DistributionDetails"
            Me.DataGridViewMagazine_DistributionDetails.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewMagazine_DistributionDetails.RunStandardValidation = True
            Me.DataGridViewMagazine_DistributionDetails.ShowColumnMenuOnRightClick = False
            Me.DataGridViewMagazine_DistributionDetails.ShowSelectDeselectAllButtons = False
            Me.DataGridViewMagazine_DistributionDetails.Size = New System.Drawing.Size(986, 227)
            Me.DataGridViewMagazine_DistributionDetails.TabIndex = 0
            Me.DataGridViewMagazine_DistributionDetails.UseEmbeddedNavigator = False
            Me.DataGridViewMagazine_DistributionDetails.ViewCaptionHeight = -1
            '
            'TabItemAPDetails_MagazineTab
            '
            Me.TabItemAPDetails_MagazineTab.AttachedControl = Me.TabControlPanelMagazineTab_Magazine
            Me.TabItemAPDetails_MagazineTab.Name = "TabItemAPDetails_MagazineTab"
            Me.TabItemAPDetails_MagazineTab.Text = "Magazine"
            '
            'TabControlPanelTVTab_TV
            '
            Me.TabControlPanelTVTab_TV.Controls.Add(Me.DataGridViewTV_DistributionDetails)
            Me.TabControlPanelTVTab_TV.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelTVTab_TV.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelTVTab_TV.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelTVTab_TV.Name = "TabControlPanelTVTab_TV"
            Me.TabControlPanelTVTab_TV.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelTVTab_TV.Size = New System.Drawing.Size(992, 235)
            Me.TabControlPanelTVTab_TV.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelTVTab_TV.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelTVTab_TV.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelTVTab_TV.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelTVTab_TV.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelTVTab_TV.Style.GradientAngle = 90
            Me.TabControlPanelTVTab_TV.TabIndex = 8
            Me.TabControlPanelTVTab_TV.TabItem = Me.TabItemAPDetails_TVTab
            '
            'DataGridViewTV_DistributionDetails
            '
            Me.DataGridViewTV_DistributionDetails.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewTV_DistributionDetails.AllowDragAndDrop = False
            Me.DataGridViewTV_DistributionDetails.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewTV_DistributionDetails.AllowSelectGroupHeaderRow = True
            Me.DataGridViewTV_DistributionDetails.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewTV_DistributionDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewTV_DistributionDetails.AutoFilterLookupColumns = False
            Me.DataGridViewTV_DistributionDetails.AutoloadRepositoryDatasource = True
            Me.DataGridViewTV_DistributionDetails.AutoUpdateViewCaption = True
            Me.DataGridViewTV_DistributionDetails.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewTV_DistributionDetails.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewTV_DistributionDetails.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewTV_DistributionDetails.ItemDescription = ""
            Me.DataGridViewTV_DistributionDetails.Location = New System.Drawing.Point(3, 4)
            Me.DataGridViewTV_DistributionDetails.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewTV_DistributionDetails.MultiSelect = True
            Me.DataGridViewTV_DistributionDetails.Name = "DataGridViewTV_DistributionDetails"
            Me.DataGridViewTV_DistributionDetails.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewTV_DistributionDetails.RunStandardValidation = True
            Me.DataGridViewTV_DistributionDetails.ShowColumnMenuOnRightClick = False
            Me.DataGridViewTV_DistributionDetails.ShowSelectDeselectAllButtons = False
            Me.DataGridViewTV_DistributionDetails.Size = New System.Drawing.Size(986, 227)
            Me.DataGridViewTV_DistributionDetails.TabIndex = 1
            Me.DataGridViewTV_DistributionDetails.UseEmbeddedNavigator = False
            Me.DataGridViewTV_DistributionDetails.ViewCaptionHeight = -1
            '
            'TabItemAPDetails_TVTab
            '
            Me.TabItemAPDetails_TVTab.AttachedControl = Me.TabControlPanelTVTab_TV
            Me.TabItemAPDetails_TVTab.Name = "TabItemAPDetails_TVTab"
            Me.TabItemAPDetails_TVTab.Text = "TV"
            '
            'TabControlPanelTVDetailsTab_TVDetails
            '
            Me.TabControlPanelTVDetailsTab_TVDetails.Controls.Add(Me.DataGridViewTVDetails_BroadcastDetails)
            Me.TabControlPanelTVDetailsTab_TVDetails.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelTVDetailsTab_TVDetails.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelTVDetailsTab_TVDetails.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelTVDetailsTab_TVDetails.Name = "TabControlPanelTVDetailsTab_TVDetails"
            Me.TabControlPanelTVDetailsTab_TVDetails.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelTVDetailsTab_TVDetails.Size = New System.Drawing.Size(992, 235)
            Me.TabControlPanelTVDetailsTab_TVDetails.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelTVDetailsTab_TVDetails.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelTVDetailsTab_TVDetails.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelTVDetailsTab_TVDetails.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelTVDetailsTab_TVDetails.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelTVDetailsTab_TVDetails.Style.GradientAngle = 90
            Me.TabControlPanelTVDetailsTab_TVDetails.TabIndex = 39
            Me.TabControlPanelTVDetailsTab_TVDetails.TabItem = Me.TabItemAPDetails_TVDetailsTab
            '
            'TabItemAPDetails_TVDetailsTab
            '
            Me.TabItemAPDetails_TVDetailsTab.AttachedControl = Me.TabControlPanelTVDetailsTab_TVDetails
            Me.TabItemAPDetails_TVDetailsTab.Name = "TabItemAPDetails_TVDetailsTab"
            Me.TabItemAPDetails_TVDetailsTab.Text = "TV Details"
            '
            'TabControlPanelProductionTab_Production
            '
            Me.TabControlPanelProductionTab_Production.Controls.Add(Me.DataGridViewProduction_DistributionDetails)
            Me.TabControlPanelProductionTab_Production.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelProductionTab_Production.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelProductionTab_Production.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelProductionTab_Production.Name = "TabControlPanelProductionTab_Production"
            Me.TabControlPanelProductionTab_Production.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelProductionTab_Production.Size = New System.Drawing.Size(992, 235)
            Me.TabControlPanelProductionTab_Production.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelProductionTab_Production.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelProductionTab_Production.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelProductionTab_Production.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelProductionTab_Production.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelProductionTab_Production.Style.GradientAngle = 90
            Me.TabControlPanelProductionTab_Production.TabIndex = 3
            Me.TabControlPanelProductionTab_Production.TabItem = Me.TabItemAPDetails_ProductionTab
            '
            'DataGridViewProduction_DistributionDetails
            '
            Me.DataGridViewProduction_DistributionDetails.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewProduction_DistributionDetails.AllowDragAndDrop = False
            Me.DataGridViewProduction_DistributionDetails.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewProduction_DistributionDetails.AllowSelectGroupHeaderRow = True
            Me.DataGridViewProduction_DistributionDetails.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewProduction_DistributionDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewProduction_DistributionDetails.AutoFilterLookupColumns = True
            Me.DataGridViewProduction_DistributionDetails.AutoloadRepositoryDatasource = True
            Me.DataGridViewProduction_DistributionDetails.AutoUpdateViewCaption = True
            Me.DataGridViewProduction_DistributionDetails.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewProduction_DistributionDetails.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewProduction_DistributionDetails.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewProduction_DistributionDetails.ItemDescription = ""
            Me.DataGridViewProduction_DistributionDetails.Location = New System.Drawing.Point(3, 4)
            Me.DataGridViewProduction_DistributionDetails.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewProduction_DistributionDetails.MultiSelect = True
            Me.DataGridViewProduction_DistributionDetails.Name = "DataGridViewProduction_DistributionDetails"
            Me.DataGridViewProduction_DistributionDetails.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewProduction_DistributionDetails.RunStandardValidation = True
            Me.DataGridViewProduction_DistributionDetails.ShowColumnMenuOnRightClick = False
            Me.DataGridViewProduction_DistributionDetails.ShowSelectDeselectAllButtons = False
            Me.DataGridViewProduction_DistributionDetails.Size = New System.Drawing.Size(986, 227)
            Me.DataGridViewProduction_DistributionDetails.TabIndex = 0
            Me.DataGridViewProduction_DistributionDetails.UseEmbeddedNavigator = False
            Me.DataGridViewProduction_DistributionDetails.ViewCaptionHeight = -1
            '
            'TabItemAPDetails_ProductionTab
            '
            Me.TabItemAPDetails_ProductionTab.AttachedControl = Me.TabControlPanelProductionTab_Production
            Me.TabItemAPDetails_ProductionTab.Name = "TabItemAPDetails_ProductionTab"
            Me.TabItemAPDetails_ProductionTab.Text = "Production"
            '
            'TabControlPanelInternetTab_Internet
            '
            Me.TabControlPanelInternetTab_Internet.Controls.Add(Me.DataGridViewInternet_DistributionDetails)
            Me.TabControlPanelInternetTab_Internet.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelInternetTab_Internet.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelInternetTab_Internet.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelInternetTab_Internet.Name = "TabControlPanelInternetTab_Internet"
            Me.TabControlPanelInternetTab_Internet.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelInternetTab_Internet.Size = New System.Drawing.Size(992, 235)
            Me.TabControlPanelInternetTab_Internet.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelInternetTab_Internet.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelInternetTab_Internet.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelInternetTab_Internet.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelInternetTab_Internet.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelInternetTab_Internet.Style.GradientAngle = 90
            Me.TabControlPanelInternetTab_Internet.TabIndex = 1
            Me.TabControlPanelInternetTab_Internet.TabItem = Me.TabItemAPDetails_InternetTab
            '
            'DataGridViewInternet_DistributionDetails
            '
            Me.DataGridViewInternet_DistributionDetails.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewInternet_DistributionDetails.AllowDragAndDrop = False
            Me.DataGridViewInternet_DistributionDetails.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewInternet_DistributionDetails.AllowSelectGroupHeaderRow = True
            Me.DataGridViewInternet_DistributionDetails.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewInternet_DistributionDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewInternet_DistributionDetails.AutoFilterLookupColumns = False
            Me.DataGridViewInternet_DistributionDetails.AutoloadRepositoryDatasource = True
            Me.DataGridViewInternet_DistributionDetails.AutoUpdateViewCaption = True
            Me.DataGridViewInternet_DistributionDetails.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewInternet_DistributionDetails.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewInternet_DistributionDetails.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewInternet_DistributionDetails.ItemDescription = ""
            Me.DataGridViewInternet_DistributionDetails.Location = New System.Drawing.Point(3, 4)
            Me.DataGridViewInternet_DistributionDetails.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewInternet_DistributionDetails.MultiSelect = True
            Me.DataGridViewInternet_DistributionDetails.Name = "DataGridViewInternet_DistributionDetails"
            Me.DataGridViewInternet_DistributionDetails.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewInternet_DistributionDetails.RunStandardValidation = True
            Me.DataGridViewInternet_DistributionDetails.ShowColumnMenuOnRightClick = False
            Me.DataGridViewInternet_DistributionDetails.ShowSelectDeselectAllButtons = False
            Me.DataGridViewInternet_DistributionDetails.Size = New System.Drawing.Size(986, 227)
            Me.DataGridViewInternet_DistributionDetails.TabIndex = 1
            Me.DataGridViewInternet_DistributionDetails.UseEmbeddedNavigator = False
            Me.DataGridViewInternet_DistributionDetails.ViewCaptionHeight = -1
            '
            'TabItemAPDetails_InternetTab
            '
            Me.TabItemAPDetails_InternetTab.AttachedControl = Me.TabControlPanelInternetTab_Internet
            Me.TabItemAPDetails_InternetTab.Name = "TabItemAPDetails_InternetTab"
            Me.TabItemAPDetails_InternetTab.Text = "Internet"
            '
            'TabControlPanelNonClientTab_NonClient
            '
            Me.TabControlPanelNonClientTab_NonClient.Controls.Add(Me.DataGridViewNonClient_DistributionDetails)
            Me.TabControlPanelNonClientTab_NonClient.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelNonClientTab_NonClient.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelNonClientTab_NonClient.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelNonClientTab_NonClient.Name = "TabControlPanelNonClientTab_NonClient"
            Me.TabControlPanelNonClientTab_NonClient.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelNonClientTab_NonClient.Size = New System.Drawing.Size(992, 235)
            Me.TabControlPanelNonClientTab_NonClient.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelNonClientTab_NonClient.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelNonClientTab_NonClient.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelNonClientTab_NonClient.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelNonClientTab_NonClient.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelNonClientTab_NonClient.Style.GradientAngle = 90
            Me.TabControlPanelNonClientTab_NonClient.TabIndex = 10
            Me.TabControlPanelNonClientTab_NonClient.TabItem = Me.TabItemAPDetails_NonClientTab
            '
            'DataGridViewNonClient_DistributionDetails
            '
            Me.DataGridViewNonClient_DistributionDetails.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewNonClient_DistributionDetails.AllowDragAndDrop = False
            Me.DataGridViewNonClient_DistributionDetails.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewNonClient_DistributionDetails.AllowSelectGroupHeaderRow = True
            Me.DataGridViewNonClient_DistributionDetails.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewNonClient_DistributionDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewNonClient_DistributionDetails.AutoFilterLookupColumns = False
            Me.DataGridViewNonClient_DistributionDetails.AutoloadRepositoryDatasource = True
            Me.DataGridViewNonClient_DistributionDetails.AutoUpdateViewCaption = True
            Me.DataGridViewNonClient_DistributionDetails.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewNonClient_DistributionDetails.DataSource = Nothing
            Me.DataGridViewNonClient_DistributionDetails.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewNonClient_DistributionDetails.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewNonClient_DistributionDetails.ItemDescription = ""
            Me.DataGridViewNonClient_DistributionDetails.Location = New System.Drawing.Point(3, 4)
            Me.DataGridViewNonClient_DistributionDetails.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewNonClient_DistributionDetails.MultiSelect = True
            Me.DataGridViewNonClient_DistributionDetails.Name = "DataGridViewNonClient_DistributionDetails"
            Me.DataGridViewNonClient_DistributionDetails.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewNonClient_DistributionDetails.RunStandardValidation = True
            Me.DataGridViewNonClient_DistributionDetails.ShowColumnMenuOnRightClick = False
            Me.DataGridViewNonClient_DistributionDetails.ShowSelectDeselectAllButtons = False
            Me.DataGridViewNonClient_DistributionDetails.Size = New System.Drawing.Size(986, 227)
            Me.DataGridViewNonClient_DistributionDetails.TabIndex = 2
            Me.DataGridViewNonClient_DistributionDetails.UseEmbeddedNavigator = False
            Me.DataGridViewNonClient_DistributionDetails.ViewCaptionHeight = -1
            '
            'TabItemAPDetails_NonClientTab
            '
            Me.TabItemAPDetails_NonClientTab.AttachedControl = Me.TabControlPanelNonClientTab_NonClient
            Me.TabItemAPDetails_NonClientTab.Name = "TabItemAPDetails_NonClientTab"
            Me.TabItemAPDetails_NonClientTab.Text = "Non-Client"
            '
            'TabControlPanelDocumentsTab_Documents
            '
            Me.TabControlPanelDocumentsTab_Documents.Controls.Add(Me.DocumentManagerControlDocuments_APDocuments)
            Me.TabControlPanelDocumentsTab_Documents.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelDocumentsTab_Documents.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelDocumentsTab_Documents.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelDocumentsTab_Documents.Name = "TabControlPanelDocumentsTab_Documents"
            Me.TabControlPanelDocumentsTab_Documents.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelDocumentsTab_Documents.Size = New System.Drawing.Size(992, 235)
            Me.TabControlPanelDocumentsTab_Documents.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelDocumentsTab_Documents.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelDocumentsTab_Documents.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelDocumentsTab_Documents.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelDocumentsTab_Documents.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelDocumentsTab_Documents.Style.GradientAngle = 90
            Me.TabControlPanelDocumentsTab_Documents.TabIndex = 11
            Me.TabControlPanelDocumentsTab_Documents.TabItem = Me.TabItemAPDetails_DocumentsTab
            '
            'DocumentManagerControlDocuments_APDocuments
            '
            Me.DocumentManagerControlDocuments_APDocuments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DocumentManagerControlDocuments_APDocuments.Location = New System.Drawing.Point(3, 4)
            Me.DocumentManagerControlDocuments_APDocuments.Margin = New System.Windows.Forms.Padding(4)
            Me.DocumentManagerControlDocuments_APDocuments.Name = "DocumentManagerControlDocuments_APDocuments"
            Me.DocumentManagerControlDocuments_APDocuments.Size = New System.Drawing.Size(986, 227)
            Me.DocumentManagerControlDocuments_APDocuments.TabIndex = 1
            '
            'TabItemAPDetails_DocumentsTab
            '
            Me.TabItemAPDetails_DocumentsTab.AttachedControl = Me.TabControlPanelDocumentsTab_Documents
            Me.TabItemAPDetails_DocumentsTab.Name = "TabItemAPDetails_DocumentsTab"
            Me.TabItemAPDetails_DocumentsTab.Text = "Documents"
            '
            'TabControlPanelExpenseReceiptsTab_ExpenseReceipts
            '
            Me.TabControlPanelExpenseReceiptsTab_ExpenseReceipts.Controls.Add(Me.DocumentManagerControlExpenseReceipts_Receipts)
            Me.TabControlPanelExpenseReceiptsTab_ExpenseReceipts.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelExpenseReceiptsTab_ExpenseReceipts.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelExpenseReceiptsTab_ExpenseReceipts.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelExpenseReceiptsTab_ExpenseReceipts.Name = "TabControlPanelExpenseReceiptsTab_ExpenseReceipts"
            Me.TabControlPanelExpenseReceiptsTab_ExpenseReceipts.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelExpenseReceiptsTab_ExpenseReceipts.Size = New System.Drawing.Size(992, 235)
            Me.TabControlPanelExpenseReceiptsTab_ExpenseReceipts.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelExpenseReceiptsTab_ExpenseReceipts.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelExpenseReceiptsTab_ExpenseReceipts.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelExpenseReceiptsTab_ExpenseReceipts.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelExpenseReceiptsTab_ExpenseReceipts.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelExpenseReceiptsTab_ExpenseReceipts.Style.GradientAngle = 90
            Me.TabControlPanelExpenseReceiptsTab_ExpenseReceipts.TabIndex = 12
            Me.TabControlPanelExpenseReceiptsTab_ExpenseReceipts.TabItem = Me.TabItemAPDetails_ExpenseReceiptsTab
            '
            'DocumentManagerControlExpenseReceipts_Receipts
            '
            Me.DocumentManagerControlExpenseReceipts_Receipts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DocumentManagerControlExpenseReceipts_Receipts.Location = New System.Drawing.Point(3, 4)
            Me.DocumentManagerControlExpenseReceipts_Receipts.Margin = New System.Windows.Forms.Padding(4)
            Me.DocumentManagerControlExpenseReceipts_Receipts.Name = "DocumentManagerControlExpenseReceipts_Receipts"
            Me.DocumentManagerControlExpenseReceipts_Receipts.Size = New System.Drawing.Size(986, 227)
            Me.DocumentManagerControlExpenseReceipts_Receipts.TabIndex = 2
            '
            'TabItemAPDetails_ExpenseReceiptsTab
            '
            Me.TabItemAPDetails_ExpenseReceiptsTab.AttachedControl = Me.TabControlPanelExpenseReceiptsTab_ExpenseReceipts
            Me.TabItemAPDetails_ExpenseReceiptsTab.Name = "TabItemAPDetails_ExpenseReceiptsTab"
            Me.TabItemAPDetails_ExpenseReceiptsTab.Text = "Expense Receipts"
            '
            'TabControlPanelOutOfHomeTab_OutOfHome
            '
            Me.TabControlPanelOutOfHomeTab_OutOfHome.Controls.Add(Me.DataGridViewOutOfHome_DistributionDetails)
            Me.TabControlPanelOutOfHomeTab_OutOfHome.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelOutOfHomeTab_OutOfHome.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelOutOfHomeTab_OutOfHome.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelOutOfHomeTab_OutOfHome.Name = "TabControlPanelOutOfHomeTab_OutOfHome"
            Me.TabControlPanelOutOfHomeTab_OutOfHome.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelOutOfHomeTab_OutOfHome.Size = New System.Drawing.Size(992, 235)
            Me.TabControlPanelOutOfHomeTab_OutOfHome.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelOutOfHomeTab_OutOfHome.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelOutOfHomeTab_OutOfHome.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelOutOfHomeTab_OutOfHome.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelOutOfHomeTab_OutOfHome.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelOutOfHomeTab_OutOfHome.Style.GradientAngle = 90
            Me.TabControlPanelOutOfHomeTab_OutOfHome.TabIndex = 9
            Me.TabControlPanelOutOfHomeTab_OutOfHome.TabItem = Me.TabItemAPDetails_OutOfHomeTab
            '
            'DataGridViewOutOfHome_DistributionDetails
            '
            Me.DataGridViewOutOfHome_DistributionDetails.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewOutOfHome_DistributionDetails.AllowDragAndDrop = False
            Me.DataGridViewOutOfHome_DistributionDetails.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewOutOfHome_DistributionDetails.AllowSelectGroupHeaderRow = True
            Me.DataGridViewOutOfHome_DistributionDetails.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewOutOfHome_DistributionDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewOutOfHome_DistributionDetails.AutoFilterLookupColumns = False
            Me.DataGridViewOutOfHome_DistributionDetails.AutoloadRepositoryDatasource = True
            Me.DataGridViewOutOfHome_DistributionDetails.AutoUpdateViewCaption = True
            Me.DataGridViewOutOfHome_DistributionDetails.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewOutOfHome_DistributionDetails.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewOutOfHome_DistributionDetails.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewOutOfHome_DistributionDetails.ItemDescription = ""
            Me.DataGridViewOutOfHome_DistributionDetails.Location = New System.Drawing.Point(3, 4)
            Me.DataGridViewOutOfHome_DistributionDetails.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewOutOfHome_DistributionDetails.MultiSelect = True
            Me.DataGridViewOutOfHome_DistributionDetails.Name = "DataGridViewOutOfHome_DistributionDetails"
            Me.DataGridViewOutOfHome_DistributionDetails.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewOutOfHome_DistributionDetails.RunStandardValidation = True
            Me.DataGridViewOutOfHome_DistributionDetails.ShowColumnMenuOnRightClick = False
            Me.DataGridViewOutOfHome_DistributionDetails.ShowSelectDeselectAllButtons = False
            Me.DataGridViewOutOfHome_DistributionDetails.Size = New System.Drawing.Size(986, 227)
            Me.DataGridViewOutOfHome_DistributionDetails.TabIndex = 1
            Me.DataGridViewOutOfHome_DistributionDetails.UseEmbeddedNavigator = False
            Me.DataGridViewOutOfHome_DistributionDetails.ViewCaptionHeight = -1
            '
            'TabItemAPDetails_OutOfHomeTab
            '
            Me.TabItemAPDetails_OutOfHomeTab.AttachedControl = Me.TabControlPanelOutOfHomeTab_OutOfHome
            Me.TabItemAPDetails_OutOfHomeTab.Name = "TabItemAPDetails_OutOfHomeTab"
            Me.TabItemAPDetails_OutOfHomeTab.Text = "Out of Home"
            '
            'TabControlPanelNewspaperTab_Newspaper
            '
            Me.TabControlPanelNewspaperTab_Newspaper.Controls.Add(Me.DataGridViewNewspaper_DistributionDetails)
            Me.TabControlPanelNewspaperTab_Newspaper.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelNewspaperTab_Newspaper.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelNewspaperTab_Newspaper.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelNewspaperTab_Newspaper.Name = "TabControlPanelNewspaperTab_Newspaper"
            Me.TabControlPanelNewspaperTab_Newspaper.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelNewspaperTab_Newspaper.Size = New System.Drawing.Size(992, 235)
            Me.TabControlPanelNewspaperTab_Newspaper.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelNewspaperTab_Newspaper.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelNewspaperTab_Newspaper.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelNewspaperTab_Newspaper.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelNewspaperTab_Newspaper.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelNewspaperTab_Newspaper.Style.GradientAngle = 90
            Me.TabControlPanelNewspaperTab_Newspaper.TabIndex = 4
            Me.TabControlPanelNewspaperTab_Newspaper.TabItem = Me.TabItemAPDetails_NewspaperTab
            '
            'DataGridViewNewspaper_DistributionDetails
            '
            Me.DataGridViewNewspaper_DistributionDetails.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewNewspaper_DistributionDetails.AllowDragAndDrop = False
            Me.DataGridViewNewspaper_DistributionDetails.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewNewspaper_DistributionDetails.AllowSelectGroupHeaderRow = True
            Me.DataGridViewNewspaper_DistributionDetails.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewNewspaper_DistributionDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewNewspaper_DistributionDetails.AutoFilterLookupColumns = False
            Me.DataGridViewNewspaper_DistributionDetails.AutoloadRepositoryDatasource = True
            Me.DataGridViewNewspaper_DistributionDetails.AutoUpdateViewCaption = True
            Me.DataGridViewNewspaper_DistributionDetails.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewNewspaper_DistributionDetails.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewNewspaper_DistributionDetails.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewNewspaper_DistributionDetails.ItemDescription = ""
            Me.DataGridViewNewspaper_DistributionDetails.Location = New System.Drawing.Point(3, 4)
            Me.DataGridViewNewspaper_DistributionDetails.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewNewspaper_DistributionDetails.MultiSelect = True
            Me.DataGridViewNewspaper_DistributionDetails.Name = "DataGridViewNewspaper_DistributionDetails"
            Me.DataGridViewNewspaper_DistributionDetails.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewNewspaper_DistributionDetails.RunStandardValidation = True
            Me.DataGridViewNewspaper_DistributionDetails.ShowColumnMenuOnRightClick = False
            Me.DataGridViewNewspaper_DistributionDetails.ShowSelectDeselectAllButtons = False
            Me.DataGridViewNewspaper_DistributionDetails.Size = New System.Drawing.Size(986, 227)
            Me.DataGridViewNewspaper_DistributionDetails.TabIndex = 1
            Me.DataGridViewNewspaper_DistributionDetails.UseEmbeddedNavigator = False
            Me.DataGridViewNewspaper_DistributionDetails.ViewCaptionHeight = -1
            '
            'TabItemAPDetails_NewspaperTab
            '
            Me.TabItemAPDetails_NewspaperTab.AttachedControl = Me.TabControlPanelNewspaperTab_Newspaper
            Me.TabItemAPDetails_NewspaperTab.Name = "TabItemAPDetails_NewspaperTab"
            Me.TabItemAPDetails_NewspaperTab.Text = "Newspaper"
            '
            'DataGridViewTVDetails_BroadcastDetails
            '
            Me.DataGridViewTVDetails_BroadcastDetails.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewTVDetails_BroadcastDetails.AllowDragAndDrop = False
            Me.DataGridViewTVDetails_BroadcastDetails.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewTVDetails_BroadcastDetails.AllowSelectGroupHeaderRow = True
            Me.DataGridViewTVDetails_BroadcastDetails.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewTVDetails_BroadcastDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewTVDetails_BroadcastDetails.AutoFilterLookupColumns = False
            Me.DataGridViewTVDetails_BroadcastDetails.AutoloadRepositoryDatasource = True
            Me.DataGridViewTVDetails_BroadcastDetails.AutoUpdateViewCaption = True
            Me.DataGridViewTVDetails_BroadcastDetails.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewTVDetails_BroadcastDetails.DataSource = Nothing
            Me.DataGridViewTVDetails_BroadcastDetails.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewTVDetails_BroadcastDetails.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewTVDetails_BroadcastDetails.ItemDescription = "Item(s)"
            Me.DataGridViewTVDetails_BroadcastDetails.Location = New System.Drawing.Point(3, 4)
            Me.DataGridViewTVDetails_BroadcastDetails.MultiSelect = True
            Me.DataGridViewTVDetails_BroadcastDetails.Name = "DataGridViewTVDetails_BroadcastDetails"
            Me.DataGridViewTVDetails_BroadcastDetails.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewTVDetails_BroadcastDetails.RunStandardValidation = True
            Me.DataGridViewTVDetails_BroadcastDetails.ShowColumnMenuOnRightClick = False
            Me.DataGridViewTVDetails_BroadcastDetails.ShowSelectDeselectAllButtons = False
            Me.DataGridViewTVDetails_BroadcastDetails.Size = New System.Drawing.Size(986, 227)
            Me.DataGridViewTVDetails_BroadcastDetails.TabIndex = 1
            Me.DataGridViewTVDetails_BroadcastDetails.UseEmbeddedNavigator = False
            Me.DataGridViewTVDetails_BroadcastDetails.ViewCaptionHeight = -1
            '
            'AccountsPayableControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.TabControlControl_APDetails)
            Me.Controls.Add(Me.ExpandablePanelControl_HeaderInfo)
            Me.Name = "AccountsPayableControl"
            Me.Size = New System.Drawing.Size(992, 615)
            Me.ExpandablePanelControl_HeaderInfo.ResumeLayout(False)
            Me.ExpandablePanelControl_HeaderInfo.PerformLayout()
            CType(Me.PictureUpdateCurrency_Image.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxControl_CurrencyCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputControl_ExchangeAmount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputControl_HomeCurrencyAmount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputControl_VendorCurrencyRate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputControl_VendorTaxableAmount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxControl_VendorTaxCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputControl_SalesTax.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputInvoiceInformation_TotalPaidToVendor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxControl_Vendor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewControl_Vendor, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.TabControlControl_InvoiceDetails, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlControl_InvoiceDetails.ResumeLayout(False)
            Me.TabControlPanelDistributionTab_Distribution.ResumeLayout(False)
            CType(Me.NumericInputDistribution_ForeignTotal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputDistribution_Balance.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputDistribution_NonClient.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputDistribution_Clients.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlPanelTransactionsTab_Transactions.ResumeLayout(False)
            Me.TabControlPanelChecksWrittenTab_ChecksWritten.ResumeLayout(False)
            CType(Me.NumericInputControl_DiscountPercentage.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputControl_Discount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputControl_InvoiceTotal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerControl_InvoiceDate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerControl_DateToPay, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputControl_InvoiceAmount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerControl_EntryDate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputControl_TotalDue.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxControl_InvoiceNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewControl_InvoiceNumber, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.TabControlControl_APDetails, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlControl_APDetails.ResumeLayout(False)
            Me.TabControlPanelRadioTab_Radio.ResumeLayout(False)
            Me.TabControlPanelRadioDetailsTab_RadioDetails.ResumeLayout(False)
            Me.TabControlPanelMagazineTab_Magazine.ResumeLayout(False)
            Me.TabControlPanelTVTab_TV.ResumeLayout(False)
            Me.TabControlPanelTVDetailsTab_TVDetails.ResumeLayout(False)
            Me.TabControlPanelProductionTab_Production.ResumeLayout(False)
            Me.TabControlPanelInternetTab_Internet.ResumeLayout(False)
            Me.TabControlPanelNonClientTab_NonClient.ResumeLayout(False)
            Me.TabControlPanelDocumentsTab_Documents.ResumeLayout(False)
            Me.TabControlPanelExpenseReceiptsTab_ExpenseReceipts.ResumeLayout(False)
            Me.TabControlPanelOutOfHomeTab_OutOfHome.ResumeLayout(False)
            Me.TabControlPanelNewspaperTab_Newspaper.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ExpandablePanelControl_HeaderInfo As DevComponents.DotNetBar.ExpandablePanel
        Friend WithEvents LabelControl_Tax As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents NumericInputControl_SalesTax As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents TextBoxControl_MessageDetails As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelControl_Message As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxDropDownControl_Note As DevComponents.DotNetBar.Controls.TextBoxDropDown
        Friend WithEvents TextBoxControl_VendorNote As System.Windows.Forms.TextBox
        Friend WithEvents NumericInputInvoiceInformation_TotalPaidToVendor As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents LabelControl_TotalPaid As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxControl_Vendor As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewControl_Vendor As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents TabControlControl_InvoiceDetails As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelDistributionTab_Distribution As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents NumericInputDistribution_Balance As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents LabelDistribution_BalanceToApply As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents NumericInputDistribution_NonClient As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputDistribution_Clients As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents LabelDistribution_ClientTotal As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelDistribution_NonClientTotal As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TabItemInvoiceDetails_DistributionTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelChecksWrittenTab_ChecksWritten As DevComponents.DotNetBar.TabControlPanel
        Private WithEvents DataGridViewChecksWritten_ChecksWritten As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TabItemInvoiceDetails_ChecksWrittenTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelTransactionsTab_Transactions As DevComponents.DotNetBar.TabControlPanel
        Private WithEvents DataGridViewTransactions_GLTransactions As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TabItemInvoiceDetails_TransactionsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents LabelControl_TotalDue As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents NumericInputControl_DiscountPercentage As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputControl_Discount As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents LabelControl_DiscountPercentage As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents NumericInputControl_InvoiceTotal As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents LabelControl_Currency As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelControl_InvoiceTotal As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxControl_PostPeriodForMod As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents DateTimePickerControl_InvoiceDate As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents ComboBoxControl_Terms As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelControl_Note As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelControl_PostingPeriodForMod As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents DateTimePickerControl_DateToPay As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents ComboBoxControl_APAccount As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelControl_InvoiceDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxControl_Office As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxControl_PostPeriod As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelControl_Terms As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents NumericInputControl_InvoiceAmount As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents LabelControl_Office As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelControl_DateToPay As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelControl_APAccount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents DateTimePickerControl_EntryDate As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents CheckBoxControl_OnHold As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxControl_1099Invoice As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelControl_EntryDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxControl_Description As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelControl_InvoiceAmount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelControl_Description As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelControl_InvoiceNumber As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelControl_Vendor As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelControl_PayTo As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelControl_PostingPeriod As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxControl_PayTo As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents NumericInputControl_TotalDue As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents SearchableComboBoxControl_InvoiceNumber As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewControl_InvoiceNumber As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents TextBoxControl_InvoiceNumber As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TabControlControl_APDetails As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelProductionTab_Production As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewProduction_DistributionDetails As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TabItemAPDetails_ProductionTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelRadioTab_Radio As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewRadio_DistributionDetails As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TabItemAPDetails_RadioTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelNonClientTab_NonClient As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewNonClient_DistributionDetails As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TabItemAPDetails_NonClientTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelOutOfHomeTab_OutOfHome As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewOutOfHome_DistributionDetails As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TabItemAPDetails_OutOfHomeTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelInternetTab_Internet As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewInternet_DistributionDetails As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TabItemAPDetails_InternetTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelTVTab_TV As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewTV_DistributionDetails As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TabItemAPDetails_TVTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelNewspaperTab_Newspaper As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewNewspaper_DistributionDetails As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TabItemAPDetails_NewspaperTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelMagazineTab_Magazine As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents DataGridViewMagazine_DistributionDetails As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TabItemAPDetails_MagazineTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelDocumentsTab_Documents As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemAPDetails_DocumentsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents DocumentManagerControlDocuments_APDocuments As AdvantageFramework.WinForm.Presentation.Controls.DocumentManagerControl
        Friend WithEvents TabControlPanelExpenseReceiptsTab_ExpenseReceipts As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemAPDetails_ExpenseReceiptsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents DocumentManagerControlExpenseReceipts_Receipts As AdvantageFramework.WinForm.Presentation.Controls.DocumentManagerControl
        Friend WithEvents NumericInputControl_VendorTaxableAmount As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents CheckBoxControl_VendorTaxEnabled As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents SearchableComboBoxControl_VendorTaxCode As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView1 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents LabelControl_VendorTaxableAmount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelControl_VendorTaxCode As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents NumericInputControl_VendorCurrencyRate As NumericInput
        Friend WithEvents NumericInputControl_HomeCurrencyAmount As NumericInput
        Friend WithEvents LabelControl_HomeCurrency As Label
        Friend WithEvents Address3LineControlControl_Address As Address3LineControl
        Friend WithEvents NumericInputControl_ExchangeAmount As NumericInput
        Friend WithEvents LabelControl_ExchangeAmount As Label
        Friend WithEvents SearchableComboBoxControl_CurrencyCode As SearchableComboBox
        Friend WithEvents GridView2 As GridView
        Friend WithEvents PictureUpdateCurrency_Image As DevExpress.XtraEditors.PictureEdit
        Friend WithEvents NumericInputDistribution_ForeignTotal As NumericInput
        Friend WithEvents LabelDistribution_ForeignTotal As Label
        Friend WithEvents TabControlPanelRadioDetailsTab_RadioDetails As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemAPDetails_RadioDetailsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelTVDetailsTab_TVDetails As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemAPDetails_TVDetailsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents DataGridViewRadioDetails_BroadcastDetails As DataGridView
        Friend WithEvents DataGridViewTVDetails_BroadcastDetails As DataGridView
    End Class

End Namespace
