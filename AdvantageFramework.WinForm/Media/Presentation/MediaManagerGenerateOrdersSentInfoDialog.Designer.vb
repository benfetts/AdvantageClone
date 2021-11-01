Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaManagerGenerateOrdersSentInfoDialog
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
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaManagerGenerateOrdersSentInfoDialog))
            Me.LabelItemAdvanceBilling_PercenToBill = New DevComponents.DotNetBar.LabelItem()
            Me.LabelItemAdvanceBilling_PercentBilled = New DevComponents.DotNetBar.LabelItem()
            Me.ItemContainerBillingSelectionVertical_Top = New DevComponents.DotNetBar.ItemContainer()
            Me.ControlContainerItemBS_InvoiceDate = New DevComponents.DotNetBar.ControlContainerItem()
            Me.DataGridViewDetails_Details = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
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
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(734, 154)
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
            Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 57)
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(734, 94)
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
            Me.PanelForm_Form.Controls.Add(Me.DataGridViewDetails_Details)
            Me.PanelForm_Form.Size = New System.Drawing.Size(734, 277)
            '
            'BarForm_StatusBar
            '
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 432)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(734, 18)
            '
            'LabelItemAdvanceBilling_PercenToBill
            '
            Me.LabelItemAdvanceBilling_PercenToBill.Name = "LabelItemAdvanceBilling_PercenToBill"
            Me.LabelItemAdvanceBilling_PercenToBill.Text = "% to Bill:"
            Me.LabelItemAdvanceBilling_PercenToBill.Width = 55
            '
            'LabelItemAdvanceBilling_PercentBilled
            '
            Me.LabelItemAdvanceBilling_PercentBilled.Name = "LabelItemAdvanceBilling_PercentBilled"
            Me.LabelItemAdvanceBilling_PercentBilled.Text = "% Billed:"
            Me.LabelItemAdvanceBilling_PercentBilled.Width = 55
            '
            'ItemContainerBillingSelectionVertical_Top
            '
            '
            '
            '
            Me.ItemContainerBillingSelectionVertical_Top.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerBillingSelectionVertical_Top.Name = "ItemContainerBillingSelectionVertical_Top"
            Me.ItemContainerBillingSelectionVertical_Top.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemAdvanceBilling_PercenToBill, Me.ControlContainerItemBS_InvoiceDate})
            '
            '
            '
            Me.ItemContainerBillingSelectionVertical_Top.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ControlContainerItemBS_InvoiceDate
            '
            Me.ControlContainerItemBS_InvoiceDate.AllowItemResize = True
            Me.ControlContainerItemBS_InvoiceDate.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItemBS_InvoiceDate.Name = "ControlContainerItemBS_InvoiceDate"
            Me.ControlContainerItemBS_InvoiceDate.Text = "ControlContainerItem2"
            '
            'DataGridViewDetails_Details
            '
            Me.DataGridViewDetails_Details.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewDetails_Details.AllowDragAndDrop = False
            Me.DataGridViewDetails_Details.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewDetails_Details.AllowSelectGroupHeaderRow = True
            Me.DataGridViewDetails_Details.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewDetails_Details.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewDetails_Details.AutoFilterLookupColumns = False
            Me.DataGridViewDetails_Details.AutoloadRepositoryDatasource = False
            Me.DataGridViewDetails_Details.AutoUpdateViewCaption = True
            Me.DataGridViewDetails_Details.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewDetails_Details.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewDetails_Details.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewDetails_Details.ItemDescription = ""
            Me.DataGridViewDetails_Details.Location = New System.Drawing.Point(13, 7)
            Me.DataGridViewDetails_Details.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewDetails_Details.MultiSelect = True
            Me.DataGridViewDetails_Details.Name = "DataGridViewDetails_Details"
            Me.DataGridViewDetails_Details.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewDetails_Details.RunStandardValidation = True
            Me.DataGridViewDetails_Details.ShowColumnMenuOnRightClick = False
            Me.DataGridViewDetails_Details.ShowSelectDeselectAllButtons = False
            Me.DataGridViewDetails_Details.Size = New System.Drawing.Size(708, 263)
            Me.DataGridViewDetails_Details.TabIndex = 2
            Me.DataGridViewDetails_Details.UseEmbeddedNavigator = False
            Me.DataGridViewDetails_Details.ViewCaptionHeight = -1
            '
            'MediaManagerGenerateOrdersSentInfoDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(744, 452)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaManagerGenerateOrdersSentInfoDialog"
            Me.Text = "Recipient Info"
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
        Friend WithEvents ItemContainerBillingSelectionVertical_Top As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ControlContainerItemBS_InvoiceDate As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents LabelItemAdvanceBilling_PercenToBill As DevComponents.DotNetBar.LabelItem
        Friend WithEvents LabelItemAdvanceBilling_PercentBilled As DevComponents.DotNetBar.LabelItem
        Friend WithEvents DataGridViewDetails_Details As WinForm.Presentation.Controls.DataGridView
    End Class

End Namespace