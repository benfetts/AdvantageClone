Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaRFPVendorMarketCrossReferenceDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaRFPVendorMarketCrossReferenceDialog))
            Me.RibbonBarFilePanel_Actions = New DevComponents.DotNetBar.RibbonBar()
            Me.ButtonItemActions_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.DataGridViewPanel_VendorMarkets = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.LabelPanel_VendorName = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.TextBoxPanel_VendorName = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox()
            Me.LabelPanel_VendorCode = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.TextBoxPanel_VendorCode = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Form.SuspendLayout()
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
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
            Me.PanelForm_Form.Controls.Add(Me.LabelPanel_VendorName)
            Me.PanelForm_Form.Controls.Add(Me.TextBoxPanel_VendorName)
            Me.PanelForm_Form.Controls.Add(Me.LabelPanel_VendorCode)
            Me.PanelForm_Form.Controls.Add(Me.TextBoxPanel_VendorCode)
            Me.PanelForm_Form.Controls.Add(Me.DataGridViewPanel_VendorMarkets)
            Me.PanelForm_Form.LookAndFeel.SkinName = "Office 2013"
            Me.PanelForm_Form.LookAndFeel.UseDefaultLookAndFeel = False
            Me.PanelForm_Form.Size = New System.Drawing.Size(985, 434)
            Me.PanelForm_Form.TabIndex = 0
            '
            'RibbonControlForm_MainRibbon
            '
            '
            '
            '
            Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(985, 154)
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
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarFilePanel_Actions)
            Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 57)
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(985, 94)
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
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarFilePanel_Actions, 0)
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
            'ProgressBarItemStatusBar_ProgressBar
            '
            '
            '
            '
            Me.ProgressBarItemStatusBar_ProgressBar.BackStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'BarForm_StatusBar
            '
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 589)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(985, 18)
            '
            'RibbonBarFilePanel_Actions
            '
            Me.RibbonBarFilePanel_Actions.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBarFilePanel_Actions.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_Actions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFilePanel_Actions.ContainerControlProcessDialogKey = True
            Me.RibbonBarFilePanel_Actions.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarFilePanel_Actions.DragDropSupport = True
            Me.RibbonBarFilePanel_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Save, Me.ButtonItemActions_Delete, Me.ButtonItemActions_Cancel})
            Me.RibbonBarFilePanel_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarFilePanel_Actions.Location = New System.Drawing.Point(103, 0)
            Me.RibbonBarFilePanel_Actions.Name = "RibbonBarFilePanel_Actions"
            Me.RibbonBarFilePanel_Actions.Size = New System.Drawing.Size(145, 92)
            Me.RibbonBarFilePanel_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarFilePanel_Actions.TabIndex = 1
            Me.RibbonBarFilePanel_Actions.Text = "Actions"
            '
            '
            '
            Me.RibbonBarFilePanel_Actions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_Actions.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemActions_Save
            '
            Me.ButtonItemActions_Save.BeginGroup = True
            Me.ButtonItemActions_Save.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Save.Name = "ButtonItemActions_Save"
            Me.ButtonItemActions_Save.RibbonWordWrap = False
            Me.ButtonItemActions_Save.SecurityEnabled = True
            Me.ButtonItemActions_Save.Stretch = True
            Me.ButtonItemActions_Save.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Save.Text = "Save"
            '
            'ButtonItemActions_Delete
            '
            Me.ButtonItemActions_Delete.BeginGroup = True
            Me.ButtonItemActions_Delete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Delete.Name = "ButtonItemActions_Delete"
            Me.ButtonItemActions_Delete.RibbonWordWrap = False
            Me.ButtonItemActions_Delete.SecurityEnabled = True
            Me.ButtonItemActions_Delete.Stretch = True
            Me.ButtonItemActions_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Delete.Text = "Delete"
            '
            'ButtonItemActions_Cancel
            '
            Me.ButtonItemActions_Cancel.BeginGroup = True
            Me.ButtonItemActions_Cancel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Cancel.Name = "ButtonItemActions_Cancel"
            Me.ButtonItemActions_Cancel.RibbonWordWrap = False
            Me.ButtonItemActions_Cancel.SecurityEnabled = True
            Me.ButtonItemActions_Cancel.Stretch = True
            Me.ButtonItemActions_Cancel.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Cancel.Text = "Cancel"
            '
            'DataGridViewPanel_VendorMarkets
            '
            Me.DataGridViewPanel_VendorMarkets.AllowSelectGroupHeaderRow = True
            Me.DataGridViewPanel_VendorMarkets.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewPanel_VendorMarkets.AutoUpdateViewCaption = True
            Me.DataGridViewPanel_VendorMarkets.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewPanel_VendorMarkets.ItemDescription = "Vendor Market(s)"
            Me.DataGridViewPanel_VendorMarkets.Location = New System.Drawing.Point(12, 32)
            Me.DataGridViewPanel_VendorMarkets.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewPanel_VendorMarkets.ModifyGridRowHeight = False
            Me.DataGridViewPanel_VendorMarkets.MultiSelect = True
            Me.DataGridViewPanel_VendorMarkets.Name = "DataGridViewPanel_VendorMarkets"
            Me.DataGridViewPanel_VendorMarkets.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewPanel_VendorMarkets.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewPanel_VendorMarkets.ShowRowSelectionIfHidden = True
            Me.DataGridViewPanel_VendorMarkets.ShowSelectDeselectAllButtons = False
            Me.DataGridViewPanel_VendorMarkets.Size = New System.Drawing.Size(961, 396)
            Me.DataGridViewPanel_VendorMarkets.TabIndex = 5
            Me.DataGridViewPanel_VendorMarkets.UseEmbeddedNavigator = False
            Me.DataGridViewPanel_VendorMarkets.ViewCaptionHeight = -1
            '
            'LabelPanel_VendorName
            '
            Me.LabelPanel_VendorName.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPanel_VendorName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPanel_VendorName.Location = New System.Drawing.Point(172, 6)
            Me.LabelPanel_VendorName.Name = "LabelPanel_VendorName"
            Me.LabelPanel_VendorName.Size = New System.Drawing.Size(82, 20)
            Me.LabelPanel_VendorName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPanel_VendorName.TabIndex = 8
            Me.LabelPanel_VendorName.Text = "Vendor Name:"
            '
            'TextBoxPanel_VendorName
            '
            Me.TextBoxPanel_VendorName.AgencyImportPath = Nothing
            Me.TextBoxPanel_VendorName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxPanel_VendorName.Border.Class = "TextBoxBorder"
            Me.TextBoxPanel_VendorName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxPanel_VendorName.CheckSpellingOnValidate = False
            Me.TextBoxPanel_VendorName.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxPanel_VendorName.DisplayName = ""
            Me.TextBoxPanel_VendorName.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxPanel_VendorName.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxPanel_VendorName.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxPanel_VendorName.FocusHighlightEnabled = True
            Me.TextBoxPanel_VendorName.Location = New System.Drawing.Point(260, 6)
            Me.TextBoxPanel_VendorName.MaxFileSize = CType(0, Long)
            Me.TextBoxPanel_VendorName.Name = "TextBoxPanel_VendorName"
            Me.TextBoxPanel_VendorName.PreventEnterBeep = True
            Me.TextBoxPanel_VendorName.SecurityEnabled = True
            Me.TextBoxPanel_VendorName.ShowSpellCheckCompleteMessage = True
            Me.TextBoxPanel_VendorName.Size = New System.Drawing.Size(713, 21)
            Me.TextBoxPanel_VendorName.StartingFolderName = Nothing
            Me.TextBoxPanel_VendorName.TabIndex = 9
            Me.TextBoxPanel_VendorName.TabOnEnter = True
            '
            'LabelPanel_VendorCode
            '
            Me.LabelPanel_VendorCode.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPanel_VendorCode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPanel_VendorCode.Location = New System.Drawing.Point(12, 6)
            Me.LabelPanel_VendorCode.Name = "LabelPanel_VendorCode"
            Me.LabelPanel_VendorCode.Size = New System.Drawing.Size(82, 20)
            Me.LabelPanel_VendorCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPanel_VendorCode.TabIndex = 6
            Me.LabelPanel_VendorCode.Text = "Vendor Code:"
            '
            'TextBoxPanel_VendorCode
            '
            Me.TextBoxPanel_VendorCode.AgencyImportPath = Nothing
            '
            '
            '
            Me.TextBoxPanel_VendorCode.Border.Class = "TextBoxBorder"
            Me.TextBoxPanel_VendorCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxPanel_VendorCode.CheckSpellingOnValidate = False
            Me.TextBoxPanel_VendorCode.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxPanel_VendorCode.DisplayName = ""
            Me.TextBoxPanel_VendorCode.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxPanel_VendorCode.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxPanel_VendorCode.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxPanel_VendorCode.FocusHighlightEnabled = True
            Me.TextBoxPanel_VendorCode.Location = New System.Drawing.Point(100, 6)
            Me.TextBoxPanel_VendorCode.MaxFileSize = CType(0, Long)
            Me.TextBoxPanel_VendorCode.Name = "TextBoxPanel_VendorCode"
            Me.TextBoxPanel_VendorCode.PreventEnterBeep = True
            Me.TextBoxPanel_VendorCode.SecurityEnabled = True
            Me.TextBoxPanel_VendorCode.ShowSpellCheckCompleteMessage = True
            Me.TextBoxPanel_VendorCode.Size = New System.Drawing.Size(66, 21)
            Me.TextBoxPanel_VendorCode.StartingFolderName = Nothing
            Me.TextBoxPanel_VendorCode.TabIndex = 7
            Me.TextBoxPanel_VendorCode.TabOnEnter = True
            '
            'MediaRFPVendorMarketCrossReferenceDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(995, 609)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaRFPVendorMarketCrossReferenceDialog"
            Me.Text = "Vendor Market Cross Reference"
            Me.Controls.SetChildIndex(Me.BarForm_StatusBar, 0)
            Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
            Me.Controls.SetChildIndex(Me.PanelForm_Form, 0)
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Form.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.PerformLayout()
            Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarFilePanel_Actions As DevComponents.DotNetBar.RibbonBar
        Friend WithEvents ButtonItemActions_Save As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents LabelPanel_VendorName As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents TextBoxPanel_VendorName As WinForm.MVC.Presentation.Controls.TextBox
        Friend WithEvents LabelPanel_VendorCode As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents TextBoxPanel_VendorCode As WinForm.MVC.Presentation.Controls.TextBox
        Friend WithEvents DataGridViewPanel_VendorMarkets As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents ButtonItemActions_Cancel As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Delete As WinForm.Presentation.Controls.ButtonItem
    End Class

End Namespace