Namespace Billing.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class BillingCommandCenterMediaBillingHistoryDialog
        Inherits WinForm.Presentation.BaseForms.BaseRibbonForm

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BillingCommandCenterMediaBillingHistoryDialog))
            Me.RibbonBarOptions_Filter = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemFilter_All = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemFilter_SelectedLineItem = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Documents = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemDocuments_Download = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Export = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.MediaBillingHistoryControl_BillingInvoices = New AdvantageFramework.WinForm.Presentation.Controls.MediaBillingHistoryControl()
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
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(982, 154)
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
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Filter)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Documents)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 57)
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(982, 94)
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
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Documents, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Filter, 0)
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
            Me.RibbonBarFilePanel_System.Size = New System.Drawing.Size(52, 92)
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
            Me.Office2007StartButtonMainRibbon_Home.ImagePaddingVertical = 0
            '
            'PanelForm_Form
            '
            Me.PanelForm_Form.Controls.Add(Me.MediaBillingHistoryControl_BillingInvoices)
            Me.PanelForm_Form.Size = New System.Drawing.Size(982, 555)
            Me.PanelForm_Form.TabIndex = 1
            '
            'BarForm_StatusBar
            '
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 710)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(982, 18)
            '
            'RibbonBarOptions_Filter
            '
            Me.RibbonBarOptions_Filter.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Filter.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Filter.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Filter.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Filter.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Filter.DragDropSupport = True
            Me.RibbonBarOptions_Filter.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemFilter_All, Me.ButtonItemFilter_SelectedLineItem})
            Me.RibbonBarOptions_Filter.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Filter.Location = New System.Drawing.Point(183, 0)
            Me.RibbonBarOptions_Filter.Name = "RibbonBarOptions_Filter"
            Me.RibbonBarOptions_Filter.SecurityEnabled = True
            Me.RibbonBarOptions_Filter.Size = New System.Drawing.Size(150, 92)
            Me.RibbonBarOptions_Filter.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Filter.TabIndex = 2
            Me.RibbonBarOptions_Filter.Text = "Filter"
            '
            '
            '
            Me.RibbonBarOptions_Filter.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Filter.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Filter.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            Me.RibbonBarOptions_Filter.Visible = False
            '
            'ButtonItemFilter_All
            '
            Me.ButtonItemFilter_All.AutoCheckOnClick = True
            Me.ButtonItemFilter_All.BeginGroup = True
            Me.ButtonItemFilter_All.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemFilter_All.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemFilter_All.Name = "ButtonItemFilter_All"
            Me.ButtonItemFilter_All.RibbonWordWrap = False
            Me.ButtonItemFilter_All.SecurityEnabled = True
            Me.ButtonItemFilter_All.Stretch = True
            Me.ButtonItemFilter_All.SubItemsExpandWidth = 14
            Me.ButtonItemFilter_All.Text = "All"
            '
            'ButtonItemFilter_SelectedLineItem
            '
            Me.ButtonItemFilter_SelectedLineItem.AutoCheckOnClick = True
            Me.ButtonItemFilter_SelectedLineItem.BeginGroup = True
            Me.ButtonItemFilter_SelectedLineItem.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemFilter_SelectedLineItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemFilter_SelectedLineItem.Name = "ButtonItemFilter_SelectedLineItem"
            Me.ButtonItemFilter_SelectedLineItem.RibbonWordWrap = False
            Me.ButtonItemFilter_SelectedLineItem.SecurityEnabled = True
            Me.ButtonItemFilter_SelectedLineItem.Stretch = True
            Me.ButtonItemFilter_SelectedLineItem.SubItemsExpandWidth = 14
            Me.ButtonItemFilter_SelectedLineItem.Text = "Selected Line Item(s)"
            '
            'RibbonBarOptions_Documents
            '
            Me.RibbonBarOptions_Documents.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Documents.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Documents.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Documents.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Documents.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Documents.DragDropSupport = True
            Me.RibbonBarOptions_Documents.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemDocuments_Download})
            Me.RibbonBarOptions_Documents.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Documents.Location = New System.Drawing.Point(114, 0)
            Me.RibbonBarOptions_Documents.Name = "RibbonBarOptions_Documents"
            Me.RibbonBarOptions_Documents.SecurityEnabled = True
            Me.RibbonBarOptions_Documents.Size = New System.Drawing.Size(69, 92)
            Me.RibbonBarOptions_Documents.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Documents.TabIndex = 1
            Me.RibbonBarOptions_Documents.Text = "Documents"
            '
            '
            '
            Me.RibbonBarOptions_Documents.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Documents.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Documents.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            Me.RibbonBarOptions_Documents.Visible = False
            '
            'ButtonItemDocuments_Download
            '
            Me.ButtonItemDocuments_Download.BeginGroup = True
            Me.ButtonItemDocuments_Download.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDocuments_Download.Name = "ButtonItemDocuments_Download"
            Me.ButtonItemDocuments_Download.RibbonWordWrap = False
            Me.ButtonItemDocuments_Download.SecurityEnabled = True
            Me.ButtonItemDocuments_Download.SubItemsExpandWidth = 14
            Me.ButtonItemDocuments_Download.Text = "Download"
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Export})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(55, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(59, 92)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 3
            Me.RibbonBarOptions_Actions.Text = "Actions"
            '
            '
            '
            Me.RibbonBarOptions_Actions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Actions.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Actions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemActions_Export
            '
            Me.ButtonItemActions_Export.BeginGroup = True
            Me.ButtonItemActions_Export.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Export.Name = "ButtonItemActions_Export"
            Me.ButtonItemActions_Export.RibbonWordWrap = False
            Me.ButtonItemActions_Export.SecurityEnabled = True
            Me.ButtonItemActions_Export.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Export.Text = "Export"
            '
            'MediaBillingHistoryControl_BillingInvoices
            '
            Me.MediaBillingHistoryControl_BillingInvoices.Dock = System.Windows.Forms.DockStyle.Fill
            Me.MediaBillingHistoryControl_BillingInvoices.Location = New System.Drawing.Point(0, 0)
            Me.MediaBillingHistoryControl_BillingInvoices.Name = "MediaBillingHistoryControl_BillingInvoices"
            Me.MediaBillingHistoryControl_BillingInvoices.Size = New System.Drawing.Size(982, 555)
            Me.MediaBillingHistoryControl_BillingInvoices.TabIndex = 1
            '
            'BillingCommandCenterMediaBillingHistoryDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(992, 730)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "BillingCommandCenterMediaBillingHistoryDialog"
            Me.Text = "Media Billing History"
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
        Friend WithEvents RibbonBarOptions_Filter As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemFilter_All As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemFilter_SelectedLineItem As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Documents As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemDocuments_Download As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Export As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents MediaBillingHistoryControl_BillingInvoices As WinForm.Presentation.Controls.MediaBillingHistoryControl
    End Class

End Namespace