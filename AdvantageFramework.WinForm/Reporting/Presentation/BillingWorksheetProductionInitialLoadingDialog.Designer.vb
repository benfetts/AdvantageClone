Namespace Reporting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class BillingWorksheetProductionInitialLoadingDialog
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BillingWorksheetProductionInitialLoadingDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.TabControlProduction_Criteria = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelProductionOptionsTab_Options = New DevComponents.DotNetBar.TabControlPanel()
            Me.BillingWorksheetProductionControl = New AdvantageFramework.WinForm.Presentation.Controls.BillingWorksheetProductionControl()
            Me.TabItemProductionCriteria_OptionsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelProductionBillingBatchTab_BillingBatchID = New DevComponents.DotNetBar.TabControlPanel()
            Me.BillingBatchChooserControl_Production = New AdvantageFramework.WinForm.Presentation.Controls.BillingBatchChooserControl()
            Me.TabItemProductionCriteria_BillingBatchIDTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelProductionSelectClientsTab_SelectClients = New DevComponents.DotNetBar.TabControlPanel()
            Me.CDPChooserControl_Production = New AdvantageFramework.WinForm.Presentation.Controls.CDPChooserControl()
            Me.TabItemProductionCriteria_SelectClientsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives = New DevComponents.DotNetBar.TabControlPanel()
            Me.AEChooserControl_Production = New AdvantageFramework.WinForm.Presentation.Controls.AEChooserControl()
            Me.TabItemProductionCriteria_SelectAccountExecutivesTab = New DevComponents.DotNetBar.TabItem(Me.components)
            CType(Me.TabControlProduction_Criteria, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlProduction_Criteria.SuspendLayout()
            Me.TabControlPanelProductionOptionsTab_Options.SuspendLayout()
            Me.TabControlPanelProductionBillingBatchTab_BillingBatchID.SuspendLayout()
            Me.TabControlPanelProductionSelectClientsTab_SelectClients.SuspendLayout()
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.SuspendLayout()
            Me.SuspendLayout()
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(576, 561)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 6
            Me.ButtonForm_OK.Text = "OK"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(657, 561)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 7
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'TabControlProduction_Criteria
            '
            Me.TabControlProduction_Criteria.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlProduction_Criteria.BackColor = System.Drawing.Color.White
            Me.TabControlProduction_Criteria.CanReorderTabs = True
            Me.TabControlProduction_Criteria.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabControlProduction_Criteria.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabControlProduction_Criteria.Controls.Add(Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives)
            Me.TabControlProduction_Criteria.Controls.Add(Me.TabControlPanelProductionSelectClientsTab_SelectClients)
            Me.TabControlProduction_Criteria.Controls.Add(Me.TabControlPanelProductionBillingBatchTab_BillingBatchID)
            Me.TabControlProduction_Criteria.Controls.Add(Me.TabControlPanelProductionOptionsTab_Options)
            Me.TabControlProduction_Criteria.Location = New System.Drawing.Point(12, 12)
            Me.TabControlProduction_Criteria.Name = "TabControlProduction_Criteria"
            Me.TabControlProduction_Criteria.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlProduction_Criteria.SelectedTabIndex = 0
            Me.TabControlProduction_Criteria.Size = New System.Drawing.Size(720, 543)
            Me.TabControlProduction_Criteria.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlProduction_Criteria.TabIndex = 9
            Me.TabControlProduction_Criteria.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlProduction_Criteria.Tabs.Add(Me.TabItemProductionCriteria_OptionsTab)
            Me.TabControlProduction_Criteria.Tabs.Add(Me.TabItemProductionCriteria_BillingBatchIDTab)
            Me.TabControlProduction_Criteria.Tabs.Add(Me.TabItemProductionCriteria_SelectClientsTab)
            Me.TabControlProduction_Criteria.Tabs.Add(Me.TabItemProductionCriteria_SelectAccountExecutivesTab)
            Me.TabControlProduction_Criteria.Text = "TabControl1"
            '
            'TabControlPanelProductionOptionsTab_Options
            '
            Me.TabControlPanelProductionOptionsTab_Options.Controls.Add(Me.BillingWorksheetProductionControl)
            Me.TabControlPanelProductionOptionsTab_Options.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelProductionOptionsTab_Options.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelProductionOptionsTab_Options.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelProductionOptionsTab_Options.Name = "TabControlPanelProductionOptionsTab_Options"
            Me.TabControlPanelProductionOptionsTab_Options.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelProductionOptionsTab_Options.Size = New System.Drawing.Size(720, 516)
            Me.TabControlPanelProductionOptionsTab_Options.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelProductionOptionsTab_Options.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelProductionOptionsTab_Options.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelProductionOptionsTab_Options.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelProductionOptionsTab_Options.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelProductionOptionsTab_Options.Style.GradientAngle = 90
            Me.TabControlPanelProductionOptionsTab_Options.TabIndex = 1
            Me.TabControlPanelProductionOptionsTab_Options.TabItem = Me.TabItemProductionCriteria_OptionsTab
            '
            'BillingWorksheetProductionControl
            '
            Me.BillingWorksheetProductionControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.BillingWorksheetProductionControl.BackColor = System.Drawing.Color.Transparent
            Me.BillingWorksheetProductionControl.Location = New System.Drawing.Point(4, 4)
            Me.BillingWorksheetProductionControl.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
            Me.BillingWorksheetProductionControl.Name = "BillingWorksheetProductionControl"
            Me.BillingWorksheetProductionControl.Size = New System.Drawing.Size(712, 508)
            Me.BillingWorksheetProductionControl.TabIndex = 2
            '
            'TabItemProductionCriteria_OptionsTab
            '
            Me.TabItemProductionCriteria_OptionsTab.AttachedControl = Me.TabControlPanelProductionOptionsTab_Options
            Me.TabItemProductionCriteria_OptionsTab.Name = "TabItemProductionCriteria_OptionsTab"
            Me.TabItemProductionCriteria_OptionsTab.Text = "Options"
            '
            'TabControlPanelProductionBillingBatchTab_BillingBatchID
            '
            Me.TabControlPanelProductionBillingBatchTab_BillingBatchID.Controls.Add(Me.BillingBatchChooserControl_Production)
            Me.TabControlPanelProductionBillingBatchTab_BillingBatchID.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelProductionBillingBatchTab_BillingBatchID.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelProductionBillingBatchTab_BillingBatchID.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelProductionBillingBatchTab_BillingBatchID.Name = "TabControlPanelProductionBillingBatchTab_BillingBatchID"
            Me.TabControlPanelProductionBillingBatchTab_BillingBatchID.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelProductionBillingBatchTab_BillingBatchID.Size = New System.Drawing.Size(720, 516)
            Me.TabControlPanelProductionBillingBatchTab_BillingBatchID.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelProductionBillingBatchTab_BillingBatchID.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelProductionBillingBatchTab_BillingBatchID.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelProductionBillingBatchTab_BillingBatchID.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelProductionBillingBatchTab_BillingBatchID.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelProductionBillingBatchTab_BillingBatchID.Style.GradientAngle = 90
            Me.TabControlPanelProductionBillingBatchTab_BillingBatchID.TabIndex = 19
            Me.TabControlPanelProductionBillingBatchTab_BillingBatchID.TabItem = Me.TabItemProductionCriteria_BillingBatchIDTab
            '
            'BillingBatchChooserControl_Production
            '
            Me.BillingBatchChooserControl_Production.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.BillingBatchChooserControl_Production.BackColor = System.Drawing.Color.Transparent
            Me.BillingBatchChooserControl_Production.Location = New System.Drawing.Point(4, 4)
            Me.BillingBatchChooserControl_Production.Name = "BillingBatchChooserControl_Production"
            Me.BillingBatchChooserControl_Production.Size = New System.Drawing.Size(712, 508)
            Me.BillingBatchChooserControl_Production.TabIndex = 0
            '
            'TabItemProductionCriteria_BillingBatchIDTab
            '
            Me.TabItemProductionCriteria_BillingBatchIDTab.AttachedControl = Me.TabControlPanelProductionBillingBatchTab_BillingBatchID
            Me.TabItemProductionCriteria_BillingBatchIDTab.Name = "TabItemProductionCriteria_BillingBatchIDTab"
            Me.TabItemProductionCriteria_BillingBatchIDTab.Text = "Billing Batch ID"
            '
            'TabControlPanelProductionSelectClientsTab_SelectClients
            '
            Me.TabControlPanelProductionSelectClientsTab_SelectClients.Controls.Add(Me.CDPChooserControl_Production)
            Me.TabControlPanelProductionSelectClientsTab_SelectClients.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelProductionSelectClientsTab_SelectClients.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelProductionSelectClientsTab_SelectClients.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelProductionSelectClientsTab_SelectClients.Name = "TabControlPanelProductionSelectClientsTab_SelectClients"
            Me.TabControlPanelProductionSelectClientsTab_SelectClients.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelProductionSelectClientsTab_SelectClients.Size = New System.Drawing.Size(720, 516)
            Me.TabControlPanelProductionSelectClientsTab_SelectClients.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelProductionSelectClientsTab_SelectClients.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelProductionSelectClientsTab_SelectClients.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelProductionSelectClientsTab_SelectClients.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelProductionSelectClientsTab_SelectClients.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelProductionSelectClientsTab_SelectClients.Style.GradientAngle = 90
            Me.TabControlPanelProductionSelectClientsTab_SelectClients.TabIndex = 5
            Me.TabControlPanelProductionSelectClientsTab_SelectClients.TabItem = Me.TabItemProductionCriteria_SelectClientsTab
            '
            'CDPChooserControl_Production
            '
            Me.CDPChooserControl_Production.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CDPChooserControl_Production.BackColor = System.Drawing.Color.Transparent
            Me.CDPChooserControl_Production.Location = New System.Drawing.Point(4, 4)
            Me.CDPChooserControl_Production.Name = "CDPChooserControl_Production"
            Me.CDPChooserControl_Production.Size = New System.Drawing.Size(712, 508)
            Me.CDPChooserControl_Production.TabIndex = 0
            '
            'TabItemProductionCriteria_SelectClientsTab
            '
            Me.TabItemProductionCriteria_SelectClientsTab.AttachedControl = Me.TabControlPanelProductionSelectClientsTab_SelectClients
            Me.TabItemProductionCriteria_SelectClientsTab.Name = "TabItemProductionCriteria_SelectClientsTab"
            Me.TabItemProductionCriteria_SelectClientsTab.Text = "Select Clients"
            '
            'TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives
            '
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.Controls.Add(Me.AEChooserControl_Production)
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.DisabledBackColor = System.Drawing.Color.Empty
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.Location = New System.Drawing.Point(0, 27)
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.Name = "TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives"
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.Size = New System.Drawing.Size(720, 516)
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.Style.BackColor1.Color = System.Drawing.Color.White
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.Style.GradientAngle = 90
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.TabIndex = 9
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.TabItem = Me.TabItemProductionCriteria_SelectAccountExecutivesTab
            '
            'AEChooserControl_Production
            '
            Me.AEChooserControl_Production.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.AEChooserControl_Production.BackColor = System.Drawing.Color.Transparent
            Me.AEChooserControl_Production.Location = New System.Drawing.Point(4, 4)
            Me.AEChooserControl_Production.Name = "AEChooserControl_Production"
            Me.AEChooserControl_Production.Size = New System.Drawing.Size(712, 508)
            Me.AEChooserControl_Production.TabIndex = 0
            '
            'TabItemProductionCriteria_SelectAccountExecutivesTab
            '
            Me.TabItemProductionCriteria_SelectAccountExecutivesTab.AttachedControl = Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives
            Me.TabItemProductionCriteria_SelectAccountExecutivesTab.Name = "TabItemProductionCriteria_SelectAccountExecutivesTab"
            Me.TabItemProductionCriteria_SelectAccountExecutivesTab.Text = "Select Account Executives"
            '
            'BillingWorksheetProductionInitialLoadingDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(744, 593)
            Me.Controls.Add(Me.TabControlProduction_Criteria)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "BillingWorksheetProductionInitialLoadingDialog"
            Me.Text = "Billing Criteria"
            CType(Me.TabControlProduction_Criteria, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlProduction_Criteria.ResumeLayout(False)
            Me.TabControlPanelProductionOptionsTab_Options.ResumeLayout(False)
            Me.TabControlPanelProductionBillingBatchTab_BillingBatchID.ResumeLayout(False)
            Me.TabControlPanelProductionSelectClientsTab_SelectClients.ResumeLayout(False)
            Me.TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents TabControlProduction_Criteria As WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelProductionOptionsTab_Options As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents BillingWorksheetProductionControl As WinForm.Presentation.Controls.BillingWorksheetProductionControl
        Friend WithEvents TabItemProductionCriteria_OptionsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelProductionBillingBatchTab_BillingBatchID As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents BillingBatchChooserControl_Production As WinForm.Presentation.Controls.BillingBatchChooserControl
        Friend WithEvents TabItemProductionCriteria_BillingBatchIDTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelProductionSelectClientsTab_SelectClients As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents CDPChooserControl_Production As WinForm.Presentation.Controls.CDPChooserControl
        Friend WithEvents TabItemProductionCriteria_SelectClientsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelProductionSelectAccountExecutivesTab_SelectAccountExecutives As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents AEChooserControl_Production As WinForm.Presentation.Controls.AEChooserControl
        Friend WithEvents TabItemProductionCriteria_SelectAccountExecutivesTab As DevComponents.DotNetBar.TabItem
    End Class

End Namespace