<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdvantageSecuritySetupForm
    Inherits AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdvantageSecuritySetupForm))
        Me.RibbonPanelFile_FilePanel.SuspendLayout()
        Me.RibbonControlForm_MainRibbon.SuspendLayout()
        Me.SuspendLayout()
        '
        'RibbonPanelFile_FilePanel
        '
        Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 54)
        Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(790, 98)
        '
        '
        '
        Me.RibbonPanelFile_FilePanel.Style.Class = ""
        Me.RibbonPanelFile_FilePanel.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanelFile_FilePanel.StyleMouseDown.Class = ""
        Me.RibbonPanelFile_FilePanel.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanelFile_FilePanel.StyleMouseOver.Class = ""
        Me.RibbonPanelFile_FilePanel.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'RibbonBarFilePanel_System
        '
        '
        '
        '
        Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.Class = ""
        Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBarFilePanel_System.BackgroundStyle.Class = ""
        Me.RibbonBarFilePanel_System.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBarFilePanel_System.TitleStyle.Class = ""
        Me.RibbonBarFilePanel_System.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBarFilePanel_System.TitleStyleMouseOver.Class = ""
        Me.RibbonBarFilePanel_System.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'RibbonControlForm_MainRibbon
        '
        '
        '
        '
        Me.RibbonControlForm_MainRibbon.BackgroundStyle.Class = ""
        Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(790, 154)
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
        'ButtonItemSystem_Exit
        '
        Me.ButtonItemSystem_Exit.Image = CType(resources.GetObject("ButtonItemSystem_Exit.Image"), System.Drawing.Image)
        '
        'ButtonItemMainRibbon_Help
        '
        Me.ButtonItemMainRibbon_Help.Image = CType(resources.GetObject("ButtonItemMainRibbon_Help.Image"), System.Drawing.Image)
        '
        'ButtonItemMainRibbon_ShowAndHide
        '
        Me.ButtonItemMainRibbon_ShowAndHide.Image = CType(resources.GetObject("ButtonItemMainRibbon_ShowAndHide.Image"), System.Drawing.Image)
        '
        'TabStripForm_MDIChildren
        '
        Me.TabStripForm_MDIChildren.Size = New System.Drawing.Size(790, 20)
        '
        'AdvantageSecuritySetupForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 456)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(0, 0)
        Me.Name = "AdvantageSecuritySetupForm"
        Me.Text = "Advantage Security Setup"
        Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
        Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
        Me.RibbonControlForm_MainRibbon.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
End Class
