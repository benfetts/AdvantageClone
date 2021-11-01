Namespace FinanceAndAccounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ClientInvoiceNewDialog
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseRibbonForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ClientInvoiceNewDialog))
        Me.NumericInputForm_InvoiceAmount = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
        Me.SearchableComboBoxForm_SalesClass = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
        Me.SearchableComboBoxView_SalesClass = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
        Me.LabelForm_SalesClass = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.NumericInputDisbursedTo_City = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputDisbursedTo_COS = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputDisbursedTo_State = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputDisbursedTo_County = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.NumericInputDisbursedTo_Sales = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelDisbursedTo_Sales = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.NumericInputDisbursedTo_GrossProfit = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.LabelDisbursedTo_GrossProfit = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelDisbursedTo_City = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelDisbursedTo_County = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelDisbursedTo_COS = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelDisbursedTo_State = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_InvoiceAmount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.GroupBoxForm_AccountCodes = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.SearchableComboBoxGroup_CityTaxGLACode = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxView_GLACodeCity = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxGroup_CountyTaxGLACode = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxView_GLACodeCounty = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxGroup_StateTaxGLACode = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxView_GLACodeState = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelGroup_CityTaxGLACode = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGroup_CountyTaxGLACode = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGroup_StateTaxGLACode = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxGroup_ARGLACode = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxView_GLACodeAR = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxGroup_OffsetGLACode = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxView_GLACodeOffset = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxGroup_COSGLACode = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxView_GLACodeCOS = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxGroup_SalesGLACode = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxView_GLACodeSales = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelGroup_OffsetGLACode = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGroup_COSGLACode = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGroup_SalesGLACode = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelGroup_AccountsReceivableGLACode = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxForm_RecordType = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxView_Type = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelForm_Type = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_InvoiceDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DateTimePickerForm_InvoiceDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.SearchableComboBoxForm_Client = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxView_Client = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxForm_Office = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxView_Office = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelForm_Office = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Product = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxForm_Product = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxView_Product = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelForm_Division = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxForm_Division = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxView_Division = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelForm_PostPeriod = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxForm_Description = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelForm_Description = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Client = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_PrintCurrentBatch = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_PrintLastInvoice = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.GroupBoxPanel_Amounts = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.SearchableComboBoxForm_PostPeriod = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxView_PostPeriod = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Form.SuspendLayout()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputForm_InvoiceAmount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxForm_SalesClass.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxView_SalesClass, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputDisbursedTo_City.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputDisbursedTo_COS.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputDisbursedTo_State.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputDisbursedTo_County.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputDisbursedTo_Sales.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputDisbursedTo_GrossProfit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxForm_AccountCodes, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxForm_AccountCodes.SuspendLayout()
            CType(Me.SearchableComboBoxGroup_CityTaxGLACode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxView_GLACodeCity, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxGroup_CountyTaxGLACode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxView_GLACodeCounty, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxGroup_StateTaxGLACode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxView_GLACodeState, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxGroup_ARGLACode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxView_GLACodeAR, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxGroup_OffsetGLACode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxView_GLACodeOffset, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxGroup_COSGLACode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxView_GLACodeCOS, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxGroup_SalesGLACode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxView_GLACodeSales, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxForm_RecordType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxView_Type, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerForm_InvoiceDate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxForm_Client.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxView_Client, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxForm_Office.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxView_Office, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxForm_Product.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxView_Product, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxForm_Division.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxView_Division, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxPanel_Amounts, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxPanel_Amounts.SuspendLayout()
            CType(Me.SearchableComboBoxForm_PostPeriod.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxView_PostPeriod, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'RibbonControlForm_MainRibbon
            '
            '
            '
            '
            Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(657, 154)
            Me.RibbonControlForm_MainRibbon.SystemText.MaximizeRibbonText = "&Maximize the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.QatAddItemText = "&Add to Quick Access Toolbar"
            Me.RibbonControlForm_MainRibbon.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>"
            Me.RibbonControlForm_MainRibbon.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar..."
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogAddButton = "&Add >>"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogCancelButton = "Cancel"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogCaption = "Customize Quick Access Toolbar"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogCategoriesLabel = "&Choose commands from:"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogOkButton = "OK"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogRemoveButton = "&Remove"
            Me.RibbonControlForm_MainRibbon.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar"
            Me.RibbonControlForm_MainRibbon.TabIndex = 0
            Me.RibbonControlForm_MainRibbon.Controls.SetChildIndex(Me.RibbonPanelFile_FilePanel, 0)
            '
            'RibbonPanelFile_FilePanel
            '
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 57)
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(657, 95)
            '
            '
            '
            Me.RibbonPanelFile_FilePanel.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonPanelFile_FilePanel.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonPanelFile_FilePanel.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonPanelFile_FilePanel.TabIndex = 0
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarFilePanel_System, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Actions, 0)
            '
            'RibbonBarFilePanel_System
            '
            '
            '
            '
            Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.BorderColor = System.Drawing.Color.DarkGray
            Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.BorderColor2 = System.Drawing.Color.DarkGray
            Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.BorderRightWidth = 2
            Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_System.BackgroundStyle.BorderColor = System.Drawing.Color.DarkGray
            Me.RibbonBarFilePanel_System.BackgroundStyle.BorderColor2 = System.Drawing.Color.DarkGray
            Me.RibbonBarFilePanel_System.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.RibbonBarFilePanel_System.BackgroundStyle.BorderRightWidth = 2
            Me.RibbonBarFilePanel_System.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFilePanel_System.Size = New System.Drawing.Size(55, 92)
            '
            '
            '
            Me.RibbonBarFilePanel_System.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_System.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemSystem_Close
            '
            Me.ButtonItemSystem_Close.Image = CType(resources.GetObject("ButtonItemSystem_Close.Image"), System.Drawing.Image)
            '
            'PanelForm_Form
            '
            Me.PanelForm_Form.Controls.Add(Me.SearchableComboBoxForm_PostPeriod)
            Me.PanelForm_Form.Controls.Add(Me.GroupBoxPanel_Amounts)
            Me.PanelForm_Form.Controls.Add(Me.SearchableComboBoxForm_SalesClass)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_SalesClass)
            Me.PanelForm_Form.Controls.Add(Me.GroupBoxForm_AccountCodes)
            Me.PanelForm_Form.Controls.Add(Me.SearchableComboBoxForm_RecordType)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_Type)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_InvoiceDate)
            Me.PanelForm_Form.Controls.Add(Me.DateTimePickerForm_InvoiceDate)
            Me.PanelForm_Form.Controls.Add(Me.SearchableComboBoxForm_Client)
            Me.PanelForm_Form.Controls.Add(Me.SearchableComboBoxForm_Office)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_Office)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_Product)
            Me.PanelForm_Form.Controls.Add(Me.SearchableComboBoxForm_Product)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_Division)
            Me.PanelForm_Form.Controls.Add(Me.SearchableComboBoxForm_Division)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_PostPeriod)
            Me.PanelForm_Form.Controls.Add(Me.TextBoxForm_Description)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_Description)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_Client)
            Me.PanelForm_Form.Size = New System.Drawing.Size(657, 404)
            Me.PanelForm_Form.TabIndex = 1
            '
            'BarForm_StatusBar
            '
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 559)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(657, 18)
            '
            'NumericInputForm_InvoiceAmount
            '
            Me.NumericInputForm_InvoiceAmount.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputForm_InvoiceAmount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.NumericInputForm_InvoiceAmount.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputForm_InvoiceAmount.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputForm_InvoiceAmount.Location = New System.Drawing.Point(101, 24)
            Me.NumericInputForm_InvoiceAmount.Name = "NumericInputForm_InvoiceAmount"
            Me.NumericInputForm_InvoiceAmount.Properties.AllowMouseWheel = False
            Me.NumericInputForm_InvoiceAmount.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputForm_InvoiceAmount.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputForm_InvoiceAmount.Properties.DisplayFormat.FormatString = "n2"
            Me.NumericInputForm_InvoiceAmount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_InvoiceAmount.Properties.EditFormat.FormatString = "n2"
            Me.NumericInputForm_InvoiceAmount.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_InvoiceAmount.Properties.Mask.EditMask = "n2"
            Me.NumericInputForm_InvoiceAmount.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputForm_InvoiceAmount.Properties.NullText = "0.00"
            Me.NumericInputForm_InvoiceAmount.SecurityEnabled = True
            Me.NumericInputForm_InvoiceAmount.Size = New System.Drawing.Size(132, 20)
            Me.NumericInputForm_InvoiceAmount.TabIndex = 1
            '
            'SearchableComboBoxForm_SalesClass
            '
            Me.SearchableComboBoxForm_SalesClass.ActiveFilterString = ""
            Me.SearchableComboBoxForm_SalesClass.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxForm_SalesClass.AutoFillMode = False
            Me.SearchableComboBoxForm_SalesClass.BookmarkingEnabled = False
            Me.SearchableComboBoxForm_SalesClass.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.SalesClass
            Me.SearchableComboBoxForm_SalesClass.DataSource = Nothing
            Me.SearchableComboBoxForm_SalesClass.DisableMouseWheel = True
            Me.SearchableComboBoxForm_SalesClass.DisplayName = ""
            Me.SearchableComboBoxForm_SalesClass.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.None
            Me.SearchableComboBoxForm_SalesClass.Location = New System.Drawing.Point(90, 110)
            Me.SearchableComboBoxForm_SalesClass.Name = "SearchableComboBoxForm_SalesClass"
            Me.SearchableComboBoxForm_SalesClass.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxForm_SalesClass.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxForm_SalesClass.Properties.NullText = "Select Sales Class"
            Me.SearchableComboBoxForm_SalesClass.Properties.ShowClearButton = False
            Me.SearchableComboBoxForm_SalesClass.Properties.ValueMember = "Code"
            Me.SearchableComboBoxForm_SalesClass.Properties.View = Me.SearchableComboBoxView_SalesClass
            Me.SearchableComboBoxForm_SalesClass.SecurityEnabled = True
            Me.SearchableComboBoxForm_SalesClass.SelectedValue = Nothing
            Me.SearchableComboBoxForm_SalesClass.Size = New System.Drawing.Size(277, 20)
            Me.SearchableComboBoxForm_SalesClass.TabIndex = 9
            '
            'SearchableComboBoxView_SalesClass
            '
            Me.SearchableComboBoxView_SalesClass.AFActiveFilterString = ""
            Me.SearchableComboBoxView_SalesClass.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxView_SalesClass.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_SalesClass.AutoFilterLookupColumns = False
            Me.SearchableComboBoxView_SalesClass.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxView_SalesClass.DataSourceClearing = False
            Me.SearchableComboBoxView_SalesClass.EnableDisabledRows = False
            Me.SearchableComboBoxView_SalesClass.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxView_SalesClass.Name = "SearchableComboBoxView_SalesClass"
            Me.SearchableComboBoxView_SalesClass.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxView_SalesClass.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxView_SalesClass.OptionsBehavior.Editable = False
            Me.SearchableComboBoxView_SalesClass.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxView_SalesClass.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxView_SalesClass.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxView_SalesClass.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxView_SalesClass.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxView_SalesClass.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxView_SalesClass.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxView_SalesClass.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxView_SalesClass.RunStandardValidation = True
            '
            'LabelForm_SalesClass
            '
            Me.LabelForm_SalesClass.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_SalesClass.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_SalesClass.Location = New System.Drawing.Point(3, 110)
            Me.LabelForm_SalesClass.Name = "LabelForm_SalesClass"
            Me.LabelForm_SalesClass.Size = New System.Drawing.Size(81, 20)
            Me.LabelForm_SalesClass.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_SalesClass.TabIndex = 8
            Me.LabelForm_SalesClass.Text = "Sales Class:"
            '
            'NumericInputDisbursedTo_City
            '
            Me.NumericInputDisbursedTo_City.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputDisbursedTo_City.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.NumericInputDisbursedTo_City.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputDisbursedTo_City.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputDisbursedTo_City.Location = New System.Drawing.Point(101, 180)
            Me.NumericInputDisbursedTo_City.Name = "NumericInputDisbursedTo_City"
            Me.NumericInputDisbursedTo_City.Properties.AllowMouseWheel = False
            Me.NumericInputDisbursedTo_City.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputDisbursedTo_City.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputDisbursedTo_City.Properties.DisplayFormat.FormatString = "n2"
            Me.NumericInputDisbursedTo_City.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDisbursedTo_City.Properties.EditFormat.FormatString = "n2"
            Me.NumericInputDisbursedTo_City.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDisbursedTo_City.Properties.Mask.EditMask = "n2"
            Me.NumericInputDisbursedTo_City.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputDisbursedTo_City.Properties.NullText = "0.00"
            Me.NumericInputDisbursedTo_City.SecurityEnabled = True
            Me.NumericInputDisbursedTo_City.Size = New System.Drawing.Size(132, 20)
            Me.NumericInputDisbursedTo_City.TabIndex = 11
            '
            'NumericInputDisbursedTo_COS
            '
            Me.NumericInputDisbursedTo_COS.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputDisbursedTo_COS.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.NumericInputDisbursedTo_COS.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputDisbursedTo_COS.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputDisbursedTo_COS.Location = New System.Drawing.Point(101, 76)
            Me.NumericInputDisbursedTo_COS.Name = "NumericInputDisbursedTo_COS"
            Me.NumericInputDisbursedTo_COS.Properties.AllowMouseWheel = False
            Me.NumericInputDisbursedTo_COS.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputDisbursedTo_COS.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputDisbursedTo_COS.Properties.DisplayFormat.FormatString = "n2"
            Me.NumericInputDisbursedTo_COS.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDisbursedTo_COS.Properties.EditFormat.FormatString = "n2"
            Me.NumericInputDisbursedTo_COS.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDisbursedTo_COS.Properties.Mask.EditMask = "n2"
            Me.NumericInputDisbursedTo_COS.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputDisbursedTo_COS.Properties.NullText = "0.00"
            Me.NumericInputDisbursedTo_COS.SecurityEnabled = True
            Me.NumericInputDisbursedTo_COS.Size = New System.Drawing.Size(132, 20)
            Me.NumericInputDisbursedTo_COS.TabIndex = 5
            '
            'NumericInputDisbursedTo_State
            '
            Me.NumericInputDisbursedTo_State.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputDisbursedTo_State.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.NumericInputDisbursedTo_State.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputDisbursedTo_State.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputDisbursedTo_State.Location = New System.Drawing.Point(101, 128)
            Me.NumericInputDisbursedTo_State.Name = "NumericInputDisbursedTo_State"
            Me.NumericInputDisbursedTo_State.Properties.AllowMouseWheel = False
            Me.NumericInputDisbursedTo_State.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputDisbursedTo_State.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputDisbursedTo_State.Properties.DisplayFormat.FormatString = "n2"
            Me.NumericInputDisbursedTo_State.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDisbursedTo_State.Properties.EditFormat.FormatString = "n2"
            Me.NumericInputDisbursedTo_State.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDisbursedTo_State.Properties.Mask.EditMask = "n2"
            Me.NumericInputDisbursedTo_State.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputDisbursedTo_State.Properties.NullText = "0.00"
            Me.NumericInputDisbursedTo_State.SecurityEnabled = True
            Me.NumericInputDisbursedTo_State.Size = New System.Drawing.Size(132, 20)
            Me.NumericInputDisbursedTo_State.TabIndex = 7
            '
            'NumericInputDisbursedTo_County
            '
            Me.NumericInputDisbursedTo_County.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputDisbursedTo_County.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.NumericInputDisbursedTo_County.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputDisbursedTo_County.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputDisbursedTo_County.Location = New System.Drawing.Point(101, 154)
            Me.NumericInputDisbursedTo_County.Name = "NumericInputDisbursedTo_County"
            Me.NumericInputDisbursedTo_County.Properties.AllowMouseWheel = False
            Me.NumericInputDisbursedTo_County.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputDisbursedTo_County.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputDisbursedTo_County.Properties.DisplayFormat.FormatString = "n2"
            Me.NumericInputDisbursedTo_County.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDisbursedTo_County.Properties.EditFormat.FormatString = "n2"
            Me.NumericInputDisbursedTo_County.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDisbursedTo_County.Properties.Mask.EditMask = "n2"
            Me.NumericInputDisbursedTo_County.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputDisbursedTo_County.Properties.NullText = "0.00"
            Me.NumericInputDisbursedTo_County.SecurityEnabled = True
            Me.NumericInputDisbursedTo_County.Size = New System.Drawing.Size(132, 20)
            Me.NumericInputDisbursedTo_County.TabIndex = 9
            '
            'NumericInputDisbursedTo_Sales
            '
            Me.NumericInputDisbursedTo_Sales.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputDisbursedTo_Sales.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.NumericInputDisbursedTo_Sales.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputDisbursedTo_Sales.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputDisbursedTo_Sales.Location = New System.Drawing.Point(101, 50)
            Me.NumericInputDisbursedTo_Sales.Name = "NumericInputDisbursedTo_Sales"
            Me.NumericInputDisbursedTo_Sales.Properties.AllowMouseWheel = False
            Me.NumericInputDisbursedTo_Sales.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control
            Me.NumericInputDisbursedTo_Sales.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputDisbursedTo_Sales.Properties.DisplayFormat.FormatString = "n2"
            Me.NumericInputDisbursedTo_Sales.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDisbursedTo_Sales.Properties.EditFormat.FormatString = "n2"
            Me.NumericInputDisbursedTo_Sales.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDisbursedTo_Sales.Properties.Mask.EditMask = "n2"
            Me.NumericInputDisbursedTo_Sales.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputDisbursedTo_Sales.Properties.NullText = "0.00"
            Me.NumericInputDisbursedTo_Sales.Properties.ReadOnly = True
            Me.NumericInputDisbursedTo_Sales.SecurityEnabled = True
            Me.NumericInputDisbursedTo_Sales.Size = New System.Drawing.Size(132, 20)
            Me.NumericInputDisbursedTo_Sales.TabIndex = 3
            Me.NumericInputDisbursedTo_Sales.TabStop = False
            '
            'LabelDisbursedTo_Sales
            '
            Me.LabelDisbursedTo_Sales.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDisbursedTo_Sales.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDisbursedTo_Sales.Location = New System.Drawing.Point(5, 50)
            Me.LabelDisbursedTo_Sales.Name = "LabelDisbursedTo_Sales"
            Me.LabelDisbursedTo_Sales.Size = New System.Drawing.Size(90, 20)
            Me.LabelDisbursedTo_Sales.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDisbursedTo_Sales.TabIndex = 2
            Me.LabelDisbursedTo_Sales.Text = "Sales:"
            '
            'NumericInputDisbursedTo_GrossProfit
            '
            Me.NumericInputDisbursedTo_GrossProfit.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputDisbursedTo_GrossProfit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.NumericInputDisbursedTo_GrossProfit.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputDisbursedTo_GrossProfit.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputDisbursedTo_GrossProfit.Location = New System.Drawing.Point(101, 206)
            Me.NumericInputDisbursedTo_GrossProfit.Name = "NumericInputDisbursedTo_GrossProfit"
            Me.NumericInputDisbursedTo_GrossProfit.Properties.AllowMouseWheel = False
            Me.NumericInputDisbursedTo_GrossProfit.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control
            Me.NumericInputDisbursedTo_GrossProfit.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputDisbursedTo_GrossProfit.Properties.DisplayFormat.FormatString = "n2"
            Me.NumericInputDisbursedTo_GrossProfit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDisbursedTo_GrossProfit.Properties.EditFormat.FormatString = "n2"
            Me.NumericInputDisbursedTo_GrossProfit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputDisbursedTo_GrossProfit.Properties.Mask.EditMask = "n2"
            Me.NumericInputDisbursedTo_GrossProfit.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputDisbursedTo_GrossProfit.Properties.NullText = "0.00"
            Me.NumericInputDisbursedTo_GrossProfit.Properties.ReadOnly = True
            Me.NumericInputDisbursedTo_GrossProfit.SecurityEnabled = True
            Me.NumericInputDisbursedTo_GrossProfit.Size = New System.Drawing.Size(132, 20)
            Me.NumericInputDisbursedTo_GrossProfit.TabIndex = 13
            Me.NumericInputDisbursedTo_GrossProfit.TabStop = False
            '
            'LabelDisbursedTo_GrossProfit
            '
            Me.LabelDisbursedTo_GrossProfit.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDisbursedTo_GrossProfit.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDisbursedTo_GrossProfit.Location = New System.Drawing.Point(5, 206)
            Me.LabelDisbursedTo_GrossProfit.Name = "LabelDisbursedTo_GrossProfit"
            Me.LabelDisbursedTo_GrossProfit.Size = New System.Drawing.Size(90, 20)
            Me.LabelDisbursedTo_GrossProfit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDisbursedTo_GrossProfit.TabIndex = 12
            Me.LabelDisbursedTo_GrossProfit.Text = "Gross Profit:"
            '
            'LabelDisbursedTo_City
            '
            Me.LabelDisbursedTo_City.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDisbursedTo_City.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDisbursedTo_City.Location = New System.Drawing.Point(5, 180)
            Me.LabelDisbursedTo_City.Name = "LabelDisbursedTo_City"
            Me.LabelDisbursedTo_City.Size = New System.Drawing.Size(90, 20)
            Me.LabelDisbursedTo_City.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDisbursedTo_City.TabIndex = 10
            Me.LabelDisbursedTo_City.Text = "Resale - City:"
            '
            'LabelDisbursedTo_County
            '
            Me.LabelDisbursedTo_County.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDisbursedTo_County.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDisbursedTo_County.Location = New System.Drawing.Point(5, 154)
            Me.LabelDisbursedTo_County.Name = "LabelDisbursedTo_County"
            Me.LabelDisbursedTo_County.Size = New System.Drawing.Size(90, 20)
            Me.LabelDisbursedTo_County.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDisbursedTo_County.TabIndex = 8
            Me.LabelDisbursedTo_County.Text = "Resale - County:"
            '
            'LabelDisbursedTo_COS
            '
            Me.LabelDisbursedTo_COS.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDisbursedTo_COS.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDisbursedTo_COS.Location = New System.Drawing.Point(5, 76)
            Me.LabelDisbursedTo_COS.Name = "LabelDisbursedTo_COS"
            Me.LabelDisbursedTo_COS.Size = New System.Drawing.Size(90, 20)
            Me.LabelDisbursedTo_COS.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDisbursedTo_COS.TabIndex = 4
            Me.LabelDisbursedTo_COS.Text = "Cost of Sales:"
            '
            'LabelDisbursedTo_State
            '
            Me.LabelDisbursedTo_State.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelDisbursedTo_State.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelDisbursedTo_State.Location = New System.Drawing.Point(5, 128)
            Me.LabelDisbursedTo_State.Name = "LabelDisbursedTo_State"
            Me.LabelDisbursedTo_State.Size = New System.Drawing.Size(90, 20)
            Me.LabelDisbursedTo_State.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelDisbursedTo_State.TabIndex = 6
            Me.LabelDisbursedTo_State.Text = "Resale - State:"
            '
            'LabelForm_InvoiceAmount
            '
            Me.LabelForm_InvoiceAmount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_InvoiceAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_InvoiceAmount.Location = New System.Drawing.Point(5, 24)
            Me.LabelForm_InvoiceAmount.Name = "LabelForm_InvoiceAmount"
            Me.LabelForm_InvoiceAmount.Size = New System.Drawing.Size(90, 20)
            Me.LabelForm_InvoiceAmount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_InvoiceAmount.TabIndex = 0
            Me.LabelForm_InvoiceAmount.Text = "Invoice Amount:"
            '
            'GroupBoxForm_AccountCodes
            '
            Me.GroupBoxForm_AccountCodes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxForm_AccountCodes.Controls.Add(Me.SearchableComboBoxGroup_CityTaxGLACode)
            Me.GroupBoxForm_AccountCodes.Controls.Add(Me.SearchableComboBoxGroup_CountyTaxGLACode)
            Me.GroupBoxForm_AccountCodes.Controls.Add(Me.SearchableComboBoxGroup_StateTaxGLACode)
            Me.GroupBoxForm_AccountCodes.Controls.Add(Me.LabelGroup_CityTaxGLACode)
            Me.GroupBoxForm_AccountCodes.Controls.Add(Me.LabelGroup_CountyTaxGLACode)
            Me.GroupBoxForm_AccountCodes.Controls.Add(Me.LabelGroup_StateTaxGLACode)
            Me.GroupBoxForm_AccountCodes.Controls.Add(Me.SearchableComboBoxGroup_ARGLACode)
            Me.GroupBoxForm_AccountCodes.Controls.Add(Me.SearchableComboBoxGroup_OffsetGLACode)
            Me.GroupBoxForm_AccountCodes.Controls.Add(Me.SearchableComboBoxGroup_COSGLACode)
            Me.GroupBoxForm_AccountCodes.Controls.Add(Me.SearchableComboBoxGroup_SalesGLACode)
            Me.GroupBoxForm_AccountCodes.Controls.Add(Me.LabelGroup_OffsetGLACode)
            Me.GroupBoxForm_AccountCodes.Controls.Add(Me.LabelGroup_COSGLACode)
            Me.GroupBoxForm_AccountCodes.Controls.Add(Me.LabelGroup_SalesGLACode)
            Me.GroupBoxForm_AccountCodes.Controls.Add(Me.LabelGroup_AccountsReceivableGLACode)
            Me.GroupBoxForm_AccountCodes.Location = New System.Drawing.Point(247, 162)
            Me.GroupBoxForm_AccountCodes.Name = "GroupBoxForm_AccountCodes"
            Me.GroupBoxForm_AccountCodes.Size = New System.Drawing.Size(407, 236)
            Me.GroupBoxForm_AccountCodes.TabIndex = 19
            Me.GroupBoxForm_AccountCodes.Text = "GL Accounts"
            '
            'SearchableComboBoxGroup_CityTaxGLACode
            '
            Me.SearchableComboBoxGroup_CityTaxGLACode.ActiveFilterString = ""
            Me.SearchableComboBoxGroup_CityTaxGLACode.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxGroup_CityTaxGLACode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxGroup_CityTaxGLACode.AutoFillMode = False
            Me.SearchableComboBoxGroup_CityTaxGLACode.BookmarkingEnabled = False
            Me.SearchableComboBoxGroup_CityTaxGLACode.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.GeneralLedgerAccount
            Me.SearchableComboBoxGroup_CityTaxGLACode.DataSource = Nothing
            Me.SearchableComboBoxGroup_CityTaxGLACode.DisableMouseWheel = True
            Me.SearchableComboBoxGroup_CityTaxGLACode.DisplayName = ""
            Me.SearchableComboBoxGroup_CityTaxGLACode.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxGroup_CityTaxGLACode.Location = New System.Drawing.Point(75, 180)
            Me.SearchableComboBoxGroup_CityTaxGLACode.Name = "SearchableComboBoxGroup_CityTaxGLACode"
            Me.SearchableComboBoxGroup_CityTaxGLACode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxGroup_CityTaxGLACode.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxGroup_CityTaxGLACode.Properties.NullText = "[Please Select]"
            Me.SearchableComboBoxGroup_CityTaxGLACode.Properties.ValueMember = "Code"
            Me.SearchableComboBoxGroup_CityTaxGLACode.Properties.View = Me.SearchableComboBoxView_GLACodeCity
            Me.SearchableComboBoxGroup_CityTaxGLACode.SecurityEnabled = True
            Me.SearchableComboBoxGroup_CityTaxGLACode.SelectedValue = Nothing
            Me.SearchableComboBoxGroup_CityTaxGLACode.Size = New System.Drawing.Size(327, 20)
            Me.SearchableComboBoxGroup_CityTaxGLACode.TabIndex = 13
            '
            'SearchableComboBoxView_GLACodeCity
            '
            Me.SearchableComboBoxView_GLACodeCity.AFActiveFilterString = ""
            Me.SearchableComboBoxView_GLACodeCity.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxView_GLACodeCity.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCity.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCity.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCity.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCity.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCity.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCity.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCity.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCity.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCity.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCity.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCity.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCity.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCity.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCity.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCity.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCity.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCity.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCity.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCity.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCity.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCity.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCity.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCity.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCity.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCity.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCity.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCity.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCity.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCity.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCity.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCity.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCity.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCity.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCity.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCity.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCity.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCity.AutoFilterLookupColumns = False
            Me.SearchableComboBoxView_GLACodeCity.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxView_GLACodeCity.DataSourceClearing = False
            Me.SearchableComboBoxView_GLACodeCity.EnableDisabledRows = False
            Me.SearchableComboBoxView_GLACodeCity.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxView_GLACodeCity.Name = "SearchableComboBoxView_GLACodeCity"
            Me.SearchableComboBoxView_GLACodeCity.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxView_GLACodeCity.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxView_GLACodeCity.OptionsBehavior.Editable = False
            Me.SearchableComboBoxView_GLACodeCity.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxView_GLACodeCity.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxView_GLACodeCity.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxView_GLACodeCity.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxView_GLACodeCity.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxView_GLACodeCity.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxView_GLACodeCity.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxView_GLACodeCity.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxView_GLACodeCity.RunStandardValidation = True
            '
            'SearchableComboBoxGroup_CountyTaxGLACode
            '
            Me.SearchableComboBoxGroup_CountyTaxGLACode.ActiveFilterString = ""
            Me.SearchableComboBoxGroup_CountyTaxGLACode.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxGroup_CountyTaxGLACode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxGroup_CountyTaxGLACode.AutoFillMode = False
            Me.SearchableComboBoxGroup_CountyTaxGLACode.BookmarkingEnabled = False
            Me.SearchableComboBoxGroup_CountyTaxGLACode.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.GeneralLedgerAccount
            Me.SearchableComboBoxGroup_CountyTaxGLACode.DataSource = Nothing
            Me.SearchableComboBoxGroup_CountyTaxGLACode.DisableMouseWheel = True
            Me.SearchableComboBoxGroup_CountyTaxGLACode.DisplayName = ""
            Me.SearchableComboBoxGroup_CountyTaxGLACode.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxGroup_CountyTaxGLACode.Location = New System.Drawing.Point(75, 154)
            Me.SearchableComboBoxGroup_CountyTaxGLACode.Name = "SearchableComboBoxGroup_CountyTaxGLACode"
            Me.SearchableComboBoxGroup_CountyTaxGLACode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxGroup_CountyTaxGLACode.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxGroup_CountyTaxGLACode.Properties.NullText = "[Please Select]"
            Me.SearchableComboBoxGroup_CountyTaxGLACode.Properties.ValueMember = "Code"
            Me.SearchableComboBoxGroup_CountyTaxGLACode.Properties.View = Me.SearchableComboBoxView_GLACodeCounty
            Me.SearchableComboBoxGroup_CountyTaxGLACode.SecurityEnabled = True
            Me.SearchableComboBoxGroup_CountyTaxGLACode.SelectedValue = Nothing
            Me.SearchableComboBoxGroup_CountyTaxGLACode.Size = New System.Drawing.Size(327, 20)
            Me.SearchableComboBoxGroup_CountyTaxGLACode.TabIndex = 11
            '
            'SearchableComboBoxView_GLACodeCounty
            '
            Me.SearchableComboBoxView_GLACodeCounty.AFActiveFilterString = ""
            Me.SearchableComboBoxView_GLACodeCounty.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxView_GLACodeCounty.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCounty.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCounty.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCounty.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCounty.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCounty.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCounty.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCounty.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCounty.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCounty.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCounty.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCounty.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCounty.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCounty.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCounty.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCounty.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCounty.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCounty.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCounty.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCounty.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCounty.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCounty.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCounty.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCounty.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCounty.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCounty.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCounty.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCounty.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCounty.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCounty.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCounty.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCounty.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCounty.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCounty.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCounty.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCounty.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCounty.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCounty.AutoFilterLookupColumns = False
            Me.SearchableComboBoxView_GLACodeCounty.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxView_GLACodeCounty.DataSourceClearing = False
            Me.SearchableComboBoxView_GLACodeCounty.EnableDisabledRows = False
            Me.SearchableComboBoxView_GLACodeCounty.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxView_GLACodeCounty.Name = "SearchableComboBoxView_GLACodeCounty"
            Me.SearchableComboBoxView_GLACodeCounty.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxView_GLACodeCounty.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxView_GLACodeCounty.OptionsBehavior.Editable = False
            Me.SearchableComboBoxView_GLACodeCounty.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxView_GLACodeCounty.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxView_GLACodeCounty.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxView_GLACodeCounty.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxView_GLACodeCounty.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxView_GLACodeCounty.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxView_GLACodeCounty.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxView_GLACodeCounty.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxView_GLACodeCounty.RunStandardValidation = True
            '
            'SearchableComboBoxGroup_StateTaxGLACode
            '
            Me.SearchableComboBoxGroup_StateTaxGLACode.ActiveFilterString = ""
            Me.SearchableComboBoxGroup_StateTaxGLACode.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxGroup_StateTaxGLACode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxGroup_StateTaxGLACode.AutoFillMode = False
            Me.SearchableComboBoxGroup_StateTaxGLACode.BookmarkingEnabled = False
            Me.SearchableComboBoxGroup_StateTaxGLACode.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.GeneralLedgerAccount
            Me.SearchableComboBoxGroup_StateTaxGLACode.DataSource = Nothing
            Me.SearchableComboBoxGroup_StateTaxGLACode.DisableMouseWheel = True
            Me.SearchableComboBoxGroup_StateTaxGLACode.DisplayName = ""
            Me.SearchableComboBoxGroup_StateTaxGLACode.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxGroup_StateTaxGLACode.Location = New System.Drawing.Point(75, 128)
            Me.SearchableComboBoxGroup_StateTaxGLACode.Name = "SearchableComboBoxGroup_StateTaxGLACode"
            Me.SearchableComboBoxGroup_StateTaxGLACode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxGroup_StateTaxGLACode.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxGroup_StateTaxGLACode.Properties.NullText = "[Please Select]"
            Me.SearchableComboBoxGroup_StateTaxGLACode.Properties.ValueMember = "Code"
            Me.SearchableComboBoxGroup_StateTaxGLACode.Properties.View = Me.SearchableComboBoxView_GLACodeState
            Me.SearchableComboBoxGroup_StateTaxGLACode.SecurityEnabled = True
            Me.SearchableComboBoxGroup_StateTaxGLACode.SelectedValue = Nothing
            Me.SearchableComboBoxGroup_StateTaxGLACode.Size = New System.Drawing.Size(327, 20)
            Me.SearchableComboBoxGroup_StateTaxGLACode.TabIndex = 9
            '
            'SearchableComboBoxView_GLACodeState
            '
            Me.SearchableComboBoxView_GLACodeState.AFActiveFilterString = ""
            Me.SearchableComboBoxView_GLACodeState.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxView_GLACodeState.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeState.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeState.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeState.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeState.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeState.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeState.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeState.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeState.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeState.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeState.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeState.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeState.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeState.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeState.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeState.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeState.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeState.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeState.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeState.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeState.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeState.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeState.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeState.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeState.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeState.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeState.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeState.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeState.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeState.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeState.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeState.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeState.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeState.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeState.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeState.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeState.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeState.AutoFilterLookupColumns = False
            Me.SearchableComboBoxView_GLACodeState.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxView_GLACodeState.DataSourceClearing = False
            Me.SearchableComboBoxView_GLACodeState.EnableDisabledRows = False
            Me.SearchableComboBoxView_GLACodeState.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxView_GLACodeState.Name = "SearchableComboBoxView_GLACodeState"
            Me.SearchableComboBoxView_GLACodeState.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxView_GLACodeState.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxView_GLACodeState.OptionsBehavior.Editable = False
            Me.SearchableComboBoxView_GLACodeState.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxView_GLACodeState.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxView_GLACodeState.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxView_GLACodeState.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxView_GLACodeState.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxView_GLACodeState.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxView_GLACodeState.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxView_GLACodeState.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxView_GLACodeState.RunStandardValidation = True
            '
            'LabelGroup_CityTaxGLACode
            '
            Me.LabelGroup_CityTaxGLACode.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGroup_CityTaxGLACode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGroup_CityTaxGLACode.Location = New System.Drawing.Point(5, 180)
            Me.LabelGroup_CityTaxGLACode.Name = "LabelGroup_CityTaxGLACode"
            Me.LabelGroup_CityTaxGLACode.Size = New System.Drawing.Size(71, 20)
            Me.LabelGroup_CityTaxGLACode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGroup_CityTaxGLACode.TabIndex = 12
            Me.LabelGroup_CityTaxGLACode.Text = "City Tax:"
            '
            'LabelGroup_CountyTaxGLACode
            '
            Me.LabelGroup_CountyTaxGLACode.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGroup_CountyTaxGLACode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGroup_CountyTaxGLACode.Location = New System.Drawing.Point(5, 154)
            Me.LabelGroup_CountyTaxGLACode.Name = "LabelGroup_CountyTaxGLACode"
            Me.LabelGroup_CountyTaxGLACode.Size = New System.Drawing.Size(64, 20)
            Me.LabelGroup_CountyTaxGLACode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGroup_CountyTaxGLACode.TabIndex = 10
            Me.LabelGroup_CountyTaxGLACode.Text = "County Tax:"
            '
            'LabelGroup_StateTaxGLACode
            '
            Me.LabelGroup_StateTaxGLACode.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGroup_StateTaxGLACode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGroup_StateTaxGLACode.Location = New System.Drawing.Point(5, 128)
            Me.LabelGroup_StateTaxGLACode.Name = "LabelGroup_StateTaxGLACode"
            Me.LabelGroup_StateTaxGLACode.Size = New System.Drawing.Size(71, 20)
            Me.LabelGroup_StateTaxGLACode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGroup_StateTaxGLACode.TabIndex = 8
            Me.LabelGroup_StateTaxGLACode.Text = "State Tax:"
            '
            'SearchableComboBoxGroup_ARGLACode
            '
            Me.SearchableComboBoxGroup_ARGLACode.ActiveFilterString = ""
            Me.SearchableComboBoxGroup_ARGLACode.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxGroup_ARGLACode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxGroup_ARGLACode.AutoFillMode = False
            Me.SearchableComboBoxGroup_ARGLACode.BookmarkingEnabled = False
            Me.SearchableComboBoxGroup_ARGLACode.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.GeneralLedgerAccount
            Me.SearchableComboBoxGroup_ARGLACode.DataSource = Nothing
            Me.SearchableComboBoxGroup_ARGLACode.DisableMouseWheel = True
            Me.SearchableComboBoxGroup_ARGLACode.DisplayName = ""
            Me.SearchableComboBoxGroup_ARGLACode.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxGroup_ARGLACode.Location = New System.Drawing.Point(75, 24)
            Me.SearchableComboBoxGroup_ARGLACode.Name = "SearchableComboBoxGroup_ARGLACode"
            Me.SearchableComboBoxGroup_ARGLACode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxGroup_ARGLACode.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxGroup_ARGLACode.Properties.NullText = "[Please Select]"
            Me.SearchableComboBoxGroup_ARGLACode.Properties.ValueMember = "Code"
            Me.SearchableComboBoxGroup_ARGLACode.Properties.View = Me.SearchableComboBoxView_GLACodeAR
            Me.SearchableComboBoxGroup_ARGLACode.SecurityEnabled = True
            Me.SearchableComboBoxGroup_ARGLACode.SelectedValue = Nothing
            Me.SearchableComboBoxGroup_ARGLACode.Size = New System.Drawing.Size(327, 20)
            Me.SearchableComboBoxGroup_ARGLACode.TabIndex = 1
            '
            'SearchableComboBoxView_GLACodeAR
            '
            Me.SearchableComboBoxView_GLACodeAR.AFActiveFilterString = ""
            Me.SearchableComboBoxView_GLACodeAR.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxView_GLACodeAR.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeAR.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeAR.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeAR.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeAR.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeAR.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeAR.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeAR.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeAR.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeAR.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeAR.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeAR.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeAR.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeAR.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeAR.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeAR.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeAR.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeAR.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeAR.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeAR.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeAR.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeAR.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeAR.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeAR.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeAR.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeAR.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeAR.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeAR.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeAR.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeAR.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeAR.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeAR.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeAR.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeAR.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeAR.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeAR.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeAR.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeAR.AutoFilterLookupColumns = False
            Me.SearchableComboBoxView_GLACodeAR.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxView_GLACodeAR.DataSourceClearing = False
            Me.SearchableComboBoxView_GLACodeAR.EnableDisabledRows = False
            Me.SearchableComboBoxView_GLACodeAR.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxView_GLACodeAR.Name = "SearchableComboBoxView_GLACodeAR"
            Me.SearchableComboBoxView_GLACodeAR.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxView_GLACodeAR.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxView_GLACodeAR.OptionsBehavior.Editable = False
            Me.SearchableComboBoxView_GLACodeAR.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxView_GLACodeAR.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxView_GLACodeAR.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxView_GLACodeAR.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxView_GLACodeAR.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxView_GLACodeAR.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxView_GLACodeAR.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxView_GLACodeAR.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxView_GLACodeAR.RunStandardValidation = True
            '
            'SearchableComboBoxGroup_OffsetGLACode
            '
            Me.SearchableComboBoxGroup_OffsetGLACode.ActiveFilterString = ""
            Me.SearchableComboBoxGroup_OffsetGLACode.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxGroup_OffsetGLACode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxGroup_OffsetGLACode.AutoFillMode = False
            Me.SearchableComboBoxGroup_OffsetGLACode.BookmarkingEnabled = False
            Me.SearchableComboBoxGroup_OffsetGLACode.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.GeneralLedgerAccount
            Me.SearchableComboBoxGroup_OffsetGLACode.DataSource = Nothing
            Me.SearchableComboBoxGroup_OffsetGLACode.DisableMouseWheel = True
            Me.SearchableComboBoxGroup_OffsetGLACode.DisplayName = ""
            Me.SearchableComboBoxGroup_OffsetGLACode.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxGroup_OffsetGLACode.Location = New System.Drawing.Point(75, 102)
            Me.SearchableComboBoxGroup_OffsetGLACode.Name = "SearchableComboBoxGroup_OffsetGLACode"
            Me.SearchableComboBoxGroup_OffsetGLACode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxGroup_OffsetGLACode.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxGroup_OffsetGLACode.Properties.NullText = "[Please Select]"
            Me.SearchableComboBoxGroup_OffsetGLACode.Properties.ValueMember = "Code"
            Me.SearchableComboBoxGroup_OffsetGLACode.Properties.View = Me.SearchableComboBoxView_GLACodeOffset
            Me.SearchableComboBoxGroup_OffsetGLACode.SecurityEnabled = True
            Me.SearchableComboBoxGroup_OffsetGLACode.SelectedValue = Nothing
            Me.SearchableComboBoxGroup_OffsetGLACode.Size = New System.Drawing.Size(327, 20)
            Me.SearchableComboBoxGroup_OffsetGLACode.TabIndex = 7
            '
            'SearchableComboBoxView_GLACodeOffset
            '
            Me.SearchableComboBoxView_GLACodeOffset.AFActiveFilterString = ""
            Me.SearchableComboBoxView_GLACodeOffset.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxView_GLACodeOffset.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeOffset.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeOffset.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeOffset.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeOffset.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeOffset.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeOffset.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeOffset.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeOffset.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeOffset.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeOffset.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeOffset.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeOffset.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeOffset.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeOffset.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeOffset.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeOffset.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeOffset.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeOffset.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeOffset.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeOffset.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeOffset.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeOffset.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeOffset.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeOffset.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeOffset.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeOffset.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeOffset.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeOffset.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeOffset.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeOffset.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeOffset.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeOffset.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeOffset.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeOffset.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeOffset.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeOffset.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeOffset.AutoFilterLookupColumns = False
            Me.SearchableComboBoxView_GLACodeOffset.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxView_GLACodeOffset.DataSourceClearing = False
            Me.SearchableComboBoxView_GLACodeOffset.EnableDisabledRows = False
            Me.SearchableComboBoxView_GLACodeOffset.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxView_GLACodeOffset.Name = "SearchableComboBoxView_GLACodeOffset"
            Me.SearchableComboBoxView_GLACodeOffset.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxView_GLACodeOffset.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxView_GLACodeOffset.OptionsBehavior.Editable = False
            Me.SearchableComboBoxView_GLACodeOffset.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxView_GLACodeOffset.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxView_GLACodeOffset.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxView_GLACodeOffset.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxView_GLACodeOffset.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxView_GLACodeOffset.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxView_GLACodeOffset.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxView_GLACodeOffset.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxView_GLACodeOffset.RunStandardValidation = True
            '
            'SearchableComboBoxGroup_COSGLACode
            '
            Me.SearchableComboBoxGroup_COSGLACode.ActiveFilterString = ""
            Me.SearchableComboBoxGroup_COSGLACode.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxGroup_COSGLACode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxGroup_COSGLACode.AutoFillMode = False
            Me.SearchableComboBoxGroup_COSGLACode.BookmarkingEnabled = False
            Me.SearchableComboBoxGroup_COSGLACode.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.GeneralLedgerAccount
            Me.SearchableComboBoxGroup_COSGLACode.DataSource = Nothing
            Me.SearchableComboBoxGroup_COSGLACode.DisableMouseWheel = True
            Me.SearchableComboBoxGroup_COSGLACode.DisplayName = ""
            Me.SearchableComboBoxGroup_COSGLACode.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxGroup_COSGLACode.Location = New System.Drawing.Point(75, 76)
            Me.SearchableComboBoxGroup_COSGLACode.Name = "SearchableComboBoxGroup_COSGLACode"
            Me.SearchableComboBoxGroup_COSGLACode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxGroup_COSGLACode.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxGroup_COSGLACode.Properties.NullText = "[Please Select]"
            Me.SearchableComboBoxGroup_COSGLACode.Properties.ValueMember = "Code"
            Me.SearchableComboBoxGroup_COSGLACode.Properties.View = Me.SearchableComboBoxView_GLACodeCOS
            Me.SearchableComboBoxGroup_COSGLACode.SecurityEnabled = True
            Me.SearchableComboBoxGroup_COSGLACode.SelectedValue = Nothing
            Me.SearchableComboBoxGroup_COSGLACode.Size = New System.Drawing.Size(327, 20)
            Me.SearchableComboBoxGroup_COSGLACode.TabIndex = 5
            '
            'SearchableComboBoxView_GLACodeCOS
            '
            Me.SearchableComboBoxView_GLACodeCOS.AFActiveFilterString = ""
            Me.SearchableComboBoxView_GLACodeCOS.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxView_GLACodeCOS.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCOS.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCOS.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCOS.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCOS.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCOS.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCOS.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCOS.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCOS.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCOS.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCOS.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCOS.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCOS.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCOS.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCOS.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCOS.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCOS.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCOS.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCOS.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCOS.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCOS.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCOS.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCOS.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCOS.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCOS.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCOS.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCOS.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCOS.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCOS.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCOS.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCOS.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCOS.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCOS.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCOS.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCOS.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCOS.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCOS.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeCOS.AutoFilterLookupColumns = False
            Me.SearchableComboBoxView_GLACodeCOS.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxView_GLACodeCOS.DataSourceClearing = False
            Me.SearchableComboBoxView_GLACodeCOS.EnableDisabledRows = False
            Me.SearchableComboBoxView_GLACodeCOS.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxView_GLACodeCOS.Name = "SearchableComboBoxView_GLACodeCOS"
            Me.SearchableComboBoxView_GLACodeCOS.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxView_GLACodeCOS.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxView_GLACodeCOS.OptionsBehavior.Editable = False
            Me.SearchableComboBoxView_GLACodeCOS.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxView_GLACodeCOS.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxView_GLACodeCOS.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxView_GLACodeCOS.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxView_GLACodeCOS.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxView_GLACodeCOS.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxView_GLACodeCOS.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxView_GLACodeCOS.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxView_GLACodeCOS.RunStandardValidation = True
            '
            'SearchableComboBoxGroup_SalesGLACode
            '
            Me.SearchableComboBoxGroup_SalesGLACode.ActiveFilterString = ""
            Me.SearchableComboBoxGroup_SalesGLACode.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxGroup_SalesGLACode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxGroup_SalesGLACode.AutoFillMode = False
            Me.SearchableComboBoxGroup_SalesGLACode.BookmarkingEnabled = False
            Me.SearchableComboBoxGroup_SalesGLACode.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.GeneralLedgerAccount
            Me.SearchableComboBoxGroup_SalesGLACode.DataSource = Nothing
            Me.SearchableComboBoxGroup_SalesGLACode.DisableMouseWheel = True
            Me.SearchableComboBoxGroup_SalesGLACode.DisplayName = ""
            Me.SearchableComboBoxGroup_SalesGLACode.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxGroup_SalesGLACode.Location = New System.Drawing.Point(75, 50)
            Me.SearchableComboBoxGroup_SalesGLACode.Name = "SearchableComboBoxGroup_SalesGLACode"
            Me.SearchableComboBoxGroup_SalesGLACode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxGroup_SalesGLACode.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxGroup_SalesGLACode.Properties.NullText = "[Please Select]"
            Me.SearchableComboBoxGroup_SalesGLACode.Properties.ValueMember = "Code"
            Me.SearchableComboBoxGroup_SalesGLACode.Properties.View = Me.SearchableComboBoxView_GLACodeSales
            Me.SearchableComboBoxGroup_SalesGLACode.SecurityEnabled = True
            Me.SearchableComboBoxGroup_SalesGLACode.SelectedValue = Nothing
            Me.SearchableComboBoxGroup_SalesGLACode.Size = New System.Drawing.Size(327, 20)
            Me.SearchableComboBoxGroup_SalesGLACode.TabIndex = 3
            '
            'SearchableComboBoxView_GLACodeSales
            '
            Me.SearchableComboBoxView_GLACodeSales.AFActiveFilterString = ""
            Me.SearchableComboBoxView_GLACodeSales.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxView_GLACodeSales.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeSales.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeSales.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeSales.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeSales.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeSales.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeSales.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeSales.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeSales.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeSales.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeSales.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeSales.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeSales.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeSales.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeSales.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeSales.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeSales.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeSales.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeSales.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeSales.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeSales.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeSales.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeSales.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeSales.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeSales.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeSales.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeSales.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeSales.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeSales.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeSales.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeSales.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeSales.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeSales.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeSales.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeSales.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeSales.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeSales.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_GLACodeSales.AutoFilterLookupColumns = False
            Me.SearchableComboBoxView_GLACodeSales.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxView_GLACodeSales.DataSourceClearing = False
            Me.SearchableComboBoxView_GLACodeSales.EnableDisabledRows = False
            Me.SearchableComboBoxView_GLACodeSales.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxView_GLACodeSales.Name = "SearchableComboBoxView_GLACodeSales"
            Me.SearchableComboBoxView_GLACodeSales.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxView_GLACodeSales.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxView_GLACodeSales.OptionsBehavior.Editable = False
            Me.SearchableComboBoxView_GLACodeSales.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxView_GLACodeSales.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxView_GLACodeSales.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxView_GLACodeSales.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxView_GLACodeSales.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxView_GLACodeSales.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxView_GLACodeSales.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxView_GLACodeSales.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxView_GLACodeSales.RunStandardValidation = True
            '
            'LabelGroup_OffsetGLACode
            '
            Me.LabelGroup_OffsetGLACode.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGroup_OffsetGLACode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGroup_OffsetGLACode.Location = New System.Drawing.Point(5, 102)
            Me.LabelGroup_OffsetGLACode.Name = "LabelGroup_OffsetGLACode"
            Me.LabelGroup_OffsetGLACode.Size = New System.Drawing.Size(64, 20)
            Me.LabelGroup_OffsetGLACode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGroup_OffsetGLACode.TabIndex = 6
            Me.LabelGroup_OffsetGLACode.Text = "Offset:"
            '
            'LabelGroup_COSGLACode
            '
            Me.LabelGroup_COSGLACode.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGroup_COSGLACode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGroup_COSGLACode.Location = New System.Drawing.Point(5, 76)
            Me.LabelGroup_COSGLACode.Name = "LabelGroup_COSGLACode"
            Me.LabelGroup_COSGLACode.Size = New System.Drawing.Size(64, 20)
            Me.LabelGroup_COSGLACode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGroup_COSGLACode.TabIndex = 4
            Me.LabelGroup_COSGLACode.Text = "COS:"
            '
            'LabelGroup_SalesGLACode
            '
            Me.LabelGroup_SalesGLACode.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGroup_SalesGLACode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGroup_SalesGLACode.Location = New System.Drawing.Point(5, 50)
            Me.LabelGroup_SalesGLACode.Name = "LabelGroup_SalesGLACode"
            Me.LabelGroup_SalesGLACode.Size = New System.Drawing.Size(64, 20)
            Me.LabelGroup_SalesGLACode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGroup_SalesGLACode.TabIndex = 2
            Me.LabelGroup_SalesGLACode.Text = "Sales:"
            '
            'LabelGroup_AccountsReceivableGLACode
            '
            Me.LabelGroup_AccountsReceivableGLACode.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelGroup_AccountsReceivableGLACode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGroup_AccountsReceivableGLACode.Location = New System.Drawing.Point(5, 24)
            Me.LabelGroup_AccountsReceivableGLACode.Name = "LabelGroup_AccountsReceivableGLACode"
            Me.LabelGroup_AccountsReceivableGLACode.Size = New System.Drawing.Size(64, 20)
            Me.LabelGroup_AccountsReceivableGLACode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGroup_AccountsReceivableGLACode.TabIndex = 0
            Me.LabelGroup_AccountsReceivableGLACode.Text = "A/R:"
            '
            'SearchableComboBoxForm_RecordType
            '
            Me.SearchableComboBoxForm_RecordType.ActiveFilterString = ""
            Me.SearchableComboBoxForm_RecordType.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxForm_RecordType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxForm_RecordType.AutoFillMode = False
            Me.SearchableComboBoxForm_RecordType.BookmarkingEnabled = False
            Me.SearchableComboBoxForm_RecordType.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.EnumObjects
            Me.SearchableComboBoxForm_RecordType.DataSource = Nothing
            Me.SearchableComboBoxForm_RecordType.DisableMouseWheel = True
            Me.SearchableComboBoxForm_RecordType.DisplayName = ""
            Me.SearchableComboBoxForm_RecordType.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxForm_RecordType.Location = New System.Drawing.Point(481, 32)
            Me.SearchableComboBoxForm_RecordType.Name = "SearchableComboBoxForm_RecordType"
            Me.SearchableComboBoxForm_RecordType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxForm_RecordType.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxForm_RecordType.Properties.NullText = "Select"
            Me.SearchableComboBoxForm_RecordType.Properties.ShowClearButton = False
            Me.SearchableComboBoxForm_RecordType.Properties.ValueMember = "Code"
            Me.SearchableComboBoxForm_RecordType.Properties.View = Me.SearchableComboBoxView_Type
            Me.SearchableComboBoxForm_RecordType.SecurityEnabled = True
            Me.SearchableComboBoxForm_RecordType.SelectedValue = Nothing
            Me.SearchableComboBoxForm_RecordType.Size = New System.Drawing.Size(173, 20)
            Me.SearchableComboBoxForm_RecordType.TabIndex = 15
            '
            'SearchableComboBoxView_Type
            '
            Me.SearchableComboBoxView_Type.AFActiveFilterString = ""
            Me.SearchableComboBoxView_Type.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxView_Type.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Type.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Type.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Type.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Type.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Type.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Type.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Type.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Type.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Type.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Type.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Type.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Type.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Type.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Type.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Type.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Type.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Type.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Type.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Type.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Type.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Type.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Type.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Type.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Type.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Type.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Type.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Type.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Type.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Type.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Type.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Type.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Type.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Type.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Type.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Type.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Type.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Type.AutoFilterLookupColumns = False
            Me.SearchableComboBoxView_Type.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxView_Type.DataSourceClearing = False
            Me.SearchableComboBoxView_Type.EnableDisabledRows = False
            Me.SearchableComboBoxView_Type.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxView_Type.Name = "SearchableComboBoxView_Type"
            Me.SearchableComboBoxView_Type.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxView_Type.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxView_Type.OptionsBehavior.Editable = False
            Me.SearchableComboBoxView_Type.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxView_Type.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxView_Type.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxView_Type.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxView_Type.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxView_Type.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxView_Type.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxView_Type.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxView_Type.RunStandardValidation = True
            '
            'LabelForm_Type
            '
            Me.LabelForm_Type.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Type.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Type.Location = New System.Drawing.Point(373, 32)
            Me.LabelForm_Type.Name = "LabelForm_Type"
            Me.LabelForm_Type.Size = New System.Drawing.Size(102, 20)
            Me.LabelForm_Type.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Type.TabIndex = 14
            Me.LabelForm_Type.Text = "Type:"
            '
            'LabelForm_InvoiceDate
            '
            Me.LabelForm_InvoiceDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_InvoiceDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_InvoiceDate.Location = New System.Drawing.Point(373, 58)
            Me.LabelForm_InvoiceDate.Name = "LabelForm_InvoiceDate"
            Me.LabelForm_InvoiceDate.Size = New System.Drawing.Size(102, 20)
            Me.LabelForm_InvoiceDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_InvoiceDate.TabIndex = 16
            Me.LabelForm_InvoiceDate.Text = "Date:"
            '
            'DateTimePickerForm_InvoiceDate
            '
            Me.DateTimePickerForm_InvoiceDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DateTimePickerForm_InvoiceDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerForm_InvoiceDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerForm_InvoiceDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_InvoiceDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerForm_InvoiceDate.ButtonDropDown.Visible = True
            Me.DateTimePickerForm_InvoiceDate.ButtonFreeText.Checked = True
            Me.DateTimePickerForm_InvoiceDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.ShortDate
            Me.DateTimePickerForm_InvoiceDate.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector
            Me.DateTimePickerForm_InvoiceDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerForm_InvoiceDate.DisplayName = ""
            Me.DateTimePickerForm_InvoiceDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.DateTimePickerForm_InvoiceDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerForm_InvoiceDate.FocusHighlightEnabled = True
            Me.DateTimePickerForm_InvoiceDate.FreeTextEntryMode = True
            Me.DateTimePickerForm_InvoiceDate.IsPopupCalendarOpen = False
            Me.DateTimePickerForm_InvoiceDate.Location = New System.Drawing.Point(481, 58)
            Me.DateTimePickerForm_InvoiceDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerForm_InvoiceDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerForm_InvoiceDate.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerForm_InvoiceDate.Name = "DateTimePickerForm_InvoiceDate"
            Me.DateTimePickerForm_InvoiceDate.ReadOnly = False
            Me.DateTimePickerForm_InvoiceDate.Size = New System.Drawing.Size(173, 21)
            Me.DateTimePickerForm_InvoiceDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerForm_InvoiceDate.TabIndex = 17
            Me.DateTimePickerForm_InvoiceDate.Value = New Date(2014, 4, 8, 16, 9, 32, 675)
            '
            'SearchableComboBoxForm_Client
            '
            Me.SearchableComboBoxForm_Client.ActiveFilterString = ""
            Me.SearchableComboBoxForm_Client.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxForm_Client.AutoFillMode = False
            Me.SearchableComboBoxForm_Client.BookmarkingEnabled = False
            Me.SearchableComboBoxForm_Client.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Client
            Me.SearchableComboBoxForm_Client.DataSource = Nothing
            Me.SearchableComboBoxForm_Client.DisableMouseWheel = True
            Me.SearchableComboBoxForm_Client.DisplayName = ""
            Me.SearchableComboBoxForm_Client.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxForm_Client.Location = New System.Drawing.Point(90, 6)
            Me.SearchableComboBoxForm_Client.Name = "SearchableComboBoxForm_Client"
            Me.SearchableComboBoxForm_Client.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxForm_Client.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxForm_Client.Properties.NullText = "Select Client"
            Me.SearchableComboBoxForm_Client.Properties.ShowClearButton = False
            Me.SearchableComboBoxForm_Client.Properties.ValueMember = "Code"
            Me.SearchableComboBoxForm_Client.Properties.View = Me.SearchableComboBoxView_Client
            Me.SearchableComboBoxForm_Client.SecurityEnabled = True
            Me.SearchableComboBoxForm_Client.SelectedValue = Nothing
            Me.SearchableComboBoxForm_Client.Size = New System.Drawing.Size(277, 20)
            Me.SearchableComboBoxForm_Client.TabIndex = 1
            '
            'SearchableComboBoxView_Client
            '
            Me.SearchableComboBoxView_Client.AFActiveFilterString = ""
            Me.SearchableComboBoxView_Client.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxView_Client.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Client.AutoFilterLookupColumns = False
            Me.SearchableComboBoxView_Client.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxView_Client.DataSourceClearing = False
            Me.SearchableComboBoxView_Client.EnableDisabledRows = False
            Me.SearchableComboBoxView_Client.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxView_Client.Name = "SearchableComboBoxView_Client"
            Me.SearchableComboBoxView_Client.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxView_Client.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxView_Client.OptionsBehavior.Editable = False
            Me.SearchableComboBoxView_Client.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxView_Client.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxView_Client.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxView_Client.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxView_Client.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxView_Client.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxView_Client.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxView_Client.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxView_Client.RunStandardValidation = True
            '
            'SearchableComboBoxForm_Office
            '
            Me.SearchableComboBoxForm_Office.ActiveFilterString = ""
            Me.SearchableComboBoxForm_Office.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxForm_Office.AutoFillMode = False
            Me.SearchableComboBoxForm_Office.BookmarkingEnabled = False
            Me.SearchableComboBoxForm_Office.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Office
            Me.SearchableComboBoxForm_Office.DataSource = Nothing
            Me.SearchableComboBoxForm_Office.DisableMouseWheel = True
            Me.SearchableComboBoxForm_Office.DisplayName = ""
            Me.SearchableComboBoxForm_Office.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.None
            Me.SearchableComboBoxForm_Office.Location = New System.Drawing.Point(90, 84)
            Me.SearchableComboBoxForm_Office.Name = "SearchableComboBoxForm_Office"
            Me.SearchableComboBoxForm_Office.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxForm_Office.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxForm_Office.Properties.NullText = "Select Office"
            Me.SearchableComboBoxForm_Office.Properties.ReadOnly = True
            Me.SearchableComboBoxForm_Office.Properties.ShowClearButton = False
            Me.SearchableComboBoxForm_Office.Properties.ValueMember = "Code"
            Me.SearchableComboBoxForm_Office.Properties.View = Me.SearchableComboBoxView_Office
            Me.SearchableComboBoxForm_Office.SecurityEnabled = True
            Me.SearchableComboBoxForm_Office.SelectedValue = Nothing
            Me.SearchableComboBoxForm_Office.Size = New System.Drawing.Size(277, 20)
            Me.SearchableComboBoxForm_Office.TabIndex = 7
            Me.SearchableComboBoxForm_Office.TabStop = False
            '
            'SearchableComboBoxView_Office
            '
            Me.SearchableComboBoxView_Office.AFActiveFilterString = ""
            Me.SearchableComboBoxView_Office.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxView_Office.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Office.AutoFilterLookupColumns = False
            Me.SearchableComboBoxView_Office.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxView_Office.DataSourceClearing = False
            Me.SearchableComboBoxView_Office.EnableDisabledRows = False
            Me.SearchableComboBoxView_Office.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxView_Office.Name = "SearchableComboBoxView_Office"
            Me.SearchableComboBoxView_Office.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxView_Office.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxView_Office.OptionsBehavior.Editable = False
            Me.SearchableComboBoxView_Office.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxView_Office.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxView_Office.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxView_Office.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxView_Office.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxView_Office.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxView_Office.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxView_Office.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxView_Office.RunStandardValidation = True
            '
            'LabelForm_Office
            '
            Me.LabelForm_Office.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Office.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Office.Location = New System.Drawing.Point(3, 84)
            Me.LabelForm_Office.Name = "LabelForm_Office"
            Me.LabelForm_Office.Size = New System.Drawing.Size(81, 20)
            Me.LabelForm_Office.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Office.TabIndex = 6
            Me.LabelForm_Office.Text = "Office:"
            '
            'LabelForm_Product
            '
            Me.LabelForm_Product.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Product.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Product.Location = New System.Drawing.Point(3, 58)
            Me.LabelForm_Product.Name = "LabelForm_Product"
            Me.LabelForm_Product.Size = New System.Drawing.Size(81, 20)
            Me.LabelForm_Product.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Product.TabIndex = 4
            Me.LabelForm_Product.Text = "Product:"
            '
            'SearchableComboBoxForm_Product
            '
            Me.SearchableComboBoxForm_Product.ActiveFilterString = ""
            Me.SearchableComboBoxForm_Product.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxForm_Product.AutoFillMode = False
            Me.SearchableComboBoxForm_Product.BookmarkingEnabled = False
            Me.SearchableComboBoxForm_Product.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Product
            Me.SearchableComboBoxForm_Product.DataSource = Nothing
            Me.SearchableComboBoxForm_Product.DisableMouseWheel = True
            Me.SearchableComboBoxForm_Product.DisplayName = ""
            Me.SearchableComboBoxForm_Product.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxForm_Product.Location = New System.Drawing.Point(90, 58)
            Me.SearchableComboBoxForm_Product.Name = "SearchableComboBoxForm_Product"
            Me.SearchableComboBoxForm_Product.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxForm_Product.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxForm_Product.Properties.NullText = "Select Product"
            Me.SearchableComboBoxForm_Product.Properties.ShowClearButton = False
            Me.SearchableComboBoxForm_Product.Properties.ValueMember = "Code"
            Me.SearchableComboBoxForm_Product.Properties.View = Me.SearchableComboBoxView_Product
            Me.SearchableComboBoxForm_Product.SecurityEnabled = True
            Me.SearchableComboBoxForm_Product.SelectedValue = Nothing
            Me.SearchableComboBoxForm_Product.Size = New System.Drawing.Size(277, 20)
            Me.SearchableComboBoxForm_Product.TabIndex = 5
            '
            'SearchableComboBoxView_Product
            '
            Me.SearchableComboBoxView_Product.AFActiveFilterString = ""
            Me.SearchableComboBoxView_Product.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxView_Product.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Product.AutoFilterLookupColumns = False
            Me.SearchableComboBoxView_Product.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxView_Product.DataSourceClearing = False
            Me.SearchableComboBoxView_Product.EnableDisabledRows = False
            Me.SearchableComboBoxView_Product.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxView_Product.Name = "SearchableComboBoxView_Product"
            Me.SearchableComboBoxView_Product.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxView_Product.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxView_Product.OptionsBehavior.Editable = False
            Me.SearchableComboBoxView_Product.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxView_Product.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxView_Product.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxView_Product.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxView_Product.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxView_Product.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxView_Product.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxView_Product.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxView_Product.RunStandardValidation = True
            '
            'LabelForm_Division
            '
            Me.LabelForm_Division.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Division.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Division.Location = New System.Drawing.Point(3, 32)
            Me.LabelForm_Division.Name = "LabelForm_Division"
            Me.LabelForm_Division.Size = New System.Drawing.Size(81, 20)
            Me.LabelForm_Division.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Division.TabIndex = 2
            Me.LabelForm_Division.Text = "Division:"
            '
            'SearchableComboBoxForm_Division
            '
            Me.SearchableComboBoxForm_Division.ActiveFilterString = ""
            Me.SearchableComboBoxForm_Division.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxForm_Division.AutoFillMode = False
            Me.SearchableComboBoxForm_Division.BookmarkingEnabled = False
            Me.SearchableComboBoxForm_Division.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Division
            Me.SearchableComboBoxForm_Division.DataSource = Nothing
            Me.SearchableComboBoxForm_Division.DisableMouseWheel = True
            Me.SearchableComboBoxForm_Division.DisplayName = ""
            Me.SearchableComboBoxForm_Division.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxForm_Division.Location = New System.Drawing.Point(90, 32)
            Me.SearchableComboBoxForm_Division.Name = "SearchableComboBoxForm_Division"
            Me.SearchableComboBoxForm_Division.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxForm_Division.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxForm_Division.Properties.NullText = "Select Division"
            Me.SearchableComboBoxForm_Division.Properties.ShowClearButton = False
            Me.SearchableComboBoxForm_Division.Properties.ValueMember = "Code"
            Me.SearchableComboBoxForm_Division.Properties.View = Me.SearchableComboBoxView_Division
            Me.SearchableComboBoxForm_Division.SecurityEnabled = True
            Me.SearchableComboBoxForm_Division.SelectedValue = Nothing
            Me.SearchableComboBoxForm_Division.Size = New System.Drawing.Size(277, 20)
            Me.SearchableComboBoxForm_Division.TabIndex = 3
            '
            'SearchableComboBoxView_Division
            '
            Me.SearchableComboBoxView_Division.AFActiveFilterString = ""
            Me.SearchableComboBoxView_Division.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxView_Division.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_Division.AutoFilterLookupColumns = False
            Me.SearchableComboBoxView_Division.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxView_Division.DataSourceClearing = False
            Me.SearchableComboBoxView_Division.EnableDisabledRows = False
            Me.SearchableComboBoxView_Division.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxView_Division.Name = "SearchableComboBoxView_Division"
            Me.SearchableComboBoxView_Division.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxView_Division.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxView_Division.OptionsBehavior.Editable = False
            Me.SearchableComboBoxView_Division.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxView_Division.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxView_Division.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxView_Division.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxView_Division.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxView_Division.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxView_Division.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxView_Division.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxView_Division.RunStandardValidation = True
            '
            'LabelForm_PostPeriod
            '
            Me.LabelForm_PostPeriod.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_PostPeriod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_PostPeriod.Location = New System.Drawing.Point(373, 6)
            Me.LabelForm_PostPeriod.Name = "LabelForm_PostPeriod"
            Me.LabelForm_PostPeriod.Size = New System.Drawing.Size(102, 20)
            Me.LabelForm_PostPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_PostPeriod.TabIndex = 12
            Me.LabelForm_PostPeriod.Text = "Post Period:"
            '
            'TextBoxForm_Description
            '
            Me.TextBoxForm_Description.BackColor = System.Drawing.Color.White
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
            Me.TextBoxForm_Description.ForeColor = System.Drawing.Color.Black
            Me.TextBoxForm_Description.Location = New System.Drawing.Point(90, 136)
            Me.TextBoxForm_Description.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Description.Name = "TextBoxForm_Description"
            Me.TextBoxForm_Description.SecurityEnabled = True
            Me.TextBoxForm_Description.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Description.Size = New System.Drawing.Size(277, 21)
            Me.TextBoxForm_Description.StartingFolderName = Nothing
            Me.TextBoxForm_Description.TabIndex = 11
            Me.TextBoxForm_Description.TabOnEnter = True
            '
            'LabelForm_Description
            '
            Me.LabelForm_Description.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Description.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Description.Location = New System.Drawing.Point(3, 136)
            Me.LabelForm_Description.Name = "LabelForm_Description"
            Me.LabelForm_Description.Size = New System.Drawing.Size(81, 20)
            Me.LabelForm_Description.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Description.TabIndex = 10
            Me.LabelForm_Description.Text = "Description:"
            '
            'LabelForm_Client
            '
            Me.LabelForm_Client.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Client.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Client.Location = New System.Drawing.Point(3, 6)
            Me.LabelForm_Client.Name = "LabelForm_Client"
            Me.LabelForm_Client.Size = New System.Drawing.Size(81, 20)
            Me.LabelForm_Client.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Client.TabIndex = 0
            Me.LabelForm_Client.Text = "Client:"
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Add, Me.ButtonItemActions_Cancel, Me.ButtonItemActions_PrintCurrentBatch, Me.ButtonItemActions_PrintLastInvoice})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(58, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(222, 92)
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
            Me.ButtonItemActions_Add.BeginGroup = True
            Me.ButtonItemActions_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Add.Name = "ButtonItemActions_Add"
            Me.ButtonItemActions_Add.RibbonWordWrap = False
            Me.ButtonItemActions_Add.SecurityEnabled = True
            Me.ButtonItemActions_Add.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Add.Text = "Add"
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
            'ButtonItemActions_PrintCurrentBatch
            '
            Me.ButtonItemActions_PrintCurrentBatch.BeginGroup = True
            Me.ButtonItemActions_PrintCurrentBatch.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_PrintCurrentBatch.Name = "ButtonItemActions_PrintCurrentBatch"
            Me.ButtonItemActions_PrintCurrentBatch.RibbonWordWrap = False
            Me.ButtonItemActions_PrintCurrentBatch.SecurityEnabled = True
            Me.ButtonItemActions_PrintCurrentBatch.SubItemsExpandWidth = 14
            Me.ButtonItemActions_PrintCurrentBatch.Text = "Print Current Batch"
            '
            'ButtonItemActions_PrintLastInvoice
            '
            Me.ButtonItemActions_PrintLastInvoice.BeginGroup = True
            Me.ButtonItemActions_PrintLastInvoice.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_PrintLastInvoice.Name = "ButtonItemActions_PrintLastInvoice"
            Me.ButtonItemActions_PrintLastInvoice.RibbonWordWrap = False
            Me.ButtonItemActions_PrintLastInvoice.SecurityEnabled = True
            Me.ButtonItemActions_PrintLastInvoice.SubItemsExpandWidth = 14
            Me.ButtonItemActions_PrintLastInvoice.Text = "Print Last Invoice"
            '
            'GroupBoxPanel_Amounts
            '
            Me.GroupBoxPanel_Amounts.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxPanel_Amounts.Controls.Add(Me.NumericInputForm_InvoiceAmount)
            Me.GroupBoxPanel_Amounts.Controls.Add(Me.NumericInputDisbursedTo_City)
            Me.GroupBoxPanel_Amounts.Controls.Add(Me.LabelDisbursedTo_State)
            Me.GroupBoxPanel_Amounts.Controls.Add(Me.LabelDisbursedTo_COS)
            Me.GroupBoxPanel_Amounts.Controls.Add(Me.NumericInputDisbursedTo_COS)
            Me.GroupBoxPanel_Amounts.Controls.Add(Me.LabelDisbursedTo_County)
            Me.GroupBoxPanel_Amounts.Controls.Add(Me.LabelForm_InvoiceAmount)
            Me.GroupBoxPanel_Amounts.Controls.Add(Me.LabelDisbursedTo_City)
            Me.GroupBoxPanel_Amounts.Controls.Add(Me.LabelDisbursedTo_GrossProfit)
            Me.GroupBoxPanel_Amounts.Controls.Add(Me.NumericInputDisbursedTo_State)
            Me.GroupBoxPanel_Amounts.Controls.Add(Me.NumericInputDisbursedTo_GrossProfit)
            Me.GroupBoxPanel_Amounts.Controls.Add(Me.LabelDisbursedTo_Sales)
            Me.GroupBoxPanel_Amounts.Controls.Add(Me.NumericInputDisbursedTo_County)
            Me.GroupBoxPanel_Amounts.Controls.Add(Me.NumericInputDisbursedTo_Sales)
            Me.GroupBoxPanel_Amounts.Location = New System.Drawing.Point(3, 162)
            Me.GroupBoxPanel_Amounts.Name = "GroupBoxPanel_Amounts"
            Me.GroupBoxPanel_Amounts.Size = New System.Drawing.Size(238, 236)
            Me.GroupBoxPanel_Amounts.TabIndex = 18
            Me.GroupBoxPanel_Amounts.Text = "Amounts"
            '
            'SearchableComboBoxForm_PostPeriod
            '
            Me.SearchableComboBoxForm_PostPeriod.ActiveFilterString = ""
            Me.SearchableComboBoxForm_PostPeriod.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxForm_PostPeriod.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxForm_PostPeriod.AutoFillMode = False
            Me.SearchableComboBoxForm_PostPeriod.BookmarkingEnabled = False
            Me.SearchableComboBoxForm_PostPeriod.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.PostPeriod
            Me.SearchableComboBoxForm_PostPeriod.DataSource = Nothing
            Me.SearchableComboBoxForm_PostPeriod.DisableMouseWheel = True
            Me.SearchableComboBoxForm_PostPeriod.DisplayName = ""
            Me.SearchableComboBoxForm_PostPeriod.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxForm_PostPeriod.Location = New System.Drawing.Point(481, 6)
            Me.SearchableComboBoxForm_PostPeriod.Name = "SearchableComboBoxForm_PostPeriod"
            Me.SearchableComboBoxForm_PostPeriod.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxForm_PostPeriod.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxForm_PostPeriod.Properties.NullText = "Select Post Period"
            Me.SearchableComboBoxForm_PostPeriod.Properties.ShowClearButton = False
            Me.SearchableComboBoxForm_PostPeriod.Properties.ValueMember = "Code"
            Me.SearchableComboBoxForm_PostPeriod.Properties.View = Me.SearchableComboBoxView_PostPeriod
            Me.SearchableComboBoxForm_PostPeriod.SecurityEnabled = True
            Me.SearchableComboBoxForm_PostPeriod.SelectedValue = Nothing
            Me.SearchableComboBoxForm_PostPeriod.Size = New System.Drawing.Size(173, 20)
            Me.SearchableComboBoxForm_PostPeriod.TabIndex = 13
            '
            'SearchableComboBoxView_PostPeriod
            '
            Me.SearchableComboBoxView_PostPeriod.AFActiveFilterString = ""
            Me.SearchableComboBoxView_PostPeriod.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxView_PostPeriod.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_PostPeriod.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_PostPeriod.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_PostPeriod.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_PostPeriod.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_PostPeriod.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_PostPeriod.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_PostPeriod.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_PostPeriod.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_PostPeriod.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_PostPeriod.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_PostPeriod.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_PostPeriod.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_PostPeriod.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_PostPeriod.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_PostPeriod.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_PostPeriod.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_PostPeriod.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_PostPeriod.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_PostPeriod.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_PostPeriod.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_PostPeriod.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_PostPeriod.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_PostPeriod.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_PostPeriod.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_PostPeriod.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_PostPeriod.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_PostPeriod.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_PostPeriod.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_PostPeriod.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_PostPeriod.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_PostPeriod.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_PostPeriod.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_PostPeriod.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_PostPeriod.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_PostPeriod.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_PostPeriod.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxView_PostPeriod.AutoFilterLookupColumns = False
            Me.SearchableComboBoxView_PostPeriod.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxView_PostPeriod.DataSourceClearing = False
            Me.SearchableComboBoxView_PostPeriod.EnableDisabledRows = False
            Me.SearchableComboBoxView_PostPeriod.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxView_PostPeriod.Name = "SearchableComboBoxView_PostPeriod"
            Me.SearchableComboBoxView_PostPeriod.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxView_PostPeriod.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxView_PostPeriod.OptionsBehavior.Editable = False
            Me.SearchableComboBoxView_PostPeriod.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxView_PostPeriod.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxView_PostPeriod.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxView_PostPeriod.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxView_PostPeriod.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxView_PostPeriod.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxView_PostPeriod.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxView_PostPeriod.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxView_PostPeriod.RunStandardValidation = True
            '
            'ClientInvoiceNewDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(667, 579)
            Me.CloseButtonVisible = False
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "ClientInvoiceNewDialog"
            Me.Text = "Add New Manual Client Invoice"
            Me.Controls.SetChildIndex(Me.BarForm_StatusBar, 0)
            Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
            Me.Controls.SetChildIndex(Me.PanelForm_Form, 0)
            Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.PerformLayout()
            Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Form.ResumeLayout(False)
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputForm_InvoiceAmount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxForm_SalesClass.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxView_SalesClass, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputDisbursedTo_City.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputDisbursedTo_COS.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputDisbursedTo_State.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputDisbursedTo_County.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputDisbursedTo_Sales.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputDisbursedTo_GrossProfit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxForm_AccountCodes, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxForm_AccountCodes.ResumeLayout(False)
            CType(Me.SearchableComboBoxGroup_CityTaxGLACode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxView_GLACodeCity, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxGroup_CountyTaxGLACode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxView_GLACodeCounty, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxGroup_StateTaxGLACode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxView_GLACodeState, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxGroup_ARGLACode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxView_GLACodeAR, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxGroup_OffsetGLACode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxView_GLACodeOffset, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxGroup_COSGLACode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxView_GLACodeCOS, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxGroup_SalesGLACode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxView_GLACodeSales, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxForm_RecordType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxView_Type, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerForm_InvoiceDate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxForm_Client.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxView_Client, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxForm_Office.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxView_Office, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxForm_Product.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxView_Product, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxForm_Division.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxView_Division, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxPanel_Amounts, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxPanel_Amounts.ResumeLayout(False)
            CType(Me.SearchableComboBoxForm_PostPeriod.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxView_PostPeriod, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents NumericInputForm_InvoiceAmount As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents SearchableComboBoxForm_SalesClass As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxView_SalesClass As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents LabelForm_SalesClass As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents NumericInputDisbursedTo_City As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputDisbursedTo_COS As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputDisbursedTo_State As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputDisbursedTo_County As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents NumericInputDisbursedTo_Sales As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents LabelDisbursedTo_Sales As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents NumericInputDisbursedTo_GrossProfit As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
        Friend WithEvents LabelDisbursedTo_GrossProfit As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelDisbursedTo_City As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelDisbursedTo_County As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelDisbursedTo_COS As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelDisbursedTo_State As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_InvoiceAmount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxForm_AccountCodes As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents SearchableComboBoxGroup_CityTaxGLACode As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxView_GLACodeCity As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxGroup_CountyTaxGLACode As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxView_GLACodeCounty As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxGroup_StateTaxGLACode As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxView_GLACodeState As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents LabelGroup_CityTaxGLACode As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelGroup_CountyTaxGLACode As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelGroup_StateTaxGLACode As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxGroup_ARGLACode As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxView_GLACodeAR As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxGroup_OffsetGLACode As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxView_GLACodeOffset As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxGroup_COSGLACode As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxView_GLACodeCOS As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxGroup_SalesGLACode As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxView_GLACodeSales As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents LabelGroup_OffsetGLACode As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelGroup_COSGLACode As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelGroup_SalesGLACode As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelGroup_AccountsReceivableGLACode As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxForm_RecordType As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxView_Type As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents LabelForm_Type As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_InvoiceDate As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents DateTimePickerForm_InvoiceDate As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents SearchableComboBoxForm_Client As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxView_Client As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxForm_Office As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxView_Office As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents LabelForm_Office As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Product As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxForm_Product As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxView_Product As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents LabelForm_Division As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxForm_Division As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxView_Division As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents LabelForm_PostPeriod As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_Description As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelForm_Description As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Client As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Add As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_PrintCurrentBatch As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_PrintLastInvoice As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents GroupBoxPanel_Amounts As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents SearchableComboBoxForm_PostPeriod As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxView_PostPeriod As AdvantageFramework.WinForm.Presentation.Controls.GridView
    End Class

End Namespace