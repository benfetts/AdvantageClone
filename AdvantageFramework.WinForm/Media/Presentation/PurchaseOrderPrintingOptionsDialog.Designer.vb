Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class PurchaseOrderPrintingOptionsDialog
        Inherits AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseRibbonForm

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
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PurchaseOrderPrintingOptionsDialog))
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.VerticalGridPurchaseOrder_Settings = New AdvantageFramework.WinForm.MVC.Presentation.Controls.VerticalGrid()
            Me.PurchaseOrderPrintSettingBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.categoryPrintOptions = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowLocationID = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowDateOverride = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.categoryReportFormat = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowReportFormat = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.categoryCommentOptions = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowPOInstructions = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowShippingIntructions = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowDetailDescription = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowDetailInstructions = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowFooterComment = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.categoryOther = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowVendorCode = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowVendorContact = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowClientName = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowProductName = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowJobNumberComponent = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowJobDescription = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowFunctionDescription = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowExcludeEmployeeSignature = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowUseLoggedInUserSignature = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Form.SuspendLayout()
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.VerticalGridPurchaseOrder_Settings, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PurchaseOrderPrintSettingBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            '_DefaultLookAndFeel
            '
            Me._DefaultLookAndFeel.LookAndFeel.SkinName = "Office 2016 Colorful"
            '
            'PanelForm_Form
            '
            Me.PanelForm_Form.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelForm_Form.Appearance.Options.UseBackColor = True
            Me.PanelForm_Form.Controls.Add(Me.VerticalGridPurchaseOrder_Settings)
            Me.PanelForm_Form.LookAndFeel.SkinName = "Office 2013"
            Me.PanelForm_Form.LookAndFeel.UseDefaultLookAndFeel = False
            Me.PanelForm_Form.Size = New System.Drawing.Size(703, 314)
            Me.PanelForm_Form.TabIndex = 0
            '
            'RibbonControlForm_MainRibbon
            '
            '
            '
            '
            Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonControlForm_MainRibbon.Margin = New System.Windows.Forms.Padding(4)
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(703, 154)
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
            Me.RibbonControlForm_MainRibbon.Controls.SetChildIndex(Me.RibbonPanelFile_FilePanel, 0)
            '
            'RibbonPanelFile_FilePanel
            '
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 57)
            Me.RibbonPanelFile_FilePanel.Margin = New System.Windows.Forms.Padding(4)
            Me.RibbonPanelFile_FilePanel.Padding = New System.Windows.Forms.Padding(4, 0, 4, 2)
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(703, 94)
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
            Me.RibbonPanelFile_FilePanel.Visible = True
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
            Me.RibbonBarFilePanel_System.Location = New System.Drawing.Point(4, 0)
            Me.RibbonBarFilePanel_System.Margin = New System.Windows.Forms.Padding(4)
            Me.RibbonBarFilePanel_System.Size = New System.Drawing.Size(100, 92)
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
            'Office2007StartButtonMainRibbon_Home
            '
            Me.Office2007StartButtonMainRibbon_Home.Image = CType(resources.GetObject("Office2007StartButtonMainRibbon_Home.Image"), System.Drawing.Image)
            '
            'ProgressBarItemStatusBar_ProgressBar
            '
            '
            '
            '
            Me.ProgressBarItemStatusBar_ProgressBar.BackStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'BarForm_StatusBar
            '
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 469)
            Me.BarForm_StatusBar.Margin = New System.Windows.Forms.Padding(4)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(703, 18)
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Save, Me.ButtonItemActions_Cancel})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(104, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(142, 92)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 13
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
            'ButtonItemActions_Save
            '
            Me.ButtonItemActions_Save.BeginGroup = True
            Me.ButtonItemActions_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Save.Name = "ButtonItemActions_Save"
            Me.ButtonItemActions_Save.RibbonWordWrap = False
            Me.ButtonItemActions_Save.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Save.Text = "Save"
            '
            'ButtonItemActions_Cancel
            '
            Me.ButtonItemActions_Cancel.BeginGroup = True
            Me.ButtonItemActions_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Cancel.Name = "ButtonItemActions_Cancel"
            Me.ButtonItemActions_Cancel.RibbonWordWrap = False
            Me.ButtonItemActions_Cancel.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Cancel.Text = "Cancel"
            '
            'VerticalGridPurchaseOrder_Settings
            '
            Me.VerticalGridPurchaseOrder_Settings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.VerticalGridPurchaseOrder_Settings.Appearance.RowHeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            Me.VerticalGridPurchaseOrder_Settings.Appearance.RowHeaderPanel.Options.UseFont = True
            Me.VerticalGridPurchaseOrder_Settings.Cursor = System.Windows.Forms.Cursors.Default
            Me.VerticalGridPurchaseOrder_Settings.CustomizationFormBounds = New System.Drawing.Rectangle(1384, 433, 216, 265)
            Me.VerticalGridPurchaseOrder_Settings.DataSource = Me.PurchaseOrderPrintSettingBindingSource
            Me.VerticalGridPurchaseOrder_Settings.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView
            Me.VerticalGridPurchaseOrder_Settings.Location = New System.Drawing.Point(12, 7)
            Me.VerticalGridPurchaseOrder_Settings.Name = "VerticalGridPurchaseOrder_Settings"
            Me.VerticalGridPurchaseOrder_Settings.OptionsBehavior.RecordsMouseWheel = True
            Me.VerticalGridPurchaseOrder_Settings.OptionsBehavior.ResizeRowHeaders = False
            Me.VerticalGridPurchaseOrder_Settings.OptionsBehavior.UseEnterAsTab = True
            Me.VerticalGridPurchaseOrder_Settings.OptionsMenu.EnableContextMenu = True
            Me.VerticalGridPurchaseOrder_Settings.Rows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.categoryPrintOptions, Me.categoryReportFormat, Me.categoryCommentOptions, Me.categoryOther})
            Me.VerticalGridPurchaseOrder_Settings.ShowButtonMode = DevExpress.XtraVerticalGrid.ShowButtonModeEnum.ShowAlways
            Me.VerticalGridPurchaseOrder_Settings.Size = New System.Drawing.Size(679, 300)
            Me.VerticalGridPurchaseOrder_Settings.TabIndex = 2
            Me.VerticalGridPurchaseOrder_Settings.TreeButtonStyle = DevExpress.XtraVerticalGrid.TreeButtonStyle.TreeView
            '
            'PurchaseOrderPrintSettingBindingSource
            '
            Me.PurchaseOrderPrintSettingBindingSource.DataSource = GetType(AdvantageFramework.DTO.PurchaseOrderPrintDefault)
            '
            'categoryPrintOptions
            '
            Me.categoryPrintOptions.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowLocationID, Me.rowDateOverride})
            Me.categoryPrintOptions.Name = "categoryPrintOptions"
            Me.categoryPrintOptions.Properties.Caption = "Print Options"
            '
            'rowLocationID
            '
            Me.rowLocationID.Name = "rowLocationID"
            Me.rowLocationID.Properties.Caption = "Location"
            Me.rowLocationID.Properties.FieldName = "LocationID"
            '
            'rowDateOverride
            '
            Me.rowDateOverride.Name = "rowDateOverride"
            Me.rowDateOverride.Properties.Caption = "Date Override"
            Me.rowDateOverride.Properties.FieldName = "DateToPrint"
            '
            'categoryReportFormat
            '
            Me.categoryReportFormat.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowReportFormat})
            Me.categoryReportFormat.Name = "categoryReportFormat"
            Me.categoryReportFormat.Properties.Caption = "Report Format"
            '
            'rowReportFormat
            '
            Me.rowReportFormat.Name = "rowReportFormat"
            Me.rowReportFormat.Properties.Caption = "Report Format"
            Me.rowReportFormat.Properties.FieldName = "ReportFormat"
            '
            'categoryCommentOptions
            '
            Me.categoryCommentOptions.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowPOInstructions, Me.rowShippingIntructions, Me.rowDetailDescription, Me.rowDetailInstructions, Me.rowFooterComment})
            Me.categoryCommentOptions.Name = "categoryCommentOptions"
            Me.categoryCommentOptions.Properties.Caption = "Comment Options"
            '
            'rowPOInstructions
            '
            Me.rowPOInstructions.Name = "rowPOInstructions"
            Me.rowPOInstructions.Properties.Caption = "PO Instructions"
            Me.rowPOInstructions.Properties.FieldName = "PurchaseOrderInstructions"
            '
            'rowShippingIntructions
            '
            Me.rowShippingIntructions.Name = "rowShippingIntructions"
            Me.rowShippingIntructions.Properties.Caption = "Shipping Instructions"
            Me.rowShippingIntructions.Properties.FieldName = "ShippingInstructions"
            '
            'rowDetailDescription
            '
            Me.rowDetailDescription.Name = "rowDetailDescription"
            Me.rowDetailDescription.Properties.Caption = "Detail Description"
            Me.rowDetailDescription.Properties.FieldName = "DetailDescription"
            '
            'rowDetailInstructions
            '
            Me.rowDetailInstructions.Name = "rowDetailInstructions"
            Me.rowDetailInstructions.Properties.Caption = "Detail Instructions"
            Me.rowDetailInstructions.Properties.FieldName = "DetailInstruction"
            '
            'rowFooterComment
            '
            Me.rowFooterComment.Name = "rowFooterComment"
            Me.rowFooterComment.Properties.Caption = "Footer Comment"
            Me.rowFooterComment.Properties.FieldName = "FooterComment"
            '
            'categoryOther
            '
            Me.categoryOther.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowVendorCode, Me.rowVendorContact, Me.rowClientName, Me.rowProductName, Me.rowJobNumberComponent, Me.rowJobDescription, Me.rowFunctionDescription, Me.rowExcludeEmployeeSignature, Me.rowUseLoggedInUserSignature})
            Me.categoryOther.Name = "categoryOther"
            Me.categoryOther.Properties.Caption = "Other"
            '
            'rowVendorCode
            '
            Me.rowVendorCode.Name = "rowVendorCode"
            Me.rowVendorCode.Properties.Caption = "Vendor Code"
            Me.rowVendorCode.Properties.FieldName = "VendorCode"
            '
            'rowVendorContact
            '
            Me.rowVendorContact.Name = "rowVendorContact"
            Me.rowVendorContact.Properties.Caption = "Vendor Contact"
            Me.rowVendorContact.Properties.FieldName = "VendorContact"
            '
            'rowClientName
            '
            Me.rowClientName.Name = "rowClientName"
            Me.rowClientName.Properties.Caption = "Client Name"
            Me.rowClientName.Properties.FieldName = "ClientName"
            '
            'rowProductName
            '
            Me.rowProductName.Name = "rowProductName"
            Me.rowProductName.Properties.Caption = "Product Name"
            Me.rowProductName.Properties.FieldName = "ProductName"
            '
            'rowJobNumberComponent
            '
            Me.rowJobNumberComponent.Name = "rowJobNumberComponent"
            Me.rowJobNumberComponent.Properties.Caption = "Job Number / Component"
            Me.rowJobNumberComponent.Properties.FieldName = "JobComponentNumber"
            '
            'rowJobDescription
            '
            Me.rowJobDescription.Name = "rowJobDescription"
            Me.rowJobDescription.Properties.Caption = "Job Description"
            Me.rowJobDescription.Properties.FieldName = "JobDescription"
            '
            'rowFunctionDescription
            '
            Me.rowFunctionDescription.Name = "rowFunctionDescription"
            Me.rowFunctionDescription.Properties.Caption = "Function Description"
            Me.rowFunctionDescription.Properties.FieldName = "FunctionDescription"
            '
            'rowExcludeEmployeeSignature
            '
            Me.rowExcludeEmployeeSignature.Name = "rowExcludeEmployeeSignature"
            Me.rowExcludeEmployeeSignature.Properties.Caption = "Exclude Employee Signature"
            Me.rowExcludeEmployeeSignature.Properties.FieldName = "UseEmployeeSignature"
            '
            'rowUseLoggedInUserSignature
            '
            Me.rowUseLoggedInUserSignature.Name = "rowUseLoggedInUserSignature"
            Me.rowUseLoggedInUserSignature.Properties.Caption = "Use Logged In User Signature"
            Me.rowUseLoggedInUserSignature.Properties.FieldName = "UseUserSignature"
            '
            'PurchaseOrderPrintingOptionsDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(713, 489)
            Me.CloseButtonVisible = False
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(4)
            Me.Name = "PurchaseOrderPrintingOptionsDialog"
            Me.Text = "Purchase Order Printing Options"
            Me.Controls.SetChildIndex(Me.BarForm_StatusBar, 0)
            Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
            Me.Controls.SetChildIndex(Me.PanelForm_Form, 0)
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Form.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.PerformLayout()
            Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.VerticalGridPurchaseOrder_Settings, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PurchaseOrderPrintSettingBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Private WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemActions_Save As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemActions_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents VerticalGridPurchaseOrder_Settings As WinForm.MVC.Presentation.Controls.VerticalGrid
        Friend WithEvents PurchaseOrderPrintSettingBindingSource As Windows.Forms.BindingSource
        Friend WithEvents categoryPrintOptions As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowLocationID As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents categoryReportFormat As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowReportFormat As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents categoryCommentOptions As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowPOInstructions As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowShippingIntructions As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents categoryOther As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowVendorCode As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowVendorContact As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowClientName As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowProductName As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowJobNumberComponent As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowJobDescription As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowFunctionDescription As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowExcludeEmployeeSignature As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowUseLoggedInUserSignature As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowFooterComment As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowDetailInstructions As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowDetailDescription As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowDateOverride As DevExpress.XtraVerticalGrid.Rows.EditorRow
    End Class

End Namespace

