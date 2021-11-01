Namespace FinanceAndAccounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ClientCashReceiptEditDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ClientCashReceiptEditDialog))
            Me.ClientCashReceiptControlForm_CCR = New AdvantageFramework.WinForm.Presentation.Controls.ClientCashReceiptControl()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Add = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Writeoff = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemWriteoff_Apply = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemWriteoff_Undo = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Payment = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemPayment_Apply = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemPayment_Partial = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemPayment_Undo = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_OnAccount = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemOnAccount_Apply = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemOnAccount_Undo = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Form.SuspendLayout()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'RibbonControlForm_MainRibbon
            '
            '
            '
            '
            Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(1011, 154)
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
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Writeoff)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_OnAccount)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Payment)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 57)
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(1011, 94)
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
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarFilePanel_System, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Actions, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Payment, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_OnAccount, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Writeoff, 0)
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
            'PanelForm_Form
            '
            Me.PanelForm_Form.Controls.Add(Me.ClientCashReceiptControlForm_CCR)
            Me.PanelForm_Form.Size = New System.Drawing.Size(1011, 489)
            '
            'BarForm_StatusBar
            '
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 644)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(1011, 18)
            '
            'ClientCashReceiptControlForm_CCR
            '
            Me.ClientCashReceiptControlForm_CCR.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ClientCashReceiptControlForm_CCR.Location = New System.Drawing.Point(3, 6)
            Me.ClientCashReceiptControlForm_CCR.Name = "ClientCashReceiptControlForm_CCR"
            Me.ClientCashReceiptControlForm_CCR.Size = New System.Drawing.Size(1005, 477)
            Me.ClientCashReceiptControlForm_CCR.TabIndex = 0
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Add, Me.ButtonItemActions_Cancel})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(103, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(100, 92)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 2
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
            'RibbonBarOptions_Writeoff
            '
            Me.RibbonBarOptions_Writeoff.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBarOptions_Writeoff.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Writeoff.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Writeoff.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Writeoff.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Writeoff.DragDropSupport = True
            Me.RibbonBarOptions_Writeoff.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemWriteoff_Apply, Me.ButtonItemWriteoff_Undo})
            Me.RibbonBarOptions_Writeoff.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Writeoff.Location = New System.Drawing.Point(420, 0)
            Me.RibbonBarOptions_Writeoff.Name = "RibbonBarOptions_Writeoff"
            Me.RibbonBarOptions_Writeoff.SecurityEnabled = True
            Me.RibbonBarOptions_Writeoff.Size = New System.Drawing.Size(94, 92)
            Me.RibbonBarOptions_Writeoff.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Writeoff.TabIndex = 14
            Me.RibbonBarOptions_Writeoff.Text = "Write Off"
            '
            '
            '
            Me.RibbonBarOptions_Writeoff.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Writeoff.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Writeoff.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemWriteoff_Apply
            '
            Me.ButtonItemWriteoff_Apply.BeginGroup = True
            Me.ButtonItemWriteoff_Apply.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemWriteoff_Apply.Name = "ButtonItemWriteoff_Apply"
            Me.ButtonItemWriteoff_Apply.RibbonWordWrap = False
            Me.ButtonItemWriteoff_Apply.SecurityEnabled = True
            Me.ButtonItemWriteoff_Apply.SubItemsExpandWidth = 14
            Me.ButtonItemWriteoff_Apply.Text = "Apply"
            '
            'ButtonItemWriteoff_Undo
            '
            Me.ButtonItemWriteoff_Undo.BeginGroup = True
            Me.ButtonItemWriteoff_Undo.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemWriteoff_Undo.Name = "ButtonItemWriteoff_Undo"
            Me.ButtonItemWriteoff_Undo.RibbonWordWrap = False
            Me.ButtonItemWriteoff_Undo.SecurityEnabled = True
            Me.ButtonItemWriteoff_Undo.SubItemsExpandWidth = 14
            Me.ButtonItemWriteoff_Undo.Text = "Undo"
            '
            'RibbonBarOptions_Payment
            '
            Me.RibbonBarOptions_Payment.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBarOptions_Payment.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Payment.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Payment.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Payment.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Payment.DragDropSupport = True
            Me.RibbonBarOptions_Payment.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemPayment_Apply, Me.ButtonItemPayment_Partial, Me.ButtonItemPayment_Undo})
            Me.RibbonBarOptions_Payment.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Payment.Location = New System.Drawing.Point(203, 0)
            Me.RibbonBarOptions_Payment.Name = "RibbonBarOptions_Payment"
            Me.RibbonBarOptions_Payment.SecurityEnabled = True
            Me.RibbonBarOptions_Payment.Size = New System.Drawing.Size(130, 92)
            Me.RibbonBarOptions_Payment.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Payment.TabIndex = 13
            Me.RibbonBarOptions_Payment.Text = "Payment"
            '
            '
            '
            Me.RibbonBarOptions_Payment.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Payment.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Payment.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemPayment_Apply
            '
            Me.ButtonItemPayment_Apply.BeginGroup = True
            Me.ButtonItemPayment_Apply.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemPayment_Apply.Name = "ButtonItemPayment_Apply"
            Me.ButtonItemPayment_Apply.RibbonWordWrap = False
            Me.ButtonItemPayment_Apply.SecurityEnabled = True
            Me.ButtonItemPayment_Apply.SubItemsExpandWidth = 14
            Me.ButtonItemPayment_Apply.Text = "Apply"
            '
            'ButtonItemPayment_Partial
            '
            Me.ButtonItemPayment_Partial.BeginGroup = True
            Me.ButtonItemPayment_Partial.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemPayment_Partial.Name = "ButtonItemPayment_Partial"
            Me.ButtonItemPayment_Partial.RibbonWordWrap = False
            Me.ButtonItemPayment_Partial.SecurityEnabled = True
            Me.ButtonItemPayment_Partial.SubItemsExpandWidth = 14
            Me.ButtonItemPayment_Partial.Text = "Partial"
            '
            'ButtonItemPayment_Undo
            '
            Me.ButtonItemPayment_Undo.BeginGroup = True
            Me.ButtonItemPayment_Undo.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemPayment_Undo.Name = "ButtonItemPayment_Undo"
            Me.ButtonItemPayment_Undo.RibbonWordWrap = False
            Me.ButtonItemPayment_Undo.SecurityEnabled = True
            Me.ButtonItemPayment_Undo.SubItemsExpandWidth = 14
            Me.ButtonItemPayment_Undo.Text = "Undo"
            '
            'RibbonBarOptions_OnAccount
            '
            Me.RibbonBarOptions_OnAccount.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBarOptions_OnAccount.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_OnAccount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_OnAccount.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_OnAccount.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_OnAccount.DragDropSupport = True
            Me.RibbonBarOptions_OnAccount.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemOnAccount_Apply, Me.ButtonItemOnAccount_Undo})
            Me.RibbonBarOptions_OnAccount.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_OnAccount.Location = New System.Drawing.Point(333, 0)
            Me.RibbonBarOptions_OnAccount.Name = "RibbonBarOptions_OnAccount"
            Me.RibbonBarOptions_OnAccount.SecurityEnabled = True
            Me.RibbonBarOptions_OnAccount.Size = New System.Drawing.Size(87, 92)
            Me.RibbonBarOptions_OnAccount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_OnAccount.TabIndex = 15
            Me.RibbonBarOptions_OnAccount.Text = "On Account"
            '
            '
            '
            Me.RibbonBarOptions_OnAccount.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_OnAccount.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_OnAccount.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemOnAccount_Apply
            '
            Me.ButtonItemOnAccount_Apply.BeginGroup = True
            Me.ButtonItemOnAccount_Apply.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemOnAccount_Apply.Name = "ButtonItemOnAccount_Apply"
            Me.ButtonItemOnAccount_Apply.RibbonWordWrap = False
            Me.ButtonItemOnAccount_Apply.SecurityEnabled = True
            Me.ButtonItemOnAccount_Apply.SubItemsExpandWidth = 14
            Me.ButtonItemOnAccount_Apply.Text = "Apply"
            '
            'ButtonItemOnAccount_Undo
            '
            Me.ButtonItemOnAccount_Undo.BeginGroup = True
            Me.ButtonItemOnAccount_Undo.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemOnAccount_Undo.Name = "ButtonItemOnAccount_Undo"
            Me.ButtonItemOnAccount_Undo.RibbonWordWrap = False
            Me.ButtonItemOnAccount_Undo.SecurityEnabled = True
            Me.ButtonItemOnAccount_Undo.SubItemsExpandWidth = 14
            Me.ButtonItemOnAccount_Undo.Text = "Undo"
            '
            'ClientCashReceiptEditDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1021, 664)
            Me.CloseButtonVisible = False
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "ClientCashReceiptEditDialog"
            Me.Text = "Client Cash Receipt"
            Me.Controls.SetChildIndex(Me.BarForm_StatusBar, 0)
            Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
            Me.Controls.SetChildIndex(Me.PanelForm_Form, 0)
            Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.PerformLayout()
            Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Form.ResumeLayout(False)
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ClientCashReceiptControlForm_CCR As AdvantageFramework.WinForm.Presentation.Controls.ClientCashReceiptControl
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Add As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Writeoff As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents RibbonBarOptions_Payment As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents RibbonBarOptions_OnAccount As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemOnAccount_Apply As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemOnAccount_Undo As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemPayment_Partial As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemWriteoff_Apply As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemWriteoff_Undo As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemPayment_Apply As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemPayment_Undo As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
    End Class

End Namespace